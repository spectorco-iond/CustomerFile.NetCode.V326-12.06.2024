<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPushOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPushOrder))
        Me.lblWhen_Qty_Gt = New System.Windows.Forms.Label()
        Me.lblUpdate_TS = New System.Windows.Forms.Label()
        Me.lblUser_Login = New System.Windows.Forms.Label()
        Me.lbllblWhen_Amt_LT = New System.Windows.Forms.Label()
        Me.lblWhen_Amt_GT = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.lblPush_Date = New System.Windows.Forms.Label()
        Me.cmdStart_Dt = New System.Windows.Forms.Button()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.txtStart_Dt = New CustomerFile.xTextBox()
        Me.txtOrd_No = New CustomerFile.xTextBox()
        Me.txtUpdate_TS = New CustomerFile.xTextBox()
        Me.txtUser_Login = New CustomerFile.xTextBox()
        Me.txtCus_Push_Order_ID = New CustomerFile.xTextBox()
        Me.txtOrd_Comment = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.txtCus_Comment_ID = New CustomerFile.xTextBox()
        Me.tsProgramMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWhen_Qty_Gt
        '
        Me.lblWhen_Qty_Gt.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Qty_Gt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Qty_Gt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Qty_Gt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Qty_Gt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Qty_Gt.Location = New System.Drawing.Point(5, 84)
        Me.lblWhen_Qty_Gt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Qty_Gt.Name = "lblWhen_Qty_Gt"
        Me.lblWhen_Qty_Gt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Qty_Gt.Size = New System.Drawing.Size(119, 21)
        Me.lblWhen_Qty_Gt.TabIndex = 5
        Me.lblWhen_Qty_Gt.Text = "Order Number"
        '
        'lblUpdate_TS
        '
        Me.lblUpdate_TS.BackColor = System.Drawing.SystemColors.Control
        Me.lblUpdate_TS.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUpdate_TS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdate_TS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpdate_TS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUpdate_TS.Location = New System.Drawing.Point(6, 306)
        Me.lblUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUpdate_TS.Name = "lblUpdate_TS"
        Me.lblUpdate_TS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUpdate_TS.Size = New System.Drawing.Size(119, 25)
        Me.lblUpdate_TS.TabIndex = 15
        Me.lblUpdate_TS.Text = "Modified Date"
        '
        'lblUser_Login
        '
        Me.lblUser_Login.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser_Login.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUser_Login.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser_Login.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUser_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUser_Login.Location = New System.Drawing.Point(6, 283)
        Me.lblUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUser_Login.Name = "lblUser_Login"
        Me.lblUser_Login.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUser_Login.Size = New System.Drawing.Size(123, 25)
        Me.lblUser_Login.TabIndex = 13
        Me.lblUser_Login.Text = "Modified By"
        '
        'lbllblWhen_Amt_LT
        '
        Me.lbllblWhen_Amt_LT.BackColor = System.Drawing.SystemColors.Control
        Me.lbllblWhen_Amt_LT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbllblWhen_Amt_LT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblWhen_Amt_LT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbllblWhen_Amt_LT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbllblWhen_Amt_LT.Location = New System.Drawing.Point(6, 38)
        Me.lbllblWhen_Amt_LT.Margin = New System.Windows.Forms.Padding(1)
        Me.lbllblWhen_Amt_LT.Name = "lbllblWhen_Amt_LT"
        Me.lbllblWhen_Amt_LT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbllblWhen_Amt_LT.Size = New System.Drawing.Size(116, 25)
        Me.lbllblWhen_Amt_LT.TabIndex = 1
        Me.lbllblWhen_Amt_LT.Text = "Push Order ID"
        '
        'lblWhen_Amt_GT
        '
        Me.lblWhen_Amt_GT.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhen_Amt_GT.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhen_Amt_GT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhen_Amt_GT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhen_Amt_GT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhen_Amt_GT.Location = New System.Drawing.Point(5, 130)
        Me.lblWhen_Amt_GT.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhen_Amt_GT.Name = "lblWhen_Amt_GT"
        Me.lblWhen_Amt_GT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhen_Amt_GT.Size = New System.Drawing.Size(123, 20)
        Me.lblWhen_Amt_GT.TabIndex = 11
        Me.lblWhen_Amt_GT.Text = "Comment"
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(5, 61)
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
        Me.tsProgramMenu.Size = New System.Drawing.Size(522, 25)
        Me.tsProgramMenu.TabIndex = 0
        Me.tsProgramMenu.Text = "ToolStrip1"
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
        'lblPush_Date
        '
        Me.lblPush_Date.BackColor = System.Drawing.SystemColors.Control
        Me.lblPush_Date.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPush_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPush_Date.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPush_Date.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPush_Date.Location = New System.Drawing.Point(5, 107)
        Me.lblPush_Date.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPush_Date.Name = "lblPush_Date"
        Me.lblPush_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPush_Date.Size = New System.Drawing.Size(119, 21)
        Me.lblPush_Date.TabIndex = 7
        Me.lblPush_Date.Text = "Pushed Date"
        '
        'cmdStart_Dt
        '
        Me.cmdStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart_Dt.Image = CType(resources.GetObject("cmdStart_Dt.Image"), System.Drawing.Image)
        Me.cmdStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStart_Dt.Location = New System.Drawing.Point(297, 104)
        Me.cmdStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdStart_Dt.Name = "cmdStart_Dt"
        Me.cmdStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart_Dt.Size = New System.Drawing.Size(21, 22)
        Me.cmdStart_Dt.TabIndex = 9
        Me.cmdStart_Dt.TabStop = False
        Me.cmdStart_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStart_Dt.UseVisualStyleBackColor = False
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(327, 33)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(8)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 10
        Me.mcCalendar.Visible = False
        '
        'txtStart_Dt
        '
        Me.txtStart_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtStart_Dt.DataLength = CType(0, Long)
        Me.txtStart_Dt.DataType = CustomerFile.CDataType.dtString
        Me.txtStart_Dt.DateValue = New Date(CType(0, Long))
        Me.txtStart_Dt.DecimalDigits = CType(0, Long)
        Me.txtStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStart_Dt.Location = New System.Drawing.Point(130, 104)
        Me.txtStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStart_Dt.Mask = Nothing
        Me.txtStart_Dt.Name = "txtStart_Dt"
        Me.txtStart_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStart_Dt.OldValue = Nothing
        Me.txtStart_Dt.Size = New System.Drawing.Size(167, 21)
        Me.txtStart_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStart_Dt.StringValue = Nothing
        Me.txtStart_Dt.TabIndex = 8
        Me.txtStart_Dt.TextDataID = Nothing
        '
        'txtOrd_No
        '
        Me.txtOrd_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtOrd_No.DataLength = CType(0, Long)
        Me.txtOrd_No.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_No.DateValue = New Date(CType(0, Long))
        Me.txtOrd_No.DecimalDigits = CType(0, Long)
        Me.txtOrd_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrd_No.Location = New System.Drawing.Point(130, 81)
        Me.txtOrd_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOrd_No.Mask = Nothing
        Me.txtOrd_No.Name = "txtOrd_No"
        Me.txtOrd_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_No.OldValue = Nothing
        Me.txtOrd_No.Size = New System.Drawing.Size(188, 21)
        Me.txtOrd_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtOrd_No.StringValue = Nothing
        Me.txtOrd_No.TabIndex = 6
        Me.txtOrd_No.TextDataID = Nothing
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
        Me.txtUpdate_TS.Location = New System.Drawing.Point(130, 303)
        Me.txtUpdate_TS.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUpdate_TS.Mask = Nothing
        Me.txtUpdate_TS.Name = "txtUpdate_TS"
        Me.txtUpdate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUpdate_TS.OldValue = Nothing
        Me.txtUpdate_TS.Size = New System.Drawing.Size(188, 21)
        Me.txtUpdate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUpdate_TS.StringValue = Nothing
        Me.txtUpdate_TS.TabIndex = 16
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
        Me.txtUser_Login.Location = New System.Drawing.Point(130, 280)
        Me.txtUser_Login.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUser_Login.Mask = Nothing
        Me.txtUser_Login.Name = "txtUser_Login"
        Me.txtUser_Login.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUser_Login.OldValue = Nothing
        Me.txtUser_Login.Size = New System.Drawing.Size(188, 21)
        Me.txtUser_Login.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUser_Login.StringValue = Nothing
        Me.txtUser_Login.TabIndex = 14
        Me.txtUser_Login.TextDataID = Nothing
        '
        'txtCus_Push_Order_ID
        '
        Me.txtCus_Push_Order_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Push_Order_ID.DataLength = CType(0, Long)
        Me.txtCus_Push_Order_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Push_Order_ID.DateValue = New Date(CType(0, Long))
        Me.txtCus_Push_Order_ID.DecimalDigits = CType(0, Long)
        Me.txtCus_Push_Order_ID.Enabled = False
        Me.txtCus_Push_Order_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Push_Order_ID.Location = New System.Drawing.Point(130, 35)
        Me.txtCus_Push_Order_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Push_Order_ID.Mask = Nothing
        Me.txtCus_Push_Order_ID.Name = "txtCus_Push_Order_ID"
        Me.txtCus_Push_Order_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Push_Order_ID.OldValue = Nothing
        Me.txtCus_Push_Order_ID.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_Push_Order_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Push_Order_ID.StringValue = Nothing
        Me.txtCus_Push_Order_ID.TabIndex = 2
        Me.txtCus_Push_Order_ID.TextDataID = Nothing
        '
        'txtOrd_Comment
        '
        Me.txtOrd_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrd_Comment.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtOrd_Comment.DataLength = CType(0, Long)
        Me.txtOrd_Comment.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_Comment.DateValue = New Date(CType(0, Long))
        Me.txtOrd_Comment.DecimalDigits = CType(0, Long)
        Me.txtOrd_Comment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrd_Comment.Location = New System.Drawing.Point(130, 127)
        Me.txtOrd_Comment.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOrd_Comment.Mask = Nothing
        Me.txtOrd_Comment.Multiline = True
        Me.txtOrd_Comment.Name = "txtOrd_Comment"
        Me.txtOrd_Comment.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_Comment.OldValue = Nothing
        Me.txtOrd_Comment.Size = New System.Drawing.Size(382, 151)
        Me.txtOrd_Comment.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtOrd_Comment.StringValue = Nothing
        Me.txtOrd_Comment.TabIndex = 12
        Me.txtOrd_Comment.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_No.Location = New System.Drawing.Point(130, 58)
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
        'txtCus_Comment_ID
        '
        Me.txtCus_Comment_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Comment_ID.DataLength = CType(0, Long)
        Me.txtCus_Comment_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Comment_ID.DateValue = New Date(CType(0, Long))
        Me.txtCus_Comment_ID.DecimalDigits = CType(0, Long)
        Me.txtCus_Comment_ID.Enabled = False
        Me.txtCus_Comment_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Comment_ID.Location = New System.Drawing.Point(130, 35)
        Me.txtCus_Comment_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Comment_ID.Mask = Nothing
        Me.txtCus_Comment_ID.Name = "txtCus_Comment_ID"
        Me.txtCus_Comment_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Comment_ID.OldValue = Nothing
        Me.txtCus_Comment_ID.Size = New System.Drawing.Size(188, 21)
        Me.txtCus_Comment_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Comment_ID.StringValue = Nothing
        Me.txtCus_Comment_ID.TabIndex = 54
        Me.txtCus_Comment_ID.TextDataID = Nothing
        '
        'frmPushOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 336)
        Me.Controls.Add(Me.mcCalendar)
        Me.Controls.Add(Me.cmdStart_Dt)
        Me.Controls.Add(Me.txtStart_Dt)
        Me.Controls.Add(Me.lblPush_Date)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.txtOrd_No)
        Me.Controls.Add(Me.lblWhen_Qty_Gt)
        Me.Controls.Add(Me.txtUpdate_TS)
        Me.Controls.Add(Me.lblUpdate_TS)
        Me.Controls.Add(Me.txtUser_Login)
        Me.Controls.Add(Me.lblUser_Login)
        Me.Controls.Add(Me.txtCus_Push_Order_ID)
        Me.Controls.Add(Me.lbllblWhen_Amt_LT)
        Me.Controls.Add(Me.txtOrd_Comment)
        Me.Controls.Add(Me.lblWhen_Amt_GT)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.lblCus_No)
        Me.MinimumSize = New System.Drawing.Size(530, 370)
        Me.Name = "frmPushOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-PSH-ORD-001"
        Me.Text = "Push Order"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOrd_No As CustomerFile.xTextBox
    Friend WithEvents lblWhen_Qty_Gt As System.Windows.Forms.Label
    Friend WithEvents txtUpdate_TS As CustomerFile.xTextBox
    Friend WithEvents lblUpdate_TS As System.Windows.Forms.Label
    Friend WithEvents txtUser_Login As CustomerFile.xTextBox
    Friend WithEvents lblUser_Login As System.Windows.Forms.Label
    Friend WithEvents txtCus_Push_Order_ID As CustomerFile.xTextBox
    Friend WithEvents lbllblWhen_Amt_LT As System.Windows.Forms.Label
    Friend WithEvents txtOrd_Comment As CustomerFile.xTextBox
    Friend WithEvents lblWhen_Amt_GT As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCus_Comment_ID As CustomerFile.xTextBox
    Friend WithEvents txtStart_Dt As CustomerFile.xTextBox
    Friend WithEvents lblPush_Date As System.Windows.Forms.Label
    Friend WithEvents cmdStart_Dt As System.Windows.Forms.Button
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
End Class
