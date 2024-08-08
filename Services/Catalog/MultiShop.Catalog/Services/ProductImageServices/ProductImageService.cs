﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageImageServices
{
    public class ProductImageService : IProductImageService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var product = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, product);

        }
    }
}
