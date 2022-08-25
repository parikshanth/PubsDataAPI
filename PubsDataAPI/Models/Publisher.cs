namespace PubsDataAPI.Models
{
    public class Publisher
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public ICollection<Title> Titles { get; set; }
    }
}
