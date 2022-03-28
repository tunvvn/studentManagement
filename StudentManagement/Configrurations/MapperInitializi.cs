﻿using AutoMapper;
using StudentManagement.Datas;
using StudentManagement.Models;
using StudentManagement.Models.Subject;

namespace StudentManagement.Configruations
{
    public class MapperInitializi: Profile
    {
        public MapperInitializi()
        {

            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Class,ClassDTO>().ReverseMap();
            CreateMap<Class, CreateClassDTO>().ReverseMap();
            CreateMap<Subjects, SubjectDTO>().ReverseMap();
            CreateMap<Subjects, CreateSubjectDTO>().ReverseMap();


        }
    }
}
