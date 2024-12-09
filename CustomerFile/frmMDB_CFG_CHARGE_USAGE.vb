Public Class frmMDB_CFG_CHARGE_USAGE

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer
    Private m_Charge_Usage As cMdb_Cfg_Charge_Usage

    Private m_Program As cMdb_Cus_Prog
    Private m_Program_Bus As New cMdb_Cus_Prog_BUS

    Private db As New cDBA()

    Private dtProgram_Id As DataTable
    Private dtShip_Via_Cd As DataTable

    Private m_DateButton As Button

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

        Call Insert()

    End Sub

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pCharge_Usage As cMdb_Cfg_Charge_Usage)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Charge_Usage = pCharge_Usage
        m_Program = m_Program_Bus.Load(m_Charge_Usage.Cus_Prog_ID)

    End Sub

#End Region


#Region "PRIVATE EVENTS - FORM ################################################"

    Private Sub frmPrograms_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If m_Charge_Usage Is Nothing Then
                m_Charge_Usage = New cMdb_Cfg_Charge_Usage()
            End If

            Call cboCus_Alt_Adr_Cd_FillCombo()
            Call cboCharge_ID_FillCombo()
            Call cboProgram_Id_FillCombo()

            Call FillFields()

            'Call SetVisibleFields()

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

            mcCalendar.Top = m_DateButton.Top
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
    Private Sub mcCalendar_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalendar.DateSelected

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

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "PRIVATE EVENTS - TOOLSTRIP BUTTONS ###################################"


    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Try

            Call Save()
            Me.Close()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try



    End Sub

    'Private Sub tsDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsDelete.Click

    '    Call Delete()

    'End Sub

#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    Private Sub Insert()

        Try
            m_Charge_Usage = New cMdb_Cfg_Charge_Usage()
            m_Charge_Usage.Cus_No = m_Customer.cmp_code

            m_Program = New cMdb_Cus_Prog

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()

        Try
            'Dim oBUS As New cMdb_Charge_Usage_BUS()

            If m_Charge_Usage Is Nothing Then
                m_Charge_Usage = New cMdb_Cfg_Charge_Usage()
                m_Program = New cMdb_Cus_Prog()
            End If

            m_Program.Cus_No = txtCus_No.Text
            If IsDate(txtStart_Dt.Text) Then
                m_Program.Start_Dt = txtStart_Dt.Text ' txtShipDate
                m_Program.Revision.Start_Dt = txtStart_Dt.Text ' txtShipDate
            Else
                m_Program.Start_Dt = Nothing ' NoDate()
                m_Program.Revision.Start_Dt = Nothing ' NoDate()
            End If
            If IsDate(txtEnd_Dt.Text) Then
                m_Program.End_Dt = txtEnd_Dt.Text ' txtShipDate
                m_Program.Revision.End_Dt = txtEnd_Dt.Text ' txtShipDate
            Else
                m_Program.End_Dt = txtEnd_Dt.Text ' txtShipDate
                m_Program.Revision.End_Dt = Nothing ' NoDate()
            End If
            m_Program.Prog_Type = 4 ' Generated by customer charges 
            If m_Program.Spector_Cd Is Nothing Then
                m_Program.Spector_Cd = m_Program_Bus.Get_Next_Spector_Cd(m_Program)
            End If

            m_Program.For_All_Accounts = (chkAllGroup.Checked)

            m_Program_Bus.Save(m_Program)

            'Ion -----------------------------------------------------------------------
            Dim dtGroupCust As DataTable = Nothing
            Dim strSqlGrCust As String = ""
            Dim strPlus As String = ""
            Dim text As String = ""
            'Ion ------------------------------------------------------------------------

            'Ion ---------------------------------------------------------------------------

            If m_Program.For_All_Accounts Then
                strPlus = " C.cus_note_3 = (SELECT cus_note_3 FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) " & _
                " or  C.cus_no = '" & m_Customer.cmp_code & "' "
            Else
                strPlus = " C.cus_no = '" & m_Customer.cmp_code & "' "
            End If

            strSqlGrCust =
                " SELECT C.cus_no " & _
                " FROM	ARCUSFIL_SQL C " & _
                " LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " & _
                "  WHERE " & _
                strPlus & _
                " ORDER BY	C.CUS_NO "

            dtGroupCust = db.DataTable(strSqlGrCust)

            For Each drGroupCust As DataRow In dtGroupCust.Rows

                Dim mGroupCustomer As New cCustomer(drGroupCust.Item("cus_no").ToString())
                m_Charge_Usage = New cMdb_Cfg_Charge_Usage(m_Program, mGroupCustomer)

                'text += " dtGroupCust : " & drGroupCust.Item("cus_no").ToString() & vbCrLf

                'Ion-------------------------------------------------------------

                m_Charge_Usage.Charge_Usage_Id = txtCharge_Usage_ID.Text
                If Not (cboCharge_Id.SelectedValue Is Nothing) Then m_Charge_Usage.Charge_Id = cboCharge_Id.SelectedValue
                'If Not (cboCharge_Id.SelectedValue Is Nothing) Then m_Charge_Usage.Charge_Cd = cboCharge_Id.Text

                'Ion ------------------------------------------------------------------------
                '- Before
                '     m_Charge_Usage.Cus_No = txtCus_No.Text

                '- Now this place is for each person of group , result of (for each expresion)
                m_Charge_Usage.Cus_No = drGroupCust.Item("cus_no").ToString()
                'Ion-------------------------------------------------------------

                If Not (cboApply_To_Ship_To.SelectedValue Is Nothing) Then m_Charge_Usage.Apply_To_Ship_To = cboApply_To_Ship_To.SelectedText
                If Not (cboApply_To_Program.SelectedValue Is Nothing) Then m_Charge_Usage.Apply_To_Program = cboApply_To_Program.SelectedText

                m_Charge_Usage.Always_Use = chkAlways_Use.Checked
                m_Charge_Usage.Never_Use = chkNever_Use.Checked
                m_Charge_Usage.When_Qty_Gt = txtWhen_Qty_GT.Text
                m_Charge_Usage.When_Amt_Gt = txtWhen_Amt_GT.Text
                m_Charge_Usage.When_Qty_Lt = txtWhen_Qty_LT.Text
                m_Charge_Usage.When_Amt_Lt = txtWhen_Amt_LT.Text
                m_Charge_Usage.Send_Email = chkSend_Email.Checked
                m_Charge_Usage.Email_To = txtEmail_To.Text
                m_Charge_Usage.No_Charge = chkNo_Charge.Checked

                If IsNumeric(txtUnit_Price.Text) Then
                    m_Charge_Usage.Unit_Price = txtUnit_Price.Text
                Else
                    txtUnit_Price.Text = ""
                    m_Charge_Usage.Unit_Price = 0
                End If

                If IsDate(txtStart_Dt.Text) Then
                    m_Charge_Usage.Charge_From = txtStart_Dt.Text ' txtShipDate
                Else
                    m_Charge_Usage.Charge_From = Nothing ' NoDate()
                End If

                If IsDate(txtEnd_Dt.Text) Then
                    m_Charge_Usage.Charge_To = txtEnd_Dt.Text ' txtShipDate
                Else
                    m_Charge_Usage.Charge_To = Nothing ' NoDate()
                End If

                m_Charge_Usage.When_Req = chkWhen_Req.Checked
                m_Charge_Usage.Blind = chkBlind.Checked
                m_Charge_Usage.Comments = txtComments.Text
                m_Charge_Usage.Autorized_By = txtAutorized_By.Text

                m_Charge_Usage.Cus_Prog_ID = m_Program.Cus_Prog_Id

                m_Charge_Usage.Save()

                ' MB++
                'Dim oUser As cHumres
                'Dim oMessage As New cMail()

                'oUser = New cHumres(Environment.UserName)
                'oMessage.FromAddr = oUser.Mail.Trim

                'oUser = New cHumres("TANIA")
                'oMessage.ToAddr = oUser.Mail.Trim
                'oMessage.BCCAddr = "marcb@spectorandco.com"

                'oMessage.Subject = "Option modification for customer " & m_Charge_Usage.Cus_No
                'oMessage.Message = _
                '"This is an automated message from the Customer File program. <br><br>" & _
                '"Customer     : " & m_Charge_Usage.Cus_No & "<br>" & _
                '"Option       : " & m_Charge_Usage.Charge_Cd & "<br>" & _
                '"Start Date   : " & m_Charge_Usage.Charge_From.ToShortDateString & "<br>" & _
                '"End Date     : " & m_Charge_Usage.Charge_To.ToShortDateString & "<br>" & _
                '"Price        : " & IIf(m_Charge_Usage.No_Charge, "Waived", "") & "<br>" & _
                '"Always use   : " & IIf(m_Charge_Usage.Always_Use, "True", "--") & "<br>" & _
                '"Never use    : " & IIf(m_Charge_Usage.Never_Use, "True", "--") & "<br>" & _
                '"Entered by   : " & m_Charge_Usage.User_Login & "<br>" & _
                '"Blind        : " & IIf(m_Charge_Usage.Blind, "True", "--") & "<br>"

                '  MB++
                '  oMessage.Send()


                m_Charge_Usage.SaveChargeToMacola(m_Program, New cCustomer(m_Program.Cus_No))

                'Dim oItemPrice As New cMacolaOeprcfil_Sql(drItemColor.Item("Item_No").ToString, m_Program)
                'If m_Program.Prog_Type = 2 and not m_program.one_shot Then
                '    oItemPrice.Cd_Tp = 1
                'Else
                '    oItemPrice.Cd_Tp = 9
                'End If

                'oItemPrice.Cus_No = m_Program.Cus_No
                'oItemPrice.Curr_Cd = m_Customer.Currency
                'oItemPrice.Item_No = drItemColor.Item("Item_No").ToString
                'oItemPrice.Start_Dt = m_Program.Start_Dt
                'oItemPrice.End_Dt = m_Program.End_Dt
                'oItemPrice.Cus_Prog_Id = m_Program.Cus_Prog_Id
                'oItemPrice.Cd_Prc_Basis = "P"
                'oItemPrice.Prod_Cat = m_Program.Spector_Cd.Substring(0, 3)
                'oItemPrice.Cd_Tp_3_Cust_Type = m_Program.Cus_Prog_Id.ToString.Trim.PadLeft(10, "0").Substring(5, 5)
                'Debug.Print(oItemPrice.Id)

                'For Each drItemDetail As DataRow In dtItemDetails.Rows

                '    iPos += 1
                '    If iPos > 10 Then iPos = 10

                '    oItemPrice.Set_Minimum_Qty(iPos, drItemDetail.Item("MIN_QTY_ORD"))

                '    If drItemDetail.Item("EQP_LEVEL") = 0 Then

                '        oItemPrice.Set_Prc_Or_Disc(iPos, drItemDetail.Item("UNIT_PRICE"))

                '    Else

                '        Dim dEqpPrice As Decimal
                '        dEqpPrice = oItemPrice.Get_Eqp_Price()
                '        If drItemDetail.Item("EQP_PCT") <> 0 Then
                '            dEqpPrice = (dEqpPrice - (dEqpPrice * drItemDetail.Item("EQP_PCT") / 100))
                '        End If
                '        oItemPrice.Set_Prc_Or_Disc(iPos, dEqpPrice)

                '    End If

                'Next (drItemDetail)
                ''Exact_Custom_OeFlash_CustomerComments()
                'If iPos >= 1 Then
                '    oItemPrice.Save()
                'End If

                'Ion ----------------------------------------------------------------------------
            Next drGroupCust

            Debug.Print(text.ToString) 'customers codes read
            'Ion ----------------------------------------------------------------------------

            txtCharge_Usage_ID.Text = m_Charge_Usage.Charge_Usage_Id
            txtUser_Login.Text = m_Charge_Usage.User_Login
            txtUpdate_TS.Text = m_Charge_Usage.Update_TS

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub Delete()

        Try

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Shadows Sub Load()

    '    Try

    '        'Dim oBUS As New cMdb_Charge_Usage_BUS()
    '        Dim oLoadProgram As New cMdb_Charge_Usage()

    '        oLoadProgram = m_Charge_Usage_BUS.Load(1)

    '        If oLoadProgram.Cus_Prog_Id = 0 Then
    '            MsgBox("Program code does not exist.")
    '        Else
    '            m_Charge_Usage = oLoadProgram

    '            Call ClearFields()
    '            Call FillFields()
    '            Call SetVisibleFields()

    '            txtStart_Dt.Focus()

    '            Select Case m_Charge_Usage_Type

    '                Case "Program"
    '                    Me.Text = "Program Maintenance"

    '                Case "Special Pricing"
    '                    Me.Text = "Special Pricing Maintenance"

    '            End Select

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub ClearFields()

        Try
            txtCharge_Usage_ID.Text = "0"
            cboCharge_Id.SelectedValue = 0
            txtCus_No.Text = String.Empty
            cboApply_To_Ship_To.SelectedValue = 0
            cboApply_To_Program.SelectedValue = 0
            chkAlways_Use.Checked = False
            chkNever_Use.Checked = False
            txtWhen_Qty_GT.Text = String.Empty
            txtWhen_Amt_GT.Text = String.Empty
            txtWhen_Qty_LT.Text = String.Empty
            txtWhen_Amt_LT.Text = String.Empty
            chkSend_Email.Checked = False
            txtEmail_To.Text = String.Empty
            chkNo_Charge.Checked = False
            txtStart_Dt.Text = String.Empty
            txtEnd_Dt.Text = String.Empty
            chkWhen_Req.Checked = False
            chkBlind.Checked = False
            txtComments.Text = String.Empty
            txtAutorized_By.Text = String.Empty
            m_Charge_Usage.User_Login = String.Empty
            m_Charge_Usage.Update_TS = String.Empty

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub FillFields()

        Try
            txtCharge_Usage_ID.Text = m_Charge_Usage.Charge_Usage_Id
            cboCharge_Id.SelectedValue = m_Charge_Usage.Charge_Id
            txtCus_No.Text = m_Charge_Usage.Cus_No
            cboApply_To_Ship_To.SelectedText = m_Charge_Usage.Apply_To_Ship_To
            cboApply_To_Program.SelectedText = m_Charge_Usage.Apply_To_Program
            chkAlways_Use.Checked = m_Charge_Usage.Always_Use
            chkNever_Use.Checked = m_Charge_Usage.Never_Use
            txtWhen_Qty_GT.Text = m_Charge_Usage.When_Qty_Gt
            txtWhen_Amt_GT.Text = m_Charge_Usage.When_Amt_Gt
            txtWhen_Qty_LT.Text = m_Charge_Usage.When_Qty_Lt
            txtWhen_Amt_LT.Text = m_Charge_Usage.When_Amt_Lt
            chkSend_Email.Checked = m_Charge_Usage.Send_Email
            txtEmail_To.Text = m_Charge_Usage.Email_To
            chkNo_Charge.Checked = m_Charge_Usage.No_Charge
            If m_Charge_Usage.Charge_From.Year <> 1 Then txtStart_Dt.Text = m_Charge_Usage.Charge_From
            If m_Charge_Usage.Charge_To.Year <> 1 Then txtEnd_Dt.Text = m_Charge_Usage.Charge_To
            chkWhen_Req.Checked = m_Charge_Usage.When_Req
            chkBlind.Checked = m_Charge_Usage.Blind
            txtComments.Text = m_Charge_Usage.Comments
            txtAutorized_By.Text = m_Charge_Usage.Autorized_By
            txtUser_Login.Text = m_Charge_Usage.User_Login
            If m_Charge_Usage.Update_TS.Year <> 1 Then txtUpdate_TS.Text = m_Charge_Usage.Update_TS

            If Not (m_Program Is Nothing) Then
                chkAllGroup.Checked = m_Program.For_All_Accounts
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "PRIVATE COMBOBOX ROUTINES ############################################"

    Private Sub cboCus_Alt_Adr_Cd_FillCombo()

        Dim strSql As String
        Dim dtCombo As DataTable
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		cus_alt_adr_cd " & _
            "FROM		ARALTADR_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' " & _
            "ORDER BY	cus_alt_adr_cd "

            dtCombo = db.DataTable(strSql)

            cboApply_To_Ship_To.Items.Add("") ' Add an empty string

            If dtCombo.Rows.Count <> 0 Then

                For Each dtRow As DataRow In dtCombo.Rows

                    cboApply_To_Ship_To.Items.Add(dtRow.Item("cus_alt_adr_cd").ToString.Trim)

                Next dtRow

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

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

    Private Sub cboProgram_Id_FillCombo()

        Dim strSql As String
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		0 AS CUS_PROG_ID, '' AS PROG_CD " & _
            "UNION " & _
            "SELECT		CUS_PROG_ID, ISNULL(PROG_CD, '') AS PROG_CD " & _
            "FROM		MDB_CUS_PROG WITH (Nolock) " & _
            "WHERE		CUS_NO = '" & m_Customer.cmp_code & "' AND " & _
            "           ISNULL(PROG_CD, '') <> '' AND " & _
            "           (START_DT <= GETDATE() AND END_DT >= GETDATE()) " & _
            "ORDER BY   PROG_CD "

            dtProgram_Id = db.DataTable(strSql)
            cboApply_To_Program.DataSource = dtProgram_Id

            cboApply_To_Program.DisplayMember = "PROG_CD"
            cboApply_To_Program.ValueMember = "CUS_PROG_ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "ENUMERATORS ##########################################################"


#End Region


#Region "PUBLIC PROPERTIES ####################################################"

    Public Property Customer() As cCustomer
        Get
            Customer = m_Customer
        End Get
        Set(value As cCustomer)
            m_Customer = value
        End Set
    End Property

    Public Property Program() As cMdb_Cfg_Charge_Usage
        Get
            Program = m_Charge_Usage
        End Get
        Set(value As cMdb_Cfg_Charge_Usage)
            m_Charge_Usage = value
        End Set
    End Property

#End Region


    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click

        Me.Close()

    End Sub


#Region "USER PERMISSIONS ##########################################################"

    Private Sub SetPermissions()

        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
        dt = db.DataTable(strSql)
        If dt.Rows.Count <> 0 Then
            User_Rights = dt.Rows(0).Item("Access_Type").ToString
        Else
            strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & Me.Tag & "' AND SCREEN_USER = 'ALL' "
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                User_Rights = dt.Rows(0).Item("Access_Type").ToString
            End If
        End If

        Select Case User_Rights
            Case "READWRITE"
                tsSave.Enabled = True

            Case "SUPERUSER"
                tsSave.Enabled = True

            Case "READONLY"
                tsClose.Visible = True
                Dim c As Control
                For Each c In Me.Controls
                    If TypeOf c Is TextBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        'c.Enabled = False
                        'c.BackColor = Color.White
                    ElseIf TypeOf c Is ComboBox Then
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is CheckBox Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is RadioButton Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        RemoveHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.PreviewKeyDown, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    ElseIf TypeOf c Is Button Then
                        'c.Enabled = False
                        RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                        AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                    End If
                Next

        End Select

    End Sub

    Private Sub ReadOnlyFields_GotFocus(sender As Object, e As System.EventArgs)

        If User_Rights = "READONLY" Then
            txtCus_No.Focus()
        End If

    End Sub

#End Region

    Private Sub txtStart_Dt_GotFocus(sender As Object, e As System.EventArgs) Handles txtStart_Dt.GotFocus

        Try
            If txtStart_Dt.Text = "" Then txtStart_Dt.Text = Now.Date

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub txtEnd_Dt_GotFocus(sender As Object, e As System.EventArgs) Handles txtEnd_Dt.GotFocus

        Try
            If txtEnd_Dt.Text = "" Then
                If IsDate(txtStart_Dt.Text) Then
                    txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddMonths(3))
                End If
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

End Class