using FluentValidation;

namespace Core.Validations;

public abstract class BaseMediatorDtoValidation<T> : AbstractValidator<T>
{
    protected abstract void Validation();
}