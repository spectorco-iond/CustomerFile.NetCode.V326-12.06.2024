Public Class frmCustomerContact

    Private m_Customer As cCustomer
    'Private m_Contact1 As cExact_Traveler_Communications
    Private m_Contact As cCicntp

    Private User_Rights As String = "READONLY"

    Private dtAlt_Rep As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Public Sub New(ByVal pstrCus_No As String)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    '    Try
    '        txtCus_No.Text = pstrCus_No.ToUpper.Trim
    '        m_Contact = New cExact_Traveler_Communications()

    '        Call cboContact_FillCombo()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Public Sub New(ByVal piID As Integer)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    '    Try

    '        m_Contact = New cExact_Traveler_Communications(piID)

    '        Call cboContact_FillCombo()

    '        Call Load()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Public Sub New(ByRef pCustomer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Contact = New cCicntp

        Call Insert()

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pContact As cCicntp)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Contact = pContact

        Call Load()

    End Sub

    Private Sub Insert()

        Try

            Call cboContact_FillCombo()
            Call cboAlternate_Rep_FillCombo()


            chkActive.CheckState = CheckState.Checked

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Shadows Sub Load()

        Try

            Call cboContact_FillCombo()
            Call cboAlternate_Rep_FillCombo()

            txtID.Text = m_Contact.ID
            cboPred.Text = m_Contact.predcode
            txtFirstName.Text = m_Contact.cnt_f_name
            txtLastName.Text = m_Contact.cnt_l_name
            cboLang.Text = m_Contact.taalcode
            txtTel.Text = m_Contact.cnt_f_tel
            txtExt.Text = m_Contact.cnt_f_ext
            txtMobile.text = m_Contact.cnt_f_mobile
            txtFax.Text = m_Contact.cnt_f_fax
            txtEmail.Text = m_Contact.cnt_email
            cboAlternate_Rep.SelectedValue = m_Contact.Alternate_Rep
            txtUse_Account_No.Text = m_Contact.Use_Account_No
            chkActive.CheckState = m_Contact.active_y
            If m_Contact.YesNoField3 = 1 Then cboWebAcc.CheckState = CheckState.Checked Else cboWebAcc.CheckState = CheckState.Unchecked

            'txtMessage.Text = m_Contact.Message
            'txtCreate_TS.Text = m_Contact.Createdate.ToShortDateString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Save()
        Try
            m_Contact.Customer = m_Customer
            m_Contact.cmp_wwn = m_Customer.cmp_wwn
            m_Contact.predcode = cboPred.Text
            m_Contact.cnt_f_name = txtFirstName.Text
            m_Contact.cnt_l_name = txtLastName.Text
            m_Contact.taalcode = cboLang.Text
            m_Contact.cnt_f_tel = txtTel.Text
            m_Contact.cnt_f_ext = txtExt.Text
            m_Contact.cnt_f_mobile = txtMobile.Text
            m_Contact.cnt_f_fax = txtFax.Text
            m_Contact.cnt_email = txtEmail.Text
            m_Contact.cnt_acc_man = m_Customer.cmp_acc_man
            m_Contact.Alternate_Rep = cboAlternate_Rep.SelectedValue
            m_Contact.Use_Account_No = txtUse_Account_No.Text

            m_Contact.active_y = chkActive.CheckState

            If cboWebAcc.CheckState = CheckState.Checked Then m_Contact.YesNoField3 = 1 Else m_Contact.YesNoField3 = 0
            m_Contact.sysmodified = Date.Now
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
            "SELECT		DISTINCT C.Fullname " &
            "FROM		cicntp C WITH (Nolock) " &
            "INNER JOIN	cicmpy P WITH (Nolock) ON C.cmp_wwn = P.cmp_wwn " &
            "WHERE	ISNULL(C.active_y,0) = 1 AND P.cmp_code = '" & txtFirstName.Text & "' " &
            "ORDER BY	C.FullName "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            'dtContacts = db.DataTable(strSql)

            'cboPred.DataSource = dtContacts

            'cboPred.ValueMember = Nothing
            'cboPred.DisplayMember = "Fullname"
            'cboPred.ValueMember = "Fullname"

            dtContacts = db.DataTable(strSql)

            If dtContacts.Rows.Count <> 0 Then

                For Each dtRow As DataRow In dtContacts.Rows

                    cboPred.Items.Add(dtRow.Item("Fullname").ToString.Trim)

                Next dtRow

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub cboAlternate_Rep_FillCombo()

        Dim strSql As String
        Dim dtAlt_Rep As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT     CAST(0 AS INT) AS Res_ID, CAST('' AS VARCHAR(64)) AS FullName " & _
            "UNION      " & _
            "SELECT		Res_ID, FullName " & _
            "FROM		HumRes WITH (Nolock) " & _
            "WHERE		Job_Title LIKE 'CSR%' AND BackOfficeBlocked = 0 " & _
            "ORDER BY	FullName "

            dtAlt_Rep = db.DataTable(strSql)

            cboAlternate_Rep.DataSource = dtAlt_Rep

            cboAlternate_Rep.ValueMember = Nothing
            cboAlternate_Rep.DisplayMember = "FullName"
            cboAlternate_Rep.ValueMember = "Res_ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Call Save()

    End Sub

    Private Sub frmCommunication_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        Call SetPermissions()

        Call LoadNewContactComboBoxes()

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

    'Private User_Rights As String = "READONLY"


    Private Sub LoadNewContactComboBoxes()

        Dim db As New cDBA
        Dim dtNamePreds As DataTable
        Dim dtLangs As DataTable

        'Dim rsNamePreds As New ADODB.Recordset
        'Dim rsLangs As New ADODB.Recordset
        Dim strSql As String

        Try

            ' Load Name Preds
            strSql = _
            "SELECT     PredCode " & _
            "FROM       Pred WITH (nolock) " & _
            "WHERE      PredCode IS NOT NULL " & _
            "ORDER BY   ID "

            dtNamePreds = db.DataTable(strSql)
            'rsNamePreds.Open(strSql, gConn.ConnectionString, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            For Each dtRow As DataRow In dtNamePreds.Rows
                cboPred.Items.Add(dtRow.Item("PredCode").ToString().Trim())
            Next

            'If rsNamePreds.RecordCount <> 0 Then
            '    While Not rsNamePreds.EOF
            '        cboPred.Items.Add(rsNamePreds.Fields("PredCode").Value)
            '        rsNamePreds.MoveNext()
            '    End While
            'End If
            'rsNamePreds.Close()

            If cboPred.Text = String.Empty Then cboPred.Text = "MR"

            ' Load Languages
            strSql = _
            "       SELECT 		1 AS TaalOrder, 'FR' AS TaalCode " & _
            "UNION  SELECT 		1 AS TaalOrder, 'EN' AS TaalCode " & _
            "UNION  SELECT     	2 as TaalOrder, TaalCode  " & _
            "       FROM       	Taal WITH (Nolock) " & _
            "       WHERE       TaalCode IS NOT NULL " & _
            "       ORDER BY   	TaalOrder, TaalCode "

            dtLangs = db.DataTable(strSql)
            If dtLangs.Rows.Count <> 0 Then
                For Each dtRow As DataRow In dtLangs.Rows
                    cboLang.Items.Add(dtRow.Item("TaalCode").ToString().Trim())
                Next
            End If
            'rsLangs.Open(strSql, gConn.ConnectionString, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            'If rsLangs.RecordCount <> 0 Then
            '    While Not rsLangs.EOF
            '        cboLang.Items.Add(rsLangs.Fields("TaalCode").Value)
            '        rsLangs.MoveNext()
            '    End While
            'End If
            'rsLangs.Close()
            If cboLang.Text = String.Empty Then cboLang.Text = "EN"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub cboProgram_Id_FillCombo()

        Dim strSql As String
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		0 AS CUS_PROG_ID, '' AS PROG_CD " & _
            "UNION " & _
            "SELECT		CUS_PROG_ID, ISNULL(PROG_CD, '') AS PROG_CD " & _
            "FROM		MDB_CUS_PROG WITH (Nolock) " & _
            "WHERE		CUS_NO = '" & m_Customer.cmp_code & "' AND " & _
            "           ISNULL(PROG_CD, '') <> '' AND " & _
            "           (START_DT <= GETDATE() AND END_DT >= GETDATE()) " & _
            "ORDER BY   PROG_CD "

            dtAlt_Rep = db.DataTable(strSql)
            cboAlternate_Rep.DataSource = dtAlt_Rep

            cboAlternate_Rep.DisplayMember = "PROG_CD"
            cboAlternate_Rep.ValueMember = "CUS_PROG_ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


End Class