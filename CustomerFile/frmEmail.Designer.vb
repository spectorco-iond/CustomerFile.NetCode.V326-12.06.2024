<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
        Me.cmdReply = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblOrd_No = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.lblFollowUp = New System.Windows.Forms.Label()
        Me.txtFollowUp = New CustomerFile.xTextBox()
        Me.txtEmailTo = New CustomerFile.xTextBox()
        Me.txtEmailID = New CustomerFile.xTextBox()
        Me.txtCreate_TS = New CustomerFile.xTextBox()
        Me.txtMessage = New CustomerFile.xTextBox()
        Me.txtSubjectLine = New CustomerFile.xTextBox()
        Me.txtUserTo = New CustomerFile.xTextBox()
        Me.txtEmailFrom = New CustomerFile.xTextBox()
        Me.txtOrd_No = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.SuspendLayout()
        '
        'cmdReply
        '
        Me.cmdReply.Location = New System.Drawing.Point(326, 39)
        Me.cmdReply.Name = "cmdReply"
        Me.cmdReply.Size = New System.Drawing.Size(75, 23)
        Me.cmdReply.TabIndex = 37
        Me.cmdReply.Text = "Reply"
        Me.cmdReply.UseVisualStyleBackColor = True
        Me.cmdReply.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(407, 382)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 34
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Message"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Subject"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Email To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Email From"
        '
        'lblOrd_No
        '
        Me.lblOrd_No.AutoSize = True
        Me.lblOrd_No.Location = New System.Drawing.Point(11, 42)
        Me.lblOrd_No.Name = "lblOrd_No"
        Me.lblOrd_No.Size = New System.Drawing.Size(57, 15)
        Me.lblOrd_No.TabIndex = 21
        Me.lblOrd_No.Text = "Order No"
        '
        'lblCus_No
        '
        Me.lblCus_No.AutoSize = True
        Me.lblCus_No.Location = New System.Drawing.Point(11, 15)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.Size = New System.Drawing.Size(81, 15)
        Me.lblCus_No.TabIndex = 19
        Me.lblCus_No.Text = "Customer No"
        '
        'lblFollowUp
        '
        Me.lblFollowUp.AutoSize = True
        Me.lblFollowUp.Location = New System.Drawing.Point(322, 69)
        Me.lblFollowUp.Name = "lblFollowUp"
        Me.lblFollowUp.Size = New System.Drawing.Size(62, 15)
        Me.lblFollowUp.TabIndex = 39
        Me.lblFollowUp.Text = "Follow Up"
        '
        'txtFollowUp
        '
        Me.txtFollowUp.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtFollowUp.DataLength = CType(0, Long)
        Me.txtFollowUp.DataType = CustomerFile.CDataType.dtString
        Me.txtFollowUp.DateValue = New Date(CType(0, Long))
        Me.txtFollowUp.DecimalDigits = CType(0, Long)
        Me.txtFollowUp.Location = New System.Drawing.Point(390, 66)
        Me.txtFollowUp.Mask = Nothing
        Me.txtFollowUp.Name = "txtFollowUp"
        Me.txtFollowUp.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtFollowUp.OldValue = ""
        Me.txtFollowUp.Size = New System.Drawing.Size(32, 21)
        Me.txtFollowUp.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtFollowUp.StringValue = Nothing
        Me.txtFollowUp.TabIndex = 40
        Me.txtFollowUp.TextDataID = Nothing
        '
        'txtEmailTo
        '
        Me.txtEmailTo.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmailTo.DataLength = CType(0, Long)
        Me.txtEmailTo.DataType = CustomerFile.CDataType.dtString
        Me.txtEmailTo.DateValue = New Date(CType(0, Long))
        Me.txtEmailTo.DecimalDigits = CType(0, Long)
        Me.txtEmailTo.Location = New System.Drawing.Point(123, 93)
        Me.txtEmailTo.Mask = Nothing
        Me.txtEmailTo.Name = "txtEmailTo"
        Me.txtEmailTo.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmailTo.OldValue = ""
        Me.txtEmailTo.Size = New System.Drawing.Size(196, 21)
        Me.txtEmailTo.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmailTo.StringValue = Nothing
        Me.txtEmailTo.TabIndex = 38
        Me.txtEmailTo.TextDataID = Nothing
        '
        'txtEmailID
        '
        Me.txtEmailID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmailID.DataLength = CType(0, Long)
        Me.txtEmailID.DataType = CustomerFile.CDataType.dtString
        Me.txtEmailID.DateValue = New Date(CType(0, Long))
        Me.txtEmailID.DecimalDigits = CType(0, Long)
        Me.txtEmailID.Enabled = False
        Me.txtEmailID.Location = New System.Drawing.Point(325, 12)
        Me.txtEmailID.Mask = Nothing
        Me.txtEmailID.Name = "txtEmailID"
        Me.txtEmailID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmailID.OldValue = ""
        Me.txtEmailID.Size = New System.Drawing.Size(157, 21)
        Me.txtEmailID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmailID.StringValue = Nothing
        Me.txtEmailID.TabIndex = 36
        Me.txtEmailID.TextDataID = Nothing
        Me.txtEmailID.Visible = False
        '
        'txtCreate_TS
        '
        Me.txtCreate_TS.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCreate_TS.DataLength = CType(0, Long)
        Me.txtCreate_TS.DataType = CustomerFile.CDataType.dtString
        Me.txtCreate_TS.DateValue = New Date(CType(0, Long))
        Me.txtCreate_TS.DecimalDigits = CType(0, Long)
        Me.txtCreate_TS.Enabled = False
        Me.txtCreate_TS.Location = New System.Drawing.Point(123, 382)
        Me.txtCreate_TS.Mask = Nothing
        Me.txtCreate_TS.Name = "txtCreate_TS"
        Me.txtCreate_TS.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCreate_TS.OldValue = ""
        Me.txtCreate_TS.Size = New System.Drawing.Size(196, 21)
        Me.txtCreate_TS.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCreate_TS.StringValue = Nothing
        Me.txtCreate_TS.TabIndex = 32
        Me.txtCreate_TS.TextDataID = Nothing
        '
        'txtMessage
        '
        Me.txtMessage.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtMessage.DataLength = CType(0, Long)
        Me.txtMessage.DataType = CustomerFile.CDataType.dtString
        Me.txtMessage.DateValue = New Date(CType(0, Long))
        Me.txtMessage.DecimalDigits = CType(0, Long)
        Me.txtMessage.Location = New System.Drawing.Point(14, 169)
        Me.txtMessage.Mask = Nothing
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMessage.OldValue = ""
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(468, 206)
        Me.txtMessage.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtMessage.StringValue = Nothing
        Me.txtMessage.TabIndex = 30
        Me.txtMessage.TextDataID = Nothing
        '
        'txtSubjectLine
        '
        Me.txtSubjectLine.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSubjectLine.DataLength = CType(0, Long)
        Me.txtSubjectLine.DataType = CustomerFile.CDataType.dtString
        Me.txtSubjectLine.DateValue = New Date(CType(0, Long))
        Me.txtSubjectLine.DecimalDigits = CType(0, Long)
        Me.txtSubjectLine.Location = New System.Drawing.Point(123, 120)
        Me.txtSubjectLine.Mask = Nothing
        Me.txtSubjectLine.Name = "txtSubjectLine"
        Me.txtSubjectLine.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSubjectLine.OldValue = ""
        Me.txtSubjectLine.Size = New System.Drawing.Size(359, 21)
        Me.txtSubjectLine.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSubjectLine.StringValue = Nothing
        Me.txtSubjectLine.TabIndex = 28
        Me.txtSubjectLine.TextDataID = Nothing
        '
        'txtUserTo
        '
        Me.txtUserTo.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtUserTo.DataLength = CType(0, Long)
        Me.txtUserTo.DataType = CustomerFile.CDataType.dtString
        Me.txtUserTo.DateValue = New Date(CType(0, Long))
        Me.txtUserTo.DecimalDigits = CType(0, Long)
        Me.txtUserTo.Location = New System.Drawing.Point(325, 93)
        Me.txtUserTo.Mask = Nothing
        Me.txtUserTo.Name = "txtUserTo"
        Me.txtUserTo.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUserTo.OldValue = ""
        Me.txtUserTo.Size = New System.Drawing.Size(157, 21)
        Me.txtUserTo.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtUserTo.StringValue = Nothing
        Me.txtUserTo.TabIndex = 26
        Me.txtUserTo.TextDataID = Nothing
        '
        'txtEmailFrom
        '
        Me.txtEmailFrom.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEmailFrom.DataLength = CType(0, Long)
        Me.txtEmailFrom.DataType = CustomerFile.CDataType.dtString
        Me.txtEmailFrom.DateValue = New Date(CType(0, Long))
        Me.txtEmailFrom.DecimalDigits = CType(0, Long)
        Me.txtEmailFrom.Location = New System.Drawing.Point(123, 66)
        Me.txtEmailFrom.Mask = Nothing
        Me.txtEmailFrom.Name = "txtEmailFrom"
        Me.txtEmailFrom.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmailFrom.OldValue = ""
        Me.txtEmailFrom.Size = New System.Drawing.Size(196, 21)
        Me.txtEmailFrom.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEmailFrom.StringValue = Nothing
        Me.txtEmailFrom.TabIndex = 24
        Me.txtEmailFrom.TextDataID = Nothing
        '
        'txtOrd_No
        '
        Me.txtOrd_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtOrd_No.DataLength = CType(0, Long)
        Me.txtOrd_No.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_No.DateValue = New Date(CType(0, Long))
        Me.txtOrd_No.DecimalDigits = CType(0, Long)
        Me.txtOrd_No.Location = New System.Drawing.Point(123, 39)
        Me.txtOrd_No.Mask = Nothing
        Me.txtOrd_No.Name = "txtOrd_No"
        Me.txtOrd_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_No.OldValue = ""
        Me.txtOrd_No.Size = New System.Drawing.Size(196, 21)
        Me.txtOrd_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtOrd_No.StringValue = Nothing
        Me.txtOrd_No.TabIndex = 22
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
        Me.txtCus_No.Location = New System.Drawing.Point(123, 12)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = ""
        Me.txtCus_No.Size = New System.Drawing.Size(196, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 20
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmEmail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(492, 416)
        Me.Controls.Add(Me.txtFollowUp)
        Me.Controls.Add(Me.lblFollowUp)
        Me.Controls.Add(Me.txtEmailTo)
        Me.Controls.Add(Me.cmdReply)
        Me.Controls.Add(Me.txtEmailID)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCreate_TS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSubjectLine)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUserTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmailFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOrd_No)
        Me.Controls.Add(Me.lblOrd_No)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.lblCus_No)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-EMA-001"
        Me.Text = "frmEmail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdReply As System.Windows.Forms.Button
    Friend WithEvents txtEmailID As CustomerFile.xTextBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtCreate_TS As CustomerFile.xTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As CustomerFile.xTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSubjectLine As CustomerFile.xTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUserTo As CustomerFile.xTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailFrom As CustomerFile.xTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrd_No As CustomerFile.xTextBox
    Friend WithEvents lblOrd_No As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents txtEmailTo As CustomerFile.xTextBox
    Friend WithEvents txtFollowUp As CustomerFile.xTextBox
    Friend WithEvents lblFollowUp As System.Windows.Forms.Label
End Class
