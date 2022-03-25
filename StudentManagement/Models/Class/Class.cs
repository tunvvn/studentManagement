namespace StudentManagement.Models
{
    public class Class
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Block { get; set; }
        public string FormTeacher   { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public List<Student> Students { get; set; }

    }   
}
