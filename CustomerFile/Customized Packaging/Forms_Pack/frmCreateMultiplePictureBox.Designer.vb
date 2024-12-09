<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateMultiplePictureBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateMultiplePictureBox))
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtStripW = New System.Windows.Forms.ToolStripTextBox()
        Me.HeightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtStripH = New System.Windows.Forms.ToolStripTextBox()
        Me.CustomImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stStripBottom = New System.Windows.Forms.StatusStrip()
        Me.stStripHightLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stStripHightText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlInchHeight = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDepth = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTxtDepth = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlInchWidth = New System.Windows.Forms.ToolStripLabel()
        Me.tsStripWidthText = New System.Windows.Forms.ToolStripLabel()
        Me.stStripWidthLabel = New System.Windows.Forms.ToolStripLabel()
        Me.tlStripComboPack = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlStripBtnOrientation = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlStripZoom = New System.Windows.Forms.ToolStripLabel()
        Me.tlStripZoomRes = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblClient = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblCus_Prog_Id = New System.Windows.Forms.ToolStripLabel()
        Me.cms.SuspendLayout()
        Me.stStripBottom.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.WidthToolStripMenuItem, Me.HeightToolStripMenuItem, Me.CustomImageToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(190, 92)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'WidthToolStripMenuItem
        '
        Me.WidthToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStripW})
        Me.WidthToolStripMenuItem.Name = "WidthToolStripMenuItem"
        Me.WidthToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WidthToolStripMenuItem.Text = "Width"
        '
        'txtStripW
        '
        Me.txtStripW.Name = "txtStripW"
        Me.txtStripW.Size = New System.Drawing.Size(100, 23)
        '
        'HeightToolStripMenuItem
        '
        Me.HeightToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStripH})
        Me.HeightToolStripMenuItem.Name = "HeightToolStripMenuItem"
        Me.HeightToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HeightToolStripMenuItem.Text = "Height"
        '
        'txtStripH
        '
        Me.txtStripH.Name = "txtStripH"
        Me.txtStripH.Size = New System.Drawing.Size(100, 23)
        '
        'CustomImageToolStripMenuItem
        '
        Me.CustomImageToolStripMenuItem.Name = "CustomImageToolStripMenuItem"
        Me.CustomImageToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.CustomImageToolStripMenuItem.Text = "Custom White Image "
        '
        'stStripBottom
        '
        Me.stStripBottom.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stStripBottom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stStripHightLabel, Me.stStripHightText, Me.tlInchHeight, Me.lblDepth, Me.lblTxtDepth})
        Me.stStripBottom.Location = New System.Drawing.Point(0, 468)
        Me.stStripBottom.Name = "stStripBottom"
        Me.stStripBottom.Size = New System.Drawing.Size(833, 22)
        Me.stStripBottom.TabIndex = 1
        Me.stStripBottom.Text = "StatusStrip1"
        '
        'stStripHightLabel
        '
        Me.stStripHightLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stStripHightLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stStripHightLabel.Name = "stStripHightLabel"
        Me.stStripHightLabel.Size = New System.Drawing.Size(45, 17)
        Me.stStripHightLabel.Text = "Height"
        '
        'stStripHightText
        '
        Me.stStripHightText.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stStripHightText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stStripHightText.Name = "stStripHightText"
        Me.stStripHightText.Size = New System.Drawing.Size(14, 17)
        Me.stStripHightText.Text = "0"
        '
        'tlInchHeight
        '
        Me.tlInchHeight.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tlInchHeight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlInchHeight.Name = "tlInchHeight"
        Me.tlInchHeight.Size = New System.Drawing.Size(30, 17)
        Me.tlInchHeight.Text = "inch"
        '
        'lblDepth
        '
        Me.lblDepth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepth.Name = "lblDepth"
        Me.lblDepth.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.lblDepth.Size = New System.Drawing.Size(144, 17)
        Me.lblDepth.Text = "Depth of the box - "
        Me.lblDepth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTxtDepth
        '
        Me.lblTxtDepth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTxtDepth.Name = "lblTxtDepth"
        Me.lblTxtDepth.Size = New System.Drawing.Size(14, 17)
        Me.lblTxtDepth.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlInchWidth, Me.tsStripWidthText, Me.stStripWidthLabel, Me.tlStripComboPack, Me.ToolStripSeparator3, Me.tlStripBtnOrientation, Me.ToolStripSeparator2, Me.tlStripZoom, Me.tlStripZoomRes, Me.ToolStripSeparator1, Me.lblClient, Me.ToolStripSeparator4, Me.lblCus_Prog_Id})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tlInchWidth
        '
        Me.tlInchWidth.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tlInchWidth.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tlInchWidth.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlInchWidth.Name = "tlInchWidth"
        Me.tlInchWidth.Size = New System.Drawing.Size(30, 22)
        Me.tlInchWidth.Text = "inch"
        '
        'tsStripWidthText
        '
        Me.tsStripWidthText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsStripWidthText.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tsStripWidthText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsStripWidthText.Name = "tsStripWidthText"
        Me.tsStripWidthText.Size = New System.Drawing.Size(14, 22)
        Me.tsStripWidthText.Text = "0"
        '
        'stStripWidthLabel
        '
        Me.stStripWidthLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.stStripWidthLabel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stStripWidthLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stStripWidthLabel.Name = "stStripWidthLabel"
        Me.stStripWidthLabel.Size = New System.Drawing.Size(41, 22)
        Me.stStripWidthLabel.Text = "Width"
        '
        'tlStripComboPack
        '
        Me.tlStripComboPack.Name = "tlStripComboPack"
        Me.tlStripComboPack.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tlStripBtnOrientation
        '
        Me.tlStripBtnOrientation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlStripBtnOrientation.Image = CType(resources.GetObject("tlStripBtnOrientation.Image"), System.Drawing.Image)
        Me.tlStripBtnOrientation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlStripBtnOrientation.Name = "tlStripBtnOrientation"
        Me.tlStripBtnOrientation.Size = New System.Drawing.Size(115, 22)
        Me.tlStripBtnOrientation.Text = "Change Orientation"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tlStripZoom
        '
        Me.tlStripZoom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlStripZoom.Name = "tlStripZoom"
        Me.tlStripZoom.Size = New System.Drawing.Size(50, 22)
        Me.tlStripZoom.Text = "Zoom - "
        '
        'tlStripZoomRes
        '
        Me.tlStripZoomRes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlStripZoomRes.Name = "tlStripZoomRes"
        Me.tlStripZoomRes.Size = New System.Drawing.Size(14, 22)
        Me.tlStripZoomRes.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblClient
        '
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(38, 22)
        Me.lblClient.Text = "Client"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'lblCus_Prog_Id
        '
        Me.lblCus_Prog_Id.Name = "lblCus_Prog_Id"
        Me.lblCus_Prog_Id.Size = New System.Drawing.Size(72, 22)
        Me.lblCus_Prog_Id.Text = "Cus_Prog_Id"
        '
        'frmCreateMultiplePictureBox
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(833, 490)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.stStripBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateMultiplePictureBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Customized Packaging"
        Me.cms.ResumeLayout(False)
        Me.stStripBottom.ResumeLayout(False)
        Me.stStripBottom.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HeightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStripW As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtStripH As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents stStripBottom As System.Windows.Forms.StatusStrip
    Friend WithEvents stStripHightLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents stStripWidthLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents stStripHightText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsStripWidthText As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tlInchHeight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlInchWidth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tlStripComboPack As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tlStripBtnOrientation As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlStripZoom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tlStripZoomRes As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDepth As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTxtDepth As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblClient As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblCus_Prog_Id As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CustomImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
