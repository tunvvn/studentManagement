using FluentValidation;
using StudentManagement.Models.DTO;

namespace StudentManagement.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Block { get; set; }
        public string Semester { get; set; }
        public int SlotPerWeek { get; set; }     
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }

    public class SubjectValidator : AbstractValidator<CreateSubjectDTO>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.SlotPerWeek).InclusiveBetween(0, 36);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.Semester).NotNull().NotEmpty();

            //RuleFor(x => x.Birthday).NotNull().NotEmpty();

        }
    }
}
