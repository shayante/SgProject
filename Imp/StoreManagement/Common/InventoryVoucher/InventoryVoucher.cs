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
    [Master(typeof(IInventoryVoucherBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class InventoryVoucher : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "InventoryVoucher_InventoryVoucher"; 
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            //base.GetColumns(columns);

            columns.Add(new TextColumnInfo("Number", "InventoryVoucher_Number"));
            columns.Add(new DateTimeColumnInfo("Date", "InventoryVoucher_Date"));
            columns.Add(new LookupColumnInfo("Type", "InventoryVoucher_Type", "InventoryVoucherType"));
            columns.Add(new StateColumnInfo("State", "InventoryVoucher_State",typeof(InventoryVoucher)));
            columns.Add(new ReferenceColumnInfo("StoreRef", "InventoryVoucher_StoreRef"));
            columns.Add(new ReferenceColumnInfo("StoreKeeperRef", "InventoryVoucher_StoreKeeperRef"));


        }

        #endregion
    }
}
