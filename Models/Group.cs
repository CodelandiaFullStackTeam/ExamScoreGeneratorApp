namespace ExamScoreGeneratorApp.Models
{
    public class Group:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GroupSubject> GroupSubjects { get; set; }
    }

    public class Subject:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GroupSubject> GroupSubjects { get; set; }
    }

    public class GroupSubject:IEntity
    {
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public bool IsMainSubject { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
