using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }

       // public virtual ClassDTO ClassDTO { get; set; }


    }

    public class CreateStudentDTO
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public int ClassId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
