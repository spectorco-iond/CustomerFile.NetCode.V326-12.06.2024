Option Explicit On
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class modExportToExcel
 
    Dim db As New cDBA


    Public Sub DatatableToExcel(ByVal dtTemp As DataTable, ByVal strAddress As String, ByRef progressBar As Object, ByRef lab1 As Object)
        Try

            'ByRef progressBar As ToolStripProgressBar
            'ByRef lab1 As ToolStripLabel

            If dtTemp.Rows.Count = 0 Then Exit Sub

            Dim strFileName As String
            Dim colExcelProcessID As New Collection
            Dim MyExcelProcessID As Integer = 0

            Dim _excel As Excel.Application
            _excel = New Excel.Application

            Dim wBook As Excel.Workbook = Nothing
            Dim wSheet As Excel.Worksheet = Nothing
            Dim misValue As Object = System.Reflection.Missing.Value

            wBook = _excel.Workbooks.Add(misValue)

            wSheet = wBook.Sheets(1)

            Dim dt As System.Data.DataTable = dtTemp
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow

            Dim _rowsCount As Int32 = dt.Rows.Count
            Dim _percentfromLoad As Decimal = _rowsCount / 100

            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            '-------------



            progressBar.Visible = True
            '     progressBar.Style = ProgressBarStyle.Marquee

            progressBar.Maximum = dt.Rows.Count
            lab1.Visible = True
            lab1.Text = 0
            '-----------



            For Each dc In dt.Columns
                colIndex = colIndex + 1
                _excel.Cells(1, colIndex) = dc.ColumnName
            Next


            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
                '  lab1.Text = Decimal.Round((100 / progressBar.Maximum) * rowIndex) & " % wait excel file load."
                '  lab1.Text = "Loaded Rows : " & rowIndex.ToString & " from "
                lab1.Text = Math.Round(rowIndex / _percentfromLoad, 2) & " % "

                progressBar.Value = rowIndex
                'progressBar.Update()
                progressBar.PerformStep()
            Next

            wSheet.Columns.AutoFit()

            If Not Directory.Exists("C:\ExactTemp\") Then
                MkDir("C:\ExactTemp\")
            End If

            strFileName = strAddress

            wBook.SaveAs(strFileName)



            wBook.Close(True)
            _excel.Quit()

            progressBar.Visible = False
            lab1.Visible = False


        Catch er As Exception
            MsgBox("Error in DatatableToExcel." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        Finally

            progressBar.Visible = False
            lab1.Visible = False
        End Try
    End Sub
    Public Sub DatatableToExcel2(ByVal dtTemp As DataTable, ByVal strAddress As String, ByRef progressBar As ToolStripProgressBar, ByRef lab1 As ToolStripLabel)
        Try

            Dim strFileName As String
            Dim colExcelProcessID As New Collection
            Dim MyExcelProcessID As Integer = 0

            Dim _excel As Excel.Application
            _excel = New Excel.Application

            Dim wBook As Excel.Workbook = Nothing
            Dim wSheet As Excel.Worksheet = Nothing
            Dim misValue As Object = System.Reflection.Missing.Value

            wBook = _excel.Workbooks.Add(misValue)

            wSheet = wBook.Sheets(1)

            Dim dt As System.Data.DataTable = dtTemp
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow

            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            '-------------
            progressBar.Visible = True
            '     progressBar.Style = ProgressBarStyle.Marquee

            progressBar.Maximum = dt.Rows.Count
            lab1.Visible = True
            lab1.Text = 0
            '-----------



            For Each dc In dt.Columns
                colIndex = colIndex + 1
                _excel.Cells(1, colIndex) = dc.ColumnName
            Next


            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
                lab1.Text = Decimal.Round((100 / progressBar.Maximum) * rowIndex) & " % wait excel file load."
                progressBar.Value = rowIndex
                'progressBar.Update()
                progressBar.PerformStep()
            Next

            wSheet.Columns.AutoFit()

            If Not Directory.Exists("C:\ExactTemp\") Then
                MkDir("C:\ExactTemp\")
            End If

            strFileName = strAddress

            wBook.SaveAs(strFileName)



            wBook.Close(True)
            _excel.Quit()

            progressBar.Visible = False
            lab1.Visible = False
        Catch er As Exception
            MsgBox("Error in DatatableToExcel." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Public Sub DatatableToExcel1(ByVal dtTemp As DataTable, ByVal strAddress As String, ByRef progressBar As Object, ByRef lab1 As Object)
        Try

            'ByRef progressBar As ToolStripProgressBar
            'ByRef lab1 As ToolStripLabel

            If dtTemp Is Nothing Then Exit Sub

            Dim strFileName As String
            Dim colExcelProcessID As New Collection
            Dim MyExcelProcessID As Integer = 0

            Dim _excel As Excel.Application
            _excel = New Excel.Application

            Dim wBook As Excel.Workbook = Nothing
            Dim wSheet As Excel.Worksheet = Nothing
            Dim misValue As Object = System.Reflection.Missing.Value

            wBook = _excel.Workbooks.Add(misValue)

            wSheet = wBook.Sheets(1)

            Dim dt As System.Data.DataTable = dtTemp
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow

            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            '-------------
            progressBar.Visible = True
            '     progressBar.Style = ProgressBarStyle.Marquee

            progressBar.Maximum = dt.Rows.Count
            lab1.Visible = True
            lab1.Text = 0
            '-----------

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                _excel.Cells(1, colIndex) = dc.ColumnName
            Next


            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next

                lab1.Text = Decimal.Round((100 / progressBar.Maximum) * rowIndex) & " % wait excel file load."
                progressBar.Value = rowIndex
                'progressBar.Update()
                progressBar.PerformStep()
            Next

            wSheet.Columns.AutoFit()

            If Not Directory.Exists("C:\ExactTemp\") Then
                MkDir("C:\ExactTemp\")
            End If

            strFileName = strAddress

            wBook.SaveAs(strFileName)



            wBook.Close(True)
            _excel.Quit()

            progressBar.Visible = False
            lab1.Visible = False
        Catch er As Exception
            MsgBox("Error in DatatableToExcel." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
End Class
