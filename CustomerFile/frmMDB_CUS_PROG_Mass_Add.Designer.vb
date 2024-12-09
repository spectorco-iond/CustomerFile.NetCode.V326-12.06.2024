<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDB_CUS_PROG_Mass_Add
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
        Me.lblItemNumberList = New System.Windows.Forms.Label()
        Me.txtItem_List = New CustomerFile.xTextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblItemNumberList
        '
        Me.lblItemNumberList.AutoSize = True
        Me.lblItemNumberList.Location = New System.Drawing.Point(9, 11)
        Me.lblItemNumberList.Name = "lblItemNumberList"
        Me.lblItemNumberList.Size = New System.Drawing.Size(46, 13)
        Me.lblItemNumberList.TabIndex = 0
        Me.lblItemNumberList.Text = "Item List"
        '
        'txtItem_List
        '
        Me.txtItem_List.CharacterInput = CustomerFile.Cinput.NumericOnly
        Me.txtItem_List.DataLength = CType(0, Long)
        Me.txtItem_List.DataType = CustomerFile.CDataType.dtString
        Me.txtItem_List.DateValue = New Date(CType(0, Long))
        Me.txtItem_List.DecimalDigits = CType(0, Long)
        Me.txtItem_List.Location = New System.Drawing.Point(12, 27)
        Me.txtItem_List.Mask = Nothing
        Me.txtItem_List.Multiline = True
        Me.txtItem_List.Name = "txtItem_List"
        Me.txtItem_List.NumericValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtItem_List.OldValue = ""
        Me.txtItem_List.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtItem_List.Size = New System.Drawing.Size(157, 258)
        Me.txtItem_List.SpacePadding = CustomerFile.CSpacePadding.NoPadding
        Me.txtItem_List.StringValue = Nothing
        Me.txtItem_List.TabIndex = 1
        Me.txtItem_List.TextDataID = Nothing
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(100, 291)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(69, 24)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'frmMDB_CUS_PROG_Mass_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 323)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtItem_List)
        Me.Controls.Add(Me.lblItemNumberList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMDB_CUS_PROG_Mass_Add"
        Me.Text = "Mass EQP Item Insert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblItemNumberList As System.Windows.Forms.Label
    Friend WithEvents txtItem_List As CustomerFile.xTextBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
End Class
