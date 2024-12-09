Public Class cDgvControl
    Inherits DataGridView

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Dim key As Keys = (keyData And Keys.KeyCode)
        If key = Keys.Enter Then
            Return True
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function


End Class
