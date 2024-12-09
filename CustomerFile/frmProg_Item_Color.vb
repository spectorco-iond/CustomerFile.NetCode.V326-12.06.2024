Public Class frmProg_Item_Color

    Private User_Rights As String = "READONLY"

    Private db As New cDBA()
    Private dtColors As DataTable

    Private Item_Cd As String
    Private Item_List_Guid As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pstrItem_Cd As String, ByVal pstrItem_List_Guid As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Item_Cd = pstrItem_Cd
        Item_List_Guid = pstrItem_List_Guid

    End Sub

    Private Sub frmProg_Item_Color_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            dgvItem_Color.EndEdit()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub frmProg_Item_Color_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            Call Fill_Fields()

            Call dgvItem_Color_CreateColumns()
            Call dgvItem_Color_Fill()
            Call dgvItem_Color_Format()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub Fill_Fields()

        Try
            txtItem_Cd.Text = Item_Cd

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetPermissions()

        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
        dt = db.DataTable(strSql)
        If dt.Rows.Count <> 0 Then
            User_Rights = dt.Rows(0).Item("Access_Type").ToString
        Else
            strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                User_Rights = dt.Rows(0).Item("Access_Type").ToString
            End If
        End If

        Select Case User_Rights
            Case "READWRITE"
                'tsbSave.Enabled = True
                'tsbNextStep.Enabled = True
                'tsbExport.Enabled = True

            Case "SUPERUSER"
                'tsbSave.Enabled = True
                'tsbNextStep.Enabled = True
                'tsbExport.Enabled = True
                'btnShowAdminFields.Visible = True

            Case "READONLY"
                'tsClose.Visible = True
                Dim c As Control
                For Each c In Me.Controls
                    If TypeOf c Is TextBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        'c.Enabled = False
                        'c.BackColor = Color.White
                    ElseIf TypeOf c Is ComboBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is CheckBox Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is RadioButton Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is Button Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    End If
                Next

        End Select

    End Sub


#Region "PRIVATE dgvItem_Color MAINTENANCE OPERATIONS ##############################"

    Private Sub dgvItem_Color_CreateColumns()

        Try
            With dgvItem_Color.Columns

                If .Count > 0 Then
                    For iCol = .Count To 1 Step -1
                        .RemoveAt(iCol - 1)
                    Next
                End If

                '.Add(DGVTextBoxColumn("FirstCol", "FirstCol", 0))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_COLOR_ID", "CUS_PROG_ITEM_COLOR_ID", 100))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_GUID", "CUS_PROG_ITEM_LIST_GUID", 100))
                .Add(DGVTextBoxColumn("ITEM_NO", "ITEM_NO", 100))
                .Add(DGVCheckBoxColumn("SELECTED", "Selected", 60))
                .Add(DGVTextBoxColumn("ITEM_COLOR", "Color", 180))
                .Add(DGVTextBoxColumn("USER_LOGIN", "Entered By", 100))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE_TS", 100))
                .Add(DGVTextBoxColumn("UPDATE_TS", "Entered Date", 100))

                'Dim comboboxColumn As DataGridViewComboBoxColumn
                'comboboxColumn = DGVComboBoxColumn("PROD_CAT_ID", "Category", 100)
                'With comboboxColumn
                '    .DataSource = GetProd_Cat_List()
                '    .ValueMember = "PROD_CAT_ID"
                '    .DisplayMember = "PROD_CAT_CODE"
                'End With
                '.Add(comboboxColumn)

            End With

            With dgvItem_Color

                .Columns(Colors.CUS_PROG_ITEM_COLOR_ID).Visible = False
                .Columns(Colors.CUS_PROG_ITEM_LIST_GUID).Visible = False
                .Columns(Colors.ITEM_NO).Visible = False
                .Columns(Colors.SELECTED).Visible = True
                .Columns(Colors.ITEM_COLOR).Visible = True
                .Columns(Colors.USER_LOGIN).Visible = False
                .Columns(Colors.CREATE_TS).Visible = False
                .Columns(Colors.UPDATE_TS).Visible = False

                .RowHeadersWidth = 20

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvItem_Color_Fill()
        Try
            Dim db As New cDBA

            Dim strLoadString As String =
            " SELECT     ISNULL(C.CUS_PROG_ITEM_COLOR_ID, 0) AS CUS_PROG_ITEM_COLOR_ID, C.CUS_PROG_ITEM_LIST_GUID, " &
            " I.ITEM_NO, ISNULL(C.SELECTED, 0) AS SELECTED, I.COLOR_LIST AS ITEM_COLOR, C.USER_LOGIN, C.CREATE_TS, C.UPDATE_TS " &
            " FROM	MDB_ITEM_DETAIL I WITH (Nolock) " &
            " LEFT JOIN	MDB_CUS_PROG_ITEM_COLOR C WITH (Nolock) ON I.ITEM_NO = C.ITEM_NO " &
            " WHERE I.Item_Cd = '" & Item_Cd & "' " &
            " ORDER BY	C.CUS_PROG_ITEM_COLOR_ID, I.COLOR_LIST "

            strLoadString = _
            " SELECT  ISNULL(C.CUS_PROG_ITEM_COLOR_ID, 0) AS CUS_PROG_ITEM_COLOR_ID, C.CUS_PROG_ITEM_LIST_GUID, " & _
            " I.ITEM_NO, ISNULL(C.SELECTED, 0) AS SELECTED, I.user_def_fld_2 AS ITEM_COLOR, C.USER_LOGIN, C.CREATE_TS, C.UPDATE_TS " & _
            " FROM	imitmidx_sql I WITH (Nolock)  LEFT JOIN	MDB_CUS_PROG_ITEM_COLOR C WITH (Nolock) ON I.ITEM_NO = C.ITEM_NO " & _
            " WHERE I.user_def_fld_1 = '" & Item_Cd & "' ORDER BY	C.CUS_PROG_ITEM_COLOR_ID, I.user_def_fld_2 "

            strLoadString =
            " SELECT  ISNULL(C.CUS_PROG_ITEM_COLOR_ID, 0) AS CUS_PROG_ITEM_COLOR_ID, C.CUS_PROG_ITEM_LIST_GUID, " &
            " I.ITEM_NO, ISNULL(C.SELECTED, 0) AS SELECTED, I.COLOR_LIST AS ITEM_COLOR, C.USER_LOGIN, C.CREATE_TS, C.UPDATE_TS " &
            " FROM	View_MDB_ITEM_DETAIL I WITH (Nolock)  LEFT JOIN	MDB_CUS_PROG_ITEM_COLOR C WITH (Nolock) ON I.ITEM_NO = C.ITEM_NO " &
            " WHERE I.ITEM_CD = '" & Item_Cd & "' " &
                       " ORDER BY	C.CUS_PROG_ITEM_COLOR_ID, I.COLOR_LIST"

            Dim strLoadEmpty As String = _
            "SELECT     TOP 1 CAST(0 AS INT) AS CUS_PROG_ITEM_COLOR_ID, " & _
            "           CAST('' AS VARCHAR(40)) AS CUS_PROG_ITEM_LIST_GUID, " & _
            "           CAST('' AS VARCHAR(30)) AS ITEM_NO, " & _
            "           CAST(0 AS bit) AS SELECTED, " & _
            "           CAST('' AS VARCHAR(30)) AS ITEM_COLOR, " & _
            "           CAST('' AS VARCHAR(30)) AS USER_LOGIN, " & _
            "           CAST(NULL AS DATETIME) AS CREATE_TS,  " & _
            "           CAST(NULL AS DATETIME) AS UPDATE_TS  " & _
            "FROM       MDB_CUS_PROG_ITEM_COLOR "

            dtColors = db.DataTable(strLoadString)
            If dtColors.Rows.Count = 0 Then
                dtColors = db.DataTable(strLoadEmpty)
            End If

            dgvItem_Color.DataSource = dtColors

            dgvItem_Color.AllowUserToAddRows = False
            dgvItem_Color.AllowUserToOrderColumns = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvItem_Color_Format()

        Try

            With dgvItem_Color
                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                .CausesValidation = True

                '.Columns(PickTypeColumns.ColHeader).Frozen = True
                .Columns(Colors.ITEM_NO).Frozen = True

                If .Rows.Count <> 0 Then
                    .CurrentCell = .Rows(0).Cells(Colors.ITEM_COLOR)
                End If

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


    Private Sub ReadOnlyFields_GotFocus(sender As Object, e As System.EventArgs)

        If User_Rights = "READONLY" Then
            'txtCus_No.Focus()
        End If

    End Sub


#Region "PRIVATE dgvItem_Color EVENTS ############################################"

    Private Sub dgvItem_Color_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvItem_Color.CellBeginEdit

        Try

            Select Case e.ColumnIndex

                Case Colors.ITEM_COLOR
                    e.Cancel = True

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvItem_Color_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem_Color.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case Colors.SELECTED

                    dgvItem_Color.EndEdit()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvItem_Color_Leave(sender As Object, e As System.EventArgs) Handles dgvItem_Color.Leave

        dgvItem_Color.EndEdit()

    End Sub

#End Region

    Public Sub Save()

        ' Do nothing if form was not opened.
        'If Not m_blnOpened Then Exit Sub

        Try

            Call SaveDataGrid(dgvItem_Color)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveDataGrid(ByRef dgv As DataGridView)

        Try

            Dim oColor As New cMDB_CUS_PROG_ITEM_COLOR()
            Dim oColorB As New cMDB_CUS_PROG_ITEM_COLOR_BLL()

            For Each dgvRow As DataGridViewRow In dgv.Rows
                dgvRow.Cells(Colors.CUS_PROG_ITEM_LIST_GUID).Value = Item_List_Guid
            Next

            ' First pass, we only save lines
            For Each dgvRow As DataGridViewRow In dgv.Rows

                'Prog_Comment_ID()'CUS_PROG_ID()'MESSAGE_ID()'CHECK_VALUE()'MESSAGE_DESC()
                If dgvRow.Cells(Colors.CUS_PROG_ITEM_COLOR_ID).Value <> 0 Then

                    oColor = oColorB.Load(dgvRow.Cells(Colors.CUS_PROG_ITEM_COLOR_ID).Value)

                    If oColor.Selected <> dgvRow.Cells(Colors.SELECTED).Value Then
                        oColor.Selected = dgvRow.Cells(Colors.SELECTED).Value
                        oColorB.Save(oColor)
                    End If

                Else

                    oColor = New cMDB_CUS_PROG_ITEM_COLOR()

                    oColor.Cus_Prog_Item_List_Guid = dgvRow.Cells(Colors.CUS_PROG_ITEM_LIST_GUID).Value
                    oColor.Item_No = dgvRow.Cells(Colors.ITEM_NO).Value.ToString
                    oColor.Selected = dgvRow.Cells(Colors.SELECTED).Value
                    oColorB.Save(oColor)

                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Enum Colors

        CUS_PROG_ITEM_COLOR_ID
        CUS_PROG_ITEM_LIST_GUID
        ITEM_NO
        SELECTED
        ITEM_COLOR
        USER_LOGIN
        CREATE_TS
        UPDATE_TS

    End Enum

End Class