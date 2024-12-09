
Public Class cMailQuickP

    Private m_FromAddr As String = String.Empty

    Private m_ToAddr As String = String.Empty
    Private m_CCAddr As String = String.Empty
    Private m_BCCAddr As String = String.Empty

    Private m_Subject As String = String.Empty
    Private m_Message As String = String.Empty

    Private m_Attachments() As String ' For Now
    'Private mstrLine As Integer = 0
    Public Attach() As String

    '  Private mailer As Object
    Private mailer As Object
    Private m_SentSuccessful As Boolean

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()
        m_FromAddr = String.Empty

        m_ToAddr = String.Empty
        m_CCAddr = String.Empty
        m_BCCAddr = String.Empty

        m_Subject = String.Empty
        m_Message = String.Empty

        ' Attach(0) = String.Empty

        m_SentSuccessful = False
    End Sub

    Public Sub Send()

        Call CreateEmailConnection()

        mailer.Message.FromAddr = m_FromAddr ' 
        mailer.Message.ToAddr = m_ToAddr '
        mailer.Message.CCAddr = m_CCAddr

        'mailer.Message.BCCAddr = m_BCCAddr
        mailer.Message.Subject = m_Subject
        mailer.Message.BodyText = m_Message

        If Attach.Length <> Nothing Then
            For i As Int32 = 0 To Attach.Length - 1
                If Attach(i) <> "" Then

                    mailer.Message.AddAttachment(Attach(i))
                    Debug.Print("Nb:" & i.ToString & "." & Attach(i).ToString)
                End If

            Next
        End If

        Try
            ' mailer.Send()

            ' Try to send message
            If mailer.Send Then
                m_SentSuccessful = True
                MsgBox("Sent successfully.")
            Else
                MsgBox("Error #" & mailer.ErrCode & ", " & mailer.ErrDesc)
                Call CloseEmailConnection()
                Exit Sub
            End If

        Catch er As Exception
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

        Call CloseEmailConnection()

    End Sub

    Private Sub CreateEmailConnection()

        Try
            '++ID 17.03.2015 it was in comment
            ' Dim mailer = New MailBee.SMTP
            mailer = CreateObject("MailBee.SMTP")

            ' Unlock MailBee.SMTP object
            mailer.LicenseKey = "MBC500-5959843B6F-3D8F3ABAB139E365D283A4325B857897"

            ' SMTP server name
            mailer.ServerName = "uranium"

            Dim dt As DataTable
            Dim db As New cDBA
            Dim strsql As String = _
            "SELECT * " & _
            "FROM TRAVELER_CONFIG WITH (Nolock) " & _
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
            MsgBox("Error in cMail." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

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
    Public Property SentSuccessful As Boolean
        Get
            SentSuccessful = m_SentSuccessful
        End Get
        Set(ByVal value As Boolean)
            m_SentSuccessful = value
        End Set
    End Property



End Class


