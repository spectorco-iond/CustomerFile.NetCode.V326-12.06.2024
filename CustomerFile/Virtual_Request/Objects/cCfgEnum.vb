
Public Class cCfgEnum
    Implements ICloneable

    Private m_intId As Int32
    Private m_strEnum_Cat As String
    Private m_strEnumSubCat As String
    Private m_strEnum_Value As String



    Public Sub New()
        Call Init()
    End Sub

    Private Sub LoadLine(ByVal pClass As cCfgEnum, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then pClass.Enum_ID = pdrRow.Item("ID")
            If Not (pdrRow.Item("Enum_Cat").Equals(DBNull.Value)) Then pClass.Enum_Cat = pdrRow.Item("Enum_Cat").ToString

            If Not (pdrRow.Item("Enum_Sub_Cat").Equals(DBNull.Value)) Then pClass.Enum_Sub_Cat = pdrRow.Item("Enum_Sub_Cat").ToString
            If Not (pdrRow.Item("Enum_Value").Equals(DBNull.Value)) Then pClass.Enum_Value = pdrRow.Item("Enum_Value").ToString

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_VariantColor." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Init()
        m_intId = 0
        m_strEnum_Cat = String.Empty
        m_strEnumSubCat = String.Empty
        m_strEnum_Value = String.Empty
    End Sub

    Public Function LoadEnumCat(ByVal p_EnumCat As String, Optional ByVal p_ITEM As String = "") As List(Of cCfgEnum)
        LoadEnumCat = New List(Of cCfgEnum)
        Try
            Dim oEnum = New cCfgEnum
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCfgEnum)
            Dim i As Integer
            Dim strSql As String

            'strSql =
            '    " select e.ID,e.Enum_Cat,e.Enum_Sub_Cat,E.ENUM_VALUE from MDB_CFG_ITEM_FLD f inner join mdb_cfg_enum e on f.ENUM_CAT = e.ENUM_CAT  " _
            '  & " inner join MDB_CFG_DEC_MET dm on dm.DEC_MET_ID = 88 " _
            '  & " where f.ENUM_CAT = '" & p_EnumCat & "' and dm.DEC_MET_ID = " & p_dec_ID

            If p_EnumCat = "PATCH_COLOR" Then
                '++ID RENAMED FIELD BECAUSE I need only retrive color value
                strSql =
                 " select ID,user_def_fld_1 AS 'Enum_Cat' ,(Rtrim(Ltrim(user_def_fld_2)) + '-' + Ltrim(Rtrim(item_no))) AS 'ENUM_VALUE', item_no AS 'Enum_Sub_Cat'  from imitmidx_sql " &
                 " where item_no Like '%" & Trim(p_ITEM) & "%' "
            Else
                strSql =
                " select e.ID,e.Enum_Cat,e.Enum_Sub_Cat,E.ENUM_VALUE from MDB_CFG_ITEM_FLD f inner join mdb_cfg_enum e on f.ENUM_CAT = e.ENUM_CAT  " _
               & " where f.ENUM_CAT = '" & p_EnumCat & "'"
            End If




            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cCfgEnum
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadEnumCat = myList


        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Imp_Loc_VIEW." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#Region "-------- Public Properties ----------"
    Public Property Enum_ID As Int32
        Get
            Enum_ID = m_intId
        End Get
        Set(value As Int32)
            m_intId = value
        End Set
    End Property
    Public Property Enum_Cat As String
        Get
            Enum_Cat = m_strEnum_Cat
        End Get
        Set(value As String)
            m_strEnum_Cat = value
        End Set
    End Property
    Public Property Enum_Sub_Cat As String
        Get
            Enum_Sub_Cat = m_strEnumSubCat
        End Get
        Set(value As String)
            m_strEnumSubCat = value
        End Set
    End Property
    Public Property Enum_Value As String
        Get
            Enum_Value = m_strEnum_Value
        End Get
        Set(value As String)
            m_strEnum_Value = value
        End Set
    End Property
#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
