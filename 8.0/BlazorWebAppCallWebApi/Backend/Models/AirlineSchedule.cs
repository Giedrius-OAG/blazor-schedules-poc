namespace Backend.Models;

public sealed class AirlineSchedule
{
    public string Id { get; set; }
    
    public string FlightNumber { get; set; }
    
    public string DepartureAirport { get; set; }
    
    public string ArrivalAirport { get; set; }
    
    public DateTime DepartureTime { get; set; }
    
    public DateTime ArrivalTime { get; set; }
}
