using S14.MenuSystem.Domain;
using System.Collections.ObjectModel;

namespace S14.MenuSystem.Common.Dtos
{
    /// <summary>
    /// Arreglo de SearchResultItem <see cref="SearchResultItem"/>
    /// </summary>
    public class SearchResponse : List<SearchResultItem> 
    {
        // d
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value">El valor que coincide con la busqueda</param>
    /// <param name="Type">El tipo de objeto</param>
    /// <param name="Route">La ruta en la api</param>
    public record SearchResultItem(string Value, string Type, string Route);
}
