using AndroidFeaturesV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndroidFeaturesV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QRCodeController : Controller
    {
        private readonly DataContext _context;

        public QRCodeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<QRCode>>> Get()
        {
            return Ok(await _context.QRCodes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QRCode>> Get(int id)
        {
            var qrCode = await _context.QRCodes.FindAsync(id);
            if (qrCode == null)
                return BadRequest("Not found.");
            return Ok(qrCode);
        }

        [HttpPost]
        public async Task<ActionResult<QRCode>> AddGeoLocation(QRCode qrCode)
        {
            _context.QRCodes.Add(qrCode);
            await _context.SaveChangesAsync();
            return Ok(await _context.QRCodes.FindAsync(qrCode.id));
        }
    }
}
