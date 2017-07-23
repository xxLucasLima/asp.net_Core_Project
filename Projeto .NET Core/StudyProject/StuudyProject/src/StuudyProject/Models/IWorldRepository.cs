using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuudyProject.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable <Trip>GetTripsByUserName(string name);
        Trip GetUserTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string name);

        void AddTrip(Trip trip);
        bool SaveChanges();
        void AddStop(string tripName, Stop newStop, string name);
    }
}