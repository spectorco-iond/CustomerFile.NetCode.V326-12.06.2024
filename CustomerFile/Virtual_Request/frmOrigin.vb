
Public Class frmOrigin
    Public Requiest_Original As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Requiest_Original = ""
        'Me.DialogResult = DialogResult.No

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmOrigin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            e.Cancel = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmOrigin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape And rdCustomer.Checked <> False Then
                Me.Close()
            Else
                MsgBox("Before  close, you need to select one of the options is mandatory.Thank you.")
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmOrigin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Requiest_Original = ""
            'Me.DialogResult = DialogResult.No
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lblInfoEsc_Click(sender As Object, e As EventArgs) Handles lblInfoEsc.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub rdCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles rdCustomer.CheckedChanged, rdSales.CheckedChanged, rdCs_Bd.CheckedChanged, rdNoBody.CheckedChanged, rdCs_Online_St_Cat.CheckedChanged
        Try

            Dim rad As RadioButton

            rad = sender

            '   If rad.Checked = True And rad.Text <> "No Body" Then
            If rad.Checked = True Then
                Requiest_Original = rad.Text
                lblInfoEsc.Visible = True
                Me.DialogResult = DialogResult.Yes
            Else
                Requiest_Original = ""
                Me.DialogResult = DialogResult.No
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



End Class