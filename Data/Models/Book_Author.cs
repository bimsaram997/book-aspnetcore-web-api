using my_books.Data.Modeks;

namespace my_books.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        //navigation properties
        public int BookId { get; set; }
        public Book Book{ get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
