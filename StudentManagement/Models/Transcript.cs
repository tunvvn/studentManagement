namespace StudentManagement.Models
{
    public class Transcript
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public  int SubjectId { get; set; }
        public string Type { get; set; }
        public double Point { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subjects Subject { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }

    }
}
