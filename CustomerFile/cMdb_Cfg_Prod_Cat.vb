Public Class cMdb_Cfg_Prod_Cat


#Region "private variables #################################################"

    Private m_intProd_Cat_ID As Int32
    Private m_strProd_Cat_Code As String
    Private m_strProd_Cat_Desc As String
    Private m_intProd_Cat_Order As Int32
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime
    Private m_dtCreate_Ts As DateTime

#End Region


#Region "Public properties ################################################"

    Public Property Prod_Cat_ID() As Int32
        Get
            Prod_Cat_ID = m_intProd_Cat_ID
        End Get
        Set(ByVal value As Int32)
            m_intProd_Cat_ID = value
        End Set
    End Property

    Public Property Prod_Cat_Code() As String
        Get
            Prod_Cat_Code = m_strProd_Cat_Code
        End Get
        Set(ByVal value As String)
            m_strProd_Cat_Code = value
        End Set
    End Property

    Public Property Prod_Cat_Desc() As String
        Get
            Prod_Cat_Desc = m_strProd_Cat_Desc
        End Get
        Set(ByVal value As String)
            m_strProd_Cat_Desc = value
        End Set
    End Property

    Public Property Prod_Cat_Order() As Int32
        Get
            Prod_Cat_Order = m_intProd_Cat_Order
        End Get
        Set(ByVal value As Int32)
            m_intProd_Cat_Order = value
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
