<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPrograms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucPrograms))
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsPrograms = New System.Windows.Forms.ToolStrip()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscbPrograms = New System.Windows.Forms.ToolStripComboBox()
        Me.tslOnlyMine = New System.Windows.Forms.ToolStripLabel()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dgvPrograms = New System.Windows.Forms.DataGridView()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.chkShow_Only_User_Stuff = New System.Windows.Forms.CheckBox()
        Me.tsExcel = New System.Windows.Forms.ToolStripButton()
        Me.tsProgressBarExcel = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslblPercent = New System.Windows.Forms.ToolStripLabel()
        Me.tsPrograms.SuspendLayout()
        Me.panData.SuspendLayout()
        CType(Me.dgvPrograms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.panExtSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNew.Enabled = False
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(35, 22)
        Me.tsbNew.Text = "New"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(40, 22)
        Me.tsbOpen.Text = "Open"
        '
        'tsPrograms
        '
        Me.tsPrograms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh, Me.ToolStripSeparator1, Me.tscbPrograms, Me.tslOnlyMine, Me.tsExcel, Me.tsProgressBarExcel, Me.tslblPercent})
        Me.tsPrograms.Location = New System.Drawing.Point(0, 0)
        Me.tsPrograms.Name = "tsPrograms"
        Me.tsPrograms.Size = New System.Drawing.Size(822, 25)
        Me.tsPrograms.TabIndex = 0
        Me.tsPrograms.Text = "Excel Button"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(44, 22)
        Me.tsbDelete.Text = "Delete"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(50, 22)
        Me.tsbRefresh.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tscbPrograms
        '
        Me.tscbPrograms.Items.AddRange(New Object() {"All Programs", "Almost Due", "Current Programs", "History Programs"})
        Me.tscbPrograms.Name = "tscbPrograms"
        Me.tscbPrograms.Size = New System.Drawing.Size(110, 25)
        Me.tscbPrograms.Text = "Current Programs"
        '
        'tslOnlyMine
        '
        Me.tslOnlyMine.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslOnlyMine.Name = "tslOnlyMine"
        Me.tslOnlyMine.Size = New System.Drawing.Size(106, 22)
        Me.tslOnlyMine.Text = "Only My Programs"
        '
        'panData
        '
        Me.panData.Controls.Add(Me.dgvPrograms)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 70)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(822, 230)
        Me.panData.TabIndex = 16
        '
        'dgvPrograms
        '
        Me.dgvPrograms.AllowUserToAddRows = False
        Me.dgvPrograms.AllowUserToDeleteRows = False
        Me.dgvPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrograms.ColumnHeadersVisible = False
        Me.dgvPrograms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrograms.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrograms.Name = "dgvPrograms"
        Me.dgvPrograms.ReadOnly = True
        Me.dgvPrograms.RowHeadersWidth = 25
        Me.dgvPrograms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrograms.Size = New System.Drawing.Size(822, 208)
        Me.dgvPrograms.TabIndex = 6
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 208)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(822, 22)
        Me.ssStatus.TabIndex = 5
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tssRecordCount
        '
        Me.tssRecordCount.Name = "tssRecordCount"
        Me.tssRecordCount.Size = New System.Drawing.Size(61, 17)
        Me.tssRecordCount.Text = "Records: 0"
        '
        'panExtSearch
        '
        Me.panExtSearch.Controls.Add(Me.dgvSearch)
        Me.panExtSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panExtSearch.Location = New System.Drawing.Point(0, 25)
        Me.panExtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panExtSearch.Name = "panExtSearch"
        Me.panExtSearch.Size = New System.Drawing.Size(822, 45)
        Me.panExtSearch.TabIndex = 15
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
        Me.dgvSearch.Size = New System.Drawing.Size(822, 45)
        Me.dgvSearch.TabIndex = 5
        '
        'chkShow_Only_User_Stuff
        '
        Me.chkShow_Only_User_Stuff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShow_Only_User_Stuff.AutoSize = True
        Me.chkShow_Only_User_Stuff.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkShow_Only_User_Stuff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chkShow_Only_User_Stuff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShow_Only_User_Stuff.Location = New System.Drawing.Point(700, 6)
        Me.chkShow_Only_User_Stuff.Name = "chkShow_Only_User_Stuff"
        Me.chkShow_Only_User_Stuff.Size = New System.Drawing.Size(15, 14)
        Me.chkShow_Only_User_Stuff.TabIndex = 17
        Me.chkShow_Only_User_Stuff.UseVisualStyleBackColor = False
        '
        'tsExcel
        '
        Me.tsExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsExcel.Image = CType(resources.GetObject("tsExcel.Image"), System.Drawing.Image)
        Me.tsExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExcel.Name = "tsExcel"
        Me.tsExcel.Size = New System.Drawing.Size(23, 22)
        Me.tsExcel.Tag = "CF-PROG-BTN-EXCEL"
        Me.tsExcel.Text = "Excel Button"
        '
        'tsProgressBarExcel
        '
        Me.tsProgressBarExcel.Name = "tsProgressBarExcel"
        Me.tsProgressBarExcel.Size = New System.Drawing.Size(250, 22)
        Me.tsProgressBarExcel.Tag = "CF-PROG-BTN-EXCEL"
        Me.tsProgressBarExcel.Visible = False
        '
        'tslblPercent
        '
        Me.tslblPercent.Name = "tslblPercent"
        Me.tslblPercent.Size = New System.Drawing.Size(17, 22)
        Me.tslblPercent.Text = "%"
        Me.tslblPercent.Visible = False
        '
        'ucPrograms
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkShow_Only_User_Stuff)
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.tsPrograms)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucPrograms"
        Me.Size = New System.Drawing.Size(822, 300)
        Me.Tag = "CF-CTL-PRG-001"
        Me.tsPrograms.ResumeLayout(False)
        Me.tsPrograms.PerformLayout()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        CType(Me.dgvPrograms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrograms As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvPrograms As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tscbPrograms As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents chkShow_Only_User_Stuff As System.Windows.Forms.CheckBox
    Friend WithEvents tslOnlyMine As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsExcel As ToolStripButton
    Friend WithEvents tsProgressBarExcel As ToolStripProgressBar
    Friend WithEvents tslblPercent As ToolStripLabel
End Class
