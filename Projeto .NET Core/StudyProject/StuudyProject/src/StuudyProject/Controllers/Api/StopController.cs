using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StuudyProject.Models;
using StuudyProject.Services;
using StuudyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Controllers.Api
{
    [Authorize]
    [Route("/api/trips/{tripName}/stops")]
    public class StopController: Controller
    {
        private GeoCoordsService _coordsService;
        private ILogger<StopController> _logger;
        private IWorldRepository _repository;

        public StopController(IWorldRepository repository, ILogger<StopController> logger, GeoCoordsService coordsService)
        {
            _coordsService = coordsService;
            _repository = repository;
            _logger = logger;

        }
        [HttpGet("")]
        public IActionResult Get(String tripName)
        {
            try
            {
                var trip = _repository.GetUserTripByName(tripName, User.Identity.Name);

                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));

            }catch(Exception e)
            {
                _logger.LogError("Failed to get stops: {0}", e);
            }
            return BadRequest("Failed to get Stops");
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(String tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<Stop>(vm);

                    var result = await _coordsService.GetCoordsAsync(newStop.Name);
                    if (!result.Sucess)
                    {
                        _logger.LogError(result.Message);

                    }else
                    {
                        newStop.Latitude = result.Latitude;
                        newStop.Longitude = result.Longitude;

                        _repository.AddStop(tripName, newStop, User.Identity.Name);

                        if(_repository.SaveChanges())
                        {
                            return Created($"api/trips/{tripName}/stops/{newStop.Name}", Mapper.Map<StopViewModel>(newStop));

                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to save new stops: {0}", e);
            }
            return BadRequest("Failed to get Stops");
        }
    }
}
