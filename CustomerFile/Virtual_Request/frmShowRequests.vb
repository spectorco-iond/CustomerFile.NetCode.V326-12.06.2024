
Imports System.Globalization

Public Class frmShowRequests
    Private ucShowReq As ucShowRequests
    Private strQuery As String = " Where "
    Public Sub New()

        '   frmShow = Me
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim iData As IDataObject = Clipboard.GetDataObject

        '  MsgBox(CType(iData.GetData(DataFormats.Text), String) & " New()")

        'ucShowReq = New ucShowRequests()
        'With ucShowReq
        '    .Dock = DockStyle.Fill
        'End With


        'panMiddle.Controls.Add(ucShowReq)
        Call LstCreateView()

    End Sub

    Public Sub New(ByVal reqId As String)



        ' This call is required by the designer.
        InitializeComponent()

        ' frmShow = Me
        ' Add any initialization after the InitializeComponent() call.
        xTxtRequestCode.Text = reqId

        'ucShowReq = New ucShowRequests()
        'With ucShowReq
        '    .Dock = DockStyle.Fill
        'End With

        'panMiddle.Controls.Add(ucShowReq)

        Call LstCreateView(strQuery)


    End Sub
    Private Sub txtbtnNew_Click(sender As Object, e As EventArgs) Handles txtbtnNew.Click
        Try

            'call type request
            Dim strQueryType = " where Active = 0 and Item_Doc_Type_Id <> 24 "
            Call LstCreate(Trim("Type"), strQueryType)

            '       Call LstCreateView()
            '

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '--------------------------------- Create ne Request ----------------------------------------------
    Private Sub CreateNewRequest(ByVal pTypeID As Int32)
        Try

            Dim strSql As String
            oRequests = New cRequests
            oReqRevision = New cReqRevision
            oReqStatus = New cReqStatus
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            olstRequests = New List(Of cRequests)
            olstReqRevision = New List(Of cReqRevision)
            olstReqStatus = New List(Of cReqStatus)
            olstExact_Traveler_Permission = New List(Of cExact_Traveler_Permission)

            Dim p_requestid As Integer = 0
            Dim p_reviewId As Integer = 0
            Dim identGuid As String

            '-----------------
            Dim strOrigin As String = String.Empty

            Dim frmReqOrigin As New frmOrigin
            frmReqOrigin.ShowDialog()

            If frmReqOrigin.DialogResult = DialogResult.Yes Then
                strOrigin = frmReqOrigin.Requiest_Original
            Else
                MsgBox("Is mandatory to choose request origin.")
                Exit Sub
            End If
            '----------------
            Dim g As Guid
            g = Guid.NewGuid()

            identGuid = g.ToString

            With oRequests
                'normaly this value need come from choose type
                'maybe from search type
                .TypeID = pTypeID '22 'in MDB_CFG_ITEM_DOC_TYPE added - 22 Storyboard Request
                .Req_Guid = identGuid

                'Create properties are filled in the class public property
                '.CreateBy =oExact_Traveler_Permission.ID  ' take employee_id
                '.CreateByFullName = oExact_Traveler_Permission.Fullname
                '.CreateDate = DateNow()

                '.ModifyBy =oExact_Traveler_Permission.ID
                '.ModifyByFullName = oExact_Traveler_Permission.Fullname
                '.ModifyDate = DateNow()

                .ViewDate = DateNow()

            End With
            'if request id is created  next is create and add revision id + number
            If oRequests.Save() = True Then

                If oRequests.Load(identGuid) = False Then
                    MsgBox("Can't find request guid :" & identGuid & " . Added time : " & DateNow().ToString("dd-MM-yyyy HH:mm"))
                    Exit Sub
                End If

                p_requestid = oRequests.RequestID

                With oReqRevision
                    'need retrive created request id 
                    ' use guid  above -> identGuid fro find good request id
                    .RequestId = p_requestid
                    .Rev_Cpt = 0
                    .Rush_Order = False
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
                    strSql = " where RequestId = " & p_requestid & " order by reviewId desc "
                    If oReqRevision.Load(strSql) = False Then
                        MsgBox("Can't find request ID :" & p_requestid & " . Added time : " & DateNow().ToString("dd-MM-yyyy HH:mm"))
                        Exit Sub
                    End If

                    p_reviewId = oReqRevision.ReviewID

                    '---------------------Add ItemCode in request------------------------------
                    'requestId + reviewId
                    If oRequests.Load(identGuid) Then
                        oRequests.ItemCode = oRequests.TypeID & "." & p_requestid
                        oRequests.Save()

                        oReqRevision.RevItemCd = Trim(oRequests.TypeID.ToString & "." & p_requestid.ToString & "." & p_reviewId.ToString & "." & oReqRevision.Rev_Cpt.ToString)
                        oReqRevision.Save()


                    End If
                    '---------------------------------------------------

                    With oReqStatus
                        'always when is new take this satatus
                        .RequestId = p_requestid
                        .ReviewId = p_reviewId
                        .StatusId = CInt(ReqCFGStatus.Pending)   ' is open -> id=0 from [100].[dbo].[ReqCFGStatus]
                        .Active = 1

                        'Create properties are filled in the class public property
                        '.CreateBy =oExact_Traveler_Permission.ID  ' take employee_id
                        '.CreateByFullName = oExact_Traveler_Permission.Fullname
                        '.CreateDate = DateNow()

                    End With

                    If oReqStatus.Save = True Then

                        panViewMain.Visible = False
                        '      Call LstCreateView(strQuery)
                        Dim frmStoryBoard As New frmVirtual_Request(p_requestid, p_reviewId)
                        frmStoryBoard.ShowDialog()

                        ' frmStoryBoard.Show() 'Dialog()
                        frmStoryBoard = Nothing


                        '6.12.2018strQuery is global variable for this page
                        '  ucShowReq.LstCreate(strQuery)


                    End If

                End If ' oReqRevision.Save() 
            End If 'oRequests.Save()

            ' frmStoryBoard.Dispose()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '-------------------------------------------------------------------------------

    '---------------- move top panel --------------
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Private Sub panMainTop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMainTop.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub
    Private Sub panMainTop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMainTop.MouseMove
        If allowCoolMove = True Then
            panMainTop.Location = New Point(panMainTop.Location.X + e.X - myCoolPoint.X, panMainTop.Location.Y + e.Y - myCoolPoint.Y)
            'this line move panel 
            panViewMain.Location = New Point(panViewMain.Location.X + e.X - myCoolPoint.X, panViewMain.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub panMainTop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panMainTop.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub
    '---------------------------------------------
    '---------------- move middle panel --------------
    Private Sub lstViewShowReq_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewShowReq.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub
    Private Sub lstViewShowReq_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewShowReq.MouseMove
        If allowCoolMove = True Then
            lstViewShowReq.Location = New Point(lstViewShowReq.Location.X + e.X - myCoolPoint.X, lstViewShowReq.Location.Y + e.Y - myCoolPoint.Y)
            'this line move panel 
            panViewMain.Location = New Point(panViewMain.Location.X + e.X - myCoolPoint.X, panViewMain.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub
    Private Sub lstViewShowReq_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstViewShowReq.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub xTxtStatus_DoubleClick(sender As Object, e As EventArgs) Handles xTxtStatus.DoubleClick
        Try
            Try
                '  If Trim(xTxtStatus.Text) = "" Then Exit Sub

                panViewMain.Visible = True
                lblSearch.Text = lblStatus.Text

                Call LstCreate(lblStatus.Text)


            Catch ex As Exception
                MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtCreator_DoubleClick(sender As Object, e As EventArgs) Handles xTxtCreator.DoubleClick
        Try
            ' If Trim(xTxtCreator.Text) = "" Then Exit Sub

            panViewMain.Visible = True
            lblSearch.Text = lblCreator.Text

            Call LstCreate(lblCreator.Text)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '--------------------------------- List View -------------------------------
    Private Sub LstCreate(ByVal column As String, Optional ByVal strQuery As String = "")
        Try
            If Trim(column = "") Then Exit Sub

            Dim oReqView As New cRequest_View
            Dim olsReqView As New List(Of cRequest_View)
            Dim oMdb_Cfg_Item_Doc_Type As cMdb_Cfg_Item_Doc_Type = New cMdb_Cfg_Item_Doc_Type
            Dim olstMdb_Cfg_Item_Doc_Type As List(Of cMdb_Cfg_Item_Doc_Type) = New List(Of cMdb_Cfg_Item_Doc_Type)

            Dim distinctVar As IEnumerable(Of String) = Nothing

            Select Case column
                Case "Request Code"
                    column = "RevItemCd"
                    olsReqView = oReqView.LoadLst(strQuery)
                    distinctVar = olsReqView.Select(Function(i As cRequest_View) i.RevItemCd).Distinct

                    lblSearch.Text = "Request Code"
                Case "Status"
                    olsReqView = oReqView.LoadLst(strQuery)
                    distinctVar = olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct
                Case "Creator"
                    olsReqView = oReqView.LoadLst(strQuery)
                    distinctVar = olsReqView.Select(Function(i As cRequest_View) i.Creator).Distinct
                    'olsReqView.FindAll(Function(i As cRequest_View) i.Creator).Distinct
                Case "Account"
                    olsReqView = oReqView.LoadLst(strQuery)
                    lblSearch.Text = lblAccount.Text
                    distinctVar = olsReqView.Select(Function(i As cRequest_View) i.Account).Distinct
                    'olsReqView.FindAll(Function(i As cRequest_View) i.Account).Distinct
                Case "Type"
                    lblSearch.Text = column
                    olstMdb_Cfg_Item_Doc_Type = oMdb_Cfg_Item_Doc_Type.Load(strQuery)
            End Select

            '    olsReqView.FindAll(Function(i As cRequest_View) i.Status).Distinct

            '---------------- fill listbox with probabily customers ------------------
            If lstViewShowReq.Items.Count = 0 Then

            Else

                lstViewShowReq.Items.Clear()

            End If

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()


            If column <> "Type" Then

                With lstViewShowReq
                    .View = View.Details
                    .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                    .HoverSelection = True
                    .Columns.Clear() ' make sure collumnscollection is empty
                    ' Add 3 columns
                    .Columns.AddRange(New ColumnHeader() {listColumns(column, column, HorizontalAlignment.Left, 200)})

                    .FullRowSelect = True
                    .GridLines = True
                    .Height = 10
                    .Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)
                End With

                For Each oStrVar As String In distinctVar 'olsReqView.Select(Function(i As cRequest_View) i.Status).Distinct 'olsReqView
                    ReDim Preserve item(UBound(item) + 1)
                    item(UBound(item)) = New ListViewItem

                    Select Case column
                        Case "RevItemCd"
                            item(UBound(item)).Text = Trim(oStrVar).ToString
                        Case "Status"
                            item(UBound(item)).Text = Trim(oStrVar).ToString
                        Case "Creator"
                            item(UBound(item)).Text = Trim(oStrVar).ToString
                        Case "Account"
                            item(UBound(item)).Text = Trim(oStrVar).ToString
                    End Select

                    Items.Add(item(UBound(item)))
                Next
            Else
                'show cMdb_Cfg_Item_Doc_Type



                With lstViewShowReq
                    .View = View.Details
                    .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                    .HoverSelection = True
                    .Columns.Clear() ' make sure collumnscollection is empty
                    ' Add 2 columns
                    .Columns.AddRange(New ColumnHeader() {listColumns(CFG_ITEM_DOC_TYPE.ITEM_DOC_TYPE_ID.ToString, "Type Id", HorizontalAlignment.Left, 50),
                                                          listColumns(CFG_ITEM_DOC_TYPE.DOC_TYPE.ToString, "Request Type", HorizontalAlignment.Left, 150)})

                    .FullRowSelect = True
                    .GridLines = True
                    .Height = 10
                    .Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)

                End With

                For Each oType As cMdb_Cfg_Item_Doc_Type In olstMdb_Cfg_Item_Doc_Type
                    ReDim Preserve item(UBound(item) + 1)
                    item(UBound(item)) = New ListViewItem

                    item(UBound(item)).Text = Trim(oType.Item_Doc_Type_Id).ToString

                    item(UBound(item)).SubItems.Add(Trim(oType.Doc_Type).ToString)

                    Items.Add(item(UBound(item)))
                Next

            End If
            lstViewShowReq.BeginUpdate()
            lstViewShowReq.Items.AddRange(Items.ToArray)
            lstViewShowReq.EndUpdate()
            lstViewShowReq.Visible = True
            lstViewShowReq.Focus()

            panViewMain.Visible = True

            Call ListView_RowsColor(lstViewShowReq)
            lblRows.Text = "Rows : " & lstViewShowReq.Items.Count

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstViewShowReq_DoubleClick(sender As Object, e As EventArgs) Handles lstViewShowReq.DoubleClick
        Try
            Dim typeId As Int32 = 0
            Dim typeDesc As String = ""


            '   If strQuery.Length = 0 Then strQuery = " where "


            Select Case Trim(lblSearch.Text)
                Case "Request Code"
                    xTxtRequestCode.Text = lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text

                    'If strQuery.Length > 7 Then strQuery &= " And "
                    'strQuery &= " RevItemCd like '%" & lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text & "%'"
                    'ucShowReq.LstCreate(strQuery)

                Case "Status"
                    xTxtStatus.Text = lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text

                    'in the TextChanged function for display in listview
                    'If strQuery.Length > 7 Then strQuery &= " And "
                    'strQuery &= " Status = '" & lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text & "'"

                    'ucShowReq.LstCreate(strQuery)

                Case "Creator"
                    xTxtCreator.Text = lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text

                    'If strQuery.Length > 7 Then strQuery &= " And "
                    'strQuery &= " Creator = '" & lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text & "'"

                  '  ucShowReq.LstCreate(strQuery)

                Case "Account"
                    xTxtAccount.Text = lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text

                    'If strQuery.Length > 7 Then strQuery &= " And "
                    'strQuery &= " Account like '%" & lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text & "%'"

                    'ucShowReq.LstCreate(strQuery)
                Case "Type"
                    typeId = CInt(lstViewShowReq.SelectedItems.Item(0).SubItems(0).Text)
                    typeDesc = lstViewShowReq.SelectedItems.Item(0).SubItems(1).Text



                    '-------------------------------------------------------------------------

                    'Dim result As DialogResult

                    'result = MessageBox.Show("You want create new " & typeDesc, "New " & typeDesc & " will be created.",
                    '                         MessageBoxButtons.YesNoCancel)

                    'If result = DialogResult.Cancel Then
                    '    'nothing to do
                    'ElseIf result = DialogResult.No Then
                    '    'nothing to do
                    'ElseIf result = DialogResult.Yes Then
                    'need create new request

                    Call CreateNewRequest(typeId)

                    '  End If
                    '  panViewMain.Visible = False
            End Select

            '  Me.Close()
            'panViewMain.Visible = False
            lstViewShowReq.Items.Clear()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblClosePanView_MouseClick(sender As Object, e As MouseEventArgs) Handles lblClosePanView.MouseClick
        Try
            panViewMain.Visible = False
            lstViewShowReq.Items.Clear()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtStatus_TextChanged(sender As Object, e As EventArgs) Handles xTxtStatus.TextChanged
        Try
            Call filter_xTxt(sender)
            Exit Sub

            Dim xTxt As xTextBox = sender

            strQuery = " Where "

            If xTxt.Text = "" Then

                If Trim(xTxtCreator.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Creator like  '%" & Trim(xTxtCreator.Text) & "%'"
                End If

                If Trim(xTxtAccount.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                End If

                If Trim(xTxtRequestCode.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " RevItemCd like '%" & Trim(xTxtRequestCode.Text) & "%'"
                End If

                If strQuery.Length < 8 Then strQuery = ""

                'ucShowReq.LstCreate(strQuery)
                Call LstCreateView(strQuery)

                xTxt.Focus()
                xTxt.Select(50, 100)
            Else
                If Trim(xTxt.Text).Length > 1 Then
                    lstViewShowReq.Items.Clear()
                    panViewMain.Visible = False
                    lblSearch.Text = ""

                    If Trim(xTxtCreator.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Creator like '%" & Trim(xTxtCreator.Text) & "%'"
                    End If

                    If Trim(xTxtAccount.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                    End If

                    If Trim(xTxtRequestCode.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " RevItemCd like'%" & Trim(xTxtRequestCode.Text) & "%'"
                    End If

                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Status like '%" & Trim(xTxt.Text) & "%'"

                    'Call ucShowReq.LstCreate(strQuery)
                    Call LstCreateView(strQuery)

                    xTxt.Focus()
                    xTxt.Select(50, 100)
                End If
            End If

            strQuery = ""
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtCreator_TextChanged(sender As Object, e As EventArgs) Handles xTxtCreator.TextChanged
        Try

            Call filter_xTxt(sender)
            Exit Sub

            Dim xTxt As xTextBox = sender
            strQuery = " Where "

            If xTxt.Text = "" Then

                If Trim(xTxtStatus.Text) <> "" Then

                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Status like  '%" & Trim(xTxtStatus.Text) & "%'"
                End If

                If Trim(xTxtAccount.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                End If

                If Trim(xTxtRequestCode.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " RevItemCd like '%" & Trim(xTxtRequestCode.Text) & "%'"
                End If

                If strQuery.Length < 8 Then strQuery = ""

                '  ucShowReq.LstCreate(strQuery)
                Call LstCreateView(strQuery)

                xTxt.Focus()
                xTxt.Select(50, 100)
            Else
                If Trim(xTxt.Text).Length > 1 Then
                    lstViewShowReq.Items.Clear()
                    panViewMain.Visible = False
                    lblSearch.Text = ""

                    If Trim(xTxtStatus.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Status like'%" & Trim(xTxtStatus.Text) & "%'"
                    End If

                    If Trim(xTxtAccount.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                    End If

                    If Trim(xTxtRequestCode.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " RevItemCd like '%" & Trim(xTxtRequestCode.Text) & "%'"
                    End If

                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Creator like '%" & Trim(xTxt.Text) & "%'"

                    'Call ucShowReq.LstCreate(strQuery)
                    Call LstCreateView(strQuery)
                    ' Call LstCreate(Trim(lblAccount.Text), strQuery)
                    xTxt.Focus()
                    xTxt.Select(50, 100)
                End If
            End If

            strQuery = ""
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtAccount_TextChanged(sender As Object, e As EventArgs) Handles xTxtAccount.TextChanged
        Try


            filter_xTxt(sender)
            Exit Sub

            Dim xTxt As xTextBox = sender
            strQuery = " Where "
            'if is deleted sentence
            If xTxt.Text = "" Then
                lstViewShowReq.Items.Clear()
                panViewMain.Visible = False
                lblSearch.Text = ""

                If Trim(xTxtStatus.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Status like '%" & Trim(xTxtStatus.Text) & "%'"
                End If

                If Trim(xTxtCreator.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Creator like '%" & Trim(xTxtCreator.Text) & "%'"
                End If

                If Trim(xTxtRequestCode.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " RevItemCd like '%" & Trim(xTxtRequestCode.Text) & "%'"
                End If

                If strQuery.Length < 8 Then strQuery = ""

                ' ucShowReq.LstCreate(strQuery)

                Call LstCreateView(strQuery)

                xTxt.Focus()
                xTxt.Select(50, 100)
            Else
                If Trim(xTxt.Text).Length > 1 Then
                    lstViewShowReq.Items.Clear()
                    panViewMain.Visible = False
                    lblSearch.Text = ""

                    If Trim(xTxtStatus.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Status like '%" & Trim(xTxtStatus.Text) & "%'"
                    End If

                    If Trim(xTxtCreator.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Creator like '%" & Trim(xTxtCreator.Text) & "%'"
                    End If

                    If Trim(xTxtRequestCode.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " RevItemCd like '%" & Trim(xTxtRequestCode.Text) & "%'"
                    End If

                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Account like '%" & Trim(xTxt.Text) & "%'"

                    '  Call ucShowReq.LstCreate(strQuery)

                    Call LstCreateView(strQuery)

                    xTxt.Focus()
                    xTxt.Select(50, 100)
                End If
            End If

            strQuery = ""

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub xTxtRequestCode_TextChanged(sender As Object, e As EventArgs) Handles xTxtRequestCode.TextChanged
        Try

            filter_xTxt(sender)
            Exit Sub

            Dim xTxt As xTextBox = sender

            strQuery = " Where "

            If xTxt.Text = "" Then
                lstViewShowReq.Items.Clear()
                panViewMain.Visible = False
                lblSearch.Text = ""

                If Trim(xTxtStatus.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Status like '%" & Trim(xTxtStatus.Text) & "%'"
                End If

                If Trim(xTxtCreator.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Creator like '%" & Trim(xTxtCreator.Text) & "%'"
                End If

                If Trim(xTxtAccount.Text) <> "" Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                End If

                If strQuery.Length < 8 Then strQuery = ""

                '    ucShowReq.LstCreate(strQuery)
                Call LstCreateView(strQuery)

                xTxt.Focus()
                xTxt.Select(50, 100)
            Else
                If Trim(xTxt.Text).Length > 1 Then
                    lstViewShowReq.Items.Clear()
                    panViewMain.Visible = False
                    lblSearch.Text = ""

                    If Trim(xTxtStatus.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Status like '%" & Trim(xTxtStatus.Text) & "%'"
                    End If

                    If Trim(xTxtCreator.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Creator like '%" & Trim(xTxtCreator.Text) & "%'"
                    End If

                    If Trim(xTxtAccount.Text) <> "" Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " Account like '%" & Trim(xTxtAccount.Text) & "%'"
                    End If

                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " RevItemCd like '%" & Trim(xTxt.Text) & "%'"

                    '  Call ucShowReq.LstCreate(strQuery)
                    Call LstCreateView(strQuery)
                    ' Call LstCreate(Trim(lblRequestCode.Text), strQuery)
                    xTxt.Focus()
                    xTxt.Select(50, 100)
                End If
            End If

            strQuery = ""
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xTxtItemCd_TextChanged(sender As Object, e As EventArgs) Handles xTxtItemCd.TextChanged
        Try
            Call filter_xTxt(sender)
            Exit Sub
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub xTxtImprint_TextChanged(sender As Object, e As EventArgs) Handles xTxtImprint.TextChanged
        Try
            Call filter_xTxt(sender)
            Exit Sub
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub xChkRush_CheckStateChanged(sender As Object, e As EventArgs) Handles xChkRush.CheckStateChanged
        Try
            Call filter_xTxt(sender)
            Exit Sub
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'function for load dinamique properties from xTxt
    '-------------------------------------------------
    Private Function transCheck(sender As Object) As String
        transCheck = ""
        Try

            Dim sstr As String = ""
            Dim _obj = sender

            If _obj.GetType.Name = "xCheckBox" Then

                If _obj.checkstate = CheckState.Checked Then
                    sstr = "YES"
                End If
            ElseIf _obj.GetType.Name = "xTextBox" Then
                sstr = _obj.text
            End If

            Return sstr

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub filter_xTxt(sender As Object)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim xTxt = sender
            strQuery = " Where "
            'if is deleted sentence

            'Return ValueType from sender and type of sender
            Dim x = transCheck(sender)

            If x = "" Then
                lstViewShowReq.Items.Clear()
                panViewMain.Visible = False
                lblSearch.Text = ""

                If Trim(xTxtStatus.Text) <> "" And xTxt.Name <> xTxtStatus.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtStatus.StringValue & " like '%" & Trim(xTxtStatus.Text) & "%'"
                End If

                If Trim(xTxtCreator.Text) <> "" And xTxt.Name <> xTxtCreator.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtCreator.StringValue & " like '%" & Trim(xTxtCreator.Text) & "%'"
                End If

                If Trim(xTxtRequestCode.Text) <> "" And xTxt.Name <> xTxtRequestCode.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtRequestCode.StringValue & " like '%" & Trim(xTxtRequestCode.Text) & "%'"
                End If

                If Trim(xTxtAccount.Text) <> "" And xTxt.Name <> xTxtAccount.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtAccount.StringValue & " like '%" & Trim(xTxtAccount.Text) & "%'"
                End If

                If Trim(xTxtItemCd.Text) <> "" And xTxt.Name <> xTxtItemCd.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtItemCd.StringValue & " like '%" & Trim(xTxtItemCd.Text) & "%'"
                End If

                If Trim(xTxtImprint.Text) <> "" And xTxt.Name <> xTxtImprint.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xTxtImprint.StringValue & " Like '%" & Trim(xTxtImprint.Text) & "%'"
                End If

                If xChkRush.CheckState = CheckState.Checked And xTxt.Name <> xChkRush.Name Then
                    If strQuery.Length > 8 Then strQuery &= " And "
                    strQuery &= " " & xChkRush.StringValue & " = " & xChkRush.CheckState & ""
                End If

                If strQuery.Length < 8 Then strQuery = ""

                ' ucShowReq.LstCreate(strQuery)

                '++ID 3.05.2019 put in comments
                If chkSearchActivate.CheckState = CheckState.Checked Then
                    Call LstCreateView(strQuery)
                End If

                If xTxt.GetType.Name <> "xCheckBox" Then
                    xTxt.Focus()
                    xTxt.Select(50, 100)
                End If
            Else
                If Trim(x).Length > 1 Then
                    lstViewShowReq.Items.Clear()
                    panViewMain.Visible = False
                    lblSearch.Text = ""

                    If Trim(xTxtStatus.Text) <> "" And xTxt.Name <> xTxtStatus.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtStatus.StringValue & " Like '%" & Trim(xTxtStatus.Text) & "%'"
                    End If

                    If Trim(xTxtCreator.Text) <> "" And xTxt.Name <> xTxtCreator.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtCreator.StringValue & " like '%" & Trim(xTxtCreator.Text) & "%'"
                    End If

                    If Trim(xTxtRequestCode.Text) <> "" And xTxt.Name <> xTxtRequestCode.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtRequestCode.StringValue & " like '%" & Trim(xTxtRequestCode.Text) & "%'"
                    End If

                    If Trim(xTxtAccount.Text) <> "" And xTxt.Name <> xTxtAccount.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtAccount.StringValue & " like '%" & Trim(xTxtAccount.Text) & "%'"
                    End If

                    If Trim(xTxtItemCd.Text) <> "" And xTxt.Name <> xTxtItemCd.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtItemCd.StringValue & " like '%" & Trim(xTxtItemCd.Text) & "%'"
                    End If

                    If Trim(xTxtImprint.Text) <> "" And xTxt.Name <> xTxtImprint.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xTxtImprint.StringValue & " Like '%" & Trim(xTxtImprint.Text) & "%'"
                    End If

                    If xChkRush.CheckState = CheckState.Checked And xTxt.Name <> xChkRush.Name Then
                        If strQuery.Length > 8 Then strQuery &= " And "
                        strQuery &= " " & xChkRush.StringValue & " = " & xChkRush.CheckState & " "
                    End If

                    If strQuery.Length > 8 Then strQuery &= " And "
                    'need validate textbox or checkbox for to know 

                    If x <> "YES" Then
                        strQuery &= " " & xTxt.StringValue & " like '%" & Trim(xTxt.Text) & "%'"
                    Else
                        strQuery &= " " & xTxt.StringValue & " = " & xTxt.checkstate & ""
                    End If

                    '  Call ucShowReq.LstCreate(strQuery)
                    '++ID 3.05.2019 put in comments
                    If chkSearchActivate.CheckState = CheckState.Checked Then
                        Call LstCreateView(strQuery)
                    End If

                    If xTxt.GetType.Name <> "xCheckBox" Then
                        xTxt.Focus()
                        xTxt.Select(50, 100)
                    End If

                End If
            End If

            strQuery = ""

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '---------------------------------------------------
    Private Sub txtbtnClose_Click(sender As Object, e As EventArgs) Handles txtbtnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmShowRequests_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Try

            If e.KeyCode = Keys.Escape Then
                If panViewMain.Visible = True Then
                    panViewMain.Visible = False
                End If
            ElseIf e.KeyCode = Keys.Enter And btnSearch.Enabled = True Then
                btnSearch.PerformClick()
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmShowRequests_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            Dim iData As IDataObject = Clipboard.GetDataObject

            '    MsgBox(CType(iData.GetData(DataFormats.Text), String) & ". Shown")



            tsLblVersion.Text = Version()


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    '---------------------------------------------------------------------------
    'from ucShowRequest
    Private ObjListView As New ListView
    Private varCpt As Int32 = 0 'use in LstCreate because need create listview object only on time but each time when i call i don't nee crete object , only reuse.
    Private variableSql As String = ""


    Public Sub LstCreateView(Optional strQuery As String = "")
        Try

            variableSql = strQuery


            If Trim(variableSql).Length = 5 Then
                strQuery = ""
            End If

            Dim oReqView As New cRequest_View
            Dim olsReqView As New List(Of cRequest_View)

            '---------------- fill listbox with probabily customers ------------------
            '  If ObjListView.Items.Count = 0 Then
            If varCpt = 0 Then
                varCpt += 1
                ObjListView = New ListView
                With ObjListView
                    .Dock = DockStyle.Fill
                End With

                panShowRequest.Controls.Add(ObjListView)

                RemoveHandler ObjListView.DoubleClick, New EventHandler(AddressOf lstView_DoubleClick)

                'Add the event handler.
                AddHandler ObjListView.DoubleClick, New EventHandler(AddressOf lstView_DoubleClick)




                RemoveHandler ObjListView.ColumnClick, AddressOf lstView_ColumnClick

                AddHandler ObjListView.ColumnClick, AddressOf lstView_ColumnClick
                'ColumnClickEventArgs
                '  panMiddleLstViewCustomerShow.Visible = True
                '  ObjListView.Items.Clear()
            Else
                ObjListView.Items.Clear()

            End If

            Dim Items As New List(Of ListViewItem)
            Dim item(-1) As ListViewItem

            Dim clHeader As New ColumnHeader()


            olsReqView = oReqView.LoadLst(strQuery)

            With ObjListView
                .View = View.Details
                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
                .HoverSelection = True
                .Columns.Clear() ' make sure collumnscollection is empty
                ' Add 3 columns
                .Columns.AddRange(New ColumnHeader() {listColumns(Request_View.RevItemCd.ToString, Request_View.RevItemCd.ToString, HorizontalAlignment.Left, 100),
                                                          listColumns(Request_View.Rush_Order.ToString, Request_View.Rush_Order.ToString, HorizontalAlignment.Left, 50),
                                                          listColumns(Request_View.Created.ToString, Request_View.Created.ToString, HorizontalAlignment.Left, 100),
                                                          listColumns(Request_View.Creator.ToString, Request_View.Creator.ToString, HorizontalAlignment.Left, 100),
                                                          listColumns(Request_View.Description.ToString, Request_View.Description.ToString, HorizontalAlignment.Left, 100),
                                                          listColumns(Request_View.Status.ToString, Request_View.Status.ToString, HorizontalAlignment.Left, 70),
                                                          listColumns(Request_View.Person.ToString, Request_View.Person.ToString, HorizontalAlignment.Left, 100),
                                                          listColumns(Request_View.Account.ToString, Request_View.Account.ToString, HorizontalAlignment.Left, 250),
                                                          listColumns(Request_View.Items_CD.ToString, Request_View.Items_CD.ToString, HorizontalAlignment.Left, 150),
                                                          listColumns(Request_View.Imprint_Logos.ToString, Request_View.Imprint_Logos.ToString, HorizontalAlignment.Left, 150),
                                                          listColumns(Request_View.RequestId.ToString, Request_View.RequestId.ToString, HorizontalAlignment.Left, 0),
                                                          listColumns(Request_View.ReviewId.ToString, Request_View.ReviewId.ToString, HorizontalAlignment.Left, 0),
                                                          listColumns(Request_View.ReviewNo.ToString, Request_View.ReviewNo.ToString, HorizontalAlignment.Left, 0)
                })
                .FullRowSelect = True
                .GridLines = True
                .Height = 10
                .Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)

            End With

            'For Each oCust As cCicmpy In olsCicmpy
            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
            'Next
            Dim rowIndex As Int32 = 0

            prgBar.Visible = True
            ' lab1.Visible = True


            'lab1.Text = ""
            prgBar.Minimum = 0
            prgBar.Maximum = olsReqView.Count

            ' lab1.Text = ""

            For Each oReqV As cRequest_View In olsReqView
                ReDim Preserve item(UBound(item) + 1)
                item(UBound(item)) = New ListViewItem

                rowIndex += 1
                prgBar.Value = rowIndex

                'lab1.Text = Decimal.Round((100 / prgBar.Maximum) * rowIndex ) & " % load."

                item(UBound(item)).Text = Trim(oReqV.RevItemCd).ToString

                item(UBound(item)).SubItems.Add(Trim(oReqV.Rush_Order).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.Created.ToString)) '.ToString("dd-MM-yyyy")
                item(UBound(item)).SubItems.Add(Trim(oReqV.Creator).ToString)

                item(UBound(item)).SubItems.Add(Trim(oReqV.Description).ToString)

                item(UBound(item)).SubItems.Add(Trim(oReqV.Status).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.Person).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.Account).ToString)

                '--------------------------------------------------------------
                item(UBound(item)).SubItems.Add(Trim(oReqV.Items_No).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.Imprint_Logos).ToString)
                '--------------------------------------------------------------

                item(UBound(item)).SubItems.Add(Trim(oReqV.RequestId).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.ReviewId).ToString)
                item(UBound(item)).SubItems.Add(Trim(oReqV.ReviewNo).ToString)

                Items.Add(item(UBound(item)))

                prgBar.PerformStep()
            Next




            ObjListView.BeginUpdate()
            ObjListView.Items.AddRange(Items.ToArray)
            ObjListView.EndUpdate()
            ObjListView.Visible = True
            ObjListView.Focus()

            'lblMiddleLineNameDisplay.Text = cust_show.Customer.ToString
            'lblMiddleLineNameDisplay.Tag = cust_show.Customer
            'lblMiddleLineFound.Text = Items.Count & " rows"
            prgBar.Visible = False
            ' lab1.Visible = False
            Call ListView_RowsColor(ObjListView)



        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lstView_DoubleClick(sender As Object, e As EventArgs)
        Try
            '   Debug.Print(objListView.SelectedItems(0).SubItems(1).Text)
            Dim lstRequestView As New ListView

            lstRequestView = sender


            'Dim frmCust As New frmCustomer ' = FindForm()
            'If Not IsNothing(frmCust) Then
            '    frmStoryBoard.Show()
            'Else
            '    frmStoryBoard.ShowDialog()
            'End If
            '  Dim f As frmShowRequests = FindForm()

            '    If varIdentIfCustFormIsOpen = True Then

            Me.Hide()

            Dim frmStoryBoard As New frmVirtual_Request(CInt(lstRequestView.SelectedItems.Item(0).SubItems(Request_View.RequestId).Text), lstRequestView.SelectedItems.Item(0).SubItems(Request_View.ReviewId).Text)


            frmStoryBoard.ShowDialog()

            Me.Show()
            '   Else
            '   Me.Hide()
            '  Dim frmStoryBoard As New frmVirtual_Request(CInt(lstRequestView.SelectedItems.Item(0).SubItems(Request_View.RequestId).Text), lstRequestView.SelectedItems.Item(0).SubItems(Request_View.ReviewId).Text)
            'frmStoryBoard.ShowDialog()
            '  End If

            ' Me.Show()
            Call LstCreateView(variableSql)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim sortColumn As Integer = -1
    Private Sub lstView_ColumnClick(sender As Object, e As ColumnClickEventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim lstRequestView As New ListView

            lstRequestView = sender

            'if current column is not the previously clicked column
            If e.Column <> sortColumn Then
                'set the sort column to the new column
                sortColumn = e.Column

                'Default to ascending sort order 
                lstRequestView.Sorting = SortOrder.Ascending
            Else
                'flip the sort order
                If lstRequestView.Sorting = SortOrder.Ascending Then
                    lstRequestView.Sorting = SortOrder.Descending
                Else
                    lstRequestView.Sorting = SortOrder.Ascending
                End If
            End If

            ' Call the sort method to manually sort.
            lstRequestView.Sort()
            ' Set the ListViewItemSorter property to a new ListViewItemComparer
            ' object.
            lstRequestView.ListViewItemSorter = New ListViewItemComparer(e.Column, lstRequestView.Sorting)

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            Cursor.Current = Cursors.WaitCursor
            strQuery = " Where "

            If Trim(xTxtStatus.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtStatus.StringValue & " like '%" & Trim(xTxtStatus.Text) & "%'"
            End If

            If Trim(xTxtCreator.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtCreator.StringValue & " like '%" & Trim(xTxtCreator.Text) & "%'"
            End If

            If Trim(xTxtRequestCode.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtRequestCode.StringValue & " like '%" & Trim(xTxtRequestCode.Text) & "%'"
            End If

            If Trim(xTxtAccount.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtAccount.StringValue & " like '%" & Trim(xTxtAccount.Text) & "%'"
            End If

            If Trim(xTxtItemCd.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtItemCd.StringValue & " like '%" & Trim(xTxtItemCd.Text) & "%'"
            End If

            If Trim(xTxtImprint.Text) <> "" Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xTxtImprint.StringValue & " Like '%" & Trim(xTxtImprint.Text) & "%'"
            End If

            If xChkRush.CheckState = CheckState.Checked Then
                If strQuery.Length > 8 Then strQuery &= " And "
                strQuery &= " " & xChkRush.StringValue & " = " & xChkRush.CheckState & ""
            End If

            If strQuery.Length < 8 Then strQuery = ""

            Call LstCreateView(strQuery)

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkSearchActivate_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSearchActivate.CheckStateChanged
        Try

            If chkSearchActivate.CheckState = CheckState.Unchecked Then
                btnSearch.Enabled = True
            Else
                btnSearch.Enabled = False
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub prgBar_Click(sender As Object, e As EventArgs) Handles prgBar.Click
        Try
            '  Call btnSearch_Click(sender, e)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Keypress(sender As Object, e As KeyPressEventArgs) Handles btnSearch.KeyPress
        Try
            Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
            If tmp.KeyChar = ChrW(Keys.Enter) Then
                btnSearch.PerformClick()
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSearch.KeyDown
        Try

            If e.KeyCode = Keys.Enter And btnSearch.Enabled = True Then

                btnSearch.PerformClick()

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmShowRequests_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            '  Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class

Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(column As Integer, order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer _
                        Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1

        Dim dtX As DateTime
        Dim dtY As DateTime

        Dim stStr As String = ""

        If col = 2 Then

            'dtX = Convert.ToDateTime(CType(x, ListViewItem).SubItems(col).Text)
            'dtY = Convert.ToDateTime(CType(y, ListViewItem).SubItems(col).Text)

            stStr = CType(x, ListViewItem).SubItems(col).Text

            dtX = DateTime.Parse(CType(x, ListViewItem).SubItems(col).Text)
            dtY = DateTime.Parse(CType(y, ListViewItem).SubItems(col).Text)

            returnVal = DateTime.Compare(dtX, dtY)
        Else

            returnVal = [String].Compare(CType(x,
                        ListViewItem).SubItems(col).Text,
                        CType(y, ListViewItem).SubItems(col).Text)
        End If


        ' Determine whether the sort order is descending.
        If order = SortOrder.Descending Then
            ' Invert the value returned by String.Compare.
            returnVal *= -1
        End If

        Return returnVal
    End Function



    'Public Function Compare(x As Object, y As Object) As Integer _
    '                  Implements System.Collections.IComparer.Compare
    '    Dim returnVal As Integer = -1

    '    Dim dtX As DateTime
    '    Dim dtY As DateTime

    '    Dim stStr As String = ""

    '    Try


    '        stStr = CType(x, ListViewItem).SubItems(col).Text

    '        dtX = DateTime.Parse(CType(x, ListViewItem).SubItems(col).Text)
    '        dtY = DateTime.Parse(CType(y, ListViewItem).SubItems(col).Text)

    '        returnVal = DateTime.Compare(dtX, dtY)


    '    Catch ex As Exception

    '        returnVal = [String].Compare(CType(x,
    '                               ListViewItem).SubItems(col).Text,
    '                               CType(y, ListViewItem).SubItems(col).Text)
    '    End Try
    '    ' Determine whether the sort order is descending.
    '    If order = SortOrder.Descending Then
    '        ' Invert the value returned by String.Compare.
    '        returnVal *= -1
    '    End If

    '    Return returnVal
    'End Function



End Class