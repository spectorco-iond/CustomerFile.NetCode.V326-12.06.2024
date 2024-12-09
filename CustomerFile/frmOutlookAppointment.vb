Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class frmOutlookAppointment

    Private m_DateButton As Button
    Private labelName As String
    Private eR As String
    Public m_boolSave As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        labelName = ""
        FormatDateTimePicket(dtpStartHours, txtStartTime)
        FormatDateTimePicket(dtpEndHours, txtEndTime)
        txtError.Visible = False
        m_boolSave = False

    End Sub

    ' Puts the selected date from the calendar info the linked textbox.
    Private Sub mcCalendar_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalendar.DateSelected

        Try

            Select Case m_DateButton.Name
                Case "cmdStartTime"
                    txtStartTime.Text = mcCalendar.SelectionRange.Start
                    txtStartTime.Focus()

                Case "cmdEndTime"
                    txtEndTime.Text = mcCalendar.SelectionRange.Start
                    txtEndTime.Focus()
            End Select

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            mcCalendar.Visible = False
            m_DateButton = Nothing
        End Try

    End Sub

    ' When date time picker gets Escape button, it closes.
    Private Sub mcCalendar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mcCalendar.KeyDown

        Try
            If e.KeyCode = Keys.Escape Then ' e.Control And e.KeyValue = Keys.F Then
                mcCalendar.Visible = False
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub mcCalendar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mcCalendar.MouseLeave
        Try

            mcCalendar.Visible = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

#Region "Maintenance Function ###########################"

    ' Date buttons click - open DateControl for element
    Private Sub Element_DateButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartTime.Click, cmdEndTime.Click

        Try
            m_DateButton = New Button
            m_DateButton = DirectCast(sender, Button)

            mcCalendar.Top = m_DateButton.Top
            mcCalendar.Left = m_DateButton.Left
            mcCalendar.Visible = True
            mcCalendar.SetDate(Date.Now)

            Select Case m_DateButton.Name
                Case "cmdStartTime"
                    If IsDate(txtStartTime.Text) Then mcCalendar.SetDate(txtStartTime.Text)

                Case "cmdEndTime"
                    If IsDate(txtEndTime.Text) Then mcCalendar.SetDate(txtEndTime.Text)

            End Select
            mcCalendar.Select()

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
    Private Sub FormatDateTimePicket(ByRef dt As DateTimePicker, ByRef txt As TextBox)
        Try

            dt.Value = dtpStartHours.Value.AddHours(1)
            dt.Format = DateTimePickerFormat.Time
            dt.ShowUpDown = True

            txt.Text = Date.Now


        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Friend Sub CreateAppointment(ByVal title As String)
        Try

       
        'retrive only hours:min:sec
        Dim dtS As Date = dtpStartHours.Value.ToShortTimeString
        Dim dtE As Date = dtpEndHours.Value.ToShortTimeString

        'concatine and convert in date
        Dim dtSConvStr As Date = Convert.ToDateTime(txtStartTime.Text & " " & dtS)
        Dim dtEConvStr As Date = Convert.ToDateTime(txtEndTime.Text & " " & dtE)

        Dim apptItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        Dim apItem As New Microsoft.Office.Interop.Outlook.Application

        apptItem = apItem.Session.Application.CreateItem(Outlook.OlItemType.olAppointmentItem)

        'https://www.add-in-express.com/creating-addins-blog/2013/06/10/outlook-calendar-appointment-meeting-items/

        With apptItem
            .Subject = title
            .Location = txtLocation.Text
            .Start = dtSConvStr 'DateTime.Now
            .End = dtEConvStr 'Date.Now.AddHours(2)
            .Duration = 5
                .Body = txtBody.Text
            .Save()
            .Send()
        End With
            m_boolSave = True

        'Release COM Objects
            If apptItem IsNot Nothing Then Marshal.ReleaseComObject(apptItem)

        Catch er As Exception
            txtStartTime.Text = ""
            m_boolSave = False
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
           
        End Try
    End Sub

    Public Function Validation() As Boolean

        Validation = False
        Dim i As Integer = 0

        eR = ""
        txtError.Visible = False



        If Trim(txtSubject.Text) = "" Then
            eR &= " Subject is empty ! " & " " & vbCrLf
            i = i + 1
            txtError.Visible = True
        End If

        Dim dtS As DateTimePicker = dtpStartHours
        dtS.Format = DateTimePickerFormat.Time



        If Convert.ToDateTime(txtStartTime.Text & " " & dtS.Value.TimeOfDay.ToString) > Convert.ToDateTime(txtEndTime.Text & " " & dtpEndHours.Value.TimeOfDay.ToString) Then
            eR &= " Start date it must be smaller than End Date " & " " & vbCrLf
            i = i + 1
            txtError.Visible = True
        ElseIf Convert.ToDateTime(txtStartTime.Text & " " & dtS.Value.TimeOfDay.ToString) < Date.Now Then

            eR &= " Start date must be  todays date or later . " & " " & vbCrLf
            i = i + 1
            txtError.Visible = True

        End If

            If i = 0 Then Validation = True

    End Function
    Private Sub ProprieteText(ByVal eRr As String)
        Try
            txtError.Visible = True
            txtError.BackColor = Color.Brown
            txtError.Text = eRr
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
#End Region
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
           
            If Validation() = True Then

                Call CreateAppointment(txtSubject.Text)

                m_boolSave = True
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Me.Close()

                Me.Cursor = System.Windows.Forms.Cursors.Arrow

            Else
                Call ProprieteText(eR)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Me.Close()
         
            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

End Class