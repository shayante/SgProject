using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Party;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class StoreKeeperProjection : EntityProjection<StoreKeeper>
    {
        #region Methods

        public override IQueryable Project(IQueryable<StoreKeeper> inputs)
        {
            var parties = ServiceFactory.Create<IPartyService>().FetchAllParties().Select(p => new { p.ID, p.FullName });
            return from storeKeeper in inputs
                   join party in parties on storeKeeper.PartyRef equals party.ID
                   select new
                   {
                       storeKeeper.ID,
                       storeKeeper.PartyRef,
                       party.FullName
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo("FullName", "StoreKeeper_FullName"));
        }

        #endregion
    }
}
