Public Class frmReportCriteria

    Public report_criteria As String
    Public reportParam As String

    Private Sub frmReportCriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reportParam = "010101010"

        Select Case report_criteria
            Case "ProgramCustomerGroup", "SpecialPricingCustomerGroup", "QuoteCustomerGroup"
                lblCriteriatoSearch.Text = "Search by Customer Group : "
            Case "ProgramCustomerCode", "SpecialPricingCustomerCode", "QuoteCustomerCode"
                lblCriteriatoSearch.Text = "Search by Customer Code : "
        End Select

    End Sub

    Private Sub txtCriteria_TextChanged(sender As Object, e As EventArgs) Handles txtCriteria.TextChanged
        Try

            If txtCriteria.Text.Length > 2 Then

                Dim db As New cDBA
                Dim dt As DataTable
                Dim strSql As String = ""

                Select Case report_criteria
                    Case "ProgramCustomerGroup", "SpecialPricingCustomerGroup", "QuoteCustomerGroup"
                        strSql = "select Distinct textfield3 As Customer_Group from cicmpy where  cmp_status = 'A' and textfield3 like '%" & txtCriteria.Text & "%'"
                    Case "ProgramCustomerCode", "SpecialPricingCustomerCode", "QuoteCustomerCode"
                        strSql = "select Distinct cmp_code As Customer_Code,cmp_name As Customer_Name from cicmpy where  cmp_status = 'A' and (cmp_code like '%" & txtCriteria.Text & "%' or cmp_name  like '%" & txtCriteria.Text & "%')"

                    Case Else
                        strSql = "select Distinct top 0 cmp_code As Customer_Code, cmp_name As Customer_Name, textfield3 As Customer_Group from cicmpy "
                End Select

                dt = db.DataTable(strSql)

                dgvCriteria.AllowUserToAddRows = True
                If dt.Rows.Count <> 0 Then
                    dgvCriteria.DataSource = dt
                Else
                    dgvCriteria.DataSource = dt
                End If
                dgvCriteria.AllowUserToAddRows = False
            End If


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvCriteria_DoubleClick(sender As Object, e As EventArgs) Handles dgvCriteria.DoubleClick
        Try

            If dgvCriteria.Rows.Count = 0 Then Exit Sub

            reportParam = dgvCriteria.CurrentRow.Cells(0).Value.ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK




        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub frmReportCriteria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    Try

    '        If reportParam = String.Empty Then
    '            Me.DialogResult = Windows.Forms.DialogResult.No
    '            e.Cancel = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub
End Class