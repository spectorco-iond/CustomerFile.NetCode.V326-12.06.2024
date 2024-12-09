Imports System.Reflection
Imports System.Data
Imports System.IO
Public Class FrmCallheadermaintenance

    Private m_cComplaintUser As cComplaintCallUser
    Private m_cComplaintCallHeader As cComplaintCallHeader
    Private m_cComplaintCallDetail As cComplaintCallDetail

    Private m_cComplaintCalldoc As cCOMPLAINT_CALL_DETAIL_FILE

    Private m_flag_new_header As Boolean

    Private db As New cDBA()
    Private DT_tables As DataTable
    Private DT_complaint_detail_tables As DataTable
    Private strSql As String

    Public Sub New(ByVal io_COMPLAINT_CALL_USER As cComplaintCallUser)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_cComplaintUser = io_COMPLAINT_CALL_USER
        m_cComplaintCallHeader = New cComplaintCallHeader
        m_flag_new_header = True
        DgvComplatinDetailList.AllowUserToAddRows = False
    End Sub
    Public Sub New(ByVal io_COMPLAINT_CALL_USER_ID As cComplaintCallUser, io_cComplaintCallHeader As cComplaintCallHeader)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_cComplaintUser = io_COMPLAINT_CALL_USER_ID
        m_cComplaintCallHeader = io_cComplaintCallHeader
        m_flag_new_header = False
        DgvComplatinDetailList.AllowUserToAddRows = False

    End Sub

    Private Sub FrmCallheadermaintenance_Load(sender As Object, e As EventArgs) Handles Me.Load



        lb_new_flag.BackColor = Color.Yellow
        lb_new_flag.Visible = False

        lab_po_no.Text = ""

        LabelUserId.Text = m_cComplaintUser.COMPLAINT_CALL_USER_ID.ToString
        tb_user_name.Text = m_cComplaintUser.get_user_name()
        lb_phone_no.Text = m_cComplaintUser.USER_CONTACT_PHONE_NUMBER
        lb_address.Text = Trim(m_cComplaintUser.USER_ADDRESS)
        lb_email.Text = Trim(m_cComplaintUser.USER_EMAIL)

        Call cbb_complaint_detail_type_initial()
        Call cbb_product_id_initial()
        DgvComplatinDetailList.RowHeadersVisible = False

        If Not m_flag_new_header Then
            show_header()
            Call show_details()
        Else
            m_cComplaintCallHeader = New cComplaintCallHeader
            show_header()
            Call new_detail_initial()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub show_header()
        Call load_cbo_cpmplaint_call_type(m_cComplaintCallHeader.COMPLAINT_CALL_TYPE_ID)
        Call load_cbo_cpmplaint_call_level(m_cComplaintCallHeader.COMPLAINT_CALL_LEVEL_ID)
        Call load_cbo_cpmplaint_call_status(m_cComplaintCallHeader.COMPLAINT_CALL_STATUS_ID)
        'Call load_dgv_po_no_list(m_cComplaintUser.CUS_NO.ToString, m_cComplaintCallHeader)
        tb_call_time.Text = m_cComplaintCallHeader.CALL_DATE.ToString
        If m_flag_new_header Then
            LabelheaderId.Text = "NEW"
        Else
            LabelheaderId.Text = m_cComplaintCallHeader.COMPLAINT_CALL_HEADER_ID.ToString
        End If
    End Sub


    Private Sub initial_detail_columns()
        DgvComplatinDetailList.DataSource = Nothing
        DgvComplatinDetailList.Columns.Clear()
        Dim comboboxColumn As DataGridViewComboBoxColumn
        With DgvComplatinDetailList.Columns
            .Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_ID", "COMPLAINT_CALL_DETAIL_ID", 100))
            .Add(DGVTextBoxColumn("COMPLAINT_CALL_HEADER_ID", "COMPLAINT_CALL_HEADER_ID", 100))
            '.Add(DGVTextBoxColumn("COMPLAINT_CALL_PRODUCT_ID", "COMPLAINT_CALL_PRODUCT_ID", 100))
            comboboxColumn = New DataGridViewComboBoxColumn()
            comboboxColumn.DataPropertyName = "COMPLAINT_CALL_PRODUCT_ID"
            comboboxColumn.HeaderText = "COMPLAINT_CALL_PRODUCT_ID"
            comboboxColumn.Name = "COMPLAINT_CALL_PRODUCT_ID"
            With comboboxColumn
                .ValueMember = "COMPLAINT_CALL_PRODUCT_ID"
                .DisplayMember = "COMPLAINT_CALL_PRODUCT_NAME"
                .DataSource = Get_MDB_CFG_PRODUCT_List()
            End With
            .Add(comboboxColumn)
            '.Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_TYPE_ID", "COMPLAINT_CALL_DETAIL_TYPE_ID", 100))
            comboboxColumn = New DataGridViewComboBoxColumn()
            comboboxColumn.DataPropertyName = "COMPLAINT_CALL_DETAIL_TYPE_ID"
            comboboxColumn.HeaderText = "COMPLAINT_CALL_DETAIL_TYPE_ID"
            comboboxColumn.Name = "COMPLAINT_CALL_DETAIL_TYPE_ID"
            With comboboxColumn
                .ValueMember = "COMPLAINT_CALL_DETAIL_TYPE_ID"
                .DisplayMember = "COMPLAINT_CALL_DETAIL_TYPE_NAME"
                .DataSource = Get_CFG_DETAIL_TYPE_List()
            End With
            .Add(comboboxColumn)
            .Add(DGVTextBoxColumn("PURCHASE_QUANTITY", "PURCHASE_QUANTITY", 100))
            .Add(DGVTextBoxColumn("DESCRIPTION_PRODUCT", "DESCRIPTION_PRODUCT", 100))
            .Add(DGVTextBoxColumn("LOGO_ON_PRODUCT", "LOGO_ON_PRODUCT", 100))
            .Add(DGVTextBoxColumn("PURCHASED_FROM", "PURCHASED_FROM", 100))
            .Add(DGVTextBoxColumn("ITEM_NO", "ITEM_NO", 100))
            'comboboxColumn = New DataGridViewComboBoxColumn()
            'comboboxColumn.DataPropertyName = "ITEM_NO"
            'comboboxColumn.HeaderText = "ITEM_NO"
            'With comboboxColumn
            '    .ValueMember = "ITEM_CD"
            '    .DisplayMember = "ITEM_CD"
            '    .DataSource = Get_MASTER_ITEM_List()
            '    .AutoComplete = AutoCompleteMode.SuggestAppend
            'End With
            '.Add(comboboxColumn)
            .Add(DGVTextBoxColumn("EXPIRY_DATE", "EXPIRY_DATE", 100))
            .Add(DGVTextBoxColumn("COMPLAINT_DETAIL", "COMPLAINT_DETAIL", 400))
            .Add(DGVTextBoxColumn("NOTE", "NOTE", 200))
            .Add(DGVTextBoxColumn("LOT_NO", "LOT_NO", 200))
            .Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_TYPE_NAME", "COMPLAINT_CALL_DETAIL_TYPE_NAME", 100))
            .Add(DGVTextBoxColumn("COMPLAINT_CALL_PRODUCT_NAME", "COMPLAINT_CALL_PRODUCT_NAME", 100))
            .Add(DGVTextBoxColumn("PO_NO", "PO_NO", 50))
            .Add(DGVTextBoxColumn("ORD_NO", "ORD_NO", 50))

        End With
        DgvComplatinDetailList.Columns("COMPLAINT_CALL_DETAIL_ID").Visible = False
        DgvComplatinDetailList.Columns("COMPLAINT_CALL_HEADER_ID").Visible = False
        DgvComplatinDetailList.Columns("COMPLAINT_CALL_PRODUCT_ID").Visible = False
        DgvComplatinDetailList.Columns("COMPLAINT_CALL_DETAIL_TYPE_ID").Visible = False
        'DgvComplatinDetailList.Columns("LOGO_ON_PRODUCT").Visible = False
        'DgvComplatinDetailList.Columns("DESCRIPTION_PRODUCT").Visible = False

        DgvComplatinDetailList.Columns("COMPLAINT_CALL_DETAIL_TYPE_NAME").DisplayIndex = 0
        DgvComplatinDetailList.Columns("COMPLAINT_CALL_PRODUCT_NAME").DisplayIndex = 1
        DgvComplatinDetailList.Columns("PO_NO").DisplayIndex = 2
        DgvComplatinDetailList.Columns("ORD_NO").DisplayIndex = 3

        If DgvComplatinDetailList.RowCount = 0 Then
            gb_complaintdetail.Visible = False
        Else
            gb_complaintdetail.Visible = True
        End If
    End Sub
    Private Sub new_detail_initial()
        'new detail
        'm_cComplaintCallDetail = New cComplaintCallDetail
        'm_cComplaintCallDetail.COMPLAINT_CALL_HEADER_ID = m_cComplaintCallHeader.COMPLAINT_CALL_HEADER_ID

        Call initial_detail_columns()
        Call load_dgv_po_no_all_list()
    End Sub

    Private Sub show_details()
        Call load_dgv_po_no_all_list()
        Call initial_detail_columns()
        strSql = " 	Select COMPLAINT_CALL_DETAIL_ID , COMPLAINT_CALL_HEADER_ID, " _
                & " COMPLAINT_CALL_PRODUCT_ID, COMPLAINT_CALL_DETAIL_TYPE_ID, " _
                & " PURCHASE_QUANTITY, DESCRIPTION_PRODUCT, LOGO_ON_PRODUCT, PURCHASED_FROM, " _
                & " ITEM_NO      , EXPIRY_DATE, COMPLAINT_DETAIL, NOTE, LOT_NO " _
                & " , ( select top 1 a3.COMPLAINT_CALL_DETAIL_TYPE_NAME from COMPLAINT_CALL_DETAIL_TYPE a3 where a3.COMPLAINT_CALL_DETAIL_TYPE_ID = t1.COMPLAINT_CALL_DETAIL_TYPE_ID ) As [COMPLAINT_CALL_DETAIL_TYPE_NAME] " _
                & " ,( Select top 1 rtrim(isnull(a4.ENUM_VALUE,'')) FROM MDB_CFG_ENUM a4 WHERE a4.ENUM_CAT = 'ITEM_CLASS' and a4.id = t1.COMPLAINT_CALL_PRODUCT_ID ) as [COMPLAINT_CALL_PRODUCT_NAME] " _
                & " , PO_NO ,ORD_NO " _
                & " from COMPLAINT_CALL_DETAIL t1 " _
                & " where t1.COMPLAINT_CALL_HEADER_ID = " _
                & m_cComplaintCallHeader.COMPLAINT_CALL_HEADER_ID.ToString _
                & " ORDER BY [COMPLAINT_CALL_DETAIL_ID] "
        DT_complaint_detail_tables = db.DataTable(strSql)
        DgvComplatinDetailList.DataSource = DT_complaint_detail_tables
        If DgvComplatinDetailList.RowCount > 0 And Not IsNothing(m_cComplaintCallDetail) Then
            For index As Integer = 0 To DgvComplatinDetailList.RowCount - 1
                If DgvComplatinDetailList.Rows(index).Cells("COMPLAINT_CALL_DETAIL_ID").Value = m_cComplaintCallDetail.COMPLAINT_CALL_DETAIL_ID Then
                    DgvComplatinDetailList.Rows(index).Selected = True
                    fill_detail_info_in_page(m_cComplaintCallDetail)
                    Exit For
                End If
            Next
        End If
        If DgvComplatinDetailList.RowCount = 0 Then
            gb_complaintdetail.Visible = False
        Else
            gb_complaintdetail.Visible = True
        End If

        If DgvComplatinDetailList.RowCount > 0 And IsNothing(m_cComplaintCallDetail) Then
            DgvComplatinDetailList.Rows(0).Selected = True
            If Not (IsNothing(DgvComplatinDetailList.Rows(0).Cells("COMPLAINT_CALL_DETAIL_ID"))) Then
                If Not IsNothing(DgvComplatinDetailList.Rows(0).Cells("COMPLAINT_CALL_DETAIL_ID").Value) Then
                    m_cComplaintCallDetail = New cComplaintCallDetail(CType(DgvComplatinDetailList.Rows(0).Cells("COMPLAINT_CALL_DETAIL_ID").Value, Integer))
                    fill_detail_info_in_page(m_cComplaintCallDetail)
                End If
            End If
        End If
    End Sub

    Private Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If m_flag_new_header Then 'need new header
            'new header by m_cComplaintUser
            save_header()
            'save detail
            save_detail()
        Else
            save_header()
            'only update or new detail
            'Save detail
            save_detail()
        End If
        MsgBox("Saved!")
        'm_flag_new_header changed from true to False after save() for new header
        Call flash_page()
        lb_new_flag.Visible = False
        bt_add_detail.Enabled = True
        DgvComplatinDetailList.Enabled = True
        'DgvComplatinDetailList.BackgroundColor = Color.Coral

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub flash_page()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        show_header()
        show_details()
        If Not IsNothing(m_cComplaintCallDetail) Then
            'm_cComplaintCallDetail
            fill_detail_info_in_page(m_cComplaintCallDetail)
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub save_header()
        m_cComplaintCallHeader.COMPLAINT_CALL_USER_ID = m_cComplaintUser.COMPLAINT_CALL_USER_ID
        m_cComplaintCallHeader.COMPLAINT_CALL_TYPE_ID = Cbo_call_type.SelectedValue
        m_cComplaintCallHeader.COMPLAINT_CALL_LEVEL_ID = Cbo_call_level.SelectedValue
        m_cComplaintCallHeader.COMPLAINT_CALL_STATUS_ID = Cbo_call_status.SelectedValue
        m_cComplaintCallHeader.CALL_DATE = tb_call_time.Text
        m_cComplaintCallHeader.PO_NO = lab_po_no.Text
        m_cComplaintCallHeader.Save()
        m_flag_new_header = False
    End Sub

    Private Sub save_detail()

        If IsNothing(m_cComplaintCallDetail) Then
            Exit Sub
        End If
        'm_cComplaintCallDetail.COMPLAINT_CALL_DETAIL_ID =
        m_cComplaintCallDetail.COMPLAINT_CALL_HEADER_ID = m_cComplaintCallHeader.COMPLAINT_CALL_HEADER_ID
        m_cComplaintCallDetail.COMPLAINT_CALL_PRODUCT_ID = Trim(cbb_product_id.SelectedValue)
        m_cComplaintCallDetail.COMPLAINT_CALL_DETAIL_TYPE_ID = Trim(cbb_complaint_detail_type.SelectedValue)
        'm_cComplaintCallDetail.PURCHASE_QUANTITY = Trim(mtb_purchase_qty.Text)
        Select Case Trim(mtb_purchase_qty.Text)
            Case ""
                m_cComplaintCallDetail.PURCHASE_QUANTITY = 0
            Case Else
                m_cComplaintCallDetail.PURCHASE_QUANTITY = Trim(mtb_purchase_qty.Text)
        End Select
        m_cComplaintCallDetail.DESCRIPTION_PRODUCT = Trim(tb_product_desc.Text)
        m_cComplaintCallDetail.LOGO_ON_PRODUCT = Trim(tb_logo_on_product.Text)
        m_cComplaintCallDetail.PURCHASED_FROM = Trim(tb_purchase_from.Text)
        m_cComplaintCallDetail.ITEM_NO = Trim(tb_item_no.Text)
        m_cComplaintCallDetail.EXPIRY_DATE = dtp_expiry_date.Value
        m_cComplaintCallDetail.COMPLAINT_DETAIL = Trim(rtx_complaint_detail.Text)
        m_cComplaintCallDetail.NOTE = Trim(rtx_notes.Text)
        m_cComplaintCallDetail.LOT_NO = Trim(tb_lot_no.Text)
        m_cComplaintCallDetail.PO_NO = Trim(lab_po_no.Text)
        Select Case Trim(mtb_ord_no.Text)
            Case ""
                m_cComplaintCallDetail.ORD_NO = 0
            Case Else
                m_cComplaintCallDetail.ORD_NO = Trim(mtb_ord_no.Text)
        End Select

        m_cComplaintCallDetail.Save()

    End Sub

    Private Sub load_cbo_cpmplaint_call_type(ByVal in_id As Integer)
        Dim olst_cComplaintCallType As List(Of cComplaintCallType)
        Dim o_cComplaintCallType_DAL As cComplaintCallType_DAL = New cComplaintCallType_DAL
        olst_cComplaintCallType = o_cComplaintCallType_DAL.Load()

        With Cbo_call_type
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = olst_cComplaintCallType
            .DisplayMember = "COMPLAINT_CALL_TYPE_NAME"
            .ValueMember = "COMPLAINT_CALL_TYPE_ID"
            .SelectedValue = in_id
        End With
    End Sub
    Private Sub load_cbo_cpmplaint_call_level(ByVal in_id As Integer)
        Dim olst_cComplaintCallLevel As List(Of cComplaintCallLevel)
        Dim o_cComplaintCallLevel_DAL As cComplaintCallLevel_DAL = New cComplaintCallLevel_DAL
        olst_cComplaintCallLevel = o_cComplaintCallLevel_DAL.Load()

        With Cbo_call_level
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = olst_cComplaintCallLevel
            .DisplayMember = "COMPLAINT_CALL_LEVEL_NAME"
            .ValueMember = "COMPLAINT_CALL_LEVEL_ID"
            .SelectedValue = in_id
        End With
    End Sub
    Private Sub load_cbo_cpmplaint_call_status(ByVal in_id As Integer)
        Dim olst_cComplaintCallStatus As List(Of cComplaintCallStatus)
        Dim o_cComplaintCallstatus_DAL As cComplaintCallStatus_DAL = New cComplaintCallStatus_DAL
        olst_cComplaintCallStatus = o_cComplaintCallstatus_DAL.Load()

        With Cbo_call_status
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = olst_cComplaintCallStatus
            .DisplayMember = "COMPLAINT_CALL_STATUS_NAME"
            .ValueMember = "COMPLAINT_CALL_STATUS_ID"
            .SelectedValue = in_id
        End With
    End Sub

    Private Sub load_dgv_po_no_list(ByVal cus_no As String, ByVal in_ComplaintCallHeader As cComplaintCallHeader)
        Try
            dgv_po_no_list.RowHeadersVisible = False
            dgv_po_no_list.AllowUserToAddRows = False
            dgv_po_no_list.AllowUserToDeleteRows = False
            dgv_po_no_list.ReadOnly = True
            dgv_po_no_list.Columns.Clear()

            Call Dgv_po_no_list_c_cols()

            Dim strSql As String =
            " Select customerno, customername, itemno, itemdesc, qty, cuspo, ord_no,headerid " _
            & " from EXACT_TRAVELER_VIEW_HEADER_GRID_InProductionOnly " _
            & " where customerno = '" & cus_no & "'"
            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)
            dgv_po_no_list.DataSource = dt

            'If dgv_po_no_list.RowCount > 0 And Not IsNothing(in_ComplaintCallHeader.PO_NO) And LTrim(RTrim(in_ComplaintCallHeader.PO_NO.ToString)) <> "" Then
            '    For index As Integer = 0 To dgv_po_no_list.RowCount - 1
            '        If dgv_po_no_list.Rows(index).Cells("cuspo").Value = LTrim(RTrim(in_ComplaintCallHeader.PO_NO.ToString)) Then
            '            dgv_po_no_list.Rows(index).Selected = True
            '            lab_po_no.Text = dgv_po_no_list.Rows(index).Cells("cuspo").Value.ToString
            '            Exit For
            '        End If
            '    Next
            'End If


            'If dgv_po_no_list.RowCount > 0 Then
            '    dgv_po_no_list.CurrentRow.Selected = True
            '    lab_po_no.Text = dgv_po_no_list.CurrentRow.Cells("cuspo").Value.ToString
            'End If
        Catch er As Exception
            MsgBox("Error in load_dgv_po_no_list." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub load_dgv_po_no_all_list()
        Try
            dgv_po_no_list.RowHeadersVisible = False
            dgv_po_no_list.AllowUserToAddRows = False
            dgv_po_no_list.AllowUserToDeleteRows = False
            dgv_po_no_list.ReadOnly = True
            dgv_po_no_list.Columns.Clear()

            Call Dgv_po_no_list_c_cols()

            Dim strSql As String =
            " select customerno, customername,itemno,itemdesc,qty,cuspo,ord_no,headerid " _
            & " from EXACT_TRAVELER_VIEW_HEADER_GRID_InProductionOnly "
            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)
            dgv_po_no_list.DataSource = dt

            'If dgv_po_no_list.RowCount > 0 And Not IsNothing(in_ComplaintCallHeader.PO_NO) And LTrim(RTrim(in_ComplaintCallHeader.PO_NO.ToString)) <> "" Then
            '    For index As Integer = 0 To dgv_po_no_list.RowCount - 1
            '        If dgv_po_no_list.Rows(index).Cells("cuspo").Value = LTrim(RTrim(in_ComplaintCallHeader.PO_NO.ToString)) Then
            '            dgv_po_no_list.Rows(index).Selected = True
            '            lab_po_no.Text = dgv_po_no_list.Rows(index).Cells("cuspo").Value.ToString
            '            Exit For
            '        End If
            '    Next
            'End If


            'If dgv_po_no_list.RowCount > 0 Then
            '    dgv_po_no_list.CurrentRow.Selected = True
            '    lab_po_no.Text = dgv_po_no_list.CurrentRow.Cells("cuspo").Value.ToString
            'End If
        Catch er As Exception
            MsgBox("Error in load_dgv_po_no_all_list." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(DgvComplatinDetailList.RowCount)

    End Sub

    Public Function Get_MDB_CFG_PRODUCT_List() As DataTable
        Get_MDB_CFG_PRODUCT_List = New DataTable
        Try
            Dim strSQL As String =
            " SELECT ISNULL(ID,0) AS COMPLAINT_CALL_PRODUCT_ID , " _
            & " rtrim(isnull(ENUM_VALUE,'')) AS COMPLAINT_CALL_PRODUCT_NAME " _
            & " FROM MDB_CFG_ENUM WHERE ENUM_CAT = 'ITEM_CLASS' " _
            & " ORDER BY ID "
            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)
            Get_MDB_CFG_PRODUCT_List = dt
        Catch er As Exception
            MsgBox("Error in Get_MDB_CFG_PRODUCT_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Function

    Public Function Get_CFG_DETAIL_TYPE_List() As DataTable
        Get_CFG_DETAIL_TYPE_List = New DataTable
        Try
            Dim strSQL As String =
            " select COMPLAINT_CALL_DETAIL_TYPE_ID,	COMPLAINT_CALL_DETAIL_TYPE_NAME " _
             & " from COMPLAINT_CALL_DETAIL_TYPE " _
             & " order by COMPLAINT_CALL_DETAIL_TYPE_ID "
            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)
            Get_CFG_DETAIL_TYPE_List = dt
        Catch er As Exception
            MsgBox("Error in Get_CFG_DETAIL_TYPE_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Function

    Private Sub bt_add_detail_Click(sender As Object, e As EventArgs) Handles bt_add_detail.Click
        Try
            lb_new_flag.Visible = True
            bt_add_detail.Enabled = False
            DgvComplatinDetailList.Enabled = False
            'MsgBox(DgvComplatinDetailList.BackColor.ToString)
            'DgvComplatinDetailList.BackgroundColor = Color.DarkGray
            m_cComplaintCallDetail = New cComplaintCallDetail
            m_cComplaintCallDetail.COMPLAINT_CALL_HEADER_ID = m_cComplaintCallHeader.COMPLAINT_CALL_HEADER_ID
            fill_detail_info_in_page(m_cComplaintCallDetail)
            gb_complaintdetail.Visible = True
        Catch er As Exception
            MsgBox("Error in bt_add_detail_Click." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub DgvComplatinDetailList_Click(sender As Object, e As EventArgs) Handles DgvComplatinDetailList.Click
        If DgvComplatinDetailList.CurrentRow Is Nothing Then Exit Sub
        If DgvComplatinDetailList.RowCount > 0 Then
            DgvComplatinDetailList.CurrentRow.Selected = True
            If Not (IsNothing(DgvComplatinDetailList.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_ID"))) Then
                If Not IsNothing(DgvComplatinDetailList.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_ID").Value) Then
                    'MsgBox(DgvComplatinDetailList.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_ID").Value.ToString)
                    'get detail
                    m_cComplaintCallDetail = New cComplaintCallDetail(CType(DgvComplatinDetailList.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_ID").Value, Integer))
                    fill_detail_info_in_page(m_cComplaintCallDetail)
                End If
            End If
        End If

    End Sub

    Private Sub fill_detail_info_in_page(ByVal in_omplaintCalldetail As cComplaintCallDetail)
        cbb_product_id.SelectedValue = in_omplaintCalldetail.COMPLAINT_CALL_PRODUCT_ID
        cbb_complaint_detail_type.SelectedValue = in_omplaintCalldetail.COMPLAINT_CALL_DETAIL_TYPE_ID
        tb_item_no.Text = in_omplaintCalldetail.ITEM_NO
        mtb_purchase_qty.Text = in_omplaintCalldetail.PURCHASE_QUANTITY
        tb_purchase_from.Text = in_omplaintCalldetail.PURCHASED_FROM
        rtx_complaint_detail.Text = in_omplaintCalldetail.COMPLAINT_DETAIL
        rtx_notes.Text = in_omplaintCalldetail.NOTE
        dtp_expiry_date.Value = in_omplaintCalldetail.EXPIRY_DATE
        tb_lot_no.Text = in_omplaintCalldetail.LOT_NO
        tb_logo_on_product.Text = in_omplaintCalldetail.LOGO_ON_PRODUCT
        tb_product_desc.Text = in_omplaintCalldetail.DESCRIPTION_PRODUCT
        lab_po_no.Text = m_cComplaintCallDetail.PO_NO
        tb_input_po_no.Text = m_cComplaintCallDetail.PO_NO
        tb_input_ord_no.Text = m_cComplaintCallDetail.ORD_NO
        mtb_ord_no.Text = m_cComplaintCallDetail.ORD_NO
        If lab_po_no.Text = "" Then
            cb_no_need_po.Checked = True
        Else
            cb_no_need_po.Checked = False
        End If
        Call initial_DGV_doc(in_omplaintCalldetail)
    End Sub

    Private Sub initial_DGV_doc(ByVal in_omplaintCalldetail As cComplaintCallDetail)
        'initial_DGV_doc
        Try
            'Dim strSQL As String =
            '" select  " _
            '& "    COMPLAINT_CALL_DETAIL_FILE_ID," _
            '& "    COMPLAINT_CALL_DETAIL_ID," _
            '& "    FILE_NAME," _
            '& "    FILE_EXT," _
            '& "    FILE_NOTE," _
            '& "    UPLOAD_DATETIME," _
            '& "    IF_VALID" _
            '& "    from COMPLAINT_CALL_DETAIL_FILE " _
            '& "    where COMPLAINT_CALL_DETAIL_ID = " + CStr(in_omplaintCalldetail.COMPLAINT_CALL_DETAIL_ID)
            'Dim dt As New DataTable
            'Dim db As New cDBA
            'dt = db.DataTable(strSQL)
            'With Dgv_complatin_doc
            '    .DataSource = dt
            '    .AllowUserToAddRows = False
            '    .AllowUserToDeleteRows = False
            '    .RowHeadersVisible = False
            '    .Columns("COMPLAINT_CALL_DETAIL_FILE_ID").Visible = False
            '    .Columns("COMPLAINT_CALL_DETAIL_ID").Visible = False
            '    .Columns("IF_VALID").Visible = False
            'End With
            Dim o_cCOMPLAINT_CALL_DETAIL_FILE_DAL As cCOMPLAINT_CALL_DETAIL_FILE_DAL
            o_cCOMPLAINT_CALL_DETAIL_FILE_DAL = New cCOMPLAINT_CALL_DETAIL_FILE_DAL

            Dim ol_cCOMPLAINT_CALL_DETAIL_FILE As List(Of cCOMPLAINT_CALL_DETAIL_FILE)
            ol_cCOMPLAINT_CALL_DETAIL_FILE = o_cCOMPLAINT_CALL_DETAIL_FILE_DAL.GetList(in_omplaintCalldetail.COMPLAINT_CALL_DETAIL_ID)

            With Dgv_complatin_doc
                .Columns.Clear()
                .Rows.Clear()
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .RowHeadersVisible = False
                .Columns.Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_FILE_ID", "COMPLAINT_CALL_DETAIL_FILE_ID", 50))
                .Columns.Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_ID", "COMPLAINT_CALL_DETAIL_ID", 50))
                .Columns.Add(DGVTextBoxColumn("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID", "COMPLAINT_CALL_DETAIL_FILE_TYPE_ID", 50))
                .Columns.Add(DGVTextBoxColumn("FILE_NAME", "FILE_NAME", 150))
                .Columns.Add(DGVTextBoxColumn("FILE_EXT", "FILE_EXT", 150))
                .Columns.Add(DGVTextBoxColumn("FILE_NOTE", "FILE_NOTE", 150))
                .Columns.Add(DGVTextBoxColumn("UPLOAD_DATETIME", "UPLOAD_DATETIME", 150))
                .Columns.Add(DGVTextBoxColumn("IF_VALID", "IF_VALID", 150))
                .Columns("COMPLAINT_CALL_DETAIL_FILE_ID").Visible = False
                .Columns("COMPLAINT_CALL_DETAIL_ID").Visible = False
                .Columns("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID").Visible = False
                .Columns("IF_VALID").Visible = False
                .Columns("IF_VALID").Visible = False
                .AutoResizeColumn(DataGridViewAutoSizeColumnMode.AllCells)
                .ReadOnly = True
            End With

            For Each oD In ol_cCOMPLAINT_CALL_DETAIL_FILE

                With Dgv_complatin_doc

                    .Rows.Add()
                    Dim i As Integer = .Rows.Count - 1
                    .Rows(i).Cells("COMPLAINT_CALL_DETAIL_FILE_ID").Value = oD.COMPLAINT_CALL_DETAIL_FILE_ID
                    .Rows(i).Cells("COMPLAINT_CALL_DETAIL_ID").Value = oD.COMPLAINT_CALL_DETAIL_ID
                    .Rows(i).Cells("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID").Value = oD.COMPLAINT_CALL_DETAIL_FILE_TYPE_ID
                    .Rows(i).Cells("FILE_NAME").Value = oD.FILE_NAME
                    .Rows(i).Cells("FILE_EXT").Value = oD.FILE_EXT
                    .Rows(i).Cells("FILE_NOTE").Value = oD.FILE_NOTE
                    .Rows(i).Cells("UPLOAD_DATETIME").Value = oD.UPLOAD_DATETIME
                    .Rows(i).Cells("IF_VALID").Value = oD.IF_VALID
                End With
            Next
        Catch er As Exception
            MsgBox("Error In Get_MDB_CFG_PRODUCT_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Sub Dgv_po_no_list_c_cols()
        Try
            'customerno, customername,itemno,itemdesc,qty,cuspo,headerid 
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("customerno", "customerno", 50))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("customername", "customername", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("itemno", "itemno", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("itemdesc", "itemdesc", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("qty", "qty", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("cuspo", "cuspo", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("ord_no", "ord_no", 100))
            dgv_po_no_list.Columns.Add(DGVTextBoxColumn("headerid", "headerid", 100))

            dgv_po_no_list.Columns("cuspo").DisplayIndex = 0
            dgv_po_no_list.Columns("customername").Visible = False

            dgv_item_list.RowHeadersVisible = False
            lb_new_flag.Visible = False
        Catch er As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Dgv_item_list_c_cols()
        Try
            dgv_item_list.Columns.Add(DGVTextBoxColumn("item_master_id", "item_master_id", 100))
            dgv_item_list.Columns.Add(DGVTextBoxColumn("ITEM_CD", "ITEM_CD", 80))
            dgv_item_list.Columns.Add(DGVTextBoxColumn("ITEM_ID", "ITEM_ID", 100))
            dgv_item_list.Columns.Add(DGVTextBoxColumn("VALUE_STR", "VALUE_STR", 20))
            dgv_item_list.Columns.Add(DGVTextBoxColumn("ITEM_CLASSIFICATION_ID", "ITEM_CLASSIFICATION_ID", 10))
            dgv_item_list.Columns("item_master_id").Visible = False
            dgv_item_list.Columns("ITEM_CLASSIFICATION_ID").Visible = False
            dgv_item_list.Columns("ITEM_ID").Visible = False
            dgv_item_list.Columns("VALUE_STR").Width = 400
            dgv_item_list.AllowUserToAddRows = False
            dgv_item_list.AllowUserToDeleteRows = False

            dgv_item_list.RowHeadersVisible = False
            dgv_item_list.ColumnHeadersVisible = False

        Catch er As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub tb_item_no_TextChanged(sender As Object, e As EventArgs) Handles tb_item_no.TextChanged


        Dim row_id As Int32
        row_id = 0
        Try
            If LTrim(RTrim(tb_item_no.Text)).Length > 2 Then
                dgv_item_list.DataSource = Nothing
                dgv_item_list.Refresh()

                Call Dgv_item_list_c_cols()

                Call Dgv_item_list_filter(LTrim(RTrim(tb_item_no.Text)))
            Else
                dgv_item_list.DataSource = Nothing
            End If
        Catch er As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Dgv_item_list_filter(ByVal pstr_item_cd As String)
        Try

            Dim db As New cDBA

            ' Dim strLoadString As String =
            '" Select t1.item_master_id , t1.item_cd, t1.item_id, t2.VALUE_STR " _
            '& " From mdb_item_master t1  " _
            '& " inner Join MDB_ITEM_FLD_VALUE t2 On t1.ITEM_MASTER_ID = t2.ITEM_MASTER_ID " _
            '& " where t2.ITEM_FLD_ID = 65  " _
            '& " And t2.LANGUAGE = 'EN' and t2.COUNTRY = 'CA' and t2.VALUE_STR is not null " _
                '& " And t1.ITEM_CD like '%" & pstr_item_cd & "%'"

                ' Dim strLoadString As String =
                '" select t1.item_master_id , t1.item_no item_cd, t1.item_variant_id item_id, t2.VALUE_STR " _
                '& " From mdb_item_variant t1  " _
                '& " inner Join MDB_ITEM_FLD_VALUE t2 on t1.ITEM_MASTER_ID = t2.ITEM_MASTER_ID " _
                '& " where t2.ITEM_FLD_ID = 65  " _
                '& " And t2.LANGUAGE = 'EN' and t2.COUNTRY = 'CA' and t2.VALUE_STR is not null " _
                '& " And t1.ITEM_no like '%" & pstr_item_cd & "%'"

                Dim strLoadString As String =
             " select t1.item_master_id , t1.item_no item_cd, t1.item_variant_id item_id, t2.VALUE_STR , tm.ITEM_CLASSIFICATION_ID " _
            & " From mdb_item_variant t1  " _
            & " inner Join MDB_ITEM_FLD_VALUE t2 On t1.ITEM_MASTER_ID = t2.ITEM_MASTER_ID " _
            & "             inner Join mdb_item_master tm On tm.ITEM_MASTER_ID = t1.ITEM_MASTER_ID " _
            & " inner Join MDB_CFG_ENUM tc on tc.id = tm.ITEM_CLASSIFICATION_ID " _
            & " where t2.ITEM_FLD_ID = 65  " _
            & " And t2.LANGUAGE = 'EN' and t2.COUNTRY = 'CA' and t2.VALUE_STR is not null " _
            & " and tc.ENUM_CAT = 'ITEM_CLASS' " _
            & " And t1.ITEM_no like '%" & pstr_item_cd & "%'"



            dgv_item_list.DataSource = db.DataTable(strLoadString)
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub cbb_complaint_detail_type_initial()
        cbb_complaint_detail_type.Items.Clear()
        Dim dt_complaint_detail_type As DataTable = Get_CFG_DETAIL_TYPE_List()
        If dt_complaint_detail_type.Rows.Count <> 0 Then
            With cbb_complaint_detail_type
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DataSource = dt_complaint_detail_type
                .DisplayMember = "COMPLAINT_CALL_DETAIL_TYPE_NAME"
                .ValueMember = "COMPLAINT_CALL_DETAIL_TYPE_ID"
            End With
        End If
    End Sub

    Private Sub cbb_product_id_initial()
        cbb_product_id.Items.Clear()
        Dim dt_cbb_product_id As DataTable = Get_MDB_CFG_PRODUCT_List()
        If dt_cbb_product_id.Rows.Count <> 0 Then
            With cbb_product_id
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DataSource = dt_cbb_product_id
                .DisplayMember = "COMPLAINT_CALL_PRODUCT_NAME"
                .ValueMember = "COMPLAINT_CALL_PRODUCT_ID"
            End With
        End If
    End Sub

    Private Sub dgv_item_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_item_list.CellClick
        If dgv_item_list.RowCount > 0 Then
            dgv_item_list.CurrentRow.Selected = True
            tb_item_no.Text = Trim(dgv_item_list.CurrentRow.Cells("ITEM_CD").Value.ToString)
            cbb_product_id.SelectedValue = Trim(dgv_item_list.CurrentRow.Cells("ITEM_CLASSIFICATION_ID").Value.ToString)
            tb_product_desc.Text = Trim(dgv_item_list.CurrentRow.Cells("VALUE_STR").Value.ToString)
        End If
        'If e.RowIndex < 0 Then
        '    Exit Sub
        'End If
        ''dgv_item_list.Rows(e.RowIndex).Selected = True
        'tb_item_no.Text = dgv_item_list.Rows(e.RowIndex).Cells("ITEM_CD").Value.ToString
    End Sub

    Private Sub dgv_po_no_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_po_no_list.CellClick
        If dgv_po_no_list.RowCount > 0 Then
            dgv_po_no_list.CurrentRow.Selected = True
            lab_po_no.Text = Trim(dgv_po_no_list.CurrentRow.Cells("cuspo").Value.ToString)
            tb_item_no.Text = Trim(dgv_po_no_list.CurrentRow.Cells("itemno").Value.ToString)
            mtb_purchase_qty.Text = Trim(dgv_po_no_list.CurrentRow.Cells("qty").Value.ToString)
            tb_product_desc.Text = Trim(dgv_po_no_list.CurrentRow.Cells("itemdesc").Value.ToString)
            mtb_ord_no.Text = Trim(dgv_po_no_list.CurrentRow.Cells("ord_no").Value.ToString)
        End If


        'If e.RowIndex < 0 Then
        '    Exit Sub
        'End If
        ''dgv_item_list.Rows(e.RowIndex).Selected = True
        'tb_item_no.Text = dgv_item_list.Rows(e.RowIndex).Cells("ITEM_CD").Value.ToString

    End Sub

    Private Sub tb_input_po_no_TextChanged(sender As Object, e As EventArgs) Handles tb_input_po_no.TextChanged
        Try
            'Dim currencyManager1 As CurrencyManager
            'currencyManager1 = CType(BindingContext(dgv_po_no_list.DataSource), CurrencyManager)
            dgv_po_no_list.CurrentCell = Nothing
            'If LTrim(RTrim(tb_input_po_no.Text)).Length > 2 Then
            'dgv_po_no_list fliter
            If dgv_po_no_list.RowCount > 0 Then
                For index As Integer = 0 To dgv_po_no_list.RowCount - 1
                    If (dgv_po_no_list.Rows(index).Cells("cuspo").Value Like "*" + LTrim(RTrim(tb_input_po_no.Text)) + "*") And
                        (dgv_po_no_list.Rows(index).Cells("ord_no").Value Like "*" + LTrim(RTrim(tb_input_ord_no.Text)) + "*") Then
                        dgv_po_no_list.Rows.Item(index).Visible = True
                    Else
                        dgv_po_no_list.Rows.Item(index).Visible = False
                    End If
                Next
            End If
            'End If
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgv_item_list_DataSourceChanged(sender As Object, e As EventArgs) Handles dgv_item_list.DataSourceChanged
        If dgv_item_list.RowCount = 1 Then
            dgv_item_list.Rows(0).Selected = True
            tb_item_no.Text = Trim(dgv_item_list.CurrentRow.Cells("ITEM_CD").Value.ToString)
            cbb_product_id.SelectedValue = dgv_item_list.CurrentRow.Cells("ITEM_CLASSIFICATION_ID").Value.ToString
        End If
    End Sub

    Private Sub cb_no_need_po_CheckedChanged(sender As Object, e As EventArgs) Handles cb_no_need_po.CheckedChanged
        If cb_no_need_po.Checked Then
            lab_po_no.Text = ""
            tb_input_po_no.Enabled = False
            dgv_po_no_list.Enabled = False
            tb_input_ord_no.Enabled = False

        Else
            tb_input_po_no.Enabled = True
            dgv_po_no_list.Enabled = True
            tb_input_ord_no.Enabled = True
        End If
    End Sub

    Private Sub tb_input_ord_no_TextChanged(sender As Object, e As EventArgs) Handles tb_input_ord_no.TextChanged
        Try
            'Dim currencyManager1 As CurrencyManager
            'currencyManager1 = CType(BindingContext(dgv_po_no_list.DataSource), CurrencyManager)
            dgv_po_no_list.CurrentCell = Nothing
            'If LTrim(RTrim(tb_input_po_no.Text)).Length > 2 Then
            'dgv_po_no_list fliter
            If dgv_po_no_list.RowCount > 0 Then
                For index As Integer = 0 To dgv_po_no_list.RowCount - 1
                    If (dgv_po_no_list.Rows(index).Cells("cuspo").Value Like "*" + LTrim(RTrim(tb_input_po_no.Text)) + "*") And
                        (dgv_po_no_list.Rows(index).Cells("ord_no").Value Like "*" + LTrim(RTrim(tb_input_ord_no.Text)) + "*") Then
                        dgv_po_no_list.Rows.Item(index).Visible = True
                    Else
                        dgv_po_no_list.Rows.Item(index).Visible = False
                    End If
                Next
            End If
            'End If
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub btn_complatin_doc_add_Click(sender As Object, e As EventArgs) Handles btn_complatin_doc_add.Click
        Try

            Dim fd As OpenFileDialog = New OpenFileDialog()

            fd.Title = "Select a File to Add"
            fd.InitialDirectory = "C:\"
            fd.Filter = "Image Files(*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                Dim oDoc As cCOMPLAINT_CALL_DETAIL_FILE = New cCOMPLAINT_CALL_DETAIL_FILE
                'txtFileToSave.Text = fd.FileName
                '                MsgBox(fd.FileName)
                Dim fs As New System.IO.FileStream(fd.FileName, IO.FileMode.Open)
                Dim br As New System.IO.BinaryReader(fs)
                Dim data() As Byte = br.ReadBytes(fs.Length)
                oDoc.FILE_CONTENT = data
                br.Close()
                fs.Close()
                'oDoc.COMPLAINT_CALL_DETAIL_FILE_ID = 0

                oDoc.COMPLAINT_CALL_DETAIL_ID = m_cComplaintCallDetail.COMPLAINT_CALL_DETAIL_ID
                oDoc.COMPLAINT_CALL_DETAIL_FILE_TYPE_ID = 1
                oDoc.FILE_NAME = System.IO.Path.GetFileNameWithoutExtension(fd.FileName)

                oDoc.FILE_EXT = Replace(System.IO.Path.GetExtension(fd.FileName), ".", "")
                oDoc.FILE_NOTE = System.IO.Path.GetFileNameWithoutExtension(fd.FileName)
                oDoc.UPLOAD_DATETIME = DateTime.Now
                'MsgBox(Now().ToString())

                oDoc.IF_VALID = 1

                Dim o_cCOMPLAINT_CALL_DETAIL_FILE_DAL As cCOMPLAINT_CALL_DETAIL_FILE_DAL
                o_cCOMPLAINT_CALL_DETAIL_FILE_DAL = New cCOMPLAINT_CALL_DETAIL_FILE_DAL
                o_cCOMPLAINT_CALL_DETAIL_FILE_DAL.Save(oDoc)
                Call initial_DGV_doc(m_cComplaintCallDetail)
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DgvComplatinDetailList_AutoSizeChanged(sender As Object, e As EventArgs) Handles DgvComplatinDetailList.AutoSizeChanged

    End Sub

    Private Sub btn_complatin_doc_del_Click(sender As Object, e As EventArgs) Handles btn_complatin_doc_del.Click
        If IsNothing(m_cComplaintCalldoc) Then
            MsgBox("please select file")
            Exit Sub
        End If
        Dim o_cCOMPLAINT_CALL_DETAIL_FILE_DAL As cCOMPLAINT_CALL_DETAIL_FILE_DAL
        o_cCOMPLAINT_CALL_DETAIL_FILE_DAL = New cCOMPLAINT_CALL_DETAIL_FILE_DAL
        Dim dr As DialogResult = MessageBox.Show("Are you sure you will delete the file: " & m_cComplaintCalldoc.FILE_NAME, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dr = DialogResult.OK Then
            o_cCOMPLAINT_CALL_DETAIL_FILE_DAL.Delete(m_cComplaintCalldoc.COMPLAINT_CALL_DETAIL_FILE_ID)
            m_cComplaintCalldoc = Nothing
            Call initial_DGV_doc(m_cComplaintCallDetail)
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Dgv_complatin_doc_Click(sender As Object, e As EventArgs) Handles Dgv_complatin_doc.Click
        If Dgv_complatin_doc.CurrentRow Is Nothing Then Exit Sub
        If Dgv_complatin_doc.RowCount > 0 Then
            Dgv_complatin_doc.CurrentRow.Selected = True
            If Not (IsNothing(Dgv_complatin_doc.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_FILE_ID"))) Then
                m_cComplaintCalldoc = New cCOMPLAINT_CALL_DETAIL_FILE
                Dim ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL As cCOMPLAINT_CALL_DETAIL_FILE_DAL
                ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL = New cCOMPLAINT_CALL_DETAIL_FILE_DAL
                'm_cComplaintCalldoc.COMPLAINT_CALL_DETAIL_FILE_ID = Dgv_complatin_doc.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_FILE_ID").Value
                m_cComplaintCalldoc = ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL.Load(Dgv_complatin_doc.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_FILE_ID").Value)
            End If
        End If
    End Sub

    Private Sub Dgv_complatin_doc_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_complatin_doc.DoubleClick
        If Dgv_complatin_doc.CurrentRow Is Nothing Then Exit Sub
        Dim ol_cCOMPLAINT_CALL_DETAIL_FILE As cCOMPLAINT_CALL_DETAIL_FILE
        Dim ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL As cCOMPLAINT_CALL_DETAIL_FILE_DAL
        ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL = New cCOMPLAINT_CALL_DETAIL_FILE_DAL

        If Dgv_complatin_doc.CurrentRow Is Nothing Then Exit Sub
        If Dgv_complatin_doc.RowCount > 0 Then
            Dgv_complatin_doc.CurrentRow.Selected = True
            If Not (IsNothing(Dgv_complatin_doc.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_FILE_ID"))) Then
                ol_cCOMPLAINT_CALL_DETAIL_FILE = ol_cCOMPLAINT_CALL_DETAIL_FILE_DAL.get_cOMPLAINT_CALL_DETAIL_FILE(Dgv_complatin_doc.CurrentRow.Cells("COMPLAINT_CALL_DETAIL_FILE_ID").Value)
            End If
        End If




        Dim byteStream As Byte()

        '' save document to file system

        Dim strSaveName As String = ol_cCOMPLAINT_CALL_DETAIL_FILE.FILE_NAME & "." & ol_cCOMPLAINT_CALL_DETAIL_FILE.FILE_EXT


        byteStream = CType(ol_cCOMPLAINT_CALL_DETAIL_FILE.FILE_CONTENT, Byte())

        If (Not Directory.Exists("C:\tempfiles")) Then
            Directory.CreateDirectory("C:\tempfiles")
        End If

        Dim newFile As FileStream = File.Create("C:\tempfiles\" & strSaveName)
        newFile.Write(byteStream, 0, byteStream.Length)
        newFile.Dispose()

        ' Open document 

        Dim p As New System.Diagnostics.Process
        Dim s As New System.Diagnostics.ProcessStartInfo("C:\tempfiles\" & strSaveName)
        s.UseShellExecute = True
        s.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = s
        p.Start()
    End Sub
End Class