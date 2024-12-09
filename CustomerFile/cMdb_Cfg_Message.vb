Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cfg_Message


#Region "private variables #################################################" 


    private m_intMessage_Id As Int32
    private m_strMsg_Group As String
    private m_intMsg_Order As Int32
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################" 


    Public Sub New() 

        Try

            Call Init()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(byval pMessage_Id As Int32) 

        Try

            Call Init()
            Call Load(pMessage_Id)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################" 


    Private sub Init() 

        Try

                m_intMessage_Id = 0
                m_strMsg_Group = string.Empty
                m_intMsg_Order = 0
                m_strUser_Login = string.Empty
                m_dtUpdate_Ts = NoDate()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub LoadLine(ByRef pdrRow As DataRow) 

        Try

            If Not (pdrRow.Item("Message_Id").Equals(DBNull.Value)) Then m_intMessage_Id = pdrRow.Item("Message_Id")
            If Not (pdrRow.Item("Msg_Group").Equals(DBNull.Value)) Then m_strMsg_Group = pdrRow.Item("Msg_Group").ToString
            If Not (pdrRow.Item("Msg_Order").Equals(DBNull.Value)) Then m_intMsg_Order = pdrRow.Item("Msg_Order")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub SaveLine(ByRef pdrRow As DataRow) 

        Try

             pdrRow.Item("Message_Id") = m_intMessage_Id 
             pdrRow.Item("Msg_Group") = m_strMsg_Group 
             pdrRow.Item("Msg_Order") = m_intMsg_Order 
             pdrRow.Item("User_Login") = m_strUser_Login 
            if m_dtUpdate_Ts.Year <> 1 Then pdrRow.Item("Update_Ts") = m_dtUpdate_Ts  

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Cfg_Message " & _
            "WHERE  Message_Id = " & m_intMessage_Id & " "

            db.Execute(strSql)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Message WITH (Nolock) " & _
            "WHERE  Message_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Cfg_Message " & _
            "WHERE  Message_Id = " & m_intMessage_Id & " "

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
            MsgBox("Error in cMdb_Cfg_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region 


#Region "Public properties ################################################" 

    Public Property Message_Id() As Int32
        Get
            Message_Id = m_intMessage_Id 
        End Get
        Set(ByVal value As Int32)
            m_intMessage_Id = value
        End Set
    End Property

    Public Property Msg_Group() As String
        Get
            Msg_Group = m_strMsg_Group 
        End Get
        Set(ByVal value As String)
            m_strMsg_Group = value
        End Set
    End Property

    Public Property Msg_Order() As Int32
        Get
            Msg_Order = m_intMsg_Order 
        End Get
        Set(ByVal value As Int32)
            m_intMsg_Order = value
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


End Class ' cMdb_Cfg_Message


