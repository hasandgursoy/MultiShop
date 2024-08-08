using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using System.Xml.Linq;


namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            // Sample Selected Value Update
            //Builders<Product>.Update.Combine(
            //string.IsNullOrEmpty(updateProductDto.CategoryId) ? Builders<Product>.Update.Set(p => p.CategoryId,updateProductDto.CategoryId) : null,
            //string.IsNullOrEmpty(updateProductDto.ProductImageUrl) ? Builders<Product>.Update.Set(p => p.ProductImageUrl, updateProductDto.ProductImageUrl) : null,
            //updateProductDto.ProductPrice != decimal.Zero ? Builders<Product>.Update.Set(p => p.ProductPrice, updateProductDto.ProductPrice) : null,
            //string.IsNullOrEmpty(updateProductDto.ProductDescription) ? Builders<Product>.Update.Set(p => p.ProductDescription, updateProductDto.ProductDescription) : null);

            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, product);

        }
    }
}
