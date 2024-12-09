<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserMaintenance
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
        Me.lb_first_name = New System.Windows.Forms.Label()
        Me.tb_first_name = New System.Windows.Forms.TextBox()
        Me.tb_last_name = New System.Windows.Forms.TextBox()
        Me.lb_last_name = New System.Windows.Forms.Label()
        Me.lb_language_id = New System.Windows.Forms.Label()
        Me.tb_user_address = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_user_post_code = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_city = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_phone_number = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_email = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bt_Save = New System.Windows.Forms.Button()
        Me.tb_belong_csr = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbb_language_id = New System.Windows.Forms.ComboBox()
        Me.bt_Save_new_complaint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lb_first_name
        '
        Me.lb_first_name.AutoSize = True
        Me.lb_first_name.Location = New System.Drawing.Point(34, 23)
        Me.lb_first_name.Name = "lb_first_name"
        Me.lb_first_name.Size = New System.Drawing.Size(57, 13)
        Me.lb_first_name.TabIndex = 0
        Me.lb_first_name.Text = "First Name"
        '
        'tb_first_name
        '
        Me.tb_first_name.Location = New System.Drawing.Point(97, 23)
        Me.tb_first_name.Name = "tb_first_name"
        Me.tb_first_name.Size = New System.Drawing.Size(100, 20)
        Me.tb_first_name.TabIndex = 1
        '
        'tb_last_name
        '
        Me.tb_last_name.Location = New System.Drawing.Point(287, 23)
        Me.tb_last_name.Name = "tb_last_name"
        Me.tb_last_name.Size = New System.Drawing.Size(176, 20)
        Me.tb_last_name.TabIndex = 3
        '
        'lb_last_name
        '
        Me.lb_last_name.AutoSize = True
        Me.lb_last_name.Location = New System.Drawing.Point(223, 23)
        Me.lb_last_name.Name = "lb_last_name"
        Me.lb_last_name.Size = New System.Drawing.Size(58, 13)
        Me.lb_last_name.TabIndex = 2
        Me.lb_last_name.Text = "Last Name"
        '
        'lb_language_id
        '
        Me.lb_language_id.AutoSize = True
        Me.lb_language_id.Location = New System.Drawing.Point(36, 62)
        Me.lb_language_id.Name = "lb_language_id"
        Me.lb_language_id.Size = New System.Drawing.Size(55, 13)
        Me.lb_language_id.TabIndex = 4
        Me.lb_language_id.Text = "Language"
        '
        'tb_user_address
        '
        Me.tb_user_address.Location = New System.Drawing.Point(97, 107)
        Me.tb_user_address.Name = "tb_user_address"
        Me.tb_user_address.Size = New System.Drawing.Size(100, 20)
        Me.tb_user_address.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Address"
        '
        'tb_user_post_code
        '
        Me.tb_user_post_code.Location = New System.Drawing.Point(287, 107)
        Me.tb_user_post_code.Name = "tb_user_post_code"
        Me.tb_user_post_code.Size = New System.Drawing.Size(176, 20)
        Me.tb_user_post_code.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Post Code"
        '
        'tb_city
        '
        Me.tb_city.Location = New System.Drawing.Point(97, 133)
        Me.tb_city.Name = "tb_city"
        Me.tb_city.Size = New System.Drawing.Size(100, 20)
        Me.tb_city.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "City"
        '
        'tb_phone_number
        '
        Me.tb_phone_number.Location = New System.Drawing.Point(287, 62)
        Me.tb_phone_number.Name = "tb_phone_number"
        Me.tb_phone_number.Size = New System.Drawing.Size(176, 20)
        Me.tb_phone_number.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Phone #"
        '
        'tb_email
        '
        Me.tb_email.Location = New System.Drawing.Point(97, 174)
        Me.tb_email.Name = "tb_email"
        Me.tb_email.Size = New System.Drawing.Size(366, 20)
        Me.tb_email.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Email"
        '
        'bt_Save
        '
        Me.bt_Save.Location = New System.Drawing.Point(226, 216)
        Me.bt_Save.Name = "bt_Save"
        Me.bt_Save.Size = New System.Drawing.Size(55, 23)
        Me.bt_Save.TabIndex = 16
        Me.bt_Save.Text = "Save"
        Me.bt_Save.UseVisualStyleBackColor = True
        '
        'tb_belong_csr
        '
        Me.tb_belong_csr.Location = New System.Drawing.Point(97, 216)
        Me.tb_belong_csr.Name = "tb_belong_csr"
        Me.tb_belong_csr.Size = New System.Drawing.Size(100, 20)
        Me.tb_belong_csr.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Belong CSR"
        '
        'cbb_language_id
        '
        Me.cbb_language_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbb_language_id.FormattingEnabled = True
        Me.cbb_language_id.Location = New System.Drawing.Point(97, 59)
        Me.cbb_language_id.Name = "cbb_language_id"
        Me.cbb_language_id.Size = New System.Drawing.Size(121, 21)
        Me.cbb_language_id.TabIndex = 19
        '
        'bt_Save_new_complaint
        '
        Me.bt_Save_new_complaint.Location = New System.Drawing.Point(312, 216)
        Me.bt_Save_new_complaint.Name = "bt_Save_new_complaint"
        Me.bt_Save_new_complaint.Size = New System.Drawing.Size(151, 23)
        Me.bt_Save_new_complaint.TabIndex = 20
        Me.bt_Save_new_complaint.Text = "save and create complaint"
        Me.bt_Save_new_complaint.UseVisualStyleBackColor = True
        '
        'frmUserMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 260)
        Me.Controls.Add(Me.bt_Save_new_complaint)
        Me.Controls.Add(Me.cbb_language_id)
        Me.Controls.Add(Me.tb_belong_csr)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.bt_Save)
        Me.Controls.Add(Me.tb_email)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_phone_number)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_city)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_user_post_code)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_user_address)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lb_language_id)
        Me.Controls.Add(Me.tb_last_name)
        Me.Controls.Add(Me.lb_last_name)
        Me.Controls.Add(Me.tb_first_name)
        Me.Controls.Add(Me.lb_first_name)
        Me.Name = "frmUserMaintenance"
        Me.Text = "User Maintenance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lb_first_name As Label
    Friend WithEvents tb_first_name As TextBox
    Friend WithEvents tb_last_name As TextBox
    Friend WithEvents lb_last_name As Label
    Friend WithEvents lb_language_id As Label
    Friend WithEvents tb_user_address As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tb_user_post_code As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_city As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_phone_number As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_email As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents bt_Save As Button
    Friend WithEvents tb_belong_csr As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbb_language_id As ComboBox
    Friend WithEvents bt_Save_new_complaint As Button
End Class
