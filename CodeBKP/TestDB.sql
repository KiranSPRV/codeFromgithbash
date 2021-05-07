
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserName] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Age] [INT] NULL,
	IsDeleted BIT NULL,
	Createdon DateTime NULL,
	UpdatedOn DateTime NULL,
   )

--EXEC  ANGJSAPI_PROC_GetAllUsers 1
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ANGJSAPI_PROC_GetAllUsers')  
EXEC('CREATE PROCEDURE dbo.ANGJSAPI_PROC_GetAllUsers AS SET NOCOUNT ON;')
GO  

--EXEC  ANGJSAPI_PROC_GetAllUsers 1
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ANGJSAPI_PROC_GetAllUsers')  
EXEC('CREATE PROCEDURE dbo.ANGJSAPI_PROC_GetAllUsers AS SET NOCOUNT ON;')
GO 
ALTER  PROCEDURE [dbo].[ANGJSAPI_PROC_GetAllUsers]
(
  @UserID INT=NULL
)  
AS  
BEGIN  
      
	IF @UserID IS NULL
	   BEGIN
	            SELECT * FROM [USER] WHERE IsDeleted=0
	   END
	ELSE
	    BEGIN
	            SELECT * FROM [USER] WHERE  USERID=@UserID AND IsDeleted=0
	   END
	
END  
GO
--EXEC  ANGJSAPI_PROC_INSERT_UPDATE_USER 1
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ANGJSAPI_PROC_GetAllUsers')  
EXEC('CREATE PROCEDURE dbo.ANGJSAPI_PROC_INSERT_UPDATE_USER AS SET NOCOUNT ON;')
GO  
ALTER  PROCEDURE [dbo].[ANGJSAPI_PROC_INSERT_UPDATE_USER]
(
  @USERID INT=NULL,
  @UserName VARCHAR(100)=NULL,
  @City VARCHAR(100)=NULL,
  @Age INT =NULL
)  
AS  
BEGIN  
    
	IF NOT EXISTS (SELECT 1 FROM [USER] WHERE UserID=@USERID)
	BEGIN
	       INSERT INTO [dbo].[User]
           ([UserName] ,[City] ,[Age],[IsDeleted] ,[Createdon]
           )
     VALUES
           (@UserName ,@City   ,@Age ,0 ,GETDATE()
           )
	END
	ELSE
	    BEGIN
		        UPDATE [USER] SET UserName=@UserName,City=@City,Age=@Age,UpdatedOn=GETDATE()
				                  WHERE USERID=@USERID
		END
	
END  
GO

--EXEC  ANGJSAPI_PROC_DELETE_USER 1
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ANGJSAPI_PROC_GetAllUsers')  
EXEC('CREATE PROCEDURE dbo.ANGJSAPI_PROC_DELETE_USER AS SET NOCOUNT ON;')
GO  
ALTER  PROCEDURE [dbo].[ANGJSAPI_PROC_DELETE_USER]
(
  @USERID INT=NULL
)  
AS  
BEGIN  
    
	 UPDATE [USER] SET IsDeleted=1,UpdatedOn=GETDATE() where UserID=@USERID
	
END  
GO