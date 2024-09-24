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
    [Master(typeof(IUnitBusiness))]
    partial class Unit : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "Unit_Unit";
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("Title","Unit_Title"));

            //columns.Add(new TextColumnInfo("Number", "Unit_Number"));
        }

        #endregion
    }
}
