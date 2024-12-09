Imports System.IO

Public Class cMail

    Private m_FromAddr As String = String.Empty

    Private m_ToAddr As String = String.Empty
    Private m_CCAddr As String = String.Empty
    Private m_BCCAddr As String = String.Empty

    Private m_Subject As String = String.Empty
    Private m_Message As String = String.Empty

    Private m_lstAttachments As List(Of String)

    Private mailer As Object
    'Private mailer As MailBee.SMTP

    Public Sub New()

    End Sub

    Public Sub Send()

        Call CreateEmailConnection()

        mailer.Message.FromAddr = m_FromAddr ' "Marc Beauregard <marcb@spectorandco.ca>"
        mailer.Message.ToAddr = m_ToAddr '"email_log@bankers.ca"  "iond@spectorandco.com"
        mailer.Message.CCAddr = m_CCAddr
        mailer.Message.BCCAddr = m_BCCAddr
        mailer.Message.Subject = m_Subject
        mailer.Message.BodyText = m_Message

        If m_lstAttachments IsNot Nothing AndAlso m_lstAttachments.Count > 0 Then
            For Each d As String In m_lstAttachments
                mailer.Message.AddAttachment(d)
            Next
        End If

        Try

            ' mailer.Send()
            '++ID 1.07.2020 added if

            If mailer.Send() = True Then
                log_mailbe_parameter(mailer, 0)
            Else
                log_mailbe_parameter(mailer, 1)
            End If

        Catch er As Exception
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Call CloseEmailConnection()

    End Sub

    Public Sub AddAttachment(ByVal pstrFilename As String)
        Try

            If m_lstAttachments Is Nothing Then m_lstAttachments = New List(Of String)
            m_lstAttachments.Add(pstrFilename)

        Catch er As Exception
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub


    Private Sub CreateEmailConnection()

        Try

            'mailer = New MailBee.SMTP
            mailer = CreateObject("MailBee.SMTP")

            ' Unlock MailBee.SMTP object
            mailer.LicenseKey = "MBC500-5959843B6F-3D8F3ABAB139E365D283A4325B857897"

            ' SMTP server name
            mailer.ServerName = "uranium"

            Dim dt As DataTable
            Dim db As New cDBA
            Dim strsql As String =
            "SELECT * " &
            "FROM TRAVELER_CONFIG WITH (Nolock) " &
            "WHERE param IN ('setupEmailServer','setupEmailPort') "

            dt = db.DataTable(strsql)
            If dt.Rows.Count <> 0 Then
                For Each dtRow As DataRow In dt.Rows
                    If dtRow.Item("Param").ToString.Trim = "setupEmailServer" Then
                        mailer.ServerName = dtRow.Item("ParamValue").ToString.Trim
                    ElseIf dtRow.Item("Param").ToString.Trim = "setupEmailPort" Then
                        mailer.PortNumber = dtRow.Item("ParamValue")
                    End If
                Next
            Else
                mailer.ServerName = ""
                mailer.PortNumber = 0
            End If

            ' Mark that body has HTML format
            mailer.Message.BodyFormat = 1

            ' Enable logging SMTP session into a file. If any errors  
            ' occur, the log can be used to investigate the problem.
            mailer.EnableLogging = True
            mailer.LogFilePath = "C:\HV_Control_SendLog.txt"

        Catch er As Exception
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Private Sub CloseEmailConnection()

        Try
            ' Close the SMTP session
            If Not (mailer Is Nothing) Then mailer.Disconnect()

            'UPGRADE_NOTE: Object mailer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            mailer = Nothing

        Catch er As Exception

        End Try

    End Sub

    '--------------------------------------------------------log  txt file-------------------------------------------------------
    Private Sub log_mailbe_parameter(ByVal _mailer As Object, ByVal _error As Int32)
        Try

            'If Not Directory.Exists("C:\mailbelog\") Then
            '    Directory.CreateDirectory("C:\mailbelog\")
            'End If


            If Not Directory.Exists("\\cobalt5\macolaes\mcc\mailbelog\") Then
                Directory.CreateDirectory("\\cobalt5\macolaes\mcc\mailbelog\")
            End If

            Dim filePath As String =
    String.Format("\\cobalt5\macolaes\mcc\mailbelog\ErrorLog_{0}_{1}_{2}.txt", DateTime.Today.ToString("dd-MMM-yyyy"), System.Environment.MachineName, Environment.UserDomainName & "_" & Environment.UserName)
            Using writer As New StreamWriter(filePath, True)

                If File.Exists(filePath) Then
                    writer.WriteLine("-PC-name:" & System.Environment.MachineName & " .User Name:" & Environment.UserDomainName & "\" & Environment.UserName & " .Email Server Name:" & _mailer.ServerName & " .Email Server Response:" & _mailer.ServerResponse _
                                    & " .Sent From Addr:" & _mailer.FromAddr & " .Sent To Addr:" & _mailer.ToAddr & " .Subject:" & _mailer.Subject & " . Sent (Yes = 0 | Not Sent = 1) Result : " & _error & " .Occured at-- " & DateTime.Now)
                Else
                    writer.WriteLine("Start Error Log for today")
                End If
            End Using

        Catch er As Exception
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub


    '--------------------------------------------------------------------------------------------------------------------------


    Public Property FromAddr() As String
        Get
            FromAddr = m_FromAddr
        End Get
        Set(ByVal value As String)
            m_FromAddr = value
        End Set
    End Property

    Public Property ToAddr() As String
        Get
            ToAddr = m_ToAddr
        End Get
        Set(ByVal value As String)
            m_ToAddr = value
        End Set
    End Property

    Public Property CCAddr() As String
        Get
            CCAddr = m_CCAddr
        End Get
        Set(ByVal value As String)
            m_CCAddr = value
        End Set
    End Property

    Public Property BCCAddr() As String
        Get
            BCCAddr = m_BCCAddr
        End Get
        Set(ByVal value As String)
            m_BCCAddr = value
        End Set
    End Property

    Public Property Subject() As String
        Get
            Subject = m_Subject
        End Get
        Set(ByVal value As String)
            m_Subject = value
        End Set
    End Property

    Public Property Message() As String
        Get
            Message = m_Message
        End Get
        Set(ByVal value As String)
            m_Message = value
        End Set
    End Property

End Class

