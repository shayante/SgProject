using System;
using System.Collections.Generic;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Store), "StoreRef")]
    [AssociatedWith(typeof(Part), "PartRef", AssociationType.ManyToOne)]
    [AssociatedWith(typeof(Store), "StoreRef", AssociationType.ManyToOne)]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class PartStore : Entity
    {


        #region Properties

        public string PartCode { get; set; }
        public string PartTitle { get; set; }
        

        #endregion

        #region Methods

        public override string GetEntityName()
        {
            return "PartStore_PartStore";
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo("StoreRef", "PartStore_StoreRef"));
            columns.Add(new ReferenceColumnInfo("PartRef", "PartStore_PartRef"));
        }

       
        #endregion
    }
}
