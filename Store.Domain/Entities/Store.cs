using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Store : Entity
{
    public string LegalName { get; private set; } = null!;
    public string? TradeName { get; private set; }
    public Document Cnpj { get; private set; } = null!;
    public bool Active { get; private set; }
    public Guid AddressId { get; private set; }

    public Store (string legalName, string cnpj, Guid addressId, string? tradeName = null, bool active = true)
    {
        if (string.IsNullOrWhiteSpace(legalName))
            throw new InvalidOperationException("LegalName cannot be empty");

        if (addressId == Guid.Empty)
            throw new InvalidOperationException("AddressId cannot be empty");

        LegalName = legalName;
        TradeName = tradeName;
        Cnpj = new Document(cnpj);
        Active = active;
        AddressId = addressId;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateStore (string? legalName = null, string? tradeName = null, string? cnpj = null, bool? active = null, Guid? addressId = null)
    {
        if (legalName != null && string.IsNullOrWhiteSpace(legalName))
            throw new InvalidOperationException("LegalName cannot be empty");

        if (addressId != null && addressId == Guid.Empty)
            throw new InvalidOperationException("AddressId cannot be empty");

        LegalName = legalName ?? LegalName;
        TradeName = tradeName ?? TradeName;
        Active = active ?? Active;
        AddressId = addressId ?? AddressId;
        Cnpj = cnpj != null ? new Document(cnpj) : Cnpj;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
