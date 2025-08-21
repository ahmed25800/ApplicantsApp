using FluentValidation.Results;
namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }

    public class BussniesLogicValidationException : Exception
    {
        public BussniesLogicValidationException()
            : base()
        {
        }

        public BussniesLogicValidationException(string? message)
            : base(message)
        {
        }
    }

    public class TransactionException : Exception
    {
        public TransactionException()
            : base()
        {
        }

        public TransactionException(string message)
            : base(message)
        {
        }
    }
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }
    }

}