using my_books.Data.Modeks;

namespace my_books.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation property
        public List<Book> Books { get; set; }
    }
}
