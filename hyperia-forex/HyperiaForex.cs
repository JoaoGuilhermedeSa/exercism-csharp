public struct CurrencyAmount
{
    private readonly decimal amount;
    private readonly string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency ?? throw new ArgumentNullException(nameof(currency));
    }

    private static void EnsureSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (!string.Equals(a.currency, b.currency, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Currency mismatch.");
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount != b.amount;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount < b.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal multiplier)
    {
        return new CurrencyAmount(a.amount * multiplier, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor)
    {
        if (divisor == 0m)
            throw new DivideByZeroException();
        return new CurrencyAmount(a.amount / divisor, a.currency);
    }

    public static explicit operator double(CurrencyAmount a) => (double)a.amount;
    public static implicit operator decimal(CurrencyAmount a) => a.amount;

    public override readonly bool Equals(object obj) => obj is CurrencyAmount other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(amount, currency);
}