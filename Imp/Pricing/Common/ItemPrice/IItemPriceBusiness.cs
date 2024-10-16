using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;

namespace SystemGroup.Training.Pricing.Common
{
    [ServiceInterface]
    public interface IItemPriceBusiness : IBusinessBase<ItemPrice>
    {
        IList<ItemPrice> FetchItemPricesByInventoryVoucher(long ivID);


        void SaveItems(ref List<ItemPrice> items);
    }

    
}
