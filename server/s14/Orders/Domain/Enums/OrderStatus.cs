namespace S14.Orders.Domain.Enums
{
    public enum OrderStatus
    {
        Created = 0, // Orden creada
        Payed = 1, // Orden pagada
        InProgress = 2, // Orden Aceptada por el local
        Prepared = 3, // Order Preparada por el local 
        Finished = 4, // Orden entregada al cliente
        Canceled = 5 // Orden 
    }
}