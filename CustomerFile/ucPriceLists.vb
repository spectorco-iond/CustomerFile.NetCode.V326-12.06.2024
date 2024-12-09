Public Class ucPriceList

    Private User_Rights As String = "READONLY"

    Private dtPrograms As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            m_Customer = pCustomer

            If dtPrograms Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvPrograms)

                dgvSearch.ColumnHeadersHeight = 24
                dgvPrograms.ColumnHeadersHeight = 24
                'dgvPrograms.ColumnHeadersVisible = False

            End If

            If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

                Call ClearSearch()

            End If

            Call FillGrid()
            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub Save()

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 70))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_ID", "CUS_PROG_ITEM_LIST_ID", 20))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 70))
                .Add(DGVTextBoxColumn("SPECTOR_CD", "Spector Code", 80))
                .Add(DGVTextBoxColumn("PROG_CD", "Program Code", 100))
                .Add(DGVTextBoxColumn("PROG_DESC", "Description", 150))
                .Add(DGVTextBoxColumn("START_DT", "Start Date", 80))
                .Add(DGVTextBoxColumn("END_DT", "End Date", 80))
                .Add(DGVTextBoxColumn("ITEM_CD", "Item", 70))
                .Add(DGVTextBoxColumn("ITEM_NO", "Macola Item No", 100))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Unit Price", 80))
                .Add(DGVTextBoxColumn("MIN_QTY_ORD", "Min Qty Ord", 80))
                .Add(DGVTextBoxColumn("EQP_LEVEL", "EQP Level", 60))
                .Add(DGVTextBoxColumn("EQP_COLUMN", "EQP Column", 60))
                .Add(DGVTextBoxColumn("EQP_PCT", "EQP Pct", 60))
                .Add(DGVCheckBoxColumn("IS_APPROVED", "Approved", 80))
                .Add(DGVTextBoxColumn("APPROVED_BY_US", "By Us", 120))
                .Add(DGVTextBoxColumn("APPROVED_BY_THEM", "By Them", 120))
                .Add(DGVTextBoxColumn("APPROVED_DT", "Approved Date", 80))
                .Add(DGVTextBoxColumn("USER_LOGIN", "Updated by", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "Date", 80))

            End With

            With dgv

                .Columns(Columns.CUS_PROG_ID).Visible = False
                .Columns(Columns.CUS_PROG_ITEM_LIST_ID).Visible = False
                .Columns(Columns.CUS_NO).Visible = False

                .Columns(Columns.EQP_COLUMN).Visible = False
                .Columns(Columns.EQP_LEVEL).Visible = False
                .Columns(Columns.IS_APPROVED).Visible = False
                .Columns(Columns.APPROVED_BY_THEM).Visible = False
                .Columns(Columns.APPROVED_BY_US).Visible = False
                .Columns(Columns.APPROVED_DT).Visible = False
                .Columns(Columns.UPDATE_TS).Visible = False

                .Columns(Columns.CUS_PROG_ID).Frozen = True
                .Columns(Columns.CUS_PROG_ITEM_LIST_ID).Frozen = True
                .Columns(Columns.CUS_NO).Frozen = True
                .Columns(Columns.SPECTOR_CD).Frozen = True
                .Columns(Columns.PROG_CD).Frozen = True

                Dim oCellStyle As New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.0000"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.UNIT_PRICE).DefaultCellStyle = oCellStyle

            End With

            'Call dgvPrograms_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ClearSearch()

    End Sub

    Private Sub FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim strSql As String
            'strSql = "EXEC DBO.QUERY '"

            'dtPrograms = db.DataTable(strSql)

            'dgvPrograms.DataSource = dtPrograms
            'dgvPrograms.AllowUserToAddRows = False

            strSql = _
            "SELECT		P.CUS_PROG_ID, I.CUS_PROG_ITEM_LIST_ID, P.CUS_NO, P.SPECTOR_CD, P.PROG_CD, " & _
            "           CASE WHEN ISNULL(P.PROG_COMMENTS, '') <> '' THEN P.PROG_COMMENTS ELSE P.PROG_DESC END AS PROG_DESC, " & _
            "			P.START_DT, P.END_DT, I.ITEM_CD, I.ITEM_NO, I.UNIT_PRICE, I.MIN_QTY_ORD, " & _
            "			CASE WHEN I.EQP_LEVEL IS NULL THEN P.EQP_LEVEL ELSE I.EQP_LEVEL END AS EQP_LEVEL, " & _
            "			CASE WHEN I.EQP_LEVEL IS NULL THEN P.EQP_COLUMN ELSE I.EQP_COLUMN END AS EQP_COLUMN, " & _
            "			CASE WHEN I.EQP_LEVEL IS NULL THEN P.EQP_PCT ELSE I.EQP_PCT END AS EQP_PCT, " & _
            "			CONVERT(BIT, CASE WHEN P.APPROVED_DT IS NULL THEN 0 ELSE 1 END) AS IS_APPROVED, " & _
            "           P.APPROVED_BY_US, P.APPROVED_BY_THEM, P.APPROVED_DT, P.USER_LOGIN, P.UPDATE_TS " & _
            "FROM		MDB_CUS_PROG P WITH (Nolock) " & _
            "LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) ON P.CUS_PROG_ID = I.CUS_PROG_ID " & _
            "WHERE		P.CUS_NO = '" & m_Customer.cmp_code & "' AND PROG_TYPE = 2 "

            dtPrograms = db.DataTable(strSql)

            dgvPrograms.DataSource = dtPrograms
            dgvPrograms.AllowUserToAddRows = False

            If dtSearch Is Nothing Then
                strSql = _
                "SELECT CAST(0 AS INT) AS CUS_PROG_ID, " & _
                "       CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " & _
                "       CAST('' AS VARCHAR(30)) AS CUS_NO, " & _
                "       CAST('' AS VARCHAR(30)) AS SPECTOR_CD, " & _
                "       CAST('' AS VARCHAR(30)) AS PROG_CD, " & _
                "       CAST('' AS VARCHAR(30)) AS PROG_DESC, " & _
                "       CAST(NULL AS DATETIME) AS START_DT, " & _
                "       CAST(NULL AS DATETIME) AS END_DT, " & _
                "       CAST('' AS VARCHAR(30)) AS ITEM_CD, " & _
                "       CAST('' AS VARCHAR(30)) AS ITEM_NO, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS UNIT_PRICE, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_LEVEL, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_COLUMN, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_PCT, " & _
                "       CAST(0 AS INT) AS IS_APPROVED, " & _
                "       CAST('' AS VARCHAR(30)) AS APPROVED_BY_US, " & _
                "       CAST('' AS VARCHAR(30)) AS APPROVED_BY_THEM, " & _
                "       CAST('' AS VARCHAR(30)) AS APPROVED_DT, " & _
                "       CAST('' AS VARCHAR(30)) AS USER_LOGIN, " & _
                "       CAST(NULL AS DATETIME) AS UPDATE_TS "

                dtSearch = db.DataTable(strSql)
                dgvSearch.DataSource = dtSearch
                dgvSearch.AllowUserToAddRows = False

            End If

            Call ApplyFilters()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ApplyFilters()

        Try

            If dtPrograms Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtPrograms.DefaultView.RowFilter = strFilter
            dgvPrograms.Refresh()

            tssRecordCount.Text = "Records: " & dgvPrograms.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Call ApplyFilters()

    End Sub

    Private Sub dgvSearch_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        dgvSearch.BeginEdit(True)

    End Sub

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvPrograms.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then
                dgv = dgvPrograms
            Else
                dgv = dgvSearch
            End If
            Debug.Print(e.Column.Name & " --- " & e.Column.Width)
            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvPrograms.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvPrograms_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvPrograms.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvPrograms_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvPrograms.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Return ' Open element
                    Call Menu_Open()

                Case Keys.Insert ' Insert a new element
                    Call Menu_New()

                Case Keys.Delete ' Delete current element
                    Call Menu_Delete()

                Case Keys.F5
                    Call Menu_Refresh()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvPrograms_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvPrograms.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvPrograms.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns
            Debug.Print(oColumn.Name.ToString)
            Select Case oColumn.Name.ToString
                Case "CUS_NO", "SPECTOR_CD", "PROG_CD", "PROG_DESC", "ITEM_CD", "ITEM_NO", _
                    "APPROVED_BY_US", "APPROVED_BY_THEM", "USER_LOGIN" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "START_DT", "END_DT", "APPROVED_DT", "UPDATE_TS" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    End If

                Case "UNIT_PRICE", "MIN_QTY_ORD", "EQP_LEVEL", _
                    "EQP_COLUMN", "EQP_PCT" '  Numeric

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                            GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If
            End Select

        Next oColumn

    End Function

    Private Sub dgvSearch_Sorted(sender As Object, e As System.EventArgs) Handles dgvSearch.Sorted

        Try
            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvPrograms.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvPrograms.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvPrograms.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvSearch_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.ColumnHeaderMouseClick

        Try
            Dim oColumn As DataGridViewColumn
            oColumn = dgvSearch.Columns(e.ColumnIndex)

            Select Case oColumn.Index

                Case Columns.START_DT, Columns.END_DT, Columns.APPROVED_DT, Columns.UPDATE_TS

                    ' There is a glitch in the .NET enums... 
                    ' Ascending is 0 in ListDirection and 1 in SortOrder (0 is none in sort order)
                    Dim oSortOrder As System.ComponentModel.ListSortDirection
                    oSortOrder = System.ComponentModel.ListSortDirection.Ascending

                    If dgvSearch.SortOrder = 1 Then
                        oSortOrder = System.ComponentModel.ListSortDirection.Descending
                    End If

                    dgvSearch.Sort(oColumn, oSortOrder)

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Enum Columns

        CUS_PROG_ID
        CUS_PROG_ITEM_LIST_ID
        CUS_NO
        SPECTOR_CD
        PROG_CD
        PROG_DESC
        START_DT
        END_DT
        ITEM_CD
        ITEM_NO
        UNIT_PRICE
        MIN_QTY_ORD
        EQP_LEVEL
        EQP_COLUMN
        EQP_PCT
        IS_APPROVED
        APPROVED_BY_US
        APPROVED_BY_THEM
        APPROVED_DT
        USER_LOGIN
        UPDATE_TS

    End Enum

    Private Sub tsbNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbNew.Click

        Call Menu_New()

    End Sub

    Private Sub tsbOpen_Click(sender As System.Object, e As System.EventArgs) Handles tsbOpen.Click

        Call Menu_Open()

    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click

        Call Menu_Delete()

    End Sub

    Private Sub tsbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefresh.Click

        Call Menu_Refresh()

    End Sub

    Private Sub Menu_New()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ofrm As New frmQuickProgram(m_Customer, "Special Pricing")
            'ofrm.Program_Type = "Special Pricing"

            ofrm.ShowDialog()

            'ofrm.Dispose()
            ofrm = Nothing

            Call FillGrid()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim oProgram As New cMdb_Cus_Prog()
            Dim oProgramB As New cMdb_Cus_Prog_BUS

            oProgram = oProgramB.Load(dgvPrograms.CurrentRow.Cells(Columns.CUS_PROG_ID).Value)

            Dim ofrm As New frmQuickProgram(m_Customer, oProgram)
            ofrm.Program_Type = "Special Pricing"

            ofrm.ShowDialog()

            'ofrm.Dispose()
            ofrm = Nothing

            Call FillGrid()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Call FillGrid()

    End Sub

    Private Sub Menu_Refresh()

        Call FillGrid()

    End Sub

    Private Sub SetPermissions()

        SetUser_Rights(User_Rights, Me.Tag)

        Select Case User_Rights
            Case "READWRITE"
                tsbNew.Enabled = True
                tsbDelete.Enabled = True

            Case "SUPERUSER"
                tsbNew.Enabled = True
                tsbDelete.Enabled = True

            Case "READONLY"
                tsbNew.Enabled = False
                tsbDelete.Enabled = False

        End Select

    End Sub

End Class
