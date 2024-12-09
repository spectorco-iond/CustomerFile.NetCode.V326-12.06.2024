Public Class ucQuotes

    Private User_Rights As String = "READONLY"

    Private dtQuotes As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA("DSN=Exact;")

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
    Private m_Quote_Step_ID As Integer = 0

    Private m_Loading As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Shadows Sub Load()

        Try

            'm_Loading = True ' Maintenant dans NEW

            m_Show_All_Customers = True
            m_Show_Cus_No = True

            chkShow_Only_User_Stuff.Checked = True
            tscbQuotes.Text = "Current Quotes"
            tscbQuote_Step_ID.Text = "All Steps"

            m_Loading = False

            Call SetPermissions()

            If dtQuotes Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvQuotes)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvQuotesunications.ColumnHeadersVisible = False

            End If

            Call FillGrid()
            'Call ApplyFilters()

            tmrRefresh.Enabled = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            m_Loading = False

            Call SetPermissions()

            m_Customer = pCustomer

            If dtQuotes Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvQuotes)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvQuotesunications.ColumnHeadersVisible = False

            End If

            If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

                Call ClearSearch()

            End If

            Call FillGrid()
            'Call ApplyFilters()

            tmrRefresh.Enabled = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub Save()

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns
                'Ion added CUS_PROG_ID,CUS_PROG_ITEM_LIST_ID
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "Cus_Prog_Id", 30))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_ID", "CUS_PROG_ITEM_LIST_ID", 30))
                'Ion
                .Add(DGVTextBoxColumn("Cus_No", "Cus_No", 70))
                .Add(DGVTextBoxColumn("Ord_Status", "Ord_Status", 70))
                'Ion added Prog_Csr
                .Add(DGVTextBoxColumn("Prog_Csr", "Prog_Csr", 70))
                'Ion-----
                .Add(DGVTextBoxColumn("Ord_No", "Quote", 70))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("Ord_Dt", "Date", 85))
                Else
                    .Add(DGVTextBoxColumn("Ord_Dt", "Date", 85))
                End If

                '.Add(DGVTextBoxColumn("Item_No", "Item", IIf(m_Show_All_Customers, 70, 110)))
                .Add(DGVTextBoxColumn("Item_No", "Item", 70))
                '.Add(DGVTextBoxColumn("Item_Desc", "Description", IIf(m_Show_All_Customers, 290, 350)))
                .Add(DGVTextBoxColumn("Item_Desc", "Description", 290))
                .Add(DGVTextBoxColumn("QUOTE_TYPE_ID", "QUOTE_TYPE_ID", 50))
                .Add(DGVTextBoxColumn("Ship_Origin", "Ship Origin", 70))
                .Add(DGVTextBoxColumn("Quote_Step_ID", "Step", 40))
                .Add(DGVTextBoxColumn("Quote_Step_Desc", "Step", 100))
                '.Add(DGVTextBoxColumn("Item_Desc_1", "Description 1", 220))
                '.Add(DGVTextBoxColumn("Item_Desc_2", "Description 2", 150))
                .Add(DGVTextBoxColumn("Qty_Ordered_Op", "", 25))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("Qty_Ordered", "Quantity", 50))
                Else
                    .Add(DGVTextBoxColumn("Qty_Ordered", "Quantity", 75))
                End If

                .Add(DGVTextBoxColumn("Unit_Price_Op", "", 25))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("Unit_Price", "Price", 70))
                Else
                    .Add(DGVTextBoxColumn("Unit_Price", "Price", 95))
                End If

                .Add(DGVTextBoxColumn("Ext_Price_Op", "", 25))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("Ext_Price", "Ext Price", 70))
                Else
                    .Add(DGVTextBoxColumn("Ext_Price", "Ext Price", 95))
                End If

                '.Add(DGVTextBoxColumn("Qty_Ordered", "Quantity", 70))
                '.Add(DGVTextBoxColumn("Unit_Price", "Price", 70))
                '.Add(DGVTextBoxColumn("Ext_Price", "Ext Price", 100))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("User_Login", "User Login", 90))
                Else
                    .Add(DGVTextBoxColumn("User_Login", "User Login", 70))
                End If

                .Add(DGVTextBoxColumn("Line_Seq_No", "Line_Seq_No", 25))

            End With

            With dgv
                'Ion
                .Columns(Columns.Cus_Prog_Id).Visible = False
                .Columns(Columns.CUS_PROG_ITEM_LIST_ID).Visible = False
                'Ion
                .Columns(Columns.Cus_No).Visible = m_Show_Cus_No
                .Columns(Columns.Ord_Status).Visible = False
                'Ion added Prog_CSR
                .Columns(Columns.Prog_Csr).Visible = False
                'Ion--------
                Dim oCell0Digits As New DataGridViewCellStyle()

                oCell0Digits.Format = "##,##0"
                oCell0Digits.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.Qty_Ordered).DefaultCellStyle = oCell0Digits

                Dim oCell4Digits As New DataGridViewCellStyle()

                oCell4Digits.Format = "##,##0.0000"
                oCell4Digits.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.Unit_Price).DefaultCellStyle = oCell4Digits
                .Columns(Columns.Ext_Price).DefaultCellStyle = oCell4Digits

                Dim oCell2Digits As New DataGridViewCellStyle()

                oCell2Digits.Format = "##,##0.00"
                oCell2Digits.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Columns.Ext_Price).DefaultCellStyle = oCell2Digits
                '++ID 11.07.2016
                .Columns(Columns.QUOTE_TYPE_ID).Visible = False
                '----------------------------------------------
                If .Name = "dgvQuotes" Then
                    .Columns(Columns.Qty_Ordered_Op).Visible = False
                    .Columns(Columns.Unit_Price_Op).Visible = False
                    .Columns(Columns.Ext_Price_Op).Visible = False
                End If

                .Columns(Columns.Line_Seq_No).Visible = False
                .Columns(Columns.Quote_Step_ID).Visible = False

                'If Not (m_Show_All_Customers) Then
                '.Columns(Columns.Quote_Step_Desc).Visible = False
                'End If

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ClearSearch()

    End Sub

    Private Sub FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim strSql As String = String.Empty

            'strSql = _
            '"SELECT		O.Cus_No, A.status AS Ord_Status, O.Ord_No, O.Ord_Dt, L.Item_No, L.Item_Desc_1, " & _
            '"			L.Item_Desc_2, CAST(L.Qty_Ordered AS DECIMAL(13, 2)) AS Qty_Ordered, L.Unit_Price, " & _
            '"			L.Qty_Ordered * L.Unit_Price as Ext_Price, A.User_Name as User_Login, L.Line_Seq_No " & _
            '"FROM		oeordhdr_sql O WITH (Nolock) " & _
            '"INNER JOIN	oeordlin_sql L WITH (Nolock) ON O.ord_no = L.ord_no and o.ord_type = l.ord_type " & _
            '"INNER JOIN	oehdraud_sql A WITH (Nolock) ON O.ord_no = A.ord_no AND O.ord_type = A.ord_type " & _
            '"			AND A.aud_action = 'A' AND A.status is not null " & _
            '"WHERE		O.Cus_No = '" & m_Customer.cmp_code & "' AND O.Ord_Type = 'Q' " & _
            '"ORDER BY   O.Cus_No, O.Ord_Dt Desc, O.Ord_No, L.Line_Seq_No "

            'strSql = _
            '"SELECT		O.Cus_No, A.status AS Ord_Status, O.Ord_No, O.Ord_Dt, L.Item_No, " & _
            '"			RTRIM(ISNULL(L.ITEM_DESC_1, '')) + RTRIM(ISNULL(L.ITEM_DESC_2, '')) AS Item_Desc, " & _
            '"           CAST('' AS CHAR(2)) AS Qty_Ordered_Op, CAST(L.Qty_Ordered AS DECIMAL(13, 2)) AS Qty_Ordered, " & _
            '"           CAST('' AS CHAR(2)) AS Unit_Price_Op, L.Unit_Price, " & _
            '"			CAST('' AS CHAR(2)) AS Ext_Price_Op, L.Qty_Ordered * L.Unit_Price as Ext_Price, " & _
            '"           A.User_Name as User_Login, L.Line_Seq_No " & _
            '"FROM		oeordhdr_sql O WITH (Nolock) " & _
            '"INNER JOIN	oeordlin_sql L WITH (Nolock) ON O.ord_no = L.ord_no and o.ord_type = l.ord_type " & _
            '"INNER JOIN	oehdraud_sql A WITH (Nolock) ON O.ord_no = A.ord_no AND O.ord_type = A.ord_type " & _
            '"			AND A.aud_action = 'A' AND A.status is not null " & _
            '"WHERE		O.Cus_No = '" & m_Customer.cmp_code & "' AND O.Ord_Type = 'Q' " & _
            '"ORDER BY   O.Cus_No, O.Ord_Dt Desc, O.Ord_No, L.Line_Seq_No "

            'Ion ---- ,CAST('' AS INT) As CUS_PROG_ID, CAST('' AS INT) AS CUS_PROG_ITEM_LIST_ID
            If m_Show_Macola Then
                strSql =
                "SELECT	CAST('' AS INT) As CUS_PROG_ID, CAST('' AS INT) AS CUS_PROG_ITEM_LIST_ID ,O.Cus_No, A.status AS Ord_Status," &
                "       CAST('' AS VARCHAR(20)) AS PROG_CSR, O.Ord_No, O.Ord_Dt, L.Item_No, " &
                "		RTRIM(ISNULL(L.ITEM_DESC_1, '')) + RTRIM(ISNULL(L.ITEM_DESC_2, '')) AS Item_Desc, " &
                "       CAST('' AS INT) AS QUOTE_TYPE_ID, CAST('' AS VARCHAR(30)) AS Ship_Origin," &
                "       CAST(L.Qty_Ordered AS DECIMAL(13, 2)) AS Qty_Ordered, CAST(0 AS INT) AS Quote_Step_ID, " &
                "       CAST('' AS CHAR(60)) AS Quote_Step_Desc, CAST('' AS CHAR(2)) AS Qty_Ordered_Op, " &
                "       L.Qty_Ordered, CAST('' AS CHAR(2)) AS Unit_Price_Op, L.Unit_Price, " &
                "		CAST('' AS CHAR(2)) AS Ext_Price_Op, L.Qty_Ordered * L.Unit_Price as Ext_Price, " &
                "       A.User_Name as User_Login, L.Line_Seq_No FROM oeordhdr_sql O WITH (Nolock) " &
                "       INNER JOIN	oeordlin_sql L WITH (Nolock) ON O.ord_no = L.ord_no and o.ord_type = l.ord_type " &
                "       INNER JOIN	oehdraud_sql A WITH (Nolock) ON O.ord_no = A.ord_no AND O.ord_type = A.ord_type " &
                "		AND A.aud_action = 'A' AND A.status is not null " &
                "       WHERE O.Ord_Type = 'Q' "
                If Not (m_Show_All_Customers) Then
                    strSql &= " AND O.Cus_No = '" & m_Customer.cmp_code & "' "
                End If
            End If
            'Ion Added or m_Show_Almost_Due
            If m_Show_History Or m_Show_Current Or m_Show_Almost_Due Then

                If m_Show_Macola Then
                    strSql &= " UNION "
                End If

                '++ID in comment from 15.07.2015
                'strSql &= _
                '"SELECT		P.CUS_PROG_ID,I.CUS_PROG_ITEM_LIST_ID,P.CUS_NO, '' AS ORD_STATUS, P.PROG_CSR , P.SPECTOR_CD AS Ord_No," & _
                '"P.Start_Dt AS Ord_Dt, I.Item_Cd AS Item_No, RTRIM(ISNULL(I.ITEM_DESC, '')) + RTRIM(ISNULL(I.ITEM_Color, '')) AS Item_Desc, " & _
                '"           P.Quote_Step_ID, E.Enum_Value AS Quote_Step_Desc, " & _
                '"			CAST('' AS CHAR(2)) AS Qty_Ordered_Op, CAST(I.Min_Qty_Ord AS DECIMAL(13, 2)) AS Qty_Ordered, " & _
                '"           CAST('' AS CHAR(2)) AS Unit_Price_Op, I.Unit_Price, " & _
                '"			CAST('' AS CHAR(2)) AS Ext_Price_Op, ISNULL(I.Min_Qty_Ord, 0) * I.Unit_Price as Ext_Price, " & _
                '"           I.User_Login, I.Cus_Prog_Item_List_ID AS Line_Seq_No " & _
                '"FROM		MDB_CUS_PROG P WITH (NOLOCK) " & _
                '"LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (NOLOCK) ON P.CUS_PROG_ID = I.CUS_PROG_ID " & _
                '"LEFT JOIN  MDB_CFG_ENUM E WITH (NOLOCK) ON E.Enum_Cat = 'QUOTE_STEP_ID' AND P.Quote_Step_ID = E.enum_order " & _
                '"WHERE		PROG_TYPE = 3 "

                '++ID 15.07.2015 new Query for see the quote unless items also  
                strSql &=
              "SELECT P.CUS_PROG_ID,I.CUS_PROG_ITEM_LIST_ID,P.CUS_NO, '' AS ORD_STATUS, P.PROG_CSR , P.SPECTOR_CD AS Ord_No," &
              "       P.Start_Dt AS Ord_Dt, I.Item_Cd AS Item_No, RTRIM(ISNULL(I.ITEM_DESC, '')) + RTRIM(ISNULL(I.ITEM_Color, '')) AS Item_Desc, " &
              "       I.QUOTE_TYPE_ID, E1.ENUM_VALUE As Ship_Origin,  P.Quote_Step_ID, E.Enum_Value AS Quote_Step_Desc, " &
              "		  CAST('' AS CHAR(2)) AS Qty_Ordered_Op, ISNULL(CAST(I.Min_Qty_Ord AS DECIMAL(13, 2)),0) AS Qty_Ordered, " &
              "       CAST('' AS CHAR(2)) AS Unit_Price_Op, ISNULL(I.Unit_Price,0) As Unit_Price, " &
              "		  CAST('' AS CHAR(2)) AS Ext_Price_Op, ISNULL(ISNULL(I.Min_Qty_Ord, 0) * I.Unit_Price,0) as Ext_Price, " &
              "       I.User_Login, I.Cus_Prog_Item_List_ID AS Line_Seq_No " &
              "   FROM		MDB_CUS_PROG P WITH (NOLOCK) " &
              "   LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (NOLOCK) ON P.CUS_PROG_ID = I.CUS_PROG_ID " &
              "   LEFT JOIN  MDB_CFG_ENUM E WITH (NOLOCK) ON E.Enum_Cat = 'QUOTE_STEP_ID' AND P.Quote_Step_ID = E.enum_order " &
              "   LEFT JOIN MDB_CFG_ENUM E1 ON I.QUOTE_TYPE_ID = E1.ID  " &
              "   WHERE PROG_TYPE = 3 "


                If Not (m_Show_All_Customers) Then
                    strSql &= " AND P.Cus_No = '" & m_Customer.cmp_code & "' "
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

                If m_Quote_Step_ID <> 0 Then
                    strSql &= " AND P.Quote_Step_ID = " & m_Quote_Step_ID & " "
                End If

            End If

            strSql &= "ORDER BY   Cus_No, Ord_Dt Desc, Ord_No, Line_Seq_No "

            dtQuotes = db.DataTable(strSql)

            dgvQuotes.DataSource = dtQuotes
            dgvQuotes.AllowUserToAddRows = False

            strSql = "SELECT " & _
            "CAST('' AS CHAR(20)) AS Cus_No, CAST('' AS CHAR(1)) AS Ord_Status,CAST('' AS VARCHAR(20)) AS PROG_CSR ," & _
            "CAST('' AS CHAR(8)) AS Ord_No, CAST(NULL AS DATETIME) AS Ord_Dt, " & _
            "CAST('' AS CHAR(30)) AS Item_No, CAST('' AS CHAR(30)) AS Item_Desc_1, " & _
            "CAST('' AS CHAR(30)) AS Item_Desc_2, CAST(NULL AS DECIMAL(13, 2))  AS Qty_Ordered, " & _
            "CAST(NULL AS DECIMAL(16, 6)) AS Unit_Price, CAST(NULL AS DECIMAL(16, 6)) AS Ext_Price, " & _
            "CAST('' AS VARCHAR(20)) AS User_Login, CAST(0 AS INT) AS Line_Seq_No "

            'Ion ---- CAST('' AS INT) As CUS_PROG_ID, CAST('' AS INT) AS CUS_PROG_ITEM_LIST_ID
            strSql = "SELECT " &
            " CAST('' AS INT) As CUS_PROG_ID, CAST('' AS INT) AS CUS_PROG_ITEM_LIST_ID, " &
            "CAST('' AS CHAR(20)) AS Cus_No, CAST('' AS CHAR(1)) AS Ord_Status,CAST('' AS VARCHAR(20)) AS PROG_CSR , " &
            "CAST('' AS CHAR(8)) AS Ord_No, CAST(NULL AS DATETIME) AS Ord_Dt, " &
            "CAST('' AS CHAR(30)) AS Item_No, CAST('' AS CHAR(60)) AS Item_Desc, " &
            "CAST('' AS INT) AS QUOTE_TYPE_ID, CAST('' AS VARCHAR(30)) AS Ship_Origin," &
            "CAST(0 AS INT) AS Quote_Step_ID, CAST('' AS CHAR(60)) AS Quote_Step_Desc, " &
            "CAST('>=' AS CHAR(2)) AS Qty_Ordered_Op, CAST(0 AS DECIMAL(13, 2)) AS Qty_Ordered, " &
            "CAST('>=' AS CHAR(2)) AS Unit_Price_Op, CAST(0 AS DECIMAL(16, 6)) AS Unit_Price, " &
            "CAST('>=' AS CHAR(2)) AS Ext_Price_Op, CAST(0 AS DECIMAL(16, 6)) AS Ext_Price, " &
            "CAST('' AS VARCHAR(20)) AS User_Login, CAST(0 AS INT) AS Line_Seq_No "

            '"CAST(NULL AS DECIMAL(16, 2)) AS Tot_Dollars, CAST('' AS CHAR(40)) AS Bill_To_Name, " & _

            If dtSearch Is Nothing Then
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

            If dtQuotes Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtQuotes.DefaultView.RowFilter = strFilter
            dgvQuotes.Refresh()

            tssRecordCount.Text = "Records: " & dgvQuotes.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvSearch.CellBeginEdit

        Try

            'e.Cancel = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Try
            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        Try

            dgvSearch.BeginEdit(True)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_Sorted(sender As Object, e As System.EventArgs) Handles dgvSearch.Sorted

        Try

            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvQuotes.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvQuotes.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvQuotes.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

                Case Columns.Ord_Dt

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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvQuotes.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvQuotes
            Else
                dgv = dgvSearch
            End If

            Select Case e.Column.Index
                Case Columns.Qty_Ordered_Op, Columns.Qty_Ordered
                    If oSender.Name = "dgvSearch" Then
                        dgvQuotes.Columns(Columns.Qty_Ordered).Width = dgvSearch.Columns(Columns.Qty_Ordered_Op).Width + dgvSearch.Columns(Columns.Qty_Ordered).Width
                    Else
                        dgvSearch.Columns(Columns.Qty_Ordered).Width = dgvQuotes.Columns(Columns.Qty_Ordered).Width - dgvSearch.Columns(Columns.Qty_Ordered_Op).Width
                    End If

                Case Columns.Unit_Price_Op, Columns.Unit_Price
                    If oSender.Name = "dgvSearch" Then
                        dgvQuotes.Columns(Columns.Unit_Price).Width = dgvSearch.Columns(Columns.Unit_Price_Op).Width + dgvSearch.Columns(Columns.Unit_Price).Width
                    Else
                        dgvSearch.Columns(Columns.Unit_Price).Width = dgvQuotes.Columns(Columns.Unit_Price).Width - dgvSearch.Columns(Columns.Unit_Price_Op).Width
                    End If

                Case Columns.Ext_Price_Op, Columns.Ext_Price
                    If oSender.Name = "dgvSearch" Then
                        dgvQuotes.Columns(Columns.Ext_Price).Width = dgvSearch.Columns(Columns.Ext_Price_Op).Width + dgvSearch.Columns(Columns.Ext_Price).Width
                    Else
                        dgvSearch.Columns(Columns.Ext_Price).Width = dgvQuotes.Columns(Columns.Ext_Price).Width - dgvSearch.Columns(Columns.Ext_Price_Op).Width
                    End If

                Case Else
                    dgv.Columns(e.Column.Index).Width = e.Column.Width

            End Select

            dgvSearch.HorizontalScrollingOffset = dgvQuotes.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvQuotes_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvQuotes.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvQuotes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvQuotes.KeyDown

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


    Private Sub dgvQuotes_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvQuotes.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvQuotes.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "Cus_No", "Ord_Status", "Ord_No", "Item_No", "Item_Desc", "Item_Desc_1", "Item_Desc_2", "User_Login", "Ship_Origin" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "Ord_Dt" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        'Ion search by date
                        GetSearchColumnsFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
                          & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "

                        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    End If

                Case "Qty_Ordered" ' Numeric + Operator

                    Dim strOperator As String
                    Select Case dgvSearch.Rows(0).Cells("Qty_Ordered_Op").Value.ToString.Trim
                        Case ">", ">=", "<", "<=", "<>", "="
                            strOperator = dgvSearch.Rows(0).Cells("Qty_Ordered_Op").Value.ToString.Trim
                        Case Else
                            strOperator = ">="
                    End Select

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        'If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        GetSearchColumnsFilter &= oColumn.Name & " " & strOperator & " " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        'End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If

                Case "Unit_Price" ' Numeric + Operator

                    Dim strOperator As String
                    Select Case dgvSearch.Rows(0).Cells("Unit_Price_Op").Value.ToString.Trim
                        Case ">", ">=", "<", "<=", "<>", "="
                            strOperator = dgvSearch.Rows(0).Cells("Unit_Price_Op").Value.ToString.Trim
                        Case Else
                            strOperator = ">="
                    End Select

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        'If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        GetSearchColumnsFilter &= oColumn.Name & " " & strOperator & " " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        'End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If

                Case "Ext_Price" ' Numeric + Operator

                    Dim strOperator As String
                    Select Case dgvSearch.Rows(0).Cells("Ext_Price_Op").Value.ToString.Trim
                        Case ">", ">=", "<", "<=", "<>", "="
                            strOperator = dgvSearch.Rows(0).Cells("Ext_Price_Op").Value.ToString.Trim
                        Case Else
                            strOperator = ">="
                    End Select

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        'If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        GetSearchColumnsFilter &= oColumn.Name & " " & strOperator & " " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        'End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If

            End Select

        Next oColumn

        If chkShow_Only_User_Stuff.Checked = True Then
            '    GetSearchColumnsFilter &= " AND PROG_CSR = '" & Environment.UserName & "' "

            'Ion Added this if for 'AND'
            If GetSearchColumnsFilter <> "" Then
                GetSearchColumnsFilter &= " AND PROG_CSR = '" & Environment.UserName & "' "
            Else
                GetSearchColumnsFilter &= " PROG_CSR = '" & Environment.UserName & "' "
            End If
            'Ion
        End If

    End Function

    Private Enum Columns
        'ion
        Cus_Prog_Id
        CUS_PROG_ITEM_LIST_ID
        'ion

        Cus_No
        Ord_Status

        'Ion--
        Prog_Csr
        'Ion--

        Ord_No
        Ord_Dt
        Item_No
        Item_Desc
        Quote_Step_ID
        Quote_Step_Desc
        QUOTE_TYPE_ID
        Ship_Origin
        'Item_Desc_1
        'Item_Desc_2
        Qty_Ordered_Op
        Qty_Ordered
        Unit_Price_Op
        Unit_Price
        Ext_Price_Op
        Ext_Price
        User_Login
        Line_Seq_No

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

            Dim ofrm As New frmQuickProgram(m_Customer, Program_Types.Quote.ToString) '12.14.2017 "Quote")
            'ofrm.Program_Type = "Quote"
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

            'Ion-----
            If dgvQuotes.Rows.Count <> 0 Then
                'Ion-----
                If dgvQuotes.CurrentRow.Cells(Columns.Ord_No).Value.ToString.Substring(0, 1) <> "Q" Then Exit Sub

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oProgram As New cMdb_Cus_Prog()
                Dim oProgramB As New cMdb_Cus_Prog_BUS

                ' MsgBox(dgvQuotes.Rows.Count)

                ' THAT IS A BIG HOLE THAT NEEDS TO BE FIXED. MUST OPEN 
                ' ONLY EXTERNAL QUOTES, NOT THOSE FROM MACOLA.

                oProgram = oProgramB.Load(dgvQuotes.CurrentRow.Cells(Columns.Ord_No).Value)

                If m_Customer Is Nothing Or m_Show_All_Customers Then
                    m_Customer = New cCustomer(oProgram.Cus_No)
                End If

                Dim ofrm As New frmQuickProgram(m_Customer, oProgram)
                ofrm.Program_Type = "Quote"

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
            '    'Ion-----
            If dgvQuotes.Rows.Count <> 0 Then
                'Ion-----

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                'Ion 14.10.14
                Dim oProgram As New cMdb_Cus_Prog()
                Dim oCus_Prog As New cMdb_Cus_Prog_BUS()
                Dim oProgram_Rev As New cMdb_Cus_Prog_Rev_BLL()
                Dim oProgram_Comm As New cMdb_Prog_Comment()
                '  Dim oItemBll As New cMDB_CUS_PROG_ITEM_PRICE_BLL()
                Dim oItemBll As New cMdb_Cus_Prog_Item_List_BUS()
                Dim oCfg_Charge_Usage As New cMdb_Cfg_Charge_Usage()
                Dim oItemPrice As New cMacolaOeprcfil_Sql()

                oProgram.Cus_Prog_Id = dgvQuotes.CurrentRow.Cells(Columns.Cus_Prog_Id).Value

                'cMacolaOeprcfil_Sql()
                oItemPrice.Cus_Prog_Id = oProgram.Cus_Prog_Id
                oItemPrice.DeleteAll() 'comment delete in the class

                'cMdb_Cfg_Charge_Usage()
                oCfg_Charge_Usage.Cus_Prog_ID = oProgram.Cus_Prog_Id
                oCfg_Charge_Usage.DeleteAll() 'comment delete in the class

                'cMdb_Cus_Prog_Item_List
                oItemBll.Delete(dgvQuotes.CurrentRow.Cells(Columns.CUS_PROG_ITEM_LIST_ID).Value) 'comment delete in the class

                'cMdb_Prog_Comment()
                'oProgram.Cus_Prog_Id = dgvQuotes.CurrentRow.Cells(Columns.Cus_Prog_Id).Value
                oProgram_Comm.Delete(oProgram) 'comment delete in the class

                'cMdb_Cus_Prog_Rev
                ' oProgram.Cus_Prog_Id = dgvQuotes.CurrentRow.Cells(Columns.Cus_Prog_Id).Value
                oProgram_Rev.Delete(oProgram) 'comment delete in the class

                'cMdb_Cus_Prog
                '  oProgram.Cus_Prog_Id = dgvQuotes.CurrentRow.Cells(Columns.Cus_Prog_Id).Value
                oCus_Prog.Delete(oProgram)

            'Ion

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
        Set(value As Boolean)
            m_Show_All_Customers = value
        End Set
    End Property

    Private Property Show_Only_User_Stuff() As Boolean
        Get
            Show_Only_User_Stuff = m_Show_Only_User_Stuff
        End Get
        Set(value As Boolean)
            m_Show_Only_User_Stuff = value
        End Set
    End Property

    Private Property Show_Cus_No() As Boolean
        Get
            Show_Cus_No = m_Show_Cus_No
        End Get
        Set(value As Boolean)
            m_Show_Cus_No = value
        End Set
    End Property

    Private Property Show_History() As Boolean
        Get
            Show_History = m_Show_History
        End Get
        Set(value As Boolean)
            m_Show_History = value
        End Set
    End Property

    Private Property Show_Current() As Boolean
        Get
            Show_Current = m_Show_Current
        End Get
        Set(value As Boolean)
            m_Show_Current = value
        End Set
    End Property

    Private Property Show_Almost_Due As Boolean
        Get
            Show_Almost_Due = m_Show_Almost_Due
        End Get
        Set(ByVal value As Boolean)
            m_Show_Almost_Due = value
        End Set
    End Property

    Private Property Show_Macola() As Boolean
        Get
            Show_Macola = m_Show_Macola
        End Get
        Set(value As Boolean)
            m_Show_Macola = value
        End Set
    End Property

    Private Property Quote_Step_ID() As Integer
        Get
            Quote_Step_ID = m_Quote_Step_ID
        End Get
        Set(value As Integer)
            m_Quote_Step_ID = value
        End Set
    End Property

    'Private Property Show_Approved() As Boolean
    '    Get
    '        Show_Approved = m_Show_Approved
    '    End Get
    '    Set(value As Boolean)
    '        m_Show_Approved = value
    '    End Set
    'End Property

    Private Sub chkShow_Only_User_Stuff_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShow_Only_User_Stuff.CheckedChanged

        m_Show_Only_User_Stuff = (chkShow_Only_User_Stuff.Checked)
        If Not m_Loading Then
            Menu_Refresh()
        End If

    End Sub

    'Private Sub tsddQuotes_Click(sender As System.Object, e As System.EventArgs)

    '    m_Show_Current = (tsddQuotes.Text = "All Quotes" Or tsddQuotes.Text = "Current Quotes")
    '    m_Show_History = (tsddQuotes.Text = "All Quotes" Or tsddQuotes.Text = "History Quotes")
    '    'm_Show_Macola = (tsddQuotes.Text = "Macola Quotes")

    '    If Not m_Loading Then Menu_Refresh()

    'End Sub

    'Private Sub tsddQuote_Step_ID_Click(sender As System.Object, e As System.EventArgs) Handles tsddQuote_Step_ID.Click

    'End Sub

    'Private Sub tscbQuotes_Click(sender As System.Object, e As System.EventArgs) Handles tscbQuotes.Click
    'End Sub

    'Private Sub ToolStripComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripComboBox1.Click

    'End Sub

    Private Sub tscbQuote_Step_ID_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tscbQuote_Step_ID.SelectedIndexChanged

        Select Case tscbQuote_Step_ID.Text

            Case "All Steps"
                m_Quote_Step_ID = 0
            Case "Saved Quote"
                m_Quote_Step_ID = 1
            Case "Pending Approval"
                m_Quote_Step_ID = 2
            Case "Approved"
                m_Quote_Step_ID = 3
            Case "Completed"
                m_Quote_Step_ID = 4
            Case "Sent To Customer"
                m_Quote_Step_ID = 5

        End Select

        If Not m_Loading Then
            Menu_Refresh()
        End If

    End Sub

    Private Sub tscbQuotes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tscbQuotes.SelectedIndexChanged

        m_Show_Current = (tscbQuotes.Text = "All Quotes" Or tscbQuotes.Text = "Current Quotes")
        m_Show_History = (tscbQuotes.Text = "All Quotes" Or tscbQuotes.Text = "History Quotes")
        'Ion Added------
        m_Show_Almost_Due = (tscbQuotes.Text = "All Quotes" Or tscbQuotes.Text = "Almost Due")
        'Ion ----------
        m_Show_Macola = (tscbQuotes.Text = "Macola Quotes")

        If Not m_Loading Then
            Menu_Refresh()
        End If

    End Sub

    Private Sub tmrRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRefresh.Tick

        'Call Menu_Refresh()

    End Sub

  
    Private Sub tscbConvertExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbConvertExcel.Click
        Try



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class
