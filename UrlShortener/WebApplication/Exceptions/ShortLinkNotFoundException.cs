namespace WebApplication.Exceptions
{
    public class ShortLinkNotFoundException : Exception
    {
        public ShortLinkNotFoundException(string message) : base(message) { }
    }
}
