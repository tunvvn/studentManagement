using StudentManagement.Models.Subject;

namespace StudentManagement.Models
{
    public class Schedule
    {
        public int Id { get; set; } 
        public int DayOfWeek { get; set; }
        public int SubjectId { get; set; }
        public int slot { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public virtual Subjects Subject { get; set; }

    }
}
