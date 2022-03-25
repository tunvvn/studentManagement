using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Models;

namespace StudentManagement.Configrurations.Entities
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    Id = 1,
                    Name = "nguyen van A",
                    Gender = "nam",
                    Birthday = DateTime.Parse("20-03-1990"),
                    Address = "thanh hoa",
                    ClassId=1,
                    FatherName ="bo cua student",
                    MotherName =" me cua student",
                    CreateBy=1,
                    UpdateBy = 1

                },
                new Student
                {
                    Id =2,
                    Name = "nguyen van B",
                    Gender = "nu",
                    Birthday = DateTime.Parse("20-03-1990"),
                    Address = "thanh hoa",
                    ClassId = 1,
                    FatherName = "bo cua student",
                    MotherName = " me cua student",
                    CreateBy = 1,
                    UpdateBy = 1

                },
               new Student
               {
                   Id = 3,
                   Name = "nguyen van A",
                   Gender = "nam",
                   Birthday = DateTime.Parse("20-03-1990"),
                   Address = "thanh hoa",
                   ClassId = 2,
                   FatherName = "bo cua student",
                   MotherName = " me cua student",
                   CreateBy = 1,
                   UpdateBy = 1

               },
                new Student
                {
                    Id = 4,
                    Name = "nguyen van A",
                    Gender = "nu",
                    Birthday = DateTime.Parse("20-02-1990"),
                    Address = "thanh hoa",
                    ClassId = 3,
                    FatherName = "bo cua student",
                    MotherName = " me cua student",
                    CreateBy =1,
                    UpdateBy = 1

                }, new Student
                {
                    Id = 5,
                    Name = "pham thi hang",
                    Gender = "12A1",
                    Birthday = DateTime.Parse("20-01-1990"),
                    Address = "thanh hoa",
                    ClassId = 4,
                    FatherName = "bo cua student",
                    MotherName = " me cua student",
                    CreateBy = 1,
                    UpdateBy = 1

                }
                );
        }
    }
}
