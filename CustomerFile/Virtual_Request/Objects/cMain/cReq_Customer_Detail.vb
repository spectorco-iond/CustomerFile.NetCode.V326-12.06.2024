Imports System.Data.Odbc

Public Class cReq_Customer_Detail
    Implements ICloneable

    Private m_intCusId As Integer
    Private m_strCmp_wwn As String
    Private m_strCnt_id As String
    Private m_intCreateBy As Integer
    Private m_strCreateByFullname As String
    Private m_dtCreateDate As Date
    Private m_intModifyBy As Integer
    Private m_strModifyByFullName As String
    Private m_dtModifyDate As Date
    Private m_intRequestId As Integer
    Private m_intReviewId As Integer


    Public Sub New()
        Call Init()
    End Sub
    Public Sub New(strQuery As String)

        Call Init()
        Call Load(strQuery)
    End Sub

    Public Sub New(requestId As Integer, reviewId As Integer)
        Call Init()
        Call Load(requestId, reviewId)
    End Sub

#Region "----------------------------- Private Function ------------------------------------"
    Private Sub Init()
        m_intCusId = 0
        m_strCmp_wwn = String.Empty
        m_strCnt_id = String.Empty
        m_intCreateBy = 0
        m_strCreateByFullname = String.Empty
        m_dtCreateDate = Date.Now
        m_intModifyBy = 0
        m_strModifyByFullName = String.Empty
        m_dtModifyDate = Date.Now
        m_intRequestId = 0
        m_intReviewId = 0
    End Sub
    '-----------------
    'm_intId 
    '   m_strCmp_wwn 
    '   m_strCnt_id 
    '   m_intCreateBy 
    '   m_strCreateByFullname 
    '   m_dtCreateDate
    '   m_intModifiedBy 
    '   m_strModifiedByFullName 
    '   m_dtModifiedDate
    '   m_intRequestId 
    '   m_intReviewId 
    '-----------------
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("CusID").Equals(DBNull.Value)) Then m_intCusId = pdrRow.Item("CusID")
            If Not (pdrRow.Item("cmp_wwn").Equals(DBNull.Value)) Then m_strCmp_wwn = pdrRow.Item("cmp_wwn").ToString
            If Not (pdrRow.Item("cnt_id").Equals(DBNull.Value)) Then m_strCnt_id = pdrRow.Item("cnt_id").ToString
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullname = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then m_intModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then m_strModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then m_dtModifyDate = pdrRow.Item("ModifyDate").ToString
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then m_intReviewId = pdrRow.Item("ReviewID")

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cReq_Customer_Detail, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("CusID").Equals(DBNull.Value)) Then pClass.CusID = pdrRow.Item("CusID")
            If Not (pdrRow.Item("cmp_wwn").Equals(DBNull.Value)) Then pClass.cmp_wwn = pdrRow.Item("cmp_wwn").ToString
            If Not (pdrRow.Item("cnt_id").Equals(DBNull.Value)) Then pClass.cnt_id = pdrRow.Item("cnt_id")
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then pClass.ModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then pClass.ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then pClass.ModifyDate = pdrRow.Item("ModifyDate").ToString
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewID").Equals(DBNull.Value)) Then pClass.ReviewID = pdrRow.Item("ReviewID")

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("CusID") = CusID

            If Not (pdrRow.Item("CusID").Equals(DBNull.Value)) Then m_intCusId = pdrRow.Item("CusID")

            pdrRow.Item("cmp_wwn") = m_strCmp_wwn
            pdrRow.Item("cnt_id") = m_strCnt_id

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If m_intCusId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("RequestId") = RequestId
            pdrRow.Item("ReviewID") = ReviewID

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReq_Customer_Detail, pdrRow As System.Data.DataRow)
        Try
            ' pdrRow.Item("CusID") = pClass.CusID
            pdrRow.Item("cmp_wwn") = pClass.cmp_wwn
            pdrRow.Item("cnt_id") = pClass.cnt_id

            If Not (pdrRow.Item("CusID").Equals(DBNull.Value)) Then pClass.CusID = pdrRow.Item("CusID")
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If pClass.CusID > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("ReviewID") = pClass.ReviewID

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region "-------------------------------- Public Function ------------------------------"
    Public Function Load(reqSql As String) As Boolean
        Load = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              " SELECT * " &
              " FROM   Req_Customer_Detail WITH (Nolock) " & reqSql


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Load(ByVal pinReqId As Integer, ByVal pintReviewID As Integer) As cReq_Customer_Detail

        Load = New cReq_Customer_Detail

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              " SELECT * " &
              " FROM   Req_Customer_Detail WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId & " " &
              " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReq_Customer_Detail)
        LoadLst = New List(Of cReq_Customer_Detail)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReq_Customer_Detail)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM ReqRevision WITH (Nolock) " & strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReq_Customer_Detail
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadLst(ByVal pinReqId As Integer) As List(Of cReq_Customer_Detail)
        LoadLst = New List(Of cReq_Customer_Detail)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReq_Customer_Detail)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM Req_Customer_Detail WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReq_Customer_Detail
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                "SELECT * " _
               & " FROM   Req_Customer_Detail " _
               & " WHERE ReviewID = " & m_intReviewId _
               & " AND RequestId = " & m_intRequestId

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
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Save(pClass As cReq_Customer_Detail) As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   Req_Customer_Detail " &
                " WHERE ReviewID = " & pClass.ReviewID & " " &
                " AND RequestId = " & pClass.RequestId

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
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Delete(pintID As Integer) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM Req_Customer_Detail " &
            "WHERE  cusID = " & pintID & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete() As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM Req_Customer_Detail " &
            "WHERE  cusID = " & m_intCusId & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReq_Customer_Detail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region

#Region "----------------------------- Public properties -----------------------------"
    Public Property CusID As Integer
        Get
            Return m_intCusId
        End Get
        Set(value As Integer)
            m_intCusId = value
        End Set
    End Property

    Public Property cmp_wwn As String
        Get
            Return m_strCmp_wwn
        End Get
        Set(value As String)
            m_strCmp_wwn = value
        End Set
    End Property

    Public Property cnt_id As String
        Get
            Return m_strCnt_id
        End Get
        Set(value As String)
            m_strCnt_id = value
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
            Return m_strCreateByFullname
        End Get
        Set(value As String)
            m_strCreateByFullname = value
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
            Return m_strModifyByFullName
        End Get
        Set(value As String)
            m_strModifyByFullName = value
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
#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
