using FoodMartMongo.Entities;
using FoodMartMongo.Services.UserService;
using FoodMartMongo.Settings;
using MongoDB.Driver;
using System.Threading.Tasks;
using BCrypt.Net;

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _userCollection;

    public UserService(IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _userCollection = database.GetCollection<User>(databaseSettings.UserCollectionName);
    }

    // Şifreyi güvenli bir şekilde kontrol eder (BCrypt ile)
    public Task<bool> CheckPasswordAsync(User user, string password)
    {
        return Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.Password));
    }

    // Kullanıcıyı kullanıcı adına göre getirir
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _userCollection.Find(x => x.UserName == username).FirstOrDefaultAsync();
    }

    // Yeni kullanıcı kaydederken şifreyi hash'ler
    public async Task RegisterUserAsync(User user)
    {
        // Aynı kullanıcı adı var mı kontrol et
        var existingUser = await GetUserByUsernameAsync(user.UserName);
        if (existingUser != null)
        {
            throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
        }

        // Şifreyi hash'le
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _userCollection.InsertOneAsync(user);
    }
    public async Task MigratePlaintextPasswordsAsync()
    {
        var users = await _userCollection.Find(_ => true).ToListAsync();

        foreach (var user in users)
        {
            // Hash formatı kontrolü: $2a$, $2b$, $2y$ gibi başlamıyorsa büyük ihtimalle düz metindir
            if (!user.Password.StartsWith("$2a$") && !user.Password.StartsWith("$2b$") && !user.Password.StartsWith("$2y$"))
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);

                var update = Builders<User>.Update.Set(u => u.Password, hashed);
                await _userCollection.UpdateOneAsync(u => u.UserId == user.UserId, update);

                Console.WriteLine($"[✓] Kullanıcı: {user.UserName} şifresi hash'lendi.");
            }
        }

        Console.WriteLine("Şifre geçiş işlemi tamamlandı.");
    }

}
