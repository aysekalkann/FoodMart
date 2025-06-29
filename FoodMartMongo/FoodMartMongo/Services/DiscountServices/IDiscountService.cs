using FoodMartMongo.Dtos.DiscountDtos;

namespace FoodMartMongo.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string discountid);
        Task<GetDiscountByIdDto> GetDiscountByIdAsync(string discountid);
    }
}
