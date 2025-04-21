using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace ex_primitive_obsession.Database;

public class CultureInfoConverter : ValueConverter<CultureInfo, string>
{
    public CultureInfoConverter() : base(cultureInfo => cultureInfo.Name, name => CultureInfo.GetCultureInfo(name)) { }
}
