using Bibliotekarz.Context;
using Bibliotekarz.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotekarz.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public BooksController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBooks()
    {
        //LINQ
        var bookList = dbContext.Books
            .Where(book => book.IsBorrowed == false)
            .OrderBy(book => book.Autor).ThenByDescending(book => book.Title)
            .ToList();
            

        return Ok(bookList);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddBook(Book book)
    {
        if (book == null || book.Id != 0)
        {
            return BadRequest("Obiekt nie może byc nullem lub posiadać ID innego niż 0.");
        }

        dbContext.Books.Add(book);
        dbContext.SaveChanges();

        return Created($"/Books/GetBook/{book.Id}", book);
    }
}
