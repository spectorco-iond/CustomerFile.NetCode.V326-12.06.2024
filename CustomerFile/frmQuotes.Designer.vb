﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotes
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
        Me.ucQuotes = New CustomerFile.ucQuotes()
        Me.SuspendLayout()
        '
        'ucQuotes
        '
        Me.ucQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucQuotes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucQuotes.Location = New System.Drawing.Point(0, 0)
        Me.ucQuotes.Name = "ucQuotes"
        Me.ucQuotes.Size = New System.Drawing.Size(992, 566)
        Me.ucQuotes.TabIndex = 0
        Me.ucQuotes.Tag = "CF-CTL-QUO-001"
        '
        'frmQuotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.ucQuotes)
        Me.Name = "frmQuotes"
        Me.Tag = "CF-QUO-TES-001"
        Me.Text = "Quotes [All companies]"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucQuotes As CustomerFile.ucQuotes
End Class
