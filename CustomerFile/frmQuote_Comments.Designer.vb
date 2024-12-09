<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuote_Comments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuote_Comments))
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.clbGeneral = New System.Windows.Forms.CheckedListBox()
        Me.dgvGeneral = New System.Windows.Forms.DataGridView()
        Me.gbProduction = New System.Windows.Forms.GroupBox()
        Me.clbProduction = New System.Windows.Forms.CheckedListBox()
        Me.dgvProduction = New System.Windows.Forms.DataGridView()
        Me.gbShipping = New System.Windows.Forms.GroupBox()
        Me.clbShipping = New System.Windows.Forms.CheckedListBox()
        Me.dgvShipping = New System.Windows.Forms.DataGridView()
        Me.gbComments = New System.Windows.Forms.GroupBox()
        Me.panItems = New System.Windows.Forms.Panel()
        Me.dgvComments = New System.Windows.Forms.DataGridView()
        Me.tsItemMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.gbGeneral.SuspendLayout()
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProduction.SuspendLayout()
        CType(Me.dgvProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbShipping.SuspendLayout()
        CType(Me.dgvShipping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbComments.SuspendLayout()
        Me.panItems.SuspendLayout()
        CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsItemMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.clbGeneral)
        Me.gbGeneral.Controls.Add(Me.dgvGeneral)
        Me.gbGeneral.Location = New System.Drawing.Point(10, 12)
        Me.gbGeneral.Margin = New System.Windows.Forms.Padding(1)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(310, 282)
        Me.gbGeneral.TabIndex = 0
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "General and Pricing"
        '
        'clbGeneral
        '
        Me.clbGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbGeneral.FormattingEnabled = True
        Me.clbGeneral.Items.AddRange(New Object() {"See Above", "Factory Direct - Overseas Pricing", "Domestic Pricing", "FOB Montreal", "FOB New York", "Additional fees for delivery", "Spector reserves the right to charge additional freight", "Freight to one location included", "shipping to one location with a Dock included to the Contiguous United states", "US Funds - Net", "Canadian Funds - Net", "Split shipments"})
        Me.clbGeneral.Location = New System.Drawing.Point(6, 19)
        Me.clbGeneral.Name = "clbGeneral"
        Me.clbGeneral.Size = New System.Drawing.Size(143, 100)
        Me.clbGeneral.TabIndex = 0
        Me.clbGeneral.Visible = False
        '
        'dgvGeneral
        '
        Me.dgvGeneral.AllowUserToAddRows = False
        Me.dgvGeneral.AllowUserToDeleteRows = False
        Me.dgvGeneral.AllowUserToResizeColumns = False
        Me.dgvGeneral.AllowUserToResizeRows = False
        Me.dgvGeneral.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGeneral.ColumnHeadersVisible = False
        Me.dgvGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGeneral.Location = New System.Drawing.Point(3, 17)
        Me.dgvGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvGeneral.Name = "dgvGeneral"
        Me.dgvGeneral.RowHeadersVisible = False
        Me.dgvGeneral.Size = New System.Drawing.Size(304, 262)
        Me.dgvGeneral.TabIndex = 1
        '
        'gbProduction
        '
        Me.gbProduction.Controls.Add(Me.clbProduction)
        Me.gbProduction.Controls.Add(Me.dgvProduction)
        Me.gbProduction.Location = New System.Drawing.Point(322, 12)
        Me.gbProduction.Margin = New System.Windows.Forms.Padding(1)
        Me.gbProduction.Name = "gbProduction"
        Me.gbProduction.Size = New System.Drawing.Size(310, 282)
        Me.gbProduction.TabIndex = 1
        Me.gbProduction.TabStop = False
        Me.gbProduction.Text = "Production"
        '
        'clbProduction
        '
        Me.clbProduction.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbProduction.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbProduction.FormattingEnabled = True
        Me.clbProduction.Items.AddRange(New Object() {"1 color / 1 location", "1 location laser engraving included", "1 location debossed included", "1 location silk screen included", "1 digital imprint included", "4 color imprint added as a charge", "Bulk Packaging", "Standard Packaging", "Packaged individually in cello", "Packaged indiv. In 1-color printed cello", "50 pens per bulk bag", "100 pens per bulk bag", "No China marking", "Chinese refills", "Chinese refills with German ink         ", "Black refills", "Blue refills"})
        Me.clbProduction.Location = New System.Drawing.Point(6, 19)
        Me.clbProduction.Name = "clbProduction"
        Me.clbProduction.Size = New System.Drawing.Size(116, 100)
        Me.clbProduction.TabIndex = 0
        Me.clbProduction.Visible = False
        '
        'dgvProduction
        '
        Me.dgvProduction.AllowUserToAddRows = False
        Me.dgvProduction.AllowUserToDeleteRows = False
        Me.dgvProduction.AllowUserToResizeColumns = False
        Me.dgvProduction.AllowUserToResizeRows = False
        Me.dgvProduction.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvProduction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduction.ColumnHeadersVisible = False
        Me.dgvProduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProduction.Location = New System.Drawing.Point(3, 17)
        Me.dgvProduction.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProduction.Name = "dgvProduction"
        Me.dgvProduction.RowHeadersVisible = False
        Me.dgvProduction.Size = New System.Drawing.Size(304, 262)
        Me.dgvProduction.TabIndex = 1
        '
        'gbShipping
        '
        Me.gbShipping.Controls.Add(Me.clbShipping)
        Me.gbShipping.Controls.Add(Me.dgvShipping)
        Me.gbShipping.Location = New System.Drawing.Point(10, 296)
        Me.gbShipping.Margin = New System.Windows.Forms.Padding(1)
        Me.gbShipping.Name = "gbShipping"
        Me.gbShipping.Size = New System.Drawing.Size(310, 252)
        Me.gbShipping.TabIndex = 1
        Me.gbShipping.TabStop = False
        Me.gbShipping.Text = "Shipping / samples / approvals"
        '
        'clbShipping
        '
        Me.clbShipping.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbShipping.FormattingEnabled = True
        Me.clbShipping.Items.AddRange(New Object() {"7-10 days for a pre-pro sample", "10-12 days for a pre-pro sample", "9-11 weeks lead time after approval", "11-13 weeks lead time after the pre-pro", "10-12 weeks lead time after the pre-pro", "12-14 weeks lead time after the pre-pro", "13-15 weeks lead time after the pre-pro", "14-16 weeks lead time after the pre-pro", "*** Please add 4 weeks due to CNY", "Will ship in 5-7 days after proof approval", "Will ship in 7-10 days after sample approved", "Will ship in 5-7 days after sample approved", "Will ship in 7-10 days after sample approved"})
        Me.clbShipping.Location = New System.Drawing.Point(6, 19)
        Me.clbShipping.Name = "clbShipping"
        Me.clbShipping.Size = New System.Drawing.Size(143, 84)
        Me.clbShipping.TabIndex = 0
        Me.clbShipping.Visible = False
        '
        'dgvShipping
        '
        Me.dgvShipping.AllowUserToAddRows = False
        Me.dgvShipping.AllowUserToDeleteRows = False
        Me.dgvShipping.AllowUserToResizeColumns = False
        Me.dgvShipping.AllowUserToResizeRows = False
        Me.dgvShipping.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvShipping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvShipping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipping.ColumnHeadersVisible = False
        Me.dgvShipping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShipping.Location = New System.Drawing.Point(3, 17)
        Me.dgvShipping.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvShipping.Name = "dgvShipping"
        Me.dgvShipping.RowHeadersVisible = False
        Me.dgvShipping.Size = New System.Drawing.Size(304, 232)
        Me.dgvShipping.TabIndex = 1
        '
        'gbComments
        '
        Me.gbComments.Controls.Add(Me.panItems)
        Me.gbComments.Controls.Add(Me.tsItemMenu)
        Me.gbComments.Location = New System.Drawing.Point(322, 296)
        Me.gbComments.Margin = New System.Windows.Forms.Padding(1)
        Me.gbComments.Name = "gbComments"
        Me.gbComments.Size = New System.Drawing.Size(310, 252)
        Me.gbComments.TabIndex = 3
        Me.gbComments.TabStop = False
        Me.gbComments.Text = "Other Comments"
        '
        'panItems
        '
        Me.panItems.Controls.Add(Me.dgvComments)
        Me.panItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panItems.Location = New System.Drawing.Point(3, 42)
        Me.panItems.Margin = New System.Windows.Forms.Padding(1)
        Me.panItems.Name = "panItems"
        Me.panItems.Size = New System.Drawing.Size(304, 207)
        Me.panItems.TabIndex = 37
        '
        'dgvComments
        '
        Me.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComments.ColumnHeadersVisible = False
        Me.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComments.Location = New System.Drawing.Point(0, 0)
        Me.dgvComments.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvComments.Name = "dgvComments"
        Me.dgvComments.RowHeadersVisible = False
        Me.dgvComments.Size = New System.Drawing.Size(304, 207)
        Me.dgvComments.TabIndex = 0
        '
        'tsItemMenu
        '
        Me.tsItemMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbDelete, Me.tsbRefresh})
        Me.tsItemMenu.Location = New System.Drawing.Point(3, 17)
        Me.tsItemMenu.Name = "tsItemMenu"
        Me.tsItemMenu.Size = New System.Drawing.Size(304, 25)
        Me.tsItemMenu.TabIndex = 1
        Me.tsItemMenu.Text = "ToolStrip2"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(35, 22)
        Me.tsbNew.Text = "New"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(40, 22)
        Me.tsbOpen.Text = "Open"
        Me.tsbOpen.Visible = False
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(44, 22)
        Me.tsbDelete.Text = "Delete"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(50, 22)
        Me.tsbRefresh.Text = "Refresh"
        '
        'frmQuote_Comments
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(634, 561)
        Me.Controls.Add(Me.gbComments)
        Me.Controls.Add(Me.gbShipping)
        Me.Controls.Add(Me.gbProduction)
        Me.Controls.Add(Me.gbGeneral)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(650, 600)
        Me.MinimumSize = New System.Drawing.Size(650, 600)
        Me.Name = "frmQuote_Comments"
        Me.Tag = "CF-QUO-CMT-001"
        Me.Text = "Quote Comments"
        Me.gbGeneral.ResumeLayout(False)
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProduction.ResumeLayout(False)
        CType(Me.dgvProduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbShipping.ResumeLayout(False)
        CType(Me.dgvShipping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbComments.ResumeLayout(False)
        Me.gbComments.PerformLayout()
        Me.panItems.ResumeLayout(False)
        CType(Me.dgvComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsItemMenu.ResumeLayout(False)
        Me.tsItemMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents clbGeneral As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbProduction As System.Windows.Forms.GroupBox
    Friend WithEvents clbProduction As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbShipping As System.Windows.Forms.GroupBox
    Friend WithEvents clbShipping As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbComments As System.Windows.Forms.GroupBox
    Friend WithEvents panItems As System.Windows.Forms.Panel
    Friend WithEvents dgvComments As System.Windows.Forms.DataGridView
    Friend WithEvents tsItemMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents dgvProduction As System.Windows.Forms.DataGridView
    Friend WithEvents dgvShipping As System.Windows.Forms.DataGridView
End Class
