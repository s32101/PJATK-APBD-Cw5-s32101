using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw5_s32101.Database;
using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IDatabase db) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAll(
        DateTime? date = null,
        string? status = null,
        Guid? roomId = null)
    {
        return Ok(db.Reservations);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetSingle([FromRoute] Guid id)
    {
        var obj = db.Reservations.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();

        return Ok(obj);
    }

    private bool IsValid(Reservation reservation)
    {
        /*
         TODO: reguły:
           Nie wolno dodać rezerwacji dla sali, która nie istnieje.
           Nie wolno dodać rezerwacji dla sali oznaczonej jako nieaktywna.
           Dwie rezerwacje tej samej sali nie mogą nakładać się czasowo tego samego dnia.
         */
        
        throw new NotImplementedException(); //TODO
    }
    
    [HttpPost("")]
    public IActionResult CreateReservation([FromBody] Reservation reservation)
    {
        if (db.Reservations.Any(r => r.Id == reservation.Id))
            return Conflict();
        
        if (!IsValid(reservation))
            return Conflict();
        
        db.Reservations.Add(reservation);
        return Created();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateReservation(
        [FromRoute] Guid id,
        [FromBody] Reservation reservation)
    {
        if (reservation.Id != id)
            return BadRequest();
        
        if (!IsValid(reservation))
            return Conflict();
        
        var obj = db.Reservations.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();

        db.Reservations.Remove(obj);
        db.Reservations.Add(reservation);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReservation([FromRoute] Guid id)
    {
        var obj = db.Reservations.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();
        
        db.Reservations.Remove(obj);
        return NoContent();
    }
}