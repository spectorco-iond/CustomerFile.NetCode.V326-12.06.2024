<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutlookAppointment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutlookAppointment))
        Me.cmdStartTime = New System.Windows.Forms.Button()
        Me.cmdEndTime = New System.Windows.Forms.Button()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.txtBody = New System.Windows.Forms.TextBox()
        Me.dtpStartHours = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndHours = New System.Windows.Forms.DateTimePicker()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.txtEndTime = New CustomerFile.xTextBox()
        Me.txtStartTime = New CustomerFile.xTextBox()
        Me.SuspendLayout()
        '
        'cmdStartTime
        '
        Me.cmdStartTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStartTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStartTime.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdStartTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStartTime.Image = CType(resources.GetObject("cmdStartTime.Image"), System.Drawing.Image)
        Me.cmdStartTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStartTime.Location = New System.Drawing.Point(173, 84)
        Me.cmdStartTime.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdStartTime.Name = "cmdStartTime"
        Me.cmdStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStartTime.Size = New System.Drawing.Size(21, 22)
        Me.cmdStartTime.TabIndex = 57
        Me.cmdStartTime.TabStop = False
        Me.cmdStartTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStartTime.UseVisualStyleBackColor = False
        '
        'cmdEndTime
        '
        Me.cmdEndTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEndTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEndTime.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdEndTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEndTime.Image = CType(resources.GetObject("cmdEndTime.Image"), System.Drawing.Image)
        Me.cmdEndTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdEndTime.Location = New System.Drawing.Point(173, 117)
        Me.cmdEndTime.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdEndTime.Name = "cmdEndTime"
        Me.cmdEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEndTime.Size = New System.Drawing.Size(21, 22)
        Me.cmdEndTime.TabIndex = 59
        Me.cmdEndTime.TabStop = False
        Me.cmdEndTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEndTime.UseVisualStyleBackColor = False
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(5, 88)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(54, 13)
        Me.lblStartTime.TabIndex = 60
        Me.lblStartTime.Text = "Start time:"
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Location = New System.Drawing.Point(8, 121)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(51, 13)
        Me.lblEndTime.TabIndex = 61
        Me.lblEndTime.Text = "End time:"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(5, 46)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(51, 13)
        Me.lblLocation.TabIndex = 65
        Me.lblLocation.Text = "Location:"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(5, 14)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(46, 13)
        Me.lblSubject.TabIndex = 64
        Me.lblSubject.Text = "Subject:"
        '
        'txtBody
        '
        Me.txtBody.Location = New System.Drawing.Point(8, 152)
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(635, 173)
        Me.txtBody.TabIndex = 69
        '
        'dtpStartHours
        '
        Me.dtpStartHours.Location = New System.Drawing.Point(198, 85)
        Me.dtpStartHours.Name = "dtpStartHours"
        Me.dtpStartHours.Size = New System.Drawing.Size(103, 20)
        Me.dtpStartHours.TabIndex = 71
        '
        'dtpEndHours
        '
        Me.dtpEndHours.Location = New System.Drawing.Point(198, 119)
        Me.dtpEndHours.Name = "dtpEndHours"
        Me.dtpEndHours.Size = New System.Drawing.Size(103, 20)
        Me.dtpEndHours.TabIndex = 74
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(234, 150)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(8)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 75
        Me.mcCalendar.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(570, 71)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(69, 30)
        Me.cmdSave.TabIndex = 76
        Me.cmdSave.Text = "New"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(570, 109)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(69, 30)
        Me.cmdClose.TabIndex = 77
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(57, 12)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReadOnly = True
        Me.txtSubject.Size = New System.Drawing.Size(582, 20)
        Me.txtSubject.TabIndex = 78
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(57, 43)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(582, 20)
        Me.txtLocation.TabIndex = 79
        '
        'txtError
        '
        Me.txtError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtError.ForeColor = System.Drawing.SystemColors.Window
        Me.txtError.Location = New System.Drawing.Point(318, 86)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.Size = New System.Drawing.Size(224, 48)
        Me.txtError.TabIndex = 80
        Me.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndTime
        '
        Me.txtEndTime.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEndTime.DataLength = CType(0, Long)
        Me.txtEndTime.DataType = CustomerFile.CDataType.dtDate
        Me.txtEndTime.DateValue = New Date(CType(0, Long))
        Me.txtEndTime.DecimalDigits = CType(0, Long)
        Me.txtEndTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndTime.Location = New System.Drawing.Point(75, 118)
        Me.txtEndTime.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEndTime.Mask = Nothing
        Me.txtEndTime.Name = "txtEndTime"
        Me.txtEndTime.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEndTime.OldValue = Nothing
        Me.txtEndTime.Size = New System.Drawing.Size(96, 21)
        Me.txtEndTime.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEndTime.StringValue = Nothing
        Me.txtEndTime.TabIndex = 58
        Me.txtEndTime.TextDataID = Nothing
        '
        'txtStartTime
        '
        Me.txtStartTime.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtStartTime.DataLength = CType(0, Long)
        Me.txtStartTime.DataType = CustomerFile.CDataType.dtDate
        Me.txtStartTime.DateValue = New Date(CType(0, Long))
        Me.txtStartTime.DecimalDigits = CType(0, Long)
        Me.txtStartTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartTime.Location = New System.Drawing.Point(75, 85)
        Me.txtStartTime.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStartTime.Mask = Nothing
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStartTime.OldValue = Nothing
        Me.txtStartTime.Size = New System.Drawing.Size(96, 21)
        Me.txtStartTime.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStartTime.StringValue = Nothing
        Me.txtStartTime.TabIndex = 56
        Me.txtStartTime.TextDataID = Nothing
        '
        'frmOutlookAppointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 337)
        Me.Controls.Add(Me.txtError)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.mcCalendar)
        Me.Controls.Add(Me.dtpEndHours)
        Me.Controls.Add(Me.dtpStartHours)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblEndTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.txtEndTime)
        Me.Controls.Add(Me.cmdEndTime)
        Me.Controls.Add(Me.txtStartTime)
        Me.Controls.Add(Me.cmdStartTime)
        Me.Name = "frmOutlookAppointment"
        Me.Text = "Outlook Appointment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartTime As CustomerFile.xTextBox
    Friend WithEvents cmdStartTime As System.Windows.Forms.Button
    Friend WithEvents txtEndTime As CustomerFile.xTextBox
    Friend WithEvents cmdEndTime As System.Windows.Forms.Button
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents lblEndTime As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents dtpStartHours As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndHours As System.Windows.Forms.DateTimePicker
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtError As System.Windows.Forms.TextBox
End Class
