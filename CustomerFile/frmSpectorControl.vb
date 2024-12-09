Public Class frmSpectorControl

    Dim ExitFromNotificationArea As Boolean

    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not e.CloseReason = CloseReason.WindowsShutDown Or Not ExitFromNotificationArea Then
            'If SpectorControlSettings.MinimizeOnClose Then
            '    e.Cancel = True
            '    ShowHideMainWindow()
            'Else
            'If SpectorControlSettings.AskConfirmation Then
            Dim DResult As DialogResult = MessageBox.Show("Do you really want to close the Spector Control ?", _
                         "APPLICATION", MessageBoxButtons.YesNo, _
                         MessageBoxIcon.Question)

            If DResult = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
            'End If
            'End If

            If e.Cancel = False Then
                Me.niSpectorControl.Visible = False
                Me.Dispose()
                Application.Exit()
            End If

        End If

    End Sub

    Private Sub ShowHideMainWindow()
        If Not Me.Visible Then
            Me.Show()
        Else
            Me.Hide()
        End If
    End Sub

    'Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    '    ExitFromNotificationArea = True

    '    Me.niSpectorControl.Visible = False
    '    Me.Dispose()
    '    Application.Exit()
    'End Sub

    Private Sub frmSpectorControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Visible = False

    End Sub

End Class