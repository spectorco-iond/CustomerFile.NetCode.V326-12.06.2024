Public Class cReqSentMails
    Implements ICloneable

    Private m_intReqSentId As Integer
    Private m_intRequestId As Integer
    Private m_intReviewId As Integer
    ' Private m_intTypeId As Integer
    '  Private m_intOrderBy As Integer
    Private m_strHTMLdata As String
    Private m_strSentTo As String
    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_dtCreateDate As Date


    Sub New()
        Init()
    End Sub

    Sub New(motherId As Integer)
        Init()
    End Sub

    Sub New(motherId As Integer, reviewId As Integer)
        Init()
    End Sub

#Region "-------------------------------------- Private Function --------------------------------------------"
    Private Sub Init()
        m_intReqSentId = 0
        m_intRequestId = 0
        m_intReviewId = 0
        m_strSentTo = String.Empty
        'm_intTypeId = 0
        'm_intOrderBy = 0
        m_strHTMLdata = String.Empty
        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreateDate = Date.Now

    End Sub
    '---------------------------------
    'm_intReqSentId
    'm_intRequestId
    'm_intReviewId
    'm_intTypeId
    'm_intOrderBy
    'm_strHTMLdata
    'm_intCreateBy
    'm_strCreateByFullName
    'm_dtCreateDate
    '----------------------------------
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ReqSentId").Equals(DBNull.Value)) Then m_intReqSentId = pdrRow.Item("ReqSentId")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then m_intReviewId = pdrRow.Item("ReviewID")

            If Not (pdrRow.Item("sentTo").Equals(DBNull.Value)) Then m_strSentTo = pdrRow.Item("sentTo").ToString
            If Not (pdrRow.Item("HTMLdata").Equals(DBNull.Value)) Then m_strHTMLdata = pdrRow.Item("HTMLdata").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqSentMails, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ReqSentId").Equals(DBNull.Value)) Then pClass.ReqSentId = pdrRow.Item("ReqSentId")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then pClass.ReviewID = pdrRow.Item("ReviewID")
            'If Not (pdrRow.Item("TypeId").Equals(DBNull.Value)) Then pClass.TypeId = pdrRow.Item("TypeId")
            'If Not (pdrRow.Item("OrderBy").Equals(DBNull.Value)) Then pClass.OrderBy = pdrRow.Item("OrderBy")
            If Not (pdrRow.Item("HTMLdata").Equals(DBNull.Value)) Then pClass.HTMLdata = pdrRow.Item("HTMLdata").ToString
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("sentTo").Equals(DBNull.Value)) Then pClass.SentTo = pdrRow.Item("sentTo").ToString
        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            '   pdrRow.Item("ReqSentId") = m_intReqSentId
            pdrRow.Item("RequestId") = m_intRequestId
            pdrRow.Item("ReviewID") = m_intReviewId

            pdrRow.Item("sentTo") = m_strSentTo
            pdrRow.Item("HTMLdata") = m_strHTMLdata

            oExact_Traveler_Permission = New cExact_Traveler_Permission
            pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
            pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
            pdrRow.Item("CreateDate") = DateNow()

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqSentMails, pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("ReqSentId") = pClass.ReqSentId
            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("ReviewID") = pClass.ReviewID
            pdrRow.Item("sentTo") = pClass.SentTo

            pdrRow.Item("HTMLdata") = pClass.HTMLdata

            oExact_Traveler_Permission = New cExact_Traveler_Permission
            pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
            pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
            pdrRow.Item("CreateDate") = DateNow()

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region "-------------------------------- Public Function -------------------------------------"
    Public Function Load(ByVal pinReqId As Integer, ByVal pintReviewID As Integer) As cReqSentMails

        Load = New cReqSentMails

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              " SELECT * " &
              " FROM   ReqSentMails WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId & " " &
              " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    'load comunication by requestId and reviewId more filtering
    Public Function LoadLst(strQuery As String) As List(Of cReqSentMails)

        LoadLst = New List(Of cReqSentMails)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqSentMails)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM ReqSentMails WITH (Nolock) " & strQuery


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqSentMails
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'load all comunication by request
    Public Function LoadLst(ByVal pinReqId As Integer) As List(Of cReqSentMails)
        LoadLst = New List(Of cReqSentMails)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqSentMails)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM ReqSentMails WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqSentMails
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                " FROM  ReqSentMails where ReqSentId = " & m_intReqSentId

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
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Save(pClass As cReqSentMails) As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   ReqSentMails " &
                " WHERE ReqSentId = " & pClass.ReqSentId


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
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Delete() As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqSentMails " &
           " WHERE  ReqSentId = " & m_intReqSentId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete(obj As cReqSentMails) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                " DELETE FROM ReqSentMails " &
            "WHERE  ReqSentId = " & obj.ReqSentId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqSentMails." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region


#Region "------------------------------- Public Properties ----------------------------------"

    Public Property ReqSentId As Integer
        Get
            Return m_intReqSentId
        End Get
        Set(value As Integer)
            m_intReqSentId = value
        End Set
    End Property

    'Public Property TypeId As Integer
    '    Get
    '        Return m_intTypeId
    '    End Get
    '    Set(value As Integer)
    '        m_intTypeId = value
    '    End Set
    'End Property

    'Public Property OrderBy As Integer
    '    Get
    '        Return m_intOrderBy
    '    End Get
    '    Set(value As Integer)
    '        m_intOrderBy = value
    '    End Set
    'End Property

    Public Property RequestId As Integer
        Get
            Return m_intRequestId
        End Get
        Set(value As Integer)
            m_intRequestId = value
        End Set
    End Property

    Public Property ReviewID As Integer
        Get
            Return m_intReviewId
        End Get
        Set(value As Integer)
            m_intReviewId = value
        End Set
    End Property

    Public Property HTMLdata As String
        Get
            Return m_strHTMLdata
        End Get
        Set(value As String)
            m_strHTMLdata = value
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
    Public Property SentTo As String
        Get
            Return m_strSentTo
        End Get
        Set(value As String)
            m_strSentTo = value
        End Set
    End Property
#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
