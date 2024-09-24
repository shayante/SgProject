if not Exists(select 1 from sys.schemas where [Name] = 'TRN3')
	exec sp_executesql N'Create schema TRN3 Authorization dbo'
GO