<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuoteSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuoteSummary))
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.panItems = New System.Windows.Forms.Panel()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.gbProgramItems = New System.Windows.Forms.GroupBox()
        Me.lblProg_Desc = New System.Windows.Forms.Label()
        Me.lblProg_Cd = New System.Windows.Forms.Label()
        Me.lblSpector_Cd = New System.Windows.Forms.Label()
        Me.lblEnd_Dt = New System.Windows.Forms.Label()
        Me.lblStart_Dt = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsProgramMenu.SuspendLayout()
        Me.panItems.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProgramItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSave.Enabled = False
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(48, 22)
        Me.tsbSave.Text = "Confirm"
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsClose})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(631, 25)
        Me.tsProgramMenu.TabIndex = 6
        Me.tsProgramMenu.Text = "ToolStrip1"
        '
        'panItems
        '
        Me.panItems.Controls.Add(Me.dgvItems)
        Me.panItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panItems.Location = New System.Drawing.Point(3, 17)
        Me.panItems.Margin = New System.Windows.Forms.Padding(1)
        Me.panItems.Name = "panItems"
        Me.panItems.Size = New System.Drawing.Size(605, 319)
        Me.panItems.TabIndex = 37
        '
        'dgvItems
        '
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvItems.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.Size = New System.Drawing.Size(605, 319)
        Me.dgvItems.TabIndex = 0
        '
        'gbProgramItems
        '
        Me.gbProgramItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramItems.Controls.Add(Me.panItems)
        Me.gbProgramItems.Location = New System.Drawing.Point(10, 177)
        Me.gbProgramItems.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramItems.Name = "gbProgramItems"
        Me.gbProgramItems.Size = New System.Drawing.Size(611, 339)
        Me.gbProgramItems.TabIndex = 7
        Me.gbProgramItems.TabStop = False
        Me.gbProgramItems.Text = "Items"
        '
        'lblProg_Desc
        '
        Me.lblProg_Desc.BackColor = System.Drawing.SystemColors.Control
        Me.lblProg_Desc.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProg_Desc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProg_Desc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProg_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProg_Desc.Location = New System.Drawing.Point(10, 107)
        Me.lblProg_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProg_Desc.Name = "lblProg_Desc"
        Me.lblProg_Desc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProg_Desc.Size = New System.Drawing.Size(105, 22)
        Me.lblProg_Desc.TabIndex = 21
        Me.lblProg_Desc.Text = "Description:"
        '
        'lblProg_Cd
        '
        Me.lblProg_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblProg_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProg_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProg_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProg_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProg_Cd.Location = New System.Drawing.Point(10, 84)
        Me.lblProg_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProg_Cd.Name = "lblProg_Cd"
        Me.lblProg_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProg_Cd.Size = New System.Drawing.Size(102, 22)
        Me.lblProg_Cd.TabIndex = 19
        Me.lblProg_Cd.Text = "Quote Name:"
        '
        'lblSpector_Cd
        '
        Me.lblSpector_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpector_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpector_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpector_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpector_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSpector_Cd.Location = New System.Drawing.Point(246, 36)
        Me.lblSpector_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSpector_Cd.Name = "lblSpector_Cd"
        Me.lblSpector_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpector_Cd.Size = New System.Drawing.Size(105, 22)
        Me.lblSpector_Cd.TabIndex = 27
        Me.lblSpector_Cd.Text = "Spector Code:"
        '
        'lblEnd_Dt
        '
        Me.lblEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnd_Dt.Location = New System.Drawing.Point(10, 153)
        Me.lblEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnd_Dt.Name = "lblEnd_Dt"
        Me.lblEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnd_Dt.Size = New System.Drawing.Size(105, 22)
        Me.lblEnd_Dt.TabIndex = 25
        Me.lblEnd_Dt.Text = "End Date:"
        '
        'lblStart_Dt
        '
        Me.lblStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStart_Dt.Location = New System.Drawing.Point(10, 130)
        Me.lblStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStart_Dt.Name = "lblStart_Dt"
        Me.lblStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStart_Dt.Size = New System.Drawing.Size(105, 22)
        Me.lblStart_Dt.TabIndex = 23
        Me.lblStart_Dt.Text = "Start Date:"
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(10, 36)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(102, 22)
        Me.lblCus_No.TabIndex = 17
        Me.lblCus_No.Text = "Customer:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(111, 35)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(130, 22)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "USA434"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(111, 83)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(507, 22)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "COCA COLA"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(111, 106)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(507, 22)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "ITEMS USED FOR COCA COLA"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(111, 129)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(133, 22)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "10/01/2013"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(111, 152)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(105, 22)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "10/14/2013"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(350, 35)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(105, 22)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "End Date"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(111, 59)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(408, 22)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "STAPLES"
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
        'frmQuoteSummary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(631, 530)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblProg_Desc)
        Me.Controls.Add(Me.lblProg_Cd)
        Me.Controls.Add(Me.lblSpector_Cd)
        Me.Controls.Add(Me.lblEnd_Dt)
        Me.Controls.Add(Me.lblStart_Dt)
        Me.Controls.Add(Me.lblCus_No)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.gbProgramItems)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmQuoteSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-QUO-SUM-001"
        Me.Text = "Quote Summary"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.panItems.ResumeLayout(False)
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProgramItems.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents panItems As System.Windows.Forms.Panel
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents gbProgramItems As System.Windows.Forms.GroupBox
    Friend WithEvents lblProg_Desc As System.Windows.Forms.Label
    Friend WithEvents lblProg_Cd As System.Windows.Forms.Label
    Friend WithEvents lblSpector_Cd As System.Windows.Forms.Label
    Friend WithEvents lblEnd_Dt As System.Windows.Forms.Label
    Friend WithEvents lblStart_Dt As System.Windows.Forms.Label
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
End Class
