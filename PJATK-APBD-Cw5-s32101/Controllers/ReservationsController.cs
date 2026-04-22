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

    [HttpPost("")]
    public IActionResult CreateReservation([FromBody] Reservation reservation)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateReservation(
        [FromRoute] Guid id,
        [FromBody] Reservation reservation)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReservation([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
}