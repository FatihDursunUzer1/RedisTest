using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisTest.API.Models;

namespace RedisTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreferencesController : ControllerBase
    {
        readonly IDistributedCache _distributedCache;

        public PreferencesController(IDistributedCache distributedCache)
        {
            _distributedCache=distributedCache;
        }

        [HttpGet()]
        public async Task<IActionResult> getPreferences()
        {
            string username = "fatih";
            var preferenceBytes=await _distributedCache.GetAsync(username);
            if (preferenceBytes is not null)
            {
                var preferences = Preferences.ToPreferences(preferenceBytes);
                return Ok(preferences);
            }
            return Ok("Bulunamadı");
        }

        [HttpPost]
        public async Task<IActionResult> setPreferences([FromBody] Preferences preferences, string username)
        {
            await _distributedCache.SetAsync(username, preferences.ToByte(), options: new DistributedCacheEntryOptions{
                AbsoluteExpiration=DateTime.Now.AddMinutes(1),
                SlidingExpiration=TimeSpan.FromSeconds(10)
            });;
         return Ok();
        }
    }
}