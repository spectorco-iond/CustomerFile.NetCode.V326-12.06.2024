
Public Class frmEmailContacts

    Public email As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub frmEmailContacts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            Call CreateColumns(dgvEmailContacts)
            Call EmailAddress()

            dgvEmailContacts.AllowUserToAddRows = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "maintenance"

    Private Sub CreateColumns(ByRef dgv As DataGridView)
        Try
            With dgv.Columns
                .Add(DGVTextBoxColumn("ID", "Id", 50))
                .Add(DGVTextBoxColumn("User_Name", "User_Name", 50))
                .Add(DGVTextBoxColumn("FullName", "Full Name", 130))
                .Add(DGVTextBoxColumn("Email", "Email", 220))
            End With

            dgv.Columns(Columns.ID).Visible = False
            dgv.Columns(Columns.User_Name).Visible = False
            dgv.ReadOnly = True
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            dgv.RowTemplate.Height = 90
            dgv.RowHeadersVisible = False
            dgv.ColumnHeadersVisible = False


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Enum Columns
        ID
        User_Name
        FullName
        Email
    End Enum


    Private Sub EmailAddress()
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim strSql As String


            'strSql = _
            '        "Select FullName, Email from user_permissions_info (NoLock) " & _
            '        "  where  PermissionGroup in ('Manager','CSR')"

            strSql = _
                " Select User_Name ,Fullname,Email  from user_permissions_info (NoLock) " & _
                " where  Fullname in ('Tanya Abitbol','Jennifer LeBricon') " & _
               "   union all " & _
               " Select User_Name ,Fullname,Email  from user_permissions_info (NoLock) " & _
               "  where  PermissionGroup in ('Manager','CSR') "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                dgvEmailContacts.DataSource = dt
                End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try

            email = dgvEmailContacts.CurrentRow.Cells(Columns.Email).Value.ToString
            Me.Close()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class