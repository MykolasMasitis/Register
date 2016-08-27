USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name=N'kms')
DROP DATABASE [kms]
GO

CREATE DATABASE [kms]
GO

USE [kms]
GO

CREATE SCHEMA nsi
GO

CREATE TYPE Sex FROM TINYINT NOT NULL
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[adr50]') AND type in (N'U'))
DROP TABLE [dbo].[adr50]
GO

CREATE TABLE [dbo].[adr50](
	[recid] int IDENTITY(0,1), [c_okato] varchar(5), [ra_name] varchar(60), [np_c] varchar(2), [np_name] varchar(60), 
	[ul_c] varchar(2), [ul_name] varchar(60), [dom] varchar(7), [kor] varchar(5), [str] varchar(5), [kv] varchar(5),
	CONSTRAINT [PK_adr50] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [adr50] ([c_okato],[ra_name],[np_c],[np_name],[ul_c],[ul_name],[dom],[kor],[str],[kv]) VALUES
  ('','','','','','','','','','')
GO
CREATE UNIQUE INDEX unik ON adr50 (c_okato, ra_name, np_name, ul_name, dom, kor, str, kv)
GO
CREATE PROCEDURE [dbo].[seekadr50]
(
@c_okato varchar(5)='', @ra_name varchar(60)='', @np_name varchar(60)='', @ul_name varchar(60)='',
@dom varchar(7)='', @kor varchar(5)='', @str varchar(5)='', @kv varchar(5)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM [adr50] WHERE [c_okato]=@c_okato AND [ra_name]=@ra_name AND [np_name]=@np_name AND [ul_name]=@ul_name
	AND [dom]=@dom AND [kor]=@kor AND [str]=@str AND [kv]=@kv;
END
GO

CREATE TABLE [dbo].[adr77](
[recid] int IDENTITY(0,1), [ul] int NOT NULL, [dom] varchar(7), [kor] varchar(5), [str] varchar(5), [kv] varchar(5),
[created] datetime default sysdatetime(),
CONSTRAINT [PK_adr77] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [adr77] (ul, dom, kor, str, kv) VALUES (0, '', '', '', '')
GO
CREATE UNIQUE INDEX unik ON adr77 (ul, dom, kor, str, kv)
GO

CREATE FUNCTION [dbo].[fseekadr77](@ul int=0, @dom varchar(7)='', @kor varchar(5)='', @str varchar(5)='', @kv varchar(5)='')
RETURNS int
BEGIN
 DECLARE @recid int
 SELECT @recid=recid FROM adr77 WHERE ul=@ul AND dom=@dom AND kor=@kor AND str=@str AND kv=@kv

 SET @recid=CASE WHEN @recid IS NULL THEN 0 ELSE @recid END 

 RETURN @recid
END
GO 

CREATE PROCEDURE [dbo].[seekadr77](@ul int=0, @dom varchar(7)='', @kor varchar(5)='', @str varchar(5)='', @kv varchar(5)='',
 @recid int=null out)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM adr77 WHERE ul=@ul AND dom=@dom AND kor=@kor AND str=@str AND kv=@kv;
END
GO

CREATE PROCEDURE [dbo].[addadr77] (
@ul int=0, @dom varchar(7)='', @kor varchar(5)='', @str varchar(5)='', @kv varchar(5)='', @recid int out)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[adr77] (ul,dom,kor,str,kv) VALUES (@ul,@dom,@kor,@str,@kv)
SET @recid = SCOPE_IDENTITY()
RETURN @recid
END
GO

CREATE TABLE [dbo].[answers](
[recid] int IDENTITY(0,1), [kmsid] int, [data] date, [tiperz] varchar(15), [sn_pol] varchar(17), [enp] varchar(16), 
[s_card] varchar(6), [n_card] varchar(10), [date_b] date, [date_e] date, [q] varchar(2), [q_ogrn] varchar(13), [fam] varchar(25),
[im] varchar(25), [ot] varchar(25), [dr] date, [w] Sex, [ans_r] varchar(3), [snils] varchar(14), [c_doc] tinyint,
[s_doc] varchar(9), [n_doc] varchar(8), [d_doc] date, [gr] varchar(3), [erz] varchar(1), [tip_d] varchar(1),
[okato] varchar(5), [npp] byte, [err] varchar(150), [created] datetime default sysdatetime(),
CONSTRAINT [PK_answers] PRIMARY KEY CLUSTERED ([recid] ASC)
)
GO
CREATE INDEX idx_kmsid ON answers (kmsid)
GO

CREATE TABLE [dbo].[errors](
[rid] int IDENTITY(0,1),
[recid] int, [data] date, [err] varchar(5), [comment] varchar(max), [c_t] varchar(5), [pid] varchar(16), [ans_fl] varchar(2),
[step] varchar(4), [v] bit, [dcor] date, [fname] varchar(25),
[created] datetime default sysdatetime(),
CONSTRAINT [PK_errors] PRIMARY KEY CLUSTERED ([rid] ASC))
GO
CREATE INDEX recid ON errors (recid)
GO
CREATE INDEX recidn ON errors (recid) WHERE dcor IS NOT NULL
GO
CREATE INDEX unik ON errors (fname, recid)
GO

CREATE TABLE [dbo].[enp2](
[recid] int IDENTITY(0,1),
[enp] varchar(16), [ogrn] varchar(13), [okato] varchar(5), [dp] date,
[created] datetime default sysdatetime(),
CONSTRAINT [PK_enp2] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [enp2] (enp,ogrn,okato,dp) values ('','','','')
GO
CREATE INDEX enp ON enp2 (enp)
GO
CREATE PROCEDURE [dbo].[seekenp2]
(
@enp varchar(16)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM enp2 WHERE enp=@enp
END
GO

CREATE TABLE [dbo].[moves](
[recid] int IDENTITY(0,1),
[et] varchar(1), [fname] varchar(25), [mkdate] smalldatetime, [kmsid] int, [frecid] varchar(6),
[vs] varchar(9), [s_card] varchar(6), [n_card] varchar(10), [c_okato] varchar(5), [enp] varchar(16), [dp] date, [jt] varchar(1),
[scn] varchar(3), [pricin] varchar(3), [tranz] varchar(3), [q] varchar(2), [err] varchar(5), [err_text] varchar(max),
[ans_fl] varchar(2), [nz] dec(3), [n_kor] dec(6), [fam] varchar(25), [im] varchar(20), [ot] varchar(20), [w] Sex, 
[dr] date, [c_doc] tinyint, [s_doc] varchar(9), [n_doc] varchar(8), [d_doc] date, [e_doc] date,
[created] datetime default sysdatetime(),
CONSTRAINT [PK_moves] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
CREATE INDEX kmsid ON moves (kmsid)
GO
CREATE INDEX fiorecid ON moves (kmsid) WHERE et='1'
GO 
CREATE INDEX ffrecid ON moves (kmsid) WHERE et='2'
GO
CREATE INDEX unik ON moves (fname, frecid)
GO

CREATE TABLE [dbo].[odoc](
[recid] int IDENTITY(0,1),
[c_doc] tinyint, [s_doc] varchar(9) NOT NULL, [n_doc] varchar(8) NOT NULL, [d_doc] date NOT NULL, [e_doc] date,
CONSTRAINT [PK_odoc] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
/*INSERT INTO odoc (c_doc,s_doc,n_doc,d_doc,e_doc) values (0,'','',NULL,NULL)*/
GO
CREATE UNIQUE INDEX unik ON odoc (s_doc, n_doc)
GO
CREATE PROCEDURE [dbo].[seekodoc]
(
@s_doc varchar(9)='', @n_doc varchar(8)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM odoc WHERE s_doc=@s_doc AND n_doc=@n_doc;
END
GO

CREATE TABLE [dbo].[ofio](
[recid] int IDENTITY(0,1),
[fam] varchar(40), [im] varchar(40), [ot] varchar(40), [dr] date, [w] Sex,
[created] datetime default sysdatetime(),
CONSTRAINT [PK_ofio] PRIMARY KEY CLUSTERED ([recid] ASC))
GO

CREATE TABLE [dbo].[osmo](
[recid] int IDENTITY(0,1),
[ogrn] varchar(13) NOT NULL, [okato] varchar(5) NOT NULL, [dp] date,
CONSTRAINT [PK_osmo] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
/*INSERT INTO osmo (ogrn,okato,dp) values ('','',NULL)*/
GO
CREATE PROCEDURE [dbo].[seekosmo]
(
@ogrn varchar(13)='', @okato varchar(5)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM osmo WHERE ogrn=@ogrn AND okato=@okato;
END
GO

-- Permiss
CREATE TABLE [dbo].[permiss](
[recid] int IDENTITY(0,1),
[c_perm] tinyint NOT NULL, [s_perm] varchar(9) NOT NULL, [n_perm] varchar(8) NOT NULL, [d_perm] date, [e_perm] date,
[created] datetime default sysdatetime() NOT NULL,
CONSTRAINT [PK_permiss] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
ALTER TABLE [dbo].[permiss] WITH NOCHECK ADD CONSTRAINT [CK_permiss_c_perm] CHECK (c_perm IN (0,11,23,25))
GO
INSERT INTO permiss (c_perm,s_perm,n_perm,d_perm,e_perm) values (0,'','',NULL,NULL)
GO
CREATE UNIQUE INDEX sn_perm ON permiss (s_perm, n_perm)
GO

CREATE FUNCTION [dbo].[fseekpermiss](@s_perm varchar(9)='', @n_perm varchar(8)='')
RETURNS int
BEGIN
 DECLARE @recid int
 SELECT @recid=recid FROM permiss WHERE s_perm=@s_perm AND n_perm=@n_perm;

 SET @recid=CASE WHEN @recid IS NULL THEN 0 ELSE @recid END 

 RETURN @recid
END
GO 

CREATE PROCEDURE [dbo].[addpermiss] (@c_perm tinyint=0, @s_perm varchar(9)='', @n_perm varchar(8)='', @d_perm date=null, @e_perm date=null)
AS
BEGIN
SET NOCOUNT ON;
DECLARE @recid int
INSERT INTO [dbo].[permiss] (c_perm, s_perm, n_perm, d_perm, e_perm) VALUES (@c_perm, @s_perm, @n_perm, @d_perm, @e_perm)
SET @recid = SCOPE_IDENTITY()
RETURN @recid
END
GO
-- Permiss

CREATE PROCEDURE [dbo].[seekpermiss](@s_perm varchar(9)='', @n_perm varchar(8)='', @recid int=NULL out)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM permiss WHERE s_perm=@s_perm AND n_perm=@n_perm;
END
GO

CREATE TABLE [dbo].[permis2](
[recid] int IDENTITY(0,1),
[c_perm] tinyint NOT NULL, [s_perm] varchar(9) NOT NULL, [n_perm] varchar(8) NOT NULL, [d_perm] date NOT NULL, [e_perm] date NOT NULL,
[created] datetime default sysdatetime() NOT NULL,
CONSTRAINT [PK_permis2] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
ALTER TABLE [dbo].[permis2] WITH NOCHECK ADD CONSTRAINT [CK_permis2_c_perm] CHECK (c_perm IN (11,23,25))
GO
/*INSERT INTO permiss (c_perm,s_perm,n_perm,d_perm,e_perm) values (0,'','',NULL,NULL)*/
GO
CREATE UNIQUE INDEX sn_perm ON permis2 (s_perm, n_perm)
GO
CREATE PROCEDURE [dbo].[seekpermis2]
(
@s_perm varchar(9)='', @n_perm varchar(8)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM permis2 WHERE s_perm=@s_perm AND n_perm=@n_perm;
END
GO

CREATE TABLE [dbo].[predst](
[recid] int IDENTITY(0,1),
[fam] varchar(40), [im] varchar(40), [ot] varchar(40), [c_doc] dec(2), [s_doc] varchar(9), [n_doc] varchar(8), [d_doc] date,
[u_doc] varchar(100), [tel1] varchar(10), [tel2] varchar(10), [inf] varchar(100),
[created] datetime default sysdatetime(),
CONSTRAINT [PK_predst] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO predst (fam,im,ot,c_doc,s_doc,n_doc,d_doc,u_doc,tel1,tel2,inf) values
  ('','','',0,'','',NULL,NULL,'','','')
GO
CREATE INDEX fio ON predst (fam,im,ot)
GO
CREATE PROCEDURE [dbo].[seekpredst]
(
@fam varchar(40)='', @im varchar(40)='', @ot varchar(40)='', @recid int=NULL out
)
AS
BEGIN
SET NOCOUNT ON;
SELECT recid FROM predst WHERE fam=@fam AND im=@im AND ot=@ot;
END
GO

CREATE TABLE [dbo].[users](
[recid] int IDENTITY(0,1),
[pv] varchar(3), [ucod] int, [id] varchar(8), [fam] varchar(25), [im] varchar(20), [ot] varchar(20), [kadr] dec(1),
[created] datetime default sysdatetime(),
CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
CREATE INDEX ucod ON users (ucod)
GO

CREATE TABLE [dbo].[wrkpl](
[recid] int IDENTITY(0,1),
[code] varchar(3), [name] varchar(100),
[created] datetime default sysdatetime(),
CONSTRAINT [PK_wrkpl] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO wrkpl (code,name) values ('','')
GO
CREATE INDEX name ON wrkpl (name)
GO

CREATE TABLE [dbo].[kms](
[recid] int IDENTITY(1,1),
[act] bit NOT NULL DEFAULT 1, [pv] varchar(3), [nz] varchar(5), [status] tinyint NOT NULL DEFAULT 0, [p_doc] tinyint, [p_doc2] tinyint,
[vs] varchar(9), [vs_data] date, [sn_card] varchar(17), [enp] varchar(16), [gz_data] date, [q] varchar(2), [dp] date, [dt] date,
[fam] varchar(40) NOT NULL, [d_type1] varchar(1) NOT NULL DEFAULT ' ', [im] varchar(40) NOT NULL, [d_type2] varchar(1) NOT NULL DEFAULT ' ',
[ot] varchar(40), [d_type3] varchar(1) NOT NULL DEFAULT ' ', [w] tinyint NOT NULL, check (w between 1 and 2), [dr] date NOT NULL,
[true_dr] tinyint NOT NULL DEFAULT 1, [adr_id] int, [adr50_id] int, [jt] varchar(1), [scn] varchar(3), [kl] tinyint NOT NULL DEFAULT 0,
[cont] varchar(40), [c_doc] tinyint, [s_doc] varchar(9), n_doc varchar(8), d_doc date, e_doc date, x_doc tinyint, u_doc varchar(max),
snils varchar(14), gr varchar(3), mr varchar(max), d_reg date, form tinyint NOT NULL DEFAULT 1, predst varchar(1) NOT NULL DEFAULT '0',
spos tinyint NOT NULL DEFAULT 1, d_type4 tinyint, coment varchar(max), ktg varchar(1), gzk_flag tinyint, doc_flag tinyint,
uec_flag varchar(1), s_card2 varchar(12), n_card2 varchar(32), is2fio varchar(1), ofioid int, is2doc varchar(1), odocid int,
mcod varchar(7), oper tinyint, operpv tinyint, isrereg tinyint, osmoid int, permid int, perm2id int, enp2id int, predstid int,
wrkid int, plant varchar(5), dpok date, blanc varchar(11), photo varbinary(max), [sign] varbinary(max), [created] datetime default sysdatetime(),
CONSTRAINT [PK_kms] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
CREATE INDEX fio ON kms (fam,im,ot)
GO
CREATE INDEX adr_id ON kms (adr_id)
GO
CREATE INDEX adr50_id ON kms (adr50_id)
GO
CREATE INDEX ofioid ON kms (ofioid)
GO
CREATE INDEX odocid ON kms (odocid)
GO
CREATE INDEX osmoid ON kms (osmoid)
GO
CREATE INDEX permid ON kms (permid)
GO
CREATE INDEX perm2id ON kms (perm2id)
GO
CREATE INDEX enp2id ON kms (enp2id)
GO
CREATE INDEX predstid ON kms (predstid)
GO

CREATE VIEW kmsview AS SELECT a.recid, a.act,a.pv,a.nz,a.status,a.p_doc,a.p_doc2,a.vs,a.vs_data,a.sn_card,a.enp,a.gz_data,a.q,a.dp,a.dt,a.fam,a.d_type1,
a.im,a.d_type2,a.ot,a.d_type3,a.w,a.dr,a.true_dr,a.adr_id,a.adr50_id,a.jt,a.scn,a.kl,a.cont,a.c_doc,a.s_doc,a.n_doc,a.d_doc,a.e_doc,a.x_doc,a.u_doc,
a.snils,a.gr,a.mr,a.d_reg,a.form,a.predst,a.spos,a.d_type4,a.coment,a.ktg,a.gzk_flag,a.doc_flag,a.uec_flag,a.s_card2,a.n_card2,a.is2fio,a.ofioid,
a.is2doc,a.odocid,a.mcod,a.oper,a.operpv,a.isrereg,a.osmoid,a.permid,a.perm2id,a.enp2id,a.predstid,a.wrkid,a.plant,a.dpok,a.blanc,a.photo,a.sign,a.created,
b.ul, b.dom, b.kor, b.str, b.kv, 
c.c_okato as c_okato, c.ra_name as ra_name, c.np_c as np_c, c.np_name as np_name, c.ul_c as ul_c, c.ul_name as ul_name, 
c.dom as dom2, c.kor as kor2, c.str as str2, c.kv as kv2, 
d.fam as prfam, d.im as prim, d.ot as prot, d.c_doc as prc_doc, d.s_doc as prs_doc, d.n_doc as prn_doc, d.d_doc as prd_doc, 
d.u_doc as prpodr, d.tel1 as prtel1, d.tel2 as prtel2, d.inf as prpinf, 
e.enp as enp2, e.ogrn as ogrn_old2, e.okato as okato_old2, e.dp as dp_old2, 
f.c_doc as oc_doc, f.s_doc as os_doc, f.n_doc as on_doc, f.d_doc as od_doc, f.e_doc as oe_doc, 
g.fam as ofam, g.im as oim, g.ot as oot, g.w as ow, g.dr as odr, 
h.ogrn as ogrn_old, h.okato as okato_old, h.dp as dp_old, 
i.c_perm, i.s_perm, i.n_perm, i.d_perm, i.e_perm, 
j.c_perm as c_perm2, j.s_perm as s_perm2, j.n_perm as n_perm2, j.d_perm as d_perm2, j.e_perm as e_perm2, 
k.code as wrkcode, k.name as wrkname 
FROM dbo.kms a 
INNER JOIN dbo.adr77 b ON a.adr_id=b.recid INNER JOIN dbo.adr50 c ON a.adr50_id=c.recid 
INNER JOIN dbo.predst d ON a.predstid=d.recid INNER JOIN dbo.enp2 e ON a.enp2id=e.recid 
INNER JOIN dbo.odoc f ON a.odocid=f.recid INNER JOIN dbo.ofio g ON a.ofioid=g.recid 
INNER JOIN dbo.osmo h ON a.osmoid=h.recid INNER JOIN dbo.permiss i ON a.permid=i.recid 
INNER JOIN dbo.permis2 j ON a.perm2id=j.recid INNER JOIN dbo.wrkpl k ON a.wrkid=k.recid 
GO

CREATE PROCEDURE [dbo].[GetPersons]
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM kmsview;
END
GO

CREATE PROCEDURE [dbo].[AddPerson](
@recid int OUTPUT, @act bit, @pv varchar(3)=null, @nz varchar(5)=null, @status tinyint, @p_doc tinyint=0,
@p_doc2 tinyint=0, @vs varchar(9)=null, @vs_data date=null, @sn_card varchar(17)=null, @enp varchar(16)=null,
@gz_data date=null, @q varchar(2)=null, @dp date=null, @dt date=null, @fam varchar(40)=null, @d_type1 varchar(1)=' ',
@im varchar(40)=null, @d_type2 varchar(1)=' ',@ot varchar(40)=null, @d_type3 varchar(1)=' ', @w tinyint, @dr date=null,
@true_dr tinyint=null, @adr_id int=null , @adr50_id int=null,@jt varchar(1)=null, @scn varchar(3)=null,
@kl tinyint=0, @cont varchar(40)=null, @c_doc tinyint=0, @s_doc varchar(9)=null, @n_doc varchar(8)=null,
@d_doc date=null,@e_doc date=null, @x_doc tinyint=0, @u_doc varchar(max)=null, @snils varchar(14)=null,
@gr varchar(3)=null, @mr varchar(max)=null, @d_reg date=null, @form tinyint=0,@predst varchar(1)='0',
@spos tinyint=0, @d_type4 tinyint=0, @coment varchar(max)=null, @ktg varchar(1)=null, @gzk_flag tinyint=0,
@doc_flag tinyint, @uec_flag varchar(1)=null,@s_card2 varchar(12)=null, @n_card2 varchar(32)=null,
@is2fio varchar(1)=null, @ofioid int=0, @is2doc varchar(1)=null, @odocid int=0,@mcod varchar(7)=null,
@oper tinyint=0, @operpv tinyint=0, @isrereg tinyint=0, @osmoid int=0, @permid int=0, @perm2id int=0,
@enp2id int=0, @predstid int=0, @wrkid int=0, @plant varchar(5)=null, @dpok date=null, @blanc varchar(11)=null,
@photo varbinary(max)=null)
AS
BEGIN TRY
	BEGIN TRANSACTION
			INSERT INTO [dbo].[kms] (
			act,pv,nz,status,p_doc,p_doc2,vs,vs_data,sn_card,enp,
			gz_data,q,dp,dt,fam,d_type1,im,d_type2,ot,d_type3,w,dr,true_dr,adr_id,adr50_id,
			jt,scn,kl,cont,c_doc,s_doc,n_doc,d_doc,e_doc,x_doc,u_doc,snils,gr,mr,d_reg,form,
			predst,spos,d_type4,coment,ktg,gzk_flag,doc_flag,uec_flag,s_card2,n_card2,is2fio,
			ofioid,is2doc,odocid,mcod,oper,operpv,isrereg,osmoid,permid,perm2id,enp2id,predstid,
			wrkid,plant,dpok,blanc,photo) VALUES (
			@act,@pv,@nz,@status,@p_doc,@p_doc2,@vs,@vs_data,@sn_card,@enp,
			@gz_data,@q,@dp,@dt,@fam,@d_type1,@im,@d_type2,@ot,@d_type3,@w,@dr,@true_dr,@adr_id,@adr50_id,
			@jt,@scn,@kl,@cont,@c_doc,@s_doc,@n_doc,@d_doc,@e_doc,@x_doc,@u_doc,@snils,@gr,@mr,@d_reg,@form,
			@predst,@spos,@d_type4,@coment,@ktg,@gzk_flag,@doc_flag,@uec_flag,@s_card2,@n_card2,@is2fio,
			@ofioid,@is2doc,@odocid,@mcod,@oper,@operpv,@isrereg,@osmoid,@permid,@perm2id,@enp2id,@predstid,
			@wrkid,@plant,@dpok,@blanc,@photo);
	COMMIT TRANSACTION
	--SET @recid = SCOPE_IDENTITY();
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    ROLLBACK
    -- Raise an error with the details of the exception
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
           @ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH
GO 

CREATE PROCEDURE [dbo].[UpdatePerson](
@recid int OUTPUT, @act bit, @pv varchar(3)=null, @nz varchar(5)=null, @status tinyint, @p_doc tinyint=0,
@p_doc2 tinyint=0, @vs varchar(9)=null, @vs_data date=null, @sn_card varchar(17)=null, @enp varchar(16)=null,
@gz_data date=null, @q varchar(2)=null, @dp date=null, @dt date=null, @fam varchar(40)=null, @d_type1 varchar(1)=' ',
@im varchar(40)=null, @d_type2 varchar(1)=' ',@ot varchar(40)=null, @d_type3 varchar(1)=' ', @w tinyint, @dr date=null,
@true_dr tinyint=null,
@adr_id int=null, @ul int=0, @dom varchar(7)=null, @kor varchar(5)=null, @str varchar(5)=null, @kv varchar(5) = null,
@adr50_id int=null,@jt varchar(1)=null, @scn varchar(3)=null,
@kl tinyint=0, @cont varchar(40)=null, @c_doc tinyint=0, @s_doc varchar(9)=null, @n_doc varchar(8)=null,
@d_doc date=null,@e_doc date=null, @x_doc tinyint=0, @u_doc varchar(max)=null, @snils varchar(14)=null,
@gr varchar(3)=null, @mr varchar(max)=null, @d_reg date=null, @form tinyint=0,@predst varchar(1)='0',
@spos tinyint=0, @d_type4 tinyint=0, @coment varchar(max)=null, @ktg varchar(1)=null, @gzk_flag tinyint=0,
@doc_flag tinyint, @uec_flag varchar(1)=null,@s_card2 varchar(12)=null, @n_card2 varchar(32)=null,
@is2fio varchar(1)=null, @ofioid int=0, @is2doc varchar(1)=null, @odocid int=0,@mcod varchar(7)=null,
@oper tinyint=0, @operpv tinyint=0, @isrereg tinyint=0, @osmoid int=0,
@permid int=0, @c_perm tinyint=0, @s_perm varchar(9)='', @n_perm varchar(8)='', @d_perm date=null, @e_perm date=null,
@perm2id int=0,
@enp2id int=0, @predstid int=0, @wrkid int=0, @plant varchar(5)=null, @dpok date=null, @blanc varchar(11)=null,
@photo varbinary(max)=null)
AS
BEGIN TRY
	BEGIN TRANSACTION
	
	DECLARE @_adr_id int
	SET @_adr_id = dbo.fseekadr77(@ul, @dom, @kor, @str, @kv)
	IF (@_adr_id != 0 ) SET @adr_id = @_adr_id
	ELSE EXEC dbo.addadr77 @ul=@ul, @dom=@dom, @kor=@kor, @str=@str, @kv=@kv, @recid=@adr_id out

	DECLARE @_permid int
	SET @_permid = dbo.seekpermiss(@s_perm, @n_perm)
	IF (@_permid != 0 ) SET @permid = @_permid
	ELSE EXEC dbo.addpermiss @c_perm=@c_perm, @s_perm=@s_perm, @n_perm=@n_perm, @d_perm=@d_perm, @e_perm=@e_perm, @recid=@permid out

    UPDATE [dbo].[kms] SET 
		act=@act,pv=@pv,nz=@nz,status=@status,p_doc=@p_doc,p_doc2=@p_doc2,vs=@vs,vs_data=@vs_data,sn_card=@sn_card,
		enp=@enp,gz_data=@gz_data,q=@q,dp=@dp,dt=@dt,fam=@fam,d_type1=@d_type1,im=@im,d_type2=@d_type2,ot=@ot,
		d_type3=@d_type3,w=@w,dr=@dr,true_dr=@true_dr,adr_id=@adr_id,adr50_id=@adr50_id,jt=@jt,scn=@scn,kl=@kl,
		cont=@cont,c_doc=@c_doc,s_doc=@s_doc,n_doc=@n_doc,d_doc=@d_doc,e_doc=@e_doc,x_doc=@x_doc,u_doc=@u_doc,
		snils=@snils,gr=@gr,mr=@mr,d_reg=@d_reg,form=@form,predst=@predst,spos=@spos,d_type4=@d_type4,coment=@coment,
		ktg=@ktg,gzk_flag=@gzk_flag,doc_flag=@doc_flag,uec_flag=@uec_flag,s_card2=@s_card2,n_card2=@n_card2,
		is2fio=@is2fio,ofioid=@ofioid,is2doc=@is2doc,odocid=@odocid,mcod=@mcod,oper=@oper,operpv=@operpv,
		isrereg=@isrereg,osmoid=@osmoid,permid=@permid,perm2id=@perm2id,enp2id=@enp2id,predstid=@predstid,
		wrkid=@wrkid,plant=@plant,dpok=@dpok,blanc=@blanc,photo=@photo WHERE recid=@recid
	
	COMMIT TRANSACTION    
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
		ROLLBACK
END CATCH
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
GO

CREATE TABLE [nsi].[status]([recid] int IDENTITY(1,1),[code] tinyint, [name] char(25), [used] bit,
CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [nsi].[status] (code,name,used) VALUES (0,'Не определен',0)
INSERT INTO [nsi].[status] (code,name,used) VALUES (1,'Ожидание подачи',0)
INSERT INTO [nsi].[status] (code,name,used) VALUES (2,'Ожидание ответа',1)
INSERT INTO [nsi].[status] (code,name,used) VALUES (3,'Обработана',1)
INSERT INTO [nsi].[status] (code,name,used) VALUES (4,'Полис на изготовлении',1)
INSERT INTO [nsi].[status] (code,name,used) VALUES (5,'Полис получен',1)
INSERT INTO [nsi].[status] (code,name,used) VALUES (6,'Полис выдан',1)
CREATE UNIQUE INDEX code ON [nsi].[status] (code)
GO

CREATE TABLE [nsi].[codfio]([recid] int IDENTITY(1,1),[code] char(1), [name] char(45),
CONSTRAINT [PK_codfio] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [nsi].[codfio] (code,name) VALUES (' ','Стандартная запись')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('0','Нет отчества/имени')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('1','Одна буква в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('2','Пробел в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('3','Одна буква+пробел в фамилии/имени/отчестве')
INSERT INTO [nsi].[codfio] (code,name) VALUES ('9','Повтор реквизитов у разных физических лиц*')
GO

CREATE TABLE [nsi].[predst]([recid] int IDENTITY(1,1), [code] char(1), [name] char(5),
CONSTRAINT [PK_predst] PRIMARY KEY CLUSTERED ([recid] ASC))
GO
INSERT INTO [nsi].[predst] (code,name) VALUES (' ','Лично')
INSERT INTO [nsi].[predst] (code,name) VALUES ('1','Мать')
INSERT INTO [nsi].[predst] (code,name) VALUES ('2','Отец')
INSERT INTO [nsi].[predst] (code,name) VALUES ('3','Иное')
GO
