using WebApplication.Data.Interfaces;
using WebApplication.Exceptions;
using WebApplication.Models;
using WebApplication.Services.Interfaces;
using WebApplication.Utils;

namespace WebApplication.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IShortLinkRepository _repository;

        public ShortLinkService(IShortLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShortLink> CreateShortLinkAsync(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl) || !Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            {
                throw new InvalidUrlException("Некорректный URL.");
            }

            var shortUrl = ShortUrlGenerator.GenerateShortUrl();
            var shortLink = new ShortLink
            {
                OriginalUrl = originalUrl,
                ShortUrl = shortUrl,
                CreatedAt = DateTime.UtcNow,
                ClickCount = 0
            };

            return await _repository.CreateAsync(shortLink);
        }

        public async Task<ShortLink> GetShortLinkByShortUrlAsync(string shortUrl)
        {
            var shortLink = await _repository.GetByShortUrlAsync(shortUrl);
            if (shortLink == null)
            {
                throw new ShortLinkNotFoundException("Ссылка не найдена.");
            }
            return shortLink;
        }

        public async Task<IEnumerable<ShortLink>> GetAllShortLinksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task IncrementClickCountAsync(string shortUrl)
        {
            var shortLink = await _repository.GetByShortUrlAsync(shortUrl);
            if (shortLink == null)
            {
                throw new ShortLinkNotFoundException("Ссылка не найдена.");
            }

            shortLink.ClickCount++;
            await _repository.UpdateAsync(shortLink);
        }

        public async Task DeleteShortLinkAsync(int id)
        {
            var shortLink = await _repository.GetByIdAsync(id);
            if (shortLink == null)
            {
                throw new ShortLinkNotFoundException("Ссылка не найдена.");
            }

            await _repository.DeleteAsync(id);
        }
    }
}
