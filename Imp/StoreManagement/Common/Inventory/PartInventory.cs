using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    public class PartInventory
    {
        public long PartRef { get; set; }

        public long StoreRef { get; set; }

        public decimal Quantity { get; set; }

        public string PartTitle { get; set; }

        public string UnitTitle { get; set; }
    }
}
