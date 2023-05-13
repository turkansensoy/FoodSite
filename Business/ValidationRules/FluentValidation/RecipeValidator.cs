using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RecipeValidator: AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(r=>r.RecipeName).NotEmpty().WithMessage("Tarif Adı Boş geçilmemezi.");
            RuleFor(r=>r.RecipeContent).NotEmpty().WithMessage("Tarif boş geçilemez.");
            RuleFor(r=>r.NumberofPerson).NotEmpty().WithMessage("Kaç kişilik olduğu boş geçilemez.");
            RuleFor(r=>r.NumberofPerson).NotEmpty().GreaterThan(1).LessThan(50).WithMessage("1-50 arasında kişi sayısı giriniz.");
            RuleFor(r => r.PreparationTime).NotEmpty().WithMessage("Hazırlanma süresi boş geçilemez.");
            RuleFor(r => r.PreparationTime).NotEmpty().GreaterThan(10).LessThan(60).WithMessage("10-60 dk arasında hazırlanma süresi giriniz.");
            RuleFor(r => r.CookingTime).NotEmpty().WithMessage("Pişirme süresi boş geçilemez.");
            RuleFor(r => r.CookingTime).NotEmpty().GreaterThan(10).LessThan(180).WithMessage("10-180 dk arasında pişirme süresi  giriniz.");
            RuleFor(r=>r.CategoryId).NotEmpty().WithMessage("Categori boş geçilemez");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Recipe>.CreateWithOptions((Recipe)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
