Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO

Public Class c_PDF

    Dim oHeaderInfo As cHeaderInfo
    Dim db As cDBA
    Dim oItem_Pict As cItem_Pictures
    Dim oContentInfo As cContentInfo


    'Public Sub New(ByRef o_SwitchLang As c_SwitchLang, ByVal p_Spector_Cd As String, ByRef pan As Panel, ByRef label1 As Label)
    Public Sub New(ByRef o_SwitchLang As c_SwitchLang, ByVal p_Spector_Cd As String, ByVal p_Program_Type As String)
        Call Document_Create_PDF(o_SwitchLang, p_Spector_Cd, p_Program_Type)
    End Sub
    Public Sub New(ByVal lang As String)

    End Sub

    'Private Sub Document_Create_PDF(ByRef o_SwitchLang As c_SwitchLang, ByVal p_Spector_Cd As String, ByRef pan As Panel, ByRef label1 As Label)
    Private Sub Document_Create_PDF(ByRef o_SwitchLang As c_SwitchLang, ByVal p_Spector_Cd As String, ByVal p_Program_Type As String)
        Dim errPos As Integer
        Dim iCurrentRow As Integer = 0
        Dim colExcelProcessID As New Collection
        Dim MyExcelProcessID As Integer = 0
        Dim msExcelProcesses As Process() = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                colExcelProcessID.Add(oProcess.Id.ToString, oProcess.Id.ToString)
            Next
        End If

        errPos = 1
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application

        msExcelProcesses = Process.GetProcessesByName("Excel")

        'Get all currently running process Ids for Excel applications
        If msExcelProcesses.Length > 0 Then
            For Each oProcess As Process In msExcelProcesses
                If Not (colExcelProcessID.Contains(oProcess.Id.ToString)) Then MyExcelProcessID = oProcess.Id
            Next
        End If

        errPos = 2
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing

        Dim misValue As Object = System.Reflection.Missing.Value
        errPos = 3

        Try
            db = New cDBA
            Dim o_Excel_Function As New c_Excel_Function

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            errPos = 4
            xlWorkBook.Styles("Normal").Font.Name = "Tahoma"
            errPos = 5
            'xlWorkBook.Styles.Font.Size = 7
            errPos = 7
            xlWorkSheet = xlWorkBook.Sheets(1)

            xlWorkBook.Activate()
            xlWorkSheet.Activate()
            errPos = 7.1

            Dim ret = o_SwitchLang.PROG_QUOTE

            With xlWorkSheet
                errPos = 8
                .Range("A:A").ColumnWidth = 0.5
                .Range("B:B").ColumnWidth = 5.86
                .Range("C:C").ColumnWidth = 4.14

                .Range("D:D").ColumnWidth = 2.14
                .Range("E:E").ColumnWidth = 2.14
                .Range("F:F").ColumnWidth = 2.14

                .Range("G:G").ColumnWidth = 2.75
                .Range("H:H").ColumnWidth = 3.38

                .Range("I:I").ColumnWidth = 4.25 '
                .Range("J:J").ColumnWidth = 3.13
                .Range("K:K").ColumnWidth = 6.25
                .Range("L:L").ColumnWidth = 6.13

                .Range("M:M").ColumnWidth = 7.5 '
                .Range("N:N").ColumnWidth = 7.5
                .Range("O:O").ColumnWidth = 7.5
                .Range("P:P").ColumnWidth = 7.5
                '---------------------Header Information-------------------------
                errPos = 9
                oHeaderInfo = New cHeaderInfo(p_Spector_Cd)
                Call Layout_Header(iCurrentRow, xlWorkSheet, oHeaderInfo, o_SwitchLang, p_Program_Type, errPos) 'errPos finnished 26
                Call Layout_Body(iCurrentRow, xlWorkSheet, errPos)

                '-------Footer--------we need take 9 line (2 = 8.25 for COMMENTS Title and 7 = 9 for the message)-------
                'Footer(iCurrentRow, xlWorkSheet, oHeaderInfo, o_SwitchLang, errPos)
                Dim cnt As Int32 = 0

                '-------------------Content Info--------------------------------7/3
                oContentInfo = New cContentInfo(p_Spector_Cd)

                Dim dtFirst As DataTable = oContentInfo.First_Etape
                Dim rowIndex As Int32 = 0
                Dim windows As New Windows.Forms.Form
                Dim progBar1 As New ProgressBar

                Dim if_last_page As Int32 = 0


                '    windows.Controls.Add(progBar1)

                progBar1.Name = "progBar"
                progBar1.Visible = True
                progBar1.Location = New System.Drawing.Point(0, 29)
                progBar1.Width = 237
                progBar1.Height = 23
                progBar1.Value = 0

                'pan.Controls.Add(progBar1)
                progBar1.Maximum = dtFirst.Rows.Count
                If dtFirst.Rows.Count <= 3 Then
                    if_last_page = 1
                End If
                Call Footer(iCurrentRow, xlWorkSheet, oHeaderInfo, o_SwitchLang, p_Program_Type, errPos, if_last_page) 'errPos finnished 26

                For Each dtContentInf As DataRow In dtFirst.Rows

                    '      rowIndex = rowIndex + 1
                    '----------This part is for second page------------------------
                    If cnt > 2 Then
                        If cnt Mod 3 = 0 Then
                            If cnt = dtFirst.Rows.Count - 1 Then
                                if_last_page = 1
                            End If
                            iCurrentRow += 9
                            Call Layout_Header(iCurrentRow, xlWorkSheet, oHeaderInfo, o_SwitchLang, p_Program_Type, errPos) 'errPos finnished 26
                            Call Layout_Body(iCurrentRow, xlWorkSheet, errPos)
                            Call Footer(iCurrentRow, xlWorkSheet, oHeaderInfo, o_SwitchLang, p_Program_Type, errPos, if_last_page) 'errPos finnished 26
                        End If
                        End If


                    '----------------------------------
                    'iCurrentRow += 1 '17  
                    iCurrentRow += 2 '18  

                    '   .Range("A" & iCurrentRow.ToString).RowHeight = 8.25

                    o_Excel_Function.SetColorInterior(.Range("A" & iCurrentRow.ToString & ":A" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbDarkKhaki)

                    errPos = 27                                        '18                             -18
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbLightSlateGray)

                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString), o_SwitchLang.CODE, False, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)
                    'value code C : F - 18

                    'justin-b-190423 change
                    'o_Excel_Function.SetStyleNormal(.Range("C" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), Remove_Space(dtContentInf.Item("ITEM_CD").ToString) & "-" & oContentInfo.Return_Items(Remove_Space(dtContentInf.Item("ITEM_CD").ToString)), True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)
                    'to 
                    o_Excel_Function.SetStyleNormal(.Range("C" & iCurrentRow.ToString & ":G" & iCurrentRow.ToString), Remove_Space(dtContentInf.Item("ITEM_CD").ToString) & "-" & Remove_Space(dtContentInf.Item("ITEM_NO").ToString), True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)
                    'justin-e
                    errPos = 28

                    o_Excel_Function.SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), o_SwitchLang.COLOR, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)

                    'value color J : N - 18
                    'for execute Wrap function

                    'justin-b-190423 change
                    o_Excel_Function.SetStyleNormal(.Range("J" & iCurrentRow.ToString & ":P" & (iCurrentRow + 1).ToString), Remove_Space(dtContentInf.Item("ITEM_COLOR").ToString), True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, 7, True, Excel.XlRgbColor.rgbWhite)
                    'justin-e-190423 

                    errPos = 29
                    iCurrentRow += 1 '19

                    'value B : K 19
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), Remove_Space(dtContentInf.Item("ITEM_DESC").ToString), True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)

                    errPos = 29.1
                    iCurrentRow += 1 '20
                    'o_Excel_Function.BorderStyle(.Range("M" & iCurrentRow.ToString & ":M" & (iCurrentRow + 8).ToString), False, Excel.XlBordersIndex.xlEdgeLeft)
                    o_Excel_Function.BorderStyle(.Range("K" & iCurrentRow.ToString & ":K" & (iCurrentRow + 8).ToString), False, Excel.XlBordersIndex.xlEdgeLeft)
                    '20
                    o_Excel_Function.SetStyleNormal(.Range("I" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), o_SwitchLang.COMMENT, True, Excel.XlHAlign.xlHAlignRight)

                    ' DisplayI_COMMENT
                    Call DisplayI_COMMENT(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, p_Program_Type, errPos)

                    'put picture
                    'justin-b-190506 change
                    'close display pic on 20190515 by justin
                    'If dtContentInf.Item("DOCID") = 0 Then
                    '   oItem_Pict = New cItem_Pictures(Remove_Space(dtContentInf.Item("ITEM_NO").ToString))
                    '   o_Excel_Function.LOGO_PATH = oItem_Pict.SaveFileToPath()
                    'Else
                    '   'Dim oExact_Traveler_Document As New cEXACT_TRAVELER_DOCUMENT(dtContentInf.Item("DOCID"))
                    '   o_Excel_Function.LOGO_PATH = oExact_Traveler_Document.SaveFileToPath()
                    'End If

                    'justin_e-190423

                    'o_Excel_Function.SetImage(xlWorkSheet, .Range("A" & iCurrentRow.ToString & ":G" & (iCurrentRow + 14).ToString), True, o_Excel_Function.LOGO_PATH, 130)
                    errPos = 30
                    '21
                    ' .Range("A" & (iCurrentRow + 1).ToString).RowHeight = 9
                    'o_Excel_Function.SetColorInterior(.Range("H" & (iCurrentRow + 1).ToString & ":L" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 1).ToString & ":H" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    'o_Excel_Function.SetStyleNormal(.Range("H" & (iCurrentRow + 1).ToString & ":J" & (iCurrentRow + 1).ToString), o_SwitchLang.DECORATION, True)
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 1).ToString & ":C" & (iCurrentRow + 1).ToString), o_SwitchLang.DECORATION, True)
                    'data value
                    'kl
                    o_Excel_Function.SetStyleNormal(.Range("D" & (iCurrentRow + 1).ToString & ":H" & (iCurrentRow + 1).ToString), oContentInfo.Return_Decorat(dtContentInf.Item("DEC_MET_ID")), True)
                    errPos = 31
                    '22
                    ' .Range("A" & (iCurrentRow + 2).ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 2).ToString & ":H" & (iCurrentRow + 2).ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 2).ToString & ":C" & (iCurrentRow + 2).ToString), o_SwitchLang.PACKAGING, True)
                    'data value
                    o_Excel_Function.SetStyleNormal(.Range("D" & (iCurrentRow + 2).ToString & ":H" & (iCurrentRow + 2).ToString), oContentInfo.Return_Pack(dtContentInf.Item("PACK_ID")), True)

                    errPos = 32
                    '23
                    '  .Range("A" & (iCurrentRow + 3).ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 3).ToString & ":H" & (iCurrentRow + 3).ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 3).ToString & ":C" & (iCurrentRow + 3).ToString), o_SwitchLang.SHIPPING, True)
                    'data value
                    'justin20190424_b_chenge 
                    'o_Excel_Function.SetStyleNormal(.Range("K" & (iCurrentRow + 3).ToString & ":L" & (iCurrentRow + 3).ToString), oContentInfo.Return_Pack(dtContentInf.Item("QUOTE_SHIP_METHOD_ID")), True)
                    'to
                    o_Excel_Function.SetStyleNormal(.Range("D" & (iCurrentRow + 3).ToString & ":H" & (iCurrentRow + 3).ToString), oContentInfo.Return_Quote_Ship_Method(dtContentInf.Item("QUOTE_SHIP_METHOD_ID")), True)
                    'justin20190424_e_chenge 
                    errPos = 33
                    '24
                    ' .Range("A" & (iCurrentRow + 4).ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 4).ToString & ":H" & (iCurrentRow + 4).ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 4).ToString & ":C" & (iCurrentRow + 4).ToString), o_SwitchLang.TYPE, True)
                    'data value
                    o_Excel_Function.SetStyleNormal(.Range("D" & (iCurrentRow + 4).ToString & ":H" & (iCurrentRow + 4).ToString), oContentInfo.Return_Type(dtContentInf.Item("QUOTE_TYPE_ID")), True)

                    errPos = 34
                    '25
                    '  .Range("A" & (iCurrentRow + 5).ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 5).ToString & ":H" & (iCurrentRow + 5).ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 5).ToString & ":C" & (iCurrentRow + 5).ToString), o_SwitchLang.SETUP, True)
                    'data value
                    o_Excel_Function.SetStyleNormal(.Range("D" & (iCurrentRow + 5).ToString & ":H" & (iCurrentRow + 5).ToString), Remove_Space(dtContentInf.Item("SETUP").ToString), True)

                    'until now iCurrentRow is = 19 because incrise has been virtual, has not assigned
                    '--------------------Place for Comments--------------------
                    'M19:P26

                    '----------------------------------------------------------
                    '19 + 8 = 27
                    iCurrentRow += 8
                    errPos = 35
                    '28 PRICING
                    '  .Range("A" & iCurrentRow.ToString).RowHeight = 12
                    'o_Excel_Function.SetColorInterior(.Range("H" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbGold) 'rgbDarkKhaki rgbPaleGoldenrod,rgbGoldenrod rgbPaleGoldenrod rgbGold
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbGold) 'rgbDarkKhaki rgbPaleGoldenrod,rgbGoldenrod rgbPaleGoldenrod rgbGold
                    'o_Excel_Function.SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), o_SwitchLang.PRICING, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), o_SwitchLang.PRICING, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbWhite)

                    '29
                    iCurrentRow += 1
                    '   .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    'o_Excel_Function.SetColorInterior(.Range("H" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    'justin 20190515
                    'o_Excel_Function.SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), o_SwitchLang.EQP, True)
                    'data

                    'justin 20150515 close EQP
                    'Call DisplayEQP(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 36

                    '30
                    iCurrentRow += 1
                    '  .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    'o_Excel_Function.SetColorInterior(.Range("H" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    'o_Excel_Function.SetStyleNormal(.Range("H" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), o_SwitchLang.QUANTITY, True)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), o_SwitchLang.QUANTITY, True)
                    'data

                    Call DisplayQTY(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 36

                    '30
                    iCurrentRow += 1
                    '  .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), o_SwitchLang.PRICE, True)
                    'data PRIX
                    Call DisplayPRIX(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 37

                    '31
                    iCurrentRow += 1


                    ' .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), o_SwitchLang.SETUP_PRICE, True)
                    'data 32
                    Call DisplaySetup_Price(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 40



                    '33
                    iCurrentRow += 1
                    '   .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbWhiteSmoke)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), o_SwitchLang.RUN_CHARGE, True)
                    'data
                    Call DisplayRun_Charge(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 39

                    '33
                    iCurrentRow += 1
                    '34
                    '  .Range("A" & iCurrentRow.ToString).RowHeight = 9
                    o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString).Cells.Interior, Excel.XlRgbColor.rgbLightGray)
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":F" & iCurrentRow.ToString), o_SwitchLang.SUBTOTAL, True)
                    Call DisplayTOTAL(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, cnt, errPos) 'errPos = 39
                    'data is plced in functon DisplayPRIX()



                    '-------------
                    ' iCurrentRow += 14
                    progBar1.Value = cnt + 1
                    'label1.Text = Decimal.Round((100 / progBar1.Maximum) * (cnt + 1)) & " % wait PDF file load."
                    progBar1.Update()
                    cnt += 1
                Next
                '------------------------------Finnish Content---------------------------------
            End With
            errPos = 27
            xlApp.PrintCommunication = False
            '------------------------------------------------
            'this is for identify gounique or spector logo, by edward criteria
            'prepare properties for display picture header 
            oItem_Pict = New cItem_Pictures

            If Environment.UserName = "edward" Then
                oItem_Pict = New cItem_Pictures("GOUNIQUE-LOGO")
                o_Excel_Function.LOGO_PATH = oItem_Pict.SaveFileToPath()
                o_Excel_Function.LOGO_WIDTH = 80
            Else
                oItem_Pict = New cItem_Pictures("00SPECTOR")
                o_Excel_Function.LOGO_PATH = oItem_Pict.SaveFileToPath()
                o_Excel_Function.LOGO_WIDTH = 290
            End If
            errPos = 28

            '------------------------------------------------

            xlApp.PrintCommunication = True
            '     xlWorkSheet.PageSetup.PrintArea = "A1:P" & (iCurrentRow + 17).ToString

            'this function work if LOGO_PATH is declared
            o_Excel_Function.SetPrintingProperties(xlWorkBook.Sheets(1))

            xlApp.PrintCommunication = True

            'xlApp.Visible = True '--- 1

            '++ID 19.1.15 'justin 20190823
            Dim strPath As String = "c:\PDF_new_export\"

            If Not (Directory.Exists(strPath)) Then
                MkDir(strPath)
            End If

            'Dim strFileName As String = strPath & "Program confirmation " & oHeaderInfo.SPECTOR_CD & Format(Now, "hhmmss") & ".PDF"
            Dim strFileName As String = strPath & p_Program_Type & "_" & oHeaderInfo.SPECTOR_CD & Format(Now, "hhmmss") & ".PDF"

            If File.Exists(strFileName) Then
                File.Delete(strFileName)
                Debug.Print("Deleted file name :" & strFileName)
            End If
            xlApp.PrintCommunication = False
            o_Excel_Function.SetPrintingProperties(xlWorkSheet)
            xlApp.PrintCommunication = True
            xlWorkBook.Sheets(1).ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, strFileName)
            xlApp = Nothing '---2
            'xlApp.Quit() ??
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strFileName
            Process.Start(startInfo)

        Catch ex As Exception
            MsgBox("Error in pdf." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        Finally
            Try
                xlWorkBook.Close(False) '---3
            Catch ex As Exception
            Finally

                'xlWorkBook = Nothing
                Debug.Print("CLOSE EXCEL PROCESS " & MyExcelProcessID.ToString)
                Dim myExcelProcess As Process = Process.GetProcessById(MyExcelProcessID)
                myExcelProcess.Kill() '---4

            End Try
        End Try
    End Sub

    Private Sub Layout_Header(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oHeaderInfo As cHeaderInfo, ByRef o_SwitchLang As c_SwitchLang, ByVal p_Program_Type As String, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function

            With xlWorkSheet
                iCurrentRow += 1 '1                                                             '2
                o_Excel_Function.SetColorInterior(.Range("B" & iCurrentRow.ToString & ":P" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbLightSlateGray)
                errPos = 10
                o_Excel_Function.SetColorInterior(.Range("A" & iCurrentRow.ToString & ":A" & (iCurrentRow + 1).ToString).Cells.Interior, Excel.XlRgbColor.rgbDarkKhaki)
                ' 1
                .Range("A" & iCurrentRow.ToString).RowHeight = 8.25
                ' 2
                .Range("A" & (iCurrentRow + 1).ToString).RowHeight = 8.25
                errPos = 11
                o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":E" & (iCurrentRow + 1).ToString), "N:#" & oHeaderInfo.SPECTOR_CD, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, 9, True, Excel.XlRgbColor.rgbWhite)
                errPos = 12
                If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("F" & iCurrentRow.ToString & ":O" & (iCurrentRow + 1).ToString), o_SwitchLang.PROG_PROGRAM, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 9, True, Excel.XlRgbColor.rgbWhite)
                End If
                If p_Program_Type = "Quote" Then
                    o_Excel_Function.SetStyleNormal(.Range("F" & iCurrentRow.ToString & ":O" & (iCurrentRow + 1).ToString), o_SwitchLang.PROG_QUOTE, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 9, True, Excel.XlRgbColor.rgbWhite)
                End If

                iCurrentRow += 1 + 1 '3 empty line
                .Range("A" & iCurrentRow.ToString).RowHeight = 1.5
                errPos = 13
                iCurrentRow += 1 '4
                'header text  .. Thank you .... or remercie
                .Range("A" & iCurrentRow.ToString).RowHeight = 27

                If p_Program_Type = "Program" Then
                    'justin changed from d->o to b->p
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), o_SwitchLang.HEADER_MESS_PROG, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbBlack, True)
                End If
                If p_Program_Type = "Quote" Then
                    'justin changed from d->o to b->p
                    o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), o_SwitchLang.HEADER_MESS_QUOTE, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbBlack, True)
                End If

                errPos = 14
                iCurrentRow += 1 '5 empty line
                .Range("A" & iCurrentRow.ToString).RowHeight = 0 '8.25

                'begin customer and program information .May be we can make a function like layout
                '----------------------------------------------------------------
                errPos = 15
                iCurrentRow += 1 ' 6  
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), o_SwitchLang.CUSTOMER, True)
                'place for data
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CMP_NAME, True)
                'right side
                errPos = 16
                If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.PROGRAM, True)
                    o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.CUS_PROG_CD, True)
                End If
                If p_Program_Type = "Quote" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.QUOTE, True)
                    o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.CUS_PROG_CD, True)
                End If
                'place for data


                errPos = 17
                iCurrentRow += 1 ' 7 
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), o_SwitchLang.ADDRESS, True)
                'place for data
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CMP_FADD1, True)
                'Right side
                errPos = 18
                If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.PROGRAM_DATE, True)
                    o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), CDate(oHeaderInfo.CREATE_TS), True)
                End If
                If p_Program_Type = "Quote" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.QUOTE_DATE, True)
                    o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), CDate(oHeaderInfo.CREATE_TS), True)
                End If
                'place for data


                iCurrentRow += 1 ' 8 
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 19
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CMP_FADD2, True)
                o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.IMPRINT, True)
                o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.IMPRINT, True)

                iCurrentRow += 1 ' 9
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 20
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CMP_FADD3, True)
                If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), o_SwitchLang.PROG_START_DATE, True)
                End If
                If p_Program_Type = "Quote" Then
                    'justin 20190515
                    '    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), o_SwitchLang.QUOTE_START_DATE, True)
                End If

                'place for data
                'close 20190515 by justin
                'o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.START_DT, True)

                iCurrentRow += 1 ' 10
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 21
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CITY_CODE, True)
                If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.PROG_END_DATE, True)
                End If
                If p_Program_Type = "Quote" Then
                    o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.QUOTE_END_DATE, True)
                End If

                'place for data
                o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.END_DT, True)

                iCurrentRow += 1 ' 11
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.COUNTRY, True) '"United state of America"
                iCurrentRow += 1 '12
                .Range("A" & iCurrentRow.ToString).RowHeight = 1 '6.75
                iCurrentRow += 1 ' 13
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 22
                o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), o_SwitchLang.CONTACT, True)
                'place for data need make function for display conact name
                o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CNT_FULLNAME, True)

                iCurrentRow += 1 '14
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 23
                'close 20190515 by justin
                'o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), o_SwitchLang.PHONE, True)
                'place for data PHONE 
                'o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CNT_TEL, True)
                ' 14
                errPos = 24
                o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.SPECTOR_CONTACT, True)
                'place for data
                o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.SPECTOR_CONTATCT, True)
                iCurrentRow += 1 '15
                .Range("A" & iCurrentRow.ToString).RowHeight = 9.75
                errPos = 25
                'close 20190515 by justin
                'o_Excel_Function.SetStyleNormal(.Range("B" & iCurrentRow.ToString & ":C" & iCurrentRow.ToString), o_SwitchLang.EMAIL, True)
                'place for data
                'o_Excel_Function.SetStyleNormal(.Range("D" & iCurrentRow.ToString & ":I" & iCurrentRow.ToString), oHeaderInfo.CNT_EMAIL, True)
                ' 15
                errPos = 26
                o_Excel_Function.SetStyleNormal(.Range("L" & iCurrentRow.ToString & ":M" & iCurrentRow.ToString), o_SwitchLang.SPECTOR_EMAIL, True)
                'place for data
                o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), oHeaderInfo.SPECTOR_EMAIL, True)
                iCurrentRow += 1 '16
                .Range("A" & iCurrentRow.ToString).RowHeight = 0

            End With

        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub
    Private Sub Layout_Body(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef errPos As Integer)
        Try
            Dim pCurrentRow As Int32
            errPos = 100
            pCurrentRow = iCurrentRow

            Dim o_Excel_Function As New c_Excel_Function

            With xlWorkSheet
                For i As Int32 = 0 To 2
                    pCurrentRow += 1 '17  
                    .Range("A" & pCurrentRow.ToString).RowHeight = 8.25 '17
                    pCurrentRow += 1 '18 
                    .Range("A" & pCurrentRow.ToString).RowHeight = 8.25 '18
                    pCurrentRow += 1 '19
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '19
                    pCurrentRow += 1 '20
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '20
                    pCurrentRow += 1 '21
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '21
                    pCurrentRow += 1 '22
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '22
                    pCurrentRow += 1 '23
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '23
                    pCurrentRow += 1 '24
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '24
                    pCurrentRow += 1 '25
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '25
                    pCurrentRow += 1 '26
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '26
                    pCurrentRow += 1 '27
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '27
                    pCurrentRow += 1 '28
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '28  'from 9 to 0 on 20190515 by justin
                    pCurrentRow += 1 '29
                    .Range("A" & pCurrentRow.ToString).RowHeight = 0 '29 '9 TO 0 20190517
                    pCurrentRow += 1 '30
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '30
                    pCurrentRow += 1 '31
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '31
                    pCurrentRow += 1 '32
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '32
                    pCurrentRow += 1 '33
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '33
                    pCurrentRow += 1 '34 --JUSTIN0517
                    .Range("A" & pCurrentRow.ToString).RowHeight = 9 '34

                Next i
            End With

        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub
    Private Sub Footer(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oHeaderInfo As cHeaderInfo, ByRef o_SwitchLang As c_SwitchLang, ByVal p_Program_Type As String, ByRef errPos As Integer, ByVal if_last_pag As Integer)
        Try

            Dim o_Excel_Function As New c_Excel_Function

           ' If if_last_pag = 0 Then
                With xlWorkSheet
                    o_Excel_Function.SetColorInterior(.Range("A" & (iCurrentRow + 56).ToString & ":A" & (iCurrentRow + 57).ToString).Cells.Interior, Excel.XlRgbColor.rgbDarkKhaki)
                    errPos = 27
                    If p_Program_Type = "Quote" Then
                        o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 56).ToString & ":P" & (iCurrentRow + 57).ToString), o_SwitchLang.FOODER_MESS_QUOTE, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbBlack, True)
                    End If
                    If p_Program_Type = "Program" Then
                    o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 56).ToString & ":P" & (iCurrentRow + 57).ToString), o_SwitchLang.FOODER_MESS_PROG, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 7, True, Excel.XlRgbColor.rgbBlack, True)
                End If
                End With
            'End If
            errPos = 35
            If if_last_pag = 1 Then
                Call DisplayCOMMENT(iCurrentRow, xlWorkSheet, oContentInfo, o_SwitchLang, p_Program_Type, errPos)
            End If


            With xlWorkSheet
                .Range("A" & (iCurrentRow + 55).ToString).RowHeight = 2.25 '71  8.25 to 5.25
                .Range("A" & (iCurrentRow + 56).ToString).RowHeight = 25 '72 
                .Range("A" & (iCurrentRow + 57).ToString).RowHeight = 15 '73 9
                .Range("A" & (iCurrentRow + 58).ToString).RowHeight = 10.5 '74
                .Range("A" & (iCurrentRow + 59).ToString).RowHeight = 10.5 '75
                .Range("A" & (iCurrentRow + 60).ToString).RowHeight = 10.5 '76
                .Range("A" & (iCurrentRow + 61).ToString).RowHeight = 10.5 '77 
                .Range("A" & (iCurrentRow + 62).ToString).RowHeight = 10.5 '78 
                .Range("A" & (iCurrentRow + 63).ToString).RowHeight = 10 '79 -20190517                '

                .PageSetup.PrintArea = "A1:P" & (iCurrentRow + 63).ToString

            End With

        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub



    Private Sub DisplayI_COMMENT(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByVal p_Program_Type As String, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtIcomment As DataTable = oContentInfo.I_COMMENT(cnt, p_Program_Type, o_SwitchLang)
            Dim rint As Int32 = 1

            'dtIcomment.
            If Not IsNothing(dtIcomment) Then
                With xlWorkSheet
                    For Each dr As DataRow In dtIcomment.Rows
                        If rint > 16 Then Exit Sub
                        If rint <= 8 Then
                            'o_Excel_Function.SetStyleNormal(.Range("M" & (iCurrentRow + rint - 1).ToString & ":N" & (iCurrentRow + rint - 1).ToString), dr.Item("MESSAGE_DESC").ToString, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, 7, False, Excel.XlRgbColor.rgbBlack, True)
                            o_Excel_Function.SetStyleNormal(.Range("K" & (iCurrentRow + rint - 1).ToString & ":M" & (iCurrentRow + rint - 1).ToString), dr.Item("MESSAGE_DESC").ToString, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, 7, False, Excel.XlRgbColor.rgbBlack, True)
                        Else
                            o_Excel_Function.SetStyleNormal(.Range("N" & (iCurrentRow + rint - 1 - 8).ToString & ":P" & (iCurrentRow + rint - 1 - 8).ToString), dr.Item("MESSAGE_DESC").ToString, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, 7, False, Excel.XlRgbColor.rgbBlack, True)
                        End If

                        'IIf(dtIcomment.Rows.Count = 1 Or rint = dtIcomment.Rows.Count, "      ", Convert.ToString(rint) + ". ") + dr.Item("MESSAGE_DESC").ToString, True, Excel.XlHAlign.xlHAlignLeft)

                        'MsgBox(dr.Item("MESSAGE_DESC").ToString)

                        '*****one line display 20190515 justin 190515
                        'o_Excel_Function.SetStyleNormal(.Range("M" & (iCurrentRow + rint - 1).ToString & ":P" & (iCurrentRow + rint + 6).ToString), dr.Item("MESSAGE_DESC").ToString, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignTop, 7, False, Excel.XlRgbColor.rgbBlack, True)
                        rint += 1
                    Next
                End With
            End If
            errPos = 27
        Catch ex As Exception
            MsgBox("Error in c_PDF___." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub

    Private Sub DisplayCOMMENT(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByVal p_Program_Type As String, ByRef errPos As Integer)

        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtcomment As DataTable = oHeaderInfo.COMMENT(oHeaderInfo.CUS_PROG_GUID, oHeaderInfo.CUS_PROG_ID, p_Program_Type, o_SwitchLang)
            Dim rint As Integer = 1
            Dim cpt As Int32 = 0

            With xlWorkSheet
                '
                o_Excel_Function.SetColorInterior(.Range("B" & (iCurrentRow + 58).ToString & ":P" & (iCurrentRow + 58).ToString).Cells.Interior, Excel.XlRgbColor.rgbLightSlateGray)
                o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 58).ToString & ":P" & (iCurrentRow + 58).ToString), o_SwitchLang.COMMENT, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, 9, True, Excel.XlRgbColor.rgbWhite)
                If Not IsNothing(dtcomment) Then
                    For Each dr As DataRow In dtcomment.Rows
                        'MsgBox(dr.Item("comment_desc").ToString)

                        If rint > 10 Then Exit Sub
                        If rint <= 5 Then
                            o_Excel_Function.SetStyleNormal(.Range("B" & (iCurrentRow + 58 + rint).ToString & ":K" & (iCurrentRow + 58 + rint).ToString), dr.Item("comment_desc").ToString, True, Excel.XlHAlign.xlHAlignLeft)
                        Else
                            o_Excel_Function.SetStyleNormal(.Range("L" & (iCurrentRow + 58 + rint - 5).ToString & ":P" & (iCurrentRow + 58 + rint - 5).ToString), dr.Item("comment_desc").ToString, True, Excel.XlHAlign.xlHAlignLeft)
                        End If
                        rint += 1
                        cpt += 1
                    Next
                End If
            End With
            '
            errPos = 27
        Catch ex As Exception
            MsgBox("Error in c_PDF___." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub

    Private Sub DisplayEQP(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtEqp As DataTable = oContentInfo.EQP(cnt)
            Dim cpt As Int32 = 1

            errPos = 36

            With xlWorkSheet
                For Each dr As DataRow In dtEqp.Rows
                    Select Case cpt 'dtEqp.Rows.Count  'dr.Item("Cnt")
                        Case 1 'M
                            'justin20190425
                            'o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $") '"#,###.00 $")
                        Case 2 'N
                            'o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 3 'O
                            'o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 4 'P
                            'o_Excel_Function.SetStyleNormal(.Range("P" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            o_Excel_Function.SetStyleNormal(.Range("P" & iCurrentRow.ToString), dr.Item("EQP_PCT").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub
    Private Sub DisplayQTY(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtQty As DataTable = oContentInfo.QTY(cnt)
            Dim cpt As Int32 = 1

            errPos = 37

            With xlWorkSheet
                For Each dr As DataRow In dtQty.Rows
                    Select Case cpt 'dr.Item("Cnt")
                        Case 1 'M

                            o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), dr.Item("MIN_QTY_ORD").ToString, True, Excel.XlHAlign.xlHAlignRight)
                        Case 2 'N
                            o_Excel_Function.SetStyleNormal(.Range("K" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), dr.Item("MIN_QTY_ORD").ToString, True, Excel.XlHAlign.xlHAlignRight)
                        Case 3 'O
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), dr.Item("MIN_QTY_ORD").ToString, True, Excel.XlHAlign.xlHAlignRight)
                        Case 4 'P
                            'o_Excel_Function.SetStyleNormal(.Range("P" & iCurrentRow.ToString), dr.Item("MIN_QTY_ORD").ToString, False, Excel.XlHAlign.xlHAlignRight)
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), dr.Item("MIN_QTY_ORD").ToString, True, Excel.XlHAlign.xlHAlignRight)
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub
    Private Sub DisplayPRIX(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function

            Dim dtPrix As DataTable = oContentInfo.PRIX(cnt)
            Dim cpt As Int32 = 1

            errPos = 38
            Dim xlApp As Excel.Application

            xlApp = New Excel.Application
            With xlWorkSheet
                For Each dr As DataRow In dtPrix.Rows
                    Select Case cpt 'dr.Item("Cnt")
                        Case 1 'M
                            o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        ' display 31 = M29*M30   
                        Case 2 'N
                            o_Excel_Function.SetStyleNormal(.Range("K" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 3 'O
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 4 'P
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error001 in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub

    Private Sub DisplayTOTAL(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function


            Dim dtPrix As DataTable = oContentInfo.PRIX(cnt)
            Dim cpt As Int32 = 1


            errPos = 38
            Dim xlApp As Excel.Application

            xlApp = New Excel.Application
            Dim sumVal As String
            With xlWorkSheet
                For Each dr As DataRow In dtPrix.Rows
                    Select Case cpt 'dr.Item("Cnt")
                        Case 1 'M
                            'o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                            ' display 31 = M29*M30   

                            sumVal = "=" & (.Range("G" & (iCurrentRow - 4).ToString).Value).ToString & "*" & dr.Item("UNIT_PRICE").ToString
                            'o_Excel_Function.SetStyleNormal(.Range("M" & (iCurrentRow + 1).ToString), sumVal, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                            o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), sumVal, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 2 'N
                            'o_Excel_Function.SetStyleNormal(.Range("N" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")

                            sumVal = "=" & (.Range("K" & (iCurrentRow - 4).ToString).Value).ToString & "*" & dr.Item("UNIT_PRICE").ToString
                            o_Excel_Function.SetStyleNormal(.Range("k" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), sumVal, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 3 'O
                            'o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")

                            sumVal = "=" & (.Range("M" & (iCurrentRow - 4).ToString).Value).ToString & "*" & dr.Item("UNIT_PRICE").ToString
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), sumVal, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 4 'P
                            'o_Excel_Function.SetStyleNormal(.Range("P" & iCurrentRow.ToString), dr.Item("UNIT_PRICE").ToString, False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")

                            sumVal = "=" & (.Range("O" & (iCurrentRow - 4).ToString).Value).ToString & "*" & dr.Item("UNIT_PRICE").ToString
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), sumVal, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error001 in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub

    Private Sub DisplayRun_Charge(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtRun_Charge As DataTable = oContentInfo.RUN_CHARGE(cnt)
            Dim cpt As Int32 = 1

            errPos = 39

            With xlWorkSheet
                For Each dr As DataRow In dtRun_Charge.Rows
                    Select Case cpt 'dr.Item("Cnt")

                        Case 1 'M
                            'o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), IIf(dr.Item("RUN_CHARGE").ToString = "", "0", dr.Item("RUN_CHARGE").ToString), False, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                            o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), IIf(dr.Item("RUN_CHARGE").ToString = "", "0", dr.Item("RUN_CHARGE").ToString), True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 2 'N
                            o_Excel_Function.SetStyleNormal(.Range("K" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), IIf(dr.Item("RUN_CHARGE").ToString = "", "0", dr.Item("RUN_CHARGE").ToString), True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 3 'O
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), IIf(dr.Item("RUN_CHARGE").ToString = "", "0", dr.Item("RUN_CHARGE").ToString), True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 4 'P
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), IIf(dr.Item("RUN_CHARGE").ToString = "", "0", dr.Item("RUN_CHARGE").ToString), True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub
    Private Sub DisplaySetup_Price(ByRef iCurrentRow As Integer, ByRef xlWorkSheet As Excel.Worksheet, ByRef oContentInfo As cContentInfo, ByRef o_SwitchLang As c_SwitchLang, ByRef cnt As Int32, ByRef errPos As Integer)
        Try
            Dim o_Excel_Function As New c_Excel_Function
            Dim dtSetup_Price As DataTable = oContentInfo.SETUP_PRICE(cnt)
            Dim cpt As Int32 = 1

            errPos = 40

            With xlWorkSheet
                For Each dr As DataRow In dtSetup_Price.Rows
                    Select Case cpt 'dr.Item("Cnt")
                        Case 1 'M
                            o_Excel_Function.SetStyleNormal(.Range("G" & iCurrentRow.ToString & ":J" & iCurrentRow.ToString), dr.Item("SETUP_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 2 'N
                            o_Excel_Function.SetStyleNormal(.Range("K" & iCurrentRow.ToString & ":L" & iCurrentRow.ToString), dr.Item("SETUP_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 3 'O
                            o_Excel_Function.SetStyleNormal(.Range("M" & iCurrentRow.ToString & ":N" & iCurrentRow.ToString), dr.Item("SETUP_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 4 'P
                            o_Excel_Function.SetStyleNormal(.Range("O" & iCurrentRow.ToString & ":P" & iCurrentRow.ToString), dr.Item("SETUP_PRICE").ToString, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, 7, False, Excel.XlRgbColor.rgbBlack, False, "Tahoma", "0.00 $")
                        Case 5 ' Not displayed
                            'may be on message it will be write above Comments
                            'Like fifth line not displayed, you can display only four line with the same properties
                            Exit Sub
                        Case Else
                            Exit Sub
                    End Select
                    cpt += 1
                Next
            End With
        Catch ex As Exception
            MsgBox("Error in c_PDF." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & ", errPos : " & errPos.ToString)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
