using System;

namespace Application.Models
{
    public class CollaboratorViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int? ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}
