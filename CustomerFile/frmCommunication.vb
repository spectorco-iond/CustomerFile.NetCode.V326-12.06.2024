Public Class frmCommunication

    Private m_Contact As cExact_Traveler_Communications

    Private User_Rights As String = "READONLY"

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
            m_Contact = New cExact_Traveler_Communications()

            Call cboContact_FillCombo()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub New(ByVal piID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try

            m_Contact = New cExact_Traveler_Communications(piID)

            Call cboContact_FillCombo()

            Call Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Shadows Sub Load()

        Try

            txtID.Text = m_Contact.Id
            txtCus_No.Text = m_Contact.Cus_No
            txtOrd_No.Text = m_Contact.Ord_No
            txtSalesperson.Text = m_Contact.Csr_Contact
            txtContact.Text = m_Contact.Cus_Contact
            txtSubject.Text = m_Contact.Subject
            txtMessage.Text = m_Contact.Message
            txtCreate_TS.Text = m_Contact.Createdate.ToShortDateString
            chkNegativeFeed.Checked = m_Contact.NegativeFeed

            Call cboContact_FillCombo()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()

        Try

            m_Contact.Cus_No = txtCus_No.Text
            m_Contact.Ord_No = txtOrd_No.Text
            m_Contact.Csr_Contact = txtSalesperson.Text
            m_Contact.Cus_Contact = txtContact.Text
            m_Contact.Subject = txtSubject.Text
            m_Contact.Message = txtMessage.Text
            m_Contact.NegativeFeed = chkNegativeFeed.Checked

            m_Contact.Save()

            Me.Close()

            'm_Contact.Createdate.ToShortDateString = txtCreate_TS.Text

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cboContact_FillCombo()

        Dim strSql As String
        Dim dtContacts As DataTable
        Dim db As New cDBA

        Try

            strSql =
            "SELECT	DISTINCT C.Fullname " &
            "FROM  cicntp C WITH (Nolock) " &
            "INNER JOIN	cicmpy P WITH (Nolock) ON C.cmp_wwn = P.cmp_wwn " &
            "WHERE	ISNULL(C.active_y,0) = 1 And P.cmp_code = '" & txtCus_No.Text & "' " &
            "ORDER BY	C.FullName "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            dtContacts = db.DataTable(strSql)

            If dtContacts.Rows.Count <> 0 Then

                For Each dtRow As DataRow In dtContacts.Rows

                    cboContact.Items.Add(dtRow.Item("Fullname").ToString.Trim)

                Next dtRow

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Call Save()

    End Sub

    Private Sub frmCommunication_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        Call SetPermissions()

    End Sub

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
                tsSave.Enabled = True

            Case "SUPERUSER"
                tsSave.Enabled = True

            Case "READONLY"
                tsClose.Visible = True
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
            lblCus_No.Focus()
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As System.EventArgs) Handles tsClose.Click

        Me.Close()

    End Sub

 
End Class
