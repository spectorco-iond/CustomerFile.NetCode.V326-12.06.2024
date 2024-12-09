<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProg_Item_Price
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
        Me.panHeader = New System.Windows.Forms.Panel()
        Me.dgvItem_Price = New System.Windows.Forms.DataGridView()
        Me.lblItem_Cd = New System.Windows.Forms.Label()
        Me.txtItem_Cd = New System.Windows.Forms.TextBox()
        Me.panHeader.SuspendLayout()
        CType(Me.dgvItem_Price, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panHeader
        '
        Me.panHeader.Controls.Add(Me.lblItem_Cd)
        Me.panHeader.Controls.Add(Me.txtItem_Cd)
        Me.panHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panHeader.Location = New System.Drawing.Point(0, 0)
        Me.panHeader.Name = "panHeader"
        Me.panHeader.Size = New System.Drawing.Size(292, 30)
        Me.panHeader.TabIndex = 12
        '
        'dgvItem_Price
        '
        Me.dgvItem_Price.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItem_Price.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItem_Price.Location = New System.Drawing.Point(0, 30)
        Me.dgvItem_Price.Name = "dgvItem_Price"
        Me.dgvItem_Price.Size = New System.Drawing.Size(292, 236)
        Me.dgvItem_Price.TabIndex = 13
        '
        'lblItem_Cd
        '
        Me.lblItem_Cd.AutoSize = True
        Me.lblItem_Cd.Location = New System.Drawing.Point(3, 8)
        Me.lblItem_Cd.Name = "lblItem_Cd"
        Me.lblItem_Cd.Size = New System.Drawing.Size(30, 13)
        Me.lblItem_Cd.TabIndex = 3
        Me.lblItem_Cd.Text = "Item:"
        '
        'txtItem_Cd
        '
        Me.txtItem_Cd.Location = New System.Drawing.Point(39, 5)
        Me.txtItem_Cd.Name = "txtItem_Cd"
        Me.txtItem_Cd.Size = New System.Drawing.Size(142, 20)
        Me.txtItem_Cd.TabIndex = 2
        '
        'frmProg_Item_Price
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.dgvItem_Price)
        Me.Controls.Add(Me.panHeader)
        Me.Name = "frmProg_Item_Price"
        Me.Text = "Item Prices"
        Me.panHeader.ResumeLayout(False)
        Me.panHeader.PerformLayout()
        CType(Me.dgvItem_Price, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panHeader As System.Windows.Forms.Panel
    Friend WithEvents dgvItem_Price As System.Windows.Forms.DataGridView
    Friend WithEvents lblItem_Cd As System.Windows.Forms.Label
    Friend WithEvents txtItem_Cd As System.Windows.Forms.TextBox
End Class
