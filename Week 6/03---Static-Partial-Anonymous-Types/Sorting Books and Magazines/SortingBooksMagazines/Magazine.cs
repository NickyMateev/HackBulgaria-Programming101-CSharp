namespace SortingBooksMagazines
{
    public class Magazine
    {
        public string Title { get; set; }
        public int ISBN { get; set; }

        public Magazine(string title, int isbn)
        {
            Title = title;
            ISBN = isbn;
        }
    }
}
