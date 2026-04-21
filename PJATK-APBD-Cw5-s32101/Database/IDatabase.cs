using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101.Database;

public interface IDatabase
{
    List<Reservation> Reservations { get; set; }
    List<Room> Rooms { get; set; }
}