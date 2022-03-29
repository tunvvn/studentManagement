namespace StudentManagement.Models.DTO
{
    public class SubjectDTO : CreateSubjectDTO
    {
        public int Id;
    }

    public class CreateSubjectDTO
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Block { get; set; }
        public int Semester { get; set; }
        public int SlotPerWeek { get; set; }
      
    }
}
