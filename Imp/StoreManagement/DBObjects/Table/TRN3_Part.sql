--<<FileName:TRN3_Part.sql>>--
--<< TABLE DEFINITION >>--

If Object_ID('TRN3.Part') Is Null
CREATE TABLE [TRN3].[Part](
	[PartID] [bigint] NOT NULL,
	[Code] [nvarchar](250) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[UnitRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]

--TEXTIMAGE_ON [SG_LOBData]
--When a table has text, ntext, image, varchar(max), nvarchar(max), varbinary(max), xml or large user defined type columns uncomment above code
GO
--<< ADD CLOLUMNS >>--

--<<Sample>>--
/*if not exists (select 1 from sys.columns where object_id=object_id('TRN3.Part') and
				[name] = 'ColumnName')
begin
    Alter table TRN3.Part Add ColumnName DataType Nullable
end
GO*/

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'PK_TRN3_Part')
ALTER TABLE [TRN3].[Part] ADD  CONSTRAINT [PK_TRN3_Part] PRIMARY KEY CLUSTERED 
(
	[PartID] ASC
) ON [PRIMARY]
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_Part_Code')


ALTER TABLE [TRN3].[Part] ADD  CONSTRAINT [IX_TRN3_Part_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
) ON [PRIMARY]

GO
If not Exists (select 1 from sys.indexes where name = 'IX_TRN3_Part_Title')


ALTER TABLE [TRN3].[Part] ADD  CONSTRAINT [IX_TRN3_Part_Title] UNIQUE NONCLUSTERED 
(
	[Title] ASC
) ON [PRIMARY]

GO
--<< FOREIGNKEYS DEFINITION >>--

If not Exists (select 1 from sys.objects where name = 'FK_TRN3_Part_UnitRef')
ALTER TABLE [TRN3].[Part]  ADD  CONSTRAINT [FK_TRN3_Part_UnitRef] FOREIGN KEY([UnitRef])
REFERENCES [TRN3].[Unit] ([UnitID])

GO

--<< DROP OBJECTS >>--
