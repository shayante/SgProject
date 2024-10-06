--<<FileName:TRN3_InventoryVoucher.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.InventoryVoucher') Is Null
CREATE TABLE [TRN3].[InventoryVoucher](
	[InventoryVoucherID] [bigint] NOT NULL,
	[Number] [nvarchar](250) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
	[StoreRef] [bigint] NOT NULL,
	[StoreKeeperRef] [bigint] NOT NULL,
	[State] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
	[Creator] [bigint] NOT NULL,
	[LastModifier] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModificationDate] [datetime] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.InventoryVoucher') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.InventoryVoucher Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_InventoryVoucher')
ALTER TABLE [TRN3].[InventoryVoucher] ADD  CONSTRAINT [PK_TRN3_InventoryVoucher] PRIMARY KEY CLUSTERED 
(
	[InventoryVoucherID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_Creator')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_Creator] FOREIGN KEY([Creator])
REFERENCES [SYS3].[User] ([UserID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_LastModifier')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_LastModifier] FOREIGN KEY([LastModifier])
REFERENCES [SYS3].[User] ([UserID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_StoreKeeperRef')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_StoreKeeperRef] FOREIGN KEY([StoreKeeperRef])
REFERENCES [TRN3].[StoreKeeper] ([StoreKeeperID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_StoreRef')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_StoreRef] FOREIGN KEY([StoreRef])
REFERENCES [TRN3].[Store] ([StoreID])

GO

--<< DROP OBJECTS >>--
