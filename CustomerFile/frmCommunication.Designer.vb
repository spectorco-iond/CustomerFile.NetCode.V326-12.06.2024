<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommunication
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommunication))
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCCAsEmailTo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboContact = New System.Windows.Forms.ComboBox()
        Me.cmdReply = New System.Windows.Forms.Button()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCCAsEmailTo = New CustomerFile.xTextBox()
        Me.txtID = New CustomerFile.xTextBox()
        Me.txtCreate_TS = New CustomerFile.xTextBox()
        Me.txtMessage = New CustomerFile.xTextBox()
        Me.txtSubject = New CustomerFile.xTextBox()
        Me.txtContact = New CustomerFile.xTextBox()
        Me.txtSalesperson = New CustomerFile.xTextBox()
        Me.txtOrd_No = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.chkNegativeFeed = New System.Windows.Forms.CheckBox()
        Me.tsProgramMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCus_No
        '
        Me.lblCus_No.AutoSize = True
        Me.lblCus_No.Location = New System.Drawing.Point(9, 38)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.Size = New System.Drawing.Size(81, 15)
        Me.lblCus_No.TabIndex = 0
        Me.lblCus_No.Text = "Customer No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Order No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "CSR Contact"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Customer Contact"
        '
        'lblCCAsEmailTo
        '
        Me.lblCCAsEmailTo.AutoSize = True
        Me.lblCCAsEmailTo.Location = New System.Drawing.Point(9, 132)
        Me.lblCCAsEmailTo.Name = "lblCCAsEmailTo"
        Me.lblCCAsEmailTo.Size = New System.Drawing.Size(92, 15)
        Me.lblCCAsEmailTo.TabIndex = 8
        Me.lblCCAsEmailTo.Text = "CC As Email To"
        Me.lblCCAsEmailTo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Message"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 436)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Date"
        '
        'cboContact
        '
        Me.cboContact.FormattingEnabled = True
        Me.cboContact.Location = New System.Drawing.Point(121, 104)
        Me.cboContact.Margin = New System.Windows.Forms.Padding(1)
        Me.cboContact.Name = "cboContact"
        Me.cboContact.Size = New System.Drawing.Size(196, 23)
        Me.cboContact.TabIndex = 16
        '
        'cmdReply
        '
        Me.cmdReply.Location = New System.Drawing.Point(323, 58)
        Me.cmdReply.Name = "cmdReply"
        Me.cmdReply.Size = New System.Drawing.Size(75, 23)
        Me.cmdReply.TabIndex = 18
        Me.cmdReply.Text = "Reply"
        Me.cmdReply.UseVisualStyleBackColor = True
        Me.cmdReply.Visible = False
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(592, 25)
        Me.tsProgramMenu.TabIndex = 19
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Subject"
        '
        'txtCCAsEmailTo
        '
        Me.txtCCAsEmailTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCCAsEmailTo.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCCAsEmailTo.DataLength = CType(0, Long)
        Me.txtCCAsEmailTo.DataType = CustomerFile.CDataType.dtString
        Me.txtCCAsEmailTo.DateValue = New Date(CType(0, Long))
        Me.txtCCAsEmailTo.DecimalDigits = CType(0, Long)
        Me.txtCCAsEmailTo.ForeColor = System.Drawing.Color.Black
        Me.txtCCAsEmailTo.Location = New System.Drawing.Point(121, 129)
        Me.txtCCAsEmailTo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCCAsEmailTo.Mask = Nothing
        Me.txtCCAsEmailTo.Name = "txtCCAsEmailTo"
        Me.txtCCAsEmailTo.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCCAsEmailTo.OldValue = ""
        Me.txtCCAsEmailTo.Size = New System.Drawing.Size(459, 21)
        Me.txtCCAsEmailTo.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCCAsEmailTo.StringValue = Nothing
        Me.txtCCAsEmailTo.TabIndex = 21
        Me.txtCCAsEmailTo.TextDataID = Nothing
        Me.txtCCAsEmailTo.Visible = False
        '
        'txtID
        '
        Me.txtID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtID.DataLength = CType(0, Long)
        Me.txtID.DataType = CustomerFile.CDataType.dtString
        Me.txtID.DateValue = New Date(CType(0, Long))
        Me.txtID.DecimalDigits = CType(0, Long)
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(323, 35)
        Me.txtID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtID.Mask = Nothing
        Me.txtID.Name = "txtID"
        Me.txtID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtID.OldValue = ""
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(157, 21)
        Me.txtID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtID.StringValue = Nothing
        Me.txtID.TabIndex = 17
        Me.txtID.TextDataID = Nothing
        Me.txtID.Visible = False
        '
        'txtCreate_TS
        '
        Me.txtCreate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCreate_TS.DataLength = CType(0, Long)
        Me.txtCreate_TS.DataType = CustomerFile.CDataType.dtString
        Me.txtCreate_TS.DateValue = New Date(CType(0, Long))
        Me.txtCreate_TS.DecimalDigits = CType(0, Long)
        Me.txtCreate_TS.Enabled = False
        Me.txtCreate_TS.ForeColor = System.Drawing.Color.Black
        Me.txtCreate_TS.Location = New System.Drawing.Point(121, 433)
        Me.txtCreate_TS.Mask = Nothing
        Me.txtCreate_TS.Name = "txtCreate_TS"
        Me.txtCreate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCreate_TS.OldValue = ""
        Me.txtCreate_TS.Size = New System.Drawing.Size(196, 21)
        Me.txtCreate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCreate_TS.StringValue = Nothing
        Me.txtCreate_TS.TabIndex = 13
        Me.txtCreate_TS.TextDataID = Nothing
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtMessage.DataLength = CType(0, Long)
        Me.txtMessage.DataType = CustomerFile.CDataType.dtString
        Me.txtMessage.DateValue = New Date(CType(0, Long))
        Me.txtMessage.DecimalDigits = CType(0, Long)
        Me.txtMessage.ForeColor = System.Drawing.Color.Black
        Me.txtMessage.Location = New System.Drawing.Point(12, 199)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(1)
        Me.txtMessage.Mask = Nothing
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMessage.OldValue = ""
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(568, 230)
        Me.txtMessage.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtMessage.StringValue = Nothing
        Me.txtMessage.TabIndex = 11
        Me.txtMessage.TextDataID = Nothing
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSubject.DataLength = CType(0, Long)
        Me.txtSubject.DataType = CustomerFile.CDataType.dtString
        Me.txtSubject.DateValue = New Date(CType(0, Long))
        Me.txtSubject.DecimalDigits = CType(0, Long)
        Me.txtSubject.ForeColor = System.Drawing.Color.Black
        Me.txtSubject.Location = New System.Drawing.Point(121, 152)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSubject.Mask = Nothing
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSubject.OldValue = ""
        Me.txtSubject.Size = New System.Drawing.Size(459, 21)
        Me.txtSubject.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSubject.StringValue = Nothing
        Me.txtSubject.TabIndex = 9
        Me.txtSubject.TextDataID = Nothing
        '
        'txtContact
        '
        Me.txtContact.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtContact.DataLength = CType(0, Long)
        Me.txtContact.DataType = CustomerFile.CDataType.dtString
        Me.txtContact.DateValue = New Date(CType(0, Long))
        Me.txtContact.DecimalDigits = CType(0, Long)
        Me.txtContact.ForeColor = System.Drawing.Color.Black
        Me.txtContact.Location = New System.Drawing.Point(319, 104)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(1)
        Me.txtContact.Mask = Nothing
        Me.txtContact.Name = "txtContact"
        Me.txtContact.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtContact.OldValue = ""
        Me.txtContact.Size = New System.Drawing.Size(157, 21)
        Me.txtContact.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtContact.StringValue = Nothing
        Me.txtContact.TabIndex = 7
        Me.txtContact.TextDataID = Nothing
        Me.txtContact.Visible = False
        '
        'txtSalesperson
        '
        Me.txtSalesperson.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSalesperson.DataLength = CType(0, Long)
        Me.txtSalesperson.DataType = CustomerFile.CDataType.dtString
        Me.txtSalesperson.DateValue = New Date(CType(0, Long))
        Me.txtSalesperson.DecimalDigits = CType(0, Long)
        Me.txtSalesperson.ForeColor = System.Drawing.Color.Black
        Me.txtSalesperson.Location = New System.Drawing.Point(121, 81)
        Me.txtSalesperson.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSalesperson.Mask = Nothing
        Me.txtSalesperson.Name = "txtSalesperson"
        Me.txtSalesperson.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSalesperson.OldValue = ""
        Me.txtSalesperson.Size = New System.Drawing.Size(196, 21)
        Me.txtSalesperson.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSalesperson.StringValue = Nothing
        Me.txtSalesperson.TabIndex = 5
        Me.txtSalesperson.TextDataID = Nothing
        '
        'txtOrd_No
        '
        Me.txtOrd_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtOrd_No.DataLength = CType(0, Long)
        Me.txtOrd_No.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_No.DateValue = New Date(CType(0, Long))
        Me.txtOrd_No.DecimalDigits = CType(0, Long)
        Me.txtOrd_No.ForeColor = System.Drawing.Color.Black
        Me.txtOrd_No.Location = New System.Drawing.Point(121, 58)
        Me.txtOrd_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOrd_No.Mask = Nothing
        Me.txtOrd_No.Name = "txtOrd_No"
        Me.txtOrd_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_No.OldValue = ""
        Me.txtOrd_No.Size = New System.Drawing.Size(196, 21)
        Me.txtOrd_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtOrd_No.StringValue = Nothing
        Me.txtOrd_No.TabIndex = 3
        Me.txtOrd_No.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Enabled = False
        Me.txtCus_No.ForeColor = System.Drawing.Color.Black
        Me.txtCus_No.Location = New System.Drawing.Point(121, 35)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = ""
        Me.txtCus_No.Size = New System.Drawing.Size(196, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 1
        Me.txtCus_No.TextDataID = Nothing
        '
        'chkNegativeFeed
        '
        Me.chkNegativeFeed.AutoSize = True
        Me.chkNegativeFeed.Location = New System.Drawing.Point(449, 178)
        Me.chkNegativeFeed.Name = "chkNegativeFeed"
        Me.chkNegativeFeed.Size = New System.Drawing.Size(131, 19)
        Me.chkNegativeFeed.TabIndex = 22
        Me.chkNegativeFeed.Text = "Negative Feedback"
        Me.chkNegativeFeed.UseVisualStyleBackColor = True
        '
        'frmCommunication
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(592, 466)
        Me.Controls.Add(Me.chkNegativeFeed)
        Me.Controls.Add(Me.txtCCAsEmailTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.cmdReply)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.cboContact)
        Me.Controls.Add(Me.txtCreate_TS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.lblCCAsEmailTo)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSalesperson)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOrd_No)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.lblCus_No)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "frmCommunication"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-COM-001"
        Me.Text = "Communications"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents txtOrd_No As CustomerFile.xTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSalesperson As CustomerFile.xTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContact As CustomerFile.xTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As CustomerFile.xTextBox
    Friend WithEvents lblCCAsEmailTo As System.Windows.Forms.Label
    Friend WithEvents txtMessage As CustomerFile.xTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCreate_TS As CustomerFile.xTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboContact As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As CustomerFile.xTextBox
    Friend WithEvents cmdReply As System.Windows.Forms.Button
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCCAsEmailTo As CustomerFile.xTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkNegativeFeed As System.Windows.Forms.CheckBox
End Class
