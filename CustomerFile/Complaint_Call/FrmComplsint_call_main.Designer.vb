<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComplsint_call_main
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_customer_name = New System.Windows.Forms.TextBox()
        Me.tb_customer_phone_no = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_customer_email = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.mtb_ord_no = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_po_no = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_cus_no = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_ref_no = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bt_CreateComplaintHeader = New System.Windows.Forms.Button()
        Me.DataCallHeaderList = New System.Windows.Forms.DataGridView()
        Me.BT_Search = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Rtb_user_name = New System.Windows.Forms.RichTextBox()
        Me.BT_Create_user = New System.Windows.Forms.Button()
        Me.DGV_USER_LIST = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.bt_cfg_save = New System.Windows.Forms.Button()
        Me.DGV_CFG_TABLE_CONTENT = New System.Windows.Forms.DataGridView()
        Me.DGV_CFG_Tables = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataCallHeaderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_USER_LIST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV_CFG_TABLE_CONTENT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_CFG_Tables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(493, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name"
        '
        'tb_customer_name
        '
        Me.tb_customer_name.Location = New System.Drawing.Point(496, 34)
        Me.tb_customer_name.Name = "tb_customer_name"
        Me.tb_customer_name.Size = New System.Drawing.Size(148, 20)
        Me.tb_customer_name.TabIndex = 1
        '
        'tb_customer_phone_no
        '
        Me.tb_customer_phone_no.Location = New System.Drawing.Point(650, 34)
        Me.tb_customer_phone_no.Name = "tb_customer_phone_no"
        Me.tb_customer_phone_no.Size = New System.Drawing.Size(132, 20)
        Me.tb_customer_phone_no.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(647, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer Phon #"
        '
        'tb_customer_email
        '
        Me.tb_customer_email.Location = New System.Drawing.Point(788, 34)
        Me.tb_customer_email.Name = "tb_customer_email"
        Me.tb_customer_email.Size = New System.Drawing.Size(179, 20)
        Me.tb_customer_email.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(785, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Customer Email"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1083, 557)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.mtb_ord_no)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.tb_po_no)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.tb_cus_no)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.tb_ref_no)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.BT_Search)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.tb_customer_email)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.tb_customer_name)
        Me.TabPage1.Controls.Add(Me.tb_customer_phone_no)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1075, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Search"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'mtb_ord_no
        '
        Me.mtb_ord_no.Location = New System.Drawing.Point(191, 33)
        Me.mtb_ord_no.Mask = "0000000"
        Me.mtb_ord_no.Name = "mtb_ord_no"
        Me.mtb_ord_no.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mtb_ord_no.ResetOnSpace = False
        Me.mtb_ord_no.Size = New System.Drawing.Size(100, 20)
        Me.mtb_ord_no.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(188, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "ORD#"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(300, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PO#"
        '
        'tb_po_no
        '
        Me.tb_po_no.Location = New System.Drawing.Point(303, 34)
        Me.tb_po_no.Name = "tb_po_no"
        Me.tb_po_no.Size = New System.Drawing.Size(87, 20)
        Me.tb_po_no.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(401, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "CUS#"
        '
        'tb_cus_no
        '
        Me.tb_cus_no.Location = New System.Drawing.Point(404, 34)
        Me.tb_cus_no.Name = "tb_cus_no"
        Me.tb_cus_no.Size = New System.Drawing.Size(87, 20)
        Me.tb_cus_no.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Ref #"
        '
        'tb_ref_no
        '
        Me.tb_ref_no.Location = New System.Drawing.Point(34, 34)
        Me.tb_ref_no.Name = "tb_ref_no"
        Me.tb_ref_no.Size = New System.Drawing.Size(148, 20)
        Me.tb_ref_no.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_CreateComplaintHeader)
        Me.GroupBox2.Controls.Add(Me.DataCallHeaderList)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1053, 273)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Complaint Call list"
        '
        'bt_CreateComplaintHeader
        '
        Me.bt_CreateComplaintHeader.Location = New System.Drawing.Point(965, 19)
        Me.bt_CreateComplaintHeader.Name = "bt_CreateComplaintHeader"
        Me.bt_CreateComplaintHeader.Size = New System.Drawing.Size(75, 34)
        Me.bt_CreateComplaintHeader.TabIndex = 2
        Me.bt_CreateComplaintHeader.Text = "Create Complaint"
        Me.bt_CreateComplaintHeader.UseVisualStyleBackColor = True
        '
        'DataCallHeaderList
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataCallHeaderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataCallHeaderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataCallHeaderList.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataCallHeaderList.Location = New System.Drawing.Point(18, 19)
        Me.DataCallHeaderList.Name = "DataCallHeaderList"
        Me.DataCallHeaderList.Size = New System.Drawing.Size(945, 248)
        Me.DataCallHeaderList.TabIndex = 1
        '
        'BT_Search
        '
        Me.BT_Search.Location = New System.Drawing.Point(973, 27)
        Me.BT_Search.Name = "BT_Search"
        Me.BT_Search.Size = New System.Drawing.Size(91, 31)
        Me.BT_Search.TabIndex = 9
        Me.BT_Search.Text = "Search"
        Me.BT_Search.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Rtb_user_name)
        Me.GroupBox1.Controls.Add(Me.BT_Create_user)
        Me.GroupBox1.Controls.Add(Me.DGV_USER_LIST)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1053, 182)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User_list"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(962, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Current User"
        '
        'Rtb_user_name
        '
        Me.Rtb_user_name.Location = New System.Drawing.Point(962, 35)
        Me.Rtb_user_name.Name = "Rtb_user_name"
        Me.Rtb_user_name.ReadOnly = True
        Me.Rtb_user_name.Size = New System.Drawing.Size(86, 58)
        Me.Rtb_user_name.TabIndex = 2
        Me.Rtb_user_name.Text = ""
        '
        'BT_Create_user
        '
        Me.BT_Create_user.Location = New System.Drawing.Point(962, 153)
        Me.BT_Create_user.Name = "BT_Create_user"
        Me.BT_Create_user.Size = New System.Drawing.Size(75, 23)
        Me.BT_Create_user.TabIndex = 1
        Me.BT_Create_user.Text = "Create User"
        Me.BT_Create_user.UseVisualStyleBackColor = True
        '
        'DGV_USER_LIST
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_USER_LIST.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_USER_LIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_USER_LIST.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_USER_LIST.Location = New System.Drawing.Point(18, 19)
        Me.DGV_USER_LIST.Name = "DGV_USER_LIST"
        Me.DGV_USER_LIST.Size = New System.Drawing.Size(938, 157)
        Me.DGV_USER_LIST.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.bt_cfg_save)
        Me.TabPage2.Controls.Add(Me.DGV_CFG_TABLE_CONTENT)
        Me.TabPage2.Controls.Add(Me.DGV_CFG_Tables)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1075, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Report"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'bt_cfg_save
        '
        Me.bt_cfg_save.Location = New System.Drawing.Point(994, 6)
        Me.bt_cfg_save.Name = "bt_cfg_save"
        Me.bt_cfg_save.Size = New System.Drawing.Size(75, 23)
        Me.bt_cfg_save.TabIndex = 2
        Me.bt_cfg_save.Text = "save"
        Me.bt_cfg_save.UseVisualStyleBackColor = True
        '
        'DGV_CFG_TABLE_CONTENT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_CFG_TABLE_CONTENT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_CFG_TABLE_CONTENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_CFG_TABLE_CONTENT.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGV_CFG_TABLE_CONTENT.Location = New System.Drawing.Point(6, 329)
        Me.DGV_CFG_TABLE_CONTENT.Name = "DGV_CFG_TABLE_CONTENT"
        Me.DGV_CFG_TABLE_CONTENT.Size = New System.Drawing.Size(1069, 174)
        Me.DGV_CFG_TABLE_CONTENT.TabIndex = 1
        '
        'DGV_CFG_Tables
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_CFG_Tables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV_CFG_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_CFG_Tables.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGV_CFG_Tables.Location = New System.Drawing.Point(9, 35)
        Me.DGV_CFG_Tables.Name = "DGV_CFG_Tables"
        Me.DGV_CFG_Tables.Size = New System.Drawing.Size(1063, 262)
        Me.DGV_CFG_Tables.TabIndex = 0
        '
        'FrmComplsint_call_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 569)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmComplsint_call_main"
        Me.Text = "Complaint Call Main"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataCallHeaderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_USER_LIST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DGV_CFG_TABLE_CONTENT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_CFG_Tables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tb_customer_name As TextBox
    Friend WithEvents tb_customer_phone_no As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_customer_email As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BT_Search As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataCallHeaderList As DataGridView
    Friend WithEvents DGV_USER_LIST As DataGridView
    Friend WithEvents DGV_CFG_Tables As DataGridView
    Friend WithEvents DGV_CFG_TABLE_CONTENT As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_ref_no As TextBox
    Friend WithEvents BT_Create_user As Button
    Friend WithEvents bt_cfg_save As Button
    Friend WithEvents Rtb_user_name As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents bt_CreateComplaintHeader As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents tb_cus_no As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tb_po_no As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents mtb_ord_no As MaskedTextBox
End Class
