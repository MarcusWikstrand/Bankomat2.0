use master
go

if  exists (
	select name 
		from sys.databases 
		where name = 'Banks'
)
drop database [Banks]
go

create database [Banks]
go

use [Banks]
go

create table Bank
(
  Bic varchar(8) not null primary key,
  Name varchar(255) not null
)
go

INSERT INTO bank (Bic, Name) VALUES ('00000001', 'The Iron Bank');

create table Customer
(
  Ssn varchar(12) primary key not null,
  FirstName varchar(100) not null,
  LastName varchar(100) not null,
  Bank varchar(8) FOREIGN KEY REFERENCES Bank(Bic)
)
go

create table Account
(
  AccountNumber int primary key not null,
  Holder varchar(12) FOREIGN KEY REFERENCES Customer(Ssn),
  Bank varchar(8) FOREIGN KEY REFERENCES Bank(Bic)
)
go

create table PaymentCard
(
  CardNumber varchar(5) primary key,
  Pin int not null,
  Holder varchar(12) FOREIGN KEY REFERENCES Customer(Ssn),
  PrimaryAccount int FOREIGN KEY REFERENCES Account(AccountNumber)
)
go

create table AccountTransaction
(
  TransactionId int IDENTITY(1,1) Primary Key,
  Account int FOREIGN KEY REFERENCES Account(AccountNumber),
  Amount decimal not null,
  TransactionTime DateTime not null DEFAULT GETDATE(),
  Outcome bit not null,
  Client int not null,
  PaymentCard varchar(5) FOREIGN KEY REFERENCES PaymentCard(CardNumber),
  Bank varchar(8) FOREIGN KEY REFERENCES Bank(Bic)
)
go

create table BalanceAccess
(
  BalanceAccessId int IDENTITY(1,1) Primary Key,
  BalanceAccessTime DateTime not null DEFAULT GETDATE(),
  Client int not null,
  PaymentCard varchar(5) FOREIGN KEY REFERENCES PaymentCard(CardNumber),
  Account int FOREIGN KEY REFERENCES Account(AccountNumber),
  Bank varchar(8) FOREIGN KEY REFERENCES Bank(Bic)
)
go

create table BankAuthentication
(
  AuhenticationId int IDENTITY(1,1) Primary Key,
  Pin int not null,
  AuthenticationTime DateTime not null DEFAULT GETDATE(),
  Outcome bit not null,
  Client int not null,
  PaymentCard varchar(5) FOREIGN KEY REFERENCES PaymentCard(CardNumber),
  Bank varchar(8) FOREIGN KEY REFERENCES Bank(Bic)
)
go


-- Seeds------------------------------------------------------------------------
--------------------------------------------------------------------------------
INSERT INTO Customer (Ssn, FirstName, LastName, Bank) VALUES ('199017179999', 'Kalle', 'Karlsson', '00000001');
INSERT INTO Customer (Ssn, FirstName, LastName, Bank) VALUES ('199017178888', 'Bo', 'Bosson', '00000001');
INSERT INTO Customer (Ssn, FirstName, LastName, Bank) VALUES ('199017177777', 'Li', 'Lisson', '00000001');
INSERT INTO Customer (Ssn, FirstName, LastName, Bank) VALUES ('199017176666', 'Dan', 'Dansson', '00000001');

INSERT INTO Account (AccountNumber, Holder, Bank) VALUES ('55555', '199017179999', '00000001');
INSERT INTO Account (AccountNumber, Holder, Bank) VALUES ('66666', '199017178888', '00000001');
INSERT INTO Account (AccountNumber, Holder, Bank) VALUES ('77777', '199017177777', '00000001');
INSERT INTO Account (AccountNumber, Holder, Bank) VALUES ('88888', '199017176666', '00000001');

INSERT INTO PaymentCard (Pin, CardNumber, Holder, PrimaryAccount) VALUES (1111, '55555', '199017179999', 55555);
INSERT INTO PaymentCard (Pin, CardNumber, Holder, PrimaryAccount) VALUES (2222, '66666', '199017178888', 66666);
INSERT INTO PaymentCard (Pin, CardNumber, Holder, PrimaryAccount) VALUES (3333, '77777', '199017177777', 77777);
INSERT INTO PaymentCard (Pin, CardNumber, Holder, PrimaryAccount) VALUES (4444, '88888', '199017176666', 88888);

INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('55555', -1000, 'true', 1337, '88888', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('55555', -500, 'true', 1337, '88888', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('55555', -200, 'true', 1337, '88888', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('55555', -100, 'true', 1337, '88888', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('66666', -300, 'true', 1337, '77777', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('66666', -100, 'true', 1337, '77777', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('66666', -100, 'true', 1337, '77777', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('77777', -300, 'true', 1337, '66666', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('77777', -500, 'true', 1337, '66666', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('77777', -400, 'true', 1337, '66666', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('88888', -100, 'true', 1337, '55555', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('88888', -1000, 'true', 1337, '55555', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('88888', -1200, 'true', 1337, '55555', '00000001');
INSERT INTO AccountTransaction (Account, Amount, Outcome, Client, PaymentCard, Bank) VALUES ('88888', -1100, 'true', 1337, '55555', '00000001');






use Banks
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_MakeTransaction]
	-- Add the parameters for the stored procedure here
	@Account int,
	@Amount decimal,
	@Outcome bit,
	@Client int,
	@PaymentCard varchar(5),
	@Bank varchar(8),
	@Time DateTime output
as
begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @ErrMsg varchar(4000);

	BEGIN TRY
	  PRINT 'Maing an transaction'
	  BEGIN TRANSACTION [myTran]
		INSERT INTO AccountTransaction(Account, Amount, Outcome, Client, PaymentCard, Bank) 
		VALUES (@Account, @Amount, @Outcome, @Client, @PaymentCard, @Bank)

		DECLARE @accountID int
		SET @accountID = SCOPE_IDENTITY()
		SET @Time = (SELECT TransactionTime FROM AccountTransaction WHERE TransactionId=@accountID)
	  COMMIT TRANSACTION [myTran]
	  PRINT 'Transaction completed.'
	END TRY
	BEGIN CATCH
	  IF(@@TRANCOUNT>0)
	  BEGIN
		--@ErrMsg = 'Test'
		PRINT ERROR_MESSAGE()
		PRINT 'Error, transaction will rollback'	
		ROLLBACK TRANSACTION [myTran]
		PRINT 'Done.'
	  END
	END CATCH

	SET NOCOUNT OFF
END
go



