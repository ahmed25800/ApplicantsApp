using Application.Dtos.Applicants;
using Application.Interfaces;
using Application.Mapping;
using Application.Queries.Applicants;
using MediatR;

namespace Application.QueryHandlers.Applicants;

public class GetApplicantsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetApplicantsQuery, List<ApplicantDto>>
{
    public  async Task<List<ApplicantDto>> Handle(GetApplicantsQuery request, CancellationToken cancellationToken)
    {
        var applicants =  await _unitOfWork.Applicants.GetAllAsync(cancellationToken);
        return applicants.Select(applicant => applicant.ToApplicantDto()).ToList();
    }
}
