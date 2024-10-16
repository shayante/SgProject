using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    [ServiceInterface]
    public interface IInventoryService
    {

        [EntityView("PartInventoryByStore", "_", typeof(PartInventoryProjection), "Title", UnderlyingType = typeof(Part))]
        IQueryable<PartInventory> FetchPartInventoryByStore(long storeRef);
    }
}
