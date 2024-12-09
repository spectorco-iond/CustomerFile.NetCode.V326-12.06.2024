Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml
Imports System.Globalization

Public Class cMdb_Cus_Document_BLL

    Public Sub AddDocumentFiles(ByVal pCus_No As String, ByVal pDoc_Type_ID As Integer, ByRef pFiles As String(), Optional pCus_Prog_Guid As String = "")

        Try

            'dgvDocuments.AllowUserToAddRows = True

            'panProgress.Visible = True

            'pbProgress.Value = 0
            'pbProgress.Maximum = Files.Length

            'txtPBEvent.Refresh()

            ' Loop through the array and add the files to the list.
            For Each strFile As String In pFiles

                'txtPBDocument.Text = strFile
                'txtPBDocument.Refresh()
                AddDocumentFile(pCus_No, pDoc_Type_ID, strFile, pCus_Prog_Guid)

                'Dim n As Integer = dgvDocuments.Rows.Add()
                'With dgvDocuments.Rows.Item(n)

                '    .Cells(Columns.CUS_DOCUMENT_ID).Value = oDocument.Cus_Document_Id
                '    .Cells(Columns.DOC_TYPE_ID).Value = oDocument.Cus_Document_Id
                '    .Cells(Columns.CUS_NO).Value = oDocument.Cus_No
                '    .Cells(Columns.CUS_CONTACT_ID).Value = oDocument.Cus_Contact_Id
                '    .Cells(Columns.MAIN_CUS_DOC_ID).Value = oDocument.Main_Cus_Doc_Id
                '    .Cells(Columns.CUS_PROG_GUID).Value = oDocument.Cus_Prog_Guid
                '    .Cells(Columns.USER_LOGIN).Value = oDocument.User_Login
                '    .Cells(Columns.CREATE_TS).Value = oDocument.Create_Ts
                '    .Cells(Columns.UPDATE_TS).Value = oDocument.Update_Ts

                'End With

                'pbProgress.Increment(1)
                'panProgress.Invalidate()

            Next

            'Call FillGrid()

            'dgvDocuments.AllowUserToAddRows = False

        Catch er As Exception
            MsgBox("Error in cMdb_Cus_Document_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            'panProgress.Visible = False
        End Try

    End Sub

    Public Sub AddDocumentFile(ByVal pCus_No As String, ByVal pDoc_Type_ID As Integer, ByVal pFile As String, Optional pCus_Prog_Guid As String = "")

        Try

            Dim oDocument As New cMdb_Cus_Document(pFile)
            oDocument.Cus_No = pCus_No
            oDocument.Cus_Prog_Guid = pCus_Prog_Guid
            oDocument.Doc_Type_Id = pDoc_Type_ID
            oDocument.Save()


        Catch er As Exception
            MsgBox("Error in cMdb_Cus_Document_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally
            'panProgress.Visible = False
        End Try

    End Sub


End Class
