using FluentValidation;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public virtual Class Class { get; set; }

    }

    public class StudentValidator : AbstractValidator<CreateStudentDTO>
    {
        public StudentValidator()
        {
/*            (x => x.Name).Length(3, 25);
*/          //RuleFor(x => x.Birthday).InclusiveBetween(1, 100);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100);
            //RuleFor(x => x.Birthday).NotNull().NotEmpty();

        }
    }
}
