namespace WebApplication.Utils
{
    internal static class ShortUrlGenerator
    {
        internal static string GenerateShortUrl()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
