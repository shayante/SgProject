--<<FileName:TRN3_InventoryVoucher.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.InventoryVoucher') Is Null
CREATE TABLE [TRN3].[InventoryVoucher](
	[InventoryVoucherID] [bigint] NOT NULL,
	[Number] [nvarchar](250) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
	[StoreRef] [bigint] NOT NULL,
	[PartyRef] [bigint] NOT NULL,
	[State] [int] NOT NULL,
	[Version] [timestamp] NOT NULL
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

If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_InventoryVoucher_Number')

CREATE UNIQUE NONCLUSTERED INDEX [IX_TRN3_InventoryVoucher_Number] ON [TRN3].[InventoryVoucher]
(
	[Number] ASC
) ON [PRIMARY]

GO
--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_PartyRef')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_PartyRef] FOREIGN KEY([PartyRef])
REFERENCES [GNR3].[Party] ([PartyID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_InventoryVoucher_StoreRef')
ALTER TABLE [TRN3].[InventoryVoucher]  ADD  CONSTRAINT [FK_TRN3_InventoryVoucher_StoreRef] FOREIGN KEY([InventoryVoucherID])
REFERENCES [TRN3].[Store] ([StoreID])

GO

--<< DROP OBJECTS >>--
