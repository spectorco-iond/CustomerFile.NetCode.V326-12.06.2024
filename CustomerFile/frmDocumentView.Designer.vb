<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentView
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
        Me.ssStatusBar = New System.Windows.Forms.StatusStrip()
        Me.tsslCreate_By = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCreate_TS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUser_Login = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUpdate_TS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCus_Document_ID = New System.Windows.Forms.Label()
        Me.lblDoc_Type_ID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCus_Contact_ID = New System.Windows.Forms.Label()
        Me.lblDocument_Ext = New System.Windows.Forms.Label()
        Me.lblDocument_Path = New System.Windows.Forms.Label()
        Me.lblDocument_Desc = New System.Windows.Forms.Label()
        Me.lblMain_Cus_Doc_ID = New System.Windows.Forms.Label()
        Me.txtDocument_Ext = New CustomerFile.xTextBox()
        Me.txtDocument_Path = New CustomerFile.xTextBox()
        Me.txtDocument_Desc = New CustomerFile.xTextBox()
        Me.txtCus_Contact_ID = New CustomerFile.xTextBox()
        Me.txtMain_Cus_Doc_ID = New CustomerFile.xTextBox()
        Me.txtCus_No = New CustomerFile.xTextBox()
        Me.txtDoc_Type_ID = New CustomerFile.xTextBox()
        Me.txtCus_Document_ID = New CustomerFile.xTextBox()
        Me.pnlPreviewDoc = New System.Windows.Forms.Panel()
        Me.wbShowFile = New System.Windows.Forms.WebBrowser()
        Me.ssStatusBar.SuspendLayout
        Me.pnlPreviewDoc.SuspendLayout
        Me.SuspendLayout
        '
        'ssStatusBar
        '
        Me.ssStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslCreate_By, Me.tsslCreate_TS, Me.tsslUser_Login, Me.tsslUpdate_TS})
        Me.ssStatusBar.Location = New System.Drawing.Point(0, 544)
        Me.ssStatusBar.Name = "ssStatusBar"
        Me.ssStatusBar.Size = New System.Drawing.Size(792, 22)
        Me.ssStatusBar.TabIndex = 40
        Me.ssStatusBar.Text = "StatusStrip1"
        '
        'tsslCreate_By
        '
        Me.tsslCreate_By.Name = "tsslCreate_By"
        Me.tsslCreate_By.Size = New System.Drawing.Size(16, 17)
        Me.tsslCreate_By.Text = "   "
        '
        'tsslCreate_TS
        '
        Me.tsslCreate_TS.Name = "tsslCreate_TS"
        Me.tsslCreate_TS.Size = New System.Drawing.Size(16, 17)
        Me.tsslCreate_TS.Text = "   "
        '
        'tsslUser_Login
        '
        Me.tsslUser_Login.Name = "tsslUser_Login"
        Me.tsslUser_Login.Size = New System.Drawing.Size(16, 17)
        Me.tsslUser_Login.Text = "   "
        '
        'tsslUpdate_TS
        '
        Me.tsslUpdate_TS.Name = "tsslUpdate_TS"
        Me.tsslUpdate_TS.Size = New System.Drawing.Size(16, 17)
        Me.tsslUpdate_TS.Text = "   "
        '
        'lblCus_Document_ID
        '
        Me.lblCus_Document_ID.AutoSize = true
        Me.lblCus_Document_ID.Location = New System.Drawing.Point(11, 15)
        Me.lblCus_Document_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCus_Document_ID.Name = "lblCus_Document_ID"
        Me.lblCus_Document_ID.Size = New System.Drawing.Size(62, 13)
        Me.lblCus_Document_ID.TabIndex = 41
        Me.lblCus_Document_ID.Text = "Cus Doc ID"
        '
        'lblDoc_Type_ID
        '
        Me.lblDoc_Type_ID.AutoSize = true
        Me.lblDoc_Type_ID.Location = New System.Drawing.Point(185, 15)
        Me.lblDoc_Type_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDoc_Type_ID.Name = "lblDoc_Type_ID"
        Me.lblDoc_Type_ID.Size = New System.Drawing.Size(74, 13)
        Me.lblDoc_Type_ID.TabIndex = 43
        Me.lblDoc_Type_ID.Text = "Doc_Type_ID"
        Me.lblDoc_Type_ID.Visible = false
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(498, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Cus No"
        Me.Label3.Visible = false
        '
        'lblCus_Contact_ID
        '
        Me.lblCus_Contact_ID.AutoSize = true
        Me.lblCus_Contact_ID.Location = New System.Drawing.Point(455, 37)
        Me.lblCus_Contact_ID.Name = "lblCus_Contact_ID"
        Me.lblCus_Contact_ID.Size = New System.Drawing.Size(85, 13)
        Me.lblCus_Contact_ID.TabIndex = 47
        Me.lblCus_Contact_ID.Text = "Cus_Contact_ID"
        Me.lblCus_Contact_ID.Visible = false
        '
        'lblDocument_Ext
        '
        Me.lblDocument_Ext.AutoSize = true
        Me.lblDocument_Ext.Location = New System.Drawing.Point(11, 81)
        Me.lblDocument_Ext.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDocument_Ext.Name = "lblDocument_Ext"
        Me.lblDocument_Ext.Size = New System.Drawing.Size(77, 13)
        Me.lblDocument_Ext.TabIndex = 55
        Me.lblDocument_Ext.Text = "Document_Ext"
        '
        'lblDocument_Path
        '
        Me.lblDocument_Path.AutoSize = true
        Me.lblDocument_Path.Location = New System.Drawing.Point(11, 59)
        Me.lblDocument_Path.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDocument_Path.Name = "lblDocument_Path"
        Me.lblDocument_Path.Size = New System.Drawing.Size(52, 13)
        Me.lblDocument_Path.TabIndex = 53
        Me.lblDocument_Path.Text = "Doc Path"
        '
        'lblDocument_Desc
        '
        Me.lblDocument_Desc.AutoSize = true
        Me.lblDocument_Desc.Location = New System.Drawing.Point(11, 37)
        Me.lblDocument_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDocument_Desc.Name = "lblDocument_Desc"
        Me.lblDocument_Desc.Size = New System.Drawing.Size(87, 13)
        Me.lblDocument_Desc.TabIndex = 51
        Me.lblDocument_Desc.Text = "Document_Desc"
        '
        'lblMain_Cus_Doc_ID
        '
        Me.lblMain_Cus_Doc_ID.AutoSize = true
        Me.lblMain_Cus_Doc_ID.Location = New System.Drawing.Point(329, 17)
        Me.lblMain_Cus_Doc_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblMain_Cus_Doc_ID.Name = "lblMain_Cus_Doc_ID"
        Me.lblMain_Cus_Doc_ID.Size = New System.Drawing.Size(97, 13)
        Me.lblMain_Cus_Doc_ID.TabIndex = 49
        Me.lblMain_Cus_Doc_ID.Text = "Main_Cus_Doc_ID"
        Me.lblMain_Cus_Doc_ID.Visible = false
        '
        'txtDocument_Ext
        '
        Me.txtDocument_Ext.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtDocument_Ext.DataLength = CType(0,Long)
        Me.txtDocument_Ext.DataType = CustomerFile.CDataType.dtString
        Me.txtDocument_Ext.DateValue = New Date(CType(0,Long))
        Me.txtDocument_Ext.DecimalDigits = CType(0,Long)
        Me.txtDocument_Ext.Location = New System.Drawing.Point(117, 78)
        Me.txtDocument_Ext.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDocument_Ext.Mask = Nothing
        Me.txtDocument_Ext.Name = "txtDocument_Ext"
        Me.txtDocument_Ext.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDocument_Ext.OldValue = ""
        Me.txtDocument_Ext.Size = New System.Drawing.Size(326, 20)
        Me.txtDocument_Ext.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtDocument_Ext.StringValue = Nothing
        Me.txtDocument_Ext.TabIndex = 56
        Me.txtDocument_Ext.TextDataID = Nothing
        '
        'txtDocument_Path
        '
        Me.txtDocument_Path.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtDocument_Path.DataLength = CType(0,Long)
        Me.txtDocument_Path.DataType = CustomerFile.CDataType.dtString
        Me.txtDocument_Path.DateValue = New Date(CType(0,Long))
        Me.txtDocument_Path.DecimalDigits = CType(0,Long)
        Me.txtDocument_Path.Location = New System.Drawing.Point(117, 56)
        Me.txtDocument_Path.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDocument_Path.Mask = Nothing
        Me.txtDocument_Path.Name = "txtDocument_Path"
        Me.txtDocument_Path.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDocument_Path.OldValue = ""
        Me.txtDocument_Path.Size = New System.Drawing.Size(326, 20)
        Me.txtDocument_Path.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtDocument_Path.StringValue = Nothing
        Me.txtDocument_Path.TabIndex = 54
        Me.txtDocument_Path.TextDataID = Nothing
        '
        'txtDocument_Desc
        '
        Me.txtDocument_Desc.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtDocument_Desc.DataLength = CType(0,Long)
        Me.txtDocument_Desc.DataType = CustomerFile.CDataType.dtString
        Me.txtDocument_Desc.DateValue = New Date(CType(0,Long))
        Me.txtDocument_Desc.DecimalDigits = CType(0,Long)
        Me.txtDocument_Desc.Location = New System.Drawing.Point(117, 34)
        Me.txtDocument_Desc.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDocument_Desc.Mask = Nothing
        Me.txtDocument_Desc.Name = "txtDocument_Desc"
        Me.txtDocument_Desc.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDocument_Desc.OldValue = ""
        Me.txtDocument_Desc.Size = New System.Drawing.Size(326, 20)
        Me.txtDocument_Desc.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtDocument_Desc.StringValue = Nothing
        Me.txtDocument_Desc.TabIndex = 52
        Me.txtDocument_Desc.TextDataID = Nothing
        '
        'txtCus_Contact_ID
        '
        Me.txtCus_Contact_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Contact_ID.DataLength = CType(0,Long)
        Me.txtCus_Contact_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Contact_ID.DateValue = New Date(CType(0,Long))
        Me.txtCus_Contact_ID.DecimalDigits = CType(0,Long)
        Me.txtCus_Contact_ID.Location = New System.Drawing.Point(546, 34)
        Me.txtCus_Contact_ID.Mask = Nothing
        Me.txtCus_Contact_ID.Name = "txtCus_Contact_ID"
        Me.txtCus_Contact_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Contact_ID.OldValue = ""
        Me.txtCus_Contact_ID.Size = New System.Drawing.Size(66, 20)
        Me.txtCus_Contact_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Contact_ID.StringValue = Nothing
        Me.txtCus_Contact_ID.TabIndex = 50
        Me.txtCus_Contact_ID.TextDataID = Nothing
        Me.txtCus_Contact_ID.Visible = false
        '
        'txtMain_Cus_Doc_ID
        '
        Me.txtMain_Cus_Doc_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtMain_Cus_Doc_ID.DataLength = CType(0,Long)
        Me.txtMain_Cus_Doc_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtMain_Cus_Doc_ID.DateValue = New Date(CType(0,Long))
        Me.txtMain_Cus_Doc_ID.DecimalDigits = CType(0,Long)
        Me.txtMain_Cus_Doc_ID.Location = New System.Drawing.Point(428, 12)
        Me.txtMain_Cus_Doc_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtMain_Cus_Doc_ID.Mask = Nothing
        Me.txtMain_Cus_Doc_ID.Name = "txtMain_Cus_Doc_ID"
        Me.txtMain_Cus_Doc_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMain_Cus_Doc_ID.OldValue = ""
        Me.txtMain_Cus_Doc_ID.Size = New System.Drawing.Size(66, 20)
        Me.txtMain_Cus_Doc_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtMain_Cus_Doc_ID.StringValue = Nothing
        Me.txtMain_Cus_Doc_ID.TabIndex = 48
        Me.txtMain_Cus_Doc_ID.TextDataID = Nothing
        Me.txtMain_Cus_Doc_ID.Visible = false
        '
        'txtCus_No
        '
        Me.txtCus_No.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_No.DataLength = CType(0,Long)
        Me.txtCus_No.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_No.DateValue = New Date(CType(0,Long))
        Me.txtCus_No.DecimalDigits = CType(0,Long)
        Me.txtCus_No.Location = New System.Drawing.Point(546, 12)
        Me.txtCus_No.Mask = Nothing
        Me.txtCus_No.Name = "txtCus_No"
        Me.txtCus_No.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_No.OldValue = ""
        Me.txtCus_No.Size = New System.Drawing.Size(66, 20)
        Me.txtCus_No.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_No.StringValue = Nothing
        Me.txtCus_No.TabIndex = 46
        Me.txtCus_No.TextDataID = Nothing
        Me.txtCus_No.Visible = false
        '
        'txtDoc_Type_ID
        '
        Me.txtDoc_Type_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtDoc_Type_ID.DataLength = CType(0,Long)
        Me.txtDoc_Type_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtDoc_Type_ID.DateValue = New Date(CType(0,Long))
        Me.txtDoc_Type_ID.DecimalDigits = CType(0,Long)
        Me.txtDoc_Type_ID.Location = New System.Drawing.Point(261, 12)
        Me.txtDoc_Type_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDoc_Type_ID.Mask = Nothing
        Me.txtDoc_Type_ID.Name = "txtDoc_Type_ID"
        Me.txtDoc_Type_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDoc_Type_ID.OldValue = ""
        Me.txtDoc_Type_ID.Size = New System.Drawing.Size(66, 20)
        Me.txtDoc_Type_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtDoc_Type_ID.StringValue = Nothing
        Me.txtDoc_Type_ID.TabIndex = 44
        Me.txtDoc_Type_ID.TextDataID = Nothing
        Me.txtDoc_Type_ID.Visible = false
        '
        'txtCus_Document_ID
        '
        Me.txtCus_Document_ID.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtCus_Document_ID.DataLength = CType(0,Long)
        Me.txtCus_Document_ID.DataType = CustomerFile.CDataType.dtString
        Me.txtCus_Document_ID.DateValue = New Date(CType(0,Long))
        Me.txtCus_Document_ID.DecimalDigits = CType(0,Long)
        Me.txtCus_Document_ID.Location = New System.Drawing.Point(117, 12)
        Me.txtCus_Document_ID.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCus_Document_ID.Mask = Nothing
        Me.txtCus_Document_ID.Name = "txtCus_Document_ID"
        Me.txtCus_Document_ID.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCus_Document_ID.OldValue = ""
        Me.txtCus_Document_ID.Size = New System.Drawing.Size(66, 20)
        Me.txtCus_Document_ID.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtCus_Document_ID.StringValue = Nothing
        Me.txtCus_Document_ID.TabIndex = 42
        Me.txtCus_Document_ID.TextDataID = Nothing
        '
        'pnlPreviewDoc
        '
        Me.pnlPreviewDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pnlPreviewDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPreviewDoc.Controls.Add(Me.wbShowFile)
        Me.pnlPreviewDoc.Location = New System.Drawing.Point(12, 102)
        Me.pnlPreviewDoc.Name = "pnlPreviewDoc"
        Me.pnlPreviewDoc.Size = New System.Drawing.Size(768, 439)
        Me.pnlPreviewDoc.TabIndex = 160
        Me.pnlPreviewDoc.Visible = false
        '
        'wbShowFile
        '
        Me.wbShowFile.AllowWebBrowserDrop = false
        Me.wbShowFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbShowFile.Location = New System.Drawing.Point(0, 0)
        Me.wbShowFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.wbShowFile.MinimumSize = New System.Drawing.Size(23, 25)
        Me.wbShowFile.Name = "wbShowFile"
        Me.wbShowFile.Size = New System.Drawing.Size(764, 435)
        Me.wbShowFile.TabIndex = 150
        '
        'frmDocumentView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.pnlPreviewDoc)
        Me.Controls.Add(Me.txtDocument_Ext)
        Me.Controls.Add(Me.lblDocument_Ext)
        Me.Controls.Add(Me.txtDocument_Path)
        Me.Controls.Add(Me.lblDocument_Path)
        Me.Controls.Add(Me.txtDocument_Desc)
        Me.Controls.Add(Me.lblDocument_Desc)
        Me.Controls.Add(Me.txtCus_Contact_ID)
        Me.Controls.Add(Me.lblMain_Cus_Doc_ID)
        Me.Controls.Add(Me.txtMain_Cus_Doc_ID)
        Me.Controls.Add(Me.lblCus_Contact_ID)
        Me.Controls.Add(Me.txtCus_No)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDoc_Type_ID)
        Me.Controls.Add(Me.lblDoc_Type_ID)
        Me.Controls.Add(Me.txtCus_Document_ID)
        Me.Controls.Add(Me.lblCus_Document_ID)
        Me.Controls.Add(Me.ssStatusBar)
        Me.MinimumSize = New System.Drawing.Size(500, 500)
        Me.Name = "frmDocumentView"
        Me.Tag = "CF-DOC-VIE-001"
        Me.Text = "Document"
        Me.ssStatusBar.ResumeLayout(false)
        Me.ssStatusBar.PerformLayout
        Me.pnlPreviewDoc.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ssStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslCreate_By As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCreate_TS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUser_Login As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUpdate_TS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCus_Document_ID As System.Windows.Forms.Label
    Friend WithEvents txtCus_Document_ID As CustomerFile.xTextBox
    Friend WithEvents txtDoc_Type_ID As CustomerFile.xTextBox
    Friend WithEvents lblDoc_Type_ID As System.Windows.Forms.Label
    Friend WithEvents txtCus_No As CustomerFile.xTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMain_Cus_Doc_ID As CustomerFile.xTextBox
    Friend WithEvents lblCus_Contact_ID As System.Windows.Forms.Label
    Friend WithEvents txtDocument_Ext As CustomerFile.xTextBox
    Friend WithEvents lblDocument_Ext As System.Windows.Forms.Label
    Friend WithEvents txtDocument_Path As CustomerFile.xTextBox
    Friend WithEvents lblDocument_Path As System.Windows.Forms.Label
    Friend WithEvents txtDocument_Desc As CustomerFile.xTextBox
    Friend WithEvents lblDocument_Desc As System.Windows.Forms.Label
    Friend WithEvents txtCus_Contact_ID As CustomerFile.xTextBox
    Friend WithEvents lblMain_Cus_Doc_ID As System.Windows.Forms.Label
    Friend WithEvents pnlPreviewDoc As System.Windows.Forms.Panel
    Friend WithEvents wbShowFile As System.Windows.Forms.WebBrowser
End Class
