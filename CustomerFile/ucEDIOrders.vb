Public Class ucEDIOrders

    Private User_Rights As String = "READONLY"

    Private dtComments As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private dgvCombo As New DataGridViewComboBoxCell

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            m_Customer = pCustomer

            If dtComments Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvOrders)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvComments.ColumnHeadersVisible = False

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

                .Add(DGVTextBoxColumn("Cus_Comment_ID", "Cus_Comment_ID", 45))
                .Add(DGVTextBoxColumn("Cus_No", "Cus_No", 175))
                .Add(DGVTextBoxColumn("Comment_Type_ID", "Comment Type", 70))
                .Add(DGVTextBoxColumn("Comment_Type_Desc", "Comment Type", 125))
                .Add(DGVTextBoxColumn("Cus_Comment", "Comment", 450))
                .Add(DGVTextBoxColumn("Comment_Order", "Order", 325))
                .Add(DGVTextBoxColumn("User_Login", "User Login", 100))
                .Add(DGVTextBoxColumn("Update_TS", "Date Modified", 125))

            End With

            dgv.Columns(Columns.Cus_Comment_ID).Visible = False
            dgv.Columns(Columns.Cus_No).Visible = False
            dgv.Columns(Columns.Comment_Type_ID).Visible = False
            dgv.Columns(Columns.Comment_Order).Visible = False

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
            "SELECT		C.Cus_Comment_ID, C.Cus_No, C.Comment_Type_ID, CT.Comment_Type_Desc, " & _
            "           RTRIM(C.Cus_Comment) AS Cus_Comment, " & _
            "			ISNULL(C.Comment_Order, 0) AS Comment_Order, " & _
            "			RTRIM(C.User_Login) AS User_Login, C.Update_TS " & _
            "FROM		MDB_CUS_COMMENT C WITH (Nolock) " & _
            "INNER JOIN MDB_CFG_COMMENT_TYPE CT WITH (Nolock) ON C.Comment_Type_ID = CT.Comment_Type_ID " & _
            "WHERE		C.Cus_No = '" & m_Customer.cmp_code & "' " & _
            "ORDER BY	ISNULL(C.Comment_Order, 0) "

            dtComments = db.DataTable(strSql)

            dgvOrders.DataSource = dtComments
            dgvOrders.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = "SELECT " & _
                "CAST(0 AS INT) AS Cus_Comment_ID, " & _
                "CAST('' AS VARCHAR(20)) AS Cus_No, " & _
                "CAST(0 AS INT) AS Comment_Type_ID, " & _
                "CAST('' AS VARCHAR(50)) AS Comment_Type_Desc, " & _
                "CAST('' as VARCHAR(2048)) AS Cus_Comment, " & _
                "CAST(0 AS INT) AS Comment_Order, " & _
                "CAST('' AS VARCHAR(20)) AS User_Login, " & _
                "CAST(NULL AS datetime) AS Update_TS "

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

            If dtComments Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtComments.DefaultView.RowFilter = strFilter
            dgvOrders.Refresh()

            tssRecordCount.Text = "Records: " & dgvOrders.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Try

            Select Case e.ColumnIndex

                'Case Columns.Cus_Comment_ID
                '    e.Cancel = True
                'Case Columns.Cus_No
                '    e.Cancel = True
                Case Columns.Comment_Type_ID
                    e.Cancel = True
                    'Case Columns.Comment_Type_Desc
                    '    e.Cancel = True
                    'Case Columns.Cus_Comment
                    '    e.Cancel = True
                Case Columns.Comment_Order
                    e.Cancel = True
                    'Case Columns.User_Login
                    '    e.Cancel = True

                Case Columns.Update_TS
                    e.Cancel = True

            End Select

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
            oColumn = dgvOrders.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvOrders.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvOrders.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvOrders.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvOrders
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvOrders.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvComments_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOrders.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvComments_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvOrders.KeyDown

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

    Private Sub dgvComments_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvOrders.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvOrders.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "Cus_No", "Comment_Type_Desc", "Cus_Comment", "User_Login"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "Cus_Comment_ID", "Comment_Order", "Comment_Type_ID" ' Numeric

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

        Cus_Comment_ID
        Cus_No
        Comment_Type_ID
        Comment_Type_Desc
        Cus_Comment
        Comment_Order
        User_Login
        Update_TS

    End Enum

    Private Sub ucComments_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus

        Debug.Print("GOTFOCUS " & Date.Now.ToString)

    End Sub


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

            Dim ofrmMdb_Cus_Comment As New frmMdb_Cus_Comment(m_Customer)
            ofrmMdb_Cus_Comment.ShowDialog()

            ofrmMdb_Cus_Comment = Nothing

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim oCus_Ship As New cMdb_Cus_Comment(dgvOrders.CurrentRow.Cells(Columns.Cus_Comment_ID).Value)
            Dim ofrm As New frmMdb_Cus_Comment(m_Customer, oCus_Ship)
            ofrm.ShowDialog()

            ofrm = Nothing

            Call FillGrid()

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
