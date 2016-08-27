USE [kms]
GO

DECLARE @table sysname;
SET @table = 'nsi.status';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[status]
CREATE TABLE [nsi].[status]([recid] int IDENTITY(1,1),[code] tinyint, [name] char(25), [used] bit,
CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED ([recid] ASC))
INSERT INTO [nsi].[status] (code,name,used) VALUES (0,'Не определен',0),
	(1,'Ожидание подачи',0),(2,'Ожидание ответа',1),(3,'Обработана',1),
	(4,'Полис на изготовлении',1),(5,'Полис получен',1),(6,'Полис выдан',1)

--INSERT INTO [nsi].[status] (code,name,used) VALUES (1,'Ожидание подачи',0)
--INSERT INTO [nsi].[status] (code,name,used) VALUES (2,'Ожидание ответа',1)
--INSERT INTO [nsi].[status] (code,name,used) VALUES (3,'Обработана',1)
--INSERT INTO [nsi].[status] (code,name,used) VALUES (4,'Полис на изготовлении',1)
--INSERT INTO [nsi].[status] (code,name,used) VALUES (5,'Полис получен',1)
--INSERT INTO [nsi].[status] (code,name,used) VALUES (6,'Полис выдан',1)
CREATE UNIQUE INDEX code ON [nsi].[status] (code)
GO

DECLARE @table sysname;
SET @table = 'nsi.codfio';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[codfio]
CREATE TABLE [nsi].[codfio]([recid] int IDENTITY(1,1),[code] char(1), [name] char(45),
CONSTRAINT [PK_codfio] PRIMARY KEY CLUSTERED ([recid] ASC))
INSERT INTO [nsi].[codfio] (code,name) VALUES (' ','Стандартная запись')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('0','Нет отчества/имени')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('1','Одна буква в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('2','Пробел в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('3','Одна буква+пробел в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('9','Повтор реквизитов у разных физических лиц*')
GO

DECLARE @table sysname;
SET @table = 'nsi.predst';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[predst]
CREATE TABLE [nsi].[predst]([recid] int IDENTITY(1,1), [code] char(1), [name] char(5),
CONSTRAINT [PK_predst] PRIMARY KEY CLUSTERED ([recid] ASC))
INSERT INTO [nsi].[predst] (code,name) VALUES (' ','Лично')
INSERT INTO [nsi].[predst] (code,name) VALUES ('1','Мать')
INSERT INTO [nsi].[predst] (code,name) VALUES ('2','Отец')
INSERT INTO [nsi].[predst] (code,name) VALUES ('3','Иное')
GO

DECLARE @table sysname;
SET @table = 'nsi.jt';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[jt]
CREATE TABLE [nsi].[jt]([recid] int IDENTITY(1,1), [code] char(1), [name] char(65),
[add] bit, [mod] bit, [izgt] bit, CONSTRAINT [PK_jt] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

DECLARE @table sysname;
SET @table = 'nsi.scenario';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[scenario]
CREATE TABLE [nsi].[scenario]([recid] int IDENTITY(1,1), [code] char(3), [name] char(100),
[pricin] char(3), [tranz] char(3), [add] bit, [mod] bit, [izgt] bit, 
CONSTRAINT [PK_scenario] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

DECLARE @table sysname;
SET @table = 'nsi.d_type4';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[d_type4]
CREATE TABLE [nsi].[d_type4]([recid] int IDENTITY(1,1), [code] char(1), [name] char(50),
CONSTRAINT [PK_d_type4] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

DECLARE @table sysname;
SET @table = 'nsi.true_dr';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[true_dr]
CREATE TABLE [nsi].[true_dr]([recid] int IDENTITY(1,1), [code] tinyint, [name] char(25),
CONSTRAINT [PK_true_dr] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

DECLARE @table sysname;
SET @table = 'nsi.streets';
IF OBJECT_ID(@table) IS NOT NULL AND OBJECTPROPERTY(OBJECT_ID(@table), 'IsTable')=1 DROP TABLE [nsi].[streets]
CREATE TABLE [nsi].[streets]([recid] int IDENTITY(1,1), [code] int, [name] char(60),
CONSTRAINT [PK_streets] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

DECLARE @table sysname;
SET @table = 'nsi.kl';
IF OBJECT_ID(@table, 'U') IS NOT NULL DROP TABLE [nsi].[kl]
CREATE TABLE [nsi].[kl]([recid] int IDENTITY(1,1), [code] tinyint, [name] char(40), [tip] tinyint,
CONSTRAINT [PK_kl] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
