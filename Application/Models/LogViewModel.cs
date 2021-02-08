using System;

namespace Application.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string message { get; set; }
        public string source { get; set; }
        public string code { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
