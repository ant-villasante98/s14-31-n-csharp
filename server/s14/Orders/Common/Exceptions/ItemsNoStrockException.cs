namespace S14.Orders.Common.Exceptions;

public class ItemsNoStrockException<T>
: Exception
{
    public T Value { get; set; }

    public ItemsNoStrockException()
    {
    }

    public ItemsNoStrockException(string message, T value)
    : base(message)
    {
        Value = value;
    }

}
