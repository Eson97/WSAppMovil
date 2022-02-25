using Core.DTO.Request;
using FluentValidation;
using Infrastructure.Validators.AppVersionExtensions.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validators
{
    internal class CreateAppVersionValidator : AbstractValidator<CreateAppVersionDTO>
    {
        public CreateAppVersionValidator()
        {
            Include(new AddIdAppAppVersion());
            Include(new AddVersionAppVersion());
            Include(new AddUrlDescargaAppVersion());
        }
    }
}
