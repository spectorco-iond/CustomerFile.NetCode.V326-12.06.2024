﻿Public Class cCustomer

    Public ID As Double = 0
    Public cmp_wwn As String = ""
    Public cmp_code As String = ""
    Public cnt_id As String = ""
    Public cmp_parent As String = ""
    Public cmp_name As String = ""
    Public cmp_fadd1 As String = ""
    Public cmp_fadd2 As String = ""
    Public cmp_fadd3 As String = ""
    Public cmp_fpc As String = ""
    Public cmp_fcity As String = ""
    Public cmp_fcounty As String = ""
    Public StateCode As String = ""
    Public cmp_fctry As String = ""
    Public cmp_CountryDesc As String = ""
    Public cmp_e_mail As String = ""
    Public cmp_web As String = ""
    Public cmp_fax As String = ""
    Public cmp_tel As String = ""
    Public sct_code As String = ""
    Public SubSector As String = ""
    Public siz_code As String = ""
    Public cmp_date_cust As Date
    Public cmp_note As String = ""
    Public cmp_acc_man As Integer = 0
    Public cmp_reseller As String = ""
    Public Administration As Double = 0
    Public cmp_type As String = ""
    Public cmp_status As String = ""
    Public DivisionDebtorID As String = ""
    Public DivisionCreditorID As String = ""
    Public datefield1 As Date
    Public datefield2 As Date
    Public datefield3 As Date
    Public datefield4 As Date
    Public datefield5 As Date
    Public numberfield1 As Double = 0
    Public numberfield2 As Double = 0
    Public numberfield3 As Double = 0
    Public numberfield4 As Double = 0
    Public numberfield5 As Double = 0
    Public YesNofield1 As Integer = 0
    Public YesNofield2 As Integer = 0
    Public YesNofield3 As Integer = 0
    Public YesNofield4 As Integer = 0
    Public YesNofield5 As Integer = 0
    Public textfield1 As String = ""
    Public textfield2 As String = ""
    Public textfield3 As String = ""
    Public textfield4 As String = ""
    Public textfield5 As String = ""
    Public cmp_rating As Integer = 0
    Public cmp_origin As String = ""
    Public Logo As Object
    Public LogoFileName As String = ""
    Public document_id As String = ""
    Public ClassificationId As String = ""
    Public type_since As Date
    Public status_since As Date
    Public WebAccessSince As Date
    Public ProcessedByBackgroundJob As Integer = 0
    Public debnr As String = ""
    Public crdnr As String = ""
    Public debcode As String = ""
    Public crdcode As String = ""
    Public ASPServer As String = ""
    Public ASPDatabase As String = ""
    Public ASPWebServer As String = ""
    Public ASPWebSite As String = ""
    Public syscreated As Date
    Public syscreator As Integer = 0
    Public sysmodified As Date
    Public sysmodifier As Integer = 0
    Public sysguid As String = ""
    Public timestamp As String = "" ' Timestamp field
    Public SearchCode As String = ""
    Public Telex As String = ""
    Public PostBankNumber As String = ""
    Public NoteID As Integer = 0
    Public Blocked As Integer = 0
    Public LayoutCode As String = ""
    Public BalanceDebit As Double = 0
    Public BalanceCredit As Double = 0
    Public SalesOrderAmount As Double = 0
    Public PageNumber As Integer = 0
    Public AmountOpen As Double = 0
    Public Factoring As Integer = 0
    Public ISOCountry As String = ""
    Public LiableToPayVAT As Integer = 0
    Public BackOrders As Integer = 0
    Public CostCenter As String = ""
    Public AddressNumber As String = ""
    Public DeliveryAddress As String = ""
    Public RouteCode As String = ""
    Public InvoiceDiscount As Double = 0
    Public PaymentConditionSearchCode As String = ""
    Public SearchCodeGoods As String = ""
    Public ExpenseCode As String = ""
    Public ICONumber As String = ""
    Public BankNumber2 As String = ""
    Public Area As String = ""
    Public InvoiceLayout As String = ""
    Public InvoiceName As String = ""
    Public Status As String = ""
    Public InvoiceThreshold As Double = 0
    Public Location As String = ""
    Public VATSource As String = ""
    Public CalculatePenaltyInterest As Integer = 0
    Public IntermediaryAssociate As String = ""
    Public SendPenaltyInvoices As Integer = 0
    Public CentralizationAccount As Double = 0
    Public Currency As String = ""
    Public BankAccountNumber As String = ""
    Public PaymentMethod As String = ""
    Public InvoiceDebtor As String = ""
    Public CreditLine As Double = 0
    Public Discount As Double = 0
    Public DateLastReminder As Date
    Public VatNumber As String = ""
    Public PurchaseReceipt As String = ""
    Public OffSetAccount As String = ""
    Public JournalCode As String = ""
    Public Reminder As Integer = 0
    Public PaymentCondition As String = ""
    Public PriceList As String = ""
    Public ItemCode As String = ""
    Public DeliveryMethod As String = ""
    Public CheckDate As String = ""
    Public StatFactor As String = ""
    Public VatCode As String = ""
    Public ChangeVatCode As Double = 0
    Public IntrastatSystem As String = ""
    Public ChangeIntraStatSystem As Integer = 0
    Public TransActionA As String = ""
    Public ChangeTransActionA As Integer = 0
    Public TransActionB As String = ""
    Public ChangeTransActionB As Integer = 0
    Public DestinationCountry As String = ""
    Public ChangeDestinationCountry As Integer = 0
    Public Transport As String = ""
    Public ChangeTransport As Integer = 0
    Public CityOfLoadUnload As String = ""
    Public ChangeCityOfLoadUnload As Integer = 0
    Public DeliveryTerms As String = ""
    Public ChangeDeliveryTerms As Integer = 0
    Public TransShipment As String = ""
    Public ChangeTransShipment As Integer = 0
    Public TriangularCountry As String = ""
    Public ChangeTriangularCountry As Integer = 0
    Public IntRegion As String = ""
    Public ChangeIntRegion As Integer = 0
    Public Collect As String = ""
    Public InvoiceCopies As Integer = 0
    Public PaymentDay1 As Integer = 0
    Public PaymentDay2 As Integer = 0
    Public PaymentDay3 As Integer = 0
    Public PaymentDay4 As Integer = 0
    Public PaymentDay5 As Integer = 0
    Public FiscalCode As String = ""
    Public CreditCard As String = ""
    Public ExpiryDate As Date
    Public TextField6 As String = ""
    Public TextField7 As String = ""
    Public TextField8 As String = ""
    Public TextField9 As String = ""
    Public TextField10 As String = ""
    Public AccountEmployeeId As Integer = 0
    Public CreditabilityScenario As String = ""
    Public VatLiability As String = ""
    Public Attention As Integer = 0
    Public Category As String = ""
    Public StatementAddress As String = ""
    Public StatementPrint As Integer = 0
    Public StatementNumber As Integer = 0
    Public StatementDate As Date
    Public DefaultSelCode As String = ""
    Public GroupPayments As String = ""
    Public BOELimitAmount As Double = 0
    Public BOEMaxAmount As Double = 0
    Public ExtraDuty As Integer = 0
    Public RegionCD As String = ""
    Public region As String = ""
    Public IntermediaryAssociateID As String = ""
    Public CompanyType As Integer = 0
    Public SalesPersonNumber As Integer = 0
    Public AccountTypeCode As String = ""
    Public StatementFrequency As String = ""
    Public AccountRating As String = ""
    Public FinanceCharge As Integer = 0
    Public ParentAccount As String = ""
    Public IsParentAccount As Integer = 0
    Public ShipVia As String = ""
    Public UPSZone As String = ""
    Public Terms As String = ""
    Public IsTaxable As Integer = 0
    Public TaxCode As String = ""
    Public TaxCode2 As String = ""
    Public TaxCode3 As String = ""
    Public ExemptNumber As String = ""
    Public AllowSubstituteItem As Integer = 0
    Public AllowBackOrders As Integer = 0
    Public AllowPartialShipment As Integer = 0
    Public DunningLetter As Integer = 0
    Public Comment1 As String = ""
    Public Comment2 As String = ""
    Public TaxSchedule As String = ""
    Public CreditCardDescription As String = ""
    Public CreditCardHolder As String = ""
    Public DefaultInvoiceForm As Integer = 0
    Public LocationShort As Double = 0
    Public TaxID As String = ""
    Public BillParent As Integer = 0
    Public Balance As Double = 0
    Public PhoneExtention As String = ""
    Public AutomaticPayment As Double = 0
    Public CustomerCode As String = ""
    Public PurchaseOrderAmount As Double = 0
    Public CountryOfOrigin As String = ""
    Public ChangeCountryOfOrigin As Integer = 0
    Public CountryOfAssembly As String = ""
    Public ChangeCountryOfAssembly As Integer = 0
    Public PurchaseOrderConfirmation As Integer = 0
    Public RecepientOfCommissions As Integer = 0
    Public CreditorType As String = ""
    Public PercentageToBePaid As Double = 0
    Public SignDate As Date
    Public ImportOriginCode As String = ""
    Public ParticipantNumber As String = ""
    Public CertifiedSupplier As Integer = 0
    Public FederalIDNumber As Integer = 0
    Public FederalIDType As String = ""
    Public FederalCategory As String = ""
    Public AutoDistribute As Integer = 0
    Public SupplierStatus As String = ""
    Public FOBCode As String = ""
    Public PrintPrice As Integer = 0
    Public Acknowledge As Integer = 0
    Public Confirmed As Integer = 0
    Public LandedCostCode As String = ""
    Public LandedCostCode2 As String = ""
    Public LandedCostCode3 As String = ""
    Public LandedCostCode4 As String = ""
    Public LandedCostCode5 As String = ""
    Public LandedCostCode6 As String = ""
    Public LandedCostCode7 As String = ""
    Public LandedCostCode8 As String = ""
    Public LandedCostCode9 As String = ""
    Public LandedCostCode10 As String = ""
    Public DefaultPOForm As Integer = 0
    Public PayeeName As String = ""
    Public CommodityCode1 As String = ""
    Public CommodityCode2 As String = ""
    Public CommodityCode3 As String = ""
    Public CommodityCode4 As String = ""
    Public CommodityCode5 As String = ""
    Public SecurityLevel As Integer = 0
    Public ChamberOfCommerce As String = ""
    Public DunsNumber As String = ""
    Public TextField11 As String = ""
    Public TextField12 As String = ""
    Public TextField13 As String = ""
    Public TextField14 As String = ""
    Public TextField15 As String = ""
    Public TextField16 As String = ""
    Public TextField17 As String = ""
    Public TextField18 As String = ""
    Public TextField19 As String = ""
    Public TextField20 As String = ""
    Public TextField21 As String = ""
    Public TextField22 As String = ""
    Public TextField23 As String = ""
    Public TextField24 As String = ""
    Public TextField25 As String = ""
    Public TextField26 As String = ""
    Public TextField27 As String = ""
    Public TextField28 As String = ""
    Public TextField29 As String = ""
    Public TextField30 As String = ""
    Public PhoneQueue As String = ""
    Public cmp_Directory As String = ""
    Public GUIDField1 As String = ""
    Public GUIDField2 As String = ""
    Public GUIDField3 As String = ""
    Public GUIDField4 As String = ""
    Public GUIDField5 As String = ""
    Public NumIntField1 As Integer = 0
    Public NumIntField2 As Integer = 0
    Public NumIntField3 As Integer = 0
    Public NumIntField4 As Integer = 0
    Public NumIntField5 As Integer = 0
    Public EncryptedCreditCard As Object ' Encrypted Varbinary field
    Public RuleItem As String = ""
    Public Substitute As Integer = 0
    Public Division As Integer = 0
    Public AutoAllocate As Integer = 0
    Public FedIDType As String = ""
    Public FedCategory As String = ""
    Public Category_01 As String = ""
    Public Category_02 As String = ""
    Public Category_03 As String = ""
    Public Category_04 As String = ""
    Public Category_05 As String = ""
    Public Category_06 As String = ""
    Public Category_07 As String = ""
    Public Category_08 As String = ""
    Public Category_09 As String = ""
    Public Category_10 As String = ""
    Public Category_11 As String = ""
    Public Category_12 As String = ""
    Public Category_13 As String = ""
    Public Category_14 As String = ""
    Public Category_15 As String = ""
    Public FedIDNumber As String = ""
    Public DefaultDeliveryAddress As String = ""

    Public Sub New()

    End Sub

    Public Sub New(ByVal pstrComp_Code As String)

        Call Load(pstrComp_Code)

    End Sub

    Public Sub Load(ByVal pstrCmp_Code As String)

        Dim db As New cDBA
        'Dim rsCustomer As New ADODB.Recordset
        Dim dtCustomer As DataTable

        Dim strSql As String

        Try
            'strSql = "" & _
            '"SELECT     TOP 1 CU.*, CN.FullName, CN.Cnt_F_Tel, CN.Cnt_F_Fax, CN.Cnt_Email, " & _
            '"           ISNULL(Tax1.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_1, " & _
            '"           ISNULL(Tax2.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_2, " & _
            '"           ISNULL(Tax3.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_3, " & _
            '"           CM.Cmp_Acc_Man, CM.Cmp_Code, CM.Cmp_FAdd1, CM.Cmp_FAdd2, " & _
            '"           CM.Cmp_FAdd3, CM.Cmp_FCity, CM.Cmp_FCounty, CM.Cmp_FCtry, " & _
            '"           CM.Cmp_FPC, CM.Cmp_Name, CM.Cmp_WWN, ISNULL(S.Slspsn_Name, '') AS Slspsn_Name, " & _
            '"           ClassificationID " & _
            '"FROM       ArCusFil_Sql CU   WITH (Nolock) " & _
            '"INNER JOIN CiCmpy       CM   WITH (Nolock) ON CU.Cus_No = CM.cmp_code " & _
            '"LEFT JOIN  CiCntp       CN   WITH (Nolock) ON CM.Cnt_ID = CN.Cnt_ID " & _
            '"LEFT JOIN 	TAXDETL_SQL  Tax1 WITH (Nolock) ON CU.Tax_Cd = Tax1.Tax_Cd " & _
            '"LEFT JOIN 	TAXDETL_SQL  Tax2 WITH (Nolock) ON CU.Tax_Cd_2 = Tax2.Tax_Cd " & _
            '"LEFT JOIN 	TAXDETL_SQL  Tax3 WITH (Nolock) ON CU.Tax_Cd_3 = Tax3.Tax_Cd " & _
            '"LEFT JOIN  ARSLMFIL_SQL S WITH (Nolock) ON CU.Slspsn_No = S.HumRes_ID " & _
            '"WHERE      RTRIM(ISNULL(CU.Cus_No, '')) = '" & RTrim(Cus_No) & "' " & _
            '"ORDER BY   CU.Cus_No ASC "

            strSql = "" &
            "SELECT     TOP 1 CM.*, CASE CM.IsTaxable WHEN 1 THEN 'Y' ELSE 'N' END AS 'IsCusTaxable', CN.FullName, CN.Cnt_F_Tel, CN.Cnt_F_Fax, CN.Cnt_Email, " &
            "           ISNULL(Tax1.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_1, " &
            "           ISNULL(Tax2.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_2, " &
            "           ISNULL(Tax3.Tax_Cd_Percent, 0) AS Tax_Cd_Percent_3, " &
            "           ISNULL(S.Slspsn_Name, '') AS Slspsn_Name, L.oms60_0 AS cmp_CountryDesc " &
            "FROM       CiCmpy       CM   WITH (Nolock) " &
            "LEFT JOIN  CiCmpy       B    WITH (Nolock) ON CM.InvoiceDebtor = b.debnr " &
            "LEFT JOIN  CiCntp       CN   WITH (Nolock) ON CM.Cnt_ID = CN.Cnt_ID and ISNULL(CN.active_y,0) = 1 " &
            "LEFT JOIN 	TAXDETL_SQL  Tax1 WITH (Nolock) ON CM.TaxCode = Tax1.Tax_Cd " &
            "LEFT JOIN 	TAXDETL_SQL  Tax2 WITH (Nolock) ON CM.TaxCode2 = Tax2.Tax_Cd " &
            "LEFT JOIN 	TAXDETL_SQL  Tax3 WITH (Nolock) ON CM.TaxCode3 = Tax3.Tax_Cd " &
            "LEFT JOIN  ARSLMFIL_SQL S WITH (Nolock) ON CM.SalesPersonNumber = S.HumRes_ID " &
            "LEFT JOIN  LAND L WITH (Nolock) ON CM.cmp_fctry = L.LandCode " &
            "WHERE  RTRIM(ISNULL(CM.Cmp_code, '')) = '" & RTrim(pstrCmp_Code) & "' " &
            "ORDER BY   CM.Cmp_code ASC "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            ' Verifier ceux qui ont des Cus_Alt_Adr_Cd
            dtCustomer = db.DataTable(strSql)
            'rsCustomer.Open(strSql, gConn.ConnectionString, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If dtCustomer.Rows.Count <> 0 Then
                'If rsCustomer.RecordCount <> 0 Then
                With dtCustomer.Rows(0)
                    If Not .Item("ID").Equals(DBNull.Value) Then ID = .Item("ID")
                    If Not .Item("cmp_wwn").Equals(DBNull.Value) Then cmp_wwn = .Item("cmp_wwn").ToString()
                    If Not .Item("cmp_code").Equals(DBNull.Value) Then cmp_code = .Item("cmp_code").ToString()
                    If Not .Item("cnt_id").Equals(DBNull.Value) Then cnt_id = .Item("cnt_id").ToString()
                    If Not .Item("cmp_parent").Equals(DBNull.Value) Then cmp_parent = .Item("cmp_parent").ToString()
                    If Not .Item("cmp_name").Equals(DBNull.Value) Then cmp_name = .Item("cmp_name").ToString()
                    If Not .Item("cmp_fadd1").Equals(DBNull.Value) Then cmp_fadd1 = .Item("cmp_fadd1").ToString()
                    If Not .Item("cmp_fadd2").Equals(DBNull.Value) Then cmp_fadd2 = .Item("cmp_fadd2").ToString()
                    If Not .Item("cmp_fadd3").Equals(DBNull.Value) Then cmp_fadd3 = .Item("cmp_fadd3").ToString()
                    If Not .Item("cmp_fpc").Equals(DBNull.Value) Then cmp_fpc = .Item("cmp_fpc").ToString()
                    If Not .Item("cmp_fcity").Equals(DBNull.Value) Then cmp_fcity = .Item("cmp_fcity").ToString()
                    If Not .Item("cmp_fcounty").Equals(DBNull.Value) Then cmp_fcounty = .Item("cmp_fcounty").ToString()
                    If Not .Item("StateCode").Equals(DBNull.Value) Then StateCode = .Item("StateCode").ToString()
                    If Not .Item("cmp_fctry").Equals(DBNull.Value) Then cmp_fctry = .Item("cmp_fctry").ToString()
                    If Not .Item("cmp_CountryDesc").Equals(DBNull.Value) Then cmp_CountryDesc = .Item("cmp_CountryDesc").ToString()
                    If Not .Item("cmp_e_mail").Equals(DBNull.Value) Then cmp_e_mail = .Item("cmp_e_mail").ToString()
                    If Not .Item("cmp_web").Equals(DBNull.Value) Then cmp_web = .Item("cmp_web").ToString()
                    If Not .Item("cmp_fax").Equals(DBNull.Value) Then cmp_fax = .Item("cmp_fax").ToString()
                    If Not .Item("cmp_tel").Equals(DBNull.Value) Then cmp_tel = .Item("cmp_tel").ToString()
                    If Not .Item("sct_code").Equals(DBNull.Value) Then sct_code = .Item("sct_code").ToString()
                    If Not .Item("SubSector").Equals(DBNull.Value) Then SubSector = .Item("SubSector").ToString()
                    If Not .Item("siz_code").Equals(DBNull.Value) Then siz_code = .Item("siz_code").ToString()
                    If Not .Item("cmp_date_cust").Equals(DBNull.Value) Then cmp_date_cust = .Item("cmp_date_cust")
                    If Not .Item("cmp_note").Equals(DBNull.Value) Then cmp_note = .Item("cmp_note").ToString()
                    If Not .Item("cmp_acc_man").Equals(DBNull.Value) Then cmp_acc_man = .Item("cmp_acc_man")
                    If Not .Item("cmp_reseller").Equals(DBNull.Value) Then cmp_reseller = .Item("cmp_reseller").ToString()
                    If Not .Item("Administration").Equals(DBNull.Value) Then Administration = .Item("Administration")
                    If Not .Item("cmp_type").Equals(DBNull.Value) Then cmp_type = .Item("cmp_type").ToString()
                    If Not .Item("cmp_status").Equals(DBNull.Value) Then cmp_status = .Item("cmp_status").ToString()
                    If Not .Item("DivisionDebtorID").Equals(DBNull.Value) Then DivisionDebtorID = .Item("DivisionDebtorID").ToString()
                    If Not .Item("DivisionCreditorID").Equals(DBNull.Value) Then DivisionCreditorID = .Item("DivisionCreditorID").ToString()
                    If Not .Item("datefield1").Equals(DBNull.Value) Then datefield1 = .Item("datefield1")
                    If Not .Item("datefield2").Equals(DBNull.Value) Then datefield2 = .Item("datefield2")
                    If Not .Item("datefield3").Equals(DBNull.Value) Then datefield3 = .Item("datefield3")
                    If Not .Item("datefield4").Equals(DBNull.Value) Then datefield4 = .Item("datefield4")
                    If Not .Item("datefield5").Equals(DBNull.Value) Then datefield5 = .Item("datefield5")
                    If Not .Item("numberfield1").Equals(DBNull.Value) Then numberfield1 = .Item("numberfield1")
                    If Not .Item("numberfield2").Equals(DBNull.Value) Then numberfield2 = .Item("numberfield2")
                    If Not .Item("numberfield3").Equals(DBNull.Value) Then numberfield3 = .Item("numberfield3")
                    If Not .Item("numberfield4").Equals(DBNull.Value) Then numberfield4 = .Item("numberfield4")
                    If Not .Item("numberfield5").Equals(DBNull.Value) Then numberfield5 = .Item("numberfield5")
                    If Not .Item("YesNofield1").Equals(DBNull.Value) Then YesNofield1 = .Item("YesNofield1")
                    If Not .Item("YesNofield2").Equals(DBNull.Value) Then YesNofield2 = .Item("YesNofield2")
                    If Not .Item("YesNofield3").Equals(DBNull.Value) Then YesNofield3 = .Item("YesNofield3")
                    If Not .Item("YesNofield4").Equals(DBNull.Value) Then YesNofield4 = .Item("YesNofield4")
                    If Not .Item("YesNofield5").Equals(DBNull.Value) Then YesNofield5 = .Item("YesNofield5")
                    If Not .Item("textfield1").Equals(DBNull.Value) Then textfield1 = .Item("textfield1").ToString()
                    If Not .Item("textfield2").Equals(DBNull.Value) Then textfield2 = .Item("textfield2").ToString()
                    If Not .Item("textfield3").Equals(DBNull.Value) Then textfield3 = .Item("textfield3").ToString()
                    If Not .Item("textfield4").Equals(DBNull.Value) Then textfield4 = .Item("textfield4").ToString()
                    If Not .Item("textfield5").Equals(DBNull.Value) Then textfield5 = .Item("textfield5").ToString()
                    If Not .Item("cmp_rating").Equals(DBNull.Value) Then cmp_rating = .Item("cmp_rating")
                    If Not .Item("cmp_origin").Equals(DBNull.Value) Then cmp_origin = .Item("cmp_origin").ToString()
                    'If Not .Item("'Logo").Equals(DBNull.Value) Then 'Logo = .ITEM("'Logo").TOSTRING()
                    If Not .Item("LogoFileName").Equals(DBNull.Value) Then LogoFileName = .Item("LogoFileName").ToString()
                    If Not .Item("document_id").Equals(DBNull.Value) Then document_id = .Item("document_id").ToString()
                    If Not .Item("ClassificationId").Equals(DBNull.Value) Then ClassificationId = .Item("ClassificationId").ToString()
                    If Not .Item("type_since").Equals(DBNull.Value) Then type_since = .Item("type_since")
                    If Not .Item("status_since").Equals(DBNull.Value) Then status_since = .Item("status_since")
                    If Not .Item("WebAccessSince").Equals(DBNull.Value) Then WebAccessSince = .Item("WebAccessSince")
                    If Not .Item("ProcessedByBackgroundJob").Equals(DBNull.Value) Then ProcessedByBackgroundJob = .Item("ProcessedByBackgroundJob")
                    If Not .Item("debnr").Equals(DBNull.Value) Then debnr = .Item("debnr").ToString()
                    If Not .Item("crdnr").Equals(DBNull.Value) Then crdnr = .Item("crdnr").ToString()
                    If Not .Item("debcode").Equals(DBNull.Value) Then debcode = .Item("debcode")
                    If Not .Item("crdcode").Equals(DBNull.Value) Then crdcode = .Item("crdcode").ToString()
                    If Not .Item("ASPServer").Equals(DBNull.Value) Then ASPServer = .Item("ASPServer").ToString()
                    If Not .Item("ASPDatabase").Equals(DBNull.Value) Then ASPDatabase = .Item("ASPDatabase").ToString()
                    If Not .Item("ASPWebServer").Equals(DBNull.Value) Then ASPWebServer = .Item("ASPWebServer").ToString()
                    If Not .Item("ASPWebSite").Equals(DBNull.Value) Then ASPWebSite = .Item("ASPWebSite").ToString()
                    If Not .Item("syscreated").Equals(DBNull.Value) Then syscreated = .Item("syscreated")
                    If Not .Item("syscreator").Equals(DBNull.Value) Then syscreator = .Item("syscreator")
                    If Not .Item("sysmodified").Equals(DBNull.Value) Then sysmodified = .Item("sysmodified")
                    If Not .Item("sysmodifier").Equals(DBNull.Value) Then sysmodifier = .Item("sysmodifier")
                    If Not .Item("sysguid").Equals(DBNull.Value) Then sysguid = .Item("sysguid").ToString()
                    If Not .Item("timestamp").Equals(DBNull.Value) Then timestamp = .Item("timestamp").ToString()
                    If Not .Item("SearchCode").Equals(DBNull.Value) Then SearchCode = .Item("SearchCode").ToString()
                    If Not .Item("Telex").Equals(DBNull.Value) Then Telex = .Item("Telex").ToString()
                    If Not .Item("PostBankNumber").Equals(DBNull.Value) Then PostBankNumber = .Item("PostBankNumber").ToString()
                    If Not .Item("NoteID").Equals(DBNull.Value) Then NoteID = .Item("NoteID")
                    If Not .Item("Blocked").Equals(DBNull.Value) Then Blocked = .Item("Blocked")
                    If Not .Item("LayoutCode").Equals(DBNull.Value) Then LayoutCode = .Item("LayoutCode").ToString()
                    If Not .Item("BalanceDebit").Equals(DBNull.Value) Then BalanceDebit = .Item("BalanceDebit")
                    If Not .Item("BalanceCredit").Equals(DBNull.Value) Then BalanceCredit = .Item("BalanceCredit")
                    If Not .Item("SalesOrderAmount").Equals(DBNull.Value) Then SalesOrderAmount = .Item("SalesOrderAmount")
                    If Not .Item("PageNumber").Equals(DBNull.Value) Then PageNumber = .Item("PageNumber")
                    If Not .Item("AmountOpen").Equals(DBNull.Value) Then AmountOpen = .Item("AmountOpen")
                    If Not .Item("Factoring").Equals(DBNull.Value) Then Factoring = .Item("Factoring")
                    If Not .Item("ISOCountry").Equals(DBNull.Value) Then ISOCountry = .Item("ISOCountry").ToString()
                    If Not .Item("LiableToPayVAT").Equals(DBNull.Value) Then LiableToPayVAT = .Item("LiableToPayVAT")
                    If Not .Item("BackOrders").Equals(DBNull.Value) Then BackOrders = .Item("BackOrders")
                    If Not .Item("CostCenter").Equals(DBNull.Value) Then CostCenter = .Item("CostCenter").ToString()
                    If Not .Item("AddressNumber").Equals(DBNull.Value) Then AddressNumber = .Item("AddressNumber").ToString()
                    If Not .Item("DeliveryAddress").Equals(DBNull.Value) Then DeliveryAddress = .Item("DeliveryAddress").ToString()
                    If Not .Item("RouteCode").Equals(DBNull.Value) Then RouteCode = .Item("RouteCode").ToString()
                    If Not .Item("InvoiceDiscount").Equals(DBNull.Value) Then InvoiceDiscount = .Item("InvoiceDiscount")
                    If Not .Item("PaymentConditionSearchCode").Equals(DBNull.Value) Then PaymentConditionSearchCode = .Item("PaymentConditionSearchCode").ToString()
                    If Not .Item("SearchCodeGoods").Equals(DBNull.Value) Then SearchCodeGoods = .Item("SearchCodeGoods").ToString()
                    If Not .Item("ExpenseCode").Equals(DBNull.Value) Then ExpenseCode = .Item("ExpenseCode").ToString()
                    If Not .Item("ICONumber").Equals(DBNull.Value) Then ICONumber = .Item("ICONumber").ToString()
                    If Not .Item("BankNumber2").Equals(DBNull.Value) Then BankNumber2 = .Item("BankNumber2").ToString()
                    If Not .Item("Area").Equals(DBNull.Value) Then Area = .Item("Area").ToString()
                    If Not .Item("InvoiceLayout").Equals(DBNull.Value) Then InvoiceLayout = .Item("InvoiceLayout").ToString()
                    If Not .Item("InvoiceName").Equals(DBNull.Value) Then InvoiceName = .Item("InvoiceName").ToString()
                    If Not .Item("Status").Equals(DBNull.Value) Then Status = .Item("Status").ToString()
                    If Not .Item("InvoiceThreshold").Equals(DBNull.Value) Then InvoiceThreshold = .Item("InvoiceThreshold")
                    If Not .Item("Location").Equals(DBNull.Value) Then Location = .Item("Location").ToString()
                    If Not .Item("VATSource").Equals(DBNull.Value) Then VATSource = .Item("VATSource").ToString()
                    If Not .Item("CalculatePenaltyInterest").Equals(DBNull.Value) Then CalculatePenaltyInterest = .Item("CalculatePenaltyInterest")
                    If Not .Item("IntermediaryAssociate").Equals(DBNull.Value) Then IntermediaryAssociate = .Item("IntermediaryAssociate").ToString()
                    If Not .Item("SendPenaltyInvoices").Equals(DBNull.Value) Then SendPenaltyInvoices = .Item("SendPenaltyInvoices")
                    If Not .Item("CentralizationAccount").Equals(DBNull.Value) Then CentralizationAccount = .Item("CentralizationAccount")
                    If Not .Item("Currency").Equals(DBNull.Value) Then Currency = .Item("Currency").ToString()
                    If Not .Item("BankAccountNumber").Equals(DBNull.Value) Then BankAccountNumber = .Item("BankAccountNumber").ToString()
                    If Not .Item("PaymentMethod").Equals(DBNull.Value) Then PaymentMethod = .Item("PaymentMethod").ToString()
                    If Not .Item("InvoiceDebtor").Equals(DBNull.Value) Then InvoiceDebtor = .Item("InvoiceDebtor").ToString()
                    If Not .Item("CreditLine").Equals(DBNull.Value) Then CreditLine = .Item("CreditLine")
                    If Not .Item("Discount").Equals(DBNull.Value) Then Discount = .Item("Discount")
                    If Not .Item("DateLastReminder").Equals(DBNull.Value) Then DateLastReminder = .Item("DateLastReminder")
                    If Not .Item("VatNumber").Equals(DBNull.Value) Then VatNumber = .Item("VatNumber").ToString()
                    If Not .Item("PurchaseReceipt").Equals(DBNull.Value) Then PurchaseReceipt = .Item("PurchaseReceipt").ToString()
                    If Not .Item("OffSetAccount").Equals(DBNull.Value) Then OffSetAccount = .Item("OffSetAccount").ToString()
                    If Not .Item("JournalCode").Equals(DBNull.Value) Then JournalCode = .Item("JournalCode").ToString()
                    If Not .Item("Reminder").Equals(DBNull.Value) Then Reminder = .Item("Reminder")
                    If Not .Item("PaymentCondition").Equals(DBNull.Value) Then PaymentCondition = .Item("PaymentCondition").ToString()
                    If Not .Item("PriceList").Equals(DBNull.Value) Then PriceList = .Item("PriceList").ToString()
                    If Not .Item("ItemCode").Equals(DBNull.Value) Then ItemCode = .Item("ItemCode").ToString()
                    If Not .Item("DeliveryMethod").Equals(DBNull.Value) Then DeliveryMethod = .Item("DeliveryMethod").ToString()
                    If Not .Item("CheckDate").Equals(DBNull.Value) Then CheckDate = .Item("CheckDate").ToString()
                    If Not .Item("StatFactor").Equals(DBNull.Value) Then StatFactor = .Item("StatFactor").ToString()
                    If Not .Item("VatCode").Equals(DBNull.Value) Then VatCode = .Item("VatCode").ToString()
                    If Not .Item("ChangeVatCode").Equals(DBNull.Value) Then ChangeVatCode = .Item("ChangeVatCode")
                    If Not .Item("IntrastatSystem").Equals(DBNull.Value) Then IntrastatSystem = .Item("IntrastatSystem").ToString()
                    If Not .Item("ChangeIntraStatSystem").Equals(DBNull.Value) Then ChangeIntraStatSystem = .Item("ChangeIntraStatSystem")
                    If Not .Item("TransActionA").Equals(DBNull.Value) Then TransActionA = .Item("TransActionA").ToString()
                    If Not .Item("ChangeTransActionA").Equals(DBNull.Value) Then ChangeTransActionA = .Item("ChangeTransActionA")
                    If Not .Item("TransActionB").Equals(DBNull.Value) Then TransActionB = .Item("TransActionB").ToString()
                    If Not .Item("ChangeTransActionB").Equals(DBNull.Value) Then ChangeTransActionB = .Item("ChangeTransActionB")
                    If Not .Item("DestinationCountry").Equals(DBNull.Value) Then DestinationCountry = .Item("DestinationCountry").ToString()
                    If Not .Item("ChangeDestinationCountry").Equals(DBNull.Value) Then ChangeDestinationCountry = .Item("ChangeDestinationCountry")
                    If Not .Item("Transport").Equals(DBNull.Value) Then Transport = .Item("Transport").ToString()
                    If Not .Item("ChangeTransport").Equals(DBNull.Value) Then ChangeTransport = .Item("ChangeTransport")
                    If Not .Item("CityOfLoadUnload").Equals(DBNull.Value) Then CityOfLoadUnload = .Item("CityOfLoadUnload").ToString()
                    If Not .Item("ChangeCityOfLoadUnload").Equals(DBNull.Value) Then ChangeCityOfLoadUnload = .Item("ChangeCityOfLoadUnload")
                    If Not .Item("DeliveryTerms").Equals(DBNull.Value) Then DeliveryTerms = .Item("DeliveryTerms").ToString()
                    If Not .Item("ChangeDeliveryTerms").Equals(DBNull.Value) Then ChangeDeliveryTerms = .Item("ChangeDeliveryTerms")
                    If Not .Item("TransShipment").Equals(DBNull.Value) Then TransShipment = .Item("TransShipment").ToString()
                    If Not .Item("ChangeTransShipment").Equals(DBNull.Value) Then ChangeTransShipment = .Item("ChangeTransShipment")
                    If Not .Item("TriangularCountry").Equals(DBNull.Value) Then TriangularCountry = .Item("TriangularCountry").ToString()
                    If Not .Item("ChangeTriangularCountry").Equals(DBNull.Value) Then ChangeTriangularCountry = .Item("ChangeTriangularCountry")
                    If Not .Item("IntRegion").Equals(DBNull.Value) Then IntRegion = .Item("IntRegion").ToString()
                    If Not .Item("ChangeIntRegion").Equals(DBNull.Value) Then ChangeIntRegion = .Item("ChangeIntRegion")
                    If Not .Item("Collect").Equals(DBNull.Value) Then Collect = .Item("Collect").ToString()
                    If Not .Item("InvoiceCopies").Equals(DBNull.Value) Then InvoiceCopies = .Item("InvoiceCopies")
                    If Not .Item("PaymentDay1").Equals(DBNull.Value) Then PaymentDay1 = .Item("PaymentDay1")
                    If Not .Item("PaymentDay2").Equals(DBNull.Value) Then PaymentDay2 = .Item("PaymentDay2")
                    If Not .Item("PaymentDay3").Equals(DBNull.Value) Then PaymentDay3 = .Item("PaymentDay3")
                    If Not .Item("PaymentDay4").Equals(DBNull.Value) Then PaymentDay4 = .Item("PaymentDay4")
                    If Not .Item("PaymentDay5").Equals(DBNull.Value) Then PaymentDay5 = .Item("PaymentDay5")
                    If Not .Item("FiscalCode").Equals(DBNull.Value) Then FiscalCode = .Item("FiscalCode").ToString()
                    If Not .Item("CreditCard").Equals(DBNull.Value) Then CreditCard = .Item("CreditCard").ToString()
                    If Not .Item("ExpiryDate").Equals(DBNull.Value) Then ExpiryDate = .Item("ExpiryDate")
                    If Not .Item("TextField6").Equals(DBNull.Value) Then TextField6 = .Item("TextField6").ToString()
                    If Not .Item("TextField7").Equals(DBNull.Value) Then TextField7 = .Item("TextField7").ToString()
                    If Not .Item("TextField8").Equals(DBNull.Value) Then TextField8 = .Item("TextField8").ToString()
                    If Not .Item("TextField9").Equals(DBNull.Value) Then TextField9 = .Item("TextField9").ToString()
                    If Not .Item("TextField10").Equals(DBNull.Value) Then TextField10 = .Item("TextField10").ToString()
                    If Not .Item("AccountEmployeeId").Equals(DBNull.Value) Then AccountEmployeeId = .Item("AccountEmployeeId")
                    If Not .Item("CreditabilityScenario").Equals(DBNull.Value) Then CreditabilityScenario = .Item("CreditabilityScenario").ToString()
                    If Not .Item("VatLiability").Equals(DBNull.Value) Then VatLiability = .Item("VatLiability").ToString()
                    If Not .Item("Attention").Equals(DBNull.Value) Then Attention = .Item("Attention")
                    If Not .Item("Category").Equals(DBNull.Value) Then Category = .Item("Category").ToString()
                    If Not .Item("StatementAddress").Equals(DBNull.Value) Then StatementAddress = .Item("StatementAddress").ToString()
                    If Not .Item("StatementPrint").Equals(DBNull.Value) Then StatementPrint = .Item("StatementPrint")
                    If Not .Item("StatementNumber").Equals(DBNull.Value) Then StatementNumber = .Item("StatementNumber")
                    If Not .Item("StatementDate").Equals(DBNull.Value) Then StatementDate = .Item("StatementDate")
                    If Not .Item("DefaultSelCode").Equals(DBNull.Value) Then DefaultSelCode = .Item("DefaultSelCode").ToString()
                    If Not .Item("GroupPayments").Equals(DBNull.Value) Then GroupPayments = .Item("GroupPayments").ToString()
                    If Not .Item("BOELimitAmount").Equals(DBNull.Value) Then BOELimitAmount = .Item("BOELimitAmount")
                    If Not .Item("BOEMaxAmount").Equals(DBNull.Value) Then BOEMaxAmount = .Item("BOEMaxAmount")
                    If Not .Item("ExtraDuty").Equals(DBNull.Value) Then ExtraDuty = .Item("ExtraDuty")
                    If Not .Item("RegionCD").Equals(DBNull.Value) Then RegionCD = .Item("RegionCD").ToString()
                    If Not .Item("region").Equals(DBNull.Value) Then region = .Item("region").ToString()
                    If Not .Item("IntermediaryAssociateID").Equals(DBNull.Value) Then IntermediaryAssociateID = .Item("IntermediaryAssociateID").ToString()
                    If Not .Item("CompanyType").Equals(DBNull.Value) Then CompanyType = .Item("CompanyType")
                    If Not .Item("SalesPersonNumber").Equals(DBNull.Value) Then SalesPersonNumber = .Item("SalesPersonNumber")
                    If Not .Item("AccountTypeCode").Equals(DBNull.Value) Then AccountTypeCode = .Item("AccountTypeCode").ToString()
                    If Not .Item("StatementFrequency").Equals(DBNull.Value) Then StatementFrequency = .Item("StatementFrequency").ToString()
                    If Not .Item("AccountRating").Equals(DBNull.Value) Then AccountRating = .Item("AccountRating").ToString()
                    If Not .Item("FinanceCharge").Equals(DBNull.Value) Then FinanceCharge = .Item("FinanceCharge")
                    If Not .Item("ParentAccount").Equals(DBNull.Value) Then ParentAccount = .Item("ParentAccount").ToString()
                    If Not .Item("IsParentAccount").Equals(DBNull.Value) Then IsParentAccount = .Item("IsParentAccount")
                    If Not .Item("ShipVia").Equals(DBNull.Value) Then ShipVia = .Item("ShipVia").ToString()
                    If Not .Item("UPSZone").Equals(DBNull.Value) Then UPSZone = .Item("UPSZone").ToString()
                    If Not .Item("Terms").Equals(DBNull.Value) Then Terms = .Item("Terms").ToString()
                    If Not .Item("IsTaxable").Equals(DBNull.Value) Then IsTaxable = .Item("IsTaxable")
                    'If Not .Item("'IsTaxable").Equals(DBNull.Value) Then 'IsTaxable = .ITEM("'IsTaxable")
                    If Not .Item("TaxCode").Equals(DBNull.Value) Then TaxCode = .Item("TaxCode").ToString()
                    If Not .Item("TaxCode2").Equals(DBNull.Value) Then TaxCode2 = .Item("TaxCode2").ToString()
                    If Not .Item("TaxCode3").Equals(DBNull.Value) Then TaxCode3 = .Item("TaxCode3").ToString()
                    If Not .Item("ExemptNumber").Equals(DBNull.Value) Then ExemptNumber = .Item("ExemptNumber").ToString()
                    If Not .Item("AllowSubstituteItem").Equals(DBNull.Value) Then AllowSubstituteItem = .Item("AllowSubstituteItem")
                    If Not .Item("AllowBackOrders").Equals(DBNull.Value) Then AllowBackOrders = .Item("AllowBackOrders")
                    If Not .Item("AllowPartialShipment").Equals(DBNull.Value) Then AllowPartialShipment = .Item("AllowPartialShipment")
                    If Not .Item("DunningLetter").Equals(DBNull.Value) Then DunningLetter = .Item("DunningLetter")
                    If Not .Item("Comment1").Equals(DBNull.Value) Then Comment1 = .Item("Comment1").ToString()
                    If Not .Item("Comment2").Equals(DBNull.Value) Then Comment2 = .Item("Comment2").ToString()
                    If Not .Item("TaxSchedule").Equals(DBNull.Value) Then TaxSchedule = .Item("TaxSchedule").ToString()
                    If Not .Item("CreditCardDescription").Equals(DBNull.Value) Then CreditCardDescription = .Item("CreditCardDescription").ToString()
                    If Not .Item("CreditCardHolder").Equals(DBNull.Value) Then CreditCardHolder = .Item("CreditCardHolder").ToString()
                    If Not .Item("DefaultInvoiceForm").Equals(DBNull.Value) Then DefaultInvoiceForm = .Item("DefaultInvoiceForm")
                    If Not .Item("LocationShort").Equals(DBNull.Value) Then LocationShort = .Item("LocationShort")
                    If Not .Item("TaxID").Equals(DBNull.Value) Then TaxID = .Item("TaxID").ToString()
                    If Not .Item("BillParent").Equals(DBNull.Value) Then BillParent = .Item("BillParent")
                    If Not .Item("Balance").Equals(DBNull.Value) Then Balance = .Item("Balance")
                    If Not .Item("PhoneExtention").Equals(DBNull.Value) Then PhoneExtention = .Item("PhoneExtention").ToString()
                    If Not .Item("AutomaticPayment").Equals(DBNull.Value) Then AutomaticPayment = .Item("AutomaticPayment")
                    If Not .Item("CustomerCode").Equals(DBNull.Value) Then CustomerCode = .Item("CustomerCode").ToString()
                    If Not .Item("PurchaseOrderAmount").Equals(DBNull.Value) Then PurchaseOrderAmount = .Item("PurchaseOrderAmount")
                    If Not .Item("CountryOfOrigin").Equals(DBNull.Value) Then CountryOfOrigin = .Item("CountryOfOrigin").ToString()
                    If Not .Item("ChangeCountryOfOrigin").Equals(DBNull.Value) Then ChangeCountryOfOrigin = .Item("ChangeCountryOfOrigin")
                    If Not .Item("CountryOfAssembly").Equals(DBNull.Value) Then CountryOfAssembly = .Item("CountryOfAssembly").ToString()
                    If Not .Item("ChangeCountryOfAssembly").Equals(DBNull.Value) Then ChangeCountryOfAssembly = .Item("ChangeCountryOfAssembly")
                    If Not .Item("PurchaseOrderConfirmation").Equals(DBNull.Value) Then PurchaseOrderConfirmation = .Item("PurchaseOrderConfirmation")
                    If Not .Item("RecepientOfCommissions").Equals(DBNull.Value) Then RecepientOfCommissions = .Item("RecepientOfCommissions")
                    If Not .Item("CreditorType").Equals(DBNull.Value) Then CreditorType = .Item("CreditorType").ToString()
                    If Not .Item("PercentageToBePaid").Equals(DBNull.Value) Then PercentageToBePaid = .Item("PercentageToBePaid")
                    If Not .Item("SignDate").Equals(DBNull.Value) Then SignDate = .Item("SignDate")
                    If Not .Item("ImportOriginCode").Equals(DBNull.Value) Then ImportOriginCode = .Item("ImportOriginCode").ToString()
                    If Not .Item("ParticipantNumber").Equals(DBNull.Value) Then ParticipantNumber = .Item("ParticipantNumber").ToString()
                    If Not .Item("CertifiedSupplier").Equals(DBNull.Value) Then CertifiedSupplier = .Item("CertifiedSupplier")
                    If Not .Item("FederalIDNumber").Equals(DBNull.Value) Then FederalIDNumber = .Item("FederalIDNumber")
                    If Not .Item("FederalIDType").Equals(DBNull.Value) Then FederalIDType = .Item("FederalIDType").ToString()
                    If Not .Item("FederalCategory").Equals(DBNull.Value) Then FederalCategory = .Item("FederalCategory").ToString()
                    If Not .Item("AutoDistribute").Equals(DBNull.Value) Then AutoDistribute = .Item("AutoDistribute")
                    If Not .Item("SupplierStatus").Equals(DBNull.Value) Then SupplierStatus = .Item("SupplierStatus").ToString()
                    If Not .Item("FOBCode").Equals(DBNull.Value) Then FOBCode = .Item("FOBCode").ToString()
                    If Not .Item("PrintPrice").Equals(DBNull.Value) Then PrintPrice = .Item("PrintPrice")
                    If Not .Item("Acknowledge").Equals(DBNull.Value) Then Acknowledge = .Item("Acknowledge")
                    If Not .Item("Confirmed").Equals(DBNull.Value) Then Confirmed = .Item("Confirmed")
                    If Not .Item("LandedCostCode").Equals(DBNull.Value) Then LandedCostCode = .Item("LandedCostCode").ToString()
                    If Not .Item("LandedCostCode2").Equals(DBNull.Value) Then LandedCostCode2 = .Item("LandedCostCode2").ToString()
                    If Not .Item("LandedCostCode3").Equals(DBNull.Value) Then LandedCostCode3 = .Item("LandedCostCode3").ToString()
                    If Not .Item("LandedCostCode4").Equals(DBNull.Value) Then LandedCostCode4 = .Item("LandedCostCode4").ToString()
                    If Not .Item("LandedCostCode5").Equals(DBNull.Value) Then LandedCostCode5 = .Item("LandedCostCode5").ToString()
                    If Not .Item("LandedCostCode6").Equals(DBNull.Value) Then LandedCostCode6 = .Item("LandedCostCode6").ToString()
                    If Not .Item("LandedCostCode7").Equals(DBNull.Value) Then LandedCostCode7 = .Item("LandedCostCode7").ToString()
                    If Not .Item("LandedCostCode8").Equals(DBNull.Value) Then LandedCostCode8 = .Item("LandedCostCode8").ToString()
                    If Not .Item("LandedCostCode9").Equals(DBNull.Value) Then LandedCostCode9 = .Item("LandedCostCode9").ToString()
                    If Not .Item("LandedCostCode10").Equals(DBNull.Value) Then LandedCostCode10 = .Item("LandedCostCode10").ToString()
                    If Not .Item("DefaultPOForm").Equals(DBNull.Value) Then DefaultPOForm = .Item("DefaultPOForm")
                    If Not .Item("PayeeName").Equals(DBNull.Value) Then PayeeName = .Item("PayeeName").ToString()
                    If Not .Item("CommodityCode1").Equals(DBNull.Value) Then CommodityCode1 = .Item("CommodityCode1").ToString()
                    If Not .Item("CommodityCode2").Equals(DBNull.Value) Then CommodityCode2 = .Item("CommodityCode2").ToString()
                    If Not .Item("CommodityCode3").Equals(DBNull.Value) Then CommodityCode3 = .Item("CommodityCode3").ToString()
                    If Not .Item("CommodityCode4").Equals(DBNull.Value) Then CommodityCode4 = .Item("CommodityCode4").ToString()
                    If Not .Item("CommodityCode5").Equals(DBNull.Value) Then CommodityCode5 = .Item("CommodityCode5").ToString()
                    If Not .Item("SecurityLevel").Equals(DBNull.Value) Then SecurityLevel = .Item("SecurityLevel")
                    If Not .Item("ChamberOfCommerce").Equals(DBNull.Value) Then ChamberOfCommerce = .Item("ChamberOfCommerce").ToString()
                    If Not .Item("DunsNumber").Equals(DBNull.Value) Then DunsNumber = .Item("DunsNumber").ToString()
                    If Not .Item("TextField11").Equals(DBNull.Value) Then TextField11 = .Item("TextField11").ToString()
                    If Not .Item("TextField12").Equals(DBNull.Value) Then TextField12 = .Item("TextField12").ToString()
                    If Not .Item("TextField13").Equals(DBNull.Value) Then TextField13 = .Item("TextField13").ToString()
                    If Not .Item("TextField14").Equals(DBNull.Value) Then TextField14 = .Item("TextField14").ToString()
                    If Not .Item("TextField15").Equals(DBNull.Value) Then TextField15 = .Item("TextField15").ToString()
                    If Not .Item("TextField16").Equals(DBNull.Value) Then TextField16 = .Item("TextField16").ToString()
                    If Not .Item("TextField17").Equals(DBNull.Value) Then TextField17 = .Item("TextField17").ToString()
                    If Not .Item("TextField18").Equals(DBNull.Value) Then TextField18 = .Item("TextField18").ToString()
                    If Not .Item("TextField19").Equals(DBNull.Value) Then TextField19 = .Item("TextField19").ToString()
                    If Not .Item("TextField20").Equals(DBNull.Value) Then TextField20 = .Item("TextField20").ToString()
                    If Not .Item("TextField21").Equals(DBNull.Value) Then TextField21 = .Item("TextField21").ToString()
                    If Not .Item("TextField22").Equals(DBNull.Value) Then TextField22 = .Item("TextField22").ToString()
                    If Not .Item("TextField23").Equals(DBNull.Value) Then TextField23 = .Item("TextField23").ToString()
                    If Not .Item("TextField24").Equals(DBNull.Value) Then TextField24 = .Item("TextField24").ToString()
                    If Not .Item("TextField25").Equals(DBNull.Value) Then TextField25 = .Item("TextField25").ToString()
                    If Not .Item("TextField26").Equals(DBNull.Value) Then TextField26 = .Item("TextField26").ToString()
                    If Not .Item("TextField27").Equals(DBNull.Value) Then TextField27 = .Item("TextField27").ToString()
                    If Not .Item("TextField28").Equals(DBNull.Value) Then TextField28 = .Item("TextField28").ToString()
                    If Not .Item("TextField29").Equals(DBNull.Value) Then TextField29 = .Item("TextField29").ToString()
                    If Not .Item("TextField30").Equals(DBNull.Value) Then TextField30 = .Item("TextField30").ToString()
                    If Not .Item("PhoneQueue").Equals(DBNull.Value) Then PhoneQueue = .Item("PhoneQueue").ToString()
                    If Not .Item("cmp_Directory").Equals(DBNull.Value) Then cmp_Directory = .Item("cmp_Directory").ToString()
                    If Not .Item("GUIDField1").Equals(DBNull.Value) Then GUIDField1 = .Item("GUIDField1").ToString()
                    If Not .Item("GUIDField2").Equals(DBNull.Value) Then GUIDField2 = .Item("GUIDField2").ToString()
                    If Not .Item("GUIDField3").Equals(DBNull.Value) Then GUIDField3 = .Item("GUIDField3").ToString()
                    If Not .Item("GUIDField4").Equals(DBNull.Value) Then GUIDField4 = .Item("GUIDField4").ToString()
                    If Not .Item("GUIDField5").Equals(DBNull.Value) Then GUIDField5 = .Item("GUIDField5").ToString()
                    If Not .Item("NumIntField1").Equals(DBNull.Value) Then NumIntField1 = .Item("NumIntField1")
                    If Not .Item("NumIntField2").Equals(DBNull.Value) Then NumIntField2 = .Item("NumIntField2")
                    If Not .Item("NumIntField3").Equals(DBNull.Value) Then NumIntField3 = .Item("NumIntField3")
                    If Not .Item("NumIntField4").Equals(DBNull.Value) Then NumIntField4 = .Item("NumIntField4")
                    If Not .Item("NumIntField5").Equals(DBNull.Value) Then NumIntField5 = .Item("NumIntField5")
                    'If Not .Item("'EncryptedCreditCard").Equals(DBNull.Value) Then 'EncryptedCreditCard = .ITEM("'EncryptedCreditCard").TOSTRING()
                    If Not .Item("RuleItem").Equals(DBNull.Value) Then RuleItem = .Item("RuleItem").ToString()
                    If Not .Item("Substitute").Equals(DBNull.Value) Then Substitute = .Item("Substitute")
                    If Not .Item("Division").Equals(DBNull.Value) Then Division = .Item("Division")
                    If Not .Item("AutoAllocate").Equals(DBNull.Value) Then AutoAllocate = .Item("AutoAllocate")
                    If Not .Item("FedIDType").Equals(DBNull.Value) Then FedIDType = .Item("FedIDType").ToString()
                    If Not .Item("FedCategory").Equals(DBNull.Value) Then FedCategory = .Item("FedCategory").ToString()
                    If Not .Item("Category_01").Equals(DBNull.Value) Then Category_01 = .Item("Category_01").ToString()
                    If Not .Item("Category_02").Equals(DBNull.Value) Then Category_02 = .Item("Category_02").ToString()
                    If Not .Item("Category_03").Equals(DBNull.Value) Then Category_03 = .Item("Category_03").ToString()
                    If Not .Item("Category_04").Equals(DBNull.Value) Then Category_04 = .Item("Category_04").ToString()
                    If Not .Item("Category_05").Equals(DBNull.Value) Then Category_05 = .Item("Category_05").ToString()
                    If Not .Item("Category_06").Equals(DBNull.Value) Then Category_06 = .Item("Category_06").ToString()
                    If Not .Item("Category_07").Equals(DBNull.Value) Then Category_07 = .Item("Category_07").ToString()
                    If Not .Item("Category_08").Equals(DBNull.Value) Then Category_08 = .Item("Category_08").ToString()
                    If Not .Item("Category_09").Equals(DBNull.Value) Then Category_09 = .Item("Category_09").ToString()
                    If Not .Item("Category_10").Equals(DBNull.Value) Then Category_10 = .Item("Category_10").ToString()
                    If Not .Item("Category_11").Equals(DBNull.Value) Then Category_11 = .Item("Category_11").ToString()
                    If Not .Item("Category_12").Equals(DBNull.Value) Then Category_12 = .Item("Category_12").ToString()
                    If Not .Item("Category_13").Equals(DBNull.Value) Then Category_13 = .Item("Category_13").ToString()
                    If Not .Item("Category_14").Equals(DBNull.Value) Then Category_14 = .Item("Category_14").ToString()
                    If Not .Item("Category_15").Equals(DBNull.Value) Then Category_15 = .Item("Category_15").ToString()
                    If Not .Item("FedIDNumber").Equals(DBNull.Value) Then FedIDNumber = .Item("FedIDNumber").ToString()
                    If Not .Item("DefaultDeliveryAddress").Equals(DBNull.Value) Then DefaultDeliveryAddress = .Item("DefaultDeliveryAddress").ToString()

                End With
            End If

            'If 1 = 1 Then
            '    ID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ID").Value), 0, rsCustomer.Fields("ID").Value)
            '    cmp_wwn = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_wwn").Value), "", rsCustomer.Fields("cmp_wwn").Value)
            '    cmp_code = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_code").Value), "", rsCustomer.Fields("cmp_code").Value)
            '    cnt_id = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cnt_id").Value), "", rsCustomer.Fields("cnt_id").Value)
            '    cmp_parent = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_parent").Value), "", rsCustomer.Fields("cmp_parent").Value)
            '    cmp_name = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_name").Value), "", rsCustomer.Fields("cmp_name").Value)
            '    cmp_fadd1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fadd1").Value), "", rsCustomer.Fields("cmp_fadd1").Value)
            '    cmp_fadd2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fadd2").Value), "", rsCustomer.Fields("cmp_fadd2").Value)
            '    cmp_fadd3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fadd3").Value), "", rsCustomer.Fields("cmp_fadd3").Value)
            '    cmp_fpc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fpc").Value), "", rsCustomer.Fields("cmp_fpc").Value)
            '    cmp_fcity = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fcity").Value), "", rsCustomer.Fields("cmp_fcity").Value)
            '    cmp_fcounty = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fcounty").Value), "", rsCustomer.Fields("cmp_fcounty").Value)
            '    StateCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StateCode").Value), "", rsCustomer.Fields("StateCode").Value)
            '    cmp_fctry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fctry").Value), "", rsCustomer.Fields("cmp_fctry").Value)
            '    cmp_e_mail = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_e_mail").Value), "", rsCustomer.Fields("cmp_e_mail").Value)
            '    cmp_web = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_web").Value), "", rsCustomer.Fields("cmp_web").Value)
            '    cmp_fax = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_fax").Value), "", rsCustomer.Fields("cmp_fax").Value)
            '    cmp_tel = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_tel").Value), "", rsCustomer.Fields("cmp_tel").Value)
            '    sct_code = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("sct_code").Value), "", rsCustomer.Fields("sct_code").Value)
            '    SubSector = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SubSector").Value), "", rsCustomer.Fields("SubSector").Value)
            '    siz_code = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("siz_code").Value), "", rsCustomer.Fields("siz_code").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("cmp_date_cust").Value)) Then cmp_date_cust = rsCustomer.Fields("cmp_date_cust").Value
            '    cmp_note = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_note").Value), "", rsCustomer.Fields("cmp_note").Value)
            '    cmp_acc_man = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_acc_man").Value), 0, rsCustomer.Fields("cmp_acc_man").Value)
            '    cmp_reseller = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_reseller").Value), "", rsCustomer.Fields("cmp_reseller").Value)
            '    Administration = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Administration").Value), 0, rsCustomer.Fields("Administration").Value)
            '    cmp_type = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_type").Value), "", rsCustomer.Fields("cmp_type").Value)
            '    cmp_status = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_status").Value), "", rsCustomer.Fields("cmp_status").Value)
            '    DivisionDebtorID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DivisionDebtorID").Value), "", rsCustomer.Fields("DivisionDebtorID").Value)
            '    DivisionCreditorID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DivisionCreditorID").Value), "", rsCustomer.Fields("DivisionCreditorID").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("datefield1").Value)) Then datefield1 = rsCustomer.Fields("datefield1").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("datefield2").Value)) Then datefield2 = rsCustomer.Fields("datefield2").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("datefield3").Value)) Then datefield3 = rsCustomer.Fields("datefield3").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("datefield4").Value)) Then datefield4 = rsCustomer.Fields("datefield4").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("datefield5").Value)) Then datefield5 = rsCustomer.Fields("datefield5").Value
            '    numberfield1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("numberfield1").Value), 0, rsCustomer.Fields("numberfield1").Value)
            '    numberfield2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("numberfield2").Value), 0, rsCustomer.Fields("numberfield2").Value)
            '    numberfield3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("numberfield3").Value), 0, rsCustomer.Fields("numberfield3").Value)
            '    numberfield4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("numberfield4").Value), 0, rsCustomer.Fields("numberfield4").Value)
            '    numberfield5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("numberfield5").Value), 0, rsCustomer.Fields("numberfield5").Value)
            '    YesNofield1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("YesNofield1").Value), 0, rsCustomer.Fields("YesNofield1").Value)
            '    YesNofield2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("YesNofield2").Value), 0, rsCustomer.Fields("YesNofield2").Value)
            '    YesNofield3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("YesNofield3").Value), 0, rsCustomer.Fields("YesNofield3").Value)
            '    YesNofield4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("YesNofield4").Value), 0, rsCustomer.Fields("YesNofield4").Value)
            '    YesNofield5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("YesNofield5").Value), 0, rsCustomer.Fields("YesNofield5").Value)
            '    textfield1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("textfield1").Value), "", rsCustomer.Fields("textfield1").Value)
            '    textfield2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("textfield2").Value), "", rsCustomer.Fields("textfield2").Value)
            '    textfield3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("textfield3").Value), "", rsCustomer.Fields("textfield3").Value)
            '    textfield4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("textfield4").Value), "", rsCustomer.Fields("textfield4").Value)
            '    textfield5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("textfield5").Value), "", rsCustomer.Fields("textfield5").Value)
            '    cmp_rating = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_rating").Value), 0, rsCustomer.Fields("cmp_rating").Value)
            '    cmp_origin = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_origin").Value), "", rsCustomer.Fields("cmp_origin").Value)
            '    'Logo = IIF(System.DBNull.Value.Equals(rsCustomer.Fields("Logo").Value), "", rsCustomer.Fields("Logo").Value)
            '    LogoFileName = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LogoFileName").Value), "", rsCustomer.Fields("LogoFileName").Value)
            '    document_id = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("document_id").Value), "", rsCustomer.Fields("document_id").Value)
            '    ClassificationId = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ClassificationId").Value), "", rsCustomer.Fields("ClassificationId").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("type_since").Value)) Then type_since = rsCustomer.Fields("type_since").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("status_since").Value)) Then status_since = rsCustomer.Fields("status_since").Value
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("WebAccessSince").Value)) Then WebAccessSince = rsCustomer.Fields("WebAccessSince").Value
            '    ProcessedByBackgroundJob = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ProcessedByBackgroundJob").Value), 0, rsCustomer.Fields("ProcessedByBackgroundJob").Value)
            '    debnr = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("debnr").Value), "", rsCustomer.Fields("debnr").Value)
            '    crdnr = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("crdnr").Value), "", rsCustomer.Fields("crdnr").Value)
            '    debcode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("debcode").Value), 0, rsCustomer.Fields("debcode").Value)
            '    crdcode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("crdcode").Value), "", rsCustomer.Fields("crdcode").Value)
            '    ASPServer = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ASPServer").Value), "", rsCustomer.Fields("ASPServer").Value)
            '    ASPDatabase = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ASPDatabase").Value), "", rsCustomer.Fields("ASPDatabase").Value)
            '    ASPWebServer = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ASPWebServer").Value), "", rsCustomer.Fields("ASPWebServer").Value)
            '    ASPWebSite = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ASPWebSite").Value), "", rsCustomer.Fields("ASPWebSite").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("syscreated").Value)) Then syscreated = rsCustomer.Fields("syscreated").Value
            '    syscreator = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("syscreator").Value), 0, rsCustomer.Fields("syscreator").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("sysmodified").Value)) Then sysmodified = rsCustomer.Fields("sysmodified").Value
            '    sysmodifier = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("sysmodifier").Value), 0, rsCustomer.Fields("sysmodifier").Value)
            '    sysguid = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("sysguid").Value), "", rsCustomer.Fields("sysguid").Value)
            '    timestamp = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("timestamp").Value), "", rsCustomer.Fields("timestamp").Value.ToString)
            '    SearchCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SearchCode").Value), "", rsCustomer.Fields("SearchCode").Value)
            '    Telex = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Telex").Value), "", rsCustomer.Fields("Telex").Value)
            '    PostBankNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PostBankNumber").Value), "", rsCustomer.Fields("PostBankNumber").Value)
            '    NoteID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NoteID").Value), 0, rsCustomer.Fields("NoteID").Value)
            '    Blocked = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Blocked").Value), 0, rsCustomer.Fields("Blocked").Value)
            '    LayoutCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LayoutCode").Value), "", rsCustomer.Fields("LayoutCode").Value)
            '    BalanceDebit = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BalanceDebit").Value), 0, rsCustomer.Fields("BalanceDebit").Value)
            '    BalanceCredit = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BalanceCredit").Value), 0, rsCustomer.Fields("BalanceCredit").Value)
            '    SalesOrderAmount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SalesOrderAmount").Value), 0, rsCustomer.Fields("SalesOrderAmount").Value)
            '    PageNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PageNumber").Value), 0, rsCustomer.Fields("PageNumber").Value)
            '    AmountOpen = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AmountOpen").Value), 0, rsCustomer.Fields("AmountOpen").Value)
            '    Factoring = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Factoring").Value), 0, rsCustomer.Fields("Factoring").Value)
            '    ISOCountry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ISOCountry").Value), "", rsCustomer.Fields("ISOCountry").Value)
            '    LiableToPayVAT = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LiableToPayVAT").Value), 0, rsCustomer.Fields("LiableToPayVAT").Value)
            '    BackOrders = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BackOrders").Value), 0, rsCustomer.Fields("BackOrders").Value)
            '    CostCenter = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CostCenter").Value), "", rsCustomer.Fields("CostCenter").Value)
            '    AddressNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AddressNumber").Value), "", rsCustomer.Fields("AddressNumber").Value)
            '    DeliveryAddress = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DeliveryAddress").Value), "", rsCustomer.Fields("DeliveryAddress").Value)
            '    RouteCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("RouteCode").Value), "", rsCustomer.Fields("RouteCode").Value)
            '    InvoiceDiscount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceDiscount").Value), 0, rsCustomer.Fields("InvoiceDiscount").Value)
            '    PaymentConditionSearchCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentConditionSearchCode").Value), "", rsCustomer.Fields("PaymentConditionSearchCode").Value)
            '    SearchCodeGoods = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SearchCodeGoods").Value), "", rsCustomer.Fields("SearchCodeGoods").Value)
            '    ExpenseCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ExpenseCode").Value), "", rsCustomer.Fields("ExpenseCode").Value)
            '    ICONumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ICONumber").Value), "", rsCustomer.Fields("ICONumber").Value)
            '    BankNumber2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BankNumber2").Value), "", rsCustomer.Fields("BankNumber2").Value)
            '    Area = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Area").Value), "", rsCustomer.Fields("Area").Value)
            '    InvoiceLayout = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceLayout").Value), "", rsCustomer.Fields("InvoiceLayout").Value)
            '    InvoiceName = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceName").Value), "", rsCustomer.Fields("InvoiceName").Value)
            '    Status = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Status").Value), "", rsCustomer.Fields("Status").Value)
            '    InvoiceThreshold = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceThreshold").Value), 0, rsCustomer.Fields("InvoiceThreshold").Value)
            '    Location = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Location").Value), "", rsCustomer.Fields("Location").Value)
            '    VATSource = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("VATSource").Value), "", rsCustomer.Fields("VATSource").Value)
            '    CalculatePenaltyInterest = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CalculatePenaltyInterest").Value), 0, rsCustomer.Fields("CalculatePenaltyInterest").Value)
            '    IntermediaryAssociate = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IntermediaryAssociate").Value), "", rsCustomer.Fields("IntermediaryAssociate").Value)
            '    SendPenaltyInvoices = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SendPenaltyInvoices").Value), 0, rsCustomer.Fields("SendPenaltyInvoices").Value)
            '    CentralizationAccount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CentralizationAccount").Value), 0, rsCustomer.Fields("CentralizationAccount").Value)
            '    Currency = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Currency").Value), "", rsCustomer.Fields("Currency").Value)
            '    BankAccountNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BankAccountNumber").Value), "", rsCustomer.Fields("BankAccountNumber").Value)
            '    PaymentMethod = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentMethod").Value), "", rsCustomer.Fields("PaymentMethod").Value)
            '    InvoiceDebtor = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceDebtor").Value), "", rsCustomer.Fields("InvoiceDebtor").Value)
            '    CreditLine = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditLine").Value), 0, rsCustomer.Fields("CreditLine").Value)
            '    Discount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Discount").Value), 0, rsCustomer.Fields("Discount").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("DateLastReminder").Value)) Then DateLastReminder = rsCustomer.Fields("DateLastReminder").Value
            '    VatNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("VatNumber").Value), "", rsCustomer.Fields("VatNumber").Value)
            '    PurchaseReceipt = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PurchaseReceipt").Value), "", rsCustomer.Fields("PurchaseReceipt").Value)
            '    OffSetAccount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("OffSetAccount").Value), "", rsCustomer.Fields("OffSetAccount").Value)
            '    JournalCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("JournalCode").Value), "", rsCustomer.Fields("JournalCode").Value)
            '    Reminder = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Reminder").Value), 0, rsCustomer.Fields("Reminder").Value)
            '    PaymentCondition = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentCondition").Value), "", rsCustomer.Fields("PaymentCondition").Value)
            '    PriceList = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PriceList").Value), "", rsCustomer.Fields("PriceList").Value)
            '    ItemCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ItemCode").Value), "", rsCustomer.Fields("ItemCode").Value)
            '    DeliveryMethod = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DeliveryMethod").Value), "", rsCustomer.Fields("DeliveryMethod").Value)
            '    CheckDate = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CheckDate").Value), "", rsCustomer.Fields("CheckDate").Value)
            '    StatFactor = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StatFactor").Value), "", rsCustomer.Fields("StatFactor").Value)
            '    VatCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("VatCode").Value), "", rsCustomer.Fields("VatCode").Value)
            '    ChangeVatCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeVatCode").Value), 0, rsCustomer.Fields("ChangeVatCode").Value)
            '    IntrastatSystem = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IntrastatSystem").Value), "", rsCustomer.Fields("IntrastatSystem").Value)
            '    ChangeIntraStatSystem = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeIntraStatSystem").Value), 0, rsCustomer.Fields("ChangeIntraStatSystem").Value)
            '    TransActionA = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TransActionA").Value), "", rsCustomer.Fields("TransActionA").Value)
            '    ChangeTransActionA = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeTransActionA").Value), 0, rsCustomer.Fields("ChangeTransActionA").Value)
            '    TransActionB = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TransActionB").Value), "", rsCustomer.Fields("TransActionB").Value)
            '    ChangeTransActionB = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeTransActionB").Value), 0, rsCustomer.Fields("ChangeTransActionB").Value)
            '    DestinationCountry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DestinationCountry").Value), "", rsCustomer.Fields("DestinationCountry").Value)
            '    ChangeDestinationCountry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeDestinationCountry").Value), 0, rsCustomer.Fields("ChangeDestinationCountry").Value)
            '    Transport = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Transport").Value), "", rsCustomer.Fields("Transport").Value)
            '    ChangeTransport = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeTransport").Value), 0, rsCustomer.Fields("ChangeTransport").Value)
            '    CityOfLoadUnload = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CityOfLoadUnload").Value), "", rsCustomer.Fields("CityOfLoadUnload").Value)
            '    ChangeCityOfLoadUnload = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeCityOfLoadUnload").Value), 0, rsCustomer.Fields("ChangeCityOfLoadUnload").Value)
            '    DeliveryTerms = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DeliveryTerms").Value), "", rsCustomer.Fields("DeliveryTerms").Value)
            '    ChangeDeliveryTerms = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeDeliveryTerms").Value), 0, rsCustomer.Fields("ChangeDeliveryTerms").Value)
            '    TransShipment = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TransShipment").Value), "", rsCustomer.Fields("TransShipment").Value)
            '    ChangeTransShipment = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeTransShipment").Value), 0, rsCustomer.Fields("ChangeTransShipment").Value)
            '    TriangularCountry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TriangularCountry").Value), "", rsCustomer.Fields("TriangularCountry").Value)
            '    ChangeTriangularCountry = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeTriangularCountry").Value), 0, rsCustomer.Fields("ChangeTriangularCountry").Value)
            '    IntRegion = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IntRegion").Value), "", rsCustomer.Fields("IntRegion").Value)
            '    ChangeIntRegion = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeIntRegion").Value), 0, rsCustomer.Fields("ChangeIntRegion").Value)
            '    Collect = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Collect").Value), "", rsCustomer.Fields("Collect").Value)
            '    InvoiceCopies = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceCopies").Value), 0, rsCustomer.Fields("InvoiceCopies").Value)
            '    PaymentDay1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentDay1").Value), 0, rsCustomer.Fields("PaymentDay1").Value)
            '    PaymentDay2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentDay2").Value), 0, rsCustomer.Fields("PaymentDay2").Value)
            '    PaymentDay3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentDay3").Value), 0, rsCustomer.Fields("PaymentDay3").Value)
            '    PaymentDay4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentDay4").Value), 0, rsCustomer.Fields("PaymentDay4").Value)
            '    PaymentDay5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentDay5").Value), 0, rsCustomer.Fields("PaymentDay5").Value)
            '    FiscalCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FiscalCode").Value), "", rsCustomer.Fields("FiscalCode").Value)
            '    CreditCard = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditCard").Value), "", rsCustomer.Fields("CreditCard").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("ExpiryDate").Value)) Then ExpiryDate = rsCustomer.Fields("ExpiryDate").Value
            '    TextField6 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField6").Value), "", rsCustomer.Fields("TextField6").Value)
            '    TextField7 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField7").Value), "", rsCustomer.Fields("TextField7").Value)
            '    TextField8 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField8").Value), "", rsCustomer.Fields("TextField8").Value)
            '    TextField9 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField9").Value), "", rsCustomer.Fields("TextField9").Value)
            '    TextField10 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField10").Value), "", rsCustomer.Fields("TextField10").Value)
            '    AccountEmployeeId = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AccountEmployeeId").Value), 0, rsCustomer.Fields("AccountEmployeeId").Value)
            '    CreditabilityScenario = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditabilityScenario").Value), "", rsCustomer.Fields("CreditabilityScenario").Value)
            '    VatLiability = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("VatLiability").Value), "", rsCustomer.Fields("VatLiability").Value)
            '    Attention = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Attention").Value), 0, rsCustomer.Fields("Attention").Value)
            '    Category = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category").Value), "", rsCustomer.Fields("Category").Value)
            '    StatementAddress = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StatementAddress").Value), "", rsCustomer.Fields("StatementAddress").Value)
            '    StatementPrint = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StatementPrint").Value), 0, rsCustomer.Fields("StatementPrint").Value)
            '    StatementNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StatementNumber").Value), 0, rsCustomer.Fields("StatementNumber").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("StatementDate").Value)) Then StatementDate = rsCustomer.Fields("StatementDate").Value
            '    DefaultSelCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DefaultSelCode").Value), "", rsCustomer.Fields("DefaultSelCode").Value)
            '    GroupPayments = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GroupPayments").Value), "", rsCustomer.Fields("GroupPayments").Value)
            '    BOELimitAmount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BOELimitAmount").Value), 0, rsCustomer.Fields("BOELimitAmount").Value)
            '    BOEMaxAmount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BOEMaxAmount").Value), 0, rsCustomer.Fields("BOEMaxAmount").Value)
            '    ExtraDuty = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ExtraDuty").Value), 0, rsCustomer.Fields("ExtraDuty").Value)
            '    RegionCD = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("RegionCD").Value), "", rsCustomer.Fields("RegionCD").Value)
            '    region = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("region").Value), "", rsCustomer.Fields("region").Value)
            '    IntermediaryAssociateID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IntermediaryAssociateID").Value), "", rsCustomer.Fields("IntermediaryAssociateID").Value)
            '    CompanyType = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CompanyType").Value), 0, rsCustomer.Fields("CompanyType").Value)
            '    SalesPersonNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SalesPersonNumber").Value), 0, rsCustomer.Fields("SalesPersonNumber").Value)
            '    AccountTypeCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AccountTypeCode").Value), "", rsCustomer.Fields("AccountTypeCode").Value)
            '    StatementFrequency = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StatementFrequency").Value), "", rsCustomer.Fields("StatementFrequency").Value)
            '    AccountRating = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AccountRating").Value), "", rsCustomer.Fields("AccountRating").Value)
            '    FinanceCharge = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FinanceCharge").Value), 0, rsCustomer.Fields("FinanceCharge").Value)
            '    ParentAccount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ParentAccount").Value), "", rsCustomer.Fields("ParentAccount").Value)
            '    IsParentAccount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IsParentAccount").Value), 0, rsCustomer.Fields("IsParentAccount").Value)
            '    ShipVia = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ShipVia").Value), "", rsCustomer.Fields("ShipVia").Value)
            '    UPSZone = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("UPSZone").Value), "", rsCustomer.Fields("UPSZone").Value)
            '    Terms = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Terms").Value), "", rsCustomer.Fields("Terms").Value)
            '    IsTaxable = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IsTaxable").Value), 0, rsCustomer.Fields("IsTaxable").Value)
            '    'IsTaxable = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("IsTaxable").Value), 0, IIf(rsCustomer.Fields("IsTaxable").Value = "Y", 1, 0))
            '    TaxCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode").Value), "", rsCustomer.Fields("TaxCode").Value)
            '    TaxCode2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode2").Value), "", rsCustomer.Fields("TaxCode2").Value)
            '    TaxCode3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode3").Value), "", rsCustomer.Fields("TaxCode3").Value)
            '    ExemptNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ExemptNumber").Value), "", rsCustomer.Fields("ExemptNumber").Value)
            '    AllowSubstituteItem = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AllowSubstituteItem").Value), 0, rsCustomer.Fields("AllowSubstituteItem").Value)
            '    AllowBackOrders = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AllowBackOrders").Value), 0, rsCustomer.Fields("AllowBackOrders").Value)
            '    AllowPartialShipment = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AllowPartialShipment").Value), 0, rsCustomer.Fields("AllowPartialShipment").Value)
            '    DunningLetter = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DunningLetter").Value), 0, rsCustomer.Fields("DunningLetter").Value)
            '    Comment1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Comment1").Value), "", rsCustomer.Fields("Comment1").Value)
            '    Comment2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Comment2").Value), "", rsCustomer.Fields("Comment2").Value)
            '    TaxSchedule = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxSchedule").Value), "", rsCustomer.Fields("TaxSchedule").Value)
            '    CreditCardDescription = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditCardDescription").Value), "", rsCustomer.Fields("CreditCardDescription").Value)
            '    CreditCardHolder = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditCardHolder").Value), "", rsCustomer.Fields("CreditCardHolder").Value)
            '    DefaultInvoiceForm = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DefaultInvoiceForm").Value), 0, rsCustomer.Fields("DefaultInvoiceForm").Value)
            '    LocationShort = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LocationShort").Value), 0, rsCustomer.Fields("LocationShort").Value)
            '    TaxID = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxID").Value), "", rsCustomer.Fields("TaxID").Value)
            '    BillParent = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("BillParent").Value), 0, rsCustomer.Fields("BillParent").Value)
            '    Balance = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Balance").Value), 0, rsCustomer.Fields("Balance").Value)
            '    PhoneExtention = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PhoneExtention").Value), "", rsCustomer.Fields("PhoneExtention").Value)
            '    AutomaticPayment = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AutomaticPayment").Value), 0, rsCustomer.Fields("AutomaticPayment").Value)
            '    CustomerCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CustomerCode").Value), "", rsCustomer.Fields("CustomerCode").Value)
            '    PurchaseOrderAmount = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PurchaseOrderAmount").Value), 0, rsCustomer.Fields("PurchaseOrderAmount").Value)
            '    CountryOfOrigin = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CountryOfOrigin").Value), "", rsCustomer.Fields("CountryOfOrigin").Value)
            '    ChangeCountryOfOrigin = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeCountryOfOrigin").Value), 0, rsCustomer.Fields("ChangeCountryOfOrigin").Value)
            '    CountryOfAssembly = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CountryOfAssembly").Value), "", rsCustomer.Fields("CountryOfAssembly").Value)
            '    ChangeCountryOfAssembly = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChangeCountryOfAssembly").Value), 0, rsCustomer.Fields("ChangeCountryOfAssembly").Value)
            '    PurchaseOrderConfirmation = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PurchaseOrderConfirmation").Value), 0, rsCustomer.Fields("PurchaseOrderConfirmation").Value)
            '    RecepientOfCommissions = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("RecepientOfCommissions").Value), 0, rsCustomer.Fields("RecepientOfCommissions").Value)
            '    CreditorType = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CreditorType").Value), "", rsCustomer.Fields("CreditorType").Value)
            '    PercentageToBePaid = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PercentageToBePaid").Value), 0, rsCustomer.Fields("PercentageToBePaid").Value)
            '    If Not (System.DBNull.Value.Equals(rsCustomer.Fields("SignDate").Value)) Then SignDate = rsCustomer.Fields("SignDate").Value
            '    ImportOriginCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ImportOriginCode").Value), "", rsCustomer.Fields("ImportOriginCode").Value)
            '    ParticipantNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ParticipantNumber").Value), "", rsCustomer.Fields("ParticipantNumber").Value)
            '    CertifiedSupplier = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CertifiedSupplier").Value), 0, rsCustomer.Fields("CertifiedSupplier").Value)
            '    FederalIDNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FederalIDNumber").Value), 0, rsCustomer.Fields("FederalIDNumber").Value)
            '    FederalIDType = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FederalIDType").Value), "", rsCustomer.Fields("FederalIDType").Value)
            '    FederalCategory = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FederalCategory").Value), "", rsCustomer.Fields("FederalCategory").Value)
            '    AutoDistribute = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AutoDistribute").Value), 0, rsCustomer.Fields("AutoDistribute").Value)
            '    SupplierStatus = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SupplierStatus").Value), "", rsCustomer.Fields("SupplierStatus").Value)
            '    FOBCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FOBCode").Value), "", rsCustomer.Fields("FOBCode").Value)
            '    PrintPrice = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PrintPrice").Value), 0, rsCustomer.Fields("PrintPrice").Value)
            '    Acknowledge = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Acknowledge").Value), 0, rsCustomer.Fields("Acknowledge").Value)
            '    Confirmed = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Confirmed").Value), 0, rsCustomer.Fields("Confirmed").Value)
            '    LandedCostCode = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode").Value), "", rsCustomer.Fields("LandedCostCode").Value)
            '    LandedCostCode2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode2").Value), "", rsCustomer.Fields("LandedCostCode2").Value)
            '    LandedCostCode3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode3").Value), "", rsCustomer.Fields("LandedCostCode3").Value)
            '    LandedCostCode4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode4").Value), "", rsCustomer.Fields("LandedCostCode4").Value)
            '    LandedCostCode5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode5").Value), "", rsCustomer.Fields("LandedCostCode5").Value)
            '    LandedCostCode6 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode6").Value), "", rsCustomer.Fields("LandedCostCode6").Value)
            '    LandedCostCode7 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode7").Value), "", rsCustomer.Fields("LandedCostCode7").Value)
            '    LandedCostCode8 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode8").Value), "", rsCustomer.Fields("LandedCostCode8").Value)
            '    LandedCostCode9 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode9").Value), "", rsCustomer.Fields("LandedCostCode9").Value)
            '    LandedCostCode10 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("LandedCostCode10").Value), "", rsCustomer.Fields("LandedCostCode10").Value)
            '    DefaultPOForm = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DefaultPOForm").Value), 0, rsCustomer.Fields("DefaultPOForm").Value)
            '    PayeeName = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PayeeName").Value), "", rsCustomer.Fields("PayeeName").Value)
            '    CommodityCode1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CommodityCode1").Value), "", rsCustomer.Fields("CommodityCode1").Value)
            '    CommodityCode2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CommodityCode2").Value), "", rsCustomer.Fields("CommodityCode2").Value)
            '    CommodityCode3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CommodityCode3").Value), "", rsCustomer.Fields("CommodityCode3").Value)
            '    CommodityCode4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CommodityCode4").Value), "", rsCustomer.Fields("CommodityCode4").Value)
            '    CommodityCode5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("CommodityCode5").Value), "", rsCustomer.Fields("CommodityCode5").Value)
            '    SecurityLevel = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SecurityLevel").Value), 0, rsCustomer.Fields("SecurityLevel").Value)
            '    ChamberOfCommerce = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ChamberOfCommerce").Value), "", rsCustomer.Fields("ChamberOfCommerce").Value)
            '    DunsNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DunsNumber").Value), "", rsCustomer.Fields("DunsNumber").Value)
            '    TextField11 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField11").Value), "", rsCustomer.Fields("TextField11").Value)
            '    TextField12 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField12").Value), "", rsCustomer.Fields("TextField12").Value)
            '    TextField13 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField13").Value), "", rsCustomer.Fields("TextField13").Value)
            '    TextField14 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField14").Value), "", rsCustomer.Fields("TextField14").Value)
            '    TextField15 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField15").Value), "", rsCustomer.Fields("TextField15").Value)
            '    TextField16 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField16").Value), "", rsCustomer.Fields("TextField16").Value)
            '    TextField17 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField17").Value), "", rsCustomer.Fields("TextField17").Value)
            '    TextField18 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField18").Value), "", rsCustomer.Fields("TextField18").Value)
            '    TextField19 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField19").Value), "", rsCustomer.Fields("TextField19").Value)
            '    TextField20 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField20").Value), "", rsCustomer.Fields("TextField20").Value)
            '    TextField21 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField21").Value), "", rsCustomer.Fields("TextField21").Value)
            '    TextField22 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField22").Value), "", rsCustomer.Fields("TextField22").Value)
            '    TextField23 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField23").Value), "", rsCustomer.Fields("TextField23").Value)
            '    TextField24 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField24").Value), "", rsCustomer.Fields("TextField24").Value)
            '    TextField25 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField25").Value), "", rsCustomer.Fields("TextField25").Value)
            '    TextField26 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField26").Value), "", rsCustomer.Fields("TextField26").Value)
            '    TextField27 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField27").Value), "", rsCustomer.Fields("TextField27").Value)
            '    TextField28 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField28").Value), "", rsCustomer.Fields("TextField28").Value)
            '    TextField29 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField29").Value), "", rsCustomer.Fields("TextField29").Value)
            '    TextField30 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TextField30").Value), "", rsCustomer.Fields("TextField30").Value)
            '    PhoneQueue = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PhoneQueue").Value), "", rsCustomer.Fields("PhoneQueue").Value)
            '    cmp_Directory = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("cmp_Directory").Value), "", rsCustomer.Fields("cmp_Directory").Value)
            '    GUIDField1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GUIDField1").Value), "", rsCustomer.Fields("GUIDField1").Value)
            '    GUIDField2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GUIDField2").Value), "", rsCustomer.Fields("GUIDField2").Value)
            '    GUIDField3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GUIDField3").Value), "", rsCustomer.Fields("GUIDField3").Value)
            '    GUIDField4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GUIDField4").Value), "", rsCustomer.Fields("GUIDField4").Value)
            '    GUIDField5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("GUIDField5").Value), "", rsCustomer.Fields("GUIDField5").Value)
            '    NumIntField1 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NumIntField1").Value), 0, rsCustomer.Fields("NumIntField1").Value)
            '    NumIntField2 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NumIntField2").Value), 0, rsCustomer.Fields("NumIntField2").Value)
            '    NumIntField3 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NumIntField3").Value), 0, rsCustomer.Fields("NumIntField3").Value)
            '    NumIntField4 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NumIntField4").Value), 0, rsCustomer.Fields("NumIntField4").Value)
            '    NumIntField5 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("NumIntField5").Value), 0, rsCustomer.Fields("NumIntField5").Value)
            '    'EncryptedCreditCard = IIF(System.DBNull.Value.Equals(rsCustomer.Fields("EncryptedCreditCard").Value), "", rsCustomer.Fields("EncryptedCreditCard").Value)
            '    RuleItem = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("RuleItem").Value), "", rsCustomer.Fields("RuleItem").Value)
            '    Substitute = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Substitute").Value), 0, rsCustomer.Fields("Substitute").Value)
            '    Division = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Division").Value), 0, rsCustomer.Fields("Division").Value)
            '    AutoAllocate = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AutoAllocate").Value), 0, rsCustomer.Fields("AutoAllocate").Value)
            '    FedIDType = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FedIDType").Value), "", rsCustomer.Fields("FedIDType").Value)
            '    FedCategory = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FedCategory").Value), "", rsCustomer.Fields("FedCategory").Value)
            '    Category_01 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_01").Value), "", rsCustomer.Fields("Category_01").Value)
            '    Category_02 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_02").Value), "", rsCustomer.Fields("Category_02").Value)
            '    Category_03 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_03").Value), "", rsCustomer.Fields("Category_03").Value)
            '    Category_04 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_04").Value), "", rsCustomer.Fields("Category_04").Value)
            '    Category_05 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_05").Value), "", rsCustomer.Fields("Category_05").Value)
            '    Category_06 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_06").Value), "", rsCustomer.Fields("Category_06").Value)
            '    Category_07 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_07").Value), "", rsCustomer.Fields("Category_07").Value)
            '    Category_08 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_08").Value), "", rsCustomer.Fields("Category_08").Value)
            '    Category_09 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_09").Value), "", rsCustomer.Fields("Category_09").Value)
            '    Category_10 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_10").Value), "", rsCustomer.Fields("Category_10").Value)
            '    Category_11 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_11").Value), "", rsCustomer.Fields("Category_11").Value)
            '    Category_12 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_12").Value), "", rsCustomer.Fields("Category_12").Value)
            '    Category_13 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_13").Value), "", rsCustomer.Fields("Category_13").Value)
            '    Category_14 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_14").Value), "", rsCustomer.Fields("Category_14").Value)
            '    Category_15 = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Category_15").Value), "", rsCustomer.Fields("Category_15").Value)
            '    FedIDNumber = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("FedIDNumber").Value), "", rsCustomer.Fields("FedIDNumber").Value)
            '    DefaultDeliveryAddress = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DefaultDeliveryAddress").Value), "", rsCustomer.Fields("DefaultDeliveryAddress").Value)

            '    'txtCmp_Type_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Cmp_Type_Desc").Value), "", rsCustomer.Fields("Cmp_Type_Desc").Value)
            '    'txtStateCode_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("StateCode_Desc").Value), "", rsCustomer.Fields("StateCode_Desc").Value)
            '    'txtCmp_FCtry_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Cmp_FCtry_Desc").Value), "", rsCustomer.Fields("Cmp_FCtry_Desc").Value)
            '    'txtClassificationID_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ClassificationID_Desc").Value), "", rsCustomer.Fields("ClassificationID_Desc").Value)
            '    'txtCmp_Acc_Man_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Cmp_Acc_Man_Desc").Value), "", rsCustomer.Fields("Cmp_Acc_Man_Desc").Value)
            '    'txtCmp_Parent_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Cmp_Parent_Desc").Value), "", rsCustomer.Fields("Cmp_Parent_Desc").Value)
            '    'txtInvoiceDebtor_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("InvoiceDebtor_Desc").Value), "", rsCustomer.Fields("InvoiceDebtor_Desc").Value)
            '    'txtPaymentCondition_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("PaymentCondition_Desc").Value), "", rsCustomer.Fields("PaymentCondition_Desc").Value)
            '    'txtCurrency_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("Currency_Desc").Value), "", rsCustomer.Fields("Currency_Desc").Value)
            '    'txtAccountEmployeeId_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AccountEmployeeId_Desc").Value), "", rsCustomer.Fields("AccountEmployeeId_Desc").Value)
            '    'txtTaxSchedule_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxSchedule_Desc").Value), "", rsCustomer.Fields("TaxSchedule_Desc").Value)
            '    'txtTaxCode_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode_Desc").Value), "", rsCustomer.Fields("TaxCode_Desc").Value)
            '    'txtTaxCode2_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode2_Desc").Value), "", rsCustomer.Fields("TaxCode2_Desc").Value)
            '    'txtTaxCode3_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("TaxCode3_Desc").Value), "", rsCustomer.Fields("TaxCode3_Desc").Value)
            '    'txtSalesPersonNumber_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("SalesPersonNumber_Desc").Value), "", rsCustomer.Fields("SalesPersonNumber_Desc").Value)
            '    'txtAccountTypeCode_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("AccountTypeCode_Desc").Value), "", rsCustomer.Fields("AccountTypeCode_Desc").Value)
            '    'txtDefaultInvoiceForm_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DefaultInvoiceForm_Desc").Value), "", rsCustomer.Fields("DefaultInvoiceForm_Desc").Value)
            '    'txtShipVia_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("ShipVia_Desc").Value), "", rsCustomer.Fields("ShipVia_Desc").Value)
            '    'txtDeliveryAddress_Desc = IIf(System.DBNull.Value.Equals(rsCustomer.Fields("DeliveryAddress_Desc").Value), "", rsCustomer.Fields("DeliveryAddress_Desc").Value)

            'End If

        Catch er As Exception
            MsgBox("Error in cCustomer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Public Sub SetCustomerDefaultValuesToOrder(ByRef pOrder As cOEI_ORDHDR, ByVal pContactID As Integer)
    Public Sub SetCustomerDefaultValuesToOrder(ByRef pOrder As cOEI_ORDHDR, ByVal pProgram As cMdb_Cus_Prog)

        Try

            ' Verifier ceux qui ont des Cus_Alt_Adr_Cd

            With pOrder

                .Curr_Cd = Currency
                '.Cus_Type_Cd = AccountTypeCode

                .Bill_To_City = cmp_fcity
                .Bill_To_State = StateCode
                .Bill_To_Zip = cmp_fpc

                .Form_No = DefaultInvoiceForm

                .Tax_Sched = TaxSchedule
                'Tax_Fg = IIf(dt.Rows(0).Item("IsTaxable").Equals(DBNull.Value), "N", IIf(Trim(dt.Rows(0).Item("IsTaxable").ToString) = "1", "Y", "N"))
                .Tax_Fg = IsTaxable

                .Tax_Cd = TaxCode
                '.Tax_Pct = Tax_Cd_Percent_1

                .Tax_Cd_2 = TaxCode2
                '.Tax_Pct_2 = Tax_Cd_Percent_2

                .Tax_Cd_3 = TaxCode3
                '.Tax_Pct_3 = Tax_Cd_Percent_3

                '.Cus_Alt_Adr_Cd = String.Empty

                .Oe_Po_No = String.Empty
                .Slspsn_No = SalesPersonNumber
                .Job_No = String.Empty

                'If g_User.Group_Defaults.Contains("MFG_LOC") Then
                '    .Mfg_Loc = Trim(g_User.Group_Defaults.Item("MFG_LOC").ToString)
                'Else
                .Mfg_Loc = LocationShort
                'End If

                .Ship_Via_Cd = ShipVia
                .Ar_Terms_Cd = PaymentCondition
                .Discount_Pct = Discount
                '.Profit_Center = GetProfit_Center(Cus_Type_Cd)

                .Dept = String.Empty

                .Ship_Instruction_1 = String.Empty
                .Ship_Instruction_2 = String.Empty

                .Bill_To_Name = cmp_name
                .Bill_To_Addr_1 = cmp_fadd1
                .Bill_To_Addr_2 = cmp_fadd2
                .Bill_To_Addr_3 = cmp_fadd3
                .Bill_To_Addr_4 = IIf(cmp_fcity = "", "", cmp_fcity) & ", " & _
                    IIf(StateCode = "", "", StateCode) & " " & _
                    IIf(cmp_fpc = "", "", cmp_fpc)
                .Bill_To_City = cmp_fcity
                .Bill_To_State = StateCode
                .Bill_To_Zip = cmp_fpc
                .Bill_To_Country = cmp_fctry
                'txtBill_To_CountryDesc.Text = dt.Rows(0).item("").Value 'will populate on country change

                'm_oOrder.Ordhead.Curr_Cd = IIf(dt.Rows(0).item("Curr_Cd")), "", dt.Rows(0).item("Curr_Cd"))

                .Ship_To_Name = String.Empty
                .Ship_To_Addr_1 = String.Empty
                .Ship_To_Addr_2 = String.Empty
                .Ship_To_Addr_3 = String.Empty
                .Ship_To_Addr_4 = String.Empty
                .Ship_To_Country = String.Empty
                .Ship_To_City = String.Empty
                .Ship_To_State = String.Empty
                .Ship_To_Zip = String.Empty

                'ShipToCountryDesc.Text = String.Empty

                If pProgram.Contact_ID <> 0 Then

                    Dim oContact As New cCicntp(pProgram.Contact_ID)

                    .User_Def_Fld_4 = oContact.FullName ' ------------
                    .Phone_Number = oContact.cnt_f_tel
                    .Fax_Number = oContact.cnt_f_fax
                    .Email_Address = oContact.cnt_email

                End If

                '.Slspsn_Pct_Comm = 100
                '.Slspsn_Pct_Comm_2 = 0
                '.Slspsn_Pct_Comm_3 = 0

                '.Deter_Rate_By = m_oOrder.GetOE_Ctl_OE_Exchange_Rate_Flag

                'If g_User.Group_Defaults.Contains("USER_DEF_FLD_2") Then
                '.User_Def_Fld_2 = Trim(g_User.Group_Defaults.Item("USER_DEF_FLD_2").ToString)
                'Else
                '    .User_Def_Fld_2 = "CAD" ' IIf(dt.Rows(0).item("AccountTypeCode")), "", dt.Rows(0).item("AccountTypeCode"))
                'End If

                '.User_Def_Fld_3 = Slspsn_Name

                .Frt_Pay_Cd = "N"
                .Selection_Cd = "C"
                .Status = "1"
                .Bal_Meth = "O"

                .Ord_Language = IIf(DefaultInvoiceForm = 21, "EN", "FR")
                .Ord_Guid = pProgram.Cus_Prog_Guid

                .Exportts = Now.Date
                .Macolats = .Exportts
                .Trigger_Message = "Complete"
                .Triggerts = .Exportts

            End With

        Catch er As Exception
            MsgBox("Error in cCustomer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function Taal_Cd_ByID(ByVal pContactId As Integer) As String
        Taal_Cd_ByID = "EN"

        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        strSql = _
            " Select rtrim(taalcode) AS taalcode from cicntp WITH (NOLOCK) where ID = " & pContactId

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("taalcode").ToString <> "" Then
                Taal_Cd_ByID = dt.Rows(0).Item("taalcode").ToString
            End If

        End If

    End Function


    Public ReadOnly Property Default_Taal_Cd() As String
        Get
            Default_Taal_Cd = "EN"
            Try
                Dim db As New cDBA
                Dim dt As DataTable
                Dim strSql As String = _
                "SELECT		CP.CMP_CODE, CT.TAALCODE, COUNT(CT.TAALCODE) AS QTY_LANGUAGE " & _
                "FROM		CICNTP CT WITH (NOLOCK) " & _
                "INNER JOIN	CICMPY CP WITH (NOLOCK) ON CT.CMP_WWN = CP.CMP_WWN " & _
                "WHERE		CP.CMP_CODE = '" & cmp_code & "' " & _
                "GROUP BY	CP.CMP_CODE, CT.TAALCODE " & _
                "ORDER BY	CP.CMP_CODE, COUNT(CT.TAALCODE) DESC "
                'strSql = ""
                dt = db.DataTable(strSql)
                If dt.Rows.Count <> 0 Then
                    Default_Taal_Cd = dt.Rows(0).Item("TAALCODE").ToString
                End If
            Catch er As Exception
                MsgBox("Error in cCustomer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End Try

        End Get
    End Property
    Public ReadOnly Property Taal_Cd() As String
        Get
            'Taal_Cd = IIf(DefaultInvoiceForm = 21, "EN", "FR")
            Taal_Cd = "EN"
        End Get
    End Property

End Class
