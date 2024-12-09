Imports System.IO
Imports System.Text

Public Class frmPreviewDoc

    Public Sub New(ByVal pDocId As Int32)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Dim oExact_Traveler_Document As New cEXACT_TRAVELER_DOCUMENT(pDocId)

            oExact_Traveler_Document.PreviewDoc(oExact_Traveler_Document, webImage, panImg)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

End Class