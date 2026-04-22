using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw5_s32101.Database;
using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IDatabase db) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAll(int? minCapacity = null, 
        bool? hasProjector = null, bool? activeOnly = null)
    {
        var query = db.Rooms.AsQueryable();
        if (minCapacity.HasValue)
            query = query.Where(r => r.Capacity >= minCapacity.Value);
        
        if (hasProjector.HasValue)
            query = query.Where(r => r.HasProjector == hasProjector.Value);
        
        if (activeOnly.HasValue)
            query = query.Where(r => r.IsActive == activeOnly.Value);

        return Ok(query.ToList());
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetSingle([FromRoute] Guid id)
    {
        var obj = db.Rooms.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();

        return Ok(obj);
    }
    
    [HttpGet("building/{buildingCode}")]
    public IActionResult GetAllFromBuilding(string buildingCode)
    {
        return Ok(db.Rooms.Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase)));
    }
    
    [HttpPost("")]
    public IActionResult InsertRoom([FromBody] Room room)
    {
        if (db.Rooms.Any(r => r.Id == room.Id))
            return Conflict();
        
        db.Rooms.Add(room);
        return Created();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult UpdateRoom([FromRoute] Guid id, [FromBody] Room room)
    {
        if (room.Id != id)
            return BadRequest();
        
        var obj = db.Rooms.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();

        db.Rooms.Remove(obj);
        db.Rooms.Add(room);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoom([FromRoute] Guid id)
    {
        //TODO: Usunięcie sali może zwracać 409 Conflict, jeśli dla tej sali istnieją przyszłe rezerwacje,
        //albo możesz przyjąć prostszą wersję i nie pozwalać usuwać sali z powiązanymi rezerwacjami.
        
        var obj = db.Rooms.FirstOrDefault(x => x.Id == id);
        if (obj == null)
            return NotFound();
        
        db.Rooms.Remove(obj);
        return NoContent();
    }
}