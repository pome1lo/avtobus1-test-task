using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortLinksController : ControllerBase
    {
        private readonly IShortLinkService _shortLinkService;

        public ShortLinksController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShortLink([FromBody] string originalUrl)
        {
            var shortLink = await _shortLinkService.CreateShortLinkAsync(originalUrl);
            return CreatedAtAction(nameof(GetShortLinkByShortUrl), new { shortUrl = shortLink.ShortUrl }, shortLink);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShortLinks()
        {
            return Ok(
                await _shortLinkService.GetAllShortLinksAsync()
            );
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetShortLinkByShortUrl(string shortUrl)
        {
            return Ok(
                await _shortLinkService.GetShortLinkByShortUrlAsync(shortUrl)
            );
        }

        [HttpGet("redirect/{shortUrl}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortUrl)
        {
            var shortLink = await _shortLinkService.GetShortLinkByShortUrlAsync(shortUrl);
            await _shortLinkService.IncrementClickCountAsync(shortUrl);
            return Redirect(shortLink.OriginalUrl);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShortLink(int id)
        {
            await _shortLinkService.DeleteShortLinkAsync(id);
            return NoContent();
        }
    }
}
