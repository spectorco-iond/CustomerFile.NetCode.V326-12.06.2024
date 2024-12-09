<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllsku
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAllsku))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pictBox1 = New System.Windows.Forms.PictureBox()
        Me.grpColors = New System.Windows.Forms.GroupBox()
        Me.lblCpt = New System.Windows.Forms.Label()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.dgvColors = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tlsCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlsAddColors = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.pan3 = New System.Windows.Forms.Panel()
        Me.pan2 = New System.Windows.Forms.Panel()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.tlsCountItems = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlsDeliteLine = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtItemCd = New System.Windows.Forms.TextBox()
        Me.lblItemCd = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.cboQuoteTypeID = New System.Windows.Forms.ComboBox()
        Me.lblQuoteTypeID = New System.Windows.Forms.Label()
        Me.cboQuoteShipMethodId = New System.Windows.Forms.ComboBox()
        Me.lblQuoteShipMethodId = New System.Windows.Forms.Label()
        Me.cboDecorating = New System.Windows.Forms.ComboBox()
        Me.lblDecorating = New System.Windows.Forms.Label()
        Me.txtMinQty1 = New System.Windows.Forms.TextBox()
        Me.lblMinQty1 = New System.Windows.Forms.Label()
        Me.txtPrice1 = New System.Windows.Forms.TextBox()
        Me.lblPrice1 = New System.Windows.Forms.Label()
        Me.chkSetupWaived = New System.Windows.Forms.CheckBox()
        Me.txtSetupPrice = New System.Windows.Forms.TextBox()
        Me.lblSetupPrice = New System.Windows.Forms.Label()
        Me.txtRunCharge = New System.Windows.Forms.TextBox()
        Me.lblRunCharge = New System.Windows.Forms.Label()
        Me.cboColorCount = New System.Windows.Forms.ComboBox()
        Me.lblColorCount = New System.Windows.Forms.Label()
        Me.cboLocationCount = New System.Windows.Forms.ComboBox()
        Me.lblLocationCount = New System.Windows.Forms.Label()
        Me.cboPack = New System.Windows.Forms.ComboBox()
        Me.lblPackaging = New System.Windows.Forms.Label()
        Me.btnImage = New System.Windows.Forms.Button()
        Me.btnComments = New System.Windows.Forms.Button()
        Me.cboCharge = New System.Windows.Forms.ComboBox()
        Me.lblCharge = New System.Windows.Forms.Label()
        Me.btnAddReturn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtMinQty2 = New System.Windows.Forms.TextBox()
        Me.lblMinQty2 = New System.Windows.Forms.Label()
        Me.txtPrice2 = New System.Windows.Forms.TextBox()
        Me.lblPrice2 = New System.Windows.Forms.Label()
        Me.txtMinQty3 = New System.Windows.Forms.TextBox()
        Me.lblMinQty3 = New System.Windows.Forms.Label()
        Me.txtPrice3 = New System.Windows.Forms.TextBox()
        Me.lblPrice3 = New System.Windows.Forms.Label()
        Me.chkEQP1 = New System.Windows.Forms.CheckBox()
        Me.txtQqpDisc1 = New System.Windows.Forms.TextBox()
        Me.chkEQP2 = New System.Windows.Forms.CheckBox()
        Me.txtQqpDisc2 = New System.Windows.Forms.TextBox()
        Me.chkEQP3 = New System.Windows.Forms.CheckBox()
        Me.txtQqpDisc3 = New System.Windows.Forms.TextBox()
        Me.pan1 = New System.Windows.Forms.Panel()
        CType(Me.pictBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpColors.SuspendLayout()
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.pan3.SuspendLayout()
        Me.pan2.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.pan1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictBox1
        '
        Me.pictBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.pictBox1.Location = New System.Drawing.Point(416, 0)
        Me.pictBox1.Name = "pictBox1"
        Me.pictBox1.Size = New System.Drawing.Size(240, 239)
        Me.pictBox1.TabIndex = 30
        Me.pictBox1.TabStop = False
        '
        'grpColors
        '
        Me.grpColors.Controls.Add(Me.lblCpt)
        Me.grpColors.Controls.Add(Me.chkAll)
        Me.grpColors.Controls.Add(Me.dgvColors)
        Me.grpColors.Controls.Add(Me.StatusStrip1)
        Me.grpColors.Controls.Add(Me.ToolStripMenu)
        Me.grpColors.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpColors.Location = New System.Drawing.Point(0, 0)
        Me.grpColors.Name = "grpColors"
        Me.grpColors.Size = New System.Drawing.Size(410, 239)
        Me.grpColors.TabIndex = 4
        Me.grpColors.TabStop = False
        Me.grpColors.Text = "All Colors  with SKU"
        '
        'lblCpt
        '
        Me.lblCpt.AutoSize = True
        Me.lblCpt.Location = New System.Drawing.Point(48, 217)
        Me.lblCpt.Name = "lblCpt"
        Me.lblCpt.Size = New System.Drawing.Size(13, 13)
        Me.lblCpt.TabIndex = 4
        Me.lblCpt.Text = "0"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(6, 19)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(84, 17)
        Me.chkAll.TabIndex = 3
        Me.chkAll.Text = "Uncheck All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dgvColors
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvColors.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvColors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvColors.Location = New System.Drawing.Point(3, 41)
        Me.dgvColors.Name = "dgvColors"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvColors.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvColors.RowHeadersWidth = 10
        Me.dgvColors.Size = New System.Drawing.Size(404, 173)
        Me.dgvColors.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsCount, Me.tlsAddColors})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 214)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(404, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tlsCount
        '
        Me.tlsCount.Name = "tlsCount"
        Me.tlsCount.Size = New System.Drawing.Size(43, 17)
        Me.tlsCount.Text = "Count "
        '
        'tlsAddColors
        '
        Me.tlsAddColors.BackColor = System.Drawing.Color.Gainsboro
        Me.tlsAddColors.Image = CType(resources.GetObject("tlsAddColors.Image"), System.Drawing.Image)
        Me.tlsAddColors.IsLink = True
        Me.tlsAddColors.Margin = New System.Windows.Forms.Padding(30, 3, 0, 2)
        Me.tlsAddColors.Name = "tlsAddColors"
        Me.tlsAddColors.Size = New System.Drawing.Size(213, 17)
        Me.tlsAddColors.Text = "ADD THIS COLORS TO GRID BELOW"
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Location = New System.Drawing.Point(3, 16)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(404, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'pan3
        '
        Me.pan3.Controls.Add(Me.pictBox1)
        Me.pan3.Controls.Add(Me.grpColors)
        Me.pan3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pan3.Location = New System.Drawing.Point(282, 0)
        Me.pan3.Name = "pan3"
        Me.pan3.Size = New System.Drawing.Size(656, 239)
        Me.pan3.TabIndex = 31
        '
        'pan2
        '
        Me.pan2.Controls.Add(Me.dgvItems)
        Me.pan2.Controls.Add(Me.StatusStrip2)
        Me.pan2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pan2.Location = New System.Drawing.Point(282, 239)
        Me.pan2.Name = "pan2"
        Me.pan2.Size = New System.Drawing.Size(656, 240)
        Me.pan2.TabIndex = 32
        '
        'dgvItems
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItems.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvItems.Size = New System.Drawing.Size(656, 218)
        Me.dgvItems.TabIndex = 3
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsCountItems, Me.tlsDeliteLine})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 218)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(656, 22)
        Me.StatusStrip2.TabIndex = 2
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'tlsCountItems
        '
        Me.tlsCountItems.Name = "tlsCountItems"
        Me.tlsCountItems.Size = New System.Drawing.Size(43, 17)
        Me.tlsCountItems.Text = "Count "
        '
        'tlsDeliteLine
        '
        Me.tlsDeliteLine.BackColor = System.Drawing.Color.Gainsboro
        Me.tlsDeliteLine.Image = CType(resources.GetObject("tlsDeliteLine.Image"), System.Drawing.Image)
        Me.tlsDeliteLine.IsLink = True
        Me.tlsDeliteLine.Margin = New System.Windows.Forms.Padding(30, 3, 0, 2)
        Me.tlsDeliteLine.Name = "tlsDeliteLine"
        Me.tlsDeliteLine.Size = New System.Drawing.Size(81, 17)
        Me.tlsDeliteLine.Text = "Delete Line"
        '
        'txtItemCd
        '
        Me.txtItemCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCd.Location = New System.Drawing.Point(12, 25)
        Me.txtItemCd.Name = "txtItemCd"
        Me.txtItemCd.Size = New System.Drawing.Size(80, 18)
        Me.txtItemCd.TabIndex = 0
        '
        'lblItemCd
        '
        Me.lblItemCd.AutoSize = True
        Me.lblItemCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCd.Location = New System.Drawing.Point(12, 9)
        Me.lblItemCd.Name = "lblItemCd"
        Me.lblItemCd.Size = New System.Drawing.Size(44, 12)
        Me.lblItemCd.TabIndex = 1
        Me.lblItemCd.Text = "ITEM CD"
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(102, 25)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(176, 18)
        Me.txtDesc.TabIndex = 2
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(103, 9)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(69, 12)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "DESCRIPTION"
        '
        'cboQuoteTypeID
        '
        Me.cboQuoteTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQuoteTypeID.FormattingEnabled = True
        Me.cboQuoteTypeID.Location = New System.Drawing.Point(12, 166)
        Me.cboQuoteTypeID.Name = "cboQuoteTypeID"
        Me.cboQuoteTypeID.Size = New System.Drawing.Size(153, 20)
        Me.cboQuoteTypeID.TabIndex = 5
        '
        'lblQuoteTypeID
        '
        Me.lblQuoteTypeID.AutoSize = True
        Me.lblQuoteTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuoteTypeID.Location = New System.Drawing.Point(12, 151)
        Me.lblQuoteTypeID.Name = "lblQuoteTypeID"
        Me.lblQuoteTypeID.Size = New System.Drawing.Size(73, 12)
        Me.lblQuoteTypeID.TabIndex = 6
        Me.lblQuoteTypeID.Text = "QUOTE TYPE ID"
        '
        'cboQuoteShipMethodId
        '
        Me.cboQuoteShipMethodId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQuoteShipMethodId.FormattingEnabled = True
        Me.cboQuoteShipMethodId.Location = New System.Drawing.Point(12, 204)
        Me.cboQuoteShipMethodId.Name = "cboQuoteShipMethodId"
        Me.cboQuoteShipMethodId.Size = New System.Drawing.Size(153, 20)
        Me.cboQuoteShipMethodId.TabIndex = 7
        '
        'lblQuoteShipMethodId
        '
        Me.lblQuoteShipMethodId.AutoSize = True
        Me.lblQuoteShipMethodId.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuoteShipMethodId.Location = New System.Drawing.Point(12, 189)
        Me.lblQuoteShipMethodId.Name = "lblQuoteShipMethodId"
        Me.lblQuoteShipMethodId.Size = New System.Drawing.Size(116, 12)
        Me.lblQuoteShipMethodId.TabIndex = 8
        Me.lblQuoteShipMethodId.Text = "QUOTE SHIP METHOD ID"
        '
        'cboDecorating
        '
        Me.cboDecorating.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDecorating.FormattingEnabled = True
        Me.cboDecorating.Location = New System.Drawing.Point(12, 280)
        Me.cboDecorating.Name = "cboDecorating"
        Me.cboDecorating.Size = New System.Drawing.Size(153, 20)
        Me.cboDecorating.TabIndex = 9
        '
        'lblDecorating
        '
        Me.lblDecorating.AutoSize = True
        Me.lblDecorating.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecorating.Location = New System.Drawing.Point(12, 265)
        Me.lblDecorating.Name = "lblDecorating"
        Me.lblDecorating.Size = New System.Drawing.Size(68, 12)
        Me.lblDecorating.TabIndex = 10
        Me.lblDecorating.Text = "DECORATING"
        '
        'txtMinQty1
        '
        Me.txtMinQty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinQty1.Location = New System.Drawing.Point(12, 60)
        Me.txtMinQty1.Name = "txtMinQty1"
        Me.txtMinQty1.Size = New System.Drawing.Size(62, 18)
        Me.txtMinQty1.TabIndex = 11
        Me.txtMinQty1.Tag = "0"
        Me.txtMinQty1.Text = "0"
        '
        'lblMinQty1
        '
        Me.lblMinQty1.AutoSize = True
        Me.lblMinQty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinQty1.Location = New System.Drawing.Point(12, 46)
        Me.lblMinQty1.Name = "lblMinQty1"
        Me.lblMinQty1.Size = New System.Drawing.Size(50, 12)
        Me.lblMinQty1.TabIndex = 12
        Me.lblMinQty1.Text = "MIN QTY 1"
        '
        'txtPrice1
        '
        Me.txtPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice1.Location = New System.Drawing.Point(82, 60)
        Me.txtPrice1.Name = "txtPrice1"
        Me.txtPrice1.ReadOnly = True
        Me.txtPrice1.Size = New System.Drawing.Size(62, 18)
        Me.txtPrice1.TabIndex = 13
        Me.txtPrice1.Tag = "0"
        Me.txtPrice1.Text = "0.00"
        '
        'lblPrice1
        '
        Me.lblPrice1.AutoSize = True
        Me.lblPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice1.Location = New System.Drawing.Point(82, 46)
        Me.lblPrice1.Name = "lblPrice1"
        Me.lblPrice1.Size = New System.Drawing.Size(41, 12)
        Me.lblPrice1.TabIndex = 14
        Me.lblPrice1.Text = "PRICE 1"
        '
        'chkSetupWaived
        '
        Me.chkSetupWaived.AutoSize = True
        Me.chkSetupWaived.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSetupWaived.Location = New System.Drawing.Point(178, 170)
        Me.chkSetupWaived.Name = "chkSetupWaived"
        Me.chkSetupWaived.Size = New System.Drawing.Size(95, 16)
        Me.chkSetupWaived.TabIndex = 15
        Me.chkSetupWaived.Text = "SETUP WAIVED"
        Me.chkSetupWaived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSetupWaived.UseVisualStyleBackColor = True
        '
        'txtSetupPrice
        '
        Me.txtSetupPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetupPrice.Location = New System.Drawing.Point(177, 204)
        Me.txtSetupPrice.Name = "txtSetupPrice"
        Me.txtSetupPrice.Size = New System.Drawing.Size(100, 18)
        Me.txtSetupPrice.TabIndex = 16
        '
        'lblSetupPrice
        '
        Me.lblSetupPrice.AutoSize = True
        Me.lblSetupPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetupPrice.Location = New System.Drawing.Point(177, 189)
        Me.lblSetupPrice.Name = "lblSetupPrice"
        Me.lblSetupPrice.Size = New System.Drawing.Size(66, 12)
        Me.lblSetupPrice.TabIndex = 17
        Me.lblSetupPrice.Text = "SETUP PRICE"
        '
        'txtRunCharge
        '
        Me.txtRunCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunCharge.Location = New System.Drawing.Point(178, 242)
        Me.txtRunCharge.Name = "txtRunCharge"
        Me.txtRunCharge.Size = New System.Drawing.Size(100, 18)
        Me.txtRunCharge.TabIndex = 18
        '
        'lblRunCharge
        '
        Me.lblRunCharge.AutoSize = True
        Me.lblRunCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunCharge.Location = New System.Drawing.Point(177, 227)
        Me.lblRunCharge.Name = "lblRunCharge"
        Me.lblRunCharge.Size = New System.Drawing.Size(69, 12)
        Me.lblRunCharge.TabIndex = 19
        Me.lblRunCharge.Text = "RUN CHARGE"
        '
        'cboColorCount
        '
        Me.cboColorCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboColorCount.FormattingEnabled = True
        Me.cboColorCount.Location = New System.Drawing.Point(177, 280)
        Me.cboColorCount.Name = "cboColorCount"
        Me.cboColorCount.Size = New System.Drawing.Size(99, 20)
        Me.cboColorCount.TabIndex = 20
        '
        'lblColorCount
        '
        Me.lblColorCount.AutoSize = True
        Me.lblColorCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColorCount.Location = New System.Drawing.Point(177, 265)
        Me.lblColorCount.Name = "lblColorCount"
        Me.lblColorCount.Size = New System.Drawing.Size(73, 12)
        Me.lblColorCount.TabIndex = 21
        Me.lblColorCount.Text = "COLOR COUNT"
        '
        'cboLocationCount
        '
        Me.cboLocationCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLocationCount.FormattingEnabled = True
        Me.cboLocationCount.Location = New System.Drawing.Point(177, 318)
        Me.cboLocationCount.Name = "cboLocationCount"
        Me.cboLocationCount.Size = New System.Drawing.Size(99, 20)
        Me.cboLocationCount.TabIndex = 22
        '
        'lblLocationCount
        '
        Me.lblLocationCount.AutoSize = True
        Me.lblLocationCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationCount.Location = New System.Drawing.Point(177, 303)
        Me.lblLocationCount.Name = "lblLocationCount"
        Me.lblLocationCount.Size = New System.Drawing.Size(88, 12)
        Me.lblLocationCount.TabIndex = 23
        Me.lblLocationCount.Text = "LOCATION COUNT"
        '
        'cboPack
        '
        Me.cboPack.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPack.FormattingEnabled = True
        Me.cboPack.Location = New System.Drawing.Point(12, 318)
        Me.cboPack.Name = "cboPack"
        Me.cboPack.Size = New System.Drawing.Size(153, 20)
        Me.cboPack.TabIndex = 24
        '
        'lblPackaging
        '
        Me.lblPackaging.AutoSize = True
        Me.lblPackaging.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackaging.Location = New System.Drawing.Point(12, 303)
        Me.lblPackaging.Name = "lblPackaging"
        Me.lblPackaging.Size = New System.Drawing.Size(62, 12)
        Me.lblPackaging.TabIndex = 25
        Me.lblPackaging.Text = "PACKAGING"
        '
        'btnImage
        '
        Me.btnImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImage.Location = New System.Drawing.Point(17, 419)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(111, 23)
        Me.btnImage.TabIndex = 26
        Me.btnImage.Text = "IMAGE"
        Me.btnImage.UseVisualStyleBackColor = True
        Me.btnImage.Visible = False
        '
        'btnComments
        '
        Me.btnComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComments.Location = New System.Drawing.Point(160, 419)
        Me.btnComments.Name = "btnComments"
        Me.btnComments.Size = New System.Drawing.Size(100, 23)
        Me.btnComments.TabIndex = 27
        Me.btnComments.Text = "COMMENTS"
        Me.btnComments.UseVisualStyleBackColor = True
        Me.btnComments.Visible = False
        '
        'cboCharge
        '
        Me.cboCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCharge.FormattingEnabled = True
        Me.cboCharge.Location = New System.Drawing.Point(12, 242)
        Me.cboCharge.Name = "cboCharge"
        Me.cboCharge.Size = New System.Drawing.Size(153, 20)
        Me.cboCharge.TabIndex = 28
        '
        'lblCharge
        '
        Me.lblCharge.AutoSize = True
        Me.lblCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge.Location = New System.Drawing.Point(12, 227)
        Me.lblCharge.Name = "lblCharge"
        Me.lblCharge.Size = New System.Drawing.Size(46, 12)
        Me.lblCharge.TabIndex = 29
        Me.lblCharge.Text = "CHARGE"
        '
        'btnAddReturn
        '
        Me.btnAddReturn.Location = New System.Drawing.Point(11, 448)
        Me.btnAddReturn.Name = "btnAddReturn"
        Me.btnAddReturn.Size = New System.Drawing.Size(261, 28)
        Me.btnAddReturn.TabIndex = 30
        Me.btnAddReturn.Text = "Add && Return in the Windows "
        Me.btnAddReturn.UseVisualStyleBackColor = True
        Me.btnAddReturn.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Excel"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtMinQty2
        '
        Me.txtMinQty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinQty2.Location = New System.Drawing.Point(12, 94)
        Me.txtMinQty2.Name = "txtMinQty2"
        Me.txtMinQty2.Size = New System.Drawing.Size(62, 18)
        Me.txtMinQty2.TabIndex = 34
        Me.txtMinQty2.Tag = "1"
        Me.txtMinQty2.Text = "0"
        '
        'lblMinQty2
        '
        Me.lblMinQty2.AutoSize = True
        Me.lblMinQty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinQty2.Location = New System.Drawing.Point(12, 80)
        Me.lblMinQty2.Name = "lblMinQty2"
        Me.lblMinQty2.Size = New System.Drawing.Size(50, 12)
        Me.lblMinQty2.TabIndex = 35
        Me.lblMinQty2.Text = "MIN QTY 2"
        '
        'txtPrice2
        '
        Me.txtPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice2.Location = New System.Drawing.Point(82, 94)
        Me.txtPrice2.Name = "txtPrice2"
        Me.txtPrice2.ReadOnly = True
        Me.txtPrice2.Size = New System.Drawing.Size(62, 18)
        Me.txtPrice2.TabIndex = 36
        Me.txtPrice2.Tag = "1"
        Me.txtPrice2.Text = "0.00"
        '
        'lblPrice2
        '
        Me.lblPrice2.AutoSize = True
        Me.lblPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice2.Location = New System.Drawing.Point(82, 80)
        Me.lblPrice2.Name = "lblPrice2"
        Me.lblPrice2.Size = New System.Drawing.Size(41, 12)
        Me.lblPrice2.TabIndex = 37
        Me.lblPrice2.Text = "PRICE 2"
        '
        'txtMinQty3
        '
        Me.txtMinQty3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinQty3.Location = New System.Drawing.Point(12, 130)
        Me.txtMinQty3.Name = "txtMinQty3"
        Me.txtMinQty3.Size = New System.Drawing.Size(62, 18)
        Me.txtMinQty3.TabIndex = 38
        Me.txtMinQty3.Tag = "2"
        Me.txtMinQty3.Text = "0"
        '
        'lblMinQty3
        '
        Me.lblMinQty3.AutoSize = True
        Me.lblMinQty3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinQty3.Location = New System.Drawing.Point(12, 115)
        Me.lblMinQty3.Name = "lblMinQty3"
        Me.lblMinQty3.Size = New System.Drawing.Size(50, 12)
        Me.lblMinQty3.TabIndex = 39
        Me.lblMinQty3.Text = "MIN QTY 3"
        '
        'txtPrice3
        '
        Me.txtPrice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice3.Location = New System.Drawing.Point(82, 130)
        Me.txtPrice3.Name = "txtPrice3"
        Me.txtPrice3.ReadOnly = True
        Me.txtPrice3.Size = New System.Drawing.Size(62, 18)
        Me.txtPrice3.TabIndex = 40
        Me.txtPrice3.Tag = "2"
        Me.txtPrice3.Text = "0.00"
        '
        'lblPrice3
        '
        Me.lblPrice3.AutoSize = True
        Me.lblPrice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice3.Location = New System.Drawing.Point(82, 115)
        Me.lblPrice3.Name = "lblPrice3"
        Me.lblPrice3.Size = New System.Drawing.Size(41, 12)
        Me.lblPrice3.TabIndex = 41
        Me.lblPrice3.Text = "PRICE 3"
        '
        'chkEQP1
        '
        Me.chkEQP1.AutoSize = True
        Me.chkEQP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEQP1.Location = New System.Drawing.Point(147, 60)
        Me.chkEQP1.Name = "chkEQP1"
        Me.chkEQP1.Size = New System.Drawing.Size(74, 16)
        Me.chkEQP1.TabIndex = 45
        Me.chkEQP1.Tag = "0"
        Me.chkEQP1.Text = "EQP Disc %"
        Me.chkEQP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEQP1.UseVisualStyleBackColor = True
        '
        'txtQqpDisc1
        '
        Me.txtQqpDisc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQqpDisc1.Location = New System.Drawing.Point(224, 60)
        Me.txtQqpDisc1.Name = "txtQqpDisc1"
        Me.txtQqpDisc1.ReadOnly = True
        Me.txtQqpDisc1.Size = New System.Drawing.Size(51, 18)
        Me.txtQqpDisc1.TabIndex = 46
        Me.txtQqpDisc1.Tag = "0"
        Me.txtQqpDisc1.Text = "0.00"
        Me.txtQqpDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQqpDisc1.Visible = False
        '
        'chkEQP2
        '
        Me.chkEQP2.AutoSize = True
        Me.chkEQP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEQP2.Location = New System.Drawing.Point(147, 94)
        Me.chkEQP2.Name = "chkEQP2"
        Me.chkEQP2.Size = New System.Drawing.Size(74, 16)
        Me.chkEQP2.TabIndex = 47
        Me.chkEQP2.Tag = "1"
        Me.chkEQP2.Text = "EQP Disc %"
        Me.chkEQP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEQP2.UseVisualStyleBackColor = True
        '
        'txtQqpDisc2
        '
        Me.txtQqpDisc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQqpDisc2.Location = New System.Drawing.Point(224, 94)
        Me.txtQqpDisc2.Name = "txtQqpDisc2"
        Me.txtQqpDisc2.ReadOnly = True
        Me.txtQqpDisc2.Size = New System.Drawing.Size(51, 18)
        Me.txtQqpDisc2.TabIndex = 48
        Me.txtQqpDisc2.Tag = "1"
        Me.txtQqpDisc2.Text = "0.00"
        Me.txtQqpDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQqpDisc2.Visible = False
        '
        'chkEQP3
        '
        Me.chkEQP3.AutoSize = True
        Me.chkEQP3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEQP3.Location = New System.Drawing.Point(147, 130)
        Me.chkEQP3.Name = "chkEQP3"
        Me.chkEQP3.Size = New System.Drawing.Size(74, 16)
        Me.chkEQP3.TabIndex = 49
        Me.chkEQP3.Tag = "2"
        Me.chkEQP3.Text = "EQP Disc %"
        Me.chkEQP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEQP3.UseVisualStyleBackColor = True
        '
        'txtQqpDisc3
        '
        Me.txtQqpDisc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQqpDisc3.Location = New System.Drawing.Point(224, 130)
        Me.txtQqpDisc3.Name = "txtQqpDisc3"
        Me.txtQqpDisc3.ReadOnly = True
        Me.txtQqpDisc3.Size = New System.Drawing.Size(51, 18)
        Me.txtQqpDisc3.TabIndex = 50
        Me.txtQqpDisc3.Tag = "2"
        Me.txtQqpDisc3.Text = "0.00"
        Me.txtQqpDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtQqpDisc3.Visible = False
        '
        'pan1
        '
        Me.pan1.Controls.Add(Me.txtQqpDisc3)
        Me.pan1.Controls.Add(Me.chkEQP3)
        Me.pan1.Controls.Add(Me.txtQqpDisc2)
        Me.pan1.Controls.Add(Me.chkEQP2)
        Me.pan1.Controls.Add(Me.txtQqpDisc1)
        Me.pan1.Controls.Add(Me.chkEQP1)
        Me.pan1.Controls.Add(Me.lblPrice3)
        Me.pan1.Controls.Add(Me.txtPrice3)
        Me.pan1.Controls.Add(Me.lblMinQty3)
        Me.pan1.Controls.Add(Me.txtMinQty3)
        Me.pan1.Controls.Add(Me.lblPrice2)
        Me.pan1.Controls.Add(Me.txtPrice2)
        Me.pan1.Controls.Add(Me.lblMinQty2)
        Me.pan1.Controls.Add(Me.txtMinQty2)
        Me.pan1.Controls.Add(Me.Button1)
        Me.pan1.Controls.Add(Me.btnAddReturn)
        Me.pan1.Controls.Add(Me.lblCharge)
        Me.pan1.Controls.Add(Me.cboCharge)
        Me.pan1.Controls.Add(Me.btnComments)
        Me.pan1.Controls.Add(Me.btnImage)
        Me.pan1.Controls.Add(Me.lblPackaging)
        Me.pan1.Controls.Add(Me.cboPack)
        Me.pan1.Controls.Add(Me.lblLocationCount)
        Me.pan1.Controls.Add(Me.cboLocationCount)
        Me.pan1.Controls.Add(Me.lblColorCount)
        Me.pan1.Controls.Add(Me.cboColorCount)
        Me.pan1.Controls.Add(Me.lblRunCharge)
        Me.pan1.Controls.Add(Me.txtRunCharge)
        Me.pan1.Controls.Add(Me.lblSetupPrice)
        Me.pan1.Controls.Add(Me.txtSetupPrice)
        Me.pan1.Controls.Add(Me.chkSetupWaived)
        Me.pan1.Controls.Add(Me.lblPrice1)
        Me.pan1.Controls.Add(Me.txtPrice1)
        Me.pan1.Controls.Add(Me.lblMinQty1)
        Me.pan1.Controls.Add(Me.txtMinQty1)
        Me.pan1.Controls.Add(Me.lblDecorating)
        Me.pan1.Controls.Add(Me.cboDecorating)
        Me.pan1.Controls.Add(Me.lblQuoteShipMethodId)
        Me.pan1.Controls.Add(Me.cboQuoteShipMethodId)
        Me.pan1.Controls.Add(Me.lblQuoteTypeID)
        Me.pan1.Controls.Add(Me.cboQuoteTypeID)
        Me.pan1.Controls.Add(Me.lblDescription)
        Me.pan1.Controls.Add(Me.txtDesc)
        Me.pan1.Controls.Add(Me.lblItemCd)
        Me.pan1.Controls.Add(Me.txtItemCd)
        Me.pan1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pan1.Location = New System.Drawing.Point(0, 0)
        Me.pan1.Name = "pan1"
        Me.pan1.Size = New System.Drawing.Size(282, 479)
        Me.pan1.TabIndex = 2
        '
        'frmAllsku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 479)
        Me.Controls.Add(Me.pan2)
        Me.Controls.Add(Me.pan3)
        Me.Controls.Add(Me.pan1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAllsku"
        Me.Text = "ALL SKU"
        CType(Me.pictBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpColors.ResumeLayout(False)
        Me.grpColors.PerformLayout()
        CType(Me.dgvColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pan3.ResumeLayout(False)
        Me.pan2.ResumeLayout(False)
        Me.pan2.PerformLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.pan1.ResumeLayout(False)
        Me.pan1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpColors As System.Windows.Forms.GroupBox
    Friend WithEvents dgvColors As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents pictBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tlsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pan3 As System.Windows.Forms.Panel
    Friend WithEvents pan2 As System.Windows.Forms.Panel
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents tlsCountItems As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlsDeliteLine As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlsAddColors As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCpt As System.Windows.Forms.Label
    Friend WithEvents txtItemCd As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCd As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents cboQuoteTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuoteTypeID As System.Windows.Forms.Label
    Friend WithEvents cboQuoteShipMethodId As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuoteShipMethodId As System.Windows.Forms.Label
    Friend WithEvents cboDecorating As System.Windows.Forms.ComboBox
    Friend WithEvents lblDecorating As System.Windows.Forms.Label
    Friend WithEvents txtMinQty1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMinQty1 As System.Windows.Forms.Label
    Friend WithEvents txtPrice1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice1 As System.Windows.Forms.Label
    Friend WithEvents chkSetupWaived As System.Windows.Forms.CheckBox
    Friend WithEvents txtSetupPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblSetupPrice As System.Windows.Forms.Label
    Friend WithEvents txtRunCharge As System.Windows.Forms.TextBox
    Friend WithEvents lblRunCharge As System.Windows.Forms.Label
    Friend WithEvents cboColorCount As System.Windows.Forms.ComboBox
    Friend WithEvents lblColorCount As System.Windows.Forms.Label
    Friend WithEvents cboLocationCount As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationCount As System.Windows.Forms.Label
    Friend WithEvents cboPack As System.Windows.Forms.ComboBox
    Friend WithEvents lblPackaging As System.Windows.Forms.Label
    Friend WithEvents btnImage As System.Windows.Forms.Button
    Friend WithEvents btnComments As System.Windows.Forms.Button
    Friend WithEvents cboCharge As System.Windows.Forms.ComboBox
    Friend WithEvents lblCharge As System.Windows.Forms.Label
    Friend WithEvents btnAddReturn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtMinQty2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMinQty2 As System.Windows.Forms.Label
    Friend WithEvents txtPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice2 As System.Windows.Forms.Label
    Friend WithEvents txtMinQty3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMinQty3 As System.Windows.Forms.Label
    Friend WithEvents txtPrice3 As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice3 As System.Windows.Forms.Label
    Friend WithEvents chkEQP1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtQqpDisc1 As System.Windows.Forms.TextBox
    Friend WithEvents chkEQP2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtQqpDisc2 As System.Windows.Forms.TextBox
    Friend WithEvents chkEQP3 As System.Windows.Forms.CheckBox
    Friend WithEvents txtQqpDisc3 As System.Windows.Forms.TextBox
    Friend WithEvents pan1 As System.Windows.Forms.Panel
End Class
