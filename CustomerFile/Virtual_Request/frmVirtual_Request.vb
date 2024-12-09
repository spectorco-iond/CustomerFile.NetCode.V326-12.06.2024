Imports System.Globalization
Imports System.IO
Imports System.Web
Imports System.Web.UI.Page
Public Class frmVirtual_Request
    Private dstVar As IEnumerable(Of cMdb_Item_Imp_Loc_VIEW)

    Private oMdb_Item_VColor As cMdb_Item_VariantColor

    Private LoadVariable As Boolean

    Private oMdb_Item_master As cMdb_Item_Master
    Private olstMaster As List(Of cMdb_Item_Master) = New List(Of cMdb_Item_Master)

    Private oMdb_Item_VariantColor As cMdb_Item_VariantColor
    Private olstVariantColor As List(Of cMdb_Item_VariantColor) = New List(Of cMdb_Item_VariantColor)

    Private oMdb_Item_Imp_Loc_VIEW As cMdb_Item_Imp_Loc_VIEW
    Private olstImp_Loc_VIEW As List(Of cMdb_Item_Imp_Loc_VIEW) = New List(Of cMdb_Item_Imp_Loc_VIEW)

    Private olsCicmpy As List(Of cCicmpy) = New List(Of cCicmpy)
    Private oCicmpy As cCicmpy

    Private olsCicntpReq As List(Of cCicntpReq) = New List(Of cCicntpReq)
    Private oCicntpReq As cCicntpReq

    Private oCfgEnum As cCfgEnum
    Private olsCfgEnum As List(Of cCfgEnum) = New List(Of cCfgEnum)

    Private oMdb_Item_Doc As cMdb_Item_Doc
    Private olstMdb_Item_Doc As List(Of cMdb_Item_Doc)
    Private olstMdb_Item_Doc_Attach As List(Of cMdb_Item_Doc) = New List(Of cMdb_Item_Doc)  'make copy for attach in email 

    Private oMdb_Cfg_Item_Doc_Type As cMdb_Cfg_Item_Doc_Type
    Private olstMdb_Cfg_Item_Doc_Type As List(Of cMdb_Cfg_Item_Doc_Type)

    Private oMDB_CFG_IMP_LOC As cMDB_CFG_IMP_LOC
    Private olstMDB_CFG_IMP_LOC As List(Of cMDB_CFG_IMP_LOC)

    Private oMDB_CFG_DEC_MET As cMDB_CFG_DEC_MET
    Private olstMDB_CFG_DEC_MET As List(Of cMDB_CFG_DEC_MET)

    Private oMdb_cfg_Color As cMdb_Cfg_Color
    Private olstMdb_Cfg_Color As List(Of cMdb_Cfg_Color)

    Private comboboxCellrec As DataGridViewComboBoxCell
    Private textboxCellrec As DataGridViewTextBoxCell
    Private Const LabelRowCount As String = "Rows:"

    Private RequestID As Integer 'main variable
    Private ReviewId As Integer 'main variable

    Private oReqItems_AdditDetail As cReqItems_AdditLocation
    Private olstReItems_AdditDetail As List(Of cReqItems_AdditLocation)

    Private oReqSentMail As cReqSentMails
    Private olstReqSentMails As List(Of cReqSentMails)
    Private pReqType As String = ""
    'use this variable in the FillLstBox, because if listbox is not close user can click by error on another row on the grid 
    ' and row index will be changed
    Private lststyleCurrentRow As Int32 = 0

    Private VarActivateEmailSearch As Boolean

    Private oReqDocBindItem As cReqDocBindItem
    Private olstReqDocBindItem As List(Of cReqDocBindItem)

    Private Const Status As String = "Status : "
    Private varDelete As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'RequestID = 1
        'ReviewId = 10

    End Sub

    'this constructor will be call only if is new request 
    Public Sub New(p_intRequestsId As Integer, p_intReviewId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'true is means form is in time for load
        LoadVariable = True
        RequestID = p_intRequestsId
        ReviewId = p_intReviewId

    End Sub

    Private Sub frmVirtual_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim strQuery As String

            'txtSpecInstrWrite.Text = "panSpecInstr1.width = " & panSpecInst1.Width.ToString & vbCrLf _
            '        & " , panCommentsGraph.width = " & panCommentsGraph.Width.ToString


            'for additional listview
            'use for activate xTxtShowSenderEmail_TextChanged 
            'because default is type of request and email is selected by type 
            'now if you user want send any other person need click on the xTxtShowSenderEmail_DoubleClick and variable will take True value
            'and xTxtShowSenderEmail_TextChanged is activate for his event
            VarActivateEmailSearch = False
            varDelete = False

            'text bow will displayed when  lnlLabelContactShow is clicked
            txtContactSearch.Hide()
            txtContactSearch.Location = New Point(105, 42)

            lstBoxAdd.Hide()
            panLstBoxAdd.Hide()
            txtBox.Hide()

            oMdb_Cfg_Item_Doc_Type = New cMdb_Cfg_Item_Doc_Type
            olstMdb_Cfg_Item_Doc_Type = New List(Of cMdb_Cfg_Item_Doc_Type)
            'fill list with all type
            olstMdb_Cfg_Item_Doc_Type = oMdb_Cfg_Item_Doc_Type.Load("")

            oReqItems = New cReqItems()
            olstReqItems = New List(Of cReqItems)
            olstReqItems_old = New List(Of cReqItems)

            '------------------- location for label ------------------------
            Call LabelPositionInMiddle()

            '------------- Checkbox for sent email need for future put in a function ---------------
            'oExact_Traveler_Permission = New cExact_Traveler_Permission
            'With chkSendToGraphic
            '    Select Case oExact_Traveler_Permission.perm_group_id
            '        Case 182 'IT 179,Graphics 182
            '            .Enabled = False
            '        Case Else
            '            .Enabled = True
            '    End Select
            'End With
            '----------------------------

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If oExact_Traveler_Permission.perm_group_id <> 182 Then
                txtSpecInstrWrite.Enabled = True
                lblSendEmailCSR.Enabled = False
                lblTimeStampGR.Enabled = False
            ElseIf oExact_Traveler_Permission.perm_group_id = 182 Then
                txtSendCommFromGraph.Enabled = True
                '++ID Graphic don't need save the request
                'if click on the status, it will be inserted in DB in status table
                'for comunication graphic will use button sent to CSR comunication
                txtbtnSave.Enabled = False
                lblTimeStampCS.Enabled = False
            End If
            '---------------------------------------------------------------
            Call loadNew_Story()
            '----------------------- load documents ------------------------
            Call DisplayDocInPanel()
            'show how much is size of Document Panel
            lblDetailSizeRezult.Text = FilesSize(0).ToString & "KB - " & FormatNumber(FilesSize(0) / 1024, 0) & "MB"
            '---------------------------------------------------------------

            Call Columns_VirtualRequest(dgvStoryBoard, Me)

            'chec if exist items for this requestId & reviewId
            'if exist don't add default line in the grid
            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItems = oReqItems.LoadLst(strQuery)
            'keep that value until form is close
            'when user exit from storyboard need comparate old value with new 
            'was declared in modGlobal
            olstReqItems_old = olstReqItems

            If olstReqItems.Count = 0 Then
                'this is default line added in dgvStoryboard in the case if is new request
                dgvStoryBoard.Rows.Add()
                dgvStoryBoard.CurrentRow.Height = 30
                dgvStoryBoard.BeginEdit(True)
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).ReadOnly = False

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Value = "X"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Tag = "0"

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_master_id)).Value = "0"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.ReqItemId)).Value = "0"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.GUID)).Value = ""
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Parent_GUID)).Value = ""

                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.Font = New Font("Arial", 14, FontStyle.Bold)
                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.BackColor = Color.Red

                dgvStoryBoard.BeginEdit(False)
            ElseIf olstReqItems.Count <> 0 Then
                'function fro load grid was before 

                ''put function for populate grid from cReqItems
                'If PopulateGridFromDB() <> True Then
                '    MsgBox("Grid Is Not filled properly.")
                'End If

                '++ID 1.16.2018 check the addtional location for the displayed Items
                'this declaration or variable never initialize is global
                oReqItems_AdditDetail = New cReqItems_AdditLocation
                olstReItems_AdditDetail = New List(Of cReqItems_AdditLocation)
                olstReqItems_AdditDetail_Old = New List(Of cReqItems_AdditLocation)


                strQuery = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqItems_AdditLocation ra WITH (Nolock) on " _
                              & " r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " and ReviewId = " & ReviewId & ""

                olstReItems_AdditDetail = oReqItems_AdditDetail.LoadLst(strQuery)

                'keep old list for coomparate old list with new 
                olstReqItems_AdditDetail_Old = olstReItems_AdditDetail


                '++ID 2.13.2018
                'check if we have anything in ReqDocBindItem
                oReqDocBindItem = New cReqDocBindItem
                olstReqDocBindItem = New List(Of cReqDocBindItem)

                strQuery = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqDocBindItem ra WITH (Nolock) " _
                     & " on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " And ReviewId = " & ReviewId & ""

                olstReqDocBindItem = oReqDocBindItem.LoadLst(strQuery)

                'added 3.28.2018
                'put function for populate grid from cReqItems
                If PopulateGridFromDB() <> True Then
                    MsgBox("Grid Is Not filled properly.")
                End If

            End If

            Call DisplayComments()

            Call GridLine_Color()

            LoadVariable = False
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '-------------------------- function for vallidate certaine cell ---------------------------
    Private Function ValidateDecoProperties(Optional ByRef respons As String = "") As Boolean
        ValidateDecoProperties = True
        Try
            Dim varResospons As String = ""
            Dim varBool As Boolean = True


            If (String.IsNullOrEmpty(Trim(txtCustomer.Text)) Or String.IsNullOrWhiteSpace(Trim(txtCustomer.Text))) Then
                varBool = False

                varResospons &= "Required Field: Customer Code and Customer Name." & vbCrLf
                txtCustomer.BackColor = Color.Red

                'If varResospons.Length > 0 Then
                '    respons &= "Required Field for ITEM NO : " & "" & " - " & varResospons
                '    respons &= vbCrLf
                'Else

                '    respons = varResospons
                'End If
            Else
                txtCustomer.BackColor = Color.Empty
            End If

            If (String.IsNullOrEmpty(Trim(lnkLblContactShow.Text)) Or String.IsNullOrWhiteSpace(Trim(lnkLblContactShow.Text))) Then
                varBool = False

                varResospons &= "Required Field Customer Contact Name and Customer Email." & vbCrLf
                '   lblContact.BackColor = Color.Red
                lnkLblContactShow.AutoSize = False

                lnkLblContactShow.Width = 140
                lnkLblContactShow.BackColor = Color.Red
            Else
                'lblContact.BackColor = Color.Empty
                lnkLblContactShow.AutoSize = True
                lnkLblContactShow.BackColor = Color.Empty
            End If

            'for Custmoer and Contact label
            respons &= varResospons

            For Each drow As DataGridViewRow In dgvStoryBoard.Rows

                varResospons = ""

                If drow.Cells(Request.IMPRINT_LOGO).Value = "" And drow.Cells(Request.Is_kit).Value = "N" And Trim(drow.Cells(Request.item_color).Value.ToString) <> "0" And Trim(drow.Cells(Request.item_color).Value.ToString) <> "empty" Then

                    varBool = False
                    varResospons &= DirectCast([Enum].Parse(GetType(Request), (CInt(Request.IMPRINT_LOGO))), Request).ToString & ", "
                    drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.BackColor = Color.Red
                    drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.ForeColor = Color.White

                Else

                    If drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.BackColor = Color.Red Then
                        drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.BackColor = Color.White
                        drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.ForeColor = Color.Maroon
                    End If

                End If

                If dgvStoryBoard.Item(Request.DEC_MET_DESC, drow.Index).EditType.Name <> "DataGridViewTextBoxEditingControl" Then
                    '++ ID put in comment 3.26.2019
                    '   varResospons = ""
                    'check Imprint Location is required field
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.IMP_DESCRIPTION), drow.Index), DataGridViewComboBoxCell)
                    ' comboboxCellrec = DirectCast(drow.Cells(CInt(Request.DEC_MET_DESC)), DataGridViewComboBoxCell)


                    If (String.IsNullOrEmpty(comboboxCellrec.Value) Or String.IsNullOrWhiteSpace(comboboxCellrec.Value)) And
                        comboboxCellrec.Items.Count <> 0 And
                        String.IsNullOrEmpty(drow.Cells(CInt(Request.Parent_GUID)).ToString) Or String.IsNullOrWhiteSpace(drow.Cells(CInt(Request.Parent_GUID)).ToString) Then
                        varBool = False

                        '                        Filter in enum
                        varResospons &= DirectCast([Enum].Parse(GetType(Request), (CInt(Request.IMP_DESCRIPTION))), Request).ToString & ", " 'comboboxCellrec.Value

                        'change backgound color for header column name
                        'put in comment because after each rows it will overwrite red in white and whiote in red
                        'only information from latest row will be assignewd properly.
                        'If dgvStoryBoard.Columns(CInt(Request.IMP_DESCRIPTION)).HeaderCell.Style.BackColor <> Color.Red Then
                        '    dgvStoryBoard.Columns(CInt(Request.IMP_DESCRIPTION)).HeaderCell.Style.BackColor = Color.Red
                        'End If

                        'dgvStoryBoard.CurrentRow.Cells(CInt(Request.Patch_Shape + i)).Style.BackColor = Color.Red
                        drow.Cells(CInt(Request.IMP_DESCRIPTION)).Style.ForeColor = Color.White

                        comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        comboboxCellrec.Style.BackColor = Color.Red
                        comboboxCellrec.Style.ForeColor = Color.White

                    Else
                        drow.Cells(CInt(Request.IMP_DESCRIPTION)).Style.ForeColor = Color.Maroon

                        comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        comboboxCellrec.Style.BackColor = Color.White

                    End If

                    'Validation certaine deco method - because they have Required Field
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.DEC_MET_DESC, drow.Index), DataGridViewComboBoxCell)

                    '--------------------------- check  Decorating Method is required field --------------------------------

                    If (String.IsNullOrEmpty(comboboxCellrec.Value) Or String.IsNullOrWhiteSpace(comboboxCellrec.Value)) And comboboxCellrec.Items.Count <> 0 And
                        String.IsNullOrEmpty(drow.Cells(CInt(Request.Parent_GUID)).ToString) Or String.IsNullOrWhiteSpace(drow.Cells(CInt(Request.Parent_GUID)).ToString) Then
                        varBool = False
                        'filter in enum
                        varResospons &= DirectCast([Enum].Parse(GetType(Request), (CInt(Request.IMP_DESCRIPTION))), Request).ToString & ", " 'comboboxCellrec.Value

                        'change backgound color for header column name
                        'If dgvStoryBoard.Columns(CInt(Request.DEC_MET_DESC)).HeaderCell.Style.BackColor <> Color.Red Then
                        '    dgvStoryBoard.Columns(CInt(Request.DEC_MET_DESC)).HeaderCell.Style.BackColor = Color.Red
                        'End If

                        'dgvStoryBoard.CurrentRow.Cells(CInt(Request.Patch_Shape + i)).Style.BackColor = Color.Red
                        drow.Cells(CInt(Request.DEC_MET_DESC)).Style.ForeColor = Color.White

                        comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        comboboxCellrec.Style.BackColor = Color.Red
                    Else
                        'If dgvStoryBoard.Columns(CInt(Request.DEC_MET_DESC)).HeaderCell.Style.BackColor <> Color.White Then
                        '    dgvStoryBoard.Columns(CInt(Request.DEC_MET_DESC)).HeaderCell.Style.BackColor = Color.White
                        'End If

                        drow.Cells(CInt(Request.DEC_MET_DESC)).Style.ForeColor = Color.Maroon
                        '  drow.Cells(CInt(Request.DEC_MET_DESC)).Style.BackColor = Color.White

                        comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                        comboboxCellrec.Style.BackColor = Color.White

                    End If

                    Select Case comboboxCellrec.Value
                        Case 88, 131, 133, 138
                            'for change header column style need put False for EnableHeadersVisualStyles
                            dgvStoryBoard.EnableHeadersVisualStyles = False

                            For i As Integer = 0 To 2
                                comboboxCellrec = New DataGridViewComboBoxCell
                                comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.Patch_Shape + i, drow.Index), DataGridViewComboBoxCell)
                                ' comboboxCellrec = DirectCast(drow.Cells(CInt(Request.Patch_Shape + i)), DataGridViewComboBoxCell)

                                If (String.IsNullOrEmpty(comboboxCellrec.Value) Or String.IsNullOrWhiteSpace(comboboxCellrec.Value)) Then
                                    varBool = False
                                    'filter in enum
                                    varResospons &= DirectCast([Enum].Parse(GetType(Request), (Request.Patch_Shape + i)), Request).ToString & ", " 'comboboxCellrec.Value

                                    'change backgound color for header column name
                                    'If dgvStoryBoard.Columns(CInt(Request.Patch_Shape + i)).HeaderCell.Style.BackColor <> Color.Red Then
                                    '    dgvStoryBoard.Columns(CInt(Request.Patch_Shape + i)).HeaderCell.Style.BackColor = Color.Red
                                    'End If

                                    'dgvStoryBoard.CurrentRow.Cells(CInt(Request.Patch_Shape + i)).Style.BackColor = Color.Red
                                    drow.Cells(CInt(Request.Patch_Shape + i)).Style.ForeColor = Color.White

                                    comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                                    comboboxCellrec.Style.BackColor = Color.Red

                                Else
                                    'change backgound color for header column name
                                    'change backgound color for header column name
                                    'If dgvStoryBoard.Columns(CInt(Request.Patch_Shape + i)).HeaderCell.Style.BackColor <> Color.White Then
                                    '    dgvStoryBoard.Columns(CInt(Request.Patch_Shape + i)).HeaderCell.Style.BackColor = Color.White
                                    'End If

                                    'dgvStoryBoard.CurrentRow.Cells(CInt(Request.Patch_Shape + i)).Style.BackColor = Color.White
                                    drow.Cells(CInt(Request.Patch_Shape + i)).Style.ForeColor = Color.Maroon

                                    comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                                    comboboxCellrec.Style.BackColor = Color.White
                                End If
                            Next

                            '-----------------------

                            If drow.Cells(CInt(Request.DEC_MET_DESC)).Value = 133 Then
                                For i As Integer = 0 To 1
                                    'If (String.IsNullOrEmpty(dgvStoryBoard.CurrentRow.Cells(Request.BackGround_Color + i).Value) Or
                                    '    String.IsNullOrWhiteSpace(dgvStoryBoard.CurrentRow.Cells(Request.BackGround_Color + i).Value)) Then

                                    If (String.IsNullOrEmpty(drow.Cells(Request.BackGround_Color + i).Value) Or
                                     String.IsNullOrWhiteSpace(drow.Cells(Request.BackGround_Color + i).Value)) Then
                                        varBool = False

                                        'filter in enum
                                        varResospons &= DirectCast([Enum].Parse(GetType(Request), (Request.BackGround_Color + i)), Request).ToString & ", " 'comboboxCellrec.Value

                                        'If dgvStoryBoard.Columns(CInt(Request.BackGround_Color + i)).HeaderCell.Style.BackColor <> Color.Red Then
                                        '    dgvStoryBoard.Columns(CInt(Request.BackGround_Color + i)).HeaderCell.Style.BackColor = Color.Red
                                        'End If

                                        drow.Cells(CInt(Request.BackGround_Color + i)).Style.BackColor = Color.Red
                                        drow.Cells(CInt(Request.BackGround_Color + i)).Style.ForeColor = Color.White
                                    Else
                                        'If dgvStoryBoard.Columns(CInt(Request.BackGround_Color + i)).HeaderCell.Style.BackColor <> Color.White Then
                                        '    dgvStoryBoard.Columns(CInt(Request.BackGround_Color + i)).HeaderCell.Style.BackColor = Color.White
                                        'End If

                                        drow.Cells(CInt(Request.BackGround_Color + i)).Style.BackColor = Color.White
                                        drow.Cells(CInt(Request.BackGround_Color + i)).Style.ForeColor = Color.Maroon

                                    End If
                                Next
                            End If
                        '-----------------------
                        Case 1 'Silk Screened

                            'If (String.IsNullOrEmpty(dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_COLOR).Value) Or
                            '      String.IsNullOrWhiteSpace(dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_COLOR).Value)) Then
                            If (String.IsNullOrEmpty(drow.Cells(Request.IMPRINT_COLOR).Value) Or
                                 String.IsNullOrWhiteSpace(drow.Cells(Request.IMPRINT_COLOR).Value)) Then
                                varBool = False
                                'If dgvStoryBoard.Columns(CInt(Request.IMPRINT_COLOR)).HeaderCell.Style.BackColor <> Color.Red Then
                                '    dgvStoryBoard.Columns(CInt(Request.IMPRINT_COLOR)).HeaderCell.Style.BackColor = Color.Red
                                'End If

                                'filter in enum
                                varResospons &= DirectCast([Enum].Parse(GetType(Request), (Request.IMPRINT_COLOR)), Request).ToString & ", " 'comboboxCellrec.Value

                                drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.BackColor = Color.Red
                                drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.ForeColor = Color.White
                            Else
                                'If dgvStoryBoard.Columns(CInt(Request.IMPRINT_COLOR)).HeaderCell.Style.BackColor <> Color.White Then
                                '    dgvStoryBoard.Columns(CInt(Request.IMPRINT_COLOR)).HeaderCell.Style.BackColor = Color.White
                                'End If

                                drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.BackColor = Color.White
                                drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.ForeColor = Color.Maroon
                            End If
                    End Select

                    If varResospons.Length > 0 Then
                        respons &= "Required Field for ITEM NO : " & Trim(drow.Cells(CInt(Request.item_no)).Value) & " - " & varResospons
                        respons &= vbCrLf
                    End If

                End If
                '''''''''''''''''''''''''''''''''''''20200323 justin add to validation field length begin

                '++ID 02.08.2022 added IsNullOrEmpty
                If String.IsNullOrEmpty(drow.Cells(Request.IMPRINT_LOGO).Value) = False Then
                    If drow.Cells(Request.IMPRINT_LOGO).Value.ToString <> "" And drow.Cells(Request.IMPRINT_LOGO).Value.length > 50 Then

                        varBool = False
                        varResospons = DirectCast([Enum].Parse(GetType(Request), (Request.IMPRINT_LOGO)), Request).ToString & ", Limit: 50"
                        drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.BackColor = Color.Red
                        drow.Cells(CInt(Request.IMPRINT_LOGO)).Style.ForeColor = Color.White
                        If varResospons.Length > 0 Then
                            respons &= "Length Field for ITEM NO : " & Trim(drow.Cells(CInt(Request.item_no)).Value) & " - " & varResospons
                            respons &= vbCrLf
                        End If
                    End If
                End If
                '++ID 02.08.2022 added IsNullOrEmpty
                If String.IsNullOrEmpty(drow.Cells(Request.IMPRINT_COLOR).Value) = False Then
                    If drow.Cells(Request.IMPRINT_COLOR).Value.ToString <> "" And drow.Cells(Request.IMPRINT_COLOR).Value.length > 50 Then
                        varBool = False
                        varResospons = DirectCast([Enum].Parse(GetType(Request), (Request.IMPRINT_COLOR)), Request).ToString & ", Limit: 50"
                        drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.BackColor = Color.Red
                        drow.Cells(CInt(Request.IMPRINT_COLOR)).Style.ForeColor = Color.White
                        If varResospons.Length > 0 Then
                            respons &= "Length Field for ITEM NO : " & Trim(drow.Cells(CInt(Request.item_no)).Value) & " - " & varResospons
                            respons &= vbCrLf
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''20200323 justin add to validation field length end

            Next



            Return varBool

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '----------------------------------------------------------------
    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
        Try

            Dim respons As String = ""
            'function added for validate certaine label in in storyboard grid 
            If ValidateDecoProperties(respons) <> True Then
                If respons.Length > 0 Then

                    Dim result1 As DialogResult = MessageBox.Show(respons,
            "Warning.",
            MessageBoxButtons.OK,
            MessageBoxIcon.Hand,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly,
            False)
                    Exit Sub
                End If
            End If
            '-------------------------
            oMdb_Item_master = New cMdb_Item_Master
            olstMaster = New List(Of cMdb_Item_Master)


            If RowCount_StoryBoard() >= Return_MaxRow_PerType() Then

                MsgBox("Maximum rows permited for " & pReqType & " Request is " & Return_MaxRow_PerType.ToString & ". " & vbCrLf &
                       "In your case you will have " & RowCount_StoryBoard().ToString & vbCrLf &
                       "Row was not added.")

                Exit Sub
            End If


            'add row to grid 
            dgvStoryBoard.Rows.Add()
            dgvStoryBoard.Refresh()
            Dim rowIndex As Integer = dgvStoryBoard.RowCount - 1

            'add x(delete) column 
            '    dgvStoryBoard.BeginEdit(True)

            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.x)).Value = "X"
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.x)).Style.Font = New Font("Arial", 14, FontStyle.Bold)
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.x)).Style.BackColor = Color.Red

            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.x)).Tag = "0"
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value = "0"
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.ReqItemId)).Value = "0"
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.GUID)).Value = ""
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.Parent_GUID)).Value = ""

            dgvStoryBoard.ClearSelection()
            dgvStoryBoard.Rows(dgvStoryBoard.RowCount - 1).Selected = True

            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_cd)).Selected = True
            dgvStoryBoard.ClearSelection()
            dgvStoryBoard.BeginEdit(False)

            Call GridLine_Color()

            'Storyboard max - 15 lines
            'Virtual    max - 10 lines


        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'count rows in grid without the SKU-Kit example BB105 have 3 components , need count only components of the kit 
    Private Function RowCount_StoryBoard() As Int32
        RowCount_StoryBoard = 0
        Try
            Dim cptRows As Integer = 0

            For Each dRows As DataGridViewRow In dgvStoryBoard.Rows
                If String.IsNullOrEmpty(dRows.Cells(Request.Parent_GUID).Value) Then
                    cptRows += 1
                End If
            Next

            Return cptRows
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'return  max row added by type
    Private Function Return_MaxRow_PerType() As Int32
        Return_MaxRow_PerType = 0
        Try
            Dim cptByTypeofDoc As Int32 = 0

            If CInt(lblStoryBoard.Tag) = 22 Then ' StoryBoard Request
                cptByTypeofDoc = 15
            ElseIf CInt(lblStoryBoard.Tag) = 23 Then ' Virtual Request
                cptByTypeofDoc = 10
            ElseIf CInt(lblStoryBoard.Tag) = 25 Then ' Virtual Request
                cptByTypeofDoc = 10
            End If

            Return cptByTypeofDoc
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub GridLine_Color()
        Try
            Dim CountR As Integer
            CountR = 0
            While CountR <= dgvStoryBoard.Rows.Count - 1

                If CountR Mod 2 = 0 Then
                    dgvStoryBoard.Rows(CountR).DefaultCellStyle.BackColor = Color.White
                Else
                    dgvStoryBoard.Rows(CountR).DefaultCellStyle.BackColor = Color.Azure

                End If
                CountR = CountR + 1
            End While

            'make rows to  height = 30
            For Each dg As DataGridViewRow In dgvStoryBoard.Rows
                dg.Height = 30
            Next

            lblRowsNo.Text = LabelRowCount & " " & dgvStoryBoard.RowCount
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmVirtual_Request_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.KeyCode = Keys.Escape Then
                If lstIStyle.Visible Then
                    lstIStyle.Items.Clear()
                    lstIStyle.Visible = False
                    'need put initialisation grid line
                    dgvStoryBoard.Item(Request.item_cd, dgvStoryBoard.CurrentRow.Index).Value = ""
                Else

                End If

                If panMiddleLstViewCustomerShow.Visible Then

                    Select Case lblMiddleLineNameDisplay.Tag
                        Case 1 ' Customer Contact 

                            txtContactSearch.Hide()
                            txtContactSearch.Text = String.Empty

                            lblMiddleLineNameDisplay.Tag = -1
                            lblMiddleLineNameDisplay.Text = ""

                            lnkLabelAdditionalLoc.Visible = False
                            lblItemShowAdditLoc.Visible = False
                            lnkDeletelocation.Visible = False

                        Case 3
                            ' -3- is listview additional location
                            If lblMiddleLineNameDisplay.Tag = 3 Then
                                'validate required label for additional location
                                Dim respons As String = ""
                                'function added for validate certaine label in in storyboard grid 
                                If Validate_RequiredLabel_AdditLocation(respons) <> True Then
                                    If respons.Length > 0 Then
                                        Dim result1 As DialogResult = MessageBox.Show(respons,
                    "Warning.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly,
                    False)
                                        Exit Sub
                                    End If
                                End If

                            End If

                        Case ListViewName.BindeImage
                            Dim s As String = ""

                            'For Each lstw As ListViewItem In lstViewCustomerMiddle.Items
                            '    s = lstw.SubItems(2).Text
                            'Next

                            '  dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.IMP_DESCRIPTION).Selected = False

                            For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                                dgv.Selected = False
                            Next

                            lstViewCustomerMiddle.Items.Clear()
                            panMiddleLstViewCustomerShow.Visible = False
                    End Select



                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""

                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False


                    panMiddleLstViewCustomerShow.Visible = False
                    lstViewCustomerMiddle.Items.Clear()

                End If

                If panItemComment.Visible = True Then

                    panItemComment.Visible = False
                    If dgvStoryBoard.RowCount <> 0 And String.IsNullOrEmpty(Trim(xTxtItemComment.Tag)) = False Then ' And String.IsNullOrEmpty(Trim(dgvStoryBoard.Rows(CInt(xTxtItemComment.Tag)).Cells(Request.ReqItemComm).Value)) = True Then
                        dgvStoryBoard.Rows(CInt(xTxtItemComment.Tag)).Cells(Request.ReqItemComm).Value = xTxtItemComment.Text
                    End If

                    ' xTxtItemComment.Text = String.Empty

                End If

            End If
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvStoryBoard_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStoryBoard.CellEnter
        Try
            '   Dim oCfgEnum As cCfgEnum
            '   Dim comboboxColumn As DataGridViewComboBoxCell

            'this if check editable function whithout Item Name cell(2)
            If e.ColumnIndex = CInt(Request.item_cd) Then
                dgvStoryBoard.BeginEdit(True)

            ElseIf Trim(dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_cd)).Value) <> "" Then
                'dgvStoryBoard.BeginEdit(True)

                dgvStoryBoard.CurrentRow.Cells(Request.item_cd).ReadOnly = False
                dgvStoryBoard.CurrentRow.Cells(Request.item_color).ReadOnly = False
                dgvStoryBoard.CurrentRow.Cells(Request.DEC_MET_DESC).ReadOnly = False
                dgvStoryBoard.CurrentRow.Cells(Request.IMP_DESCRIPTION).ReadOnly = False
                dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_COLOR).ReadOnly = False
                dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_LOGO).ReadOnly = False

            Else
                'initialise line if item code is empty and make line readonly
                For i As Int32 = 0 To dgvStoryBoard.ColumnCount - 1
                    If dgvStoryBoard.Rows(e.RowIndex).Cells(i).GetType.Name = "DataGridViewCheckBoxCell" Then

                        dgvStoryBoard.Rows(e.RowIndex).Cells(i).Value = False

                    ElseIf dgvStoryBoard.Rows(e.RowIndex).Cells(i).GetType.Name = "WorkaroundDataGridViewComboBoxCell" Then

                        Debug.Print(dgvStoryBoard.Rows(e.RowIndex).Cells(i).FormattedValue)

                        '---------------------
                        If i = CInt(Request.item_color) Then

                            oMdb_Item_VariantColor = New cMdb_Item_VariantColor
                            Call comboboxCell(dgvStoryBoard, i, CInt(e.RowIndex), "color_id", "Color_Cd",
                                  oMdb_Item_VariantColor.Load_VariantListColor(CInt(oMdb_Item_VariantColor.Item_Master_Id)))
                        ElseIf i = CInt(Request.DEC_MET_DESC) Then

                            oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                            Call comboboxCell(dgvStoryBoard, i, CInt(e.RowIndex), "DEC_MET_ID", "DEC_MET_DESC",
                                              oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(0)))

                        ElseIf i = CInt(Request.IMP_DESCRIPTION) Then
                            oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                            Call comboboxCell(dgvStoryBoard, i, CInt(e.RowIndex), "IMP_LOC_ID", "Imp_Loc_Desc",
                                              oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(0), CInt(0)))
                            'ElseIf i = CInt(Request.Patch_Shape) Then
                            '    oCfgEnum = New cCfgEnum
                            '    Call comboboxCell(dgvStoryBoard, i, CInt(e.RowIndex), "ID", "PATCH_SHAPE",
                            '                      oCfgEnum.LoadEnumCat(0))
                        End If
                        '---------------------

                    ElseIf dgvStoryBoard.Rows(e.RowIndex).Cells(i).GetType.Name = "DataGridViewTextBoxCell" Then
                        If i <> CInt(Request.x) And i <> CInt(Request.ReqItemId) Then
                            dgvStoryBoard.Rows(e.RowIndex).Cells(i).Value = ""
                        End If

                    End If
                Next

                dgvStoryBoard.CurrentCell.ReadOnly = True
            End If

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvStoryBoard_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStoryBoard.CellValueChanged
        Try
            'grid is load cell by cell fro maintaine designe 

            If dgvStoryBoard.RowCount = 1 And Trim(dgvStoryBoard.Rows(0).Cells(CInt(Request.item_cd)).Value) = "" Then Exit Sub

            oMdb_Item_master = New cMdb_Item_Master

            olstMaster = New List(Of cMdb_Item_Master)
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            If e.ColumnIndex = CInt(Request.item_color) Then 'item_color


            ElseIf e.ColumnIndex = CInt(Request.DEC_MET_DESC) Then

                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                'if is kit , don't need fill DataGridViewComboBoxCell 
                'because dec_met_desc are assigned to the components of the kit 
                If Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value) <> "K" And
                     Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Parent_GUID).Value) = "" Then '(not kit and has not guid from parent)
                    'fill imprint location

                    ''cast dec_met_desc
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell) ' 

                    olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(dgvStoryBoard.Item(Request.item_master_id, e.RowIndex).Value), CInt(comboboxCellrec.Value))

                    Call comboboxCell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), CInt(e.RowIndex),
                                  "IMP_LOC_ID", "Imp_Loc_Desc", olstImp_Loc_VIEW)

                    dgvStoryBoard.CurrentRow.Cells(Request.Patch_Shape).Selected = True

                    ' 88-BRAND PATCH, 131-4CP BRAND PATCH, 133-BRAND SHIELD
                    If (CInt(comboboxCellrec.Value) = 88 Or CInt(comboboxCellrec.Value) = 131 Or CInt(comboboxCellrec.Value) = 133 Or CInt(comboboxCellrec.Value) = 138) Then

                        'only for BRANDPATCH  id 88 will be created combobox    ' 88-BRAND PATCH, 131-4CP BRAND PATCH, 133-BRAND SHIELD
                        oCfgEnum = New cCfgEnum
                        olsCfgEnum = New List(Of cCfgEnum)
                        olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                        If olsCfgEnum.Count <> 0 Then
                            'convert in combobox if is brandpach
                            Call comboboxCell(dgvStoryBoard, CInt(Request.Patch_Shape), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Shape).ReadOnly = False
                        End If

                        '----------------------------------------------------------------------------------
                        '++ID 1.15.2018 added new request Patch Color
                        oCfgEnum = New cCfgEnum
                        olsCfgEnum = New List(Of cCfgEnum)

                        If (CInt(comboboxCellrec.Value) = 88 Or CInt(comboboxCellrec.Value) = 131 Or CInt(comboboxCellrec.Value) = 138) Then
                            olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08BP44")
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = ""
                        ElseIf CInt(comboboxCellrec.Value) = 133 Then
                            olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = "Tone On Tone"
                        End If

                        'olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                        If olsCfgEnum.Count <> 0 Then
                            Call comboboxCell(dgvStoryBoard, CInt(Request.Patch_Color), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Color).ReadOnly = False

                            Call comboboxCell(dgvStoryBoard, CInt(Request.Thread_Color), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Thread_Color).ReadOnly = False

                        End If

                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).ReadOnly = False
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).Value = ""
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).ReadOnly = False
                        '--------------------------------------------------------------------------------------------------
                    Else
                        'return textbox properties if is not BrandPach id = 88 
                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Shape), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Shape).ReadOnly = True

                        'return textbox properties if is not  id = 88 ,131,133
                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Color), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Color).ReadOnly = True

                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Thread_Color), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Thread_Color).ReadOnly = True

                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = "-"
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).ReadOnly = True
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).Value = "-"
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).ReadOnly = True

                    End If

                ElseIf Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value) <> "K" And
                         Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Parent_GUID).Value) <> "" Then '(not kit and has  guid from parent)

                    Debug.Print(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.item_cd).Value & " Is Kit" & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value)
                    'cast dec_met_desc
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell) ' 

                    Call comboboxCell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), CInt(e.RowIndex),
                                  "IMP_LOC_ID", "Imp_Loc_Desc",
                                  oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(CInt(dgvStoryBoard.Item(Request.Parent_GUID, e.RowIndex).Tag),
                                   CInt(dgvStoryBoard.Item(Request.item_master_id, e.RowIndex).Value),
                                                                             CInt(comboboxCellrec.Value)))

                    dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Shape).Selected = True

                    'only for BRANDPATCH  id 88 will be created combobox
                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)
                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                    If (CInt(comboboxCellrec.Value) = 88 Or CInt(comboboxCellrec.Value) = 131 Or CInt(comboboxCellrec.Value) = 133 Or CInt(comboboxCellrec.Value) = 138) Then

                        If olsCfgEnum.Count <> 0 Then
                            'convert in combobox if is brandpach
                            Call comboboxCell(dgvStoryBoard, CInt(Request.Patch_Shape), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Shape).ReadOnly = False
                        End If
                        '----------------------------------------------------------------------------------
                        '++ID 1.15.2018 added new request Patch Color
                        oCfgEnum = New cCfgEnum
                        olsCfgEnum = New List(Of cCfgEnum)

                        If (CInt(comboboxCellrec.Value) = 88 Or CInt(comboboxCellrec.Value) = 131 Or CInt(comboboxCellrec.Value) = 138) Then
                            olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08BP44")
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = ""
                        ElseIf CInt(comboboxCellrec.Value) = 133 Then
                            olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = "Tone On Tone"
                        End If

                        'olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                        If olsCfgEnum.Count <> 0 Then
                            Call comboboxCell(dgvStoryBoard, CInt(Request.Patch_Color), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Color).ReadOnly = False

                            Call comboboxCell(dgvStoryBoard, CInt(Request.Thread_Color), CInt(e.RowIndex), "Enum_ID", "ENUM_VALUE", olsCfgEnum)
                            dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Thread_Color).ReadOnly = False
                        End If


                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).ReadOnly = False
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).Value = ""
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).ReadOnly = False

                        '--------------------------------------------------------------------------------------------------
                    Else
                        'return textbox properties if is not BrandPach id = 88 
                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Shape), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Shape).ReadOnly = True

                        'return textbox properties if is not  id = 88 ,131,133
                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Color), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Patch_Color).ReadOnly = True

                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.Thread_Color), e.RowIndex, "-")
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Thread_Color).ReadOnly = True

                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).Value = "-"
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.BackGround_Color).ReadOnly = True
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).Value = "-"
                        dgvStoryBoard.Rows(e.RowIndex).Cells(Request.StampingPattern).ReadOnly = True
                    End If

                    dgvStoryBoard.Rows(e.RowIndex).Cells(CInt(Request.Area_Size)).Selected = True

                ElseIf Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value) = "K" Then

                    Debug.Print(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.item_cd).Value & " Is Kit" & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value)

                End If

            ElseIf e.ColumnIndex = CInt(Request.IMP_DESCRIPTION) Then

            ElseIf e.ColumnIndex = CInt(Request.Is_kit) Then

            End If

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvStoryBoard_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStoryBoard.CellClick
        Try
            Dim oReqItems_AdditLocation_Del As cReqItems_AdditLocation
            Dim olstReItems_AdditLocation_Del As List(Of cReqItems_AdditLocation)
            Dim strSQL As String = ""

            If e.ColumnIndex = -1 Then Exit Sub
            If e.RowIndex = -1 Then Exit Sub
            '----------------------------
            Dim l As List(Of Integer) = New List(Of Integer)
            '----------------------------
            'Dim cptFoResizing As Int32 = 0

            If e.ColumnIndex = CInt(Request.x) And dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Parent_GUID).Value = "" Then

                Dim result As DialogResult

                result = MessageBox.Show("You sure want delete " & " line index - " & e.RowIndex & " With Item Cd = " & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.item_cd).Value _
                                                 & ". If Is a kit all components will be deleted .", "Delete Alert !!! Make your choose.",
                                                 MessageBoxButtons.YesNoCancel)
                Select Case result
                    Case DialogResult.Cancel
                        Exit Sub
                    Case DialogResult.No

                        Exit Sub
                    Case DialogResult.Yes

                        Dim RepeatResult As DialogResult

                        RepeatResult = MessageBox.Show(" Item/Items will be deleted definitely. ", " Alert !!!", MessageBoxButtons.OKCancel)

                        Select Case RepeatResult
                            Case DialogResult.Cancel
                                Exit Select
                            Case DialogResult.OK

                                '----------------------- Execute Delete ------------------------
                                Select Case dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value
                                    Case "K"
                                        'add parent in stock list
                                        l.Add(e.RowIndex)

                                        If Not dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag Is Nothing Then
                                            'delete before from DB
                                            'delete kit parent 
                                            oReqItems = New cReqItems

                                            If oReqItems.Delete(CInt(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag)) <> True Then
                                                MsgBox("Not deleted : " & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.item_cd).Tag & ",ReqItemId:" & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag)
                                            End If
                                        End If

                                        For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                                            'remove child rows  
                                            If dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value = dgv.Cells(Request.Parent_GUID).Value Then

                                                Try

                                                    '-------------- Kit Start Delete Additional Location in DB --------------
                                                    'Before remove from ReqItems_AdditLocation if exist
                                                    oReqItems_AdditLocation_Del = New cReqItems_AdditLocation
                                                    olstReItems_AdditLocation_Del = New List(Of cReqItems_AdditLocation)

                                                    'take current item Guid and check in ReqItems_AdditLocation if exist records
                                                    strSQL = "Select * from  ReqItems_AdditLocation WITH (Nolock) where ReqItemGuid = '" & Trim(dgvStoryBoard.Rows(dgv.Index).Cells(Request.GUID).Value.ToString) & "'"

                                                    olstReItems_AdditLocation_Del = oReqItems_AdditLocation_Del.LoadLst(strSQL)

                                                    'all records need to be deleted if it found. Form DB
                                                    If Not olstReItems_AdditLocation_Del Is Nothing Then
                                                        For Each item As cReqItems_AdditLocation In olstReItems_AdditLocation_Del
                                                            oReqItems_AdditLocation_Del.Delete(item)
                                                        Next
                                                    End If

                                                    'now delete from global olstReItems_AdditDetail - list(of cReqItems_AdditLocation)  filled in the load event form 
                                                    If Not olstReItems_AdditDetail Is Nothing Then

                                                        olstReItems_AdditDetail.RemoveAll(Function(i As cReqItems_AdditLocation) i.ReqItemGuid = Trim(dgvStoryBoard.Rows(dgv.Index).Cells(Request.GUID).Value.ToString))

                                                    End If
                                                    '---------------------- Kit Start Delete Additional Location in DB --------------------------------
                                                Catch ex As Exception
                                                    MsgBox("Error in " & Me.Name & ". Case 'K' delete from ReqItems_AdditLocation" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                                End Try
                                                '---------------------search and delete all line from ReqDocumBindItem if are found -----------------------------
                                                Try
                                                    Dim m_BindId As Int32 = 0
                                                    If Not olstReqDocBindItem Is Nothing Then

                                                        If olstReqDocBindItem.Count <> 0 Then

                                                            For Each docBind As cReqDocBindItem In olstReqDocBindItem
                                                                If docBind.ItemGuid = Trim(dgvStoryBoard.Rows(dgv.Index).Cells(Request.GUID).Value.ToString) And docBind.BindId <> 0 Then
                                                                    oReqDocBindItem = New cReqDocBindItem
                                                                    oReqDocBindItem.BindId = docBind.BindId

                                                                    oReqDocBindItem.Delete(oReqDocBindItem)
                                                                End If
                                                            Next

                                                            olstReqDocBindItem.RemoveAll(Function(i As cReqDocBindItem) i.ItemGuid = Trim(dgvStoryBoard.Rows(dgv.Index).Cells(Request.GUID).Value.ToString))

                                                        End If
                                                    End If

                                                Catch ex As Exception
                                                    MsgBox("Error in " & Me.Name & ". Case 'K' delete from ReqItems_AdditLocation" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                                End Try
                                                '--------------------- delete function from ReqDocumBindItem -------------------------
                                                'before delete items from DB
                                                'check if is nothing
                                                'because when line is added and is not saved and user want remove 
                                                'we don't need check in db, ReqItemId is hidden in Request.X -Tag
                                                If Not dgvStoryBoard.Rows(dgv.Index).Cells(Request.x).Tag Is Nothing Then
                                                    'delete from DB all components from kit and kit,too
                                                    oReqItems = New cReqItems

                                                    If oReqItems.Delete(CInt(dgvStoryBoard.Rows(dgv.Index).Cells(Request.x).Tag)) <> True Then
                                                        MsgBox("Not deleted : " & dgvStoryBoard.Rows(dgv.Index).Cells(Request.item_cd).Tag & ",ReqItemId:" & dgvStoryBoard.Rows(dgv.Index).Cells(Request.x).Tag)
                                                    End If
                                                End If
                                                'stock index of rows and after delete 
                                                l.Add(dgv.Index)
                                            End If
                                        Next
                                        'sort descendent, for delete from last to first
                                        l.Reverse()
                                        For Each i As Integer In l
                                            dgvStoryBoard.Rows.RemoveAt(i)
                                        Next

                                        'remove parent of the rows
                                    Case Else

                                        'before delete from DB in the tag is ReqItemId
                                        'if tag is empty we don't need touch the DB
                                        'Only clean in List if is case
                                        If Not dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag Is Nothing Then
                                            Try
                                                '-------------- Start Delete Additional Location in DB --------------
                                                'Before remove from ReqItems_AdditLocation if exist
                                                oReqItems_AdditLocation_Del = New cReqItems_AdditLocation
                                                olstReItems_AdditLocation_Del = New List(Of cReqItems_AdditLocation)

                                                'take current item Guid and check in ReqItems_AdditLocation if exist records
                                                strSQL = "Select * from  ReqItems_AdditLocation WITH (Nolock) where ReqItemGuid = '" & Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value.ToString) & "'"

                                                olstReItems_AdditLocation_Del = oReqItems_AdditLocation_Del.LoadLst(strSQL)

                                                'all records need to be deleted if it found
                                                If Not olstReItems_AdditLocation_Del Is Nothing Then
                                                    For Each item As cReqItems_AdditLocation In olstReItems_AdditLocation_Del
                                                        oReqItems_AdditLocation_Del.Delete(item)
                                                    Next
                                                End If

                                                'now delete from global olstReItems_AdditDetail - list(of cReqItems_AdditLocation)  filled in the load event form 
                                                If Not olstReItems_AdditDetail Is Nothing Then
                                                    If olstReItems_AdditDetail.Count <> 0 Then
                                                        olstReItems_AdditDetail.RemoveAll(Function(i As cReqItems_AdditLocation) i.ReqItemGuid = Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value.ToString))
                                                    End If
                                                End If

                                            Catch ex As Exception
                                                MsgBox("Error in " & Me.Name & ". Case Else delete from ReqItems_AdditLocation" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                            End Try
                                            '---------------------- end Delete Additional Location in DB --------------------------------
                                            '---------------------search and delete all line from ReqDocumBindItem if are found -----------------------------
                                            Try
                                                Dim m_BindId As Int32 = 0
                                                Dim _Query As String = ""
                                                If Not olstReqDocBindItem Is Nothing Then

                                                    If olstReqDocBindItem.Count <> 0 Then

                                                        For Each docBind As cReqDocBindItem In olstReqDocBindItem
                                                            If docBind.ItemGuid = Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value.ToString) And docBind.BindId <> 0 Then
                                                                oReqDocBindItem = New cReqDocBindItem
                                                                oReqDocBindItem.BindId = docBind.BindId

                                                                oReqDocBindItem.Delete(oReqDocBindItem)
                                                            End If
                                                        Next
                                                    End If

                                                    olstReqDocBindItem.RemoveAll(Function(i As cReqDocBindItem) i.ItemGuid = Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value.ToString))

                                                End If

                                            Catch ex As Exception
                                                MsgBox("Error in " & Me.Name & ". Case Else delete from ReqItems_AdditLocation" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                            End Try
                                            '--------------------- delete function from ReqDocumBindItem -------------------------



                                            If oReqItems.Delete(CInt(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag)) <> True Then
                                                MsgBox("Not deleted : " & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.item_cd).Tag & ",ReqItemId:" & dgvStoryBoard.Rows(e.RowIndex).Cells(Request.x).Tag)
                                            End If
                                        End If

                                        'now delete in the global olstReItems_AdditDetail - list(of cReqItems_AdditLocation)  filled in the load event form, if is the case

                                        If Not olstReItems_AdditDetail Is Nothing Then

                                            olstReItems_AdditDetail.RemoveAll(Function(i As cReqItems_AdditLocation) i.ReqItemGuid = Trim(dgvStoryBoard.Rows(e.RowIndex).Cells(Request.GUID).Value))

                                        End If

                                        'initialise
                                        oReqItems = New cReqItems

                                        'for single line, have not the child
                                        dgvStoryBoard.Rows.RemoveAt(e.RowIndex)
                                End Select 'RepeatResult
                        End Select 'result
                        '---------------------------------------------------------------

                End Select



                ''delete  function 
                'MsgBox("you want delete item cd : " & dgvStoryBoard.Rows(e.RowIndex).Cells(CInt(Request.item_cd)).Value & " from the list. " _
                '      & " . First Column Value : " & dgvStoryBoard.Rows(e.RowIndex).Cells(CInt(Request.x)).Value)


                '----------
                'oReqItems = New cReqItems
                'olstReqItems = New List(Of cReqItems)

                'olstReqItems = oReqItems.LoadLst(RequestID, ReviewId)

                ''SEARCH IN EXISTING DB ALL LINES WITH SAME REQUESTID AND REVIEWID
                ''COMMPARE WITH NEW EDITED MAYBE LIST AND REMOVE ALL ITEMS WHICH ARE NOT FINDED IN  olstReqItemsCheck
                'For Each items As cReqItems In olstReqItems

                '    If olstReqItems.Find(Function(i As cReqItems) i.ReqItemId = items.ReqItemId) Is Nothing Then
                '        If oReqItems.Delete(CInt(items.ReqItemId)) <> True Then
                '            MsgBox("Not deleted : " & items.ItemCd & ",ReqitemId:" & items.ReqItemId)
                '        End If
                '    End If

                'Next

                '  ------------------
            ElseIf e.ColumnIndex = CInt(Request.item_color) And dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType.Name = "DataGridViewTextBoxCell" Then
                dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            ElseIf e.ColumnIndex = CInt(Request.DEC_MET_DESC) And dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType.Name = "DataGridViewTextBoxCell" Then
                dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            ElseIf e.ColumnIndex = CInt(Request.IMP_DESCRIPTION) And dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType.Name = "DataGridViewTextBoxCell" Then
                dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
            End If

            'show label rows numbers
            lblRowsNo.Text = "Rows: " & dgvStoryBoard.Rows.Count

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstIStyle_KeyDown(sender As Object, e As KeyEventArgs) Handles lstIStyle.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                'MsgBox("Enter Key was pressed.", , "Enter Key")
                Try

                    Call Fill_GridLine_LstBox(lststyleCurrentRow)

                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstIStyle_DoubleClick(sender As Object, e As MouseEventArgs) Handles lstIStyle.DoubleClick
        Try

            Call Fill_GridLine_LstBox(lststyleCurrentRow)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '--move lstbox
    Private Sub lstIStyle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstIStyle.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub
    Private Sub lstIStyle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstIStyle.MouseMove
        If allowCoolMove = True Then
            lstIStyle.Location = New Point(lstIStyle.Location.X + e.X - myCoolPoint.X, lstIStyle.Location.Y + e.Y - myCoolPoint.Y)
            'this line move panel 
            '   panMiddleLstViewCustomerShow.Location = New Point(panMiddleLstViewCustomerShow.Location.X + e.X - myCoolPoint.X, panMiddleLstViewCustomerShow.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub lstIStyle_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstIStyle.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub
    '---------------

    Private Sub dgvStoryBoard_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvStoryBoard.EditingControlShowing
        Try

            If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.item_color) Or
                dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.DEC_MET_DESC) Or
                dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.IMP_DESCRIPTION) Then
                'added this exception for indentify if cell is textboxCell
                'because for the components of the kit color combobox is cinverted in textbox cell
                'and we don't need activate function comboboxcell
                If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.item_color) _
                    And dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_color)).EditType.Name = "DataGridViewTextBoxEditingControl" Then
                    Exit Sub
                ElseIf dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.DEC_MET_DESC) _
                And dgvStoryBoard.CurrentRow.Cells(CInt(Request.DEC_MET_DESC)).EditType.Name = "DataGridViewTextBoxEditingControl" Then
                    Exit Sub
                ElseIf dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.IMP_DESCRIPTION) _
                    And dgvStoryBoard.CurrentRow.Cells(CInt(Request.IMP_DESCRIPTION)).EditType.Name = "DataGridViewTextBoxEditingControl" Then
                    Exit Sub

                End If

                Dim combo As ComboBox = CType(e.Control, ComboBox)

                If (combo IsNot Nothing) Then
                    ' Remove an existing event-handler, if present, to avoid 
                    ' adding multiple handlers when the editing control is reused.

                    '  combo.ItemHeight = 50
                    '  combo.Height = 50
                    RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)

                    'Add the event handler.
                    AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)

                    'cboDropDown_SelectedIndexChanged
                    RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf cboDropDown_SelectedIndexChanged)

                    AddHandler combo.SelectedIndexChanged, New EventHandler(AddressOf cboDropDown_SelectedIndexChanged)


                End If

            End If

            '''justin add 20200324
            If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.IMPRINT_LOGO) Then
                Dim txt_IMPRINT_LOGO As TextBox = CType(e.Control, TextBox)
                If (txt_IMPRINT_LOGO IsNot Nothing) Then
                    RemoveHandler txt_IMPRINT_LOGO.TextChanged, New EventHandler(AddressOf txt_IMPRINT_LOGO_TextChanged)
                    AddHandler txt_IMPRINT_LOGO.TextChanged, New EventHandler(AddressOf txt_IMPRINT_LOGO_TextChanged)
                End If
            End If
            If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.IMPRINT_COLOR) Then
                Dim txt_IMPRINT_LOGO As TextBox = CType(e.Control, TextBox)
                If (txt_IMPRINT_LOGO IsNot Nothing) Then
                    RemoveHandler txt_IMPRINT_LOGO.TextChanged, New EventHandler(AddressOf txt_IMPRINT_LOGO_TextChanged)
                    AddHandler txt_IMPRINT_LOGO.TextChanged, New EventHandler(AddressOf txt_IMPRINT_LOGO_TextChanged)
                End If
            End If
            '''
            If TypeOf e.Control Is ComboBox Then
                Dim cbo As ComboBox = DirectCast(e.Control, ComboBox)
                '    cbo.Height = 30
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'justin add 20200324
    Private Sub txt_IMPRINT_LOGO_TextChanged(sender As Object, e As EventArgs)
        Dim l_txt_IMPRINT_LOGO_Text As TextBox = CType(sender, TextBox)
        If l_txt_IMPRINT_LOGO_Text.Text.Length > 50 Then
            MsgBox("Please note that IMPRINT_LOGO's content cannot exceed 50 characters(Current:" + CStr(l_txt_IMPRINT_LOGO_Text.Text.Length) + "), please Check.")
        End If
    End Sub
    'justin add 20200324
    Private Sub txt_IMPRINT_COLOR_TextChanged(sender As Object, e As EventArgs)
        Dim l_txt_IMPRINT_COLOR_Text As TextBox = CType(sender, TextBox)
        If l_txt_IMPRINT_COLOR_Text.Text.Length > 50 Then
            MsgBox("Please note that IMPRINT_COLOR's content cannot exceed 50 characters(Current:" + CStr(l_txt_IMPRINT_COLOR_Text.Text.Length) + "), please Check.")
        End If
    End Sub

    Private Sub dgvStoryBoard_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvStoryBoard.DataError
        If (e.Context _
                    = (DataGridViewDataErrorContexts.Formatting Or DataGridViewDataErrorContexts.PreferredSize)) Then
            e.ThrowException = False
        End If
    End Sub
    '----------------populate grid line from listbox certaine cells-------------------
    Private Sub Fill_GridLine_LstBox(ByVal rowIndex As Int32)
        Try
            Dim lstSelectedItem As New cMdb_Item_Master

            oMdb_Item_master = New cMdb_Item_Master

            olstMaster = New List(Of cMdb_Item_Master)
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            Dim g As Guid
            g = Guid.NewGuid()
            Dim l As List(Of Integer) = New List(Of Integer)

            'need check if is not kit because when user change item we need initialise at 0 (Zero)
            'for the kit need delete the line

            ' If lstIStyle.Visible = False Then Exit Sub

            If dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value <> "" Then
                'initialise line in the grig--
                '    dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_cd)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value = 0

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.prod_category)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_no)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.Maco_desc1)).Value = ""

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.BackGround_Color)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.StampingPattern)).Value = ""

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.IMPRINT_COLOR)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.IMPRINT_LOGO)).Value = ""

                Select Case dgvStoryBoard.Rows(rowIndex).Cells(Request.Is_kit).Value
                    Case "K"
                        'add parent in stock list
                        '  l.Add(e.RowIndex)
                        For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                            'remove child rows  
                            If dgvStoryBoard.Rows(rowIndex).Cells(Request.GUID).Value = dgv.Cells(Request.Parent_GUID).Value Then
                                'stock index of rows
                                l.Add(dgv.Index)
                            End If
                        Next
                        Dim cptFoResizing As Int32 = 0
                        'sort descendent, for delete from last to first
                        l.Reverse()
                        For Each i As Integer In l
                            dgvStoryBoard.Rows.RemoveAt(i)
                        Next

                        'remove parent of the rows

                    Case Else

                End Select

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.Is_kit)).Value = ""

                oMdb_Item_VariantColor = New cMdb_Item_VariantColor

                Call comboboxCell(dgvStoryBoard, CInt(Request.item_color), rowIndex, "color_id", "Color_Cd",
                              oMdb_Item_VariantColor.Load_VariantListColor(CInt(oMdb_Item_VariantColor.Item_Master_Id)))

                comboboxCellrec = New DataGridViewComboBoxCell
                comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.item_color, rowIndex), DataGridViewComboBoxCell) ' 
                comboboxCellrec.Value = 0

                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW

                'need check which is the type name of cell

                Call comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), rowIndex, "DEC_MET_ID", "DEC_MET_DESC",
                                           oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VariantColor.Item_Master_Id)))
                comboboxCellrec = New DataGridViewComboBoxCell
                comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.DEC_MET_DESC, rowIndex), DataGridViewComboBoxCell) ' 
                comboboxCellrec.Value = 0

                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                Call comboboxCell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), rowIndex, "IMP_LOC_ID", "Imp_Loc_Desc",
                                          oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VariantColor.Item_Master_Id), CInt(0)))

                comboboxCellrec = New DataGridViewComboBoxCell
                comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.IMP_DESCRIPTION, rowIndex), DataGridViewComboBoxCell) ' 
                comboboxCellrec.Value = 0

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.Area_Size)).Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.DEFAULT_LOC)).Value = 0

                'return textboxcell or initialise maybe it was combobox
                textboxCellrec = New DataGridViewTextBoxCell
                textboxCellrec = DirectCast(dgvStoryBoard.Item(Request.Patch_Shape, rowIndex), DataGridViewTextBoxCell)
                textboxCellrec.Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(Request.Patch_Shape).ReadOnly = True

                'return textboxcell or initialise maybe it was combobox
                textboxCellrec = New DataGridViewTextBoxCell
                textboxCellrec = DirectCast(dgvStoryBoard.Item(Request.Patch_Color, rowIndex), DataGridViewTextBoxCell)
                textboxCellrec.Value = ""
                dgvStoryBoard.Rows(rowIndex).Cells(Request.Patch_Color).ReadOnly = True

                dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.GUID)).Value = ""

            End If

            If Trim(dgvStoryBoard.Rows(rowIndex).Cells(Request.item_cd).Value) <> String.Empty Then
                olstMaster = oMdb_Item_master.LoadMasterCd_List(Trim(dgvStoryBoard.Rows(rowIndex).Cells(Request.item_cd).Value))
            End If
            'if is only one items

            If olstMaster.Count = 1 Then
                lstSelectedItem = olstMaster.Find(Function(i As cMdb_Item_Master) i.Item_Master_Id <> 0)
            Else
                lstSelectedItem = lstIStyle.SelectedItem
            End If

            If lstSelectedItem.Is_Kit = "K" Then

                oMdb_Item_master = New cMdb_Item_Master
                olstMaster = New List(Of cMdb_Item_Master)
                olstMaster = oMdb_Item_master.LoadKitInfo_List(lstSelectedItem.Item_Master_Id)

                'Max 15 Rows Storybord
                'Max 10 Rows Virtual
                '   If (RowCount_StoryBoard() + (olstMaster.Count + 1)) >= Return_MaxRow_PerType() Then
                If RowCount_StoryBoard() >= Return_MaxRow_PerType() Then

                    MsgBox("Maximum rows permited for " & pReqType & " Request Is " & Return_MaxRow_PerType.ToString & " . " & vbCrLf &
                           "In your case you will have " & (RowCount_StoryBoard() + (olstMaster.Count + 1)) & vbCrLf &
                           "Components of the Kit are Not added .")

                    dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_cd)).Value = String.Empty

                    Exit Sub
                End If

            End If

            'fill item_cd,item_master_id from lstStyle
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_cd)).Value = lstSelectedItem.Item_Cd.ToString  'lstIStyle.ValueMember
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value = lstSelectedItem.Item_Master_Id.ToString  'lstIStyle.DisplayMember
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.prod_category)).Value = lstSelectedItem.PRODUCT_CATEGORY.ToString  'lstIStyle.DisplayMember
            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.Is_kit)).Value = lstSelectedItem.Is_Kit.ToString  'lstIStyle.DisplayMember

            'don't need show this info, always is hidden but is filled in the class object
            '   dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.USER_LOGIN)).Value = Environment.UserName
            'information abou date will be entered in the function save or update

            '--------------------- fill color id combobox from same row -----------------

            oMdb_Item_VariantColor = New cMdb_Item_VariantColor
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            olstVariantColor = oMdb_Item_VariantColor.Load_VariantListColor(CInt(dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value))
            '++11.14.2017
            'If oMdb_Item_VariantColor.Load_VariantListColor(CInt(dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value)).Count <> 0 Then
            If olstVariantColor.Count <> 0 Then
                Call comboboxCell(dgvStoryBoard, CInt(Request.item_color), CInt(rowIndex), "color_id", "Color_Cd", olstVariantColor) 'oMdb_Item_VariantColor.Load_VariantListColor(CInt(dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.item_master_id)).Value)))
            End If

            'add delete cell
            dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Value = "X"
            dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.Font = New Font("Arial", 14, FontStyle.Bold)
            dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.BackColor = Color.Red

            dgvStoryBoard.Rows(rowIndex).Cells(CInt(Request.GUID)).Value = Trim(g.ToString)

            lstIStyle.Visible = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '----------------------------- Create New Object -------------------------------------- 
    Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim oMdb_Item_Imp_Loc_VIEW_Copy As cMdb_Item_Imp_Loc_VIEW
            Dim olstImp_Loc_VIEW_Copy As List(Of cMdb_Item_Imp_Loc_VIEW)

            Dim combo As ComboBox = CType(sender, ComboBox)
            Dim g As Guid

            oMdb_Item_VariantColor = New cMdb_Item_VariantColor
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            Dim osltMdb_Item_Im_Loc_View As List(Of cMdb_Item_Imp_Loc_VIEW)

            oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
            'variable for resizing grid with other s objects
            Dim cptFoResizing As Int32 = 0

            'Console.WriteLine("Row  {0}, Value: {1}", dgvStoryBoard.CurrentCell.RowIndex, combo.SelectedItem)

            If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.item_color) Then

                oMdb_Item_VColor = New cMdb_Item_VariantColor
                oMdb_Item_VColor = combo.SelectedItem

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_no)).Value = oMdb_Item_VColor.Item_No
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Maco_desc1)).Value = oMdb_Item_VColor.Maco_Desc1

                'fill combobox in the grid de_met_desc

                '---------------------------------------------------------------------
                'in the case if is kit need load components for this KIT

                Dim varConst As Integer = 0
                '0 = add row
                '1 = insert row

                If dgvStoryBoard.CurrentRow.Cells(Request.Is_kit).Value <> "K" Then

                    osltMdb_Item_Im_Loc_View = New List(Of cMdb_Item_Imp_Loc_VIEW)
                    'distinct sort  olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                    '  osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id))

                    osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMetListCBO(CInt(oMdb_Item_VColor.Item_Master_Id))

                    If osltMdb_Item_Im_Loc_View.Count <> 0 Then

                        Call comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), CInt(dgvStoryBoard.CurrentRow.Index),
                                      "DEC_MET_ID", "DEC_MET_DESC", osltMdb_Item_Im_Loc_View)

                        oMdb_Item_Imp_Loc_VIEW_Copy = New cMdb_Item_Imp_Loc_VIEW
                        olstImp_Loc_VIEW_Copy = New List(Of cMdb_Item_Imp_Loc_VIEW)

                        olstImp_Loc_VIEW_Copy = oMdb_Item_Imp_Loc_VIEW_Copy.LoadDecMet_List(CInt(dgvStoryBoard.Item(Request.item_master_id, CInt(dgvStoryBoard.CurrentRow.Index)).Value))

                        If Not olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1) Is Nothing Then

                            Dim idDecMet As Int32 = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Dec_Met_Id

                            comboboxCellrec = New DataGridViewComboBoxCell
                            comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.DEC_MET_DESC, CInt(dgvStoryBoard.CurrentRow.Index)), DataGridViewComboBoxCell) ' 
                            comboboxCellrec.Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Dec_Met_Id

                            Dim idImpLoc As Int32 = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Imp_Loc_Id

                            comboboxCellrec = New DataGridViewComboBoxCell
                            comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.IMP_DESCRIPTION, CInt(dgvStoryBoard.CurrentRow.Index)), DataGridViewComboBoxCell) ' 
                            comboboxCellrec.Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Imp_Loc_Id


                            dgvStoryBoard.CurrentRow.Cells(CInt(Request.Area_Size)).Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).AREA_SIZE
                            dgvStoryBoard.CurrentRow.Cells(CInt(Request.DEFAULT_LOC)).Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Default_Loc

                        End If

                        '   "DEC_MET_ID", "DEC_MET_DESC", oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id)))
                    End If

                ElseIf dgvStoryBoard.CurrentRow.Cells(Request.Is_kit).Value = "K" Then

                    oMdb_Item_master = New cMdb_Item_Master
                    olstMaster = New List(Of cMdb_Item_Master)

                    Dim cpt As Int32 = olstMaster.Count
                    Dim rowindex As Int32 = dgvStoryBoard.CurrentRow.Index
                    'need have row count because each time when it will be added line grid will be increase
                    cptFoResizing = dgvStoryBoard.RowCount

                    tetxBoxcell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), rowindex, "")
                    tetxBoxcell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), rowindex, "")
                    tetxBoxcell(dgvStoryBoard, CInt(Request.IMPRINT_COLOR), rowindex, "")
                    tetxBoxcell(dgvStoryBoard, CInt(Request.IMPRINT_LOGO), rowindex, "")

                    dgvStoryBoard.CurrentRow.Cells(CInt(Request.ReqItemId)).Value = 0

                    Dim l As List(Of Integer) = New List(Of Integer)

                    'if only one rows is nothing look
                    If dgvStoryBoard.RowCount > 1 Then

                        For Each dgvRow As DataGridViewRow In dgvStoryBoard.Rows

                            If dgvRow.Cells(CInt(Request.Parent_GUID)).Value = dgvStoryBoard.CurrentRow.Cells(CInt(Request.GUID)).Value And
                           dgvRow.Cells(CInt(Request.Parent_GUID)).Tag = dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_master_id)).Value Then
                                'put in list array for make reverse sort and remove from grid with desc index
                                l.Add(dgvRow.Index)
                            End If
                        Next

                        l.Reverse()
                        For Each i As Integer In l
                            dgvStoryBoard.Rows.RemoveAt(i)
                        Next
                    End If

                    If l.Count <> 0 Then
                        If l.Item(l.Count - 1) < dgvStoryBoard.Rows.Count Then
                            l.Sort()
                            For Each i As Integer In l
                                dgvStoryBoard.Rows.Insert(i)
                            Next

                            varConst = 1 'insert row
                        End If
                    End If
                    olstMaster = oMdb_Item_master.LoadKitInfo_List(CInt(dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_master_id)).Value))
                    'start adding because is only one line and we can add


                    For Each itemM As cMdb_Item_Master In olstMaster
                        'need check how we can do if user select another color 
                        'need remove already added line and added newest
                        'need create new peopwrties for datagridview like tag in textbox and put parent item master and 
                        'when user want add or change color program will remove alreade added and add newesr
                        ' identify what operation need do only add row or insert between other rows
                        rowindex += 1
                        cptFoResizing += 1
                        Select Case varConst
                            Case 0 'add row
                                'if user added 3 line one of the line is kit and item color is not added ex. first line from 3
                                'now if user want add color varConstant return 0 but we need insert row between 1 -> 2
                                If dgvStoryBoard.CurrentRow.Index = dgvStoryBoard.RowCount Then
                                    dgvStoryBoard.Rows.Add()
                                Else
                                    dgvStoryBoard.Rows.Insert(rowindex)
                                End If

                            Case 1 'row was been iserted

                        End Select

                        dgvStoryBoard.BeginEdit(True)

                        dgvStoryBoard.Rows(rowindex).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Regular)
                        dgvStoryBoard.Rows(rowindex).Height = 30
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.x)).Style.Font = New Font("Arial", 10, FontStyle.Regular)
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.x)).Style.BackColor = Color.Gold

                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.x)).Value = "|--" & Trim(dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_cd)).Value)
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_master_id)).Value = itemM.Item_Master_Id

                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_cd)).Value = Trim(itemM.Item_Cd)
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_cd)).ReadOnly = True


                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.prod_category)).Value = Trim(itemM.PRODUCT_CATEGORY)
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Is_kit)).Value = Trim(itemM.Is_Kit)
                        g = Guid.NewGuid()
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.GUID)).Value = g.ToString

                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Parent_GUID)).Value = dgvStoryBoard.CurrentRow.Cells(CInt(Request.GUID)).Value.ToString
                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Parent_GUID)).Tag = dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_master_id)).Value

                        dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.ReqItemId)).Value = 0

                        oMdb_Item_VColor = New cMdb_Item_VariantColor

                        oMdb_Item_VColor = combo.SelectedItem

                        oMdb_Item_VariantColor = New cMdb_Item_VariantColor
                        olstVariantColor = New List(Of cMdb_Item_VariantColor)

                        Dim olstVariantColorCopy = New List(Of cMdb_Item_VariantColor)

                        Dim m_clorid As String = ""
                        Dim m_colorCd As String = ""
                        Dim m_item_no As String = ""
                        Dim m_maco_desc1 As String = ""
                        Dim m_mix_and_match As Boolean = False

                        '++ID 02.08.2022 variable identify mix and match
                        m_mix_and_match = MixAndMatch(CInt(oMdb_Item_VColor.Item_Master_Id)) 'function boolean if is true kit is mix and match

                        olstVariantColor = oMdb_Item_VariantColor.Load_KitCompVariantListColor(CInt(oMdb_Item_VColor.Item_Master_Id),
                                                                                                  CInt(oMdb_Item_VColor.Item_Variant_Id),
                                                                                                  itemM.Item_Master_Id)

                        olstVariantColorCopy = New List(Of cMdb_Item_VariantColor)(olstVariantColor)

                        '++ID 02.08.2022  mix and match
                        If m_mix_and_match = True Then

                            Call comboboxCell(dgvStoryBoard, CInt(Request.item_color), Int(rowindex), "color_id", "Color_Cd", olstVariantColorCopy)

                            comboboxCellrec = New DataGridViewComboBoxCell
                            comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.item_color, Int(rowindex)), DataGridViewComboBoxCell) ' 
                            comboboxCellrec.Value = olstVariantColor.Item(0).Color_Id
                        End If



                        If olstVariantColorCopy.Count <> 0 And m_mix_and_match = False Then
                            m_clorid = olstVariantColorCopy.Item(0).Color_Id
                            m_colorCd = olstVariantColorCopy.Item(0).Color_Cd
                            m_item_no = olstVariantColorCopy.Item(0).Item_No
                            m_maco_desc1 = olstVariantColorCopy.Item(0).Maco_Desc1
                            tetxBoxcell(dgvStoryBoard, CInt(Request.item_color), rowindex, m_colorCd, m_clorid)
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_no)).Value = m_item_no
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Maco_desc1)).Value = m_maco_desc1
                            '++ID 02.08.2022 mix and match 
                        ElseIf olstVariantColorCopy.Count <> 0 And m_mix_and_match = True Then
                            m_clorid = olstVariantColorCopy.Item(0).Color_Id
                            m_colorCd = olstVariantColorCopy.Item(0).Color_Cd
                            m_item_no = olstVariantColorCopy.Item(0).Item_No
                            m_maco_desc1 = olstVariantColorCopy.Item(0).Maco_Desc1
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_no)).Value = m_item_no
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Maco_desc1)).Value = m_maco_desc1
                        Else
                            tetxBoxcell(dgvStoryBoard, CInt(Request.item_color), rowindex, "")
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.item_no)).Value = ""
                            dgvStoryBoard.Rows(rowindex).Cells(CInt(Request.Maco_desc1)).Value = ""
                        End If

                        olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)
                        'olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(CInt(oMdb_Item_VColor.Item_Master_Id), CInt(itemM.Item_Master_Id))

                        olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetCompListCBO(CInt(oMdb_Item_VColor.Item_Master_Id), CInt(itemM.Item_Master_Id))

                        If olstImp_Loc_VIEW.Count <> 0 And m_clorid <> 0 Then

                            Call comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), CInt(rowindex),
                                      "DEC_MET_ID", "DEC_MET_DESC", olstImp_Loc_VIEW)

                            '++ID 1.15.2018-----------------------------------------------
                            oMdb_Item_Imp_Loc_VIEW_Copy = New cMdb_Item_Imp_Loc_VIEW
                            olstImp_Loc_VIEW_Copy = New List(Of cMdb_Item_Imp_Loc_VIEW)

                            'I need make something like for regular item. Example on the Notepad++
                            'example with BB104

                            olstImp_Loc_VIEW_Copy = oMdb_Item_Imp_Loc_VIEW_Copy.LoadDecMetComp_List(CInt(oMdb_Item_VColor.Item_Master_Id), CInt(dgvStoryBoard.Item(Request.item_master_id, CInt(rowindex)).Value))

                            If Not olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1) Is Nothing Then

                                Try
                                    ' Dim idDecMet As Int32 = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Dec_Met_Id

                                    comboboxCellrec = New DataGridViewComboBoxCell
                                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.DEC_MET_DESC, CInt(rowindex)), DataGridViewComboBoxCell) ' 
                                    comboboxCellrec.Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Dec_Met_Id

                                    '    Dim idImpLoc As Int32 = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Imp_Loc_Id

                                    comboboxCellrec = New DataGridViewComboBoxCell
                                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(Request.IMP_DESCRIPTION, CInt(rowindex)), DataGridViewComboBoxCell) ' 
                                    comboboxCellrec.Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Imp_Loc_Id


                                    dgvStoryBoard.Rows(CInt(rowindex)).Cells(CInt(Request.Area_Size)).Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).AREA_SIZE
                                    dgvStoryBoard.Rows(CInt(rowindex)).Cells(CInt(Request.DEFAULT_LOC)).Value = olstImp_Loc_VIEW_Copy.Find(Function(c As cMdb_Item_Imp_Loc_VIEW) c.Default_Loc = 1).Default_Loc
                                Catch ex As Exception
                                    MsgBox("Error in " & Me.Name & ". Select dfault decorating method,location,area size,default checkbox." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                End Try
                            End If
                            '---------------------------------------------------------------


                        End If

                        dgvStoryBoard.BeginEdit(False)

                    Next

                End If
                'rows colors
                Call GridLine_Color()

            ElseIf dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.DEC_MET_DESC) Then

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Area_Size)).Value = ""
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.DEFAULT_LOC)).Value = 0

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.IMP_DESCRIPTION)).Selected = True
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.BackGround_Color)).Value = ""
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.StampingPattern)).Value = ""

            ElseIf dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.IMP_DESCRIPTION) Then

                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                oMdb_Item_Imp_Loc_VIEW = combo.SelectedItem

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Area_Size)).Value = oMdb_Item_Imp_Loc_VIEW.AREA_SIZE
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.DEFAULT_LOC)).Value = oMdb_Item_Imp_Loc_VIEW.Default_Loc
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Area_Size)).Selected = True

            End If

            ' lblRowsNo.Text = LabelRowCount & dgvStoryBoard.RowCount
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '++ID 02.08.2022-----------------------------------
    Private Function MixAndMatch(ByVal _item_master_id As Int32) As Boolean
        MixAndMatch = False 'mean not mix and match item
        Dim db As New cDBA
        Dim dt As New DataTable
        Dim strSql As String = ""
        Try

            strSql = "  Select VALUE_INT from MDB_ITEM_FLD_VALUE where ITEM_MASTER_ID = " & _item_master_id & " and ITEM_FLD_ID = 266 and VALUE_INT = 1"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                MixAndMatch = True
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '-----------------------------------

    Private Sub cboDropDown_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim combo As ComboBox = CType(sender, ComboBox)

            If dgvStoryBoard.CurrentCell.ColumnIndex = CInt(Request.DEC_MET_DESC) Then
                '  oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Try
            Call AddDocument(Icon_Path)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Drag the file

    Private Sub pan1DocStok_DragDrop(sender As Object, e As DragEventArgs) Handles pan1DocStok.DragDrop
        Try
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                '  MsgBox(path)
                Call AddDocument(path)
            Next
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub pan1DocStok_DragEnter(sender As Object, e As DragEventArgs) Handles pan1DocStok.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub pan2DocStok_DragDrop(sender As Object, e As DragEventArgs) Handles pan2DocStok.DragDrop
        Try
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                '  MsgBox(path)
                Call AddDocument(path)
            Next
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub pan2DocStok_DragEnter(sender As Object, e As DragEventArgs) Handles pan2DocStok.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '--------------------------------function for add image---------------------------------
    Private Function Icon_Path() As String
        Icon_Path = ""
        Try
            Dim result As DialogResult
            Dim opFileD As New OpenFileDialog

            result = opFileD.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then
                Icon_Path = opFileD.FileName
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub AddDocument(ByVal m_path As String)

        Try
            If m_path = "" Then Exit Sub

            Dim m_FileUpload As ADODB.Stream
            Dim strIcon_Name As String = ""
            Dim strFile(System.Enum.GetNames(GetType(Documentlinklabel)).Length) As String
            ' Enum.GetValues(typeof(Documentlinklabel)).Cast<Documentlinklabel>().Distinct().Count()

            Dim ByteIcon As Byte() = Nothing

            Dim myFile As New FileInfo(m_path)

            If myFile Is Nothing Then Exit Sub

            Debug.Print(FormatBytes(myFile.Length))

            strIcon_Name = m_path.Substring(m_path.LastIndexOf("\") + 1).Substring(0, m_path.Substring(m_path.LastIndexOf("\") + 1).LastIndexOf("."))

            strFile(Documentlinklabel.ID) = 0 'now is 0(zero) becuase added from system
            strFile(Documentlinklabel.DocTxtShow) = m_path.Substring(m_path.LastIndexOf("\") + 1).Replace("?", "") 'abstract_color_background_picture_8016-wide.jpg


            strFile(Documentlinklabel.DocName) = strIcon_Name.Replace("?", "") 'abstract_color_background_picture_8016-wide
            strFile(Documentlinklabel.DocPath) = m_path 'C:\Users\iond\Pictures\abstract_color_background_picture_8016-wide.jpg
            strFile(Documentlinklabel.DocExtention) = m_path.Substring(m_path.LastIndexOf(".") + 1).Replace("?", "") ' jpg
            'm_path.Substring(m_path.LastIndexOf("\") + 1) = "background-11.jpg"
            strFile(Documentlinklabel.DocGuid) = ""

            m_FileUpload = New ADODB.Stream
            m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
            m_FileUpload.Open()
            m_FileUpload.LoadFromFile(m_path)

            ByteIcon = m_FileUpload.Read

            Debug.Print(" ICON_NAME-" & strIcon_Name & "; FILENAME:- " & strFile(Documentlinklabel.DocPath) & "; Icon:- " & ByteIcon.ToString)

            If FilesSize(ByteIcon.Length) >= 19000 Then

                MsgBox("You cannot add files more than 20 MB in your request." & vbCrLf & "Because email box cannot receive more than 20 MB. " & vbCrLf & "Document Is Not added. Thank you")
                Exit Sub
            End If

            lblDetailSizeRezult.Text = FilesSize(ByteIcon.Length).ToString & "KB - " & FormatNumber(FilesSize(ByteIcon.Length) / 1024, 0) & "MB"

            Call Add_DinamicLinkLabel(pan1DocStok, strFile, ByteIcon, FormatBytes(myFile.Length))

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Dim DoubleBytes As Double
    'give All files size
    Public Function FilesSize(Optional ByVal byteLen As ULong = 0) As Double
        FilesSize = New Double
        Try
            Dim ByteIcon As Byte() = Nothing
            Dim calculateSize As ULong = 0
            Dim lblLabel As New Label

            Dim lblLink As xLinkLabel = Nothing
            Dim lbl As Label = Nothing
            Dim m_var As String = lblLabel.Tag

            For Each ctrl As Control In grpAdditDetail.Controls
                'search panel 1 & 2
                If TypeOf ctrl Is Panel Then
                    If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        'check in the panel
                        For Each pan As Control In ctrl.Controls
                            'find linklabel with id from label
                            If TypeOf pan Is LinkLabel Then
                                'If pan.Name = m_var Then
                                lblLink = pan
                                ByteIcon = lblLink.TagByte
                                calculateSize += ByteIcon.Length
                                ' End If
                            End If
                        Next '  For Each pan As Control In ctrl.Controls
                    End If '  If (ctrl.Name = "pan1" Or ctrl.Name = "pan2") Then
                End If '  If TypeOf ctrl Is Panel Then
            Next '   For Each ctrl As Control In m_control.Controls

            DoubleBytes = CDbl((calculateSize + byteLen) / 1024)

            Return CDbl(FormatNumber(DoubleBytes, 0))   '  FormatBytes(calculateSize)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'give document size 

    Default Public Property FormatBytes(ByVal BytesCaller As ULong) As String
        Get
            Try
                Select Case BytesCaller
                    Case Is >= 1099511627776
                        DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                        Return FormatNumber(DoubleBytes, 0) & " TB"
                    Case 1073741824 To 1099511627775
                        DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                        Return FormatNumber(DoubleBytes, 2) & " GB"
                    Case 1048576 To 1073741823
                        DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                        Return FormatNumber(DoubleBytes, 0) & " MB"
                    Case 1024 To 1048575
                        DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                        Return FormatNumber(DoubleBytes, 0) & " KB"
                    Case 0 To 1023
                        DoubleBytes = BytesCaller ' bytes
                        Return FormatNumber(DoubleBytes, 0) & " bytes"
                    Case Else
                        Return ""
                End Select
            Catch ex As Exception
                MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                Return ""
            End Try
        End Get
        Set(value As String)

        End Set
    End Property
    Public Function FormatBytesDb(ByVal BytesCaller As ULong) As ULong
        FormatBytesDb = New Double
        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 0)
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2)
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 0)
                Case 1024 To 1048575
                    DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 0)
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    Return FormatNumber(DoubleBytes, 0)
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
            Return ""
        End Try

    End Function

    '----------------------------------------------------------------------------
    '--------- create frunction fro have label, and picturebox dinamic -----
    '--------- is called in linklabel generator -----------
    Public Function Add_DinamicLinkLabel(ByRef pan As Panel, ByVal p_Value() As String, ByRef m_Byte As Byte(), Optional ByVal doc_size As String = "") As xLinkLabel
        Add_DinamicLinkLabel = New xLinkLabel
        Try
            Dim g As Guid
            Dim cptobj As Int32
            Dim toolTipLnklLabel As New ToolTip()

            Add_DinamicLinkLabel.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
            Add_DinamicLinkLabel.Height = 13


            g = Guid.NewGuid()

            Dim strGuid As String

            If p_Value(Documentlinklabel.DocGuid).ToString <> "" Then
                strGuid = p_Value(Documentlinklabel.DocGuid).ToString
            Else
                strGuid = g.ToString
            End If

            Select Case findObject(pan1DocStok)
                Case <= 6
                    cptobj = 0
                    If findObject(pan1DocStok) >= 1 Then cptobj = 13 * (findObject(pan1DocStok))
                    'show toolTip
                    toolTipLnklLabel = New ToolTip
                    With toolTipLnklLabel
                        .Tag = strGuid
                        .SetToolTip(Add_DinamicLinkLabel, p_Value(Documentlinklabel.DocPath))
                    End With

                    With Add_DinamicLinkLabel
                        .Name = strGuid 'g.ToString
                        .Location = New Point(9, 0 + cptobj)
                        If p_Value(Documentlinklabel.DocTxtShow) <> "" Then .Text = p_Value(Documentlinklabel.DocTxtShow) Else .Text = p_Value(Documentlinklabel.DocPath)
                        If p_Value(Documentlinklabel.DocName) <> "" Then .TagName = p_Value(Documentlinklabel.DocName) Else .TagName = p_Value(Documentlinklabel.DocPath)
                        If p_Value(Documentlinklabel.DocExtention) <> "" Then .TagExtention = p_Value(Documentlinklabel.DocExtention) Else .TagExtention = p_Value(Documentlinklabel.DocPath)

                        If CInt(p_Value(Documentlinklabel.ID)) <> 0 Then .TagId = p_Value(Documentlinklabel.ID) Else .TagId = 0
                        .TagPath = p_Value(Documentlinklabel.DocPath)
                        .TagByte = m_Byte
                        .Tag = strGuid
                        .Width = 180
                    End With
                    'create x delete
                    Call Add_DinamicLabel(pan1DocStok, cptobj, 202, Add_DinamicLinkLabel.Name, doc_size)
                    AddHandler Add_DinamicLinkLabel.MouseClick, AddressOf DinamicLinkLabel_MouseClick
                    AddHandler Add_DinamicLinkLabel.MouseDown, AddressOf DinamicLinkLabel_MouseDown

                    pan1DocStok.Controls.Add(Add_DinamicLinkLabel)
                Case Else
                    ' need put in tis block 
                    Select Case findObject(pan2DocStok)
                        Case <= 6
                            cptobj = 0
                            If findObject(pan2DocStok) >= 1 Then cptobj = 13 * (findObject(pan2DocStok))
                            'show toolTip
                            toolTipLnklLabel = New ToolTip
                            With toolTipLnklLabel
                                .Tag = strGuid
                                .SetToolTip(Add_DinamicLinkLabel, p_Value(Documentlinklabel.DocPath))
                            End With
                            With Add_DinamicLinkLabel
                                .Name = strGuid 'g.ToString
                                .Location = New Point(9, 0 + cptobj)
                                If p_Value(Documentlinklabel.DocTxtShow) <> "" Then .Text = p_Value(Documentlinklabel.DocTxtShow) Else .Text = p_Value(Documentlinklabel.DocPath)
                                If p_Value(Documentlinklabel.DocName) <> "" Then .TagName = p_Value(Documentlinklabel.DocName) Else .TagName = p_Value(Documentlinklabel.DocPath)
                                If CInt(p_Value(Documentlinklabel.ID)) <> 0 Then .TagId = p_Value(Documentlinklabel.ID) Else .TagId = 0

                                If p_Value(Documentlinklabel.DocExtention) <> "" Then .TagExtention = p_Value(Documentlinklabel.DocExtention) Else .TagExtention = p_Value(Documentlinklabel.DocPath)
                                .TagPath = p_Value(Documentlinklabel.DocPath)
                                .TagByte = m_Byte
                                .Tag = strGuid
                                .Width = 180
                            End With
                            'create x delete

                            Call Add_DinamicLabel(pan2DocStok, cptobj, 202, Add_DinamicLinkLabel.Name, doc_size)
                            AddHandler Add_DinamicLinkLabel.MouseClick, AddressOf DinamicLinkLabel_MouseClick
                            AddHandler Add_DinamicLinkLabel.MouseDown, AddressOf DinamicLinkLabel_MouseDown

                            '   Private Sub lstViewCustomerMiddle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewCustomerMiddle.MouseDown


                            pan2DocStok.Controls.Add(Add_DinamicLinkLabel)
                        Case Else
                            MsgBox("No more 14 file ")
                    End Select
            End Select

            Return Add_DinamicLinkLabel

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '------------
    Private Sub DinamicLinkLabel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            'Drag Drop from form on the our folder work but mix event MouseClick with MouseDown
            'when I tyr only click and open the file function only make copy on panel


            'Dim cLinkLabel As New xLinkLabel
            'cLinkLabel = sender
            'Dim data As DataObject = New DataObject()
            'Dim path As String = Trim(cLinkLabel.TagPath.Substring(cLinkLabel.TagPath.LastIndexOf("\") + 1).Substring(0, cLinkLabel.TagPath.Substring(cLinkLabel.TagPath.LastIndexOf("\") + 1).LastIndexOf(".")))

            'path &= "." & cLinkLabel.TagExtention

            'If (Not Directory.Exists("C\ExactTemp")) Then
            '    Directory.CreateDirectory("C\ExactTemp")
            'End If

            'If File.Exists("C\ExactTemp\" & path) Then

            '    data.SetData(DataFormats.FileDrop, New String() {"C\ExactTemp\" & path})
            '    'set to DragDropEffects.All, if you want to copy or move locally with Control-Key-pressed
            '    cLinkLabel.DoDragDrop(data, DragDropEffects.Copy)
            'Else
            '    Dim newFile As FileStream = File.Create("C\ExactTemp\" & path)
            '    'newFile.Write(byteStream, 0, byteStream.Length)
            '    newFile.Write(cLinkLabel.TagByte, 0, cLinkLabel.TagByte.Length)
            '    newFile.Dispose()

            '    data.SetData(DataFormats.FileDrop, New String() {"C\ExactTemp\" & path})
            '    'set to DragDropEffects.All, if you want to copy or move locally with Control-Key-pressed

            '    cLinkLabel.DoDragDrop(data, DragDropEffects.Copy)
            'End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '------------
    Public Function Add_DinamicLabel(ByRef pan As Panel, ByVal cptobj As String, ByVal m_X As Int32, ByVal m_linkId As String, Optional ByVal doc_size As String = "") As Label
        Add_DinamicLabel = New Label
        Try
            Dim g As Guid
            Dim toolTipLnklLabel As New ToolTip()
            '    Dim cptobj As Int32 = 0

            Add_DinamicLabel.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
            Add_DinamicLabel.Height = 13

            g = Guid.NewGuid()
            'Select Case findObject(pan1)
            '    Case <= 4
            '        If findObject(pan1) >= 1 Then cptobj = 27 * (findObject(pan1))
            'toolTip
            toolTipLnklLabel = New ToolTip
            With toolTipLnklLabel
                .Tag = m_linkId
                .SetToolTip(Add_DinamicLabel, "Delete Document")
            End With
            With Add_DinamicLabel
                .Name = g.ToString
                .Location = New Point(m_X, 1 + cptobj) 'was 5
                .Text = "(" & doc_size & ") X "
                ' .Font = New Font("Arial Rounded MT", 7, FontStyle.Bold)
                .ForeColor = Color.Red
                .Tag = m_linkId
            End With
            'End Select

            AddHandler Add_DinamicLabel.MouseClick, AddressOf DinamicLabelObj_MouseClick
            pan.Controls.Add(Add_DinamicLabel)

            Return Add_DinamicLabel

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Add_DinamicPictureBox() As PictureBox
        Add_DinamicPictureBox = Nothing
        Try

            With Add_DinamicPictureBox()

            End With

            Return Add_DinamicPictureBox

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'return caunt of labels from specific panel 
    Public Function findObject(Optional ByRef m_control As Control = Nothing, Optional ByRef m_var As Int32 = 0) As Int32
        findObject = 0
        Try
            For Each ctrl As Control In m_control.Controls
                If TypeOf ctrl Is LinkLabel Then
                    findObject += 1
                End If
            Next

            Return findObject

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function findObjectRemove(ByRef m_var As String) As Int32
        findObjectRemove = 0
        Try
            Dim lblLink As xLinkLabel = Nothing
            Dim lbl As Label = Nothing

            For Each ctrl As Control In grpAdditDetail.Controls

                'search panel 1 & 2
                If TypeOf ctrl Is Panel Then

                    If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        'check teh panel
                        For Each pan As Control In ctrl.Controls
                            'find linklabel with id from label

                            If TypeOf pan Is LinkLabel Then
                                If pan.Name = m_var Then

                                    lblLink = pan
                                    'cannot remove object into ctrl.Controls , because fro each is broken we remove from loop
                                    ' ctrl.Controls.Remove(pan)
                                    findObjectRemove = 1
                                    ' in this function DocDelete are deleted also documents with same DocId  olstReqDocBindItem
                                    If CInt(lblLink.TagId) <> 0 Then Call DocDelete(CInt(lblLink.TagId))
                                End If
                            ElseIf TypeOf pan Is Label Then
                                If pan.Tag = m_var Then
                                    lbl = pan
                                    ' ctrl.Controls.Remove(pan)
                                End If
                            End If

                        Next '  For Each pan As Control In ctrl.Controls

                        'need identify in which panel we are
                        'Delete  document from db

                        If ctrl.Controls.Contains(lblLink) Then ctrl.Controls.Remove(lblLink)
                        If ctrl.Controls.Contains(lbl) Then ctrl.Controls.Remove(lbl)

                    End If '  If (ctrl.Name = "pan1" Or ctrl.Name = "pan2") Then
                End If '  If TypeOf ctrl Is Panel Then

                'If TypeOf ctrl Is LinkLabel Then
                '    findObjectData += 1
                'End If
            Next '   For Each ctrl As Control In m_control.Controls

            Call MoveObject()

            Return findObjectRemove

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function MoveObject() As Int32
        MoveObject = 0
        Try
            Dim oLinkLabel As cLinkLabel
            Dim listLnkLabel As New List(Of cLinkLabel)
            Dim linkCPT As Int32 = 0

            Dim oLabel As cLabel
            Dim listlbl As New List(Of cLabel)
            Dim lblCPT As Int32 = 0

            For Each ctrl As Control In grpAdditDetail.Controls
                Select Case True
                    Case TypeOf ctrl Is Panel
                        'search in the panel side
                        'find all linklabeland label and stock in list
                        'after need move and arrange in the panels 
                        '  If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        If ctrl.Name = "pan1DocStok" Then

                            For Each pan As Control In ctrl.Controls
                                If TypeOf pan Is LinkLabel Then
                                    oLinkLabel = New cLinkLabel

                                    linkCPT += 1
                                    oLinkLabel.Count = linkCPT

                                    oLinkLabel.LNKLABEL = pan

                                    'oLinkLabel.LNKLABEL.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
                                    'oLinkLabel.LNKLABEL.Height = 13

                                    listLnkLabel.Add(oLinkLabel)
                                ElseIf TypeOf pan Is Label Then
                                    oLabel = New cLabel

                                    lblCPT += 1
                                    oLabel.Count = lblCPT
                                    oLabel.LABEL = pan
                                    'oLabel.LABEL.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
                                    'oLabel.LABEL.Height = 13
                                    listlbl.Add(oLabel)
                                End If
                            Next

                        ElseIf ctrl.Name = "pan2DocStok" Then
                            For Each pan As Control In ctrl.Controls
                                If TypeOf pan Is LinkLabel Then
                                    oLinkLabel = New cLinkLabel

                                    linkCPT += 1
                                    oLinkLabel.Count = linkCPT

                                    oLinkLabel.LNKLABEL = pan

                                    'oLinkLabel.LNKLABEL.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
                                    'oLinkLabel.LNKLABEL.Height = 13

                                    listLnkLabel.Add(oLinkLabel)
                                ElseIf TypeOf pan Is Label Then
                                    oLabel = New cLabel

                                    lblCPT += 1
                                    oLabel.Count = lblCPT
                                    oLabel.LABEL = pan
                                    'oLabel.LABEL.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
                                    'oLabel.LABEL.Height = 13
                                    listlbl.Add(oLabel)
                                End If
                            Next
                        End If
                End Select
            Next

            Debug.Print(listLnkLabel.ToString)
            Debug.Print(listlbl.ToString)

            Dim lbl As Label = Nothing

            'lbl.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
            'lbl.Height = 13
            Dim cptObj As Int32 = 0

            For Each lstLink As cLinkLabel In listLnkLabel
                If lstLink.Count = 1 Then
                    lstLink.LNKLABEL.Location = New Point(9, 0)

                    lbl = listlbl.Find(Function(i As cLabel) i.Count = lstLink.Count).LABEL
                    lbl.Location = New Point(202, 0)
                    pan1DocStok.Controls.Add(lstLink.LNKLABEL)
                    pan1DocStok.Controls.Add(lbl)
                ElseIf lstLink.Count >= 2 And lstLink.Count <= 7 Then
                    cptObj += 13
                    lstLink.LNKLABEL.Location = New Point(9, 0 + cptObj)

                    lbl = listlbl.Find(Function(i As cLabel) i.Count = lstLink.Count).LABEL
                    lbl.Location = New Point(202, 0 + cptObj)
                    pan1DocStok.Controls.Add(lstLink.LNKLABEL)
                    pan1DocStok.Controls.Add(lbl)
                ElseIf lstLink.Count = 8 Then
                    cptObj = 0
                    lstLink.LNKLABEL.Location = New Point(9, 0)

                    lbl = listlbl.Find(Function(i As cLabel) i.Count = lstLink.Count).LABEL
                    lbl.Location = New Point(202, 0)
                    pan2DocStok.Controls.Add(lstLink.LNKLABEL)
                    pan2DocStok.Controls.Add(lbl)
                ElseIf lstLink.Count >= 7 And lstLink.Count <= 14 Then
                    cptObj += 13
                    lstLink.LNKLABEL.Location = New Point(9, 0 + cptObj)

                    lbl = listlbl.Find(Function(i As cLabel) i.Count = lstLink.Count).LABEL
                    lbl.Location = New Point(202, 0 + cptObj)
                    pan2DocStok.Controls.Add(lstLink.LNKLABEL)
                    pan2DocStok.Controls.Add(lbl)
                End If

            Next

            Return MoveObject
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub DinamicLabelObj_MouseClick(sender As Object, e As MouseEventArgs)
        Try
            Dim lblLabel As New Label
            lblLabel = sender
            Dim lblLink As xLinkLabel = Nothing
            Dim lbl As Label = Nothing
            Dim m_var As String = lblLabel.Tag

            For Each ctrl As Control In grpAdditDetail.Controls
                'search panel 1 & 2
                If TypeOf ctrl Is Panel Then
                    If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        'check in the panel
                        For Each pan As Control In ctrl.Controls
                            'find linklabel with id from label
                            If TypeOf pan Is LinkLabel Then
                                If pan.Name = m_var Then
                                    lblLink = pan
                                End If
                            End If
                        Next '  For Each pan As Control In ctrl.Controls
                    End If '  If (ctrl.Name = "pan1" Or ctrl.Name = "pan2") Then
                End If '  If TypeOf ctrl Is Panel Then
            Next '   For Each ctrl As Control In m_control.Controls

            Dim result As DialogResult

            result = MessageBox.Show(" Document Name - " & lblLink.Text & " - " & lblLabel.Text & " will be deleted.", "Delete Alert !!! Make your choose.",
                                             MessageBoxButtons.YesNoCancel)
            Select Case result
                Case DialogResult.Cancel
                    Exit Sub
                Case DialogResult.No
                    Exit Sub
                Case DialogResult.Yes
                    Dim RepeatResult As DialogResult
                    RepeatResult = MessageBox.Show(" Documents will be deleted definitely. ", " Alert !!!", MessageBoxButtons.OKCancel)

                    Select Case RepeatResult
                        Case DialogResult.Cancel
                            Exit Select
                        Case DialogResult.OK

                            '----------------------- Execute Delete ------------------------
                            Call findObjectRemove(lblLabel.Tag)

                    End Select 'RepeatResult
            End Select 'result

            lblDetailSizeRezult.Text = FilesSize(0).ToString & "KB - " & FormatNumber(FilesSize(0) / 1024, 0) & "MB"

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DinamicLinkLabel_MouseClick(sender As Object, e As MouseEventArgs)
        Try
            Dim linklLbl As New xLinkLabel

            linklLbl = sender

            Call openDocument(linklLbl.Text, linklLbl.TagByte)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'open document 
    Private Sub openDocument(ByRef m_name As String, Optional ByRef m_byte As Byte() = Nothing)
        Try
            '  Dim byteStream As Byte()

            ' save document to file system

            Dim strSaveName As String = m_name ' oDoc.Item_Doc_Name & "." & oDoc.Item_Doc_File_Ext

            '    byteStream = m_byte 'CType(oDoc.Item_Doc, Byte())

            If (Not Directory.Exists("C\ExactTemp")) Then
                Directory.CreateDirectory("C\ExactTemp")
            End If

            'exception was added because for certaine events come with repertoire C:\ExactTemp\BB102_BLU_BP-1.jpg from BindImageItem..listview
            If Not m_byte Is Nothing Then
                Dim newFile As FileStream = File.Create("C\ExactTemp\" & strSaveName)
                'newFile.Write(byteStream, 0, byteStream.Length)
                newFile.Write(m_byte, 0, m_byte.Length)
                newFile.Dispose()
                Dim p As New System.Diagnostics.Process
                Dim s As New System.Diagnostics.ProcessStartInfo("C\ExactTemp\" & strSaveName)
                s.UseShellExecute = True
                s.WindowStyle = ProcessWindowStyle.Normal
                p.StartInfo = s
                p.Start()

            Else
                ' Open document 
                Dim p As New System.Diagnostics.Process
                Dim s As New System.Diagnostics.ProcessStartInfo(strSaveName)
                s.UseShellExecute = True
                s.WindowStyle = ProcessWindowStyle.Normal
                p.StartInfo = s
                p.Start()

            End If

            'If File.Exists("C\ExactTemp\" & strSaveName) Then
            '    File.Delete("C\ExactTemp\" & strSaveName)
            'End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub pan2DocStok_MouseCaptureChanged(sender As Object, e As EventArgs) Handles pan2DocStok.MouseCaptureChanged
        Try
            Label2.Text = ""
            Dim mspt = New Point(Cursor.Position)
            Label2.Text = "x" & mspt.X & "y: " & mspt.Y

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub pan1DocStok_MouseCaptureChanged(sender As Object, e As EventArgs) Handles pan1DocStok.MouseCaptureChanged
        Try
            Label4.Text = ""
            Dim mspt = New Point(Cursor.Position)
            Label4.Text = "x" & mspt.X & "y: " & mspt.Y

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Private Sub btSrc_Click(sender As Object, e As EventArgs) Handles btSrc.Click
    '    Try

    '        Call Customer_Lst()

    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub

#Region "---------------------- work with lstCustomer --------------------------"
    Public Sub Customer_Lst()
        Try
            oCicmpy = New cCicmpy
            olsCicmpy = New List(Of cCicmpy)
            Dim strQuery As String = ""

            ImgList = New ImageList With {.ImageSize = New Size(15, 15)}

            '---------------- fill listbox with probabily customers ------------------
            If Trim(txtCustomer.Text) = "" Then
                olsCicmpy = oCicmpy.GetList_Cicmpy()
            Else
                strQuery = " where (cmp_code Like '%" & Trim(txtCustomer.Text) & "%' or cmp_name like '%" & Trim(txtCustomer.Text) & "%')"
                olsCicmpy = oCicmpy.GetList_Cicmpy(strQuery)
            End If

            'if search find only ome item display
            If olsCicmpy.Count = 1 Then
                oCicmpy = New cCicmpy

                txtCustomer.Text = Trim(olsCicmpy.Item(0).CMP_CODE)
                lblCustomerName.AutoSize = True
                lblCustomerName.Text = Trim(olsCicmpy.Item(0).CMP_NAME)
                'put value in TAG for use load contact 
                lblCustomerName.Tag = Trim(olsCicmpy.Item(0).CMP_WWN)

                lnkLblContactShow.Text = ""
                lblContactEmail.Text = ""
                Exit Sub
            ElseIf olsCicmpy.Count = 0 Then
                '    MsgBox("FOUND " & olsCicmpy.Count & " ROWS .")

                lblCustomerName.Text = String.Empty
                lnkLblContactShow.Text = "-"

                Exit Sub
            End If

            panMiddleLstViewCustomerShow.Visible = True
            panMiddleLstViewCustomerShow.Width = 750
            panMiddleLstViewCustomerShow.Left = 239
            lstViewCustomerMiddle.Items.Clear()

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()

            With lstViewCustomerMiddle
                .SmallImageList = ImgList
                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .CheckBoxes = False
                .Columns.Clear() ' make sure collumnscollection is empty
                ' Add 3 columns
                .Columns.AddRange(New ColumnHeader() {listColumns(Cicmpy_Enum.Cmp_code.ToString, Cicmpy_Enum.Cmp_code.ToString, HorizontalAlignment.Left, 120),
                                                     listColumns(Cicmpy_Enum.Cmp_name.ToString, Cicmpy_Enum.Cmp_name.ToString, HorizontalAlignment.Left, 350),
                                                     listColumns(Cicmpy_Enum.Cmp_e_mail.ToString, Cicmpy_Enum.Cmp_e_mail.ToString, HorizontalAlignment.Left, 250),
                                                      listColumns(Cicmpy_Enum.Cmp_wwn.ToString, Cicmpy_Enum.Cmp_wwn.ToString, HorizontalAlignment.Left, 0)})
                .FullRowSelect = True
                .GridLines = True
            End With

            'For Each oCust As cCicmpy In olsCicmpy
            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
            'Next

            For Each oCust As cCicmpy In olsCicmpy
                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem
                item(UBound(item)).Text = Trim(oCust.CMP_CODE).ToString

                item(UBound(item)).SubItems.Add(Trim(oCust.CMP_NAME).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCust.CMP_E_MAIL).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCust.CMP_WWN).ToString)
                Items.Add(item(UBound(item)))
            Next

            lstViewCustomerMiddle.BeginUpdate()
            lstViewCustomerMiddle.Items.AddRange(Items.ToArray)
            lstViewCustomerMiddle.EndUpdate()
            lstViewCustomerMiddle.Visible = True
            lstViewCustomerMiddle.Focus()

            lblMiddleLineNameDisplay.Text = ListViewName.Customer.ToString & "-" & ListViewName.Customer  'cust_show.Customer.ToString
            lblMiddleLineNameDisplay.Tag = ListViewName.Customer
            lblMiddleLineFound.Text = Items.Count & " rows"

            Call ListView_RowsColor(lstViewCustomerMiddle)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Contact_Lst()
        Try
            oCicntpReq = New cCicntpReq
            olsCicntpReq = New List(Of cCicntpReq)

            '---------------- fill listbox with probabily customers ------------------
            If Trim(txtCustomer.Text) = String.Empty Then
                '    olsCicntpReq = oCicntpReq.GetList_cCicntpReq()
                'if Customer is not selected contact don't exist
                'close sub
                Exit Sub
            Else
                If Trim(txtContactSearch.Text) = "" Then
                    olsCicntpReq = oCicntpReq.GetList_cCicntpReq(Trim(lblCustomerName.Tag))
                Else
                    olsCicntpReq = oCicntpReq.GetList_cCicntpReq(Trim(lblCustomerName.Tag), Trim(txtContactSearch.Text))
                End If

            End If

            '  If search Then find only ome item display
            If olsCicntpReq.Count = 1 Then
                oCicntpReq = New cCicntpReq

                lnkLblContactShow.Text = olsCicntpReq.Item(0).FULLNAME
                lnkLblContactShow.Tag = olsCicntpReq.Item(0).CNT_ID
                lnkLblContactShow.AutoSize = True

                'txtContactSearch.Text = olsCicntpReq.Item(0).FULLNAME
                'txtContactSearch.Tag = olsCicntpReq.Item(0).CNT_ID
                txtContactSearch.Hide()
                '  txtContactSearch.Text = String.Empty

                If String.IsNullOrEmpty(Trim(olsCicntpReq.Item(0).CNT_EMAIL)) = False Then 'normal state if string is not empty is false
                    lblContactEmail.Text = olsCicntpReq.Item(0).CNT_EMAIL
                Else 'if string is empty satet is true
                    lblContactEmail.Text = "Missing e-mail address."
                End If



                Exit Sub
                ElseIf olsCicntpReq.Count = 0 Then
                    '     MsgBox("FOUND " & olsCicntpReq.Count & " ROWS .")

                    'lnkLblContactShow.Text = ""
                    'lblContactEmail.Text = ""

                    '   txtContactSearch.Text = String.Empty
                    '   txtContactSearch.Tag = 0

                    '   Exit Sub
                End If

            panMiddleLstViewCustomerShow.Visible = True
            panMiddleLstViewCustomerShow.Width = 750
            panMiddleLstViewCustomerShow.Left = 239
            lstViewCustomerMiddle.Items.Clear()

            ImgList = New ImageList With {.ImageSize = New Size(15, 15)}
            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()

            With lstViewCustomerMiddle
                .View = View.Details
                .CheckBoxes = False
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .Columns.Clear() ' make sure collumnscollection is empty
                ' Add 3 columns
                .SmallImageList = ImgList
                .Columns.AddRange(New ColumnHeader() {listColumns(Cicntp_Enum.cnt_l_name.ToString, Cicntp_Enum.cnt_l_name.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(Cicntp_Enum.FullName.ToString, Cicntp_Enum.FullName.ToString, HorizontalAlignment.Left, 150),
                                                      listColumns(Cicntp_Enum.Gender.ToString, Cicntp_Enum.Gender.ToString, HorizontalAlignment.Left, 80),
                                                      listColumns(Cicntp_Enum.cnt_job_desc.ToString, Cicntp_Enum.cnt_job_desc.ToString, HorizontalAlignment.Left, 150),
                                                      listColumns(Cicntp_Enum.active.ToString, Cicntp_Enum.active.ToString, HorizontalAlignment.Left, 80),
                                                      listColumns(Cicntp_Enum.cnt_email.ToString, Cicntp_Enum.cnt_email.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(Cicntp_Enum.cnt_id.ToString, Cicntp_Enum.cnt_id.ToString, HorizontalAlignment.Left, 0)})
                .FullRowSelect = True
                .GridLines = True
            End With

            'For Each oCust As cCicmpy In olsCicmpy
            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
            'Next

            For Each oCic As cCicntpReq In olsCicntpReq
                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem
                item(UBound(item)).Text = Trim(oCic.CNT_L_NAME).ToString

                item(UBound(item)).SubItems.Add(Trim(oCic.FULLNAME).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCic.GENDER).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCic.CNT_JOB_DESC).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCic.ACTIVE).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCic.CNT_EMAIL).ToString)
                item(UBound(item)).SubItems.Add(Trim(oCic.CNT_ID).ToString)
                Items.Add(item(UBound(item)))
            Next

            lstViewCustomerMiddle.BeginUpdate()
            lstViewCustomerMiddle.Items.AddRange(Items.ToArray)
            lstViewCustomerMiddle.EndUpdate()
            lstViewCustomerMiddle.Visible = True
            lstViewCustomerMiddle.Focus()

            lblMiddleLineNameDisplay.Text = ListViewName.Contact.ToString & "-" & ListViewName.Contact ' cust_show.Contact.ToString
            lblMiddleLineNameDisplay.Tag = ListViewName.Contact
            lblMiddleLineFound.Text = Items.Count & " rows"

            Call ListView_RowsColor(lstViewCustomerMiddle)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "---------------------- listview show graphic department"

    Public Sub Graphic_Lst()
        Try
            oExact_Traveler_Permission = New cExact_Traveler_Permission
            olstExact_Traveler_Permission = New List(Of cExact_Traveler_Permission)
            Dim strQuery As String = ""
            '---------------- fill listbox with probabily customers ------------------
            'If Trim(xTxtShowSenderEmail.Text) = "" Then
            '    olsCicmpy = oCicmpy.GetList_Cicmpy()
            'Else
            strQuery = " where (p.user_name like '%" & Trim(xTxtShowSenderEmail.Text) &
                    "%' or p.Fullname like '%" & Trim(xTxtShowSenderEmail.Text) & "%' or  p.Email like '%" &
                    Trim(xTxtShowSenderEmail.Text) & "%' or pg.group_name like '%" & Trim(xTxtShowSenderEmail.Text) & "%')"

            olstExact_Traveler_Permission = oExact_Traveler_Permission.LoadLst(strQuery)
            ' End If

            'if search find only ome item display
            If olstExact_Traveler_Permission.Count = 1 Then
                oExact_Traveler_Permission = New cExact_Traveler_Permission

                xTxtShowSenderEmail.Text = olstExact_Traveler_Permission.Item(0).Email
                xTxtShowSenderEmail.AutoSize = True

                Exit Sub
            ElseIf olstExact_Traveler_Permission.Count = 0 Then
                '  MsgBox("FOUND " & olstExact_Traveler_Permission.Count & " ROWS .")

                '    xTxtShowSenderEmail.Text = ""

                Exit Sub
            End If
            ImgList = New ImageList With {.ImageSize = New Size(15, 15)}
            panMiddleLstViewCustomerShow.Visible = True
            lstViewCustomerMiddle.Items.Clear()

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()

            With lstViewCustomerMiddle

                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .Columns.Clear() ' make sure collumnscollection is empty
                ' Add 3 columns
                .SmallImageList = ImgList
                .CheckBoxes = False
                .Columns.AddRange(New ColumnHeader() {listColumns(Traveler_Users.User_Name.ToString, Traveler_Users.User_Name.ToString, HorizontalAlignment.Left, 120),
                                                     listColumns(Traveler_Users.Fullname.ToString, Traveler_Users.Fullname.ToString, HorizontalAlignment.Left, 150),
                                                     listColumns(Traveler_Users.Email.ToString, Traveler_Users.Email.ToString, HorizontalAlignment.Left, 250),
                                                      listColumns(Traveler_Users.Group_name.ToString, Traveler_Users.Group_name.ToString, HorizontalAlignment.Left, 120)})
                .FullRowSelect = True
                .GridLines = True
            End With

            'For Each oCust As cCicmpy In olsCicmpy
            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
            'Next

            For Each oUsers As cExact_Traveler_Permission In olstExact_Traveler_Permission
                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem
                item(UBound(item)).Text = Trim(oUsers.User_Name).ToString

                item(UBound(item)).SubItems.Add(Trim(oUsers.Fullname).ToString)
                item(UBound(item)).SubItems.Add(Trim(oUsers.Email).ToString)
                item(UBound(item)).SubItems.Add(Trim(oUsers.Group_Name).ToString)
                Items.Add(item(UBound(item)))
            Next

            lstViewCustomerMiddle.BeginUpdate()
            lstViewCustomerMiddle.Items.AddRange(Items.ToArray)
            lstViewCustomerMiddle.EndUpdate()
            lstViewCustomerMiddle.Visible = True
            lstViewCustomerMiddle.Focus()

            lblMiddleLineNameDisplay.Text = ListViewName.Traveler_Users.ToString & "-" & ListViewName.Traveler_Users
            lblMiddleLineNameDisplay.Tag = ListViewName.Traveler_Users
            lblMiddleLineFound.Text = Items.Count & " rows"

            Call ListView_RowsColor(lstViewCustomerMiddle)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region


    Private Sub lnkLabelIcoContact_Click(sender As Object, e As EventArgs) Handles lnklblIcoContact.Click
        Try
            txtContactSearch.Show()
            txtContactSearch.Focus()

            Call Contact_Lst()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'TextChange event use for activate listview
    'Private Sub txtCustomer_Click(sender As Object, e As EventArgs) Handles txtCustomer.Click
    '    Try
    '        panMiddleLstViewCustomerShow.Visible = False
    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    '----------------------------------------------------------------------
#Region "---------- Move Panel Customer ----------------"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point

    'Not possibil move main panel because don't have acces all object in side are in the DOCK
    'Private Sub panMiddleLstViewCustomerShow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMiddleLstViewCustomerShow.MouseDown
    '    allowCoolMove = True
    '    myCoolPoint = New Point(e.X, e.Y)
    '    Me.Cursor = Cursors.SizeAll
    'End Sub
    'Private Sub panMiddleLstViewCustomerShow_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMiddleLstViewCustomerShow.MouseMove
    '    If allowCoolMove = True Then
    '        panMiddleLstViewCustomerShow.Location = New Point(panMiddleLstViewCustomerShow.Location.X + e.X - myCoolPoint.X, panMiddleLstViewCustomerShow.Location.Y + e.Y - myCoolPoint.Y)
    '    End If
    'End Sub
    'Private Sub panMiddleLstViewCustomerShow_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMiddleLstViewCustomerShow.MouseUp
    '    allowCoolMove = False
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub lstViewCustomerMiddle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewCustomerMiddle.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll

        Select Case lblMiddleLineNameDisplay.Tag

            Case ListViewName.BindeImage
                Try
                    Dim pt As Point = lstViewCustomerMiddle.PointToClient(Control.MousePosition)

                    If lstViewCustomerMiddle.GetItemAt(pt.X, pt.Y) Is Nothing Then Exit Sub

                    lstViewCustomerMiddle.GetItemAt(pt.X, pt.Y).Selected = True
                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try
                '--------------
                Try
                    If lstViewCustomerMiddle.SelectedItems.Count > 0 Then
                        If File.Exists(Me.lstViewCustomerMiddle.SelectedItems(0).SubItems(2).Text) Then
                            Dim data As DataObject = New DataObject()
                            data.SetData(DataFormats.FileDrop, New String() {Me.lstViewCustomerMiddle.SelectedItems(0).SubItems(2).Text})
                            'set to DragDropEffects.All, if you want to copy or move locally with Control-Key-pressed
                            Me.lstViewCustomerMiddle.DoDragDrop(data, DragDropEffects.Copy)
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try


        End Select
    End Sub
    Private Sub lstViewCustomerMiddle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewCustomerMiddle.MouseMove
        If allowCoolMove = True Then
            lstViewCustomerMiddle.Location = New Point(lstViewCustomerMiddle.Location.X + e.X - myCoolPoint.X, lstViewCustomerMiddle.Location.Y + e.Y - myCoolPoint.Y)
            'this line move panel 
            panMiddleLstViewCustomerShow.Location = New Point(panMiddleLstViewCustomerShow.Location.X + e.X - myCoolPoint.X, panMiddleLstViewCustomerShow.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub lstViewCustomerMiddle_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewCustomerMiddle.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default

        'exception added for manage event when we click on the listview double click and item will not to be checked 
        'Select Case lblMiddleLineNameDisplay.Tag
        '    Case ListViewName.BindeImage

        '        inhibitAutoCheck = False

        'End Select
    End Sub
    '---------------- move top panel --------------
    Private Sub panlstMiddleTopCustomerInSide_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panlstMiddleTopCustomerInSide.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub
    Private Sub panlstMiddleTopCustomerInSide_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panlstMiddleTopCustomerInSide.MouseMove
        If allowCoolMove = True Then
            panlstMiddleTopCustomerInSide.Location = New Point(panlstMiddleTopCustomerInSide.Location.X + e.X - myCoolPoint.X, panlstMiddleTopCustomerInSide.Location.Y + e.Y - myCoolPoint.Y)
            'this line move panel 
            panMiddleLstViewCustomerShow.Location = New Point(panMiddleLstViewCustomerShow.Location.X + e.X - myCoolPoint.X, panMiddleLstViewCustomerShow.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub panlstMiddleTopCustomerInSide_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panlstMiddleTopCustomerInSide.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub
    '---------------------------------------------
#End Region
    Private Sub lstViewCustomerMiddle_DoubleClick(sender As Object, e As EventArgs) Handles lstViewCustomerMiddle.DoubleClick
        Try
            Debug.Print(lstViewCustomerMiddle.SelectedItems(0).SubItems(1).Text)

            'Public Enum ListViewName
            '    Customer = 0
            '    Contact = 1
            '    Traveler_Users = 2
            '    Additional_Location = 3
            'End Enum
            If lstViewCustomerMiddle.SelectedItems.Count > 0 Then

                Select Case CInt(lblMiddleLineNameDisplay.Tag)
                    Case 0 'Customer

                        lblCustomerName.Text = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(1).Text)
                        lblCustomerName.Tag = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(3).Text)

                        lnkLblContactShow.Text = "-"
                        lblContactEmail.Text = ""
                        lnkLblContactShow.Tag = 0

                        txtCustomer.Text = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(0).Text)
                    Case 1 'Contact
                        lnkLblContactShow.Text = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(1).Text)
                        lnkLblContactShow.Tag = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(6).Text) 'cnt_id
                        lblContactEmail.Text = "Contact Email: " & Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(5).Text)

                        txtContactSearch.Text = String.Empty
                        txtContactSearch.Hide()
                    Case 2 'Traveler_Users
                        xTxtShowSenderEmail.Text = Trim(lstViewCustomerMiddle.SelectedItems.Item(0).SubItems(2).Text)
                    Case 3 'Additional_Location
                        'I put for now exit sub because event need  go to MouseDouble Click
                        Exit Sub
                End Select

                lstViewCustomerMiddle.Items.Clear()
                panMiddleLstViewCustomerShow.Visible = False

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lnkLblContactShow_MouseClick(sender As Object, e As MouseEventArgs) Handles lnkLblContactShow.MouseClick
        Try

            Call Contact_Lst()


            txtContactSearch.Show()

            '     Call Contact_Lst()


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmVirtual_Request_MouseCaptureChanged(sender As Object, e As EventArgs) Handles Me.MouseCaptureChanged
        Try
            Dim mspt = New Point(Cursor.Position)

            Label3.Text = "X:" & mspt.X & "Y: " & mspt.Y
            Label1.Text = "Width: " & Me.Width & "- Height: " & Me.Height
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Declare Function ShowScrollBar Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Boolean
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Try
    '        ShowScrollBar(panBottom.Handle, 0, False)
    '    Catch ex As Exception
    '    End Try
    '    MyBase.WndProc(m)
    'End Sub
    Private Sub Timestamp_Inst_Click(sender As Object, e As EventArgs) Handles Timestamp_Inst.Click
        Try

            txtSpecInstrWrite.Text &= GETTimestamp()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Timestamp_CommeGraph_Click(sender As Object, e As EventArgs) Handles Timestamp_CommeGraph.Click
        Try
            txtSendCommFromGraph.Text &= GETTimestamp()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function GETTimestamp() As String
        GETTimestamp = String.Empty
        Try

            Dim strTime As String = String.Empty
            Dim dt = DateTime.UtcNow
            Dim utcOffset As New DateTimeOffset(dt, TimeSpan.Zero)
            Dim zone As System.TimeZoneInfo
            Dim currentDateTime As System.DateTime
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            currentDateTime = DateAndTime.Now
            zone = System.TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")

            strTime = "[" & oExact_Traveler_Permission.Fullname & " " & currentDateTime.ToString("yyyy-MM-dd hh:mm:ss tt") & " / (GMT" & utcOffset.ToOffset(zone.GetUtcOffset(utcOffset)).ToString("%K") & ")]"

            Return strTime

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub dgvStoryBoard_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvStoryBoard.KeyUp
        Try

            oMdb_Item_master = New cMdb_Item_Master

            olstMaster = New List(Of cMdb_Item_Master)
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            If e.KeyCode = Keys.Enter Then

                dgvStoryBoard.CurrentRow.Cells(Request.item_cd).Selected = True

                e.SuppressKeyPress = True


            ElseIf e.KeyCode = Keys.Tab Then
                Select Case dgvStoryBoard.CurrentCell.ColumnIndex
                    Case CInt(Request.Is_kit)
                        Call FillListBox()
                End Select
            End If
            e.SuppressKeyPress = True 'this will prevent ding sound 
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvStoryBoard_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStoryBoard.KeyDown
        Try

            oMdb_Item_master = New cMdb_Item_Master

            olstMaster = New List(Of cMdb_Item_Master)
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            If e.KeyCode = Keys.Enter Then

                dgvStoryBoard.CurrentRow.Cells(Request.item_cd).Selected = True

                e.Handled = True
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Tab Then

                Select Case dgvStoryBoard.CurrentCell.ColumnIndex
                    Case CInt(Request.Is_kit)
                        Call FillListBox()

                        'Case CInt(Request.prod_category)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.item_color).Selected = True


                        'Case CInt(Request.item_color)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.DEC_MET_DESC).Selected = True
                        'Case CInt(Request.DEC_MET_DESC)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.IMP_DESCRIPTION).Selected = True
                        'Case CInt(Request.IMP_DESCRIPTION)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.Patch_Shape).Selected = True
                        'Case CInt(Request.Patch_Shape)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.Patch_Color).Selected = True
                        'Case CInt(Request.Patch_Color)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.Thread_Color).Selected = True
                        'Case CInt(Request.Thread_Color)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.BackGround_Color).Selected = True
                        'Case CInt(Request.BackGround_Color)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.StampingPattern).Selected = True
                        'Case CInt(Request.StampingPattern)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_COLOR).Selected = True
                        'Case CInt(Request.IMPRINT_COLOR)
                        '    dgvStoryBoard.CurrentRow.Cells(Request.IMPRINT_LOGO).Selected = True
                        'Case CInt(Request.IMPRINT_LOGO)
                        '    btnAddLine.Focus()
                End Select




            End If
            e.SuppressKeyPress = True 'this will prevent ding sound 
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillListBox()
        Try
            oMdb_Item_master = New cMdb_Item_Master

            olstMaster = New List(Of cMdb_Item_Master)
            olstVariantColor = New List(Of cMdb_Item_VariantColor)

            '---------------- fill listbox with probabily item code ------------------
            olstMaster = oMdb_Item_master.LoadMasterCd_List(Trim(dgvStoryBoard.CurrentRow.Cells(Request.item_cd).Value))

            '1.08.2018
            lststyleCurrentRow = dgvStoryBoard.CurrentRow.Index

            Debug.Print(Trim(dgvStoryBoard.CurrentRow.Cells(Request.item_cd).Value))
            If olstMaster.Count = 0 Then Exit Sub
            If olstMaster.Count = 1 Then
                '  lstIStyle.TopIndex = 1
                Call Fill_GridLine_LstBox(lststyleCurrentRow)
                Exit Sub
            End If

            lstIStyle.Items.Clear()

            With lstIStyle
                .DisplayMember = "Item_Cd"
                .ValueMember = "Item_Master_Id"
            End With

            'sort list by 
            olstMaster = olstMaster.OrderBy(Function(i As cMdb_Item_Master) i.Item_Cd).ToList

            For Each oItem As cMdb_Item_Master In olstMaster
                lstIStyle.Items.Add(oItem)   ' add to list of item colors
            Next


            lstIStyle.Visible = True
            lstIStyle.Height = dgvStoryBoard.Height
            lstIStyle.Focus()
            lstIStyle.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtbtnSave_Click(sender As Object, e As EventArgs) Handles txtbtnSave.Click
        Try
            Dim respons As String = ""
            'function added for validate certaine label in in storyboard grid 
            If ValidateDecoProperties(respons) <> True Then
                If respons.Length > 0 Then
                    'message need to be revised
                    '      MsgBox(respons)

                    Dim result1 As DialogResult = MessageBox.Show(respons & vbCrLf & " --- REQUEST IS NOT SAVED!!! ---",
            "--- REQUEST IS NOT SAVED!!! ---",
            MessageBoxButtons.OK,
            MessageBoxIcon.Hand,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly,
            False)


                    Exit Sub
                End If
            Else
                Call SaveRequest()
            End If
            '-------------------------



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveRequest(Optional ByVal pStatus As Integer = -1)
        Try

            '++ID 4.12.2018 
            Select Case oExact_Traveler_Permission.perm_group_id
                Case 182 'Gr 182 
                    'limit save for graphic depart, only documents and comunication
                    Call DocumentsAddDB()
                    Call RetriveCommentsAddInDB()

                    Select Case pStatus
                'for now by status is in comment
                        Case ReqCFGStatus.Completed 'ReqCFGStatus.Pending, ReqCFGStatus.InWork, ReqCFGStatus.Processed, ReqCFGStatus.Completed, ReqCFGStatus.Reopen

                            Call SendEmail_ByStatus(pStatus) 'CInt(ReqCFGStatus.Completed))
                            ' Call SendEmail_ByStatus(pStatus)
                        Case Else
                            'pStatus
                            Call SendEmail_ByStatus(CInt(lblTextStatusInfo.Tag))
                    End Select

                Case Else

                    Call ReviewUpdate()

                    Call AddCustomerDetail()

                    Call DocumentsAddDB()

                    Call RretriveInfoFromItemListDGV()

                    Call SaveRequestItem_AdditionalLocation()

                    Call SaveRequest_DocBindItem()

                    Call RetriveCommentsAddInDB()

                    If chkSendToGraphic.CheckState = CheckState.Checked Then
                        'Call SendEmail()
                        Call SendEmailNewDisplay()
                    Else
                        Dim result As DialogResult

                        result = MessageBox.Show("CheckBox send email was not checked and request will not be send to the Graphic Department." & vbCrLf &
                           "Click - YES - Email will be sent. ", " Email Alert !!!", MessageBoxButtons.YesNoCancel)

                        Select Case result
                            Case DialogResult.Cancel
                                MsgBox("Email for Graphic Departmet was not sent.")
                                Exit Sub
                            Case DialogResult.No
                                MsgBox("Email for Graphic Departmet was not sent.")
                                Exit Sub
                            Case DialogResult.Yes
                                chkSendToGraphic.CheckState = CheckState.Checked
                                'Call SendEmail()

                                Call SendEmailNewDisplay()
                        End Select
                    End If


            End Select




            '----------------------

            MsgBox("Request No : " & xtxtReqItemCode.Text & " was saved.")

            txtCustomer.Focus()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtbtnDelete_Click(sender As Object, e As EventArgs) Handles txtbtnDelete.Click
        Try
            'delete definetly 
            'if RequestId Have more Review delete only all which include this review 
            'if is only one request with review delete all what include this review
            Dim strQuery As String = ""
            Dim strSql As String = ""
            Dim result As DialogResult

            varDelete = False

            result = MessageBox.Show("You want delete - Request No: " & RequestID & " with Review No: " & ReviewId, "Delete Alert !!! Make your choose.",
                                             MessageBoxButtons.YesNoCancel)
            Select Case result
                Case DialogResult.Cancel
                    txtCustomer.Focus()
                    Exit Sub
                Case DialogResult.No
                    txtCustomer.Focus()
                    Exit Sub
                Case DialogResult.Yes
                    Dim RepeatResult As DialogResult
                    RepeatResult = MessageBox.Show("If request have more review, only that review will be deleted definitely or all in the case if is only one.", " Alert !!!", MessageBoxButtons.OKCancel)

                    Select Case RepeatResult
                        Case DialogResult.Cancel
                            Exit Select
                        Case DialogResult.OK

                            varDelete = True
                            '---------------------------- Delete cReq_Customer_Detail --------------------------------
                            oReq_Cust_Det = New cReq_Customer_Detail

                            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
                            If oReq_Cust_Det.Load(strQuery) = True Then
                                oReq_Cust_Det.Delete()
                            End If
                            '--------------------------- Deleted Customer Detail ------------------------------------

                            'delete with RequestId And ReviewId because more communication can have same requestId with ReviewId only Communication Id is diferent
                            '---------------------------- Delete in cReqCommunication --------------------------------
                            oReqCommunic = New cReqCommunication
                            olstReqCommunic = New List(Of cReqCommunication)

                            strQuery = " WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId
                            olstReqCommunic = oReqCommunic.LoadLst(strQuery)

                            If olstReqCommunic.Count <> 0 Then
                                For Each comm As cReqCommunication In olstReqCommunic
                                    oReqCommunic.Delete(comm.CommId)
                                Next
                            End If
                            '-------------------------- Deleted all Communication ------------------------------------
                            '----------------- Delete ReqBindDocItem  for existing Items -------------------------

                            Try
                                'check if list (of object ) is not empty
                                If Not olstReqDocBindItem Is Nothing Then
                                    If olstReqDocBindItem.Count <> 0 Then
                                        For Each reqDoc As cReqDocBindItem In olstReqDocBindItem
                                            If reqDoc.BindId <> 0 Then
                                                oReqDocBindItem = New cReqDocBindItem

                                                oReqDocBindItem.DocId = reqDoc.BindId
                                                oReqDocBindItem.Delete(reqDoc)
                                            End If

                                        Next
                                    End If
                                End If



                            Catch ex As Exception
                                MsgBox("Error in " & Me.Name & ". Delete ReqBindDocItem ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                            End Try

                            '----------------- End Function for Delete ReqBindDocItem ----------------------------
                            '-------------------------- Delete cMdb_Item_Doc -----------------------------------------
                            oMdb_Item_Doc = New cMdb_Item_Doc
                            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)

                            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
                            olstMdb_Item_Doc = oMdb_Item_Doc.LoadList(strQuery)

                            If olstMdb_Item_Doc.Count <> 0 Then
                                For Each doc As cMdb_Item_Doc In olstMdb_Item_Doc
                                    oMdb_Item_Doc.Delete(doc.Item_Doc_Id)
                                Next
                            End If
                            '--------------------------- Deleted all Documents ---------------------------------------
                            '----------------------- Delete in cReqItems_AdditLocation -------------------------------
                            Try

                                oReqItems_AdditDetail = New cReqItems_AdditLocation
                                olstReItems_AdditDetail = New List(Of cReqItems_AdditLocation)

                                strSql = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqItems_AdditLocation ra WITH (Nolock) on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " and ReviewId = " & ReviewId & ""

                                olstReItems_AdditDetail = oReqItems_AdditDetail.LoadLst(strSql)

                                If Not olstReItems_AdditDetail Is Nothing Then

                                    For Each reqAddDet As cReqItems_AdditLocation In olstReItems_AdditDetail
                                        oReqItems_AdditDetail = New cReqItems_AdditLocation

                                        oReqItems_AdditDetail.Delete(reqAddDet)
                                    Next

                                End If
                            Catch ex As Exception
                                MsgBox("Error in " & Me.Name & ". Delete ReqBindDocItem ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)

                            End Try
                            '----------------- Deleted all Additional Location for existing Items --------------------

                            '--------------------------- Delete cReqItems --------------------------------------------
                            oReqItems = New cReqItems
                            olstReqItems = New List(Of cReqItems)

                            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
                            olstReqItems = oReqItems.LoadLst(strQuery)

                            If olstReqItems.Count <> 0 Then
                                For Each item As cReqItems In olstReqItems
                                    oReqItems.Delete(item.ReqItemId)
                                Next
                            End If
                            '--------------------------- Deleted all Items -------------------------------------------
                            '--------------------------- Delete cReqSentMails ----------------------------------------

                            oReqSentMail = New cReqSentMails
                            olstReqSentMails = New List(Of cReqSentMails)

                            strQuery = " where  requestId = " & RequestID & " and reviewId = " & ReviewId
                            olstReqSentMails = oReqSentMail.LoadLst(strSql)

                            If olstReqSentMails IsNot Nothing Then

                                For Each item As cReqSentMails In olstReqSentMails
                                    item.Delete(item)
                                Next

                            End If

                            '--------- Deleted all ReqSentMails for this RequestId and ReviewId ----------------------
                            '--------------------------- Delete cReqStatus -------------------------------------------
                            oReqStatus = New cReqStatus
                            olstReqStatus = New List(Of cReqStatus)

                            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
                            olstReqStatus = oReqStatus.LoadLst(strQuery)

                            If olstReqStatus.Count <> 0 Then
                                For Each status As cReqStatus In olstReqStatus
                                    oReqStatus.Delete(status.ID)
                                Next
                            End If
                            '--------------------------- Deleted all Status -----------------------------------------
                            '--------------------------- Delete cReqRevision and if is a case delete cRequest
                            oReqRevision = New cReqRevision
                            olstReqRevision = New List(Of cReqRevision)

                            strQuery = " WHERE RequestId = " & RequestID
                            'this line is did because we need know how many review has the request
                            'if we have more than one -> request will not be deleted.
                            'only in the case if count review is only one(1) request will be deleted  
                            olstReqRevision = oReqRevision.LoadLst(strQuery)

                            If olstReqRevision.Count <> 0 Then
                                oReqRevision.Delete(ReviewId)
                            End If


                            If olstReqRevision.Count <= 1 Then
                                oRequests = New cRequests
                                oRequests.Delete(RequestID)
                            End If

                            'maybe need load show forms whit listview
                            Me.Close()

                    End Select
            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtbtnStatus_Click(sender As Object, e As EventArgs) Handles txtbtnStatus.Click
        Try

            oReqStatus = New cReqStatus
            olstReqStatus = New List(Of cReqStatus)
            Dim strQuery As String = " WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqStatus = oReqStatus.LoadLst(strQuery)

            Call ClickTopButton(CInt(txtbtnStatus.Tag), CInt(olstReqStatus.Find(Function(i As cReqStatus) i.Active = True).StatusId))
            txtCustomer.Focus()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtbtnNew_Click(sender As Object, e As EventArgs) Handles txtbtnNew.Click
        Try
            Dim result = MessageBox.Show("You want reopen - Request No: " & RequestID & " with Review No: " & ReviewId, " Create Revision.",
                                         MessageBoxButtons.YesNoCancel)
            Select Case result
                Case DialogResult.Cancel
                    txtCustomer.Focus()
                    Exit Sub
                Case DialogResult.No
                    txtCustomer.Focus()
                    Exit Sub
                Case DialogResult.Yes
                    Call ClickTopButton(CInt(txtbtnNew.Tag), CInt(lblTextStatusInfo.Tag))
                    txtCustomer.Focus()
            End Select



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "---------------------------- Load New Form Private Function, Methods,Label & Buttons in the Top -------------------------------------"
    'main function which take all what we need for load new request
    Private Sub loadNew_Story()
        Try
            Dim strSql As String
            'rename and asigne id for reopen button
            txtbtnNew.Text = ReqCFGStatus.Reopen.ToString
            txtbtnNew.Tag = ReqCFGStatus.Reopen
            '-------------------------------------
            oRequests = New cRequests
            oReqRevision = New cReqRevision
            oReqStatus = New cReqStatus
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            olstRequests = New List(Of cRequests)
            olstReqRevision = New List(Of cReqRevision)
            olstReqStatus = New List(Of cReqStatus)
            olstExact_Traveler_Permission = New List(Of cExact_Traveler_Permission)

            '-------------------------- cRequests ----------------------------------------------
            oRequests.Load(RequestID)

            'Select Case oRequests.TypeID
            '    Case 22 'from this table MDB_CFG_ITEM_DOC_TYPE
            Me.Text = Trim(olstMdb_Cfg_Item_Doc_Type.Find(Function(i As cMdb_Cfg_Item_Doc_Type) i.Item_Doc_Type_Id = oRequests.TypeID).Doc_Type)

            'specify request name and in the tag put TypeId
            pReqType = Trim(olstMdb_Cfg_Item_Doc_Type.Find(Function(i As cMdb_Cfg_Item_Doc_Type) i.Item_Doc_Type_Id = oRequests.TypeID).Doc_Type)

            lblStoryBoard.Text = pReqType & " - "
            lblStoryBoard.Tag = oRequests.TypeID
            ' "Storyboard Request"
            '  End Select

            'add number storyboard
            ' &= Trim(oRequests.ItemCode)

            '++ID 4.15.2020 added label for inform CSR 
            'If oRequests.TypeID = 23 Then
            '    lblCovid19.Visible = True
            'End If



            lblFullName.Text = oRequests.CreateByFullName
            lblCreateDate.Text = oRequests.CreateDate.ToString("dd-MM-yyyy HH:mm")

            '-------------------------- cReqRevision --------------------------------------------
            'is enough reqId with revId because is new storyb.. and always neew is 0
            'means like need to be only one line
            strSql = " WHERE  ReviewId = " & ReviewId & " order by ReviewId desc "
            oReqRevision.Load(strSql)

            chkRushOrder.Checked = oReqRevision.Rush_Order
            lblRevNo.Text = oReqRevision.Rev_Cpt
            xtxtReqItemCode.Text = oReqRevision.RevItemCd
            '------------------------------ cReqStatus ----------------------------------------

            Call EditActualStatusTopAndMiddle()

            oReqStatus = New cReqStatus
            oReqStatus.Load(RequestID, ReviewId)

            Call CheckTopButton(oReqStatus.StatusId)

            '----------------------------- Creq_Customer_Detail ------------------------------

            Call Display_Customer()


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'move label in the middle form which show staus , full name who changed and date changed.
    Private Sub LabelPositionInMiddle()
        Try
            lblCreate.Location = New Point(5, 5)
            lblFullName.Location = New Point(5, 22)
            lblCreateDate.Location = New Point(5, 36)

            lblApprove.Location = New Point(96, 5)
            lblFNameApprove.Location = New Point(96, 22)
            lblAppr3field.Location = New Point(96, 36)

            lblRealise.Location = New Point(187, 5)
            lblFNRealise.Location = New Point(187, 22)
            lblDateRealise.Location = New Point(187, 36)

            lblProcess.Location = New Point(278, 5)
            lblFNameProcess.Location = New Point(278, 22)
            lblDateProcess.Location = New Point(278, 36)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'always when status is changed need recuperate and populate in the top status label with user name
    Private Sub EditActualStatusTopAndMiddle()
        Try
            oReqStatus = New cReqStatus
            olstReqStatus = New List(Of cReqStatus)

            olstReqStatus = oReqStatus.LoadLst(RequestID, ReviewId)

            For Each oRS As cReqStatus In olstReqStatus

                Select Case oRS.StatusId
                    Case ReqCFGStatus.Pending
                        'With lblTextStatusInfo
                        '    .Text = "Status : " & DirectCast([Enum].Parse(GetType(ReqCFGStatus), oRS.StatusId), ReqCFGStatus).ToString
                        '    .Tag = oRS.StatusId
                        'End With
                        lblStatusModifiedBy.Text = "Modified by : " & oRS.CreateByFullName & " " & oRS.CreateDate.ToString("dd-MM-yyyy HH:mm")
                    Case ReqCFGStatus.InWork
                        'show info about who took the work
                        With lblApprove
                            .Text = DirectCast([Enum].Parse(GetType(ReqCFGStatus), oRS.StatusId), ReqCFGStatus).ToString
                            .Tag = oRS.StatusId
                        End With
                        lblFNameApprove.Text = oRS.CreateByFullName
                        lblAppr3field.Text = oRS.CreateDate.ToString("dd-MM-yyyy HH:mm")
                    Case ReqCFGStatus.Completed
                        With lblRealise
                            .Text = DirectCast([Enum].Parse(GetType(ReqCFGStatus), oRS.StatusId), ReqCFGStatus).ToString
                            .Tag = oRS.StatusId
                        End With
                        lblFNRealise.Text = oRS.CreateByFullName
                        lblDateRealise.Text = oRS.CreateDate.ToString("dd-MM-yyyy HH:mm")
                    Case ReqCFGStatus.Processed
                        With lblProcess
                            .Text = DirectCast([Enum].Parse(GetType(ReqCFGStatus), oRS.StatusId), ReqCFGStatus).ToString
                            .Tag = oRS.StatusId
                        End With
                        lblFNameProcess.Text = oRS.CreateByFullName
                        lblDateProcess.Text = oRS.CreateDate.ToString("dd-MM-yyyy HH:mm")
                    Case ReqCFGStatus.Reopen
                        'With lblTextStatusInfo
                        '    .Text = "Status : " & DirectCast([Enum].Parse(GetType(ReqCFGStatus), oRS.StatusId), ReqCFGStatus).ToString
                        '    .Tag = oRS.StatusId
                        'End With
                        lblStatusModifiedBy.Text = "Modified by : " & oRS.CreateByFullName & " " & oRS.CreateDate.ToString("dd-MM-yyyy HH:mm")
                End Select
            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'this sub is call only in the load function for identify status and rename button Status
    Private Sub CheckTopButton(p_statusId As Integer)
        Try
            'oRequestStatusT = New cRequestStatusT
            'olstRequestStatusT = New List(Of cRequestStatusT)
            'olstRequestStatusT = oRequestStatusT.LoadLst
            oExact_Traveler_Permission = New cExact_Traveler_Permission
            Dim rev_cpt As Integer = 0
            Dim strSql As String = String.Empty

            'retrive request status and change button text
            Select Case p_statusId
                Case ReqCFGStatus.Pending
                    'next step after Open
                    '---------------------- cRequestStatusT -------------------------
                    '    oRequestStatusT.Load(RequestStatus.Approved)
                    With txtbtnStatus
                        .Text = ReqCFGStatus.InWork.ToString
                        .Tag = ReqCFGStatus.InWork

                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select

                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).ID
                    End With
                    lblTextStatusInfo.Tag = ReqCFGStatus.Pending
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Pending.ToString
                    '------------------------------------------------
                Case ReqCFGStatus.InWork 'Accepted by person who click

                    With txtbtnStatus
                        .Text = ReqCFGStatus.Completed.ToString
                        .Tag = ReqCFGStatus.Completed
                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select
                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Realized).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Realized).ID
                    End With
                    lblTextStatusInfo.Tag = ReqCFGStatus.InWork
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.InWork.ToString

                Case ReqCFGStatus.Completed
                    With txtbtnStatus
                        .Text = ReqCFGStatus.Processed.ToString
                        .Tag = ReqCFGStatus.Processed
                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select
                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Processed).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Processed).ID

                        .Enabled = False
                    End With
                    'when we will click on the reopen button status for txtbtnStatus it will be changed in Approved + will be created new version 
                    ' + txtbtnNew.visible = false
                    txtbtnNew.Visible = True
                    lblTextStatusInfo.Tag = ReqCFGStatus.Completed
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Completed.ToString
                Case ReqCFGStatus.Processed


                Case ReqCFGStatus.Reopen 'create new review version

                    With txtbtnStatus
                        .Text = ReqCFGStatus.InWork.ToString
                        .Tag = ReqCFGStatus.InWork
                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select
                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).ID
                    End With

                    lblTextStatusInfo.Tag = ReqCFGStatus.Pending
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Pending.ToString

            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'make insert and update status , is executed only in run time 
    Private Sub ClickTopButton(p_statusId As Integer, p_intActiveStatus As Integer)
        Try
            'oRequestStatusT = New cRequestStatusT
            'olstRequestStatusT = New List(Of cRequestStatusT)
            'olstRequestStatusT = oRequestStatusT.LoadLst

            Dim rev_cpt As Integer = 0
            Dim strSql As String = String.Empty

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            'retrive request status and change button text
            Select Case p_statusId
                Case ReqCFGStatus.Pending

                    'next step after Open
                    '---------------------- cRequestStatusT -------------------------
                    '    oRequestStatusT.Load(RequestStatus.Approved)

                    With txtbtnStatus
                        .Text = ReqCFGStatus.InWork.ToString
                        .Tag = ReqCFGStatus.InWork

                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select
                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).ID
                    End With

                    'save request after changed status
                    '   Call SaveRequest(ReqCFGStatus.Pending)

                    lblTextStatusInfo.Tag = ReqCFGStatus.Pending
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Pending.ToString

                    p_statusId = ReqCFGStatus.Pending
                    '------------------------------------------------
                Case ReqCFGStatus.InWork 'Accepted by person who click

                    Call changeReqStatusDB(p_intActiveStatus, 0)

                    p_statusId = ReqCFGStatus.InWork

                    'insert changed status in DB
                    Call changeReqStatusDB(p_statusId, 1)

                    With txtbtnStatus
                        .Text = ReqCFGStatus.Completed.ToString
                        .Tag = ReqCFGStatus.Completed

                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select

                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Realized).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Realized).ID
                    End With
                    lblTextStatusInfo.Tag = ReqCFGStatus.InWork
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.InWork.ToString
                    'save request after changed status
                    '  Call SaveRequest(ReqCFGStatus.InWork)

                Case ReqCFGStatus.Completed

                    Call changeReqStatusDB(p_intActiveStatus, 0)

                    p_statusId = ReqCFGStatus.Completed

                    'insert changed status in DB
                    Call changeReqStatusDB(p_statusId, 1)

                    With txtbtnStatus
                        .Text = ReqCFGStatus.Processed.ToString
                        .Tag = ReqCFGStatus.Processed

                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select

                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Processed).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Processed).ID

                        .Enabled = False
                    End With
                    'when we will click on the reopen button status for txtbtnStatus it will be changed in Approved + will be created new version 
                    ' + txtbtnNew.visible = false
                    txtbtnNew.Visible = True

                    lblTextStatusInfo.Tag = ReqCFGStatus.Completed
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Completed.ToString

                    'save request after changed status
                    Call SaveRequest(ReqCFGStatus.Completed)

                Case ReqCFGStatus.Processed 'is only for display the properties but never is clickable


                Case ReqCFGStatus.Reopen 'create new review version
                    ' when we reopen the request old request always stop to completes = 3 and active 1
                    'because this is condition for to be displayed in view
                    '    Call changeReqStatusDB(p_intActiveStatus, 0)


                    '-------- Select before Request Origin -----------------
                    Dim strOrigin As String = String.Empty
                    Dim oldReqRevision As Int32 = 0


                    Dim frmReqOrigin As New frmOrigin
                    frmReqOrigin.ShowDialog()

                    If frmReqOrigin.DialogResult = DialogResult.Yes Then
                        strOrigin = frmReqOrigin.Requiest_Original
                    Else
                        MsgBox("Is mandatory to choose request origin.")
                        Exit Sub
                    End If
                    '--------------------------------------------------------

                    p_statusId = ReqCFGStatus.Reopen

                    'need enter record for create another review it's existing + 1
                    'also need add record in the ReqStatus like with new ReviewID + new status

                    'not displaied Reopen becuase is  fallin Pending 
                    lblTextStatusInfo.Tag = ReqCFGStatus.Pending
                    lblTextStatusInfo.Text = Status & ReqCFGStatus.Pending.ToString


                    oReqRevision = New cReqRevision
                    olstReqRevision = New List(Of cReqRevision)

                    Dim strQuery As String = " WHERE RequestId = " & RequestID

                    olstReqRevision = oReqRevision.LoadLst(strQuery)
                    rev_cpt = olstReqRevision.Max(Function(i As cReqRevision) i.Rev_Cpt) + 1

                    With oReqRevision
                        'never update for revision only new
                        .RequestId = RequestID
                        .Rev_Cpt = rev_cpt
                        .Rush_Order = chkRushOrder.CheckState
                        .Origin = strOrigin
                        'Create properties are filled in the class public property
                        '.CreateBy =oExact_Traveler_Permission.ID  ' take employee_id
                        '.CreateByFullName = oExact_Traveler_Permission.Fullname
                        '.CreateDate = DateNow()
                    End With

                    'if review is saved  
                    If oReqRevision.Save() = True Then
                        'now need retrive review Id for add in ReqStatus
                        'in this case we have only one revision
                        'don't need identify revision count because for now is 0

                        strSql = " Where rev_cpt= " & rev_cpt & " and RequestId = " & RequestID & " order by ReviewId desc"

                        If oReqRevision.Load(strSql) = False Then
                            MsgBox("Can't find request ID :" & RequestID & " . Added time : " & DateNow().ToString("dd-MM-yyyy HH:mm"))
                            Exit Sub
                        End If
                    End If
                    'use variable for take copy from that revision
                    oldReqRevision = ReviewId
                    '---------------------------------------------
                    ReviewId = oReqRevision.ReviewID
                    lblRevNo.Text = "Rev.No: " & oReqRevision.Rev_Cpt

                    '---------------------Add ItemCode in request------------------------------
                    'TypeId + requestId + reviewId + Rev_Cpt

                    oReqRevision.RevItemCd = Trim(oRequests.TypeID.ToString & "." & RequestID.ToString & "." & ReviewId.ToString & "." & oReqRevision.Rev_Cpt.ToString)
                    oReqRevision.Save()

                    xtxtReqItemCode.Text = Trim(oRequests.TypeID.ToString & "." & RequestID.ToString & "." & ReviewId.ToString & "." & oReqRevision.Rev_Cpt.ToString)
                    '---------------------------------------------------

                    Call changeReqStatusDB(p_statusId, 1)

                    With txtbtnStatus
                        .Text = ReqCFGStatus.InWork.ToString
                        .Tag = ReqCFGStatus.InWork
                        Select Case oExact_Traveler_Permission.perm_group_id
                            Case 179, 182 'IT 179,Graphics 182
                                .Enabled = True
                            Case Else
                                .Enabled = False
                        End Select
                        '.Text = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).Description
                        '.Tag = olstRequestStatusT.Find(Function(i As cRequestStatusT) i.ID = RequestStatus.Approved).ID
                    End With
                    txtbtnNew.Visible = False
                    '----------------Save all data with new revision number--------------------------

                    Call ReviewUpdate()

                    Call AddCustomerDetail()

                    Call DocumentsAddDB()

                    Call RretriveInfoFromItemListDGV()

                    '---------------------------------------

                    Try
                        '1.31.2018
                        'if  olstReItems_AdditDetail is nothing by pas that exception for add additional location for the items
                        If Not olstReItems_AdditDetail Is Nothing Then

                            If olstReItems_AdditDetail.Count <> 0 Then

                                Dim oReqItems_AdditLocation_Save As cReqItems_AdditLocation

                                oReqItems_AdditLocation_Save = New cReqItems_AdditLocation

                                oReqItems = New cReqItems()
                                olstReqItems = New List(Of cReqItems)
                                strSql = " WHERE  RequestId = " & RequestID & " " & " And reviewId = " & ReviewId

                                'all items form reqItems table
                                olstReqItems = oReqItems.LoadLst(strSql)

                                If Not olstReqItems Is Nothing Then

                                    'After what ReqItemId was inserted for the new additlocation 
                                    'can save or update in DB
                                    Dim g As Guid
                                    '  g = Guid.NewGuid()

                                    'we have additDetail from old review and need make copy for new reopen review
                                    'now Request Items already are saved, from old additDetail need take ReqItemId for connect with new copied line from old ReqItems
                                    For Each addLocSave As cReqItems_AdditLocation In olstReItems_AdditDetail
                                        addLocSave.Additional_ID = 0
                                        'search in olstReqItems with  original additDet reqItemGuid and identify ReqItemId 
                                        'returned ReqItemId os newest Id from copied line
                                        addLocSave.ReqItemId = olstReqItems.Find(Function(i As cReqItems) i.GUID = addLocSave.ReqItemGuid).ReqItemId
                                        g = Guid.NewGuid()
                                        addLocSave.GUID = g.ToString
                                        addLocSave.Save(addLocSave)
                                    Next

                                    'Recharge the global olstReItems_AdditDetail
                                    oReqItems_AdditDetail = New cReqItems_AdditLocation
                                    olstReItems_AdditDetail = New List(Of cReqItems_AdditLocation)

                                    strSql = "Select ra.* from ReqItems r With (Nolock)  inner join ReqItems_AdditLocation ra With (Nolock) On r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " And ReviewId = " & ReviewId & ""

                                    olstReItems_AdditDetail = oReqItems_AdditDetail.LoadLst(strSql)

                                End If ' If Not olstReqItems Is Nothing Then

                            End If ' If olstReItems_AdditDetail.Count <> 0 Then

                        End If ' If Not olstReItems_AdditDetail Is Nothing Then

                    Catch ex As Exception
                        MsgBox("Error In " & Me.Name & ".Copy olstReItems_AdditDetail. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try

                    'make copy from ReqDocBindItem

                    Try
                        'System.Guid.NewGuid.ToString()
                        If Not olstReqDocBindItem Is Nothing Then

                            If olstReqDocBindItem.Count <> 0 Then
                                'load all documetns for reopen request
                                Dim oMdb_Doc As New cMdb_Item_Doc
                                Dim olstMdb_Doc As New List(Of cMdb_Item_Doc)
                                olstMdb_Doc = oMdb_Doc.LoadList(" where RequestId = " & RequestID & " And reviewId = " & ReviewId)

                                'need identify how it was assigned old document by item
                                'need make comparation, by binary file
                                Dim oMdb_Doc_Old As New cMdb_Item_Doc
                                Dim olstMdb_Doc_Old As New List(Of cMdb_Item_Doc)
                                olstMdb_Doc_Old = oMdb_Doc_Old.LoadList(" where RequestId = " & RequestID)

                                Dim strDocname As String = ""
                                Dim docByte As Byte() = Nothing

                                oReqItems = New cReqItems()
                                olstReqItems = New List(Of cReqItems)
                                strSql = " WHERE  RequestId = " & RequestID & " " & " And reviewId = " & ReviewId

                                'all items form reqItems table
                                olstReqItems = oReqItems.LoadLst(strSql)

                                If Not olstReqItems Is Nothing Then
                                    If olstReqItems.Count <> 0 Then

                                        For Each addDocBindSave As cReqDocBindItem In olstReqDocBindItem
                                            addDocBindSave.BindId = 0
                                            'search in olstReqItems with  original addDocBindSave reqItemGuid and identify ReqItemId 
                                            'returned ReqItemId os newest Id from copied line
                                            addDocBindSave.ReqItemId = olstReqItems.Find(Function(i As cReqItems) i.GUID = addDocBindSave.ItemGuid).ReqItemId

                                            'assign docId 
                                            'retrive label for comparate
                                            If Not olstMdb_Doc_Old Is Nothing And Not olstMdb_Doc Is Nothing Then
                                                If olstMdb_Doc_Old.Count <> 0 And olstMdb_Doc.Count <> 0 Then

                                                    strDocname = olstMdb_Doc_Old.Find(Function(c As cMdb_Item_Doc) c.Item_Doc_Id = addDocBindSave.DocId).Item_Doc_Name
                                                    docByte = olstMdb_Doc_Old.Find(Function(c As cMdb_Item_Doc) c.Item_Doc_Id = addDocBindSave.DocId).Item_Doc


                                                    addDocBindSave.DocId = olstMdb_Doc.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Name = strDocname And i.Item_Doc.Length = docByte.Length).Item_Doc_Id

                                                End If
                                            End If


                                            addDocBindSave.Guid = System.Guid.NewGuid.ToString()
                                            addDocBindSave.Save(addDocBindSave)
                                        Next

                                        'Recharge the global olstReItems_AdditDetail
                                        oReqDocBindItem = New cReqDocBindItem
                                        olstReqDocBindItem = New List(Of cReqDocBindItem)

                                        strSql = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqDocBindItem ra WITH (Nolock) " _
                                               & " On r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " And ReviewId = " & ReviewId & ""

                                        olstReqDocBindItem = oReqDocBindItem.LoadLst(strSql)

                                    End If
                                End If


                            End If

                            End If

                    Catch ex As Exception
                        MsgBox("Error In " & Me.Name & ".Make copy from ReqDocBindItem. " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try

                    '--------------------
                    'Call RetriveCommentsAddInDB()

                    Call RetriveCommentsFromCopy(oldReqRevision)

                    ''-----------------Send email ---------------------
                    '' In the SendEmail is added also saving cReqSentMails function , in the bottom of the function .
                    ''    Call SendEmail()
                    'If chkSendToGraphic.CheckState = CheckState.Checked Then
                    '    ' Call SendEmail()

                    '    Call SendEmailNewDisplay()
                    'Else
                    '    Dim result As DialogResult

                    '    result = MessageBox.Show("CheckBox for send email was not checked and request will not be send to the Graphic Department." & vbCrLf &
                    '       "Click - YES - Email will be sent. ", " Email Alert !!!", MessageBoxButtons.YesNoCancel)

                    '    Select Case result
                    '        Case DialogResult.Cancel
                    '            MsgBox("Email for Graphic Departmet was not sent.")
                    '            Exit Sub
                    '        Case DialogResult.No
                    '            MsgBox("Email for Graphic Departmet was not sent.")
                    '            Exit Sub
                    '        Case DialogResult.Yes
                    '            chkSendToGraphic.CheckState = CheckState.Checked

                    '            '  Call SendEmail()

                    '            Call SendEmailNewDisplay()
                    '    End Select
                    'End If

                    '-------------------------------------------------

                    MsgBox("Revision was created : " & xtxtReqItemCode.Text)

                    txtbtnNew.Visible = False



                    'Call InitializeComponent()
                    'Me.Refresh()
                    '   Call LoadForm()

                    Dim frmNew As frmVirtual_Request

                    frmNew = New frmVirtual_Request(RequestID, ReviewId)
                    frmNew.Show()


                    Me.Close()

            End Select

            'chang display for actual activ status
            Call EditActualStatusTopAndMiddle()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'modify status
    Private Function changeReqStatusDB(p_statusId As Integer, p_Active As Boolean)
        changeReqStatusDB = False
        Try
            oReqStatus = New cReqStatus
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            With oReqStatus
                'always when is new take this satatus
                .RequestId = RequestID
                .ReviewId = ReviewId
                .StatusId = p_statusId
                .Active = p_Active
            End With

            If oReqStatus.Save <> True Then MsgBox(" Problem!!! Status is not changed.")

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region

#Region "---------------------------- Work & Save Customer Detail --------------------------------"
    Private Sub AddCustomerDetail()
        Try

            oReq_Cust_Det = New cReq_Customer_Detail

            With oReq_Cust_Det
                .cmp_wwn = Trim(lblCustomerName.Tag)
                .cnt_id = Trim(lnkLblContactShow.Tag)

                .RequestId = RequestID
                .ReviewID = ReviewId
            End With

            If oReq_Cust_Det.Save <> True Then
                MsgBox("Can't save cmp_wwn:" & Trim(lblCustomerName.Tag) & " with cnt_id:" & Trim(lnkLblContactShow.Tag) _
                       & " . Work time : " & DateNow().ToString("dd-MM-yyyy HH:mm") & " .RequestId: " & RequestID & ",ReviewId:" & ReviewId & ".")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Display_Customer()
        Try
            Dim strSql As String
            strSql = " where  RequestId = " & RequestID & " And ReviewId = " & ReviewId
            oReq_Cust_Det = New cReq_Customer_Detail(strSql)
            olstReq_Cust_Det = New List(Of cReq_Customer_Detail)

            olsCicmpy = New List(Of cCicmpy)
            oCicmpy = New cCicmpy

            olsCicntpReq = New List(Of cCicntpReq)
            oCicntpReq = New cCicntpReq

            If oReq_Cust_Det.cmp_wwn = "" Then Exit Sub

            oCicmpy.Load(oReq_Cust_Det.cmp_wwn)

            txtCustomer.Text = Trim(oCicmpy.CMP_CODE)
            lblCustomerName.Text = Trim(oCicmpy.CMP_NAME)
            lblCustomerName.Tag = Trim(oReq_Cust_Det.cmp_wwn)

            oCicntpReq.Load(oReq_Cust_Det.cnt_id)

            lnkLblContactShow.Text = Trim(oCicntpReq.FULLNAME)
            lnkLblContactShow.Tag = oReq_Cust_Det.cnt_id
            lblContactEmail.Text = Trim(oCicntpReq.CNT_EMAIL)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "---------------------------- Work & Save Attacment --------------------------------"
    Public Sub Add_Attacments()
        Try
            oMdb_Item_Doc = New cMdb_Item_Doc
            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)

            'before I need find all lnkLabel from two panel and recuperate filename and other information what I need for save 




        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Display_Attachments()
        Try

            'I can use this function 
            ' put all from database, filename, bytes, formatbytes(Bytes)
            '  Call Add_DinamicLinkLabel(pan1DocStok, strFilename, ByteIcon, FormatBytes(myFile.Length))
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'function for save documents in db from panel
    Private Function DocumentsAddDB() As Boolean
        DocumentsAddDB = False
        Try
            Dim strQuery As String
            Dim lblLink As xLinkLabel = Nothing
            Dim lbl As Label = Nothing
            oMdb_Item_Doc = New cMdb_Item_Doc
            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)

            For Each ctrl As Control In grpAdditDetail.Controls

                'search panel 1 & 2
                If TypeOf ctrl Is Panel Then

                    If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        'check teh panel
                        For Each pan As Control In ctrl.Controls
                            'find linklabel with id from label

                            If TypeOf pan Is xLinkLabel Then
                                lblLink = pan
                                'init onject                                '
                                oMdb_Item_Doc = New cMdb_Item_Doc
                                'fill data
                                oMdb_Item_Doc.Item_Doc_Id = CInt(lblLink.TagId)

                                '++ID 7.12.2018 validate interog. markup
                                oMdb_Item_Doc.Item_Doc_Name = lblLink.TagName.Replace("?", "")

                                oMdb_Item_Doc.Item_Doc_Type_Id = CInt(lblStoryBoard.Tag)

                                oMdb_Item_Doc.RequestId = RequestID
                                oMdb_Item_Doc.ReviewId = ReviewId
                                'containe guid we need identify object when is added and is saved but form is not refreshed 
                                oMdb_Item_Doc.Req_Guid = lblLink.Tag.ToString

                                oMdb_Item_Doc.Item_Doc_File_Ext = lblLink.TagExtention
                                oMdb_Item_Doc.Item_Doc = lblLink.TagByte
                                'don't need update existing documents, we can only add and remove documents
                                ' If lblLink.TagId = 0 Then
                                olstMdb_Item_Doc.Add(oMdb_Item_Doc)

                                ' End If
                            End If
                        Next '  For Each pan As Control In ctrl.Controls

                    End If '  If (ctrl.Name = "pan1" Or ctrl.Name = "pan2") Then
                End If '  If TypeOf ctrl Is Panel Then

            Next '   For Each ctrl As Control In m_control.Controls

            '------------------------------------------------------------------------
            'Add customer original mail in list of document for save or update or by pass
            If Not xLnkOrigmail.TagByte Is Nothing Then

                oMdb_Item_Doc = New cMdb_Item_Doc
                'fill data
                oMdb_Item_Doc.Item_Doc_Id = CInt(xLnkOrigmail.TagId)
                '++ID 7.12.2018 interog markup validate
                oMdb_Item_Doc.Item_Doc_Name = xLnkOrigmail.TagPath.Replace("?", "")

                oMdb_Item_Doc.Item_Doc_Type_Id = 24 ' need add customer eail type  = 24  [MDB_CFG_ITEM_DOC_TYPE]

                oMdb_Item_Doc.RequestId = RequestID
                oMdb_Item_Doc.ReviewId = ReviewId
                'containe guid we need identify object when is added and is saved but form is not refreshed 
                oMdb_Item_Doc.Req_Guid = xLnkOrigmail.Tag.ToString

                oMdb_Item_Doc.Item_Doc_File_Ext = xLnkOrigmail.TagExtention
                oMdb_Item_Doc.Item_Doc = xLnkOrigmail.TagByte
                'don't need update existing documents, we can only add and remove documents
                ' If lblLink.TagId = 0 Then
                olstMdb_Item_Doc.Add(oMdb_Item_Doc)
            End If

            '------------------------------------------------------------------------

            Dim oMdb_Doc As New cMdb_Item_Doc
            Dim olstMdb_Doc As New List(Of cMdb_Item_Doc)

            olstMdb_Doc = oMdb_Doc.LoadList(" where RequestId = " & RequestID)

            'make copy and user for attach documents in email 
            olstMdb_Item_Doc_Attach = olstMdb_Item_Doc

            'save in DB from List(of )
            For Each doc As cMdb_Item_Doc In olstMdb_Item_Doc
                Try
                    oMdb_Item_Doc = New cMdb_Item_Doc

                    '------------------ in the case when request is reopen is created new reviewId 
                    'but if for second review reuse some doc need rewrite in DB with other iid
                    If Not olstMdb_Doc.Find(Function(i As cMdb_Item_Doc) i.Req_Guid = doc.Req_Guid And i.ReviewId = doc.ReviewId) Is Nothing Then
                        oMdb_Item_Doc.Item_Doc_Id = doc.Item_Doc_Id
                    End If
                    '------------------

                    oMdb_Item_Doc.Item_Doc_Name = doc.Item_Doc_Name.Replace("?", "")
                    oMdb_Item_Doc.Item_Doc_Type_Id = doc.Item_Doc_Type_Id
                    oMdb_Item_Doc.RequestId = doc.RequestId
                    oMdb_Item_Doc.ReviewId = doc.ReviewId
                    oMdb_Item_Doc.Item_Doc_File_Ext = doc.Item_Doc_File_Ext
                    oMdb_Item_Doc.Item_Doc = doc.Item_Doc
                    oMdb_Item_Doc.Req_Guid = doc.Req_Guid

                    'need add function for check if image exist nothig to do because we don't need update image 
                    'before delete after add

                    If oMdb_Item_Doc.Item_Doc_Id = 0 Then
                        If oMdb_Item_Doc.Save <> True Then
                            MsgBox("Document name : " & doc.Item_Doc_Name & " is not saved.")

                        Else
                            'if item_doc_id is not 0 but reviewId is diferent like in DB


                        End If

                        DocumentsAddDB = True
                    End If

                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try
            Next

            '---------------------------------------------------------------------
            oMdb_Item_Doc = New cMdb_Item_Doc
            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)

            'load all saved document for requestId and ReviewId from session


            strQuery = " WHERE requestId = " & RequestID & " and reviewId = " & ReviewId
            olstMdb_Item_Doc = oMdb_Item_Doc.LoadList(strQuery)

            'add item_doc_id for each saved document with Req_Guid 
            For Each ctrl As Control In grpAdditDetail.Controls

                'search panel 1 & 2
                If TypeOf ctrl Is Panel Then

                    If ctrl.Name = "pan1DocStok" Or ctrl.Name = "pan2DocStok" Then
                        'check teh panel
                        For Each pan As Control In ctrl.Controls
                            'find linklabel with id from label

                            If TypeOf pan Is xLinkLabel Then
                                lblLink = pan
                                If lblLink.TagId = 0 Then
                                    lblLink.TagId = olstMdb_Item_Doc.Find(Function(i As cMdb_Item_Doc) i.Req_Guid = Trim(lblLink.Tag.ToString) And i.Item_Doc_Type_Id <> 24).Item_Doc_Id
                                End If
                            End If
                        Next '  For Each pan As Control In ctrl.Controls

                    End If '  If (ctrl.Name = "pan1" Or ctrl.Name = "pan2") Then
                End If '  If TypeOf ctrl Is Panel Then

            Next '   For Each ctrl As Control In m_control.Controls
            '-----------------------------------------------------
            If Not olstMdb_Item_Doc.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Type_Id = 24) Is Nothing Then
                xLnkOrigmail.TagId = olstMdb_Item_Doc.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Type_Id = 24).Item_Doc_Id
            End If
            
            Return DocumentsAddDB

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function DisplayDocInPanel() As Boolean
        DisplayDocInPanel = False
        Try
            Dim strFile(System.Enum.GetNames(GetType(Documentlinklabel)).Length) As String
            ' Enum.GetValues(typeof(Documentlinklabel)).Cast<Documentlinklabel>().Distinct().Count()

            If RequestID = 0 Then
                Exit Function
            End If

            If ReviewId = 0 Then
                Exit Function
            End If

            oMdb_Item_Doc = New cMdb_Item_Doc
            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)
            Dim strQuery As String 'always start with ' where .....


            strQuery = " where REQUESTID = " & RequestID & " AND REVIEWID = " & ReviewId & " order by  ITEM_DOC_ID asc"
            olstMdb_Item_Doc = oMdb_Item_Doc.LoadList(strQuery)

            If olstMdb_Item_Doc.Count = 0 Then Exit Function

            For Each doc As cMdb_Item_Doc In olstMdb_Item_Doc
                If doc.Item_Doc_Type_Id <> 24 Then

                    Try
                        'oMdb_Item_Doc = New cMdb_Item_Doc
                        'oMdb_Item_Doc.Item_Doc_Name = doc.Item_Doc_Name
                        'oMdb_Item_Doc.Item_Doc_Type_Id = doc.Item_Doc_Type_Id
                        'oMdb_Item_Doc.RequestId = doc.RequestId
                        'oMdb_Item_Doc.ReviewId = doc.ReviewId
                        'oMdb_Item_Doc.Item_Doc_File_Ext = doc.Item_Doc_File_Ext
                        'oMdb_Item_Doc.Item_Doc = doc.Item_Doc

                        Debug.Print(FormatBytes(doc.Item_Doc.Length))

                        strFile(Documentlinklabel.ID) = doc.Item_Doc_Id  'now is 0(zero) becuase added from system
                        strFile(Documentlinklabel.DocTxtShow) = doc.Item_Doc_Name + "." + doc.Item_Doc_File_Ext  'abstract_color_background_picture_8016-wide.jpg
                        strFile(Documentlinklabel.DocName) = doc.Item_Doc_Name 'abstract_color_background_picture_8016-wide
                        strFile(Documentlinklabel.DocPath) = doc.Item_Doc_Name + "." + doc.Item_Doc_File_Ext 'abstract_color_background_picture_8016-wide.jpg
                        strFile(Documentlinklabel.DocExtention) = doc.Item_Doc_File_Ext  ' jpg
                        strFile(Documentlinklabel.DocGuid) = doc.Req_Guid.ToString

                        Call Add_DinamicLinkLabel(pan1DocStok, strFile, doc.Item_Doc, FormatBytes(doc.Item_Doc.Length))

                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try
                    DisplayDocInPanel = True
                Else
                    xLnkOrigmail.TagId = doc.Item_Doc_Id
                    xLnkOrigmail.TagPath = doc.Item_Doc_Name + "." + doc.Item_Doc_File_Ext
                    xLnkOrigmail.TagByte = doc.Item_Doc

                    xLnkOrigmail.TagExtention = doc.Item_Doc_File_Ext
                    xLnkOrigmail.BackColor = Color.Violet
                    xLnkOrigmail.Tag = doc.Req_Guid.ToString 'new guid each time when add mail

                End If
            Next

            Return DisplayDocInPanel
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function DocDelete(pdocId As Integer) As Boolean
        DocDelete = False
        Try
            '---------------------search and delete all line from ReqDocumBindItem if are found -----------------------------
            Try
                Dim m_BindId As Int32 = 0
                If Not olstReqDocBindItem Is Nothing Then

                    If olstReqDocBindItem.Count <> 0 Then

                        For Each docBind As cReqDocBindItem In olstReqDocBindItem
                            If docBind.DocId = pdocId Then
                                oReqDocBindItem = New cReqDocBindItem
                                oReqDocBindItem.BindId = docBind.BindId

                                oReqDocBindItem.Delete(oReqDocBindItem)
                            End If
                        Next

                        olstReqDocBindItem.RemoveAll(Function(i As cReqDocBindItem) i.DocId = pdocId)

                    End If
                End If

            Catch ex As Exception
                MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
            End Try
            '--------------------- delete function from ReqDocumBindItem -------------------------



            oMdb_Item_Doc = New cMdb_Item_Doc
            If oMdb_Item_Doc.Delete(pdocId) Then DocDelete = True

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


#End Region

#Region "---------------------------- Work & Save Items --------------------------------"
    Private Function RretriveInfoFromItemListDGV() As Boolean
        RretriveInfoFromItemListDGV = False
        Try
            Dim oReqItemsCheck As New cReqItems
            Dim olstReqItemsCheck As New List(Of cReqItems)
            Dim strQuery As String

            If dgvStoryBoard.RowCount = 0 Then Exit Function
            If dgvStoryBoard.Rows(0).Cells(Request.item_master_id).Value.ToString = "" Then
                Exit Function
            End If

            strQuery = "  where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItemsCheck = oReqItemsCheck.LoadLst(strQuery)

            '   oReqItems = New cReqItems
            olstReqItems = New List(Of cReqItems)

            For Each dgRow As DataGridViewRow In dgvStoryBoard.Rows

                oReqItems = New cReqItems

                'if is created review but line is same need put reqitemId = 0 in the dgRow.Cells(CInt(Request.x)).Tag
                '
                If olstReqItemsCheck.Count = 0 Then
                    dgRow.Cells(CInt(Request.x)).Tag = 0
                End If

                'if line was saved, in same time info was changed and saved second time
                If CInt(dgRow.Cells(CInt(Request.x)).Tag) = 0 Then

                    If Not olstReqItemsCheck.Find(Function(i As cReqItems) i.GUID = dgRow.Cells(CInt(Request.GUID)).Value.ToString) Is Nothing Then
                        dgRow.Cells(CInt(Request.x)).Tag = olstReqItemsCheck.Find(Function(i As cReqItems) i.GUID = dgRow.Cells(CInt(Request.GUID)).Value.ToString).ReqItemId
                    End If

                End If

                oReqItems.ReqItemId = CInt(dgRow.Cells(CInt(Request.x)).Tag)
                oReqItems.RequestId = RequestID
                oReqItems.ReviewId = ReviewId
                oReqItems.item_master_id = Trim(dgRow.Cells(CInt(Request.item_master_id)).Value)
                oReqItems.ItemCd = Trim(dgRow.Cells(CInt(Request.item_cd)).Value)
                oReqItems.prod_category = Trim(dgRow.Cells(CInt(Request.prod_category)).Value)
                oReqItems.Is_Kit = Trim(dgRow.Cells(CInt(Request.Is_kit)).Value)

                '++ID 02.08.2022--------------- check if it has parent and parent is mix and match item 
                Dim _mx_and_match As Boolean = False
                Try
                    Dim _item_m_id As Int32 = 0

                    If String.IsNullOrEmpty(dgRow.Cells(Request.Parent_GUID).Value) = False Then
                        For Each dgv As DataGridViewRow In dgvStoryBoard.Rows

                            If Trim(dgv.Cells(Request.GUID).Value.ToString) = Trim(dgRow.Cells(Request.Parent_GUID).Value.ToString) Then
                                _item_m_id = dgv.Cells(Request.item_master_id).Value
                            End If

                        Next
                        'check with parent item master if is mix and match
                        'variable item master will be used in below exception for to give to user possibility to change item color
                        _mx_and_match = MixAndMatch(_item_m_id)

                    End If

                Catch ex As Exception
                    MsgBox("Error check mix and match group item - " &
                       Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try
                '--------------------------------------------------------------------------------------------------------
                '----------------------- Retrive from DataGridViewComboBoxCell Color_ID ---------------------------------
                '  If (dgRow.Cells(Request.Parent_GUID).Value.ToString = "" Or dgRow.Cells(Request.Parent_GUID).Value Is Nothing) Then 'it was If dgRow.Cells(Request.Parent_GUID).Value = "" Then

                If String.IsNullOrEmpty(dgRow.Cells(Request.Parent_GUID).Value) Then 'it was If dgRow.Cells(Request.Parent_GUID).Value = "" Then

                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.item_color), dgRow.Index), DataGridViewComboBoxCell) ' 
                    oReqItems.color_id = CInt(comboboxCellrec.Value)
                    '++ID 02.08.2022
                ElseIf String.IsNullOrEmpty(dgRow.Cells(Request.Parent_GUID).Value) = False And _mx_and_match = True Then
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.item_color), dgRow.Index), DataGridViewComboBoxCell) ' 
                    oReqItems.color_id = CInt(comboboxCellrec.Value)
                Else
                    oReqItems.color_id = CInt(dgRow.Cells(CInt(Request.item_color)).Tag)
                End If

                oReqItems.item_no = dgRow.Cells(Request.item_no).Value
                oReqItems.Maco_desc1 = Trim(dgRow.Cells(Request.Maco_desc1).Value)

                '----------------------------------------------------------------------------------------------------------------------
                If Trim(dgRow.Cells(CInt(Request.Is_kit)).Value) <> "K" Then
                    '----------------------- Retrive from DataGridViewComboBoxCell Dec_Met_Id -----------------------------------------
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.DEC_MET_DESC), dgRow.Index), DataGridViewComboBoxCell) ' 

                    If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.dec_met_id = CInt(comboboxCellrec.Value)
                    '------------------------------------------------------------------------------------------------------------------

                    '----------------------- Retrive from DataGridViewComboBoxCell IMP_DESCRIPTION_id ---------------------------------
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.IMP_DESCRIPTION), dgRow.Index), DataGridViewComboBoxCell)
                    If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.imp_desc_id = CInt(comboboxCellrec.Value)
                    '------------------------------------------------------------------------------------------------------------------------

                    '----------------------- Retrive from DataGridViewComboBoxCell Patch_Shape , Patch_Color---------------------------------
                    If (oReqItems.dec_met_id = 88 Or oReqItems.dec_met_id = 131 Or oReqItems.dec_met_id = 133 Or CInt(comboboxCellrec.Value) = 138) Then 'retrive value only if is 88 BRANDPATCH 
                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Patch_Shape), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.patch_shape = CInt(comboboxCellrec.Value)
                        '++ID 1.15.2018
                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Patch_Color), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.Patch_Color = CInt(comboboxCellrec.Value)

                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Thread_Color), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.Thread_Color = CInt(comboboxCellrec.Value)

                        If (String.IsNullOrEmpty(dgRow.Cells(Request.BackGround_Color).Value) Or String.IsNullOrWhiteSpace(dgRow.Cells(Request.BackGround_Color).Value)) <> True Then
                            '    oReqItems.BackGround_Color = String.Empty
                            'Else
                            oReqItems.BackGround_Color = dgRow.Cells(Request.BackGround_Color).Value.ToString
                        End If

                        If (String.IsNullOrEmpty(dgRow.Cells(Request.StampingPattern).Value) Or String.IsNullOrWhiteSpace(dgRow.Cells(Request.StampingPattern).Value)) <> True Then
                            '    oReqItems.StampingPattern = String.Empty
                            'Else
                            oReqItems.StampingPattern = dgRow.Cells(Request.StampingPattern).Value.ToString
                        End If

                    End If
                End If
                '--------------------------------------------------------------------------------------------------------
                oReqItems.GUID = dgRow.Cells(Request.GUID).Value.ToString


                If String.IsNullOrEmpty(dgRow.Cells(CInt(Request.Parent_GUID)).Value) = False Then
                    '(Not dgRow.Cells(CInt(Request.Parent_GUID)).Value Is Nothing Or
                    'it was  If dgRow.Cells(CInt(Request.Parent_GUID)).Value.ToString <> "" Then
                    oReqItems.parent_guid = dgRow.Cells(CInt(Request.Parent_GUID)).Value.ToString
                End If

                oReqItems.IMPRINT_COLOR = dgRow.Cells(Request.IMPRINT_COLOR).Value
                oReqItems.IMPRINT_LOGO = Trim(dgRow.Cells(Request.IMPRINT_LOGO).Value)


                oReqItems.ReqItemComm = dgRow.Cells(Request.ReqItemComm).Value

                olstReqItems.Add(oReqItems)
            Next

            'NEED CHECK AND DELETE IN DB ITEMS WHICH WAS DELETED FROM GRID
            oReqItemsCheck = New cReqItems
            olstReqItemsCheck = New List(Of cReqItems)
            '  strQuery = "  where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItemsCheck = oReqItemsCheck.LoadLst(strQuery)

            'SEARCH IN EXISTING DB ALL LINES WITH SAME REQUESTID AND REVIEWID
            'COMMPARE WITH NEW EDITED MAYBE LIST AND REMOVE ALL ITEMS WHICH ARE NOT FINDED IN  olstReqItemsCheck
            For Each items As cReqItems In olstReqItemsCheck

                If olstReqItems.Find(Function(i As cReqItems) i.ReqItemId = items.ReqItemId) Is Nothing Then
                    If oReqItemsCheck.Delete(CInt(items.ReqItemId)) <> True Then
                        MsgBox("Not deleted : " & items.ItemCd & ",ReqitemId:" & items.ReqItemId)
                    End If
                End If
            Next

            'if list of cReqItems is well populated this means it will be well saved
            For Each lstItem As cReqItems In olstReqItems
                oReqItems = New cReqItems

                oReqItems.ReqItemId = lstItem.ReqItemId
                oReqItems.RequestId = lstItem.RequestId
                oReqItems.ReviewId = lstItem.ReviewId
                oReqItems.item_master_id = lstItem.item_master_id
                oReqItems.ItemCd = lstItem.ItemCd
                oReqItems.prod_category = lstItem.prod_category
                oReqItems.Is_Kit = lstItem.Is_Kit

                oReqItems.color_id = lstItem.color_id

                oReqItems.item_no = lstItem.item_no
                oReqItems.Maco_desc1 = lstItem.Maco_desc1

                oReqItems.dec_met_id = lstItem.dec_met_id

                oReqItems.imp_desc_id = lstItem.imp_desc_id

                oReqItems.patch_shape = lstItem.patch_shape
                '++ID 1.15.2018
                oReqItems.Patch_Color = lstItem.Patch_Color

                oReqItems.Thread_Color = lstItem.Thread_Color
                oReqItems.BackGround_Color = lstItem.BackGround_Color
                oReqItems.StampingPattern = lstItem.StampingPattern

                oReqItems.GUID = lstItem.GUID
                oReqItems.parent_guid = lstItem.parent_guid

                oReqItems.IMPRINT_COLOR = lstItem.IMPRINT_COLOR
                oReqItems.IMPRINT_LOGO = lstItem.IMPRINT_LOGO

                oReqItems.ReqItemComm = lstItem.ReqItemComm

                'If lstItem.Save() <> True Then
                ' save function return saved id in the case if is new record 
                If oReqItems.Save() <> True Then
                    MsgBox("Sku Nr: " & oReqItems.item_no & " is not saved.")
                Else
                    '++ID 1.17.2018 00:05AM
                    If lstItem.ReqItemId = 0 Then
                        'search new line in grid by criteria and put ReqitemId in the next cell
                        For Each dgvRows As DataGridViewRow In dgvStoryBoard.Rows
                            If dgvRows.Cells(Request.GUID).Value.ToString = lstItem.GUID Then
                                dgvRows.Cells(Request.x).Tag = oReqItems.ReqItemId
                                dgvRows.Cells(Request.ReqItemId).Value = oReqItems.ReqItemId
                            End If
                        Next

                        '  MsgBox("Request Item Id = " & oReqItems.ReqItemId)
                    End If

                End If
            Next

            oReqItemsCheck = New cReqItems


            strQuery = "  where requestId = " & RequestID & " and reviewId = " & ReviewId

            'refill the list with new modified value
            olstReqItems_old = oReqItemsCheck.LoadLst(strQuery)

            Return True

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function



    Private Function PopulateGridFromDB() As Boolean
        ' Call GridLine_Color()

        PopulateGridFromDB = False
        Try
            Dim cpt As Integer = 0
            Dim olstReqItemsCopy As List(Of cReqItems)

            oReqItems = New cReqItems
            olstReqItems = New List(Of cReqItems)
            Dim strQuery As String

            strQuery = "  where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItems = oReqItems.LoadLst(strQuery)

            olstReqItemsCopy = New List(Of cReqItems)

            olstReqItemsCopy = olstReqItems


            For Each lstItem As cReqItems In olstReqItems
                oReqItems = New cReqItems

                Try
                    'add row to grid 
                    dgvStoryBoard.Rows.Add()

                    'need check, each time when rows is added which is CurrrentRows

                    'add x(delete) column 
                    dgvStoryBoard.BeginEdit(True)

                    '----------------------- X-----------------------------
                    'if is not part of kit 
                    If lstItem.parent_guid = "" Then

                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Value = "X"
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Tag = lstItem.ReqItemId
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.Font = New Font("Arial", 14, FontStyle.Bold)
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.BackColor = Color.Red
                    Else
                        'if is part of kit
                        dgvStoryBoard.Rows(cpt).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Regular)
                        dgvStoryBoard.Rows(cpt).Height = 30
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.Font = New Font("Arial", 10, FontStyle.Regular)
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Style.BackColor = Color.Gold

                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Value = "|--" & Trim(olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).ItemCd)
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.x)).Tag = lstItem.ReqItemId
                    End If
                Catch ex As Exception
                    MsgBox("Error in X - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- iten_master_id ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.item_master_id)).Value = lstItem.item_master_id
                Catch ex As Exception
                    MsgBox("Error in item_master_id - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try



                '----------------------- style ------------------
                Try

                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.item_cd)).Value = lstItem.ItemCd

                Catch ex As Exception
                    MsgBox("Error in item_cd - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- prod_cat ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.prod_category)).Value = lstItem.prod_category
                Catch ex As Exception
                    MsgBox("Error in prod_cat - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- is_kit ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.Is_kit)).Value = lstItem.Is_Kit

                    If lstItem.Is_Kit = "K" Then
                        tetxBoxcell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), dgvStoryBoard.Rows(cpt).Index, "")
                        tetxBoxcell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), dgvStoryBoard.Rows(cpt).Index, "")
                    End If

                Catch ex As Exception
                    MsgBox("Error in is_kit and convert dec_met, imp_desc in textbox - " &
                           Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '--------------- check if it has parent and parent is mix and match item 
                Dim _mx_and_match As Boolean = False
                Try
                    Dim _item_m_id As Int32 = 0

                    '  For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                    If lstItem.parent_guid <> "" Then
                        For Each lstItemP As cReqItems In olstReqItems
                            If Trim(lstItemP.GUID) = Trim(lstItem.parent_guid) Then
                                _item_m_id = lstItemP.item_master_id
                            End If
                        Next

                        'check with parent item master if is mix and match
                        'variable item master will be used in below exception for to give to user possibility to change item color
                        _mx_and_match = MixAndMatch(_item_m_id)
                    End If

                Catch ex As Exception
                    MsgBox("Error check mix and match group item - " &
                       Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try


                '----------------------- item_color ------------------
                Try
                    'before need populate combobox with color which item has
                    oMdb_Item_VariantColor = New cMdb_Item_VariantColor
                    olstVariantColor = New List(Of cMdb_Item_VariantColor)

                    olstVariantColor = oMdb_Item_VariantColor.Load_VariantListColor(lstItem.item_master_id)

                    'exception : because if parent_guid containee guid this means item is component of the kit , and color is selected always
                    If lstItem.parent_guid = "" Then
                        If olstVariantColor.Count <> 0 Then
                            comboboxCell(dgvStoryBoard, CInt(Request.item_color), CInt(cpt), "color_id", "Color_Cd", olstVariantColor).Value = lstItem.color_id

                        End If
                        '+++ ID 02.08.2022
                    ElseIf lstItem.parent_guid <> "" And _mx_and_match = True Then
                        If olstVariantColor.Count <> 0 Then
                            comboboxCell(dgvStoryBoard, CInt(Request.item_color), CInt(cpt), "color_id", "Color_Cd", olstVariantColor).Value = lstItem.color_id
                        End If
                    Else

                        Call tetxBoxcell(dgvStoryBoard, CInt(Request.item_color), CInt(dgvStoryBoard.Rows(cpt).Index),
                                         olstVariantColor.Find(Function(i As cMdb_Item_VariantColor) i.Color_Id = lstItem.color_id).Color_Cd, lstItem.color_id)
                        'color_cd for display and color_id put in Tag for use in save function

                    End If

                Catch ex As Exception
                    MsgBox("Error in item_color - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- item_no ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.item_no)).Value = lstItem.item_no
                    ' dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_no)).Value = lstItem.item_no
                Catch ex As Exception
                    MsgBox("Error in item_no - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- Maco_desc1 ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.Maco_desc1)).Value = lstItem.Maco_desc1
                    'dgvStoryBoard.CurrentRow.Cells(CInt(Request.Maco_desc1)).Value = lstItem.Maco_desc1
                Catch ex As Exception
                    MsgBox("Error in Maco_desc1 - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '------------------------------------------------------------------------------------------------------------------------


                'if item is kit it cannot has deorating and location , his components has that
                If lstItem.Is_Kit <> "K" And lstItem.dec_met_id <> 0 Then

                    '----------------------- Dec_Met_Id ------------------
                    Try
                        oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                        olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                        If lstItem.parent_guid = "" Then
                            ' olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(lstItem.item_master_id))
                            olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetListCBO(CInt(lstItem.item_master_id))
                        Else
                            'olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(
                            '                olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id, lstItem.item_master_id)

                            olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetCompListCBO(
                                            olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id, lstItem.item_master_id)


                        End If

                        comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), CInt(dgvStoryBoard.Rows(cpt).Index),
                                      "DEC_MET_ID", "DEC_MET_DESC", olstImp_Loc_VIEW).Value = lstItem.dec_met_id

                        '88 BRANDPATCH from mdb_cfg_dec_met
                        If (lstItem.dec_met_id = 88 Or lstItem.dec_met_id = 131 Or lstItem.dec_met_id = 133 Or CInt(comboboxCellrec.Value) = 138) Then

                            'only for BRANDPATCH,BrandShield, 4CP brandshield  id 88,131,133 will be created combobox
                            oCfgEnum = New cCfgEnum
                            olsCfgEnum = New List(Of cCfgEnum)
                            olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                            If olsCfgEnum.Count <> 0 Then
                                'convert in combobox if is brandpach
                                comboboxCell(dgvStoryBoard, CInt(Request.Patch_Shape), CInt(dgvStoryBoard.Rows(cpt).Index),
                                             "Enum_ID", "ENUM_VALUE", olsCfgEnum).Value = lstItem.patch_shape

                                dgvStoryBoard.Rows(cpt).Cells(Request.Patch_Shape).ReadOnly = False
                            End If

                            '++ID 1.15.2018  
                            oCfgEnum = New cCfgEnum
                            olsCfgEnum = New List(Of cCfgEnum)

                            If (lstItem.dec_met_id = 88 Or lstItem.dec_met_id = 131 Or CInt(comboboxCellrec.Value) = 138) Then
                                olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08BP44")
                            ElseIf lstItem.dec_met_id = 133 Then
                                olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                            End If

                            If olsCfgEnum.Count <> 0 Then
                                'convert in combobox if is brandpach,brandshiel,4CP Brandshield
                                comboboxCell(dgvStoryBoard, CInt(Request.Patch_Color), CInt(dgvStoryBoard.Rows(cpt).Index),
                                                 "Enum_ID", "ENUM_VALUE", olsCfgEnum).Value = lstItem.Patch_Color

                                dgvStoryBoard.Rows(cpt).Cells(Request.Patch_Color).ReadOnly = False

                                'Thread_Color are same color like color of the patch.
                                'we use same color of the pach becuase we don't have inventory of the thread
                                comboboxCell(dgvStoryBoard, CInt(Request.Thread_Color), CInt(dgvStoryBoard.Rows(cpt).Index),
                                           "Enum_ID", "ENUM_VALUE", olsCfgEnum).Value = lstItem.Patch_Color

                                dgvStoryBoard.Rows(cpt).Cells(Request.Thread_Color).ReadOnly = False

                            End If

                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.BackGround_Color)).Value = lstItem.BackGround_Color
                            dgvStoryBoard.Rows(cpt).Cells(Request.BackGround_Color).ReadOnly = False
                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.StampingPattern)).Value = lstItem.StampingPattern
                            dgvStoryBoard.Rows(cpt).Cells(Request.StampingPattern).ReadOnly = False
                        Else
                            'return textbox properties if is not BrandPach id = 88 ,131,133
                            Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Shape), CInt(dgvStoryBoard.Rows(cpt).Index), "-")
                            Call tetxBoxcell(dgvStoryBoard, CInt(Request.Patch_Color), CInt(dgvStoryBoard.Rows(cpt).Index), "-")
                            Call tetxBoxcell(dgvStoryBoard, CInt(Request.Thread_Color), CInt(dgvStoryBoard.Rows(cpt).Index), "-")
                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.BackGround_Color)).Value = "-"
                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.StampingPattern)).Value = "-"
                        End If



                    Catch ex As Exception
                        MsgBox("Error in Dec_met_id,Patch_Shape,Thread_Color,BackGround_Color,StampingPattern, - " & Me.Name &
                               "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        PopulateGridFromDB = False
                    End Try

                    '----------------------- IMP_DESCRIPTION ------------------
                    Try
                        ' dgvStoryBoard.Rows(cpt).Cells(CInt(Request.IMP_DESCRIPTION)).Value = lstItem.imp_desc_id

                        Dim oMdb_Item_Imp_Loc As New cMdb_Item_Imp_Loc_VIEW
                        Dim olstImp_Loc As New List(Of cMdb_Item_Imp_Loc_VIEW)

                        ' olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(lstItem.item_master_id), CInt(lstItem.dec_met_id))

                        If lstItem.parent_guid = "" Then
                            olstImp_Loc = oMdb_Item_Imp_Loc.LoadDecMet_List(CInt(lstItem.item_master_id), CInt(lstItem.dec_met_id))
                        Else
                            olstImp_Loc = oMdb_Item_Imp_Loc.LoadDecMetComp_List(
                                            olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id, lstItem.item_master_id, CInt(lstItem.dec_met_id))
                        End If

                        'fill combobox with posibil location for present dec_met_id


                        If lstItem.imp_desc_id <> 0 Then
                            comboboxCell(dgvStoryBoard, CInt(Request.IMP_DESCRIPTION), cpt,
                                          "IMP_LOC_ID", "Imp_Loc_Desc", olstImp_Loc).Value = CInt(lstItem.imp_desc_id)

                            'populate AreaSize
                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.Area_Size)).Value =
                            olstImp_Loc.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Imp_Loc_Id = lstItem.imp_desc_id).AREA_SIZE
                            'populate defaul_loc
                            dgvStoryBoard.Rows(cpt).Cells(CInt(Request.DEFAULT_LOC)).Value =
                                    olstImp_Loc.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Imp_Loc_Id = lstItem.imp_desc_id).Default_Loc
                        End If

                    Catch ex As Exception
                        MsgBox("Error in imp_desc_id,Area_size,defaul_loc - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        PopulateGridFromDB = False
                    End Try

                ElseIf lstItem.Is_Kit <> "K" And lstItem.dec_met_id = 0 Then
                    Try
                        '--------------------- Decorating ----------------------
                        oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                        olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                        If lstItem.parent_guid = "" Then
                            olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(lstItem.item_master_id))
                        Else
                            '    olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(
                            '                    olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id, lstItem.item_master_id)

                            olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetCompListCBO(
                                            olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id, lstItem.item_master_id)
                        End If

                        Call comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), CInt(dgvStoryBoard.Rows(cpt).Index),
                                      "DEC_MET_ID", "DEC_MET_DESC", olstImp_Loc_VIEW) '.Value = lstItem.dec_met_id

                        'comboboxCell(dgvStoryBoard, CInt(Request.DEC_MET_DESC), CInt(dgvStoryBoard.Rows(cpt).Index),
                        '              "DEC_MET_ID", "DEC_MET_DESC", olstImp_Loc_VIEW).Value = lstItem.dec_met_id


                    Catch ex As Exception
                        MsgBox("Error in exception ElseIF  imp_desc_id,Area_size,defaul_loc - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        PopulateGridFromDB = False
                    End Try

                ElseIf lstItem.Is_Kit = "K" Then
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.IMPRINT_COLOR)).ReadOnly = True
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.IMPRINT_LOGO)).ReadOnly = True

                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.BackGround_Color)).ReadOnly = True
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.StampingPattern)).ReadOnly = True
                End If
                '------------------------------------------------

                '----------------------- GUID -------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.GUID)).Value = lstItem.GUID
                Catch ex As Exception
                    MsgBox("Error in GUID - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- parent_guid ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.Parent_GUID)).Value = lstItem.parent_guid

                    If lstItem.parent_guid <> "" Then
                        dgvStoryBoard.Rows(cpt).Cells(CInt(Request.Parent_GUID)).Tag =
                                            olstReqItemsCopy.Find(Function(i As cReqItems) i.GUID = lstItem.parent_guid).item_master_id '"item_master_id for the kit"
                    End If

                Catch ex As Exception
                    MsgBox("Error in parent_guid - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                '----------------------- IMPRINT_COLOR & IMPRINT_LOGO ------------------
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.IMPRINT_COLOR)).Value = lstItem.IMPRINT_COLOR
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.IMPRINT_LOGO)).Value = lstItem.IMPRINT_LOGO

                Catch ex As Exception
                    MsgBox("Error in IMPRINT (COLOR or LOGO) - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try
                '----------------------- Item Comment ------------------
                Try

                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.ReqItemComm)).Value = lstItem.ReqItemComm

                Catch ex As Exception
                    MsgBox("Error in Item Comment - " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try


                '----------------------- ReqItemId ------------------
                '++ID 1.16.2018
                Try
                    dgvStoryBoard.Rows(cpt).Cells(CInt(Request.ReqItemId)).Value = lstItem.ReqItemId

                Catch ex As Exception
                    MsgBox("Error in  " & Me.Name & ". ReqItemId" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    PopulateGridFromDB = False
                End Try

                dgvStoryBoard.BeginEdit(False)
                PopulateGridFromDB = True
                If cpt <> olstReqItems.Count Then cpt += 1 Else Exit Function

            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "----------------------------- Work Save Item Additional Imprint Location -------------------------------- "
    Private Sub SaveRequestItem_AdditionalLocation()
        '---------------------------------------
        'function for save Additional Location
        '---------------------------------------
        Try
            'variable used
            Dim boulVar As Boolean = False

            '  Dim olstReItems_AdditLocation_Save As List(Of cReqItems_AdditLocation)
            If olstReItems_AdditDetail Is Nothing Then Exit Sub

            Dim strSql As String = ""
            Dim oReqItems_AdditDetail_Check As cReqItems_AdditLocation
            Dim olstReItems_AdditDetail_Check As List(Of cReqItems_AdditLocation)


            Dim oReqItems_AdditLocation_Save As cReqItems_AdditLocation
            ' TakeData_DGVStBoard
            oReqItems_AdditLocation_Save = New cReqItems_AdditLocation
            '   olstReItems_AdditLocation_Save = New List(Of cReqItems_AdditLocation)

            '      olstReItems_AdditDetail
            'identify all ReqItemId = 0 , because when item is added in stroyboard grid it will have id only after save function


            'check if was deleted lines from DB in listview
            'return existing additional location  for comparate
            oReqItems_AdditDetail = New cReqItems_AdditLocation
            oReqItems_AdditDetail_Check = New cReqItems_AdditLocation
            olstReItems_AdditDetail_Check = New List(Of cReqItems_AdditLocation)

            strSql = " select ra.* from ReqItems r WITH (Nolock)  inner join ReqItems_AdditLocation ra WITH (Nolock) on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " and ReviewId = " & ReviewId & ""
            olstReItems_AdditDetail_Check = oReqItems_AdditDetail.LoadLst(strSql)

            For Each addit_check As cReqItems_AdditLocation In olstReItems_AdditDetail_Check
                boulVar = False
                For Each addit_changes As cReqItems_AdditLocation In olstReItems_AdditDetail
                    If (addit_check.Additional_ID = addit_changes.Additional_ID Or addit_changes.Additional_ID = 0) Then
                        boulVar = True
                    End If
                Next
                If boulVar <> True Then
                    addit_check.Delete(addit_check)
                End If
            Next

            '---------------------------------------------------------------------

            For Each olstDet As cReqItems_AdditLocation In olstReItems_AdditDetail
                If olstDet.ReqItemId = 0 Then
                    'find requestId by ReqItemGuid from AdditLocation
                    For Each dgvStBoardList As cReqItems In TakeData_DGVStBoard()
                        If olstDet.ReqItemGuid = dgvStBoardList.GUID Then
                            olstDet.ReqItemId = dgvStBoardList.ReqItemId
                        End If
                    Next
                End If
            Next

            'After what ReqItemId was inserted for the new additlocation 
            'can save or update in DB
            For Each addLocSave As cReqItems_AdditLocation In olstReItems_AdditDetail
                'eliminate wrong empty line
                If addLocSave.Additional_ID <> 0 And (addLocSave.dec_met_id = 0 Or addLocSave.imp_desc_id = 0) Then
                    addLocSave.Delete(addLocSave)
                ElseIf addLocSave.Additional_ID = 0 And (addLocSave.dec_met_id = 0 Or addLocSave.imp_desc_id = 0) Then

                Else
                    addLocSave.Save(addLocSave)
                End If
            Next
            '-------------------------------------------------------------------

            'If olstReItems_AdditDetail_Check.Find(Function(c As cReqItems_AdditLocation) c.Additional_ID = addLocSave.Additional_ID) Is Nothing Then
            '-------------------------------------------------------------------

            'Recharge the global olstReItems_AdditDetail
            oReqItems_AdditDetail = New cReqItems_AdditLocation
            olstReItems_AdditDetail = New List(Of cReqItems_AdditLocation)

            strSql = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqItems_AdditLocation ra WITH (Nolock) on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " and ReviewId = " & ReviewId & ""

            olstReItems_AdditDetail = oReqItems_AdditDetail.LoadLst(strSql)
            Debug.Print(olstReItems_AdditDetail.Count)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
        '---------------------------------------
        '---------------------------------------
    End Sub

#End Region
#Region "---------------------------- Work & Save Bind-Document-Items -----------------------------"
    Private Sub SaveRequest_DocBindItem()
        Try
            If olstReqDocBindItem Is Nothing Then Exit Sub

            Dim olstReqDBindOld_Data As New List(Of cReqDocBindItem)
            oReqDocBindItem = New cReqDocBindItem
            Dim message As String = ""

            Dim strQuery = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqDocBindItem ra WITH (Nolock) 
                      on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " And ReviewId = " & ReviewId & ""

            olstReqDBindOld_Data = oReqDocBindItem.LoadLst(strQuery)


            Dim oReqItemsCheck As cReqItems
            oReqItemsCheck = New cReqItems

            Dim olstReqItemsCheck As List(Of cReqItems)
            olstReqItemsCheck = New List(Of cReqItems)

            strQuery = "  where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItemsCheck = oReqItemsCheck.LoadLst(strQuery)


            If olstReqDBindOld_Data.Count = 0 Then
                'don't need comparate new list with old list the objects

                'fill object from list olstReqDocBindItem 
                'and save all data



                For Each olstB As cReqDocBindItem In olstReqDocBindItem
                    oReqDocBindItem = New cReqDocBindItem
                    'need check for new line added in grid 
                    'after save need recuperate by ItemGuid and fill ReqItemId

                    oReqDocBindItem.ReqItemId = olstB.ReqItemId
                    'exception for check if is new itemd added when we bided document with item we used only the Guid but need recuperate ReqItemId 

                    ' in bind table is FK
                    If olstB.ReqItemId = 0 Then
                        oReqDocBindItem.ReqItemId = olstReqItemsCheck.Find(Function(i As cReqItems) i.GUID = olstB.ItemGuid).ReqItemId
                    Else
                        oReqDocBindItem.ReqItemId = olstB.ReqItemId
                    End If

                    oReqDocBindItem.DocId = olstB.DocId
                    oReqDocBindItem.Guid = olstB.Guid
                    oReqDocBindItem.ItemGuid = olstB.ItemGuid

                    oReqDocBindItem.Save()
                    'return bindId
                    olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.Guid = olstB.Guid).BindId = oReqDocBindItem.BindId
                Next
            Else
                'comparate new list with old
                'For Each old As cReqDocBindItem In olstReqDBindOld_Data

                '    'comapare with new changes did while 
                '    For Each newest As cReqDocBindItem In olstReqDocBindItem
                '        If newest.BindId = old.BindId Then
                '            message = ""
                '        ElseIf newest.BindId <> old.BindId Then

                '        End If
                '    Next
                'Next
                ' this is for new items---------------------
                Dim except = olstReqDocBindItem.Except(olstReqDBindOld_Data)

                For Each product In except
                    Debug.Print("Compared BindId : " & product.BindId)

                    If product.BindId = 0 Then

                        oReqDocBindItem = New cReqDocBindItem

                        'need check for new line added in grid 
                        'after save need recuperate by ItemGuid and fill ReqItemId

                        'oReqDocBindItem.ReqItemId = product.ReqItemId

                        If product.ReqItemId = 0 Then
                            oReqDocBindItem.ReqItemId = olstReqItemsCheck.Find(Function(i As cReqItems) i.GUID = product.ItemGuid).ReqItemId
                        Else
                            oReqDocBindItem.ReqItemId = product.ReqItemId
                        End If


                        oReqDocBindItem.DocId = product.DocId
                        oReqDocBindItem.Guid = product.Guid
                        oReqDocBindItem.ItemGuid = product.ItemGuid

                        oReqDocBindItem.Save()

                        'return BindId from
                        olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.Guid = product.Guid).BindId = oReqDocBindItem.BindId

                    End If
                Next

                'delete items missed from new list

                Dim except1 = olstReqDBindOld_Data.Except(olstReqDocBindItem)

                Dim varCompar As Boolean = False

                For Each item In except1 'is data from old version , before save
                    Debug.Print("Compared BindId : " & item.BindId)
                    varCompar = False
                    'logic is 
                    'if in old data missing id from new data this means item was deleted
                    'need delete from DB, also.

                    For Each item1 In except
                        If item.BindId = item1.BindId Then
                            varCompar = True
                        End If
                    Next

                    If varCompar = False Then
                        oReqDocBindItem = New cReqDocBindItem
                        oReqDocBindItem.BindId = item.BindId
                        oReqDocBindItem.Delete(oReqDocBindItem)

                    End If


                Next


            End If





        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "---------------------------- Work & Save Communication --------------------------------"

    Public Sub SendEmail()
        Dim CPT As Int32 = 0
        Try
            Dim strQuery As String = ""
            Dim oCfgEnum1 As cCfgEnum
            Dim olsCfgEnum1 As List(Of cCfgEnum)

            Dim oReqSentMail As cReqSentMails
            Dim olstReqSentMails As List(Of cReqSentMails)

            Dim Message As String = ""
            Dim valImp As String = ""
            Dim valMet As String = ""
            Dim valPatch_Shape As String = ""
            Dim valPatch_Color As String = ""
            Dim valArea As String = ""
            Dim valDefaultLoc As Integer = 0
            Dim listFileAddress As List(Of String) = New List(Of String)
            Dim valItemMasterKit As String = ""
            Dim valItemMasterKit_Cd As String = ""
            Dim valDocLoc As String = ""
            Dim valColorName As String = ""
            Dim valTreadColor As String = ""
            Dim valBackGroundColor As String = ""
            Dim valStampingPattern As String = ""


            '   If chkSendToGraphic.CheckState = CheckState.Checked Then


            If Trim(xTxtShowSenderEmail.Text) = "" Then
                MsgBox("Email address is empty please enter or choose from list. E-mail is not sent." & vbCrLf & " Thank you")
                Exit Sub
            End If


                'sent to graphic
                'need put in function and for now all mail will be sent to Erin
                oExact_Traveler_Permission = New cExact_Traveler_Permission
                If oExact_Traveler_Permission.Load(" where p.Email = '" & Trim(xTxtShowSenderEmail.Text) & "'") <> True Then

                    MsgBox(Trim(xTxtShowSenderEmail.Text & " e-Mail is wrong."))
                    Exit Sub
                End If

                oExact_Traveler_Permission = New cExact_Traveler_Permission

                Dim oMessage As New cMail()
                oMessage.FromAddr = oExact_Traveler_Permission.Email
                oMessage.ToAddr = Trim(xTxtShowSenderEmail.Text) & "," & oExact_Traveler_Permission.Email '"erin@spectorandco.com"
            '++ID 02.29.2022 commneted email iond@
            '  oMessage.CCAddr = "iond@spectorandco.ca"
            oMessage.Subject = "Message from : " & Trim(lblStoryBoard.Text) & Trim(xtxtReqItemCode.Text)

            '++ID 4.12.2018 reduce fro send documetns 
            If chkSendOnlyComm.CheckState <> CheckState.Checked Then
                '--------------------- document place -----------------------------
                If olstMdb_Item_Doc_Attach IsNot Nothing Then
                    For Each d As cMdb_Item_Doc In olstMdb_Item_Doc_Attach
                        If d.Item_Doc_Type_Id <> 24 Then
                            valDocLoc = WriteInExact(d.Item_Doc_Name.Replace("?","") & "." & d.Item_Doc_File_Ext, d.Item_Doc)
                            oMessage.AddAttachment(valDocLoc)
                            listFileAddress.Add(valDocLoc)
                        End If
                    Next
                End If
                '-------------------------------------------------------------------
            End If 'If chkSendOnlyComm.CheckState <> CheckState.Checked Then

            Message = "<html>
<head>
<style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
</style>


</head>
<body>"

            Message &= "<p ><font size='5'> " & Trim(lblStoryBoard.Text) & "   " & Trim(xtxtReqItemCode.Text) & "</font></p>.<br/> <br/>"
            Message &= " Status - " & txtbtnStatus.Tag & "-" & txtbtnStatus.Text & "<br/>"

            If chkRushOrder.CheckState = CheckState.Checked Then Message &= "Is Rush Order : YES. <br/> <br/>"
                Message &= " For Customer : " & Trim(txtCustomer.Text) & " - " & Trim(lblCustomerName.Text) & ".<br/><br/>"
                Message &= " Customer Contact : " & Trim(lnkLblContactShow.Text) & ",  e-mail : " & Trim(lblContactEmail.Text) & ".<br/> <br/> <br/>"

            Message &= "<a  href='M:/mcc/traveler executable/CustomerFile/CustomerFile.exe' > - >Customer File Program< - </a>.<br/> <br/> <br/>"


            If chkSendOnlyComm.CheckState <> CheckState.Checked Then

                Message &= "<table  > 
               <tr bgcolor='#8FBC8F'  > <td> Masterid </td> 
       <td> Style </td> <td> Prod Cat </td> <td> Kit:Y/N </td> <td> Color </td> <td> SKU </td>  <td> Macola Description </td> <td> Deco/Method </td> 
         <td> Deco/Location </td> <td> Area/Size </td> <td> Default/Location </td> <td> Patch/Shape </td> <td> Patch/Color </td> <td> Thread Color </td> <td> BackGround Color </td>
          <td> Stamping Pattern </td>  <td> Imprint/Color </td> <td> Imprint/Logo </td>  </tr> "
                oReqItems = New cReqItems
                olstReqItems = New List(Of cReqItems)

                If olstReqItems IsNot Nothing Then

                    strQuery = " select ri.* from ReqItems ri where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'" _
                            & "   union   " _
                            & " select ri.ReqItemId,RequestId = 0,ReviewId = 0,ri.item_master_id,ItemCd = '',Is_Kit = '',prod_category= '',Maco_desc1 = '',color_id = 0, " _
                            & " item_no = '',l.dec_met_id, l.imp_desc_id, l.patch_shape, ri.GUID, ri.parent_guid, CreateBy = 0,  " _
                            & " CreateByFullName = '', CreateDate = '', ModifyBy = 0, ModifyByFullName = '', ModifyDate = '',l.imprint_color ,l.imprint_logo ,l.patch_color, " _
                            & " l.Thread_Color, l.BackGround_Color,l.StampingPattern,ri.ReqItemComm  from ReqItems ri right join ReqItems_AdditLocation l on " _
                            & " ri.ReqItemId = l.ReqItemId   where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'  order by ReqItemId,RequestId  desc "

                    olstReqItems = oReqItems.LoadLst_ForEmail(strQuery)

                    oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                    olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                    Dim oRItems As New cReqItems
                    Dim olstRItems As List(Of cReqItems)

                    oRItems = New cReqItems
                    olstRItems = New List(Of cReqItems)

                    olstRItems = oReqItems.LoadLst_ForEmail(strQuery) 'LoadLst("WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId)

                    oMDB_CFG_IMP_LOC = New cMDB_CFG_IMP_LOC
                    olstMDB_CFG_IMP_LOC = New List(Of cMDB_CFG_IMP_LOC)
                    olstMDB_CFG_IMP_LOC = oMDB_CFG_IMP_LOC.LoadLst

                    oMDB_CFG_DEC_MET = New cMDB_CFG_DEC_MET
                    olstMDB_CFG_DEC_MET = New List(Of cMDB_CFG_DEC_MET)
                    olstMDB_CFG_DEC_MET = oMDB_CFG_DEC_MET.LoadLst

                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)
                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                    oCfgEnum1 = New cCfgEnum
                    'olsCfgEnum1 = New List(Of cCfgEnum)
                    'olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                    oMdb_cfg_Color = New cMdb_Cfg_Color
                    olstMdb_Cfg_Color = New List(Of cMdb_Cfg_Color)

                    olstMdb_Cfg_Color = oMdb_cfg_Color.Load

                    'start FOR EACH  olstReqItems
                    For Each item As cReqItems In olstReqItems
                        CPT += 1
                        olsCfgEnum1 = New List(Of cCfgEnum)
                        '    olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                        If (item.dec_met_id = 88 Or item.dec_met_id = 131 Or CInt(comboboxCellrec.Value) = 138) Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08BP44")
                        ElseIf item.dec_met_id = 133 Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                        End If

                        valArea = ""
                        valDefaultLoc = 0
                        valImp = ""
                        valMet = ""
                        valItemMasterKit = ""
                        valPatch_Shape = ""
                        valPatch_Color = ""
                        valColorName = ""

                        Try
                            If Not olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id) Is Nothing Then
                                valColorName = olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id).COLOR_NAME
                            End If
                        Catch ex As Exception
                            MsgBox("Error in " & Me.Name & ". Assigne color name" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        End Try

                        Message &= "<tr>"

                        If item.RequestId <> 0 And item.ReviewId <> 0 And item.color_id <> 0 Then

                            Message &= " <td> " & item.item_master_id & "</td> <td> " & item.ItemCd & " </td> <td>" & item.prod_category & "</td>"

                            If item.parent_guid <> "" Then
                                If Not olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid) Is Nothing Then valItemMasterKit_Cd = item.Is_Kit & "-" & olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).ItemCd
                            Else
                                valItemMasterKit_Cd = item.Is_Kit
                            End If

                            Message &= "<td>" & valItemMasterKit_Cd & "</td> "

                            Message &= " <td>" & Trim(valColorName) & "</td><td>" & item.item_no & "<t/d><td>" & item.Maco_desc1 & "</td>"

                        Else
                            'exception if item have additional location
                            Dim additLocation As String = ""
                            additLocation = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).item_no

                            Message &= " <td colspan = '7' bgcolor='#B0E0E6' align='center'> ADITIONAL LOCATION FOR ITEM NO : " & Trim(additLocation).ToUpper

                            Message &= " </td>"

                        End If

                        If item.dec_met_id <> 0 Then
                            If Not olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id) Is Nothing Then valMet = olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id).DEC_MET_NAME
                        End If
                        Message &= " <td>" & valMet & "</td>"

                        If item.imp_desc_id <> 0 Then
                            If Not olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id) Is Nothing Then valImp = olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id).IMP_DESC
                        End If
                        Message &= "<td>" & valImp & "</td>  "

                        If item.parent_guid = "" Then 'Item is not kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then
                                If item.item_master_id = 0 Then
                                    item.item_master_id = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).item_master_id
                                End If

                                olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(item.item_master_id)

                                If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE

                                valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                            End If
                            Message &= "<td>" & valArea & " </td> "

                            If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"

                        ElseIf item.parent_guid <> "" Then 'item Is component of the kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then

                                valItemMasterKit = olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).item_master_id
                                olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(valItemMasterKit, item.item_master_id, item.dec_met_id)

                                If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then
                                    valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE
                                    valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                                End If

                                Message &= "<td>" & valArea & " </td> "

                                If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"
                            Else
                                Message &= "<td> </td>  <td> </td>"
                            End If
                        End If

                        If item.patch_shape <> 0 Then
                            If Not olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape) Is Nothing Then valPatch_Shape = olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape).Enum_Value
                        End If

                        Message &= "<td>" & valPatch_Shape & " </td> "
                        '++ID 1.15.2018 added patch_color
                        If item.Patch_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color) Is Nothing Then valPatch_Color = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color).Enum_Value
                        End If

                        Message &= "<td>" & valPatch_Color & "</td> "

                        If item.Thread_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color) Is Nothing Then valTreadColor = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color).Enum_Value
                        End If

                        Message &= "<td>" & valTreadColor & "</td>"
                        Message &= "<td>" & item.BackGround_Color & "</td>"
                        Message &= "<td>" & item.StampingPattern & "</td>"

                        Message &= "<td> " & item.IMPRINT_COLOR & " </td> <td> " & item.IMPRINT_LOGO & " </td>  </tr>"

                    Next

                End If

                Message &= " </table> "

            End If 'If chkSendOnlyComm.CheckState <> CheckState.Checked Then

            '------------------------Add comments in e-mail -------------------------------------------

            oReqCommunic = New cReqCommunication
                olstReqCommunic = New List(Of cReqCommunication)

                '------------------------------ Display txtSpecInstrReceive -----------------------------
                olstReqCommunic = New List(Of cReqCommunication)
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

                Message &= "<br/><br/> Comments from CS: " & "<br/> "
                If Not olstReqCommunic Is Nothing Then
                    For Each comm As cReqCommunication In olstReqCommunic
                        Message &= comm.MessageInstruction & "<br/> "
                    Next
                End If
                Message &= "----------------------------------------------------------------------------<br/><br/>"
                '----------------------------------------------------------------------------------------

                '------------------------------- Display txtRecCommGraph --------------------------------
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")
                Message &= "Comments from Graphics : <br/>"
                If Not olstReqCommunic Is Nothing Then
                    For Each comm As cReqCommunication In olstReqCommunic
                        Message &= comm.MessageInstruction & "<br/> "
                    Next
                End If
                '----------------------------------------------------------------------------------------
                Message &= "----------------------------------------------------------------------------<br/><br/> Thank you "

                Message &= "</body> </html>"

                oMessage.Message = Message
                oMessage.Send()

                MsgBox("E-Mail was send successfully towards " & Trim(xTxtShowSenderEmail.Text))


            For Each s As String In listFileAddress
                If File.Exists(s) Then
                    File.Delete(s)
                End If
            Next



            '---------------------- save email --------------------------

            oReqSentMail = New cReqSentMails
                olstReqSentMails = New List(Of cReqSentMails)

                'where requestid = '" & RequestID & "' and reviewid = '" & ReviewId & 

                With oReqSentMail
                    .RequestId = RequestID
                    .ReviewID = ReviewId
                    .SentTo = Trim(xTxtShowSenderEmail.Text)
                    .HTMLdata = Message
                    .Save()
                End With
                '------------------------------------------------------------
            'Else

            'End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & ". CPT = " & CPT & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SendEmail_ByStatus(ByVal pStatus As Int32)

        Dim CPT As Int32 = 0
        Try
            Dim g As String = ""
            Dim strQuery As String = ""
            Dim valDocLoc As String = ""
            Dim listFileAddress As List(Of String) = New List(Of String)

            Dim intByteLength As Int32 = 0
            Dim boolCheckByteLength As Boolean = True
            Dim strMissingDocumByLength As String = ""

            Dim oReqSentMail As cReqSentMails
            ' Dim olstReqSentMails As List(Of cReqSentMails)

            Dim oReqRev As cReqRevision
            'RequestID, ReviewId
            oReqRev = New cReqRevision()
            oReqRev.Load(" where  RequestId = " & RequestID & " and ReviewId = " & ReviewId)

            strQuery = " where p.ID = " & oReqRev.CreateBy

            oExact_Traveler_Permission = New cExact_Traveler_Permission(strQuery)

            Dim oMdb_Doc_St As New cMdb_Item_Doc
            Dim olstMdb_Doc_St As New List(Of cMdb_Item_Doc)

            olstMdb_Doc_St = oMdb_Doc_St.LoadList(" where RequestId = " & RequestID & " And ReviewId = " & ReviewId & "order by Item_Doc_Type_Id asc")

            Dim Message As String = ""
            Dim SentToCreator As String = ""

            SentToCreator = Trim(oExact_Traveler_Permission.Email)

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            Dim oMessage As New cMail()

            'NEED IDENTIFY WHAT IS THAT 22 OR 23 




            If lblStoryBoard.Tag = 23 Then
                oMessage.FromAddr = oExact_Traveler_Permission.Email '"virtualsamples@spectorandco.com"
            ElseIf lblStoryBoard.Tag = 22 Then
                oMessage.FromAddr = oExact_Traveler_Permission.Email ' "storyboard@spectorandco.com"
            ElseIf lblStoryBoard.Tag = 25 Then
                oMessage.FromAddr = oExact_Traveler_Permission.Email ' "flyers@spectorandco.com"
            Else
                oMessage.FromAddr = oExact_Traveler_Permission.Email
            End If

            oMessage.ToAddr = SentToCreator & "," & oExact_Traveler_Permission.Email '"erin@spectorandco.com"

            '++ID 02.29.2022 commneted email iond@
            ' oMessage.CCAddr = "iond@spectorandco.ca"
            'oMessage.Subject = "Message from : " & Trim(lblStoryBoard.Text) & Trim(xtxtReqItemCode.Text)
            oMessage.Subject = Trim(lblStoryBoard.Text) & Trim(xtxtReqItemCode.Text) & "- is " & DirectCast([Enum].Parse(GetType(ReqCFGStatus), pStatus), ReqCFGStatus).ToString

            '++ID 4.12.2018 send documents only if is completed request 
            'if not only comunication
            If pStatus = CInt(ReqCFGStatus.Completed) Then

                Try
                    g = Guid.NewGuid.ToString

                    If olstMdb_Item_Doc_Attach IsNot Nothing Then
                        For Each d As cMdb_Item_Doc In olstMdb_Doc_St

                            valDocLoc = ""

                            'filter by d.user_login
                            'complete status can only graphic depart and if s.user_name is not from graphic traveler_permission return 0
                            strQuery = "  where user_name = '" & d.User_Login & "' and perm_group_id = 182 " '182 - perm_group_id is Graphics Department
                            oExact_Traveler_Permission = New cExact_Traveler_Permission(strQuery)

                            'intByteLength += FilesSize(d.Item_Doc.Length)

                            'If intByteLength >= 19000 Then
                            '    boolCheckByteLength = False
                            '    strMissingDocumByLength &= d.Item_Doc_Name & "." & d.Item_Doc_File_Ext
                            'End If

                            If oExact_Traveler_Permission.ID <> 0 Then

                                intByteLength += CDbl(FormatNumber(d.Item_Doc.Length / 1024, 0))

                                If intByteLength >= 19000 Then
                                    boolCheckByteLength = False
                                    strMissingDocumByLength &= d.Item_Doc_Name & "." & d.Item_Doc_File_Ext & vbCrLf
                                End If

                                If boolCheckByteLength <> False Then valDocLoc = WriteInExact(d.Item_Doc_Name.Replace("?", "") & "_" & g & "." & d.Item_Doc_File_Ext, d.Item_Doc)

                                'oMessage.AddAttachment(valDocLoc)
                                'listFileAddress.Add(valDocLoc)
                            Else
                                '+ID 4.13.2018 add document Customer Email added by CSR
                                If d.Item_Doc_Type_Id = 24 Then

                                    intByteLength += CDbl(FormatNumber(d.Item_Doc.Length / 1024, 0))

                                    If intByteLength >= 19000 Then
                                        boolCheckByteLength = False
                                        strMissingDocumByLength &= d.Item_Doc_Name & "." & d.Item_Doc_File_Ext & vbCrLf
                                    End If

                                    If boolCheckByteLength <> False Then valDocLoc = WriteInExact(d.Item_Doc_Name.Replace("?", "") & "_" & g & "." & d.Item_Doc_File_Ext, d.Item_Doc)

                                    'oMessage.AddAttachment(valDocLoc)
                                    'listFileAddress.Add(valDocLoc)
                                End If
                            End If
                            '++ID 4.13.2018 result will be one
                            If valDocLoc <> "" Then
                                oMessage.AddAttachment(valDocLoc)
                                listFileAddress.Add(valDocLoc)
                            End If



                        Next
                    End If
                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & ". Add in Mail documents from graphics dept." & CPT & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try

            End If '  If pStatus = CInt(ReqCFGStatus.Completed) Then

            Message = "<html>
<head>
<style>

</style>


</head>
<body>"

            Message &= "<p ><font size='5'> " & Trim(lblStoryBoard.Text) & "   " & Trim(xtxtReqItemCode.Text) & "</font></p><br/> "

            '      Message &= " Status changed in - <font size='5'>" & txtbtnStatus.Tag & "-" & txtbtnStatus.Text & "</font> <br/><br/>"

            'Message &= "By Value Status changed in - <font size='5'>" &
            '    DirectCast([Enum].Parse(GetType(ReqCFGStatus), pStatus), ReqCFGStatus) & "-" &
            '     DirectCast([Enum].Parse(GetType(ReqCFGStatus), pStatus), ReqCFGStatus).ToString & "</font> <br/><br/>"
            '" Status - " & txtbtnStatus.Tag & "-" & txtbtnStatus.Text & "<br/>"

            Message &= " Request  is - <font size='5'>" & DirectCast([Enum].Parse(GetType(ReqCFGStatus), pStatus), ReqCFGStatus).ToString & ".</font> <br/><br/>"

            If chkRushOrder.CheckState = CheckState.Checked Then Message &= "Is Rush Order : YES. <br/> <br/>"
            Message &= " Customer : " & Trim(txtCustomer.Text) & " - " & Trim(lblCustomerName.Text) & ".<br/>"
            Message &= " Customer Contact : " & Trim(lnkLblContactShow.Text) & ",  e-mail : " & Trim(lblContactEmail.Text) & ".<br/><br/>"

            Message &= "<a  href='M:/mcc/traveler executable/CustomerFile/CustomerFile.exe' > - >Customer File Program Link< - </a>.<br/><br/>"

            '++ID 4.13.2018 added the not
            If strMissingDocumByLength.Length > 0 Then
                Message &=  strMissingDocumByLength & "<font color='red'>" & " - was not added in attachments (but you can find in the 'Request Program') : </font><br/>" 

            End If

            Message &= "<br/>"
            '------------------------Add comments in e-mail -------------------------------------------

            oReqCommunic = New cReqCommunication
            olstReqCommunic = New List(Of cReqCommunication)

            '------------------------------ Display txtSpecInstrReceive -----------------------------
            olstReqCommunic = New List(Of cReqCommunication)
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

            Message &= "<br/><br/><font color='red'> Comments from CS: </font>" & "<br/> "
            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    Message &= comm.MessageInstruction & "<br/> "
                Next
            End If
            Message &= "----------------------------------------------------------------------------<br/><br/>"

            '------------------------------- Display txtRecCommGraph --------------------------------
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")
            Message &= "<font color='red'> Comments from Graphics : </font> <br/>"
            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    Message &= comm.MessageInstruction & "<br/> "
                Next
            End If
            '----------------------------------------------------------------------------------------
            Message &= "----------------------------------------------------------------------------<br/><br/> Thank you "

            Message &= "</body> </html>"

            oMessage.Message = Message
            oMessage.Send()

            MsgBox("E-Mail was send successfully." & Trim(xTxtShowSenderEmail.Text))


            For Each s As String In listFileAddress
                If File.Exists(s) Then
                    File.Delete(s)
                End If
            Next

            '---------------------- save email --------------------------

            oReqSentMail = New cReqSentMails
            '    olstReqSentMails = New List(Of cReqSentMails)

            'where requestid = '" & RequestID & "' and reviewid = '" & ReviewId & 

            With oReqSentMail
                .RequestId = RequestID
                .ReviewID = ReviewId
                .SentTo = SentToCreator
                .HTMLdata = Message
                .Save()
            End With

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & ". CPT = " & CPT & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub RetriveCommentsAddInDB()
        Try
            ' If Trim(txtSendCommFromGraph.Text) = "" Or Trim(txtSpecInstrWrite.Text) = "" Then Exit Sub

            oReqCommunic = New cReqCommunication
            olstReqCommunic = New List(Of cReqCommunication)
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If oExact_Traveler_Permission.perm_group_id = 182 Then
                If Trim(txtSendCommFromGraph.Text) = "" Then Exit Sub
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182 ")
            Else
                If Trim(txtSpecInstrWrite.Text) = "" Then Exit Sub
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182) ")
            End If

            'in Exact_Traveler_Permission_Group Graphics is  ID - 182
            'and  if we want identify communication need check group_permission_id

            ' orderBy = olstReqCommunic.FindLast(Function(i As cReqCommunication) i.OrderBy).OrderBy

            oReqCommunic = New cReqCommunication
            With oReqCommunic
                .RequestId = RequestID
                .ReviewID = ReviewId
                .TypeId = oExact_Traveler_Permission.perm_group_id

                If olstReqCommunic.Count = 0 Then .OrderBy = olstReqCommunic.Count Else .OrderBy = CInt(olstReqCommunic.Item(olstReqCommunic.Count - 1).OrderBy + 1)
                If oExact_Traveler_Permission.perm_group_id <> 182 Then
                    If Trim(txtSpecInstrWrite.Text) <> "" Then .MessageInstruction = txtSpecInstrWrite.Text
                ElseIf oExact_Traveler_Permission.perm_group_id = 182 Then
                    If Trim(txtSendCommFromGraph.Text) <> "" Then .MessageInstruction = txtSendCommFromGraph.Text
                End If

                '  If Trim(.MessageInstruction) = "" Then Exit Sub

                If (Trim(.MessageInstruction) <> String.Empty Or Trim(txtSendCommFromGraph.Text) <> "") Then
                    'If chkSendToGraphic.CheckState = CheckState.Checked And Trim(xTxtShowSenderEmail.Text) <> String.Empty Then
                    '    .SentTo = Trim(xTxtShowSenderEmail.Text)
                    'End If

                    If .Save() = True Then
                        Call DisplayComments()
                        If oExact_Traveler_Permission.perm_group_id <> 182 Then
                            txtSpecInstrWrite.Text = ""
                        ElseIf oExact_Traveler_Permission.perm_group_id = 182 Then
                            txtSendCommFromGraph.Text = ""
                        End If
                    End If
                    'ElseIf chkSendToGraphic.CheckState = CheckState.Checked And Trim(xTxtShowSenderEmail.Text) <> String.Empty Then

                    '    .SentTo = Trim(xTxtShowSenderEmail.Text)
                    '    .Save()

                Else
                    Exit Sub
                End If

            End With

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'function is called only when request is reopened
    Public Sub RetriveCommentsFromCopy(ByVal intOldReviewId As Int32)
        Try
            ' If Trim(txtSendCommFromGraph.Text) = "" Or Trim(txtSpecInstrWrite.Text) = "" Then Exit Sub

            oReqCommunic = New cReqCommunication
            olstReqCommunic = New List(Of cReqCommunication)
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            'If oExact_Traveler_Permission.perm_group_id = 182 Then
            '    If Trim(txtSendCommFromGraph.Text) = "" Then Exit Sub
            '    olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182 ")
            'Else
            '    If Trim(txtSpecInstrWrite.Text) = "" Then Exit Sub
            '    olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182) ")
            'End If

            'load all comments from preview Request
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & intOldReviewId)

            If olstReqCommunic Is Nothing Then Exit Sub

            For Each comm As cReqCommunication In olstReqCommunic

                oReqCommunic = New cReqCommunication

                With oReqCommunic

                    .RequestId = RequestID
                    .ReviewID = ReviewId
                    .TypeId = comm.TypeId
                    .OrderBy = 0
                    .CreateBy = comm.CreateBy
                    .CreateByFullName = comm.CreateByFullName
                    .CreateDate = comm.CreateDate
                    .MessageInstruction = comm.MessageInstruction

                    .Save()
                End With

            Next

            'Show the comments
            'Call DisplayComments()
            'If oExact_Traveler_Permission.perm_group_id <> 182 Then
            '    txtSpecInstrWrite.Text = ""
            'ElseIf oExact_Traveler_Permission.perm_group_id = 182 Then
            '    txtSendCommFromGraph.Text = ""
            'End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplayComments()
        Try

            oReqCommunic = New cReqCommunication
            olstReqCommunic = New List(Of cReqCommunication)
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            '------------------------------- Display txtRecCommGraph --------------------------------
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")

            txtRecCommGraph.Text = ""

            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    txtRecCommGraph.Text &= comm.MessageInstruction & vbCrLf
                Next
            End If
            '----------------------------------------------------------------------------------------
            '------------------------------ Display txtSpecInstrReceive -----------------------------
            olstReqCommunic = New List(Of cReqCommunication)
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

            txtSpecInstrReceive.Text = ""

            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    txtSpecInstrReceive.Text &= comm.MessageInstruction & vbCrLf
                Next
            End If
            '----------------------------------------------------------------------------------------

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "-------------------------------------- Update in Review table ---------------------------"

    Private Sub ReviewUpdate()
        Try
            oReqRevision = New cReqRevision

            Dim strQuery As String = " WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId
            oReqRevision.Load(strQuery)
            oReqRevision.Rush_Order = chkRushOrder.CheckState
            oReqRevision.Save()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
    Private Sub txtbtnClose_Click(sender As Object, e As EventArgs) Handles txtbtnClose.Click
        Try
            'Dim olstReqIt As New List(Of cReqItems)

            'If (dgvStoryBoard.Rows.Count = 0 Or dgvStoryBoard.Rows.Count = 1) Then

            'End If

            'Select Case dgvStoryBoard.Rows.Count
            '    Case 0

            '    Case 1
            '        If dgvStoryBoard.Rows(0).Cells(Request.item_master_id).Value <> "" Then
            '            olstReqIt = TakeData_DGVStBoard()
            '        End If
            '    Case Else
            '        olstReqIt = TakeData_DGVStBoard()
            'End Select

            'If olstReqIt.Count <> 0 Then

            '    olstReqIt = TakeData_DGVStBoard()

            '    Dim val As IEnumerable(Of cReqItems) = olstReqItems_old.Except(olstReqIt)
            '    Dim varBl As Boolean = False


            '    If (olstReqIt.Count > olstReqItems_old.Count Or olstReqIt.Count < olstReqItems_old.Count) Then
            '        varBl = True 'true = need save request
            '    End If

            '    For Each reIt As cReqItems In olstReqIt
            '        Debug.Print(reIt.item_master_id)
            '        If olstReqItems_old.Find(Function(i As cReqItems) i.item_master_id = reIt.item_master_id And i.color_id = reIt.color_id And
            '                              i.dec_met_id = reIt.dec_met_id And i.imp_desc_id = reIt.imp_desc_id And i.patch_shape = reIt.patch_shape And
            '                              i.IMPRINT_COLOR = reIt.IMPRINT_COLOR And i.IMPRINT_LOGO = reIt.IMPRINT_LOGO And i.Patch_Color = reIt.Patch_Color And
            '                              i.Thread_Color = reIt.Thread_Color And i.BackGround_Color = reIt.BackGround_Color And
            '                              i.StampingPattern = reIt.StampingPattern) Is Nothing Then

            '            Dim result As Integer = MessageBox.Show("You made changes in Item Grid. You want save or Exit.", "Made changes!!!", MessageBoxButtons.YesNoCancel)
            '            If result = DialogResult.Cancel Then
            '                MessageBox.Show("Changes are not saved!!!")
            '            ElseIf result = DialogResult.No Then
            '                MessageBox.Show("Changes are not saved!!!")

            '            ElseIf result = DialogResult.Yes Then
            '                Try
            '                    Dim respons As String = ""
            '                    'function added for validate certaine label in in storyboard grid 
            '                    If ValidateDecoProperties(respons) <> True Then
            '                        If respons.Length > 0 Then
            '                            'message need to be revised
            '                            '      MsgBox(respons)

            '                            Dim result1 As DialogResult = MessageBox.Show(respons & vbCrLf & " --- REQUEST IS NOT SAVED!!! ---",
            '                    "--- REQUEST IS NOT SAVED!!! ---",
            '                    MessageBoxButtons.OK,
            '                    MessageBoxIcon.Hand,
            '                    MessageBoxDefaultButton.Button1,
            '                    MessageBoxOptions.DefaultDesktopOnly,
            '                    False)

            '                            Exit Sub
            '                        End If
            '                    End If
            '                    '-------------------------

            '                    Call SaveRequest()

            '                    Me.Close()

            '                    ' Exit Sub

            '                Catch ex As Exception
            '                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
            '                End Try
            '            End If

            '        End If
            '    Next

            'End If



            Me.Close()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '------------------------- write byte() in exactemp for add in email -----------------
    Private Function WriteInExact(ByRef m_name As String, ByRef m_byte As Byte()) As String
        WriteInExact = ""
        Try
            '  Dim byteStream As Byte()

            ' save document to file system

            Dim strSaveName As String = "C:\ExactTemp\" & m_name.Replace("?", "")  ' oDoc.Item_Doc_Name & "." & oDoc.Item_Doc_File_Ext

            If File.Exists(strSaveName) Then

            Else

                'byteStream = m_byte 'CType(oDoc.Item_Doc, Byte())

                If (Not Directory.Exists("C:\ExactTemp")) Then
                    Directory.CreateDirectory("C:\ExactTemp")
                End If

                Dim newFile As FileStream = File.Create(strSaveName)
                'newFile.Write(byteStream, 0, byteStream.Length)
                newFile.Write(m_byte, 0, m_byte.Length)

                newFile.Dispose()

            End If

            'If File.Exists("C:\ExactTemp\" & strSaveName) Then
            '    File.Delete("C:\ExactTemp\" & strSaveName)
            'End If
            Return strSaveName
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub xTxtShowSenderEmail_TextChanged(sender As Object, e As EventArgs) Handles xTxtShowSenderEmail.TextChanged
        Try
            If VarActivateEmailSearch = True Then
                'Activate View if Is more one character entered
                If Trim(xTxtShowSenderEmail.Text).Length > 1 And LoadVariable = False Then
                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False
                    Call Graphic_Lst()
                End If
                xTxtShowSenderEmail.Focus()
                xTxtShowSenderEmail.Select(50, 100)
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub xTxtShowSenderEmail_DoubleClick(sender As Object, e As EventArgs) Handles xTxtShowSenderEmail.DoubleClick
        Try
            'activate xTxtShowSenderEmail_TextChanged
            VarActivateEmailSearch = True

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub xTxtShowSenderEmail_LostFocus(sender As Object, e As EventArgs) Handles xTxtShowSenderEmail.LostFocus
        Try
            'activate xTxtShowSenderEmail_TextChanged
            '   VarActivateEmailSearch = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtCustomer.TextChanged
        Try
            'activate view if is more one character entered
            If Trim(txtCustomer.Text).Length > 1 And LoadVariable = False Then
                lstViewCustomerMiddle.Items.Clear()
                panMiddleLstViewCustomerShow.Visible = False
                Call Customer_Lst()
            Else
                lblCustomerName.Text = ""
                'If load all customers will take time 
                '   Call Customer_Lst()
            End If
            txtCustomer.Focus()
            txtCustomer.Select(50, 100)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtContactSearch_TextChanged(sender As Object, e As EventArgs) Handles txtContactSearch.TextChanged
        Try

            'activate view if is more one character entered
            If Trim(txtContactSearch.Text).Length > -1 And LoadVariable = False Then
                lstViewCustomerMiddle.Items.Clear()
                panMiddleLstViewCustomerShow.Visible = False
                Call Contact_Lst()
            End If
            txtContactSearch.Focus()
            txtContactSearch.Select(50, 100)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkSendToGraphic_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSendToGraphic.CheckStateChanged
        Try
            Dim keyword As String = ""


            If chkSendToGraphic.CheckState = CheckState.Checked Then
                xTxtShowSenderEmail.Visible = True
                xTxtShowSenderEmail.Focus()
                xTxtShowSenderEmail.Select(50, 100)


                If CInt(lblStoryBoard.Tag) = 22 Then ' StoryBoard Request
                    keyword = "stor"

                    For i As Int32 = 0 To keyword.Length - 1
                        For n As Int64 = 1 To 30000000
                            If n = 30000000 Then
                                xTxtShowSenderEmail.Text &= keyword(i)
                            End If
                        Next
                    Next

                    'put in comment because it will executed after exception finished
                    '  Call Graphic_Lst()

                ElseIf CInt(lblStoryBoard.Tag) = 23 Then ' Virtual Request
                    '++ID 4.15.2020 redirect mail from virtual  to story board during COVID19
                    ' keyword = "stor"
                    '06.09.2020
                    keyword = "virtual"

                    For i As Int32 = 0 To keyword.Length - 1
                        For n As Int64 = 1 To 30000000
                            If n = 30000000 Then
                                xTxtShowSenderEmail.Text &= keyword(i)
                            End If
                        Next
                    Next
                ElseIf CInt(lblStoryBoard.Tag) = 25 Then ' Virtual Request

                    keyword = "Flyers"

                    For i As Int32 = 0 To keyword.Length - 1
                        For n As Int64 = 1 To 30000000
                            If n = 30000000 Then
                                xTxtShowSenderEmail.Text &= keyword(i)
                            End If
                        Next
                    Next

                End If

                Call Graphic_Lst()

            Else

                VarActivateEmailSearch = False
                xTxtShowSenderEmail.Visible = False
                xTxtShowSenderEmail.Text = ""
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblTimeStampCS_Click(sender As Object, e As EventArgs) Handles lblTimeStampCS.Click
        Try
            txtSpecInstrWrite.Text &= GETTimestamp()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblTimeStampGR_Click(sender As Object, e As EventArgs) Handles lblTimeStampGR.Click
        Try
            txtSendCommFromGraph.Text &= GETTimestamp()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblBtnCloseLstW_Click(sender As Object, e As EventArgs) Handles lblBtnCloseLstW.Click


        Try

            Select Case CInt(lblMiddleLineNameDisplay.Tag)
                Case ListViewName.Customer   '0 Customer

                    With lblCustomerName
                        .Text = ""
                        .Tag = ""
                    End With

                    lnkLblContactShow.Text = "-"
                    lblContactEmail.Text = ""

                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""

                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False

                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False

                Case ListViewName.Contact ' 1 'Contact

                    '  lnkLblContactShow.Text = ""
                    '  lblContactEmail.Text = ""
                    txtContactSearch.Hide()
                    txtContactSearch.Text = String.Empty

                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""

                    lnkLabelAdditionalLoc.Visible = False

                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False

                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False

                Case ListViewName.Traveler_Users  ' 2
                    'deactivate xTxtMail... TextChanged
                    VarActivateEmailSearch = False

                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False

                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False



                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""

                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False

                    panLstBoxAdd.Hide()

                Case ListViewName.Additional_Location '3
                    '---------------------------
                    Try
                        For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                            dgv.Selected = False
                        Next
                        btnWebBrowser.Focus()
                        Dim respons As String = ""
                        'function added for validate certaine label in in storyboard grid 
                        If Validate_RequiredLabel_AdditLocation(respons) <> True Then
                                    If respons.Length > 0 Then
                                        Dim result1 As DialogResult = MessageBox.Show(respons,
                        "Warning.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly,
                        False)
                                        Exit Sub
                                    End If
                                End If


                        lblMiddleLineNameDisplay.Tag = -1
                        lblMiddleLineNameDisplay.Text = ""
                        txtBox.Text = ""
                        txtBox.Hide()
                        panLstBoxAdd.Hide()
                        lnkLabelAdditionalLoc.Visible = False
                        lblItemShowAdditLoc.Visible = False
                        lnkDeletelocation.Visible = False

                        panMiddleLstViewCustomerShow.Visible = False
                        lstViewCustomerMiddle.Items.Clear()
                      '  End If
                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try
                    '---------------------------
                Case ListViewName.BindeImage
                    Dim s As String = ""

                    For Each lstw As ListViewItem In lstViewCustomerMiddle.Items
                        s = lstw.SubItems(2).Text
                    Next

                    '  dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.IMP_DESCRIPTION).Selected = False

                    For Each dgv As DataGridViewRow In dgvStoryBoard.Rows
                        dgv.Selected = False
                    Next

                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""
                    txtBox.Text = ""
                    txtBox.Hide()
                    panLstBoxAdd.Hide()
                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False


                    lstViewCustomerMiddle.Items.Clear()
                    panMiddleLstViewCustomerShow.Visible = False


            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    '----------------------------- LISTVIEW ADDITIONAL DECO METH,LOCATION AND OTHER INFORMATIONS --------------------------------
    '++ID 1.16.2018 start work
    Private oReqItems_AdditDetail_Work As cReqItems_AdditLocation
    Private olstReItems_AdditDetail_Work As List(Of cReqItems_AdditLocation)
    Public Sub Additional_Lst(ByVal p_strReqItemGuid As String, ByRef olst_ReqItemsDGV As List(Of cReqItems), Optional ByVal p_intReqItemId As Int32 = 0, Optional ByVal p_strReqItemGuidParent As String = "") 'parent for check if is kit
        'olst_ReqItemsDGV -> took data from grid
        Try

            lblMiddleLineNameDisplay.Text = ListViewName.Additional_Location.ToString & "-" & ListViewName.Additional_Location
            lblMiddleLineNameDisplay.Tag = ListViewName.Additional_Location

            Dim oEnum As New cReqItems_AdditLocation
            Dim mItemNo As String = ""
            Dim addline As Boolean = True
            'lstBoxAdd.Hide()
            'panLstBoxAdd.Hide()
            'txtBox.Hide()
            'added only modify rows size
            ImgList = New ImageList With {.ImageSize = New Size(15, 15)}

            ' the List ->  olstReItems_AdditDetail_Work come from -> added handler after right click on the imp_loc_id on the grid TSM_Click already filtered for this ReqItemId 
            'for the name of lstview I need create Enum function or create global Constant for identify more easy what did we open. 
            'If Not olstReItems_AdditDetail_Work.Find(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = p_strReqItemGuid) Is Nothing Then
            '    'samething I can retrivereqItemsId from CInt(dgvStoryBoard.CurrentRow.Cells(Request.x).Tag)

            '    'was added validation for not add double empty line when listview is called
            '    'false this means like exist one empty line
            '    'true all line are full
            '    For Each addit As cReqItems_AdditLocation In olstReItems_AdditDetail_Work
            '        If addit.dec_met_id = 0 Then
            '            addline = False
            '        End If
            '    Next

            '    If addline <> False Then
            '        'If nothing found for this request add new line in List for use in view
            '        'after that  
            '        oEnum = New cReqItems_AdditLocation
            '        'for know in which row enter Enum 

            '        oEnum.ReqItemGuid = p_strReqItemGuid
            '        'take ReqItemId if is saved info if not take 0, when request will be saved ReqItemId will be added.
            '        If Not olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid) Is Nothing Then oEnum.ReqItemId = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).ReqItemId
            '        'insert 
            '        olstReItems_AdditDetail_Work.Insert((olstReItems_AdditDetail_Work.Count - 1) + 1, oEnum)
            '    End If

            'Else

            '    oEnum = New cReqItems_AdditLocation
            '    oEnum.ReqItemGuid = p_strReqItemGuid
            '    'take ReqItemId if is saved info if not take 0, when request will be saved ReqItemId will be added.
            '    If Not olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid) Is Nothing Then oEnum.ReqItemId = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).ReqItemId
            '    'insert 
            '    olstReItems_AdditDetail_Work.Insert(0, oEnum)

            'End If

            mItemNo = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).item_no

            panMiddleLstViewCustomerShow.Visible = True

            panMiddleLstViewCustomerShow.Width = 1000
            panMiddleLstViewCustomerShow.Left = 100 'normaly is 239

            lstViewCustomerMiddle.Items.Clear()

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()


            With lstViewCustomerMiddle
                .SmallImageList = ImgList
                .CheckBoxes = False
                .Height = 10
                .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .Columns.Clear() ' make sure collumnscollection is empty
                ' Add 3 columns
                .Columns.AddRange(New ColumnHeader() {listColumns(ReqItem_AdditLoc.Additional_id.ToString, ReqItem_AdditLoc.Additional_id.ToString, HorizontalAlignment.Left, 0),
                                                      listColumns(ReqItem_AdditLoc.ReqItemId.ToString, ReqItem_AdditLoc.ReqItemId.ToString, HorizontalAlignment.Left, 0),
                                                      listColumns(ReqItem_AdditLoc.ReqItemGuid.ToString, ReqItem_AdditLoc.ReqItemGuid.ToString, HorizontalAlignment.Left, 0),
                                                      listColumns(ReqItem_AdditLoc.Dec_met_id.ToString, ReqItem_AdditLoc.Dec_met_id.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Imp_desc_id.ToString, ReqItem_AdditLoc.Imp_desc_id.ToString, HorizontalAlignment.Left, 100),
                                                       listColumns(ReqItem_AdditLoc.Imprint_Color.ToString, ReqItem_AdditLoc.Imprint_Color.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Imprint_Logo.ToString, ReqItem_AdditLoc.Imprint_Logo.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Patch_Shape.ToString, ReqItem_AdditLoc.Patch_Shape.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Patch_Color.ToString, ReqItem_AdditLoc.Patch_Color.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Thread_Color.ToString, ReqItem_AdditLoc.Thread_Color.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.BackGround_Color.ToString, ReqItem_AdditLoc.BackGround_Color.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.StampingPattern.ToString, ReqItem_AdditLoc.StampingPattern.ToString, HorizontalAlignment.Left, 100),
                                                      listColumns(ReqItem_AdditLoc.Guid.ToString, ReqItem_AdditLoc.Guid.ToString, HorizontalAlignment.Left, 0),
                                                      listColumns(ReqItem_AdditLoc.ReqItemComm.ToString, ReqItem_AdditLoc.ReqItemComm.ToString, HorizontalAlignment.Left, 100)})
                '  .FullRowSelect = False
                .GridLines = True
                .LabelEdit = False
                .AllowColumnReorder = True
                .Sorting = SortOrder.Ascending
                .AllowColumnReorder = True
                ' .HideSelection = False

            End With

            'For Each oCust As cCicmpy In olsCicmpy
            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
            'Next
            '   olstReItems_AdditDetail_Work.Sort(olstReItems_AdditDetail_Work)
            'I need make sort order by additional id
            olstReItems_AdditDetail_Work.OrderBy(Function(i As cReqItems_AdditLocation) i.Additional_ID)

            For Each oAdditional As cReqItems_AdditLocation In olstReItems_AdditDetail_Work
                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem
                item(UBound(item)).Text = Trim(oAdditional.Additional_ID).ToString

                item(UBound(item)).SubItems.Add(Trim(oAdditional.ReqItemId).ToString)

                item(UBound(item)).SubItems.Add(Trim(oAdditional.ReqItemGuid).ToString)

                item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.dec_met_id, CInt(ReqItem_AdditLoc.Dec_met_id))).Tag = oAdditional.dec_met_id

                item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.imp_desc_id, CInt(ReqItem_AdditLoc.Imp_desc_id))).Tag = oAdditional.imp_desc_id

                item(UBound(item)).SubItems.Add(Trim(oAdditional.IMPRINT_COLOR).ToString)
                item(UBound(item)).SubItems.Add(Trim(oAdditional.IMPRINT_LOGO).ToString)

                ' item(UBound(item)).SubItems.Add(Trim(ReturnAreaSize(olst_ReqItemsDGV, oAdditional.dec_met_id, oAdditional.imp_desc_id, reqItemsGuid).ToString))

                'for the patch in the function put dec_met_id for identify if is 88 (brand patch),131(etc),133(etc)
                Select Case oAdditional.dec_met_id
                    Case 88, 131, 133, 138
                        item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.patch_shape, CInt(ReqItem_AdditLoc.Patch_Shape))).Tag = oAdditional.patch_shape '(Trim(oAdditional.patch_shape).ToString)
                        item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.Patch_Color, CInt(ReqItem_AdditLoc.Patch_Color), oAdditional.dec_met_id)).Tag = oAdditional.Patch_Color 'Trim(oAdditional.Patch_Color).ToString)

                        item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.Thread_Color, CInt(ReqItem_AdditLoc.Thread_Color), oAdditional.dec_met_id)).Tag = oAdditional.Thread_Color 'Trim(oAdditional.Thread_Color).ToString)
                        item(UBound(item)).SubItems.Add(Trim(oAdditional.BackGround_Color).ToString)
                        item(UBound(item)).SubItems.Add(Trim(oAdditional.StampingPattern).ToString)

                    Case Else
                        item(UBound(item)).SubItems.Add(Trim("-").ToString)
                        item(UBound(item)).SubItems.Add(Trim("-").ToString)
                        item(UBound(item)).SubItems.Add(Trim("-").ToString)
                        item(UBound(item)).SubItems.Add(Trim("-").ToString)
                        item(UBound(item)).SubItems.Add(Trim("-").ToString)

                End Select
                ' item(UBound(item)).SubItems.Add(ReturnValueString(oAdditional.patch_shape, CInt(ReqItem_AdditLoc.Patch_Shape))).Tag = oAdditional.patch_shape '(Trim(oAdditional.patch_shape).ToString)
                ' item(UBound(item)).SubItems.Add(Trim(oAdditional.Patch_Color).ToString)


                item(UBound(item)).SubItems.Add(Trim(oAdditional.GUID).ToString)
                item(UBound(item)).SubItems.Add(Trim(oAdditional.ReqItemComm).ToString)
                Items.Add(item(UBound(item)))
            Next

            lstViewCustomerMiddle.BeginUpdate()
            'lstViewCustomerMiddle.Items.AddRange(Items.ToArray)
            '  Items.Sort(Function(i As ListViewItem, x As ListViewItem) i.SubItems(ReqItem_AdditLoc.Additional_id))



            lstViewCustomerMiddle.Items.AddRange(Items.ToArray)
            '   lstViewCustomerMiddle.Sort()

            lstViewCustomerMiddle.EndUpdate()
            lstViewCustomerMiddle.Visible = True
            lstViewCustomerMiddle.Focus()


            lnkLabelAdditionalLoc.Visible = True 'this label is only for Additional display
            lblMiddleLineFound.Text = Items.Count & " rows"
            lnkDeletelocation.Visible = True
            lblItemShowAdditLoc.Visible = True
            lblItemShowAdditLoc.Text = mItemNo
            Call ListView_RowsColor(lstViewCustomerMiddle)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '----- function for return string of value id , it used in Additional_Lst for populate field decoratin, location patches -----
    Private Function ReturnValueString(ByVal value_id As Int32, ByVal identifiant As Int32, Optional ByVal pDec_Met As Int32 = 0) As String 'identifiant use ReqItem_AdditLoc Enum
        ReturnValueString = String.Empty
        Try

            Select Case identifiant
                Case CInt(ReqItem_AdditLoc.Dec_met_id)
                    oMDB_CFG_DEC_MET = New cMDB_CFG_DEC_MET
                    oMDB_CFG_DEC_MET.Load(value_id)
                    ReturnValueString = oMDB_CFG_DEC_MET.DEC_MET_NAME
                Case CInt(ReqItem_AdditLoc.Imp_desc_id)
                    oMDB_CFG_IMP_LOC = New cMDB_CFG_IMP_LOC
                    oMDB_CFG_IMP_LOC.Load(value_id)
                    ReturnValueString = oMDB_CFG_IMP_LOC.IMP_DESC
                Case CInt(ReqItem_AdditLoc.Patch_Shape)
                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)
                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                    If olsCfgEnum.Count <> 0 Then
                        ReturnValueString = olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = value_id).Enum_Value
                    End If
                Case CInt(ReqItem_AdditLoc.Patch_Color), CInt(ReqItem_AdditLoc.Thread_Color)
                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)

                    If (pDec_Met = 88 Or pDec_Met = 131 Or pDec_Met = 138) Then
                        olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08BP44")
                    ElseIf pDec_Met = 133 Then
                        olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                    End If
                    If Not olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = value_id) Is Nothing Then ReturnValueString = olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = value_id).Enum_Value
            End Select

            Return ReturnValueString

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function ReturnAreaSize(ByRef olst_ReqItemsDGV As List(Of cReqItems), ByVal dec_meth As Int32, ByVal imp_loc As Int32, ByVal p_strReqItemGuid As String) As String
        ReturnAreaSize = String.Empty
        Try
            Dim valArea As String = ""

            Dim oMdb_Item_Imp_Loc_VIEW As cMdb_Item_Imp_Loc_VIEW
            Dim olstImp_Loc_VIEW As List(Of cMdb_Item_Imp_Loc_VIEW)
            Dim pitem_master_id As Int32 = 0
            Dim p_parentItemMaster As Int32 = 0


            If olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).parent_guid = "" Then
                If dec_meth <> 0 AndAlso imp_loc <> 0 Then

                    oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                    olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                    pitem_master_id = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).item_master_id
                    olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(pitem_master_id)
                    If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = dec_meth And i.Imp_Loc_Id = imp_loc) Is Nothing Then
                        'return value area size
                        valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = dec_meth And i.Imp_Loc_Id = imp_loc).AREA_SIZE
                    End If
                End If
            ElseIf olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).parent_guid <> "" Then
                If dec_meth <> 0 AndAlso imp_loc <> 0 Then
                    oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                    olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)
                    '++ID 1.22.2018
                    Dim pitem_parentGuid = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).parent_guid

                    p_parentItemMaster = olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = pitem_parentGuid).item_master_id

                    'variable filled in TSM_Click -> reqItemsGuidParent but we can use -> p_parentItemMaster from above
                    olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(p_parentItemMaster, olst_ReqItemsDGV.Find(Function(c As cReqItems) c.GUID = p_strReqItemGuid).item_master_id, dec_meth)

                    If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = dec_meth And i.Imp_Loc_Id = imp_loc) Is Nothing Then
                        'return value area size
                        valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = dec_meth And i.Imp_Loc_Id = imp_loc).AREA_SIZE
                    End If
                End If
            End If
            Return valArea
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub dgvStoryBoard_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStoryBoard.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex >= 0 Then
            dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            dgvStoryBoard.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = "1"
            'if possible insert code here to read selected option from context menu and get relevant content from respective cell

        End If
    End Sub
    Private Sub dgvStoryBoard_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvStoryBoard.MouseDown
        Try
            'first event pass in Mouse dow after go to mouse click
            'unselect the rows in grid 
            'in Mouse click selected row will take color
            For Each dgvS As DataGridViewRow In dgvStoryBoard.Rows
                dgvS.Selected = False
            Next
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private MnuStrip As New ContextMenuStrip
    Private TSM As New ToolStripMenuItem

    Private Sub dgvStoryBoard_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvStoryBoard.MouseClick
        Try
            Dim dgv As DataGridView = sender
            MnuStrip = New ContextMenuStrip

            Dim ht As DataGridView.HitTestInfo

            ht = dgv.HitTest(e.X, e.Y)
            If ht.RowIndex = -1 Then Exit Sub
            If dgvStoryBoard.Rows(ht.RowIndex).Cells(Request.item_cd).Value = "" Then
                Exit Sub
            End If

            panItemComment.Visible = False
            If dgvStoryBoard.RowCount <> 0 And String.IsNullOrEmpty(Trim(xTxtItemComment.Tag)) = False Then ' And String.IsNullOrEmpty(Trim(dgvStoryBoard.Rows(CInt(xTxtItemComment.Tag)).Cells(Request.ReqItemComm).Value)) = False Then
                dgvStoryBoard.Rows(CInt(xTxtItemComment.Tag)).Cells(Request.ReqItemComm).Value = xTxtItemComment.Text
            End If
            '  xTxtItemComment.Text = String.Empty

            If e.Button = Windows.Forms.MouseButtons.Right Then
                'loop unselect the rows in grid
                'For Each dgvS As DataGridViewRow In dgvStoryBoard.Rows
                '    dgvS.Selected = False
                'Next

                Select Case ht.ColumnIndex
                    Case Request.IMP_DESCRIPTION

                        'check if line is item kit exit from sub because item  has not decorating with location
                        If dgv.Rows(ht.RowIndex).Cells(Request.Is_kit).Value = "K" Then Exit Sub

                        dgv.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                        dgv.Rows(ht.RowIndex).Selected = True

                        TSM = New ToolStripMenuItem
                        TSM.Name = "tsmLocation"
                        TSM.Text = "Add Another Location."
                        TSM.Tag = ht.RowIndex.ToString
                        MnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {TSM})

                    Case Request.IMPRINT_LOGO

                        'check if line is item kit exit from sub because item  has not decorating with location
                        If dgv.Rows(ht.RowIndex).Cells(Request.Is_kit).Value = "K" Then Exit Sub

                        dgv.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Selected = True
                        dgv.Rows(ht.RowIndex).Selected = True

                        TSM = New ToolStripMenuItem
                        TSM.Name = "tsmDocument"
                        TSM.Text = "Document File"
                        TSM.Tag = ht.RowIndex.ToString
                        MnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {TSM})

                End Select

                MnuStrip.Show(dgv, New Point(e.X, e.Y))
                AddHandler TSM.Click, AddressOf TSM_Click

            ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                '  MsgBox("Data from Column ." & Request.ReqItemId.ToString & "-" & dgvStoryBoard.Rows(0).Cells(CInt(Request.ReqItemId)).Value.ToString)
                Select Case ht.ColumnIndex
                    Case Request.ReqItemComm
                        panItemComment.Visible = True
                        xTxtItemComment.Text = dgv.Rows(ht.RowIndex).Cells(ht.ColumnIndex).Value
                        'put in tag rowindex , because when it will return value in grid we need know in which row put data
                        xTxtItemComment.Tag = ht.RowIndex

                End Select

            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private reqItemsId As Int32
    Private reqItemsGuid As String
    Private reqItemsGuidParent As String
    Private Sub TSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '   MsgBox("ToolStripMenu1")

            If TSM.Text <> "Document File" Then

                'Use objects in below function
                'are declared like private objects in same file frmVirtual_Request
                oReqItems_AdditDetail_Work = New cReqItems_AdditLocation
                olstReItems_AdditDetail_Work = New List(Of cReqItems_AdditLocation)

                'initialise variable, them are used only in that event for additional imprint location
                reqItemsId = 0
                reqItemsGuid = String.Empty
                reqItemsGuidParent = String.Empty
                'assigne variable
                'TSM.Tag have info about rowindex which was  clicked with right click in dgvStoryBoard_MouseClick

                If Not dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.ReqItemId)).Value Is Nothing Then
                    If CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.ReqItemId)).Value) <> 0 Then reqItemsId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)
                End If

                reqItemsGuid = Trim(CStr(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.GUID).Value.ToString))

                'If Not dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value Is Nothing Then
                'True is  NullAnd Empty
                'False is filled
                If String.IsNullOrEmpty(Trim(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value.ToString)) <> True Then
                    '  If dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value.ToString <> String.Empty Then
                    reqItemsGuidParent = Trim(CStr(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value.ToString))
                    '   End If
                End If
                'olstReItems_AdditDetail is loaded when program is started
                If Not olstReItems_AdditDetail Is Nothing Then
                    If olstReItems_AdditDetail.Count <> 0 Then
                        If Not olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = reqItemsGuid) Is Nothing Then
                            olstReItems_AdditDetail_Work = olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = reqItemsGuid)
                        End If
                    End If
                End If

                'if we have records for this line, take it.

                'call function for open additional Imrint Location
                Call Additional_Lst(reqItemsGuid, TakeData_DGVStBoard, reqItemsId, reqItemsGuidParent)

            Else 'if is Document File   because we have only two option

                'If Not dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.ReqItemId)).Value Is Nothing Then
                '    If CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.ReqItemId)).Value) <> 0 Then
                '        reqItemsId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)
                '    Else
                '        MsgBox("Request need to be saved before bind addded documents")
                '        Exit Sub
                '    End If

                '    'if is nothng need to be 0
                '    reqItemsId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)
                '    reqItemsGuid = dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.GUID)).Value

                '    'add function for display documents
                '    Call BindItem_Image()
                'End If

                reqItemsId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)
                reqItemsGuid = dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(CInt(Request.GUID)).Value

                Call DocumentsAddDB()

                'add function for display documents
                Call BindItem_Image(reqItemsGuid)

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private CurrentSB As ListViewItem.ListViewSubItem
    Private CurrentItem As ListViewItem
    ' Private txtBox As TextBox
    Private bCancelEdit As Boolean = False
    Private Sub lstViewCustomerMiddle_MouseClick(sender As Object, e As MouseEventArgs) Handles lstViewCustomerMiddle.MouseClick
        Try

            Dim lstview As ListView = sender
            Dim iSubIndex As Integer

            'lblMiddleLineNameDisplay.Text = ListViewName.Additional_Location.ToString & "-" & ListViewName.Additional_Location
            'lblMiddleLineNameDisplay.Tag = ListViewName.Additional_Location
            Select Case lblMiddleLineNameDisplay.Tag
                Case ListViewName.Additional_Location
                    Try
                        txtBox.Hide()
                        Dim list_DGVStBoard As List(Of cReqItems) = New List(Of cReqItems)

                        'private variable reqItemsGuid come from TSM_Click
                        list_DGVStBoard = TakeData_DGVStBoard()

                        ' If Not TakeData_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid) Is Nothing Then
                        If Not list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid) Is Nothing Then

                            Dim osltMdb_Item_Im_Loc_View As List(Of cMdb_Item_Imp_Loc_VIEW)
                            Dim listArray As New ArrayList()
                            CurrentItem = New ListViewItem
                            CurrentSB = New ListViewItem.ListViewSubItem
                            '    txtBox = New TextBox

                            Dim lLeft As Integer
                            Dim lWidth As Integer
                            Dim pItem_master_id As Int32 = 0
                            Dim pItem_master_component_id As Int32 = 0
                            Dim pstrParentGuid As String = ""

                            If lstview.SelectedItems.Count >= 0 Then

                                CurrentItem = lstViewCustomerMiddle.GetItemAt(e.X, e.Y) ' which listviewitem was clicked

                                If CurrentItem Is Nothing Then Exit Sub

                                CurrentSB = CurrentItem.GetSubItemAt(e.X, e.Y) ' which subitem was clicked

                                ' See which column has been clicked

                                ' NOTE: This portion is important. Here you can define your own
                                '       rules as to which column can be edited and which cannot.
                                iSubIndex = CurrentItem.SubItems.IndexOf(CurrentSB)

                                If iSubIndex = 0 Then
                                    ' There's a slight coding difficulty here. If the first item is to be edited
                                    ' then when you get the Bounds of the first subitem, it returns the Bounds of
                                    ' the entire ListViewItem. Hence the Textbox looks very wierd. In order to allow
                                    ' editing on the first column, we use the built-in editing method.

                                    CurrentItem.BeginEdit()     ' make sure the LabelEdit is set to True
                                    lnkLabelAdditionalLoc.Focus()
                                    Exit Sub
                                End If

                                lLeft = CurrentSB.Bounds.Left + 2
                                lWidth = CurrentSB.Bounds.Width

                                Select Case iSubIndex
                                    Case ReqItem_AdditLoc.Dec_met_id, ReqItem_AdditLoc.Imp_desc_id, ReqItem_AdditLoc.Patch_Shape, ReqItem_AdditLoc.Patch_Color, ReqItem_AdditLoc.Thread_Color
                                        ' These  olumns are allowed to be edited. So continue the code
                                        'lisBox will be added for this four index

                                        Select Case iSubIndex
                                            Case ReqItem_AdditLoc.Dec_met_id
                                                'exception work only if item_master_id is in.
                                                '---- item kit never will arrive in this exception , because item kit has not location with decoration
                                                If Not list_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid And c.parent_guid <> "") Is Nothing Then 'if is component of the kit

                                                    'component -> item_master_id 
                                                    pItem_master_component_id = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).item_master_id

                                                    'take parent guid for find parent item_master_id
                                                    pstrParentGuid = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).parent_guid

                                                    'also in the grid column Parent guid contein in the Tag Item_Mater_Id from kit parent
                                                    'search parent item master id 
                                                    pItem_master_id = list_DGVStBoard.Find(Function(c As cReqItems) c.GUID = pstrParentGuid).item_master_id

                                                    'now with item_master_id I can populate deco metod for this item
                                                    'i need identify also if is kit component
                                                    'I need use regular function for populate combobox 

                                                    '-------------------------------------------------------------------------
                                                    osltMdb_Item_Im_Loc_View = New List(Of cMdb_Item_Imp_Loc_VIEW)
                                                    'distinct sort  olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                                                    '  osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id))

                                                    osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMetCompListCBO(CInt(pItem_master_id), CInt(pItem_master_component_id))

                                                    If osltMdb_Item_Im_Loc_View.Count <> 0 Then
                                                        listArray = New ArrayList()
                                                        For Each decor As cMdb_Item_Imp_Loc_VIEW In osltMdb_Item_Im_Loc_View
                                                            If decor.Dec_Met_Id <> 0 Then listArray.Add(New ListPopulate(decor.Dec_Met_Id, decor.Dec_Met_Desc))
                                                        Next
                                                    End If
                                                Else
                                                    'if is regular item
                                                    pItem_master_id = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).item_master_id
                                                    'now with item_master_id I can populate deco metod for this item
                                                    'i need identify also if is kit component
                                                    'I need use regular function for populate combobox 

                                                    '-------------------------------------------------------------------------
                                                    osltMdb_Item_Im_Loc_View = New List(Of cMdb_Item_Imp_Loc_VIEW)
                                                    'distinct sort  olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                                                    '  osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id))

                                                    osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMetListCBO(CInt(pItem_master_id))

                                                    If osltMdb_Item_Im_Loc_View.Count <> 0 Then
                                                        listArray = New ArrayList()
                                                        For Each decor As cMdb_Item_Imp_Loc_VIEW In osltMdb_Item_Im_Loc_View
                                                            If decor.Dec_Met_Id <> 0 Then listArray.Add(New ListPopulate(decor.Dec_Met_Id, decor.Dec_Met_Desc))
                                                        Next

                                                    End If
                                                End If
                                  '-------------------------------------------------------------------------
                                  ' End If
                                            Case ReqItem_AdditLoc.Imp_desc_id
                                                '-----------------------------------------------------
                                                'exception work only if item_master_id is in.
                                                '---- item kit never will arrive in this exception , because item kit has not location with decoration
                                                If Not list_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid And c.parent_guid <> "") Is Nothing Then 'if is component of the kit

                                                    'component -> item_master_id 
                                                    pItem_master_component_id = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).item_master_id

                                                    'take parent guid for find parent item_master_id
                                                    pstrParentGuid = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).parent_guid

                                                    'also in the grid column Parent guid contein in the Tag Item_Mater_Id from kit parent
                                                    'search parent item master id 
                                                    pItem_master_id = list_DGVStBoard.Find(Function(c As cReqItems) c.GUID = pstrParentGuid).item_master_id

                                                    'now with item_master_id I can populate deco metod for this item
                                                    'i need identify also if is kit component
                                                    'I need use regular function for populate combobox 

                                                    '-------------------------------------------------------------------------
                                                    osltMdb_Item_Im_Loc_View = New List(Of cMdb_Item_Imp_Loc_VIEW)
                                                    'distinct sort  olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                                                    '  osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id))

                                                    '   osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMetCompListCBO(CInt(pItem_master_id), CInt(pItem_master_component_id))

                                                    osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(CInt(pItem_master_id), CInt(pItem_master_component_id),
                                                                                                                  CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag))

                                                    If osltMdb_Item_Im_Loc_View.Count <> 0 Then
                                                        listArray = New ArrayList()
                                                        For Each decor As cMdb_Item_Imp_Loc_VIEW In osltMdb_Item_Im_Loc_View
                                                            If decor.Dec_Met_Id <> 0 Then listArray.Add(New ListPopulate(decor.Imp_Loc_Id, decor.Imp_Loc_Desc))
                                                        Next
                                                    End If
                                                Else
                                                    'if is regular item
                                                    pItem_master_id = list_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid).item_master_id
                                                    'now with item_master_id I can populate deco metod for this item
                                                    'i need identify also if is kit component
                                                    'I need use regular function for populate combobox 

                                                    '-------------------------------------------------------------------------
                                                    osltMdb_Item_Im_Loc_View = New List(Of cMdb_Item_Imp_Loc_VIEW)
                                                    'distinct sort  olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                                                    '  osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VColor.Item_Master_Id))

                                                    osltMdb_Item_Im_Loc_View = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(pItem_master_id), CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag))

                                                    If osltMdb_Item_Im_Loc_View.Count <> 0 Then
                                                        listArray = New ArrayList()
                                                        For Each decor As cMdb_Item_Imp_Loc_VIEW In osltMdb_Item_Im_Loc_View
                                                            If decor.Dec_Met_Id <> 0 Then listArray.Add(New ListPopulate(decor.Imp_Loc_Id, decor.Imp_Loc_Desc))
                                                        Next
                                                    End If
                                                End If
                                    '-----------------------------------------------------
                                            Case ReqItem_AdditLoc.Patch_Shape
                                                Select Case CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag)

                                                    Case 88, 133, 131, 138
                                                        ' 88-BRAND PATCH, 131-4CP BRAND PATCH, 133-BRAND SHIELD
                                                        oCfgEnum = New cCfgEnum
                                                        olsCfgEnum = New List(Of cCfgEnum)
                                                        olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                                                        If olsCfgEnum.Count <> 0 Then

                                                            listArray = New ArrayList()
                                                            For Each patch As cCfgEnum In olsCfgEnum
                                                                listArray.Add(New ListPopulate(patch.Enum_ID, patch.Enum_Value))
                                                            Next
                                                        Else
                                                            listArray = New ArrayList()
                                                        End If
                                                End Select
                                            Case ReqItem_AdditLoc.Patch_Color, ReqItem_AdditLoc.Thread_Color
                                                oCfgEnum = New cCfgEnum
                                                olsCfgEnum = New List(Of cCfgEnum)

                                                If (CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag) = 88 Or
                                                    CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag) = 131 Or
                                                    CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag) = 138) Then
                                                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08BP44")
                                                ElseIf CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag) = 133 Then
                                                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                                                End If

                                                If olsCfgEnum.Count <> 0 Then
                                                    listArray = New ArrayList()
                                                    For Each patch As cCfgEnum In olsCfgEnum
                                                        listArray.Add(New ListPopulate(patch.Enum_ID, patch.Enum_Value))
                                                    Next
                                                End If
                                        End Select
                                        '------------------- fill and show listbox ,etc----------------------

                                        Select Case iSubIndex
                                            Case ReqItem_AdditLoc.Dec_met_id, ReqItem_AdditLoc.Imp_desc_id
                                                txtBox.Hide()

                                                With lstBoxAdd
                                                    ' .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                                    'lstViewCustomerMiddle.Top, lWidth + 40, CurrentSB.Bounds.Height + 100)
                                                    .Width = lWidth + 60
                                                    .Show()
                                                    .Focus()
                                                    .BackColor = Color.Beige  'color only for check 
                                                    .ForeColor = Color.Black
                                                    .ScrollAlwaysVisible = True

                                                    .DataSource = listArray
                                                    .DisplayMember = "Value"
                                                    .ValueMember = "ID"
                                                    .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                                                End With
                                                With panLstBoxAdd
                                                    .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                           lstViewCustomerMiddle.Top + 15, lWidth + 70, CurrentSB.Bounds.Height + 120)
                                                    .Show()
                                                    '.Focus()
                                                End With
                                            Case ReqItem_AdditLoc.Patch_Shape, ReqItem_AdditLoc.Patch_Color, ReqItem_AdditLoc.Thread_Color

                                                Select Case CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag)
                                                    Case 88, 131, 133, 138
                                                        txtBox.Hide()

                                                        With lstBoxAdd
                                                            ' .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                                            'lstViewCustomerMiddle.Top, lWidth + 40, CurrentSB.Bounds.Height + 100)
                                                            .Show()
                                                            .Focus()
                                                            .BackColor = Color.Beige  'color only for check 
                                                            .ForeColor = Color.Black
                                                            .ScrollAlwaysVisible = True

                                                            .DataSource = listArray
                                                            .DisplayMember = "Value"
                                                            .ValueMember = "ID"
                                                            .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                                                        End With
                                                        With panLstBoxAdd
                                                            .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                           lstViewCustomerMiddle.Top + 15, lWidth + 70, CurrentSB.Bounds.Height + 120)
                                                            .Show()
                                                            '.Focus()
                                                        End With

                                                End Select
                                        End Select
                                    Case ReqItem_AdditLoc.Imprint_Color, ReqItem_AdditLoc.Imprint_Logo

                                        lstBoxAdd.Hide()
                                        panLstBoxAdd.Hide()

                                        ' These  columns are allowed to be edited. So continue the code
                                        'text box added for two index
                                        With txtBox
                                            .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                   lstViewCustomerMiddle.Top, lWidth, CurrentSB.Bounds.Height)
                                            .Text = CurrentSB.Text
                                            .Show()
                                            .Select(0, 0)
                                            '.Focus()
                                            .BackColor = Color.Beige
                                            .ForeColor = Color.Black
                                            .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                                        End With
                                    Case ReqItem_AdditLoc.BackGround_Color, ReqItem_AdditLoc.StampingPattern

                                        lstBoxAdd.Hide()
                                        panLstBoxAdd.Hide()
                                        Select Case CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag)
                                            Case 88, 131, 133, 138
                                                ' These  columns are allowed to be edited. So continue the code
                                                'text box added for two index
                                                With txtBox
                                                    .SetBounds(lLeft + lstViewCustomerMiddle.Left, CurrentSB.Bounds.Top +
                                            lstViewCustomerMiddle.Top, lWidth, CurrentSB.Bounds.Height)
                                                    .Text = CurrentSB.Text
                                                    .Show()
                                                    '.Focus()
                                                    .BackColor = Color.Beige
                                                    .ForeColor = Color.Black
                                                    .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                                                End With

                                        End Select
                                           '++ID 4.16.2018   
                                    Case ReqItem_AdditLoc.ReqItemComm
                                                lstBoxAdd.Hide()
                                                panLstBoxAdd.Hide()

                                                ' These  columns are allowed to be edited. So continue the code
                                                'text box added for two index
                                                With txtBox
                                            .SetBounds(lLeft + (lstViewCustomerMiddle.Left) - 200, CurrentSB.Bounds.Top +
                                   (lstViewCustomerMiddle.Top + 20), lWidth, CurrentSB.Bounds.Height)
                                            .Text = CurrentSB.Text
                                                    .Width = 283
                                            .Height = 179
                                            .Multiline = True
                                            .Show()
                                                    .Select(0, 0)
                                                    '.Focus()
                                                    .BackColor = Color.Beige
                                                    .ForeColor = Color.Black
                                                    .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                                                End With
                                            Case Else
                                                ' In my example I have defined that only "Runs"
                                                ' and "Wickets" columns can be edited by user
                                                panLstBoxAdd.Hide()
                                                lstBoxAdd.Hide()
                                                Exit Sub
                                        End Select
                             End If
                        Else

                        End If '  If Not TakeData_DGVStBoard.Find(Function(i As cReqItems) i.GUID = reqItemsGuid) Is Nothing Then

                    Catch ex As Exception
                        MsgBox("Error in " & Me.Name & ". MANAGE: " & ListViewName.Additional_Location.ToString & "-" & ListViewName.Additional_Location & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                    End Try

                Case ListViewName.BindeImage

                    'CurrentItem = New ListViewItem
                    'CurrentSB = New ListViewItem.ListViewSubItem

                    'CurrentItem = lstViewCustomerMiddle.GetItemAt(e.X, e.Y) ' which listviewitem was clicked
                    'If CurrentItem Is Nothing Then Exit Sub

                    '' See which column has been clicked
                    'iSubIndex = CurrentItem.SubItems.IndexOf(CurrentSB)


                    'If iSubIndex = 0 Then

                    '    Call openDocument(CurrentItem.SubItems(2).Text) 'return almost that C:\ExactTemp\BB102_BLU_BP-1.jpg
                    'End If

            End Select
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'variable is created for close event for check checkbox
    Private inhibitAutoCheck As Boolean 'true need inhibit ,false work

    'Private Sub lstViewCustomerMiddle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstViewCustomerMiddle.MouseDoubleClick
    '    Try
    '        Dim iSubIndex As Integer
    '        Dim senderList As ListView

    '        senderList = sender

    '        CurrentItem = New ListViewItem
    '        CurrentSB = New ListViewItem.ListViewSubItem

    '        CurrentItem = lstViewCustomerMiddle.GetItemAt(e.X, e.Y) ' which listviewitem was clicked
    '        If CurrentItem Is Nothing Then Exit Sub

    '        iSubIndex = CurrentItem.SubItems.IndexOf(CurrentSB)

    '        Select Case lblMiddleLineNameDisplay.Tag
    '            Case ListViewName.BindeImage

    '                ' See which column has been clicked

    '                If iSubIndex = 0 Then

    '                    Call openDocument(CurrentItem.SubItems(2).Text) 'return almost that C:\ExactTemp\BB102_BLU_BP-1.jpg
    '                End If
    '        End Select

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub lstViewCustomerMiddle_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstViewCustomerMiddle.ItemCheck
        Try
            '  Dim imageKey As Int32 = 0
            '  Dim reqItemGuid As String = ""
            ' Dim reqItemId As Int32 = 0

            '    Dim lvt As ListView


            'if event is uncheck try find in list(of ) the item if is there
            'if it found delete, we don't need stock info if is unchecked
            'when data will be saved , need validation or need comparate existing line with  old line, finally need save new and delete old unchecked
            'for line didn't moved bypass

            'if is False means like is not ihibited is not closed
            '   If inhibitAutoCheck Then
            '    e.NewValue = e.CurrentValue

            '   lvt = sender
            '  Debug.Print(lvt.SelectedItems.Count)

            '  imageKey = CInt(lvt.Items(e.Index).ImageKey)
            '  reqItemGuid = lvt.Items(e.Index).Tag

            '  If (e.CurrentValue = CheckState.Unchecked) Then

            '    If Not olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.DocId = imageKey And i.ItemGuid = reqItemGuid) Is Nothing Then

            '    olstReqDocBindItem.RemoveAll(Function(i As cReqDocBindItem) i.DocId = lvt.Items(e.Index).ImageKey)

            '     olstReqDocBindItem.Remove(olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.DocId = imageKey And i.ItemGuid = reqItemGuid))
            '     End If

            '   ElseIf (e.CurrentValue = CheckState.Checked) Then

            'oReqDocBindItem = New cReqDocBindItem

            'oReqDocBindItem.ReqItemId = reqItemId

            '' oReqDocBindItem.Guid = "" propertie is filled in the class object Init() Method

            'oReqDocBindItem.ItemGuid = reqItemGuid
            'oReqDocBindItem.DocId = imageKey

            'olstReqDocBindItem.Add(oReqDocBindItem)
            ' End If
            '  End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub lstViewCustomerMiddle_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lstViewCustomerMiddle.ItemChecked

        Select Case lblMiddleLineNameDisplay.Tag
            Case ListViewName.BindeImage
                Try
                    Dim imageKey As Int32 = 0
                    Dim reqItemGuid As String = ""
                    Dim reqItemId As Int32 = 0

                    Dim lvt As ListView
                    lvt = sender
                    Debug.Print(lvt.SelectedItems.Count)

                    'if event is uncheck try find in list(of ) the item if is there
                    'if it found delete, we don't need stock info if is unchecked
                    'when data will be saved , need validation or need comparate existing line with  old line, finally need save new and delete old unchecked
                    'for line didn't moved bypass

                    If loadBindItemImage <> True Then


                        imageKey = CInt(lvt.Items(e.Item.Index).ImageKey)
                        reqItemGuid = lvt.Items(e.Item.Index).Tag
                        reqItemId = dgvStoryBoard.CurrentRow.Cells(Request.ReqItemId).Value
                        '  reqItemId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)


                        If (e.Item.Checked = False) Then

                            If Not olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.DocId = imageKey And i.ItemGuid = reqItemGuid) Is Nothing Then
                                '    olstReqDocBindItem.RemoveAll(Function(i As cReqDocBindItem) i.DocId = lvt.Items(e.Index).ImageKey)
                                olstReqDocBindItem.Remove(olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.DocId = imageKey And i.ItemGuid = reqItemGuid))
                            End If

                        ElseIf (e.Item.Checked = True) Then
                            If Not olstReqDocBindItem Is Nothing Then
                                If Not olstReqDocBindItem.Find(Function(i As cReqDocBindItem) i.ItemGuid = reqItemGuid And i.DocId = imageKey) Is Nothing Then
                                    Exit Sub
                                End If
                            Else
                                If olstReqDocBindItem Is Nothing Then
                                    olstReqDocBindItem = New List(Of cReqDocBindItem)
                                End If
                            End If

                            oReqDocBindItem = New cReqDocBindItem
                            'when save need check if is 0 and recuperate reqItem from new line added
                            oReqDocBindItem.ReqItemId = reqItemId

                            ' oReqDocBindItem.Guid = "" propertie is filled in the class object Init() Method

                            oReqDocBindItem.ItemGuid = reqItemGuid
                            oReqDocBindItem.DocId = imageKey

                            olstReqDocBindItem.Add(oReqDocBindItem)
                        End If
                    End If

                Catch ex As Exception

                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)

                    lblMiddleLineNameDisplay.Tag = -1
                    lblMiddleLineNameDisplay.Text = ""

                    lnkLabelAdditionalLoc.Visible = False
                    lblItemShowAdditLoc.Visible = False
                    lnkDeletelocation.Visible = False
                    Exit Sub
                End Try
        End Select
    End Sub
    Private Sub txtBox_LostFocus(sender As Object, e As System.EventArgs) Handles txtBox.LostFocus
        Try
            '  update listviewitem
            CurrentSB.Text = txtBox.Text

            Select Case CurrentItem.SubItems.IndexOf(CurrentSB)
                Case ReqItem_AdditLoc.Imprint_Color, ReqItem_AdditLoc.Imprint_Logo, ReqItem_AdditLoc.BackGround_Color, ReqItem_AdditLoc.StampingPattern, ReqItem_AdditLoc.ReqItemComm

                    For Each additDet As cReqItems_AdditLocation In olstReItems_AdditDetail_Work

                        If lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(CInt(ReqItem_AdditLoc.Guid)).Text = additDet.GUID Then

                            Select Case CurrentItem.SubItems.IndexOf(CurrentSB)

                                Case ReqItem_AdditLoc.Imprint_Color
                                    additDet.IMPRINT_COLOR = Trim(txtBox.Text)

                                Case ReqItem_AdditLoc.Imprint_Logo
                                    additDet.IMPRINT_LOGO = Trim(txtBox.Text)

                                Case ReqItem_AdditLoc.BackGround_Color
                                    additDet.BackGround_Color = Trim(txtBox.Text)

                                Case ReqItem_AdditLoc.StampingPattern
                                    additDet.StampingPattern = Trim(txtBox.Text)
                                Case ReqItem_AdditLoc.ReqItemComm
                                    additDet.ReqItemComm = Trim(txtBox.Text)

                            End Select

                        End If
                    Next

                    olstReItems_AdditDetail = olstReItems_AdditDetail.Union(olstReItems_AdditDetail_Work).ToList

                    Debug.Print(olstReItems_AdditDetail.Count)
            End Select
            ' olstReItems_AdditDetail_Work
            txtBox.Hide()
            lstViewCustomerMiddle.Focus()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstBoxAdd_LostFocus(sender As Object, e As EventArgs) Handles lstBoxAdd.LostFocus
        Try
            lstBoxAdd.Hide()
            panLstBoxAdd.Hide()
            lstViewCustomerMiddle.Focus()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub panLstBoxAdd_LostFocus(sender As Object, e As EventArgs) Handles panLstBoxAdd.LostFocus
        Try

            ' update listviewitem
            '    CurrentSB.Text = lstBoxAdd.SelectedItem.ToString
            lstBoxAdd.Hide()
            panLstBoxAdd.Hide()
            lstViewCustomerMiddle.Focus()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub panLstBoxAdd_MouseLeave(sender As Object, e As EventArgs) Handles panLstBoxAdd.MouseLeave
        Try
            panLstBoxAdd.Hide()
            lstBoxAdd.Hide()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub lstBoxAdd_DoubleClick(sender As Object, e As EventArgs) Handles lstBoxAdd.DoubleClick
        Try
            Dim p_dec_met As Int32 = 0
            Dim p_imp_loc As Int32 = 0
            Dim p_thread_Color As Int32 = 0
            panLstBoxAdd.Hide()
            lstBoxAdd.Hide()
            If Not lstBoxAdd.SelectedItem Is Nothing Then
                CurrentSB.Text = lstBoxAdd.Text
                CurrentSB.Tag = lstBoxAdd.SelectedValue

                Select Case CurrentItem.SubItems.IndexOf(CurrentSB)
                    Case ReqItem_AdditLoc.Imp_desc_id
                        'retrive some id from current line selected
                        p_dec_met = CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag)
                        p_imp_loc = CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Imp_desc_id).Tag)

                        '---(reqItemsGuid, TakeData_DGVStBoard, reqItemsId, reqItemsGuidParent)

                        'need autopopulate area size after location is selected
                        ' Call ReturnAreaSize(olst_ReqItemsDGV, oAdditional.dec_met_id, oAdditional.imp_desc_id, reqItemsGuid)
                        '    Call ReturnAreaSize(TakeData_DGVStBoard(), p_dec_met, p_imp_loc, reqItemsGuid)

                        '    lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Area_Size).Text = ReturnAreaSize(TakeData_DGVStBoard(), p_dec_met, p_imp_loc, reqItemsGuid)

                End Select


                'CurrentItem.SubItems.IndexOf(CurrentSB) 'return column 
                ' ? lstViewCustomerMiddle.Items(0).SubItems(ReqItem_AdditLoc.Guid).Text
                '"f466d94c-6033-4dc6-98f4-a991a27b4cc9"
                'each time when enter data in cell do samething in List(of )
                For Each additDet As cReqItems_AdditLocation In olstReItems_AdditDetail_Work

                    If lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(CInt(ReqItem_AdditLoc.Guid)).Text = additDet.GUID Then
                        Select Case CurrentItem.SubItems.IndexOf(CurrentSB)
                            Case ReqItem_AdditLoc.Dec_met_id
                                additDet.dec_met_id = CInt(lstBoxAdd.SelectedValue)
                                Select Case CInt(lstBoxAdd.SelectedValue)
                                    Case 88, 131, 133, 138

                                        lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Patch_Shape).Text = ""
                                        lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Patch_Color).Text = ""

                                        lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Thread_Color).Text = ""
                                        lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.BackGround_Color).Text = ""
                                        lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.StampingPattern).Text = ""

                                End Select

                            Case ReqItem_AdditLoc.Imp_desc_id
                                'I need add properties text for decorating method for display and dec id rest for database
                                additDet.imp_desc_id = lstBoxAdd.SelectedValue
                            Case ReqItem_AdditLoc.Patch_Shape
                                additDet.patch_shape = lstBoxAdd.SelectedValue
                            Case ReqItem_AdditLoc.Patch_Color
                                additDet.Patch_Color = lstBoxAdd.SelectedValue
                            Case ReqItem_AdditLoc.Thread_Color
                                additDet.Thread_Color = lstBoxAdd.SelectedValue
                            Case ReqItem_AdditLoc.BackGround_Color

                            Case ReqItem_AdditLoc.StampingPattern

                            Case ReqItem_AdditLoc.Imprint_Color

                            Case ReqItem_AdditLoc.Imprint_Logo

                            Case ReqItem_AdditLoc.ReqItemId

                        End Select
                    End If

                Next
                'olstReItems_AdditDetail_Work
            End If
            '  Debug.Print(lstBoxAdd.SelectedItem)
            '  Dim union As IEnumerable(Of cReqItems_AdditLocation) = olstReItems_AdditDetail.Union(olstReItems_AdditDetail_Work).ToList

            If olstReItems_AdditDetail Is Nothing Then olstReItems_AdditDetail = olstReItems_AdditDetail_Work.ToList

            olstReItems_AdditDetail = olstReItems_AdditDetail.Union(olstReItems_AdditDetail_Work).ToList

            Debug.Print(olstReItems_AdditDetail.Count)

            'olstReItems_AdditDetail.AddRange(olstReItems_AdditDetail_Work)
            'Debug.Print(olstReItems_AdditDetail.Count)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstViewCustomerMiddle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstViewCustomerMiddle.SelectedIndexChanged
        Try

            Dim lstV As ListView = sender
            For Each item As ListViewItem In lstV.Items
                item.BackColor = SystemColors.Window
                item.ForeColor = SystemColors.WindowText
            Next

            For Each item As ListViewItem In lstV.SelectedItems
                item.BackColor = SystemColors.GrayText
                item.ForeColor = SystemColors.ControlLight
            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub lnkLabelAdditionalLoc_Click(sender As Object, e As EventArgs) Handles lnkLabelAdditionalLoc.Click
        Try
            'Dim oEnum As cReqItems_AdditLocation
            'oEnum = New cReqItems_AdditLocation
            If lblMiddleLineNameDisplay.Tag = ListViewName.Additional_Location Then

                Dim oEnum As New cReqItems_AdditLocation
                Dim mItemNo As String = ""
                Dim addline As Boolean = True


                lnkDeletelocation.Visible = True

                'loop is used for eliminate double add of the line in the listview
                For Each item As ListViewItem In lstViewCustomerMiddle.Items
                    If item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text = "" Then
                        Call ListView_RowsColor(lstViewCustomerMiddle)
                        Exit Sub
                    End If
                Next
                '--------------------------------------------------------------
                Dim respons As String = ""
                'function added for validate certaine label in in storyboard grid 
                If Validate_RequiredLabel_AdditLocation(respons) <> True Then
                    If respons.Length > 0 Then
                        Dim result1 As DialogResult = MessageBox.Show(respons,
                "Warning.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly,
                False)
                        Exit Sub
                    End If
                End If
                '----------------------- Insert empty line in listview ---------------------------------------

                If Not olstReItems_AdditDetail_Work.Find(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = reqItemsGuid) Is Nothing Then
                    'samething I can retrivereqItemsId from CInt(dgvStoryBoard.CurrentRow.Cells(Request.x).Tag)

                    'was added validation for not add double empty line when listview is called
                    'false this means like exist one empty line
                    'true all line are full
                    For Each addit As cReqItems_AdditLocation In olstReItems_AdditDetail_Work
                        If addit.dec_met_id = 0 Then
                            addline = False
                        End If
                    Next

                    If addline <> False Then
                        'If nothing found for this request add new line in List for use in view
                        'after that  
                        oEnum = New cReqItems_AdditLocation
                        'for know in which row enter Enum 

                        oEnum.ReqItemGuid = reqItemsGuid
                        'take ReqItemId if is saved info if not take 0, when request will be saved ReqItemId will be added.
                        If Not TakeData_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid) Is Nothing Then oEnum.ReqItemId = TakeData_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid).ReqItemId
                        'insert 
                        olstReItems_AdditDetail_Work.Insert((olstReItems_AdditDetail_Work.Count - 1) + 1, oEnum)
                    End If

                Else

                    oEnum = New cReqItems_AdditLocation
                    oEnum.ReqItemGuid = reqItemsGuid
                    'take ReqItemId if is saved info if not take 0, when request will be saved ReqItemId will be added.
                    If Not TakeData_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid) Is Nothing Then oEnum.ReqItemId = TakeData_DGVStBoard.Find(Function(c As cReqItems) c.GUID = reqItemsGuid).ReqItemId
                    'insert 
                    olstReItems_AdditDetail_Work.Insert(0, oEnum)

                End If


                '-------------------------------------------------------------

                Call Additional_Lst(reqItemsGuid, TakeData_DGVStBoard, reqItemsId, reqItemsGuidParent)

                Call ListView_RowsColor(lstViewCustomerMiddle)

            ElseIf lblMiddleLineNameDisplay.Tag = ListViewName.BindeImage Then

                For Each lstw As ListViewItem In lstViewCustomerMiddle.Items
                    If lstw.Checked = True Then
                        Debug.Print(lstw.Index & " image key = " & lstw.ImageKey)
                    End If
                Next

            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '----------------------------- function for validate Required Label for additional location listview ------------------------------------
    Private Function Validate_RequiredLabel_AdditLocation(Optional ByRef respons As String = "") As Boolean
        Validate_RequiredLabel_AdditLocation = True
        Try

            '------------------ Validate Required label when line is added in listview additional location ------------------------
            Dim ValFunctRespons As String = ""
            Dim varResospons As String = String.Empty
            Dim varBool As Boolean = True

            If lstViewCustomerMiddle.Items.Count = 0 Then Exit Function

            For Each item As ListViewItem In lstViewCustomerMiddle.Items
                item.UseItemStyleForSubItems = False

                If item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text = String.Empty Then
                    varBool = False
                    varResospons &= "Required field " &
                                DirectCast([Enum].Parse(GetType(ReqItem_AdditLoc), (CInt(ReqItem_AdditLoc.Dec_met_id))), ReqItem_AdditLoc).ToString & vbCrLf
                    item.SubItems(ReqItem_AdditLoc.Dec_met_id).BackColor = Color.Red
                    item.SubItems(ReqItem_AdditLoc.Dec_met_id).ForeColor = Color.White
                Else
                    item.SubItems(ReqItem_AdditLoc.Dec_met_id).ResetStyle()
                End If



                If item.SubItems(ReqItem_AdditLoc.Imp_desc_id).Text = String.Empty Then
                    varBool = False
                    varResospons &= "Required field " &
                                DirectCast([Enum].Parse(GetType(ReqItem_AdditLoc), (CInt(ReqItem_AdditLoc.Imp_desc_id))), ReqItem_AdditLoc).ToString &
                                " for Deco/Meth : " & item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text & vbCrLf
                    item.SubItems(ReqItem_AdditLoc.Imp_desc_id).BackColor = Color.Red
                    item.SubItems(ReqItem_AdditLoc.Imp_desc_id).ForeColor = Color.White

                Else
                    item.SubItems(ReqItem_AdditLoc.Imp_desc_id).ResetStyle()
                End If

                Select Case item.SubItems(ReqItem_AdditLoc.Dec_met_id).Tag
                    Case 88, 131, 133, 138
                        For i As Int32 = 0 To 2
                            If item.SubItems(ReqItem_AdditLoc.Patch_Shape + i).Text = String.Empty Then
                                varBool = False
                                varResospons &= "Required field " &
                                DirectCast([Enum].Parse(GetType(ReqItem_AdditLoc), (CInt(ReqItem_AdditLoc.Patch_Shape + i))), ReqItem_AdditLoc).ToString &
                                " for Deco/Meth : " & item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text & vbCrLf
                                item.SubItems(ReqItem_AdditLoc.Patch_Shape + i).BackColor = Color.Red
                                item.SubItems(ReqItem_AdditLoc.Patch_Shape + i).ForeColor = Color.White

                            Else
                                item.SubItems(ReqItem_AdditLoc.Patch_Shape + i).ResetStyle()
                            End If
                        Next

                        If item.SubItems(ReqItem_AdditLoc.Dec_met_id).Tag = 133 And item.SubItems(ReqItem_AdditLoc.BackGround_Color).Text = String.Empty Then
                            varBool = False
                            varResospons &= "Required field " &
                                DirectCast([Enum].Parse(GetType(ReqItem_AdditLoc), (CInt(ReqItem_AdditLoc.BackGround_Color))), ReqItem_AdditLoc).ToString &
                                " for Deco/Meth : " & item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text & vbCrLf
                            item.SubItems(ReqItem_AdditLoc.BackGround_Color).BackColor = Color.Red
                            item.SubItems(ReqItem_AdditLoc.BackGround_Color).ForeColor = Color.White
                        Else
                            item.SubItems(ReqItem_AdditLoc.BackGround_Color).ResetStyle()
                        End If

                    Case 1
                        If item.SubItems(ReqItem_AdditLoc.Imprint_Color).Text = String.Empty Then
                            varBool = False
                            varResospons &= "Required field " &
                                DirectCast([Enum].Parse(GetType(ReqItem_AdditLoc), (CInt(ReqItem_AdditLoc.Imprint_Color))), ReqItem_AdditLoc).ToString &
                                " for Deco/Meth : " & item.SubItems(ReqItem_AdditLoc.Dec_met_id).Text & vbCrLf
                            item.SubItems(ReqItem_AdditLoc.Imprint_Color).BackColor = Color.Red
                            item.SubItems(ReqItem_AdditLoc.Imprint_Color).ForeColor = Color.White
                        Else
                            item.SubItems(ReqItem_AdditLoc.Imprint_Color).ResetStyle()

                        End If

                End Select
                '  item.UseItemStyleForSubItems = True
            Next

            If varResospons.Length > 0 Then
                respons &= varResospons & vbCrLf
            End If
            '---------------------------------------------------------------------------------------------------

            Return varBool

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------
    Private Sub lnkDeletelocation_Click(sender As Object, e As EventArgs) Handles lnkDeletelocation.Click
        Try
            '  CInt(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Dec_met_id).Tag)
            If CurrentItem Is Nothing Then
                MsgBox("Click on the line if you want delete.")
                Exit Sub
            End If
            If CurrentItem.Index = -1 Then Exit Sub
            Debug.Print(CurrentItem.Index)
            Dim m_guid As String = Trim(lstViewCustomerMiddle.Items(CurrentItem.Index).SubItems(ReqItem_AdditLoc.Guid).Text)
            lstViewCustomerMiddle.Items.RemoveAt(CurrentItem.Index)

            If Not olstReItems_AdditDetail.Find(Function(c As cReqItems_AdditLocation) c.GUID = m_guid) Is Nothing Then
                olstReItems_AdditDetail.RemoveAt(olstReItems_AdditDetail.FindIndex(Function(c As cReqItems_AdditLocation) c.GUID = m_guid))
            End If
            If olstReItems_AdditDetail_Work.Find(Function(c As cReqItems_AdditLocation) c.GUID = m_guid) Is Nothing Then
                olstReItems_AdditDetail_Work.RemoveAt(olstReItems_AdditDetail_Work.FindIndex(Function(c As cReqItems_AdditLocation) c.GUID = m_guid))
            End If

            ' olstReItems_AdditDetail = olstReItems_AdditDetail.Union(olstReItems_AdditDetail_Work).ToList
            panLstBoxAdd.Hide()
            '    lstBoxAdd.Items.Clear()
            lstBoxAdd.Hide()
            txtBox.Text = ""
            txtBox.Hide()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '--------------------------------- WORK WITH ADDITIONAL DEC/LOC -----------------------------------------------
    '---------- Function Retrive from dgvStoryboard data toward list(of cReqItems)---------------------------------
    Private Function TakeData_DGVStBoard() As List(Of cReqItems)
        TakeData_DGVStBoard = New List(Of cReqItems)
        Try
            olstReqItems = New List(Of cReqItems)

            For Each dgRow As DataGridViewRow In dgvStoryBoard.Rows

                oReqItems = New cReqItems

                oReqItems.ReqItemId = CInt(dgRow.Cells(CInt(Request.x)).Tag)
                oReqItems.RequestId = RequestID
                oReqItems.ReviewId = ReviewId
                oReqItems.item_master_id = Trim(dgRow.Cells(CInt(Request.item_master_id)).Value)
                oReqItems.ItemCd = Trim(dgRow.Cells(CInt(Request.item_cd)).Value)
                oReqItems.prod_category = Trim(dgRow.Cells(CInt(Request.prod_category)).Value)
                oReqItems.Is_Kit = Trim(dgRow.Cells(CInt(Request.Is_kit)).Value)

                '----------------------- Retrive from DataGridViewComboBoxCell Color_ID ---------------------------------
                If String.IsNullOrEmpty(Trim(dgRow.Cells(Request.Parent_GUID).Value.ToString)) Then
                    '  If dgRow.Cells(Request.Parent_GUID).Value = "" Then

                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.item_color), dgRow.Index), DataGridViewComboBoxCell) ' 
                    oReqItems.color_id = CInt(comboboxCellrec.Value)
                Else
                    oReqItems.color_id = CInt(dgRow.Cells(CInt(Request.item_color)).Tag)
                End If

                oReqItems.item_no = dgRow.Cells(Request.item_no).Value
                oReqItems.Maco_desc1 = Trim(dgRow.Cells(Request.Maco_desc1).Value)

                'don't need info from parent kit because it has not dec, loc, patch etc.
                '------------------------------------------------------------------------------------------------
                If Trim(dgRow.Cells(CInt(Request.Is_kit)).Value) <> "K" Then
                    '----------------------- Retrive from DataGridViewComboBoxCell Dec_Met_Id ---------------------------------
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.DEC_MET_DESC), dgRow.Index), DataGridViewComboBoxCell) ' 

                    If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.dec_met_id = CInt(comboboxCellrec.Value)
                    '--------------------------------------------------------------------------------------------------------

                    '----------------------- Retrive from DataGridViewComboBoxCell IMP_DESCRIPTION_id ---------------------------------
                    comboboxCellrec = New DataGridViewComboBoxCell
                    comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.IMP_DESCRIPTION), dgRow.Index), DataGridViewComboBoxCell)
                    If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.imp_desc_id = CInt(comboboxCellrec.Value)
                    '--------------------------------------------------------------------------------------------------------

                    '----------------------- Retrive from DataGridViewComboBoxCell Patch_Shape , Patch_Color---------------------------------
                    If (oReqItems.dec_met_id = 88 Or oReqItems.dec_met_id = 131 Or oReqItems.dec_met_id = 133 Or oReqItems.dec_met_id = 138) Then 'retrive value only if is 88 BRANDPATCH 
                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Patch_Shape), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.patch_shape = CInt(comboboxCellrec.Value)
                        '++ID 1.15.2018
                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Patch_Color), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.Patch_Color = CInt(comboboxCellrec.Value)

                        comboboxCellrec = New DataGridViewComboBoxCell
                        comboboxCellrec = DirectCast(dgvStoryBoard.Item(CInt(Request.Thread_Color), dgRow.Index), DataGridViewComboBoxCell) ' 
                        If CInt(comboboxCellrec.Value) <> 0 Then oReqItems.Thread_Color = CInt(comboboxCellrec.Value)


                        If (String.IsNullOrEmpty(dgRow.Cells(Request.BackGround_Color).Value) Or String.IsNullOrWhiteSpace(dgRow.Cells(Request.BackGround_Color).Value)) Then
                            oReqItems.BackGround_Color = String.Empty
                        Else
                            oReqItems.BackGround_Color = dgRow.Cells(Request.BackGround_Color).Value.ToString
                        End If

                        If (String.IsNullOrEmpty(dgRow.Cells(Request.StampingPattern).Value) Or String.IsNullOrWhiteSpace(dgRow.Cells(Request.StampingPattern).Value)) Then
                            oReqItems.StampingPattern = String.Empty
                        Else
                            oReqItems.StampingPattern = dgRow.Cells(Request.StampingPattern).Value.ToString
                        End If



                    End If
                End If
                '--------------------------------------------------------------------------------------------------------
                oReqItems.GUID = dgRow.Cells(Request.GUID).Value.ToString

                'True - value is null ,empty
                'False - is  filled
                If String.IsNullOrEmpty(Trim(dgRow.Cells(CInt(Request.Parent_GUID)).Value.ToString)) <> True Then
                    '  If dgRow.Cells(Request.Parent_GUID).Value <> "" Then
                    oReqItems.parent_guid = dgRow.Cells(CInt(Request.Parent_GUID)).Value.ToString
                End If

                oReqItems.IMPRINT_COLOR = dgRow.Cells(Request.IMPRINT_COLOR).Value
                oReqItems.IMPRINT_LOGO = Trim(dgRow.Cells(Request.IMPRINT_LOGO).Value)

                olstReqItems.Add(oReqItems)
            Next

            Return olstReqItems

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '--------------------------------------------------------------------------------------------------------------
    '------------------------------ Show ListView all  Documents for this Request -------------------------------------
    Private ImgList As New ImageList With {.ImageSize = New Size(64, 64)}
    Private loadBindItemImage As Boolean
    Public Sub BindItem_Image(ByVal reqItemsGuid As String) 'parent for check if is kit
        'olst_ReqItemsDGV -> took data from grid
        Try
            'true while is load
            loadBindItemImage = True
            ImgList = New ImageList With {.ImageSize = New Size(64, 64)}
            Dim oEnum As New cReqItems_AdditLocation
            Dim mItemNo As String = ""
            Dim addline As Boolean = True

            panMiddleLstViewCustomerShow.Visible = True
            panMiddleLstViewCustomerShow.Width = 750
            panMiddleLstViewCustomerShow.Left = 239
            lstViewCustomerMiddle.Items.Clear()

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()

            '--------------
            With lstViewCustomerMiddle
                ' .Height = 10
                .Font = New Font(New FontFamily("Segoe UI"), 10, FontStyle.Regular)
                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .Columns.Clear() ' make sure collumnscollection is empty
                .SmallImageList = ImgList
                .CheckBoxes = True

                ' Add 3 columns
                .Columns.AddRange(New ColumnHeader() {listColumns("Pictures", "Pictures", HorizontalAlignment.Right, 96),
                                                     listColumns("Document Size", "Document Size", HorizontalAlignment.Center, 80),
                                                      listColumns("Document Name", "Document Name", HorizontalAlignment.Left, 250)
                                                    })
                '  .FullRowSelect = False
                .GridLines = True
                .LabelEdit = False
                .AllowColumnReorder = True
                .Sorting = SortOrder.Ascending
                .AllowColumnReorder = True
                ' .HideSelection = False
                ' .Columns(0).DisplayIndex = .Columns.Count - 1
                .AutoArrange = False
            End With

            '----------------------Load document file in listview---------------------------

            Dim fileName As String = ""
            Dim strFile(System.Enum.GetNames(GetType(Documentlinklabel)).Length) As String

            oMdb_Item_Doc = New cMdb_Item_Doc
            olstMdb_Item_Doc = New List(Of cMdb_Item_Doc)
            Dim strQuery As String 'always start with ' where .....

            strQuery = " where REQUESTID = " & RequestID & " AND REVIEWID = " & ReviewId & " and ITEM_DOC_TYPE_ID <> 24 order by  Item_Doc_Name asc"
            olstMdb_Item_Doc = oMdb_Item_Doc.LoadList(strQuery)

            If olstMdb_Item_Doc.Count = 0 Then

                MsgBox("You can assign document for an item after save request." & vbCrLf & "Thank you.")
                panMiddleLstViewCustomerShow.Visible = False
                Exit Sub
            End If



            Dim tileSetImage As System.Drawing.Image
            Dim cpt As Integer = 0
            Dim newImageKey As String = ""

            '------------------------ List(of cMdb_Item_Doc) Loaded -----------------------------
            olstMdb_Item_Doc.OrderBy(Function(i As cMdb_Item_Doc) i.Item_Doc_Name)



            For Each doc As cMdb_Item_Doc In olstMdb_Item_Doc

                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem

                newImageKey = doc.Item_Doc_Id.ToString
                'item(UBound(item)).Text = Trim(doc.Item_Doc_Id).ToString

                'function write file in Exact and check if exist copy and use existing copy
                fileName = WriteInExact(doc.Item_Doc_Name.Replace("?", "") & "-" & UBound(item) + 1 & "." & doc.Item_Doc_File_Ext, doc.Item_Doc)

                If Not olstReqDocBindItem Is Nothing Then

                    If Not olstReqDocBindItem.Find(Function(c As cReqDocBindItem) c.ItemGuid = reqItemsGuid And c.DocId = doc.Item_Doc_Id) Is Nothing Then

                        item(UBound(item)).Checked = True

                        'if not exist in list nothing to do
                        'default value is checked = false
                        'Else
                        ' item(UBound(item)).Checked = False
                    End If

                End If

                If IsValidImage(fileName) Then

                    '   tileSetImage = System.Drawing.Image.FromFile(WriteInExact(doc.Item_Doc_Name & "-" & UBound(item) & "." & doc.Item_Doc_File_Ext, doc.Item_Doc))

                    tileSetImage = System.Drawing.Image.FromFile(fileName)
                    '   ImgList.ImageSize = Size
                    ImgList.Images.Add(newImageKey, tileSetImage)

                    '   item(UBound(item)).Text = fileName
                    item(UBound(item)).ImageKey = newImageKey

                Else
                    '   add Icon file
                    ImgList.Images.Add(newImageKey, Icon.ExtractAssociatedIcon(fileName).ToBitmap) 'newImageKey, tileSetImage)

                    item(UBound(item)).ImageKey = newImageKey
                    '  item(UBound(item)).Text = fileName
                End If

                item(UBound(item)).Tag = reqItemsGuid


                item(UBound(item)).SubItems.Add(FormatBytes(doc.Item_Doc.Length))
                item(UBound(item)).SubItems.Add(fileName)
                'item(UBound(item)).SubItems.Add(doc.Item_Doc_File_Ext)

                Items.Add(item(UBound(item)))

            Next

            lstViewCustomerMiddle.BeginUpdate()

            lstViewCustomerMiddle.Items.AddRange(Items.ToArray)

            lstViewCustomerMiddle.EndUpdate()
            lstViewCustomerMiddle.Visible = True
            lstViewCustomerMiddle.Focus()

            lblMiddleLineNameDisplay.Text = ListViewName.BindeImage.ToString & "-" & ListViewName.BindeImage
            lblMiddleLineNameDisplay.Tag = ListViewName.BindeImage

            lblMiddleLineFound.Text = Items.Count & " rows"

            lblItemShowAdditLoc.Visible = True


            If TSM.Tag Is Nothing Then
                mItemNo = dgvStoryBoard.CurrentRow.Cells(Request.item_no).Value
            Else
                mItemNo = dgvStoryBoard.Rows(TSM.Tag).Cells(Request.item_no).Value
            End If

            '  mItemNo = dgvStoryBoard.Rows(TSM.Tag).Cells(Request.item_no).Value
            lblItemShowAdditLoc.Text = mItemNo


            TSM.Tag = Nothing

            Call ListView_RowsColor(lstViewCustomerMiddle)

            lnkLabelAdditionalLoc.Visible = False 'this label is only for Additional display
            lnkDeletelocation.Visible = False

            'False is loaded
            loadBindItemImage = False


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'check if file is image
    Function IsValidImage(filename As String) As Boolean
        Try
            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(filename)
        Catch generatedExceptionName As OutOfMemoryException
            ' Image.FromFile throws an OutOfMemoryException  
            ' if the file does not have a valid image format or 
            ' GDI+ does not support the pixel format of the file. 
            ' 
            Return False
        End Try
        Return True
    End Function

    Private Sub btnWebBrowser_Click(sender As Object, e As EventArgs) Handles btnWebBrowser.Click
        Dim Message As String = ""
        Try

            Dim CPT As Int32 = 0
            Try
                Dim strQuery As String = ""
                Dim oCfgEnum1 As cCfgEnum
                Dim olsCfgEnum1 As List(Of cCfgEnum)



                Dim valImp As String = ""
                Dim valMet As String = ""
                Dim valPatch_Shape As String = ""
                Dim valPatch_Color As String = ""
                Dim valArea As String = ""
                Dim valDefaultLoc As Integer = 0
                Dim listFileAddress As List(Of String) = New List(Of String)
                Dim valItemMasterKit As String = ""
                Dim valItemMasterKit_Cd As String = ""
                Dim valDocLoc As String = ""
                Dim valColorName As String = ""
                Dim valTreadColor As String = ""
                Dim valBackGroundColor As String = ""
                Dim valStampingPattern As String = ""



                oExact_Traveler_Permission = New cExact_Traveler_Permission



                Message = "<html>
<head>
<style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
</style>


</head>
<body>"
                'txtbtnStatus
                '.Text = RequestStatus.Processed.ToString
                '.Tag = RequestStatus.Processed



                Message &= "<p ><font size='5'> " & Trim(lblStoryBoard.Text) & "   " & Trim(xtxtReqItemCode.Text) & "</font></p>.<br/> <br/>"
                Message &= " Status - " & txtbtnStatus.Tag & "-" & txtbtnStatus.Text

                If chkRushOrder.CheckState = CheckState.Checked Then Message &= "Is Rush Order : YES. <br/> <br/>"
                Message &= " For Customer : " & Trim(txtCustomer.Text) & " - " & Trim(lblCustomerName.Text) & ".<br/><br/>"
                Message &= " Customer Contact : " & Trim(lnkLblContactShow.Text) & ",  e-mail : " & Trim(lblContactEmail.Text) & ".<br/> <br/> <br/>"

                Message &= "<a  href='M:/mcc/traveler executable/CustomerFile/CustomerFile.exe' > - >Customer File Program< - </a>.<br/> <br/> <br/>"

                Message &= "<table  > 
               <tr bgcolor='#8FBC8F'  > <td> Masterid </td> 
       <td> Style </td> <td> Prod Cat </td> <td> Kit:Y/N </td> <td> Color </td> <td> SKU </td>  <td> Macola Description </td> <td> Deco/Method </td> 
         <td> Deco/Location </td> <td> Area/Size </td> <td> Default/Location </td> <td> Patch/Shape </td> <td> Patch/Color </td> <td> Thread Color </td> <td> BackGround Color </td>
          <td> Stamping Pattern </td>  <td> Imprint/Color </td> <td> Imprint/Logo </td>  </tr> "
                oReqItems = New cReqItems
                olstReqItems = New List(Of cReqItems)

                If olstReqItems IsNot Nothing Then

                    strQuery = " select ri.* from ReqItems ri where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'" _
                        & "   union   " _
                        & " select ri.ReqItemId,RequestId = 0,ReviewId = 0,ri.item_master_id,ItemCd = '',Is_Kit = '',prod_category= '',Maco_desc1 = '',color_id = 0, " _
                        & " item_no = '',l.dec_met_id, l.imp_desc_id, l.patch_shape, ri.GUID, ri.parent_guid, CreateBy = 0,  " _
                        & " CreateByFullName = '', CreateDate = '', ModifyBy = 0, ModifyByFullName = '', ModifyDate = '',l.imprint_color ,l.imprint_logo ,l.patch_color, " _
                        & " l.Thread_Color, l.BackGround_Color,l.StampingPattern,ri.ReqItemComm from ReqItems ri right join ReqItems_AdditLocation l on " _
                        & " ri.ReqItemId = l.ReqItemId   where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'  order by ReqItemId,RequestId  desc "

                    olstReqItems = oReqItems.LoadLst_ForEmail(strQuery)

                    oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                    olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                    Dim oRItems As New cReqItems
                    Dim olstRItems As List(Of cReqItems)

                    oRItems = New cReqItems
                    olstRItems = New List(Of cReqItems)

                    olstRItems = oReqItems.LoadLst_ForEmail(strQuery) 'LoadLst("WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId)

                    oMDB_CFG_IMP_LOC = New cMDB_CFG_IMP_LOC
                    olstMDB_CFG_IMP_LOC = New List(Of cMDB_CFG_IMP_LOC)
                    olstMDB_CFG_IMP_LOC = oMDB_CFG_IMP_LOC.LoadLst

                    oMDB_CFG_DEC_MET = New cMDB_CFG_DEC_MET
                    olstMDB_CFG_DEC_MET = New List(Of cMDB_CFG_DEC_MET)
                    olstMDB_CFG_DEC_MET = oMDB_CFG_DEC_MET.LoadLst

                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)
                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                    oCfgEnum1 = New cCfgEnum
                    'olsCfgEnum1 = New List(Of cCfgEnum)
                    'olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                    oMdb_cfg_Color = New cMdb_Cfg_Color
                    olstMdb_Cfg_Color = New List(Of cMdb_Cfg_Color)

                    olstMdb_Cfg_Color = oMdb_cfg_Color.Load

                    'start FOR EACH  olstReqItems
                    For Each item As cReqItems In olstReqItems
                        CPT += 1
                        olsCfgEnum1 = New List(Of cCfgEnum)
                        '    olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                        If (item.dec_met_id = 88 Or item.dec_met_id = 131 Or item.dec_met_id = 138) Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08BP44")
                        ElseIf item.dec_met_id = 133 Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                        End If

                        valArea = ""
                        valDefaultLoc = 0
                        valImp = ""
                        valMet = ""
                        valItemMasterKit = ""
                        valPatch_Shape = ""
                        valPatch_Color = ""
                        valColorName = ""

                        Try
                            If Not olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id) Is Nothing Then
                                valColorName = olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id).COLOR_NAME
                            End If
                        Catch ex As Exception
                            MsgBox("Error in " & Me.Name & ". Assigne color name" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        End Try

                        Message &= "<tr>"

                        If item.RequestId <> 0 And item.ReviewId <> 0 And item.color_id <> 0 Then

                            Message &= " <td> " & item.item_master_id & "</td> <td> " & item.ItemCd & " </td> <td>" & item.prod_category & "</td>"

                            If item.parent_guid <> "" Then
                                If Not olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid) Is Nothing Then valItemMasterKit_Cd = item.Is_Kit & "-" & olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).ItemCd
                            Else
                                valItemMasterKit_Cd = item.Is_Kit
                            End If

                            Message &= "<td>" & valItemMasterKit_Cd & "</td> "

                            Message &= " <td>" & Trim(valColorName) & "</td><td>" & item.item_no & "<t/d><td>" & item.Maco_desc1 & "</td>"

                        Else
                            'exception if item have additional location
                            Dim additLocation As String = ""
                            additLocation = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).item_no

                            Message &= " <td colspan = '7' bgcolor='#B0E0E6' align='center'> ADITIONAL LOCATION FOR ITEM NO : " & Trim(additLocation).ToUpper

                            Message &= " </td>"

                        End If

                        If item.dec_met_id <> 0 Then
                            If Not olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id) Is Nothing Then valMet = olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id).DEC_MET_NAME
                        End If
                        Message &= " <td>" & valMet & "</td>"

                        If item.imp_desc_id <> 0 Then
                            If Not olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id) Is Nothing Then valImp = olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id).IMP_DESC
                        End If
                        Message &= "<td>" & valImp & "</td>  "

                        If item.parent_guid = "" Then 'Item is not kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then
                                If item.item_master_id = 0 Then
                                    item.item_master_id = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).item_master_id
                                End If

                                olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(item.item_master_id)

                                If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE

                                valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                            End If
                            Message &= "<td>" & valArea & " </td> "

                            If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"

                        ElseIf item.parent_guid <> "" Then 'item Is component of the kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then

                                valItemMasterKit = olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).item_master_id
                                olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(valItemMasterKit, item.item_master_id, item.dec_met_id)

                                If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then
                                    valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE
                                    valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                                End If

                                Message &= "<td>" & valArea & " </td> "

                                If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"
                            Else
                                Message &= "<td> </td>  <td> </td>"
                            End If
                        End If

                        If item.patch_shape <> 0 Then
                            If Not olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape) Is Nothing Then valPatch_Shape = olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape).Enum_Value
                        End If

                        Message &= "<td>" & valPatch_Shape & " </td> "
                        '++ID 1.15.2018 added patch_color
                        If item.Patch_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color) Is Nothing Then valPatch_Color = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color).Enum_Value
                        End If

                        Message &= "<td>" & valPatch_Color & "</td> "

                        If item.Thread_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color) Is Nothing Then valTreadColor = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color).Enum_Value
                        End If

                        Message &= "<td>" & valTreadColor & "</td>"
                        Message &= "<td>" & item.BackGround_Color & "</td>"
                        Message &= "<td>" & item.StampingPattern & "</td>"

                        Message &= "<td> " & item.IMPRINT_COLOR & " </td> <td> " & item.IMPRINT_LOGO & " </td>  </tr>"

                    Next

                End If

                Message &= " </table> "

                '------------------------Add comments in e-mail -------------------------------------------

                oReqCommunic = New cReqCommunication
                olstReqCommunic = New List(Of cReqCommunication)

                '------------------------------ Display txtSpecInstrReceive -----------------------------
                olstReqCommunic = New List(Of cReqCommunication)
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

                Message &= "<br/><br/> Comments from CS: " & "<br/> "
                If Not olstReqCommunic Is Nothing Then
                    For Each comm As cReqCommunication In olstReqCommunic
                        Message &= comm.MessageInstruction & "<br/> "
                    Next
                End If
                Message &= "----------------------------------------------------------------------------<br/><br/>"
                '----------------------------------------------------------------------------------------

                '------------------------------- Display txtRecCommGraph --------------------------------
                olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")
                Message &= "Comments from Graphics : <br/>"
                If Not olstReqCommunic Is Nothing Then
                    For Each comm As cReqCommunication In olstReqCommunic
                        Message &= comm.MessageInstruction & "<br/> "
                    Next
                End If
                '----------------------------------------------------------------------------------------
                Message &= "----------------------------------------------------------------------------<br/><br/> Thank you "

                Message &= "</body> </html>"



            Catch ex As Exception
                MsgBox("Error in " & Me.Name & ". CPT = " & CPT & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
            End Try


            Dim web As New frmWebBrowser(Message)
            web.Show()


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmVirtual_Request_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

            btnWebBrowser.Focus()

            Dim olstReqIt As New List(Of cReqItems)

            If varDelete <> True Then

                Select Case dgvStoryBoard.Rows.Count
                    Case 0

                    Case 1
                        '    If dgvStoryBoard.Rows(0).Cells(Request.item_master_id).Value <> 0 Then
                        If Microsoft.VisualBasic.Information.IsNumeric(dgvStoryBoard.Rows(0).Cells(Request.item_master_id).Value) Then
                            olstReqIt = TakeData_DGVStBoard()
                        End If

                    Case Else
                        olstReqIt = TakeData_DGVStBoard()
                End Select

                If olstReqIt.Count <> 0 Then

                    olstReqIt = TakeData_DGVStBoard()

                    Dim val As IEnumerable(Of cReqItems) = olstReqItems_old.Except(olstReqIt)
                    Dim varBl As Boolean = False

                    If (olstReqIt.Count > olstReqItems_old.Count Or olstReqIt.Count < olstReqItems_old.Count) Then
                        varBl = True 'true = need save request
                    End If

                    For Each reIt As cReqItems In olstReqIt

                        If olstReqItems_old.Find(Function(i As cReqItems) i.item_master_id = reIt.item_master_id And i.color_id = reIt.color_id And
                                              i.dec_met_id = reIt.dec_met_id And i.imp_desc_id = reIt.imp_desc_id And i.patch_shape = reIt.patch_shape And
                                              i.IMPRINT_COLOR = reIt.IMPRINT_COLOR And i.IMPRINT_LOGO = reIt.IMPRINT_LOGO And i.Patch_Color = reIt.Patch_Color And
                                              i.Thread_Color = reIt.Thread_Color And i.BackGround_Color = reIt.BackGround_Color And
                                              i.StampingPattern = reIt.StampingPattern) Is Nothing Then

                            Dim result As Integer = MessageBox.Show("You made changes in Item Grid. You want save or Exit.", "Made changes!!!", MessageBoxButtons.YesNoCancel)
                            If result = DialogResult.Cancel Then
                                MessageBox.Show("Changes are not saved!!!")
                                e.Cancel = False
                                Exit Sub
                            ElseIf result = DialogResult.No Then
                                MessageBox.Show("Changes are not saved!!!")
                                e.Cancel = False
                                Exit Sub
                            ElseIf result = DialogResult.Yes Then
                                Try
                                    Dim respons As String = ""
                                    'function added for validate certaine label in in storyboard grid 
                                    If ValidateDecoProperties(respons) <> True Then
                                        If respons.Length > 0 Then
                                            'message need to be revised
                                            '      MsgBox(respons)

                                            Dim result1 As DialogResult = MessageBox.Show(respons & vbCrLf & " --- REQUEST IS NOT SAVED!!! ---",
                                    "--- REQUEST IS NOT SAVED!!! ---",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly,
                                    False)

                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    End If
                                    '-------------------------

                                    Call SaveRequest()

                                    ' Me.Close()
                                    e.Cancel = False
                                    Exit Sub
                                Catch ex As Exception
                                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                                End Try
                            End If

                        End If
                    Next


                End If
                'new exception variable is filled in frmCustomer
                'declared in mGlobal
                'means like frmCustomer is open

                'If varIdentIfCustFormIsOpen = True Then
                '    Dim f As New frmShowRequests
                '    f.Show()
                'End If
            End If


            e.Cancel = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xLnkOrigmail_DragDrop(sender As Object, e As DragEventArgs) Handles xLnkOrigmail.DragDrop
        Try

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            If files(0).Length = 0 Then Exit Sub

            Dim mail_path As String = files(0)

            Dim m_FileUpload As ADODB.Stream
            Dim strIcon_Name As String = ""
            Dim strFile(System.Enum.GetNames(GetType(Documentlinklabel)).Length) As String
            ' Enum.GetValues(typeof(Documentlinklabel)).Cast<Documentlinklabel>().Distinct().Count()

            Dim ByteIcon As Byte() = Nothing

            Dim myFile As New FileInfo(mail_path)

            If myFile Is Nothing Then Exit Sub

            Debug.Print(FormatBytes(myFile.Length))

            If xLnkOrigmail.TagId = 0 Then


                strIcon_Name = mail_path.Substring(mail_path.LastIndexOf("\") + 1).Substring(0, mail_path.Substring(mail_path.LastIndexOf("\") + 1).LastIndexOf("."))

                strFile(Documentlinklabel.ID) = 0 'now is 0(zero) becuase added from system
                strFile(Documentlinklabel.DocTxtShow) = mail_path.Substring(mail_path.LastIndexOf("\") + 1) 'abstract_color_background_picture_8016-wide.jpg
                strFile(Documentlinklabel.DocName) = strIcon_Name 'abstract_color_background_picture_8016-wide
                strFile(Documentlinklabel.DocPath) = mail_path 'C:\Users\iond\Pictures\abstract_color_background_picture_8016-wide.jpg
                strFile(Documentlinklabel.DocExtention) = mail_path.Substring(mail_path.LastIndexOf(".") + 1) ' jpg
                'm_path.Substring(m_path.LastIndexOf("\") + 1) = "background-11.jpg"
                strFile(Documentlinklabel.DocGuid) = ""

                m_FileUpload = New ADODB.Stream
                m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
                m_FileUpload.Open()
                m_FileUpload.LoadFromFile(mail_path)

                ByteIcon = m_FileUpload.Read

                Debug.Print(" ICON_NAME:-" & strIcon_Name & "; FILENAME:- " & strFile(Documentlinklabel.DocPath) & "; Icon:- " & ByteIcon.ToString)

                If ByteIcon.ToString.Length <> 0 Then
                    ' xLnkOrigmail.Text = Trim(strIcon_Name)
                    '   xLnkOrigmail.TagId = 0 'this is docid in disigne is defined 0
                    xLnkOrigmail.TagPath = Trim(strIcon_Name) & "." & strFile(Documentlinklabel.DocExtention)
                    xLnkOrigmail.TagByte = ByteIcon
                    'xLnkOrigmail.TagPath = strFile(Documentlinklabel.DocPath)
                    xLnkOrigmail.TagExtention = strFile(Documentlinklabel.DocExtention)
                    xLnkOrigmail.BackColor = Color.Violet
                    xLnkOrigmail.Tag = Guid.NewGuid().ToString  'new guid each time when add mail
                End If

            Else

                Dim result As Integer = MessageBox.Show("Previous Customer Email Will Be Deleted and New Added", "Previous email Customer Email will be deleted. Alert!!! ", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    MessageBox.Show("No change.")
                ElseIf result = DialogResult.Yes Then

                    oMdb_Item_Doc = New cMdb_Item_Doc()

                    If oMdb_Item_Doc.Delete(xLnkOrigmail.TagId) = True Then



                        strIcon_Name = mail_path.Substring(mail_path.LastIndexOf("\") + 1).Substring(0, mail_path.Substring(mail_path.LastIndexOf("\") + 1).LastIndexOf("."))

                        strFile(Documentlinklabel.ID) = 0 'now is 0(zero) becuase added from system
                        strFile(Documentlinklabel.DocTxtShow) = mail_path.Substring(mail_path.LastIndexOf("\") + 1) 'abstract_color_background_picture_8016-wide.jpg
                        strFile(Documentlinklabel.DocName) = strIcon_Name 'abstract_color_background_picture_8016-wide
                        strFile(Documentlinklabel.DocPath) = mail_path 'C:\Users\iond\Pictures\abstract_color_background_picture_8016-wide.jpg
                        strFile(Documentlinklabel.DocExtention) = mail_path.Substring(mail_path.LastIndexOf(".") + 1) ' jpg
                        'm_path.Substring(m_path.LastIndexOf("\") + 1) = "background-11.jpg"
                        strFile(Documentlinklabel.DocGuid) = ""

                        m_FileUpload = New ADODB.Stream
                        m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
                        m_FileUpload.Open()
                        m_FileUpload.LoadFromFile(mail_path)

                        ByteIcon = m_FileUpload.Read

                        Debug.Print(" ICON_NAME:-" & strIcon_Name & "; FILENAME:- " & strFile(Documentlinklabel.DocPath) & "; Icon:- " & ByteIcon.ToString)

                        If ByteIcon.ToString.Length <> 0 Then
                            ' xLnkOrigmail.Text = Trim(strIcon_Name)
                            '   xLnkOrigmail.TagId = 0 'this is docid in disigne is defined 0
                            xLnkOrigmail.TagPath = Trim(strIcon_Name) & "." & strFile(Documentlinklabel.DocExtention)
                            xLnkOrigmail.TagByte = ByteIcon
                            'xLnkOrigmail.TagPath = strFile(Documentlinklabel.DocPath)
                            xLnkOrigmail.TagExtention = strFile(Documentlinklabel.DocExtention)
                            xLnkOrigmail.BackColor = Color.Violet
                            xLnkOrigmail.Tag = Guid.NewGuid().ToString  'new guid each time when add mail
                        End If

                    End If

                    MsgBox("New document was added successfully.")
                End If 'deleted is true
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xLnkOrigmail_DragEnter(sender As Object, e As DragEventArgs) Handles xLnkOrigmail.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xLnkOrigmail_MouseClick(sender As Object, e As MouseEventArgs) Handles xLnkOrigmail.MouseClick
        Try

            If xLnkOrigmail.TagByte Is Nothing Then Exit Sub
            Call openDocument(xLnkOrigmail.TagPath, xLnkOrigmail.TagByte)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstViewCustomerMiddle_LostFocus(sender As Object, e As EventArgs) Handles lstViewCustomerMiddle.LostFocus
        Try

            Select Case lblMiddleLineNameDisplay.Tag
                Case ListViewName.Additional_Location


            End Select


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub lstViewCustomerMiddle_KeyUp(sender As Object, e As KeyEventArgs) Handles lstViewCustomerMiddle.KeyUp
        Try
            If e.KeyCode = Keys.Tab Then
                txtBox.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvStoryBoard_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvStoryBoard.CellFormatting
        Try
            'added all 3.29.2018
            Dim guidReqitem As String = ""
            Dim cptAdditional As Int32 = 0

            Dim cptDoc As Int32 = 0
            Dim strDocumentConj As String = ""
            Dim decMet As String = ""
            Dim impLoc As String = ""

            Dim dgv As DataGridView
            dgv = sender

            guidReqitem = dgv.Rows(e.RowIndex).Cells(Request.GUID).Value

            'If e.ColumnIndex = CInt(Request.IMP_DESCRIPTION) Then
            '    Debug.Print("mouse wheel RowIndex: " & e.RowIndex & dgv.Rows(e.RowIndex).Cells(Request.IMP_DESCRIPTION).ToolTipText)
            '    dgv.Rows(e.RowIndex).Cells(Request.IMP_DESCRIPTION).ToolTipText = "Custom text for item_master_id:" & dgv.Rows(e.RowIndex).Cells(Request.item_master_id).Value
            'End If

            '---------------------------------------------------------------------
            '++ID 4.12.2018 ----
            If dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value = "K" Then Exit Sub
            '-------------------
            'add color for cell if reqitemid is exist in addtional list
            Select Case e.ColumnIndex
                Case CInt(Request.IMP_DESCRIPTION)
                    '  If dgvStoryBoard.Rows(e.RowIndex).Cells(Request.Is_kit).Value <> "K" Then Exit Sub
                    If Not olstReItems_AdditDetail Is Nothing Then

                            comboboxCellrec = New DataGridViewComboBoxCell
                            comboboxCellrec = DirectCast(dgv.Item(Request.IMP_DESCRIPTION, e.RowIndex), DataGridViewComboBoxCell)

                            cptAdditional = olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = guidReqitem).Count

                            If cptAdditional <> 0 Then

                                comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                                '  comboboxCellrec.FlatStyle = FlatStyle.Flat
                                comboboxCellrec.Style.BackColor = Color.Violet

                                comboboxCellrec.Style.ForeColor = Color.White

                                dgv.Rows(e.RowIndex).Cells(CInt(Request.IMP_DESCRIPTION)).ToolTipText = ""

                                'For i As Integer = 0 To cptAdditional - 1
                                '    '  comboboxCellrec.ToolTipText &= "Aditional Location fro DECO_METH:" & olstReItems_AdditDetail.Item(i).imp_desc_id & ",LOCATION:" & olstReItems_AdditDetail.Item(0).imp_desc_id & vbCrLf

                                '    dgv.Rows(e.RowIndex).Cells(CInt(Request.IMP_DESCRIPTION)).ToolTipText &= "Aditional Location fro DECO_METH:" & olstReItems_AdditDetail.Item(i).imp_desc_id & ",LOCATION:" & olstReItems_AdditDetail.Item(0).imp_desc_id & vbCrLf

                                'Next

                                For Each loc As cReqItems_AdditLocation In olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = guidReqitem)
                                    decMet = ""
                                    impLoc = ""
                                    oMDB_CFG_IMP_LOC = New cMDB_CFG_IMP_LOC
                                    oMDB_CFG_DEC_MET = New cMDB_CFG_DEC_MET

                                    oMDB_CFG_DEC_MET.Load(CInt(loc.dec_met_id))
                                    decMet = oMDB_CFG_DEC_MET.DEC_MET_NAME
                                    oMDB_CFG_IMP_LOC.Load(CInt(loc.imp_desc_id))
                                    impLoc = oMDB_CFG_IMP_LOC.IMP_DESC

                                    '      dgv.Rows(e.RowIndex).Cells(CInt(Request.IMP_DESCRIPTION)).ToolTipText &= "Addit. Location for DECO_METH: " & loc.dec_met_id & "-" & decMet & ", LOCATION:" & loc.imp_desc_id & "-" & impLoc & vbCrLf
                                    dgv.Rows(e.RowIndex).Cells(CInt(Request.IMP_DESCRIPTION)).ToolTipText &= "DECO_METH: " & loc.dec_met_id & "-" & decMet & ", LOCATION:" & loc.imp_desc_id & "-" & impLoc & vbCrLf
                                Next

                            Else
                                comboboxCellrec.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                                '  comboboxCellrec.FlatStyle = FlatStyle.Standard
                                comboboxCellrec.Style.BackColor = Color.White
                                comboboxCellrec.Style.ForeColor = Color.Maroon
                                dgv.Rows(e.RowIndex).Cells(CInt(Request.IMP_DESCRIPTION)).ToolTipText = ""

                            End If
                        End If
                Case CInt(Request.IMPRINT_LOGO)

                    If Not olstReqDocBindItem Is Nothing Then
                            cptDoc = olstReqDocBindItem.FindAll(Function(c As cReqDocBindItem) c.ItemGuid = guidReqitem).Count

                            If cptDoc > 0 Then
                                strDocumentConj = " documents "
                            Else
                                strDocumentConj = " document "
                            End If

                            If cptDoc <> 0 Then
                                dgv.Rows(e.RowIndex).Cells(CInt(Request.IMPRINT_LOGO)).Style.BackColor = Color.Violet
                                dgv.Rows(e.RowIndex).Cells(CInt(Request.IMPRINT_LOGO)).ToolTipText = cptDoc & strDocumentConj & " assigned for it."
                            End If
                        End If
                        '------------------------------------------------------------------------


                End Select



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnAddLoc_Click(sender As Object, e As EventArgs) Handles btnAddLoc.Click
        Try
            If dgvStoryBoard.RowCount = 0 Then
                Exit Sub
            End If

            If dgvStoryBoard.CurrentRow.Cells(Request.item_master_id).FormattedValue = "" Then
                Exit Sub
            End If



            'Use objects in below function
            'are declared like private objects in same file frmVirtual_Request
            oReqItems_AdditDetail_Work = New cReqItems_AdditLocation
            olstReItems_AdditDetail_Work = New List(Of cReqItems_AdditLocation)

            'initialise variable, them are used only in that event for additional imprint location
            reqItemsId = 0
            reqItemsGuid = String.Empty
            reqItemsGuidParent = String.Empty
            'assigne variable
            'TSM.Tag have info about rowindex which was  clicked with right click in dgvStoryBoard_MouseClick

            If Not dgvStoryBoard.CurrentRow.Cells(CInt(Request.ReqItemId)).Value Is Nothing Then
                If CInt(dgvStoryBoard.CurrentRow.Cells(CInt(Request.ReqItemId)).Value) <> 0 Then reqItemsId = CInt(dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.ReqItemId).Value)
            End If

            reqItemsGuid = Trim(CStr(dgvStoryBoard.CurrentRow.Cells(Request.GUID).Value.ToString))

            'If Not dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value Is Nothing Then
            'True is  NullAnd Empty
            'False is filled
            If String.IsNullOrEmpty(Trim(dgvStoryBoard.CurrentRow.Cells(Request.Parent_GUID).Value.ToString)) <> True Then
                '  If dgvStoryBoard.Rows(CInt(TSM.Tag)).Cells(Request.Parent_GUID).Value.ToString <> String.Empty Then
                reqItemsGuidParent = Trim(CStr(dgvStoryBoard.CurrentRow.Cells(Request.Parent_GUID).Value.ToString))
                '   End If
            End If
            'olstReItems_AdditDetail is loaded when program is started
            If Not olstReItems_AdditDetail Is Nothing Then
                If olstReItems_AdditDetail.Count <> 0 Then
                    If Not olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = reqItemsGuid) Is Nothing Then
                        olstReItems_AdditDetail_Work = olstReItems_AdditDetail.FindAll(Function(c As cReqItems_AdditLocation) c.ReqItemGuid = reqItemsGuid)
                    End If
                End If
            End If

            'if we have records for this line, take it.

            'call function for open additional Imrint Location
            Call Additional_Lst(reqItemsGuid, TakeData_DGVStBoard, reqItemsId, reqItemsGuidParent)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'move
    Private Sub panItemComment_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panItemComment.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub
    Private Sub panItemComment_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panItemComment.MouseMove
        If allowCoolMove = True Then
            panItemComment.Location = New Point(panItemComment.Location.X + e.X - myCoolPoint.X, panItemComment.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub panItemComment_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panItemComment.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblCloseItemComm_MouseClick(sender As Object, e As MouseEventArgs) Handles lblCloseItemComm.MouseClick
        Try

            panItemComment.Visible = False
            dgvStoryBoard.Rows(CInt(xTxtItemComment.Tag)).Cells(CInt(Request.ReqItemComm)).Value = xTxtItemComment.Text

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtItemComment_TextChanged(sender As Object, e As EventArgs) Handles xTxtItemComment.TextChanged
        Try
            lblCaracterLimItemComm.Left = 1
            lblCaracterLimItemComm.Text = "Text Length : " & xTxtItemComment.TextLength

            '  xTxtItemComment.TextLength  = 2
            If xTxtItemComment.TextLength > 500 Then
                lblCaracterLimItemComm.ForeColor = Color.White
                lblCaracterLimItemComm.BackColor = Color.Red
                MsgBox("You have reached the text limit. 500 characters max.")

                '  lblCaracterLimItemComm.ForeColor = Color.Red


                xTxtItemComment.Text = xTxtItemComment.Text.Substring(0, 500)

            Else

                lblCaracterLimItemComm.ForeColor = Color.Maroon
                lblCaracterLimItemComm.BackColor = Color.Transparent

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblSendEmailCSR_Click(sender As Object, e As EventArgs) Handles lblSendEmailCSR.Click
        Try
            '++ID 4.12.2018 
            Select Case oExact_Traveler_Permission.perm_group_id
                Case 182 'Gr 182 
                    ' save comunication only
                    '  Call DocumentsAddDB()
                    Call RetriveCommentsAddInDB()

                    Call SendEmail_ByStatus(CInt(lblTextStatusInfo.Tag))

            End Select

        Catch ex As Exception

        End Try
    End Sub

    '---------------------------------- Work with new display of email ------------------------------------------------
    Public Sub SendEmailNewDisplay()
        Dim CPT As Int32 = 0
        Try
            Dim strQuery As String = ""
            Dim oCfgEnum1 As cCfgEnum
            Dim olsCfgEnum1 As List(Of cCfgEnum)

            Dim oReqSentMail As cReqSentMails
            Dim olstReqSentMails As List(Of cReqSentMails)

            Dim Message As String = ""
            Dim valImp As String = ""
            Dim valMet As String = ""
            Dim valPatch_Shape As String = ""
            Dim valPatch_Color As String = ""
            Dim valArea As String = ""
            Dim valDefaultLoc As Integer = 0
            Dim listFileAddress As List(Of String) = New List(Of String)
            Dim valItemMasterKit As String = ""
            Dim valItemMasterKit_Cd As String = ""
            Dim valDocLoc As String = ""
            Dim valColorName As String = ""
            Dim valTreadColor As String = ""
            Dim valBackGroundColor As String = ""
            Dim valStampingPattern As String = ""
            Dim bindDocuments As String = ""

            oReqDocBindItem = New cReqDocBindItem
            olstReqDocBindItem = New List(Of cReqDocBindItem)

            'load oj binded items, the data is anly text
            '    olstReqDocBindItem = oReqDocBindItem.LoadLst("select * from ReqDocBindItem")
            Dim sqlDocBind As String = " select d.* from  ReqDocBindItem d inner join ReqItems i on " _
                 & "  d.ItemGuid = i.GUID    where " _
                  & " requestid =   " & RequestID & " AND   ReviewId = " & ReviewId

            olstReqDocBindItem = oReqDocBindItem.LoadLst(sqlDocBind)


            '   If chkSendToGraphic.CheckState = CheckState.Checked Then


            If Trim(xTxtShowSenderEmail.Text) = "" Then
                MsgBox("Email address is empty please enter or choose from list. E-mail is not sent." & vbCrLf & " Thank you")
                Exit Sub
            End If


            'sent to graphic
            'need put in function and for now all mail will be sent to Erin
            oExact_Traveler_Permission = New cExact_Traveler_Permission
            If oExact_Traveler_Permission.Load(" where p.Email = '" & Trim(xTxtShowSenderEmail.Text) & "'") <> True Then

                MsgBox(Trim(xTxtShowSenderEmail.Text & " e-Mail is wrong."))
                Exit Sub
            End If

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            Dim oMessage As New cMail()
            oMessage.FromAddr = oExact_Traveler_Permission.Email
            oMessage.ToAddr = Trim(xTxtShowSenderEmail.Text) & "," & oExact_Traveler_Permission.Email '"erin@spectorandco.com"

            '++ID 02.29.2022 commneted email iond@
            'oMessage.CCAddr = "iond@spectorandco.ca"
            oMessage.Subject = "Message from : " & Trim(lblStoryBoard.Text) & Trim(xtxtReqItemCode.Text)

            '++ID 4.12.2018 reduce fro send documetns 
            If chkSendOnlyComm.CheckState <> CheckState.Checked Then
                '--------------------- document place -----------------------------
                If olstMdb_Item_Doc_Attach IsNot Nothing Then
                    For Each d As cMdb_Item_Doc In olstMdb_Item_Doc_Attach
                        If d.Item_Doc_Type_Id <> 24 Then
                            valDocLoc = WriteInExact(d.Item_Doc_Name.Replace("?", "") & "." & d.Item_Doc_File_Ext, d.Item_Doc)
                            oMessage.AddAttachment(valDocLoc)
                            listFileAddress.Add(valDocLoc)
                        End If
                    Next
                End If
                '-------------------------------------------------------------------
            End If 'If chkSendOnlyComm.CheckState <> CheckState.Checked Then

            Message = "<html>
<head>
<style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
</style>


</head>
<body>"

            Message &= "<p ><font size='5'> " & Trim(lblStoryBoard.Text) & "   " & Trim(xtxtReqItemCode.Text) & "</font></p>.<br/> <br/>"
            Message &= lblTextStatusInfo.Text & "<br/>" ' & txtbtnStatus.Tag & "-" & txtbtnStatus.Text 

            If chkRushOrder.CheckState = CheckState.Checked Then Message &= "Is Rush Order : YES. <br/> <br/>"
            Message &= " For Customer : " & Trim(txtCustomer.Text) & " - " & Trim(lblCustomerName.Text) & ".<br/><br/>"
            Message &= " Customer Contact : " & Trim(lnkLblContactShow.Text) & ",  e-mail : " & Trim(lblContactEmail.Text) & ".<br/> <br/> <br/>"

            Message &= "<a  href='M:/mcc/traveler executable/CustomerFile/CustomerFile.exe' > - >Customer File Program< - </a>.<br/> <br/> <br/>"



            '------------------------Add comments in e-mail -------------------------------------------
            ' Message &= "</br> </br>"

            oReqCommunic = New cReqCommunication
            olstReqCommunic = New List(Of cReqCommunication)

            '------------------------------ Display txtSpecInstrReceive -----------------------------
            olstReqCommunic = New List(Of cReqCommunication)
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

            Message &= "<Table> <tr><td><font style='color:blue;'> Comments from CS:  </font> </td> <td><font style='color:blue;'>  Comments from Graphics : </font></td></tr>"
            Message &= "<tr><td style='vertical-align: top;  text-align: left;'> " & " "
            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    Message &= comm.MessageInstruction & "<br/> "
                Next
            End If

            Message &= "</td>"
            '----------------------------------------------------------------------------------------

            '------------------------------- Display txtRecCommGraph --------------------------------
            olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")
            Message &= "<td style='vertical-align: top;  text-align: left;'> "
            If Not olstReqCommunic Is Nothing Then
                For Each comm As cReqCommunication In olstReqCommunic
                    Message &= comm.MessageInstruction & "<br/> "
                Next
            End If

            '----------------------------------------------------------------------------------------

            Message &= "</td></tr></table>"



            If chkSendOnlyComm.CheckState <> CheckState.Checked Then

                '     Message &= "<table  > 
                '<tr bgcolor='#8FBC8F'  > 
                '             <td> SKU - Color </td>  <td> Kit:Y/N </td>  <td> Deco/Method </td> <td> Deco/Location </td> <td> Area/Size </td> 
                '             <td> Imprint/Color </td> <td> Imprint/Logo </td> <td> Patch/Shape </td> <td> Patch/Color </td> 
                '             <td> Thread Color </td> <td> BackGround Color </td> <td> Stamping Pattern </td>  
                '</tr> "
                oReqItems = New cReqItems
                olstReqItems = New List(Of cReqItems)

                If olstReqItems IsNot Nothing Then

                    'don''t  need table
                    strQuery = " select ri.* from ReqItems ri where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'" _
                            & "   union   " _
                            & " select ri.ReqItemId,RequestId = 0,ReviewId = 0,ri.item_master_id,ItemCd = '',Is_Kit = '',prod_category= '',Maco_desc1 = '',color_id = 0, " _
                            & " item_no = '',l.dec_met_id, l.imp_desc_id, l.patch_shape, ri.GUID, ri.parent_guid, CreateBy = 0,  " _
                            & " CreateByFullName = '', CreateDate = '', ModifyBy = 0, ModifyByFullName = '', ModifyDate = '',l.imprint_color ,l.imprint_logo ,l.patch_color, " _
                            & " l.Thread_Color, l.BackGround_Color,l.StampingPattern,ri.ReqItemComm  from ReqItems ri right join ReqItems_AdditLocation l on " _
                            & " ri.ReqItemId = l.ReqItemId   where RequestId =  '" & RequestID & "' and ReviewId = '" & ReviewId & "'  order by ReqItemId,RequestId  desc "

                    strQuery = "  select * from " _
                             & " ( " _
                             & " Select *, Addit_Loc_Mess = '' from ReqItems  " _
                             & "   union " _
                             & " select r.reqitemId, r.requestID, r.Reviewid, r.item_master_id, r.itemcd , r.is_kit, r.prod_Category, r.maco_desc1, r.color_id, r.item_no, " _
                             & " a.dec_met_id, a.imp_desc_id, a.patch_shape, r.Guid, r.parent_guid, a.createBy, a.CreateByFullName, a.createDate, a.ModifyBy, " _
                             & " a.ModifyByFullName, a.modifyDate, a.imprint_color, a.imprint_logo, a.patch_color, a.Thread_Color, a.Background_Color, " _
                             & " a.StampingPattern,a.ReqItemComm, " _
                             & " Cast(r.itemcd + ' - ' + [dbo].[Give_MDB_COLOR_CD](r.color_id,2) as Varchar(60)) as Addit_Loc_Mess " _
                             & "  from reqitems r right join ReqItems_AdditLocation a on r.ReqItemId = a.reqItemId  " _
                             & " )  as look  " _
                             & " where look.RequestId =  '" & RequestID & "' and look.ReviewId = '" & ReviewId & "'  order by reqitemId,Addit_Loc_Mess asc "




                    olstReqItems = oReqItems.LoadLst_ForEmail(strQuery)

                    oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                    olstImp_Loc_VIEW = New List(Of cMdb_Item_Imp_Loc_VIEW)

                    Dim oRItems As New cReqItems
                    Dim olstRItems As List(Of cReqItems)

                    oRItems = New cReqItems
                    olstRItems = New List(Of cReqItems)

                    olstRItems = oReqItems.LoadLst_ForEmail(strQuery) 'LoadLst("WHERE  RequestId = " & RequestID & " and reviewId = " & ReviewId)

                    oMDB_CFG_IMP_LOC = New cMDB_CFG_IMP_LOC
                    olstMDB_CFG_IMP_LOC = New List(Of cMDB_CFG_IMP_LOC)
                    olstMDB_CFG_IMP_LOC = oMDB_CFG_IMP_LOC.LoadLst

                    oMDB_CFG_DEC_MET = New cMDB_CFG_DEC_MET
                    olstMDB_CFG_DEC_MET = New List(Of cMDB_CFG_DEC_MET)
                    olstMDB_CFG_DEC_MET = oMDB_CFG_DEC_MET.LoadLst

                    oCfgEnum = New cCfgEnum
                    olsCfgEnum = New List(Of cCfgEnum)
                    olsCfgEnum = oCfgEnum.LoadEnumCat("PATCH_SHAPE")

                    oCfgEnum1 = New cCfgEnum
                    'olsCfgEnum1 = New List(Of cCfgEnum)
                    'olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                    oMdb_cfg_Color = New cMdb_Cfg_Color
                    olstMdb_Cfg_Color = New List(Of cMdb_Cfg_Color)

                    olstMdb_Cfg_Color = oMdb_cfg_Color.Load

                    'start FOR EACH  olstReqItems
                    For Each item As cReqItems In olstReqItems
                        CPT += 1
                        olsCfgEnum1 = New List(Of cCfgEnum)
                        '    olsCfgEnum1 = oCfgEnum.LoadEnumCat("PATCH_COLOR")

                        If (item.dec_met_id = 88 Or item.dec_met_id = 131 Or item.dec_met_id = 138) Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08BP44")
                        ElseIf item.dec_met_id = 133 Then
                            olsCfgEnum1 = oCfgEnum1.LoadEnumCat("PATCH_COLOR", "08ROLLMET")
                        End If

                        valArea = ""
                        valDefaultLoc = 0
                        valImp = ""
                        valMet = ""
                        valItemMasterKit = ""
                        valPatch_Shape = ""
                        valPatch_Color = ""
                        valColorName = ""

                        Try
                            If Not olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id) Is Nothing Then
                                valColorName = olstMdb_Cfg_Color.Find(Function(i As cMdb_Cfg_Color) i.COLOR_ID = item.color_id).COLOR_NAME
                            End If
                        Catch ex As Exception
                            MsgBox("Error in " & Me.Name & ". Assigne color name" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                        End Try


                        If Trim(item.Addit_Loc_Mess.Length) = 0 Then
                            If item.parent_guid <> "" Then
                                If Not olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid) Is Nothing Then valItemMasterKit_Cd = item.Is_Kit & "-" & olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).ItemCd
                            Else
                                valItemMasterKit_Cd = item.Is_Kit
                            End If

                            If valItemMasterKit_Cd.IndexOf("-") = -1 Then
                                Message &= "<br/>------------------------------------------------------------- <br/>"
                            Else
                                Message &= "<br/>"
                            End If

                            Message &= " SKU - Color : <font style='color:blue;'>" & item.ItemCd & "-" & Trim(valColorName) & "</font> <br/> "

                            'If item.parent_guid <> "" Then
                            '    If Not olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid) Is Nothing Then valItemMasterKit_Cd = item.Is_Kit & "-" & olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).ItemCd
                            'Else
                            '    valItemMasterKit_Cd = item.Is_Kit
                            'End If

                            If valItemMasterKit_Cd = "K" Then
                                Message &= " Kit:Y/N : <font style='color:red;'>" & valItemMasterKit_Cd & "</font><br/> "
                            ElseIf valItemMasterKit_Cd.IndexOf("-") <> -1 Then
                                Message &= " Kit:Y/N : <font style='color:red;'>" & valItemMasterKit_Cd & "</font><br/> "
                            Else
                                Message &= " Kit:Y/N : " & valItemMasterKit_Cd & "<br/> "
                            End If

                        Else
                            'exception if item have additional location
                            Dim additLocation As String = ""
                            additLocation = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).ItemCd

                            'Message &= "<font style='color:red;'> -  ADITIONAL LOCATION FOR ITEM NO : </font> <font style='color:blue;'>" & Trim(additLocation).ToUpper & "-" & Trim(valColorName) & "</font><br/>"

                            Message &= "<br/> <font style='color:red;'> - Additional location for style : </font> <font style='color:blue;'>" & item.Addit_Loc_Mess & "</font> <br/>"

                        End If

                        If item.dec_met_id <> 0 Then
                            If Not olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id) Is Nothing Then valMet = olstMDB_CFG_DEC_MET.Find(Function(i As cMDB_CFG_DEC_MET) i.DEC_MET_ID = item.dec_met_id).DEC_MET_NAME

                            Message &= " Decorating Method : <font style='color:blue;'>" & valMet & "</font><br/>"
                        End If

                        If item.imp_desc_id <> 0 Then
                            If Not olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id) Is Nothing Then valImp = olstMDB_CFG_IMP_LOC.Find(Function(i As cMDB_CFG_IMP_LOC) i.IMP_LOC_ID = item.imp_desc_id).IMP_DESC

                            Message &= " Decorating Location : <font style='color:blue;'>" & valImp & "</font><br/>  "
                        End If

                        If item.parent_guid = "" Then 'Item is not kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then
                                If item.item_master_id = 0 Then
                                    item.item_master_id = olstRItems.Find(Function(c As cReqItems) c.ReqItemId = item.ReqItemId).item_master_id
                                End If

                                '  olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(item.item_master_id)

                                'If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE

                                'valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                            End If

                            ' Message &= "<td>" & valArea & " </td> "

                            '  If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"

                        ElseIf item.parent_guid <> "" Then 'item Is component of the kit

                            If item.dec_met_id <> 0 AndAlso item.imp_desc_id <> 0 Then

                                valItemMasterKit = olstRItems.Find(Function(i As cReqItems) i.GUID = item.parent_guid).item_master_id
                                olstImp_Loc_VIEW = oMdb_Item_Imp_Loc_VIEW.LoadDecMetComp_List(valItemMasterKit, item.item_master_id, item.dec_met_id)

                                If Not olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id) Is Nothing Then
                                    '     valArea = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).AREA_SIZE
                                    '   valDefaultLoc = olstImp_Loc_VIEW.Find(Function(i As cMdb_Item_Imp_Loc_VIEW) i.Dec_Met_Id = item.dec_met_id And i.Imp_Loc_Id = item.imp_desc_id).Default_Loc
                                End If

                                '       Message &= "<td>" & valArea & " </td> "

                                '    If valDefaultLoc = 1 Then Message &= "<td>Yes</td>" Else Message &= "<td>Not</td>"
                            Else
                                ' Message &= "<td> </td>  <td> </td>"
                            End If
                        End If

                        '  Message &= "Imprint Color : <font style='color:blue;'>" & item.IMPRINT_COLOR & "</font> <br/> Imprint/Logo : <font style='color:blue;'>" & item.IMPRINT_LOGO & "</font> <br/> "
                        If String.IsNullOrEmpty(item.IMPRINT_COLOR) = False Then Message &= "Imprint Color : <font style='color:blue;'>" & item.IMPRINT_COLOR & "</font> <br/>"
                        If String.IsNullOrEmpty(item.IMPRINT_LOGO) = False Then Message &= "Imprint/Logo : <font style='color:blue;'>" & item.IMPRINT_LOGO & "</font> <br/>"



                        If item.patch_shape <> 0 Then
                            If Not olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape) Is Nothing Then valPatch_Shape = olsCfgEnum.Find(Function(i As cCfgEnum) i.Enum_ID = item.patch_shape).Enum_Value
                            Message &= "Patch Shape : <font style='color:blue;'>" & valPatch_Shape & "</font> <br/> "
                        End If

                        '++ID 1.15.2018 added patch_color
                        If item.Patch_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color) Is Nothing Then valPatch_Color = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Patch_Color).Enum_Value
                            Message &= "Patch Color : <font style='color:blue;'>" & valPatch_Color & "</font><br/> "
                        End If

                        If item.Thread_Color <> 0 Then
                            If Not olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color) Is Nothing Then valTreadColor = olsCfgEnum1.Find(Function(i As cCfgEnum) i.Enum_ID = item.Thread_Color).Enum_Value
                            Message &= "Thread Color : <font style='color:blue;'>" & valTreadColor & "</font><br/>"
                        End If

                        If String.IsNullOrEmpty(item.BackGround_Color) = False Then
                            If Trim(item.BackGround_Color).Length > 1 Then Message &= "BackGround Color : <font style='color:blue;'>" & item.BackGround_Color & "</font><br/>"
                        End If

                        If String.IsNullOrEmpty(item.StampingPattern) = False Then
                            If Trim(item.StampingPattern).Length > 1 Then Message &= "StampingPattern : <font style='color:blue;'>" & item.StampingPattern & "</font><br/> "
                        End If

                        If String.IsNullOrEmpty(item.ReqItemComm) = False Then
                            If Trim(item.ReqItemComm).Length > 1 Then Message &= "Item Comment : <font style='color:blue;'>" & item.ReqItemComm & "</font> <br/>"
                        End If

                        'show documents if are joint
                        'olstMdb_Item_Doc_Attach
                        'item.ReqItemId
                        'olstReqDocBindItem

                        If Not olstReqDocBindItem.FindAll(Function(c As cReqDocBindItem) c.ReqItemId = item.ReqItemId) Is Nothing Then
                            If olstReqDocBindItem.FindAll(Function(c As cReqDocBindItem) c.ReqItemId = item.ReqItemId).Count <> 0 Then
                                bindDocuments = ""
                                For Each docBind As cReqDocBindItem In olstReqDocBindItem.FindAll(Function(c As cReqDocBindItem) c.ReqItemId = item.ReqItemId)

                                    If Not olstMdb_Item_Doc_Attach.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Id = docBind.DocId) Is Nothing Then
                                        bindDocuments &= olstMdb_Item_Doc_Attach.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Id = docBind.DocId).Item_Doc_Name &
                                                                       "." & olstMdb_Item_Doc_Attach.Find(Function(i As cMdb_Item_Doc) i.Item_Doc_Id = docBind.DocId).Item_Doc_File_Ext & ", "
                                    End If


                                Next

                                Message &= "Documents attached for Item :  <font style='color:blue;'>" & bindDocuments & "</font><br/>"

                            End If
                        End If

                    Next

                End If
                '                Message &= " </table> "
            End If 'If chkSendOnlyComm.CheckState <> CheckState.Checked Then

            ''------------------------Add comments in e-mail -------------------------------------------
            'Message &= "</br> </br>"

            'oReqCommunic = New cReqCommunication
            'olstReqCommunic = New List(Of cReqCommunication)

            ''------------------------------ Display txtSpecInstrReceive -----------------------------
            'olstReqCommunic = New List(Of cReqCommunication)
            'olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId  not in (182)  order by commId asc ")

            'Message &= "<Table> <tr><td><font style='color:blue;'> Comments from CS:  </font> </td> <td><font style='color:blue;'>  Comments from Graphics : </font></td></tr>"
            'Message &= "<tr><td style='vertical-align: top;  text-align: left;'> " & " "
            'If Not olstReqCommunic Is Nothing Then
            '    For Each comm As cReqCommunication In olstReqCommunic
            '        Message &= comm.MessageInstruction & "<br/> "
            '    Next
            'End If

            'Message &= "</td>"
            ''----------------------------------------------------------------------------------------

            ''------------------------------- Display txtRecCommGraph --------------------------------
            'olstReqCommunic = oReqCommunic.LoadLst(" where RequestId = " & RequestID & " and ReviewID = " & ReviewId & " and TypeId = 182  order by commId asc")
            'Message &= "<td style='vertical-align: top;  text-align: left;'> "
            'If Not olstReqCommunic Is Nothing Then
            '    For Each comm As cReqCommunication In olstReqCommunic
            '        Message &= comm.MessageInstruction & "<br/> "
            '    Next
            'End If

            ''----------------------------------------------------------------------------------------

            'Message &= "</td></tr></table>"
            Message &= "</body> </html>"

            oMessage.Message = Message
            oMessage.Send()

            MsgBox("E-Mail was send successfully towards " & Trim(xTxtShowSenderEmail.Text))


            For Each s As String In listFileAddress
                If File.Exists(s) Then
                    File.Delete(s)
                End If
            Next

            '---------------------- save email --------------------------

            oReqSentMail = New cReqSentMails
            olstReqSentMails = New List(Of cReqSentMails)

            'where requestid = '" & RequestID & "' and reviewid = '" & ReviewId & 

            With oReqSentMail
                .RequestId = RequestID
                .ReviewID = ReviewId
                .SentTo = Trim(xTxtShowSenderEmail.Text)
                .HTMLdata = Message
                .Save()
            End With
            '------------------------------------------------------------
            'Else

            'End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & ". CPT = " & CPT & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnDocItem_Click(sender As Object, e As EventArgs) Handles btnDocItem.Click
        Try

            reqItemsId = CInt(dgvStoryBoard.CurrentRow.Cells(Request.ReqItemId).Value)
            reqItemsGuid = dgvStoryBoard.CurrentRow.Cells(CInt(Request.GUID)).Value

            Call DocumentsAddDB()

            'add function for display documents
            Call BindItem_Image(reqItemsGuid)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub pan1DocStok_Click(sender As Object, e As EventArgs) Handles pan1DocStok.Click
        Try

            Dim p As Panel
            p = sender

            p.Height += 100

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pan1DocStok_MouseLeave(sender As Object, e As EventArgs) Handles pan1DocStok.MouseLeave
        Try

            Dim p As Panel
            p = sender

            p.Height = 103

        Catch ex As Exception

        End Try
    End Sub


    '------------------------------------------------------------------------------------------------------------------

    'try to load the form
    Private Sub LoadForm()
        Try
            Dim strQuery As String
            'for additional listview
            'use for activate xTxtShowSenderEmail_TextChanged 
            'because default is type of request and email is selected by type 
            'now if you user want send any other person need click on the xTxtShowSenderEmail_DoubleClick and variable will take True value
            'and xTxtShowSenderEmail_TextChanged is activate for his event
            VarActivateEmailSearch = False
            varDelete = False

            'text bow will displayed when  lnlLabelContactShow is clicked
            txtContactSearch.Hide()
            txtContactSearch.Location = New Point(105, 42)

            lstBoxAdd.Hide()
            panLstBoxAdd.Hide()
            txtBox.Hide()

            oMdb_Cfg_Item_Doc_Type = New cMdb_Cfg_Item_Doc_Type
            olstMdb_Cfg_Item_Doc_Type = New List(Of cMdb_Cfg_Item_Doc_Type)
            'fill list with all type
            olstMdb_Cfg_Item_Doc_Type = oMdb_Cfg_Item_Doc_Type.Load("")

            oReqItems = New cReqItems()
            olstReqItems = New List(Of cReqItems)
            olstReqItems_old = New List(Of cReqItems)

            '------------------- location for label ------------------------
            Call LabelPositionInMiddle()

            '------------- Checkbox for sent email need for future put in a function ---------------
            'oExact_Traveler_Permission = New cExact_Traveler_Permission
            'With chkSendToGraphic
            '    Select Case oExact_Traveler_Permission.perm_group_id
            '        Case 182 'IT 179,Graphics 182
            '            .Enabled = False
            '        Case Else
            '            .Enabled = True
            '    End Select
            'End With
            '----------------------------

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If oExact_Traveler_Permission.perm_group_id <> 182 Then
                txtSpecInstrWrite.Enabled = True
                lblSendEmailCSR.Enabled = False
                lblTimeStampGR.Enabled = False
            ElseIf oExact_Traveler_Permission.perm_group_id = 182 Then
                txtSendCommFromGraph.Enabled = True
                '++ID Graphic don't need save the request
                'if click on the status, it will be inserted in DB in status table
                'for comunication graphic will use button sent to CSR comunication
                txtbtnSave.Enabled = False
                lblTimeStampCS.Enabled = False
            End If
            '---------------------------------------------------------------
            Call loadNew_Story()
            '----------------------- load documents ------------------------
            Call DisplayDocInPanel()
            'show how much is size of Document Panel
            lblDetailSizeRezult.Text = FilesSize(0).ToString & "KB - " & FormatNumber(FilesSize(0) / 1024, 0) & "MB"
            '---------------------------------------------------------------

            Call Columns_VirtualRequest(dgvStoryBoard, Me)

            'chec if exist items for this requestId & reviewId
            'if exist don't add default line in the grid
            strQuery = " where requestId = " & RequestID & " and reviewId = " & ReviewId
            olstReqItems = oReqItems.LoadLst(strQuery)
            'keep that value until form is close
            'when user exit from storyboard need comparate old value with new 
            'was declared in modGlobal
            olstReqItems_old = olstReqItems

            If olstReqItems.Count = 0 Then
                'this is default line added in dgvStoryboard in the case if is new request
                dgvStoryBoard.Rows.Add()
                dgvStoryBoard.CurrentRow.Height = 30
                dgvStoryBoard.BeginEdit(True)
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).ReadOnly = False

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Value = "X"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Tag = "0"

                dgvStoryBoard.CurrentRow.Cells(CInt(Request.item_master_id)).Value = "0"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.ReqItemId)).Value = "0"
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.GUID)).Value = ""
                dgvStoryBoard.CurrentRow.Cells(CInt(Request.Parent_GUID)).Value = ""

                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.Font = New Font("Arial", 14, FontStyle.Bold)
                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'dgvStoryBoard.CurrentRow.Cells(CInt(Request.x)).Style.BackColor = Color.Red

                dgvStoryBoard.BeginEdit(False)
            ElseIf olstReqItems.Count <> 0 Then
                'function fro load grid was before 

                ''put function for populate grid from cReqItems
                'If PopulateGridFromDB() <> True Then
                '    MsgBox("Grid Is Not filled properly.")
                'End If

                '++ID 1.16.2018 check the addtional location for the displayed Items
                'this declaration or variable never initialize is global
                oReqItems_AdditDetail = New cReqItems_AdditLocation
                olstReItems_AdditDetail = New List(Of cReqItems_AdditLocation)
                olstReqItems_AdditDetail_Old = New List(Of cReqItems_AdditLocation)


                strQuery = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqItems_AdditLocation ra WITH (Nolock) on " _
                              & " r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " and ReviewId = " & ReviewId & ""

                olstReItems_AdditDetail = oReqItems_AdditDetail.LoadLst(strQuery)

                'keep old list for coomparate old list with new 
                olstReqItems_AdditDetail_Old = olstReItems_AdditDetail


                '++ID 2.13.2018
                'check if we have anything in ReqDocBindItem
                oReqDocBindItem = New cReqDocBindItem
                olstReqDocBindItem = New List(Of cReqDocBindItem)

                strQuery = "select ra.* from ReqItems r WITH (Nolock)  inner join ReqDocBindItem ra WITH (Nolock) " _
                     & " on r.ReqItemId = ra.ReqItemId  where r.RequestId = " & RequestID & " And ReviewId = " & ReviewId & ""

                olstReqDocBindItem = oReqDocBindItem.LoadLst(strQuery)

                'added 3.28.2018
                'put function for populate grid from cReqItems
                If PopulateGridFromDB() <> True Then
                    MsgBox("Grid Is Not filled properly.")
                End If

            End If

            Call DisplayComments()

            Call GridLine_Color()

            LoadVariable = False
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmVirtual_Request_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Try
            Dim panInstrWidth = panSpecInst1.Width.ToString


            If Me.WindowState = FormWindowState.Minimized Then

                'panSpecInst1.Width = 663
                'panCommentsGraph.Width = 663

                Call execResize()

                '   MsgBox("The form has been maximized. Width : " & panInstrWidth)
                'txtSpecInstrWrite.Text = "panSpecInstr1.width = " & panSpecInst1.Width.ToString & vbCrLf _
                '    & " , panCommentsGraph.width = " & panCommentsGraph.Width.ToString

                '  MsgBox("The form has been minimized.")

            ElseIf Me.WindowState = FormWindowState.Maximized Then

                'panSpecInst1.Width = Me.Width / 2 - 7                '813
                'panCommentsGraph.Width = Me.Width / 2 - 7


                Call execResize()

                '  MsgBox("The form has been maximized. Width : " & panSpecInst1.Width.ToString)
                'txtSpecInstrWrite.Text = "panSpecInstr1.width = " & panSpecInst1.Width.ToString & vbCrLf _
                '   & " , panCommentsGraph.width = " & panCommentsGraph.Width.ToString

            End If

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmVirtual_Request_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Try

            Dim strWidth As String = ""
            If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.X >= (Me.Size.Width - 20) AndAlso e.Y >= (Me.Size.Height - 20) Then
                Dim XOffset, YOffset As Integer
                XOffset = e.X - (Me.Size.Width)
                YOffset = e.Y - (Me.Size.Height)
                Me.Size = New Size(Me.Size.Width + XOffset, Me.Size.Height + YOffset)

                'strWidth = "panSpecInstr1.width = " & panSpecInst1.Width.ToString & vbCrLf _
                '    & " , panCommentsGraph.width = " & panCommentsGraph.Width.ToString _
                '    & " , form width = " & Me.Width.ToString



                Call execResize()

                '   MsgBox(strWidth)
            End If

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#Region "Function for return param for resize"

    Private Function fReturnWH(ByVal paramType As Char) As Int32
        fReturnWH = 0
        Try
            Dim intvalue As Int32 = 0

            Select Case paramType
                Case "W" 'width

                    intvalue = 663
                    If Me.Width > 1343 Then
                        intvalue += ((Me.Width - 1343) / 2 - 7) ' + 663

                        '1343 is min width
                        '2 divide for two side
                        '7 is deviation 
                        '663 is standard width for panel comment
                    End If
                Case "H" 'height
                    intvalue = 106
                    If Me.Height > 850 Then
                        intvalue += ((Me.Height - 913) / 2 - 7)
                    End If
            End Select

            Return intvalue

        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub execResize()
        Try
            panSpecInst1.Width = fReturnWH("W")
            panCommentsGraph.Width = fReturnWH("W")

            If panCommentsGraph.Height < 324 Then
                panCommentsGraph.Height = 324 'fReturnWH("H") * 2
                panSpecInst1.Height = 324
            End If

            txtSpecInstrReceive.Height = fReturnWH("H")
            txtSpecInstrWrite.Height = fReturnWH("H")

            txtRecCommGraph.Height = fReturnWH("H")
            txtSendCommFromGraph.Height = fReturnWH("H")
        Catch ex As Exception
            MsgBox("Error In " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region "resize with mouse"

    Public IsDragging As Boolean = False, IsClick As Boolean = False
    Public StartPoint, FirstPoint, LastPoint As Point
    Private Sub panTopMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panTopMain.Click, panTopButtonBar.Click, StatusStrip1.Click, panCommentsGraph.Click,
        grBoxItemList.Click, pan3AddFree.Click, Me.Click, grpCustomerInfo.Click, lstViewCustomerMiddle.Click, grpCustomerInfo.Click
        '   If IsClick = True Then MsgBox("CLick")

        ' txtSpecInstrWrite.Text = "Form width : " & Me.Width.ToString & vbCrLf & " Form Height : " & Me.Height.ToString

        Call execResize()

    End Sub



    Private Sub panTopMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panTopMain.MouseDown, panTopButtonBar.MouseDown, StatusStrip1.MouseDown,
        panCommentsGraph.MouseDown, grBoxItemList.MouseDown, pan3AddFree.MouseDown, Me.MouseDown, grpCustomerInfo.MouseDown, grpAdditDetail.MouseDown, grpCustomerInfo.MouseDown
        StartPoint = Me.PointToScreen(New Point(e.X, e.Y))
        FirstPoint = StartPoint
        IsDragging = True

        ' txtSpecInstrWrite.Text = "Form width : " & Me.Width.ToString & vbCrLf & " Form Height : " & Me.Height.ToString

        Call execResize()

    End Sub

    Private Sub panTopMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panTopMain.MouseMove, panTopButtonBar.MouseMove, StatusStrip1.MouseMove,
        panCommentsGraph.MouseMove, grBoxItemList.MouseMove, pan3AddFree.MouseMove, Me.MouseMove, lstViewCustomerMiddle.MouseMove, lstViewCustomerMiddle.MouseMove, grpCustomerInfo.MouseMove
        If IsDragging Then
            Dim EndPoint As Point = Me.PointToScreen(New Point(e.X, e.Y))
            IsClick = False
            Me.Left += (EndPoint.X - StartPoint.X)
            Me.Top += (EndPoint.Y - StartPoint.Y)
            StartPoint = EndPoint
            LastPoint = EndPoint
        End If

        'txtSpecInstrWrite.Text = "Form width : " & Me.Width.ToString & vbCrLf & " Form Height : " & Me.Height.ToString

        Call execResize()

    End Sub

    Private Sub panTopMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panTopMain.MouseUp, panTopButtonBar.MouseUp, StatusStrip1.MouseUp,
         panCommentsGraph.MouseUp, grBoxItemList.MouseUp, pan3AddFree.MouseUp, Me.MouseUp, grpCustomerInfo.MouseUp, grpAdditDetail.MouseUp, grpCustomerInfo.MouseUp
        IsDragging = False
        If LastPoint = StartPoint Then IsClick = True Else IsClick = False

        ' txtSpecInstrWrite.Text = "Form width : " & Me.Width.ToString & vbCrLf & " Form Height : " & Me.Height.ToString

        Call execResize()
    End Sub



#End Region
#Region "Texbox Dragging"
    'Private txt As Panel 'TextBox
    'Private txtptX, txtptY As Integer
    'Private Sub txt_MouseLeave(sender As Object, e As EventArgs)
    '    Me.Cursor = Cursors.Arrow
    'End Sub
    'Dim MoveMode As Boolean
    'Dim DragMode As Boolean = True
    'Private Sub txt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If DragMode = True Then
    '        MoveMode = True
    '        If e.Button = MouseButtons.Left Then
    '            txt = CType(sender, panSpecInst1) 'CType(sender, TextBox)
    '            txtptX = e.X : txtptY = e.Y
    '            If e.X >= txt.Width - 10 Then
    '                txt.Cursor = Cursors.Cross
    '            Else
    '                txt.Cursor = Cursors.IBeam
    '            End If

    '            If e.Y >= txt.Height - 10 Then
    '                txt.Cursor = Cursors.Cross
    '            Else
    '                txt.Cursor = Cursors.IBeam
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub txt_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '    If MoveMode = True Then
    '        If txt.Cursor = Cursors.Cross Then
    '            txt.Width = e.X
    '            txt.Height = e.Y
    '        Else
    '            txt.Location = New Point(txt.Location.X + e.X - txtptX, txt.Location.Y + e.Y - txtptY)
    '            Me.Refresh()
    '        End If
    '    End If
    'End Sub

    'Private Sub txt_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    txt = CType(sender, panSpecInst1)  ' CType(sender, TextBox)
    '    If txt.Cursor = Cursors.Cross Then
    '        txt.Cursor = Cursors.IBeam
    '    End If
    '    MoveMode = False
    'End Sub
#End Region

End Class

Public Class ListPopulate
    Private intId As String
    Private strValue As String

    Public Sub New(ByVal strId As String, ByVal strValue As String)
        Me.intId = strId
        Me.strValue = strValue
    End Sub 'NewNew

    Public ReadOnly Property Value() As String
        Get
            Return strValue
        End Get
    End Property

    Public ReadOnly Property ID() As String
        Get
            Return intId
        End Get
    End Property

End Class 'USState

Public Class ListResize
    Private intId As String
    Private strValue As String

    Public Sub New(ByVal strId As String, ByVal strValue As String)
        Me.intId = strId
        Me.strValue = strValue
    End Sub 'NewNew

    Public Property Value() As String
        Get
            Return strValue
        End Get
        Set(value As String)
            strValue = value
        End Set
    End Property
    Public Property ID() As String
        Get
            Return intId
        End Get
        Set(value As String)
            intId = value
        End Set
    End Property






End Class 'USState

