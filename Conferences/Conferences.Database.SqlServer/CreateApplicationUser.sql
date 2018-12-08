-- run on master
CREATE LOGIN appuser   
   WITH PASSWORD = 'password'
GO 

CREATE USER [appuser] FOR LOGIN [appuser] WITH DEFAULT_SCHEMA=[dbo]
GO

-- run on conferences
CREATE USER [appuser] FOR LOGIN [appuser] WITH DEFAULT_SCHEMA=[dbo]
GO

EXEC sp_addrolemember 'appuserrole', 'appuser';
GO

GRANT SELECT, DELETE, INSERT, UPDATE ON SCHEMA :: dbo TO appuser;
GO