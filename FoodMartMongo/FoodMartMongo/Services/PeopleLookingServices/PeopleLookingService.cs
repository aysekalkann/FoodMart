using AutoMapper;
using FoodMartMongo.Dtos.PeopleLookingDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.PeopleLookingServices
{
    public class PeopleLookingService : IPeopleLookingService
    {
        private readonly IMongoCollection<PeopleLooking> _peopleLookingCollection;
        private readonly IMapper _mapper;
        private MongoClientSettings _databaseSettings;

        public PeopleLookingService(IMapper mapper,IDatabaseSettings _databaseSettings )
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mapper = mapper;
            _peopleLookingCollection =database.GetCollection<PeopleLooking>(_databaseSettings.PeopleLookingCollectionName);
        }

        public async Task CreatePeopleLookingAsync(CreatePeopleLookingDto createPeopleLookingDto)
        {
            var value=_mapper.Map<PeopleLooking>(createPeopleLookingDto);
            await _peopleLookingCollection.InsertOneAsync(value);
        }

        public async Task DeletePeopleLookingAsync(string id)
        {
            await _peopleLookingCollection.DeleteOneAsync(x=>x.PeopleLookingId==id);
        }

        public async Task<List<ResultPeopleLookingDto>> GetAllPeopleLookingAsync()
        {
            var values=await _peopleLookingCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultPeopleLookingDto>>(values);
        }

        public async Task<GetPeopleLookingByIdDto> GetPeopleLookingByIdAsync(string id)
        {
            var value=await _peopleLookingCollection.Find(x=>x.PeopleLookingId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetPeopleLookingByIdDto>(value);
        }

        public async Task UpdatePeopleLookingAsync(UpdatePeopleLookingDto updatePeopleLookingDto)
        {
            var values = _mapper.Map<PeopleLooking>(updatePeopleLookingDto);
            await _peopleLookingCollection.FindOneAndReplaceAsync(x => x.PeopleLookingId == updatePeopleLookingDto.PeopleLookingId, values);
        }
    }
}
