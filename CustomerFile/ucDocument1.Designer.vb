﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDocument1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucDocument1))
        Me.cmdShipDateTP = New System.Windows.Forms.Button()
        Me.txtPBEvent = New System.Windows.Forms.TextBox()
        Me.lblHistory = New System.Windows.Forms.Label()
        Me.cmdDateTP = New System.Windows.Forms.Button()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.cmdSearchHistory = New System.Windows.Forms.Button()
        Me.pnlPreviewDoc = New System.Windows.Forms.Panel()
        Me.cmdPreviewClose = New System.Windows.Forms.Button()
        Me.wbShowFile = New System.Windows.Forms.WebBrowser()
        Me.lblPreview = New System.Windows.Forms.Label()
        Me.chkOrderAckSaveOnly = New System.Windows.Forms.CheckBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblHistoryFrom = New System.Windows.Forms.Label()
        Me.chkShowHistory = New System.Windows.Forms.CheckBox()
        Me.cmdNewEmail = New System.Windows.Forms.Button()
        Me.txtPBDocument = New System.Windows.Forms.TextBox()
        Me.cmdDeleteEmail = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOr = New System.Windows.Forms.RadioButton()
        Me.btnAnd = New System.Windows.Forms.RadioButton()
        Me.panProgress = New System.Windows.Forms.Panel()
        Me.cmdShowDeleted = New System.Windows.Forms.CheckBox()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.cmdCopyDoc = New System.Windows.Forms.Button()
        Me.cmdDeleteDoc = New System.Windows.Forms.Button()
        Me.cmdPreviewDoc = New System.Windows.Forms.Button()
        Me.lblSelectedType = New System.Windows.Forms.Label()
        Me.lvTypes = New System.Windows.Forms.ListView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblFiles = New System.Windows.Forms.Label()
        Me.lblHistoryTo = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.pnlHistory = New System.Windows.Forms.Panel()
        Me.txtSearchElements = New System.Windows.Forms.TextBox()
        Me.dgvFileList = New System.Windows.Forms.DataGridView()
        Me.dgvEmails = New System.Windows.Forms.DataGridView()
        Me.pnlPreviewDoc.SuspendLayout()
        Me.panProgress.SuspendLayout()
        Me.pnlHistory.SuspendLayout()
        CType(Me.dgvFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdShipDateTP
        '
        Me.cmdShipDateTP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShipDateTP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShipDateTP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdShipDateTP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShipDateTP.Image = CType(resources.GetObject("cmdShipDateTP.Image"), System.Drawing.Image)
        Me.cmdShipDateTP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdShipDateTP.Location = New System.Drawing.Point(325, 1)
        Me.cmdShipDateTP.Name = "cmdShipDateTP"
        Me.cmdShipDateTP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShipDateTP.Size = New System.Drawing.Size(24, 24)
        Me.cmdShipDateTP.TabIndex = 32
        Me.cmdShipDateTP.TabStop = False
        Me.cmdShipDateTP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdShipDateTP.UseVisualStyleBackColor = False
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
        'lblHistory
        '
        Me.lblHistory.AutoSize = True
        Me.lblHistory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistory.Location = New System.Drawing.Point(6, 5)
        Me.lblHistory.Name = "lblHistory"
        Me.lblHistory.Size = New System.Drawing.Size(49, 16)
        Me.lblHistory.TabIndex = 25
        Me.lblHistory.Text = "History"
        '
        'cmdDateTP
        '
        Me.cmdDateTP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDateTP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDateTP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdDateTP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDateTP.Image = CType(resources.GetObject("cmdDateTP.Image"), System.Drawing.Image)
        Me.cmdDateTP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdDateTP.Location = New System.Drawing.Point(187, 1)
        Me.cmdDateTP.Name = "cmdDateTP"
        Me.cmdDateTP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDateTP.Size = New System.Drawing.Size(24, 24)
        Me.cmdDateTP.TabIndex = 30
        Me.cmdDateTP.TabStop = False
        Me.cmdDateTP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDateTP.UseVisualStyleBackColor = False
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(3, 26)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(301, 23)
        Me.pbProgress.TabIndex = 156
        '
        'cmdSearchHistory
        '
        Me.cmdSearchHistory.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearchHistory.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearchHistory.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdSearchHistory.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearchHistory.Image = CType(resources.GetObject("cmdSearchHistory.Image"), System.Drawing.Image)
        Me.cmdSearchHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSearchHistory.Location = New System.Drawing.Point(384, 268)
        Me.cmdSearchHistory.Name = "cmdSearchHistory"
        Me.cmdSearchHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearchHistory.Size = New System.Drawing.Size(24, 24)
        Me.cmdSearchHistory.TabIndex = 28
        Me.cmdSearchHistory.TabStop = False
        Me.cmdSearchHistory.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSearchHistory.UseVisualStyleBackColor = False
        '
        'pnlPreviewDoc
        '
        Me.pnlPreviewDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreviewDoc.Controls.Add(Me.cmdPreviewClose)
        Me.pnlPreviewDoc.Controls.Add(Me.wbShowFile)
        Me.pnlPreviewDoc.Controls.Add(Me.lblPreview)
        Me.pnlPreviewDoc.Location = New System.Drawing.Point(37, 74)
        Me.pnlPreviewDoc.Name = "pnlPreviewDoc"
        Me.pnlPreviewDoc.Size = New System.Drawing.Size(912, 462)
        Me.pnlPreviewDoc.TabIndex = 178
        Me.pnlPreviewDoc.Visible = False
        '
        'cmdPreviewClose
        '
        Me.cmdPreviewClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreviewClose.Location = New System.Drawing.Point(845, 2)
        Me.cmdPreviewClose.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPreviewClose.Name = "cmdPreviewClose"
        Me.cmdPreviewClose.Size = New System.Drawing.Size(63, 24)
        Me.cmdPreviewClose.TabIndex = 151
        Me.cmdPreviewClose.Text = "Close"
        Me.cmdPreviewClose.UseVisualStyleBackColor = True
        '
        'wbShowFile
        '
        Me.wbShowFile.AllowWebBrowserDrop = False
        Me.wbShowFile.Location = New System.Drawing.Point(3, 28)
        Me.wbShowFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.wbShowFile.MinimumSize = New System.Drawing.Size(23, 25)
        Me.wbShowFile.Name = "wbShowFile"
        Me.wbShowFile.Size = New System.Drawing.Size(909, 432)
        Me.wbShowFile.TabIndex = 150
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreview.Location = New System.Drawing.Point(2, 6)
        Me.lblPreview.Margin = New System.Windows.Forms.Padding(2)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(52, 16)
        Me.lblPreview.TabIndex = 149
        Me.lblPreview.Text = "Preview"
        '
        'chkOrderAckSaveOnly
        '
        Me.chkOrderAckSaveOnly.AutoSize = True
        Me.chkOrderAckSaveOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkOrderAckSaveOnly.Location = New System.Drawing.Point(424, 9)
        Me.chkOrderAckSaveOnly.Name = "chkOrderAckSaveOnly"
        Me.chkOrderAckSaveOnly.Size = New System.Drawing.Size(121, 17)
        Me.chkOrderAckSaveOnly.TabIndex = 177
        Me.chkOrderAckSaveOnly.Text = "Save order ack only"
        Me.chkOrderAckSaveOnly.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.Location = New System.Drawing.Point(132, 273)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(49, 16)
        Me.lblSearch.TabIndex = 27
        Me.lblSearch.Text = "Search"
        '
        'lblHistoryFrom
        '
        Me.lblHistoryFrom.AutoSize = True
        Me.lblHistoryFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryFrom.Location = New System.Drawing.Point(61, 5)
        Me.lblHistoryFrom.Name = "lblHistoryFrom"
        Me.lblHistoryFrom.Size = New System.Drawing.Size(38, 16)
        Me.lblHistoryFrom.TabIndex = 33
        Me.lblHistoryFrom.Text = "From"
        '
        'chkShowHistory
        '
        Me.chkShowHistory.AutoSize = True
        Me.chkShowHistory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowHistory.Location = New System.Drawing.Point(441, 277)
        Me.chkShowHistory.Name = "chkShowHistory"
        Me.chkShowHistory.Size = New System.Drawing.Size(104, 20)
        Me.chkShowHistory.TabIndex = 182
        Me.chkShowHistory.Text = "Show History"
        Me.chkShowHistory.UseVisualStyleBackColor = True
        '
        'cmdNewEmail
        '
        Me.cmdNewEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewEmail.Location = New System.Drawing.Point(80, 274)
        Me.cmdNewEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdNewEmail.Name = "cmdNewEmail"
        Me.cmdNewEmail.Size = New System.Drawing.Size(60, 24)
        Me.cmdNewEmail.TabIndex = 180
        Me.cmdNewEmail.Text = "New"
        Me.cmdNewEmail.UseVisualStyleBackColor = True
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
        'cmdDeleteEmail
        '
        Me.cmdDeleteEmail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteEmail.Location = New System.Drawing.Point(146, 274)
        Me.cmdDeleteEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdDeleteEmail.Name = "cmdDeleteEmail"
        Me.cmdDeleteEmail.Size = New System.Drawing.Size(60, 24)
        Me.cmdDeleteEmail.TabIndex = 181
        Me.cmdDeleteEmail.Text = "Delete"
        Me.cmdDeleteEmail.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 400
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(6, 278)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(48, 16)
        Me.lblEmail.TabIndex = 179
        Me.lblEmail.Text = "Emails"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 400
        '
        'btnOr
        '
        Me.btnOr.AutoSize = True
        Me.btnOr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOr.Location = New System.Drawing.Point(333, 263)
        Me.btnOr.Name = "btnOr"
        Me.btnOr.Size = New System.Drawing.Size(37, 18)
        Me.btnOr.TabIndex = 35
        Me.btnOr.TabStop = True
        Me.btnOr.Text = "Or"
        Me.btnOr.UseVisualStyleBackColor = True
        '
        'btnAnd
        '
        Me.btnAnd.AutoSize = True
        Me.btnAnd.Checked = True
        Me.btnAnd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnd.Location = New System.Drawing.Point(333, 279)
        Me.btnAnd.Name = "btnAnd"
        Me.btnAnd.Size = New System.Drawing.Size(45, 18)
        Me.btnAnd.TabIndex = 34
        Me.btnAnd.TabStop = True
        Me.btnAnd.Text = "And"
        Me.btnAnd.UseVisualStyleBackColor = True
        '
        'panProgress
        '
        Me.panProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panProgress.Controls.Add(Me.txtPBDocument)
        Me.panProgress.Controls.Add(Me.txtPBEvent)
        Me.panProgress.Controls.Add(Me.pbProgress)
        Me.panProgress.Location = New System.Drawing.Point(353, 123)
        Me.panProgress.Name = "panProgress"
        Me.panProgress.Size = New System.Drawing.Size(311, 141)
        Me.panProgress.TabIndex = 176
        Me.panProgress.Visible = False
        '
        'cmdShowDeleted
        '
        Me.cmdShowDeleted.AutoSize = True
        Me.cmdShowDeleted.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowDeleted.Location = New System.Drawing.Point(212, 277)
        Me.cmdShowDeleted.Name = "cmdShowDeleted"
        Me.cmdShowDeleted.Size = New System.Drawing.Size(107, 20)
        Me.cmdShowDeleted.TabIndex = 183
        Me.cmdShowDeleted.Text = "Show Deleted"
        Me.cmdShowDeleted.UseVisualStyleBackColor = True
        Me.cmdShowDeleted.Visible = False
        '
        'mcCalendar
        '
        Me.mcCalendar.Cursor = System.Windows.Forms.Cursors.Default
        Me.mcCalendar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mcCalendar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.mcCalendar.Location = New System.Drawing.Point(18, 351)
        Me.mcCalendar.MaxSelectionCount = 1
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 175
        Me.mcCalendar.Visible = False
        '
        'cmdCopyDoc
        '
        Me.cmdCopyDoc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopyDoc.Location = New System.Drawing.Point(324, 5)
        Me.cmdCopyDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCopyDoc.Name = "cmdCopyDoc"
        Me.cmdCopyDoc.Size = New System.Drawing.Size(60, 24)
        Me.cmdCopyDoc.TabIndex = 172
        Me.cmdCopyDoc.Text = "Copy"
        Me.cmdCopyDoc.UseVisualStyleBackColor = True
        Me.cmdCopyDoc.Visible = False
        '
        'cmdDeleteDoc
        '
        Me.cmdDeleteDoc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteDoc.Location = New System.Drawing.Point(58, 5)
        Me.cmdDeleteDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdDeleteDoc.Name = "cmdDeleteDoc"
        Me.cmdDeleteDoc.Size = New System.Drawing.Size(60, 24)
        Me.cmdDeleteDoc.TabIndex = 173
        Me.cmdDeleteDoc.Text = "Delete"
        Me.cmdDeleteDoc.UseVisualStyleBackColor = True
        '
        'cmdPreviewDoc
        '
        Me.cmdPreviewDoc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreviewDoc.Location = New System.Drawing.Point(124, 5)
        Me.cmdPreviewDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdPreviewDoc.Name = "cmdPreviewDoc"
        Me.cmdPreviewDoc.Size = New System.Drawing.Size(60, 24)
        Me.cmdPreviewDoc.TabIndex = 171
        Me.cmdPreviewDoc.Text = "Preview"
        Me.cmdPreviewDoc.UseVisualStyleBackColor = True
        '
        'lblSelectedType
        '
        Me.lblSelectedType.AutoSize = True
        Me.lblSelectedType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedType.Location = New System.Drawing.Point(203, 9)
        Me.lblSelectedType.Name = "lblSelectedType"
        Me.lblSelectedType.Size = New System.Drawing.Size(12, 16)
        Me.lblSelectedType.TabIndex = 170
        Me.lblSelectedType.Text = " "
        '
        'lvTypes
        '
        Me.lvTypes.AllowDrop = True
        Me.lvTypes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTypes.FullRowSelect = True
        Me.lvTypes.HideSelection = False
        Me.lvTypes.HoverSelection = True
        Me.lvTypes.Location = New System.Drawing.Point(6, 31)
        Me.lvTypes.MultiSelect = False
        Me.lvTypes.Name = "lvTypes"
        Me.lvTypes.Size = New System.Drawing.Size(160, 234)
        Me.lvTypes.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvTypes.TabIndex = 168
        Me.lvTypes.UseCompatibleStateImageBehavior = False
        Me.lvTypes.View = System.Windows.Forms.View.Details
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 400
        '
        'lblFiles
        '
        Me.lblFiles.AutoSize = True
        Me.lblFiles.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiles.Location = New System.Drawing.Point(169, 9)
        Me.lblFiles.Name = "lblFiles"
        Me.lblFiles.Size = New System.Drawing.Size(36, 16)
        Me.lblFiles.TabIndex = 169
        Me.lblFiles.Text = "Files"
        Me.lblFiles.Visible = False
        '
        'lblHistoryTo
        '
        Me.lblHistoryTo.AutoSize = True
        Me.lblHistoryTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryTo.Location = New System.Drawing.Point(217, 5)
        Me.lblHistoryTo.Name = "lblHistoryTo"
        Me.lblHistoryTo.Size = New System.Drawing.Size(22, 16)
        Me.lblHistoryTo.TabIndex = 26
        Me.lblHistoryTo.Text = "To"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(3, 9)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(36, 16)
        Me.lblType.TabIndex = 167
        Me.lblType.Text = "Type"
        '
        'pnlHistory
        '
        Me.pnlHistory.Controls.Add(Me.lblHistory)
        Me.pnlHistory.Controls.Add(Me.btnOr)
        Me.pnlHistory.Controls.Add(Me.btnAnd)
        Me.pnlHistory.Controls.Add(Me.lblHistoryFrom)
        Me.pnlHistory.Controls.Add(Me.cmdShipDateTP)
        Me.pnlHistory.Controls.Add(Me.cmdDateTP)
        Me.pnlHistory.Controls.Add(Me.cmdSearchHistory)
        Me.pnlHistory.Controls.Add(Me.lblSearch)
        Me.pnlHistory.Controls.Add(Me.lblHistoryTo)
        Me.pnlHistory.Controls.Add(Me.txtSearchElements)
        Me.pnlHistory.Location = New System.Drawing.Point(571, 4)
        Me.pnlHistory.Name = "pnlHistory"
        Me.pnlHistory.Size = New System.Drawing.Size(410, 298)
        Me.pnlHistory.TabIndex = 174
        Me.pnlHistory.Visible = False
        '
        'txtSearchElements
        '
        Me.txtSearchElements.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchElements.Location = New System.Drawing.Point(187, 269)
        Me.txtSearchElements.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearchElements.Multiline = True
        Me.txtSearchElements.Name = "txtSearchElements"
        Me.txtSearchElements.Size = New System.Drawing.Size(140, 21)
        Me.txtSearchElements.TabIndex = 24
        '
        'dgvFileList
        '
        Me.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFileList.Location = New System.Drawing.Point(172, 31)
        Me.dgvFileList.Name = "dgvFileList"
        Me.dgvFileList.Size = New System.Drawing.Size(803, 240)
        Me.dgvFileList.TabIndex = 184
        '
        'dgvEmails
        '
        Me.dgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmails.Location = New System.Drawing.Point(3, 303)
        Me.dgvEmails.Name = "dgvEmails"
        Me.dgvEmails.Size = New System.Drawing.Size(972, 237)
        Me.dgvEmails.TabIndex = 185
        '
        'ucDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlPreviewDoc)
        Me.Controls.Add(Me.mcCalendar)
        Me.Controls.Add(Me.dgvFileList)
        Me.Controls.Add(Me.chkOrderAckSaveOnly)
        Me.Controls.Add(Me.chkShowHistory)
        Me.Controls.Add(Me.cmdNewEmail)
        Me.Controls.Add(Me.cmdDeleteEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.panProgress)
        Me.Controls.Add(Me.cmdShowDeleted)
        Me.Controls.Add(Me.cmdCopyDoc)
        Me.Controls.Add(Me.cmdDeleteDoc)
        Me.Controls.Add(Me.cmdPreviewDoc)
        Me.Controls.Add(Me.lblSelectedType)
        Me.Controls.Add(Me.lvTypes)
        Me.Controls.Add(Me.lblFiles)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.pnlHistory)
        Me.Controls.Add(Me.dgvEmails)
        Me.Name = "ucDocument"
        Me.Size = New System.Drawing.Size(980, 555)
        Me.pnlPreviewDoc.ResumeLayout(False)
        Me.pnlPreviewDoc.PerformLayout()
        Me.panProgress.ResumeLayout(False)
        Me.panProgress.PerformLayout()
        Me.pnlHistory.ResumeLayout(False)
        Me.pnlHistory.PerformLayout()
        CType(Me.dgvFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShipDateTP As System.Windows.Forms.Button
    Friend WithEvents txtPBEvent As System.Windows.Forms.TextBox
    Friend WithEvents lblHistory As System.Windows.Forms.Label
    Friend WithEvents cmdDateTP As System.Windows.Forms.Button
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdSearchHistory As System.Windows.Forms.Button
    Friend WithEvents pnlPreviewDoc As System.Windows.Forms.Panel
    Friend WithEvents cmdPreviewClose As System.Windows.Forms.Button
    Friend WithEvents wbShowFile As System.Windows.Forms.WebBrowser
    Friend WithEvents lblPreview As System.Windows.Forms.Label
    Friend WithEvents chkOrderAckSaveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblHistoryFrom As System.Windows.Forms.Label
    Friend WithEvents chkShowHistory As System.Windows.Forms.CheckBox
    Friend WithEvents cmdNewEmail As System.Windows.Forms.Button
    Friend WithEvents txtPBDocument As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeleteEmail As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnOr As System.Windows.Forms.RadioButton
    Friend WithEvents btnAnd As System.Windows.Forms.RadioButton
    Friend WithEvents panProgress As System.Windows.Forms.Panel
    Friend WithEvents cmdShowDeleted As System.Windows.Forms.CheckBox
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents cmdCopyDoc As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteDoc As System.Windows.Forms.Button
    Friend WithEvents cmdPreviewDoc As System.Windows.Forms.Button
    Friend WithEvents lblSelectedType As System.Windows.Forms.Label
    Friend WithEvents lvTypes As System.Windows.Forms.ListView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFiles As System.Windows.Forms.Label
    Friend WithEvents lblHistoryTo As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents pnlHistory As System.Windows.Forms.Panel
    Friend WithEvents txtSearchElements As System.Windows.Forms.TextBox
    Friend WithEvents dgvFileList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEmails As System.Windows.Forms.DataGridView

End Class
