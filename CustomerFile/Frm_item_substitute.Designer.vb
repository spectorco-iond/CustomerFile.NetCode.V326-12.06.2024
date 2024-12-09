<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_item_substitute
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
        Me.Dgv_item_substitute = New System.Windows.Forms.DataGridView()
        Me.Dgv_item_list = New System.Windows.Forms.DataGridView()
        Me.TBox_filter_by_cd = New System.Windows.Forms.TextBox()
        Me.Bt_Add_SITEM = New System.Windows.Forms.Button()
        Me.Bt_Del_SITEM = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Dgv_item_substitute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_item_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgv_item_substitute
        '
        Me.Dgv_item_substitute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_item_substitute.Location = New System.Drawing.Point(3, 17)
        Me.Dgv_item_substitute.Name = "Dgv_item_substitute"
        Me.Dgv_item_substitute.Size = New System.Drawing.Size(89, 188)
        Me.Dgv_item_substitute.TabIndex = 0
        '
        'Dgv_item_list
        '
        Me.Dgv_item_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_item_list.Location = New System.Drawing.Point(158, 28)
        Me.Dgv_item_list.Name = "Dgv_item_list"
        Me.Dgv_item_list.Size = New System.Drawing.Size(150, 177)
        Me.Dgv_item_list.TabIndex = 1
        '
        'TBox_filter_by_cd
        '
        Me.TBox_filter_by_cd.Location = New System.Drawing.Point(250, 2)
        Me.TBox_filter_by_cd.Name = "TBox_filter_by_cd"
        Me.TBox_filter_by_cd.Size = New System.Drawing.Size(60, 20)
        Me.TBox_filter_by_cd.TabIndex = 2
        '
        'Bt_Add_SITEM
        '
        Me.Bt_Add_SITEM.Location = New System.Drawing.Point(94, 35)
        Me.Bt_Add_SITEM.Name = "Bt_Add_SITEM"
        Me.Bt_Add_SITEM.Size = New System.Drawing.Size(63, 52)
        Me.Bt_Add_SITEM.TabIndex = 3
        Me.Bt_Add_SITEM.Text = "<< Add Substitute ITEM"
        Me.Bt_Add_SITEM.UseVisualStyleBackColor = True
        '
        'Bt_Del_SITEM
        '
        Me.Bt_Del_SITEM.Location = New System.Drawing.Point(94, 109)
        Me.Bt_Del_SITEM.Name = "Bt_Del_SITEM"
        Me.Bt_Del_SITEM.Size = New System.Drawing.Size(63, 51)
        Me.Bt_Del_SITEM.TabIndex = 4
        Me.Bt_Del_SITEM.Text = ">> Delete Substitute ITEM"
        Me.Bt_Del_SITEM.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(156, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Filter By ITEM_CD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-4, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Substitue ITEM List"
        '
        'Frm_item_substitute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 209)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bt_Del_SITEM)
        Me.Controls.Add(Me.Bt_Add_SITEM)
        Me.Controls.Add(Me.TBox_filter_by_cd)
        Me.Controls.Add(Me.Dgv_item_list)
        Me.Controls.Add(Me.Dgv_item_substitute)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_item_substitute"
        Me.ShowInTaskbar = False
        Me.Text = "item_substitute"
        CType(Me.Dgv_item_substitute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_item_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Dgv_item_substitute As DataGridView
    Friend WithEvents Dgv_item_list As DataGridView
    Friend WithEvents TBox_filter_by_cd As TextBox
    Friend WithEvents Bt_Add_SITEM As Button
    Friend WithEvents Bt_Del_SITEM As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
