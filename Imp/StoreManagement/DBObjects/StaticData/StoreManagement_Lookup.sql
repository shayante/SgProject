DECLARE @system nvarchar (50) = N'TRN3'
DECLARE @type nvarchar(500) = N'InventoryVoucherType'
DECLARE @token nvarchar (500) = @system + '|' + @type
--------------------------------------------------------------------------------------

EXEC sys3.InitializeLookup @system , @type , N'ورود/خروج'

EXEC sys3.AddLookupValue @token , 1 , N'ورود' , 1
EXEC sys3.AddLookupValue @token , 2 , N'خروج' , 2

EXEC sys3.AddLookupTranslation @token , 1 , N'en-us' , N'Enter'
EXEC sys3.AddLookupTranslation @token , 2 , N'en-us' , N'Exit'