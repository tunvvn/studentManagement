using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
namespace StudentManagement.Configrurations.Entities
{
    public class SubjectConfiguation : IEntityTypeConfiguration<Subjects>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subjects> builder)
        {
            builder.HasData(
                new Subjects
                {
                    Id = 1,
                    Name = "Toan",
                    Block = 12,
                 
                    Semester = 1,
                    SlotPerWeek = 6,
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    CreateBy = 1,
                    UpdateBy = 1

                },
                 new Subjects
                 {
                     Id = 2,
                     Name = "Ly",
                     Block = 12,

                     Semester = 1,
                     SlotPerWeek = 3,
                     UpdateDate = DateTime.Now,
                     CreateDate = DateTime.Now,
                     CreateBy = 1,
                     UpdateBy = 1

                 },
                  new Subjects
                  {
                      Id = 3,
                      Name = "hoa",
                      Block = 11,

                      Semester = 1,
                      SlotPerWeek = 3,
                      UpdateDate = DateTime.Now,
                      CreateDate = DateTime.Now,
                      CreateBy = 1,
                      UpdateBy = 1

                  } ,
                   new Subjects
                   {
                       Id = 4,
                       Name = "hoa",
                       Block = 11,

                       Semester = 2,
                       SlotPerWeek = 3,
                       UpdateDate = DateTime.Now,
                       CreateDate = DateTime.Now,
                       CreateBy = 1,
                       UpdateBy = 1

                   }


                );
            
        }
    }
}
