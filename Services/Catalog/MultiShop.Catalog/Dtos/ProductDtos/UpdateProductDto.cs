using System.Text.Json.Serialization;
using ThirdParty.Json.LitJson;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ProductDescription { get; set; }
        public string? CategoryId { get; set; }
    }
}
