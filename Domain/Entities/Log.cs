using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Log : Entity
    {
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O level é obrigatório")]
        [MaxLength(15, ErrorMessage = "O level deve ter no maximo 15 caracteres")]
        public string Level { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A mensagem é obrigatória")]
        [MaxLength(255, ErrorMessage = "A mensagem deve ter no maximo 255 caracteres")]
        public string Message { get; private set; }

        public string Source { get; private set; }

        [MaxLength(3, ErrorMessage = "O código deve ter no maximo 3 caracteres")]
        public string Code { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public Log() : base() { }

        public Log(dynamic obj) : base()
        {
            this.Id = obj.Id;
            this.Level = obj.Level;
            this.Message = obj.Message;
            this.Source = obj.Source;
            this.Code = obj.Code;
            this.CreatedAt = obj.CreatedAt;
        }

        public void SetLevel(string level)
        {
            this.Level = level;
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public void SetSource(string source)
        {
            this.Source = source;
        }

        public void SetCode(string code)
        {
            this.Code = code;
        }

        public void SetCreatedAt(DateTime? createdAt)
        {
            this.CreatedAt = createdAt;
        }
    }
}
