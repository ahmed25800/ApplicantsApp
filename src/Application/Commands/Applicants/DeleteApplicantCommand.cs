using Application.Dtos.Applicants;
using Application.Dtos.Common;
using MediatR;

namespace Application.Commands.Applicants;
public record DeleteApplicantCommand(int Id) : IRequest<BaseResponseDto<ApplicantDto>>;

