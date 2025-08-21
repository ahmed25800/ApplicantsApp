namespace Application.Dtos.Applicants;
public record ApplicantDto(int Id, string Name, string FamilyName, string Address,
string CountryOfOrigin, string EmailAdress, int Age, bool Hired , string CreatedAt , string UpdatedAt);