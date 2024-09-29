using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemGroup.Training.StoreManagement.Common
{
    public static class Util
    {
        public static string GetKey(string fileName, string key)
        {
            return $"Training.StoreManagement:{fileName}_{key}";
        }

        public static string GetKey(this string fullKey)
        {
            return $"Training.StoreManagement:{fullKey}";
        }
    }
}
