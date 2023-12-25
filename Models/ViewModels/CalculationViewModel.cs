namespace ExamScoreGeneratorApp.Models.ViewModels
{
    public class CalculationViewModel:IEntity
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsMainSubject { get; set; }

    }
}
