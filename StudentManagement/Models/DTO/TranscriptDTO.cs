namespace StudentManagement.Models.DTO
{
    public class TranscriptDTO : CreateTranscriptDTO
    {
        public int Id { get; set; }
    }

    public class CreateTranscriptDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string Type { get; set; }
        public double Point { get; set; }
    }
}
