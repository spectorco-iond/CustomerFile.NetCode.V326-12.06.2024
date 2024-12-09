Public Class cReqStatus
    Implements ICloneable

    Private intID As Integer
    Private intRequestId As Integer
    Private intReviewId As Integer
    Private intStatusId As Integer
    Private blActive As Boolean 
    Private intIntfield As Integer
    Private intIntfield1 As Integer
    Private strStrfield As String
    Private strStrfield1 As String
    Private intCreateBy As Integer
    Private strCreateByFullName As String
    Private dtCreateDate As Date
    Public Sub New()
        Call Init()
    End Sub


#Region "------------------------ Private Function ----------------------------------"
    Private Sub Init()
        intID = 0
        intRequestId = 0
        intReviewId = 0
        intStatusId = 0
        blActive = False
        'intIntfield = 0
        'intIntfield1 = 0
        'strStrfield = String.Empty
        'strStrfield1 = String.Empty
        intCreateBy = 0
        strCreateByFullName = String.Empty
        dtCreateDate = Date.Now
    End Sub
    '
    'intID 
    'intRequestId 
    'intReviewId 
    'intStatusId 
    'strActive
    'intIntfield 
    'intIntfield1 
    'strStrfield 
    'strStrfield1 
    'intCreateBy 
    'strCreateByFullName 
    'CreateDate 
    '
    'ID 
    'RequestId 
    'ReviewId 
    'StatusId 
    'Active
    'Intfield 
    'Intfield1 
    'Strfield 
    'Strfield1 
    'CreateBy 
    'CreateByFullName 
    'CreateDate 
    '
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then intID = pdrRow.Item("ID")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then intReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("StatusId").Equals(DBNull.Value)) Then intStatusId = pdrRow.Item("StatusId")
            If Not (pdrRow.Item("Active").Equals(DBNull.Value)) Then blActive = pdrRow.Item("Active")
            'If Not (pdrRow.Item("Intfield").Equals(DBNull.Value)) Then intIntfield = pdrRow.Item("Intfield")
            'If Not (pdrRow.Item("Intfield1").Equals(DBNull.Value)) Then intIntfield1 = pdrRow.Item("Intfield1")
            'If Not (pdrRow.Item("Strfield").Equals(DBNull.Value)) Then strStrfield = pdrRow.Item("Strfield")
            'If Not (pdrRow.Item("Strfield1").Equals(DBNull.Value)) Then strStrfield1 = pdrRow.Item("Strfield1")
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then dtCreateDate = pdrRow.Item("CreateDate").ToString

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqStatus, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then pClass.ID = pdrRow.Item("ID")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then pClass.ReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("StatusId").Equals(DBNull.Value)) Then pClass.StatusId = pdrRow.Item("StatusId")
            If Not (pdrRow.Item("Active").Equals(DBNull.Value)) Then pClass.Active = pdrRow.Item("Active")
            'If Not (pdrRow.Item("Intfield").Equals(DBNull.Value)) Then pClass.intfield = pdrRow.Item("Intfield")
            'If Not (pdrRow.Item("Intfield1").Equals(DBNull.Value)) Then pClass.intfield1 = pdrRow.Item("Intfield1")
            'If Not (pdrRow.Item("Strfield").Equals(DBNull.Value)) Then pClass.strfield = pdrRow.Item("Strfield").ToString
            'If Not (pdrRow.Item("Strfield1").Equals(DBNull.Value)) Then pClass.strfield1 = pdrRow.Item("Strfield1").ToString
            'If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            '   pdrRow.Item("ID") = intID
            pdrRow.Item("RequestId") = intRequestId
            pdrRow.Item("ReviewId") = intReviewId
            pdrRow.Item("StatusId") = intStatusId
            pdrRow.Item("Active") = blActive
            'pdrRow.Item("Intfield") = intIntfield
            'pdrRow.Item("Intfield1") = intIntfield1
            'pdrRow.Item("Strfield") = strStrfield
            'pdrRow.Item("Strfield1") = strStrfield1

            oExact_Traveler_Permission = New cExact_Traveler_Permission
            pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
            pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
            pdrRow.Item("CreateDate") = DateNow()


        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqStatus, pdrRow As System.Data.DataRow)
        Try
            '  pdrRow.Item("ID") = pClass.ID
            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("ReviewId") = pClass.ReviewId
            pdrRow.Item("StatusId") = pClass.StatusId
            pdrRow.Item("Active") = pClass.Active
            'pdrRow.Item("Intfield") = pClass.intfield
            'pdrRow.Item("Intfield1") = pClass.intfield1
            'pdrRow.Item("Strfield") = pClass.strfield
            'pdrRow.Item("Strfield1") = pClass.strfield1
            pdrRow.Item("CreateBy") = pClass.CreateBy
            pdrRow.Item("CreateByFullName") = pClass.CreateByFullName
            pdrRow.Item("CreateDate") = pClass.CreateDate

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
#Region "---------------------------- Public Function --------------------------------------"
    Public Function Load(ByVal pinReqId As Integer, ByVal pintReviewID As Integer) As Boolean
        Load = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              " SELECT ID,RequestId,ReviewId,StatusId,Active,CreateBy,CreateByFullName,CreateDate " &
              " FROM   ReqStatus WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId & " " &
              " and reviewId = " & pintReviewID & " and Active = 1 "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                   Load = true
            End If

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(ByVal pinReqId As Integer, ByVal pintReviewID As Integer) As List(Of cReqStatus)

        LoadLst = New List(Of cReqStatus)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqStatus)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT ID,RequestId,ReviewId,StatusId,Active,CreateBy,CreateByFullName,CreateDate " _
           & "FROM ReqStatus WITH (Nolock) " _
           & " WHERE  RequestId = " & pinReqId & " " _
           & " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqStatus
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReqStatus)
        LoadLst = New List(Of cReqStatus)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqStatus)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT  ID,RequestId,ReviewId,StatusId,Active,CreateBy,CreateByFullName,CreateDate " _
           & "FROM ReqStatus WITH (Nolock) " & strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqStatus
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                "SELECT  ID,RequestId,ReviewId,StatusId,Active,CreateBy,CreateByFullName,CreateDate " _
              & " FROM   ReqStatus  WHERE ReviewID = " & intReviewId & " " _
              & " AND RequestId = " & intRequestId & " and StatusId = " & intStatusId

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

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Save(pClass As cReqStatus) As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
            "SELECT  ID,RequestId,ReviewId,StatusId,Active,CreateBy,CreateByFullName,CreateDate " _
              & " FROM   ReqStatus " _
              & " WHERE ReviewID = " & pClass.ReviewId & " " _
              & " AND RequestId = " & pClass.RequestId

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

            Save = db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Delete() As Boolean
        Delete = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqStatus " &
            "WHERE  ID = " & intID

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete(pintID As Integer) As Boolean
        Delete = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
                "DELETE FROM ReqStatus " &
            "WHERE  ID = " & pintID & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "-------------------------------- Public Properties -------------------------------"

    Public Property ID As Integer
        Get
            Return intID
        End Get
        Set(value As Integer)
            intID = value
        End Set
    End Property

    Public Property RequestId As Integer
        Get
            Return intRequestId
        End Get
        Set(value As Integer)
            intRequestId = value
        End Set
    End Property

    Public Property ReviewId As Integer
        Get
            Return intReviewId
        End Get
        Set(value As Integer)
            intReviewId = value
        End Set
    End Property

    Public Property StatusId As Integer
        Get
            Return intStatusId
        End Get
        Set(value As Integer)
            intStatusId = value
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return blActive
        End Get
        Set(value As Boolean)
            blActive = value
        End Set
    End Property

    Public Property intfield As Integer
        Get
            Return intIntfield
        End Get
        Set(value As Integer)
            intIntfield = value
        End Set
    End Property

    Public Property intfield1 As Integer
        Get
            Return intIntfield1
        End Get
        Set(value As Integer)
            intIntfield1 = value
        End Set
    End Property

    Public Property strfield As String
        Get
            Return strStrfield
        End Get
        Set(value As String)
            strStrfield = value
        End Set
    End Property

    Public Property strfield1 As String
        Get
            Return strStrfield1
        End Get
        Set(value As String)
            strStrfield1 = value
        End Set
    End Property

    Public Property CreateBy As Integer
        Get
            Return intCreateBy
        End Get
        Set(value As Integer)
            intCreateBy = value
        End Set
    End Property

    Public Property CreateByFullName As String
        Get
            Return strCreateByFullName
        End Get
        Set(value As String)
            strCreateByFullName = value
        End Set
    End Property

    Public Property CreateDate As Date
        Get
            Return dtCreateDate
        End Get
        Set(value As Date)
            dtCreateDate = value
        End Set
    End Property
#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
