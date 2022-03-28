﻿using StudentManagement.Models;
using AutoMapper;
using StudentManagement.Datas;
using StudentManagement.IRepository;
using StudentManagement.Models;

namespace StudentManagement.Services.ClassService
{
    public class ClassService : IClassService
    {
        private IUnitOfWork iunitOfWork;
        private readonly ILogger<ClassService> ilogger;
        private readonly IMapper imapper;



        public ClassService(IUnitOfWork unitofWork, ILogger<ClassService> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }
        public async Task<Class> CreateClassAsync(CreateClassDTO createClassDTO)
        {
            var cla = imapper.Map<Class>(createClassDTO);

            await iunitOfWork.Classes.Insert(cla);
            await iunitOfWork.Save();
            return cla;
        }

        public async Task<Class> UpdateClassAsync(int id, CreateClassDTO createClassDTO)
        {
            var clas = await iunitOfWork.Classes.Get(q => q.Id == (id));
          
            if (createClassDTO.StudentIds.Count() > 0)

            {
                var students = await iunitOfWork.Students.GetAll(q => q.ClassId == (id));
                foreach (Student s in students)
                {
                    iunitOfWork.Students.Delete(s.Id);

                }

                foreach (int s in createClassDTO.StudentIds)
                {
                    var student = await iunitOfWork.Students.Get(q => q.Id == (id));
                    student.ClassId = student.Id;
                    iunitOfWork.Students.Update(student);
                    await iunitOfWork.Save();
                }

            }
            imapper.Map(createClassDTO, clas);
            iunitOfWork.Classes.Update(clas);
            var check = iunitOfWork.SaveChange();
            if (check == 0)
            {
                throw new Exception("Class not update!");
            }
          
            return clas;
        }
    }
}
