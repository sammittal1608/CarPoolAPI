namespace Models
{
    public class MatchingRideResponse
    {
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public string CustomerId { get; set; }
        public int Seats { get; set; }
        public float Price { get; set; }

    }
}
