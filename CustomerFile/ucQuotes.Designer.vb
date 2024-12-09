<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucQuotes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucQuotes))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddQuote_Step_ID = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AllStepsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SentToCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tscbQuotes = New System.Windows.Forms.ToolStripComboBox()
        Me.tscbQuote_Step_ID = New System.Windows.Forms.ToolStripComboBox()
        Me.tslOnlyMine = New System.Windows.Forms.ToolStripLabel()
        Me.tscbConvertExcel = New System.Windows.Forms.ToolStripButton()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dgvQuotes = New System.Windows.Forms.DataGridView()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.chkShow_Only_User_Stuff = New System.Windows.Forms.CheckBox()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.panData.SuspendLayout()
        CType(Me.dgvQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.panExtSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh, Me.ToolStripSeparator1, Me.tsddQuote_Step_ID, Me.tscbQuotes, Me.tscbQuote_Step_ID, Me.tslOnlyMine, Me.tscbConvertExcel})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(640, 25)
        Me.tsMenu.TabIndex = 13
        Me.tsMenu.Text = "ToolStrip1"
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
        'tsddQuote_Step_ID
        '
        Me.tsddQuote_Step_ID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddQuote_Step_ID.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllStepsToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.CompletedToolStripMenuItem, Me.SentToCustomerToolStripMenuItem})
        Me.tsddQuote_Step_ID.Image = CType(resources.GetObject("tsddQuote_Step_ID.Image"), System.Drawing.Image)
        Me.tsddQuote_Step_ID.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddQuote_Step_ID.Name = "tsddQuote_Step_ID"
        Me.tsddQuote_Step_ID.Size = New System.Drawing.Size(65, 22)
        Me.tsddQuote_Step_ID.Text = "All Steps"
        Me.tsddQuote_Step_ID.Visible = False
        '
        'AllStepsToolStripMenuItem
        '
        Me.AllStepsToolStripMenuItem.Name = "AllStepsToolStripMenuItem"
        Me.AllStepsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.AllStepsToolStripMenuItem.Text = "All Steps"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(209, 22)
        Me.ToolStripMenuItem2.Text = "Saved Quote"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(209, 22)
        Me.ToolStripMenuItem3.Text = "Pending Pricing Approval"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(209, 22)
        Me.ToolStripMenuItem4.Text = "Pricing Approved"
        '
        'CompletedToolStripMenuItem
        '
        Me.CompletedToolStripMenuItem.Name = "CompletedToolStripMenuItem"
        Me.CompletedToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CompletedToolStripMenuItem.Text = "Completed"
        '
        'SentToCustomerToolStripMenuItem
        '
        Me.SentToCustomerToolStripMenuItem.Name = "SentToCustomerToolStripMenuItem"
        Me.SentToCustomerToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.SentToCustomerToolStripMenuItem.Text = "Sent To Customer"
        '
        'tscbQuotes
        '
        Me.tscbQuotes.Items.AddRange(New Object() {"All Quotes", "Almost Due", "Current Quotes", "History Quotes", "Macola Quotes"})
        Me.tscbQuotes.Name = "tscbQuotes"
        Me.tscbQuotes.Size = New System.Drawing.Size(100, 25)
        Me.tscbQuotes.Text = "Current Quotes"
        '
        'tscbQuote_Step_ID
        '
        Me.tscbQuote_Step_ID.Items.AddRange(New Object() {"All Steps", "Saved Quote", "Pending Approval", "Approved", "Completed", "Sent To Customer"})
        Me.tscbQuote_Step_ID.Name = "tscbQuote_Step_ID"
        Me.tscbQuote_Step_ID.Size = New System.Drawing.Size(110, 25)
        Me.tscbQuote_Step_ID.Text = "All Steps"
        '
        'tslOnlyMine
        '
        Me.tslOnlyMine.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslOnlyMine.Name = "tslOnlyMine"
        Me.tslOnlyMine.Size = New System.Drawing.Size(93, 22)
        Me.tslOnlyMine.Text = "Only My Quotes"
        '
        'tscbConvertExcel
        '
        Me.tscbConvertExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tscbConvertExcel.Image = CType(resources.GetObject("tscbConvertExcel.Image"), System.Drawing.Image)
        Me.tscbConvertExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscbConvertExcel.Name = "tscbConvertExcel"
        Me.tscbConvertExcel.Size = New System.Drawing.Size(93, 22)
        Me.tscbConvertExcel.Text = "Convert->Excel"
        Me.tscbConvertExcel.Visible = False
        '
        'panData
        '
        Me.panData.Controls.Add(Me.dgvQuotes)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 70)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(640, 230)
        Me.panData.TabIndex = 15
        '
        'dgvQuotes
        '
        Me.dgvQuotes.AllowUserToAddRows = False
        Me.dgvQuotes.AllowUserToDeleteRows = False
        Me.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuotes.ColumnHeadersVisible = False
        Me.dgvQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQuotes.Location = New System.Drawing.Point(0, 0)
        Me.dgvQuotes.Name = "dgvQuotes"
        Me.dgvQuotes.ReadOnly = True
        Me.dgvQuotes.RowHeadersWidth = 25
        Me.dgvQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuotes.Size = New System.Drawing.Size(640, 208)
        Me.dgvQuotes.TabIndex = 12
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 208)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(640, 22)
        Me.ssStatus.TabIndex = 11
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
        Me.panExtSearch.Size = New System.Drawing.Size(640, 45)
        Me.panExtSearch.TabIndex = 14
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
        Me.dgvSearch.Size = New System.Drawing.Size(640, 45)
        Me.dgvSearch.TabIndex = 11
        '
        'chkShow_Only_User_Stuff
        '
        Me.chkShow_Only_User_Stuff.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShow_Only_User_Stuff.AutoSize = True
        Me.chkShow_Only_User_Stuff.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.chkShow_Only_User_Stuff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chkShow_Only_User_Stuff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShow_Only_User_Stuff.Location = New System.Drawing.Point(531, 6)
        Me.chkShow_Only_User_Stuff.Name = "chkShow_Only_User_Stuff"
        Me.chkShow_Only_User_Stuff.Size = New System.Drawing.Size(15, 14)
        Me.chkShow_Only_User_Stuff.TabIndex = 16
        Me.chkShow_Only_User_Stuff.UseVisualStyleBackColor = False
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 60000
        '
        'ucQuotes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chkShow_Only_User_Stuff)
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.tsMenu)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucQuotes"
        Me.Size = New System.Drawing.Size(640, 300)
        Me.Tag = "CF-CTL-QUO-001"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        CType(Me.dgvQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvQuotes As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddQuote_Step_ID As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AllStepsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkShow_Only_User_Stuff As System.Windows.Forms.CheckBox
    Friend WithEvents CompletedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SentToCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tscbQuotes As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tscbQuote_Step_ID As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents tslOnlyMine As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbConvertExcel As System.Windows.Forms.ToolStripButton

End Class
