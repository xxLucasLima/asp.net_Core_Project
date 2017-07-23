using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using StuudyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StuudyProject.Services
{
    public class GeoCoordsService
    {
        private IConfigurationRoot _config;

        public GeoCoordsService(IConfigurationRoot config)
        {
            _config = config;
        }

        public async Task<GeoCoordsResult> GetCoordsAsync(string name)
        {
            var result = new GeoCoordsResult()
            {
                Sucess = false,
                Message = "Failed to get Coodinates"

            };

            var apiKey = _config["Keys:BingKey"];
            var encodedName = WebUtility.UrlEncode(name);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);
            var results = JObject.Parse(json);
            var resources = results["resourceSets"][0]["resources"];

            if (!results["resourceSets"][0]["resources"].HasValues)
            {
                result.Message = $"Could not find a confident match for '{name}' as a location";
            }
            else
            {
                var confidence = (string)resources[0]["confidence"];
                if(confidence != "High")
                {
                    result.Message = $"Could not find a confident match for '{name}' as a location";

                }
                else
                {
                    var coords = resources[0]["geocodePoints"][0]["coordinates"];
                    result.Latitude = (double)coords[0];
                    result.Longitude = (double)coords[1];
                    result.Sucess = true;
                    result.Message = "Sucess";

                }
            }

            return result;
        }
    }
}
