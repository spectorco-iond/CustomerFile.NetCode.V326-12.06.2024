<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucComm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucComm))
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsComm = New System.Windows.Forms.ToolStrip()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tsbSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.lblNbDays = New System.Windows.Forms.ToolStripLabel()
        Me.txtLastDays = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslSaveAs = New System.Windows.Forms.ToolStripLabel()
        Me.tscbSave_Doc_Type_ID = New System.Windows.Forms.ToolStripComboBox()
        Me.panData = New System.Windows.Forms.Panel()
        Me.panProgress = New System.Windows.Forms.Panel()
        Me.txtPBDocument = New System.Windows.Forms.TextBox()
        Me.txtPBEvent = New System.Windows.Forms.TextBox()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.pnlPreviewDoc = New System.Windows.Forms.Panel()
        Me.panDocument = New System.Windows.Forms.Panel()
        Me.wbShowFile = New System.Windows.Forms.WebBrowser()
        Me.tsDocumentMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbDocumentClose = New System.Windows.Forms.ToolStripButton()
        Me.dgvComm = New System.Windows.Forms.DataGridView()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.tsComm.SuspendLayout()
        Me.panData.SuspendLayout()
        Me.panProgress.SuspendLayout()
        Me.pnlPreviewDoc.SuspendLayout()
        Me.panDocument.SuspendLayout()
        Me.tsDocumentMenu.SuspendLayout()
        CType(Me.dgvComm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tsbNew.Size = New System.Drawing.Size(35, 24)
        Me.tsbNew.Tag = "CF-CTL-COM-001"
        Me.tsbNew.Text = "New"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(40, 24)
        Me.tsbOpen.Text = "Open"
        '
        'tsComm
        '
        Me.tsComm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh, Me.tsbSeparator, Me.lblNbDays, Me.txtLastDays, Me.ToolStripSeparator1, Me.tslSaveAs, Me.tscbSave_Doc_Type_ID})
        Me.tsComm.Location = New System.Drawing.Point(0, 0)
        Me.tsComm.Name = "tsComm"
        Me.tsComm.Size = New System.Drawing.Size(500, 27)
        Me.tsComm.TabIndex = 5
        Me.tsComm.Text = "ToolStrip1"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(44, 24)
        Me.tsbDelete.Text = "Delete"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(50, 24)
        Me.tsbRefresh.Text = "Refresh"
        '
        'tsbSeparator
        '
        Me.tsbSeparator.Name = "tsbSeparator"
        Me.tsbSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'lblNbDays
        '
        Me.lblNbDays.Name = "lblNbDays"
        Me.lblNbDays.Size = New System.Drawing.Size(59, 24)
        Me.lblNbDays.Text = "Last Days:"
        '
        'txtLastDays
        '
        Me.txtLastDays.Name = "txtLastDays"
        Me.txtLastDays.Size = New System.Drawing.Size(40, 27)
        Me.txtLastDays.Text = "90"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'tslSaveAs
        '
        Me.tslSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslSaveAs.Image = CType(resources.GetObject("tslSaveAs.Image"), System.Drawing.Image)
        Me.tslSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslSaveAs.Name = "tslSaveAs"
        Me.tslSaveAs.Size = New System.Drawing.Size(165, 24)
        Me.tslSaveAs.Text = "Save New Document As Type:"
        '
        'tscbSave_Doc_Type_ID
        '
        Me.tscbSave_Doc_Type_ID.Name = "tscbSave_Doc_Type_ID"
        Me.tscbSave_Doc_Type_ID.Size = New System.Drawing.Size(140, 23)
        '
        'panData
        '
        Me.panData.Controls.Add(Me.panProgress)
        Me.panData.Controls.Add(Me.pnlPreviewDoc)
        Me.panData.Controls.Add(Me.dgvComm)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 72)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(500, 228)
        Me.panData.TabIndex = 20
        '
        'panProgress
        '
        Me.panProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panProgress.Controls.Add(Me.txtPBDocument)
        Me.panProgress.Controls.Add(Me.txtPBEvent)
        Me.panProgress.Controls.Add(Me.pbProgress)
        Me.panProgress.Location = New System.Drawing.Point(95, 45)
        Me.panProgress.Name = "panProgress"
        Me.panProgress.Size = New System.Drawing.Size(311, 141)
        Me.panProgress.TabIndex = 164
        Me.panProgress.Visible = False
        '
        'txtPBDocument
        '
        Me.txtPBDocument.BackColor = System.Drawing.SystemColors.Control
        Me.txtPBDocument.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPBDocument.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPBDocument.Location = New System.Drawing.Point(3, 56)
        Me.txtPBDocument.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPBDocument.Multiline = True
        Me.txtPBDocument.Name = "txtPBDocument"
        Me.txtPBDocument.ReadOnly = True
        Me.txtPBDocument.Size = New System.Drawing.Size(301, 74)
        Me.txtPBDocument.TabIndex = 159
        '
        'txtPBEvent
        '
        Me.txtPBEvent.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtPBEvent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPBEvent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPBEvent.ForeColor = System.Drawing.SystemColors.Window
        Me.txtPBEvent.Location = New System.Drawing.Point(3, 4)
        Me.txtPBEvent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPBEvent.Name = "txtPBEvent"
        Me.txtPBEvent.Size = New System.Drawing.Size(301, 15)
        Me.txtPBEvent.TabIndex = 158
        Me.txtPBEvent.Text = "In Progress..."
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(3, 26)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(301, 23)
        Me.pbProgress.TabIndex = 156
        '
        'pnlPreviewDoc
        '
        Me.pnlPreviewDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreviewDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreviewDoc.Controls.Add(Me.panDocument)
        Me.pnlPreviewDoc.Controls.Add(Me.tsDocumentMenu)
        Me.pnlPreviewDoc.Location = New System.Drawing.Point(20, 20)
        Me.pnlPreviewDoc.Margin = New System.Windows.Forms.Padding(20)
        Me.pnlPreviewDoc.Name = "pnlPreviewDoc"
        Me.pnlPreviewDoc.Size = New System.Drawing.Size(460, 188)
        Me.pnlPreviewDoc.TabIndex = 163
        Me.pnlPreviewDoc.Visible = False
        '
        'panDocument
        '
        Me.panDocument.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panDocument.Controls.Add(Me.wbShowFile)
        Me.panDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panDocument.Location = New System.Drawing.Point(0, 25)
        Me.panDocument.Name = "panDocument"
        Me.panDocument.Size = New System.Drawing.Size(456, 159)
        Me.panDocument.TabIndex = 162
        Me.panDocument.Visible = False
        '
        'wbShowFile
        '
        Me.wbShowFile.AllowWebBrowserDrop = False
        Me.wbShowFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbShowFile.Location = New System.Drawing.Point(0, 0)
        Me.wbShowFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.wbShowFile.MinimumSize = New System.Drawing.Size(23, 25)
        Me.wbShowFile.Name = "wbShowFile"
        Me.wbShowFile.Size = New System.Drawing.Size(452, 155)
        Me.wbShowFile.TabIndex = 163
        '
        'tsDocumentMenu
        '
        Me.tsDocumentMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDocumentClose})
        Me.tsDocumentMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsDocumentMenu.Name = "tsDocumentMenu"
        Me.tsDocumentMenu.Size = New System.Drawing.Size(456, 25)
        Me.tsDocumentMenu.TabIndex = 151
        Me.tsDocumentMenu.Text = "ToolStrip1"
        '
        'tsbDocumentClose
        '
        Me.tsbDocumentClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDocumentClose.Image = CType(resources.GetObject("tsbDocumentClose.Image"), System.Drawing.Image)
        Me.tsbDocumentClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDocumentClose.Name = "tsbDocumentClose"
        Me.tsbDocumentClose.Size = New System.Drawing.Size(40, 22)
        Me.tsbDocumentClose.Text = "Close"
        '
        'dgvComm
        '
        Me.dgvComm.AllowDrop = True
        Me.dgvComm.AllowUserToAddRows = False
        Me.dgvComm.AllowUserToDeleteRows = False
        Me.dgvComm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComm.ColumnHeadersVisible = False
        Me.dgvComm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComm.Location = New System.Drawing.Point(0, 0)
        Me.dgvComm.MultiSelect = False
        Me.dgvComm.Name = "dgvComm"
        Me.dgvComm.ReadOnly = True
        Me.dgvComm.RowHeadersWidth = 25
        Me.dgvComm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComm.Size = New System.Drawing.Size(500, 206)
        Me.dgvComm.TabIndex = 162
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 206)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(500, 22)
        Me.ssStatus.TabIndex = 161
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
        Me.panExtSearch.Location = New System.Drawing.Point(0, 27)
        Me.panExtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panExtSearch.Name = "panExtSearch"
        Me.panExtSearch.Size = New System.Drawing.Size(500, 45)
        Me.panExtSearch.TabIndex = 19
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
        'ucComm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.tsComm)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucComm"
        Me.Size = New System.Drawing.Size(500, 300)
        Me.Tag = "CF-CTL-COM-001"
        Me.tsComm.ResumeLayout(False)
        Me.tsComm.PerformLayout()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        Me.panProgress.ResumeLayout(False)
        Me.panProgress.PerformLayout()
        Me.pnlPreviewDoc.ResumeLayout(False)
        Me.pnlPreviewDoc.PerformLayout()
        Me.panDocument.ResumeLayout(False)
        Me.tsDocumentMenu.ResumeLayout(False)
        Me.tsDocumentMenu.PerformLayout()
        CType(Me.dgvComm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsComm As System.Windows.Forms.ToolStrip
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents lblNbDays As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtLastDays As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlPreviewDoc As System.Windows.Forms.Panel
    Friend WithEvents panDocument As System.Windows.Forms.Panel
    Friend WithEvents wbShowFile As System.Windows.Forms.WebBrowser
    Friend WithEvents tsDocumentMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDocumentClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvComm As System.Windows.Forms.DataGridView
    Friend WithEvents tsbSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslSaveAs As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSave_Doc_Type_ID As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents panProgress As System.Windows.Forms.Panel
    Friend WithEvents txtPBDocument As System.Windows.Forms.TextBox
    Friend WithEvents txtPBEvent As System.Windows.Forms.TextBox
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar

End Class
