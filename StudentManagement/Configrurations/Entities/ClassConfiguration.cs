using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Models;

namespace StudentManagement.Configrurations.Entities
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasData(
                new Class
                {
                    Id = 1,
                    Name = "12A1",
                    Block = 12,
                    FormTeacher = "Pham thi thu thao",
                    CreateBy = 1,
                    UpdateBy = 1
                },
                new Class
                {
                    Id = 2,
                    Name = "11A3",
                    Block = 11,
                    FormTeacher = "Pham thi thu thao"
                    ,
                    CreateBy = 1,
                    UpdateBy = 1
                },
               new Class
               {
                   Id = 3,
                   Name = "11A5",
                   Block = 11,
                   FormTeacher = "Nguyen van tu",
                   CreateBy = 1,
                   UpdateBy = 1
               },
                new Class
                {
                    Id =4,
                    Name = "10A3",
                    Block = 10,
                    FormTeacher = "le dieu linh",
                    CreateBy =1,
                    UpdateBy = 1
                }
                );
        }
    }
}
