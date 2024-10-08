﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Service.Attributes;
using SystemGroup.General.PartyManagement.Common;
using SystemGroup.Training.StoreManagement.Common;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class StoreKeeperBusiness : BusinessBase<StoreKeeper>, IStoreKeeperBusiness
    {
        public void DeleteExtension(StoreKeeper extensionEntity, Party referenceEntity)
        {
            
            if (FetchInventoryVouchersByStoreKeeper(extensionEntity.ID).Any())
            {
                throw this.CreateException("Messages_StoreKeeperExistsInVoucher");
            }
            Delete(extensionEntity);
        }

        public void SaveExtension(ref StoreKeeper extensionEntity, Party referenceEntity)
        {
            extensionEntity.PartyRef = referenceEntity.ID;
            Save(ref extensionEntity);
        }

        

        public virtual IQueryable<InventoryVoucher> FetchInventoryVouchersByStoreKeeper(long storeKeeperID)
        {
            return ServiceFactory.Create<IInventoryVoucherBusiness>().FetchAll()
                .Where(i=>i.StoreKeeperRef == storeKeeperID);
        }

       

    }
}
