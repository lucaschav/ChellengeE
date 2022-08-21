namespace ChellengeE.Models.Dtos
{
    public class PagedList<T>
    {
        public int TotalPages { get; set; }
        public int ActualPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
