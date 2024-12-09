
Public Class cHeaderInfo

    Dim db As cDBA

    'if change or add new properties we need add same in Enum from gGlobal.HeaderInfo 

    Dim intCus_Prog_Id As Int32
    Dim strCus_No As String
    Dim intProgType As Int32
    Dim strSpectorCd As String
    Dim strImprint As String
    Dim strProg_Csr As String
    Dim dtStart_Dt As Date
    Dim dtEnd_Dt As Date
    Dim strProg_Comment As String

    Dim strCnt_FullName As String
    Dim strCnt_Tel As String
    Dim strCnt_Email As String

    Dim intCurrent_Rev_No As Int32
    Dim strCreate_By As String
    Dim strCmp_Name As String
    Dim strAddr1 As String
    Dim strAddr2 As String
    Dim strAddr3 As String
    Dim strCity_Code As String
    Dim strSpector_Contact As String
    Dim strSpector_Email As String
    Dim strSpector_CUS_PROG_GUID As String
    Dim strSpector_CUS_PROG_CD As String
    Dim strSpector_CREATE_TS As String


    Dim strCountry As String

    Private Function fCountry() As String
        fCountry = String.Empty
        Try
            db = New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql = _
                " select cmp_fctry As Country_Code, oms60_0 as Country from cicmpy c " & _
                " inner join land l on c.cmp_fctry = l.landcode where c.cmp_code = '" & Remove_Space(strCus_No) & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                fCountry = dt.Rows(0).Item("Country").ToString
            End If

        Catch ex As Exception
            MsgBox("Error in cHeaderInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    Public Sub New(ByVal p_Cus_Prog_Id As Int32)
        Call Load(p_Cus_Prog_Id)
    End Sub
    Public Sub New(ByVal p_Spector_Cd As String)
        Call Load(p_Spector_Cd)
    End Sub
    Private Sub Init()
        intCus_Prog_Id = 0
        strCus_No = String.Empty
        intProgType = 0
        strSpectorCd = String.Empty
        strImprint = String.Empty
        strProg_Csr = String.Empty
        dtStart_Dt = Date.Now
        dtEnd_Dt = Date.Now
        strProg_Comment = String.Empty

        strCnt_FullName = String.Empty
        strCnt_Tel = String.Empty
        strCnt_Email = String.Empty

        intCurrent_Rev_No = 0
        strCreate_By = String.Empty
        strCmp_Name = String.Empty
        strAddr1 = String.Empty
        strAddr2 = String.Empty
        strAddr3 = String.Empty
        strCity_Code = String.Empty

        strSpector_Contact = String.Empty
        strSpector_Email = String.Empty
        strSpector_CUS_PROG_GUID = String.Empty
        strSpector_CUS_PROG_CD = String.Empty
        strSpector_CREATE_TS = Date.Now
    End Sub
    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("CUS_PROG_ID").Equals(DBNull.Value)) Then intCus_Prog_Id = pdrRow.Item("CUS_PROG_ID")
            If Not (pdrRow.Item("CUS_NO").Equals(DBNull.Value)) Then strCus_No = pdrRow.Item("CUS_NO").ToString
            If Not (pdrRow.Item("PROG_TYPE").Equals(DBNull.Value)) Then intProgType = pdrRow.Item("PROG_TYPE")
            If Not (pdrRow.Item("SPECTOR_CD").Equals(DBNull.Value)) Then strSpectorCd = pdrRow.Item("SPECTOR_CD").ToString
            If Not (pdrRow.Item("IMPRINT").Equals(DBNull.Value)) Then strImprint = pdrRow.Item("IMPRINT").ToString
            If Not (pdrRow.Item("PROG_CSR").Equals(DBNull.Value)) Then strProg_Csr = pdrRow.Item("PROG_CSR").ToString
            If Not (pdrRow.Item("START_DT").Equals(DBNull.Value)) Then dtStart_Dt = pdrRow.Item("START_DT")
            If Not (pdrRow.Item("END_DT").Equals(DBNull.Value)) Then dtEnd_Dt = pdrRow.Item("END_DT")
            If Not (pdrRow.Item("PROG_COMMENTS").Equals(DBNull.Value)) Then strProg_Comment = pdrRow.Item("PROG_COMMENTS").ToString
            If Not (pdrRow.Item("Cnt_Contact").Equals(DBNull.Value)) Then strCnt_FullName = pdrRow.Item("Cnt_Contact").ToString
            If Not (pdrRow.Item("cnt_f_tel").Equals(DBNull.Value)) Then strCnt_Tel = pdrRow.Item("cnt_f_tel").ToString
            If Not (pdrRow.Item("cnt_email").Equals(DBNull.Value)) Then strCnt_Email = pdrRow.Item("cnt_email").ToString

            If Not (pdrRow.Item("CURRENT_REV_NO").Equals(DBNull.Value)) Then intCurrent_Rev_No = pdrRow.Item("CURRENT_REV_NO")
            If Not (pdrRow.Item("CREATE_BY").Equals(DBNull.Value)) Then strCreate_By = pdrRow.Item("CREATE_BY").ToString
            If Not (pdrRow.Item("cmp_name").Equals(DBNull.Value)) Then strCmp_Name = pdrRow.Item("cmp_name").ToString
            If Not (pdrRow.Item("cmp_fadd1").Equals(DBNull.Value)) Then strAddr1 = pdrRow.Item("cmp_fadd1").ToString
            If Not (pdrRow.Item("cmp_fadd2").Equals(DBNull.Value)) Then strAddr2 = pdrRow.Item("cmp_fadd2").ToString
            If Not (pdrRow.Item("cmp_fadd3").Equals(DBNull.Value)) Then strAddr3 = pdrRow.Item("cmp_fadd3").ToString
            If Not (pdrRow.Item("City_Code").Equals(DBNull.Value)) Then strCity_Code = pdrRow.Item("City_Code").ToString


            If Not (pdrRow.Item("Spect_Contact").Equals(DBNull.Value)) Then strSpector_Contact = pdrRow.Item("Spect_Contact").ToString
            If Not (pdrRow.Item("Email").Equals(DBNull.Value)) Then strSpector_Email = pdrRow.Item("Email").ToString

            If Not (pdrRow.Item("CUS_PROG_GUID").Equals(DBNull.Value)) Then strSpector_CUS_PROG_GUID = pdrRow.Item("CUS_PROG_GUID").ToString
            If Not (pdrRow.Item("CUS_PROG_CD").Equals(DBNull.Value)) Then strSpector_CUS_PROG_CD = pdrRow.Item("CUS_PROG_CD").ToString
            If Not (pdrRow.Item("CREATE_TS").Equals(DBNull.Value)) Then strSpector_CREATE_TS = pdrRow.Item("CREATE_TS").ToString


            If fCountry() <> String.Empty Then strCountry = fCountry()


        Catch ex As Exception
            MsgBox("Error In cHeaderInfo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Load(ByVal p_Cus_Prog_Id As Int32)
        Try

            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            'strSql =
            '    " Select m.CUS_PROG_ID, m.CUS_NO, m.PROG_TYPE, m.SPECTOR_CD, m.IMPRINT, m.PROG_CSR, m.START_DT, m.END_DT, " &
            '    " m.PROG_COMMENTS, cn.FullName, m.CURRENT_REV_NO, m.CREATE_BY, " &
            '    " c.cmp_name, c.cmp_fadd1, c.cmp_fadd2, c.cmp_fadd3, (c.cmp_fcity + ', ' + c.StateCode + ' ' + cmp_fpc ) As City_Code " &
            '    " from MDB_CUS_PROG m inner join cicmpy c ON m.CUS_NO = c.cmp_code LEFT JOIN cicntp cn on m.CONTACT_ID = cn.ID  " &
            '    " where cus_pro_id = " & p_Cus_Prog_Id


            strSql =
             " select m.CUS_PROG_ID, m.CUS_NO, m.PROG_TYPE, m.SPECTOR_CD, m.IMPRINT, m.PROG_CSR , m.START_DT , m.END_DT, " &
               " m.PROG_COMMENTS, cn.FullName AS Cnt_Contact, cn.cnt_f_tel,cn.cnt_email, m.CURRENT_REV_NO, m.CREATE_BY,  c.cmp_name, c.cmp_fadd1,c.cmp_fadd2, c.cmp_fadd3," &
               " (c.cmp_fcity + ', ' + c.StateCode + ' ' + cmp_fpc ) As City_Code, u.Fullname AS Spect_Contact, u.Email ,m.CUS_PROG_GUID , m.PROG_CD , m.CREATE_TS " &
               " from MDB_CUS_PROG m inner join cicmpy c ON m.CUS_NO = c.cmp_code LEFT JOIN cicntp cn on m.CONTACT_ID = cn.ID " &
               " left join user_permissions_info u on m.PROG_CSR = u.User_Name where ISNULL(cn.active_y,0) = 1 AND  m.cus_pro_id = " & p_Cus_Prog_Id
            '++ID 11.13.2019 added criteria for exclude inactive contacts cn.active_y = 1 

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(dt.Rows(0))
            End If


        Catch ex As Exception
            MsgBox("Error in cHeaderInfo.Load(int)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Load(ByVal p_Spector_CD As String)
        Try

            db = New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = _
                " select m.CUS_PROG_ID, m.CUS_NO, m.PROG_TYPE, m.SPECTOR_CD, m.IMPRINT, m.PROG_CSR , m.START_DT , m.END_DT,  " & _
                " m.PROG_COMMENTS, cn.FullName, m.CURRENT_REV_NO, m.CREATE_BY, " & _
                " c.cmp_name, c.cmp_fadd1,c.cmp_fadd2, c.cmp_fadd3, (c.cmp_fcity + ', ' + c.StateCode + ' ' + cmp_fpc ) As City_Code " & _
                " from MDB_CUS_PROG m inner join cicmpy c ON m.CUS_NO = c.cmp_code LEFT JOIN cicntp cn on m.CONTACT_ID = cn.ID  " & _
                " where m.SPECTOR_CD = '" & p_Spector_CD & "'"

            strSql =
               " select m.CUS_PROG_ID, m.CUS_NO, m.PROG_TYPE, m.SPECTOR_CD, m.IMPRINT, m.PROG_CSR , m.START_DT , m.END_DT, " &
               " m.PROG_COMMENTS, cn.FullName AS Cnt_Contact, cn.cnt_f_tel,cn.cnt_email, m.CURRENT_REV_NO, m.CREATE_BY, " &
               " c.cmp_name, c.cmp_fadd1,c.cmp_fadd2, c.cmp_fadd3," &
               " (c.cmp_fcity + ', ' + c.StateCode + ' ' + cmp_fpc ) As City_Code, u.Fullname AS Spect_Contact, u.Email , m.CUS_PROG_GUID , m.PROG_CD as CUS_PROG_CD, m.CREATE_TS" &
               " from MDB_CUS_PROG m inner join cicmpy c ON m.CUS_NO = c.cmp_code LEFT JOIN cicntp cn on m.CONTACT_ID = cn.ID " &
               " left join user_permissions_info u on m.PROG_CSR = u.User_Name where ISNULL(cn.active_y,0) = 1 and  m.SPECTOR_CD = '" & p_Spector_CD & "'" 'P15-0591' 
            '++ID 11.13.2019 added criteria for exclude inactive contacts cn.active_y = 1 

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(dt.Rows(0))
            End If


        Catch ex As Exception
            MsgBox("Error in cHeaderInfo.Load(int)." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function COMMENT(ByVal h_CUS_PROG_GUID As String, ByVal h_cus_prog_id As String, ByVal p_Program_Type As String, ByRef o_SwitchLang As c_SwitchLang) As DataTable
        COMMENT = Nothing
        Dim lang_type As String = "en"

        If IsNothing(o_SwitchLang.o_English) Then
            lang_type = "fr"
        End If
        Try
            db = New cDBA
            Dim strSql As String = ""
            Dim dt As DataTable
            '********justin 20190515
            '****************for one line display begin
            'If p_Program_Type = "Quote" Then
            'strSql =
            '       "select 		(select CONCAT (  CAST( ROW_NUMBER() OVER(ORDER BY t.comment_desc ) as varchar(10))  ,    '.' ,   t.comment_desc  ,'         ' )     from   ( " &
            '   " Select comment_desc from MDB_Prog_Comment P " &
            '   " where MESSAGE_ID = 0 And (RTrim(LTrim(ITEM_CD)) = '' or ITEM_CD is null) and " &
            '   " P.CUS_PROG_GUID = '" & h_CUS_PROG_GUID & "'  " &
            '   " And cus_prog_id = '" & h_cus_prog_id & "' " &
            '    " union all  " &
            '   " Select distinct l.MESSAGE_DESC  As comment_desc from MDB_PROG_COMMENT m " &
            '   " inner Join MDB_MESSAGE_DESC l on l.MESSAGE_ID = m.MESSAGE_ID  " &
            '   " inner Join MDB_CUS_PROG k on k.CUS_PROG_GUID = m.CUS_PROG_GUID  " &
            '   " where(LTrim(LTrim(m.item_cd)) = '')  " &
            '   " And l.TAAL_CD = '" & lang_type & "' and len(l.MESSAGE_DESC) > 0 " &
            '   " And m.CUS_PROG_ID = '" & h_cus_prog_id & "' " &
            '   " ) t FOR XML PATH ('') 		) as comment_desc "
            'End If
            'If p_Program_Type = "Program" Then
            ' strSql =
            '         "select 		(select CONCAT (  CAST( ROW_NUMBER() OVER(ORDER BY t.comment_desc ) as varchar(10))  ,    '.' ,   t.comment_desc  ,'         ')     from   ( " &
            '     " select prog_comments as comment_desc from Mdb_Cus_Prog  where Spector_Cd = '" & strSpectorCd & "' " &
            '     "  ) t FOR XML PATH ('') 		) as comment_desc "
            'End If
            '****************for one line display end

            '********justin 20190515
            '****************for item display begin
            If p_Program_Type = "Quote" Then
                strSql =
                    " select CONCAT ( CAST( ROW_NUMBER() OVER(ORDER BY t.comment_desc ) as varchar(10))  ,    '.' ,   t.comment_desc ) as comment_desc   from   ( " &
                " Select comment_desc from MDB_Prog_Comment P " &
                " where MESSAGE_ID = 0 And (RTrim(LTrim(ITEM_CD)) = '' or ITEM_CD is null) and " &
                " P.CUS_PROG_GUID = '" & h_CUS_PROG_GUID & "'  " &
                " And cus_prog_id = '" & h_cus_prog_id & "' " &
                 " union all  " &
                " Select distinct l.MESSAGE_DESC  As comment_desc from MDB_PROG_COMMENT m " &
                " inner Join MDB_MESSAGE_DESC l on l.MESSAGE_ID = m.MESSAGE_ID  " &
                " inner Join MDB_CUS_PROG k on k.CUS_PROG_GUID = m.CUS_PROG_GUID  " &
                " where(LTrim(LTrim(m.item_cd)) = '')  " &
                " And l.TAAL_CD = '" & lang_type & "' and len(l.MESSAGE_DESC) > 0 " &
                " And m.CUS_PROG_ID = '" & h_cus_prog_id & "' " &
                " )  t "


            End If
            If p_Program_Type = "Program" Then
                strSql =
                    " select CONCAT ( CAST( ROW_NUMBER() OVER(ORDER BY t.comment_desc ) as varchar(10))  ,    '.' ,  replace( t.comment_desc, CHAR(13),',' )  )  as comment_desc  from   ( " &
                " select  replace( prog_comments, CHAR(10),'  ' ) as comment_desc from Mdb_Cus_Prog  where Spector_Cd = '" & strSpectorCd & "' " &
                "  ) t "
            End If
            '****************for item display end


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                COMMENT = dt
            End If

        Catch ex As Exception
            MsgBox("Error in I_COMMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#Region "################Puclic Properties###################"
    Public Property CUS_PROG_ID As Int32
        Get
            CUS_PROG_ID = intCus_Prog_Id
        End Get
        Set(ByVal value As Int32)
            intCus_Prog_Id = value
        End Set
    End Property
    Public Property CUS_NO As String
        Get
            CUS_NO = strCus_No
        End Get
        Set(ByVal value As String)
            strCus_No = value
        End Set
    End Property
    Public Property PROG_TYPE As Int32
        Get
            PROG_TYPE = intProgType
        End Get
        Set(ByVal value As Int32)
            intProgType = value
        End Set
    End Property
    Public Property SPECTOR_CD As String
        Get
            SPECTOR_CD = strSpectorCd
        End Get
        Set(ByVal value As String)
            strSpectorCd = value
        End Set
    End Property
    Public Property IMPRINT As String
        Get
            IMPRINT = strImprint
        End Get
        Set(ByVal value As String)
            strImprint = value
        End Set
    End Property
    Public Property PROG_CSR As String
        Get
            PROG_CSR = strProg_Csr
        End Get
        Set(ByVal value As String)
            strProg_Csr = value
        End Set
    End Property
    Public Property START_DT As Date
        Get
            START_DT = dtStart_Dt
        End Get
        Set(ByVal value As Date)
            dtStart_Dt = value
        End Set
    End Property
    Public Property END_DT As Date
        Get
            END_DT = dtEnd_Dt
        End Get
        Set(ByVal value As Date)
            dtEnd_Dt = value
        End Set
    End Property
    Public Property PROG_COMMENTS As String
        Get
            PROG_COMMENTS = strProg_Comment
        End Get
        Set(ByVal value As String)
            strProg_Comment = value
        End Set
    End Property
    Public Property CNT_FULLNAME As String
        Get
            CNT_FULLNAME = strCnt_FullName
        End Get
        Set(ByVal value As String)
            strCnt_FullName = value
        End Set
    End Property
    Public Property CNT_TEL As String
        Get
            CNT_TEL = strCnt_Tel
        End Get
        Set(ByVal value As String)
            strCnt_Tel = value
        End Set
    End Property
    Public Property CNT_EMAIL As String
        Get
            CNT_EMAIL = strCnt_Email
        End Get
        Set(ByVal value As String)
            strCnt_Email = value
        End Set
    End Property

    Public Property CUS_PROG_GUID As String
        Get
            CUS_PROG_GUID = strSpector_CUS_PROG_GUID
        End Get
        Set(ByVal value As String)
            strSpector_CUS_PROG_GUID = value
        End Set
    End Property

    Public Property CUS_PROG_CD As String
        Get
            CUS_PROG_CD = strSpector_CUS_PROG_CD
        End Get
        Set(ByVal value As String)
            strSpector_CUS_PROG_CD = value
        End Set
    End Property
    Public Property CREATE_TS As String
        Get
            CREATE_TS = strSpector_CREATE_TS
        End Get
        Set(ByVal value As String)
            strSpector_CREATE_TS = value
        End Set
    End Property


    Public Property CURRENT_REV_NO As Int32
        Get
            CURRENT_REV_NO = intCurrent_Rev_No
        End Get
        Set(ByVal value As Int32)
            intCurrent_Rev_No = value
        End Set
    End Property
    Public Property CREATE_BY As String
        Get
            CREATE_BY = strCreate_By
        End Get
        Set(ByVal value As String)
            strCreate_By = value
        End Set
    End Property
    Public Property CMP_NAME As String
        Get
            CMP_NAME = strCmp_Name
        End Get
        Set(ByVal value As String)
            strCmp_Name = value
        End Set
    End Property
    Public Property CMP_FADD1 As String
        Get
            CMP_FADD1 = strAddr1
        End Get
        Set(ByVal value As String)
            strAddr1 = value
        End Set
    End Property
    Public Property CMP_FADD2 As String
        Get
            CMP_FADD2 = strAddr2
        End Get
        Set(ByVal value As String)
            strAddr2 = value
        End Set
    End Property
    Public Property CMP_FADD3 As String
        Get
            CMP_FADD3 = strAddr3
        End Get
        Set(ByVal value As String)
            strAddr3 = value
        End Set
    End Property
    Public Property CITY_CODE As String
        Get
            CITY_CODE = strCity_Code
        End Get
        Set(ByVal value As String)
            strCity_Code = value
        End Set
    End Property

    Public Property SPECTOR_CONTATCT As String
        Get
            SPECTOR_CONTATCT = strSpector_Contact
        End Get
        Set(ByVal value As String)
            strSpector_Contact = value
        End Set
    End Property
    Public Property SPECTOR_EMAIL As String
        Get
            SPECTOR_EMAIL = strSpector_Email
        End Get
        Set(ByVal value As String)
            strSpector_Email = value
        End Set
    End Property
    Public Property COUNTRY As String
        Get
            COUNTRY = strCountry
        End Get
        Set(ByVal value As String)
            strCountry = value
        End Set
    End Property
#End Region

End Class
