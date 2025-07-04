﻿namespace FoodMartMongo.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string PeopleLookingCollectionName { get; set; }
        public string UserCollectionName { get; set; }
    }
   
}
