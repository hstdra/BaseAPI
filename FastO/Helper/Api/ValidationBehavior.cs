using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Helper.Api
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidatorFactory _validationFactory;

        public ValidationBehavior(IValidatorFactory validationFactory)
        {
            _validationFactory = validationFactory;
        }

        public Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var validator = _validationFactory.GetValidator(request.GetType());
            var result = validator?.Validate(new ValidationContext<TRequest>(request));

            if (result != null && !result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return next();
        }

    }
}