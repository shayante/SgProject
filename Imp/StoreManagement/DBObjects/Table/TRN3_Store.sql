--<<FileName:TRN3_Store.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.Store') Is Null
CREATE TABLE [TRN3].[Store](
	[StoreID] [bigint] NOT NULL,
	[Code] [nvarchar](250) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.Store') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.Store Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_Store')
ALTER TABLE [TRN3].[Store] ADD  CONSTRAINT [PK_TRN3_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_Store_Code')


ALTER TABLE [TRN3].[Store] ADD  CONSTRAINT [IX_TRN3_Store_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
) ON [PRIMARY]

GO
If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_Store_Name')


ALTER TABLE [TRN3].[Store] ADD  CONSTRAINT [IX_TRN3_Store_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
) ON [PRIMARY]

GO
--<< FOREIGNKEYS DEFINITION >>--


--<< DROP OBJECTS >>--
