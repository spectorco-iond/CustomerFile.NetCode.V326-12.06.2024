Public Class frmQuote_Step_Request

    Private m_Program_Type_ID As Integer = 0
    Private m_Quote_Type_ID As Integer = 0
    Private m_Quote_Step_ID As Integer = 0
    Private m_Request_User As String = String.Empty
    Private dtUsers As DataTable
    Private m_Proceed As Boolean = False
    Private m_blnCannotAutoApprove As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pProgram_Type As String, ByVal pQuote_Type_ID As Integer, ByVal pQuote_Step_ID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Select Case pProgram_Type
            Case "Quote"
                m_Program_Type_ID = (Program_Types.Quote + 1)
            Case "Program"
                m_Program_Type_ID = (Program_Types.Program + 1)
            Case "Special Pricing"
                m_Program_Type_ID = (Program_Types.Special_Pricing + 1)
        End Select

        'm_Program_Type_ID = pProgram_Type
        m_Quote_Type_ID = pQuote_Type_ID
        m_Quote_Step_ID = pQuote_Step_ID


    End Sub

    Private Sub frmQuote_Step_Request_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            Call dgvUsers_CreateColumns()
            Call dgvUsers_Fill()
            Call dgvUsers_Format()

            ' chkNoSendRequest.Visible = (m_Program_Type_ID = 2) ' (m_Quote_Type_ID = 1 Or m_Quote_Type_ID = 2)
            chkNoSendRequest.Enabled = Not (m_blnCannotAutoApprove)

            If m_Program_Type_ID = (Program_Types.Program + 1) Then chkNoSendRequest.Enabled = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub


#Region "PRIVATE dgvUsers MAINTENANCE OPERATIONS ##############################"

    Private Sub dgvUsers_CreateColumns()

        Try
            With dgvUsers.Columns

                If .Count > 0 Then
                    For iCol = .Count To 1 Step -1
                        .RemoveAt(iCol - 1)
                    Next
                End If

                .Add(DGVTextBoxColumn("SCREEN_USER", "Users for approval", 20))
                .Add(DGVTextBoxColumn("USER_ORDER", "Order", 20))

            End With

            dgvUsers.Columns(1).Visible = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvUsers_Fill()

        Try

            'Dim dt As DataTable
            Dim db As New cDBA

            Dim strSql As String = _
            "SELECT     DISTINCT SCREEN_USER AS SCREEN_USER, USER_ORDER " & _
            "FROM       MDB_CFG_QUOTE_PROC_USER WITH (Nolock) " & _
            " WHERE  SCREEN_USER not in ('MARCB','HILLEL') and " & _
            " QUOTE_TYPE_ID = " & m_Quote_Type_ID & " AND " & _
            "  QUOTE_STEP_ID = " & m_Quote_Step_ID & " " & _
            " ORDER BY   SCREEN_USER, USER_ORDER "

            dtUsers = db.DataTable(strSql)

            dgvUsers.DataSource = dtUsers

            dgvUsers.AllowUserToAddRows = False
            dgvUsers.AllowUserToOrderColumns = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub dgvUsers_Format()

        Try

            With dgvUsers
                For lPos As Integer = 0 To .Columns.Count - 1
                    .Columns(lPos).SortMode = DataGridViewColumnSortMode.NotSortable
                Next lPos

                dgvUsers.Columns(0).Width = 264

                .CausesValidation = True

                .CurrentCell = .Rows(0).Cells(0)

            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

#End Region


    Public ReadOnly Property Request_User() As String
        Get
            Request_User = m_Request_User
        End Get
    End Property

    Public ReadOnly Property Send_Request() As Boolean
        Get
            'Send_Request = Not (chkNoSendRequest.Checked)
            Send_Request = (chkNoSendRequest.Checked)
        End Get

    End Property

    Public ReadOnly Property Proceed() As Boolean
        Get
            Proceed = m_Proceed
        End Get
    End Property

    Private Sub tsbConfirmRequest_Click(sender As System.Object, e As System.EventArgs) Handles tsbConfirmRequest.Click

        m_Request_User = dgvUsers.CurrentRow.Cells(0).Value

        m_Proceed = True
        Me.Close()

        'Dim oResult As MsgBoxResult = MsgBox("Do you really want to proceed ??", MsgBoxStyle.YesNoCancel)

        'Select Case oResult
        '    Case MsgBoxResult.Yes
        '        m_Proceed = True
        '    Case MsgBoxResult.No
        '        m_Proceed = False
        '    Case MsgBoxResult.Cancel
        '        m_Proceed = False
        'End Select

        'If oResult <> MsgBoxResult.Cancel Then Me.Close()

    End Sub

    Public Property CannotAutoApprove() As Boolean
        Get
            CannotAutoApprove = m_blnCannotAutoApprove
        End Get
        Set(value As Boolean)
            m_blnCannotAutoApprove = value
        End Set
    End Property

End Class