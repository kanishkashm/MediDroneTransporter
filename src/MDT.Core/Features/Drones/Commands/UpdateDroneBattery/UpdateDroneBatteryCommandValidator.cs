using FluentValidation;
using MDT.Core.Features.Drones.Commands.UpdateDrone;

namespace MDT.Core.Features.Drones.Commands.UpdateDroneBattery
{
    public class UpdateDroneBatteryCommandValidator : AbstractValidator<UpdateDroneBatteryCommand>
    {
        public UpdateDroneBatteryCommandValidator()
        {
            RuleFor(p => p.BatteryLevel)
                .LessThanOrEqualTo(100).WithMessage("{BatteryLevel} must not exceed 100%.")
                .GreaterThanOrEqualTo(0);
        }
    }
}
