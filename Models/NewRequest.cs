namespace ChellengeE.Models
{
    public class NewRequest
    {
        public string? Status { get; set; }
        public int TotalResults { get; set; }
        public new List<Article> Articles { get; set; }
    }
}
