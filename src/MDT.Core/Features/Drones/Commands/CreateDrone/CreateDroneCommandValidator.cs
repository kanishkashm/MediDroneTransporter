using FluentValidation;

namespace MDT.Core.Features.Drones.Commands.CreateDrone
{
    public class CreateDroneCommandValidator : AbstractValidator<CreateDroneCommand>
    {
        public CreateDroneCommandValidator()
        {
            RuleFor(p => p.SerialNumber)
                .NotEmpty().WithMessage("{SerialNumber} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{SerialNumber} must not exceed 100 characters.");
            RuleFor(p => p.WeightLimit)
                .LessThanOrEqualTo(500).WithMessage("{WeightLimit} must not exceed 500 gr.")
                .GreaterThanOrEqualTo(1);
            RuleFor(p => p.BatteryCapacity)
                .LessThanOrEqualTo(100).WithMessage("{BatteryCapacity} must not exceed 100%.")
                .GreaterThanOrEqualTo(0);
        }
    }
}
