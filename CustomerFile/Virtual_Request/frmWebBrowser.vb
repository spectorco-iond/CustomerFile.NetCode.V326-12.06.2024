'Imports System.Drawing.Printing

Public Class frmWebBrowser



    'Dim WithEvents mPrintDocument As New PrintDocument
    'Dim mPrintBitMap As Bitmap

    Private mHtml As String = ""
    Public Sub New(ByVal strHtml As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mHtml = strHtml
    End Sub

    Private Sub frmWebBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            '   webBrowser.Document.Write(mHtml)
            webBrowser.DocumentText = mHtml
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private d As CommonDialog
    Private Sub lblPrint_Click(sender As Object, e As EventArgs) Handles lblPrint.Click
        Try

            'work not properly
            'neeed revised


            'mPrintBitMap = New Bitmap(panWebBrowser.Width, panWebBrowser.Height)

            'Dim lRect As System.Drawing.Rectangle
            'lRect.Width = panWebBrowser.Width
            'lRect.Height = panWebBrowser.Height
            'Me.DrawToBitmap(mPrintBitMap, lRect)


            '' Make a PrintDocument and print.
            'mPrintDocument = New PrintDocument
            ''   mPrintDocument.PrinterSettings.LandscapeAngle =
            'mPrintDocument.Print()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Private Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles mPrintDocument.PrintPage
    '    '' Draw the image centered.
    '    'Dim lWidth As Integer = e.MarginBounds.X + (e.MarginBounds.Width - mPrintBitMap.Width) ' \ 2
    '    'Dim lHeight As Integer = e.MarginBounds.Y + (e.MarginBounds.Height - mPrintBitMap.Height) ' \ 2
    '    'e.Graphics.DrawImage(mPrintBitMap, lWidth, lHeight)


    '    '' There's only one page.
    '    'e.HasMorePages = False
    'End Sub

End Class