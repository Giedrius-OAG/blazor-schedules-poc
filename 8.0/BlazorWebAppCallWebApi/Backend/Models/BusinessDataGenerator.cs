namespace Backend.Models

{
    public static class BusinessDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        
        public static List<AirlineSchedule> GenerateRandomSchedules(int numberOfSchedules = 10)
        {
            var random = new Random();
            var schedules = new List<AirlineSchedule>();

            for (var i = 0; i < numberOfSchedules; i++)
            {
                var flightNumber = GenerateRandomFlightNumber(random);
                var (departureAirport, arrivalAirport) = GenerateRandomAirports(random);
                var (departureTime, arrivalTime) = GenerateRandomFlightTimes(random);

                schedules.Add(new AirlineSchedule
                {
                    Id = Guid.NewGuid().ToString(),
                    FlightNumber = flightNumber,
                    DepartureAirport = departureAirport,
                    ArrivalAirport = arrivalAirport,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime
                });
            }

            return schedules;
        }

        private static string GenerateRandomFlightNumber(Random random)
        {
            
            return new string(Enumerable.Repeat(Letters, 3).Select(s => s[random.Next(s.Length)]).ToArray()) +
                   new string(Enumerable.Repeat(Numbers, 3).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static (string, string) GenerateRandomAirports(Random random)
        {
            string departureAirport, arrivalAirport;
            do
            {
                departureAirport = new string(Enumerable.Repeat(Letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());
                arrivalAirport = new string(Enumerable.Repeat(Letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (departureAirport == arrivalAirport);

            return (departureAirport, arrivalAirport);
        }

        private static (DateTime, DateTime) GenerateRandomFlightTimes(Random random)
        {
            var departureTime = DateTime.UtcNow.AddHours(random.Next(1, 24));
            var arrivalTime = departureTime.AddHours(random.Next(1, 4)); // Arrival time 1 to 3 hours after departure
            return (departureTime, arrivalTime);
        }
    }
}
