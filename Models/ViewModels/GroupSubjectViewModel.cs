namespace ExamScoreGeneratorApp.Models.ViewModels
{
    public class GroupSubjectViewModel:IEntity
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsMainSubject { get; set; }
        public string IsMainSubjectString { get; set; }
    }
}
