Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim oCust As New cCustomer("USA434")

        Dim oFrm As New frmCustomerHeader(oCust)

        oFrm.ShowDialog()
        oFrm.Dispose()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim oCustomer As New cCustomerInfo("USA434")
        oCustomer.Form.ShowDialog()
        oCustomer = Nothing

    End Sub


End Class
