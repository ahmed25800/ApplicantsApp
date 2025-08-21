using Application.Dtos.Applicants;
using Application.Helpers;
using Domain.Entities;

namespace Application.Mapping
{
    public static class ApplicantsMappingExtensions
    {
        public static ApplicantDto ToApplicantDto(this Applicant applicant) {
            return new ApplicantDto(applicant.Id ,  applicant.Name , applicant.FamilyName , applicant.Address , applicant.CountryOfOrigin , applicant.EmailAdress , applicant.Age , applicant.Hired , applicant.CreatedAt.ToIsoString() , applicant.UpdatedAt.ToIsoString());
        }

        public static Applicant ToApplicantEntity(this ApplicantBaseRequest request)
        {
            return new Applicant(
                    request.Name , request.FamilyName, request.Address, request.CountryOfOrigin, request.EmailAdress, request.Age, request.Hired == true 
                );
        }

        public static void FromApplicantRequest(this Applicant applicant , ApplicantBaseRequest request)
        {
            applicant.Update(
                request.Name, request.FamilyName, request.Address, request.CountryOfOrigin, request.EmailAdress, request.Age, request.Hired == true
            );
        }

    }
}
