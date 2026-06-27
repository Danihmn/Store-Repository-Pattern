using FluentResults;
using Store.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Store.Domain.ValueObjects;

public class Phone : ValueObject
{
    public string Value { get; }

    private Phone (string number) => Value = number;

    public static Result<Phone> Create (string number)
    {
        if (string.IsNullOrWhiteSpace(number) || !IsValid(number))
            return Result.Fail("Invalid phone number");

        return Result.Ok(new Phone(number));
    }

    private static bool IsValid (string number)
        => Regex.IsMatch(number, @"^\(\d{2}\)\s?\d{4,5}-\d{4}$");
}