'Public Class frmProg_Item_Price

'    Private User_Rights As String = "READONLY"

'    Private db As New cDBA()
'    Private dtPrices As DataTable

'    Public Sub New()

'        ' This call is required by the designer.
'        InitializeComponent()

'        ' Add any initialization after the InitializeComponent() call.

'    End Sub


'    Private Sub frmProg_Item_Price_Load(sender As Object, e As System.EventArgs) Handles Me.Load

'        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

'        Try

'            Call SetPermissions()

'            Call dgvItem_Price_CreateColumns()
'            Call dgvItem_Price_Fill()
'            Call dgvItem_Price_Format()

'        Catch er As Exception
'            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
'        End Try

'        Me.Cursor = System.Windows.Forms.Cursors.Arrow

'    End Sub

'    Private Sub SetPermissions()

'        Dim db As New cDBA
'        Dim dt As DataTable
'        Dim strSql As String

'        strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
'        dt = db.DataTable(strSql)
'        If dt.Rows.Count <> 0 Then
'            User_Rights = dt.Rows(0).Item("Access_Type").ToString
'        Else
'            strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
'            dt = db.DataTable(strSql)
'            If dt.Rows.Count <> 0 Then
'                User_Rights = dt.Rows(0).Item("Access_Type").ToString
'            End If
'        End If

'        Select Case User_Rights
'            Case "READWRITE"
'                'tsbSave.Enabled = True
'                'tsbNextStep.Enabled = True
'                'tsbExport.Enabled = True

'            Case "SUPERUSER"
'                'tsbSave.Enabled = True
'                'tsbNextStep.Enabled = True
'                'tsbExport.Enabled = True
'                'btnShowAdminFields.Visible = True

'            Case "READONLY"
'                'tsClose.Visible = True
'                Dim c As Control
'                For Each c In Me.Controls
'                    If TypeOf c Is TextBox Then
'                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        'c.Enabled = False
'                        'c.BackColor = Color.White
'                    ElseIf TypeOf c Is ComboBox Then
'                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                    ElseIf TypeOf c Is CheckBox Then
'                        'c.Enabled = False
'                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                    ElseIf TypeOf c Is RadioButton Then
'                        'c.Enabled = False
'                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                    ElseIf TypeOf c Is Button Then
'                        'c.Enabled = False
'                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
'                    End If
'                Next

'        End Select

'    End Sub


'#Region "PRIVATE dgvItem_Price MAINTENANCE OPERATIONS ##############################"

'    Private Sub dgvItem_Price_CreateColumns()

'        Try
'            With dgvItem_Price.Columns

'                If .Count > 0 Then
'                    For iCol = .Count To 1 Step -1
'                        .RemoveAt(iCol - 1)
'                    Next
'                End If

'                '.Add(DGVTextBoxColumn("FirstCol", "FirstCol", 0))
'                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_PRICE_ID", "CUS_PROG_ITEM_PRICE_ID", 20))
'                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_GUID", "CUS_PROG_ITEM_LIST_GUID", 100))
'                .Add(DGVTextBoxColumn("PRICE_COLUMN", "EQP_LEVEL", 20))
'                .Add(DGVTextBoxColumn("EQP_LEVEL", "EQP_LEVEL", 20))
'                .Add(DGVTextBoxColumn("EQP_COLUMN", "EQP_COLUMN", 20))
'                .Add(DGVTextBoxColumn("EQP_PCT", "EQP_PCT", 20))
'                .Add(DGVTextBoxColumn("UNIT_PRICE", "UNIT_PRICE", 20))
'                .Add(DGVTextBoxColumn("MIN_QTY_ORD", "MIN_QTY_ORD", 20))
'                .Add(DGVTextBoxColumn("USER_LOGIN", "Entered By", 80))
'                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE_TS", 20))
'                .Add(DGVTextBoxColumn("UPDATE_TS", "Entered Date", 80))

'                'Dim comboboxColumn As DataGridViewComboBoxColumn
'                'comboboxColumn = DGVComboBoxColumn("PROD_CAT_ID", "Category", 100)
'                'With comboboxColumn
'                '    .DataSource = GetProd_Cat_List()
'                '    .ValueMember = "PROD_CAT_ID"
'                '    .DisplayMember = "PROD_CAT_CODE"
'                'End With
'                '.Add(DGVCheckBoxColumn("EQP_LEVEL", "EQP", 40)) ' 50 

'            End With

'            With dgvItem_Price

'                .Columns(Prices.CUS_PROG_ITEM_PRICE_ID).Visible = False
'                .Columns(Prices.CUS_PROG_ITEM_LIST_GUID).Visible = False
'                .Columns(Prices.EQP_LEVEL).Visible = True
'                .Columns(Prices.EQP_COLUMN).Visible = True
'                .Columns(Prices.EQP_PCT).Visible = True
'                .Columns(Prices.UNIT_PRICE).Visible = True
'                .Columns(Prices.MIN_QTY_ORD).Visible = True
'                .Columns(Prices.USER_LOGIN).Visible = True
'                .Columns(Prices.CREATE_TS).Visible = True
'                .Columns(Prices.UPDATE_TS).Visible = True

'                .RowHeadersWidth = 20

'            End With

'        Catch er As Exception
'            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
'        End Try

'    End Sub


'    Private Sub dgvItem_Price_Fill()
'        Try

'            'Dim dt As DataTable
'            Dim db As New cDBA
'            'Ion I change MDB_ITEM_DETAIL => MDB_ITEM_DETAIL_OLD only for THOR dbo.100
'            Dim strLoadString As String = _
'            "SELECT     CUS_PROG_ITEM_COLOR_ID, CUS_PROG_ITEM_LIST_GUID, ITEM_NO, ITEM_COLOR, SELECTED, USER_LOGIN, CREATE_TS, UPDATE_TS " & _
'            "FROM       MDB_CUS_PROG_ITEM_COLOR C WITH (Nolock) " & _
'            "INNER JOIN MDB_ITEM_DETAIL I WITH (Nolock) ON C.Item_Cd = I.Item_Cd " & _
'            "WHERE      I.Item_Cd = '" & Trim(RTrim(txtItem_Cd.Text)) & "' " & _
'            "ORDER BY   I.CUS_PROG_ITEM_LIST_ID, ITEM_COLOR "



'            Dim strLoadEmpty As String = _
'            "SELECT     TOP 1 CAST(0 AS INT) AS CUS_PROG_ITEM_COLOR_ID, " & _
'            "           CAST('' AS VARCHAR(40)) AS CUS_PROG_ITEM_LIST_GUID, " & _
'            "           CAST('' AS VARCHAR(30)) AS ITEM_NO, " & _
'            "           CAST('' AS VARCHAR(30)) AS ITEM_COLOR, " & _
'            "           CAST(0 AS bit)) AS SELECTED, " & _
'            "           CAST('' AS VARCHAR(30)) AS USER_LOGIN, " & _
'            "           CAST(NULL AS DATETIME) AS CREATE_TS,  " & _
'            "           CAST(NULL AS DATETIME) AS UPDATE_TS,  " & _
'            "FROM       MDB_CUS_PROG_ITEM_COLOR "

'            dtPrices = db.DataTable(strLoadString)
'            If dtPrices.Rows.Count = 0 Then
'                dtPrices = db.DataTable(strLoadEmpty)
'            End If

'            dgvItem_Price.DataSource = dtPrices

'            dgvItem_Price.AllowUserToAddRows = False
'            dgvItem_Price.AllowUserToOrderColumns = False

'        Catch er As Exception
'            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
'        End Try

'    End Sub

'    Private Sub dgvItem_Price_Format()

'        Try

'            With dgvItem_Price
'                For lPos As Integer = 0 To .Columns.Count - 1
'                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
'                Next lPos

'                .CausesValidation = True

'                Dim oCellStyle As New DataGridViewCellStyle()
'                oCellStyle = New DataGridViewCellStyle()
'                oCellStyle.Format = "##,##0.000"
'                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'                .Columns(Prices.UNIT_PRICE).DefaultCellStyle = oCellStyle

'                oCellStyle = New DataGridViewCellStyle()
'                oCellStyle.Format = "##,##0.00"
'                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
'                .Columns(Prices.EQP_PCT).DefaultCellStyle = oCellStyle

'                oCellStyle = New DataGridViewCellStyle()
'                oCellStyle.Format = "###,##0"
'                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'                .Columns(Prices.MIN_QTY_ORD).DefaultCellStyle = oCellStyle

'                '.Columns(PickTypeColumns.ColHeader).Frozen = True
'                .Columns(Prices.CUS_PROG_ITEM_PRICE_ID).Frozen = True
'                .Columns(Prices.CUS_PROG_ITEM_LIST_GUID).Frozen = True
'                .Columns(Prices.PRICE_COLUMN).Frozen = True

'                ''.Columns(PickTypeColumns.ColHeader).Visible = False
'                '.Columns(Items.CUS_PROG_ITEM_LIST_ID).Visible = False
'                '.Columns(Items.CUS_PROG_ID).Visible = False

'                '.Columns(Items.USER_LOGIN).Visible = False
'                '.Columns(Items.UPDATE_TS).Visible = False

'                .CurrentCell = .Rows(0).Cells(Prices.PRICE_COLUMN)

'            End With

'        Catch er As Exception
'            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
'        End Try

'    End Sub

'#End Region


'    Private Sub ReadOnlyFields_GotFocus(sender As Object, e As System.EventArgs)

'        If User_Rights = "READONLY" Then
'            'txtCus_No.Focus()
'        End If

'    End Sub

'    Private Enum Prices

'        CUS_PROG_ITEM_PRICE_ID
'        CUS_PROG_ITEM_LIST_GUID
'        PRICE_COLUMN
'        EQP_LEVEL
'        EQP_COLUMN
'        EQP_PCT
'        UNIT_PRICE
'        MIN_QTY_ORD
'        USER_LOGIN
'        CREATE_TS
'        UPDATE_TS

'    End Enum

'End Class