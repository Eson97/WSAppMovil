using Core.DTO.Request;
using FluentValidation;
using Infrastructure.Extensions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators.DescargaExtensions.Add
{
    public class AddIdAppVersionDescarga : AbstractValidator<CreateDescargaDTO>
    {
        public AddIdAppVersionDescarga()
        {
            RuleFor(x => x.IdAppVersion).Cascade(CascadeMode.Stop)
                .Must(x => x > 0).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.")
                .Must(x => RegexExtensions.VerifyValue(x, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}
