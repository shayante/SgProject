using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    public class PartStoreProjection : EntityProjection<PartStore>
    {
        public override IQueryable Project(IQueryable<PartStore> inputs)
        {
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            return from partStore in inputs
                   join part in parts on partStore.PartRef equals part.ID
                   select new
                   {
                       partStore.ID,
                       partStore.StoreRef,
                       partStore.PartRef,
                       PartTitle = part.Title,
                       PartCode = part.Code,
                   };
        }


        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo("StoreRef","_"));
            columns.Add(new ReferenceColumnInfo("PartRef","_"));
            columns.Add(new TextColumnInfo("PartCode", "PartStore_PartCode"));
            columns.Add(new TextColumnInfo("PartTitle", "PartStore_PartTitle"));
        }
    }
}
