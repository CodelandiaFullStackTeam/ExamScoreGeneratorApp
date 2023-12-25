using ExamScoreGeneratorApp.Models;
using ExamScoreGeneratorApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamScoreGeneratorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ExamDbContext _context = new ExamDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _context.Groups.ToList();
            return Ok(new ResponseResult<Group>
            {
                Data = groups,
                Message = "Success",
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Add(GroupDTO groupDto)
        {

            if (string.IsNullOrWhiteSpace(groupDto.Name))
            {
                return BadRequest(new ResponseResult<Group>
                {
                    Data = null,
                    Message = "Name is empty",
                    Success = false
                });
            }

            var group = new Group
            {
                Name = groupDto.Name,
            };

            _context.Groups.Add(group);
            _context.SaveChanges();

            return Ok(new ResponseResult<Group>
            {
                Data = null,
                Message = "Added successfully",
                Success = true
            });
        }

        [HttpDelete]
        public IActionResult Delete(BaseDeleteDto groupDeleteDto)
        {
            var deletedEntity = _context.Groups.FirstOrDefault(x => x.ID == groupDeleteDto.ID);
            if (deletedEntity is not null)
            {
                _context.Remove(deletedEntity);
                _context.SaveChanges();
            }

            return Ok(new ResponseResult<Group>
            {
                Data = null,
                Message = "Deleted",
                Success = true
            });
        }
    }
}
