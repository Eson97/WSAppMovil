using Core.DTO.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.AppVersionExtensions.Add
{
    internal class AddVersionAppVersion : AbstractValidator<CreateAppVersionDTO>
    {
        public AddVersionAppVersion()
        {
            RuleFor(x => x.AppVersion1).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El nombre de la version no puede ser nulo")
                .NotEmpty().WithMessage("El nombre de la verison no puede estar vacío");
        }
    }
}
