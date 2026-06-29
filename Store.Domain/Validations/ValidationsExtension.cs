using FluentResults;

namespace Store.Domain.Validations;

public static class ValidationsExtension
{
    public static void NotEmpty (this List<IError> errors, string? value, string code, string message)
    {
        if (string.IsNullOrWhiteSpace(value)) errors.Add(new Abstractions.Error(code, message));
    }

    public static void NotEmptyIfProvided (this List<IError> errors, string? value, string code, string message)
    {
        if (value != null) errors.NotEmpty(value, code, message);
    }

    public static void NotEmpty (this List<IError> errors, Guid value, string code, string message)
    {
        if (value == Guid.Empty) errors.Add(new Abstractions.Error(code, message));
    }

    public static void NotEmptyIfProvided (this List<IError> errors, Guid? value, string code, string message)
    {
        if (value != null) errors.NotEmpty(value.Value, code, message);
    }

    public static void GreaterThanZero (this List<IError> errors, decimal value, string code, string message)
    {
        if (value <= 0) errors.Add(new Abstractions.Error(code, message));
    }

    public static void GreaterThanZero (this List<IError> errors, decimal? value, string code, string message)
    {
        if (value != null) errors.GreaterThanZero(value.Value, code, message);
    }

    public static void GreaterThanZero (this List<IError> errors, int value, string code, string message)
    {
        if (value <= 0) errors.Add(new Abstractions.Error(code, message));
    }

    public static void NotNegative (this List<IError> errors, int? value, string code, string message)
    {
        if (value < 0) errors.Add(new Abstractions.Error(code, message));
    }

    public static void AddErrorsTo<T> (this Result<T> result, List<IError> errors)
    {
        if (result.IsFailed) errors.AddRange(result.Errors);
    }
}
