using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class PartProjection : EntityProjection<Part>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Part> inputs)
        {
            var units = ServiceFactory.Create<IUnitBusiness>().FetchAll();
            return from part in inputs
                   join unit in units on part.UnitRef equals unit.ID
                   select new
                   {
                       part.ID,
                       part.Code,
                       part.Title,
                       part.UnitRef,
                       Unit = unit.Title
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Part>("Code"));
            columns.Add(new EntityColumnInfo<Part>("Title"));
            columns.Add(new TextColumnInfo("Unit", "Part_UnitRef"));
        }

        #endregion
    }
}
