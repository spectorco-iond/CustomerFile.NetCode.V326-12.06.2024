Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Prog_Comment


#Region "private variables #################################################"


    Private m_intProg_Comment_Id As Int32
    Private m_intCus_Prog_Id As Int32
    Private m_strCus_Prog_Guid As String
    Private m_strCus_Prog_Item_List_Guid As String
    Private m_strItem_Cd As String
    Private m_intMessage_Id As Int32
    Private m_strComment_Desc As String
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pProg_Comment_Id As Int32)

        Try

            Call Init()
            Call Load(pProg_Comment_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pCus_Prog_Guid As String, ByVal pMessageID As Integer)

        Try

            Call Init()

            m_strCus_Prog_Guid = pCus_Prog_Guid
            m_intMessage_Id = pMessageID

            Call Load(m_strCus_Prog_Guid, m_intMessage_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pCus_Prog_Guid As String, ByVal pCus_Prog_Item_List_Guid As String, ByVal pMessageID As Integer)

        Try

            Call Init()

            m_strCus_Prog_Guid = pCus_Prog_Guid
            m_strCus_Prog_Item_List_Guid = pCus_Prog_Item_List_Guid
            m_intMessage_Id = pMessageID

            Call Load(m_strCus_Prog_Guid, m_strCus_Prog_Item_List_Guid, m_intMessage_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intProg_Comment_Id = 0
            m_intCus_Prog_Id = 0
            m_strCus_Prog_Guid = String.Empty
            m_strCus_Prog_Item_List_Guid = String.Empty
            m_strItem_Cd = String.Empty
            m_intMessage_Id = 0
            m_strComment_Desc = String.Empty
            m_strUser_Login = String.Empty
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Prog_Comment_Id").Equals(DBNull.Value)) Then m_intProg_Comment_Id = pdrRow.Item("Prog_Comment_Id")
            If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then m_intCus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
            If Not (pdrRow.Item("Cus_Prog_Guid").Equals(DBNull.Value)) Then m_strCus_Prog_Guid = pdrRow.Item("Cus_Prog_Guid").ToString
            If Not (pdrRow.Item("Cus_Prog_Item_List_Guid").Equals(DBNull.Value)) Then m_strCus_Prog_Item_List_Guid = pdrRow.Item("Cus_Prog_Item_List_Guid").ToString
            If Not (pdrRow.Item("Item_Cd").Equals(DBNull.Value)) Then m_strItem_Cd = pdrRow.Item("Item_Cd").ToString
            If Not (pdrRow.Item("Message_Id").Equals(DBNull.Value)) Then m_intMessage_Id = pdrRow.Item("Message_Id")
            If Not (pdrRow.Item("Comment_Desc").Equals(DBNull.Value)) Then m_strComment_Desc = pdrRow.Item("Comment_Desc").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Prog_Comment_Id") = m_intProg_Comment_Id
            pdrRow.Item("Cus_Prog_Id") = m_intCus_Prog_Id
            pdrRow.Item("Cus_Prog_Guid") = m_strCus_Prog_Guid
            pdrRow.Item("Cus_Prog_Item_List_Guid") = m_strCus_Prog_Item_List_Guid
            pdrRow.Item("Item_Cd") = m_strItem_Cd
            pdrRow.Item("Message_Id") = m_intMessage_Id
            pdrRow.Item("Comment_Desc") = m_strComment_Desc

            m_strUser_Login = Environment.UserName
            pdrRow.Item("User_Login") = m_strUser_Login

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"

    'Ion 14.10.14   Delete element with CUS_PROG_ID from database
    Public Sub Delete(ByRef oCus_Prog_Id As cMdb_Cus_Prog)
        Dim db As New cDBA
        Dim strSql As String
        Dim dt As DataTable
        Try
            Dim cus_prog_id As Int32 = oCus_Prog_Id.Cus_Prog_Id
            strSql = _
            " SELECT * " & _
            " FROM   Mdb_Prog_Comment WITH (Nolock) " & _
            " where Cus_Prog_Id = " & cus_prog_id & ""

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                For Each item As DataRow In dt.Rows
                    m_intProg_Comment_Id = CInt(item.Item("Prog_Comment_Id").ToString)
                    Call Delete()
                Next

            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Ion 



    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Prog_Comment " & _
            "WHERE  Prog_Comment_Id = " & m_intProg_Comment_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Prog_Comment WITH (Nolock) " & _
            "WHERE  Prog_Comment_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pCus_Prog_Guid As String, ByVal pMessageID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Prog_Comment WITH (Nolock) " & _
            "WHERE  Cus_Prog_Guid = '" & pCus_Prog_Guid & "' AND ISNULL(Cus_Prog_Item_List_Guid, '') = '' AND Message_ID = " & pMessageID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pCus_Prog_Guid As String, ByVal pCus_Prog_Item_List_Guid As String, ByVal pMessageID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Prog_Comment WITH (Nolock) " & _
            "WHERE  Cus_Prog_Guid = '" & pCus_Prog_Guid & "' AND ISNULL(Cus_Prog_Item_List_Guid, '') = '" & pCus_Prog_Item_List_Guid & "' AND Message_ID = " & pMessageID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Prog_Comment " & _
            "WHERE  Prog_Comment_Id = " & m_intProg_Comment_Id & " "

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
            MsgBox("Error in cMdb_Prog_Comment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Prog_Comment_Id() As Int32
        Get
            Prog_Comment_Id = m_intProg_Comment_Id
        End Get
        Set(ByVal value As Int32)
            m_intProg_Comment_Id = value
        End Set
    End Property

    Public Property Cus_Prog_Item_List_Guid() As String
        Get
            Cus_Prog_Item_List_Guid = m_strCus_Prog_Item_List_Guid
        End Get
        Set(ByVal value As String)
            m_strCus_Prog_Item_List_Guid = value
        End Set
    End Property

    Public Property Cus_Prog_Guid() As String
        Get
            Cus_Prog_Guid = m_strCus_Prog_Guid
        End Get
        Set(ByVal value As String)
            m_strCus_Prog_Guid = value
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

    Public Property Item_Cd() As String
        Get
            Item_Cd = m_strItem_Cd
        End Get
        Set(ByVal value As String)
            m_strItem_Cd = value
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

    Public Property Comment_Desc() As String
        Get
            Comment_Desc = m_strComment_Desc
        End Get
        Set(ByVal value As String)
            m_strComment_Desc = value
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


End Class ' cMdb_Prog_Comment


