Public Class frmMDB_CUS_SHIP

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer
    Private m_Cus_Ship As cMdb_Cus_Ship

    Private db As New cDBA()

    Private dtProgram_Id As DataTable
    Private dtShip_Via_Cd As DataTable
    Private dtCountry_Cd As DataTable

#Region "PUBLIC CONSTRUCTORS ##################################################"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer

        Call Insert()

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pCus_Ship As cMdb_Cus_Ship)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Cus_Ship = pCus_Ship

    End Sub

#End Region


#Region "PRIVATE EVENTS - FORM ################################################"

    Private Sub frmPrograms_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If m_Cus_Ship Is Nothing Then
                m_Cus_Ship = New cMdb_Cus_Ship()            
            End If

            Call FillFields()
            'Ion
            Call cboCountry_Cd_FillCombo()
            'Ion
            Call cboCus_Alt_Adr_Cd_FillCombo()
            Call cboGroup_Cd_FillCombo()
            Call cboProgram_Id_FillCombo()
            Call cboShip_Via_Cd_FillCombo()

            'Call SetVisibleFields()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region



#Region "PRIVATE EVENTS - TOOLSTRIP BUTTONS ###################################"

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Try

            Call Save()
            Me.Close()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try


    End Sub

    'Private Sub tsDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsDelete.Click

    '    Call Delete()

    'End Sub

#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    Private Sub Insert()

        Try
            m_Cus_Ship = New cMdb_Cus_Ship()
            m_Cus_Ship.Cus_No = m_Customer.cmp_code

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()

        Try
            'Dim oBUS As New cMdb_Cus_Ship_BUS()

            If m_Cus_Ship Is Nothing Then m_Cus_Ship = New cMdb_Cus_Ship()

            m_Cus_Ship.Group_Cd = cboGroup_Cd.Text
            m_Cus_Ship.Cus_No = txtCus_No.Text
            m_Cus_Ship.Cus_Alt_Adr_Cd = cboCus_Alt_Adr_Cd.Text
            'Ion---- 
            m_Cus_Ship.Country_Cd = Trim(cboCountry.SelectedValue)  'txtCountry_Cd.Text
            'Ion-----
            If Not (cboProgram_Id.SelectedValue Is Nothing) Then m_Cus_Ship.Prog_Id = cboProgram_Id.SelectedValue

            m_Cus_Ship.Ship_Via_Cd = Trim(cboShip_Via_Cd.SelectedValue)

            m_Cus_Ship.Ship_Via_Account = txtShip_Via_Account.Text
            m_Cus_Ship.Printer_Comment = txtPrinter_Comment.Text
            m_Cus_Ship.Printer_Instructions = txtPrinter_Instructions.Text
            m_Cus_Ship.Packer_Comment = txtPacker_Comment.Text
            m_Cus_Ship.Packer_Instructions = txtPacker_Instructions.Text
            m_Cus_Ship.Ship_Instructions_1 = txtShip_Instructions_1.Text
            m_Cus_Ship.Ship_Instructions_2 = txtShip_Instructions_2.Text
            ' Ion this property he has lack
            m_Cus_Ship.Ship_Comments = txtShip_Comments.Text
            'Ion
            m_Cus_Ship.Always_Use = chkAlways_Use.Checked
            m_Cus_Ship.Never_Use = chkNever_Use.Checked
            m_Cus_Ship.No_Charge = chkNo_Charge.Checked
            m_Cus_Ship.Samples_Only = chkSamples_Only.Checked
            m_Cus_Ship.User_Login = Environment.UserName
            m_Cus_Ship.Update_Ts = Date.Now

            m_Cus_Ship.Save()

            txtCus_Ship_ID.Text = m_Cus_Ship.Cus_Ship_Id
            txtUser_Login.Text = m_Cus_Ship.User_Login
            txtUpdate_TS.Text = m_Cus_Ship.Update_Ts

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub



    Private Sub Delete()

        Try

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Shadows Sub Load()

    '    Try

    '        'Dim oBUS As New cMdb_Cus_Ship_BUS()
    '        Dim oLoadProgram As New cMdb_Cus_Ship()

    '        oLoadProgram = m_Cus_Ship_BUS.Load(1)

    '        If oLoadProgram.Cus_Prog_Id = 0 Then
    '            MsgBox("Program code does not exist.")
    '        Else
    '            m_Cus_Ship = oLoadProgram

    '            Call ClearFields()
    '            Call FillFields()
    '            Call SetVisibleFields()

    '            txtStart_Dt.Focus()

    '            Select Case m_Cus_Ship_Type

    '                Case "Program"
    '                    Me.Text = "Program Maintenance"

    '                Case "Special Pricing"
    '                    Me.Text = "Special Pricing Maintenance"

    '            End Select

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub ClearFields()

        txtCus_Ship_ID.Text = "0"
        cboGroup_Cd.Text = String.Empty
        txtCus_No.Text = String.Empty
        cboCus_Alt_Adr_Cd.Text = String.Empty
        '   txtCountry_Cd.Text = String.Empty

        cboProgram_Id.SelectedValue = 0
        cboShip_Via_Cd.SelectedValue = 0
        txtShip_Via_Account.Text = String.Empty
        txtPrinter_Comment.Text = String.Empty
        txtPrinter_Instructions.Text = String.Empty
        txtPacker_Comment.Text = String.Empty
        txtPacker_Instructions.Text = String.Empty
        txtShip_Instructions_1.Text = String.Empty
        txtShip_Instructions_2.Text = String.Empty
        chkAlways_Use.Checked = String.Empty
        chkNever_Use.Checked = String.Empty
        chkNo_Charge.Checked = String.Empty
        chkSamples_Only.Checked = String.Empty
        txtUser_Login.Text = String.Empty
        txtUpdate_TS.Text = String.Empty

    End Sub

    Private Sub FillFields()

        txtCus_Ship_ID.Text = m_Cus_Ship.Cus_Ship_Id
        cboGroup_Cd.Text = m_Cus_Ship.Group_Cd
        txtCus_No.Text = m_Cus_Ship.Cus_No
        cboCus_Alt_Adr_Cd.Text = m_Cus_Ship.Cus_Alt_Adr_Cd

        'Ion has put comments, because it has all time same value
        ' txtCountry_Cd.Text = m_Cus_Ship.Country_Cd
        Call cboCountry_Cd_FillCombo()

        cboProgram_Id.SelectedValue = m_Cus_Ship.Prog_Id
        cboShip_Via_Cd.SelectedValue = m_Cus_Ship.Ship_Via_Cd
        If m_Cus_Ship.Ship_Via_Account.Trim = String.Empty Then
            txtShip_Comments.Text = m_Cus_Ship.Ship_Comments.Trim
            txtShip_Comments.Visible = True
            lblShip_Comments.Visible = True
        Else
            txtShip_Via_Account.Text = m_Cus_Ship.Ship_Via_Account.Trim
        End If
        txtPrinter_Comment.Text = m_Cus_Ship.Printer_Comment
        txtPrinter_Instructions.Text = m_Cus_Ship.Printer_Instructions
        txtPacker_Comment.Text = m_Cus_Ship.Packer_Comment
        txtPacker_Instructions.Text = m_Cus_Ship.Packer_Instructions
        txtShip_Instructions_1.Text = m_Cus_Ship.Ship_Instructions_1
        txtShip_Instructions_2.Text = m_Cus_Ship.Ship_Instructions_2

        ' Ion this property he lack
        m_Cus_Ship.Ship_Comments = txtShip_Comments.Text
        'Ion

        chkAlways_Use.Checked = m_Cus_Ship.Always_Use
        chkNever_Use.Checked = m_Cus_Ship.Never_Use
        chkNo_Charge.Checked = m_Cus_Ship.No_Charge
        chkSamples_Only.Checked = m_Cus_Ship.Samples_Only
        txtUser_Login.Text = m_Cus_Ship.User_Login
        If m_Cus_Ship.Update_Ts.Year <> 1 Then txtUpdate_TS.Text = m_Cus_Ship.Update_Ts

    End Sub

#End Region



#Region "PRIVATE COMBOBOX ROUTINES ############################################"

    Private Sub cboCus_Alt_Adr_Cd_FillCombo()

        Dim strSql As String
        Dim dtCombo As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		cus_alt_adr_cd " & _
            "FROM		ARALTADR_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' " & _
            "ORDER BY	cus_alt_adr_cd "

            dtCombo = db.DataTable(strSql)

            cboCus_Alt_Adr_Cd.Items.Add("") ' Add an empty string

            If dtCombo.Rows.Count <> 0 Then

                For Each dtRow As DataRow In dtCombo.Rows

                    cboCus_Alt_Adr_Cd.Items.Add(dtRow.Item("cus_alt_adr_cd").ToString.Trim)

                Next dtRow

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub cboGroup_Cd_FillCombo()

        Dim strSql As String
        Dim dtCombo As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		DISTINCT ISNULL(Cus_Note_3, '') AS Cus_Note_3 " & _
            "FROM		arcusfil_sql " & _
            "ORDER BY	ISNULL(Cus_Note_3, '') "

            dtCombo = db.DataTable(strSql)

            'cboGroup_Cd.Items.Add(" ") ' No need to add here, query gives an empty line

            If dtCombo.Rows.Count <> 0 Then

                For Each dtRow As DataRow In dtCombo.Rows

                    cboGroup_Cd.Items.Add(dtRow.Item("Cus_Note_3").ToString.Trim)

                Next dtRow

            End If

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

            dtProgram_Id = db.DataTable(strSql)
            cboProgram_Id.DataSource = dtProgram_Id

            cboProgram_Id.DisplayMember = "PROG_CD"
            cboProgram_Id.ValueMember = "CUS_PROG_ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub cboShip_Via_Cd_FillCombo()

        Dim strSql As String
        Dim dtShip_Via_Cd As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		'' AS Sy_Code, '' AS Code_Desc " & _
            "UNION " & _
            "SELECT		Sy_Code, RTRIM(Code_Desc) + ' (' + RTRIM(Sy_Code) + ')' AS Code_Desc " & _
            "FROM		SYCDEFIL_SQL WITH (Nolock) " & _
            "WHERE      Cd_Type = 'V' " & _
            "ORDER BY	Code_Desc "

            dtShip_Via_Cd = db.DataTable(strSql)
            cboShip_Via_Cd.DataSource = dtShip_Via_Cd

            cboShip_Via_Cd.DisplayMember = "Code_Desc"
            cboShip_Via_Cd.ValueMember = "Sy_Code"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    'Ion----
    Private Sub cboCountry_Cd_FillCombo()
        Dim strSql As String = ""
        Dim db As New cDBA
        Try
            If Trim(m_Cus_Ship.Country_Cd) = "" Then
                strSql = _
                 " SELECT CAST('' AS CHAR(3)) AS landcode,CAST('' AS VARCHAR(60)) AS oms60_0 " & _
                 " UNION ALL " & _
                 " SELECT landcode, oms60_0 from land WHERE landcode in ('CA','US') " & _
                 " UNION ALL " & _
                 " SELECT landcode, oms60_0 FROM land WHERE landcode not in ('CA','US') "
            ElseIf Trim(m_Cus_Ship.Country_Cd) = "CA" Then
                strSql = _
                    " SELECT landcode, oms60_0 FROM land WHERE landcode in ('CA', 'US') order by ID asc"
            ElseIf Trim(m_Cus_Ship.Country_Cd) = "US" Then
                strSql = _
                    " SELECT landcode, oms60_0 FROM land WHERE landcode in ('US', 'CA') order by ID desc"
            ElseIf Trim(m_Cus_Ship.Country_Cd) <> "CA" And Trim(m_Cus_Ship.Country_Cd) <> "US" Then
                strSql = _
                   " SELECT landcode, oms60_0 FROM land WHERE landcode = '" & Trim(m_Cus_Ship.Country_Cd) & "'" & _
                   " UNION " & _
                   " SELECT landcode, oms60_0 FROM land WHERE landcode in ('US', 'CA')"
            End If

            dtCountry_Cd = db.DataTable(strSql)

            If dtCountry_Cd.Rows.Count <> 0 Then
                cboCountry.DataSource = dtCountry_Cd

                cboCountry.DisplayMember = "oms60_0"
                cboCountry.ValueMember = "landcode"
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    'Ion----
#End Region

#Region "ENUMERATORS ##########################################################"

    Private Enum ItemColumn
        CUS_PROG_ITEM_LIST_ID
        CUS_PROG_ID
        ITEM_CD
        ITEM_NO
        EQP_LEVEL
        EQP_COLUMN
        EQP_PCT
        UNIT_PRICE
        MIN_QTY_ORD
        USER_LOGIN
        UPDATE_TS
    End Enum

    Private Enum Items
        CUS_PROG_ITEM_LIST_ID
        CUS_PROG_ID
        ITEM_CD
        ITEM_NO
        UNIT_PRICE
        EQP_PCT
        MIN_QTY_ORD
        USER_LOGIN
        UPDATE_TS
        DIRTY
    End Enum

#End Region


#Region "PUBLIC PROPERTIES ####################################################"

    Public Property Customer() As cCustomer
        Get
            Customer = m_Customer
        End Get
        Set(value As cCustomer)
            m_Customer = value
        End Set
    End Property

    Public Property Program() As cMdb_Cus_Ship
        Get
            Program = m_Cus_Ship
        End Get
        Set(value As cMdb_Cus_Ship)
            m_Cus_Ship = value
        End Set
    End Property

#End Region


    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click

        Me.Close()

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
            txtCus_No.Focus()
        End If

    End Sub

End Class