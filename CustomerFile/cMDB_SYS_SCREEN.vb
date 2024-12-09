Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cMDB_SYS_SCREEN


#Region "private variables #################################################"


    Private m_intScreen_Id As Int32
    Private m_strScreen_Cd As String
    Private m_strScreen_Desc As String
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime
    Private m_colFunc As New Collection

#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pScreen_Id As Int32)

        Try

            Call Init()
            Call Load(pScreen_Id)
            Call LoadFunc()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pScreen_Cd As String)

        Try

            Call Init()
            Call Load(pScreen_Cd)
            Call LoadFunc()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intScreen_Id = 0
            m_strScreen_Cd = String.Empty
            m_strScreen_Desc = String.Empty
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Screen_Id").Equals(DBNull.Value)) Then m_intScreen_Id = pdrRow.Item("Screen_Id")
            If Not (pdrRow.Item("Screen_Cd").Equals(DBNull.Value)) Then m_strScreen_Cd = pdrRow.Item("Screen_Cd").ToString
            If Not (pdrRow.Item("Screen_Desc").Equals(DBNull.Value)) Then m_strScreen_Desc = pdrRow.Item("Screen_Desc").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Screen_Id") = m_intScreen_Id
            pdrRow.Item("Screen_Cd") = m_strScreen_Cd
            pdrRow.Item("Screen_Desc") = m_strScreen_Desc

            m_strUser_Login = Environment.UserName
            pdrRow.Item("User_Login") = m_strUser_Login

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadFunc()

        Try
            If m_colFunc.Count <> 0 Then m_colFunc.Clear()

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT DISTINCT FUNC_NAME " & _
            "FROM   MDB_SYS_SCREEN_FUNC_USER WITH (Nolock) " & _
            "WHERE  Screen_Id = " & m_intScreen_Id & " "

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                For Each drRow As DataRow In dt.Rows
                    m_colFunc.Add(drRow.Item("FUNC_NAME").ToString.Trim, drRow.Item("FUNC_NAME").ToString.Trim)
                Next drRow
            End If

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM MDB_SYS_SCREEN " & _
            "WHERE  Screen_Id = " & m_intScreen_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   MDB_SYS_SCREEN WITH (Nolock) " & _
            "WHERE  Screen_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load(ByVal pScreen_Cd As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   MDB_SYS_SCREEN WITH (Nolock) " & _
            "WHERE  pScreen_Cd = '" & pScreen_Cd & "' "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   MDB_SYS_SCREEN " & _
            "WHERE  Screen_Id = " & m_intScreen_Id & " "

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

            If m_intScreen_Id = 0 Then m_intScreen_Id = db.DataTable("SELECT MAX(Screen_Id) AS Max_Screen_Id FROM MDB_SYS_SCREEN WITH (Nolock) WHERE USER_LOGIN = '" & m_strUser_Login & "'").Rows(0).Item("Max_Screen_Id")

        Catch ex As Exception
            MsgBox("Error in cMDB_SYS_SCREEN." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Screen_Id() As Int32
        Get
            Screen_Id = m_intScreen_Id
        End Get
        Set(ByVal value As Int32)
            m_intScreen_Id = value
        End Set
    End Property

    Public Property Screen_Cd() As String
        Get
            Screen_Cd = m_strScreen_Cd
        End Get
        Set(ByVal value As String)
            m_strScreen_Cd = value
        End Set
    End Property

    Public Property Screen_Desc() As String
        Get
            Screen_Desc = m_strScreen_Desc
        End Get
        Set(ByVal value As String)
            m_strScreen_Desc = value
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

    Public ReadOnly Property Func_Name() As Collection
        Get
            Func_Name = m_colFunc
        End Get
    End Property
#End Region


End Class
