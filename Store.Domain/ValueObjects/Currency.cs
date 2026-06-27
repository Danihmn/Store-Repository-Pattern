using Store.Domain.Abstractions;

namespace Store.Domain.ValueObjects;

public class Currency : ValueObject
{
    public decimal Value { get; }

    public Currency (decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be greater than 0");

        Value = amount;
    }
}