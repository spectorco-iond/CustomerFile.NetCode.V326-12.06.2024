Public Class frmCustomer_Disruption

    Private db As New cDBA()
    Private dtDisruption As DataTable

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer

    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    Public Sub New(ByVal oCustomer As cCustomer, ByVal pstrOrd_No As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtCus_No.Text = oCustomer.cmp_code
        txtCmp_Name.Text = oCustomer.cmp_name
        txtOrd_No.Text = pstrOrd_No

        'Call Fill_Disruption()

    End Sub

    Public Sub New(ByVal oCustomer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtCus_No.Text = oCustomer.cmp_code
        txtCmp_Name.Text = oCustomer.cmp_name

        'Call Fill_Disruption()

    End Sub

    'Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click

    '    Call Menu_Save()

    'End Sub

    'Private Sub Menu_Save()

    '    Try

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Private Sub Fill_Disruption()

    '    Try

    '        Dim strSql As String = "SELECT * FROM MDB_CFG_DISRUPTION ORDER BY SORT_ORDER "
    '        dtDisruption = db.DataTable(strSql)
    '        If dtDisruption.Rows.Count <> 0 Then
    '            For Each dtRow As DataRow In dtDisruption.Rows
    '            Next
    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    'Private Sub frmQuote_Comments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    '    Try

    '        dgvDisruption.EndEdit()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    Private Sub frmCustomer_Disruption_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            dgvCheckList_CreateColumns(dgvDisruption)
            dgvCheckList_Fill(dgvDisruption)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub SetPermissions()

        'Dim db As New cDBA
        'Dim dt As DataTable
        'Dim strSql As String

        'strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
        'dt = db.DataTable(strSql)
        'If dt.Rows.Count <> 0 Then
        '    User_Rights = dt.Rows(0).Item("Access_Type").ToString
        'Else
        '    strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
        '    dt = db.DataTable(strSql)
        '    If dt.Rows.Count <> 0 Then
        '        User_Rights = dt.Rows(0).Item("Access_Type").ToString
        '    End If
        'End If

        'Select Case User_Rights
        '    Case "READWRITE"
        '        tsbSave.Enabled = True
        '        tsbNextStep.Enabled = True

        '    Case "SUPERUSER"
        '        tsbSave.Enabled = True
        '        tsbNextStep.Enabled = True

        '    Case "READONLY"
        '        tsClose.Visible = True
        '        Dim c As Control
        '        For Each c In Me.Controls
        '            If TypeOf c Is TextBox Then
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                'c.Enabled = False
        '                'c.BackColor = Color.White
        '            ElseIf TypeOf c Is ComboBox Then
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is CheckBox Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is RadioButton Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is Button Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            End If
        '        Next

        'End Select

    End Sub


#Region "LOAD OPTIONS ##########################################################"

    Private Sub dgvCheckList_CreateColumns(ByRef dgv As DataGridView)

        Try
            'If dtGeneral Is Nothing Then

            With dgv.Columns

                .Add(DGVTextBoxColumn("Disruption_ID", "Disruption_ID", 10))
                .Add(DGVCheckBoxColumn("CHECK_VALUE", "CHECK_VALUE", 40))
                .Add(DGVTextBoxColumn("Disruption_Desc", "Disruption_Desc", 300))
                .Add(DGVTextBoxColumn("Feedback_Text", "Disruption Text", 700))

            End With

            dgv.ColumnHeadersVisible = False
            dgv.RowHeadersVisible = False
            dgv.Columns(Disruption.DISRUPTION_ID).Visible = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCheckList_Fill(ByRef dgv As DataGridView)

        Try

            Dim strSql As String = ""
            strSql =
            "SELECT DISRUPTION_ID, CAST (0 AS BIT) AS CHECK_VALUE, DISRUPTION_DESC ,'' as Feedback_Text " &
            "FROM MDB_CFG_DISRUPTION WITH (Nolock) " &
            "WHERE ISNULL(SHOW_CSR, 0) = 1 " &
            "ORDER BY SORT_ORDER "

            dtDisruption = db.DataTable(strSql)

            dgv.DataSource = dtDisruption
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region

    Public Sub Menu_Save()

        ' Do nothing if form was not opened.
        'If Not m_blnOpened Then Exit Sub

        Try

            dgvDisruption.EndEdit()
            Call SaveCheckGrid(dgvDisruption)
            Me.Close()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveCheckGrid(ByRef dgv As DataGridView)

        Try

            ' First pass, we only save lines
            For Each dgvRow As DataGridViewRow In dgv.Rows

                If dgvRow.Cells(Disruption.CHECK_VALUE).Value <> 0 Then

                    Dim oFeedback As New cMDB_CUS_FEEDBACK
                    oFeedback.Cus_No = txtCus_No.Text
                    oFeedback.Ord_No = txtOrd_No.Text
                    oFeedback.Disruption_ID = dgvRow.Cells(Disruption.DISRUPTION_ID).Value
                    oFeedback.Feedback_Text = Trim(dgvRow.Cells(Disruption.Feedback_Text).Value.ToString)
                    oFeedback.Save()

                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Property Customer() As cCustomer
        Get
            Customer = m_Customer
        End Get
        Set(value As cCustomer)
            m_Customer = value
        End Set
    End Property

    Private Enum Disruption

        DISRUPTION_ID
        CHECK_VALUE
        DISRUPTION_DESC
        Feedback_Text

    End Enum

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click

        Call Menu_Save()

    End Sub

End Class