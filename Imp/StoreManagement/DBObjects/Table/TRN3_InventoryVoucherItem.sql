--<<FileName:TRN3_InventoryVoucherItem.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.InventoryVoucherItem') Is Null
CREATE TABLE [TRN3].[InventoryVoucherItem](
	[InventoryVoucherItemID] [bigint] NOT NULL,
	[InventoryVoucherRef] [bigint] NOT NULL,
	[PartRef] [bigint] NOT NULL,
	[Quantity] [decimal](28, 6) NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.InventoryVoucherItem') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.InventoryVoucherItem Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_InventoryVoucherItem')
ALTER TABLE [TRN3].[InventoryVoucherItem] ADD  CONSTRAINT [PK_TRN3_InventoryVoucherItem] PRIMARY KEY CLUSTERED 
(
	[InventoryVoucherItemID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucherItem_InventoryVoucherRef')
ALTER TABLE [TRN3].[InventoryVoucherItem]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucherItem_InventoryVoucherRef] FOREIGN KEY([InventoryVoucherRef])
REFERENCES [TRN3].[InventoryVoucher] ([InventoryVoucherID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucherItem_PartRef')
ALTER TABLE [TRN3].[InventoryVoucherItem]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucherItem_PartRef] FOREIGN KEY([PartRef])
REFERENCES [TRN3].[Part] ([PartID])

GO

--<< DROP OBJECTS >>--
