<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewDoc))
        Me.panImg = New System.Windows.Forms.Panel()
        Me.webImage = New System.Windows.Forms.WebBrowser()
        Me.panImg.SuspendLayout()
        Me.SuspendLayout()
        '
        'panImg
        '
        Me.panImg.AutoScroll = True
        Me.panImg.AutoSize = True
        Me.panImg.Controls.Add(Me.webImage)
        Me.panImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panImg.Location = New System.Drawing.Point(0, 0)
        Me.panImg.Name = "panImg"
        Me.panImg.Size = New System.Drawing.Size(1025, 535)
        Me.panImg.TabIndex = 0
        '
        'webImage
        '
        Me.webImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webImage.Location = New System.Drawing.Point(0, 0)
        Me.webImage.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webImage.Name = "webImage"
        Me.webImage.Size = New System.Drawing.Size(1025, 535)
        Me.webImage.TabIndex = 0
        '
        'frmPreviewDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1025, 535)
        Me.Controls.Add(Me.panImg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreviewDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPreviewDoc"
        Me.panImg.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panImg As System.Windows.Forms.Panel
    Friend WithEvents webImage As System.Windows.Forms.WebBrowser
End Class
