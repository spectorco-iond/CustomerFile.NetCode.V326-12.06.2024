Public Class frmEmail

    Private User_Rights As String = "READONLY"

    Private mo_Email As cExact_Traveler_Email_Message
    Private m_strCus_No As String = String.Empty

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pstrCus_No As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try
            txtCus_No.Text = pstrCus_No.ToUpper.Trim
            mo_Email = New cExact_Traveler_Email_Message()

            'Call cboContact_FillCombo()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub New(ByVal piID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try

            mo_Email = New cExact_Traveler_Email_Message(piID)

            'Call cboContact_FillCombo()

            Call Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs)

        MsgBox("We do not allow save in this screen.")

        'Call Save()

    End Sub

    Private Shadows Sub Load()

        Try

            txtCus_No.Text = m_strCus_No
            txtEmailID.Text = mo_Email.EmailId
            txtOrd_No.Text = mo_Email.Ord_No
            txtEmailFrom.Text = mo_Email.EmailFrom
            txtFollowUp.Text = mo_Email.FollowUp
            txtEmailTo.Text = mo_Email.EmailTo
            txtUserTo.Text = mo_Email.UserTo
            txtSubjectLine.Text = mo_Email.SubjectLine
            txtMessage.Text = mo_Email.Message
            txtCreate_TS.Text = mo_Email.Createdate.ToShortDateString

            'Call cboContact_FillCombo()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub Save()

    '    Try

    '        mo_Email.Cus_No = txtCus_No.Text
    '        mo_Email.Ord_No = txtOrd_No.Text
    '        mo_Email.Csr_Contact = txtSalesperson.Text
    '        mo_Email.Cus_Contact = txtContact.Text
    '        mo_Email.Subject = txtSubject.Text
    '        mo_Email.Message = txtMessage.Text

    '        mo_Email.Save()

    '        'mo_Email.Createdate.ToShortDateString = txtCreate_TS.Text

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    'Private Sub cboContact_FillCombo()

    '    Dim strSql As String
    '    Dim dtContacts As DataTable
    '    Dim db As New cDBA

    '    Try

    '        strSql = _
    '        "SELECT		DISTINCT C.Fullname " & _
    '        "FROM		cicntp C WITH (Nolock) " & _
    '        "INNER JOIN	cicmpy P WITH (Nolock) ON C.cmp_wwn = P.cmp_wwn " & _
    '        "WHERE		P.cmp_code = '" & txtCus_No.Text & "' " & _
    '        "ORDER BY	C.FullName "

    '        dtContacts = db.DataTable(strSql)

    '        If dtContacts.Rows.Count <> 0 Then

    '            For Each dtRow As DataRow In dtContacts.Rows

    '                cboContact.Items.Add(dtRow.Item("Fullname").ToString.Trim)

    '            Next dtRow

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Private Sub SetPermissions()

        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
        dt = db.DataTable(strSql)
        If dt.Rows.Count <> 0 Then
            User_Rights = dt.Rows(0).Item("Access_Type").ToString
        Else
            strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                User_Rights = dt.Rows(0).Item("Access_Type").ToString
            End If
        End If

        Select Case User_Rights
            Case "READWRITE"
                'tsSave.Enabled = True

            Case "SUPERUSER"
                'tsSave.Enabled = True

            Case "READONLY"
                'tsClose.Visible = True
                Dim c As Control
                For Each c In Me.Controls
                    If TypeOf c Is TextBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        'c.Enabled = False
                        'c.BackColor = Color.White
                    ElseIf TypeOf c Is ComboBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is CheckBox Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is RadioButton Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is Button Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    End If
                Next

        End Select

    End Sub

    Private Sub ReadOnlyFields_GotFocus(sender As Object, e As System.EventArgs)

        If User_Rights = "READONLY" Then
            cmdClose.Focus()
        End If

    End Sub

    Private Sub frmEmail_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        Call SetPermissions()

    End Sub

End Class