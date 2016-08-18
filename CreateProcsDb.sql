USE [kms]
GO
DROP PROCEDURE [dbo].[DeletePerson]
GO

CREATE PROCEDURE [dbo].[DeletePerson] (@recid int)
AS
BEGIN TRY
    BEGIN TRANSACTION
			DELETE FROM [dbo].[kms] WHERE recid = @recid;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    ROLLBACK
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
           @ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH