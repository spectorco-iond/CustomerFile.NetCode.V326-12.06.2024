Public Class frmOrders

    Private Sub UcOrders_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            UcOrders.Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

End Class