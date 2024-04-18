using Microsoft.EntityFrameworkCore;
using S14.Payments.Common.Utilities;

namespace S14.Payments.Infraestructure.Seeds;

public static class PaymentErrorSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var paymentErrors = new[]
        {
            new PaymentError
            {
                Id = 1,
                Code = "022",
                Description = "Error: nonexistent order"
            },
            new PaymentError
            {
                Id = 2,
                Code = "037",
                Description = "Error: payment could not be completed, payment system down"
            }
        };

        builder.Entity<PaymentError>().HasData(paymentErrors);
    }
}
