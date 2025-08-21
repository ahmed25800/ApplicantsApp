using Application.Dtos.Applicants;
using Application.Dtos.Common;
using Application.Interfaces.Services;
using FluentValidation;
using MediatR;

namespace Application.Commands.Applicants;
public record CreateApplicantCommand(ApplicantBaseRequest Request) : IRequest<BaseResponseDto<ApplicantDto>>;

public class CreateApplicantValidator : AbstractValidator<CreateApplicantCommand>
{
    public CreateApplicantValidator(ICountryValidatorService countryValidatorService)
    {
        RuleFor(x => x.Request).SetValidator(new ApplicantBaseRequestValidator(countryValidatorService));
    }
}