<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrders
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
        Me.panQuickSearch = New System.Windows.Forms.Panel()
        Me.chkEDI = New System.Windows.Forms.CheckBox()
        Me.txtLastXOrders = New CustomerFile.xTextBox()
        Me.lblLastXOrders = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.rbAndSearch = New System.Windows.Forms.RadioButton()
        Me.rbOrSearch = New System.Windows.Forms.RadioButton()
        Me.chkAIO_CurOrd_Quo = New System.Windows.Forms.CheckBox()
        Me.txtAIO_CurOrd_LastDays = New CustomerFile.xTextBox()
        Me.lblAIO_CurOrd_LastDays = New System.Windows.Forms.Label()
        Me.chkAIO_CurOrd_BOOnly = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_RepeatsOnly = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_Ship = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_PartShip = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_NotShip = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_RMA = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_Cre = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_Inv = New System.Windows.Forms.CheckBox()
        Me.chkAIO_CurOrd_Ord = New System.Windows.Forms.CheckBox()
        Me.panExtSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiDisruption = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tssRecordCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panQuickSearch.SuspendLayout()
        Me.panExtSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panData.SuspendLayout()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMenu.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'panQuickSearch
        '
        Me.panQuickSearch.Controls.Add(Me.chkEDI)
        Me.panQuickSearch.Controls.Add(Me.txtLastXOrders)
        Me.panQuickSearch.Controls.Add(Me.lblLastXOrders)
        Me.panQuickSearch.Controls.Add(Me.lblSearch)
        Me.panQuickSearch.Controls.Add(Me.rbAndSearch)
        Me.panQuickSearch.Controls.Add(Me.rbOrSearch)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_Quo)
        Me.panQuickSearch.Controls.Add(Me.txtAIO_CurOrd_LastDays)
        Me.panQuickSearch.Controls.Add(Me.lblAIO_CurOrd_LastDays)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_BOOnly)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_RepeatsOnly)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_Ship)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_PartShip)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_NotShip)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_RMA)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_Cre)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_Inv)
        Me.panQuickSearch.Controls.Add(Me.chkAIO_CurOrd_Ord)
        Me.panQuickSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panQuickSearch.Location = New System.Drawing.Point(0, 0)
        Me.panQuickSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panQuickSearch.Name = "panQuickSearch"
        Me.panQuickSearch.Size = New System.Drawing.Size(645, 45)
        Me.panQuickSearch.TabIndex = 0
        '
        'chkEDI
        '
        Me.chkEDI.AutoSize = True
        Me.chkEDI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEDI.Location = New System.Drawing.Point(277, 0)
        Me.chkEDI.Margin = New System.Windows.Forms.Padding(1)
        Me.chkEDI.Name = "chkEDI"
        Me.chkEDI.Padding = New System.Windows.Forms.Padding(1)
        Me.chkEDI.Size = New System.Drawing.Size(48, 21)
        Me.chkEDI.TabIndex = 125
        Me.chkEDI.Text = "EDI"
        Me.chkEDI.UseVisualStyleBackColor = True
        '
        'txtLastXOrders
        '
        Me.txtLastXOrders.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtLastXOrders.DataLength = CType(0, Long)
        Me.txtLastXOrders.DataType = CustomerFile.CDataType.dtString
        Me.txtLastXOrders.DateValue = New Date(CType(0, Long))
        Me.txtLastXOrders.DecimalDigits = CType(0, Long)
        Me.txtLastXOrders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastXOrders.Location = New System.Drawing.Point(361, 21)
        Me.txtLastXOrders.Margin = New System.Windows.Forms.Padding(1)
        Me.txtLastXOrders.Mask = Nothing
        Me.txtLastXOrders.Name = "txtLastXOrders"
        Me.txtLastXOrders.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLastXOrders.OldValue = Nothing
        Me.txtLastXOrders.Size = New System.Drawing.Size(39, 21)
        Me.txtLastXOrders.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtLastXOrders.StringValue = Nothing
        Me.txtLastXOrders.TabIndex = 124
        Me.txtLastXOrders.TextDataID = Nothing
        Me.txtLastXOrders.Visible = False
        '
        'lblLastXOrders
        '
        Me.lblLastXOrders.BackColor = System.Drawing.SystemColors.Control
        Me.lblLastXOrders.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLastXOrders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastXOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastXOrders.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLastXOrders.Location = New System.Drawing.Point(327, 23)
        Me.lblLastXOrders.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLastXOrders.Name = "lblLastXOrders"
        Me.lblLastXOrders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLastXOrders.Size = New System.Drawing.Size(121, 18)
        Me.lblLastXOrders.TabIndex = 123
        Me.lblLastXOrders.Text = "Last                 orders"
        Me.lblLastXOrders.Visible = False
        '
        'lblSearch
        '
        Me.lblSearch.BackColor = System.Drawing.SystemColors.Control
        Me.lblSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSearch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(457, 25)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSearch.Size = New System.Drawing.Size(56, 19)
        Me.lblSearch.TabIndex = 122
        Me.lblSearch.Text = "Search : "
        '
        'rbAndSearch
        '
        Me.rbAndSearch.AutoSize = True
        Me.rbAndSearch.Checked = True
        Me.rbAndSearch.Location = New System.Drawing.Point(566, 23)
        Me.rbAndSearch.Name = "rbAndSearch"
        Me.rbAndSearch.Size = New System.Drawing.Size(50, 19)
        Me.rbAndSearch.TabIndex = 121
        Me.rbAndSearch.TabStop = True
        Me.rbAndSearch.Text = "AND"
        Me.rbAndSearch.UseVisualStyleBackColor = True
        '
        'rbOrSearch
        '
        Me.rbOrSearch.AutoSize = True
        Me.rbOrSearch.Location = New System.Drawing.Point(517, 23)
        Me.rbOrSearch.Name = "rbOrSearch"
        Me.rbOrSearch.Size = New System.Drawing.Size(43, 19)
        Me.rbOrSearch.TabIndex = 120
        Me.rbOrSearch.Text = "OR"
        Me.rbOrSearch.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_Quo
        '
        Me.chkAIO_CurOrd_Quo.AutoSize = True
        Me.chkAIO_CurOrd_Quo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_Quo.Location = New System.Drawing.Point(220, 0)
        Me.chkAIO_CurOrd_Quo.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Quo.Name = "chkAIO_CurOrd_Quo"
        Me.chkAIO_CurOrd_Quo.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Quo.Size = New System.Drawing.Size(55, 21)
        Me.chkAIO_CurOrd_Quo.TabIndex = 119
        Me.chkAIO_CurOrd_Quo.Text = "QUO"
        Me.chkAIO_CurOrd_Quo.UseVisualStyleBackColor = True
        '
        'txtAIO_CurOrd_LastDays
        '
        Me.txtAIO_CurOrd_LastDays.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtAIO_CurOrd_LastDays.DataLength = CType(0, Long)
        Me.txtAIO_CurOrd_LastDays.DataType = CustomerFile.CDataType.dtString
        Me.txtAIO_CurOrd_LastDays.DateValue = New Date(CType(0, Long))
        Me.txtAIO_CurOrd_LastDays.DecimalDigits = CType(0, Long)
        Me.txtAIO_CurOrd_LastDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAIO_CurOrd_LastDays.Location = New System.Drawing.Point(361, -1)
        Me.txtAIO_CurOrd_LastDays.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAIO_CurOrd_LastDays.Mask = Nothing
        Me.txtAIO_CurOrd_LastDays.Name = "txtAIO_CurOrd_LastDays"
        Me.txtAIO_CurOrd_LastDays.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAIO_CurOrd_LastDays.OldValue = Nothing
        Me.txtAIO_CurOrd_LastDays.Size = New System.Drawing.Size(39, 21)
        Me.txtAIO_CurOrd_LastDays.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtAIO_CurOrd_LastDays.StringValue = Nothing
        Me.txtAIO_CurOrd_LastDays.TabIndex = 118
        Me.txtAIO_CurOrd_LastDays.Text = "30"
        Me.txtAIO_CurOrd_LastDays.TextDataID = Nothing
        '
        'lblAIO_CurOrd_LastDays
        '
        Me.lblAIO_CurOrd_LastDays.BackColor = System.Drawing.SystemColors.Control
        Me.lblAIO_CurOrd_LastDays.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAIO_CurOrd_LastDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAIO_CurOrd_LastDays.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAIO_CurOrd_LastDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAIO_CurOrd_LastDays.Location = New System.Drawing.Point(327, 2)
        Me.lblAIO_CurOrd_LastDays.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAIO_CurOrd_LastDays.Name = "lblAIO_CurOrd_LastDays"
        Me.lblAIO_CurOrd_LastDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAIO_CurOrd_LastDays.Size = New System.Drawing.Size(121, 18)
        Me.lblAIO_CurOrd_LastDays.TabIndex = 117
        Me.lblAIO_CurOrd_LastDays.Text = "Last                 days"
        '
        'chkAIO_CurOrd_BOOnly
        '
        Me.chkAIO_CurOrd_BOOnly.AutoSize = True
        Me.chkAIO_CurOrd_BOOnly.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_BOOnly.Location = New System.Drawing.Point(566, 1)
        Me.chkAIO_CurOrd_BOOnly.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_BOOnly.Name = "chkAIO_CurOrd_BOOnly"
        Me.chkAIO_CurOrd_BOOnly.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_BOOnly.Size = New System.Drawing.Size(73, 21)
        Me.chkAIO_CurOrd_BOOnly.TabIndex = 116
        Me.chkAIO_CurOrd_BOOnly.Text = "B/O only"
        Me.chkAIO_CurOrd_BOOnly.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_RepeatsOnly
        '
        Me.chkAIO_CurOrd_RepeatsOnly.AutoSize = True
        Me.chkAIO_CurOrd_RepeatsOnly.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_RepeatsOnly.Location = New System.Drawing.Point(464, 1)
        Me.chkAIO_CurOrd_RepeatsOnly.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_RepeatsOnly.Name = "chkAIO_CurOrd_RepeatsOnly"
        Me.chkAIO_CurOrd_RepeatsOnly.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_RepeatsOnly.Size = New System.Drawing.Size(100, 21)
        Me.chkAIO_CurOrd_RepeatsOnly.TabIndex = 115
        Me.chkAIO_CurOrd_RepeatsOnly.Text = "Repeats only"
        Me.chkAIO_CurOrd_RepeatsOnly.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_Ship
        '
        Me.chkAIO_CurOrd_Ship.AutoSize = True
        Me.chkAIO_CurOrd_Ship.Checked = True
        Me.chkAIO_CurOrd_Ship.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAIO_CurOrd_Ship.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_Ship.Location = New System.Drawing.Point(220, 23)
        Me.chkAIO_CurOrd_Ship.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Ship.Name = "chkAIO_CurOrd_Ship"
        Me.chkAIO_CurOrd_Ship.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Ship.Size = New System.Drawing.Size(74, 21)
        Me.chkAIO_CurOrd_Ship.TabIndex = 114
        Me.chkAIO_CurOrd_Ship.Text = "Shipped"
        Me.chkAIO_CurOrd_Ship.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_PartShip
        '
        Me.chkAIO_CurOrd_PartShip.AutoSize = True
        Me.chkAIO_CurOrd_PartShip.Checked = True
        Me.chkAIO_CurOrd_PartShip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAIO_CurOrd_PartShip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_PartShip.Location = New System.Drawing.Point(99, 23)
        Me.chkAIO_CurOrd_PartShip.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_PartShip.Name = "chkAIO_CurOrd_PartShip"
        Me.chkAIO_CurOrd_PartShip.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_PartShip.Size = New System.Drawing.Size(119, 21)
        Me.chkAIO_CurOrd_PartShip.TabIndex = 113
        Me.chkAIO_CurOrd_PartShip.Text = "Partially shipped"
        Me.chkAIO_CurOrd_PartShip.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_NotShip
        '
        Me.chkAIO_CurOrd_NotShip.AutoSize = True
        Me.chkAIO_CurOrd_NotShip.Checked = True
        Me.chkAIO_CurOrd_NotShip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAIO_CurOrd_NotShip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_NotShip.Location = New System.Drawing.Point(3, 23)
        Me.chkAIO_CurOrd_NotShip.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_NotShip.Name = "chkAIO_CurOrd_NotShip"
        Me.chkAIO_CurOrd_NotShip.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_NotShip.Size = New System.Drawing.Size(95, 21)
        Me.chkAIO_CurOrd_NotShip.TabIndex = 112
        Me.chkAIO_CurOrd_NotShip.Text = "Not shipped"
        Me.chkAIO_CurOrd_NotShip.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_RMA
        '
        Me.chkAIO_CurOrd_RMA.AutoSize = True
        Me.chkAIO_CurOrd_RMA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_RMA.Location = New System.Drawing.Point(165, 1)
        Me.chkAIO_CurOrd_RMA.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_RMA.Name = "chkAIO_CurOrd_RMA"
        Me.chkAIO_CurOrd_RMA.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_RMA.Size = New System.Drawing.Size(53, 21)
        Me.chkAIO_CurOrd_RMA.TabIndex = 111
        Me.chkAIO_CurOrd_RMA.Text = "RMA"
        Me.chkAIO_CurOrd_RMA.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_Cre
        '
        Me.chkAIO_CurOrd_Cre.AutoSize = True
        Me.chkAIO_CurOrd_Cre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_Cre.Location = New System.Drawing.Point(109, 1)
        Me.chkAIO_CurOrd_Cre.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Cre.Name = "chkAIO_CurOrd_Cre"
        Me.chkAIO_CurOrd_Cre.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Cre.Size = New System.Drawing.Size(54, 21)
        Me.chkAIO_CurOrd_Cre.TabIndex = 110
        Me.chkAIO_CurOrd_Cre.Text = "CRE"
        Me.chkAIO_CurOrd_Cre.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_Inv
        '
        Me.chkAIO_CurOrd_Inv.AutoSize = True
        Me.chkAIO_CurOrd_Inv.Checked = True
        Me.chkAIO_CurOrd_Inv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAIO_CurOrd_Inv.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_Inv.Location = New System.Drawing.Point(60, 0)
        Me.chkAIO_CurOrd_Inv.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Inv.Name = "chkAIO_CurOrd_Inv"
        Me.chkAIO_CurOrd_Inv.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Inv.Size = New System.Drawing.Size(47, 21)
        Me.chkAIO_CurOrd_Inv.TabIndex = 109
        Me.chkAIO_CurOrd_Inv.Text = "INV"
        Me.chkAIO_CurOrd_Inv.UseVisualStyleBackColor = True
        '
        'chkAIO_CurOrd_Ord
        '
        Me.chkAIO_CurOrd_Ord.AutoSize = True
        Me.chkAIO_CurOrd_Ord.Checked = True
        Me.chkAIO_CurOrd_Ord.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAIO_CurOrd_Ord.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAIO_CurOrd_Ord.Location = New System.Drawing.Point(3, 1)
        Me.chkAIO_CurOrd_Ord.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Ord.Name = "chkAIO_CurOrd_Ord"
        Me.chkAIO_CurOrd_Ord.Padding = New System.Windows.Forms.Padding(1)
        Me.chkAIO_CurOrd_Ord.Size = New System.Drawing.Size(55, 21)
        Me.chkAIO_CurOrd_Ord.TabIndex = 108
        Me.chkAIO_CurOrd_Ord.Text = "ORD"
        Me.chkAIO_CurOrd_Ord.UseVisualStyleBackColor = True
        '
        'panExtSearch
        '
        Me.panExtSearch.Controls.Add(Me.dgvSearch)
        Me.panExtSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.panExtSearch.Location = New System.Drawing.Point(0, 45)
        Me.panExtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.panExtSearch.Name = "panExtSearch"
        Me.panExtSearch.Size = New System.Drawing.Size(645, 45)
        Me.panExtSearch.TabIndex = 3
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
        Me.dgvSearch.Size = New System.Drawing.Size(645, 45)
        Me.dgvSearch.TabIndex = 0
        '
        'panData
        '
        Me.panData.Controls.Add(Me.dgvOrders)
        Me.panData.Controls.Add(Me.ssStatus)
        Me.panData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panData.Location = New System.Drawing.Point(0, 90)
        Me.panData.Margin = New System.Windows.Forms.Padding(0)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(645, 235)
        Me.panData.TabIndex = 4
        '
        'dgvOrders
        '
        Me.dgvOrders.AllowUserToAddRows = False
        Me.dgvOrders.AllowUserToDeleteRows = False
        Me.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrders.ContextMenuStrip = Me.cmsMenu
        Me.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrders.Location = New System.Drawing.Point(0, 0)
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.ReadOnly = True
        Me.dgvOrders.RowHeadersWidth = 25
        Me.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrders.Size = New System.Drawing.Size(645, 213)
        Me.dgvOrders.TabIndex = 6
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiDisruption})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(153, 48)
        '
        'tsmiDisruption
        '
        Me.tsmiDisruption.Name = "tsmiDisruption"
        Me.tsmiDisruption.Size = New System.Drawing.Size(152, 22)
        Me.tsmiDisruption.Text = "Disruption"
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRecordCount})
        Me.ssStatus.Location = New System.Drawing.Point(0, 213)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(645, 22)
        Me.ssStatus.TabIndex = 5
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tssRecordCount
        '
        Me.tssRecordCount.Name = "tssRecordCount"
        Me.tssRecordCount.Size = New System.Drawing.Size(59, 17)
        Me.tssRecordCount.Text = "Records: 0"
        '
        'ucOrders
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.panExtSearch)
        Me.Controls.Add(Me.panQuickSearch)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ucOrders"
        Me.Size = New System.Drawing.Size(645, 325)
        Me.Tag = "CF-CTL-ORD-001"
        Me.panQuickSearch.ResumeLayout(False)
        Me.panQuickSearch.PerformLayout()
        Me.panExtSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panData.ResumeLayout(False)
        Me.panData.PerformLayout()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMenu.ResumeLayout(False)
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panQuickSearch As System.Windows.Forms.Panel
    Friend WithEvents chkAIO_CurOrd_Quo As System.Windows.Forms.CheckBox
    Friend WithEvents txtAIO_CurOrd_LastDays As CustomerFile.xTextBox
    Friend WithEvents lblAIO_CurOrd_LastDays As System.Windows.Forms.Label
    Friend WithEvents chkAIO_CurOrd_BOOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_RepeatsOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_Ship As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_PartShip As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_NotShip As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_RMA As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_Cre As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_Inv As System.Windows.Forms.CheckBox
    Friend WithEvents chkAIO_CurOrd_Ord As System.Windows.Forms.CheckBox
    Friend WithEvents panExtSearch As System.Windows.Forms.Panel
    Friend WithEvents panData As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents rbAndSearch As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrSearch As System.Windows.Forms.RadioButton
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvOrders As System.Windows.Forms.DataGridView
    Friend WithEvents txtLastXOrders As CustomerFile.xTextBox
    Friend WithEvents lblLastXOrders As System.Windows.Forms.Label
    Friend WithEvents chkEDI As System.Windows.Forms.CheckBox
    Friend WithEvents cmsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiDisruption As System.Windows.Forms.ToolStripMenuItem

End Class
