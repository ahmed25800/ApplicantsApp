namespace Application.Interfaces.Services;
public interface ICountryValidatorService
{
    /// <summary>
    /// Validates if the given country is valid.
    /// </summary>
    /// <param name="country">The country to validate.</param>
    /// <returns>True if the country is valid, otherwise false.</returns>
    Task<bool> IsValidAsync(string countryName, CancellationToken ct);
}