Public Class cCicmpy

    Private intID As Int32
    Private strCmp_wwn As String
    Private strCmp_code As String
    Private strCnt_id As String
    Private strCmp_parent As String
    Private strCmp_name As String
    Private strCmp_fadd1 As String
    Private strCmp_fadd2 As String
    Private strCmp_fadd3 As String
    Private strCmp_fpc As String 'zipcode
    Private strCmp_fcity As String
    Private strCmp_fcountry As String
    Private strStateCode As String
    Private strCmp_fctry As String
    Private strCmp_e_mail As String
    Private strCmp_web As String
    Private strCmp_fax As String
    Private strCmp_tel As String
    Private strCmp_note As String
    Private strCmp_acc_man As String
    Private strCmp_type As String
    Private strCmp_status As String
    Private strDevisionDebtorID As String
    Private strDevisionCreditorID As String
    Private strTextfield1 As String 'EQP,EQP PLUS
    Private strTextField11 As String
    Private strDefaultInvoiceForm As String
    Private strSalesPersonNumber As String



    Public Sub New()
            Call Init()
        End Sub
    Public Sub New(ByVal pID As Int32)
        Call Init()

    End Sub
    Public Sub New(ByVal p_strGuid As String)
            Call Init()

    End Sub
#Region "--------------Init()---------------"
        Private Sub Init()

        intID = 0
        strCmp_wwn = String.Empty
        strCmp_code = String.Empty
        strCnt_id = String.Empty
        strCmp_parent = String.Empty
        strCmp_name = String.Empty
        strCmp_fadd1 = String.Empty
        strCmp_fadd2 = String.Empty
        strCmp_fadd3 = String.Empty
        strCmp_fpc = String.Empty 'zipcode
        strCmp_fcity = String.Empty
        strCmp_fcountry = String.Empty
        strStateCode = String.Empty
        strCmp_fctry = String.Empty
        strCmp_e_mail = String.Empty
        strCmp_web = String.Empty
        strCmp_fax = String.Empty
        strCmp_tel = String.Empty
        strCmp_note = String.Empty
        strCmp_acc_man = String.Empty
        strCmp_type = String.Empty
        strCmp_status = String.Empty
        strDevisionDebtorID = String.Empty
        strDevisionCreditorID = String.Empty
        strTextfield1 = String.Empty 'EQP,EQP PLUS
        strTextField11 = String.Empty
        strDefaultInvoiceForm = String.Empty
        strSalesPersonNumber = String.Empty

    End Sub
#End Region
#Region "-----------Private Function--------"
        Private Sub SaveLine(ByRef pdrRow As DataRow)
            Try
                With pdrRow
                .Item("ID") = intID
                .Item("Cmp_wwn") = strCmp_wwn
                .Item("Cmp_code") = strCmp_code
                .Item("Cnt_id") = strCnt_id
                .Item("Cmp_Parent") = strCmp_parent
                .Item("Cmp_name") = strCmp_name
                .Item("Cmp_fadd1") = strCmp_fadd1
                .Item("Cmp_fadd2") = strCmp_fadd2
                .Item("Cmp_fadd3") = strCmp_fadd3
                .Item("Cmp_fpc") = strCmp_fpc
                .Item("Cmp_fcity") = strCmp_fcity
                .Item("cmp_fcounty") = strCmp_fcountry
                .Item("StateCode") = strStateCode
                .Item("Cmp_fctry") = strCmp_fctry
                .Item("Cmp_e_mail") = strCmp_e_mail
                .Item("Cmp_web") = strCmp_web
                .Item("Cmp_fax") = strCmp_fax
                .Item("Cmp_tel") = strCmp_tel
                .Item("Cmp_note") = strCmp_note
                .Item("Cmp_acc_man") = strCmp_acc_man
                .Item("Cmp_type") = strCmp_type
                .Item("Cmp_status") = strCmp_status
                .Item("DivisionDebtorID") = strDevisionDebtorID
                .Item("DivisionCreditorID") = strDevisionCreditorID
                .Item("Textfield1") = strTextfield1
                .Item("TextField11") = strTextField11
                .Item("DefaultInvoiceForm") = strDefaultInvoiceForm
                .Item("SalesPersonNumber") = strSalesPersonNumber

            End With

            Catch ex As Exception
            MsgBox("Error in cCicmpy.SaveLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
        End Sub
    'Private Sub fr()

    '    ID
    '    Cmp_wwn
    '    Cmp_code
    '    Cnt_id
    '    Cmp_Parent
    '    Cmp_name
    '    Cmp_fadd1
    '    Cmp_fadd2
    '    Cmp_fadd3
    '    Cmp_fpc
    '    Cmp_fcity
    '    Cmp_fcountry
    '    Cmp_StateCode
    '    Cmp_fctry
    '    Cmp_e_mail
    '    Cmp_web
    '    Cmp_fax
    '    Cmp_tel
    '    Cmp_note
    '    Cmp_acc_man
    '    Cmp_type
    '    Cmp_status
    '    DevisionDebtorID
    '    DevisionCreditorID
    '    Textfield1
    '    TextField11
    'End Sub
    'Private Sub pro()

    '    intID
    '    strCmp_wwn
    '    strCmp_code
    '    strCnt_id
    '    strCmp_parent
    '    strCmp_name
    '    strCmp_fadd1
    '    strCmp_fadd2
    '    strCmp_fadd3
    '    strCmp_fpc
    '    strCmp_fcity
    '    strCmp_fcountry
    '    strStateCode
    '    strCmp_fctry
    '    strCmp_e_mail
    '    strCmp_web
    '    strCmp_fax
    '    strCmp_tel
    '    strCmp_note
    '    strCmp_acc_man
    '    strCmp_type
    '    strCmp_status
    '    strDevisionDebtorID
    '    strDevisionCreditorID
    '    strTextfield1
    '    strTextField11
    '    strDefaultInvoiceForm
    '    strSalesPersonNumber
    'End Sub
    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            With pdrRow
                If Not (.Item("ID").Equals(DBNull.Value)) Then intID = .Item("ID")
                If Not (.Item("Cmp_wwn").Equals(DBNull.Value)) Then strCmp_wwn = .Item("Cmp_wwn").ToString
                If Not (.Item("Cmp_code").Equals(DBNull.Value)) Then strCmp_code = .Item("Cmp_code").ToString
                If Not (.Item("Cnt_id").Equals(DBNull.Value)) Then strCnt_id = .Item("Cnt_id").ToString
                If Not (.Item("Cmp_Parent").Equals(DBNull.Value)) Then strCmp_parent = .Item("Cmp_Parent").ToString
                If Not (.Item("Cmp_name").Equals(DBNull.Value)) Then strCmp_name = .Item("Cmp_name").ToString
                If Not (.Item("Cmp_fadd1").Equals(DBNull.Value)) Then strCmp_fadd1 = .Item("Cmp_fadd1").ToString
                If Not (.Item("Cmp_fadd2").Equals(DBNull.Value)) Then strCmp_fadd2 = .Item("Cmp_fadd2").ToString
                If Not (.Item("Cmp_fadd3").Equals(DBNull.Value)) Then strCmp_fadd3 = .Item("Cmp_fadd3").ToString
                If Not (.Item("Cmp_fpc").Equals(DBNull.Value)) Then strCmp_fpc = .Item("Cmp_fpc").ToString
                If Not (.Item("Cmp_fcity").Equals(DBNull.Value)) Then strCmp_fcity = .Item("Cmp_fcity").ToString
                If Not (.Item("cmp_fcounty").Equals(DBNull.Value)) Then strCmp_fcountry = .Item("cmp_fcounty").ToString
                If Not (.Item("StateCode").Equals(DBNull.Value)) Then strStateCode = .Item("StateCode").ToString
                If Not (.Item("Cmp_fctry").Equals(DBNull.Value)) Then strCmp_fctry = .Item("Cmp_fctry").ToString
                If Not (.Item("Cmp_e_mail").Equals(DBNull.Value)) Then strCmp_e_mail = .Item("Cmp_e_mail").ToString
                If Not (.Item("Cmp_web").Equals(DBNull.Value)) Then strCmp_web = .Item("Cmp_web").ToString
                If Not (.Item("Cmp_fax").Equals(DBNull.Value)) Then strCmp_fax = .Item("Cmp_fax").ToString
                If Not (.Item("Cmp_tel").Equals(DBNull.Value)) Then strCmp_tel = .Item("Cmp_tel").ToString
                If Not (.Item("Cmp_note").Equals(DBNull.Value)) Then strCmp_note = .Item("Cmp_note").ToString
                If Not (.Item("Cmp_acc_man").Equals(DBNull.Value)) Then strCmp_acc_man = .Item("Cmp_acc_man").ToString
                If Not (.Item("Cmp_type").Equals(DBNull.Value)) Then strCmp_type = .Item("Cmp_type").ToString
                If Not (.Item("Cmp_status").Equals(DBNull.Value)) Then strCmp_status = .Item("Cmp_status").ToString
                If Not (.Item("DivisionDebtorID").Equals(DBNull.Value)) Then strDevisionDebtorID = .Item("DivisionDebtorID").ToString
                If Not (.Item("DivisionCreditorID").Equals(DBNull.Value)) Then strDevisionCreditorID = .Item("DivisionCreditorID").ToString
                If Not (.Item("Textfield1").Equals(DBNull.Value)) Then strTextfield1 = .Item("Textfield1").ToString
                If Not (.Item("TextField11").Equals(DBNull.Value)) Then strTextField11 = .Item("TextField11").ToString
                If Not (.Item("DefaultInvoiceForm").Equals(DBNull.Value)) Then strDefaultInvoiceForm = .Item("DefaultInvoiceForm").ToString
                If Not (.Item("SalesPersonNumber").Equals(DBNull.Value)) Then strSalesPersonNumber = .Item("SalesPersonNumber").ToString

            End With

        Catch ex As Exception
            MsgBox("Error in cCicmpy.LoadLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(pClass As cCicmpy, ByRef pdrRow As DataRow)
        Try
            With pdrRow
                If Not (.Item("ID").Equals(DBNull.Value)) Then pClass.intID = .Item("ID")
                If Not (.Item("Cmp_wwn").Equals(DBNull.Value)) Then pClass.strCmp_wwn = .Item("Cmp_wwn").ToString
                If Not (.Item("Cmp_code").Equals(DBNull.Value)) Then pClass.strCmp_code = .Item("Cmp_code").ToString
                If Not (.Item("Cnt_id").Equals(DBNull.Value)) Then pClass.strCnt_id = .Item("Cnt_id").ToString
                If Not (.Item("Cmp_Parent").Equals(DBNull.Value)) Then pClass.strCmp_parent = .Item("Cmp_Parent").ToString
                If Not (.Item("Cmp_name").Equals(DBNull.Value)) Then pClass.strCmp_name = .Item("Cmp_name").ToString
                If Not (.Item("Cmp_fadd1").Equals(DBNull.Value)) Then pClass.strCmp_fadd1 = .Item("Cmp_fadd1").ToString
                If Not (.Item("Cmp_fadd2").Equals(DBNull.Value)) Then pClass.strCmp_fadd2 = .Item("Cmp_fadd2").ToString
                If Not (.Item("Cmp_fadd3").Equals(DBNull.Value)) Then pClass.strCmp_fadd3 = .Item("Cmp_fadd3").ToString
                If Not (.Item("Cmp_fpc").Equals(DBNull.Value)) Then pClass.strCmp_fpc = .Item("Cmp_fpc").ToString
                If Not (.Item("Cmp_fcity").Equals(DBNull.Value)) Then pClass.strCmp_fcity = .Item("Cmp_fcity").ToString
                If Not (.Item("cmp_fcounty").Equals(DBNull.Value)) Then pClass.strCmp_fcountry = .Item("cmp_fcounty").ToString
                If Not (.Item("StateCode").Equals(DBNull.Value)) Then pClass.strStateCode = .Item("StateCode").ToString
                If Not (.Item("Cmp_fctry").Equals(DBNull.Value)) Then pClass.strCmp_fctry = .Item("Cmp_fctry").ToString
                If Not (.Item("Cmp_e_mail").Equals(DBNull.Value)) Then pClass.strCmp_e_mail = .Item("Cmp_e_mail").ToString
                If Not (.Item("Cmp_web").Equals(DBNull.Value)) Then pClass.strCmp_web = .Item("Cmp_web").ToString
                If Not (.Item("Cmp_fax").Equals(DBNull.Value)) Then pClass.strCmp_fax = .Item("Cmp_fax").ToString
                If Not (.Item("Cmp_tel").Equals(DBNull.Value)) Then pClass.strCmp_tel = .Item("Cmp_tel").ToString
                If Not (.Item("Cmp_note").Equals(DBNull.Value)) Then pClass.strCmp_note = .Item("Cmp_note").ToString
                If Not (.Item("Cmp_acc_man").Equals(DBNull.Value)) Then pClass.strCmp_acc_man = .Item("Cmp_acc_man").ToString
                If Not (.Item("Cmp_type").Equals(DBNull.Value)) Then pClass.strCmp_type = .Item("Cmp_type").ToString
                If Not (.Item("Cmp_status").Equals(DBNull.Value)) Then pClass.strCmp_status = .Item("Cmp_status").ToString
                If Not (.Item("DivisionDebtorID").Equals(DBNull.Value)) Then pClass.strDevisionDebtorID = .Item("DivisionDebtorID").ToString
                If Not (.Item("DivisionCreditorID").Equals(DBNull.Value)) Then pClass.strDevisionCreditorID = .Item("DivisionCreditorID").ToString
                If Not (.Item("Textfield1").Equals(DBNull.Value)) Then pClass.strTextfield1 = .Item("Textfield1").ToString
                If Not (.Item("TextField11").Equals(DBNull.Value)) Then pClass.strTextField11 = .Item("TextField11").ToString
                If Not (.Item("DefaultInvoiceForm").Equals(DBNull.Value)) Then pClass.strDefaultInvoiceForm = .Item("DefaultInvoiceForm").ToString
                If Not (.Item("SalesPersonNumber").Equals(DBNull.Value)) Then pClass.strSalesPersonNumber = .Item("SalesPersonNumber").ToString


            End With

        Catch ex As Exception
            MsgBox("Error in cCicmpy.LoadLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "-----------Pubic Function----------"

    Public Sub Load(ByVal pID As Int32)
        Try
            Dim db As New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql =
                " SELECT * FROM Cicmpy WITH (NOLOCK) " &
                " WHERE ID = " & pID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCicmpy.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Sub Load(ByVal p_strGuid As String)
        Try
            Dim db As New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql =
                " SELECT * FROM Cicmpy WITH (NOLOCK) " &
                " WHERE cmp_wwn = '" & p_strGuid & "'"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCicmpy.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function GetList_Cicmpy() As List(Of cCicmpy)

        GetList_Cicmpy = New List(Of cCicmpy)
        Try

            Dim oEnum = New cCicmpy
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCicmpy)
            Dim i As Integer
            Dim strSql As String

            strSql = " select * from cicmpy WITH (NOLOCK) order by id desc "

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                '    myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cCicmpy
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_Cicmpy = myList

        Catch ex As Exception
            MsgBox("Error in cCicmpy.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function GetList_Cicmpy(Optional ByVal pQuery As String = "") As List(Of cCicmpy)

        GetList_Cicmpy = New List(Of cCicmpy)
        Try

            Dim oEnum = New cCicmpy
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCicmpy)
            Dim i As Integer
            Dim strSql As String

            strSql = " select top 200 * from cicmpy WITH (NOLOCK) "
            '_
            '        & " where cmp_code like '%" & m_cmpcode & "%' "
            If pQuery <> "" Then
                strSql &= pQuery
            End If


            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                '      myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cCicmpy
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_Cicmpy = myList

        Catch ex As Exception
            MsgBox("Error in cCicmpy.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'Public Sub Save()
    '        Try
    '        Dim db As New cDBA
    '        Dim strSql As String
    '            Dim dt As DataTable
    '            Dim drRow As DataRow

    '        strSql =
    '            " SELECT * FROM Cicmpy WITH (NOLOCK) " &
    '            " WHERE ID = " & intID

    '        dt = db.DataTable(strSql)

    '        If dt.Rows.Count = 0 Then
    '            'execute Save
    '            drRow = dt.NewRow
    '        Else
    '            drRow = dt.Rows(0)
    '        End If

    '        Call SaveLine(drRow)

    '            If dt.Rows.Count = 0 Then
    '                db.DBDataTable.Rows.Add(drRow)
    '                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
    '                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand
    '            Else
    '                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
    '                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand
    '            End If

    '            db.DBDataAdapter.Update(db.DBDataTable)

    '        Catch ex As Exception
    '            MsgBox("Error in cCicmpy.Save() " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '        End Try
    '    End Sub
#End Region

#Region "--------------Public Property------------------"

    Public Property ID As Int32
        Get
            ID = intID
        End Get
        Set(ByVal value As Int32)
            intID = ID
        End Set
    End Property
    Public Property CMP_WWN As String
        Get
            CMP_WWN = strCmp_wwn
        End Get
        Set(ByVal value As String)
            strCmp_wwn = CMP_WWN
        End Set
    End Property
    Public Property CMP_CODE As String
        Get
            CMP_CODE = strCmp_code
        End Get
        Set(ByVal value As String)
            strCmp_code = CMP_CODE
        End Set
    End Property
    Public Property CNT_ID As String
        Get
            CNT_ID = strCnt_id
        End Get
        Set(ByVal value As String)
            strCnt_id = CNT_ID
        End Set
    End Property
    Public Property CMP_PARENT As String
        Get
            CMP_PARENT = strCmp_parent
        End Get
        Set(ByVal value As String)
            strCmp_parent = CMP_PARENT
        End Set
    End Property
    Public Property CMP_NAME As String
        Get
            CMP_NAME = strCmp_name
        End Get
        Set(ByVal value As String)
            strCmp_name = CMP_NAME
        End Set
    End Property
    Public Property CMP_FADD1 As String
        Get
            CMP_FADD1 = strCmp_fadd1
        End Get
        Set(ByVal value As String)
            strCmp_fadd1 = CMP_FADD1
        End Set
    End Property
    Public Property CMP_FADD2 As String
        Get
            CMP_FADD2 = strCmp_fadd2
        End Get
        Set(ByVal value As String)
            strCmp_fadd2 = CMP_FADD2
        End Set
    End Property
    Public Property CMP_FADD3 As String
        Get
            CMP_FADD3 = strCmp_fadd3
        End Get
        Set(ByVal value As String)
            strCmp_fadd3 = CMP_FADD3
        End Set
    End Property
    Public Property CMP_FPC As String
        Get
            CMP_FPC = strCmp_fpc
        End Get
        Set(ByVal value As String)
            strCmp_fpc = CMP_FPC
        End Set
    End Property
    Public Property CMP_FCITY As String
        Get
            CMP_FCITY = strCmp_fcity
        End Get
        Set(ByVal value As String)
            strCmp_fcity = CMP_FCITY
        End Set
    End Property
    Public Property CMP_FCOUNTY As String
        Get
            CMP_FCOUNTY = strCmp_fcountry
        End Get
        Set(ByVal value As String)
            strCmp_fcountry = CMP_FCOUNTY
        End Set
    End Property
    Public Property STATECODE As String
        Get
            STATECODE = strStateCode
        End Get
        Set(ByVal value As String)
            strStateCode = STATECODE
        End Set
    End Property
    Public Property CMP_FCTRY As String
        Get
            CMP_FCTRY = strCmp_fctry
        End Get
        Set(ByVal value As String)
            strCmp_fctry = CMP_FCTRY
        End Set
    End Property
    Public Property CMP_E_MAIL As String
        Get
            CMP_E_MAIL = strCmp_e_mail
        End Get
        Set(ByVal value As String)
            strCmp_e_mail = CMP_E_MAIL
        End Set
    End Property
    Public Property CMP_WEB As String
        Get
            CMP_WEB = strCmp_web
        End Get
        Set(ByVal value As String)
            strCmp_web = CMP_WEB
        End Set
    End Property
    Public Property CMP_FAX As String
        Get
            CMP_FAX = strCmp_fax
        End Get
        Set(ByVal value As String)
            strCmp_fax = CMP_FAX
        End Set
    End Property
    Public Property CMP_TEL As String
        Get
            CMP_TEL = strCmp_tel
        End Get
        Set(ByVal value As String)
            strCmp_tel = CMP_TEL
        End Set
    End Property
    Public Property CMP_NOTE As String
        Get
            CMP_NOTE = strCmp_note
        End Get
        Set(ByVal value As String)
            strCmp_note = CMP_NOTE
        End Set
    End Property
    Public Property CMP_ACC_MAN As String
        Get
            CMP_ACC_MAN = strCmp_acc_man
        End Get
        Set(ByVal value As String)
            strCmp_acc_man = CMP_ACC_MAN
        End Set
    End Property
    Public Property CMP_TYPE As String
        Get
            CMP_TYPE = strCmp_type
        End Get
        Set(ByVal value As String)
            strCmp_type = CMP_TYPE
        End Set
    End Property
    Public Property CMP_STATUS As String
        Get
            CMP_STATUS = strCmp_status
        End Get
        Set(ByVal value As String)
            strCmp_status = CMP_STATUS
        End Set
    End Property
    Public Property DIVISIONDEBTORID As String
        Get
            DIVISIONDEBTORID = strDevisionDebtorID
        End Get
        Set(ByVal value As String)
            strDevisionDebtorID = DIVISIONDEBTORID
        End Set
    End Property
    Public Property DIVISIONCREDITORID As String
        Get
            DIVISIONCREDITORID = strDevisionCreditorID
        End Get
        Set(ByVal value As String)
            strDevisionCreditorID = DIVISIONCREDITORID
        End Set
    End Property
    Public Property TEXTFIELD1 As String
        Get
            TEXTFIELD1 = strTextfield1
        End Get
        Set(ByVal value As String)
            strTextfield1 = TEXTFIELD1
        End Set
    End Property
    Public Property TEXTFIELD11 As String
        Get
            TEXTFIELD11 = strTextField11
        End Get
        Set(ByVal value As String)
            strTextField11 = TEXTFIELD11
        End Set
    End Property
    Public Property DEFAULTINVOICEFORM As String
        Get
            DEFAULTINVOICEFORM = strDefaultInvoiceForm
        End Get
        Set(ByVal value As String)
            strDefaultInvoiceForm = DEFAULTINVOICEFORM
        End Set
    End Property
    Public Property SALESPERSONNUMBER As String
        Get
            SALESPERSONNUMBER = strSalesPersonNumber
        End Get
        Set(ByVal value As String)
            strSalesPersonNumber = SALESPERSONNUMBER
        End Set
    End Property

#End Region




End Class
