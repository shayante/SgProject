using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;
using System.Collections;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class PartInventoryProjection : EntityProjection<PartInventory>
    {
        #region Methods

        public override IQueryable Project(IQueryable<PartInventory> inputs)
        {
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            var units = ServiceFactory.Create<IUnitBusiness>().FetchAll();
            return from inv in inputs
                   join part in parts on inv.PartRef equals part.ID
                   join unit in units on part.UnitRef equals unit.ID
                   select new
                   {
                       part.ID,
                       part.Code,
                       part.Title,
                       Unit = unit.Title,
                       Inventory = inv.Quantity,
                   };



        }

        public override IQueryable<PartInventory> FetchInputsByID(params long[] ids)
        {
            return ServiceFactory.Create<IPartBusiness>().FetchByID(ids).Select(p => new PartInventory
            {
                PartRef = p.ID,
            });
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);


            columns.Add(new EntityColumnInfo<Part>("Code"));
            columns.Add(new EntityColumnInfo<Part>("Title"));
            columns.Add(new TextColumnInfo("Unit", "Part_UnitRef"));
            columns.Add(new NumericColumnInfo("Inventory", "Part_InventoryQuantity", NumericType.FloatingPoint, "N2"));
        }

        #endregion
    }
}
