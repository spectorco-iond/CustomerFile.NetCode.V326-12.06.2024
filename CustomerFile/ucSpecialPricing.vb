Public Class ucSpecialPricing

    Private User_Rights As String = "READONLY"

    Private dtSpecialPricing As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private m_Show_All_Customers As Boolean = False ' Done
    Private m_Show_Only_User_Stuff As Boolean = False ' Done
    Private m_Show_Cus_No As Boolean = False ' Done
    Private m_Show_Macola As Boolean = False
    Private m_Show_History As Boolean = False
    Private m_Show_Current As Boolean = True
    'Ion Added -----
    Private m_Show_Almost_Due As Boolean = False
    'Ion---------

    Private m_Loading As Boolean = True

    Public Shadows Sub Load()

        Try

            'm_Loading = True ' Maintenant dans NEW

            m_Show_All_Customers = True
            m_Show_Cus_No = True

            chkShow_Only_User_Stuff.Checked = True
            tscbSpecialPricing.Text = "Current Special Pricing"

            m_Loading = False

            Call SetPermissions()

            If dtSpecialPricing Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvSpecialPricing)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvQuotesunications.ColumnHeadersVisible = False

            End If

            Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            m_Loading = False

            Call SetPermissions()

            m_Customer = pCustomer

            If dtSpecialPricing Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvSpecialPricing)

                dgvSearch.ColumnHeadersHeight = 24
                dgvSpecialPricing.ColumnHeadersHeight = 24
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
                .Add(DGVTextBoxColumn("SPECTOR_CD", "Spector Code", 90)) '80
                .Add(DGVTextBoxColumn("PROG_CD", "Program Code", 130)) '110
                'Ion added PROG_CSR
                .Add(DGVTextBoxColumn("PROG_CSR", "Prog_CSR", 70))
                .Add(DGVTextBoxColumn("PROG_DESC", "Imprint", 130)) '110

                '--------------------------------------------
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("START_DT", "Start Date", 90)) '70
                Else
                    .Add(DGVTextBoxColumn("START_DT", "Start Date", 90)) '70
                End If

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("END_DT", "End Date", 90)) '70
                Else
                    .Add(DGVTextBoxColumn("END_DT", "End Date", 90)) '70
                End If
                '--------------------------------------------

                '.Add(DGVTextBoxColumn("START_DT", "Start Date", 70))
                '.Add(DGVTextBoxColumn("END_DT", "End Date", 70))

                .Add(DGVTextBoxColumn("ITEM_CD", "Item", 100)) '80
                .Add(DGVTextBoxColumn("ITEM_NO", "Sku", 100)) '
                .Add(DGVTextBoxColumn("MIN_QTY_ORD", "Min Qty", 60))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Price", 70))
                '.Add(DGVTextBoxColumn("EQP_LEVEL", "EQP Level", 60))
                .Add(DGVCheckBoxColumn("EQP_LEVEL", "EQP", 50))
                .Add(DGVTextBoxColumn("EQP_COLUMN", "EQP Column", 60))
                .Add(DGVTextBoxColumn("EQP_PCT", "EQP Disc", 70))
                .Add(DGVCheckBoxColumn("IS_APPROVED", "Approved", 80))
                .Add(DGVTextBoxColumn("APPROVED_BY_US", "By Us", 120))
                .Add(DGVTextBoxColumn("APPROVED_BY_THEM", "By Them", 120))
                .Add(DGVTextBoxColumn("APPROVED_DT", "Approved Date", 80))
                .Add(DGVTextBoxColumn("USER_LOGIN", "Updated by", 100)) '80
                .Add(DGVTextBoxColumn("UPDATE_TS", "Date", 100)) '80

            End With

            With dgv

                .Columns(Columns.CUS_PROG_ID).Visible = False
                .Columns(Columns.CUS_PROG_ITEM_LIST_ID).Visible = False
                'Ion added PROG_CSR
                .Columns(Columns.PROG_CSR).Visible = False
                .Columns(Columns.CUS_NO).Visible = m_Show_Cus_No
                .Columns(Columns.ITEM_NO).Visible = False
                .Columns(Columns.EQP_COLUMN).Visible = False
                .Columns(Columns.EQP_LEVEL).Visible = False
                .Columns(Columns.EQP_PCT).Visible = False
                .Columns(Columns.IS_APPROVED).Visible = False
                .Columns(Columns.APPROVED_BY_THEM).Visible = False
                .Columns(Columns.APPROVED_BY_US).Visible = False
                .Columns(Columns.APPROVED_DT).Visible = False
                .Columns(Columns.UPDATE_TS).Visible = True

                .Columns(Columns.CUS_PROG_ID).Frozen = True
                .Columns(Columns.CUS_PROG_ITEM_LIST_ID).Frozen = True
                .Columns(Columns.CUS_NO).Frozen = True
                .Columns(Columns.SPECTOR_CD).Frozen = True
                .Columns(Columns.PROG_CD).Frozen = True

                Dim oCellStyle As New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.0000"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.UNIT_PRICE).DefaultCellStyle = oCellStyle

                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.00"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.EQP_PCT).DefaultCellStyle = oCellStyle

                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.MIN_QTY_ORD).DefaultCellStyle = oCellStyle

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

            'Ion added P.PROG_CSR
            strSql = _
            "SELECT		P.CUS_PROG_ID, I.CUS_PROG_ITEM_LIST_ID, P.CUS_NO, P.SPECTOR_CD, P.PROG_CD, P.PROG_CSR, " & _
            "           CASE WHEN ISNULL(P.PROG_DESC, '') <> '' THEN P.PROG_DESC ELSE P.PROG_COMMENTS END AS PROG_DESC, " & _
            "			P.START_DT, P.END_DT, I.ITEM_CD, I.ITEM_NO, I.MIN_QTY_ORD, I.UNIT_PRICE,I.EQP_LEVEL,I.EQP_COLUMN,I.EQP_PCT,  " & _
            "			CONVERT(BIT, CASE WHEN P.APPROVED_DT IS NULL THEN 0 ELSE 1 END) AS IS_APPROVED, " & _
            "           P.APPROVED_BY_US, P.APPROVED_BY_THEM, P.APPROVED_DT, P.USER_LOGIN, P.UPDATE_TS " & _
            "FROM		MDB_CUS_PROG P WITH (Nolock) " & _
            "LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) ON P.CUS_PROG_ID = I.CUS_PROG_ID " & _
            "WHERE		P.PROG_TYPE in (2,4) "

            ' "			CASE WHEN I.EQP_LEVEL = 0 THEN I.UNIT_PRICE ELSE NULL END AS UNIT_PRICE, " & _
            '"			CASE WHEN I.EQP_LEVEL IS NULL THEN P.EQP_LEVEL ELSE I.EQP_LEVEL END AS EQP_LEVEL, " & _
            '"			CASE WHEN I.EQP_LEVEL = 1 THEN I.EQP_COLUMN ELSE NULL END AS EQP_COLUMN, " & _
            '"			CASE WHEN I.EQP_LEVEL = 1 THEN I.EQP_PCT ELSE NULL END AS EQP_PCT, " & _



            If Not (m_Show_All_Customers) Then
                strSql &= " AND P.CUS_NO = '" & m_Customer.cmp_code & "' "
            End If

            If Not (m_Show_History And m_Show_Current) Then
                If m_Show_History Then
                    strSql &= " AND P.End_Dt < CONVERT(DATE, GETDATE()) "
                ElseIf m_Show_Current Then
                    strSql &= " AND P.End_Dt >= CONVERT(DATE, GETDATE())  "
                    'Ion -------- Added ElseIf
                ElseIf m_Show_Almost_Due Then
                    strSql &= " AND  P.End_Dt >= (select DATEADD(DD,0,GETDATE()))" & _
                                "  AND  P.End_Dt <= (select DATEADD(DD,45,GETDATE())) "
                    'Ion --------------  
                End If
            End If

            dtSpecialPricing = db.DataTable(strSql)

            dgvSpecialPricing.DataSource = dtSpecialPricing
            dgvSpecialPricing.AllowUserToAddRows = False

            'Ion added PROG_CSR
            If dtSearch Is Nothing Then
                strSql = _
                "SELECT CAST(0 AS INT) AS CUS_PROG_ID, " & _
                "       CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " & _
                "       CAST('' AS VARCHAR(30)) AS CUS_NO, " & _
                "       CAST('' AS VARCHAR(30)) AS SPECTOR_CD, " & _
                "       CAST('' AS VARCHAR(30)) AS PROG_CD, " & _
                "       CAST('' AS VARCHAR(20)) AS PROG_CSR," & _
                "       CAST('' AS VARCHAR(30)) AS PROG_DESC, " & _
                "       CAST(NULL AS DATETIME) AS START_DT, " & _
                "       CAST(NULL AS DATETIME) AS END_DT, " & _
                "       CAST('' AS VARCHAR(30)) AS ITEM_CD, " & _
                "       CAST('' AS VARCHAR(30)) AS ITEM_NO, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " & _
                "       CAST(0 AS NUMERIC(13, 4)) AS UNIT_PRICE, " & _
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

            If dtSpecialPricing Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtSpecialPricing.DefaultView.RowFilter = strFilter
            dgvSpecialPricing.Refresh()

            tssRecordCount.Text = "Records: " & dgvSpecialPricing.Rows.Count.ToString

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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvSpecialPricing.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then
                dgv = dgvSpecialPricing
            Else
                dgv = dgvSearch
            End If
            Debug.Print(e.Column.Name & " --- " & e.Column.Width)
            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvSpecialPricing.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvPrograms_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSpecialPricing.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvPrograms_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvSpecialPricing.KeyDown

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

    Private Sub dgvOrders_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvSpecialPricing.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvSpecialPricing.FirstDisplayedScrollingColumnIndex

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
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        'Ion serach by date
                        GetSearchColumnsFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
                          & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "
                        'Ion
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


        If chkShow_Only_User_Stuff.Checked = True Then
            ' GetSearchColumnsFilter &= "AND PROG_CSR = '" & Environment.UserName & "' "

            'Ion Added this if for 'AND'
            If GetSearchColumnsFilter <> "" Then
                GetSearchColumnsFilter &= " AND PROG_CSR = '" & Environment.UserName & "' "
            Else
                GetSearchColumnsFilter &= " PROG_CSR = '" & Environment.UserName & "' "
            End If
            'Ion
        End If

    End Function

    Private Sub dgvSearch_Sorted(sender As Object, e As System.EventArgs) Handles dgvSearch.Sorted

        Try
            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvSpecialPricing.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvSpecialPricing.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvSpecialPricing.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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
        'Ion added
        PROG_CSR
        'Ion--
        PROG_DESC
        START_DT
        END_DT
        ITEM_CD
        ITEM_NO
        MIN_QTY_ORD
        UNIT_PRICE
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

            Dim ofrm As New frmQuickProgram(m_Customer, "Special Pricing") '12.14.2017 "Special Pricing")
            'ofrm.Program_Type = "Special Pricing"
            ofrm.ShowDialog()

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
            'Ion
            If dgvSpecialPricing.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oProgram As New cMdb_Cus_Prog()
                Dim oProgramB As New cMdb_Cus_Prog_BUS


                '++ID 3.08.2015 I put in comment because each time when open each cus_prog_id, the function do update, for nothing.
                'oProgram = oProgramB.Load(dgvSpecialPricing.CurrentRow.Cells(Columns.CUS_PROG_ID).Value)

                '++ID 3.08.2015 Added for filling only cMdb_Cus_Prog or only for create new Cus_Prog_Id
                oProgram = oProgramB.LoadPSQ(dgvSpecialPricing.CurrentRow.Cells(Columns.CUS_PROG_ID).Value)

                If m_Customer Is Nothing Or m_Show_All_Customers Then
                    m_Customer = New cCustomer(oProgram.Cus_No)
                End If

                Dim ofrm As New frmQuickProgram(m_Customer, oProgram)
                ofrm.Program_Type = "Special Pricing"
                ofrm.ShowDialog()

                ofrm = Nothing

                Call FillGrid()

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

            End If

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Try
            '    'Ion----- 15.10.14
            If dgvSpecialPricing.Rows.Count <> 0 Then


                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                'Ion 15.10.14
                Dim oProgram As New cMdb_Cus_Prog()
                Dim oCus_Prog As New cMdb_Cus_Prog_BUS()
                Dim oProgram_Rev As New cMdb_Cus_Prog_Rev_BLL()
                Dim oProgram_Comm As New cMdb_Prog_Comment()
                '  Dim oItemBll As New cMDB_CUS_PROG_ITEM_PRICE_BLL()
                Dim oItemBll As New cMdb_Cus_Prog_Item_List_BUS()
                Dim oCfg_Charge_Usage As New cMdb_Cfg_Charge_Usage()
                Dim oItemPrice As New cMacolaOeprcfil_Sql()

                oProgram.Cus_Prog_Id = dgvSpecialPricing.CurrentRow.Cells(Columns.CUS_PROG_ID).Value

                'cMacolaOeprcfil_Sql()
                oItemPrice.Cus_Prog_Id = oProgram.Cus_Prog_Id
                oItemPrice.DeleteAll() 'comment delete in the class

                'cMdb_Cfg_Charge_Usage()
                oCfg_Charge_Usage.Cus_Prog_ID = oProgram.Cus_Prog_Id
                oCfg_Charge_Usage.DeleteAll() 'comment delete in the class

                'cMdb_Cus_Prog_Item_List
                oItemBll.Delete(dgvSpecialPricing.CurrentRow.Cells(Columns.CUS_PROG_ITEM_LIST_ID).Value) 'comment delete in the class

                'cMdb_Prog_Comment()
                oProgram_Comm.Delete(oProgram) 'comment delete in the class

                'cMdb_Cus_Prog_Rev
                oProgram_Rev.Delete(oProgram) 'comment delete in the class

                'cMdb_Cus_Prog
                oCus_Prog.Delete(oProgram)

                'Ion---

                Call FillGrid()

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

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

    Private Property Show_All_Customers() As Boolean
        Get
            Show_All_Customers = m_Show_All_Customers
        End Get
        Set(ByVal value As Boolean)
            m_Show_All_Customers = value
        End Set
    End Property

    Private Property Show_Only_User_Stuff() As Boolean
        Get
            Show_Only_User_Stuff = m_Show_Only_User_Stuff
        End Get
        Set(ByVal value As Boolean)
            m_Show_Only_User_Stuff = value
        End Set
    End Property

    Private Property Show_Cus_No() As Boolean
        Get
            Show_Cus_No = m_Show_Cus_No
        End Get
        Set(ByVal value As Boolean)
            m_Show_Cus_No = value
        End Set
    End Property

    Private Property Show_History() As Boolean
        Get
            Show_History = m_Show_History
        End Get
        Set(ByVal value As Boolean)
            m_Show_History = value
        End Set
    End Property

    Private Property Show_Current() As Boolean
        Get
            Show_Current = m_Show_Current
        End Get
        Set(ByVal value As Boolean)
            m_Show_Current = value
        End Set
    End Property
    'Ion
    Private Property Show_Almost_Due As Boolean
        Get
            Show_Almost_Due = m_Show_Almost_Due
        End Get
        Set(ByVal value As Boolean)
            m_Show_Almost_Due = value
        End Set
    End Property
    'Ion
    Private Property Show_Macola() As Boolean
        Get
            Show_Macola = m_Show_Macola
        End Get
        Set(ByVal value As Boolean)
            m_Show_Macola = value
        End Set
    End Property

    Private Sub chkShow_Only_User_Stuff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShow_Only_User_Stuff.CheckedChanged

        m_Show_Only_User_Stuff = (chkShow_Only_User_Stuff.Checked)
        If Not m_Loading Then
            Menu_Refresh()
        End If

    End Sub

    Private Sub tscbSpecialPricing_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbSpecialPricing.SelectedIndexChanged

        m_Show_Current = (tscbSpecialPricing.Text = "All Special Pricing" Or tscbSpecialPricing.Text = "Current Special Pricing")
        m_Show_History = (tscbSpecialPricing.Text = "All Special Pricing" Or tscbSpecialPricing.Text = "History Special Pricing")
        'Ion Added------
        m_Show_Almost_Due = (tscbSpecialPricing.Text = "All Quotes" Or tscbSpecialPricing.Text = "Almost Due")
        'Ion ----------

        If Not m_Loading Then
            Menu_Refresh()
        End If

    End Sub

  
End Class
