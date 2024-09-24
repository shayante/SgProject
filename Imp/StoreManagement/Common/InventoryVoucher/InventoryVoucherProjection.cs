using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class InventoryVoucherProjection : EntityProjection<InventoryVoucher>
    {
        #region Methods

        public override IQueryable Project(IQueryable<InventoryVoucher> inputs)
        {
            
            return from input in inputs

                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);


            columns.Add(new EntityColumnInfo<InventoryVoucher>("Number"));
            columns.Add(new EntityColumnInfo<InventoryVoucher>("Date"));
            //columns.Add(new TextColumnInfo("Type", "InventoryVoucher_Type"));//TODO add lookup
            //columns.Add(new DateTimeColumnInfo("State", "InventoryVoucher_State"));//TODO add lookup
            //columns.Add(new TextColumnInfo("StoreName", "InventoryVoucher_StoreRef"));//TODO add after join
            //columns.Add(new TextColumnInfo("StoreKeeper", "InventoryVoucher_StoreKeeperRef"));//TODO add after join
        }

        #endregion
    }
}
