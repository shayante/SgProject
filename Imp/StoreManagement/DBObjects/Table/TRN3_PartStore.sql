--<<FileName:TRN3_PartStore.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.PartStore') Is Null
CREATE TABLE [TRN3].[PartStore](
	[PartStoreID] [bigint] NOT NULL,
	[PartRef] [bigint] NOT NULL,
	[StoreRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.PartStore') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.PartStore Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_PartStore')
ALTER TABLE [TRN3].[PartStore] ADD  CONSTRAINT [PK_TRN3_PartStore] PRIMARY KEY CLUSTERED 
(
	[PartStoreID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_PartStore_PartRef')
ALTER TABLE [TRN3].[PartStore]  ADD  CONSTRAINT [FK_TRN3_PartStore_PartRef] FOREIGN KEY([PartRef])
REFERENCES [TRN3].[Part] ([PartID])

GO
If not Exists (select 1 from sys.objects where name = 'FK_TRN3_PartStore_StoreRef')
ALTER TABLE [TRN3].[PartStore]  ADD  CONSTRAINT [FK_TRN3_PartStore_StoreRef] FOREIGN KEY([StoreRef])
REFERENCES [TRN3].[Store] ([StoreID])

GO

--<< DROP OBJECTS >>--
