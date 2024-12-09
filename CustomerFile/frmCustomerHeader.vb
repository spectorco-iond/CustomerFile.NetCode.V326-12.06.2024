Public Class frmCustomerHeader

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer

    Private m_Mdb_Customer_BUS As New cMdb_Customer_BUS
    Private m_Mdb_Customer As New cMdb_Customer

    Dim db As New cDBA()

    Dim dtAIO_CurrentOrders As DataTable
    Dim dtAIO_SelfPromo As DataTable
    Dim dtAIO_ProgramPricing As DataTable
    Dim dtAIO_Communications As DataTable
    Dim dtAIO_PriceLists As DataTable
    Dim dtAIO_Charges As DataTable
    Dim dtAIO_PushedOrders As DataTable
    Dim dtDocContacts As DataTable

    Dim boolchkWhGl As Boolean = False
    Dim booltxtWhGl As Boolean = False
    Dim strChangeWtGl As String = ""

    Private FormIsClosing As Boolean = False
    Private m_DateButton As Button



#Region "CONSTRUCTORS #########################################################"

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
        m_Mdb_Customer = m_Mdb_Customer_BUS.Load(m_Customer.cmp_code)

    End Sub

#End Region


#Region "PRIVATE FORM EVENTS ###################################################"

    Private Sub frmCustomerHeader_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim oCus As New cMdb_Customer
        Dim oCus_BUS As New cMdb_Customer_BUS
        Dim beforeDate As String
        Try
            FormIsClosing = True
            Debug.Print("frmCustomerHeader_FormClosing")
            dgvDocContacts.EndEdit()

            SetUser_Rights(User_Rights, Me.Tag)

            Select Case User_Rights
                Case "READWRITE", "SUPERUSER"

                    txtCmp_Code.Focus()

                    If boolchkWhGl = True Or booltxtWhGl = True Then


                        Dim result3 As DialogResult = MessageBox.Show("Are you sure you want to change the White Glove for this client?", "White Glove Lost Focus", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)


                        If result3 = Windows.Forms.DialogResult.Yes And chkWhite_Glove.CheckState = CheckState.Checked Then
                            txtWhite_Glove_End_Date.Enabled = (chkWhite_Glove.Checked)
                            txtWhite_Glove_Order_Count.Enabled = (chkWhite_Glove.Checked)
                        ElseIf result3 = Windows.Forms.DialogResult.Yes And chkWhite_Glove.CheckState = CheckState.Unchecked Then
                            txtWhite_Glove_End_Date.Enabled = (chkWhite_Glove.Checked)
                            txtWhite_Glove_Order_Count.Enabled = (chkWhite_Glove.Checked)
                        ElseIf result3 = Windows.Forms.DialogResult.No Then 'And chkWhite_Glove.CheckState = CheckState.Checked Then

                            Exit Sub

                        End If

                        If chkWhite_Glove.Checked <> chkWhite_Glove.Tag Or txtWhite_Glove_Order_Count.Text <> txtWhite_Glove_Order_Count.Tag Or txtWhite_Glove_End_Date.Text <> txtWhite_Glove_End_Date.Tag Then

                            oCus = oCus_BUS.Load(txtCmp_Code.Text.Trim)

                            beforeDate = oCus.White_Glove_End_Date.ToString

                            If chkWhite_Glove.Checked Then
                                If Not IsDate(txtWhite_Glove_End_Date.Text) Then
                                    txtWhite_Glove_End_Date.Text = Date.Now.Date
                                End If
                                oCus.White_Glove_End_Date = CDate(txtWhite_Glove_End_Date.Text)

                                If Not IsNumeric(txtWhite_Glove_Order_Count.Text) Then
                                    txtWhite_Glove_Order_Count.Text = "3"
                                End If
                                oCus.White_Glove_Order_Count = CInt(txtWhite_Glove_Order_Count.Text)
                            Else
                                oCus.White_Glove_End_Date = NoDate()
                                oCus.White_Glove_Order_Count = 0
                            End If

                            oCus_BUS.Save(oCus)
                            SendEmail(Trim(txtCmp_Code.Text), oCus.White_Glove_End_Date.ToString, chkWhite_Glove, beforeDate)
                            '     oCus_BUS.SaveCustomersFromGroup(oCus)

                        Else
                            'MsgBox("The same")
                        End If

                    End If

            End Select
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#Region "-----------Audit for White Glove-----------------"
    Private Sub SendEmail(ByVal strClient As String, ByVal strEndDate As String, ByRef chkBoxStr As CheckBox, ByVal strBeforeDate As String)
        Try

            Dim oMessage As New cMailAdviseWhiteGlove
            Dim strMessage As String

            oMessage.FromAddr = Email(Environment.UserName)
            oMessage.ToAddr = Trim("iond@spectorandco.ca") 'Trim("betty@spectorandco.ca")

            ' oMessage.CCAddr = Trim("stephane@spectorandco.ca")
            '  oMessage.CCAddr = Trim("andrew@spectorandco.ca")

            oMessage.Subject = Trim(" Alert changed White Glove in Customer File for the client " & Trim(strClient))

            strMessage = " - This changed it was made of user : " & Environment.UserName & "<br />"
            strMessage &= " - White Glove CheckBox was changed for " & chkBoxStr.Checked.ToString & "<br />"
            strMessage &= " - End Date before it was the " & strBeforeDate & "<br />"
            strMessage &= " - End Date it was changed for " & strEndDate & "<br />"
            strMessage &= " - Alert sended : " & Date.Now

            oMessage.Message = "<html>" & strMessage & "</html>"

            oMessage.Send()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Email(ByVal user As String) As String

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim strSql As String

        Email = ""

        strSql = _
                "Select * from user_permissions_info " & _
                " where user_name = '" & user & "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            Email = dt.Rows(0).Item("Email").ToString
        End If

        Return Email

    End Function
#End Region

    Private Sub frmCustomerHeader_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus

        Debug.Print("frmCustomerHeader_GotFocus " & Date.Now.ToString)

    End Sub


    Private Sub frmCustomerHeader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Dim _assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

        'Dim fileInfo As New System.IO.FileInfo(_assembly.Location)

        'Dim lastModified = fileInfo.LastWriteTime


        lblVersion.Text = Version()
        ' lblVersion.Text & " " & _assembly.GetName.Version.ToString & " date :  " & lastModified.ToString("dd-MM-yyyy hh:mm tt")

        Try
            If m_Customer Is Nothing Then Exit Sub

            Call SetPermissions()




            With m_Customer

                txtCmp_Code.Text = .cmp_code
                txtCmp_Name.Text = .cmp_name
                txtCmp_FAdd1.Text = .cmp_fadd1
                txtCmp_FAdd2.Text = .cmp_fadd2
                txtCmp_FAdd3.Text = .cmp_fadd3
                txtCmp_FCity.Text = .cmp_fcity
                txtStateCode.Text = .StateCode
                txtCus_Note_3.Text = .textfield3

                txtCmp_FPC.Text = .cmp_fpc
                txtCmp_FCtry.Text = .cmp_fctry
                txtPhoneNumber.Text = .cmp_tel

                txtSalesPersonNumber.Text = .SalesPersonNumber
                txtSalesPersonNumber_Desc.Text = GetElementDescription("ARSLMFIL_SQL", "", .SalesPersonNumber)

                txtRegion.Text = .region
                'txtRegion_Desc.Text = GetElementDescription("Land", "", .cmp_fctry)

                txtcmp_status.Text = .cmp_status
                txtcmp_status_Desc.Text = GetElementDescription("cicmpy", "cmp_status", .cmp_status)

                txtCurrency.Text = .Currency
                'txtCurrency_Desc.Text = GetElementDescription("Land", "", .cmp_fctry)

                txtRep.Text = .cmp_acc_man
                txtRep_Desc.Text = GetElementDescription("HUMRES", "FullName", .cmp_acc_man)
                txtRep_Email.Text = GetElementDescription("HUMRES", "Mail", .cmp_acc_man)
                txtRep_Phone.Text = GetElementDescription("HUMRES", "TelNr_Werk", .cmp_acc_man)

                'Humres.FullName()
                'Humres.Mail()
                'Humres.TelNr_Werk()

                txtShipVia.Text = .ShipVia
                txtShipVia_Desc.Text = GetElementDescription("SYCDEFIL_SQL", "", .ShipVia)

                txtPaymentCondition.Text = .PaymentCondition
                'txtPaymentMethod.Text = .PaymentMethod
                txtPaymentCondition_Desc.Text = GetElementDescription("SYTRMFIL_SQL", "", .PaymentCondition)

                chkTxbl_Fg.Checked = IIf(.IsTaxable = 1, True, False)
                txttax_cd.Text = .TaxCode
                txttax_cd_2.Text = .TaxCode2
                txttax_cd_3.Text = .TaxCode3

                chkAllowBackOrders.Checked = IIf(.AllowBackOrders = 1, True, False)
                chkAllowPartialShipment.Checked = IIf(.AllowPartialShipment = 1, True, False)
                chkAllowSubstituteItem.Checked = IIf(.AllowSubstituteItem = 1, True, False)

                txtClassificationID.Text = .ClassificationId
                txtEQP_Status.Text = .textfield1

                XTxt_SAM_Textfiel4.Text = Get_SAM_Textfiel4(m_Customer.cmp_code)  'justin add on 20221222 for ticket:30550

                If .TextField6 <> String.Empty Then
                    lblVIP.Visible = True
                Else
                    lblVIP.Visible = False
                End If



                'Call dgvCurrentOrders_LoadFields()
                Call dgvSelfPromo_Load()
                'Call dgvProgramPricing_Load()
                Call dgvCommunications_Load()
                'Call dgvPriceLists_Load()
                Call dgvCharges_Load()
                Call dgvDocContacts_Load()
                Call dgvPushedOrders_Load()

            End With

            With m_Mdb_Customer

                'if client have more 1 return, display this count of returns items
                'function is in cMdb_Customer_DAL.CountFunRMA_3Month(ByVal pCus_No As String) As Integer
                If .CountRMA_3Month <> 0 Then
                    lblReturn_3Month.Visible = True
                    lblReturn_3Month.Text = .CountRMA_3Month & " " & lblReturn_3Month.Text
                End If

                If .White_Glove_End_Date >= Date.Now.Date() Or .White_Glove_Order_Count > 0 Then
                    chkWhite_Glove.Checked = True

                    txtWhite_Glove_End_Date.Enabled = True
                    'This variable is populate for use in txtWhite_Glove_End_Date_TextChanged

                    strChangeWtGl = .White_Glove_End_Date.ToString

                    Convert.ToDateTime(strChangeWtGl.ToString())

                    strChangeWtGl = String.Format("{0:MM/dd/yyyy}", CDate(strChangeWtGl.ToString))


                    txtWhite_Glove_End_Date.Text = .White_Glove_End_Date.ToString
                    txtWhite_Glove_End_Date.Tag = .White_Glove_End_Date.ToString

                    txtWhite_Glove_Order_Count.Enabled = True
                    txtWhite_Glove_Order_Count.Text = .White_Glove_Order_Count
                    txtWhite_Glove_Order_Count.Tag = .White_Glove_Order_Count

                End If
                chkWhite_Glove.Tag = chkWhite_Glove.Checked
            End With



        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub frmCustomerHeader_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

        'Call Resize_gbAIO__CurrentOrders_Resize()

    End Sub


#End Region


#Region "Private DateTimePicker control functions #########################"

    ' Date buttons click - open DateControl for element
    Private Sub Element_DateButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWhite_Glove_End_Date.Click

        Try
            m_DateButton = New Button
            m_DateButton = DirectCast(sender, Button)

            mcCalendar.Top = m_DateButton.Top
            mcCalendar.Left = m_DateButton.Left
            mcCalendar.Visible = True
            mcCalendar.SetDate(Date.Now)

            Select Case m_DateButton.Name
                Case "cmdWhite_Glove_End_Date"
                    If IsDate(txtWhite_Glove_End_Date.Text) Then mcCalendar.SetDate(txtWhite_Glove_End_Date.Text)

                    'Case "cmdEnd_Dt"
                    '    If IsDate(txtEnd_Dt.Text) Then mcCalendar.SetDate(txtEnd_Dt.Text)

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

                Case "txtWhite_Glove_End_Date"
                    GetDateControlByControlName = cmdWhite_Glove_End_Date

                    'Case "txtEnd_Dt"
                    '    GetDateControlByControlName = cmdEnd_Dt

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    ' Puts the selected date from the calendar info the linked textbox.
    Private Sub mcCalendar_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalendar.DateSelected

        Try

            Select Case m_DateButton.Name
                Case "cmdWhite_Glove_End_Date"
                    txtWhite_Glove_End_Date.Text = mcCalendar.SelectionRange.Start
                    txtWhite_Glove_End_Date.Focus()

                    'Case "cmdEnd_Dt"
                    '    txtEnd_Dt.Text = mcCalendar.SelectionRange.Start
                    '    txtEnd_Dt.Focus()

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


    '#Region "LOAD CurrentOrders ####################################################"

    '    Private Sub dgvCurrentOrders_LoadFields()

    '        Try

    '            With dgvCurrentOrders.Columns
    '                .Add(DGVTextBoxColumn("Cus_No", "Cus_No", 50))
    '                .Add(DGVTextBoxColumn("Ord_Type", "T", 20))
    '                .Add(DGVTextBoxColumn("RMA_No", "RMA_No", 50))
    '                .Add(DGVTextBoxColumn("Ord_No", "Ord No", 50))
    '                .Add(DGVTextBoxColumn("Ord_Dt", "Ord Dt", 55))
    '                .Add(DGVTextBoxColumn("Inv_No", "Inv No", 50))
    '                .Add(DGVTextBoxColumn("Inv_Dt", "Inv Dt", 55))
    '                .Add(DGVTextBoxColumn("Ct_Ord_No", "Ct_Ord_No", 50))
    '                .Add(DGVTextBoxColumn("Ct_Inv_No", "Ct_Inv_No", 50))
    '                .Add(DGVTextBoxColumn("OE_Po_No", "PO Number", 60))
    '                .Add(DGVTextBoxColumn("Tot_Dollars", "Amount", 50))
    '                .Add(DGVTextBoxColumn("Bill_To_Name", "Bill_To_Name", 50))
    '                .Add(DGVTextBoxColumn("Tot_Sls_Amt", "Tot_Sls_Amt", 50))
    '                .Add(DGVTextBoxColumn("Shipping_Status", "Shipping", 110))
    '                .Add(DGVTextBoxColumn("User_def_Fld_4", "User_def_Fld_4", 50))
    '                .Add(DGVTextBoxColumn("Nb_Travelers", "Nb_Travelers", 50))
    '                .Add(DGVTextBoxColumn("LinesShipped", "LinesShipped", 50))
    '                .Add(DGVTextBoxColumn("NotShipped", "NotShipped", 50))
    '                .Add(DGVTextBoxColumn("PartialShipped", "PartialShipped", 50))
    '                .Add(DGVTextBoxColumn("CompleteShipped", "CompleteShipped", 50))
    '                .Add(DGVTextBoxColumn("ShippedDate", "ShippedDate", 100))
    '                .Add(DGVTextBoxColumn("Line_Count", "Lines", 20))
    '                .Add(DGVTextBoxColumn("Has_Bo", "BO", 25))
    '                .Add(DGVTextBoxColumn("BO_Count", "BO_Count", 20))
    '                .Add(DGVTextBoxColumn("Repeat_From", "Repeat_From", 50))
    '                .Add(DGVTextBoxColumn("Repeat_To", "Repeat_To", 50))
    '                .Add(DGVTextBoxColumn("Extra_1", "Extra_1", 50))
    '                .Add(DGVTextBoxColumn("Extra_2", "Extra_2", 50))
    '            End With

    '            Call dgvCurrentOrders_ShowColumns()

    '            Call dgvCurrentOrders_FillGrid()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvCurrentOrders_ShowColumns()

    '        Try
    '            If dgvCurrentOrders.Columns.Count = 0 Then Exit Sub

    '            With dgvCurrentOrders

    '                .ColumnHeadersHeight = 20
    '                .RowHeadersWidth = 20

    '                .Columns(AIO_CurOrd_Col.Cus_No).Visible = False
    '                '.Columns(AIO_CurOrd_Col.Ord_Type).Visible = False

    '                .Columns(AIO_CurOrd_Col.RMA_No).Visible = chkAIO_CurOrd_RMA.Checked

    '                '.Columns(AIO_CurOrd_Col.Ord_No).Visible = False
    '                '.Columns(AIO_CurOrd_Col.Ord_Dt).Visible = False

    '                .Columns(AIO_CurOrd_Col.Inv_No).Visible = chkAIO_CurOrd_Inv.Checked
    '                .Columns(AIO_CurOrd_Col.Inv_Dt).Visible = chkAIO_CurOrd_Inv.Checked
    '                .Columns(AIO_CurOrd_Col.Bill_To_Name).Visible = chkAIO_CurOrd_Inv.Checked

    '                .Columns(AIO_CurOrd_Col.Ct_Ord_No).Visible = chkAIO_CurOrd_Cre.Checked
    '                .Columns(AIO_CurOrd_Col.Ct_Inv_No).Visible = chkAIO_CurOrd_Cre.Checked

    '                '.Columns(AIO_CurOrd_Col.OE_Po_No).Visible = False
    '                '.Columns(AIO_CurOrd_Col.Tot_Dollars).Visible = False
    '                .Columns(AIO_CurOrd_Col.Tot_Sls_Amt).Visible = False
    '                '.Columns(AIO_CurOrd_Col.Shipping_Status).Visible = False

    '                .Columns(AIO_CurOrd_Col.User_def_Fld_4).Visible = False
    '                .Columns(AIO_CurOrd_Col.Nb_Travelers).Visible = False
    '                .Columns(AIO_CurOrd_Col.LinesShipped).Visible = False
    '                .Columns(AIO_CurOrd_Col.NotShipped).Visible = False
    '                .Columns(AIO_CurOrd_Col.PartialShipped).Visible = False
    '                .Columns(AIO_CurOrd_Col.CompleteShipped).Visible = False

    '                .Columns(AIO_CurOrd_Col.ShippedDate).Visible = (chkAIO_CurOrd_Ord.Checked Or chkAIO_CurOrd_Inv.Checked)

    '                .Columns(AIO_CurOrd_Col.Line_Count).Visible = False
    '                '.Columns(AIO_CurOrd_Col.Has_Bo).Visible = False

    '                .Columns(AIO_CurOrd_Col.BO_Count).Visible = chkAIO_CurOrd_BOOnly.Checked

    '                .Columns(AIO_CurOrd_Col.Repeat_From).Visible = chkAIO_CurOrd_RepeatsOnly.Checked
    '                .Columns(AIO_CurOrd_Col.Repeat_To).Visible = chkAIO_CurOrd_RepeatsOnly.Checked

    '                .Columns(AIO_CurOrd_Col.Extra_1).Visible = False
    '                .Columns(AIO_CurOrd_Col.Extra_2).Visible = False

    '            End With

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvCurrentOrders_FillGrid()

    '        Try

    '            Dim strSql As String
    '            strSql = "EXEC DBO.EXACT_TRAVELER_CUSTOMER_HISTORY '" & m_Customer.cmp_code.Trim & "', " & txtAIO_CurOrd_LastDays.Text.ToString

    '            dtAIO_CurrentOrders = db.DataTable(strSql)

    '            dgvCurrentOrders.DataSource = dtAIO_CurrentOrders
    '            dgvCurrentOrders.AllowUserToAddRows = False

    '            Call dgvCurrentOrders_Filter()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvCurrentOrders_Filter()

    '        Try

    '            If dtAIO_CurrentOrders Is Nothing Then Exit Sub

    '            'txtLoading.Visible = True
    '            'Me.Refresh()

    '            Dim strFilter As String = ""
    '            Dim strSubFilter As String = ""

    '            If Not (chkAIO_CurOrd_Cre.Checked) Then strFilter = strFilter & " (Ord_type <> 'C')  AND "
    '            If Not (chkAIO_CurOrd_Quo.Checked) Then strFilter = strFilter & " (Ord_type <> 'Q')  AND "
    '            If Not (chkAIO_CurOrd_Ord.Checked) Then strFilter = strFilter & " (Ord_type <> 'O')  AND "
    '            If Not (chkAIO_CurOrd_RMA.Checked) Then strFilter = strFilter & " (Ord_type <> 'RMA')  AND "
    '            If Not (chkAIO_CurOrd_Inv.Checked) Then strFilter = strFilter & " (Ord_type <> 'I')  AND "
    '            If Not (chkAIO_CurOrd_NotShip.Checked) Then strFilter = strFilter & " (NotShipped <> 'X')  AND "
    '            If Not (chkAIO_CurOrd_PartShip.Checked) Then strFilter = strFilter & " (PartialShipped <> 'X')  AND "
    '            If Not (chkAIO_CurOrd_Ship.Checked) Then strFilter = strFilter & " (CompleteShipped <> 'X')  AND "

    '            If chkAIO_CurOrd_BOOnly.Checked Then strFilter = strFilter & " (Has_BO <> ' ')  AND "

    '            ' On doit contruite le Repeat a la fin, on ne peut pas mettre de OR et de AND dans la meme condition
    '            ' On doit alors completement les separer... crissement mauvais, mais bon...
    '            If chkAIO_CurOrd_RepeatsOnly.Checked Then
    '                If strFilter = "" Then
    '                    strFilter = " (Repeat_From <> '' OR Repeat_To <> '')  AND "
    '                Else
    '                    strSubFilter = Mid(strFilter, 1, Len(strFilter) - 4)
    '                    strFilter = "(" & strSubFilter & " AND Repeat_From <> '') OR (" & strSubFilter & " AND Repeat_To <> '')  AND "
    '                End If
    '            End If

    '            'dgvCurrentOrders.
    '            'datCustHistory.Recordset.Filter = ""
    '            'datCustHistory.Recordset.Requery()

    '            If strFilter <> "" Then strFilter = Mid(strFilter, 1, Len(strFilter) - 4)

    '            dtAIO_CurrentOrders.DefaultView.RowFilter = strFilter

    '            'If strFilter <> "" Then
    '            '    'datCustHistory.Recordset.Filter = Mid(strFilter, 1, Len(strFilter) - 4)
    '            'Else
    '            '    dtAIO_CurrentOrders.DefaultView.RowFilter = strFilter
    '            'End If

    '            'Call SetDgCustHistoryColumns()

    '            'txtLoading.Visible = False


    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '#End Region

#Region "LOAD SELFPROMO ########################################################"

    Private Sub dgvSelfPromo_Load()

        Try
            '++ ID new column for spesificate what is self program 
            'PROG_NAME,V.CUSTNO, A.INV_YEAR, V.VOL_REB, 
            'A.oe_po_no, isnull(A.TOT_AMT_FC, 0) AS TOT_AMT_FC, A.inv_dt 

            With dgvSelfPromo.Columns
                .Add(DGVTextBoxColumn("PROG", "PROG", 60))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 40))

                .Add(DGVTextBoxColumn("VOL_REB", "VOL_REB", 50))
                .Add(DGVTextBoxColumn("OE_PO_NO", "PO Number", 80))
                .Add(DGVTextBoxColumn("TOT_AMT_FC", "Amount", 65))
                .Add(DGVTextBoxColumn("INV_YEAR", "YEAR", 50))
                .Add(DGVTextBoxColumn("INV_DT", "Date", 80))
            End With

            Call dgvSelfPromo_ShowColumns()

            txtAIO_SelfPromoYear.Text = Date.Now.Year.ToString

            Call dgvSelfPromo_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSelfPromo_ShowColumns()

        Try
            If dgvSelfPromo.Columns.Count = 0 Then Exit Sub

            With dgvSelfPromo

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                .Columns(AIO_SelfPromo_Col.CUS_NO).Visible = False
                .Columns(AIO_SelfPromo_Col.INV_YEAR).Visible = False
                .Columns(AIO_SelfPromo_Col.VOL_REB).Visible = False

            End With

            Dim oCellStyle As New DataGridViewCellStyle()
            oCellStyle.Format = "##,##0.00"
            oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgvSelfPromo.Columns(AIO_SelfPromo_Col.TOT_AMT_FC).DefaultCellStyle = oCellStyle

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSelfPromo_FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            '++ID 17.07.2015
            Dim strSql As String = _
                               " select cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC, " & _
                               " inv_dt  from   betty.Bankers_VolumeRebate V " & _
                               " left join rptdash_sales_SelfPromoAllowance on cus_no = custno " & _
                               " where custno = '" & m_Customer.cmp_code & "' " & _
                               "order by	inv_dt desc "


            strSql = "select 'Allowance' as prog,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   betty.Bankers_VolumeRebate V " _
& " Left Join rptdash_sales_SelfPromoAllowance on cus_no = custno where  custno = '" & m_Customer.cmp_code & "' " _
          & "  union " _
& "Select 'Self Promo' as prog,cus_no,inv_year,V.VOL_REB,oe_po_no,isnull(TOT_AMT_FC, 0) AS TOT_AMT_FC,  inv_dt from   betty.Bankers_VolumeRebate V " _
& "  Left Join " _
& " (SELECT  cus_no, ord_no,item_no, CASE WHEN orig_ord_type = 'C' THEN 0 ELSE 1 END AS isNotCredit, tot_amt_fc, YEAR(inv_dt) AS inv_year, region, ClassificationId, cus_city, regionBD, user_def_fld_2 AS orderType,  " _
 & "                        AccountEmployeeId, inv_dt, oe_po_no, cnt_no, cnt_name " _
& " From dbo.rptdash_sales_CustomerSalesInHistory " _
& " Where (item_no Like '88SELFPROMO%')) sp on v.CUSTNO = sp.cus_no where   cus_no = '" & m_Customer.cmp_code & "' and inv_year = year(getdate()) "


            '++ID 17.07.2015 I put in comment
            '"Select		V.CUSTNO As CUS_NO, A.INV_YEAR, V.VOL_REB, A.oe_po_no, isnull(A.TOT_AMT_FC, 0) As TOT_AMT_FC, A.inv_dt " & _
            '"FROM		betty.Bankers_VolumeRebate V " & _
            '"LEFT JOIN	rptdash_sales_SelfPromoAllowance_Detail A On V.CUSTNO = A.cus_no And (a.inv_year = " & txtAIO_SelfPromoYear.Text & " Or A.inv_year Is null) " & _
            '"where		CUSTNO = '" & m_Customer.cmp_code & "' " & _
            '"order by	A.inv_dt"

            dtAIO_SelfPromo = db.DataTable(strSql)

            dgvSelfPromo.DataSource = dtAIO_SelfPromo
            dgvSelfPromo.AllowUserToAddRows = False

            Dim dblAllowance As Double = 0
            Dim dblSelfPromoAmt As Double = 0

            If dtAIO_SelfPromo.Rows.Count <> 0 Then
                txtSelfPromo_Amt.Text = dtAIO_SelfPromo.Rows(0).Item("VOL_REB")
                For Each drRow As DataRow In dtAIO_SelfPromo.Rows
                    If drRow.Item(AIO_SelfPromo_Col.PROG).ToString = "Allowance" Then
                        dblAllowance += drRow.Item("Tot_Amt_FC")
                    ElseIf drRow.Item(AIO_SelfPromo_Col.PROG).ToString = "Self Promo" Then
                        dblSelfPromoAmt += drRow.Item("Tot_Amt_FC")
                    End If
                Next
                txtSelfPromo_Remaining.Text = (dtAIO_SelfPromo.Rows(0).Item("VOL_REB") + dblAllowance).ToString
                txtSelfPromo.Text = dblSelfPromoAmt.ToString
            Else
                txtSelfPromo_Amt.Text = "0.00"
                txtSelfPromo_Remaining.Text = "0.00"
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "LOAD PUSHED ORDER #####################################################"

    Private Sub dgvPushedOrders_Load()

        Try

            'V.CUSTNO, A.INV_YEAR, V.VOL_REB, 
            'A.oe_po_no, isnull(A.TOT_AMT_FC, 0) AS TOT_AMT_FC, A.inv_dt 

            With dgvPushedOrders.Columns
                .Add(DGVTextBoxColumn("CUS_PUSH_ORDER_ID", "CUS_PUSH_ORDER_ID", 50))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 50))
                .Add(DGVTextBoxColumn("ORD_NO", "Order", 60))
                .Add(DGVTextBoxColumn("PUSH_DATE", "PushDate", 60))
                .Add(DGVTextBoxColumn("ORD_COMMENT", "Comments", 195))
                .Add(DGVTextBoxColumn("USER_LOGIN", "Entered By", 50))
                .Add(DGVTextBoxColumn("UPDATE_TS", "Date", 45))
            End With

            Call dgvPushedOrders_ShowColumns()

            Call dgvPushedOrders_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvPushedOrders_ShowColumns()

        Try
            If dgvPushedOrders.Columns.Count = 0 Then Exit Sub

            With dgvPushedOrders

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                .Columns(AIO_PushOrd_Col.CUS_PUSH_ORDER_ID).Visible = False
                .Columns(AIO_PushOrd_Col.CUS_NO).Visible = False
                .Columns(AIO_PushOrd_Col.USER_LOGIN).Visible = False
                .Columns(AIO_PushOrd_Col.UPDATE_TS).Visible = False

                Dim oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "MM/dd/yy"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                .Columns(AIO_PushOrd_Col.PUSH_DATE).DefaultCellStyle = oCellStyle
                .Columns(AIO_PushOrd_Col.UPDATE_TS).DefaultCellStyle = oCellStyle

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvPushedOrders_FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'CONVERT(VARCHAR(10), PUSH_DATE, 101)
            Dim strSql As String = _
            "SELECT		TOP 3 CUS_PUSH_ORDER_ID, CUS_NO, ORD_NO, " & _
            "           PUSH_DATE, ORD_COMMENT, USER_LOGIN, UPDATE_TS " & _
            "FROM		MDB_CUS_PUSH_ORDER WITH (Nolock) " & _
            "WHERE      CUS_NO = '" & m_Customer.cmp_code & "' " & _
            "ORDER BY	CUS_PUSH_ORDER_ID DESC"

            'Dim strSql As String = _
            '"SELECT		TOP 3 CUS_PUSH_ORDER_ID, CUS_NO, ORD_NO, " & _
            '"           CONVERT(VARCHAR(10), PUSH_DATE, 101) AS PUSH_DATE, " & _
            '"           ORD_COMMENT, USER_LOGIN, UPDATE_TS " & _
            '"FROM		MDB_CUS_PUSH_ORDER WITH (Nolock) " & _
            '"WHERE      CUS_NO = '" & m_Customer.cmp_code & "' " & _
            '"ORDER BY	CUS_PUSH_ORDER_ID DESC"

            dtAIO_PushedOrders = db.DataTable(strSql)

            dgvPushedOrders.DataSource = dtAIO_PushedOrders
            dgvPushedOrders.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "LOAD DOCUMENT CORRESPONDANCE ###################################"

    Private Sub dgvDocContacts_Load()

        Try

            'V.CUSTNO, A.INV_YEAR, V.VOL_REB, 
            'A.oe_po_no, isnull(A.TOT_AMT_FC, 0) AS TOT_AMT_FC, A.inv_dt 

            'CUS_COMM_TYPE_ID, CUS_NO, COMM_TYPE_ID, COMM_TYPE_DESC, CONTACT_ID, USER_LOGIN, UPDATE_TS

            With dgvDocContacts.Columns
                .Add(DGVTextBoxColumn("CUS_COMM_TYPE_ID", "CUS_COMM_TYPE_ID", 50))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 50))
                .Add(DGVTextBoxColumn("COMM_TYPE_ID", "COMM_TYPE_ID", 50))
                .Add(DGVTextBoxColumn("COMM_TYPE_DESC", "Document", 100))

                Dim comboboxColumn As DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("CONTACT_ID", "Correspondance", 180)
                With comboboxColumn
                    .DataSource = GetDocContactsList()
                    .ValueMember = "Contact_ID"
                    .DisplayMember = "Contact_Desc"
                End With
                .Add(comboboxColumn)

                .Add(DGVTextBoxColumn("USER_LOGIN", "USER_LOGIN", 100))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE_TS", 100))
            End With

            Call dgvDocContacts_ShowColumns()

            Call dgvDocContacts_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function GetDocContactsList() As DataTable ' , ByVal pstrProd_Cat As String)

        GetDocContactsList = New DataTable

        Try

            'Dim strSQL As String = _
            '"SELECT  CAST(0 AS INT) AS Contact_ID, CAST('' AS VARCHAR(50)) AS Contact_Desc " & _
            '"UNION " & _
            '"SELECT		ISNULL(C.ID, 0) AS Contact_ID, rtrim(isnull(c.FullName, '')) AS Contact_Desc " & _
            '"FROM		cicntp C WITH (Nolock) " & _
            '"LEFT JOIN	taal T WITH (Nolock) ON C.taalcode = T.taalcode " & _
            '"WHERE		C.cmp_wwn = '" & m_Customer.cmp_wwn & "' " & _
            '"ORDER BY   Contact_Desc, Contact_ID "


            Dim strSQL As String =
            "SELECT  CAST(0 AS INT) AS Contact_ID, CAST('  <NONE>' AS VARCHAR(100)) AS Contact_Desc " &
            "UNION " &
            "SELECT		ISNULL(C.ID, 0) AS Contact_ID, rtrim(isnull(c.FullName, '')) AS Contact_Desc " &
            "FROM		cicntp C WITH (Nolock) " &
            "LEFT JOIN	taal T WITH (Nolock) ON C.taalcode = T.taalcode " &
            "WHERE	ISNULL(C.active_y,0) = 1 And Cast(C.cmp_wwn As Varchar(40)) = '" & Trim(m_Customer.cmp_wwn) & "' " &
            "ORDER BY   Contact_Desc, Contact_ID "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            GetDocContactsList = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function


    Private Sub dgvDocContacts_ShowColumns()

        Try
            If dgvDocContacts.Columns.Count = 0 Then Exit Sub

            With dgvDocContacts

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                'CUS_COMM_TYPE_ID, CUS_NO, COMM_TYPE_ID, COMM_TYPE_DESC, CONTACT_ID, USER_LOGIN, UPDATE_TS
                .Columns(AIO_CusContacts_Col.CUS_COMM_TYPE_ID).Visible = False
                .Columns(AIO_CusContacts_Col.CUS_NO).Visible = False
                .Columns(AIO_CusContacts_Col.COMM_TYPE_ID).Visible = False
                .Columns(AIO_CusContacts_Col.USER_LOGIN).Visible = False
                .Columns(AIO_CusContacts_Col.UPDATE_TS).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocContacts_FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim strSql As String = _
            "SELECT		ISNULL(CT.CUS_COMM_TYPE_ID, 0) AS CUS_COMM_TYPE_ID, " & _
            "			CUS.CUS_NO, " & _
            "			CUS.COMM_TYPE_ID, CUS.COMM_TYPE_DESC, CT.CONTACT_ID, " & _
            "			CT.USER_LOGIN, CT.UPDATE_TS " & _
            "FROM  " & _
            "	( " & _
            "		SELECT		C.CUS_NO, CFG.COMM_TYPE_ID, CFG.COMM_DESC AS COMM_TYPE_DESC " & _
            "		FROM		ARCUSFIL_SQL C WITH (Nolock), MDB_CFG_COMM_TYPE CFG WITH (Nolock) " & _
            "	) CUS " & _
            "LEFT JOIN	MDB_CUS_COMM_TYPE CT WITH (Nolock) ON CUS.COMM_TYPE_ID = CT.COMM_TYPE_ID AND CUS.cus_no = CT.CUS_NO " & _
            "WHERE		CUS.CUS_NO = '" & m_Customer.cmp_code.Trim & "' AND CT.PROGRAM_ID IS NULL "
            '"SELECT		ISNULL(CT.CUS_COMM_TYPE_ID, 0) AS CUS_COMM_TYPE_ID, " & _
            '"           CAST('" & m_Customer.cmp_code & "' AS VARCHAR(20)) AS CUS_NO, " & _
            '"			CFG.COMM_TYPE_ID, CFG.COMM_DESC AS COMM_TYPE_DESC, CT.CONTACT_ID, " & _
            '"           CT.USER_LOGIN, CT.UPDATE_TS " & _
            '"FROM		MDB_CFG_COMM_TYPE CFG WITH (Nolock) " & _
            '"LEFT JOIN	MDB_CUS_COMM_TYPE CT WITH (Nolock) ON CFG.COMM_TYPE_ID = CT.COMM_TYPE_ID " & _
            '"WHERE		CT.CUS_NO = '" & m_Customer.cmp_code & "' OR CT.CUS_NO IS NULL " & _
            '"ORDER BY	CFG.COMM_ORDER "

            dtDocContacts = db.DataTable(strSql)

            dgvDocContacts.DataSource = dtDocContacts
            dgvDocContacts.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "LOAD PROGRAM PRICING ##################################################"

    '    Private Sub dgvProgramPricing_Load()

    '        Try
    '            With dgvProgramPricing.Columns
    '                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 50))
    '                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 20))
    '                .Add(DGVTextBoxColumn("PROG_CD", "Program Code", 120))
    '                .Add(DGVTextBoxColumn("PROG_TYPE", "PROG_TYPE", 50))
    '                .Add(DGVTextBoxColumn("END_DT", "End Date", 120))
    '            End With

    '            Call dgvProgramPricing_ShowColumns()

    '            Call dgvProgramPricing_FillGrid()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvProgramPricing_ShowColumns()

    '        Try
    '            If dgvProgramPricing.Columns.Count = 0 Then Exit Sub

    '            With dgvProgramPricing

    '                .ColumnHeadersHeight = 20
    '                .RowHeadersWidth = 20

    '                .Columns(AIO_Programs_Col.CUS_PROG_ID).Visible = False
    '                .Columns(AIO_Programs_Col.CUS_NO).Visible = False
    '                .Columns(AIO_Programs_Col.PROG_TYPE).Visible = False

    '            End With

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvProgramPricing_FillGrid()

    '        Try

    '            Dim strSql As String = _
    '            "SELECT     P.CUS_PROG_ID, P.CUS_NO, P.PROG_CD, P.PROG_TYPE, P.END_DT " & _
    '            "FROM		MDB_CUS_PROG P WITH (Nolock)  " & _
    '            "WHERE		CUS_NO = '" & m_Customer.cmp_code & "' AND P.PROG_TYPE = 1 " & _
    '            "ORDER BY	END_DT "

    '            dtAIO_ProgramPricing = db.DataTable(strSql)

    '            dgvProgramPricing.DataSource = dtAIO_ProgramPricing
    '            dgvProgramPricing.AllowUserToAddRows = False

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

#End Region


#Region "LOAD COMMUNICATIONS ###################################################"

    Private Sub dgvCommunications_Load()

        Try

            ''Doc, DocType, Ord_No, DocFrom, Subject, CreateDate, CommID
            With dgvCommunications.Columns
                .Add(DGVTextBoxColumn("Doc", "Doc", 0)) ''
                .Add(DGVTextBoxColumn("DocType", "DocType", 80))
                .Add(DGVTextBoxColumn("ExtType", "Ext Type", 70))
                .Add(DGVTextBoxColumn("Ord_No", "Ord_No", 80))
                .Add(DGVTextBoxColumn("DocFrom", "DocFrom", 80))
                .Add(DGVTextBoxColumn("DocTo", "DocTo", 150))
                .Add(DGVTextBoxColumn("Subject", "Subject", 250))
                .Add(DGVCheckBoxColumn("NegativeFeed", "Negative", 70))
                .Add(DGVTextBoxColumn("NegativeReason", "Reason", 70))
                .Add(DGVTextBoxColumn("CreateDate", "CreateDate", 80))
                .Add(DGVTextBoxColumn("CommID", "CommID", 0)) '' 
            End With

            Call dgvCommunications_ShowColumns()

            Call dgvCommunications_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCommunications_ShowColumns()

        Try
            If dgvCommunications.Columns.Count = 0 Then Exit Sub

            With dgvCommunications

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                .Columns(AIO_Comm_Col.Doc).Visible = False
                .Columns(AIO_Comm_Col.CommID).Visible = False
                .Columns(AIO_Comm_Col.ExtType).Visible = False
                .Columns(AIO_Comm_Col.DocTo).Visible = False
                .Columns(AIO_Comm_Col.NegativeFeed).Visible = False
                .Columns(AIO_Comm_Col.NegativeReason).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCommunications_FillGrid()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim strSql As String
            'strSql = "exec dbo.EXACT_TRAVELER_COMMUNICATIONS_LIST_20130805 '" & m_Customer.cmp_code & "', '', 1, 15"
            strSql = "exec dbo.EXACT_TRAVELER_COMMUNICATIONS_LIST_20140128 '" & m_Customer.cmp_code & "', '', 1, 30"

            dtAIO_Communications = db.DataTable(strSql)

            dgvCommunications.DataSource = dtAIO_Communications
            dgvCommunications.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "LOAD OPTIONS ##########################################################"

    Private Sub dgvCharges_Load()

        Try
            '++ID put in comment 2015.04.20-----------------------------------------------
            'With dgvOptions.Columns
            '    .Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 50))
            '    '.Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 20))
            '    .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 85))
            '    .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 40))
            '    .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 40))
            '    .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 40))
            '    .Add(DGVCheckBoxColumn("WAIVED", "N/C", 30))
            '    .Add(DGVCheckBoxColumn("NOT_WAIVED", "Not Waived", 40))
            '    .Add(DGVTextBoxColumn("EXT_COMMENTS", "Comments", 125))
            '    .Add(DGVTextBoxColumn("CHARGE_ORDER", "CHARGE_ORDER", 50))
            '    'CHARGE_ORDER
            'End With
            '----------------------------------------------------------------------------
            '++ID Added new columns 2015.04.20 ------------------------------------------
            dgvOptions.Columns.Clear()

            With dgvOptions.Columns
                .Add(DGVTextBoxColumn("CHARGE_ID", "Charge ID", 50))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Description", 65))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 85))
                .Add(DGVCheckBoxColumn("Always", "Always", 45))
                .Add(DGVCheckBoxColumn("Never", "Never", 45))
                .Add(DGVTextBoxColumn("CD_TP", "cd_tp", 40))
                .Add(DGVTextBoxColumn("CURR_CD", "Curr cd", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_CUST_NO", "Customer", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_ITEM_NO", "Item no", 90))
                .Add(DGVTextBoxColumn("PRC_OR_DISC_1", "Prix", 48))
                .Add(DGVTextBoxColumn("START_DT", "Start Dt", 60))
                .Add(DGVTextBoxColumn("END_DT", "End Dt", 60))
                .Add(DGVTextBoxColumn("extra_8", "Create Date", 60))
                .Add(DGVTextBoxColumn("extra_9", "Update_Date", 60))
                .Add(DGVTextBoxColumn("extra_15", "User Login", 60))
                .Add(DGVTextBoxColumn("ID", "ID", 50))
                'CHARGE_ORDER
            End With


            With dgvOptions
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                .Columns(OptionAll.CHARGE_ID).Visible = False
                .Columns(OptionAll.DESCRIPTION).Visible = False
                .Columns(OptionAll.cd_tp).Visible = False
                .Columns(OptionAll.curr_cd).Visible = False
                .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
                .Columns(OptionAll.cd_tp_1_item_no).Visible = False
                .Columns(OptionAll.extra_8).Visible = False 'create date
                .Columns(OptionAll.extra_9).Visible = False 'update date
                .Columns(OptionAll.extra_15).Visible = False
                .Columns(OptionAll.ID).Visible = False
            End With

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
            '++ID put in comment 2015.04.20
            'Call dgvCharges_ShowColumns()

            Call dgvCharges_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    '++ID create this Enum 2015.04.20----
    Private Enum OptionAll
        CHARGE_ID
        DESCRIPTION
        SHORT_DESC
        Always 'always 1(true) - 0(false)
        Never
        cd_tp
        curr_cd
        cd_tp_1_cust_no
        cd_tp_1_item_no
        prc_or_disc_1
        start_dt
        end_dt
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

                .Columns(AIO_Charges_Col.CHARGE_ID).Visible = False
                '.Columns(AIO_Charges_Col.CHARGE_USAGE_ID).Visible = False
                .Columns(AIO_Charges_Col.CUS_NO).Visible = False
                .Columns(AIO_Charges_Col.NEVER_USE).Visible = False
                .Columns(AIO_Charges_Col.NOT_WAIVED).Visible = False
                .Columns(AIO_Charges_Col.CHARGE_ORDER).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvCharges_FillGrid()

        Try
            Dim strSql As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            '++ID put in comment 2015.04.20 ------------------------------------------------------------------------
            'strSql = _
            '"SELECT		C.CHARGE_ID, ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.SHORT_DESC, CU.CUS_NO, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS WAIVED, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 0 ELSE 1 END)) AS NOT_WAIVED, " & _
            '"           CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  + " & _
            '"           CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END  + " & _
            '"           ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS " & _
            '"            FROM " & _
            '"	(	SELECT	CUS.CUS_NO, C.*" & _
            '"		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
            '"	) C " & _
            '"LEFT JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " & _
            '"LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no " & _
            '"WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND " & _
            '"           (C.CHARGE_ID IN (13, 14, 16, 8, 17) OR CU.charge_usage_id IS NOT NULL) AND " & _
            '"           (ISNULL(CU.cus_prog_id, 0) = 0) " & _
            '"ORDER BY	C.CUS_NO, CH.CHARGE_ORDER, C.SHORT_DESC "

            'strSql = _
            '"SELECT		DISTINCT C.CHARGE_ID, C.SHORT_DESC, CU.CUS_NO, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS WAIVED, " & _
            '"			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 0 ELSE 1 END)) AS NOT_WAIVED, " & _
            '"           CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  + " & _
            '"           CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END  + " & _
            '"           ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS, CH.CHARGE_ORDER " & _
            '"FROM " & _
            '"	(	SELECT	CUS.CUS_NO, C.*" & _
            '"		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
            '"	) C " & _
            '"LEFT JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " & _
            '"LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no AND CAST(GETDATE() AS DATE) BETWEEN CHARGE_FROM AND CHARGE_TO " & _
            '"LEFT JOIN  MDB_CUS_PROG CP WITH (NOLOCK) ON CU.CUS_PROG_ID = CP.CUS_PROG_ID AND ISNULL(CP.PROG_TYPE, 0) IN (0, 4) " & _
            '"WHERE		CU.CUS_NO = '" & m_Customer.cmp_code & "' AND " & _
            '"           (C.CHARGE_ID IN (13, 14, 16, 8, 17) OR CU.charge_usage_id IS NOT NULL) AND ISNULL(CP.PROG_TYPE, 0) IN (0, 4) " & _
            '"ORDER BY	CH.CHARGE_ORDER, C.SHORT_DESC "
            '-----------------------------------------------------------------------------------------------
            '++ID added 2015.04.20 -------------------------------------------------------------------------
            '"  select m.CHARGE_ID,m.CHARGE_CD,m.DESCRIPTION,m.SHORT_DESC, " & _
            ' " o.cd_tp,o.curr_cd,o.cd_tp_1_cust_no,o.cd_tp_3_cust_type,cd_tp_1_item_no, " & _
            ' " o.start_dt,o.end_dt,o.cd_prc_basis,o.ID  " & _
            ' " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            ' "  where o.cd_tp_1_cust_no = 'c210' and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "



            strSql = _
            " select m.CHARGE_ID, m.DESCRIPTION, m.SHORT_DESC, " &
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '1' THEN 1 ELSE 0 END)) as Always, " & _
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '2' THEN 1 ELSE 0 END)) as Never, " & _
            " o.cd_tp, o.curr_cd, " & _
            " o.cd_tp_1_cust_no, cd_tp_1_item_no, prc_or_disc_1 , o.start_dt, o.end_dt, " & _
            " o.extra_8, o.extra_9, o.extra_15, o.ID " & _
            " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            " where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' " & _
            " and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "

            '------------------------------------------------------------------------------------------------

            dtAIO_Charges = db.DataTable(strSql)

            dgvOptions.DataSource = dtAIO_Charges
            dgvOptions.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region

    '#Region "PRIVATE CURRENTORDERS FILTER CONTROL EVENTS ##########################"

    '    Private Sub chkAIO_CurrentOrders_More_CheckedChanged(sender As System.Object, e As System.EventArgs)

    '        Try

    '            If chkAIO_CurrentOrders_More.Checked Then
    '                scCurrentOrders.SplitterDistance = 90
    '            Else
    '                scCurrentOrders.SplitterDistance = 16
    '            End If

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub dgvCurrentOrders_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    '    End Sub

    '    Private Sub dgvCurrentOrders_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs)

    '        Debug.Print(e.Column.Width.ToString)

    '    End Sub

    '    Private Sub chkAIO_CurOrd_Ord_CheckedOrdType(sender As System.Object, e As System.EventArgs)

    '        Try

    '            Call dgvCurrentOrders_ShowColumns()
    '            Call dgvCurrentOrders_Filter()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub chkAIO_CurOrd_Ord_CheckedFlags(sender As System.Object, e As System.EventArgs)

    '        Try

    '            Call dgvCurrentOrders_Filter()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub txtAIO_CurOrd_LastDays_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    '        Try

    '            Dim strValue As String = txtAIO_CurOrd_LastDays.Text.Trim

    '            If IsNumeric(strValue) Then

    '                If Not (txtAIO_CurOrd_LastDays.OldValue.ToString.Trim = txtAIO_CurOrd_LastDays.Text.ToString.Trim) Then

    '                    Call dgvCurrentOrders_FillGrid()

    '                End If

    '            Else

    '                MsgBox("Value must be numeric.")
    '                e.Cancel = True

    '            End If

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub gbAIO_CurrentOrders_Resize_CheckedChanged(sender As System.Object, e As System.EventArgs)

    '        Try

    '            Call Resize_gbAIO__CurrentOrders_Resize()

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '    Private Sub Resize_gbAIO__CurrentOrders_Resize()

    '        Try

    '            If chkAIO_CurrentOrders_Resize.Checked Then
    '                gbAIO_CurrentOrders.Size = New Size(Me.Width - 42, Me.Height - 308)
    '            Else
    '                gbAIO_CurrentOrders.Size = New Size(377, 304)
    '            End If

    '        Catch er As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '        End Try

    '    End Sub

    '#End Region

#Region "PRIVATE GRID COLUMN ENUMERATORS ######################################"

    Private Enum AIO_CurOrd_Col
        Cus_No
        Ord_Type
        RMA_No
        Ord_No
        Ord_Dt
        Inv_No
        Inv_Dt
        Ct_Ord_No
        Ct_Inv_No
        OE_Po_No
        Tot_Dollars
        Bill_To_Name
        Tot_Sls_Amt
        Shipping_Status
        User_def_Fld_4
        Nb_Travelers
        LinesShipped
        NotShipped
        PartialShipped
        CompleteShipped
        ShippedDate
        Line_Count
        Has_Bo
        BO_Count
        Repeat_From
        Repeat_To
        Extra_1
        Extra_2
    End Enum
    Private Enum AIO_SelfPromo_Col
        PROG
        CUS_NO
        VOL_REB
        OE_PO_NO
        TOT_AMT_FC
        INV_YEAR
        INV_DT
        'CUS_NO
        'OE_PO_NO
        'ITEM_NO
        'PRICE
        'ORD_DT
    End Enum
    Private Enum AIO_CusContacts_Col
        CUS_COMM_TYPE_ID
        CUS_NO
        COMM_TYPE_ID
        COMM_TYPE_DESC
        CONTACT_ID
        USER_LOGIN
        UPDATE_TS
    End Enum
    Private Enum AIO_Programs_Col
        CUS_PROG_ID
        CUS_NO
        PROG_CD
        PROG_TYPE
        END_DT
    End Enum
    Private Enum AIO_Comm_Col
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
    Private Enum AIO_Prices_Col
        CUS_PROG_ID
        CUS_NO
        PROG_CD
        PROG_TYPE
        ITEM_CD
        UNIT_PRICE
        START_DT
        END_DT
        APPROVED_BY_US
    End Enum
    Private Enum AIO_Charges_Col
        CHARGE_ID
        'CHARGE_USAGE_ID ' REMOVED
        SHORT_DESC
        CUS_NO
        ALWAYS_USE
        NEVER_USE
        WAIVED
        NOT_WAIVED
        EXT_COMMENTS
        CHARGE_ORDER ' NEW
    End Enum

    Private Enum AIO_PushOrd_Col
        CUS_PUSH_ORDER_ID
        CUS_NO
        ORD_NO
        PUSH_DATE
        ORD_COMMENTS
        USER_LOGIN
        UPDATE_TS
    End Enum
#End Region

    Private Sub tcCusInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcCusInfo.Click

        Dim tcControl As TabControl = sender

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Select Case tcControl.SelectedIndex ' tcControl.SelectedIndex

                Case Tabs.AllInOne
                    Call dgvCharges_FillGrid()
                Case Tabs.Communications
                    UcComm.Load(m_Customer)
                Case Tabs.Contacts
                    UcContacts.Load(m_Customer)
                Case Tabs.Orders
                    UcOrders.Load(m_Customer)
                Case Tabs.Programs
                    UcPrograms.Load(m_Customer)
                Case Tabs.SpecialPricing
                    UcSpecialPricing.Load(m_Customer)
                Case Tabs.Quotes
                    UcQuotes.Load(m_Customer)
                Case Tabs.Charges
                    UcCharges.Load(m_Customer)
                Case Tabs.Shipping
                    UcShipping.Load(m_Customer)
                    'Case Tabs.Production
                    'UcProduction.Load(m_Customer)
                Case Tabs.OtherComments
                    UcOtherComments.Load(m_Customer)
                Case Tabs.CustPack
                    Dim frmCustPack As New frmItem_Picture(m_Customer, "CustomerHeader")
                    tcControl.SelectedIndex = 0
                    ' Call dgvCharges_FillGrid()
                    frmCustPack.Show()

                    'Case Tabs.Artworks
                    '    'UcOrderComments.Load(m_Customer)
                    'Case Tabs.Charts
                    '    'UcOrderComments.Load(m_Customer)
                    'Case Tabs.Documents
                    '    UcDocuments.Load(m_Customer)

            End Select

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Enum Tabs

        AllInOne
        Communications
        Contacts
        Orders
        Programs
        SpecialPricing
        Quotes
        Charges
        Shipping
        'Production
        OtherComments
        'Documents
        'Artworks
        'Charts
        CustPack
    End Enum


    Private Sub cmdMacola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMacola.Click

        Dim oCustomer As New cCustomerInfo(m_Customer.cmp_code)
        oCustomer.Form.ShowDialog()
        oCustomer = Nothing

    End Sub

    Private Sub tpAllInOne_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpAllInOne.Resize

        'Dim iWidth As Integer
        'Dim iHeight As Integer

        'iWidth = tpAllInOne.Width
        'iHeight = tpAllInOne.Height

        '' CALCULATE WIDTH
        'gbAIO_CurrentOrders.Width = 377 + ((iWidth - 377) / 3)
        'gbAIO_Communications.Width = 603 + ((iWidth - 603) * 2 / 3)

        'gbAIO_SelfPromo.Width = gbAIO_CurrentOrders.Width

        'gbAIO_ProgramPricing.Width = 300 + ((iWidth - 300) / 3)
        'gbAIO_Charges.Width = gbAIO_ProgramPricing.Width
        'gbAIO_PriceLists.Width = gbAIO_ProgramPricing.Width
        'gbAIO_PackingShipping.Width = gbAIO_ProgramPricing.Width

        '' CALCULATE HEIGHT
        'gbAIO_CurrentOrders.Height = 304 + ((iHeight - 304) * 2 / 3)
        'gbAIO_Communications.Height = 140 + ((iHeight - 140) / 3)

        'gbAIO_SelfPromo.Height = 120 + ((iHeight - 120) / 3)

        'gbAIO_ProgramPricing.Height = gbAIO_Communications.Height
        'gbAIO_Charges.Height = gbAIO_ProgramPricing.Height
        'gbAIO_PriceLists.Height = gbAIO_ProgramPricing.Height
        'gbAIO_PackingShipping.Height = gbAIO_ProgramPricing.Height

        'gbAIO_Communications.Location = New Point(gbAIO_CurrentOrders.Width + 6, 4)
        'gbAIO_SelfPromo.Location = New Point(4, gbAIO_CurrentOrders.Width + 6)

        'gbAIO_ProgramPricing.Location = New Point(12, 12)
        'gbAIO_Charges.Location = New Point(12, 12)
        'gbAIO_PriceLists.Location = New Point(12, 12)
        'gbAIO_PackingShipping.Location = New Point(12, 12)


        'gbAIO_Communications.Location.X = gbAIO_CurrentOrders.Width + 6

    End Sub


    Private Sub btnCustomerCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerCharges.Click

        Dim oCustomer As New frmCustomerConfig
        oCustomer.ShowDialog()
        oCustomer = Nothing

    End Sub


    Private Sub txtAIO_SelfPromoYear_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAIO_SelfPromoYear.Validating

        Try

            If Not IsNumeric(txtAIO_SelfPromoYear.Text) Then
                txtAIO_SelfPromoYear.Text = Date.Now.Year.ToString
            End If

            Call dgvSelfPromo_FillGrid()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocContacts_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDocContacts.CellBeginEdit

        Try
            Select Case e.ColumnIndex

                Case AIO_CusContacts_Col.CONTACT_ID
                    ' Only allow this field to be edited. Everything else is generated by code.

                Case Else
                    e.Cancel = True

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocContacts_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocContacts.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case AIO_CusContacts_Col.CONTACT_ID

                    Debug.Print("dgvDocContacts.EndEdit()")
                    dgvDocContacts.EndEdit()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocContacts_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocContacts.CellEndEdit

        Try

            If FormIsClosing Then

                Select Case e.ColumnIndex

                    Case AIO_CusContacts_Col.CONTACT_ID

                        Dim oID As Integer = 0
                        Dim oCell As DataGridViewComboBoxCell = dgvDocContacts.CurrentCell

                        SaveDocContactsCell(oCell)

                End Select

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveDocContactsCell(ByRef oCell As DataGridViewComboBoxCell)

        Try
            Dim oIndex As Integer = dgvDocContacts.CurrentRow.Cells(AIO_CusContacts_Col.CUS_COMM_TYPE_ID).Value
            Dim oCharge As New cMdb_Cus_Comm_Type(oIndex)

            oCharge.Cus_No = m_Customer.cmp_code
            oCharge.Comm_Type_Id = dgvDocContacts.Rows(oCell.RowIndex).Cells(AIO_CusContacts_Col.COMM_TYPE_ID).Value
            If oCell.Value.Equals(DBNull.Value) Then
                oCharge.Contact_Id = 0
            Else
                oCharge.Contact_Id = oCell.Value
            End If
            oCharge.Save()

            dgvDocContacts.Rows(oCell.RowIndex).Cells(AIO_CusContacts_Col.CUS_COMM_TYPE_ID).Value = oCharge.Cus_Comm_Type_Id
            dgvDocContacts.Rows(oCell.RowIndex).Cells(AIO_CusContacts_Col.USER_LOGIN).Value = oCharge.User_Login
            dgvDocContacts.Rows(oCell.RowIndex).Cells(AIO_CusContacts_Col.UPDATE_TS).Value = oCharge.Update_Ts

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvDocContacts_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocContacts.CellValidated

        Try
            Debug.Print("dgvDocContacts_CellValidated")

            Select Case e.ColumnIndex
                Case AIO_CusContacts_Col.CONTACT_ID

                    Dim oID As Integer = 0
                    Dim oCell As DataGridViewComboBoxCell = dgvDocContacts.CurrentCell

                    If oCell.IsInEditMode Or FormIsClosing Then
                        SaveDocContactsCell(oCell)
                    End If

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsNewPushedOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNewPushedOrder.Click

        Call Menu_New_PushedOrder()

    End Sub

    Private Sub Menu_New_PushedOrder()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim ofrmPushOrder As New frmPushOrder(m_Customer)
            ofrmPushOrder.ShowDialog()

            ofrmPushOrder = Nothing

            Call dgvPushedOrders_FillGrid()

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetPermissions()

        Try
            SetUser_Rights(User_Rights, Me.Tag)

            Select Case User_Rights
                Case "READWRITE"
                    dgvDocContacts.ReadOnly = False

                Case "SUPERUSER"
                    dgvDocContacts.ReadOnly = False

                Case "READONLY"
                    'tsClose.Visible = True
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
                'c.Enabled = False
                'c.BackColor = Color.White
            ElseIf TypeOf c Is ComboBox Then
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                RemoveHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.Click, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
            ElseIf TypeOf c Is CheckBox Then
                '++ID 7.4.15
                If c.Name = "chkWhite_Glove" Then c.Enabled = False

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
                If c.Name = "cmdWhite_Glove_End_Date" Then c.Enabled = False

                'c.Enabled = False
                RemoveHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
                AddHandler c.GotFocus, AddressOf ReadOnlyFields_GotFocus ' TextBox_TextChanged
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub ReadOnlyFields_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If User_Rights = "READONLY" Then
            Label1.Focus()
        End If

    End Sub

    Private Sub tsRefreshPushedOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRefreshPushedOrder.Click

        Call dgvPushedOrders_FillGrid()

    End Sub

    Private Sub fields_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCmp_Code.GotFocus, txtCus_Note_3.GotFocus, _
                txtCmp_Name.GotFocus, txtCmp_FAdd1.GotFocus, txtCmp_FAdd2.GotFocus, txtCmp_FAdd3.GotFocus, txtCmp_FCity.GotFocus, _
                txtStateCode.GotFocus, txtCmp_FPC.GotFocus, txtCmp_FCtry.GotFocus, txtPhoneNumber.GotFocus, txtSalesPersonNumber.GotFocus, _
                txtRegion.GotFocus, txtCurrency.GotFocus, txtRep.GotFocus, txtRep_Phone.GotFocus, txtRep_Email.GotFocus, _
                txtClassificationID.GotFocus, txtEQP_Status.GotFocus, txtcmp_status.GotFocus, txtShipVia.GotFocus, _
                txtPaymentCondition.GotFocus, txttax_cd.GotFocus, txttax_cd_2.GotFocus, txttax_cd_3.GotFocus

        tcCusInfo.Focus()

    End Sub

    Private Sub cmdDisruption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisruption.Click

        Try

            If tcCusInfo.SelectedIndex = Tabs.Orders Then
                Dim oCustomer As New frmCustomer_Disruption(m_Customer, UcOrders.Current_Ord_No)
                oCustomer.ShowDialog()
                oCustomer = Nothing
            Else
                Dim oCustomer As New frmCustomer_Disruption(m_Customer)
                oCustomer.ShowDialog()
                oCustomer = Nothing
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub chkWhite_Glove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWhite_Glove.CheckedChanged

        txtWhite_Glove_End_Date.Enabled = (chkWhite_Glove.Checked)
        txtWhite_Glove_Order_Count.Enabled = (chkWhite_Glove.Checked)
   
        '++ID 7.4.2015 put in comment
        ' cmdWhite_Glove_End_Date.Enabled = (chkWhite_Glove.Checked)

    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    '    'Dim Forms As New List(Of Form)()
    '    Dim formType As Type = Type.GetType("System.Windows.Forms.Form")
    '    'Dim oForm As Form
    '    'For Each t As Type In Me.GetType().Assembly.GetTypes()
    '    '    If t.IsSubclassOf(GetType(System.Windows.Forms.Form)) = True Then
    '    '        oForm = CType(Activator.CreateInstance(t), Form)
    '    '        Debug.Print(oForm.Name & " -- " & oForm.Tag)
    '    '        'Forms.Add(CType(Activator.CreateInstance(t), Form))
    '    '    End If
    '    'Next

    '    'Dim Forms As New List(Of Form)()
    '    'Dim formType As Type = Type.GetType("System.Windows.Forms.Form")
    '    'For Each t As Type In sender.GetType().Assembly.GetTypes()
    '    '    If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
    '    '        MsgBox(t.Name)
    '    '    End If
    '    'Next

    '    'Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

    '    'Dim oForms As Form() = myAssembly.get
    '    'Dim types As Type() = myAssembly.GetTypes()
    '    'For Each myType In types
    '    '    ' mytype 
    '    '    If myType.BaseType.FullName = "System.Windows.Forms.Form" Then
    '    '        MessageBox.Show(myType.Name.)
    '    '    End If
    '    'Next


    'End Sub

    Private Sub gbCustomer_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gbCustomer.MouseClick
        Try
            gbCustomer.Focus()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Customer_Copy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gbCustomer.KeyDown
        Try
            'Ion Ctrl + C 
            If e.Control And e.KeyCode = Keys.C Then
                Call grpBox()
            End If
            'Ion
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Ion
    Public Sub grpBox()
        Try

            Dim txt() As String = {}
            Dim count As Int32 = 0
            Dim text As String = ""
            For Each grBoxContr As Control In gbCustomer.Controls

                If TypeOf grBoxContr Is TextBox Then

                    ReDim Preserve txt(count)
                    txt(count) = grBoxContr.Text
                    text += grBoxContr.Text & vbCrLf
                    count += 1
                End If

            Next grBoxContr

            Clipboard.Clear()
            Clipboard.SetText(text)
            Debug.Print(text)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Ion
    Private Sub Lab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click, Label2.Click, Label5.Click, Label8.Click, Label7.Click, Label6.Click, Label12.Click, Label1.Click, lblPhoneNumber.Click, Label3.Click, Label11.Click, Label10.Click

        gbCustomer.Focus()

    End Sub

    Private Sub txt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCmp_Code.Click, txtCus_Note_3.Click, txtCmp_Name.Click, txtCmp_FAdd1.Click, txtCmp_FAdd2.Click, txtCmp_FAdd3.Click, txtCmp_FCity.Click, txtStateCode.Click, txtCmp_FPC.Click, txtCmp_FCtry.Click

        gbCustomer.Focus()

    End Sub

    Private Sub txtWhite_Glove_End_Date_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWhite_Glove_End_Date.LostFocus
        Try
            If strChangeWtGl <> txtWhite_Glove_End_Date.Text Then
                booltxtWhGl = True
            Else
                booltxtWhGl = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    'strChangeWtGl
    'txtWhite_Glove_End_Date.Text = .White_Glove_End_Date.ToString
    '              txtWhite_Glove_End_Date.Tag = .White_Glove_End_Date.ToString
    'check if text changed, this boolean use in formclosing
    'if is changed required save

    'Private Sub txtWhite_Glove_End_Date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWhite_Glove_End_Date.TextChanged
    '    Try
    '        If strChangeWtGl <> txtWhite_Glove_End_Date.Text Then
    '            booltxtWhGl = True
    '        Else
    '            booltxtWhGl = False
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub chkWhite_Glove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWhite_Glove.Click
        boolchkWhGl = True
    End Sub

    Private Sub Lb_SAM_Textfiel4_Click(sender As Object, e As EventArgs) Handles Lb_SAM_Textfiel4.Click

    End Sub

    Private Function Get_SAM_Textfiel4(ByVal in_cmp_code As String) As String
        Dim db As New cDBA
        Dim dt As New DataTable
        Dim strSql As String

        Get_SAM_Textfiel4 = ""


        If Not (in_cmp_code Is Nothing) And (Trim(in_cmp_code) <> "") Then
            strSql = "  Select  Top 1 upper(ltrim(rtrim(isnull(CM.textfield4,'')))) as sam from CiCmpy CM " &
                " WHERE      LTrim(RTrim(ISNULL(CM.Cmp_code, ''))) = '" & m_Customer.cmp_code & "'"
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                Get_SAM_Textfiel4 = dt.Rows(0).Item("sam").ToString
            End If
        End If

        Return Get_SAM_Textfiel4

    End Function
End Class

