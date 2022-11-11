namespace Peadetfoods.Infrastructure.Common
{
    public struct Error
    {
        public Error(string message)
        {
            Messages = new List<string> { message };
            StatusCode = 400;
        }

        public Error(IEnumerable<string> messages)
        {
            Messages = new List<string>(messages);
            StatusCode = 400;
        }

        public List<string> Messages { get; set; }
        public int StatusCode { get; set; }
    }
}
