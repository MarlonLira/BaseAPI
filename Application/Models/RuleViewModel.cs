using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RuleViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
