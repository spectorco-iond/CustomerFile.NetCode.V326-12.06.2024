Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Timers

Public Class frmItem_Picture
    Dim drRowNew As DataRow
    Dim dt As DataTable = New DataTable()
    Dim dTable As DataTable = New DataTable()
    'Dim oScreenResolution As New cChangeScreenResolution
    Private oOeprcfil_sql As New cOeprcfil_sql_Pack
    Dim db As New cDBA

    Dim oMdb_List As New cMdb_Cus_Prog_Item_List_Pack

    Private picture As Byte()

    Private m_Customer As cCustomer
    Public oMdb_Cus_Prog As New cMdb_Cus_Prog_Pack
    Dim oMdb_Cus_Document As New cMdb_Cus_Document_Pack
    Private p_Save As Boolean = False
    Private p_CustPack As Boolean = False
    Private p_Option As Int32
    Private p_Program As String

    Private aTimer As System.Timers.Timer


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '^^^^^^^for identifie why is the pack code & if frmCreateMultiplePictureBox is close after that retrive in txtItem_Cd^^^^^^^^^^^^^^^^^^^
        pack_code = ""
        frm_pack_close = False
        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

    End Sub

    Public Sub New(ByVal pCustomer As cCustomer, ByVal m_Program As String)

        ' This call is required by the designer.
        InitializeComponent()

        p_Program = m_Program

        ' Add any initialization after the InitializeComponent() call.
        m_Customer = pCustomer
        txtCusNo.Text = m_Customer.cmp_code
        txtCurrency.Text = m_Customer.Currency
        p_CustPack = True
        p_Option = 2
        Call Curr(txtRunCharge)
        Call Curr(txtSetup)

        '^^^^^^^^^^^^^^^^^^^^^
        pack_code = ""
        frm_pack_close = False
        '^^^^^^^^^^^^^^^^^^^^^

    End Sub

    Public Sub New(ByVal Cus_Prog_Id As Integer, ByVal m_Program As String)

        ' This call is required by the designer.
        InitializeComponent()
        p_Program = m_Program
        oMdb_Cus_Prog = New cMdb_Cus_Prog_Pack(Cus_Prog_Id)

        txtCusNo.Text = Trim(oMdb_Cus_Prog.Cus_No)
        txtCurrency.Text = Currency(Trim(txtCusNo.Text))
        p_CustPack = False
        ' Add any initialization after the InitializeComponent() call.
        p_Option = 3

        Call Curr(txtRunCharge)
        Call Curr(txtSetup)

        '^^^^^^^^^^^^^^^^^^^^^
        pack_code = ""
        frm_pack_close = False
        '^^^^^^^^^^^^^^^^^^^^^

    End Sub

    Private Sub frmItem_Picture_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            If p_Save <> True Then



                Dim oMsgBox As New MsgBoxResult

                If p_CustPack = False Then
                    oMsgBox = MsgBox("Your Customised Packaging is not saved.You have 3 options." & vbCrLf & "YES = Save & Exit from form. " & vbCrLf _
                                                    & "NO  = Do not Save & Exit from form." & vbCrLf & "CANCEL = Cancel Message Box & Return in form. ", MsgBoxStyle.YesNoCancel, " Message from " & Me.Text & ".")
                ElseIf p_CustPack = True Then
                    '"EXIT", MsgBoxStyle.OkCancel, " Message from " & Me.Text & "."
                    oMsgBox = MsgBox(Space(30) & "EXIT", MsgBoxStyle.OkCancel, " Message from " & Me.Text & ".")
                End If

                If oMsgBox = MsgBoxResult.No Then

                    p_Save = True

                ElseIf oMsgBox = MsgBoxResult.Cancel Then

                    e.Cancel = True
                    p_Save = False
                ElseIf oMsgBox = MsgBoxResult.Yes Then

                    If pack_code.Length <> 0 And frm_pack_close = True Then
                        aTimer.Stop()
                        aTimer.Dispose()
                    End If


                    For Each dr As DataGridViewRow In dgvItem.Rows
                        oMdb_List = New cMdb_Cus_Prog_Item_List_Pack
                        With oMdb_List
                            .Cus_Prog_Id = oMdb_Cus_Prog.Cus_Prog_Id
                            .Item_Cd = Trim(dr.Cells(Column.item_cd).Value)
                            .Item_No = Trim(dr.Cells(Column.item_no).Value)
                            .Item_Color = "ALL"
                            .Item_Desc = Trim(dr.Cells(Column.description).Value)
                            .Min_Qty_Ord = dr.Cells(Column.Min_Qty_Ord).Value

                            .Unit_Price = dr.Cells(Column.price).Value
                            .Setup_Price = dr.Cells(Column.setup).Value
                            .Dec_Met_ID = dr.Cells(Column.deco_id).Value
                            .Dec_Met_Group_ID = dr.Cells(Column.deco_id).Value
                            .ChargeId = dr.Cells(Column.charge_id).Value
                            .Run_Charge = dr.Cells(Column.run_charge).Value

                            .Save()

                        End With
                    Next
                    Debug.Print(printScreen)

                    If File.Exists(printScreen) Then

                        oMdb_Cus_Document = New cMdb_Cus_Document_Pack(printScreen)

                        ''Code for save prnt screen of custom box
                        With oMdb_Cus_Document

                            .Doc_Type_Id = 42
                            .Cus_No = oMdb_Cus_Prog.Cus_No
                            'for document_desc,document_path and document_ext in the class it will be populate
                            'for document_data also
                            .Cus_Prog_Guid = oMdb_Cus_Prog.Cus_Prog_Guid
                            .Save()
                        End With
                        e.Cancel = False
                        p_Save = True
                    End If
                End If 'MsgBox
            Else
                e.Cancel = False
                Me.Close()
            End If 'p_Save
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



    Private Sub frmItem_Picture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Directory.Exists("C:\ExactTemp\") Then
                MkDir("C:\ExactTemp\")
            End If

            ' Call Item_PictureProof()
            Call FillCboDeco()
            Call FillCboCharge()

            picture = Nothing

            Call CreateColumns(dgvItem)
            Call CreateColumns(dgvResult)
            Call DisplayItem(dgvItem)
            Call DisplayResult(dgvResult)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub cboColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColor.SelectedIndexChanged
        Try

            Call Item_Picture()
            Call PreviewDoc(pictBox)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Function TextUpper(ByRef sender As Object) As TextBox
        TextUpper = Nothing

        Try
            Dim TextBox = New TextBox
            TextBox = DirectCast(sender, TextBox)

            TextBox.Text.ToString.ToUpper()
            TextUpper = TextBox

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub txtItemCd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemCd.LostFocus
        Try

            cboDecoMetod.SelectedIndex = 0
            cboCharge.SelectedIndex = 0

            txtItemCd.Text = TextUpper(sender).Text.ToString.ToUpper

            If txtItemCd.Text.ToUpper = "CUSTOM" Then

                lblItemDesc.Text = "CUSTOM ITEM"

                cboColor.DataSource = Nothing

                Dim opFile As New OpenFileDialog
                Dim strPathAndFile As String = ""

                opFile.Title = "Open File Dialog"
                opFile.InitialDirectory = "C:\Desktop\"

                If opFile.ShowDialog() = DialogResult.OK Then
                    '  strPathAndFile = opFile.FileName

                    strPathAndFile = "C:\ExactTemp\" & "CUSTOM ITEM" & Guid.NewGuid.ToString & ".jpg"

                    My.Computer.FileSystem.CopyFile(opFile.FileName, strPathAndFile, True)

                    Call DisplayPict(strPathAndFile, pictBox)

                End If

            Else
                Call FindItems()
            End If

            txtQty.Text = 1

            Curr(txtRunCharge)
            Curr(txtSetup)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "----- Private function -----"

    Private Sub FillCboDeco()
        Try
            Dim dt As DataTable
            Dim strSql As String

            cboDecoMetod.DataSource = Nothing

            strSql = _
            "SELECT      CAST(0 AS INT) AS DEC_MET_ID, CAST(' ' AS VARCHAR(20)) AS DEC_MET_CD  " & _
            "UNION      " & _
            "SELECT		DEC_MET_ID, DEC_MET_CD FROM  MDB_CFG_DEC_MET WITH (NoLock)  " & _
            "WHERE IMPRINT_LIST_ITEM = 1 ORDER BY	DEC_MET_CD "

            dt = db.DataTable(strSql)

            cboDecoMetod.DataSource = dt

            cboDecoMetod.ValueMember = "DEC_MET_ID"
            cboDecoMetod.DisplayMember = "DEC_MET_CD"

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub FillCboCharge()
        Try
            Dim dt As DataTable
            Dim strSql As String

            cboCharge.DataSource = Nothing

            strSql = _
        "SELECT		'' AS CHARGE_ID, '' AS DESCRIPTION " & _
        "UNION " & _
        "SELECT		Charge_Id, RTRIM(ISNULL(DESCRIPTION, '')) AS DESCRIPTION " & _
        "FROM		mdb_cfg_charge WITH (Nolock) " & _
        "WHERE      ISNULL(CHARGE_CD, '') <> 'SET_UP' " & _
        "ORDER BY	DESCRIPTION "

            dt = db.DataTable(strSql)

            cboCharge.DataSource = dt

            cboCharge.DisplayMember = "DESCRIPTION"
            cboCharge.ValueMember = "Charge_Id"

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub FindItems()
        Try

            cboColor.DataSource = Nothing

            Dim dt As DataTable
            Dim strSql As String

            strSql =
            "  select top 1  CAST(Null AS char(75)) as user_def_fld_1, CAST(Null AS char(75)) as user_def_fld_2, " &
            " CAST(Null AS char(30)) as item_no,CAST(Null AS char(30)) as item_note_5, " &
            " CAST(Null AS char(30)) as item_desc_1,CAST(Null AS char(30)) as item_desc_2, CAST(Null AS char(30)) as search_desc, " &
            " CAST(Null AS char(1)) as   end_item_cd,CAST(Null AS char(1)) as  kit_feat_fg,CAST(Null AS  numeric(9,0)) as ID from imitmidx_sql " &
            " union " &
            " Select user_def_fld_1,user_def_fld_2,RTRIM(imitmidx_sql.item_no),item_note_5,item_desc_1, item_desc_2,search_desc, " &
            " end_item_cd,kit_feat_fg, ID from imitmidx_sql left join item_pictures it on imitmidx_sql.item_no  = it.item_no " &
            " where user_def_fld_1 = '" & Trim(txtItemCd.Text) & "'   and  imitmidx_sql.activity_cd = 'A'  " &
            " union " &
            " Select user_def_fld_1,user_def_fld_2,RTRIM(imitmidx_sql.item_no),item_note_5,item_desc_1, item_desc_2,search_desc, " &
            " end_item_cd,kit_feat_fg, ID from imitmidx_sql where user_def_fld_1 = '66" & Trim(txtItemCd.Text) & "' and item_no like '%BLK%'"



            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                If dt.Rows.Count = 1 Then

                    lblItemDesc.Text = Trim(dt.Rows(0).Item("item_desc_1").ToString)
                    cboColor.DataSource = dt

                    cboColor.DisplayMember = "item_no"
                    cboColor.ValueMember = "ID"
                ElseIf dt.Rows.Count > 1 Then
                    lblItemDesc.Text = Trim(dt.Rows(1).Item("item_desc_1").ToString)
                    cboColor.DataSource = dt

                    cboColor.DisplayMember = "item_no"
                    cboColor.ValueMember = "ID"
                End If

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Item_Picture()
        Try
            Dim strSql As String
            Dim dt As DataTable

            If cboColor.SelectedIndex <= 0 Then Exit Sub

            If cboColor.Text <> "" Then

                strSql =
                    " select * from item_pictures " &
                    " where (item_no = '" & Trim(cboColor.Text) & "' or item_no =  'SPECTOR') "


                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then

                    picture = dt.Rows(0).Item("picture")

                    strSql = "Select COALESCE(NullIf(x,''),'0') As x, COALESCE(NullIf(y,''),'0') As y, " &
                             "  COALESCE(NullIf(z,''),'0') AS z  from  item_size where  item_cd = '" & txtItemCd.Text & "'"

                    '++ID 12062024
                    strSql = " select p.ITEM_MASTER_ID , p.ITEM_CD , p.ItemStatus , p.SIZE_X As x , p.SIZE_Y As y , p.SIZE_Z As z , " _
                   & " p.WEIGHT , p.WEIGHT_W_PKG from MDB_ITEM_FLD_PIVOT_ION p  " _
                   & " where    p.ItemStatus = 'lau' " _
                   & " And ISNULL(Cast(p.SIZE_X As Decimal(10, 2)), 0.00) <> 0.00 And ISNULL(Cast(SIZE_Y As Decimal(10,2)),0.00) <> 0.00  " _
                   & " And p.ITEM_CD  = '" & txtItemCd.Text & "' "


                    dt = db.DataTable(strSql)

                    If dt.Rows.Count <> 0 Then
                        txtWidth.Text = dt.Rows(0).Item("x").ToString  '* 2.54
                        txtHeight.Text = dt.Rows(0).Item("y").ToString  '* 2.54
                        txtDepth.Text = dt.Rows(0).Item("z").ToString
                    Else
                        txtWidth.Text = "0"
                        txtHeight.Text = "0"
                        txtDepth.Text = "0"
                    End If
                Else

                    strSql = "Select COALESCE(NullIf(x,''),'0') As x, COALESCE(NullIf(y,''),'0') As y, " &
                                "  COALESCE(NullIf(z,''),'0') AS z  from  item_size where  item_cd = '" & txtItemCd.Text & "'"

                    '++ID 12062024
                    strSql = " select p.ITEM_MASTER_ID , p.ITEM_CD , p.ItemStatus , p.SIZE_X As x , p.SIZE_Y As y , p.SIZE_Z As z , " _
                   & " p.WEIGHT , p.WEIGHT_W_PKG from MDB_ITEM_FLD_PIVOT_ION p  " _
                   & " where     p.ItemStatus = 'lau' " _
                   & " And ISNULL(Cast(p.SIZE_X As Decimal(10, 2)), 0.00) <> 0.00 And ISNULL(Cast(SIZE_Y As Decimal(10,2)),0.00) <> 0.00  " _
                   & " And p.ITEM_CD  = '" & txtItemCd.Text & "' "



                    dt = db.DataTable(strSql)

                    If dt.Rows.Count <> 0 Then
                        txtWidth.Text = dt.Rows(0).Item("x").ToString  '* 2.54
                        txtHeight.Text = dt.Rows(0).Item("y").ToString  '* 2.54
                        txtDepth.Text = dt.Rows(0).Item("z").ToString
                    Else
                        txtWidth.Text = "0"
                        txtHeight.Text = "0"
                        txtDepth.Text = "0"
                    End If

                    picture = Nothing
                    pictBox.Image = Nothing
                End If
            Else
                picture = Nothing
                pictBox.Image = Nothing

                txtWidth.Text = "0"
                txtHeight.Text = "0"
                txtDepth.Text = "0"

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'unusable function , it display image proofread by
    Private Sub Item_PictureProof()
        Try
            Dim strSql As String
            Dim dt As DataTable

            If cboColor.Text <> "" Then

                strSql = _
                     "Select * from item_pictures where item_no = 'ProofRead'"

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then

                    picture = dt.Rows(0).Item("picture")

                Else
                    picture = Nothing
                    pictBox.Image = Nothing
                End If
            Else
                picture = Nothing
                pictBox.Image = Nothing
            End If

            Call PreviewDoc(pictBox)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'return Currency of Client
    Private Function Currency(ByVal cus_cd As String) As String
        Currency = ""

        Dim strSql As String
        Dim dt As DataTable

        strSql = " select Currency from cicmpy  where cmp_code = '" & cus_cd & "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            Currency = Trim(dt.Rows(0).Item("Currency").ToString)
        End If
    End Function
    'return currency $
    Private Function Curr(ByRef txt As TextBox) As TextBox

        Curr = txt

        If Curr.Text = String.Empty Then Curr.Text = 0.0

        Dim c As Double = CDbl(Curr.Text)

        Curr.Text = c.ToString("C", New Globalization.CultureInfo("en-US"))

    End Function
    'return currency $ for  DataGridViewTextBoxColumn
    Private Function DGVCurr(ByRef dgvTxt As DataGridViewTextBoxColumn) As DataGridViewTextBoxColumn

        DGVCurr = dgvTxt

        DGVCurr.DefaultCellStyle.Format = "C"

    End Function
    'return Charge - ITEM_NO
    Private Function Charge_Item_No(ByRef cbCharge As ComboBox) As String

        Charge_Item_No = ""

        Dim strSql As String
        Dim dt As DataTable

        strSql = _
            " select item_no from MDB_CFG_CHARGE With (NOLOCK) " & _
            " where charge_id = " & cbCharge.SelectedValue

        dt = db.DataTable(strSql)

        Charge_Item_No = Trim(dt.Rows(0).Item("item_no").ToString)

    End Function

    'return price for RunCharge
    Private Sub PriceRunCharge()
        Try
            Dim strSql As String
            Dim dt As DataTable

            If cboCharge.SelectedIndex <> 0 Then

                strSql = _
                    " SELECT  prc_or_disc_1, RTRIM(cd_tp_1_item_no)  FROM oeprcfil_sql  WITH (Nolock) " & _
                    " where curr_cd = '" & Trim(txtCurrency.Text) & "' And cd_tp = 1  " & _
                    " And cd_tp_3_cust_type = '' and cd_tp_1_cust_no = '" & Trim(txtCusNo.Text) & "' " & _
                    " and  cd_tp_1_item_no = '" & Charge_Item_No(cboCharge) & "' and end_dt > GETDATE()  "

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then
                    lblCharge_ItemNo.Visible = True
                    lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                    lblCharge_ItemNo.BackColor = Color.Yellow
                    lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                    txtRunCharge.Text = FormatNumber(CDbl(dt.Rows(0).Item("prc_or_disc_1")), 3)
                    Call Curr(txtRunCharge)
                Else

                    strSql = _
                        " SELECT  prc_or_disc_1, RTRIM(cd_tp_1_item_no)  FROM oeprcfil_sql WITH (Nolock) " & _
                         " where  curr_cd = '" & Trim(txtCurrency.Text) & "' And cd_tp = 6  " & _
                        " And cd_tp_3_cust_type = '' and cd_tp_1_cust_no = '' " & _
                        " and  cd_tp_1_item_no = '" & Charge_Item_No(cboCharge) & "' and end_dt > GETDATE()  "

                    dt = db.DataTable(strSql)
                    If dt.Rows.Count <> 0 Then
                        lblCharge_ItemNo.Visible = True
                        lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                        lblCharge_ItemNo.BackColor = Color.Yellow
                        lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                        txtRunCharge.Text = FormatNumber(CDbl(dt.Rows(0).Item("prc_or_disc_1")), 3)
                        Call Curr(txtRunCharge)

                    Else
                        lblCharge_ItemNo.Visible = True
                        lblCharge_ItemNo.BorderStyle = BorderStyle.FixedSingle
                        lblCharge_ItemNo.BackColor = Color.Yellow
                        lblCharge_ItemNo.Text = Charge_Item_No(cboCharge)

                        txtRunCharge.Text = FormatNumber(CDbl(0.0), 3)
                        Call Curr(txtRunCharge)

                    End If

                End If
            Else

                txtRunCharge.Text = FormatNumber(CDbl(0.0), 3)
                Call Curr(txtRunCharge)
                lblCharge_ItemNo.Visible = False
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    '--------------------------------
    'resize image , it means handle with real item
    Private Sub ResizeImage(ByVal pImage As String, ByVal widthImg As Int32, ByVal height As Int32, ByRef picBox As PictureBox)
        Try
            Dim mStream As New ADODB.Stream
            Dim strName As String = pImage

            Dim strCopyName As String



            strCopyName = pImage.Substring(pImage.LastIndexOf("\") + 1, (pImage.LastIndexOf(".")) - (pImage.LastIndexOf("\") + 1)) & Guid.NewGuid.ToString & pImage.Substring(pImage.LastIndexOf("."))

            'strCopyName = pImage.Substring(pImage.LastIndexOf("\") + 1, (pImage.LastIndexOf(".")) - (pImage.LastIndexOf("\") + 1)) & pImage.Substring(pImage.LastIndexOf("."))


            Dim m_path As String = "C:\ExactTemp\" & strCopyName

            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            'Dim matchingProcesses = New List(Of Process)

            'For Each process As Process In process.GetProcesses()
            '    For Each m As ProcessModule In process.Modules
            '        If String.Compare(m.FileName, m_path, StringComparison.InvariantCultureIgnoreCase) = 0 Then
            '            matchingProcesses.Add(process)
            '            Exit For
            '        End If
            '    Next
            'Next

            'For Each pr As Process In matchingProcesses
            '    pr.Kill()
            'Next
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            For Each p As Process In Process.GetProcesses
                Dim file As String
                Try
                    file = p.Modules(0).FileName
                    If file = m_path Then
                        MsgBox(file)
                    End If
                    Debug.Print("Process : " & p.ProcessName & ", " & file)
                Catch ex As Exception
                    file = "n/a"
                End Try
            Next
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            If Not File.Exists(m_path) Then
                My.Computer.FileSystem.CopyFile(pImage, m_path, True)

            Else
                System.Threading.Thread.Sleep(2000)

                File.Delete(m_path)
                My.Computer.FileSystem.CopyFile(pImage, m_path, False)
            End If


            If File.Exists(pImage) Then
                System.Threading.Thread.Sleep(2000)

                File.Delete(pImage)

            End If

            Call DisplayPict(m_path, picBox)

            Dim imageToResize As Image = Image.FromFile(m_path)

            Dim newImage As New Bitmap(imageToResize, New System.Drawing.Size(widthImg, height))

            Dim stream As New MemoryStream

            Dim bt As Byte()

            '  Dim strImagePng As String = m_path.Remove(m_path.LastIndexOf(".")) & ".png"

            newImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)

            ' stream.Dispose()
            bt = stream.ToArray

            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()

            mStream.Write(bt)

            mStream.SaveToFile(strName, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            Call DisplayPict(strName, picBox)

            mStream.Close()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'return pixel
    Private Function converter(ByRef inch As Double) As Double
        converter = 0.0

        '1cm = 567 twips
        '1pixel = 15 twips
        converter = ((inch * 2.54) * 567) / 15

    End Function
    'return prepares the image for to be displayed
    Private Sub PreviewDoc(ByRef picBox As PictureBox)

        Try
            Dim mStream As New ADODB.Stream

            If picture Is Nothing Then Exit Sub

            Dim m_path As String = "C:\ExactTemp\"
            Dim strPathAndFile As String



            strPathAndFile = m_path & Trim(cboColor.Text) & Guid.NewGuid.ToString & ".jpeg"


            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()

            mStream.Write(picture)

            mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)


            mStream.Close()

            Call DisplayPict(strPathAndFile, picBox)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    ' return display image from PreviewDoc
    Private Sub DisplayPict(ByVal strPath As String, ByRef picBox As PictureBox)
        Try

            Dim imgOrg As Bitmap
            Dim imgShow As Bitmap
            Dim g As Graphics
            Dim divideBy, divideByH, divideByW As Double


            imgOrg = CType(Image.FromFile(strPath, True), Bitmap) 'DirectCast(Bitmap.FromStream(ms), Bitmap)

            divideByW = imgOrg.Width / picBox.Width
            divideByH = imgOrg.Height / picBox.Height
            If divideByW > 1 Or divideByH > 1 Then
                If divideByW > divideByH Then
                    divideBy = divideByW
                Else
                    divideBy = divideByH
                End If

                imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            Else
                imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            End If
            imgOrg.Dispose()
            picBox.Image = imgShow

            picBox.Image.Tag = strPath

            picBox.Refresh()

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ############### Maintenance for DataGridView ########################"

    Private Enum Column
        item_cd
        item_no
        description
        price
        decorating
        deco_id
        setup
        charge
        charge_id
        run_charge
        Min_Qty_Ord
        item_w 'item width
        item_h 'item height
        item_path
    End Enum

    Private Sub CreateColumns(ByRef dgv As DataGridView)
        Try
            With dgv.Columns
                .Add(DGVTextBoxColumn("item_cd", "ItemCd", 60))

                If dgv.Name <> "dgvResult" Then
                    .Add(DGVTextBoxColumn("item_no", "Item No", 100))
                    .Add(DGVTextBoxColumn("description", "Desc", 100))
                    .Add(DGVCurr(DGVTextBoxColumn("price", "Price", 80)))
                    .Add(DGVTextBoxColumn("decorating", "Deco", 100))
                    .Add(DGVTextBoxColumn("deco_id", "Deco_Id", 50))
                    .Add(DGVCurr(DGVTextBoxColumn("setup", "Setup", 80)))
                    .Add(DGVTextBoxColumn("charge", "Charge", 100))
                    .Add(DGVTextBoxColumn("charge_id", "Charge_ID", 50))
                    .Add(DGVCurr(DGVTextBoxColumn("run_charge", "Run Charge", 100)))
                ElseIf dgv.Name = "dgvResult" Then
                    .Add(DGVTextBoxColumn("item_no", "Item No", 165))
                    .Add(DGVTextBoxColumn("description", "Desc", 100))
                    .Add(DGVCurr(DGVTextBoxColumn("price", "Price", 80)))
                    .Add(DGVTextBoxColumn("decorating", "Decorating", 100))
                    .Add(DGVTextBoxColumn("deco_id", "Deco_Id", 50))
                    .Add(DGVCurr(DGVTextBoxColumn("setup", "Setup", 80)))
                    .Add(DGVTextBoxColumn("charge", "Charge", 100))
                    .Add(DGVTextBoxColumn("charge_id", "Charge_Id", 50))
                    .Add(DGVCurr(DGVTextBoxColumn("run_charge", "Run Charge", 100)))
                End If

                .Add(DGVTextBoxColumn("Min_Qty_Ord", "Qty", 80))
                .Add(DGVTextBoxColumn("item_w", "Inch_W", 80))
                .Add(DGVTextBoxColumn("item_h", "Inch_H", 80))
                .Add(DGVTextBoxColumn("item_path", "Path", 200))
            End With

            With dgv
                If .Name <> "dgvResult" Then
                    .RowTemplate.Height = 20
                    .Columns(Column.description).Visible = False
                    .Columns(Column.Min_Qty_Ord).Visible = False
                    .Columns(Column.item_path).Visible = False
                    .Columns(Column.deco_id).Visible = False
                    .Columns(Column.charge_id).Visible = False
                ElseIf .Name = "dgvResult" Then
                    .ColumnHeadersVisible = False
                    .Columns(Column.description).Visible = False
                    .Columns(Column.Min_Qty_Ord).Visible = False
                    .Columns(Column.item_cd).Visible = False
                    '.Columns(Column.item_no).Visible = False
                    .Columns(Column.item_w).Visible = False
                    .Columns(Column.item_h).Visible = False
                    .Columns(Column.item_path).Visible = False
                    .Columns(Column.deco_id).Visible = False
                    .Columns(Column.charge_id).Visible = False
                End If


                With .DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Font = New Font("Ariel", 9)
                    '    .ForeColor = Color.BlueViolet
                    '  .SelectionBackColor = Color.WhiteSmoke
                End With
                .ColumnHeadersDefaultCellStyle.Font = New Font("Ariel", 9)
                '   .ColumnHeadersHeight = 10
                '.ColumnHeadersDefaultCellStyle.Format = 30

            End With


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Display info
    Private Sub DisplayItem(ByRef dgv As DataGridView)
        Try
            ' Dim dt As DataTable
            Dim strSql As String

            strSql = _
                   " select Cast(Null As char(10)) as item_cd, " & _
                   " Cast(Null AS varchar(25)) as item_no, " & _
                   " Cast(Null AS varchar(255)) As description, " & _
                   " Cast(Null AS decimal(16,6)) AS price, " & _
                   " Cast(Null AS varchar(250)) As decorating, " & _
                   " Cast(Null As INT) As deco_id, " & _
                   " Cast(Null AS decimal(16,6)) AS setup, " & _
                   " Cast(Null As varchar(250)) As charge,  " & _
                   " Cast(Null As int) As charge_id, " & _
                   " Cast(Null AS decimal(16,6)) As run_charge, " & _
                   " Cast(Null As decimal(16,6)) As Min_Qty_Ord, " & _
                   " Cast(Null AS decimal(16,6)) As item_w, " & _
                   " Cast(Null As decimal(16,6)) AS item_h, " & _
                   " Cast(Null As varchar(250)) As item_path   "

            dt = db.DataTable(strSql)

            dgv.DataSource = dt

            dgv.AllowUserToDeleteRows = True
            dgv.Rows.Remove(dgv.CurrentRow)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Display Result
    Private Sub DisplayResult(ByRef dgv As DataGridView)
        Try
            ' Dim dTable As DataTable
            Dim strSql As String
            db = New cDBA
            strSql = _
                   " select Cast(Null As char(10)) as item_cd, " & _
                   " Cast(Null AS varchar(25)) as item_no, " & _
                   " Cast(Null AS varchar(255)) As description, " & _
                   " Cast(Null AS decimal(16,6)) AS price, " & _
                   " Cast(Null AS varchar(250)) As decorating, " & _
                   " Cast(Null As INT) As deco_id, " & _
                   " Cast(Null AS decimal(16,6)) AS setup, " & _
                   " Cast(Null As varchar(250)) As charge,  " & _
                   " Cast(Null As int) As charge_id, " & _
                   " Cast(Null AS decimal(16,6)) As run_charge, " & _
                   " Cast(Null As decimal(16,6)) As Min_Qty_Ord, " & _
                   " Cast(Null AS decimal(16,6)) As item_w, " & _
                   " Cast(Null As decimal(16,6)) AS item_h, " & _
                   " Cast(Null As varchar(250)) As item_path   "

            dTable = db.DataTable(strSql)

            dgv.DataSource = dTable

            'dgv.AllowUserToDeleteRows = True
            'dgv.Rows.Remove(dgv.CurrentRow)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub addLineDGV(ByRef dgv As DataGridView)
        Try
            oOeprcfil_sql = New cOeprcfil_sql_Pack
            oOeprcfil_sql.Cus_No = Trim(txtCusNo.Text)
            oOeprcfil_sql.Item_No = Trim(cboColor.Text)
            oOeprcfil_sql.Curr_Cd = Trim(txtCurrency.Text)
            oOeprcfil_sql.Quantity = txtQty.Text

            drRowNew = dt.NewRow

            drRowNew("item_cd") = Trim(txtItemCd.Text)
            drRowNew("item_no") = Trim(cboColor.Text)
            drRowNew("description") = Trim(lblItemDesc.Text)
            drRowNew("price") = Decimal.Round(oOeprcfil_sql.displayPrice(p_Program), 3)

            If cboDecoMetod.Text <> String.Empty Then drRowNew("decorating") = Trim(cboDecoMetod.Text)

            drRowNew("deco_id") = cboDecoMetod.SelectedValue

            drRowNew("setup") = CDbl(txtSetup.Text)

            '   If cboCharge.Text <> String.Empty Then drRowNew("charge") = Trim(cboCharge.Text)

            If Not cboCharge.SelectedItem Is Nothing Then
                drRowNew("charge_id") = cboCharge.SelectedValue
                drRowNew("charge") = Trim(cboCharge.Text)
            Else
                drRowNew("charge_id") = 0
                drRowNew("charge") = Trim(cboCharge.Text)
            End If

            '    drRowNew("charge_id") = cboCharge.SelectedValue
            drRowNew("run_charge") = CDbl(txtRunCharge.Text)
            drRowNew("Min_Qty_Ord") = CDbl(txtQty.Text)
            drRowNew("item_w") = CDbl(txtWidth.Text)
            drRowNew("item_h") = CDbl(txtHeight.Text)

            'pictBox.Image.Tag

            If Not IsNothing(pictBox.Image) Then
                drRowNew("item_path") = pictBox.Image.Tag
            Else
                drRowNew("item_path") = ""
            End If


            dt.Rows.Add(drRowNew)

            dgv.DataSource = dt
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub addLineDGVResult(ByRef dgv As DataGridView)
        Try
            Dim price As Decimal = 0.0
            Dim setup As Decimal = 0.0
            Dim run_charge As Decimal = 0.0

            For Each dgvR As DataGridViewRow In dgvItem.Rows

                price = CDbl(price) + CDbl(dgvR.Cells("price").Value)
                setup = CDbl(setup) + CDbl(dgvR.Cells("setup").Value)
                run_charge = CDbl(run_charge) + CDbl(dgvR.Cells("run_charge").Value)
            Next

            Debug.Print(price)
            dgvResult.Rows(0).Cells(Column.item_no).Value = "Total price : "
            dgvResult.Rows(0).Cells(Column.price).Value = price
            dgvResult.Rows(0).Cells(Column.setup).Value = setup
            dgvResult.Rows(0).Cells(Column.run_charge).Value = run_charge

            '  txtPriceSet.Text = " TOTAL: PRICE + SETUP + CHARGE :  " & CDbl(price + setup + run_charge).ToString("C", New Globalization.CultureInfo("en-US"))
            txtPriceSet.Text = " TOTAL PRICE : " & CDbl(price).ToString("C", New Globalization.CultureInfo("en-US"))


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub rowDelete(ByRef dgv As DataGridView)
        Try
            dgv.AllowUserToDeleteRows = True
            dgv.Rows.Remove(dgv.CurrentRow)
            dgv.AllowUserToDeleteRows = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

    Private Sub btnResize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResize.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Call ResizeImage(pictBox.Image.Tag, converter(CDbl(txtWidth.Text)), converter(CDbl(txtHeight.Text)), pictBox)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnCustomized_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomized.Click
        Try

            Dim frmCreateM As New frmCreateMultiplePictureBox
            frmCreateM.lblClient.Text = Trim(oMdb_Cus_Prog.Cus_No)
            frmCreateM.lblCus_Prog_Id.Text = oMdb_Cus_Prog.Cus_Prog_Id


            frmCreateM.Show()
            Call SetTimer()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            dgvItem.AllowUserToAddRows = True

            Call addLineDGV(dgvItem)

            Call addLineDGVResult(dgvResult)

            dgvItem.AllowUserToAddRows = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tsBtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsBtnDelete.Click
        Try

            Call rowDelete(dgvItem)
            Call addLineDGVResult(dgvResult)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub tsRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsRefresh.Click
        Try
            dgvItem.Refresh()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnAddImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddImage.Click
        Try
            Dim strname As String
            opFile.Title = "Open File Dialog"
            opFile.InitialDirectory = "C:\"

            If opFile.ShowDialog() = DialogResult.OK Then

                strname = opFile.FileName
                Label2.Text = strname
            End If

            DisplayPict(Label2.Text, pictBox)


        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim oItem_Picture As New cItem_Picture_Pack(Trim(Label2.Text))

            oItem_Picture.Item_No = "ProofRead"
            oItem_Picture.Catalog_Item_Num = "Proof"

            oItem_Picture.W_Pixels = 400
            oItem_Picture.H_Pixels = 400
            oItem_Picture.OEI_W_Pixels = 400
            oItem_Picture.OEI_H_Pixels = 400

            oItem_Picture.Rotate = String.Empty

            oItem_Picture.Save()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



    Private Sub tlStripBtnAddBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlStripBtnAddBox.Click
        Try
            dgvItem.AllowUserToAddRows = True
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItem_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvItem.CellBeginEdit
        Try
            dgvItem.AllowUserToAddRows = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellDoubleClick
        Try
            If dgvItem.CurrentRow.Cells(Column.item_path).Value <> "" Then
                Call DisplayPict(dgvItem.CurrentRow.Cells(Column.item_path).Value, pictBox)
            Else
                pictBox.Image = Nothing
            End If

            '  dgvItem.AllowUserToAddRows = False
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellEndEdit
        Try

            dgvItem.AllowUserToAddRows = False

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItem_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvItem.DragOver
        Try
            e.Effect = DragDropEffects.Move
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub dgvItem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvItem.MouseMove
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim clientPoint As Point = dgvItem.PointToClient(New Point(e.X, e.Y))
                Dim info As DataGridView.HitTestInfo = dgvItem.HitTest(clientPoint.X, clientPoint.Y)

                If dgvItem.CurrentRow.Cells(Column.item_path).Value <> "" Then
                    dgvItem.DoDragDrop(dgvItem.CurrentRow.Cells(Column.item_path).Value, DragDropEffects.Copy)
                Else
                    MsgBox("This Item does not contain image.")
                End If

            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtCusNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusNo.LostFocus
        Try
            txtCurrency.Text = Currency(Trim(txtCusNo.Text))
            txtItemCd.Focus()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region " Create Flash for X & Y "
    Private Sub Arrow(ByRef e As System.Windows.Forms.PaintEventArgs)
        Try

            Dim pen As New Pen(Color.FromArgb(0, 0, 0), 8)

            Dim cap1 As New AdjustableArrowCap(1, 1, False)
            Dim cap2 As New AdjustableArrowCap(2, 1)

            cap1.BaseCap = LineCap.Round
            cap1.BaseInset = 1
            cap1.StrokeJoin = LineJoin.Bevel
            cap2.WidthScale = 1
            cap2.BaseCap = LineCap.Square
            cap2.Height = 1

            '   pen.CustomStartCap = cap1
            pen.CustomEndCap = cap2
            'pen.EndCap = LineCap.RoundAnchor
            'pen.StartCap = LineCap.ArrowAnchor
            e.Graphics.DrawLine(pen, 10, 10, 385, 10)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Arrow2(ByRef e As System.Windows.Forms.PaintEventArgs)
        Try

            Dim pen As New Pen(Color.FromArgb(0, 0, 0), 8)

            Dim cap1 As New AdjustableArrowCap(1, 1, False)
            Dim cap2 As New AdjustableArrowCap(2, 1)

            cap1.BaseCap = LineCap.Round
            cap1.BaseInset = 1
            cap1.StrokeJoin = LineJoin.Bevel
            cap2.WidthScale = 1
            cap2.BaseCap = LineCap.Square
            cap2.Height = 1

            '   pen.CustomStartCap = cap1
            pen.CustomEndCap = cap2
            'pen.EndCap = LineCap.RoundAnchor
            'pen.StartCap = LineCap.ArrowAnchor
            e.Graphics.DrawLine(pen, 20, 399, 20, 10)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Call Arrow(e)
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        Try
            Call Arrow2(e)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub



    Private Sub cboCharge_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCharge.SelectedIndexChanged
        Try

            Call PriceRunCharge()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtSetup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSetup.LostFocus
        Try

            Call Curr(txtSetup)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtRunCharge_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRunCharge.LostFocus
        Try

            Call Curr(txtRunCharge)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub cboDecoMetod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDecoMetod.SelectedIndexChanged
        Try
            If cboDecoMetod.SelectedIndex = 0 Then
                txtSetup.Text = FormatNumber(CDbl(0.0), 3)
                Call Curr(txtSetup)
            End If

        Catch ex As Exception

        End Try
    End Sub

    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    Public Property PRISCREEN As String
        Get
            PRISCREEN = printScreen
        End Get
        Set(ByVal value As String)
            printScreen = value
        End Set
    End Property

    '^^^^^^^^^^^^^^^^^^Tiemr functions^^^^^^^^^^^^^^^^^^^^^^^^
    Private Sub SetTimer()
        ' Create a timer with a two second interval.
        aTimer = New System.Timers.Timer(8000)
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = True
        aTimer.Enabled = True
    End Sub
    ' The event handler for the Timer.Elapsed event. 

    Private Strt As System.Threading.Thread

    Private Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Debug.Print("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime)
        'Debug.Print(GetSetting("CustomerFile", "frmCreateMultiplePictureBox", "pack_code", "").ToString)
        '   Dim pack_code As String = GetSetting("CustomerFile", "frmCreateMultiplePictureBox", "pack_code", "").ToString

        Dim Strt As System.Threading.Thread

        If pack_code.Length <> 0 And frm_pack_close = True Then

            Strt = New System.Threading.Thread(AddressOf MyThread1)
            Strt.Start()

            aTimer.Stop()
            aTimer.Dispose()

           
        End If
    End Sub
    Sub MyThread1()
        ' Working code

        Call AccessControl()

    End Sub
    Private Sub AccessControl()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControl))
        Else

            ' Code wasn't working in the threading sub
            If pack_code = "" And frm_pack_close = False Then Exit Sub

            txtItemCd.Focus()
            txtItemCd.Text = pack_code
            cboColor.Focus()
            cboColor.SelectedIndex = 1

            dgvItem.AllowUserToAddRows = True

            Call addLineDGV(dgvItem)

            Call addLineDGVResult(dgvResult)

            dgvItem.AllowUserToAddRows = False

            pack_code = ""
            frm_pack_close = False

        End If
    End Sub

End Class