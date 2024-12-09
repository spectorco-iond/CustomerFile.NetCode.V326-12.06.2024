Public Class cMdb_Cus_Prog_Item_List
    Implements ICloneable

#Region "private variables #################################################"


    Private m_intCus_Prog_Item_List_Id As Int32
    Private m_strCus_Prog_Item_List_Guid As String
    Private m_intCus_Prog_Id As Int32
    Private m_intProd_Cat_ID As Integer
    Private m_strItem_Cd As String
    Private m_intCustom_Item_Id As Integer
    Private m_strItem_No As String
    Private m_strItem_Desc As String
    Private m_strItem_Color As String
    Private m_intEqp_Level As Int32
    Private m_intEqp_Column As Int32
    Private m_decEqp_Pct As Decimal
    Private m_decUnit_Price As Decimal
    Private m_decMin_Qty_Ord As Decimal
    Private m_blnSetup_Waived As Boolean
    Private m_decSetup_Price As Decimal
    Private m_decRun_Charge As Decimal
    Private m_intDec_Met_ID As Integer
    Private m_intDec_Met_Group_ID As Integer
    Private m_intColor_Count As Integer
    Private m_intLocation_Count As Integer
    Private m_intQuote_Type_ID As Integer
    Private m_intQuote_Ship_Method_ID As Integer
    Private m_intPack_ID As Integer
    Private m_intPack_Qty_By_Id As Integer
    Private m_strPack_Comment As String
    Private m_blnOverseas As Boolean
    Private m_blnDomestic As Boolean
    Private m_intRefill_Id As Integer
    Private m_strRefill_Color As String
    Private m_intRefill_Qty As Integer
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime
    Private m_intDocId As Int32
    Private m_intChargeId As Int32
    Private m_blNeedApproval As Boolean
    Private m_strApprovedBy As String
    Private m_dtApprovedDate As DateTime
    Private m_item_comment_logo As String

#End Region


#Region "Constructors #####################################################"

    Public Sub New()

        m_strCus_Prog_Item_List_Guid = Guid.NewGuid.ToString

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Item_List_Id() As Int32
        Get
            Cus_Prog_Item_List_Id = m_intCus_Prog_Item_List_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Item_List_Id = value
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

    Public Property Cus_Prog_Id() As Int32
        Get
            Cus_Prog_Id = m_intCus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Id = value
        End Set
    End Property

    Public Property Prod_Cat_ID() As Integer
        Get
            Prod_Cat_ID = m_intProd_Cat_ID
        End Get
        Set(ByVal value As Int32)
            m_intProd_Cat_ID = value
        End Set
    End Property

    Public Property Item_Cd() As String
        Get
            Item_Cd = m_strItem_Cd
        End Get
        Set(ByVal value As String)
            m_strItem_Cd = value
        End Set
    End Property

    Public Property Custom_Item_Id() As Integer
        Get
            Custom_Item_Id = m_intCustom_Item_Id
        End Get
        Set(ByVal value As Integer)
            m_intCustom_Item_Id = value
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

    Public Property Item_Desc() As String
        Get
            Item_Desc = m_strItem_Desc
        End Get
        Set(ByVal value As String)
            m_strItem_Desc = value
        End Set
    End Property

    Public Property Item_Color() As String
        Get
            Item_Color = m_strItem_Color
        End Get
        Set(ByVal value As String)
            m_strItem_Color = value
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

    Public Property Setup_Waived() As Boolean
        Get
            Setup_Waived = m_blnSetup_Waived
        End Get
        Set(ByVal value As Boolean)
            m_blnSetup_Waived = value
        End Set
    End Property

    Public Property Setup_Price() As Decimal
        Get
            Setup_Price = m_decSetup_Price
        End Get
        Set(ByVal value As Decimal)
            m_decSetup_Price = value
        End Set
    End Property

    Public Property Run_Charge() As Decimal
        Get
            Run_Charge = m_decRun_Charge
        End Get
        Set(ByVal value As Decimal)
            m_decRun_Charge = value
        End Set
    End Property

    Public Property Dec_Met_ID() As Integer
        Get
            Dec_Met_ID = m_intDec_Met_ID
        End Get
        Set(value As Integer)
            m_intDec_Met_ID = value
        End Set
    End Property

    Public Property Dec_Met_Group_ID() As Integer
        Get
            Dec_Met_Group_ID = m_intDec_Met_Group_ID
        End Get
        Set(value As Integer)
            m_intDec_Met_Group_ID = value
        End Set
    End Property

    Public Property Color_Count() As Integer
        Get
            Color_Count = m_intColor_Count
        End Get
        Set(value As Integer)
            m_intColor_Count = value
        End Set
    End Property

    Public Property Location_Count() As Integer
        Get
            Location_Count = m_intLocation_Count
        End Get
        Set(value As Integer)
            m_intLocation_Count = value
        End Set
    End Property

    Public Property Quote_Type_ID() As Integer
        Get
            Quote_Type_ID = m_intQuote_Type_ID
        End Get
        Set(value As Integer)
            m_intQuote_Type_ID = value
        End Set
    End Property

    Public Property Quote_Ship_Method_ID() As Integer
        Get
            Quote_Ship_Method_ID = m_intQuote_Ship_Method_ID
        End Get
        Set(value As Integer)
            m_intQuote_Ship_Method_ID = value
        End Set
    End Property

    Public Property Pack_ID() As Integer
        Get
            Pack_ID = m_intPack_ID
        End Get
        Set(value As Integer)
            m_intPack_ID = value
        End Set
    End Property

    Public Property Pack_Qty_By_ID() As Integer
        Get
            Pack_Qty_By_ID = m_intPack_Qty_By_Id
        End Get
        Set(value As Integer)
            m_intPack_Qty_By_Id = value
        End Set
    End Property

    Public Property Pack_Comment() As String
        Get
            Pack_Comment = m_strPack_Comment
        End Get
        Set(value As String)
            m_strPack_Comment = value
        End Set
    End Property

    Public Property Overseas() As Boolean
        Get
            Overseas = m_blnOverseas
            'Overseas = (m_intQuote_Type_ID = 1) 
        End Get
        Set(ByVal value As Boolean)
            m_blnOverseas = value
        End Set
    End Property

    Public Property Domestic() As Boolean
        Get
            Domestic = m_blnDomestic
            'Domestic = (m_intQuote_Type_ID = 2) 
        End Get
        Set(ByVal value As Boolean)
            m_blnDomestic = value
        End Set
    End Property

    Public Property Refill_ID() As Integer
        Get
            Refill_ID = m_intRefill_Id
        End Get
        Set(value As Integer)
            m_intRefill_Id = value
        End Set
    End Property

    Public Property Refill_Color() As String
        Get
            Refill_Color = m_strRefill_Color
        End Get
        Set(value As String)
            m_strRefill_Color = value
        End Set
    End Property

    Public Property Refill_Qty() As Integer
        Get
            Refill_Qty = m_intRefill_Qty
        End Get
        Set(value As Integer)
            m_intRefill_Qty = value
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
    Public Property DocID As Int32
        Get
            DocID = m_intDocId
        End Get
        Set(ByVal value As Int32)
            m_intDocId = value
        End Set
    End Property
    Public Property ChargeId As Int32
        Get
            ChargeId = m_intChargeId
        End Get
        Set(ByVal value As Int32)
            m_intChargeId = value
        End Set
    End Property
    Public Property Need_Approval As Boolean
        Get
            Return m_blNeedApproval
        End Get
        Set(value As Boolean)
            m_blNeedApproval = value
        End Set
    End Property
    Public Property ApprovedBy As String
        Get
            Return m_strApprovedBy
        End Get
        Set(value As String)
            m_strApprovedBy = value
        End Set
    End Property
    Public Property Approved_Date As DateTime
        Get
            Return m_dtApprovedDate
        End Get
        Set(value As DateTime)
            m_dtApprovedDate = value
        End Set
    End Property

    Public Property Item_comment_logo As String
        Get
            Return m_item_comment_logo
        End Get
        Set(value As String)
            m_item_comment_logo = value
        End Set
    End Property


#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class ' cMdb_Cus_Prog_Item_List


