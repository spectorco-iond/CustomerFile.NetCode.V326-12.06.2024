Public Class ucProduction

    Private User_Rights As String = "READONLY"

    Private dtProduction As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            m_Customer = pCustomer

            If dtProduction Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvProduction)

                dgvSearch.ColumnHeadersHeight = 24
                dgvProduction.ColumnHeadersVisible = False

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
                .Add(DGVTextBoxColumn("Cus_No", "Cus_No", 70))
                .Add(DGVTextBoxColumn("Ord_Type", "T", 20))
                .Add(DGVTextBoxColumn("RMA_No", "RMA_No", 70))
                .Add(DGVTextBoxColumn("Ord_No", "Ord No", 70))
                '.Add(DGVTextBoxColumn("Ord_Dt", "Ord Dt", 90))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("Ord_Dt", "Ord Dt", 90))
                Else
                    .Add(DGVTextBoxColumn("Ord_Dt", "Ord Dt", 90))
                End If
                .Add(DGVTextBoxColumn("Inv_No", "Inv No", 70))
                '.Add(DGVTextBoxColumn("Inv_Dt", "Inv Dt", 90))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("Inv_Dt", "Inv Dt", 90))
                Else
                    .Add(DGVTextBoxColumn("Inv_Dt", "Inv Dt", 90))
                End If
                .Add(DGVTextBoxColumn("Ct_Ord_No", "Ct_Ord_No", 70))
                .Add(DGVTextBoxColumn("Ct_Inv_No", "Ct_Inv_No", 70))
                .Add(DGVTextBoxColumn("OE_Po_No", "PO Number", 110))
                .Add(DGVTextBoxColumn("Tot_Dollars", "Amount", 70))
                .Add(DGVTextBoxColumn("Bill_To_Name", "Bill_To_Name", 100))
                .Add(DGVTextBoxColumn("Tot_Sls_Amt", "Tot_Sls_Amt", 70))
                .Add(DGVTextBoxColumn("Shipping_Status", "Shipping", 120))
                .Add(DGVTextBoxColumn("User_def_Fld_4", "User_def_Fld_4", 120))
                .Add(DGVTextBoxColumn("Nb_Travelers", "Nb_Travelers", 50))
                .Add(DGVTextBoxColumn("LinesShipped", "LinesShipped", 50))
                .Add(DGVTextBoxColumn("NotShipped", "NotShipped", 50))
                .Add(DGVTextBoxColumn("PartialShipped", "PartialShipped", 50))
                .Add(DGVTextBoxColumn("CompleteShipped", "CompleteShipped", 50))
                '.Add(DGVTextBoxColumn("ShippedDate", "Shipped Date", 90))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("ShippedDate", "Shipped Date", 90))
                Else
                    .Add(DGVTextBoxColumn("ShippedDate", "Shipped Date", 90))
                End If
                .Add(DGVTextBoxColumn("Line_Count", "Lines", 40))
                .Add(DGVTextBoxColumn("Has_Bo", "BO", 40))
                .Add(DGVTextBoxColumn("BO_Count", "BO_Count", 40))
                .Add(DGVTextBoxColumn("Repeat_From", "Repeat_From", 70))
                .Add(DGVTextBoxColumn("Repeat_To", "Repeat_To", 70))
                .Add(DGVTextBoxColumn("Extra_1", "Extra_1", 70))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVTextBoxColumn("Extra_2", "Extra_2", 70))
                Else
                    .Add(DGVTextBoxColumn("Extra_2", "Extra_2", 50))
                End If
            End With

            'Call dgvProduction_ShowColumns()

            'Call dgvProduction_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ClearSearch()

    End Sub

    Private Sub FillGrid()

        Try

            Dim strSql As String
            strSql = "EXEC DBO.QUERY '"

            dtProduction = db.DataTable(strSql)

            dgvProduction.DataSource = dtProduction
            dgvProduction.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                'strSql = "SELECT " & _
                '"CAST('' AS CHAR(4)) AS PredCode, CAST('' AS VARCHAR(100)) AS FullName, " & _
                '"CAST('' AS VARCHAR(30)) AS OMS30_0, CAST('' as CHAR(25)) AS cnt_f_tel, " & _
                '"CAST('' AS CHAR(128)) AS cnt_email, CAST('' AS CHAR(25)) AS cnt_f_fax, " & _
                '"CAST(NULL AS INT) AS ID "

                'dtSearch = db.DataTable(strSql)
                'dgvSearch.DataSource = dtSearch
                'dgvSearch.AllowUserToAddRows = False

            End If

            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ApplyFilters()

        Try

            If dtProduction Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtProduction.DefaultView.RowFilter = strFilter
            dgvProduction.Refresh()

            tssRecordCount.Text = "Records: " & dgvProduction.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvProduction.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvProduction
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvProduction.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvProduction_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvProduction.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvProduction_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvProduction.KeyDown

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

    Private Sub dgvProduction_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvProduction.Scroll
        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvProduction.FirstDisplayedScrollingColumnIndex
        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "Cus_No", "Ord_Type", "RMA_No", "Ord_No", "Inv_No", "Ct_Ord_No", "Ct_Inv_No", "OE_Po_No", _
                     "Bill_To_Name", "Shipping_Status", "User_def_Fld_4", "NotShipped", "PartialShipped", _
                     "CompleteShipped", "Has_Bo", "BO_Count", "Repeat_From", "Repeat_To", "Extra_1", "Extra_2" ' String

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        '                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
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

        Doc
        DocType
        Ord_No
        DocFrom
        Subject
        CreateDate
        ID

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
