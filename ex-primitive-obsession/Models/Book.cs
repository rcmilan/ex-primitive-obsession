using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ex_primitive_obsession.Models;

public class Book
{
    public BookId Id { get; private set; }
    public string Title { get; private set; }
    public CultureInfo Culture { get; private set; }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "EF Core requires a parameterless constructor for the entity")]
    private Book(BookId Id, string Title, CultureInfo Culture) => (this.Id, this.Title, this.Culture) = (Id, Title, Culture);

    public static Book Create(string title, string culture) => new(default, title, CultureInfo.GetCultureInfo(culture, true));

}

public record struct BookId(int Value);
