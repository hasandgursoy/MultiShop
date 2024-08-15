namespace MultiShop.Order.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string DistrictId { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
