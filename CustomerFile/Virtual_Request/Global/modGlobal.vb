Module modGlobal
    Dim db As cDBA
    Public blIsBreach69 As Boolean = False 'this variable is for identify if user is loged with true pass
    Public uRight As Boolean = False
    Public LoadWidow As Int32 = 0


    'Public variable for Request
    Public oRequests As cRequests
    Public oReqRevision As cReqRevision
    Public oReqStatus As cReqStatus
    Public oExact_Traveler_Permission As cExact_Traveler_Permission
    Public oRequestStatusT As cReqCFGStatus

    Public oReq_Cust_Det As cReq_Customer_Detail

    Public frmShow As frmShowRequests 'was added in global for manage easy

    Public oReqItems As cReqItems

    Public oReqCommunic As cReqCommunication


    Public olstRequests As List(Of cRequests)
    Public olstReqRevision As List(Of cReqRevision)
    Public olstReqStatus As List(Of cReqStatus)
    Public olstExact_Traveler_Permission As List(Of cExact_Traveler_Permission)
    Public olstRequestStatusT As List(Of cReqCFGStatus)

    Public olstReq_Cust_Det As List(Of cReq_Customer_Detail)

    Public olstReqItems As List(Of cReqItems)
    Public olstReqItems_old As List(Of cReqItems) 'when storyboard is loaded we keep this variable until close application
    'when user want exit we will comparate old variablke with new

    Public olstReqItems_AdditDetail_Old As List(Of cReqItems_AdditLocation)

    Public olstReqCommunic As List(Of cReqCommunication)
    '----------------------------------------------------


    Public Function DateNow() As Date

        DateNow = Date.Now

    End Function

    'Public Function NoDate() As Date

    '    NoDate = New Date

    'End Function
#Region "    DGV Columns functions ############################### "
    '    Public Function DGVTextBoxColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewTextBoxColumn

    '        DGVTextBoxColumn = New DataGridViewTextBoxColumn

    '        DGVTextBoxColumn.HeaderText = pstrHeaderText
    '        DGVTextBoxColumn.DataPropertyName = pstrName
    '        DGVTextBoxColumn.Name = pstrName

    '        If plWidth <> 0 Then DGVTextBoxColumn.Width = plWidth

    '    End Function
    '    Public Function DGVCheckBoxColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewCheckBoxColumn

    '        DGVCheckBoxColumn = New DataGridViewCheckBoxColumn

    '        DGVCheckBoxColumn.HeaderText = pstrHeaderText
    '        DGVCheckBoxColumn.DataPropertyName = pstrName
    '        DGVCheckBoxColumn.Name = pstrName

    '        DGVCheckBoxColumn.FalseValue = 0 '"False"
    '        DGVCheckBoxColumn.TrueValue = 1 '"True"
    '        DGVCheckBoxColumn.IndeterminateValue = 0 '"False"

    '        If plWidth <> 0 Then DGVCheckBoxColumn.Width = plWidth

    '    End Function
    '    Public Function DGVButtonColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewButtonColumn

    '        '     Dim DGVButtonCell As New DataGridViewButtonCell

    '        DGVButtonColumn = New DataGridViewButtonColumn

    '        DGVButtonColumn.HeaderText = pstrHeaderText
    '        DGVButtonColumn.DataPropertyName = pstrName
    '        DGVButtonColumn.Name = pstrName
    '        DGVButtonColumn.Text = pstrHeaderText
    '        DGVButtonColumn.UseColumnTextForButtonValue = True
    '        ' DGVButtonColumn.DefaultCellStyle.ForeColor = Color.Transparent

    '        If plWidth <> 0 Then DGVButtonColumn.Width = plWidth

    '    End Function
    '    Public Function DGVImageColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, ByVal plWidth As Long) As DataGridViewImageColumn

    '        DGVImageColumn = New DataGridViewImageColumn
    '        DGVImageColumn.Name = pstrName
    '        DGVImageColumn.DataPropertyName = pstrName
    '        DGVImageColumn.HeaderText = pstrHeaderText

    '        If plWidth <> 0 Then DGVImageColumn.Width = plWidth
    '    End Function
#End Region


#Region "-------------------------------------------"

#End Region
#Region "############## Publlic Enum ################"
    'need use while fill dgvStoryBoad for by pas datagridview celvalue changed

    Public start_fill As Boolean = False


    Public Const Customer_Show As String = "Customer"
    Public Const Contact_Show As String = "Contact"
    Public Const Traveler_Users_Show As String = "Traveler Users"

    Public Enum ListViewName
        Customer = 0
        Contact = 1
        Traveler_Users = 2
        Additional_Location = 3
        BindeImage = 4
    End Enum

    Public Enum Traveler_Users
        ID
        User_Name
        Fullname
        Email
        Perm_group_id
        Password
        Employee_id
        Payroll_dept_code
        MdbPermission
        Group_name
    End Enum

    Public Enum Request_View
        RevItemCd = 0 'review item cd
        Rush_Order = 1
        Created = 2
        Creator = 3
        Description = 4
        Status = 5
        Person = 6
        Account = 7
        Items_CD = 8
        Imprint_Logos = 9
        RequestId = 10
        ReviewId = 11
        ReviewNo = 12
    End Enum
    Public Enum Documentlinklabel
        ID
        DocTxtShow
        DocPath
        DocName
        DocExtention
        DocGuid
    End Enum
    Public Enum cust_show
        Customer = 0
        Contact = 1
    End Enum
    'before it was like that 02.09.2018---
    'Public Enum RequestStatus
    '    Open = 0
    '    Approved = 1
    '    Rejected = 2
    '    Processed = 3
    '    Realized = 4
    '    Draft = 5
    '    Reopen = 6
    'End Enum

    'after 02.09.2018--------------------

    'also exist SQL Scalar Function for identify status dbo.[GiveRequestStatusDesc](@id)
    Public Enum ReqCFGStatus
        Pending = 1
        InWork = 2
        ' Rejected = 2
        Completed = 3
        Processed = 4
        ' Draft = 5
        Reopen = 5
    End Enum

    Public Enum Request

        x = 0 ' delete & in cell x.tag = hidden ReqItemId 
        item_master_id = 1
        item_cd = 2
        prod_category = 3
        Is_kit = 4
        item_color = 5
        item_no = 6
        Maco_desc1 = 7
        DEC_MET_DESC = 8
        IMP_DESCRIPTION = 9
        Area_Size = 10
        DEFAULT_LOC = 11

        IMPRINT_COLOR = 12
        IMPRINT_LOGO = 13

        Patch_Shape = 14

        Patch_Color = 15

        Thread_Color = 16
        BackGround_Color = 17
        StampingPattern = 18

        'IMPRINT_COLOR = 17
        'IMPRINT_LOGO = 18
        GUID = 19
        Parent_GUID = 20
        ReqItemId = 21
        ReqItemComm = 22

    End Enum

    Public Enum ReqItem_AdditLoc
        Additional_id = 0
        ReqItemId = 1
        ReqItemGuid = 2

        Dec_met_id = 3
        Imp_desc_id = 4

        ' Area_Size = 5
        Imprint_Color = 5
        Imprint_Logo = 6

        Patch_Shape = 7
        Patch_Color = 8

        Thread_Color = 9
        BackGround_Color = 10
        StampingPattern = 11

        Guid = 12
        ReqItemComm = 13
    End Enum

    Public Enum Mdb_Variant_Enum
        ITEM_VARIANT_ID = 0
        ITEM_MASTER_ID = 1
        COLOR_ID = 2
        COLOR_CD = 3
        COLOR_NAME = 4
        COLOR_NAME_FR = 5
        ITEM_NO = 6
        STATUS = 7
        WQL_STATUS = 8
        WQL_DISCO = 9
    End Enum
    Public Enum Cicmpy_Enum
        ID = 0
        Cmp_wwn = 1
        Cmp_code = 2
        Cnt_id = 3
        Cmp_Parent = 4
        Cmp_name = 5
        Cmp_fadd1 = 6
        Cmp_fadd2 = 7
        Cmp_fadd3 = 8
        Cmp_fpc = 9
        Cmp_fcity = 10
        cmp_fcounty = 11
        StateCode = 12
        Cmp_fctry = 13
        Cmp_e_mail = 14
        Cmp_web = 15
        Cmp_fax = 16
        Cmp_tel = 17
        Cmp_note = 18
        Cmp_acc_man = 19
        Cmp_type = 20
        Cmp_status = 21
        DivisionDebtorID = 22
        DivisionCreditorID = 23
        Textfield1 = 24
        TextField11 = 25
        DefaultInvoiceForm = 26
        SalesPersonNumber = 27
    End Enum
    Public Enum Cicntp_Enum
        ID = 0
        cnt_id = 1
        cmp_wwn = 2
        cnt_f_name = 3
        cnt_l_name = 4
        cnt_m_name = 5
        FullName = 6
        Gender = 7
        cnt_job_desc = 8
        cnt_dept = 9
        taalcode = 10
        cnt_f_ext = 11
        cnt_f_fax = 12
        cnt_f_tel = 13
        cnt_f_mobile = 14
        cnt_email = 15
        cnt_acc_man = 16
        active = 17
        active_y = 18
    End Enum
    Public Enum CFG_COLOR
        Color_ID
        Color_CD
        Color_Name
        Color_Name_FR
        User_Login
        Create_TS
        Update_TS
    End Enum

    Public Enum CFG_ENUM
        ID
        ENUM_CAT
        ENUM_SUB_CAT
        ENUM_VALUE
        ENUM_ORDER
        USER_ID
        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum

    Public Enum CFG_IMP_LOC
        IMP_LOC_ID
        IMP_LOC_CD
        DESCRIPTION
        DESCRIPTION_FR
        CLASS_ID
        PROD_TYPE
        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum

    Public Enum CFG_ITEM_CATEGORY
        ITEM_CATEGORY_ID
        NAME_EN
        NAME_FR
        BANNER_TEXT_1_EN
        BANNER_TEXT_1_FR
        BANNER_TEXT_2_EN
        BANNER_TEXT_2_FR
        IS_DECO
        HEADER_IMAGE
        HEADER_LINK
        DISABLED

        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum
    Public Enum CFG_ITEM_COLLECTION
        CFG_ITEM_COLLECTION_ID
        COLLECTION_CD
        NAME_EN
        NAME_FR
        BANNER_TEXT_1_EN
        BANNER_TEXT_1_FR
        BANNER_TEXT_2_EN
        BANNER_TEXT_2_FR
        IS_DECO
        HEADER_IMAGE
        HEADER_LINK
        DISABLED

        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum
    Public Enum CFG_ITEM_DOC_TYPE
        ITEM_DOC_TYPE_ID
        DOC_TYPE
        ACTIVE
        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum
    Public Enum CFG_PACK
        PACK_ID
        PACK_CD
        DESCRIPTION
        DESCRIPTION_FR
        CAPACITY
        ITEM_CONTENT
        IS_INBOUND
        IS_OUTBOUND
        SIZE_X
        SIZE_Y
        SIZE_Z
        SIZE_UOM
        WEIGHT
        WEIGHT_UOM

        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum
    Public Enum CFG_REFILLS
        REFILL_ID
        REFILL_CODE
        REFILL_DESC
        REFILL_DESC_FR
        IS_STD 'boolean
        IS_OPTIONAL ''boolean

        USER_LOGIN
        CREATE_DT
        UPDATE_DT
    End Enum
    Public Enum CFG_WEB_ICON
        WEB_ICON_ID
        ICON_NAME
        FILENAME
        FILENAME_US
        DESC_EN
        DESC_FR
        TYPE
        LOCATION  'int
        ACTIVE  'boolean 

        USER_LOGIN
        CREATE_TS
        UPDATE_TS

        ICON_EN
        ICON_FR

        BT_EN 'put binary data from ICON_EN 
        BT_FR 'put binary data from ICON_FR

    End Enum

    Public Enum CFG_FLD_CHANGE_RECIPIENT
        FLD_CHANGE_RECIPIENT_ID
        GROUP_CHANGE_CODE
        ' FLD_CD
        CHECKPOINT_CD_COMPLETED
        ITEM_STATUS
        NTUSERID

        USER_LOGIN
        CREATE_TS
        UPDATE_TS
    End Enum
    Public Enum RECIPIENT_USER
        NTUSERID
        PermissionGroup
        ID
        FLD_CHANGE_RECIPIENT_ID
    End Enum
#End Region
#Region "############## Publlic Populate info for Recipent form ################"
    Public Function Departments() As DataTable
        Departments = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                   " SELECT CAST('' AS VARCHAR(30)) AS group_name,CAST('' AS INT ) AS ID FROM EXACT_TRAVELER_PERMISSION_GROUP " & _
                   " UNION " & _
                   " SELECT group_name,ID  FROM EXACT_TRAVELER_PERMISSION_GROUP WITH (NOLOCK) order by group_name asc "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Departments = dt
            End If
        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function FindDeptName_By_ID(ByVal _id As Int32) As String
        FindDeptName_By_ID = String.Empty
        Try

            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                  " SELECT group_name,ID  FROM EXACT_TRAVELER_PERMISSION_GROUP WITH (NOLOCK)" & _
                  " WHERE ID = " & _id

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                FindDeptName_By_ID = "DEPT:" & dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function GroupChangeCode() As DataTable
        GroupChangeCode = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                " SELECT  CAST('' AS varchar(30)) AS GROUP_CHANGE_NAME ,CAST('' AS VARCHAR(30)) AS GROUP_CHANGE_CODE " & _
                " FROM MDB_CFG_FLD_CHANGE_GROUPS " & _
                " UNION " & _
                " SELECT DISTINCT GROUP_CHANGE_NAME, GROUP_CHANGE_CODE " & _
                " FROM MDB_CFG_FLD_CHANGE_GROUPS " & _
                " ORDER BY GROUP_CHANGE_NAME "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                GroupChangeCode = dt
            End If


        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Users(ByVal _group As Int32) As DataTable
        Users = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                " SELECT CAST('' AS VARCHAR(30)) AS Fullname,CAST('' AS INT) AS ID  FROM user_permissions_info " & _
                " UNION " & _
                " SELECT Fullname,ID  FROM user_permissions_info " & _
                " WHERE perm_group_id = '" & _group & "'  " & _
                " ORDER BY Fullname ASC "

            dt = db.DataTable(strSql)

            '  If dt.Rows.Count <> 0 Then
            Users = dt

            '  End If


        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function FindUserName_By_ID(ByVal _id As Int32) As String
        FindUserName_By_ID = String.Empty
        Try

            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                  " SELECT user_name,ID  FROM user_permissions_info WITH (NOLOCK)" & _
                  " WHERE ID = " & _id

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                FindUserName_By_ID = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Checkpoint() As DataTable
        Checkpoint = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            'other column CP_CODE
            strSql = _
                " SELECT CAST('' AS Varchar(30)) AS CP_NAME,  CAST('' AS VARCHAR(30)) AS CP_CODE  FROM MDB_CFG_PD_CHECKPOINT " & _
                " UNION " & _
                " SELECT CP_NAME, CP_CODE  FROM MDB_CFG_PD_CHECKPOINT WITH (NOLOCK) " & _
                " ORDER BY CP_NAME ASC "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Checkpoint = dt
            End If

        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function ItemStatus() As DataTable
        ItemStatus = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
              " SELECT CAST('' AS Varchar(30)) AS  ITEM_STATUS ,CAST('' AS VARCHAR(30)) AS IMAGIANRYFIELD " & _
              " FROM MDB_CFG_FLD_CHANGE_RECIPIENT " & _
              " UNION " & _
              " SELECT DISTINCT ITEM_STATUS, CAST('' AS VARCHAR(30)) AS IMAGIANRYFIELD  FROM MDB_CFG_FLD_CHANGE_RECIPIENT WITH (NOLOCK) " & _
              " WHERE   ITEM_STATUS  IS NOT NULL AND ITEM_STATUS NOT IN ('') " 

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                ItemStatus = dt
            End If

        Catch ex As Exception
            MsgBox("Error in modGlobal. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
    'function for convert string.empty in DBNull
    Public Function DbNullOrStringValue(ByVal value As String) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
            Exit Function
        ElseIf value Is Nothing Then
            Return DBNull.Value
            Exit Function
        Else
            Return value
            Exit Function
        End If
    End Function
    'function for convert string.empty in DBNull
    Public Function DbNullOrStringValue(ByVal value As Int32) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
            'ElseIf value = 0 Then
            '    Return DBNull.Value
        Else
            Return value
        End If
    End Function
    Public Function DbNullOrStringValue(ByVal value As Decimal) As Object
        If String.IsNullOrEmpty(value) Then
            Return DBNull.Value
        ElseIf value = 0.0 Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function
    Public Function DbNullOrStringValue(ByVal value As Byte()) As Object

        If value Is Nothing Then Return value
        If String.IsNullOrEmpty(value.ToString) Then
            Return DBNull.Value
        Else
            Return value
        End If
    End Function
    Public Function booleanIdentify(ByVal bl As Boolean) As Int16
        booleanIdentify = 0
        Try
            Select Case bl
                Case True
                    booleanIdentify = 1
            End Select
        Catch ex As Exception
            MsgBox("Error in modGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#Region " ----- Verify existing combination in all form except Recipient , it use listBox for choose ----- "


    '----------------------------------------------------------------------------------------
    Public Sub CheckReapetLine_DGV(ByRef dgvT As DataGridView, ByRef dgvBott As DataGridView, ByRef dt As DataTable)
        Try
            Dim strRetrive As String = ""
            Dim cpt As Int32 = 0

            'For i As Int32 = 0 To dgvTop.Rows.Count - 1
            For c As Int32 = 0 To dgvT.Columns.Count - 1


                Select Case dgvT.Columns(c).Visible
                    Case True
                        If dgvT.Columns(c).CellType.Name <> "DataGridViewButtonCell" And dgvT.Columns(c).CellType.Name <> "DataGridViewImageCell" Then

                            If Not dgvT.Rows(0).Cells(c).Value Is Nothing Then
                                If dgvT.Rows(0).Cells(c).Value.ToString <> "" Then

                                    strRetrive &= CreateCriteriaRowFilter(dgvT, c, cpt)

                                End If 'ToString <> ""
                            End If 'Not Is Nothing 
                        Else
                            Debug.Print("Cell  DataGridView Cell type " & dgvT.Columns(c).CellType.Name)
                        End If 'identify cellType for make search in dgv(search by button , imageview we not make)
                End Select
            Next
            '  Next

            dt.DefaultView.RowFilter = strRetrive
            dgvBott.Refresh()
        Catch ex As Exception
            MsgBox("Error in modGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'receive data from string and if is string.empty  add for row filter like in sql is null
    Private Function CreateCriteriaRowFilter(ByVal _str As String) As String
        CreateCriteriaRowFilter = _str
        '------------------------------------------------
        If IsNumeric(_str) And _str.IndexOf(",") = -1 Then

            If _str = "" Then
                CreateCriteriaRowFilter = " IS NULL "
            Else
                CreateCriteriaRowFilter = " = " & CInt(_str)
            End If
        Else
            If _str = "" Then
                CreateCriteriaRowFilter = " IS NULL "
            Else
                CreateCriteriaRowFilter = " Like '" & _str & "%'"
            End If
        End If
        '---------------------------------------------------
    End Function
   
    'manage count of selected item in listboxes
    Private Function ReturnAndIn_RowFilter(ByVal _cpt As Int32) As String
        ReturnAndIn_RowFilter = ""
        If _cpt > 0 Then
            ReturnAndIn_RowFilter = " And "
        Else
            ReturnAndIn_RowFilter = ""
        End If
    End Function

    Private Function CreateCriteriaRowFilter(ByRef dgvT As DataGridView, ByRef c As Int32, ByRef cpt As Int32) As String
        CreateCriteriaRowFilter = ""

        If dgvT.Rows(0).Cells(c).Value.ToString = "" Then
            CreateCriteriaRowFilter = ReturnAndIn_RowFilter(cpt) & dgvT.Columns(c).Name & " IS NULL OR " & dgvT.Columns(c).Name & " = '' "
            Exit Function
        ElseIf TypeOf dgvT.Rows(0).Cells(c).Value Is String Then
            'STRING PROPERTY
            CreateCriteriaRowFilter = ReturnAndIn_RowFilter(cpt) & dgvT.Columns(c).Name & " Like '" & dgvT.Rows(0).Cells(c).Value & "%'"
            cpt += 1
            Exit Function
        ElseIf TypeOf dgvT.Rows(0).Cells(c).Value Is Integer Or TypeOf dgvT.Rows(0).Cells(c).Value Is Decimal Then
            'IF O(ZERO) NOTHING TO DO
            If dgvT.Rows(0).Cells(c).Value <> 0 Then
                'INTEGER
                CreateCriteriaRowFilter = ReturnAndIn_RowFilter(cpt) & dgvT.Columns(c).Name & " = " & dgvT.Rows(0).Cells(c).Value
                cpt += 1
            End If
            'ElseIf TypeOf dgvT.Rows(0).Cells(c).Value Is Decimal Then
            Exit Function
        ElseIf TypeOf dgvT.Rows(0).Cells(c).Value Is Boolean Then
            If dgvT.Rows(0).Cells(c).Value = True Then
                CreateCriteriaRowFilter = ReturnAndIn_RowFilter(cpt) & dgvT.Columns(c).Name & " = 1"
                cpt += 1
            End If
            Exit Function
        End If


        '------------------------------------------------
        'If IsNumeric(_str) And _str.IndexOf(",") = -1 Then

        '    If _str = "" Then
        '        CreateCriteriaRowFilter = " IS NULL "
        '    Else
        '        CreateCriteriaRowFilter = " = " & CInt(_str)
        '    End If
        'Else
        '    If _str = "" Then
        '        CreateCriteriaRowFilter = " IS NULL "
        '    Else
        '        CreateCriteriaRowFilter = " Like '" & _str & "%'"
        '    End If
        'End If
        '---------------------------------------------------
    End Function
    '----------------------------------------------------------------------------------------
#End Region
    Public Function user_right(ByRef txt1 As TextBox, ByRef txt2 As TextBox) As Boolean
        user_right = False
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim db As New cDBA

            strSql =
                " select * from user_permissions_info " &
                " where User_Name = '" & txt1.Text & "' and Password = '" & txt2.Text & "' and PermissionGroup = 'IT' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                user_right = True
            End If

        Catch ex As Exception
            MsgBox("Error in modGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'function for create fake cbo only in load grid empty
    Public Function getEmptyDataSource(ByVal p_strid As String, ByVal p_strtxt As String) As DataTable
        getEmptyDataSource = Nothing
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim db As New cDBA

            strSql = "select 0 As '" & p_strid & "', '' As '" & p_strtxt & "'"

            dt = db.DataTable(strSql)


        Catch ex As Exception
            MsgBox("Error in modGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

End Module
