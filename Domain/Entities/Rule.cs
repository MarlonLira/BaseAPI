using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Rule : Entity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool Active { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(20, ErrorMessage = "O Nome deve ter no maximo 20 caracteres")]
        public string Name { get; private set; }

        [Required( ErrorMessage = "O level é obrigatório")]
        public int Level { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public virtual ICollection<Employee> Employees { get; private set; }

        public Rule() : base() { }

        public Rule(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.Active = obj.Active;
            this.Name = obj.Name;
            this.Level = obj.Level;
            this.CreatedAt = obj.CreatedAt;
            this.UpdatedAt = obj.UpdatedAt;

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
