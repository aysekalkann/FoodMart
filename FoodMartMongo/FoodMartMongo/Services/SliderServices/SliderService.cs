﻿using AutoMapper;
using FoodMartMongo.Dtos.SliderDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _sliderCollection=database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value=_mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x=>x.SliderId==id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var value = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(value);
        }

        public async Task<GetSliderByIdDto> GetSliderByIdAsync(string sliderId)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == sliderId).FirstOrDefaultAsync();
            return _mapper.Map<GetSliderByIdDto>(value);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var value=_mapper.Map<Slider>(updateSliderDto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, value);
        }
    }
}
