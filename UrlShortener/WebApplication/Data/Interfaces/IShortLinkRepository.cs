using WebApplication.Models;

namespace WebApplication.Data.Interfaces
{
    public interface IShortLinkRepository
    {
        Task<ShortLink> GetByShortUrlAsync(string shortUrl);
        Task<ShortLink> GetByIdAsync(int id);
        Task<IEnumerable<ShortLink>> GetAllAsync();
        Task<ShortLink> CreateAsync(ShortLink shortLink);
        Task<ShortLink> UpdateAsync(ShortLink shortLink);
        Task DeleteAsync(int id);
    }
}
