using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Interfaces;
using WebApplication.Models;

namespace WebApplication.Data.Repositories
{
    public class ShortLinkRepository : IShortLinkRepository
    {
        private readonly ApplicationDbContext _context;

        public ShortLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShortLink> GetByShortUrlAsync(string shortUrl)
        {
            return await _context.ShortLinks
                .FirstOrDefaultAsync(sl => sl.ShortUrl == shortUrl);
        }

        public async Task<ShortLink> GetByIdAsync(int id)
        {
            return await _context.ShortLinks
                .FindAsync(id);
        }

        public async Task<IEnumerable<ShortLink>> GetAllAsync()
        {
            return await _context.ShortLinks
                .ToListAsync();
        }

        public async Task<ShortLink> CreateAsync(ShortLink shortLink)
        {
            _context.ShortLinks.Add(shortLink);
            await _context.SaveChangesAsync();
            return shortLink;
        }

        public async Task<ShortLink> UpdateAsync(ShortLink shortLink)
        {
            _context.ShortLinks.Update(shortLink);
            await _context.SaveChangesAsync();
            return shortLink;
        }

        public async Task DeleteAsync(int id)
        {
            var shortLink = await _context.ShortLinks.FindAsync(id);
            if (shortLink is not null)
            {
                _context.ShortLinks.Remove(shortLink);
                await _context.SaveChangesAsync();
            }
        }
    }
}
