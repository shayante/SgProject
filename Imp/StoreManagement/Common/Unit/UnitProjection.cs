﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class UnitProjection : EntityProjection<Unit>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Unit> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new EntityColumnInfo<Unit>("Title"));
        }

        #endregion
    }
}
