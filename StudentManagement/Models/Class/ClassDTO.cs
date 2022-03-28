using System.ComponentModel.DataAnnotations;


namespace StudentManagement.Models
{
    public class ClassDTO : CreateClassDTO
    {
        public int Id { get; set; }
     
    }

    public class CreateClassDTO
    {
        public string Name { get; set; }
        public int Block { get; set; }
        public string FormTeacher { get; set; }

        public List<int> StudentIds { get; set; }

       
    }
}
