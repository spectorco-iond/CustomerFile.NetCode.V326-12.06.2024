/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [cus_no]
      ,[ord_no]
      ,[isNotCredit]
      ,[tot_amt_fc]
      ,[inv_year]
      ,[region]
      ,[ClassificationId]
      ,[cus_city]
      ,[regionBD]
      ,[orderType]
      ,[AccountEmployeeId]
      ,[inv_dt]
      ,[oe_po_no]
      ,[cnt_no]
      ,[cnt_name]
  FROM [100].[dbo].[rptdash_sales_SelfPromoAllowance]

  SELECT        cus_no, ord_no, CASE WHEN orig_ord_type = 'C' THEN 0 ELSE 1 END AS isNotCredit, tot_amt_fc, YEAR(inv_dt) AS inv_year, region, ClassificationId, cus_city, regionBD, user_def_fld_2 AS orderType, 
                         AccountEmployeeId, inv_dt, oe_po_no, cnt_no, cnt_name
FROM            dbo.rptdash_sales_CustomerSalesInHistory
WHERE        (item_no LIKE '88MKALLOW16%')

 select cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   betty.Bankers_VolumeRebate V 
  left join rptdash_sales_SelfPromoAllowance on cus_no = custno  where custno = 'N144' order by inv_dt desc

   select *  from   betty.Bankers_VolumeRebate V 
  left join rptdash_sales_SelfPromoAllowance on cus_no = custno  where custno = 'N144' order by inv_dt desc

    SELECT        cus_no, ord_no, CASE WHEN orig_ord_type = 'C' THEN 0 ELSE 1 END AS isNotCredit, tot_amt_fc, YEAR(inv_dt) AS inv_year, region, ClassificationId, cus_city, regionBD, user_def_fld_2 AS orderType, 
                         AccountEmployeeId, inv_dt, oe_po_no, cnt_no, cnt_name
FROM            dbo.rptdash_sales_CustomerSalesInHistory
WHERE        (item_no LIKE '88MKALLOW16%')

select 'Allowance' as prog_name,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   betty.Bankers_VolumeRebate V 
left join rptdash_sales_SelfPromoAllowance on cus_no = custno  where cus_no = 's753'
 union
select 'Self Promo' as prog_name,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   betty.Bankers_VolumeRebate V 
  left join  -- Like View rptdash_sales_SelfPromoAllowance
(SELECT  cus_no, ord_no,item_no, CASE WHEN orig_ord_type = 'C' THEN 0 ELSE 1 END AS isNotCredit, tot_amt_fc, YEAR(inv_dt) AS inv_year, region, ClassificationId, cus_city, regionBD, user_def_fld_2 AS orderType, 
                         AccountEmployeeId, inv_dt, oe_po_no, cnt_no, cnt_name
FROM            dbo.rptdash_sales_CustomerSalesInHistory
WHERE        (item_no LIKE '88SELFPROMO%')  ) sp on v.CUSTNO = sp.cus_no where  cus_no = 's753' and inv_year = year(getdate())


select  year(getdate())

select 'Allowance' as prog_name,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   
betty.Bankers_VolumeRebate V  Left Join rptdash_sales_SelfPromoAllowance on cus_no = custno -- where  custno = 'S753'   
union 
Select 'Self Promo' as prog_name,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from  
betty.Bankers_VolumeRebate V   Left Join  (SELECT  cus_no, ord_no,item_no, CASE WHEN orig_ord_type = 'C' THEN 0 ELSE 1 END AS isNotCredit, 
tot_amt_fc, YEAR(inv_dt) AS inv_year, region, ClassificationId, cus_city, regionBD, user_def_fld_2 AS orderType,AccountEmployeeId, 
inv_dt, oe_po_no, cnt_no, cnt_name  From dbo.rptdash_sales_CustomerSalesInHistory  Where (item_no Like '88SELFPROMO%')) sp on 
v.CUSTNO = sp.cus_no -- where   cus_no = 'S753'

-- VIEW - rptdash_sales_CustomerSalesInHistory -
SELECT        oeh.ord_no, oeh.cus_no, c.cmp_name, oel.qty_to_ship, oeh.orig_ord_type, CASE WHEN oeh.orig_ord_type = 'C' THEN ((oel.qty_ordered * - 1) * (oel.unit_price) * ((100 - oel.discount_pct) / 100)) 
                         ELSE ((oel.qty_to_ship * oel.unit_price) * ((100 - oel.discount_pct) / 100)) END AS tot_amt_fc, oel.item_no, c.region, c.ClassificationId, oeh.inv_dt, oeh.user_def_fld_2, oeh.oe_po_no, oeh.ord_type, 
                         c.numberfield2 AS eqp_target, c.textfield1 AS eqp_status, c.cmp_fcity AS cus_city, oel.line_no, oel.line_seq_no, c.textfield4 AS regionBD, c.numberfield2 AS target_amt, c.AccountEmployeeId, ISNULL(n.ID, '') 
                         AS cnt_no, ISNULL(n.FullName, '') AS cnt_name
FROM            dbo.oelinhst_sql AS oel WITH (NOLOCK) INNER JOIN
                         dbo.oehdrhst_sql AS oeh WITH (NOLOCK) ON oel.inv_no = oeh.inv_no INNER JOIN
                         dbo.cicmpy_betty AS c WITH (NOLOCK) ON oeh.cus_no = c.cmp_code LEFT OUTER JOIN
                         dbo.EXACT_TRAVELER_ORDER_CUSTOMER_CONTACTS_NEW AS omn WITH (NOLOCK) ON omn.orderNo = LTRIM(oeh.ord_no) AND omn.contactType = 0 AND omn.primaryContact = 1 LEFT OUTER JOIN
                         dbo.cicntp AS n ON n.ID = omn.defContact

SELECT        TOP (100) PERCENT ID, cmp_code, cmp_name, cmp_fadd1, cmp_fadd2, cmp_fadd3, cmp_fpc, cmp_fcity, StateCode, cmp_fctry, cmp_fax, cmp_tel, cmp_type, cmp_status, textfield1, textfield2, textfield3, textfield4, 
                         textfield5, ClassificationId, type_since, status_since, syscreated, syscreator, sysmodified, sysmodifier, Currency, PaymentMethod, CreditLine, PaymentCondition, AccountEmployeeId, region, 
                         SalesPersonNumber, Terms, cmp_e_mail, cmp_web, AccountTypeCode, cmp_wwn, cmp_parent, TaxCode, TaxCode2, TaxCode3, CreditCard, TextField6, TextField7, ShipVia, cmp_acc_man, cmp_note, cnt_id, 
                         TextField10, ExpiryDate, DefaultInvoiceForm, TaxSchedule, YesNofield1, YesNofield2, YesNofield3, YesNofield4, YesNofield5, datefield1, datefield2, datefield3, datefield4, datefield5, Comment1, debnr, crdnr, 
                         crdcode, debcode, numberfield1, numberfield2, numberfield3, numberfield5, numberfield4, TextField8, CreditCardHolder, CreditCardDescription, AllowBackOrders, AccountRating, StatementPrint, 
                         SecurityLevel
FROM            dbo.cicmpy where cmp_code = 'S753'
