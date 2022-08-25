namespace PubsDataAPI.Models
{
    public class Employee
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleInitial { get; set; }
        public String LastName { get; set; }
        public Job Job { get; set; }
        public int JobLevel { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime HireDate { get; set; }
    }
}
