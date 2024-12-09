<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCharges
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucCharges))
        Me.tsCharges = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscbOptions = New System.Windows.Forms.ToolStripComboBox()
        Me.tsbcOptionList = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbGlobalOption = New System.Windows.Forms.ToolStripButton()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dgvCharges = New System.Windows.Forms.DataGridView()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.chkShow_Only_User_Stuff = New System.Windows.Forms.CheckBox()
        Me.tsCharges.SuspendLayout()
        Me.panData.SuspendLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.panExtSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsCharges
        '
        Me.tsCharges.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsCharges.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh, Me.ToolStripSeparator1, Me.tscbOptions, Me.tsbcOptionList, Me.ToolStripLabel1, Me.tsbGlobalOption})
        Me.tsCharges.Location = New System.Drawing.Point(0, 0)
        Me.tsCharges.Name = "tsCharges"
        Me.tsCharges.Size = New System.Drawing.Size(711, 28)
        Me.tsCharges.TabIndex = 6
        Me.tsCharges.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNew.Enabled = False
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(43, 25)
        Me.tsbNew.Text = "New"
        Me.tsbNew.Visible = False
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(49, 25)
        Me.tsbOpen.Text = "Open"
        Me.tsbOpen.Visible = False
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(57, 25)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.Visible = False
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(62, 25)
        Me.tsbRefresh.Text = "Refresh"
        Me.tsbRefresh.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        Me.ToolStripSeparator1.Visible = False
        '
        'tscbOptions
        '
        Me.tscbOptions.Items.AddRange(New Object() {"All Options", "Almost Due", "Current Options", "History Options"})
        Me.tscbOptions.Name = "tscbOptions"
        Me.tscbOptions.Size = New System.Drawing.Size(110, 28)
        Me.tscbOptions.Text = "Current Options"
        Me.tscbOptions.Visible = False
        '
        'tsbcOptionList
        '
        Me.tsbcOptionList.Name = "tsbcOptionList"
        Me.tsbcOptionList.Size = New System.Drawing.Size(75, 28)
        Me.tsbcOptionList.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(119, 25)
        Me.ToolStripLabel1.Text = "Only My Options"
        Me.ToolStripLabel1.Visible = False
        '
        'tsbGlobalOption
        '
        Me.tsbGlobalOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbGlobalOption.Image = CType(resources.GetObject("tsbGlobalOption.Image"), System.Drawing.Image)
        Me.tsbGlobalOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGlobalOption.Name = "tsbGlobalOption"
        Me.tsbGlobalOption.Size = New System.Drawing.Size(174, 24)
        Me.tsbGlobalOption.Tag = "CF-CTL-CHG-AGOP-001"
        Me.tsbGlobalOption.Text = "New/Manage All-in-one"
        Me.tsbGlobalOption.Visible = False
        '
        'panData
        '
        Me.panData.Controls.Add(Me.dgvCharges)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 73)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(711, 227)
        Me.panData.TabIndex = 20
        '
        'dgvCharges
        '
        Me.dgvCharges.AllowUserToAddRows = False
        Me.dgvCharges.AllowUserToDeleteRows = False
        Me.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCharges.Location = New System.Drawing.Point(0, 0)
        Me.dgvCharges.Name = "dgvCharges"
        Me.dgvCharges.ReadOnly = True
        Me.dgvCharges.RowHeadersWidth = 25
        Me.dgvCharges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCharges.Size = New System.Drawing.Size(711, 202)
        Me.dgvCharges.TabIndex = 5
        '
        'ssStatus
        '
        Me.ssStatus.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 202)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(711, 25)
        Me.ssStatus.TabIndex = 4
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tssRecordCount
        '
        Me.tssRecordCount.Name = "tssRecordCount"
        Me.tssRecordCount.Size = New System.Drawing.Size(77, 20)
        Me.tssRecordCount.Text = "Records: 0"
        '
        'panExtSearch
        '
        Me.panExtSearch.Controls.Add(Me.dgvSearch)
        Me.panExtSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panExtSearch.Location = New System.Drawing.Point(0, 28)
        Me.panExtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panExtSearch.Name = "panExtSearch"
        Me.panExtSearch.Size = New System.Drawing.Size(711, 45)
        Me.panExtSearch.TabIndex = 19
        Me.panExtSearch.Visible = False
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.ColumnHeadersHeight = 12
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.RowHeadersWidth = 25
        Me.dgvSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSearch.Size = New System.Drawing.Size(711, 45)
        Me.dgvSearch.TabIndex = 5
        Me.dgvSearch.Visible = False
        '
        'chkShow_Only_User_Stuff
        '
        Me.chkShow_Only_User_Stuff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShow_Only_User_Stuff.AutoSize = True
        Me.chkShow_Only_User_Stuff.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkShow_Only_User_Stuff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chkShow_Only_User_Stuff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShow_Only_User_Stuff.Location = New System.Drawing.Point(594, 6)
        Me.chkShow_Only_User_Stuff.Name = "chkShow_Only_User_Stuff"
        Me.chkShow_Only_User_Stuff.Size = New System.Drawing.Size(18, 17)
        Me.chkShow_Only_User_Stuff.TabIndex = 18
        Me.chkShow_Only_User_Stuff.UseVisualStyleBackColor = False
        Me.chkShow_Only_User_Stuff.Visible = False
        '
        'ucCharges
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkShow_Only_User_Stuff)
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.tsCharges)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucCharges"
        Me.Size = New System.Drawing.Size(711, 300)
        Me.Tag = "CF-CTL-CHG-001"
        Me.tsCharges.ResumeLayout(False)
        Me.tsCharges.PerformLayout()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        CType(Me.dgvCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsCharges As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvCharges As System.Windows.Forms.DataGridView
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbcOptionList As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tscbOptions As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chkShow_Only_User_Stuff As System.Windows.Forms.CheckBox
    Friend WithEvents tsbGlobalOption As System.Windows.Forms.ToolStripButton

End Class
