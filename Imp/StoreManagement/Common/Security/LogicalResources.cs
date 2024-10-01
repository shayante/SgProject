using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Security;
using SystemGroup.Training.StoreManagement.Common;

namespace SystemGroup.Logistics.InventoryManagement.Common
{
    public class LogicalResources : ILogicalResourceDeclarator
    {
        #region ILogicalResourceDeclarator Members

        public void DeclareLogicalResourceTree(IList<LogicalResourceTreeNode> list)
        {
            LogicalResourceTreeNode res = new LogicalResourceCategory("Training", "LogicalResources_Training",
                new LogicalResourceCategory("StoreManagement", "LogicalResources_StoreManagement",
                    new CompositeLogicalResource("Unit", "LogicalResources_Unit",
                                     typeof(Unit),
                                      new LogicalResource("New", "LogicalResources_New"),
                                      new LogicalResource("Edit", "LogicalResources_Edit"),
                                      new LogicalResource("Delete", "LogicalResources_Delete")
                    ),
                    new CompositeLogicalResource("Part", "LogicalResources_Part",
                                     typeof(Part),
                                      new LogicalResource("New", "LogicalResources_New"),
                                      new LogicalResource("Edit", "LogicalResources_Edit"),
                                      new LogicalResource("Delete", "LogicalResources_Delete")
                    ),
                    new CompositeLogicalResource("Store", "LogicalResources_Store",
                                     typeof(Store),
                                      new LogicalResource("New", "LogicalResources_New"),
                                      new LogicalResource("Edit", "LogicalResources_Edit"),
                                      new LogicalResource("Delete", "LogicalResources_Delete")
                    ),
                    new CompositeLogicalResource("InventoryVoucher", "LogicalResources_InventoryVoucher",
                                     typeof(InventoryVoucher),
                                      new LogicalResource("New", "LogicalResources_New"),
                                      new LogicalResource("Edit", "LogicalResources_Edit"),
                                      new LogicalResource("Delete", "LogicalResources_Delete")
                    )
                )
            );
            list.Add(res);
        }

        #endregion
    }
}
