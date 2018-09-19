namespace BookeNeest.Domain.Models
{
    public class BookFilter
    {
        public string Name { get; set; }
        public string Genres { get; set; }
        public string Authors { get; set; }
        public int MinRating { get; set; }
        public int MaxRating { get; set; }
    }
}
