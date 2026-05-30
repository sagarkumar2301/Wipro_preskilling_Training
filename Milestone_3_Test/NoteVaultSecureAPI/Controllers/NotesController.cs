using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteVaultSecureAPI.DTOs;

namespace NoteVaultSecureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public IActionResult AddNote(NoteDto dto)
        {
            return Ok(new
            {
                message = "Note added successfully",
                noteId = 1
            });
        }
        [Authorize]
[HttpGet]
public IActionResult GetNotes()
{
    return Ok();
}

[Authorize]
[HttpPut("{id}")]
public IActionResult UpdateNote(int id, NoteDto dto)
{
    return Ok();
}

[Authorize]
[HttpDelete("{id}")]
public IActionResult DeleteNote(int id)
{
    return Ok();
}
    }
}