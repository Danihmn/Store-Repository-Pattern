using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.Enums;

namespace Store.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Value { get; }
    public EDocumentType Type { get; }

    private Document (string value, EDocumentType type)
    {
        Value = value;
        Type = type;
    }

    public static Document FromPersistence (string value)
    {
        var clean = Clean(value);
        var type = clean.Length == 11 ? EDocumentType.CPF : EDocumentType.CNPJ;

        return new Document(value, type);
    }

    public static Result<Document> Create (string value)
    {
        var clean = Clean(value);

        var typeResult = clean.Length switch
        {
            11 => Result.Ok(EDocumentType.CPF),
            14 => Result.Ok(EDocumentType.CNPJ),
            _ => Result.Fail<EDocumentType>("Document must have 11 (CPF) or 14 (CNPJ) digits.")
        };

        if (typeResult.IsFailed)
            return Result.Fail<Document>(typeResult.Errors);

        var type = typeResult.Value;

        var isValid = type == EDocumentType.CPF
            ? IsValidCpf(clean)
            : IsValidCnpj(clean);

        if (!isValid)
            return Result.Fail($"{type} is invalid.");

        return Result.Ok(new Document(value, type));
    }

    private static string Clean (string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Document cannot be empty.");

        return new string(value.Where(char.IsDigit).ToArray());
    }

    private static bool IsValidCpf (string cpf)
    {
        if (cpf.Distinct().Count() == 1)
            return false;

        var numbers = cpf.Select(c => c - '0').ToArray();

        int CalculateDigit (int count)
        {
            var sum = 0;

            for (var i = 0; i < count; i++)
                sum += numbers[i] * (count + 1 - i);

            var remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }

        var digit1 = CalculateDigit(9);
        var digit2 = CalculateDigit(10);

        return numbers[9] == digit1 && numbers[10] == digit2;
    }

    private static bool IsValidCnpj (string cnpj)
    {
        if (cnpj.Distinct().Count() == 1)
            return false;

        var numbers = cnpj.Select(c => c - '0').ToArray();

        int CalculateDigit (int count)
        {
            int[] weights = count == 12
                ? [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
                : [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            var sum = 0;

            for (var i = 0; i < count; i++)
                sum += numbers[i] * weights[i];

            var remainder = sum % 11;

            return remainder < 2 ? 0 : 11 - remainder;
        }

        var digit1 = CalculateDigit(12);
        var digit2 = CalculateDigit(13);

        return numbers[12] == digit1 && numbers[13] == digit2;
    }

    public string Formatted () => Type == EDocumentType.CPF
        ? Convert.ToUInt64(Value).ToString(@"000\.000\.000\-00")
        : Convert.ToUInt64(Value).ToString(@"00\.000\.000\/0000\-00");

    public override bool Equals (object? obj)
    {
        if (obj is not Document other)
            return false;

        return Value == other.Value && Type == other.Type;
    }

    public override int GetHashCode () => HashCode.Combine(Value, Type);

    public static bool operator == (Document? left, Document? right) =>
        Equals(left, right);

    public static bool operator != (Document? left, Document? right) =>
        !Equals(left, right);

    public override string ToString () => Value;
}