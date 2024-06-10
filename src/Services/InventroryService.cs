using enigpus.Models;

namespace enigpus.Services;

public interface IInventroryService
{
    void AddBook(Book book);
    Book SearchBook(string title);
    List<Book> GetAllBooks();
    void RemoveBook(string code);

}
