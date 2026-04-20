namespace PJATK_APBD_Cw5_s32101.Models;

public record Reservation(
    Guid Id,
    Guid RoomId,
    string OrganizerName,
    string Topic,
    DateTime Date,
    DateTime StartTime,
    DateTime EndTime,
    ReservationStatus Status
);

public enum ReservationStatus
{
    Planned,
    Confirmed,
    Cancelled
}