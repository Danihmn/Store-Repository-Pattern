using FluentResults;
using Store.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Store.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email (string address) => Value = address;

    public static Result<Email> Create (string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValid(address))
            return Result.Fail("Invalid email");

        return Result.Ok(new Email(address));
    }

    private static bool IsValid (string address)
        => Regex.IsMatch(address, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
}