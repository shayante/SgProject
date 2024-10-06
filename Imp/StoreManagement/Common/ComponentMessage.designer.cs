namespace SystemGroup.Training.StoreManagement.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SystemGroup.Framework;
    
    
    // Do not CHANGE this class name or  its content.
    public partial class ComponentMessage : MessageContainer
    {
        
        #region Fields
        private static ComponentMessage instance = new ComponentMessage();
        #endregion
        
        #region Constructors
        static ComponentMessage()
        {
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "UnitTitleShouldBeUnique", "عنوان واحد سنجش تکراری است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartCodeShouldBeUnique", "کد کالا تکراری است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartTitleShouldBeUnique", "عنوان کالا تکراری است"));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidUnitForSavingPart", "خطا در ذخیره سازی کالا: واحد سنجش معتبر نیست"));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "UnitIsUsedInPart", "ازین واحد سنجش در کالا استفاده شده است و نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "StoreCodeShouldBeUnique", "کد انبار تکراری است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "StoreNameShouldBeUnique", "نام انبار تکراری است/"));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidPartForSavingInPartStore", "خطا در ذخیره سازی کالا-انبار: کالا نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartIsUsedInStore", "کالا در انبار ثبت شده است و نمیتوانید آن را حذف کنید"));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidStoreForSavingInPartStore", "خطا در ذخیره سازی کالا-انبار: انبار نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "StoreHasPart", "در انبار کالا ثبت شده است نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartIsAddedToThisStore", "کالا قبلا در انبار ثبت شده است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "ThisPartyIsStoreKeeperAlready", "شخص قبلا به عنوان انبار دار ذخیره شده است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidPartyToSaveAsStoreKeeper", "خطا در ذخیره سازی انبار دار: شخص نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartyIsStoreKeeper", "شخص به عنوان انبار دار ذخیره شده است. نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidStoreKeeperForSavingInInventoryVoucher", "خطا در ذخیره سازی سند انبار: انباردار نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InventoryVoucherIsSubmittedForStoreKeeper", "برای این انبار دار سند انبار ثبت شده است و نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidStoreForSavingInInventoryVoucher", "خطا در ذخیره سازی سند انبار: انبار نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InventoryVoucherIsSubmittedForStore", "برای انبار سند ثبت شده است و نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "ItemIsExistsInInventoryVoucher", "نمیتوانید کالای تکراری در سند انبار ثبت کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidInventoryVoucherForSavingInInventoryVoucherItem", ""));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InventoryVoucherHasItem", "در این سند انبار قلم وجود دارد ونمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "InvalidPartForSavingInInventoryVoucherItem", "خطا در ذخیره قلم سند انبار: کالا نامعتبر است."));
            ComponentMessage.instance.MessageCollection.Add(new SgMessage("SystemGroup.Training.StoreManagement", "PartIsNotatedInInventoryVoucherItem", "کالا در سند انبار ثبت شده است نمیتوانید آن را حذف کنید."));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("UnitTitleShouldBeUnique", 2147483647, new SgKeyword("IX_TRN3_Unit_Title", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartCodeShouldBeUnique", 2147483647, new SgKeyword("IX_TRN3_Part_Code", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartTitleShouldBeUnique", 2147483647, new SgKeyword("IX_TRN3_Part_Title", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidUnitForSavingPart", 2147483647, new SgKeyword("FK_TRN3_Part_UnitRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidUnitForSavingPart", 2147483647, new SgKeyword("FK_TRN3_Part_UnitRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("UnitIsUsedInPart", 2147483647, new SgKeyword("FK_TRN3_Part_UnitRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("StoreCodeShouldBeUnique", 2147483647, new SgKeyword("IX_TRN3_Store_Code", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("StoreNameShouldBeUnique", 2147483647, new SgKeyword("IX_TRN3_StoreName", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartForSavingInPartStore", 2147483647, new SgKeyword("FK_TRN3_PartStore_PartRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartForSavingInPartStore", 2147483647, new SgKeyword("FK_TRN3_PartStore_PartRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartIsUsedInStore", 2147483647, new SgKeyword("FK_TRN3_PartStore_PartRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreForSavingInPartStore", 2147483647, new SgKeyword("FK_TRN3_PartStore_StoreRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreForSavingInPartStore", 2147483647, new SgKeyword("FK_TRN3_PartStore_StoreRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("StoreHasPart", 2147483647, new SgKeyword("FK_TRN3_PartStore_StoreRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartIsAddedToThisStore", 2147483647, new SgKeyword("IX_TRN3_PartStore_PartRef_StoreRef", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("ThisPartyIsStoreKeeperAlready", 2147483647, new SgKeyword("IX_TRN3_StoreKeeper_PartyRef", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartyToSaveAsStoreKeeper", 2147483647, new SgKeyword("FK_TRN3_StoreKeeper_PartyRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartyToSaveAsStoreKeeper", 2147483647, new SgKeyword("FK_TRN3_StoreKeeper_PartyRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartyIsStoreKeeper", 2147483647, new SgKeyword("FK_TRN3_StoreKeeper_PartyRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreKeeperForSavingInInventoryVoucher", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreKeeperRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreKeeperForSavingInInventoryVoucher", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreKeeperRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InventoryVoucherIsSubmittedForStoreKeeper", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreKeeperRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreForSavingInInventoryVoucher", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidStoreForSavingInInventoryVoucher", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InventoryVoucherIsSubmittedForStore", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucher_StoreRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("ItemIsExistsInInventoryVoucher", 2147483647, new SgKeyword("IX_TRN3_InventoryVoucherItem_InventoryVoucherRef_PartRef", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidInventoryVoucherForSavingInInventoryVoucherItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_InventoryVoucherRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidInventoryVoucherForSavingInInventoryVoucherItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_InventoryVoucherRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InventoryVoucherHasItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_InventoryVoucherRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartForSavingInInventoryVoucherItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_PartRef", SgKeywordType.Default), new SgKeyword("Insert", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("InvalidPartForSavingInInventoryVoucherItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_PartRef", SgKeywordType.Default), new SgKeyword("Update", SgKeywordType.Default)));
            ComponentMessage.instance.ExceptionMappingCollection.Add(new ExceptionMapping("PartIsNotatedInInventoryVoucherItem", 2147483647, new SgKeyword("FK_TRN3_InventoryVoucherItem_PartRef", SgKeywordType.Default), new SgKeyword("Delete", SgKeywordType.Default)));
        }
        #endregion
        
        #region Properties
        public static SgMessage UnitTitleShouldBeUnique
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "UnitTitleShouldBeUnique");
            }
        }
        
        public static SgMessage PartCodeShouldBeUnique
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartCodeShouldBeUnique");
            }
        }
        
        public static SgMessage PartTitleShouldBeUnique
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartTitleShouldBeUnique");
            }
        }
        
        public static SgMessage InvalidUnitForSavingPart
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidUnitForSavingPart");
            }
        }
        
        public static SgMessage UnitIsUsedInPart
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "UnitIsUsedInPart");
            }
        }
        
        public static SgMessage StoreCodeShouldBeUnique
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "StoreCodeShouldBeUnique");
            }
        }
        
        public static SgMessage StoreNameShouldBeUnique
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "StoreNameShouldBeUnique");
            }
        }
        
        public static SgMessage InvalidPartForSavingInPartStore
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidPartForSavingInPartStore");
            }
        }
        
        public static SgMessage PartIsUsedInStore
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartIsUsedInStore");
            }
        }
        
        public static SgMessage InvalidStoreForSavingInPartStore
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidStoreForSavingInPartStore");
            }
        }
        
        public static SgMessage StoreHasPart
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "StoreHasPart");
            }
        }
        
        public static SgMessage PartIsAddedToThisStore
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartIsAddedToThisStore");
            }
        }
        
        public static SgMessage ThisPartyIsStoreKeeperAlready
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "ThisPartyIsStoreKeeperAlready");
            }
        }
        
        public static SgMessage InvalidPartyToSaveAsStoreKeeper
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidPartyToSaveAsStoreKeeper");
            }
        }
        
        public static SgMessage PartyIsStoreKeeper
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartyIsStoreKeeper");
            }
        }
        
        public static SgMessage InvalidStoreKeeperForSavingInInventoryVoucher
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidStoreKeeperForSavingInInventoryVoucher");
            }
        }
        
        public static SgMessage InventoryVoucherIsSubmittedForStoreKeeper
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InventoryVoucherIsSubmittedForStoreKeeper");
            }
        }
        
        public static SgMessage InvalidStoreForSavingInInventoryVoucher
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidStoreForSavingInInventoryVoucher");
            }
        }
        
        public static SgMessage InventoryVoucherIsSubmittedForStore
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InventoryVoucherIsSubmittedForStore");
            }
        }
        
        public static SgMessage ItemIsExistsInInventoryVoucher
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "ItemIsExistsInInventoryVoucher");
            }
        }
        
        public static SgMessage InvalidInventoryVoucherForSavingInInventoryVoucherItem
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidInventoryVoucherForSavingInInventoryVoucherItem");
            }
        }
        
        public static SgMessage InventoryVoucherHasItem
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InventoryVoucherHasItem");
            }
        }
        
        public static SgMessage InvalidPartForSavingInInventoryVoucherItem
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "InvalidPartForSavingInInventoryVoucherItem");
            }
        }
        
        public static SgMessage PartIsNotatedInInventoryVoucherItem
        {
            get
            {
                return ComponentMessage.FindMessage(ComponentMessage.instance.MessageCollection, "PartIsNotatedInInventoryVoucherItem");
            }
        }
        #endregion
        
        #region Methods
        public override MessageContainer GetSingleton()
        {
            return ComponentMessage.instance;
        }
        #endregion
    }
}
