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
            LogicalResourceTreeNode res = new LogicalResourceCategory("Training", "LogicalResources_Training".GetKey(),
                new LogicalResourceCategory("StoreManagement", "LogicalResources_StoreManagement".GetKey(),
                    new CompositeLogicalResource("Unit", "LogicalResources_Unit".GetKey(),
                                     typeof(Unit),
                                      new LogicalResource("New", "LogicalResources_New".GetKey()),
                                      new LogicalResource("Edit", "LogicalResources_Edit".GetKey()),
                                      new LogicalResource("Delete", "LogicalResources_Delete".GetKey())
                    ),
                    new CompositeLogicalResource("Part", "LogicalResources_Part".GetKey(),
                                     typeof(Part),
                                      new LogicalResource("New", "LogicalResources_New".GetKey()),
                                      new LogicalResource("Edit", "LogicalResources_Edit".GetKey()),
                                      new LogicalResource("Delete", "LogicalResources_Delete".GetKey())
                    ),
                    new CompositeLogicalResource("Store", "LogicalResources_Store".GetKey(),
                                     typeof(Store),
                                      new LogicalResource("New", "LogicalResources_New".GetKey()),
                                      new LogicalResource("Edit", "LogicalResources_Edit".GetKey()),
                                      new LogicalResource("Delete", "LogicalResources_Delete".GetKey())
                    ),
                    new CompositeLogicalResource("InventoryVoucher", "LogicalResources_InventoryVoucher".GetKey(),
                                     typeof(InventoryVoucher),
                                      new LogicalResource("New", "LogicalResources_New".GetKey()),
                                      new LogicalResource("Edit", "LogicalResources_Edit".GetKey()),
                                      new LogicalResource("Delete", "LogicalResources_Delete".GetKey())
                    )
                )
            );
            list.Add(res);
        }

        #endregion
    }
}
