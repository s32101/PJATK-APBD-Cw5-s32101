using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw5_s32101.Models;

public record Room(
    Guid Id,
    [Required]
    string Name,
    [Required]
    string BuildingCode,
    int Floor,
    /*
     Najmniejsza możliwa liczba typu double w C#, która jest większa od zera, to Double.Epsilon (wartość ≈ 4.94065645841247E-324).
     */
    [Range(double.Epsilon, double.MaxValue)]
    int Capacity,
    bool HasProjector,
    bool IsActive
);