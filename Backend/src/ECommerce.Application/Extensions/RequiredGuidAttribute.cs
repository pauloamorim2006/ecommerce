using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.Extensions
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredGuidAttribute : ValidationAttribute
    {
        public RequiredGuidAttribute() => ErrorMessage = "{0} deve ser preenchido.";

        public RequiredGuidAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
            => value != null && value is Guid && !Guid.Empty.Equals(value);
    }
}
