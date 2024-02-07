namespace Caeruleum.Model;

public record Plant(
    int Id,
    string Name,
    string ScienticName,
    string Category
)
{
    public Plant()
        : this(0, string.Empty, string.Empty, string.Empty)
    { }
}
