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
    [Master(typeof(IStoreKeeperBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields()]
    partial class StoreKeeper : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "StoreKeeper_StoreKeeper"; 
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo("PartyRef", "_"));
        }

        #endregion
    }
}
