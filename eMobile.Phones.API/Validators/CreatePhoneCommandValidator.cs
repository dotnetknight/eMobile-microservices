using eMobile.Phones.Models.Commands;
using FluentValidation;

namespace eMobile.Phones.API.Validators
{
    public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty()
                .WithMessage("Name is required!")
                .NotEqual("string")
                .WithMessage("Phone name can't equal to 'string'");

            RuleFor(l => l.CPUModel)
                .NotEmpty().WithMessage("CPU Model is required!");

            RuleFor(l => l.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required!")
                .NotEqual("string")
                .WithMessage("Manufacturer name can't equal to 'string'");

            RuleFor(l => l.Weight)
            .NotEmpty()
            .WithMessage("Weight is required!");

            RuleFor(l => l.RAM)
            .NotEmpty()
            .WithMessage("RAM is required!");

            RuleFor(l => l.Price)
            .NotEmpty()
            .WithMessage("Price is required!");

            RuleForEach(x => x.Media).ChildRules(m =>
            {
                m.RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Photo is required!");

                m.RuleFor(x => x.VideoUrl)
               .NotEmpty()
               .WithMessage("Video is required!");
            });

            RuleFor(l => l.Dimensions.Height)
            .NotEmpty()
            .WithMessage("Phone height is required!");

            RuleFor(l => l.Dimensions.Width)
            .NotEmpty()
            .WithMessage("Phone width is required!");

            RuleFor(l => l.Dimensions.Length)
            .NotEmpty()
            .WithMessage("Phone length is required!");

            RuleFor(l => l.Display.Size)
            .NotEmpty()
            .WithMessage("Size of display is required!");

            RuleFor(l => l.Display.HorizontalResolution)
            .NotEmpty()
            .WithMessage("Horizontal resolution of display is required!");

            RuleFor(l => l.Display.VerticalResolution)
            .NotEmpty()
            .WithMessage("Vertial resolution is required!");
        }
    }
}
