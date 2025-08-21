using Application.Interfaces.Services;
using System.Net.Http.Json;

namespace Infrastructure.Services;
public  class CountryValidatorService(HttpClient _http) : ICountryValidatorService
{
    public async Task<bool> IsValidAsync(string countryName, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(countryName))
            return false;

        try
        {
            // v3.1 endpoint with fullText=true for exact matches
            var url = $"https://restcountries.com/v3.1/name/{Uri.EscapeDataString(countryName)}?fullText=true";

            using var response = await _http.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode)
                return false;

            var countries = await response.Content.ReadFromJsonAsync<object[]>(cancellationToken: ct);

            return countries != null && countries.Length > 0;
        }
        catch
        {
            return false;
        }
    }
}

