Public Class cMDB_CUS_FEEDBACK


#Region "private variables #################################################"


    Private m_intFeedback_ID As Int32
    Private m_strCus_No As String
    Private m_strOrd_No As String
    Private m_intDisruption_ID As Int32
    Private m_strFeedback_Text As String
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime
    Private m_dtCreate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pFeedback_ID As Int32)

        Try

            Call Init()
            Call Load(pFeedback_ID)

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intFeedback_ID = 0
            m_strCus_No = String.Empty
            m_strOrd_No = String.Empty
            m_intDisruption_ID = 0
            m_strFeedback_Text = String.Empty
            m_strUser_Login = String.Empty
            m_dtCreate_Ts = NoDate()
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Feedback_ID").Equals(DBNull.Value)) Then m_intFeedback_ID = pdrRow.Item("Feedback_ID")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("Disruption_ID").Equals(DBNull.Value)) Then m_intDisruption_ID = pdrRow.Item("Disruption_ID")
            If Not (pdrRow.Item("Feedback_Text").Equals(DBNull.Value)) Then m_strFeedback_Text = pdrRow.Item("Feedback_Text").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Ord_No") = m_strOrd_No
            pdrRow.Item("Disruption_ID") = m_intDisruption_ID
            pdrRow.Item("Feedback_Text") = m_strFeedback_Text

            m_strUser_Login = Environment.UserName

            If m_intFeedback_ID = 0 Then m_dtCreate_Ts = Date.Now
            m_dtUpdate_Ts = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            pdrRow.Item("Create_Ts") = m_dtCreate_Ts
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM MDB_CUS_FEEDBACK " & _
            "WHERE  Feedback_ID = " & m_intFeedback_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   MDB_CUS_FEEDBACK WITH (Nolock) " & _
            "WHERE  Feedback_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   MDB_CUS_FEEDBACK " & _
            "WHERE  Feedback_ID = " & m_intFeedback_ID & " "

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
            MsgBox("Error in cMDB_CUS_FEEDBACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Feedback_ID() As Int32
        Get
            Feedback_ID = m_intFeedback_ID
        End Get
        Set(ByVal value As Int32)
            m_intFeedback_ID = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
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

    Public Property Disruption_ID() As Int32
        Get
            Disruption_ID = m_intDisruption_ID
        End Get
        Set(ByVal value As Int32)
            m_intDisruption_ID = value
        End Set
    End Property

    Public Property Feedback_Text() As String
        Get
            Feedback_Text = m_strFeedback_Text
        End Get
        Set(ByVal value As String)
            m_strFeedback_Text = value
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

    Public Property Create_Ts() As DateTime
        Get
            Create_Ts = m_dtCreate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtCreate_Ts = value
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

End Class
