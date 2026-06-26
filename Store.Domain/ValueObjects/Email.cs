using Store.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Store.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    public Email (string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValid(address))
            throw new InvalidOperationException("Invalid email");

        Value = address;
    }

    private static bool IsValid (string address)
        => Regex.IsMatch(address, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
}