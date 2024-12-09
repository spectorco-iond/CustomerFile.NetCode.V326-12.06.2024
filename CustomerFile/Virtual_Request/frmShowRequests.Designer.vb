<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShowRequests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowRequests))
        Me.panTop = New System.Windows.Forms.Panel()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.chkSearchActivate = New System.Windows.Forms.CheckBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblItemCd = New System.Windows.Forms.Label()
        Me.lblImprint = New System.Windows.Forms.Label()
        Me.lblRequestCode = New System.Windows.Forms.Label()
        Me.lblCreator = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.panIntoTop = New System.Windows.Forms.Panel()
        Me.txtbtnNew = New System.Windows.Forms.TextBox()
        Me.txtbtnClose = New System.Windows.Forms.TextBox()
        Me.panViewMain = New System.Windows.Forms.Panel()
        Me.panMainMiddle = New System.Windows.Forms.Panel()
        Me.lstViewShowReq = New System.Windows.Forms.ListView()
        Me.panMainTop = New System.Windows.Forms.Panel()
        Me.lblClosePanView = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblRows = New System.Windows.Forms.Label()
        Me.panMiddle = New System.Windows.Forms.Panel()
        Me.panShowRequest = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.xChkRush = New CustomerFile.xCheckBox()
        Me.xTxtItemCd = New CustomerFile.xTextBox()
        Me.xTxtImprint = New CustomerFile.xTextBox()
        Me.xTxtRequestCode = New CustomerFile.xTextBox()
        Me.xTxtAccount = New CustomerFile.xTextBox()
        Me.xTxtCreator = New CustomerFile.xTextBox()
        Me.xTxtStatus = New CustomerFile.xTextBox()
        Me.panTop.SuspendLayout()
        Me.panIntoTop.SuspendLayout()
        Me.panViewMain.SuspendLayout()
        Me.panMainMiddle.SuspendLayout()
        Me.panMainTop.SuspendLayout()
        Me.panMiddle.SuspendLayout()
        Me.panShowRequest.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panTop
        '
        Me.panTop.Controls.Add(Me.prgBar)
        Me.panTop.Controls.Add(Me.chkSearchActivate)
        Me.panTop.Controls.Add(Me.btnSearch)
        Me.panTop.Controls.Add(Me.xChkRush)
        Me.panTop.Controls.Add(Me.lblItemCd)
        Me.panTop.Controls.Add(Me.xTxtItemCd)
        Me.panTop.Controls.Add(Me.lblImprint)
        Me.panTop.Controls.Add(Me.xTxtImprint)
        Me.panTop.Controls.Add(Me.lblRequestCode)
        Me.panTop.Controls.Add(Me.xTxtRequestCode)
        Me.panTop.Controls.Add(Me.lblCreator)
        Me.panTop.Controls.Add(Me.lblAccount)
        Me.panTop.Controls.Add(Me.lblStatus)
        Me.panTop.Controls.Add(Me.xTxtAccount)
        Me.panTop.Controls.Add(Me.xTxtCreator)
        Me.panTop.Controls.Add(Me.xTxtStatus)
        Me.panTop.Controls.Add(Me.panIntoTop)
        Me.panTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panTop.Location = New System.Drawing.Point(0, 0)
        Me.panTop.Name = "panTop"
        Me.panTop.Size = New System.Drawing.Size(1175, 130)
        Me.panTop.TabIndex = 0
        '
        'prgBar
        '
        Me.prgBar.ForeColor = System.Drawing.Color.DarkBlue
        Me.prgBar.Location = New System.Drawing.Point(745, 98)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(114, 24)
        Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBar.TabIndex = 38
        '
        'chkSearchActivate
        '
        Me.chkSearchActivate.AutoSize = True
        Me.chkSearchActivate.Location = New System.Drawing.Point(741, 39)
        Me.chkSearchActivate.Name = "chkSearchActivate"
        Me.chkSearchActivate.Size = New System.Drawing.Size(132, 17)
        Me.chkSearchActivate.TabIndex = 37
        Me.chkSearchActivate.Text = "Disable Search Button"
        Me.chkSearchActivate.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Navy
        Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(744, 69)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(115, 27)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'lblItemCd
        '
        Me.lblItemCd.AutoSize = True
        Me.lblItemCd.Location = New System.Drawing.Point(346, 76)
        Me.lblItemCd.Name = "lblItemCd"
        Me.lblItemCd.Size = New System.Drawing.Size(43, 13)
        Me.lblItemCd.TabIndex = 34
        Me.lblItemCd.Text = "Item Cd"
        '
        'lblImprint
        '
        Me.lblImprint.AutoSize = True
        Me.lblImprint.Location = New System.Drawing.Point(509, 76)
        Me.lblImprint.Name = "lblImprint"
        Me.lblImprint.Size = New System.Drawing.Size(38, 13)
        Me.lblImprint.TabIndex = 32
        Me.lblImprint.Text = "Imprint"
        '
        'lblRequestCode
        '
        Me.lblRequestCode.AutoSize = True
        Me.lblRequestCode.Location = New System.Drawing.Point(12, 37)
        Me.lblRequestCode.Name = "lblRequestCode"
        Me.lblRequestCode.Size = New System.Drawing.Size(75, 13)
        Me.lblRequestCode.TabIndex = 30
        Me.lblRequestCode.Text = "Request Code"
        '
        'lblCreator
        '
        Me.lblCreator.AutoSize = True
        Me.lblCreator.Location = New System.Drawing.Point(15, 77)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(41, 13)
        Me.lblCreator.TabIndex = 28
        Me.lblCreator.Text = "Creator"
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(179, 77)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(47, 13)
        Me.lblAccount.TabIndex = 27
        Me.lblAccount.Text = "Account"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(179, 37)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 26
        Me.lblStatus.Text = "Status"
        '
        'panIntoTop
        '
        Me.panIntoTop.Controls.Add(Me.txtbtnNew)
        Me.panIntoTop.Controls.Add(Me.txtbtnClose)
        Me.panIntoTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panIntoTop.Location = New System.Drawing.Point(0, 0)
        Me.panIntoTop.Name = "panIntoTop"
        Me.panIntoTop.Size = New System.Drawing.Size(1175, 33)
        Me.panIntoTop.TabIndex = 22
        '
        'txtbtnNew
        '
        Me.txtbtnNew.BackColor = System.Drawing.Color.White
        Me.txtbtnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtbtnNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbtnNew.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtbtnNew.Location = New System.Drawing.Point(64, 6)
        Me.txtbtnNew.Name = "txtbtnNew"
        Me.txtbtnNew.ReadOnly = True
        Me.txtbtnNew.Size = New System.Drawing.Size(66, 22)
        Me.txtbtnNew.TabIndex = 21
        Me.txtbtnNew.Text = "New"
        Me.txtbtnNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbtnClose
        '
        Me.txtbtnClose.BackColor = System.Drawing.Color.White
        Me.txtbtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtbtnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbtnClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtbtnClose.Location = New System.Drawing.Point(7, 6)
        Me.txtbtnClose.Name = "txtbtnClose"
        Me.txtbtnClose.ReadOnly = True
        Me.txtbtnClose.Size = New System.Drawing.Size(56, 22)
        Me.txtbtnClose.TabIndex = 17
        Me.txtbtnClose.Text = "Close"
        Me.txtbtnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'panViewMain
        '
        Me.panViewMain.Controls.Add(Me.panMainMiddle)
        Me.panViewMain.Controls.Add(Me.panMainTop)
        Me.panViewMain.Location = New System.Drawing.Point(398, 46)
        Me.panViewMain.Name = "panViewMain"
        Me.panViewMain.Size = New System.Drawing.Size(268, 180)
        Me.panViewMain.TabIndex = 29
        Me.panViewMain.Visible = False
        '
        'panMainMiddle
        '
        Me.panMainMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panMainMiddle.Controls.Add(Me.lstViewShowReq)
        Me.panMainMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMainMiddle.Location = New System.Drawing.Point(0, 23)
        Me.panMainMiddle.Name = "panMainMiddle"
        Me.panMainMiddle.Size = New System.Drawing.Size(268, 157)
        Me.panMainMiddle.TabIndex = 31
        '
        'lstViewShowReq
        '
        Me.lstViewShowReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstViewShowReq.Location = New System.Drawing.Point(0, 0)
        Me.lstViewShowReq.Name = "lstViewShowReq"
        Me.lstViewShowReq.Size = New System.Drawing.Size(266, 155)
        Me.lstViewShowReq.TabIndex = 0
        Me.lstViewShowReq.UseCompatibleStateImageBehavior = False
        '
        'panMainTop
        '
        Me.panMainTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMainTop.Controls.Add(Me.lblClosePanView)
        Me.panMainTop.Controls.Add(Me.lblSearch)
        Me.panMainTop.Controls.Add(Me.lblRows)
        Me.panMainTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panMainTop.Location = New System.Drawing.Point(0, 0)
        Me.panMainTop.Name = "panMainTop"
        Me.panMainTop.Size = New System.Drawing.Size(268, 23)
        Me.panMainTop.TabIndex = 30
        '
        'lblClosePanView
        '
        Me.lblClosePanView.AutoSize = True
        Me.lblClosePanView.BackColor = System.Drawing.Color.Maroon
        Me.lblClosePanView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClosePanView.ForeColor = System.Drawing.Color.White
        Me.lblClosePanView.Location = New System.Drawing.Point(243, 3)
        Me.lblClosePanView.Name = "lblClosePanView"
        Me.lblClosePanView.Size = New System.Drawing.Size(16, 15)
        Me.lblClosePanView.TabIndex = 29
        Me.lblClosePanView.Text = "X"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(106, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(47, 13)
        Me.lblSearch.TabIndex = 28
        Me.lblSearch.Text = "Search :"
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Location = New System.Drawing.Point(3, 5)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(40, 13)
        Me.lblRows.TabIndex = 27
        Me.lblRows.Text = "Rows :"
        '
        'panMiddle
        '
        Me.panMiddle.Controls.Add(Me.panShowRequest)
        Me.panMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panMiddle.Location = New System.Drawing.Point(0, 130)
        Me.panMiddle.Name = "panMiddle"
        Me.panMiddle.Size = New System.Drawing.Size(1175, 388)
        Me.panMiddle.TabIndex = 1
        '
        'panShowRequest
        '
        Me.panShowRequest.Controls.Add(Me.panViewMain)
        Me.panShowRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panShowRequest.Location = New System.Drawing.Point(0, 0)
        Me.panShowRequest.Name = "panShowRequest"
        Me.panShowRequest.Size = New System.Drawing.Size(1175, 388)
        Me.panShowRequest.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLblVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1175, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLblVersion
        '
        Me.tsLblVersion.Name = "tsLblVersion"
        Me.tsLblVersion.Size = New System.Drawing.Size(52, 17)
        Me.tsLblVersion.Text = "Version :"
        '
        'xChkRush
        '
        Me.xChkRush.AutoSize = True
        Me.xChkRush.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xChkRush.DataLength = CType(0, Long)
        Me.xChkRush.DataType = CustomerFile.CDataType.dtString
        Me.xChkRush.DateValue = New Date(CType(0, Long))
        Me.xChkRush.DecimalDigits = CType(0, Long)
        Me.xChkRush.isMultiLang = False
        Me.xChkRush.Location = New System.Drawing.Point(341, 53)
        Me.xChkRush.Mask = Nothing
        Me.xChkRush.Name = "xChkRush"
        Me.xChkRush.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xChkRush.OldValue = ""
        Me.xChkRush.Size = New System.Drawing.Size(57, 17)
        Me.xChkRush.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xChkRush.StringValue = "Rush_Ord_bool"
        Me.xChkRush.TabIndex = 35
        Me.xChkRush.TableFieldSource = Nothing
        Me.xChkRush.TableSource = Nothing
        Me.xChkRush.Text = "RUSH"
        Me.xChkRush.TextDataID = Nothing
        Me.xChkRush.UseVisualStyleBackColor = True
        '
        'xTxtItemCd
        '
        Me.xTxtItemCd.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtItemCd.DataLength = CType(0, Long)
        Me.xTxtItemCd.DataType = CustomerFile.CDataType.dtString
        Me.xTxtItemCd.DateValue = New Date(CType(0, Long))
        Me.xTxtItemCd.DecimalDigits = CType(0, Long)
        Me.xTxtItemCd.Location = New System.Drawing.Point(341, 93)
        Me.xTxtItemCd.Mask = Nothing
        Me.xTxtItemCd.Name = "xTxtItemCd"
        Me.xTxtItemCd.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtItemCd.OldValue = ""
        Me.xTxtItemCd.Size = New System.Drawing.Size(146, 20)
        Me.xTxtItemCd.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtItemCd.StringValue = "Items_CD"
        Me.xTxtItemCd.TabIndex = 33
        Me.xTxtItemCd.TextDataID = Nothing
        '
        'xTxtImprint
        '
        Me.xTxtImprint.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtImprint.DataLength = CType(0, Long)
        Me.xTxtImprint.DataType = CustomerFile.CDataType.dtString
        Me.xTxtImprint.DateValue = New Date(CType(0, Long))
        Me.xTxtImprint.DecimalDigits = CType(0, Long)
        Me.xTxtImprint.Location = New System.Drawing.Point(509, 92)
        Me.xTxtImprint.Mask = Nothing
        Me.xTxtImprint.Name = "xTxtImprint"
        Me.xTxtImprint.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtImprint.OldValue = ""
        Me.xTxtImprint.Size = New System.Drawing.Size(146, 20)
        Me.xTxtImprint.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtImprint.StringValue = "Imprint_Logos"
        Me.xTxtImprint.TabIndex = 31
        Me.xTxtImprint.TextDataID = Nothing
        '
        'xTxtRequestCode
        '
        Me.xTxtRequestCode.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtRequestCode.DataLength = CType(0, Long)
        Me.xTxtRequestCode.DataType = CustomerFile.CDataType.dtString
        Me.xTxtRequestCode.DateValue = New Date(CType(0, Long))
        Me.xTxtRequestCode.DecimalDigits = CType(0, Long)
        Me.xTxtRequestCode.Location = New System.Drawing.Point(12, 53)
        Me.xTxtRequestCode.Mask = Nothing
        Me.xTxtRequestCode.Name = "xTxtRequestCode"
        Me.xTxtRequestCode.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtRequestCode.OldValue = ""
        Me.xTxtRequestCode.Size = New System.Drawing.Size(146, 20)
        Me.xTxtRequestCode.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtRequestCode.StringValue = "RevItemCd"
        Me.xTxtRequestCode.TabIndex = 29
        Me.xTxtRequestCode.TextDataID = Nothing
        '
        'xTxtAccount
        '
        Me.xTxtAccount.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtAccount.DataLength = CType(0, Long)
        Me.xTxtAccount.DataType = CustomerFile.CDataType.dtString
        Me.xTxtAccount.DateValue = New Date(CType(0, Long))
        Me.xTxtAccount.DecimalDigits = CType(0, Long)
        Me.xTxtAccount.Location = New System.Drawing.Point(179, 92)
        Me.xTxtAccount.Mask = Nothing
        Me.xTxtAccount.Name = "xTxtAccount"
        Me.xTxtAccount.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtAccount.OldValue = ""
        Me.xTxtAccount.Size = New System.Drawing.Size(146, 20)
        Me.xTxtAccount.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtAccount.StringValue = "Account"
        Me.xTxtAccount.TabIndex = 25
        Me.xTxtAccount.TextDataID = Nothing
        '
        'xTxtCreator
        '
        Me.xTxtCreator.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtCreator.DataLength = CType(0, Long)
        Me.xTxtCreator.DataType = CustomerFile.CDataType.dtString
        Me.xTxtCreator.DateValue = New Date(CType(0, Long))
        Me.xTxtCreator.DecimalDigits = CType(0, Long)
        Me.xTxtCreator.Location = New System.Drawing.Point(12, 93)
        Me.xTxtCreator.Mask = Nothing
        Me.xTxtCreator.Name = "xTxtCreator"
        Me.xTxtCreator.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtCreator.OldValue = ""
        Me.xTxtCreator.Size = New System.Drawing.Size(146, 20)
        Me.xTxtCreator.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtCreator.StringValue = "Creator"
        Me.xTxtCreator.TabIndex = 24
        Me.xTxtCreator.TextDataID = Nothing
        '
        'xTxtStatus
        '
        Me.xTxtStatus.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.xTxtStatus.DataLength = CType(0, Long)
        Me.xTxtStatus.DataType = CustomerFile.CDataType.dtString
        Me.xTxtStatus.DateValue = New Date(CType(0, Long))
        Me.xTxtStatus.DecimalDigits = CType(0, Long)
        Me.xTxtStatus.Location = New System.Drawing.Point(179, 53)
        Me.xTxtStatus.Mask = Nothing
        Me.xTxtStatus.Name = "xTxtStatus"
        Me.xTxtStatus.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.xTxtStatus.OldValue = ""
        Me.xTxtStatus.Size = New System.Drawing.Size(146, 20)
        Me.xTxtStatus.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.xTxtStatus.StringValue = "Status"
        Me.xTxtStatus.TabIndex = 23
        Me.xTxtStatus.TextDataID = Nothing
        '
        'frmShowRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1175, 518)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.panMiddle)
        Me.Controls.Add(Me.panTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmShowRequests"
        Me.Text = "Show Requests"
        Me.panTop.ResumeLayout(False)
        Me.panTop.PerformLayout()
        Me.panIntoTop.ResumeLayout(False)
        Me.panIntoTop.PerformLayout()
        Me.panViewMain.ResumeLayout(False)
        Me.panMainMiddle.ResumeLayout(False)
        Me.panMainTop.ResumeLayout(False)
        Me.panMainTop.PerformLayout()
        Me.panMiddle.ResumeLayout(False)
        Me.panShowRequest.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panTop As Panel
    Friend WithEvents panMiddle As Panel
    Friend WithEvents panIntoTop As Panel
    Friend WithEvents txtbtnNew As TextBox
    Friend WithEvents txtbtnClose As TextBox
    Friend WithEvents xTxtCreator As xTextBox
    Friend WithEvents xTxtStatus As xTextBox
    Friend WithEvents panViewMain As Panel
    Friend WithEvents panMainMiddle As Panel
    Friend WithEvents panMainTop As Panel
    Friend WithEvents lblSearch As Label
    Friend WithEvents lblRows As Label
    Friend WithEvents lblCreator As Label
    Friend WithEvents lblAccount As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents xTxtAccount As xTextBox
    Friend WithEvents lblClosePanView As Label
    Friend WithEvents lblRequestCode As Label
    Friend WithEvents xTxtRequestCode As xTextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsLblVersion As ToolStripStatusLabel
    Friend WithEvents lstViewShowReq As ListView
    Friend WithEvents panShowRequest As Panel
    Friend WithEvents lblItemCd As Label
    Friend WithEvents xTxtItemCd As xTextBox
    Friend WithEvents lblImprint As Label
    Friend WithEvents xTxtImprint As xTextBox
    Friend WithEvents xChkRush As xCheckBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents chkSearchActivate As CheckBox
    Friend WithEvents prgBar As ProgressBar
End Class
