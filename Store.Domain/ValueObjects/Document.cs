using Caelum.Stella.CSharp.Validation;
using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.Enums;

namespace Store.Domain.ValueObjects;

public class Document : ValueObject
{
    private static readonly CPFValidator _cpfValidator = new();
    private static readonly CNPJValidator _cnpjValidator = new();

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
            ? _cpfValidator.IsValid(clean)
            : _cnpjValidator.IsValid(clean);

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

    public override bool Equals (object? obj)
    {
        if (obj is not Document other) return false;
        return Value == other.Value && Type == other.Type;
    }

    public override int GetHashCode () => HashCode.Combine(Value, Type);

    public static bool operator == (Document? left, Document? right) => Equals(left, right);
    public static bool operator != (Document? left, Document? right) => !Equals(left, right);

    public override string ToString () => Value;
}