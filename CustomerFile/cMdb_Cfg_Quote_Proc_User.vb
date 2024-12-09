Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cfg_Quote_Proc_User


#Region "private variables #################################################" 


    private m_intQuote_Proc_User_Id As Int32
    private m_intQuote_Type_Id As Int32
    private m_intQuote_Step_Id As Int32
    private m_strScreen_User As String
    private m_blnUser_Receive_Mail_On_Step As Boolean
    private m_blnCsr_Receive_Mail_On_Step As Boolean
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################" 


    Public Sub New() 

        Try

            Call Init()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(byval pQuote_Proc_User_Id As Int32) 

        Try

            Call Init()
            Call Load(pQuote_Proc_User_Id)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################" 


    Private sub Init() 

        Try

                m_intQuote_Proc_User_Id = 0
                m_intQuote_Type_Id = 0
                m_intQuote_Step_Id = 0
                m_strScreen_User = string.Empty
                m_blnUser_Receive_Mail_On_Step = false
                m_blnCsr_Receive_Mail_On_Step = false
                m_strUser_Login = string.Empty
                m_dtUpdate_Ts = NoDate()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub LoadLine(ByRef pdrRow As DataRow) 

        Try

            If Not (pdrRow.Item("Quote_Proc_User_Id").Equals(DBNull.Value)) Then m_intQuote_Proc_User_Id = pdrRow.Item("Quote_Proc_User_Id")
            If Not (pdrRow.Item("Quote_Type_Id").Equals(DBNull.Value)) Then m_intQuote_Type_Id = pdrRow.Item("Quote_Type_Id")
            If Not (pdrRow.Item("Quote_Step_Id").Equals(DBNull.Value)) Then m_intQuote_Step_Id = pdrRow.Item("Quote_Step_Id")
            If Not (pdrRow.Item("Screen_User").Equals(DBNull.Value)) Then m_strScreen_User = pdrRow.Item("Screen_User").ToString
            If Not (pdrRow.Item("User_Receive_Mail_On_Step").Equals(DBNull.Value)) Then m_blnUser_Receive_Mail_On_Step = pdrRow.Item("User_Receive_Mail_On_Step")
            If Not (pdrRow.Item("Csr_Receive_Mail_On_Step").Equals(DBNull.Value)) Then m_blnCsr_Receive_Mail_On_Step = pdrRow.Item("Csr_Receive_Mail_On_Step")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub SaveLine(ByRef pdrRow As DataRow) 

        Try

            pdrRow.Item("Quote_Proc_User_Id") = m_intQuote_Proc_User_Id
            pdrRow.Item("Quote_Type_Id") = m_intQuote_Type_Id
            pdrRow.Item("Quote_Step_Id") = m_intQuote_Step_Id
            pdrRow.Item("Screen_User") = m_strScreen_User
            pdrRow.Item("User_Receive_Mail_On_Step") = m_blnUser_Receive_Mail_On_Step
            pdrRow.Item("Csr_Receive_Mail_On_Step") = m_blnCsr_Receive_Mail_On_Step

            m_strUser_Login = Environment.UserName
            pdrRow.Item("User_Login") = m_strUser_Login

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Cfg_Quote_Proc_User " & _
            "WHERE  Quote_Proc_User_Id = " & m_intQuote_Proc_User_Id & " "

            db.Execute(strSql)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Quote_Proc_User WITH (Nolock) " & _
            "WHERE  Quote_Proc_User_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Cfg_Quote_Proc_User " & _
            "WHERE  Quote_Proc_User_Id = " & m_intQuote_Proc_User_Id & " "

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
            MsgBox("Error in cMdb_Cfg_Quote_Proc_User." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region 


#Region "Public properties ################################################" 

    Public Property Quote_Proc_User_Id() As Int32
        Get
            Quote_Proc_User_Id = m_intQuote_Proc_User_Id 
        End Get
        Set(ByVal value As Int32)
            m_intQuote_Proc_User_Id = value
        End Set
    End Property

    Public Property Quote_Type_Id() As Int32
        Get
            Quote_Type_Id = m_intQuote_Type_Id 
        End Get
        Set(ByVal value As Int32)
            m_intQuote_Type_Id = value
        End Set
    End Property

    Public Property Quote_Step_Id() As Int32
        Get
            Quote_Step_Id = m_intQuote_Step_Id 
        End Get
        Set(ByVal value As Int32)
            m_intQuote_Step_Id = value
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

    Public Property User_Receive_Mail_On_Step() As Boolean
        Get
            User_Receive_Mail_On_Step = m_blnUser_Receive_Mail_On_Step 
        End Get
        Set(ByVal value As Boolean)
            m_blnUser_Receive_Mail_On_Step = value
        End Set
    End Property

    Public Property Csr_Receive_Mail_On_Step() As Boolean
        Get
            Csr_Receive_Mail_On_Step = m_blnCsr_Receive_Mail_On_Step 
        End Get
        Set(ByVal value As Boolean)
            m_blnCsr_Receive_Mail_On_Step = value
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


End Class ' cMdb_Cfg_Quote_Proc_User


