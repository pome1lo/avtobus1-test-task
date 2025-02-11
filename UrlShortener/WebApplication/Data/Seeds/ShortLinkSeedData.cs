using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Utils;

namespace WebApplication.Data.Seeds
{
    internal static class ShortLinkSeedData
    {
        internal static void Seed(ModelBuilder modelBuilder)
        {
            var shortLinks = new[]
            {
                new ShortLink
                {
                    Id = 1,
                    OriginalUrl = "https://blogs-images.forbes.com/ceciliarodriguez/files/2018/06/00000015_p.jpg",
                    ShortUrl = ShortUrlGenerator.GenerateShortUrl(),
                    CreatedAt = DateTime.UtcNow,
                    ClickCount = 0
                },
                new ShortLink
                {
                    Id = 2,
                    OriginalUrl = "https://s0.rbk.ru/v6_top_pics/media/img/5/13/756372136012135.jpg",
                    ShortUrl = ShortUrlGenerator.GenerateShortUrl(),
                    CreatedAt = DateTime.UtcNow,
                    ClickCount = 0
                },
                new ShortLink
                {
                    Id = 3,
                    OriginalUrl = "https://i.pinimg.com/736x/38/1e/0f/381e0f5a84c95c81f2d470d71ee9c2b4.jpg",
                    ShortUrl = ShortUrlGenerator.GenerateShortUrl(),
                    CreatedAt = DateTime.UtcNow,
                    ClickCount = 0
                }
            };

            modelBuilder.Entity<ShortLink>().HasData(shortLinks);
        }
    }
}
