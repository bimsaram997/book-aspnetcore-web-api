using my_books.Data.Modeks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder application)
        {
            using (var serviceScope =  application.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any()) {
                    context.Books.AddRange(new Book()
                    {
                        Title= "Harry Potter",
                        Description = "This is good book",
                        IsRead= true,
                        DateRead= DateTime.Now.AddDays(-10),
                        Rate= 4,
                        Genre ="Thriller",
                        Author = "J. K. Rowling",
                        CoverUrl= "https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2014/7/30/1406719264487/fd90e162-93de-41b1-aea5-f8e49227e85b-1360x2040.jpeg?w=1200&q=55&auto=format&usm=12&fit=max&s=6aec5983026d71051e0abf881c79ab6f",
                        DateAdded = DateTime.Now

                    },
                    new Book()
                    {
                        Title = "Sherlock homes",
                        Description = "This is serious",
                        IsRead = false,
                        Genre = "Action",
                        Author = "Authr Conan Dyle",
                        CoverUrl = "http://almabooks.com/wp-content/uploads/2016/10/9781847496164.jpg",
                        DateAdded = DateTime.Now

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
