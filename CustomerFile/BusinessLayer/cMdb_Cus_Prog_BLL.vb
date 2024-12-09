Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop

Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.Drawing

Public Class cMdb_Cus_Prog_BUS
    Dim arrDocId() As Int32
    ' Handle to the Mdb_Cus_Prog DBAccess class
    Private oMdb_Cus_Prog_DA As cMdb_Cus_Prog_DAL = Nothing


    Public Sub New()
        oMdb_Cus_Prog_DA = New cMdb_Cus_Prog_DAL()

    End Sub


    '' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Cus_Prog)
    '    Return oMdb_Cus_Prog_DA.GetList()
    'End Function

    '++ID 03.08.2015 added this function only for display the programs(Programs,Special Pricing)
    Public Function LoadPSQ(ByVal piCus_Prog_Id As Integer) As cMdb_Cus_Prog

        LoadPSQ = oMdb_Cus_Prog_DA.Load(piCus_Prog_Id)
        LoadPSQ.Revision = Get_Revision(LoadPSQ)
        '  If Load.Revision.Cus_Prog_Rev_ID = 0 Then Create_Revision_From_Program(Load)

        If LoadPSQ.Revision.Cus_Prog_Rev_ID = 0 Then
            Create_Revision_From_Program(LoadPSQ)
        End If


    End Function

    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Prog_Id As Integer) As cMdb_Cus_Prog

        Load = oMdb_Cus_Prog_DA.Load(piCus_Prog_Id)
        Load.Revision = Get_Revision(Load)
        '  If Load.Revision.Cus_Prog_Rev_ID = 0 Then Create_Revision_From_Program(Load)

        If Load.Revision.Cus_Prog_Rev_ID = 0 Then
            Create_Revision_From_Program(Load)
        Else
            '++ID added 02.05.2015 'else' also added
            Create_Revision_From_Program_Update(Load)
            '---------------------
        End If


    End Function


    Public Function Load(ByVal pstrCus_Spector_Cd As String) As cMdb_Cus_Prog

        Load = oMdb_Cus_Prog_DA.Load(pstrCus_Spector_Cd)
        Load.Revision = Get_Revision(Load)
        If Load.Revision.Cus_Prog_Rev_ID = 0 Then Create_Revision_From_Program(Load)

    End Function


    ' Insert current element in the database 
    Public Function Save(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
        Return oMdb_Cus_Prog_DA.Save(oMdb_Cus_Prog)
    End Function


    ' Delete element with ID specified from the database 
    Public Function Delete(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
        Return oMdb_Cus_Prog_DA.Delete(oMdb_Cus_Prog)
    End Function


    Public Sub CopyFromRevision(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog)

        If oMdb_Cus_Prog.Revision Is Nothing Then Exit Sub

        oMdb_Cus_Prog.Prog_Cd = oMdb_Cus_Prog.Revision.Program
        oMdb_Cus_Prog.Imprint = oMdb_Cus_Prog.Revision.Imprint
        oMdb_Cus_Prog.Start_Dt = oMdb_Cus_Prog.Revision.Start_Dt
        oMdb_Cus_Prog.End_Dt = oMdb_Cus_Prog.Revision.End_Dt
        oMdb_Cus_Prog.Contact_ID = oMdb_Cus_Prog.Revision.Cicntp_ID
        oMdb_Cus_Prog.Prog_CSR = oMdb_Cus_Prog.Revision.Prog_CSR
        oMdb_Cus_Prog.For_All_Accounts = oMdb_Cus_Prog.For_All_Accounts

    End Sub


    ' Delete element with ID specified from the database 
    'Public Function Delete(ByVal piCus_Prog_Id As Integer) As Boolean
    '    Return oMdb_Cus_Prog_DA.Delete(piCus_Prog_Id)
    'End Function

    '' Update current element in the database 
    'Public Function Update(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
    '    Return oMdb_Cus_Prog_DA.Save(oMdb_Cus_Prog)
    'End Function

    ' Validate current element 
    Public Function Validate(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
        Return True
    End Function

    'Public Function GetRenew_From_ID(oMdb_Cus_Prog As cMdb_Cus_Prog) As Integer
    '    Dim strSql As String
    '    Dim db As New cDBA
    '    Dim dt As DataTable

    '    strSql = "SELECT * FROM "
    'End Function

    '' Validate current element 
    'Public Function Validate(oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean

    'End Function

    'Public Function Get_Next_Spector_Cd(ByVal pDate As Date) As String

    '    Dim strProg_Date_Cd As String = (pDate.Year - 2000).ToString.PadLeft(2, "0") + (pDate.Month).ToString.PadLeft(2, "0")
    '    Dim oProg_Count As New cMdb_Cus_Prog_Count(strProg_Date_Cd)

    '    oProg_Count.Prog_Count += 1
    '    oProg_Count.Save()

    '    Get_Next_Spector_Cd = strProg_Date_Cd + "-" + oProg_Count.Prog_Count.ToString.PadLeft(3, "0")

    '    oProg_Count = Nothing

    'End Function

    Public Function Get_Next_Spector_Cd(ByRef oProgram As cMdb_Cus_Prog) As String

        If oProgram.Spector_Cd = String.Empty Then
            Get_Next_Spector_Cd = New cMdb_Cus_Prog_Count(oProgram).Set_Next_Prog_Count()
        Else
            Get_Next_Spector_Cd = oProgram.Spector_Cd
        End If
        'Dim oProg_Count As New cMdb_Cus_Prog_Count(oProgram)
        'Get_Next_Spector_Cd = oProg_Count.Set_Next_Prog_Count()

        'oProg_Count = Nothing

    End Function

    Public Sub Init(ByRef oCus_Prog As cMdb_Cus_Prog)

        Try

            With oCus_Prog

                .Approved_By_Them = String.Empty
                .Approved_By_Us = String.Empty
                .Approved_Dt = NoDate()
                .Cus_No = String.Empty
                .Cus_Prog_Guid = String.Empty
                .Cus_Prog_Id = 0
                .End_Dt = NoDate()
                .Eqp_Column = 0
                .Eqp_Level = 0
                .Eqp_Pct = 0
                .Prog_Cd = String.Empty
                '.Prog_Desc = String.Empty
                .Imprint = String.Empty
                .Prog_CSR = String.Empty
                .No_End_Date = False
                .Prog_Type = 0
                .Renew_To_Cus_Prog_Id = 0
                .Spector_Cd = String.Empty
                .Prog_Comments = String.Empty
                .Start_Dt = NoDate()
                .Update_TS = NoDate()
                .User_Login = ""
                .Quote_Type_ID = 0
                .Quote_Ship_Method_ID = 0
                .Quote_Step_ID = Quote_Step.New_Quote
                .Quote_Step_User = String.Empty
                .Contact_ID = 0
                .One_Shot = False
                .Ord_No = String.Empty
                .Create_By = String.Empty
                .Current_Rev_No = 0
                .Auto_Renew = False
                .Renew_Dt = NoDate()
                .Renew_End_Dt = NoDate()
                .Renew_Sent = False
                .For_All_Accounts = False

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Clone(ByRef oSource As cMdb_Cus_Prog) As cMdb_Cus_Prog

        ' Clones everything BUT the primary key
        Dim oClone As New cMdb_Cus_Prog

        oClone.Approved_By_Them = oSource.Approved_By_Them
        oClone.Approved_By_Us = oSource.Approved_By_Us
        oClone.Approved_Dt = oSource.Approved_Dt
        oClone.Cus_No = oSource.Cus_No
        oClone.Cus_Prog_Guid = oSource.Cus_Prog_Guid
        oClone.Cus_Prog_Id = oSource.Cus_Prog_Id
        oClone.End_Dt = oSource.End_Dt
        oClone.Eqp_Column = oSource.Eqp_Column
        oClone.Eqp_Level = oSource.Eqp_Level
        oClone.Eqp_Pct = oSource.Eqp_Pct
        oClone.Prog_Cd = oSource.Prog_Cd
        'oClone.Prog_Desc = oSource.Prog_Desc
        oClone.Imprint = oSource.Imprint
        oClone.Prog_CSR = oSource.Prog_CSR
        oClone.No_End_Date = oSource.No_End_Date
        oClone.Prog_Type = oSource.Prog_Type
        oClone.Renew_To_Cus_Prog_Id = oSource.Renew_To_Cus_Prog_Id
        oClone.Spector_Cd = oSource.Spector_Cd
        oClone.Prog_Comments = oSource.Prog_Comments
        oClone.Start_Dt = oSource.Start_Dt
        oClone.Update_TS = oSource.Update_TS
        oClone.User_Login = oSource.User_Login
        oClone.Quote_Type_ID = oSource.Quote_Type_ID
        oClone.Quote_Ship_Method_ID = oSource.Quote_Ship_Method_ID
        oClone.Quote_Step_ID = oSource.Quote_Step_ID
        oClone.Quote_Step_User = oSource.Quote_Step_User
        oClone.Contact_ID = oSource.Contact_ID
        oClone.One_Shot = oSource.One_Shot
        oClone.Ord_No = oSource.Ord_No
        oClone.Current_Rev_No = oSource.Current_Rev_No
        oClone.For_All_Accounts = oSource.For_All_Accounts

        oClone.Create_By = Environment.UserName
        oClone.User_Login = Environment.UserName
        oClone.Create_TS = Date.Now
        oClone.Update_TS = Date.Now

        Return oClone

    End Function


    Public Function Get_Quote_Type(ByVal piID As Integer) As String

        ' MDB_CFG_ENUM

        Dim strValue As String = ""

        Select Case piID
            'Case 1
            '    strValue = "Extended Needs Special Price"
            'Case 2
            '    strValue = "Overseas Past Extended"
            Case 1
                strValue = "Domestic"
            Case 2
                strValue = "Overseas"
            Case 3
                strValue = "Custom"
                'Case 1
                '    strValue = "Extended"
                'Case 2
                '    strValue = "Needs Special Price"
                'Case 3
                '    strValue = "Overseas"
                'Case 4
                '    strValue = "Past Extended"
        End Select

        Get_Quote_Type = strValue

    End Function

    Public Function Get_Quote_Type(ByVal pstrDesc As String) As Integer

        Dim iValue As Integer = 0

        Select Case pstrDesc
            Case "Domestic"
                iValue = 1
            Case "Overseas"
                iValue = 2
            Case "Custom"
                iValue = 3
                'Case "Past Extended"
                '    iValue = 4
                'Case "Extended Needs Special Price"
                '    iValue = 1
                'Case "Overseas Past Extended"
                '    iValue = 2
        End Select

        Get_Quote_Type = iValue

    End Function

    Public Function Get_Quote_Ship_Method(ByVal piID As Integer) As String

        Dim strValue As String = ""

        Select Case piID
            Case 1
                strValue = "Air"
            Case 2
                strValue = "Ground"
            Case 3
                strValue = "Sea"
        End Select

        Get_Quote_Ship_Method = strValue

    End Function

    Public Function Get_Quote_Ship_Method(ByVal pstrDesc As String) As Integer

        Dim iValue As Integer = 0

        Select Case pstrDesc
            Case "Air"
                iValue = 1
            Case "Ground"
                iValue = 2
            Case "Sea"
                iValue = 3

        End Select

        Get_Quote_Ship_Method = iValue

    End Function

    Public Function Get_Quote_Step(ByVal piID As Integer) As String

        Dim strValue As String = ""

        Select Case piID
            Case Quote_Step.New_Quote
                strValue = "New Quote"
            Case Quote_Step.Saved_Quote
                strValue = "Saved Quote"
            Case Quote_Step.Pending_Pricing_Approval
                strValue = "Pending Pricing Approval"
            Case Quote_Step.Pricing_Approved
                strValue = "Pricing Approved"
            Case Quote_Step.Ready_To_Send
                strValue = "Quote Ready To Send"
            Case Quote_Step.Sent_To_Customer
                strValue = "Quote Sent To Customer"
        End Select

        Get_Quote_Step = strValue

    End Function

    Public Function Get_Quote_Next_Step(ByVal piID As Integer) As String

        Dim strValue As String = ""

        Select Case piID
            Case Quote_Step.New_Quote
                strValue = "Save Quote"
            Case Quote_Step.Saved_Quote
                'strValue = "Request Pricing Approval"   'justin 20220902  comment for ticket 28237
                strValue = "Complete Quote"    'justin add for ticket 28237 : no need step: approve pricing
            Case Quote_Step.Pending_Pricing_Approval
                'strValue = "Approve Pricing"    'justin 20220902  comment for ticket 28237
                strValue = "Complete Quote"    'justin add for ticket 28237 : no need step: approve pricing
            Case Quote_Step.Pricing_Approved
                strValue = "Complete Quote"
            Case Quote_Step.Ready_To_Send
                strValue = "Export File To Customer"
            Case Quote_Step.Sent_To_Customer
                strValue = "Quote Sent To Customer"
        End Select

        Get_Quote_Next_Step = strValue

    End Function

    Public Function Get_Quote_Step(ByVal pstrDesc As String) As Integer

        Dim iValue As Integer = 0

        Select Case pstrDesc
            Case "New Quote"
                iValue = Quote_Step.New_Quote
            Case "Saved Quote"
                iValue = Quote_Step.Saved_Quote
            Case "Pending Pricing Approval"
                iValue = Quote_Step.Pending_Pricing_Approval
            Case "Pricing Approved"
                iValue = Quote_Step.Pricing_Approved
            Case "Quote Ready To Send"
                iValue = Quote_Step.Ready_To_Send
            Case "Quote Sent To Customer"
                iValue = Quote_Step.Sent_To_Customer

        End Select

        Get_Quote_Step = iValue

    End Function

    Public Function Get_Quote_Next_Step(ByVal pstrDesc As String) As Integer

        Dim iValue As Integer = 0

        Select Case pstrDesc
            'Case Quote_Step.New_Quote
            Case "New Quote"
                iValue = Quote_Step.Saved_Quote
            Case "Save Quote"
                'iValue = Quote_Step.Pending_Pricing_Approval  'justin 20220902  comment for ticket 28237
                iValue = Quote_Step.Pricing_Approved  'justin add for ticket 28237 : no need step: approve pricing
            Case "Request Pricing Approval"
                iValue = Quote_Step.Pricing_Approved
            Case "Approve Pricing"
                iValue = Quote_Step.Ready_To_Send
            Case "Complete Quote"
                iValue = Quote_Step.New_Quote
            Case "Export File To Customer"
                iValue = Quote_Step.New_Quote
            Case "Quote Sent To Customer"
                iValue = Quote_Step.New_Quote
        End Select

        Get_Quote_Next_Step = iValue

    End Function

    Public Function Get_Quote_Step_ComboList() As DataTable

        Get_Quote_Step_ComboList = oMdb_Cus_Prog_DA.Get_Quote_Step_ComboList()

    End Function

    Public Function Get_Quote_Type_ComboList() As DataTable

        Get_Quote_Type_ComboList = oMdb_Cus_Prog_DA.Get_Quote_Type_ComboList()

    End Function

    Public Function Get_Quote_Ship_Method_ComboList() As DataTable

        Get_Quote_Ship_Method_ComboList = oMdb_Cus_Prog_DA.Get_Quote_Ship_Method_ComboList()

    End Function

    Public Sub Create_Excel_Program_Report(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog, ByRef oCustomer As cCustomer)

        Dim errPos As Integer
        Dim oPriceBLL As New cOEPrcFil_Sql_BLL

        Dim strDecorating As String = ""


        Dim colExcelProcessID As New Collection
        Dim MyExcelProcessID As Integer = 0

        Dim msExcelProcesses As Process() = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                colExcelProcessID.Add(oProcess.Id.ToString, oProcess.Id.ToString)
            Next
        End If

        errPos = 1
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        msExcelProcesses = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                If Not (colExcelProcessID.Contains(oProcess.Id.ToString)) Then MyExcelProcessID = oProcess.Id
            Next
        End If

        Dim xlWorkBook As Excel.Workbook
        'Dim xlWorkSheet As Object = Nothing
        'Dim IStartedXL As Boolean

        errPos = 4
        Dim misValue As Object = System.Reflection.Missing.Value

        'Try
        '    xlApp = GetObject(, "excel.application")
        'Catch ex As Exception
        'End Try

        'If xlApp Is Nothing Then
        '    xlApp = CreateObject("excel.application")
        '    IStartedXL = True
        'End If

        xlWorkBook = xlApp.Workbooks.Add

        'Dim a1 As Excel.Range
        'Dim a2 As Excel.Interior
        'Dim a3 As Excel.CellFormat

        'Dim oCellGreyInterior As Excel.Interior '= Nothing
        'Dim oRange As Excel.Range '= Nothing

        Try

            Dim dtHeader As DataTable
            Dim dtItems As DataTable
            Dim dtItemsDetails As DataTable
            Dim dtOptions As DataTable
            Dim db As New cDBA()
            Dim strCurrency As String = ""

            dtHeader = db.DataTable("select * from mdb_cus_prog_quote_view  where CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id)

            '++ID 10.19.2018 added validate DataTable (dtHeader) and added variable Currency for dipslay Section 3
            If dtHeader.Rows.Count = 0 Then Exit Sub

            strCurrency = Trim(dtHeader.Rows(0).Item("Currency").ToString)


            errPos = 6
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkBook.Styles("Normal").Font.Name = "Arial"
            errPos = 7
            'xlWorkSheet = xlWorkBook.Sheets(1)
            errPos = 8

            'SetPrintingProperties(xlWorkBook.Sheets(1))

            With xlWorkBook.Sheets(1)

                'Set Column width ' 130

                .Range("A:A").ColumnWidth = 2.63
                .Range("B:B").ColumnWidth = 11
                .Range("C:C").ColumnWidth = 12 ' 66
                .Range("D:D").ColumnWidth = 18
                .Range("E:E").ColumnWidth = 18
                .Range("F:F").ColumnWidth = 11
                .Range("G:G").ColumnWidth = 11
                .Range("H:H").ColumnWidth = 11
                .Range("I:I").ColumnWidth = 11
                .Range("J:J").ColumnWidth = 8.88
                .Range("K:K").ColumnWidth = 8.88
                .Range("L:L").ColumnWidth = 8.88


                ' .Range("I:I").ColumnWidth = 18
                '  .Range("J:J").ColumnWidth = 2.89

                .Range("A1").RowHeight = 75

                Dim oLogo As New cItem_Pictures("00SPECTOR") '00SPECTOR
                SetImage(xlWorkBook.Sheets(1), .Range("B1"), oLogo.SaveFileToPath(), 70, 280)

                '++ID  19.05.2015 before B2:K4
                ' SetStyleH1(.Range("B2:K4"), "PROGRAM PRICING FORM", True)
                SetStyleH1(.Range("B2:L4"), "PROGRAM PRICING FORM", True)

                'SetStyleH5(.Range("B6:J6"), "This form serves as notification of product inclusion in your program.", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B7:J7"), "ALL WAIVED CHARGES MUST BE LISTED ON THIS FORM.  ANY ADDITIONAL ", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B8:J8"), "CHARGES NOT LISTED ON THIS FORM WILL NOT BE PAID BY SPECTOR & CO.", True, Excel.XlHAlign.xlHAlignCenter)

                SetStyleH5(.Range("B6:K6"), "Thank you for including our products in your program. Please reference the supplier program number on your P.O.", True, Excel.XlHAlign.xlHAlignCenter)
                SetStyleH5(.Range("B7:K7"), "Please note the comments below for additionnal important information", True, Excel.XlHAlign.xlHAlignCenter)

                Dim iStartRow As Integer = 9
                Dim iItemCount As Integer = 0
                Dim iCurrentRow As Integer = iStartRow
                Dim iRowItem As Integer = 0

                '########################################################################
                '#      SECTION PROGRAM INFORMATION
                '########################################################################

                'SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "PROGRAM INFORMATION", True)
                'iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "SUPPLIER PROGRAM NO:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Spector_CD").ToString, True)

                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CUSTOMER:", True)
                'SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_code.Trim & " - " & oCustomer.cmp_name.Trim, True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_name.Trim, True)

                iCurrentRow += 1

                If oCustomer.cmp_fadd1.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd1.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd2.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd2.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd3.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd3.Trim, True)
                    iCurrentRow += 1
                End If

                'RTRIM(ISNULL(CMP_FCITY, ''))  RTRIM(ISNULL(STATECODE, '')) RTRIM(ISNULL(CMP_FPC, '')) AS CMP_FADD4, CMP_FCTRY
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), _
                oCustomer.cmp_fcity.Trim & ", " & oCustomer.StateCode.Trim & " " & oCustomer.cmp_fpc.Trim, True)
                iCurrentRow += 1

                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_CountryDesc.Trim, True)
                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PROGRAM DATE:", True)
                If Not (dtHeader.Rows(0).Item("Create_TS").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Create_TS")).ToShortDateString, True)
                    .Range("D" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "SPECTOR CONTACT:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString, True)

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PROGRAM:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":D" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Prog_Cd").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Email").ToString, True)

                iCurrentRow += 1
                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "IMPRINT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Imprint").ToString, True)

                'SetStyleH5(.Range("E" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), "PHONE:", True)
                'SetStyleNormal(.Range("G13:J13"), "913-548-7964", True)

                'SetStyleH5(.Range("B11"), "SUPPLIER NAME:")
                'SetStyleNormal(.Range("C11:D11"), "Spector & Co", True)

                iCurrentRow += 1
                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CONTACT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Contact_Name").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "PROGRAM START DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_Start_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_Start_Dt")).ToShortDateString)
                    .Range("F" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PHONE NUMBER:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Phone_Number").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "PROGRAM END DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString)
                    .Range("G" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Email_Address").ToString, True)

                'MergeCells(.Range("B2:H4"))
                '.Range("B2").FormulaR1C1 = "GUARANTEED PRICING FORM"

                '########################################################################
                '#      SECTION DES ITEMS
                '########################################################################

                iCurrentRow += 2

                iStartRow = iCurrentRow
                iRowItem = 0

                errPos = 9
                Dim strsql As String = _
                "SELECT     DISTINCT Item_Cd,Item_Color,DEC_MET_GROUP_DESC " & _
                "FROM       MDB_CUS_PROG_PROGRAMS_ITEMS_VIEW  " & _
                "WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                "ORDER BY   Item_Cd "

                dtItems = db.DataTable(strsql)
                If dtItems.Rows.Count <> 0 Then

                    '++ID 19.05.2015 :K -> :L
                    '   SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "ITEM INFORMATION", True)
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "ITEM INFORMATION", True)

                    iCurrentRow += 2

                    For Each dtRow As DataRow In dtItems.Rows

                        Dim strColor As String = String.Empty

                        errPos = 10
                        strsql = _
                        " SELECT     DISTINCT Item_Color " & _
                        " FROM       MDB_CUS_PROG_PROGRAMS_ITEMS_VIEW " & _
                        " WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                        " AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND ISNULL(Item_Color, '') <> '' " & _
                        "  and ITEM_COLOR = '" & dtRow.Item("Item_Color").ToString & "' " & _
                        " AND DEC_MET_GROUP_DESC = '" & Trim(dtRow.Item("DEC_MET_GROUP_DESC").ToString) & "'  ORDER BY   Item_Color "

                        'Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        'Debug.Print("STEP 1 : " & strsql)

                        dtItemsDetails = db.DataTable(strsql)
                        If dtItemsDetails.Rows.Count <> 0 Then
                            For Each drDetail As DataRow In dtItemsDetails.Rows
                                strColor &= Trim(drDetail.Item("Item_Color")) & ", "
                            Next
                            strColor = strColor.Substring(0, strColor.Length - 2)
                        End If

                        errPos = 11
                        strsql = _
                        "SELECT  DISTINCT ISNULL(Prod_Cat_ID, 0) as Prod_Cat_ID, Item_Cd, Item_Desc, " & _
                        " Min_Qty_Ord, EQP_Level, Unit_Price, Run_Charge, Setup_Waived, Setup_Price, Dec_Met_Group_Desc, " & _
                        " CUS_PROG_ITEM_LIST_ID FROM       MDB_CUS_PROG_PROGRAMS_ITEMS_VIEW " & _
                        "WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                        " AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        " AND ITEM_COLOR = '" & dtRow.Item("Item_Color").ToString & "' " & _
                        " AND DEC_MET_GROUP_DESC = '" & Trim(dtRow.Item("DEC_MET_GROUP_DESC").ToString) & "' " & _
                        " ORDER BY   Item_Cd, Min_Qty_Ord "

                        'Debug.Print("STEP 2 : " & strsql)

                        dtItemsDetails = db.DataTable(strsql)

                        'iCurrentRow = iStartRow + (iItemCount * 8)
                        iRowItem = 0
                        SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":C" & (iCurrentRow + iRowItem).ToString), "ITEM", True)
                        SetStyleH4(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "PRICING", True)

                        iRowItem = 1

                        errPos = 12

                        ''----------------up to here charge image of the item-----------------------------------

                        Dim strItem_Color As String = ""

                        '   strsql = _
                        '"SELECT TOP 1 ITEM_NO " & _
                        '"FROM imitmidx_sql WITH (Nolock) " & _
                        '"WHERE user_def_fld_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "

                        '++ID 1.12.2018
                        strsql =
                     "SELECT TOP 1 ITEM_NO " &
                     "FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                     "WHERE Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "



                        If strColor.Trim <> "ALL" Then
                            If strColor.Contains(",") Then
                                strItem_Color = Trim(strColor.Substring(0, strColor.IndexOf(",")))
                            Else
                                strItem_Color = Trim(strColor.Trim)
                            End If
                            ' strsql &= " AND Color_List = '" & Trim(strItem_Color) & "' "
                            '  strsql &= " AND user_def_fld_2 like '%" & Trim(strItem_Color) & "%' "
                            '++ID 1.12.2018
                            strsql &= " AND Color_List = '" & Trim(strItem_Color) & "' "
                        End If

                        Dim dtImage As DataTable = db.DataTable(strsql)
                        If dtImage.Rows.Count <> 0 Then

                            Dim oImage As New cItem_Pictures(dtImage.Rows(0).Item("Item_No").ToString)
                            SetImage(xlWorkBook.Sheets(1), .Range("B" & (iCurrentRow + iRowItem)), oImage.SaveFileToPath(), 60, 60)

                        End If

                        errPos = 13
                        Dim strItem_No As String = ""
                        'strsql =
                        '"SELECT TOP 1 * " &
                        '"FROM   IMITMIDX_SQL " &
                        '"WHERE  USER_DEF_FLD_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND " &
                        '"       ITEM_NO NOT LIKE '%AST%' AND ITEM_NO NOT LIKE '%ASS%' "

                        '++ID  1.11.2019
                        strsql = "SELECT TOP 1 * " &
                        "FROM   View_MDB_ITEM_DETAIL " &
                        "WHERE  ITEM_CD = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND " &
                        "       ITEM_NO NOT LIKE '%AST%' AND ITEM_NO NOT LIKE '%ASS%' "

                        dtImage = db.DataTable(strsql)

                        If dtImage.Rows.Count <> 0 Then
                            strItem_No = dtImage.Rows(0).Item("Item_No").ToString
                        End If

                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "CODE:")
                        If dtItemsDetails.Rows.Count <> 0 Then SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtItemsDetails.Rows(0).Item("Item_Cd").ToString, True)

                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem + 1).ToString), "DESCRIPTION:")
                        If dtItemsDetails.Rows.Count <> 0 Then SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem + 1).ToString & ":E" & (iCurrentRow + iRowItem + 1).ToString), dtItemsDetails.Rows(0).Item("Item_Desc").ToString, True)

                        SetStyleH5(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "ORDER QUANTITY:", True)
                        SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 1).ToString & ":G" & (iCurrentRow + iRowItem + 1).ToString), "ITEM PRICE:", True)

                        Dim iColumnPos As Integer = 72 ' (chr for H)

                        errPos = 14
                        For Each drDetail In dtItemsDetails.Rows

                            SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem).ToString), drDetail.item("Min_Qty_Ord").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$ #,##0;($ #,##0)"

                            '++ID for new code we don't need  this comment code ------------------------------------
                            'because before the prices is not displayed, but now always all prices will be displayed
                            'If drDetail.item("EQP_Level") = 1 Then
                            '    If drDetail.Item("Prod_Cat_ID") <> 0 Then
                            '        SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), "E.Q.P.", False, Excel.XlHAlign.xlHAlignRight)
                            '    Else
                            '        SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), oPriceBLL.Get_EQP(strItem_No, oCustomer.Currency), False, Excel.XlHAlign.xlHAlignRight)
                            '        .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.00;($#,##0.00)"
                            '    End If
                            '  Else
                            SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), drDetail.item("Unit_Price").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.000;($#,##0.000)" '"$#,##0.00;($#,##0.00)"

                            '  End If
                            '---------------------------------------------------------------------------------------
                            If drDetail.item("Setup_Waived") Or drDetail.item("Setup_Price") <> 0 Then ' "$#,##0.0000_);($#,##0.0000)" '' "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""0.0000""????_);_(@_)"
                                SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 2).ToString & ":G" & (iCurrentRow + iRowItem + 2).ToString), "SETUP PRICE:", True)
                                If drDetail.item("Setup_Waived") Then
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), "0", False, Excel.XlHAlign.xlHAlignRight)
                                Else
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), drDetail.item("Setup_Price").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                End If
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString).NumberFormat = "$#,##0.00;($#,##0.00)"
                                '++ID 22.05.2015 I put in comment because it appear near price
                                'If drDetail.item("DEC_MET_GROUP_DESC").ToString.Trim <> String.Empty Then
                                '    SetStyleNormal(.Range(Chr(iColumnPos + 1) & (iCurrentRow + iRowItem + 2).ToString), "for " & drDetail.item("DEC_MET_GROUP_DESC").ToString.Trim, False)
                                '    ' DEC_MET_GROUP_DESC

                                'End If

                            End If

                            If drDetail.item("Run_Charge") <> 0 Then ' "$#,##0.0000_);($#,##0.0000)" '' "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""0.0000""????_);_(@_)"
                                SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 3).ToString & ":G" & (iCurrentRow + iRowItem + 3).ToString), "RUN CHARGE:", True)
                                SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString), drDetail.item("Run_Charge").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString).NumberFormat = "$#,##0.00;($#,##0.00)"
                            End If
                            iColumnPos += 1

                        Next

                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem).ToString), "500", False, Excel.XlHAlign.xlHAlignRight)
                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem + 1).ToString), "0.38")
                        '.Range("H" & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"

                        'iRowItem = 2
                        'SetStyleH5(.Range("B" & (iCurrentRow + iRowItem).ToString), "DESCRIPTION")
                        'SetStyleNormal(.Range("C" & (iCurrentRow + iRowItem).ToString & ":D" & (iCurrentRow + iRowItem).ToString), "Dario Ballpoint Pen", True)

                        'SetStyleH5(.Range("E" & (iCurrentRow + iRowItem).ToString & ":F" & (iCurrentRow + iRowItem).ToString), "ITEM PRICE", True)
                        'SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), "0.39")
                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem).ToString), "0.38")
                        '.Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"
                        '.Range("H" & (iCurrentRow + iRowItem).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"

                        errPos = 15
                        iRowItem = 3
                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "COLOR(S):")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strColor, True)

                        strDecorating = Trim(dtItemsDetails.Rows(0).Item("DEC_MET_GROUP_DESC").ToString)

                        ' strDecorating = ""

                        iRowItem = 4
                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "DECORATION:")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strDecorating, True)

                        'iRowItem = 4
                        'SetStyleH5(.Range("B" & (iCurrentRow + iRowItem).ToString), "OTHER FIELD:")
                        'SetStyleNormal(.Range("C" & (iCurrentRow + iRowItem).ToString & ":D" & (iCurrentRow + iRowItem).ToString), "Some data", True)

                        'new fro add 2 line after each item below
                        'iRowItem = 5
                        'SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "Test 1 Row:")
                        'iRowItem = 6
                        'SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "Test 2 Row:")



                        '++ID 10.19.2018 add comment text
                        iRowItem = 5

                        Dim iCommentCount As Integer = 0

                        If strCurrency = "USD" Then
                            Dim strComm = " Select cg.FLD_NAME   AS COMMENT_DESC, " &
                       " 100 As  MSG_ORDER, fv.ITEM_FLD_VALUE_ID  as Prog_Comment_ID   FROM " &
                       "  MDB_ITEM_MASTER m   WITH (NOLOCK) inner join  MDB_ITEM_FLD_VALUE fv  WITH (NOLOCK) on  " &
                       " m.ITEM_MASTER_ID = FV.ITEM_MASTER_ID inner join MDB_CFG_ITEM_FLD cg On " &
                       " FV.ITEM_FLD_ID = cg.ITEM_FLD_ID  where item_cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' and cg.ITEM_FLD_ID = 529 " &
                       " and FV.VALUE_INT = 1  order by MSG_ORDER asc, PROG_COMMENT_ID asc "


                            Dim dtComments = db.DataTable(strComm)


                            If dtComments.Rows.Count <> 0 Then

                                iCurrentRow += 1

                                For Each drComment As DataRow In dtComments.Rows
                                    If iCommentCount = 0 Then
                                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "COMMENTS:")
                                        iCommentCount += 1
                                    End If
                                    SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString), drComment.Item("Comment_Desc").ToString)
                                    iCurrentRow += 1
                                Next drComment

                                iCurrentRow = iCurrentRow + (7 - iCommentCount)
                            Else

                                iCurrentRow = iCurrentRow + 7

                            End If

                        Else
                            iCurrentRow = iCurrentRow + 7
                        End If


                        '+ 8 'it was 6

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                'SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "COMMENTS", True)
                'iCurrentRow += 2

                '########################################################################
                '#      SECTION DES CHARGES
                '########################################################################

                iStartRow = iCurrentRow
                iRowItem = 0

                errPos = 16
                strsql = _
                "SELECT		ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.CHARGE_ID, C.CHARGE_CD, " & _
                "           ISNULL(CU.CUS_PROG_ID, 0) AS CUS_PROG_ID, C.DESCRIPTION, C.SHORT_DESC, CU.CUS_NO, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NO_CHARGE, " & _
                "			ISNULL(CU.UNIT_PRICE, 0) AS UNIT_PRICE, " & _
                "           CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  + " & _
                "           CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END  + " & _
                "           ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS " & _
                "            FROM " & _
                "	(	SELECT	CUS.CUS_NO, C.*" & _
                "		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
                "	) C " & _
                "INNER JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " & _
                "INNER JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no AND CU.CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id & " " & _
                "WHERE		C.CUS_NO = '" & oMdb_Cus_Prog.Cus_No & "' AND C.CHARGE_ID <> 27 " & _
                "ORDER BY	(CASE WHEN CU.CHARGE_USAGE_ID IS NOT NULL THEN 1 ELSE 0 END) DESC,  " & _
                "           CH.CHARGE_ORDER, C.SHORT_DESC "

                '"ORDER BY	C.CUS_NO, CH.CHARGE_ORDER, C.SHORT_DESC "
                'CHARGE_USAGE_ID(,CHARGE_ID()), CHARGE_CD()
                'CUS_PROG_ID(), 'DESCRIPTION(), 'SHORT_DESC(), 'CUS_NO()
                'ALWAYS_USE(), 'NEVER_USE(), 'NO_CHARGE()
                'UNIT_PRICE(), 'EXT_COMMENTS()

                Dim blnCommentsLabelShown As Boolean = False

                dtOptions = db.DataTable(strsql)

                If dtOptions.Rows.Count <> 0 Then

                    '++ID 19.05.2015 :K -> :L
                    ' SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "COMMENTS", True)
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "COMMENTS", True)

                    iCurrentRow += 2
                    blnCommentsLabelShown = True
                    For Each dtRow As DataRow In dtOptions.Rows

                        Dim strOptionString As String = ""

                        'iCurrentRow = iStartRow + (iItemCount * 8)
                        iRowItem = 0

                        If dtRow.Item("Always_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        ElseIf dtRow.Item("Never_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        Else
                            strOptionString = "FOR " & dtRow.Item("Description").ToString.Trim & ", "
                        End If

                        If dtRow.Item("No_Charge") <> 0 Then
                            strOptionString &= "THERE WILL BE NO CHARGE APPLIED."
                        Else
                            If dtRow.Item("Unit_Price") <> 0 Then
                                'Dim a1 As String = dtRow.Item("Unit_Price")
                                'a1 = CDbl(a1).ToString("N3", CultureInfo.InvariantCulture)
                                strOptionString &= "CHARGE PRICE WILL BE $" & CDbl(dtRow.Item("Unit_Price")).ToString("N3", CultureInfo.InvariantCulture)
                                'strOptionString = "CHARGE PRICE WILL BE " & dtRow.Item("Unit_Price").ToString.Format("N3", CultureInfo.InvariantCulture).ToString
                            Else
                                strOptionString &= "REGULAR CHARGE PRICE APPLY"
                            End If
                        End If

                        SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), strOptionString, True)

                        iCurrentRow = iCurrentRow + 1

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                If Not blnCommentsLabelShown Then


                    '++ID 19.05.2015 :K -> :L
                    '   SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "COMMENTS", True)
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "COMMENTS", True)

                    blnCommentsLabelShown = True

                    iCurrentRow += 2

                End If

                '########################################################################
                '#      SECTION DE COMMENTS
                '########################################################################
                errPos = 17
                Dim rechTxt As RichTextBox
                If oMdb_Cus_Prog.Prog_Comments.Trim <> String.Empty Then
                    rechTxt = New RichTextBox
                    rechTxt.Text = oMdb_Cus_Prog.Prog_Comments

                    ' iCurrentRow += CInt(rechTxt.Lines.Length) '1
                    SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & (iCurrentRow + CInt(rechTxt.Lines.Length)).ToString), oMdb_Cus_Prog.Prog_Comments, True, Excel.XlHAlign.xlHAlignLeft, True)

                    iCurrentRow += CInt(rechTxt.Lines.Length)
                End If

                ' COMMENTS SHOWN ON EVERY ORDER
                'WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.
                'SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), "WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.", True)


                '########################################################################
                '#      SECTION DE BAS DE PAGE DU RAPPORT
                '########################################################################

                'iCurrentRow += 2

                'iStartRow = iCurrentRow
                'iRowItem = 0

                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "ABOVE PRICING AND INVENTORY GUARANTEED THROUGH:", True)
                'If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                '    SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '    .Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"
                'End If

                'iRowItem = 1
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

                'iRowItem = 4
                'SetStyleNormal(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString.Trim, True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), Date.Now.ToString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '.Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"

                'iRowItem = 5
                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "SUPPLIER REPRESENTATIVE, ABOVE", True)
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

            End With

            errPos = 18
            xlApp.PrintCommunication = False
            SetPrintingProperties(xlWorkBook.Sheets(1))
            xlApp.PrintCommunication = True


            'xlApp.Visible = True
            'xlWorkBook.Close(True)
            'xlApp.Quit()

            '++ID 19.1.15
            Dim strPath As String = "c:\Program confirmation\"

            If Not (Directory.Exists(strPath)) Then
                MkDir(strPath)
            End If

            Dim strFileName As String = strPath & "Program confirmation " & oMdb_Cus_Prog.Spector_Cd & ".PDF" '
            xlWorkBook.Sheets(1).ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, strFileName)

            '++ID 14.1.15
            'xlWorkBook.Sheets(1).ExportAsFixedFormat( _
            '   Excel.XlFixedFormatType.xlTypePDF, _
            '   strFileName, _
            '   Excel.XlFixedFormatQuality.xlQualityStandard, _
            '   True, _
            '   True, _
            '   1, _
            '   10, _
            '   False)

            '--------------------------------------------------

            Dim oDocSave As New cMdb_Cus_Document_BLL()
            oDocSave.AddDocumentFile(oMdb_Cus_Prog.Cus_No, 37, strFileName, oMdb_Cus_Prog.Cus_Prog_Guid)
            'xlWorkSheet.Delete()
            'xlWorkSheet = Nothing
            'xlWorkBook.Close(False)

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strFileName
            Process.Start(startInfo)

        Catch er As Exception
            'Call UnsetExportTS()
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message & " " & errPos.ToString)
            'xlWorkBook.Close(False)
            'xlApp.Quit()
        Finally
            Try
                xlApp.Visible = True
                'xlWorkBook.Sheets(1) = Nothing
                xlWorkBook.Close(False)
            Catch ex As Exception
            Finally
                'xlWorkSheet = Nothing
                xlWorkBook = Nothing
                'If IStartedXL Then
                Debug.Print("CLOSE EXCEL PROCESS " & MyExcelProcessID.ToString)
                Dim myExcelProcess As Process = Process.GetProcessById(MyExcelProcessID)
                myExcelProcess.Kill()
                'End If
                xlApp = Nothing
            End Try
        End Try

    End Sub

    Public Sub Create_Excel_Program_Report1(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog, ByRef oCustomer As cCustomer)

        Dim errPos As Integer
        Dim oPriceBLL As New cOEPrcFil_Sql_BLL

        errPos = 1
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        errPos = 2
        Dim xlWorkBook As Excel.Workbook = Nothing
        errPos = 3
        Dim xlWorkSheet As Excel.Worksheet
        errPos = 4
        Dim misValue As Object = System.Reflection.Missing.Value

        errPos = 5

        'Dim a1 As Excel.Range
        'Dim a2 As Excel.Interior
        'Dim a3 As Excel.CellFormat

        'Dim oCellGreyInterior As Excel.Interior '= Nothing
        'Dim oRange As Excel.Range '= Nothing

        Try

            Dim dtHeader As DataTable
            Dim dtItems As DataTable
            Dim dtItemsDetails As DataTable
            Dim dtOptions As DataTable
            Dim db As New cDBA()
            dtHeader = db.DataTable("select * from mdb_cus_prog_quote_view where CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id)

            errPos = 6
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkBook.Styles("Normal").Font.Name = "Arial"
            errPos = 7
            xlWorkSheet = xlWorkBook.Sheets(1)
            errPos = 8

            SetPrintingProperties(xlWorkSheet)

            With xlWorkSheet

                'Set Column width ' 130
                .Range("A:A").ColumnWidth = 3
                .Range("B:B").ColumnWidth = 10
                .Range("C:C").ColumnWidth = 12 ' 66
                .Range("D:D").ColumnWidth = 18
                .Range("E:E").ColumnWidth = 18
                .Range("F:F").ColumnWidth = 11
                .Range("G:G").ColumnWidth = 11
                .Range("H:H").ColumnWidth = 11
                .Range("I:I").ColumnWidth = 11
                .Range("J:J").ColumnWidth = 11
                .Range("K:K").ColumnWidth = 11
                .Range("L:L").ColumnWidth = 3
                '.Range("I:I").ColumnWidth = 18
                '.Range("J:J").ColumnWidth = 2.89

                .Range("A1").RowHeight = 75
                Dim oLogo As New cItem_Pictures("SPECTOR")
                SetImage(xlWorkSheet, .Range("B1"), oLogo.SaveFileToPath(), 70, 280)

                SetStyleH1(.Range("B2:K4"), "PROGRAM PRICING FORM", True)

                'SetStyleH5(.Range("B6:J6"), "This form serves as notification of product inclusion in your program.", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B7:J7"), "ALL WAIVED CHARGES MUST BE LISTED ON THIS FORM.  ANY ADDITIONAL ", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B8:J8"), "CHARGES NOT LISTED ON THIS FORM WILL NOT BE PAID BY SPECTOR & CO.", True, Excel.XlHAlign.xlHAlignCenter)

                SetStyleH5(.Range("B6:K6"), "Thank you for including our products in your program. Please reference the supplier program number on your P.O.", True, Excel.XlHAlign.xlHAlignCenter)
                SetStyleH5(.Range("B7:K7"), "Please note the comments below for additionnal important information", True, Excel.XlHAlign.xlHAlignCenter)

                Dim iStartRow As Integer = 9
                Dim iItemCount As Integer = 0
                Dim iCurrentRow As Integer = iStartRow
                Dim iRowItem As Integer = 0

                '########################################################################
                '#      SECTION PROGRAM INFORMATION
                '########################################################################

                'SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "PROGRAM INFORMATION", True)
                'iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "SUPPLIER PROGRAM NO:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Spector_CD").ToString, True)

                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CUSTOMER:", True)
                'SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_code.Trim & " - " & oCustomer.cmp_name.Trim, True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_name.Trim, True)

                iCurrentRow += 1

                If oCustomer.cmp_fadd1.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd1.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd2.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd2.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd3.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd3.Trim, True)
                    iCurrentRow += 1
                End If

                'RTRIM(ISNULL(CMP_FCITY, ''))  RTRIM(ISNULL(STATECODE, '')) RTRIM(ISNULL(CMP_FPC, '')) AS CMP_FADD4, CMP_FCTRY
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), _
                oCustomer.cmp_fcity.Trim & ", " & oCustomer.StateCode.Trim & " " & oCustomer.cmp_fpc.Trim, True)
                iCurrentRow += 1

                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_CountryDesc.Trim, True)
                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PROGRAM DATE:", True)
                If Not (dtHeader.Rows(0).Item("Create_TS").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Create_TS")).ToShortDateString, True)
                    .Range("D" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "SPECTOR CONTACT:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString, True)

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PROGRAM:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":D" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Prog_Cd").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Email").ToString, True)

                iCurrentRow += 1
                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "IMPRINT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Imprint").ToString, True)

                'SetStyleH5(.Range("E" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), "PHONE:", True)
                'SetStyleNormal(.Range("G13:J13"), "913-548-7964", True)

                'SetStyleH5(.Range("B11"), "SUPPLIER NAME:")
                'SetStyleNormal(.Range("C11:D11"), "Spector & Co", True)

                iCurrentRow += 1
                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CONTACT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Contact_Name").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "PROGRAM START DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_Start_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_Start_Dt")).ToShortDateString)
                    .Range("F" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PHONE NUMBER:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Phone_Number").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "PROGRAM END DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString)
                    .Range("G" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Email_Address").ToString, True)

                'MergeCells(.Range("B2:H4"))
                '.Range("B2").FormulaR1C1 = "GUARANTEED PRICING FORM"

                '########################################################################
                '#      SECTION DES ITEMS
                '########################################################################

                iCurrentRow += 2

                iStartRow = iCurrentRow
                iRowItem = 0

                Dim strsql As String = _
                "SELECT     DISTINCT Item_Cd " & _
                "FROM       MDB_CUS_PROG_QUOTE_items_VIEW " & _
                "WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                "ORDER BY   Item_Cd "

                dtItems = db.DataTable(strsql)
                If dtItems.Rows.Count <> 0 Then

                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "ITEM INFORMATION", True)
                    iCurrentRow += 2

                    For Each dtRow As DataRow In dtItems.Rows

                        Dim strColor As String = String.Empty

                        strsql = _
                        "SELECT     DISTINCT Item_Color " & _
                        "FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        "WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND ISNULL(Item_Color, '') <> '' " & _
                        "ORDER BY   Item_Color "

                        'Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        'Debug.Print("STEP 1 : " & strsql)

                        dtItemsDetails = db.DataTable(strsql)
                        If dtItemsDetails.Rows.Count <> 0 Then
                            For Each drDetail As DataRow In dtItemsDetails.Rows
                                strColor &= drDetail.Item("Item_Color") & ", "
                            Next
                            strColor = strColor.Substring(0, strColor.Length - 2)
                        End If

                        strsql = _
                        "SELECT     DISTINCT ISNULL(Prod_Cat_ID, 0) as Prod_Cat_ID, Item_Cd, Item_Desc, " & _
                        "           Min_Qty_Ord, EQP_Level, Unit_Price, Run_Charge, Setup_Waived, Setup_Price, Dec_Met_Group_Desc " & _
                        "FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        "WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        "ORDER BY   Item_Cd, Min_Qty_Ord "

                        'Debug.Print("STEP 2 : " & strsql)

                        dtItemsDetails = db.DataTable(strsql)

                        iRowItem = 0
                        SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":C" & (iCurrentRow + iRowItem).ToString), "ITEM", True)
                        SetStyleH4(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "PRICING", True)

                        iRowItem = 1

                        Dim strItem_Color As String = ""
                      
                        strsql = _
                            "SELECT TOP 1 ITEM_NO " & _
                            "FROM imitmidx_sql WITH (Nolock) " & _
                            "WHERE user_def_fld_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "

                        If strColor.Trim <> "ALL" Then
                            If strColor.Contains(",") Then
                                strItem_Color = strColor.Substring(0, strColor.IndexOf(",")).Trim
                            Else
                                strItem_Color = strColor.Trim
                            End If
                            strsql &= " AND user_def_fld_2 like '%" & strItem_Color & "%' "
                        End If

                        Dim dtImage As DataTable = db.DataTable(strsql)
                        If dtImage.Rows.Count <> 0 Then

                            Dim oImage As New cItem_Pictures(dtImage.Rows(0).Item("Item_No").ToString)
                            SetImage(xlWorkSheet, .Range("B" & (iCurrentRow + iRowItem)), oImage.SaveFileToPath(), 60, 60)

                        End If

                        Dim strItem_No As String = ""
                        strsql = _
                        "SELECT TOP 1 * " & _
                        "FROM   IMITMIDX_SQL " & _
                        "WHERE  USER_DEF_FLD_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND " & _
                        "       ITEM_NO NOT LIKE '%AST%' AND ITEM_NO NOT LIKE '%ASS%' "

                        dtImage = db.DataTable(strsql)

                        If dtImage.Rows.Count <> 0 Then
                            strItem_No = dtImage.Rows(0).Item("Item_No").ToString
                        End If

                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "CODE:")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtItemsDetails.Rows(0).Item("Item_Cd").ToString, True)

                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem + 1).ToString), "DESCRIPTION:")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem + 1).ToString & ":E" & (iCurrentRow + iRowItem + 1).ToString), dtItemsDetails.Rows(0).Item("Item_Desc").ToString, True)

                        SetStyleH5(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "ORDER QUANTITY:", True)
                        SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 1).ToString & ":G" & (iCurrentRow + iRowItem + 1).ToString), "ITEM PRICE:", True)

                        Dim iColumnPos As Integer = 72 ' (chr for H)

                        For Each drDetail In dtItemsDetails.Rows

                            SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem).ToString), drDetail.item("Min_Qty_Ord").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$ #,##0);($ #,##0)"

                            If drDetail.item("EQP_Level") = 1 Then
                                If drDetail.Item("Prod_Cat_ID") <> 0 Then
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), "E.Q.P.", False, Excel.XlHAlign.xlHAlignRight)
                                Else
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), oPriceBLL.Get_EQP(strItem_No, oCustomer.Currency), False, Excel.XlHAlign.xlHAlignRight)
                                    .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$ #,##0.0000_);($ #,##0.0000)"
                                End If
                            Else
                                SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), drDetail.item("Unit_Price").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$ #,##0.0000_);($ #,##0.0000)"
                            End If
                            If drDetail.item("Setup_Waived") Or drDetail.item("Setup_Price") <> 0 Then ' "$#,##0.0000_);($#,##0.0000)" '' "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""0.0000""????_);_(@_)"
                                SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 2).ToString & ":G" & (iCurrentRow + iRowItem + 2).ToString), "SETUP PRICE:", True)
                                If drDetail.item("Setup_Waived") Then
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), "0", False, Excel.XlHAlign.xlHAlignRight)
                                Else
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), drDetail.item("Setup_Price").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                End If
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString).NumberFormat = "$ #,##0.0000_);($ #,##0.0000)"
                                If drDetail.item("DEC_MET_GROUP_DESC").ToString.Trim <> String.Empty Then
                                    SetStyleNormal(.Range(Chr(iColumnPos + 1) & (iCurrentRow + iRowItem + 2).ToString), "for " & drDetail.item("DEC_MET_GROUP_DESC").ToString.Trim, False)
                                    ' DEC_MET_GROUP_DESC
                                End If
                            End If

                            If drDetail.item("Run_Charge") <> 0 Then ' "$#,##0.0000_);($#,##0.0000)" '' "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""0.0000""????_);_(@_)"
                                SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 3).ToString & ":G" & (iCurrentRow + iRowItem + 3).ToString), "RUN CHARGE:", True)
                                SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString), drDetail.item("Run_Charge").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString).NumberFormat = "$ #,##0.0000_);($ #,##0.0000)"
                            End If
                            iColumnPos += 1

                        Next

                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem).ToString), "500", False, Excel.XlHAlign.xlHAlignRight)
                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem + 1).ToString), "0.38")
                        '.Range("H" & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"

                        'iRowItem = 2
                        'SetStyleH5(.Range("B" & (iCurrentRow + iRowItem).ToString), "DESCRIPTION")
                        'SetStyleNormal(.Range("C" & (iCurrentRow + iRowItem).ToString & ":D" & (iCurrentRow + iRowItem).ToString), "Dario Ballpoint Pen", True)

                        'SetStyleH5(.Range("E" & (iCurrentRow + iRowItem).ToString & ":F" & (iCurrentRow + iRowItem).ToString), "ITEM PRICE", True)
                        'SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), "0.39")
                        'SetStyleNormal(.Range("H" & (iCurrentRow + iRowItem).ToString), "0.38")
                        '.Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"
                        '.Range("H" & (iCurrentRow + iRowItem).ToString).NumberFormat = "_($* #,##0.0000_);_($* (#,##0.0000);_($* ""-""????_);_(@_)"

                        iRowItem = 3
                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "COLOR(S):")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strColor, True)

                        'iRowItem = 4
                        'SetStyleH5(.Range("B" & (iCurrentRow + iRowItem).ToString), "OTHER FIELD:")
                        'SetStyleNormal(.Range("C" & (iCurrentRow + iRowItem).ToString & ":D" & (iCurrentRow + iRowItem).ToString), "Some data", True)

                        iCurrentRow = iCurrentRow + 6

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                '########################################################################
                '#      SECTION DES CHARGES
                '########################################################################

                iStartRow = iCurrentRow
                iRowItem = 0

                strsql = _
                "SELECT		ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.CHARGE_ID, C.CHARGE_CD, " & _
                "           ISNULL(CU.CUS_PROG_ID, 0) AS CUS_PROG_ID, C.DESCRIPTION, C.SHORT_DESC, CU.CUS_NO, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NO_CHARGE, " & _
                "			ISNULL(CU.UNIT_PRICE, 0) AS UNIT_PRICE, " & _
                "           CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  + " & _
                "           CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END  + " & _
                "           ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS " & _
                "            FROM " & _
                "	(	SELECT	CUS.CUS_NO, C.*" & _
                "		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
                "	) C " & _
                "INNER JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " & _
                "INNER JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no AND CU.CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id & " " & _
                "WHERE		C.CUS_NO = '" & oMdb_Cus_Prog.Cus_No & "' " & _
                "ORDER BY	(CASE WHEN CU.CHARGE_USAGE_ID IS NOT NULL THEN 1 ELSE 0 END) DESC,  " & _
                "           CH.CHARGE_ORDER, C.SHORT_DESC "

                '"ORDER BY	C.CUS_NO, CH.CHARGE_ORDER, C.SHORT_DESC "
                'CHARGE_USAGE_ID(,CHARGE_ID()), CHARGE_CD()
                'CUS_PROG_ID(), 'DESCRIPTION(), 'SHORT_DESC(), 'CUS_NO()
                'ALWAYS_USE(), 'NEVER_USE(), 'NO_CHARGE()
                'UNIT_PRICE(), 'EXT_COMMENTS()

                dtOptions = db.DataTable(strsql)

                If dtOptions.Rows.Count <> 0 Then

                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "COMMENTS", True)
                    iCurrentRow += 2

                    For Each dtRow As DataRow In dtOptions.Rows

                        Dim strOptionString As String = ""

                        'iCurrentRow = iStartRow + (iItemCount * 8)
                        iRowItem = 0

                        If dtRow.Item("Always_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        ElseIf dtRow.Item("Never_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        Else
                            strOptionString = "FOR " & dtRow.Item("Description").ToString.Trim & ", "
                        End If

                        If dtRow.Item("No_Charge") <> 0 Then
                            strOptionString &= "THERE WILL BE NO CHARGE APPLIED."
                        Else
                            If dtRow.Item("Unit_Price") <> 0 Then
                                'Dim a1 As String = dtRow.Item("Unit_Price")
                                'a1 = CDbl(a1).ToString("N3", CultureInfo.InvariantCulture)
                                strOptionString &= "CHARGE PRICE WILL BE $" & CDbl(dtRow.Item("Unit_Price")).ToString("N3", CultureInfo.InvariantCulture)
                                'strOptionString = "CHARGE PRICE WILL BE " & dtRow.Item("Unit_Price").ToString.Format("N3", CultureInfo.InvariantCulture).ToString
                            Else
                                strOptionString &= "REGULAR CHARGE PRICE APPLY"
                            End If
                        End If

                        SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), strOptionString, True)

                        iCurrentRow = iCurrentRow + 1

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                '########################################################################
                '#      SECTION DE COMMENTS
                '########################################################################
                If oMdb_Cus_Prog.Prog_Comments.Trim <> String.Empty Then
                    iCurrentRow += 1
                    SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oMdb_Cus_Prog.Prog_Comments, True)
                End If

                ' COMMENTS SHOWN ON EVERY ORDER
                'WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.
                'SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), "WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.", True)


                '########################################################################
                '#      SECTION DE BAS DE PAGE DU RAPPORT
                '########################################################################

                'iCurrentRow += 2

                'iStartRow = iCurrentRow
                'iRowItem = 0

                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "ABOVE PRICING AND INVENTORY GUARANTEED THROUGH:", True)
                'If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                '    SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '    .Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"
                'End If

                'iRowItem = 1
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

                'iRowItem = 4
                'SetStyleNormal(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString.Trim, True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), Date.Now.ToString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '.Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"

                'iRowItem = 5
                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "SUPPLIER REPRESENTATIVE, ABOVE", True)
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

            End With


            Dim strPath As String = "c:\Program confirmation1\"

            If Not (Directory.Exists(strPath)) Then
                MkDir(strPath)
            End If

            Dim strFileName As String = strPath & "Program confirmation1 " & oMdb_Cus_Prog.Spector_Cd & ".PDF"
            xlWorkSheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, strFileName)

            Dim oDocSave As New cMdb_Cus_Document_BLL()
            oDocSave.AddDocumentFile(oMdb_Cus_Prog.Cus_No, 37, strFileName, oMdb_Cus_Prog.Cus_Prog_Guid)
            xlWorkBook.Close(False)

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strFileName
            Process.Start(startInfo)

        Catch er As Exception
            'Call UnsetExportTS()
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message & " " & errPos.ToString)
            'xlWorkBook.Close(False)
            'xlApp.Quit()
        Finally
            Try
                'xlApp.Visible = True
                xlWorkBook.Close(False)
            Catch ex As Exception
            Finally
                xlWorkBook = Nothing
                xlApp.Quit()
                xlApp = Nothing
            End Try
        End Try

    End Sub

    Public Sub Create_Excel_Quote_Report(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog, ByRef oCustomer As cCustomer)

        Dim errPos As Integer
        Dim oPriceBLL As New cOEPrcFil_Sql_BLL
        Dim iCurrentRow As Integer
        errPos = 1
        Dim colExcelProcessID As New Collection
        Dim MyExcelProcessID As Integer = 0

        Dim msExcelProcesses As Process() = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                colExcelProcessID.Add(oProcess.Id.ToString, oProcess.Id.ToString)
            Next
        End If

        errPos = 1
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        msExcelProcesses = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                If Not (colExcelProcessID.Contains(oProcess.Id.ToString)) Then MyExcelProcessID = oProcess.Id
            Next
        End If

        errPos = 2
        Dim xlWorkBook As Excel.Workbook = Nothing
        errPos = 3
        Dim xlWorkSheet As Excel.Worksheet
        errPos = 4
        Dim misValue As Object = System.Reflection.Missing.Value

        errPos = 5

        Try

            Dim dtHeader As DataTable
            Dim dtItems As DataTable
            Dim dtItemsDetails As DataTable
            Dim dtOptions As DataTable
            Dim dtComments As DataTable
            Dim db As New cDBA()
            Dim strRevision As String = ""
            Dim strCurrency As String = ""
            Dim oCustomTaal As New cCustomer
            Dim taalC As String

            taalC = oCustomTaal.Taal_Cd_ByID(oMdb_Cus_Prog.Contact_ID)



            Dim strSql As String = "select * from mdb_cus_prog_quote_view where CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id

            dtHeader = db.DataTable(strSql)

            '++ID 10.19.2018 added validate DataTable (dtHeader) and added variable Currency for dipslay Section 3
            If dtHeader.Rows.Count = 0 Then Exit Sub

            strCurrency = Trim(dtHeader.Rows(0).Item("Currency").ToString)

            errPos = 6
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkBook.Styles("Normal").Font.Name = "Arial"
            errPos = 7
            xlWorkSheet = xlWorkBook.Sheets(1)
            errPos = 8

            With xlWorkSheet

                'Set Column width ' 130
                .Range("A:A").ColumnWidth = 2.63
                .Range("B:B").ColumnWidth = 17.63
                .Range("C:C").ColumnWidth = 16.38 ' 66
                .Range("D:D").ColumnWidth = 28.63
                .Range("E:E").ColumnWidth = 8.25 'before 10.63 ++ID 03.03.2015
                .Range("F:F").ColumnWidth = 6.38
                .Range("G:G").ColumnWidth = 9.75 'before 11 ++ID 03.03.2015
                .Range("H:H").ColumnWidth = 11 ' before 11 ++ID 03.03.2015
                .Range("I:I").ColumnWidth = 11
                .Range("J:J").ColumnWidth = 11
                .Range("K:K").ColumnWidth = 11 '10 ++ID 03.03.2015
                .Range("L:L").ColumnWidth = 11 'before 6 ++ID 03.03.2015
                '.Range("I:I").ColumnWidth = 18
                '.Range("J:J").ColumnWidth = 2.89

                .Range("A1").RowHeight = 75

                '++ID 16.1.15

                Dim strLogo As String = ""
                Dim dtLogo As DataTable
                Dim intDocILogo As Int32 = 0
                Dim path As String = ""

                'If is 'edward' logo GoUnique else Spector & Co
                strLogo = _
                    " select top 1 * from exact_traveler_document " & _
                    " where DocDescription =  '" & Environment.UserName & "' and doctypeid = 40 order by DocId desc "
                'strLogo = _
                '    "select top 1 * from exact_traveler_document " & _
                '    " where DocDescription =  'edward' and doctypeid = 40 order by DocId desc "

                dtLogo = db.DataTable(strLogo)

                If dtLogo.Rows.Count <> 0 Then

                    intDocILogo = dtLogo.Rows(0).Item("DocId")
                    Dim oExact_Traveler_Doc As New cEXACT_TRAVELER_DOCUMENT(intDocILogo)

                    path = oExact_Traveler_Doc.SaveFileToPath()

                    Dim bmp As New Bitmap(path)
                    'bmp.Height
                    ' .Range("B1").RowHeight = 105
                    '++ID 04.03.15   
                    Dim oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignRight

                    Dim xlRange As Excel.Range = CType(.Range(.Cells(1, "E"), .Cells(1, "F")), Excel.Range)

                    xlRange.Merge()

                    xlRange.HorizontalAlignment = oAlign

                    xlRange.RowHeight = 105

                    SetImage(xlWorkBook.Sheets(1), xlRange, path, 100, 100)

                    oExact_Traveler_Doc = New cEXACT_TRAVELER_DOCUMENT()
                Else

                    'Dim oLogo As New cItem_Pictures("SPECTOR")
                    Dim oLogo As New cItem_Pictures("00SPECTOR") '00SPECTOR
                    SetImage(xlWorkBook.Sheets(1), .Range("B1"), oLogo.SaveFileToPath(), 70, 280)
                End If

                'Dim oLogo As New cItem_Pictures("SPECTOR")
                'SetImage(xlWorkSheet, .Range("B1"), oLogo.SaveFileToPath(), 70, 280)


                '++ID before B2:K4
                SetStyleH1(.Range("B2:L4"), "QUOTE PRICING FORM", True)

                'SetStyleH5(.Range("B6:J6"), "This form serves as notification of product inclusion in your program.", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B7:J7"), "ALL WAIVED CHARGES MUST BE LISTED ON THIS FORM.  ANY ADDITIONAL ", True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleH5(.Range("B8:J8"), "CHARGES NOT LISTED ON THIS FORM WILL NOT BE PAID BY SPECTOR & CO.", True, Excel.XlHAlign.xlHAlignCenter)

                SetStyleH5(.Range("B6:K6"), "Thank you for including our products in your quote. Please reference the supplier quote number on your P.O.", True, Excel.XlHAlign.xlHAlignCenter)
                SetStyleH5(.Range("B7:K7"), "Please note the comments below for additionnal important information", True, Excel.XlHAlign.xlHAlignCenter)

                Dim iStartRow As Integer = 9
                Dim iItemCount As Integer = 0
                iCurrentRow = iStartRow
                Dim iRowItem As Integer = 0

                '########################################################################
                '#      SECTION PROGRAM INFORMATION
                '########################################################################

                'SetStyleH2(.Range("B" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), "QUOTE INFORMATION", True)
                'iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "SUPPLIER QUOTE NO:", True)

                If dtHeader.Rows(0).Item("CURRENT_REV_NO") = 0 Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Spector_CD").ToString, True)
                Else
                    strRevision = "(REVISION " & dtHeader.Rows(0).Item("CURRENT_REV_NO").ToString.Trim & ")"
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Spector_CD").ToString.Trim & " " & strRevision, True)
                    'SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "REVISION:", True)
                    'SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CURRENT_REV_NO").ToString, True)
                End If

                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CUSTOMER:", True)
                'SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_code.Trim & " - " & oCustomer.cmp_name.Trim, True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_name.Trim, True)

                iCurrentRow += 1

                If oCustomer.cmp_fadd1.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd1.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd2.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd2.Trim, True)
                    iCurrentRow += 1
                End If

                If oCustomer.cmp_fadd3.Trim <> String.Empty Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_fadd3.Trim, True)
                    iCurrentRow += 1
                End If

                'RTRIM(ISNULL(CMP_FCITY, ''))  RTRIM(ISNULL(STATECODE, '')) RTRIM(ISNULL(CMP_FPC, '')) AS CMP_FADD4, CMP_FCTRY
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), _
                oCustomer.cmp_fcity.Trim & ", " & oCustomer.StateCode.Trim & " " & oCustomer.cmp_fpc.Trim, True)
                iCurrentRow += 1

                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), oCustomer.cmp_CountryDesc.Trim, True)

                iCurrentRow += 2

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "QUOTE DATE:", True)
                If Not (dtHeader.Rows(0).Item("Create_TS").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Create_TS")).ToShortDateString, True)
                    .Range("D" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "SPECTOR CONTACT:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString, True)

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "QUOTE:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":D" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Prog_Cd").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":K" & iCurrentRow.ToString), dtHeader.Rows(0).Item("CSR_Email").ToString, True)

                iCurrentRow += 1
                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "IMPRINT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Imprint").ToString, True)

                'SetStyleH5(.Range("E" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), "PHONE:", True)
                'SetStyleNormal(.Range("G13:J13"), "913-548-7964", True)

                'SetStyleH5(.Range("B11"), "SUPPLIER NAME:")
                'SetStyleNormal(.Range("C11:D11"), "Spector & Co", True)

                iCurrentRow += 1
                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "CONTACT:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Contact_Name").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "QUOTE START DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_Start_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_Start_Dt")).ToShortDateString)
                    .Range("F" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "PHONE NUMBER:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Phone_Number").ToString, True)

                SetStyleH5(.Range("F" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), "QUOTE END DATE:", True)
                If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                    SetStyleNormal(.Range("H" & iCurrentRow.ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString)
                    .Range("G" & iCurrentRow.ToString).NumberFormat = "m/d/yyyy"
                End If

                iCurrentRow += 1

                SetStyleH5(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), "EMAIL:", True)
                SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":E" & iCurrentRow.ToString), dtHeader.Rows(0).Item("Email_Address").ToString, True)

                'MergeCells(.Range("B2:H4"))
                '.Range("B2").FormulaR1C1 = "GUARANTEED PRICING FORM"

                '########################################################################
                '#      SECTION DES ITEMS
                '########################################################################

                iCurrentRow += 2

                iStartRow = iCurrentRow
                iRowItem = 0

                'strSql = _
                '"SELECT     DISTINCT Item_Cd, ISNULL(OVERSEAS, 0) AS OVERSEAS, " & _
                '"           ISNULL(QUOTE_TYPE_ID, 0) AS QUOTE_TYPE_ID, ISNULL(QUOTE_TYPE_DESC, '') AS QUOTE_TYPE_DESC, " & _
                '"           ISNULL(QUOTE_SHIP_METHOD_ID, 0) AS QUOTE_SHIP_METHOD_ID, ISNULL(QUOTE_SHIP_METHOD_DESC, '') AS QUOTE_SHIP_METHOD_DESC, " & _
                '"           ISNULL(PACK_ID, 0) AS PACK_ID, ISNULL(PACK_CD, '') AS PACK_CD, " & _
                '"           ISNULL(DEC_MET_GROUP_ID, 0) AS DEC_MET_GROUP_ID, ISNULL(DEC_MET_GROUP_DESC, '') AS DEC_MET_GROUP_DESC, " & _
                '"           ISNULL(SETUP_STRING, '') AS SETUP_STRING " & _
                '"FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                '"WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                '"ORDER BY   Item_Cd "
                '++ID 19.05.2015 we added Item_Color
                strSql = _
                "SELECT     DISTINCT Item_Cd,ITEM_COLOR, ISNULL(OVERSEAS, 0) AS OVERSEAS, " & _
                "           ISNULL(QUOTE_TYPE_ID, 0) AS QUOTE_TYPE_ID, ISNULL(QUOTE_TYPE_DESC, '') AS QUOTE_TYPE_DESC, " & _
                "           ISNULL(QUOTE_SHIP_METHOD_ID, 0) AS QUOTE_SHIP_METHOD_ID, ISNULL(QUOTE_SHIP_METHOD_DESC, '') AS QUOTE_SHIP_METHOD_DESC, " & _
                "           ISNULL(PACK_ID, 0) AS PACK_ID, ISNULL(PACK_CD, '') AS PACK_CD, " & _
                "           ISNULL(DEC_MET_ID, 0) AS DEC_MET_ID, ISNULL(DEC_MET_CD, '') AS DEC_MET_CD, " & _
                "           ISNULL(DEC_MET_GROUP_ID, 0) AS DEC_MET_GROUP_ID, ISNULL(DEC_MET_GROUP_DESC, '') AS DEC_MET_GROUP_DESC," & _
                "           ISNULL(SETUP_STRING, '') AS SETUP_STRING " & _
                " FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                " WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' " & _
                " ORDER BY   Item_Cd "
                dtItems = db.DataTable(strSql)
                If dtItems.Rows.Count <> 0 Then
                    '++ID 04.03.2015 :K -> :L
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "ITEM INFORMATION", True)
                    iCurrentRow += 2

                    For Each dtRow As DataRow In dtItems.Rows

                        Dim strPackaging As String = String.Empty
                        Dim strQUOTE_TYPE_ID As String = dtRow.Item("QUOTE_TYPE_ID")
                        Dim strQUOTE_TYPE_DESC As String = dtRow.Item("QUOTE_TYPE_DESC").ToString
                        Dim strQUOTE_SHIP_METHOD_ID As String = dtRow.Item("QUOTE_SHIP_METHOD_ID")
                        Dim strQUOTE_SHIP_METHOD_DESC As String = dtRow.Item("QUOTE_SHIP_METHOD_DESC").ToString
                        Dim strPACK_CD As String = dtRow.Item("PACK_CD").ToString
                        Dim strDEC_MET_GROUP_DESC As String = dtRow.Item("DEC_MET_GROUP_DESC").ToString
                        Dim strDEC_MET_CD As String = dtRow.Item("DEC_MET_CD").ToString
                        Dim strSETUP_STRING As String = dtRow.Item("SETUP_STRING").ToString
                        ' Dim decSETUP_PRICE As Decimal = dtRow.Item("SETUP_PRICE")

                        Dim strColor As String = String.Empty
                        'strQUOTE_SHIP_METHOD_DESC
                        'strSql = _
                        '"SELECT     DISTINCT Item_Color " & _
                        '"FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        '"WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND ISNULL(Item_Color, '') <> '' AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " AND ISNULL(DEC_MET_CD, '') = '" & strDEC_MET_CD & "' " & _
                        '"ORDER BY   Item_Color "

                        '++ID 19.05.2015 I added one criteria for identifie Distinct Item Color
                        strSql = _
                        "SELECT     DISTINCT Item_Color " & _
                        "FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        " WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        " AND Item_Color = '" & dtRow.Item("Item_Color").ToString & "' AND ISNULL(Item_Color, '') <> '' " & _
                        " AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & "" & _
                        " AND ISNULL(QUOTE_TYPE_ID, 0) = " & strQUOTE_TYPE_ID & " AND ISNULL(QUOTE_SHIP_METHOD_ID, 0) = " & strQUOTE_SHIP_METHOD_ID & " " & _
                        " AND ISNULL(DEC_MET_CD, '') = '" & strDEC_MET_CD & "'  AND ISNULL(SETUP_STRING, '') = '" & strSETUP_STRING & "'  " & _
                        " AND ISNULL(PACK_CD, '') = '" & strPACK_CD & "' ORDER BY   Item_Color "

                        ' AND ISNULL(QUOTE_TYPE_ID, 0) = " & strQUOTE_TYPE_ID & " AND ISNULL(QUOTE_SHIP_METHOD_ID, 0) = " & strQUOTE_SHIP_METHOD_ID & " 

                        'Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        'Debug.Print("STEP 1 : " & strsql)

                        dtItemsDetails = db.DataTable(strSql)
                        If dtItemsDetails.Rows.Count <> 0 Then
                            For Each drDetail As DataRow In dtItemsDetails.Rows
                                strColor &= Trim(drDetail.Item("Item_Color")) & ", "
                            Next
                            strColor = strColor.Substring(0, strColor.Length - 2)
                        End If

                        'strSql = _
                        '"SELECT     DISTINCT PACK_CD " & _
                        '"FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        '"WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND ISNULL(Item_Color, '') <> '' AND ISNULL(PACK_CD, '') <> '' AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " " & _
                        '"ORDER BY   PACK_CD "


                        '++ID 20.05.2015 added  AND Item_Color = '" & dtRow.Item("Item_Color").ToString & "'
                        strSql = _
                        " SELECT     DISTINCT PACK_CD " & _
                        " FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        " WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        "  AND Item_Color = '" & dtRow.Item("Item_Color").ToString & "' AND ISNULL(Item_Color, '') <> '' AND ISNULL(PACK_CD, '') <> '' " & _
                        " AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " AND ISNULL(QUOTE_TYPE_ID, 0) = " & strQUOTE_TYPE_ID & " " & _
                        " AND ISNULL(QUOTE_SHIP_METHOD_ID, 0) = " & strQUOTE_SHIP_METHOD_ID & " AND ISNULL(DEC_MET_CD, '') = '" & strDEC_MET_CD & "' " & _
                        "  AND ISNULL(SETUP_STRING, '') = '" & strSETUP_STRING & "' AND ISNULL(PACK_CD, '') = '" & strPACK_CD & "'  ORDER BY   PACK_CD "

                        'Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        'Debug.Print("STEP 1 : " & strsql)

                        dtItemsDetails = db.DataTable(strSql)
                        If dtItemsDetails.Rows.Count <> 0 Then
                            For Each drDetail As DataRow In dtItemsDetails.Rows
                                strPackaging &= drDetail.Item("PACK_CD") & ", "
                            Next
                            strPackaging = strPackaging.Substring(0, strPackaging.Length - 2)
                        End If

                        Dim strDecorating As String = String.Empty
                        strDecorating = strDEC_MET_CD
                        'strSql = _
                        '"SELECT     DISTINCT DEC_MET_CD " & _
                        '"FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        '"WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND ISNULL(Item_Color, '') <> '' AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " " & _
                        '"ORDER BY   DEC_MET_CD "

                        ''Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        ''Debug.Print("STEP 1 : " & strsql)

                        'dtItemsDetails = db.DataTable(strSql)
                        'If dtItemsDetails.Rows.Count <> 0 Then
                        '    For Each drDetail As DataRow In dtItemsDetails.Rows
                        '        strDecorating = drDetail.Item("DEC_MET_CD") & " "
                        '    Next
                        '    'strDecorating = strColor.Substring(0, strColor.Length - 2)
                        'End If

                        Dim strColLoc As String = String.Empty

                        strSql = _
                        " SELECT     DISTINCT COLOR_COUNT, LOCATION_COUNT " & _
                        " FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        " WHERE      Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        "  AND Item_Color = '" & dtRow.Item("Item_Color").ToString & "' AND ISNULL(Item_Color, '') <> ''  " & _
                        " AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " " & _
                        " AND ISNULL(QUOTE_TYPE_ID, 0) = " & strQUOTE_TYPE_ID & " AND ISNULL(QUOTE_SHIP_METHOD_ID, 0) = " & strQUOTE_SHIP_METHOD_ID & " " & _
                        " AND ISNULL(DEC_MET_CD, '') = '" & strDEC_MET_CD & "'  AND ISNULL(SETUP_STRING, '') = '" & strSETUP_STRING & "'  " & _
                        " AND ISNULL(PACK_CD, '') = '" & strPACK_CD & "' ORDER BY   COLOR_COUNT, LOCATION_COUNT "

                        'Debug.Print("Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' ")
                        'Debug.Print("STEP 1 : " & strsql)

                        dtItemsDetails = db.DataTable(strSql)
                        If dtItemsDetails.Rows.Count <> 0 Then
                            For Each drDetail As DataRow In dtItemsDetails.Rows
                                strColLoc = drDetail.Item("COLOR_COUNT").ToString.Trim & " COLORS, " & drDetail.Item("LOCATION_COUNT").ToString.Trim & " LOCATIONS "
                            Next
                            'strColLoc = strColor.Substring(0, strColor.Length - 2)
                        End If

                        ' strDecorating &= strColLoc

                        strSql = _
                        " SELECT     DISTINCT ISNULL(Prod_Cat_ID, 0) as Prod_Cat_ID, Item_Cd, Item_Desc, " & _
                        " Min_Qty_Ord, EQP_Level, Unit_Price, Run_Charge, Setup_Waived, Setup_Price, " & _
                        " ISNULL(Cus_Prog_Item_List_Guid, '') AS Cus_Prog_Item_List_Guid ,CUS_PROG_ITEM_LIST_ID  " & _
                        " FROM       MDB_CUS_PROG_QUOTE_ITEMS_VIEW " & _
                        " WHERE  Spector_Cd = '" & oMdb_Cus_Prog.Spector_Cd & "' AND Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' " & _
                        " AND Item_Color = '" & dtRow.Item("Item_Color").ToString & "' AND ISNULL(OVERSEAS, 0) = " & dtRow.Item("OVERSEAS") & " " & _
                        " AND ISNULL(QUOTE_TYPE_ID, 0) = " & strQUOTE_TYPE_ID & " AND ISNULL(QUOTE_SHIP_METHOD_ID, 0) = " & strQUOTE_SHIP_METHOD_ID & " " & _
                        " AND ISNULL(DEC_MET_CD, '') = '" & strDEC_MET_CD & "' AND ISNULL(SETUP_STRING, '') = '" & strSETUP_STRING & "'  " & _
                        " AND ISNULL(PACK_CD, '') = '" & strPACK_CD & "' ORDER BY   Item_Cd, Min_Qty_Ord "

                        'Debug.Print("STEP 2 : " & strsql)

                        dtItemsDetails = db.DataTable(strSql)

                        'iCurrentRow = iStartRow + (iItemCount * 8)
                        iRowItem = 0
                        SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":C" & (iCurrentRow + iRowItem).ToString), "ITEM", True)
                        SetStyleH4(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "PRICING", True)

                        iRowItem = 1
                       

                        '++ID 16.1.15 I put it in place of comment above

                        Dim strItem_Color As String = ""


                        '++ID 14.1.15 

                        Dim dtDocId As DataTable

                        Dim cpt As Int32 = 0

                        If dtItemsDetails.Rows.Count <> 0 Then

                            'dtItemsDetails it can return more than 1, then each row returned, we must verify if have DocId, and take only first docId found 
                            For Each row As DataRow In dtItemsDetails.Rows

                                strSql = _
                           " SELECT DocId FROM MDB_CUS_PROG_ITEM_LIST " & _
                           " where   CUS_PROG_ITEM_LIST_ID = " & row.Item("CUS_PROG_ITEM_LIST_ID")

                                dtDocId = db.DataTable(strSql)

                                If dtDocId.Rows.Count <> 0 Then
                                    If dtDocId.Rows(0).Item("DocId") <> 0 And Trim(dtDocId.Rows(0).Item("DocId").ToString) <> "" Then
                                        ReDim Preserve arrDocId(cpt)
                                        arrDocId(cpt) = dtDocId.Rows(0).Item("DocId")
                                        cpt = cpt + 1
                                    End If
                                End If

                            Next

                        End If

                        Dim dtImage As DataTable = Nothing
                        '-----------------------------------

                        ''++ID 15.1.15
                        'If strColor.Trim <> "ALL" Then
                        '    If strColor.Contains(",") Then
                        '        strItem_Color = Trim(strColor.Substring(0, strColor.IndexOf(",")))
                        '    Else
                        '        strItem_Color = Trim(strColor)
                        '    End If
                        '    strSql &= " AND Color_List = '" & strItem_Color & "' "
                        'End If

                        '    If arrDocId Is Nothing Then
                        'it existed before
                        '---------------------Start seek(search) image of item ------ 

                        '++ID 02.02.2016 added , changed MDB_ITEM_DETAIL=>imitmidx_sql
                        'strSql =
                        '  "SELECT TOP 1 ITEM_NO " &
                        '"FROM imitmidx_sql WITH (Nolock) " &
                        '"WHERE user_def_fld_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "

                        '++ID 1.12.2018
                        strSql =
                     "SELECT TOP 1 ITEM_NO " &
                     "FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                     "WHERE Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "

                        '++ID 15.1.15
                        If strColor.Trim <> "ALL" Then
                            If strColor.Contains(",") Then
                                strItem_Color = Trim(strColor.Substring(0, strColor.IndexOf(",")))
                            Else
                                strItem_Color = Trim(strColor)
                            End If
                            '    strSql &= " AND Color_List = '" & strItem_Color & "' "
                            '++ID added 1.8.2018 colon from imitmidx_sql
                            strSql &= " AND Color_LIST like '%" & strItem_Color & "%' "
                        End If

                        dtImage = db.DataTable(strSql)
                        If dtImage.Rows.Count <> 0 And arrDocId Is Nothing Then

                            Dim oImage As New cItem_Pictures(dtImage.Rows(0).Item("Item_No").ToString)
                            SetImage(xlWorkBook.Sheets(1), .Range("B" & (iCurrentRow + iRowItem).ToString), oImage.SaveFileToPath(), 100, 100)

                        Else
                            '++ID 9.3.15 
                            If arrDocId IsNot Nothing Then
                                Dim oExact_Traveler_Document As New cEXACT_TRAVELER_DOCUMENT(arrDocId(0))
                                SetImage(xlWorkBook.Sheets(1), .Range("B" & (iCurrentRow + iRowItem).ToString), oExact_Traveler_Document.SaveFileToPath(), 100, 100)
                                Debug.Print("arrDocId() : " & arrDocId.Count)

                                arrDocId = Nothing
                            End If
                        End If

                        '----------------up to here charge image of the item-----------------------------------

                        Dim strItem_No As String = ""
                        'strSql = _
                        '"SELECT TOP 1 * " & _
                        '"FROM   IMITMIDX_SQL " & _
                        '"WHERE  USER_DEF_FLD_1 = '" & dtRow.Item("Item_Cd").ToString.Trim & "' AND " & _
                        '"       ITEM_NO NOT LIKE '%AST%' AND ITEM_NO NOT LIKE '%ASS%' "

                        '++ID 1.12.2018
                        strSql =
                     " SELECT TOP 1 ITEM_NO " &
                     " FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                     " WHERE Item_Cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "'and item_no not like '%AST' "

                        dtImage = db.DataTable(strSql)

                            If dtImage.Rows.Count <> 0 Then
                                strItem_No = dtImage.Rows(0).Item("Item_No").ToString
                            End If

                        SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "CODE:")
                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtItemsDetails.Rows(0).Item("Item_Cd").ToString, True)

                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem + 1).ToString), "DESCRIPTION:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem + 1).ToString & ":E" & (iCurrentRow + iRowItem + 1).ToString), dtItemsDetails.Rows(0).Item("Item_Desc").ToString, True)

                            SetStyleH5(.Range("F" & (iCurrentRow + iRowItem).ToString & ":G" & (iCurrentRow + iRowItem).ToString), "ORDER QUANTITY:", True)
                            SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 1).ToString & ":G" & (iCurrentRow + iRowItem + 1).ToString), "ITEM PRICE:", True)
                            SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 2).ToString & ":G" & (iCurrentRow + iRowItem + 2).ToString), "QUOTED VALUE:", True)
                            SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 3).ToString & ":G" & (iCurrentRow + iRowItem + 3).ToString), "RUN CHARGE:", True)
                        SetStyleH5(.Range("F" & (iCurrentRow + iRowItem + 4).ToString & ":G" & (iCurrentRow + iRowItem + 4).ToString), "SETUP PRICE:", True)

                        Dim iColumnPos As Integer = 72 ' (chr for H)
                            Dim strGuid_List As String = ""
                            For Each drDetail In dtItemsDetails.Rows

                                Dim dblMin_Qty_Ord As Double
                                Dim dblUnit_Price As Double

                                If strGuid_List <> "" Then strGuid_List &= ", "
                                strGuid_List += "'" & drDetail.item("Cus_Prog_Item_List_Guid").ToString.Trim & "'"

                                dblMin_Qty_Ord = drDetail.item("Min_Qty_Ord")
                                SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem).ToString), dblMin_Qty_Ord.ToString, False, Excel.XlHAlign.xlHAlignRight)
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "#,##0;(#,##0)"

                                If drDetail.item("EQP_Level") = 1 Then
                                    If drDetail.Item("Prod_Cat_ID") <> 0 Then
                                        SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), "E.Q.P.", False, Excel.XlHAlign.xlHAlignRight)
                                    Else
                                        dblUnit_Price = oPriceBLL.Get_EQP(strItem_No, oCustomer.Currency)
                                        SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), dblUnit_Price.ToString, False, Excel.XlHAlign.xlHAlignRight)
                                        '.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.0000;($#,##0.0000)"
                                        .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.000;($#,##0.00)" ' NumberFormatString(dblUnit_Price, 2, 4, True)
                                        SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), (dblMin_Qty_Ord * dblUnit_Price).ToString, False, Excel.XlHAlign.xlHAlignRight)
                                        .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString).NumberFormat = "$#,##0.00;($#,##0.00)" ' NumberFormatString((dblMin_Qty_Ord * dblUnit_Price), 2, 4, True)
                                    End If
                                    'SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), oPriceBLL.Get_EQP(dtImage.Rows(0).Item("Item_No").ToString, oCustomer.Currency))
                                    '.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$ #,##0.0000_);($ #,##0.0000)"
                                    ''SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), "E.Q.P.")
                                Else
                                    dblUnit_Price = drDetail.item("Unit_Price").ToString
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString), dblUnit_Price.ToString, False, Excel.XlHAlign.xlHAlignRight)
                                    '.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.0000;($#,##0.0000)"
                                    .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 1).ToString).NumberFormat = "$#,##0.000;($#,##0.00)" ' NumberFormatString(dblUnit_Price, 2, 4, True)
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString), (dblMin_Qty_Ord * dblUnit_Price).ToString, False, Excel.XlHAlign.xlHAlignRight)
                                    .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 2).ToString).NumberFormat = "$#,##0.00;($#,##0.00)" ' NumberFormatString((dblMin_Qty_Ord * dblUnit_Price), 2, 4, True)
                                End If
                                If Not (drDetail.item("Run_Charge").Equals(DBNull.Value)) Then
                                    SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString), drDetail.item("Run_Charge").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                    .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 3).ToString).NumberFormat = "$#,##0.00;($#,##0.00)" ' NumberFormatString(drDetail.item("Run_Charge"), 2, 4, True)
                            End If

                            '++ID 20.05.2015 added setup price
                            If Not (drDetail.item("SETUP_PRICE").Equals(DBNull.Value)) Then
                                SetStyleNormal(.Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 4).ToString), drDetail.item("SETUP_PRICE").ToString, False, Excel.XlHAlign.xlHAlignRight)
                                .Range(Chr(iColumnPos) & (iCurrentRow + iRowItem + 4).ToString).NumberFormat = "$#,##0.00;($#,##0.00)" ' NumberFormatString(drDetail.item("Run_Charge"), 2, 4, True)
                            End If

                                iColumnPos += 1

                            Next

                            iRowItem = 4
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "COLOR(S):")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strColor, True)

                            iRowItem = 5
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "DECORATION:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strDecorating, True)

                            iRowItem = 6
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "PACKAGING:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strPackaging, True)

                            iRowItem = 7
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "TYPE:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strQUOTE_TYPE_DESC, True)

                            iRowItem = 8
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "SHIPPING:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strQUOTE_SHIP_METHOD_DESC, True)

                            iRowItem = 9
                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "SETUP:")
                            SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strSETUP_STRING, True)

                        If IsNumeric(strSETUP_STRING) Then
                            .Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString).NumberFormat = "$#,##0.00;($#,##0.00)"
                        End If
                            'iRowItem = 9
                            'SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "RUN CHARGE:")
                            'SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), strSETUP_STRING, True)

                            iRowItem = 10

                            If strGuid_List <> "" Then

                                Dim iCommentCount As Integer = 0
                            'For Each drDetail In dtItemsDetails.Rows

                            'M.TAAL_CD = '" & oCustomer.Taal_Cd.Trim & "' AND " & _

                            strSql =
                            " SELECT     DISTINCT ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, 0 As  MSG_ORDER, Prog_Comment_ID " &
                            " FROM       MDB_Prog_Comment P WITH (NOLOCK) " &
                            " WHERE      P.CUS_PROG_GUID = '" & oMdb_Cus_Prog.Cus_Prog_Guid & "' AND " &
                            "			ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN (" & strGuid_List & ") AND " &
                            "           ISNULL(P.COMMENT_DESC, '') <> '' AND P.MESSAGE_ID = 0 " &
                            "  UNION      " &
                            " SELECT	    DISTINCT CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC, " &
                            "  M.MSG_ORDER, '' As PROG_COMMENT_ID  FROM	MDB_MESSAGE_DESC_VIEW M " &
                            " LEFT JOIN	MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID " &
                            " WHERE		M.TAAL_CD = '" & Trim(taalC) & "' AND " &
                            "			P.CUS_PROG_GUID = '" & oMdb_Cus_Prog.Cus_Prog_Guid & "' AND " &
                            "			ISNULL(Prog_Comment_ID, 0) <> 0 AND " &
                            "			ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN (" & strGuid_List & ") "

                            '++ID 10.19.2018 Exception for Section301 insert message only in the case for US client
                            If strCurrency = "USD" Then
                                strSql &= " UNION " &
                           " Select Case FV.VALUE_INT When 1 Then cg.FLD_NAME   End AS COMMENT_DESC, " &
                           " 100 As  MSG_ORDER, fv.ITEM_FLD_VALUE_ID  as Prog_Comment_ID   FROM " &
                           "  MDB_ITEM_MASTER m   WITH (NOLOCK) inner join  MDB_ITEM_FLD_VALUE fv  WITH (NOLOCK) on  " &
                           " m.ITEM_MASTER_ID = FV.ITEM_MASTER_ID inner join MDB_CFG_ITEM_FLD cg On " &
                           " FV.ITEM_FLD_ID = cg.ITEM_FLD_ID  where item_cd = '" & dtRow.Item("Item_Cd").ToString.Trim & "' and cg.ITEM_FLD_ID = 529 " &
                           " and FV.VALUE_INT = 1  order by MSG_ORDER asc, PROG_COMMENT_ID asc "
                            Else

                                strSql &= " order by MSG_ORDER asc, PROG_COMMENT_ID asc "
                            End If
                            '    "ORDER BY	COMMENT_DESC "

                            '"ORDER BY	Case When ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END "

                            dtComments = db.DataTable(strSql)

                                If dtComments.Rows.Count <> 0 Then
                                    For Each drComment As DataRow In dtComments.Rows
                                        If iCommentCount = 0 Then
                                            SetStyleH5(.Range("C" & (iCurrentRow + iRowItem).ToString), "COMMENTS:")
                                            iCommentCount += 1
                                        End If
                                        SetStyleNormal(.Range("D" & (iCurrentRow + iRowItem).ToString), drComment.Item("Comment_Desc").ToString)
                                        iCurrentRow += 1
                                    Next drComment

                                    iCurrentRow += 12
                                Else

                                    iCurrentRow += 13

                                End If

                            Else

                                iCurrentRow += 13

                            End If

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                '########################################################################
                '#      SECTION DES CHARGES
                '########################################################################

                iStartRow = iCurrentRow
                iRowItem = 0

                ' ON INCLUE LES CHARGES PARCE QU'ELLES SONT ORDER LEVEL MAIS PAS LES SETUPS
                ' PARCE QU'ILS SONT LINE LEVEL.
                strSql = _
                "SELECT		ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.CHARGE_ID, C.CHARGE_CD, " & _
                "           ISNULL(CU.CUS_PROG_ID, 0) AS CUS_PROG_ID, C.DESCRIPTION, C.SHORT_DESC, CU.CUS_NO, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
                "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NO_CHARGE, " & _
                "			ISNULL(CU.UNIT_PRICE, 0) AS UNIT_PRICE, " & _
                "           CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  + " & _
                "           CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END  + " & _
                "           ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS " & _
                "            FROM " & _
                "	(	SELECT	CUS.CUS_NO, C.*" & _
                "		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
                "	) C " & _
                "INNER JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " & _
                "INNER JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no AND CU.CUS_PROG_ID = " & oMdb_Cus_Prog.Cus_Prog_Id & " " & _
                "WHERE		C.CUS_NO = '" & oMdb_Cus_Prog.Cus_No & "' AND CU.CHARGE_ID <> 27 " & _
                "ORDER BY	(CASE WHEN CU.CHARGE_USAGE_ID IS NOT NULL THEN 1 ELSE 0 END) DESC,  " & _
                "           CH.CHARGE_ORDER, C.SHORT_DESC "

                '"ORDER BY	C.CUS_NO, CH.CHARGE_ORDER, C.SHORT_DESC "
                'CHARGE_USAGE_ID(,CHARGE_ID()), CHARGE_CD()
                'CUS_PROG_ID(), 'DESCRIPTION(), 'SHORT_DESC(), 'CUS_NO()
                'ALWAYS_USE(), 'NEVER_USE(), 'NO_CHARGE()
                'UNIT_PRICE(), 'EXT_COMMENTS()

                dtOptions = db.DataTable(strSql)

                Dim blnCommentsLabelShown As Boolean = False
                If dtOptions.Rows.Count <> 0 Then
                    '++ID 04.03.2015 :K -> :L
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "COMMENTS", True)
                    blnCommentsLabelShown = True

                    iCurrentRow += 2

                    For Each dtRow As DataRow In dtOptions.Rows

                        Dim strOptionString As String = ""

                        'iCurrentRow = iStartRow + (iItemCount * 8)
                        iRowItem = 0

                        If dtRow.Item("Always_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        ElseIf dtRow.Item("Never_Use") <> 0 Then
                            strOptionString = "ALWAYS USE " & dtRow.Item("Description").ToString.Trim & ", "
                        Else
                            strOptionString = "FOR " & dtRow.Item("Description").ToString.Trim & ", "
                        End If

                        If dtRow.Item("No_Charge") <> 0 Then
                            strOptionString &= "THERE WILL BE NO CHARGE APPLIED."
                        Else
                            If dtRow.Item("Unit_Price") <> 0 Then
                                'Dim a1 As String = dtRow.Item("Unit_Price")
                                'a1 = CDbl(a1).ToString("N3", CultureInfo.InvariantCulture)
                                strOptionString &= "CHARGE PRICE WILL BE $" & CDbl(dtRow.Item("Unit_Price")).ToString("N3", CultureInfo.InvariantCulture)
                                '.NumberFormat = "$#,##0.00;($#,##0.00)
                                'strOptionString = "CHARGE PRICE WILL BE " & dtRow.Item("Unit_Price").ToString.Format("N3", CultureInfo.InvariantCulture).ToString
                            Else
                                strOptionString &= "REGULAR CHARGE PRICE APPLY"
                            End If
                        End If

                        SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), strOptionString, True)

                        iCurrentRow += 1

                    Next dtRow

                    iStartRow = iCurrentRow
                    iRowItem = 0

                End If

                If Not blnCommentsLabelShown Then
                    '++ID 04.03.2015 :K -> :L
                    SetStyleH2(.Range("B" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), "COMMENTS", True)
                    blnCommentsLabelShown = True

                    iCurrentRow += 2

                End If

                ' COMMENTS SHOWN ON EVERY ORDER
                'WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.
                ''SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), "THIS QUOTE IS VALID FOR 2 WEEKS, BEGINNING THE DAY OF THE START DATE, INCLUDING THE DAY OF THE END DATE.", True)
                SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), "*** THIS QUOTE IS VALID FOR 2 WEEKS ***", True)
                iCurrentRow += 1

                If oCustomer.Currency = "USD" Then
                    SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":L" & (iCurrentRow + 1).ToString), "*** Please note that all prices quoted are subject to change due to the additional tariffs proposed by Section 301.Once the final list of affected items is published  we will inform you of changes to pricing, should it apply.",
                                      True, Excel.XlHAlign.xlHAlignLeft, True)
                    iCurrentRow += 2

                    SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":G" & (iCurrentRow).ToString), "*** Only products that are FSC certified are covered by FSC certificate SCS-COC-009085",
                                    True, Excel.XlHAlign.xlHAlignLeft, True)
                    iCurrentRow += 1
                Else
                    SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":G" & (iCurrentRow).ToString), "*** Seuls les produits certifiés FSC sont couverts par le certificat FSC SCS-COC-009085",
                                 True, Excel.XlHAlign.xlHAlignLeft, True)
                    iCurrentRow += 1
                End If


                'SetStyleNormal(.Range("B" & iCurrentRow.ToString & ": I" & iCurrentRow.ToString), "WHEN NO RUN CHARGE PRICES ARE SHOWN, THEN REGULAR RUN CHARGE PRICES APPLY.", True)
                'iCurrentRow += 1

                'strsql = _
                '"SELECT	    ISNULL(Prog_Comment_ID, 0) as Prog_Comment_ID, P.CUS_PROG_ID, P.CUS_PROG_GUID, " & _
                '"			P.CUS_PROG_ITEM_LIST_GUID, M.MESSAGE_ID, ISNULL(Prog_Comment_ID, 0) as CHECK_VALUE, " & _
                '"			CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC, P.USER_LOGIN, P.UPDATE_TS " & _

                'oCustomer.Taal_Cd.Trim 

                strSql = _
                "SELECT     DISTINCT PROG_COMMENT_ID, ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, 0 As MSG_ORDER, Prog_Comment_ID " & _
                "FROM       MDB_Prog_Comment P WITH (NOLOCK) " & _
                "WHERE      P.CUS_PROG_GUID = '" & oMdb_Cus_Prog.Cus_Prog_Guid & "' AND " & _
                "           ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND " & _
                "           ISNULL(P.ITEM_CD, '') = '' AND " & _
                "           ISNULL(P.COMMENT_DESC, '') <> '' AND P.MESSAGE_ID = 0 " & _
                " UNION      " & _
                "SELECT	    DISTINCT 0 AS PROG_COMMENT_ID, CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC, " & _
                "  M.MSG_ORDER, '' As PROG_COMMENT_ID  FROM		MDB_MESSAGE_DESC_VIEW M " & _
                "LEFT JOIN	MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID " & _
                "WHERE		M.TAAL_CD = '" & Trim(taalC) & "' AND " & _
                "			P.CUS_PROG_GUID = '" & oMdb_Cus_Prog.Cus_Prog_Guid & "' AND " & _
                "			ISNULL(Prog_Comment_ID, 0) <> 0 AND " & _
                "			ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND " & _
                "			ISNULL(P.ITEM_CD, '') = '' " & _
                "  order by MSG_ORDER asc, P.PROG_COMMENT_ID asc "

                '"ORDER BY	COMMENT_DESC "

                '"ORDER BY	CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END " 

                dtComments = db.DataTable(strSql)

                If dtComments.Rows.Count <> 0 Then

                    For Each drComment As DataRow In dtComments.Rows
                        'SetStyleNormal(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), drDetail.item("Comment_Desc").ToString, True)
                        SetStyleNormal(.Range("B" & iCurrentRow.ToString), drComment.Item("Comment_Desc").ToString)
                        iCurrentRow += 1
                    Next drComment

                End If

                '########################################################################
                '#      SECTION DE BAS DE PAGE DU RAPPORT
                '########################################################################

                'iCurrentRow += 2

                'iStartRow = iCurrentRow
                'iRowItem = 0

                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "ABOVE PRICING AND INVENTORY GUARANTEED THROUGH:", True)
                'If Not (dtHeader.Rows(0).Item("Quote_End_Dt").Equals(DBNull.Value)) Then
                '    SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), CDate(dtHeader.Rows(0).Item("Quote_End_Dt")).ToShortDateString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '    .Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"
                'End If

                'iRowItem = 1
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

                'iRowItem = 4
                'SetStyleNormal(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), dtHeader.Rows(0).Item("CSR_Fullname").ToString.Trim, True, Excel.XlHAlign.xlHAlignCenter)
                'SetStyleNormal(.Range("G" & (iCurrentRow + iRowItem).ToString), Date.Now.ToString.Trim, False, Excel.XlHAlign.xlHAlignCenter)
                '.Range("G" & (iCurrentRow + iRowItem).ToString).NumberFormat = "m/d/yyyy"

                'iRowItem = 5
                'SetStyleH4(.Range("B" & (iCurrentRow + iRowItem).ToString & ":E" & (iCurrentRow + iRowItem).ToString), "SUPPLIER REPRESENTATIVE, ABOVE", True)
                'SetStyleH4(.Range("G" & (iCurrentRow + iRowItem).ToString), "DATE")

            End With

            Dim strFileName As String
            '++ID 19.1.15
            Dim strPath As String = "C:\Quote confirmation\"

            If Not (Directory.Exists(strPath)) Then
                MkDir(strPath)
            End If

            If strRevision = "" Then
                strFileName = strPath & "Quote confirmation " & oMdb_Cus_Prog.Spector_Cd & ".PDF"
            Else
                strFileName = strPath & "Quote confirmation " & oMdb_Cus_Prog.Spector_Cd & " " & strRevision & ".PDF"
            End If

            '++ID 22.01.15
            If File.Exists(strFileName) Then
                File.Delete(strFileName)
                Debug.Print("Deleted file name :" & strFileName)
            End If

            iCurrentRow += 2
            'xlApp.PrintCommunication = True
            xlWorkSheet.PageSetup.PrintArea = "A1:L" & iCurrentRow

            xlApp.PrintCommunication = False
            SetPrintingProperties(xlWorkSheet)
            xlApp.PrintCommunication = True

            xlWorkSheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, strFileName)

            '   xlApp.Visible = True 
            '   xlWorkBook.Close(True) 
            xlApp.Quit()

            Dim oDocSave As New cMdb_Cus_Document_BLL()
            oDocSave.AddDocumentFile(oMdb_Cus_Prog.Cus_No, 38, strFileName, oMdb_Cus_Prog.Cus_Prog_Guid)

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strFileName
            Process.Start(startInfo)


        Catch er As Exception
            'Call UnsetExportTS()
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message & " " & errPos.ToString)
            'xlWorkBook.Close(False)
            'xlApp.Quit()
        Finally
            'Try
            'xlApp.Visible = True
            'Catch ex As Exception
            'End Try
            Try
                '    xlApp.Visible = True
                ' xlWorkBook.Sheets(1) = Nothing
                ' xlWorkBook.Close(False)
            Catch ex As Exception
            Finally
                'xlWorkSheet = Nothing
                xlWorkBook = Nothing
                'If IStartedXL Then
                Debug.Print("CLOSE EXCEL PROCESS " & MyExcelProcessID.ToString)
                Dim myExcelProcess As Process = Process.GetProcessById(MyExcelProcessID)
                myExcelProcess.Kill()
                'End If
                xlApp = Nothing
            End Try
        End Try
    End Sub

    Private Sub SetGreyInterior(ByRef oCellGreyInterior As Excel.Interior)

        With oCellGreyInterior
            .Pattern = Excel.XlPattern.xlPatternSolid
            .PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            .ThemeColor = Excel.XlThemeColor.xlThemeColorDark1
            .TintAndShade = -0.249977111117893
            .PatternTintAndShade = 0
        End With

    End Sub

    Private Sub SetPrintingProperties(ByRef oSheet As Excel.Worksheet)

        With oSheet.PageSetup

            '.LeftHeader = ""
            '.CenterHeader = ""
            '.RightHeader = ""
            '.LeftFooter = ""
            '.CenterFooter = ""
            '.RightFooter = ""
            '.LeftMargin = Application.InchesToPoints(0.7)
            '.RightMargin = Application.InchesToPoints(0.7)
            '.TopMargin = Application.InchesToPoints(0.75)
            ' .BottomMargin = Application.InchesToPoints(0.75)
            '.HeaderMargin = Application.InchesToPoints(0.3)
            '.FooterMargin = Application.InchesToPoints(0.3)
            '.PrintHeadings = False
            '.PrintGridlines = False
            '.PrintComments = xlPrintNoComments
            '.PrintQuality = 1200
            .TopMargin = .Application.InchesToPoints(0.5)
            .BottomMargin = .Application.InchesToPoints(0.75)
            .CenterHorizontally = False
            .CenterVertically = False
            .Orientation = Excel.XlPageOrientation.xlPortrait
            .Draft = False
            .PaperSize = Excel.XlPaperSize.xlPaperLetter
            .BlackAndWhite = False
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = 0
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True

        End With

    End Sub

    Private Sub SetStyleH1(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter)

        With oRange

            SetGreyInterior(.Interior)

            .Font.Bold = True
            .Font.Size = 24

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With

    End Sub

    Private Sub SetStyleH2(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter)

        With oRange

            SetGreyInterior(.Interior)

            .Font.Bold = True
            .Font.Size = 16

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With

    End Sub

    Private Sub SetStyleH3(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter)

        With oRange

            SetGreyInterior(.Interior)

            .Font.Bold = True
            .Font.Size = 12

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With

    End Sub

    Private Sub SetStyleH4(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter)

        With oRange

            SetGreyInterior(.Interior)

            .Font.Bold = True
            .Font.Size = 10

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With

    End Sub

    Private Sub SetImage(ByRef oSheet As Excel.Worksheet, ByRef oRange As Excel.Range, ByVal pstrPath As String, ByVal piHeight As Integer, ByVal piWidth As Integer)

        If pstrPath <> "" Then
            With oSheet.Pictures.Insert(pstrPath)

                .Left = oRange.Left
                .Top = oRange.Top
                .Height = piHeight
                .Width = piWidth
                .ShapeRange.IncrementTop(2.25)

            End With
        End If

    End Sub

    Private Sub SetStyleH5(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft)

        With oRange

            .Font.Bold = True
            .Font.Size = 10

            .HorizontalAlignment = oAlign
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With

    End Sub

    Private Sub SetStyleNormal(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft, Optional ByVal pWrapText As Boolean = False)

        With oRange

            .Font.Bold = False
            .Font.Size = 10

            .HorizontalAlignment = oAlign
            .VerticalAlignment = Excel.XlVAlign.xlVAlignTop 'xlVAlignCenter
            .WrapText = pWrapText
            .MergeCells = pMerge
            .FormulaR1C1 = pValue




        End With


    End Sub


    Private Sub MergeCells(ByRef oRange As Excel.Range)

        With oRange
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .WrapText = False
            .Orientation = 0
            .AddIndent = False
            .IndentLevel = 0
            .ShrinkToFit = False
            '.ReadingOrder = xlContext
            .MergeCells = True
        End With

    End Sub

    Public Sub Mass_Add(ByVal pWords As String(), ByRef pdgvItems As DataGridView, ByRef pdtItems As DataTable, ByRef pProgram As cMdb_Cus_Prog)

        Try

            For Each oWord As String In pWords
                ItemLineInsert(pdgvItems, pdtItems)
                pdgvItems.Rows(pdgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value = oWord
                pdgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value = Get_Item_Description(oWord)
                SetColorCombo(pdgvItems.Rows(pdgvItems.Rows.Count - 1).Cells(Items.ITEM_COLOR), oWord, " ALL")
                pdgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = " ALL"
                pdgvItems.CurrentRow.Cells(Items.EQP_LEVEL).Value = True
            Next oWord

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub ProductLineInsert(ByRef dgvItems As DataGridView, ByRef dtItems As DataTable, ByRef pProgram As cMdb_Cus_Prog, Optional ByVal pstrItem_Cd As String = "")

        Debug.Print("ProductLineInsert")

        Try
            Dim dtTable1 As DataTable = Nothing
            If dgvItems.Rows.Count = 0 Then

                LineInsert(dgvItems, dtItems)

            ElseIf Not (dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value.Equals(DBNull.Value)) Then

                If Not Trim(dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value).Equals("") Then
                    If (dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value.Equals(DBNull.Value)) Then
                        dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value = Get_Item_Description(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value)

                    ElseIf dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value = String.Empty Then
                        dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value = Get_Item_Description(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value)
                    End If
                    If (dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.Equals(DBNull.Value)) Then


                        Call SetColorCombo(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR), dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString, dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString, dtTable1)
                        '   dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = "ALL"

                        If dtTable1.Rows.Count <> 0 Then
                            dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = dtTable1.Rows(1).Item("Item_Color").ToString

                            Dim item_no = displayItemNo(Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)), Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString)))

                            dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value = item_no

                        Else
                            dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = dtTable1.Rows(0).Item("Item_Color").ToString
                        End If

                        dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Selected = True

                    ElseIf dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = String.Empty Then
                        Call SetColorCombo(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR), dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString, dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString)
                        dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = "ALL"
                    End If
                    If Not (dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_COLOR).Value.Equals(DBNull.Value)) Then
                        If Not Trim(dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_COLOR).Value).Equals("") Then
                            LineInsert(dgvItems, dtItems)
                        End If
                    End If
                Else
                    dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)
                End If

            Else
                dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)
            End If

            If (pProgram.Prog_Type = 3) And (pstrItem_Cd <> String.Empty) Then
                dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value = pstrItem_Cd
                dgvItems.EndEdit()
            End If

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Public Sub ItemLineInsert(ByRef dgvItems As DataGridView, ByRef dtItems As DataTable)

        Debug.Print("ItemLineInsert")

        Try

            If dgvItems.Rows.Count = 0 Then

                Call LineInsert(dgvItems, dtItems)

            ElseIf Not (dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value.Equals(DBNull.Value)) Then

                If Not Trim(dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value).Equals("") Then
                    Call LineInsert(dgvItems, dtItems)
                Else
                    dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)
                End If

            Else

                dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)

            End If

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub LineInsert(ByRef dgvItems As DataGridView, ByRef dtItems As DataTable)

        Debug.Print("LineInsert")

        Try
            Dim drNewRow As DataRow
            dgvItems.AllowUserToAddRows = True

            Dim colHidden As New Collection
            For Each drRow As DataGridViewRow In dgvItems.Rows
                If drRow.Visible = False Then colHidden.Add(drRow.Index.ToString, drRow.Index.ToString)
            Next

            drNewRow = dtItems.NewRow

            dtItems.Rows.Add(drNewRow)

            dgvItems.AllowUserToAddRows = False
            dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)

            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value = String.Empty
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.CUSTOM_ITEM_ID).Value = 0
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.MIN_QTY_ORD).Value = 0
            '++ID 15.05.2015 value par default 0.00 for Unite_Price
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.UNIT_PRICE).Value = 0.0 'DBNull.Value
            '++ID 15.05.2015 value par default 0 for EQP Level

            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.EQP_LEVEL).Value = 0


            'justin add 20191001
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_SUBSTITUTE).Value = "."

            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_NO).Value = String.Empty
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_COLOR).Value = String.Empty

            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.EQP_PCT).Value = 0.0 'DBNull.Value
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.CHARGE_ID).Value = DBNull.Value
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.RUN_CHARGE).Value = DBNull.Value
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.SETUP_WAIVED).Value = False
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.SETUP_PRICE).Value = DBNull.Value
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.COLOR_COUNT).Value = 1
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.LOCATION_COUNT).Value = 1
            'dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.OVERSEAS).Value = DBNull.Value
            'dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.DOMESTIC).Value = DBNull.Value
            'dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.RUN_CHARGE).Value = DBNull.Value
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = Guid.NewGuid()
            dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.LINE_COMMENTS).Value = "Comments"

            dgvItems.Focus()

            For Each oHidden In colHidden
                dgvItems.Rows(CInt(oHidden.ToString)).Visible = False
            Next

            dgvItems.BeginEdit(True)

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function Get_Item_Description(ByVal pstrItem_Cd As String) As String

        Get_Item_Description = ""

        'trysdxf() ' also set item descrption with custom_item_id

        Try

            Dim DB As New cDBA()
            Dim dtItem As DataTable

            'Ion I change MDB_ITEM => MDB_ITEM_OLD only for THOR dbo.100
            Dim strSql As String

            'strSql = _ 
            ' "SELECT ISNULL(LONG_ITEM_DESC, '') as LONG_ITEM_DESC " & _
            '"FROM MDB_ITEM WITH (Nolock) " & _
            '"WHERE ITEM_CD = '" & pstrItem_Cd.Trim.ToUpper & "' "

            '++ID changed MDB_ITE -> imitmidx_sql  10.08.2016
            strSql =
                " select top 1 search_desc from imitmidx_sql " &
                 " where user_def_fld_1 = '" & pstrItem_Cd.Trim.ToUpper & "' " &
                 " and item_no not like '%AST' and  item_no not like 'ACT%' and " &
                 " item_no not like 'XX%' AND item_no not like 'ZZ%' "

            '++ID 08.02.2022 added inf from ITEM_NOTE_1 in Item_description , need to show FSC info if is the case
            strSql =
                " select top 1 case when ISNULL(item_note_1,'') <> '' then ISNULL(ltrim(rtrim(item_note_1)),'') + ', ' + Ltrim(rtrim(item_desc_1)) else Ltrim(rtrim(item_desc_1)) end As item_desc_1 " &
                 " from imitmidx_sql  where user_def_fld_1 = '" & pstrItem_Cd.Trim.ToUpper & "' " &
                 " and item_no not like '%AST' and  item_no not like 'ACT%' and " &
                 " item_no not like 'XX%' AND item_no not like 'ZZ%' "

            dtItem = DB.DataTable(strSql)
            If dtItem.Rows.Count <> 0 Then


                ' Get_Item_Description = dtItem.Rows(0).Item("search_desc").ToString
                Get_Item_Description = dtItem.Rows(0).Item("item_desc_1").ToString

            Else
                strSql = _
                "SELECT ISNULL(PROD_CAT_DESC, '') as PROD_CAT_DESC " & _
                "FROM MDB_CFG_PROD_CAT WITH (Nolock) " & _
                "WHERE PROD_CAT_CODE = '" & pstrItem_Cd.Trim.ToUpper & "' "

                dtItem = DB.DataTable(strSql)
                If dtItem.Rows.Count <> 0 Then
                    Get_Item_Description = dtItem.Rows(0).Item("PROD_CAT_DESC").ToString
                End If

            End If

        Catch er As Exception
            MsgBox("Error in cMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function Get_Custom_Item_Desc(ByVal pintCustom_Item_Id As Integer) As String

        Get_Custom_Item_Desc = ""

        Try

            Dim DB As New cDBA()
            Dim dtItem As DataTable

            Dim strSql As String = _
            "SELECT ISNULL(ENUM_VALUE, '') as LONG_ITEM_DESC " & _
            "FROM   MDB_CFG_ENUM WITH (Nolock) " & _
            "WHERE  ENUM_CAT = 'CUSTOM_ITEMS' AND ID = " & pintCustom_Item_Id & " "

            dtItem = DB.DataTable(strSql)
            If dtItem.Rows.Count <> 0 Then
                Get_Custom_Item_Desc = dtItem.Rows(0).Item("LONG_ITEM_DESC").ToString
            End If

        Catch er As Exception
            MsgBox("Error in cMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    ' This should be identical to the enum in frmQuickProgram. 
    ' frmQuickProgram HAS the right definition and this is only a copy of it.
    Private Enum Items

        CUS_PROG_ITEM_LIST_ID
        CUS_PROG_ID
        PROD_CAT_ID
        ITEM_CD
        CUSTOM_ITEM_ID
        ITEM_DESC
        ITEM_NO
        ITEM_COLOR
        QUOTE_TYPE_ID
        'justin 2019091001
        ITEM_SUBSTITUTE
        QUOTE_SHIP_METHOD_ID
        MIN_QTY_ORD
        UNIT_PRICE
        EQP_LEVEL
        EQP_PCT
        DEC_MET_ID
        DEC_MET_GROUP_ID
        SETUP_WAIVED
        SETUP_PRICE
        CHARGE_ID
        RUN_CHARGE
        COLOR_COUNT
        LOCATION_COUNT
        PACK_ID
        'OVERSEAS
        'DOMESTIC
        USER_LOGIN
        UPDATE_TS
        DIRTY
        CUS_PROG_ITEM_LIST_GUID
        LINE_COMMENTS

    End Enum


    '    '
    '    ActiveSheet.Pictures.Insert("C:\Chandail Vanek.jpg").Select()

    '    Range("B2:I4").Select()
    '    ActiveWindow.SmallScroll(Down:=27)
    '    ActiveSheet.Shapes.Range(Array("Picture 1")).Select()
    '    Selection.ShapeRange.IncrementLeft(-339)
    '    Selection.ShapeRange.IncrementTop(-105.75)
    '    Selection.ShapeRange.ScaleWidth(0.2666666667, msoFalse, msoScaleFromTopLeft)
    '    Selection.ShapeRange.ScaleHeight(0.2666666667, msoFalse, msoScaleFromTopLeft)
    '    ActiveWindow.SmallScroll(Down:=-18)
    '    Selection.ShapeRange.IncrementLeft(-21)
    '    Selection.ShapeRange.IncrementTop(-275.25)
    '    ActiveWindow.SmallScroll(Down:=-21)
    '    Selection.ShapeRange.IncrementLeft(-9.75)
    '    Selection.ShapeRange.IncrementTop(-168)
    '    Selection.ShapeRange.ScaleHeight(0.8854166667, msoFalse, msoScaleFromTopLeft)
    '    Range("C5").Select()
    '    ActiveSheet.Shapes.Range(Array("Picture 1")).Select()
    '    Selection.ShapeRange.ScaleWidth(0.99609375, msoFalse, msoScaleFromBottomRight)
    '    Range("A3").Select()
    'End Sub

    Public Sub SetColorCombo(ByRef pProgram As cMdb_Cus_Prog, ByVal cboColumn As DataGridViewComboBoxColumn)

        Try
            With cboColumn
                '.DataSource = RetrieveAlternativeTitles()

                '.ValueMember = "RouteId" ' ColumnName.TitleOfCourtesy.ToString()
                .DataSource = ChangeCboColorList(pProgram)

                .ValueMember = "Item_Color" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "Item_Color"

            End With

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Public Sub SetColorCombo(ByVal cboCell As DataGridViewComboBoxCell, ByVal pstrItem_Cd As String, ByVal pstrValue As String, Optional ByRef refColor As DataTable = Nothing)

        Try
            Dim dtTable As DataTable
            dtTable = ChangeCboColorList(pstrItem_Cd, pstrValue)

            If dtTable.Rows.Count <> 0 Then
                With cboCell
                    '.DataSource = RetrieveAlternativeTitles()
                    '.ValueMember = "RouteId" ' ColumnName.TitleOfCourtesy.ToString()
                    .DataSource = dtTable '.Rows(0).Item("Item_Color").ToString 'ChangeCboColorList(pstrItem_Cd, pstrValue)

                    refColor = dtTable  'ChangeCboColorList(pstrItem_Cd, pstrValue).Rows(0).Item("Item_Color").ToString

                    '.ValueMember = "Item_Color" 'ColumnName.TitleOfCourtesy.ToString() 
                    'justin20200106 change for display color_code
                    .ValueMember = "color_id"
                    .DisplayMember = "Item_Color"
                End With
            End If
        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub




    Public Sub SetDecomethNew(ByVal cboCell As DataGridViewComboBoxCell, ByVal pstrItem_Cd As String)

        Try
            Dim dtTable As DataTable
            dtTable = ChangeDecoMethList(pstrItem_Cd)

            If dtTable.Rows.Count <> 0 Then
                With cboCell
                    '.DataSource = RetrieveAlternativeTitles()
                    '.ValueMember = "RouteId" ' ColumnName.TitleOfCourtesy.ToString()
                    .DataSource = dtTable '.Rows(0).Item("Item_Color").ToString 'ChangeCboColorList(pstrItem_Cd, pstrValue)



                    .ValueMember = "DEC_MET_ID" 'ColumnName.TitleOfCourtesy.ToString()
                    .DisplayMember = "DEC_MET_NAME"
                End With
            End If
        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    Private Function ChangeCboColorList(ByRef pProgram As cMdb_Cus_Prog) As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeCboColorList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql = _
            "SELECT     DISTINCT LTRIM(RTRIM(Item_Color)) AS Item_Color " & _
            "FROM       MDB_CUS_PROG_ITEM_LIST " & _
            "WHERE      CUS_PROG_ID = " & pProgram.Cus_Prog_Id.ToString & _
            " ORDER BY   Item_Color "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboColorList = dt

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    '++ID 19.05.2015 function boolean for advise if price is same for all of item_cd
    'if one from item_cd have a price different, boolean is true 
    'This function is for ChangeCboColorList(ByVal strItem_Cd As String, ByVal pstrValue As String)
    Private Function DifferentPrice(ByVal strItem_cd As String) As Boolean
        DifferentPrice = False

        Dim strSql As String
        Dim dt As DataTable
        Dim db As New cDBA

        strSql = _
       " Select * from oeprcfil_sql o inner join " & _
       " imitmidx_sql m on o.cd_tp_1_item_no = m.Item_No " & _
       " where m.user_def_fld_1 = '" & strItem_cd & "' and o.cd_tp_1_cust_no = '' " & _
       " and o.cd_tp_3_cust_type = '' and o.curr_cd = 'CAD' "


        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then

            For Each drRow As DataRow In dt.Rows

                For i As Integer = 0 To dt.Rows.Count - 1
                    If drRow.Item("prc_or_disc_2") <> dt.Rows(i).Item("prc_or_disc_2") Then
                        DifferentPrice = True
                        Exit Function
                    End If
                Next

            Next

        End If

    End Function

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function ChangeCboColorList(ByVal strItem_Cd As String, ByVal pstrValue As String) As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeCboColorList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql = _
                   " select LTRIM(RTRIM(user_def_fld_2)) As Item_Color from imitmidx_sql  " & _
                   " where (user_def_fld_1 = '" & Trim(RTrim(strItem_Cd)) & "' or user_def_fld_1 = '66" & Trim(RTrim(strItem_Cd)) & "') " & _
                   " And item_no not like 'AC%' and item_no not like 'X%' and item_no not like '%AST' and  item_no not  like '%Z%' " & _
                   " AND item_no not  like 'USS%' AND user_def_fld_2 IS NOT NULL "
            '++ID 1.8.2018

            'justin changed 20200106''
            strSql =
                   " select LTRIM(RTRIM(Color_List))+'-'+color_code As Item_Color , color_id as color_id from View_MDB_ITEM_DETAIL  " &
                   " where (ITEM_CD = '" & Trim(RTrim(strItem_Cd)) & "' or ITEM_CD = '66" & Trim(RTrim(strItem_Cd)) & "') " &
                   " And item_no not like 'AC%' and item_no not like 'X%' and item_no not like '%AST' and  item_no not  like '%Z%' " &
                   " AND item_no not  like 'USS%' "
            ''

            ' AND Color_List IS NOT NULL

            '"SELECT     DISTINCT COLOR_LIST AS Item_Color " & _
            '"FROM       MDB_ITEM_DETAIL " & _
            '"WHERE      ITEM_CD = '" & strItem_Cd & "' " & _

            '++ID 1.31.2018 put in comment DefferentPrice.. 
            'we need have -all- for open frmAllItems
            '  If DifferentPrice(strItem_Cd) = False Then
            strSql &=
            " UNION " &
            " SELECT     'ALL' AS Item_Color , 'ALL' as color_id " 'justin 20200103 change
            'in comment from 3.29.2018
            '" UNION " &
            '" SELECT   ' MULTI' AS Item_Color "
            '  End If



            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboColorList = dt

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    '++ID 4.17.2019
    Private Function ChangeDecoMethList(Optional ByVal strItem_Cd As String = "") As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeDecoMethList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            If Trim(strItem_Cd) = "" Then Exit Function

            strSql =
              " select  '' as DEC_MET_ID ,Cast('' As varchar(50)) As DEC_MET_NAME  " _
            & " union " _
            & " select distinct l.DEC_MET_ID,d.DEC_MET_NAME   from MDB_ITEM_MASTER m inner join MDB_ITEM_IMP_LOC l on m.ITEM_MASTER_ID = l.ITEM_MASTER_ID " _
            & " inner Join MDB_CFG_DEC_MET d On l.DEC_MET_ID = d.DEC_MET_ID  " _
            & " where isnull(l.DEC_MET_ID,0) <> 0 and item_cd = '" & Trim(strItem_Cd) & "' " _
             & " union " _
            & " select distinct m.DEC_MET_ID,m.DEC_MET_NAME   from MDB_ITEM_MASTER ma inner join  	 MDB_ITEM_IMP_LOC lm on ma.ITEM_MASTER_ID = lm.ITEM_MASTER_ID  " _
            & " inner join MDB_ITEM_IMP_LOC ls on 	lm.COMPONENT_MASTER_ID  = ls.ITEM_MASTER_ID and lm.COMPONENT_IMP_LOC_ID  = ls.ITEM_IMP_LOC_ID   " _
            & " inner join MDB_CFG_DEC_MET m on isnull(ls.DEC_MET_ID,0) = m.DEC_MET_ID where  ma.item_cd = '" & Trim(strItem_Cd) & "' "

            '++ID 4.29.2019 show decorating for kit latest sql union


            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            Return dt

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL.ChangeDecoMethList " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    'Logique de creation de revision:
    ' - on compare la revision actuelle avec la precedente. Si c'est identique, ca n'a pas bougé 
    '   alors on fait seulement remettre le flag a request pricing approval. Si c'est different
    '   on enregistre, on ajoute 1 au nombre de revisions et on met le flag a request pricing approval.
    Public Sub Create_Revision(ByRef pProgram As cMdb_Cus_Prog)

        Try

            Dim strNew_Xml As String
            strNew_Xml = Get_Program_XML(pProgram)

            If strNew_Xml <> pProgram.Revision.Rev_State Then

                Dim oRev As New cMdb_Cus_Prog_Rev()
                Dim oRev_BLL As New cMdb_Cus_Prog_Rev_BLL()

                Dim oNew As New cMdb_Cus_Prog_Rev
                oNew = oRev_BLL.Clone(pProgram.Revision)
                oNew.Rev_No = Get_Next_Rev_No(pProgram)
                pProgram.Current_Rev_No = oNew.Rev_No

                oRev_BLL.Save(oNew)

                pProgram.Quote_Step_ID = Quote_Step.Saved_Quote
                Save(pProgram)

                pProgram.Revision = oNew

            End If

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    ' This proc is used to automatically create a revision when it does not exist
    ' It is used for previous programs that did not handle revisions at the first place.
    Public Sub Create_Revision_From_Program(ByRef pProgram As cMdb_Cus_Prog)

        Try

            Dim oRev_BLL As New cMdb_Cus_Prog_Rev_BLL()

            pProgram.Current_Rev_No = 0

            With pProgram.Revision

                '.Cus_Prog_Rev_ID = 0
                .Cus_Prog_Id = pProgram.Cus_Prog_Id
                .Cicntp_ID = pProgram.Contact_ID

                .Start_Dt = pProgram.Start_Dt
                .End_Dt = pProgram.End_Dt

                .Imprint = pProgram.Imprint
                .Prog_CSR = pProgram.Prog_CSR
                '.Prog_Desc = pProgram.Prog_Desc

                .Rev_No = pProgram.Current_Rev_No
                .Rev_State = ""

                .Create_Ts = pProgram.Create_TS
                .Update_Ts = pProgram.Update_TS
                .User_Login = pProgram.User_Login

            End With

            oRev_BLL.Save(pProgram.Revision)

            pProgram.Revision.Rev_State = Get_Revision_XML(pProgram)

            oRev_BLL.Save(pProgram.Revision)
            Save(pProgram)

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    '++ID aded 02.05.2015
    ' Update revision if need
    Public Sub Create_Revision_From_Program_Update(ByRef pProgram As cMdb_Cus_Prog)

        Try

            Dim oRev_BLL As New cMdb_Cus_Prog_Rev_BLL()

            ' pProgram.Current_Rev_No = 0

            With pProgram.Revision

                '.Cus_Prog_Rev_ID = 0
                .Cus_Prog_Id = pProgram.Cus_Prog_Id
                .Cicntp_ID = pProgram.Contact_ID

                .Start_Dt = pProgram.Start_Dt
                .End_Dt = pProgram.End_Dt

                .Imprint = pProgram.Imprint
                .Prog_CSR = pProgram.Prog_CSR
                '.Prog_Desc = pProgram.Prog_Desc

                .Rev_No = pProgram.Current_Rev_No
                .Rev_State = ""

                .Create_Ts = pProgram.Create_TS
                .Update_Ts = pProgram.Update_TS
                .User_Login = pProgram.User_Login

            End With

            oRev_BLL.Save(pProgram.Revision)

            pProgram.Revision.Rev_State = Get_Revision_XML(pProgram)

            oRev_BLL.Save(pProgram.Revision)
            Save(pProgram)

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function Create_XML_Revision(ByRef pProgram As cMdb_Cus_Prog) As Boolean

        Create_XML_Revision = False

        Try


        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function


    Public Function Get_Next_Rev_No(ByRef pProgram As cMdb_Cus_Prog) As Integer

        Get_Next_Rev_No = 0

        Dim db As New cDBA
        Dim dt As DataTable

        Dim strSql As String = _
        "SELECT		MAX(ISNULL(R.REV_NO, -1)) AS MAX_REV_NO " & _
        "FROM		MDB_CUS_PROG P WITH (Nolock) " & _
        "LEFT JOIN	MDB_CUS_PROG_REV R WITH (Nolock) ON P.Cus_Prog_ID = R.Cus_Prog_ID " & _
        "           WHERE P.CUS_PROG_ID = " & pProgram.Cus_Prog_Id

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            Get_Next_Rev_No = dt.Rows(0).Item("MAX_REV_NO") + 1
        Else
            Get_Next_Rev_No = 1
        End If

    End Function


    Public Function Get_Program_XML(ByRef pProgram As cMdb_Cus_Prog) As String

        'Get_Program_XML = oMdb_Cus_Prog_DA.Get_Program_XML(pProgram).Rows(0).Item(0).ToString

        Get_Program_XML = ""
        For Each dtRow As DataRow In oMdb_Cus_Prog_DA.Get_Program_XML(pProgram).Rows
            Get_Program_XML &= dtRow.Item(0).ToString
        Next dtRow

    End Function


    Public Function Get_Revision_XML(ByRef pProgram As cMdb_Cus_Prog) As String

        'Get_Revision_XML = oMdb_Cus_Prog_DA.Get_Revision_XML(pProgram).Rows(0).Item(0).ToString

        Get_Revision_XML = ""
        For Each dtRow As DataRow In oMdb_Cus_Prog_DA.Get_Revision_XML(pProgram).Rows
            Get_Revision_XML &= dtRow.Item(0).ToString
        Next dtRow

    End Function


    Public Function Get_Revision(ByRef pProgram As cMdb_Cus_Prog) As cMdb_Cus_Prog_Rev

        Dim oRev_BLL As New cMdb_Cus_Prog_Rev_BLL
        Get_Revision = oRev_BLL.Load(pProgram)

    End Function

    Public Function ContainsCustomItems(ByRef pProgram As cMdb_Cus_Prog) As Boolean

        Return oMdb_Cus_Prog_DA.ContainsCustomItems(pProgram)

    End Function

    Public Function NumberFormatString(ByVal pNumber As Double, ByVal pMinDec As Integer, Optional ByVal pMaxDec As Integer = 0, Optional ByVal pMoney As Boolean = False) As String

        '"$#,##0.00;($#,##0.00)"
        NumberFormatString = "#,##0."
        If pMoney Then NumberFormatString = "$" & NumberFormatString

        Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        Dim iCount As Integer = 0

        If pNumber.ToString.Contains(".") Then
            iCount = pNumber.ToString.Length - (pNumber.ToString.IndexOf(nfi.CurrencyDecimalSeparator) + 1)
        Else
            iCount = pMinDec
        End If

        If pMinDec > pMaxDec Then pMaxDec = pMinDec
        If iCount < pMinDec Then iCount = pMinDec
        If iCount > pMaxDec Then iCount = pMaxDec

        NumberFormatString &= "".PadRight(iCount, "0")
        NumberFormatString = NumberFormatString & "(" & NumberFormatString & ")"

    End Function

    Public Sub SetDefaultQuoteComments(ByRef pCustomer As cCustomer, ByRef pProgram As cMdb_Cus_Prog)

        Try

            If Environment.UserName = "edward" Then
                'If Environment.UserName = "marcb" Then

                Dim oMessage As New cMdb_Prog_Comment

                If pCustomer.Default_Taal_Cd.Trim = "EN" Then

                    oMessage.Cus_Prog_Id = 0
                    oMessage.Cus_Prog_Guid = pProgram.Cus_Prog_Guid
                    oMessage.Message_Id = 0
                    oMessage.Comment_Desc = "Please note stage payments terms for Go Unique Orders:"
                    oMessage.Save()

                    oMessage = New cMdb_Prog_Comment
                    oMessage.Cus_Prog_Id = 0
                    oMessage.Cus_Prog_Guid = pProgram.Cus_Prog_Guid
                    oMessage.Message_Id = 0
                    oMessage.Comment_Desc = "33% deposit at time of order placement, 33% payment at time of shipping and balance at delivery."
                    oMessage.Save()

                Else

                    oMessage.Cus_Prog_Id = 0
                    oMessage.Cus_Prog_Guid = pProgram.Cus_Prog_Guid
                    oMessage.Message_Id = 0
                    oMessage.Comment_Desc = "Veuillez noter les termes de paiement échelonné pour les commandes Soyez Unique :"
                    oMessage.Save()

                    oMessage = New cMdb_Prog_Comment
                    oMessage.Cus_Prog_Id = 0
                    oMessage.Cus_Prog_Guid = pProgram.Cus_Prog_Guid
                    oMessage.Message_Id = 0
                    oMessage.Comment_Desc = "33% de dépôt au moment de placer la commande, 33% de paiement à l’expédition de la commande, balance à la livraison."
                    oMessage.Save()

                End If

            End If

        Catch er As Exception
            MsgBox("Error in CMDB_Cus_Prog_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Public Enum ProgramType

        Program
        SpecialPricing
        Quote

    End Enum


    Public Enum Quote_Type

        Domestic = 1
        Overseas
        Custom

    End Enum


    Public Enum Quote_Ship_Method

        Air = 1
        Ground
        Sea

    End Enum

End Class ' cMdb_Cus_Prog


