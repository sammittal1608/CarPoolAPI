namespace Models
{
    public class OfferRide
    {
        public string OwnerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date {get;set ; }
        public DateTime RideValidFrom { get; set; }
        public DateTime RideValidTill { get; set; }
        public int AvailableSeats { get; set; }
        public List<string> IntermediaryStops { get; set; }
        public float Price { get; set; }
        public string CustomerId { get; set; }
        public bool IsRideBooked { get; set; }
    }
}
