Public Class cReqDocBindItem
    Implements ICloneable

    Private m_intBindId As Integer
    Private m_intReqItemId As Integer
    Private m_intDocId As Integer

    Private m_strGuid As String 'when object is added
    Private m_strItemGuid As String 'Item guid from grid or db, we need in the case when item from grid is not saved

    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_dtCreateDate As Date

    Private m_intModifyBy As Integer
    Private m_strModifyByFullname As String
    Private m_dtModifyDate As Date

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()
        m_intBindId = 0
        m_intReqItemId = 0
        m_intDocId = 0
        m_strGuid = System.Guid.NewGuid.ToString()   'when object is added
        m_strItemGuid = String.Empty '

        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreateDate = Date.Now

        m_intModifyBy = 0
        m_strModifyByFullname = String.Empty
        m_dtModifyDate = Date.Now
    End Sub

    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("BindId").Equals(DBNull.Value)) Then m_intBindId = pdrRow.Item("BindId")
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then m_intReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("DocId").Equals(DBNull.Value)) Then m_intDocId = pdrRow.Item("DocId")

            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then m_strGuid = pdrRow.Item("GUID").ToString
            If Not (pdrRow.Item("ItemGuid").Equals(DBNull.Value)) Then m_strItemGuid = pdrRow.Item("ItemGuid").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then m_intModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then m_strModifyByFullname = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then m_dtModifyDate = pdrRow.Item("ModifyDate").ToString


        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqDocBindItem, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("BindId").Equals(DBNull.Value)) Then pClass.BindId = pdrRow.Item("BindId")
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then pClass.ReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("DocId").Equals(DBNull.Value)) Then pClass.DocId = pdrRow.Item("DocId")

            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then pClass.Guid = pdrRow.Item("GUID").ToString
            If Not (pdrRow.Item("ItemGuid").Equals(DBNull.Value)) Then pClass.ItemGuid = pdrRow.Item("ItemGuid").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then pClass.ModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then pClass.ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then pClass.ModifyDate = pdrRow.Item("ModifyDate").ToString


        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("BindId") = m_intBindId
            pdrRow.Item("ReqItemId") = m_intReqItemId
            pdrRow.Item("DocId") = m_intDocId

            pdrRow.Item("GUID") = m_strGuid
            pdrRow.Item("ItemGuid") = m_strItemGuid

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If m_intBindId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqDocBindItem, pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("BindId") = m_intBindId
            pdrRow.Item("ReqItemId") = pClass.ReqItemId
            pdrRow.Item("DocId") = pClass.DocId

            pdrRow.Item("GUID") = pClass.Guid
            pdrRow.Item("ItemGuid") = pClass.ItemGuid

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If pClass.BindId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "---------------------------------- Public Function ----------------------------------"
    Public Function Load(strQuery As String) As cReqDocBindItem

        Load = New cReqDocBindItem

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = strQuery
            '" SELECT * " &
            '" FROM   ReqItems_AdditLocation WITH (Nolock) "


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReqDocBindItem)

        LoadLst = New List(Of cReqDocBindItem)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqDocBindItem)
            Dim i As Integer
            Dim strSql As String

            strSql = strQuery
            '  "SELECT * " &
            '  "FROM  " & strQuery

            '" WHERE  RequestId = " & pinReqId & " " &
            '  " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqDocBindItem
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadLst(ByVal pinAdditionalId As Integer) As List(Of cReqDocBindItem)

        LoadLst = New List(Of cReqDocBindItem)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqDocBindItem)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM  ReqDocBindItem WITH (Nolock) " &
              " WHERE  Additional_Id = " & pinAdditionalId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqDocBindItem
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save() As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   ReqDocBindItem " &
                " WHERE BindId = " & m_intBindId

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            Save = db.DBDataAdapter.Update(db.DBDataTable)

            If m_intBindId = 0 Then m_intBindId = db.DataTable("SELECT MAX(BindId) AS BindId FROM ReqDocBindItem WITH (Nolock)").Rows(0).Item("BindId")


        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Save(ByRef pClass As cReqDocBindItem) As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   ReqDocBindItem where BindId = " & pClass.BindId

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pClass, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    'Public Function Delete() As Boolean
    '    Delete = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql =
    '            "DELETE FROM ReqItems_AdditLocation  WHERE  Additional_Id = " & m_intAdditional_id

    '        db.Execute(strSql)

    '        Delete = True

    '    Catch ex As Exception
    '        MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Function
    Public Function Delete(ByRef pClass As cReqDocBindItem) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqDocBindItem " &
            " WHERE  BindId = " & pClass.BindId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'Public Function Delete(ByVal _Query As String) As Boolean
    '    Delete = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql =
    '            "DELETE FROM ReqDocBindItem " & _Query


    '        db.Execute(strSql)

    '        Delete = True

    '    Catch ex As Exception
    '        MsgBox("Error in cReqDocBindItem." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Function
#End Region


    Public Property BindId As Integer
        Get
            Return m_intBindId
        End Get
        Set(value As Integer)
            m_intBindId = value
        End Set
    End Property

    Public Property ReqItemId As Integer
        Get
            Return m_intReqItemId
        End Get
        Set(value As Integer)
            m_intReqItemId = value
        End Set
    End Property

    Public Property DocId As Integer
        Get
            Return m_intDocId
        End Get
        Set(value As Integer)
            m_intDocId = value
        End Set
    End Property
    Public Property Guid As String
        Get
            Return m_strGuid
        End Get
        Set(value As String)
            m_strGuid = value
        End Set
    End Property
    Public Property ItemGuid As String
        Get
            Return m_strItemGuid
        End Get
        Set(value As String)
            m_strItemGuid = value
        End Set
    End Property

    Public Property CreateBy As Integer
        Get
            Return m_intCreateBy
        End Get
        Set(value As Integer)
            m_intCreateBy = value
        End Set
    End Property

    Public Property CreateByFullName As String
        Get
            Return m_strCreateByFullName
        End Get
        Set(value As String)
            m_strCreateByFullName = value
        End Set
    End Property

    Public Property CreateDate As Date
        Get
            Return m_dtCreateDate
        End Get
        Set(value As Date)
            m_dtCreateDate = value
        End Set
    End Property

    Public Property ModifyBy As Integer
        Get
            Return m_intModifyBy
        End Get
        Set(value As Integer)
            m_intModifyBy = value
        End Set
    End Property

    Public Property ModifyByFullName As String
        Get
            Return m_strModifyByFullname
        End Get
        Set(value As String)
            m_strModifyByFullname = value
        End Set
    End Property

    Public Property ModifyDate As Date
        Get
            Return m_dtModifyDate
        End Get
        Set(value As Date)
            m_dtModifyDate = value
        End Set
    End Property
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
