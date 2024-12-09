
Public Class cContentInfo

    Dim db As cDBA
    Dim m_Spector_Cd As String
    Dim m_Cus_Prog_Id As Int32

    Dim intCus_prog_id() As Int32
    Dim strItem_Cd() As String
    Dim strItem_No() As String
    Dim strItem_Color() As String
    Dim strItem_Desc() As String
    Dim intDec_Met_Gr_Id() As Int32
    Dim intPack_Id() As Int32
    Dim intQuote_Ship_Meth_Id() As Int32
    Dim intQuote_Type_Id() As Int32
    Dim strSetup() As String
    Dim blSetupWaived() As Boolean
    Dim blDocid() As Int32


#Region "-------------Constructor----------------"
    Public Sub New()

        m_Spector_Cd = String.Empty
        m_Cus_Prog_Id = 0
    End Sub
    Public Sub New(ByVal p_spector_cd As String)

        m_Spector_Cd = Remove_Space(p_spector_cd) 'this fuction in gGlobal

    End Sub
    Public Sub New(ByVal p_id As Int32)

        m_Cus_Prog_Id = p_id
    End Sub
#End Region

    Private Sub Redim_Function(Optional ByRef pDt As DataTable = Nothing)
        Try
            ReDim intCus_prog_id(pDt.Rows.Count - 1)
            ReDim strItem_Cd(pDt.Rows.Count - 1)
            ReDim strItem_No(pDt.Rows.Count - 1)
            ReDim strItem_Color(pDt.Rows.Count - 1)
            ReDim strItem_Desc(pDt.Rows.Count - 1)
            ReDim intDec_Met_Gr_Id(pDt.Rows.Count - 1)
            ReDim intPack_Id(pDt.Rows.Count - 1)
            ReDim intQuote_Ship_Meth_Id(pDt.Rows.Count - 1)
            ReDim intQuote_Type_Id(pDt.Rows.Count - 1)
            ReDim strSetup(pDt.Rows.Count - 1)
            ReDim blSetupWaived(pDt.Rows.Count - 1)
            ReDim blDocid(pDt.Rows.Count - 1)
        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub



    Public Function First_Etape() As DataTable
        First_Etape = Nothing
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            'strSql =
            '    " Select Distinct l.CUS_PROG_ID, l.ITEM_CD,l.ITEM_NO ,l.ITEM_COLOR,l.ITEM_DESC,l.DEC_MET_ID ,l.PACK_ID, " &
            '    " l.QUOTE_SHIP_METHOD_ID, l.QUOTE_TYPE_ID, case l.SETUP_WAIVED when 1 THEN 'WAIVED' WHEN 0 THEN '' END AS SETUP,l.SETUP_WAIVED " &
            '    "  from MDB_CUS_PROG  m WITH (NoLock) inner join MDB_CUS_PROG_ITEM_LIST l WITH (NoLock) " &
            '    " on m.CUS_PROG_ID = l.CUS_PROG_ID where  m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            'JUSTIN-B-20190423 ADD C  l.ITEM_NO, l.ITEM_COLOR
            strSql =
              " Select Distinct l.CUS_PROG_ID, l.ITEM_CD,l.ITEM_DESC,l.DEC_MET_ID ,l.PACK_ID, l.ITEM_COLOR, l.ITEM_NO, l.ITEM_COLOR , " &
              " l.QUOTE_SHIP_METHOD_ID, l.QUOTE_TYPE_ID, case l.SETUP_WAIVED when 1 THEN 'WAIVED' WHEN 0 THEN '' END AS SETUP,l.SETUP_WAIVED , l.DocId" &
              "  from MDB_CUS_PROG  m WITH (NoLock) inner join MDB_CUS_PROG_ITEM_LIST l WITH (NoLock) " &
              " on m.CUS_PROG_ID = l.CUS_PROG_ID where  m.SPECTOR_CD = '" & m_Spector_Cd & "' "
            'JUSTIN-E-20190423
            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                First_Etape = dt
                Call Redim_Function(dt)
                Call LoadLine(dt)
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub LoadLine(ByRef pDt As DataTable)
        Try
            Dim cnt As Int32 = 0

            For Each pdrRow As DataRow In pDt.Rows

                If Not (pdrRow.Item("CUS_PROG_ID").Equals(DBNull.Value)) Then intCus_prog_id(cnt) = pdrRow.Item("CUS_PROG_ID")
                If Not (pdrRow.Item("ITEM_CD").Equals(DBNull.Value)) Then strItem_Cd(cnt) = pdrRow.Item("ITEM_CD").ToString
                'justin-b-20190423 change
                ' strItem_No(cnt) = Return_Items(Remove_Space(pdrRow.Item("ITEM_CD").ToString))
                'to
                If Not (pdrRow.Item("ITEM_NO").Equals(DBNull.Value)) Then strItem_No(cnt) = pdrRow.Item("ITEM_NO").ToString

                'justin-b-20190423 change
                'strItem_Color(cnt) = Return_Colors(Remove_Space(pdrRow.Item("ITEM_CD").ToString))
                'to
                If Not (pdrRow.Item("ITEM_COLOR").Equals(DBNull.Value)) Then strItem_Color(cnt) = pdrRow.Item("ITEM_COLOR").ToString
                'justin_e-20190423

                'If Not (pdrRow.Item("ITEM_CD").Equals(DBNull.Value)) Then strItem_Cd(cnt) = pdrRow.Item("ITEM_CD").ToString
                If Not (pdrRow.Item("ITEM_DESC").Equals(DBNull.Value)) Then strItem_Desc(cnt) = pdrRow.Item("ITEM_DESC").ToString
                If Not (pdrRow.Item("DEC_MET_ID").Equals(DBNull.Value)) Then intDec_Met_Gr_Id(cnt) = pdrRow.Item("DEC_MET_ID")
                If Not (pdrRow.Item("PACK_ID").Equals(DBNull.Value)) Then intPack_Id(cnt) = pdrRow.Item("PACK_ID")
                If Not (pdrRow.Item("QUOTE_SHIP_METHOD_ID").Equals(DBNull.Value)) Then intQuote_Ship_Meth_Id(cnt) = pdrRow.Item("QUOTE_SHIP_METHOD_ID")
                If Not (pdrRow.Item("QUOTE_TYPE_ID").Equals(DBNull.Value)) Then intQuote_Type_Id(cnt) = pdrRow.Item("QUOTE_TYPE_ID")
                If Not (pdrRow.Item("SETUP").Equals(DBNull.Value)) Then strSetup(cnt) = pdrRow.Item("SETUP").ToString
                If Not (pdrRow.Item("SETUP_WAIVED").Equals(DBNull.Value)) Then blSetupWaived(cnt) = pdrRow.Item("SETUP_WAIVED").ToString
                If Not (pdrRow.Item("DOCID").Equals(DBNull.Value)) Then blDocid(cnt) = pdrRow.Item("DOCID")
                cnt += 1

                If pDt.Rows.Count = cnt Then Exit Sub

                '  If fCountry() <> String.Empty Then strCountry = fCountry()
            Next

        Catch ex As Exception
            MsgBox("Error in cHeaderInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function Return_Items(ByVal pItem_Cd As String) As String
        Return_Items = ""
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql =
            " Select  SUBSTRING( (select distinct ',  ' +  l.ITEM_NO as [text()] " &
            " from MDB_CUS_PROG  m WITH (NoLock) inner join MDB_CUS_PROG_ITEM_LIST l WITH (NoLock)  on m.CUS_PROG_ID = l.CUS_PROG_ID " &
            " where  m.SPECTOR_CD = '" & Remove_Space(m_Spector_Cd) & "' and  l.ITEM_CD = '" & Remove_Space(pItem_Cd) & "' " &
            " for XML PATH('')   ) ,2,1000) [Items] "

            dt = db.DataTable(strSql)

            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function Return_Colors(ByVal pItem_Cd As String) As String
        Return_Colors = ""
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String
            strSql =
            " Select  SUBSTRING( (select distinct ',' +  l.ITEM_COLOR as [text()] " &
            " from MDB_CUS_PROG  m WITH (NoLock) inner join MDB_CUS_PROG_ITEM_LIST l WITH (NoLock)  on m.CUS_PROG_ID = l.CUS_PROG_ID " &
            " where  m.SPECTOR_CD = '" & Remove_Space(m_Spector_Cd) & "' and  l.ITEM_CD = '" & Remove_Space(pItem_Cd) & "' " &
            " for XML PATH('')   ) ,2,1000) [COLORS] "


            dt = db.DataTable(strSql)

            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function Return_Decorat(ByVal p_Id As Int32) As String
        Return_Decorat = String.Empty
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            'JUSTIN-B-20190424 CHANGED
            'strSql = _
            '      " SELECT	DEC_MET_ID, DEC_MET_CD FROM MDB_CFG_DEC_MET WITH (NoLock)  " & _
            '      " WHERE IMPRINT_LIST_ITEM = 1 and DEC_MET_GROUP_ID = " & p_Id & " ORDER BY DEC_MET_CD "
            'TO
            strSql =
                  " SELECT	DEC_MET_CD ,DEC_MET_NAME FROM MDB_CFG_DEC_MET WITH (NoLock)  " &
                  " WHERE IMPRINT_LIST_ITEM = 1 and DEC_MET_ID = " & p_Id
            'JUSTIN_E20190424

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Return_Decorat = Remove_Space(dt.Rows(0).Item("DEC_MET_NAME").ToString)
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Return_Pack(ByVal p_Id As Int32) As String
        Return_Pack = String.Empty
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql =
                " SELECT	PACK_ID, PACK_CD FROM  MDB_CFG_PACK WITH (Nolock) " &
                "  where PACK_ID = " & p_Id & " ORDER BY PACK_CD "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Return_Pack = dt.Rows(0).Item("PACK_CD").ToString
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'JUSTIN-B-20190424 NEWADD FOR QUOTE_SHIP_METHOD_ID
    Public Function Return_Quote_Ship_Method(ByVal p_Id As Int32) As String
        Return_Quote_Ship_Method = String.Empty
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql =
                " SELECT  top 1 ID , ENUM_VALUE  FROM MDB_CFG_ENUM  WITH (Nolock) " &
                "  where ID = " & p_Id & " and ENUM_CAT = 'QUOTE_SHIP_METHOD_ID' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Return_Quote_Ship_Method = dt.Rows(0).Item("ENUM_VALUE").ToString
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'JUSTIN-E-20190424

    Public Function Return_Type(ByVal p_Id As Int32) As String
        Return_Type = String.Empty
        Try
            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
               " SELECT ID AS Quote_Type_ID, ENUM_VALUE AS Quote_Type_Desc  " & _
               " FROM MDB_CFG_ENUM WITH (Nolock) WHERE ENUM_CAT = 'QUOTE_TYPE_ID' and  ID = " & p_Id

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Return_Type = dt.Rows(0).Item("Quote_Type_Desc").ToString
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'justin'
    Public Function I_COMMENT(ByVal p_Cnt As Int32, ByVal p_Program_Type As String, ByRef o_SwitchLang As c_SwitchLang) As DataTable
        I_COMMENT = Nothing
        Dim lang_type As String = "en"

        If IsNothing(o_SwitchLang.o_English) Then
            lang_type = "fr"
        End If
        Try
            db = New cDBA
            Dim strSql As String = ""
            Dim dt As DataTable

            'justin 19515
            '**********--one line display 
            'If p_Program_Type = "Program" Then
            'PROG'
            'strSql = "select ( Select CONCAT (   CAST( ROW_NUMBER() OVER(ORDER BY FLD_NAME ) as varchar(10))  ,    '.' ,   cg.FLD_NAME  ,'         ' )  FROM  " &
            '    "  MDB_ITEM_MASTER m   WITH (NOLOCK) inner join  MDB_ITEM_FLD_VALUE fv  WITH (NOLOCK) on  " &
            '    " m.ITEM_MASTER_ID = FV.ITEM_MASTER_ID inner join MDB_CFG_ITEM_FLD cg On " &
            '    " FV.ITEM_FLD_ID = cg.ITEM_FLD_ID  where item_cd = '" & strItem_Cd(p_Cnt).ToString.Trim & "'" & " and cg.ITEM_FLD_ID = 529 " &
            '    " and FV.VALUE_INT = 1   " &
            '    " FOR XML PATH ('') ) as MESSAGE_DESC "
            'End If
            'If p_Program_Type = "Quote" Then
            'QUOTE
            'strSql =
            '     "   select ( 	select CONCAT (  CAST( ROW_NUMBER() OVER(ORDER BY MESSAGE_DESC ) as varchar(10))  ,    '.' ,   MESSAGE_DESC , '         '    )  " &
            '     " from " &
            '     " ( " &
            '      " Select distinct l.MESSAGE_DESC  from MDB_PROG_COMMENT m " &
            '      " inner Join MDB_MESSAGE_DESC l On l.MESSAGE_ID = m.MESSAGE_ID " &
            '      " inner join MDB_CUS_PROG k On k.CUS_PROG_GUID = m.CUS_PROG_GUID " &
            '      " where m.item_cd = '" & strItem_Cd(p_Cnt) & "'  " & "And m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.TAAL_CD = '" & lang_type & "' and len(l.MESSAGE_DESC) > 0 " &
            '      " union all " &
            '      " Select  m.COMMENT_DESC from MDB_PROG_COMMENT m " &
            '      " where m.item_cd = '" & strItem_Cd(p_Cnt) & "'  " & "And m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And Len(m.COMMENT_DESC) > 0 " &
            '      " ) t 	 FOR XML PATH ('') ) as MESSAGE_DESC "
            'End If
            '**********--one line display end

            'justin 19515
            '**********--by item display--begin
            If p_Program_Type = "Program" Then
                'PROG'
                strSql = " Select CONCAT (   CAST( ROW_NUMBER() OVER(ORDER BY FLD_NAME ) as varchar(10))  ,    '.' ,   cg.FLD_NAME ) as MESSAGE_DESC FROM  " &
                    "  MDB_ITEM_MASTER m   WITH (NOLOCK) inner join  MDB_ITEM_FLD_VALUE fv  WITH (NOLOCK) on  " &
                    " m.ITEM_MASTER_ID = FV.ITEM_MASTER_ID inner join MDB_CFG_ITEM_FLD cg On " &
                    " FV.ITEM_FLD_ID = cg.ITEM_FLD_ID  where item_cd = '" & strItem_Cd(p_Cnt).ToString.Trim & "'" & " and cg.ITEM_FLD_ID = 529 " &
                    " and FV.VALUE_INT = 1   " &
                    "  "
                'MsgBox(strSql)

            End If
            If p_Program_Type = "Quote" Then
                'QUOTE
                strSql =
                     "   select CONCAT (  CAST( ROW_NUMBER() OVER(ORDER BY MESSAGE_DESC ) as varchar(10))  ,    '.' ,   t.MESSAGE_DESC  )  as MESSAGE_DESC  " &
                     " from " &
                     " ( " &
                      " Select distinct l.MESSAGE_DESC  from MDB_PROG_COMMENT m " &
                      " inner Join MDB_MESSAGE_DESC l On l.MESSAGE_ID = m.MESSAGE_ID " &
                      " inner join MDB_CUS_PROG k On k.CUS_PROG_GUID = m.CUS_PROG_GUID " &
                      " where m.item_cd = '" & strItem_Cd(p_Cnt) & "'  " & "And k.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.TAAL_CD = '" & lang_type & "' and len(l.MESSAGE_DESC) > 0 " &
                      " union all " &
                      " Select  m.COMMENT_DESC from MDB_PROG_COMMENT m " &
                      " where m.item_cd = '" & strItem_Cd(p_Cnt) & "'  " & "And m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And Len(m.COMMENT_DESC) > 0 " &
                      "  ) t	"
                'MsgBox(strSql)
            End If
            '**********--by item display--end

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                I_COMMENT = dt
            End If

        Catch ex As Exception
            MsgBox("Error In I_COMMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    ''


#Region "##################Display EQP,QTY,PRICE,TOTAL,RUN-PRICE,SETUP PRICE################"
    'when execute function First_Etape we populate array variable and we can use in same time in the function in the same file.
    Public Function EQP(ByVal p_Cnt As Int32) As DataTable
        EQP = Nothing
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            ' l.EQP_PCT,  l.MIN_QTY_ORD , l.UNIT_PRICE,l.SETUP_PRICE  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l 

            strSql = _
             " Select  ROW_NUMBER() OVER(ORDER BY l.EQP_PCT) As Cnt, l.EQP_PCT" & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  On m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_NO = '" & strItem_No(p_Cnt) & "' And RTRIM(l.ITEM_COLOR)  = '" & strItem_Color(p_Cnt) & "' " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "


            strSql =
            " Select  l.EQP_PCT" &
            "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " &
            " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) &
            " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " &
            "And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And " &
            " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " &
            " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " &
            " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "
            'justin-20190423-delete condition            " And l.ITEM_DESC = '" & CType(strItem_Desc(p_Cnt), String) & "'" &


            'If strItem_No(p_Cnt).IndexOf(",") <> -1 Then
            '    strSql &= _
            '             " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt).Substring(0, strItem_No(p_Cnt).IndexOf(","))) & "' "
            'Else
            '    strSql &= _
            '       " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt)) & "' "
            'End If

            'MsgBox(strItem_Color(p_Cnt))

            If strItem_Color(p_Cnt).IndexOf(",") <> -1 Then
                strSql &=
                      " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt).Substring(0, strItem_Color(p_Cnt).IndexOf(","))) & "' "
            Else
                If Remove_Space(strItem_Color(p_Cnt)) <> "ALL" Then
                    strSql &=
                           " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' "
                End If
            End If


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                EQP = dt
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function QTY(ByVal p_Cnt As Int32) As DataTable
        QTY = Nothing
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            ' l.EQP_PCT,  l.MIN_QTY_ORD , l.UNIT_PRICE,l.SETUP_PRICE  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l 

            strSql = _
             " Select  ROW_NUMBER() OVER(ORDER BY l.MIN_QTY_ORD) AS Cnt, l.MIN_QTY_ORD" & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_NO = '" & strItem_No(p_Cnt) & "' And RTRIM(l.ITEM_COLOR)  = '" & strItem_Color(p_Cnt) & "' " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            strSql = _
            " Select  l.MIN_QTY_ORD" & _
            "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
            " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
            " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
            " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
            " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
            " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            'If strItem_No(p_Cnt).IndexOf(",") <> -1 Then
            '    strSql &= _
            '       " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt).Substring(0, strItem_No(p_Cnt).IndexOf(","))) & "' "
            'Else
            '    strSql &= _
            '       " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt)) & "' "
            'End If


            If strItem_Color(p_Cnt).IndexOf(",") <> -1 Then
                strSql &=
                      " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt).Substring(0, strItem_Color(p_Cnt).IndexOf(","))) & "' "
            Else
                If Remove_Space(strItem_Color(p_Cnt)) <> "ALL" Then
                    strSql &= _
                           " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' "
                End If
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                QTY = dt
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function PRIX(ByVal p_Cnt As Int32) As DataTable
        PRIX = Nothing
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            ' l.EQP_PCT,  l.MIN_QTY_ORD , l.UNIT_PRICE,l.SETUP_PRICE  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l 

            strSql = _
             " Select  ROW_NUMBER() OVER(ORDER BY l.UNIT_PRICE) AS Cnt, l.UNIT_PRICE " & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_NO = '" & strItem_No(p_Cnt) & "' And RTRIM(l.ITEM_COLOR)  = '" & strItem_Color(p_Cnt) & "' " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "


            strSql =
          " Select l.UNIT_PRICE " &
          "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " &
          " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " &
          " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt)) & "' And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' " &
          " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " &
          " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " &
          " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " &
          " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            'If strItem_No(p_Cnt).IndexOf(",") <> -1 Then
            '    strSql &= _
            '       " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt).Substring(0, strItem_No(p_Cnt).IndexOf(","))) & "' "
            'Else
            '    strSql &= _
            '       " And l.ITEM_NO = '" & Remove_Space(strItem_No(p_Cnt)) & "' "
            'End If


            If strItem_Color(p_Cnt).IndexOf(",") <> -1 Then
                strSql &= _
                      " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt).Substring(0, strItem_Color(p_Cnt).IndexOf(","))) & "' "
            Else
                If Remove_Space(strItem_Color(p_Cnt)) <> "ALL" Then
                    strSql &= _
                           " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' "
                End If
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                PRIX = dt
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function RUN_CHARGE(ByVal p_Cnt As Int32) As DataTable
        RUN_CHARGE = Nothing
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            ' l.EQP_PCT,  l.MIN_QTY_ORD , l.UNIT_PRICE,l.SETUP_PRICE  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l 

            strSql = _
             " Select ROW_NUMBER() OVER(ORDER BY l.RUN_CHARGE) AS Cnt, l.RUN_CHARGE " & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_NO = '" & strItem_No(p_Cnt) & "' And RTRIM(l.ITEM_COLOR)  = '" & strItem_Color(p_Cnt) & "' " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            strSql = _
           " Select l.RUN_CHARGE " & _
           " from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
           " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
           " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
           " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
           " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
           " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "


            If strItem_Color(p_Cnt).IndexOf(",") <> -1 Then
                strSql &= _
                      " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt).Substring(0, strItem_Color(p_Cnt).IndexOf(","))) & "' "
            Else
                If Remove_Space(strItem_Color(p_Cnt)) <> "ALL" Then
                    strSql &= _
                                       " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' "
                End If
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                RUN_CHARGE = dt
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function SETUP_PRICE(ByVal p_Cnt As Int32) As DataTable
        SETUP_PRICE = Nothing
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            ' l.EQP_PCT,  l.MIN_QTY_ORD , l.UNIT_PRICE,l.SETUP_PRICE  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l 

            strSql = _
             " Select  ROW_NUMBER() OVER(ORDER BY l.UNIT_PRICE) AS Cnt, l.SETUP_PRICE " & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_NO = '" & strItem_No(p_Cnt) & "' And RTRIM(l.ITEM_COLOR)  = '" & strItem_Color(p_Cnt) & "' " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "


            strSql = _
             " Select l.SETUP_PRICE " & _
             "  from MDB_CUS_PROG m inner join MDB_CUS_PROG_ITEM_LIST l  on m.CUS_PROG_ID = l.CUS_PROG_ID   " & _
             " where m.CUS_PROG_ID = " & intCus_prog_id(p_Cnt) & " And l.ITEM_CD = '" & strItem_Cd(p_Cnt) & "'  " & _
             " And l.ITEM_DESC = '" & strItem_Desc(p_Cnt) & "' And l.DEC_MET_GROUP_ID = " & intDec_Met_Gr_Id(p_Cnt) & " And  " & _
             " l.PACK_ID = " & intPack_Id(p_Cnt) & " And l.QUOTE_SHIP_METHOD_ID = " & intQuote_Ship_Meth_Id(p_Cnt) & "  " & _
             " And l.QUOTE_TYPE_ID = " & intQuote_Type_Id(p_Cnt) & "  And l.SETUP_WAIVED = '" & blSetupWaived(p_Cnt) & "' " & _
             " And m.SPECTOR_CD = '" & m_Spector_Cd & "' "

            If strItem_Color(p_Cnt).IndexOf(",") <> -1 Then
                strSql &= _
                      " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt).Substring(0, strItem_Color(p_Cnt).IndexOf(","))) & "' "
            Else
                If Remove_Space(strItem_Color(p_Cnt)) <> "ALL" Then
                    strSql &= _
                                       " And RTRIM(l.ITEM_COLOR)  = '" & Remove_Space(strItem_Color(p_Cnt)) & "' "
                End If
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                SETUP_PRICE = dt
            End If

        Catch ex As Exception
            MsgBox("Error in cContentInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#End Region

#Region "-------------------Public Properties------------------"
    Public Property CUS_PROG_ID As Int32()
        Get
            Return intCus_prog_id
        End Get
        Set(ByVal value As Int32())
            intCus_prog_id = value
        End Set
    End Property
    Public Property ITEM_CD As String()
        Get
            Return strItem_Cd
        End Get
        Set(ByVal value As String())
            strItem_Cd = value
        End Set
    End Property
    Public Property ITEM_NO As String()
        Get
            Return strItem_No
        End Get
        Set(ByVal value As String())
            strItem_No = value
        End Set
    End Property
    Public Property ITEM_COLOR As String()
        Get
            Return strItem_Color
        End Get
        Set(ByVal value As String())
            strItem_Color = value
        End Set
    End Property
    Public Property ITEM_DESC As String()
        Get
            Return strItem_Desc
        End Get
        Set(ByVal value As String())
            strItem_Desc = value
        End Set
    End Property
    Public Property DEC_MET_GR_ID As Int32()
        Get
            Return intDec_Met_Gr_Id
        End Get
        Set(ByVal value As Int32())
            intDec_Met_Gr_Id = value
        End Set
    End Property

    Public Property PACK_ID As Int32()
        Get
            Return intPack_Id
        End Get
        Set(ByVal value As Int32())
            intPack_Id = value
        End Set
    End Property
    Public Property QUOTE_SHIP_METH_ID As Int32()
        Get
            Return intQuote_Ship_Meth_Id
        End Get
        Set(ByVal value As Int32())
            intQuote_Ship_Meth_Id = value
        End Set
    End Property
    Public Property QUOTE_TYPE_ID As Int32()
        Get
            Return intQuote_Type_Id
        End Get
        Set(ByVal value As Int32())
            intQuote_Type_Id = value
        End Set
    End Property
    Public Property SETUP As String()
        Get
            Return strSetup
        End Get
        Set(ByVal value As String())
            strSetup = value
        End Set
    End Property
    Public Property SETUP_WAIVED As Boolean()
        Get
            SETUP_WAIVED = blSetupWaived
        End Get
        Set(ByVal value As Boolean())
            blSetupWaived = value
        End Set
    End Property
    Public Property DOCID As Int32()
        Get
            DOCID = blDocid
        End Get
        Set(ByVal value As Int32())
            blDocid = value
        End Set
    End Property
#End Region
End Class
