using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupNotesController : ControllerBase
    {
        IGroupNoteService _groupNoteService;

        public GroupNotesController(IGroupNoteService groupNoteService)
        {
            _groupNoteService = groupNoteService;
        }


        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int id)
        {
            var result = _groupNoteService.GetAllByGroupId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(GroupNote groupNote)
        {
            var result = _groupNoteService.Add(groupNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(GroupNote groupNote)
        {
            var result = _groupNoteService.Update(groupNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GroupNote groupNote)
        {
            var result = _groupNoteService.Delete(groupNote);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
