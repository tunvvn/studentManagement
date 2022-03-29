using AutoMapper;
using StudentManagement.Datas;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
using System.Linq;

namespace StudentManagement.Services.ServiceImpl
{

    public class TranscriptService : ITranscriptService
    {

        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<TranscriptService> ilogger;
        private readonly IMapper imapper;
        private readonly DataBaseContext _context;



        public TranscriptService(IUnitOfWork unitofWork, ILogger<TranscriptService> logger, IMapper mapper, DataBaseContext dbContext)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
            _context= dbContext;
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


        public async Task<double> ScoreSummaryBySubject(ScoreSumaryBySubject scoreSumaryBySubject)
        {

            // Tổng kết theo học kì của 1 học sinh
            if(scoreSumaryBySubject.ClassId==null && scoreSumaryBySubject.SubjectId==null)
            {
                IQueryable<Class> classes = from t in _context.Classes select t; // can you confirm if your context has Tables or MyTables?
                IQueryable<Student> students = from t in _context.Students select t;
                IQueryable<Transcript> transcripts = from t in _context.Transcripts select t;
                IQueryable<Subjects> subjects = from t in _context.Subjects select t;


                var listTranscript =(
                                    from x in transcripts
                                    join k in subjects on x.SubjectId equals k.Id
                                    join y in students on x.StudentId equals y.Id
                                    //join z in classes on y.ClassId equals z.Id
                                    
                                    where (scoreSumaryBySubject.StudentId == y.Id && k.Semester==scoreSumaryBySubject.Semester)
                                    select new TranscriptDTO
                                    {
                                        SubjectId = x.SubjectId,
                                        Point = x.Point,
                                        Type = x.Type
                                    }).ToList();

                if(listTranscript.Count==0)
                {
                    ilogger.LogError($"Invaild infor attempt in {nameof(ScoreSummaryBySubject)}");
                    throw new Exception("ScoreSummary no data");
                }    
                var result = CalculateScore(listTranscript);
                return result;
            }    
            else
            {
                // Tổng kết 1 môn học của học sinh
                if (scoreSumaryBySubject.ClassId == null)
                {
                    var transcripts = await iunitOfWork.Transcripts.GetAll(q => q.StudentId == scoreSumaryBySubject.StudentId && q.SubjectId == scoreSumaryBySubject.SubjectId);
                    if (transcripts.Count == 0)
                    {
                        ilogger.LogError($"Invaild infor attempt in {nameof(ScoreSummaryBySubject)}");
                        throw new Exception("ScoreSummary no data");
                    }
                    double total = 0;
                    double coefficient = 0;


                    foreach (Transcript t in transcripts)
                    {
                        if (t.Type.Equals(TypeEnum.Fast_Test))
                        {
                            total = total + t.Point;
                            coefficient++;
                        }
                        else if (t.Type.Equals(TypeEnum.Medium_Test))
                        {
                            total = total + t.Point * 2;
                            coefficient = coefficient + 2;
                        }
                        else if (t.Type.Equals(TypeEnum.Final_Test))
                        {
                            total = total + t.Point * 3;
                            coefficient = coefficient + 3;

                        }
                    }


                    return total / coefficient;
                }

                // Tổng kết theo tất cả điểm học sinh trong lớp học
                else
                {
                    IQueryable<Class> classes = from t in _context.Classes select t; 
                    IQueryable<Student> students = from t in _context.Students select t;
                    IQueryable<Transcript> transcripts = from t in _context.Transcripts select t;

                    var listTranscript =(
                                        from x in transcripts
                                        join y in students on x.StudentId equals y.Id
                                        join z in classes on y.ClassId equals z.Id
                                        where (scoreSumaryBySubject.SubjectId == x.SubjectId)
                                        select new TranscriptDTO
                                        {
                                            SubjectId = x.SubjectId,
                                            Point = x.Point,
                                            Type = x.Type
                                        }).ToList();

                    if (listTranscript.Count == 0)
                    {
                        ilogger.LogError($"Invaild infor attempt in {nameof(ScoreSummaryBySubject)}");
                        throw new Exception("ScoreSummary no data");
                    }
                    var result = CalculateScore(listTranscript);
                    return result;


                }
            }          

        }


        private double CalculateScore(List<TranscriptDTO> transcriptDTO)
        {
            double total = 0;
            double coefficient = 0;


            foreach (TranscriptDTO t in transcriptDTO)
            {
                if (t.Type.Equals(TypeEnum.Fast_Test))
                {
                    total = total + t.Point;
                    coefficient++;
                }
                else if (t.Type.Equals(TypeEnum.Medium_Test))
                {
                    total = total + t.Point * 2;
                    coefficient = coefficient + 2;
                }
                else if (t.Type.Equals(TypeEnum.Final_Test))
                {
                    total = total + t.Point * 3;
                    coefficient = coefficient + 3;

                }
            }
            return total / coefficient;

        }
    }
}
