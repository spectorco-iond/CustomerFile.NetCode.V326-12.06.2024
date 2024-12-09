Public Class cMdb_Item_Master
    Implements ICloneable

#Region "private variables #################################################"

    Private m_intItem_Master_Id As Int32
    Private m_intItem_Id As Int32
    Private m_strItem_Cd As String
    Private m_intVersion_No As Int32
    Private m_intIs_Current As Int32
    Private m_strStatus As String
    Private m_strPending_Item_Cd As String
    Private m_intItem_Classification_Id As Int32
    Private m_strProd_Category As String
    Private m_intIs_Kit As String
    Private m_dEffective_Start_Date As Date
    Private m_dEffective_End_Date As Date
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime


#End Region


    Public Function LoadByMasterId(ByVal pintID As Integer) As cMdb_Item_Master
        LoadByMasterId = New cMdb_Item_Master()
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Mdb_Item_Master WITH (Nolock) " &
            "WHERE  Item_Master_Id = " & pintID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(LoadByMasterId, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Master." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function LoadMasterCd_List(ByVal pItemCd As String) As List(Of cMdb_Item_Master)
        LoadMasterCd_List = New List(Of cMdb_Item_Master)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Master)
            Dim i As Integer
            Dim strSql As String

            strSql =
            "SELECT * " &
            "FROM   Mdb_Item_Master WITH (Nolock) " &
            "WHERE  (Item_Cd Like '%" & Trim(pItemCd) & "%' Or Pending_Item_Cd Like '%" & Trim(pItemCd) & "%') "



            strSql = "Select  Item_Master_Id, Item_Id, Case when isnull(m.ITEM_CD,'') = '' then m.PENDING_ITEM_CD else m.ITEM_CD end As Item_Cd,  " _
                   & " Version_No, Is_Current, Status, Pending_Item_Cd, Item_Classification_Id, " _
                   & " dbo.MDB_Prod_Cat(m.ITEM_CLASSIFICATION_ID) As Prod_Category, case when Is_Kit = 0 then 'N' when  Is_Kit = 1 then 'K' else 'N' end as Is_Kit, " _
                   & " Effective_Start_Date, Effective_End_Date, " _
                   & " User_Login, Create_Ts, Update_Ts From MDB_ITEM_MASTER m " _
                   & "WHERE  (m.Item_Cd Like '%" & Trim(pItemCd) & "%' Or m.Pending_Item_Cd Like '%" & Trim(pItemCd) & "%') "

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Item_Master
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadMasterCd_List = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Master." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadKitInfo_List(ByVal pItemMaster As Int32) As List(Of cMdb_Item_Master)
        LoadKitInfo_List = New List(Of cMdb_Item_Master)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Master)
            Dim i As Integer
            Dim strSql As String


            strSql = "select  m.Item_Master_Id, m.Item_Id, Case when isnull(m.ITEM_CD,'') = '' then m.PENDING_ITEM_CD else m.ITEM_CD end As Item_Cd, " _
 & " m.Version_No, m.Is_Current, m.Status, m.Pending_Item_Cd, m.Item_Classification_Id, dbo.MDB_Prod_Cat(m.ITEM_CLASSIFICATION_ID) As Prod_Category,  " _
 & " case when m.Is_Kit = 0 then 'N' when  m.Is_Kit = 1 then 'K' else 'N' end as Is_Kit, m.Effective_Start_Date, m.Effective_End_Date,  " _
 & " m.User_Login, m.Create_Ts, m.Update_Ts  " _
 & " from MDB_ITEM_MASTER m  inner join MDB_ITEM_IMP_LOC l on  m.ITEM_MASTER_ID  = l.COMPONENT_MASTER_ID   " _
 & " where l.ITEM_MASTER_ID = " & pItemMaster

            strSql =
              "  select " _
& "  m.Item_Master_Id, m.Item_Id, Case When isnull(m.ITEM_CD,'') = '' then m.PENDING_ITEM_CD else m.ITEM_CD end As Item_Cd, " _
& "  m.Version_No, m.Is_Current, m.Status, m.Pending_Item_Cd, m.Item_Classification_Id, dbo.MDB_Prod_Cat(m.ITEM_CLASSIFICATION_ID) As Prod_Category,  " _
& "  Case when m.Is_Kit = 0 then 'N' when  m.Is_Kit = 1 then 'K' else 'N' end as Is_Kit, m.Effective_Start_Date, m.Effective_End_Date,  " _
& "  m.User_Login, m.Create_Ts, m.Update_Ts" _
& "  From mdb_item_master m Where Item_Master_Id   In " _
& "  ( " _
& "  Select distinct k.COMPONENT_MASTER_ID  from MDB_KIT_COMPONENT k inner join MDB_ITEM_MASTER m On  " _
& "  k.COMPONENT_MASTER_ID = m.ITEM_MASTER_ID " _
    & "             where k.ITEM_MASTER_ID = " & pItemMaster _
& "  ) "



            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Item_Master
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadKitInfo_List = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Master." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub LoadLine(ByVal pClass As cMdb_Item_Master, ByRef pdrRow As DataRow)
        Try

            If Not (pdrRow.Item("Item_Master_Id").Equals(DBNull.Value)) Then pClass.Item_Master_Id = pdrRow.Item("Item_Master_Id")
            If Not (pdrRow.Item("Item_Id").Equals(DBNull.Value)) Then pClass.Item_Id = pdrRow.Item("Item_Id")
            If Not (pdrRow.Item("Item_Cd").Equals(DBNull.Value)) Then pClass.Item_Cd = pdrRow.Item("Item_Cd").ToString
            If Not (pdrRow.Item("Version_No").Equals(DBNull.Value)) Then pClass.Version_No = pdrRow.Item("Version_No")
            If Not (pdrRow.Item("Is_Current").Equals(DBNull.Value)) Then pClass.Is_Current = pdrRow.Item("Is_Current")
            If Not (pdrRow.Item("Is_Kit").Equals(DBNull.Value)) Then pClass.Is_Kit = pdrRow.Item("Is_Kit").ToString
            If Not (pdrRow.Item("Status").Equals(DBNull.Value)) Then pClass.Status = pdrRow.Item("Status").ToString
            If Not (pdrRow.Item("Pending_Item_Cd").Equals(DBNull.Value)) Then pClass.Pending_Item_Cd = pdrRow.Item("Pending_Item_Cd").ToString
            If Not (pdrRow.Item("Item_Classification_Id").Equals(DBNull.Value)) Then pClass.Item_Classification_Id = pdrRow.Item("Item_Classification_Id")
            If Not (pdrRow.Item("Prod_Category").Equals(DBNull.Value)) Then pClass.m_strProd_Category = pdrRow.Item("Prod_Category").ToString

            If Not (pdrRow.Item("Effective_Start_Date").Equals(DBNull.Value)) Then pClass.Effective_Start_Date = pdrRow.Item("Effective_Start_Date")
            If Not (pdrRow.Item("Effective_End_Date").Equals(DBNull.Value)) Then pClass.Effective_End_Date = pdrRow.Item("Effective_End_Date")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then pClass.User_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then pClass.Create_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then pClass.Update_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Master." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



#Region "Public properties ################################################"

    Public Property Item_Master_Id() As Int32
        Get
            Item_Master_Id = m_intItem_Master_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Master_Id = value
        End Set
    End Property

    Public Property Item_Id() As Int32
        Get
            Item_Id = m_intItem_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Id = value
        End Set
    End Property

    Public Property Version_No() As Int32
        Get
            Version_No = m_intVersion_No
        End Get
        Set(ByVal value As Int32)
            m_intVersion_No = value
        End Set
    End Property

    Public Property Is_Current() As Int32
        Get
            Is_Current = m_intIs_Current
        End Get
        Set(ByVal value As Int32)
            m_intIs_Current = value
        End Set
    End Property

    Public Property Is_Kit() As String
        Get
            Is_Kit = m_intIs_Kit
        End Get
        Set(ByVal value As String)
            m_intIs_Kit = value
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

    Public Property Status() As String
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As String)
            m_strStatus = value
        End Set
    End Property

    Public Property Pending_Item_Cd() As String
        Get
            Pending_Item_Cd = m_strPending_Item_Cd
        End Get
        Set(ByVal value As String)
            m_strPending_Item_Cd = value
        End Set
    End Property

    Public Property Item_Classification_Id() As Int32
        Get
            Item_Classification_Id = m_intItem_Classification_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Classification_Id = value
        End Set
    End Property
    Public Property PRODUCT_CATEGORY As String
        Get
            PRODUCT_CATEGORY = m_strProd_Category
        End Get
        Set(value As String)
            m_strProd_Category = value
        End Set
    End Property
    Public Property Effective_Start_Date() As Date
        Get
            Effective_Start_Date = m_dEffective_Start_Date
        End Get
        Set(ByVal value As Date)
            m_dEffective_Start_Date = value
        End Set
    End Property

    Public Property Effective_End_Date() As Date
        Get
            Effective_End_Date = m_dEffective_End_Date
        End Get
        Set(ByVal value As Date)
            m_dEffective_End_Date = value
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

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

End Class ' cMdb_Item_Master

