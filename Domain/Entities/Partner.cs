using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Partner : Entity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool Active { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no maximo 50 caracteres")]
        public string Name { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Registry Code é obrigatório")]
        [MaxLength(15, ErrorMessage = "O Registry Code deve ter no maximo 15 caracteres")]
        public string RegistryCode { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Email deve ter no maximo 50 caracteres")]
        public string Email { get; private set; }

        [MaxLength(12, ErrorMessage = "O Phone deve ter no maximo 12 caracteres")]
        public string Phone { get; private set; }

        [MaxLength(255, ErrorMessage = "O About deve ter no maximo 255 caracteres")]
        public string About { get; private set; }

        public byte[] Image { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public virtual ICollection<PartnerAddress> PartnerAddresses { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; }

        public Partner() : base() { }

        public Partner(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.Active = obj.Active;
            this.Name = obj.Name;
            this.RegistryCode = obj.RegistryCode;
            this.Email = obj.Email;
            this.Phone = obj.Phone;
            this.About = obj.About;
            this.Image = obj.Image;
            this.CreatedAt = obj.CreatedAt;
            this.UpdatedAt = obj.UpdatedAt;
        }

        public void SetActive(bool active)
        {
            this.Active = active;
        }

        public void SetCreatedAt(DateTime? createdAt)
        {
            this.CreatedAt = createdAt;
        }

        public void SetUpdatedAt(DateTime? updatedAt)
        {
            this.UpdatedAt = updatedAt;
        }
    }
}
