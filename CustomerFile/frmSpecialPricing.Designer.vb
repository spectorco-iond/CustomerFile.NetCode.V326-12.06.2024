<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecialPricing
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
        Me.UcSpecialPricing = New CustomerFile.ucSpecialPricing()
        Me.SuspendLayout()
        '
        'UcSpecialPricing
        '
        Me.UcSpecialPricing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSpecialPricing.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSpecialPricing.Location = New System.Drawing.Point(0, 0)
        Me.UcSpecialPricing.Name = "UcSpecialPricing"
        Me.UcSpecialPricing.Size = New System.Drawing.Size(992, 566)
        Me.UcSpecialPricing.TabIndex = 0
        Me.UcSpecialPricing.Tag = "CF-CTL-SPR-001"
        '
        'frmSpecialPricing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.UcSpecialPricing)
        Me.Name = "frmSpecialPricing"
        Me.Text = "Special Pricing [All companies]"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcSpecialPricing As CustomerFile.ucSpecialPricing
End Class
