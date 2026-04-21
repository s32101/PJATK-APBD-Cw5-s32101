using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw5_s32101.Models;

[StartTimeEndTimeValidation]
public record Reservation(
    Guid Id,
    Guid RoomId,
    [Required]
    string OrganizerName,
    [Required]
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