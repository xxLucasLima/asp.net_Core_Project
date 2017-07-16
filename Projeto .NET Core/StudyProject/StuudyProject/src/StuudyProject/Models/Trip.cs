
using System;
using System.Collections;
using System.Collections.Generic;

namespace StuudyProject.Models
{
    public class Trip
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public ICollection <Stop> Stops { get; set; }
    }
}