Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Text

Public Class frmDocumentView

    Private m_Document As New cMdb_Cus_Document
    Private m_Path As String = "c:\ExactTemp\"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal iDocument_ID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Document = New cMdb_Cus_Document(iDocument_ID)
        Call PreviewDoc()

    End Sub

    Public Sub New(ByRef oDocument As cMdb_Cus_Document)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_Document = oDocument
        Call PreviewDoc()

    End Sub

    Private Sub frmDocumentView_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Call Save()

    End Sub

    Private Sub frmDocumentView_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If m_Document Is Nothing Then
            m_Document = New cMdb_Cus_Document
        End If

        With m_Document

            txtDoc_Type_ID.Text = .Doc_Type_Id
            txtCus_No.Text = .Cus_No
            txtCus_Contact_ID.Text = .Cus_Contact_Id
            txtMain_Cus_Doc_ID.Text = .Main_Cus_Doc_Id
            txtDocument_Desc.Text = .Document_Desc
            txtDocument_Path.Text = .Document_Path
            txtDocument_Ext.Text = .Document_Ext

        End With

    End Sub

    Private Sub Save()

        If m_Document Is Nothing Then
            m_Document = New cMdb_Cus_Document
        End If

        With m_Document

            .Doc_Type_Id = txtDoc_Type_ID.Text
            .Cus_No = txtCus_No.Text
            .Cus_Contact_Id = txtCus_Contact_ID.Text
            .Main_Cus_Doc_Id = txtMain_Cus_Doc_ID.Text
            .Document_Desc = txtDocument_Desc.Text
            .Document_Path = txtDocument_Path.Text
            .Document_Ext = txtDocument_Ext.Text

            .Save()

        End With

    End Sub

    Private Sub PreviewDoc()

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String

        Try

            If m_Document Is Nothing Then Exit Sub

            Dim strPathAndFile As String
            'Dim strPathAndFile As String = gPath & m_Document.DocFile
            If m_Document.Cus_Document_Id <> 0 Then
                If Trim(m_Document.DocFile) = "" Then
                    strPathAndFile = m_Path & m_Document.Cus_Document_Id
                Else
                    strPathAndFile = m_Path & m_Document.DocFile
                End If

            Else
                strPathAndFile = m_Path & m_Document.DocFile ' Name
            End If

            'Dim strPathAndFile As String = gPath & m_Document.DocFile ' Name

            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Not (Directory.Exists(m_Path)) Then
                'If Dir(m_Path, FileAttribute.Directory) = "" Then
                MkDir(m_Path)
            End If

            '/////////////////////////////
            'Get the document from the database and write it to a temp file
            Dim mStream As New ADODB.Stream
            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()
            mStream.Write(m_Document.GetDocumentRow.Item("Document_Data"))
            If m_Document.Cus_Document_Id <> 0 Then
                'mStream.Write(m_Document.GetDocumentRow.Item("Document"))
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            Else
                'mStream.Write(m_Document.GetDocumentImage())
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            End If

            'mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            '////////////////////////////////
            'Show the file
            Select Case Mid(strPathAndFile.ToUpper, strPathAndFile.Length - 3)

                Case ".MSG", ".XLS", "XLSX", ".DOC", "DOCX", ".BMP"
                    pnlPreviewDoc.Visible = False

                Case Else
                    pnlPreviewDoc.Visible = True

            End Select

            wbShowFile.Navigate(strPathAndFile, False) ', True) '1 = NewWindow


            'wbShowFile.Navigate(New System.Uri(strPathAndFile), True) '1 = NewWindow

            'End If

        Catch er As Exception
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try

    End Sub

End Class