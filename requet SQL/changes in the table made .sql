/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[Description]
      ,[TermID]
      ,[Division]
  FROM [100].[dbo].[RequestStatus]

  --alter table requests add Req_Guid varchar(40)

 -- alter table requests alter column TypeId int  NOT NULL
 --rename column name 
 -- sp_rename 'requests.status', 'Freefield', 'COLUMN'
 --rename table name 
 --sp_rename 'requests', 'requests'
 --was int changed in varchar
 --alter table requests  Alter Column  Freefield varchar(50)
-- alter table ReqItems  Alter Column  patch_color varchar(30)


 --sp_rename 'requests.ModifiedBy', 'ModifyBy', 'COLUMN'
  --sp_rename 'requests.ModifiedByFullName', 'ModifyByFullName', 'COLUMN'
   --sp_rename 'requests.ModifiedDate', 'ModifyDate', 'COLUMN'

  --  sp_rename 'Req_Customer_Detail.ModifiedBy', 'ModifyBy', 'COLUMN'
  --sp_rename 'Req_Customer_Detail.ModifiedByFullName', 'ModifyByFullName', 'COLUMN'
  -- sp_rename 'Req_Customer_Detail.ModifiedDate', 'ModifyDate', 'COLUMN'

 
 -- alter table ReqStatus  Alter Column  guid1 tinyint
 --sp_rename 'ReqStatus.guid1', 'Active', 'COLUMN'

 sp_rename 'Req_Items', 'ReqItems'
 