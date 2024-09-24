--<<FileName:TRN3_Unit.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.Unit') Is Null
CREATE TABLE [TRN3].[Unit](
	[UnitID] [bigint] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.Unit') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.Unit Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_Unit')
ALTER TABLE [TRN3].[Unit] ADD  CONSTRAINT [PK_TRN3_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_Unit_Title')


ALTER TABLE [TRN3].[Unit] ADD  CONSTRAINT [IX_TRN3_Unit_Title] UNIQUE NONCLUSTERED 
(
	[Title] ASC
) ON [PRIMARY]

GO
--<< FOREIGNKEYS DEFINITION >>--


--<< DROP OBJECTS >>--
