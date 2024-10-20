using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.DAL;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;
using SystemGroup.Training.StoreManagement.Common;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class InventoryVoucherBusiness : BusinessBase<InventoryVoucher>, IInventoryVoucherBusiness
    {


        protected override void OnRecordSaved(InventoryVoucher record, List<Pair<Entity, EntityActionType>> changeSet)
        {

            using(DbResourceLock.AcquireOutsideOfTransaction(nameof(StoreManagement), nameof(InventoryVoucher)))
            {
                ControlInventory(record.StoreRef);
                base.OnRecordSaved(record, changeSet);
            }
            

        }

        private void ControlInventory(long storeID)
        {
            var inventory = ServiceFactory.Create<IInventoryService>().FetchPartInventoryByStore(storeID).Where(pi => pi.Quantity < 0).FirstOrDefault();
            if (inventory != null)
            {
                var partBiz = ServiceFactory.Create<IPartBusiness>();
                var unitBiz = ServiceFactory.Create<IUnitBusiness>();
                var partID = inventory.PartRef;
                var pu = (from part in partBiz.FetchAll()
                          join unit in unitBiz.FetchAll() on part.UnitRef equals unit.ID
                          where part.ID == partID
                          select new
                          {
                              part,
                              unit
                          }).Single();

                inventory.PartTitle = pu.part.Title;
                inventory.UnitTitle = pu.unit.Title;
                throw this.CreateException("Messages_InventoryCannotBeNegative", inventory.PartTitle, (inventory.Quantity * -1).ToString("N2"), inventory.UnitTitle);
            }
            
        }
        

    }
}
