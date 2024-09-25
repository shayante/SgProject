--<<FileName:TRN3_StoreKeeper.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.StoreKeeper') Is Null
CREATE TABLE [TRN3].[StoreKeeper](
	[StoreKeeperID] [bigint] NOT NULL,
	[PartyRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.StoreKeeper') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.StoreKeeper Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_StoreKeeper')
ALTER TABLE [TRN3].[StoreKeeper] ADD  CONSTRAINT [PK_TRN3_StoreKeeper] PRIMARY KEY CLUSTERED 
(
	[StoreKeeperID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_StoreKeeper_PartyRef')
ALTER TABLE [TRN3].[StoreKeeper] ADD  CONSTRAINT [IX_TRN3_StoreKeeper_PartyRef] UNIQUE NONCLUSTERED 
(
	[PartyRef] ASC
) ON [PRIMARY]

GO
--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_StoreKeeper_PartyRef')
ALTER TABLE [TRN3].[StoreKeeper]  ADD  CONSTRAINT [FK_TRN3_StoreKeeper_PartyRef] FOREIGN KEY([PartyRef])
REFERENCES [GNR3].[Party] ([PartyID])

GO

--<< DROP OBJECTS >>--
