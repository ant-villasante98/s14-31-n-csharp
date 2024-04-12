using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S14.Payments.Common.Dtos;
using S14.Payments.Common.Utilities;
using S14.Payments.Domain;
using S14.Payments.Domain.Enums;
using S14.Payments.Infraestructure;

namespace S14.Payments.Services;

public class PaymentService(PaymentsSystemContext _context, IMapper _mapper)
    : IPaymentService
{
    public async Task<PaymentResponse> CreatePayment(int orderId)
    {
        using (var transaction = _context.Database.BeginTransactionAsync())
        {
            try
            {
                var payment = new Payment()
                {
                    PaymentDate = DateTime.UtcNow
                };
                var paymentResponse = new PaymentResponse();

                // var order = _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
                // ArgumentNullException.ThrowIfNull(order);
                // if (order.Status == OrderStatus.Canceled)
                // {
                //    payment.Errors.add(new PaymentError
                //    {
                //         Code = "088",
                //         Description = $"Error: payment not completed, the order with id {order.Id} has been canceled"
                //    });
                // }
                // else
                // {
                // List<(int, bool)> validations = menuService.ValidateOrder(order.Id);
                if (!validations.count > 0)
                {
                    foreach (var tupla in validations)
                    {
                        if (!tupla.Item2)
                        {
                            payment.Errors.Add(new PaymentError
                            {
                                Code = "123",
                                Description = $"Error: payment not completed, the item with id {tupla.Item1} of your order is not in stock at this time"
                            });
                        }
                    }
                }
                else
                {
                    // payment.Order = order;
                    payment.OrderId = order.Id;
                    var paymentCreated = _context.Payments.Add(payment).Entity;
                    if (paymentCreated is null)
                    {
                        payment.Errors.Add(new PaymentError
                        {
                            Code = "037",
                            Description = "Error: payment could not be completed, payment system down"
                        });
                    }
                    else
                    {
                        paymentCreated.IsValid = true;
                        await _context.Database.CommitTransactionAsync();
                        paymentResponse = _mapper.Map<PaymentResponse>(paymentCreated);
                    }
                }

                return paymentResponse;
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception("Error registering payment", ex);
            }
        }
    }
}
