using enigpus.Models;
using enigpus.Services;

namespace enigpus.Services.Implementation;

public class InventoryServiceImpl:IInventroryService
{
    private readonly List<Book> _books;

    public InventoryServiceImpl()
    {
        _books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public void RemoveBook(string code)
    {
         var book = _books.FirstOrDefault(b => b.Code.Equals(code, System.StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                _books.Remove(book);
            } else {
                Console.WriteLine("Book Not Found");
            }
    }

    public Book SearchBook(string title)
    {
        return _books.FirstOrDefault(x => x.GetTitle().Equals(title, StringComparison.OrdinalIgnoreCase))!;
    }
}
