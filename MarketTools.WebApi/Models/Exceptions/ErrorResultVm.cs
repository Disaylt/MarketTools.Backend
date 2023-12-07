namespace MarketTools.WebApi.Models.Exceptions
{
    public class ErrorResultVm
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public int Status { get; set; }
        public Dictionary<string, IEnumerable<string>> Errors { get; set; } = new Dictionary<string, IEnumerable<string>>();
    }
}
