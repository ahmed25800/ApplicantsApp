using Application.Commands.Applicants;
using Application.Common.Exceptions;
using Application.Dtos.Applicants;
using Application.Dtos.Common;
using Application.Interfaces;
using Application.Mapping;
using MediatR;

namespace Application.CommandHandlers.Applicants
{
    public class DeleteApplicantCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteApplicantCommand, BaseResponseDto<ApplicantDto>>
    {
        public async Task<BaseResponseDto<ApplicantDto>> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.Applicants.GetAsync(request.Id, cancellationToken);
            if (applicant == null)
            {
                throw new NotFoundException("Applicant not found.");
            }
            try
            {
                await _unitOfWork.Applicants.DeleteAsync(applicant, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new BaseResponseDto<ApplicantDto>
                {
                    Data = applicant.ToApplicantDto(),
                    Message = "Applicant deleted successfully.",
                    Success = true
                };
            }
            catch (Exception e)
            {
                if (e is NotFoundException) throw;
                throw new TransactionException("Failed to delete the applicant.");
            }
        }
    }
}
