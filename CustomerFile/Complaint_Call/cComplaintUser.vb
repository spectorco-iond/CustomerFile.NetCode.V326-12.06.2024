Public Class cComplaintUser


#Region "private variables #################################################"
    Private m_COMPLAINT_CALL_USER_ID As Int32 = 0
    Private m_FIRST_NAME As String = ""
    Private m_LAST_NAME As String = ""
    Private m_LANGUAGE_ID As Int32
    Private m_USER_CONTACT_PHONE_NUMBER As String = ""
    Private m_USER_ADDRESS As String = ""
    Private m_USER_POST_CODE As String = ""
    Private m_USER_CITY As String = ""
    Private m_USER_EMAIL As String = ""
    Private m_CREATE_BY As String = ""
    Private m_CREATE_DATE As Date
    Private m_BELONG_CSR As String = ""
    Private m_STATUS As Int32
#End Region


#Region "Public CONSTRUCTORS ###############################################"

    Public Sub New()
        m_COMPLAINT_CALL_USER_ID = 0
    End Sub

#End Region
    Public Sub save() 'insert
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
            MsgBox("saved!")
        Catch ex As Exception
            MsgBox("Error in cComplaintUser." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveLine(ByRef pdrRow As DataRow)
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

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_USER." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_USER_ID As Int32
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

    Public Property LAST_NAME As String
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

    Public Property USER_CONTACT_PHONE_NUMBER As String
        Get
            USER_CONTACT_PHONE_NUMBER = m_USER_CONTACT_PHONE_NUMBER
        End Get
        Set(ByVal value As String)
            m_USER_CONTACT_PHONE_NUMBER = value
        End Set
    End Property

    Public Property USER_ADDRESS As String
        Get
            USER_ADDRESS = m_USER_ADDRESS
        End Get
        Set(ByVal value As String)
            m_USER_ADDRESS = value
        End Set
    End Property

    Public Property USER_POST_CODE As String
        Get
            USER_POST_CODE = m_USER_POST_CODE
        End Get
        Set(ByVal value As String)
            m_USER_POST_CODE = value
        End Set
    End Property

    Public Property USER_CITY As String
        Get
            USER_CITY = m_USER_CITY
        End Get
        Set(ByVal value As String)
            m_USER_CITY = value
        End Set
    End Property

    Public Property USER_EMAIL As String
        Get
            USER_EMAIL = m_USER_EMAIL
        End Get
        Set(ByVal value As String)
            m_USER_EMAIL = value
        End Set
    End Property

    Public Property CREATE_BY As String
        Get
            CREATE_BY = m_CREATE_BY
        End Get
        Set(ByVal value As String)
            m_CREATE_BY = value
        End Set
    End Property


    Public Property CREATE_DATE As Date
        Get
            CREATE_DATE = m_CREATE_DATE
        End Get
        Set(ByVal value As Date)
            m_CREATE_DATE = value
        End Set
    End Property


    Public Property BELONG_CSR As String
        Get
            BELONG_CSR = m_BELONG_CSR
        End Get
        Set(ByVal value As String)
            m_BELONG_CSR = value
        End Set
    End Property

    Public Property STATUS As Int32
        Get
            STATUS = m_STATUS
        End Get
        Set(ByVal value As Int32)
            m_STATUS = value
        End Set
    End Property
#End Region
End Class


