Public Class ucOrders

    Private User_Rights As String = "READONLY"

    Private dtOrders As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private m_Show_All_Customers As Boolean = False ' Done
    Private m_Show_Only_User_Stuff As Boolean = False ' Done
    Private m_Show_Cus_No As Boolean = False ' Done
    Private m_Show_Macola As Boolean = False
    Private m_Show_History As Boolean = True
    Private m_Show_Current As Boolean = True

    Private m_Loading As Boolean = True

    Public Shadows Sub Load()

        Try

            m_Show_All_Customers = True
            m_Show_Cus_No = True

            m_Loading = False

            lblLastXOrders.Visible = True
            txtLastXOrders.Visible = True

            Call SetPermissions()

            If dtOrders Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvOrders)

                dgvSearch.ColumnHeadersHeight = 24

                CreateDisruptionMenu(tsmiDisruption)

            End If

            Call SetButtons()
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

            If dtOrders Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvOrders)

                dgvSearch.ColumnHeadersHeight = 24
                dgvOrders.ColumnHeadersVisible = False

                CreateDisruptionMenu(tsmiDisruption)

            End If

            If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

                Call ClearSearch()

            End If

            Call SetButtons()
            Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetButtons()

        Try

            If m_Show_All_Customers Then
                chkEDI.Visible = True
            Else
                Call SetEDIButton(m_Customer)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetEDIButton(ByRef pCustomer As cCustomer)

        Try

            Dim db As New cDBA()
            Dim dt As DataTable

            Dim strSql As String = _
            "SELECT * FROM MDB_Customer WITH (Nolock) WHERE Cus_No = '" & m_Customer.cmp_code & "' "

            dt = db.DataTable(strSql)
            chkEDI.Visible = (dt.Rows.Count <> 0)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            'dgv.Columns(Orders.Cus_No).Visible = False
            'dgv.Columns(Orders.Nb_Travelers).Visible = False
            'dgv.Columns(Orders.Bill_To_Name).Visible = False
            'dgv.Columns(Orders.LinesShipped).Visible = False
            'dgv.Columns(Orders.NotShipped).Visible = False
            'dgv.Columns(Orders.PartialShipped).Visible = False
            'dgv.Columns(Orders.CompleteShipped).Visible = False
            'dgv.Columns(Orders.Repeat_To).Visible = False
            'dgv.Columns(Orders.Has_Bo).Visible = False
            'dgv.Columns(Orders.BO_Count).Visible = False
            'dgv.Columns(Orders.BO_List_Concat).Visible = False
            'dgv.Columns(Orders.Imprint_List_Concat).Visible = False


            With dgv.Columns

                .Add(DGVTextBoxColumn("Cus_No", "Customer", 70))
                ' ++ID I put in comment 6.1.15
                .Add(DGVTextBoxColumn("OE_Po_No", "PO Number", 110))
                .Add(DGVTextBoxColumn("Ord_Type", "T", 20))
                .Add(DGVTextBoxColumn("Ord_No", "Ord No", 60))
                '.Add(DGVTextBoxColumn("Ord_Dt", "Ord Dt", 90))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("Ord_Dt", "Ord Date", 62))
                Else
                    .Add(DGVTextBoxColumn("Ord_Dt", "Ord Date", 62))
                End If

                .Add(DGVTextBoxColumn("Inv_No", "Inv No", 60))
                '.Add(DGVTextBoxColumn("Inv_Dt", "Inv Dt", 90))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("Inv_Dt", "Inv Date", 60))
                Else
                    .Add(DGVTextBoxColumn("Inv_Dt", "Inv Date", 60))
                End If
                .Add(DGVTextBoxColumn("Repeat_From", "Repeat", 60))
                .Add(DGVTextBoxColumn("RMA_No", "RMA", 60))
                .Add(DGVTextBoxColumn("Ct_Ord_No", "CR No", 60))
                .Add(DGVTextBoxColumn("Ct_Inv_No", "CR Inv", 60))
                .Add(DGVTextBoxColumn("Promise_Dt", "Promise Date", 100))
                '.Add(DGVTextBoxColumn("Shipping_Status", "Ship Status", 100))
                .Add(DGVTextBoxColumn("Shipping_Status", "Ship Status", 100))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("ShippedDate", "ShipDate", 60))
                Else
                    .Add(DGVTextBoxColumn("ShippedDate", "ShpDate", 60))
                End If

                ' .Add(DGVTextBoxColumn("OE_Po_No", "PO Number", 110))

                .Add(DGVTextBoxColumn("EDI_Item", "EDI_Item", 150))
                .Add(DGVCheckBoxColumn("EDI_Order_Fg", "EDI", 30))
                .Add(DGVTextBoxColumn("Imprint_List", "Imprint", 110))
                .Add(DGVTextBoxColumn("Tot_Dollars", "Amount", 70))
                .Add(DGVTextBoxColumn("Tot_Sls_Amt", "Tot Sls Amt", 70))
                .Add(DGVTextBoxColumn("User_def_Fld_4", "Order Contact", 120))
                '.Add(DGVTextBoxColumn("ShippedDate", "Shipped Date", 90))
                .Add(DGVTextBoxColumn("Line_Count", "Lines", 40))
                .Add(DGVTextBoxColumn("BO_List", "No Stock", 80))
                .Add(DGVTextBoxColumn("Extra_1", "Extra_1", 70))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("Extra_2", "Extra_2", 70))
                Else
                    .Add(DGVTextBoxColumn("Extra_2", "Extra_2", 50))
                End If

                '### THOSE FIELDS ARE HIDDEN

                .Add(DGVTextBoxColumn("Imprint_List_Concat", "Imprint", 110))
                .Add(DGVTextBoxColumn("Nb_Travelers", "Nb_Travelers", 50))
                .Add(DGVTextBoxColumn("Bill_To_Name", "Bill_To_Name", 100))
                .Add(DGVTextBoxColumn("LinesShipped", "LinesShipped", 50))
                .Add(DGVTextBoxColumn("NotShipped", "NotShipped", 50))
                .Add(DGVTextBoxColumn("PartialShipped", "PartialShipped", 50))
                .Add(DGVTextBoxColumn("CompleteShipped", "CompleteShipped", 50))
                .Add(DGVTextBoxColumn("Has_Bo", "No Stk", 40))
                .Add(DGVTextBoxColumn("BO_List_Concat", "No Stock", 40))
                .Add(DGVTextBoxColumn("BO_Count", "BO_Count", 40))
                .Add(DGVTextBoxColumn("Repeat_To", "Repeat_To", 70))

            End With

            Dim oCellStyle As New DataGridViewCellStyle()
            oCellStyle.Format = "##,##0.00"
            oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgv.Columns(Orders.Tot_Dollars).DefaultCellStyle = oCellStyle
            dgv.Columns(Orders.Tot_Sls_Amt).DefaultCellStyle = oCellStyle

            'If dgv.Name = "dgvOrders" Then

            oCellStyle = New DataGridViewCellStyle()
            oCellStyle.Format = "MM/dd/yy"
            oCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            dgv.Columns(Orders.Ord_Dt).DefaultCellStyle = oCellStyle
            dgv.Columns(Orders.Inv_Dt).DefaultCellStyle = oCellStyle
            dgv.Columns(Orders.ShippedDate).DefaultCellStyle = oCellStyle

            'dgv.Columns(Orders.Ord_Dt).DefaultCellStyle.Format = "mm/dd/yyyy"
            'dgv.Columns(Orders.Inv_Dt).DefaultCellStyle.Format = "mm/dd/yyyy"
            'dgv.Columns(Orders.ShippedDate).DefaultCellStyle.Format = "mm/dd/yyyy"

            'End If

            dgv.Columns(Orders.OE_Po_No).Frozen = True
            dgv.Columns(Orders.Cus_No).Frozen = True
            dgv.Columns(Orders.Ord_Type).Frozen = True
            dgv.Columns(Orders.Ord_No).Frozen = True
            dgv.Columns(Orders.Ord_Dt).Frozen = True
            dgv.Columns(Orders.Inv_No).Frozen = True

            dgv.Columns(Orders.Cus_No).Visible = m_Show_Cus_No
            dgv.Columns(Orders.Nb_Travelers).Visible = False
            dgv.Columns(Orders.Bill_To_Name).Visible = False
            dgv.Columns(Orders.LinesShipped).Visible = False
            dgv.Columns(Orders.NotShipped).Visible = False
            dgv.Columns(Orders.PartialShipped).Visible = False
            dgv.Columns(Orders.CompleteShipped).Visible = False
            dgv.Columns(Orders.Repeat_To).Visible = False
            dgv.Columns(Orders.Has_Bo).Visible = False
            dgv.Columns(Orders.BO_Count).Visible = False
            dgv.Columns(Orders.BO_List_Concat).Visible = False
            dgv.Columns(Orders.Imprint_List_Concat).Visible = False
            dgv.Columns(Orders.EDI_Item).Visible = False
            dgv.Columns(Orders.EDI_Order_Fg).Visible = False

            'Call dgvOrders_ShowColumns()
            'Call dgvOrders_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub dgvOrders_ShowColumns()

    '    If dgvOrders.Columns.Count = 0 Then Exit Sub

    '    With dgvOrders

    '        .ColumnHeadersHeight = 20
    '        .RowHeadersWidth = 20

    '        .Columns(Orders.Cus_No).Visible = False
    '        '.Columns(Orders.Ord_Type).Visible = False

    '        .Columns(Orders.RMA_No).Visible = chkAIO_CurOrd_RMA.Checked

    '        '.Columns(Orders.Ord_No).Visible = False
    '        '.Columns(Orders.Ord_Dt).Visible = False

    '        .Columns(Orders.Inv_No).Visible = chkAIO_CurOrd_Inv.Checked
    '        .Columns(Orders.Inv_Dt).Visible = chkAIO_CurOrd_Inv.Checked
    '        .Columns(Orders.Bill_To_Name).Visible = chkAIO_CurOrd_Inv.Checked

    '        .Columns(Orders.Ct_Ord_No).Visible = chkAIO_CurOrd_Cre.Checked
    '        .Columns(Orders.Ct_Inv_No).Visible = chkAIO_CurOrd_Cre.Checked

    '        '.Columns(Orders.OE_Po_No).Visible = False
    '        '.Columns(Orders.Tot_Dollars).Visible = False
    '        .Columns(Orders.Tot_Sls_Amt).Visible = False
    '        '.Columns(Orders.Shipping_Status).Visible = False

    '        .Columns(Orders.User_def_Fld_4).Visible = False
    '        .Columns(Orders.Nb_Travelers).Visible = False
    '        .Columns(Orders.LinesShipped).Visible = False
    '        .Columns(Orders.NotShipped).Visible = False
    '        .Columns(Orders.PartialShipped).Visible = False
    '        .Columns(Orders.CompleteShipped).Visible = False

    '        .Columns(Orders.ShippedDate).Visible = (chkAIO_CurOrd_Ord.Checked Or chkAIO_CurOrd_Inv.Checked)

    '        .Columns(Orders.Line_Count).Visible = False
    '        '.Columns(Orders.Has_Bo).Visible = False

    '        .Columns(Orders.BO_Count).Visible = chkAIO_CurOrd_BOOnly.Checked

    '        .Columns(Orders.Repeat_From).Visible = chkAIO_CurOrd_RepeatsOnly.Checked
    '        .Columns(Orders.Repeat_To).Visible = chkAIO_CurOrd_RepeatsOnly.Checked

    '        .Columns(Orders.Extra_1).Visible = False
    '        .Columns(Orders.Extra_2).Visible = False

    '    End With

    'End Sub

    Private Sub ClearSearch()

    End Sub

    Private Sub FillGrid()

        Dim strSql As String

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If Not m_Show_All_Customers Then
                'EXEC DBO.EXACT_TRAVELER_CUSTOMER_HISTORY_20140130ion
                'strSql = "EXEC DBO.EXACT_TRAVELER_CUSTOMER_HISTORY_20131022 '" & m_Customer.cmp_code.Trim & "', " & txtAIO_CurOrd_LastDays.Text.ToString
                'strSql = "EXEC DBO.EXACT_TRAVELER_CUSTOMER_HISTORY_20140130 '" & m_Customer.cmp_code.Trim & "', " & txtAIO_CurOrd_LastDays.Text.ToString
                strSql = "EXEC DBO.EXACT_TRAVELER_CUSTOMER_HISTORY_20150106 '" & m_Customer.cmp_code.Trim & "', " & txtAIO_CurOrd_LastDays.Text.ToString

                dtOrders = db.DataTable(strSql)

                dgvOrders.DataSource = dtOrders
                dgvOrders.AllowUserToAddRows = False

            End If


            strSql = "SELECT " & _
            "CAST('' AS CHAR(20)) AS Cus_No, " & _
            "CAST('' AS CHAR(25)) AS OE_Po_No, " & _
            "CAST('' AS CHAR(1)) AS Ord_Type, " & _
            "CAST('' AS CHAR(8)) AS Ord_No, " & _
            "CAST(NULL AS DATETIME) AS Ord_Dt, " & _
            "CAST('' AS CHAR(8)) AS Inv_No, " & _
            "CAST(NULL AS DATETIME) AS Inv_Dt, " & _
            "CAST('' AS CHAR(8)) AS Repeat_From, " & _
            "CAST('' AS VARCHAR(1)) AS RMA_No, " & _
            "CAST('' AS VARCHAR(8)) AS Ct_Ord_No, " & _
            "CAST('' AS CHAR(8)) AS Ct_Inv_No, " & _
            "CAST('' AS VARCHAR(30)) AS Promise_DT, " & _
            "CAST('' AS VARCHAR(40)) AS Shipping_Status, " & _
            "CAST(NULL AS DATETIME) AS ShippedDate, " & _
            "CAST('' AS VARCHAR(30)) AS EDI_Item, " & _
            "CAST(0 AS BIT) AS EDI_Order_Fg, " & _
            "CAST('' AS VARCHAR(60)) AS Imprint_List, " & _
            "CAST(NULL AS DECIMAL(16, 2)) AS Tot_Dollars, " & _
            "CAST(NULL AS DECIMAL(16, 2)) AS Tot_Sls_Amt, " & _
            "CAST('' AS CHAR(30)) AS User_def_Fld_4, " & _
            "CAST(NULL AS INT) AS Line_Count, " & _
            "CAST('' AS VARCHAR(60)) AS BO_List, " & _
            "CAST('' AS VARCHAR(1)) AS Extra_1, " & _
            "CAST('' AS VARCHAR(1)) AS Extra_2, " & _
            "CAST('' AS VARCHAR(MAX)) AS Imprint_List_Concat, " & _
            "CAST(NULL AS INT) AS Nb_Travelers, " & _
            "CAST('' AS CHAR(40)) AS Bill_To_Name, " & _
            "CAST(NULL AS INT) AS LinesShipped, " & _
            "CAST('' AS VARCHAR(1)) AS NotShipped, " & _
            "CAST('' AS VARCHAR(1)) AS PartialShipped, " & _
            "CAST('' AS VARCHAR(1)) AS CompleteShipped, " & _
            "CAST('' AS CHAR(1)) AS Has_Bo, " & _
            "CAST('' AS VARCHAR(MAX)) AS BO_List_Concat, " & _
            "CAST('' AS VARCHAR(6)) AS BO_Count, " & _
            "CAST('' AS CHAR(8)) AS Repeat_To "

            dtSearch = db.DataTable(strSql)

            dgvSearch.DataSource = dtSearch
            dgvSearch.AllowUserToAddRows = False

            '   Call ApplyFilters()
            ' Call SetToolTips()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub ApplyFiltersOldWorking()

    '    Try

    '        If dtOrders Is Nothing Then Exit Sub

    '        'txtLoading.Visible = True
    '        'Me.Refresh()

    '        Dim strFilter As String = ""
    '        Dim strSubFilter As String = ""

    '        If Not (chkAIO_CurOrd_Cre.Checked) Then strFilter = strFilter & " (Ord_type <> 'C')  AND "
    '        If Not (chkAIO_CurOrd_Quo.Checked) Then strFilter = strFilter & " (Ord_type <> 'Q')  AND "
    '        If Not (chkAIO_CurOrd_Ord.Checked) Then strFilter = strFilter & " (Ord_type <> 'O')  AND "
    '        If Not (chkAIO_CurOrd_RMA.Checked) Then strFilter = strFilter & " (Ord_type <> 'RMA')  AND "
    '        If Not (chkAIO_CurOrd_Inv.Checked) Then strFilter = strFilter & " (Ord_type <> 'I')  AND "
    '        If Not (chkAIO_CurOrd_NotShip.Checked) Then strFilter = strFilter & " (NotShipped <> 'X')  AND "
    '        If Not (chkAIO_CurOrd_PartShip.Checked) Then strFilter = strFilter & " (PartialShipped <> 'X')  AND "
    '        If Not (chkAIO_CurOrd_Ship.Checked) Then strFilter = strFilter & " (CompleteShipped <> 'X')  AND "

    '        If chkAIO_CurOrd_BOOnly.Checked Then strFilter = strFilter & " (Has_BO <> ' ')  AND "

    '        ' On doit contruite le Repeat a la fin, on ne peut pas mettre de OR et de AND dans la meme condition
    '        ' On doit alors completement les separer... crissement mauvais, mais bon...
    '        If chkAIO_CurOrd_RepeatsOnly.Checked Then
    '            If strFilter = "" Then
    '                strFilter = " (Repeat_From <> '' OR Repeat_To <> '')  AND "
    '            Else
    '                strSubFilter = Mid(strFilter, 1, Len(strFilter) - 4)
    '                strFilter = "(" & strSubFilter & " AND Repeat_From <> '') OR (" & strSubFilter & " AND Repeat_To <> '')  AND "
    '            End If
    '        End If

    '        'dgvOrders.
    '        'datCustHistory.Recordset.Filter = ""
    '        'datCustHistory.Recordset.Requery()

    '        If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

    '        m_GlobalFilter = strFilter
    '        dtOrders.DefaultView.RowFilter = strFilter

    '        'If strFilter <> "" Then
    '        '    'datCustHistory.Recordset.Filter = Mid(strFilter, 1, Len(strFilter) - 4)
    '        'Else
    '        '    dtOrders.DefaultView.RowFilter = strFilter
    '        'End If

    '        'Call SetDgCustHistoryColumns()

    '        'txtLoading.Visible = False


    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub SetToolTips()

        Try
            Dim strTooltip As String = ""
            Dim strValue As String = ""
            Dim strSql As String = ""

            For Each dgvRow As DataGridViewRow In dgvOrders.Rows

                strValue = dgvRow.Cells(Orders.BO_List).Value.ToString.Trim
                If strValue.Length >= 8 Then
                    If strValue.Substring(strValue.Length - 8, 8) = "ITEMS BO" Then

                        strTooltip = ""
                        Dim dtBO As DataTable
                        strSql = "SELECT * FROM DBO.MDB_BO_Count('" & dgvRow.Cells(Orders.Ord_No).Value & "', 0)"
                        dtBO = db.DataTable(strSql)
                        If dtBO.Rows.Count <> 0 Then
                            For Each dtRow As DataRow In dtBO.Rows
                                strTooltip &= dtRow.Item("Item_No").ToString & Environment.NewLine
                            Next
                        End If
                        dgvOrders.Rows(dgvRow.Index).Cells(Orders.BO_List).ToolTipText = strTooltip
                    End If
                End If

                strValue = dgvRow.Cells(Orders.Imprint_List).Value.ToString.Trim
                If strValue.Length >= 7 Then
                    If strValue.Substring(0, 7) = "MULTI (" Then

                        strTooltip = ""
                        Dim dtImprint As DataTable
                        strSql = "SELECT * FROM DBO.MDB_Imprint_Count('" & dgvRow.Cells(Orders.Ord_No).Value & "', 0)"
                        dtImprint = db.DataTable(strSql)
                        If dtImprint.Rows.Count <> 0 Then
                            For Each dtRow As DataRow In dtImprint.Rows
                                strTooltip &= dtRow.Item("Imprint_Item").ToString & Environment.NewLine
                            Next
                        End If
                        dgvOrders.Rows(dgvRow.Index).Cells(Orders.Imprint_List).ToolTipText = strTooltip

                    End If
                End If


                strValue = dgvRow.Cells(Orders.Promise_Dt).Value.ToString.Trim
                If strValue = "MULTI DATES" Then

                    strTooltip = ""
                    Dim dtDates As DataTable
                    strSql = _
                    "SELECT		DISTINCT Ord_No, Promise_Dt, COUNT(Line_Seq_No) AS Qty_Lines " & _
                    "FROM		OEORDLIN_SQL WITH (NOLOCK) " & _
                    "WHERE		Ord_No = '" & dgvRow.Cells(Orders.Ord_No).Value & "' AND Ord_Type = 'O' " & _
                    "GROUP BY	Ord_No, Promise_Dt " & _
                    "ORDER BY	Ord_No, Promise_Dt "

                    '"SELECT DISTINCT PROMISE_DT FROM OEORDLIN_SQL WHERE ORD_NO = '" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "' AND ORD_TYPE = 'O' "
                    dtDates = db.DataTable(strSql)
                    If dtDates.Rows.Count <> 0 Then
                        For Each dtRow As DataRow In dtDates.Rows
                            strTooltip &= CDate(dtRow.Item("PROMISE_DT")).ToShortDateString & " (" & dtRow.Item("Qty_Lines").ToString & " LINES)" & Environment.NewLine
                        Next
                    Else
                        strSql = _
                        "SELECT		DISTINCT Ord_No, Promise_Dt, COUNT(Line_Seq_No) AS Qty_Lines " & _
                        "FROM		OELINHST_SQL WITH (NOLOCK) " & _
                        "WHERE		Ord_No = '" & dgvRow.Cells(Orders.Ord_No).Value & "' AND Ord_Type = 'O' " & _
                        "GROUP BY	Ord_No, Promise_Dt " & _
                        "ORDER BY	Ord_No, Promise_Dt "
                        dtDates = db.DataTable(strSql)
                        If dtDates.Rows.Count <> 0 Then
                            For Each dtRow As DataRow In dtDates.Rows
                                strTooltip &= CDate(dtRow.Item("PROMISE_DT")).ToShortDateString & " (" & dtRow.Item("Qty_Lines").ToString & " LINES)" & Environment.NewLine
                            Next
                        End If
                    End If
                    dgvOrders.Rows(dgvRow.Index).Cells(Orders.Promise_Dt).ToolTipText = strTooltip

                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ApplyFilters()

        Dim strFilter As String = ""
        Dim strSubFilter As String = ""

        Try

            If dtOrders Is Nothing And Not (m_Show_All_Customers) Then Exit Sub

            SetFilters(strFilter, strSubFilter)

            m_GlobalFilter = strFilter
            SetSearchColumnsFilter(m_SearchFilter)

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            If m_Show_All_Customers Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim strQueryCurrent As String = ""
                Dim strQueryHistory As String = ""
                Dim strQueryRMA As String = ""

                SetOrderQueries(strQueryCurrent, strQueryHistory, strQueryRMA)

                If strFilter <> String.Empty Then
                    strQueryCurrent &= strFilter & " UNION "
                    strQueryHistory &= strFilter & " UNION "
                    strQueryRMA &= strFilter
                End If

                dtOrders = db.DataTable(strQueryCurrent & strQueryHistory & strQueryRMA)

                dgvOrders.DataSource = dtOrders
                dgvOrders.AllowUserToAddRows = False

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

            Else

                dtOrders.DefaultView.RowFilter = strFilter
                dgvOrders.Refresh()

            End If

            tssRecordCount.Text = "Records: " & dgvOrders.Rows.Count.ToString

            Call SetToolTips()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub ApplyFilters()

    '    Try

    '        If dtOrders Is Nothing Then Exit Sub

    '        Dim strFilter As String = ""
    '        Dim strSubFilter As String = ""

    '        SetFilters(strFilter, strSubFilter)

    '        m_GlobalFilter = strFilter
    '        SetSearchColumnsFilter(m_SearchFilter)

    '        strFilter = ""

    '        If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
    '        If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
    '        If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

    '        dtOrders.DefaultView.RowFilter = strFilter
    '        dgvOrders.Refresh()

    '        tssRecordCount.Text = "Records: " & dgvOrders.Rows.Count.ToString

    '        Call SetToolTips()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    'Private Sub ApplyFilters()

    '    Try

    '        If dtOrders Is Nothing Then Exit Sub

    '        Dim strFilter As String = ""
    '        Dim strSubFilter As String = ""

    '        If (chkAIO_CurOrd_Cre.Checked) Then strFilter = strFilter & " (Ord_type = 'C')  OR  "
    '        If (chkAIO_CurOrd_Quo.Checked) Then strFilter = strFilter & " (Ord_type = 'Q')  OR  "
    '        If (chkAIO_CurOrd_Ord.Checked) Then strFilter = strFilter & " (Ord_type = 'O')  OR  "
    '        If (chkAIO_CurOrd_RMA.Checked) Then strFilter = strFilter & " (Ord_type = 'RMA')  OR  "
    '        If (chkAIO_CurOrd_Inv.Checked) Then strFilter = strFilter & " (Ord_type = 'I')  OR  "

    '        If strFilter <> "" Then strFilter = "( " & strFilter.Substring(1, strFilter.Length - 5).Trim & " ) "
    '        If (chkAIO_CurOrd_Inv.Checked) Then strFilter = "( " & strFilter & " OR Inv_No <> '' ) "
    '        If strFilter <> "" Then strFilter &= " AND "

    '        If Not (chkAIO_CurOrd_NotShip.Checked) Then strFilter = strFilter & " (NotShipped <> 'X')  AND "
    '        If Not (chkAIO_CurOrd_PartShip.Checked) Then strFilter = strFilter & " (PartialShipped <> 'X')  AND "
    '        If Not (chkAIO_CurOrd_Ship.Checked) Then strFilter = strFilter & " (CompleteShipped <> 'X')  AND "

    '        If chkAIO_CurOrd_BOOnly.Checked Then strFilter = strFilter & " (Has_BO <> ' ')  AND "

    '        ' On doit contruite le Repeat a la fin, on ne peut pas mettre de OR et de AND dans la meme condition
    '        ' On doit alors completement les separer... crissement mauvais, mais bon...
    '        If chkAIO_CurOrd_RepeatsOnly.Checked Then
    '            If strFilter = "" Then
    '                strFilter = " (Repeat_From <> '' OR Repeat_To <> '')  AND "
    '            Else
    '                strSubFilter = Mid(strFilter, 1, Len(strFilter) - 4)
    '                strFilter = "(" & strSubFilter & " AND Repeat_From <> '') OR (" & strSubFilter & " AND Repeat_To <> '')  AND "
    '            End If
    '        End If

    '        If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

    '        m_GlobalFilter = strFilter
    '        m_SearchFilter = GetSearchColumnsFilter()

    '        strFilter = ""

    '        If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
    '        If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
    '        If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

    '        dtOrders.DefaultView.RowFilter = strFilter
    '        dgvOrders.Refresh()

    '        tssRecordCount.Text = "Records: " & dgvOrders.Rows.Count.ToString

    '        Call SetToolTips()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub SetOrderQueries(ByRef strQueryCurrent As String, ByRef strQueryHistory As String, ByRef strQueryRMA As String)

        Dim strFields As String = _
        "Cus_No, Ord_Type, Ord_No, Ord_Dt, Inv_No, Inv_Dt, Repeat_From, RMA_No, " & _
        "CT_Ord_No, CT_Inv_No, Promise_Dt, Shipping_Status, ShippedDate,OE_PO_No,  " & _
        "EDI_Item, EDI_Order_Fg, Imprint_List, Tot_Dollars, Tot_Sls_Amt, User_Def_Fld_4, Line_Count, " & _
        "BO_List, Extra_1, Extra_2, Imprint_List_Concat, Nb_Travelers, Bill_To_Name, " & _
        "LinesShipped, NotShipped, PartialShipped, CompleteShipped, Has_BO, " & _
        "BO_List_Concat, BO_Count, Repeat_To "

        strQueryCurrent = "SELECT " & strFields & " FROM MDB_CUS_FILE_ORDER_CURRENT_VIEW "
        strQueryHistory = "SELECT " & strFields & " FROM MDB_CUS_FILE_ORDER_HISTORY_VIEW "
        strQueryRMA = "SELECT " & strFields & " FROM MDB_CUS_FILE_ORDER_RMA_VIEW "

    End Sub

    Private Sub SetFilters(ByRef strFilter As String, ByRef strSubFilter As String)

        If (chkAIO_CurOrd_Cre.Checked) Then strFilter = strFilter & " (Ord_type = 'C')  OR  "
        If (chkAIO_CurOrd_Quo.Checked) Then strFilter = strFilter & " (Ord_type = 'Q')  OR  "
        If (chkAIO_CurOrd_Ord.Checked) Then strFilter = strFilter & " (Ord_type = 'O')  OR  "
        If (chkAIO_CurOrd_RMA.Checked) Then strFilter = strFilter & " (Ord_type = 'RMA')  OR  "
        If (chkAIO_CurOrd_Inv.Checked) Then strFilter = strFilter & " (Ord_type = 'I')  OR  "

        If strFilter <> "" Then strFilter = "( " & strFilter.Substring(1, strFilter.Length - 5).Trim & " ) "
        If (chkAIO_CurOrd_Inv.Checked) Then strFilter = "( " & strFilter & " OR Inv_No <> '' ) "
        If strFilter <> "" Then strFilter &= " AND "

        If Not (chkAIO_CurOrd_NotShip.Checked) Then strFilter = strFilter & " (NotShipped <> 'X')  AND "
        If Not (chkAIO_CurOrd_PartShip.Checked) Then strFilter = strFilter & " (PartialShipped <> 'X')  AND "
        If Not (chkAIO_CurOrd_Ship.Checked) Then strFilter = strFilter & " (CompleteShipped <> 'X')  AND "

        If chkAIO_CurOrd_BOOnly.Checked Then strFilter = strFilter & " (Has_BO <> ' ')  AND "
        If chkEDI.Checked Then strFilter = strFilter & " (EDI_Order_Fg = 1)  AND "

        ' On doit contruite le Repeat a la fin, on ne peut pas mettre de OR et de AND dans la meme condition
        ' On doit alors completement les separer... crissement mauvais, mais bon...
        If chkAIO_CurOrd_RepeatsOnly.Checked Then
            If strFilter = "" Then
                strFilter = " (Repeat_From <> '' OR Repeat_To <> '')  AND "
            Else
                strSubFilter = Mid(strFilter, 1, Len(strFilter) - 4)
                strFilter = "(" & strSubFilter & " AND Repeat_From <> '') OR (" & strSubFilter & " AND Repeat_To <> '')  AND "
            End If
        End If

        If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

    End Sub

    Private Sub SetSearchColumnsFilter(ByRef m_SearchFilter As String)

        m_SearchFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "Cus_No", "Ord_Type", "RMA_No", "Ord_No", "Inv_No", "Ct_Ord_No", "Ct_Inv_No", _
                     "OE_Po_No", "Imprint_List", "Imprint_List_Concat", "Bill_To_Name", "Shipping_Status", _
                     "User_def_Fld_4", "NotShipped", "PartialShipped", "CompleteShipped", "Has_Bo", _
                     "BO_List", "BO_List_Concat", "BO_Count", "Repeat_From", "Repeat_To", "Extra_1", "Extra_2", "EDI_Item" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If m_SearchFilter.Trim <> "" Then m_SearchFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        m_SearchFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "Ord_Dt", "Inv_Dt", "ShippedDate" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        If m_SearchFilter.Trim <> "" Then m_SearchFilter &= " AND "

                        m_SearchFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
                                                   & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "
                        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    End If

                Case "Tot_Dollars", "Tot_Sls_Amt", "Nb_Travelers", "LinesShipped", "Line_Count" ' Numeric

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                            If m_SearchFilter.Trim <> "" Then m_SearchFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                            m_SearchFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If
            End Select

        Next oColumn

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvSearch.CellBeginEdit

        Try
            Select Case e.ColumnIndex

                Case Orders.Cus_No
                    e.Cancel = True

                Case Orders.Ord_Type
                    e.Cancel = True

                Case Orders.RMA_No

                Case Orders.Ord_No

                Case Orders.Ord_Dt

                Case Orders.Inv_No

                Case Orders.Inv_Dt

                Case Orders.Ct_Ord_No

                Case Orders.Ct_Inv_No

                Case Orders.OE_Po_No

                Case Orders.Imprint_List

                Case Orders.Imprint_List_Concat

                Case Orders.Tot_Dollars

                Case Orders.Bill_To_Name

                Case Orders.Tot_Sls_Amt

                Case Orders.Promise_Dt
                    e.Cancel = True

                Case Orders.Shipping_Status
                    e.Cancel = True

                Case Orders.User_def_Fld_4

                Case Orders.Nb_Travelers

                Case Orders.LinesShipped

                Case Orders.NotShipped
                    e.Cancel = True

                Case Orders.PartialShipped
                    e.Cancel = True

                Case Orders.CompleteShipped
                    e.Cancel = True

                Case Orders.ShippedDate

                Case Orders.Line_Count

                Case Orders.Has_Bo
                    e.Cancel = True

                Case Orders.BO_List

                Case Orders.BO_List_Concat

                Case Orders.BO_Count
                    e.Cancel = True

                Case Orders.Repeat_From

                Case Orders.Repeat_To

                Case Orders.Extra_1

                Case Orders.Extra_2

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub txtAIO_CurOrd_LastDays_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAIO_CurOrd_LastDays.Validating

        Try

            Dim strValue As String = txtAIO_CurOrd_LastDays.Text.Trim

            If IsNumeric(strValue) Then

                If Not (txtAIO_CurOrd_LastDays.OldValue.ToString.Trim = txtAIO_CurOrd_LastDays.Text.ToString.Trim) Then

                    Call FillGrid()

                End If

            Else

                MsgBox("Value must be numeric.")
                e.Cancel = True

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub rbSearch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOrSearch.CheckedChanged, rbAndSearch.CheckedChanged

        Call ApplyFilters()

    End Sub

    Private Sub CheckboxOptions_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _
        chkAIO_CurOrd_BOOnly.CheckedChanged, chkAIO_CurOrd_Cre.CheckedChanged, _
        chkAIO_CurOrd_Inv.CheckedChanged, chkAIO_CurOrd_NotShip.CheckedChanged, _
        chkAIO_CurOrd_Ord.CheckedChanged, chkAIO_CurOrd_PartShip.CheckedChanged, _
        chkAIO_CurOrd_Quo.CheckedChanged, chkAIO_CurOrd_RepeatsOnly.CheckedChanged, _
        chkAIO_CurOrd_RMA.CheckedChanged, chkAIO_CurOrd_Ship.CheckedChanged

        Call ApplyFilters()
        ', chkEDI.CheckedChanged'
    End Sub

    Private Sub chkEDI_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _
        chkEDI.CheckedChanged

        Call ApplyFilters()
        dgvSearch.Columns(Orders.EDI_Item).Visible = chkEDI.Checked
        dgvOrders.Columns(Orders.EDI_Item).Visible = chkEDI.Checked

    End Sub

    Private Sub dgvSearch_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Call ApplyFilters()

    End Sub

    Private Sub dgvSearch_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        ' If dgvSearch. <> -1 Then
        '  dgvSearch.BeginEdit(True)
        '  End If

    End Sub

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvOrders.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then
                dgv = dgvOrders
            Else
                dgv = dgvSearch
            End If
            Debug.Print(e.Column.Name & " --- " & e.Column.Width)
            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvOrders.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOrders_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOrders.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvOrders_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvOrders.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Return ' Open element
                    Call Menu_Open()

                Case Keys.Insert ' Insert a new element
                    'Call Menu_New()

                Case Keys.Delete ' Delete current element
                    'Call Menu_Delete()

                Case Keys.F5
                    'Call Menu_Refresh()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOrders_MouseHover(sender As Object, e As System.EventArgs) Handles dgvOrders.MouseHover

        Try
            Dim grvScreenLocation As Point = dgvOrders.PointToScreen(dgvOrders.Location)
            Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + dgvOrders.Left
            Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + dgvOrders.Top
            Dim hit As DataGridView.HitTestInfo = dgvOrders.HitTest(tempX, tempY)
            Dim iRow As Integer = hit.RowIndex
            Dim iCell As Integer = hit.ColumnIndex
            Dim strSql As String = ""
            Dim strTooltip As String = ""

            If iRow = (-1) Or iCell = (-1) Then Exit Sub

            'Debug.Print("HOVER : " & dgvOrders.Rows(iRow).Cells(iCell).ToolTipText)

            'Select Case iCell
            '    Case Orders.BO_List
            '        Dim strImprint As String = dgvOrders.Rows(iRow).Cells(iCell).Value.ToString.Trim
            '        If strImprint.Length >= 8 Then
            '            If strImprint.Substring(strImprint.Length - 8, 8) = "ITEMS BO" Then
            '                If dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = "" Then
            '                    Dim dtBO As DataTable
            '                    strSql = "SELECT * FROM DBO.MDB_BO_Count('" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "', 0)"
            '                    dtBO = db.DataTable(strSql)
            '                    If dtBO.Rows.Count <> 0 Then
            '                        For Each dtRow As DataRow In dtBO.Rows
            '                            strTooltip &= dtRow.Item("Item_No").value.ToString & Environment.NewLine
            '                        Next
            '                    End If
            '                    dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = strTooltip
            '                End If
            '            End If
            '        End If

            '    Case Orders.Imprint_List
            '        Dim strImprint As String = dgvOrders.Rows(iRow).Cells(iCell).Value.ToString.Trim
            '        If strImprint.Length >= 7 Then
            '            If strImprint.Substring(0, 7) = "MULTI (" Then
            '                If dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = "" Then
            '                    Dim dtImprint As DataTable
            '                    strSql = "SELECT * FROM DBO.MDB_Imprint_Count('" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "', 0)"
            '                    dtImprint = db.DataTable(strSql)
            '                    If dtImprint.Rows.Count <> 0 Then
            '                        For Each dtRow As DataRow In dtImprint.Rows
            '                            strTooltip &= dtRow.Item("Imprint_Item").value.ToString & Environment.NewLine
            '                        Next
            '                    End If
            '                    dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = strTooltip
            '                End If
            '            End If
            '        End If

            '    Case Orders.Promise_Dt
            '        Dim strImprint As String = dgvOrders.Rows(iRow).Cells(iCell).Value.ToString.Trim
            '        If strImprint = "MULTI DATES" Then
            '            If dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = "" Then
            '                Dim dtDates As DataTable
            '                strSql = _
            '                "SELECT		DISTINCT Ord_No, Promise_Dt, COUNT(Line_Seq_No) AS Qty_Lines " & _
            '                "FROM		OEORDLIN_SQL WITH (NOLOCK) " & _
            '                "WHERE		Ord_No = '" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "' AND Ord_Type = 'O' " & _
            '                "GROUP BY	Ord_No, Promise_Dt " & _
            '                "ORDER BY	Ord_No, Promise_Dt "

            '                '"SELECT DISTINCT PROMISE_DT FROM OEORDLIN_SQL WHERE ORD_NO = '" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "' AND ORD_TYPE = 'O' "
            '                dtDates = db.DataTable(strSql)
            '                If dtDates.Rows.Count <> 0 Then
            '                    For Each dtRow As DataRow In dtDates.Rows
            '                        strTooltip &= CDate(dtRow.Item("PROMISE_DT")).ToShortDateString & " (" & dtRow.Item("Qty_Lines").ToString & " LINES)" & Environment.NewLine
            '                    Next
            '                Else
            '                    strSql = _
            '                    "SELECT		DISTINCT Ord_No, Promise_Dt, COUNT(Line_Seq_No) AS Qty_Lines " & _
            '                    "FROM		OELINHST_SQL WITH (NOLOCK) " & _
            '                    "WHERE		Ord_No = '" & dgvOrders.Rows(iRow).Cells(Orders.Ord_No).Value & "' AND Ord_Type = 'O' " & _
            '                    "GROUP BY	Ord_No, Promise_Dt " & _
            '                    "ORDER BY	Ord_No, Promise_Dt "
            '                    dtDates = db.DataTable(strSql)
            '                    If dtDates.Rows.Count <> 0 Then
            '                        For Each dtRow As DataRow In dtDates.Rows
            '                            strTooltip &= CDate(dtRow.Item("PROMISE_DT")).ToShortDateString & " (" & dtRow.Item("Qty_Lines").ToString & " LINES)" & Environment.NewLine
            '                        Next
            '                    End If
            '                End If
            '                dgvOrders.Rows(iRow).Cells(iCell).ToolTipText = strTooltip
            '            End If
            '        End If
            'End Select

            'RemoveHandler dgvOrders.MouseHover, AddressOf dgvOrders_MouseHover ' TextBox_TextChanged
            'dgvSearch.Focus()
            'AddHandler dgvOrders.MouseHover, AddressOf dgvOrders_MouseHover ' TextBox_TextChanged

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOrders_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvOrders.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvOrders.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "Cus_No", "Ord_Type", "RMA_No", "Ord_No", "Inv_No", "Ct_Ord_No", "Ct_Inv_No", _
                     "OE_Po_No", "Imprint_List", "Imprint_List_Concat", "Bill_To_Name", "Shipping_Status", _
                     "User_def_Fld_4", "NotShipped", "PartialShipped", "CompleteShipped", "Has_Bo", _
                     "BO_List", "BO_List_Concat", "BO_Count", "Repeat_From", "Repeat_To", "Extra_1", "Extra_2", "EDI_Item"  ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "Ord_Dt", "Inv_Dt", "ShippedDate" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    End If

                Case "Tot_Dollars", "Tot_Sls_Amt", "Nb_Travelers", "LinesShipped", "Line_Count" ' Numeric

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
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
            oColumn = dgvOrders.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder
            'dgvOrders.Sort(oSortOrder)
            '        MsgBox("1")
            If oSortOrder = 1 Then
                dgvOrders.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvOrders.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        'dgvOrders.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
        'If oSortOrder = System.ComponentModel.ListSortDirection.Ascending Then
        '    dgvOrders.Sort(System.ComponentModel.ListSortDirection.Ascending)
        'Else
        '    dgvOrders.Sort(System.ComponentModel.ListSortDirection.Descending)
        'End If
        'dgvOrders.Sort(dgvOrders.Columns(dgvSearch.CurrentCell.OwningColumn), System.ComponentModel.ListSortDirection.Ascending)
        'dgvOrders.SortedColumn(
    End Sub


    Private Sub dgvSearch_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.ColumnHeaderMouseClick

        Try
            Dim oColumn As DataGridViewColumn
            oColumn = dgvSearch.Columns(e.ColumnIndex)

            Select Case oColumn.Index

                Case Orders.Inv_Dt, Orders.Ord_Dt, Orders.ShippedDate

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

        'Try

        '    Dim oColumn As DataGridViewColumn
        '    oColumn = dgvOrders.Columns(e.ColumnIndex)

        '    Select Case oColumn.Index

        '        Case Orders.Inv_Dt, Orders.Ord_Dt, Orders.ShippedDate

        '            ' There is a glitch in the .NET enums... 
        '            ' Ascending is 0 in ListDirection and 1 in SortOrder (0 is none in sort order)
        '            Dim oSortOrder As System.ComponentModel.ListSortDirection
        '            oSortOrder = System.ComponentModel.ListSortDirection.Ascending

        '            If dgvOrders.SortOrder = 1 Then
        '                oSortOrder = System.ComponentModel.ListSortDirection.Descending
        '            End If

        '            dgvOrders.Sort(oColumn, oSortOrder)

        '    End Select

        'Catch er As Exception
        '    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        'End Try

    End Sub

    Private Sub Menu_Open()

    End Sub

    Private Sub SetPermissions()

        SetUser_Rights(User_Rights, Me.Tag)

        Select Case User_Rights
            Case "READWRITE"
                'tsbNew.Enabled = True
                'tsbDelete.Enabled = True

            Case "SUPERUSER"
                'tsbNew.Enabled = True
                'tsbDelete.Enabled = True

            Case "READONLY"
                'tsbNew.Enabled = False
                'tsbDelete.Enabled = False

        End Select

    End Sub

    Private Enum Orders

        '++ID Added OE_Po_No 1.6.15

        Cus_No ' Visible = False
        OE_Po_No
        Ord_Type
        Ord_No
        Ord_Dt
        Inv_No
        Inv_Dt
        Repeat_From
        RMA_No
        Ct_Ord_No
        Ct_Inv_No
        Promise_Dt
        Shipping_Status
        ShippedDate
        'Shipping_Status

        '++ID 1.6.15 put in comment
        'OE_Po_No
        EDI_Item ' Visible = False
        EDI_Order_Fg ' Visible = False
        Imprint_List
        Tot_Dollars
        Tot_Sls_Amt
        User_def_Fld_4
        Line_Count
        BO_List
        Extra_1
        Extra_2
        Imprint_List_Concat ' Visible = False
        Nb_Travelers ' Visible = False
        Bill_To_Name ' Visible = False
        LinesShipped ' Visible = False
        NotShipped ' Visible = False
        PartialShipped ' Visible = False
        CompleteShipped ' Visible = False
        Has_Bo ' Visible = False
        BO_List_Concat ' Visible = False
        BO_Count ' Visible = False
        Repeat_To ' Visible = False

    End Enum

    Public Sub CreateDisruptionMenu(ByRef oMenu As ToolStripMenuItem)

        Try
            Dim db As New cDBA()
            Dim dt As DataTable
            Dim strSql As String
            strSql = "SELECT DISRUPTION_ID, DISRUPTION_DESC FROM MDB_CFG_DISRUPTION WHERE ISNULL(SHOW_CSR, 0) = 1  ORDER BY DISRUPTION_GROUP, SORT_ORDER"
            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For Each dtRow As DataRow In dt.Rows
                    Dim oMenuItem As New ToolStripMenuItem
                    oMenuItem.Name = "dyntsmiDisruption" & oMenu.DropDownItems.Count
                    oMenuItem.Text = dtRow.Item("DISRUPTION_DESC").ToString.Trim
                    oMenuItem.Tag = dtRow.Item("DISRUPTION_ID").ToString.Trim
                    AddHandler oMenuItem.Click, AddressOf DisruptionMenuSelection
                    oMenu.DropDownItems.Add(oMenuItem)
                Next
            End If

        Catch er As Exception
            MsgBox("Error in cMDB_CUS_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    ' Handler for click
    Private Sub DisruptionMenuSelection(sender As ToolStripMenuItem, e As System.EventArgs)

        Try
            Dim oFeedback As New cMDB_CUS_FEEDBACK
            oFeedback.Cus_No = m_Customer.cmp_code.Trim
            oFeedback.Ord_No = dgvOrders.CurrentRow.Cells(Orders.Ord_No).Value
            oFeedback.Disruption_ID = CInt(sender.Tag)
            oFeedback.Save()

        Catch er As Exception
            MsgBox("Error in cMDB_CUS_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public ReadOnly Property Current_Ord_No() As String
        Get
            Current_Ord_No = dgvOrders.CurrentRow.Cells(Orders.Ord_No).Value.ToString
        End Get
    End Property

End Class
