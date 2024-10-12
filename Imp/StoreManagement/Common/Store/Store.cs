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
using SystemGroup.Framework.Numbering;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;

namespace SystemGroup.Training.StoreManagement.Common
{
    [Serializable]
    [Master(typeof(IStoreBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class Store : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "Store_Store"; 
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("Code", "Store_Code"));
            columns.Add(new TextColumnInfo("Name", "Store_Name"));
        }

        public void FillPartStoreProperties()
        {
            var parts = ServiceFactory.Create<IPartBusiness>()
                .FetchByID(PartStores.Select(ps => ps.PartRef).Distinct().ToArray())
                .ToDictionary(p => p.ID);
            foreach (var ps in PartStores)
            {

                ps.PartTitle = parts[ps.PartRef].Title;
                ps.PartCode = parts[ps.PartRef].Code;
            }
                
                
        }


        #endregion
    }
}
