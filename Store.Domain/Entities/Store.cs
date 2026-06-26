using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Store : Entity
{
    public string LegalName { get; private set; } = null!;
    public string? TradeName { get; private set; }
    public string Cnpj { get; private set; } = null!;
    public bool Active { get; private set; }
    public Guid AddressId { get; private set; }

    public Store (string legalName, string cnpj, Guid addressId, string? tradeName = null, bool active = true)
    {
        if (string.IsNullOrWhiteSpace(legalName))
            throw new InvalidOperationException("LegalName cannot be empty");

        var cnpjDigits = cnpj?.Replace(".", "").Replace("/", "").Replace("-", "") ?? string.Empty;
        if (string.IsNullOrWhiteSpace(cnpjDigits) || cnpjDigits.Length != 14 || !cnpjDigits.All(char.IsDigit))
            throw new InvalidOperationException("Invalid CNPJ");

        if (addressId == Guid.Empty)
            throw new InvalidOperationException("AddressId cannot be empty");

        LegalName = legalName;
        TradeName = tradeName;
        Cnpj = cnpjDigits;
        Active = active;
        AddressId = addressId;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateStore (string? legalName = null, string? tradeName = null, string? cnpj = null, bool? active = null, Guid? addressId = null)
    {
        if (legalName != null && string.IsNullOrWhiteSpace(legalName))
            throw new InvalidOperationException("LegalName cannot be empty");

        if (cnpj != null)
        {
            var cnpjDigits = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            if (string.IsNullOrWhiteSpace(cnpjDigits) || cnpjDigits.Length != 14 || !cnpjDigits.All(char.IsDigit))
                throw new InvalidOperationException("Invalid CNPJ");
            Cnpj = cnpjDigits;
        }

        if (addressId != null && addressId == Guid.Empty)
            throw new InvalidOperationException("AddressId cannot be empty");

        LegalName = legalName ?? LegalName;
        TradeName = tradeName ?? TradeName;
        Active = active ?? Active;
        AddressId = addressId ?? AddressId;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
