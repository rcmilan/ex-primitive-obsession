using ex_primitive_obsession.Database;
using ex_primitive_obsession.IO;
using ex_primitive_obsession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ex_primitive_obsession.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetBookResponse>> Get([FromServices] AppDbContext dbContext, [FromRoute] int id)
    {
        var book = await dbContext.Books.FindAsync(new BookId(id));

        if (book is null) return NotFound();

        return Ok(new GetBookResponse(book.Id.Value, book.Title, book.Culture.Name));
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetBookResponse>>> GetAll([FromServices] AppDbContext dbContext)
    {
        var books = await dbContext.Books.ToListAsync();
        return Ok(books.Select(b => new GetBookResponse(b.Id.Value, b.Title, b.Culture.Name)));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromServices] AppDbContext dbContext, [FromBody] PostBookRequest request)
    {
        var newBook = Book.Create(request.Title, request.Culture);

        await dbContext.Books.AddAsync(newBook);

        await dbContext.SaveChangesAsync();

        return Created();
    }
}
