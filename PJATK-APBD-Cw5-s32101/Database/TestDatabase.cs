using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101.Database;

public class TestDatabase : IDatabase
{
    public List<Reservation> Reservations { get; set; } = [];
    public List<Room> Rooms { get; set; } = [];
}