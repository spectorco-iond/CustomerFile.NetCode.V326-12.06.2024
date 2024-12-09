Imports System.IO

Public Class frmAllsku
    Dim db As cDBA
    Dim dtT As DataTable
    Dim oOeprcfil_sql As cMacolaOeprcfil_Sql
    Dim pITEM_CD As String = "EC116"
    Dim pITEM_COLOR As String = "ALL"
    Private m_Program_BUS As New cMdb_Cus_Prog_BUS()
    Private m_Program As cMdb_Cus_Prog
    Private m_Customer As cCustomer
    Private dtItem As DataTable
    Private myTxtMinQty() As TextBox '= {txtMinQty1, txtMinQty2, txtMinQty3}
    Private myTxtPrice() As TextBox '= {txtPrice1, txtPrice2, txtPrice3}
    Private myTxtQqpDisc() As TextBox '= {txtQqpDisc1, txtQqpDisc2, txtQqpDisc3}
    Private mychkEQP() As CheckBox '= {chkEQP1, chkEQP2, chkEQP3}
    Dim init As Int32 = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.

    End Sub
    'receive datatable for having same data
    Public Sub New(ByVal pItemCD As String, ByVal pDesc As String, ByRef dtItems As DataTable, ByRef p_Program As cMdb_Cus_Prog, ByRef p_Customer As cCustomer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_Program = p_Program
        m_Customer = p_Customer
        dtItem = dtItems
        strItemCd = Trim(pItemCD)
        strDesc = Trim(pDesc)
        Call fillDGVColor()

        '    Me.dgvColors.DefaultCellStyle.WrapMode = DataGridViewTriState.True




        dgvItems_CreateColumns()

        dgvItems.DataSource = dtItem.Clone
        'dgvItems_Fill(dtItems.Clone, m_Program)

        Call fillObjects()
        tlsDeliteLine.Visible = False

        btnAddReturn.Text &= " " & Prog_Type(m_Program.Prog_Type)
    End Sub
    Private Sub frmAllsku_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Select Case m_Program.Prog_Type
                Case 2
                    txtPrice1.ReadOnly = False
                    txtPrice2.ReadOnly = False
                    txtPrice3.ReadOnly = False
            End Select




            'check , If we need EQP only for the Program = true and Special PR,Quaote = false
            Call PopulateArrayObject()

            Call ActivateEQPChk()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub PopulateArrayObject()
        Try
            myTxtMinQty = {txtMinQty1, txtMinQty2, txtMinQty3}
            myTxtPrice = {txtPrice1, txtPrice2, txtPrice3}
            myTxtQqpDisc = {txtQqpDisc1, txtQqpDisc2, txtQqpDisc3}
            mychkEQP = {chkEQP1, chkEQP2, chkEQP3}
            mychkEQP = {chkEQP1, chkEQP2, chkEQP3}
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvColors_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvColors.CellClick
        Try

            If e.RowIndex = -1 Then Exit Sub
            '  MsgBox(dgvColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor.ToString) '"Color [DarkRed]"
            If dgvColors.Rows(e.RowIndex).Cells(colorall.picture).Value.ToString = "" Then
                pictBox1.Image = Nothing
                Exit Sub
            End If
            pictBox1.Image = ByteToImage(dgvColors.Rows(e.RowIndex).Cells(colorall.picture).Value)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkEQP1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEQP1.CheckStateChanged, chkEQP2.CheckStateChanged, chkEQP3.CheckStateChanged
        Try
            'make visibile textbox dependent chekbox
            Dim chk As CheckBox = CType(sender, CheckBox)

            'apply for update the data in objects
            Call PopulateArrayObject()

            myTxtQqpDisc(chk.Tag).Visible = chk.CheckState 'True

            If chk.CheckState <> CheckState.Checked Then
                myTxtQqpDisc(chk.Tag).Text = "0.00"
                myTxtPrice(chk.Tag).Text = ItemPrice(CInt(myTxtMinQty(chk.Tag).Text))
            End If


            If Trim(RTrim(myTxtMinQty(chk.Tag).Text)) = String.Empty Or CInt(myTxtMinQty(chk.Tag).Text) = 0 Then
                myTxtQqpDisc(chk.Tag).Text = "0.00"
                myTxtQqpDisc(chk.Tag).ReadOnly = True
            Else
                myTxtQqpDisc(chk.Tag).ReadOnly = False
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub chkAll_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.CheckStateChanged
        Try
            Dim checked As Int32
            If chkAll.CheckState = CheckState.Checked Then
                chkAll.Text = "Uncheck ALL"
                checked = 1
            Else
                chkAll.Text = "Check ALL"
                checked = 0
            End If

            Call UncheckAll(checked)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub tlsAddColors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlsAddColors.Click
        Try
            Debug.Print(dtItem.Rows.Count)
            dtT = New DataTable
            Dim index As Int32 = 0
            Dim dtRow As DataRow

            'apply for update the data in objects
            Call PopulateArrayObject()

            dtT = dtItem.Clone
            dgvItems.DataSource = dtT

            Do While index < 3
                If Trim(RTrim(myTxtMinQty(index).Text)) <> String.Empty And IsNumeric(myTxtPrice(index).Text) And CDbl(myTxtMinQty(index).Text) <> 0 Then

                    For Each dr As DataGridViewRow In dgvColors.Rows

                        If dr.Cells(0).EditedFormattedValue = True Then

                            dtRow = dtT.NewRow

                            dtRow(Items.PROD_CAT_ID) = 0
                            dtRow(Items.ITEM_CD) = Trim(strItemCd)
                            dtRow(Items.CUSTOM_ITEM_ID) = 0
                            dtRow(Items.ITEM_DESC) = Trim(strDesc)
                            dtRow(Items.ITEM_NO) = Trim(RTrim(dr.Cells(colorall.ITEM_NO).Value))
                            dtRow(Items.ITEM_COLOR) = Trim(RTrim(dr.Cells(colorall.COLOR).Value.ToString))

                            If Trim(cboQuoteTypeID.Text) <> "" Then
                                dtRow(Items.QUOTE_TYPE_ID) = cboQuoteTypeID.SelectedValue
                            Else
                                dtRow(Items.QUOTE_TYPE_ID) = 0
                            End If

                            dtRow(Items.ITEM_SUBSTITUTE) = "ITEM_SUBSTITUTE"


                            If Trim(cboQuoteShipMethodId.Text) <> "" Then
                                dtRow(Items.QUOTE_SHIP_METHOD_ID) = cboQuoteShipMethodId.SelectedValue
                            Else
                                dtRow(Items.QUOTE_SHIP_METHOD_ID) = 0
                            End If


                            dtRow(Items.MIN_QTY_ORD) = CInt(myTxtMinQty(index).Text)
                            dtRow(Items.UNIT_PRICE) = CDbl(myTxtPrice(index).Text)

                            'is not for quote
                            dtRow(Items.EQP_LEVEL) = mychkEQP(index).Checked

                            If myTxtQqpDisc(index).Text = String.Empty Then myTxtQqpDisc(index).Text = 0

                                dtRow(Items.EQP_PCT) = CDbl(myTxtQqpDisc(index).Text)

                                If CDbl(myTxtQqpDisc(index).Text) <> 0 And m_Program.Prog_Type = (Program_Types.Program + 1) Then

                                    dtRow(Items.NEED_APPROVAL) = 1

                                End If

                                If Trim(cboDecorating.Text) <> "" Then
                                    dtRow(Items.DEC_MET_ID) = cboDecorating.SelectedValue
                                Else
                                    dtRow(Items.DEC_MET_ID) = 0
                                End If

                                dtRow(Items.DEC_MET_GROUP_ID) = 0

                                dtRow(Items.SETUP_WAIVED) = chkSetupWaived.Checked

                                If Trim(txtSetupPrice.Text) <> "" Then
                                    dtRow(Items.SETUP_PRICE) = txtSetupPrice.Text
                                Else
                                    dtRow(Items.SETUP_PRICE) = 0
                                End If

                                If Trim(cboCharge.Text) <> "" Then
                                    dtRow(Items.CHARGE_ID) = cboCharge.SelectedValue
                                Else
                                    dtRow(Items.CHARGE_ID) = 0
                                End If

                                If Trim(txtRunCharge.Text) <> "" Then
                                    dtRow(Items.RUN_CHARGE) = txtRunCharge.Text
                                Else
                                    dtRow(Items.RUN_CHARGE) = 0
                                End If

                                If Trim(cboColorCount.Text) <> "" Then
                                    dtRow(Items.COLOR_COUNT) = cboColorCount.Text
                                Else
                                    dtRow(Items.COLOR_COUNT) = 0
                                End If

                                If Trim(cboLocationCount.Text) <> "" Then
                                    dtRow(Items.LOCATION_COUNT) = cboLocationCount.Text
                                Else
                                    dtRow(Items.LOCATION_COUNT) = 0
                                End If

                                If Trim(cboPack.Text) <> "" Then
                                    dtRow(Items.PACK_ID) = cboPack.SelectedValue
                                Else
                                    dtRow(Items.PACK_ID) = 0
                                End If
                                dtRow(Items.CUS_PROG_ITEM_LIST_GUID) = Guid.NewGuid.ToString

                                dtT.Rows.Add(dtRow)
                            End If
                    Next
                    index += 1
                Else
                    index += 1
                End If
            Loop
            If dtT.Rows.Count <> 0 Then

                btnAddReturn.Visible = True
                tlsDeliteLine.Visible = True

                dgvItems.DataSource = dtT

                dgvItems.AllowUserToAddRows = False
                dgvItems.AllowUserToOrderColumns = False

                tlsCountItems.Text = "Count " & dtT.Rows.Count
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub tlsDeliteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlsDeliteLine.Click
        Try
            For Each dr As DataGridViewRow In dgvItems.SelectedRows
                '      If dr.Selected Then
                dtT.Rows.RemoveAt(dr.Index)
                '  End If
            Next

            tlsCountItems.Text = "Count " & dtT.Rows.Count
            If dtT.Rows.Count = 0 Then
                btnAddReturn.Visible = False
                tlsDeliteLine.Visible = False
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#Region "-------------fill objects-------------------------"
    Private strItemCd As String
    Private strDesc As String
    Private Sub fillObjects()
        Try

            If Prog_Type(m_Program.Prog_Type) = "Quote" Or Prog_Type(m_Program.Prog_Type) = "Special Pricing" Then
                'chkEQP.Visible = False
                'lblEqpDisc.Visible = False
                'txtQqpDisc.Visible = False
            End If

            txtItemCd.Text = strItemCd.ToUpper
            txtDesc.Text = strDesc.ToUpper

            With cboQuoteTypeID
                .DataSource = m_Program_BUS.Get_Quote_Type_ComboList()
                .ValueMember = "Quote_Type_ID"
                .DisplayMember = "Quote_Type_Desc"
            End With
            With cboQuoteShipMethodId
                .DataSource = m_Program_BUS.Get_Quote_Ship_Method_ComboList()
                .ValueMember = "Quote_Ship_Method_ID"
                .DisplayMember = "Quote_Ship_Method_Desc"
            End With
            With cboDecorating
                .DataSource = ChangeCboDecoratingList()
                .ValueMember = "DEC_MET_ID" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "DEC_MET_CD"
            End With
            With cboPack
                .DataSource = ChangeCboPackagingList()
                .ValueMember = "PACK_ID" ' ColumnName.TitleOfCourtesy.ToString()
                .DisplayMember = "DESCRIPTION"
            End With
            With cboCharge
                .DataSource = ChangeCboChargeList()
                .ValueMember = "Charge_Id"
                .DisplayMember = "DESCRIPTION"
            End With
            For i As Int32 = 0 To 3
                cboColorCount.Items.Add(i)
                cboLocationCount.Items.Add(i)
            Next
            cboColorCount.SelectedIndex = 1
            cboLocationCount.SelectedIndex = 1
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'cboDecorating
    Public Function ChangeCboDecoratingList() As DataTable ' , ByVal pstrProd_Cat As String)
        ChangeCboDecoratingList = New DataTable
        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql = _
            "SELECT CAST(0 AS INT) AS DEC_MET_ID, CAST(' ' AS VARCHAR(20)) AS DEC_MET_CD " & _
            "UNION " & _
            "SELECT	DEC_MET_ID, DEC_MET_CD " & _
            "FROM MDB_CFG_DEC_MET WITH (NoLock) " & _
            "WHERE IMPRINT_LIST_ITEM = 1 " & _
            "ORDER BY	DEC_MET_CD "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboDecoratingList = dt

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Function
    'cbpPack
    Public Function ChangeCboPackagingList() As DataTable ' , ByVal pstrProd_Cat As String)
        ChangeCboPackagingList = New DataTable
        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'Route must match category from line item.
            Dim strSql As String

            strSql = _
            "SELECT CAST(0 AS INT) AS PACK_ID, CAST(' ' AS VARCHAR(50)) AS DESCRIPTION,CAST(' ' AS VARCHAR(20)) AS PACK_CD " & _
            "UNION      " & _
            "SELECT	PACK_ID, DESCRIPTION, PACK_CD " & _
            "FROM  MDB_CFG_PACK WITH (Nolock) " & _
            "ORDER BY PACK_CD "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboPackagingList = dt

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Function
    'cboCharge
    Public Function ChangeCboChargeList() As DataTable
        ChangeCboChargeList = New DataTable
        Try
            Dim strSql As String

            strSql = _
              " SELECT	 CAST(0 AS INT) AS CHARGE_ID, CAST(' ' AS VARCHAR(20)) AS DESCRIPTION " & _
              " UNION " & _
              " SELECT	Charge_Id, RTRIM(ISNULL(DESCRIPTION, '')) AS DESCRIPTION " & _
              " FROM mdb_cfg_charge WITH (Nolock) " & _
              " WHERE ISNULL(CHARGE_CD, '') <> 'SET_UP' " & _
              " ORDER BY DESCRIPTION "

            Dim dt As New DataTable
            Dim db As New cDBA
            dt = db.DataTable(strSql)

            ChangeCboChargeList = dt

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Prog_Type(ByVal intType As Int32) As String
        Prog_Type = ""
        Try

            Select Case intType
                Case 1
                    Return "Program"
                    ' m_Program.Prog_Type = 1
                Case 2
                    Return "Special Pricing"
                    '  m_Program.Prog_Type = 2
                Case 3
                    Return "Quote"
                    '  m_Program.Prog_Type = 3
            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "-------------dgvItems maintenance-----------------"
    Private Sub dgvItems_CreateColumns()
        Try
            With dgvItems.Columns
                If .Count > 0 Then
                    For iCol = .Count To 1 Step -1
                        .RemoveAt(iCol - 1)
                    Next
                End If

                '.Add(DGVTextBoxColumn("FirstCol", "FirstCol", 0))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_ID", "CUS_PROG_ITEM_LIST_ID", 20))
                .Add(DGVTextBoxColumn("CUS_PROG_ID", "CUS_PROG_ID", 100))

                .Add(DGVTextBoxColumn("PROD_CAT_ID", "Category", 100))

                .Add(DGVTextBoxColumn("ITEM_CD", "Item", 80))
                .Add(DGVCheckBoxColumn("ITEM_COMMENT_LOGO", "ITEM_COMMENT_LOGO", 50))  'justin add 20230531

                .Add(DGVCheckBoxColumn("Selectrow", "Select", 50))

                .Add(DGVTextBoxColumn("CUSTOM_ITEM_ID", "Custom Item", 100))

                .Add(DGVTextBoxColumn("ITEM_DESC", "Description", 130))
                .Add(DGVTextBoxColumn("Disco", "Disco", 80))
                .Add(DGVTextBoxColumn("ITEM_NO", "SKU", 100))

                .Add(DGVTextBoxColumn("ITEM_COLOR", "Color", 100))

                .Add(DGVTextBoxColumn("Quote_Type_ID", "Quote_Type_ID", 100))

                .Add(DGVTextBoxColumn("Quote_Ship_Method_ID", "Quote_Ship_Method_ID", 100))

                '.Add(DGVComboBoxColumn("ITEM_COLOR", "Color", 100))
                .Add(DGVTextBoxColumn("MIN_QTY_ORD", "Min Qty", 60)) ' 80
                .Add(DGVTextBoxColumn("UNIT_PRICE", "Price", 60)) ' 80
                .Add(DGVCheckBoxColumn("EQP_LEVEL", "EQP", 40)) ' 50 
                .Add(DGVTextBoxColumn("EQP_PCT", "EQP Disc %", 60))

                .Add(DGVTextBoxColumn("DEC_MET_ID", "Decorating", 100))
                .Add(DGVTextBoxColumn("DEC_MET_GROUP_ID", "Decorating", 100))

                .Add(DGVCheckBoxColumn("SETUP_WAIVED", "Setup Waived", 50))
                .Add(DGVTextBoxColumn("SETUP_PRICE", "Special Setup Price", 80))

                .Add(DGVTextBoxColumn("CHARGE_ID", "Charge", 80))

                .Add(DGVTextBoxColumn("RUN_CHARGE", "Run Charge", 80))

                .Add(DGVTextBoxColumn("COLOR_COUNT", "COLOR COUNT", 80))
                .Add(DGVTextBoxColumn("LOCATION_COUNT", "LOCATION COUNT", 80))

                .Add(DGVTextBoxColumn("PACK_ID", "Packaging", 100))

                '.Add(DGVCheckBoxColumn("OVERSEAS", "Overseas", 60))
                '.Add(DGVCheckBoxColumn("DOMESTIC", "Domestic", 60))

                'comboboxColumn = DGVComboBoxColumn("REFILL_ID", "Refill", 50)
                'SetColorCombo(comboboxColumn)
                'dgvItems.Columns.Add(comboboxColumn)

                .Add(DGVTextBoxColumn("USER_LOGIN", "Entered By", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "Entered Date", 80))

                .Add(DGVTextBoxColumn("DIRTY", "DIRTY", 80))
                .Add(DGVTextBoxColumn("CUS_PROG_ITEM_LIST_GUID", "ITEM GUID", 1))
                .Add(DGVTextBoxColumn("LINE_COMMENTS", "Comments", 80))
                '++ID
                .Add(DGVButtonColumn("Image", "Image", 60))
                .Add(DGVTextBoxColumn("DocId", "Doc Id", 50))
                .Add(DGVCheckBoxColumn("Need_Approval", "Need Approval", 50))
            End With

            With dgvItems
                .Columns(Items.CUS_PROG_ITEM_LIST_ID).Visible = False
                .Columns(Items.CUS_PROG_ID).Visible = False
                .Columns(Items.PROD_CAT_ID).Visible = False
                .Columns(Items.ITEM_CD).Visible = True
                .Columns(Items.CUSTOM_ITEM_ID).Visible = False
                .Columns(Items.ITEM_DESC).Visible = True
                .Columns(Items.ITEM_NO).Visible = True
                .Columns(Items.ITEM_COLOR).Visible = True
                .Columns(Items.QUOTE_TYPE_ID).Visible = False
                .Columns(Items.QUOTE_SHIP_METHOD_ID).Visible = False
                .Columns(Items.MIN_QTY_ORD).Visible = True
                .Columns(Items.UNIT_PRICE).Visible = True
                .Columns(Items.ITEM_COMMENT_LOGO).Visible = True  'justin add 20230531

                .Columns(Items.EQP_LEVEL).Visible = IIf(Prog_Type(m_Program.Prog_Type) <> "Quote" Or _
                                                        Prog_Type(m_Program.Prog_Type) <> "Special Pricing", 0, 1)

                .Columns(Items.EQP_PCT).Visible = IIf(Prog_Type(m_Program.Prog_Type) <> "Quote" Or _
                                                        Prog_Type(m_Program.Prog_Type) <> "Special Pricing", 0, 1)

                '++ID 13.05.2015 readonly false if EQP_LEVEL = false(0)
                .Columns(Items.EQP_PCT).ReadOnly = True

                .Columns(Items.DEC_MET_ID).Visible = False ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.DEC_MET_GROUP_ID).Visible = False ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.SETUP_WAIVED).Visible = True '(m_Program_Type <> "Special Pricing")
                .Columns(Items.SETUP_PRICE).Visible = True '(m_Program_Type <> "Special Pricing")
                .Columns(Items.CHARGE_ID).Visible = False
                .Columns(Items.RUN_CHARGE).Visible = True ' (m_Program_Type <> "Special Pricing")
                .Columns(Items.COLOR_COUNT).Visible = True '(m_Program_Type = "Quote")
                .Columns(Items.LOCATION_COUNT).Visible = True '(m_Program_Type = "Quote")
                .Columns(Items.PACK_ID).Visible = False
                '.Columns(Items.OVERSEAS).Visible = (m_Program_Type = "Quote")
                '.Columns(Items.DOMESTIC).Visible = (m_Program_Type = "Quote")
                .Columns(Items.USER_LOGIN).Visible = False
                .Columns(Items.UPDATE_TS).Visible = False
                .Columns(Items.DIRTY).Visible = False
                .Columns(Items.CUS_PROG_ITEM_LIST_GUID).Visible = False
                .Columns(Items.CUS_PROG_ITEM_LIST_GUID).ReadOnly = True
                .Columns(Items.LINE_COMMENTS).Visible = False
                .RowHeadersWidth = 20
                .Columns(Items.DocId).Visible = False
                .Columns(Items.DocId).ReadOnly = True
                .Columns(Items.DocId).ToolTipText = "IMAGE"
                .Columns(Items.Image).Visible = False
                .Columns(Items.ITEM_COMMENT_LOGO).Visible = False 'justin add 20230531
                .Columns(Items.DISCO).Visible = False
            End With

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Sub dgvItems_Fill(ByVal dtItems As DataTable, ByRef m_Program As cMdb_Cus_Prog)
        Try

            Dim db As New cDBA

            Dim strLoadEmpty As String =
            " SELECT TOP 1 CAST(0 AS INT) AS CUS_PROG_ITEM_LIST_ID, " &
            "        CAST(0 AS INT) AS CUS_PROG_ID, " &
            "        CAST(0 AS INT) AS PROD_CAT_ID, " &
            "        CAST('' AS VARCHAR(20)) AS ITEM_CD, " &
            "        CAST(0 AS INT) AS CUSTOM_ITEM_ID, " &
            "        CAST('' AS VARCHAR(60)) AS ITEM_DESC, " &
            "        CAST('' AS VARCHAR(30)) AS ITEM_NO, " &
            "        CAST('' AS VARCHAR(20)) AS ITEM_COLOR, " &
            "        CAST(0 AS INT) AS QUOTE_TYPE_ID, " &
            "        CAST(0 AS INT) AS QUOTE_SHIP_METHOD_ID, " &
            "        CAST(0 AS NUMERIC(13, 4)) AS MIN_QTY_ORD, " &
            "        CAST(NULL AS NUMERIC(13, 4)) AS UNIT_PRICE, " &
            "        CAST(NULL AS INT) AS EQP_LEVEL, " &
            "        CAST(NULL AS NUMERIC(13, 4)) AS EQP_PCT, " &
            "        CAST(NULL AS INT) AS DEC_MET_ID, " &
            "        CAST(NULL AS INT) AS DEC_MET_GROUP_ID, " &
            "        CAST(NULL AS BIT) AS SETUP_WAIVED, " &
            "        CAST(NULL AS NUMERIC(13, 6)) AS SETUP_PRICE, " &
            "        CAST(0 AS INT) AS CHARGE_ID,  " &
            "        CAST(NULL AS NUMERIC(13, 6)) AS RUN_CHARGE, " &
            "        CAST(1 AS INT) AS COLOR_COUNT, " &
            "        CAST(1 AS INT) AS LOCATION_COUNT, " &
            "        CAST(NULL AS INT) AS PACK_ID, " &
            "        CAST('' AS VARCHAR(20)) AS USER_LOGIN, " &
            "        CAST(NULL AS DATETIME) AS UPDATE_TS,  " &
            "        CAST('' AS VARCHAR(1)) AS DIRTY, " &
            "        CAST('' AS VARCHAR(40)) AS CUS_PROG_ITEM_LIST_GUID, " &
            "        'Comments' AS LINE_COMMENTS ," &
            "         CAST('' As VARCHAR(5))  As Image,  " &
            "         CAST(0 AS INT) AS DocID,  " &
             "        CAST(NULL AS BIT) AS NEED_APPROVAL, " &
            " CAST('' AS VARCHAR(1)) AS ITEM_COMMENT_LOGO " &
            "   FROM  MDB_CUS_PROG_ITEM_LIST "
            'justin add ITEM_COMMENT_LOGO 20230531
            dtItems = db.DataTable(strLoadEmpty)
           
            dgvItems.DataSource = dtItems

            dgvItems.AllowUserToAddRows = False
            dgvItems.AllowUserToOrderColumns = False

            If dgvItems.Rows(0).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = String.Empty Then
                dgvItems.Rows(0).Cells(Items.CUS_PROG_ITEM_LIST_GUID).Value = Guid.NewGuid.ToString
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Enum Items
        CUS_PROG_ITEM_LIST_ID
        CUS_PROG_ID
        PROD_CAT_ID
        ITEM_CD
        ITEM_COMMENT_LOGO
        SELECTROW
        CUSTOM_ITEM_ID
        ITEM_DESC
        DISCO
        ITEM_NO
        ITEM_COLOR
        QUOTE_TYPE_ID
        'justin 20190910
        ITEM_SUBSTITUTE
        QUOTE_SHIP_METHOD_ID
        MIN_QTY_ORD
        UNIT_PRICE
        EQP_LEVEL
        EQP_PCT
        DEC_MET_ID
        DEC_MET_GROUP_ID
        SETUP_WAIVED
        SETUP_PRICE
        CHARGE_ID
        RUN_CHARGE
        COLOR_COUNT
        LOCATION_COUNT
        PACK_ID
        'OVERSEAS
        'DOMESTIC
        USER_LOGIN
        UPDATE_TS
        DIRTY
        CUS_PROG_ITEM_LIST_GUID
        LINE_COMMENTS
        Image
        DocId
        NEED_APPROVAL
    End Enum
    'justin add ITEM_COMMENT_LOGO 20230531
#End Region
#Region "-------------dgvColors maintenance-----------------"
    Private Sub UncheckAll(ByVal chk As Boolean)
        Try
            For Each dRow As DataGridViewRow In dgvColors.Rows
                dRow.Cells(0).Value = chk
            Next
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub CreateColumnsColor(ByRef dgv As DataGridView)
    '    Try
    '        With dgv.Columns
    '            .Add(DGVCheckBoxColumn("RowSelect", "CHECK", 60))
    '            .Add(DGVTextBoxColumn("COLOR", "Color", 120))
    '            .Add(DGVTextBoxColumn("ITEM_NO", "ITEM NO", 100))
    '            .Add(DGVImageColumn("picture", "PICTURE", 100))
    '        End With

    '        dgv.Columns(0).ReadOnly = False

    '    Catch ex As Exception
    '        MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Sub
    Private Sub CreateColumnsColor()
        Try
            With dgvColors
                With .Columns
                    .Add(DGVCheckBoxColumn("RowSelect", "Select", 60))
                    .Add(DGVTextBoxColumn("COLOR", "COLOR", 60))
                    .Add(DGVTextBoxColumn("Color_ID", "Color_ID", 10))
                    .Add(DGVTextBoxColumn("ITEM_NO", "ITEM NO", 80))

                    .Add(DGVTextBoxColumn("qtyAvailable", "STOCK", 55)) 'Discontinued
                    .Add(DGVTextBoxColumn("Discontinued", "DISCO", 40)) 'Discontinued
                    .Add(DGVImageColumn("picture", "PICTURE", 80))
                End With
                .Columns(colorall.COLOR).ReadOnly = True
                .Columns(colorall.Color_ID).ReadOnly = True
                .Columns(colorall.Color_ID).Visible = False
                .Columns(colorall.ITEM_NO).ReadOnly = True
                .Columns(colorall.qtyAvailable).ReadOnly = True
                .Columns(colorall.Discontinued).ReadOnly = True
                .Columns(colorall.picture).ReadOnly = True
                .Columns(colorall.picture).Visible = True
            End With
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Enum colorall
        RowSelect
        COLOR
        Color_ID
        ITEM_NO
        qtyAvailable
        Discontinued
        picture
    End Enum
    Private Sub fillDGVColor()
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            'strSql =
            '    " select  CAST(1 AS Bit) AS RowSelect,i.user_def_fld_2 As COLOR,i.ITEM_NO, v.qtyAvailable,v.Discontinued , " &
            '    " p.picture from imitmidx_sql i left join item_pictures p on i.item_no = p.item_no " &
            '    " left join Ion_InventoryResultsView v on i.item_no = v.itemNo  " &
            '    " where (i.user_def_fld_1 = '" & Trim(RTrim(strItemCd)) & "' or i.user_def_fld_1 ='66" & Trim(RTrim(strItemCd)) & "') " &
            '    " and i.item_no not like 'AC%' and i.item_no not like 'XX%' " &
            '    " and i.item_no not like '%AST' and i.item_no not like '%Z%' " &
            '    " AND i.item_no not  like 'USS%'" ' AND i.user_def_fld_2 IS NOT NULL "

            '++ID 1.8.2018
            'strSql =
            '    " select  CAST(1 AS Bit) AS RowSelect,i.Color_List As COLOR,i.ITEM_NO, v.qtyAvailable,v.Discontinued , " &
            '    " p.picture from View_MDB_ITEM_DETAIL i left join item_pictures p on i.item_no = p.item_no " &
            '    " left join Ion_InventoryResultsView v on i.item_no = v.itemNo  " &
            '    " where (i.ITEM_CD = '" & Trim(RTrim(strItemCd)) & "' or i.ITEM_CD ='66" & Trim(RTrim(strItemCd)) & "') " &
            '    " and i.item_no not like 'AC%' and i.item_no not like 'XX%' " &
            '    " and i.item_no not like '%AST' and i.item_no not like '%Z%' " &
            '    " AND i.item_no not  like 'USS%' and COUNTRY_CD = 'CA' and BOUND_TYPE='in'" ' AND i.user_def_fld_2 IS NOT NULL "

            '++ID 1.9.2018
            strSql =
               " select  CAST(1 AS Bit) AS RowSelect, i.Color_List As COLOR, i.Color_ID,i.ITEM_NO, v.qtyAvailable, v.Discontinued ,  " &
               " p.item_Doc as picture from View_MDB_ITEM_DETAIL i " &
               " Left Join Ion_View_Item_Picture p on i.item_no = p.item_no  and p.ITEM_DOC_TYPE_ID = 6   left join Ion_InventoryResultsView v on i.item_no = v.itemNo  " &
               " where (i.ITEM_CD = '" & Trim(RTrim(strItemCd)) & "' or i.ITEM_CD ='66" & Trim(RTrim(strItemCd)) & "') " &
               " and i.item_no not like 'AC%' and i.item_no not like 'XX%'  and i.item_no not like '%AST' " &
               " And i.item_no Not Like '%Z%' AND i.item_no not  like 'USS%' "

                    dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call CreateColumnsColor()
                dgvColors.DataSource = dt

                dgvColors.AllowUserToAddRows = False
                dgvColors.AllowUserToOrderColumns = False
                tlsCount.Text &= " " & dt.Rows.Count

                If Not (dt.Rows(0).Item(colorall.picture).Equals(DBNull.Value)) Then
                    pictBox1.Image = ByteToImage(dt.Rows(0).Item(colorall.picture))
                End If
            Else
                Exit Sub
            End If

            oOeprcfil_sql = New cMacolaOeprcfil_Sql
            oOeprcfil_sql.LoadMinQty(m_Customer.Currency,
         Trim(RTrim(strItemCd)), Trim(RTrim(dgvColors.Rows(0).Cells(colorall.ITEM_NO).Value.ToString)))
            Debug.Print(oOeprcfil_sql.Minimum_Qty_2)

            txtMinQty1.Text = Decimal.Round(oOeprcfil_sql.Minimum_Qty_2, 2)

            'oOeprcfil_sql.displayPrice(Trim(txtCus_No.Text), Trim(txtCurr_Cd.Text), _
            '    dgvItems.CurrentRow.Cells(Items.ITEM_CD).Value.ToString, _
            '    Trim(RTrim(dgvItems.Rows(e.RowIndex).Cells(Items.ITEM_COLOR).Value.ToString)), dgvItems.Rows(e.RowIndex).Cells(Items.MIN_QTY_ORD).Value, _
            '    m_Program_Type, dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value)

            txtPrice1.Text = Decimal.Round(oOeprcfil_sql.displayPrice(Trim(m_Program.Cus_No), Trim(m_Customer.Currency),
                  Trim(RTrim(strItemCd)), Trim(RTrim(dgvColors.Rows(0).Cells(colorall.COLOR).Value.ToString)), oOeprcfil_sql.Minimum_Qty_2, Prog_Type(m_Program.Prog_Type)), 3) ' it's latest optional parameter :dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value




        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "----------------Display Image in PictureBox--------------------------"
    Private Function ByteToImage(ByRef blob As Byte()) As Bitmap
        ByteToImage = Nothing
        Try
            If IsNothing(blob) Then Exit Function

            Dim mStream As New MemoryStream
            Dim pData = blob

            mStream.Write(pData, 0, Convert.ToInt32(pData.Length))
            Dim bm As New Bitmap(mStream, False)

            ' Make a bitmap for the result.

            mStream.Dispose()

            Dim bm_dest As New Bitmap(CInt(pictBox1.Width), CInt(pictBox1.Height))

            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            gr_dest.DrawImage(bm, 0, 0, _
        bm_dest.Width + 1, _
        bm_dest.Height + 1)
            Return bm_dest
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
    Private Sub dgvColors_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvColors.CellMouseLeave
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim cpt As Int32 = 0

                    For Each dr As DataGridViewRow In dgvColors.Rows
                        If dr.Cells(0).EditedFormattedValue = True Then
                            cpt += 1
                        End If
                    Next

                    Debug.Print("dgvColors_CellMouseLeave")
                
                    lblCpt.Text = cpt.ToString
            End Select

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvColors_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvColors.LostFocus
        Try
            Dim cpt As Int32 = 0
            For Each dr As DataGridViewRow In dgvColors.Rows
                If dr.Cells(0).EditedFormattedValue = True Then
                    cpt += 1
                End If
            Next

            Debug.Print("dgvColors_LostFocus")

            lblCpt.Text = cpt.ToString

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnAddReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReturn.Click
        Try
            Call dtItemsAdd()
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function dtItemsAdd() As DataTable
        dtItemsAdd = Nothing
        Try

            Debug.Print("Function dtItemsAdd(). Row Count from Quote : " & dtItem.Rows.Count)
            Debug.Print("Function dtItemsAdd(). Row Count from Color grid : " & dtT.Rows.Count)

            'check if dtT is Nothing
            'if is Nothing don't make Merge
            If Not IsNothing(dtT) Then
                dtItem.Merge(dtT)
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim myStream As Stream = Nothing
            Dim strAddress As String = "C:\ExactTemp\AllSku export " & Guid.NewGuid.ToString & ".xlsx"
            Dim modExportToExcel As New modExportToExcel

            'Call modExportToExcel.DatatableToExcel(dtItem, strAddress)

            Me.Cursor = Cursors.Default

            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = strAddress
            Process.Start(startInfo)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvItems_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.RowEnter
        Try
            If IsNothing(dgvItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                tlsDeliteLine.Visible = False
                Exit Sub
            End If

            tlsDeliteLine.Visible = True
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
   
#Region "-----------------price---------------------"
    Private Function ItemPrice(ByVal qty As Int32) As Decimal
        ItemPrice = 0.0
        Try

            If IsNumeric(qty) And qty <> 0 Then
                ItemPrice = Decimal.Round(oOeprcfil_sql.displayPrice(Trim(m_Program.Cus_No), Trim(m_Customer.Currency), _
                  Trim(RTrim(strItemCd)), Trim(RTrim(dgvColors.CurrentRow.Cells(1).Value.ToString)), Decimal.Round(qty), Prog_Type(m_Program.Prog_Type)), 3)
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function ItemPrice(ByVal qty As String) As String
        ItemPrice = String.Empty
        Try
            MsgBox("You need enter number value.")

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function ApplyPercentage(ByVal price As Decimal, ByVal Eqp As Decimal) As Decimal
        ApplyPercentage = 0.0
        Try
            '  ApplyPercentage = price - ((price / 100) * CDbl(txtQqpDisc.Text))
            If Not IsNumeric(price) And price = 0.0 Then Exit Function

            Return Decimal.Round(price - ((price / 100) * Eqp), 3)
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub ActivateChkEQP(ByRef chkEqp As CheckBox, ByVal sender As Object)
        Try
            Dim txt As TextBox = CType(sender, TextBox) 'text box qty1,2,3

            If m_Program.Prog_Type = 1 And IsNumeric(txt.Text) Then
                chkEqp.Visible = True
            Else
                chkEqp.Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ActivateEQPChk()
        Try
            For Each chk As CheckBox In mychkEQP
                If m_Program.Prog_Type = 1 Then
                    chk.Visible = True
                Else
                    chk.Visible = False
                End If
            Next

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
    Private Sub txtQqpDisc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQqpDisc1.LostFocus, txtQqpDisc2.LostFocus, txtQqpDisc3.LostFocus
        Try
            Dim txtQqpDisc As TextBox = CType(sender, TextBox)

            'apply for update data in array
            Call PopulateArrayObject()

            ''empty it's means nothing to do, exit from sub
            If txtQqpDisc.Text = String.Empty Then
                'return position 0 , normal prise by qty
                myTxtPrice(txtQqpDisc.Tag).Text = ItemPrice(CInt(myTxtMinQty(CInt(txtQqpDisc.Tag)).Text))
                txtQqpDisc.Text = "0.00"
                init = 0
                Exit Sub
            ElseIf CDbl(txtQqpDisc.Text) = 0.0 Then
                'return position 0 , normal prise by qty
                myTxtPrice(txtQqpDisc.Tag).Text = ItemPrice(CInt(myTxtMinQty(CInt(txtQqpDisc.Tag)).Text))
                init = 0
                txtQqpDisc.Text = "0.00"
                Exit Sub
            End If

            myTxtPrice(txtQqpDisc.Tag).Text = ApplyPercentage(ItemPrice(CInt(myTxtMinQty(CInt(txtQqpDisc.Tag)).Text)),
                                                              Convert.ToDecimal(myTxtQqpDisc(CInt(txtQqpDisc.Tag)).Text))

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtMinQty1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinQty1.LostFocus, txtMinQty2.LostFocus, txtMinQty3.LostFocus
        Try
            'apply for update the data in objects
            Call PopulateArrayObject()
            Dim txtMinQty As TextBox = CType(sender, TextBox)

            If Trim(RTrim(txtMinQty.Text)) = String.Empty Then
                txtMinQty.Text = "0"
            End If

            If m_Program.Prog_Type = 1 Then

                If Trim(RTrim(txtMinQty.Text)) = String.Empty Or CInt(txtMinQty.Text) = 0 Then
                    myTxtQqpDisc(txtMinQty.Tag).ReadOnly = True
                    mychkEQP(txtMinQty.Tag).CheckState = CheckState.Unchecked
                    myTxtPrice(txtMinQty.Tag).Text = ItemPrice(CInt(myTxtMinQty(CInt(txtMinQty.Tag)).Text))
                Else
                    myTxtQqpDisc(txtMinQty.Tag).ReadOnly = False

                    'display price by qty + percentage
                    myTxtPrice(txtMinQty.Tag).Text = ApplyPercentage(ItemPrice(CInt(txtMinQty.Text)), Convert.ToDecimal(myTxtQqpDisc(CInt(txtMinQty.Tag)).Text))

                End If

            Else
                'display price by qty
                myTxtPrice(txtMinQty.Tag).Text = ItemPrice(CInt(myTxtMinQty(CInt(txtMinQty.Tag)).Text))
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtMinQty2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            oOeprcfil_sql = New cMacolaOeprcfil_Sql

            If Not IsNumeric(txtMinQty2.Text) Then Exit Sub

            Call ActivateChkEQP(chkEQP2, sender)

            txtPrice2.Text = Decimal.Round(oOeprcfil_sql.displayPrice(Trim(m_Program.Cus_No), Trim(m_Customer.Currency), _
            Trim(RTrim(strItemCd)), Trim(RTrim(dgvColors.CurrentRow.Cells(1).Value.ToString)), txtMinQty2.Text, Prog_Type(m_Program.Prog_Type)), 3)
            'it's latest optional parameter :dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtMinQty3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            oOeprcfil_sql = New cMacolaOeprcfil_Sql

            If Not IsNumeric(txtMinQty3.Text) Then Exit Sub

            Call ActivateChkEQP(chkEQP2, sender)

            txtPrice3.Text = Decimal.Round(oOeprcfil_sql.displayPrice(Trim(m_Program.Cus_No), Trim(m_Customer.Currency), _
              Trim(RTrim(strItemCd)), Trim(RTrim(dgvColors.CurrentRow.Cells(1).Value.ToString)), txtMinQty3.Text, Prog_Type(m_Program.Prog_Type)), 3)
            'it's latest optional parameter :dgvItems.Rows(e.RowIndex).Cells(Items.EQP_LEVEL).Value

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cboDecorating_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDecorating.SelectedIndexChanged
        Try

            If Trim(RTrim(cboDecorating.Text)) = "DEBOSS" Then
                chkSetupWaived.CheckState = CheckState.Unchecked
                ' txtSetupPrice.Text = String.Empty
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chkSetupWaived_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSetupWaived.CheckStateChanged
        Try

            If Trim(RTrim(cboDecorating.Text)) = "DEBOSS" Then
                chkSetupWaived.CheckState = CheckState.Unchecked
                '   txtSetupPrice.Text = String.Empty
            End If

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmAllsku_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            For Each row As DataGridViewRow In dgvColors.Rows
                If row.Cells(colorall.qtyAvailable).Value <= 0 Then
                    dgvColors.Rows(row.Index).Cells(colorall.ITEM_NO).Style.BackColor = Color.DarkRed
                    dgvColors.Rows(row.Index).Cells(colorall.ITEM_NO).Style.ForeColor = Color.White

                    dgvColors.Rows(row.Index).Cells(colorall.qtyAvailable).Style.BackColor = Color.DarkRed
                    dgvColors.Rows(row.Index).Cells(colorall.qtyAvailable).Style.ForeColor = Color.White

                    ' MsgBox(dgvColors.Rows(row.Index).Cells(colorall.ITEM_NO).Style.BackColor.ToString)
                End If
            Next

            'dgvColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
            'MsgBox(dgvColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor.ToString)


            'dgvColors.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Beige

            'MsgBox(dgvColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor.ToString)

        Catch ex As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)

        End Try
    End Sub
End Class