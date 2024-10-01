
namespace SystemGroup.Training.StoreManagement.Common
{
    public static class Util
    {
       

        public static string GetTranslateKey(this string key)
        {
            return $"Training.StoreManagement:{key}";
        }
    }
}
