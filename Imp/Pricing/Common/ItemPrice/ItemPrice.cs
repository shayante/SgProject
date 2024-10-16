using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;

namespace SystemGroup.Training.Pricing.Common
{
    [Serializable]
    [Master(typeof(IItemPriceBusiness))]
    partial class ItemPrice : Entity
    {

        #region Properties
        public string PartTitle { get; set; }
        public string UnitTitle { get; set; }
        public decimal Quantity { get; set; }

        public decimal? EditablePrice { get; set; }
        #endregion

        #region Methods


        public void SubmitPrice()
        {
            Price = EditablePrice ?? 0;
        }
        #endregion
    }
}
