using Application.Commands.Applicants;
using Application.Common.Exceptions;
using Application.Dtos.Applicants;
using Application.Dtos.Common;
using Application.Interfaces;
using Application.Mapping;
using MediatR;

namespace Application.CommandHandlers.Applicants
{
    public class CreateApplicantCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateApplicantCommand, BaseResponseDto<ApplicantDto>>
    {
        public async Task<BaseResponseDto<ApplicantDto>> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var applicant = request.Request.ToApplicantEntity();
                await _unitOfWork.Applicants.AddAsync(applicant, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new BaseResponseDto<ApplicantDto>
                {
                    Data = applicant.ToApplicantDto(),
                    Message = "Applicant created successfully",
                    Success = true
                };
            }
            catch(Exception)
            {
                throw new TransactionException("Failed to create the applicant.");
            } 
        }
    }
}
