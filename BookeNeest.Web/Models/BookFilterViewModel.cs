namespace BookeNeest.Web.Models
{
    //if MinRating is not nullable, it is initialized with 0;
    //hence SelectList takes that value as initial selected one and ignores selectedValue parameter of new SelectList() => useless constructor parameter;
    //Statement: asp.net SelectList is shit.  
    public class BookFilterViewModel
    {
        public string Name { get; set; }
        public string Genres { get; set; }
        public string Authors { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
    }
}