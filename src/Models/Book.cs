namespace enigpus.Models;

public abstract class Book(String code, String title, String publisher, int year)
{
    public String Code { get; } = code;
    public String Title { get; } = title;
    public int Year { get; } = year;
    public String Publisher { get; } = publisher;

    public abstract String GetTitle();

}
