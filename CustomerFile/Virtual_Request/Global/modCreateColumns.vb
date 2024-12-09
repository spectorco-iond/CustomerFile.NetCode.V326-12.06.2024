

Module modCreateColumns
    Public Function comboboxColumnListImp(ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cMdb_Item_Imp_Loc_VIEW), ByVal pWidth As Int32) As DataGridViewComboBoxColumn
        comboboxColumnListImp = New DataGridViewComboBoxColumn
        Try
            comboboxColumnListImp = DGVComboBoxColumn(pstrid, pstrMember, pWidth)
            With comboboxColumnListImp
                .DataSource = listOf 'need create function for populate
                '  .ValueMember = pstrid
                ' .DisplayMember = pstrMember
                .DefaultCellStyle.ForeColor = Color.Maroon
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .DefaultCellStyle.BackColor = Color.White
                .FlatStyle = FlatStyle.Flat

                '.Style.ForeColor = Color.Maroon

                '.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                '.Style.BackColor = Color.White

            End With
            Return comboboxColumnListImp
        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxColumnListCol(ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cMdb_Item_VariantColor), ByVal pWidth As Int32) As DataGridViewComboBoxColumn
        comboboxColumnListCol = New DataGridViewComboBoxColumn
        Try
            comboboxColumnListCol = DGVComboBoxColumn(pstrid, pstrMember, pWidth)
            With comboboxColumnListCol
                .DataSource = listOf 'need create function for populate

                .DefaultCellStyle.ForeColor = Color.Maroon
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .DefaultCellStyle.BackColor = Color.White
                ' .ValueMember = pstrid
                ' .DisplayMember = pstrMember
            End With
            Return comboboxColumnListCol
        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxColumnList(ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cMdb_Item_VariantColor), ByVal pWidth As Int32) As DataGridViewComboBoxColumn
        comboboxColumnList = New DataGridViewComboBoxColumn
        Try
            comboboxColumnList = DGVComboBoxColumn(pstrid, pstrMember, pWidth)
            With comboboxColumnList
                .DataSource = listOf 'need create function for populate
                '  .ValueMember = pstrid
                '  .DisplayMember = pstrMember
                .DefaultCellStyle.ForeColor = Color.Maroon
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .DefaultCellStyle.BackColor = Color.White
            End With
            Return comboboxColumnList
        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'with datatable
    Public Function comboboxColumnEnumCol(ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cCfgEnum)) As DataGridViewComboBoxColumn
        comboboxColumnEnumCol = New DataGridViewComboBoxColumn
        Try
            comboboxColumnEnumCol = DGVComboBoxColumn(pstrid, pstrMember, 200)
            With comboboxColumnEnumCol
                .DataSource = listOf 'need create function for populate
                .ValueMember = pstrid
                .DisplayMember = pstrMember
                .Width = 200
                .DefaultCellStyle.ForeColor = Color.Maroon
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .DefaultCellStyle.BackColor = Color.White

            End With
            Return comboboxColumnEnumCol
        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxCell(ByRef dgv As DataGridView, ByVal colIndex As Integer, ByVal rowIndex As Integer, ByVal pstrid As String, ByVal pstrMember As String, ByRef dt As DataTable) As DataGridViewComboBoxCell

        comboboxCell = New DataGridViewComboBoxCell
        Try
            comboboxCell = DirectCast(dgv.Item(colIndex, rowIndex), DataGridViewComboBoxCell) ' 
            With comboboxCell
                'getEmptyDataSource(pstrid, pstrMember) 'need create function for populate
                .DataSource = dt
                .ValueMember = pstrid
                .DisplayMember = pstrMember
                .Style.ForeColor = Color.Maroon

                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Style.BackColor = Color.White
            End With
            Return comboboxCell

        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxCell(ByRef dgv As DataGridView, ByVal colIndex As Integer, ByVal rowIndex As Integer, ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cMdb_Item_VariantColor)) As DataGridViewComboBoxCell
        'cMdb_Item_VariantColor
        comboboxCell = New DataGridViewComboBoxCell
        Try
            comboboxCell = DirectCast(dgv.Item(colIndex, rowIndex), DataGridViewComboBoxCell) ' 
            With comboboxCell
                .DataSource = listOf 'getEmptyDataSource(pstrid, pstrMember) 'need create function for populate
                .ValueMember = pstrid
                .DisplayMember = pstrMember
                .Style.ForeColor = Color.Maroon

                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Style.BackColor = Color.White
            End With
            Return comboboxCell

        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxCell(ByRef dgv As DataGridView, ByVal colIndex As Integer, ByVal rowIndex As Integer, ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cMdb_Item_Imp_Loc_VIEW)) As DataGridViewComboBoxCell
        'cMdb_Item_Imp_Loc_VIEW
        comboboxCell = New DataGridViewComboBoxCell
        Try

            dgv.Rows(rowIndex).Cells(colIndex) = New DataGridViewComboBoxCell
            '         If colIndex = 9 Then MsgBox("column: " & colIndex)
            comboboxCell = DirectCast(dgv.Item(colIndex, rowIndex), DataGridViewComboBoxCell) ' 
            With comboboxCell
                .DataSource = listOf 'getEmptyDataSource(pstrid, pstrMember) 'need create function for populate
                .ValueMember = pstrid
                .DisplayMember = pstrMember
                .Style.ForeColor = Color.Maroon

                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Style.BackColor = Color.White
            End With
            Return comboboxCell

        Catch ex As Exception
            MsgBox("Name : " & comboboxCell.ColumnIndex & "Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function comboboxCell(ByRef dgv As DataGridView, ByVal colIndex As Integer, ByVal rowIndex As Integer, ByVal pstrid As String, ByVal pstrMember As String, ByRef listOf As List(Of cCfgEnum)) As DataGridViewComboBoxCell
        'cMdb_Item_Imp_Loc_VIEW
        comboboxCell = New DataGridViewComboBoxCell
        Try

            dgv.Rows(rowIndex).Cells(colIndex) = New DataGridViewComboBoxCell

            comboboxCell = DirectCast(dgv.Item(colIndex, rowIndex), DataGridViewComboBoxCell) ' 
            With comboboxCell
                .DataSource = listOf 'getEmptyDataSource(pstrid, pstrMember) 'need create function for populate
                .ValueMember = pstrid
                .DisplayMember = pstrMember
                .Style.ForeColor = Color.Maroon

                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Style.BackColor = Color.White
            End With
            Return comboboxCell

        Catch ex As Exception
            MsgBox("Name : " & comboboxCell.ColumnIndex & "Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function tetxBoxcell(ByRef dgv As DataGridView, ByVal colIndex As Integer, ByVal rowIndex As Integer, ByVal strVal As String, Optional ByVal strTag As String = "") As DataGridViewTextBoxCell

        tetxBoxcell = New DataGridViewTextBoxCell
        Try
            dgv.Rows(rowIndex).Cells(colIndex) = New DataGridViewTextBoxCell
            tetxBoxcell = DirectCast(dgv.Item(colIndex, rowIndex), DataGridViewTextBoxCell) ' 
            With tetxBoxcell
                .Value = strVal
                .Tag = strTag
                .ReadOnly = True

            End With
            Return tetxBoxcell

        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'listview color for line (rows)
    Public Sub ListView_RowsColor(ByRef listView As ListView)
        Try
            Dim CountR As Integer
            CountR = 0
            While CountR <= listView.Items.Count - 1

                If CountR Mod 2 = 0 Then
                    listView.Items(CountR).BackColor = Color.White
                Else
                    listView.Items(CountR).BackColor = Color.Azure

                End If
                CountR = CountR + 1
            End While

        Catch ex As Exception
            MsgBox("Error in modCreateColumns " & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Columns_VirtualRequest(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            Dim oMdb_Item_VariantColor As cMdb_Item_VariantColor
            Dim oMdb_Item_Imp_Loc_VIEW As cMdb_Item_Imp_Loc_VIEW

            With dgv.Columns
                .Clear()


                .Add(DGVTextBoxColumn("x", "", 40))
                .Add(DGVTextBoxColumn("item_master_id", "Masterid", 80))
                .Add(DGVTextBoxColumn("item_cd", "Style", 60))
                .Add(DGVTextBoxColumn("prod_category", "Prod Cat", 80))

                .Add(DGVTextBoxColumn("Is_kit", "Kit:Y/N", 50))

                oMdb_Item_VariantColor = New cMdb_Item_VariantColor
                .Add(comboboxColumnListCol("color_id", "Color", oMdb_Item_VariantColor.Load_VariantListColor(CInt(oMdb_Item_VariantColor.Item_Master_Id)), 60))

                .Add(DGVTextBoxColumn("item_no", "sku", 100)) 'text
                .Add(DGVTextBoxColumn("Maco_desc1", "Macola Description", 130)) 'text
                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                .Add(comboboxColumnListImp("DEC_MET_ID", "Decorating Method", oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VariantColor.Item_Master_Id)), 160))

                oMdb_Item_Imp_Loc_VIEW = New cMdb_Item_Imp_Loc_VIEW
                .Add(comboboxColumnListImp("IMP_LOC_ID", "Location", oMdb_Item_Imp_Loc_VIEW.LoadDecMet_List(CInt(oMdb_Item_VariantColor.Item_Master_Id), CInt(0)), 160))

                .Add(DGVTextBoxColumn("Area_Size", "Aria Size", 125))

                .Add(DGVCheckBoxColumn("DEFAULT_LOC", "Default Loc", 60))

                .Add(DGVTextBoxColumn("Imprint_Color", "Imprint Color", 100))
                .Add(DGVTextBoxColumn("Imprint_Logo", "Imprint Logo", 100))


                'oCfgEnum = New cCfgEnum
                '.Add(comboboxColumnEnumCol("ID", "PATCH_SHAPE", oCfgEnum.LoadEnumCat("")))
                .Add(DGVTextBoxColumn("ID", "PATCH SHAPE", 100))
                .Add(DGVTextBoxColumn("ID", "PATCH COLOR", 100))

                'latest modification  2.01.2018 ---------------- 
                .Add(DGVTextBoxColumn("ID", "Thread Color", 100))
                .Add(DGVTextBoxColumn("BackGround_Color", "BackGround Color", 100))
                .Add(DGVTextBoxColumn("StampingPattern", "Stamping Pattern", 100))
                '-----------------------------------------------

                '.Add(DGVTextBoxColumn("Imprint_Color", "Imprint Color", 100))
                '.Add(DGVTextBoxColumn("Imprint_Logo", "Imprint Logo", 100))
                .Add(DGVTextBoxColumn("GUID", "Guid", 80))
                .Add(DGVTextBoxColumn("Parent_GUID", "Parent GUID", 80))
                .Add(DGVTextBoxColumn("ReqItemId", "ReqItemId", 40))
                .Add(DGVTextBoxColumn("ReqItemComm", "Comment", 60))
            End With

            With dgv

                .CancelEdit()
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                .ColumnHeadersHeight = 25
                .RowHeadersWidth = 15
                With .Columns

                    .Item(CInt(Request.x)).ReadOnly = True
                    .Item(CInt(Request.item_cd)).Frozen = DataGridViewElementStates.Frozen
                    .Item(CInt(Request.x)).DefaultCellStyle.Font = New Font("Arial", 14, FontStyle.Bold)
                    .Item(CInt(Request.x)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Item(CInt(Request.x)).DefaultCellStyle.BackColor = Color.Red

                    .Item(Request.item_master_id).ReadOnly = True
                    If Environment.UserName <> "iond" Then
                        .Item(Request.item_master_id).Visible = False
                        .Item(Request.ReqItemId).Visible = False
                    End If


                    .Item(Request.item_no).ReadOnly = True
                    .Item(Request.prod_category).ReadOnly = True
                    .Item(Request.Is_kit).ReadOnly = True

                    .Item(Request.Area_Size).ReadOnly = True
                    '.Item(Request.Patch_Shape).ReadOnly = True
                    .Item(Request.DEFAULT_LOC).ReadOnly = True

                    '.Item(Request.USER_LOGIN).ReadOnly = True
                    '.Item(Request.CREATE_TS).ReadOnly = True
                    '.Item(Request.UPDATE_TS).ReadOnly = True

                    .Item(Request.prod_category).Visible = False
                    .Item(Request.item_no).Visible = False
                    .Item(Request.Maco_desc1).Visible = False

                    .Item(Request.ReqItemComm).Visible = True

                    '.Item(Request.CREATE_TS).Visible = False
                    '.Item(Request.UPDATE_TS).Visible = False
                    .Item(Request.GUID).Visible = False
                    .Item(Request.Parent_GUID).Visible = False
                    '.Item(Request.GUID).ReadOnly = True
                    '.Item(Request.Parent_GUID).ReadOnly = True

                End With
            End With

            'dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Value = "X"
            'dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.Font = New Font("Arial", 14, FontStyle.Bold)
            'dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgvStoryBoard.Rows(rowIndex).Cells(Request.x).Style.BackColor = Color.Red


            For Each dgvCell As DataGridViewColumn In dgv.Columns
                'If dgvCell.Index <> CInt(Request.item_cd) Then
                '    dgvCell.ReadOnly = True
                'End If
                Select Case dgvCell.Index
                    Case CInt(Request.item_cd), CInt(Request.IMPRINT_COLOR), CInt(Request.IMPRINT_LOGO)
                        dgvCell.ReadOnly = False
                    Case Else
                        dgvCell.ReadOnly = True
                End Select
            Next


            Call PropertyForm(dgv, frm)
            'enable sort mode, becuase for the kit - components can mix
            For Each dgvCol As DataGridViewColumn In dgv.Columns
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    '--------clolumns for ListView -------
    Public Function listColumns(ByVal txt As String, ByVal name As String, ByRef horizAlign As HorizontalAlignment, ByVal w As Int32) As ColumnHeader
        listColumns = New ColumnHeader
        Try
            Dim clHeader As New ColumnHeader

            With clHeader
                .Text = txt 'Cicmpy_Enum.Cmp_code.ToString
                .Name = name 'Cicmpy_Enum.Cmp_code.ToString
                .TextAlign = horizAlign
                .Width = w

            End With

            Return clHeader
        Catch ex As Exception
            MsgBox("Error in modCreateColumns ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    '----
    Public Sub Columns_CFG_Color(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("COLOR_ID", "ID", 60))
                .Add(DGVTextBoxColumn("COLOR_CD", "COLOR CD", 120))
                .Add(DGVTextBoxColumn("COLOR_NAME", "COLOR NAME", 145))

                .Add(DGVTextBoxColumn("COLOR_NAME_FR", "COLOR NAME FR", 145))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    If dgv.Name <> "dgvTop" Then
                        .Item(CFG_COLOR.Color_CD).ReadOnly = True
                    End If
                    .Item(CFG_COLOR.Color_ID).Visible = False
                    .Item(CFG_COLOR.User_Login).Visible = False
                    .Item(CFG_COLOR.Create_TS).Visible = False
                    .Item(CFG_COLOR.Update_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_Color ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_ENUM(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("ID", "ID", 60))

                .Add(DGVTextBoxColumn("ENUM_CAT", "ENUM CAT", 140))
                .Add(DGVTextBoxColumn("ENUM_SUB_CAT", "ENUM SUB CAT", 100))

                .Add(DGVTextBoxColumn("ENUM_VALUE", "ENUM VALUE", 170))
                .Add(DGVTextBoxColumn("ENUM_ORDER", "ENUM ORDER", 50))
                .Add(DGVTextBoxColumn("USER_ID", "USER ID", 50))
                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_ENUM.ID).Visible = False
                    .Item(CFG_ENUM.ENUM_SUB_CAT).Visible = False
                    .Item(CFG_ENUM.ENUM_ORDER).Visible = False
                    .Item(CFG_ENUM.USER_ID).Visible = False
                    .Item(CFG_ENUM.USER_LOGIN).Visible = False
                    .Item(CFG_ENUM.CREATE_TS).Visible = False
                    .Item(CFG_ENUM.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_ENUM ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_IMP_LOC(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("IMP_LOC_ID", "ID", 60))

                .Add(DGVTextBoxColumn("IMP_LOC_CD", "IMP_LOC_CD", 80))

                .Add(DGVTextBoxColumn("DESCRIPTION", "DESCRIPTION", 170))
                .Add(DGVTextBoxColumn("DESCRIPTION_FR", "DESCRIPTION FR", 170))
                .Add(DGVTextBoxColumn("CLASS_ID", "CLASS_ID", 80))

                .Add(DGVTextBoxColumn("PROD_TYPE", "PROD_TYPE", 50))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With
            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_IMP_LOC.IMP_LOC_ID).Visible = False
                    .Item(CFG_IMP_LOC.IMP_LOC_CD).Visible = False
                    .Item(CFG_IMP_LOC.PROD_TYPE).Visible = False

                    .Item(CFG_IMP_LOC.USER_LOGIN).Visible = False
                    .Item(CFG_IMP_LOC.CREATE_TS).Visible = False
                    .Item(CFG_IMP_LOC.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_IMP_LOC ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Columns_CFG_ITEM_CATEGORY(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("ITEM_CATEGORY_ID", "ITEM_CATEGORY_ID", 60))

                .Add(DGVTextBoxColumn("NAME_EN", "NAME EN", 81))
                .Add(DGVTextBoxColumn("NAME_FR", "NAME FR", 80))

                .Add(DGVTextBoxColumn("BANNER_TEXT_1_EN", "BANNER TEXT 1 EN", 170))
                .Add(DGVTextBoxColumn("BANNER_TEXT_1_FR", "BANNER TEXT 1 FR", 170))

                .Add(DGVTextBoxColumn("BANNER_TEXT_2_EN", "BANNER TEXT 2 EN", 170))
                .Add(DGVTextBoxColumn("BANNER_TEXT_2_FR", "BANNER TEXT 2 FR", 170))

                .Add(DGVCheckBoxColumn("IS_DECO", "ID DECO", 60)) ' .Add(DGVCheckBoxColumn("Always", "Always", 45))

                .Add(DGVTextBoxColumn("HEADER_IMAGE", "HEADER IMAGE", 120))
                .Add(DGVTextBoxColumn("HEADER_LINK", "HEADER LINK", 80))

                .Add(DGVCheckBoxColumn("DISABLED", "DISABLED", 70)) ' .Add(DGVCheckBoxColumn("Always", "Always", 45))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_ITEM_CATEGORY.ITEM_CATEGORY_ID).Visible = False
                    .Item(CFG_ITEM_CATEGORY.HEADER_LINK).Visible = False
                    .Item(CFG_ITEM_CATEGORY.USER_LOGIN).Visible = False
                    .Item(CFG_ITEM_CATEGORY.CREATE_TS).Visible = False
                    .Item(CFG_ITEM_CATEGORY.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_ITEM_CATEGORY ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_ITEM_COLLECTION(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("CFG_ITEM_COLLECTION_ID", "ITEM COLLECTION ID", 60))

                .Add(DGVTextBoxColumn("COLLECTION_CD", "COLLECTION CD", 120))

                .Add(DGVTextBoxColumn("NAME_EN", "NAME EN", 81))
                .Add(DGVTextBoxColumn("NAME_FR", "NAME FR", 80))

                .Add(DGVTextBoxColumn("BANNER_TEXT_1_EN", "BANNER TEXT 1 EN", 170))
                .Add(DGVTextBoxColumn("BANNER_TEXT_1_FR", "BANNER TEXT 1 FR", 170))

                .Add(DGVTextBoxColumn("BANNER_TEXT_2_EN", "BANNER TEXT 2 EN", 170))
                .Add(DGVTextBoxColumn("BANNER_TEXT_2_FR", "BANNER TEXT 2 FR", 170))

                .Add(DGVCheckBoxColumn("IS_DECO", "ID DECO", 60)) ' .Add(DGVCheckBoxColumn("Always", "Always", 45))

                .Add(DGVTextBoxColumn("HEADER_IMAGE", "HEADER IMAGE", 120))
                .Add(DGVTextBoxColumn("HEADER_LINK", "HEADER LINK", 80))

                .Add(DGVCheckBoxColumn("DISABLED", "DISABLED", 70)) ' .Add(DGVCheckBoxColumn("Always", "Always", 45))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_ITEM_COLLECTION.CFG_ITEM_COLLECTION_ID).Visible = False
                    .Item(CFG_ITEM_COLLECTION.IS_DECO).Visible = False
                    .Item(CFG_ITEM_COLLECTION.HEADER_LINK).Visible = False
                    .Item(CFG_ITEM_COLLECTION.USER_LOGIN).Visible = False
                    .Item(CFG_ITEM_COLLECTION.CREATE_TS).Visible = False
                    .Item(CFG_ITEM_COLLECTION.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_ITEM_COLLECTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_ITEM_DOC_TYPE(ByRef dgv As DataGridView, ByRef frm As Form)
        Try


            With dgv.Columns
                .Clear()

                .Add(DGVTextBoxColumn("ITEM_DOC_TYPE_ID", "ID", 60))
                .Add(DGVTextBoxColumn("DOC_TYPE", "DOC TYPE", 120))
                .Add(DGVCheckBoxColumn("ACTIVE", "ACTIVE", 70))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    If dgv.Name <> "dgvTop" Then
                        .Item(CFG_COLOR.Color_CD).ReadOnly = True
                    End If
                    .Item(CFG_ITEM_DOC_TYPE.ITEM_DOC_TYPE_ID).Visible = False

                    .Item(CFG_ITEM_DOC_TYPE.USER_LOGIN).Visible = False
                    .Item(CFG_ITEM_DOC_TYPE.CREATE_TS).Visible = False
                    .Item(CFG_ITEM_DOC_TYPE.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_ITEM_DOC_TYPE ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_PACK(ByRef dgv As DataGridView, ByRef frm As Form)
        Try

            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("PACK_ID", "PACK ID", 60))
                .Add(DGVTextBoxColumn("PACK_CD", "PACK CD", 100))
                .Add(DGVTextBoxColumn("DESCRIPTION", "DESCRIPTION", 200))
                .Add(DGVTextBoxColumn("DESCRIPTION_FR", "DESCRIPTION FR", 200))
                .Add(DGVTextBoxColumn("CAPACITY", "CAPACITY", 70))
                .Add(DGVTextBoxColumn("ITEM_CONTENT", "ITEM CONTENT", 70))

                .Add(DGVCheckBoxColumn("IS_INBOUND", "IS INBOUND", 80))
                .Add(DGVCheckBoxColumn("IS_OUTBOUND", "IS OUTBOUND", 90))

                .Add(DGVTextBoxColumn("SIZE_X", "SIZE X", 70))
                .Add(DGVTextBoxColumn("SIZE_Y", "SIZE Y", 70))
                .Add(DGVTextBoxColumn("SIZE_Z", "SIZE Z", 70))
                .Add(DGVTextBoxColumn("SIZE_UOM", "SIZE UOM", 150))
                .Add(DGVTextBoxColumn("WEIGHT", "WEIGHT", 70))
                .Add(DGVTextBoxColumn("WEIGHT_UOM", "WEIGHT UOM", 80))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_PACK.PACK_ID).Visible = False
                    .Item(CFG_PACK.CAPACITY).Visible = False
                    .Item(CFG_PACK.ITEM_CONTENT).Visible = False
                    .Item(CFG_PACK.SIZE_X).Visible = False
                    .Item(CFG_PACK.SIZE_Y).Visible = False
                    .Item(CFG_PACK.SIZE_Z).Visible = False
                    .Item(CFG_PACK.SIZE_UOM).Visible = False
                    .Item(CFG_PACK.WEIGHT).Visible = False
                    .Item(CFG_PACK.WEIGHT_UOM).Visible = False

                    .Item(CFG_PACK.USER_LOGIN).Visible = False
                    .Item(CFG_PACK.CREATE_TS).Visible = False
                    .Item(CFG_PACK.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_PACK." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_REFILLS(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("REFILL_ID", "REFILL ID", 60))
                .Add(DGVTextBoxColumn("REFILL_CODE", "REFILL CODE", 100))
                .Add(DGVTextBoxColumn("REFILL_DESC", "DESCRIPTION", 200))
                .Add(DGVTextBoxColumn("REFILL_DESC_FR", "DESCRIPTION FR", 200))

                .Add(DGVCheckBoxColumn("IS_STD", "IS_STD", 80))
                .Add(DGVCheckBoxColumn("IS_OPTIONAL", "IS_OPTIONAL", 90))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_DT", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_DT", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_REFILLS.REFILL_ID).Visible = False

                    .Item(CFG_REFILLS.USER_LOGIN).Visible = False
                    .Item(CFG_REFILLS.CREATE_DT).Visible = False
                    .Item(CFG_REFILLS.UPDATE_DT).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_REFILLS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_CFG_WEB_ICON(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("CFG_WEB_ICON_ID", "CFG WEB ICON ID", 60))
                .Add(DGVTextBoxColumn("ICON_NAME", "ICON NAME", 100))
                .Add(DGVTextBoxColumn("FILENAME", "FILENAME", 140))
                .Add(DGVTextBoxColumn("FILENAME_US", "FILENAME US", 150))
                .Add(DGVTextBoxColumn("DESC_EN", "DESC EN", 100))
                .Add(DGVTextBoxColumn("DESC_FR", "DESC FR", 100))

                .Add(DGVTextBoxColumn("TYPE", "TYPE", 60))
                .Add(DGVTextBoxColumn("LOCATION", "LOCATION", 80))
                .Add(DGVCheckBoxColumn("ACTIVE", "ACTIVE", 80))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))

                .Add(DGVImageColumn("ICON_EN", "ICON EN", 130))
                .Add(DGVImageColumn("ICON_FR", "ICON FR", 130))

                'If dgv.Name <> "dgvTop" Then
                '    .Add(DGVImageColumn("BT_EN", "BT_EN", 130))
                '    .Add(DGVImageColumn("BT_FR", "BT FR", 130))
                'Else
                .Add(DGVButtonColumn("BT_EN", "BT EN", 130))
                .Add(DGVButtonColumn("BT_FR", "BT FR", 130))
                ' End If

            End With
            If dgv.Name = "dgvTop" Then
                For Each col As DataGridViewColumn In dgv.Columns
                    col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End If

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_WEB_ICON.WEB_ICON_ID).Visible = False
                    .Item(CFG_WEB_ICON.USER_LOGIN).Visible = False
                    .Item(CFG_WEB_ICON.CREATE_TS).Visible = False
                    .Item(CFG_WEB_ICON.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertyForm(dgv, frm)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_WEB_ICON." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Sub Columns_CFG_FLD_CHANGE_RECIPIENT(ByRef dgv As DataGridView, ByVal _pan As Panel)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("FLD_CHANGE_RECIPIENT_ID", "ID", 60))
                .Add(DGVTextBoxColumn("GROUP_CHANGE_CODE", "GR.CHANGE.CD", 100))
                ' .Add(DGVTextBoxColumn("FLD_CD", "FLD CD", 100))
                .Add(DGVTextBoxColumn("CHECKPOINT_CD_COMPLETED", "CHECKPOINT CD COMPLETED", 200))
                .Add(DGVTextBoxColumn("ITEM_STATUS", "ITEM STATUS", 110))
                .Add(DGVTextBoxColumn("NTUSERID", "NTUSERID", 100))

                .Add(DGVTextBoxColumn("USER_LOGIN", "LOGIN", 50))
                .Add(DGVTextBoxColumn("CREATE_TS", "CREATE DATE", 80))
                .Add(DGVTextBoxColumn("UPDATE_TS", "UPDATE DATE", 80))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(CFG_FLD_CHANGE_RECIPIENT.FLD_CHANGE_RECIPIENT_ID).Visible = False

                    .Item(CFG_FLD_CHANGE_RECIPIENT.USER_LOGIN).Visible = False
                    .Item(CFG_FLD_CHANGE_RECIPIENT.CREATE_TS).Visible = False
                    .Item(CFG_FLD_CHANGE_RECIPIENT.UPDATE_TS).Visible = False
                End With
            End With

            Call PropertySpecify(dgv, _pan)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_FLD_CHANGE_RECIPIENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Columns_UsersRecipient(ByRef dgv As DataGridView, ByVal _pan As Panel)
        Try
            With dgv.Columns
                .Clear()
                .Add(DGVTextBoxColumn("PermissionGroup", "DEPT:", 90))
                .Add(DGVTextBoxColumn("NTUSERID", "NTUSERID", 100))
                .Add(DGVTextBoxColumn("ID", "ID", 80))
                .Add(DGVTextBoxColumn("FLD_CHANGE_RECIPIENT_ID", "Recip_ID", 60))
            End With

            With dgv
                .ColumnHeadersHeight = 20
                .RowHeadersWidth = 20
                With .Columns
                    .Item(RECIPIENT_USER.FLD_CHANGE_RECIPIENT_ID).Visible = False
                    .Item(RECIPIENT_USER.ID).Visible = False
                End With
            End With

            Call PropertySpecify(dgv, _pan)

        Catch ex As Exception
            MsgBox("Error in Columns_CFG_FLD_CHANGE_RECIPIENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub PropertyForm(ByRef dgv As DataGridView, ByRef frm As Form)
        Try
            Dim c As Int32 = 0

            For Each dgC As DataGridViewColumn In dgv.Columns
                If dgC.Visible = True Then
                    c = c + dgC.Width
                End If
            Next
            Debug.Print(c.ToString)

            With frm
                .Width = c + dgv.RowHeadersWidth + 35
                .Height = 600
                .StartPosition = FormStartPosition.CenterScreen
            End With

        Catch ex As Exception
            MsgBox("Error in SizeForm(dgv)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub PropertySpecify(ByRef dgv As DataGridView, ByRef _panAs As Panel)
        Try
            Dim c As Int32 = 0

            For Each dgC As DataGridViewColumn In dgv.Columns
                If dgC.Visible = True Then
                    c = c + dgC.Width
                End If
            Next

            Debug.Print(c.ToString)
            _panAs.Width = c + dgv.RowHeadersWidth + 25
            'With frm
            '    .Width = c + dgv.RowHeadersWidth + 35
            '    .Height = 600
            '    .StartPosition = FormStartPosition.CenterScreen
            'End With

        Catch ex As Exception
            MsgBox("Error in SizeForm(dgv)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
End Module
