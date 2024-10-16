﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemGroup.Training.Pricing.Common
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GeneralDvp")]
	public partial class DataModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertItemPrice(ItemPrice instance);
    partial void UpdateItemPrice(ItemPrice instance);
    partial void DeleteItemPrice(ItemPrice instance);
    #endregion
		
		//public DataModelDataContext() : 
		//		base(global::SystemGroup.Training.StoreManagement.Common.Properties.Settings.Default.GeneralDvpConnectionString2, mappingSource)
		//{
		//	OnCreated();
		//}
		
		public DataModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ItemPrice> ItemPrices
		{
			get
			{
				return this.GetTable<ItemPrice>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="TRN3.ItemPrice")]
	public partial class ItemPrice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _VoucherItemRef;
		
		private decimal _Price;
		
		private System.Data.Linq.Binary _Version;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnVoucherItemRefChanging(long value);
    partial void OnVoucherItemRefChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnVersionChanging(System.Data.Linq.Binary value);
    partial void OnVersionChanged();
    #endregion
		
		public ItemPrice()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="ItemPriceID", Storage="_ID", DbType="BigInt NOT NULL", IsPrimaryKey=true, UpdateCheck=UpdateCheck.Never)]
		public override long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="InventoryVoucherItemRef", Storage="_VoucherItemRef", DbType="BigInt NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public long VoucherItemRef
		{
			get
			{
				return this._VoucherItemRef;
			}
			set
			{
				if ((this._VoucherItemRef != value))
				{
					this.OnVoucherItemRefChanging(value);
					this.SendPropertyChanging();
					this._VoucherItemRef = value;
					this.SendPropertyChanged("VoucherItemRef");
					this.OnVoucherItemRefChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(28,6) NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersionChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Version");
					this.OnVersionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
