Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Log_Quote_Step


#Region "private variables #################################################" 


    private m_intLog_Quote_Step_Id As Int32
    private m_intQuote_Id As Int32
    private m_intQuote_Step_Id As Int32
    private m_strQuote_State As String
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################" 


    Public Sub New() 

        Try

            Call Init()

        Catch ex as Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pLog_Quote_Step_Id As Int32)

        Try

            Call Init()
            Call Load(pLog_Quote_Step_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' This one creates a new quote log data and saves it.
    Public Sub New(ByVal pQuote_Id As Integer, ByVal pQuote_Step_Id As Integer)

        Try

            Call Init()
            m_intQuote_Id = pQuote_Id
            m_intQuote_Step_Id = pQuote_Step_Id

            Call SetQuoteState()

            Call Save()

        Catch ex As Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub



#End Region


#Region "Private maintenance procedures ###################################" 


    Private sub Init() 

        Try

                m_intLog_Quote_Step_Id = 0
                m_intQuote_Id = 0
                m_intQuote_Step_Id = 0
                m_strQuote_State = string.Empty
                m_strUser_Login = string.Empty
                m_dtUpdate_Ts = NoDate()

        Catch ex as Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub LoadLine(ByRef pdrRow As DataRow) 

        Try

            If Not (pdrRow.Item("Log_Quote_Step_Id").Equals(DBNull.Value)) Then m_intLog_Quote_Step_Id = pdrRow.Item("Log_Quote_Step_Id")
            If Not (pdrRow.Item("Quote_Id").Equals(DBNull.Value)) Then m_intQuote_Id = pdrRow.Item("Quote_Id")
            If Not (pdrRow.Item("Quote_Step_Id").Equals(DBNull.Value)) Then m_intQuote_Step_Id = pdrRow.Item("Quote_Step_Id")
            If Not (pdrRow.Item("Quote_State").Equals(DBNull.Value)) Then m_strQuote_State = pdrRow.Item("Quote_State").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex as Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub SaveLine(ByRef pdrRow As DataRow) 

        Try

            pdrRow.Item("Log_Quote_Step_Id") = m_intLog_Quote_Step_Id
            pdrRow.Item("Quote_Id") = m_intQuote_Id
            pdrRow.Item("Quote_Step_Id") = m_intQuote_Step_Id
            pdrRow.Item("Quote_State") = m_strQuote_State

            m_strUser_Login = Environment.UserName
            pdrRow.Item("User_Login") = m_strUser_Login

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex as Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region 


#Region "Private procedures ###############################################"

    Private Sub SetQuoteState()

        Try
            Dim db As New cDBA
            Dim dt As DataTable
            Dim strsql As String = _
            "SELECT		P.CUS_PROG_ID, P.CUS_NO, P.SPECTOR_CD, P.PROG_CD, P.PROG_DESC, " & _
            "			P.QUOTE_TYPE_ID, P.START_DT, P.END_DT, P.PROG_COMMENTS, " & _
            "			I.CUS_PROG_ITEM_LIST_ID, I.ITEM_CD, I.ITEM_NO, I.ITEM_DESC, I.ITEM_COLOR, I.MIN_QTY_ORD, I.UNIT_PRICE, I.EQP_LEVEL, I.EQP_PCT " & _
            "FROM		MDB_CUS_PROG P WITH (Nolock) " & _
            "INNER JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (nolock) ON P.CUS_PROG_ID = I.CUS_PROG_ID " & _
            "WHERE		P.CUS_PROG_ID = " & m_intQuote_Id.ToString & " " & _
            "" & _
            "FOR XML AUTO "

            dt = db.DataTable(strsql)
            If dt.Rows.Count <> 0 Then
                m_strQuote_State = dt.Rows(0).Item(0).ToString.Trim
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Log_Quote_Step " & _
            "WHERE  Log_Quote_Step_Id = " & m_intLog_Quote_Step_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Log_Quote_Step WITH (Nolock) " & _
            "WHERE  Log_Quote_Step_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Log_Quote_Step " & _
            "WHERE  Log_Quote_Step_Id = " & m_intLog_Quote_Step_Id & " "

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
            MsgBox("Error in cMdb_Log_Quote_Step." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Log_Quote_Step_Id() As Int32
        Get
            Log_Quote_Step_Id = m_intLog_Quote_Step_Id
        End Get
        Set(ByVal value As Int32)
            m_intLog_Quote_Step_Id = value
        End Set
    End Property

    Public Property Quote_Id() As Int32
        Get
            Quote_Id = m_intQuote_Id
        End Get
        Set(ByVal value As Int32)
            m_intQuote_Id = value
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

    Public Property Quote_State() As String
        Get
            Quote_State = m_strQuote_State
        End Get
        Set(ByVal value As String)
            m_strQuote_State = value
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


End Class ' cMdb_Log_Quote_Step


