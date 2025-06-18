namespace Bibliotekarz.Data;

public class Book : EntityBase
{
    public string Autor { get; set; }

    public string? Title { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed { get; set; }

    public Customer? Borrower { get; set; }
}
