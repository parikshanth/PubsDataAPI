namespace PubsDataAPI.Models
{
    public class Title
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }

        public string? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YTDSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
