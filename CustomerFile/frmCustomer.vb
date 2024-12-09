Imports System.Globalization
Imports System.IO

Public Class frmCustomer

    Private User_Rights As String = "READONLY"

    Private dtCustomers As DataTable
    Private dtSearch As DataTable

    Private m_Customer As cCustomer
    Private db As New cDBA()

    Private m_GlobalFilter As String
    Private m_SearchFilter As String

    Private m_NoLoad As Boolean = False

    Private Sub CreateColumns(ByRef dgv As DataGridView)

        ' Try

        '    With dgv.Columns

        '        .Add(DGVTextBoxColumn("CUS_NO", "Cus No", 60))
        '        .Add(DGVTextBoxColumn("CUS_NAME", "Customer Name", 200))
        '        .Add(DGVTextBoxColumn("ADDR_1", "Address 1", 150))
        '        .Add(DGVTextBoxColumn("ADDR_2", "Address 2", 150))
        '        .Add(DGVTextBoxColumn("ADDR_3", "Address 3", 100))
        '        .Add(DGVTextBoxColumn("CITY", "City", 100))
        '        .Add(DGVTextBoxColumn("STATE", "State", 40))
        '        .Add(DGVTextBoxColumn("ZIP", "Zip", 40))
        '        .Add(DGVTextBoxColumn("COUNTRY", "Country", 40))
        '        .Add(DGVTextBoxColumn("PHONE_NO", "Phone number", 100))
        '        .Add(DGVTextBoxColumn("SLSPSN_NO", "CSR", 30))
        '        .Add(DGVTextBoxColumn("SLSPSN_NO_DESC", "CSR Name", 120))
        '        .Add(DGVTextBoxColumn("CUS_NOTE_1", "EQP Status", 50))
        '        .Add(DGVTextBoxColumn("CLASSIFICATIONID", "Star Lvl", 50))
        '        .Add(DGVTextBoxColumn("CUS_NOTE_3", "Group", 50))
        '        '.Add(DGVTextBoxColumn("SHIP_VIA_CD", "SHIP_VIA_CD", 50))
        '        '.Add(DGVTextBoxColumn("SHIP_VIA_CD_DESC", "SHIP_VIA_CD_DESC", 50))
        '        '.Add(DGVTextBoxColumn("AR_TERMS_CD", "AR_TERMS_CD", 50))
        '        '.Add(DGVTextBoxColumn("AR_TERMS_CD_DESC", "AR_TERMS_CD_DESC", 50))
        '        .Add(DGVTextBoxColumn("TXBL_FG", "Tax", 20))
        '        .Add(DGVTextBoxColumn("ALLOW_BO", "BO", 20))
        '        .Add(DGVTextBoxColumn("ALLOW_PART_SHIP", "Part Ship", 20))

        '        dgv.Columns(Customers.CUS_NO).Frozen = True
        '        dgv.Columns(Customers.CUS_NAME).Frozen = True
        '        dgv.Columns(Customers.SLSPSN_NO).Visible = False

        '    End With

        'Catch er As Exception
        '    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        'End Try

        Try
            '++ID 6.1.15
            With dgv.Columns

                .Add(DGVTextBoxColumn("CUS_NO", "Cus No", 60))
                .Add(DGVTextBoxColumn("CUS_NAME", "Customer Name", 200))
                '++ID 29.12.14
                .Add(DGVTextBoxColumn("CUS_NOTE_1", "EQP Status", 50))
                .Add(DGVTextBoxColumn("CLASSIFICATIONID", "Star Lvl", 50))

                .Add(DGVTextBoxColumn("ADDR_1", "Address 1", 150))
                .Add(DGVTextBoxColumn("ADDR_2", "Address 2", 150))
                .Add(DGVTextBoxColumn("ADDR_3", "Address 3", 100))
                .Add(DGVTextBoxColumn("CITY", "City", 100))
                .Add(DGVTextBoxColumn("STATE", "State", 40))
                .Add(DGVTextBoxColumn("ZIP", "Zip", 40))
                .Add(DGVTextBoxColumn("COUNTRY", "Country", 40))
                .Add(DGVTextBoxColumn("PHONE_NO", "Phone number", 100))
                .Add(DGVTextBoxColumn("SLSPSN_NO", "CSR", 30))
                .Add(DGVTextBoxColumn("SLSPSN_NO_DESC", "CSR Name", 120))

                '  .Add(DGVTextBoxColumn("CUS_NOTE_1", "EQP Status", 50))
                '  .Add(DGVTextBoxColumn("CLASSIFICATIONID", "Star Lvl", 50))

                .Add(DGVTextBoxColumn("CUS_NOTE_3", "Group", 50))
                '.Add(DGVTextBoxColumn("SHIP_VIA_CD", "SHIP_VIA_CD", 50))
                '.Add(DGVTextBoxColumn("SHIP_VIA_CD_DESC", "SHIP_VIA_CD_DESC", 50))
                '.Add(DGVTextBoxColumn("AR_TERMS_CD", "AR_TERMS_CD", 50))
                '.Add(DGVTextBoxColumn("AR_TERMS_CD_DESC", "AR_TERMS_CD_DESC", 50))
                .Add(DGVTextBoxColumn("TXBL_FG", "Tax", 20))
                .Add(DGVTextBoxColumn("ALLOW_BO", "BO", 20))
                .Add(DGVTextBoxColumn("ALLOW_PART_SHIP", "Part Ship", 20))

                dgv.Columns(Customers.CUS_NO).Frozen = True
                dgv.Columns(Customers.CUS_NAME).Frozen = True
                dgv.Columns(Customers.SLSPSN_NO).Visible = False
                dgv.Columns(Customers.SLSPSN_NO_DESC).Visible = True
                dgv.Columns(Customers.CUS_NOTE_3).Visible = True
                dgv.Columns(Customers.TXBL_FG).Visible = False
                dgv.Columns(Customers.ALLOW_BO).Visible = False
                dgv.Columns(Customers.ALLOW_PART_SHIP).Visible = False


            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub FillGrid()

        Try
            '++ID 6.1.15
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim strSql As String =
           "SELECT		C.CUS_NO, C.CUS_NAME, H.FULLNAME AS SLSPSN_NO_DESC, C.CUS_NOTE_1," &
           " C.ADDR_1, C.ADDR_2, C.ADDR_3, C.CITY, " &
           "  C.STATE, C.ZIP, C.COUNTRY, C.PHONE_NO, C.SLSPSN_NO, " &
           "  P.CLASSIFICATIONID, " &
           "  C.CUS_NOTE_3, C.TXBL_FG, C.ALLOW_BO, C.ALLOW_PART_SHIP " &
           "FROM		ARCUSFIL_SQL C " &
           "LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " &
           "LEFT JOIN HUMRES H ON P.ACCOUNTEMPLOYEEID = H.RES_ID " &
           " where cmp_status <> 'E'    ORDER BY	C.CUS_NO "

            dtCustomers = db.DataTable(strSql)

            dgvCust.DataSource = dtCustomers
            dgvCust.AllowUserToAddRows = False

            strSql = "SELECT " & _
            "CAST('' AS VARCHAR(20)) AS CUS_NO, CAST('' AS VARCHAR(50)) AS CUS_NAME, " & _
         "   CAST('' AS CHAR(40)) AS SLSPSN_NO_DESC, CAST('' AS VARCHAR(80)) AS CUS_NOTE_1," & _
            "CAST('' AS VARCHAR(100)) AS ADDR_1, CAST('' AS VARCHAR(100)) AS ADDR_2, " & _
            "CAST('' AS VARCHAR(100)) AS ADDR_3, CAST('' AS VARCHAR(100)) AS CITY, " & _
            "CAST('' AS CHAR(3)) AS STATE, CAST('' AS VARCHAR(20)) AS ZIP, " & _
            "CAST('' AS CHAR(3)) AS COUNTRY, CAST('' AS CHAR(25)) AS PHONE_NO, " & _
            "CAST(NULL AS INT) AS SLSPSN_NO,  CAST('' AS CHAR(25)) AS CLASSIFICATIONID, " & _
            "CAST('' AS VARCHAR(80)) AS CUS_NOTE_3, CAST('' AS VARCHAR(1)) AS TXBL_FG, " & _
            "CAST('' AS VARCHAR(1)) AS ALLOW_BO, " & _
            "CAST('' AS VARCHAR(1)) AS ALLOW_PART_SHIP"

            dtSearch = db.DataTable(strSql)

            dgvSearch.DataSource = dtSearch
            dgvSearch.AllowUserToAddRows = False

            Call ApplyFilters()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
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
            Debug.Print("01: " & strFilter)
            dtCustomers.DefaultView.RowFilter = strFilter
            Debug.Print("02: " & strFilter)
            dgvCust.Refresh()
            Debug.Print("03: " & strFilter)

            tssRecordCount.Text = "Records: " & dgvCust.Rows.Count.ToString

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSearch_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEndEdit

        Dim strCustomer As String = ""

        If dgvCust.Rows.Count = 1 Then
            strCustomer = dgvCust.Rows(0).Cells(Customers.CUS_NO).Value
        End If

        Call ApplyFilters()

        If dgvCust.Rows.Count = 1 Then
            If strCustomer <> dgvCust.Rows(0).Cells(Customers.CUS_NO).Value Then
                Call OpenCustomer()
            End If
        Else
            'Debug.Print("dgvCust.Focus()")
            'dgvCust.Focus()
        End If

    End Sub

    Private Sub dgvSearch_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellEnter

        dgvSearch.BeginEdit(True)

    End Sub


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

    Private Sub dgvCust_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvCust.DoubleClick

        Try

            Call OpenCustomer()

            'If Not (IsNothing(dgvCust.CurrentRow.Cells(Customers.CUS_NO))) Then

            '    Dim strCustomer As String
            '    strCustomer = dgvCust.CurrentRow.Cells(Customers.CUS_NO).Value.ToString.Trim

            '    Dim oCustomer As New cCustomer(strCustomer)
            '    Dim oHeader As New frmCustomerHeader(oCustomer)
            '    oHeader.ShowDialog()
            '    oHeader.Dispose()

            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCust_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCust.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Return ' Open element
                    Call OpenCustomer()

                Case Keys.Insert ' Insert a new element
                    ' Nothing to do here

                Case Keys.Delete ' Delete current element
                    ' Nothing to do here

                Case Keys.F5
                    Call FillGrid()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvOrders_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles dgvCust.Scroll
        dgvSearch.FirstDisplayedScrollingColumnIndex = dgvCust.FirstDisplayedScrollingColumnIndex
        If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
            dgvSearch.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Private Function GetSearchColumnsFilter() As String

        GetSearchColumnsFilter = ""

        For Each oColumn As DataGridViewColumn In dgvSearch.Columns

            Select Case oColumn.Name.ToString

                'CHECK NUMERIC FIELDS ENTRY
                Case "SLSPSN_NO"
                    If IsNumeric(dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim) Then
                        If dgvSearch.Rows(0).Cells(oColumn.Name).Value <> 0 Then
                            'If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                            GetSearchColumnsFilter &= oColumn.Name & " = " & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim & " "
                        End If
                    Else
                        If Not (dgvSearch.Rows(0).Cells(oColumn.Name).Value.Equals(DBNull.Value)) Then
                            MsgBox("Value of field " & oColumn.HeaderText & " is not numeric.")
                        End If
                    End If

                    'CHECK DATE FIELDS ENTRY
                    'Case "Ord_Dt", "Inv_Dt", "ShippedDate" ' Date

                    '    If dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim <> "" Then
                    '        'GetSearchColumnsFilter = oColumn.Name & " LIKE '%" & dgvSearch.Rows(1).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%'"
                    '    End If


                Case "CUS_NAME"

                    If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim <> "" Then
                        'If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= IIf(rbAndSearch.Checked, " AND ", " OR ")
                        If dgvSearch.Rows(0).Cells(oColumn.Name.ToString).Value.ToString.Trim.Contains("@") Then
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                            Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                            Dim strContact As String =
                            "select DISTINCT cmp.Cmp_Code " &
                            "from cicmpy cmp with (nolock) " &
                            "inner join cicntp cnt with (nolock) on cnt.cmp_wwn = cmp.cmp_wwn " &
                            "where cnt_email = '" & strSearchText.Trim & "' AND cnt.active_y = 1 "
                            Dim dtContact As DataTable
                            dtContact = db.DataTable(strContact)
                            If dtContact.Rows.Count <> 0 Then
                                strContact = "CUS_NO IN ("
                                For Each dtRow As DataRow In dtContact.Rows
                                    strContact &= "'" & dtRow.Item("Cmp_Code").ToString.Trim & "', "
                                Next
                                strContact = strContact.Substring(0, strContact.Length - 2)
                                strContact &= ") "
                                GetSearchColumnsFilter &= "(" & strContact & " OR (" & GetLikeCondition(oColumn.Name, strSearchText) & "))"
                            Else
                                GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                            End If
                        Else
                            If GetSearchColumnsFilter.Trim <> "" Then GetSearchColumnsFilter &= " AND "
                            Dim strSearchText As String = dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''")
                            GetSearchColumnsFilter &= GetLikeCondition(oColumn.Name, strSearchText)
                        End If
                        'GetSearchColumnsFilter &= oColumn.Name & " LIKE '%" & dgvSearch.Rows(0).Cells(oColumn.Name).Value.ToString.Trim.Replace("'", "''") & "%' "
                    End If

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

        Debug.Print(GetSearchColumnsFilter)

    End Function

    Private Enum Customers

        CUS_NO
        CUS_NAME
        '++ID 6.1.15
        CUS_NOTE_1 ' EQP
        CLASSIFICATIONID ' STARS

        ADDR_1
        ADDR_2
        ADDR_3
        CITY
        STATE
        ZIP
        COUNTRY
        PHONE_NO
        SLSPSN_NO
        SLSPSN_NO_DESC

        ' CUS_NOTE_1 ' EQP
        '  CLASSIFICATIONID ' STARS

        CUS_NOTE_3 ' GROUP
        'SHIP_VIA_CD
        'SHIP_VIA_CD_DESC
        'AR_TERMS_CD
        'AR_TERMS_CD_DESC
        TXBL_FG
        ALLOW_BO
        ALLOW_PART_SHIP

    End Enum

    'Private Sub rbSearch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOrSearch.CheckedChanged, rbAndSearch.CheckedChanged

    '    Call ApplyFilters()

    'End Sub

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

    Private Sub frmCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try
            varIdentIfCustFormIsOpen = True

            Dim _assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

            Dim fileInfo As New System.IO.FileInfo(_assembly.Location)

            Dim lastModified = fileInfo.LastWriteTime


            lblVersion.Text = Version()
            '"Version :" & " " & _assembly.GetName.Version.ToString & "; Date :  " & lastModified.ToString("dd-MM-yyyy hh:mm tt") & ";"

            ' This will open Customer straight when sent from command line
            Call OpenCustomerFile()

            If m_NoLoad Then Exit Sub

            If dtCustomers Is Nothing Then

                Call CreateColumns(dgvSearch)
                Call CreateColumns(dgvCust)

                dgvSearch.ColumnHeadersHeight = 24
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

    Private Sub OpenCustomerFile()

        Try
            'If Environment.UserName.ToUpper <> "MARCB" Then Exit Sub

            ' Retrieve & Store the Command Line Parameters  
            Dim cmdLineParams As String() = Environment.GetCommandLineArgs()

            ' Check for command Line Parameter (if any)   
            If cmdLineParams.Length >= 1 Then

                Dim strCustomer As String
                strCustomer = cmdLineParams(1)

                Dim oCustomer As New cCustomer(strCustomer)
                Dim oHeader As New frmCustomerHeader(oCustomer)

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

                oHeader.ShowDialog()
                oHeader = Nothing

                m_NoLoad = True

                Me.Close()

            End If

        Catch ex As Exception
            '  MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub OpenCustomer()

        Try

            If Not (IsNothing(dgvCust.CurrentRow.Cells(Customers.CUS_NO))) Then

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Dim strCustomer As String
                strCustomer = dgvCust.CurrentRow.Cells(Customers.CUS_NO).Value.ToString.Trim

                Dim oCustomer As New cCustomer(strCustomer)
                Dim oHeader As New frmCustomerHeader(oCustomer)

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

                oHeader.ShowDialog()
                oHeader = Nothing

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    '    Try

    '        With New cMail
    '            .FromAddr = "marcb@spectorandco.com"
    '            .ToAddr = "marcbeauregard@yahoo.com"
    '            .Subject = "Salut beau mec !"
    '            .Message = "Salut Marc, Comment ca roule ?"
    '            .Send()
    '        End With

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim oFrm As New frmQuote_Step_Request(3, 2, 3)

        oFrm.ShowDialog()

        Debug.Print(oFrm.Request_User & "  Proceed: " & oFrm.Proceed.ToString & "   Send Request: " & oFrm.Send_Request.ToString)

        oFrm.Dispose()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim oFrm As New frmSpectorControl

        oFrm.Show()

        'oFrm.Dispose()

    End Sub

    Private Sub tsmQuotes_Click(sender As System.Object, e As System.EventArgs) Handles tsmQuotes.Click, QuoteToolStripMenuItem1.Click

        Dim oQuotes As New frmQuotes()
        oQuotes.Show()

        'oQuotes.Dispose()       

    End Sub

    Private Sub tsmExit_Click(sender As System.Object, e As System.EventArgs) Handles tsmExit.Click

        Me.Close()

    End Sub

    Private Sub tsmPrograms_Click(sender As System.Object, e As System.EventArgs) Handles tsmPrograms.Click, ProgramsToolStripMenuItem1.Click

        Dim oPrograms As New frmPrograms()
        oPrograms.Show()

    End Sub

    Private Sub tsmSpecialPricing_Click(sender As System.Object, e As System.EventArgs) Handles tsmSpecialPricing.Click, SpecialPriceToolStripMenuItem.Click

        Dim oSpecialPricing As New frmSpecialPricing()
        oSpecialPricing.Show()

    End Sub

    Private Sub tsmOrders_Click(sender As System.Object, e As System.EventArgs) Handles tsmOrders.Click

        Dim oOrders As New frmOrders()
        oOrders.Show()

    End Sub


    Private Sub tsmOptions_Click(sender As System.Object, e As System.EventArgs) Handles tsmOptions.Click

        Dim oOptions As New frmOptions()
        oOptions.Show()

    End Sub


    '---------------------------------------------------------------------------------------------------
    ' I put in comment because I have questions with  MailBee.SMTP, it should run after remove the comments
    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim mailer As New MailBee.SMTP

    '    Try

    '        'mailer = New MailBee.SMTP
    '        mailer = CreateObject("MailBee.SMTP")

    '        ' Unlock MailBee.SMTP object
    '        mailer.LicenseKey = "MBC500-5959843B6F-3D8F3ABAB139E365D283A4325B857897"

    '        ' SMTP server name
    '        mailer.ServerName = "uranium"

    '        Dim db As New cDBA
    '        Dim dt As DataTable

    '        Dim strSql As String

    '        strSql = _
    '        "SELECT * " & _
    '        "FROM TRAVELER_CONFIG WITH (Nolock) " & _
    '        "WHERE param IN ('setupEmailServer','setupEmailPort') "

    '        dt = db.DataTable(strSql)

    '        If dt.Rows.Count <> 0 Then
    '            For Each dtRow As DataRow In dt.Rows
    '                If Trim(dtRow.Item("Param").ToString) = "setupEmailServer" Then
    '                    mailer.ServerName = Trim(dtRow.Item("ParamValue").ToString)
    '                ElseIf Trim(dtRow.Item("Param").ToString) = "setupEmailPort" Then
    '                    mailer.PortNumber = CInt(Trim(dtRow.Item("ParamValue")))
    '                End If
    '            Next
    '        Else
    '            mailer.ServerName = "exchange.bankers.ca"   '"exchange.bankers.ca"
    '            mailer.PortNumber = 166   '25
    '        End If

    '        ' Mark that body has HTML format
    '        mailer.Message.BodyFormat = 1

    '        ' Enable logging SMTP session into a file. If any errors  
    '        ' occur, the log can be used to investigate the problem.
    '        mailer.EnableLogging = True
    '        mailer.LogFilePath = "C:\HV_Control_SendLog.txt"

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub
    '--------------------------------------------------------------------------------------------------------------

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim oForm As New frmProg_Item_Color("EC3080", "12345")
        oForm.ShowDialog()
        oForm.Save()
        oForm.Dispose()
        oForm = Nothing

    End Sub

    Public Function NumberFormatString(ByVal pNumber As Double, ByVal pMinDec As Integer, Optional ByVal pMaxDec As Integer = 0, Optional ByVal pMoney As Boolean = False) As String

        '"$#,##0.00;($#,##0.00)"
        NumberFormatString = "#,##0."
        If pMoney Then NumberFormatString = "$" & NumberFormatString

        Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        Dim iCount As Integer = 0

        If pNumber.ToString.Contains(".") Then
            iCount = pNumber.ToString.Length - (pNumber.ToString.IndexOf(nfi.CurrencyDecimalSeparator) + 1)
        Else
            iCount = pMinDec
        End If

        If pMinDec > pMaxDec Then pMaxDec = pMinDec
        If iCount < pMinDec Then iCount = pMinDec
        If iCount > pMaxDec Then iCount = pMaxDec

        NumberFormatString &= "".PadRight(iCount, "0")
        NumberFormatString = NumberFormatString & "(" & NumberFormatString & ")"

    End Function

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        MsgBox(NumberFormatString(12.25, 1, 4, True))
        MsgBox(NumberFormatString(12.25, 2, 4, True))
        MsgBox(NumberFormatString(12.25, 3, 4, True))
        MsgBox(NumberFormatString(12.254, 2, 4, True))

    End Sub

    Private Sub tsMRequest_Click(sender As Object, e As EventArgs) Handles tsMRequest.Click, RequestToolStripMenuItem.Click
        Try
            Dim frmReqShow As New frmShowRequests
            frmReqShow.Show()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



    Private Sub tlsLabelClick_Click(sender As Object, e As EventArgs) Handles tlsLabelClick.Click
        Try

            Dim frmReqShow As New frmShowRequests

            '  frmReqShow.MdiParent = Me
            Me.Hide()

            frmReqShow.ShowDialog()

            ' frmReqShow.Dispose()

            Me.Show()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tlsLabelClick_MouseHover(sender As Object, e As EventArgs) Handles tlsLabelClick.MouseHover
        Try

            tlsLabelClick.BackColor = Color.Beige

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tlsLabelClick_MouseLeave(sender As Object, e As EventArgs) Handles tlsLabelClick.MouseLeave
        Try
            tlsLabelClick.BackColor = Color.LightSkyBlue
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ComplaintCallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplaintCallToolStripMenuItem.Click
        FrmComplsint_call_main.ShowDialog()
    End Sub

    Private Sub SHowRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SHowRequestToolStripMenuItem.Click
        Dim frmReqShow As New frmShowRequests



        '  frmReqShow.MdiParent = Me
        Me.Hide()

        frmReqShow.ShowDialog()

        ' frmReqShow.Dispose()

        Me.Show()
    End Sub

    Private Sub OptionsChargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsChargeToolStripMenuItem.Click

    End Sub

    Private Sub DaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaysTlStripMntem30.Click, DaysTlStripMntem60.Click, DaysTlStripMntem120.Click, DaysTlStripMntem240.Click,
            DaysTlStripMntem240.Click, DaysTlStripMntem360.Click, DaysTlStripMntem480.Click, DaysTlStripMntem600.Click, DaysTlStripMntem720.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "CSOptionCharges") '(days,report name)



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '---------------------------------- Program Event reports ---------------------------------------------------
    Private Sub PAC180_Click(sender As Object, e As EventArgs) Handles PAC180.Click, PAC360.Click, PAC540.Click, PAC720.Click, PAC900.Click, PAC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "ProgramAllCustomers") '(days,report name)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PCG180_Click(sender As Object, e As EventArgs) Handles PCG180.Click, PCG360.Click, PCG540.Click, PCG720.Click, PCG900.Click, PCG1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "ProgramCustomerGroup") '(days,report name)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PCC180_Click(sender As Object, e As EventArgs) Handles PCC180.Click, PCC360.Click, PCC540.Click, PCC720.Click, PCC900.Click, PCC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "ProgramCustomerCode") '(days,report name)



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '----------------------------------------------- Special pricing reports --------------------------------------------

    Private Sub SPAC180_Click(sender As Object, e As EventArgs) Handles SPAC180.Click, SPAC360.Click, SPAC540.Click, SPAC720.Click, SPAC900.Click, SPAC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "SpecialPricingAllCustomers") '(days,report name)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SPCG180_Click(sender As Object, e As EventArgs) Handles SPCG180.Click, SPCG360.Click, SPCG540.Click, SPCG720.Click, SPCG900.Click, SPCG1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "SpecialPricingCustomerGroup") '(days,report name)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SPCC180_Click(sender As Object, e As EventArgs) Handles SPCC180.Click, SPCC360.Click, SPCC540.Click, SPCC720.Click, SPCC900.Click, SPCC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "SpecialPricingCustomerCode") '(days,report name)



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '----------------------------------------------- Quote reports ------------------------------------------------------
    Private Sub QAC180_Click(sender As Object, e As EventArgs) Handles QAC180.Click, QAC360.Click, QAC540.Click, QAC720.Click, QAC900.Click, QAC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "QuoteAllCustomers") '(days,report name)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub QCG180_Click(sender As Object, e As EventArgs) Handles QCG180.Click, QCG360.Click, QCG540.Click, QCG720.Click, QCG900.Click, QCG1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "QuoteCustomerGroup") '(days,report name)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub QCC180_Click(sender As Object, e As EventArgs) Handles QCC180.Click, QCC360.Click, QCC540.Click, QCC720.Click, QCC900.Click, QCC1080.Click
        Try
            Dim obj = sender

            Dim _tsTxt As ToolStripMenuItem = obj

            Call Report_CustomerOptionCharges(CInt(_tsTxt.Tag), "QuoteCustomerCode") '(days,report name)



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '---------------------------------- Function to execute the reports -------------------------------------------------
    Private Sub Report_CustomerOptionCharges(ByVal _days As Int32, ByVal _reportName As String)
        Try

            Dim myStream As Stream = Nothing
            Dim _dir As String = "C:\ExactTemp\"
            Dim _strdate As String = Date.Now.ToString

            _strdate = Replace(_strdate, "/", "")
            _strdate = Replace(_strdate, ":", "")
            _strdate = Replace(_strdate, " ", "")



            Dim strSavepath As String = ""

            If Directory.Exists(_dir) Then
                strSavepath = _dir & _reportName & "_" & _strdate & "_" & Guid.NewGuid.ToString & ".xlsx"
            Else
                Directory.CreateDirectory(_dir)

                If Not Directory.Exists(_dir) Then
                    MsgBox("Directory : " & _dir & "not created. Please try again or sent ticket request to IT Development dept. Thnak you")
                    Exit Sub
                Else
                    strSavepath = _dir & _reportName & "_" & _strdate & "_" & Guid.NewGuid.ToString & ".xlsx"
                End If


            End If


            Dim modExportToExcel As New modExportToExcel

            Me.Cursor = Cursors.WaitCursor
            '-----------------------------------------

            Dim DTable As DataTable = dtQuery(_days, _reportName)


            If DTable.Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("Data not found by serach criteria.")
                Exit Sub
            End If

            panprogressbarpercent.Visible = True
            ' lblPercent.Visible = True

            ' Call modExportToExcel.DatatableToExcel1(dtQuery(_days, _reportName), strSavepath, progressBar, lblPercent)

            Call modExportToExcel.DatatableToExcel(DTable, strSavepath, progressBar, lblPercent)

            Me.Cursor = Cursors.Default

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strSavepath
            If File.Exists(strSavepath) Then
                Process.Start(startInfo)
            End If


            panprogressbarpercent.Visible = False
            lblPercent.Visible = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function dtQuery(ByVal _days As Int32, ByVal _reportname As String) As DataTable
        dtQuery = Nothing
        Try
            db = New cDBA
            Dim strSql As String = "select top 0 '',''"

            Dim frmRCriteria As New frmReportCriteria

            Select Case _reportname
                Case "CSOptionCharges"
                    strSql =
              " Select * from dbo.Report_CS_OptionCharges(" & _days & ") "


                    'strat with the Programs.---------------------------------------------------------------------------------------------------------
                Case "ProgramAllCustomers"

                    strSql =
           " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",1) "

                Case "ProgramCustomerGroup"
                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql =
                 " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",1)  where Cust_group = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If

                Case "ProgramCustomerCode"

                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql = " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",1) where CusCD = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If

                    'Start with the Special pricing.---------------------------------------------------------------------------------------------------------
                Case "SpecialPricingAllCustomers"

                    strSql =
           " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",2) "

                Case "SpecialPricingCustomerGroup"
                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql =
                 " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",2)  where Cust_group = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If

                Case "SpecialPricingCustomerCode"

                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql = " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",2) where CusCD = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If

                    'Start with the Quotes.---------------------------------------------------------------------------------------------------------
                Case "QuoteAllCustomers"

                    strSql =
           " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",3) "

                Case "QuoteCustomerGroup"
                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql =
                 " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",3)  where Cust_group = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If

                Case "QuoteCustomerCode"

                    frmRCriteria.report_criteria = _reportname

                    If frmRCriteria.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        strSql = " Select * from  [dbo].[Report_ProgSpecQuote](" & _days & ",3) where CusCD = '" & Trim(frmRCriteria.reportParam) & "' "

                        'Else

                        '    Exit Function

                    End If



            End Select





            dtQuery = db.DataTable(strSql)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


End Class