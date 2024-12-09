Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.IO

Public Class frmCreateMultiplePictureBox
    Dim db As New cDBA
    Dim orientation As Boolean = False
    Dim itemCount As Integer = 0

    '  Public printScreen As String

    Dim zoom As Double = 0.0

    Dim bm_source As Bitmap
    Dim convCm As Double = 0.0277

    Private picture As Image
    Private num_PicBxs As Integer = 0

    Dim Shapes As New List(Of PictureBox)
    Private WithEvents Shape As PictureBox
    Private pictureLocation As Point

    Dim ShapesTxt As New List(Of TextBox)
    Private WithEvents ShapeTxt As TextBox

    Dim TextBox As New TextBox


    Dim gs As Integer = 50 'This is set to the the grid spacing
    Dim startgridX As Integer = 130 'Set this to the X position of the first usable grid square
    Dim startgridY As Integer = 114 'Set this to the Y position of the first usable grid square

    Dim IsDragging As Boolean = False
    Dim StartPoint As Point
    Dim StartPointText As Point

    Private m_PictureBox As PictureBox

    Private Sub frmCreateMultiplePictureBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '  Me.BackColor = Color.DarkSalmon
            Call tlComboPack()
            frm_pack_close = False

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

#Region "#### Function ###"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' If there is an image and it has a location, 
        ' paint it when the Form is repainted.
        If (Me.picture IsNot Nothing) And _
          Not (Me.pictureLocation.Equals(Point.Empty)) Then
            e.Graphics.DrawImage(Me.picture, Me.pictureLocation)
        End If
    End Sub

    Private Sub Add_PictureBoxes(ByVal files As String()) 'For Array
        Try

            Dim strName As String
            Dim PicBox As New PictureBox

            strName = files(0)
            strName = strName.Substring(strName.LastIndexOf("\") + 1, (strName.LastIndexOf(".") - 1) - strName.LastIndexOf("\"))

            Shapes.Add(PicBox)
            Shapes(num_PicBxs).Visible = True
            picture = Image.FromFile(files(0), True)

            Shapes(num_PicBxs).Name = strName & num_PicBxs
            Shapes(num_PicBxs).Tag = files(0).ToString
            Shapes(num_PicBxs).Image = picture
            Shapes(num_PicBxs).SizeMode = PictureBoxSizeMode.AutoSize

            '  Shapes(num_PicBxs).Width = picture.Width
            '  Shapes(num_PicBxs).Height = picture.Height
            Shapes(num_PicBxs).BorderStyle = BorderStyle.Fixed3D
            Shapes(num_PicBxs).BringToFront()

            AddHandler ShapesTxt(num_PicBxs).LostFocus, AddressOf ShapeTxt_LostFocus

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Add_PictureBoxes(ByVal files As String) 'Simple string
        Try

            Dim strName As String
            Dim PicBox As New PictureBox

            strName = files
            strName = strName.Substring(strName.LastIndexOf("\") + 1, (strName.LastIndexOf(".") - 1) - strName.LastIndexOf("\"))

            Shapes.Add(PicBox)
            Shapes(num_PicBxs).Visible = True
            picture = Image.FromFile(files, True)

            Shapes(num_PicBxs).Name = strName & num_PicBxs
            Shapes(num_PicBxs).Tag = files(0).ToString
            Shapes(num_PicBxs).Image = picture

            '  If zoom <> 0.0 Then

            Shapes(num_PicBxs).SizeMode = PictureBoxSizeMode.Zoom

            Shapes(num_PicBxs).Width = picture.Width / zoom
            Shapes(num_PicBxs).Height = picture.Height / zoom
            Shapes(num_PicBxs).BorderStyle = BorderStyle.Fixed3D
            Shapes(num_PicBxs).BringToFront()

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub Add_TextBoxs(ByVal Str As String, ByRef picturelocation As Point)
        Try
            TextBox = New TextBox

            '  picturelocation = Me.PointToClient(New Point(e.X, e.Y))

            ShapesTxt.Add(TextBox)
            ShapesTxt(num_PicBxs).Visible = True

            ShapesTxt(num_PicBxs).Location = New Point(Me.pictureLocation.X, Me.pictureLocation.Y - 20)
            ShapesTxt(num_PicBxs).Name = Str & num_PicBxs
            ShapesTxt(num_PicBxs).Text = Str.Substring(0, Str.Length - 36)

            '  TextBox.Width = 100
            ShapesTxt(num_PicBxs).BackColor = Color.White
            ShapesTxt(num_PicBxs).ForeColor = Color.Black
            ShapesTxt(num_PicBxs).Font = New Font("Time New Romane", 10, FontStyle.Bold)
            ShapesTxt(num_PicBxs).BorderStyle = BorderStyle.None
            ShapesTxt(num_PicBxs).ReadOnly = False

            Me.Controls.Add(ShapesTxt(num_PicBxs))


            Dim textSize As System.Drawing.Size = TextRenderer.MeasureText(ShapesTxt(num_PicBxs).Text, ShapesTxt(num_PicBxs).Font)
            ShapesTxt(num_PicBxs).Width = textSize.Width  '100

            AddHandler ShapesTxt(num_PicBxs).LostFocus, AddressOf ShapeTxt_LostFocus
            AddHandler ShapesTxt(num_PicBxs).TextChanged, AddressOf ShapeTxt_TextChanged

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub frmCreateMultiplePictureBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Try
            '      Dim str As String = e.Data.GetData("Text")

            If e.Data.GetDataPresent(DataFormats.Bitmap) _
                Or e.Data.GetDataPresent(DataFormats.FileDrop) _
                Or e.Data.GetDataPresent(DataFormats.StringFormat) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmCreateMultiplePictureBox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Try

            If e.Data.GetDataPresent(DataFormats.Bitmap) _
                Or e.Data.GetDataPresent(DataFormats.FileDrop) _
                Or e.Data.GetDataPresent(DataFormats.StringFormat) Then

                Dim str As String = ""

                Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

                If Not IsNothing(files) Then
                    Call Add_PictureBoxes(files)
                ElseIf e.Data.GetDataPresent(DataFormats.StringFormat) Then

                    str = e.Data.GetData("Text")

                    Call Add_PictureBoxes(str)

                    str = str.Substring(str.LastIndexOf("\") + 1, (str.LastIndexOf(".") - 1) - str.LastIndexOf("\"))

                Else
                    Exit Sub
                End If
                Me.pictureLocation = Me.PointToClient(New Point(e.X, e.Y))

                Call Add_TextBoxs(str, pictureLocation)
                'TextBox = New TextBox



                'TextBox.Location = New Point(Me.pictureLocation.X, Me.pictureLocation.Y - 20)
                'TextBox.Name = str
                'TextBox.Text = str

                'Dim textSize As System.Drawing.Size = TextRenderer.MeasureText(TextBox.Text, TextBox.Font)
                'TextBox.Width = textSize.Width + 15  '100

                ''  TextBox.Width = 100
                'TextBox.BackColor = Color.Gray
                'TextBox.ForeColor = Color.White
                'TextBox.Font = New Font("Time New Romane", 10, FontStyle.Bold)
                'TextBox.BorderStyle = BorderStyle.None
                'TextBox.ReadOnly = False

                'Me.Controls.Add(TextBox)

                'ShapesTxt.Add(TextBox)

                '   AddHandler ShapesTxt(num_PicBxs).LostFocus, AddressOf ShapeTxt_LostFocus



                Shapes(num_PicBxs).Location = Me.pictureLocation
                Me.Controls.Add(Shapes(num_PicBxs))


                AddHandler Shapes(num_PicBxs).MouseUp, AddressOf Shape_MouseUp
                AddHandler Shapes(num_PicBxs).MouseDown, AddressOf Shape_MouseDown
                AddHandler Shapes(num_PicBxs).MouseMove, AddressOf Shape_MouseMove
                AddHandler Shapes(num_PicBxs).MouseDoubleClick, AddressOf Shape_MouseDoubleClick
                AddHandler Shapes(num_PicBxs).MouseClick, AddressOf Shape_MouseClick

                num_PicBxs += 1

            End If
            picture = Nothing

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

#Region "### EvenHandler #####"

    Private Sub EControl()
        Try
            Dim Children As New List(Of System.Windows.Forms.Control)
            Dim t As Integer = 0
            t = Me.Controls.Count

            Debug.Print(t.ToString)
            For Each frm In My.Application.OpenForms
                For Each oControl As Control In frm.Controls
                    If TypeOf oControl Is PictureBox Then
                        Debug.Print(oControl.Name.ToString)

                        m_PictureBox = New PictureBox

                        m_PictureBox = oControl

                        m_PictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                        m_PictureBox.Refresh()

                    End If
                Next
            Next


        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)

        End Try
    End Sub

    Private Sub ControlResizePictureBox()
        Try
            Dim Children As New List(Of System.Windows.Forms.Control)
            Dim t As Integer = 0
            t = Me.Controls.Count

            Debug.Print(t.ToString)
            For Each frm In My.Application.OpenForms
                If frm.Name = "frmCreateMultiplePictureBox" Then
                    For Each oControl As Control In frm.Controls

                        If TypeOf oControl Is PictureBox Then
                            Debug.Print(oControl.Name.ToString)

                            m_PictureBox = New PictureBox

                            m_PictureBox = oControl

                            Dim img As Image = m_PictureBox.Image

                            '  m_PictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)

                            '     If zoom <> 0.0 Then

                            m_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
                            m_PictureBox.Width = img.Width / zoom
                            m_PictureBox.Height = img.Height / zoom
                            'Else


                            '   m_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize
                            ' End If

                            '  m_PictureBox.Image = img
                            m_PictureBox.Refresh()

                        End If
                    Next
                End If
            Next


        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)

        End Try
    End Sub


    Private Sub ShapeTxt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShapeTxt.TextChanged

        ' Get TextBox reference from sender object.
        ' ... The TextBox1 could be used directly instead.
        ' Dim t As TextBox = sender

        ' Assign the window's title to the Text of the TextBox.
        ' ... This is a string value.
        '  Me.Text = t.Text

        TextBox = New TextBox
        TextBox = DirectCast(sender, TextBox)

        Dim textSize As System.Drawing.Size = TextRenderer.MeasureText(TextBox.Text, TextBox.Font)
        TextBox.Width = textSize.Width '+ 15  '100

    End Sub

    Private Sub ShapeTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShapeTxt.LostFocus
        Try
            TextBox = New TextBox
            TextBox = DirectCast(sender, TextBox)

            Dim textSize As System.Drawing.Size = TextRenderer.MeasureText(TextBox.Text, TextBox.Font)
            TextBox.Width = textSize.Width '5  '100

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Shape_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shape.MouseClick
        Try

            m_PictureBox = New PictureBox
            m_PictureBox = DirectCast(sender, PictureBox)


            If e.Button = Windows.Forms.MouseButtons.Right Then

                cms.Show(m_PictureBox, New System.Drawing.Point(e.X, e.Y))
                txtStripW.Text = m_PictureBox.Width
                txtStripH.Text = m_PictureBox.Height

            End If

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Shape_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shape.MouseDoubleClick
        Try
            If m_PictureBox.Image Is Nothing Then
                Dim h As Int32 = m_PictureBox.Height
                Dim w As Int32 = m_PictureBox.Width

                m_PictureBox.Width = h
                m_PictureBox.Height = w

                m_PictureBox.Refresh()
            Else
                Dim img As Image = m_PictureBox.Image

                m_PictureBox = New PictureBox
                m_PictureBox = DirectCast(sender, PictureBox)


                '     Debug.Print(m_PictureBox.Tag.ToString)

                img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                If zoom <> 0 Then
                    m_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
                    m_PictureBox.Width = img.Width / zoom
                    m_PictureBox.Height = img.Height / zoom
                Else
                    m_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize
                End If

                'm_PictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                'm_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize

                m_PictureBox.Image = img
                m_PictureBox.Refresh()
            End If



        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Shape_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shape.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then

            m_PictureBox = New PictureBox

            m_PictureBox = DirectCast(sender, PictureBox)

            StartPoint = m_PictureBox.PointToScreen(New Point(e.X, e.Y))

            IsDragging = True

        End If

    End Sub

    Private Sub Shape_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shape.MouseMove
        If IsDragging Then

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim EndPoint As Point = m_PictureBox.PointToScreen(New Point(e.X, e.Y))

                m_PictureBox.Left += (EndPoint.X - StartPoint.X)
                m_PictureBox.Top += (EndPoint.Y - StartPoint.Y)

                For Each c As Control In Me.Controls
                    If TypeOf c Is TextBox And c.Name = m_PictureBox.Name Then

                        Dim PointText As Point = New Point(m_PictureBox.Location.X, m_PictureBox.Location.Y - 20)
                        c.Location = PointText

                        Dim textSize As System.Drawing.Size = TextRenderer.MeasureText(c.Text, c.Font)

                        c.Width = textSize.Width '100
                    End If

                Next

                StartPoint = EndPoint

            End If
        End If
    End Sub

    Private Sub Shape_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shape.MouseUp

        IsDragging = False
        ' Call EControl()

    End Sub


#End Region

    Private Sub cms_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cms.ItemClicked
        Try
            If e.ClickedItem.Text = "Delete" Then

                Debug.Print(e.ClickedItem.Text)

                For Each c As Control In Me.Controls
                    If TypeOf c Is TextBox And c.Name = m_PictureBox.Name Then
                        c.BackgroundImage = Nothing
                        Me.Controls.Remove(c)

                    End If

                Next

                Me.Controls.Remove(m_PictureBox)

            ElseIf e.ClickedItem.Name = "WidthToolStripMenuItem" Then

                m_PictureBox.Width = txtStripW.Text
                m_PictureBox.Refresh()

            ElseIf e.ClickedItem.Name = "HeightToolStripMenuItem" Then

                'txtStripH.Text = m_PictureBox.Height
                m_PictureBox.Height = txtStripH.Text
                m_PictureBox.Refresh()
            ElseIf e.ClickedItem.Name = "CustomImageToolStripMenuItem" Then
                Debug.Print(e.ClickedItem.Text)
                itemCount += 1
                For Each c As Control In Me.Controls
                    If TypeOf c Is TextBox And c.Name = m_PictureBox.Name Then

                        c.Text = "Custom Item" & itemCount.ToString
                        c.Name = "Custom Item" & itemCount.ToString
                        m_PictureBox.Name = c.Name
                        m_PictureBox.Image = Nothing
                        m_PictureBox.BackColor = Color.WhiteSmoke
                        m_PictureBox.Invalidate()

                    End If

                Next

            End If

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

#Region "---------------Maintenance-----------------"

    'need cm
    Private Function convertPixInch(ByVal pixel As Decimal) As Decimal
        convertPixInch = 0.0

        '1 pixel = 15 twips
        '1 cm = 567 twips
        Dim res As Decimal = (pixel * 15 / 567) / 2.54
        convertPixInch = Decimal.Round(res, 1)
    End Function
    'need pixel
    Private Function convertInchCmPixel(ByVal inch As Decimal) As Decimal
        convertInchCmPixel = 0.0

        '1 pixel = 15 twips
        '1 cm = 567 twips
        '1 inch = 2.54 cm
        Dim res As Decimal = ((inch * 2.54) * 567) / 15
        convertInchCmPixel = Decimal.Round(res, 1)

    End Function

    Private Sub tlComboPack()
        Try

            Dim dt As DataTable
            Dim strSql As String

            strSql = " select top 1 CAST(null as varchar(20) ) As item_cd ," & _
                     " CAST(null as varchar(20)) As x, CAST(null as varchar(20)) As y, " & _
                     " CAST (null As Varchar(20)) As z  From ITEM_SIZE " & _
                     " UNION " & _
                     " SELECT item_cd,x,y,z " & _
                     " From ITEM_SIZE where item_cd like 'p%' "


            'p.ITEM_MASTER_ID , p.ItemStatus ,    p.WEIGHT , p.WEIGHT_W_PKG

            strSql = " select top 1 CAST(null as varchar(20) ) As item_cd , " _
                   & " CAST(null as varchar(20)) As x, CAST(null as varchar(20)) As y, " _
                   & " CAST (null As Varchar(20)) As z  From ITEM_SIZE " _
                   & " UNION " _
                   & " select p.ITEM_CD , p.SIZE_X As x , p.SIZE_Y As y , p.SIZE_Z As z " _
                   & " from MDB_ITEM_FLD_PIVOT_ION p  " _
                   & " where p.ItemClass = 'Packaging' and p.ItemStatus = 'lau' " _
                   & " And ISNULL(Cast(p.SIZE_X As Decimal(10, 2)), 0.00) <> 0.00 And ISNULL(Cast(SIZE_Y As Decimal(10,2)),0.00) <> 0.00  "



            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                tlStripComboPack.ComboBox.DataSource = dt
                tlStripComboPack.ComboBox.DisplayMember = "ITEM_CD"
                tlStripComboPack.ComboBox.ValueMember = "item_cd"
            End If

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub ResizeForm()
        Try

            Dim dt As DataTable
            Dim strSql As String

            If tlStripComboPack.ComboBox.SelectedIndex = 0 Then Exit Sub


            strSql = " SELECT item_cd,x,y,z " &
                      " From ITEM_SIZE where item_cd = '" & tlStripComboPack.ComboBox.SelectedValue & "' "

            strSql = " select p.ITEM_MASTER_ID , p.ITEM_CD , p.ItemStatus , p.SIZE_X As x , p.SIZE_Y As y , p.SIZE_Z As z , " _
                   & " p.WEIGHT , p.WEIGHT_W_PKG from MDB_ITEM_FLD_PIVOT_ION p  " _
                   & " where p.ItemClass = 'Packaging' and p.ItemStatus = 'lau' " _
                   & " And ISNULL(Cast(p.SIZE_X As Decimal(10, 2)), 0.00) <> 0.00 And ISNULL(Cast(SIZE_Y As Decimal(10,2)),0.00) <> 0.00  " _
                   & " And p.ITEM_CD  = '" & tlStripComboPack.ComboBox.SelectedValue & "' "



            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                lblTxtDepth.Text = dt.Rows(0).Item("z").ToString

                Select Case dt.Rows(0).Item("item_cd").ToString
                    Case "P1216", "BBAND2", "P4724"

                        zoom = 1.7

                        tlStripZoomRes.Text = " / " & zoom

                        If orientation <> False Then

                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString) / zoom)
                            Me.Height = ((ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)) + (stStripBottom.Height + 10)) / zoom

                        Else

                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Height = ((ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)) + (stStripBottom.Height + 10)) / zoom
                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString) / zoom)

                        End If


                    Case "P912", "66P350120", "66P350105", "66P325950", "P1295"

                        zoom = 1.4
                        tlStripZoomRes.Text = " / " & zoom

                        If orientation <> False Then

                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString) / zoom)
                            Me.Height = ((ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)) + (stStripBottom.Height + 10)) / zoom

                        Else

                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Height = ((ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)) + (stStripBottom.Height + 10)) / zoom
                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString) / zoom)

                        End If

                    Case Else

                        zoom = 1.05
                        tlStripZoomRes.Text = "0"

                        If orientation <> False Then
                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString))
                            Me.Height = (ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)) + (stStripBottom.Height + 10)

                            orientation = True
                        Else

                            stStripHightText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)))
                            tsStripWidthText.Text = convertPixInch(convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString)))

                            Me.Height = (ToolStrip1.Height + 15) + convertInchCmPixel(CDbl(dt.Rows(0).Item("x").ToString)) + (stStripBottom.Height + 10)
                            Me.Width = convertInchCmPixel(CDbl(dt.Rows(0).Item("y").ToString))

                            orientation = False

                        End If

                End Select

            End If

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

#End Region
    '-------------------------------------

    

    Private Sub tlStripComboPack_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlStripComboPack.SelectedIndexChanged
        Try

            Call ResizeForm()

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try

        Try
            ' Dim Children As New List(Of System.Windows.Forms.Control)
            Dim t As Integer = 0
            t = Me.Controls.Count
            Dim count As Integer = 0

            Debug.Print(t.ToString)
            For Each frm In My.Application.OpenForms
                If frm.Name = "frmCreateMultiplePictureBox" Then
                    For Each oControl As Control In frm.Controls

                        If TypeOf oControl Is PictureBox Then

                            Debug.Print(oControl.Name.ToString)
                            count = count + 1
                        End If
                    Next
                End If
            Next

            If count <> 0 Then
                Call ControlResizePictureBox()
            End If


        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub tlStripBtnOrientation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlStripBtnOrientation.Click
        Try

            If orientation = False Then
                orientation = True
            Else
                orientation = False
            End If

            Call ResizeForm()

        Catch ex As Exception
            MsgBox(Me.Name & ". " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmCreateMultiplePictureBox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim graph As Graphics = Nothing
        If m_PictureBox Is Nothing Then

            frm_pack_close = False
            pack_code = ""
            e.Cancel = False
            Exit Sub
        End If


        Try
            Dim frmleft As System.Drawing.Point = Me.Bounds.Location
            Dim screenx As Integer = frmleft.X
            Dim screeny As Integer = frmleft.Y

            Dim bmp As New Bitmap(Me.Bounds.Width + 8, Me.Bounds.Height + 8)

            graph = Graphics.FromImage(bmp)

            graph.CopyFromScreen(screenx - 5, screeny - 5, 0, 0, bmp.Size)

            ' Save the Screenshot to a file
            'this is global variable 
            printScreen = "C:\ExactTemp\" & Trim(lblCus_Prog_Id.Text) & "_cl_" & lblClient.Text & "_" & Date.Now.ToString("dd-MM-yyyy") & "_Pack" & Guid.NewGuid.ToString & ".png"

            'this is global variable
            pack_code = tlStripComboPack.Text
            '   SaveSetting("CustomerFile", "frmCreateMultiplePictureBox", "pack_code", pack_code)

            bmp.Save(printScreen)

            Dim saveFileDialog1 As New SaveFileDialog

            saveFileDialog1.InitialDirectory = "C:\Desktop\"

            saveFileDialog1.FilterIndex = 2

            saveFileDialog1.FileName = Me.Text & Guid.NewGuid.ToString & "_" & Date.Now.ToString("dd-MM-yyyy")

            If saveFileDialog1.ShowDialog = DialogResult.OK Then
                bmp.Save(saveFileDialog1.FileName & ".png")
            End If

            frm_pack_close = True


        Catch ex As Exception
            MsgBox(Me.Name & ". " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


End Class