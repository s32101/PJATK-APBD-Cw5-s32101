namespace PJATK_APBD_Cw5_s32101.Models;

public record Room(
    Guid Id,
    string Name,
    string BuildingCode,
    int Floor,
    int Capacity,
    bool HasProjector,
    bool IsActive
);