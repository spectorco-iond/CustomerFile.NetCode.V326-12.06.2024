﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrders
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
        Me.UcOrders = New CustomerFile.ucOrders()
        Me.SuspendLayout()
        '
        'UcOrders
        '
        Me.UcOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcOrders.Location = New System.Drawing.Point(0, 0)
        Me.UcOrders.Margin = New System.Windows.Forms.Padding(0)
        Me.UcOrders.Name = "UcOrders"
        Me.UcOrders.Size = New System.Drawing.Size(992, 566)
        Me.UcOrders.TabIndex = 0
        Me.UcOrders.Tag = "CF-CTL-ORD-001"
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.UcOrders)
        Me.Name = "frmOrders"
        Me.Text = "Orders [All companies]"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcOrders As CustomerFile.ucOrders
End Class
