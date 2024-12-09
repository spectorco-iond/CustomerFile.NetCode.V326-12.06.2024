<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDB_CFG_CHARGE_USAGE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDB_CFG_CHARGE_USAGE))
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.lblWhen_Amt_GT = New System.Windows.Forms.Label()
        Me.lblCharge_Id = New System.Windows.Forms.Label()
        Me.lblEmail_To = New System.Windows.Forms.Label()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.lblAutorized_By = New System.Windows.Forms.Label()
        Me.lbllblWhen_Amt_LT = New System.Windows.Forms.Label()
        Me.lblShip_Instructions_2 = New System.Windows.Forms.Label()
        Me.lblAlways_Use = New System.Windows.Forms.Label()
        Me.lblNever_Use = New System.Windows.Forms.Label()
        Me.lblNo_Charge = New System.Windows.Forms.Label()
        Me.lblBlind = New System.Windows.Forms.Label()
        Me.lblUser_Login = New System.Windows.Forms.Label()
        Me.lblUpdate_TS = New System.Windows.Forms.Label()
        Me.cboCharge_Id = New System.Windows.Forms.ComboBox()
        Me.chkAlways_Use = New System.Windows.Forms.CheckBox()
        Me.chkNever_Use = New System.Windows.Forms.CheckBox()
        Me.chkNo_Charge = New System.Windows.Forms.CheckBox()
        Me.chkBlind = New System.Windows.Forms.CheckBox()
        Me.lblCharge_Usage_ID = New System.Windows.Forms.Label()
        Me.lblWhen_Qty_Gt = New System.Windows.Forms.Label()
        Me.lblWhen_Qty_LT = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblApply_To_Ship_To = New System.Windows.Forms.Label()
        Me.lblApply_To_Program = New System.Windows.Forms.Label()
        Me.cboApply_To_Program = New System.Windows.Forms.ComboBox()
        Me.cboApply_To_Ship_To = New System.Windows.Forms.ComboBox()
        Me.chkSend_Email = New System.Windows.Forms.CheckBox()
        Me.chkWhen_Req = New System.Windows.Forms.CheckBox()
        Me.lblStart_Dt = New System.Windows.Forms.Label()
        Me.lblEnd_Dt = New System.Windows.Forms.Label()
        Me.cmdStart_Dt = New System.Windows.Forms.Button()
        Me.cmdEnd_Dt = New System.Windows.Forms.Button()
        Me.gbProgramHeader = New System.Windows.Forms.GroupBox()
        Me.txtUnit_Price = New CustomerFile.xTextBox()
        Me.lblUnit_Price = New System.Windows.Forms.Label()
        Me.txtEnd_Dt = New CustomerFile.xTextBox()
        Me.txtStart_Dt = New CustomerFile.xTextBox()
        Me.XTextBox4 = New CustomerFile.xTextBox()
        Me.txtWhen_Qty_LT = New CustomerFile.xTextBox()
        Me.txtWhen_Qty_GT = New CustomerFile.xTextBox()
        Me.txtUpdate_TS = New CustomerFile.xTextBox()
        Me.txtUser_Login = New CustomerFile.xTextBox()
        Me.XTextBox17 = New CustomerFile.xTextBox()
        Me.XTextBox16 = New CustomerFile.xTextBox()
        Me.txtShip_Instructions_2 = New CustomerFile.xTextBox()
        Me.txtWhen_Amt_LT = New CustomerFile.xTextBox()
        Me.txtAutorized_By = New CustomerFile.xTextBox()
        Me.txtComments = New CustomerFile.xTextBox()
        Me.txtEmail_To = New CustomerFile.xTextBox()
        Me.txtWhen_Amt_GT = New CustomerFile.xTextBox()
        Me.txtCharge_Usage_ID = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.chkAllGroup = New System.Windows.Forms.CheckBox()
        Me.tsProgramMenu.SuspendLayout()
        Me.gbProgramHeader.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tsSave.Visible = False
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose, Me.ToolStripLabel1})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(672, 25)
        Me.tsProgramMenu.TabIndex = 0
        Me.tsProgramMenu.Text = "ToolStrip1"
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(145, 22)
        Me.ToolStripLabel1.Text = "Use for all group accounts"
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(90, 165)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(8)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 70
        Me.mcCalendar.Visible = False
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(7, 22)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(113, 25)
        Me.lblCus_No.TabIndex = 1
        Me.lblCus_No.Text = "Customer"
        '
        'lblWhen_Amt_GT
        '
        Me.lblWhen_Amt_GT.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Amt_GT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Amt_GT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Amt_GT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Amt_GT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Amt_GT.Location = New System.Drawing.Point(7, 173)
        Me.lblWhen_Amt_GT.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Amt_GT.Name = "lblWhen_Amt_GT"
        Me.lblWhen_Amt_GT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Amt_GT.Size = New System.Drawing.Size(123, 20)
        Me.lblWhen_Amt_GT.TabIndex = 26
        Me.lblWhen_Amt_GT.Text = "When Amt GT"
        '
        'lblCharge_Id
        '
        Me.lblCharge_Id.BackColor = System.Drawing.SystemColors.Control
        Me.lblCharge_Id.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCharge_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge_Id.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCharge_Id.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCharge_Id.Location = New System.Drawing.Point(7, 45)
        Me.lblCharge_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCharge_Id.Name = "lblCharge_Id"
        Me.lblCharge_Id.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCharge_Id.Size = New System.Drawing.Size(119, 25)
        Me.lblCharge_Id.TabIndex = 3
        Me.lblCharge_Id.Text = "Option"
        '
        'lblEmail_To
        '
        Me.lblEmail_To.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmail_To.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEmail_To.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail_To.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmail_To.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmail_To.Location = New System.Drawing.Point(328, 232)
        Me.lblEmail_To.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmail_To.Name = "lblEmail_To"
        Me.lblEmail_To.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEmail_To.Size = New System.Drawing.Size(113, 22)
        Me.lblEmail_To.TabIndex = 43
        Me.lblEmail_To.Text = "Email_To"
        Me.lblEmail_To.Visible = False
        '
        'lblComments
        '
        Me.lblComments.BackColor = System.Drawing.SystemColors.Control
        Me.lblComments.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblComments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblComments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComments.Location = New System.Drawing.Point(7, 255)
        Me.lblComments.Margin = New System.Windows.Forms.Padding(1)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblComments.Size = New System.Drawing.Size(123, 25)
        Me.lblComments.TabIndex = 45
        Me.lblComments.Text = "Comments"
        '
        'lblAutorized_By
        '
        Me.lblAutorized_By.BackColor = System.Drawing.SystemColors.Control
        Me.lblAutorized_By.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAutorized_By.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutorized_By.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAutorized_By.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutorized_By.Location = New System.Drawing.Point(7, 278)
        Me.lblAutorized_By.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAutorized_By.Name = "lblAutorized_By"
        Me.lblAutorized_By.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAutorized_By.Size = New System.Drawing.Size(123, 18)
        Me.lblAutorized_By.TabIndex = 47
        Me.lblAutorized_By.Text = "Autorized_By"
        '
        'lbllblWhen_Amt_LT
        '
        Me.lbllblWhen_Amt_LT.BackColor = System.Drawing.SystemColors.Control
        Me.lbllblWhen_Amt_LT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbllblWhen_Amt_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblWhen_Amt_LT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbllblWhen_Amt_LT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbllblWhen_Amt_LT.Location = New System.Drawing.Point(328, 173)
        Me.lbllblWhen_Amt_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.lbllblWhen_Amt_LT.Name = "lbllblWhen_Amt_LT"
        Me.lbllblWhen_Amt_LT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbllblWhen_Amt_LT.Size = New System.Drawing.Size(116, 25)
        Me.lbllblWhen_Amt_LT.TabIndex = 30
        Me.lbllblWhen_Amt_LT.Text = "When Amt LT"
        '
        'lblShip_Instructions_2
        '
        Me.lblShip_Instructions_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblShip_Instructions_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShip_Instructions_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip_Instructions_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShip_Instructions_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShip_Instructions_2.Location = New System.Drawing.Point(8, 232)
        Me.lblShip_Instructions_2.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShip_Instructions_2.Name = "lblShip_Instructions_2"
        Me.lblShip_Instructions_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShip_Instructions_2.Size = New System.Drawing.Size(119, 25)
        Me.lblShip_Instructions_2.TabIndex = 40
        Me.lblShip_Instructions_2.Text = "Send_Email"
        Me.lblShip_Instructions_2.Visible = False
        '
        'lblAlways_Use
        '
        Me.lblAlways_Use.BackColor = System.Drawing.SystemColors.Control
        Me.lblAlways_Use.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAlways_Use.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlways_Use.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAlways_Use.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlways_Use.Location = New System.Drawing.Point(7, 139)
        Me.lblAlways_Use.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAlways_Use.Name = "lblAlways_Use"
        Me.lblAlways_Use.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAlways_Use.Size = New System.Drawing.Size(122, 18)
        Me.lblAlways_Use.TabIndex = 5
        Me.lblAlways_Use.Text = "Always Use"
        '
        'lblNever_Use
        '
        Me.lblNever_Use.BackColor = System.Drawing.SystemColors.Control
        Me.lblNever_Use.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNever_Use.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNever_Use.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNever_Use.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNever_Use.Location = New System.Drawing.Point(176, 139)
        Me.lblNever_Use.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNever_Use.Name = "lblNever_Use"
        Me.lblNever_Use.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNever_Use.Size = New System.Drawing.Size(122, 18)
        Me.lblNever_Use.TabIndex = 8
        Me.lblNever_Use.Text = "Never Use"
        '
        'lblNo_Charge
        '
        Me.lblNo_Charge.BackColor = System.Drawing.SystemColors.Control
        Me.lblNo_Charge.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNo_Charge.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo_Charge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNo_Charge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNo_Charge.Location = New System.Drawing.Point(8, 116)
        Me.lblNo_Charge.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNo_Charge.Name = "lblNo_Charge"
        Me.lblNo_Charge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNo_Charge.Size = New System.Drawing.Size(122, 18)
        Me.lblNo_Charge.TabIndex = 11
        Me.lblNo_Charge.Text = "At No Charge"
        '
        'lblBlind
        '
        Me.lblBlind.BackColor = System.Drawing.SystemColors.Control
        Me.lblBlind.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBlind.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBlind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBlind.Location = New System.Drawing.Point(328, 91)
        Me.lblBlind.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBlind.Name = "lblBlind"
        Me.lblBlind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBlind.Size = New System.Drawing.Size(121, 18)
        Me.lblBlind.TabIndex = 21
        Me.lblBlind.Text = "Blind"
        '
        'lblUser_Login
        '
        Me.lblUser_Login.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser_Login.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser_Login.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser_Login.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUser_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUser_Login.Location = New System.Drawing.Point(7, 314)
        Me.lblUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUser_Login.Name = "lblUser_Login"
        Me.lblUser_Login.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser_Login.Size = New System.Drawing.Size(123, 25)
        Me.lblUser_Login.TabIndex = 49
        Me.lblUser_Login.Text = "Modified By"
        '
        'lblUpdate_TS
        '
        Me.lblUpdate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblUpdate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdate_TS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUpdate_TS.Location = New System.Drawing.Point(328, 314)
        Me.lblUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUpdate_TS.Name = "lblUpdate_TS"
        Me.lblUpdate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdate_TS.Size = New System.Drawing.Size(119, 25)
        Me.lblUpdate_TS.TabIndex = 51
        Me.lblUpdate_TS.Text = "Modified Date"
        '
        'cboCharge_Id
        '
        Me.cboCharge_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCharge_Id.FormattingEnabled = True
        Me.cboCharge_Id.Location = New System.Drawing.Point(132, 42)
        Me.cboCharge_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.cboCharge_Id.Name = "cboCharge_Id"
        Me.cboCharge_Id.Size = New System.Drawing.Size(188, 23)
        Me.cboCharge_Id.TabIndex = 4
        '
        'chkAlways_Use
        '
        Me.chkAlways_Use.AutoSize = True
        Me.chkAlways_Use.Location = New System.Drawing.Point(132, 140)
        Me.chkAlways_Use.Name = "chkAlways_Use"
        Me.chkAlways_Use.Size = New System.Drawing.Size(15, 14)
        Me.chkAlways_Use.TabIndex = 6
        Me.chkAlways_Use.UseVisualStyleBackColor = True
        '
        'chkNever_Use
        '
        Me.chkNever_Use.AutoSize = True
        Me.chkNever_Use.Location = New System.Drawing.Point(305, 140)
        Me.chkNever_Use.Name = "chkNever_Use"
        Me.chkNever_Use.Size = New System.Drawing.Size(15, 14)
        Me.chkNever_Use.TabIndex = 9
        Me.chkNever_Use.UseVisualStyleBackColor = True
        '
        'chkNo_Charge
        '
        Me.chkNo_Charge.AutoSize = True
        Me.chkNo_Charge.Location = New System.Drawing.Point(132, 117)
        Me.chkNo_Charge.Name = "chkNo_Charge"
        Me.chkNo_Charge.Size = New System.Drawing.Size(15, 14)
        Me.chkNo_Charge.TabIndex = 12
        Me.chkNo_Charge.UseVisualStyleBackColor = True
        '
        'chkBlind
        '
        Me.chkBlind.AutoSize = True
        Me.chkBlind.Location = New System.Drawing.Point(452, 92)
        Me.chkBlind.Name = "chkBlind"
        Me.chkBlind.Size = New System.Drawing.Size(15, 14)
        Me.chkBlind.TabIndex = 22
        Me.chkBlind.UseVisualStyleBackColor = True
        '
        'lblCharge_Usage_ID
        '
        Me.lblCharge_Usage_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblCharge_Usage_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCharge_Usage_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge_Usage_ID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCharge_Usage_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCharge_Usage_ID.Location = New System.Drawing.Point(328, 114)
        Me.lblCharge_Usage_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCharge_Usage_ID.Name = "lblCharge_Usage_ID"
        Me.lblCharge_Usage_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCharge_Usage_ID.Size = New System.Drawing.Size(122, 20)
        Me.lblCharge_Usage_ID.TabIndex = 24
        Me.lblCharge_Usage_ID.Text = "Charge Usage ID"
        '
        'lblWhen_Qty_Gt
        '
        Me.lblWhen_Qty_Gt.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Qty_Gt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Qty_Gt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Qty_Gt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Qty_Gt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Qty_Gt.Location = New System.Drawing.Point(7, 194)
        Me.lblWhen_Qty_Gt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Qty_Gt.Name = "lblWhen_Qty_Gt"
        Me.lblWhen_Qty_Gt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Qty_Gt.Size = New System.Drawing.Size(119, 21)
        Me.lblWhen_Qty_Gt.TabIndex = 28
        Me.lblWhen_Qty_Gt.Text = "When Qty GT"
        '
        'lblWhen_Qty_LT
        '
        Me.lblWhen_Qty_LT.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Qty_LT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Qty_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Qty_LT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Qty_LT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Qty_LT.Location = New System.Drawing.Point(328, 194)
        Me.lblWhen_Qty_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Qty_LT.Name = "lblWhen_Qty_LT"
        Me.lblWhen_Qty_LT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Qty_LT.Size = New System.Drawing.Size(115, 21)
        Me.lblWhen_Qty_LT.TabIndex = 32
        Me.lblWhen_Qty_LT.Text = "When Qty LT"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(328, 68)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(121, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "When Requested"
        '
        'lblApply_To_Ship_To
        '
        Me.lblApply_To_Ship_To.BackColor = System.Drawing.SystemColors.Control
        Me.lblApply_To_Ship_To.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblApply_To_Ship_To.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApply_To_Ship_To.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblApply_To_Ship_To.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApply_To_Ship_To.Location = New System.Drawing.Point(328, 43)
        Me.lblApply_To_Ship_To.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApply_To_Ship_To.Name = "lblApply_To_Ship_To"
        Me.lblApply_To_Ship_To.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblApply_To_Ship_To.Size = New System.Drawing.Size(120, 25)
        Me.lblApply_To_Ship_To.TabIndex = 14
        Me.lblApply_To_Ship_To.Text = "Apply To Ship To"
        '
        'lblApply_To_Program
        '
        Me.lblApply_To_Program.BackColor = System.Drawing.SystemColors.Control
        Me.lblApply_To_Program.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblApply_To_Program.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApply_To_Program.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblApply_To_Program.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApply_To_Program.Location = New System.Drawing.Point(328, 18)
        Me.lblApply_To_Program.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApply_To_Program.Name = "lblApply_To_Program"
        Me.lblApply_To_Program.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblApply_To_Program.Size = New System.Drawing.Size(118, 25)
        Me.lblApply_To_Program.TabIndex = 16
        Me.lblApply_To_Program.Text = "Apply To Program"
        Me.lblApply_To_Program.Visible = False
        '
        'cboApply_To_Program
        '
        Me.cboApply_To_Program.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboApply_To_Program.FormattingEnabled = True
        Me.cboApply_To_Program.Location = New System.Drawing.Point(452, 40)
        Me.cboApply_To_Program.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApply_To_Program.Name = "cboApply_To_Program"
        Me.cboApply_To_Program.Size = New System.Drawing.Size(188, 23)
        Me.cboApply_To_Program.TabIndex = 17
        Me.cboApply_To_Program.Visible = False
        '
        'cboApply_To_Ship_To
        '
        Me.cboApply_To_Ship_To.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboApply_To_Ship_To.FormattingEnabled = True
        Me.cboApply_To_Ship_To.Location = New System.Drawing.Point(452, 15)
        Me.cboApply_To_Ship_To.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApply_To_Ship_To.Name = "cboApply_To_Ship_To"
        Me.cboApply_To_Ship_To.Size = New System.Drawing.Size(188, 23)
        Me.cboApply_To_Ship_To.TabIndex = 15
        '
        'chkSend_Email
        '
        Me.chkSend_Email.AutoSize = True
        Me.chkSend_Email.Location = New System.Drawing.Point(132, 233)
        Me.chkSend_Email.Name = "chkSend_Email"
        Me.chkSend_Email.Size = New System.Drawing.Size(15, 14)
        Me.chkSend_Email.TabIndex = 41
        Me.chkSend_Email.UseVisualStyleBackColor = True
        Me.chkSend_Email.Visible = False
        '
        'chkWhen_Req
        '
        Me.chkWhen_Req.AutoSize = True
        Me.chkWhen_Req.Location = New System.Drawing.Point(452, 69)
        Me.chkWhen_Req.Name = "chkWhen_Req"
        Me.chkWhen_Req.Size = New System.Drawing.Size(15, 14)
        Me.chkWhen_Req.TabIndex = 19
        Me.chkWhen_Req.UseVisualStyleBackColor = True
        '
        'lblStart_Dt
        '
        Me.lblStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStart_Dt.Location = New System.Drawing.Point(7, 70)
        Me.lblStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStart_Dt.Name = "lblStart_Dt"
        Me.lblStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStart_Dt.Size = New System.Drawing.Size(110, 22)
        Me.lblStart_Dt.TabIndex = 34
        Me.lblStart_Dt.Text = "Start Date"
        '
        'lblEnd_Dt
        '
        Me.lblEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnd_Dt.Location = New System.Drawing.Point(8, 92)
        Me.lblEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnd_Dt.Name = "lblEnd_Dt"
        Me.lblEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnd_Dt.Size = New System.Drawing.Size(110, 22)
        Me.lblEnd_Dt.TabIndex = 37
        Me.lblEnd_Dt.Text = "End Date"
        '
        'cmdStart_Dt
        '
        Me.cmdStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart_Dt.Image = CType(resources.GetObject("cmdStart_Dt.Image"), System.Drawing.Image)
        Me.cmdStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStart_Dt.Location = New System.Drawing.Point(299, 66)
        Me.cmdStart_Dt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdStart_Dt.Name = "cmdStart_Dt"
        Me.cmdStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart_Dt.Size = New System.Drawing.Size(21, 22)
        Me.cmdStart_Dt.TabIndex = 36
        Me.cmdStart_Dt.TabStop = False
        Me.cmdStart_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStart_Dt.UseVisualStyleBackColor = False
        '
        'cmdEnd_Dt
        '
        Me.cmdEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnd_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnd_Dt.Image = CType(resources.GetObject("cmdEnd_Dt.Image"), System.Drawing.Image)
        Me.cmdEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdEnd_Dt.Location = New System.Drawing.Point(299, 89)
        Me.cmdEnd_Dt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdEnd_Dt.Name = "cmdEnd_Dt"
        Me.cmdEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnd_Dt.Size = New System.Drawing.Size(21, 22)
        Me.cmdEnd_Dt.TabIndex = 39
        Me.cmdEnd_Dt.TabStop = False
        Me.cmdEnd_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEnd_Dt.UseVisualStyleBackColor = False
        '
        'gbProgramHeader
        '
        Me.gbProgramHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramHeader.Controls.Add(Me.mcCalendar)
        Me.gbProgramHeader.Controls.Add(Me.txtUnit_Price)
        Me.gbProgramHeader.Controls.Add(Me.lblUnit_Price)
        Me.gbProgramHeader.Controls.Add(Me.chkNever_Use)
        Me.gbProgramHeader.Controls.Add(Me.chkAlways_Use)
        Me.gbProgramHeader.Controls.Add(Me.cmdEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.cmdStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.chkWhen_Req)
        Me.gbProgramHeader.Controls.Add(Me.chkSend_Email)
        Me.gbProgramHeader.Controls.Add(Me.cboApply_To_Ship_To)
        Me.gbProgramHeader.Controls.Add(Me.cboApply_To_Program)
        Me.gbProgramHeader.Controls.Add(Me.lblApply_To_Program)
        Me.gbProgramHeader.Controls.Add(Me.lblApply_To_Ship_To)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox4)
        Me.gbProgramHeader.Controls.Add(Me.Label4)
        Me.gbProgramHeader.Controls.Add(Me.txtWhen_Qty_LT)
        Me.gbProgramHeader.Controls.Add(Me.lblWhen_Qty_LT)
        Me.gbProgramHeader.Controls.Add(Me.txtWhen_Qty_GT)
        Me.gbProgramHeader.Controls.Add(Me.lblWhen_Qty_Gt)
        Me.gbProgramHeader.Controls.Add(Me.lblCharge_Usage_ID)
        Me.gbProgramHeader.Controls.Add(Me.chkBlind)
        Me.gbProgramHeader.Controls.Add(Me.chkNo_Charge)
        Me.gbProgramHeader.Controls.Add(Me.cboCharge_Id)
        Me.gbProgramHeader.Controls.Add(Me.txtUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.txtUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.lblUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox17)
        Me.gbProgramHeader.Controls.Add(Me.lblBlind)
        Me.gbProgramHeader.Controls.Add(Me.XTextBox16)
        Me.gbProgramHeader.Controls.Add(Me.lblNo_Charge)
        Me.gbProgramHeader.Controls.Add(Me.lblNever_Use)
        Me.gbProgramHeader.Controls.Add(Me.lblAlways_Use)
        Me.gbProgramHeader.Controls.Add(Me.txtShip_Instructions_2)
        Me.gbProgramHeader.Controls.Add(Me.lblShip_Instructions_2)
        Me.gbProgramHeader.Controls.Add(Me.txtWhen_Amt_LT)
        Me.gbProgramHeader.Controls.Add(Me.lbllblWhen_Amt_LT)
        Me.gbProgramHeader.Controls.Add(Me.txtAutorized_By)
        Me.gbProgramHeader.Controls.Add(Me.lblAutorized_By)
        Me.gbProgramHeader.Controls.Add(Me.lblComments)
        Me.gbProgramHeader.Controls.Add(Me.txtComments)
        Me.gbProgramHeader.Controls.Add(Me.txtEmail_To)
        Me.gbProgramHeader.Controls.Add(Me.lblEmail_To)
        Me.gbProgramHeader.Controls.Add(Me.txtWhen_Amt_GT)
        Me.gbProgramHeader.Controls.Add(Me.lblCharge_Id)
        Me.gbProgramHeader.Controls.Add(Me.txtCharge_Usage_ID)
        Me.gbProgramHeader.Controls.Add(Me.lblWhen_Amt_GT)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_No)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_No)
        Me.gbProgramHeader.Controls.Add(Me.ShapeContainer1)
        Me.gbProgramHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgramHeader.Location = New System.Drawing.Point(10, 26)
        Me.gbProgramHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Name = "gbProgramHeader"
        Me.gbProgramHeader.Padding = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Size = New System.Drawing.Size(652, 345)
        Me.gbProgramHeader.TabIndex = 1
        Me.gbProgramHeader.TabStop = False
        Me.gbProgramHeader.Text = "Option Information"
        '
        'txtUnit_Price
        '
        Me.txtUnit_Price.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtUnit_Price.DataLength = CType(0, Long)
        Me.txtUnit_Price.DataType = CustomerFile.CDataType.dtString
        Me.txtUnit_Price.DateValue = New Date(CType(0, Long))
        Me.txtUnit_Price.DecimalDigits = CType(0, Long)
        Me.txtUnit_Price.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit_Price.Location = New System.Drawing.Point(244, 113)
        Me.txtUnit_Price.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUnit_Price.Mask = Nothing
        Me.txtUnit_Price.Name = "txtUnit_Price"
        Me.txtUnit_Price.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUnit_Price.OldValue = Nothing
        Me.txtUnit_Price.Size = New System.Drawing.Size(76, 21)
        Me.txtUnit_Price.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUnit_Price.StringValue = Nothing
        Me.txtUnit_Price.TabIndex = 54
        Me.txtUnit_Price.TextDataID = Nothing
        '
        'lblUnit_Price
        '
        Me.lblUnit_Price.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit_Price.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUnit_Price.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit_Price.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUnit_Price.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUnit_Price.Location = New System.Drawing.Point(179, 116)
        Me.lblUnit_Price.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUnit_Price.Name = "lblUnit_Price"
        Me.lblUnit_Price.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUnit_Price.Size = New System.Drawing.Size(63, 18)
        Me.lblUnit_Price.TabIndex = 53
        Me.lblUnit_Price.Text = "Unit Price"
        '
        'txtEnd_Dt
        '
        Me.txtEnd_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEnd_Dt.DataLength = CType(0, Long)
        Me.txtEnd_Dt.DataType = CustomerFile.CDataType.dtDate
        Me.txtEnd_Dt.DateValue = New Date(CType(0, Long))
        Me.txtEnd_Dt.DecimalDigits = CType(0, Long)
        Me.txtEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnd_Dt.Location = New System.Drawing.Point(132, 90)
        Me.txtEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEnd_Dt.Mask = Nothing
        Me.txtEnd_Dt.Name = "txtEnd_Dt"
        Me.txtEnd_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEnd_Dt.OldValue = Nothing
        Me.txtEnd_Dt.Size = New System.Drawing.Size(166, 21)
        Me.txtEnd_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEnd_Dt.StringValue = Nothing
        Me.txtEnd_Dt.TabIndex = 38
        Me.txtEnd_Dt.TextDataID = Nothing
        '
        'txtStart_Dt
        '
        Me.txtStart_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtStart_Dt.DataLength = CType(0, Long)
        Me.txtStart_Dt.DataType = CustomerFile.CDataType.dtDate
        Me.txtStart_Dt.DateValue = New Date(CType(0, Long))
        Me.txtStart_Dt.DecimalDigits = CType(0, Long)
        Me.txtStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStart_Dt.Location = New System.Drawing.Point(132, 67)
        Me.txtStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStart_Dt.Mask = Nothing
        Me.txtStart_Dt.Name = "txtStart_Dt"
        Me.txtStart_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStart_Dt.OldValue = Nothing
        Me.txtStart_Dt.Size = New System.Drawing.Size(166, 21)
        Me.txtStart_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStart_Dt.StringValue = Nothing
        Me.txtStart_Dt.TabIndex = 35
        Me.txtStart_Dt.TextDataID = Nothing
        '
        'XTextBox4
        '
        Me.XTextBox4.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTextBox4.DataLength = CType(0, Long)
        Me.XTextBox4.DataType = CustomerFile.CDataType.dtString
        Me.XTextBox4.DateValue = New Date(CType(0, Long))
        Me.XTextBox4.DecimalDigits = CType(0, Long)
        Me.XTextBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTextBox4.Location = New System.Drawing.Point(471, 65)
        Me.XTextBox4.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox4.Mask = Nothing
        Me.XTextBox4.Name = "XTextBox4"
        Me.XTextBox4.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox4.OldValue = Nothing
        Me.XTextBox4.Size = New System.Drawing.Size(169, 21)
        Me.XTextBox4.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox4.StringValue = Nothing
        Me.XTextBox4.TabIndex = 20
        Me.XTextBox4.TextDataID = Nothing
        Me.XTextBox4.Visible = False
        '
        'txtWhen_Qty_LT
        '
        Me.txtWhen_Qty_LT.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhen_Qty_LT.DataLength = CType(0, Long)
        Me.txtWhen_Qty_LT.DataType = CustomerFile.CDataType.dtString
        Me.txtWhen_Qty_LT.DateValue = New Date(CType(0, Long))
        Me.txtWhen_Qty_LT.DecimalDigits = CType(0, Long)
        Me.txtWhen_Qty_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhen_Qty_LT.Location = New System.Drawing.Point(452, 193)
        Me.txtWhen_Qty_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhen_Qty_LT.Mask = Nothing
        Me.txtWhen_Qty_LT.Name = "txtWhen_Qty_LT"
        Me.txtWhen_Qty_LT.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhen_Qty_LT.OldValue = Nothing
        Me.txtWhen_Qty_LT.Size = New System.Drawing.Size(188, 21)
        Me.txtWhen_Qty_LT.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhen_Qty_LT.StringValue = Nothing
        Me.txtWhen_Qty_LT.TabIndex = 33
        Me.txtWhen_Qty_LT.TextDataID = Nothing
        '
        'txtWhen_Qty_GT
        '
        Me.txtWhen_Qty_GT.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhen_Qty_GT.DataLength = CType(0, Long)
        Me.txtWhen_Qty_GT.DataType = CustomerFile.CDataType.dtString
        Me.txtWhen_Qty_GT.DateValue = New Date(CType(0, Long))
        Me.txtWhen_Qty_GT.DecimalDigits = CType(0, Long)
        Me.txtWhen_Qty_GT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhen_Qty_GT.Location = New System.Drawing.Point(132, 193)
        Me.txtWhen_Qty_GT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhen_Qty_GT.Mask = Nothing
        Me.txtWhen_Qty_GT.Name = "txtWhen_Qty_GT"
        Me.txtWhen_Qty_GT.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhen_Qty_GT.OldValue = Nothing
        Me.txtWhen_Qty_GT.Size = New System.Drawing.Size(188, 21)
        Me.txtWhen_Qty_GT.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhen_Qty_GT.StringValue = Nothing
        Me.txtWhen_Qty_GT.TabIndex = 29
        Me.txtWhen_Qty_GT.TextDataID = Nothing
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
        Me.txtUpdate_TS.Location = New System.Drawing.Point(452, 311)
        Me.txtUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUpdate_TS.Mask = Nothing
        Me.txtUpdate_TS.Name = "txtUpdate_TS"
        Me.txtUpdate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUpdate_TS.OldValue = Nothing
        Me.txtUpdate_TS.Size = New System.Drawing.Size(188, 21)
        Me.txtUpdate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUpdate_TS.StringValue = Nothing
        Me.txtUpdate_TS.TabIndex = 52
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
        Me.txtUser_Login.Location = New System.Drawing.Point(132, 311)
        Me.txtUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUser_Login.Mask = Nothing
        Me.txtUser_Login.Name = "txtUser_Login"
        Me.txtUser_Login.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUser_Login.OldValue = Nothing
        Me.txtUser_Login.Size = New System.Drawing.Size(188, 21)
        Me.txtUser_Login.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUser_Login.StringValue = Nothing
        Me.txtUser_Login.TabIndex = 50
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
        Me.XTextBox17.Location = New System.Drawing.Point(471, 88)
        Me.XTextBox17.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox17.Mask = Nothing
        Me.XTextBox17.Name = "XTextBox17"
        Me.XTextBox17.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox17.OldValue = Nothing
        Me.XTextBox17.Size = New System.Drawing.Size(169, 21)
        Me.XTextBox17.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox17.StringValue = Nothing
        Me.XTextBox17.TabIndex = 23
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
        Me.XTextBox16.Location = New System.Drawing.Point(360, 275)
        Me.XTextBox16.Margin = New System.Windows.Forms.Padding(1)
        Me.XTextBox16.Mask = Nothing
        Me.XTextBox16.Name = "XTextBox16"
        Me.XTextBox16.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTextBox16.OldValue = Nothing
        Me.XTextBox16.Size = New System.Drawing.Size(18, 21)
        Me.XTextBox16.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTextBox16.StringValue = Nothing
        Me.XTextBox16.TabIndex = 13
        Me.XTextBox16.TextDataID = Nothing
        Me.XTextBox16.Visible = False
        '
        'txtShip_Instructions_2
        '
        Me.txtShip_Instructions_2.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShip_Instructions_2.DataLength = CType(0, Long)
        Me.txtShip_Instructions_2.DataType = CustomerFile.CDataType.dtString
        Me.txtShip_Instructions_2.DateValue = New Date(CType(0, Long))
        Me.txtShip_Instructions_2.DecimalDigits = CType(0, Long)
        Me.txtShip_Instructions_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip_Instructions_2.Location = New System.Drawing.Point(151, 229)
        Me.txtShip_Instructions_2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShip_Instructions_2.Mask = Nothing
        Me.txtShip_Instructions_2.Name = "txtShip_Instructions_2"
        Me.txtShip_Instructions_2.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShip_Instructions_2.OldValue = Nothing
        Me.txtShip_Instructions_2.Size = New System.Drawing.Size(169, 21)
        Me.txtShip_Instructions_2.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShip_Instructions_2.StringValue = Nothing
        Me.txtShip_Instructions_2.TabIndex = 42
        Me.txtShip_Instructions_2.TextDataID = Nothing
        Me.txtShip_Instructions_2.Visible = False
        '
        'txtWhen_Amt_LT
        '
        Me.txtWhen_Amt_LT.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhen_Amt_LT.DataLength = CType(0, Long)
        Me.txtWhen_Amt_LT.DataType = CustomerFile.CDataType.dtString
        Me.txtWhen_Amt_LT.DateValue = New Date(CType(0, Long))
        Me.txtWhen_Amt_LT.DecimalDigits = CType(0, Long)
        Me.txtWhen_Amt_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhen_Amt_LT.Location = New System.Drawing.Point(452, 170)
        Me.txtWhen_Amt_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhen_Amt_LT.Mask = Nothing
        Me.txtWhen_Amt_LT.Name = "txtWhen_Amt_LT"
        Me.txtWhen_Amt_LT.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhen_Amt_LT.OldValue = Nothing
        Me.txtWhen_Amt_LT.Size = New System.Drawing.Size(188, 21)
        Me.txtWhen_Amt_LT.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhen_Amt_LT.StringValue = Nothing
        Me.txtWhen_Amt_LT.TabIndex = 31
        Me.txtWhen_Amt_LT.TextDataID = Nothing
        '
        'txtAutorized_By
        '
        Me.txtAutorized_By.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtAutorized_By.DataLength = CType(0, Long)
        Me.txtAutorized_By.DataType = CustomerFile.CDataType.dtString
        Me.txtAutorized_By.DateValue = New Date(CType(0, Long))
        Me.txtAutorized_By.DecimalDigits = CType(0, Long)
        Me.txtAutorized_By.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutorized_By.Location = New System.Drawing.Point(132, 275)
        Me.txtAutorized_By.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAutorized_By.Mask = Nothing
        Me.txtAutorized_By.Name = "txtAutorized_By"
        Me.txtAutorized_By.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAutorized_By.OldValue = Nothing
        Me.txtAutorized_By.Size = New System.Drawing.Size(188, 21)
        Me.txtAutorized_By.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtAutorized_By.StringValue = Nothing
        Me.txtAutorized_By.TabIndex = 48
        Me.txtAutorized_By.TextDataID = Nothing
        '
        'txtComments
        '
        Me.txtComments.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtComments.DataLength = CType(0, Long)
        Me.txtComments.DataType = CustomerFile.CDataType.dtString
        Me.txtComments.DateValue = New Date(CType(0, Long))
        Me.txtComments.DecimalDigits = CType(0, Long)
        Me.txtComments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(132, 252)
        Me.txtComments.Margin = New System.Windows.Forms.Padding(1)
        Me.txtComments.Mask = Nothing
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtComments.OldValue = Nothing
        Me.txtComments.Size = New System.Drawing.Size(508, 21)
        Me.txtComments.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtComments.StringValue = Nothing
        Me.txtComments.TabIndex = 46
        Me.txtComments.TextDataID = Nothing
        '
        'txtEmail_To
        '
        Me.txtEmail_To.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmail_To.DataLength = CType(0, Long)
        Me.txtEmail_To.DataType = CustomerFile.CDataType.dtString
        Me.txtEmail_To.DateValue = New Date(CType(0, Long))
        Me.txtEmail_To.DecimalDigits = CType(0, Long)
        Me.txtEmail_To.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail_To.Location = New System.Drawing.Point(452, 229)
        Me.txtEmail_To.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmail_To.Mask = Nothing
        Me.txtEmail_To.Name = "txtEmail_To"
        Me.txtEmail_To.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmail_To.OldValue = Nothing
        Me.txtEmail_To.Size = New System.Drawing.Size(188, 21)
        Me.txtEmail_To.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmail_To.StringValue = Nothing
        Me.txtEmail_To.TabIndex = 44
        Me.txtEmail_To.TextDataID = Nothing
        Me.txtEmail_To.Visible = False
        '
        'txtWhen_Amt_GT
        '
        Me.txtWhen_Amt_GT.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhen_Amt_GT.DataLength = CType(0, Long)
        Me.txtWhen_Amt_GT.DataType = CustomerFile.CDataType.dtString
        Me.txtWhen_Amt_GT.DateValue = New Date(CType(0, Long))
        Me.txtWhen_Amt_GT.DecimalDigits = CType(0, Long)
        Me.txtWhen_Amt_GT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhen_Amt_GT.Location = New System.Drawing.Point(132, 170)
        Me.txtWhen_Amt_GT.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhen_Amt_GT.Mask = Nothing
        Me.txtWhen_Amt_GT.Name = "txtWhen_Amt_GT"
        Me.txtWhen_Amt_GT.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhen_Amt_GT.OldValue = Nothing
        Me.txtWhen_Amt_GT.Size = New System.Drawing.Size(188, 21)
        Me.txtWhen_Amt_GT.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhen_Amt_GT.StringValue = Nothing
        Me.txtWhen_Amt_GT.TabIndex = 27
        Me.txtWhen_Amt_GT.TextDataID = Nothing
        '
        'txtCharge_Usage_ID
        '
        Me.txtCharge_Usage_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCharge_Usage_ID.DataLength = CType(0, Long)
        Me.txtCharge_Usage_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCharge_Usage_ID.DateValue = New Date(CType(0, Long))
        Me.txtCharge_Usage_ID.DecimalDigits = CType(0, Long)
        Me.txtCharge_Usage_ID.Enabled = False
        Me.txtCharge_Usage_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCharge_Usage_ID.Location = New System.Drawing.Point(452, 111)
        Me.txtCharge_Usage_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCharge_Usage_ID.Mask = Nothing
        Me.txtCharge_Usage_ID.Name = "txtCharge_Usage_ID"
        Me.txtCharge_Usage_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCharge_Usage_ID.OldValue = Nothing
        Me.txtCharge_Usage_ID.Size = New System.Drawing.Size(188, 21)
        Me.txtCharge_Usage_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCharge_Usage_ID.StringValue = Nothing
        Me.txtCharge_Usage_ID.TabIndex = 25
        Me.txtCharge_Usage_ID.Text = "0"
        Me.txtCharge_Usage_ID.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Enabled = False
        Me.txtCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_No.Location = New System.Drawing.Point(132, 19)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = Nothing
        Me.txtCus_No.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 2
        Me.txtCus_No.TextDataID = Nothing
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 15)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(650, 329)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 9
        Me.LineShape3.X2 = 638
        Me.LineShape3.Y1 = 287
        Me.LineShape3.Y2 = 287
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 9
        Me.LineShape2.X2 = 638
        Me.LineShape2.Y1 = 206
        Me.LineShape2.Y2 = 206
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 8
        Me.LineShape1.X2 = 637
        Me.LineShape1.Y1 = 146
        Me.LineShape1.Y2 = 146
        '
        'chkAllGroup
        '
        Me.chkAllGroup.AutoSize = True
        Me.chkAllGroup.BackColor = System.Drawing.SystemColors.Control
        Me.chkAllGroup.Location = New System.Drawing.Point(509, 6)
        Me.chkAllGroup.Name = "chkAllGroup"
        Me.chkAllGroup.Size = New System.Drawing.Size(15, 14)
        Me.chkAllGroup.TabIndex = 72
        Me.chkAllGroup.UseVisualStyleBackColor = False
        '
        'frmMDB_CFG_CHARGE_USAGE
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(672, 381)
        Me.Controls.Add(Me.chkAllGroup)
        Me.Controls.Add(Me.gbProgramHeader)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMDB_CFG_CHARGE_USAGE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CHG-USG-001"
        Me.Text = "Option Maintenance"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.gbProgramHeader.ResumeLayout(False)
        Me.gbProgramHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblWhen_Amt_GT As System.Windows.Forms.Label
    Friend WithEvents txtCharge_Usage_ID As CustomerFile.xTextBox
    Friend WithEvents lblCharge_Id As System.Windows.Forms.Label
    Friend WithEvents txtWhen_Amt_GT As CustomerFile.xTextBox
    Friend WithEvents lblEmail_To As System.Windows.Forms.Label
    Friend WithEvents txtEmail_To As CustomerFile.xTextBox
    Friend WithEvents txtComments As CustomerFile.xTextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblAutorized_By As System.Windows.Forms.Label
    Friend WithEvents txtAutorized_By As CustomerFile.xTextBox
    Friend WithEvents lbllblWhen_Amt_LT As System.Windows.Forms.Label
    Friend WithEvents txtWhen_Amt_LT As CustomerFile.xTextBox
    Friend WithEvents lblShip_Instructions_2 As System.Windows.Forms.Label
    Friend WithEvents txtShip_Instructions_2 As CustomerFile.xTextBox
    Friend WithEvents lblAlways_Use As System.Windows.Forms.Label
    Friend WithEvents lblNever_Use As System.Windows.Forms.Label
    Friend WithEvents lblNo_Charge As System.Windows.Forms.Label
    Friend WithEvents XTextBox16 As CustomerFile.xTextBox
    Friend WithEvents lblBlind As System.Windows.Forms.Label
    Friend WithEvents XTextBox17 As CustomerFile.xTextBox
    Friend WithEvents lblUser_Login As System.Windows.Forms.Label
    Friend WithEvents txtUser_Login As CustomerFile.xTextBox
    Friend WithEvents lblUpdate_TS As System.Windows.Forms.Label
    Friend WithEvents txtUpdate_TS As CustomerFile.xTextBox
    Friend WithEvents cboCharge_Id As System.Windows.Forms.ComboBox
    Friend WithEvents chkAlways_Use As System.Windows.Forms.CheckBox
    Friend WithEvents chkNever_Use As System.Windows.Forms.CheckBox
    Friend WithEvents chkNo_Charge As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlind As System.Windows.Forms.CheckBox
    Friend WithEvents lblCharge_Usage_ID As System.Windows.Forms.Label
    Friend WithEvents lblWhen_Qty_Gt As System.Windows.Forms.Label
    Friend WithEvents txtWhen_Qty_GT As CustomerFile.xTextBox
    Friend WithEvents lblWhen_Qty_LT As System.Windows.Forms.Label
    Friend WithEvents txtWhen_Qty_LT As CustomerFile.xTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents XTextBox4 As CustomerFile.xTextBox
    Friend WithEvents lblApply_To_Ship_To As System.Windows.Forms.Label
    Friend WithEvents lblApply_To_Program As System.Windows.Forms.Label
    Friend WithEvents cboApply_To_Program As System.Windows.Forms.ComboBox
    Friend WithEvents cboApply_To_Ship_To As System.Windows.Forms.ComboBox
    Friend WithEvents chkSend_Email As System.Windows.Forms.CheckBox
    Friend WithEvents chkWhen_Req As System.Windows.Forms.CheckBox
    Friend WithEvents lblStart_Dt As System.Windows.Forms.Label
    Friend WithEvents lblEnd_Dt As System.Windows.Forms.Label
    Friend WithEvents txtStart_Dt As CustomerFile.xTextBox
    Friend WithEvents txtEnd_Dt As CustomerFile.xTextBox
    Friend WithEvents cmdStart_Dt As System.Windows.Forms.Button
    Friend WithEvents cmdEnd_Dt As System.Windows.Forms.Button
    Friend WithEvents gbProgramHeader As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtUnit_Price As CustomerFile.xTextBox
    Friend WithEvents lblUnit_Price As System.Windows.Forms.Label
    Friend WithEvents chkAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
