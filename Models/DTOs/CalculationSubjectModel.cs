namespace ExamScoreGeneratorApp.Models.DTOs
{
    public class CalculationSubjectModel
    {
        public int SubjectId { get; set; }
        public int CorrectQuestionCount { get; set; }
        public int WrongQuestionCount { get; set; }
        public int BlankQuestionCount { get; set; }
    }
}
