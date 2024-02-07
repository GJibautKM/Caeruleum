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
    ];

    public static Plant? GetById(int plantId)
        => Plants.FirstOrDefault(p => p.Id == plantId);
}
