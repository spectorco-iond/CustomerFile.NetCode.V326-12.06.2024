<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProduction
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucProduction))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dgvProduction = New System.Windows.Forms.DataGridView()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.panData.SuspendLayout()
        CType(Me.dgvProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.panExtSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(500, 25)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNew.Enabled = False
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(32, 22)
        Me.tsbNew.Text = "New"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(37, 22)
        Me.tsbOpen.Text = "Open"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(42, 22)
        Me.tsbDelete.Text = "Delete"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(49, 22)
        Me.tsbRefresh.Text = "Refresh"
        '
        'panData
        '
        Me.panData.Controls.Add(Me.dgvProduction)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 70)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(500, 230)
        Me.panData.TabIndex = 18
        '
        'dgvProduction
        '
        Me.dgvProduction.AllowUserToAddRows = False
        Me.dgvProduction.AllowUserToDeleteRows = False
        Me.dgvProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduction.ColumnHeadersVisible = False
        Me.dgvProduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProduction.Location = New System.Drawing.Point(0, 0)
        Me.dgvProduction.Name = "dgvProduction"
        Me.dgvProduction.ReadOnly = True
        Me.dgvProduction.RowHeadersWidth = 25
        Me.dgvProduction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProduction.Size = New System.Drawing.Size(500, 208)
        Me.dgvProduction.TabIndex = 6
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 208)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(500, 22)
        Me.ssStatus.TabIndex = 5
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tssRecordCount
        '
        Me.tssRecordCount.Name = "tssRecordCount"
        Me.tssRecordCount.Size = New System.Drawing.Size(59, 17)
        Me.tssRecordCount.Text = "Records: 0"
        '
        'panExtSearch
        '
        Me.panExtSearch.Controls.Add(Me.dgvSearch)
        Me.panExtSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panExtSearch.Location = New System.Drawing.Point(0, 25)
        Me.panExtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panExtSearch.Name = "panExtSearch"
        Me.panExtSearch.Size = New System.Drawing.Size(500, 45)
        Me.panExtSearch.TabIndex = 17
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.ColumnHeadersHeight = 12
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.RowHeadersWidth = 25
        Me.dgvSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSearch.Size = New System.Drawing.Size(500, 45)
        Me.dgvSearch.TabIndex = 5
        '
        'ucProduction
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.tsMenu)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucProduction"
        Me.Size = New System.Drawing.Size(500, 300)
        Me.Tag = "CF-CTL-PRD-001"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        CType(Me.dgvProduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvProduction As System.Windows.Forms.DataGridView

End Class
