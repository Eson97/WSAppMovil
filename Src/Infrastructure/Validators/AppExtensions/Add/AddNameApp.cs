using Core.DTO.Request;
using FluentValidation;

namespace Infrastructure.Validators.AppExtensions.Add
{
    internal class AddNameApp:AbstractValidator<CreateAppDTO>
    {
        public AddNameApp()
        {
            RuleFor(x => x.Nombre).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El nombre de la app no puede ser nulo")
                .NotEmpty().WithMessage("El nombre de la app no puede estar vacío");
        }
    }
}
