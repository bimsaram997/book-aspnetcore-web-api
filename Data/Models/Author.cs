using my_books.Data.Modeks;

namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //navigation property
        public List<Book_Author> Book_Authors { get; set; }

    }

}