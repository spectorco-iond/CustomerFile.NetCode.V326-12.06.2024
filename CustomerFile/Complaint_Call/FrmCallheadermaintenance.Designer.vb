<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCallheadermaintenance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_user_name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_call_time = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DgvComplatinDetailList = New System.Windows.Forms.DataGridView()
        Me.bt_save = New System.Windows.Forms.Button()
        Me.Cbo_call_type = New System.Windows.Forms.ComboBox()
        Me.Cbo_call_level = New System.Windows.Forms.ComboBox()
        Me.Cbo_call_status = New System.Windows.Forms.ComboBox()
        Me.LabelUserId = New System.Windows.Forms.Label()
        Me.LabelheaderId = New System.Windows.Forms.Label()
        Me.bt_add_detail = New System.Windows.Forms.Button()
        Me.gb_complaintdetail = New System.Windows.Forms.GroupBox()
        Me.btn_complatin_doc_del = New System.Windows.Forms.Button()
        Me.btn_complatin_doc_add = New System.Windows.Forms.Button()
        Me.Dgv_complatin_doc = New System.Windows.Forms.DataGridView()
        Me.mtb_purchase_qty = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_ord_no = New System.Windows.Forms.MaskedTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tb_input_ord_no = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cb_no_need_po = New System.Windows.Forms.CheckBox()
        Me.tb_input_po_no = New System.Windows.Forms.TextBox()
        Me.tb_product_desc = New System.Windows.Forms.TextBox()
        Me.lab_po_no = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgv_po_no_list = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_logo_on_product = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_lot_no = New System.Windows.Forms.TextBox()
        Me.lable11 = New System.Windows.Forms.Label()
        Me.dtp_expiry_date = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lb_new_flag = New System.Windows.Forms.Label()
        Me.dgv_item_list = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtx_notes = New System.Windows.Forms.RichTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rtx_complaint_detail = New System.Windows.Forms.RichTextBox()
        Me.tb_purchase_from = New System.Windows.Forms.TextBox()
        Me.tb_item_no = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbb_complaint_detail_type = New System.Windows.Forms.ComboBox()
        Me.cbb_product_id = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lb_email = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lb_address = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lb_phone_no = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        CType(Me.DgvComplatinDetailList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_complaintdetail.SuspendLayout()
        CType(Me.Dgv_complatin_doc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_po_no_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_item_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'tb_user_name
        '
        Me.tb_user_name.Location = New System.Drawing.Point(91, 37)
        Me.tb_user_name.Name = "tb_user_name"
        Me.tb_user_name.ReadOnly = True
        Me.tb_user_name.Size = New System.Drawing.Size(334, 20)
        Me.tb_user_name.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Call type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Call_level"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Status"
        '
        'tb_call_time
        '
        Me.tb_call_time.Enabled = False
        Me.tb_call_time.Location = New System.Drawing.Point(280, 156)
        Me.tb_call_time.Name = "tb_call_time"
        Me.tb_call_time.Size = New System.Drawing.Size(119, 20)
        Me.tb_call_time.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(228, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Call time"
        '
        'DgvComplatinDetailList
        '
        Me.DgvComplatinDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvComplatinDetailList.Location = New System.Drawing.Point(433, 38)
        Me.DgvComplatinDetailList.Name = "DgvComplatinDetailList"
        Me.DgvComplatinDetailList.ReadOnly = True
        Me.DgvComplatinDetailList.Size = New System.Drawing.Size(727, 112)
        Me.DgvComplatinDetailList.TabIndex = 10
        '
        'bt_save
        '
        Me.bt_save.Location = New System.Drawing.Point(1101, 152)
        Me.bt_save.Name = "bt_save"
        Me.bt_save.Size = New System.Drawing.Size(59, 24)
        Me.bt_save.TabIndex = 11
        Me.bt_save.Text = "Save"
        Me.bt_save.UseVisualStyleBackColor = True
        '
        'Cbo_call_type
        '
        Me.Cbo_call_type.FormattingEnabled = True
        Me.Cbo_call_type.Location = New System.Drawing.Point(60, 128)
        Me.Cbo_call_type.Name = "Cbo_call_type"
        Me.Cbo_call_type.Size = New System.Drawing.Size(129, 21)
        Me.Cbo_call_type.TabIndex = 12
        '
        'Cbo_call_level
        '
        Me.Cbo_call_level.FormattingEnabled = True
        Me.Cbo_call_level.Location = New System.Drawing.Point(280, 128)
        Me.Cbo_call_level.Name = "Cbo_call_level"
        Me.Cbo_call_level.Size = New System.Drawing.Size(119, 21)
        Me.Cbo_call_level.TabIndex = 13
        '
        'Cbo_call_status
        '
        Me.Cbo_call_status.FormattingEnabled = True
        Me.Cbo_call_status.Location = New System.Drawing.Point(60, 155)
        Me.Cbo_call_status.Name = "Cbo_call_status"
        Me.Cbo_call_status.Size = New System.Drawing.Size(129, 21)
        Me.Cbo_call_status.TabIndex = 14
        '
        'LabelUserId
        '
        Me.LabelUserId.AutoSize = True
        Me.LabelUserId.Location = New System.Drawing.Point(242, 22)
        Me.LabelUserId.Name = "LabelUserId"
        Me.LabelUserId.Size = New System.Drawing.Size(64, 13)
        Me.LabelUserId.TabIndex = 15
        Me.LabelUserId.Text = "LabelUserId"
        '
        'LabelheaderId
        '
        Me.LabelheaderId.AutoSize = True
        Me.LabelheaderId.Location = New System.Drawing.Point(93, 23)
        Me.LabelheaderId.Name = "LabelheaderId"
        Me.LabelheaderId.Size = New System.Drawing.Size(75, 13)
        Me.LabelheaderId.TabIndex = 16
        Me.LabelheaderId.Text = "LabelheaderId"
        '
        'bt_add_detail
        '
        Me.bt_add_detail.Location = New System.Drawing.Point(433, 153)
        Me.bt_add_detail.Name = "bt_add_detail"
        Me.bt_add_detail.Size = New System.Drawing.Size(162, 23)
        Me.bt_add_detail.TabIndex = 18
        Me.bt_add_detail.Text = "Add Complaint Detail"
        Me.bt_add_detail.UseVisualStyleBackColor = True
        '
        'gb_complaintdetail
        '
        Me.gb_complaintdetail.Controls.Add(Me.Label25)
        Me.gb_complaintdetail.Controls.Add(Me.btn_complatin_doc_del)
        Me.gb_complaintdetail.Controls.Add(Me.btn_complatin_doc_add)
        Me.gb_complaintdetail.Controls.Add(Me.Dgv_complatin_doc)
        Me.gb_complaintdetail.Controls.Add(Me.mtb_purchase_qty)
        Me.gb_complaintdetail.Controls.Add(Me.mtb_ord_no)
        Me.gb_complaintdetail.Controls.Add(Me.Label24)
        Me.gb_complaintdetail.Controls.Add(Me.tb_input_ord_no)
        Me.gb_complaintdetail.Controls.Add(Me.Label23)
        Me.gb_complaintdetail.Controls.Add(Me.cb_no_need_po)
        Me.gb_complaintdetail.Controls.Add(Me.tb_input_po_no)
        Me.gb_complaintdetail.Controls.Add(Me.tb_product_desc)
        Me.gb_complaintdetail.Controls.Add(Me.lab_po_no)
        Me.gb_complaintdetail.Controls.Add(Me.Label17)
        Me.gb_complaintdetail.Controls.Add(Me.dgv_po_no_list)
        Me.gb_complaintdetail.Controls.Add(Me.Label13)
        Me.gb_complaintdetail.Controls.Add(Me.tb_logo_on_product)
        Me.gb_complaintdetail.Controls.Add(Me.Label16)
        Me.gb_complaintdetail.Controls.Add(Me.tb_lot_no)
        Me.gb_complaintdetail.Controls.Add(Me.lable11)
        Me.gb_complaintdetail.Controls.Add(Me.dtp_expiry_date)
        Me.gb_complaintdetail.Controls.Add(Me.Label15)
        Me.gb_complaintdetail.Controls.Add(Me.lb_new_flag)
        Me.gb_complaintdetail.Controls.Add(Me.dgv_item_list)
        Me.gb_complaintdetail.Controls.Add(Me.Label11)
        Me.gb_complaintdetail.Controls.Add(Me.Label10)
        Me.gb_complaintdetail.Controls.Add(Me.Label9)
        Me.gb_complaintdetail.Controls.Add(Me.Label7)
        Me.gb_complaintdetail.Controls.Add(Me.rtx_notes)
        Me.gb_complaintdetail.Controls.Add(Me.Label12)
        Me.gb_complaintdetail.Controls.Add(Me.rtx_complaint_detail)
        Me.gb_complaintdetail.Controls.Add(Me.tb_purchase_from)
        Me.gb_complaintdetail.Controls.Add(Me.tb_item_no)
        Me.gb_complaintdetail.Controls.Add(Me.Label8)
        Me.gb_complaintdetail.Controls.Add(Me.cbb_complaint_detail_type)
        Me.gb_complaintdetail.Controls.Add(Me.cbb_product_id)
        Me.gb_complaintdetail.Controls.Add(Me.Label6)
        Me.gb_complaintdetail.Location = New System.Drawing.Point(12, 198)
        Me.gb_complaintdetail.Name = "gb_complaintdetail"
        Me.gb_complaintdetail.Size = New System.Drawing.Size(1172, 360)
        Me.gb_complaintdetail.TabIndex = 36
        Me.gb_complaintdetail.TabStop = False
        Me.gb_complaintdetail.Text = "Complaint detail"
        '
        'btn_complatin_doc_del
        '
        Me.btn_complatin_doc_del.Location = New System.Drawing.Point(1091, 326)
        Me.btn_complatin_doc_del.Name = "btn_complatin_doc_del"
        Me.btn_complatin_doc_del.Size = New System.Drawing.Size(75, 23)
        Me.btn_complatin_doc_del.TabIndex = 70
        Me.btn_complatin_doc_del.Text = "Del"
        Me.btn_complatin_doc_del.UseVisualStyleBackColor = True
        '
        'btn_complatin_doc_add
        '
        Me.btn_complatin_doc_add.Location = New System.Drawing.Point(955, 326)
        Me.btn_complatin_doc_add.Name = "btn_complatin_doc_add"
        Me.btn_complatin_doc_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_complatin_doc_add.TabIndex = 69
        Me.btn_complatin_doc_add.Text = "Add"
        Me.btn_complatin_doc_add.UseVisualStyleBackColor = True
        '
        'Dgv_complatin_doc
        '
        Me.Dgv_complatin_doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_complatin_doc.Location = New System.Drawing.Point(955, 191)
        Me.Dgv_complatin_doc.Name = "Dgv_complatin_doc"
        Me.Dgv_complatin_doc.Size = New System.Drawing.Size(211, 136)
        Me.Dgv_complatin_doc.TabIndex = 68
        '
        'mtb_purchase_qty
        '
        Me.mtb_purchase_qty.Location = New System.Drawing.Point(78, 209)
        Me.mtb_purchase_qty.Mask = "00000"
        Me.mtb_purchase_qty.Name = "mtb_purchase_qty"
        Me.mtb_purchase_qty.ResetOnSpace = False
        Me.mtb_purchase_qty.Size = New System.Drawing.Size(117, 20)
        Me.mtb_purchase_qty.TabIndex = 67
        Me.mtb_purchase_qty.ValidatingType = GetType(Integer)
        '
        'mtb_ord_no
        '
        Me.mtb_ord_no.Location = New System.Drawing.Point(78, 231)
        Me.mtb_ord_no.Mask = "0000000"
        Me.mtb_ord_no.Name = "mtb_ord_no"
        Me.mtb_ord_no.ResetOnSpace = False
        Me.mtb_ord_no.Size = New System.Drawing.Size(117, 20)
        Me.mtb_ord_no.TabIndex = 66
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(43, 238)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 64
        Me.Label24.Text = "Ord#"
        '
        'tb_input_ord_no
        '
        Me.tb_input_ord_no.Location = New System.Drawing.Point(286, 33)
        Me.tb_input_ord_no.Name = "tb_input_ord_no"
        Me.tb_input_ord_no.Size = New System.Drawing.Size(119, 20)
        Me.tb_input_ord_no.TabIndex = 63
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(247, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(31, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Ord#"
        '
        'cb_no_need_po
        '
        Me.cb_no_need_po.AutoSize = True
        Me.cb_no_need_po.Location = New System.Drawing.Point(409, 34)
        Me.cb_no_need_po.Name = "cb_no_need_po"
        Me.cb_no_need_po.Size = New System.Drawing.Size(119, 17)
        Me.cb_no_need_po.TabIndex = 61
        Me.cb_no_need_po.Text = "No need PO# Ord#"
        Me.cb_no_need_po.UseVisualStyleBackColor = True
        '
        'tb_input_po_no
        '
        Me.tb_input_po_no.Location = New System.Drawing.Point(61, 34)
        Me.tb_input_po_no.Name = "tb_input_po_no"
        Me.tb_input_po_no.Size = New System.Drawing.Size(134, 20)
        Me.tb_input_po_no.TabIndex = 60
        '
        'tb_product_desc
        '
        Me.tb_product_desc.Location = New System.Drawing.Point(78, 333)
        Me.tb_product_desc.Name = "tb_product_desc"
        Me.tb_product_desc.Size = New System.Drawing.Size(446, 20)
        Me.tb_product_desc.TabIndex = 59
        '
        'lab_po_no
        '
        Me.lab_po_no.AutoSize = True
        Me.lab_po_no.Location = New System.Drawing.Point(83, 16)
        Me.lab_po_no.Name = "lab_po_no"
        Me.lab_po_no.Size = New System.Drawing.Size(25, 13)
        Me.lab_po_no.TabIndex = 39
        Me.lab_po_no.Text = "___"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 336)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Product Desc"
        '
        'dgv_po_no_list
        '
        Me.dgv_po_no_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_po_no_list.Location = New System.Drawing.Point(12, 56)
        Me.dgv_po_no_list.Name = "dgv_po_no_list"
        Me.dgv_po_no_list.Size = New System.Drawing.Size(512, 100)
        Me.dgv_po_no_list.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "PO NO->"
        '
        'tb_logo_on_product
        '
        Me.tb_logo_on_product.Location = New System.Drawing.Point(372, 282)
        Me.tb_logo_on_product.Name = "tb_logo_on_product"
        Me.tb_logo_on_product.Size = New System.Drawing.Size(152, 20)
        Me.tb_logo_on_product.TabIndex = 57
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(290, 285)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Logo on product"
        '
        'tb_lot_no
        '
        Me.tb_lot_no.Location = New System.Drawing.Point(78, 254)
        Me.tb_lot_no.Name = "tb_lot_no"
        Me.tb_lot_no.Size = New System.Drawing.Size(117, 20)
        Me.tb_lot_no.TabIndex = 55
        '
        'lable11
        '
        Me.lable11.AutoSize = True
        Me.lable11.Location = New System.Drawing.Point(38, 260)
        Me.lable11.Name = "lable11"
        Me.lable11.Size = New System.Drawing.Size(35, 13)
        Me.lable11.TabIndex = 54
        Me.lable11.Text = "LOT#"
        '
        'dtp_expiry_date
        '
        Me.dtp_expiry_date.Location = New System.Drawing.Point(78, 279)
        Me.dtp_expiry_date.Name = "dtp_expiry_date"
        Me.dtp_expiry_date.Size = New System.Drawing.Size(206, 20)
        Me.dtp_expiry_date.TabIndex = 53
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 279)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Expiry Date"
        '
        'lb_new_flag
        '
        Me.lb_new_flag.AutoSize = True
        Me.lb_new_flag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_new_flag.Location = New System.Drawing.Point(89, 0)
        Me.lb_new_flag.Name = "lb_new_flag"
        Me.lb_new_flag.Size = New System.Drawing.Size(64, 16)
        Me.lb_new_flag.TabIndex = 51
        Me.lb_new_flag.Text = "NEW........"
        '
        'dgv_item_list
        '
        Me.dgv_item_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_item_list.Location = New System.Drawing.Point(201, 162)
        Me.dgv_item_list.Name = "dgv_item_list"
        Me.dgv_item_list.ReadOnly = True
        Me.dgv_item_list.Size = New System.Drawing.Size(323, 113)
        Me.dgv_item_list.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(778, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Complaint Detail"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(0, 306)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Purchase From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Purchase Qty"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(290, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Complaint type"
        '
        'rtx_notes
        '
        Me.rtx_notes.Location = New System.Drawing.Point(530, 191)
        Me.rtx_notes.Name = "rtx_notes"
        Me.rtx_notes.Size = New System.Drawing.Size(419, 158)
        Me.rtx_notes.TabIndex = 45
        Me.rtx_notes.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(724, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Notes"
        '
        'rtx_complaint_detail
        '
        Me.rtx_complaint_detail.Location = New System.Drawing.Point(530, 32)
        Me.rtx_complaint_detail.Name = "rtx_complaint_detail"
        Me.rtx_complaint_detail.Size = New System.Drawing.Size(636, 142)
        Me.rtx_complaint_detail.TabIndex = 43
        Me.rtx_complaint_detail.Text = ""
        '
        'tb_purchase_from
        '
        Me.tb_purchase_from.Location = New System.Drawing.Point(78, 305)
        Me.tb_purchase_from.Name = "tb_purchase_from"
        Me.tb_purchase_from.Size = New System.Drawing.Size(206, 20)
        Me.tb_purchase_from.TabIndex = 42
        '
        'tb_item_no
        '
        Me.tb_item_no.Location = New System.Drawing.Point(78, 164)
        Me.tb_item_no.Name = "tb_item_no"
        Me.tb_item_no.Size = New System.Drawing.Size(117, 20)
        Me.tb_item_no.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "item no"
        '
        'cbb_complaint_detail_type
        '
        Me.cbb_complaint_detail_type.FormattingEnabled = True
        Me.cbb_complaint_detail_type.Location = New System.Drawing.Point(372, 306)
        Me.cbb_complaint_detail_type.Name = "cbb_complaint_detail_type"
        Me.cbb_complaint_detail_type.Size = New System.Drawing.Size(152, 21)
        Me.cbb_complaint_detail_type.TabIndex = 38
        '
        'cbb_product_id
        '
        Me.cbb_product_id.FormattingEnabled = True
        Me.cbb_product_id.Location = New System.Drawing.Point(78, 186)
        Me.cbb_product_id.Name = "cbb_product_id"
        Me.cbb_product_id.Size = New System.Drawing.Size(117, 21)
        Me.cbb_product_id.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "product"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(646, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(184, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Complatint Detail Lists: (READ ONLY)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lb_email)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lb_address)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lb_phone_no)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.DgvComplatinDetailList)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.bt_save)
        Me.GroupBox1.Controls.Add(Me.bt_add_detail)
        Me.GroupBox1.Controls.Add(Me.LabelheaderId)
        Me.GroupBox1.Controls.Add(Me.tb_user_name)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LabelUserId)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cbo_call_status)
        Me.GroupBox1.Controls.Add(Me.tb_call_time)
        Me.GroupBox1.Controls.Add(Me.Cbo_call_level)
        Me.GroupBox1.Controls.Add(Me.Cbo_call_type)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1166, 180)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Complaint Header:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(222, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 13)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "Id:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(26, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Ref:"
        '
        'lb_email
        '
        Me.lb_email.AutoSize = True
        Me.lb_email.Location = New System.Drawing.Point(119, 108)
        Me.lb_email.Name = "lb_email"
        Me.lb_email.Size = New System.Drawing.Size(45, 13)
        Me.lb_email.TabIndex = 46
        Me.lb_email.Text = "Label23"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(28, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Email"
        '
        'lb_address
        '
        Me.lb_address.AutoSize = True
        Me.lb_address.Location = New System.Drawing.Point(119, 83)
        Me.lb_address.Name = "lb_address"
        Me.lb_address.Size = New System.Drawing.Size(45, 13)
        Me.lb_address.TabIndex = 44
        Me.lb_address.Text = "Label21"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(30, 83)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Address"
        '
        'lb_phone_no
        '
        Me.lb_phone_no.AutoSize = True
        Me.lb_phone_no.Location = New System.Drawing.Point(119, 61)
        Me.lb_phone_no.Name = "lb_phone_no"
        Me.lb_phone_no.Size = New System.Drawing.Size(45, 13)
        Me.lb_phone_no.TabIndex = 42
        Me.lb_phone_no.Text = "Label19"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(25, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Phone #"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1041, 175)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Doc"
        '
        'FrmCallheadermaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 569)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb_complaintdetail)
        Me.Name = "FrmCallheadermaintenance"
        Me.Text = "Complaint detail maintenance"
        CType(Me.DgvComplatinDetailList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_complaintdetail.ResumeLayout(False)
        Me.gb_complaintdetail.PerformLayout()
        CType(Me.Dgv_complatin_doc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_po_no_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_item_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub



    Friend WithEvents Label1 As Label
    Friend WithEvents tb_user_name As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tb_call_time As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DgvComplatinDetailList As DataGridView
    Friend WithEvents bt_save As Button
    Friend WithEvents Cbo_call_type As ComboBox
    Friend WithEvents Cbo_call_level As ComboBox
    Friend WithEvents Cbo_call_status As ComboBox
    Friend WithEvents LabelUserId As Label
    Friend WithEvents LabelheaderId As Label
    Friend WithEvents bt_add_detail As Button
    Friend WithEvents gb_complaintdetail As GroupBox
    Friend WithEvents dgv_item_list As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents rtx_notes As RichTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents rtx_complaint_detail As RichTextBox
    Friend WithEvents tb_purchase_from As TextBox
    Friend WithEvents tb_item_no As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbb_complaint_detail_type As ComboBox
    Friend WithEvents cbb_product_id As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lb_new_flag As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dgv_po_no_list As DataGridView
    Friend WithEvents lab_po_no As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents dtp_expiry_date As DateTimePicker
    Friend WithEvents tb_lot_no As TextBox
    Friend WithEvents lable11 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents tb_logo_on_product As TextBox
    Friend WithEvents tb_product_desc As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tb_input_po_no As TextBox
    Friend WithEvents lb_email As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lb_address As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lb_phone_no As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents cb_no_need_po As CheckBox
    Friend WithEvents tb_input_ord_no As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents mtb_ord_no As MaskedTextBox
    Friend WithEvents mtb_purchase_qty As MaskedTextBox
    Friend WithEvents Dgv_complatin_doc As DataGridView
    Friend WithEvents btn_complatin_doc_del As Button
    Friend WithEvents btn_complatin_doc_add As Button
    Friend WithEvents Label25 As Label
End Class
