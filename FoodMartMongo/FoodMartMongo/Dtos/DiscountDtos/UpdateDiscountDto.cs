﻿namespace FoodMartMongo.Dtos.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public string DiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
