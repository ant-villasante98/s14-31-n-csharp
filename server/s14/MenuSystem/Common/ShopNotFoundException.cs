using S14.MenuSystem.Domain;
using S14.MenuSystem.Infraestructure;

namespace S14.MenuSystem.Common
{
    public class ShopNotFoundException
        : Exception
    {
        public ShopNotFoundException(int shopId)
        {
            ShopId = shopId;
        }

        public ShopNotFoundException(int shopId, string? message)
            : this(shopId, message, null)
        {
            ShopId = shopId;
        }

        public ShopNotFoundException(int shopId, string? message, Exception? innerException)
            : this(message, innerException)
        {
            ShopId = shopId;
        }

        public ShopNotFoundException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public ShopNotFoundException(string message) 
            : base(message)
        {
        }

        public ShopNotFoundException()
        {
        }

        public int ShopId { get; set; }
    }
}
