Public Class frmMdb_Cus_Comment

    Private User_Rights As String = "READONLY"

    Private m_Customer As cCustomer
    Private m_Comment As cMdb_Cus_Comment

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

    Public Sub New(ByRef pCustomer As cCustomer, ByRef pComment As cMdb_Cus_Comment)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Customer = pCustomer
        m_Comment = pComment

    End Sub

#End Region


#Region "PRIVATE EVENTS - FORM ################################################"

    Private Sub frmPrograms_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try

            Call SetPermissions()

            If m_Comment Is Nothing Then
                m_Comment = New cMdb_Cus_Comment()
            End If

            Call FillFields()

            Call cboComment_Type_ID_FillCombo()


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

#End Region


#Region "PRIVATE MAINTENANCE ROUTINES #########################################"

    Private Sub Insert()

        Try
            m_Comment = New cMdb_Cus_Comment()
            m_Comment.Cus_No = m_Customer.cmp_code

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub Save()

        Try
            'Dim oBUS As New cMdb_Charge_Usage_BUS()

            If m_Comment Is Nothing Then m_Comment = New cMdb_Cus_Comment()

            m_Comment.Cus_Comment_Id = txtCus_Comment_ID.Text
            If Not (cboComment_Type_ID.SelectedValue Is Nothing) Then m_Comment.Comment_Type_ID = cboComment_Type_ID.SelectedValue
            m_Comment.Cus_No = txtCus_No.Text
            m_Comment.Cus_Comment = txtCus_Comment.Text
            m_Comment.Comment_Order = CInt(txtComment_Order.Text)

            m_Comment.Save()

            txtCus_Comment_ID.Text = m_Comment.Cus_Comment_Id
            txtUser_Login.Text = m_Comment.User_Login
            txtUpdate_TS.Text = m_Comment.Update_TS

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

        txtCus_Comment_ID.Text = "0"
        cboComment_Type_ID.SelectedValue = 0
        txtCus_No.Text = String.Empty
        txtCus_Comment.Text = String.Empty
        txtComment_Order.Text = String.Empty
        m_Comment.User_Login = String.Empty
        m_Comment.Update_TS = String.Empty

    End Sub

    Private Sub FillFields()

        txtCus_Comment_ID.Text = m_Comment.Cus_Comment_Id
        cboComment_Type_ID.SelectedValue = m_Comment.Comment_Type_ID
        txtCus_No.Text = m_Comment.Cus_No
        txtCus_Comment.Text = m_Comment.Cus_Comment
        txtComment_Order.Text = m_Comment.Comment_Order
        txtUser_Login.Text = m_Comment.User_Login
        If m_Comment.Update_Ts.Year <> 1 Then txtUpdate_TS.Text = m_Comment.Update_Ts

    End Sub

#End Region


#Region "PRIVATE COMBOBOX ROUTINES ############################################"

    Private Sub cboComment_Type_ID_FillCombo()

        Dim strSql As String
        Dim db As New cDBA

        Try

            strSql = _
            "SELECT		0 AS Comment_Type_ID, '' AS Comment_Type_Desc " & _
            "UNION " & _
            "SELECT		C.Comment_Type_ID, ISNULL(C.Comment_Type_Desc, '') AS Comment_Type_Desc " & _
            "FROM		MDB_CFG_COMMENT_TYPE C WITH (Nolock) " & _
            "ORDER BY   Comment_Type_Desc "

            dtProgram_Type = db.DataTable(strSql)
            cboComment_Type_ID.DataSource = dtProgram_Type

            cboComment_Type_ID.DisplayMember = "Comment_Type_Desc"
            cboComment_Type_ID.ValueMember = "Comment_Type_ID"

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

    Public Property Program() As cMdb_Cus_Comment
        Get
            Program = m_Comment
        End Get
        Set(value As cMdb_Cus_Comment)
            m_Comment = value
        End Set
    End Property

#End Region

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click

        Call Save()
        Me.Close()

    End Sub


    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click

        Me.Close()

    End Sub

    Private Sub SetPermissions()

        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String

        ' IMPORTANT - THIS SCREEN SHOULD ALWAYS BE READ ONLY. WE WANT ENTRIES TO BE CATEGORIZED.

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