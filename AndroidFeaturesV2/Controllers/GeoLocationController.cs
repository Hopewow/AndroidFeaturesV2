using AndroidFeaturesV2.DataLayer;
using AndroidFeaturesV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndroidFeaturesV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeoLocationController : Controller
    {
        private readonly DataContext _context;

        public GeoLocationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeoLocation>>> Get()
        {
            return Ok(await _context.GeoLocations.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeoLocation>> Get(int id)
        {
            var location = await _context.GeoLocations.FindAsync(id);
            if (location == null)
                return BadRequest("Not found.");
            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<GeoLocation>> AddGeoLocation(GeoLocation location)
        {
            _context.GeoLocations.Add(location);
            await _context.SaveChangesAsync();
            return Ok(await _context.GeoLocations.FindAsync(location.id));
        }
    }
}
