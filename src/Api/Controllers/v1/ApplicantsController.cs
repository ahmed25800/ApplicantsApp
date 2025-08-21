using Application.Commands.Applicants;
using Application.Dtos.Applicants;
using Application.Queries.Applicants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
public class ApplicantsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicantsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get an applicant by Id.
    /// </summary>
    /// <param name="id">The ID of the applicant.</param>
    /// <returns>Returns the applicant details if found, otherwise 404.</returns>
    /// <response code="200">Returns the applicant details.</response>
    /// <response code="404">If the applicant is not found.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApplicantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var applicant = await _mediator.Send(new GetApplicantByIdQuery(id));
        return Ok(applicant);
    }

    /// <summary>
    /// Get all applicants.
    /// </summary>
    /// <returns>A list of applicants.</returns>
    /// <response code="200">Returns the list of applicants.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<ApplicantDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var applicants = await _mediator.Send(new GetApplicantsQuery());
        return Ok(applicants);
    }

    /// <summary>
    /// Create a new applicant.
    /// </summary>
    /// <param name="request">The applicant details.</param>
    /// <returns>The newly created applicant.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/v1/applicants/1
    ///     {
    ///         "firstName": "Ahmed",
    ///         "lastName": "Ashraf",
    ///         "email": "ahmed@ahmed.com",
    ///         "country": "EG"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns the created applicant.</response>
    /// <response code="400">If the request is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ApplicantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ApplicantBaseRequest request)
    {
        var response = await _mediator.Send(new CreateApplicantCommand(request));
        return Ok(response);
    }

    /// <summary>
    /// Update an existing applicant.
    /// </summary>
    /// <param name="id">The ID of the applicant to update.</param>
    /// <param name="request">The updated applicant details.</param>
    /// <returns>The updated applicant.</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /api/v1/applicants/1
    ///     {
    ///         "firstName": "Ahmed",
    ///         "lastName": "Ashraf",
    ///         "email": "ahmed@ahmed.com",
    ///         "country": "EG"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns the updated applicant.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the applicant is not found.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApplicantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] ApplicantBaseRequest request)
    {
        var response = await _mediator.Send(new UpdateApplicantCommand(id, request));
        return Ok(response);
    }

    /// <summary>
    /// Delete an applicant by Id.
    /// </summary>
    /// <param name="id">The ID of the applicant to delete.</param>
    /// <returns>The deleted applicant.</returns>
    /// <response code="200">Returns the deleted applicant details.</response>
    /// <response code="404">If the applicant is not found.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApplicantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediator.Send(new DeleteApplicantCommand(id));
        return Ok(response);
    }
}
