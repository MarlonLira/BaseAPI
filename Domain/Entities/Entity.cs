using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Entity
    {
        private List<ValidationResult> _validationsErros;

        public bool IsValid()
        {
            this._validationsErros = new List<ValidationResult>();
            var context = new ValidationContext(this);
            return Validator.TryValidateObject(this, context, _validationsErros, true);
        }

        public List<ValidationResult> GetValidationResults()
        {
            return _validationsErros;
        }

        public bool ExistProperty(object obj, string property)
        {
            return obj.GetType().GetProperty(property) != null;
        }

        public object ReturnPropertyIfValid(object obj, string property)
        {
            if (this.ExistProperty(obj, property))
            {
                return obj.GetType().GetProperty(property).GetValue(obj);
            }
            else
            {
                return null;
            }
        }
    }
}
