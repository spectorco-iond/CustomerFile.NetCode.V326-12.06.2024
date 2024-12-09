<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDB_CUS_SHIP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDB_CUS_SHIP))
        Me.gbProgramHeader = New System.Windows.Forms.GroupBox()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.lblShip_Comments = New System.Windows.Forms.Label()
        Me.lblCus_Ship_ID = New System.Windows.Forms.Label()
        Me.cboCus_Alt_Adr_Cd = New System.Windows.Forms.ComboBox()
        Me.chkSamples_Only = New System.Windows.Forms.CheckBox()
        Me.chkNo_Charge = New System.Windows.Forms.CheckBox()
        Me.chkNever_Use = New System.Windows.Forms.CheckBox()
        Me.chkAlways_Use = New System.Windows.Forms.CheckBox()
        Me.cboShip_Via_Cd = New System.Windows.Forms.ComboBox()
        Me.cboGroup_Cd = New System.Windows.Forms.ComboBox()
        Me.cboProgram_Id = New System.Windows.Forms.ComboBox()
        Me.lblUpdate_TS = New System.Windows.Forms.Label()
        Me.lblUser_Login = New System.Windows.Forms.Label()
        Me.lblSamples_Only = New System.Windows.Forms.Label()
        Me.lblNo_Charge = New System.Windows.Forms.Label()
        Me.lblNever_Use = New System.Windows.Forms.Label()
        Me.lblAlways_Use = New System.Windows.Forms.Label()
        Me.lblShip_Instructions_2 = New System.Windows.Forms.Label()
        Me.lblPrinter_Instructions = New System.Windows.Forms.Label()
        Me.lblShip_Instructions_1 = New System.Windows.Forms.Label()
        Me.lblPacker_Instructions = New System.Windows.Forms.Label()
        Me.lblPacker_Comment = New System.Windows.Forms.Label()
        Me.lblProgram_Cd = New System.Windows.Forms.Label()
        Me.lblPrinter_Comment = New System.Windows.Forms.Label()
        Me.lblShip_Via_Account = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblGroup_Cd = New System.Windows.Forms.Label()
        Me.lblCountry_Cd = New System.Windows.Forms.Label()
        Me.lblCus_Alt_Adr_Cd = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lsSeparator1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.txtShip_Comments = New CustomerFile.xTextBox()
        Me.txtUpdate_TS = New CustomerFile.xTextBox()
        Me.txtUser_Login = New CustomerFile.xTextBox()
        Me.XTextBox17 = New CustomerFile.xTextBox()
        Me.XTextBox16 = New CustomerFile.xTextBox()
        Me.XTextBox14 = New CustomerFile.xTextBox()
        Me.XTextBox13 = New CustomerFile.xTextBox()
        Me.txtShip_Instructions_2 = New CustomerFile.xTextBox()
        Me.txtPrinter_Instructions = New CustomerFile.xTextBox()
        Me.txtShip_Instructions_1 = New CustomerFile.xTextBox()
        Me.txtPacker_Instructions = New CustomerFile.xTextBox()
        Me.txtPacker_Comment = New CustomerFile.xTextBox()
        Me.txtPrinter_Comment = New CustomerFile.xTextBox()
        Me.txtShip_Via_Account = New CustomerFile.xTextBox()
        Me.txtCus_Ship_ID = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.gbProgramHeader.SuspendLayout()
        Me.tsProgramMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProgramHeader
        '
        Me.gbProgramHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramHeader.Controls.Add(Me.cboCountry)
        Me.gbProgramHeader.Controls.Add(Me.txtShip_Comments)
        Me.gbProgramHeader.Controls.Add(Me.lblShip_Comments)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_Ship_ID)
        Me.gbProgramHeader.Controls.Add(Me.cboCus_Alt_Adr_Cd)
        Me.gbProgramHeader.Controls.Add(Me.chkSamples_Only)
        Me.gbProgramHeader.Controls.Add(Me.chkNo_Charge)
        Me.gbProgramHeader.Controls.Add(Me.chkNever_Use)
        Me.gbProgramHeader.Controls.Add(Me.chkAlways_Use)
        Me.gbProgramHeader.Controls.Add(Me.cboShip_Via_Cd)
        Me.gbProgramHeader.Controls.Add(Me.cboGroup_Cd)
        Me.gbProgramHeader.Controls.Add(Me.cboProgram_Id)
        Me.gbProgramHeader.Controls.Add(Me.txtUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.txtUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.lblUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox17)
        Me.gbProgramHeader.Controls.Add(Me.lblSamples_Only)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox16)
        Me.gbProgramHeader.Controls.Add(Me.lblNo_Charge)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox14)
        Me.gbProgramHeader.Controls.Add(Me.lblNever_Use)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox13)
        Me.gbProgramHeader.Controls.Add(Me.lblAlways_Use)
        Me.gbProgramHeader.Controls.Add(Me.txtShip_Instructions_2)
        Me.gbProgramHeader.Controls.Add(Me.lblShip_Instructions_2)
        Me.gbProgramHeader.Controls.Add(Me.txtPrinter_Instructions)
        Me.gbProgramHeader.Controls.Add(Me.lblPrinter_Instructions)
        Me.gbProgramHeader.Controls.Add(Me.txtShip_Instructions_1)
        Me.gbProgramHeader.Controls.Add(Me.lblShip_Instructions_1)
        Me.gbProgramHeader.Controls.Add(Me.lblPacker_Instructions)
        Me.gbProgramHeader.Controls.Add(Me.txtPacker_Instructions)
        Me.gbProgramHeader.Controls.Add(Me.txtPacker_Comment)
        Me.gbProgramHeader.Controls.Add(Me.lblPacker_Comment)
        Me.gbProgramHeader.Controls.Add(Me.lblProgram_Cd)
        Me.gbProgramHeader.Controls.Add(Me.txtPrinter_Comment)
        Me.gbProgramHeader.Controls.Add(Me.lblPrinter_Comment)
        Me.gbProgramHeader.Controls.Add(Me.lblShip_Via_Account)
        Me.gbProgramHeader.Controls.Add(Me.txtShip_Via_Account)
        Me.gbProgramHeader.Controls.Add(Me.Label5)
        Me.gbProgramHeader.Controls.Add(Me.lblGroup_Cd)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_Ship_ID)
        Me.gbProgramHeader.Controls.Add(Me.lblCountry_Cd)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_Alt_Adr_Cd)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_No)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_No)
        Me.gbProgramHeader.Controls.Add(Me.ShapeContainer1)
        Me.gbProgramHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgramHeader.Location = New System.Drawing.Point(10, 26)
        Me.gbProgramHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Name = "gbProgramHeader"
        Me.gbProgramHeader.Padding = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Size = New System.Drawing.Size(650, 370)
        Me.gbProgramHeader.TabIndex = 4
        Me.gbProgramHeader.TabStop = False
        Me.gbProgramHeader.Text = "Shipping Information"
        '
        'cboCountry
        '
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(131, 90)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(188, 23)
        Me.cboCountry.TabIndex = 47
        '
        'lblShip_Comments
        '
        Me.lblShip_Comments.BackColor = System.Drawing.SystemColors.Control
        Me.lblShip_Comments.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShip_Comments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip_Comments.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShip_Comments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShip_Comments.Location = New System.Drawing.Point(6, 263)
        Me.lblShip_Comments.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShip_Comments.Name = "lblShip_Comments"
        Me.lblShip_Comments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShip_Comments.Size = New System.Drawing.Size(122, 25)
        Me.lblShip_Comments.TabIndex = 45
        Me.lblShip_Comments.Text = "Ship Comments"
        '
        'lblCus_Ship_ID
        '
        Me.lblCus_Ship_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_Ship_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_Ship_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_Ship_ID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_Ship_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_Ship_ID.Location = New System.Drawing.Point(327, 93)
        Me.lblCus_Ship_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_Ship_ID.Name = "lblCus_Ship_ID"
        Me.lblCus_Ship_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_Ship_ID.Size = New System.Drawing.Size(120, 20)
        Me.lblCus_Ship_ID.TabIndex = 15
        Me.lblCus_Ship_ID.Text = "Customer Ship ID"
        '
        'cboCus_Alt_Adr_Cd
        '
        Me.cboCus_Alt_Adr_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCus_Alt_Adr_Cd.FormattingEnabled = True
        Me.cboCus_Alt_Adr_Cd.Location = New System.Drawing.Point(131, 65)
        Me.cboCus_Alt_Adr_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.cboCus_Alt_Adr_Cd.Name = "cboCus_Alt_Adr_Cd"
        Me.cboCus_Alt_Adr_Cd.Size = New System.Drawing.Size(188, 23)
        Me.cboCus_Alt_Adr_Cd.TabIndex = 6
        '
        'chkSamples_Only
        '
        Me.chkSamples_Only.AutoSize = True
        Me.chkSamples_Only.Location = New System.Drawing.Point(452, 310)
        Me.chkSamples_Only.Name = "chkSamples_Only"
        Me.chkSamples_Only.Size = New System.Drawing.Size(15, 14)
        Me.chkSamples_Only.TabIndex = 39
        Me.chkSamples_Only.UseVisualStyleBackColor = True
        '
        'chkNo_Charge
        '
        Me.chkNo_Charge.AutoSize = True
        Me.chkNo_Charge.Location = New System.Drawing.Point(452, 287)
        Me.chkNo_Charge.Name = "chkNo_Charge"
        Me.chkNo_Charge.Size = New System.Drawing.Size(15, 14)
        Me.chkNo_Charge.TabIndex = 36
        Me.chkNo_Charge.UseVisualStyleBackColor = True
        '
        'chkNever_Use
        '
        Me.chkNever_Use.AutoSize = True
        Me.chkNever_Use.Location = New System.Drawing.Point(132, 310)
        Me.chkNever_Use.Name = "chkNever_Use"
        Me.chkNever_Use.Size = New System.Drawing.Size(15, 14)
        Me.chkNever_Use.TabIndex = 33
        Me.chkNever_Use.UseVisualStyleBackColor = True
        '
        'chkAlways_Use
        '
        Me.chkAlways_Use.AutoSize = True
        Me.chkAlways_Use.Location = New System.Drawing.Point(132, 287)
        Me.chkAlways_Use.Name = "chkAlways_Use"
        Me.chkAlways_Use.Size = New System.Drawing.Size(15, 14)
        Me.chkAlways_Use.TabIndex = 30
        Me.chkAlways_Use.UseVisualStyleBackColor = True
        '
        'cboShip_Via_Cd
        '
        Me.cboShip_Via_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShip_Via_Cd.FormattingEnabled = True
        Me.cboShip_Via_Cd.Location = New System.Drawing.Point(451, 42)
        Me.cboShip_Via_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.cboShip_Via_Cd.Name = "cboShip_Via_Cd"
        Me.cboShip_Via_Cd.Size = New System.Drawing.Size(188, 23)
        Me.cboShip_Via_Cd.TabIndex = 12
        '
        'cboGroup_Cd
        '
        Me.cboGroup_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGroup_Cd.FormattingEnabled = True
        Me.cboGroup_Cd.Location = New System.Drawing.Point(131, 17)
        Me.cboGroup_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.cboGroup_Cd.Name = "cboGroup_Cd"
        Me.cboGroup_Cd.Size = New System.Drawing.Size(188, 23)
        Me.cboGroup_Cd.TabIndex = 2
        '
        'cboProgram_Id
        '
        Me.cboProgram_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProgram_Id.FormattingEnabled = True
        Me.cboProgram_Id.Location = New System.Drawing.Point(451, 17)
        Me.cboProgram_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.cboProgram_Id.Name = "cboProgram_Id"
        Me.cboProgram_Id.Size = New System.Drawing.Size(188, 23)
        Me.cboProgram_Id.TabIndex = 10
        '
        'lblUpdate_TS
        '
        Me.lblUpdate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblUpdate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdate_TS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUpdate_TS.Location = New System.Drawing.Point(326, 341)
        Me.lblUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUpdate_TS.Name = "lblUpdate_TS"
        Me.lblUpdate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdate_TS.Size = New System.Drawing.Size(122, 25)
        Me.lblUpdate_TS.TabIndex = 43
        Me.lblUpdate_TS.Text = "Modified Date"
        '
        'lblUser_Login
        '
        Me.lblUser_Login.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser_Login.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser_Login.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser_Login.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUser_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUser_Login.Location = New System.Drawing.Point(6, 341)
        Me.lblUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUser_Login.Name = "lblUser_Login"
        Me.lblUser_Login.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser_Login.Size = New System.Drawing.Size(122, 25)
        Me.lblUser_Login.TabIndex = 41
        Me.lblUser_Login.Text = "Modified By"
        '
        'lblSamples_Only
        '
        Me.lblSamples_Only.BackColor = System.Drawing.SystemColors.Control
        Me.lblSamples_Only.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSamples_Only.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSamples_Only.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSamples_Only.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSamples_Only.Location = New System.Drawing.Point(326, 309)
        Me.lblSamples_Only.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSamples_Only.Name = "lblSamples_Only"
        Me.lblSamples_Only.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSamples_Only.Size = New System.Drawing.Size(122, 18)
        Me.lblSamples_Only.TabIndex = 38
        Me.lblSamples_Only.Text = "Samples Only"
        '
        'lblNo_Charge
        '
        Me.lblNo_Charge.BackColor = System.Drawing.SystemColors.Control
        Me.lblNo_Charge.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNo_Charge.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo_Charge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNo_Charge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNo_Charge.Location = New System.Drawing.Point(326, 286)
        Me.lblNo_Charge.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNo_Charge.Name = "lblNo_Charge"
        Me.lblNo_Charge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNo_Charge.Size = New System.Drawing.Size(122, 25)
        Me.lblNo_Charge.TabIndex = 35
        Me.lblNo_Charge.Text = "No Charge"
        '
        'lblNever_Use
        '
        Me.lblNever_Use.BackColor = System.Drawing.SystemColors.Control
        Me.lblNever_Use.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNever_Use.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNever_Use.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNever_Use.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNever_Use.Location = New System.Drawing.Point(6, 309)
        Me.lblNever_Use.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNever_Use.Name = "lblNever_Use"
        Me.lblNever_Use.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNever_Use.Size = New System.Drawing.Size(122, 18)
        Me.lblNever_Use.TabIndex = 32
        Me.lblNever_Use.Text = "Never Use"
        '
        'lblAlways_Use
        '
        Me.lblAlways_Use.BackColor = System.Drawing.SystemColors.Control
        Me.lblAlways_Use.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAlways_Use.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlways_Use.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAlways_Use.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlways_Use.Location = New System.Drawing.Point(6, 286)
        Me.lblAlways_Use.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAlways_Use.Name = "lblAlways_Use"
        Me.lblAlways_Use.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAlways_Use.Size = New System.Drawing.Size(122, 25)
        Me.lblAlways_Use.TabIndex = 29
        Me.lblAlways_Use.Text = "Always Use"
        '
        'lblShip_Instructions_2
        '
        Me.lblShip_Instructions_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblShip_Instructions_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShip_Instructions_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip_Instructions_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShip_Instructions_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShip_Instructions_2.Location = New System.Drawing.Point(6, 240)
        Me.lblShip_Instructions_2.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShip_Instructions_2.Name = "lblShip_Instructions_2"
        Me.lblShip_Instructions_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShip_Instructions_2.Size = New System.Drawing.Size(122, 25)
        Me.lblShip_Instructions_2.TabIndex = 27
        Me.lblShip_Instructions_2.Text = "Ship Instructions 2"
        '
        'lblPrinter_Instructions
        '
        Me.lblPrinter_Instructions.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrinter_Instructions.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrinter_Instructions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinter_Instructions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrinter_Instructions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrinter_Instructions.Location = New System.Drawing.Point(6, 148)
        Me.lblPrinter_Instructions.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrinter_Instructions.Name = "lblPrinter_Instructions"
        Me.lblPrinter_Instructions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrinter_Instructions.Size = New System.Drawing.Size(119, 25)
        Me.lblPrinter_Instructions.TabIndex = 19
        Me.lblPrinter_Instructions.Text = "Printer Instructions"
        '
        'lblShip_Instructions_1
        '
        Me.lblShip_Instructions_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblShip_Instructions_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShip_Instructions_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip_Instructions_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShip_Instructions_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShip_Instructions_1.Location = New System.Drawing.Point(6, 217)
        Me.lblShip_Instructions_1.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShip_Instructions_1.Name = "lblShip_Instructions_1"
        Me.lblShip_Instructions_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShip_Instructions_1.Size = New System.Drawing.Size(122, 25)
        Me.lblShip_Instructions_1.TabIndex = 25
        Me.lblShip_Instructions_1.Text = "Ship Instructions 1"
        '
        'lblPacker_Instructions
        '
        Me.lblPacker_Instructions.BackColor = System.Drawing.SystemColors.Control
        Me.lblPacker_Instructions.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPacker_Instructions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPacker_Instructions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPacker_Instructions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPacker_Instructions.Location = New System.Drawing.Point(6, 194)
        Me.lblPacker_Instructions.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPacker_Instructions.Name = "lblPacker_Instructions"
        Me.lblPacker_Instructions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPacker_Instructions.Size = New System.Drawing.Size(122, 25)
        Me.lblPacker_Instructions.TabIndex = 23
        Me.lblPacker_Instructions.Text = "Packer Instructions"
        '
        'lblPacker_Comment
        '
        Me.lblPacker_Comment.BackColor = System.Drawing.SystemColors.Control
        Me.lblPacker_Comment.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPacker_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPacker_Comment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPacker_Comment.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPacker_Comment.Location = New System.Drawing.Point(6, 171)
        Me.lblPacker_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPacker_Comment.Name = "lblPacker_Comment"
        Me.lblPacker_Comment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPacker_Comment.Size = New System.Drawing.Size(119, 25)
        Me.lblPacker_Comment.TabIndex = 21
        Me.lblPacker_Comment.Text = "Packer Comment"
        '
        'lblProgram_Cd
        '
        Me.lblProgram_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblProgram_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgram_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgram_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProgram_Cd.Location = New System.Drawing.Point(326, 20)
        Me.lblProgram_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProgram_Cd.Name = "lblProgram_Cd"
        Me.lblProgram_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProgram_Cd.Size = New System.Drawing.Size(119, 25)
        Me.lblProgram_Cd.TabIndex = 9
        Me.lblProgram_Cd.Text = "Program"
        '
        'lblPrinter_Comment
        '
        Me.lblPrinter_Comment.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrinter_Comment.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrinter_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinter_Comment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrinter_Comment.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrinter_Comment.Location = New System.Drawing.Point(6, 125)
        Me.lblPrinter_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrinter_Comment.Name = "lblPrinter_Comment"
        Me.lblPrinter_Comment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrinter_Comment.Size = New System.Drawing.Size(122, 25)
        Me.lblPrinter_Comment.TabIndex = 17
        Me.lblPrinter_Comment.Text = "Printer Comment"
        '
        'lblShip_Via_Account
        '
        Me.lblShip_Via_Account.BackColor = System.Drawing.SystemColors.Control
        Me.lblShip_Via_Account.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShip_Via_Account.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip_Via_Account.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShip_Via_Account.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShip_Via_Account.Location = New System.Drawing.Point(326, 70)
        Me.lblShip_Via_Account.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShip_Via_Account.Name = "lblShip_Via_Account"
        Me.lblShip_Via_Account.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShip_Via_Account.Size = New System.Drawing.Size(122, 25)
        Me.lblShip_Via_Account.TabIndex = 13
        Me.lblShip_Via_Account.Text = "Ship Via Account No"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(326, 45)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(119, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Ship Via"
        '
        'lblGroup_Cd
        '
        Me.lblGroup_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblGroup_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGroup_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGroup_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGroup_Cd.Location = New System.Drawing.Point(6, 20)
        Me.lblGroup_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblGroup_Cd.Name = "lblGroup_Cd"
        Me.lblGroup_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGroup_Cd.Size = New System.Drawing.Size(119, 25)
        Me.lblGroup_Cd.TabIndex = 1
        Me.lblGroup_Cd.Text = "Group"
        '
        'lblCountry_Cd
        '
        Me.lblCountry_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblCountry_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCountry_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountry_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCountry_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountry_Cd.Location = New System.Drawing.Point(6, 93)
        Me.lblCountry_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCountry_Cd.Name = "lblCountry_Cd"
        Me.lblCountry_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCountry_Cd.Size = New System.Drawing.Size(122, 20)
        Me.lblCountry_Cd.TabIndex = 7
        Me.lblCountry_Cd.Text = "Country "
        '
        'lblCus_Alt_Adr_Cd
        '
        Me.lblCus_Alt_Adr_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_Alt_Adr_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_Alt_Adr_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_Alt_Adr_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_Alt_Adr_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_Alt_Adr_Cd.Location = New System.Drawing.Point(7, 68)
        Me.lblCus_Alt_Adr_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_Alt_Adr_Cd.Name = "lblCus_Alt_Adr_Cd"
        Me.lblCus_Alt_Adr_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_Alt_Adr_Cd.Size = New System.Drawing.Size(120, 25)
        Me.lblCus_Alt_Adr_Cd.TabIndex = 5
        Me.lblCus_Alt_Adr_Cd.Text = "Alt Address"
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(6, 45)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(119, 25)
        Me.lblCus_No.TabIndex = 3
        Me.lblCus_No.Text = "Customer"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 15)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1, Me.lsSeparator1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(648, 354)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 8
        Me.LineShape1.X2 = 637
        Me.LineShape1.Y1 = 317
        Me.LineShape1.Y2 = 317
        '
        'lsSeparator1
        '
        Me.lsSeparator1.Name = "lsSeparator1"
        Me.lsSeparator1.X1 = 8
        Me.lsSeparator1.X2 = 637
        Me.lsSeparator1.Y1 = 101
        Me.lsSeparator1.Y2 = 101
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
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(670, 25)
        Me.tsProgramMenu.TabIndex = 5
        Me.tsProgramMenu.Text = "ToolStrip1"
        '
        'txtShip_Comments
        '
        Me.txtShip_Comments.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShip_Comments.DataLength = CType(0, Long)
        Me.txtShip_Comments.DataType = CustomerFile.CDataType.dtString
        Me.txtShip_Comments.DateValue = New Date(CType(0, Long))
        Me.txtShip_Comments.DecimalDigits = CType(0, Long)
        Me.txtShip_Comments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip_Comments.Location = New System.Drawing.Point(131, 260)
        Me.txtShip_Comments.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShip_Comments.Mask = Nothing
        Me.txtShip_Comments.Name = "txtShip_Comments"
        Me.txtShip_Comments.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShip_Comments.OldValue = Nothing
        Me.txtShip_Comments.Size = New System.Drawing.Size(508, 21)
        Me.txtShip_Comments.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShip_Comments.StringValue = Nothing
        Me.txtShip_Comments.TabIndex = 46
        Me.txtShip_Comments.TextDataID = Nothing
        '
        'txtUpdate_TS
        '
        Me.txtUpdate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtUpdate_TS.DataLength = CType(0, Long)
        Me.txtUpdate_TS.DataType = CustomerFile.CDataType.dtDateTime
        Me.txtUpdate_TS.DateValue = New Date(CType(0, Long))
        Me.txtUpdate_TS.DecimalDigits = CType(0, Long)
        Me.txtUpdate_TS.Enabled = False
        Me.txtUpdate_TS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdate_TS.Location = New System.Drawing.Point(451, 338)
        Me.txtUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUpdate_TS.Mask = Nothing
        Me.txtUpdate_TS.Name = "txtUpdate_TS"
        Me.txtUpdate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUpdate_TS.OldValue = Nothing
        Me.txtUpdate_TS.Size = New System.Drawing.Size(188, 21)
        Me.txtUpdate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUpdate_TS.StringValue = Nothing
        Me.txtUpdate_TS.TabIndex = 44
        Me.txtUpdate_TS.TextDataID = Nothing
        '
        'txtUser_Login
        '
        Me.txtUser_Login.CharacterInput = CustomerFile.Cinput.CharactersOnly
        Me.txtUser_Login.DataLength = CType(0, Long)
        Me.txtUser_Login.DataType = CustomerFile.CDataType.dtString
        Me.txtUser_Login.DateValue = New Date(CType(0, Long))
        Me.txtUser_Login.DecimalDigits = CType(0, Long)
        Me.txtUser_Login.Enabled = False
        Me.txtUser_Login.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser_Login.Location = New System.Drawing.Point(130, 338)
        Me.txtUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUser_Login.Mask = Nothing
        Me.txtUser_Login.Name = "txtUser_Login"
        Me.txtUser_Login.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUser_Login.OldValue = Nothing
        Me.txtUser_Login.Size = New System.Drawing.Size(188, 21)
        Me.txtUser_Login.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUser_Login.StringValue = Nothing
        Me.txtUser_Login.TabIndex = 42
        Me.txtUser_Login.TextDataID = Nothing
        '
        'XTextBox17
        '
        Me.XTextBox17.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTextBox17.DataLength = CType(0, Long)
        Me.XTextBox17.DataType = CustomerFile.CDataType.dtString
        Me.XTextBox17.DateValue = New Date(CType(0, Long))
        Me.XTextBox17.DecimalDigits = CType(0, Long)
        Me.XTextBox17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTextBox17.Location = New System.Drawing.Point(451, 306)
        Me.XTextBox17.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox17.Mask = Nothing
        Me.XTextBox17.Name = "XTextBox17"
        Me.XTextBox17.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox17.OldValue = Nothing
        Me.XTextBox17.Size = New System.Drawing.Size(188, 21)
        Me.XTextBox17.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox17.StringValue = Nothing
        Me.XTextBox17.TabIndex = 40
        Me.XTextBox17.TextDataID = Nothing
        Me.XTextBox17.Visible = False
        '
        'XTextBox16
        '
        Me.XTextBox16.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTextBox16.DataLength = CType(0, Long)
        Me.XTextBox16.DataType = CustomerFile.CDataType.dtString
        Me.XTextBox16.DateValue = New Date(CType(0, Long))
        Me.XTextBox16.DecimalDigits = CType(0, Long)
        Me.XTextBox16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTextBox16.Location = New System.Drawing.Point(451, 283)
        Me.XTextBox16.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox16.Mask = Nothing
        Me.XTextBox16.Name = "XTextBox16"
        Me.XTextBox16.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox16.OldValue = Nothing
        Me.XTextBox16.Size = New System.Drawing.Size(188, 21)
        Me.XTextBox16.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox16.StringValue = Nothing
        Me.XTextBox16.TabIndex = 37
        Me.XTextBox16.TextDataID = Nothing
        Me.XTextBox16.Visible = False
        '
        'XTextBox14
        '
        Me.XTextBox14.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTextBox14.DataLength = CType(0, Long)
        Me.XTextBox14.DataType = CustomerFile.CDataType.dtString
        Me.XTextBox14.DateValue = New Date(CType(0, Long))
        Me.XTextBox14.DecimalDigits = CType(0, Long)
        Me.XTextBox14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTextBox14.Location = New System.Drawing.Point(131, 306)
        Me.XTextBox14.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox14.Mask = Nothing
        Me.XTextBox14.Name = "XTextBox14"
        Me.XTextBox14.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox14.OldValue = Nothing
        Me.XTextBox14.Size = New System.Drawing.Size(188, 21)
        Me.XTextBox14.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox14.StringValue = Nothing
        Me.XTextBox14.TabIndex = 34
        Me.XTextBox14.TextDataID = Nothing
        Me.XTextBox14.Visible = False
        '
        'XTextBox13
        '
        Me.XTextBox13.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTextBox13.DataLength = CType(0, Long)
        Me.XTextBox13.DataType = CustomerFile.CDataType.dtString
        Me.XTextBox13.DateValue = New Date(CType(0, Long))
        Me.XTextBox13.DecimalDigits = CType(0, Long)
        Me.XTextBox13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTextBox13.Location = New System.Drawing.Point(131, 283)
        Me.XTextBox13.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox13.Mask = Nothing
        Me.XTextBox13.Name = "XTextBox13"
        Me.XTextBox13.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox13.OldValue = Nothing
        Me.XTextBox13.Size = New System.Drawing.Size(188, 21)
        Me.XTextBox13.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox13.StringValue = Nothing
        Me.XTextBox13.TabIndex = 31
        Me.XTextBox13.TextDataID = Nothing
        Me.XTextBox13.Visible = False
        '
        'txtShip_Instructions_2
        '
        Me.txtShip_Instructions_2.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShip_Instructions_2.DataLength = CType(0, Long)
        Me.txtShip_Instructions_2.DataType = CustomerFile.CDataType.dtString
        Me.txtShip_Instructions_2.DateValue = New Date(CType(0, Long))
        Me.txtShip_Instructions_2.DecimalDigits = CType(0, Long)
        Me.txtShip_Instructions_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip_Instructions_2.Location = New System.Drawing.Point(131, 237)
        Me.txtShip_Instructions_2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShip_Instructions_2.Mask = Nothing
        Me.txtShip_Instructions_2.Name = "txtShip_Instructions_2"
        Me.txtShip_Instructions_2.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShip_Instructions_2.OldValue = Nothing
        Me.txtShip_Instructions_2.Size = New System.Drawing.Size(508, 21)
        Me.txtShip_Instructions_2.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShip_Instructions_2.StringValue = Nothing
        Me.txtShip_Instructions_2.TabIndex = 28
        Me.txtShip_Instructions_2.TextDataID = Nothing
        '
        'txtPrinter_Instructions
        '
        Me.txtPrinter_Instructions.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPrinter_Instructions.DataLength = CType(0, Long)
        Me.txtPrinter_Instructions.DataType = CustomerFile.CDataType.dtString
        Me.txtPrinter_Instructions.DateValue = New Date(CType(0, Long))
        Me.txtPrinter_Instructions.DecimalDigits = CType(0, Long)
        Me.txtPrinter_Instructions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrinter_Instructions.Location = New System.Drawing.Point(131, 145)
        Me.txtPrinter_Instructions.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPrinter_Instructions.Mask = Nothing
        Me.txtPrinter_Instructions.Name = "txtPrinter_Instructions"
        Me.txtPrinter_Instructions.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrinter_Instructions.OldValue = Nothing
        Me.txtPrinter_Instructions.Size = New System.Drawing.Size(508, 21)
        Me.txtPrinter_Instructions.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPrinter_Instructions.StringValue = Nothing
        Me.txtPrinter_Instructions.TabIndex = 20
        Me.txtPrinter_Instructions.TextDataID = Nothing
        '
        'txtShip_Instructions_1
        '
        Me.txtShip_Instructions_1.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShip_Instructions_1.DataLength = CType(0, Long)
        Me.txtShip_Instructions_1.DataType = CustomerFile.CDataType.dtString
        Me.txtShip_Instructions_1.DateValue = New Date(CType(0, Long))
        Me.txtShip_Instructions_1.DecimalDigits = CType(0, Long)
        Me.txtShip_Instructions_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip_Instructions_1.Location = New System.Drawing.Point(131, 214)
        Me.txtShip_Instructions_1.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShip_Instructions_1.Mask = Nothing
        Me.txtShip_Instructions_1.Name = "txtShip_Instructions_1"
        Me.txtShip_Instructions_1.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShip_Instructions_1.OldValue = Nothing
        Me.txtShip_Instructions_1.Size = New System.Drawing.Size(508, 21)
        Me.txtShip_Instructions_1.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShip_Instructions_1.StringValue = Nothing
        Me.txtShip_Instructions_1.TabIndex = 26
        Me.txtShip_Instructions_1.TextDataID = Nothing
        '
        'txtPacker_Instructions
        '
        Me.txtPacker_Instructions.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPacker_Instructions.DataLength = CType(0, Long)
        Me.txtPacker_Instructions.DataType = CustomerFile.CDataType.dtString
        Me.txtPacker_Instructions.DateValue = New Date(CType(0, Long))
        Me.txtPacker_Instructions.DecimalDigits = CType(0, Long)
        Me.txtPacker_Instructions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPacker_Instructions.Location = New System.Drawing.Point(131, 191)
        Me.txtPacker_Instructions.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPacker_Instructions.Mask = Nothing
        Me.txtPacker_Instructions.Name = "txtPacker_Instructions"
        Me.txtPacker_Instructions.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPacker_Instructions.OldValue = Nothing
        Me.txtPacker_Instructions.Size = New System.Drawing.Size(508, 21)
        Me.txtPacker_Instructions.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPacker_Instructions.StringValue = Nothing
        Me.txtPacker_Instructions.TabIndex = 24
        Me.txtPacker_Instructions.TextDataID = Nothing
        '
        'txtPacker_Comment
        '
        Me.txtPacker_Comment.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPacker_Comment.DataLength = CType(0, Long)
        Me.txtPacker_Comment.DataType = CustomerFile.CDataType.dtString
        Me.txtPacker_Comment.DateValue = New Date(CType(0, Long))
        Me.txtPacker_Comment.DecimalDigits = CType(0, Long)
        Me.txtPacker_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPacker_Comment.Location = New System.Drawing.Point(131, 168)
        Me.txtPacker_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPacker_Comment.Mask = Nothing
        Me.txtPacker_Comment.Name = "txtPacker_Comment"
        Me.txtPacker_Comment.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPacker_Comment.OldValue = Nothing
        Me.txtPacker_Comment.Size = New System.Drawing.Size(508, 21)
        Me.txtPacker_Comment.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPacker_Comment.StringValue = Nothing
        Me.txtPacker_Comment.TabIndex = 22
        Me.txtPacker_Comment.TextDataID = Nothing
        '
        'txtPrinter_Comment
        '
        Me.txtPrinter_Comment.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPrinter_Comment.DataLength = CType(0, Long)
        Me.txtPrinter_Comment.DataType = CustomerFile.CDataType.dtString
        Me.txtPrinter_Comment.DateValue = New Date(CType(0, Long))
        Me.txtPrinter_Comment.DecimalDigits = CType(0, Long)
        Me.txtPrinter_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrinter_Comment.Location = New System.Drawing.Point(131, 122)
        Me.txtPrinter_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPrinter_Comment.Mask = Nothing
        Me.txtPrinter_Comment.Name = "txtPrinter_Comment"
        Me.txtPrinter_Comment.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPrinter_Comment.OldValue = Nothing
        Me.txtPrinter_Comment.Size = New System.Drawing.Size(508, 21)
        Me.txtPrinter_Comment.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPrinter_Comment.StringValue = Nothing
        Me.txtPrinter_Comment.TabIndex = 18
        Me.txtPrinter_Comment.TextDataID = Nothing
        '
        'txtShip_Via_Account
        '
        Me.txtShip_Via_Account.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShip_Via_Account.DataLength = CType(0, Long)
        Me.txtShip_Via_Account.DataType = CustomerFile.CDataType.dtString
        Me.txtShip_Via_Account.DateValue = New Date(CType(0, Long))
        Me.txtShip_Via_Account.DecimalDigits = CType(0, Long)
        Me.txtShip_Via_Account.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip_Via_Account.Location = New System.Drawing.Point(451, 67)
        Me.txtShip_Via_Account.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShip_Via_Account.Mask = Nothing
        Me.txtShip_Via_Account.Name = "txtShip_Via_Account"
        Me.txtShip_Via_Account.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShip_Via_Account.OldValue = Nothing
        Me.txtShip_Via_Account.Size = New System.Drawing.Size(188, 21)
        Me.txtShip_Via_Account.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShip_Via_Account.StringValue = Nothing
        Me.txtShip_Via_Account.TabIndex = 14
        Me.txtShip_Via_Account.TextDataID = Nothing
        '
        'txtCus_Ship_ID
        '
        Me.txtCus_Ship_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Ship_ID.DataLength = CType(0, Long)
        Me.txtCus_Ship_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Ship_ID.DateValue = New Date(CType(0, Long))
        Me.txtCus_Ship_ID.DecimalDigits = CType(0, Long)
        Me.txtCus_Ship_ID.Enabled = False
        Me.txtCus_Ship_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Ship_ID.Location = New System.Drawing.Point(451, 90)
        Me.txtCus_Ship_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Ship_ID.Mask = Nothing
        Me.txtCus_Ship_ID.Name = "txtCus_Ship_ID"
        Me.txtCus_Ship_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Ship_ID.OldValue = Nothing
        Me.txtCus_Ship_ID.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_Ship_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Ship_ID.StringValue = Nothing
        Me.txtCus_Ship_ID.TabIndex = 16
        Me.txtCus_Ship_ID.Text = "0"
        Me.txtCus_Ship_ID.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_No.Location = New System.Drawing.Point(131, 42)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = Nothing
        Me.txtCus_No.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 4
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmMDB_CUS_SHIP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(670, 406)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.gbProgramHeader)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(678, 423)
        Me.Name = "frmMDB_CUS_SHIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CUS-SHP-001"
        Me.Text = "Customer Shipping Information"
        Me.gbProgramHeader.ResumeLayout(False)
        Me.gbProgramHeader.PerformLayout()
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbProgramHeader As System.Windows.Forms.GroupBox
    Friend WithEvents cboCus_Alt_Adr_Cd As System.Windows.Forms.ComboBox
    Friend WithEvents chkSamples_Only As System.Windows.Forms.CheckBox
    Friend WithEvents chkNo_Charge As System.Windows.Forms.CheckBox
    Friend WithEvents chkNever_Use As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlways_Use As System.Windows.Forms.CheckBox
    Friend WithEvents cboShip_Via_Cd As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup_Cd As System.Windows.Forms.ComboBox
    Friend WithEvents cboProgram_Id As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpdate_TS As CustomerFile.xTextBox
    Friend WithEvents lblUpdate_TS As System.Windows.Forms.Label
    Friend WithEvents txtUser_Login As CustomerFile.xTextBox
    Friend WithEvents lblUser_Login As System.Windows.Forms.Label
    Friend WithEvents XTextBox17 As CustomerFile.xTextBox
    Friend WithEvents lblSamples_Only As System.Windows.Forms.Label
    Friend WithEvents XTextBox16 As CustomerFile.xTextBox
    Friend WithEvents lblNo_Charge As System.Windows.Forms.Label
    Friend WithEvents XTextBox14 As CustomerFile.xTextBox
    Friend WithEvents lblNever_Use As System.Windows.Forms.Label
    Friend WithEvents XTextBox13 As CustomerFile.xTextBox
    Friend WithEvents lblAlways_Use As System.Windows.Forms.Label
    Friend WithEvents txtShip_Instructions_2 As CustomerFile.xTextBox
    Friend WithEvents lblShip_Instructions_2 As System.Windows.Forms.Label
    Friend WithEvents txtPrinter_Instructions As CustomerFile.xTextBox
    Friend WithEvents lblPrinter_Instructions As System.Windows.Forms.Label
    Friend WithEvents txtShip_Instructions_1 As CustomerFile.xTextBox
    Friend WithEvents lblShip_Instructions_1 As System.Windows.Forms.Label
    Friend WithEvents lblPacker_Instructions As System.Windows.Forms.Label
    Friend WithEvents txtPacker_Instructions As CustomerFile.xTextBox
    Friend WithEvents txtPacker_Comment As CustomerFile.xTextBox
    Friend WithEvents lblPacker_Comment As System.Windows.Forms.Label
    Friend WithEvents lblProgram_Cd As System.Windows.Forms.Label
    Friend WithEvents txtPrinter_Comment As CustomerFile.xTextBox
    Friend WithEvents lblPrinter_Comment As System.Windows.Forms.Label
    Friend WithEvents lblShip_Via_Account As System.Windows.Forms.Label
    Friend WithEvents txtShip_Via_Account As CustomerFile.xTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblGroup_Cd As System.Windows.Forms.Label
    Friend WithEvents txtCus_Ship_ID As CustomerFile.xTextBox
    Friend WithEvents lblCountry_Cd As System.Windows.Forms.Label
    Friend WithEvents lblCus_Alt_Adr_Cd As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsSeparator1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents lblCus_Ship_ID As System.Windows.Forms.Label
    Friend WithEvents txtShip_Comments As CustomerFile.xTextBox
    Friend WithEvents lblShip_Comments As System.Windows.Forms.Label
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
End Class
