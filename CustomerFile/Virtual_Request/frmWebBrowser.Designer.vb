<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWebBrowser
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
        Me.webBrowser = New System.Windows.Forms.WebBrowser()
        Me.panTop = New System.Windows.Forms.Panel()
        Me.lblPrint = New System.Windows.Forms.Label()
        Me.panWebBrowser = New System.Windows.Forms.Panel()
        Me.panTop.SuspendLayout()
        Me.panWebBrowser.SuspendLayout()
        Me.SuspendLayout()
        '
        'webBrowser
        '
        Me.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrowser.Name = "webBrowser"
        Me.webBrowser.Size = New System.Drawing.Size(1122, 405)
        Me.webBrowser.TabIndex = 0
        '
        'panTop
        '
        Me.panTop.Controls.Add(Me.lblPrint)
        Me.panTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panTop.Location = New System.Drawing.Point(0, 0)
        Me.panTop.Name = "panTop"
        Me.panTop.Size = New System.Drawing.Size(1122, 30)
        Me.panTop.TabIndex = 1
        Me.panTop.Visible = False
        '
        'lblPrint
        '
        Me.lblPrint.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPrint.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblPrint.Location = New System.Drawing.Point(1050, 0)
        Me.lblPrint.Name = "lblPrint"
        Me.lblPrint.Size = New System.Drawing.Size(72, 30)
        Me.lblPrint.TabIndex = 0
        Me.lblPrint.Text = "Print"
        Me.lblPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panWebBrowser
        '
        Me.panWebBrowser.Controls.Add(Me.webBrowser)
        Me.panWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panWebBrowser.Location = New System.Drawing.Point(0, 30)
        Me.panWebBrowser.Name = "panWebBrowser"
        Me.panWebBrowser.Size = New System.Drawing.Size(1122, 405)
        Me.panWebBrowser.TabIndex = 2
        '
        'frmWebBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 435)
        Me.Controls.Add(Me.panWebBrowser)
        Me.Controls.Add(Me.panTop)
        Me.Name = "frmWebBrowser"
        Me.Text = "frmWebBrowser"
        Me.panTop.ResumeLayout(False)
        Me.panWebBrowser.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents webBrowser As WebBrowser
    Friend WithEvents panTop As Panel
    Friend WithEvents lblPrint As Label
    Friend WithEvents panWebBrowser As Panel
End Class
