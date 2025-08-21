using Application.Dtos.Applicants;
using Application.Dtos.Common;
using Application.Interfaces.Services;
using FluentValidation;
using MediatR;

namespace Application.Commands.Applicants;

public record UpdateApplicantCommand(int Id , ApplicantBaseRequest Request) : IRequest<BaseResponseDto<ApplicantDto>>;

public class UpdateApplicantValidator : AbstractValidator<UpdateApplicantCommand>
{
    public UpdateApplicantValidator(ICountryValidatorService countryValidatorService)
    {
        RuleFor(x => x.Request).SetValidator(new ApplicantBaseRequestValidator(countryValidatorService));
    }
}