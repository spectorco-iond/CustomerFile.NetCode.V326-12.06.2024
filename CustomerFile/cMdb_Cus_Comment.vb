Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cus_Comment


#Region "private variables #################################################"


    Private m_intCus_Comment_Id As Int32
    Private m_strCus_No As String
    Private m_strCus_Comment As String
    Private m_intComment_Type_ID As Int32
    Private m_intComment_Order As Int32
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Comment_Id As Int32)

        Try

            Call Init()
            Call Load(pCus_Comment_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCus_Comment_Id = 0
            m_strCus_No = String.Empty
            m_strCus_Comment = String.Empty
            m_intComment_Type_ID = 0
            m_intComment_Order = 0
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Comment_Id").Equals(DBNull.Value)) Then m_intCus_Comment_Id = pdrRow.Item("Cus_Comment_Id")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Cus_Comment").Equals(DBNull.Value)) Then m_strCus_Comment = pdrRow.Item("Cus_Comment").ToString
            If Not (pdrRow.Item("Comment_Type_ID").Equals(DBNull.Value)) Then m_intComment_Type_ID = pdrRow.Item("Comment_Type_ID")
            If Not (pdrRow.Item("Comment_Order").Equals(DBNull.Value)) Then m_intComment_Order = pdrRow.Item("Comment_Order")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Comment_Id") = m_intCus_Comment_Id
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Cus_Comment") = m_strCus_Comment
            pdrRow.Item("Comment_Type_ID") = m_intComment_Type_ID
            pdrRow.Item("Comment_Order") = m_intComment_Order

            m_strUser_Login = Environment.UserName
            m_dtUpdate_Ts = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            pdrRow.Item("Update_TS") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Comment " & _
            "WHERE  Cus_Comment_Id = " & m_intCus_Comment_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Comment WITH (Nolock) " & _
            "WHERE  Cus_Comment_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Comment " & _
            "WHERE  Cus_Comment_Id = " & m_intCus_Comment_Id & " "

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

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Cus_Comment_Id() As Int32
        Get
            Cus_Comment_Id = m_intCus_Comment_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Comment_Id = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Public Property Cus_Comment() As String
        Get
            Cus_Comment = m_strCus_Comment
        End Get
        Set(ByVal value As String)
            m_strCus_Comment = value
        End Set
    End Property

    Public Property Comment_Type_ID() As Int32
        Get
            Comment_Type_ID = m_intComment_Type_ID
        End Get
        Set(ByVal value As Int32)
            m_intComment_Type_ID = value
        End Set
    End Property

    Public Property Comment_Order() As Int32
        Get
            Comment_Order = m_intComment_Order
        End Get
        Set(ByVal value As Int32)
            m_intComment_Order = value
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

    Public Property Update_Ts() As DateTime
        Get
            Update_Ts = m_dtUpdate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_Ts = value
        End Set
    End Property

#End Region


End Class ' cMdb_Cus_Comment


