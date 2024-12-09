Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cOEI_ORDHDR


#Region "private variables #################################################"


    Private m_strOrd_Type As String
    Private m_strOrd_No As String
    Private m_strOei_Ord_No As String
    Private m_strStatus As String
    Private m_dtEntered_Dt As DateTime
    Private m_dtOrd_Dt As DateTime
    Private m_strApply_To_No As String
    Private m_strOe_Po_No As String
    Private m_strCus_No As String
    Private m_strBal_Meth As String
    Private m_strBill_To_Name As String
    Private m_strBill_To_Addr_1 As String
    Private m_strBill_To_Addr_2 As String
    Private m_strBill_To_Addr_3 As String
    Private m_strBill_To_Addr_4 As String
    Private m_strBill_To_Country As String
    Private m_strCus_Alt_Adr_Cd As String
    Private m_strShip_To_Name As String
    Private m_strShip_To_Addr_1 As String
    Private m_strShip_To_Addr_2 As String
    Private m_strShip_To_Addr_3 As String
    Private m_strShip_To_Addr_4 As String
    Private m_strShip_To_Country As String
    Private m_dtShipping_Dt As DateTime
    Private m_strShip_Via_Cd As String
    Private m_strAr_Terms_Cd As String
    Private m_strFrt_Pay_Cd As String
    Private m_strShip_Instruction_1 As String
    Private m_strShip_Instruction_2 As String
    Private m_intSlspsn_No As Int32
    Private m_decSlspsn_Pct_Comm As Decimal
    Private m_decSlspsn_Comm_Amt As Decimal
    Private m_intSlspsn_No_2 As Int32
    Private m_decSlspsn_Pct_Comm_2 As Decimal
    Private m_decSlspsn_Comm_Amt_2 As Decimal
    Private m_intSlspsn_No_3 As Int32
    Private m_decSlspsn_Pct_Comm_3 As Decimal
    Private m_decSlspsn_Comm_Amt_3 As Decimal
    Private m_strTax_Cd As String
    Private m_decTax_Pct As Decimal
    Private m_strTax_Cd_2 As String
    Private m_decTax_Pct_2 As Decimal
    Private m_strTax_Cd_3 As String
    Private m_decTax_Pct_3 As Decimal
    Private m_decDiscount_Pct As Decimal
    Private m_strJob_No As String
    Private m_strMfg_Loc As String
    Private m_strProfit_Center As String
    Private m_strDept As String
    Private m_strAr_Reference As String
    Private m_decTot_Sls_Amt As Decimal
    Private m_decTot_Sls_Disc As Decimal
    Private m_decTot_Tax_Amt As Decimal
    Private m_decTot_Cost As Decimal
    Private m_decTot_Weight As Decimal
    Private m_decMisc_Amt As Decimal
    Private m_strMisc_Mn_No As String
    Private m_strMisc_Sb_No As String
    Private m_strMisc_Dp_No As String
    Private m_decFrt_Amt As Decimal
    Private m_strFrt_Mn_No As String
    Private m_strFrt_Sb_No As String
    Private m_strFrt_Dp_No As String
    Private m_decSls_Tax_Amt_1 As Decimal
    Private m_decSls_Tax_Amt_2 As Decimal
    Private m_decSls_Tax_Amt_3 As Decimal
    Private m_decComm_Pct As Decimal
    Private m_decComm_Amt As Decimal
    Private m_strCmt_1 As String
    Private m_strCmt_2 As String
    Private m_strCmt_3 As String
    Private m_decPayment_Amt As Decimal
    Private m_decPayment_Disc_Amt As Decimal
    Private m_strChk_No As String
    Private m_dtChk_Dt As DateTime
    Private m_strCash_Mn_No As String
    Private m_strCash_Sb_No As String
    Private m_strCash_Dp_No As String
    Private m_dtOrd_Dt_Picked As DateTime
    Private m_dtOrd_Dt_Billed As DateTime
    Private m_strInv_No As String
    Private m_dtInv_Dt As DateTime
    Private m_strSelection_Cd As String
    Private m_dtPosted_Dt As DateTime
    Private m_strPart_Posted_Fg As String
    Private m_strShip_To_Freefrm_Fg As String
    Private m_strBill_To_Freefrm_Fg As String
    Private m_strCopy_To_Bm_Fg As String
    Private m_strEdi_Fg As String
    Private m_strClosed_Fg As String
    Private m_decAccum_Misc_Amt As Decimal
    Private m_decAccum_Frt_Amt As Decimal
    Private m_decAccum_Tot_Tax_Amt As Decimal
    Private m_decAccum_Sls_Tax_Amt As Decimal
    Private m_decAccum_Tot_Sls_Amt As Decimal
    Private m_strHold_Fg As String
    Private m_strPrepayment_Fg As String
    Private m_strLost_Sale_Cd As String
    Private m_strOrig_Ord_Type As String
    Private m_dtOrig_Ord_Dt As DateTime
    Private m_strOrig_Ord_No As String
    Private m_bAward_Probability As Byte
    Private m_strOe_Cash_No As String
    Private m_strExch_Rt_Fg As String
    Private m_strCurr_Cd As String
    Private m_decOrig_Trx_Rt As Decimal
    Private m_decCurr_Trx_Rt As Decimal
    Private m_strTax_Sched As String
    Private m_strUser_Def_Fld_1 As String
    Private m_strUser_Def_Fld_2 As String
    Private m_strUser_Def_Fld_3 As String
    Private m_strUser_Def_Fld_4 As String
    Private m_strUser_Def_Fld_5 As String
    Private m_strDeter_Rate_By As String
    Private m_bForm_No As Byte
    Private m_strTax_Fg As String
    Private m_strSls_Mn_No As String
    Private m_strSls_Sb_No As String
    Private m_strSls_Dp_No As String
    Private m_dtOrd_Dt_Shipped As DateTime
    Private m_decTot_Dollars As Decimal
    Private m_strMult_Loc_Fg As String
    Private m_decTot_Tax_Cost As Decimal
    Private m_strHist_Load_Record As String
    Private m_strPre_Select_Status As String
    Private m_intPacking_No As Int32
    Private m_strDeliv_Ar_Terms_Cd As String
    Private m_strInv_Batch_Id As String
    Private m_strBill_To_No As String
    Private m_strRma_No As String
    Private m_intProg_Term_No As Int32
    Private m_strExtra_1 As String
    Private m_strExtra_2 As String
    Private m_strExtra_3 As String
    Private m_strExtra_4 As String
    Private m_strExtra_5 As String
    Private m_strExtra_6 As String
    Private m_strExtra_7 As String
    Private m_strExtra_8 As String
    Private m_strExtra_9 As String
    Private m_decExtra_10 As Decimal
    Private m_decExtra_11 As Decimal
    Private m_decExtra_12 As Decimal
    Private m_decExtra_13 As Decimal
    Private m_intExtra_14 As Int32
    Private m_intExtra_15 As Int32
    Private m_intEdi_Doc_Seq As Int16
    Private m_strContact_1 As String
    Private m_strPhone_Number As String
    Private m_strFax_Number As String
    Private m_strEmail_Address As String
    Private m_strUse_Email As String
    Private m_strShip_To_City As String
    Private m_strShip_To_State As String
    Private m_strShip_To_Zip As String
    Private m_strBill_To_City As String
    Private m_strBill_To_State As String
    Private m_strBill_To_Zip As String
    Private m_strFiller_0001 As String
    Private m_decId As Integer
    Private m_strOrd_Guid As String
    Private m_strUserid As String
    Private m_strShip_Link As String
    Private m_intSendorderack As Int32
    Private m_intContactview As Int32
    Private m_dtExportts As DateTime
    Private m_dtMacolats As DateTime
    Private m_strOpents As String
    Private m_strTrigger_Message As String
    Private m_dtTriggerts As DateTime
    Private m_blnEmail_Sent As Boolean
    Private m_blnOrderacksaveonly As Boolean
    Private m_blnAutocompletereship As Boolean
    Private m_strRepeatord_No As String
    Private m_strOrd_Language As String

#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pId As Integer)

        Try

            Call Init()
            Call Load(pId)

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pOei_Ord_No As String)

        Try

            Call Init()
            Call Load(pOei_Ord_No)

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    'Public Sub New(ByVal pOrd_Guid As String)

    '    Try

    '        Call Init()
    '        Call Load(pOrd_Guid)

    '    Catch ex As Exception
    '        MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub

#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_strOrd_Type = String.Empty
            m_strOrd_No = String.Empty
            m_strOei_Ord_No = String.Empty
            m_strStatus = String.Empty
            m_dtEntered_Dt = NoDate()
            m_dtOrd_Dt = NoDate()
            m_strApply_To_No = String.Empty
            m_strOe_Po_No = String.Empty
            m_strCus_No = String.Empty
            m_strBal_Meth = String.Empty
            m_strBill_To_Name = String.Empty
            m_strBill_To_Addr_1 = String.Empty
            m_strBill_To_Addr_2 = String.Empty
            m_strBill_To_Addr_3 = String.Empty
            m_strBill_To_Addr_4 = String.Empty
            m_strBill_To_Country = String.Empty
            m_strCus_Alt_Adr_Cd = String.Empty
            m_strShip_To_Name = String.Empty
            m_strShip_To_Addr_1 = String.Empty
            m_strShip_To_Addr_2 = String.Empty
            m_strShip_To_Addr_3 = String.Empty
            m_strShip_To_Addr_4 = String.Empty
            m_strShip_To_Country = String.Empty
            m_dtShipping_Dt = NoDate()
            m_strShip_Via_Cd = String.Empty
            m_strAr_Terms_Cd = String.Empty
            m_strFrt_Pay_Cd = String.Empty
            m_strShip_Instruction_1 = String.Empty
            m_strShip_Instruction_2 = String.Empty
            m_intSlspsn_No = 0
            m_decSlspsn_Pct_Comm = 0
            m_decSlspsn_Comm_Amt = 0
            m_intSlspsn_No_2 = 0
            m_decSlspsn_Pct_Comm_2 = 0
            m_decSlspsn_Comm_Amt_2 = 0
            m_intSlspsn_No_3 = 0
            m_decSlspsn_Pct_Comm_3 = 0
            m_decSlspsn_Comm_Amt_3 = 0
            m_strTax_Cd = String.Empty
            m_decTax_Pct = 0
            m_strTax_Cd_2 = String.Empty
            m_decTax_Pct_2 = 0
            m_strTax_Cd_3 = String.Empty
            m_decTax_Pct_3 = 0
            m_decDiscount_Pct = 0
            m_strJob_No = String.Empty
            m_strMfg_Loc = String.Empty
            m_strProfit_Center = String.Empty
            m_strDept = String.Empty
            m_strAr_Reference = String.Empty
            m_decTot_Sls_Amt = 0
            m_decTot_Sls_Disc = 0
            m_decTot_Tax_Amt = 0
            m_decTot_Cost = 0
            m_decTot_Weight = 0
            m_decMisc_Amt = 0
            m_strMisc_Mn_No = String.Empty
            m_strMisc_Sb_No = String.Empty
            m_strMisc_Dp_No = String.Empty
            m_decFrt_Amt = 0
            m_strFrt_Mn_No = String.Empty
            m_strFrt_Sb_No = String.Empty
            m_strFrt_Dp_No = String.Empty
            m_decSls_Tax_Amt_1 = 0
            m_decSls_Tax_Amt_2 = 0
            m_decSls_Tax_Amt_3 = 0
            m_decComm_Pct = 0
            m_decComm_Amt = 0
            m_strCmt_1 = String.Empty
            m_strCmt_2 = String.Empty
            m_strCmt_3 = String.Empty
            m_decPayment_Amt = 0
            m_decPayment_Disc_Amt = 0
            m_strChk_No = String.Empty
            m_dtChk_Dt = NoDate()
            m_strCash_Mn_No = String.Empty
            m_strCash_Sb_No = String.Empty
            m_strCash_Dp_No = String.Empty
            m_dtOrd_Dt_Picked = NoDate()
            m_dtOrd_Dt_Billed = NoDate()
            m_strInv_No = String.Empty
            m_dtInv_Dt = NoDate()
            m_strSelection_Cd = String.Empty
            m_dtPosted_Dt = NoDate()
            m_strPart_Posted_Fg = String.Empty
            m_strShip_To_Freefrm_Fg = String.Empty
            m_strBill_To_Freefrm_Fg = String.Empty
            m_strCopy_To_Bm_Fg = String.Empty
            m_strEdi_Fg = String.Empty
            m_strClosed_Fg = String.Empty
            m_decAccum_Misc_Amt = 0
            m_decAccum_Frt_Amt = 0
            m_decAccum_Tot_Tax_Amt = 0
            m_decAccum_Sls_Tax_Amt = 0
            m_decAccum_Tot_Sls_Amt = 0
            m_strHold_Fg = String.Empty
            m_strPrepayment_Fg = String.Empty
            m_strLost_Sale_Cd = String.Empty
            m_strOrig_Ord_Type = String.Empty
            m_dtOrig_Ord_Dt = NoDate()
            m_strOrig_Ord_No = String.Empty

            m_strOe_Cash_No = String.Empty
            m_strExch_Rt_Fg = String.Empty
            m_strCurr_Cd = String.Empty
            m_decOrig_Trx_Rt = 0
            m_decCurr_Trx_Rt = 0
            m_strTax_Sched = String.Empty
            m_strUser_Def_Fld_1 = String.Empty
            m_strUser_Def_Fld_2 = String.Empty
            m_strUser_Def_Fld_3 = String.Empty
            m_strUser_Def_Fld_4 = String.Empty
            m_strUser_Def_Fld_5 = String.Empty
            m_strDeter_Rate_By = String.Empty

            m_strTax_Fg = String.Empty
            m_strSls_Mn_No = String.Empty
            m_strSls_Sb_No = String.Empty
            m_strSls_Dp_No = String.Empty
            m_dtOrd_Dt_Shipped = NoDate()
            m_decTot_Dollars = 0
            m_strMult_Loc_Fg = String.Empty
            m_decTot_Tax_Cost = 0
            m_strHist_Load_Record = String.Empty
            m_strPre_Select_Status = String.Empty
            m_intPacking_No = 0
            m_strDeliv_Ar_Terms_Cd = String.Empty
            m_strInv_Batch_Id = String.Empty
            m_strBill_To_No = String.Empty
            m_strRma_No = String.Empty
            m_intProg_Term_No = 0
            m_strExtra_1 = String.Empty
            m_strExtra_2 = String.Empty
            m_strExtra_3 = String.Empty
            m_strExtra_4 = String.Empty
            m_strExtra_5 = String.Empty
            m_strExtra_6 = String.Empty
            m_strExtra_7 = String.Empty
            m_strExtra_8 = String.Empty
            m_strExtra_9 = String.Empty
            m_decExtra_10 = 0
            m_decExtra_11 = 0
            m_decExtra_12 = 0
            m_decExtra_13 = 0
            m_intExtra_14 = 0
            m_intExtra_15 = 0
            m_intEdi_Doc_Seq = 0
            m_strContact_1 = String.Empty
            m_strPhone_Number = String.Empty
            m_strFax_Number = String.Empty
            m_strEmail_Address = String.Empty
            m_strUse_Email = String.Empty
            m_strShip_To_City = String.Empty
            m_strShip_To_State = String.Empty
            m_strShip_To_Zip = String.Empty
            m_strBill_To_City = String.Empty
            m_strBill_To_State = String.Empty
            m_strBill_To_Zip = String.Empty
            m_strFiller_0001 = String.Empty
            m_decId = 0
            m_strOrd_Guid = String.Empty
            m_strUserid = String.Empty
            m_strShip_Link = String.Empty
            m_intSendorderack = 0
            m_intContactview = 0
            m_dtExportts = NoDate()
            m_dtMacolats = NoDate()
            m_strOpents = String.Empty
            m_strTrigger_Message = String.Empty
            m_dtTriggerts = NoDate()
            m_blnEmail_Sent = False
            m_blnOrderacksaveonly = False
            m_blnAutocompletereship = False
            m_strRepeatord_No = String.Empty
            m_strOrd_Language = String.Empty

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Ord_Type").Equals(DBNull.Value)) Then m_strOrd_Type = pdrRow.Item("Ord_Type").ToString
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("Oei_Ord_No").Equals(DBNull.Value)) Then m_strOei_Ord_No = pdrRow.Item("Oei_Ord_No").ToString
            If Not (pdrRow.Item("Status").Equals(DBNull.Value)) Then m_strStatus = pdrRow.Item("Status").ToString
            If Not (pdrRow.Item("Entered_Dt").Equals(DBNull.Value)) Then m_dtEntered_Dt = pdrRow.Item("Entered_Dt")
            If Not (pdrRow.Item("Ord_Dt").Equals(DBNull.Value)) Then m_dtOrd_Dt = pdrRow.Item("Ord_Dt")
            If Not (pdrRow.Item("Apply_To_No").Equals(DBNull.Value)) Then m_strApply_To_No = pdrRow.Item("Apply_To_No").ToString
            If Not (pdrRow.Item("Oe_Po_No").Equals(DBNull.Value)) Then m_strOe_Po_No = pdrRow.Item("Oe_Po_No").ToString
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Bal_Meth").Equals(DBNull.Value)) Then m_strBal_Meth = pdrRow.Item("Bal_Meth").ToString
            If Not (pdrRow.Item("Bill_To_Name").Equals(DBNull.Value)) Then m_strBill_To_Name = pdrRow.Item("Bill_To_Name").ToString
            If Not (pdrRow.Item("Bill_To_Addr_1").Equals(DBNull.Value)) Then m_strBill_To_Addr_1 = pdrRow.Item("Bill_To_Addr_1").ToString
            If Not (pdrRow.Item("Bill_To_Addr_2").Equals(DBNull.Value)) Then m_strBill_To_Addr_2 = pdrRow.Item("Bill_To_Addr_2").ToString
            If Not (pdrRow.Item("Bill_To_Addr_3").Equals(DBNull.Value)) Then m_strBill_To_Addr_3 = pdrRow.Item("Bill_To_Addr_3").ToString
            If Not (pdrRow.Item("Bill_To_Addr_4").Equals(DBNull.Value)) Then m_strBill_To_Addr_4 = pdrRow.Item("Bill_To_Addr_4").ToString
            If Not (pdrRow.Item("Bill_To_Country").Equals(DBNull.Value)) Then m_strBill_To_Country = pdrRow.Item("Bill_To_Country").ToString
            If Not (pdrRow.Item("Cus_Alt_Adr_Cd").Equals(DBNull.Value)) Then m_strCus_Alt_Adr_Cd = pdrRow.Item("Cus_Alt_Adr_Cd").ToString
            If Not (pdrRow.Item("Ship_To_Name").Equals(DBNull.Value)) Then m_strShip_To_Name = pdrRow.Item("Ship_To_Name").ToString
            If Not (pdrRow.Item("Ship_To_Addr_1").Equals(DBNull.Value)) Then m_strShip_To_Addr_1 = pdrRow.Item("Ship_To_Addr_1").ToString
            If Not (pdrRow.Item("Ship_To_Addr_2").Equals(DBNull.Value)) Then m_strShip_To_Addr_2 = pdrRow.Item("Ship_To_Addr_2").ToString
            If Not (pdrRow.Item("Ship_To_Addr_3").Equals(DBNull.Value)) Then m_strShip_To_Addr_3 = pdrRow.Item("Ship_To_Addr_3").ToString
            If Not (pdrRow.Item("Ship_To_Addr_4").Equals(DBNull.Value)) Then m_strShip_To_Addr_4 = pdrRow.Item("Ship_To_Addr_4").ToString
            If Not (pdrRow.Item("Ship_To_Country").Equals(DBNull.Value)) Then m_strShip_To_Country = pdrRow.Item("Ship_To_Country").ToString
            If Not (pdrRow.Item("Shipping_Dt").Equals(DBNull.Value)) Then m_dtShipping_Dt = pdrRow.Item("Shipping_Dt")
            If Not (pdrRow.Item("Ship_Via_Cd").Equals(DBNull.Value)) Then m_strShip_Via_Cd = pdrRow.Item("Ship_Via_Cd").ToString
            If Not (pdrRow.Item("Ar_Terms_Cd").Equals(DBNull.Value)) Then m_strAr_Terms_Cd = pdrRow.Item("Ar_Terms_Cd").ToString
            If Not (pdrRow.Item("Frt_Pay_Cd").Equals(DBNull.Value)) Then m_strFrt_Pay_Cd = pdrRow.Item("Frt_Pay_Cd").ToString
            If Not (pdrRow.Item("Ship_Instruction_1").Equals(DBNull.Value)) Then m_strShip_Instruction_1 = pdrRow.Item("Ship_Instruction_1").ToString
            If Not (pdrRow.Item("Ship_Instruction_2").Equals(DBNull.Value)) Then m_strShip_Instruction_2 = pdrRow.Item("Ship_Instruction_2").ToString
            If Not (pdrRow.Item("Slspsn_No").Equals(DBNull.Value)) Then m_intSlspsn_No = pdrRow.Item("Slspsn_No")
            If Not (pdrRow.Item("Slspsn_Pct_Comm").Equals(DBNull.Value)) Then m_decSlspsn_Pct_Comm = pdrRow.Item("Slspsn_Pct_Comm")
            If Not (pdrRow.Item("Slspsn_Comm_Amt").Equals(DBNull.Value)) Then m_decSlspsn_Comm_Amt = pdrRow.Item("Slspsn_Comm_Amt")
            If Not (pdrRow.Item("Slspsn_No_2").Equals(DBNull.Value)) Then m_intSlspsn_No_2 = pdrRow.Item("Slspsn_No_2")
            If Not (pdrRow.Item("Slspsn_Pct_Comm_2").Equals(DBNull.Value)) Then m_decSlspsn_Pct_Comm_2 = pdrRow.Item("Slspsn_Pct_Comm_2")
            If Not (pdrRow.Item("Slspsn_Comm_Amt_2").Equals(DBNull.Value)) Then m_decSlspsn_Comm_Amt_2 = pdrRow.Item("Slspsn_Comm_Amt_2")
            If Not (pdrRow.Item("Slspsn_No_3").Equals(DBNull.Value)) Then m_intSlspsn_No_3 = pdrRow.Item("Slspsn_No_3")
            If Not (pdrRow.Item("Slspsn_Pct_Comm_3").Equals(DBNull.Value)) Then m_decSlspsn_Pct_Comm_3 = pdrRow.Item("Slspsn_Pct_Comm_3")
            If Not (pdrRow.Item("Slspsn_Comm_Amt_3").Equals(DBNull.Value)) Then m_decSlspsn_Comm_Amt_3 = pdrRow.Item("Slspsn_Comm_Amt_3")
            If Not (pdrRow.Item("Tax_Cd").Equals(DBNull.Value)) Then m_strTax_Cd = pdrRow.Item("Tax_Cd").ToString
            If Not (pdrRow.Item("Tax_Pct").Equals(DBNull.Value)) Then m_decTax_Pct = pdrRow.Item("Tax_Pct")
            If Not (pdrRow.Item("Tax_Cd_2").Equals(DBNull.Value)) Then m_strTax_Cd_2 = pdrRow.Item("Tax_Cd_2").ToString
            If Not (pdrRow.Item("Tax_Pct_2").Equals(DBNull.Value)) Then m_decTax_Pct_2 = pdrRow.Item("Tax_Pct_2")
            If Not (pdrRow.Item("Tax_Cd_3").Equals(DBNull.Value)) Then m_strTax_Cd_3 = pdrRow.Item("Tax_Cd_3").ToString
            If Not (pdrRow.Item("Tax_Pct_3").Equals(DBNull.Value)) Then m_decTax_Pct_3 = pdrRow.Item("Tax_Pct_3")
            If Not (pdrRow.Item("Discount_Pct").Equals(DBNull.Value)) Then m_decDiscount_Pct = pdrRow.Item("Discount_Pct")
            If Not (pdrRow.Item("Job_No").Equals(DBNull.Value)) Then m_strJob_No = pdrRow.Item("Job_No").ToString
            If Not (pdrRow.Item("Mfg_Loc").Equals(DBNull.Value)) Then m_strMfg_Loc = pdrRow.Item("Mfg_Loc").ToString
            If Not (pdrRow.Item("Profit_Center").Equals(DBNull.Value)) Then m_strProfit_Center = pdrRow.Item("Profit_Center").ToString
            If Not (pdrRow.Item("Dept").Equals(DBNull.Value)) Then m_strDept = pdrRow.Item("Dept").ToString
            If Not (pdrRow.Item("Ar_Reference").Equals(DBNull.Value)) Then m_strAr_Reference = pdrRow.Item("Ar_Reference").ToString
            If Not (pdrRow.Item("Tot_Sls_Amt").Equals(DBNull.Value)) Then m_decTot_Sls_Amt = pdrRow.Item("Tot_Sls_Amt")
            If Not (pdrRow.Item("Tot_Sls_Disc").Equals(DBNull.Value)) Then m_decTot_Sls_Disc = pdrRow.Item("Tot_Sls_Disc")
            If Not (pdrRow.Item("Tot_Tax_Amt").Equals(DBNull.Value)) Then m_decTot_Tax_Amt = pdrRow.Item("Tot_Tax_Amt")
            If Not (pdrRow.Item("Tot_Cost").Equals(DBNull.Value)) Then m_decTot_Cost = pdrRow.Item("Tot_Cost")
            If Not (pdrRow.Item("Tot_Weight").Equals(DBNull.Value)) Then m_decTot_Weight = pdrRow.Item("Tot_Weight")
            If Not (pdrRow.Item("Misc_Amt").Equals(DBNull.Value)) Then m_decMisc_Amt = pdrRow.Item("Misc_Amt")
            If Not (pdrRow.Item("Misc_Mn_No").Equals(DBNull.Value)) Then m_strMisc_Mn_No = pdrRow.Item("Misc_Mn_No").ToString
            If Not (pdrRow.Item("Misc_Sb_No").Equals(DBNull.Value)) Then m_strMisc_Sb_No = pdrRow.Item("Misc_Sb_No").ToString
            If Not (pdrRow.Item("Misc_Dp_No").Equals(DBNull.Value)) Then m_strMisc_Dp_No = pdrRow.Item("Misc_Dp_No").ToString
            If Not (pdrRow.Item("Frt_Amt").Equals(DBNull.Value)) Then m_decFrt_Amt = pdrRow.Item("Frt_Amt")
            If Not (pdrRow.Item("Frt_Mn_No").Equals(DBNull.Value)) Then m_strFrt_Mn_No = pdrRow.Item("Frt_Mn_No").ToString
            If Not (pdrRow.Item("Frt_Sb_No").Equals(DBNull.Value)) Then m_strFrt_Sb_No = pdrRow.Item("Frt_Sb_No").ToString
            If Not (pdrRow.Item("Frt_Dp_No").Equals(DBNull.Value)) Then m_strFrt_Dp_No = pdrRow.Item("Frt_Dp_No").ToString
            If Not (pdrRow.Item("Sls_Tax_Amt_1").Equals(DBNull.Value)) Then m_decSls_Tax_Amt_1 = pdrRow.Item("Sls_Tax_Amt_1")
            If Not (pdrRow.Item("Sls_Tax_Amt_2").Equals(DBNull.Value)) Then m_decSls_Tax_Amt_2 = pdrRow.Item("Sls_Tax_Amt_2")
            If Not (pdrRow.Item("Sls_Tax_Amt_3").Equals(DBNull.Value)) Then m_decSls_Tax_Amt_3 = pdrRow.Item("Sls_Tax_Amt_3")
            If Not (pdrRow.Item("Comm_Pct").Equals(DBNull.Value)) Then m_decComm_Pct = pdrRow.Item("Comm_Pct")
            If Not (pdrRow.Item("Comm_Amt").Equals(DBNull.Value)) Then m_decComm_Amt = pdrRow.Item("Comm_Amt")
            If Not (pdrRow.Item("Cmt_1").Equals(DBNull.Value)) Then m_strCmt_1 = pdrRow.Item("Cmt_1").ToString
            If Not (pdrRow.Item("Cmt_2").Equals(DBNull.Value)) Then m_strCmt_2 = pdrRow.Item("Cmt_2").ToString
            If Not (pdrRow.Item("Cmt_3").Equals(DBNull.Value)) Then m_strCmt_3 = pdrRow.Item("Cmt_3").ToString
            If Not (pdrRow.Item("Payment_Amt").Equals(DBNull.Value)) Then m_decPayment_Amt = pdrRow.Item("Payment_Amt")
            If Not (pdrRow.Item("Payment_Disc_Amt").Equals(DBNull.Value)) Then m_decPayment_Disc_Amt = pdrRow.Item("Payment_Disc_Amt")
            If Not (pdrRow.Item("Chk_No").Equals(DBNull.Value)) Then m_strChk_No = pdrRow.Item("Chk_No").ToString
            If Not (pdrRow.Item("Chk_Dt").Equals(DBNull.Value)) Then m_dtChk_Dt = pdrRow.Item("Chk_Dt")
            If Not (pdrRow.Item("Cash_Mn_No").Equals(DBNull.Value)) Then m_strCash_Mn_No = pdrRow.Item("Cash_Mn_No").ToString
            If Not (pdrRow.Item("Cash_Sb_No").Equals(DBNull.Value)) Then m_strCash_Sb_No = pdrRow.Item("Cash_Sb_No").ToString
            If Not (pdrRow.Item("Cash_Dp_No").Equals(DBNull.Value)) Then m_strCash_Dp_No = pdrRow.Item("Cash_Dp_No").ToString
            If Not (pdrRow.Item("Ord_Dt_Picked").Equals(DBNull.Value)) Then m_dtOrd_Dt_Picked = pdrRow.Item("Ord_Dt_Picked")
            If Not (pdrRow.Item("Ord_Dt_Billed").Equals(DBNull.Value)) Then m_dtOrd_Dt_Billed = pdrRow.Item("Ord_Dt_Billed")
            If Not (pdrRow.Item("Inv_No").Equals(DBNull.Value)) Then m_strInv_No = pdrRow.Item("Inv_No").ToString
            If Not (pdrRow.Item("Inv_Dt").Equals(DBNull.Value)) Then m_dtInv_Dt = pdrRow.Item("Inv_Dt")
            If Not (pdrRow.Item("Selection_Cd").Equals(DBNull.Value)) Then m_strSelection_Cd = pdrRow.Item("Selection_Cd").ToString
            If Not (pdrRow.Item("Posted_Dt").Equals(DBNull.Value)) Then m_dtPosted_Dt = pdrRow.Item("Posted_Dt")
            If Not (pdrRow.Item("Part_Posted_Fg").Equals(DBNull.Value)) Then m_strPart_Posted_Fg = pdrRow.Item("Part_Posted_Fg").ToString
            If Not (pdrRow.Item("Ship_To_Freefrm_Fg").Equals(DBNull.Value)) Then m_strShip_To_Freefrm_Fg = pdrRow.Item("Ship_To_Freefrm_Fg").ToString
            If Not (pdrRow.Item("Bill_To_Freefrm_Fg").Equals(DBNull.Value)) Then m_strBill_To_Freefrm_Fg = pdrRow.Item("Bill_To_Freefrm_Fg").ToString
            If Not (pdrRow.Item("Copy_To_Bm_Fg").Equals(DBNull.Value)) Then m_strCopy_To_Bm_Fg = pdrRow.Item("Copy_To_Bm_Fg").ToString
            If Not (pdrRow.Item("Edi_Fg").Equals(DBNull.Value)) Then m_strEdi_Fg = pdrRow.Item("Edi_Fg").ToString
            If Not (pdrRow.Item("Closed_Fg").Equals(DBNull.Value)) Then m_strClosed_Fg = pdrRow.Item("Closed_Fg").ToString
            If Not (pdrRow.Item("Accum_Misc_Amt").Equals(DBNull.Value)) Then m_decAccum_Misc_Amt = pdrRow.Item("Accum_Misc_Amt")
            If Not (pdrRow.Item("Accum_Frt_Amt").Equals(DBNull.Value)) Then m_decAccum_Frt_Amt = pdrRow.Item("Accum_Frt_Amt")
            If Not (pdrRow.Item("Accum_Tot_Tax_Amt").Equals(DBNull.Value)) Then m_decAccum_Tot_Tax_Amt = pdrRow.Item("Accum_Tot_Tax_Amt")
            If Not (pdrRow.Item("Accum_Sls_Tax_Amt").Equals(DBNull.Value)) Then m_decAccum_Sls_Tax_Amt = pdrRow.Item("Accum_Sls_Tax_Amt")
            If Not (pdrRow.Item("Accum_Tot_Sls_Amt").Equals(DBNull.Value)) Then m_decAccum_Tot_Sls_Amt = pdrRow.Item("Accum_Tot_Sls_Amt")
            If Not (pdrRow.Item("Hold_Fg").Equals(DBNull.Value)) Then m_strHold_Fg = pdrRow.Item("Hold_Fg").ToString
            If Not (pdrRow.Item("Prepayment_Fg").Equals(DBNull.Value)) Then m_strPrepayment_Fg = pdrRow.Item("Prepayment_Fg").ToString
            If Not (pdrRow.Item("Lost_Sale_Cd").Equals(DBNull.Value)) Then m_strLost_Sale_Cd = pdrRow.Item("Lost_Sale_Cd").ToString
            If Not (pdrRow.Item("Orig_Ord_Type").Equals(DBNull.Value)) Then m_strOrig_Ord_Type = pdrRow.Item("Orig_Ord_Type").ToString
            If Not (pdrRow.Item("Orig_Ord_Dt").Equals(DBNull.Value)) Then m_dtOrig_Ord_Dt = pdrRow.Item("Orig_Ord_Dt")
            If Not (pdrRow.Item("Orig_Ord_No").Equals(DBNull.Value)) Then m_strOrig_Ord_No = pdrRow.Item("Orig_Ord_No").ToString
            If Not (pdrRow.Item("Award_Probability").Equals(DBNull.Value)) Then m_bAward_Probability = pdrRow.Item("Award_Probability")
            If Not (pdrRow.Item("Oe_Cash_No").Equals(DBNull.Value)) Then m_strOe_Cash_No = pdrRow.Item("Oe_Cash_No").ToString
            If Not (pdrRow.Item("Exch_Rt_Fg").Equals(DBNull.Value)) Then m_strExch_Rt_Fg = pdrRow.Item("Exch_Rt_Fg").ToString
            If Not (pdrRow.Item("Curr_Cd").Equals(DBNull.Value)) Then m_strCurr_Cd = pdrRow.Item("Curr_Cd").ToString
            If Not (pdrRow.Item("Orig_Trx_Rt").Equals(DBNull.Value)) Then m_decOrig_Trx_Rt = pdrRow.Item("Orig_Trx_Rt")
            If Not (pdrRow.Item("Curr_Trx_Rt").Equals(DBNull.Value)) Then m_decCurr_Trx_Rt = pdrRow.Item("Curr_Trx_Rt")
            If Not (pdrRow.Item("Tax_Sched").Equals(DBNull.Value)) Then m_strTax_Sched = pdrRow.Item("Tax_Sched").ToString
            If Not (pdrRow.Item("User_Def_Fld_1").Equals(DBNull.Value)) Then m_strUser_Def_Fld_1 = pdrRow.Item("User_Def_Fld_1").ToString
            If Not (pdrRow.Item("User_Def_Fld_2").Equals(DBNull.Value)) Then m_strUser_Def_Fld_2 = pdrRow.Item("User_Def_Fld_2").ToString
            If Not (pdrRow.Item("User_Def_Fld_3").Equals(DBNull.Value)) Then m_strUser_Def_Fld_3 = pdrRow.Item("User_Def_Fld_3").ToString
            If Not (pdrRow.Item("User_Def_Fld_4").Equals(DBNull.Value)) Then m_strUser_Def_Fld_4 = pdrRow.Item("User_Def_Fld_4").ToString
            If Not (pdrRow.Item("User_Def_Fld_5").Equals(DBNull.Value)) Then m_strUser_Def_Fld_5 = pdrRow.Item("User_Def_Fld_5").ToString
            If Not (pdrRow.Item("Deter_Rate_By").Equals(DBNull.Value)) Then m_strDeter_Rate_By = pdrRow.Item("Deter_Rate_By").ToString
            If Not (pdrRow.Item("Form_No").Equals(DBNull.Value)) Then m_bForm_No = pdrRow.Item("Form_No")
            If Not (pdrRow.Item("Tax_Fg").Equals(DBNull.Value)) Then m_strTax_Fg = pdrRow.Item("Tax_Fg").ToString
            If Not (pdrRow.Item("Sls_Mn_No").Equals(DBNull.Value)) Then m_strSls_Mn_No = pdrRow.Item("Sls_Mn_No").ToString
            If Not (pdrRow.Item("Sls_Sb_No").Equals(DBNull.Value)) Then m_strSls_Sb_No = pdrRow.Item("Sls_Sb_No").ToString
            If Not (pdrRow.Item("Sls_Dp_No").Equals(DBNull.Value)) Then m_strSls_Dp_No = pdrRow.Item("Sls_Dp_No").ToString
            If Not (pdrRow.Item("Ord_Dt_Shipped").Equals(DBNull.Value)) Then m_dtOrd_Dt_Shipped = pdrRow.Item("Ord_Dt_Shipped")
            If Not (pdrRow.Item("Tot_Dollars").Equals(DBNull.Value)) Then m_decTot_Dollars = pdrRow.Item("Tot_Dollars")
            If Not (pdrRow.Item("Mult_Loc_Fg").Equals(DBNull.Value)) Then m_strMult_Loc_Fg = pdrRow.Item("Mult_Loc_Fg").ToString
            If Not (pdrRow.Item("Tot_Tax_Cost").Equals(DBNull.Value)) Then m_decTot_Tax_Cost = pdrRow.Item("Tot_Tax_Cost")
            If Not (pdrRow.Item("Hist_Load_Record").Equals(DBNull.Value)) Then m_strHist_Load_Record = pdrRow.Item("Hist_Load_Record").ToString
            If Not (pdrRow.Item("Pre_Select_Status").Equals(DBNull.Value)) Then m_strPre_Select_Status = pdrRow.Item("Pre_Select_Status").ToString
            If Not (pdrRow.Item("Packing_No").Equals(DBNull.Value)) Then m_intPacking_No = pdrRow.Item("Packing_No")
            If Not (pdrRow.Item("Deliv_Ar_Terms_Cd").Equals(DBNull.Value)) Then m_strDeliv_Ar_Terms_Cd = pdrRow.Item("Deliv_Ar_Terms_Cd").ToString
            If Not (pdrRow.Item("Inv_Batch_Id").Equals(DBNull.Value)) Then m_strInv_Batch_Id = pdrRow.Item("Inv_Batch_Id").ToString
            If Not (pdrRow.Item("Bill_To_No").Equals(DBNull.Value)) Then m_strBill_To_No = pdrRow.Item("Bill_To_No").ToString
            If Not (pdrRow.Item("Rma_No").Equals(DBNull.Value)) Then m_strRma_No = pdrRow.Item("Rma_No").ToString
            If Not (pdrRow.Item("Prog_Term_No").Equals(DBNull.Value)) Then m_intProg_Term_No = pdrRow.Item("Prog_Term_No")
            If Not (pdrRow.Item("Extra_1").Equals(DBNull.Value)) Then m_strExtra_1 = pdrRow.Item("Extra_1").ToString
            If Not (pdrRow.Item("Extra_2").Equals(DBNull.Value)) Then m_strExtra_2 = pdrRow.Item("Extra_2").ToString
            If Not (pdrRow.Item("Extra_3").Equals(DBNull.Value)) Then m_strExtra_3 = pdrRow.Item("Extra_3").ToString
            If Not (pdrRow.Item("Extra_4").Equals(DBNull.Value)) Then m_strExtra_4 = pdrRow.Item("Extra_4").ToString
            If Not (pdrRow.Item("Extra_5").Equals(DBNull.Value)) Then m_strExtra_5 = pdrRow.Item("Extra_5").ToString
            If Not (pdrRow.Item("Extra_6").Equals(DBNull.Value)) Then m_strExtra_6 = pdrRow.Item("Extra_6").ToString
            If Not (pdrRow.Item("Extra_7").Equals(DBNull.Value)) Then m_strExtra_7 = pdrRow.Item("Extra_7").ToString
            If Not (pdrRow.Item("Extra_8").Equals(DBNull.Value)) Then m_strExtra_8 = pdrRow.Item("Extra_8").ToString
            If Not (pdrRow.Item("Extra_9").Equals(DBNull.Value)) Then m_strExtra_9 = pdrRow.Item("Extra_9").ToString
            If Not (pdrRow.Item("Extra_10").Equals(DBNull.Value)) Then m_decExtra_10 = pdrRow.Item("Extra_10")
            If Not (pdrRow.Item("Extra_11").Equals(DBNull.Value)) Then m_decExtra_11 = pdrRow.Item("Extra_11")
            If Not (pdrRow.Item("Extra_12").Equals(DBNull.Value)) Then m_decExtra_12 = pdrRow.Item("Extra_12")
            If Not (pdrRow.Item("Extra_13").Equals(DBNull.Value)) Then m_decExtra_13 = pdrRow.Item("Extra_13")
            If Not (pdrRow.Item("Extra_14").Equals(DBNull.Value)) Then m_intExtra_14 = pdrRow.Item("Extra_14")
            If Not (pdrRow.Item("Extra_15").Equals(DBNull.Value)) Then m_intExtra_15 = pdrRow.Item("Extra_15")
            If Not (pdrRow.Item("Edi_Doc_Seq").Equals(DBNull.Value)) Then m_intEdi_Doc_Seq = pdrRow.Item("Edi_Doc_Seq")
            If Not (pdrRow.Item("Contact_1").Equals(DBNull.Value)) Then m_strContact_1 = pdrRow.Item("Contact_1").ToString
            If Not (pdrRow.Item("Phone_Number").Equals(DBNull.Value)) Then m_strPhone_Number = pdrRow.Item("Phone_Number").ToString
            If Not (pdrRow.Item("Fax_Number").Equals(DBNull.Value)) Then m_strFax_Number = pdrRow.Item("Fax_Number").ToString
            If Not (pdrRow.Item("Email_Address").Equals(DBNull.Value)) Then m_strEmail_Address = pdrRow.Item("Email_Address").ToString
            If Not (pdrRow.Item("Use_Email").Equals(DBNull.Value)) Then m_strUse_Email = pdrRow.Item("Use_Email").ToString
            If Not (pdrRow.Item("Ship_To_City").Equals(DBNull.Value)) Then m_strShip_To_City = pdrRow.Item("Ship_To_City").ToString
            If Not (pdrRow.Item("Ship_To_State").Equals(DBNull.Value)) Then m_strShip_To_State = pdrRow.Item("Ship_To_State").ToString
            If Not (pdrRow.Item("Ship_To_Zip").Equals(DBNull.Value)) Then m_strShip_To_Zip = pdrRow.Item("Ship_To_Zip").ToString
            If Not (pdrRow.Item("Bill_To_City").Equals(DBNull.Value)) Then m_strBill_To_City = pdrRow.Item("Bill_To_City").ToString
            If Not (pdrRow.Item("Bill_To_State").Equals(DBNull.Value)) Then m_strBill_To_State = pdrRow.Item("Bill_To_State").ToString
            If Not (pdrRow.Item("Bill_To_Zip").Equals(DBNull.Value)) Then m_strBill_To_Zip = pdrRow.Item("Bill_To_Zip").ToString
            If Not (pdrRow.Item("Filler_0001").Equals(DBNull.Value)) Then m_strFiller_0001 = pdrRow.Item("Filler_0001").ToString
            If Not (pdrRow.Item("Id").Equals(DBNull.Value)) Then m_decId = pdrRow.Item("Id")
            If Not (pdrRow.Item("Ord_Guid").Equals(DBNull.Value)) Then m_strOrd_Guid = pdrRow.Item("Ord_Guid").ToString
            If Not (pdrRow.Item("Userid").Equals(DBNull.Value)) Then m_strUserid = pdrRow.Item("Userid").ToString
            If Not (pdrRow.Item("Ship_Link").Equals(DBNull.Value)) Then m_strShip_Link = pdrRow.Item("Ship_Link").ToString
            If Not (pdrRow.Item("Sendorderack").Equals(DBNull.Value)) Then m_intSendorderack = pdrRow.Item("Sendorderack")
            If Not (pdrRow.Item("Contactview").Equals(DBNull.Value)) Then m_intContactview = pdrRow.Item("Contactview")
            If Not (pdrRow.Item("Exportts").Equals(DBNull.Value)) Then m_dtExportts = pdrRow.Item("Exportts")
            If Not (pdrRow.Item("Macolats").Equals(DBNull.Value)) Then m_dtMacolats = pdrRow.Item("Macolats")
            If Not (pdrRow.Item("Opents").Equals(DBNull.Value)) Then m_strOpents = pdrRow.Item("Opents").ToString
            If Not (pdrRow.Item("Trigger_Message").Equals(DBNull.Value)) Then m_strTrigger_Message = pdrRow.Item("Trigger_Message").ToString
            If Not (pdrRow.Item("Triggerts").Equals(DBNull.Value)) Then m_dtTriggerts = pdrRow.Item("Triggerts")
            If Not (pdrRow.Item("Email_Sent").Equals(DBNull.Value)) Then m_blnEmail_Sent = pdrRow.Item("Email_Sent")
            If Not (pdrRow.Item("Orderacksaveonly").Equals(DBNull.Value)) Then m_blnOrderacksaveonly = pdrRow.Item("Orderacksaveonly")
            If Not (pdrRow.Item("Autocompletereship").Equals(DBNull.Value)) Then m_blnAutocompletereship = pdrRow.Item("Autocompletereship")
            If Not (pdrRow.Item("Repeatord_No").Equals(DBNull.Value)) Then m_strRepeatord_No = pdrRow.Item("Repeatord_No").ToString
            If Not (pdrRow.Item("Ord_Language").Equals(DBNull.Value)) Then m_strOrd_Language = pdrRow.Item("Ord_Language").ToString

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Ord_Type") = m_strOrd_Type
            pdrRow.Item("Ord_No") = m_strOrd_No
            pdrRow.Item("Oei_Ord_No") = m_strOei_Ord_No
            pdrRow.Item("Status") = m_strStatus
            If m_dtEntered_Dt.Year <> 1 Then pdrRow.Item("Entered_Dt") = m_dtEntered_Dt
            If m_dtOrd_Dt.Year <> 1 Then pdrRow.Item("Ord_Dt") = m_dtOrd_Dt
            pdrRow.Item("Apply_To_No") = m_strApply_To_No
            pdrRow.Item("Oe_Po_No") = m_strOe_Po_No
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Bal_Meth") = m_strBal_Meth
            pdrRow.Item("Bill_To_Name") = m_strBill_To_Name
            pdrRow.Item("Bill_To_Addr_1") = m_strBill_To_Addr_1
            pdrRow.Item("Bill_To_Addr_2") = m_strBill_To_Addr_2
            pdrRow.Item("Bill_To_Addr_3") = m_strBill_To_Addr_3
            pdrRow.Item("Bill_To_Addr_4") = m_strBill_To_Addr_4
            pdrRow.Item("Bill_To_Country") = m_strBill_To_Country
            pdrRow.Item("Cus_Alt_Adr_Cd") = m_strCus_Alt_Adr_Cd
            pdrRow.Item("Ship_To_Name") = m_strShip_To_Name
            pdrRow.Item("Ship_To_Addr_1") = m_strShip_To_Addr_1
            pdrRow.Item("Ship_To_Addr_2") = m_strShip_To_Addr_2
            pdrRow.Item("Ship_To_Addr_3") = m_strShip_To_Addr_3
            pdrRow.Item("Ship_To_Addr_4") = m_strShip_To_Addr_4
            pdrRow.Item("Ship_To_Country") = m_strShip_To_Country
            If m_dtShipping_Dt.Year <> 1 Then pdrRow.Item("Shipping_Dt") = m_dtShipping_Dt
            pdrRow.Item("Ship_Via_Cd") = m_strShip_Via_Cd
            pdrRow.Item("Ar_Terms_Cd") = m_strAr_Terms_Cd
            pdrRow.Item("Frt_Pay_Cd") = m_strFrt_Pay_Cd
            pdrRow.Item("Ship_Instruction_1") = m_strShip_Instruction_1
            pdrRow.Item("Ship_Instruction_2") = m_strShip_Instruction_2
            pdrRow.Item("Slspsn_No") = m_intSlspsn_No
            pdrRow.Item("Slspsn_Pct_Comm") = m_decSlspsn_Pct_Comm
            pdrRow.Item("Slspsn_Comm_Amt") = m_decSlspsn_Comm_Amt
            pdrRow.Item("Slspsn_No_2") = m_intSlspsn_No_2
            pdrRow.Item("Slspsn_Pct_Comm_2") = m_decSlspsn_Pct_Comm_2
            pdrRow.Item("Slspsn_Comm_Amt_2") = m_decSlspsn_Comm_Amt_2
            pdrRow.Item("Slspsn_No_3") = m_intSlspsn_No_3
            pdrRow.Item("Slspsn_Pct_Comm_3") = m_decSlspsn_Pct_Comm_3
            pdrRow.Item("Slspsn_Comm_Amt_3") = m_decSlspsn_Comm_Amt_3
            pdrRow.Item("Tax_Cd") = m_strTax_Cd
            pdrRow.Item("Tax_Pct") = m_decTax_Pct
            pdrRow.Item("Tax_Cd_2") = m_strTax_Cd_2
            pdrRow.Item("Tax_Pct_2") = m_decTax_Pct_2
            pdrRow.Item("Tax_Cd_3") = m_strTax_Cd_3
            pdrRow.Item("Tax_Pct_3") = m_decTax_Pct_3
            pdrRow.Item("Discount_Pct") = m_decDiscount_Pct
            pdrRow.Item("Job_No") = m_strJob_No
            pdrRow.Item("Mfg_Loc") = m_strMfg_Loc
            pdrRow.Item("Profit_Center") = m_strProfit_Center
            pdrRow.Item("Dept") = m_strDept
            pdrRow.Item("Ar_Reference") = m_strAr_Reference
            pdrRow.Item("Tot_Sls_Amt") = m_decTot_Sls_Amt
            pdrRow.Item("Tot_Sls_Disc") = m_decTot_Sls_Disc
            pdrRow.Item("Tot_Tax_Amt") = m_decTot_Tax_Amt
            pdrRow.Item("Tot_Cost") = m_decTot_Cost
            pdrRow.Item("Tot_Weight") = m_decTot_Weight
            pdrRow.Item("Misc_Amt") = m_decMisc_Amt
            pdrRow.Item("Misc_Mn_No") = m_strMisc_Mn_No
            pdrRow.Item("Misc_Sb_No") = m_strMisc_Sb_No
            pdrRow.Item("Misc_Dp_No") = m_strMisc_Dp_No
            pdrRow.Item("Frt_Amt") = m_decFrt_Amt
            pdrRow.Item("Frt_Mn_No") = m_strFrt_Mn_No
            pdrRow.Item("Frt_Sb_No") = m_strFrt_Sb_No
            pdrRow.Item("Frt_Dp_No") = m_strFrt_Dp_No
            pdrRow.Item("Sls_Tax_Amt_1") = m_decSls_Tax_Amt_1
            pdrRow.Item("Sls_Tax_Amt_2") = m_decSls_Tax_Amt_2
            pdrRow.Item("Sls_Tax_Amt_3") = m_decSls_Tax_Amt_3
            pdrRow.Item("Comm_Pct") = m_decComm_Pct
            pdrRow.Item("Comm_Amt") = m_decComm_Amt
            pdrRow.Item("Cmt_1") = m_strCmt_1
            pdrRow.Item("Cmt_2") = m_strCmt_2
            pdrRow.Item("Cmt_3") = m_strCmt_3
            pdrRow.Item("Payment_Amt") = m_decPayment_Amt
            pdrRow.Item("Payment_Disc_Amt") = m_decPayment_Disc_Amt
            pdrRow.Item("Chk_No") = m_strChk_No
            If m_dtChk_Dt.Year <> 1 Then pdrRow.Item("Chk_Dt") = m_dtChk_Dt
            pdrRow.Item("Cash_Mn_No") = m_strCash_Mn_No
            pdrRow.Item("Cash_Sb_No") = m_strCash_Sb_No
            pdrRow.Item("Cash_Dp_No") = m_strCash_Dp_No
            If m_dtOrd_Dt_Picked.Year <> 1 Then pdrRow.Item("Ord_Dt_Picked") = m_dtOrd_Dt_Picked
            If m_dtOrd_Dt_Billed.Year <> 1 Then pdrRow.Item("Ord_Dt_Billed") = m_dtOrd_Dt_Billed
            pdrRow.Item("Inv_No") = m_strInv_No
            If m_dtInv_Dt.Year <> 1 Then pdrRow.Item("Inv_Dt") = m_dtInv_Dt
            pdrRow.Item("Selection_Cd") = m_strSelection_Cd
            If m_dtPosted_Dt.Year <> 1 Then pdrRow.Item("Posted_Dt") = m_dtPosted_Dt
            pdrRow.Item("Part_Posted_Fg") = m_strPart_Posted_Fg
            pdrRow.Item("Ship_To_Freefrm_Fg") = m_strShip_To_Freefrm_Fg
            pdrRow.Item("Bill_To_Freefrm_Fg") = m_strBill_To_Freefrm_Fg
            pdrRow.Item("Copy_To_Bm_Fg") = m_strCopy_To_Bm_Fg
            pdrRow.Item("Edi_Fg") = m_strEdi_Fg
            pdrRow.Item("Closed_Fg") = m_strClosed_Fg
            pdrRow.Item("Accum_Misc_Amt") = m_decAccum_Misc_Amt
            pdrRow.Item("Accum_Frt_Amt") = m_decAccum_Frt_Amt
            pdrRow.Item("Accum_Tot_Tax_Amt") = m_decAccum_Tot_Tax_Amt
            pdrRow.Item("Accum_Sls_Tax_Amt") = m_decAccum_Sls_Tax_Amt
            pdrRow.Item("Accum_Tot_Sls_Amt") = m_decAccum_Tot_Sls_Amt
            pdrRow.Item("Hold_Fg") = m_strHold_Fg
            pdrRow.Item("Prepayment_Fg") = m_strPrepayment_Fg
            pdrRow.Item("Lost_Sale_Cd") = m_strLost_Sale_Cd
            pdrRow.Item("Orig_Ord_Type") = m_strOrig_Ord_Type
            If m_dtOrig_Ord_Dt.Year <> 1 Then pdrRow.Item("Orig_Ord_Dt") = m_dtOrig_Ord_Dt
            pdrRow.Item("Orig_Ord_No") = m_strOrig_Ord_No
            pdrRow.Item("Award_Probability") = m_bAward_Probability
            pdrRow.Item("Oe_Cash_No") = m_strOe_Cash_No
            pdrRow.Item("Exch_Rt_Fg") = m_strExch_Rt_Fg
            pdrRow.Item("Curr_Cd") = m_strCurr_Cd
            pdrRow.Item("Orig_Trx_Rt") = m_decOrig_Trx_Rt
            pdrRow.Item("Curr_Trx_Rt") = m_decCurr_Trx_Rt
            pdrRow.Item("Tax_Sched") = m_strTax_Sched
            pdrRow.Item("User_Def_Fld_1") = m_strUser_Def_Fld_1
            pdrRow.Item("User_Def_Fld_2") = m_strUser_Def_Fld_2
            pdrRow.Item("User_Def_Fld_3") = m_strUser_Def_Fld_3
            pdrRow.Item("User_Def_Fld_4") = m_strUser_Def_Fld_4
            pdrRow.Item("User_Def_Fld_5") = m_strUser_Def_Fld_5
            pdrRow.Item("Deter_Rate_By") = m_strDeter_Rate_By
            pdrRow.Item("Form_No") = m_bForm_No
            pdrRow.Item("Tax_Fg") = m_strTax_Fg
            pdrRow.Item("Sls_Mn_No") = m_strSls_Mn_No
            pdrRow.Item("Sls_Sb_No") = m_strSls_Sb_No
            pdrRow.Item("Sls_Dp_No") = m_strSls_Dp_No
            If m_dtOrd_Dt_Shipped.Year <> 1 Then pdrRow.Item("Ord_Dt_Shipped") = m_dtOrd_Dt_Shipped
            pdrRow.Item("Tot_Dollars") = m_decTot_Dollars
            pdrRow.Item("Mult_Loc_Fg") = m_strMult_Loc_Fg
            pdrRow.Item("Tot_Tax_Cost") = m_decTot_Tax_Cost
            pdrRow.Item("Hist_Load_Record") = m_strHist_Load_Record
            pdrRow.Item("Pre_Select_Status") = m_strPre_Select_Status
            pdrRow.Item("Packing_No") = m_intPacking_No
            pdrRow.Item("Deliv_Ar_Terms_Cd") = m_strDeliv_Ar_Terms_Cd
            pdrRow.Item("Inv_Batch_Id") = m_strInv_Batch_Id
            pdrRow.Item("Bill_To_No") = m_strBill_To_No
            pdrRow.Item("Rma_No") = m_strRma_No
            pdrRow.Item("Prog_Term_No") = m_intProg_Term_No
            pdrRow.Item("Extra_1") = m_strExtra_1
            pdrRow.Item("Extra_2") = m_strExtra_2
            pdrRow.Item("Extra_3") = m_strExtra_3
            pdrRow.Item("Extra_4") = m_strExtra_4
            pdrRow.Item("Extra_5") = m_strExtra_5
            pdrRow.Item("Extra_6") = m_strExtra_6
            pdrRow.Item("Extra_7") = m_strExtra_7
            pdrRow.Item("Extra_8") = m_strExtra_8
            pdrRow.Item("Extra_9") = m_strExtra_9
            pdrRow.Item("Extra_10") = m_decExtra_10
            pdrRow.Item("Extra_11") = m_decExtra_11
            pdrRow.Item("Extra_12") = m_decExtra_12
            pdrRow.Item("Extra_13") = m_decExtra_13
            pdrRow.Item("Extra_14") = m_intExtra_14
            pdrRow.Item("Extra_15") = m_intExtra_15
            pdrRow.Item("Edi_Doc_Seq") = m_intEdi_Doc_Seq
            pdrRow.Item("Contact_1") = m_strContact_1
            pdrRow.Item("Phone_Number") = m_strPhone_Number
            pdrRow.Item("Fax_Number") = m_strFax_Number
            pdrRow.Item("Email_Address") = m_strEmail_Address
            pdrRow.Item("Use_Email") = m_strUse_Email
            pdrRow.Item("Ship_To_City") = m_strShip_To_City
            pdrRow.Item("Ship_To_State") = m_strShip_To_State
            pdrRow.Item("Ship_To_Zip") = m_strShip_To_Zip
            pdrRow.Item("Bill_To_City") = m_strBill_To_City
            pdrRow.Item("Bill_To_State") = m_strBill_To_State
            pdrRow.Item("Bill_To_Zip") = m_strBill_To_Zip
            pdrRow.Item("Filler_0001") = m_strFiller_0001
            pdrRow.Item("Id") = m_decId
            pdrRow.Item("Ord_Guid") = m_strOrd_Guid
            pdrRow.Item("Userid") = m_strUserid
            pdrRow.Item("Ship_Link") = m_strShip_Link
            pdrRow.Item("Sendorderack") = m_intSendorderack
            pdrRow.Item("Contactview") = m_intContactview
            If m_dtExportts.Year <> 1 Then pdrRow.Item("Exportts") = m_dtExportts
            If m_dtMacolats.Year <> 1 Then pdrRow.Item("Macolats") = m_dtMacolats
            pdrRow.Item("Opents") = m_strOpents
            pdrRow.Item("Trigger_Message") = m_strTrigger_Message
            If m_dtTriggerts.Year <> 1 Then pdrRow.Item("Triggerts") = m_dtTriggerts
            pdrRow.Item("Email_Sent") = m_blnEmail_Sent
            pdrRow.Item("Orderacksaveonly") = m_blnOrderacksaveonly
            pdrRow.Item("Autocompletereship") = m_blnAutocompletereship
            pdrRow.Item("Repeatord_No") = m_strRepeatord_No
            pdrRow.Item("Ord_Language") = m_strOrd_Language

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Oei_Ordhdr " & _
            "WHERE  Id = " & m_decId & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Oei_Ordhdr WITH (Nolock) " & _
            "WHERE  Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pOei_Ord_No As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Oei_Ordhdr WITH (Nolock) " & _
            "WHERE  Oei_Ord_No = '" & pOei_Ord_No & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    'Private Sub Load(ByVal pOrd_Guid As String)

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String
    '        strSql = _
    '        "SELECT * " & _
    '        "FROM   Oei_Ordhdr WITH (Nolock) " & _
    '        "WHERE  Ord_Guid = '" & pOrd_Guid & "' "

    '        dt = db.DataTable(strSql)

    '        If dt.Rows.Count <> 0 Then
    '            Call LoadLine(dt.Rows(0))
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Oei_Ordhdr " & _
            "WHERE  Id = " & m_decId & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cOei_Ordhdr." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Ord_Type() As String
        Get
            Ord_Type = m_strOrd_Type
        End Get
        Set(ByVal value As String)
            m_strOrd_Type = value
        End Set
    End Property

    Public Property Ord_No() As String
        Get
            Ord_No = m_strOrd_No
        End Get
        Set(ByVal value As String)
            m_strOrd_No = value
        End Set
    End Property

    Public Property Oei_Ord_No() As String
        Get
            Oei_Ord_No = m_strOei_Ord_No
        End Get
        Set(ByVal value As String)
            m_strOei_Ord_No = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As String)
            m_strStatus = value
        End Set
    End Property

    Public Property Entered_Dt() As DateTime
        Get
            Entered_Dt = m_dtEntered_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtEntered_Dt = value
        End Set
    End Property

    Public Property Ord_Dt() As DateTime
        Get
            Ord_Dt = m_dtOrd_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtOrd_Dt = value
        End Set
    End Property

    Public Property Apply_To_No() As String
        Get
            Apply_To_No = m_strApply_To_No
        End Get
        Set(ByVal value As String)
            m_strApply_To_No = value
        End Set
    End Property

    Public Property Oe_Po_No() As String
        Get
            Oe_Po_No = m_strOe_Po_No
        End Get
        Set(ByVal value As String)
            m_strOe_Po_No = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Public Property Bal_Meth() As String
        Get
            Bal_Meth = m_strBal_Meth
        End Get
        Set(ByVal value As String)
            m_strBal_Meth = value
        End Set
    End Property

    Public Property Bill_To_Name() As String
        Get
            Bill_To_Name = m_strBill_To_Name
        End Get
        Set(ByVal value As String)
            m_strBill_To_Name = value
        End Set
    End Property

    Public Property Bill_To_Addr_1() As String
        Get
            Bill_To_Addr_1 = m_strBill_To_Addr_1
        End Get
        Set(ByVal value As String)
            m_strBill_To_Addr_1 = value
        End Set
    End Property

    Public Property Bill_To_Addr_2() As String
        Get
            Bill_To_Addr_2 = m_strBill_To_Addr_2
        End Get
        Set(ByVal value As String)
            m_strBill_To_Addr_2 = value
        End Set
    End Property

    Public Property Bill_To_Addr_3() As String
        Get
            Bill_To_Addr_3 = m_strBill_To_Addr_3
        End Get
        Set(ByVal value As String)
            m_strBill_To_Addr_3 = value
        End Set
    End Property

    Public Property Bill_To_Addr_4() As String
        Get
            Bill_To_Addr_4 = m_strBill_To_Addr_4
        End Get
        Set(ByVal value As String)
            m_strBill_To_Addr_4 = value
        End Set
    End Property

    Public Property Bill_To_Country() As String
        Get
            Bill_To_Country = m_strBill_To_Country
        End Get
        Set(ByVal value As String)
            m_strBill_To_Country = value
        End Set
    End Property

    Public Property Cus_Alt_Adr_Cd() As String
        Get
            Cus_Alt_Adr_Cd = m_strCus_Alt_Adr_Cd
        End Get
        Set(ByVal value As String)
            m_strCus_Alt_Adr_Cd = value
        End Set
    End Property

    Public Property Ship_To_Name() As String
        Get
            Ship_To_Name = m_strShip_To_Name
        End Get
        Set(ByVal value As String)
            m_strShip_To_Name = value
        End Set
    End Property

    Public Property Ship_To_Addr_1() As String
        Get
            Ship_To_Addr_1 = m_strShip_To_Addr_1
        End Get
        Set(ByVal value As String)
            m_strShip_To_Addr_1 = value
        End Set
    End Property

    Public Property Ship_To_Addr_2() As String
        Get
            Ship_To_Addr_2 = m_strShip_To_Addr_2
        End Get
        Set(ByVal value As String)
            m_strShip_To_Addr_2 = value
        End Set
    End Property

    Public Property Ship_To_Addr_3() As String
        Get
            Ship_To_Addr_3 = m_strShip_To_Addr_3
        End Get
        Set(ByVal value As String)
            m_strShip_To_Addr_3 = value
        End Set
    End Property

    Public Property Ship_To_Addr_4() As String
        Get
            Ship_To_Addr_4 = m_strShip_To_Addr_4
        End Get
        Set(ByVal value As String)
            m_strShip_To_Addr_4 = value
        End Set
    End Property

    Public Property Ship_To_Country() As String
        Get
            Ship_To_Country = m_strShip_To_Country
        End Get
        Set(ByVal value As String)
            m_strShip_To_Country = value
        End Set
    End Property

    Public Property Shipping_Dt() As DateTime
        Get
            Shipping_Dt = m_dtShipping_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtShipping_Dt = value
        End Set
    End Property

    Public Property Ship_Via_Cd() As String
        Get
            Ship_Via_Cd = m_strShip_Via_Cd
        End Get
        Set(ByVal value As String)
            m_strShip_Via_Cd = value
        End Set
    End Property

    Public Property Ar_Terms_Cd() As String
        Get
            Ar_Terms_Cd = m_strAr_Terms_Cd
        End Get
        Set(ByVal value As String)
            m_strAr_Terms_Cd = value
        End Set
    End Property

    Public Property Frt_Pay_Cd() As String
        Get
            Frt_Pay_Cd = m_strFrt_Pay_Cd
        End Get
        Set(ByVal value As String)
            m_strFrt_Pay_Cd = value
        End Set
    End Property

    Public Property Ship_Instruction_1() As String
        Get
            Ship_Instruction_1 = m_strShip_Instruction_1
        End Get
        Set(ByVal value As String)
            m_strShip_Instruction_1 = value
        End Set
    End Property

    Public Property Ship_Instruction_2() As String
        Get
            Ship_Instruction_2 = m_strShip_Instruction_2
        End Get
        Set(ByVal value As String)
            m_strShip_Instruction_2 = value
        End Set
    End Property

    Public Property Slspsn_No() As Int32
        Get
            Slspsn_No = m_intSlspsn_No
        End Get
        Set(ByVal value As Int32)
            m_intSlspsn_No = value
        End Set
    End Property

    Public Property Slspsn_Pct_Comm() As Decimal
        Get
            Slspsn_Pct_Comm = m_decSlspsn_Pct_Comm
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Pct_Comm = value
        End Set
    End Property

    Public Property Slspsn_Comm_Amt() As Decimal
        Get
            Slspsn_Comm_Amt = m_decSlspsn_Comm_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Comm_Amt = value
        End Set
    End Property

    Public Property Slspsn_No_2() As Int32
        Get
            Slspsn_No_2 = m_intSlspsn_No_2
        End Get
        Set(ByVal value As Int32)
            m_intSlspsn_No_2 = value
        End Set
    End Property

    Public Property Slspsn_Pct_Comm_2() As Decimal
        Get
            Slspsn_Pct_Comm_2 = m_decSlspsn_Pct_Comm_2
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Pct_Comm_2 = value
        End Set
    End Property

    Public Property Slspsn_Comm_Amt_2() As Decimal
        Get
            Slspsn_Comm_Amt_2 = m_decSlspsn_Comm_Amt_2
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Comm_Amt_2 = value
        End Set
    End Property

    Public Property Slspsn_No_3() As Int32
        Get
            Slspsn_No_3 = m_intSlspsn_No_3
        End Get
        Set(ByVal value As Int32)
            m_intSlspsn_No_3 = value
        End Set
    End Property

    Public Property Slspsn_Pct_Comm_3() As Decimal
        Get
            Slspsn_Pct_Comm_3 = m_decSlspsn_Pct_Comm_3
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Pct_Comm_3 = value
        End Set
    End Property

    Public Property Slspsn_Comm_Amt_3() As Decimal
        Get
            Slspsn_Comm_Amt_3 = m_decSlspsn_Comm_Amt_3
        End Get
        Set(ByVal value As Decimal)
            m_decSlspsn_Comm_Amt_3 = value
        End Set
    End Property

    Public Property Tax_Cd() As String
        Get
            Tax_Cd = m_strTax_Cd
        End Get
        Set(ByVal value As String)
            m_strTax_Cd = value
        End Set
    End Property

    Public Property Tax_Pct() As Decimal
        Get
            Tax_Pct = m_decTax_Pct
        End Get
        Set(ByVal value As Decimal)
            m_decTax_Pct = value
        End Set
    End Property

    Public Property Tax_Cd_2() As String
        Get
            Tax_Cd_2 = m_strTax_Cd_2
        End Get
        Set(ByVal value As String)
            m_strTax_Cd_2 = value
        End Set
    End Property

    Public Property Tax_Pct_2() As Decimal
        Get
            Tax_Pct_2 = m_decTax_Pct_2
        End Get
        Set(ByVal value As Decimal)
            m_decTax_Pct_2 = value
        End Set
    End Property

    Public Property Tax_Cd_3() As String
        Get
            Tax_Cd_3 = m_strTax_Cd_3
        End Get
        Set(ByVal value As String)
            m_strTax_Cd_3 = value
        End Set
    End Property

    Public Property Tax_Pct_3() As Decimal
        Get
            Tax_Pct_3 = m_decTax_Pct_3
        End Get
        Set(ByVal value As Decimal)
            m_decTax_Pct_3 = value
        End Set
    End Property

    Public Property Discount_Pct() As Decimal
        Get
            Discount_Pct = m_decDiscount_Pct
        End Get
        Set(ByVal value As Decimal)
            m_decDiscount_Pct = value
        End Set
    End Property

    Public Property Job_No() As String
        Get
            Job_No = m_strJob_No
        End Get
        Set(ByVal value As String)
            m_strJob_No = value
        End Set
    End Property

    Public Property Mfg_Loc() As String
        Get
            Mfg_Loc = m_strMfg_Loc
        End Get
        Set(ByVal value As String)
            m_strMfg_Loc = value
        End Set
    End Property

    Public Property Profit_Center() As String
        Get
            Profit_Center = m_strProfit_Center
        End Get
        Set(ByVal value As String)
            m_strProfit_Center = value
        End Set
    End Property

    Public Property Dept() As String
        Get
            Dept = m_strDept
        End Get
        Set(ByVal value As String)
            m_strDept = value
        End Set
    End Property

    Public Property Ar_Reference() As String
        Get
            Ar_Reference = m_strAr_Reference
        End Get
        Set(ByVal value As String)
            m_strAr_Reference = value
        End Set
    End Property

    Public Property Tot_Sls_Amt() As Decimal
        Get
            Tot_Sls_Amt = m_decTot_Sls_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Sls_Amt = value
        End Set
    End Property

    Public Property Tot_Sls_Disc() As Decimal
        Get
            Tot_Sls_Disc = m_decTot_Sls_Disc
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Sls_Disc = value
        End Set
    End Property

    Public Property Tot_Tax_Amt() As Decimal
        Get
            Tot_Tax_Amt = m_decTot_Tax_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Tax_Amt = value
        End Set
    End Property

    Public Property Tot_Cost() As Decimal
        Get
            Tot_Cost = m_decTot_Cost
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Cost = value
        End Set
    End Property

    Public Property Tot_Weight() As Decimal
        Get
            Tot_Weight = m_decTot_Weight
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Weight = value
        End Set
    End Property

    Public Property Misc_Amt() As Decimal
        Get
            Misc_Amt = m_decMisc_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decMisc_Amt = value
        End Set
    End Property

    Public Property Misc_Mn_No() As String
        Get
            Misc_Mn_No = m_strMisc_Mn_No
        End Get
        Set(ByVal value As String)
            m_strMisc_Mn_No = value
        End Set
    End Property

    Public Property Misc_Sb_No() As String
        Get
            Misc_Sb_No = m_strMisc_Sb_No
        End Get
        Set(ByVal value As String)
            m_strMisc_Sb_No = value
        End Set
    End Property

    Public Property Misc_Dp_No() As String
        Get
            Misc_Dp_No = m_strMisc_Dp_No
        End Get
        Set(ByVal value As String)
            m_strMisc_Dp_No = value
        End Set
    End Property

    Public Property Frt_Amt() As Decimal
        Get
            Frt_Amt = m_decFrt_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decFrt_Amt = value
        End Set
    End Property

    Public Property Frt_Mn_No() As String
        Get
            Frt_Mn_No = m_strFrt_Mn_No
        End Get
        Set(ByVal value As String)
            m_strFrt_Mn_No = value
        End Set
    End Property

    Public Property Frt_Sb_No() As String
        Get
            Frt_Sb_No = m_strFrt_Sb_No
        End Get
        Set(ByVal value As String)
            m_strFrt_Sb_No = value
        End Set
    End Property

    Public Property Frt_Dp_No() As String
        Get
            Frt_Dp_No = m_strFrt_Dp_No
        End Get
        Set(ByVal value As String)
            m_strFrt_Dp_No = value
        End Set
    End Property

    Public Property Sls_Tax_Amt_1() As Decimal
        Get
            Sls_Tax_Amt_1 = m_decSls_Tax_Amt_1
        End Get
        Set(ByVal value As Decimal)
            m_decSls_Tax_Amt_1 = value
        End Set
    End Property

    Public Property Sls_Tax_Amt_2() As Decimal
        Get
            Sls_Tax_Amt_2 = m_decSls_Tax_Amt_2
        End Get
        Set(ByVal value As Decimal)
            m_decSls_Tax_Amt_2 = value
        End Set
    End Property

    Public Property Sls_Tax_Amt_3() As Decimal
        Get
            Sls_Tax_Amt_3 = m_decSls_Tax_Amt_3
        End Get
        Set(ByVal value As Decimal)
            m_decSls_Tax_Amt_3 = value
        End Set
    End Property

    Public Property Comm_Pct() As Decimal
        Get
            Comm_Pct = m_decComm_Pct
        End Get
        Set(ByVal value As Decimal)
            m_decComm_Pct = value
        End Set
    End Property

    Public Property Comm_Amt() As Decimal
        Get
            Comm_Amt = m_decComm_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decComm_Amt = value
        End Set
    End Property

    Public Property Cmt_1() As String
        Get
            Cmt_1 = m_strCmt_1
        End Get
        Set(ByVal value As String)
            m_strCmt_1 = value
        End Set
    End Property

    Public Property Cmt_2() As String
        Get
            Cmt_2 = m_strCmt_2
        End Get
        Set(ByVal value As String)
            m_strCmt_2 = value
        End Set
    End Property

    Public Property Cmt_3() As String
        Get
            Cmt_3 = m_strCmt_3
        End Get
        Set(ByVal value As String)
            m_strCmt_3 = value
        End Set
    End Property

    Public Property Payment_Amt() As Decimal
        Get
            Payment_Amt = m_decPayment_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decPayment_Amt = value
        End Set
    End Property

    Public Property Payment_Disc_Amt() As Decimal
        Get
            Payment_Disc_Amt = m_decPayment_Disc_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decPayment_Disc_Amt = value
        End Set
    End Property

    Public Property Chk_No() As String
        Get
            Chk_No = m_strChk_No
        End Get
        Set(ByVal value As String)
            m_strChk_No = value
        End Set
    End Property

    Public Property Chk_Dt() As DateTime
        Get
            Chk_Dt = m_dtChk_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtChk_Dt = value
        End Set
    End Property

    Public Property Cash_Mn_No() As String
        Get
            Cash_Mn_No = m_strCash_Mn_No
        End Get
        Set(ByVal value As String)
            m_strCash_Mn_No = value
        End Set
    End Property

    Public Property Cash_Sb_No() As String
        Get
            Cash_Sb_No = m_strCash_Sb_No
        End Get
        Set(ByVal value As String)
            m_strCash_Sb_No = value
        End Set
    End Property

    Public Property Cash_Dp_No() As String
        Get
            Cash_Dp_No = m_strCash_Dp_No
        End Get
        Set(ByVal value As String)
            m_strCash_Dp_No = value
        End Set
    End Property

    Public Property Ord_Dt_Picked() As DateTime
        Get
            Ord_Dt_Picked = m_dtOrd_Dt_Picked
        End Get
        Set(ByVal value As DateTime)
            m_dtOrd_Dt_Picked = value
        End Set
    End Property

    Public Property Ord_Dt_Billed() As DateTime
        Get
            Ord_Dt_Billed = m_dtOrd_Dt_Billed
        End Get
        Set(ByVal value As DateTime)
            m_dtOrd_Dt_Billed = value
        End Set
    End Property

    Public Property Inv_No() As String
        Get
            Inv_No = m_strInv_No
        End Get
        Set(ByVal value As String)
            m_strInv_No = value
        End Set
    End Property

    Public Property Inv_Dt() As DateTime
        Get
            Inv_Dt = m_dtInv_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtInv_Dt = value
        End Set
    End Property

    Public Property Selection_Cd() As String
        Get
            Selection_Cd = m_strSelection_Cd
        End Get
        Set(ByVal value As String)
            m_strSelection_Cd = value
        End Set
    End Property

    Public Property Posted_Dt() As DateTime
        Get
            Posted_Dt = m_dtPosted_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtPosted_Dt = value
        End Set
    End Property

    Public Property Part_Posted_Fg() As String
        Get
            Part_Posted_Fg = m_strPart_Posted_Fg
        End Get
        Set(ByVal value As String)
            m_strPart_Posted_Fg = value
        End Set
    End Property

    Public Property Ship_To_Freefrm_Fg() As String
        Get
            Ship_To_Freefrm_Fg = m_strShip_To_Freefrm_Fg
        End Get
        Set(ByVal value As String)
            m_strShip_To_Freefrm_Fg = value
        End Set
    End Property

    Public Property Bill_To_Freefrm_Fg() As String
        Get
            Bill_To_Freefrm_Fg = m_strBill_To_Freefrm_Fg
        End Get
        Set(ByVal value As String)
            m_strBill_To_Freefrm_Fg = value
        End Set
    End Property

    Public Property Copy_To_Bm_Fg() As String
        Get
            Copy_To_Bm_Fg = m_strCopy_To_Bm_Fg
        End Get
        Set(ByVal value As String)
            m_strCopy_To_Bm_Fg = value
        End Set
    End Property

    Public Property Edi_Fg() As String
        Get
            Edi_Fg = m_strEdi_Fg
        End Get
        Set(ByVal value As String)
            m_strEdi_Fg = value
        End Set
    End Property

    Public Property Closed_Fg() As String
        Get
            Closed_Fg = m_strClosed_Fg
        End Get
        Set(ByVal value As String)
            m_strClosed_Fg = value
        End Set
    End Property

    Public Property Accum_Misc_Amt() As Decimal
        Get
            Accum_Misc_Amt = m_decAccum_Misc_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decAccum_Misc_Amt = value
        End Set
    End Property

    Public Property Accum_Frt_Amt() As Decimal
        Get
            Accum_Frt_Amt = m_decAccum_Frt_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decAccum_Frt_Amt = value
        End Set
    End Property

    Public Property Accum_Tot_Tax_Amt() As Decimal
        Get
            Accum_Tot_Tax_Amt = m_decAccum_Tot_Tax_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decAccum_Tot_Tax_Amt = value
        End Set
    End Property

    Public Property Accum_Sls_Tax_Amt() As Decimal
        Get
            Accum_Sls_Tax_Amt = m_decAccum_Sls_Tax_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decAccum_Sls_Tax_Amt = value
        End Set
    End Property

    Public Property Accum_Tot_Sls_Amt() As Decimal
        Get
            Accum_Tot_Sls_Amt = m_decAccum_Tot_Sls_Amt
        End Get
        Set(ByVal value As Decimal)
            m_decAccum_Tot_Sls_Amt = value
        End Set
    End Property

    Public Property Hold_Fg() As String
        Get
            Hold_Fg = m_strHold_Fg
        End Get
        Set(ByVal value As String)
            m_strHold_Fg = value
        End Set
    End Property

    Public Property Prepayment_Fg() As String
        Get
            Prepayment_Fg = m_strPrepayment_Fg
        End Get
        Set(ByVal value As String)
            m_strPrepayment_Fg = value
        End Set
    End Property

    Public Property Lost_Sale_Cd() As String
        Get
            Lost_Sale_Cd = m_strLost_Sale_Cd
        End Get
        Set(ByVal value As String)
            m_strLost_Sale_Cd = value
        End Set
    End Property

    Public Property Orig_Ord_Type() As String
        Get
            Orig_Ord_Type = m_strOrig_Ord_Type
        End Get
        Set(ByVal value As String)
            m_strOrig_Ord_Type = value
        End Set
    End Property

    Public Property Orig_Ord_Dt() As DateTime
        Get
            Orig_Ord_Dt = m_dtOrig_Ord_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtOrig_Ord_Dt = value
        End Set
    End Property

    Public Property Orig_Ord_No() As String
        Get
            Orig_Ord_No = m_strOrig_Ord_No
        End Get
        Set(ByVal value As String)
            m_strOrig_Ord_No = value
        End Set
    End Property

    Public Property Award_Probability() As Byte
        Get
            Award_Probability = m_bAward_Probability
        End Get
        Set(ByVal value As Byte)
            m_bAward_Probability = value
        End Set
    End Property

    Public Property Oe_Cash_No() As String
        Get
            Oe_Cash_No = m_strOe_Cash_No
        End Get
        Set(ByVal value As String)
            m_strOe_Cash_No = value
        End Set
    End Property

    Public Property Exch_Rt_Fg() As String
        Get
            Exch_Rt_Fg = m_strExch_Rt_Fg
        End Get
        Set(ByVal value As String)
            m_strExch_Rt_Fg = value
        End Set
    End Property

    Public Property Curr_Cd() As String
        Get
            Curr_Cd = m_strCurr_Cd
        End Get
        Set(ByVal value As String)
            m_strCurr_Cd = value
        End Set
    End Property

    Public Property Orig_Trx_Rt() As Decimal
        Get
            Orig_Trx_Rt = m_decOrig_Trx_Rt
        End Get
        Set(ByVal value As Decimal)
            m_decOrig_Trx_Rt = value
        End Set
    End Property

    Public Property Curr_Trx_Rt() As Decimal
        Get
            Curr_Trx_Rt = m_decCurr_Trx_Rt
        End Get
        Set(ByVal value As Decimal)
            m_decCurr_Trx_Rt = value
        End Set
    End Property

    Public Property Tax_Sched() As String
        Get
            Tax_Sched = m_strTax_Sched
        End Get
        Set(ByVal value As String)
            m_strTax_Sched = value
        End Set
    End Property

    Public Property User_Def_Fld_1() As String
        Get
            User_Def_Fld_1 = m_strUser_Def_Fld_1
        End Get
        Set(ByVal value As String)
            m_strUser_Def_Fld_1 = value
        End Set
    End Property

    Public Property User_Def_Fld_2() As String
        Get
            User_Def_Fld_2 = m_strUser_Def_Fld_2
        End Get
        Set(ByVal value As String)
            m_strUser_Def_Fld_2 = value
        End Set
    End Property

    Public Property User_Def_Fld_3() As String
        Get
            User_Def_Fld_3 = m_strUser_Def_Fld_3
        End Get
        Set(ByVal value As String)
            m_strUser_Def_Fld_3 = value
        End Set
    End Property

    Public Property User_Def_Fld_4() As String
        Get
            User_Def_Fld_4 = m_strUser_Def_Fld_4
        End Get
        Set(ByVal value As String)
            m_strUser_Def_Fld_4 = value
        End Set
    End Property

    Public Property User_Def_Fld_5() As String
        Get
            User_Def_Fld_5 = m_strUser_Def_Fld_5
        End Get
        Set(ByVal value As String)
            m_strUser_Def_Fld_5 = value
        End Set
    End Property

    Public Property Deter_Rate_By() As String
        Get
            Deter_Rate_By = m_strDeter_Rate_By
        End Get
        Set(ByVal value As String)
            m_strDeter_Rate_By = value
        End Set
    End Property

    Public Property Form_No() As Byte
        Get
            Form_No = m_bForm_No
        End Get
        Set(ByVal value As Byte)
            m_bForm_No = value
        End Set
    End Property

    Public Property Tax_Fg() As String
        Get
            Tax_Fg = m_strTax_Fg
        End Get
        Set(ByVal value As String)
            m_strTax_Fg = value
        End Set
    End Property

    Public Property Sls_Mn_No() As String
        Get
            Sls_Mn_No = m_strSls_Mn_No
        End Get
        Set(ByVal value As String)
            m_strSls_Mn_No = value
        End Set
    End Property

    Public Property Sls_Sb_No() As String
        Get
            Sls_Sb_No = m_strSls_Sb_No
        End Get
        Set(ByVal value As String)
            m_strSls_Sb_No = value
        End Set
    End Property

    Public Property Sls_Dp_No() As String
        Get
            Sls_Dp_No = m_strSls_Dp_No
        End Get
        Set(ByVal value As String)
            m_strSls_Dp_No = value
        End Set
    End Property

    Public Property Ord_Dt_Shipped() As DateTime
        Get
            Ord_Dt_Shipped = m_dtOrd_Dt_Shipped
        End Get
        Set(ByVal value As DateTime)
            m_dtOrd_Dt_Shipped = value
        End Set
    End Property

    Public Property Tot_Dollars() As Decimal
        Get
            Tot_Dollars = m_decTot_Dollars
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Dollars = value
        End Set
    End Property

    Public Property Mult_Loc_Fg() As String
        Get
            Mult_Loc_Fg = m_strMult_Loc_Fg
        End Get
        Set(ByVal value As String)
            m_strMult_Loc_Fg = value
        End Set
    End Property

    Public Property Tot_Tax_Cost() As Decimal
        Get
            Tot_Tax_Cost = m_decTot_Tax_Cost
        End Get
        Set(ByVal value As Decimal)
            m_decTot_Tax_Cost = value
        End Set
    End Property

    Public Property Hist_Load_Record() As String
        Get
            Hist_Load_Record = m_strHist_Load_Record
        End Get
        Set(ByVal value As String)
            m_strHist_Load_Record = value
        End Set
    End Property

    Public Property Pre_Select_Status() As String
        Get
            Pre_Select_Status = m_strPre_Select_Status
        End Get
        Set(ByVal value As String)
            m_strPre_Select_Status = value
        End Set
    End Property

    Public Property Packing_No() As Int32
        Get
            Packing_No = m_intPacking_No
        End Get
        Set(ByVal value As Int32)
            m_intPacking_No = value
        End Set
    End Property

    Public Property Deliv_Ar_Terms_Cd() As String
        Get
            Deliv_Ar_Terms_Cd = m_strDeliv_Ar_Terms_Cd
        End Get
        Set(ByVal value As String)
            m_strDeliv_Ar_Terms_Cd = value
        End Set
    End Property

    Public Property Inv_Batch_Id() As String
        Get
            Inv_Batch_Id = m_strInv_Batch_Id
        End Get
        Set(ByVal value As String)
            m_strInv_Batch_Id = value
        End Set
    End Property

    Public Property Bill_To_No() As String
        Get
            Bill_To_No = m_strBill_To_No
        End Get
        Set(ByVal value As String)
            m_strBill_To_No = value
        End Set
    End Property

    Public Property Rma_No() As String
        Get
            Rma_No = m_strRma_No
        End Get
        Set(ByVal value As String)
            m_strRma_No = value
        End Set
    End Property

    Public Property Prog_Term_No() As Int32
        Get
            Prog_Term_No = m_intProg_Term_No
        End Get
        Set(ByVal value As Int32)
            m_intProg_Term_No = value
        End Set
    End Property

    Public Property Extra_1() As String
        Get
            Extra_1 = m_strExtra_1
        End Get
        Set(ByVal value As String)
            m_strExtra_1 = value
        End Set
    End Property

    Public Property Extra_2() As String
        Get
            Extra_2 = m_strExtra_2
        End Get
        Set(ByVal value As String)
            m_strExtra_2 = value
        End Set
    End Property

    Public Property Extra_3() As String
        Get
            Extra_3 = m_strExtra_3
        End Get
        Set(ByVal value As String)
            m_strExtra_3 = value
        End Set
    End Property

    Public Property Extra_4() As String
        Get
            Extra_4 = m_strExtra_4
        End Get
        Set(ByVal value As String)
            m_strExtra_4 = value
        End Set
    End Property

    Public Property Extra_5() As String
        Get
            Extra_5 = m_strExtra_5
        End Get
        Set(ByVal value As String)
            m_strExtra_5 = value
        End Set
    End Property

    Public Property Extra_6() As String
        Get
            Extra_6 = m_strExtra_6
        End Get
        Set(ByVal value As String)
            m_strExtra_6 = value
        End Set
    End Property

    Public Property Extra_7() As String
        Get
            Extra_7 = m_strExtra_7
        End Get
        Set(ByVal value As String)
            m_strExtra_7 = value
        End Set
    End Property

    Public Property Extra_8() As String
        Get
            Extra_8 = m_strExtra_8
        End Get
        Set(ByVal value As String)
            m_strExtra_8 = value
        End Set
    End Property

    Public Property Extra_9() As String
        Get
            Extra_9 = m_strExtra_9
        End Get
        Set(ByVal value As String)
            m_strExtra_9 = value
        End Set
    End Property

    Public Property Extra_10() As Decimal
        Get
            Extra_10 = m_decExtra_10
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_10 = value
        End Set
    End Property

    Public Property Extra_11() As Decimal
        Get
            Extra_11 = m_decExtra_11
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_11 = value
        End Set
    End Property

    Public Property Extra_12() As Decimal
        Get
            Extra_12 = m_decExtra_12
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_12 = value
        End Set
    End Property

    Public Property Extra_13() As Decimal
        Get
            Extra_13 = m_decExtra_13
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_13 = value
        End Set
    End Property

    Public Property Extra_14() As Int32
        Get
            Extra_14 = m_intExtra_14
        End Get
        Set(ByVal value As Int32)
            m_intExtra_14 = value
        End Set
    End Property

    Public Property Extra_15() As Int32
        Get
            Extra_15 = m_intExtra_15
        End Get
        Set(ByVal value As Int32)
            m_intExtra_15 = value
        End Set
    End Property

    Public Property Edi_Doc_Seq() As Int16
        Get
            Edi_Doc_Seq = m_intEdi_Doc_Seq
        End Get
        Set(ByVal value As Int16)
            m_intEdi_Doc_Seq = value
        End Set
    End Property

    Public Property Contact_1() As String
        Get
            Contact_1 = m_strContact_1
        End Get
        Set(ByVal value As String)
            m_strContact_1 = value
        End Set
    End Property

    Public Property Phone_Number() As String
        Get
            Phone_Number = m_strPhone_Number
        End Get
        Set(ByVal value As String)
            m_strPhone_Number = value
        End Set
    End Property

    Public Property Fax_Number() As String
        Get
            Fax_Number = m_strFax_Number
        End Get
        Set(ByVal value As String)
            m_strFax_Number = value
        End Set
    End Property

    Public Property Email_Address() As String
        Get
            Email_Address = m_strEmail_Address
        End Get
        Set(ByVal value As String)
            m_strEmail_Address = value
        End Set
    End Property

    Public Property Use_Email() As String
        Get
            Use_Email = m_strUse_Email
        End Get
        Set(ByVal value As String)
            m_strUse_Email = value
        End Set
    End Property

    Public Property Ship_To_City() As String
        Get
            Ship_To_City = m_strShip_To_City
        End Get
        Set(ByVal value As String)
            m_strShip_To_City = value
        End Set
    End Property

    Public Property Ship_To_State() As String
        Get
            Ship_To_State = m_strShip_To_State
        End Get
        Set(ByVal value As String)
            m_strShip_To_State = value
        End Set
    End Property

    Public Property Ship_To_Zip() As String
        Get
            Ship_To_Zip = m_strShip_To_Zip
        End Get
        Set(ByVal value As String)
            m_strShip_To_Zip = value
        End Set
    End Property

    Public Property Bill_To_City() As String
        Get
            Bill_To_City = m_strBill_To_City
        End Get
        Set(ByVal value As String)
            m_strBill_To_City = value
        End Set
    End Property

    Public Property Bill_To_State() As String
        Get
            Bill_To_State = m_strBill_To_State
        End Get
        Set(ByVal value As String)
            m_strBill_To_State = value
        End Set
    End Property

    Public Property Bill_To_Zip() As String
        Get
            Bill_To_Zip = m_strBill_To_Zip
        End Get
        Set(ByVal value As String)
            m_strBill_To_Zip = value
        End Set
    End Property

    Public Property Filler_0001() As String
        Get
            Filler_0001 = m_strFiller_0001
        End Get
        Set(ByVal value As String)
            m_strFiller_0001 = value
        End Set
    End Property

    Public Property Id() As Integer
        Get
            Id = m_decId
        End Get
        Set(ByVal value As Integer)
            m_decId = value
        End Set
    End Property

    Public Property Ord_Guid() As String
        Get
            Ord_Guid = m_strOrd_Guid
        End Get
        Set(ByVal value As String)
            m_strOrd_Guid = value
        End Set
    End Property

    Public Property Userid() As String
        Get
            Userid = m_strUserid
        End Get
        Set(ByVal value As String)
            m_strUserid = value
        End Set
    End Property

    Public Property Ship_Link() As String
        Get
            Ship_Link = m_strShip_Link
        End Get
        Set(ByVal value As String)
            m_strShip_Link = value
        End Set
    End Property

    Public Property Sendorderack() As Int32
        Get
            Sendorderack = m_intSendorderack
        End Get
        Set(ByVal value As Int32)
            m_intSendorderack = value
        End Set
    End Property

    Public Property Contactview() As Int32
        Get
            Contactview = m_intContactview
        End Get
        Set(ByVal value As Int32)
            m_intContactview = value
        End Set
    End Property

    Public Property Exportts() As DateTime
        Get
            Exportts = m_dtExportts
        End Get
        Set(ByVal value As DateTime)
            m_dtExportts = value
        End Set
    End Property

    Public Property Macolats() As DateTime
        Get
            Macolats = m_dtMacolats
        End Get
        Set(ByVal value As DateTime)
            m_dtMacolats = value
        End Set
    End Property

    Public Property Opents() As String
        Get
            Opents = m_strOpents
        End Get
        Set(ByVal value As String)
            m_strOpents = value
        End Set
    End Property

    Public Property Trigger_Message() As String
        Get
            Trigger_Message = m_strTrigger_Message
        End Get
        Set(ByVal value As String)
            m_strTrigger_Message = value
        End Set
    End Property

    Public Property Triggerts() As DateTime
        Get
            Triggerts = m_dtTriggerts
        End Get
        Set(ByVal value As DateTime)
            m_dtTriggerts = value
        End Set
    End Property

    Public Property Email_Sent() As Boolean
        Get
            Email_Sent = m_blnEmail_Sent
        End Get
        Set(ByVal value As Boolean)
            m_blnEmail_Sent = value
        End Set
    End Property

    Public Property Orderacksaveonly() As Boolean
        Get
            Orderacksaveonly = m_blnOrderacksaveonly
        End Get
        Set(ByVal value As Boolean)
            m_blnOrderacksaveonly = value
        End Set
    End Property

    Public Property Autocompletereship() As Boolean
        Get
            Autocompletereship = m_blnAutocompletereship
        End Get
        Set(ByVal value As Boolean)
            m_blnAutocompletereship = value
        End Set
    End Property

    Public Property Repeatord_No() As String
        Get
            Repeatord_No = m_strRepeatord_No
        End Get
        Set(ByVal value As String)
            m_strRepeatord_No = value
        End Set
    End Property

    Public Property Ord_Language() As String
        Get
            Ord_Language = m_strOrd_Language
        End Get
        Set(ByVal value As String)
            m_strOrd_Language = value
        End Set
    End Property

#End Region


End Class ' cOei_Ordhdr



