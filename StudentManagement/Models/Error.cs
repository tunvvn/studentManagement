using Newtonsoft.Json;

namespace StudentManagement.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public override string ToString()=> JsonConvert.SerializeObject(this);
        
    }
}
