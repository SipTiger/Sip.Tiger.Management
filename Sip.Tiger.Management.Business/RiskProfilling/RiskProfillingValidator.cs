using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using FluentValidation;
namespace Sip.Tiger.Management.Business.RiskProfilling
{
    public class RiskProfillingValidator : AbstractValidator<RiskProfillingCommand>
    {
        public RiskProfillingValidator()
        {
            RuleFor(c => c.RiskAppetiteScore)
                .GreaterThan(0)
                .WithMessage("RiskAppetiteScore should not be less than zero");

            RuleFor(c => c.TimeHorizonScore)
              .GreaterThan(0)
              .WithMessage("TimeHorizonScore should not be less than zero");

        }
    }
}
