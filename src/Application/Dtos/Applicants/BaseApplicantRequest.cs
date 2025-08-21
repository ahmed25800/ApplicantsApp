using Application.Interfaces.Services;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Dtos.Applicants;

/// <summary>
/// Base request object used when creating or updating an Applicant.
/// </summary>
public record ApplicantBaseRequest
{
    [SwaggerSchema("First name of the applicant (minimum 5 characters).", Nullable = false)]
    public required string Name { get; init; }

    [SwaggerSchema("Family/Last name of the applicant (minimum 5 characters).", Nullable = false)]
    public required string FamilyName { get; init; }

    [SwaggerSchema("Address of the applicant (minimum 10 characters).", Nullable = false)]
    public required string Address { get; init; }

    [SwaggerSchema("Country of origin. Must be a valid country (validated against REST Countries API eg Egypt , Saudi Arabia).", Nullable = false)]
    public required string CountryOfOrigin { get; init; }

    [SwaggerSchema("Email address of the applicant. Must include a valid TLD.", Nullable = false)]
    public required string EmailAdress { get; init; }

    [SwaggerSchema("Age of the applicant. Must be between 20 and 60.", Nullable = false)]
    public int Age { get; init; }

    [SwaggerSchema("Indicates if the applicant is hired (true/false).")]
    public bool? Hired { get; set; }
}



public class ApplicantBaseRequestValidator : AbstractValidator<ApplicantBaseRequest>
{
    public ApplicantBaseRequestValidator(ICountryValidatorService _countryValidatorService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MinimumLength(10);

        RuleFor(x => x.EmailAdress)
            .NotEmpty()
            .EmailAddress()
            .Must(e => e.Contains('.') &&
                       System.Text.RegularExpressions.Regex.IsMatch(e, @".+@.+\.[A-Za-z]{2,}$"))
            .WithMessage("Email must contain a valid top-level domain.");

        RuleFor(x => x.Age)
            .InclusiveBetween(20, 60);

        RuleFor(x => x.CountryOfOrigin)
            .NotEmpty()
            .MustAsync(async (name, ct) => await _countryValidatorService.IsValidAsync(name, ct))
            .WithMessage("CountryOfOrigin must be a valid country (REST Countries).");
    }
}