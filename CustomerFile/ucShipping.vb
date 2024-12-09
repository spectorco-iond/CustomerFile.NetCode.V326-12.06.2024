Public Class ucShipping

    Private User_Rights As String = "READONLY"

    Private dtShipping As DataTable
    Private dtSearch As DataTable


    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            m_Customer = pCustomer

            If dtShipping Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvShipping)

                dgvSearch.ColumnHeadersHeight = 24
                dgvShipping.ColumnHeadersVisible = False

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
                .Add(DGVTextBoxColumn("CUS_SHIP_ID", "CUS_SHIP_ID", 70))
                .Add(DGVTextBoxColumn("GROUP_CD", "Group", 80))
                .Add(DGVTextBoxColumn("CUS_NO", "Customer", 70))
                .Add(DGVTextBoxColumn("CUS_ALT_ADR_CD", "Alt. Address", 80))
                .Add(DGVTextBoxColumn("COUNTRY_CD", "Country", 50))
                .Add(DGVTextBoxColumn("PROG_ID", "PROG_ID", 70))
                .Add(DGVTextBoxColumn("PROG_CD", "Program", 120))
                .Add(DGVTextBoxColumn("SHIP_VIA_CD", "SHIP_VIA_CD", 70))
                .Add(DGVTextBoxColumn("SHIP_VIA_DESC", "Ship Via", 120))
                .Add(DGVTextBoxColumn("SHIP_VIA_ACCOUNT", "Ship Account", 300))
                .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 50))
                .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 50))
                .Add(DGVTextBoxColumn("PRINTER_COMMENT", "Printer Comments", 100))
                .Add(DGVTextBoxColumn("PRINTER_INSTRUCTIONS", "Printer Instructions", 100))
                .Add(DGVTextBoxColumn("PACKER_COMMENT", "Packer Comments", 100))
                .Add(DGVTextBoxColumn("PACKER_INSTRUCTIONS", "Packer instructions", 100))
                .Add(DGVTextBoxColumn("SHIP_INSTRUCTIONS_1", "Ship Instructions 1", 100))
                .Add(DGVTextBoxColumn("SHIP_INSTRUCTIONS_2", "Ship Instructions 2", 100))
                .Add(DGVTextBoxColumn("CMT_WHEN_SELECTED", "CMT_WHEN_SELECTED", 100))
                .Add(DGVCheckBoxColumn("NO_CHARGE", "N/C", 70))
                .Add(DGVCheckBoxColumn("SAMPLES_ONLY", "Samp Only", 70))
                .Add(DGVTextBoxColumn("USER_LOGIN", "USER_LOGIN", 70))
                '.Add(DGVTextBoxColumn("Ord_Dt", "Ord Dt", 90))

                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("UPDATE_TS", "UPDATE_TS", 90))
                Else
                    .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE_TS", 70))
                End If
            End With

            With dgv

                .Columns(Columns.CUS_SHIP_ID).Visible = False
                .Columns(Columns.PROG_ID).Visible = False
                .Columns(Columns.SHIP_VIA_CD).Visible = False
                .Columns(Columns.CMT_WHEN_SELECTED).Visible = False

            End With

            'Call FillGrid()

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
            strSql = _
            "SELECT		S.CUS_SHIP_ID, S.GROUP_CD, S.CUS_NO, S.CUS_ALT_ADR_CD, S.COUNTRY_CD, " & _
            "			S.PROG_ID, ISNULL(P.PROG_CD, '') AS PROG_CD, S.SHIP_VIA_CD, " & _
            "           ISNULL(C.CODE_DESC, '') AS SHIP_VIA_DESC, " & _
            "           CASE WHEN ISNULL(S.SHIP_COMMENTS, '') <> '' THEN S.SHIP_COMMENTS ELSE S.SHIP_VIA_ACCOUNT END AS SHIP_VIA_ACCOUNT, " & _
            "           S.ALWAYS_USE, S.NEVER_USE, S.PRINTER_COMMENT, " & _
            "			S.PRINTER_INSTRUCTIONS, S.PACKER_COMMENT, S.PACKER_INSTRUCTIONS, " & _
            "			S.SHIP_INSTRUCTIONS_1, S.SHIP_INSTRUCTIONS_2, " & _
            "			S.CMT_WHEN_SELECTED, S.NO_CHARGE, S.SAMPLES_ONLY, S.USER_LOGIN, S.UPDATE_TS " & _
            "FROM		MDB_CUS_SHIP S WITH (Nolock) " & _
            "LEFT JOIN  MDB_CUS_PROG P WITH (NOLOCK) ON S.PROG_ID = P.CUS_PROG_ID " & _
            "LEFT JOIN  SYCDEFIL_SQL C WITH (Nolock) ON S.SHIP_VIA_CD = C.SY_CODE AND Cd_Type = 'V' " & _
            "WHERE		S.CUS_NO = '" & m_Customer.cmp_code.Trim & "' " & _
            "ORDER BY	S.CUS_SHIP_ID "

            dtShipping = db.DataTable(strSql)

            dgvShipping.DataSource = dtShipping
            dgvShipping.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = _
                "SELECT	CAST(0 AS int) AS CUS_SHIP_ID, " & _
                "		CAST('' AS VARCHAR(80)) AS GROUP_CD, " & _
                "		CAST('' AS VARCHAR(20)) AS CUS_NO, " & _
                "		CAST('' AS VARCHAR(15)) AS CUS_ALT_ADR_CD, " & _
                "		CAST('' AS VARCHAR(3)) AS COUNTRY_CD, " & _
                "		CAST(0 AS int) AS PROG_ID, " & _
                "		CAST('' AS VARCHAR(20)) AS PROG_CD, " & _
                "		CAST('' AS VARCHAR(3)) AS SHIP_VIA_CD, " & _
                "		CAST('' AS VARCHAR(30)) AS SHIP_VIA_DESC, " & _
                "		CAST('' AS VARCHAR(20)) AS SHIP_VIA_ACCOUNT, " & _
                "		CAST(0 AS INT) AS ALWAYS_USE, " & _
                "		CAST(0 AS INT) AS NEVER_USE, " & _
                "		CAST('' AS VARCHAR(500)) AS PRINTER_COMMENT, " & _
                "		CAST('' AS VARCHAR(500)) AS PRINTER_INSTRUCTIONS, " & _
                "		CAST('' AS VARCHAR(500)) AS PACKER_COMMENT, " & _
                "		CAST('' AS VARCHAR(500)) AS PACKER_INSTRUCTIONS, " & _
                "		CAST('' AS VARCHAR(40)) AS SHIP_INSTRUCTIONS_1, " & _
                "		CAST('' AS VARCHAR(40)) AS SHIP_INSTRUCTIONS_2, " & _
                "		CAST('' AS VARCHAR(500)) AS CMT_WHEN_SELECTED, " & _
                "		CAST(0 AS INT) AS NO_CHARGE, " & _
                "		CAST(0 AS INT) AS SAMPLES_ONLY, " & _
                "		CAST('' AS VARCHAR(20)) AS USER_LOGIN, " & _
                "		CAST(NULL AS datetime) AS UPDATE_TS "

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

            If dtShipping Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtShipping.DefaultView.RowFilter = strFilter
            dgvShipping.Refresh()

            tssRecordCount.Text = "Records: " & dgvShipping.Rows.Count.ToString

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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvShipping.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvShipping
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvShipping.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvShipping_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvShipping.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvShipping_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvShipping.KeyDown

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

    Private Sub dgvShipping_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvShipping.Scroll
        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvShipping.FirstDisplayedScrollingColumnIndex
        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "GROUP_CD", "CUS_NO", "CUS_ALT_ADR_CD", "COUNTRY_CD", "PROG_CD", _
                     "SHIP_VIA_CD", "SHIP_VIA_DESC", "SHIP_VIA_ACCOUNT", "PRINTER_COMMENT", _
                     "PRINTER_INSTRUCTIONS", "PACKER_COMMENT", "PACKER_INSTRUCTIONS", _
                     "SHIP_INSTRUCTIONS_1", "SHIP_INSTRUCTIONS_2", "USER_LOGIN" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "UPDATE_TS" ' Date
                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "

                        GetSearchColumnsFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
                          & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "

                        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    End If

                Case "CUS_SHIP_ID", "PROG_ID", "ALWAYS_USE", "NEVER_USE", _
                     "NO_CHARGE", "SAMPLES_ONLY" ' Numeric

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

    Private Enum Columns

        CUS_SHIP_ID
        GROUP_CD
        CUS_NO
        CUS_ALT_ADR_CD
        COUNTRY_CD
        PROG_ID
        PROG_CD
        SHIP_VIA_CD
        SHIP_VIA_DESC
        SHIP_VIA_ACCOUNT
        ALWAYS_USE
        NEVER_USE
        PRINTER_COMMENT
        PRINTER_INSTRUCTIONS
        PACKER_COMMENT
        PACKER_INSTRUCTIONS
        SHIP_INSTRUCTIONS_1
        SHIP_INSTRUCTIONS_2
        CMT_WHEN_SELECTED
        NO_CHARGE
        SAMPLES_ONLY
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

            'Dim oCus_Ship As New cMdb_Cus_Ship(m_Customer) ' dgvShipping.CurrentRow.Cells(Columns.CUS_SHIP_ID).Value)
            Dim ofrm As New frmMDB_CUS_SHIP(m_Customer)
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

            If dgvShipping.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oCus_Ship As New cMdb_Cus_Ship(dgvShipping.CurrentRow.Cells(Columns.CUS_SHIP_ID).Value)
                Dim ofrm As New frmMDB_CUS_SHIP(m_Customer, oCus_Ship)
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
        Dim oCus_Ship As New cMdb_Cus_Ship()
        Try
            If dgvShipping.Rows.Count <> 0 Then

                oCus_Ship.Cus_Ship_Id = dgvShipping.CurrentRow.Cells(Columns.CUS_SHIP_ID).Value
                oCus_Ship.Delete()

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

End Class
