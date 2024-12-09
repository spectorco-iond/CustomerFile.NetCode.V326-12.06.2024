Public Class cMdb_Item_VariantColor
    Implements ICloneable


#Region "private variables #################################################"


    Private m_intItem_Variant_Id As Int32
    Private m_intItem_Master_Id As Int16

    Private m_intColor_Id As Int32
    Private m_strColor_Cd As String
    Private m_strColor_Name As String
    Private m_strColor_Name_Fr As String

    Private m_strItem_No As String
    Private m_strMaco_Desc1 As String
    Private m_blWQL_Status As Boolean
    Private m_strWql_Disco As String

#End Region

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()

        m_intItem_Variant_Id = 0
        m_intItem_Master_Id = 0

        m_intColor_Id = 0
        m_strColor_Cd = String.Empty
        m_strColor_Name = String.Empty
        m_strColor_Name_Fr = String.Empty
        m_strItem_No = String.Empty
        m_strMaco_Desc1 = String.Empty
        m_blWQL_Status = False
        m_strWql_Disco = String.Empty

    End Sub

    'take list for populate dropdownlist
    Public Function Load_VariantListColor(ByVal pintID As Int32) As List(Of cMdb_Item_VariantColor)

        Load_VariantListColor = New List(Of cMdb_Item_VariantColor)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_VariantColor)
            Dim i As Integer

            Dim strSql As String
            strSql =
               " select v.ITEM_VARIANT_ID ,v.ITEM_MASTER_ID,v.COLOR_ID,c.COLOR_CD ,c.COLOR_NAME,c.COLOR_NAME_FR,v.ITEM_NO,f.VALUE_STR as 'Maco_desc1', " _
             & " v.STATUS,v.WQL_STATUS,v.WQL_DISCO  from MDB_ITEM_VARIANT v inner join MDB_ITEM_MASTER m on v.ITEM_MASTER_ID = m.ITEM_MASTER_ID  " _
             & " inner join MDB_CFG_COLOR c on v.COLOR_ID = c.COLOR_ID   left join MDB_ITEM_FLD_VALUE f on v.ITEM_MASTER_ID = f.ITEM_MASTER_ID  " _
             & "  and v.ITEM_VARIANT_ID = f.ITEM_VARIANT_ID and ITEM_FLD_ID = 69 where v.ITEM_MASTER_ID = " & pintID

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then

                strSql = "  select ITEM_VARIANT_ID = 0 ,ITEM_MASTER_ID = 0, COLOR_ID = 0, COLOR_CD='empty' ,COLOR_NAME='-', COLOR_NAME_FR='-',ITEM_NO='-',Maco_Desc1 = '-' ," _
                 & "STATUS=0,WQL_STATUS= 0 ,WQL_DISCO='-'  "

                dt = db.DataTable(strSql)
            End If
            Dim oEnum = New cMdb_Item_VariantColor


            myList.Insert(0, oEnum)
            For i = 0 To dt.Rows.Count - 1
                oEnum = New cMdb_Item_VariantColor
                Call LoadLine(oEnum, dt.Rows(i))
                myList.Add(oEnum)
            Next

            Load_VariantListColor = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_VariantColor." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Load_KitCompVariantListColor(ByVal pintID As Int32, ByVal pItVariantId As String, ByVal pCompMasterId As Int32) As List(Of cMdb_Item_VariantColor)

        Load_KitCompVariantListColor = New List(Of cMdb_Item_VariantColor)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_VariantColor)
            Dim i As Integer


            'example
            ' select v.ITEM_VARIANT_ID ,v.ITEM_MASTER_ID,v.COLOR_ID as id_color,v.ITEM_NO,v.STATUS,
            '  vv.ITEM_VARIANT_ID , vv.ITEM_MASTER_ID, vv.COLOR_ID As id_color, vv.ITEM_NO, vv.STATUS from MDB_KIT_COMPONENT k inner join MDB_ITEM_VARIANT v on 
            'k.item_VARIANT_ID = v.ITEM_VARIANT_ID inner join 
            'MDB_KIT_COMPONENT kk on k.KIT_COMPONENT_ID =kk.KIT_COMPONENT_ID 
            'inner Join MDB_ITEM_VARIANT vv on kk.COMPONENT_VARIANT_ID = vv.ITEM_VARIANT_ID 
            ' where k.ITEM_MASTER_ID = 26013 And v.ITEM_VARIANT_ID = 101561

            Dim strSql As String
            strSql =
               " select v.ITEM_VARIANT_ID ,v.ITEM_MASTER_ID,v.COLOR_ID,c.COLOR_CD ,c.COLOR_NAME,c.COLOR_NAME_FR,v.ITEM_NO," _
             & " v.STATUS,v.WQL_STATUS,v.WQL_DISCO from MDB_KIT_COMPONENT k inner join MDB_ITEM_VARIANT v on k.item_VARIANT_ID  = v.ITEM_VARIANT_ID inner join  " _
             & " MDB_KIT_COMPONENT kk on k.KIT_COMPONENT_ID =kk.KIT_COMPONENT_ID " _
             & " inner join MDB_ITEM_VARIANT vv on kk.COMPONENT_VARIANT_ID = vv.ITEM_VARIANT_ID " _
             & " where k.ITEM_MASTER_ID = " & pintID & " and v.ITEM_VARIANT_ID = " & pItVariantId


            '++ID 02.08.2022 
            strSql =
                " select v.ITEM_VARIANT_ID ,v.ITEM_MASTER_ID,v.COLOR_ID,c.COLOR_CD ,c.COLOR_NAME,c.COLOR_NAME_FR,v.ITEM_NO,f.VALUE_STR as 'Maco_Desc1',  " _
        & "v.STATUS,v.WQL_STATUS,v.WQL_DISCO  from  MDB_KIT_COMPONENT k inner join MDB_ITEM_VARIANT v On k.COMPONENT_VARIANT_ID = v.ITEM_VARIANT_ID  " _
        & " inner join MDB_CFG_COLOR c on v.COLOR_ID = c.COLOR_ID   left join MDB_ITEM_FLD_VALUE f on v.ITEM_MASTER_ID = f.ITEM_MASTER_ID  " _
        & "  and v.ITEM_VARIANT_ID = f.ITEM_VARIANT_ID and ITEM_FLD_ID = 69 " _
        & " where k.ITEM_MASTER_ID = " & pintID & " And k.ITEM_VARIANT_ID = " & pItVariantId & " And k.COMPONENT_MASTER_ID = " & pCompMasterId & "" _
        & " union " _
        & " select v.ITEM_VARIANT_ID ,v.ITEM_MASTER_ID,v.COLOR_ID,c.COLOR_CD ,c.COLOR_NAME,c.COLOR_NAME_FR,v.ITEM_NO,f.VALUE_STR as 'Maco_Desc1',  " _
        & "v.STATUS,v.WQL_STATUS,v.WQL_DISCO  from  MDB_KIT_COMPONENT k inner join MDB_ITEM_VARIANT v On  k.COMPONENT_MASTER_ID = v.ITEM_MASTER_ID   " _
        & " inner join MDB_CFG_COLOR c on v.COLOR_ID = c.COLOR_ID   left join MDB_ITEM_FLD_VALUE f on v.ITEM_MASTER_ID = f.ITEM_MASTER_ID  " _
        & "  and v.ITEM_VARIANT_ID = f.ITEM_VARIANT_ID and ITEM_FLD_ID = 69 " _
        & "  inner join   MDB_ITEM_FLD_VALUE fv on  k.ITEM_MASTER_ID = fv.ITEM_MASTER_ID and fv.ITEM_FLD_ID = 266 and ISNULL(fv.VALUE_INT,0) = 1 " _
        & " where k.ITEM_MASTER_ID = " & pintID & " And k.ITEM_VARIANT_ID = " & pItVariantId & " And k.COMPONENT_MASTER_ID = " & pCompMasterId & ""




            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then

                strSql = "  Select ITEM_VARIANT_ID = 0 ,ITEM_MASTER_ID = 0, COLOR_ID = 0, COLOR_CD='empty' ,COLOR_NAME='-', COLOR_NAME_FR='-',ITEM_NO='-', Maco_desc1 = '-'," _
                 & "STATUS=0,WQL_STATUS= 0 ,WQL_DISCO='-'  "

                dt = db.DataTable(strSql)
            End If
            Dim oEnum = New cMdb_Item_VariantColor


            ' myList.Insert(0, oEnum)
            For i = 0 To dt.Rows.Count - 1
                oEnum = New cMdb_Item_VariantColor
                Call LoadLine(oEnum, dt.Rows(i))
                myList.Add(oEnum)
            Next

            Load_KitCompVariantListColor = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_VariantColor." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByVal pClass As cMdb_Item_VariantColor, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Item_Variant_Id").Equals(DBNull.Value)) Then pClass.Item_Variant_Id = pdrRow.Item("Item_Variant_Id")
            If Not (pdrRow.Item("Item_Master_Id").Equals(DBNull.Value)) Then pClass.Item_Master_Id = pdrRow.Item("Item_Master_Id")


            If Not (pdrRow.Item("Color_Id").Equals(DBNull.Value)) Then pClass.Color_Id = pdrRow.Item("Color_Id")
            If Not (pdrRow.Item("Color_Cd").Equals(DBNull.Value)) Then pClass.Color_Cd = pdrRow.Item("Color_Cd").ToString
            If Not (pdrRow.Item("Color_Name").Equals(DBNull.Value)) Then pClass.Color_Name = pdrRow.Item("Color_Name").ToString
            If Not (pdrRow.Item("Color_Name_Fr").Equals(DBNull.Value)) Then pClass.Color_Name_Fr = pdrRow.Item("Color_Name_Fr").ToString

            If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then pClass.Item_No = pdrRow.Item("Item_No").ToString
            If Not (pdrRow.Item("Maco_desc1").Equals(DBNull.Value)) Then pClass.Maco_Desc1 = pdrRow.Item("Maco_desc1").ToString

            If Not (pdrRow.Item("Wql_Status").Equals(DBNull.Value)) Then pClass.WQL_STATUS = pdrRow.Item("Wql_Status")
            If Not (pdrRow.Item("Wql_Disco").Equals(DBNull.Value)) Then pClass.WQL_DISCO = pdrRow.Item("Wql_Disco").ToString

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_VariantColor." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
#Region "Public properties ################################################"


    '---------------------------------------
    Public Property Item_Variant_Id() As Int32
        Get
            Item_Variant_Id = m_intItem_Variant_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Variant_Id = value
        End Set
    End Property

    Public Property Item_Master_Id() As Int32
        Get
            Item_Master_Id = m_intItem_Master_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Master_Id = value
        End Set
    End Property

    Public Property Color_Id() As Int32
        Get
            Color_Id = m_intColor_Id
        End Get
        Set(ByVal value As Int32)
            m_intColor_Id = value
        End Set
    End Property
    Public Property Color_Cd() As String
        Get
            Color_Cd = m_strColor_Cd
        End Get
        Set(ByVal value As String)
            m_strColor_Cd = value
        End Set
    End Property

    Public Property Color_Name() As String
        Get
            Color_Name = m_strColor_Name
        End Get
        Set(ByVal value As String)
            m_strColor_Name = value
        End Set
    End Property

    Public Property Color_Name_Fr() As String
        Get
            Color_Name_Fr = m_strColor_Name_Fr
        End Get
        Set(ByVal value As String)
            m_strColor_Name_Fr = value
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
    Public Property Maco_Desc1 As String
        Get
            Maco_Desc1 = m_strMaco_Desc1
        End Get
        Set(value As String)
            m_strMaco_Desc1 = value
        End Set
    End Property
    Public Property WQL_STATUS() As Boolean
        Get
            WQL_STATUS = m_blWQL_Status
        End Get
        Set(value As Boolean)
            m_blWQL_Status = value
        End Set
    End Property

    Public Property WQL_DISCO() As String
        Get
            WQL_DISCO = m_strWql_Disco
        End Get
        Set(value As String)
            m_strWql_Disco = value
        End Set
    End Property
    '---------------------------------------


#End Region
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

End Class

Public Class cMdb_Cfg_Color
    Implements ICloneable

    Private m_intColor_id As Int32
    Private m_Color_Cd As String
    Private m_Color_Name As String
    Private m_Color_Name_Fr As String

    Public Sub New()
        Call init()
    End Sub

    Private Sub init()
        m_intColor_id = 0
        m_Color_Cd = String.Empty
        m_Color_Name = String.Empty
        m_Color_Name_Fr = String.Empty
    End Sub

    Private Sub LoadLine(ByVal pClass As cMdb_Cfg_Color, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Color_id").Equals(DBNull.Value)) Then pClass.COLOR_ID = pdrRow.Item("Color_id")
            If Not (pdrRow.Item("Color_CD").Equals(DBNull.Value)) Then pClass.COLOR_CD = pdrRow.Item("COLOR_CD").ToString

            If Not (pdrRow.Item("Color_Name").Equals(DBNull.Value)) Then pClass.COLOR_NAME = pdrRow.Item("Color_Name").ToString
            If Not (pdrRow.Item("Color_Name_Fr").Equals(DBNull.Value)) Then pClass.COLOR_NAME_FR = pdrRow.Item("Color_Name_Fr").ToString


        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Load() As List(Of cMdb_Cfg_Color)

        Load = New List(Of cMdb_Cfg_Color)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Cfg_Color)
            Dim i As Integer

            Dim strSql As String
            strSql = " select color_id,color_cd,color_name, color_name_fr from mdb_cfg_color"


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Dim oEnum = New cMdb_Cfg_Color
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Cfg_Color
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Property COLOR_ID As Int32
        Get
            Return m_intColor_id
        End Get
        Set(value As Int32)
            m_intColor_id = value
        End Set
    End Property
    Public Property COLOR_CD As String
        Get
            Return m_Color_Cd
        End Get
        Set(value As String)
            m_Color_Cd = value
        End Set
    End Property
    Public Property COLOR_NAME As String
        Get
            Return m_Color_Name
        End Get
        Set(value As String)
            m_Color_Name = value
        End Set
    End Property
    Public Property COLOR_NAME_FR As String
        Get
            Return m_Color_Name_Fr
        End Get
        Set(value As String)
            m_Color_Name_Fr = value
        End Set
    End Property

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

End Class
