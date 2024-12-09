<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.ucCharges = New CustomerFile.ucCharges()
        Me.SuspendLayout()
        '
        'ucCharges
        '
        Me.ucCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCharges.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucCharges.Location = New System.Drawing.Point(0, 0)
        Me.ucCharges.Name = "ucCharges"
        Me.ucCharges.Size = New System.Drawing.Size(992, 566)
        Me.ucCharges.TabIndex = 0
        Me.ucCharges.Tag = "CF-CTL-CHG-001"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.ucCharges)
        Me.Name = "frmOptions"
        Me.Text = "Options [All Companies]"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucCharges As CustomerFile.ucCharges
End Class
