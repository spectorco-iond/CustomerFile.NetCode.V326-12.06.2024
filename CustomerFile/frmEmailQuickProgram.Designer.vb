<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailQuickProgram
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmailQuickProgram))
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.lblAttachments = New System.Windows.Forms.Label()
        Me.cmdAtach = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dgvFileName = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCC = New System.Windows.Forms.Button()
        Me.txtCC = New CustomerFile.xTextBox()
        Me.txtCusName = New CustomerFile.xTextBox()
        Me.txtEmailTo = New CustomerFile.xTextBox()
        Me.txtCreate_TS = New CustomerFile.xTextBox()
        Me.txtMessage = New CustomerFile.xTextBox()
        Me.txtSubjectLine = New CustomerFile.xTextBox()
        Me.txtEmailFrom = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        CType(Me.dgvFileName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSend
        '
        Me.cmdSend.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSend.Location = New System.Drawing.Point(409, 482)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(75, 23)
        Me.cmdSend.TabIndex = 55
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 485)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Message"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Subject"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Email To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Email From"
        '
        'lblCus_No
        '
        Me.lblCus_No.AutoSize = True
        Me.lblCus_No.Location = New System.Drawing.Point(12, 15)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.Size = New System.Drawing.Size(68, 13)
        Me.lblCus_No.TabIndex = 41
        Me.lblCus_No.Text = "Customer No"
        '
        'lblAttachments
        '
        Me.lblAttachments.AutoSize = True
        Me.lblAttachments.Location = New System.Drawing.Point(14, 192)
        Me.lblAttachments.Name = "lblAttachments"
        Me.lblAttachments.Size = New System.Drawing.Size(66, 13)
        Me.lblAttachments.TabIndex = 61
        Me.lblAttachments.Text = "Attachments"
        Me.lblAttachments.Visible = False
        '
        'cmdAtach
        '
        Me.cmdAtach.Location = New System.Drawing.Point(15, 156)
        Me.cmdAtach.Name = "cmdAtach"
        Me.cmdAtach.Size = New System.Drawing.Size(75, 23)
        Me.cmdAtach.TabIndex = 64
        Me.cmdAtach.Text = "Attach File"
        Me.cmdAtach.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'dgvFileName
        '
        Me.dgvFileName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFileName.Location = New System.Drawing.Point(101, 156)
        Me.dgvFileName.Name = "dgvFileName"
        Me.dgvFileName.Size = New System.Drawing.Size(383, 107)
        Me.dgvFileName.TabIndex = 65
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'cmdCC
        '
        Me.cmdCC.Location = New System.Drawing.Point(12, 92)
        Me.cmdCC.Name = "cmdCC"
        Me.cmdCC.Size = New System.Drawing.Size(75, 20)
        Me.cmdCC.TabIndex = 68
        Me.cmdCC.Text = "CC..."
        Me.cmdCC.UseVisualStyleBackColor = True
        '
        'txtCC
        '
        Me.txtCC.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCC.DataLength = CType(0, Long)
        Me.txtCC.DataType = CustomerFile.CDataType.dtString
        Me.txtCC.DateValue = New Date(CType(0, Long))
        Me.txtCC.DecimalDigits = CType(0, Long)
        Me.txtCC.Location = New System.Drawing.Point(124, 92)
        Me.txtCC.Mask = Nothing
        Me.txtCC.Multiline = True
        Me.txtCC.Name = "txtCC"
        Me.txtCC.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCC.OldValue = ""
        Me.txtCC.Size = New System.Drawing.Size(359, 30)
        Me.txtCC.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCC.StringValue = Nothing
        Me.txtCC.TabIndex = 67
        Me.txtCC.TextDataID = Nothing
        '
        'txtCusName
        '
        Me.txtCusName.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCusName.DataLength = CType(0, Long)
        Me.txtCusName.DataType = CustomerFile.CDataType.dtString
        Me.txtCusName.DateValue = New Date(CType(0, Long))
        Me.txtCusName.DecimalDigits = CType(0, Long)
        Me.txtCusName.Enabled = False
        Me.txtCusName.Location = New System.Drawing.Point(215, 12)
        Me.txtCusName.Mask = Nothing
        Me.txtCusName.Name = "txtCusName"
        Me.txtCusName.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCusName.OldValue = ""
        Me.txtCusName.Size = New System.Drawing.Size(268, 20)
        Me.txtCusName.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCusName.StringValue = Nothing
        Me.txtCusName.TabIndex = 63
        Me.txtCusName.TextDataID = Nothing
        '
        'txtEmailTo
        '
        Me.txtEmailTo.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmailTo.DataLength = CType(0, Long)
        Me.txtEmailTo.DataType = CustomerFile.CDataType.dtString
        Me.txtEmailTo.DateValue = New Date(CType(0, Long))
        Me.txtEmailTo.DecimalDigits = CType(0, Long)
        Me.txtEmailTo.Location = New System.Drawing.Point(124, 66)
        Me.txtEmailTo.Mask = Nothing
        Me.txtEmailTo.Name = "txtEmailTo"
        Me.txtEmailTo.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmailTo.OldValue = ""
        Me.txtEmailTo.Size = New System.Drawing.Size(359, 20)
        Me.txtEmailTo.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmailTo.StringValue = Nothing
        Me.txtEmailTo.TabIndex = 58
        Me.txtEmailTo.TextDataID = Nothing
        '
        'txtCreate_TS
        '
        Me.txtCreate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCreate_TS.DataLength = CType(0, Long)
        Me.txtCreate_TS.DataType = CustomerFile.CDataType.dtString
        Me.txtCreate_TS.DateValue = New Date(CType(0, Long))
        Me.txtCreate_TS.DecimalDigits = CType(0, Long)
        Me.txtCreate_TS.Enabled = False
        Me.txtCreate_TS.Location = New System.Drawing.Point(125, 482)
        Me.txtCreate_TS.Mask = Nothing
        Me.txtCreate_TS.Name = "txtCreate_TS"
        Me.txtCreate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCreate_TS.OldValue = ""
        Me.txtCreate_TS.Size = New System.Drawing.Size(196, 20)
        Me.txtCreate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCreate_TS.StringValue = Nothing
        Me.txtCreate_TS.TabIndex = 54
        Me.txtCreate_TS.TextDataID = Nothing
        '
        'txtMessage
        '
        Me.txtMessage.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtMessage.DataLength = CType(0, Long)
        Me.txtMessage.DataType = CustomerFile.CDataType.dtString
        Me.txtMessage.DateValue = New Date(CType(0, Long))
        Me.txtMessage.DecimalDigits = CType(0, Long)
        Me.txtMessage.Location = New System.Drawing.Point(16, 269)
        Me.txtMessage.Mask = Nothing
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMessage.OldValue = ""
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(468, 206)
        Me.txtMessage.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtMessage.StringValue = Nothing
        Me.txtMessage.TabIndex = 52
        Me.txtMessage.TextDataID = Nothing
        '
        'txtSubjectLine
        '
        Me.txtSubjectLine.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSubjectLine.DataLength = CType(0, Long)
        Me.txtSubjectLine.DataType = CustomerFile.CDataType.dtString
        Me.txtSubjectLine.DateValue = New Date(CType(0, Long))
        Me.txtSubjectLine.DecimalDigits = CType(0, Long)
        Me.txtSubjectLine.Location = New System.Drawing.Point(124, 128)
        Me.txtSubjectLine.Mask = Nothing
        Me.txtSubjectLine.Name = "txtSubjectLine"
        Me.txtSubjectLine.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSubjectLine.OldValue = ""
        Me.txtSubjectLine.Size = New System.Drawing.Size(359, 20)
        Me.txtSubjectLine.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSubjectLine.StringValue = Nothing
        Me.txtSubjectLine.TabIndex = 50
        Me.txtSubjectLine.TextDataID = Nothing
        '
        'txtEmailFrom
        '
        Me.txtEmailFrom.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmailFrom.DataLength = CType(0, Long)
        Me.txtEmailFrom.DataType = CustomerFile.CDataType.dtString
        Me.txtEmailFrom.DateValue = New Date(CType(0, Long))
        Me.txtEmailFrom.DecimalDigits = CType(0, Long)
        Me.txtEmailFrom.Location = New System.Drawing.Point(124, 39)
        Me.txtEmailFrom.Mask = Nothing
        Me.txtEmailFrom.Name = "txtEmailFrom"
        Me.txtEmailFrom.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmailFrom.OldValue = ""
        Me.txtEmailFrom.Size = New System.Drawing.Size(359, 20)
        Me.txtEmailFrom.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmailFrom.StringValue = Nothing
        Me.txtEmailFrom.TabIndex = 46
        Me.txtEmailFrom.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Enabled = False
        Me.txtCus_No.Location = New System.Drawing.Point(124, 12)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = ""
        Me.txtCus_No.Size = New System.Drawing.Size(85, 20)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 42
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmEmailQuickProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(496, 511)
        Me.Controls.Add(Me.cmdCC)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.dgvFileName)
        Me.Controls.Add(Me.cmdAtach)
        Me.Controls.Add(Me.txtCusName)
        Me.Controls.Add(Me.lblAttachments)
        Me.Controls.Add(Me.txtEmailTo)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.txtCreate_TS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSubjectLine)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmailFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.lblCus_No)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmailQuickProgram"
        Me.Text = "Email Program Maintenance"
        CType(Me.dgvFileName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEmailTo As CustomerFile.xTextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents txtCreate_TS As CustomerFile.xTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As CustomerFile.xTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailFrom As CustomerFile.xTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents lblAttachments As System.Windows.Forms.Label
    Friend WithEvents txtCusName As CustomerFile.xTextBox
    Friend WithEvents cmdAtach As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvFileName As System.Windows.Forms.DataGridView
    Friend WithEvents txtSubjectLine As CustomerFile.xTextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCC As CustomerFile.xTextBox
    Friend WithEvents cmdCC As System.Windows.Forms.Button
End Class
