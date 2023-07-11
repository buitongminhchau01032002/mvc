using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace PhotoStore.Models {

    public class NotPartOfAttribute : ValidationAttribute {

        public string CompareFieldName { get; }
        public NotPartOfAttribute(string compareFieldName) {
            CompareFieldName = compareFieldName;
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            var currentObject = validationContext.ObjectInstance;
            string? compareString = currentObject.GetType().GetProperty(CompareFieldName).GetValue(currentObject, null) as string;
            if (compareString == null) {
                return ValidationResult.Success;
            }
            
            string? currentFieldValue = value as string;
            if (currentFieldValue == null) {
                return ValidationResult.Success;
            }

            if (compareString.Contains(currentFieldValue)) {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }

    public class NotPartOfAttributeAdapter : AttributeAdapterBase<NotPartOfAttribute> {
        public NotPartOfAttributeAdapter(NotPartOfAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }

        public override void AddValidation(ClientModelValidationContext context) {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-notpartof", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-notpartof-comparefield", Attribute.CompareFieldName);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext) {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }

    public class NotPartOfAttributeAdapterProvider : IValidationAttributeAdapterProvider {
        private readonly IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter? GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer? stringLocalizer) {
            if (attribute is NotPartOfAttribute classicMovieAttribute) {
                return new NotPartOfAttributeAdapter(classicMovieAttribute, stringLocalizer);
            }

            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
