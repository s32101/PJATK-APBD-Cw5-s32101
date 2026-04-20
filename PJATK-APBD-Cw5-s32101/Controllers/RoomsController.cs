using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw5_s32101.Models;

namespace PJATK_APBD_Cw5_s32101.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAll(int? minCapacity = null, 
        bool? hasProjector = null, bool? activeOnly = null)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetSingle([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("building/{buildingId:guid}")]
    public IActionResult GetAllFromBuilding(Guid buildingId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("")]
    public IActionResult InsertRoom([FromBody] Room room)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult UpdateRoom([FromRoute] Guid id, [FromBody] Room room)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoom([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
}