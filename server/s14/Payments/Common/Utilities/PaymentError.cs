namespace S14.Payments.Common.Utilities;

public class PaymentError
{
    /// <summary>
    /// Los codigos diponibles de errores de pagos que se pueden llevar a cabo en distintas partes del
    /// proceso de pago son los siguientes:
    ///     Para error al querer pagar una orden inexistente:
    ///     { "Code" = "022",
    ///       "Desciption" = "Error: nonexistent order"
    ///     }
    ///     Para error al agregar el pago:
    ///     { "Code" = "037",
    ///       "Desciption" = "Error: payment could not be completed, payment system down"
    ///     }
    ///     Para error al querer hacer el pago de una orden que existe pero no tiene productos en ella:
    ///     { "Code" = "064",
    ///       "Desciption" = "Error: payment not completed, order with id {order.Id} does not contain products"
    ///     }
    ///     Para error al querer hacer el pago de una orden en estado cancelada
    ///     { "Code" = "088",
    ///       "Desciption" = "Error: payment not completed, the order with id {order.Id} has been canceled"
    ///     }
    ///     Para error al querer verificar el stock de los items contenidos en la orden
    ///     { "Code" = "102",
    ///       "Desciption" = "Error: payment not completed, the stock of the products contained in the order {order.Id} could not be verified"
    ///     }
    ///     Para error al querer hacer el pago de una orden que contiene productos sin stock.
    ///     { "Code" = "123",
    ///       "Desciption" = "Error: payment not completed, the item with id {tupla.Item1} of your order is not in stock at this time"
    ///     }
    /// </summary>
    public int Id { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }
}
