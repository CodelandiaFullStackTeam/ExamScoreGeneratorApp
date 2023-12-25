namespace ExamScoreGeneratorApp.Models.DTOs
{
    public class CalculationBaseModel
    {
        public int GroupId { get; set; }
        public int MaxQuestionCount { get; set; }
        public List<CalculationSubjectModel> Subjects { get; set; }
    }
}
