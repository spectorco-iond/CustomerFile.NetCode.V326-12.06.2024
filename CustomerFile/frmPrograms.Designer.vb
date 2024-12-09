<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrograms
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
        Me.UcPrograms = New CustomerFile.ucPrograms()
        Me.SuspendLayout()
        '
        'UcPrograms
        '
        Me.UcPrograms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPrograms.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcPrograms.Location = New System.Drawing.Point(0, 0)
        Me.UcPrograms.Name = "UcPrograms"
        Me.UcPrograms.Size = New System.Drawing.Size(992, 566)
        Me.UcPrograms.TabIndex = 0
        Me.UcPrograms.Tag = "CF-CTL-PRG-001"
        '
        'frmPrograms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.UcPrograms)
        Me.Name = "frmPrograms"
        Me.Text = "Programs [All companies]"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcPrograms As CustomerFile.ucPrograms
End Class
