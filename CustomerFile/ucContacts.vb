Public Class ucContacts

    Private User_Rights As String = "READONLY"

    Private dtContacts As DataTable
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

            If dtContacts Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvContacts)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvContacts.ColumnHeadersVisible = False

            End If

            If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

                Call ClearSearch()

            End If

            Call FillGrid()
            Call ApplyFilters()

            'dgvCombo.Items.Add("")
            'dgvCombo.Items.Add("Ligne 1")
            'dgvCombo.Items.Add("Ligne 2")
            'dgvCombo.Items.Add("Ligne 3")
            ''dgvCombo.Value = ""
            ' ''dgvCombo.

            'dgvContacts(6, 7) = dgvCombo
            'dgvContacts(6, 7).ValueType = dgvCombo.ValueType

            'dgvContacts(6, 5) = dgvCombo
            'dgvContacts(6, 5).ValueType = dgvCombo.ValueType

            'dgvContacts(4, Columns.Value) = dgvCombo
            'dgvContacts(4, Columns.Value).ValueType = dgvCombo.ValueType

            'dgvContacts(6, Columns.Value) = dgvCombo
            'dgvContacts(6, Columns.Value).ValueType = dgvCombo.ValueType


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub Save()

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("ID", "ID", 70))
                .Add(DGVTextBoxColumn("PredCode", "Pred", 45))
                .Add(DGVTextBoxColumn("FullName", "Full Name", 250))
                .Add(DGVTextBoxColumn("TaalCode", "TaalCode", 45))
                .Add(DGVTextBoxColumn("OMS30_0", "Language", 70))
                .Add(DGVTextBoxColumn("cnt_f_tel", "Phone Number", 100))
                .Add(DGVTextBoxColumn("cnt_email", "Email Address", 250))
                .Add(DGVTextBoxColumn("cnt_f_fax", "Fax Number", 100))
                .Add(DGVTextBoxColumn("Alternate_CSR", "Alternate CSR", 100))
                '.Add(DGVCheckBoxColumn("Active_y", "Active/Inactive", 70))
                '.Add(DGVTextBoxColumn("Value", "Value", 70))

            End With

            dgv.Columns(Columns.ID).Visible = False
            dgv.Columns(Columns.TaalCode).Visible = False

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
            strSql =
            "SELECT		C.ID, c.PredCode, c.FullName, ISNULL(C.TaalCode, '') AS TaalCode, " &
            "           T.OMS30_0 AS OMS30_0, RTRIM(ISNULL(C.cnt_f_tel, '')) + ' ' + RTRIM(ISNULL(C.cnt_f_ext, '')) AS cnt_f_tel, " &
            "           RTRIM(C.cnt_email) AS cnt_email, RTRIM(C.cnt_f_fax) AS cnt_f_fax, ISNULL(H.Fullname, '') AS Alternate_CSR  " &
            "FROM		cicntp C WITH (Nolock) " &
            "LEFT JOIN	taal T WITH (Nolock) ON C.taalcode = T.taalcode " &
            "LEFT JOIN  humres H WITH (Nolock) ON C.NumberField1 = H.Res_ID " &
           "WHERE	ISNULL(C.active_y,0) = 1 And C.cmp_wwn = '" & m_Customer.cmp_wwn & "' " &
            "ORDER BY	C.FullName "




            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            dtContacts = db.DataTable(strSql)

            dgvContacts.DataSource = dtContacts
            dgvContacts.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = "SELECT CAST(NULL AS INT) AS ID, " &
                "CAST('' AS CHAR(4)) AS PredCode, CAST('' AS VARCHAR(100)) AS FullName, " &
                "CAST('' AS CHAR(3)) AS TaalCode, CAST('' AS VARCHAR(30)) AS OMS30_0, CAST('' as VARCHAR(25)) AS cnt_f_tel, " &
                "CAST('' AS CHAR(128)) AS cnt_email, CAST('' AS VARCHAR(25)) AS cnt_f_fax, CAST('' AS VARCHAR(64)) AS Alternate_CSR "

                dtSearch = db.DataTable(strSql)
                dgvSearch.DataSource = dtSearch
                dgvSearch.AllowUserToAddRows = False

            End If

            Call ApplyFilters()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ApplyFilters()

        Try

            If dtContacts Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " And "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtContacts.DefaultView.RowFilter = strFilter
            dgvContacts.Refresh()

            tssRecordCount.Text = "Records: " & dgvContacts.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Try
            Select Case e.ColumnIndex

                'Case Columns.PredCode
                '    e.Cancel = True
                'Case Columns.FullName
                '    e.Cancel = True
                'Case Columns.OMS30_0
                '    e.Cancel = True
                'Case Columns.cnt_f_tel
                '    e.Cancel = True
                'Case Columns.cnt_email
                '    e.Cancel = True
                'Case Columns.cnt_f_fax
                '    e.Cancel = True
                Case Columns.ID
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
            oColumn = dgvContacts.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvContacts.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvContacts.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvContacts.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvContacts
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvContacts.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvContacts_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvContacts.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvContacts_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvContacts.KeyDown

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

    Private Sub dgvContacts_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvContacts.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvContacts.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "PredCode", "FullName", "TaalCode", "OMS30_0", "cnt_f_tel", "cnt_email", "cnt_f_fax", "Alternate_CSR"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "

                    End If
                    'Case "Active_y"
                    '    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value = 1 Then
                    '        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                    '        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value
                    '        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                    '    Else
                    '        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                    '        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value
                    '        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                    '    End If

            End Select

        Next oColumn

    End Function

    Private Enum Columns

        ID
        PredCode
        FullName
        TaalCode
        OMS30_0
        cnt_f_tel
        cnt_email
        cnt_f_fax
        Alternate_CSR

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

            Dim ofrmContact As New frmCustomerContact(m_Customer)
            ofrmContact.ShowDialog()

            ofrmContact = Nothing

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try
            'Ion----If dgvCont.........
            If dgvContacts.Rows.Count <> 0 Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim oContact As New cCicntp(dgvContacts.CurrentRow.Cells(Columns.ID).Value)
                Dim ofrm As New frmCustomerContact(m_Customer, oContact)
                ofrm.ShowDialog()

                ofrm = Nothing

                Call FillGrid()
            End If

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Try

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Menu_Refresh()

        Call FillGrid()

    End Sub

    Private Sub SetPermissions()

        SetUser_Rights(User_Rights, Me.Tag)

        '++ID put in comment tsbDelete because delete contact must be only from the Synergy

        Select Case User_Rights
            Case "READWRITE"
                tsbNew.Enabled = True
              '  tsbDelete.Enabled = True

            Case "SUPERUSER"
                tsbNew.Enabled = True
              '  tsbDelete.Enabled = True

            Case "READONLY"
                tsbNew.Enabled = False
                '  tsbDelete.Enabled = False

        End Select

    End Sub

End Class
