<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickProgram
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuickProgram))
        Me.cmdEnd_Dt = New System.Windows.Forms.Button()
        Me.cmdStart_Dt = New System.Windows.Forms.Button()
        Me.cboProg_Type = New System.Windows.Forms.ComboBox()
        Me.tsProgramMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsRenew = New System.Windows.Forms.ToolStripButton()
        Me.tsConfirm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNextStep = New System.Windows.Forms.ToolStripButton()
        Me.tsbCreateRevision = New System.Windows.Forms.ToolStripButton()
        Me.tsbExport = New System.Windows.Forms.ToolStripButton()
        Me.tsbClientEmail = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportForm = New System.Windows.Forms.ToolStripButton()
        Me.lblProgram_No = New System.Windows.Forms.Label()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tsItemMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMassInsert = New System.Windows.Forms.ToolStripButton()
        Me.btnCustomizedPack = New System.Windows.Forms.ToolStripButton()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.gbProgramItems = New System.Windows.Forms.GroupBox()
        Me.btnChk = New System.Windows.Forms.Button()
        Me.panItems = New System.Windows.Forms.Panel()
        Me.panProgress = New System.Windows.Forms.Panel()
        Me.txtPBDocument = New System.Windows.Forms.TextBox()
        Me.txtPBEvent = New System.Windows.Forms.TextBox()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.chkAllGroup = New System.Windows.Forms.CheckBox()
        Me.lblEnd_Dt = New System.Windows.Forms.Label()
        Me.lblStart_Dt = New System.Windows.Forms.Label()
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.gbProgramHeader = New System.Windows.Forms.GroupBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.btnNote = New System.Windows.Forms.Button()
        Me.lblRenewProgram = New System.Windows.Forms.Label()
        Me.lblCommOrdClosed = New System.Windows.Forms.Label()
        Me.txtCommentQuoteResult = New System.Windows.Forms.TextBox()
        Me.lblQuoteResult = New System.Windows.Forms.Label()
        Me.cboQuoteResult = New System.Windows.Forms.ComboBox()
        Me.cboStatusQuote = New System.Windows.Forms.ComboBox()
        Me.lblDecision_Dt = New System.Windows.Forms.Label()
        Me.lblStatusQuote = New System.Windows.Forms.Label()
        Me.gbSaveProgress = New System.Windows.Forms.GroupBox()
        Me.lblSave_Item_No = New System.Windows.Forms.Label()
        Me.lblSave_Line_No = New System.Windows.Forms.Label()
        Me.pbSave_Item_No = New System.Windows.Forms.ProgressBar()
        Me.lblSave_Cus_No = New System.Windows.Forms.Label()
        Me.pbSave_Line_No = New System.Windows.Forms.ProgressBar()
        Me.pbSave_Cus_No = New System.Windows.Forms.ProgressBar()
        Me.chkOne_Shot = New System.Windows.Forms.CheckBox()
        Me.chkSent_To_Customer = New System.Windows.Forms.CheckBox()
        Me.lblCurrent_Rev_No = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblOrd_No = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.cmdQuoteComments = New System.Windows.Forms.Button()
        Me.btnShowAdminFields = New System.Windows.Forms.Button()
        Me.lblProg_Comments = New System.Windows.Forms.Label()
        Me.cboContact_ID = New System.Windows.Forms.ComboBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblImprint = New System.Windows.Forms.Label()
        Me.lblProg_Cd = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lblQuote_Step_User = New System.Windows.Forms.Label()
        Me.gbQuoteSteps = New System.Windows.Forms.GroupBox()
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.lblQuote_Step_ID = New System.Windows.Forms.Label()
        Me.ssStatusBar = New System.Windows.Forms.StatusStrip()
        Me.tsslCreate_By = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCreate_TS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUser_Login = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUpdate_TS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tcOptions = New System.Windows.Forms.TabControl()
        Me.tcpOptions = New System.Windows.Forms.TabPage()
        Me.panOptions = New System.Windows.Forms.Panel()
        Me.dgvOptions = New System.Windows.Forms.DataGridView()
        Me.tsOptions = New System.Windows.Forms.ToolStrip()
        Me.tsbOptionsWaiveAll = New System.Windows.Forms.ToolStripButton()
        Me.tsbOptionsResetAll = New System.Windows.Forms.ToolStripButton()
        Me.tcpSetUps = New System.Windows.Forms.TabPage()
        Me.panSetUps = New System.Windows.Forms.Panel()
        Me.dgvSetUps = New System.Windows.Forms.DataGridView()
        Me.tsSetUps = New System.Windows.Forms.ToolStrip()
        Me.tsbSetUpsWaiveAll = New System.Windows.Forms.ToolStripButton()
        Me.tsbSetUpsResetAll = New System.Windows.Forms.ToolStripButton()
        Me.tcpDocuments = New System.Windows.Forms.TabPage()
        Me.menuCopyRow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAndPasteThisItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.pictLoadImage = New System.Windows.Forms.PictureBox()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.txtProg_CSR = New CustomerFile.xTextBox()
        Me.txtQuote_Step_User = New CustomerFile.xTextBox()
        Me.txtQuote_Step_ID = New CustomerFile.xTextBox()
        Me.UcDocuments = New CustomerFile.ucDocument()
        Me.txtEndDecision_Dt = New CustomerFile.xTextBox()
        Me.txtDecision_Dt = New CustomerFile.xTextBox()
        Me.txtCurrent_Rev_No = New CustomerFile.xTextBox()
        Me.txtOrd_No = New CustomerFile.xTextBox()
        Me.txtCurr_Cd = New CustomerFile.xTextBox()
        Me.txtProg_Comments = New CustomerFile.xTextBox()
        Me.txtImprint = New CustomerFile.xTextBox()
        Me.txtSpector_Cd = New CustomerFile.xTextBox()
        Me.txtEnd_Dt = New CustomerFile.xTextBox()
        Me.txtStart_Dt = New CustomerFile.xTextBox()
        Me.txtProg_Cd = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.tsProgramMenu.SuspendLayout()
        Me.tsItemMenu.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProgramItems.SuspendLayout()
        Me.panItems.SuspendLayout()
        Me.panProgress.SuspendLayout()
        Me.gbProgramHeader.SuspendLayout()
        Me.gbSaveProgress.SuspendLayout()
        Me.gbQuoteSteps.SuspendLayout()
        Me.gbOptions.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ssStatusBar.SuspendLayout()
        Me.tcOptions.SuspendLayout()
        Me.tcpOptions.SuspendLayout()
        Me.panOptions.SuspendLayout()
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsOptions.SuspendLayout()
        Me.tcpSetUps.SuspendLayout()
        Me.panSetUps.SuspendLayout()
        CType(Me.dgvSetUps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSetUps.SuspendLayout()
        Me.tcpDocuments.SuspendLayout()
        Me.menuCopyRow.SuspendLayout()
        CType(Me.pictLoadImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdEnd_Dt
        '
        Me.cmdEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnd_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnd_Dt.Image = CType(resources.GetObject("cmdEnd_Dt.Image"), System.Drawing.Image)
        Me.cmdEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdEnd_Dt.Location = New System.Drawing.Point(449, 100)
        Me.cmdEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdEnd_Dt.Name = "cmdEnd_Dt"
        Me.cmdEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnd_Dt.Size = New System.Drawing.Size(21, 22)
        Me.cmdEnd_Dt.TabIndex = 20
        Me.cmdEnd_Dt.TabStop = False
        Me.cmdEnd_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEnd_Dt.UseVisualStyleBackColor = False
        '
        'cmdStart_Dt
        '
        Me.cmdStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart_Dt.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart_Dt.Image = CType(resources.GetObject("cmdStart_Dt.Image"), System.Drawing.Image)
        Me.cmdStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStart_Dt.Location = New System.Drawing.Point(209, 100)
        Me.cmdStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdStart_Dt.Name = "cmdStart_Dt"
        Me.cmdStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart_Dt.Size = New System.Drawing.Size(21, 22)
        Me.cmdStart_Dt.TabIndex = 17
        Me.cmdStart_Dt.TabStop = False
        Me.cmdStart_Dt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStart_Dt.UseVisualStyleBackColor = False
        '
        'cboProg_Type
        '
        Me.cboProg_Type.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProg_Type.FormattingEnabled = True
        Me.cboProg_Type.Items.AddRange(New Object() {"Program", "Special Price List", "Quote"})
        Me.cboProg_Type.Location = New System.Drawing.Point(295, 15)
        Me.cboProg_Type.Margin = New System.Windows.Forms.Padding(1)
        Me.cboProg_Type.Name = "cboProg_Type"
        Me.cboProg_Type.Size = New System.Drawing.Size(32, 23)
        Me.cboProg_Type.TabIndex = 4
        Me.cboProg_Type.Visible = False
        '
        'tsProgramMenu
        '
        Me.tsProgramMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsProgramMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsRenew, Me.tsConfirm, Me.tsbNextStep, Me.tsbCreateRevision, Me.tsbExport, Me.tsbClientEmail, Me.tsbExportForm, Me.ToolStripSeparator2})
        Me.tsProgramMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsProgramMenu.Name = "tsProgramMenu"
        Me.tsProgramMenu.Size = New System.Drawing.Size(1068, 25)
        Me.tsProgramMenu.TabIndex = 0
        Me.tsProgramMenu.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSave.Enabled = False
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(35, 22)
        Me.tsbSave.Text = "Save"
        '
        'tsRenew
        '
        Me.tsRenew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRenew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRenew.Image = CType(resources.GetObject("tsRenew.Image"), System.Drawing.Image)
        Me.tsRenew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRenew.Name = "tsRenew"
        Me.tsRenew.Size = New System.Drawing.Size(98, 22)
        Me.tsRenew.Text = "Update Program"
        Me.tsRenew.Visible = False
        '
        'tsConfirm
        '
        Me.tsConfirm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsConfirm.Image = CType(resources.GetObject("tsConfirm.Image"), System.Drawing.Image)
        Me.tsConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsConfirm.Name = "tsConfirm"
        Me.tsConfirm.Size = New System.Drawing.Size(104, 22)
        Me.tsConfirm.Text = "Confirm Program"
        Me.tsConfirm.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNextStep
        '
        Me.tsbNextStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNextStep.Enabled = False
        Me.tsbNextStep.Image = CType(resources.GetObject("tsbNextStep.Image"), System.Drawing.Image)
        Me.tsbNextStep.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNextStep.Name = "tsbNextStep"
        Me.tsbNextStep.Size = New System.Drawing.Size(93, 22)
        Me.tsbNextStep.Text = "Request Pricing"
        '
        'tsbCreateRevision
        '
        Me.tsbCreateRevision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCreateRevision.Image = CType(resources.GetObject("tsbCreateRevision.Image"), System.Drawing.Image)
        Me.tsbCreateRevision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCreateRevision.Name = "tsbCreateRevision"
        Me.tsbCreateRevision.Size = New System.Drawing.Size(92, 22)
        Me.tsbCreateRevision.Text = "Create Revision"
        Me.tsbCreateRevision.Visible = False
        '
        'tsbExport
        '
        Me.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport.Enabled = False
        Me.tsbExport.Image = CType(resources.GetObject("tsbExport.Image"), System.Drawing.Image)
        Me.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport.Name = "tsbExport"
        Me.tsbExport.Size = New System.Drawing.Size(44, 22)
        Me.tsbExport.Text = "Export"
        Me.tsbExport.Visible = False
        '
        'tsbClientEmail
        '
        Me.tsbClientEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClientEmail.Image = CType(resources.GetObject("tsbClientEmail.Image"), System.Drawing.Image)
        Me.tsbClientEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClientEmail.Name = "tsbClientEmail"
        Me.tsbClientEmail.Size = New System.Drawing.Size(137, 22)
        Me.tsbClientEmail.Text = "Send Email to the Client"
        Me.tsbClientEmail.Visible = False
        '
        'tsbExportForm
        '
        Me.tsbExportForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExportForm.Image = CType(resources.GetObject("tsbExportForm.Image"), System.Drawing.Image)
        Me.tsbExportForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbExportForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportForm.Name = "tsbExportForm"
        Me.tsbExportForm.Size = New System.Drawing.Size(68, 22)
        Me.tsbExportForm.Text = "NewExport"
        '
        'lblProgram_No
        '
        Me.lblProgram_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblProgram_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgram_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgram_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProgram_No.Location = New System.Drawing.Point(222, 18)
        Me.lblProgram_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProgram_No.Name = "lblProgram_No"
        Me.lblProgram_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProgram_No.Size = New System.Drawing.Size(105, 22)
        Me.lblProgram_No.TabIndex = 3
        Me.lblProgram_No.Text = "Spec Price No"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(35, 22)
        Me.tsbNew.Text = "New"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
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
        'tsItemMenu
        '
        Me.tsItemMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsItemMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbDelete, Me.tsbOpen, Me.tsbRefresh, Me.ToolStripSeparator1, Me.tsbMassInsert, Me.btnCustomizedPack})
        Me.tsItemMenu.Location = New System.Drawing.Point(3, 17)
        Me.tsItemMenu.Name = "tsItemMenu"
        Me.tsItemMenu.Size = New System.Drawing.Size(1040, 25)
        Me.tsItemMenu.TabIndex = 1
        Me.tsItemMenu.Text = "ToolStrip2"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(40, 22)
        Me.tsbOpen.Text = "Open"
        Me.tsbOpen.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMassInsert
        '
        Me.tsbMassInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbMassInsert.Image = CType(resources.GetObject("tsbMassInsert.Image"), System.Drawing.Image)
        Me.tsbMassInsert.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMassInsert.Name = "tsbMassInsert"
        Me.tsbMassInsert.Size = New System.Drawing.Size(70, 22)
        Me.tsbMassInsert.Text = "Mass Insert"
        '
        'btnCustomizedPack
        '
        Me.btnCustomizedPack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnCustomizedPack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCustomizedPack.Image = CType(resources.GetObject("btnCustomizedPack.Image"), System.Drawing.Image)
        Me.btnCustomizedPack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCustomizedPack.Name = "btnCustomizedPack"
        Me.btnCustomizedPack.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCustomizedPack.Size = New System.Drawing.Size(132, 22)
        Me.btnCustomizedPack.Text = "Customized Packaging"
        '
        'dgvItems
        '
        Me.dgvItems.AllowDrop = True
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvItems.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvItems.MultiSelect = False
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.Size = New System.Drawing.Size(1040, 249)
        Me.dgvItems.TabIndex = 0
        '
        'gbProgramItems
        '
        Me.gbProgramItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProgramItems.Controls.Add(Me.btnChk)
        Me.gbProgramItems.Controls.Add(Me.panItems)
        Me.gbProgramItems.Controls.Add(Me.tsItemMenu)
        Me.gbProgramItems.Location = New System.Drawing.Point(10, 299)
        Me.gbProgramItems.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramItems.Name = "gbProgramItems"
        Me.gbProgramItems.Size = New System.Drawing.Size(1046, 294)
        Me.gbProgramItems.TabIndex = 2
        Me.gbProgramItems.TabStop = False
        Me.gbProgramItems.Text = "Items"
        '
        'btnChk
        '
        Me.btnChk.Location = New System.Drawing.Point(381, 15)
        Me.btnChk.Name = "btnChk"
        Me.btnChk.Size = New System.Drawing.Size(75, 23)
        Me.btnChk.TabIndex = 41
        Me.btnChk.Text = "Group ChkBox"
        Me.btnChk.UseVisualStyleBackColor = True
        Me.btnChk.Visible = False
        '
        'panItems
        '
        Me.panItems.Controls.Add(Me.panProgress)
        Me.panItems.Controls.Add(Me.dgvItems)
        Me.panItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panItems.Location = New System.Drawing.Point(3, 42)
        Me.panItems.Margin = New System.Windows.Forms.Padding(1)
        Me.panItems.Name = "panItems"
        Me.panItems.Size = New System.Drawing.Size(1040, 249)
        Me.panItems.TabIndex = 37
        '
        'panProgress
        '
        Me.panProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panProgress.Controls.Add(Me.txtPBDocument)
        Me.panProgress.Controls.Add(Me.txtPBEvent)
        Me.panProgress.Controls.Add(Me.pbProgress)
        Me.panProgress.Location = New System.Drawing.Point(365, 51)
        Me.panProgress.Name = "panProgress"
        Me.panProgress.Size = New System.Drawing.Size(311, 141)
        Me.panProgress.TabIndex = 158
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
        'chkAllGroup
        '
        Me.chkAllGroup.AutoSize = True
        Me.chkAllGroup.Location = New System.Drawing.Point(635, 4)
        Me.chkAllGroup.Name = "chkAllGroup"
        Me.chkAllGroup.Size = New System.Drawing.Size(195, 19)
        Me.chkAllGroup.TabIndex = 38
        Me.chkAllGroup.Text = "Update Buying Group Accounts"
        Me.chkAllGroup.UseVisualStyleBackColor = True
        Me.chkAllGroup.Visible = False
        '
        'lblEnd_Dt
        '
        Me.lblEnd_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnd_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnd_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnd_Dt.Location = New System.Drawing.Point(244, 103)
        Me.lblEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnd_Dt.Name = "lblEnd_Dt"
        Me.lblEnd_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnd_Dt.Size = New System.Drawing.Size(105, 22)
        Me.lblEnd_Dt.TabIndex = 18
        Me.lblEnd_Dt.Text = "End Date"
        '
        'lblStart_Dt
        '
        Me.lblStart_Dt.BackColor = System.Drawing.SystemColors.Control
        Me.lblStart_Dt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart_Dt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStart_Dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStart_Dt.Location = New System.Drawing.Point(5, 103)
        Me.lblStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStart_Dt.Name = "lblStart_Dt"
        Me.lblStart_Dt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStart_Dt.Size = New System.Drawing.Size(105, 22)
        Me.lblStart_Dt.TabIndex = 15
        Me.lblStart_Dt.Text = "Start Date"
        '
        'lblCus_No
        '
        Me.lblCus_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCus_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCus_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCus_No.Location = New System.Drawing.Point(8, 18)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCus_No.Size = New System.Drawing.Size(102, 22)
        Me.lblCus_No.TabIndex = 1
        Me.lblCus_No.Text = "Customer"
        '
        'gbProgramHeader
        '
        Me.gbProgramHeader.Controls.Add(Me.txtNote)
        Me.gbProgramHeader.Controls.Add(Me.btnNote)
        Me.gbProgramHeader.Controls.Add(Me.lblRenewProgram)
        Me.gbProgramHeader.Controls.Add(Me.txtEndDecision_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblCommOrdClosed)
        Me.gbProgramHeader.Controls.Add(Me.txtCommentQuoteResult)
        Me.gbProgramHeader.Controls.Add(Me.lblQuoteResult)
        Me.gbProgramHeader.Controls.Add(Me.cboQuoteResult)
        Me.gbProgramHeader.Controls.Add(Me.cboStatusQuote)
        Me.gbProgramHeader.Controls.Add(Me.txtDecision_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblDecision_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblStatusQuote)
        Me.gbProgramHeader.Controls.Add(Me.gbSaveProgress)
        Me.gbProgramHeader.Controls.Add(Me.chkOne_Shot)
        Me.gbProgramHeader.Controls.Add(Me.chkSent_To_Customer)
        Me.gbProgramHeader.Controls.Add(Me.lblCurrent_Rev_No)
        Me.gbProgramHeader.Controls.Add(Me.txtCurrent_Rev_No)
        Me.gbProgramHeader.Controls.Add(Me.Button1)
        Me.gbProgramHeader.Controls.Add(Me.txtOrd_No)
        Me.gbProgramHeader.Controls.Add(Me.lblOrd_No)
        Me.gbProgramHeader.Controls.Add(Me.btn1)
        Me.gbProgramHeader.Controls.Add(Me.cmdQuoteComments)
        Me.gbProgramHeader.Controls.Add(Me.txtCurr_Cd)
        Me.gbProgramHeader.Controls.Add(Me.btnShowAdminFields)
        Me.gbProgramHeader.Controls.Add(Me.lblProg_Comments)
        Me.gbProgramHeader.Controls.Add(Me.txtProg_Comments)
        Me.gbProgramHeader.Controls.Add(Me.cboContact_ID)
        Me.gbProgramHeader.Controls.Add(Me.lblContact)
        Me.gbProgramHeader.Controls.Add(Me.txtImprint)
        Me.gbProgramHeader.Controls.Add(Me.lblImprint)
        Me.gbProgramHeader.Controls.Add(Me.txtSpector_Cd)
        Me.gbProgramHeader.Controls.Add(Me.lblProg_Cd)
        Me.gbProgramHeader.Controls.Add(Me.cmdEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.cmdStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.cboProg_Type)
        Me.gbProgramHeader.Controls.Add(Me.txtProg_Cd)
        Me.gbProgramHeader.Controls.Add(Me.lblProgram_No)
        Me.gbProgramHeader.Controls.Add(Me.lblEnd_Dt)
        Me.gbProgramHeader.Controls.Add(Me.lblStart_Dt)
        Me.gbProgramHeader.Controls.Add(Me.txtCus_No)
        Me.gbProgramHeader.Controls.Add(Me.lblCus_No)
        Me.gbProgramHeader.Controls.Add(Me.ShapeContainer1)
        Me.gbProgramHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgramHeader.Location = New System.Drawing.Point(10, 33)
        Me.gbProgramHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Name = "gbProgramHeader"
        Me.gbProgramHeader.Padding = New System.Windows.Forms.Padding(1)
        Me.gbProgramHeader.Size = New System.Drawing.Size(476, 264)
        Me.gbProgramHeader.TabIndex = 1
        Me.gbProgramHeader.TabStop = False
        Me.gbProgramHeader.Text = "Program Basics"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(75, 237)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(100, 20)
        Me.txtNote.TabIndex = 164
        Me.txtNote.Visible = False
        '
        'btnNote
        '
        Me.btnNote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNote.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNote.ForeColor = System.Drawing.SystemColors.Window
        Me.btnNote.Location = New System.Drawing.Point(11, 235)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(53, 23)
        Me.btnNote.TabIndex = 163
        Me.btnNote.Text = "Note"
        Me.btnNote.UseVisualStyleBackColor = False
        '
        'lblRenewProgram
        '
        Me.lblRenewProgram.AutoSize = True
        Me.lblRenewProgram.Location = New System.Drawing.Point(239, 0)
        Me.lblRenewProgram.Name = "lblRenewProgram"
        Me.lblRenewProgram.Size = New System.Drawing.Size(114, 15)
        Me.lblRenewProgram.TabIndex = 162
        Me.lblRenewProgram.Text = "Was updated from :"
        Me.lblRenewProgram.Visible = False
        '
        'lblCommOrdClosed
        '
        Me.lblCommOrdClosed.AutoSize = True
        Me.lblCommOrdClosed.Location = New System.Drawing.Point(244, 203)
        Me.lblCommOrdClosed.Name = "lblCommOrdClosed"
        Me.lblCommOrdClosed.Size = New System.Drawing.Size(200, 15)
        Me.lblCommOrdClosed.TabIndex = 58
        Me.lblCommOrdClosed.Text = "Feedback from Client on the Quote."
        Me.lblCommOrdClosed.Visible = False
        '
        'txtCommentQuoteResult
        '
        Me.txtCommentQuoteResult.Location = New System.Drawing.Point(247, 220)
        Me.txtCommentQuoteResult.Multiline = True
        Me.txtCommentQuoteResult.Name = "txtCommentQuoteResult"
        Me.txtCommentQuoteResult.Size = New System.Drawing.Size(223, 38)
        Me.txtCommentQuoteResult.TabIndex = 57
        Me.txtCommentQuoteResult.Visible = False
        '
        'lblQuoteResult
        '
        Me.lblQuoteResult.AutoSize = True
        Me.lblQuoteResult.Location = New System.Drawing.Point(5, 216)
        Me.lblQuoteResult.Name = "lblQuoteResult"
        Me.lblQuoteResult.Size = New System.Drawing.Size(79, 15)
        Me.lblQuoteResult.TabIndex = 52
        Me.lblQuoteResult.Text = "Quote Result"
        Me.lblQuoteResult.Visible = False
        '
        'cboQuoteResult
        '
        Me.cboQuoteResult.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQuoteResult.FormattingEnabled = True
        Me.cboQuoteResult.Location = New System.Drawing.Point(90, 210)
        Me.cboQuoteResult.Name = "cboQuoteResult"
        Me.cboQuoteResult.Size = New System.Drawing.Size(141, 22)
        Me.cboQuoteResult.TabIndex = 53
        Me.cboQuoteResult.Visible = False
        '
        'cboStatusQuote
        '
        Me.cboStatusQuote.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatusQuote.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusQuote.FormattingEnabled = True
        Me.cboStatusQuote.Location = New System.Drawing.Point(90, 179)
        Me.cboStatusQuote.Name = "cboStatusQuote"
        Me.cboStatusQuote.Size = New System.Drawing.Size(141, 22)
        Me.cboStatusQuote.TabIndex = 56
        Me.cboStatusQuote.Visible = False
        '
        'lblDecision_Dt
        '
        Me.lblDecision_Dt.AutoSize = True
        Me.lblDecision_Dt.Location = New System.Drawing.Point(239, 184)
        Me.lblDecision_Dt.Name = "lblDecision_Dt"
        Me.lblDecision_Dt.Size = New System.Drawing.Size(90, 15)
        Me.lblDecision_Dt.TabIndex = 51
        Me.lblDecision_Dt.Text = "Follow up date:"
        Me.lblDecision_Dt.Visible = False
        '
        'lblStatusQuote
        '
        Me.lblStatusQuote.AutoSize = True
        Me.lblStatusQuote.Location = New System.Drawing.Point(8, 188)
        Me.lblStatusQuote.Name = "lblStatusQuote"
        Me.lblStatusQuote.Size = New System.Drawing.Size(81, 15)
        Me.lblStatusQuote.TabIndex = 50
        Me.lblStatusQuote.Text = "Quote Status "
        Me.lblStatusQuote.Visible = False
        '
        'gbSaveProgress
        '
        Me.gbSaveProgress.Controls.Add(Me.lblSave_Item_No)
        Me.gbSaveProgress.Controls.Add(Me.lblSave_Line_No)
        Me.gbSaveProgress.Controls.Add(Me.pbSave_Item_No)
        Me.gbSaveProgress.Controls.Add(Me.lblSave_Cus_No)
        Me.gbSaveProgress.Controls.Add(Me.pbSave_Line_No)
        Me.gbSaveProgress.Controls.Add(Me.pbSave_Cus_No)
        Me.gbSaveProgress.Location = New System.Drawing.Point(177, 52)
        Me.gbSaveProgress.Name = "gbSaveProgress"
        Me.gbSaveProgress.Size = New System.Drawing.Size(258, 145)
        Me.gbSaveProgress.TabIndex = 1
        Me.gbSaveProgress.TabStop = False
        Me.gbSaveProgress.Text = "Save in progress"
        Me.gbSaveProgress.Visible = False
        '
        'lblSave_Item_No
        '
        Me.lblSave_Item_No.AutoSize = True
        Me.lblSave_Item_No.Location = New System.Drawing.Point(27, 64)
        Me.lblSave_Item_No.Name = "lblSave_Item_No"
        Me.lblSave_Item_No.Size = New System.Drawing.Size(40, 15)
        Me.lblSave_Item_No.TabIndex = 5
        Me.lblSave_Item_No.Text = "Item : "
        '
        'lblSave_Line_No
        '
        Me.lblSave_Line_No.AutoSize = True
        Me.lblSave_Line_No.Location = New System.Drawing.Point(27, 107)
        Me.lblSave_Line_No.Name = "lblSave_Line_No"
        Me.lblSave_Line_No.Size = New System.Drawing.Size(40, 15)
        Me.lblSave_Line_No.TabIndex = 4
        Me.lblSave_Line_No.Text = "Line : "
        Me.lblSave_Line_No.Visible = False
        '
        'pbSave_Item_No
        '
        Me.pbSave_Item_No.Location = New System.Drawing.Point(26, 81)
        Me.pbSave_Item_No.Margin = New System.Windows.Forms.Padding(30, 3, 30, 3)
        Me.pbSave_Item_No.Name = "pbSave_Item_No"
        Me.pbSave_Item_No.Size = New System.Drawing.Size(192, 23)
        Me.pbSave_Item_No.TabIndex = 3
        '
        'lblSave_Cus_No
        '
        Me.lblSave_Cus_No.AutoSize = True
        Me.lblSave_Cus_No.Location = New System.Drawing.Point(27, 20)
        Me.lblSave_Cus_No.Name = "lblSave_Cus_No"
        Me.lblSave_Cus_No.Size = New System.Drawing.Size(71, 15)
        Me.lblSave_Cus_No.TabIndex = 2
        Me.lblSave_Cus_No.Text = "Customer : "
        Me.lblSave_Cus_No.Visible = False
        '
        'pbSave_Line_No
        '
        Me.pbSave_Line_No.Location = New System.Drawing.Point(26, 125)
        Me.pbSave_Line_No.Margin = New System.Windows.Forms.Padding(30, 3, 30, 3)
        Me.pbSave_Line_No.Name = "pbSave_Line_No"
        Me.pbSave_Line_No.Size = New System.Drawing.Size(192, 23)
        Me.pbSave_Line_No.TabIndex = 1
        Me.pbSave_Line_No.Visible = False
        '
        'pbSave_Cus_No
        '
        Me.pbSave_Cus_No.Location = New System.Drawing.Point(26, 38)
        Me.pbSave_Cus_No.Margin = New System.Windows.Forms.Padding(30, 3, 30, 3)
        Me.pbSave_Cus_No.Name = "pbSave_Cus_No"
        Me.pbSave_Cus_No.Size = New System.Drawing.Size(192, 23)
        Me.pbSave_Cus_No.TabIndex = 0
        Me.pbSave_Cus_No.Visible = False
        '
        'chkOne_Shot
        '
        Me.chkOne_Shot.AutoSize = True
        Me.chkOne_Shot.Location = New System.Drawing.Point(112, 78)
        Me.chkOne_Shot.Name = "chkOne_Shot"
        Me.chkOne_Shot.Size = New System.Drawing.Size(106, 19)
        Me.chkOne_Shot.TabIndex = 42
        Me.chkOne_Shot.Text = "One Shot Deal"
        Me.chkOne_Shot.UseVisualStyleBackColor = True
        Me.chkOne_Shot.Visible = False
        '
        'chkSent_To_Customer
        '
        Me.chkSent_To_Customer.AutoSize = True
        Me.chkSent_To_Customer.Location = New System.Drawing.Point(112, 78)
        Me.chkSent_To_Customer.Name = "chkSent_To_Customer"
        Me.chkSent_To_Customer.Size = New System.Drawing.Size(125, 19)
        Me.chkSent_To_Customer.TabIndex = 46
        Me.chkSent_To_Customer.Text = "Sent To Customer"
        Me.chkSent_To_Customer.UseVisualStyleBackColor = True
        Me.chkSent_To_Customer.Visible = False
        '
        'lblCurrent_Rev_No
        '
        Me.lblCurrent_Rev_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrent_Rev_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrent_Rev_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent_Rev_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrent_Rev_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCurrent_Rev_No.Location = New System.Drawing.Point(407, 18)
        Me.lblCurrent_Rev_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCurrent_Rev_No.Name = "lblCurrent_Rev_No"
        Me.lblCurrent_Rev_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrent_Rev_No.Size = New System.Drawing.Size(29, 22)
        Me.lblCurrent_Rev_No.TabIndex = 41
        Me.lblCurrent_Rev_No.Text = "Rev"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(21, 70)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 20)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Show"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblOrd_No
        '
        Me.lblOrd_No.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrd_No.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOrd_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrd_No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrd_No.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOrd_No.Location = New System.Drawing.Point(244, 79)
        Me.lblOrd_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblOrd_No.Name = "lblOrd_No"
        Me.lblOrd_No.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOrd_No.Size = New System.Drawing.Size(105, 22)
        Me.lblOrd_No.TabIndex = 43
        Me.lblOrd_No.Text = "Order No"
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(21, 44)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(43, 20)
        Me.btn1.TabIndex = 41
        Me.btn1.Text = "Hide"
        Me.btn1.UseVisualStyleBackColor = True
        Me.btn1.Visible = False
        '
        'cmdQuoteComments
        '
        Me.cmdQuoteComments.BackColor = System.Drawing.SystemColors.Control
        Me.cmdQuoteComments.Location = New System.Drawing.Point(112, 148)
        Me.cmdQuoteComments.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdQuoteComments.Name = "cmdQuoteComments"
        Me.cmdQuoteComments.Size = New System.Drawing.Size(237, 24)
        Me.cmdQuoteComments.TabIndex = 23
        Me.cmdQuoteComments.Text = "Quote Comments"
        Me.cmdQuoteComments.UseVisualStyleBackColor = False
        Me.cmdQuoteComments.Visible = False
        '
        'btnShowAdminFields
        '
        Me.btnShowAdminFields.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowAdminFields.Location = New System.Drawing.Point(65, 15)
        Me.btnShowAdminFields.Name = "btnShowAdminFields"
        Me.btnShowAdminFields.Size = New System.Drawing.Size(43, 20)
        Me.btnShowAdminFields.TabIndex = 31
        Me.btnShowAdminFields.Text = "Admin"
        Me.btnShowAdminFields.UseVisualStyleBackColor = True
        Me.btnShowAdminFields.Visible = False
        '
        'lblProg_Comments
        '
        Me.lblProg_Comments.BackColor = System.Drawing.SystemColors.Control
        Me.lblProg_Comments.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProg_Comments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProg_Comments.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProg_Comments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProg_Comments.Location = New System.Drawing.Point(5, 151)
        Me.lblProg_Comments.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProg_Comments.Name = "lblProg_Comments"
        Me.lblProg_Comments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProg_Comments.Size = New System.Drawing.Size(104, 22)
        Me.lblProg_Comments.TabIndex = 24
        Me.lblProg_Comments.Text = "Comments"
        '
        'cboContact_ID
        '
        Me.cboContact_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContact_ID.FormattingEnabled = True
        Me.cboContact_ID.Location = New System.Drawing.Point(112, 123)
        Me.cboContact_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.cboContact_ID.Name = "cboContact_ID"
        Me.cboContact_ID.Size = New System.Drawing.Size(237, 23)
        Me.cboContact_ID.TabIndex = 22
        '
        'lblContact
        '
        Me.lblContact.BackColor = System.Drawing.SystemColors.Control
        Me.lblContact.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblContact.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContact.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblContact.Location = New System.Drawing.Point(5, 126)
        Me.lblContact.Margin = New System.Windows.Forms.Padding(1)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblContact.Size = New System.Drawing.Size(221, 22)
        Me.lblContact.TabIndex = 21
        Me.lblContact.Text = "Contact"
        '
        'lblImprint
        '
        Me.lblImprint.BackColor = System.Drawing.SystemColors.Control
        Me.lblImprint.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImprint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImprint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImprint.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprint.Location = New System.Drawing.Point(244, 55)
        Me.lblImprint.Margin = New System.Windows.Forms.Padding(1)
        Me.lblImprint.Name = "lblImprint"
        Me.lblImprint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImprint.Size = New System.Drawing.Size(105, 22)
        Me.lblImprint.TabIndex = 9
        Me.lblImprint.Text = "Imprint"
        '
        'lblProg_Cd
        '
        Me.lblProg_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblProg_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProg_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProg_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProg_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProg_Cd.Location = New System.Drawing.Point(5, 55)
        Me.lblProg_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProg_Cd.Name = "lblProg_Cd"
        Me.lblProg_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProg_Cd.Size = New System.Drawing.Size(105, 22)
        Me.lblProg_Cd.TabIndex = 7
        Me.lblProg_Cd.Text = "Program Name"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(1, 15)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(474, 248)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 7
        Me.LineShape1.X2 = 535
        Me.LineShape1.Y1 = 28
        Me.LineShape1.Y2 = 28
        '
        'lblQuote_Step_User
        '
        Me.lblQuote_Step_User.BackColor = System.Drawing.SystemColors.Control
        Me.lblQuote_Step_User.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQuote_Step_User.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuote_Step_User.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQuote_Step_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblQuote_Step_User.Location = New System.Drawing.Point(4, 60)
        Me.lblQuote_Step_User.Margin = New System.Windows.Forms.Padding(1)
        Me.lblQuote_Step_User.Name = "lblQuote_Step_User"
        Me.lblQuote_Step_User.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQuote_Step_User.Size = New System.Drawing.Size(105, 18)
        Me.lblQuote_Step_User.TabIndex = 36
        Me.lblQuote_Step_User.Text = "Quote Step User"
        '
        'gbQuoteSteps
        '
        Me.gbQuoteSteps.Controls.Add(Me.gbOptions)
        Me.gbQuoteSteps.Controls.Add(Me.lblQuote_Step_ID)
        Me.gbQuoteSteps.Controls.Add(Me.txtProg_CSR)
        Me.gbQuoteSteps.Controls.Add(Me.txtQuote_Step_User)
        Me.gbQuoteSteps.Controls.Add(Me.txtQuote_Step_ID)
        Me.gbQuoteSteps.Controls.Add(Me.lblQuote_Step_User)
        Me.gbQuoteSteps.Location = New System.Drawing.Point(930, 33)
        Me.gbQuoteSteps.Name = "gbQuoteSteps"
        Me.gbQuoteSteps.Size = New System.Drawing.Size(126, 190)
        Me.gbQuoteSteps.TabIndex = 38
        Me.gbQuoteSteps.TabStop = False
        Me.gbQuoteSteps.Text = "Quote Steps"
        Me.gbQuoteSteps.Visible = False
        '
        'gbOptions
        '
        Me.gbOptions.Controls.Add(Me.ToolStrip1)
        Me.gbOptions.Location = New System.Drawing.Point(7, 118)
        Me.gbOptions.Margin = New System.Windows.Forms.Padding(1)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Size = New System.Drawing.Size(34, 42)
        Me.gbOptions.TabIndex = 38
        Me.gbOptions.TabStop = False
        Me.gbOptions.Text = "Options / Charges"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Enabled = False
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(28, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip2"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Enabled = False
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(35, 19)
        Me.ToolStripButton1.Text = "New"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(40, 19)
        Me.ToolStripButton2.Text = "Open"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Enabled = False
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(44, 19)
        Me.ToolStripButton3.Text = "Delete"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Enabled = False
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(50, 19)
        Me.ToolStripButton4.Text = "Refresh"
        '
        'lblQuote_Step_ID
        '
        Me.lblQuote_Step_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblQuote_Step_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQuote_Step_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuote_Step_ID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQuote_Step_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblQuote_Step_ID.Location = New System.Drawing.Point(4, 17)
        Me.lblQuote_Step_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblQuote_Step_ID.Name = "lblQuote_Step_ID"
        Me.lblQuote_Step_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQuote_Step_ID.Size = New System.Drawing.Size(86, 18)
        Me.lblQuote_Step_ID.TabIndex = 38
        Me.lblQuote_Step_ID.Text = "Quote Step ID"
        '
        'ssStatusBar
        '
        Me.ssStatusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ssStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslCreate_By, Me.tsslCreate_TS, Me.tsslUser_Login, Me.tsslUpdate_TS})
        Me.ssStatusBar.Location = New System.Drawing.Point(0, 594)
        Me.ssStatusBar.Name = "ssStatusBar"
        Me.ssStatusBar.Size = New System.Drawing.Size(1068, 22)
        Me.ssStatusBar.TabIndex = 39
        Me.ssStatusBar.Text = "StatusStrip1"
        '
        'tsslCreate_By
        '
        Me.tsslCreate_By.Name = "tsslCreate_By"
        Me.tsslCreate_By.Size = New System.Drawing.Size(16, 17)
        Me.tsslCreate_By.Text = "   "
        '
        'tsslCreate_TS
        '
        Me.tsslCreate_TS.Name = "tsslCreate_TS"
        Me.tsslCreate_TS.Size = New System.Drawing.Size(16, 17)
        Me.tsslCreate_TS.Text = "   "
        '
        'tsslUser_Login
        '
        Me.tsslUser_Login.Name = "tsslUser_Login"
        Me.tsslUser_Login.Size = New System.Drawing.Size(16, 17)
        Me.tsslUser_Login.Text = "   "
        '
        'tsslUpdate_TS
        '
        Me.tsslUpdate_TS.Name = "tsslUpdate_TS"
        Me.tsslUpdate_TS.Size = New System.Drawing.Size(16, 17)
        Me.tsslUpdate_TS.Text = "   "
        '
        'tcOptions
        '
        Me.tcOptions.Controls.Add(Me.tcpOptions)
        Me.tcOptions.Controls.Add(Me.tcpSetUps)
        Me.tcOptions.Controls.Add(Me.tcpDocuments)
        Me.tcOptions.Location = New System.Drawing.Point(488, 39)
        Me.tcOptions.Margin = New System.Windows.Forms.Padding(1)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedIndex = 0
        Me.tcOptions.Size = New System.Drawing.Size(570, 258)
        Me.tcOptions.TabIndex = 40
        '
        'tcpOptions
        '
        Me.tcpOptions.Controls.Add(Me.panOptions)
        Me.tcpOptions.Controls.Add(Me.tsOptions)
        Me.tcpOptions.Location = New System.Drawing.Point(4, 24)
        Me.tcpOptions.Name = "tcpOptions"
        Me.tcpOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tcpOptions.Size = New System.Drawing.Size(562, 230)
        Me.tcpOptions.TabIndex = 0
        Me.tcpOptions.Text = "Options"
        Me.tcpOptions.UseVisualStyleBackColor = True
        '
        'panOptions
        '
        Me.panOptions.Controls.Add(Me.dgvOptions)
        Me.panOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panOptions.Location = New System.Drawing.Point(3, 3)
        Me.panOptions.Margin = New System.Windows.Forms.Padding(1)
        Me.panOptions.Name = "panOptions"
        Me.panOptions.Size = New System.Drawing.Size(556, 224)
        Me.panOptions.TabIndex = 40
        '
        'dgvOptions
        '
        Me.dgvOptions.AllowUserToAddRows = False
        Me.dgvOptions.AllowUserToDeleteRows = False
        Me.dgvOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptions.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvOptions.Name = "dgvOptions"
        Me.dgvOptions.ReadOnly = True
        Me.dgvOptions.Size = New System.Drawing.Size(556, 224)
        Me.dgvOptions.TabIndex = 0
        '
        'tsOptions
        '
        Me.tsOptions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOptionsWaiveAll, Me.tsbOptionsResetAll})
        Me.tsOptions.Location = New System.Drawing.Point(3, 3)
        Me.tsOptions.Name = "tsOptions"
        Me.tsOptions.Size = New System.Drawing.Size(556, 25)
        Me.tsOptions.TabIndex = 39
        Me.tsOptions.Text = "tsOptionsMenu"
        Me.tsOptions.Visible = False
        '
        'tsbOptionsWaiveAll
        '
        Me.tsbOptionsWaiveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOptionsWaiveAll.Image = CType(resources.GetObject("tsbOptionsWaiveAll.Image"), System.Drawing.Image)
        Me.tsbOptionsWaiveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptionsWaiveAll.Name = "tsbOptionsWaiveAll"
        Me.tsbOptionsWaiveAll.Size = New System.Drawing.Size(60, 22)
        Me.tsbOptionsWaiveAll.Text = "Waive All"
        Me.tsbOptionsWaiveAll.Visible = False
        '
        'tsbOptionsResetAll
        '
        Me.tsbOptionsResetAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOptionsResetAll.Image = CType(resources.GetObject("tsbOptionsResetAll.Image"), System.Drawing.Image)
        Me.tsbOptionsResetAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptionsResetAll.Name = "tsbOptionsResetAll"
        Me.tsbOptionsResetAll.Size = New System.Drawing.Size(56, 22)
        Me.tsbOptionsResetAll.Text = "Reset All"
        Me.tsbOptionsResetAll.Visible = False
        '
        'tcpSetUps
        '
        Me.tcpSetUps.Controls.Add(Me.panSetUps)
        Me.tcpSetUps.Controls.Add(Me.tsSetUps)
        Me.tcpSetUps.Location = New System.Drawing.Point(4, 22)
        Me.tcpSetUps.Name = "tcpSetUps"
        Me.tcpSetUps.Padding = New System.Windows.Forms.Padding(3)
        Me.tcpSetUps.Size = New System.Drawing.Size(562, 232)
        Me.tcpSetUps.TabIndex = 2
        Me.tcpSetUps.Text = "Set-Ups"
        Me.tcpSetUps.UseVisualStyleBackColor = True
        '
        'panSetUps
        '
        Me.panSetUps.Controls.Add(Me.dgvSetUps)
        Me.panSetUps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panSetUps.Location = New System.Drawing.Point(3, 3)
        Me.panSetUps.Margin = New System.Windows.Forms.Padding(1)
        Me.panSetUps.Name = "panSetUps"
        Me.panSetUps.Size = New System.Drawing.Size(556, 226)
        Me.panSetUps.TabIndex = 43
        '
        'dgvSetUps
        '
        Me.dgvSetUps.AllowUserToAddRows = False
        Me.dgvSetUps.AllowUserToDeleteRows = False
        Me.dgvSetUps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSetUps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSetUps.Location = New System.Drawing.Point(0, 0)
        Me.dgvSetUps.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSetUps.Name = "dgvSetUps"
        Me.dgvSetUps.Size = New System.Drawing.Size(556, 226)
        Me.dgvSetUps.TabIndex = 0
        Me.dgvSetUps.Visible = False
        '
        'tsSetUps
        '
        Me.tsSetUps.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsSetUps.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSetUpsWaiveAll, Me.tsbSetUpsResetAll})
        Me.tsSetUps.Location = New System.Drawing.Point(3, 3)
        Me.tsSetUps.Name = "tsSetUps"
        Me.tsSetUps.Size = New System.Drawing.Size(556, 25)
        Me.tsSetUps.TabIndex = 42
        Me.tsSetUps.Text = "ToolStrip3"
        Me.tsSetUps.Visible = False
        '
        'tsbSetUpsWaiveAll
        '
        Me.tsbSetUpsWaiveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSetUpsWaiveAll.Image = CType(resources.GetObject("tsbSetUpsWaiveAll.Image"), System.Drawing.Image)
        Me.tsbSetUpsWaiveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSetUpsWaiveAll.Name = "tsbSetUpsWaiveAll"
        Me.tsbSetUpsWaiveAll.Size = New System.Drawing.Size(60, 22)
        Me.tsbSetUpsWaiveAll.Text = "Waive All"
        '
        'tsbSetUpsResetAll
        '
        Me.tsbSetUpsResetAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSetUpsResetAll.Image = CType(resources.GetObject("tsbSetUpsResetAll.Image"), System.Drawing.Image)
        Me.tsbSetUpsResetAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSetUpsResetAll.Name = "tsbSetUpsResetAll"
        Me.tsbSetUpsResetAll.Size = New System.Drawing.Size(56, 22)
        Me.tsbSetUpsResetAll.Text = "Reset All"
        '
        'tcpDocuments
        '
        Me.tcpDocuments.Controls.Add(Me.UcDocuments)
        Me.tcpDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tcpDocuments.Name = "tcpDocuments"
        Me.tcpDocuments.Padding = New System.Windows.Forms.Padding(3)
        Me.tcpDocuments.Size = New System.Drawing.Size(562, 232)
        Me.tcpDocuments.TabIndex = 1
        Me.tcpDocuments.Text = "Documents"
        Me.tcpDocuments.UseVisualStyleBackColor = True
        '
        'menuCopyRow
        '
        Me.menuCopyRow.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuCopyRow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyAndPasteThisItemToolStripMenuItem})
        Me.menuCopyRow.Name = "menuCopyRow"
        Me.menuCopyRow.Size = New System.Drawing.Size(206, 26)
        '
        'CopyAndPasteThisItemToolStripMenuItem
        '
        Me.CopyAndPasteThisItemToolStripMenuItem.Name = "CopyAndPasteThisItemToolStripMenuItem"
        Me.CopyAndPasteThisItemToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CopyAndPasteThisItemToolStripMenuItem.Text = "Copy and Paste this Item"
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(488, 60)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(8)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 61
        Me.mcCalendar.Visible = False
        '
        'pictLoadImage
        '
        Me.pictLoadImage.BackColor = System.Drawing.Color.Transparent
        Me.pictLoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pictLoadImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictLoadImage.Image = CType(resources.GetObject("pictLoadImage.Image"), System.Drawing.Image)
        Me.pictLoadImage.Location = New System.Drawing.Point(422, 231)
        Me.pictLoadImage.Name = "pictLoadImage"
        Me.pictLoadImage.Size = New System.Drawing.Size(237, 179)
        Me.pictLoadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictLoadImage.TabIndex = 159
        Me.pictLoadImage.TabStop = False
        Me.pictLoadImage.Visible = False
        Me.pictLoadImage.WaitOnLoad = True
        '
        'lblLoading
        '
        Me.lblLoading.BackColor = System.Drawing.Color.Transparent
        Me.lblLoading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoading.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoading.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLoading.Location = New System.Drawing.Point(496, 408)
        Me.lblLoading.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLoading.Size = New System.Drawing.Size(99, 14)
        Me.lblLoading.TabIndex = 161
        Me.lblLoading.Text = "Loading ........"
        Me.lblLoading.Visible = False
        '
        'txtProg_CSR
        '
        Me.txtProg_CSR.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtProg_CSR.DataLength = CType(0, Long)
        Me.txtProg_CSR.DataType = CustomerFile.CDataType.dtString
        Me.txtProg_CSR.DateValue = New Date(CType(0, Long))
        Me.txtProg_CSR.DecimalDigits = CType(0, Long)
        Me.txtProg_CSR.Enabled = False
        Me.txtProg_CSR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProg_CSR.Location = New System.Drawing.Point(4, 162)
        Me.txtProg_CSR.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProg_CSR.Mask = Nothing
        Me.txtProg_CSR.Name = "txtProg_CSR"
        Me.txtProg_CSR.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtProg_CSR.OldValue = Nothing
        Me.txtProg_CSR.Size = New System.Drawing.Size(118, 21)
        Me.txtProg_CSR.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtProg_CSR.StringValue = Nothing
        Me.txtProg_CSR.TabIndex = 32
        Me.txtProg_CSR.TextDataID = Nothing
        '
        'txtQuote_Step_User
        '
        Me.txtQuote_Step_User.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtQuote_Step_User.DataLength = CType(0, Long)
        Me.txtQuote_Step_User.DataType = CustomerFile.CDataType.dtString
        Me.txtQuote_Step_User.DateValue = New Date(CType(0, Long))
        Me.txtQuote_Step_User.DecimalDigits = CType(0, Long)
        Me.txtQuote_Step_User.Enabled = False
        Me.txtQuote_Step_User.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuote_Step_User.Location = New System.Drawing.Point(4, 80)
        Me.txtQuote_Step_User.Margin = New System.Windows.Forms.Padding(1)
        Me.txtQuote_Step_User.Mask = Nothing
        Me.txtQuote_Step_User.Name = "txtQuote_Step_User"
        Me.txtQuote_Step_User.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtQuote_Step_User.OldValue = Nothing
        Me.txtQuote_Step_User.Size = New System.Drawing.Size(118, 21)
        Me.txtQuote_Step_User.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtQuote_Step_User.StringValue = Nothing
        Me.txtQuote_Step_User.TabIndex = 37
        Me.txtQuote_Step_User.TextDataID = Nothing
        '
        'txtQuote_Step_ID
        '
        Me.txtQuote_Step_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtQuote_Step_ID.DataLength = CType(0, Long)
        Me.txtQuote_Step_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtQuote_Step_ID.DateValue = New Date(CType(0, Long))
        Me.txtQuote_Step_ID.DecimalDigits = CType(0, Long)
        Me.txtQuote_Step_ID.Enabled = False
        Me.txtQuote_Step_ID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuote_Step_ID.Location = New System.Drawing.Point(4, 37)
        Me.txtQuote_Step_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtQuote_Step_ID.Mask = Nothing
        Me.txtQuote_Step_ID.Name = "txtQuote_Step_ID"
        Me.txtQuote_Step_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtQuote_Step_ID.OldValue = Nothing
        Me.txtQuote_Step_ID.Size = New System.Drawing.Size(118, 21)
        Me.txtQuote_Step_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtQuote_Step_ID.StringValue = Nothing
        Me.txtQuote_Step_ID.TabIndex = 34
        Me.txtQuote_Step_ID.TextDataID = Nothing
        '
        'UcDocuments
        '
        Me.UcDocuments.Cus_Prog_Guid = Nothing
        Me.UcDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDocuments.Location = New System.Drawing.Point(3, 3)
        Me.UcDocuments.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.UcDocuments.Name = "UcDocuments"
        Me.UcDocuments.SearchVisible = False
        Me.UcDocuments.Size = New System.Drawing.Size(556, 226)
        Me.UcDocuments.TabIndex = 0
        Me.UcDocuments.Tag = "CF-CTL-DOC-001"
        '
        'txtEndDecision_Dt
        '
        Me.txtEndDecision_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEndDecision_Dt.DataLength = CType(0, Long)
        Me.txtEndDecision_Dt.DataType = CustomerFile.CDataType.dtDateTime
        Me.txtEndDecision_Dt.DateValue = New Date(CType(0, Long))
        Me.txtEndDecision_Dt.DecimalDigits = CType(0, Long)
        Me.txtEndDecision_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndDecision_Dt.Location = New System.Drawing.Point(333, 195)
        Me.txtEndDecision_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEndDecision_Dt.Mask = Nothing
        Me.txtEndDecision_Dt.Name = "txtEndDecision_Dt"
        Me.txtEndDecision_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEndDecision_Dt.OldValue = Nothing
        Me.txtEndDecision_Dt.ReadOnly = True
        Me.txtEndDecision_Dt.Size = New System.Drawing.Size(137, 21)
        Me.txtEndDecision_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEndDecision_Dt.StringValue = Nothing
        Me.txtEndDecision_Dt.TabIndex = 59
        Me.txtEndDecision_Dt.TextDataID = Nothing
        Me.txtEndDecision_Dt.Visible = False
        '
        'txtDecision_Dt
        '
        Me.txtDecision_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtDecision_Dt.DataLength = CType(0, Long)
        Me.txtDecision_Dt.DataType = CustomerFile.CDataType.dtDateTime
        Me.txtDecision_Dt.DateValue = New Date(CType(0, Long))
        Me.txtDecision_Dt.DecimalDigits = CType(0, Long)
        Me.txtDecision_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDecision_Dt.Location = New System.Drawing.Point(333, 181)
        Me.txtDecision_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDecision_Dt.Mask = Nothing
        Me.txtDecision_Dt.Name = "txtDecision_Dt"
        Me.txtDecision_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDecision_Dt.OldValue = Nothing
        Me.txtDecision_Dt.ReadOnly = True
        Me.txtDecision_Dt.Size = New System.Drawing.Size(137, 21)
        Me.txtDecision_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtDecision_Dt.StringValue = Nothing
        Me.txtDecision_Dt.TabIndex = 54
        Me.txtDecision_Dt.TextDataID = Nothing
        Me.txtDecision_Dt.Visible = False
        '
        'txtCurrent_Rev_No
        '
        Me.txtCurrent_Rev_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCurrent_Rev_No.DataLength = CType(0, Long)
        Me.txtCurrent_Rev_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCurrent_Rev_No.DateValue = New Date(CType(0, Long))
        Me.txtCurrent_Rev_No.DecimalDigits = CType(0, Long)
        Me.txtCurrent_Rev_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrent_Rev_No.Location = New System.Drawing.Point(438, 15)
        Me.txtCurrent_Rev_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCurrent_Rev_No.Mask = Nothing
        Me.txtCurrent_Rev_No.Name = "txtCurrent_Rev_No"
        Me.txtCurrent_Rev_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCurrent_Rev_No.OldValue = Nothing
        Me.txtCurrent_Rev_No.ReadOnly = True
        Me.txtCurrent_Rev_No.Size = New System.Drawing.Size(31, 21)
        Me.txtCurrent_Rev_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCurrent_Rev_No.StringValue = Nothing
        Me.txtCurrent_Rev_No.TabIndex = 45
        Me.txtCurrent_Rev_No.TextDataID = Nothing
        '
        'txtOrd_No
        '
        Me.txtOrd_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtOrd_No.DataLength = CType(50, Long)
        Me.txtOrd_No.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_No.DateValue = New Date(CType(0, Long))
        Me.txtOrd_No.DecimalDigits = CType(0, Long)
        Me.txtOrd_No.Enabled = False
        Me.txtOrd_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrd_No.Location = New System.Drawing.Point(351, 76)
        Me.txtOrd_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOrd_No.Mask = Nothing
        Me.txtOrd_No.Name = "txtOrd_No"
        Me.txtOrd_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_No.OldValue = Nothing
        Me.txtOrd_No.Size = New System.Drawing.Size(118, 21)
        Me.txtOrd_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtOrd_No.StringValue = Nothing
        Me.txtOrd_No.TabIndex = 44
        Me.txtOrd_No.TextDataID = Nothing
        '
        'txtCurr_Cd
        '
        Me.txtCurr_Cd.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCurr_Cd.DataLength = CType(0, Long)
        Me.txtCurr_Cd.DataType = CustomerFile.CDataType.dtString
        Me.txtCurr_Cd.DateValue = New Date(CType(0, Long))
        Me.txtCurr_Cd.DecimalDigits = CType(0, Long)
        Me.txtCurr_Cd.Enabled = False
        Me.txtCurr_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurr_Cd.Location = New System.Drawing.Point(177, 15)
        Me.txtCurr_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCurr_Cd.Mask = Nothing
        Me.txtCurr_Cd.Name = "txtCurr_Cd"
        Me.txtCurr_Cd.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCurr_Cd.OldValue = Nothing
        Me.txtCurr_Cd.Size = New System.Drawing.Size(31, 21)
        Me.txtCurr_Cd.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCurr_Cd.StringValue = Nothing
        Me.txtCurr_Cd.TabIndex = 32
        Me.txtCurr_Cd.TextDataID = Nothing
        '
        'txtProg_Comments
        '
        Me.txtProg_Comments.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtProg_Comments.DataLength = CType(0, Long)
        Me.txtProg_Comments.DataType = CustomerFile.CDataType.dtString
        Me.txtProg_Comments.DateValue = New Date(CType(0, Long))
        Me.txtProg_Comments.DecimalDigits = CType(0, Long)
        Me.txtProg_Comments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProg_Comments.Location = New System.Drawing.Point(112, 148)
        Me.txtProg_Comments.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProg_Comments.Mask = Nothing
        Me.txtProg_Comments.Multiline = True
        Me.txtProg_Comments.Name = "txtProg_Comments"
        Me.txtProg_Comments.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtProg_Comments.OldValue = Nothing
        Me.txtProg_Comments.Size = New System.Drawing.Size(357, 66)
        Me.txtProg_Comments.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtProg_Comments.StringValue = Nothing
        Me.txtProg_Comments.TabIndex = 25
        Me.txtProg_Comments.TextDataID = Nothing
        '
        'txtImprint
        '
        Me.txtImprint.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtImprint.DataLength = CType(50, Long)
        Me.txtImprint.DataType = CustomerFile.CDataType.dtString
        Me.txtImprint.DateValue = New Date(CType(0, Long))
        Me.txtImprint.DecimalDigits = CType(0, Long)
        Me.txtImprint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImprint.Location = New System.Drawing.Point(351, 52)
        Me.txtImprint.Margin = New System.Windows.Forms.Padding(1)
        Me.txtImprint.Mask = Nothing
        Me.txtImprint.Name = "txtImprint"
        Me.txtImprint.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtImprint.OldValue = Nothing
        Me.txtImprint.Size = New System.Drawing.Size(118, 21)
        Me.txtImprint.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtImprint.StringValue = Nothing
        Me.txtImprint.TabIndex = 10
        Me.txtImprint.TextDataID = Nothing
        '
        'txtSpector_Cd
        '
        Me.txtSpector_Cd.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSpector_Cd.DataLength = CType(0, Long)
        Me.txtSpector_Cd.DataType = CustomerFile.CDataType.dtString
        Me.txtSpector_Cd.DateValue = New Date(CType(0, Long))
        Me.txtSpector_Cd.DecimalDigits = CType(0, Long)
        Me.txtSpector_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpector_Cd.Location = New System.Drawing.Point(329, 15)
        Me.txtSpector_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSpector_Cd.Mask = Nothing
        Me.txtSpector_Cd.Name = "txtSpector_Cd"
        Me.txtSpector_Cd.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSpector_Cd.OldValue = Nothing
        Me.txtSpector_Cd.ReadOnly = True
        Me.txtSpector_Cd.Size = New System.Drawing.Size(76, 21)
        Me.txtSpector_Cd.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSpector_Cd.StringValue = Nothing
        Me.txtSpector_Cd.TabIndex = 5
        Me.txtSpector_Cd.TextDataID = Nothing
        '
        'txtEnd_Dt
        '
        Me.txtEnd_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEnd_Dt.DataLength = CType(0, Long)
        Me.txtEnd_Dt.DataType = CustomerFile.CDataType.dtDate
        Me.txtEnd_Dt.DateValue = New Date(CType(0, Long))
        Me.txtEnd_Dt.DecimalDigits = CType(0, Long)
        Me.txtEnd_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnd_Dt.Location = New System.Drawing.Point(351, 100)
        Me.txtEnd_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEnd_Dt.Mask = Nothing
        Me.txtEnd_Dt.Name = "txtEnd_Dt"
        Me.txtEnd_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEnd_Dt.OldValue = Nothing
        Me.txtEnd_Dt.Size = New System.Drawing.Size(96, 21)
        Me.txtEnd_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEnd_Dt.StringValue = Nothing
        Me.txtEnd_Dt.TabIndex = 19
        Me.txtEnd_Dt.TextDataID = Nothing
        '
        'txtStart_Dt
        '
        Me.txtStart_Dt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtStart_Dt.DataLength = CType(0, Long)
        Me.txtStart_Dt.DataType = CustomerFile.CDataType.dtDate
        Me.txtStart_Dt.DateValue = New Date(CType(0, Long))
        Me.txtStart_Dt.DecimalDigits = CType(0, Long)
        Me.txtStart_Dt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStart_Dt.Location = New System.Drawing.Point(112, 100)
        Me.txtStart_Dt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStart_Dt.Mask = Nothing
        Me.txtStart_Dt.Name = "txtStart_Dt"
        Me.txtStart_Dt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStart_Dt.OldValue = Nothing
        Me.txtStart_Dt.Size = New System.Drawing.Size(96, 21)
        Me.txtStart_Dt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStart_Dt.StringValue = Nothing
        Me.txtStart_Dt.TabIndex = 16
        Me.txtStart_Dt.TextDataID = Nothing
        '
        'txtProg_Cd
        '
        Me.txtProg_Cd.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtProg_Cd.DataLength = CType(50, Long)
        Me.txtProg_Cd.DataType = CustomerFile.CDataType.dtString
        Me.txtProg_Cd.DateValue = New Date(CType(0, Long))
        Me.txtProg_Cd.DecimalDigits = CType(0, Long)
        Me.txtProg_Cd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProg_Cd.Location = New System.Drawing.Point(112, 52)
        Me.txtProg_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProg_Cd.Mask = Nothing
        Me.txtProg_Cd.Name = "txtProg_Cd"
        Me.txtProg_Cd.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtProg_Cd.OldValue = Nothing
        Me.txtProg_Cd.Size = New System.Drawing.Size(119, 21)
        Me.txtProg_Cd.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtProg_Cd.StringValue = Nothing
        Me.txtProg_Cd.TabIndex = 8
        Me.txtProg_Cd.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Enabled = False
        Me.txtCus_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_No.Location = New System.Drawing.Point(112, 15)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = Nothing
        Me.txtCus_No.Size = New System.Drawing.Size(63, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 2
        Me.txtCus_No.Text = "USA434"
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmQuickProgram
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1068, 616)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.pictLoadImage)
        Me.Controls.Add(Me.mcCalendar)
        Me.Controls.Add(Me.gbQuoteSteps)
        Me.Controls.Add(Me.chkAllGroup)
        Me.Controls.Add(Me.tcOptions)
        Me.Controls.Add(Me.ssStatusBar)
        Me.Controls.Add(Me.tsProgramMenu)
        Me.Controls.Add(Me.gbProgramItems)
        Me.Controls.Add(Me.gbProgramHeader)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmQuickProgram"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-QCK-PRG-001"
        Me.Text = "Program Maintenance"
        Me.tsProgramMenu.ResumeLayout(False)
        Me.tsProgramMenu.PerformLayout()
        Me.tsItemMenu.ResumeLayout(False)
        Me.tsItemMenu.PerformLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProgramItems.ResumeLayout(False)
        Me.gbProgramItems.PerformLayout()
        Me.panItems.ResumeLayout(False)
        Me.panProgress.ResumeLayout(False)
        Me.panProgress.PerformLayout()
        Me.gbProgramHeader.ResumeLayout(False)
        Me.gbProgramHeader.PerformLayout()
        Me.gbSaveProgress.ResumeLayout(False)
        Me.gbSaveProgress.PerformLayout()
        Me.gbQuoteSteps.ResumeLayout(False)
        Me.gbQuoteSteps.PerformLayout()
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ssStatusBar.ResumeLayout(False)
        Me.ssStatusBar.PerformLayout()
        Me.tcOptions.ResumeLayout(False)
        Me.tcpOptions.ResumeLayout(False)
        Me.tcpOptions.PerformLayout()
        Me.panOptions.ResumeLayout(False)
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsOptions.ResumeLayout(False)
        Me.tsOptions.PerformLayout()
        Me.tcpSetUps.ResumeLayout(False)
        Me.tcpSetUps.PerformLayout()
        Me.panSetUps.ResumeLayout(False)
        CType(Me.dgvSetUps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSetUps.ResumeLayout(False)
        Me.tsSetUps.PerformLayout()
        Me.tcpDocuments.ResumeLayout(False)
        Me.menuCopyRow.ResumeLayout(False)
        CType(Me.pictLoadImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdEnd_Dt As System.Windows.Forms.Button
    Friend WithEvents cmdStart_Dt As System.Windows.Forms.Button
    Friend WithEvents txtEnd_Dt As CustomerFile.xTextBox
    Friend WithEvents txtStart_Dt As CustomerFile.xTextBox
    Friend WithEvents cboProg_Type As System.Windows.Forms.ComboBox
    Friend WithEvents tsProgramMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRenew As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtProg_Cd As CustomerFile.xTextBox
    Friend WithEvents lblProgram_No As System.Windows.Forms.Label
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsItemMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents gbProgramItems As System.Windows.Forms.GroupBox
    Friend WithEvents lblEnd_Dt As System.Windows.Forms.Label
    Friend WithEvents lblStart_Dt As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents gbProgramHeader As System.Windows.Forms.GroupBox
    Friend WithEvents panItems As System.Windows.Forms.Panel
    Friend WithEvents txtImprint As CustomerFile.xTextBox
    Friend WithEvents lblImprint As System.Windows.Forms.Label
    Friend WithEvents txtSpector_Cd As CustomerFile.xTextBox
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdQuoteComments As System.Windows.Forms.Button
    Friend WithEvents tsbNextStep As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboContact_ID As System.Windows.Forms.ComboBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lblProg_Comments As System.Windows.Forms.Label
    Friend WithEvents txtProg_Comments As CustomerFile.xTextBox
    Friend WithEvents btnShowAdminFields As System.Windows.Forms.Button
    Friend WithEvents txtProg_CSR As CustomerFile.xTextBox
    Friend WithEvents tsbExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtQuote_Step_User As CustomerFile.xTextBox
    Friend WithEvents lblQuote_Step_User As System.Windows.Forms.Label
    Friend WithEvents txtQuote_Step_ID As CustomerFile.xTextBox
    Friend WithEvents gbQuoteSteps As System.Windows.Forms.GroupBox
    Friend WithEvents lblQuote_Step_ID As System.Windows.Forms.Label
    Friend WithEvents ssStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslCreate_TS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCreate_By As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUpdate_TS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUser_Login As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tcOptions As System.Windows.Forms.TabControl
    Friend WithEvents tcpOptions As System.Windows.Forms.TabPage
    Friend WithEvents tcpDocuments As System.Windows.Forms.TabPage
    Friend WithEvents UcDocuments As CustomerFile.ucDocument
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbMassInsert As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCurr_Cd As CustomerFile.xTextBox
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents chkOne_Shot As System.Windows.Forms.CheckBox
    Friend WithEvents txtOrd_No As CustomerFile.xTextBox
    Friend WithEvents lblOrd_No As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tcpSetUps As System.Windows.Forms.TabPage
    Friend WithEvents panOptions As System.Windows.Forms.Panel
    Friend WithEvents dgvOptions As System.Windows.Forms.DataGridView
    Friend WithEvents tsOptions As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbOptionsWaiveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOptionsResetAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents panSetUps As System.Windows.Forms.Panel
    Friend WithEvents dgvSetUps As System.Windows.Forms.DataGridView
    Friend WithEvents tsSetUps As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSetUpsWaiveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSetUpsResetAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCreateRevision As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCurrent_Rev_No As System.Windows.Forms.Label
    Friend WithEvents txtCurrent_Rev_No As CustomerFile.xTextBox
    Friend WithEvents chkSent_To_Customer As System.Windows.Forms.CheckBox
    Friend WithEvents lblProg_Cd As System.Windows.Forms.Label
    Friend WithEvents chkAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnChk As System.Windows.Forms.Button
    Friend WithEvents gbSaveProgress As System.Windows.Forms.GroupBox
    Friend WithEvents lblSave_Item_No As System.Windows.Forms.Label
    Friend WithEvents lblSave_Line_No As System.Windows.Forms.Label
    Friend WithEvents pbSave_Item_No As System.Windows.Forms.ProgressBar
    Friend WithEvents lblSave_Cus_No As System.Windows.Forms.Label
    Friend WithEvents pbSave_Line_No As System.Windows.Forms.ProgressBar
    Friend WithEvents pbSave_Cus_No As System.Windows.Forms.ProgressBar
    Friend WithEvents panProgress As System.Windows.Forms.Panel
    Friend WithEvents txtPBDocument As System.Windows.Forms.TextBox
    Friend WithEvents txtPBEvent As System.Windows.Forms.TextBox
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblQuoteResult As System.Windows.Forms.Label
    Friend WithEvents cboQuoteResult As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusQuote As System.Windows.Forms.ComboBox
    Friend WithEvents lblDecision_Dt As System.Windows.Forms.Label
    Friend WithEvents lblStatusQuote As System.Windows.Forms.Label
    Friend WithEvents tsbClientEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCommentQuoteResult As System.Windows.Forms.TextBox
    Friend WithEvents lblCommOrdClosed As System.Windows.Forms.Label
    Public WithEvents txtDecision_Dt As CustomerFile.xTextBox
    Public WithEvents txtEndDecision_Dt As CustomerFile.xTextBox
    Friend WithEvents btnCustomizedPack As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuCopyRow As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyAndPasteThisItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents pictLoadImage As PictureBox
    Friend WithEvents lblLoading As Label
    Friend WithEvents lblRenewProgram As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents btnNote As Button
    Friend WithEvents tsbExportForm As ToolStripButton
End Class
