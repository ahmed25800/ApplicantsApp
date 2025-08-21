using Application.Commands.Applicants;
using Application.Common.Exceptions;
using Application.Dtos.Applicants;
using Application.Dtos.Common;
using Application.Interfaces;
using Application.Mapping;
using MediatR;

namespace Application.CommandHandlers.Applicants
{
    public class UpdateApplicantCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateApplicantCommand, BaseResponseDto<ApplicantDto>>
    {
        public async Task<BaseResponseDto<ApplicantDto>> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _unitOfWork.Applicants.GetAsync(request.Id , cancellationToken);
            if (applicant == null)
            {
                throw new NotFoundException("Applicant not found.");
            }
            var exist = await _unitOfWork.Applicants.GetByEmail(request.Request.EmailAdress, cancellationToken);
            if (exist != null && exist.Id != applicant.Id) throw new BussniesLogicValidationException("Email address already exist.");

            try
            {
                applicant.FromApplicantRequest(request.Request);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new BaseResponseDto<ApplicantDto>
                {
                    Data = applicant.ToApplicantDto(),
                    Message = "Applicant updated successfully.",
                    Success = true
                };
            }
            catch(Exception e)
            {
                if (e is BussniesLogicValidationException || e is NotFoundException) throw;
                throw new TransactionException("Failed to update the applicant.");
            }
            
        }
    }
}
