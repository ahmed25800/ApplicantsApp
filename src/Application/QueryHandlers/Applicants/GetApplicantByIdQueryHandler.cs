using Application.Common.Exceptions;
using Application.Dtos.Applicants;
using Application.Interfaces;
using Application.Mapping;
using Application.Queries.Applicants;
using MediatR;

namespace Application.QueryHandlers.Applicants
{
    public class GetApplicantByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetApplicantByIdQuery, ApplicantDto>
    {
        public async Task<ApplicantDto> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.Applicants.GetAsync(request.Id, cancellationToken);
            return applicant?.ToApplicantDto() ?? throw new NotFoundException("Applicant not found.");
        }
    }
}
