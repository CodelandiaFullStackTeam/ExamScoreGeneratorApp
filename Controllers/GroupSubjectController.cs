using ExamScoreGeneratorApp.Models;
using ExamScoreGeneratorApp.Models.DTOs;
using ExamScoreGeneratorApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamScoreGeneratorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupSubjectController : ControllerBase
    {
        private readonly ExamDbContext _context = new ExamDbContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = from gs in _context.GroupSubject
                       join g in _context.Groups on gs.GroupId equals g.ID
                       join s in _context.Subjects on gs.SubjectId equals s.ID
                       orderby g.Name
                       select new GroupSubjectViewModel
                       {
                           GroupId = g.ID,
                           SubjectId = s.ID,
                           GroupName = g.Name,
                           SubjectName = s.Name,
                           IsMainSubject = gs.IsMainSubject,
                           IsMainSubjectString = gs.IsMainSubject ? "Əsas fənn" : "Köməkçi fənn"
                       };
            return Ok(new ResponseResult<GroupSubjectViewModel>
            {
                Data = data.ToList(),
                Message = "Success",
                Success = true
            });
            
        }

        [HttpPost]
        public IActionResult Add(GroupSubjectDTO groupSubjectDto)
        {
            var model = new GroupSubject
            {
                GroupId = groupSubjectDto.GroupId,
                SubjectId = groupSubjectDto.SubjectId,
                IsMainSubject = groupSubjectDto.IsMainSubject
            };

            _context.Add(model);
            _context.SaveChanges();
            return Ok(new ResponseResult<GroupSubject>
            {
                Data = null,
                Message = "Success",
                Success = true
            });
        }
    }
}
