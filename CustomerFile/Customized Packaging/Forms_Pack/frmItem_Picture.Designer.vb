<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem_Picture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItem_Picture))
        Me.txtItemCd = New System.Windows.Forms.TextBox()
        Me.lblItem_Cd = New System.Windows.Forms.Label()
        Me.lblItemDesc = New System.Windows.Forms.Label()
        Me.cboColor = New System.Windows.Forms.ComboBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.panPictBox = New System.Windows.Forms.Panel()
        Me.pictBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnCustomized = New System.Windows.Forms.Button()
        Me.panItemDesc = New System.Windows.Forms.Panel()
        Me.lblCharge_ItemNo = New System.Windows.Forms.Label()
        Me.cboCharge = New System.Windows.Forms.ComboBox()
        Me.lblCharge = New System.Windows.Forms.Label()
        Me.txtRunCharge = New System.Windows.Forms.TextBox()
        Me.lblRunCharge = New System.Windows.Forms.Label()
        Me.cboDecoMetod = New System.Windows.Forms.ComboBox()
        Me.lblDecoMetods = New System.Windows.Forms.Label()
        Me.txtSetup = New System.Windows.Forms.TextBox()
        Me.lblSetup = New System.Windows.Forms.Label()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.lblCurr = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblCusNo = New System.Windows.Forms.Label()
        Me.txtCusNo = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.panResize = New System.Windows.Forms.Panel()
        Me.lblDepth = New System.Windows.Forms.Label()
        Me.txtDepth = New System.Windows.Forms.TextBox()
        Me.lblinch1 = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.btnResize = New System.Windows.Forms.Button()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.panDgvItemDesc = New System.Windows.Forms.Panel()
        Me.panResult = New System.Windows.Forms.Panel()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.panDgvItems = New System.Windows.Forms.Panel()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.tsTop = New System.Windows.Forms.ToolStrip()
        Me.tsBtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tlStripBtnAddBox = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddImage = New System.Windows.Forms.Button()
        Me.opFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPriceSet = New System.Windows.Forms.TextBox()
        Me.panPictBox.SuspendLayout()
        CType(Me.pictBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panItemDesc.SuspendLayout()
        Me.panResize.SuspendLayout()
        Me.panDgvItemDesc.SuspendLayout()
        Me.panResult.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panDgvItems.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsTop.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtItemCd
        '
        Me.txtItemCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCd.Location = New System.Drawing.Point(80, 29)
        Me.txtItemCd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemCd.Name = "txtItemCd"
        Me.txtItemCd.Size = New System.Drawing.Size(89, 26)
        Me.txtItemCd.TabIndex = 3
        '
        'lblItem_Cd
        '
        Me.lblItem_Cd.AutoSize = True
        Me.lblItem_Cd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem_Cd.Location = New System.Drawing.Point(5, 33)
        Me.lblItem_Cd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItem_Cd.Name = "lblItem_Cd"
        Me.lblItem_Cd.Size = New System.Drawing.Size(67, 20)
        Me.lblItem_Cd.TabIndex = 2
        Me.lblItem_Cd.Text = "Item Cd"
        '
        'lblItemDesc
        '
        Me.lblItemDesc.AutoSize = True
        Me.lblItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemDesc.Location = New System.Drawing.Point(181, 33)
        Me.lblItemDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemDesc.Name = "lblItemDesc"
        Me.lblItemDesc.Size = New System.Drawing.Size(95, 20)
        Me.lblItemDesc.TabIndex = 3
        Me.lblItemDesc.Text = "Description"
        '
        'cboColor
        '
        Me.cboColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboColor.FormattingEnabled = True
        Me.cboColor.Location = New System.Drawing.Point(80, 125)
        Me.cboColor.Name = "cboColor"
        Me.cboColor.Size = New System.Drawing.Size(129, 25)
        Me.cboColor.TabIndex = 6
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(5, 128)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(86, 20)
        Me.lblColor.TabIndex = 5
        Me.lblColor.Text = "Item Color"
        '
        'panPictBox
        '
        Me.panPictBox.Controls.Add(Me.pictBox)
        Me.panPictBox.Location = New System.Drawing.Point(31, 12)
        Me.panPictBox.Name = "panPictBox"
        Me.panPictBox.Size = New System.Drawing.Size(398, 364)
        Me.panPictBox.TabIndex = 8
        '
        'pictBox
        '
        Me.pictBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictBox.Location = New System.Drawing.Point(0, 0)
        Me.pictBox.Name = "pictBox"
        Me.pictBox.Size = New System.Drawing.Size(398, 364)
        Me.pictBox.TabIndex = 0
        Me.pictBox.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(3, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 365)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'btnCustomized
        '
        Me.btnCustomized.Location = New System.Drawing.Point(328, 408)
        Me.btnCustomized.Name = "btnCustomized"
        Me.btnCustomized.Size = New System.Drawing.Size(101, 75)
        Me.btnCustomized.TabIndex = 11
        Me.btnCustomized.Text = "Customized Packaging"
        Me.btnCustomized.UseVisualStyleBackColor = True
        '
        'panItemDesc
        '
        Me.panItemDesc.Controls.Add(Me.lblCharge_ItemNo)
        Me.panItemDesc.Controls.Add(Me.cboCharge)
        Me.panItemDesc.Controls.Add(Me.lblCharge)
        Me.panItemDesc.Controls.Add(Me.txtRunCharge)
        Me.panItemDesc.Controls.Add(Me.lblRunCharge)
        Me.panItemDesc.Controls.Add(Me.cboDecoMetod)
        Me.panItemDesc.Controls.Add(Me.lblDecoMetods)
        Me.panItemDesc.Controls.Add(Me.txtSetup)
        Me.panItemDesc.Controls.Add(Me.lblSetup)
        Me.panItemDesc.Controls.Add(Me.txtCurrency)
        Me.panItemDesc.Controls.Add(Me.lblCurr)
        Me.panItemDesc.Controls.Add(Me.txtQty)
        Me.panItemDesc.Controls.Add(Me.lblQty)
        Me.panItemDesc.Controls.Add(Me.lblCusNo)
        Me.panItemDesc.Controls.Add(Me.txtCusNo)
        Me.panItemDesc.Controls.Add(Me.btnAdd)
        Me.panItemDesc.Controls.Add(Me.lblItemDesc)
        Me.panItemDesc.Controls.Add(Me.txtItemCd)
        Me.panItemDesc.Controls.Add(Me.lblItem_Cd)
        Me.panItemDesc.Controls.Add(Me.panResize)
        Me.panItemDesc.Controls.Add(Me.cboColor)
        Me.panItemDesc.Controls.Add(Me.lblColor)
        Me.panItemDesc.Location = New System.Drawing.Point(440, 11)
        Me.panItemDesc.Name = "panItemDesc"
        Me.panItemDesc.Size = New System.Drawing.Size(376, 215)
        Me.panItemDesc.TabIndex = 0
        '
        'lblCharge_ItemNo
        '
        Me.lblCharge_ItemNo.AutoSize = True
        Me.lblCharge_ItemNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharge_ItemNo.Location = New System.Drawing.Point(82, 106)
        Me.lblCharge_ItemNo.Name = "lblCharge_ItemNo"
        Me.lblCharge_ItemNo.Size = New System.Drawing.Size(54, 17)
        Me.lblCharge_ItemNo.TabIndex = 21
        Me.lblCharge_ItemNo.Text = "Charge"
        '
        'cboCharge
        '
        Me.cboCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCharge.FormattingEnabled = True
        Me.cboCharge.Location = New System.Drawing.Point(79, 82)
        Me.cboCharge.Name = "cboCharge"
        Me.cboCharge.Size = New System.Drawing.Size(145, 25)
        Me.cboCharge.TabIndex = 20
        '
        'lblCharge
        '
        Me.lblCharge.AutoSize = True
        Me.lblCharge.Location = New System.Drawing.Point(6, 85)
        Me.lblCharge.Name = "lblCharge"
        Me.lblCharge.Size = New System.Drawing.Size(63, 20)
        Me.lblCharge.TabIndex = 19
        Me.lblCharge.Text = "Charge"
        '
        'txtRunCharge
        '
        Me.txtRunCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunCharge.Location = New System.Drawing.Point(306, 82)
        Me.txtRunCharge.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRunCharge.Name = "txtRunCharge"
        Me.txtRunCharge.Size = New System.Drawing.Size(60, 26)
        Me.txtRunCharge.TabIndex = 17
        '
        'lblRunCharge
        '
        Me.lblRunCharge.AutoSize = True
        Me.lblRunCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunCharge.Location = New System.Drawing.Point(225, 85)
        Me.lblRunCharge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRunCharge.Name = "lblRunCharge"
        Me.lblRunCharge.Size = New System.Drawing.Size(98, 20)
        Me.lblRunCharge.TabIndex = 18
        Me.lblRunCharge.Text = "Run Charge"
        '
        'cboDecoMetod
        '
        Me.cboDecoMetod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDecoMetod.FormattingEnabled = True
        Me.cboDecoMetod.Location = New System.Drawing.Point(80, 56)
        Me.cboDecoMetod.Name = "cboDecoMetod"
        Me.cboDecoMetod.Size = New System.Drawing.Size(129, 25)
        Me.cboDecoMetod.TabIndex = 16
        '
        'lblDecoMetods
        '
        Me.lblDecoMetods.AutoSize = True
        Me.lblDecoMetods.Location = New System.Drawing.Point(6, 57)
        Me.lblDecoMetods.Name = "lblDecoMetods"
        Me.lblDecoMetods.Size = New System.Drawing.Size(91, 20)
        Me.lblDecoMetods.TabIndex = 15
        Me.lblDecoMetods.Text = "Decorating"
        '
        'txtSetup
        '
        Me.txtSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetup.Location = New System.Drawing.Point(306, 55)
        Me.txtSetup.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSetup.Name = "txtSetup"
        Me.txtSetup.Size = New System.Drawing.Size(60, 26)
        Me.txtSetup.TabIndex = 5
        '
        'lblSetup
        '
        Me.lblSetup.AutoSize = True
        Me.lblSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetup.Location = New System.Drawing.Point(225, 58)
        Me.lblSetup.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSetup.Name = "lblSetup"
        Me.lblSetup.Size = New System.Drawing.Size(83, 20)
        Me.lblSetup.TabIndex = 14
        Me.lblSetup.Text = "Setup Net"
        '
        'txtCurrency
        '
        Me.txtCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Location = New System.Drawing.Point(288, 3)
        Me.txtCurrency.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(78, 26)
        Me.txtCurrency.TabIndex = 2
        '
        'lblCurr
        '
        Me.lblCurr.AutoSize = True
        Me.lblCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurr.Location = New System.Drawing.Point(225, 6)
        Me.lblCurr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurr.Name = "lblCurr"
        Me.lblCurr.Size = New System.Drawing.Size(77, 20)
        Me.lblCurr.TabIndex = 0
        Me.lblCurr.Text = "Currency"
        '
        'txtQty
        '
        Me.txtQty.Enabled = False
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(306, 125)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(60, 26)
        Me.txtQty.TabIndex = 4
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.Location = New System.Drawing.Point(270, 128)
        Me.lblQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(35, 20)
        Me.lblQty.TabIndex = 10
        Me.lblQty.Text = "Qty"
        '
        'lblCusNo
        '
        Me.lblCusNo.AutoSize = True
        Me.lblCusNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCusNo.Location = New System.Drawing.Point(5, 6)
        Me.lblCusNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCusNo.Name = "lblCusNo"
        Me.lblCusNo.Size = New System.Drawing.Size(65, 20)
        Me.lblCusNo.TabIndex = 0
        Me.lblCusNo.Text = "Cus No"
        '
        'txtCusNo
        '
        Me.txtCusNo.Location = New System.Drawing.Point(80, 3)
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(129, 26)
        Me.txtCusNo.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(281, 191)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 23)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "Add in Box"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'panResize
        '
        Me.panResize.Controls.Add(Me.lblDepth)
        Me.panResize.Controls.Add(Me.txtDepth)
        Me.panResize.Controls.Add(Me.lblinch1)
        Me.panResize.Controls.Add(Me.lblHeight)
        Me.panResize.Controls.Add(Me.lblWidth)
        Me.panResize.Controls.Add(Me.btnResize)
        Me.panResize.Controls.Add(Me.txtHeight)
        Me.panResize.Controls.Add(Me.txtWidth)
        Me.panResize.Location = New System.Drawing.Point(8, 151)
        Me.panResize.Name = "panResize"
        Me.panResize.Size = New System.Drawing.Size(361, 37)
        Me.panResize.TabIndex = 0
        '
        'lblDepth
        '
        Me.lblDepth.AutoSize = True
        Me.lblDepth.Location = New System.Drawing.Point(135, 10)
        Me.lblDepth.Name = "lblDepth"
        Me.lblDepth.Size = New System.Drawing.Size(30, 20)
        Me.lblDepth.TabIndex = 17
        Me.lblDepth.Text = "(Z)"
        '
        'txtDepth
        '
        Me.txtDepth.Location = New System.Drawing.Point(161, 7)
        Me.txtDepth.Name = "txtDepth"
        Me.txtDepth.Size = New System.Drawing.Size(40, 26)
        Me.txtDepth.TabIndex = 9
        '
        'lblinch1
        '
        Me.lblinch1.AutoSize = True
        Me.lblinch1.Location = New System.Drawing.Point(201, 10)
        Me.lblinch1.Name = "lblinch1"
        Me.lblinch1.Size = New System.Drawing.Size(94, 20)
        Me.lblinch1.TabIndex = 14
        Me.lblinch1.Text = "(All in inch)"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(68, 10)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(31, 20)
        Me.lblHeight.TabIndex = 13
        Me.lblHeight.Text = "(Y)"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(3, 10)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(32, 20)
        Me.lblWidth.TabIndex = 12
        Me.lblWidth.Text = "(X)"
        '
        'btnResize
        '
        Me.btnResize.Location = New System.Drawing.Point(276, 7)
        Me.btnResize.Name = "btnResize"
        Me.btnResize.Size = New System.Drawing.Size(82, 22)
        Me.btnResize.TabIndex = 10
        Me.btnResize.Text = "RESIZE"
        Me.btnResize.UseVisualStyleBackColor = True
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(93, 7)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(40, 26)
        Me.txtHeight.TabIndex = 8
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(27, 7)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(40, 26)
        Me.txtWidth.TabIndex = 7
        '
        'panDgvItemDesc
        '
        Me.panDgvItemDesc.Controls.Add(Me.panResult)
        Me.panDgvItemDesc.Controls.Add(Me.panDgvItems)
        Me.panDgvItemDesc.Controls.Add(Me.tsTop)
        Me.panDgvItemDesc.Controls.Add(Me.ToolStripContainer1)
        Me.panDgvItemDesc.Location = New System.Drawing.Point(441, 229)
        Me.panDgvItemDesc.Name = "panDgvItemDesc"
        Me.panDgvItemDesc.Size = New System.Drawing.Size(375, 254)
        Me.panDgvItemDesc.TabIndex = 14
        '
        'panResult
        '
        Me.panResult.Controls.Add(Me.dgvResult)
        Me.panResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panResult.Location = New System.Drawing.Point(0, 233)
        Me.panResult.Name = "panResult"
        Me.panResult.Size = New System.Drawing.Size(375, 21)
        Me.panResult.TabIndex = 17
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResult.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.Location = New System.Drawing.Point(0, 0)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvResult.Size = New System.Drawing.Size(375, 21)
        Me.dgvResult.TabIndex = 0
        '
        'panDgvItems
        '
        Me.panDgvItems.Controls.Add(Me.dgvItem)
        Me.panDgvItems.Dock = System.Windows.Forms.DockStyle.Top
        Me.panDgvItems.Location = New System.Drawing.Point(0, 27)
        Me.panDgvItems.Name = "panDgvItems"
        Me.panDgvItems.Size = New System.Drawing.Size(375, 206)
        Me.panDgvItems.TabIndex = 16
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvItem.Size = New System.Drawing.Size(375, 206)
        Me.dgvItem.TabIndex = 0
        '
        'tsTop
        '
        Me.tsTop.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnDelete, Me.tsRefresh, Me.tlStripBtnAddBox})
        Me.tsTop.Location = New System.Drawing.Point(0, 0)
        Me.tsTop.Name = "tsTop"
        Me.tsTop.Size = New System.Drawing.Size(375, 27)
        Me.tsTop.TabIndex = 0
        Me.tsTop.Text = "ToolStrip1"
        '
        'tsBtnDelete
        '
        Me.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsBtnDelete.Image = CType(resources.GetObject("tsBtnDelete.Image"), System.Drawing.Image)
        Me.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnDelete.Name = "tsBtnDelete"
        Me.tsBtnDelete.Size = New System.Drawing.Size(90, 24)
        Me.tsBtnDelete.Text = "Delete Row"
        '
        'tsRefresh
        '
        Me.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(62, 24)
        Me.tsRefresh.Text = "Refresh"
        Me.tsRefresh.Visible = False
        '
        'tlStripBtnAddBox
        '
        Me.tlStripBtnAddBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlStripBtnAddBox.Image = CType(resources.GetObject("tlStripBtnAddBox.Image"), System.Drawing.Image)
        Me.tlStripBtnAddBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlStripBtnAddBox.Name = "tlStripBtnAddBox"
        Me.tlStripBtnAddBox.Size = New System.Drawing.Size(70, 24)
        Me.tlStripBtnAddBox.Text = "Add Box"
        Me.tlStripBtnAddBox.Visible = False
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(8, 0)
        Me.ToolStripContainer1.Location = New System.Drawing.Point(8, 3)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(8, 8)
        Me.ToolStripContainer1.TabIndex = 13
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(144, 438)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel.TabIndex = 0
        Me.btnExcel.Text = "Excel Button"
        Me.btnExcel.UseVisualStyleBackColor = True
        Me.btnExcel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 415)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'btnAddImage
        '
        Me.btnAddImage.Location = New System.Drawing.Point(74, 415)
        Me.btnAddImage.Name = "btnAddImage"
        Me.btnAddImage.Size = New System.Drawing.Size(205, 23)
        Me.btnAddImage.TabIndex = 0
        Me.btnAddImage.Text = "Add Image in Item_Pictures"
        Me.btnAddImage.UseVisualStyleBackColor = True
        Me.btnAddImage.Visible = False
        '
        'opFile
        '
        Me.opFile.FileName = "OpenFileDialog1"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(-7, 434)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(42, 382)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(384, 20)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 382)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "X"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Y"
        '
        'txtPriceSet
        '
        Me.txtPriceSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceSet.Location = New System.Drawing.Point(475, 483)
        Me.txtPriceSet.Name = "txtPriceSet"
        Me.txtPriceSet.ReadOnly = True
        Me.txtPriceSet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPriceSet.Size = New System.Drawing.Size(222, 26)
        Me.txtPriceSet.TabIndex = 19
        Me.txtPriceSet.Visible = False
        '
        'frmItem_Picture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 483)
        Me.Controls.Add(Me.txtPriceSet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnAddImage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.panDgvItemDesc)
        Me.Controls.Add(Me.panItemDesc)
        Me.Controls.Add(Me.btnCustomized)
        Me.Controls.Add(Me.panPictBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItem_Picture"
        Me.Text = "Items"
        Me.panPictBox.ResumeLayout(False)
        CType(Me.pictBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panItemDesc.ResumeLayout(False)
        Me.panItemDesc.PerformLayout()
        Me.panResize.ResumeLayout(False)
        Me.panResize.PerformLayout()
        Me.panDgvItemDesc.ResumeLayout(False)
        Me.panDgvItemDesc.PerformLayout()
        Me.panResult.ResumeLayout(False)
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panDgvItems.ResumeLayout(False)
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsTop.ResumeLayout(False)
        Me.tsTop.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtItemCd As System.Windows.Forms.TextBox
    Friend WithEvents lblItem_Cd As System.Windows.Forms.Label
    Friend WithEvents lblItemDesc As System.Windows.Forms.Label
    Friend WithEvents cboColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents panPictBox As System.Windows.Forms.Panel
    Friend WithEvents pictBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnCustomized As System.Windows.Forms.Button
    Friend WithEvents panItemDesc As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents panDgvItemDesc As System.Windows.Forms.Panel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents tsTop As System.Windows.Forms.ToolStrip
    Friend WithEvents tsBtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddImage As System.Windows.Forms.Button
    Friend WithEvents opFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblCusNo As System.Windows.Forms.Label
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents lblCurr As System.Windows.Forms.Label
    Friend WithEvents txtSetup As System.Windows.Forms.TextBox
    Friend WithEvents lblSetup As System.Windows.Forms.Label
    Friend WithEvents panResult As System.Windows.Forms.Panel
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents panDgvItems As System.Windows.Forms.Panel
    Friend WithEvents tlStripBtnAddBox As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPriceSet As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents btnResize As System.Windows.Forms.Button
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblinch1 As System.Windows.Forms.Label
    Friend WithEvents txtDepth As System.Windows.Forms.TextBox
    Friend WithEvents lblDepth As System.Windows.Forms.Label
    Friend WithEvents panResize As System.Windows.Forms.Panel
    Friend WithEvents cboCharge As System.Windows.Forms.ComboBox
    Friend WithEvents lblCharge As System.Windows.Forms.Label
    Friend WithEvents txtRunCharge As System.Windows.Forms.TextBox
    Friend WithEvents lblRunCharge As System.Windows.Forms.Label
    Friend WithEvents cboDecoMetod As System.Windows.Forms.ComboBox
    Friend WithEvents lblDecoMetods As System.Windows.Forms.Label
    Friend WithEvents lblCharge_ItemNo As System.Windows.Forms.Label
End Class
