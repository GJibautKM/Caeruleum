using Caeruleum.Model;

namespace Caeruleum.InMemoryDb;

internal static class InMemoryPlants
{
    public static readonly IEnumerable<Plant> Plants =
    [
        new(1, "Abricotier", "Prunus armeniaca", "Rosacées"),
        new(2, "Buis commun", "Buxus sempervirens", "Buxacées"),
        new(3, "Centaurée bleuet", "Centaurea cyanus", "Astéracées"),
        new(4, "Digitale pourpre", "Digitalis purpurea", "Plantaginacées"),
        new(5, "Estragon", "Artemisia dracunculus", "Astéracées"),
        new(6, "Verveine", "Aloysia citriodora", "Verbénacées"),
        new(7, "Mélisse", "Melissa officinalis", "Lamiacées"),
        new(8, "Rosier des chiens", "Rosa canina", "Rosacées"),
        new(9, "Raifort", "Armoracia rusticana", "Brassicacées"),
    ];

    public static Plant? GetById(int plantId)
        => Plants.FirstOrDefault(p => p.Id == plantId);
}
