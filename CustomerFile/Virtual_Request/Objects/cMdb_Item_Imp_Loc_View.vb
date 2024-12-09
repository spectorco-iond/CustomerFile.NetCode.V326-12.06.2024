Public Class cMdb_Item_Imp_Loc_VIEW
    Implements ICloneable

#Region "private variables #################################################"

    Private m_intItem_Master_Id As Int32
    Private m_chIs_Kit As Char

    Private m_intItem_Imp_Loc_Id As Int32
    Private m_intComponent_Master_Id As Int32

    Private m_strItem_Cd As String
    Private m_strComponent_CD As String

    Private m_intDec_Met_Id As Int32
    Private m_strDec_Met_Desc As String

    Private m_intImp_Loc_Id As Int32
    Private m_strImp_Loc_Desc As String

    Private m_strArea_Size As String

    Private m_intDefault_Loc As Integer
    Private m_intWeb_Display As Int32
    Private m_intIs_Enlarged As Integer
    Private m_intIs_Personalizable As Int32

#End Region
    Public Sub New()
        Call Init()
    End Sub

#Region "------------- Public Function ---------------"


    Public Sub Init()

        m_intItem_Master_Id = 0
        m_chIs_Kit = String.Empty

        m_intItem_Imp_Loc_Id = 0
        m_intComponent_Master_Id = 0

        m_strItem_Cd = String.Empty
        m_strComponent_CD = String.Empty

        m_intDec_Met_Id = 0
        m_strDec_Met_Desc = "Blank" 'String.Empty

        m_intImp_Loc_Id = 0
        m_strImp_Loc_Desc = String.Empty

        m_strArea_Size = String.Empty

        m_intDefault_Loc = 0
        m_intWeb_Display = 0
        m_intIs_Enlarged = 0
        m_intIs_Personalizable = 0

    End Sub


    Private Sub LoadLine(pClass As cMdb_Item_Imp_Loc_VIEW, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("ITEM_MASTER_ID").Equals(DBNull.Value)) Then pClass.Item_Master_Id = pdrRow.Item("ITEM_MASTER_ID")
            If Not (pdrRow.Item("Is_Kit").Equals(DBNull.Value)) Then pClass.IS_KIT = pdrRow.Item("Is_Kit").ToString
            If Not (pdrRow.Item("ITEM_IMP_LOC_ID").Equals(DBNull.Value)) Then pClass.Item_Imp_Loc_Id = pdrRow.Item("ITEM_IMP_LOC_ID")
            If Not (pdrRow.Item("COMP_MASTER_ID").Equals(DBNull.Value)) Then pClass.Component_Master_Id = pdrRow.Item("COMP_MASTER_ID")

            If Not (pdrRow.Item("ITEM_CD").Equals(DBNull.Value)) Then pClass.ITEM_CD = pdrRow.Item("ITEM_CD").ToString
            If Not (pdrRow.Item("COMPONENT_CD").Equals(DBNull.Value)) Then pClass.COMPONENT_CD = pdrRow.Item("COMPONENT_CD").ToString

            If Not (pdrRow.Item("Dec_Met_Id").Equals(DBNull.Value)) Then pClass.Dec_Met_Id = pdrRow.Item("Dec_Met_Id")
            If Not (pdrRow.Item("DEC_MET_DESC").Equals(DBNull.Value)) Then pClass.Dec_Met_Desc = pdrRow.Item("DEC_MET_DESC").ToString

            If Not (pdrRow.Item("IMP_LOC_ID").Equals(DBNull.Value)) Then pClass.Imp_Loc_Id = pdrRow.Item("IMP_LOC_ID")
            If Not (pdrRow.Item("Imp_Loc_Desc").Equals(DBNull.Value)) Then pClass.Imp_Loc_Desc = pdrRow.Item("Imp_Loc_Desc").ToString

            If Not (pdrRow.Item("Area_Size").Equals(DBNull.Value)) Then pClass.AREA_SIZE = pdrRow.Item("Area_Size").ToString

            If Not (pdrRow.Item("DEFAULT_LOC").Equals(DBNull.Value)) Then pClass.Default_Loc = pdrRow.Item("DEFAULT_LOC")
            If Not (pdrRow.Item("WEB_DISPLAY").Equals(DBNull.Value)) Then pClass.Web_Display = pdrRow.Item("WEB_DISPLAY")
            If Not (pdrRow.Item("IS_ENLARGED").Equals(DBNull.Value)) Then pClass.Is_Enlarged = pdrRow.Item("IS_ENLARGED")
            If Not (pdrRow.Item("IS_PERSONALIZABLE").Equals(DBNull.Value)) Then pClass.Is_Personalizable = pdrRow.Item("IS_PERSONALIZABLE")


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub LoadLineCBO(pClass As cMdb_Item_Imp_Loc_VIEW, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("ITEM_MASTER_ID").Equals(DBNull.Value)) Then pClass.Item_Master_Id = pdrRow.Item("ITEM_MASTER_ID")
            'If Not (pdrRow.Item("Is_Kit").Equals(DBNull.Value)) Then pClass.IS_KIT = pdrRow.Item("Is_Kit").ToString
            'If Not (pdrRow.Item("ITEM_IMP_LOC_ID").Equals(DBNull.Value)) Then pClass.Item_Imp_Loc_Id = pdrRow.Item("ITEM_IMP_LOC_ID")
            'If Not (pdrRow.Item("COMP_MASTER_ID").Equals(DBNull.Value)) Then pClass.Component_Master_Id = pdrRow.Item("COMP_MASTER_ID")

            'If Not (pdrRow.Item("ITEM_CD").Equals(DBNull.Value)) Then pClass.ITEM_CD = pdrRow.Item("ITEM_CD").ToString
            'If Not (pdrRow.Item("COMPONENT_CD").Equals(DBNull.Value)) Then pClass.COMPONENT_CD = pdrRow.Item("COMPONENT_CD").ToString

            If Not (pdrRow.Item("Dec_Met_Id").Equals(DBNull.Value)) Then pClass.Dec_Met_Id = pdrRow.Item("Dec_Met_Id")
            If Not (pdrRow.Item("DEC_MET_DESC").Equals(DBNull.Value)) Then pClass.Dec_Met_Desc = pdrRow.Item("DEC_MET_DESC").ToString

            'If Not (pdrRow.Item("IMP_LOC_ID").Equals(DBNull.Value)) Then pClass.Imp_Loc_Id = pdrRow.Item("IMP_LOC_ID")
            'If Not (pdrRow.Item("Imp_Loc_Desc").Equals(DBNull.Value)) Then pClass.Imp_Loc_Desc = pdrRow.Item("Imp_Loc_Desc").ToString

            'If Not (pdrRow.Item("Area_Size").Equals(DBNull.Value)) Then pClass.AREA_SIZE = pdrRow.Item("Area_Size").ToString

            'If Not (pdrRow.Item("DEFAULT_LOC").Equals(DBNull.Value)) Then pClass.Default_Loc = pdrRow.Item("DEFAULT_LOC")
            'If Not (pdrRow.Item("WEB_DISPLAY").Equals(DBNull.Value)) Then pClass.Web_Display = pdrRow.Item("WEB_DISPLAY")
            'If Not (pdrRow.Item("IS_ENLARGED").Equals(DBNull.Value)) Then pClass.Is_Enlarged = pdrRow.Item("IS_ENLARGED")
            'If Not (pdrRow.Item("IS_PERSONALIZABLE").Equals(DBNull.Value)) Then pClass.Is_Personalizable = pdrRow.Item("IS_PERSONALIZABLE")


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Load(ByVal pintID As Integer) As cMdb_Item_Imp_Loc_VIEW

        Load = New cMdb_Item_Imp_Loc_VIEW()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Mdb_Item_Imp_Loc WITH (Nolock) " &
            "WHERE  Item_Imp_Loc_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    'load decomethod and other on the line
    Public Function LoadDecMet_List(ByVal p_Item_Master_id As Int32) As List(Of cMdb_Item_Imp_Loc_VIEW)
        LoadDecMet_List = New List(Of cMdb_Item_Imp_Loc_VIEW)
        Try
            Dim oEnum = New cMdb_Item_Imp_Loc_VIEW
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim i As Integer
            Dim strSql As String

            strSql = "select * from MDB_VIEW_DECOMETH_LOCATION_USEDTABLE WITH (NOLOCK) " _
                   & " where  ITEM_MASTER_ID = " & p_Item_Master_id

            dt = db.DataTable(strSql)

            'myList.Insert(0, oEnum)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Item_Imp_Loc_VIEW
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadDecMet_List = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    '------------------ only for display in combobox ---------------------
    Public Function LoadDecMetListCBO(ByVal p_Item_Master_id As Int32) As List(Of cMdb_Item_Imp_Loc_VIEW)
        LoadDecMetListCBO = New List(Of cMdb_Item_Imp_Loc_VIEW)
        Try
            Dim oEnum = New cMdb_Item_Imp_Loc_VIEW
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim i As Integer
            Dim strSql As String

            strSql = "select Distinct ITEM_MASTER_ID,dec_met_id,dec_met_desc from MDB_VIEW_DECOMETH_LOCATION_USEDTABLE WITH (NOLOCK) " _
                   & " where  ITEM_MASTER_ID = " & p_Item_Master_id

            dt = db.DataTable(strSql)
            ' myList.Insert(0, oEnum)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Item_Imp_Loc_VIEW
                    Call LoadLineCBO(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadDecMetListCBO = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'load location and other on the line
    Public Function LoadDecMet_List(ByVal p_Item_Master_id As Int32, ByVal p_Dec_Meth_Id As Int32) As List(Of cMdb_Item_Imp_Loc_VIEW)
        LoadDecMet_List = New List(Of cMdb_Item_Imp_Loc_VIEW)
        Try
            Dim oEnum = New cMdb_Item_Imp_Loc_VIEW
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim i As Integer
            Dim strSql As String

            strSql = "select * from MDB_VIEW_DECOMETH_LOCATION_USEDTABLE WITH (NOLOCK) " _
                   & " where  ITEM_MASTER_ID = " & p_Item_Master_id & " and Dec_Met_ID = " & p_Dec_Meth_Id



            dt = db.DataTable(strSql)

            'myList.Insert(0, oEnum)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Item_Imp_Loc_VIEW
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If
            LoadDecMet_List = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadDecMetCompListCBO(ByVal p_Item_Master_id As Int32, ByVal p_Comp_Master_Id As Int32, Optional ByVal p_dec_met_id As Int32 = 0) As List(Of cMdb_Item_Imp_Loc_VIEW)
        LoadDecMetCompListCBO = New List(Of cMdb_Item_Imp_Loc_VIEW)
        Try
            Dim oEnum = New cMdb_Item_Imp_Loc_VIEW
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim i As Integer
            Dim strSql As String

            strSql = "select  Distinct ITEM_MASTER_ID,dec_met_id,dec_met_desc  from MDB_VIEW_DECOMETH_LOCATION_USEDTABLE WITH (NOLOCK) " _
                   & " where  ITEM_MASTER_ID = " & p_Comp_Master_Id

            '  & " where  ITEM_MASTER_ID = " & p_Item_Master_id & " and COMP_MASTER_ID = " & p_Comp_Master_Id


            If p_dec_met_id <> 0 Then
                strSql &= " and Dec_Met_ID = " & p_dec_met_id
            End If

            dt = db.DataTable(strSql)

            '  myList.Insert(0, oEnum)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Item_Imp_Loc_VIEW
                    Call LoadLineCBO(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadDecMetCompListCBO = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadDecMetComp_List(ByVal p_Item_Master_id As Int32, ByVal p_Comp_Master_Id As Int32, Optional ByVal p_dec_met_id As Int32 = 0) As List(Of cMdb_Item_Imp_Loc_VIEW)
        LoadDecMetComp_List = New List(Of cMdb_Item_Imp_Loc_VIEW)
        Try
            Dim oEnum = New cMdb_Item_Imp_Loc_VIEW
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim i As Integer
            Dim strSql As String

            strSql = "select * from MDB_VIEW_DECOMETH_LOCATION_USEDTABLE WITH (NOLOCK) " _
                   & " where  ITEM_MASTER_ID = " & p_Comp_Master_Id


            '   & " where  ITEM_MASTER_ID = " & p_Item_Master_id & " and COMP_MASTER_ID = " & p_Comp_Master_Id
            If p_dec_met_id <> 0 Then
                strSql &= " and Dec_Met_ID = " & p_dec_met_id
            End If

            dt = db.DataTable(strSql)

            ' myList.Insert(0, oEnum)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMdb_Item_Imp_Loc_VIEW
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadDecMetComp_List = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    ' Deletes the current row from the database, if it exists.
    'Public Function Delete(pintID As Integer) As Boolean

    '    Delete = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql =
    '              "DELETE FROM Mdb_Item_Imp_Loc_Changes " &
    '          "WHERE  Item_Imp_Loc_Changes_Id = " & pintID & " "

    '        db.Execute(strSql)

    '        Delete = True

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function



#End Region

#Region "Public properties ################################################"

    Public Property Item_Master_Id() As Int32
        Get
            Item_Master_Id = m_intItem_Master_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Master_Id = value
        End Set
    End Property

    Public Property IS_KIT As Char
        Get
            IS_KIT = m_chIs_Kit
        End Get
        Set(ByVal value As Char)
            m_chIs_Kit = value
        End Set
    End Property

    Public Property Item_Imp_Loc_Id() As Int32
        Get
            Item_Imp_Loc_Id = m_intItem_Imp_Loc_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Imp_Loc_Id = value
        End Set
    End Property
    Public Property Component_Master_Id() As Int32
        Get
            Component_Master_Id = m_intComponent_Master_Id
        End Get
        Set(ByVal value As Int32)
            m_intComponent_Master_Id = value
        End Set
    End Property
    Public Property ITEM_CD() As String
        Get
            ITEM_CD = m_strItem_Cd
        End Get
        Set(ByVal value As String)
            m_strItem_Cd = value
        End Set
    End Property
    Public Property COMPONENT_CD() As String
        Get
            COMPONENT_CD = m_strComponent_CD
        End Get
        Set(ByVal value As String)
            m_strComponent_CD = value
        End Set
    End Property
    Public Property Dec_Met_Id() As Int32
        Get
            Dec_Met_Id = m_intDec_Met_Id
        End Get
        Set(ByVal value As Int32)
            m_intDec_Met_Id = value
        End Set
    End Property

    Public Property Dec_Met_Desc() As String
        Get
            Dec_Met_Desc = m_strDec_Met_Desc
        End Get
        Set(ByVal value As String)
            m_strDec_Met_Desc = value
        End Set
    End Property

    Public Property Imp_Loc_Id() As Int32
        Get
            Imp_Loc_Id = m_intImp_Loc_Id
        End Get
        Set(ByVal value As Int32)
            m_intImp_Loc_Id = value
        End Set
    End Property

    Public Property Imp_Loc_Desc() As String
        Get
            Imp_Loc_Desc = m_strImp_Loc_Desc
        End Get
        Set(ByVal value As String)
            m_strImp_Loc_Desc = value
        End Set
    End Property

    Public Property AREA_SIZE() As String
        Get
            AREA_SIZE = m_strArea_Size
        End Get
        Set(ByVal value As String)
            m_strArea_Size = value
        End Set
    End Property

    Public Property Default_Loc() As Integer
        Get
            Default_Loc = m_intDefault_Loc
        End Get
        Set(ByVal value As Integer)
            m_intDefault_Loc = value
        End Set
    End Property
    Public Property Web_Display() As Int32
        Get
            Web_Display = m_intWeb_Display
        End Get
        Set(ByVal value As Int32)
            m_intWeb_Display = value
        End Set
    End Property
    Public Property Is_Enlarged() As Integer
        Get
            Is_Enlarged = m_intIs_Enlarged
        End Get
        Set(ByVal value As Integer)
            m_intIs_Enlarged = value
        End Set
    End Property

    Public Property Is_Personalizable() As Int32
        Get
            Is_Personalizable = m_intIs_Personalizable
        End Get
        Set(ByVal value As Int32)
            m_intIs_Personalizable = value
        End Set
    End Property


#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

End Class ' cMdb_Item_Imp_Loc
