using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.InventoryVoucherPages;
using SystemGroup.Training.StoreManagement.Web.PartPages;
using SystemGroup.Training.StoreManagement.Web.StorePages;
using SystemGroup.Training.StoreManagement.Web.UnitPages;
using SystemGroup.Web;
using SystemGroup.Web.ApplicationServices;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Shell;
using Part = SystemGroup.Training.StoreManagement.Common.Part;

namespace SystemGroup.Training.StoreManagement.Web
{
    public class WebComponentInitializer : WebComponentInitializerBase
    {

        #region Statics
        private static IUnitBusiness UnitBiz => ServiceFactory.Create<IUnitBusiness>();
        private static IPartBusiness PartBiz => ServiceFactory.Create<IPartBusiness>();
        private static IStoreBusiness StoreBiz => ServiceFactory.Create<IStoreBusiness>();
        private static IInventoryVoucherBusiness InventoryVoucherBiz => ServiceFactory.Create<IInventoryVoucherBusiness>();
        #endregion

        #region EntityActions

        #region Unit


        [AddNewEntityAction(typeof(Unit))]
        public void NewUnit()
        {
            SgShell.Show<EditUnit>();
        }

        [ViewDetailEntityAction(typeof(Unit))]
        public void EditUnit(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<EditUnit>($"id={id}");
            }
        }


        [DeleteEntityAction(typeof(Unit))]
        public void DeleteUnit(long[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                UnitBiz.Delete(ids);
            }
        }


        #endregion

        #region Part


        [AddNewEntityAction(typeof(Part))]
        public void NewPart()
        {
            SgShell.Show<EditPart>();
        }

        [ViewDetailEntityAction(typeof(Part))]
        public void EditPart(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<EditPart>($"id={id}");
            }
        }


        [DeleteEntityAction(typeof(Part))]
        public void DeletePart(long[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                PartBiz.Delete(ids);
            }
        }

        #endregion

        #region Store


        [AddNewEntityAction(typeof(Store))]
        public void NewStore()
        {
            SgShell.Show<EditStore>();
        }

        [ViewDetailEntityAction(typeof(Store))]
        public void EditStore(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<EditStore>($"id={id}");
            }
        }


        [DeleteEntityAction(typeof(Store))]
        public void DeleteStore(long[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                StoreBiz.Delete(ids);
            }
        }

        #endregion


        #region InventoryVoucher


        [AddNewEntityAction(typeof(InventoryVoucher))]
        public void NewInventoryVoucher()
        {
            SgShell.Show<EditInventoryVoucher>();
        }

        [ViewDetailEntityAction(typeof(InventoryVoucher))]
        public void EditInventoryVoucher(long[] ids)
        {
            foreach (var id in ids)
            {
                SgShell.Show<EditInventoryVoucher>($"id={id}");
            }
        }


        [DeleteEntityAction(typeof(InventoryVoucher))]
        public void DeleteInventoryVoucher(long[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                InventoryVoucherBiz.Delete(ids);
            }
        }

        #endregion

        #endregion

        #region Methods

        public override List<ComponentLink> RegisterLinks()
        {
            return new List<ComponentLink>
            {
                new ComponentLink("Training", "Labels_Training", null, null, 0, new ComponentLink[] {
                    new ComponentLink("Lists", "s:Labels_Lists", null, null, 1, new ComponentLink[] {

                        new ComponentLink("InventoryVoucherList","InventoryVoucher_InventoryVoucher",null,"~/List.aspx?ComponentName=SystemGroup.Training.StoreManagement&EntityName=InventoryVoucher",1),
                        new ComponentLink("StoreList","Store_Store",null,"~/List.aspx?ComponentName=SystemGroup.Training.StoreManagement&EntityName=Store",2),
                        new ComponentLink("PartList","Part_Part",null,"~/List.aspx?ComponentName=SystemGroup.Training.StoreManagement&EntityName=Part",3),
                        new ComponentLink("UnitList","Unit_Unit",null,"~/List.aspx?ComponentName=SystemGroup.Training.StoreManagement&EntityName=Unit",4),
                    
                    }),
                    new ComponentLink("AddInventoryVoucher", "Links_AddInventoryVoucher", null, typeof(EditInventoryVoucher), 1),
                    new ComponentLink("AddStore", "Links_AddStore", null, typeof(EditStore), 2),
                    new ComponentLink("AddPart", "Links_AddPart", null, typeof(EditPart), 3),
                    new ComponentLink("AddUnit", "Links_AddUnit", null, typeof(EditUnit), 4),
                })
            };
        }

        #endregion
    }
}
