Public Class frmManageGlobalOptions

    Private key As String
    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer

    Private m_Program_Bus As New cMdb_Cus_Prog_BUS

    Private oOeprcfil As New cMacolaOeprcfil_Sql

    Dim dtAIO_Charges As DataTable

    Private db As New cDBA()

    Private dtProgram_Id As DataTable
    Private dtShip_Via_Cd As DataTable

    Private p_CheckState As Int32 = 0

    Private m_DateButton As Button
    Private m_RadioButton As RadioButton

#Region "PUBLIC CONSTRUCTORS ##################################################"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer

        '  Call Insert()

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pCharge_Usage As cMdb_Cfg_Charge_Usage)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer

    End Sub

#End Region


#Region "PRIVATE EVENTS - FORM ################################################"


    Private Sub frmManageGlobalOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            Call cboCharge_ID_FillCombo()

            Call dgvCharges_Load()
            Call dgvCharges_FillGrid()

            Call FillFields()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub SetPermissions()

        Try
            SetUser_Rights(User_Rights, Me.Tag)

            Select Case User_Rights
                'Case "READWRITE"
                '    dgvDocContacts.ReadOnly = False

                'Case "SUPERUSER"
                '    dgvDocContacts.ReadOnly = False

                Case "READONLY"
                    Dim c As Control
                    For Each c In Me.Controls
                        SetReadOnlyHandlersToControl(c)
                    Next

            End Select

            'SetControl_Rights()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetReadOnlyHandlersToControl(ByRef c As Control)

        Try
            If TypeOf c Is GroupBox Then
                For Each d In c.Controls
                    SetReadOnlyHandlersToControl(d)
                Next
            ElseIf TypeOf c Is TextBox Then
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                c.Enabled = False
                'c.BackColor = Color.White
            ElseIf TypeOf c Is ComboBox Then
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged

                c.Enabled = False
            ElseIf TypeOf c Is CheckBox Then
                '++ID 7.4.15
                '  If c.Name = "chkWhite_Glove" Then c.Enabled = False

                c.Enabled = False
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
            ElseIf TypeOf c Is RadioButton Then
                c.Enabled = False
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
            ElseIf TypeOf c Is Button Then
                '  If c.Name = "cmdWhite_Glove_End_Date" Then c.Enabled = False

                c.Enabled = False
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ReadOnlyFields_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If User_Rights = "READONLY" Then
            lblCus_No.Focus()
        End If

    End Sub



#End Region

#Region "PRIVATE EVENTS - TOOLSTRIP BUTTONS ###################################"


    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click

        Try

            Call Save()
            '  Me.Close()

            Call dgvCharges_Load()

            radNew.Checked = False
            radUpdate.Checked = True

            AddHandler Me.radNew.CheckedChanged, AddressOf Element_RadioButtom
            AddHandler Me.radUpdate.CheckedChanged, AddressOf Element_RadioButtom


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try



    End Sub

    'Private Sub tsDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsDelete.Click

    '    Call Delete()

    'End Sub

#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    Private Sub InsertFromGrid()

        Try
            txtID.Text = dgvOptions.CurrentRow.Cells(OptionAll.ID).Value.ToString
            cboCharge_Id.Text = Trim(dgvOptions.CurrentRow.Cells(OptionAll.DESCRIPTION).Value.ToString)

            txtStart_Dt.Text = dgvOptions.CurrentRow.Cells(OptionAll.start_dt).Value.ToString
            txtEnd_Dt.Text = dgvOptions.CurrentRow.Cells(OptionAll.end_dt).Value.ToString

            txtItem_No.Text = dgvOptions.CurrentRow.Cells(OptionAll.cd_tp_1_item_no).Value.ToString

            Dim p As String = dgvOptions.CurrentRow.Cells(OptionAll.prc_or_disc_1).Value.ToString


            If p.IndexOf(".") = -1 Then
                p = p
            ElseIf (p.Length - p.IndexOf(".")) > 3 Then
                p = p.Substring(0, p.IndexOf(".") + 3)
            Else
                p = p
            End If


            txtPrice.Text = p 'dgvOptions.CurrentRow.Cells(OptionAll.prc_or_disc_1).Value.ToString

            If Trim(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString) <> "" Then

                If Trim(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString) = "1" Then
                    chkNever.CheckState = CheckState.Unchecked
                    chkAlwaysExe.CheckState = CheckState.Checked 'CInt(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString)

                ElseIf Trim(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString) = "2" Then
                    chkAlwaysExe.CheckState = CheckState.Unchecked
                    chkNever.CheckState = CheckState.Checked 'CInt(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString)
                ElseIf Trim(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString) = "0" _
                    Or Trim(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString) = "" Then
                    chkAlwaysExe.CheckState = CheckState.Unchecked
                    chkNever.CheckState = CheckState.Unchecked
                End If
                '    chkAlwaysExe.CheckState = CInt(dgvOptions.CurrentRow.Cells(OptionAll.extra_5).Value.ToString)
            Else
                chkAlwaysExe.CheckState = CheckState.Unchecked
            End If

            txtCreate_TS.Text = dgvOptions.CurrentRow.Cells(OptionAll.extra_8).Value.ToString
            txtUpdate_TS.Text = dgvOptions.CurrentRow.Cells(OptionAll.extra_9).Value.ToString

            ' If Not (pdrRow.Item("Minimum_Qty_9").Equals(DBNull.Value)) Then m_decMinimum_Qty_9 = pdrRow.Item("Minimum_Qty_9")
            If dgvOptions.CurrentRow.Cells(OptionAll.extra_15).Value.Equals(DBNull.Value) Then
                txtUser_Login.Text = user_login()
            Else
                txtUser_Login.Text = user_login(CInt(dgvOptions.CurrentRow.Cells(OptionAll.extra_15).Value))
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()
        Try
            If radNew.Checked = True And cboCharge_Id.Text <> "" Then
                '++ID if is not twice charge 
                If cboCharge_Id_Selected() <> True Then
                    Debug.Print("Save new Line.")
                    oOeprcfil = New cMacolaOeprcfil_Sql()

                    oOeprcfil.Item_No = ChargeItemNo(cboCharge_Id.SelectedValue)

                    If IsDate(txtStart_Dt.Text) Then oOeprcfil.Start_Dt = CDate(txtStart_Dt.Text) Else oOeprcfil.Start_Dt = Now.Date 'Date.Today.ToString

                    If IsDate(txtEnd_Dt.Text) Then oOeprcfil.End_Dt = CDate(txtEnd_Dt.Text) Else oOeprcfil.End_Dt = Now.Date ' Date.Today.ToString

                    oOeprcfil.Cd_Tp = 1
                    oOeprcfil.Cus_No = m_Customer.cmp_code
                    oOeprcfil.Curr_Cd = m_Customer.Currency


                    oOeprcfil.Cd_Prc_Basis = "P"

                    Dim number As Decimal = txtPrice.Text
                    If Decimal.TryParse(txtPrice.Text, number) Then oOeprcfil.Prc_Or_Disc_1 = number

                    oOeprcfil.Extra_5 = p_CheckState.ToString ' CInt(chkAlwaysExe.CheckState).ToString
                    oOeprcfil.Extra_8 = Trim(txtCreate_TS.Text)

                    oOeprcfil.Extra_9 = Trim(txtUpdate_TS.Text)

                    oOeprcfil.Extra_15 = user_login(Environment.UserName)

                    oOeprcfil.Save()

                End If
            ElseIf radUpdate.Checked = True And cboCharge_Id.Text <> "" Then
                Debug.Print("Entre en Save update line")

                oOeprcfil = New cMacolaOeprcfil_Sql(dgvOptions.CurrentRow.Cells(OptionAll.ID).Value)

                '   oOeprcfil.Item_No = ChargeItemNo(cboCharge_Id.SelectedValue)


                If IsDate(txtStart_Dt.Text) Then oOeprcfil.Start_Dt = CDate(txtStart_Dt.Text) Else oOeprcfil.Start_Dt = Now.Date 'Date.Today.ToString


                If IsDate(txtEnd_Dt.Text) Then oOeprcfil.End_Dt = CDate(txtEnd_Dt.Text) Else oOeprcfil.End_Dt = Now.Date 'Date.Today.ToString

                If txtPrice.Text <> "" Then oOeprcfil.Prc_Or_Disc_1 = Convert.ToDecimal(txtPrice.Text)

                oOeprcfil.Extra_5 = p_CheckState.ToString 'CInt(chkAlwaysExe.CheckState).ToString


                'DateTime txtCreate_TS, txtUpdate_TS ---------------------------
                If Trim(txtCreate_TS.Text) = "" Then
                    oOeprcfil.Extra_8 = Now.Date.ToString("yyyy-MM-dd") 'Trim(txtCreate_TS.Text)
                Else
                    'oOeprcfil.Extra_8 = Now.Date.ToString("yyyy-MM-dd")
                End If

                oOeprcfil.Extra_9 = Now.Date.ToString("yyyy-MM-dd") 'Trim(txtUpdate_TS.Text)

                'If Trim(txtUpdate_TS.Text) <> "" Then
                '    oOeprcfil.Extra_9 = Now.Date.ToString("yyyy-MM-dd") 'Trim(txtUpdate_TS.Text)
                'Else
                '    oOeprcfil.Extra_9 = Now.Date.ToString("yyyy-MM-dd")
                'End If
                '-----------------------------------

                oOeprcfil.Extra_15 = user_login(Environment.UserName)

                oOeprcfil.Save()

            Else
                Debug.Print(" Save() is not good because in sub Save -> if radButton is not ok .")
            End If


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub Delete()

        Try
            oOeprcfil = New cMacolaOeprcfil_Sql()

            oOeprcfil.Delete(CInt(dgvOptions.CurrentRow.Cells(OptionAll.ID).Value))

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ClearFields()

        Try


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub FillFields()

        Try

            'oOeprcfil = New cMacolaOeprcfil_Sql(dgvOptions.CurrentRow.Cells(OptionAll.ID).Value)

            'txtCus_No.Text = m_Customer.cmp_code
            'cboCharge_Id.Text = Trim(dgvOptions.CurrentRow.Cells(OptionAll.DESCRIPTION).Value.ToString)

            'txtStart_Dt.Text = dgvOptions.CurrentRow.Cells(OptionAll.start_dt).Value.ToString
            'txtEnd_Dt.Text = dgvOptions.CurrentRow.Cells(OptionAll.end_dt).Value.ToString

            ' dgvOptions.CurrentRow.Selected = False

            If dgvOptions.Rows.Count <> 0 Then
                dgvOptions.CurrentRow.Selected = False
            End If


            txtID.Text = ""
            txtCus_No.Text = m_Customer.cmp_code
            cboCharge_Id.Text = ""
            txtStart_Dt.Text = Now.Date
            txtEnd_Dt.Text = ProgramDate(Date.Today)
            cboCharge_Id.Enabled = True
            txtItem_No.Text = ""
            txtPrice.Text = "0.00"

            txtCreate_TS.Text = Now.Date.ToString("yyyy-MM-dd")
            txtUpdate_TS.Text = Now.Date.ToString("yyyy-MM-dd")


            txtUser_Login.Text = Environment.UserName

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "PRIVATE COMBOBOX ROUTINES ############################################"

    Private Sub cboCharge_ID_FillCombo()

        Dim strSql As String
        Dim dtCharge_ID As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		0 AS CHARGE_ID, '' AS DESCRIPTION " & _
            "UNION " & _
            "SELECT		CHARGE_ID, RTRIM(ISNULL(DESCRIPTION, '')) AS DESCRIPTION " & _
            "FROM		mdb_cfg_charge WITH (Nolock) " & _
            "WHERE      ISNULL(CHARGE_CD, '') <> 'SET_UP' " & _
            "ORDER BY	DESCRIPTION "

            dtCharge_ID = db.DataTable(strSql)
            cboCharge_Id.DataSource = dtCharge_ID

            cboCharge_Id.DisplayMember = "DESCRIPTION"
            cboCharge_Id.ValueMember = "CHARGE_ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Function ChargeItemNo(ByVal cgarge_id As Integer) As String

        ChargeItemNo = ""

        Dim dt As DataTable
        Dim strSql As String


        strSql = _
               " SELECT		CHARGE_ID,SHORT_DESC,ITEM_NO " & _
               " FROM		mdb_cfg_charge WITH (Nolock)  " & _
               " WHERE      ISNULL(CHARGE_CD, '') <> 'SET_UP' and CHARGE_ID = " & cgarge_id & "" & _
               " ORDER BY	DESCRIPTION  "

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("ITEM_NO").ToString <> "" Then
                ChargeItemNo = dt.Rows(0).Item("ITEM_NO").ToString
            End If
        End If

        Return ChargeItemNo
    End Function

#End Region


#Region "ENUMERATORS ##########################################################"


#End Region


#Region "PUBLIC PROPERTIES ####################################################"

    Public Property Customer() As cCustomer
        Get
            Customer = m_Customer
        End Get
        Set(ByVal value As cCustomer)
            m_Customer = value
        End Set
    End Property


#End Region


#Region " Functions ##########################################################"
    Private Function ProgramDate(ByRef time As DateTime) As DateTime

        Dim yearP As Integer
        Dim yearN As Integer

        yearP = time.Year

        ProgramDate = time

        yearN = yearP + 1

        If Date.Today.Month = 1 Then
            ProgramDate = "01/31/" & yearP
        Else
            ProgramDate = "01/31/" & yearN
        End If

    End Function
#End Region

    Private Sub txtStart_Dt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStart_Dt.Click
        Try
            If txtStart_Dt.Text = "" Then txtStart_Dt.Text = Now.Date
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub txtStart_Dt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStart_Dt.GotFocus

        Try
            'If txtStart_Dt.Text = "" Then txtStart_Dt.Text = Now.Date
            'If IsDate(txtStart_Dt.Text) Then
            '    txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddMonths(3))
            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub txtEnd_Dt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEnd_Dt.GotFocus

        Try
            If txtEnd_Dt.Text = "" Then
                If IsDate(txtStart_Dt.Text) Then

                    txtEnd_Dt.Text = ProgramDate(CDate(txtStart_Dt.Text))

                    '  txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddYears(1))
                End If
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#Region "LOAD OPTIONS ##########################################################"

    Private Sub dgvCharges_Load()

        Try
            dgvOptions.Columns.Clear()

            With dgvOptions.Columns
                .Add(DGVTextBoxColumn("CHARGE_ID", "Charge ID", 50))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Description", 85))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 110))
                .Add(DGVTextBoxColumn("CD_TP", "cd_tp", 40))
                .Add(DGVTextBoxColumn("CURR_CD", "Curr cd", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_CUST_NO", "Customer", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_ITEM_NO", "Item no", 90))
                .Add(DGVTextBoxColumn("PRC_OR_DISC_1", "Prix", 60))
                .Add(DGVTextBoxColumn("START_DT", "Start date", 60))
                .Add(DGVTextBoxColumn("END_DT", "End date", 60))
                .Add(DGVTextBoxColumn("extra_5", "Always", 50))
                .Add(DGVTextBoxColumn("extra_8", "Create Date", 60))
                .Add(DGVTextBoxColumn("extra_9", "Update_Date", 60))
                .Add(DGVTextBoxColumn("extra_15", "User Login", 60))
                .Add(DGVTextBoxColumn("ID", "ID", 50))
                'CHARGE_ORDER
            End With

            'sort 


            'With dgvOptions
            '    .ColumnHeadersHeight = 20
            '    .RowHeadersWidth = 20
            '    .Columns(OptionAll.CHARGE_ID).Visible = False
            '    .Columns(OptionAll.DESCRIPTION).Visible = False
            '    .Columns(OptionAll.cd_tp).Visible = False
            '    .Columns(OptionAll.curr_cd).Visible = False
            '    .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
            '    .Columns(OptionAll.cd_tp_1_item_no).Visible = False
            '    .Columns(OptionAll.ID).Visible = False
            'End With
            '----------------------------------------------------------------------------

            Call dgvCharges_ShowColumns()

            Call dgvCharges_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Enum OptionAll
        CHARGE_ID
        DESCRIPTION
        SHORT_DESC
        cd_tp
        curr_cd
        cd_tp_1_cust_no
        cd_tp_1_item_no
        prc_or_disc_1
        start_dt
        end_dt
        extra_5 'always 1(true) - 0(false)
        extra_8 'create date
        extra_9 'update date
        extra_15 'user name
        ID
    End Enum
    '------------------------------------
    Private Sub dgvCharges_ShowColumns()

        Try
            If dgvOptions.Columns.Count = 0 Then Exit Sub

            With dgvOptions
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                .Columns(OptionAll.CHARGE_ID).Visible = False
                .Columns(OptionAll.DESCRIPTION).Visible = False
                .Columns(OptionAll.cd_tp).Visible = False
                .Columns(OptionAll.curr_cd).Visible = False
                .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
                .Columns(OptionAll.cd_tp_1_item_no).Visible = False
                .Columns(OptionAll.extra_5).Visible = False
                .Columns(OptionAll.extra_8).Visible = False 'create date
                .Columns(OptionAll.extra_9).Visible = False 'update date
                .Columns(OptionAll.extra_15).Visible = False
                .Columns(OptionAll.ID).Visible = False
            End With
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCharges_FillGrid()

        Try
            Dim strSql As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            '++ID added 2015.04.20 -------------------------------------------------------------------------
            '"  select m.CHARGE_ID,m.CHARGE_CD,m.DESCRIPTION,m.SHORT_DESC, " & _
            ' " o.cd_tp,o.curr_cd,o.cd_tp_1_cust_no,o.cd_tp_3_cust_type,cd_tp_1_item_no, " & _
            ' " o.start_dt,o.end_dt,o.cd_prc_basis,o.ID  " & _
            ' " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            ' "  where o.cd_tp_1_cust_no = 'c210' and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "



            strSql = _
                "  select m.CHARGE_ID, m.DESCRIPTION, m.SHORT_DESC, o.cd_tp, o.curr_cd, " & _
                "  o.cd_tp_1_cust_no, cd_tp_1_item_no, prc_or_disc_1 , o.start_dt, o.end_dt, " & _
                "  o.extra_5, o.extra_8, o.extra_9, o.extra_15, o.ID " & _
                "  from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
                "  where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' " & _
                " and o.cd_tp_3_cust_type = '' "

            'and o.end_dt  >= GETDATE() 
            'extra_8 = create date
            'extra_9 = update date
            'extra_15 = User Name


            dtAIO_Charges = db.DataTable(strSql)

            dgvOptions.DataSource = dtAIO_Charges
            dgvOptions.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region

#Region "Private DateTimePicker control functions #########################"

    ' Date buttons click - open DateControl for element
    Private Sub Element_DateButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart_Dt.Click, cmdEnd_Dt.Click


        Try
            m_DateButton = New Button
            m_DateButton = DirectCast(sender, Button)

            mcCalendar.Top = m_DateButton.Top - 150
            mcCalendar.Left = m_DateButton.Left
            mcCalendar.Visible = True
            mcCalendar.SetDate(Date.Now)

            Select Case m_DateButton.Name
                Case "cmdStart_Dt"
                    If IsDate(txtStart_Dt.Text) Then mcCalendar.SetDate(txtStart_Dt.Text)

                Case "cmdEnd_Dt"
                    If IsDate(txtEnd_Dt.Text) Then mcCalendar.SetDate(txtEnd_Dt.Text)

            End Select
            mcCalendar.Select()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    ' Returns the search button control associated with a textbox or a combobox
    Private Function GetDateControlByControlName(ByVal txtElement As String) As Button

        GetDateControlByControlName = New Button

        Try
            Select Case txtElement

                Case "txtStart_Dt"
                    GetDateControlByControlName = cmdStart_Dt

                Case "txtEnd_Dt"
                    GetDateControlByControlName = cmdEnd_Dt

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    ' Puts the selected date from the calendar info the linked textbox.
    Private Sub mcCalendar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalendar.DateSelected

        Try

            Select Case m_DateButton.Name
                Case "cmdStart_Dt"
                    txtStart_Dt.Text = mcCalendar.SelectionRange.Start
                    txtStart_Dt.Focus()

                Case "cmdEnd_Dt"
                    txtEnd_Dt.Text = mcCalendar.SelectionRange.Start
                    txtEnd_Dt.Focus()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            mcCalendar.Visible = False
            m_DateButton = Nothing
        End Try

    End Sub

    ' When date time picker gets Escape button, it closes.
    Private Sub mcCalendar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mcCalendar.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then ' e.Control And e.KeyValue = Keys.F Then
                mcCalendar.Visible = False
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
    Private Sub dgvOptions_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOptions.CellClick
        Try
            If dgvOptions.Rows.Count <> 0 Then
                dgvOptions.CurrentRow.Selected = False

                If radNew.Checked <> True Then
                    Call InsertFromGrid()
                    dgvOptions.CurrentRow.Selected = True
                End If
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Element_RadioButtom(ByVal sender As Object, ByVal e As System.EventArgs) Handles radNew.Click, radUpdate.Click, radNew.CheckedChanged, radUpdate.CheckedChanged
        Try
            m_RadioButton = New RadioButton
            m_RadioButton = DirectCast(sender, RadioButton)

            Select Case m_RadioButton.Name
                Case "radNew"
                    If dgvOptions.Rows.Count <> 0 Then
                        dgvOptions.CurrentRow.Selected = False
                    End If
                    tsDelete.Visible = False

                    txtID.Text = ""
                    cboCharge_Id.Text = ""

                    txtStart_Dt.Text = Now.Date
                    txtEnd_Dt.Text = ProgramDate(Date.Today)

                    cboCharge_Id.Enabled = True
                    txtItem_No.Text = ""
                    chkAlwaysExe.CheckState = CheckState.Unchecked
                    txtPrice.Text = "0.00"

                    txtCreate_TS.Text = Now.Date.ToString("yyyy-MM-dd")
                    txtUpdate_TS.Text = Now.Date.ToString("yyyy-MM-dd")


                    txtUser_Login.Text = Environment.UserName

                Case "radUpdate"
                    cboCharge_Id.Enabled = False
                    tsDelete.Visible = True
                    If dgvOptions.Rows.Count <> 0 Then
                        '  dgvOptions.Rows(0).Selected = True
                        dgvOptions.CurrentRow.Selected = True
                        Call InsertFromGrid()
                    End If

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Friend Function user_login()

        user_login = ""

        Return user_login

    End Function

    'retrieve User_Name
    Friend Function user_login(ByRef userId As Integer) As String

        Dim dt As DataTable
        Dim strSql As String

        user_login = ""

        If userId.ToString <> "" Then

            strSql = _
                " select User_Name  from EXACT_TRAVELER_PERMISSION where ID = " & userId & ""

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                user_login = dt.Rows(0).Item("User_Name").ToString
            End If

        End If

        Return user_login

    End Function
    'retrieve ID
    Friend Function user_login(ByVal user_name As String) As Integer

        Dim dt As DataTable
        Dim strSql As String

        user_login = 0

        If user_name <> "" Then

            strSql = _
                       " select ID  from EXACT_TRAVELER_PERMISSION where user_name = '" & user_name & "'"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                user_login = dt.Rows(0).Item("ID")
            End If

        End If

        Return user_login

    End Function
    'verify if is the same item in data base 
    Private Function cboCharge_Id_Selected() As Boolean
        ' Try
        cboCharge_Id_Selected = False

        Dim dt As DataTable
        Dim strSql As String
        '  Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        '++ID added 2015.04.20 -------------------------------------------------------------------------
        '"  select m.CHARGE_ID,m.CHARGE_CD,m.DESCRIPTION,m.SHORT_DESC, " & _
        ' " o.cd_tp,o.curr_cd,o.cd_tp_1_cust_no,o.cd_tp_3_cust_type,cd_tp_1_item_no, " & _
        ' " o.start_dt,o.end_dt,o.cd_prc_basis,o.ID  " & _
        ' " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
        ' "  where o.cd_tp_1_cust_no = 'c210' and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "


        strSql = _
            "  select m.CHARGE_ID,m.DESCRIPTION,m.SHORT_DESC, o.cd_tp,o.curr_cd, " & _
            "o.cd_tp_1_cust_no,cd_tp_1_item_no, prc_or_disc_1 , o.start_dt,o.end_dt, " & _
            " o.extra_8, o.extra_9, o.extra_15 ,o.ID " & _
            " from oeprcfil_sql o inner join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            "  where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' " & _
            " and CHARGE_ID = " & cboCharge_Id.SelectedValue & "" & _
            " and o.cd_tp_3_cust_type = '' "

        'and o.end_dt  >= GETDATE() 
        'extra_8 = create date
        'extra_9 = update date
        'extra_15 = User Name


        dt = db.DataTable(strSql)
        If dt.Rows.Count <> 0 Then
            cboCharge_Id_Selected = True
            MsgBox("This Charge already exist for this Customer")
        End If

        Return cboCharge_Id_Selected

        'Catch er As Exception
        '    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        'End Try

        'Me.Cursor = System.Windows.Forms.Cursors.Arrow



    End Function

    Private Sub cboCharge_Id_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCharge_Id.SelectedValueChanged
        Try

            tsSave.Enabled = False
            If cboCharge_Id.SelectedIndex <> 0 Then

                txtItem_No.Text = ChargeItemNo(CInt(cboCharge_Id.SelectedValue))
                If Trim(txtItem_No.Text) <> "" Then tsSave.Enabled = True
            Else
                txtItem_No.Text = ""
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False And e.KeyChar <> Chr(46) Then
                e.Handled = True
                MsgBox("Please enter valid number.")
            End If


            If e.KeyChar = Chr(46) Then

                If txtPrice.Text.IndexOf(".") > 0 Then
                    e.Handled = True
                    MsgBox("Please enter valid number.")
                End If

            End If

            If txtPrice.Text.Length = 8 And e.KeyChar <> ControlChars.Back And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Delete) Then
                'txtPrice.Text.Remove(7)

                If txtPrice.SelectionLength = 0 Then
                    e.Handled = True
                    MsgBox("Please number it must be 8 digit.")
                ElseIf txtPrice.SelectionLength <> 0 Then
                    'Dim intSub As Decimal

                    'Dim start As String = txtPrice.Text
                    'Dim last As String = txtPrice.Text

                    'start = start.Substring(0, txtPrice.SelectionStart)
                    'last = txtPrice.Text.Substring(txtPrice.SelectionLength + txtPrice.SelectionStart, txtPrice.TextLength - (txtPrice.SelectionLength + txtPrice.SelectionStart))

                    ''intSub = txtPrice.Text.Substring(0, txtPrice.SelectionStart) + e.KeyChar + _
                    ''    txtPrice.Text.Substring(txtPrice.SelectionLength + txtPrice.SelectionStart, _
                    ''    txtPrice.TextLength - (txtPrice.SelectionLength + txtPrice.SelectionStart))

                    'intSub = start & e.KeyChar & last

                    '  txtPrice.Text = ""

                    'txtPrice.Text = intSub.ToString

                    key = e.KeyChar

                End If

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub txtPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrice.LostFocus
    '    Try

    '        If txtPrice.SelectionLength <> 0 And key <> "" Then
    '            Dim intSub As Decimal

    '            Dim start As String = txtPrice.Text
    '            Dim last As String = txtPrice.Text

    '            start = start.Substring(0, txtPrice.SelectionStart)
    '            last = txtPrice.Text.Substring(txtPrice.SelectionLength + txtPrice.SelectionStart, txtPrice.TextLength - (txtPrice.SelectionLength + txtPrice.SelectionStart))

    '            'intSub = txtPrice.Text.Substring(0, txtPrice.SelectionStart) + e.KeyChar + _
    '            '    txtPrice.Text.Substring(txtPrice.SelectionLength + txtPrice.SelectionStart, _
    '            '    txtPrice.TextLength - (txtPrice.SelectionLength + txtPrice.SelectionStart))

    '            intSub = start & key & last

    '            '  txtPrice.Text = ""
    '            '    Call Init()
    '            txtPrice.Text = intSub.ToString

    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Private Sub txtPrice_ModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrice.ModifiedChanged

    'End Sub

    Private Sub txtPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPrice.Validating
        Try



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDelete.Click
        Try
            Call Delete()

            Call dgvCharges_Load()

            radNew.Checked = True
            radUpdate.Checked = False


            radNew.Checked = False
            radUpdate.Checked = True



            AddHandler Me.radNew.CheckedChanged, AddressOf Element_RadioButtom
            AddHandler Me.radUpdate.CheckedChanged, AddressOf Element_RadioButtom

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub mcCalendar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mcCalendar.MouseLeave
        Try

            mcCalendar.Visible = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdateDt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDt.Click
        Try
            txtStart_Dt.Text = Now.Date
            txtEnd_Dt.Text = ProgramDate(Date.Today)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkAlwaysExe_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAlwaysExe.CheckStateChanged
        Try

            Call ChkState()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkNever_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNever.CheckStateChanged
        Try

            Call ChkState()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ChkState()
        Try

            If chkAlwaysExe.CheckState = CheckState.Checked And chkNever.CheckState = CheckState.Checked Then
                MsgBox("They can't be true for both case.")
                chkAlwaysExe.CheckState = CheckState.Unchecked
                chkNever.CheckState = CheckState.Unchecked
            ElseIf chkAlwaysExe.CheckState = CheckState.Checked And chkNever.CheckState = CheckState.Unchecked Then
                p_CheckState = 1  'if is always

                If Trim(txtStart_Dt.Text) = String.Empty Then txtStart_Dt.Text = Now.Date
                If Trim(txtEnd_Dt.Text) = String.Empty Then txtEnd_Dt.Text = ProgramDate(Date.Today)

            ElseIf chkAlwaysExe.CheckState = CheckState.Unchecked And chkNever.CheckState = CheckState.Checked Then
                p_CheckState = 2 'if is never
                If Trim(txtStart_Dt.Text) = String.Empty Then txtStart_Dt.Text = Now.Date
                If Trim(txtEnd_Dt.Text) = String.Empty Then txtEnd_Dt.Text = ProgramDate(Date.Today)
            ElseIf chkAlwaysExe.CheckState = CheckState.Unchecked And chkNever.CheckState = CheckState.Unchecked Then
                p_CheckState = 0  'if is required
                If Trim(txtStart_Dt.Text) = String.Empty Then txtStart_Dt.Text = Now.Date
                If Trim(txtEnd_Dt.Text) = String.Empty Then txtEnd_Dt.Text = ProgramDate(Date.Today)
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class