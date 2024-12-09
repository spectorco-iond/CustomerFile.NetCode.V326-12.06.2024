<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerConfig
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
        Me.panMainContainer = New System.Windows.Forms.Panel()
        Me.panCust = New System.Windows.Forms.Panel()
        Me.dgvCust = New System.Windows.Forms.DataGridView()
        Me.panSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.panMainContainer.SuspendLayout()
        Me.panCust.SuspendLayout()
        CType(Me.dgvCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panMainContainer
        '
        Me.panMainContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panMainContainer.Controls.Add(Me.panCust)
        Me.panMainContainer.Controls.Add(Me.panSearch)
        Me.panMainContainer.Location = New System.Drawing.Point(9, 9)
        Me.panMainContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.panMainContainer.Name = "panMainContainer"
        Me.panMainContainer.Size = New System.Drawing.Size(998, 682)
        Me.panMainContainer.TabIndex = 11
        '
        'panCust
        '
        Me.panCust.Controls.Add(Me.dgvCust)
        Me.panCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCust.Location = New System.Drawing.Point(0, 65)
        Me.panCust.Margin = New System.Windows.Forms.Padding(2)
        Me.panCust.Name = "panCust"
        Me.panCust.Size = New System.Drawing.Size(998, 617)
        Me.panCust.TabIndex = 12
        '
        'dgvCust
        '
        Me.dgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCust.Location = New System.Drawing.Point(0, 0)
        Me.dgvCust.Name = "dgvCust"
        Me.dgvCust.ReadOnly = True
        Me.dgvCust.Size = New System.Drawing.Size(998, 617)
        Me.dgvCust.TabIndex = 0
        '
        'panSearch
        '
        Me.panSearch.Controls.Add(Me.dgvSearch)
        Me.panSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSearch.Location = New System.Drawing.Point(0, 0)
        Me.panSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.panSearch.Name = "panSearch"
        Me.panSearch.Size = New System.Drawing.Size(998, 65)
        Me.panSearch.TabIndex = 11
        '
        'dgvSearch
        '
        Me.dgvSearch.ColumnHeadersHeight = 32
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSearch.Size = New System.Drawing.Size(998, 65)
        Me.dgvSearch.TabIndex = 0
        '
        'frmCustomerConfig
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1016, 700)
        Me.Controls.Add(Me.panMainContainer)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCustomerConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CUS-CFG-001"
        Me.Text = "Customer Configuration"
        Me.panMainContainer.ResumeLayout(False)
        Me.panCust.ResumeLayout(False)
        CType(Me.dgvCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panMainContainer As System.Windows.Forms.Panel
    Friend WithEvents panCust As System.Windows.Forms.Panel
    Friend WithEvents dgvCust As System.Windows.Forms.DataGridView
    Friend WithEvents panSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
End Class
