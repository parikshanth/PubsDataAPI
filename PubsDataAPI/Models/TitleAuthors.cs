using System.Transactions;

namespace PubsDataAPI.Models
{
    public class TitleAuthors
    {
        public Author Author { get; set; }
        public Title Title { get; set; }
        public int AuthorOrdinal { get; set; }
        public int RoyaltyPercent { get; set; }
    }
}
