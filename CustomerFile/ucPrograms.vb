Imports System.IO

Public Class ucPrograms

    Private User_Rights As String = "READONLY"

    Private dtPrograms As DataTable
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

    Private dtExc As DataTable
    Public Shadows Sub Load()
        Try
            ' tsButtonExcel.Visible = ExcelBtn(Environment.UserName)

            '++ID 11.29.2016
            Call ExcelBtn()
            'm_Loading = True ' Maintenant dans NEW

            m_Show_All_Customers = True
            m_Show_Cus_No = True

            chkShow_Only_User_Stuff.Checked = True
            tscbPrograms.Text = "Current Programs"

            m_Loading = False

            Call SetPermissions()

            If dtPrograms Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvPrograms)

                dgvSearch.ColumnHeadersHeight = 24

            End If

            Call FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Shadows Sub Load(ByVal pCustomer As cCustomer)

        Try

            m_Loading = False

            '  tsButtonExcel.Visible = ExcelBtn(Environment.UserName)
            Call ExcelBtn()
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
                .Add(DGVTextBoxColumn("CMP_NAME", "CUS.NAME", 100))
                .Add(DGVTextBoxColumn("SPECTOR_CD", "Spector Code", 70))
                .Add(DGVTextBoxColumn("PROG_CD", "Program Code", 110))

                '++ID StepId Added for check if is approved program
                'in the case if EQP + % is selected and is write
                .Add(DGVTextBoxColumn("Quote_Step_ID", "StepID", 40))
                .Add(DGVTextBoxColumn("Quote_Step_Desc", "Step", 100))

                'Ion----
                .Add(DGVTextBoxColumn("PROG_CSR", "Prog_CSR", 70))
                'Ion----
                '.Add(DGVTextBoxColumn("PROG_DESC", "Imprint", 110))
                '++ID changed Column name Imprint to prog Comments, imprint was wrong name
                .Add(DGVTextBoxColumn("PROG_DESC", "Prog-Comments", 110))

                '-----------------------------
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("START_DT", "Start Date", 70))
                Else
                    .Add(DGVTextBoxColumn("START_DT", "Start Date", 70))
                    '    dgv.Columns(Columns.CreateDate).DefaultCellStyle.Format = "MM/dd/yyyy"
                End If

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("END_DT", "End Date", 70))
                Else
                    .Add(DGVTextBoxColumn("END_DT", "End Date", 70))
                    '    dgv.Columns(Columns.CreateDate).DefaultCellStyle.Format = "MM/dd/yyyy"
                End If
                '-----------------------------

                '.Add(DGVTextBoxColumn("START_DT", "Start Date", 70))
                '.Add(DGVTextBoxColumn("END_DT", "End Date", 70))
                .Add(DGVTextBoxColumn("Buyer_Name", "Buyer Name", 100))
                .Add(DGVTextBoxColumn("VEND_NO", "VEND NO", 80))
                .Add(DGVTextBoxColumn("ITEM_CD", "Item", 80))
                .Add(DGVTextBoxColumn("ITEM_COMMENT_LOGO", "ITEM_COMMENT_LOGO", 120))
                .Add(DGVTextBoxColumn("DISCO", "DISCO", 100))
                .Add(DGVTextBoxColumn("ITEM_NO", "SKU", 100))
                .Add(DGVTextBoxColumn("ITEM_DESC", "IT.DESC", 100))
                .Add(DGVTextBoxColumn("ITEM_COLOR", "IT.COLOR", 70))

                .Add(DGVTextBoxColumn("MIN_QTY_ORD", "Min Qty", 60))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Price", 65))
                '.Add(DGVTextBoxColumn("EQP_LEVEL", "EQP Level", 60))
                .Add(DGVCheckBoxColumn("EQP_LEVEL", "EQP", 50))
                .Add(DGVTextBoxColumn("EQP_COLUMN", "EQP Column", 50))
                .Add(DGVTextBoxColumn("EQP_PCT", "EQP Disc", 70))
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
                .Columns(Columns.PROG_CSR).Visible = False
                .Columns(Columns.CUS_NO).Visible = m_Show_Cus_No
                .Columns(Columns.CMP_NAME).Visible = m_Show_Cus_No

                .Columns(Columns.EQP_COLUMN).Visible = False
                '.Columns(Columns.EQP_LEVEL).Visible = False
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


            '" '' as ITEM_COMMENTT_LOG , " & 
            strSql =
            "SELECT	P.CUS_PROG_ID, I.CUS_PROG_ITEM_LIST_ID, P.CUS_NO, c.cmp_name, P.SPECTOR_CD, P.PROG_CD,P.Quote_Step_ID, E.Enum_Value AS Quote_Step_Desc,P.PROG_CSR,  " &
            " CASE WHEN ISNULL(P.PROG_DESC, '') <> '' THEN P.PROG_DESC ELSE P.PROG_COMMENTS END AS PROG_DESC, " &
            " P.START_DT, P.END_DT, dbo.Buyer_Name(im.byr_plnr) AS Buyer_Name,pim.VEND_NO , I.ITEM_CD, " & " item_comment_logo as ITEM_COMMENT_LOGO , " &
            " im.item_note_4 As 'DISCO', " &
            " I.ITEM_NO, I.ITEM_DESC, I.ITEM_COLOR, I.MIN_QTY_ORD, " &
            " I.UNIT_PRICE,I.EQP_LEVEL,I.EQP_COLUMN,I.EQP_PCT, " &
            " CONVERT(BIT, CASE WHEN P.APPROVED_DT IS NULL THEN 0 ELSE 1 END) AS IS_APPROVED, " &
            " P.APPROVED_BY_US, P.APPROVED_BY_THEM, P.APPROVED_DT, P.USER_LOGIN, P.UPDATE_TS " &
            " FROM	MDB_CUS_PROG P WITH (Nolock) " &
            " LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) ON P.CUS_PROG_ID = I.CUS_PROG_ID " &
            " LEFT JOIN  MDB_CFG_ENUM E WITH (NOLOCK) ON E.Enum_Cat = 'QUOTE_STEP_ID' AND P.Quote_Step_ID = E.enum_order  " &
            " LEFT JOIN  MDB_CFG_ENUM E1 ON I.QUOTE_TYPE_ID = E1.ID  " &
            " Left JOIN (Select user_def_fld_1,min(item_note_4) As item_note_4 ,byr_plnr,item_no from imitmidx_sql With (Nolock) group by user_def_fld_1,byr_plnr,item_no ) As im   " &
            "  On I.ITEM_NO  = im.item_no   LEFT JOIN ( select  p.vend_no,im.item_no,im.user_def_fld_1 FROM  " &
            " (select distinct  user_def_fld_1,MIN(item_no) as item_no  from imitmidx_sql  where  item_no Not Like 'AC%' and item_no " &
            " Not Like 'XX%' and item_no not like '%AST' and item_no not like '%Z%' and item_no not like '08%' and item_no not like '88%' AND item_no not  like 'USS%'  " &
            " And user_def_fld_2 Is Not NULL  group by user_def_fld_1) As im  left join  poitmvnd_sql p On im.item_no = p.item_no where p.approved_cd = 'P'   " &
            " group by p.vend_no, im.item_no, im.user_def_fld_1 ) As pim On (I.ITEM_NO  = pim.item_no  Or  '66'+I.ITEM_CD = pim.user_def_fld_1)  " &
            " INNER JOIN cicmpy c On P.CUS_NO = c.cmp_code " &
            " WHERE		P.PROG_TYPE = 1 "

            '"			Case When I.EQP_LEVEL = 0 Then I.UNIT_PRICE Else NULL End As UNIT_PRICE, " & _
            '          "			Case When I.EQP_LEVEL Is NULL Then P.EQP_LEVEL Else I.EQP_LEVEL End As EQP_LEVEL, " & _
            '          "			Case When I.EQP_LEVEL = 1 Then I.EQP_COLUMN Else NULL End As EQP_COLUMN, " & _
            '          "			Case When I.EQP_LEVEL = 1 Then I.EQP_PCT Else NULL End As EQP_PCT, " & _

            If Not (m_Show_All_Customers) Then
                strSql &= " And P.CUS_NO = '" & m_Customer.cmp_code & "' "
            End If

            If Not (m_Show_History And m_Show_Current) Then
                If m_Show_History Then
                    strSql &= " AND P.End_Dt < CONVERT(DATE, GETDATE()) "
                ElseIf m_Show_Current Then
                    strSql &= " AND P.End_Dt >= CONVERT(DATE, GETDATE()) "
                    'Ion -------- Added ElseIf
                ElseIf m_Show_Almost_Due Then
                    strSql &= " AND  P.End_Dt >=  (select DATEADD(DD,0,GETDATE()))" &
                                "  AND  P.End_Dt <= (select DATEADD(DD,45,GETDATE())) "
                    'Ion --------------
                End If
            End If

            strSql &= " order by P.CUS_NO asc "

            dtPrograms = db.DataTable(strSql)

            dgvPrograms.DataSource = dtPrograms
            dgvPrograms.AllowUserToAddRows = False

            'Ion added PROG_CSR 
            '"       CAST('' AS VARCHAR(30)) AS ITEM_COMMENT_LOGO, " &
            If dtSearch Is Nothing Then
                strSql =
                "SELECT CAST(0 AS INT) AS CUS_PROG_ID, " &
                "       CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " &
                "       CAST('' AS VARCHAR(30)) AS CUS_NO, " &
                "       CAST('' AS VARCHAR(100)) AS CMP_NAME, " &
                "       CAST('' AS VARCHAR(30)) AS SPECTOR_CD, " &
                "       CAST('' AS VARCHAR(30)) AS PROG_CD, " &
                "CAST(0 AS INT) AS Quote_Step_ID, CAST('' AS CHAR(60)) AS Quote_Step_Desc, " &
                "       CAST('' AS VARCHAR(20)) AS PROG_CSR, " &
                "       CAST('' AS VARCHAR(30)) AS PROG_DESC, " &
                "       CAST(NULL AS DATETIME) AS START_DT, " &
                "       CAST(NULL AS DATETIME) AS END_DT, " &
                 "       CAST('' AS VARCHAR(30)) AS BUYER_NAME, " &
                "       CAST('' AS VARCHAR(30)) AS VEND_NO, " &
                "       CAST('' AS VARCHAR(30)) AS ITEM_CD, " &
                "       CAST('' AS VARCHAR(30)) AS ITEM_COMMENT_LOGO, " &
                "       CAST('' AS VARCHAR(30)) AS DISCO ," &
                "       CAST('' AS VARCHAR(30)) AS ITEM_NO, " &
                "       CAST('' AS VARCHAR(100)) AS ITEM_DESC, " &
                "       CAST('' AS VARCHAR(20)) AS ITEM_COLOR, " &
                "       CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " &
                "       CAST(0 AS NUMERIC(13, 4)) AS UNIT_PRICE, " &
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_LEVEL, " &
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_COLUMN, " &
                "       CAST(0 AS NUMERIC(13, 4)) AS EQP_PCT, " &
                "       CAST(0 AS INT) AS IS_APPROVED, " &
                "       CAST('' AS VARCHAR(30)) AS APPROVED_BY_US, " &
                "       CAST('' AS VARCHAR(30)) AS APPROVED_BY_THEM, " &
                "       CAST('' AS VARCHAR(30)) AS APPROVED_DT, " &
                "       CAST('' AS VARCHAR(30)) AS USER_LOGIN, " &
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
            '+ID 25.03.2016--------
            dtExc = dtPrograms
            '----------------------
            dgvPrograms.Refresh()

            tssRecordCount.Text = "Records: " & dgvPrograms.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Call ApplyFilters()

    End Sub

    Private Sub dgvSearch_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        dgvSearch.BeginEdit(True)

    End Sub

    Private Sub dgv_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvPrograms.ColumnWidthChanged

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

    Private Sub dgvPrograms_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPrograms.DoubleClick

        Call Menu_Open()

    End Sub



    Private Sub dgvPrograms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPrograms.KeyDown

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

    Private Sub dgvOrders_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvPrograms.Scroll

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
                Case "CUS_NO", "CMP_NAME", "SPECTOR_CD", "PROG_CD", "Quote_Step_Desc", "PROG_DESC", "Buyer_Name", "VEND_NO", "ITEM_CD", "DISCO", "ITEM_NO",
                    "ITEM_DESC", "ITEM_COLOR", "APPROVED_BY_US", "APPROVED_BY_THEM", "USER_LOGIN" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "START_DT", "END_DT", "APPROVED_DT", "UPDATE_TS" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        'Ion search by date
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
            'Ion Added this if for 'AND'
            If GetSearchColumnsFilter <> "" Then
                GetSearchColumnsFilter &= " AND PROG_CSR = '" & Environment.UserName & "' "
            Else
                GetSearchColumnsFilter &= " PROG_CSR = '" & Environment.UserName & "' "
            End If
            'Ion
        End If

    End Function

    Private Sub dgvSearch_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSearch.Sorted

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


    Private Sub dgvSearch_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSearch.ColumnHeaderMouseClick

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


        '    If dgv.Name = "dgvSearch" Then
        '    .Add(DGVCalendarColumn("END_DT", "End Date", 70))
        '    Else
        '    .Add(DGVTextBoxColumn("END_DT", "End Date", 70))
        '                '    dgv.Columns(Columns.CreateDate).DefaultCellStyle.Format = "MM/dd/yyyy"
        '            End If
        ''-----------------------------

        ''.Add(DGVTextBoxColumn("START_DT", "Start Date", 70))
        ''.Add(DGVTextBoxColumn("END_DT", "End Date", 70))
        '.Add(DGVTextBoxColumn("Buyer_Name", "Buyer Name", 100))
        '.Add(DGVTextBoxColumn("VEND_NO", "VEND NO", 80))
        '.Add(DGVTextBoxColumn("ITEM_CD", "Item", 80))
        '.Add(DGVTextBoxColumn("DISCO", "DISCO", 100))
        '.Add(DGVTextBoxColumn("ITEM_NO", "SKU", 100))
        '.Add(DGVTextBoxColumn("ITEM_DESC", "IT.DESC", 100))
        '.Add(DGVTextBoxColumn("ITEM_COLOR", "IT.COLOR", 70))

        CUS_PROG_ID
        CUS_PROG_ITEM_LIST_ID
        CUS_NO
        CMP_NAME
        SPECTOR_CD
        PROG_CD

        Quote_Step_ID
        Quote_Step_Desc

        'Ion
        PROG_CSR
        'Ion
        PROG_DESC
        START_DT
        END_DT
        '++ID new field added 11.07.2016
        BUYER_NAME
        VEND_NO
        '------------------------------
        ITEM_CD
        '++ID new field added 11.07.2016
        DISCO
        '------------------------------
        ITEM_NO
        ITEM_DESC
        ITEM_COLOR
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

            Dim ofrm As New frmQuickProgram(m_Customer, "Program") '12.14.2017 "Program")
            'ofrm.Program_Type = "Program"
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
            'Ion------If dgvPr.......
            If dgvPrograms.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oProgram As New cMdb_Cus_Prog()
                Dim oProgramB As New cMdb_Cus_Prog_BUS

                '++ID 3.08.2015 I put in comment because each time when open each cus_prog_id, the function do update, for nothing.
                'oProgram = oProgramB.Load(dgvPrograms.CurrentRow.Cells(Columns.CUS_PROG_ID).Value)

                '++ID 3.08.2015 Added for filling only cMdb_Cus_Prog or only for create new Cus_Prog_Id
                oProgram = oProgramB.LoadPSQ(dgvPrograms.CurrentRow.Cells(Columns.CUS_PROG_ID).Value)


                If m_Customer Is Nothing Or m_Show_All_Customers Then
                    m_Customer = New cCustomer(oProgram.Cus_No)
                End If

                Dim ofrm As New frmQuickProgram(m_Customer, oProgram)
                ofrm.Program_Type = "Program"
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

            If dgvPrograms.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                'Ion 15.10.14
                Dim oProgram As New cMdb_Cus_Prog()
                Dim oCus_Prog As New cMdb_Cus_Prog_BUS()
                Dim oProgram_Rev As New cMdb_Cus_Prog_Rev_BLL()
                Dim oProgram_Comm As New cMdb_Prog_Comment()
                '  Dim oItemBll As New cMDB_CUS_PROG_ITEM_PRICE_BLL()
                Dim oItemBll As New cMdb_Cus_Prog_Item_List_BUS()
                Dim oCfg_Charge_Usage As New cMdb_Cfg_Charge_Usage()


                oProgram.Cus_Prog_Id = dgvPrograms.CurrentRow.Cells(Columns.CUS_PROG_ID).Value

                'cMdb_Cfg_Charge_Usage()
                oCfg_Charge_Usage.Cus_Prog_ID = oProgram.Cus_Prog_Id
                oCfg_Charge_Usage.DeleteAll() 'comment delete in the class

                'cMdb_Cus_Prog_Item_List
                oItemBll.Delete(dgvPrograms.CurrentRow.Cells(Columns.CUS_PROG_ITEM_LIST_ID).Value) 'comment delete in the class

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
    Private Sub SetPermissions(ByVal arr() As Object)

        For Each elem As Object In arr
            SetUser_Rights(User_Rights, elem.Tag)

            Select Case User_Rights
                Case "READWRITE"
                    elem.Visible = True
                Case "SUPERUSER"
                    elem.Visible = True
                Case "READONLY"
                    elem.Visible = False
            End Select
        Next

        '  SetUser_Rights(User_Rights, Me.Tag)

        User_Rights = "READONLY"

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
    Private Sub tscbPrograms_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbPrograms.SelectedIndexChanged

        m_Show_Current = (tscbPrograms.Text = "All Programs" Or tscbPrograms.Text = "Current Programs")
        m_Show_History = (tscbPrograms.Text = "All Programs" Or tscbPrograms.Text = "History Programs")
        'Ion ------ Added
        m_Show_Almost_Due = (tscbPrograms.Text = "All Programs" Or tscbPrograms.Text = "Almost Due")
        'Ion ----

        If Not m_Loading Then
            Menu_Refresh()
        End If
    End Sub

    Private Sub tsButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Try

            'Dim startDate, endDate As DateTime

            'Dim myStream As Stream = Nothing
            'Dim strAddress As String = "C:\ExactTemp\Program export " & Guid.NewGuid.ToString & ".xlsx"
            'Dim modExportToExcel As New modExportToExcel

            'startDate = PromptWindows("Start", "Start Date.")
            'endDate = PromptWindows("End", "End Date.")
            'Me.Cursor = Cursors.WaitCursor
            ''-----------------------------------------

            'Call modExportToExcel.DatatableToExcel(dtQuery(startDate, endDate), strAddress, progressBar, lab1)

            'Me.Cursor = Cursors.Default

            'Dim startInfo As New ProcessStartInfo
            'startInfo.FileName = strAddress
            'Process.Start(startInfo)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Function ExcelBtn(ByVal user_name As String) As Boolean
        Dim btn As Boolean = False
        ExcelBtn = btn
        Try
            Dim arr(1) As Object

            arr(0) = tsExcel
            arr(1) = tsProgressBarExcel

            SetPermissions(arr)


            'Select Case Trim(user_name)
            '    Case "pamelab", "krista", "lisa", "angela"
            '        btn = True
            '    Case "iond"
            '        btn = True
            '    Case "betty", "tania", "suzy"
            '        btn = True
            'End Select

            ExcelBtn = btn

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Sub ExcelBtn()
        Try
            Dim arr(0) As Object

            arr(0) = tsExcel
            '  arr(1) = progressBar

            SetPermissions(arr)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function PromptWindows(ByVal msg As String, ByVal tit As String) As Object
        PromptWindows = Nothing
        Try
            Dim message, title, defaultValue As String
            Dim myValue As Object
            ' Set prompt.
            message = "Enter " & msg & " date format 'YYYY/MM/DD'"
            ' Set title.
            title = tit '"Start Date."
            defaultValue = "1"   ' Set default value.

            ' Display message, title, and default value.
            myValue = InputBox(message, title, defaultValue)

            ' If user has clicked Cancel, set myValue to defaultValue 
            If myValue Is "" Then myValue = defaultValue

            ' Display dialog box at position 100, 100.
            '  myValue = InputBox(message, title, defaultValue, 100, 100)
            ' If user has clicked Cancel, set myValue to defaultValue 
            ' If myValue Is "" Then myValue = defaultValue

            PromptWindows = myValue

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function dtQuery(ByRef startDate As DateTime, ByRef endDate As DateTime) As DataTable
        dtQuery = Nothing
        Try
            db = New cDBA
            Dim strSql As String

            strSql =
                 " SELECT  P.CUS_PROG_ID, I.CUS_PROG_ITEM_LIST_ID, P.CUS_NO, c.cmp_name, P.SPECTOR_CD, P.PROG_CD, P.PROG_CSR,  " &
                 " CASE WHEN ISNULL(P.PROG_DESC, '') <> '' THEN P.PROG_DESC ELSE P.PROG_COMMENTS END AS PROG_DESC,  P.START_DT, P.END_DT, dbo.Buyer_Name(im.byr_plnr) AS Buyer_Name, " &
                 " pim.vend_no ,I.ITEM_CD,im.item_note_4 As 'Discontinued' ,I.ITEM_NO, I.ITEM_DESC, I.ITEM_COLOR, I.MIN_QTY_ORD, I.UNIT_PRICE,I.EQP_LEVEL,I.EQP_COLUMN,I.EQP_PCT, " &
                 " CONVERT(BIT, CASE WHEN P.APPROVED_DT IS NULL THEN 0 ELSE 1 END) AS IS_APPROVED,  P.APPROVED_BY_US, P.APPROVED_BY_THEM, " &
                 " P.APPROVED_DT, P.USER_LOGIN, P.UPDATE_TS   " &
                 " FROM  MDB_CUS_PROG P WITH (Nolock)  LEFT JOIN MDB_CUS_PROG_ITEM_LIST I WITH (Nolock)  " &
                 " ON P.CUS_PROG_ID = I.CUS_PROG_ID  " &
                 " LEFT JOIN (select user_def_fld_1,min(item_note_4) as item_note_4,byr_plnr,item_no from imitmidx_sql WITH (Nolock) group by user_def_fld_1,byr_plnr,item_no ) AS im  " &
                 " on I.ITEM_NO  = im.item_no  " &
                 " LEFT JOIN ( select  p.vend_no,im.item_no,im.user_def_fld_1 from  (select distinct  user_def_fld_1,MIN(item_no) as item_no  from imitmidx_sql " &
                 " where  item_no not like 'AC%' and item_no not like 'XX%' and item_no not like '%AST' and item_no not like '%Z%' and item_no not like '08%'" &
                 " and item_no not like '88%' AND item_no not  like 'USS%' AND user_def_fld_2 IS NOT NULL " &
                 " group by user_def_fld_1) AS im  left join  poitmvnd_sql p ON im.item_no = p.item_no where p.approved_cd = 'P'  " &
                 " group by p.vend_no,im.item_no,im.user_def_fld_1 ) AS pim on (I.ITEM_NO  = pim.item_no  or  '66'+I.ITEM_CD = pim.user_def_fld_1) " &
                 " INNER JOIN cicmpy c on P.CUS_NO = c.cmp_code  WHERE  P.PROG_TYPE = 1 AND P.START_DT > '" & startDate & "' " &
                 " AND P.End_Dt < '" & endDate & "'  order by P.START_DT desc "

            strSql =
                 "SELECT		P.CUS_PROG_ID, I.CUS_PROG_ITEM_LIST_ID, P.CUS_NO, c.cmp_name, P.SPECTOR_CD, P.PROG_CD, P.PROG_CSR, " _
          & " CASE WHEN ISNULL(P.PROG_DESC, '') <> '' THEN P.PROG_DESC ELSE P.PROG_COMMENTS END AS PROG_DESC, " _
           & " P.START_DT, P.END_DT, dbo.Buyer_Name(im.byr_plnr) AS Buyer_Name,pim.VEND_NO , I.ITEM_CD, im.item_note_4 As 'DISCO', " _
             & " I.ITEM_NO, I.ITEM_DESC, I.ITEM_COLOR, I.MIN_QTY_ORD, " _
           & " I.UNIT_PRICE,I.EQP_LEVEL,I.EQP_COLUMN,I.EQP_PCT, " _
            & " CONVERT(BIT, CASE WHEN P.APPROVED_DT IS NULL THEN 0 ELSE 1 END) AS IS_APPROVED, " _
           & " P.APPROVED_BY_US, P.APPROVED_BY_THEM, P.APPROVED_DT, P.USER_LOGIN, P.UPDATE_TS " _
           & " FROM		MDB_CUS_PROG P WITH (Nolock) " _
          & " LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) ON P.CUS_PROG_ID = I.CUS_PROG_ID " _
          & " Left JOIN (Select user_def_fld_1,min(item_note_4) As item_note_4 ,byr_plnr,item_no from imitmidx_sql With (Nolock) group by user_def_fld_1,byr_plnr,item_no ) As im   " _
           & "  On I.ITEM_NO  = im.item_no   LEFT JOIN ( select  p.vend_no,im.item_no,im.user_def_fld_1 FROM  " _
           & " (select distinct  user_def_fld_1,MIN(item_no) as item_no  from imitmidx_sql  where  item_no Not Like 'AC%' and item_no " _
          & " Not Like 'XX%' and item_no not like '%AST' and item_no not like '%Z%' and item_no not like '08%' and item_no not like '88%' AND item_no not  like 'USS%'  " _
          & " And user_def_fld_2 Is Not NULL  group by user_def_fld_1) As im  left join  poitmvnd_sql p On im.item_no = p.item_no where p.approved_cd = 'P'   " _
         & " group by p.vend_no, im.item_no, im.user_def_fld_1 ) As pim On (I.ITEM_NO  = pim.item_no  Or  '66'+I.ITEM_CD = pim.user_def_fld_1)  " _
         & " INNER JOIN cicmpy c On P.CUS_NO = c.cmp_code " _
          & " WHERE	not I.CUS_PROG_ITEM_LIST_ID is null and	P.PROG_TYPE = 1  AND P.START_DT BETWEEN '" & startDate & "' AND '" & endDate & "' "

            strSql &= " order by P.START_DT desc " '" order by P.CUS_NO asc "


            dtQuery = db.DataTable(strSql)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub tsExcel_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
        Try

            Dim startDate, endDate As DateTime

            Dim myStream As Stream = Nothing
            Dim strAddress As String = "C:\ExactTemp\Program export " & Guid.NewGuid.ToString & ".xlsx"
            Dim modExportToExcel As New modExportToExcel

            startDate = PromptWindows("Start", "Start Date.")
            endDate = PromptWindows("End", "End Date.")
            Me.Cursor = Cursors.WaitCursor
            '-----------------------------------------

            Call modExportToExcel.DatatableToExcel(dtQuery(startDate, endDate), strAddress, tsProgressBarExcel, tslblPercent)

            Me.Cursor = Cursors.Default

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strAddress
            Process.Start(startInfo)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class
