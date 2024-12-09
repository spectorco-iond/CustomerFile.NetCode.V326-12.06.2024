Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO

Public Class c_Excel_Function

    Dim m_logo_path As String
    Dim m_logo_width As Integer

    Public Sub New()
        Call Init()
    End Sub
#Region "##############Maintenance Properties##########################"
    Private Sub Init()
        Try
            m_logo_path = String.Empty
            m_logo_width = 0

        Catch ex As Exception
            MsgBox("Error in c_Excel_Function." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "################ Functions Maintenance #####################"

    Public Sub SetImage(ByRef oSheet As Excel.Worksheet, ByRef oRange As Excel.Range, ByVal pLockAspRatio As Boolean, ByVal pstrPath As String, _
                        ByVal piHeight As Integer, Optional ByVal piWidth As Integer = 0)

        If pstrPath <> "" Then

            With oSheet.Pictures.Insert(pstrPath)
                .ShapeRange.LockAspectRatio = pLockAspRatio
                .Left = oRange.Left
                .Top = oRange.Top
                .Height = piHeight
                If piWidth <> 0 Then .Width = piWidth
                .ShapeRange.IncrementTop(2.25)

            End With
        End If
    End Sub
   
    Public Sub SetStyleH1(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False, Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignCenter)

        With oRange

            SetColorInterior(.Interior)

            .Font.Bold = True
            .Font.Size = 24
            .Font.FontStyle = "Tahoma"

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

        End With
    End Sub
    Public Sub SetColorInterior(ByRef oCellGreyInterior As Excel.Interior, Optional ByRef xlTmColor As Excel.XlRgbColor = Excel.XlRgbColor.rgbDarkKhaki, Optional ByVal pTintShade As Int32 = 0)


        With oCellGreyInterior
            .Pattern = Excel.XlPattern.xlPatternSolid
            .PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            .Color = xlTmColor
            '.ThemeColor = xlTmColor 'RGB(148, 138, 84)  
            .TintAndShade = pTintShade
            .PatternTintAndShade = 0
        End With
    End Sub

    Public Sub SetStyleNormal(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False,
                               Optional ByVal oAlignHor As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft,
                               Optional ByVal oAlignVert As Excel.XlVAlign = Excel.XlVAlign.xlVAlignCenter,
                               Optional ByVal oFontSize As Integer = 7, Optional ByVal pFontBold As Boolean = False,
                               Optional ByVal p_Font_Color As Excel.XlRgbColor = Excel.XlRgbColor.rgbBlack,
                               Optional ByVal oWrapText As Boolean = False,
                               Optional ByVal pFontName As String = "Tahoma",
                               Optional ByVal oCurrency As String = "0.00")

        With oRange

            .Font.Bold = pFontBold
            .Font.Size = oFontSize
            .Font.Name = "Tahoma"
            .Font.Color = p_Font_Color 'RGB(255, 255, 255)

            .HorizontalAlignment = oAlignHor
            .VerticalAlignment = oAlignVert

            .WrapText = oWrapText
            .MergeCells = pMerge
            .FormulaR1C1 = pValue
            If oCurrency <> "0.00" Then .NumberFormat = oCurrency
            ' .RowHeight = pRowHeight
        End With

    End Sub

    Public Sub SetStyleNormalBold(ByRef oRange As Excel.Range, Optional ByVal pValue1 As Integer = 0, Optional ByVal pValue2 As Integer = 0)

        With oRange

            .Characters(pValue1, pValue2).Font.Bold = True
            .Font.FontStyle = "Tahoma"

        End With

    End Sub

    Public Sub SetStyleH5(ByRef oRange As Excel.Range, Optional ByVal pValue As String = "", Optional ByVal pMerge As Boolean = False,
                           Optional ByVal oAlign As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft, Optional ByVal pFontSize As Integer = 7 _
                           , Optional ByVal rowH As Integer = 27)

        With oRange

            .Font.Bold = True
            .Font.Size = pFontSize
            .Font.Name = "Tahoma"

            .HorizontalAlignment = oAlign
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .MergeCells = pMerge
            .FormulaR1C1 = pValue

            .RowHeight = rowH
        End With

    End Sub

    Public Sub BorderStyle(ByRef oRange As Excel.Range, Optional ByRef oBordAround As Boolean = True, _
                            Optional ByRef bordersIndex As Excel.XlBordersIndex = Excel.XlBordersIndex.xlEdgeBottom, _
                            Optional ByRef borderWeight As Excel.XlBorderWeight = Excel.XlBorderWeight.xlThin)
        Try

            With oRange

                If oBordAround = True Then
                    .BorderAround2(Excel.XlLineStyle.xlContinuous)
                    With .Borders
                        .MergeCells = True
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = borderWeight
                        .Color = Color.Black
                    End With

                ElseIf oBordAround = False Then
                    With .Borders(bordersIndex)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = borderWeight
                        .Color = Color.Black
                    End With

                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub SetPrintingProperties(ByRef oSheet As Excel.Worksheet)
        Try

            If m_logo_path = String.Empty Then Exit Sub

            With oSheet.PageSetup
                .HeaderMargin = 4 '3.7 '0.05

                .TopMargin = 67 '63 '60 '66 '0.89

                .LeftHeaderPicture.Filename = m_logo_path
                .LeftHeaderPicture.Width = m_logo_width / 1.3

                .LeftHeaderPicture.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse
                .LeftHeader = "&G"

                .LeftMargin = 55.6 '50 '0.77
                .RightMargin = 14.8 '15.8 '16 '0.2

                .FooterMargin = 12.3 '14.45 '0.17
                .BottomMargin = 24.6 '24 '23 '25.74 '0.35

                .CenterHorizontally = False
                .CenterVertically = False
                .Orientation = Excel.XlPageOrientation.xlPortrait
                .Draft = False
                .PaperSize = Excel.XlPaperSize.xlPaperLetter
                .BlackAndWhite = False
                .Zoom = True


                'in comment because zoom is true
                .FitToPagesWide = 1
                .FitToPagesTall = 0
                .OddAndEvenPagesHeaderFooter = False
                .DifferentFirstPageHeaderFooter = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = False


                .LeftFooter = Environment.UserName
                .CenterFooter = "&""Arial,Bold""Page &P of &N "" "" &N" '" &N" '"&""Arial,Bold"
                .RightFooter = "&D &N" ' DateTime.Now.ToString("d")
                '.Footer.Font.Size = 6

            End With
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region " --------------Properties-------------------------"

    Public Property LOGO_PATH As String
        Get
            LOGO_PATH = m_logo_path
        End Get
        Set(ByVal value As String)
            m_logo_path = value
        End Set
    End Property

    Public Property LOGO_WIDTH As Integer
        Get
            LOGO_WIDTH = m_logo_width
        End Get
        Set(ByVal value As Integer)
            m_logo_width = value
        End Set
    End Property
#End Region

End Class
