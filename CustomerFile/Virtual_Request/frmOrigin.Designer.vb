<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrigin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrigin))
        Me.lblOrigin = New System.Windows.Forms.Label()
        Me.rdCs_Bd = New System.Windows.Forms.RadioButton()
        Me.rdSales = New System.Windows.Forms.RadioButton()
        Me.rdCustomer = New System.Windows.Forms.RadioButton()
        Me.lstViewShowReq = New System.Windows.Forms.ListView()
        Me.rdNoBody = New System.Windows.Forms.RadioButton()
        Me.lblInfoEsc = New System.Windows.Forms.Label()
        Me.rdCs_Online_St_Cat = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'lblOrigin
        '
        Me.lblOrigin.AutoSize = True
        Me.lblOrigin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrigin.Location = New System.Drawing.Point(12, 17)
        Me.lblOrigin.Name = "lblOrigin"
        Me.lblOrigin.Size = New System.Drawing.Size(111, 16)
        Me.lblOrigin.TabIndex = 32
        Me.lblOrigin.Text = "Origin of request :"
        '
        'rdCs_Bd
        '
        Me.rdCs_Bd.AutoSize = True
        Me.rdCs_Bd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCs_Bd.Location = New System.Drawing.Point(140, 61)
        Me.rdCs_Bd.Name = "rdCs_Bd"
        Me.rdCs_Bd.Size = New System.Drawing.Size(234, 20)
        Me.rdCs_Bd.TabIndex = 31
        Me.rdCs_Bd.TabStop = True
        Me.rdCs_Bd.Text = "Request from client, idea generator"
        Me.rdCs_Bd.UseVisualStyleBackColor = True
        '
        'rdSales
        '
        Me.rdSales.AutoSize = True
        Me.rdSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSales.Location = New System.Drawing.Point(140, 38)
        Me.rdSales.Name = "rdSales"
        Me.rdSales.Size = New System.Drawing.Size(230, 20)
        Me.rdSales.TabIndex = 30
        Me.rdSales.TabStop = True
        Me.rdSales.Text = "Request from client, order pending"
        Me.rdSales.UseVisualStyleBackColor = True
        '
        'rdCustomer
        '
        Me.rdCustomer.AutoSize = True
        Me.rdCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCustomer.Location = New System.Drawing.Point(140, 15)
        Me.rdCustomer.Name = "rdCustomer"
        Me.rdCustomer.Size = New System.Drawing.Size(240, 20)
        Me.rdCustomer.TabIndex = 29
        Me.rdCustomer.TabStop = True
        Me.rdCustomer.Text = "Request from client for quote/project"
        Me.rdCustomer.UseVisualStyleBackColor = True
        '
        'lstViewShowReq
        '
        Me.lstViewShowReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstViewShowReq.Location = New System.Drawing.Point(0, 0)
        Me.lstViewShowReq.Name = "lstViewShowReq"
        Me.lstViewShowReq.Size = New System.Drawing.Size(476, 138)
        Me.lstViewShowReq.TabIndex = 28
        Me.lstViewShowReq.UseCompatibleStateImageBehavior = False
        '
        'rdNoBody
        '
        Me.rdNoBody.AutoSize = True
        Me.rdNoBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdNoBody.Location = New System.Drawing.Point(140, 84)
        Me.rdNoBody.Name = "rdNoBody"
        Me.rdNoBody.Size = New System.Drawing.Size(211, 20)
        Me.rdNoBody.TabIndex = 33
        Me.rdNoBody.TabStop = True
        Me.rdNoBody.Text = "Internal request, idea generator"
        Me.rdNoBody.UseVisualStyleBackColor = True
        '
        'lblInfoEsc
        '
        Me.lblInfoEsc.AutoSize = True
        Me.lblInfoEsc.BackColor = System.Drawing.Color.Wheat
        Me.lblInfoEsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoEsc.ForeColor = System.Drawing.Color.Maroon
        Me.lblInfoEsc.Location = New System.Drawing.Point(404, 3)
        Me.lblInfoEsc.Name = "lblInfoEsc"
        Me.lblInfoEsc.Size = New System.Drawing.Size(67, 13)
        Me.lblInfoEsc.TabIndex = 34
        Me.lblInfoEsc.Text = " ESC - EXIT "
        Me.lblInfoEsc.Visible = False
        '
        'rdCs_Online_St_Cat
        '
        Me.rdCs_Online_St_Cat.AutoSize = True
        Me.rdCs_Online_St_Cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCs_Online_St_Cat.Location = New System.Drawing.Point(140, 110)
        Me.rdCs_Online_St_Cat.Name = "rdCs_Online_St_Cat"
        Me.rdCs_Online_St_Cat.Size = New System.Drawing.Size(321, 20)
        Me.rdCs_Online_St_Cat.TabIndex = 35
        Me.rdCs_Online_St_Cat.TabStop = True
        Me.rdCs_Online_St_Cat.Text = "Request from customer for online store/catalogue."
        Me.rdCs_Online_St_Cat.UseVisualStyleBackColor = True
        '
        'frmOrigin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(476, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.rdCs_Online_St_Cat)
        Me.Controls.Add(Me.lblInfoEsc)
        Me.Controls.Add(Me.rdNoBody)
        Me.Controls.Add(Me.lblOrigin)
        Me.Controls.Add(Me.rdCs_Bd)
        Me.Controls.Add(Me.rdSales)
        Me.Controls.Add(Me.rdCustomer)
        Me.Controls.Add(Me.lstViewShowReq)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmOrigin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Origin     "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblOrigin As Label
    Friend WithEvents rdCs_Bd As RadioButton
    Friend WithEvents rdSales As RadioButton
    Friend WithEvents rdCustomer As RadioButton
    Friend WithEvents lstViewShowReq As ListView
    Friend WithEvents rdNoBody As RadioButton
    Friend WithEvents lblInfoEsc As Label
    Friend WithEvents rdCs_Online_St_Cat As RadioButton
End Class
