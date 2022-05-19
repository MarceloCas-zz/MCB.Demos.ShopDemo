using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using FluentValidation;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Inputs.Base.Validators
{
    public abstract class InputBaseValidator<TInputBase>
        : ValidatorBase<TInputBase>,
        Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.IValidator<TInputBase>
        where TInputBase : InputBase
    {
        // Execution User
        public static readonly string ExecutionUserShouldNotNullErrorCode = nameof(ExecutionUserShouldNotNullErrorCode);
        public static readonly string ExecutionUserShouldNotNullMessage = nameof(ExecutionUserShouldNotNullMessage);
        public static readonly Severity ExecutionUserShouldNotNullSeverity = Severity.Error;

        public static readonly string ExecutionUserShouldMaximumLengthErrorCode = nameof(ExecutionUserShouldMaximumLengthErrorCode);
        public static readonly string ExecutionUserShouldMaximumLengthMessage = nameof(ExecutionUserShouldMaximumLengthMessage);
        public static readonly Severity ExecutionUserShouldMaximumLengthSeverity = Severity.Error;

        // Source Platform
        public static readonly string SourcePlatformShouldNotNullErrorCode = nameof(SourcePlatformShouldNotNullErrorCode);
        public static readonly string SourcePlatformShouldNotNullMessage = nameof(SourcePlatformShouldNotNullMessage);
        public static readonly Severity SourcePlatformShouldNotNullSeverity = Severity.Error;

        public static readonly string SourcePlatformShouldMaximumLengthErrorCode = nameof(SourcePlatformShouldMaximumLengthErrorCode);
        public static readonly string SourcePlatformShouldMaximumLengthMessage = nameof(SourcePlatformShouldMaximumLengthMessage);
        public static readonly Severity SourcePlatformShouldMaximumLengthSeverity = Severity.Error;

        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            fluentValidationValidatorWrapper.RuleFor(input => input.ExecutionUser)
                .NotNull()
                .WithErrorCode(ExecutionUserShouldNotNullErrorCode)
                .WithMessage(ExecutionUserShouldNotNullMessage)
                .WithSeverity(ExecutionUserShouldNotNullSeverity)
                .MaximumLength(150)
                .WithErrorCode(ExecutionUserShouldMaximumLengthErrorCode)
                .WithMessage(ExecutionUserShouldMaximumLengthMessage)
                .WithSeverity(ExecutionUserShouldMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.SourcePlatform)
                .NotNull()
                .WithErrorCode(SourcePlatformShouldNotNullErrorCode)
                .WithMessage(SourcePlatformShouldNotNullMessage)
                .WithSeverity(SourcePlatformShouldNotNullSeverity)
                .MaximumLength(150)
                .WithErrorCode(SourcePlatformShouldMaximumLengthErrorCode)
                .WithMessage(SourcePlatformShouldMaximumLengthMessage)
                .WithSeverity(SourcePlatformShouldMaximumLengthSeverity);

            ConfigureFluentValidationConcreteValidatorInternal(fluentValidationValidatorWrapper);
        }
        protected abstract void ConfigureFluentValidationConcreteValidatorInternal(FluentValidationValidatorWrapper fluentValidationValidatorWrapper);
    }
}
