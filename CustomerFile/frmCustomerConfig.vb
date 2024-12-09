Public Class frmCustomerConfig

    Private User_Rights As String = "READONLY"

    Private dtCustomers As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("CUS_NO", "Cus No", 60))
                .Add(DGVTextBoxColumn("CUS_NAME", "Customer Name", 200))
                .Add(DGVCheckBoxColumn("HAS_PAPER_PROOF", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_EXACT_QTY", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_PRODUCT_PROOF", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_LESS_THAN_MIN", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_VIRTUAL_PROOF", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_SET_UP", "Has Setup", 75))
                .Add(DGVCheckBoxColumn("HAS_COLOR_MATCH", "Has PProof", 75))
                .Add(DGVCheckBoxColumn("HAS_NO_OVER", "Has NoOver", 75))
                .Add(DGVCheckBoxColumn("HAS_NO_UNDER", "Has NoUnder", 75))
                .Add(DGVCheckBoxColumn("ALWAYS_PAPER_PROOF", "Always Paper Prf", 65))
                .Add(DGVCheckBoxColumn("NC_PAPER_PROOF", "N/C Paper Prf", 65))
                .Add(DGVCheckBoxColumn("ALWAYS_EXACT_QTY", "Always Exact Qty", 65))
                .Add(DGVCheckBoxColumn("NC_EXACT_QTY", "N/C Exact Qty", 65))
                .Add(DGVCheckBoxColumn("NC_PRODUCT_PROOF", "N/C Prod Prf", 65))
                .Add(DGVCheckBoxColumn("NC_LESS_THAN_MIN", "N/C LTM", 60))
                .Add(DGVCheckBoxColumn("NC_VIRTUAL_PROOF", "N/C Virtual", 60))
                .Add(DGVCheckBoxColumn("NC_SET_UP", "N/C Setup", 60))
                .Add(DGVCheckBoxColumn("NC_COLOR_MATCH", "N/C Color Match", 75))
                .Add(DGVCheckBoxColumn("ALWAYS_NO_OVER", "No Over", 60))
                .Add(DGVCheckBoxColumn("ALWAYS_NO_UNDER", "No Under", 60))
                'If dgv.Name = "dgvSearch" Then
                '    .Add(DGVCheckBoxColumn("ALWAYS_NO_UNDER", "No Under", 75))
                'Else
                '    .Add(DGVCheckBoxColumn("ALWAYS_NO_UNDER", "No Under", 55))
                'End If

                dgv.Columns(Customers.CUS_NO).Frozen = True
                dgv.Columns(Customers.CUS_NAME).Frozen = True

                dgv.Columns(Customers.HAS_PAPER_PROOF).Visible = False
                dgv.Columns(Customers.HAS_EXACT_QTY).Visible = False
                dgv.Columns(Customers.HAS_PRODUCT_PROOF).Visible = False
                dgv.Columns(Customers.HAS_LESS_THAN_MIN).Visible = False
                dgv.Columns(Customers.HAS_VIRTUAL_PROOF).Visible = False
                dgv.Columns(Customers.HAS_SET_UP).Visible = False
                dgv.Columns(Customers.HAS_COLOR_MATCH).Visible = False
                dgv.Columns(Customers.HAS_NO_OVER).Visible = False
                dgv.Columns(Customers.HAS_NO_UNDER).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub FillGrid()

        Try

            Dim strSql As String = _
            "SELECT		CUS_NO, CUS_NAME, HAS_PAPER_PROOF, HAS_EXACT_QTY, HAS_PRODUCT_PROOF, " & _
            "           HAS_LESS_THAN_MIN, HAS_VIRTUAL_PROOF, HAS_SET_UP, HAS_COLOR_MATCH, HAS_NO_OVER, HAS_NO_UNDER, " & _
            "           ALWAYS_PAPER_PROOF, NC_PAPER_PROOF, ALWAYS_EXACT_QTY, NC_EXACT_QTY, " & _
            "           NC_PRODUCT_PROOF, NC_LESS_THAN_MIN, NC_VIRTUAL_PROOF, NC_SET_UP, NC_COLOR_MATCH, ALWAYS_NO_OVER, ALWAYS_NO_UNDER  " & _
            "FROM		MDB_CHARGE_SETUP_BY_CUSTOMER_VIEW C " & _
            "ORDER BY	C.CUS_NO "

            dtCustomers = db.DataTable(strSql)

            dgvCust.DataSource = dtCustomers
            dgvCust.AllowUserToAddRows = False

            strSql = "SELECT " & _
            "CAST('' AS VARCHAR(20)) AS CUS_NO, CAST('' AS VARCHAR(50)) AS CUS_NAME, " & _
            "CAST(0 AS BIT) AS HAS_PAPER_PROOF, " & _
            "CAST(0 AS BIT) AS HAS_EXACT_QTY, " & _
            "CAST(0 AS BIT) AS HAS_PRODUCT_PROOF, " & _
            "CAST(0 AS BIT) AS HAS_LESS_THAN_MIN, " & _
            "CAST(0 AS BIT) AS HAS_VIRTUAL_PROOF, " & _
            "CAST(0 AS BIT) AS HAS_SET_UP, " & _
            "CAST(0 AS BIT) AS HAS_COLOR_MATCH, " & _
            "CAST(0 AS BIT) AS HAS_NO_OVER, " & _
            "CAST(0 AS BIT) AS HAS_NO_UNDER, " & _
            "CAST(0 AS BIT) AS ALWAYS_PAPER_PROOF, " & _
            "CAST(0 AS BIT) AS NC_PAPER_PROOF, " & _
            "CAST(0 AS BIT) AS ALWAYS_EXACT_QTY, " & _
            "CAST(0 AS BIT) AS NC_EXACT_QTY, " & _
            "CAST(0 AS BIT) AS NC_PRODUCT_PROOF, " & _
            "CAST(0 AS BIT) AS NC_LESS_THAN_MIN, " & _
            "CAST(0 AS BIT) AS NC_VIRTUAL_PROOF, " & _
            "CAST(0 AS BIT) AS NC_SET_UP, " & _
            "CAST(0 AS BIT) AS NC_COLOR_MATCH, " & _
            "CAST(0 AS BIT) AS ALWAYS_NO_OVER, " & _
            "CAST(0 AS BIT) AS ALWAYS_NO_UNDER "

            dtSearch = db.DataTable(strSql)

            dgvSearch.DataSource = dtSearch
            dgvSearch.AllowUserToAddRows = False

            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub ApplyFilters()

        Try

            If dtCustomers Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtCustomers.DefaultView.RowFilter = strFilter
            dgvCust.Refresh()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCust_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCust.CellBeginEdit

        Try
            Select Case e.ColumnIndex
                Case Customers.CUS_NO, Customers.CUS_NAME
                    e.Cancel = True

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case Customers.ALWAYS_PAPER_PROOF, Customers.ALWAYS_EXACT_QTY, Customers.NC_COLOR_MATCH, Customers.NC_EXACT_QTY, Customers.NC_LESS_THAN_MIN, Customers.NC_PAPER_PROOF, Customers.NC_PRODUCT_PROOF, Customers.NC_SET_UP, Customers.NC_VIRTUAL_PROOF, Customers.ALWAYS_NO_OVER, Customers.ALWAYS_NO_UNDER

                    dgvSearch.EndEdit()

            End Select

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

    Private Sub dgvCust_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCust.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case Customers.ALWAYS_PAPER_PROOF, Customers.ALWAYS_EXACT_QTY, Customers.NC_COLOR_MATCH, Customers.NC_EXACT_QTY, Customers.NC_LESS_THAN_MIN, Customers.NC_PAPER_PROOF, Customers.NC_PRODUCT_PROOF, Customers.NC_SET_UP, Customers.NC_VIRTUAL_PROOF

                    Debug.Print("dgvCust.EndEdit()")
                    dgvCust.EndEdit()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCust_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCust.CellEndEdit

        Dim strCharge As String = ""
        Dim strFlag As String = "NO_CHARGE"
        Dim strFlagValue As String = ""

        Try
            Select Case e.ColumnIndex
                Case Customers.ALWAYS_PAPER_PROOF
                    strCharge = "PAPER_PROOF"
                    strFlag = "ALWAYS_USE"
                Case Customers.ALWAYS_EXACT_QTY
                    strCharge = "EXACT_QTY"
                    strFlag = "ALWAYS_USE"
                    strFlagValue = 0
                Case Customers.NC_COLOR_MATCH
                    strCharge = "COLOR_MATCH"
                    strFlag = "NO_CHARGE"
                Case Customers.NC_EXACT_QTY
                    strCharge = "EXACT_QTY"
                    strFlag = "NO_CHARGE"
                Case Customers.NC_LESS_THAN_MIN
                    strCharge = "LESS_THAN_MIN"
                    strFlag = "NO_CHARGE"
                Case Customers.NC_PAPER_PROOF
                    strCharge = "PAPER_PROOF"
                    strFlag = "NO_CHARGE"
                Case Customers.NC_PRODUCT_PROOF
                    strCharge = "PRODUCT_PROOF"
                    strFlag = "NO_CHARGE"
                Case Customers.NC_SET_UP
                    strCharge = "SET_UP" '' ????????? MAYBE ...
                    strFlag = "NO_CHARGE"
                Case Customers.NC_VIRTUAL_PROOF
                    strCharge = "VIRTUAL_PROOF"
                    strFlag = "NO_CHARGE"
                Case Customers.ALWAYS_NO_OVER
                    strCharge = "NO_OVER"
                    strFlag = "ALWAYS_USE"
                    strFlagValue = 0
                Case Customers.ALWAYS_NO_UNDER
                    strCharge = "NO_UNDER"
                    strFlag = "ALWAYS_USE"
                    strFlagValue = 0

            End Select

            If strCharge <> "" Then

                Dim db As New cDBA()
                Dim dt As DataTable
                Dim strCus_No As String = dgvCust.CurrentRow.Cells(Customers.CUS_NO).Value.ToString.Trim
                Dim strSql As String = _
                "SELECT * " & _
                "FROM   MDB_CFG_CHARGE_USAGE WITH (Nolock) " & _
                "WHERE CUS_NO = '" & strCus_No & "' AND CHARGE_CD = '" & strCharge & "' AND ISNULL(APPLY_TO_PROGRAM, '') = '' "

                strFlagValue = dgvCust.CurrentCell.Value

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then
                    Dim iCharge_Usage_ID As Integer = dt.Rows(0).Item("Charge_Usage_ID")
                    strSql = "UPDATE MDB_CFG_CHARGE_USAGE SET " & strFlag & " = " & strFlagValue & " WHERE Charge_Usage_ID = " & iCharge_Usage_ID
                    db.Execute(strSql)
                Else
                    strSql = "SELECT ISNULL(Charge_ID, 0) AS Charge_ID FROM MDB_CFG_CHARGE WHERE CHARGE_CD = '" & strCharge & "' "
                    dt = db.DataTable(strSql)
                    If dt.Rows.Count <> 0 Then
                        Dim iCharge_ID As String = dt.Rows(0).Item("Charge_ID").ToString
                        strSql = _
                        "INSERT INTO MDB_CFG_CHARGE_USAGE " & _
                        "(CUS_NO, CHARGE_ID, CHARGE_CD, " & strFlag & ") VALUES (" & _
                        "'" & strCus_No & "', " & iCharge_ID & ", '" & strCharge & "', " & strFlagValue & ")"
                        db.Execute(strSql)
                    End If

                End If

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub dgvCust_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCust.CellEnter

    '    Try
    '        Select Case e.ColumnIndex
    '            Case Customers.CUS_NO, Customers.CUS_NAME
    '                e.cancel = True

    '        End Select

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvCust.ColumnWidthChanged, dgvSearch.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then
                dgv = dgvCust
            Else
                dgv = dgvSearch
            End If
            Debug.Print(e.Column.Name & " --- " & e.Column.Width)
            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvCust.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub dgvCust_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvCust.DoubleClick

    '    Try

    '        If Not (IsNothing(dgvCust.CurrentRow.Cells(Customers.CUS_NO))) Then

    '            Dim strCustomer As String
    '            strCustomer = dgvCust.CurrentRow.Cells(Customers.CUS_NO).Value.ToString.Trim

    '            Dim oCustomer As New cCustomer(strCustomer)
    '            Dim oHeader As New frmCustomerHeader(oCustomer)
    '            oHeader.ShowDialog()
    '            oHeader.Dispose()

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    Private Sub dgvOrders_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvCust.Scroll
        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvCust.FirstDisplayedScrollingColumnIndex
        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        'Debug.Print("++++++++++++++++++++++++")

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString

                ''CHECK NUMERIC FIELDS ENTRY

                'Case "SLSPSN_NO"
                '    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                '        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                '            'If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                '            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                '            GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                '        End If
                '    Else
                '        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                '            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                '        End If
                '    End If

                'CHECK DATE FIELDS ENTRY
                'Case "Ord_Dt", "Inv_Dt", "ShippedDate" ' Date

                '    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                '        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                '    End If

                Case "ALWAYS_PAPER_PROOF", "ALWAYS_EXACT_QTY", "NC_PAPER_PROOF", _
                     "NC_EXACT_QTY", "NC_PRODUCT_PROOF", "NC_LESS_THAN_MIN", _
                     "NC_VIRTUAL_PROOF", "NC_SET_UP", "NC_COLOR_MATCH", "ALWAYS_NO_OVER", "ALWAYS_NO_UNDER"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value Then

                        'Debug.Print(oColumn.Name & " IS CHECKED ")

                        Dim strSearchColName As String = "HAS_PAPER_PROOF"

                        Select Case oColumn.Name
                            Case "ALWAYS_PAPER_PROOF", "NC_PAPER_PROOF"
                                strSearchColName = "HAS_PAPER_PROOF"
                            Case "ALWAYS_EXACT_QTY", "NC_EXACT_QTY"
                                strSearchColName = "HAS_EXACT_QTY"
                            Case "NC_PRODUCT_PROOF"
                                strSearchColName = "HAS_PRODUCT_PROOF"
                            Case "NC_LESS_THAN_MIN"
                                strSearchColName = "HAS_LESS_THAN_MIN"
                            Case "NC_VIRTUAL_PROOF"
                                strSearchColName = "HAS_VIRTUAL_PROOF"
                            Case "NC_SET_UP"
                                strSearchColName = "HAS_SET_UP"
                            Case "NC_COLOR_MATCH"
                                strSearchColName = "HAS_COLOR_MATCH"
                            Case "ALWAYS_NO_OVER"
                                strSearchColName = "HAS_NO_OVER"
                            Case "ALWAYS_NO_UNDER"
                                strSearchColName = "HAS_NO_UNDER"
                        End Select

                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        GetSearchColumnsFilter &= strSearchColName & " = 1 "

                    Else
                        'Debug.Print(oColumn.Name & " NOT CHECKED ")
                    End If

                Case "HAS_PAPER_PROOF", "HAS_EXACT_QTY", "HAS_PRODUCT_PROOF", "HAS_LESS_THAN_MIN", _
                     "HAS_VIRTUAL_PROOF", "HAS_SET_UP", "HAS_COLOR_MATCH", "HAS_NO_OVER", "HAS_NO_UNDER"

                    ' Do nothing for the checkboxes in sort



                    ' EVERYTHING ELSE IS STRING
                Case Else

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

            End Select

        Next oColumn

    End Function

    Private Enum Customers

        CUS_NO
        CUS_NAME
        HAS_PAPER_PROOF
        HAS_EXACT_QTY
        HAS_PRODUCT_PROOF
        HAS_LESS_THAN_MIN
        HAS_VIRTUAL_PROOF
        HAS_SET_UP
        HAS_COLOR_MATCH
        HAS_NO_OVER
        HAS_NO_UNDER
        ALWAYS_PAPER_PROOF
        NC_PAPER_PROOF
        ALWAYS_EXACT_QTY
        NC_EXACT_QTY
        NC_PRODUCT_PROOF
        NC_LESS_THAN_MIN
        NC_VIRTUAL_PROOF
        NC_SET_UP
        NC_COLOR_MATCH
        ALWAYS_NO_OVER
        ALWAYS_NO_UNDER

    End Enum

    'Private Sub rbSearch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOrSearch.CheckedChanged, rbAndSearch.CheckedChanged

    '    Call ApplyFilters()

    'End Sub

    Private Sub dgvSearch_SortCompare(sender As Object, e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvSearch.SortCompare

    End Sub

    Private Sub dgvSearch_Sorted(sender As Object, e As System.EventArgs) Handles dgvSearch.Sorted

        Try
            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvCust.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder
            'dgvOrders.Sort(oSortOrder)
            '        MsgBox("1")
            If oSortOrder = 1 Then
                dgvCust.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvCust.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

    'Private Sub dgvSearch_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.ColumnHeaderMouseClick

    '    Try
    '        Dim oColumn As DataGridViewColumn
    '        oColumn = dgvSearch.Columns(e.ColumnIndex)

    '        Select Case oColumn.Index

    '            Case AIO_CurOrd_Col.Inv_Dt, AIO_CurOrd_Col.Ord_Dt, AIO_CurOrd_Col.ShippedDate

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

    '    'Try

    '    '    Dim oColumn As DataGridViewColumn
    '    '    oColumn = dgvOrders.Columns(e.ColumnIndex)

    '    '    Select Case oColumn.Index

    '    '        Case AIO_CurOrd_Col.Inv_Dt, AIO_CurOrd_Col.Ord_Dt, AIO_CurOrd_Col.ShippedDate

    '    '            ' There is a glitch in the .NET enums... 
    '    '            ' Ascending is 0 in ListDirection and 1 in SortOrder (0 is none in sort order)
    '    '            Dim oSortOrder As System.ComponentModel.ListSortDirection
    '    '            oSortOrder = System.ComponentModel.ListSortDirection.Ascending

    '    '            If dgvOrders.SortOrder = 1 Then
    '    '                oSortOrder = System.ComponentModel.ListSortDirection.Descending
    '    '            End If

    '    '            dgvOrders.Sort(oColumn, oSortOrder)

    '    '    End Select

    '    'Catch er As Exception
    '    '    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    'End Try

    'End Sub

    Private Sub frmCustomer_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If dtCustomers Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvCust)

                dgvSearch.ColumnHeadersHeight = 44
                dgvCust.ColumnHeadersVisible = False

            End If

            'If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

            '    Call ClearSearch()

            'End If

            Call FillGrid()
            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub SetPermissions()

        SetUser_Rights(User_Rights, Me.Tag)

        Select Case User_Rights
            Case "READWRITE"
                dgvCust.ReadOnly = False

            Case "SUPERUSER"
                dgvCust.ReadOnly = False

            Case "READONLY"
                dgvCust.ReadOnly = True

        End Select

    End Sub

End Class