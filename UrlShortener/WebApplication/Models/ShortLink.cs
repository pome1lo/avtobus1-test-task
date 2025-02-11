namespace WebApplication.Models
{
    public class ShortLink
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ClickCount { get; set; } = 0;
    }
}
