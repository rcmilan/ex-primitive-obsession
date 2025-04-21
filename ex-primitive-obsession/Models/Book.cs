using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ex_primitive_obsession.Models;

public class Book
{
    public BookId Id { get; private set; }
    public string Title { get; private set; }
    public CultureInfo Culture { get; private set; }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "EF Core requires a parameterless constructor for the entity")]
    private Book(BookId id, string title, CultureInfo culture) => (Id, Title, Culture) = (id, title, culture);
}

public record BookId(int Value);