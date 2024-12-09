Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cComplaintCallUser

#Region "private variables #################################################"
    Private m_COMPLAINT_CALL_USER_ID As Int32 = 0
    Private m_FIRST_NAME As String = String.Empty
    Private m_LAST_NAME As String = String.Empty
    Private m_LANGUAGE_ID As Int32 = 0
    Private m_USER_CONTACT_PHONE_NUMBER As String = String.Empty
    Private m_USER_ADDRESS As String = String.Empty
    Private m_USER_POST_CODE As String = String.Empty
    Private m_USER_CITY As String = String.Empty
    Private m_USER_EMAIL As String = String.Empty
    Private m_CREATE_BY As String = String.Empty
    Private m_CREATE_DATE As DateTime
    Private m_BELONG_CSR As String = String.Empty
    Private m_STATUS As Int32 = 0
    Private m_CUS_NO As String = String.Empty
#End Region

#Region "Public constructors ##############################################"

    Public Sub New()
        Try
            Call Init()
        Catch ex As Exception
            MsgBox("Error in cComplaintCallUser." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pCOMPLAINT_CALL_USER_ID As Int32)

        Try
            Call Init()
            Call Load(pCOMPLAINT_CALL_USER_ID)

        Catch ex As Exception
            MsgBox("Error in cComplaintCallLevel." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function New_from_CUS(ByVal pcComplaintCallUser As cComplaintCallUser)

        Try
            m_COMPLAINT_CALL_USER_ID = pcComplaintCallUser.COMPLAINT_CALL_USER_ID
            m_FIRST_NAME = pcComplaintCallUser.FIRST_NAME
            m_LAST_NAME = pcComplaintCallUser.LAST_NAME
            m_LANGUAGE_ID = pcComplaintCallUser.LANGUAGE_ID
            m_USER_CONTACT_PHONE_NUMBER = pcComplaintCallUser.USER_CONTACT_PHONE_NUMBER
            m_USER_ADDRESS = pcComplaintCallUser.USER_ADDRESS
            m_USER_POST_CODE = pcComplaintCallUser.USER_POST_CODE
            m_USER_CITY = pcComplaintCallUser.USER_CITY
            m_USER_EMAIL = pcComplaintCallUser.USER_EMAIL
            m_CREATE_BY = pcComplaintCallUser.CREATE_BY
            m_CREATE_DATE = pcComplaintCallUser.CREATE_DATE
            m_BELONG_CSR = pcComplaintCallUser.BELONG_CSR
            m_STATUS = pcComplaintCallUser.STATUS
            m_CUS_NO = pcComplaintCallUser.CUS_NO

            Call Load_from_cus(pcComplaintCallUser)

        Catch ex As Exception
            MsgBox("Error in cComplaintCallLevel." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


#End Region


#Region "Private maintenance procedures ###################################"

    Private Sub Init()

        Try
            m_COMPLAINT_CALL_USER_ID = 0
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_USER_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_USER_ID = pdrRow.Item("COMPLAINT_CALL_USER_ID")
            If Not (pdrRow.Item("FIRST_NAME").Equals(DBNull.Value)) Then m_FIRST_NAME = pdrRow.Item("FIRST_NAME").ToString
            If Not (pdrRow.Item("LAST_NAME").Equals(DBNull.Value)) Then m_LAST_NAME = pdrRow.Item("LAST_NAME").ToString
            If Not (pdrRow.Item("LANGUAGE_ID").Equals(DBNull.Value)) Then m_LANGUAGE_ID = pdrRow.Item("LANGUAGE_ID")
            If Not (pdrRow.Item("USER_CONTACT_PHONE_NUMBER").Equals(DBNull.Value)) Then m_USER_CONTACT_PHONE_NUMBER = pdrRow.Item("USER_CONTACT_PHONE_NUMBER").ToString
            If Not (pdrRow.Item("USER_ADDRESS").Equals(DBNull.Value)) Then m_USER_ADDRESS = pdrRow.Item("USER_ADDRESS").ToString
            If Not (pdrRow.Item("USER_POST_CODE").Equals(DBNull.Value)) Then m_USER_POST_CODE = pdrRow.Item("USER_POST_CODE").ToString
            If Not (pdrRow.Item("USER_CITY").Equals(DBNull.Value)) Then m_USER_CITY = pdrRow.Item("USER_CITY").ToString
            If Not (pdrRow.Item("USER_EMAIL").Equals(DBNull.Value)) Then m_USER_EMAIL = pdrRow.Item("USER_EMAIL").ToString
            If Not (pdrRow.Item("CREATE_BY").Equals(DBNull.Value)) Then m_CREATE_BY = pdrRow.Item("CREATE_BY")
            If Not (pdrRow.Item("CREATE_DATE").Equals(DBNull.Value)) Then m_CREATE_DATE = pdrRow.Item("CREATE_DATE")
            If Not (pdrRow.Item("BELONG_CSR").Equals(DBNull.Value)) Then m_BELONG_CSR = pdrRow.Item("BELONG_CSR").ToString
            If Not (pdrRow.Item("STATUS").Equals(DBNull.Value)) Then m_STATUS = pdrRow.Item("STATUS")
            If Not (pdrRow.Item("CUS_NO").Equals(DBNull.Value)) Then m_CUS_NO = pdrRow.Item("CUS_NO")
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveLine(ByRef pdrRow As DataRow) 'save m from input 1row
        Try
            pdrRow.Item("COMPLAINT_CALL_USER_ID") = m_COMPLAINT_CALL_USER_ID
            pdrRow.Item("FIRST_NAME") = m_FIRST_NAME
            pdrRow.Item("LAST_NAME") = m_LAST_NAME
            pdrRow.Item("LANGUAGE_ID") = m_LANGUAGE_ID
            pdrRow.Item("USER_CONTACT_PHONE_NUMBER") = m_USER_CONTACT_PHONE_NUMBER
            pdrRow.Item("USER_ADDRESS") = m_USER_ADDRESS
            pdrRow.Item("USER_POST_CODE") = m_USER_POST_CODE
            pdrRow.Item("USER_CITY") = m_USER_CITY
            pdrRow.Item("USER_EMAIL") = m_USER_EMAIL
            pdrRow.Item("CREATE_BY") = m_CREATE_BY
            pdrRow.Item("CREATE_DATE") = m_CREATE_DATE
            pdrRow.Item("BELONG_CSR") = m_BELONG_CSR
            pdrRow.Item("STATUS") = m_STATUS
            pdrRow.Item("CUS_NO") = m_CUS_NO

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM COMPLAINT_CALL_USER " &
            "WHERE  COMPLAINT_CALL_USER_ID = " & m_COMPLAINT_CALL_USER_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load_from_cus(ByVal pcComplaintCallUser As cComplaintCallUser)

        Try
            Dim pintID As Integer = pcComplaintCallUser.COMPLAINT_CALL_USER_ID

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_USER WITH (Nolock) " &
            "WHERE  COMPLAINT_CALL_USER_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            Else
                If pintID = 99999 Then
                    Save()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_USER WITH (Nolock) " &
            "WHERE  COMPLAINT_CALL_USER_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current COMPLAINT_CALL_LEVEL into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_USER " &
            "WHERE  COMPLAINT_CALL_USER_ID = " & m_COMPLAINT_CALL_USER_ID & " "

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


            If m_COMPLAINT_CALL_USER_ID = 0 Then m_COMPLAINT_CALL_USER_ID = db.DataTable("SELECT MAX(COMPLAINT_CALL_USER_ID) AS Max_COMPLAINT_CALL_USER_ID FROM COMPLAINT_CALL_USER WITH (Nolock)").Rows(0).Item("Max_COMPLAINT_CALL_USER_ID")
            If m_COMPLAINT_CALL_USER_ID = 99999 Then m_COMPLAINT_CALL_USER_ID = db.DataTable("SELECT MAX(COMPLAINT_CALL_USER_ID) AS Max_COMPLAINT_CALL_USER_ID FROM COMPLAINT_CALL_USER WITH (Nolock)").Rows(0).Item("Max_COMPLAINT_CALL_USER_ID")
            'MsgBox("user saved! user_id is: " + m_COMPLAINT_CALL_USER_ID.ToString)
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_USER_ID() As Int32
        Get
            COMPLAINT_CALL_USER_ID = m_COMPLAINT_CALL_USER_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_USER_ID = value
        End Set
    End Property

    Public Property FIRST_NAME() As String
        Get
            FIRST_NAME = m_FIRST_NAME
        End Get
        Set(ByVal value As String)
            m_FIRST_NAME = value
        End Set
    End Property
    Public Property LAST_NAME() As String
        Get
            LAST_NAME = m_LAST_NAME
        End Get
        Set(ByVal value As String)
            m_LAST_NAME = value
        End Set
    End Property

    Public Property LANGUAGE_ID() As Int32
        Get
            LANGUAGE_ID = m_LANGUAGE_ID
        End Get
        Set(ByVal value As Int32)
            m_LANGUAGE_ID = value
        End Set
    End Property
    Public Property USER_CONTACT_PHONE_NUMBER() As String
        Get
            USER_CONTACT_PHONE_NUMBER = m_USER_CONTACT_PHONE_NUMBER
        End Get
        Set(ByVal value As String)
            m_USER_CONTACT_PHONE_NUMBER = value
        End Set
    End Property
    Public Property USER_ADDRESS() As String
        Get
            USER_ADDRESS = m_USER_ADDRESS
        End Get
        Set(ByVal value As String)
            m_USER_ADDRESS = value
        End Set
    End Property
    Public Property USER_POST_CODE() As String
        Get
            USER_POST_CODE = m_USER_POST_CODE
        End Get
        Set(ByVal value As String)
            m_USER_POST_CODE = value
        End Set
    End Property

    Public Property USER_CITY() As String
        Get
            USER_CITY = m_USER_CITY
        End Get
        Set(ByVal value As String)
            m_USER_CITY = value
        End Set
    End Property
    Public Property USER_EMAIL() As String
        Get
            USER_EMAIL = m_USER_EMAIL
        End Get
        Set(ByVal value As String)
            m_USER_EMAIL = value
        End Set
    End Property

    Public Property CREATE_BY() As String
        Get
            CREATE_BY = m_CREATE_BY
        End Get
        Set(ByVal value As String)
            m_CREATE_BY = value
        End Set
    End Property

    Public Property CREATE_DATE() As DateTime
        Get
            CREATE_DATE = m_CREATE_DATE
        End Get
        Set(ByVal value As DateTime)
            m_CREATE_DATE = value
        End Set
    End Property

    Public Property BELONG_CSR() As String
        Get
            BELONG_CSR = m_BELONG_CSR
        End Get
        Set(ByVal value As String)
            m_BELONG_CSR = value
        End Set
    End Property
    Public Property STATUS() As Int32
        Get
            STATUS = m_STATUS
        End Get
        Set(ByVal value As Int32)
            m_STATUS = value
        End Set
    End Property

    Public Property CUS_NO() As String
        Get
            CUS_NO = m_CUS_NO
        End Get
        Set(ByVal value As String)
            m_CUS_NO = value
        End Set
    End Property

#End Region

    Public Function get_user_name() As String
        Return m_LAST_NAME + " , " + m_FIRST_NAME
    End Function
End Class ' cComplaintCallUser