namespace StudentManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int ClassId { get; set; }
        public int Block { get; set; }
        public string Semester { get; set; }
        public string SlotPerWeek { get; set; }     
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
