Public Class cMdb_Cus_Prog_Rev


#Region "private variables #################################################"

    Private m_intCus_Prog_Rev_Id As Int32 = 0
    Private m_intCus_Prog_ID As Int32
    Private m_intRev_No As Int32
    Private m_strRev_State As String
    Private m_strProgram As String
    Private m_strImprint As String
    Private m_strProg_CSR As String
    Private m_dtStart_Dt As DateTime
    Private m_dtEnd_Dt As DateTime
    Private m_intCicntp_Id As Int32
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime
    Private m_EmailId As Int32

#End Region


#Region "Constructors #####################################################"

    Public Sub New()

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Rev_ID() As Int32
        Get
            Cus_Prog_Rev_ID = m_intCus_Prog_Rev_ID
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Rev_ID = value
        End Set
    End Property

    Public Property Cus_Prog_Id() As Int32
        Get
            Cus_Prog_Id = m_intCus_Prog_ID
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_ID = value
        End Set
    End Property

    Public Property Rev_No() As Integer
        Get
            Rev_No = m_intRev_No
        End Get
        Set(ByVal value As Int32)
            m_intRev_No = value
        End Set
    End Property

    Public Property Rev_State() As String
        Get
            Rev_State = m_strRev_State
        End Get
        Set(ByVal value As String)
            m_strRev_State = value
        End Set
    End Property

    Public Property Program() As String
        Get
            Program = m_strProgram
        End Get
        Set(ByVal value As String)
            m_strProgram = value
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

    Public Property Start_Dt() As DateTime
        Get
            Start_Dt = m_dtStart_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtStart_Dt = value
        End Set
    End Property

    Public Property End_Dt() As DateTime
        Get
            End_Dt = m_dtEnd_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtEnd_Dt = value
        End Set
    End Property

    Public Property Cicntp_ID() As Int32
        Get
            Cicntp_ID = m_intCicntp_Id
        End Get
        Set(ByVal value As Int32)
            m_intCicntp_Id = value
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

    Public Property Create_Ts() As DateTime
        Get
            Create_Ts = m_dtCreate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtCreate_Ts = value
        End Set
    End Property

    Public Property Update_Ts() As DateTime
        Get
            Update_Ts = m_dtUpdate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_Ts = value
        End Set
    End Property
    '++ID 23.03.2015
    Public Property EmailId As Int32
        Get
            EmailId = m_EmailId
        End Get
        Set(ByVal value As Int32)
            m_EmailId = value
        End Set
    End Property
#End Region


End Class
