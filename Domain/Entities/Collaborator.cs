﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class Collaborator : Entity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool Active { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no maximo 50 caracteres")]
        public string Name { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Registry Code é obrigatório")]
        [MaxLength(12, ErrorMessage = "O Registry Code deve ter no maximo 12 caracteres")]
        public string RegistryCode { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Email deve ter no maximo 50 caracteres")]
        public string Email { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Phone é obrigatório")]
        [MaxLength(12, ErrorMessage = "O Phone deve ter no maximo 12 caracteres")]
        public string Phone { get; private set; }

        [MaxLength(100, ErrorMessage = "O Pasword deve ter no maximo 100 caracteres")]
        public string Password { get; private set; }

        public byte[] Image { get; private set; }

        [Required(ErrorMessage = "O Id do Cliente é obrigatório")]
        public int? ClientId { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }


        public virtual Client Client { get; private set; }

        public Collaborator() : base() { }

        public Collaborator(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.Active = obj.Active;
            this.Name = obj.Name;
            this.RegistryCode = obj.RegistryCode;
            this.Email = obj.Email;
            this.Phone = obj.Phone;
            this.Password = obj.Password;
            this.Image = obj.Image;
            this.ClientId = obj.ClientId;
            this.CreatedAt = obj.CreatedAt;
            this.UpdatedAt = obj.UpdatedAt;
        }

        public void SetActive(bool active)
        {
            this.Active = active;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
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
