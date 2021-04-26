using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotesController : ControllerBase
    {
        IUserNoteService _userNoteService;

        public UserNotesController(IUserNoteService userNoteService)
        {
            _userNoteService = userNoteService;
        }



        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int id)
        {
            var result = _userNoteService.GetAllByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserNote userNote)
        {
            var result = _userNoteService.Add(userNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserNote userNote)
        {
            var result = _userNoteService.Update(userNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserNote userNote)
        {
            var result = _userNoteService.Delete(userNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
