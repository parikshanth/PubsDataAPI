namespace PubsDataAPI.Models
{
    public class Sale
    {
        public Store Store { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string PaymentTerms { get; set; }
        public Title Title { get; set; }

    }
}
