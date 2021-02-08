using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserAffiliationViewModel> UserAffiliations { get; private set; }
    }
}
