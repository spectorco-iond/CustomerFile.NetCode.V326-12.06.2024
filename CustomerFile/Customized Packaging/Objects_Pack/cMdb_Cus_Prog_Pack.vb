

Public Class cMdb_Cus_Prog_Pack

#Region "private variables #################################################"

    Private m_intCus_Prog_Id As Int32 = 0
    Private m_strCus_No As String = ""
    Private m_strCus_Prog_Guid As String
    Private m_strSpector_Cd As String
    Private m_intProg_Type As Int32
    Private m_strProg_Cd As String
    Private m_strProg_Desc As String
    Private m_strImprint As String
    Private m_strProg_CSR As String
    Private m_intQuote_Type_ID As Integer
    Private m_intQuote_Ship_Method_ID As Integer
    Private m_intQuote_Step_ID As Integer
    Private m_strQuote_Step_User As String
    Private m_dtStart_Dt As Date ' DateTime
    Private m_dtEnd_Dt As Date ' DateTime
    Private m_blnNo_End_Date As Boolean
    Private m_intRenew_To_Cus_Prog_Id As Int32
    Private m_strApproved_By_Us As String
    Private m_strApproved_By_Them As String
    Private m_dtApproved_Dt As Date ' DateTime
    Private m_blnApproved As Boolean ' not in table
    Private m_intEqp_Level As Int32
    Private m_intEqp_Column As Int32
    Private m_decEqp_Pct As Decimal
    Private m_strProg_Comments As String
    Private m_intContact_ID As Integer
    Private m_blnOne_Shot As Boolean
    Private m_strOrd_No As String
    Private m_intCurrent_Rev_No As Int32 = 0
    Private m_blnAuto_Renew As Boolean
    Private m_dtRenew_Dt As DateTime
    Private m_dtRenew_End_Dt As DateTime
    Private m_blnRenew_Sent As Boolean
    Private m_blnFor_All_Accounts As Boolean
    Private m_strUser_Login As String
    Private m_dtCreate_TS As Date
    Private m_strCreate_By As String
    Private m_dtUpdate_TS As Date ' DateTime


    '++ID 16.03.2015
    Private m_strQuote_Status As String
    Private m_strQuote_Result As String
    Private m_dtDecisioin_Dt As Date
    '----------------------------------
#End Region

    Public Sub New()
        Try
            Call Init()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub New(ByVal cus_prog_id As Integer)
        Try

            m_intCus_Prog_Id = cus_prog_id
            Call Load()

        Catch ex As Exception

        End Try
    End Sub

#Region "#################################"
    Private Sub Init()

        m_intCus_Prog_Id = 0
        m_strCus_No = String.Empty
        m_strCus_Prog_Guid = String.Empty
        m_strSpector_Cd = String.Empty
        m_intProg_Type = 0
        m_strProg_Cd = String.Empty
        m_strProg_Desc = String.Empty
        m_strImprint = String.Empty
        m_strProg_CSR = String.Empty
        m_intQuote_Type_ID = 0
        m_intQuote_Ship_Method_ID = 0
        m_intQuote_Step_ID = 0
        m_strQuote_Step_User = String.Empty
        m_dtStart_Dt = NoDate() ' DateTime
        m_dtEnd_Dt = NoDate() ' DateTime
        m_blnNo_End_Date = False
        m_intRenew_To_Cus_Prog_Id = 0
        m_strApproved_By_Us = String.Empty
        m_strApproved_By_Them = String.Empty
        m_dtApproved_Dt = NoDate() ' DateTime
        m_blnApproved = False  ' not in table
        m_intEqp_Level = 0
        m_intEqp_Column = 0
        m_decEqp_Pct = 0.0
        m_strProg_Comments = String.Empty
        m_intContact_ID = 0
        m_blnOne_Shot = False
        m_strOrd_No = String.Empty
        m_intCurrent_Rev_No = 0
        m_blnAuto_Renew = False
        m_dtRenew_Dt = NoDate()
        m_dtRenew_End_Dt = NoDate()
        m_blnRenew_Sent = False
        m_blnFor_All_Accounts = False
        m_strUser_Login = String.Empty
        m_dtCreate_TS = NoDate()
        m_strCreate_By = String.Empty
        m_dtUpdate_TS = NoDate() ' DateTime


        '++ID 16.03.2015
        m_strQuote_Status = String.Empty
        m_strQuote_Result = String.Empty
        m_dtDecisioin_Dt = NoDate()
    End Sub
    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then m_intCus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Cus_Prog_Guid").Equals(DBNull.Value)) Then m_strCus_Prog_Guid = pdrRow.Item("Cus_Prog_Guid").ToString
            If Not (pdrRow.Item("Spector_Cd").Equals(DBNull.Value)) Then m_strSpector_Cd = pdrRow.Item("Spector_Cd").ToString
            If Not (pdrRow.Item("Prog_Cd").Equals(DBNull.Value)) Then m_strProg_Cd = pdrRow.Item("Prog_Cd").ToString
            'If Not (pdrRow.Item("Prog_Desc").Equals(DBNull.Value)) Then .Prog_Desc = pdrRow.Item("Prog_Desc").ToString
            If Not (pdrRow.Item("Imprint").Equals(DBNull.Value)) Then m_strImprint = pdrRow.Item("Imprint").ToString
            If Not (pdrRow.Item("Prog_CSR").Equals(DBNull.Value)) Then m_strProg_CSR = pdrRow.Item("Prog_CSR").ToString
            If Not (pdrRow.Item("Prog_Type").Equals(DBNull.Value)) Then m_intProg_Type = pdrRow.Item("Prog_Type")
            If Not (pdrRow.Item("Quote_Type_ID").Equals(DBNull.Value)) Then m_intQuote_Type_ID = pdrRow.Item("Quote_Type_ID").ToString
            If Not (pdrRow.Item("Quote_Ship_Method_ID").Equals(DBNull.Value)) Then m_intQuote_Ship_Method_ID = pdrRow.Item("Quote_Ship_Method_ID").ToString
            If Not (pdrRow.Item("Quote_Step_ID").Equals(DBNull.Value)) Then m_intQuote_Step_ID = pdrRow.Item("Quote_Step_ID")
            If Not (pdrRow.Item("Quote_Step_User").Equals(DBNull.Value)) Then m_strQuote_Step_User = pdrRow.Item("Quote_Step_User").ToString
            If Not (pdrRow.Item("Start_Dt").Equals(DBNull.Value)) Then m_dtStart_Dt = pdrRow.Item("Start_Dt")
            If Not (pdrRow.Item("End_Dt").Equals(DBNull.Value)) Then m_dtEnd_Dt = pdrRow.Item("End_Dt")
            If Not (pdrRow.Item("No_End_Date").Equals(DBNull.Value)) Then m_blnNo_End_Date = pdrRow.Item("No_End_Date")
            If Not (pdrRow.Item("Renew_To_Cus_Prog_Id").Equals(DBNull.Value)) Then m_intRenew_To_Cus_Prog_Id = pdrRow.Item("Renew_To_Cus_Prog_Id")
            If Not (pdrRow.Item("Approved_By_Us").Equals(DBNull.Value)) Then m_strApproved_By_Us = pdrRow.Item("Approved_By_Us").ToString
            If Not (pdrRow.Item("Approved_By_Them").Equals(DBNull.Value)) Then m_strApproved_By_Them = pdrRow.Item("Approved_By_Them").ToString
            If Not (pdrRow.Item("Approved_Dt").Equals(DBNull.Value)) Then m_dtApproved_Dt = pdrRow.Item("Approved_Dt")
            If Not (pdrRow.Item("Eqp_Level").Equals(DBNull.Value)) Then m_intEqp_Level = pdrRow.Item("Eqp_Level")
            If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then m_intEqp_Column = pdrRow.Item("Eqp_Column")
            If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then m_decEqp_Pct = pdrRow.Item("Eqp_Pct")
            If Not (pdrRow.Item("Prog_Comments").Equals(DBNull.Value)) Then m_strProg_Comments = pdrRow.Item("Prog_Comments").ToString
            If Not (pdrRow.Item("Contact_ID").Equals(DBNull.Value)) Then m_intContact_ID = pdrRow.Item("Contact_ID")
            If Not (pdrRow.Item("One_Shot").Equals(DBNull.Value)) Then m_blnOne_Shot = pdrRow.Item("One_Shot")
            If Not (pdrRow.Item("Current_Rev_No").Equals(DBNull.Value)) Then m_intCurrent_Rev_No = pdrRow.Item("Current_Rev_No")
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("Auto_Renew").Equals(DBNull.Value)) Then m_blnAuto_Renew = pdrRow.Item("Auto_Renew")
            If Not (pdrRow.Item("Renew_Dt").Equals(DBNull.Value)) Then m_dtRenew_Dt = pdrRow.Item("Renew_Dt")
            If Not (pdrRow.Item("Renew_End_Dt").Equals(DBNull.Value)) Then m_dtRenew_End_Dt = pdrRow.Item("Renew_End_Dt")
            If Not (pdrRow.Item("Renew_Sent").Equals(DBNull.Value)) Then m_blnRenew_Sent = pdrRow.Item("Renew_Sent")
            If Not (pdrRow.Item("For_All_Accounts").Equals(DBNull.Value)) Then m_blnFor_All_Accounts = pdrRow.Item("For_All_Accounts")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_TS = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Create_By").Equals(DBNull.Value)) Then m_strCreate_By = pdrRow.Item("Create_By").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_TS = pdrRow.Item("Update_Ts")
            '++ID 16.03.2015
            If Not (pdrRow.Item("QUOTE_STATUS").Equals(DBNull.Value)) Then m_strQuote_Status = pdrRow.Item("QUOTE_STATUS").ToString
            If Not (pdrRow.Item("QUOTE_RESULT").Equals(DBNull.Value)) Then m_strQuote_Result = pdrRow.Item("QUOTE_RESULT").ToString
            If Not (pdrRow.Item("DECISION_DT").Equals(DBNull.Value)) Then m_dtDecisioin_Dt = pdrRow.Item("DECISION_DT")


        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Public Sub Load()

        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog WITH (Nolock) " & _
            "WHERE  Cus_Prog_Id = " & m_intCus_Prog_Id

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region



#Region "Public properties ################################################"

    Public Property Cus_Prog_Id() As Int32
        Get
            Cus_Prog_Id = m_intCus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Id = value
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

    Public Property Cus_Prog_Guid() As String
        Get
            Cus_Prog_Guid = m_strCus_Prog_Guid
        End Get
        Set(ByVal value As String)
            m_strCus_Prog_Guid = value
        End Set
    End Property

    'Public Property Prog_Desc() As String
    '    Get
    '        Prog_Desc = m_strProg_Desc
    '    End Get
    '    Set(ByVal value As String)
    '        m_strProg_Desc = value
    '    End Set
    'End Property

    Public Property Prog_Cd() As String
        Get
            Prog_Cd = m_strProg_Cd
        End Get
        Set(ByVal value As String)
            m_strProg_Cd = value
        End Set
    End Property

    Public Property Spector_Cd() As String
        Get
            Spector_Cd = m_strSpector_Cd
        End Get
        Set(ByVal value As String)
            m_strSpector_Cd = value
        End Set
    End Property

    Public Property Imprint() As String
        Get
            Imprint = m_strImprint
        End Get
        Set(ByVal value As String)
            m_strImprint = value
        End Set
    End Property

    Public Property Prog_CSR() As String
        Get
            Prog_CSR = m_strProg_CSR
        End Get
        Set(ByVal value As String)
            m_strProg_CSR = value
        End Set
    End Property

    Public Property Prog_Type() As Int32
        Get
            Prog_Type = m_intProg_Type
        End Get
        Set(ByVal value As Int32)
            m_intProg_Type = value
        End Set
    End Property

    Public Property Start_Dt() As Date ' DateTime
        Get
            Start_Dt = m_dtStart_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtStart_Dt = value
        End Set
    End Property

    Public Property End_Dt() As Date ' DateTime
        Get
            End_Dt = m_dtEnd_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtEnd_Dt = value
        End Set
    End Property

    Public Property No_End_Date() As Boolean
        Get
            No_End_Date = m_blnNo_End_Date
        End Get
        Set(ByVal value As Boolean)
            m_blnNo_End_Date = value
        End Set
    End Property

    Public Property Renew_To_Cus_Prog_Id() As Int32
        Get
            Renew_To_Cus_Prog_Id = m_intRenew_To_Cus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            m_intRenew_To_Cus_Prog_Id = value
        End Set
    End Property

    Public Property Approved_By_Us() As String
        Get
            Approved_By_Us = m_strApproved_By_Us
        End Get
        Set(ByVal value As String)
            m_strApproved_By_Us = value
        End Set
    End Property

    Public Property Approved_By_Them() As String
        Get
            Approved_By_Them = m_strApproved_By_Them
        End Get
        Set(ByVal value As String)
            m_strApproved_By_Them = value
        End Set
    End Property

    Public Property Approved_Dt() As Date ' DateTime
        Get
            Approved_Dt = m_dtApproved_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtApproved_Dt = value
        End Set
    End Property

    Public Property Eqp_Level() As Int32
        Get
            Eqp_Level = m_intEqp_Level
        End Get
        Set(ByVal value As Int32)
            m_intEqp_Level = value
        End Set
    End Property

    Public Property Eqp_Column() As Int32
        Get
            Eqp_Column = m_intEqp_Column
        End Get
        Set(ByVal value As Int32)
            m_intEqp_Column = value
        End Set
    End Property

    Public Property Eqp_Pct() As Decimal
        Get
            Eqp_Pct = m_decEqp_Pct
        End Get
        Set(ByVal value As Decimal)
            m_decEqp_Pct = value
        End Set
    End Property

    Public Property Prog_Comments() As String
        Get
            Prog_Comments = m_strProg_Comments
        End Get
        Set(ByVal value As String)
            m_strProg_Comments = value
        End Set
    End Property

    Public Property One_Shot() As Boolean
        Get
            One_Shot = m_blnOne_Shot
        End Get
        Set(ByVal value As Boolean)
            m_blnOne_Shot = value
        End Set
    End Property

    Public Property Current_Rev_No() As Int32
        Get
            Current_Rev_No = m_intCurrent_Rev_No
        End Get
        Set(ByVal value As Int32)
            m_intCurrent_Rev_No = value
        End Set
    End Property

    Public Property Auto_Renew() As Boolean
        Get
            Auto_Renew = m_blnAuto_Renew
        End Get
        Set(ByVal value As Boolean)
            m_blnAuto_Renew = value
        End Set
    End Property

    Public Property Renew_Dt() As Date ' DateTime
        Get
            Renew_Dt = m_dtRenew_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtRenew_Dt = value
        End Set
    End Property

    Public Property Renew_End_Dt() As Date ' DateTime
        Get
            Renew_End_Dt = m_dtRenew_End_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtRenew_End_Dt = value
        End Set
    End Property

    Public Property Renew_Sent() As Boolean
        Get
            Renew_Sent = m_blnRenew_Sent
        End Get
        Set(ByVal value As Boolean)
            m_blnRenew_Sent = value
        End Set
    End Property

    Public Property User_Login() As String
        Get
            User_Login = m_strUser_Login
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
        End Set
    End Property

    Public Property Create_By() As String
        Get
            Create_By = m_strCreate_By
        End Get
        Set(ByVal value As String)
            m_strCreate_By = value
        End Set
    End Property

    Public Property Create_TS() As Date ' DateTime
        Get
            Create_TS = m_dtCreate_TS
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtCreate_TS = value
        End Set
    End Property

    Public Property Update_TS() As Date ' DateTime
        Get
            Update_TS = m_dtUpdate_TS
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtUpdate_TS = value
        End Set
    End Property

    Public ReadOnly Property Approved() As Boolean
        Get
            Approved = Not (IsNothing(m_dtApproved_Dt))
        End Get
    End Property

    'Public ReadOnly Property Renew_To_Cus_Prog_Cd() As String
    '    Get
    '        Renew_To_Cus_Prog_Cd = ""

    '        Dim oDAL As New cMdb_Cus_Prog_DAL()
    '        Renew_To_Cus_Prog_Cd = oDAL.GetItem(m_intRenew_To_Cus_Prog_Id).Prog_Cd

    '    End Get
    'End Property

    Public Property Quote_Type_ID() As Integer
        Get
            Quote_Type_ID = m_intQuote_Type_ID
        End Get
        Set(ByVal value As Integer)
            m_intQuote_Type_ID = value
        End Set
    End Property

    Public Property Quote_Ship_Method_ID() As Integer
        Get
            Quote_Ship_Method_ID = m_intQuote_Ship_Method_ID
        End Get
        Set(ByVal value As Integer)
            m_intQuote_Ship_Method_ID = value
        End Set
    End Property

    Public Property Quote_Step_ID() As Integer
        Get
            Quote_Step_ID = m_intQuote_Step_ID
        End Get
        Set(ByVal value As Integer)
            m_intQuote_Step_ID = value
        End Set
    End Property

    Public Property Quote_Step_User() As String
        Get
            Quote_Step_User = m_strQuote_Step_User
        End Get
        Set(ByVal value As String)
            m_strQuote_Step_User = value
        End Set
    End Property

    Public Property Contact_ID() As Integer
        Get
            Contact_ID = m_intContact_ID
        End Get
        Set(ByVal value As Integer)
            m_intContact_ID = value
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



    Public Property For_All_Accounts() As Boolean
        Get
            For_All_Accounts = m_blnFor_All_Accounts
        End Get
        Set(ByVal value As Boolean)
            m_blnFor_All_Accounts = value
        End Set
    End Property
    '++ID 16.03.2015
    Public Property Quote_Status As String
        Get
            Quote_Status = m_strQuote_Status
        End Get
        Set(ByVal value As String)
            m_strQuote_Status = value
        End Set
    End Property
    Public Property Quote_Result As String
        Get
            Quote_Result = m_strQuote_Result
        End Get
        Set(ByVal value As String)
            m_strQuote_Result = value
        End Set
    End Property
    Public Property Decision_Dt As DateTime
        Get
            Decision_Dt = m_dtDecisioin_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtDecisioin_Dt = value
        End Set
    End Property
    '--------------------------------------



#End Region



End Class
