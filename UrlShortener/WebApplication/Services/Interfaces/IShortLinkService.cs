using WebApplication.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IShortLinkService
    {
        Task<ShortLink> CreateShortLinkAsync(string originalUrl);
        Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl);
        Task<IEnumerable<ShortLink>> GetAllShortLinksAsync();
        Task IncrementClickCountAsync(string shortUrl);
        Task DeleteShortLinkAsync(int id);
    }
}
