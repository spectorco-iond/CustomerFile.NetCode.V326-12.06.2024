Public Class cMDB_CUS_PROG_ITEM_PRICE


#Region "private variables #################################################"


    Private m_intCus_Prog_Item_Price_Id As Int32
    Private m_strCus_Prog_Item_List_Guid As String
    Private m_intEqp_Level As Int32
    Private m_intEqp_Column As Int32
    Private m_decEqp_Pct As Decimal
    Private m_decUnit_Price As Decimal
    Private m_decMin_Qty_Ord As Decimal
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime

#End Region


#Region "Constructors #####################################################"

    Public Sub New()

        'm_strCus_Prog_Item_List_Guid = Guid.NewGuid.ToString

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Item_Price_Id() As Int32
        Get
            Cus_Prog_Item_Price_Id = m_intCus_Prog_Item_Price_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Item_Price_Id = value
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

    Public Property Unit_Price() As Decimal
        Get
            Unit_Price = m_decUnit_Price
        End Get
        Set(ByVal value As Decimal)
            m_decUnit_Price = value
        End Set
    End Property

    Public Property Min_Qty_Ord() As Decimal
        Get
            Min_Qty_Ord = m_decMin_Qty_Ord
        End Get
        Set(ByVal value As Decimal)
            m_decMin_Qty_Ord = value
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
