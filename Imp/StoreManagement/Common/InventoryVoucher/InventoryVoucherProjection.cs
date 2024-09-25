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
    public class InventoryVoucherProjection : EntityProjection<InventoryVoucher>
    {
        #region Methods

        public override IQueryable Project(IQueryable<InventoryVoucher> inputs)
        {
            var sotreBiz = ServiceFactory.Create<IStoreBusiness>();
            var sotreKeeperBiz = ServiceFactory.Create<IStoreKeeperBusiness>();
            var partyBiz = ServiceFactory.Create<IPartyService>();

            return from iv in inputs
                   join store in sotreBiz.FetchAll()
                   on iv.StoreRef equals store.ID
                   join sk in sotreKeeperBiz.FetchAll() on iv.StoreRef equals sk.ID
                   join party in partyBiz.FetchAllParties() on sk.PartyRef equals party.ID
                   select new
                   {
                       iv.ID,
                       iv.Number,
                       iv.Date,
                       iv.Type,
                       iv.State,
                       iv.StoreRef,
                       iv.StoreKeeperRef,
                       StoreName = store.Name,
                       StoreKeeper = party.FullName
                   };

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);


            columns.Add(new EntityColumnInfo<InventoryVoucher>("Number"));
            columns.Add(new EntityColumnInfo<InventoryVoucher>("Date"));
            columns.Add(new EntityColumnInfo<InventoryVoucher>("Type"));
            columns.Add(new EntityColumnInfo<InventoryVoucher>("State"));
            columns.Add(new TextColumnInfo("StoreName", "InventoryVoucher_StoreRef"));
            columns.Add(new TextColumnInfo("StoreKeeper", "InventoryVoucher_StoreKeeperRef"));
        }

        #endregion
    }
}
