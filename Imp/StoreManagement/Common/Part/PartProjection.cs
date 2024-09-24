using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class PartProjection : EntityProjection<Part>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Part> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "Part_Field1"));
        }

        #endregion
    }
}
