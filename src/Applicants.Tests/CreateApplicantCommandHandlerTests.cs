using Application.CommandHandlers.Applicants;
using Application.Commands.Applicants;
using Application.Dtos.Applicants;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Moq;

public class CreateApplicantCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IApplicantRepository> _repoMock;
    private readonly CreateApplicantCommandHandler _handler;

    public CreateApplicantCommandHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _repoMock = new Mock<IApplicantRepository>();

        _uowMock.Setup(u => u.Applicants).Returns(_repoMock.Object);
        _uowMock.Setup(u => u.SaveChangesAsync(CancellationToken.None)).ReturnsAsync(1);

        _handler = new CreateApplicantCommandHandler(_uowMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldCallRepositoryAndSaveChanges()
    {
        
        var applicantRequest = new ApplicantBaseRequest
        {
            Name = "Ahmed",
            FamilyName = "Ashraf",
            Address = "Cairo, Egypt",
            CountryOfOrigin = "Egypt",
            EmailAdress = "ahmed@test.com",
            Age = 30,
            Hired = false
        };
        var command = new CreateApplicantCommand(applicantRequest
        );


        _repoMock.Setup(r => r.AddAsync(It.IsAny<Applicant>() , CancellationToken.None)).Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, default);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Applicant>(), CancellationToken.None), Times.Once);
        _uowMock.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
         Assert.True(result != null && result.Success == true);
    }
}
