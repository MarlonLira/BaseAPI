using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int PartnerId { get; set; }
        public int RuleId { get; set; }
        public DateTime? CreatedId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
