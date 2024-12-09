Public Class cMdb_Cus_Prog


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
    Private m_dtRenew_Dt As Date
    Private m_dtRenew_End_Dt As Date
    Private m_blnRenew_Sent As Boolean
    Private m_blnFor_All_Accounts As Boolean
    Private m_strUser_Login As String
    Private m_dtCreate_TS As Date
    Private m_strCreate_By As String
    Private m_dtUpdate_TS As Date ' DateTime
    Private m_oRevision As cMdb_Cus_Prog_Rev

    '++ID 16.03.2015
    Private m_strQuote_Status As String
    Private m_strQuote_Result As String
    Private m_dtDecisioin_Dt As Date

    '++ID 7.28.2018
    Private m_strNote As String
    '----------------------------------
#End Region


#Region "Public CONSTRUCTORS ###############################################"

    Public Sub New()

        m_strCus_Prog_Guid = Guid.NewGuid.ToString
        m_oRevision = New cMdb_Cus_Prog_Rev

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Id As Int32
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

    Public Property Cus_Prog_Guid As String
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

    Public Property Prog_Cd As String
        Get
            Prog_Cd = m_strProg_Cd
        End Get
        Set(ByVal value As String)
            m_strProg_Cd = value
        End Set
    End Property

    Public Property Spector_Cd As String
        Get
            Spector_Cd = m_strSpector_Cd
        End Get
        Set(ByVal value As String)
            m_strSpector_Cd = value
        End Set
    End Property

    Public Property Imprint As String
        Get
            Imprint = m_strImprint
        End Get
        Set(ByVal value As String)
            m_strImprint = value
        End Set
    End Property

    Public Property Prog_CSR As String
        Get
            Prog_CSR = m_strProg_CSR
        End Get
        Set(ByVal value As String)
            m_strProg_CSR = value
        End Set
    End Property

    Public Property Prog_Type As Int32
        Get
            Prog_Type = m_intProg_Type
        End Get
        Set(ByVal value As Int32)
            m_intProg_Type = value
        End Set
    End Property

    Public Property Start_Dt As Date ' DateTime
        Get
            Start_Dt = m_dtStart_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtStart_Dt = value
        End Set
    End Property

    Public Property End_Dt As Date ' DateTime
        Get
            End_Dt = m_dtEnd_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtEnd_Dt = value
        End Set
    End Property

    Public Property No_End_Date As Boolean
        Get
            No_End_Date = m_blnNo_End_Date
        End Get
        Set(ByVal value As Boolean)
            m_blnNo_End_Date = value
        End Set
    End Property

    Public Property Renew_To_Cus_Prog_Id As Int32
        Get
            Renew_To_Cus_Prog_Id = m_intRenew_To_Cus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            m_intRenew_To_Cus_Prog_Id = value
        End Set
    End Property

    Public Property Approved_By_Us As String
        Get
            Approved_By_Us = m_strApproved_By_Us
        End Get
        Set(ByVal value As String)
            m_strApproved_By_Us = value
        End Set
    End Property

    Public Property Approved_By_Them As String
        Get
            Approved_By_Them = m_strApproved_By_Them
        End Get
        Set(ByVal value As String)
            m_strApproved_By_Them = value
        End Set
    End Property

    Public Property Approved_Dt As Date ' DateTime
        Get
            Approved_Dt = m_dtApproved_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtApproved_Dt = value
        End Set
    End Property

    Public Property Eqp_Level As Int32
        Get
            Eqp_Level = m_intEqp_Level
        End Get
        Set(ByVal value As Int32)
            m_intEqp_Level = value
        End Set
    End Property

    Public Property Eqp_Column As Int32
        Get
            Eqp_Column = m_intEqp_Column
        End Get
        Set(ByVal value As Int32)
            m_intEqp_Column = value
        End Set
    End Property

    Public Property Eqp_Pct As Decimal
        Get
            Eqp_Pct = m_decEqp_Pct
        End Get
        Set(ByVal value As Decimal)
            m_decEqp_Pct = value
        End Set
    End Property

    Public Property Prog_Comments As String
        Get
            Prog_Comments = m_strProg_Comments
        End Get
        Set(ByVal value As String)
            m_strProg_Comments = value
        End Set
    End Property

    Public Property One_Shot As Boolean
        Get
            One_Shot = m_blnOne_Shot
        End Get
        Set(ByVal value As Boolean)
            m_blnOne_Shot = value
        End Set
    End Property

    Public Property Current_Rev_No As Int32
        Get
            Current_Rev_No = m_intCurrent_Rev_No
        End Get
        Set(ByVal value As Int32)
            m_intCurrent_Rev_No = value
        End Set
    End Property

    Public Property Auto_Renew As Boolean
        Get
            Auto_Renew = m_blnAuto_Renew
        End Get
        Set(ByVal value As Boolean)
            m_blnAuto_Renew = value
        End Set
    End Property

    Public Property Renew_Dt As Date ' DateTime
        Get
            Renew_Dt = m_dtRenew_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtRenew_Dt = value
        End Set
    End Property

    Public Property Renew_End_Dt As Date ' DateTime
        Get
            Renew_End_Dt = m_dtRenew_End_Dt
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtRenew_End_Dt = value
        End Set
    End Property

    Public Property Renew_Sent As Boolean
        Get
            Renew_Sent = m_blnRenew_Sent
        End Get
        Set(ByVal value As Boolean)
            m_blnRenew_Sent = value
        End Set
    End Property

    Public Property User_Login As String
        Get
            User_Login = m_strUser_Login
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
        End Set
    End Property

    Public Property Create_By As String
        Get
            Create_By = m_strCreate_By
        End Get
        Set(ByVal value As String)
            m_strCreate_By = value
        End Set
    End Property

    Public Property Create_TS As Date ' DateTime
        Get
            Create_TS = m_dtCreate_TS
        End Get
        Set(ByVal value As Date) ' DateTime)
            m_dtCreate_TS = value
        End Set
    End Property

    Public Property Update_TS As Date ' DateTime
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

    Public Property Quote_Type_ID As Integer
        Get
            Quote_Type_ID = m_intQuote_Type_ID
        End Get
        Set(ByVal value As Integer)
            m_intQuote_Type_ID = value
        End Set
    End Property

    Public Property Quote_Ship_Method_ID As Integer
        Get
            Quote_Ship_Method_ID = m_intQuote_Ship_Method_ID
        End Get
        Set(ByVal value As Integer)
            m_intQuote_Ship_Method_ID = value
        End Set
    End Property

    Public Property Quote_Step_ID As Integer
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

    Public Property Ord_No As String
        Get
            Ord_No = m_strOrd_No
        End Get
        Set(ByVal value As String)
            m_strOrd_No = value
        End Set
    End Property

    Public Property Revision() As cMdb_Cus_Prog_Rev
        Get
            Revision = m_oRevision
        End Get
        Set(ByVal value As cMdb_Cus_Prog_Rev)
            m_oRevision = value
        End Set
    End Property

    Public Property For_All_Accounts As Boolean
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
    Public Property Decision_Dt As Date
        Get
            Decision_Dt = m_dtDecisioin_Dt
        End Get
        Set(ByVal value As Date)
            m_dtDecisioin_Dt = value
        End Set
    End Property
    '--------------------------------------

    Public Property Note As String
        Get
            Return m_strNote
        End Get
        Set(value As String)
            m_strNote = value
        End Set
    End Property

#End Region


End Class ' cMdb_Cus_Prog

