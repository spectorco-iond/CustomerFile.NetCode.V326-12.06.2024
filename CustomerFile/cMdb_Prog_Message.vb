Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Prog_Message


#Region "private variables #################################################" 


    private m_intProg_Message_Id As Int32
    Private m_intCus_Prog_Id As Int32
    private m_intMessage_Id As Int32
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################" 


    Public Sub New() 

        Try

            Call Init()

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(byval pProg_Message_Id As Int32) 

        Try

            Call Init()
            Call Load(pProg_Message_Id)

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################" 


    Private sub Init() 

        Try

                m_intProg_Message_Id = 0
            m_intCus_Prog_Id = 0
                m_intMessage_Id = 0
                m_strUser_Login = string.Empty
                m_dtUpdate_Ts = NoDate()

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub LoadLine(ByRef pdrRow As DataRow) 

        Try

            If Not (pdrRow.Item("Prog_Message_Id").Equals(DBNull.Value)) Then m_intProg_Message_Id = pdrRow.Item("Prog_Message_Id")
            If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then m_intCus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
            If Not (pdrRow.Item("Message_Id").Equals(DBNull.Value)) Then m_intMessage_Id = pdrRow.Item("Message_Id")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub SaveLine(ByRef pdrRow As DataRow) 

        Try

            pdrRow.Item("Prog_Message_Id") = m_intProg_Message_Id
            pdrRow.Item("Cus_Prog_Id") = m_intCus_Prog_Id
            pdrRow.Item("Message_Id") = m_intMessage_Id
            pdrRow.Item("User_Login") = m_strUser_Login
            If m_dtUpdate_Ts.Year <> 1 Then pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Prog_Message " & _
            "WHERE  Prog_Message_Id = " & m_intProg_Message_Id & " "

            db.Execute(strSql)

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Prog_Message WITH (Nolock) " & _
            "WHERE  Prog_Message_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Prog_Message " & _
            "WHERE  Prog_Message_Id = " & m_intProg_Message_Id & " "

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

        Catch ex as Exception
            MsgBox("Error in cMdb_Prog_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region 


#Region "Public properties ################################################" 

    Public Property Prog_Message_Id() As Int32
        Get
            Prog_Message_Id = m_intProg_Message_Id 
        End Get
        Set(ByVal value As Int32)
            m_intProg_Message_Id = value
        End Set
    End Property

    Public Property Cus_Prog_Id() As Int32
        Get
            Cus_Prog_Id = m_intCus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Id = value
        End Set
    End Property

    Public Property Message_Id() As Int32
        Get
            Message_Id = m_intMessage_Id 
        End Get
        Set(ByVal value As Int32)
            m_intMessage_Id = value
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


End Class ' cMdb_Prog_Message


