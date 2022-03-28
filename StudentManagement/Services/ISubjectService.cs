using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Models.DTO;


namespace StudentManagement.Services.SubjectService
{



    public interface ISubjectService
    {
        Task<List<SubjectDTO>> GetAllSubjects([FromQuery] RequestParams requestParams);
        Task<Subjects> CreateSubject(CreateSubjectDTO createSubjectDTO);
        Task<Subjects> UpdateSubject(int Id, CreateSubjectDTO createSubjectDTO);
        Task<bool> DeleteSubject(int Id);
    }
}
