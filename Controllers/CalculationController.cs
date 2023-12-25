using ExamScoreGeneratorApp.Models.DTOs;
using ExamScoreGeneratorApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamScoreGeneratorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ExamDbContext _context = new ExamDbContext();
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var data = from gs in _context.GroupSubject
                       join s in _context.Subjects on gs.SubjectId equals s.ID
                       where gs.GroupId == id
                       select new CalculationViewModel
                       {
                           IsMainSubject = gs.IsMainSubject,
                           SubjectName = s.Name,
                           SubjectId = s.ID
                       };
            return Ok(new ResponseResult<CalculationViewModel>
            {
                Data = data.ToList(),
                Message = "Success",
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Calculate(CalculationAddDTO tableData)
        {
            double mainSubjectPointPerQuestion = 8;
            double subjectPointPerQuestion = 4;
            double wrongMainQuestionDecreasePoint = 2;
            double wrongQuestionDecreasePoint = 1;
            double totalPoint = default;

            var model = JsonConvert.DeserializeObject<List<CalculationBaseModel>>(tableData.TableData);

            foreach (var subject in model[0].Subjects)
            {
                bool isMainSubject = _context.GroupSubject.FirstOrDefault(x => x.GroupId == model[0].GroupId && x.SubjectId == subject.SubjectId).IsMainSubject;

                double correctPoints = (subject.CorrectQuestionCount * (isMainSubject ? mainSubjectPointPerQuestion : subjectPointPerQuestion));
                double wrongPoints = (subject.WrongQuestionCount * (isMainSubject ? wrongMainQuestionDecreasePoint : wrongQuestionDecreasePoint));
                double points = correctPoints - wrongPoints;
                totalPoint += points;

            }




            return Ok(new CalculationResult
            {
                Data = Math.Round(totalPoint, 2),
                Message = "Success",
                Success = true

            });
        }
    }
}
