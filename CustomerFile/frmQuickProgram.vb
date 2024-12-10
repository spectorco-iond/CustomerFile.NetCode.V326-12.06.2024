Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Globalization
Imports System.ComponentModel

Public Class frmQuickProgram

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer
    Private m_Program As cMdb_Cus_Prog
    Private m_Program_BUS As New cMdb_Cus_Prog_BUS()
    Private m_Rev_BUS As New cMdb_Cus_Prog_Rev_BLL()
    Private m_Item_BUS As New cMdb_Cus_Prog_Item_List_BUS()

    Private db As New cDBA()
    Private dtItems As DataTable
    Private dtOptions As DataTable
    Private dtSetUps As DataTable

    Private m_DateButton As Button

    Private blnForceFocus As Boolean = False
    Private m_DirtyLine As Boolean

    Private m_Program_Type As String = String.Empty

    Delegate Sub SetColumnIndex(ByVal i As Integer)
    Delegate Sub ProductLineInsertDelegate(ByVal pstrItem_Cd As String)

    Private m_Saved As Boolean = True
    Private m_blnCannotAutoApprove As Boolean
    '++ID 9.1.15variable for index comes from  dgvItems_MouseMove rowindex
    Private intRowIndexMouseMove As Int32
    'Dim ofrmQuote_Comments As frmQuote_Comments
    Public pOutlook As New cOutlookApp


#Region "PUBLIC CONSTRUCTORS ##################################################"

    Public Sub New(ByRef pCustomer As cCustomer, ByVal pstrProgram_Type As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Program_Type = pstrProgram_Type

        Call Insert()

    End Sub

    ' When opening a program, it will use this signature
    Public Sub New(ByRef pCustomer As cCustomer, ByRef pProgram As cMdb_Cus_Prog)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'chkAllGroup.Checked = True
        m_Customer = pCustomer
        m_Program = pProgram

        'ofrmQuote_Comments = New frmQuote_Comments(m_Customer, m_Program)

        'Ion put in comment, because it doesn't display the grid 17.10.14, it call / ofrm.Program_Type = "Special Pricing" / in Load function
        '  Call Insert()
    End Sub

    'Public Sub New(ByRef pCustomer As cCustomer, ByRef pProgram As cMdb_Cus_Prog, ByVal pEditMode As Integer)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    '    m_Customer = pCustomer
    '    m_Program = pProgram

    '    Select Case pEditMode
    '        Case EditMode.Insert
    '            Call Insert()
    '        Case EditMode.Delete
    '            Call Delete()
    '        Case EditMode.Update
    '            'Call Load()
    '        Case EditMode.View

    '    End Select

    'End Sub

#End Region
#Region "Private DateTimePicker control functions #########################"

    ' Date buttons click - open DateControl for element
    Private Sub Element_DateButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart_Dt.Click, cmdEnd_Dt.Click

        If m_Program_Type = "Quote" And m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer Then Exit Sub

        Try
            m_DateButton = New Button
            m_DateButton = DirectCast(sender, Button)

            If m_DateButton.Name = "cmdApproved_Dt" And blnForceFocus Then Exit Sub

            mcCalendar.Top = m_DateButton.Top
            mcCalendar.Left = m_DateButton.Left
            mcCalendar.Visible = True
            mcCalendar.SetDate(Date.Now)

            Select Case m_DateButton.Name
                Case "cmdStart_Dt"
                    If IsDate(txtStart_Dt.Text) Then mcCalendar.SetDate(txtStart_Dt.Text)

                Case "cmdEnd_Dt"
                    If IsDate(txtEnd_Dt.Text) Then mcCalendar.SetDate(txtEnd_Dt.Text)
                    'Case "cmdDecision_Dt"
                    '    If IsDate(txtDecision_Dt.Text) Then mcCalendar.SetDate(txtDecision_Dt.Text)
                    'Case "cmdApproved_Dt"
                    '    If IsDate(txtApproved_Dt.Text) Then mcCalendar.SetDate(txtApproved_Dt.Text)

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
                    'Case "txtDecision_Dt"
                    '    GetDateControlByControlName = cmdDecision_Dt
                    'Case "txtApproved_Dt"
                    '    GetDateControlByControlName = cmdApproved_Dt

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
                    'Case "cmdDecision_Dt"
                    '    txtDecision_Dt.Text = mcCalendar.SelectionRange.Start
                    '    txtDecision_Dt.Focus()
                    'Case "cmdApproved_Dt"
                    '    txtApproved_Dt.Text = mcCalendar.SelectionRange.Start
                    '    txtApproved_Dt.Focus()

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

    Private Sub mcCalendar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mcCalendar.MouseLeave
        Try

            mcCalendar.Visible = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


#End Region


#Region "PRIVATE EVENTS - FORM ################################################"

    Private Sub frmQuickProgram_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        If Not m_Saved Then

            Dim intDocId As Int32
            Dim oExact As cEXACT_TRAVELER_DOCUMENT

            Dim oMsgBox As New MsgBoxResult
            oMsgBox = MsgBox("Your " & m_Program_Type & " is not saved. Do you want to leave anyway ?", MsgBoxStyle.YesNoCancel)
            If Not (oMsgBox = MsgBoxResult.Yes) Then

                e.Cancel = True

            Else
                '++ID
                Dim strSql As String
                Dim dt As DataTable

                If m_Program_Type = "Quote" Then
                    For Each row As DataGridViewRow In dgvItems.Rows

                        If Trim(row.Cells(Items.DocId).Value.ToString) = "" Then
                            Debug.Print("row.Cells(Items.DocId).Equals(DBNull.Value)= '' ")
                        Else
                            intDocId = row.Cells(Items.DocId).Value

                            Select Case intDocId
                                Case 0
                                    Debug.Print("Case  intDocId = '0' ")
                                Case Is > 0

                                    strSql =
                                        " SELECT * FROM  MDB_CUS_PROG_ITEM_LIST ML INNER JOIN " &
                                        " EXACT_TRAVELER_DOCUMENT ED ON ML.DocId = ED.DocID " &
                                        " WHERE ED.DocID = " & row.Cells(Items.DocId).Value

                                    dt = db.DataTable(strSql)

                                    If dt.Rows.Count = 0 Then
                                        oExact = New cEXACT_TRAVELER_DOCUMENT(intDocId)

                                        oExact.Delete()
                                    End If
                            End Select

                        End If
                    Next
                End If 'If m_Program_Type = "Quote"

            End If
        End If

    End Sub

    Private Sub frmPrograms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try
            '++ID12092024 new Test modifcation new updated and new version
            'lines added for to keep version for Git Hub
            MsgBox(" Test for Git Hub. Try  to display the message box as was added . ")

            AddHandler bw.DoWork, AddressOf bw_DoWork
            AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

            'justin190501
            AddHandler bwf.DoWork, AddressOf bwf_DoWork
            AddHandler bwf.RunWorkerCompleted, AddressOf bwf_RunWorkerCompleted

            ChangePictureVisibility = AddressOf ChangeVisibility

            Dim tt = New ToolTip

            tt.SetToolTip(lblDecision_Dt, "Click for make one Outlook Appointment")

            'chkAllGroup.Checked = True
            Call SetPermissions()



            If m_Program Is Nothing Then
                '++ID 12.14.2017 changed old select for that
                m_Program = New cMdb_Cus_Prog()

                Select Case m_Program_Type
                    Case "Program"
                        m_Program.Prog_Type = CInt(Program_Types.Program) + 1 '1

                    Case "Special Pricing"
                        m_Program.Prog_Type = CInt(Program_Types.Special_Pricing) + 1 ' 2

                    Case "Quote"
                        m_Program.Prog_Type = CInt(Program_Types.Quote) + 1 '3

                End Select

                'old select
                'Select Case m_Program_Type
                '    Case Program_Types.Program.ToString
                '        m_Program.Prog_Type = 1
                '    Case "Special Pricing"
                '        m_Program.Prog_Type = 2
                '    Case "Quote"
                '        m_Program.Prog_Type = 3
                'End Select

                m_Program.Cus_No = m_Customer.cmp_code
                m_Program.Prog_CSR = Environment.UserName

            End If

            Select Case m_Program_Type

                Case "Program"

                    chkAllGroup.Visible = True

                    tsRenew.Visible = True
                    tsRenew.Text = tsRenew.Text & "-" & Date.Today.Year
                    '----------------------------------------------
                    '++ID 3.14.2018
                    'Display original program
                    Dim oCus_prog As cMdb_Cus_Prog = New cMdb_Cus_Prog
                    If m_Program.Renew_To_Cus_Prog_Id <> 0 Then
                        With lblRenewProgram
                            .Visible = True
                            m_Program_BUS.Init(oCus_prog)
                            oCus_prog = m_Program_BUS.Load(CInt(m_Program.Renew_To_Cus_Prog_Id))
                            .Text = "Was updated from : " & oCus_prog.Spector_Cd.ToString
                            .BackColor = Color.Red
                            .ForeColor = Color.White
                        End With
                    End If
                    '----------------------------------------------
                    '12.14.2017 "Program"
                    '++ID 12.14.2017 control for rea_to_send step -------------------------------------
                    If (m_Program.Quote_Step_ID = Quote_Step.Ready_To_Send Or m_Program.Quote_Step_ID = Quote_Step.Pricing_Approved) Then tsbExport.Visible = True

                    If (m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval) Then tsbMassInsert.Enabled = False
                    tsbNextStep.Visible = (m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval)
                    '  If m_Program.Spector_Cd <> "" Then tsbClientEmail.Visible = True
                    '----------------------------------------------------
                    '  If m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer Then dgvOptions.ReadOnly = True
                    '------------------------------------------------------------------------------------------
                    'tsbCreateRevision.Visible = True
                    lblProgram_No.Text = "Program No"
                    chkOne_Shot.Visible = False
                    '  tsbExport.Visible = True
                    '++ID 18.03.2015
                    '    tsbClientEmail.Visible = True
                    '-------------------------------

                    'tcOptions.Visible = True
                   ' tsbClientEmail.Visible = False
                    'lblProg_Type.Visible = True
                    'cboProg_Type.Visible = True

                Case "Special Pricing" '12.14.2017 "Special Pricing"

                    lblProgram_No.Text = "Spec Price No"
                    chkOne_Shot.Visible = True
                    tsbExport.Visible = False
                    '++ID 18.03.2015
                    '  tsbClientEmail.Visible = False
                    '------------------------------
                    tsbNextStep.Visible = False

                    tsbClientEmail.Visible = False
                    'dgvOptions.ReadOnly = True
                    'tcOptions.Visible = True
                    lblProg_Cd.Visible = False
                    txtProg_Cd.Visible = False
                    lblImprint.Visible = False
                    txtImprint.Visible = False
                    txtStart_Dt.Text = ""
                    txtEnd_Dt.Text = ""
                    lblProg_Comments.Text = "Reason:"

                Case "Quote" '12.14.2017 "Quote"

                    lblProgram_No.Text = "Quote No"
                    chkOne_Shot.Visible = False
                    If m_Program.Quote_Step_ID >= Quote_Step.Pricing_Approved Then tsbMassInsert.Enabled = False
                    If m_Program.Quote_Step_ID >= Quote_Step.Ready_To_Send Then tsbExport.Visible = True
                    '++ID 18.03.2015
                    ' If m_Program.Quote_Step_ID >= Quote_Step.Ready_To_Send Then tsbClientEmail.Visible = True

                    If m_Program.Spector_Cd <> "" Then tsbClientEmail.Visible = True
                    '----------------------------------------------------
                    If m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer Then dgvOptions.ReadOnly = True

                    'tsbCreateRevision.Visible = True
                    'tsbCreateRevision.Enabled = True

                    tsbNextStep.Visible = True
                    'tcOptions.Visible = True

                    'gbQuotes.Visible = True
                    cmdQuoteComments.Visible = True
                    txtProg_Comments.Visible = False
                    lblCommOrdClosed.Visible = True
                    txtCommentQuoteResult.Visible = True

                    Call QuoteResult()

            End Select

            Call cboContact_FillCombo()

            Call FillFields()

            Call dgvItems_CreateColumns()
            Call dgvItems_Fill()
            '---------------------------
            Call dgvItems_Format()

            If dgvItems.Rows.Count <> 0 Then

                If dgvItems.Rows(0).Cells(Items.ITEM_CD).Value <> String.Empty Then
                    Call ValidateColorList()
                End If

            End If
            '----------------------------

            '++ID 13.1.15
            If m_Program_Type = "Quote" Then
                Call cellDocIdPropr()
            End If

            '-----------------------------------------------

            '   Call SetVisibleFields()

            '-------------
            Call dgvCharges_Load()
            'Call dgvOptions_CreateColumns()
            'Call dgvOptions_Format()
            'Call dgvOptions_Fill()
            '-------------

            Call dgvSetUps_CreateColumns()
            Call dgvSetUps_Format()
            Call dgvSetUps_Fill()

            UcDocuments.SearchVisible = False

            Call UcDocuments.Load(m_Program)

            Call SetProgramCaptions()
            Call SetStatusBar()

            If m_Program_Type = "Quote" Then

                dgvItems.Columns(Items.PROD_CAT_ID).Visible = False
                dgvItems.Columns(Items.EQP_LEVEL).Visible = False
                dgvItems.Columns(Items.EQP_PCT).Visible = False

                Call SetQuoteCommentButton()

                'Dim a1 As System.Drawing.Color

                For Each oRow As DataGridViewRow In dgvItems.Rows
                    If oRow.Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value.ToString <> "" Then
                        oRow.Cells(Items.LINE_COMMENTS).Style.BackColor = QuoteCommentColor(m_Program.Cus_Prog_Guid, oRow.Cells("CUS_PROG_ITEM_LIST_GUID").Value.ToString)
                        'oRow.Cells(Items.LINE_COMMENTS).Style.BackColor = a1
                        'oRow.Cells(Items.CUS_PROG_ITEM_LIST_GUID).Style.BackColor = QuoteCommentColor(m_Program.Cus_Prog_Guid, oRow.Cells("CUS_PROG_ITEM_LIST_GUID").Value.ToString)
                    End If
                Next

            End If

            m_Saved = True

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub


#End Region


#Region "PRIVATE EVENTS - BUTTONS #############################################"



#End Region


#Region "PRIVATE EVENTS - TOOLSTRIP BUTTONS ###################################"

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        Try

            If Not ValidateSave() Then Exit Sub

            Call Menu_Save()

            'Call Save()

            If m_Program_Type = "Quote" Then


                Dim iErrorCount As Integer
                Dim procs() As Process = Process.GetProcessesByName("Outlook")
                If procs.Length < 1 Then Process.Start("OutLook.exe") 'MsgBox("Oulook is running")

                ' Obviously, each element in the procs() array will contain an outlook process

                'first appoint
                Call ListAttendees(m_Program.Spector_Cd & " - First appointment for the client no: " & txtCus_No.Text, txtDecision_Dt.Text, txtEndDecision_Dt.Text, m_Program.Spector_Cd, m_strBodyOutlook, m_strLocationOutlook, iErrorCount)

                'repeat after first followme
                Dim secDecision As Date = Convert.ToDateTime(txtDecision_Dt.Text)
                Dim secEndDecision As Date = Convert.ToDateTime(txtEndDecision_Dt.Text)

                'this is for calculate the days which should add
                Call FollowUp(secDecision)
                Call FollowUp(secEndDecision)

                'second appoint
                Call ListAttendees(m_Program.Spector_Cd & " - Second appointment for the client no: " & txtCus_No.Text, secDecision, secEndDecision, m_Program.Spector_Cd, m_strBodyOutlook, m_strLocationOutlook, iErrorCount)


                'If iErrorCount = 0 Then
                '    Call CreateAppointment(m_Program.Spector_Cd & " for client no: " & txtCus_No.Text, txtDecision_Dt.Text, txtEndDecision_Dt.Text, m_Program.Spector_Cd, m_strBodyOutlook, m_strLocationOutlook)
                'End If

            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    'superuser is people who has power for Approval the price.
    Private Function SuperuserIdentify() As Boolean
        SuperuserIdentify = False
        Try

            Dim db As New cDBA
            Dim dtUsers As DataTable

            Dim strSql As String =
           " SELECT     DISTINCT SCREEN_USER AS SCREEN_USER, USER_ORDER " _
         & " FROM       MDB_CFG_QUOTE_PROC_USER WITH (Nolock) " _
         & " where SCREEN_USER = '" & Environment.UserName & "'"

            dtUsers = db.DataTable(strSql)

            If dtUsers.Rows.Count <> 0 Then
                SuperuserIdentify = True
            End If

            Return SuperuserIdentify
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub tsbNextStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNextStep.Click

        Try

            'add always +1 because it was made from before with number 1,2,3
            'but with Enum it start 0,1,2
            If m_Program.Prog_Type = (Program_Types.Program + 1) And m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then

                Try

                    If SuperuserIdentify() <> False Then

                        'I think before I need validate if need approval is unchecked after that  if is true change strep and update cus_prog step

                        '----------------------------------------
                        Try

                            Dim oMdb_item_list As cMdb_Cus_Prog_Item_List
                            Dim item_list As List(Of cMdb_Cus_Prog_Item_List) = New List(Of cMdb_Cus_Prog_Item_List)

                            Dim strVar As String = ""
                            dgvItems.EndEdit()
                            For Each dgvR As DataGridViewRow In dgvItems.Rows

                                If dgvR.Cells(Items.NEED_APPROVAL).Value.ToString <> "" Then
                                    If dgvR.Cells(Items.NEED_APPROVAL).Value = True Then

                                        oMdb_item_list = New cMdb_Cus_Prog_Item_List

                                        If dgvR.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value IsNot Nothing Then oMdb_item_list.Cus_Prog_Item_List_Id = dgvR.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value

                                        If dgvR.Cells(Items.ITEM_CD).Value IsNot Nothing Then oMdb_item_list.Item_Cd = dgvR.Cells(Items.ITEM_CD).Value
                                        If dgvR.Cells(Items.ITEM_COLOR).Value IsNot Nothing Then oMdb_item_list.Item_Color = dgvR.Cells(Items.ITEM_COLOR).Value
                                        If dgvR.Cells(Items.EQP_PCT).Value IsNot Nothing Then oMdb_item_list.Eqp_Pct = dgvR.Cells(Items.EQP_PCT).Value

                                        item_list.Add(oMdb_item_list)
                                    End If
                                End If
                            Next

                            'exception if user want send approval price or not 
                            'user have option for select what he want
                            Dim oMdb_Cus_Prog_Item_List As New cMdb_Cus_Prog_Item_List_BUS
                            If item_list.Count <> 0 Then

                                For i As Integer = 0 To item_list.Count - 1

                                    oMdb_item_list = New cMdb_Cus_Prog_Item_List

                                    oMdb_Cus_Prog_Item_List = New cMdb_Cus_Prog_Item_List_BUS

                                    oMdb_item_list = oMdb_Cus_Prog_Item_List.Load(item_list.Item(i).Cus_Prog_Item_List_Id).Clone

                                    oMdb_item_list.Need_Approval = False
                                    oMdb_item_list.ApprovedBy = Environment.UserName
                                    oMdb_item_list.Approved_Date = DateNow.ToString
                                    oMdb_Cus_Prog_Item_List.Save(oMdb_item_list)

                                Next

                            End If

                        Catch ex As Exception
                            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        End Try
                        '----------------------------------------

                        'from 2 go to 3
                        Call ProcessToStep(m_Program.Quote_Step_ID + 1)

                    Else
                        MsgBox("User : " & Environment.UserName & " can't Approve.")
                    End If


                Catch er As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
                End Try

            ElseIf m_Program.Prog_Type = (Program_Types.Quote + 1) Then
                'And m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval

                'regular user cannot approve is in Pending_Pricing_Approval
                If m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then

                    If SuperuserIdentify() <> False Then
                        Call ProcessToNextStep()

                        Call Save()
                        m_Saved = True
                    Else
                        MsgBox("User : " & Environment.UserName & " can't Approve.")
                        Exit Sub
                    End If

                Else
                    'need add save function
                    Call ProcessToNextStep()

                    Call Save()
                End If

            End If


            'I need check why I need save ---
            '++ID 12.18.2017 put in comment
            'Call EndEdit()
            ''++ID added 02.05.2015
            'Call Menu_Save()
            ''---------------------
            'If Not ValidateSave() Then Exit Sub

            'Call Save()
            '--------------------------------




        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "PRIVATE EVENTS - DATAGRIDVIEW ########################################"


#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    '++ID 13.1.15
    Private Sub cellDocIdPropr()
        Try

            Dim intDocId As Int32

            For Each row As DataGridViewRow In dgvItems.Rows
                Dim bc As DataGridViewButtonCell = TryCast(dgvItems(Items.Image, row.Index), DataGridViewButtonCell)
                If Trim(row.Cells(Items.DocId).Value.ToString) = "" Then
                    row.Cells(Items.Image).ToolTipText = "No Image"
                    Debug.Print("dgvItems_CreateColumns() row.Cells(Items.DocId).Equals(DBNull.Value)= '' ")
                Else
                    intDocId = row.Cells(Items.DocId).Value

                    Select Case intDocId
                        Case 0
                            'row.Cells(Items.DocId).Style.ForeColor = Color.Transparent
                            'row.Cells(Items.DocId).Style.SelectionForeColor = Color.Transparent

                            row.Cells(Items.Image).ToolTipText = "No Image"
                            Debug.Print("dgvItems_CreateColumns() Case  intDocId = '0' ")
                        Case Is > 0

                            bc.FlatStyle = FlatStyle.Popup
                            bc.Style.BackColor = System.Drawing.Color.CornflowerBlue
                            bc.Style.ForeColor = System.Drawing.Color.White
                            bc.Style.SelectionBackColor = System.Drawing.Color.Ivory
                            bc.Style.SelectionForeColor = System.Drawing.Color.DarkBlue

                            'row.Cells(Items.DocId).Style.BackColor = Color.CornflowerBlue
                            'row.Cells(Items.DocId).Style.ForeColor = Color.Transparent
                            'row.Cells(Items.DocId).Style.SelectionForeColor = Color.Transparent
                            'row.Cells(Items.DocId).ToolTipText = "Image"
                    End Select

                End If
            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub GroupCust(ByRef chkGroup As CheckBox) 'Ion
        Try
            '++ID -----------------------------------------------------------------------
            Dim dtGroupCust As DataTable = Nothing
            Dim strSqlGrCust As String = ""
            Dim text As String = ""
            Dim strPlus As String
            Dim count As Int32

            If chkGroup.CheckState = 1 Then
                '  strPlus = " C.cus_note_3 = (SELECT cus_note_3 FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) " &
                '++ID 12062024 added 'Like' Operator
                strPlus = " ( C.cus_note_3 Like '%' + (SELECT Ltrim(Rtrim(cus_note_3)) As cus_note_3  FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) + '%' " &
                " or  C.cus_no = '" & m_Customer.cmp_code & "' )"
            Else
                strPlus = " C.cus_no = '" & m_Customer.cmp_code & "' "
            End If

            strSqlGrCust =
                " SELECT C.cus_no " &
                " FROM	ARCUSFIL_SQL C " &
                " LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " &
                "  WHERE " &
                strPlus &
                " ORDER BY	C.CUS_NO "

            dtGroupCust = db.DataTable(strSqlGrCust)

            For Each drGroupCust As DataRow In dtGroupCust.Rows
                count += 1
                text += "Count" & count & " dtGroupCust : " & drGroupCust.Item("cus_no").ToString() & vbCrLf

            Next drGroupCust

            Debug.Print(text.ToString)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function Menu_Save() As Boolean

        Menu_Save = False

        Dim StartTS As Date
        Dim EndTS As Date
        Try
            Call EndEdit()

            If Not ValidateSave() Then Exit Function


            If SuperuserIdentify() <> True Then

                Select Case Program_Type
                    Case "Program"
                        'function loop grid  for find if exist Items flagged need approval
                        If Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then
                            MsgBox("Prices are currently in the process of being entered and approved, you cannot save.")
                            Exit Function
                        End If
                        If ChangeStatusForPrograms() <> True Then
                            Exit Function
                        End If
                    Case "Special Pricing"

                End Select
            Else
                If ChangeStatusForPrograms() <> True Then
                    Exit Function
                End If
            End If


            StartTS = Date.Now
            Call Save()
            EndTS = Date.Now

            m_Saved = True

            Menu_Save = True

            Call SetProgramCaptions()

            '++ID new function for identify for programs

            Call SetStatusBar()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    '++ID 12.18.2017 function used in the case if need_approval is flagged ---------------
    Private Function ChangeStatusForPrograms() As Boolean
        ChangeStatusForPrograms = False
        Try
            Dim oMdb_item_list As cMdb_Cus_Prog_Item_List
            Dim item_list As List(Of cMdb_Cus_Prog_Item_List) = New List(Of cMdb_Cus_Prog_Item_List)
            Dim result As DialogResult
            Dim strVar As String = ""

            dgvItems.EndEdit()

            For Each dgvR As DataGridViewRow In dgvItems.Rows

                If dgvR.Cells(Items.NEED_APPROVAL).Value.ToString <> "" Then
                    If dgvR.Cells(Items.NEED_APPROVAL).Value = True Then

                        oMdb_item_list = New cMdb_Cus_Prog_Item_List

                        If dgvR.Cells(Items.ITEM_CD).Value IsNot Nothing Then oMdb_item_list.Item_Cd = dgvR.Cells(Items.ITEM_CD).Value
                        If dgvR.Cells(Items.ITEM_COLOR).Value IsNot Nothing Then oMdb_item_list.Item_Color = dgvR.Cells(Items.ITEM_COLOR).Value
                        If dgvR.Cells(Items.EQP_PCT).Value IsNot Nothing Then oMdb_item_list.Eqp_Pct = dgvR.Cells(Items.EQP_PCT).Value

                        item_list.Add(oMdb_item_list)
                    End If
                End If
            Next

            'exception if user want send approval price or not 
            'user have option for select what he want

            If item_list.Count <> 0 Then

                'message box wiht yes/no/cancel

                For Each item As cMdb_Cus_Prog_Item_List In item_list
                    strVar &= vbCrLf & "For item " & item.Item_Cd & "-" & item.Item_Color & " was added additional discount percent : " & item.Eqp_Pct & "% and need to be approved."
                Next

                result = MessageBox.Show("Your program will be locked for a limited time." & strVar, "Approval remember.", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    '++ID 12.18.2017 filter in Enum
                    Dim en As Program_Types = CType([Enum].Parse(GetType(Program_Types), Program.Quote_Type_ID), Program_Types)  'System.Enum.GetValues(GetType(Program.Quote_Type_ID + 1).

                    MessageBox.Show(en & "-" & Program.Spector_Cd & "was Not saved.")

                ElseIf result = DialogResult.No Then

                    Dim en1 As Program_Types = CType([Enum].Parse(GetType(Program_Types), Program.Quote_Type_ID), Program_Types)  'System.Enum.GetValues(GetType(Program.Quote_Type_ID + 1).

                    MessageBox.Show(en1 & "-" & Program.Spector_Cd & " was not saved.")

                    '  MessageBox.Show("No pressed")
                ElseIf result = DialogResult.Yes Then

                    Call ProcessToStep(Quote_Step.Pending_Pricing_Approval)
                    ChangeStatusForPrograms = True
                End If
            Else
                Call ProcessToStep(4)
                ChangeStatusForPrograms = True
            End If

            Return ChangeStatusForPrograms

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '----------------------------------------------------------------------------
    Private Sub SetProgramCaptions()

        Try

            Me.Text = m_Program_Type & " Maintenance"
            gbProgramHeader.Text = m_Program_Type
            lblProg_Cd.Text = m_Program_Type & " Name"

            Select Case Program_Type

                Case "Program"   '12.14.2017"Program"
                    '     If SuperuserIdentify() <> True Then
                    'If m_Program.Quote_Step_ID = Quote_Step.Saved_Quote And m_Program.Quote_Step_ID <= Quote_Step.Ready_To_Send Then
                    tsbNextStep.Text = m_Program_BUS.Get_Quote_Next_Step(m_Program.Quote_Step_ID)
                    '   End If
                    '  End If



                    Select Case m_Program.Quote_Step_ID
                        Case Quote_Step.Pending_Pricing_Approval
                            tsbNextStep.Visible = True
                            dgvOptions.ReadOnly = True
                            tsbMassInsert.Enabled = False
                            tsbExport.Visible = False
                        Case Quote_Step.Pricing_Approved, Quote_Step.Ready_To_Send, Quote_Step.Saved_Quote
                            tsbExport.Visible = True
                            tsbNextStep.Visible = False
                            tsbMassInsert.Enabled = True
                        Case Else

                            tsbNextStep.Visible = False
                            tsbMassInsert.Enabled = True
                    End Select

                Case "Special Pricing" '12.14.2017 "Special Pricing"

                    lblProg_Cd.Text = "Price Name"
                    '++ID 12.19.2017
                    tsbNextStep.Visible = False

                Case "Quote" '12.14.2017 "Quote"
                    Me.Text &= " [" & m_Program_BUS.Get_Quote_Step(m_Program.Quote_Step_ID) & "]"

                    If m_Program.Quote_Step_ID >= Quote_Step.Saved_Quote And m_Program.Quote_Step_ID <= Quote_Step.Ready_To_Send Then
                        tsbNextStep.Text = m_Program_BUS.Get_Quote_Next_Step(m_Program.Quote_Step_ID)
                    End If

                    tsbNextStep.Visible = (m_Program.Quote_Step_ID >= Quote_Step.Saved_Quote And m_Program.Quote_Step_ID < Quote_Step.Pricing_Approved)
                    tsbExport.Visible = (m_Program.Quote_Step_ID >= Quote_Step.Pricing_Approved)
                    '++ID 18.03.2015
                    '   tsbClientEmail.Visible = (m_Program.Quote_Step_ID >= Quote_Step.Pricing_Approved)
                    '------------------------------
                    tsbMassInsert.Enabled = (m_Program.Quote_Step_ID < Quote_Step.Pricing_Approved)
                    dgvOptions.ReadOnly = True '(m_Program.Quote_Step_ID >= Quote_Step.Ready_To_Send)
                    'chkSent_To_Customer.Visible = m_Program.Quote_Step_ID >= Quote_Step.Ready_To_Send
                    tsbCreateRevision.Visible = (m_Program.Quote_Step_ID >= Quote_Step.Pending_Pricing_Approval)

                    If m_Program.Spector_Cd <> "" Then tsbClientEmail.Visible = True

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Sub Insert()
        Try
            m_Program = New cMdb_Cus_Prog()
            Select Case m_Program_Type
                Case "Program"
                    m_Program.Prog_Type = CInt(Program_Types.Program) + 1 '1
                Case "Special Pricing"
                    m_Program.Prog_Type = CInt(Program_Types.Special_Pricing) + 1 '2
                Case "Quote"
                    m_Program.Prog_Type = CInt(Program_Types.Quote) + 1 '3
                    m_Program_BUS.SetDefaultQuoteComments(m_Customer, m_Program)
            End Select
            m_Program.Cus_No = m_Customer.cmp_code
            m_Program.Prog_CSR = Environment.UserName

            'espace pour charge la  txtDecision
            If m_Program_Type = "Quote" Then
                txtDecision_Dt.Text = FollowMe(Date.Now, "9:00:00 AM")
                txtEndDecision_Dt.Text = FollowMe(Date.Now, "5:00:00 PM")
            End If
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Sub Save()
        Try
            'Dim oBUS As New cMdb_Cus_Prog_BUS()
            gbSaveProgress.Visible = True
            gbSaveProgress.Refresh()

            If m_Program Is Nothing Then m_Program = New cMdb_Cus_Prog()
            If m_Program.Cus_Prog_Id <> 0 Then m_Program = m_Program_BUS.Load(m_Program.Cus_Prog_Id)

            If m_Program Is Nothing Then
                m_Program = New cMdb_Cus_Prog()
                m_Program_BUS.Init(m_Program)
            End If

            Select Case m_Program_Type
                Case "Program"
                    m_Program.Prog_Type = CInt(Program_Types.Program) + 1'1
                Case "Special Pricing"
                    m_Program.Prog_Type = CInt(Program_Types.Special_Pricing) + 1' 2
                Case "Quote"
                    m_Program.Prog_Type = CInt(Program_Types.Quote) + 1 '3
            End Select

            If txtSpector_Cd.Text = String.Empty Then
                '    If IsDate(txtEnd_Dt.Text) Then
                m_Program.Spector_Cd = m_Program_BUS.Get_Next_Spector_Cd(m_Program)
            End If

            'm_Program.Current_Rev_No = 0

            m_Program.Cus_No = txtCus_No.Text
            'm_Program.Spector_Cd = txtSpector_Cd.Text

            m_Program.Prog_Cd = txtProg_Cd.Text
            m_Program.Revision.Program = m_Program.Prog_Cd

            If IsDate(txtStart_Dt.Text) Then
                m_Program.Start_Dt = txtStart_Dt.Text ' txtShipDate
                m_Program.Revision.Start_Dt = txtStart_Dt.Text ' txtShipDate
            Else
                m_Program.Start_Dt = Nothing ' NoDate()
                m_Program.Revision.Start_Dt = Nothing ' txtShipDate
            End If

            If IsDate(txtEnd_Dt.Text) Then
                m_Program.End_Dt = txtEnd_Dt.Text ' txtShipDate
                m_Program.Revision.End_Dt = txtEnd_Dt.Text ' txtShipDate
            Else
                m_Program.End_Dt = Nothing ' NoDate()
                m_Program.Revision.End_Dt = Nothing ' NoDate()
            End If

            m_Program.Imprint = txtImprint.Text
            m_Program.Revision.Imprint = txtImprint.Text

            m_Program.Contact_ID = cboContact_ID.SelectedValue
            m_Program.Revision.Cicntp_ID = cboContact_ID.SelectedValue

            m_Program.Prog_Comments = txtProg_Comments.Text

            '++ID 16.3.2015

            If m_Program_Type = "Quote" Then
                m_Program.Quote_Status = cboStatusQuote.Text
                m_Program.Quote_Result = cboQuoteResult.Text

                m_Program.Decision_Dt = txtDecision_Dt.Text 'm_DecisionDt 'txtDecision_Dt.Text

                If txtCommentQuoteResult.Visible = True Then
                    '   m_Program.Prog_Comments = lblCommOrdClosed.Text & " : " & txtCommentQuoteResult.Text
                    m_Program.Prog_Comments = txtCommentQuoteResult.Text
                Else
                    m_Program.Prog_Comments = String.Empty
                End If
                '++ID  7.28.2018
                m_Program.Note = Trim(txtNote.Text)

            End If

            '------------------------------------------

            'm_Program.Prog_CSR = txtProg_CSR.Text
            m_Program.Revision.Prog_CSR = m_Program.Prog_CSR ' txtProg_CSR.Text
            m_Program.For_All_Accounts = chkAllGroup.Checked

            'm_Program.User_Login = GetNTUserID()
            'm_Program.Update_Ts = Date.Now

            'If chkSent_To_Customer.Checked Then m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer

            Dim blnOK As Boolean
            blnOK = m_Program_BUS.Save(m_Program)

            If blnOK Then blnOK = m_Rev_BUS.Save(m_Program.Revision)

            If blnOK Then

                Call SaveLines()

                If tcOptions.Visible Then
                    '++ID 12.08.2015 put in comment
                    '  Call SaveOptions()
                    Call SaveSetUps()
                End If

                If m_Program_Type = "Quote" Then

                    Call SaveOrder()
                End If

                If txtSpector_Cd.Text = String.Empty Then
                    txtSpector_Cd.Text = m_Program.Spector_Cd
                    txtCurrent_Rev_No.Text = "0"
                End If

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            gbSaveProgress.Visible = False
        End Try

    End Sub

    Private Sub SaveLines()

        Try

            For Each dgvRow As DataGridViewRow In dgvItems.Rows
                dgvRow.Cells(Items.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
            Next

            ' First pass, we only save lines
            For Each dgvRow As DataGridViewRow In dgvItems.Rows

                'If dgvRow.Cells(Items.ITEM_CD).Value = "DEL" Then
                If dgvRow.Visible = True Then

                    If Not dgvRow.Cells(Items.ITEM_CD).Value.Equals(DBNull.Value) Then

                        If dgvRow.Cells(Items.ITEM_CD).Value <> "" Then

                            Dim oItem As New cMdb_Cus_Prog_Item_List()

                            If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then
                                oItem = m_Item_BUS.Load(CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
                            End If

                            '   oItem.Cus_Prog_Id = dgvRow.Cells(Items.CUS_PROG_ID).Value
                            If m_Program_Type <> "Quote" Then
                                oItem.Prod_Cat_ID = If(dgvRow.Cells(Items.PROD_CAT_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.PROD_CAT_ID).Value)
                            End If

                            oItem.Cus_Prog_Id = m_Program.Cus_Prog_Id
                            oItem.Item_Cd = dgvRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper
                            oItem.Item_No = If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value)
                            oItem.Item_Desc = If(dgvRow.Cells(Items.ITEM_DESC).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_DESC).Value)
                            oItem.Item_Color = If(dgvRow.Cells(Items.ITEM_COLOR).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_COLOR).Value)
                            oItem.Unit_Price = If(dgvRow.Cells(Items.UNIT_PRICE).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.UNIT_PRICE).Value)

                            '  Debug.Print("Item_Cd  " & oItem.Item_Cd & ", Price " & oItem.Unit_Price)
                            oItem.Eqp_Level = If(dgvRow.Cells(Items.EQP_LEVEL).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.EQP_LEVEL).Value)
                            Debug.Print(" EQP_Level " & oItem.Eqp_Level & ", Item_Cd  " & oItem.Item_Cd & ", Price " & oItem.Unit_Price)
                            oItem.Eqp_Pct = If(dgvRow.Cells(Items.EQP_PCT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.EQP_PCT).Value) ' dgvRow.Cells(Items.EQP_PCT).Value
                            oItem.Min_Qty_Ord = If(dgvRow.Cells(Items.MIN_QTY_ORD).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.MIN_QTY_ORD).Value)
                            oItem.Setup_Waived = If(dgvRow.Cells(Items.SETUP_WAIVED).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.SETUP_WAIVED).Value)
                            oItem.Setup_Price = If(dgvRow.Cells(Items.SETUP_PRICE).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.SETUP_PRICE).Value)

                            oItem.Quote_Ship_Method_ID = 0
                            oItem.Quote_Type_ID = 0

                            oItem.ChargeId = If(dgvRow.Cells(Items.CHARGE_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.CHARGE_ID).Value)
                            If Not (dgvRow.Cells(Items.RUN_CHARGE).Value.Equals(DBNull.Value)) Then
                                oItem.Run_Charge = dgvRow.Cells(Items.RUN_CHARGE).Value
                            Else
                                oItem.Run_Charge = -1
                            End If

                            'oItem.Dec_Met_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)
                            'oItem.Dec_Met_Group_ID = If(dgvRow.Cells(Items.DEC_MET_GROUP_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_GROUP_ID).Value)

                            oItem.Dec_Met_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)
                            oItem.Dec_Met_Group_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)

                            oItem.Color_Count = If(dgvRow.Cells(Items.COLOR_COUNT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.COLOR_COUNT).Value)
                            oItem.Location_Count = If(dgvRow.Cells(Items.LOCATION_COUNT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.LOCATION_COUNT).Value)
                            oItem.Pack_ID = If(dgvRow.Cells(Items.PACK_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.PACK_ID).Value)

                            oItem.Quote_Type_ID = If(dgvRow.Cells(Items.QUOTE_TYPE_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.QUOTE_TYPE_ID).Value)
                            oItem.Quote_Ship_Method_ID = If(dgvRow.Cells(Items.QUOTE_SHIP_METHOD_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.QUOTE_SHIP_METHOD_ID).Value)
                            '++ID 12.1.15
                            oItem.DocID = If(dgvRow.Cells(Items.DocId).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DocId).Value)

                            oItem.Need_Approval = If(dgvRow.Cells(Items.NEED_APPROVAL).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.NEED_APPROVAL).Value)

                            '++ -------------------
                            oItem.Overseas = (oItem.Quote_Type_ID = Quote_Type.Overseas)
                            Dim oComment As New cMdb_Prog_Comment(m_Program.Cus_Prog_Guid, oItem.Cus_Prog_Item_List_Guid, 4) '---

                            If oComment.Prog_Comment_Id <> 0 And Not oItem.Overseas Then
                                oComment.Delete()
                            Else
                                If oItem.Overseas Then
                                    oComment.Item_Cd = oItem.Item_Cd
                                    oComment.Comment_Desc = "Factory Direct - Overseas Pricing"
                                    oComment.Save()
                                End If
                            End If

                            oItem.Domestic = (oItem.Quote_Type_ID = Quote_Type.Domestic)
                            'oItem.Domestic = If(dgvRow.Cells(Items.DOMESTIC).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DOMESTIC).Value)
                            oComment = New cMdb_Prog_Comment(m_Program.Cus_Prog_Guid, oItem.Cus_Prog_Item_List_Guid, 5) '---

                            If oComment.Prog_Comment_Id <> 0 And Not oItem.Domestic Then
                                oComment.Delete()
                            Else
                                If oItem.Overseas Then
                                    oComment.Item_Cd = oItem.Item_Cd
                                    oComment.Comment_Desc = "Domestic Pricing"
                                    oComment.Save()
                                End If
                            End If

                            oItem.Cus_Prog_Item_List_Guid = If(dgvRow.Cells("CUS_PROG_ITEM_LIST_GUID").Value.Equals(DBNull.Value), 0, dgvRow.Cells("CUS_PROG_ITEM_LIST_GUID").Value)

                            oItem.Item_comment_logo = If(dgvRow.Cells("ITEM_COMMENT_LOGO").Value.Equals(DBNull.Value), "", dgvRow.Cells("ITEM_COMMENT_LOGO").Value)

                            Dim oSaveResult As Boolean = m_Item_BUS.Save(oItem)

                            dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value = oItem.Cus_Prog_Item_List_Id
                            dgvRow.Cells(Items.USER_LOGIN).Value = oItem.User_Login
                            dgvRow.Cells(Items.DIRTY).Value = String.Empty

                        End If

                    End If

                End If

            Next

            ' Second pass, we only delete lines.
            For Each dgvRow As DataGridViewRow In dgvItems.Rows

                'If dgvRow.Cells(Items.ITEM_CD).Value = "DEL" Then
                If dgvRow.Visible = False Then

                    If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then

                        If CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value) <> 0 Then
                            'Dim orep As Boolean
                            ' delete price line from macola file, then delete line
                            m_Item_BUS.Delete(CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
                            m_Item_BUS.DeleteMacolaProgramPricing(dgvRow.Cells(Items.ITEM_CD).Value, m_Program.Cus_Prog_Id)
                        End If

                    End If

                End If

            Next

            ' Third pass, once everything is saved and deleted, update Macola prices for remaining items.
            ' This is a 2 way process, first we do everything that is ALL, then we do everything by color.
            ' BE CAREFUL FOR HOLES: THERE IS A POSSIBILITY OF DATA INTERLACING HERE IF DATA IS ALL AND DATA IS OF COLOR.
            ' IN THESE CASES, WE MUST CONCATENATE THE PRICES AND WE GIVE PRIORITY TO THE ALL FACTOR. (WITH A UNION)
            ' THIS IS DONE ONLY FOR SPECIAL PRICING. PROGRAMS AND QUOTES DO NOT UPDATE MACOLA PRICES. 
            ' WE EVENTUALLY CAN DO IT BUT NEED TO ADVISE MACOLA FOR A SPECIAL PROCESS. IF THEY CAN USE OUR SP IT WILL BE POSSIBLE.

            If m_Program.One_Shot And Trim(m_Program.Ord_No <> String.Empty) Then Exit Sub

            If (m_Program_Type <> "Quote") Or (m_Program_Type = "Quote" And m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer) Then

                Dim dtItems As DataTable
                Dim dtItemColors As DataTable
                Dim dtItemDetails As DataTable

                Dim strSql As String = ""

                strSql =
                "SELECT DISTINCT " &
                "           IL.CUS_PROG_ITEM_LIST_ID, CASE WHEN ISNULL(IL.PROD_CAT_ID, 0) = 0 THEN IL.ITEM_CD ELSE IP.ITEM_CD END AS ITEM_CD, " &
                "           ISNULL(IL.PROD_CAT_ID, 0) AS PROD_CAT_ID, " &
                "           ISNULL(IL.EQP_LEVEL, 0) AS EQP_LEVEL " &
                "FROM       MDB_CUS_PROG_ITEM_LIST IL WITH (Nolock) " &
                "LEFT JOIN  MDB_ITEM_PROD_CAT_PREVIEW IP ON IL.PROD_CAT_ID = IP.PROD_CAT_ID " &
                "WHERE      IL.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " " &
                "ORDER BY   CASE WHEN ISNULL(IL.PROD_CAT_ID, 0) = 0 THEN IL.ITEM_CD ELSE IP.ITEM_CD END "

                dtItems = db.DataTable(strSql)

                pbSave_Item_No.Maximum = dtItems.Rows.Count

                Dim pbSave_Item_No_Pos As Integer = 0


                '++ID 12062024, lines to delete was moved , before it used to delete one by one but finally it delete all 
                'removed from loop for to delete in one shot
                'using to delete by prog_id for to add it again in new format
                Dim oItPrice As New cMacolaOeprcfil_Sql
                oItPrice.LoadByExtar_14(m_Program)
                '  oItPrice.DeleteAll(m_Customer.cmp_code)
                'just need to be deleted extra_14 -> cus_prog_id
                oItPrice.DeleteAll()


                For Each drItemRow As DataRow In dtItems.Rows

                    pbSave_Item_No_Pos += 1
                    lblSave_Item_No.Text = "Item : " & drItemRow.Item("Item_Cd").ToString
                    lblSave_Item_No.Refresh()

                    pbSave_Item_No.Value = pbSave_Item_No_Pos

                    strSql =
                    "SELECT ITEM_CD, ITEM_NO, COLOR_LIST " &
                    "FROM MDB_ITEM_DETAIL WITH (Nolock) " &
                    "WHERE ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%'  " &
                    "ORDER BY COLOR_LIST "
                    '05/24/2016

                    strSql =
                        " SELECT user_def_fld_1 as ITEM_CD, ITEM_NO, user_def_fld_2 as COLOR_LIST  " &
                        " FROM imitmidx_sql WITH (Nolock) " &
                        " WHERE user_def_fld_1 = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%'  " &
                        " ORDER BY user_def_fld_2 "

                    '++ID 1.8.2018 
                    strSql =
                        " SELECT ITEM_CD, ITEM_NO, COLOR_LIST  " &
                        " FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                        " WHERE ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%' " &
                        " ORDER BY COLOR_LIST "

                    dtItemColors = db.DataTable(strSql)
                    Dim _cpt As Int32 = 0
                    For Each drItemColor As DataRow In dtItemColors.Rows

                        If drItemRow.Item("PROD_CAT_ID") <> 0 Then
                            strSql =
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           CUS_PROG_ITEM_LIST_ID = " & drItemRow.Item("CUS_PROG_ITEM_LIST_ID").ToString & " " &
                            "ORDER BY   MIN_QTY_ORD, UNIT_PRICE DESC "
                        Else
                            strSql =
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND " &
                            "           ITEM_COLOR = '" & drItemColor.Item("Color_List").ToString & "' " &
                            "UNION " &
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND " &
                            "           ITEM_COLOR = ' ALL' " &
                            "ORDER BY   MIN_QTY_ORD, UNIT_PRICE DESC "

                        End If


                        Dim iPos As Integer = 0

                        dtItemDetails = db.DataTable(strSql)
                        If dtItemDetails.Rows.Count <> 0 Then

                            'Ion -----------------------------------------------------------------------
                            Dim dtGroupCust As DataTable = Nothing
                            Dim strSqlGrCust As String = ""
                            Dim strPlus As String = ""
                            Dim text As String = ""

                            'put execution out of exception becasue was not work for all from account -------------------
                            '++id 04302024 added functin to delete if exist for other from group
                            'Dim oItPrice As New cMacolaOeprcfil_Sql
                            'oItPrice.LoadByExtar_14(m_Program)

                            ''  oItPrice.DeleteAll(m_Customer.cmp_code)
                            ''just need to be deleted extra_14 -> cus_prog_id
                            'oItPrice.DeleteAll()

                            '-------------------

                            If chkAllGroup.CheckState = CheckState.Checked Then
                                '++ID 12042024 replaced  (C.cus_note_3 = value VS (C.cus_note_3 Like value   
                                strPlus = " ( C.cus_note_3 Like '%' + (SELECT Ltrim(Rtrim(cus_note_3)) As cus_note_3  FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) + '%' " &
                                " or  C.cus_no = '" & m_Customer.cmp_code & "') and P.Currency = '" & m_Customer.Currency & "' and cmp_status = 'A' " ' ++ID 04302024 added filter by currency, status

                            Else
                                ' ++id 04302024 added functin to delete if exist for other from group
                                'Dim oItPrice As New cMacolaOeprcfil_Sql
                                'oItPrice.LoadByExtar_14(m_Program)
                                'oItPrice.DeleteAll(m_Customer.cmp_code)
                                ''just need to be deleted extra_14 -> cus_prog_id
                                'oItPrice.DeleteAll()

                                strPlus = " C.cus_no = '" & m_Customer.cmp_code & "' "
                            End If

                            strSqlGrCust =
                                " SELECT C.cus_no " &
                                " FROM	ARCUSFIL_SQL C " &
                                " LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " &
                                "  WHERE " &
                                strPlus &
                                " ORDER BY	C.CUS_NO "

                            dtGroupCust = db.DataTable(strSqlGrCust)

                            Dim cname As String = ""


                            If dtGroupCust.Rows.Count <> 0 Then

                                For Each drGroupCust As DataRow In dtGroupCust.Rows

                                    cname = ""
                                    lblSave_Cus_No.Text = "Customer : " & drGroupCust.Item("Cus_No").ToString
                                    cname = drGroupCust.Item("Cus_No").ToString

                                    'text += " dtGroupCust : " & drGroupCust.Item("cus_no").ToString() & vbCrLf

                                    'Ion ------------------------------------------------------------------------

                                    Dim oItemPrice As New cMacolaOeprcfil_Sql

                                    oItemPrice.Loadpricing(drItemColor.Item("Item_No").ToString, m_Program, cname)

                                    If m_Program.Prog_Type = 2 And Not m_Program.One_Shot Then
                                        oItemPrice.Cd_Tp = 1
                                    Else
                                        oItemPrice.Cd_Tp = 9
                                    End If

                                    '- Before
                                    ' oItemPrice.Cus_No = m_Program.Cus_No
                                    'Ion ------------------------------------------------------------
                                    '- Now this place is for each person of group , result of (for each expresion)
                                    oItemPrice.Cus_No = drGroupCust.Item("cus_no").ToString()
                                    'Ion-------------------------------------------------------------

                                    oItemPrice.Curr_Cd = m_Customer.Currency
                                    oItemPrice.Item_No = drItemColor.Item("Item_No").ToString
                                    oItemPrice.Start_Dt = m_Program.Revision.Start_Dt
                                    oItemPrice.End_Dt = m_Program.Revision.End_Dt
                                    oItemPrice.Cus_Prog_Id = m_Program.Cus_Prog_Id
                                    oItemPrice.Cd_Prc_Basis = "P"
                                    oItemPrice.Prod_Cat = m_Program.Spector_Cd.Substring(0, 3)
                                    oItemPrice.Cd_Tp_3_Cust_Type = m_Program.Cus_Prog_Id.ToString.Trim.PadLeft(10, "0").Substring(5, 5)
                                    Debug.Print(oItemPrice.Id)

                                    '++ID 05012024 brought to initialise parameter iPos, if not will mix the data.
                                    iPos = 0

                                    For Each drItemDetail As DataRow In dtItemDetails.Rows

                                        lblSave_Line_No.Text = "Line : " & iPos.ToString & "/" & dtItemDetails.Rows.Count.ToString

                                        iPos += 1
                                        If iPos > 10 Then iPos = 10

                                        oItemPrice.Set_Minimum_Qty(iPos, drItemDetail.Item("MIN_QTY_ORD"))

                                        '++ID 15.05.2015 I put in comment because 
                                        'before EQP_Level checked the price most small
                                        'now we will use just for make the EQP_PCT enabled for added pourcentage
                                        'the price most small is added dependet of Program_Type
                                        '

                                        '      If drItemDetail.Item("EQP_LEVEL") = 0 Then

                                        oItemPrice.Set_Prc_Or_Disc(iPos, drItemDetail.Item("UNIT_PRICE"))

                                        '       Else

                                        'Dim dEqpPrice As Decimal
                                        'dEqpPrice = oItemPrice.Get_Eqp_Price()
                                        'If drItemDetail.Item("EQP_PCT") <> 0 Then
                                        '    dEqpPrice = (dEqpPrice - (dEqpPrice * drItemDetail.Item("EQP_PCT") / 100))
                                        'End If
                                        'oItemPrice.Set_Prc_Or_Disc(iPos, dEqpPrice)

                                        'End If

                                    Next (drItemDetail)
                                    'Exact_Custom_OeFlash_CustomerComments()
                                    If iPos >= 1 Then
                                        oItemPrice.Save()

                                    End If

                                    'Ion ----------------------------------------------------------------------------
                                Next drGroupCust

                                Debug.Print(text.ToString) 'customers codes read
                                'Ion ----------------------------------------------------------------------------
                            End If

                        End If

                    Next drItemColor

                Next drItemRow


                'Ion ----------------------------------------------------------------------------
                'Next drGroupCust

                'Debug.Print(text.ToString) 'customers codes read
                'Ion ----------------------------------------------------------------------------
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    '------------------ Renew Program Version ---------------------
    Private Sub RenewProgramVersion()
        Try
            'Dim oBUS As New cMdb_Cus_Prog_BUS()
            gbSaveProgress.Visible = True
            gbSaveProgress.Refresh()

            If m_Program.Cus_Prog_Id = 0 Then Exit Sub


            Dim intRenewCus_Prog_Id As Int32 = m_Program.Cus_Prog_Id


            'initialise main object likeis new program
            m_Program = New cMdb_Cus_Prog()

            'this exception I leave because it was before like in Save functioin
            If m_Program Is Nothing Then
                m_Program = New cMdb_Cus_Prog()
                m_Program_BUS.Init(m_Program)
            End If

            m_Program_BUS.Init(m_Program)




            Select Case m_Program_Type
                Case "Program"
                    m_Program.Prog_Type = CInt(Program_Types.Program) + 1 '1
                Case Else
                    Exit Sub
            End Select


            txtSpector_Cd.Text = String.Empty
            If txtSpector_Cd.Text = String.Empty Then
                m_Program.Spector_Cd = m_Program_BUS.Get_Next_Spector_Cd(m_Program)
            End If

            m_Program.Cus_Prog_Guid = Guid.NewGuid.ToString

            m_Program.Cus_No = txtCus_No.Text
            'm_Program.Spector_Cd = txtSpector_Cd.Text

            m_Program.Prog_Cd = txtProg_Cd.Text
            m_Program.Revision.Program = m_Program.Prog_Cd


            m_Program.Renew_To_Cus_Prog_Id = intRenewCus_Prog_Id


            '----------------------------------------------
            '++ID 3.14.2018
            'Display original program
            Dim oCus_prog As cMdb_Cus_Prog = New cMdb_Cus_Prog
            If intRenewCus_Prog_Id <> 0 Then
                With lblRenewProgram
                    .Visible = True
                    m_Program_BUS.Init(oCus_prog)
                    oCus_prog = m_Program_BUS.Load(CInt(m_Program.Renew_To_Cus_Prog_Id))
                    .Text = "Was updated from : " & oCus_prog.Spector_Cd.ToString
                    .BackColor = Color.Red
                    .ForeColor = Color.White
                End With
            End If
            '----------------------------------------------

            txtStart_Dt.Text = Now.Date
            m_Program.Start_Dt = txtStart_Dt.Text
            m_Program.Revision.Start_Dt = txtStart_Dt.Text


            txtEnd_Dt.Text = ProgramDate(Date.Today)
            m_Program.End_Dt = txtEnd_Dt.Text
            m_Program.Revision.End_Dt = txtEnd_Dt.Text

            m_Program.Imprint = txtImprint.Text
            m_Program.Revision.Imprint = txtImprint.Text

            m_Program.Contact_ID = cboContact_ID.SelectedValue
            m_Program.Revision.Cicntp_ID = cboContact_ID.SelectedValue

            m_Program.Prog_Comments = txtProg_Comments.Text

            m_Program.Prog_CSR = Environment.UserName
            m_Program.Revision.Prog_CSR = Environment.UserName 'm_Program.Prog_CSR ' txtProg_CSR.Text
            m_Program.For_All_Accounts = chkAllGroup.Checked

            m_Program.User_Login = Environment.UserName
            m_Program.Create_TS = Date.Now
            m_Program.Update_TS = Date.Now
            m_Program.Create_By = Environment.UserName
            'If chkSent_To_Customer.Checked Then m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer

            Dim blnOK As Boolean
            blnOK = m_Program_BUS.Save(m_Program)

            m_Program.Revision.Cus_Prog_Id = m_Program.Cus_Prog_Id

            If blnOK Then blnOK = m_Rev_BUS.Save(m_Program.Revision)

            If blnOK Then

                'Call SaveLines()
                Call SaveLinesRenewFunction()

                '  If tcOptions.Visible Then
                '++ID 12.08.2015 put in comment
                '  Call SaveOptions()
                '  Call SaveSetUps()
                'End If

                If txtSpector_Cd.Text = String.Empty Then
                    txtSpector_Cd.Text = m_Program.Spector_Cd
                    txtCurrent_Rev_No.Text = "0"
                End If

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            gbSaveProgress.Visible = False
        End Try

    End Sub
    '--------------------------------------------------------------
    Private Function prog_min_qty(ByVal _item_no As String, ByVal _curr As String) As Int32
        prog_min_qty = 0
        Try
            Dim dt As DataTable
            Dim strSql As String = ""
            Dim _minQty As Int32 = 0

            strSql =
        "  select  minimum_qty_1 ,item_no,cd_tp,curr_cd  from MWAV_DOMESTIC_PRICING " _
        & "where  cd_tp = 6  And minimum_qty_1 <> 0 And item_no = '" & Trim(_item_no) & "' and curr_cd = '" & Trim(_curr) & "' "

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                _minQty = CInt(dt.Rows(0).Item("minimum_qty_1"))
            End If
            Return _minQty

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub SaveLinesRenewFunction()

        Try
            Dim price As Decimal
            Dim oOeprcfil_sql As cMacolaOeprcfil_Sql

            For Each dgvRow As DataGridViewRow In dgvItems.Rows
                dgvRow.Cells(Items.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
                dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value = 0
            Next

            ' First pass, we only save lines
            For Each dgvRow As DataGridViewRow In dgvItems.Rows
                Dim _item_no As String = ""

                _item_no = If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value)

                If CheckDiscoProp(_item_no) = "" Then

                    'If dgvRow.Cells(Items.ITEM_CD).Value = "DEL" Then
                    If dgvRow.Visible = True Then

                        If Not dgvRow.Cells(Items.ITEM_CD).Value.Equals(DBNull.Value) Then

                            If dgvRow.Cells(Items.ITEM_CD).Value <> "" Then
                                oOeprcfil_sql = New cMacolaOeprcfil_Sql

                                price = 0.0

                                Dim oItem As New cMdb_Cus_Prog_Item_List()

                                'I don't need load existing object from database
                                'If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then
                                '    oItem = m_Item_BUS.Load(CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
                                'End If

                                oItem.Prod_Cat_ID = If(dgvRow.Cells(Items.PROD_CAT_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.PROD_CAT_ID).Value)


                                oItem.Cus_Prog_Id = m_Program.Cus_Prog_Id
                                oItem.Item_Cd = dgvRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper
                                oItem.Item_No = If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value)
                                oItem.Item_Desc = If(dgvRow.Cells(Items.ITEM_DESC).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_DESC).Value)

                                dgvRow.Cells(Items.ITEM_COLOR).Value = returnColorList(If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value))

                                oItem.Item_Color = If(dgvRow.Cells(Items.ITEM_COLOR).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_COLOR).Value)

                                oItem.Eqp_Level = If(dgvRow.Cells(Items.EQP_LEVEL).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.EQP_LEVEL).Value)

                                oItem.Eqp_Pct = If(dgvRow.Cells(Items.EQP_PCT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.EQP_PCT).Value) ' dgvRow.Cells(Items.EQP_PCT).Value

                                oItem.Min_Qty_Ord = prog_min_qty(oItem.Item_No, Trim(txtCurr_Cd.Text))

                                '-------------------- manage price ---------------
                                price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                                           dgvRow.Cells(Items.ITEM_CD).Value.ToString,
                                           Trim(dgvRow.Cells(Items.ITEM_COLOR).Value.ToString), oItem.Min_Qty_Ord,'dgvRow.Cells(Items.MIN_QTY_ORD).Value,
                                           m_Program_Type, dgvRow.Cells(Items.EQP_LEVEL).Value)

                                dgvRow.Cells(Items.MIN_QTY_ORD).Value = oItem.Min_Qty_Ord

                                If oItem.Eqp_Level <> 0 And oItem.Eqp_Pct > 0.00 Then

                                    price = price - ((price / 100) * dgvRow.Cells(Items.EQP_PCT).Value)
                                    oItem.Unit_Price = price 'If(dgvRow.Cells(Items.UNIT_PRICE).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.UNIT_PRICE).Value)
                                    dgvRow.Cells(Items.UNIT_PRICE).Value = price
                                Else
                                    oItem.Unit_Price = price 'If(dgvRow.Cells(Items.UNIT_PRICE).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.UNIT_PRICE).Value)
                                    dgvRow.Cells(Items.UNIT_PRICE).Value = price
                                End If
                                '------------------------------------------------
                                '  Debug.Print("Item_Cd  " & oItem.Item_Cd & ", price " & oItem.Unit_Price)

                                Debug.Print(" EQP_Level " & oItem.Eqp_Level & ", Item_Cd  " & oItem.Item_Cd & ", price " & oItem.Unit_Price)
                                'commented01.16.2023
                                '   oItem.Min_Qty_Ord = If(dgvRow.Cells(Items.MIN_QTY_ORD).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.MIN_QTY_ORD).Value)

                                '      oItem.Min_Qty_Ord = prog_min_qty(oItem.Item_No, Trim(txtCurr_Cd.Text))

                                oItem.Setup_Waived = If(dgvRow.Cells(Items.SETUP_WAIVED).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.SETUP_WAIVED).Value)
                                oItem.Setup_Price = If(dgvRow.Cells(Items.SETUP_PRICE).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.SETUP_PRICE).Value)

                                oItem.Quote_Ship_Method_ID = 0
                                oItem.Quote_Type_ID = 0

                                oItem.ChargeId = If(dgvRow.Cells(Items.CHARGE_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.CHARGE_ID).Value)
                                If Not (dgvRow.Cells(Items.RUN_CHARGE).Value.Equals(DBNull.Value)) Then
                                    oItem.Run_Charge = dgvRow.Cells(Items.RUN_CHARGE).Value
                                Else
                                    oItem.Run_Charge = -1
                                End If

                                'oItem.Dec_Met_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)
                                'oItem.Dec_Met_Group_ID = If(dgvRow.Cells(Items.DEC_MET_GROUP_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_GROUP_ID).Value)

                                oItem.Dec_Met_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)
                                oItem.Dec_Met_Group_ID = If(dgvRow.Cells(Items.DEC_MET_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DEC_MET_ID).Value)

                                oItem.Color_Count = If(dgvRow.Cells(Items.COLOR_COUNT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.COLOR_COUNT).Value)
                                oItem.Location_Count = If(dgvRow.Cells(Items.LOCATION_COUNT).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.LOCATION_COUNT).Value)
                                oItem.Pack_ID = If(dgvRow.Cells(Items.PACK_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.PACK_ID).Value)

                                oItem.Quote_Type_ID = If(dgvRow.Cells(Items.QUOTE_TYPE_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.QUOTE_TYPE_ID).Value)
                                oItem.Quote_Ship_Method_ID = If(dgvRow.Cells(Items.QUOTE_SHIP_METHOD_ID).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.QUOTE_SHIP_METHOD_ID).Value)
                                '++ID 12.1.15
                                oItem.DocID = If(dgvRow.Cells(Items.DocId).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DocId).Value)

                                oItem.Need_Approval = If(dgvRow.Cells(Items.NEED_APPROVAL).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.NEED_APPROVAL).Value)

                                '++ -------------------
                                oItem.Overseas = (oItem.Quote_Type_ID = Quote_Type.Overseas)


                                oItem.Domestic = (oItem.Quote_Type_ID = Quote_Type.Domestic)
                                'oItem.Domestic = If(dgvRow.Cells(Items.DOMESTIC).Value.Equals(DBNull.Value), 0, dgvRow.Cells(Items.DOMESTIC).Value)

                                oItem.Cus_Prog_Item_List_Guid = Guid.NewGuid().ToString

                                Dim oSaveResult As Boolean = m_Item_BUS.Save(oItem)

                                dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value = oItem.Cus_Prog_Item_List_Id
                                dgvRow.Cells(Items.USER_LOGIN).Value = oItem.User_Login
                                dgvRow.Cells(Items.DIRTY).Value = String.Empty

                            End If

                        End If

                    End If
                End If

            Next

            '  ' Second pass, we only delete lines.
            'For Each dgvRow As DataGridViewRow In dgvItems.Rows

            '    'If dgvRow.Cells(Items.ITEM_CD).Value = "DEL" Then
            '    If dgvRow.Visible = False Then

            '        If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then

            '            If CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value) <> 0 Then
            '                'Dim orep As Boolean
            '                ' delete price line from macola file, then delete line
            '                m_Item_BUS.Delete(CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
            '                m_Item_BUS.DeleteMacolaProgramPricing(dgvRow.Cells(Items.ITEM_CD).Value, m_Program.Cus_Prog_Id)
            '            End If

            '        End If

            '    End If

            'Next

            ' Third pass, once everything is saved and deleted, update Macola prices for remaining items.
            ' This is a 2 way process, first we do everything that is ALL, then we do everything by color.
            ' BE CAREFUL FOR HOLES: THERE IS A POSSIBILITY OF DATA INTERLACING HERE IF DATA IS ALL AND DATA IS OF COLOR.
            ' IN THESE CASES, WE MUST CONCATENATE THE PRICES AND WE GIVE PRIORITY TO THE ALL FACTOR. (WITH A UNION)
            ' THIS IS DONE ONLY FOR SPECIAL PRICING. PROGRAMS AND QUOTES DO NOT UPDATE MACOLA PRICES. 
            ' WE EVENTUALLY CAN DO IT BUT NEED TO ADVISE MACOLA FOR A SPECIAL PROCESS. IF THEY CAN USE OUR SP IT WILL BE POSSIBLE.

            If m_Program.One_Shot And Trim(m_Program.Ord_No <> String.Empty) Then Exit Sub

            If (m_Program_Type <> "Quote") Or (m_Program_Type = "Quote" And m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer) Then

                Dim dtItems As DataTable
                Dim dtItemColors As DataTable
                Dim dtItemDetails As DataTable

                Dim strSql As String = ""

                strSql =
                "Select DISTINCT " &
                "           IL.CUS_PROG_ITEM_LIST_ID, Case When ISNULL(IL.PROD_CAT_ID, 0) = 0 Then IL.ITEM_CD Else IP.ITEM_CD End As ITEM_CD, " &
                "           ISNULL(IL.PROD_CAT_ID, 0) As PROD_CAT_ID, " &
                "           ISNULL(IL.EQP_LEVEL, 0) As EQP_LEVEL " &
                "FROM       MDB_CUS_PROG_ITEM_LIST IL With (Nolock) " &
                "LEFT JOIN  MDB_ITEM_PROD_CAT_PREVIEW IP On IL.PROD_CAT_ID = IP.PROD_CAT_ID " &
                "WHERE      IL.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " " &
                "ORDER BY   Case When ISNULL(IL.PROD_CAT_ID, 0) = 0 Then IL.ITEM_CD Else IP.ITEM_CD End "

                dtItems = db.DataTable(strSql)

                pbSave_Item_No.Maximum = dtItems.Rows.Count
                Dim pbSave_Item_No_Pos As Integer = 0

                For Each drItemRow As DataRow In dtItems.Rows

                    pbSave_Item_No_Pos += 1
                    lblSave_Item_No.Text = "Item : " & drItemRow.Item("Item_Cd").ToString
                    lblSave_Item_No.Refresh()

                    pbSave_Item_No.Value = pbSave_Item_No_Pos

                    'strSql =
                    '"SELECT ITEM_CD, ITEM_NO, COLOR_LIST " &
                    '"FROM MDB_ITEM_DETAIL WITH (Nolock) " &
                    '"WHERE ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%'  " &
                    '"ORDER BY COLOR_LIST "
                    ''05/24/2016

                    'strSql =
                    '    " SELECT user_def_fld_1 as ITEM_CD, ITEM_NO, user_def_fld_2 as COLOR_LIST  " &
                    '    " FROM imitmidx_sql WITH (Nolock) " &
                    '    " WHERE user_def_fld_1 = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%'  " &
                    '    " ORDER BY user_def_fld_2 "

                    '++ID 1.8.2018 
                    strSql =
                        " SELECT ITEM_CD, ITEM_NO, COLOR_LIST  " &
                        " FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                        " WHERE ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND ITEM_NO NOT LIKE '%AST%' " &
                        " ORDER BY COLOR_LIST "

                    dtItemColors = db.DataTable(strSql)
                    For Each drItemColor As DataRow In dtItemColors.Rows

                        If drItemRow.Item("PROD_CAT_ID") <> 0 Then
                            strSql =
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           CUS_PROG_ITEM_LIST_ID = " & drItemRow.Item("CUS_PROG_ITEM_LIST_ID").ToString & " " &
                            "ORDER BY   MIN_QTY_ORD, UNIT_PRICE DESC "
                        Else
                            strSql =
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND " &
                            "           ITEM_COLOR = '" & drItemColor.Item("Color_List").ToString & "' " &
                            "UNION " &
                            "SELECT     ITEM_CD, ITEM_COLOR, ISNULL(MIN_QTY_ORD, 0) AS MIN_QTY_ORD, " &
                            "           ISNULL(UNIT_PRICE, 0) AS UNIT_PRICE, ISNULL(EQP_LEVEL, 0) AS EQP_LEVEL, " &
                            "           ISNULL(EQP_PCT, 0) AS EQP_PCT " &
                            "FROM       MDB_CUS_PROG_ITEM_LIST " &
                            "WHERE      CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " &
                            "           ITEM_CD = '" & drItemRow.Item("Item_Cd").ToString & "' AND " &
                            "           ITEM_COLOR = ' ALL' " &
                            "ORDER BY   MIN_QTY_ORD, UNIT_PRICE DESC "

                        End If


                        Dim iPos As Integer = 0

                        dtItemDetails = db.DataTable(strSql)
                        If dtItemDetails.Rows.Count <> 0 Then

                            'Ion -----------------------------------------------------------------------
                            Dim dtGroupCust As DataTable = Nothing
                            Dim strSqlGrCust As String = ""
                            Dim strPlus As String = ""
                            Dim text As String = ""
                            'Ion ------------------------------------------------------------------------

                            'Ion ---------------------------------------------------------------------------

                            If chkAllGroup.CheckState = CheckState.Checked Then
                                '  strPlus = " C.cus_note_3 = (SELECT cus_note_3 FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) " &
                                '++ID 12062024 commented above and below added 'LIKE' operator
                                strPlus = " ( C.cus_note_3 Like '%' + (SELECT Ltrim(Rtrim(cus_note_3)) As cus_note_3  FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) + '%' " &
                                " or  C.cus_no = '" & m_Customer.cmp_code & "' ) "
                            Else
                                strPlus = " C.cus_no = '" & m_Customer.cmp_code & "' "
                            End If

                            strSqlGrCust =
                                " SELECT C.cus_no " &
                                " FROM	ARCUSFIL_SQL C " &
                                " LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " &
                                "  WHERE " &
                                strPlus &
                                " ORDER BY	C.CUS_NO "

                            dtGroupCust = db.DataTable(strSqlGrCust)

                            For Each drGroupCust As DataRow In dtGroupCust.Rows

                                lblSave_Cus_No.Text = "Customer : " & drGroupCust.Item("Cus_No").ToString

                                'text += " dtGroupCust : " & drGroupCust.Item("cus_no").ToString() & vbCrLf

                                'Ion ------------------------------------------------------------------------

                                Dim oItemPrice As New cMacolaOeprcfil_Sql(drItemColor.Item("Item_No").ToString, m_Program)
                                If m_Program.Prog_Type = 2 And Not m_Program.One_Shot Then
                                    oItemPrice.Cd_Tp = 1
                                Else
                                    oItemPrice.Cd_Tp = 9
                                End If

                                '- Before
                                ' oItemPrice.Cus_No = m_Program.Cus_No
                                'Ion ------------------------------------------------------------
                                '- Now this place is for each person of group , result of (for each expresion)
                                oItemPrice.Cus_No = drGroupCust.Item("cus_no").ToString()
                                'Ion-------------------------------------------------------------

                                oItemPrice.Curr_Cd = m_Customer.Currency
                                oItemPrice.Item_No = drItemColor.Item("Item_No").ToString
                                oItemPrice.Start_Dt = m_Program.Revision.Start_Dt
                                oItemPrice.End_Dt = m_Program.Revision.End_Dt
                                oItemPrice.Cus_Prog_Id = m_Program.Cus_Prog_Id
                                oItemPrice.Cd_Prc_Basis = "P"
                                oItemPrice.Prod_Cat = m_Program.Spector_Cd.Substring(0, 3)
                                oItemPrice.Cd_Tp_3_Cust_Type = m_Program.Cus_Prog_Id.ToString.Trim.PadLeft(10, "0").Substring(5, 5)
                                Debug.Print(oItemPrice.Id)

                                For Each drItemDetail As DataRow In dtItemDetails.Rows

                                    lblSave_Line_No.Text = "Line : " & iPos.ToString & "/" & dtItemDetails.Rows.Count.ToString

                                    iPos += 1
                                    If iPos > 10 Then iPos = 10

                                    oItemPrice.Set_Minimum_Qty(iPos, drItemDetail.Item("MIN_QTY_ORD"))

                                    '++ID 15.05.2015 I put in comment because 
                                    'before EQP_Level checked the price most small
                                    'now we will use just for make the EQP_PCT enabled for added pourcentage
                                    'the price most small is added dependet of Program_Type
                                    '

                                    '      If drItemDetail.Item("EQP_LEVEL") = 0 Then

                                    oItemPrice.Set_Prc_Or_Disc(iPos, drItemDetail.Item("UNIT_PRICE"))

                                    '       Else

                                    'Dim dEqpPrice As Decimal
                                    'dEqpPrice = oItemPrice.Get_Eqp_Price()
                                    'If drItemDetail.Item("EQP_PCT") <> 0 Then
                                    '    dEqpPrice = (dEqpPrice - (dEqpPrice * drItemDetail.Item("EQP_PCT") / 100))
                                    'End If
                                    'oItemPrice.Set_Prc_Or_Disc(iPos, dEqpPrice)

                                    'End If

                                Next (drItemDetail)
                                'Exact_Custom_OeFlash_CustomerComments()
                                If iPos >= 1 Then
                                    oItemPrice.Save()
                                End If

                                'Ion ----------------------------------------------------------------------------
                            Next drGroupCust

                            Debug.Print(text.ToString) 'customers codes read
                            'Ion ----------------------------------------------------------------------------

                        End If

                    Next drItemColor

                Next drItemRow

                'Ion ----------------------------------------------------------------------------
                'Next drGroupCust

                'Debug.Print(text.ToString) 'customers codes read
                'Ion ----------------------------------------------------------------------------
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    '------------------- Return Color List with Item_No ----------------------------
    Private Function returnColorList(ByVal p_ItemNo As String) As String
        returnColorList = String.Empty
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim sql As String
            Dim color_list As String

            color_list = String.Empty

            If p_ItemNo = String.Empty Then

                Return "ALL"
                Exit Function
            End If


            sql = " Select Color_list from View_MDB_ITEM_DETAIL where ITEM_NO = '" & Trim(p_ItemNo) & "' "

            dt = db.DataTable(sql)

            If dt.Rows.Count <> 0 Then
                color_list = dt.Rows(0).Item("Color_List").ToString
            End If

            Return color_list
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function allColorList() As DataTable
        allColorList = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim sql As String

            sql = " select   'ALL' as Item_Color " _
                & " UNION " _
                & " select  'MULTI' as Item_Color  " _
                & " UNION " _
                & " Select Color_list as Item_Color from View_MDB_ITEM_DETAIL   " _
                & " order by Item_color "

            'removed Multi 3.29.2018
            sql = " select   'ALL' as Item_Color " _
                & " UNION " _
                & " Select Color_list as Item_Color from View_MDB_ITEM_DETAIL   " _
                & " order by Item_color "

            dt = db.DataTable(sql)

            If dt.Rows.Count <> 0 Then
                Return dt
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '-----------------------------------------------
    Private Function AllDecoMeth() As DataTable
        AllDecoMeth = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim sql As String

            sql = " select  '' as DEC_MET_ID ,Cast('' As varchar(50)) As DEC_MET_NAME  " _
                & " union " _
                & "select distinct l.DEC_MET_ID,d.DEC_MET_NAME   from MDB_ITEM_MASTER m inner join MDB_ITEM_IMP_LOC l on m.ITEM_MASTER_ID = l.ITEM_MASTER_ID  " _
                & " inner join MDB_CFG_DEC_MET d on l.DEC_MET_ID = d.DEC_MET_ID  " _
                & " where isnull(l.DEC_MET_ID,'') <> '' order by DEC_MET_ID "

            dt = db.DataTable(sql)

            If dt.Rows.Count <> 0 Then
                Return dt
            End If


        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    Private Sub SaveOptions()

        Try

            '++ID -----------------------------------------------------------------------
            Dim dtGroupCust As DataTable = Nothing
            Dim strSqlGrCust As String = ""
            Dim strPlus As String = ""
            Dim text As String = ""
            'Ion ------------------------------------------------------------------------

            '++ID ---------------------------------------------------------------------------

            If chkAllGroup.CheckState = CheckState.Checked Then
                '   strPlus = " C.cus_note_3 = (Select cus_note_3 FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) " &
                '++ID 12062024 commented above and below added criteria with 'Like' operator
                strPlus = " (  C.cus_note_3 Like '%' + (SELECT Ltrim(Rtrim(cus_note_3)) As cus_note_3  FROM ARCUSFIL_SQL WHERE cus_no = '" & m_Customer.cmp_code & "' ) + '%' " &
                " or  C.cus_no = '" & m_Customer.cmp_code & "' )"
            Else
                strPlus = " C.cus_no = '" & m_Customer.cmp_code & "' "
            End If

            strSqlGrCust =
                " SELECT C.cus_no " &
                " FROM	ARCUSFIL_SQL C " &
                " LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE " &
                "  WHERE " &
                strPlus &
                " ORDER BY	C.CUS_NO "

            dtGroupCust = db.DataTable(strSqlGrCust)

            For Each drGroupCust As DataRow In dtGroupCust.Rows

                text += " dtGroupCust : " & drGroupCust.Item("cus_no").ToString() & vbCrLf

                '++ID ------------------------------------------------------------------------


                For Each dgvRow As DataGridViewRow In dgvOptions.Rows
                    dgvRow.Cells(Options.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
                Next dgvRow

                For Each dgvRow As DataGridViewRow In dgvOptions.Rows

                    Dim oCharge As cMdb_Cfg_Charge_Usage = Nothing

                    If dgvRow.Cells(Options.CHARGE_USAGE_ID).Value = 0 Then

                        ' It would be a new row
                        If dgvRow.Cells(Options.ALWAYS_USE).Value <> 0 Or
                            dgvRow.Cells(Options.NEVER_USE).Value <> 0 Or
                            dgvRow.Cells(Options.NO_CHARGE).Value <> 0 Or
                            dgvRow.Cells(Options.UNIT_PRICE).Value <> 0 Then

                            oCharge = New cMdb_Cfg_Charge_Usage()


                            '- Before
                            '   oCharge.Cus_No = m_Customer.cmp_code
                            '++ID ------------------------------------------------------------
                            '- Now this place is for each person of group , result of (for each expresion)
                            oCharge.Cus_No = drGroupCust.Item("cus_no").ToString()
                            '++ID -------------------------------------------------------------

                            oCharge.Charge_Id = dgvRow.Cells(Options.CHARGE_ID).Value
                            oCharge.Charge_Cd = dgvRow.Cells(Options.CHARGE_CD).Value
                            oCharge.Cus_Prog_ID = m_Program.Cus_Prog_Id
                            oCharge.Always_Use = dgvRow.Cells(Options.ALWAYS_USE).Value
                            oCharge.Never_Use = dgvRow.Cells(Options.NEVER_USE).Value
                            oCharge.No_Charge = dgvRow.Cells(Options.NO_CHARGE).Value
                            oCharge.Unit_Price = dgvRow.Cells(Options.UNIT_PRICE).Value
                            oCharge.Charge_From = m_Program.Revision.Start_Dt
                            oCharge.Charge_To = m_Program.Revision.End_Dt

                            oCharge.Save()

                            dgvRow.Cells(Options.CHARGE_USAGE_ID).Value = oCharge.Charge_Usage_Id

                        End If

                    Else

                        ' It is already existing
                        oCharge = New cMdb_Cfg_Charge_Usage(dgvRow.Cells(Options.CHARGE_USAGE_ID).Value)

                        oCharge.Always_Use = dgvRow.Cells(Options.ALWAYS_USE).Value
                        oCharge.Never_Use = dgvRow.Cells(Options.NEVER_USE).Value
                        oCharge.No_Charge = dgvRow.Cells(Options.NO_CHARGE).Value
                        oCharge.Unit_Price = dgvRow.Cells(Options.UNIT_PRICE).Value
                        oCharge.Charge_From = m_Program.Revision.Start_Dt
                        oCharge.Charge_To = m_Program.Revision.End_Dt

                        oCharge.Save()

                    End If

                    If (m_Program_Type <> "Quote") Or (m_Program_Type = "Quote" And m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer) Then
                        ' Now change the values in Macola
                        If Not oCharge Is Nothing Then

                            If oCharge.Charge_Usage_Id <> 0 Then

                                oCharge.SaveChargeToMacola(m_Program, m_Customer)

                            End If

                        End If

                    End If

                Next

                'Ion ----------------------------------------------------------------------------
            Next drGroupCust

            Debug.Print(text.ToString) 'customers codes read
            'Ion ----------------------------------------------------------------------------

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveSetUps()

        Try

            For Each dgvRow As DataGridViewRow In dgvSetUps.Rows
                dgvRow.Cells(Options.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
            Next

            For Each dgvRow As DataGridViewRow In dgvSetUps.Rows

                Dim oCharge As cMdb_Cfg_Charge_Usage = Nothing

                If dgvRow.Cells(Options.CHARGE_USAGE_ID).Value = 0 Then

                    ' It would be a new row
                    If dgvRow.Cells(Options.ALWAYS_USE).Value <> 0 Or
                        dgvRow.Cells(Options.NEVER_USE).Value <> 0 Or
                        dgvRow.Cells(Options.NO_CHARGE).Value <> 0 Or
                        dgvRow.Cells(Options.UNIT_PRICE).Value <> 0 Then

                        oCharge = New cMdb_Cfg_Charge_Usage()

                        oCharge.Cus_No = m_Customer.cmp_code
                        oCharge.Charge_Id = dgvRow.Cells(Options.CHARGE_ID).Value
                        oCharge.Charge_Cd = dgvRow.Cells(Options.CHARGE_CD).Value
                        oCharge.Dec_Met_Id = dgvRow.Cells(Options.DEC_MET_ID).Value
                        oCharge.Cus_Prog_ID = m_Program.Cus_Prog_Id
                        oCharge.Always_Use = dgvRow.Cells(Options.ALWAYS_USE).Value
                        oCharge.Never_Use = dgvRow.Cells(Options.NEVER_USE).Value
                        oCharge.No_Charge = dgvRow.Cells(Options.NO_CHARGE).Value
                        oCharge.Unit_Price = dgvRow.Cells(Options.UNIT_PRICE).Value
                        oCharge.Charge_From = m_Program.Revision.Start_Dt
                        oCharge.Charge_To = m_Program.Revision.End_Dt

                        oCharge.Save()

                        dgvRow.Cells(Options.CHARGE_USAGE_ID).Value = oCharge.Charge_Usage_Id

                    End If

                Else

                    ' It is already existing
                    oCharge = New cMdb_Cfg_Charge_Usage(dgvRow.Cells(Options.CHARGE_USAGE_ID).Value)

                    oCharge.Always_Use = dgvRow.Cells(Options.ALWAYS_USE).Value
                    oCharge.Never_Use = dgvRow.Cells(Options.NEVER_USE).Value
                    oCharge.No_Charge = dgvRow.Cells(Options.NO_CHARGE).Value
                    oCharge.Unit_Price = dgvRow.Cells(Options.UNIT_PRICE).Value
                    oCharge.Charge_From = m_Program.Revision.Start_Dt
                    oCharge.Charge_To = m_Program.Revision.End_Dt

                    oCharge.Save()

                End If

                If (m_Program_Type <> "Quote") Or (m_Program_Type = "Quote" And m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer) Then
                    ' Now change the values in Macola
                    If Not oCharge Is Nothing Then

                        If oCharge.Charge_Usage_Id <> 0 Then

                            oCharge.SaveChargeToMacola(m_Program, m_Customer)

                        End If

                    End If

                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SaveOrder()

        Try

            Dim oOrder As New cOEI_ORDHDR(m_Program.Spector_Cd)
            m_Customer.SetCustomerDefaultValuesToOrder(oOrder, m_Program)


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Function ValidateSave() As Boolean

        Dim iErrorCount As Integer = 0

        ValidateSave = False
        m_blnCannotAutoApprove = False

        Try

            If txtCus_No.Text.Trim = String.Empty Then
                MsgBox("You must enter a customer number.", MsgBoxStyle.Exclamation, "Save Error")
                iErrorCount += 1
            End If

            If Not (IsDate(txtStart_Dt.Text) And IsDate(txtEnd_Dt.Text)) And iErrorCount = 0 Then
                MsgBox("You must enter a start date and an end date.", MsgBoxStyle.Exclamation, "Save Error")
                iErrorCount += 1
            End If



            If m_Program_Type = "Special Pricing" And txtProg_Comments.Text.Trim.Length = 0 And iErrorCount = 0 Then
                MsgBox("You must enter a reason for the special pricing.", MsgBoxStyle.Exclamation, "Save Error")
                iErrorCount += 1
            End If

            '++ID 10/9/14  --------------------
            Dim rows As String = ""

            'if is CUSTOM it should select one option in the Custom Item(Combobox)

            For Each row As DataGridViewRow In dgvItems.Rows

                If row.Cells(Items.ITEM_CD).FormattedValue.ToString.Contains("CUSTOM") Then

                    If row.Cells(Items.CUSTOM_ITEM_ID).Value = 0 Then

                        rows += (row.Index + 1).ToString & ","

                    End If

                End If

            Next

            'if it contain variable (rows)
            If rows <> String.Empty Then

                rows = rows.Substring(0, rows.LastIndexOf(","))
                '  Else

                '  MsgBox("No code was selected for custom item.", MsgBoxStyle.Exclamation, "Save Error")
                Debug.Print("In the Rows : " & rows & " and in the column : -Custom Item- it should choose an option ")
                '     iErrorCount += 1
            End If


            '++ID-------------------------------------------

            If dgvItems.Rows.Count <> 0 And iErrorCount = 0 Then

                For Each dgvRow As DataGridViewRow In dgvItems.Rows
                    dgvRow.Cells(Items.CUS_PROG_ID).Value = m_Program.Cus_Prog_Id
                Next

                For Each dgvRow As DataGridViewRow In dgvItems.Rows

                    If dgvRow.Visible Then

                        If dgvRow.Cells(Items.ITEM_CD).Value <> "" Then
                            If iErrorCount = 0 Then

                                Dim blnOK As Boolean = True

                                If Not (dgvRow.Cells(Items.CUS_PROG_ID) Is Nothing) Then

                                    If (dgvRow.Cells(Items.ITEM_CD) Is Nothing) Then
                                        blnOK = False
                                    Else
                                        If dgvRow.Cells(Items.ITEM_CD).Value.ToString.Equals(String.Empty) Then
                                            If (dgvRow.Cells(Items.UNIT_PRICE).Value <> 0 Or dgvRow.Cells(Items.EQP_PCT).Value <> 0) Then
                                                MsgBox("Item not defined on line " & (dgvRow.Index + 1).ToString & ".", MsgBoxStyle.Exclamation, "Save Error")
                                                iErrorCount += 1
                                            End If
                                            blnOK = False
                                        End If
                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

            End If

            '---------------------------------------------------------------------
            If dgvItems.Rows.Count > 0 Then
                Dim lst As List(Of ListPopulate) = New List(Of ListPopulate)
                Dim olst As ListPopulate
                Dim strMessage As String = ""

                For Each dr As DataGridViewRow In dgvItems.Rows

                    If String.IsNullOrWhiteSpace(Trim(dr.Cells(Items.ITEM_NO).Value)) = True And dr.Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") <> True And String.IsNullOrEmpty(dr.Cells(Items.ITEM_CD).Value) = False Then
                        olst = New ListPopulate(Trim(dr.Cells(Items.ITEM_CD).Value), Trim(dr.Cells(Items.ITEM_DESC).Value))

                        lst.Add(olst)
                    End If
                Next

                'need put exit sub in the case if value item_no is empty

                If lst.Count <> 0 Then

                    For Each l As ListPopulate In lst
                        strMessage &= "Required field : SKU and Color for Item - " & l.ID & vbCrLf
                    Next

                    MsgBox(strMessage)

                    iErrorCount += 1
                End If


            End If

            '--------------------------------------------------------------------

            '++ID 12.08.2015 I put in comment
            'If dgvOptions.Rows.Count <> 0 And iErrorCount = 0 Then

            '    For Each dgvRow As DataGridViewRow In dgvOptions.Rows

            '        'ALWAYS_USE     NEVER_USE   NO_CHARGE  UNIT_PRICE

            '        'If dgvRow.Cells(Options.UNIT_PRICE).Value <> 0 And dgvRow.Cells(Options.WAIVED).Value <> 0 Then
            '        If dgvRow.Cells(Options.UNIT_PRICE).Value <> 0 And dgvRow.Cells(Options.NO_CHARGE).Value <> 0 Then

            '            If (dgvRow.Cells(Items.UNIT_PRICE).Value <> 0 Or dgvRow.Cells(Items.EQP_PCT).Value <> 0) Then

            '                MsgBox("Option " & dgvRow.Cells(Options.DESCRIPTION).ToString & " cannot be waived with a unit price.", MsgBoxStyle.Exclamation, "Save Error")
            '                iErrorCount += 1

            '            End If

            '        End If

            '    Next

            'End If



            ValidateSave = (iErrorCount = 0)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Private Sub ProcessToNextStep()

        ' need add exception for certaine step

        Call ProcessToStep(m_Program.Quote_Step_ID + 1)

    End Sub

    Private Sub ProcessToStep(ByVal piStep As Integer)

        Try
            Dim strUser_Create As String = ""

            m_Program.Quote_Step_ID = piStep

            Select Case m_Program.Quote_Step_ID
                Case Quote_Step.New_Quote

                Case Quote_Step.Saved_Quote

                Case Quote_Step.Pending_Pricing_Approval

                    'If Environment.UserName.ToUpper <> "MARCB" Then

                    Dim oFrm As New frmQuote_Step_Request(m_Program_Type, m_Program.Quote_Type_ID, m_Program.Quote_Step_ID)
                    oFrm.CannotAutoApprove = m_blnCannotAutoApprove

                    oFrm.ShowDialog()

                    If oFrm.Proceed Then
                        If oFrm.Send_Request = False Then
                            Dim oUser As cHumres
                            Dim oMessage As New cMail()

                            oUser = New cHumres(Environment.UserName)
                            oMessage.FromAddr = oUser.Mail.Trim

                            oUser = New cHumres(oFrm.Request_User)
                            'oUser.Mail = "marcbeauregard@yahoo.com"
                            oMessage.ToAddr = oUser.Mail.Trim
                            '12.14.2017 need after test remove comment 
                            ' oMessage.BCCAddr = "email_log@spectorandco.com"

                            oMessage.Subject = "Price request for " & Program_Type & "#" & Trim(txtSpector_Cd.Text) & " "
                            oMessage.Message =
                            "This is an automated message from the Customer File program. " &
                            "You have a " & Program_Type & " price request for " & Program_Type & "#" & Trim(txtSpector_Cd.Text) & " (Customer " & m_Program.Cus_No & ")."
                            '     m_Program.Spector_Cd
                            oMessage.Send()

                        Else
                            m_Program.Quote_Step_ID = Quote_Step.Pricing_Approved
                        End If

                    Else
                        ' On recule a draft.

                        m_Program.Quote_Step_ID -= 1
                    End If

                    Debug.Print(oFrm.Request_User & "  Proceed: " & oFrm.Proceed.ToString & "   Send Request: " & oFrm.Send_Request.ToString)
                    oFrm.Dispose()

                    'End If

                Case Quote_Step.Pricing_Approved

                    strUser_Create = m_Program.User_Login.ToString.Trim

                    If strUser_Create.ToUpper = Environment.UserName.ToUpper Then
                        strUser_Create = m_Program.Create_By.ToString.Trim
                    End If

                    Dim strSql As String = "SELECT ID FROM humres WHERE usr_id = '" & strUser_Create & "' "    'm_Program.User_Login.ToString.Trim()
                    Dim dt As DataTable = db.DataTable(strSql)

                    If dt.Rows.Count <> 0 Then

                        Dim oUser As cHumres
                        Dim oMessage As New cMail()

                        oUser = New cHumres(Environment.UserName)
                        oMessage.FromAddr = oUser.Mail.Trim

                        oUser = New cHumres(CInt(dt.Rows(0).Item("ID")))

                        'oUser.Mail = "marcbeauregard@yahoo.com"
                        oMessage.ToAddr = oUser.Mail.Trim
                        '  oMessage.BCCAddr = "email_log@spectorandco.ca"

                        oMessage.Subject = "Pricing request for " & Program_Type & "#" & Trim(txtSpector_Cd.Text) & " completed."
                        oMessage.Message = "The pricing request for " & Program_Type & "#" & Trim(txtSpector_Cd.Text) & " (Customer " & m_Program.Cus_No & ") is now completed and approved."
                        oMessage.Send()

                    End If

                    Me.Close()
                    'If oResult <> MsgBoxResult.Cancel Then Me.Close()
                    'End If

                Case Quote_Step.Ready_To_Send

                Case Quote_Step.Sent_To_Customer


            End Select

            Dim blnOK As Boolean = m_Program_BUS.Save(m_Program)

            txtQuote_Step_ID.Text = m_Program.Quote_Step_ID

            Call SetProgramCaptions()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Shadows Sub Load()

    '    Try

    '        If tsTxtProgram_Cd.Text.Trim = "" Then Exit Sub
    '        'Dim oBUS As New cMdb_Cus_Prog_BUS()
    '        Dim oLoadProgram As New cMdb_Cus_Prog()

    '        oLoadProgram = m_Program_BUS.Load(tsTxtProgram_Cd.Text.Trim)

    '        If oLoadProgram.Cus_Prog_Id = 0 Then
    '            MsgBox("Program code does not exist.")
    '        Else
    '            m_Program = oLoadProgram

    '            Call ClearFields()
    '            Call FillFields()
    '            Call SetVisibleFields()

    '            tsTxtProgram_Cd.Text = ""
    '            txtStart_Dt.Focus()

    '            Select Case m_Program_Type

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
            Debug.Print("ClearFields " & Date.Now)
            txtCus_No.Text = String.Empty
            txtCurr_Cd.Text = String.Empty
            txtProg_Cd.Text = String.Empty

            'cboProg_Type.Text = String.Empty
            txtStart_Dt.Text = String.Empty
            txtEnd_Dt.Text = String.Empty

            chkOne_Shot.Checked = False
            chkSent_To_Customer.Checked = False

            'cboQuote_Type.Text = String.Empty
            'cboQuote_Ship_Method.Text = String.Empty

            'txtSearch_Program_Cd.Text = String.Empty

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub FillFields()

        Try
            txtCus_No.Text = m_Program.Cus_No
            txtCurr_Cd.Text = m_Customer.Currency

            txtSpector_Cd.Text = m_Program.Spector_Cd
            txtCurrent_Rev_No.Text = m_Program.Current_Rev_No

            txtProg_Cd.Text = m_Program.Prog_Cd
            'If m_Program.Prog_Desc = String.Empty Then
            '    txtImprint.Text = m_Program.Prog_Comments
            'Else
            '    txtImprint.Text = m_Program.Prog_Desc
            'End If

            txtImprint.Text = m_Program.Revision.Imprint ' m_Program.Current_Rev_No ' m_Program.Revision.Imprint ' Prog_Desc

            txtProg_Comments.Text = m_Program.Prog_Comments

            cboContact_ID.SelectedValue = m_Program.Revision.Cicntp_ID

            'txtProg_CSR.Text = m_Program.Revision.Prog_CSR

            'Select Case m_Program.Prog_Type
            '    Case 1
            '        cboProg_Type.Text = "Program"
            '    Case 2
            '        cboProg_Type.Text = "Special Price List"
            'End Select

            If m_Program.Revision.Start_Dt.Year <> 1 Then
                txtStart_Dt.Text = m_Program.Revision.Start_Dt
            ElseIf m_Program.Prog_Type = 2 Then
                txtStart_Dt.Text = Date.Now.Date
            End If

            If m_Program.Revision.End_Dt.Year <> 1 Then
                txtEnd_Dt.Text = m_Program.Revision.End_Dt
            ElseIf m_Program.Prog_Type = 2 Then
                txtEnd_Dt.Text = Date.Now.Date.AddDays(14)
            End If

            If m_Program.Revision.End_Dt.Year <> 1 Then txtEnd_Dt.Text = m_Program.Revision.End_Dt
            'If m_Program.End_Dt.Year <> 1 Then txtEnd_Dt.Text = m_Program.End_Dt

            chkOne_Shot.Checked = m_Program.One_Shot
            txtOrd_No.Text = m_Program.Ord_No

            chkAllGroup.Checked = m_Program.For_All_Accounts

            'If m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer Then chkSent_To_Customer.Checked = True

            'cboQuote_Type.Text = m_Program_BUS.Get_Quote_Type(m_Program.Quote_Type_ID)
            'cboQuote_Ship_Method.Text = m_Program_BUS.Get_Quote_Ship_Method(m_Program.Quote_Ship_Method_ID)


            If m_Program_Type = "Quote" Then
                cboStatusQuote.Text = m_Program.Quote_Status
                cboQuoteResult.Text = m_Program.Quote_Result

                If m_Program.Spector_Cd <> "" Then

                    If m_Program.Decision_Dt <> "#12:00:00 AM#" Then
                        txtDecision_Dt.Text = m_Program.Decision_Dt
                        m_EndDecisionDt = m_Program.Decision_Dt
                        If m_Program.Spector_Cd <> "" Then txtEndDecision_Dt.Text = m_EndDecisionDt.AddHours(6)
                    Else

                        'espace pour charge la  txtDecision
                        txtDecision_Dt.Text = FollowMe(Date.Now, "9:00:00 AM")
                        txtEndDecision_Dt.Text = FollowMe(Date.Now, "5:00:00 PM")
                    End If

                    txtNote.Text = Trim(m_Program.Note)

                End If

                '     If m_Program.Spector_Cd <> "" Then txtEndDecision_Dt.Text = m_EndDecisionDt.AddHours(6)

                If txtCommentQuoteResult.Visible = True Then
                    txtCommentQuoteResult.Text = m_Program.Prog_Comments
                End If

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetVisibleFields()

        Call SetEditingProperties()

    End Sub

    Private Sub SetEditingProperties()

        Try

            'panRenewal.Enabled = Not (m_Program.Prog_Cd Is Nothing)
            'panEQP.Enabled = Not (m_Program.Prog_Cd Is Nothing)
            'panApproval_Data.Visible = IsNothing(m_Program.Approved_Dt)
            'panApprove_Program.Visible = Not (IsNothing(m_Program.Approved_Dt))

            'panRenewal.Enabled = Not (txtProg_Cd.Text = String.Empty)
            'panEQP.Enabled = Not (txtProg_Cd.Text = String.Empty)
            'panApproval_Data.Visible = Not (txtApproved_Dt.Text = String.Empty)
            'panApprove_Program.Visible = txtApproved_Dt.Text = String.Empty

            'gbProgramItems.Enabled = (m_Program.Cus_Prog_Id <> 0)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


#Region "PRIVATE ROUTINES #####################################################"

    'Private Sub Approve_Program()

    '    Try

    '        If txtApproved_By_Us.Text.Trim = String.Empty Or txtApproved_By_Them.Text.Trim = "" Then
    '            MsgBox("Approved by information is missing.")
    '            Exit Sub
    '        End If

    '        If dgvItems.Rows.Count = 0 Then
    '            MsgBox("A program cannot be approved without items.")
    '            Exit Sub
    '        End If

    '        Dim oConfirm As MsgBoxResult

    '        oConfirm = MsgBox("Do you approve this program ?", MsgBoxStyle.YesNo, "Program approval")

    '        If oConfirm = MsgBoxResult.Yes Then
    '            txtApproved_Dt.Text = Now.Date.ToShortDateString
    '            Call Save()
    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

#End Region


#Region "PRIVATE DGVITEMS MAINTENANCE OPERATIONS ##############################"

    Private Sub dgvItems_CreateColumns()

        Try
            Dim comboboxColumn As DataGridViewComboBoxColumn

            With dgvItems.Columns
                .Clear()
                If .Count > 0 Then
                    For iCol = .Count To 1 Step -1
                        .RemoveAt(iCol - 1)
                    Next
                End If

                ' .Add(DGVTextBoxColumn("FirstCol", "FirstCol", 0))

                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_ID", "CUS_PROG_ITEM_LIST_ID", 20))
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 100))

                comboboxColumn = New DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("PROD_CAT_ID", "Category", 100)
                With comboboxColumn
                    .DataSource = GetProd_Cat_List()
                    .ValueMember = "PROD_CAT_ID"
                    .DisplayMember = "PROD_CAT_CODE"
                End With
                .Add(comboboxColumn)

                .Add(DGVTextBoxColumn("ITEM_CD", "Item", IIf(m_Program_Type = "Quote", 80, 120)))
                .Add(DGVTextBoxColumn("ITEM_COMMENT_LOGO", "ITEM_COMMENT_LOGO", 120))
                .Add(DGVCheckBoxColumn("Selectrow", "Select", 50))

                comboboxColumn = New DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("CUSTOM_ITEM_ID", "Custom Item", 100)
                With comboboxColumn
                    .DataSource = GetCustom_Item_List()
                    .ValueMember = "CUSTOM_ITEM_ID"
                    .DisplayMember = "CUSTOM_ITEM_DESC"
                End With
                .Add(comboboxColumn)


                .Add(DGVTextBoxColumn("ITEM_DESC", "Description", IIf(m_Program_Type = "Quote", 150, 150)))
                .Add(DGVTextBoxColumn("Disco", "Disco", 80))
                .Add(DGVTextBoxColumn("ITEM_NO", "SKU", 100))


                comboboxColumn = New DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("ITEM_COLOR", "Color", 300)
                '  m_Program_BUS.SetColorCombo(m_Program, comboboxColumn)
                With comboboxColumn
                    .DataSource = allColorList()
                    .ValueMember = "Item_Color" ' ColumnName.TitleOfCourtesy.ToString()
                    .DisplayMember = "Item_Color"

                End With
                ' comboboxColumn.ReadOnly = False
                .Add(comboboxColumn)

                    comboboxColumn = New DataGridViewComboBoxColumn
                    comboboxColumn = DGVComboBoxColumn("Quote_Type_ID", "Ship_Origin", 100)
                    With comboboxColumn
                        .DataSource = m_Program_BUS.Get_Quote_Type_ComboList()
                        .ValueMember = "Quote_Type_ID"
                        .DisplayMember = "Quote_Type_Desc"
                    End With
                .Add(comboboxColumn)

                'justin 20190917
                .Add(DGVTextBoxColumn("ITEM_SUBSTITUTE", "ITEM_SUBSTITUTE", 120))

                comboboxColumn = New DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("Quote_Ship_Method_ID", "Ship_Method", 100)
                    With comboboxColumn
                        .DataSource = m_Program_BUS.Get_Quote_Ship_Method_ComboList()
                        .ValueMember = "Quote_Ship_Method_ID"
                        .DisplayMember = "Quote_Ship_Method_Desc"
                    End With
                    .Add(comboboxColumn)

                    '.Add(DGVComboBoxColumn("ITEM_COLOR", "Color", 100))
                    .Add(DGVTextBoxColumn("MIN_QTY_ORD", "Min Qty", 60)) ' 80
                    .Add(DGVTextBoxColumn("UNIT_PRICE", "Price", 60)) ' 80
                .Add(DGVCheckBoxColumn("EQP_LEVEL", "EQP", 40)) ' 50 

                .Add(DGVTextBoxColumn("EQP_PCT", "EQP Disc %", 60))

                comboboxColumn = New DataGridViewComboBoxColumn
                comboboxColumn = DGVComboBoxColumn("DEC_MET_ID", "Decorating", 100)

                With comboboxColumn
                    .DataSource = AllDecoMeth()
                    .ValueMember = "DEC_MET_ID" ' ColumnName.TitleOfCourtesy.ToString()
                    .DisplayMember = "DEC_MET_NAME"
                End With

                ' SetDecoratingCombo(comboboxColumn)
                .Add(comboboxColumn)

                    comboboxColumn = New DataGridViewComboBoxColumn
                    comboboxColumn = DGVComboBoxColumn("DEC_MET_GROUP_ID", "Decorating", 100)
                    SetGroupDecoratingCombo(comboboxColumn)
                    .Add(comboboxColumn)

                    .Add(DGVCheckBoxColumn("SETUP_WAIVED", "Setup Waived", 50))
                    .Add(DGVTextBoxColumn("SETUP_PRICE", "Special Setup Price", 80))

                    '++ID 06.08.2015
                    comboboxColumn = New DataGridViewComboBoxColumn
                    comboboxColumn = DGVComboBoxColumn("CHARGE_ID", "Charge", 150)
                    SetChargeCombo(comboboxColumn)
                    .Add(comboboxColumn)

                    .Add(DGVTextBoxColumn("RUN_CHARGE", "Run Charge", 80))

                    .Add(DGVTextBoxColumn("COLOR_COUNT", "Color", 40))
                    .Add(DGVTextBoxColumn("LOCATION_COUNT", "Location", 40))

                    comboboxColumn = New DataGridViewComboBoxColumn
                    comboboxColumn = DGVComboBoxColumn("PACK_ID", "Packaging", 100)
                    SetPackagingCombo(comboboxColumn)
                    .Add(comboboxColumn)
                    '.Add(DGVCheckBoxColumn("OVERSEAS", "Overseas", 60))
                    '.Add(DGVCheckBoxColumn("DOMESTIC", "Domestic", 60))

                    'comboboxColumn = DGVComboBoxColumn("REFILL_ID", "Refill", 50)
                    'SetColorCombo(comboboxColumn)
                    'dgvItems.Columns.Add(comboboxColumn)

                    .Add(DGVTextBoxColumn("USER_LOGIN", "Entered By", 80))
                    .Add(DGVTextBoxColumn("UPDATE_TS", "Entered Date", 80))

                    .Add(DGVTextBoxColumn("DIRTY", "DIRTY", 80))
                    .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_GUID", "ITEM GUID", 1))
                    .Add(DGVTextBoxColumn("LINE_COMMENTS", "Comments", 80))
                    '++ID
                    .Add(DGVButtonColumn("Image", "Image", 60))
                    .Add(DGVTextBoxColumn("DocId", "Doc Id", 50))

                    .Add(DGVCheckBoxColumn("Need_Approval", "Need Approval", 30))
                End With



                With dgvItems
                .Columns(Items.CUS_PROG_ITEM_LIST_ID).Visible = False
                .Columns(Items.CUS_PROG_ID).Visible = False
                .Columns(Items.PROD_CAT_ID).Visible = False
                .Columns(Items.ITEM_CD).Visible = True
                .Columns(Items.CUSTOM_ITEM_ID).Visible = False
                .Columns(Items.ITEM_DESC).Visible = True
                .Columns(Items.ITEM_NO).Visible = True
                .Columns(Items.ITEM_COLOR).Visible = True
                .Columns(Items.QUOTE_TYPE_ID).Visible = (m_Program_Type = "Quote")
                .Columns(Items.ITEM_SUBSTITUTE).Visible = True
                .Columns(Items.QUOTE_SHIP_METHOD_ID).Visible = (m_Program_Type = "Quote")
                .Columns(Items.MIN_QTY_ORD).Visible = True
                .Columns(Items.UNIT_PRICE).Visible = True
                '  .Columns(Items.UNIT_PRICE).ReadOnly = True
                .Columns(Items.EQP_LEVEL).Visible = (m_Program_Type <> "Quote")

                .Columns(Items.EQP_LEVEL).Visible = (m_Program_Type <> "Special Pricing")

                .Columns(Items.EQP_PCT).Visible = (m_Program_Type <> "Quote")
                .Columns(Items.EQP_PCT).Visible = (m_Program_Type <> "Special Pricing")

                '++ID 13.05.2015 readonly false if EQP_LEVEL = false(0)
                .Columns(Items.EQP_PCT).ReadOnly = True

                .Columns(Items.DEC_MET_ID).Visible = True ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.DEC_MET_GROUP_ID).Visible = False ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.SETUP_WAIVED).Visible = True '(m_Program_Type <> "Special Pricing")
                .Columns(Items.SETUP_PRICE).Visible = True '(m_Program_Type <> "Special Pricing")
                .Columns(Items.RUN_CHARGE).Visible = True ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.COLOR_COUNT).Visible = (m_Program_Type = "Program") '(m_Program_Type = "Quote")
                .Columns(Items.LOCATION_COUNT).Visible = (m_Program_Type = "Program") '(m_Program_Type = "Quote")
                .Columns(Items.PACK_ID).Visible = (m_Program_Type = "Quote")
                '.Columns(Items.OVERSEAS).Visible = (m_Program_Type = "Quote")
                '.Columns(Items.DOMESTIC).Visible = (m_Program_Type = "Quote")
                .Columns(Items.USER_LOGIN).Visible = False
                .Columns(Items.UPDATE_TS).Visible = False
                .Columns(Items.DIRTY).Visible = False
                .Columns(Items.CUS_PROG_ITEM_LIST_GUID).Visible = True
                .Columns(Items.CUS_PROG_ITEM_LIST_GUID).ReadOnly = True
                '.Columns(Items.LINE_COMMENTS).Visible = False
                .RowHeadersWidth = 20
                .Columns(Items.DocId).Visible = False
                .Columns(Items.DocId).ReadOnly = True
                .Columns(Items.DISCO).ReadOnly = True
                .Columns(Items.DocId).ToolTipText = "IMAGE"
                .Columns(Items.Image).Visible = (m_Program_Type = "Quote")

                .Columns(Items.NEED_APPROVAL).Visible = False
                .Columns(Items.ITEM_SUBSTITUTE).Visible = True

            End With


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function GetCustom_Item_List() As DataTable

        GetCustom_Item_List = New DataTable

        Try

            Dim strSQL As String =
            "SELECT     CAST(0 AS INT) AS CUSTOM_ITEM_ID, CAST(' ' AS VARCHAR(100)) AS CUSTOM_ITEM_DESC " &
            "UNION " &
            "SELECT		ISNULL(E.ID, 0) AS CUSTOM_ITEM_ID, rtrim(isnull(E.ENUM_VALUE, '')) AS CUSTOM_ITEM_DESC " &
            "FROM       MDB_CFG_ENUM E WITH (Nolock) " &
            "WHERE      E.ENUM_CAT = 'CUSTOM_ITEMS' " &
            "ORDER BY   CUSTOM_ITEM_DESC "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            GetCustom_Item_List = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function GetProd_Cat_List() As DataTable ' , ByVal pstrProd_Cat As String)

        GetProd_Cat_List = New DataTable

        Try

            Dim strSQL As String =
            "SELECT     CAST(0 AS INT) AS PROD_CAT_ID, CAST(' ' AS VARCHAR(100)) AS PROD_CAT_CODE " &
            "UNION " &
            "SELECT		ISNULL(C.PROD_CAT_ID, 0) AS PROD_CAT_ID, rtrim(isnull(c.PROD_CAT_CODE, '')) AS PROD_CAT_CODE " &
            "FROM		MDB_CFG_PROD_CAT C WITH (Nolock) " &
            "ORDER BY   PROD_CAT_CODE "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            GetProd_Cat_List = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    ''justin 20190910 for culumn substitute display in dgv_items
    Private Sub dgvItems_C_Subst_item()
        Dim l_row_id As Int16
        Dim l_main_item_cd As String
        Dim l_main_item_master_id As Int16
        Dim l_subst_item_count_flag As Int16
        l_row_id = 0
        Try
            If dgvItems.Rows.Count = 0 Then
                Exit Sub
            End If
            For Each dgvRow As DataGridViewRow In dgvItems.Rows
                If IsDBNull(dgvRow.Cells("item_cd").Value) Then
                    ''
                Else
                    l_main_item_master_id = 0
                    'get item_cd
                    l_main_item_cd = CStr(dgvRow.Cells("item_cd").Value)
                    'get item_master_id by item_cd
                    Dim Get_item_master_id = New DataTable
                    Dim strSQL As String =
                        "select item_master_id from mdb_item_master where item_cd = '" & l_main_item_cd & "'"
                    Dim dt As New DataTable
                    Dim db As New cDBA
                    dt = db.DataTable(strSQL)
                    If dt.Rows.Count = 0 Then
                        'MsgBox("Notice: ITEM_CD:" & l_main_item_cd & " is not valid! ")
                        'Exit Sub
                        dgvItems.Rows(l_row_id).Cells("ITEM_SUBSTITUTE").Value = ""
                        l_row_id = l_row_id + 1
                        Continue For
                    Else
                        l_main_item_master_id = dt.Rows(0).Item(0)
                    End If


                    'update item_substitute
                    Dim strSQL_count As String =
                        "select count(*) as l_count from MDB_SUBSTITUTE_ITEM_MASTER where ITEM_MASTER_ID = " & l_main_item_master_id
                    Dim dt_count As New DataTable
                    Dim db_count As New cDBA
                    dt_count = db_count.DataTable(strSQL_count)
                    l_subst_item_count_flag = dt_count.Rows(0).Item(0)
                    If l_subst_item_count_flag = 0 Then
                        dgvItems.Rows(l_row_id).Cells("ITEM_SUBSTITUTE").Value = "No Substitute item!"
                        dgvItems.Rows(l_row_id).Cells("ITEM_SUBSTITUTE").Style.BackColor = Color.Red
                    Else
                        dgvItems.Rows(l_row_id).Cells("ITEM_SUBSTITUTE").Value = "Substitute item list"
                        dgvItems.Rows(l_row_id).Cells("ITEM_SUBSTITUTE").Style.BackColor = Color.MediumSeaGreen
                    End If

                    l_row_id = l_row_id + 1
                End If

            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    ''
    Private Sub dgvItems_Fill()

        Try

            'Dim dt As DataTable
            Dim db As New cDBA

            Dim strLoadString As String =
              "SELECT   I.CUS_PROG_ITEM_LIST_ID, I.CUS_PROG_ID, ISNULL(I.PROD_CAT_ID, 0) AS PROD_CAT_ID, " &
            "           I.ITEM_CD, Item_comment_LOGO  as ITEM_COMMENT_LOGO ," &
            " 0 As Selectrow,I.CUSTOM_ITEM_ID, I.ITEM_DESC,'' As Disco ,I.ITEM_NO, I.ITEM_COLOR, I.QUOTE_TYPE_ID, 'ITEM_SUBSTITUTE' as ITEM_SUBSTITUTE,I.QUOTE_SHIP_METHOD_ID, " &
            "           I.MIN_QTY_ORD, I.UNIT_PRICE  AS UNIT_PRICE, " &
            "           I.EQP_LEVEL,I.EQP_PCT  AS EQP_PCT, " &
            "           I.DEC_MET_ID, I.DEC_MET_GROUP_ID, I.SETUP_WAIVED, I.SETUP_PRICE, I.CHARGE_ID,I.RUN_CHARGE, " &
            "           I.COLOR_COUNT, I.LOCATION_COUNT, I.PACK_ID, " &
            "           I.USER_LOGIN, I.UPDATE_TS, CAST('' AS VARCHAR(1)) AS DIRTY, " &
            "           I.CUS_PROG_ITEM_LIST_GUID, 'Comments' AS LINE_COMMENTS ,'Image' AS Image , I.DocId,I.Need_Approval" &
            "          FROM       MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) " &
            "          WHERE      I.CUS_PROG_ID = " & m_Program.Cus_Prog_Id.ToString & " " &
            "          ORDER BY   I.CUS_PROG_ITEM_LIST_ID "



            '++ID in comment because EQP_LEVEL decide display price
            '"SELECT     I.CUS_PROG_ITEM_LIST_ID, I.CUS_PROG_ID, ISNULL(I.PROD_CAT_ID, 0) AS PROD_CAT_ID, " & _
            '"           I.ITEM_CD, I.CUSTOM_ITEM_ID, I.ITEM_DESC, I.ITEM_NO, I.ITEM_COLOR, I.QUOTE_TYPE_ID, I.QUOTE_SHIP_METHOD_ID, " & _
            '"           I.MIN_QTY_ORD, CASE WHEN I.EQP_LEVEL = 1 THEN NULL ELSE I.UNIT_PRICE END AS UNIT_PRICE, " & _
            '"           I.EQP_LEVEL, CASE WHEN I.EQP_LEVEL = 1 THEN I.EQP_PCT ELSE NULL END AS EQP_PCT, " & _
            '"           I.DEC_MET_ID, I.DEC_MET_GROUP_ID, I.SETUP_WAIVED, I.SETUP_PRICE, I.RUN_CHARGE, " & _
            '"           I.COLOR_COUNT, I.LOCATION_COUNT, I.PACK_ID, " & _
            '"           I.USER_LOGIN, I.UPDATE_TS, CAST('' AS VARCHAR(1)) AS DIRTY, " & _
            '"           I.CUS_PROG_ITEM_LIST_GUID, 'Comments' AS LINE_COMMENTS ,'Image' AS Image , I.DocId" & _
            '"          FROM       MDB_CUS_PROG_ITEM_LIST I WITH (Nolock) " & _
            '"          WHERE      I.CUS_PROG_ID = " & m_Program.Cus_Prog_Id.ToString & " " & _
            '"          ORDER BY   I.CUS_PROG_ITEM_LIST_ID "
            '"           I.COLOR_COUNT, I.LOCATION_COUNT, I.PACK_ID, I.OVERSEAS, I.DOMESTIC, " & _

            Dim strLoadEmpty As String =
            "SELECT     TOP 1  CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " &
            "           CAST(0 AS INT) AS CUS_PROG_ID, " &
            "           CAST(0 AS INT) AS PROD_CAT_ID, " &
            "           CAST('' AS VARCHAR(20)) AS ITEM_CD,  CAST('' AS VARCHAR(100))  as ITEM_COMMENT_LOGO , CAST(0 AS INT) AS Selectrow, " &
            "           CAST(0 AS INT) AS CUSTOM_ITEM_ID, " &
            "           CAST('' AS VARCHAR(60)) AS ITEM_DESC, " &
            "           CAST('' AS VARCHAR(15)) AS Disco, " &
            "           CAST('' AS VARCHAR(30)) AS ITEM_NO, " &
            "           CAST('' AS VARCHAR(20)) AS ITEM_COLOR, " &
            "           CAST(0 AS INT) AS QUOTE_TYPE_ID, " &
            "           CAST('' AS VARCHAR(60)) AS ITEM_SUBSTITUTE, " &
            "           CAST(0 AS INT) AS QUOTE_SHIP_METHOD_ID, " &
            "           CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " &
            "           CAST(0 AS NUMERIC(13, 4)) AS UNIT_PRICE, " &
            "           CAST(NULL AS INT) AS EQP_LEVEL, " &
            "           CAST(NULL AS NUMERIC(13, 4)) AS EQP_PCT, " &
            "           CAST(NULL AS INT) AS DEC_MET_ID, " &
            "           CAST(NULL AS INT) AS DEC_MET_GROUP_ID, " &
            "           CAST(NULL AS BIT) AS SETUP_WAIVED, " &
            "           CAST(NULL AS NUMERIC(13, 6)) AS SETUP_PRICE, " &
            "           CAST(0 AS INT) AS CHARGE_ID,  " &
            "           CAST(NULL AS NUMERIC(13, 6)) AS RUN_CHARGE, " &
            "           CAST(1 AS INT) AS COLOR_COUNT, " &
            "           CAST(1 AS INT) AS LOCATION_COUNT, " &
            "           CAST(NULL AS INT) AS PACK_ID, " &
            "           CAST('' AS VARCHAR(20)) AS USER_LOGIN, " &
            "           CAST(NULL AS DATETIME) AS UPDATE_TS,  " &
            "           CAST('' AS VARCHAR(1)) AS DIRTY, " &
            "           CAST('' AS VARCHAR(40)) AS CUS_PROG_ITEM_LIST_GUID, " &
            "           'Comments' AS LINE_COMMENTS ," &
            "           CAST('' As VARCHAR(5))  As Image,          " &
            "           CAST(0 AS INT) AS DocID,  " &
            "           CAST(NULL AS BIT) AS Need_Approval " &
            "           FROM       MDB_CUS_PROG_ITEM_LIST "

            '"           CAST(NULL AS BIT) AS OVERSEAS, " & _
            '"           CAST(NULL AS BIT) AS DOMESTIC, " & _

            If m_Program.Cus_Prog_Id <> 0 Then
                dtItems = db.DataTable(strLoadString)
                If dtItems.Rows.Count = 0 Then
                    dtItems = db.DataTable(strLoadEmpty)
                End If
            Else
                dtItems = db.DataTable(strLoadEmpty)
            End If

            dgvItems.DataSource = dtItems

            dgvItems.AllowUserToAddRows = False
            dgvItems.AllowUserToOrderColumns = False

            If dgvItems.Rows(0).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = String.Empty Then
                dgvItems.Rows(0).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = Guid.NewGuid.ToString
            End If

            '' Initialize the button column. 
            'Dim oButton As DataGridViewButtonColumn
            'oButton = DGVButtonColumn("LINE_COMMENTS", "Comments", 80)

            '' Add the button column to the control.
            'dgvItems.Columns.Add(oButton)

            Select Case m_Program_Type
                Case "Quote"
                    dgvItems.Columns(Items.CUSTOM_ITEM_ID).Visible = m_Program_BUS.ContainsCustomItems(m_Program)
                    dgvItems.Columns(Items.NEED_APPROVAL).Visible = False

                    dgvItems.Columns(Items.EQP_LEVEL).Visible = False
                    dgvItems.Columns(Items.EQP_PCT).Visible = False

                Case "Special Pricing"
                    dgvItems.Columns(Items.LINE_COMMENTS).Visible = False
                    dgvItems.Columns(Items.NEED_APPROVAL).Visible = False

                    dgvItems.Columns(Items.EQP_LEVEL).Visible = False
                    dgvItems.Columns(Items.EQP_PCT).Visible = False

                Case "Program"
                    dgvItems.Columns(Items.LINE_COMMENTS).Visible = False
                    'dgvItems.Columns(Items.LINE_COMMENTS).Visible = True 'test justin 20230516


            End Select

            'For Each dgvRow As DataGridViewRow In dgvItems.Rows
            '    If dgvRow.Cells(Items.ITEM_NO).Value <> String.Empty Then

            '        Dim _item_no As String = ""
            '        _item_no = dgvRow.Cells(Items.ITEM_NO).Value

            '        Dim _disco As String = ""

            '        _disco = CheckDiscoProp(_item_no)

            '        If _disco.Length > 0 Then
            '            dgvRow.Cells(Items.DISCO).Value = Trim(_disco)
            '            ' dgvItems.CurrentRow = Color.Red
            '            dgvRow.DefaultCellStyle.BackColor = Color.Red
            '        Else
            '            dgvRow.DefaultCellStyle.BackColor = Color.White
            '        End If


            '    End If

            'Next
            Call DiscoColorRows()

            Call dgvItems_C_Subst_item()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    Private Sub DiscoColorRows()
        Try
            For Each dgvRow As DataGridViewRow In dgvItems.Rows
                If dgvRow.Cells(Items.ITEM_NO).Value <> String.Empty Then

                    Dim _item_no As String = ""
                    _item_no = dgvRow.Cells(Items.ITEM_NO).Value

                    Dim _disco As String = ""

                    _disco = CheckDiscoProp(_item_no)

                    If _disco.Length > 0 Then
                        dgvRow.Cells(Items.DISCO).Value = Trim(_disco)
                        ' dgvItems.CurrentRow = Color.Red
                        dgvRow.DefaultCellStyle.BackColor = Color.Red
                    Else
                        dgvRow.DefaultCellStyle.BackColor = Color.White
                    End If


                End If

            Next
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvItems_Format()

        Try

            With dgvItems
                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                .CausesValidation = True

                Dim oCellStyle As New DataGridViewCellStyle()
                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.000"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Items.UNIT_PRICE).DefaultCellStyle = oCellStyle
                .Columns(Items.SETUP_PRICE).DefaultCellStyle = oCellStyle
                .Columns(Items.RUN_CHARGE).DefaultCellStyle = oCellStyle

                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.00"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(Items.EQP_PCT).DefaultCellStyle = oCellStyle

                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "###,##0"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Items.MIN_QTY_ORD).DefaultCellStyle = oCellStyle

                '.Columns(PickTypeColumns.ColHeader).Frozen = True
                .Columns(Items.CUS_PROG_ITEM_LIST_ID).Frozen = True
                .Columns(Items.CUS_PROG_ID).Frozen = True
                .Columns(Items.PROD_CAT_ID).Frozen = True
                .Columns(Items.ITEM_CD).Frozen = True
                .Columns(Items.ITEM_SUBSTITUTE).ReadOnly = True


                ''.Columns(PickTypeColumns.ColHeader).Visible = False
                '.Columns(Items.CUS_PROG_ITEM_LIST_ID).Visible = False
                '.Columns(Items.CUS_PROG_ID).Visible = False

                '.Columns(Items.USER_LOGIN).Visible = False
                '.Columns(Items.UPDATE_TS).Visible = False

                .CurrentCell = .Rows(0).Cells(Items.ITEM_CD)


            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'return Charge - ITEM_NO
    Private Function Charge_Item_No(ByRef cbCharge As Int32) As String

        Charge_Item_No = ""

        Dim strSql As String
        Dim dt As DataTable

        strSql =
            " select item_no from MDB_CFG_CHARGE With (NOLOCK) " &
            " where charge_id = " & cbCharge

        dt = db.DataTable(strSql)

        Charge_Item_No = Trim(dt.Rows(0).Item("item_no").ToString)

    End Function


    'return price for RunCharge
    Private Function PriceRunCharge(ByRef DGVCell As Int32) As Decimal

        PriceRunCharge = 0.0
        '   Dim comboBoxCell As New DataGridViewComboBoxCell()

        Try
            Dim strSql As String
            Dim dt As DataTable

            '   comboBoxCell = DGVCell

            If DGVCell <> 0 Then

                strSql =
                    " SELECT  prc_or_disc_1, RTRIM(cd_tp_1_item_no)  FROM oeprcfil_sql  WITH (Nolock) " &
                    " where curr_cd = '" & Trim(m_Customer.Currency) & "' And cd_tp = 1  " &
                    " And cd_tp_3_cust_type = '' and cd_tp_1_cust_no = '" & Trim(m_Customer.CustomerCode) & "' " &
                    " and  cd_tp_1_item_no = '" & Charge_Item_No(DGVCell) & "' and end_dt > GETDATE()  "

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then
                    ' lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                    ' lblCharge_ItemNo.BackColor = Color.Yellow
                    ' lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                    PriceRunCharge = FormatNumber(CDbl(dt.Rows(0).Item("prc_or_disc_1")), 3)
                    '  Call Curr(txtRunCharge)
                Else

                    strSql =
                        " SELECT  prc_or_disc_1, RTRIM(cd_tp_1_item_no)  FROM oeprcfil_sql WITH (Nolock) " &
                         " where  curr_cd = '" & Trim(m_Customer.Currency) & "' And cd_tp = 6  " &
                        " And cd_tp_3_cust_type = '' and cd_tp_1_cust_no = '' " &
                        " and  cd_tp_1_item_no = '" & Charge_Item_No(DGVCell) & "' and end_dt > GETDATE()  "

                    dt = db.DataTable(strSql)
                    If dt.Rows.Count <> 0 Then
                        'lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                        'lblCharge_ItemNo.BackColor = Color.Yellow
                        'lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                        PriceRunCharge = dt.Rows(0).Item("prc_or_disc_1")
                        'Call Curr(txtRunCharge)

                    Else
                        'lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                        'lblCharge_ItemNo.BackColor = Color.Yellow
                        'lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                        PriceRunCharge = FormatNumber(CDbl(0.0), 3)
                        'Call Curr(txtRunCharge)

                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#End Region


#Region "FORCE FOCUS OPERATIONS AND TRIGGERS ##################################"

    ' This proc checks the tabindex of the caller and compare it to needed fields.
    ' Also, completes some fields depending on position from tabindex order.
    'Private Function ForceFocus(ByVal piTabIndex As Integer) As Boolean

    '    ForceFocus = False

    '    Try
    '        ' Set focus to Order number if not entered
    '        If piTabIndex > cmdEnd_Dt.TabIndex Then

    '            If (Trim(txtEnd_Dt.Text) = "") Then

    '                txtEnd_Dt.Focus()
    '                'ttToolTip.SetToolTip(txtEnd_Dt, "Data must be entered here.")
    '                'ForceFocus = True

    '                'Exit Function

    '            Else

    '                If txtSpector_Cd.Text = String.Empty Then

    '                    txtSpector_Cd.Text = m_Program_BUS.Get_Next_Spector_Cd(CDate(txtEnd_Dt.Text))
    '                    Call SetEditingProperties()

    '                End If

    '            End If

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Function

    'Private Sub ForceFocus(ByRef oElement As Object)

    '    Dim txtElement As New Object

    '    Try
    '        If TypeOf oElement Is xTextBox Then

    '            txtElement = New xTextBox
    '            txtElement = DirectCast(oElement, xTextBox)

    '        ElseIf TypeOf oElement Is ComboBox Then

    '            txtElement = New ComboBox
    '            txtElement = DirectCast(oElement, ComboBox)

    '        End If

    '        txtElement.focus()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    '' Logical sequence get focus to force focus on needed fields
    'Private Sub Element_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    '    txtApproved_By_Them.GotFocus, txtApproved_By_Us.GotFocus, txtApproved_Dt.GotFocus

    '    Dim lTabIndex As Integer

    '    Try
    '        If TypeOf sender Is xTextBox Then

    '            Dim txtElement As New xTextBox
    '            txtElement = DirectCast(sender, xTextBox)
    '            lTabIndex = txtElement.TabIndex

    '        ElseIf TypeOf sender Is ComboBox Then

    '            Dim txtElement As New ComboBox
    '            txtElement = DirectCast(sender, ComboBox)
    '            lTabIndex = txtElement.TabIndex

    '        ElseIf TypeOf sender Is CheckBox Then

    '            Dim txtElement As New CheckBox
    '            txtElement = DirectCast(sender, CheckBox)
    '            lTabIndex = txtElement.TabIndex

    '        ElseIf TypeOf sender Is Button Then

    '            Dim txtElement As New Button
    '            txtElement = DirectCast(sender, Button)
    '            lTabIndex = txtElement.TabIndex

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    '    'blnForceFocus = ForceFocus(lTabIndex)

    'End Sub


    'Private Sub ReadOnlyFields_GotFocus(sender As Object, e As System.EventArgs) _
    'Handles txtCus_No.GotFocus, txtSpector_Cd.GotFocus

    '    txtProg_Cd.Focus()

    'End Sub

#End Region


#Region "ENUMERATORS ##########################################################"

    'Private Enum ItemColumn
    '    CUS_PROG_ITEM_LIST_ID
    '    CUS_PROG_ID
    '    ITEM_CD
    '    ITEM_NO
    '    EQP_LEVEL
    '    EQP_COLUMN
    '    EQP_PCT
    '    UNIT_PRICE
    '    MIN_QTY_ORD
    '    USER_LOGIN
    '    UPDATE_TS
    'End Enum

    Private Enum Items

        CUS_PROG_ITEM_LIST_ID
        CUS_PROG_ID
        PROD_CAT_ID
        ITEM_CD
        ITEM_COMMENT_LOGO
        SELECTROW
        CUSTOM_ITEM_ID
        ITEM_DESC
        DISCO
        ITEM_NO
        ITEM_COLOR
        QUOTE_TYPE_ID
        'justin 20190910
        ITEM_SUBSTITUTE
        QUOTE_SHIP_METHOD_ID
        MIN_QTY_ORD
        UNIT_PRICE
        EQP_LEVEL
        EQP_PCT
        DEC_MET_ID
        DEC_MET_GROUP_ID
        SETUP_WAIVED
        SETUP_PRICE
        CHARGE_ID
        RUN_CHARGE
        COLOR_COUNT
        LOCATION_COUNT
        PACK_ID
        'OVERSEAS
        'DOMESTIC
        USER_LOGIN
        UPDATE_TS
        DIRTY
        CUS_PROG_ITEM_LIST_GUID
        LINE_COMMENTS
        Image
        DocId
        NEED_APPROVAL
    End Enum

    Private Enum Options

        CHARGE_USAGE_ID
        CHARGE_ID
        CHARGE_CD
        DEC_MET_ID
        DEC_MET_CD
        CUS_PROG_ID
        DESCRIPTION
        SHORT_DESC
        CUS_NO
        ALWAYS_USE
        NEVER_USE
        NO_CHARGE
        UNIT_PRICE
        EXT_COMMENTS

    End Enum

    Private Enum Tabs
        Options
        Documents
    End Enum

    Public Enum Quote_Type

        Domestic = 1
        Overseas
        Custom

    End Enum

    Public Enum Quote_Ship_Method

        Air = 1
        Ground
        Sea

    End Enum

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

    Public Property Program() As cMdb_Cus_Prog
        Get
            Program = m_Program
        End Get
        Set(ByVal value As cMdb_Cus_Prog)
            m_Program = value
        End Set
    End Property

#End Region


    Private Sub ProductLineInsert(Optional ByVal pstrItem_Cd As String = "")

        Debug.Print("ProductLineInsert")

        Try

            m_Program_BUS.ProductLineInsert(dgvItems, dtItems, m_Program, pstrItem_Cd)


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Public Property Program_Type() As String
        Get
            Program_Type = m_Program_Type
        End Get
        Set(ByVal value As String)
            m_Program_Type = value
        End Set
    End Property



    'Private Sub ItemLineInsert()

    '    Debug.Print("ItemLineInsert")

    '    Try

    '        If dgvItems.Rows.Count = 0 Then

    '            Call LineInsert()

    '        ElseIf Not (dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value.Equals(DBNull.Value)) Then

    '            If Not Trim(dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value).Equals("") Then
    '                Call LineInsert()
    '            Else
    '                dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)
    '            End If

    '        Else

    '            dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)

    '        End If

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Private Sub LineInsert()

    '    Debug.Print("LineInsert")

    '    Try
    '        Dim drNewRow As DataRow
    '        dgvItems.AllowUserToAddRows = True

    '        Dim colHidden As New Collection
    '        For Each drRow As DataGridViewRow In dgvItems.Rows
    '            If drRow.Visible = False Then colHidden.Add(drRow.Index.ToString, drRow.Index.ToString)
    '        Next

    '        drNewRow = dtItems.NewRow

    '        dtItems.Rows.Add(drNewRow)

    '        dgvItems.AllowUserToAddRows = False
    '        dgvItems.CurrentCell = dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD)

    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.ITEM_CD).Value = String.Empty
    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.MIN_QTY_ORD).Value = 0
    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.UNIT_PRICE).Value = DBNull.Value
    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.EQP_PCT).Value = DBNull.Value
    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.RUN_CHARGE).Value = DBNull.Value
    '        dgvItems.Rows(dgvItems.Rows.Count - 1).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = Guid.NewGuid()

    '        dgvItems.Focus()

    '        For Each oHidden In colHidden
    '            dgvItems.Rows(CInt(oHidden.ToString)).Visible = False
    '        Next

    '        dgvItems.BeginEdit(True)

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    'Private Sub dgvItems_LostFocus(sender As Object, e As System.EventArgs) Handles dgvItems.LostFocus

    '    Try
    '        'dgvItems.EndEdit()

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    Private Sub tsProgramMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsProgramMenu.GotFocus

        Try
            Call EndEdit()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub EndEdit()

        dgvItems.EndEdit()
        '   dgvOptions.EndEdit()
        dgvSetUps.EndEdit()

    End Sub
    Private Function ProgramDate(ByRef time As DateTime) As DateTime

        Dim yearP As Integer
        Dim yearN As Integer

        yearP = time.Year

        '   ProgramDate = time

        yearN = yearP + 1

        '++ID 01.20.2021 commented becasue changed end date logic from  31 JAN to 31 DEC
        'I measn we dont to check which month we have

        Dim strDate As String = ""
        '++ID 01.17.2023 unomented exception for to check in which month we are and depend of peroin add end date
        If Date.Today.Month <= 6 Then
            strDate = "06/30/" & yearP
        Else
            strDate = "12/31/" & yearP ' yearN
        End If

        Dim timet As DateTime = DateTime.Parse(strDate)



        Return timet 'DateTime.Parse(strDate)
        ' ProgramDate = "12/31/" & yearP



    End Function

    Private Sub txtEnd_Dt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEnd_Dt.GotFocus

        Select Case m_Program_Type
            Case "Program"

                If txtEnd_Dt.Text = "" Then txtEnd_Dt.Text = ProgramDate(Date.Today) '(CDate(txtStart_Dt.Text).AddMonths(3))

            Case "Special Pricing"
                If txtEnd_Dt.Text = "" Then txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddMonths(3))
            Case "Quote"
                If txtEnd_Dt.Text = "" Then txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddDays(13))
        End Select

    End Sub

    Private Sub txtEnd_Dt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEnd_Dt.LostFocus

        Try

            'If txtSpector_Cd.Text = String.Empty Then
            '    If IsDate(txtEnd_Dt.Text) Then
            '        txtSpector_Cd.Text = m_Program_BUS.Get_Next_Spector_Cd(CDate(txtEnd_Dt.Text))
            '    End If
            'End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub txtStart_Dt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStart_Dt.GotFocus

        If txtStart_Dt.Text = "" Then txtStart_Dt.Text = Now.Date

    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click

        Call Menu_New()

    End Sub

    Private Sub tsbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOpen.Click

        Call Menu_Open()

    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click

        Dim _chekcedrow As Boolean
        _chekcedrow = False

        Dim myArr() As Int32
        Dim myArrnotsaved() As Int32

        Dim _cpt As Int32 = 0
        Dim _cptNotSaved As Int32 = 0

        For Each dgvRow As DataGridViewRow In dgvItems.Rows
            If dgvRow.Cells(Items.SELECTROW).EditedFormattedValue = True Then

                _chekcedrow = True

                dgvRow.Selected = True

                Try
                    'if is in Pending Pricing Approval
                    If m_Program.Quote_Step_ID = 2 Then
                        MsgBox("You cannot delete row. -" & Program_Type & "- is in Step Pending Pricing Approval. ")
                        Exit Sub
                    End If

                    If dgvRow.Cells(Items.ITEM_CD).Value.ToString = "" Then
                        dgvItems.Rows.Remove(dgvRow)
                    End If

                    Dim iPos As Integer = dgvRow.Index

                    ' We only ask to delete items if they were first saved. 
                    ' Every other Is deleted without asking.

                    If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then

                        m_Item_BUS.Delete(CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
                        m_Item_BUS.DeleteMacolaProgramPricing(dgvRow.Cells(Items.ITEM_CD).Value, m_Program.Cus_Prog_Id)

                        ReDim Preserve myArr(_cpt)
                        myArr(_cpt) = CInt(dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value)
                        _cpt += 1

                        Debug.Print("In the function Menu_Delete- dtItems Rows Count: " & dtItems.Rows.Count - 1)

                    Else
                        Debug.Print("In the function Menu_Delete- dtItems Rows Count: " & dtItems.Rows.Count - 1)
                        '     dtItems.Rows.RemoveAt(iPos)


                        ReDim Preserve myArrnotsaved(_cptNotSaved)
                        myArrnotsaved(_cptNotSaved) = iPos
                        _cptNotSaved += 1

                    End If

                Catch er As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
                End Try


            End If

        Next

        Try

            Dim _param1 As Boolean
            _param1 = False
            'if rows are not checked (SelectedRow) delete only one selected row
            If _chekcedrow = False Then
                Call Menu_Delete()
            Else

                '----------------delete from datagridview not yest saved items 
                If Not myArrnotsaved Is Nothing Then
                    For i As Integer = myArrnotsaved.Length - 1 To 0 Step -1
                        dgvItems.Rows.Remove(dgvItems.Rows(myArrnotsaved(i)))
                    Next
                End If
                '----------------delete from Datable---------------------
                If Not myArr Is Nothing Then
                    For Each ind As Integer In myArr

                        For Each dr As DataRow In dtItems.Rows
                            If _param1 <> True Then
                                If dr("CUS_PROG_ITEM_LIST_ID") = ind Then

                                    dr.Delete()
                                    _param1 = True 'parameter added for do not continue to enter in if block
                                    Exit For
                                End If
                            End If
                        Next
                        _param1 = False
                        dtItems.AcceptChanges()
                    Next

                End If

                '   Refresh_C = True
                dgvItems.Refresh()
                '  Call Menu_Refresh()


                Call DiscoColorRows()


                Call dgvItems_C_Subst_item()



            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Dim Refresh_C As Boolean = False

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Refresh_C = True
        dgvItems.Refresh()
        Call Menu_Refresh()

    End Sub

    Private Sub Menu_New()

        Try

            If m_Program_Type = "Quotes" Then
                If m_Program.Quote_Step_ID > 3 Then
                    MsgBox("Prices have been approved, you cannot add new items.")
                    Exit Sub
                End If

            ElseIf m_Program_Type = "Program" Then
                If Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then

                    '++ID3.7.2018 commetn
                    '    MsgBox("Prices have been approved, you cannot add new items.")
                    '   Exit Sub
                End If
            End If

            '---------------------------------------------------------------------
            If dgvItems.Rows.Count > 0 Then
                Dim lst As List(Of ListPopulate) = New List(Of ListPopulate)
                Dim olst As ListPopulate
                Dim strMessage As String = ""

                For Each dr As DataGridViewRow In dgvItems.Rows

                    If String.IsNullOrWhiteSpace(Trim(dr.Cells(Items.ITEM_NO).Value)) = True And dr.Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") <> True And String.IsNullOrEmpty(dr.Cells(Items.ITEM_CD).Value) = False Then
                        olst = New ListPopulate(Trim(dr.Cells(Items.ITEM_CD).Value), Trim(dr.Cells(Items.ITEM_DESC).Value))

                        lst.Add(olst)
                    End If
                Next

                'need put exit sub in the case if value item_no is empty

                If lst.Count <> 0 Then

                    For Each l As ListPopulate In lst
                        strMessage &= "Required field : SKU and Color for Item - " & l.ID & vbCrLf
                    Next

                    MsgBox(strMessage)

                    Exit Sub
                End If


            End If

            '--------------------------------------------------------------------



            Call m_Program_BUS.ItemLineInsert(dgvItems, dtItems)




            'Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Open()

        Try

            'Call FillGrid()
            'Call ApplyFilters()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Delete()

        Try
            'if is in Pending Pricing Approval
            If m_Program.Quote_Step_ID = 2 Then
                MsgBox("You cannot delete row. -" & Program_Type & "- is in Step Pending Pricing Approval. ")
                Exit Sub
            End If

            If dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString = "" Then

                dgvItems.Rows.Remove(dgvItems.CurrentRow)

                Exit Sub
            End If


            Dim iPos As Integer = dgvItems.CurrentRow.Index

            ' We only ask to delete items if they were first saved. 
            ' Every other Is deleted without asking.

            If Not (dgvItems.CurrentRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then

                If Trim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString) <> "" Then

                    Dim mbrOkToDelete As MsgBoxResult
                    mbrOkToDelete = MsgBox("Delete Row ?", MsgBoxStyle.YesNo, "Delete Row ")

                    If mbrOkToDelete = MsgBoxResult.No Then Exit Sub
                    Select Case mbrOkToDelete
                        Case MsgBoxResult.No
                            Exit Sub
                        Case MsgBoxResult.Yes
                            m_Item_BUS.Delete(CInt(dgvItems.Rows(iPos).Cells(Items.CUS_PROG_ITEM_LIST_ID).Value))
                            m_Item_BUS.DeleteMacolaProgramPricing(dgvItems.Rows(iPos).Cells(Items.ITEM_CD).Value, m_Program.Cus_Prog_Id)

                            Debug.Print("In the function Menu_Delete- dtItems Rows Count: " & dtItems.Rows.Count - 1)
                            dtItems.Rows.RemoveAt(iPos)


                    End Select
                End If
            Else
                Debug.Print("In the function Menu_Delete- dtItems Rows Count: " & dtItems.Rows.Count - 1)
                dtItems.Rows.RemoveAt(iPos)
            End If

            '  Call ChangeStatusForPrograms()

            dgvItems.Focus()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Refresh()

        Call dgvItems_Fill()

        'dgvItems_Validation Items.Item_CD
        Refresh_C = False

        '  Call FillGrid()
        'Call ApplyFilters()

    End Sub

    Private Sub dgvItems_CellContextMenuStripChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellContextMenuStripChanged

    End Sub

    '++ID 12.1.15
    Private Sub dgvItems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick
        Try
            If e.ColumnIndex = Items.Image Then

                If Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) = "" Then
                    Debug.Print("dgvItems_CellDoubleClick :     If Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) <> "" ")
                Else
                    Select Case dgvItems.CurrentRow.Cells(Items.DocId).Value
                        Case 0
                            Debug.Print("dgvItems_CellDoubleClick :    Case 0")
                        Case Is > 0
                            Debug.Print("dgvItems_CellDoubleClick :    Case Is > 0")
                            Me.Cursor = Cursors.WaitCursor

                            Dim frmPrewiewD As New frmPreviewDoc(dgvItems.CurrentRow.Cells(Items.DocId).Value)

                            frmPrewiewD.Show()
                            Me.Cursor = Cursors.Default
                    End Select

                End If

            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit

        'justin 20190910
        Call dgvItems_C_Subst_item()

        '    Debug.Print("dgvItems_CellEndEdit" & dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)
        Dim myComboBoxCell As New DataGridViewComboBoxCell
        Try

            'Dim oMdb_Item_VariantColor As cMdb_Item_VariantColor
            'Dim lstVariantColor As List(Of cMdb_Item_VariantColor)
            'Dim oMdb_Cfg_Color_DAL As cMdb_Cfg_Color_DAL

            Dim oOeprcfil_sql As cMacolaOeprcfil_Sql
            Dim item_cd As String
            Select Case e.ColumnIndex
                Case Items.UNIT_PRICE
                    If dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") = True Then Exit Sub

                    'if cell is empty or is ot numeric
                    If Microsoft.VisualBasic.Information.IsNumeric(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value) = False Then
                        dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = priceValidate 'priccevalidate come from Validating event in the case if is nothing in cell
                    Else

                        If String.IsNullOrEmpty(Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString))) = True Then Exit Sub

                        'check if price is not same like in DB, need only ask about is user accept the price and is not a wrong entered data 
                        oOeprcfil_sql = New cMacolaOeprcfil_Sql
                        Dim priceU = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                     Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)),
                     Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)), qty,
                     m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                        If dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value <> priceU Then
                            'MSGBox for ask 
                            'Dim respons As Integer = MessageBox.Show("The price for item no " & dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value.ToString & " is different than regular and Qty : " & dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).FormattedValue.ToString & " , is : " _
                            '    & FormatNumber(priceU, 2).ToString() & "$. If you want return to regular price click Yes.  ", "Alert! ", MessageBoxButtons.YesNo)

                            Dim respons As Integer = MessageBox.Show("Price for item no " & dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value.ToString & " changed : new price " & FormatNumber(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value, 2).ToString() & "$ - previous price " _
                          & FormatNumber(priceU, 2).ToString() & "$. If you want Return Previous price click Yes.  ", "Note. ", MessageBoxButtons.YesNo)



                            If respons = DialogResult.Yes Then
                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = priceU
                            ElseIf respons = DialogResult.No Then
                                '      dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                            End If

                        End If
                    End If
                    'priceValidate

                Case Items.MIN_QTY_ORD
                    Dim price As Decimal
                    oOeprcfil_sql = New cMacolaOeprcfil_Sql

                    '++ID added exception with Special Pricin Quote Step like for Item Color
                    'do not need made event changes while execution for certain steps 
                    '++ID 12.05.2015 PRIX ---------
                    If m_Program_Type <> "Special Pricing" And (Quote_Step.New_Quote Or Quote_Step.Saved_Quote) = m_Program.Quote_Step_ID Then
                        Try


                            If Microsoft.VisualBasic.Information.IsNumeric(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value) Then

                                'exception added because if user remove qty and cell become emty validating event return qty with old value(before empty)

                                If Microsoft.VisualBasic.Information.IsNumeric(dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value) = False Then
                                    dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = qty
                                Else
                                    qty = dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value
                                End If

                                If dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value > 0 Then

                                    price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                     Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)),
                     Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)), qty,
                     m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                                    '++ID calcule les purcentage si le cas
                                    If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value = False Then

                                        If dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value <> price Then
                                            'MSGBox for ask 
                                            '   Dim respons As Integer = MessageBox.Show("The price for item no " & dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value.ToString & " is different than regular and Qty : " & dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).FormattedValue.ToString & " , is : " _
                                            '++ ID 01.18.2021 commented
                                            '  Dim respons As Integer = MessageBox.Show("Price for item no " & dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value.ToString & " changed : from  " & FormatNumber(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value, 2).ToString() & " to " _
                                            '& FormatNumber(price, 2).ToString() & "$. If you want Return Previous price click Yes.  ", "Note. ", MessageBoxButtons.YesNo)

                                            '  ' & FormatNumber(price, 2).ToString() & "$. If you want Return To regular price click Yes.  ", "Alert! ", MessageBoxButtons.YesNo)

                                            '  If respons = DialogResult.Yes Then
                                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                            '  ElseIf respons = DialogResult.No Then
                                            '      '      dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                                            '  End If

                                        End If




                                    Else
                                        Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                                            Case "0"
                                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                            Case ""
                                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                            Case Else
                                                price = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                        End Select
                                    End If
                                    '------------------------------
                                    '++ID 29.12.14
                                End If
                            Else
                                MsgBox("Price field need To be numeric value (Like /0..->..9/).")
                            End If
                        Catch ex As Exception
                            MsgBox("Error in " & Me.Name & ". Exception for Price type is numeric." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        End Try
                    Else
                        If Microsoft.VisualBasic.Information.IsNumeric(dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value) = False Then
                            dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = qty
                        Else
                            qty = dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value
                        End If



                    End If
                Case Items.ITEM_COLOR
                    '------------------------------------Work with All SKU---------------------------------------------
                    'If Trim(dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue) = "ALL" _
                    'And Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper)) <> "CUSTOM" _
                    'And Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper)) <> "ALL ITEMS" Then
                    '++ID 3.30.2018 added 'custom' validation for open all sku form



                    If (Trim(dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue) = "ALL" Or Trim(dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue) = "") _
                    And dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") <> True Then

                        Dim dtItemsCountBefore As Int32 = dtItems.Rows.Count
                        Dim currentRowIndex As Int32 = dgvItems.CurrentRow.Index

                        Dim frmAll As New frmAllsku(Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)),
                                                   Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value.ToString)),
                                                   dtItems, m_Program, m_Customer)
                        Dim f = frmAll.ShowDialog()

                        'delete currentrow which content of the item_color is "ALL"
                        'If Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString)) = "ALL" And
                        '    (Trim(RTrim(dgvItems.CurrentRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.ToString)) = String.Empty _
                        '   Or Trim(RTrim(dgvItems.CurrentRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.ToString)) = "0") Then
                        'delete current line with All color Option

                        dgvItems.Rows.RemoveAt(currentRowIndex)


                        'Execute this only if they add line
                        If (dtItemsCountBefore - 1) <> dtItems.Rows.Count Then

                            ' Call tsbSave_Click(sender, e)
                            ' Call Save()

                            dgvItems.DataSource = Nothing
                            '   dgvItems.Columns.Clear()

                            Refresh_C = True
                            Call dgvItems_CreateColumns()

                            dgvItems.DataSource = dtItems

                            Call ValidateColorList()

                            m_Saved = False
                            '     dgvItems.Refresh()

                            Select Case m_Program_Type
                                Case "Quote"
                                    dgvItems.Columns(Items.CUSTOM_ITEM_ID).Visible = m_Program_BUS.ContainsCustomItems(m_Program)
                                    dgvItems.Columns(Items.NEED_APPROVAL).Visible = False

                                    dgvItems.Columns(Items.EQP_LEVEL).Visible = False
                                    dgvItems.Columns(Items.EQP_PCT).Visible = False

                                Case "Special Pricing"
                                    dgvItems.Columns(Items.LINE_COMMENTS).Visible = False
                                    dgvItems.Columns(Items.NEED_APPROVAL).Visible = False

                                    dgvItems.Columns(Items.EQP_LEVEL).Visible = False
                                    dgvItems.Columns(Items.EQP_PCT).Visible = False

                                Case "Program"
                                    dgvItems.Columns(Items.LINE_COMMENTS).Visible = False
                                    '  Call ChangeStatusForPrograms()
                            End Select


                            'dgvItems.Refresh()
                            'Call Menu_Refresh()
                        End If
                        'justin 20190916 for flash new display for the column: item_substitute
                        Call dgvItems_C_Subst_item()
                        '    Exit Sub
                        'End If

                        Exit Sub

                    Else
                        ' 'oMdb_Item_VariantColor = New cMdb_Item_VariantColor
                        ' 'lstVariantColor = New List(Of cMdb_Item_VariantColor)
                        ' oMdb_Cfg_Color_DAL = New cMdb_Cfg_Color_DAL

                        ' oMdb_Cfg_Color_DAL.LoadByCode(Trim(dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue))
                        '' dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value = oMdb_Cfg_Color_DAL.


                    End If
                    '-----------------------------------------------------------------
                    '++ID 06.07.2016 we don't need change price by Item color because this is not our item, this means we have not sku for him
                    'If Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper)) = "CUSTOM" _
                    '    Or Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper)) = "custom" Then Exit Sub

                    '3.30.2018
                    If dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") = True Then Exit Sub



                    Dim price As Decimal

                    'display item_no for put in colon sku
                    'for use  combobox cel need change ind for populate dropdown item color because it have not id .....
                    'Dim comboboxCellrec As New DataGridViewComboBoxCell
                    'comboboxCellrec = DirectCast(dgvItems.Item(CInt(Items.ITEM_COLOR), e.RowIndex), DataGridViewComboBoxCell)

                    'justin 20200106 For restore color name display as befor(no color code at the end of combobox) if end editcell'' 
                    Dim item_no = displayItemNo(Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)), Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)))
                    dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value = item_no



                    Dim _disco As String = ""

                    _disco = CheckDiscoProp(item_no)

                    If _disco.Length > 0 Then
                        ' dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value = item_no & "-" & _disco
                        dgvItems.CurrentRow.Cells(Items.DISCO).Value = Trim(_disco)
                        ' dgvItems.CurrentRow = Color.Red
                        dgvItems.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                    Else
                        If dgvItems.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red Then
                            dgvItems.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                        End If

                    End If

                        '++ID 01.17.2023 check to add  function to insert min qty in Program oItem.Min_Qty_Ord

                        Select Case m_Program_Type
                        Case "Program"
                            'item_no
                            dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = prog_min_qty(item_no, Trim(txtCurr_Cd.Text))

                    End Select


                    'set combobox back to color_name as before after update item_no
                    Call SetBackColorCombo(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR), dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString, dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)  'justin20200106

                    '------------------------------------
                    oOeprcfil_sql = New cMacolaOeprcfil_Sql


                    '    item_cd = dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.PadRight(6, "0")

                    item_cd = dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString
                    Debug.Print(item_cd)

                    If dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = 0 Or Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value.ToString)) = String.Empty Then

                        oOeprcfil_sql.LoadMinQty(txtCurr_Cd.Text,
                     Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)),
                     Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString)))
                        Debug.Print(oOeprcfil_sql.Minimum_Qty_2)

                        dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = oOeprcfil_sql.Minimum_Qty_2
                    End If



                    '++ID 11.05.2015 PRIX ---------

                    Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value.ToString
                        Case ""
                            dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value = False
                    End Select

                    price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                        dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                        Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value,
                        m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                    'If (Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value.ToString)) = String.Empty Or
                    '  dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = 0 Then

                    If String.IsNullOrEmpty(Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value.ToString))) = True Then

                        '++ID calcule les purcentage si le cas
                        If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value Then

                            Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                                Case "0"
                                    dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                Case ""
                                    dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                Case Else
                                    price = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                                    dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                            End Select
                        Else
                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                        End If
                        '------------------------------
                    Else
                        'if in the cell price already have one price
                        Dim p As Decimal
                        '++ID calcule les purcentage si le cas
                        If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value Then

                            Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                                Case "0"
                                    p = price
                                Case ""
                                    p = price
                                Case Else
                                    p = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                            End Select
                        Else
                            p = price
                        End If

                        '20201102 justin add01
                        dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                        '

                        '++ID new exception by Quote Step
                        'because If is in Pending, Or  Aproved or 
                        If m_Program_Type <> "Special Pricing" And ((CInt(Quote_Step.New_Quote)) = m_Program.Quote_Step_ID Or (CInt(Quote_Step.Saved_Quote)) = m_Program.Quote_Step_ID) Then
                            'message if price is diferent lilke in db it will repeate this things each time when you touch cbo lolor
                            If dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value <> p Then
                                'The Unit Price it will be changed
                                '   & FormatNumber(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value, 2).ToString() & "$" & " => "
                                '++ID commented 01.18.2020
                                'Dim result As Integer = MessageBox.Show("Regular price for item no " & item_no & " and Qty : " & dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).FormattedValue.ToString & " , is : " _
                                '                   & FormatNumber(p, 2).ToString() & "$. If you want return to regular price click Yes.  ", "Alert! ", MessageBoxButtons.YesNo)
                                'If result = DialogResult.Yes Then
                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                                'ElseIf result = DialogResult.No Then
                                '    '      dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                                'End If
                            End If
                        End If
                    End If
                    '  Else
                    Debug.Print("Min_Qty_Ord : " & dgvItems.CurrentRow.Cells(Items.MIN_QTY_ORD).Value.ToString)
                    '    End If
                    '++ID 30.12.14
                Case Items.DEC_MET_ID
                    myComboBoxCell = New DataGridViewComboBoxCell
                    myComboBoxCell = DirectCast(dgvItems.Item(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell)

                    Dim mText As String = myComboBoxCell.FormattedValue.ToString

                    Dim checkBoxCell As DataGridViewCheckBoxCell = DirectCast(dgvItems(Items.SETUP_WAIVED, e.RowIndex), DataGridViewCheckBoxCell)

                    With dgvItems.CurrentRow
                        If Trim(mText) = "DEBOSS" Then

                            .Cells(Items.SETUP_WAIVED).Value = 0

                        End If
                    End With

                    Debug.Print("Decorating : " & mText)
                    '-------------------------------
                Case Items.SETUP_WAIVED

                    '++ID 09.06.2015 added exception for Setup Waived and Special Setup Price 

                    myComboBoxCell = New DataGridViewComboBoxCell
                    myComboBoxCell = DirectCast(dgvItems.Item(Items.DEC_MET_ID, e.RowIndex), DataGridViewComboBoxCell)

                    Dim mText As String = myComboBoxCell.FormattedValue.ToString

                    If mText <> String.Empty Then
                        If Trim(mText) = "DEBOSS" And dgvItems.CurrentRow.Cells(Items.SETUP_WAIVED).Value = True Then
                            ' dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                            dgvItems.Rows(e.RowIndex).Cells(Items.SETUP_PRICE).Value = 0.0 'DBNull.Value
                        ElseIf dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                            dgvItems.Rows(e.RowIndex).Cells(Items.SETUP_PRICE).Value = 0.0
                        ElseIf dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                            dgvItems.Rows(e.RowIndex).Cells(Items.SETUP_PRICE).Value = DBNull.Value
                        End If
                    End If
                Case Items.CHARGE_ID

                    myComboBoxCell = New DataGridViewComboBoxCell
                    myComboBoxCell = DirectCast(dgvItems.Item(Items.CHARGE_ID, e.RowIndex), DataGridViewComboBoxCell)



                    Dim c As Decimal = PriceRunCharge(CInt(myComboBoxCell.Value))

                    dgvItems.Rows(e.RowIndex).Cells(Items.RUN_CHARGE).Value = c ' PriceRunCharge(PriceRunCharge(CInt(myComboBoxCell.Value)))
                    '++ID 13.05.2015-----------------------------------
                Case Items.EQP_LEVEL

                    Dim price As Decimal
                    oOeprcfil_sql = New cMacolaOeprcfil_Sql

                    '++ID 12.05.2015 PRIX ---------

                    If dgvItems.CurrentRow.Cells(Items.EQP_LEVEL).Value Then
                        dgvItems.CurrentRow.Cells(Items.EQP_PCT).ReadOnly = False


                    ElseIf Not dgvItems.CurrentRow.Cells(Items.EQP_LEVEL).Value Then
                        dgvItems.CurrentRow.Cells(Items.EQP_PCT).Value = 0.0
                        dgvItems.CurrentRow.Cells(Items.EQP_PCT).ReadOnly = True
                        dgvItems.Rows(e.RowIndex).Cells(Items.NEED_APPROVAL).Value = False

                        'enough validation for the price
                        'price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                        '                   dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                        '                   Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value,
                        '                   m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                        'dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price


                        '             price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text), _
                        'dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString, _
                        'Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value, _
                        'm_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                        '             dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price

                    End If



                Case Items.EQP_PCT



                    Dim price As Decimal

                    oOeprcfil_sql = New cMacolaOeprcfil_Sql

                    '++ID 12.05.2015 PRIX ---------

                    '++ID calcule les purcentage si le cas
                    If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value <> False Then
                        '  dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                        '   Else

                        Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                            Case "0"

                                dgvItems.Rows(e.RowIndex).Cells(Items.NEED_APPROVAL).Value = False

                                price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                                         dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                                         Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value, m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)
                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price

                            Case ""
                                dgvItems.Rows(e.RowIndex).Cells(Items.NEED_APPROVAL).Value = False

                                price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                                     dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                                     Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value, m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)
                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value = 0.0
                            Case Else

                                'this means value in EQP Price is more like 0
                                'in this case need activate Need_Approval
                                If SuperuserIdentify() <> True Then dgvItems.Rows(e.RowIndex).Cells(Items.NEED_APPROVAL).Value = True


                                price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                                           dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                                           Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value,
                                           m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                                price = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price

                                'tsbNextStep.Visible = True
                                'tsbExport.Visible = False

                        End Select

                    End If

                Case Items.SETUP_WAIVED
                    With dgvItems.CurrentRow
                        If Trim(dgvItems.CurrentRow.Cells(Items.DEC_MET_ID).FormattedValue.ToString) = "DEBOSS" Then
                            .Cells(Items.SETUP_WAIVED).Value = 0
                            '  Else
                            '        .Cells(Items.SETUP_WAIVED).Value = 1
                        End If
                    End With

                    Debug.Print(dgvItems.CurrentRow.Cells(Items.DEC_MET_ID).FormattedValue.ToString)

                    ''20201102 justin add:02
                Case Items.ITEM_NO
                    Dim orginal_item_no = dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_NO).Value
                    If orginal_item_no <> "" And orginal_item_no.ToString.Length = 11 Then
                        Dim dt_orginal_color_code As DataTable
                        dt_orginal_color_code = Getorignal_color_id(orginal_item_no) 'dt
                        dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value = dt_orginal_color_code.Rows(0).ItemArray(0).ToString()

                        ''''''''''
                        Dim price As Decimal
                        Dim item_no = displayItemNo(Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)), Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)))
                        dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value = item_no





                        'set combobox back to color_name as before after update item_no
                        Call SetBackColorCombo(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR), dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString, dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)  'justin20200106

                            oOeprcfil_sql = New cMacolaOeprcfil_Sql
                            item_cd = dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString

                            If dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = 0 Or Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value.ToString)) = String.Empty Then
                                oOeprcfil_sql.LoadMinQty(txtCurr_Cd.Text,
                            Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)),
                            Trim(RTrim(dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value.ToString)))
                                dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value = oOeprcfil_sql.Minimum_Qty_2
                            End If


                            Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value.ToString
                                Case ""
                                    dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value = False
                            End Select

                            price = oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text),
                        dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString,
                        Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value,
                        m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

                            If String.IsNullOrEmpty(Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value.ToString))) = True Then

                                If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value Then

                                    Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                                        Case "0"
                                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                        Case ""
                                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                        Case Else
                                            price = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                    End Select
                                Else
                                    dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = price
                                End If
                                '------------------------------
                            Else
                                'if in the cell price already have one price
                                Dim p As Decimal
                                '++ID calcule les purcentage si le cas
                                If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value Then

                                    Select Case dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value.ToString
                                        Case "0"
                                            p = price
                                        Case ""
                                            p = price
                                        Case Else
                                            p = price - ((price / 100) * dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).Value)
                                    End Select
                                Else
                                    p = price
                                End If

                                dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p

                                '++ID new exception by Quote Step
                                'because If is in Pending, Or  Aproved or 
                                If m_Program_Type <> "Special Pricing" And ((CInt(Quote_Step.New_Quote)) = m_Program.Quote_Step_ID Or (CInt(Quote_Step.Saved_Quote)) = m_Program.Quote_Step_ID) Then
                                    'message if price is diferent lilke in db it will repeate this things each time when you touch cbo lolor
                                    If dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value <> p Then
                                        'The Unit Price it will be changed
                                        '   & FormatNumber(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value, 2).ToString() & "$" & " => "

                                        '++ID 01.18.2021 commented
                                        'Dim result As Integer = MessageBox.Show("Regular price for item no " & item_no & " and Qty : " & dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).FormattedValue.ToString & " , is : " _
                                        '               & FormatNumber(p, 2).ToString() & "$. If you want return to regular price click Yes.  ", "Alert! ", MessageBoxButtons.YesNo)


                                        Dim respons As Integer = MessageBox.Show("Price for item no " & dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value.ToString & " changed : new price " & FormatNumber(dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value, 2).ToString() & "$ - previous price " _
                          & FormatNumber(p, 2).ToString() & "$. If you want Return Previous price click Yes.  ", "Note. ", MessageBoxButtons.YesNo)


                                        If respons = DialogResult.Yes Then
                                            dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                                        ElseIf respons = DialogResult.No Then
                                            '      dgvItems.Rows(e.RowIndex).Cells(Items.UNIT_PRICE).Value = p
                                        End If
                                    End If
                                End If
                            End If
                            ''''''''''
                        End If


            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    '---------------- displayItemNo for display in dgvItem in item colon--------------------
    'Private Function displayItemNo(ByVal strItemCode As String, ByVal strItemColor As String) As String
    '    displayItemNo = ""
    '    Try
    '        db = New cDBA
    '        Dim strSql As String
    '        Dim dt As DataTable

    '        strSql =
    '            " SELECT ITEM_NO FROM imitmidx_sql  WITH (Nolock) " &
    '            " WHERE user_def_fld_1 = '" & strItemCode & "'  and user_def_fld_2 = '" & strItemColor & "'"
    '        '++ID 1.18.2018 from MDB
    '        strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
    '            & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
    '            & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '" & strItemCode & "'  and c.COLOR_NAME = '" & strItemColor & "'"



    '        dt = db.DataTable(strSql)

    '        If dt.Rows.Count <> 0 Then
    '            displayItemNo = Trim(RTrim(dt.Rows(0).Item("ITEM_NO").ToString))

    '        Else
    '            strSql =
    '         " SELECT ITEM_NO FROM imitmidx_sql  WITH (Nolock) " &
    '         " WHERE  user_def_fld_1 = '66" & strItemCode & "'  and user_def_fld_2 = '" & strItemColor & "'"

    '            '++ID 1.18.2018 from MDB
    '            strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
    '            & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
    '            & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '66" & strItemCode & "'  and c.COLOR_NAME = '" & strItemColor & "'"

    '            dt = db.DataTable(strSql)

    '            If dt.Rows.Count <> 0 Then
    '                displayItemNo = Trim(RTrim(dt.Rows(0).Item("ITEM_NO").ToString))
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Function

    Private Sub dgvItems_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvItems.CellMouseDoubleClick

        Debug.Print("dgvItems_CellMouseDoubleClick")
        Debug.Print("Items.CUS_PROG_ID : " & dgvItems.CurrentRow.Cells(Items.CUS_PROG_ID).Value.ToString())
        Debug.Print("Current Cell Value : " & dgvItems.CurrentCell.Value.ToString())
    End Sub
    '++ID 9.1.15
    Private Sub AddDocumentFiles(ByRef Files As String(), ByVal pDocId As Int32)

        Try
            Dim str As String
            panProgress.Visible = True

            pbProgress.Value = 0
            pbProgress.Maximum = Files.Length

            txtPBEvent.Refresh()

            ' Loop through the array and add the files to the list.
            For Each strFile As String In Files

                str = strFile.Substring(strFile.LastIndexOf("\") + 1)

                str = str.Substring(str.LastIndexOf(".") + 1) 'if is format image


                Select Case str
                    Case "JPG", "jpg", "JPEG", "jpeg", "GIF", "gif", "PNG", "png", "BMP", "bmp"

                        txtPBDocument.Text = strFile
                        txtPBDocument.Refresh()

                        Dim oExact_Traveler_Doc As New cEXACT_TRAVELER_DOCUMENT(strFile, pDocId)

                        If pDocId > 0 Then
                            oExact_Traveler_Doc.Save()
                        Else
                            oExact_Traveler_Doc.Ord_No = ""
                            oExact_Traveler_Doc.DocType = "Custom item pictures "
                            oExact_Traveler_Doc.DocTypeID = 39
                            oExact_Traveler_Doc.HeaderID = 0


                            oExact_Traveler_Doc.Save()
                            dgvItems.Rows(intRowIndexMouseMove).Cells(Items.DocId).Value = oExact_Traveler_Doc.DocID
                            pbProgress.Increment(1)
                            panProgress.Invalidate()
                        End If

                    Case Else
                        MsgBox("Don't support this format : " & str & "." & vbCrLf &
                               " Only 'JPG', 'jpg', 'JPEG', 'jpeg', 'GIF', 'gif', 'PNG', 'png', 'BMP', 'bmp' ")

                End Select
            Next
            '  Threading.Thread.Sleep(2000)


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            panProgress.Visible = False
        End Try

    End Sub
    '++ID 9.1.15
    Private Sub dgvItems_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvItems.DragDrop
        Try
            If m_Program_Type = "Quote" Then
                Debug.Print("dgvItems_DragDrop : CurrentRow " & intRowIndexMouseMove.ToString)

                Dim index As Int32 = dgvItems.Rows(intRowIndexMouseMove).Index

                Debug.Print("dgvItems_DragDrop dgvItems.RowIndex : " & index.ToString)

                Dim MyFiles() As String

                If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                    ' Assign the files to an array.
                    MyFiles = e.Data.GetData(DataFormats.FileDrop)

                    If Trim(dgvItems.Rows(index).Cells(Items.DocId).Value.ToString) = "" Then
                        Call AddDocumentFiles(MyFiles, 0)
                    Else
                        Select Case dgvItems.Rows(index).Cells(Items.DocId).Value
                            Case 0
                                Call AddDocumentFiles(MyFiles, 0)
                            Case Is > 0
                                Call AddDocumentFiles(MyFiles, dgvItems.Rows(index).Cells(Items.DocId).Value)
                        End Select
                    End If


                    '++ID 13.1.15
                    Call cellDocIdPropr()

                End If
            End If



        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    '++ID 9.1.15 drag
    Private Sub dgvItems_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvItems.DragEnter
        Try

            If m_Program_Type = "Quote" Then
                If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                    e.Effect = DragDropEffects.All
                ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then 'For email Drag & Drop 
                    e.Effect = DragDropEffects.Copy
                End If
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID  9.1.15
    Private Sub dgvItems_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvItems.MouseMove
        Try

            '  If (e.Button & MouseButtons.Left) <> MouseButtons.Left Then
            'Debug.Print("dgvItems_MouseMove :  X." & e.X & vbCrLf & "Y." & e.Y)

            'Dim hti As DataGridView.HitTestInfo = dgvItems.HitTest(e.X, e.Y)

            'If hti.RowIndex = -1 Then

            '    Exit Sub
            'End If


            'dgvItems.Rows(hti.RowIndex).Selected = True

            'intRowIndexMouseMove = dgvItems.Rows(hti.RowIndex).Index

            'Debug.Print("dgvItems_MouseMove dgvComm.RowIndex : " & intRowIndexMouseMove.ToString)

            '  End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    ', dgvOptions.Validating
    Private Sub SetUnsaved() Handles dgvItems.Validating, txtCus_No.Validating, txtEnd_Dt.Validating, txtImprint.Validating, txtProg_Cd.Validating, txtProg_Comments.Validating, txtProg_CSR.Validating, txtQuote_Step_ID.Validating, txtQuote_Step_User.Validating, txtSpector_Cd.Validating, txtStart_Dt.Validating, cboContact_ID.Validating, cboProg_Type.Validating

        m_Saved = False

    End Sub

#Region "PRIVATE EVENTS - DATAGRIDVIEW ########################################"

    Private Sub dgvItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvItems.CellBeginEdit

        Debug.Print("dgvItems_CellBeginEdit" & dgvItems.CurrentRow.Cells(Items.UNIT_PRICE).Value.ToString)

        Try

            'If blnFill Then Exit Sub

            ' Les Colonnes doivent etre programm‚es pour etre activ‚es. 
            ' Le ELSE fait un cancel = true
            '++ID 12.14.2017 Added Or m_Program_Type = .....
            If m_Program_Type = "Quote" Then
                If e.ColumnIndex = Items.LINE_COMMENTS Then
                    Debug.Print("OK")
                ElseIf m_Program.Quote_Step_ID >= Quote_Step.Sent_To_Customer Then
                    MsgBox("Quote was sent to customer, you cannot edit items.")
                    e.Cancel = True
                ElseIf m_Program.Quote_Step_ID >= Quote_Step.Pricing_Approved Then
                    '++ID 1.12.2018 exception for item color because in masterdatabase color name is diferent 
                    ' And this give posubility for vhange in the case if Is aproved already
                    If e.ColumnIndex <> Items.ITEM_COLOR Then
                        MsgBox("Prices have been approved, you cannot edit items.")
                        e.Cancel = True
                    End If

                ElseIf m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then
                    ' Check if user is autorized for entering data here
                    Dim strSql As String =
                    "SELECT     * " &
                    "FROM       MDB_CFG_QUOTE_PROC_USER WITH (Nolock) " &
                    "WHERE      QUOTE_TYPE_ID = " & m_Program.Quote_Type_ID & " AND " &
                    "           QUOTE_STEP_ID = " & m_Program.Quote_Step_ID & " AND " &
                    "           SCREEN_USER = '" & Environment.UserName & "' "
                    Dim dtPerm As DataTable = db.DataTable(strSql)
                    If dtPerm.Rows.Count = 0 Then
                        MsgBox("Prices are currently in the process of being entered and approved, you cannot edit items.")
                        e.Cancel = True
                    End If
                End If
                '++ID 12.18.2017 new excpetion for program, almost same like for Quote but little bit reduced
            ElseIf m_Program_Type = "Program" Then

                'If m_Program.Quote_Step_ID = Quote_Step.Pricing_Approved Then
                '    MsgBox("Prices have been approved, you cannot edit items.")
                '    e.Cancel = True
                'Else
                If m_Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then
                    ' Check if user is autorized for entering data here
                    Dim strSql As String =
                    "SELECT     * " &
                    "FROM       MDB_CFG_QUOTE_PROC_USER WITH (Nolock) " &
                    "WHERE      QUOTE_TYPE_ID = " & m_Program.Quote_Type_ID & " AND " &
                    "           QUOTE_STEP_ID = " & m_Program.Quote_Step_ID & " AND " &
                    "           SCREEN_USER = '" & Environment.UserName & "' "
                    Dim dtPerm As DataTable = db.DataTable(strSql)
                    If dtPerm.Rows.Count = 0 Then
                        MsgBox("Prices are currently in the process of being entered and approved, you cannot edit items.")
                        e.Cancel = True
                    End If
                End If

            End If

            Select Case e.ColumnIndex

                Case Items.USER_LOGIN
                    e.Cancel = True

                Case Items.ITEM_CD

                    If Not dgvItems.CurrentRow.Cells(Items.PROD_CAT_ID).Value.Equals(DBNull.Value) Then
                        If dgvItems.CurrentRow.Cells(Items.PROD_CAT_ID).Value <> 0 Then
                            MsgBox("You cannot change the item code When selecting a category Of items.")
                            e.Cancel = True
                        End If
                    End If

                Case Items.UNIT_PRICE
                    If Not dgvItems.CurrentRow.Cells(Items.PROD_CAT_ID).Value.Equals(DBNull.Value) Then
                        If dgvItems.CurrentRow.Cells(Items.PROD_CAT_ID).Value <> 0 Then
                            MsgBox("You cannot enter a price For a category Of items.")
                            e.Cancel = True
                        End If
                    End If

                Case Items.LINE_COMMENTS
                    e.Cancel = True

            End Select

        Catch er As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellClick

        Try
            'justin 20190910
            Call dgvItems_C_Subst_item()
            '

            Select Case e.ColumnIndex

                Case Items.LINE_COMMENTS

                    If m_Program_Type = "Quote" And m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer Then Exit Sub

                    Try

                        Dim ofrm As frmQuote_Comments
                        ofrm = New frmQuote_Comments(m_Customer, m_Program, dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString, dgvItems.Rows(e.RowIndex).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value.ToString)
                        ofrm.ShowDialog()
                        ofrm.Save()
                        ofrm.Dispose()
                        dgvItems.Rows(e.RowIndex).Cells(Items.LINE_COMMENTS).Style.BackColor = QuoteCommentColor(m_Program.Cus_Prog_Guid, dgvItems.Rows(e.RowIndex).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value.ToString)

                    Catch er As Exception
                        MsgBox("Error In COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
                    End Try
                '++ID 22.1.15
                Case Items.Image

                    If Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) = "" Then
                        Debug.Print("dgvItems_CellClick :   If Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) <> "" ")
                    ElseIf Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) = "0" Then
                        Debug.Print("dgvItems_CellClick :   If Trim(dgvItems.CurrentRow.Cells(Items.DocId).Value.ToString) <> "" ")
                    Else
                        Select Case dgvItems.CurrentRow.Cells(Items.DocId).Value
                            Case 0
                                Debug.Print("dgvItems_CellDoubleClick :    Case 0")
                            Case Is > 0
                                Debug.Print("dgvItems_CellDoubleClick :    Case Is > 0")
                                Me.Cursor = Cursors.WaitCursor

                                Dim frmPrewiewD As New frmPreviewDoc(dgvItems.CurrentRow.Cells(Items.DocId).Value)

                                frmPrewiewD.Show()
                                Me.Cursor = Cursors.Default
                        End Select
                    End If
                Case Items.EQP_PCT

                    If dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value Then
                        dgvItems.Rows(e.RowIndex).Cells(Items.EQP_PCT).ReadOnly = False
                    End If

                Case Items.UNIT_PRICE
                    'justin 20190910 add 
                Case Items.ITEM_SUBSTITUTE
                    If e.RowIndex < 0 Then
                        Exit Sub
                    End If
                    Dim ofrm As New Frm_item_substitute(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString)
                    ofrm.StartPosition = FormStartPosition.Manual

                    'postion_in the form
                    Dim Cellx As Int16 = Me.dgvItems.GetCellDisplayRectangle(Me.dgvItems.CurrentCell.ColumnIndex, Me.dgvItems.CurrentCell.RowIndex, False).Left + Me.dgvItems.Location.X + Me.dgvItems.Margin.Left + Me.gbProgramItems.Location.X + Me.gbProgramItems.Margin.Left
                    Dim Celly As Int16 = Me.dgvItems.GetCellDisplayRectangle(Me.dgvItems.CurrentCell.ColumnIndex, Me.dgvItems.CurrentCell.RowIndex, False).Top + Me.dgvItems.Location.Y + Me.dgvItems.Margin.Top + Me.gbProgramItems.Location.Y + Me.gbProgramItems.Margin.Top + Me.tsProgramMenu.Size.Height + Me.Margin.Top + 3

                    ofrm.FormBorderStyle = FormBorderStyle.Fixed3D 'disable resizing of a form
                    ofrm.StartPosition = FormStartPosition.CenterParent
                    ofrm.Location = New System.Drawing.Size(Cellx, Celly - 95)

                    ofrm.ShowDialog()

                    Call dgvItems_C_Subst_item()
            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvItems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellEnter

        Debug.Print("dgvItems_CellEnter")

        Try
            If dgvItems.Rows.Count = 0 Then Exit Sub
            'fill color cell



            If e.ColumnIndex = Items.ITEM_COLOR Then

                '    If Not (dgvRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value.Equals(DBNull.Value)) Then

                'justin add 20200106 for initial color_name+code from item_no''
                '    Dim orginal_item_no = dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_NO).Value

                Dim orginal_item_no As String = ""
                If Not (dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_NO).Value.Equals(DBNull.Value)) Then

                    If orginal_item_no <> "" And orginal_item_no.ToString.Length = 11 Then
                        Dim dt_orginal_color_code As DataTable
                        dt_orginal_color_code = Getorignal_color_id(orginal_item_no) 'dt
                        dgvItems.CurrentCell.Value = dt_orginal_color_code.Rows(0).ItemArray(0).ToString()
                    End If

                End If
                '=====================================================================================

                Call m_Program_BUS.SetColorCombo(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR), dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString, dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)

            End If

            '++ID 4.17.2019
            If e.ColumnIndex = Items.DEC_MET_ID Then
                Call m_Program_BUS.SetDecomethNew(dgvItems.Rows(e.RowIndex).Cells(Items.DEC_MET_ID), dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString)
            End If


            If e.ColumnIndex < Items.PROD_CAT_ID Then

                Dim oInvoke As New SetColumnIndex(AddressOf SetColumnIndexSub)
                dgvItems.BeginInvoke(oInvoke, Items.ITEM_CD)

            ElseIf e.ColumnIndex > Items.ITEM_CD And dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value Is Nothing Then

                Dim oInvoke As New SetColumnIndex(AddressOf SetColumnIndexSub)
                dgvItems.BeginInvoke(oInvoke, Items.ITEM_CD)

            ElseIf e.ColumnIndex > Items.ITEM_CD And Trim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_CD).Value.ToString) = "" Then

                Dim oInvoke As New SetColumnIndex(AddressOf SetColumnIndexSub)
                dgvItems.BeginInvoke(oInvoke, Items.ITEM_CD)

            End If

            Select Case dgvItems.CurrentCell.ColumnIndex

                Case Items.ITEM_DESC
                    'If Not (e.FormattedValue.Equals(DBNull.Value) Or e.FormattedValue = "") Then
                    'Debug.Print(dgvItems.Rows(iRowIndex).Cells(Items.ITEM_DESC).Value)
                    If dgvItems.CurrentCell.Value.Equals(DBNull.Value) Then
                        If dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString.Contains("CUSTOM") Then
                            dgvItems.CurrentCell.Value = m_Program_BUS.Get_Item_Description(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)
                            'dgvItems.CurrentCell.Value = m_Program_BUS.Get_Custom_Item_Desc(CInt(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value))
                        Else
                            dgvItems.CurrentCell.Value = m_Program_BUS.Get_Item_Description(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString)
                        End If
                    ElseIf dgvItems.CurrentCell.Value = String.Empty Then
                        dgvItems.CurrentCell.Value = m_Program_BUS.Get_Item_Description(dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value)
                    End If

                Case Items.ITEM_COLOR
                    dgvItems.BeginEdit(True)

                Case Items.UNIT_PRICE



            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    Dim qty As Int32
    Dim priceValidate As Double
    Private Sub dgvItems_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvItems.CellValidating

        '    Debug.Print("dgvItems_CellValidating" & dgvItems.CurrentRow.Cells(Items.UNIT_PRICE).Value.ToString)

        Dim iRowIndex As Integer = dgvItems.CurrentRow.Index

        Try
            'If e.ColumnIndex = Items.ITEM_NO Or (Trim(dgvItems.Rows(dgvItems.CurrentRow.Index).Cells(Items.ITEM_NO).Value).Length <> 0 And e.ColumnIndex > Items.ITEM_NO) Then

            Select Case e.ColumnIndex

                Case Items.PROD_CAT_ID
                    Debug.Print(e.FormattedValue)
                    If e.FormattedValue <> " " Then
                        dgvItems.Rows(iRowIndex).Cells(Items.ITEM_CD).Value = e.FormattedValue.ToString.ToUpper
                    End If

                Case Items.ITEM_CD
                    Debug.Print(e.FormattedValue)
                    If Not (e.FormattedValue.Equals(DBNull.Value) Or e.FormattedValue = "") Then

                        dgvItems.Rows(iRowIndex).Cells(Items.ITEM_CD).Value = e.FormattedValue.ToString.ToUpper
                        If e.FormattedValue.ToString.Contains("CUSTOM") Then
                            If m_Program_Type = "Quote" Then
                                dgvItems.Columns(Items.CUSTOM_ITEM_ID).Visible = True
                            End If
                        End If

                        '++ID 09.06.2015 Added elseif for check the item Cd if is, because for begining one line user need enter: 
                        ' item after color, qty,price etc

                    ElseIf e.FormattedValue = String.Empty And e.RowIndex <> 0 Then

                        If Refresh_C <> True Then
                            MsgBox("You need enter item cd !!!")
                            e.Cancel = True
                        End If

                    End If

                Case Items.ITEM_COLOR

                    'in comment  from 3.29.2018
                    'because CSR not use this properties
                    'dgvItems.Rows(iRowIndex).Cells(Items.ITEM_COLOR).Value = e.FormattedValue
                    'If e.FormattedValue = " MULTI" Then
                    '    MsgBox("Multi not available.")
                    '    e.Cancel = True
                    '    Exit Sub

                    'End If

                Case Items.MIN_QTY_ORD
                    Try

                        '  If Not IsNumeric(e.FormattedValue) Then
                        If Microsoft.VisualBasic.Information.IsNumeric(e.FormattedValue) = False Then
                            'MsgBox("It must have Min Qty.")

                            qty = dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                            'Dim cell As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
                            'cell.Value = qty
                            '  e.Cancel = True
                        ElseIf e.FormattedValue <= 0 Then
                            '06.07.2016 put in comment same e.Cancel
                            MsgBox("Qty is 0.")

                            e.Cancel = True
                            '   e.Cancel = True
                        End If

                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try

                Case Items.UNIT_PRICE
                    Try

                        If Microsoft.VisualBasic.Information.IsNumeric(e.FormattedValue) = False Then
                            '  If IsNumeric(e.FormattedValue) Then
                            MsgBox("You need enter numeric value /0..->..9/")
                            dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            priceValidate = dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value


                            '     e.Cancel = True
                            '       dgvItems.Rows(e.RowIndex).ErrorText = 3.0


                            'Dim cell As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)

                            'cell.Value = 3.0

                        End If


                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try

                Case Items.EQP_PCT
                    Try
                        '  If IsNumeric(e.FormattedValue) Then
                        If Microsoft.VisualBasic.Information.IsNumeric(e.FormattedValue) = False Then
                            MsgBox("You need enter numeric value /0..->..9/")
                            e.Cancel = True
                            'Debug.Print("SET UNIT PRICE TO NOTHING")
                            'dgvItems.Rows(iRowIndex).Cells(Items.UNIT_PRICE).Value = DBNull.Value
                        End If
                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try
                Case Items.CHARGE_ID
                    Try
                        If Trim(e.FormattedValue) = "" Then
                            dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = 0.0
                            'e.Cancel = True
                        End If

                    Catch ex As Exception
                        MsgBox("Error in Select Case Items.CHARGE_ID ,form -" & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try
                Case Items.RUN_CHARGE
                    Try
                        If IsNumeric(e.FormattedValue) Then
                        End If
                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try


            End Select


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub dgvItems_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvItems.EditingControlShowing

        Debug.Print("dgvItems_EditingControlShowing")

        'If m_ShowEvents Then Debug.Print("dgvPick_Type.EditingControlShowing")

        ' HERE TO OVERWRITE THE KEYDOWN EVENT OF THE TEXTBOX TO A CUSTOM CONTROL TEXTBOX
        Try

            If TypeOf e.Control Is TextBox Then

                Dim tb As TextBox = CType(e.Control, TextBox)
                'Remove the existing handler if there is one.
                RemoveHandler tb.KeyDown, AddressOf dgvItems_KeyDown ' TextBox_TextChanged

                'Add a new handler.
                AddHandler tb.KeyDown, AddressOf dgvItems_KeyDown ' TextBox_TextChanged
                '    End With
                'End If

            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub dgvItems_GotFocus(sender As Object, e As System.EventArgs) Handles dgvItems.GotFocus

    '    Debug.Print("dgvItems_GotFocus")

    'End Sub

    Private Sub dgvItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvItems.KeyDown

        Debug.Print("dgvItems_KeyDown" & dgvItems.CurrentRow.Cells(Items.UNIT_PRICE).Value.ToString)

        ' HERE TO CHECK FOR KEYCODES TO LAUNCH SHORTCUTS
        Try

            Select Case e.KeyCode
                Case Keys.Return

                    Dim oInvoke As New ProductLineInsertDelegate(AddressOf ProductLineInsert)
                    dgvItems.BeginInvoke(oInvoke, dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value)

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


    'Private Sub dgvItems_Leave(sender As Object, e As System.EventArgs) Handles dgvItems.Leave

    '    Debug.Print("dgvItems_Leave")

    'End Sub

    'Private Sub dgvItems_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.RowEnter

    '    Debug.Print("dgvItems_RowEnter")

    'End Sub

    'Private Sub dgvItems_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.RowLeave

    '    Debug.Print("dgvItems_RowLeave")

    'End Sub

#End Region

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
                tsbSave.Enabled = True
                tsbNextStep.Enabled = True
                tsbExport.Enabled = True
                '++ID 18.03.2015
                tsbClientEmail.Enabled = True
                '-------------------------
            Case "SUPERUSER"
                tsbSave.Enabled = True
                tsbNextStep.Enabled = True
                tsbExport.Enabled = True
                '++ID 18.03.2015
                tsbClientEmail.Enabled = True
                '--------------------------
                btnShowAdminFields.Visible = True

            Case "READONLY"
                'tsClose.Visible = True
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

    Private Sub ReadOnlyFields_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If User_Rights = "READONLY" Then
            txtCus_No.Focus()
        End If

    End Sub

    Private Sub SetColumnIndexSub(ByVal columnIndex As Integer)

        dgvItems.CurrentCell = dgvItems.CurrentRow.Cells(columnIndex)
        'dgvItems.BeginEdit(True)

    End Sub

    Private Sub SetDecoratingCombo(ByVal cboColumn As DataGridViewComboBoxColumn)

        Try
            With cboColumn

                .DataSource = ChangeCboDecoratingList()

                .ValueMember = "DEC_MET_ID" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "DEC_MET_CD"

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    '++ID 06.08.2015
    Private Sub SetChargeCombo(ByVal cboColumn As DataGridViewComboBoxColumn)

        Try
            With (cboColumn)

                .DataSource = ChangeCboChargeList()

                .ValueMember = "Charge_Id"
                .DisplayMember = "DESCRIPTION"

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub


    Private Sub SetGroupDecoratingCombo(ByVal cboColumn As DataGridViewComboBoxColumn)

        Try
            With cboColumn

                .DataSource = ChangeCboGroupDecoratingList()

                .ValueMember = "DEC_MET_GROUP_ID" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "DEC_MET_GROUP_DESC"

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetPackagingCombo(ByVal cboColumn As DataGridViewComboBoxColumn)

        Try
            With cboColumn
                '.DataSource = RetrieveAlternativeTitles()

                '.ValueMember = "RouteId" ' ColumnName.TitleOfCourtesy.ToString()
                .DataSource = ChangeCboPackagingList()

                .ValueMember = "PACK_ID" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "PACK_CD"

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Function ChangeCboDecoratingList() As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeCboDecoratingList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql =
            "SELECT     CAST(0 AS INT) AS DEC_MET_ID, CAST(' ' AS VARCHAR(20)) AS DEC_MET_CD " &
            "UNION      " &
            "SELECT		DEC_MET_ID, DEC_MET_CD " &
            "FROM       MDB_CFG_DEC_MET WITH (NoLock) " &
            "WHERE      IMPRINT_LIST_ITEM = 1 " &
            "ORDER BY	DEC_MET_CD "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboDecoratingList = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    '++ID 06.08.2015
    Public Function ChangeCboChargeList() As DataTable
        ChangeCboChargeList = New DataTable
        Try
            Dim strSql As String

            strSql =
              " SELECT	 CAST(0 AS INT) AS CHARGE_ID, CAST(' ' AS VARCHAR(20)) AS DESCRIPTION " &
              " UNION " &
              " SELECT	Charge_Id, RTRIM(ISNULL(DESCRIPTION, '')) AS DESCRIPTION " &
              " FROM mdb_cfg_charge WITH (Nolock) " &
              " WHERE ISNULL(CHARGE_CD, '') <> 'SET_UP' " &
              " ORDER BY DESCRIPTION "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboChargeList = dt

        Catch ex As Exception
            MsgBox("Error in frmQuickProgram:" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Function ChangeCboGroupDecoratingList() As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeCboGroupDecoratingList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql =
            "SELECT     CAST(0 AS INT) AS DEC_MET_GROUP_ID, CAST(' ' AS VARCHAR(20)) AS DEC_MET_GROUP_DESC " &
            "UNION      " &
            "SELECT		DEC_MET_GROUP_ID, DEC_MET_GROUP_DESC " &
            "FROM       MDB_CFG_DEC_MET_GROUP WITH (NoLock) " &
            "ORDER BY	DEC_MET_GROUP_DESC "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboGroupDecoratingList = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function ChangeCboPackagingList() As DataTable ' , ByVal pstrProd_Cat As String)

        ChangeCboPackagingList = New DataTable

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql =
            "SELECT     CAST(0 AS INT) AS PACK_ID, CAST(' ' AS VARCHAR(20)) AS PACK_CD " &
            "UNION      " &
            "SELECT	    PACK_ID, PACK_CD " &
            "FROM	    MDB_CFG_PACK WITH (Nolock) " &
            "ORDER BY   PACK_CD "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboPackagingList = dt

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    Private Sub cmdQuoteComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuoteComments.Click

        Try
            m_Program.Contact_ID = cboContact_ID.SelectedValue

            Dim ofrm As frmQuote_Comments
            ofrm = New frmQuote_Comments(m_Customer, m_Program)
            ofrm.ShowDialog()
            ofrm.Save()
            ofrm.Dispose()

            Call SetQuoteCommentButton()

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetQuoteCommentButton()

        Try

            Dim dt As DataTable
            Dim db As New cDBA
            Dim strsql As String =
            "SELECT CUS_PROG_GUID FROM MDB_PROG_COMMENT " &
            "WHERE CUS_PROG_GUID = '" & m_Program.Cus_Prog_Guid & "' AND ISNULL(ITEM_CD, '') = '' "

            dt = db.DataTable(strsql)
            If dt.Rows.Count = 0 Then
                cmdQuoteComments.BackColor = Control.DefaultBackColor
            Else
                cmdQuoteComments.BackColor = Color.DeepSkyBlue
            End If

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Function QuoteCommentColor(ByVal pCus_Prog_Guid As String, ByVal pItem_Guid As String) As System.Drawing.Color

        QuoteCommentColor = Color.Empty
        'QuoteCommentColor = Color.Red

        Try

            Dim dt As DataTable
            Dim db As New cDBA
            Dim strsql As String =
            "SELECT CUS_PROG_GUID FROM MDB_PROG_COMMENT " &
            "WHERE CUS_PROG_GUID = '" & pCus_Prog_Guid & "' AND CUS_PROG_ITEM_LIST_GUID = '" & pItem_Guid & "' "

            dt = db.DataTable(strsql)
            If dt.Rows.Count <> 0 Then
                QuoteCommentColor = Color.DeepSkyBlue
            End If

        Catch er As Exception
            MsgBox("Error in COrder." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Private Sub cboContact_FillCombo()

        Dim strSql As String
        Dim dtContacts As DataTable
        Dim db As New cDBA

        Try

            strSql =
            "SELECT		DISTINCT C.ID, C.Fullname " &
            "FROM		cicntp C WITH (Nolock) " &
            "INNER JOIN	cicmpy P WITH (Nolock) ON C.cmp_wwn = P.cmp_wwn " &
            "WHERE	ISNULL(C.active_y,0) = 1 And P.cmp_code = '" & m_Customer.cmp_code & "' " &
            "ORDER BY	C.FullName "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            dtContacts = db.DataTable(strSql)

            cboContact_ID.DataSource = dtContacts

            cboContact_ID.ValueMember = Nothing
            cboContact_ID.DisplayMember = "Fullname"
            cboContact_ID.ValueMember = "ID"

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub cboContact_FillCombo1()

    '    Dim strSql As String
    '    Dim dtContacts As DataTable
    '    Dim db As New cDBA

    '    Try

    '        strSql = _
    '        "SELECT		DISTINCT C.ID, C.Fullname " & _
    '        "FROM		cicntp C WITH (Nolock) " & _
    '        "INNER JOIN	cicmpy P WITH (Nolock) ON C.cmp_wwn = P.cmp_wwn " & _
    '        "WHERE		P.cmp_code = '" & m_Customer.cmp_code & "' " & _
    '        "ORDER BY	C.FullName "

    '        dtContacts = db.DataTable(strSql)

    '        cboContact_ID.DataSource = dtContacts

    '        cboContact_ID.ValueMember = Nothing
    '        cboContact_ID.DisplayMember = "Fullname"
    '        cboContact_ID.ValueMember = "ID"

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub


    'Dim comboboxColumn As DataGridViewComboBoxColumn
    '            comboboxColumn = DGVComboBoxColumn("CONTACT_ID", "Correspondance", 180)
    '            With comboboxColumn
    '                .DataSource = GetDocContactsList()
    '                .ValueMember = "Contact_ID"
    '                .DisplayMember = "Contact_Desc"
    '            End With
    '            .Add(comboboxColumn)




#Region "LOAD OPTIONS ##########################################################"

    Private Sub dgvOptions_CreateColumns()

        Try

            With dgvOptions.Columns
                .Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 10))
                .Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 10))
                .Add(DGVTextBoxColumn("CHARGE_CD", "CHARGE_CD", 10))
                .Add(DGVTextBoxColumn("DEC_MET_ID", "DEC_MET_ID", 10))
                .Add(DGVTextBoxColumn("DEC_MET_CD", "DEC_MET_CD", 10))
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 10))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Charge", 180))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Short Desc", 10))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 10))
                .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 50))
                .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 50))
                .Add(DGVCheckBoxColumn("NO_CHARGE", "Waived", 50))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Unit Price", 63))
                .Add(DGVTextBoxColumn("EXT_COMMENTS", "Comments", 10))
            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOptions_Format()

        Try
            If dgvOptions.Columns.Count = 0 Then Exit Sub

            With dgvOptions

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                .CausesValidation = True

                Dim oCellStyle As New DataGridViewCellStyle()
                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.000"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Options.UNIT_PRICE).DefaultCellStyle = oCellStyle

                'CHARGE_USAGE_ID()
                'CHARGE_ID()
                'CUS_PROG_ID
                'DESCRIPTION
                'SHORT_DESC()
                'CUS_NO()
                'ALWAYS_USE()
                'NEVER_USE()
                'NO_CHARGE()
                'UNIT_PRICE
                'EXT_COMMENTS()

                .Columns(Options.CHARGE_USAGE_ID).Visible = False
                .Columns(Options.CHARGE_ID).Visible = False
                .Columns(Options.CHARGE_CD).Visible = False
                .Columns(Options.DEC_MET_ID).Visible = False
                .Columns(Options.DEC_MET_CD).Visible = False
                .Columns(Options.CUS_PROG_ID).Visible = False
                .Columns(Options.SHORT_DESC).Visible = False
                .Columns(Options.CUS_NO).Visible = False
                .Columns(Options.EXT_COMMENTS).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOptions_Fill()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            '++ID 07.05.2015 New Sql Query String
            Dim strSql As String =
            " SELECT ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.CHARGE_ID, C.CHARGE_CD," &
       "  CAST(0 AS INT) AS DEC_MET_ID, CAST ('' AS VARCHAR(20)) AS DEC_MET_CD, " &
       "  ISNULL(CU.CUS_PROG_ID, 0) AS CUS_PROG_ID, C.DESCRIPTION, C.SHORT_DESC, CU.CUS_NO,  " &
       "  CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE,  " &
       "  CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " &
       "  CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NO_CHARGE, " &
       "  ISNULL(CU.UNIT_PRICE, 0) AS UNIT_PRICE,  " &
       "  CASE WHEN ISNULL(CU.BLIND, 0) = 1 THEN 'BLIND, ' ELSE '' END  +  " &
       "  CASE WHEN ISNULL(CU.WHEN_REQ, 0) = 1 THEN 'WHEN REQUESTED, ' ELSE '' END + ISNULL(CU.COMMENTS, '') AS EXT_COMMENTS " &
       "  FROM   (	SELECT	CUS.CUS_NO, C.* FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock)) C " &
       "  LEFT JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON C.CHARGE_ID = CH.CHARGE_ID " &
       "  LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID " &
       "  and c.cus_no = cu.cus_no AND CU.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " " &
       "  WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND C.CHARGE_CD <> 'SET_UP' and  " &
       "  C.CHARGE_CD not in  (select m.CHARGE_CD  " &
       "  from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO " &
       "  where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' AND o.EXTRA_5 = '1' and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() )  " &
       " ORDER BY CH.CHARGE_ORDER asc, CH.DESCRIPTION ASC  "


            dtOptions = db.DataTable(strSql)

            dgvOptions.DataSource = dtOptions
            dgvOptions.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "LOAD SETUPS ##########################################################"

    Private Sub dgvSetUps_CreateColumns()

        Try

            With dgvSetUps.Columns
                .Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 10))
                .Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 10))
                .Add(DGVTextBoxColumn("CHARGE_CD", "CHARGE_CD", 10))
                .Add(DGVTextBoxColumn("DEC_MET_ID", "DEC_MET_ID", 10))
                .Add(DGVTextBoxColumn("DEC_MET_CD", "DEC_MET_CD", 10))
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 10))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Charge", 180))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Short Desc", 10))
                .Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 10))
                .Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 50))
                .Add(DGVCheckBoxColumn("NEVER_USE", "Never", 50))
                .Add(DGVCheckBoxColumn("NO_CHARGE", "Waived", 50))
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Unit Price", 63))
                .Add(DGVTextBoxColumn("EXT_COMMENTS", "Comments", 10))
            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSetUps_Format()

        Try
            If dgvSetUps.Columns.Count = 0 Then Exit Sub

            With dgvSetUps

                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20

                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                .CausesValidation = True

                Dim oCellStyle As New DataGridViewCellStyle()
                oCellStyle = New DataGridViewCellStyle()
                oCellStyle.Format = "##,##0.000"
                oCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(Options.UNIT_PRICE).DefaultCellStyle = oCellStyle
                .Columns(Options.CHARGE_USAGE_ID).Visible = False
                .Columns(Options.CHARGE_ID).Visible = False
                .Columns(Options.CHARGE_CD).Visible = False
                .Columns(Options.DEC_MET_ID).Visible = False
                .Columns(Options.DEC_MET_CD).Visible = False
                .Columns(Options.ALWAYS_USE).Visible = False
                .Columns(Options.NEVER_USE).Visible = False
                .Columns(Options.CUS_PROG_ID).Visible = False
                .Columns(Options.SHORT_DESC).Visible = False
                .Columns(Options.CUS_NO).Visible = False
                .Columns(Options.EXT_COMMENTS).Visible = False

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSetUps_Fill()

        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            '.Add(DGVTextBoxColumn("CHARGE_USAGE_ID", "CHARGE_USAGE_ID", 10))
            '.Add(DGVTextBoxColumn("CHARGE_ID", "CHARGE_ID", 10))
            '.Add(DGVTextBoxColumn("CHARGE_CD", "CHARGE_CD", 10))
            '.Add(DGVTextBoxColumn("DEC_MET_ID", "DEC_MET_ID", 10))
            '.Add(DGVTextBoxColumn("DEC_MET_CD", "DEC_MET_CD", 10))
            '.Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 10))
            '.Add(DGVTextBoxColumn("DESCRIPTION", "Charge", 180))
            '.Add(DGVTextBoxColumn("SHORT_DESC", "Short Desc", 10))
            '.Add(DGVTextBoxColumn("CUS_NO", "CUS_NO", 10))
            '.Add(DGVCheckBoxColumn("ALWAYS_USE", "Always", 50))
            '.Add(DGVCheckBoxColumn("NEVER_USE", "Never", 50))
            '.Add(DGVCheckBoxColumn("NO_CHARGE", "Waived", 50))
            '.Add(DGVTextBoxColumn("UNIT_PRICE", "Unit Price", 63))
            '.Add(DGVTextBoxColumn("EXT_COMMENTS", "Comments", 10))

            ' Important - we do not enter SETUP anymore, it will be linked 
            Dim strSql As String =
            "SELECT		ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, " &
            "           CAST(27 AS INT) AS CHARGE_ID, CAST ('SET_UP' AS VARCHAR(20)) AS CHARGE_CD, " &
            "           C.DEC_MET_ID, C.DEC_MET_CD, " &
            "           ISNULL(CU.CUS_PROG_ID, 0) AS CUS_PROG_ID, C.DEC_MET_CD AS DESCRIPTION, C.DEC_MET_CD AS SHORT_DESC, CU.CUS_NO, " &
            "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " &
            "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " &
            "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NO_CHARGE, " &
            "			ISNULL(CU.UNIT_PRICE, 0) AS UNIT_PRICE, " &
            "           CAST ('' AS VARCHAR(20)) AS EXT_COMMENTS " &
            "            FROM " &
            "	(	SELECT	CUS.CUS_NO, D.*" &
            "		FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_DEC_MET D WITH (Nolock) " &
            "	) C " &
            "LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON cu.CHARGE_ID = 27 and c.cus_no = cu.cus_no AND C.DEC_MET_ID = CU.DEC_MET_ID AND CU.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " " &
            "WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' " &
            "ORDER BY	(CASE WHEN CU.CHARGE_USAGE_ID IS NOT NULL THEN 1 ELSE 0 END) DESC,  " &
            "           C.DEC_MET_CD "

            '"ORDER BY	C.CUS_NO, CH.CHARGE_ORDER, C.SHORT_DESC "
            'CHARGE_USAGE_ID(,CHARGE_ID()), CHARGE_CD()
            'CUS_PROG_ID(), 'DESCRIPTION(), 'SHORT_DESC(), 'CUS_NO()
            'ALWAYS_USE(), 'NEVER_USE(), 'NO_CHARGE()
            'UNIT_PRICE(), 'EXT_COMMENTS()

            dtSetUps = db.DataTable(strSql)

            dgvSetUps.DataSource = dtSetUps
            dgvSetUps.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region



#Region "PRIVATE DGVOPTIONS EVENTS ############################################"

    Private Sub dgvOptions_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOptions.CellBeginEdit

        Try

            'Select Case e.ColumnIndex

            '    Case Options.DESCRIPTION
            '        e.Cancel = True

            'End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvOptions_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOptions.CellContentClick

        Try
            'Select Case e.ColumnIndex
            '    Case Options.ALWAYS_USE, Options.NEVER_USE, Options.NO_CHARGE

            '        dgvOptions.EndEdit()

            'End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub



    Private Sub dgvOptions_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOptions.Leave

        '  dgvOptions.EndEdit()

    End Sub

#End Region


#Region "PRIVATE DGVSETUPS EVENTS #############################################"

    Private Sub dgvSetUps_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvSetUps.CellBeginEdit

        Try

            Select Case e.ColumnIndex

                Case Options.DESCRIPTION
                    e.Cancel = True

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvSetUps_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSetUps.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case Options.ALWAYS_USE, Options.NEVER_USE, Options.NO_CHARGE

                    dgvSetUps.EndEdit()

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub dgvSetUps_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) 

    '    Try
    '        Select Case dgvItems.CurrentCell.ColumnIndex

    '            Case Options.UNIT_PRICE
    '                dgvItems.BeginEdit(True)

    '        End Select

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub dgvSetUps_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSetUps.Leave

        dgvSetUps.EndEdit()

    End Sub

#End Region


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAdminFields.Click

        Try
            tcpOptions.Hide()

            gbQuoteSteps.Visible = True

            'm_Program_BUS.Create_Excel_Program_Report(m_Program)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport.Click

        If m_Program_Type = "Program" Then
            '++ID need save manualy
            ' If Menu_Save() Then


            If Not bw.IsBusy = True Then
                    bw.RunWorkerAsync()
                End If

            '        pictLoadImage.Visible = True
            '        m_Program_BUS.Create_Excel_Program_Report(m_Program, m_Customer)
            '        pictLoadImage.Visible = False
            '    Else
            '   Me.Cursor = Cursors.Default
            '   Exit Sub
            'End If
        ElseIf m_Program_Type = "Quote" Then
            txtStart_Dt.Text = Date.Now.Date
            txtEnd_Dt.Text = Date.Now.Date.AddDays(13)
            If Menu_Save() Then

                If Not bw.IsBusy = True Then
                    bw.RunWorkerAsync()
                End If
                '        pictLoadImage.Visible = True
                '        'm_Program_BUS.Save(m_Program)
                '        m_Program_BUS.Create_Excel_Quote_Report(m_Program, m_Customer)
                '        pictLoadImage.Visible = False
                '        Call ProcessToStep(Quote_Step.Ready_To_Send)
            Else
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If


        '   RemoveHandler bw.DoWork, AddressOf bw_DoWork
        '   RemoveHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        '   ChangePictureVisibility = AddressOf ChangeVisibility

    End Sub

    '++ID 1.12.2018 cod for load gif image while is generated pdf

    Dim bw As BackgroundWorker = New BackgroundWorker
    Public Delegate Sub PictureVisibilityDelegate(ByVal visibility As Boolean)
    Dim ChangePictureVisibility As PictureVisibilityDelegate
    Public Sub ChangeVisibility(ByVal visibility As Boolean)
        pictLoadImage.Visible = visibility
        lblLoading.Visible = visibility


        If visibility = True Then
            Me.Cursor = Cursors.WaitCursor
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs)
        Me.Invoke(ChangePictureVisibility, True)

        If m_Program_Type = "Program" Then
            '  If Menu_Save() Then
            ' pictLoadImage.Visible = True
            m_Program_BUS.Create_Excel_Program_Report(m_Program, m_Customer)


            '  pictLoadImage.Visible = False
            '  End If
        ElseIf m_Program_Type = "Quote" Then
            ' txtStart_Dt.Text = Date.Now.Date
            ' txtEnd_Dt.Text = Date.Now.Date.AddDays(13)
            ' If Menu_Save() Then
            '  pictLoadImage.Visible = True
            'm_Program_BUS.Save(m_Program)
            m_Program_BUS.Create_Excel_Quote_Report(m_Program, m_Customer)
                ' pictLoadImage.Visible = False
                Call ProcessToStep(Quote_Step.Ready_To_Send)
            '  End If
        End If


    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Me.Invoke(ChangePictureVisibility, False)
    End Sub

    '----------------------------------

    Private Sub fields_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProg_Cd.GotFocus,
                txtImprint.GotFocus,
                txtStart_Dt.GotFocus, cmdStart_Dt.GotFocus, txtEnd_Dt.GotFocus, cmdEnd_Dt.GotFocus,
                cboContact_ID.GotFocus, cmdQuoteComments.GotFocus, dgvItems.GotFocus

        If m_Program_Type = "Quote" Then
            If m_Program.Quote_Step_ID = Quote_Step.Sent_To_Customer Then
                txtProg_Comments.Focus()
            End If
        End If

    End Sub

    Private Sub SetStatusBar()

        Try
            With m_Program

                If .Create_By <> String.Empty Then
                    tsslCreate_By.Text = "Created by: " & .Create_By
                    If .Create_TS.ToString <> String.Empty Then tsslCreate_TS.Text = "Date:" & .Create_TS.ToString
                End If

                If .User_Login <> String.Empty Then
                    tsslUser_Login.Text = "Modified by: " & .User_Login
                    If .Update_TS.ToString <> String.Empty Then tsslUpdate_TS.Text = "Date:" & .Update_TS.ToString

                End If

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Private Sub SetUnsaved(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtStart_Dt.Validating, txtSpector_Cd.Validating, txtQuote_Step_User.Validating, txtQuote_Step_ID.Validating, txtProg_CSR.Validating, txtProg_Comments.Validating, txtProg_Cd.Validating, txtImprint.Validating, txtEnd_Dt.Validating, txtCus_No.Validating, dgvItems.Validating, cboQuote_Type.Validating, cboQuote_Ship_Method.Validating, cboProg_Type.Validating, cboContact_ID.Validating, dgvOptions.Validating

    'End Sub

    Private Sub tcOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcOptions.Click

        Dim tcControl As TabControl = sender

        Try
            'If m_oOrder Is Nothing Then
            '    m_oOrder = New cOrder()
            '    UcOrder.Fill() ' m_oOrder)
            'End If
            ''tcControl.SelectedIndex = 2
            ''Dim iSelectedIndex As Integer = CInt(Mid(tcPage.Name, tcPage.Name.Length - 1, 2))

            'If tcControl.SelectedIndex <> Tabs.History And tcControl.SelectedIndex <> Tabs.ReservedItems Then
            '    If tcControl.SelectedIndex > Tabs.Header And (Trim(m_oOrder.Ordhead.Cus_No) = "" Or m_oOrder.Ordhead.Cus_No Is Nothing) Then
            '        sstOrder.SelectTab(Tabs.Header)
            '        Exit Sub
            '    End If

            '    'If tcControl.SelectedIndex > Tabs.CustomerContact And (m_oOrder.Ordhead.ContactView = 0) Then
            '    If tcControl.SelectedIndex > Tabs.CustomerContact And (m_oOrder.Ordhead.ContactView = 0) Then
            '        sstOrder.SelectTab(Tabs.CustomerContact)
            '        m_oOrder.Ordhead.ContactView = 1
            '        Exit Sub
            '    End If
            'End If

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Select Case tcControl.SelectedIndex ' tcControl.SelectedIndex

                Case Tabs.Options
                Case Tabs.Documents
                    If m_Program Is Nothing Then
                        m_Program = New cMdb_Cus_Prog()
                        m_Program.Cus_No = txtCus_No.Text
                    End If
                    UcDocuments.Load(m_Program)
            End Select

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    ''Public Function VerifyProductionAvailability(ByVal Ord_No As String, ByVal line_no As Long, ByVal dt As Date, ByVal line_only As Boolean, ByVal origDate As Date) As Boolean
    'Public Sub SetCommentButtonColor(ByRef pCell As DataGridViewCell)

    '    Try

    '        Dim strSql As String
    '        Dim db As New cDBA
    '        Dim dtRouteCat As DataTable
    '        Dim dtAvailDate As DataTable
    '        Dim dtRow As DataRow
    '        Dim intThermoColor As Integer = 0

    '        Dim routeEl As String ' Object

    '        Select Case intThermoColor
    '            Case 0
    '                pCell.Style.BackColor = Color.Empty
    '            Case 1
    '                pCell.Style.BackColor = Color.Empty ' Color.Orange
    '            Case 2
    '                pCell.Style.BackColor = Color.Empty ' Color.Yellow
    '            Case 3
    '                pCell.Style.BackColor = Color.Empty ' Color.Cyan
    '            Case 4
    '                pCell.Style.BackColor = Color.Red ' Color.Magenta
    '            Case Else
    '                pCell.Style.BackColor = Color.Empty

    '        End Select

    '    Catch er As Exception
    '        MsgBox("Error in COrdline." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Private Sub SetUnsaved(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtStart_Dt.Validating, txtSpector_Cd.Validating, txtQuote_Step_User.Validating, txtQuote_Step_ID.Validating, txtProg_CSR.Validating, txtProg_Comments.Validating, txtProg_Cd.Validating, txtImprint.Validating, txtEnd_Dt.Validating, txtCus_No.Validating, dgvOptions.Validating, dgvItems.Validating, cboQuote_Type.Validating, cboQuote_Ship_Method.Validating, cboProg_Type.Validating, cboContact_ID.Validating

    'End Sub

    Private Sub tsbMassInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMassInsert.Click

        Try

            Dim oFrm As New frmMDB_CUS_PROG_Mass_Add()
            oFrm.ShowDialog()

            m_Program_BUS.Mass_Add(oFrm.Item_List(" "), dgvItems, dtItems, m_Program)

            oFrm.Close()
            oFrm = Nothing

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click

        'm_Program_BUS.Create_XML_Revision(m_Program)
        tcpOptions.Hide()


    End Sub

    'Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    '    Try
    '        'tcpOptions.Hide()
    '        Dim A1 As String
    '        A1 = m_Program_BUS.Get_Revision(m_Program)
    '        MsgBox(A1)

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub tsbOptionsWaiveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOptionsWaiveAll.Click

        '   Call Options_WaiveAll()

    End Sub

    Private Sub tsbOptionsResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOptionsResetAll.Click

        '  Call Options_ResetAll()

    End Sub

    Private Sub tsbSetUpsWaiveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSetUpsWaiveAll.Click

        Call SetUps_WaiveAll()

    End Sub

    Private Sub tsbSetUpsResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSetUpsResetAll.Click

        Call SetUps_ResetAll()

    End Sub

    'Private Sub Options_WaiveAll()

    '    Try

    '        For Each dgvRow As DataGridViewRow In dgvOptions.Rows
    '            dgvRow.Cells(Options.NO_CHARGE).Value = True
    '            dgvRow.Cells(Options.UNIT_PRICE).Value = 0
    '        Next

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    'Private Sub Options_ResetAll()

    '    Try

    '        For Each dgvRow As DataGridViewRow In dgvOptions.Rows
    '            dgvRow.Cells(Options.ALWAYS_USE).Value = False
    '            dgvRow.Cells(Options.NEVER_USE).Value = False
    '            dgvRow.Cells(Options.NO_CHARGE).Value = False
    '            dgvRow.Cells(Options.UNIT_PRICE).Value = 0
    '        Next

    '    Catch er As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
    '    End Try

    'End Sub

    Private Sub SetUps_WaiveAll()

        Try

            For Each dgvRow As DataGridViewRow In dgvSetUps.Rows
                dgvRow.Cells(Options.NO_CHARGE).Value = True
                dgvRow.Cells(Options.UNIT_PRICE).Value = 0
            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub SetUps_ResetAll()

        Try

            For Each dgvRow As DataGridViewRow In dgvSetUps.Rows
                dgvRow.Cells(Options.NO_CHARGE).Value = False
                dgvRow.Cells(Options.UNIT_PRICE).Value = 0
            Next

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub tsbCreateRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCreateRevision.Click

        Try
            Call Menu_Create_Revision()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Menu_Create_Revision()

        Try

            '++ID added 02.05.2015
            ' Call Menu_Save()
            '---------------------

            Dim oMsgBox As New MsgBoxResult
            oMsgBox = MsgBox("Did you send the current version to the customer ?", MsgBoxStyle.YesNoCancel)

            Select Case oMsgBox

                Case MsgBoxResult.Yes

                    txtStart_Dt.Text = Now.Date
                    txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddDays(13))

                    Call Menu_Save()

                    m_Program_BUS.Create_Revision(m_Program)
                    txtCurrent_Rev_No.Text = m_Program.Current_Rev_No

                    Call ProcessToStep(Quote_Step.Saved_Quote)
                    '++ID before oMsgBox = MsgBoxResult.No
                Case MsgBoxResult.No

                    txtStart_Dt.Text = Now.Date
                    txtEnd_Dt.Text = (CDate(txtStart_Dt.Text).AddDays(13))

                    Call Menu_Save()
                    '++ID added 02.05.2015 -1 for do back one step
                    Call ProcessToStep(Quote_Step.Saved_Quote - 1)

                Case Else

            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    '++ID 12.1.15
    Private Sub dgvItems_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvItems.DragOver
        Try
            Dim point As Point = dgvItems.PointToClient(New Point(e.X, e.Y))

            Dim hti As DataGridView.HitTestInfo = dgvItems.HitTest(point.X, point.Y)

            If hti.RowIndex <= -1 Then
                Debug.Print("out of range")
                Exit Sub
            End If
            Debug.Print("dgvItems_MouseMove :  X." & point.X & vbCrLf & "Y." & point.Y)

            dgvItems.Rows(hti.RowIndex).Selected = True

            intRowIndexMouseMove = dgvItems.Rows(hti.RowIndex).Index

            Debug.Print("dgvItems_MouseMove dgvComm.RowIndex : " & intRowIndexMouseMove.ToString)

            If intRowIndexMouseMove >= 0 Then
                e.Effect = DragDropEffects.Move
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '++ID 16.07.2015
    Private Sub dgvItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvItems.MouseClick
        Try

            If dgvItems.RowCount < 0 Then
                Exit Sub
            End If

            Debug.Print("dgvItems_MouseClick -> Left - " & dgvItems.Rows(dgvItems.CurrentRow.Index).Cells(Items.CUS_PROG_ITEM_LIST_ID).Value)

            If e.Button = Windows.Forms.MouseButtons.Right Then

                dgvItems.ClearSelection()

                Dim hti As DataGridView.HitTestInfo = dgvItems.HitTest(e.X, e.Y)

                dgvItems.CurrentCell = dgvItems.Rows(hti.RowIndex).Cells(Items.ITEM_CD)

                dgvItems.Rows(hti.RowIndex).Selected = True
                '  dgvItems.BeginEdit(True)

                Application.DoEvents()

                Debug.Print("dgvItems_MouseClick - " & dgvItems.Rows(hti.RowIndex).Cells(Items.CUS_PROG_ITEM_LIST_ID).Value)

                If Not dgvItems.Rows(hti.RowIndex).Cells(Items.CUS_PROG_ITEM_LIST_ID).Value Is Nothing Then

                    CopyAndPasteThisItemToolStripMenuItem.Text = "Copy and Paste this Item " & Trim(dgvItems.Rows(hti.RowIndex).Cells(Items.ITEM_CD).Value.ToString)
                    menuCopyRow.Show(sender, New System.Drawing.Point(e.X, e.Y))

                End If

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID 13.1.15
    Private Sub dgvItems_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvItems.SelectionChanged
        Try

            '  Me.dgvItems.ClearSelection()

            For Each row As DataGridViewRow In dgvItems.Rows

                For Each cell As DataGridViewCell In row.Cells

                    cell.Style.SelectionBackColor = Color.Beige
                    cell.Style.SelectionForeColor = Color.DarkBlue

                Next

            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID ...03.2015
#Region "Load Quote result"

    Public Sub QuoteResult()
        Try

            If m_Program_Type = "Quote" Then
                lblStatusQuote.Visible = True
                cboStatusQuote.Visible = True
                lblDecision_Dt.Visible = True
                txtDecision_Dt.Visible = True
                '    cmdDecision_Dt.Visible = True
                lblQuoteResult.Visible = True
                cboQuoteResult.Visible = True

                '    tsbClientEmail.Visible = True



                Call cboStatusQuoteLoad()
                Call cboQuoteResultLoad()
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub cboStatusQuoteLoad()
        Try
            cboStatusQuote.Items.Clear()
            cboStatusQuote.Items.Add("")
            cboStatusQuote.Items.Add("sent to client")
            cboStatusQuote.Items.Add("pending")

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cboQuoteResultLoad()
        Try
            cboQuoteResult.Items.Clear()
            cboQuoteResult.Items.Add("")
            cboQuoteResult.Items.Add("order received.")
            cboQuoteResult.Items.Add("no response to follow up.")
            cboQuoteResult.Items.Add("no order - closed")
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function FollowMe(ByRef dateF As Date, Optional ByVal hour As String = "") As DateTime
        FollowMe = dateF

        Dim fromatafter As Date = dateF
        Dim d As DateTime
        Dim dateS As String = dateF.ToString
        '  Dim hour As String = "9:00:00 AM"

        ' 0 = Sunday ' 1 = Monday ' 2 = Tuesday ' 3 = Wednesday ' 4 = Thursday ' 5 = Friday ' 6 = Saturday
        Select Case fromatafter.DayOfWeek
            Case 1, 2
                dateS = fromatafter.AddDays(2).ToString("MM/dd/yy")
            Case 3
                dateS = fromatafter.AddDays(5).ToString("MM/dd/yy")
            Case 4
                dateS = fromatafter.AddDays(4).ToString("MM/dd/yy")
            Case 5
                dateS = fromatafter.AddDays(5).ToString("MM/dd/yy")
            Case 6
                dateS = fromatafter.AddDays(4).ToString("MM/dd/yy")
        End Select

        d = Convert.ToDateTime(dateS & " " & hour)
        FollowMe = d


    End Function

    Private Sub FollowUp(ByRef dateF As Date)
        Try

            Dim fromatafter As DateTime = dateF

            '  Dim hour As String = "9:00:00 AM"

            ' 0 = Sunday ' 1 = Monday ' 2 = Tuesday ' 3 = Wednesday ' 4 = Thursday ' 5 = Friday ' 6 = Saturday
            Select Case fromatafter.DayOfWeek
                Case 1, 2
                    dateF = fromatafter.AddDays(2).ToString("MM/dd/yy hh:mm:ss tt")
                Case 3
                    dateF = fromatafter.AddDays(5).ToString("MM/dd/yy hh:mm:ss tt")
                Case 4
                    dateF = fromatafter.AddDays(4).ToString("MM/dd/yy hh:mm:ss tt")
                Case 5
                    dateF = fromatafter.AddDays(5).ToString("MM/dd/yy hh:mm:ss tt")
                Case 6
                    dateF = fromatafter.AddDays(4).ToString("MM/dd/yy hh:mm:ss tt")
            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Friend Sub CreateAppointment(ByVal title As String, ByVal strStartDt As String, ByVal strEndDt As String, ByVal strSubject As String, Optional ByVal strBody As String = "", Optional ByVal strLocation As String = "", Optional ByRef iErrorCount As Integer = 0)
        Try

            'retrive only hours:min:sec
            'Dim dtS As Date = dtpStartHours.Value.ToShortTimeString
            'Dim dtE As Date = dtpEndHours.Value.ToShortTimeString

            ''concatine and convert in date
            Dim dtSConvStr As Date = Convert.ToDateTime(strStartDt)
            Dim dtEConvStr As Date = Convert.ToDateTime(strEndDt)

            If dtSConvStr < Date.Now Then
                dtSConvStr = Date.Now
                Call FollowUp(dtSConvStr)
                txtDecision_Dt.Text = dtSConvStr

                dtEConvStr = Date.Now.AddHours(1)
                Call FollowUp(dtEConvStr)
                txtEndDecision_Dt.Text = dtEConvStr
            End If

            Dim apptItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
            Dim apItem As New Microsoft.Office.Interop.Outlook.Application

            apptItem = apItem.Session.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)

            'https://www.add-in-express.com/creating-addins-blog/2013/06/10/outlook-calendar-appointment-meeting-items/


            With apptItem
                .Subject = title
                .Location = strLocation 'txtLocation.Text
                .Start = dtSConvStr 'dtSConvStr 'DateTime.Now
                .End = dtEConvStr 'dtEConvStr 'Date.Now.AddHours(2)
                .Duration = 5
                .Body = strBody 'txtSpector_Cd.Text & " for client no: " & txtCus_No.Text 'TextBox1.Text
                .Save()
                .Send()
            End With


            'Release COM Objects
            If apptItem IsNot Nothing Then Marshal.ReleaseComObject(apptItem)

        Catch er As Exception
            iErrorCount += 1
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)

        End Try
    End Sub


    Friend Sub ListAttendees(ByVal title As String, ByVal strStartDt As String, ByVal strEndDt As String, ByVal strSubject As String, Optional ByVal strBody As String = "", Optional ByVal strLocation As String = "", Optional ByRef iErrorCount As Integer = 0)
        'Dim recipients As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        'Dim apItem As New Microsoft.Office.Interop.Outlook.Application

        'apptItem = apItem.Session.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)

        'https://www.add-in-express.com/creating-addins-blog/2013/06/10/outlook-calendar-appointment-meeting-items/


        Try
            Dim dtSConvStr As Date = Convert.ToDateTime(strStartDt)
            Dim dtEConvStr As Date = Convert.ToDateTime(strEndDt)



            Dim folder As Microsoft.Office.Interop.Outlook.Folder = Nothing
            Dim folderItems As Microsoft.Office.Interop.Outlook.Items = Nothing
            Dim filteredItems As Microsoft.Office.Interop.Outlook.Items = Nothing

            Dim apptItem As Microsoft.Office.Interop.Outlook.AppointmentItem

            Dim apItem As New Microsoft.Office.Interop.Outlook.Application

            Dim objNS As Outlook._NameSpace = apItem.Session


            'apItem = apItem.Session.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)

            folder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)
            'apItem.ActiveExplorer.CurrentFolder
            Debug.Print(folder.Name)
            If folder.DefaultItemType = Outlook.OlItemType.olAppointmentItem Then


                folderItems = folder.Items
                filteredItems = folderItems.Restrict("[MessageClass] = 'IPM.Appointment'")
                Dim fRemoved As Boolean = False
                Dim intfEdit As Integer = 0


                Dim i As Integer = 1

                Do Until i > filteredItems.Count

                    apptItem = filteredItems.Item(i)

                    Dim optionalAttendees As String = "Organizer: " & apptItem.Organizer & " Subject: " & apptItem.Subject & " Start Date: " & apptItem.Start & " End Date " & apptItem.End & vbCrLf & apptItem.MessageClass

                    If apptItem.Subject = title Then

                        With apptItem
                            .Subject = title
                            .Location = strLocation 'txtLocation.Text
                            .Start = dtSConvStr 'dtSConvStr 'DateTime.Now
                            .End = dtEConvStr 'dtEConvStr 'Date.Now.AddHours(2)
                            .Duration = 5
                            .Body = strBody 'txtSpector_Cd.Text & " for client no: " & txtCus_No.Text 'TextBox1.Text
                            .Save()
                            .Send()
                        End With
                        intfEdit += 1
                    End If

                    i = i + 1
                    intfEdit += 0
                    Marshal.ReleaseComObject(apptItem)
                Loop


                If intfEdit = 0 Then

                    If dtSConvStr < Date.Now Then
                        dtSConvStr = Date.Now
                        Call FollowUp(dtSConvStr)
                        txtDecision_Dt.Text = dtSConvStr

                        dtEConvStr = Date.Now.AddHours(1)
                        Call FollowUp(dtEConvStr)
                        txtEndDecision_Dt.Text = dtEConvStr
                    End If

                    apptItem = apItem.Session.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)

                    With apptItem
                        .Subject = title
                        .Location = strLocation 'txtLocation.Text
                        .Start = dtSConvStr 'dtSConvStr 'DateTime.Now
                        .End = dtEConvStr 'dtEConvStr 'Date.Now.AddHours(2)
                        .Duration = 5
                        .Body = strBody 'txtSpector_Cd.Text & " for client no: " & txtCus_No.Text 'TextBox1.Text
                        .Save()
                        .Send()
                    End With

                    'Release COM Objects
                    If apptItem IsNot Nothing Then Marshal.ReleaseComObject(apptItem)

                End If



            End If

            'Release COM Objects
            Marshal.ReleaseComObject(filteredItems)
            Marshal.ReleaseComObject(folderItems)
            Marshal.ReleaseComObject(folder)

            Call releaseOutl(filteredItems)
            Call releaseOutl(folderItems)
            Call releaseOutl(folder)
            Call releaseOutl(apItem)
            Call releaseOutl(objNS)

        Catch ex As Exception
            iErrorCount += 1
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub





    Private Sub releaseOutl(ByRef ob As Object)
        Try
            ob = Nothing
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


#End Region


    Private Sub cboQuoteResult_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboQuoteResult.SelectedValueChanged
        Try
            '  If cboStatusQuote.Text <> "pending" Then

            'If cboQuoteResult.Text = "no order - closed" Then
            '    lblCommOrdClosed.Visible = True
            '    txtCommentQuoteResult.Visible = True
            '    lblCommOrdClosed.Text = "Why order is closed?"
            '    ' txtCommentQuoteResult.Text = "Comments: Why order is closed?"
            'Else
            '    lblCommOrdClosed.Visible = False
            '    txtCommentQuoteResult.Visible = False
            '    txtCommentQuoteResult.Text = String.Empty
            'End If
            ' Else
            If (cboStatusQuote.Text = "pending" Or cboStatusQuote.Text = "sent to client") And cboQuoteResult.Text = "no order - closed" Then
                MsgBox("The Quote can't be " & Trim(cboStatusQuote.Text) & " and in the same time closed.")
                cboQuoteResult.SelectedIndex = 0
                cboQuoteResult.Refresh()
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub cboStatusQuote_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatusQuote.SelectedValueChanged
        Try
            'If cboQuoteResult.Text <> "no order - closed" Then

            'If cboStatusQuote.Text = "pending" Then
            '    lblCommOrdClosed.Visible = True
            '    txtCommentQuoteResult.Visible = True
            '    lblCommOrdClosed.Text = "Why order is pending?"
            '    ' it was in comment '   txtCommentQuoteResult.Text = "Comments: Why order is pending?"
            'Else
            '    lblCommOrdClosed.Visible = False
            '    txtCommentQuoteResult.Visible = False
            '    txtCommentQuoteResult.Text = String.Empty
            'End If
            'Else
            If cboQuoteResult.Text = "no order - closed" And (cboStatusQuote.Text = "pending" Or cboStatusQuote.Text = "sent to client") Then
                MsgBox("Quote it can't be " & Trim(cboStatusQuote.Text) & " and same time closed.")
                cboStatusQuote.SelectedIndex = 0

                cboStatusQuote.Refresh()
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tsbClientEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClientEmail.Click
        Try
            Dim oFrmEmailQ As New frmEmailQuickProgram(m_Customer, m_Program)
            oFrmEmailQ.CONTACT_ID = cboContact_ID.SelectedValue
            oFrmEmailQ.Show()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID 21.03.2015
    Private Sub lblDecision_Dt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDecision_Dt.MouseClick
        Try

            Call ShowMyDialogBox()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID 21.03.2015
    Private m_DecisionDt As DateTime
    Private m_EndDecisionDt As DateTime
    Private m_strBodyOutlook As String
    Private m_strLocationOutlook As String
    Public Property DecisionDt As DateTime
        Get
            DecisionDt = m_DecisionDt
        End Get
        Set(ByVal value As DateTime)
            m_DecisionDt = value
        End Set
    End Property
    Public Property EndDateDt As DateTime
        Get
            EndDateDt = m_EndDecisionDt
        End Get
        Set(ByVal value As DateTime)
            m_EndDecisionDt = value
        End Set
    End Property
    Public Property BodyOutlook As String
        Get
            BodyOutlook = m_strBodyOutlook
        End Get
        Set(ByVal value As String)
            m_strBodyOutlook = value
        End Set
    End Property
    Public Property LocationOutlook As String
        Get
            LocationOutlook = m_strLocationOutlook
        End Get
        Set(ByVal value As String)
            m_strLocationOutlook = value
        End Set
    End Property
    Public Sub ShowMyDialogBox()

        Dim testDialog As New frmOutlookAppointment()

        ' Show testDialog as a modal dialog and determine if DialogResult = OK.



        testDialog.txtSubject.Text = txtSpector_Cd.Text & " for client no: " & txtCus_No.Text


        testDialog.ShowDialog(Me)

        ' If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

        'If testDialog.Validation = True Then

        ' Read the contents of testDialog's TextBox.
        If testDialog.txtSubject.Text <> "" And testDialog.m_boolSave = True Then
            Dim dtS As Date = testDialog.dtpStartHours.Value.ToShortTimeString
            Dim dtE As Date = testDialog.dtpEndHours.Value.ToShortTimeString

            m_DecisionDt = Convert.ToDateTime(testDialog.txtStartTime.Text & " " & dtS)
            m_EndDecisionDt = Convert.ToDateTime(testDialog.txtEndTime.Text & " " & dtE)



            'testDialog.txtStartTime.Text
            txtDecision_Dt.Text = m_DecisionDt
            txtEndDecision_Dt.Text = m_EndDecisionDt
            m_strBodyOutlook = testDialog.txtBody.Text
            m_strLocationOutlook = testDialog.txtLocation.Text
            txtDecision_Dt.Focus()
            txtEndDecision_Dt.Focus()

        End If

        testDialog.Dispose()

    End Sub 'ShowMyDialogBox

    '++ID 16.07.2015
    Private Sub btnCustomizedPack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomizedPack.Click
        Try

            Call Menu_Save()

            Dim frm As New frmItem_Picture(m_Program.Cus_Prog_Id, "QuoteProgram")

            frm.ShowDialog()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'to calm item_color in dgvItems
    Private Sub dgvItems_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItems.DataError
        e.Cancel = True
    End Sub
    '++ID 16.07.2015
    Private Sub CopyAndPasteThisItemToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyAndPasteThisItemToolStripMenuItem.Click
        Try

            Call CopyLineInsert(dgvItems, dtItems)

            Debug.Print(" CopyThisRowToolStripMenuItem_Click - " & dgvItems.CurrentRow.Cells(Items.CUS_PROG_ITEM_LIST_ID).Value)

            dgvItems.DataSource = dtItems
            dgvItems.AllowUserToAddRows = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '++ID 16.07.2015
    Public Sub CopyLineInsert(ByRef dgvItems As DataGridView, ByRef dtItems As DataTable)

        Debug.Print("CopyLineInsert")
        ' Copied information put in Datatable 
        Try
            Dim drNewRow As DataRow

            drNewRow = dtItems.NewRow

            '   drNewRow.Item("CUS_PROG_ID") = dgvItems.CurrentRow.Cells(Items.CUS_PROG_ID).Value
            drNewRow.Item("PROD_CAT_ID") = dgvItems.CurrentRow.Cells(Items.PROD_CAT_ID).Value
            drNewRow.Item("ITEM_CD") = dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value
            drNewRow.Item("CUSTOM_ITEM_ID") = dgvItems.CurrentRow.Cells(Items.CUSTOM_ITEM_ID).Value
            drNewRow.Item("ITEM_DESC") = dgvItems.CurrentRow.Cells(Items.ITEM_DESC).Value
            drNewRow.Item("ITEM_NO") = dgvItems.CurrentRow.Cells(Items.ITEM_NO).Value
            drNewRow.Item("ITEM_COLOR") = dgvItems.CurrentRow.Cells(Items.ITEM_COLOR).Value
            drNewRow.Item("QUOTE_TYPE_ID") = dgvItems.CurrentRow.Cells(Items.QUOTE_TYPE_ID).Value
            drNewRow.Item("QUOTE_SHIP_METHOD_ID") = dgvItems.CurrentRow.Cells(Items.QUOTE_SHIP_METHOD_ID).Value
            drNewRow.Item("MIN_QTY_ORD") = dgvItems.CurrentRow.Cells(Items.MIN_QTY_ORD).Value
            drNewRow.Item("UNIT_PRICE") = dgvItems.CurrentRow.Cells(Items.UNIT_PRICE).Value
            drNewRow.Item("EQP_LEVEL") = dgvItems.CurrentRow.Cells(Items.EQP_LEVEL).Value
            drNewRow.Item("EQP_PCT") = dgvItems.CurrentRow.Cells(Items.EQP_PCT).Value
            drNewRow.Item("DEC_MET_ID") = dgvItems.CurrentRow.Cells(Items.DEC_MET_ID).Value
            drNewRow.Item("DEC_MET_GROUP_ID") = dgvItems.CurrentRow.Cells(Items.DEC_MET_GROUP_ID).Value
            drNewRow.Item("SETUP_WAIVED") = dgvItems.CurrentRow.Cells(Items.SETUP_WAIVED).Value
            drNewRow.Item("SETUP_PRICE") = dgvItems.CurrentRow.Cells(Items.SETUP_PRICE).Value

            drNewRow.Item("CHARGE_ID") = dgvItems.CurrentRow.Cells(Items.CHARGE_ID).Value
            drNewRow.Item("RUN_CHARGE") = dgvItems.CurrentRow.Cells(Items.RUN_CHARGE).Value


            drNewRow.Item("COLOR_COUNT") = dgvItems.CurrentRow.Cells(Items.COLOR_COUNT).Value
            drNewRow.Item("LOCATION_COUNT") = dgvItems.CurrentRow.Cells(Items.LOCATION_COUNT).Value
            drNewRow.Item("PACK_ID") = dgvItems.CurrentRow.Cells(Items.PACK_ID).Value

            drNewRow.Item("USER_LOGIN") = dgvItems.CurrentRow.Cells(Items.USER_LOGIN).Value
            drNewRow.Item("UPDATE_TS") = dgvItems.CurrentRow.Cells(Items.UPDATE_TS).Value
            drNewRow.Item("DIRTY") = dgvItems.CurrentRow.Cells(Items.DIRTY).Value

            drNewRow.Item("CUS_PROG_ITEM_LIST_GUID") = Guid.NewGuid()
            drNewRow.Item("LINE_COMMENTS") = dgvItems.CurrentRow.Cells(Items.LINE_COMMENTS).Value
            drNewRow.Item("Image") = dgvItems.CurrentRow.Cells(Items.Image).Value
            drNewRow.Item("DocId") = dgvItems.CurrentRow.Cells(Items.DocId).Value

            dtItems.Rows.Add(drNewRow)

        Catch ex As Exception
            MsgBox("Copied information put in Datatable " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "Charge"
    Private Sub dgvCharges_Load()

        Try

            dgvOptions.Columns.Clear()

            With dgvOptions.Columns
                .Add(DGVTextBoxColumn("CHARGE_ID", "Charge ID", 50))
                .Add(DGVTextBoxColumn("DESCRIPTION", "Description", 160))
                .Add(DGVTextBoxColumn("SHORT_DESC", "Charge", 90))
                .Add(DGVCheckBoxColumn("Always", "Always", 45))
                .Add(DGVCheckBoxColumn("Never", "Never", 45))
                .Add(DGVTextBoxColumn("CD_TP", "cd_tp", 40))
                .Add(DGVTextBoxColumn("CURR_CD", "Currency", 60))
                .Add(DGVTextBoxColumn("CD_TP_1_CUST_NO", "Customer", 90))
                .Add(DGVTextBoxColumn("CD_TP_1_ITEM_NO", "Item no", 90))
                .Add(DGVTextBoxColumn("PRC_OR_DISC_1", "Prix", 60))
                .Add(DGVTextBoxColumn("START_DT", "Start Dt", 80))
                .Add(DGVTextBoxColumn("END_DT", "End Dt", 80))
                .Add(DGVTextBoxColumn("extra_8", "Create Dt", 90))
                .Add(DGVTextBoxColumn("extra_9", "Update Dt", 90))
                .Add(DGVTextBoxColumn("extra_15", "User Login", 90))
                .Add(DGVTextBoxColumn("ID", "ID", 50))
                'CHARGE_ORDER
            End With


            With dgvOptions
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                .Columns(OptionAll.CHARGE_ID).Visible = False
                .Columns(OptionAll.DESCRIPTION).Visible = True
                .Columns(OptionAll.cd_tp).Visible = False
                .Columns(OptionAll.curr_cd).Visible = True
                .Columns(OptionAll.cd_tp_1_cust_no).Visible = False
                .Columns(OptionAll.cd_tp_1_item_no).Visible = False
                .Columns(OptionAll.extra_8).Visible = True 'create date
                .Columns(OptionAll.extra_9).Visible = True 'update date
                .Columns(OptionAll.extra_15).Visible = True
                .Columns(OptionAll.ID).Visible = False
            End With

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

    Private Sub dgvCharges_FillGrid()

        Try
            Dim strSql As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            strSql = _
            " select m.CHARGE_ID, m.DESCRIPTION, m.SHORT_DESC, " &
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '1' THEN 1 ELSE 0 END)) as Always, " & _
              " CONVERT(BIT,(CASE ISNULL(o.extra_5, '0') WHEN '2' THEN 1 ELSE 0 END)) as Never, " & _
            " o.cd_tp, o.curr_cd, " & _
            " o.cd_tp_1_cust_no, cd_tp_1_item_no, prc_or_disc_1 , o.start_dt, o.end_dt, " & _
            " o.extra_8, o.extra_9, ex.User_Name as extra_15, o.ID " & _
            " from oeprcfil_sql o right join MDB_CFG_CHARGE m ON o.cd_tp_1_item_no = m.ITEM_NO  " & _
            " left join EXACT_TRAVELER_PERMISSION ex on o.extra_15 = ex.ID " & _
            " where o.cd_tp_1_cust_no = '" & m_Customer.cmp_code & "' " & _
            " and o.cd_tp_3_cust_type = '' and o.end_dt  >= GETDATE() "

            '------------------------------------------------------------------------------------------------

            dtOptions = db.DataTable(strSql)

            dgvOptions.DataSource = dtOptions
            dgvOptions.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub
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

    Private Sub tsRenew_Click(sender As Object, e As EventArgs) Handles tsRenew.Click
        Try

            Call tsbSave_Click(sender, e)

            If Program.Quote_Step_ID = Quote_Step.Pending_Pricing_Approval Then
                MsgBox("Prices are currently in the process of being entered and approved, you cannot save.")
                Exit Sub
            Else
                Call RenewProgramVersion()

                Refresh_C = True
                dgvItems.Refresh()
                Call Menu_Refresh()

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
    '++ID 3.14.2018 function was created while Customer file start use Master Database Table
    Private Sub ValidateColorList()
        Try
            If dgvItems.RowCount <> 0 Then
                Dim item_no As String = ""
                Dim dgvcc As DataGridViewComboBoxCell

                'comboboxCellrec = New DataGridViewComboBoxCell
                'comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.DEC_MET_DESC, drow.Index), DataGridViewComboBoxCell)

                For Each dgvRow As DataGridViewRow In dgvItems.Rows

                    item_no = If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value)

                    If dgvRow.Cells(Items.ITEM_CD).Value.ToString.ToUpper.Contains("CUSTOM") <> True Then

                        If Trim(dgvRow.Cells(Items.ITEM_COLOR).Value) <> returnColorList(If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value)) Then
                            '    dgvRow.Cells(Items.ITEM_COLOR).Value = returnColorList(If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value))
                            dgvcc = New DataGridViewComboBoxCell
                            dgvcc = DirectCast(dgvRow.Cells(Items.ITEM_COLOR), DataGridViewComboBoxCell)
                            dgvcc.Value = returnColorList(If(dgvRow.Cells(Items.ITEM_NO).Value.Equals(DBNull.Value), "", dgvRow.Cells(Items.ITEM_NO).Value))

                        End If
                    End If
                Next
            End If
            dgvItems.Refresh ()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)

        End Try
    End Sub





    '++ID 7.28.2018
    Private Sub btnNote_Click(sender As Object, e As EventArgs) Handles btnNote.Click
        Try
            If txtNote.Height < 30 Then
                With txtNote
                    .Height = 176
                    .Width = 320
                    .Location = New Point(75, 81)
                    .Visible = True
                    btnNote.BackColor = Color.Red
                End With
            Else
                With txtNote
                    .Height = 20
                    .Width = 100
                    .Location = New Point(75, 237)
                    .Visible = False
                    btnNote.BackColor = Color.FromArgb(192, 192, 0)
                End With
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tsbExportForm_Click(sender As Object, e As EventArgs) Handles tsbExportForm.Click
        If m_Program_Type = "Program" Then
            If Not bwf.IsBusy = True Then
                bwf.RunWorkerAsync()
            End If
        ElseIf m_Program_Type = "Quote" Then
            txtStart_Dt.Text = Date.Now.Date
            txtEnd_Dt.Text = Date.Now.Date.AddDays(13)
            If Menu_Save() Then
                If Not bwf.IsBusy = True Then
                    bwf.RunWorkerAsync()
                End If
            Else
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If
    End Sub
    Dim bwf As BackgroundWorker = New BackgroundWorker
    Private Sub bwf_DoWork(sender As Object, e As DoWorkEventArgs)
        Me.Invoke(ChangePictureVisibility, True)

        '++ID modified 7.15.2019
        'added function with one return value preference contact language
        'it replace if below
        Dim _ef_lang As String = ef_lang(Trim(m_Program.Spector_Cd)) 'default

        'If Remove_Space(m_Customer.Currency) = "CAD" Then
        '    ef_lang = "fr"
        'End If

        Dim oc_switchlang As c_SwitchLang = New c_SwitchLang(_ef_lang)

        '  Dim oc_switchlang As c_SwitchLang = New c_SwitchLang(ef_lang(Trim(m_Program.Spector_Cd)))

        If m_Program_Type = "Program" Then
            Dim o_PDF As New c_PDF(oc_switchlang, Trim(m_Program.Spector_Cd), m_Program_Type)
        ElseIf m_Program_Type = "Quote" Then
            Dim o_PDF As New c_PDF(oc_switchlang, Trim(m_Program.Spector_Cd), m_Program_Type)
            Call ProcessToStep(Quote_Step.Ready_To_Send)
        End If
    End Sub
    Private Sub bwf_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Me.Invoke(ChangePictureVisibility, False)
    End Sub

    ' ++ID 7.15.2019 funtion return language preference for selected contact
    ' if contact is not selected default value is english
    Private Function ef_lang(ByVal p_Spector_CD As String) As String
        ef_lang = ""
        Try

            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            Dim l As String = "EN"

            strSql =
               " select case when (UPPER(isnull(cn.taalcode,'')) = '' or UPPER(isnull(cn.taalcode,'')) = 'EN')  then 'EN' else 'FR' end  as  ef_lang " &
               " from MDB_CUS_PROG m inner join cicmpy c ON m.CUS_NO = c.cmp_code LEFT JOIN cicntp cn on m.CONTACT_ID = cn.ID " &
               " left join user_permissions_info u on m.PROG_CSR = u.User_Name where m.SPECTOR_CD = '" & p_Spector_CD & "'"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                l = dt.Rows(0).Item("ef_lang").ToString.ToUpper
            End If

            Return l

        Catch ex As Exception
            MsgBox("Error in ef_lang(spector_cd)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'justin 20200106
    Public Sub SetBackColorCombo(ByVal cboCell As DataGridViewComboBoxCell, ByVal pstrItem_Cd As String, ByVal pstrValue As String, Optional ByRef refColor As DataTable = Nothing)

        Try
            Dim dtTable As DataTable
            dtTable = GetBackAllColorList(pstrValue)

            If dtTable.Rows.Count <> 0 Then
                With cboCell
                    .DataSource = dtTable '.Rows(0).Item("Item_Color").ToString 'ChangeCboColorList(pstrItem_Cd, pstrValue)
                    refColor = dtTable  'ChangeCboColorList(pstrItem_Cd, pstrValue).Rows(0).Item("Item_Color").ToString
                    .ValueMember = "Item_Color"
                    .DisplayMember = "Item_Color"
                    .Value = dtTable.Rows(0).ItemArray(0).ToString()
                End With
                'MessageBox.Show(dtTable.Rows(0).ItemArray(0).ToString())
            End If

        Catch er As Exception
            MsgBox("Error in frmQuickProgram." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'justin 20200106
    Private Function GetBackAllColorList(ByVal pstrValue As String) As DataTable
        GetBackAllColorList = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim sql As String

            sql = " select   'ALL' as Item_Color " _
                & " UNION " _
                & " select  'MULTI' as Item_Color  " _
                & " UNION " _
                & " Select Color_list as Item_Color from View_MDB_ITEM_DETAIL   " _
                & " order by Item_color "

            'removed Multi 3.29.2018
            sql = " Select Color_list as Item_Color from View_MDB_ITEM_DETAIL where color_id =   " + pstrValue _
                & " order by Item_color "
            dt = db.DataTable(sql)

            If dt.Rows.Count <> 0 Then
                Return dt
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'justin 20200106
    Private Function Getorignal_color_id(ByVal pstrValue As String) As DataTable
        Getorignal_color_id = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim sql As String

            sql = " Select Color_id as Item_Color_id from View_MDB_ITEM_DETAIL where item_no =   '" + pstrValue + "' "
            dt = db.DataTable(sql)

            If dt.Rows.Count <> 0 Then
                Return dt
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function CheckDiscoProp(ByVal _item_no As String) As String
        CheckDiscoProp = ""

        Try

            Dim db As New cDBA
            Dim dt As DataTable
            Dim strSql As String = ""

            strSql =
            " SELECT  item_note_4  FROM   IMITMIDX_SQL " &
            " WHERE  item_no = '" & _item_no.Trim & "' " &
            " AND (item_note_4 like '%Disco%' or item_note_4 like '%DNR%') "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Return Trim(dt.Rows(0).Item("item_note_4").ToString)
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub SetUnsaved(sender As Object, e As CancelEventArgs) Handles txtStart_Dt.Validating, txtSpector_Cd.Validating, txtQuote_Step_User.Validating, txtQuote_Step_ID.Validating, txtProg_CSR.Validating, txtProg_Comments.Validating, txtProg_Cd.Validating, txtImprint.Validating, txtEnd_Dt.Validating, txtCus_No.Validating, dgvItems.Validating, cboProg_Type.Validating, cboContact_ID.Validating

    End Sub

    '++ID 12042024 validate if customer is included in any group if not unchek the checkbox
    Private Sub chkAllGroup_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAllGroup.CheckStateChanged
        Try

            If chkAllGroup.CheckState = CheckState.Checked Then

                Dim db As New cDBA
                Dim dt As DataTable
                Dim strSql As String = ""

                strSql =
                " SELECT isnull(cus_note_3,'') as cus_note_3 FROM ARCUSFIL_SQL WHERE Ltrim(Rtrim(cus_no)) = '" & Trim(m_Customer.cmp_code) & "' "

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then
                    If Trim(dt.Rows(0).Item("cus_note_3").ToString) = String.Empty Then
                        MsgBox("Customer is not part of any group.")
                        chkAllGroup.CheckState = CheckState.Unchecked
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


End Class

