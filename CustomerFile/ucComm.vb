Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Text

Public Class ucComm

    Private User_Rights As String = "READONLY"

    Private dtCommunications As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA("DSN=Exact;")

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private m_Document As New CDocument

    Private m_Ord_Guid As String
    Private m_Item_Guid As String
    Private m_Cus_No As String

    Private blnLoading As Boolean = False
    Private dgvRow As DataGridViewRow
    Private intListDropIndex As Integer
    Private blnRenameFile As Boolean = False
    Private m_DateButton As Button

    Private m_Path As String = "c:\ExactTemp\"

    Private dtSave_Doc_Type_ID As DataTable

    Public Shadows Sub Load(pCustomer As cCustomer)

        Try

            Call SetPermissions()

            m_Customer = pCustomer

            If dtCommunications Is Nothing Then

                Call tscbSave_Doc_Type_ID_FillCombo()

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvComm)

                dgvSearch.ColumnHeadersHeight = 24
                'dgvCommunications.ColumnHeadersVisible = False

            End If

            If Not (m_Customer Is Nothing Or m_Customer.Equals(pCustomer)) Then

                Call ClearSearch()

            End If

            Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub Save()

    End Sub

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        Try

            With dgv.Columns

                .Add(DGVTextBoxColumn("Doc", "Doc", 20))
                .Add(DGVTextBoxColumn("DocType", "Type", 70))
                .Add(DGVTextBoxColumn("ExtType", "Ext Type", 70))
                .Add(DGVTextBoxColumn("Ord_No", "Ord No", 70))
                .Add(DGVTextBoxColumn("DocFrom", "From", 150))
                .Add(DGVTextBoxColumn("DocTo", "DocTo", 150))
                .Add(DGVTextBoxColumn("Subject", "Subject", 250))
                .Add(DGVCheckBoxColumn("NegativeFeed", "Negative", 70))
                .Add(DGVTextBoxColumn("NegativeReason", "Reason", 70))
                If dgv.Name = "dgvSearch" Then
                    .Add(DGVCalendarColumn("CreateDate", "Date", 120))
                Else
                    .Add(DGVTextBoxColumn("CreateDate", "Date", 120))
                    '    dgv.Columns(Columns.CreateDate).DefaultCellStyle.Format = "MM/dd/yyyy"
                End If
                .Add(DGVTextBoxColumn("CommID", "CommID", 70))

            End With

            With dgv

                .Columns(Columns.ExtType).Visible = False
                .Columns(Columns.Doc).Visible = False
                .Columns(Columns.NegativeReason).Visible = False
                .Columns(Columns.CommID).Visible = False

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

            If Not IsNumeric(txtLastDays.Text) Then
                txtLastDays.Text = "90"
            Else
                txtLastDays.Text = CInt("0" & txtLastDays.Text).ToString
                If txtLastDays.Text = "0" Then
                    txtLastDays.Text = "90"
                End If
            End If

            Dim strSql As String
            'strSql = "EXEC dbo.EXACT_TRAVELER_COMMUNICATIONS_LIST_20120717 '" & m_Customer.cmp_code.Trim & "', '', 1 "
            'strSql = "EXEC dbo.EXACT_TRAVELER_COMMUNICATIONS_LIST_20130805 '" & m_Customer.cmp_code.Trim & "', '', 1, " & txtLastDays.Text
            strSql = "EXEC dbo.EXACT_TRAVELER_COMMUNICATIONS_LIST_20140128 '" & m_Customer.cmp_code.Trim & "', '', 1, " & txtLastDays.Text

            dtCommunications = db.DataTable(strSql)

            dgvComm.DataSource = dtCommunications
            dgvComm.AllowUserToAddRows = False

            If dtSearch Is Nothing Then

                strSql = _
                "SELECT	CAST(0 AS INT) AS DOC, CAST('' AS VARCHAR(20)) AS DocType, " & _
                "       CAST('' AS VARCHAR(20)) AS ExtType, CAST('' AS VARCHAR(20)) AS Ord_No, " & _
                "       CAST('' AS VARCHAR(30)) AS DocFrom, CAST('' AS VARCHAR(30)) AS DocTo, " & _
                "		CAST('' AS VARCHAR(100)) as Subject, " & _
                "       CAST(NULL AS BIT) AS NegativeFeed, CAST('' AS VARCHAR(60)) AS NegativeReason, " & _
                "       CAST(NULL AS DATETIME) as CreateDate, CAST(0 AS INT) AS CommID "

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

            If dtCommunications Is Nothing Then Exit Sub

            Dim strFilter As String = ""
            Dim strSubFilter As String = ""

            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

            m_GlobalFilter = strFilter
            m_SearchFilter = GetSearchColumnsFilter()

            strFilter = ""

            If m_GlobalFilter <> "" Then strFilter = "(" & m_GlobalFilter & ")"
            If m_GlobalFilter <> String.Empty And m_SearchFilter <> String.Empty Then strFilter &= " AND "
            If m_SearchFilter <> "" Then strFilter &= "(" & m_SearchFilter & ")"

            dtCommunications.DefaultView.RowFilter = strFilter

            dgvComm.Refresh()

            tssRecordCount.Text = "Records: " & dgvComm.Rows.Count.ToString

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

    Private Sub dgvSearch_Sorted(sender As Object, e As System.EventArgs) Handles dgvSearch.Sorted

        Try
            Dim oColumn As DataGridViewColumn
            Dim oSortOrder As System.ComponentModel.ListSortDirection
            oColumn = dgvComm.Columns(dgvSearch.SortedColumn.Index)
            oSortOrder = dgvSearch.SortOrder

            If oSortOrder = 1 Then
                dgvComm.Sort(oColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                dgvComm.Sort(oColumn, System.ComponentModel.ListSortDirection.Descending)
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

                Case Columns.CreateDate

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

    Private Sub dgv_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvSearch.ColumnWidthChanged, dgvComm.ColumnWidthChanged

        Try

            Dim oSender As DataGridView
            oSender = DirectCast(sender, DataGridView)

            Dim dgv As DataGridView

            If oSender.Name = "dgvSearch" Then ' we inverse here cause we set the other grid
                dgv = dgvComm
            Else
                dgv = dgvSearch
            End If

            dgv.Columns(e.Column.Index).Width = e.Column.Width

            dgvSearch.HorizontalScrollingOffset = dgvComm.HorizontalScrollingOffset

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvCommunications_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs)
        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvComm.FirstDisplayedScrollingColumnIndex
        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString

                Case "DocType", "ExtType", "Ord_No", "DocFrom", "DocTo", "Subject"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                        Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                        GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

                Case "CreateDate" ' Date

                    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then

                        If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "

                        GetSearchColumnsFilter &= oColumn.Name & " >= #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & "# " _
                           & " AND  " & oColumn.Name & " < #" & dgvSearch.Rows(0).Cells(oColumn.Name).Value & " 23:59:59# "

                    End If

                Case "Doc", "CommID"

                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "

                            GetSearchColumnsFilter &= String.Format(oColumn.Name & " = '#{0}#'", New DateTime(dgvSearch.Rows(0).Cells(oColumn.Name).Value))

                            ' GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
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
        ExtType
        Ord_No
        DocFrom
        DocTo
        Subject
        NegativeFeed
        NegativeReason
        CreateDate
        CommID

    End Enum


    Private Sub dgvComm_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dgvComm.DoubleClick

        Call OpenCommunication()

    End Sub

    Private Sub OpenCommunication()

        'Call PreviewDoc()

        Dim iCommType As Integer

        Try

            If dgvComm.Rows.Count > 0 Then ' If dgvComm.CurrentRow.Index > 0 Then

                iCommType = CInt(dgvComm.CurrentRow.Cells(Columns.Doc).Value)

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Select Case iCommType

                    Case 1 ' Exact_Traveler_Document

                        Call PreviewDoc()

                    Case 2 ' Exact_Traveler_Email_Message

                        Dim ofrmEmail As New frmEmail(CInt(dgvComm.CurrentRow.Cells(Columns.CommID).Value))
                        ofrmEmail.Cus_No = m_Cus_No
                        ofrmEmail.ShowDialog()
                        'ofrmEmail.Dispose()
                        ofrmEmail = Nothing

                    Case 3 ' Exact_Traveler_Communications

                        Dim ofrmCommunication As New frmCommunication(CInt(dgvComm.CurrentRow.Cells(Columns.CommID).Value))
                        ofrmCommunication.ShowDialog()
                        'ofrmCommunication.Dispose()
                        ofrmCommunication = Nothing

                    Case 4 ' EXACT_TRAVELER_COMMENTS_ORDER_LEVEL

                    Case 5 ' MDB_CUS_DOCUMENT

                        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                        Dim iIndex As Integer = CInt(dgvComm.CurrentRow.Cells(Columns.CommID).Value)
                        Dim oDocument As New cMdb_Cus_Document(iIndex)
                        Dim ofrm As New frmDocumentView(oDocument)
                        ofrm.ShowDialog()

                        ofrm = Nothing


                End Select


                'SELECT 		1 AS DOC, 'Document' AS DocType, O.Ord_No, '' AS DocFrom, D.DocDescription AS Subject, D.CreateDate, D.DocID AS CommID
                'FROM 		Exact_Traveler_Document D WITH (Nolock) 
                'INNER JOIN	(
                '		SELECT Distinct Cus_No, Ord_No
                '		FROM Exact_Traveler_Header WITH (Nolock) 
                '		WHERE Cus_No = @Cus_No
                '		) O ON D.Ord_No = O.Ord_No
                'WHERE 		Doctypeid in (7, 16) AND O.Ord_No = @Ord_No AND DATEADD(DAY, @LastDays, D.CreateDate) > GETDATE()

                'UNION

                'SELECT 		2 AS DOC, 'Email' AS DocType, O.Ord_No, D.EmailFrom AS DocFrom, D.SubjectLine AS Subject, D.CreateDate, D.EmailID AS CommID
                'FROM 		Exact_Traveler_Email_Message D WITH (Nolock) 
                'INNER JOIN	(
                '		SELECT Distinct Cus_No, Ord_No
                '		FROM Exact_Traveler_Header WITH (Nolock) 
                '		WHERE Cus_No = @Cus_No
                '		) O ON D.Ord_No = O.Ord_No
                'WHERE		O.Ord_No = @Ord_No AND DATEADD(DAY, @LastDays, D.CreateDate) > GETDATE()

                'UNION

                'SELECT 		3 AS DOC, 'Dialog' AS DocType, C.Ord_No, C.CSR_Contact AS DocFrom, C.Subject, C.CreateDate, C.ID AS CommID
                'FROM 		Exact_Traveler_Communications C WITH (Nolock) 
                'WHERE 		Cus_No = @Cus_No AND Ord_No = @Ord_No AND Deleted = 0 AND DATEADD(DAY, @LastDays, C.CreateDate) > GETDATE()

                'UNION

                'SELECT 		4 AS DOC, 'Comment' AS DocType, COM.Ord_No, COM.UserID AS DocFrom, COM.Cmt AS Subject, COM.CreateDate, COM.ID AS CommID
                'FROM 		EXACT_TRAVELER_COMMENTS_ORDER_LEVEL COM WITH (Nolock) 
                'WHERE 		Ord_No = @Ord_No AND 1 = @Comments  AND DATEADD(DAY, @LastDays, COM.CreateDate) > GETDATE()

            End If

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsbDocumentClose_Click(sender As System.Object, e As System.EventArgs)

        panDocument.Visible = False

    End Sub

    Private Sub PreviewDoc()

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String

        Try

            m_Document = New CDocument()
            m_Document.Load(CInt(dgvComm.CurrentRow.Cells(Columns.CommID).Value))

            'If dgvFileList.Rows.Count <> 0 Then
            '    m_Document.Load(dgvFileList.Rows(dgvFileList.CurrentRow.Index))
            'End If

            Dim strPathAndFile As String
            'Dim strPathAndFile As String = gPath & m_Document.DocFile
            If m_Document.DocID <> 0 Then
                If Trim(m_Document.DocName) = "" Then
                    strPathAndFile = m_Path & m_Document.DocID
                Else
                    strPathAndFile = m_Path & m_Document.DocName
                End If

            Else
                strPathAndFile = m_Path & m_Document.DocFile ' Name
            End If

            'Dim strPathAndFile As String = gPath & m_Document.DocFile ' Name

            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Not (Directory.Exists(m_Path)) Then
                'If Dir(m_Path, FileAttribute.Directory) = "" Then
                MkDir(m_Path)
            End If

            '/////////////////////////////
            'Get the document from the database and write it to a temp file
            Dim mStream As New ADODB.Stream
            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()
            mStream.Write(m_Document.GetDocumentRow.Item("Document"))
            If m_Document.DocID <> 0 Then
                'mStream.Write(m_Document.GetDocumentRow.Item("Document"))
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            Else
                'mStream.Write(m_Document.GetDocumentImage())
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            End If

            'mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            '////////////////////////////////
            'Show the file
            Select Case Mid(strPathAndFile.ToUpper, strPathAndFile.Length - 3)

                Case ".MSG", ".XLS", "XLSX", ".DOC", "DOCX", ".BMP"
                    pnlPreviewDoc.Visible = False

                Case Else
                    pnlPreviewDoc.Visible = True

            End Select

            wbShowFile.Navigate(strPathAndFile) ', True) '1 = NewWindow
            'wbShowFile.Navigate(New System.Uri(strPathAndFile), True) '1 = NewWindow

            'End If

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try

    End Sub


    Private Sub txtLastDays_Leave(sender As Object, e As System.EventArgs) Handles txtLastDays.Leave

        Call FillGrid()

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
            "WHERE	    Active = 1 " & _
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

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ofrmCommunication As New frmCommunication(m_Customer.cmp_code)
            ofrmCommunication.ShowDialog()
            'ofrmCommunication.Dispose()
            ofrmCommunication = Nothing

            Call FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Call OpenCommunication()

        Call FillGrid()

    End Sub

    Private Sub Menu_Delete()

        Call FillGrid()

    End Sub

    Private Sub Menu_Refresh()

        Call FillGrid()

    End Sub


    Private Sub dgvComm_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles dgvComm.DragDrop

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

    Private Sub dgvComm_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles dgvComm.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then 'For email Drag & Drop 
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

   

    Private Sub dgvComm_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles dgvComm.DragOver

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub dgvComm_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvComm.KeyDown

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

    Private Sub AddDocumentFiles(ByRef Files As String())

        Try

            dgvComm.AllowUserToAddRows = True

            panProgress.Visible = True

            pbProgress.Value = 0
            pbProgress.Maximum = Files.Length

            txtPBEvent.Refresh()

            ' Loop through the array and add the files to the list.
            For Each strFile As String In Files

                txtPBDocument.Text = strFile
                txtPBDocument.Refresh()

                Dim oDocument As New cMdb_Cus_Document(strFile)
                oDocument.Cus_No = m_Customer.cmp_code
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

            dgvComm.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            panProgress.Visible = False
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

    End Sub
    '++ID 9.1.15
    Private Sub dgvComm_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvComm.DragLeave
        Try

            Debug.Print(" dgvComm_DragLeave : " & dgvComm.CurrentRow.Index.ToString)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID 9.1.15
    Private Sub dgvComm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvComm.MouseMove
        Try

            If (e.Button & MouseButtons.Left) <> MouseButtons.Left Then
                Debug.Print("dgvComm_MouseMove :  X." & e.X & vbCrLf & "Y." & e.Y)

                Dim hti As DataGridView.HitTestInfo = dgvComm.HitTest(e.X, e.Y)


                dgvComm.Rows(hti.RowIndex).Selected = True

                Dim index As Int32 = dgvComm.Rows(hti.RowIndex).Index

                Debug.Print("dgvComm_MouseMove dgvComm.RowIndex : " & index.ToString)

            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

  
End Class
