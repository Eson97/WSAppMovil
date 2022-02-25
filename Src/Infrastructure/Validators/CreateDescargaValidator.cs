using Core.DTO.Request;
using FluentValidation;
using Infrastructure.Validators.DescargaExtensions.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    public class CreateDescargaValidator : AbstractValidator<CreateDescargaDTO>
    {
        public CreateDescargaValidator()
        {
            Include(new AddIdAppVersionDescarga());
            Include(new AddIdUsuarioDescarga());
        }
    }
}
