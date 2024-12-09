Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cus_Push_Order


#Region "private variables #################################################"


    Private m_intCus_Push_Order_Id As Int32
    Private m_strCus_No As String
    Private m_strOrd_No As String
    Private m_dtPush_Date As DateTime
    Private m_strOrd_Comment As String
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Push_Order_Id As Int32)

        Try

            Call Init()
            Call Load(pCus_Push_Order_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCus_Push_Order_Id = 0
            m_strCus_No = String.Empty
            m_strOrd_No = String.Empty
            m_dtPush_Date = NoDate()
            m_strOrd_Comment = String.Empty
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Push_Order_Id").Equals(DBNull.Value)) Then m_intCus_Push_Order_Id = pdrRow.Item("Cus_Push_Order_Id")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("Push_Date").Equals(DBNull.Value)) Then m_dtPush_Date = pdrRow.Item("Push_Date")
            If Not (pdrRow.Item("Ord_Comment").Equals(DBNull.Value)) Then m_strOrd_Comment = pdrRow.Item("Ord_Comment").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Push_Order_Id") = m_intCus_Push_Order_Id
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Ord_No") = m_strOrd_No
            If m_dtPush_Date.Year <> 1 Then pdrRow.Item("Push_Date") = m_dtPush_Date
            pdrRow.Item("Ord_Comment") = m_strOrd_Comment

            m_strUser_Login = Environment.UserName
            m_dtUpdate_Ts = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            If m_dtUpdate_Ts.Year <> 1 Then pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Cus_Push_Order " & _
            "WHERE  Cus_Push_Order_Id = " & m_intCus_Push_Order_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Push_Order WITH (Nolock) " & _
            "WHERE  Cus_Push_Order_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Cus_Push_Order " & _
            "WHERE  Cus_Push_Order_Id = " & m_intCus_Push_Order_Id & " "

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

            If m_intCus_Push_Order_Id = 0 Then m_intCus_Push_Order_Id = db.DataTable("SELECT MAX(Cus_Push_Order_Id) AS Max_Cus_Push_Order_ID FROM MDB_Cus_Push_Order WITH (Nolock)").Rows(0).Item("Max_Cus_Push_Order_Id")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Push_Order." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Cus_Push_Order_Id() As Int32
        Get
            Cus_Push_Order_Id = m_intCus_Push_Order_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Push_Order_Id = value
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

    Public Property Ord_No() As String
        Get
            Ord_No = m_strOrd_No
        End Get
        Set(ByVal value As String)
            m_strOrd_No = value
        End Set
    End Property

    Public Property Push_Date() As DateTime
        Get
            Push_Date = m_dtPush_Date
        End Get
        Set(ByVal value As DateTime)
            m_dtPush_Date = value
        End Set
    End Property

    Public Property Ord_Comment() As String
        Get
            Ord_Comment = m_strOrd_Comment
        End Get
        Set(ByVal value As String)
            m_strOrd_Comment = value
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


End Class ' cMdb_Cus_Push_Order


