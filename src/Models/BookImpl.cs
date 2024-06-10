using enigpus.Models;

namespace enigpus;

public class BookImpl : Book
{
    public BookImpl(String code, string title, string publisher, int year) : base(code, title, publisher, year)
    {

    }
    public override string GetTitle()
    {
        return Title;
    }
}
