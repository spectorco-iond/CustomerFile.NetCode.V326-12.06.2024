Public Class frmUserMaintenance
    Private ol_ComplaintUser As cComplaintCallUser

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ol_ComplaintUser = New cComplaintCallUser
    End Sub
    Public Sub New(ByVal io_COMPLAINT_CALL_USER As cComplaintCallUser)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ol_ComplaintUser = io_COMPLAINT_CALL_USER

    End Sub


    Private Sub bt_Save_Click(sender As Object, e As EventArgs) Handles bt_Save.Click
        If check_input() Then
            Call initial_userobject()
            'save
            ol_ComplaintUser.Save()
            Me.Close()
        End If
    End Sub

    Private Sub initial_userobject()
        'initial object 
        ol_ComplaintUser.FIRST_NAME = tb_first_name.Text
        ol_ComplaintUser.LAST_NAME = tb_last_name.Text
        ol_ComplaintUser.LANGUAGE_ID = cbb_language_id.SelectedValue
        ol_ComplaintUser.USER_CONTACT_PHONE_NUMBER = tb_phone_number.Text
        ol_ComplaintUser.USER_ADDRESS = tb_user_address.Text
        ol_ComplaintUser.USER_POST_CODE = tb_user_post_code.Text
        ol_ComplaintUser.USER_CITY = tb_city.Text
        ol_ComplaintUser.USER_EMAIL = tb_email.Text
        ol_ComplaintUser.CREATE_BY = Environment.UserName
        ol_ComplaintUser.CREATE_DATE = Date.Now
        ol_ComplaintUser.BELONG_CSR = tb_belong_csr.Text
        ol_ComplaintUser.STATUS = 1
    End Sub
    Private Function check_input() As Boolean
        'check input
        If Not check_input(tb_first_name.Text) Then
            MsgBox("please input first_name ")
            Return False
        End If
        If Not check_input(tb_last_name.Text) Then
            MsgBox("please input last_name ")
            Return False
        End If
        If Not check_input(cbb_language_id.SelectedValue) Then
            MsgBox("please input language ")
            Return False
        End If
        If Not check_input(tb_phone_number.Text) Then
            MsgBox("please input phone_number ")
            Return False
        End If
        If Not check_input(tb_user_address.Text) Then
            MsgBox("please input address ")
            Return False
        End If
        If Not check_input(tb_user_post_code.Text) Then
            MsgBox("please input post_code ")
            Return False
        End If
        If Not check_input(tb_city.Text) Then
            MsgBox("please input city_name ")
            Return False
        End If
        If Not check_input(tb_email.Text) Then
            MsgBox("please input email ")
            Return False
        End If
        Return True
    End Function
    Private Function check_input(ByVal content As String) As Boolean
        check_input = True
        If Trim(content) = "" Then check_input = False
    End Function

    Private Sub cbb_language_id_initial()
        cbb_language_id.Items.Clear()
        Dim dt_cbb_language_id As DataTable = Get_MDB_CFG_LANGUAGE_List()
        If dt_cbb_language_id.Rows.Count <> 0 Then
            With cbb_language_id
                .DataSource = dt_cbb_language_id
                .DisplayMember = "LANGUAGE_CODE"
                .ValueMember = "LANGUAGE_ID"
            End With
        End If
    End Sub

    Public Function Get_MDB_CFG_LANGUAGE_List() As DataTable

        Get_MDB_CFG_LANGUAGE_List = New DataTable

        Try

            Dim strSQL As String =
            "SELECT		ISNULL(E.LANGUAGE_ID, 0) AS LANGUAGE_ID, rtrim(isnull(E.LANGUAGE_CODE, '')) AS LANGUAGE_CODE " &
            "FROM       MDB_CFG_LANGUAGE E WITH (Nolock) " &
            "ORDER BY   LANGUAGE_CODE "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSQL)

            Get_MDB_CFG_LANGUAGE_List = dt

        Catch er As Exception
            MsgBox("Error in Get_MDB_CFG_LANGUAGE_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Private Sub frmUserMaintenance_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call cbb_language_id_initial()
        tb_first_name.Text = Trim(ol_ComplaintUser.FIRST_NAME)
        tb_last_name.Text = Trim(ol_ComplaintUser.LAST_NAME)
        cbb_language_id.SelectedValue = ol_ComplaintUser.LANGUAGE_ID
        cbb_language_id.SelectedValue = CType(ol_ComplaintUser.LANGUAGE_ID, Integer)

        tb_phone_number.Text = ol_ComplaintUser.USER_CONTACT_PHONE_NUMBER
        tb_user_address.Text = ol_ComplaintUser.USER_ADDRESS
        tb_user_post_code.Text = ol_ComplaintUser.USER_POST_CODE
        tb_city.Text = ol_ComplaintUser.USER_CITY
        tb_email.Text = ol_ComplaintUser.USER_EMAIL
        '= Environment.UserName =ol_ComplaintUser.CREATE_BY 
        ' = Date.Now = ol_ComplaintUser.CREATE_DATE
        tb_belong_csr.Text = ol_ComplaintUser.BELONG_CSR
        'ol_ComplaintUser.STATUS = 
    End Sub

    Private Sub bt_Save_new_complaint_Click(sender As Object, e As EventArgs) Handles bt_Save_new_complaint.Click
        If check_input() Then
            Call initial_userobject()
            'save
            ol_ComplaintUser.Save()
            Using frm_createHeader = New FrmCallheadermaintenance(ol_ComplaintUser)
                frm_createHeader.ShowDialog()
            End Using
            Me.Close()
        End If
    End Sub
End Class