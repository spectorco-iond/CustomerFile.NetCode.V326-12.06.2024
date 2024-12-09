Public Class frmPushOrder

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer
    Private m_Push_Order As cMdb_Cus_Push_Order

    Private db As New cDBA()

    Private dtProgram_Type As DataTable

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

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pPush_Order As cMdb_Cus_Push_Order)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Push_Order = pPush_Order

    End Sub

#End Region


#Region "PRIVATE EVENTS - FORM ################################################"

    Private Sub frmPrograms_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If m_Push_Order Is Nothing Then
                m_Push_Order = New cMdb_Cus_Push_Order()
            End If

            Call FillFields()

            'Call txtStart_Dt_FillCombo()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    Private Sub Insert()

        Try
            m_Push_Order = New cMdb_Cus_Push_Order()
            m_Push_Order.Cus_No = m_Customer.cmp_code

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()

        Try
            'Dim oBUS As New cMdb_Charge_Usage_BUS()

            If m_Push_Order Is Nothing Then m_Push_Order = New cMdb_Cus_Push_Order()

            m_Push_Order.Cus_Push_Order_Id = txtCus_Push_Order_ID.Text
            m_Push_Order.Push_Date = txtStart_Dt.Text
            m_Push_Order.Cus_No = txtCus_No.Text
            m_Push_Order.Ord_Comment = txtOrd_Comment.Text
            m_Push_Order.Ord_No = CInt(txtOrd_No.Text)

            m_Push_Order.Save()

            txtCus_Push_Order_ID.Text = m_Push_Order.Cus_Push_Order_Id
            txtUser_Login.Text = m_Push_Order.User_Login
            txtUpdate_TS.Text = m_Push_Order.Update_TS

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


    Private Sub ClearFields()

        txtCus_Push_Order_ID.Text = "0"
        txtStart_Dt.Text = String.Empty
        txtCus_No.Text = String.Empty
        txtOrd_Comment.Text = String.Empty
        txtOrd_No.Text = String.Empty
        m_Push_Order.User_Login = String.Empty
        m_Push_Order.Update_TS = String.Empty

    End Sub

    Private Sub FillFields()

        txtCus_No.Text = m_Push_Order.Cus_No
        txtCus_Push_Order_ID.Text = m_Push_Order.Cus_Push_Order_Id
        If m_Push_Order.Push_Date.Year <> 1 Then txtStart_Dt.Text = m_Push_Order.Push_Date
        txtOrd_Comment.Text = m_Push_Order.Ord_Comment
        txtOrd_No.Text = m_Push_Order.Ord_No
        txtUser_Login.Text = m_Push_Order.User_Login
        If m_Push_Order.Update_Ts.Year <> 1 Then txtUpdate_TS.Text = m_Push_Order.Update_Ts

    End Sub

#End Region


#Region "PRIVATE COMBOBOX ROUTINES ############################################"


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

    Public Property Program() As cMdb_Cus_Push_Order
        Get
            Program = m_Push_Order
        End Get
        Set(value As cMdb_Cus_Push_Order)
            m_Push_Order = value
        End Set
    End Property

#End Region

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Call Save()
        Me.Close()

    End Sub


#Region "Private DateTimePicker control functions #########################"

    ' Date buttons click - open DateControl for element
    Private Sub Element_DateButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart_Dt.Click

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


    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click

        Me.Close()

    End Sub

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

End Class