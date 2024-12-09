Public Class FrmComplsint_call_main
    Dim db As New cDBA()
    Dim DT_tables As DataTable
    Dim strSql As String

    Dim table_name As String
    Dim arr_column_name() As String
    Dim DGV_CFG_TABLE_CONTENT_row_count_before As Integer = 0

    Private mc_COMPLAINT_CALL_USER As cComplaintCallUser


    Private Sub FrmComplsint_call_main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''
        DGV_USER_LIST.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Call DGV_CFG_Tables_Load()
        DataCallHeaderList.AllowUserToAddRows = False
        DGV_USER_LIST.AllowUserToAddRows = False

        DataCallHeaderList.RowHeadersVisible = False
        DGV_USER_LIST.RowHeadersVisible = False
        TabPage2.Enabled = False

        Call serach_fill_user_with_condtion("")
        ''
    End Sub

    Public Function get_cus_no_from_po(ByVal in_po_no As String) As String
        Dim l_cus_no As String = ""
        get_cus_no_from_po = ""

        Try
            Dim strSQL As String =
              " SELECT top 1   " _
                & "                          LTRIM(HEAD.cus_no) AS CustomerNo, CUS.cmp_name AS CustomerName,  " _
                & "                          ORD.Item_no AS ItemNo, ORD.Item_Desc_1 AS ItemDesc, ORD.Qty_Ordered AS Qty,   " _
                & "           LTRIM(RTRIM(OEH.oe_po_no)) AS CusPO " _
                & "                          " _
                & "    " _
                & " FROM            dbo.EXACT_TRAVELER_DETAILS AS DET  " _
                & "  " _
                & " INNER JOIN " _
                & "                          dbo.EXACT_TRAVELER_HEADER AS HEAD ON DET.HeaderID = HEAD.HeaderID   " _
                & " INNER JOIN " _
                & "                          dbo.cicmpy AS CUS ON LTRIM(RTRIM(HEAD.cus_no)) = LTRIM(RTRIM(CUS.cmp_code)) " _
                & " INNER JOIN dbo.EXACT_TRAVELER_VIEW_OE_ITEMS_AND_PARENTS AS ORD ON HEAD.ord_no = ORD.Ord_no AND HEAD.Line_no = ORD.Line_no AND HEAD.Component_seq_no = ORD.Component_seq_No						  " _
                & " INNER JOIN  dbo.oeordhdr_sql AS OEH ON ORD.Ord_no = OEH.ord_no " _
                & " where LTRIM(RTRIM(OEH.oe_po_no)) like '%" & LTrim(RTrim(in_po_no)) & "%' "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            If dt.Rows.Count = 1 Then
                l_cus_no = dt.Rows(0).Item("CustomerNo").ToString

            End If
            get_cus_no_from_po = l_cus_no

        Catch er As Exception
            MsgBox("Error in get_cus_no_from_po." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function get_cus_no_from_ordno(ByVal in_ord_no As String) As String
        Dim l_cus_no As String = ""
        get_cus_no_from_ordno = ""

        Try
            '" select top 1 ltrim(rtrim(customerno))  as CustomerNo from EXACT_TRAVELER_VIEW_HEADER_GRID_InProductionOnly where ord_no =  " & in_ord_no.ToString
            Dim strSQL As String = " Select isnull( STUFF((SELECT ','+''''+ltrim(rtrim(customerno))+'''' " _
            & " FROM  EXACT_TRAVELER_VIEW_HEADER_GRID_InProductionOnly (NOLOCK) " _
            & " where CAST(ord_no As varchar(10)) Like  '%" & in_ord_no & "%' " _
            & " For Xml path('')),1,1,'') 	,'') as CustomerNo "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            If dt.Rows.Count = 1 Then
                l_cus_no = dt.Rows(0).Item("CustomerNo").ToString

            End If
            get_cus_no_from_ordno = l_cus_no

        Catch er As Exception
            MsgBox("Error in get_cus_no_from_ordno." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Function

    Private Sub BT_Search_Click(sender As Object, e As EventArgs) Handles BT_Search.Click
        'gather search condition
        Dim input_ref_no As String = ""
        Dim input_customer_name As String = ""
        Dim input_customer_phone_number As String = ""
        Dim input_customer_email As String = ""
        Dim input_cus_no As String = ""
        Dim input_po_no As String = "" 'po
        Dim input_ord_no As String = "" 'po

        input_ref_no = Trim(tb_ref_no.Text)
        input_customer_name = Trim(tb_customer_name.Text)
        input_customer_phone_number = Trim(tb_customer_phone_no.Text)
        input_customer_email = Trim(tb_customer_email.Text)
        input_cus_no = Trim(tb_cus_no.Text)
        input_po_no = Trim(tb_po_no.Text)
        input_ord_no = Trim(mtb_ord_no.Text)

        Dim search_condition As String = " where "
        If input_customer_name <> "" Then search_condition = search_condition & "[FIRST_NAME]+[LAST_NAME] like '%" & input_customer_name & "%' and "
        If input_customer_phone_number <> "" Then search_condition = search_condition & "[USER_CONTACT_PHONE_NUMBER] like '%" & input_customer_phone_number & "%' and "
        If input_customer_email <> "" Then search_condition = search_condition & "[USER_EMAIL] like '%" & input_customer_email & "%' and "
        If input_ref_no <> "" Then search_condition = search_condition _
                & "[COMPLAINT_CALL_USER_ID] = (select top 1 COMPLAINT_CALL_USER_ID from COMPLAINT_CALL_HEADER where COMPLAINT_CALL_HEADER_ID = " _
                & input_ref_no.ToString & ") and "
        If input_cus_no <> "" Then search_condition = search_condition & "[CUS_NO] like '%" & input_cus_no & "%' and "
        If input_po_no <> "" Then
            Dim cus_no_from_po As String = ""
            cus_no_from_po = get_cus_no_from_po(input_po_no)
            search_condition = search_condition & "[CUS_NO] = '" & cus_no_from_po & "' and "
        End If
        If input_ord_no <> "" Then
            Dim cus_no_from_ord_no As String = ""
            cus_no_from_ord_no = get_cus_no_from_ordno(input_ord_no)
            If cus_no_from_ord_no <> "" Then
                search_condition = search_condition & "[CUS_NO] in (" & cus_no_from_ord_no & ") and "
            Else
                search_condition = search_condition & " 1 = 2 and "
            End If

        End If

        If search_condition = " where " Then
            search_condition = ""
        Else
            search_condition = search_condition.Remove(search_condition.LastIndexOf("and") - 1)
        End If

        Call serach_fill_user_with_condtion(search_condition)
    End Sub

    Private Sub serach_fill_user_with_condtion(ByVal in_condition_str As String)
        Dim from_str As String
        Dim search_condition = in_condition_str
        from_str = "(  SELECT	 99999 as COMPLAINT_CALL_USER_ID,  C.CUS_NAME as [FIRST_NAME], CN.FullName   as [LAST_NAME], " _
                & " 1 As LANGUAGE_ID, C.PHONE_NO as [USER_CONTACT_PHONE_NUMBER],  " _
                & " isnull(C.ADDR_1,'') + isnull(C.ADDR_2,'')+ isnull(C.ADDR_3,'') As USER_ADDRESS, " _
                & "  C.ZIP As USER_POST_CODE ,C.STATE As USER_CITY, " _
                & "   CN.cnt_email As USER_EMAIL,null As CREATE_BY , null As CREATE_DATE , H.FULLNAME As BELONG_CSR	, " _
                & " 99 As STATUS ,C.CUS_NO" _
                & "            FROM		ARCUSFIL_SQL C   " _
                & "            LEFT JOIN  CICMPY P On C.CUS_NO = P.CMP_CODE  " _
                & "            LEFT JOIN HUMRES H On P.ACCOUNTEMPLOYEEID = H.RES_ID  " _
                & " LEFT JOIN  CiCntp       CN   WITH (Nolock) ON p.Cnt_ID = CN.Cnt_ID and ISNULL(CN.active_y,0) = 1 " _
                & " where   ltrim(rtrim(C.CUS_NO)) != '000000' and  C.CUS_NO  not in (select CUS_NO from [dbo].[COMPLAINT_CALL_USER] )" _
                & " union all " _
                & " Select [COMPLAINT_CALL_USER_ID], " _
                & "                 [FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]   " _
                & "                 ,[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,CUS_NO as [CUS_NO] " _
                & "                 FROM [dbo].[COMPLAINT_CALL_USER]  )  t1"
        strSql = " Select [COMPLAINT_CALL_USER_ID], " _
                & "[FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]  " _
                & ",[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,[CUS_NO] " _
                & ",(select top 1 LANGUAGE_CODE from MDB_CFG_LANGUAGE l where l.LANGUAGE_ID = t1. LANGUAGE_ID ) as [LANGUAGE_CODE] " _
                & " FROM " & from_str & " " _
                & search_condition _
                & " ORDER BY [COMPLAINT_CALL_USER_ID] "
        DT_tables = db.DataTable(strSql)
        Call dgv_fill_user_list(DT_tables)
    End Sub
    'Private Sub dgv_fill_from_dataset(ByVal dgv As DataGridView, ByVal dt As DataTable)
    '    Try
    '       dgv.Columns.Clear()
    'If dt.Rows.Count <> 0 Then
    'Dim name(dt.Columns.Count) As String
    'Dim i As Integer = 0
    'For Each column As DataColumn In dt.Columns
    '               name(i) = column.ColumnName
    'With dgv.Columns
    '.Add(DGVTextBoxColumn(name(i), name(i), 100))
    'End With
    'Next
    '           dgv.DataSource = dt
    'End If
    'Catch er As Exception
    '       MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    'End Try

    'End Sub

    Private Sub BT_Create_user_Click(sender As Object, e As EventArgs) Handles BT_Create_user.Click
        Using frm_createUser = New frmUserMaintenance()
            frm_createUser.ShowDialog()
        End Using
    End Sub

    Private Sub bt_cfg_save_Click_1(sender As Object, e As EventArgs) Handles bt_cfg_save.Click
        'DGV_CFG_TABLE_CONTENT
        'DGV_CFG_TABLE_CONTENT_row_count_before



    End Sub

    'Private Sub DGV_CFG_TABLE_CONTENT_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_CFG_TABLE_CONTENT.CellValueChanged
    '    Try
    '        If DGV_CFG_TABLE_CONTENT.Rows.Count > DGV_CFG_TABLE_CONTENT_row_count_before Or DGV_CFG_TABLE_CONTENT.Rows.Count = 0 Then
    '            Dim strda = "Select * from " & table_name
    '            Dim str_update_sql As String = "insert " & table_name _
    '                                            & " values("
    '        Else
    '            Dim str_updated_column_name As String = DGV_CFG_TABLE_CONTENT.Columns(e.ColumnIndex).HeaderText
    '            Dim str_updated_value As String = DGV_CFG_TABLE_CONTENT.CurrentCell.Value.ToString
    '            Dim str_updated_TPK_value As String = DGV_CFG_TABLE_CONTENT.Rows(e.RowIndex).Cells(0).Value.ToString
    '            Dim str_updated_TPK_name As String = DGV_CFG_TABLE_CONTENT.Columns(0).HeaderText
    '            Dim str_update_sql As String = " update " & table_name _
    '                                        & " Set " & str_updated_column_name & " = '" & str_updated_value & "' " _
    '                                        & " where " & str_updated_TPK_name & " = '" & str_updated_TPK_value & "' "
    '            db.Execute(str_update_sql)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error in DGV_CFG_TABLE_CONTENT_CellValueChanged." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Private Sub DGV_CFG_TABLE_CONTENT_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_CFG_TABLE_CONTENT.RowLeave
    '    Dim INSERT_COLUMN_LIST As String = ""
    '    Dim INSERT_values_LIST As String = ""
    '    If DGV_CFG_TABLE_CONTENT.Rows.Count > DGV_CFG_TABLE_CONTENT_row_count_before Or DGV_CFG_TABLE_CONTENT.Rows.Count = 0 Then
    '        For Each columns_name In arr_column_name
    '            INSERT_COLUMN_LIST = INSERT_COLUMN_LIST + columns_name + " , "
    '            INSERT_values_LIST = INSERT_values_LIST + " '" + DGV_CFG_TABLE_CONTENT.Rows(e.RowIndex).Cells(columns_name).Value.ToString + "' ,"
    '            'MsgBox(DGV_CFG_TABLE_CONTENT.Rows(e.RowIndex).Cells(columns_name).Value.ToString)
    '        Next
    '        INSERT_COLUMN_LIST = INSERT_COLUMN_LIST.Substring(INSERT_COLUMN_LIST.IndexOf(",") + 1)
    '        INSERT_COLUMN_LIST = INSERT_COLUMN_LIST.Remove(INSERT_COLUMN_LIST.LastIndexOf(",") - 1)

    '        INSERT_values_LIST = INSERT_values_LIST.Substring(INSERT_values_LIST.IndexOf(",") + 1)
    '        INSERT_values_LIST = INSERT_values_LIST.Remove(INSERT_values_LIST.LastIndexOf(",") - 1)

    '        'MsgBox(e.RowIndex.ToString + " insert " + table_name + " (" + INSERT_COLUMN_LIST + ") values ( " + INSERT_values_LIST + " )")
    '        db.Execute(" insert " + table_name + " (" + INSERT_COLUMN_LIST + ") values ( " + INSERT_values_LIST + " )")


    '    End If

    'End Sub

    Private Sub DGV_USER_LIST_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_USER_LIST.CellClick
        'get user_id
        'fill dgv header
        mc_COMPLAINT_CALL_USER = New cComplaintCallUser(CType(DGV_USER_LIST.CurrentRow.Cells("COMPLAINT_CALL_USER_ID").Value, Integer))
        If DGV_USER_LIST.CurrentRow.Cells("COMPLAINT_CALL_USER_ID").Value = 99999 Then
            mc_COMPLAINT_CALL_USER.COMPLAINT_CALL_USER_ID = 99999
            If Not (DGV_USER_LIST.CurrentRow.Cells("FIRST_NAME").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.FIRST_NAME = CType(DGV_USER_LIST.CurrentRow.Cells("FIRST_NAME").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("LAST_NAME").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.LAST_NAME = CType(DGV_USER_LIST.CurrentRow.Cells("LAST_NAME").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("LANGUAGE_ID").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.LANGUAGE_ID = CType(DGV_USER_LIST.CurrentRow.Cells("LANGUAGE_ID").Value, Integer)
            If Not (DGV_USER_LIST.CurrentRow.Cells("USER_CONTACT_PHONE_NUMBER").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.USER_CONTACT_PHONE_NUMBER = CType(DGV_USER_LIST.CurrentRow.Cells("USER_CONTACT_PHONE_NUMBER").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("USER_ADDRESS").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.USER_ADDRESS = CType(DGV_USER_LIST.CurrentRow.Cells("USER_ADDRESS").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("USER_POST_CODE").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.USER_POST_CODE = CType(DGV_USER_LIST.CurrentRow.Cells("USER_POST_CODE").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("USER_CITY").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.USER_CITY = CType(DGV_USER_LIST.CurrentRow.Cells("USER_CITY").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("USER_EMAIL").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.USER_EMAIL = CType(DGV_USER_LIST.CurrentRow.Cells("USER_EMAIL").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("CREATE_BY").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.CREATE_BY = CType(DGV_USER_LIST.CurrentRow.Cells("CREATE_BY").Value, String)
            mc_COMPLAINT_CALL_USER.CREATE_DATE = Date.Now
            If Not (DGV_USER_LIST.CurrentRow.Cells("BELONG_CSR").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.BELONG_CSR = CType(DGV_USER_LIST.CurrentRow.Cells("BELONG_CSR").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("STATUS").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.STATUS = CType(DGV_USER_LIST.CurrentRow.Cells("STATUS").Value, String)
            If Not (DGV_USER_LIST.CurrentRow.Cells("CUS_NO").Value.Equals(DBNull.Value)) Then mc_COMPLAINT_CALL_USER.CUS_NO = CType(DGV_USER_LIST.CurrentRow.Cells("CUS_NO").Value, String)
        End If
        strSql = " SELECT [COMPLAINT_CALL_HEADER_ID] " _
              & " ,[COMPLAINT_CALL_USER_ID] " _
              & " ,[COMPLAINT_CALL_TYPE_ID] " _
              & " ,( select top 1 a1.COMPLAINT_CALL_TYPE_NAME from COMPLAINT_CALL_TYPE a1 where a1.COMPLAINT_CALL_TYPE_ID = t1.COMPLAINT_CALL_TYPE_ID ) as [COMPLAINT_CALL_TYPE_NAME] " _
              & " ,[COMPLAINT_CALL_LEVEL_ID] " _
              & " ,( select top 1 a2.COMPLAINT_CALL_LEVEL_NAME from COMPLAINT_CALL_LEVEL a2 where a2.COMPLAINT_CALL_LEVEL_ID = t1.COMPLAINT_CALL_LEVEL_ID ) as [COMPLAINT_CALL_LEVEL_NAME] " _
              & " ,[COMPLAINT_CALL_STATUS_ID] " _
              & " ,( select top 1 a3.COMPLAINT_CALL_STATUS_NAME from COMPLAINT_CALL_STATUS a3 where a3.COMPLAINT_CALL_STATUS_ID = t1.COMPLAINT_CALL_STATUS_ID ) as [COMPLAINT_CALL_STATUS_NAME] " _
              & " ,[CALL_DATE] , [PO_NO]" _
              & " FROM [dbo].[COMPLAINT_CALL_HEADER] t1 " _
              & " WHERE COMPLAINT_CALL_USER_ID = " & mc_COMPLAINT_CALL_USER.COMPLAINT_CALL_USER_ID.ToString _
              & " ORDER BY [COMPLAINT_CALL_HEADER_ID] "
        DT_tables = db.DataTable(strSql)
        Rtb_user_name.Text = mc_COMPLAINT_CALL_USER.get_user_name()
        Call dgv_fill_header_list(DT_tables)
    End Sub


    ''
    Private Sub dgv_fill_header_list(ByVal dt As DataTable)
        Try
            Dim comboboxColumn As DataGridViewComboBoxColumn
            DataCallHeaderList.Columns.Clear()
            Dim column_wide As Integer = 185
            If dt.Rows.Count <> 0 Then
                With DataCallHeaderList.Columns
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_HEADER_ID", "COMPLAINT_Ref_NO", column_wide))
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_USER_ID", "COMPLAINT_CALL_USER_ID", column_wide))
                    comboboxColumn = New DataGridViewComboBoxColumn()
                    comboboxColumn.DataPropertyName = "COMPLAINT_CALL_TYPE_ID"
                    comboboxColumn.HeaderText = "COMPLAINT_CALL_TYPE_ID"
                    comboboxColumn.Name = "COMPLAINT_CALL_TYPE_ID"
                    With comboboxColumn
                        .ValueMember = "COMPLAINT_CALL_TYPE_ID"
                        .DisplayMember = "COMPLAINT_CALL_TYPE_NAME"
                        .DataSource = Get_MDB_CFG_COMPLAINT_CALL_TYPE_List()
                    End With
                    .Add(comboboxColumn)
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_TYPE_NAME", "COMPLAINT_CALL_TYPE_NAME", column_wide))
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_LEVEL_ID", "COMPLAINT_CALL_LEVEL_ID", column_wide))
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_LEVEL_NAME", "COMPLAINT_CALL_LEVEL_NAME", column_wide))
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_STATUS_ID", "COMPLAINT_CALL_STATUS_ID", column_wide))
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_STATUS_NAME", "COMPLAINT_CALL_STATUS_NAME", column_wide))
                    .Add(DGVTextBoxColumn("CALL_DATE", "CALL_DATE", column_wide))
                    .Add(DGVTextBoxColumn("PO_NO", "PO_NO", column_wide))
                End With
                With DataCallHeaderList
                    .Columns("COMPLAINT_CALL_USER_ID").Visible = False
                    .Columns("COMPLAINT_CALL_TYPE_ID").Visible = False
                    .Columns("COMPLAINT_CALL_LEVEL_ID").Visible = False
                    .Columns("COMPLAINT_CALL_STATUS_ID").Visible = False
                    .Columns("PO_NO").Visible = False
                End With
                DataCallHeaderList.ReadOnly = True
                DataCallHeaderList.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox("Error in dgv_fill_header_list." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'Call dgv_fill_from_dataset(DataCallHeaderList, DT_tables)
    'If Not dgv_fill_from_dataset(DataCallHeaderList, DT_tables) Then 'dgv_fill_from_dataset in module
    '        Return
    '    End If
    'End Sub

    Private Sub bt_CreateComplaintHeader_Click(sender As Object, e As EventArgs) Handles bt_CreateComplaintHeader.Click
        If mc_COMPLAINT_CALL_USER Is Nothing Then
            MsgBox("user is null")
            Return
        End If
        If mc_COMPLAINT_CALL_USER.COMPLAINT_CALL_USER_ID = 99999 Then
            mc_COMPLAINT_CALL_USER.New_from_CUS(mc_COMPLAINT_CALL_USER)
        End If
        'MsgBox(mc_COMPLAINT_CALL_USER.COMPLAINT_CALL_USER_ID)
        Using frm_createHeader = New FrmCallheadermaintenance(mc_COMPLAINT_CALL_USER)
            frm_createHeader.ShowDialog()
        End Using
    End Sub

    Private Function Get_user_name_by_id(ByVal strUserId As Integer) As String
        Get_user_name_by_id = ""
        Dim oCOmplatinCallUser As cComplaintCallUser = New cComplaintCallUser(strUserId)
        Get_user_name_by_id = oCOmplatinCallUser.FIRST_NAME + ",  " + oCOmplatinCallUser.LAST_NAME
        Get_user_name_by_id = oCOmplatinCallUser.get_user_name()
        Return Get_user_name_by_id
    End Function

    Private Sub DataCallHeaderList_DoubleClick(sender As Object, e As EventArgs) Handles DataCallHeaderList.DoubleClick

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'get user and header object
        If mc_COMPLAINT_CALL_USER Is Nothing Then
            MsgBox("user is null")
            Return
        End If

        If Not (IsNothing(DataCallHeaderList.CurrentRow.Cells("COMPLAINT_CALL_HEADER_ID"))) Then
            Dim ocComplaintCallHeader As cComplaintCallHeader = New cComplaintCallHeader(CType(DataCallHeaderList.CurrentRow.Cells("COMPLAINT_CALL_HEADER_ID").Value, Integer))
            DataCallHeaderList.CurrentRow.Selected = True
            Using FrmCallheadermaintenance = New FrmCallheadermaintenance(mc_COMPLAINT_CALL_USER, ocComplaintCallHeader)
                FrmCallheadermaintenance.ShowDialog()
            End Using
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub dgv_fill_user_list(ByVal dt As DataTable)
        Try
            'Dim comboboxColumn As DataGridViewComboBoxColumn
            DGV_USER_LIST.Columns.Clear()
            If dt.Rows.Count <> 0 Then
                With DGV_USER_LIST.Columns
                    .Add(DGVTextBoxColumn("COMPLAINT_CALL_USER_ID", "COMPLAINT_CALL_USER_ID", 100))
                    .Add(DGVTextBoxColumn("FIRST_NAME", "FIRST_NAME", 100))
                    .Add(DGVTextBoxColumn("LAST_NAME", "LAST_NAME", 100))
                    .Add(DGVTextBoxColumn("LANGUAGE_ID", "LANGUAGE_ID", 100))
                    '
                    'comboboxColumn = New DataGridViewComboBoxColumn()
                    'comboboxColumn.DataPropertyName = "LANGUAGE_ID"
                    'comboboxColumn.HeaderText = "LANGUAGE_ID"
                    'comboboxColumn.Name = "LANGUAGE_ID"
                    'With comboboxColumn
                    '    .ValueMember = "LANGUAGE_ID"
                    '    .DisplayMember = "LANGUAGE_CODE"
                    '    .DataSource = Get_MDB_CFG_LANGUAGE_List()
                    'End With
                    '.Add(comboboxColumn)
                    '
                    .Add(DGVTextBoxColumn("USER_CONTACT_PHONE_NUMBER", "USER_CONTACT_PHONE_NUMBER", 100))
                    .Add(DGVTextBoxColumn("USER_ADDRESS", "USER_ADDRESS", 100))
                    .Add(DGVTextBoxColumn("USER_POST_CODE", "USER_POST_CODE", 100))
                    .Add(DGVTextBoxColumn("USER_CITY", "USER_CITY", 100))
                    .Add(DGVTextBoxColumn("USER_EMAIL", "USER_EMAIL", 100))
                    .Add(DGVTextBoxColumn("CREATE_BY", "CREATE_BY", 100))
                    .Add(DGVTextBoxColumn("CREATE_DATE", "CREATE_DATE", 100))
                    .Add(DGVTextBoxColumn("BELONG_CSR", "BELONG_CSR", 100))
                    .Add(DGVTextBoxColumn("STATUS", "STATUS", 100))
                    .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 100))
                    .Add(DGVTextBoxColumn("LANGUAGE_CODE", "LANGUAGE_CODE", 100))

                End With

                With DGV_USER_LIST
                    .Columns("COMPLAINT_CALL_USER_ID").Visible = False
                    .Columns("LANGUAGE_ID").Visible = False
                    .Columns("STATUS").Visible = False
                    .Columns("CUS_NO").DisplayIndex = 0
                    .Columns("LANGUAGE_CODE").DisplayIndex = 3
                End With
                DGV_USER_LIST.ReadOnly = True

                DGV_USER_LIST.DataSource = dt
                If DGV_USER_LIST.RowCount >= 0 Then
                    DGV_USER_LIST.Rows(0).Selected = True
                    mc_COMPLAINT_CALL_USER = New cComplaintCallUser(CType(DGV_USER_LIST.Rows(0).Cells("COMPLAINT_CALL_USER_ID").Value, Integer))
                End If
            End If
        Catch ex As Exception
            MsgBox("Error in dgv_fill_user_list." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Function Get_MDB_CFG_LANGUAGE_List() As DataTable 'Get_MDB_CFG_COMPLAINT_CALL_TYPE_List

        Get_MDB_CFG_LANGUAGE_List = New DataTable

        Try

            Dim strSQL As String =
            "SELECT		ISNULL(E.LANGUAGE_ID, 0) As LANGUAGE_ID, rtrim(isnull(E.LANGUAGE_CODE, '')) AS LANGUAGE_CODE " &
            "FROM       MDB_CFG_LANGUAGE E WITH (Nolock) " &
            "ORDER BY   LANGUAGE_CODE "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            Get_MDB_CFG_LANGUAGE_List = dt

        Catch er As Exception
            MsgBox("Error in Get_MDB_CFG_LANGUAGE_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function Get_MDB_CFG_COMPLAINT_CALL_TYPE_List() As DataTable

        Get_MDB_CFG_COMPLAINT_CALL_TYPE_List = New DataTable

        Try

            Dim strSQL As String =
            "SELECT [COMPLAINT_CALL_TYPE_ID] ,[COMPLAINT_CALL_TYPE_NAME] " _
            & " FROM [dbo].[COMPLAINT_CALL_TYPE] E WITH (Nolock) " _
            & "ORDER BY   COMPLAINT_CALL_TYPE_ID "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            Get_MDB_CFG_COMPLAINT_CALL_TYPE_List = dt

        Catch er As Exception
            MsgBox("Error in Get_MDB_CFG_LANGUAGE_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub DGV_USER_LIST_DataSourceChanged(sender As Object, e As EventArgs) Handles DGV_USER_LIST.DataSourceChanged
        If DGV_USER_LIST.RowCount >= 0 Then
            DGV_USER_LIST.Rows(0).Selected = True
            mc_COMPLAINT_CALL_USER = New cComplaintCallUser(CType(DGV_USER_LIST.Rows(0).Cells("COMPLAINT_CALL_USER_ID").Value, Integer))
        End If
        strSql = " SELECT [COMPLAINT_CALL_HEADER_ID] " _
      & " ,[COMPLAINT_CALL_USER_ID] " _
      & " ,[COMPLAINT_CALL_TYPE_ID] " _
      & " ,( select top 1 a1.COMPLAINT_CALL_TYPE_NAME from COMPLAINT_CALL_TYPE a1 where a1.COMPLAINT_CALL_TYPE_ID = t1.COMPLAINT_CALL_TYPE_ID ) as [COMPLAINT_CALL_TYPE_NAME] " _
      & " ,[COMPLAINT_CALL_LEVEL_ID] " _
      & " ,( select top 1 a2.COMPLAINT_CALL_LEVEL_NAME from COMPLAINT_CALL_LEVEL a2 where a2.COMPLAINT_CALL_LEVEL_ID = t1.COMPLAINT_CALL_LEVEL_ID ) as [COMPLAINT_CALL_LEVEL_NAME] " _
      & " ,[COMPLAINT_CALL_STATUS_ID] " _
      & " ,( select top 1 a3.COMPLAINT_CALL_STATUS_NAME from COMPLAINT_CALL_STATUS a3 where a3.COMPLAINT_CALL_STATUS_ID = t1.COMPLAINT_CALL_STATUS_ID ) as [COMPLAINT_CALL_STATUS_NAME] " _
      & " ,[CALL_DATE] , [PO_NO]" _
      & " FROM [dbo].[COMPLAINT_CALL_HEADER] t1 " _
      & " WHERE COMPLAINT_CALL_USER_ID = " & mc_COMPLAINT_CALL_USER.COMPLAINT_CALL_USER_ID.ToString _
      & " ORDER BY [COMPLAINT_CALL_HEADER_ID] "
        DT_tables = db.DataTable(strSql)
        Rtb_user_name.Text = mc_COMPLAINT_CALL_USER.get_user_name()

        Call dgv_fill_header_list(DT_tables)
    End Sub



    Private Sub DGV_USER_LIST_DoubleClick(sender As Object, e As EventArgs) Handles DGV_USER_LIST.DoubleClick
        Try
            If DGV_USER_LIST.RowCount > 0 Then
                If Not (IsNothing(DGV_USER_LIST.CurrentRow.Cells("COMPLAINT_CALL_USER_ID"))) Then
                    If DGV_USER_LIST.CurrentRow.Cells("COMPLAINT_CALL_USER_ID").Value.ToString <> "99999" Then
                        Dim lo_cComplaintCallUser As cComplaintCallUser
                        lo_cComplaintCallUser = New cComplaintCallUser(DGV_USER_LIST.CurrentRow.Cells("COMPLAINT_CALL_USER_ID").Value.ToString)
                        Using frm_createUser = New frmUserMaintenance(lo_cComplaintCallUser)
                            frm_createUser.ShowDialog()
                            Dim from_str As String
                            from_str = "( " _
                                    & " Select [COMPLAINT_CALL_USER_ID], " _
                                    & "                 [FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]   " _
                                    & "                 ,[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,CUS_NO as [CUS_NO] " _
                                    & "                 FROM [dbo].[COMPLAINT_CALL_USER]  )  t1"
                            strSql = " Select [COMPLAINT_CALL_USER_ID], " _
                                    & "[FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]  " _
                                    & ",[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,[CUS_NO]" _
                                     & ",(select top 1 LANGUAGE_CODE from MDB_CFG_LANGUAGE l where l.LANGUAGE_ID = t1. LANGUAGE_ID ) as [LANGUAGE_CODE] " _
                                    & "FROM " & from_str & " " _
                                    & " WHERE COMPLAINT_CALL_USER_ID = " & lo_cComplaintCallUser.COMPLAINT_CALL_USER_ID.ToString _
                                    & " ORDER BY [COMPLAINT_CALL_USER_ID] "
                            DT_tables = db.DataTable(strSql)
                            Call dgv_fill_user_list(DT_tables)
                        End Using
                    Else
                        Dim lo_cComplaintCallUser As cComplaintCallUser
                        lo_cComplaintCallUser = New cComplaintCallUser()
                        If Not (DGV_USER_LIST.CurrentRow.Cells("FIRST_NAME").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.FIRST_NAME = CType(DGV_USER_LIST.CurrentRow.Cells("FIRST_NAME").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("LAST_NAME").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.LAST_NAME = CType(DGV_USER_LIST.CurrentRow.Cells("LAST_NAME").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("LANGUAGE_ID").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.LANGUAGE_ID = CType(DGV_USER_LIST.CurrentRow.Cells("LANGUAGE_ID").Value, Integer)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("USER_CONTACT_PHONE_NUMBER").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.USER_CONTACT_PHONE_NUMBER = CType(DGV_USER_LIST.CurrentRow.Cells("USER_CONTACT_PHONE_NUMBER").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("USER_ADDRESS").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.USER_ADDRESS = CType(DGV_USER_LIST.CurrentRow.Cells("USER_ADDRESS").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("USER_POST_CODE").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.USER_POST_CODE = CType(DGV_USER_LIST.CurrentRow.Cells("USER_POST_CODE").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("USER_CITY").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.USER_CITY = CType(DGV_USER_LIST.CurrentRow.Cells("USER_CITY").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("USER_EMAIL").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.USER_EMAIL = CType(DGV_USER_LIST.CurrentRow.Cells("USER_EMAIL").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("CREATE_BY").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.CREATE_BY = CType(DGV_USER_LIST.CurrentRow.Cells("CREATE_BY").Value, String)
                        lo_cComplaintCallUser.CREATE_DATE = Date.Now
                        If Not (DGV_USER_LIST.CurrentRow.Cells("BELONG_CSR").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.BELONG_CSR = CType(DGV_USER_LIST.CurrentRow.Cells("BELONG_CSR").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("STATUS").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.STATUS = CType(DGV_USER_LIST.CurrentRow.Cells("STATUS").Value, String)
                        If Not (DGV_USER_LIST.CurrentRow.Cells("CUS_NO").Value.Equals(DBNull.Value)) Then lo_cComplaintCallUser.CUS_NO = CType(DGV_USER_LIST.CurrentRow.Cells("CUS_NO").Value, String)
                        Using frm_createUser = New frmUserMaintenance(lo_cComplaintCallUser)
                            frm_createUser.ShowDialog()
                            ''
                            Dim from_str As String
                            from_str = "( " _
                                    & " Select [COMPLAINT_CALL_USER_ID], " _
                                    & "                 [FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]   " _
                                    & "                 ,[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,CUS_NO as [CUS_NO] " _
                                    & "                 FROM [dbo].[COMPLAINT_CALL_USER]  )  t1"
                            strSql = " Select [COMPLAINT_CALL_USER_ID], " _
                                    & "[FIRST_NAME],[LAST_NAME],[LANGUAGE_ID],[USER_CONTACT_PHONE_NUMBER],[USER_ADDRESS],[USER_POST_CODE]  " _
                                    & ",[USER_CITY],[USER_EMAIL],[CREATE_BY],[CREATE_DATE],[BELONG_CSR],[STATUS] ,[CUS_NO]" _
                                    & "FROM " & from_str & " " _
                                    & " WHERE COMPLAINT_CALL_USER_ID = " & lo_cComplaintCallUser.COMPLAINT_CALL_USER_ID.ToString _
                                    & " ORDER BY [COMPLAINT_CALL_USER_ID] "
                            DT_tables = db.DataTable(strSql)
                            Call dgv_fill_user_list(DT_tables)
                            ''
                        End Using
                    End If

                End If

            End If


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub mtb_ord_no_GotFocus(sender As Object, e As EventArgs) Handles mtb_ord_no.GotFocus


    '    'mtb_ord_no.Focus()
    'End Sub

    Private Sub mtb_ord_no_Click(sender As Object, e As EventArgs) Handles mtb_ord_no.Click
        mtb_ord_no.SelectionStart = 0
        mtb_ord_no.SelectionLength = Len(mtb_ord_no.Text)
    End Sub
End Class