<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpectorControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpectorControl))
        Me.cmdCustomerFile = New System.Windows.Forms.Button()
        Me.cmdQuotes = New System.Windows.Forms.Button()
        Me.cmdPrograms = New System.Windows.Forms.Button()
        Me.niSpectorControl = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCustomerFile
        '
        Me.cmdCustomerFile.Location = New System.Drawing.Point(12, 12)
        Me.cmdCustomerFile.Name = "cmdCustomerFile"
        Me.cmdCustomerFile.Size = New System.Drawing.Size(65, 42)
        Me.cmdCustomerFile.TabIndex = 0
        Me.cmdCustomerFile.Text = "Customer File"
        Me.cmdCustomerFile.UseVisualStyleBackColor = True
        '
        'cmdQuotes
        '
        Me.cmdQuotes.Location = New System.Drawing.Point(83, 12)
        Me.cmdQuotes.Name = "cmdQuotes"
        Me.cmdQuotes.Size = New System.Drawing.Size(65, 42)
        Me.cmdQuotes.TabIndex = 1
        Me.cmdQuotes.Text = "Quotes"
        Me.cmdQuotes.UseVisualStyleBackColor = True
        '
        'cmdPrograms
        '
        Me.cmdPrograms.Location = New System.Drawing.Point(154, 12)
        Me.cmdPrograms.Name = "cmdPrograms"
        Me.cmdPrograms.Size = New System.Drawing.Size(65, 42)
        Me.cmdPrograms.TabIndex = 2
        Me.cmdPrograms.Text = "Programs"
        Me.cmdPrograms.UseVisualStyleBackColor = True
        '
        'niSpectorControl
        '
        Me.niSpectorControl.BalloonTipText = "Spector Control"
        Me.niSpectorControl.ContextMenuStrip = Me.ContextMenuStrip1
        Me.niSpectorControl.Icon = CType(resources.GetObject("niSpectorControl.Icon"), System.Drawing.Icon)
        Me.niSpectorControl.Text = "Spector Control"
        Me.niSpectorControl.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripSeparator1, Me.ToolStripMenuItem4})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 98)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem1.Text = "Menu 1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem2.Text = "Menu 2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem3.Text = "Menu 3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(117, 6)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem4.Text = "Exit"
        '
        'frmSpectorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 66)
        Me.Controls.Add(Me.cmdPrograms)
        Me.Controls.Add(Me.cmdQuotes)
        Me.Controls.Add(Me.cmdCustomerFile)
        Me.MaximizeBox = False
        Me.Name = "frmSpectorControl"
        Me.Tag = "CF-SPE-CTL-001"
        Me.Text = "Spector Control"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents cmdCustomerFile As System.Windows.Forms.Button
    Friend WithEvents cmdQuotes As System.Windows.Forms.Button
    Friend WithEvents cmdPrograms As System.Windows.Forms.Button
    Friend WithEvents niSpectorControl As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
End Class
