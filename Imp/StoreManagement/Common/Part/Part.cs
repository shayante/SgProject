using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    [Master(typeof(IPartBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class Part : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "Part_Part";
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("Code", "Part_Code"));
            columns.Add(new TextColumnInfo("Title", "Part_Title"));
            columns.Add(new ReferenceColumnInfo("UnitRef", "Part_UnitRef"));
        }

        
        #endregion
    }
}
