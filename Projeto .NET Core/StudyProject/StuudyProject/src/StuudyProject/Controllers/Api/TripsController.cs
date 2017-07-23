using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StuudyProject.Models;
using StuudyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Controllers.Api
{
    [Route("api/trips")]
    [Authorize]
    public class TripsController: Controller
    {
        private ILogger<TripsController> _logger;
        private IWorldRepository _repository;

        public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetTripsByUserName(this.User.Identity.Name);
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }catch(Exception e)
            {
                _logger.LogError($"Failed to get All trips: {e}");
                return BadRequest("Error in method Get");
            }

        }

        [HttpPost("")]
        public IActionResult Post([FromBody]TripViewModel theTrip)
        {
            
            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(theTrip);

                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);

                if(_repository.SaveChanges())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }

            }
            return BadRequest("Failed to Save the trip");
        }
    }
}
