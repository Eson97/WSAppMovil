using Core.DTO.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.AppVersionExtensions.Add
{
    internal class AddUrlDescargaAppVersion : AbstractValidator<CreateAppVersionDTO>
    {
        public AddUrlDescargaAppVersion()
        {
            RuleFor(x => x.UrlDescarga).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("La Url de descarga no puede ser nula")
                .NotEmpty().WithMessage("La Url de descarga no puede ");
        }
    }
}
