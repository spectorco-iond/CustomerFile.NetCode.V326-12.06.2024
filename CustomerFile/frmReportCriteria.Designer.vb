<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCriteria
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvCriteria = New System.Windows.Forms.DataGridView()
        Me.lblCriteriatoSearch = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCriteriatoSearch)
        Me.Panel1.Controls.Add(Me.txtCriteria)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 52)
        Me.Panel1.TabIndex = 0
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(219, 13)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(246, 22)
        Me.txtCriteria.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvCriteria)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(477, 274)
        Me.Panel2.TabIndex = 1
        '
        'dgvCriteria
        '
        Me.dgvCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCriteria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCriteria.Location = New System.Drawing.Point(0, 0)
        Me.dgvCriteria.Name = "dgvCriteria"
        Me.dgvCriteria.ReadOnly = True
        Me.dgvCriteria.RowTemplate.Height = 24
        Me.dgvCriteria.Size = New System.Drawing.Size(477, 274)
        Me.dgvCriteria.TabIndex = 0
        '
        'lblCriteriatoSearch
        '
        Me.lblCriteriatoSearch.AutoSize = True
        Me.lblCriteriatoSearch.Location = New System.Drawing.Point(6, 16)
        Me.lblCriteriatoSearch.Name = "lblCriteriatoSearch"
        Me.lblCriteriatoSearch.Size = New System.Drawing.Size(92, 17)
        Me.lblCriteriatoSearch.TabIndex = 1
        Me.lblCriteriatoSearch.Text = "Search by   : "
        '
        'frmReportCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 326)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReportCriteria"
        Me.Text = "frmReportCriteria"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvCriteria As DataGridView
    Friend WithEvents txtCriteria As TextBox
    Friend WithEvents lblCriteriatoSearch As Label
End Class
