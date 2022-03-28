using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class Class
    {
        public int Id { get; set; }
/*        [Index(IsUnique = true)]
*/        public string Name { get; set; }
        public int Block { get; set; }
        public string FormTeacher   { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public List<Student> Students { get; set; }

    }


    public class ClassValidator : AbstractValidator<CreateClassDTO>
    {
        public ClassValidator()
        {
            /*            (x => x.Name).Length(3, 25);
            */          //RuleFor(x => x.Birthday).InclusiveBetween(1, 100);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 100);
            RuleFor(x => x.Block).NotNull().InclusiveBetween(1,12);

        }
    }
}
