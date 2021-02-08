using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class PartnerAddress : Entity
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool Active { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O país é obrigatório")]
        [MaxLength(30, ErrorMessage = "O país deve ter no maximo 30 caracteres")]
        public string Country { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O estado é obrigatório")]
        [MaxLength(50, ErrorMessage = "O estado deve ter no maximo 50 caracteres")]
        public string State { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A cidade é obrigatória")]
        [MaxLength(50, ErrorMessage = "A cidade deve ter no maximo 50 caracteres")]
        public string City { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A rua é obrigatória")]
        [MaxLength(50, ErrorMessage = "O rua deve ter no maximo 50 caracteres")]
        public string Street { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O número é obrigatória")]
        [MaxLength(10, ErrorMessage = "O número deve ter no maximo 10 caracteres")]
        public string Number { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O CEP é obrigatória")]
        [MaxLength(9, ErrorMessage = "O CEP deve ter no maximo 9 caracteres")]
        public string ZipCode { get; private set; }

        [Required(ErrorMessage = "A latitude é obrigatória")]
        public float Latitude { get; private set; }

        [Required(ErrorMessage = "A longitude é obrigatória")]
        public float Longitude { get; private set; }

        [MaxLength(50, ErrorMessage = "O complemento deve ter no maximo 50 caracteres")]
        public string Complement { get; private set; }

        [Required(ErrorMessage = "O Id é obrigatório")]
        public int PartnerId { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public virtual Partner Partner { get; private set; }

        public PartnerAddress() : base() { }

        public PartnerAddress(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.Active = obj.Active;
            this.Country = obj.Country;
            this.State = obj.State;
            this.City = obj.City;
            this.Street = obj.Street;
            this.Number = obj.Number;
            this.ZipCode = obj.ZipCode;
            this.Latitude = obj.Latitude;
            this.Longitude = obj.Longitude;
            this.Complement = obj.Complement;
            this.PartnerId = obj.PartnerId;
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
