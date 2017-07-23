using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Models
{
    public class WorldRepository: IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldContext> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting All Trips from DataBase");
            return _context.Trips.ToList();
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);

        }

        public bool SaveChanges()
        {

            return (_context.SaveChanges()) > 0;
        }

        public Trip GetUserTripByName(string tripName)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .Where(t => t.Name == tripName)
                .FirstOrDefault();
        }

        public void AddStop(string tripName, Stop newStop, string name)
        {
            var trip = GetUserTripByName(tripName, name);

            if(trip != null)
            {
                trip.Stops.Add(newStop);
                _context.Stops.Add(newStop);
            }
        }

        public IEnumerable<Trip> GetTripsByUserName(string name)
        {
            return _context.Trips.Include(t=> t.Stops).Where(t=> t.UserName == name).ToList();
        }

        public Trip GetUserTripByName(string tripName, string name)
        {
            return _context.Trips
                           .Include(t => t.Stops)
                           .Where(t => t.Name == tripName && t.UserName == name)
                           .FirstOrDefault();
        }
    }
}
