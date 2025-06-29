using AutoMapper;
using FoodMartMongo.Dtos.CategoryDtos;
using FoodMartMongo.Dtos.CustomerDtos;
using FoodMartMongo.Dtos.DiscountDtos;
using FoodMartMongo.Dtos.PeopleLookingDtos;
using FoodMartMongo.Dtos.ProductDto;
using FoodMartMongo.Dtos.SliderDtos;
using FoodMartMongo.Entities;

namespace FoodMartMongo.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetProductByIdDto>().ReverseMap();

            CreateMap<Customer,ResultCustomerDto>().ReverseMap();
            CreateMap<Customer,CreateCustomerDto>().ReverseMap();
            CreateMap<Customer,UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer,GetCustomerByIdDto>().ReverseMap();

            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider,CreateSliderDto>().ReverseMap();
            CreateMap<Slider,UpdateSliderDto>().ReverseMap();
            CreateMap<Slider,GetSliderByIdDto>().ReverseMap();

            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountByIdDto>().ReverseMap();

            CreateMap<PeopleLooking,ResultPeopleLookingDto>().ReverseMap();
            CreateMap<PeopleLooking,CreatePeopleLookingDto>().ReverseMap();
            CreateMap<PeopleLooking,UpdatePeopleLookingDto>().ReverseMap();
            CreateMap<PeopleLooking,GetPeopleLookingByIdDto>().ReverseMap();
        }
    }
}
