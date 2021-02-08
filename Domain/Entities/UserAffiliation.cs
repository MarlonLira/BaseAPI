using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserAffiliation : Entity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        [MaxLength(1, ErrorMessage = "O Status deve ter no maximo 1 caracteres")]
        public string Status { get; private set; }

        [Required(ErrorMessage = "O Id do Cliente é obrigatório")]
        public int ClientId { get; private set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório")]
        public int UserId { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }


        public virtual Client Client { get; private set; }

        public virtual User User { get; private set; }

        public UserAffiliation() : base() { }

        public UserAffiliation(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.ClientId = obj.ClientId;
            this.UserId = obj.UserId;
            this.CreatedAt = obj.CreatedAt;
            this.UpdatedAt = obj.UpdatedAt;
        }

        public void SetStatus(string status)
        {
            this.Status = status;
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
