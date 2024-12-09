<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerContact
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerContact))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.cboPred = New System.Windows.Forms.ComboBox()
        Me.lblCCAsEmailTo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.cboLang = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboAlternate_Rep = New System.Windows.Forms.ComboBox()
        Me.lblUse_Account_No = New System.Windows.Forms.Label()
        Me.lblMsgUse_Account_No = New System.Windows.Forms.Label()
        Me.cboWebAcc = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblActive = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtUse_Account_No = New CustomerFile.xTextBox()
        Me.txtMobile = New CustomerFile.xTextBox()
        Me.txtFax = New CustomerFile.xTextBox()
        Me.txtID = New CustomerFile.xTextBox()
        Me.txtEmail = New CustomerFile.xTextBox()
        Me.txtExt = New CustomerFile.xTextBox()
        Me.txtTel = New CustomerFile.xTextBox()
        Me.txtLastName = New CustomerFile.xTextBox()
        Me.txtFirstName = New CustomerFile.xTextBox()
        Me.tsProgramMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Email Address"
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(414, 25)
        Me.tsProgramMenu.TabIndex = 39
        Me.tsProgramMenu.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSave.Enabled = False
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(35, 22)
        Me.tsSave.Text = "Save"
        '
        'tsClose
        '
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(40, 22)
        Me.tsClose.Text = "Close"
        Me.tsClose.Visible = False
        '
        'cboPred
        '
        Me.cboPred.FormattingEnabled = True
        Me.cboPred.Location = New System.Drawing.Point(119, 59)
        Me.cboPred.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPred.Name = "cboPred"
        Me.cboPred.Size = New System.Drawing.Size(196, 23)
        Me.cboPred.TabIndex = 36
        '
        'lblCCAsEmailTo
        '
        Me.lblCCAsEmailTo.AutoSize = True
        Me.lblCCAsEmailTo.Location = New System.Drawing.Point(7, 204)
        Me.lblCCAsEmailTo.Name = "lblCCAsEmailTo"
        Me.lblCCAsEmailTo.Size = New System.Drawing.Size(74, 15)
        Me.lblCCAsEmailTo.TabIndex = 30
        Me.lblCCAsEmailTo.Text = "Fax Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Pred Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Phone Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Last Name"
        '
        'lblCus_No
        '
        Me.lblCus_No.AutoSize = True
        Me.lblCus_No.Location = New System.Drawing.Point(7, 87)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.Size = New System.Drawing.Size(68, 15)
        Me.lblCus_No.TabIndex = 22
        Me.lblCus_No.Text = "First Name"
        '
        'cboLang
        '
        Me.cboLang.FormattingEnabled = True
        Me.cboLang.Location = New System.Drawing.Point(119, 130)
        Me.cboLang.Margin = New System.Windows.Forms.Padding(1)
        Me.cboLang.Name = "cboLang"
        Me.cboLang.Size = New System.Drawing.Size(196, 23)
        Me.cboLang.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Language"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Contact ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Mobile Phone"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 15)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Alternate Rep"
        '
        'cboAlternate_Rep
        '
        Me.cboAlternate_Rep.FormattingEnabled = True
        Me.cboAlternate_Rep.Location = New System.Drawing.Point(119, 247)
        Me.cboAlternate_Rep.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAlternate_Rep.Name = "cboAlternate_Rep"
        Me.cboAlternate_Rep.Size = New System.Drawing.Size(285, 23)
        Me.cboAlternate_Rep.TabIndex = 48
        '
        'lblUse_Account_No
        '
        Me.lblUse_Account_No.AutoSize = True
        Me.lblUse_Account_No.Location = New System.Drawing.Point(7, 275)
        Me.lblUse_Account_No.Name = "lblUse_Account_No"
        Me.lblUse_Account_No.Size = New System.Drawing.Size(85, 15)
        Me.lblUse_Account_No.TabIndex = 50
        Me.lblUse_Account_No.Text = "Use Account #"
        '
        'lblMsgUse_Account_No
        '
        Me.lblMsgUse_Account_No.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgUse_Account_No.Location = New System.Drawing.Point(206, 271)
        Me.lblMsgUse_Account_No.Name = "lblMsgUse_Account_No"
        Me.lblMsgUse_Account_No.Size = New System.Drawing.Size(208, 33)
        Me.lblMsgUse_Account_No.TabIndex = 51
        Me.lblMsgUse_Account_No.Text = "When used, OEI will say to use entered account number when choosing contact."
        '
        'cboWebAcc
        '
        Me.cboWebAcc.AutoSize = True
        Me.cboWebAcc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cboWebAcc.Location = New System.Drawing.Point(119, 301)
        Me.cboWebAcc.Name = "cboWebAcc"
        Me.cboWebAcc.Size = New System.Drawing.Size(15, 14)
        Me.cboWebAcc.TabIndex = 52
        Me.cboWebAcc.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 300)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 15)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Web Account"
        '
        'lblActive
        '
        Me.lblActive.AutoSize = True
        Me.lblActive.Location = New System.Drawing.Point(7, 325)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(41, 15)
        Me.lblActive.TabIndex = 55
        Me.lblActive.Text = "Active "
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Location = New System.Drawing.Point(119, 326)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 54
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtUse_Account_No
        '
        Me.txtUse_Account_No.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUse_Account_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtUse_Account_No.DataLength = CType(20, Long)
        Me.txtUse_Account_No.DataType = CustomerFile.CDataType.dtString
        Me.txtUse_Account_No.DateValue = New Date(CType(0, Long))
        Me.txtUse_Account_No.DecimalDigits = CType(0, Long)
        Me.txtUse_Account_No.ForeColor = System.Drawing.Color.Black
        Me.txtUse_Account_No.Location = New System.Drawing.Point(119, 272)
        Me.txtUse_Account_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUse_Account_No.Mask = Nothing
        Me.txtUse_Account_No.Name = "txtUse_Account_No"
        Me.txtUse_Account_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUse_Account_No.OldValue = ""
        Me.txtUse_Account_No.Size = New System.Drawing.Size(87, 21)
        Me.txtUse_Account_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUse_Account_No.StringValue = Nothing
        Me.txtUse_Account_No.TabIndex = 49
        Me.txtUse_Account_No.TextDataID = Nothing
        '
        'txtMobile
        '
        Me.txtMobile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobile.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtMobile.DataLength = CType(0, Long)
        Me.txtMobile.DataType = CustomerFile.CDataType.dtString
        Me.txtMobile.DateValue = New Date(CType(0, Long))
        Me.txtMobile.DecimalDigits = CType(0, Long)
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.Location = New System.Drawing.Point(119, 178)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(1)
        Me.txtMobile.Mask = Nothing
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMobile.OldValue = ""
        Me.txtMobile.Size = New System.Drawing.Size(285, 21)
        Me.txtMobile.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtMobile.StringValue = Nothing
        Me.txtMobile.TabIndex = 46
        Me.txtMobile.TextDataID = Nothing
        '
        'txtFax
        '
        Me.txtFax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFax.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtFax.DataLength = CType(0, Long)
        Me.txtFax.DataType = CustomerFile.CDataType.dtString
        Me.txtFax.DateValue = New Date(CType(0, Long))
        Me.txtFax.DecimalDigits = CType(0, Long)
        Me.txtFax.ForeColor = System.Drawing.Color.Black
        Me.txtFax.Location = New System.Drawing.Point(119, 201)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFax.Mask = Nothing
        Me.txtFax.Name = "txtFax"
        Me.txtFax.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFax.OldValue = ""
        Me.txtFax.Size = New System.Drawing.Size(285, 21)
        Me.txtFax.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtFax.StringValue = Nothing
        Me.txtFax.TabIndex = 41
        Me.txtFax.TextDataID = Nothing
        '
        'txtID
        '
        Me.txtID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtID.DataLength = CType(0, Long)
        Me.txtID.DataType = CustomerFile.CDataType.dtString
        Me.txtID.DateValue = New Date(CType(0, Long))
        Me.txtID.DecimalDigits = CType(0, Long)
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(119, 36)
        Me.txtID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtID.Mask = Nothing
        Me.txtID.Name = "txtID"
        Me.txtID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtID.OldValue = ""
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(196, 21)
        Me.txtID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtID.StringValue = Nothing
        Me.txtID.TabIndex = 37
        Me.txtID.TextDataID = Nothing
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmail.DataLength = CType(0, Long)
        Me.txtEmail.DataType = CustomerFile.CDataType.dtString
        Me.txtEmail.DateValue = New Date(CType(0, Long))
        Me.txtEmail.DecimalDigits = CType(0, Long)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.Location = New System.Drawing.Point(119, 224)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmail.Mask = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmail.OldValue = ""
        Me.txtEmail.Size = New System.Drawing.Size(285, 21)
        Me.txtEmail.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmail.StringValue = Nothing
        Me.txtEmail.TabIndex = 31
        Me.txtEmail.TextDataID = Nothing
        '
        'txtExt
        '
        Me.txtExt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtExt.DataLength = CType(0, Long)
        Me.txtExt.DataType = CustomerFile.CDataType.dtString
        Me.txtExt.DateValue = New Date(CType(0, Long))
        Me.txtExt.DecimalDigits = CType(0, Long)
        Me.txtExt.ForeColor = System.Drawing.Color.Black
        Me.txtExt.Location = New System.Drawing.Point(317, 155)
        Me.txtExt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtExt.Mask = Nothing
        Me.txtExt.Name = "txtExt"
        Me.txtExt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtExt.OldValue = ""
        Me.txtExt.Size = New System.Drawing.Size(87, 21)
        Me.txtExt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtExt.StringValue = Nothing
        Me.txtExt.TabIndex = 29
        Me.txtExt.TextDataID = Nothing
        '
        'txtTel
        '
        Me.txtTel.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtTel.DataLength = CType(0, Long)
        Me.txtTel.DataType = CustomerFile.CDataType.dtString
        Me.txtTel.DateValue = New Date(CType(0, Long))
        Me.txtTel.DecimalDigits = CType(0, Long)
        Me.txtTel.ForeColor = System.Drawing.Color.Black
        Me.txtTel.Location = New System.Drawing.Point(119, 155)
        Me.txtTel.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTel.Mask = Nothing
        Me.txtTel.Name = "txtTel"
        Me.txtTel.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTel.OldValue = ""
        Me.txtTel.Size = New System.Drawing.Size(196, 21)
        Me.txtTel.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtTel.StringValue = Nothing
        Me.txtTel.TabIndex = 27
        Me.txtTel.TextDataID = Nothing
        '
        'txtLastName
        '
        Me.txtLastName.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtLastName.DataLength = CType(0, Long)
        Me.txtLastName.DataType = CustomerFile.CDataType.dtString
        Me.txtLastName.DateValue = New Date(CType(0, Long))
        Me.txtLastName.DecimalDigits = CType(0, Long)
        Me.txtLastName.ForeColor = System.Drawing.Color.Black
        Me.txtLastName.Location = New System.Drawing.Point(119, 107)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtLastName.Mask = Nothing
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLastName.OldValue = ""
        Me.txtLastName.Size = New System.Drawing.Size(196, 21)
        Me.txtLastName.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtLastName.StringValue = Nothing
        Me.txtLastName.TabIndex = 25
        Me.txtLastName.TextDataID = Nothing
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtFirstName.DataLength = CType(0, Long)
        Me.txtFirstName.DataType = CustomerFile.CDataType.dtString
        Me.txtFirstName.DateValue = New Date(CType(0, Long))
        Me.txtFirstName.DecimalDigits = CType(0, Long)
        Me.txtFirstName.ForeColor = System.Drawing.Color.Black
        Me.txtFirstName.Location = New System.Drawing.Point(119, 84)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFirstName.Mask = Nothing
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFirstName.OldValue = ""
        Me.txtFirstName.Size = New System.Drawing.Size(196, 21)
        Me.txtFirstName.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtFirstName.StringValue = Nothing
        Me.txtFirstName.TabIndex = 23
        Me.txtFirstName.TextDataID = Nothing
        '
        'frmCustomerContact
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(414, 349)
        Me.Controls.Add(Me.lblActive)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboWebAcc)
        Me.Controls.Add(Me.lblMsgUse_Account_No)
        Me.Controls.Add(Me.lblUse_Account_No)
        Me.Controls.Add(Me.txtUse_Account_No)
        Me.Controls.Add(Me.cboAlternate_Rep)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboLang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.cboPred)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblCCAsEmailTo)
        Me.Controls.Add(Me.txtExt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblCus_No)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCustomerContact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CUS-CNT-001"
        Me.Text = "Contact Maintenance"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFax As CustomerFile.xTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As CustomerFile.xTextBox
    Friend WithEvents cboPred As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmail As CustomerFile.xTextBox
    Friend WithEvents lblCCAsEmailTo As System.Windows.Forms.Label
    Friend WithEvents txtExt As CustomerFile.xTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTel As CustomerFile.xTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As CustomerFile.xTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents cboLang As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As CustomerFile.xTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboAlternate_Rep As System.Windows.Forms.ComboBox
    Friend WithEvents lblUse_Account_No As System.Windows.Forms.Label
    Friend WithEvents txtUse_Account_No As CustomerFile.xTextBox
    Friend WithEvents lblMsgUse_Account_No As System.Windows.Forms.Label
    Friend WithEvents cboWebAcc As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblActive As Label
    Friend WithEvents chkActive As CheckBox
End Class
