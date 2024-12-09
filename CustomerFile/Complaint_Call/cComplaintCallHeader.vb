Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cComplaintCallHeader

#Region "private variables #################################################"
    Private m_COMPLAINT_CALL_HEADER_ID As Int32 = 0
    Private m_COMPLAINT_CALL_USER_ID As Int32 = 0
    Private m_COMPLAINT_CALL_TYPE_ID As Int32 = 1
    Private m_COMPLAINT_CALL_LEVEL_ID As Int32 = 1
    Private m_COMPLAINT_CALL_STATUS_ID As Int32 = 1
    Private m_CALL_DATE As DateTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    Private m_PO_NO As String = ""

#End Region

#Region "Public constructors ##############################################"

    Public Sub New()
        Try
            Call Init()
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pCOMPLAINT_CALL_HEADER_ID As Int32)

        Try
            Call Init()
            Call Load(pCOMPLAINT_CALL_HEADER_ID)

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"

    Private Sub Init()

        Try
            m_COMPLAINT_CALL_HEADER_ID = 0
            m_CALL_DATE = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_HEADER_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_HEADER_ID = pdrRow.Item("COMPLAINT_CALL_HEADER_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_USER_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_USER_ID = pdrRow.Item("COMPLAINT_CALL_USER_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_TYPE_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_TYPE_ID = pdrRow.Item("COMPLAINT_CALL_TYPE_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_LEVEL_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_LEVEL_ID = pdrRow.Item("COMPLAINT_CALL_LEVEL_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_STATUS_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_STATUS_ID = pdrRow.Item("COMPLAINT_CALL_STATUS_ID")
            If Not (pdrRow.Item("CALL_DATE").Equals(DBNull.Value)) Then m_CALL_DATE = pdrRow.Item("CALL_DATE")
            If Not (pdrRow.Item("PO_NO").Equals(DBNull.Value)) Then m_PO_NO = pdrRow.Item("PO_NO")
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub SaveLine(ByRef pdrRow As DataRow) 'save m from input 1row
        Try
            pdrRow.Item("COMPLAINT_CALL_HEADER_ID") = m_COMPLAINT_CALL_HEADER_ID
            pdrRow.Item("COMPLAINT_CALL_USER_ID") = m_COMPLAINT_CALL_USER_ID
            pdrRow.Item("COMPLAINT_CALL_TYPE_ID") = m_COMPLAINT_CALL_TYPE_ID
            pdrRow.Item("COMPLAINT_CALL_LEVEL_ID") = m_COMPLAINT_CALL_LEVEL_ID
            pdrRow.Item("COMPLAINT_CALL_STATUS_ID") = m_COMPLAINT_CALL_STATUS_ID
            pdrRow.Item("CALL_DATE") = m_CALL_DATE
            pdrRow.Item("PO_NO") = m_PO_NO

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current row from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
            "DELETE FROM COMPLAINT_CALL_HEADER " &
            "WHERE  COMPLAINT_CALL_HEADER_ID = " & m_COMPLAINT_CALL_HEADER_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_HEADER WITH (Nolock) " &
            "WHERE  COMPLAINT_CALL_HEADER_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current COMPLAINT_CALL_HEADER into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_HEADER " &
            "WHERE  COMPLAINT_CALL_HEADER_ID = " & m_COMPLAINT_CALL_HEADER_ID & " "

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

            'MsgBox("saved!")
            'strSql = "SELECT MAX(COMPLAINT_CALL_HEADER_ID) AS Max_COMPLAINT_CALL_HEADER_ID FROM COMPLAINT_CALL_HEADER WITH (Nolock)"
            'dt = db.DataTable(strSql)
            'MsgBox(dt.Rows(0).Item("Max_COMPLAINT_CALL_HEADER_ID"))

            If m_COMPLAINT_CALL_HEADER_ID = 0 Then
                m_COMPLAINT_CALL_HEADER_ID = db.DataTable("SELECT MAX(COMPLAINT_CALL_HEADER_ID) AS Max_COMPLAINT_CALL_HEADER_ID FROM COMPLAINT_CALL_HEADER WITH (Nolock)").Rows(0).Item("Max_COMPLAINT_CALL_HEADER_ID")
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_HEADER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_HEADER_ID() As Int32
        Get
            COMPLAINT_CALL_HEADER_ID = m_COMPLAINT_CALL_HEADER_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_HEADER_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_USER_ID() As Int32
        Get
            COMPLAINT_CALL_USER_ID = m_COMPLAINT_CALL_USER_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_USER_ID = value
        End Set
    End Property
    Public Property COMPLAINT_CALL_TYPE_ID() As Int32
        Get
            COMPLAINT_CALL_TYPE_ID = m_COMPLAINT_CALL_TYPE_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_TYPE_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_LEVEL_ID() As Int32
        Get
            COMPLAINT_CALL_LEVEL_ID = m_COMPLAINT_CALL_LEVEL_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_LEVEL_ID = value
        End Set
    End Property
    Public Property COMPLAINT_CALL_STATUS_ID() As Int32
        Get
            COMPLAINT_CALL_STATUS_ID = m_COMPLAINT_CALL_STATUS_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_STATUS_ID = value
        End Set
    End Property
    Public Property CALL_DATE() As DateTime
        Get
            CALL_DATE = m_CALL_DATE
        End Get
        Set(ByVal value As DateTime)
            m_CALL_DATE = value
        End Set
    End Property

    Public Property PO_NO() As String
        Get
            PO_NO = m_PO_NO
        End Get
        Set(ByVal value As String)
            m_PO_NO = value
        End Set
    End Property



#End Region


End Class ' cCOMPLAINT_CALL_HEADER_ID