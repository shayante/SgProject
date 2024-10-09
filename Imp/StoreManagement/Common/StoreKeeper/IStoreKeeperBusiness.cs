using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;
using SystemGroup.General.PartyManagement.Common;

namespace SystemGroup.Training.StoreManagement.Common
{
    [ServiceInterface]
    public interface IStoreKeeperBusiness : IBusinessBase<StoreKeeper> , IExtensionBusiness<StoreKeeper,Party>
    {
        [EntityView("AllStoreKeepers","_",typeof(StoreKeeperProjection),defaultDisplayMember: "FullName")]
        new IQueryable<StoreKeeper> FetchAll();

        IQueryable<InventoryVoucher> FetchInventoryVouchersByStoreKeeper(long id);
    }
}
