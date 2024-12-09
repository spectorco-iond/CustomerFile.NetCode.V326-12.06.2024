Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO

Public Class ucDocument

    Private User_Rights As String = "READONLY"

    Private dtDocuments As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private dgvCombo As New DataGridViewComboBoxCell

    Private m_strCus_No As String
    Private m_strOrd_Guid As String
    Private m_strItem_Guid As String
    Private m_strCus_Prog_Guid As String
    Private m_DocTypeID As String

    Private m_oDocument As CDocument
    Private m_oCus_Document As cMdb_Cus_Document
    'Private m_oProgram As cMdb_Cus_Prog
    Private dtSave_Doc_Type_ID As DataTable

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            'm_Customer = pCustomer
            m_strCus_No = pCustomer.cmp_code

            Call Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Shadows Sub Load(pProgram As cMdb_Cus_Prog)

        Try

            Call SetPermissions()

            'm_oProgram = pProgram
            m_strCus_No = pProgram.Cus_No
            m_strCus_Prog_Guid = pProgram.Cus_Prog_Guid

            Call Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Shadows Sub Load()

        Try

            If dtDocuments Is Nothing Then

                Call tscbSave_Doc_Type_ID_FillCombo()

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvDocuments)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvDocuments.ColumnHeadersVisible = False

            End If

            'If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

            '    Call ClearSearch()

            'End If

            Call FillGrid()
            Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetPermissions()

        SetUser_Rights(User_Rights, Me.Tag)

        Select Case User_Rights
            Case "READWRITE"
                tsbNew.Enabled = False 'True
                tsbDelete.Enabled = True

            Case "SUPERUSER"
                tsbNew.Enabled = False 'True
                tsbDelete.Enabled = True

            Case "READONLY"
                tsbNew.Enabled = False
                tsbDelete.Enabled = False

        End Select

    End Sub

    Public Sub Save()

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("CUS_DOCUMENT_ID", "CUS_DOCUMENT_ID", 100))
                .Add(DGVTextBoxColumn("DOC_TYPE_ID", "DOC_TYPE_ID", 100))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 100))
                .Add(DGVTextBoxColumn("CUS_CONTACT_ID", "CUS_CONTACT_ID", 100))
                .Add(DGVTextBoxColumn("MAIN_CUS_DOC_ID", "MAIN_CUS_DOC_ID", 100))
                .Add(DGVTextBoxColumn("DOCUMENT_DESC", "DOCUMENT_DESC", 400))
                .Add(DGVTextBoxColumn("DOCUMENT_PATH", "DOCUMENT_PATH", 100))
                .Add(DGVTextBoxColumn("DOCUMENT_EXT", "DOCUMENT_EXT", 100))
                .Add(DGVTextBoxColumn("CUS_PROG_GUID", "CUS_PROG_GUID", 100))
                '.Add(DGVTextBoxColumn("DOCUMENT_DATA", "DOCUMENT_DATA", 100))
                .Add(DGVTextBoxColumn("USER_LOGIN", "USER_LOGIN", 100))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE_TS", 100))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE_TS", 100))

            End With

            dgv.Columns(Columns.CUS_DOCUMENT_ID).Visible = False
            dgv.Columns(Columns.DOC_TYPE_ID).Visible = False
            dgv.Columns(Columns.CUS_NO).Visible = False
            dgv.Columns(Columns.CUS_CONTACT_ID).Visible = False
            dgv.Columns(Columns.MAIN_CUS_DOC_ID).Visible = False
            dgv.Columns(Columns.DOCUMENT_PATH).Visible = False
            dgv.Columns(Columns.DOCUMENT_EXT).Visible = False
            dgv.Columns(Columns.CUS_PROG_GUID).Visible = False
            dgv.Columns(Columns.USER_LOGIN).Visible = False
            dgv.Columns(Columns.CREATE_TS).Visible = False
            dgv.Columns(Columns.UPDATE_TS).Visible = False

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
            "SELECT	    CUS_DOCUMENT_ID, DOC_TYPE_ID, CUS_NO, CUS_CONTACT_ID, " & _
            "           MAIN_CUS_DOC_ID, DOCUMENT_DESC, DOCUMENT_PATH, DOCUMENT_EXT, " & _
            "           CUS_PROG_GUID, USER_LOGIN, CREATE_TS, UPDATE_TS " & _
            "FROM		MDB_CUS_DOCUMENT D WITH (Nolock) " & _
            "WHERE		CUS_NO = '" & m_strCus_No & "' "

            If m_strCus_Prog_Guid <> String.Empty Then strSql &= "AND CUS_PROG_GUID = '" & m_strCus_Prog_Guid & "' "

            dtDocuments = db.DataTable(strSql)

            dgvDocuments.DataSource = dtDocuments
            dgvDocuments.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = "SELECT CAST (0 AS INT) AS CUS_DOCUMENT_ID, " & _
                "CAST (0 AS INT) AS DOC_TYPE_ID, " & _
                "CAST ('' AS VARCHAR(20)) AS CUS_NO, " & _
                "CAST (0 AS INT) AS CUS_CONTACT_ID, " & _
                "CAST (0 AS INT) AS MAIN_CUS_DOC_ID, " & _
                "CAST ('' AS VARCHAR(100)) AS DOCUMENT_DESC, " & _
                "CAST ('' AS VARCHAR(500)) AS DOCUMENT_PATH, " & _
                "CAST ('' AS VARCHAR(10)) AS DOCUMENT_EXT, " & _
                "CAST ('' AS VARCHAR(40)) AS CUS_PROG_GUID, " & _
                "CAST ('' AS VARCHAR(20)) AS USER_LOGIN, " & _
                "CAST (NULL AS DATETIME) AS CREATE_TS, " & _
                "CAST (NULL AS DATETIME) AS UPDATE_TS "

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

            If dtDocuments Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtDocuments.DefaultView.RowFilter = strFilter
            dgvDocuments.Refresh()

            tssRecordCount.Text = "Records: " & dgvDocuments.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Try
            Select Case e.ColumnIndex

                Case Columns.CUS_DOCUMENT_ID
                    e.Cancel = True
                Case Columns.CUS_DOCUMENT_ID
                    e.Cancel = True
                Case Columns.DOC_TYPE_ID
                    e.Cancel = True
                Case Columns.CUS_NO
                Case Columns.CUS_CONTACT_ID
                    e.Cancel = True
                Case Columns.MAIN_CUS_DOC_ID
                    e.Cancel = True
                Case Columns.DOCUMENT_DESC
                Case Columns.DOCUMENT_PATH
                Case Columns.DOCUMENT_EXT
                    'Case Columns.DOCUMENT_DATA
                    '    e.Cancel = True
                Case Columns.USER_LOGIN
                Case Columns.CREATE_TS
                    e.Cancel = True
                Case Columns.UPDATE_TS
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
            oColumn = dgvDocuments.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvDocuments.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvDocuments.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvDocuments.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvDocuments
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvDocuments.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocuments_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDocuments.DoubleClick

        Call Menu_Open()

    End Sub

    Private Sub dgvDocuments_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDocuments.KeyDown

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

    Private Sub dgvDocuments_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvDocuments.Scroll

        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvDocuments.FirstDisplayedScrollingColumnIndex

        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If

    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString
                Case "DOCUMENT_DESC", "USER_LOGIN"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

            End Select

        Next oColumn

    End Function

    Private Sub dgvDocuments_DragEnter(ByVal sender As Object, ByVal e As  _
                System.Windows.Forms.DragEventArgs) Handles dgvDocuments.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then 'For email Drag & Drop 
            e.Effect = DragDropEffects.Copy
        End If

    End Sub


    Private Sub dgvDocuments_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvDocuments.MouseMove

        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim iIndex As Integer = dgvDocuments.CurrentRow.Cells(Columns.CUS_DOCUMENT_ID).Value
                Dim oDocument As New cMdb_Cus_Document(iIndex)
                'DoDragDrop(oDocument.SaveToDataObject, DragDropEffects.Copy)

                Dim strFilenames(0) As String
                ReDim Preserve strFilenames(1)
                strFilenames(0) = "C:\FILES\CH Bleu.JPG"

                'DoDragDrop(New DataObject(DataFormats.FileDrop, True, strFilenames), DragDropEffects.All)

                Dim data_object As New DataObject()

                '' = oDocument.SaveToFileName
                '' Add the data in various formats.
                data_object.SetData(DataFormats.FileDrop, True, strFilenames)
                ''data_object.SetData(DataFormats.Text, rchSource.Text)
                dgvDocuments.DoDragDrop(data_object, DragDropEffects.Copy)

            End If

            ''Dim ellipse = TryCast(sender, Ellipse)
            'If dgvDocuments.Rows.Count > 0 And e.LeftButton = MouseButtonState.Pressed Then
            '    DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy)
            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocuments_DragDrop(ByVal sender As Object, ByVal e As  _
                System.Windows.Forms.DragEventArgs) Handles dgvDocuments.DragDrop

        Try

            If tscbSave_Doc_Type_ID.ComboBox.SelectedIndex = 0 Then
                MsgBox("You must first select what type of document you want to save the file under.")
                Exit Sub
            End If

            Dim MyFiles() As String

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                ' Assign the files to an array.
                MyFiles = e.Data.GetData(DataFormats.FileDrop)

                AddDocumentFiles(MyFiles)

            ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then

                Dim objOL As New Microsoft.Office.Interop.Outlook.Application
                Dim objMI As Microsoft.Office.Interop.Outlook.MailItem
                ReDim MyFiles(1)

                MyFiles(0) = ""
                Dim iPos As Integer = 0
                For Each objMI In objOL.ActiveExplorer.Selection()
                    ReDim Preserve MyFiles(iPos)
                    'hardcode a destination path for testing
                    Dim strFile As String = _
                                IO.Path.Combine("c:\ExactTemp", _
                                                ("-" & objMI.Subject + ".msg").Replace(":", "").Replace("/", "_").Replace("*", ".").Replace("?", "."))
                    objMI.SaveAs(strFile)
                    MyFiles(iPos) = strFile
                    iPos += 1

                Next

                AddDocumentFiles(MyFiles)

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocuments_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvDocuments.DragOver

        'Dim this_list As ListView = DirectCast(sender, ListView)
        'Dim pt As Point = this_list.PointToClient(New Point(e.X, e.Y))
        'intListDropIndex = this_list.GetItemAt(pt.X, pt.Y).Index
        'lvTypes.View = View.Details
        ''this_list.SelectedItems.Clear()
        'this_list.Items(intListDropIndex).Selected = True
        'If pt.Y < 23 Then this_list.EnsureVisible(intListDropIndex - 1)
        'If pt.Y > this_list.Height - 21 Then
        '    this_list.EnsureVisible(intListDropIndex + 1)
        'End If

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub AddDocumentFiles(ByRef Files As String())

        Try

            dgvDocuments.AllowUserToAddRows = True

            panProgress.Visible = True

            pbProgress.Value = 0
            pbProgress.Maximum = Files.Length

            txtPBEvent.Refresh()

            ' Loop through the array and add the files to the list.
            For Each strFile As String In Files

                txtPBDocument.Text = strFile
                txtPBDocument.Refresh()

                Dim oDocument As New cMdb_Cus_Document(strFile)
                oDocument.Cus_No = m_strCus_No
                oDocument.Cus_Prog_Guid = m_strCus_Prog_Guid
                oDocument.Doc_Type_Id = tscbSave_Doc_Type_ID.SelectedIndex
                oDocument.Save()

                'Dim n As Integer = dgvDocuments.Rows.Add()
                'With dgvDocuments.Rows.Item(n)

                '    .Cells(Columns.CUS_DOCUMENT_ID).Value = oDocument.Cus_Document_Id
                '    .Cells(Columns.DOC_TYPE_ID).Value = oDocument.Cus_Document_Id
                '    .Cells(Columns.CUS_NO).Value = oDocument.Cus_No
                '    .Cells(Columns.CUS_CONTACT_ID).Value = oDocument.Cus_Contact_Id
                '    .Cells(Columns.MAIN_CUS_DOC_ID).Value = oDocument.Main_Cus_Doc_Id
                '    .Cells(Columns.CUS_PROG_GUID).Value = oDocument.Cus_Prog_Guid
                '    .Cells(Columns.USER_LOGIN).Value = oDocument.User_Login
                '    .Cells(Columns.CREATE_TS).Value = oDocument.Create_Ts
                '    .Cells(Columns.UPDATE_TS).Value = oDocument.Update_Ts

                'End With

                pbProgress.Increment(1)
                panProgress.Invalidate()

            Next

            Call FillGrid()

            dgvDocuments.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            panProgress.Visible = False
        End Try

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

    Private Sub tscbSave_Doc_Type_ID_FillCombo()

        Dim strSql As String
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		0 AS DocTypeID, '' AS DocType " & _
            "UNION " & _
            "SELECT		DocTypeID, ISNULL(DocType, '') AS DocType " & _
            "FROM		EXACT_TRAVELER_XREF_DOCTYPE WITH (Nolock) " & _
            "WHERE		Active = 1 " & _
            "ORDER BY   DocType "

            dtSave_Doc_Type_ID = db.DataTable(strSql)
            tscbSave_Doc_Type_ID.ComboBox.DataSource = dtSave_Doc_Type_ID

            tscbSave_Doc_Type_ID.ComboBox.DisplayMember = "DocType"
            tscbSave_Doc_Type_ID.ComboBox.ValueMember = "DocTypeID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_New()

    End Sub

    Private Sub Menu_Open()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim iIndex As Integer = dgvDocuments.CurrentRow.Cells(Columns.CUS_DOCUMENT_ID).Value
            Dim oDocument As New cMdb_Cus_Document(iIndex)
            Dim ofrm As New frmDocumentView(oDocument)
            ofrm.ShowDialog()

            ofrm = Nothing

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim iIndex As Integer = dgvDocuments.CurrentRow.Cells(Columns.CUS_DOCUMENT_ID).Value
            Dim oDocument As New cMdb_Cus_Document(iIndex)
            oDocument.Hide()

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Refresh()

        Call FillGrid()

    End Sub

    Public Property SearchVisible() As Boolean
        Get
            SearchVisible = panExtSearch.Visible
        End Get
        Set(value As Boolean)
            panExtSearch.Visible = value
        End Set
    End Property

    Public Property Cus_Prog_Guid() As String
        Get
            Cus_Prog_Guid = m_strCus_Prog_Guid
        End Get
        Set(value As String)
            m_strCus_Prog_Guid = value
        End Set
    End Property

    Private Enum Columns
        CUS_DOCUMENT_ID
        DOC_TYPE_ID
        CUS_NO
        CUS_CONTACT_ID
        MAIN_CUS_DOC_ID
        DOCUMENT_DESC
        DOCUMENT_PATH
        DOCUMENT_EXT
        'DOCUMENT_DATA
        CUS_PROG_GUID
        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum



End Class
