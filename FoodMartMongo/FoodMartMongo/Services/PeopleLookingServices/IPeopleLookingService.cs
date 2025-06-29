using FoodMartMongo.Dtos.PeopleLookingDtos;

namespace FoodMartMongo.Services.PeopleLookingServices
{
    public interface IPeopleLookingService
    {
        Task<List<ResultPeopleLookingDto>>GetAllPeopleLookingAsync();
        Task CreatePeopleLookingAsync(CreatePeopleLookingDto createPeopleLookingDto);
        Task UpdatePeopleLookingAsync(UpdatePeopleLookingDto updatePeopleLookingDto);
        Task DeletePeopleLookingAsync(string id);
        Task<GetPeopleLookingByIdDto> GetPeopleLookingByIdAsync(string id);

    }
}
