using Store.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Store.Domain.ValueObjects;

public class Phone : ValueObject
{
    public string Value { get; }

    public Phone (string number)
    {
        if (string.IsNullOrWhiteSpace(number) || !IsValid(number))
            throw new InvalidOperationException("Invalid phone number");

        Value = number;
    }

    private static bool IsValid (string number)
        => Regex.IsMatch(number, @"^\(\d{2}\)\s?\d{4,5}-\d{4}$");
}