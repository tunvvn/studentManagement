using AutoMapper;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;

namespace StudentManagement.Services.ServiceImpl
{





    public class TranscriptService : ITranscriptService
    {

        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<TranscriptService> ilogger;
        private readonly IMapper imapper;


        public TranscriptService(IUnitOfWork unitofWork, ILogger<TranscriptService> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }

        public async Task<Transcript> CreateTranscript(CreateTranscriptDTO createTranscriptDTO)
        {
            var transcript = imapper.Map<Transcript>(createTranscriptDTO);

            await iunitOfWork.Transcripts.Insert(transcript);
            await iunitOfWork.Save();
            return transcript;
        }

        public async Task<List<TranscriptDTO>> GetAllTranscripts (RequestParams requestParams)
        {
            var uni = await iunitOfWork.Transcripts.GetPageList(requestParams);
            var results = imapper.Map<List<TranscriptDTO>>(uni);
            return results;
        }

        public async Task<Transcript> UpdateTranscript(int Id, CreateTranscriptDTO createTranscriptDTO)
        {
            var transcript = await iunitOfWork.Transcripts.Get(q => q.Id == (Id));
            if (transcript == null)
            {
                ilogger.LogError($"Invaild PUT attempt in {nameof(UpdateTranscript)}");
                throw new Exception("transcript not exit");
            }

            imapper.Map(createTranscriptDTO, transcript);
            transcript.UpdateBy = 1;
            transcript.CreateBy = 1;
            iunitOfWork.Transcripts.Update(transcript);
            await iunitOfWork.Save();
            return transcript;
        }

        public async Task<bool> DeleteTranscript(int Id)
        {
            var subject = await iunitOfWork.Transcripts.Get(q => q.Id == (Id));
            if (subject == null)
            {
                ilogger.LogError($"Invaild PUT attempt in {nameof(DeleteTranscript)}");
                throw new Exception("invaild transcript");
            }
            await iunitOfWork.Transcripts.Delete(Id);
            var check = iunitOfWork.SaveChange();
            if (check == 0)
            {
                throw new Exception("invaild delete transcript");
            }
            else
                return true;


        }
    }
}
