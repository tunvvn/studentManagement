using StudentManagement.Models;
using StudentManagement.Models.DTO;

namespace StudentManagement.Services
{
    public interface ITranscriptService
    {
        Task <List<TranscriptDTO>> GetAllTranscripts(RequestParams requestParams);
        Task <Transcript> CreateTranscript(CreateTranscriptDTO createSubjectDTO);
        Task <Transcript> UpdateTranscript(int id, CreateTranscriptDTO createTranscriptDTO);
        Task<bool> DeleteTranscript(int id);
    }
}
