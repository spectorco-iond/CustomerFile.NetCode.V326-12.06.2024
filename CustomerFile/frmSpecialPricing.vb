Public Class frmSpecialPricing

    Private Sub frmSpecialPricing_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            UcSpecialPricing.Load()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

End Class