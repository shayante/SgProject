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

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    [DetailOf(typeof(InventoryVoucher), "InventoryVoucherRef")]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class InventoryVoucherItem : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "InventoryVoucherItem_InventoryVoucherItem";
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo("InventoryVoucherRef", "_"));
            columns.Add(new ReferenceColumnInfo("PartRef", "_"));
            columns.Add(new NumericColumnInfo("Quantity", "InventoryVoucherItem_Quantity",NumericType.FloatingPoint));

        }

        #endregion
    }
}
