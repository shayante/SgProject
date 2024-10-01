using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    [ServiceInterface]
    public interface IPartBusiness : IBusinessBase<Part>
    {
        [EntityView("AllParts", "Views_AllParts", typeof(PartProjection), "Title", IsDefaultView = true)]
        new IQueryable<Part> FetchAll();

        [EntityView("AvailablePartForStore", "_",typeof(PartProjection),"Title", IsDefaultView = false)]
        IQueryable<Part> FetchPartsAvailableForStore(long[] igonreIDs);
    }
}
