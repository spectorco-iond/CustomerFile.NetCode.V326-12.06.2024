<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomer_Disruption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomer_Disruption))
        Me.lblCus_No = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.dgvDisruption = New System.Windows.Forms.DataGridView()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.txtOrd_No = New CustomerFile.xTextBox()
        Me.txtCmp_Name = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.tsMenu.SuspendLayout()
        CType(Me.dgvDisruption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCus_No
        '
        Me.lblCus_No.AutoSize = True
        Me.lblCus_No.Location = New System.Drawing.Point(10, 38)
        Me.lblCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_No.Name = "lblCus_No"
        Me.lblCus_No.Size = New System.Drawing.Size(62, 15)
        Me.lblCus_No.TabIndex = 1
        Me.lblCus_No.Text = "Customer"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1072, 25)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(35, 22)
        Me.tsbSave.Text = "Save"
        '
        'dgvDisruption
        '
        Me.dgvDisruption.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDisruption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDisruption.Location = New System.Drawing.Point(12, 81)
        Me.dgvDisruption.Margin = New System.Windows.Forms.Padding(1)
        Me.dgvDisruption.Name = "dgvDisruption"
        Me.dgvDisruption.Size = New System.Drawing.Size(1048, 283)
        Me.dgvDisruption.TabIndex = 5
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Location = New System.Drawing.Point(10, 61)
        Me.lblOrder.Margin = New System.Windows.Forms.Padding(1)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(38, 15)
        Me.lblOrder.TabIndex = 6
        Me.lblOrder.Text = "Order"
        '
        'txtOrd_No
        '
        Me.txtOrd_No.CharacterInput = CustomerFile.Cinput.CharactersOnly
        Me.txtOrd_No.DataLength = CType(8, Long)
        Me.txtOrd_No.DataType = CustomerFile.CDataType.dtString
        Me.txtOrd_No.DateValue = New Date(CType(0, Long))
        Me.txtOrd_No.DecimalDigits = CType(0, Long)
        Me.txtOrd_No.Enabled = False
        Me.txtOrd_No.Location = New System.Drawing.Point(77, 58)
        Me.txtOrd_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOrd_No.Mask = Nothing
        Me.txtOrd_No.Name = "txtOrd_No"
        Me.txtOrd_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd_No.OldValue = ""
        Me.txtOrd_No.Size = New System.Drawing.Size(80, 21)
        Me.txtOrd_No.SpacePadding = CustomerFile.CSpacePadding.PaddingBefore
        Me.txtOrd_No.StringValue = Nothing
        Me.txtOrd_No.TabIndex = 7
        Me.txtOrd_No.TextDataID = Nothing
        '
        'txtCmp_Name
        '
        Me.txtCmp_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCmp_Name.CharacterInput = CustomerFile.Cinput.CharactersOnly
        Me.txtCmp_Name.DataLength = CType(0, Long)
        Me.txtCmp_Name.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_Name.DateValue = New Date(CType(0, Long))
        Me.txtCmp_Name.DecimalDigits = CType(0, Long)
        Me.txtCmp_Name.Enabled = False
        Me.txtCmp_Name.Location = New System.Drawing.Point(159, 35)
        Me.txtCmp_Name.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_Name.Mask = Nothing
        Me.txtCmp_Name.Name = "txtCmp_Name"
        Me.txtCmp_Name.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_Name.OldValue = ""
        Me.txtCmp_Name.Size = New System.Drawing.Size(903, 21)
        Me.txtCmp_Name.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_Name.StringValue = Nothing
        Me.txtCmp_Name.TabIndex = 4
        Me.txtCmp_Name.TextDataID = Nothing
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.CharactersOnly
        Me.txtCus_No.DataLength = CType(0, Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0, Long))
        Me.txtCus_No.DecimalDigits = CType(0, Long)
        Me.txtCus_No.Enabled = False
        Me.txtCus_No.Location = New System.Drawing.Point(77, 35)
        Me.txtCus_No.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = ""
        Me.txtCus_No.Size = New System.Drawing.Size(80, 21)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 2
        Me.txtCus_No.TextDataID = Nothing
        '
        'frmCustomer_Disruption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 376)
        Me.Controls.Add(Me.txtOrd_No)
        Me.Controls.Add(Me.lblOrder)
        Me.Controls.Add(Me.dgvDisruption)
        Me.Controls.Add(Me.txtCmp_Name)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.lblCus_No)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "frmCustomer_Disruption"
        Me.Text = "Customer Disruption"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.dgvDisruption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCus_No As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCmp_Name As CustomerFile.xTextBox
    Friend WithEvents dgvDisruption As System.Windows.Forms.DataGridView
    Friend WithEvents lblOrder As System.Windows.Forms.Label
    Friend WithEvents txtOrd_No As CustomerFile.xTextBox
End Class
