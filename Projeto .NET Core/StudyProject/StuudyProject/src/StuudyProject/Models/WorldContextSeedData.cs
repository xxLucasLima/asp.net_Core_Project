using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        public async Task EnsureData()
        {
            if (!_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "US Trip",
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() {  Name = "Atlanta, GA", Arrival = new DateTime(2014, 6, 4), Latitude = 33.748995, Longitude = -84.387982, Order = 0 },
                        new Stop() {  Name = "New York, NY", Arrival = new DateTime(2014, 6, 9), Latitude = 40.712784, Longitude = -74.005941, Order = 1 },
                        new Stop() {  Name = "Boston, MA", Arrival = new DateTime(2014, 7, 1), Latitude = 42.360082, Longitude = -71.058880, Order = 2 },
                        new Stop() {  Name = "Chicago, IL", Arrival = new DateTime(2014, 7, 10), Latitude = 41.878114, Longitude = -87.629798, Order = 3 },
                        new Stop() {  Name = "Seattle, WA", Arrival = new DateTime(2014, 8, 13), Latitude = 47.606209, Longitude = -122.332071, Order = 4 },
                        new Stop() {  Name = "Atlanta, GA", Arrival = new DateTime(2014, 8, 23), Latitude = 33.748995, Longitude = -84.387982, Order = 5 },
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var WorldTrip = new Trip()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "World Trip",
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Order = 45, Latitude =  28.632244, Longitude =  77.220724, Name = "New Delhi, India", Arrival = DateTime.Parse("Mar 4, 2015") },
                        new Stop() { Order = 46, Latitude =  27.700000, Longitude =  85.333333, Name = "Kathmandu, Nepal", Arrival = DateTime.Parse("Mar 10, 2015") },
                        new Stop() { Order = 47, Latitude =  28.632244, Longitude =  77.220724, Name = "New Delhi, India", Arrival = DateTime.Parse("Mar 11, 2015") },
                        new Stop() { Order = 48, Latitude =  22.1667, Longitude =  113.5500, Name = "Macau", Arrival = DateTime.Parse("Mar 21, 2015") },
                        new Stop() { Order = 49, Latitude =  22.396428, Longitude =  114.109497, Name = "Hong Kong", Arrival = DateTime.Parse("Mar 24, 2015") },
                        new Stop() { Order = 50, Latitude =  39.904030, Longitude =  116.407526, Name = "Beijing, China", Arrival = DateTime.Parse("Apr 19, 2015") },
                        new Stop() { Order = 51, Latitude =  22.396428, Longitude =  114.109497, Name = "Hong Kong", Arrival = DateTime.Parse("Apr 24, 2015") },
                        new Stop() { Order = 52, Latitude =  1.352083, Longitude =  103.819836, Name = "Singapore", Arrival = DateTime.Parse("Apr 30, 2015") },
                        new Stop() { Order = 53, Latitude =  3.139003, Longitude =  101.686855, Name = "Kuala Lumpor, Malaysia", Arrival = DateTime.Parse("May 7, 2015") },
                        new Stop() { Order = 54, Latitude =  13.727896, Longitude =  100.524123, Name = "Bangkok, Thailand", Arrival = DateTime.Parse("May 24, 2015") },
                        new Stop() { Order = 55, Latitude =  33.748995, Longitude =  -84.387982, Name = "Atlanta, Georgia", Arrival = DateTime.Parse("Jun 17, 2015") },
                    }
                };

                _context.Trips.Add(WorldTrip);
                _context.Stops.AddRange(WorldTrip.Stops);

                await _context.SaveChangesAsync();

            }
        }
    }
}
