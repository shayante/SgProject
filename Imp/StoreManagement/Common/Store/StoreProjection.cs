using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class StoreProjection : EntityProjection<Store>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Store> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Store>("Code"));
            columns.Add(new EntityColumnInfo<Store>("Name"));
        }

        #endregion
    }
}
