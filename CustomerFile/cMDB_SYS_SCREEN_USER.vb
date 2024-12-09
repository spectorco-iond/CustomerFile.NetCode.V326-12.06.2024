Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cMDB_SYS_Screen_Cd


#Region "private variables #################################################"


    Private m_intScreen_User_Id As Int32
    Private m_intScreen_Id As Int32
    Private m_strScreen_Cd As String
    Private m_strScreen_User As String
    Private m_strAccess_Type As String
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pScreen_User_Id As Int32)

        Try

            Call Init()
            Call Load(pScreen_User_Id)

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intScreen_User_Id = 0
            m_intScreen_Id = 0
            m_strScreen_Cd = String.Empty
            m_strScreen_User = String.Empty
            m_strAccess_Type = String.Empty
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Screen_User_Id").Equals(DBNull.Value)) Then m_intScreen_User_Id = pdrRow.Item("Screen_User_Id")
            If Not (pdrRow.Item("Screen_Id").Equals(DBNull.Value)) Then m_intScreen_Id = pdrRow.Item("Screen_Id")
            If Not (pdrRow.Item("Screen_Cd").Equals(DBNull.Value)) Then m_strScreen_Cd = pdrRow.Item("Screen_Cd").ToString
            If Not (pdrRow.Item("Screen_User").Equals(DBNull.Value)) Then m_strScreen_User = pdrRow.Item("Screen_User").ToString
            If Not (pdrRow.Item("Access_Type").Equals(DBNull.Value)) Then m_strAccess_Type = pdrRow.Item("Access_Type").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Screen_Id") = m_intScreen_Id
            pdrRow.Item("Screen_Cd") = m_strScreen_Cd
            pdrRow.Item("Screen_User") = m_strScreen_User
            pdrRow.Item("Access_Type") = m_strAccess_Type

            m_strUser_Login = Environment.UserName
            pdrRow.Item("User_Login") = m_strUser_Login

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM MDB_SYS_SCREEN_USER " & _
            "WHERE  Screen_User_Id = " & m_intScreen_User_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   MDB_SYS_SCREEN_USER WITH (Nolock) " & _
            "WHERE  Screen_User_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   MDB_SYS_SCREEN_USER " & _
            "WHERE  Screen_User_Id = " & m_intScreen_User_Id & " "

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

            If m_intScreen_Id = 0 Then m_intScreen_Id = db.DataTable("SELECT MAX(Screen_User_Id) AS Max_Screen_User_Id FROM MDB_SYS_SCREEN_USER WITH (Nolock) WHERE USER_LOGIN = '" & m_strUser_Login & "'").Rows(0).Item("Max_Screen_User_Id")

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Screen_User_Id() As Int32
        Get
            Screen_User_Id = m_intScreen_User_Id
        End Get
        Set(ByVal value As Int32)
            m_intScreen_User_Id = value
        End Set
    End Property

    Public Property Screen_Id() As Int32
        Get
            Screen_Id = m_intScreen_Id
        End Get
        Set(ByVal value As Int32)
            m_intScreen_Id = value
        End Set
    End Property

    Public Property Screen_Cd() As Int32
        Get
            Screen_Cd = m_strScreen_Cd
        End Get
        Set(ByVal value As Int32)
            m_strScreen_Cd = value
        End Set
    End Property

    Public Property Screen_User() As String
        Get
            Screen_User = m_strScreen_User
        End Get
        Set(ByVal value As String)
            m_strScreen_User = value
        End Set
    End Property

    Public Property Access_Type() As String
        Get
            Access_Type = m_strAccess_Type
        End Get
        Set(ByVal value As String)
            m_strAccess_Type = value
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

End Class
