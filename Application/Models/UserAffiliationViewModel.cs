using System;

namespace Application.Models
{
    public class UserAffiliationViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ClientViewModel Client { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}
