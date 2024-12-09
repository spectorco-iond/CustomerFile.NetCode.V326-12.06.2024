Imports System.Data.Odbc

Public Class cReqRevision
    Implements ICloneable

    Private m_intReviewID As Integer
    Private m_intRequestId As Integer
    Private m_intRev_Cpt As Integer
    Private m_blRushOrder As Boolean
    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_dtCreateDate As Date
    Private m_strRevItemCd As String
    Private m_strOrigin As String

    Public Sub New()
        Call Init()

    End Sub

    Public Sub New(pinReqId As Integer, p_reviewId As Integer)
        Call Init()
        Call Load(pinReqId, p_reviewId)
    End Sub

#Region "--------------------------- Private Function ------------------------------"
    Private Sub Init()
        m_intReviewID = 0
        m_intRequestId = 0
        m_intRev_Cpt = 0
        m_blRushOrder = False
        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreateDate = Date.Now
        m_strRevItemCd = String.Empty
        m_strOrigin = String.Empty
    End Sub
    '---------------------
    'm_intReviewID
    '    m_intRequestId
    '    m_intRev_Cpt
    '    m_blRushOrder 
    '    m_intCreateBy
    '    m_strCreateByFullName 
    '    m_dtCreateDate 
    '------------------------
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            'If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then ReviewID = pdrRow.Item("ReviewID")
            'If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then RequestId = pdrRow.Item("RequestId")
            'If Not (pdrRow.Item("Rev_Cpt").Equals(DBNull.Value)) Then Rev_Cpt = pdrRow.Item("Rev_Cpt")
            'If Not (pdrRow.Item("Rush_Order").Equals(DBNull.Value)) Then Rush_Order = pdrRow.Item("Rush_Order")
            'If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then CreateBy = pdrRow.Item("CreateBy")
            'If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            'If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then CreateDate = pdrRow.Item("CreateDate").ToString

            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then m_intReviewID = pdrRow.Item("ReviewID")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("Rev_Cpt").Equals(DBNull.Value)) Then m_intRev_Cpt = pdrRow.Item("Rev_Cpt")
            If Not (pdrRow.Item("Rush_Order").Equals(DBNull.Value)) Then m_blRushOrder = pdrRow.Item("Rush_Order")
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("RevItemCd").Equals(DBNull.Value)) Then m_strRevItemCd = pdrRow.Item("RevItemCd").ToString
            If Not (pdrRow.Item("Origin").Equals(DBNull.Value)) Then m_strOrigin = pdrRow.Item("Origin").ToString
        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqRevision, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then pClass.ReviewID = pdrRow.Item("ReviewID")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("Rev_Cpt").Equals(DBNull.Value)) Then pClass.Rev_Cpt = pdrRow.Item("Rev_Cpt")
            If Not (pdrRow.Item("Rush_Order").Equals(DBNull.Value)) Then pClass.Rush_Order = pdrRow.Item("Rush_Order")
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("RevItemCd").Equals(DBNull.Value)) Then pClass.RevItemCd = pdrRow.Item("RevItemCd").ToString
            If Not (pdrRow.Item("Origin").Equals(DBNull.Value)) Then pClass.Origin = pdrRow.Item("Origin").ToString
        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try

            'pdrRow.Item("ReviewID") = m_intReviewID
            pdrRow.Item("RequestId") = m_intRequestId
            pdrRow.Item("Rev_Cpt") = m_intRev_Cpt
            pdrRow.Item("Rush_Order") = m_blRushOrder

            If m_intReviewID = 0 Then
                oExact_Traveler_Permission = New cExact_Traveler_Permission
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("RevItemCd") = m_strRevItemCd
            pdrRow.Item("Origin") = m_strOrigin

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqRevision, pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("ReviewID") = pClass.ReviewID
            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("Rev_Cpt") = pClass.Rev_Cpt
            pdrRow.Item("Rush_Order") = pClass.Rush_Order

            If pClass.ReviewID = 0 Then
                oExact_Traveler_Permission = New cExact_Traveler_Permission
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("RevItemCd") = pClass.RevItemCd
            pdrRow.Item("RevItemCd") = pClass.Origin

            'pdrRow.Item("CreateByFullName") = pClass.CreateByFullName
            'pdrRow.Item("CreateDate") = pClass.CreateDate

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
#Region "------------------------------- Public Function ------------------------------------"
    Public Function Load(strQuery As String) As Boolean
        Load = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              "SELECT * " &
              "FROM   ReqRevision WITH (Nolock) " & strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Load(ByVal pinReqId As Integer, ByVal pintID As Integer) As cReqRevision

        Load = New cReqRevision

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              "SELECT * " &
              "FROM   ReqRevision WITH (Nolock) " &
              "WHERE  ReviewID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

            Return Load

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReqRevision)

        LoadLst = New List(Of cReqRevision)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqRevision)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM ReqRevision WITH (Nolock) " & strQuery

            ' "WHERE RequestId = " & piRequestId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqRevision
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save(pClass As cReqRevision) As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String


            strSql =
                "SELECT * " &
                "FROM   ReqRevision " &
                "WHERE ReviewID = " & pClass.ReviewID & " " &
                "   AND RequestId = " & pClass.RequestId


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
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                "FROM   ReqRevision " &
                "WHERE ReviewID = " & ReviewID

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
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    'delete only specified version 
    Public Function Delete() As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
            " DELETE FROM ReqRevision " &
            " WHERE  ReviewID = " & m_intReviewID

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'delete all by request id
    Public Function Delete(revId As Integer) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
            " DELETE FROM ReqRevision " &
            " WHERE ReviewId = " & revId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqRevision." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#End Region
#Region "--------------------------- Public Properties -----------------------------------"
    Public Property ReviewID As Integer
        Get
            Return m_intReviewID
        End Get
        Set(value As Integer)
            m_intReviewID = value
        End Set
    End Property

    Public Property Rev_Cpt As Integer
        Get
            Return m_intRev_Cpt
        End Get
        Set(value As Integer)
            m_intRev_Cpt = value
        End Set
    End Property

    Public Property Rush_Order As Boolean
        Get
            Return m_blRushOrder
        End Get
        Set(value As Boolean)
            m_blRushOrder = value
        End Set
    End Property

    Public Property RequestId As Integer
        Get
            Return m_intRequestId
        End Get
        Set(value As Integer)
            m_intRequestId = value
        End Set
    End Property

    Public Property CreateDate As Date
        Get
            'm_dtCreateDate = DateNow()

            Return m_dtCreateDate
        End Get
        Set(value As Date)
            m_dtCreateDate = value
        End Set
    End Property

    Public Property CreateBy As Integer
        Get
            'oExact_Traveler_Permission = New cExact_Traveler_Permission
            'm_intCreateBy =oExact_Traveler_Permission.ID

            Return m_intCreateBy
        End Get
        Set(value As Integer)
            m_intCreateBy = value
        End Set
    End Property

    Public Property CreateByFullName As String
        Get
            'oExact_Traveler_Permission = New cExact_Traveler_Permission
            'm_strCreateByFullName = oExact_Traveler_Permission.Fullname

            Return m_strCreateByFullName
        End Get
        Set(value As String)
            m_strCreateByFullName = value
        End Set
    End Property
    Public Property RevItemCd As String
        Get
            Return m_strRevItemCd
        End Get
        Set(value As String)
            m_strRevItemCd = value
        End Set
    End Property
    Public Property Origin As String
        Get
            Return m_strOrigin
        End Get
        Set(value As String)
            m_strOrigin = value
        End Set
    End Property

#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
