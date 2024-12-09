<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMdb_Cus_Comment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMdb_Cus_Comment))
        Me.gbProgramHeader = New System.Windows.Forms.GroupBox()
        Me.txtComment_Order = New CustomerFile.xTextBox()
        Me.lblWhen_Qty_Gt = New System.Windows.Forms.Label()
        Me.cboComment_Type_ID = New System.Windows.Forms.ComboBox()
        Me.txtUpdate_TS = New CustomerFile.xTextBox()
        Me.lblUpdate_TS = New System.Windows.Forms.Label()
        Me.txtUser_Login = New CustomerFile.xTextBox()
        Me.lblUser_Login = New System.Windows.Forms.Label()
        Me.txtCus_Comment_ID = New CustomerFile.xTextBox()
        Me.lbllblWhen_Amt_LT = New System.Windows.Forms.Label()
        Me.txtCus_Comment = New CustomerFile.xTextBox()
        Me.lblCharge_Id = New System.Windows.Forms.Label()
        Me.lblWhen_Amt_GT = New System.Windows.Forms.Label()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.gbProgramHeader.SuspendLayout()
        Me.tsProgramMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProgramHeader
        '
        Me.gbProgramHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramHeader.Controls.Add(Me.txtComment_Order)
        Me.gbProgramHeader.Controls.Add(Me.lblWhen_Qty_Gt)
        Me.gbProgramHeader.Controls.Add(Me.cboComment_Type_ID)
        Me.gbProgramHeader.Controls.Add(Me.txtUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.lblUpdate_TS)
        Me.gbProgramHeader.Controls.Add(Me.txtUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.lblUser_Login)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_Comment_ID)
        Me.gbProgramHeader.Controls.Add(Me.lbllblWhen_Amt_LT)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_Comment)
        Me.gbProgramHeader.Controls.Add(Me.lblCharge_Id)
        Me.gbProgramHeader.Controls.Add(Me.lblWhen_Amt_GT)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_No)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_No)
        Me.gbProgramHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgramHeader.Location = New System.Drawing.Point(10, 26)
        Me.gbProgramHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Name = "gbProgramHeader"
        Me.gbProgramHeader.Padding = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Size = New System.Drawing.Size(650, 311)
        Me.gbProgramHeader.TabIndex = 7
        Me.gbProgramHeader.TabStop = False
        Me.gbProgramHeader.Text = "Customer Comment"
        '
        'txtComment_Order
        '
        Me.txtComment_Order.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtComment_Order.DataLength = CType(0, Long)
        Me.txtComment_Order.DataType = CustomerFile.CDataType.dtString
        Me.txtComment_Order.DateValue = New Date(CType(0, Long))
        Me.txtComment_Order.DecimalDigits = CType(0, Long)
        Me.txtComment_Order.Enabled = False
        Me.txtComment_Order.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment_Order.Location = New System.Drawing.Point(132, 243)
        Me.txtComment_Order.Margin = New System.Windows.Forms.Padding(1)
        Me.txtComment_Order.Mask = Nothing
        Me.txtComment_Order.Name = "txtComment_Order"
        Me.txtComment_Order.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtComment_Order.OldValue = Nothing
        Me.txtComment_Order.Size = New System.Drawing.Size(188, 21)
        Me.txtComment_Order.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtComment_Order.StringValue = Nothing
        Me.txtComment_Order.TabIndex = 47
        Me.txtComment_Order.TextDataID = Nothing
        '
        'lblWhen_Qty_Gt
        '
        Me.lblWhen_Qty_Gt.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Qty_Gt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Qty_Gt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Qty_Gt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Qty_Gt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Qty_Gt.Location = New System.Drawing.Point(7, 244)
        Me.lblWhen_Qty_Gt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Qty_Gt.Name = "lblWhen_Qty_Gt"
        Me.lblWhen_Qty_Gt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Qty_Gt.Size = New System.Drawing.Size(119, 21)
        Me.lblWhen_Qty_Gt.TabIndex = 48
        Me.lblWhen_Qty_Gt.Text = "Comment Order"
        '
        'cboComment_Type_ID
        '
        Me.cboComment_Type_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComment_Type_ID.FormattingEnabled = True
        Me.cboComment_Type_ID.Location = New System.Drawing.Point(132, 65)
        Me.cboComment_Type_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.cboComment_Type_ID.Name = "cboComment_Type_ID"
        Me.cboComment_Type_ID.Size = New System.Drawing.Size(188, 23)
        Me.cboComment_Type_ID.TabIndex = 2
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
        Me.txtUpdate_TS.Location = New System.Drawing.Point(452, 278)
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
        'lblUpdate_TS
        '
        Me.lblUpdate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblUpdate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdate_TS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUpdate_TS.Location = New System.Drawing.Point(328, 281)
        Me.lblUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUpdate_TS.Name = "lblUpdate_TS"
        Me.lblUpdate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdate_TS.Size = New System.Drawing.Size(119, 25)
        Me.lblUpdate_TS.TabIndex = 43
        Me.lblUpdate_TS.Text = "Modified Date"
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
        Me.txtUser_Login.Location = New System.Drawing.Point(132, 278)
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
        'lblUser_Login
        '
        Me.lblUser_Login.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser_Login.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser_Login.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser_Login.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUser_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUser_Login.Location = New System.Drawing.Point(7, 281)
        Me.lblUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUser_Login.Name = "lblUser_Login"
        Me.lblUser_Login.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser_Login.Size = New System.Drawing.Size(123, 25)
        Me.lblUser_Login.TabIndex = 41
        Me.lblUser_Login.Text = "Modified By"
        '
        'txtCus_Comment_ID
        '
        Me.txtCus_Comment_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Comment_ID.DataLength = CType(0, Long)
        Me.txtCus_Comment_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Comment_ID.DateValue = New Date(CType(0, Long))
        Me.txtCus_Comment_ID.DecimalDigits = CType(0, Long)
        Me.txtCus_Comment_ID.Enabled = False
        Me.txtCus_Comment_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Comment_ID.Location = New System.Drawing.Point(132, 19)
        Me.txtCus_Comment_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Comment_ID.Mask = Nothing
        Me.txtCus_Comment_ID.Name = "txtCus_Comment_ID"
        Me.txtCus_Comment_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Comment_ID.OldValue = Nothing
        Me.txtCus_Comment_ID.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_Comment_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Comment_ID.StringValue = Nothing
        Me.txtCus_Comment_ID.TabIndex = 20
        Me.txtCus_Comment_ID.TextDataID = Nothing
        '
        'lbllblWhen_Amt_LT
        '
        Me.lbllblWhen_Amt_LT.BackColor = System.Drawing.SystemColors.Control
        Me.lbllblWhen_Amt_LT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbllblWhen_Amt_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblWhen_Amt_LT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbllblWhen_Amt_LT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbllblWhen_Amt_LT.Location = New System.Drawing.Point(8, 22)
        Me.lbllblWhen_Amt_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.lbllblWhen_Amt_LT.Name = "lbllblWhen_Amt_LT"
        Me.lbllblWhen_Amt_LT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbllblWhen_Amt_LT.Size = New System.Drawing.Size(116, 25)
        Me.lbllblWhen_Amt_LT.TabIndex = 19
        Me.lbllblWhen_Amt_LT.Text = "Comment ID"
        '
        'txtCus_Comment
        '
        Me.txtCus_Comment.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Comment.DataLength = CType(0, Long)
        Me.txtCus_Comment.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Comment.DateValue = New Date(CType(0, Long))
        Me.txtCus_Comment.DecimalDigits = CType(0, Long)
        Me.txtCus_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Comment.Location = New System.Drawing.Point(132, 90)
        Me.txtCus_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Comment.Mask = Nothing
        Me.txtCus_Comment.Multiline = True
        Me.txtCus_Comment.Name = "txtCus_Comment"
        Me.txtCus_Comment.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Comment.OldValue = Nothing
        Me.txtCus_Comment.Size = New System.Drawing.Size(508, 151)
        Me.txtCus_Comment.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Comment.StringValue = Nothing
        Me.txtCus_Comment.TabIndex = 18
        Me.txtCus_Comment.TextDataID = Nothing
        '
        'lblCharge_Id
        '
        Me.lblCharge_Id.BackColor = System.Drawing.SystemColors.Control
        Me.lblCharge_Id.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCharge_Id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge_Id.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCharge_Id.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCharge_Id.Location = New System.Drawing.Point(7, 68)
        Me.lblCharge_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCharge_Id.Name = "lblCharge_Id"
        Me.lblCharge_Id.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCharge_Id.Size = New System.Drawing.Size(119, 25)
        Me.lblCharge_Id.TabIndex = 1
        Me.lblCharge_Id.Text = "Comment Type"
        '
        'lblWhen_Amt_GT
        '
        Me.lblWhen_Amt_GT.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Amt_GT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Amt_GT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Amt_GT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Amt_GT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Amt_GT.Location = New System.Drawing.Point(7, 93)
        Me.lblWhen_Amt_GT.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Amt_GT.Name = "lblWhen_Amt_GT"
        Me.lblWhen_Amt_GT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Amt_GT.Size = New System.Drawing.Size(123, 20)
        Me.lblWhen_Amt_GT.TabIndex = 7
        Me.lblWhen_Amt_GT.Text = "Comment"
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
        Me.txtCus_No.Location = New System.Drawing.Point(132, 42)
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
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(7, 45)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(113, 25)
        Me.lblCus_No.TabIndex = 3
        Me.lblCus_No.Text = "Customer"
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(670, 25)
        Me.tsProgramMenu.TabIndex = 8
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
        Me.tsClose.Size = New System.Drawing.Size(37, 22)
        Me.tsClose.Text = "Close"
        Me.tsClose.Visible = False
        '
        'frmMdb_Cus_Comment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(670, 347)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.gbProgramHeader)
        Me.Name = "frmMdb_Cus_Comment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CUS-CMT-001"
        Me.Text = "Customer Comments"
        Me.gbProgramHeader.ResumeLayout(False)
        Me.gbProgramHeader.PerformLayout()
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbProgramHeader As System.Windows.Forms.GroupBox
    Friend WithEvents txtComment_Order As CustomerFile.xTextBox
    Friend WithEvents lblWhen_Qty_Gt As System.Windows.Forms.Label
    Friend WithEvents cboComment_Type_ID As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpdate_TS As CustomerFile.xTextBox
    Friend WithEvents lblUpdate_TS As System.Windows.Forms.Label
    Friend WithEvents txtUser_Login As CustomerFile.xTextBox
    Friend WithEvents lblUser_Login As System.Windows.Forms.Label
    Friend WithEvents txtCus_Comment_ID As CustomerFile.xTextBox
    Friend WithEvents lbllblWhen_Amt_LT As System.Windows.Forms.Label
    Friend WithEvents txtCus_Comment As CustomerFile.xTextBox
    Friend WithEvents lblCharge_Id As System.Windows.Forms.Label
    Friend WithEvents lblWhen_Amt_GT As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
End Class
