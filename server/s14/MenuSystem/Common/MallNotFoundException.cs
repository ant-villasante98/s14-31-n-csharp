namespace S14.MenuSystem.Common
{
    public class MallNotFoundException(int mallId, string message = "")
        : Exception(message)
    {
        // 
    }
}
