using System.Security.Cryptography;
using AutoMapper;
using S14.MenuSystem.Services;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;
using S14.Orders.Infrastructure.Repositories;
using S14.Payments.Common.Dtos;
using S14.Payments.Common.Utilities;
using S14.Payments.Domain;
using S14.Payments.Infraestructure;

namespace S14.Payments.Services;

public class PaymentService(PaymentsSystemContext _context,
                            IMapper _mapper,
                            IOrderRepository _orderRepository,
                            IShopService _shopService)
   : IPaymentService
{
    public async Task<PaymentResponse> CreatePayment(Order? order)
    {
        var payment = new Payment()
        {
            PaymentDate = DateTime.UtcNow,
            // Consecutive = AleatoringNumber(),
            Errors = new List<PaymentError>()
        };

        try
        {
            // var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order is null)
            {
                // var error = await _context.PaymentError.FirstOrDefaultAsync(e => e.Code == "022");
                payment.Errors.Add(new PaymentError
                {
                    Code = "022",
                    Description = "Error: nonexistent order"
                });
                payment.IsValid = false;
            }
            else
            {
                if (order.Status == OrderStatus.Canceled)
                {
                    payment.Errors.Add(new PaymentError
                    {
                        Code = "088",
                        Description = $"Error: payment not completed, the order with id {order.Id} has been canceled"
                    });
                    payment.IsValid = false;
                }
                else
                {
                    if (!(order.Details.Count > 0))
                    {
                        payment.Errors.Add(new PaymentError
                        {
                            Code = "064",
                            Description = $"Error: payment not completed, order with id {order.Id} does not contain products"
                        });
                        payment.IsValid = false;
                    }
                    else
                    {
                        var verifyResponse = _shopService.VerifyStockByOrder(order.Id);
                        if (verifyResponse is null)
                        {
                            payment.Errors.Add(new PaymentError
                            {
                                Code = "102",
                                Description = $"Error: payment not completed, the stock of the products contained in the order {order.Id} could not be verified"
                            });
                            payment.IsValid = false;
                        }
                        else
                        {
                            var validations = verifyResponse.Items.ToList();
                            foreach (var detail in validations)
                            {
                                if (!detail.IsAvailable)
                                {
                                    payment.Errors.Add(new PaymentError
                                    {
                                        Code = "123",
                                        Description = $"Error: payment not completed, the item with id {detail.ItemId} of your order is not in stock at this time"
                                    });
                                    payment.IsValid = false;
                                }
                            }
                        }
                    }
                }

                payment.OrderId = order.Id;
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }
        catch
        {
            payment.Errors.Add(new PaymentError
            {
                Code = "037",
                Description = "Error: payment could not be completed, payment system down"
            });
            payment.IsValid = false;
        }

        var paymentResponse = _mapper.Map<PaymentResponse>(payment);
        return paymentResponse;
    }

    public string AleatoringNumber()
    {
        byte[] randomNumber = new byte[6];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        return Convert.ToBase64String(randomNumber);
    }
}
