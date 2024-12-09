Public Class ucCharges

    Private User_Rights As String = "READONLY"

    Private dtCharges As DataTable
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
    Private m_Show_Almost_Due As Boolean = False

    Private m_Loading As Boolean = True

    Public Shadows Sub Load()

        Try

            'm_Loading = True ' Maintenant dans NEW

            m_Show_All_Customers = True
            m_Show_Cus_No = True

            chkShow_Only_User_Stuff.Checked = True
            tscbOptions.Text = "Current Options"

            m_Loading = False

            Call SetPermissions()

            If dtCharges Is Nothing Then

                Call dgvCharges_Load()

                'Call CreateColumns(dgvSearch)
                'Call CreateColumns(dgvCharges)

                'dgvSearch.ColumnHeadersHeight = 24
                'dgvQuotesunications.ColumnHeadersVisible = False

            End If

            '  Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Shadows Sub Load(ByVal pCustomer As cCustomer)

        Try

            tscbOptions.Text = "Current Options"

            m_Loading = False

            Call SetPermissions()

            m_Customer = pCustomer

            If dtCharges Is Nothing Then

                Call dgvCharges_Load()

                'Call CreateColumns(dgvSearch)
                'Call CreateColumns(dgvCharges)

                'dgvSearch.ColumnHeadersHeight = 24
                'dgvCharges.ColumnHeadersHeight = 24
                'dgvCharges.ColumnHeadersVisible = False

            End If

            'If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

            '    Call ClearSearch()

            'End If

            'Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CusProg_Id", 30))
                .Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 30))
                .Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 30))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Charge name", 150))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 100))
                .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 50))
                .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 50))
                .Add(DGVCheckBoxColumn("WAIVED", "Waived", 50))
                .Add(DGVCheckBoxColumn("NOT_WAIVED", "Not waived", 50))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Unit Price", 80))
                .Add(DGVTextBoxColumn("WHEN_QTY_LT", "When Qty LT", 80))
                .Add(DGVTextBoxColumn("WHEN_QTY_GT", "When Qty GT", 80))
                .Add(DGVTextBoxColumn("WHEN_AMT_LT", "When Amt LT", 80))
                .Add(DGVTextBoxColumn("WHEN_AMT_GT", "When Amt GT", 80))
                .Add(DGVCheckBoxColumn("SEND_EMAIL", "Send Email", 50))
                .Add(DGVTextBoxColumn("EMAIL_TO", "Send Email To", 150))
                .Add(DGVCheckBoxColumn("WHEN_REQ", "When Request", 50))
                .Add(DGVCheckBoxColumn("BLIND", "Blind", 50))
                .Add(DGVTextBoxColumn("COMMENTS", "Comments", 150))
                .Add(DGVTextBoxColumn("AUTORIZED_BY", "Approved by", 150))
                .Add(DGVTextBoxColumn("PROG_CSR", "Prog_CSR", 70))

            End With

            With dgv
                .Columns(Columns.CUS_PROG_ID).Visible = False
                .Columns(Columns.CHARGE_ID).Visible = False
                .Columns(Columns.CHARGE_USAGE_ID).Visible = False
                .Columns(Columns.CUS_NO).Visible = m_Show_Cus_No
                .Columns(Columns.NOT_WAIVED).Visible = False
                .Columns(Columns.CUS_PROG_ID).Frozen = True
                .Columns(Columns.CHARGE_ID).Frozen = True
                .Columns(Columns.CHARGE_USAGE_ID).Frozen = True
                .Columns(Columns.SHORT_DESC).Frozen = True
                .Columns(Columns.PROG_CSR).Visible = False

            End With

            Dim oCellStyle As New DataGridViewCellStyle()
            oCellStyle.Format = "###,##0"
            oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgv.Columns(Columns.WHEN_QTY_LT).DefaultCellStyle = oCellStyle
            dgv.Columns(Columns.WHEN_QTY_GT).DefaultCellStyle = oCellStyle
            dgv.Columns(Columns.WHEN_AMT_LT).DefaultCellStyle = oCellStyle
            dgv.Columns(Columns.WHEN_AMT_GT).DefaultCellStyle = oCellStyle

            'Call dgvCharges_FillGrid()

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

            'dtCharges = db.DataTable(strSql)

            'dgvCharges.DataSource = dtCharges
            'dgvCharges.AllowUserToAddRows = False

            strSql = _
            "SELECT	CP.CUS_PROG_ID, C.CHARGE_ID, ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.SHORT_DESC, CU.CUS_NO, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS WAIVED, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 0 ELSE 1 END)) AS NOT_WAIVED, " & _
            "           CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN CONVERT(VARCHAR(10), '')  ELSE CONVERT(VARCHAR(10), CU.UNIT_PRICE) END AS UNIT_PRICE, " & _
            "           CU.WHEN_QTY_LT, CU.WHEN_QTY_GT, CU.WHEN_AMT_LT, CU.WHEN_AMT_GT, " & _
            "           CU.SEND_EMAIL, CU.EMAIL_TO, CU.WHEN_REQ, CU.BLIND, CU.COMMENTS, CU.AUTORIZED_BY, H.USR_ID AS PROG_CSR " & _
            "FROM " & _
            "   (	SELECT	CUS.CUS_NO, CUS.SLSPSN_NO, C.* " & _
            "       FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
            "	) C " & _
            "LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no " & _
            "INNER JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON CU.CHARGE_ID = CH.CHARGE_ID " & _
            "LEFT JOIN  MDB_CUS_PROG CP WITH (NOLOCK) ON CU.CUS_PROG_ID = CP.CUS_PROG_ID AND ISNULL(CP.PROG_TYPE, 0) IN (0, 4) " & _
            "LEFT JOIN  HUMRES H WITH (NOLOCK) ON C.slspsn_no = H.RES_ID " & _
            "WHERE		(CU.charge_usage_id IS NOT NULL) AND ISNULL(CP.PROG_TYPE, 0) IN (0, 4) "
            '"WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND (CU.charge_usage_id IS NOT NULL) AND CP.PROG_TYPE = 4 "

            If Not (m_Show_All_Customers) Then
                strSql &= " AND CU.CUS_NO = '" & m_Customer.cmp_code & "' "
            End If

            'Ion: I removed one condition for the table MDB_CUS_PROG on CU.CUS_NO = CP.CUS_NO AND 
            'Because it display only CUS_NO what is it the table MDB_CUS_PROG, if are saved for one group


            '"ORDER BY	C.CUS_NO, C.SHORT_DESC "

            '"WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND (CU.charge_usage_id IS NOT NULL) AND (ISNULL(CU.cus_prog_id, 0) = 0) " & _
            '"ORDER BY	C.CUS_NO, C.SHORT_DESC "

            '"WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND (C.CHARGE_ID IN (13, 14, 16, 8, 17) OR CU.charge_usage_id IS NOT NULL) " & _
            '"WHERE		P.CUS_NO = '" & m_Customer.cmp_code & "' AND PROG_TYPE = 1 "

            If Not (m_Show_History And m_Show_Current) Then
                If m_Show_History Then
                    strSql &= " AND CU.CHARGE_FROM < CONVERT(DATE, GETDATE()) "
                ElseIf m_Show_Current Then
                    strSql &= " AND CU.CHARGE_TO >= CONVERT(DATE, GETDATE()) "
                    'Ion -------- Added ElseIf
                ElseIf m_Show_Almost_Due Then
                    strSql &= "  AND  CU.CHARGE_TO  >= (select DATEADD(DD,0,GETDATE()))" & _
                              " AND  CU.CHARGE_TO  <= (select DATEADD(DD,45,GETDATE())) "
                    'Ion --------------  
                End If
            End If

            strSql &= "ORDER BY	C.CUS_NO, C.SHORT_DESC "

            dtCharges = db.DataTable(strSql)

            dgvCharges.DataSource = dtCharges
            dgvCharges.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = _
                "SELECT CAST(0 AS INT) AS CUS_PROG_ID,CAST(0 AS INT) AS CHARGE_ID, CAST(0 AS INT) AS CHARGE_USAGE_ID, " & _
                "CAST('' AS VARCHAR(20)) AS SHORT_DESC, CAST('' AS VARCHAR(20)) AS CUS_NO, " & _
                "CAST(0 AS BIT) AS ALWAYS_USE, CAST(0 AS BIT) AS NEVER_USE, " & _
                "CAST(0 AS BIT) AS WAIVED, CAST(0 AS BIT) AS NOT_WAIVED, CAST('' AS VARCHAR(10)) AS UNIT_PRICE," & _
                "CAST(0 AS NUMERIC(13, 4)) AS WHEN_QTY_LT, CAST(0 AS NUMERIC(13, 4)) AS WHEN_QTY_GT, " & _
                "CAST(0 AS NUMERIC(13, 4)) AS WHEN_AMT_LT, CAST(0 AS NUMERIC(13, 4)) AS WHEN_AMT_GT, " & _
                "CAST('' AS VARCHAR(255)) AS SEND_EMAIL, CAST('' AS VARCHAR(100)) AS EMAIL_TO, " & _
                "CAST(0 AS BIT) AS WHEN_REQ, CAST(0 AS BIT) AS BLIND, " & _
                "CAST('' AS VARCHAR(255)) AS COMMENTS, CAST('' AS VARCHAR(20)) AS AUTORIZED_BY "

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

            If dtCharges Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtCharges.DefaultView.RowFilter = strFilter
            dgvCharges.Refresh()

            tssRecordCount.Text = "Records: " & dgvCharges.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        'For Each oColumn As DataGridViewColumn In dgvSearch.Columns
        '    Debug.Print(oColumn.Name.ToString)
        '    Select Case oColumn.Name.ToString
        '        Case "CUS_NO", "SPECTOR_CD", "PROG_CD", "PROG_DESC", "ITEM_CD", "ITEM_NO", _
        '            "APPROVED_BY_US", "APPROVED_BY_THEM", "USER_LOGIN" ' String

        '            If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
        '                If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
        '                Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
        '                GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
        '                'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
        '            End If

        '        Case "START_DT", "END_DT", "APPROVED_DT", "UPDATE_TS" ' Date

        '            If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
        '                If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
        '                'Ion search by date
        '                GetSearchColumnsFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
        '                  & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "
        '                'Ion
        '                'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
        '            End If

        '        Case "UNIT_PRICE", "MIN_QTY_ORD", "EQP_LEVEL", _
        '            "EQP_COLUMN", "EQP_PCT" '  Numeric

        '            If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
        '                If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
        '                    If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
        '                    GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
        '                End If
        '            Else
        '                If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
        '                    MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
        '                End If
        '            End If
        '    End Select

        'Next oColumn

        If chkShow_Only_User_Stuff.Checked = True Then
            'Ion Added this if for 'AND'
            If GetSearchColumnsFilter <> "" Then
                GetSearchColumnsFilter &= " AND PROG_CSR = '" & Environment.UserName & "' "
            Else
                GetSearchColumnsFilter &= " PROG_CSR = '" & Environment.UserName & "' "
            End If
            'Ion
        End If

    End Function

    Private Sub dgvSearch_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Try

            'e.Cancel = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvSearch_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Try
            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        Try

            dgvSearch.BeginEdit(True)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSearch.Sorted

        Try
            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvCharges.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvCharges.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvCharges.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    'Private Sub dgvSearch_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.ColumnHeaderMouseClick

    '    Try
    '        Dim oColumn As DataGridViewColumn
    '        oColumn = dgvSearch.Columns(e.ColumnIndex)

    '        Select Case oColumn.Index

    '            Case Columns.START_DT, Columns.END_DT, Columns.APPROVED_DT, Columns.UPDATE_TS

    '                ' There is a glitch in the .NET enums... 
    '                ' Ascending is 0 in ListDirection and 1 in SortOrder (0 is none in sort order)
    '                Dim oSortOrder As System.ComponentModel.ListSortDirection
    '                oSortOrder = System.ComponentModel.ListSortDirection.Ascending

    '                If dgvSearch.SortOrder = 1 Then
    '                    oSortOrder = System.ComponentModel.ListSortDirection.Descending
    '                End If

    '                dgvSearch.Sort(oColumn, oSortOrder)

    '        End Select

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub dgv_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvCharges.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvCharges
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvCharges.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Function GetSearchColumnsFilter() As String

    '    GetSearchColumnsFilter = ""

    '    For Each oColumn As DataGridViewColumn In dgvSearch.Columns

    '        Select Case oColumn.Name.ToString
    '            Case "Cus_No", "Ord_Type", "RMA_No", "Ord_No", "Inv_No", "Ct_Ord_No", "Ct_Inv_No", "OE_Po_No", _
    '                 "Bill_To_Name", "Shipping_Status", "User_def_Fld_4", "NotShipped", "PartialShipped", _
    '                 "CompleteShipped", "Has_Bo", "BO_Count", "Repeat_From", "Repeat_To", "Extra_1", "Extra_2" ' String

    '                If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
    '                    '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
    '                    If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
    '                    GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
    '                End If

    '            Case "Ord_Dt", "Inv_Dt", "ShippedDate" ' Date

    '                If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
    '                    'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
    '                End If

    '            Case "Tot_Dollars", "Tot_Sls_Amt", "Nb_Travelers", "LinesShipped", "Line_Count" ' Numeric

    '                If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
    '                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
    '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
    '                        GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
    '                    End If
    '                Else
    '                    If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
    '                        MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
    '                    End If
    '                End If
    '        End Select

    '    Next oColumn

    'End Function

    Private Enum Columns
        CUS_PROG_ID
        CHARGE_ID
        CHARGE_USAGE_ID
        SHORT_DESC
        CUS_NO
        ALWAYS_USE
        NEVER_USE
        WAIVED
        NOT_WAIVED
        UNIT_PRICE
        WHEN_QTY_LT
        WHEN_QTY_GT
        WHEN_AMT_LT
        WHEN_AMT_GT
        SEND_EMAIL
        EMAIL_TO
        WHEN_REQ
        BLIND
        COMMENTS
        AUTORIZED_BY
        PROG_CSR

    End Enum

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click

        Call Menu_New()

    End Sub

    Private Sub tsbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOpen.Click

        Call Menu_Open()

    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click

        Call Menu_Delete()

    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click

        Call Menu_Refresh()

    End Sub

    Private Sub Menu_New()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ofrm As New frmMDB_CFG_CHARGE_USAGE(m_Customer)

            ofrm.ShowDialog()

            'ofrm.Dispose()
            ofrm = Nothing

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try

            If dgvCharges.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oCus_Ship As New cMdb_Cfg_Charge_Usage(dgvCharges.CurrentRow.Cells(Columns.CHARGE_USAGE_ID).Value)

                If m_Customer Is Nothing Or m_Show_All_Customers Then
                    m_Customer = New cCustomer(oCus_Ship.Cus_No)
                End If

                Dim ofrm As New frmMDB_CFG_CHARGE_USAGE(m_Customer, oCus_Ship)

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

                ofrm.ShowDialog()

                'ofrm.Dispose()
                ofrm = Nothing

                Call FillGrid()

            End If

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()
        'Ion 20.10.14 --------------------------------
        Try


            Dim oMdbCfgChargeUsage As New cMdb_Cfg_Charge_Usage()
            Dim oMdbCusProg As New cMdb_Cus_Prog()
            Dim oCusProg_BLL As New cMdb_Cus_Prog_BUS()
            Dim oItemPrice As New cMacolaOeprcfil_Sql()

            If dgvCharges.Rows.Count <> 0 Then

                oItemPrice.Cus_Prog_Id = dgvCharges.CurrentRow.Cells(Columns.CUS_PROG_ID).Value
                oItemPrice.DeleteAll()

                oMdbCfgChargeUsage.Cus_Prog_ID = dgvCharges.CurrentRow.Cells(Columns.CUS_PROG_ID).Value
                oMdbCfgChargeUsage.DeleteAll()

                oMdbCusProg.Cus_Prog_Id = dgvCharges.CurrentRow.Cells(Columns.CUS_PROG_ID).Value
                oCusProg_BLL.Delete(oMdbCusProg)

                'After what we delete one line in the cMdb_Cfg_Charge_Usage,
                ' verify if exist in the table same cus_prog_id, 
                'if not exist , we must delete cus_prog_id in the table Mdb_Cus_Prog
                '  If oMdbCfgChargeUsage.Count(oMdbCusProg) = 0 Then oCusProg_BLL.Delete(oMdbCusProg)

            End If
            Call FillGrid()
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
        'Ion-------------------
    End Sub

    Private Sub Menu_Refresh()

        Call FillGrid()

    End Sub


    Private Sub dgvCharges_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCharges.DoubleClick

        'Call Menu_Open()
        tsbOpen.PerformClick()

    End Sub

    Private Sub dgvCharges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCharges.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Return ' Open element
                    tsbOpen.PerformClick()

                Case Keys.Insert ' Insert a new element
                    tsbNew.PerformClick()

                Case Keys.Delete ' Delete current element
                    tsbOpen.PerformClick()

                Case Keys.F5
                    tsbRefresh.PerformClick()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

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

        '++ID 2015.04.21 Added permission for button Manage Global Options of the customer 
        Dim strRights As String = "READONLY"

        SetUser_Rights(strRights, tsbGlobalOption.Tag)

        Select Case strRights
            Case "READWRITE"
                tsbGlobalOption.Visible = True
            Case "READONLY"
                tsbGlobalOption.Visible = False
        End Select



    End Sub

    Private Sub tscbOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbOptions.SelectedIndexChanged

        m_Show_Current = (tscbOptions.Text = "All Options" Or tscbOptions.Text = "Current Options")
        m_Show_History = (tscbOptions.Text = "All Options" Or tscbOptions.Text = "History Options")
        'Ion Added------
        m_Show_Almost_Due = (tscbOptions.Text = "All Quotes" Or tscbOptions.Text = "Almost Due")
        'Ion ----------

        If Not m_Loading Then
            Menu_Refresh()
        End If

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

    Private Property Show_Almost_Due() As Boolean
        Get
            Show_Almost_Due = m_Show_Almost_Due
        End Get
        Set(ByVal value As Boolean)
            m_Show_Almost_Due = value
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

    Private Sub tsbGlobalOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGlobalOption.Click
        Try

            '++ID 2015.04.21 
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ofrmManage As New frmManageGlobalOptions(m_Customer)

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

            ofrmManage.ShowDialog()

            'ofrm.Dispose()
            ofrmManage = Nothing

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "Charge"
    Private Sub dgvCharges_Load()

        Try
            '++ID put in comment 2015.04.20-----------------------------------------------
            'With dgvOptions.Columns
            '    .Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 50))
            '    '.Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 20))
            '    .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 85))
            '    .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 40))
            '    .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 40))
            '    .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 40))
            '    .Add(DGVCheckBoxColumn("WAIVED", "N/C", 30))
            '    .Add(DGVCheckBoxColumn("NOT_WAIVED", "Not Waived", 40))
            '    .Add(DGVTextBoxColumn("EXT_COMMENTS", "Comments", 125))
            '    .Add(DGVTextBoxColumn("CHARGE_ORDER", "CHARGE_ORDER", 50))
            '    'CHARGE_ORDER
            'End With
            '----------------------------------------------------------------------------
            '++ID Added new columns 2015.04.20 ------------------------------------------
            dgvCharges.Columns.Clear()

            With dgvCharges.Columns
                .Add(DGVTextBoxColumn("CHARGE_ID", "Charge ID", 50))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Description", 160))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 90))
                .Add(DGVCheckBoxColumn("Always", "Always", 45))
                .Add(DGVCheckBoxColumn("Never", "Never", 45))
                .Add(DGVTextBoxColumn("CD_TP", "cd_tp", 40))
                .Add(DGVTextBoxColumn("CURR_CD", "Currency", 60))
                .Add(DGVTextBoxColumn("CD_TP_1_CUST_NO", "Customer", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_ITEM_NO", "Item no", 90))
                .Add(DGVTextBoxColumn("PRC_OR_DISC_1", "Prix", 60))
                .Add(DGVTextBoxColumn("START_DT", "Start Dt", 80))
                .Add(DGVTextBoxColumn("END_DT", "End Dt", 80))
                .Add(DGVTextBoxColumn("extra_8", "Create Dt", 90))
                .Add(DGVTextBoxColumn("extra_9", "Update Dt", 90))
                .Add(DGVTextBoxColumn("extra_15", "User Login", 90))
                .Add(DGVTextBoxColumn("ID", "ID", 50))
                'CHARGE_ORDER
            End With


            With dgvCharges
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                .Columns(OptionAll.CHARGE_ID).Visible = False
                .Columns(OptionAll.DESCRIPTION).Visible = True
                .Columns(OptionAll.cd_tp).Visible = False
                .Columns(OptionAll.curr_cd).Visible = True
                .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
                .Columns(OptionAll.cd_tp_1_item_no).Visible = False
                .Columns(OptionAll.extra_8).Visible = True 'create date
                .Columns(OptionAll.extra_9).Visible = True 'update date
                .Columns(OptionAll.extra_15).Visible = True
                .Columns(OptionAll.ID).Visible = False
            End With

            'With dgvOptions
            '    .ColumnHeadersHeight = 20
            '    .RowHeadersWidth = 20
            '    .Columns(OptionAll.CHARGE_ID).Visible = False
            '    .Columns(OptionAll.DESCRIPTION).Visible = False
            '    .Columns(OptionAll.cd_tp).Visible = False
            '    .Columns(OptionAll.curr_cd).Visible = False
            '    .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
            '    .Columns(OptionAll.cd_tp_1_item_no).Visible = False
            '    .Columns(OptionAll.ID).Visible = False
            'End With
            '----------------------------------------------------------------------------
            '++ID put in comment 2015.04.20
            'Call dgvCharges_ShowColumns()

            Call dgvCharges_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    '++ID create this Enum 2015.04.20----
    Private Enum OptionAll
        CHARGE_ID
        DESCRIPTION
        SHORT_DESC
        Always 'always 1(true) - 0(false)
        Never
        cd_tp
        curr_cd
        cd_tp_1_cust_no
        cd_tp_1_item_no
        prc_or_disc_1
        start_dt
        end_dt
        extra_8 'create date
        extra_9 'update date
        extra_15 'user name
        ID
    End Enum
    '------------------------------------

    Private Sub dgvCharges_FillGrid()

        Try
            Dim strSql As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            strSql = _
            " select m.CHARGE_ID, m.DESCRIPTION, m.SHORT_DESC, " &
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '1' THEN 1 ELSE 0 END)) as Always, " & _
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '2' THEN 1 ELSE 0 END)) as Never, " & _
            " o.cd_tp, o.curr_cd, " & _
            " o.cd_tp_1_cust_no, cd_tp_1_item_no, prc_or_disc_1 , o.start_dt, o.end_dt, " & _
            " o.extra_8, o.extra_9, ex.User_Name as extra_15, o.ID " & _
            " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            " left join EXACT_TRAVELER_PERMISSION ex on o.extra_15 = ex.ID " & _
            " where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' " & _
            " and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "

            '------------------------------------------------------------------------------------------------

            dtSearch = db.DataTable(strSql)

            dgvCharges.DataSource = dtSearch
            dgvCharges.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub
    'retrieve User_Name
    Friend Function user_login(ByRef userId As Integer) As String

        Dim dt As DataTable
        Dim strSql As String

        user_login = ""

        If userId.ToString <> "" Then

            strSql = _
                " select User_Name  from EXACT_TRAVELER_PERMISSION where ID = " & userId & ""

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                user_login = dt.Rows(0).Item("User_Name").ToString
            End If

        End If

        Return user_login

    End Function
    'retrieve ID
    Friend Function user_login(ByVal user_name As String) As Integer

        Dim dt As DataTable
        Dim strSql As String

        user_login = 0

        If user_name <> "" Then

            strSql = _
                       " select ID  from EXACT_TRAVELER_PERMISSION where user_name = '" & user_name & "'"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                user_login = dt.Rows(0).Item("ID")
            End If

        End If

        Return user_login

    End Function


#End Region
End Class
