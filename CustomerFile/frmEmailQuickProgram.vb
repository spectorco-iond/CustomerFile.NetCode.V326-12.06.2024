Imports System.IO

Public Class frmEmailQuickProgram

    Dim drRowNew As DataRow
    Dim table As DataTable = New DataTable()
    Dim column As DataColumn

    Private m_Customer As cCustomer
    Private m_Program As cMdb_Cus_Prog
    Private DOCUMENT_PATH As String
    Private DOCUMENT_DESC As String
    Private mo_Email As cExact_Traveler_Email_Message
    Private contactId As Integer

    Public Property CONTACT_ID As Integer
        Get
            CONTACT_ID = contactId
        End Get
        Set(ByVal value As Integer)
            contactId = value
        End Set
    End Property


    Public Sub New(ByRef pCustomer As cCustomer, ByRef pProgram As cMdb_Cus_Prog)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_Customer = pCustomer
            m_Program = pProgram

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub frmEmailQuickProgram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call CreateColumn(dgvFileName)
            Call LoadInfo()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Call SendEmail()

            '   Call SaveEmail()

            Me.Cursor = Cursors.Default
            '   Me.Close()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "Load info in form Email QuickProgram"

    Private Sub LoadInfo()
        Try

            Call LoadLastDocumen(m_Program)

            ' LoadLastDocumen(m_Program).Substring(LoadLastDocumen(m_Program).LastIndexOf("\") + 1).Remove(LoadLastDocumen(m_Program).Substring'(LoadLastDocumen(m_Program).LastIndexOf("\") + 1).LastIndexOf("."))

            txtCus_No.Text = m_Customer.cmp_code
            txtCusName.Text = m_Customer.cmp_name
            txtEmailFrom.Text = Email(Environment.UserName)  ' mo_Email.EmailFrom
            '  txtFollowUp.Text = m_Program.Decision_Dt   'mo_Email.FollowUp
            txtEmailTo.Text = Trim(EmailCust()) 'mo_Email.EmailTo
            txtCC.Text = Email(Environment.UserName) & ";"
            txtCreate_TS.Text = Today.Date

            'If Not (Directory.Exists(Trim(strPath))) = False Then
            '    MsgBox(" File is not exported .")
            '    txtSubjectLine.Text = ""
            '    txtAttachments.Text = ""
            '    Exit Sub
            'End If
            Dim m_PathDirectory = DOCUMENT_PATH


            If DOCUMENT_PATH <> "" Then
                Try

                    m_PathDirectory = m_PathDirectory.Remove(m_PathDirectory.LastIndexOf("\") + 1)

                    If Not File.Exists(m_PathDirectory & DOCUMENT_DESC) Then

                        MsgBox(" File is not exported .")
                        txtSubjectLine.Text = ""
                        '  txtAttachments.Text = ""
                        Exit Sub
                        ' File.Delete(Trim(strPath))
                        '  Debug.Print("Deleted file name :" & Trim(strPath))

                    End If

                Catch ex As Exception
                    MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
                End Try


                If DOCUMENT_DESC.LastIndexOf(".") <> -1 Then
                    txtSubjectLine.Text = DOCUMENT_DESC.Remove(DOCUMENT_DESC.LastIndexOf("."))
                Else
                    txtSubjectLine.Text = DOCUMENT_PATH.Substring(DOCUMENT_PATH.LastIndexOf("\") + 1)
                End If

                'LoadLastDocumen(m_Program).Substring(LoadLastDocumen(m_Program).LastIndexOf("\") + 1)

                drRowNew = table.NewRow

                drRowNew.Item(Columns.item) = Trim(DOCUMENT_PATH)

                table.Rows.Add(drRowNew)


                dgvFileName.DataSource = table

                dgvFileName.AllowUserToAddRows = False

                '     txtAttachments.Text = Trim(DOCUMENT_PATH)

            Else
                dgvFileName.AllowUserToAddRows = False
                dgvFileName.ScrollBars = ScrollBars.None
            End If

            '   txtMessage.Text = vbCrLf & txtMessage.Text & vbCrLf & Today.Date
            txtCreate_TS.Text = Today.Date

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function Email(ByVal user As String) As String

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim strSql As String

        Email = ""

        strSql = _
                "Select * from user_permissions_info " & _
                " where user_name = '" & user & "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            Email = dt.Rows(0).Item("Email").ToString
        End If

        Return Email

    End Function

    Private Sub LoadLastDocumen(ByRef pProgram As cMdb_Cus_Prog)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim str As String

            Dim strSql = _
                "SELECT	    CUS_DOCUMENT_ID, DOC_TYPE_ID, CUS_NO, CUS_CONTACT_ID, " & _
                " DOCUMENT_DESC, DOCUMENT_PATH,DOCUMENT_DATA ,DOCUMENT_EXT, " & _
                " CUS_PROG_GUID, USER_LOGIN, CREATE_TS, UPDATE_TS " & _
                " FROM MDB_CUS_DOCUMENT D WITH (Nolock) " & _
                " WHERE		CUS_NO = '" & pProgram.Cus_No & "' AND CUS_PROG_GUID = '" & pProgram.Cus_Prog_Guid & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                DOCUMENT_PATH = dt.Rows(dt.Rows.Count - 1).Item("DOCUMENT_PATH").ToString
                DOCUMENT_DESC = dt.Rows(dt.Rows.Count - 1).Item("DOCUMENT_DESC").ToString
                str = DOCUMENT_PATH

                addFile(str, DOCUMENT_DESC, dt.Rows(dt.Rows.Count - 1))
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function EmailCust() As String

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim strSql As String
        Dim email As String = ""

        EmailCust = ""

        strSql = _
                " Select * from CiCntp " & _
                " where ID = " & contactId & " and cmp_wwn = '" & m_Customer.cmp_wwn & "' "

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then

            If dt.Rows(0).Item("cnt_email").ToString <> "" Then
                EmailCust = dt.Rows(0).Item("cnt_email").ToString
            Else
                EmailCust = m_Customer.cmp_e_mail
            End If
        Else
            EmailCust = m_Customer.cmp_e_mail
        End If

        Return EmailCust

    End Function

    Private Sub SendEmail()
        Try

            Dim oMessage As New cMailQuickP

            oMessage.FromAddr = Email(Environment.UserName)
            oMessage.ToAddr = Trim(txtEmailTo.Text)

            oMessage.CCAddr = Trim(txtCC.Text)

            oMessage.Subject = Trim(txtSubjectLine.Text)

            Dim strLineMes As String = "<html>"

            For i As Integer = 0 To txtMessage.Lines.Length - 1

                strLineMes &= txtMessage.Lines(i) & "<br />"

            Next

            strLineMes &= "<br /> <br /> <br />_____________________<br />"
            strLineMes &= Trim(User_FullName)
            strLineMes &= "<br />" & Trim(txtEmailFrom.Text)

            oMessage.Message = strLineMes & "</html>"

            Dim cpt As Integer = 0


            If dgvFileName.Rows.Count <> 0 Then
                For Each dRow As DataGridViewRow In dgvFileName.Rows
                    ReDim Preserve oMessage.Attach(dgvFileName.Rows.Count - 1)

                    If Trim(dRow.Cells(Columns.item).Value.ToString) <> "" Then

                        Debug.Print(dRow.Cells(Columns.item).Value.ToString)

                        oMessage.Attach(cpt) = dRow.Cells(Columns.item).Value.ToString

                        If dgvFileName.Rows.Count <> cpt - 1 Then cpt += 1

                    End If
                Next

            Else
                ReDim Preserve oMessage.Attach(dgvFileName.Rows.Count)
                oMessage.Attach(cpt) = ""
            End If

            oMessage.Send()
            If oMessage.SentSuccessful = True Then
                Call SaveEmail()
            End If
            
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub addFile(ByRef m_PathDirectory As String, ByRef m_PathFile As String, ByRef dr As DataRow)
        Try

            m_PathDirectory = m_PathDirectory.Remove(m_PathDirectory.LastIndexOf("\") + 1)

            If Not (Directory.Exists(m_PathDirectory)) Then
                'If Dir(m_Path, FileAttribute.Directory) = "" Then
                MkDir(m_PathDirectory)
            End If


            '/////////////////////////////
            'Get the document from the database and write it to a temp file
            Dim mStream As New ADODB.Stream
            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()
            mStream.Write(dr.Item("Document_Data")) '.Items("Document_Data"         
            mStream.SaveToFile(m_PathDirectory & m_PathFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub SaveEmail()

        Try
            mo_Email = New cExact_Traveler_Email_Message

            mo_Email.UserTo = Trim(txtCus_No.Text)
            mo_Email.EmailTo = Trim(txtEmailTo.Text)
            mo_Email.SubjectLine = Trim(txtSubjectLine.Text)
            mo_Email.Message = Trim(txtMessage.Text)
            mo_Email.EmailFrom = Environment.UserName
            mo_Email.Createdate = DateTime.Now
            mo_Email.SPECTOR_CD = m_Program.Spector_Cd
            mo_Email.FollowUp = "Y"
            mo_Email.Save()

      
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub
#End Region

    Private Sub cmdAtach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtach.Click
        Try

            Dim selectedFile As String = String.Empty
            Dim cpt As Integer = 0



            ' Pour afficher l'OpenFileDialog 
            Dim dr As DialogResult = Me.OpenFileDialog1.ShowDialog()

            If (dr = System.Windows.Forms.DialogResult.OK) Then

                dgvFileName.AllowUserToAddRows = True

                For Each file In OpenFileDialog1.FileNames

                    'dgvFileName.AllowUserToAddRows = True

                    drRowNew = table.NewRow

                    drRowNew.Item(Columns.item) = file.ToString

                    table.Rows.Add(drRowNew)

                    Debug.Print(file.ToString)

                    '  dgvFileName.AllowUserToAddRows = False

                    '     cpt += 1
                Next

                dgvFileName.DataSource = table
                ' Pour insérer l'emplacement du fichier choisi dans le TextBox 
                'selectedFile = OpenFileDialog1.FileName

                'If selectedFile IsNot Nothing Then
                '    txtAttachments.Text = selectedFile
                'End If

            End If

            dgvFileName.AllowUserToAddRows = False
        Catch ex As Exception
            MsgBox("Error in : " & Me.Name & ex.Message)
        End Try
    End Sub

    Private Sub FillRow(ByRef dgv1 As DataGridView, ByRef drRow As DataRow)
        dgv1.Rows(dgv1.Rows.Count - 1).Cells("item").Value = drRow.Item("item").ToString
      
        ' dgv1.AllowUserToAddRows = False
    End Sub

    Private Sub CreateColumn(ByRef dgv As DataGridView)

        Try
            column = New DataColumn()
            column.DataType = Type.GetType("System.String")
            column.ColumnName = "item"

            table.Columns.Add(column)

            dgv.ReadOnly = True
            dgv.DataSource = table
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            dgv.Columns(Columns.item).Width = 383
            'dgv.RowTemplate.MinimumHeight = 80
            dgv.RowTemplate.Height = 90
            dgv.RowHeadersVisible = False
            dgv.ColumnHeadersVisible = False

        Catch ex As Exception
            MsgBox("Error in : " & Me.Name & ex.Message)
        End Try

    End Sub

    Private Enum Columns
        item
    End Enum

    Private rowIndex As Integer = 0

    Private Sub dgvFileName_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFileName.CellMouseUp
        Try
            If e.Button = MouseButtons.Right Then

                Me.dgvFileName.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.dgvFileName.CurrentCell = Me.dgvFileName.Rows(e.RowIndex).Cells(Columns.item)
                Me.ContextMenuStrip1.Show(Me.dgvFileName, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)


            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub dgvFileName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFileName.KeyDown
        Try

            If e.KeyCode = Keys.Delete Then

                If File.Exists(dgvFileName.CurrentRow.Cells(Columns.item).Value.ToString()) Then
                    '  File.Delete(dgvFileName.CurrentRow.Cells(Columns.item).Value.ToString())
                End If

                dgvFileName.Rows.RemoveAt(dgvFileName.CurrentRow.Index)
                dgvFileName.Refresh()
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Not Me.dgvFileName.Rows(Me.rowIndex).IsNewRow Then
                Me.dgvFileName.Rows.RemoveAt(Me.rowIndex)
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub cmdCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCC.Click
        Try

            Dim frmEmailCont As New frmEmailContacts
            frmEmailCont.ShowDialog()


            '   txtCC.Text += frmEmailCont.email & ";"

            If Trim(frmEmailCont.email) <> "" Then
                txtCC.Text += frmEmailCont.email & ";"
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Class