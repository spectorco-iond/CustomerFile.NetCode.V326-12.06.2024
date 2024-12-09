<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerHeader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerHeader))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbCustomer = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdDisruption = New System.Windows.Forms.Button()
        Me.txtCus_Note_3 = New CustomerFile.xTextBox()
        Me.txtCmp_Code = New CustomerFile.xTextBox()
        Me.txtCmp_Name = New CustomerFile.xTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New CustomerFile.xTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCmp_FCtry = New CustomerFile.xTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStateCode = New CustomerFile.xTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCmp_FCity = New CustomerFile.xTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCmp_FPC = New CustomerFile.xTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCmp_FAdd3 = New CustomerFile.xTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCmp_FAdd2 = New CustomerFile.xTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCmp_FAdd1 = New CustomerFile.xTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdMacola = New System.Windows.Forms.Button()
        Me.gbAdvanced = New System.Windows.Forms.GroupBox()
        Me.lblVIP = New System.Windows.Forms.Label()
        Me.XTxt_SAM_Textfiel4 = New CustomerFile.xTextBox()
        Me.Lb_SAM_Textfiel4 = New System.Windows.Forms.Label()
        Me.chkAllowSubstituteItem = New System.Windows.Forms.CheckBox()
        Me.lblAllowSubstituteItem = New System.Windows.Forms.Label()
        Me.chkAllowPartialShipment = New System.Windows.Forms.CheckBox()
        Me.lblAllowPartialShipment = New System.Windows.Forms.Label()
        Me.chkAllowBackOrders = New System.Windows.Forms.CheckBox()
        Me.lblWhite_Glove_Count = New System.Windows.Forms.Label()
        Me.lblAllowBackOrders = New System.Windows.Forms.Label()
        Me.txttax_cd_2 = New CustomerFile.xTextBox()
        Me.txttax_cd_3 = New CustomerFile.xTextBox()
        Me.btnCustomerCharges = New System.Windows.Forms.Button()
        Me.txttax_cd = New CustomerFile.xTextBox()
        Me.lblTxbl_Cd = New System.Windows.Forms.Label()
        Me.chkTxbl_Fg = New System.Windows.Forms.CheckBox()
        Me.lblTxbl_Fg = New System.Windows.Forms.Label()
        Me.txtPaymentCondition_Desc = New CustomerFile.xTextBox()
        Me.txtPaymentCondition = New CustomerFile.xTextBox()
        Me.lblPaymentCondition = New System.Windows.Forms.Label()
        Me.txtShipVia_Desc = New CustomerFile.xTextBox()
        Me.txtShipVia = New CustomerFile.xTextBox()
        Me.lblShipVia = New System.Windows.Forms.Label()
        Me.txtcmp_status_Desc = New CustomerFile.xTextBox()
        Me.txtcmp_status = New CustomerFile.xTextBox()
        Me.lblcmp_status = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtClassificationID = New CustomerFile.xTextBox()
        Me.txtEQP_Status = New CustomerFile.xTextBox()
        Me.lblTextField1 = New System.Windows.Forms.Label()
        Me.lblClassificationID = New System.Windows.Forms.Label()
        Me.tcCusInfo = New System.Windows.Forms.TabControl()
        Me.tpAllInOne = New System.Windows.Forms.TabPage()
        Me.gbAIO_PushedOrders = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgvPushedOrders = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsNewPushedOrder = New System.Windows.Forms.ToolStripButton()
        Me.tsOpenPushedOrder = New System.Windows.Forms.ToolStripButton()
        Me.tsDeletePushedOrder = New System.Windows.Forms.ToolStripButton()
        Me.tsRefreshPushedOrder = New System.Windows.Forms.ToolStripButton()
        Me.gbAIO_DocContacts = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvDocContacts = New System.Windows.Forms.DataGridView()
        Me.gbAIO_Options = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvOptions = New System.Windows.Forms.DataGridView()
        Me.gbAIO_Communications = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvCommunications = New System.Windows.Forms.DataGridView()
        Me.gbAIO_SelfPromo = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dgvSelfPromo = New System.Windows.Forms.DataGridView()
        Me.panSelfPromoHead = New System.Windows.Forms.Panel()
        Me.txtSelfPromo = New System.Windows.Forms.TextBox()
        Me.lblSelfPromo = New System.Windows.Forms.Label()
        Me.lblAIO_SelfPromoYear = New System.Windows.Forms.Label()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.txtAIO_SelfPromoYear = New CustomerFile.xTextBox()
        Me.txtSelfPromo_Remaining = New CustomerFile.xTextBox()
        Me.lblAllowance = New System.Windows.Forms.Label()
        Me.txtSelfPromo_Amt = New CustomerFile.xTextBox()
        Me.tpCommunications = New System.Windows.Forms.TabPage()
        Me.UcComm = New CustomerFile.ucComm()
        Me.tpContacts = New System.Windows.Forms.TabPage()
        Me.UcContacts = New CustomerFile.ucContacts()
        Me.tpOrders = New System.Windows.Forms.TabPage()
        Me.UcOrders = New CustomerFile.ucOrders()
        Me.tpPrograms = New System.Windows.Forms.TabPage()
        Me.UcPrograms = New CustomerFile.ucPrograms()
        Me.tpSpecialPricing = New System.Windows.Forms.TabPage()
        Me.UcSpecialPricing = New CustomerFile.ucSpecialPricing()
        Me.tbQuotes = New System.Windows.Forms.TabPage()
        Me.UcQuotes = New CustomerFile.ucQuotes()
        Me.tpCharges = New System.Windows.Forms.TabPage()
        Me.UcCharges = New CustomerFile.ucCharges()
        Me.tpShipping = New System.Windows.Forms.TabPage()
        Me.UcShipping = New CustomerFile.ucShipping()
        Me.tpOtherComments = New System.Windows.Forms.TabPage()
        Me.UcOtherComments = New CustomerFile.ucComments()
        Me.tpCustPack = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRep_Email = New CustomerFile.xTextBox()
        Me.lblRep_Email = New System.Windows.Forms.Label()
        Me.txtRep_Phone = New CustomerFile.xTextBox()
        Me.lblRep_Phone = New System.Windows.Forms.Label()
        Me.txtRep_Desc = New CustomerFile.xTextBox()
        Me.txtRep = New CustomerFile.xTextBox()
        Me.lblRep = New System.Windows.Forms.Label()
        Me.txtCurrency = New CustomerFile.xTextBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.txtRegion = New CustomerFile.xTextBox()
        Me.lblTerr = New System.Windows.Forms.Label()
        Me.txtSalesPersonNumber_Desc = New CustomerFile.xTextBox()
        Me.txtSalesPersonNumber = New CustomerFile.xTextBox()
        Me.lblSalesPersonNumber = New System.Windows.Forms.Label()
        Me.cmdWhite_Glove_End_Date = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkWhite_Glove = New System.Windows.Forms.CheckBox()
        Me.lblWhite_Glove = New System.Windows.Forms.Label()
        Me.mcCalendar = New System.Windows.Forms.MonthCalendar()
        Me.sbSpecialTreatment = New System.Windows.Forms.GroupBox()
        Me.lblReturn_3Month = New System.Windows.Forms.Label()
        Me.txtWhite_Glove_End_Date = New CustomerFile.xTextBox()
        Me.txtWhite_Glove_Order_Count = New CustomerFile.xTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbCustomer.SuspendLayout()
        Me.gbAdvanced.SuspendLayout()
        Me.tcCusInfo.SuspendLayout()
        Me.tpAllInOne.SuspendLayout()
        Me.gbAIO_PushedOrders.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvPushedOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.gbAIO_DocContacts.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvDocContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAIO_Options.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAIO_Communications.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCommunications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAIO_SelfPromo.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvSelfPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panSelfPromoHead.SuspendLayout()
        Me.tpCommunications.SuspendLayout()
        Me.tpContacts.SuspendLayout()
        Me.tpOrders.SuspendLayout()
        Me.tpPrograms.SuspendLayout()
        Me.tpSpecialPricing.SuspendLayout()
        Me.tbQuotes.SuspendLayout()
        Me.tpCharges.SuspendLayout()
        Me.tpShipping.SuspendLayout()
        Me.tpOtherComments.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.sbSpecialTreatment.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCustomer
        '
        Me.gbCustomer.Controls.Add(Me.Button1)
        Me.gbCustomer.Controls.Add(Me.cmdDisruption)
        Me.gbCustomer.Controls.Add(Me.txtCus_Note_3)
        Me.gbCustomer.Controls.Add(Me.txtCmp_Code)
        Me.gbCustomer.Controls.Add(Me.txtCmp_Name)
        Me.gbCustomer.Controls.Add(Me.Label3)
        Me.gbCustomer.Controls.Add(Me.lblPhoneNumber)
        Me.gbCustomer.Controls.Add(Me.txtPhoneNumber)
        Me.gbCustomer.Controls.Add(Me.Label1)
        Me.gbCustomer.Controls.Add(Me.Label2)
        Me.gbCustomer.Controls.Add(Me.Label5)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FCtry)
        Me.gbCustomer.Controls.Add(Me.Label10)
        Me.gbCustomer.Controls.Add(Me.txtStateCode)
        Me.gbCustomer.Controls.Add(Me.Label11)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FCity)
        Me.gbCustomer.Controls.Add(Me.Label12)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FPC)
        Me.gbCustomer.Controls.Add(Me.Label4)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FAdd3)
        Me.gbCustomer.Controls.Add(Me.Label6)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FAdd2)
        Me.gbCustomer.Controls.Add(Me.Label7)
        Me.gbCustomer.Controls.Add(Me.txtCmp_FAdd1)
        Me.gbCustomer.Controls.Add(Me.Label8)
        Me.gbCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.gbCustomer.Location = New System.Drawing.Point(9, 10)
        Me.gbCustomer.Margin = New System.Windows.Forms.Padding(1)
        Me.gbCustomer.Name = "gbCustomer"
        Me.gbCustomer.Size = New System.Drawing.Size(330, 214)
        Me.gbCustomer.TabIndex = 5
        Me.gbCustomer.TabStop = False
        Me.gbCustomer.Text = "Customer Information"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(43, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 56)
        Me.Button1.TabIndex = 143
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cmdDisruption
        '
        Me.cmdDisruption.Location = New System.Drawing.Point(217, 186)
        Me.cmdDisruption.Name = "cmdDisruption"
        Me.cmdDisruption.Size = New System.Drawing.Size(109, 22)
        Me.cmdDisruption.TabIndex = 142
        Me.cmdDisruption.Text = "Disruption"
        Me.cmdDisruption.UseVisualStyleBackColor = True
        '
        'txtCus_Note_3
        '
        Me.txtCus_Note_3.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Note_3.DataLength = CType(0, Long)
        Me.txtCus_Note_3.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Note_3.DateValue = New Date(CType(0, Long))
        Me.txtCus_Note_3.DecimalDigits = CType(0, Long)
        Me.txtCus_Note_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCus_Note_3.Location = New System.Drawing.Point(214, 18)
        Me.txtCus_Note_3.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Note_3.Mask = Nothing
        Me.txtCus_Note_3.Name = "txtCus_Note_3"
        Me.txtCus_Note_3.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Note_3.OldValue = Nothing
        Me.txtCus_Note_3.Size = New System.Drawing.Size(112, 26)
        Me.txtCus_Note_3.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Note_3.StringValue = Nothing
        Me.txtCus_Note_3.TabIndex = 128
        Me.txtCus_Note_3.TextDataID = Nothing
        '
        'txtCmp_Code
        '
        Me.txtCmp_Code.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_Code.DataLength = CType(0, Long)
        Me.txtCmp_Code.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_Code.DateValue = New Date(CType(0, Long))
        Me.txtCmp_Code.DecimalDigits = CType(0, Long)
        Me.txtCmp_Code.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_Code.Location = New System.Drawing.Point(76, 18)
        Me.txtCmp_Code.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_Code.Mask = Nothing
        Me.txtCmp_Code.Name = "txtCmp_Code"
        Me.txtCmp_Code.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_Code.OldValue = Nothing
        Me.txtCmp_Code.Size = New System.Drawing.Size(75, 26)
        Me.txtCmp_Code.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_Code.StringValue = Nothing
        Me.txtCmp_Code.TabIndex = 109
        Me.txtCmp_Code.TextDataID = Nothing
        '
        'txtCmp_Name
        '
        Me.txtCmp_Name.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_Name.DataLength = CType(0, Long)
        Me.txtCmp_Name.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_Name.DateValue = New Date(CType(0, Long))
        Me.txtCmp_Name.DecimalDigits = CType(0, Long)
        Me.txtCmp_Name.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_Name.Location = New System.Drawing.Point(76, 42)
        Me.txtCmp_Name.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_Name.Mask = Nothing
        Me.txtCmp_Name.Name = "txtCmp_Name"
        Me.txtCmp_Name.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_Name.OldValue = Nothing
        Me.txtCmp_Name.Size = New System.Drawing.Size(250, 26)
        Me.txtCmp_Name.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_Name.StringValue = Nothing
        Me.txtCmp_Name.TabIndex = 107
        Me.txtCmp_Name.TextDataID = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(153, 21)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Group"
        '
        'lblPhoneNumber
        '
        Me.lblPhoneNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblPhoneNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPhoneNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhoneNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhoneNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPhoneNumber.Location = New System.Drawing.Point(4, 189)
        Me.lblPhoneNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        Me.lblPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPhoneNumber.Size = New System.Drawing.Size(70, 19)
        Me.lblPhoneNumber.TabIndex = 140
        Me.lblPhoneNumber.Text = "Phone"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPhoneNumber.DataLength = CType(0, Long)
        Me.txtPhoneNumber.DataType = CustomerFile.CDataType.dtString
        Me.txtPhoneNumber.DateValue = New Date(CType(0, Long))
        Me.txtPhoneNumber.DecimalDigits = CType(0, Long)
        Me.txtPhoneNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhoneNumber.Location = New System.Drawing.Point(76, 186)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPhoneNumber.Mask = Nothing
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPhoneNumber.OldValue = Nothing
        Me.txtPhoneNumber.Size = New System.Drawing.Size(137, 26)
        Me.txtPhoneNumber.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPhoneNumber.StringValue = Nothing
        Me.txtPhoneNumber.TabIndex = 137
        Me.txtPhoneNumber.TextDataID = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(4, 165)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(70, 23)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Zip"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(4, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(70, 23)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Code"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(4, 45)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 23)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Name"
        '
        'txtCmp_FCtry
        '
        Me.txtCmp_FCtry.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FCtry.DataLength = CType(0, Long)
        Me.txtCmp_FCtry.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FCtry.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FCtry.DecimalDigits = CType(0, Long)
        Me.txtCmp_FCtry.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_FCtry.Location = New System.Drawing.Point(276, 162)
        Me.txtCmp_FCtry.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FCtry.Mask = Nothing
        Me.txtCmp_FCtry.Name = "txtCmp_FCtry"
        Me.txtCmp_FCtry.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FCtry.OldValue = Nothing
        Me.txtCmp_FCtry.Size = New System.Drawing.Size(50, 26)
        Me.txtCmp_FCtry.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FCtry.StringValue = Nothing
        Me.txtCmp_FCtry.TabIndex = 103
        Me.txtCmp_FCtry.TextDataID = Nothing
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(215, 165)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(79, 23)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Country"
        '
        'txtStateCode
        '
        Me.txtStateCode.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtStateCode.DataLength = CType(0, Long)
        Me.txtStateCode.DataType = CustomerFile.CDataType.dtString
        Me.txtStateCode.DateValue = New Date(CType(0, Long))
        Me.txtStateCode.DecimalDigits = CType(0, Long)
        Me.txtStateCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStateCode.Location = New System.Drawing.Point(276, 138)
        Me.txtStateCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStateCode.Mask = Nothing
        Me.txtStateCode.Name = "txtStateCode"
        Me.txtStateCode.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStateCode.OldValue = Nothing
        Me.txtStateCode.Size = New System.Drawing.Size(50, 26)
        Me.txtStateCode.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtStateCode.StringValue = Nothing
        Me.txtStateCode.TabIndex = 101
        Me.txtStateCode.TextDataID = Nothing
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(215, 141)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(40, 23)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "State"
        '
        'txtCmp_FCity
        '
        Me.txtCmp_FCity.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FCity.DataLength = CType(0, Long)
        Me.txtCmp_FCity.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FCity.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FCity.DecimalDigits = CType(0, Long)
        Me.txtCmp_FCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_FCity.Location = New System.Drawing.Point(76, 138)
        Me.txtCmp_FCity.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FCity.Mask = Nothing
        Me.txtCmp_FCity.Name = "txtCmp_FCity"
        Me.txtCmp_FCity.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FCity.OldValue = Nothing
        Me.txtCmp_FCity.Size = New System.Drawing.Size(137, 26)
        Me.txtCmp_FCity.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FCity.StringValue = Nothing
        Me.txtCmp_FCity.TabIndex = 99
        Me.txtCmp_FCity.TextDataID = Nothing
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(4, 141)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(70, 23)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "City"
        '
        'txtCmp_FPC
        '
        Me.txtCmp_FPC.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FPC.DataLength = CType(0, Long)
        Me.txtCmp_FPC.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FPC.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FPC.DecimalDigits = CType(0, Long)
        Me.txtCmp_FPC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_FPC.Location = New System.Drawing.Point(76, 162)
        Me.txtCmp_FPC.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FPC.Mask = Nothing
        Me.txtCmp_FPC.Name = "txtCmp_FPC"
        Me.txtCmp_FPC.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FPC.OldValue = Nothing
        Me.txtCmp_FPC.Size = New System.Drawing.Size(137, 26)
        Me.txtCmp_FPC.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FPC.StringValue = Nothing
        Me.txtCmp_FPC.TabIndex = 97
        Me.txtCmp_FPC.TextDataID = Nothing
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 139)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(10, 23)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Zip code"
        '
        'txtCmp_FAdd3
        '
        Me.txtCmp_FAdd3.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FAdd3.DataLength = CType(0, Long)
        Me.txtCmp_FAdd3.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FAdd3.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FAdd3.DecimalDigits = CType(0, Long)
        Me.txtCmp_FAdd3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_FAdd3.Location = New System.Drawing.Point(76, 114)
        Me.txtCmp_FAdd3.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FAdd3.Mask = Nothing
        Me.txtCmp_FAdd3.Name = "txtCmp_FAdd3"
        Me.txtCmp_FAdd3.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FAdd3.OldValue = Nothing
        Me.txtCmp_FAdd3.Size = New System.Drawing.Size(250, 26)
        Me.txtCmp_FAdd3.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FAdd3.StringValue = Nothing
        Me.txtCmp_FAdd3.TabIndex = 95
        Me.txtCmp_FAdd3.TextDataID = Nothing
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(4, 117)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(70, 23)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Address 3"
        '
        'txtCmp_FAdd2
        '
        Me.txtCmp_FAdd2.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FAdd2.DataLength = CType(0, Long)
        Me.txtCmp_FAdd2.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FAdd2.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FAdd2.DecimalDigits = CType(0, Long)
        Me.txtCmp_FAdd2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtCmp_FAdd2.Location = New System.Drawing.Point(76, 90)
        Me.txtCmp_FAdd2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FAdd2.Mask = Nothing
        Me.txtCmp_FAdd2.Name = "txtCmp_FAdd2"
        Me.txtCmp_FAdd2.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FAdd2.OldValue = Nothing
        Me.txtCmp_FAdd2.Size = New System.Drawing.Size(250, 26)
        Me.txtCmp_FAdd2.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FAdd2.StringValue = Nothing
        Me.txtCmp_FAdd2.TabIndex = 93
        Me.txtCmp_FAdd2.TextDataID = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(4, 93)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(70, 23)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Address 2"
        '
        'txtCmp_FAdd1
        '
        Me.txtCmp_FAdd1.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCmp_FAdd1.DataLength = CType(0, Long)
        Me.txtCmp_FAdd1.DataType = CustomerFile.CDataType.dtString
        Me.txtCmp_FAdd1.DateValue = New Date(CType(0, Long))
        Me.txtCmp_FAdd1.DecimalDigits = CType(0, Long)
        Me.txtCmp_FAdd1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCmp_FAdd1.Location = New System.Drawing.Point(76, 66)
        Me.txtCmp_FAdd1.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCmp_FAdd1.Mask = Nothing
        Me.txtCmp_FAdd1.Name = "txtCmp_FAdd1"
        Me.txtCmp_FAdd1.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCmp_FAdd1.OldValue = Nothing
        Me.txtCmp_FAdd1.Size = New System.Drawing.Size(250, 26)
        Me.txtCmp_FAdd1.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCmp_FAdd1.StringValue = Nothing
        Me.txtCmp_FAdd1.TabIndex = 91
        Me.txtCmp_FAdd1.TextDataID = Nothing
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(4, 68)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(70, 23)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Address 1"
        '
        'cmdMacola
        '
        Me.cmdMacola.Enabled = False
        Me.cmdMacola.Location = New System.Drawing.Point(170, 65)
        Me.cmdMacola.Margin = New System.Windows.Forms.Padding(1)
        Me.cmdMacola.Name = "cmdMacola"
        Me.cmdMacola.Size = New System.Drawing.Size(130, 22)
        Me.cmdMacola.TabIndex = 144
        Me.cmdMacola.Text = "Macola File"
        Me.cmdMacola.UseVisualStyleBackColor = True
        Me.cmdMacola.Visible = False
        '
        'gbAdvanced
        '
        Me.gbAdvanced.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAdvanced.Controls.Add(Me.lblVIP)
        Me.gbAdvanced.Controls.Add(Me.XTxt_SAM_Textfiel4)
        Me.gbAdvanced.Controls.Add(Me.Lb_SAM_Textfiel4)
        Me.gbAdvanced.Controls.Add(Me.chkAllowSubstituteItem)
        Me.gbAdvanced.Controls.Add(Me.lblAllowSubstituteItem)
        Me.gbAdvanced.Controls.Add(Me.chkAllowPartialShipment)
        Me.gbAdvanced.Controls.Add(Me.lblAllowPartialShipment)
        Me.gbAdvanced.Controls.Add(Me.chkAllowBackOrders)
        Me.gbAdvanced.Controls.Add(Me.lblWhite_Glove_Count)
        Me.gbAdvanced.Controls.Add(Me.lblAllowBackOrders)
        Me.gbAdvanced.Controls.Add(Me.txttax_cd_2)
        Me.gbAdvanced.Controls.Add(Me.txttax_cd_3)
        Me.gbAdvanced.Controls.Add(Me.btnCustomerCharges)
        Me.gbAdvanced.Controls.Add(Me.txttax_cd)
        Me.gbAdvanced.Controls.Add(Me.lblTxbl_Cd)
        Me.gbAdvanced.Controls.Add(Me.chkTxbl_Fg)
        Me.gbAdvanced.Controls.Add(Me.lblTxbl_Fg)
        Me.gbAdvanced.Controls.Add(Me.txtPaymentCondition_Desc)
        Me.gbAdvanced.Controls.Add(Me.txtPaymentCondition)
        Me.gbAdvanced.Controls.Add(Me.lblPaymentCondition)
        Me.gbAdvanced.Controls.Add(Me.txtShipVia_Desc)
        Me.gbAdvanced.Controls.Add(Me.txtShipVia)
        Me.gbAdvanced.Controls.Add(Me.lblShipVia)
        Me.gbAdvanced.Controls.Add(Me.txtcmp_status_Desc)
        Me.gbAdvanced.Controls.Add(Me.txtcmp_status)
        Me.gbAdvanced.Controls.Add(Me.lblcmp_status)
        Me.gbAdvanced.Controls.Add(Me.CheckBox1)
        Me.gbAdvanced.Controls.Add(Me.Label15)
        Me.gbAdvanced.Controls.Add(Me.cmdMacola)
        Me.gbAdvanced.Controls.Add(Me.txtClassificationID)
        Me.gbAdvanced.Controls.Add(Me.txtEQP_Status)
        Me.gbAdvanced.Controls.Add(Me.lblTextField1)
        Me.gbAdvanced.Controls.Add(Me.lblClassificationID)
        Me.gbAdvanced.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.gbAdvanced.Location = New System.Drawing.Point(673, 10)
        Me.gbAdvanced.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAdvanced.Name = "gbAdvanced"
        Me.gbAdvanced.Size = New System.Drawing.Size(334, 214)
        Me.gbAdvanced.TabIndex = 5
        Me.gbAdvanced.TabStop = False
        Me.gbAdvanced.Text = "Extended Information"
        '
        'lblVIP
        '
        Me.lblVIP.AutoSize = True
        Me.lblVIP.BackColor = System.Drawing.Color.Black
        Me.lblVIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIP.ForeColor = System.Drawing.Color.Gold
        Me.lblVIP.Location = New System.Drawing.Point(13, 20)
        Me.lblVIP.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVIP.Name = "lblVIP"
        Me.lblVIP.Size = New System.Drawing.Size(43, 26)
        Me.lblVIP.TabIndex = 174
        Me.lblVIP.Text = "VIP"
        Me.lblVIP.Visible = False
        '
        'XTxt_SAM_Textfiel4
        '
        Me.XTxt_SAM_Textfiel4.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.XTxt_SAM_Textfiel4.DataLength = CType(0, Long)
        Me.XTxt_SAM_Textfiel4.DataType = CustomerFile.CDataType.dtString
        Me.XTxt_SAM_Textfiel4.DateValue = New Date(CType(0, Long))
        Me.XTxt_SAM_Textfiel4.DecimalDigits = CType(0, Long)
        Me.XTxt_SAM_Textfiel4.Location = New System.Drawing.Point(252, 18)
        Me.XTxt_SAM_Textfiel4.Mask = Nothing
        Me.XTxt_SAM_Textfiel4.Name = "XTxt_SAM_Textfiel4"
        Me.XTxt_SAM_Textfiel4.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.XTxt_SAM_Textfiel4.OldValue = ""
        Me.XTxt_SAM_Textfiel4.Size = New System.Drawing.Size(78, 25)
        Me.XTxt_SAM_Textfiel4.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.XTxt_SAM_Textfiel4.StringValue = Nothing
        Me.XTxt_SAM_Textfiel4.TabIndex = 173
        Me.XTxt_SAM_Textfiel4.TextDataID = Nothing
        '
        'Lb_SAM_Textfiel4
        '
        Me.Lb_SAM_Textfiel4.AutoSize = True
        Me.Lb_SAM_Textfiel4.Location = New System.Drawing.Point(210, 21)
        Me.Lb_SAM_Textfiel4.Name = "Lb_SAM_Textfiel4"
        Me.Lb_SAM_Textfiel4.Size = New System.Drawing.Size(38, 17)
        Me.Lb_SAM_Textfiel4.TabIndex = 172
        Me.Lb_SAM_Textfiel4.Text = "SAM"
        '
        'chkAllowSubstituteItem
        '
        Me.chkAllowSubstituteItem.AutoSize = True
        Me.chkAllowSubstituteItem.Location = New System.Drawing.Point(190, 167)
        Me.chkAllowSubstituteItem.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAllowSubstituteItem.Name = "chkAllowSubstituteItem"
        Me.chkAllowSubstituteItem.Size = New System.Drawing.Size(18, 17)
        Me.chkAllowSubstituteItem.TabIndex = 171
        Me.chkAllowSubstituteItem.UseVisualStyleBackColor = True
        Me.chkAllowSubstituteItem.Visible = False
        '
        'lblAllowSubstituteItem
        '
        Me.lblAllowSubstituteItem.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllowSubstituteItem.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAllowSubstituteItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllowSubstituteItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAllowSubstituteItem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAllowSubstituteItem.Location = New System.Drawing.Point(144, 165)
        Me.lblAllowSubstituteItem.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAllowSubstituteItem.Name = "lblAllowSubstituteItem"
        Me.lblAllowSubstituteItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAllowSubstituteItem.Size = New System.Drawing.Size(44, 19)
        Me.lblAllowSubstituteItem.TabIndex = 170
        Me.lblAllowSubstituteItem.Text = "Subst"
        Me.lblAllowSubstituteItem.Visible = False
        '
        'chkAllowPartialShipment
        '
        Me.chkAllowPartialShipment.AutoSize = True
        Me.chkAllowPartialShipment.Location = New System.Drawing.Point(127, 166)
        Me.chkAllowPartialShipment.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAllowPartialShipment.Name = "chkAllowPartialShipment"
        Me.chkAllowPartialShipment.Size = New System.Drawing.Size(18, 17)
        Me.chkAllowPartialShipment.TabIndex = 169
        Me.chkAllowPartialShipment.UseVisualStyleBackColor = True
        Me.chkAllowPartialShipment.Visible = False
        '
        'lblAllowPartialShipment
        '
        Me.lblAllowPartialShipment.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllowPartialShipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAllowPartialShipment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllowPartialShipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAllowPartialShipment.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAllowPartialShipment.Location = New System.Drawing.Point(56, 164)
        Me.lblAllowPartialShipment.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAllowPartialShipment.Name = "lblAllowPartialShipment"
        Me.lblAllowPartialShipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAllowPartialShipment.Size = New System.Drawing.Size(69, 19)
        Me.lblAllowPartialShipment.TabIndex = 168
        Me.lblAllowPartialShipment.Text = "Part. Ship"
        Me.lblAllowPartialShipment.Visible = False
        '
        'chkAllowBackOrders
        '
        Me.chkAllowBackOrders.AutoSize = True
        Me.chkAllowBackOrders.Location = New System.Drawing.Point(39, 165)
        Me.chkAllowBackOrders.Margin = New System.Windows.Forms.Padding(1)
        Me.chkAllowBackOrders.Name = "chkAllowBackOrders"
        Me.chkAllowBackOrders.Size = New System.Drawing.Size(18, 17)
        Me.chkAllowBackOrders.TabIndex = 167
        Me.chkAllowBackOrders.UseVisualStyleBackColor = True
        Me.chkAllowBackOrders.Visible = False
        '
        'lblWhite_Glove_Count
        '
        Me.lblWhite_Glove_Count.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhite_Glove_Count.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhite_Glove_Count.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhite_Glove_Count.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhite_Glove_Count.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhite_Glove_Count.Location = New System.Drawing.Point(136, 67)
        Me.lblWhite_Glove_Count.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhite_Glove_Count.Name = "lblWhite_Glove_Count"
        Me.lblWhite_Glove_Count.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhite_Glove_Count.Size = New System.Drawing.Size(16, 19)
        Me.lblWhite_Glove_Count.TabIndex = 171
        Me.lblWhite_Glove_Count.Text = "For next 2 order(s)"
        Me.lblWhite_Glove_Count.Visible = False
        '
        'lblAllowBackOrders
        '
        Me.lblAllowBackOrders.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllowBackOrders.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAllowBackOrders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllowBackOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAllowBackOrders.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAllowBackOrders.Location = New System.Drawing.Point(4, 164)
        Me.lblAllowBackOrders.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAllowBackOrders.Name = "lblAllowBackOrders"
        Me.lblAllowBackOrders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAllowBackOrders.Size = New System.Drawing.Size(50, 19)
        Me.lblAllowBackOrders.TabIndex = 166
        Me.lblAllowBackOrders.Text = " B.O."
        Me.lblAllowBackOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAllowBackOrders.Visible = False
        '
        'txttax_cd_2
        '
        Me.txttax_cd_2.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txttax_cd_2.DataLength = CType(0, Long)
        Me.txttax_cd_2.DataType = CustomerFile.CDataType.dtString
        Me.txttax_cd_2.DateValue = New Date(CType(0, Long))
        Me.txttax_cd_2.DecimalDigits = CType(0, Long)
        Me.txttax_cd_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax_cd_2.Location = New System.Drawing.Point(228, 186)
        Me.txttax_cd_2.Margin = New System.Windows.Forms.Padding(1)
        Me.txttax_cd_2.Mask = Nothing
        Me.txttax_cd_2.Name = "txttax_cd_2"
        Me.txttax_cd_2.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txttax_cd_2.OldValue = Nothing
        Me.txttax_cd_2.Size = New System.Drawing.Size(50, 26)
        Me.txttax_cd_2.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txttax_cd_2.StringValue = Nothing
        Me.txttax_cd_2.TabIndex = 163
        Me.txttax_cd_2.TextDataID = Nothing
        '
        'txttax_cd_3
        '
        Me.txttax_cd_3.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txttax_cd_3.DataLength = CType(0, Long)
        Me.txttax_cd_3.DataType = CustomerFile.CDataType.dtString
        Me.txttax_cd_3.DateValue = New Date(CType(0, Long))
        Me.txttax_cd_3.DecimalDigits = CType(0, Long)
        Me.txttax_cd_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax_cd_3.Location = New System.Drawing.Point(280, 186)
        Me.txttax_cd_3.Margin = New System.Windows.Forms.Padding(1)
        Me.txttax_cd_3.Mask = Nothing
        Me.txttax_cd_3.Name = "txttax_cd_3"
        Me.txttax_cd_3.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txttax_cd_3.OldValue = Nothing
        Me.txttax_cd_3.Size = New System.Drawing.Size(50, 26)
        Me.txttax_cd_3.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txttax_cd_3.StringValue = Nothing
        Me.txttax_cd_3.TabIndex = 162
        Me.txttax_cd_3.TextDataID = Nothing
        '
        'btnCustomerCharges
        '
        Me.btnCustomerCharges.Enabled = False
        Me.btnCustomerCharges.Location = New System.Drawing.Point(9, 64)
        Me.btnCustomerCharges.Margin = New System.Windows.Forms.Padding(1)
        Me.btnCustomerCharges.Name = "btnCustomerCharges"
        Me.btnCustomerCharges.Size = New System.Drawing.Size(130, 22)
        Me.btnCustomerCharges.TabIndex = 168
        Me.btnCustomerCharges.Text = "Customer Charges"
        Me.btnCustomerCharges.UseVisualStyleBackColor = True
        Me.btnCustomerCharges.Visible = False
        '
        'txttax_cd
        '
        Me.txttax_cd.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txttax_cd.DataLength = CType(0, Long)
        Me.txttax_cd.DataType = CustomerFile.CDataType.dtString
        Me.txttax_cd.DateValue = New Date(CType(0, Long))
        Me.txttax_cd.DecimalDigits = CType(0, Long)
        Me.txttax_cd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax_cd.Location = New System.Drawing.Point(176, 186)
        Me.txttax_cd.Margin = New System.Windows.Forms.Padding(1)
        Me.txttax_cd.Mask = Nothing
        Me.txttax_cd.Name = "txttax_cd"
        Me.txttax_cd.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txttax_cd.OldValue = Nothing
        Me.txttax_cd.Size = New System.Drawing.Size(50, 26)
        Me.txttax_cd.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txttax_cd.StringValue = Nothing
        Me.txttax_cd.TabIndex = 161
        Me.txttax_cd.TextDataID = Nothing
        '
        'lblTxbl_Cd
        '
        Me.lblTxbl_Cd.BackColor = System.Drawing.SystemColors.Control
        Me.lblTxbl_Cd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTxbl_Cd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTxbl_Cd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTxbl_Cd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTxbl_Cd.Location = New System.Drawing.Point(90, 189)
        Me.lblTxbl_Cd.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTxbl_Cd.Name = "lblTxbl_Cd"
        Me.lblTxbl_Cd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTxbl_Cd.Size = New System.Drawing.Size(78, 19)
        Me.lblTxbl_Cd.TabIndex = 160
        Me.lblTxbl_Cd.Text = "Tax Codes"
        '
        'chkTxbl_Fg
        '
        Me.chkTxbl_Fg.AutoSize = True
        Me.chkTxbl_Fg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTxbl_Fg.Location = New System.Drawing.Point(67, 191)
        Me.chkTxbl_Fg.Margin = New System.Windows.Forms.Padding(1)
        Me.chkTxbl_Fg.Name = "chkTxbl_Fg"
        Me.chkTxbl_Fg.Size = New System.Drawing.Size(18, 17)
        Me.chkTxbl_Fg.TabIndex = 159
        Me.chkTxbl_Fg.UseVisualStyleBackColor = True
        '
        'lblTxbl_Fg
        '
        Me.lblTxbl_Fg.BackColor = System.Drawing.SystemColors.Control
        Me.lblTxbl_Fg.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTxbl_Fg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTxbl_Fg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTxbl_Fg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTxbl_Fg.Location = New System.Drawing.Point(4, 189)
        Me.lblTxbl_Fg.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTxbl_Fg.Name = "lblTxbl_Fg"
        Me.lblTxbl_Fg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTxbl_Fg.Size = New System.Drawing.Size(56, 19)
        Me.lblTxbl_Fg.TabIndex = 158
        Me.lblTxbl_Fg.Text = "Taxable"
        '
        'txtPaymentCondition_Desc
        '
        Me.txtPaymentCondition_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPaymentCondition_Desc.DataLength = CType(25, Long)
        Me.txtPaymentCondition_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtPaymentCondition_Desc.DateValue = New Date(CType(0, Long))
        Me.txtPaymentCondition_Desc.DecimalDigits = CType(0, Long)
        Me.txtPaymentCondition_Desc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentCondition_Desc.Location = New System.Drawing.Point(170, 138)
        Me.txtPaymentCondition_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPaymentCondition_Desc.Mask = Nothing
        Me.txtPaymentCondition_Desc.Name = "txtPaymentCondition_Desc"
        Me.txtPaymentCondition_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPaymentCondition_Desc.OldValue = Nothing
        Me.txtPaymentCondition_Desc.ReadOnly = True
        Me.txtPaymentCondition_Desc.Size = New System.Drawing.Size(160, 26)
        Me.txtPaymentCondition_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPaymentCondition_Desc.StringValue = Nothing
        Me.txtPaymentCondition_Desc.TabIndex = 153
        Me.txtPaymentCondition_Desc.TextDataID = Nothing
        '
        'txtPaymentCondition
        '
        Me.txtPaymentCondition.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtPaymentCondition.DataLength = CType(0, Long)
        Me.txtPaymentCondition.DataType = CustomerFile.CDataType.dtString
        Me.txtPaymentCondition.DateValue = New Date(CType(0, Long))
        Me.txtPaymentCondition.DecimalDigits = CType(0, Long)
        Me.txtPaymentCondition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentCondition.Location = New System.Drawing.Point(93, 138)
        Me.txtPaymentCondition.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPaymentCondition.Mask = Nothing
        Me.txtPaymentCondition.Name = "txtPaymentCondition"
        Me.txtPaymentCondition.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPaymentCondition.OldValue = Nothing
        Me.txtPaymentCondition.Size = New System.Drawing.Size(75, 26)
        Me.txtPaymentCondition.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtPaymentCondition.StringValue = Nothing
        Me.txtPaymentCondition.TabIndex = 152
        Me.txtPaymentCondition.TextDataID = Nothing
        '
        'lblPaymentCondition
        '
        Me.lblPaymentCondition.BackColor = System.Drawing.SystemColors.Control
        Me.lblPaymentCondition.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPaymentCondition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentCondition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPaymentCondition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPaymentCondition.Location = New System.Drawing.Point(4, 141)
        Me.lblPaymentCondition.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPaymentCondition.Name = "lblPaymentCondition"
        Me.lblPaymentCondition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPaymentCondition.Size = New System.Drawing.Size(75, 19)
        Me.lblPaymentCondition.TabIndex = 151
        Me.lblPaymentCondition.Text = "AR Terms"
        '
        'txtShipVia_Desc
        '
        Me.txtShipVia_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShipVia_Desc.DataLength = CType(25, Long)
        Me.txtShipVia_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtShipVia_Desc.DateValue = New Date(CType(0, Long))
        Me.txtShipVia_Desc.DecimalDigits = CType(0, Long)
        Me.txtShipVia_Desc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipVia_Desc.Location = New System.Drawing.Point(170, 114)
        Me.txtShipVia_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShipVia_Desc.Mask = Nothing
        Me.txtShipVia_Desc.Name = "txtShipVia_Desc"
        Me.txtShipVia_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShipVia_Desc.OldValue = Nothing
        Me.txtShipVia_Desc.ReadOnly = True
        Me.txtShipVia_Desc.Size = New System.Drawing.Size(160, 26)
        Me.txtShipVia_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShipVia_Desc.StringValue = Nothing
        Me.txtShipVia_Desc.TabIndex = 150
        Me.txtShipVia_Desc.TextDataID = Nothing
        '
        'txtShipVia
        '
        Me.txtShipVia.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtShipVia.DataLength = CType(0, Long)
        Me.txtShipVia.DataType = CustomerFile.CDataType.dtString
        Me.txtShipVia.DateValue = New Date(CType(0, Long))
        Me.txtShipVia.DecimalDigits = CType(0, Long)
        Me.txtShipVia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipVia.Location = New System.Drawing.Point(93, 114)
        Me.txtShipVia.Margin = New System.Windows.Forms.Padding(1)
        Me.txtShipVia.Mask = Nothing
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtShipVia.OldValue = Nothing
        Me.txtShipVia.Size = New System.Drawing.Size(75, 26)
        Me.txtShipVia.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtShipVia.StringValue = Nothing
        Me.txtShipVia.TabIndex = 149
        Me.txtShipVia.TextDataID = Nothing
        '
        'lblShipVia
        '
        Me.lblShipVia.BackColor = System.Drawing.SystemColors.Control
        Me.lblShipVia.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShipVia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipVia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShipVia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblShipVia.Location = New System.Drawing.Point(4, 117)
        Me.lblShipVia.Margin = New System.Windows.Forms.Padding(1)
        Me.lblShipVia.Name = "lblShipVia"
        Me.lblShipVia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShipVia.Size = New System.Drawing.Size(84, 19)
        Me.lblShipVia.TabIndex = 148
        Me.lblShipVia.Text = "Ship Via Cd"
        '
        'txtcmp_status_Desc
        '
        Me.txtcmp_status_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtcmp_status_Desc.DataLength = CType(25, Long)
        Me.txtcmp_status_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtcmp_status_Desc.DateValue = New Date(CType(0, Long))
        Me.txtcmp_status_Desc.DecimalDigits = CType(0, Long)
        Me.txtcmp_status_Desc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmp_status_Desc.Location = New System.Drawing.Point(170, 90)
        Me.txtcmp_status_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtcmp_status_Desc.Mask = Nothing
        Me.txtcmp_status_Desc.Name = "txtcmp_status_Desc"
        Me.txtcmp_status_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtcmp_status_Desc.OldValue = Nothing
        Me.txtcmp_status_Desc.ReadOnly = True
        Me.txtcmp_status_Desc.Size = New System.Drawing.Size(160, 26)
        Me.txtcmp_status_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtcmp_status_Desc.StringValue = Nothing
        Me.txtcmp_status_Desc.TabIndex = 147
        Me.txtcmp_status_Desc.TextDataID = Nothing
        '
        'txtcmp_status
        '
        Me.txtcmp_status.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtcmp_status.DataLength = CType(0, Long)
        Me.txtcmp_status.DataType = CustomerFile.CDataType.dtString
        Me.txtcmp_status.DateValue = New Date(CType(0, Long))
        Me.txtcmp_status.DecimalDigits = CType(0, Long)
        Me.txtcmp_status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmp_status.Location = New System.Drawing.Point(93, 90)
        Me.txtcmp_status.Margin = New System.Windows.Forms.Padding(1)
        Me.txtcmp_status.Mask = Nothing
        Me.txtcmp_status.Name = "txtcmp_status"
        Me.txtcmp_status.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtcmp_status.OldValue = Nothing
        Me.txtcmp_status.Size = New System.Drawing.Size(75, 26)
        Me.txtcmp_status.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtcmp_status.StringValue = Nothing
        Me.txtcmp_status.TabIndex = 146
        Me.txtcmp_status.TextDataID = Nothing
        '
        'lblcmp_status
        '
        Me.lblcmp_status.BackColor = System.Drawing.SystemColors.Control
        Me.lblcmp_status.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblcmp_status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcmp_status.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcmp_status.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcmp_status.Location = New System.Drawing.Point(4, 93)
        Me.lblcmp_status.Margin = New System.Windows.Forms.Padding(1)
        Me.lblcmp_status.Name = "lblcmp_status"
        Me.lblcmp_status.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblcmp_status.Size = New System.Drawing.Size(75, 19)
        Me.lblcmp_status.TabIndex = 145
        Me.lblcmp_status.Text = "Status"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(315, 47)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(250, 46)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 19)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "On Trial"
        Me.Label15.Visible = False
        '
        'txtClassificationID
        '
        Me.txtClassificationID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtClassificationID.DataLength = CType(0, Long)
        Me.txtClassificationID.DataType = CustomerFile.CDataType.dtString
        Me.txtClassificationID.DateValue = New Date(CType(0, Long))
        Me.txtClassificationID.DecimalDigits = CType(0, Long)
        Me.txtClassificationID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassificationID.Location = New System.Drawing.Point(147, 18)
        Me.txtClassificationID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtClassificationID.Mask = Nothing
        Me.txtClassificationID.Name = "txtClassificationID"
        Me.txtClassificationID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtClassificationID.OldValue = ""
        Me.txtClassificationID.Size = New System.Drawing.Size(51, 26)
        Me.txtClassificationID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtClassificationID.StringValue = Nothing
        Me.txtClassificationID.TabIndex = 49
        Me.txtClassificationID.TextDataID = Nothing
        '
        'txtEQP_Status
        '
        Me.txtEQP_Status.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtEQP_Status.DataLength = CType(0, Long)
        Me.txtEQP_Status.DataType = CustomerFile.CDataType.dtString
        Me.txtEQP_Status.DateValue = New Date(CType(0, Long))
        Me.txtEQP_Status.DecimalDigits = CType(0, Long)
        Me.txtEQP_Status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEQP_Status.Location = New System.Drawing.Point(93, 42)
        Me.txtEQP_Status.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEQP_Status.Mask = Nothing
        Me.txtEQP_Status.Name = "txtEQP_Status"
        Me.txtEQP_Status.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEQP_Status.OldValue = ""
        Me.txtEQP_Status.Size = New System.Drawing.Size(155, 26)
        Me.txtEQP_Status.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtEQP_Status.StringValue = Nothing
        Me.txtEQP_Status.TabIndex = 48
        Me.txtEQP_Status.TextDataID = Nothing
        '
        'lblTextField1
        '
        Me.lblTextField1.AutoSize = True
        Me.lblTextField1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextField1.Location = New System.Drawing.Point(4, 45)
        Me.lblTextField1.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTextField1.Name = "lblTextField1"
        Me.lblTextField1.Size = New System.Drawing.Size(93, 19)
        Me.lblTextField1.TabIndex = 17
        Me.lblTextField1.Text = "EQP Status"
        '
        'lblClassificationID
        '
        Me.lblClassificationID.AutoSize = True
        Me.lblClassificationID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClassificationID.Location = New System.Drawing.Point(66, 22)
        Me.lblClassificationID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblClassificationID.Name = "lblClassificationID"
        Me.lblClassificationID.Size = New System.Drawing.Size(81, 19)
        Me.lblClassificationID.TabIndex = 15
        Me.lblClassificationID.Text = "Star Level"
        '
        'tcCusInfo
        '
        Me.tcCusInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcCusInfo.Controls.Add(Me.tpAllInOne)
        Me.tcCusInfo.Controls.Add(Me.tpCommunications)
        Me.tcCusInfo.Controls.Add(Me.tpContacts)
        Me.tcCusInfo.Controls.Add(Me.tpOrders)
        Me.tcCusInfo.Controls.Add(Me.tpPrograms)
        Me.tcCusInfo.Controls.Add(Me.tpSpecialPricing)
        Me.tcCusInfo.Controls.Add(Me.tbQuotes)
        Me.tcCusInfo.Controls.Add(Me.tpCharges)
        Me.tcCusInfo.Controls.Add(Me.tpShipping)
        Me.tcCusInfo.Controls.Add(Me.tpOtherComments)
        Me.tcCusInfo.Controls.Add(Me.tpCustPack)
        Me.tcCusInfo.Location = New System.Drawing.Point(9, 228)
        Me.tcCusInfo.Margin = New System.Windows.Forms.Padding(1)
        Me.tcCusInfo.Name = "tcCusInfo"
        Me.tcCusInfo.SelectedIndex = 0
        Me.tcCusInfo.Size = New System.Drawing.Size(998, 441)
        Me.tcCusInfo.TabIndex = 7
        '
        'tpAllInOne
        '
        Me.tpAllInOne.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpAllInOne.Controls.Add(Me.gbAIO_PushedOrders)
        Me.tpAllInOne.Controls.Add(Me.gbAIO_DocContacts)
        Me.tpAllInOne.Controls.Add(Me.gbAIO_Options)
        Me.tpAllInOne.Controls.Add(Me.gbAIO_Communications)
        Me.tpAllInOne.Controls.Add(Me.gbAIO_SelfPromo)
        Me.tpAllInOne.Location = New System.Drawing.Point(4, 26)
        Me.tpAllInOne.Name = "tpAllInOne"
        Me.tpAllInOne.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAllInOne.Size = New System.Drawing.Size(990, 411)
        Me.tpAllInOne.TabIndex = 9
        Me.tpAllInOne.Text = "All In One"
        '
        'gbAIO_PushedOrders
        '
        Me.gbAIO_PushedOrders.Controls.Add(Me.Panel7)
        Me.gbAIO_PushedOrders.Controls.Add(Me.Panel3)
        Me.gbAIO_PushedOrders.Location = New System.Drawing.Point(8, 240)
        Me.gbAIO_PushedOrders.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAIO_PushedOrders.Name = "gbAIO_PushedOrders"
        Me.gbAIO_PushedOrders.Size = New System.Drawing.Size(324, 166)
        Me.gbAIO_PushedOrders.TabIndex = 6
        Me.gbAIO_PushedOrders.TabStop = False
        Me.gbAIO_PushedOrders.Text = "Pushed Orders"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgvPushedOrders)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(3, 46)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(318, 117)
        Me.Panel7.TabIndex = 7
        '
        'dgvPushedOrders
        '
        Me.dgvPushedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPushedOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPushedOrders.Location = New System.Drawing.Point(0, 0)
        Me.dgvPushedOrders.Name = "dgvPushedOrders"
        Me.dgvPushedOrders.ReadOnly = True
        Me.dgvPushedOrders.RowHeadersVisible = False
        Me.dgvPushedOrders.Size = New System.Drawing.Size(318, 117)
        Me.dgvPushedOrders.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ToolStrip2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(3, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(318, 25)
        Me.Panel3.TabIndex = 6
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNewPushedOrder, Me.tsOpenPushedOrder, Me.tsDeletePushedOrder, Me.tsRefreshPushedOrder})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(318, 27)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsNewPushedOrder
        '
        Me.tsNewPushedOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsNewPushedOrder.Image = CType(resources.GetObject("tsNewPushedOrder.Image"), System.Drawing.Image)
        Me.tsNewPushedOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNewPushedOrder.Name = "tsNewPushedOrder"
        Me.tsNewPushedOrder.Size = New System.Drawing.Size(43, 24)
        Me.tsNewPushedOrder.Tag = ""
        Me.tsNewPushedOrder.Text = "New"
        '
        'tsOpenPushedOrder
        '
        Me.tsOpenPushedOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsOpenPushedOrder.Image = CType(resources.GetObject("tsOpenPushedOrder.Image"), System.Drawing.Image)
        Me.tsOpenPushedOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOpenPushedOrder.Name = "tsOpenPushedOrder"
        Me.tsOpenPushedOrder.Size = New System.Drawing.Size(49, 24)
        Me.tsOpenPushedOrder.Text = "Open"
        Me.tsOpenPushedOrder.Visible = False
        '
        'tsDeletePushedOrder
        '
        Me.tsDeletePushedOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDeletePushedOrder.Image = CType(resources.GetObject("tsDeletePushedOrder.Image"), System.Drawing.Image)
        Me.tsDeletePushedOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDeletePushedOrder.Name = "tsDeletePushedOrder"
        Me.tsDeletePushedOrder.Size = New System.Drawing.Size(57, 24)
        Me.tsDeletePushedOrder.Text = "Delete"
        Me.tsDeletePushedOrder.Visible = False
        '
        'tsRefreshPushedOrder
        '
        Me.tsRefreshPushedOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsRefreshPushedOrder.Image = CType(resources.GetObject("tsRefreshPushedOrder.Image"), System.Drawing.Image)
        Me.tsRefreshPushedOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefreshPushedOrder.Name = "tsRefreshPushedOrder"
        Me.tsRefreshPushedOrder.Size = New System.Drawing.Size(62, 24)
        Me.tsRefreshPushedOrder.Text = "Refresh"
        '
        'gbAIO_DocContacts
        '
        Me.gbAIO_DocContacts.Controls.Add(Me.Panel1)
        Me.gbAIO_DocContacts.Location = New System.Drawing.Point(334, 207)
        Me.gbAIO_DocContacts.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAIO_DocContacts.Name = "gbAIO_DocContacts"
        Me.gbAIO_DocContacts.Size = New System.Drawing.Size(325, 200)
        Me.gbAIO_DocContacts.TabIndex = 5
        Me.gbAIO_DocContacts.TabStop = False
        Me.gbAIO_DocContacts.Text = "Document correspondance"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvDocContacts)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 176)
        Me.Panel1.TabIndex = 3
        '
        'dgvDocContacts
        '
        Me.dgvDocContacts.AllowUserToAddRows = False
        Me.dgvDocContacts.AllowUserToDeleteRows = False
        Me.dgvDocContacts.AllowUserToResizeRows = False
        Me.dgvDocContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocContacts.Location = New System.Drawing.Point(0, 0)
        Me.dgvDocContacts.Name = "dgvDocContacts"
        Me.dgvDocContacts.ReadOnly = True
        Me.dgvDocContacts.Size = New System.Drawing.Size(319, 176)
        Me.dgvDocContacts.TabIndex = 2
        '
        'gbAIO_Options
        '
        Me.gbAIO_Options.Controls.Add(Me.Panel4)
        Me.gbAIO_Options.Location = New System.Drawing.Point(8, 5)
        Me.gbAIO_Options.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAIO_Options.Name = "gbAIO_Options"
        Me.gbAIO_Options.Size = New System.Drawing.Size(324, 233)
        Me.gbAIO_Options.TabIndex = 1
        Me.gbAIO_Options.TabStop = False
        Me.gbAIO_Options.Text = "Options"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvOptions)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(3, 21)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(318, 209)
        Me.Panel4.TabIndex = 3
        '
        'dgvOptions
        '
        Me.dgvOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptions.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptions.Name = "dgvOptions"
        Me.dgvOptions.ReadOnly = True
        Me.dgvOptions.Size = New System.Drawing.Size(318, 209)
        Me.dgvOptions.TabIndex = 2
        '
        'gbAIO_Communications
        '
        Me.gbAIO_Communications.Controls.Add(Me.Panel2)
        Me.gbAIO_Communications.Location = New System.Drawing.Point(334, 5)
        Me.gbAIO_Communications.Margin = New System.Windows.Forms.Padding(0)
        Me.gbAIO_Communications.Name = "gbAIO_Communications"
        Me.gbAIO_Communications.Size = New System.Drawing.Size(652, 200)
        Me.gbAIO_Communications.TabIndex = 4
        Me.gbAIO_Communications.TabStop = False
        Me.gbAIO_Communications.Text = "Last Communications"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvCommunications)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(646, 176)
        Me.Panel2.TabIndex = 2
        '
        'dgvCommunications
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCommunications.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCommunications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCommunications.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCommunications.Location = New System.Drawing.Point(0, 0)
        Me.dgvCommunications.Name = "dgvCommunications"
        Me.dgvCommunications.ReadOnly = True
        Me.dgvCommunications.Size = New System.Drawing.Size(646, 176)
        Me.dgvCommunications.TabIndex = 1
        '
        'gbAIO_SelfPromo
        '
        Me.gbAIO_SelfPromo.Controls.Add(Me.Panel5)
        Me.gbAIO_SelfPromo.Controls.Add(Me.panSelfPromoHead)
        Me.gbAIO_SelfPromo.Location = New System.Drawing.Point(661, 207)
        Me.gbAIO_SelfPromo.Margin = New System.Windows.Forms.Padding(1)
        Me.gbAIO_SelfPromo.Name = "gbAIO_SelfPromo"
        Me.gbAIO_SelfPromo.Size = New System.Drawing.Size(326, 200)
        Me.gbAIO_SelfPromo.TabIndex = 2
        Me.gbAIO_SelfPromo.TabStop = False
        Me.gbAIO_SelfPromo.Text = "Marketing Allowance"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvSelfPromo)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(3, 61)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(320, 136)
        Me.Panel5.TabIndex = 116
        '
        'dgvSelfPromo
        '
        Me.dgvSelfPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelfPromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSelfPromo.Location = New System.Drawing.Point(0, 0)
        Me.dgvSelfPromo.Name = "dgvSelfPromo"
        Me.dgvSelfPromo.ReadOnly = True
        Me.dgvSelfPromo.Size = New System.Drawing.Size(320, 136)
        Me.dgvSelfPromo.TabIndex = 1
        '
        'panSelfPromoHead
        '
        Me.panSelfPromoHead.Controls.Add(Me.txtSelfPromo)
        Me.panSelfPromoHead.Controls.Add(Me.lblSelfPromo)
        Me.panSelfPromoHead.Controls.Add(Me.lblAIO_SelfPromoYear)
        Me.panSelfPromoHead.Controls.Add(Me.lblRemaining)
        Me.panSelfPromoHead.Controls.Add(Me.txtAIO_SelfPromoYear)
        Me.panSelfPromoHead.Controls.Add(Me.txtSelfPromo_Remaining)
        Me.panSelfPromoHead.Controls.Add(Me.lblAllowance)
        Me.panSelfPromoHead.Controls.Add(Me.txtSelfPromo_Amt)
        Me.panSelfPromoHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.panSelfPromoHead.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panSelfPromoHead.Location = New System.Drawing.Point(3, 21)
        Me.panSelfPromoHead.Name = "panSelfPromoHead"
        Me.panSelfPromoHead.Size = New System.Drawing.Size(320, 40)
        Me.panSelfPromoHead.TabIndex = 115
        '
        'txtSelfPromo
        '
        Me.txtSelfPromo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelfPromo.Location = New System.Drawing.Point(131, 16)
        Me.txtSelfPromo.Name = "txtSelfPromo"
        Me.txtSelfPromo.ReadOnly = True
        Me.txtSelfPromo.Size = New System.Drawing.Size(51, 23)
        Me.txtSelfPromo.TabIndex = 121
        '
        'lblSelfPromo
        '
        Me.lblSelfPromo.AutoSize = True
        Me.lblSelfPromo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelfPromo.Location = New System.Drawing.Point(128, 0)
        Me.lblSelfPromo.Name = "lblSelfPromo"
        Me.lblSelfPromo.Size = New System.Drawing.Size(77, 16)
        Me.lblSelfPromo.TabIndex = 120
        Me.lblSelfPromo.Text = "Self Promo"
        '
        'lblAIO_SelfPromoYear
        '
        Me.lblAIO_SelfPromoYear.AutoSize = True
        Me.lblAIO_SelfPromoYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAIO_SelfPromoYear.Location = New System.Drawing.Point(263, 0)
        Me.lblAIO_SelfPromoYear.Name = "lblAIO_SelfPromoYear"
        Me.lblAIO_SelfPromoYear.Size = New System.Drawing.Size(37, 16)
        Me.lblAIO_SelfPromoYear.TabIndex = 118
        Me.lblAIO_SelfPromoYear.Text = "Year"
        '
        'lblRemaining
        '
        Me.lblRemaining.AutoSize = True
        Me.lblRemaining.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemaining.Location = New System.Drawing.Point(65, 0)
        Me.lblRemaining.Name = "lblRemaining"
        Me.lblRemaining.Size = New System.Drawing.Size(75, 16)
        Me.lblRemaining.TabIndex = 114
        Me.lblRemaining.Text = "Remaining"
        '
        'txtAIO_SelfPromoYear
        '
        Me.txtAIO_SelfPromoYear.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtAIO_SelfPromoYear.DataLength = CType(0, Long)
        Me.txtAIO_SelfPromoYear.DataType = CustomerFile.CDataType.dtNumWithoutDecimals
        Me.txtAIO_SelfPromoYear.DateValue = New Date(CType(0, Long))
        Me.txtAIO_SelfPromoYear.DecimalDigits = CType(0, Long)
        Me.txtAIO_SelfPromoYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAIO_SelfPromoYear.Location = New System.Drawing.Point(265, 16)
        Me.txtAIO_SelfPromoYear.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAIO_SelfPromoYear.Mask = Nothing
        Me.txtAIO_SelfPromoYear.Name = "txtAIO_SelfPromoYear"
        Me.txtAIO_SelfPromoYear.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAIO_SelfPromoYear.OldValue = Nothing
        Me.txtAIO_SelfPromoYear.Size = New System.Drawing.Size(54, 23)
        Me.txtAIO_SelfPromoYear.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtAIO_SelfPromoYear.StringValue = Nothing
        Me.txtAIO_SelfPromoYear.TabIndex = 117
        Me.txtAIO_SelfPromoYear.TextDataID = Nothing
        '
        'txtSelfPromo_Remaining
        '
        Me.txtSelfPromo_Remaining.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSelfPromo_Remaining.DataLength = CType(0, Long)
        Me.txtSelfPromo_Remaining.DataType = CustomerFile.CDataType.dtNumWithDecimals
        Me.txtSelfPromo_Remaining.DateValue = New Date(CType(0, Long))
        Me.txtSelfPromo_Remaining.DecimalDigits = CType(2, Long)
        Me.txtSelfPromo_Remaining.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelfPromo_Remaining.Location = New System.Drawing.Point(66, 16)
        Me.txtSelfPromo_Remaining.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSelfPromo_Remaining.Mask = Nothing
        Me.txtSelfPromo_Remaining.Name = "txtSelfPromo_Remaining"
        Me.txtSelfPromo_Remaining.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSelfPromo_Remaining.OldValue = Nothing
        Me.txtSelfPromo_Remaining.ReadOnly = True
        Me.txtSelfPromo_Remaining.Size = New System.Drawing.Size(55, 23)
        Me.txtSelfPromo_Remaining.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSelfPromo_Remaining.StringValue = Nothing
        Me.txtSelfPromo_Remaining.TabIndex = 113
        Me.txtSelfPromo_Remaining.TextDataID = Nothing
        '
        'lblAllowance
        '
        Me.lblAllowance.AutoSize = True
        Me.lblAllowance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllowance.Location = New System.Drawing.Point(3, 0)
        Me.lblAllowance.Name = "lblAllowance"
        Me.lblAllowance.Size = New System.Drawing.Size(71, 16)
        Me.lblAllowance.TabIndex = 112
        Me.lblAllowance.Text = "Allowance"
        '
        'txtSelfPromo_Amt
        '
        Me.txtSelfPromo_Amt.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSelfPromo_Amt.DataLength = CType(0, Long)
        Me.txtSelfPromo_Amt.DataType = CustomerFile.CDataType.dtNumWithDecimals
        Me.txtSelfPromo_Amt.DateValue = New Date(CType(0, Long))
        Me.txtSelfPromo_Amt.DecimalDigits = CType(2, Long)
        Me.txtSelfPromo_Amt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelfPromo_Amt.Location = New System.Drawing.Point(6, 16)
        Me.txtSelfPromo_Amt.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSelfPromo_Amt.Mask = Nothing
        Me.txtSelfPromo_Amt.Name = "txtSelfPromo_Amt"
        Me.txtSelfPromo_Amt.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSelfPromo_Amt.OldValue = Nothing
        Me.txtSelfPromo_Amt.ReadOnly = True
        Me.txtSelfPromo_Amt.Size = New System.Drawing.Size(56, 23)
        Me.txtSelfPromo_Amt.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSelfPromo_Amt.StringValue = Nothing
        Me.txtSelfPromo_Amt.TabIndex = 111
        Me.txtSelfPromo_Amt.TextDataID = Nothing
        '
        'tpCommunications
        '
        Me.tpCommunications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCommunications.Controls.Add(Me.UcComm)
        Me.tpCommunications.Location = New System.Drawing.Point(4, 25)
        Me.tpCommunications.Name = "tpCommunications"
        Me.tpCommunications.Size = New System.Drawing.Size(990, 412)
        Me.tpCommunications.TabIndex = 5
        Me.tpCommunications.Text = "Communications"
        '
        'UcComm
        '
        Me.UcComm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcComm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcComm.Location = New System.Drawing.Point(0, 0)
        Me.UcComm.Name = "UcComm"
        Me.UcComm.Size = New System.Drawing.Size(990, 412)
        Me.UcComm.TabIndex = 0
        Me.UcComm.Tag = "CF-CTL-COM-001"
        '
        'tpContacts
        '
        Me.tpContacts.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpContacts.Controls.Add(Me.UcContacts)
        Me.tpContacts.Location = New System.Drawing.Point(4, 25)
        Me.tpContacts.Name = "tpContacts"
        Me.tpContacts.Size = New System.Drawing.Size(990, 412)
        Me.tpContacts.TabIndex = 7
        Me.tpContacts.Text = "Contacts"
        '
        'UcContacts
        '
        Me.UcContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcContacts.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcContacts.Location = New System.Drawing.Point(0, 0)
        Me.UcContacts.Name = "UcContacts"
        Me.UcContacts.Size = New System.Drawing.Size(990, 412)
        Me.UcContacts.TabIndex = 0
        Me.UcContacts.Tag = "CF-CTL-CNT-001"
        '
        'tpOrders
        '
        Me.tpOrders.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpOrders.Controls.Add(Me.UcOrders)
        Me.tpOrders.Location = New System.Drawing.Point(4, 25)
        Me.tpOrders.Name = "tpOrders"
        Me.tpOrders.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrders.Size = New System.Drawing.Size(990, 412)
        Me.tpOrders.TabIndex = 0
        Me.tpOrders.Text = "Orders"
        '
        'UcOrders
        '
        Me.UcOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcOrders.Location = New System.Drawing.Point(3, 3)
        Me.UcOrders.Margin = New System.Windows.Forms.Padding(0)
        Me.UcOrders.Name = "UcOrders"
        Me.UcOrders.Size = New System.Drawing.Size(984, 406)
        Me.UcOrders.TabIndex = 1
        Me.UcOrders.Tag = "CF-CTL-ORD-001"
        '
        'tpPrograms
        '
        Me.tpPrograms.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpPrograms.Controls.Add(Me.UcPrograms)
        Me.tpPrograms.Location = New System.Drawing.Point(4, 25)
        Me.tpPrograms.Name = "tpPrograms"
        Me.tpPrograms.Size = New System.Drawing.Size(990, 412)
        Me.tpPrograms.TabIndex = 1
        Me.tpPrograms.Text = "Programs"
        '
        'UcPrograms
        '
        Me.UcPrograms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPrograms.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcPrograms.Location = New System.Drawing.Point(0, 0)
        Me.UcPrograms.Name = "UcPrograms"
        Me.UcPrograms.Size = New System.Drawing.Size(990, 412)
        Me.UcPrograms.TabIndex = 0
        Me.UcPrograms.Tag = "CF-CTL-PRG-001"
        '
        'tpSpecialPricing
        '
        Me.tpSpecialPricing.Controls.Add(Me.UcSpecialPricing)
        Me.tpSpecialPricing.Location = New System.Drawing.Point(4, 25)
        Me.tpSpecialPricing.Name = "tpSpecialPricing"
        Me.tpSpecialPricing.Size = New System.Drawing.Size(990, 412)
        Me.tpSpecialPricing.TabIndex = 11
        Me.tpSpecialPricing.Text = "Special Pricing"
        Me.tpSpecialPricing.UseVisualStyleBackColor = True
        '
        'UcSpecialPricing
        '
        Me.UcSpecialPricing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSpecialPricing.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSpecialPricing.Location = New System.Drawing.Point(0, 0)
        Me.UcSpecialPricing.Name = "UcSpecialPricing"
        Me.UcSpecialPricing.Size = New System.Drawing.Size(990, 412)
        Me.UcSpecialPricing.TabIndex = 0
        Me.UcSpecialPricing.Tag = "CF-CTL-SPR-001"
        '
        'tbQuotes
        '
        Me.tbQuotes.Controls.Add(Me.UcQuotes)
        Me.tbQuotes.Location = New System.Drawing.Point(4, 25)
        Me.tbQuotes.Name = "tbQuotes"
        Me.tbQuotes.Size = New System.Drawing.Size(990, 412)
        Me.tbQuotes.TabIndex = 10
        Me.tbQuotes.Text = "Quotes"
        Me.tbQuotes.UseVisualStyleBackColor = True
        '
        'UcQuotes
        '
        Me.UcQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcQuotes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcQuotes.Location = New System.Drawing.Point(0, 0)
        Me.UcQuotes.Name = "UcQuotes"
        Me.UcQuotes.Size = New System.Drawing.Size(990, 412)
        Me.UcQuotes.TabIndex = 0
        Me.UcQuotes.Tag = "CF-CTL-QUO-001"
        '
        'tpCharges
        '
        Me.tpCharges.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCharges.Controls.Add(Me.UcCharges)
        Me.tpCharges.Location = New System.Drawing.Point(4, 26)
        Me.tpCharges.Name = "tpCharges"
        Me.tpCharges.Size = New System.Drawing.Size(990, 411)
        Me.tpCharges.TabIndex = 3
        Me.tpCharges.Text = "Options"
        '
        'UcCharges
        '
        Me.UcCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcCharges.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcCharges.Location = New System.Drawing.Point(0, 0)
        Me.UcCharges.Name = "UcCharges"
        Me.UcCharges.Size = New System.Drawing.Size(990, 411)
        Me.UcCharges.TabIndex = 0
        Me.UcCharges.Tag = "CF-CTL-CHG-001"
        '
        'tpShipping
        '
        Me.tpShipping.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpShipping.Controls.Add(Me.UcShipping)
        Me.tpShipping.Location = New System.Drawing.Point(4, 25)
        Me.tpShipping.Name = "tpShipping"
        Me.tpShipping.Size = New System.Drawing.Size(990, 412)
        Me.tpShipping.TabIndex = 4
        Me.tpShipping.Text = "Shipping"
        '
        'UcShipping
        '
        Me.UcShipping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcShipping.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcShipping.Location = New System.Drawing.Point(0, 0)
        Me.UcShipping.Name = "UcShipping"
        Me.UcShipping.Size = New System.Drawing.Size(990, 412)
        Me.UcShipping.TabIndex = 1
        Me.UcShipping.Tag = "CF-CTL-SHP-001"
        '
        'tpOtherComments
        '
        Me.tpOtherComments.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpOtherComments.Controls.Add(Me.UcOtherComments)
        Me.tpOtherComments.Location = New System.Drawing.Point(4, 25)
        Me.tpOtherComments.Name = "tpOtherComments"
        Me.tpOtherComments.Size = New System.Drawing.Size(990, 412)
        Me.tpOtherComments.TabIndex = 8
        Me.tpOtherComments.Text = "Other Comments"
        '
        'UcOtherComments
        '
        Me.UcOtherComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOtherComments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcOtherComments.Location = New System.Drawing.Point(0, 0)
        Me.UcOtherComments.Name = "UcOtherComments"
        Me.UcOtherComments.Size = New System.Drawing.Size(990, 412)
        Me.UcOtherComments.TabIndex = 0
        Me.UcOtherComments.Tag = "CF-CTL-CMT-001"
        '
        'tpCustPack
        '
        Me.tpCustPack.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tpCustPack.Location = New System.Drawing.Point(4, 25)
        Me.tpCustPack.Name = "tpCustPack"
        Me.tpCustPack.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCustPack.Size = New System.Drawing.Size(990, 412)
        Me.tpCustPack.TabIndex = 12
        Me.tpCustPack.Text = "Cust-Packaging"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRep_Email)
        Me.GroupBox2.Controls.Add(Me.lblRep_Email)
        Me.GroupBox2.Controls.Add(Me.txtRep_Phone)
        Me.GroupBox2.Controls.Add(Me.lblRep_Phone)
        Me.GroupBox2.Controls.Add(Me.txtRep_Desc)
        Me.GroupBox2.Controls.Add(Me.txtRep)
        Me.GroupBox2.Controls.Add(Me.lblRep)
        Me.GroupBox2.Controls.Add(Me.txtCurrency)
        Me.GroupBox2.Controls.Add(Me.lblCurrency)
        Me.GroupBox2.Controls.Add(Me.txtRegion)
        Me.GroupBox2.Controls.Add(Me.lblTerr)
        Me.GroupBox2.Controls.Add(Me.txtSalesPersonNumber_Desc)
        Me.GroupBox2.Controls.Add(Me.txtSalesPersonNumber)
        Me.GroupBox2.Controls.Add(Me.lblSalesPersonNumber)
        Me.GroupBox2.Location = New System.Drawing.Point(341, 10)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 146)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CSR / Salesperson"
        '
        'txtRep_Email
        '
        Me.txtRep_Email.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtRep_Email.DataLength = CType(0, Long)
        Me.txtRep_Email.DataType = CustomerFile.CDataType.dtString
        Me.txtRep_Email.DateValue = New Date(CType(0, Long))
        Me.txtRep_Email.DecimalDigits = CType(0, Long)
        Me.txtRep_Email.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRep_Email.Location = New System.Drawing.Point(90, 114)
        Me.txtRep_Email.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRep_Email.Mask = Nothing
        Me.txtRep_Email.Name = "txtRep_Email"
        Me.txtRep_Email.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRep_Email.OldValue = Nothing
        Me.txtRep_Email.Size = New System.Drawing.Size(236, 26)
        Me.txtRep_Email.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtRep_Email.StringValue = Nothing
        Me.txtRep_Email.TabIndex = 167
        Me.txtRep_Email.TextDataID = Nothing
        '
        'lblRep_Email
        '
        Me.lblRep_Email.BackColor = System.Drawing.SystemColors.Control
        Me.lblRep_Email.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRep_Email.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRep_Email.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRep_Email.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRep_Email.Location = New System.Drawing.Point(4, 117)
        Me.lblRep_Email.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRep_Email.Name = "lblRep_Email"
        Me.lblRep_Email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRep_Email.Size = New System.Drawing.Size(84, 19)
        Me.lblRep_Email.TabIndex = 166
        Me.lblRep_Email.Text = "Email"
        '
        'txtRep_Phone
        '
        Me.txtRep_Phone.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtRep_Phone.DataLength = CType(0, Long)
        Me.txtRep_Phone.DataType = CustomerFile.CDataType.dtString
        Me.txtRep_Phone.DateValue = New Date(CType(0, Long))
        Me.txtRep_Phone.DecimalDigits = CType(0, Long)
        Me.txtRep_Phone.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRep_Phone.Location = New System.Drawing.Point(90, 90)
        Me.txtRep_Phone.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRep_Phone.Mask = Nothing
        Me.txtRep_Phone.Name = "txtRep_Phone"
        Me.txtRep_Phone.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRep_Phone.OldValue = Nothing
        Me.txtRep_Phone.Size = New System.Drawing.Size(236, 26)
        Me.txtRep_Phone.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtRep_Phone.StringValue = Nothing
        Me.txtRep_Phone.TabIndex = 148
        Me.txtRep_Phone.TextDataID = Nothing
        '
        'lblRep_Phone
        '
        Me.lblRep_Phone.BackColor = System.Drawing.SystemColors.Control
        Me.lblRep_Phone.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRep_Phone.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRep_Phone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRep_Phone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRep_Phone.Location = New System.Drawing.Point(4, 93)
        Me.lblRep_Phone.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRep_Phone.Name = "lblRep_Phone"
        Me.lblRep_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRep_Phone.Size = New System.Drawing.Size(75, 19)
        Me.lblRep_Phone.TabIndex = 147
        Me.lblRep_Phone.Text = "Phone number"
        '
        'txtRep_Desc
        '
        Me.txtRep_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtRep_Desc.DataLength = CType(25, Long)
        Me.txtRep_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtRep_Desc.DateValue = New Date(CType(0, Long))
        Me.txtRep_Desc.DecimalDigits = CType(0, Long)
        Me.txtRep_Desc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRep_Desc.Location = New System.Drawing.Point(167, 66)
        Me.txtRep_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRep_Desc.Mask = Nothing
        Me.txtRep_Desc.Name = "txtRep_Desc"
        Me.txtRep_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRep_Desc.OldValue = Nothing
        Me.txtRep_Desc.ReadOnly = True
        Me.txtRep_Desc.Size = New System.Drawing.Size(159, 26)
        Me.txtRep_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtRep_Desc.StringValue = Nothing
        Me.txtRep_Desc.TabIndex = 146
        Me.txtRep_Desc.TextDataID = Nothing
        '
        'txtRep
        '
        Me.txtRep.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtRep.DataLength = CType(0, Long)
        Me.txtRep.DataType = CustomerFile.CDataType.dtString
        Me.txtRep.DateValue = New Date(CType(0, Long))
        Me.txtRep.DecimalDigits = CType(0, Long)
        Me.txtRep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRep.Location = New System.Drawing.Point(90, 66)
        Me.txtRep.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRep.Mask = Nothing
        Me.txtRep.Name = "txtRep"
        Me.txtRep.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRep.OldValue = Nothing
        Me.txtRep.Size = New System.Drawing.Size(75, 26)
        Me.txtRep.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtRep.StringValue = Nothing
        Me.txtRep.TabIndex = 145
        Me.txtRep.TextDataID = Nothing
        '
        'lblRep
        '
        Me.lblRep.BackColor = System.Drawing.SystemColors.Control
        Me.lblRep.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRep.Location = New System.Drawing.Point(4, 68)
        Me.lblRep.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRep.Name = "lblRep"
        Me.lblRep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRep.Size = New System.Drawing.Size(84, 19)
        Me.lblRep.TabIndex = 144
        Me.lblRep.Text = "Salesperson"
        '
        'txtCurrency
        '
        Me.txtCurrency.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCurrency.DataLength = CType(0, Long)
        Me.txtCurrency.DataType = CustomerFile.CDataType.dtString
        Me.txtCurrency.DateValue = New Date(CType(0, Long))
        Me.txtCurrency.DecimalDigits = CType(0, Long)
        Me.txtCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Location = New System.Drawing.Point(251, 42)
        Me.txtCurrency.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCurrency.Mask = Nothing
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCurrency.OldValue = Nothing
        Me.txtCurrency.Size = New System.Drawing.Size(75, 26)
        Me.txtCurrency.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCurrency.StringValue = Nothing
        Me.txtCurrency.TabIndex = 143
        Me.txtCurrency.TextDataID = Nothing
        '
        'lblCurrency
        '
        Me.lblCurrency.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrency.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrency.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCurrency.Location = New System.Drawing.Point(167, 45)
        Me.lblCurrency.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrency.Size = New System.Drawing.Size(76, 19)
        Me.lblCurrency.TabIndex = 142
        Me.lblCurrency.Text = "Currency"
        '
        'txtRegion
        '
        Me.txtRegion.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtRegion.DataLength = CType(0, Long)
        Me.txtRegion.DataType = CustomerFile.CDataType.dtString
        Me.txtRegion.DateValue = New Date(CType(0, Long))
        Me.txtRegion.DecimalDigits = CType(0, Long)
        Me.txtRegion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegion.Location = New System.Drawing.Point(90, 42)
        Me.txtRegion.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRegion.Mask = Nothing
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtRegion.OldValue = Nothing
        Me.txtRegion.Size = New System.Drawing.Size(75, 26)
        Me.txtRegion.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtRegion.StringValue = Nothing
        Me.txtRegion.TabIndex = 141
        Me.txtRegion.TextDataID = Nothing
        '
        'lblTerr
        '
        Me.lblTerr.BackColor = System.Drawing.SystemColors.Control
        Me.lblTerr.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTerr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTerr.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTerr.Location = New System.Drawing.Point(4, 45)
        Me.lblTerr.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTerr.Name = "lblTerr"
        Me.lblTerr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTerr.Size = New System.Drawing.Size(75, 22)
        Me.lblTerr.TabIndex = 140
        Me.lblTerr.Text = "Territory"
        '
        'txtSalesPersonNumber_Desc
        '
        Me.txtSalesPersonNumber_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSalesPersonNumber_Desc.DataLength = CType(25, Long)
        Me.txtSalesPersonNumber_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtSalesPersonNumber_Desc.DateValue = New Date(CType(0, Long))
        Me.txtSalesPersonNumber_Desc.DecimalDigits = CType(0, Long)
        Me.txtSalesPersonNumber_Desc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPersonNumber_Desc.Location = New System.Drawing.Point(167, 18)
        Me.txtSalesPersonNumber_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSalesPersonNumber_Desc.Mask = Nothing
        Me.txtSalesPersonNumber_Desc.Name = "txtSalesPersonNumber_Desc"
        Me.txtSalesPersonNumber_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSalesPersonNumber_Desc.OldValue = Nothing
        Me.txtSalesPersonNumber_Desc.ReadOnly = True
        Me.txtSalesPersonNumber_Desc.Size = New System.Drawing.Size(159, 26)
        Me.txtSalesPersonNumber_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSalesPersonNumber_Desc.StringValue = Nothing
        Me.txtSalesPersonNumber_Desc.TabIndex = 139
        Me.txtSalesPersonNumber_Desc.TextDataID = Nothing
        '
        'txtSalesPersonNumber
        '
        Me.txtSalesPersonNumber.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtSalesPersonNumber.DataLength = CType(0, Long)
        Me.txtSalesPersonNumber.DataType = CustomerFile.CDataType.dtString
        Me.txtSalesPersonNumber.DateValue = New Date(CType(0, Long))
        Me.txtSalesPersonNumber.DecimalDigits = CType(0, Long)
        Me.txtSalesPersonNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPersonNumber.Location = New System.Drawing.Point(90, 18)
        Me.txtSalesPersonNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSalesPersonNumber.Mask = Nothing
        Me.txtSalesPersonNumber.Name = "txtSalesPersonNumber"
        Me.txtSalesPersonNumber.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSalesPersonNumber.OldValue = Nothing
        Me.txtSalesPersonNumber.Size = New System.Drawing.Size(75, 26)
        Me.txtSalesPersonNumber.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtSalesPersonNumber.StringValue = Nothing
        Me.txtSalesPersonNumber.TabIndex = 138
        Me.txtSalesPersonNumber.TextDataID = Nothing
        '
        'lblSalesPersonNumber
        '
        Me.lblSalesPersonNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblSalesPersonNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSalesPersonNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalesPersonNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSalesPersonNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSalesPersonNumber.Location = New System.Drawing.Point(4, 22)
        Me.lblSalesPersonNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSalesPersonNumber.Name = "lblSalesPersonNumber"
        Me.lblSalesPersonNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSalesPersonNumber.Size = New System.Drawing.Size(75, 19)
        Me.lblSalesPersonNumber.TabIndex = 137
        Me.lblSalesPersonNumber.Text = "CSR"
        '
        'cmdWhite_Glove_End_Date
        '
        Me.cmdWhite_Glove_End_Date.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWhite_Glove_End_Date.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdWhite_Glove_End_Date.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdWhite_Glove_End_Date.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdWhite_Glove_End_Date.Image = CType(resources.GetObject("cmdWhite_Glove_End_Date.Image"), System.Drawing.Image)
        Me.cmdWhite_Glove_End_Date.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdWhite_Glove_End_Date.Location = New System.Drawing.Point(305, 13)
        Me.cmdWhite_Glove_End_Date.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdWhite_Glove_End_Date.Name = "cmdWhite_Glove_End_Date"
        Me.cmdWhite_Glove_End_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdWhite_Glove_End_Date.Size = New System.Drawing.Size(21, 23)
        Me.cmdWhite_Glove_End_Date.TabIndex = 176
        Me.cmdWhite_Glove_End_Date.TabStop = False
        Me.cmdWhite_Glove_End_Date.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdWhite_Glove_End_Date.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(199, 41)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(71, 19)
        Me.Label13.TabIndex = 174
        Me.Label13.Text = "Order Qty:"
        Me.Label13.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(112, 17)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(40, 19)
        Me.Label9.TabIndex = 172
        Me.Label9.Text = "Until:"
        '
        'chkWhite_Glove
        '
        Me.chkWhite_Glove.AutoSize = True
        Me.chkWhite_Glove.Location = New System.Drawing.Point(90, 19)
        Me.chkWhite_Glove.Name = "chkWhite_Glove"
        Me.chkWhite_Glove.Size = New System.Drawing.Size(18, 17)
        Me.chkWhite_Glove.TabIndex = 170
        Me.chkWhite_Glove.UseVisualStyleBackColor = True
        '
        'lblWhite_Glove
        '
        Me.lblWhite_Glove.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhite_Glove.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWhite_Glove.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhite_Glove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWhite_Glove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhite_Glove.Location = New System.Drawing.Point(4, 17)
        Me.lblWhite_Glove.Margin = New System.Windows.Forms.Padding(1)
        Me.lblWhite_Glove.Name = "lblWhite_Glove"
        Me.lblWhite_Glove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWhite_Glove.Size = New System.Drawing.Size(82, 19)
        Me.lblWhite_Glove.TabIndex = 169
        Me.lblWhite_Glove.Text = "White Glove"
        '
        'mcCalendar
        '
        Me.mcCalendar.Location = New System.Drawing.Point(1012, 15)
        Me.mcCalendar.Margin = New System.Windows.Forms.Padding(8)
        Me.mcCalendar.Name = "mcCalendar"
        Me.mcCalendar.TabIndex = 143
        Me.mcCalendar.Visible = False
        '
        'sbSpecialTreatment
        '
        Me.sbSpecialTreatment.Controls.Add(Me.lblReturn_3Month)
        Me.sbSpecialTreatment.Controls.Add(Me.cmdWhite_Glove_End_Date)
        Me.sbSpecialTreatment.Controls.Add(Me.txtWhite_Glove_End_Date)
        Me.sbSpecialTreatment.Controls.Add(Me.txtWhite_Glove_Order_Count)
        Me.sbSpecialTreatment.Controls.Add(Me.lblWhite_Glove)
        Me.sbSpecialTreatment.Controls.Add(Me.Label13)
        Me.sbSpecialTreatment.Controls.Add(Me.chkWhite_Glove)
        Me.sbSpecialTreatment.Controls.Add(Me.Label9)
        Me.sbSpecialTreatment.Location = New System.Drawing.Point(341, 158)
        Me.sbSpecialTreatment.Margin = New System.Windows.Forms.Padding(1)
        Me.sbSpecialTreatment.Name = "sbSpecialTreatment"
        Me.sbSpecialTreatment.Size = New System.Drawing.Size(330, 66)
        Me.sbSpecialTreatment.TabIndex = 145
        Me.sbSpecialTreatment.TabStop = False
        Me.sbSpecialTreatment.Text = "Special Treatment"
        '
        'lblReturn_3Month
        '
        Me.lblReturn_3Month.AutoSize = True
        Me.lblReturn_3Month.BackColor = System.Drawing.Color.Red
        Me.lblReturn_3Month.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblReturn_3Month.Location = New System.Drawing.Point(6, 45)
        Me.lblReturn_3Month.Name = "lblReturn_3Month"
        Me.lblReturn_3Month.Size = New System.Drawing.Size(173, 17)
        Me.lblReturn_3Month.TabIndex = 177
        Me.lblReturn_3Month.Text = "returns() during 3 months"
        Me.lblReturn_3Month.Visible = False
        '
        'txtWhite_Glove_End_Date
        '
        Me.txtWhite_Glove_End_Date.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhite_Glove_End_Date.DataLength = CType(10, Long)
        Me.txtWhite_Glove_End_Date.DataType = CustomerFile.CDataType.dtDate
        Me.txtWhite_Glove_End_Date.DateValue = New Date(CType(0, Long))
        Me.txtWhite_Glove_End_Date.DecimalDigits = CType(0, Long)
        Me.txtWhite_Glove_End_Date.Enabled = False
        Me.txtWhite_Glove_End_Date.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhite_Glove_End_Date.Location = New System.Drawing.Point(185, 14)
        Me.txtWhite_Glove_End_Date.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhite_Glove_End_Date.Mask = Nothing
        Me.txtWhite_Glove_End_Date.Name = "txtWhite_Glove_End_Date"
        Me.txtWhite_Glove_End_Date.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhite_Glove_End_Date.OldValue = Nothing
        Me.txtWhite_Glove_End_Date.Size = New System.Drawing.Size(119, 26)
        Me.txtWhite_Glove_End_Date.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhite_Glove_End_Date.StringValue = Nothing
        Me.txtWhite_Glove_End_Date.TabIndex = 173
        Me.txtWhite_Glove_End_Date.Tag = "txtWhite_Glove_End_Date"
        Me.txtWhite_Glove_End_Date.TextDataID = Nothing
        '
        'txtWhite_Glove_Order_Count
        '
        Me.txtWhite_Glove_Order_Count.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtWhite_Glove_Order_Count.DataLength = CType(0, Long)
        Me.txtWhite_Glove_Order_Count.DataType = CustomerFile.CDataType.dtString
        Me.txtWhite_Glove_Order_Count.DateValue = New Date(CType(0, Long))
        Me.txtWhite_Glove_Order_Count.DecimalDigits = CType(0, Long)
        Me.txtWhite_Glove_Order_Count.Enabled = False
        Me.txtWhite_Glove_Order_Count.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhite_Glove_Order_Count.Location = New System.Drawing.Point(272, 38)
        Me.txtWhite_Glove_Order_Count.Margin = New System.Windows.Forms.Padding(1)
        Me.txtWhite_Glove_Order_Count.Mask = Nothing
        Me.txtWhite_Glove_Order_Count.Name = "txtWhite_Glove_Order_Count"
        Me.txtWhite_Glove_Order_Count.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWhite_Glove_Order_Count.OldValue = Nothing
        Me.txtWhite_Glove_Order_Count.Size = New System.Drawing.Size(54, 26)
        Me.txtWhite_Glove_Order_Count.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtWhite_Glove_Order_Count.StringValue = Nothing
        Me.txtWhite_Glove_Order_Count.TabIndex = 175
        Me.txtWhite_Glove_Order_Count.TextDataID = Nothing
        Me.txtWhite_Glove_Order_Count.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 675)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1016, 25)
        Me.StatusStrip1.TabIndex = 146
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblVersion
        '
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(68, 20)
        Me.lblVersion.Text = "Version : "
        '
        'frmCustomerHeader
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1016, 700)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mcCalendar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.sbSpecialTreatment)
        Me.Controls.Add(Me.tcCusInfo)
        Me.Controls.Add(Me.gbAdvanced)
        Me.Controls.Add(Me.gbCustomer)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 610)
        Me.Name = "frmCustomerHeader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "CF-CUS-HDR-001"
        Me.Text = "Customer Header"
        Me.gbCustomer.ResumeLayout(False)
        Me.gbCustomer.PerformLayout()
        Me.gbAdvanced.ResumeLayout(False)
        Me.gbAdvanced.PerformLayout()
        Me.tcCusInfo.ResumeLayout(False)
        Me.tpAllInOne.ResumeLayout(False)
        Me.gbAIO_PushedOrders.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgvPushedOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.gbAIO_DocContacts.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvDocContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAIO_Options.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAIO_Communications.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvCommunications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAIO_SelfPromo.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvSelfPromo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panSelfPromoHead.ResumeLayout(False)
        Me.panSelfPromoHead.PerformLayout()
        Me.tpCommunications.ResumeLayout(False)
        Me.tpContacts.ResumeLayout(False)
        Me.tpOrders.ResumeLayout(False)
        Me.tpPrograms.ResumeLayout(False)
        Me.tpSpecialPricing.ResumeLayout(False)
        Me.tbQuotes.ResumeLayout(False)
        Me.tpCharges.ResumeLayout(False)
        Me.tpShipping.ResumeLayout(False)
        Me.tpOtherComments.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.sbSpecialTreatment.ResumeLayout(False)
        Me.sbSpecialTreatment.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbAdvanced As System.Windows.Forms.GroupBox
    Friend WithEvents tcCusInfo As System.Windows.Forms.TabControl
    Friend WithEvents tpOrders As System.Windows.Forms.TabPage
    Friend WithEvents tpPrograms As System.Windows.Forms.TabPage
    Friend WithEvents tpCharges As System.Windows.Forms.TabPage
    Friend WithEvents tpShipping As System.Windows.Forms.TabPage
    Friend WithEvents tpCommunications As System.Windows.Forms.TabPage
    Friend WithEvents tpContacts As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTextField1 As System.Windows.Forms.Label
    Friend WithEvents lblClassificationID As System.Windows.Forms.Label
    Friend WithEvents tpOtherComments As System.Windows.Forms.TabPage
    Friend WithEvents txtCmp_FCtry As CustomerFile.xTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStateCode As CustomerFile.xTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_FCity As CustomerFile.xTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_FPC As CustomerFile.xTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_FAdd3 As CustomerFile.xTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_FAdd2 As CustomerFile.xTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_FAdd1 As CustomerFile.xTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_Code As CustomerFile.xTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCmp_Name As CustomerFile.xTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tpAllInOne As System.Windows.Forms.TabPage
    Friend WithEvents gbAIO_Options As System.Windows.Forms.GroupBox
    Friend WithEvents gbAIO_Communications As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCommunications As System.Windows.Forms.DataGridView
    Friend WithEvents gbAIO_SelfPromo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSelfPromo_Amt As CustomerFile.xTextBox
    Friend WithEvents UcOrders As CustomerFile.ucOrders
    Friend WithEvents txtCus_Note_3 As CustomerFile.xTextBox
    Friend WithEvents txtClassificationID As CustomerFile.xTextBox
    Friend WithEvents txtEQP_Status As CustomerFile.xTextBox
    Friend WithEvents UcContacts As CustomerFile.ucContacts
    Friend WithEvents UcPrograms As CustomerFile.ucPrograms
    Friend WithEvents UcCharges As CustomerFile.ucCharges
    Friend WithEvents dgvOptions As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdMacola As System.Windows.Forms.Button
    Friend WithEvents UcComm As CustomerFile.ucComm
    Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents txtPhoneNumber As CustomerFile.xTextBox
    Friend WithEvents txttax_cd_2 As CustomerFile.xTextBox
    Friend WithEvents txttax_cd_3 As CustomerFile.xTextBox
    Friend WithEvents txttax_cd As CustomerFile.xTextBox
    Friend WithEvents lblTxbl_Cd As System.Windows.Forms.Label
    Friend WithEvents chkTxbl_Fg As System.Windows.Forms.CheckBox
    Friend WithEvents lblTxbl_Fg As System.Windows.Forms.Label
    Friend WithEvents txtPaymentCondition_Desc As CustomerFile.xTextBox
    Friend WithEvents txtPaymentCondition As CustomerFile.xTextBox
    Friend WithEvents lblPaymentCondition As System.Windows.Forms.Label
    Friend WithEvents txtShipVia_Desc As CustomerFile.xTextBox
    Friend WithEvents txtShipVia As CustomerFile.xTextBox
    Friend WithEvents lblShipVia As System.Windows.Forms.Label
    Friend WithEvents txtcmp_status_Desc As CustomerFile.xTextBox
    Friend WithEvents txtcmp_status As CustomerFile.xTextBox
    Friend WithEvents lblcmp_status As System.Windows.Forms.Label
    Friend WithEvents gbAIO_DocContacts As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvDocContacts As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvSelfPromo As System.Windows.Forms.DataGridView
    Friend WithEvents panSelfPromoHead As System.Windows.Forms.Panel
    Friend WithEvents lblRemaining As System.Windows.Forms.Label
    Friend WithEvents txtSelfPromo_Remaining As CustomerFile.xTextBox
    Friend WithEvents lblAllowance As System.Windows.Forms.Label
    Friend WithEvents tbQuotes As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRep_Phone As CustomerFile.xTextBox
    Friend WithEvents lblRep_Phone As System.Windows.Forms.Label
    Friend WithEvents txtRep_Desc As CustomerFile.xTextBox
    Friend WithEvents txtRep As CustomerFile.xTextBox
    Friend WithEvents lblRep As System.Windows.Forms.Label
    Friend WithEvents txtCurrency As CustomerFile.xTextBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents txtRegion As CustomerFile.xTextBox
    Friend WithEvents lblTerr As System.Windows.Forms.Label
    Friend WithEvents txtSalesPersonNumber_Desc As CustomerFile.xTextBox
    Friend WithEvents txtSalesPersonNumber As CustomerFile.xTextBox
    Friend WithEvents lblSalesPersonNumber As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRep_Email As CustomerFile.xTextBox
    Friend WithEvents lblRep_Email As System.Windows.Forms.Label
    Friend WithEvents UcQuotes As CustomerFile.ucQuotes
    Friend WithEvents UcShipping As CustomerFile.ucShipping
    Friend WithEvents btnCustomerCharges As System.Windows.Forms.Button
    Friend WithEvents lblAIO_SelfPromoYear As System.Windows.Forms.Label
    Friend WithEvents txtAIO_SelfPromoYear As CustomerFile.xTextBox
    Friend WithEvents gbAIO_PushedOrders As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents dgvPushedOrders As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsNewPushedOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents UcOtherComments As CustomerFile.ucComments
    Friend WithEvents gbCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllowSubstituteItem As System.Windows.Forms.CheckBox
    Friend WithEvents lblAllowSubstituteItem As System.Windows.Forms.Label
    Friend WithEvents chkAllowPartialShipment As System.Windows.Forms.CheckBox
    Friend WithEvents lblAllowPartialShipment As System.Windows.Forms.Label
    Friend WithEvents chkAllowBackOrders As System.Windows.Forms.CheckBox
    Friend WithEvents lblAllowBackOrders As System.Windows.Forms.Label
    Friend WithEvents lblWhite_Glove_Count As System.Windows.Forms.Label
    Friend WithEvents chkWhite_Glove As System.Windows.Forms.CheckBox
    Friend WithEvents lblWhite_Glove As System.Windows.Forms.Label
    Friend WithEvents tsOpenPushedOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDeletePushedOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefreshPushedOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpSpecialPricing As System.Windows.Forms.TabPage
    Friend WithEvents UcSpecialPricing As CustomerFile.ucSpecialPricing
    Friend WithEvents cmdDisruption As System.Windows.Forms.Button
    Friend WithEvents txtWhite_Glove_Order_Count As CustomerFile.xTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtWhite_Glove_End_Date As CustomerFile.xTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdWhite_Glove_End_Date As System.Windows.Forms.Button
    Friend WithEvents mcCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents sbSpecialTreatment As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tpCustPack As System.Windows.Forms.TabPage
    Friend WithEvents lblReturn_3Month As System.Windows.Forms.Label
    Friend WithEvents lblSelfPromo As Label
    Friend WithEvents txtSelfPromo As TextBox
    Friend WithEvents XTxt_SAM_Textfiel4 As xTextBox
    Friend WithEvents Lb_SAM_Textfiel4 As Label
    Friend WithEvents lblVIP As Label
End Class
