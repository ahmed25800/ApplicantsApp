using Application.Dtos.Applicants;
using MediatR;

namespace Application.Queries.Applicants;
public record GetApplicantByIdQuery(int Id) : IRequest<ApplicantDto>;