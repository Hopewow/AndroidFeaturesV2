using AndroidFeaturesV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndroidFeaturesV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageUploadController : Controller
    {
        private readonly DataContext _context;

        public ImageUploadController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ImageUpload>>> Get()
        {
            return Ok(await _context.ImageUploads.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageUpload>> Get(int id)
        {
            var image = await _context.ImageUploads.FindAsync(id);
            if (image == null)
                return BadRequest("Not found.");
            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult<ImageUpload>> AddGeoLocation(ImageUpload image)
        {
            _context.ImageUploads.Add(image);
            await _context.SaveChangesAsync();
            return Ok(await _context.ImageUploads.FindAsync(image.id));
        }
    }
}
