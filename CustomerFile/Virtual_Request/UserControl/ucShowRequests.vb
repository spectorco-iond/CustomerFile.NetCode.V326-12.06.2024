Public Class ucShowRequests

    '    Private ObjListView As New ListView
    '    Private frmParent As frmShowRequests
    '    Private varCpt As Int32 = 0 'use in LstCreate because need create listview object only on time but each time when i call i don't nee crete object , only reuse.

    '    Public Sub New()

    '        ' This call is required by the designer.
    '        InitializeComponent()

    '        ' Add any initialization after the InitializeComponent() call.

    '        ' Dim f As frmShowRequests = FindForm()
    '        'Dim f As frmShowRequests
    '        'f = FindForm()
    '        'If Not IsNothing(f) Then
    '        '    AddHandler f.FormClosed, AddressOf ParentFormClosing
    '        ' End If



    '        Call LstCreate()

    '    End Sub
    '    Public Sub New(param As String)
    '        MyBase.New()
    '        ' This call is required by the designer.
    '        InitializeComponent()

    '        ' Dim f As frmShowRequests = FindForm()
    '        'Dim f As frmShowRequests
    '        'f = FindForm()
    '        'If Not IsNothing(f) Then
    '        '    AddHandler f.FormClosed, AddressOf ParentFormClosing
    '        'End If

    '        ' Add any initialization after the InitializeComponent() call.

    '        Call LstCreate(param)

    '    End Sub
    '    'Private Sub ParentFormClosing(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    '    '    Try
    '    '        Dim f As New frmShowRequests

    '    '        f = sender
    '    '        f.Close()

    '    '    Catch ex As Exception
    '    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    '    End Try
    '    'End Sub
    '#Region "----------------- Create ListView Object ---------------------"
    '    Private Sub lstView_DoubleClick(sender As Object, e As EventArgs)
    '        Try
    '            '   Debug.Print(objListView.SelectedItems(0).SubItems(1).Text)
    '            Dim lstRequestView As New ListView

    '            lstRequestView = sender

    '            Dim frmStoryBoard As New frmVirtual_Request(CInt(lstRequestView.SelectedItems.Item(0).SubItems(Request_View.RequestId).Text), lstRequestView.SelectedItems.Item(0).SubItems(Request_View.ReviewId).Text)


    '            'Dim frmCust As New frmCustomer ' = FindForm()
    '            'If Not IsNothing(frmCust) Then
    '            '    frmStoryBoard.Show()
    '            'Else
    '            '    frmStoryBoard.ShowDialog()
    '            'End If
    '            '  Dim f As frmShowRequests = FindForm()

    '            If varIdentIfCustFormIsOpen = True Then
    '                frmShow.Hide()
    '                frmStoryBoard.ShowDialog()
    '                ' Dim f As frmShowRequests = FindForm()
    '            Else

    '                frmShow.Hide()
    '                frmStoryBoard.ShowDialog()
    '            End If

    '            frmShow.Show()
    '            Call LstCreate(variableSql)

    '        Catch ex As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '        End Try
    '    End Sub
    '    Private variableSql As String = ""
    '    Public Sub LstCreate(Optional strQuery As String = "")
    '        Try

    '            variableSql = strQuery

    '            Dim oReqView As New cRequest_View
    '            Dim olsReqView As New List(Of cRequest_View)

    '            '---------------- fill listbox with probabily customers ------------------
    '            '  If ObjListView.Items.Count = 0 Then
    '            If varCpt = 0 Then
    '                varCpt += 1
    '                ObjListView = New ListView
    '                With ObjListView
    '                    .Dock = DockStyle.Fill
    '                End With

    '                panShowRequest.Controls.Add(ObjListView)

    '                RemoveHandler ObjListView.DoubleClick, New EventHandler(AddressOf lstView_DoubleClick)

    '                'Add the event handler.
    '                AddHandler ObjListView.DoubleClick, New EventHandler(AddressOf lstView_DoubleClick)

    '                '  panMiddleLstViewCustomerShow.Visible = True
    '                '  ObjListView.Items.Clear()
    '            Else
    '                ObjListView.Items.Clear()

    '            End If

    '            Dim Items As New List(Of ListViewItem)
    '            Dim item(-1) As ListViewItem

    '            Dim clHeader As New ColumnHeader()


    '            olsReqView = oReqView.LoadLst(strQuery)

    '            With ObjListView
    '                .View = View.Details
    '                .HeaderStyle = ColumnHeaderStyle.Clickable   ' set to whatever you need
    '                .HoverSelection = True
    '                .Columns.Clear() ' make sure collumnscollection is empty
    '                ' Add 3 columns
    '                .Columns.AddRange(New ColumnHeader() {listColumns(Request_View.RevItemCd.ToString, Request_View.RevItemCd.ToString, HorizontalAlignment.Left, 100),
    '                                                          listColumns(Request_View.Rush_Order.ToString, Request_View.Rush_Order.ToString, HorizontalAlignment.Left, 70),
    '                                                          listColumns(Request_View.Created.ToString, Request_View.Created.ToString, HorizontalAlignment.Left, 150),
    '                                                          listColumns(Request_View.Creator.ToString, Request_View.Creator.ToString, HorizontalAlignment.Left, 100),
    '                                                          listColumns(Request_View.Description.ToString, Request_View.Description.ToString, HorizontalAlignment.Left, 150),
    '                                                          listColumns(Request_View.Status.ToString, Request_View.Status.ToString, HorizontalAlignment.Left, 100),
    '                                                          listColumns(Request_View.Person.ToString, Request_View.Person.ToString, HorizontalAlignment.Left, 100),
    '                                                          listColumns(Request_View.Account.ToString, Request_View.Account.ToString, HorizontalAlignment.Left, 250),
    '                                                          listColumns(Request_View.RequestId.ToString, Request_View.RequestId.ToString, HorizontalAlignment.Left, 0),
    '                                                          listColumns(Request_View.ReviewId.ToString, Request_View.ReviewId.ToString, HorizontalAlignment.Left, 0),
    '                                                          listColumns(Request_View.ReviewNo.ToString, Request_View.ReviewNo.ToString, HorizontalAlignment.Left, 0)
    '                    })
    '                .FullRowSelect = True
    '                .GridLines = True
    '                .Height = 10
    '                .Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)

    '            End With

    '            'For Each oCust As cCicmpy In olsCicmpy
    '            '    lstViewCustomer.Items.Add(New ListViewItem(oCust.CMP_CODE.ToString.ToUpper))
    '            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_NAME.ToString.ToUpper)
    '            '    lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(oCust.CMP_E_MAIL.ToString.ToUpper)

    '            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(3).ToString.ToUpper)
    '            '    'lstViewCustomer.Items(lstViewCustomer.Items.Count - 1).SubItems.Add(numberrow.ItemArray.GetValue(4).ToString.ToUpper)
    '            'Next

    '            For Each oReqV As cRequest_View In olsReqView
    '                ReDim Preserve item(UBound(item) + 1)
    '                item(UBound(item)) = New ListViewItem

    '                item(UBound(item)).Text = Trim(oReqV.RevItemCd).ToString

    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Rush_Order).ToString)
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Created.ToString("dd-MM-yyyy")))
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Creator).ToString)

    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Description).ToString)

    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Status).ToString)
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Person).ToString)
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.Account).ToString)

    '                item(UBound(item)).SubItems.Add(Trim(oReqV.RequestId).ToString)
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.ReviewId).ToString)
    '                item(UBound(item)).SubItems.Add(Trim(oReqV.ReviewNo).ToString)

    '                Items.Add(item(UBound(item)))
    '            Next




    '            ObjListView.BeginUpdate()
    '            ObjListView.Items.AddRange(Items.ToArray)
    '            ObjListView.EndUpdate()
    '            ObjListView.Visible = True
    '            ObjListView.Focus()

    '            'lblMiddleLineNameDisplay.Text = cust_show.Customer.ToString
    '            'lblMiddleLineNameDisplay.Tag = cust_show.Customer
    '            'lblMiddleLineFound.Text = Items.Count & " rows"
    '            Call ListView_RowsColor(ObjListView)



    '        Catch ex As Exception
    '            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '        End Try
    '    End Sub






    '#End Region

End Class
