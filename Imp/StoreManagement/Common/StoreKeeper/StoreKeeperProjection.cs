using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class StoreKeeperProjection : EntityProjection<StoreKeeper>
    {
        #region Methods

        public override IQueryable Project(IQueryable<StoreKeeper> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "StoreKeeper_Field1"));
        }

        #endregion
    }
}
