using Application.Dtos.Applicants;
using MediatR;

namespace Application.Queries.Applicants;
public record GetApplicantsQuery() : IRequest<List<ApplicantDto>>;