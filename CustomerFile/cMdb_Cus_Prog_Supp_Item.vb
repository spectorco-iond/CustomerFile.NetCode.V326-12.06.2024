Public Class cMdb_Cus_Prog_Supp_Item


#Region "private variables #################################################" 


    private m_intCus_Prog_Supp_Item_Id As Int32
    private m_intCus_Prog_Item_List_Id As Int32
    private m_strItem_No As String
    private m_intItem_Type As Int32
    private m_blnPrice_Included As Boolean
    private m_decUnit_Price As Decimal
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public properties ################################################" 

    Public Property Cus_Prog_Supp_Item_Id() As Int32
        Get
            Cus_Prog_Supp_Item_Id = m_intCus_Prog_Supp_Item_Id 
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Supp_Item_Id = value
        End Set
    End Property

    Public Property Cus_Prog_Item_List_Id() As Int32
        Get
            Cus_Prog_Item_List_Id = m_intCus_Prog_Item_List_Id 
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Item_List_Id = value
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

    Public Property Item_Type() As Int32
        Get
            Item_Type = m_intItem_Type 
        End Get
        Set(ByVal value As Int32)
            m_intItem_Type = value
        End Set
    End Property

    Public Property Price_Included() As Boolean
        Get
            Price_Included = m_blnPrice_Included 
        End Get
        Set(ByVal value As Boolean)
            m_blnPrice_Included = value
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

    Public Property User_Login() As String
        Get
            User_Login = m_strUser_Login 
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
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


End Class ' cMdb_Cus_Prog_Supp_Item


