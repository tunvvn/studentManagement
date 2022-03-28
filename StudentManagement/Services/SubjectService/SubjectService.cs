using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.Subject;
using StudentManagement.Services.SubjectService;


namespace StudentManagement.Services.SubjectService
{


    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<SubjectService> ilogger;
        private readonly IMapper imapper;



        public SubjectService(IUnitOfWork unitofWork, ILogger<SubjectService> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }

        public async Task<Subjects> CreateSubject(CreateSubjectDTO createSubjectDTO)
        {
            var subject = imapper.Map<Subjects>(createSubjectDTO);

            await iunitOfWork.Subjects.Insert(subject);
            await iunitOfWork.Save();
            return subject;
        }

        public async Task<bool> DeleteSubject(int Id)
        {
            var subject = await iunitOfWork.Subjects.Get(q => q.Id == (Id));
            if (subject == null)
            {
                ilogger.LogError($"Invaild PUT attempt in {nameof(DeleteSubject)}");
                throw new Exception("invaild subject");
            }
             await iunitOfWork.Subjects.Delete(Id);
            var check =  iunitOfWork.SaveChange();
            if (check == 0)
            {
                throw new Exception("invaild delete subject");
            }
            else
                return true;
           
                
        }

        public async Task<List<SubjectDTO>> GetAllSubjects([FromQuery] RequestParams requestParams)
        {
            var uni = await iunitOfWork.Subjects.GetPageList(requestParams);
            var results = imapper.Map<List<SubjectDTO>>(uni);
            return results;
        }

        public async Task<Subjects> UpdateSubject(int Id,CreateSubjectDTO createSubjectDTO)
        {
            var subject = await iunitOfWork.Subjects.Get(q => q.Id == (Id));
            if (subject == null)
            {
                ilogger.LogError($"Invaild PUT attempt in {nameof(UpdateSubject)}");
                throw new Exception("Subject not exit");
            }
            
            imapper.Map(createSubjectDTO, subject);
            subject.UpdateBy = 1;
            subject.CreateBy = 1;
            iunitOfWork.Subjects.Update(subject);
            await iunitOfWork.Save();
            return subject;
        }
    }
}
