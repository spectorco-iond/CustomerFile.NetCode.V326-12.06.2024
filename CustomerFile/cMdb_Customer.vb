Public Class cMdb_Customer


#Region "private variables #################################################" 


    private m_intCus_Id As Int32
    private m_strCus_No As String
    private m_intCus_Dec_Count As Int32
    private m_strEdi_Cus_Name As String
    private m_intPick_Sensitivity As Int32
    private m_intStar_Level As Int32
    private m_blnEqp_Status As Boolean
    private m_intEqp_Column As Int32
    private m_decEqp_Pct As Decimal
    private m_blnEqp_Trial As Boolean
    private m_strGroup_Member As String
    Private m_blnAll_Star_Traveler As Boolean
    Private m_dtWhite_Glove_End_Date As DateTime
    Private m_intWhite_Glove_Order_Count As Integer
    private m_blnCoop_Pricing As Boolean
    private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime
    Private m_CountRMA_3Month As Integer

#End Region


#Region "Public properties ################################################" 

    Public Property Cus_Id() As Int32
        Get
            Cus_Id = m_intCus_Id 
        End Get
        Set(ByVal value As Int32)
            m_intCus_Id = value
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

    Public Property Cus_Dec_Count() As Int32
        Get
            Cus_Dec_Count = m_intCus_Dec_Count 
        End Get
        Set(ByVal value As Int32)
            m_intCus_Dec_Count = value
        End Set
    End Property

    Public Property Edi_Cus_Name() As String
        Get
            Edi_Cus_Name = m_strEdi_Cus_Name 
        End Get
        Set(ByVal value As String)
            m_strEdi_Cus_Name = value
        End Set
    End Property

    Public Property Pick_Sensitivity() As Int32
        Get
            Pick_Sensitivity = m_intPick_Sensitivity 
        End Get
        Set(ByVal value As Int32)
            m_intPick_Sensitivity = value
        End Set
    End Property

    Public Property Star_Level() As Int32
        Get
            Star_Level = m_intStar_Level 
        End Get
        Set(ByVal value As Int32)
            m_intStar_Level = value
        End Set
    End Property

    Public Property Eqp_Status() As Boolean
        Get
            Eqp_Status = m_blnEqp_Status 
        End Get
        Set(ByVal value As Boolean)
            m_blnEqp_Status = value
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

    Public Property Eqp_Trial() As Boolean
        Get
            Eqp_Trial = m_blnEqp_Trial 
        End Get
        Set(ByVal value As Boolean)
            m_blnEqp_Trial = value
        End Set
    End Property

    Public Property Group_Member() As String
        Get
            Group_Member = m_strGroup_Member 
        End Get
        Set(ByVal value As String)
            m_strGroup_Member = value
        End Set
    End Property

    Public Property All_Star_Traveler() As Boolean
        Get
            All_Star_Traveler = m_blnAll_Star_Traveler 
        End Get
        Set(ByVal value As Boolean)
            m_blnAll_Star_Traveler = value
        End Set
    End Property

    Public Property White_Glove_End_Date() As DateTime
        Get
            White_Glove_End_Date = m_dtWhite_Glove_End_Date
        End Get
        Set(ByVal value As DateTime)
            m_dtWhite_Glove_End_Date = value
        End Set
    End Property

    Public Property White_Glove_Order_Count() As Integer
        Get
            White_Glove_Order_Count = m_intWhite_Glove_Order_Count
        End Get
        Set(ByVal value As Integer)
            m_intWhite_Glove_Order_Count = value
        End Set
    End Property

    Public Property Coop_Pricing() As Boolean
        Get
            Coop_Pricing = m_blnCoop_Pricing
        End Get
        Set(ByVal value As Boolean)
            m_blnCoop_Pricing = value
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

    Public Property CountRMA_3Month As Integer
        Get
            CountRMA_3Month = m_CountRMA_3Month
        End Get
        Set(ByVal value As Integer)
            m_CountRMA_3Month = value
        End Set
    End Property

#End Region


End Class ' cMdb_Customer


