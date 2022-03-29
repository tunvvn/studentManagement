namespace StudentManagement.Models.DTO
{
    public class ScoreSumaryBySubject
    {
        public int StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int? Semester  { get; set; }

        public int? ClassId { get; set; }

    }
}
