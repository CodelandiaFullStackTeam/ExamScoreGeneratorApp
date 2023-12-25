using ExamScoreGeneratorApp.Models;
using ExamScoreGeneratorApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamScoreGeneratorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ExamDbContext _context = new ExamDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = _context.Subjects.ToList();
            return Ok(new ResponseResult<Subject>
            {
                Data = subjects,
                Message = "Success",
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Add(SubjectDTO subjectDto)
        {

            if (string.IsNullOrWhiteSpace(subjectDto.Name))
            {
                return BadRequest(new ResponseResult<Subject>
                {
                    Data = null,
                    Message = "Name is empty",
                    Success = false
                });
            }

            var subject = new Subject
            {
                Name = subjectDto.Name,
            };

            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return Ok(new ResponseResult<Subject>
            {
                Data = null,
                Message = "Added successfully",
                Success = true
            });
        }

        [HttpDelete]
        public IActionResult Delete(BaseDeleteDto deleteDto)
        {
            var deletedEntity = _context.Subjects.FirstOrDefault(x => x.ID == deleteDto.ID);
            if (deletedEntity is not null)
            {
                _context.Remove(deletedEntity);
                _context.SaveChanges();
            }

            return Ok(new ResponseResult<Subject>
            {
                Data = null,
                Message = "Deleted",
                Success = true
            });
        }
    }
}
