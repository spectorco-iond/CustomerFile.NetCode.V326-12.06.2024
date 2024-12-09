<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGlobalOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageGlobalOptions))
        Me.gbProgramHeader = New System.Windows.Forms.GroupBox()
        Me.chkNever = New System.Windows.Forms.CheckBox()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnUpdateDt = New System.Windows.Forms.Button()
        Me.chkAlwaysExe = New System.Windows.Forms.CheckBox()
        Me.lblItem_No = New System.Windows.Forms.Label()
        Me.txtItem_No = New System.Windows.Forms.TextBox()
        Me.lblUpdate_TS = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.drpFunction = New System.Windows.Forms.GroupBox()
        Me.radNew = New System.Windows.Forms.RadioButton()
        Me.radUpdate = New System.Windows.Forms.RadioButton()
        Me.gbAIO_Options = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvOptions = New System.Windows.Forms.DataGridView()
        Me.cmdEnd_Dt = New System.Windows.Forms.Button()
        Me.cmdStart_Dt = New System.Windows.Forms.Button()
        Me.lblEnd_Dt = New System.Windows.Forms.Label()
        Me.lblStart_Dt = New System.Windows.Forms.Label()
        Me.cboCharge_Id = New System.Windows.Forms.ComboBox()
        Me.lblCreate_TS = New System.Windows.Forms.Label()
        Me.lblUser_Login = New System.Windows.Forms.Label()
        Me.lblCharge_Id = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.txtUpdate_TS = New CustomerFile.xTextBox()
        Me.txtID = New CustomerFile.xTextBox()
        Me.txtEnd_Dt = New CustomerFile.xTextBox()
        Me.txtStart_Dt = New CustomerFile.xTextBox()
        Me.txtCreate_TS = New CustomerFile.xTextBox()
        Me.txtUser_Login = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.gbProgramHeader.SuspendLayout()
        Me.drpFunction.SuspendLayout()
        Me.gbAIO_Options.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProgramHeader
        '
        Me.gbProgramHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramHeader.Controls.Add(Me.chkNever)
        Me.gbProgramHeader.Controls.Add(Me.mcCalendar)
        Me.gbProgramHeader.Controls.Add(Me.btnUpdateDt)
        Me.gbProgramHeader.Controls.Add(Me.chkAlwaysExe)
        Me.gbProgramHeader.Controls.Add(Me.lblItem_No)
        Me.gbProgramHeader.Controls.Add(Me.txtItem_No)
        Me.gbProgramHeader.Controls.Add(Me.txtUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblPrice)
        Me.gbProgramHeader.Controls.Add(Me.txtPrice)
        Me.gbProgramHeader.Controls.Add(Me.txtID)
        Me.gbProgramHeader.Controls.Add(Me.drpFunction)
        Me.gbProgramHeader.Controls.Add(Me.gbAIO_Options)
        Me.gbProgramHeader.Controls.Add(Me.cmdEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.cmdStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.cboCharge_Id)
        Me.gbProgramHeader.Controls.Add(Me.txtCreate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblCreate_TS)
        Me.gbProgramHeader.Controls.Add(Me.txtUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.lblUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.lblCharge_Id)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_No)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_No)
        Me.gbProgramHeader.Controls.Add(Me.ShapeContainer1)
        Me.gbProgramHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgramHeader.Location = New System.Drawing.Point(13, 32)
        Me.gbProgramHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Name = "gbProgramHeader"
        Me.gbProgramHeader.Padding = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Size = New System.Drawing.Size(861, 444)
        Me.gbProgramHeader.TabIndex = 2
        Me.gbProgramHeader.TabStop = False
        Me.gbProgramHeader.Text = "Option Information"
        '
        'chkNever
        '
        Me.chkNever.AutoSize = True
        Me.chkNever.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNever.Location = New System.Drawing.Point(300, 208)
        Me.chkNever.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNever.Name = "chkNever"
        Me.chkNever.Size = New System.Drawing.Size(68, 21)
        Me.chkNever.TabIndex = 87
        Me.chkNever.Text = "Never"
        Me.chkNever.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkNever.UseVisualStyleBackColor = True
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(222, 323)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 85
        Me.mcCalendar.Visible = False
        '
        'btnUpdateDt
        '
        Me.btnUpdateDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateDt.Location = New System.Drawing.Point(13, 204)
        Me.btnUpdateDt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateDt.Name = "btnUpdateDt"
        Me.btnUpdateDt.Size = New System.Drawing.Size(100, 28)
        Me.btnUpdateDt.TabIndex = 84
        Me.btnUpdateDt.Text = "Update Dt"
        Me.btnUpdateDt.UseVisualStyleBackColor = True
        '
        'chkAlwaysExe
        '
        Me.chkAlwaysExe.AutoSize = True
        Me.chkAlwaysExe.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAlwaysExe.Location = New System.Drawing.Point(184, 209)
        Me.chkAlwaysExe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkAlwaysExe.Name = "chkAlwaysExe"
        Me.chkAlwaysExe.Size = New System.Drawing.Size(76, 21)
        Me.chkAlwaysExe.TabIndex = 83
        Me.chkAlwaysExe.Text = "Always"
        Me.chkAlwaysExe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkAlwaysExe.UseVisualStyleBackColor = True
        '
        'lblItem_No
        '
        Me.lblItem_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblItem_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItem_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItem_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblItem_No.Location = New System.Drawing.Point(16, 142)
        Me.lblItem_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblItem_No.Name = "lblItem_No"
        Me.lblItem_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItem_No.Size = New System.Drawing.Size(159, 28)
        Me.lblItem_No.TabIndex = 80
        Me.lblItem_No.Text = "Item No"
        '
        'txtItem_No
        '
        Me.txtItem_No.Location = New System.Drawing.Point(223, 144)
        Me.txtItem_No.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtItem_No.Name = "txtItem_No"
        Me.txtItem_No.ReadOnly = True
        Me.txtItem_No.Size = New System.Drawing.Size(161, 25)
        Me.txtItem_No.TabIndex = 79
        '
        'lblUpdate_TS
        '
        Me.lblUpdate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblUpdate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdate_TS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUpdate_TS.Location = New System.Drawing.Point(265, 402)
        Me.lblUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUpdate_TS.Name = "lblUpdate_TS"
        Me.lblUpdate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdate_TS.Size = New System.Drawing.Size(111, 22)
        Me.lblUpdate_TS.TabIndex = 77
        Me.lblUpdate_TS.Text = "Modified Date"
        '
        'lblPrice
        '
        Me.lblPrice.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrice.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrice.Location = New System.Drawing.Point(16, 172)
        Me.lblPrice.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrice.Size = New System.Drawing.Size(159, 28)
        Me.lblPrice.TabIndex = 76
        Me.lblPrice.Text = "Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(253, 175)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(131, 25)
        Me.txtPrice.TabIndex = 75
        '
        'drpFunction
        '
        Me.drpFunction.Controls.Add(Me.radNew)
        Me.drpFunction.Controls.Add(Me.radUpdate)
        Me.drpFunction.Location = New System.Drawing.Point(65, 22)
        Me.drpFunction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.drpFunction.Name = "drpFunction"
        Me.drpFunction.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.drpFunction.Size = New System.Drawing.Size(320, 43)
        Me.drpFunction.TabIndex = 73
        Me.drpFunction.TabStop = False
        Me.drpFunction.Text = "Function"
        '
        'radNew
        '
        Me.radNew.AutoSize = True
        Me.radNew.Checked = True
        Me.radNew.Location = New System.Drawing.Point(157, 17)
        Me.radNew.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.radNew.Name = "radNew"
        Me.radNew.Size = New System.Drawing.Size(138, 21)
        Me.radNew.TabIndex = 1
        Me.radNew.TabStop = True
        Me.radNew.Text = "Add New Option "
        Me.radNew.UseVisualStyleBackColor = True
        '
        'radUpdate
        '
        Me.radUpdate.AutoSize = True
        Me.radUpdate.Location = New System.Drawing.Point(9, 17)
        Me.radUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.radUpdate.Name = "radUpdate"
        Me.radUpdate.Size = New System.Drawing.Size(122, 21)
        Me.radUpdate.TabIndex = 0
        Me.radUpdate.Text = "Update Option"
        Me.radUpdate.UseVisualStyleBackColor = True
        '
        'gbAIO_Options
        '
        Me.gbAIO_Options.Controls.Add(Me.Panel4)
        Me.gbAIO_Options.Location = New System.Drawing.Point(421, 18)
        Me.gbAIO_Options.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAIO_Options.Name = "gbAIO_Options"
        Me.gbAIO_Options.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbAIO_Options.Size = New System.Drawing.Size(432, 295)
        Me.gbAIO_Options.TabIndex = 71
        Me.gbAIO_Options.TabStop = False
        Me.gbAIO_Options.Text = "Options"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvOptions)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(4, 22)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 269)
        Me.Panel4.TabIndex = 3
        '
        'dgvOptions
        '
        Me.dgvOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptions.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvOptions.Name = "dgvOptions"
        Me.dgvOptions.ReadOnly = True
        Me.dgvOptions.Size = New System.Drawing.Size(424, 269)
        Me.dgvOptions.TabIndex = 2
        '
        'cmdEnd_Dt
        '
        Me.cmdEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnd_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnd_Dt.Image = CType(resources.GetObject("cmdEnd_Dt.Image"), System.Drawing.Image)
        Me.cmdEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdEnd_Dt.Location = New System.Drawing.Point(356, 265)
        Me.cmdEnd_Dt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdEnd_Dt.Name = "cmdEnd_Dt"
        Me.cmdEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnd_Dt.Size = New System.Drawing.Size(28, 27)
        Me.cmdEnd_Dt.TabIndex = 39
        Me.cmdEnd_Dt.TabStop = False
        Me.cmdEnd_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEnd_Dt.UseVisualStyleBackColor = False
        '
        'cmdStart_Dt
        '
        Me.cmdStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart_Dt.Image = CType(resources.GetObject("cmdStart_Dt.Image"), System.Drawing.Image)
        Me.cmdStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStart_Dt.Location = New System.Drawing.Point(356, 236)
        Me.cmdStart_Dt.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdStart_Dt.Name = "cmdStart_Dt"
        Me.cmdStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart_Dt.Size = New System.Drawing.Size(28, 27)
        Me.cmdStart_Dt.TabIndex = 36
        Me.cmdStart_Dt.TabStop = False
        Me.cmdStart_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStart_Dt.UseVisualStyleBackColor = False
        '
        'lblEnd_Dt
        '
        Me.lblEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnd_Dt.Location = New System.Drawing.Point(15, 268)
        Me.lblEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnd_Dt.Name = "lblEnd_Dt"
        Me.lblEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnd_Dt.Size = New System.Drawing.Size(147, 27)
        Me.lblEnd_Dt.TabIndex = 37
        Me.lblEnd_Dt.Text = "End Date"
        '
        'lblStart_Dt
        '
        Me.lblStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStart_Dt.Location = New System.Drawing.Point(13, 241)
        Me.lblStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStart_Dt.Name = "lblStart_Dt"
        Me.lblStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStart_Dt.Size = New System.Drawing.Size(147, 27)
        Me.lblStart_Dt.TabIndex = 34
        Me.lblStart_Dt.Text = "Start Date"
        '
        'cboCharge_Id
        '
        Me.cboCharge_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCharge_Id.FormattingEnabled = True
        Me.cboCharge_Id.Location = New System.Drawing.Point(115, 111)
        Me.cboCharge_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.cboCharge_Id.Name = "cboCharge_Id"
        Me.cboCharge_Id.Size = New System.Drawing.Size(269, 25)
        Me.cboCharge_Id.TabIndex = 4
        '
        'lblCreate_TS
        '
        Me.lblCreate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCreate_TS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCreate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCreate_TS.Location = New System.Drawing.Point(15, 402)
        Me.lblCreate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCreate_TS.Name = "lblCreate_TS"
        Me.lblCreate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCreate_TS.Size = New System.Drawing.Size(85, 22)
        Me.lblCreate_TS.TabIndex = 51
        Me.lblCreate_TS.Text = "Create Date"
        '
        'lblUser_Login
        '
        Me.lblUser_Login.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUser_Login.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser_Login.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser_Login.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser_Login.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUser_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUser_Login.Location = New System.Drawing.Point(631, 402)
        Me.lblUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUser_Login.Name = "lblUser_Login"
        Me.lblUser_Login.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser_Login.Size = New System.Drawing.Size(89, 22)
        Me.lblUser_Login.TabIndex = 49
        Me.lblUser_Login.Text = "Modified By"
        '
        'lblCharge_Id
        '
        Me.lblCharge_Id.BackColor = System.Drawing.SystemColors.Control
        Me.lblCharge_Id.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCharge_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge_Id.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCharge_Id.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCharge_Id.Location = New System.Drawing.Point(15, 114)
        Me.lblCharge_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCharge_Id.Name = "lblCharge_Id"
        Me.lblCharge_Id.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCharge_Id.Size = New System.Drawing.Size(159, 31)
        Me.lblCharge_Id.TabIndex = 3
        Me.lblCharge_Id.Text = "Option"
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(15, 86)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(151, 31)
        Me.lblCus_No.TabIndex = 1
        Me.lblCus_No.Text = "Customer"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 19)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(859, 424)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 9
        Me.LineShape3.X2 = 638
        Me.LineShape3.Y1 = 297
        Me.LineShape3.Y2 = 297
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(888, 27)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(44, 24)
        Me.tsSave.Text = "Save"
        '
        'tsDelete
        '
        Me.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDelete.Image = CType(resources.GetObject("tsDelete.Image"), System.Drawing.Image)
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(57, 24)
        Me.tsDelete.Text = "Delete"
        Me.tsDelete.Visible = False
        '
        'txtUpdate_TS
        '
        Me.txtUpdate_TS.BackColor = System.Drawing.SystemColors.Window
        Me.txtUpdate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtUpdate_TS.DataLength = CType(0, Long)
        Me.txtUpdate_TS.DataType = CustomerFile.CDataType.dtDateTime
        Me.txtUpdate_TS.DateValue = New Date(CType(0, Long))
        Me.txtUpdate_TS.DecimalDigits = CType(0, Long)
        Me.txtUpdate_TS.Enabled = False
        Me.txtUpdate_TS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdate_TS.Location = New System.Drawing.Point(379, 399)
        Me.txtUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUpdate_TS.Mask = Nothing
        Me.txtUpdate_TS.Name = "txtUpdate_TS"
        Me.txtUpdate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUpdate_TS.OldValue = Nothing
        Me.txtUpdate_TS.ReadOnly = True
        Me.txtUpdate_TS.Size = New System.Drawing.Size(129, 23)
        Me.txtUpdate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUpdate_TS.StringValue = Nothing
        Me.txtUpdate_TS.TabIndex = 78
        Me.txtUpdate_TS.TextDataID = Nothing
        '
        'txtID
        '
        Me.txtID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtID.DataLength = CType(0, Long)
        Me.txtID.DataType = CustomerFile.CDataType.dtString
        Me.txtID.DateValue = New Date(CType(0, Long))
        Me.txtID.DecimalDigits = CType(0, Long)
        Me.txtID.Enabled = False
        Me.txtID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(503, 331)
        Me.txtID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtID.Mask = Nothing
        Me.txtID.Name = "txtID"
        Me.txtID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtID.OldValue = Nothing
        Me.txtID.Size = New System.Drawing.Size(249, 25)
        Me.txtID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtID.StringValue = Nothing
        Me.txtID.TabIndex = 74
        Me.txtID.TextDataID = Nothing
        '
        'txtEnd_Dt
        '
        Me.txtEnd_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEnd_Dt.DataLength = CType(0, Long)
        Me.txtEnd_Dt.DataType = CustomerFile.CDataType.dtDate
        Me.txtEnd_Dt.DateValue = New Date(CType(0, Long))
        Me.txtEnd_Dt.DecimalDigits = CType(0, Long)
        Me.txtEnd_Dt.Enabled = False
        Me.txtEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnd_Dt.Location = New System.Drawing.Point(133, 266)
        Me.txtEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEnd_Dt.Mask = Nothing
        Me.txtEnd_Dt.Name = "txtEnd_Dt"
        Me.txtEnd_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEnd_Dt.OldValue = Nothing
        Me.txtEnd_Dt.Size = New System.Drawing.Size(220, 25)
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
        Me.txtStart_Dt.Enabled = False
        Me.txtStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStart_Dt.Location = New System.Drawing.Point(133, 238)
        Me.txtStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStart_Dt.Mask = Nothing
        Me.txtStart_Dt.Name = "txtStart_Dt"
        Me.txtStart_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStart_Dt.OldValue = Nothing
        Me.txtStart_Dt.Size = New System.Drawing.Size(220, 25)
        Me.txtStart_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStart_Dt.StringValue = Nothing
        Me.txtStart_Dt.TabIndex = 35
        Me.txtStart_Dt.TextDataID = Nothing
        '
        'txtCreate_TS
        '
        Me.txtCreate_TS.BackColor = System.Drawing.SystemColors.Window
        Me.txtCreate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCreate_TS.DataLength = CType(0, Long)
        Me.txtCreate_TS.DataType = CustomerFile.CDataType.dtDateTime
        Me.txtCreate_TS.DateValue = New Date(CType(0, Long))
        Me.txtCreate_TS.DecimalDigits = CType(0, Long)
        Me.txtCreate_TS.Enabled = False
        Me.txtCreate_TS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreate_TS.Location = New System.Drawing.Point(115, 399)
        Me.txtCreate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCreate_TS.Mask = Nothing
        Me.txtCreate_TS.Name = "txtCreate_TS"
        Me.txtCreate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCreate_TS.OldValue = Nothing
        Me.txtCreate_TS.ReadOnly = True
        Me.txtCreate_TS.Size = New System.Drawing.Size(129, 23)
        Me.txtCreate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCreate_TS.StringValue = Nothing
        Me.txtCreate_TS.TabIndex = 52
        Me.txtCreate_TS.TextDataID = Nothing
        '
        'txtUser_Login
        '
        Me.txtUser_Login.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUser_Login.BackColor = System.Drawing.SystemColors.Window
        Me.txtUser_Login.CharacterInput = CustomerFile.Cinput.CharactersOnly
        Me.txtUser_Login.DataLength = CType(0, Long)
        Me.txtUser_Login.DataType = CustomerFile.CDataType.dtString
        Me.txtUser_Login.DateValue = New Date(CType(0, Long))
        Me.txtUser_Login.DecimalDigits = CType(0, Long)
        Me.txtUser_Login.Enabled = False
        Me.txtUser_Login.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser_Login.Location = New System.Drawing.Point(723, 399)
        Me.txtUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUser_Login.Mask = Nothing
        Me.txtUser_Login.Name = "txtUser_Login"
        Me.txtUser_Login.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUser_Login.OldValue = Nothing
        Me.txtUser_Login.ReadOnly = True
        Me.txtUser_Login.Size = New System.Drawing.Size(129, 23)
        Me.txtUser_Login.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUser_Login.StringValue = Nothing
        Me.txtUser_Login.TabIndex = 50
        Me.txtUser_Login.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_No.Location = New System.Drawing.Point(115, 82)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = Nothing
        Me.txtCus_No.ReadOnly = True
        Me.txtCus_No.Size = New System.Drawing.Size(269, 25)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 2
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmManageGlobalOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 489)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbProgramHeader)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmManageGlobalOptions"
        Me.Tag = "CF-CTL-CHG-AGOP-001"
        Me.Text = "Manage Global Options"
        Me.gbProgramHeader.ResumeLayout(False)
        Me.gbProgramHeader.PerformLayout()
        Me.drpFunction.ResumeLayout(False)
        Me.drpFunction.PerformLayout()
        Me.gbAIO_Options.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbProgramHeader As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEnd_Dt As System.Windows.Forms.Button
    Friend WithEvents cmdStart_Dt As System.Windows.Forms.Button
    Friend WithEvents txtEnd_Dt As CustomerFile.xTextBox
    Friend WithEvents txtStart_Dt As CustomerFile.xTextBox
    Friend WithEvents lblEnd_Dt As System.Windows.Forms.Label
    Friend WithEvents lblStart_Dt As System.Windows.Forms.Label
    Friend WithEvents cboCharge_Id As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreate_TS As CustomerFile.xTextBox
    Friend WithEvents lblCreate_TS As System.Windows.Forms.Label
    Friend WithEvents txtUser_Login As CustomerFile.xTextBox
    Friend WithEvents lblUser_Login As System.Windows.Forms.Label
    Friend WithEvents lblCharge_Id As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbAIO_Options As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgvOptions As System.Windows.Forms.DataGridView
    Friend WithEvents drpFunction As System.Windows.Forms.GroupBox
    Friend WithEvents radNew As System.Windows.Forms.RadioButton
    Friend WithEvents radUpdate As System.Windows.Forms.RadioButton
    Friend WithEvents txtID As CustomerFile.xTextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdate_TS As CustomerFile.xTextBox
    Friend WithEvents lblUpdate_TS As System.Windows.Forms.Label
    Friend WithEvents tsDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblItem_No As System.Windows.Forms.Label
    Friend WithEvents txtItem_No As System.Windows.Forms.TextBox
    Friend WithEvents chkAlwaysExe As System.Windows.Forms.CheckBox
    Friend WithEvents btnUpdateDt As System.Windows.Forms.Button
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents chkNever As System.Windows.Forms.CheckBox
    Private WithEvents ShapeContainer1 As ShapeContainer
    Private WithEvents LineShape3 As LineShape
End Class
