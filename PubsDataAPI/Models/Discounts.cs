namespace PubsDataAPI.Models
{
    public class Discounts
    {
        public string DiscountType { get; set; }
        public Store Store  { get; set; }
        public int LowQuantity { get; set; }
        public int HighQuantity { get; set; }
        public float Discount { get; set; }
    }
}
