namespace Models
{
    public class MatchingRideRequest
    {
        public string Email { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public DateTime RideValidFrom { get; set; }
        public DateTime RideVaildTill { get; set; }
    }
}
