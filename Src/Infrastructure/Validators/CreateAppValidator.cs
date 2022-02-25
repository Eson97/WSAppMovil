using FluentValidation;
using Core.DTO.Request;
using Infrastructure.Validators.AppExtensions.Add;

namespace Infrastructure.Validators
{
    public class CreateAppValidator : AbstractValidator<CreateAppDTO>
    {
        public CreateAppValidator()
        {
            Include(new AddNameApp());
        }
    }
}
