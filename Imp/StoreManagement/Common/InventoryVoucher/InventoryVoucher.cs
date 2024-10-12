using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    [Master(typeof(IInventoryVoucherBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields("Number")]
    partial class InventoryVoucher : Entity, INumberedEntity, ITrackedEntity
    {
        #region Methods

        public override void SetDefaultValues()
        {
            base.SetDefaultValues();
            Date = DateTime.Today;
            Type = InventoryVoucherType.Enter;
        }

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

        public void FillItemsProperties()
        {
            var partBiz = ServiceFactory.Create<IPartBusiness>();
            var inventoryBiz = ServiceFactory.Create<IInventoryVoucherBusiness>();
            var unitBiz = ServiceFactory.Create<IUnitBusiness>();

            var parts = (from item in inventoryBiz.FetchDetail<InventoryVoucherItem>()
                         where item.InventoryVoucherRef == ID
                         join part in partBiz.FetchAll() on item.PartRef equals part.ID
                         join unit in unitBiz.FetchAll() on part.UnitRef equals unit.ID
                         select new {part,unit}
                        ).ToDictionary(pu => pu.part.ID);
            

            //var parts = InventoryVoucherItems.Select(i => i.Part).ToDictionary(p => p.ID);
            foreach (var item in InventoryVoucherItems)
            {
                item.PartCode = parts[item.PartRef].part.Code;
                item.PartTitle = parts[item.PartRef].part.Title;
                item.UnitTitle = parts[item.PartRef].unit.Title;

            }
        }

        #endregion
    }
}
