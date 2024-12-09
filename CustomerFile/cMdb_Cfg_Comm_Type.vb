Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cfg_Comm_Type


#Region "private variables #################################################" 


    Private m_intComm_Type_Id As Int32 = 0
    private m_strComm_Desc As String
    private m_intComm_Order As Int32
    private m_strUser_Login As String
    private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################" 


    Public Sub New() 

        Try

            Call Init()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(byval pComm_Type_Id As Int32) 

        Try

            Call Init()
            Call Load(pComm_Type_Id)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################" 


    Private sub Init() 

        Try

            m_intComm_Type_Id = 0
            m_strComm_Desc = String.Empty
            m_intComm_Order = 0
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub LoadLine(ByRef pdrRow As DataRow) 

        Try

            If Not (pdrRow.Item("Comm_Type_Id").Equals(DBNull.Value)) Then m_intComm_Type_Id = pdrRow.Item("Comm_Type_Id")
            If Not (pdrRow.Item("Comm_Desc").Equals(DBNull.Value)) Then m_strComm_Desc = pdrRow.Item("Comm_Desc").ToString
            If Not (pdrRow.Item("Comm_Order").Equals(DBNull.Value)) Then m_intComm_Order = pdrRow.Item("Comm_Order")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private sub SaveLine(ByRef pdrRow As DataRow) 

        Try

            'pdrRow.Item("Comm_Type_Id") = m_intComm_Type_Id 
             pdrRow.Item("Comm_Desc") = m_strComm_Desc 
             pdrRow.Item("Comm_Order") = m_intComm_Order 

            m_strUser_Login = Environment.UserName
            m_dtUpdate_Ts = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            pdrRow.Item("Update_TS") = m_dtUpdate_Ts

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Cfg_Comm_Type " & _
            "WHERE  Comm_Type_Id = " & m_intComm_Type_Id & " "

            db.Execute(strSql)

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Comm_Type WITH (Nolock) " & _
            "WHERE  Comm_Type_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex as Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Cfg_Comm_Type " & _
            "WHERE  Comm_Type_Id = " & m_intComm_Type_Id & " "

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

            If m_intComm_Type_Id = 0 Then m_intComm_Type_Id = db.DataTable("SELECT MAX(Comm_Type_Id) AS Max_Comm_Type_Id FROM Mdb_Cfg_Comm_Type WITH (Nolock)").Rows(0).Item("Max_Comm_Type_Id")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Comm_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region 


#Region "Public properties ################################################" 

    Public Property Comm_Type_Id() As Int32
        Get
            Comm_Type_Id = m_intComm_Type_Id 
        End Get
        Set(ByVal value As Int32)
            m_intComm_Type_Id = value
        End Set
    End Property

    Public Property Comm_Desc() As String
        Get
            Comm_Desc = m_strComm_Desc 
        End Get
        Set(ByVal value As String)
            m_strComm_Desc = value
        End Set
    End Property

    Public Property Comm_Order() As Int32
        Get
            Comm_Order = m_intComm_Order 
        End Get
        Set(ByVal value As Int32)
            m_intComm_Order = value
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


End Class ' cMdb_Cfg_Comm_Type


