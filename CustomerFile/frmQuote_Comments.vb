Public Class frmQuote_Comments

    Private User_Rights As String = "READONLY"

    Private db As New cDBA()

    Private m_Customer As cCustomer
    Private m_Program As cMdb_Cus_Prog
    Private m_Contact As cCicntp

    'Private m_blnOpened As Boolean = False

    Private dtGeneral As DataTable
    Private dtShipping As DataTable
    Private dtProduction As DataTable
    Private dtComments As DataTable

    Private m_strItem_Cd As String = String.Empty
    Private m_strCus_Prog_Item_List_Guid As String = String.Empty

    Delegate Sub ReturnInsertDelegate(ByVal pstrItem_Cd As String)

    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    Public Sub New(ByRef oCustomer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = oCustomer
        m_Program = New cMdb_Cus_Prog()
        m_Contact = New cCicntp()

    End Sub

    Public Sub New(ByRef oCustomer As cCustomer, ByRef oProgram As cMdb_Cus_Prog)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = oCustomer
        m_Program = oProgram
        m_Contact = New cCicntp(oProgram.Contact_ID)

    End Sub


    Public Sub New(ByRef oCustomer As cCustomer, ByRef oProgram As cMdb_Cus_Prog, ByVal pItem_cd As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = oCustomer
        m_Program = oProgram
        m_Contact = New cCicntp(oProgram.Contact_ID)
        m_strItem_Cd = pItem_cd

    End Sub

    Public Sub New(ByRef oCustomer As cCustomer, ByRef oProgram As cMdb_Cus_Prog, ByVal pItem_cd As String, ByVal pCus_Prog_Item_List_Guid As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = oCustomer
        m_Program = oProgram
        m_Contact = New cCicntp(oProgram.Contact_ID)
        m_strItem_Cd = pItem_cd
        m_strCus_Prog_Item_List_Guid = pCus_Prog_Item_List_Guid

    End Sub

    Private Sub frmQuote_Comments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            dgvGeneral.EndEdit()
            dgvShipping.EndEdit()
            dgvComments.EndEdit()
            dgvProduction.EndEdit()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub frmQuote_Comments_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If m_Program Is Nothing Then

                m_Program = New cMdb_Cus_Prog()
                m_Program.Cus_No = m_Customer.cmp_code

            End If

            'Select Case m_Program_Type
            '    Case "Program"

            '    Case "Special Pricing"

            '    Case "Quote"
            '        gbQuotes.Visible = True
            'End Select

            'Call FillFields()

            'Call dgvComments_CreateColumns()
            'Call dgvComments_Fill()
            'Call dgvComments_Format()

            dgvCheckList_CreateColumns(dgvGeneral)
            dgvCheckList_Format(dgvGeneral)
            dgvCheckList_Fill(dgvGeneral)

            dgvCheckList_CreateColumns(dgvShipping)
            dgvCheckList_Format(dgvShipping)
            dgvCheckList_Fill(dgvShipping)

            dgvCheckList_CreateColumns(dgvProduction)
            dgvCheckList_Format(dgvProduction)
            dgvCheckList_Fill(dgvProduction)

            dgvCheckList_CreateColumns(dgvComments)
            dgvCheckList_Format(dgvComments)
            dgvCheckList_Fill(dgvComments)

            If m_Program.Spector_Cd Is Nothing Then
                Me.Text = "Comments [Program: NEW" & IIf(m_strItem_Cd <> String.Empty, "  Item: " & m_strItem_Cd.Trim, "") & "]"
            Else
                Me.Text = "Comments [Program: " & m_Program.Spector_Cd.Trim & IIf(m_strItem_Cd <> String.Empty, "  Item: " & m_strItem_Cd.Trim, "") & "]"
            End If
            'Me.Text = "Comments [Program: " & IIf(m_Program.Spector_Cd.Trim Is Nothing, "NEW ", m_Program.Spector_Cd.Trim) & IIf(m_strItem_Cd <> String.Empty, "  Item: " & m_strItem_Cd.Trim, "") & "]"

            'Call SetVisibleFields()

            'Call SetProgramCaptions()

            'm_blnOpened = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub SetPermissions()

        'Dim db As New cDBA
        'Dim dt As DataTable
        'Dim strSql As String

        'strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
        'dt = db.DataTable(strSql)
        'If dt.Rows.Count <> 0 Then
        '    User_Rights = dt.Rows(0).Item("Access_Type").ToString
        'Else
        '    strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
        '    dt = db.DataTable(strSql)
        '    If dt.Rows.Count <> 0 Then
        '        User_Rights = dt.Rows(0).Item("Access_Type").ToString
        '    End If
        'End If

        'Select Case User_Rights
        '    Case "READWRITE"
        '        tsbSave.Enabled = True
        '        tsbNextStep.Enabled = True

        '    Case "SUPERUSER"
        '        tsbSave.Enabled = True
        '        tsbNextStep.Enabled = True

        '    Case "READONLY"
        '        tsClose.Visible = True
        '        Dim c As Control
        '        For Each c In Me.Controls
        '            If TypeOf c Is TextBox Then
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                'c.Enabled = False
        '                'c.BackColor = Color.White
        '            ElseIf TypeOf c Is ComboBox Then
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is CheckBox Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is RadioButton Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            ElseIf TypeOf c Is Button Then
        '                'c.Enabled = False
        '                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
        '            End If
        '        Next

        'End Select

    End Sub


#Region "LOAD OPTIONS ##########################################################"

    Private Sub dgvCheckList_CreateColumns(ByRef dgv As DataGridView)

        Try
            'If dtGeneral Is Nothing Then

            With dgv.Columns

                .Add(DGVTextBoxColumn("Prog_Comment_ID", "Prog_Comment_ID", 10))
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 10))
                .Add(DGVTextBoxColumn("MESSAGE_ID", "MESSAGE_ID", 10))
                .Add(DGVCheckBoxColumn("CHECK_VALUE", "CHECK_VALUE", 20))
                .Add(DGVTextBoxColumn("MESSAGE_DESC", "MESSAGE_DESC", 480))
                .Add(DGVTextBoxColumn("COMMENT_DESC", "COMMENT_DESC", 300))
                .Add(DGVTextBoxColumn("USER_LOGIN", "USER_LOGIN", 100))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE_TS", 100))

            End With

            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCheckList_Format(ByRef dgv As DataGridView)

        Try

            'If dtGeneral Is Nothing Then

            If dgv.Columns.Count = 0 Then Exit Sub

            With dgv

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                .CausesValidation = True

                .Columns(CheckList.PROG_COMMENT_ID).Visible = False
                .Columns(CheckList.MESSAGE_ID).Visible = False
                .Columns(CheckList.CUS_PROG_ID).Visible = False

                If dgv.Name = "dgvComments" Then
                    .Columns(CheckList.CHECK_VALUE).Visible = False
                    .Columns(CheckList.MESSAGE_DESC).Visible = False
                Else
                    .Columns(CheckList.COMMENT_DESC).Visible = False
                End If

                .Columns(CheckList.USER_LOGIN).Visible = False
                .Columns(CheckList.UPDATE_TS).Visible = False

            End With

            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCheckList_Fill(ByRef dgv As DataGridView)

        Try

            'If dtGeneral Is Nothing Then

            Dim strSql As String = ""
            'ISNULL(Prog_Comment_ID, 0)
            strSql = _
            "SELECT	    ISNULL(Prog_Comment_ID, 0) as Prog_Comment_ID, P.CUS_PROG_ID, " & _
            "           M.MESSAGE_ID, ISNULL(Prog_Comment_ID, 0) as CHECK_VALUE, M.MESSAGE_DESC, " & _
            "           P.COMMENT_DESC, P.USER_LOGIN, P.UPDATE_TS " & _
            "FROM		MDB_MESSAGE_DESC_VIEW M " & _
            "LEFT JOIN	MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID " & _
            "WHERE		M.TAAL_CD = '" & m_Customer.Taal_Cd.Trim & "' "

            strSql = _
            "SELECT	    ISNULL(Prog_Comment_ID, 0) as Prog_Comment_ID, P.CUS_PROG_ID, " & _
            "           M.MESSAGE_ID, ISNULL(Prog_Comment_ID, 0) as CHECK_VALUE, M.MESSAGE_DESC, " & _
            "           ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, P.USER_LOGIN, P.UPDATE_TS " & _
            "FROM		MDB_MESSAGE_DESC_VIEW M " & _
            "LEFT JOIN  MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID AND P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' "

            'COMMENT_DESC
            'USER_LOGIN()
            'UPDATE_TS()

            'If m_Program.Cus_Prog_Guid <> String.Empty Then
            '    ''AND ISNULL(CUS_PROG_GUID, '') IN ('', '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "')
            '    strSql &= " AND (ISNULL(CUS_PROG_GUID, '') IN ('', '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "'))  "
            'End If

            'If m_Program.Cus_Prog_Id <> 0 Then
            '    strSql &= " AND (PROG_ID = " & m_Program.Cus_Prog_Id & " OR PROG_ID IS NULL) "
            'End If

            ' CA MARCHE PAS PARCE QU'IL SAVE PAS LE ITEM_NO DANS LE CAS...
            If m_strItem_Cd <> String.Empty Then
                If m_strCus_Prog_Item_List_Guid = String.Empty Then
                    strSql &= " AND P.ITEM_CD = '" & m_strItem_Cd.Replace("'", "''") & "' "
                End If
            Else
                strSql &= " AND ISNULL(P.ITEM_CD, '') = '' "
                'AND P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' 
            End If

            ' CA MARCHE PAS PARCE QU'IL SAVE PAS LE ITEM_NO DANS LE CAS...
            If m_strCus_Prog_Item_List_Guid <> String.Empty Then
                strSql &= " AND P.CUS_PROG_ITEM_LIST_GUID = '" & m_strCus_Prog_Item_List_Guid.Replace("'", "''") & "' "
            Else
                strSql &= " AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' "
                'AND P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' 
            End If

            If m_Contact.ID = 0 Then
                strSql &= "WHERE		M.TAAL_CD = '" & m_Customer.Taal_Cd.Trim & "' "
            Else
                strSql &= "WHERE		M.TAAL_CD = '" & m_Contact.taalcode.Trim & "' "
            End If

            Select Case dgv.Name

                Case "dgvGeneral"
                    strSql &= " AND MSG_GROUP = 'General and Pricing' AND M.MESSAGE_ID NOT IN (4, 5)"

                    dtGeneral = db.DataTable(strSql)

                    dgv.DataSource = dtGeneral
                    dgv.AllowUserToAddRows = False

                Case "dgvShipping"
                    strSql &= " AND MSG_GROUP = 'Shipping / samples / approvals' "

                    dtShipping = db.DataTable(strSql)

                    dgv.DataSource = dtShipping
                    dgv.AllowUserToAddRows = False

                Case "dgvProduction"
                    strSql &= " AND MSG_GROUP = 'Decoration / Packaging' "

                    dtProduction = db.DataTable(strSql)

                    dgv.DataSource = dtProduction
                    dgv.AllowUserToAddRows = False

                Case "dgvComments"

                    strSql = _
                    "SELECT	    ISNULL(P.Prog_Comment_ID, 0) as Prog_Comment_ID, P.CUS_PROG_ID, " & _
                    "           P.MESSAGE_ID, 0 as CHECK_VALUE, '' AS MESSAGE_DESC, " & _
                    "           ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, P.USER_LOGIN, P.UPDATE_TS " & _
                    "FROM       MDB_Prog_Comment P " & _
                    "WHERE      P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' "

                    If m_strItem_Cd <> String.Empty Then
                        If m_strCus_Prog_Item_List_Guid = String.Empty Then
                            strSql &= " AND P.ITEM_CD = '" & m_strItem_Cd.Replace("'", "''") & "' "
                        End If
                    Else
                        strSql &= " AND P.ITEM_CD = '' "
                        'AND P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' 
                    End If

                    ' CA MARCHE PAS PARCE QU'IL SAVE PAS LE ITEM_NO DANS LE CAS...
                    If m_strCus_Prog_Item_List_Guid <> String.Empty Then
                        strSql &= " AND P.CUS_PROG_ITEM_LIST_GUID = '" & m_strCus_Prog_Item_List_Guid.Replace("'", "''") & "' "
                    Else
                        strSql &= " AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' "
                        'AND P.CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid.Replace("'", "''") & "' 
                    End If

                    strSql &= " AND ISNULL(COMMENT_DESC, '') <> '' "

                    dtComments = db.DataTable(strSql)

                    dgv.DataSource = dtComments
                    dgv.AllowUserToAddRows = False

            End Select

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region



#Region "PRIVATE DGVITEMS MAINTENANCE OPERATIONS ##############################"

    'Private Sub dgvComments_CreateColumns()

    '    Try
    '        With dgvComments.Columns

    '            If .Count > 0 Then
    '                For iCol = .Count To 1 Step -1
    '                    .RemoveAt(iCol - 1)
    '                Next
    '            End If

    '            .Add(DGVTextBoxColumn("Comment_ID", "Comment_ID", 20))
    '            .Add(DGVTextBoxColumn("Cus_Prog_ID", "Cus_Prog_ID", 100))
    '            .Add(DGVTextBoxColumn("Comment_Desc", "Comment_Desc", 300))
    '            .Add(DGVTextBoxColumn("User_Login", "User_Login", 100))
    '            .Add(DGVTextBoxColumn("Update_TS", "Update_TS", 100))

    '        End With

    '        With dgvComments
    '            .Columns(Comments.Comment_ID).Visible = False
    '            .Columns(Comments.Cus_Prog_ID).Visible = False
    '            .Columns(Comments.User_Login).Visible = True
    '            .Columns(Comments.Update_TS).Visible = True

    '        End With

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Private Sub dgvComments_Fill()

    '    'Try

    '    '    'Dim dt As DataTable
    '    '    Dim db As New cDBA

    '    '    Dim strLoadString As String = _
    '    '    "SELECT     CUS_PROG_ITEM_LIST_ID, CUS_PROG_ID, ITEM_CD, ITEM_DESC, ITEM_NO, " & _
    '    '    "           ITEM_COLOR, MIN_QTY_ORD, UNIT_PRICE, EQP_LEVEL, EQP_PCT, " & _
    '    '    "           USER_LOGIN, UPDATE_TS, CAST('' AS VARCHAR(1)) AS DIRTY " & _
    '    '    "FROM       MDB_CUS_PROG_ITEM_LIST WITH (Nolock) " & _
    '    '    "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id.ToString & " " & _
    '    '    "ORDER BY   CUS_PROG_ITEM_LIST_ID "

    '    '    Dim strLoadEmpty As String = _
    '    '    "SELECT     TOP 1 CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " & _
    '    '    "           CAST(0 AS INT) AS CUS_PROG_ID, " & _
    '    '    "           CAST('' AS VARCHAR(20)) AS ITEM_CD, " & _
    '    '    "           CAST('' AS VARCHAR(60)) AS ITEM_DESC, " & _
    '    '    "           CAST('' AS VARCHAR(30)) AS ITEM_NO, " & _
    '    '    "           CAST('' AS VARCHAR(20)) AS ITEM_COLOR, " & _
    '    '    "           CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " & _
    '    '    "           CAST(NULL AS NUMERIC(13, 4)) AS UNIT_PRICE, " & _
    '    '    "           CAST(NULL AS INT) AS EQP_LEVEL, " & _
    '    '    "           CAST(NULL AS NUMERIC(13, 4)) AS EQP_PCT, " & _
    '    '    "           CAST('' AS VARCHAR(20)) AS USER_LOGIN, " & _
    '    '    "           CAST(NULL AS DATETIME) AS UPDATE_TS,  " & _
    '    '    "           CAST('' AS VARCHAR(1)) AS DIRTY " & _
    '    '    "FROM       MDB_CUS_PROG_ITEM_LIST "

    '    '    If m_Program.Cus_Prog_Id <> 0 Then
    '    '        dtItems = db.DataTable(strLoadString)
    '    '        If dtItems.Rows.Count = 0 Then
    '    '            dtItems = db.DataTable(strLoadEmpty)
    '    '        End If
    '    '    Else
    '    '        dtItems = db.DataTable(strLoadEmpty)
    '    '    End If

    '    '    dgvItems.DataSource = dtItems

    '    '    dgvItems.AllowUserToAddRows = False
    '    '    dgvItems.AllowUserToOrderColumns = False

    '    'Catch er As Exception
    '    '    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    'End Try

    'End Sub

    'Private Sub dgvComments_Format()

    '    Try

    '        'With dgvItems
    '        '    For lPos As Integer = 0 To .Columns.Count - 1
    '        '        .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
    '        '    Next lPos

    '        '    .CausesValidation = True

    '        '    Dim oCellStyle As New DataGridViewCellStyle()
    '        '    oCellStyle = New DataGridViewCellStyle()
    '        '    oCellStyle.Format = "##,##0.000"
    '        '    oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '        '    .Columns(Items.UNIT_PRICE).DefaultCellStyle = oCellStyle

    '        '    oCellStyle = New DataGridViewCellStyle()
    '        '    oCellStyle.Format = "##,##0.00"
    '        '    oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        '    .Columns(Items.EQP_PCT).DefaultCellStyle = oCellStyle

    '        '    oCellStyle = New DataGridViewCellStyle()
    '        '    oCellStyle.Format = "###,##0"
    '        '    oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '        '    .Columns(Items.MIN_QTY_ORD).DefaultCellStyle = oCellStyle

    '        '    '.Columns(PickTypeColumns.ColHeader).Frozen = True
    '        '    .Columns(Items.CUS_PROG_ITEM_LIST_ID).Frozen = True
    '        '    .Columns(Items.CUS_PROG_ID).Frozen = True
    '        '    .Columns(Items.ITEM_CD).Frozen = True

    '        '    ''.Columns(PickTypeColumns.ColHeader).Visible = False
    '        '    '.Columns(Items.CUS_PROG_ITEM_LIST_ID).Visible = False
    '        '    '.Columns(Items.CUS_PROG_ID).Visible = False

    '        '    '.Columns(Items.USER_LOGIN).Visible = False
    '        '    '.Columns(Items.UPDATE_TS).Visible = False

    '        '    .CurrentCell = .Rows(0).Cells(Items.ITEM_CD)

    '        'End With

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

#End Region

    'This sub is used for testing only. No valid anything should be entered here.
    'Private Sub T1()

    '    Dim oDict As New Dictionary(Of String, String)
    '    oDict.Add("8", "Ligne 8")
    '    oDict.Add("12", "Ligne 12")
    '    oDict.Add("16", "Ligne 16")

    '    'var dict = new Dictionary<string, string>();
    '    '         ArrayList arr = new ArrayList();
    '    '         foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
    '    '            {
    '    '             dict.Add(folder.Id.ToString(),folder.DisplayName);
    '    '             arr.Add(folder.Id.ToString());
    '    '            }        

    '    clbTest.DataSource = New BindingSource(oDict, "")
    '    clbTest.m()
    '   checkedListBox1.DataSource = new BindingSource(dict, null);
    '   checkedListBox1.DisplayMember = "Value";
    '   checkedListBox1.ValueMember = "Key";

    'End Sub

    'Public Sub Save(ByRef pProgram As cMdb_Cus_Prog)

    '    Try
    '        m_Program = pProgram
    '        Call Save()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Public Sub Save()

        ' Do nothing if form was not opened.
        'If Not m_blnOpened Then Exit Sub

        Try

            Call SaveCheckGrid(dgvGeneral)
            Call SaveCheckGrid(dgvProduction)
            Call SaveCheckGrid(dgvShipping)
            Call SaveCheckGrid(dgvComments)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveCheckGrid(ByRef dgv As DataGridView)

        Try

            For Each dgvRow As DataGridViewRow In dgv.Rows
                dgvRow.Cells(CheckList.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
            Next

            ' First pass, we only save lines
            For Each dgvRow As DataGridViewRow In dgv.Rows

                'Prog_Comment_ID()'CUS_PROG_ID()'MESSAGE_ID()'CHECK_VALUE()'MESSAGE_DESC()
                If dgvRow.Cells(CheckList.PROG_COMMENT_ID).Value <> 0 Or dgvRow.Cells(CheckList.CHECK_VALUE).Value <> 0 Or dgvRow.Cells(CheckList.COMMENT_DESC).Value <> String.Empty Then

                    Dim oItem As New cMdb_Prog_Comment()

                    If dgvRow.Cells(CheckList.PROG_COMMENT_ID).Value <> 0 Then
                        oItem = New cMdb_Prog_Comment(CInt(dgvRow.Cells(CheckList.PROG_COMMENT_ID).Value))
                    End If

                    If dgvRow.Cells(CheckList.CHECK_VALUE).Value = 0 And (dgvRow.Cells(CheckList.COMMENT_DESC).Value.Equals(DBNull.Value) Or dgvRow.Cells(CheckList.COMMENT_DESC).Value.ToString = String.Empty) Then

                        oItem.Delete()
                        dgvRow.Cells(CheckList.PROG_COMMENT_ID).Value = 0

                    Else

                        oItem.Cus_Prog_Id = dgvRow.Cells(CheckList.CUS_PROG_ID).Value
                        oItem.Cus_Prog_Guid = m_Program.Cus_Prog_Guid
                        'oItem.Message_Id = If(dgvRow.Cells(CheckList.MESSAGE_ID).Value.Equals(DBNull.Value), "", dgvRow.Cells(CheckList.MESSAGE_ID).Value)
                        oItem.Message_Id = If(dgvRow.Cells(CheckList.MESSAGE_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(CheckList.MESSAGE_ID).Value)
                        oItem.Item_Cd = m_strItem_Cd
                        If Not (dgvRow.Cells(CheckList.COMMENT_DESC).Value.Equals(DBNull.Value)) Then oItem.Comment_Desc = dgvRow.Cells(CheckList.COMMENT_DESC).Value.ToString
                        If m_strCus_Prog_Item_List_Guid <> String.Empty Then oItem.Cus_Prog_Item_List_Guid = m_strCus_Prog_Item_List_Guid
                        oItem.Save()

                        dgvRow.Cells(CheckList.PROG_COMMENT_ID).Value = oItem.Prog_Comment_Id

                    End If

                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Property Program() As cMdb_Cus_Prog
        Get
            Program = m_Program
        End Get
        Set(value As cMdb_Cus_Prog)
            m_Program = value
        End Set
    End Property

    Public Property Customer() As cCustomer
        Get
            Customer = m_Customer
        End Get
        Set(value As cCustomer)
            m_Customer = value
        End Set
    End Property

    Private Enum CheckList

        PROG_COMMENT_ID
        CUS_PROG_ID
        MESSAGE_ID
        CHECK_VALUE
        MESSAGE_DESC
        COMMENT_DESC
        USER_LOGIN
        UPDATE_TS

        '        "SELECT	    ISNULL(Prog_Comment_ID, 0) as Prog_Comment_ID, " & _
        '"           P.PROG_ID, M.MESSAGE_ID, M.MESSAGE_DESC " & _

    End Enum

    'Private Enum Comments

    '    Comment_ID
    '    Cus_Prog_ID
    '    Comment_Desc
    '    User_Login
    '    Update_TS

    'End Enum

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

            dgvComments.EndEdit()
            Call CommentLineInsert()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Try

            With dgvComments

                If .Rows.Count = 0 Then Exit Sub

                .EndEdit()

                .AllowUserToDeleteRows = True

                If .CurrentRow.Cells(CheckList.PROG_COMMENT_ID).Value <> 0 Then
                    Dim oComment As New cMdb_Prog_Comment(.CurrentRow.Cells(CheckList.PROG_COMMENT_ID).Value)
                    oComment.Delete()
                End If

                .Rows.RemoveAt(.CurrentRow.Index)
                .AllowUserToDeleteRows = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Refresh()

        Try

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub CommentLineInsert()

        Debug.Print("ItemLineInsert")

        Try

            If dgvComments.Rows.Count = 0 Then

                Call LineInsert()

            ElseIf Not (dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC).Value.Equals(DBNull.Value)) Then

                If Not Trim(dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC).Value).Equals("") Then
                    Call LineInsert()
                Else
                    dgvComments.CurrentCell = dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC)
                End If

            Else

                dgvComments.CurrentCell = dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC)

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub LineInsert()

        Debug.Print("LineInsert")

        Try
            Dim drNewRow As DataRow
            dgvComments.AllowUserToAddRows = True

            drNewRow = dtComments.NewRow

            dtComments.Rows.Add(drNewRow)

            dgvComments.AllowUserToAddRows = False
            'If dgvRow.Cells(CheckList.Prog_Comment_ID).Value <> 0 Or dgvRow.Cells(CheckList.CHECK_VALUE).Value <> 0 Then

            dgvComments.CurrentCell = dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC)

            dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.PROG_COMMENT_ID).Value = 0
            dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.CHECK_VALUE).Value = 0
            dgvComments.Rows(dgvComments.Rows.Count - 1).Cells(CheckList.COMMENT_DESC).Value = String.Empty

            dgvComments.Focus()

            dgvComments.BeginEdit(True)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvComments_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComments.CellContentClick

    End Sub

    Private Sub dgvComments_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvComments.KeyDown

        Try

            Select Case e.KeyCode
                Case Keys.Return

                    Dim oInvoke As New ReturnInsertDelegate(AddressOf CommentLineInsert)
                    dgvComments.BeginInvoke(oInvoke, dgvComments.CurrentRow.Cells(CheckList.COMMENT_DESC).Value)

                    'Call ProductLineInsert(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value)

                Case Keys.Delete
                    'Call Menu_Delete()

                Case Keys.Insert
                    'Call Menu_New()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

End Class