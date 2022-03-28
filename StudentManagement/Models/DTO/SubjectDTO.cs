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
        public string Semester { get; set; }
        public int SlotPerWeek { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
