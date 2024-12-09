Public Class cExact_Traveler_Email_Message


#Region "private variables ####################################################"


    Private m_intEmailId As Int32 = 0
    Private m_strOrd_No As String ' Done
    Private m_strUserTo As String
    Private m_strEmailTo As String
    Private m_strEmailFrom As String
    Private m_strSubjectLine As String
    Private m_strMessage As String
    Private m_dtCreatedate As DateTime
    Private m_strFollowUp As String
    'Private m_blnDeleted As Boolean
    'Private m_intOrig_Id As Int32
    Private m_strSpector_Cd As String

#End Region


#Region "Public constructors ##################################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pEmailId As Int32)

        Try

            Call Init()
            Call Load(pEmailId)

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures #######################################"


    Private Sub Init()

        Try

            m_intEmailId = 0
            m_strUserTo = String.Empty
            m_strOrd_No = String.Empty
            m_strEmailTo = String.Empty
            m_strEmailFrom = String.Empty
            m_strSubjectLine = String.Empty
            m_strMessage = String.Empty

            m_strFollowUp = String.Empty
            m_strSpector_Cd = String.Empty

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("EmailId").Equals(DBNull.Value)) Then m_intEmailId = pdrRow.Item("EmailId")
            If Not (pdrRow.Item("UserTo").Equals(DBNull.Value)) Then m_strUserTo = pdrRow.Item("UserTo").ToString
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("EmailTo").Equals(DBNull.Value)) Then m_strEmailTo = pdrRow.Item("EmailTo").ToString
            If Not (pdrRow.Item("EmailFrom").Equals(DBNull.Value)) Then m_strEmailFrom = pdrRow.Item("EmailFrom").ToString
            If Not (pdrRow.Item("SubjectLine").Equals(DBNull.Value)) Then m_strSubjectLine = pdrRow.Item("SubjectLine").ToString
            If Not (pdrRow.Item("Message").Equals(DBNull.Value)) Then m_strMessage = pdrRow.Item("Message").ToString
            If Not (pdrRow.Item("Createdate").Equals(DBNull.Value)) Then m_dtCreatedate = pdrRow.Item("Createdate")
            If Not (pdrRow.Item("FollowUp").Equals(DBNull.Value)) Then m_strFollowUp = pdrRow.Item("FollowUp").ToString
            If Not (pdrRow.Item("SPECTOR_CD").Equals(DBNull.Value)) Then m_strSpector_Cd = pdrRow.Item("SPECTOR_CD").ToString

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Id") = m_intId ' NEVER SAVE ID
            pdrRow.Item("UserTo") = m_strUserTo
            pdrRow.Item("Ord_No") = m_strOrd_No
            pdrRow.Item("EmailTo") = m_strEmailTo
            pdrRow.Item("EmailFrom") = m_strEmailFrom
            pdrRow.Item("SubjectLine") = m_strSubjectLine
            pdrRow.Item("Message") = m_strMessage
            If m_dtCreatedate.Year <> 1 Then pdrRow.Item("Createdate") = m_dtCreatedate.Date
            pdrRow.Item("FollowUp") = m_strFollowUp
            pdrRow.Item("SPECTOR_CD") = m_strSpector_Cd

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region


#Region "Public maintenance procedures ########################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Exact_Traveler_Email_Message " & _
            "WHERE  Id = " & m_intEmailId & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintEmailID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Exact_Traveler_Email_Message WITH (Nolock) " & _
            "WHERE  EmailID = " & pintEmailID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Exact_Traveler_Email_Message " & _
            "WHERE  EmailID = " & m_intEmailId & " "

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
            MsgBox("Error in cExact_Traveler_Email_Message." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ####################################################"

    Public Property EmailId() As Int32
        Get
            EmailId = m_intEmailId
        End Get
        Set(ByVal value As Int32)
            m_intEmailId = value
        End Set
    End Property

    Public Property UserTo() As String
        Get
            UserTo = m_strUserTo
        End Get
        Set(ByVal value As String)
            m_strUserTo = value
        End Set
    End Property

    Public Property Ord_No() As String
        Get
            Ord_No = m_strOrd_No
        End Get
        Set(ByVal value As String)
            m_strOrd_No = value
        End Set
    End Property

    Public Property EmailTo() As String
        Get
            EmailTo = m_strEmailTo
        End Get
        Set(ByVal value As String)
            m_strEmailTo = value
        End Set
    End Property

    Public Property EmailFrom() As String
        Get
            EmailFrom = m_strEmailFrom
        End Get
        Set(ByVal value As String)
            m_strEmailFrom = value
        End Set
    End Property

    Public Property SubjectLine() As String
        Get
            SubjectLine = m_strSubjectLine
        End Get
        Set(ByVal value As String)
            m_strSubjectLine = value
        End Set
    End Property

    Public Property Message() As String
        Get
            Message = m_strMessage
        End Get
        Set(ByVal value As String)
            m_strMessage = value
        End Set
    End Property

    Public Property Createdate() As DateTime
        Get
            Createdate = m_dtCreatedate
        End Get
        Set(ByVal value As DateTime)
            m_dtCreatedate = value
        End Set
    End Property

    Public Property FollowUp() As String
        Get
            FollowUp = m_strFollowUp
        End Get
        Set(ByVal value As String)
            m_strFollowUp = value
        End Set
    End Property
    '++ID 23.03.2015
    Public Property SPECTOR_CD As String
        Get
            SPECTOR_CD = m_strSpector_Cd
        End Get
        Set(ByVal value As String)
            m_strSpector_Cd = value
        End Set
    End Property

#End Region


End Class
