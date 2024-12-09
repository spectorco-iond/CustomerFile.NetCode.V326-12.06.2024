Public Class cMDB_CUS_PROG_ITEM_COLOR


#Region "private variables #################################################"


    Private m_intCus_Prog_Item_Color_Id As Int32
    Private m_strCus_Prog_Item_List_Guid As String
    Private m_strItem_No As String
    Private m_blnSelected As Boolean
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime

#End Region


#Region "Constructors #####################################################"

    Public Sub New()

        ' m_strCus_Prog_Item_List_Guid = Guid.NewGuid.ToString

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Item_Color_Id() As Int32
        Get
            Cus_Prog_Item_Color_Id = m_intCus_Prog_Item_Color_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Item_Color_Id = value
        End Set
    End Property

    Public Property Cus_Prog_Item_List_Guid() As String
        Get
            Cus_Prog_Item_List_Guid = m_strCus_Prog_Item_List_Guid
        End Get
        Set(ByVal value As String)
            m_strCus_Prog_Item_List_Guid = value
        End Set
    End Property

    Public Property Item_No() As String
        Get
            Item_No = m_strItem_No
        End Get
        Set(ByVal value As String)
            m_strItem_No = value
        End Set
    End Property

    Public Property Selected() As Boolean
        Get
            Selected = m_blnSelected
        End Get
        Set(ByVal value As Boolean)
            m_blnSelected = value
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

#End Region


End Class
