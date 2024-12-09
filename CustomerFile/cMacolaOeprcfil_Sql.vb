Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMacolaOeprcfil_Sql


#Region "private variables #################################################"


    Private m_bCd_Tp As Byte
    Private m_strCurr_Cd As String
    Private m_strCd_Tp_1_Cust_No As String
    Private m_strCd_Tp_3_Cust_Type As String
    Private m_strCd_Tp_1_Item_No As String
    Private m_strCd_Tp_2_Prod_Cat As String
    Private m_dtStart_Dt As DateTime
    Private m_dtEnd_Dt As DateTime
    Private m_strCd_Prc_Basis As String
    Private m_decMinimum_Qty_1 As Decimal
    Private m_decPrc_Or_Disc_1 As Decimal
    Private m_decMinimum_Qty_2 As Decimal
    Private m_decPrc_Or_Disc_2 As Decimal
    Private m_decMinimum_Qty_3 As Decimal
    Private m_decPrc_Or_Disc_3 As Decimal
    Private m_decMinimum_Qty_4 As Decimal
    Private m_decPrc_Or_Disc_4 As Decimal
    Private m_decMinimum_Qty_5 As Decimal
    Private m_decPrc_Or_Disc_5 As Decimal
    Private m_decMinimum_Qty_6 As Decimal
    Private m_decPrc_Or_Disc_6 As Decimal
    Private m_decMinimum_Qty_7 As Decimal
    Private m_decPrc_Or_Disc_7 As Decimal
    Private m_decMinimum_Qty_8 As Decimal
    Private m_decPrc_Or_Disc_8 As Decimal
    Private m_decMinimum_Qty_9 As Decimal
    Private m_decPrc_Or_Disc_9 As Decimal
    Private m_decMinimum_Qty_10 As Decimal
    Private m_decPrc_Or_Disc_10 As Decimal
    Private m_strExtra_1 As String
    Private m_strExtra_2 As String
    Private m_strExtra_3 As String
    Private m_strExtra_4 As String
    Private m_strExtra_5 As String
    Private m_strExtra_6 As String
    Private m_strExtra_7 As String
    Private m_strExtra_8 As String
    Private m_strExtra_9 As String
    Private m_decExtra_10 As Decimal
    Private m_decExtra_11 As Decimal
    Private m_decExtra_12 As Decimal
    Private m_decExtra_13 As Decimal
    Private m_intExtra_14 As Int32
    Private m_intExtra_15 As Int32
    Private m_strFiller_0004 As String
    Private m_decId As Decimal


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pId As Integer)

        Try

            Call Init()
            Call Load(pId)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pstrItem_No As String, ByVal pstrCurr_Cd As String)

        Try

            Call Init()
            Call Load(pstrItem_No, pstrCurr_Cd)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pstrItem_No As String, ByVal pstrCus_No As String, ByVal pstrCurr_Cd As String)

        Try

            Call Init()
            Call Load(pstrItem_No, pstrCus_No, pstrCurr_Cd)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    'Public Sub New(ByVal pstrItem_No As String, ByVal pCus_Prog_ID As Integer, ByVal pCus_Prog_Item_List_ID As Integer)
    Public Sub New(ByVal pstrItem_No As String, ByRef oProgram As cMdb_Cus_Prog)

        Try

            Call Init()
            Call Load(pstrItem_No, oProgram)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"

    Private Sub Init()

        Try

            m_bCd_Tp = 0
            m_strCurr_Cd = String.Empty
            m_strCd_Tp_1_Cust_No = String.Empty
            m_strCd_Tp_3_Cust_Type = String.Empty
            m_strCd_Tp_1_Item_No = String.Empty
            m_strCd_Tp_2_Prod_Cat = String.Empty
            m_dtStart_Dt = NoDate()
            m_dtEnd_Dt = NoDate()
            m_strCd_Prc_Basis = String.Empty
            m_decMinimum_Qty_1 = 0
            m_decPrc_Or_Disc_1 = 0
            m_decMinimum_Qty_2 = 0
            m_decPrc_Or_Disc_2 = 0
            m_decMinimum_Qty_3 = 0
            m_decPrc_Or_Disc_3 = 0
            m_decMinimum_Qty_4 = 0
            m_decPrc_Or_Disc_4 = 0
            m_decMinimum_Qty_5 = 0
            m_decPrc_Or_Disc_5 = 0
            m_decMinimum_Qty_6 = 0
            m_decPrc_Or_Disc_6 = 0
            m_decMinimum_Qty_7 = 0
            m_decPrc_Or_Disc_7 = 0
            m_decMinimum_Qty_8 = 0
            m_decPrc_Or_Disc_8 = 0
            m_decMinimum_Qty_9 = 0
            m_decPrc_Or_Disc_9 = 0
            m_decMinimum_Qty_10 = 0
            m_decPrc_Or_Disc_10 = 0
            m_strExtra_1 = String.Empty
            m_strExtra_2 = String.Empty
            m_strExtra_3 = String.Empty
            m_strExtra_4 = String.Empty
            m_strExtra_5 = String.Empty
            m_strExtra_6 = String.Empty
            m_strExtra_7 = String.Empty
            m_strExtra_8 = String.Empty
            m_strExtra_9 = String.Empty
            m_decExtra_10 = 0
            m_decExtra_11 = 0
            m_decExtra_12 = 0
            m_decExtra_13 = 0
            m_intExtra_14 = 0
            m_intExtra_15 = 0
            m_strFiller_0004 = String.Empty
            m_decId = 0

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cd_Tp").Equals(DBNull.Value)) Then m_bCd_Tp = pdrRow.Item("Cd_Tp")
            If Not (pdrRow.Item("Curr_Cd").Equals(DBNull.Value)) Then m_strCurr_Cd = pdrRow.Item("Curr_Cd").ToString
            If Not (pdrRow.Item("Cd_Tp_1_Cust_No").Equals(DBNull.Value)) Then m_strCd_Tp_1_Cust_No = pdrRow.Item("Cd_Tp_1_Cust_No").ToString
            If Not (pdrRow.Item("Cd_Tp_3_Cust_Type").Equals(DBNull.Value)) Then m_strCd_Tp_3_Cust_Type = pdrRow.Item("Cd_Tp_3_Cust_Type").ToString
            If Not (pdrRow.Item("Cd_Tp_1_Item_No").Equals(DBNull.Value)) Then m_strCd_Tp_1_Item_No = pdrRow.Item("Cd_Tp_1_Item_No").ToString
            If Not (pdrRow.Item("Cd_Tp_2_Prod_Cat").Equals(DBNull.Value)) Then m_strCd_Tp_2_Prod_Cat = pdrRow.Item("Cd_Tp_2_Prod_Cat").ToString
            If Not (pdrRow.Item("Start_Dt").Equals(DBNull.Value)) Then m_dtStart_Dt = pdrRow.Item("Start_Dt")
            If Not (pdrRow.Item("End_Dt").Equals(DBNull.Value)) Then m_dtEnd_Dt = pdrRow.Item("End_Dt")
            If Not (pdrRow.Item("Cd_Prc_Basis").Equals(DBNull.Value)) Then m_strCd_Prc_Basis = pdrRow.Item("Cd_Prc_Basis").ToString
            If Not (pdrRow.Item("Minimum_Qty_1").Equals(DBNull.Value)) Then m_decMinimum_Qty_1 = pdrRow.Item("Minimum_Qty_1")
            If Not (pdrRow.Item("Prc_Or_Disc_1").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_1 = pdrRow.Item("Prc_Or_Disc_1")
            If Not (pdrRow.Item("Minimum_Qty_2").Equals(DBNull.Value)) Then m_decMinimum_Qty_2 = pdrRow.Item("Minimum_Qty_2")
            If Not (pdrRow.Item("Prc_Or_Disc_2").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_2 = pdrRow.Item("Prc_Or_Disc_2")
            If Not (pdrRow.Item("Minimum_Qty_3").Equals(DBNull.Value)) Then m_decMinimum_Qty_3 = pdrRow.Item("Minimum_Qty_3")
            If Not (pdrRow.Item("Prc_Or_Disc_3").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_3 = pdrRow.Item("Prc_Or_Disc_3")
            If Not (pdrRow.Item("Minimum_Qty_4").Equals(DBNull.Value)) Then m_decMinimum_Qty_4 = pdrRow.Item("Minimum_Qty_4")
            If Not (pdrRow.Item("Prc_Or_Disc_4").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_4 = pdrRow.Item("Prc_Or_Disc_4")
            If Not (pdrRow.Item("Minimum_Qty_5").Equals(DBNull.Value)) Then m_decMinimum_Qty_5 = pdrRow.Item("Minimum_Qty_5")
            If Not (pdrRow.Item("Prc_Or_Disc_5").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_5 = pdrRow.Item("Prc_Or_Disc_5")
            If Not (pdrRow.Item("Minimum_Qty_6").Equals(DBNull.Value)) Then m_decMinimum_Qty_6 = pdrRow.Item("Minimum_Qty_6")
            If Not (pdrRow.Item("Prc_Or_Disc_6").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_6 = pdrRow.Item("Prc_Or_Disc_6")
            If Not (pdrRow.Item("Minimum_Qty_7").Equals(DBNull.Value)) Then m_decMinimum_Qty_7 = pdrRow.Item("Minimum_Qty_7")
            If Not (pdrRow.Item("Prc_Or_Disc_7").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_7 = pdrRow.Item("Prc_Or_Disc_7")
            If Not (pdrRow.Item("Minimum_Qty_8").Equals(DBNull.Value)) Then m_decMinimum_Qty_8 = pdrRow.Item("Minimum_Qty_8")
            If Not (pdrRow.Item("Prc_Or_Disc_8").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_8 = pdrRow.Item("Prc_Or_Disc_8")
            If Not (pdrRow.Item("Minimum_Qty_9").Equals(DBNull.Value)) Then m_decMinimum_Qty_9 = pdrRow.Item("Minimum_Qty_9")
            If Not (pdrRow.Item("Prc_Or_Disc_9").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_9 = pdrRow.Item("Prc_Or_Disc_9")
            If Not (pdrRow.Item("Minimum_Qty_10").Equals(DBNull.Value)) Then m_decMinimum_Qty_10 = pdrRow.Item("Minimum_Qty_10")
            If Not (pdrRow.Item("Prc_Or_Disc_10").Equals(DBNull.Value)) Then m_decPrc_Or_Disc_10 = pdrRow.Item("Prc_Or_Disc_10")
            If Not (pdrRow.Item("Extra_1").Equals(DBNull.Value)) Then m_strExtra_1 = pdrRow.Item("Extra_1").ToString
            If Not (pdrRow.Item("Extra_2").Equals(DBNull.Value)) Then m_strExtra_2 = pdrRow.Item("Extra_2").ToString
            If Not (pdrRow.Item("Extra_3").Equals(DBNull.Value)) Then m_strExtra_3 = pdrRow.Item("Extra_3").ToString
            If Not (pdrRow.Item("Extra_4").Equals(DBNull.Value)) Then m_strExtra_4 = pdrRow.Item("Extra_4").ToString
            If Not (pdrRow.Item("Extra_5").Equals(DBNull.Value)) Then m_strExtra_5 = pdrRow.Item("Extra_5").ToString
            If Not (pdrRow.Item("Extra_6").Equals(DBNull.Value)) Then m_strExtra_6 = pdrRow.Item("Extra_6").ToString
            If Not (pdrRow.Item("Extra_7").Equals(DBNull.Value)) Then m_strExtra_7 = pdrRow.Item("Extra_7").ToString
            If Not (pdrRow.Item("Extra_8").Equals(DBNull.Value)) Then m_strExtra_8 = pdrRow.Item("Extra_8").ToString
            If Not (pdrRow.Item("Extra_9").Equals(DBNull.Value)) Then m_strExtra_9 = pdrRow.Item("Extra_9").ToString
            If Not (pdrRow.Item("Extra_10").Equals(DBNull.Value)) Then m_decExtra_10 = pdrRow.Item("Extra_10")
            If Not (pdrRow.Item("Extra_11").Equals(DBNull.Value)) Then m_decExtra_11 = pdrRow.Item("Extra_11")
            If Not (pdrRow.Item("Extra_12").Equals(DBNull.Value)) Then m_decExtra_12 = pdrRow.Item("Extra_12")
            If Not (pdrRow.Item("Extra_13").Equals(DBNull.Value)) Then m_decExtra_13 = pdrRow.Item("Extra_13")
            If Not (pdrRow.Item("Extra_14").Equals(DBNull.Value)) Then m_intExtra_14 = pdrRow.Item("Extra_14")
            If Not (pdrRow.Item("Extra_15").Equals(DBNull.Value)) Then m_intExtra_15 = pdrRow.Item("Extra_15")
            If Not (pdrRow.Item("Filler_0004").Equals(DBNull.Value)) Then m_strFiller_0004 = pdrRow.Item("Filler_0004").ToString
            If Not (pdrRow.Item("Id").Equals(DBNull.Value)) Then m_decId = pdrRow.Item("Id")

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Id") = m_decId
            pdrRow.Item("Cd_Tp") = m_bCd_Tp
            pdrRow.Item("Curr_Cd") = m_strCurr_Cd
            pdrRow.Item("Cd_Tp_1_Cust_No") = m_strCd_Tp_1_Cust_No
            pdrRow.Item("Cd_Tp_3_Cust_Type") = m_strCd_Tp_3_Cust_Type
            pdrRow.Item("Cd_Tp_1_Item_No") = m_strCd_Tp_1_Item_No
            pdrRow.Item("Cd_Tp_2_Prod_Cat") = m_strCd_Tp_2_Prod_Cat
            If m_dtStart_Dt.Year <> 1 Then pdrRow.Item("Start_Dt") = m_dtStart_Dt
            If m_dtEnd_Dt.Year <> 1 Then pdrRow.Item("End_Dt") = m_dtEnd_Dt
            pdrRow.Item("Cd_Prc_Basis") = m_strCd_Prc_Basis
            pdrRow.Item("Minimum_Qty_1") = m_decMinimum_Qty_1
            pdrRow.Item("Prc_Or_Disc_1") = m_decPrc_Or_Disc_1
            pdrRow.Item("Minimum_Qty_2") = m_decMinimum_Qty_2
            pdrRow.Item("Prc_Or_Disc_2") = m_decPrc_Or_Disc_2
            pdrRow.Item("Minimum_Qty_3") = m_decMinimum_Qty_3
            pdrRow.Item("Prc_Or_Disc_3") = m_decPrc_Or_Disc_3
            pdrRow.Item("Minimum_Qty_4") = m_decMinimum_Qty_4
            pdrRow.Item("Prc_Or_Disc_4") = m_decPrc_Or_Disc_4
            pdrRow.Item("Minimum_Qty_5") = m_decMinimum_Qty_5
            pdrRow.Item("Prc_Or_Disc_5") = m_decPrc_Or_Disc_5
            pdrRow.Item("Minimum_Qty_6") = m_decMinimum_Qty_6
            pdrRow.Item("Prc_Or_Disc_6") = m_decPrc_Or_Disc_6
            pdrRow.Item("Minimum_Qty_7") = m_decMinimum_Qty_7
            pdrRow.Item("Prc_Or_Disc_7") = m_decPrc_Or_Disc_7
            pdrRow.Item("Minimum_Qty_8") = m_decMinimum_Qty_8
            pdrRow.Item("Prc_Or_Disc_8") = m_decPrc_Or_Disc_8
            pdrRow.Item("Minimum_Qty_9") = m_decMinimum_Qty_9
            pdrRow.Item("Prc_Or_Disc_9") = m_decPrc_Or_Disc_9
            pdrRow.Item("Minimum_Qty_10") = m_decMinimum_Qty_10
            pdrRow.Item("Prc_Or_Disc_10") = m_decPrc_Or_Disc_10
            'pdrRow.Item("Extra_1") = m_strExtra_1
            'pdrRow.Item("Extra_2") = m_strExtra_2
            'pdrRow.Item("Extra_3") = m_strExtra_3
            'pdrRow.Item("Extra_4") = m_strExtra_4
            '++ID removed comment  2015.05.07
            pdrRow.Item("Extra_5") = m_strExtra_5 ' chekbox Always Execute we will use 1 or 0
            'pdrRow.Item("Extra_6") = m_strExtra_6
            'pdrRow.Item("Extra_7") = m_strExtra_7
            '++ID removed comment 2015.04.23
            pdrRow.Item("Extra_8") = m_strExtra_8  ' Create_DT we use in frmManagerGlobalOptions.vb
            pdrRow.Item("Extra_9") = m_strExtra_9  ' Update_DT we use in frmManagerGlobalOptions.vb
            'pdrRow.Item("Extra_10") = m_decExtra_10
            'pdrRow.Item("Extra_11") = m_decExtra_11
            'pdrRow.Item("Extra_12") = m_decExtra_12
            'pdrRow.Item("Extra_13") = m_decExtra_13
            pdrRow.Item("Extra_14") = m_intExtra_14 ' We only save this field, it links the special pricing Cus_Prog_ID
            '++ID removed comment 2015.04.23
            pdrRow.Item("Extra_15") = m_intExtra_15  ' User_ID we use in frmManagerGlobalOptions.vb
            'pdrRow.Item("Filler_0004") = m_strFiller_0004

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"
    'Ion 14.10.14
    Public Sub DeleteAll(Optional ByVal m_cus_no As String = "")
        Dim db As New cDBA
        Dim strSql As String
        Dim dt As DataTable
        Try
            Dim cus_prog_id As Int32 = m_intExtra_14
            strSql =
            " SELECT * " &
            " FROM   Oeprcfil_Sql WITH (Nolock) " &
            " where cd_tp = 9 and ISNULL(Extra_14, 0) <> 0 AND ISNULL(Extra_14, 0) = " & cus_prog_id

            If m_cus_no <> "" Then
                strSql &= " and cd_tp_1_cust_no <> '" & m_cus_no & "'"
            End If



            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                For Each item As DataRow In dt.Rows
                    m_decId = item.Item("Id").ToString()
                    m_intExtra_14 = CInt(item.Item("Extra_14").ToString)
                    m_strCd_Tp_1_Cust_No = item.Item("CD_TP_1_CUST_NO").ToString
                    m_strCd_Tp_1_Item_No = item.Item("CD_TP_1_ITEM_NO").ToString

                    Call Delete()
                Next
                Call Init()
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Ion 
    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            ' We make sure only to remove data linked to a program, special pricing or quote. --WITH (Nolock)
            strSql = _
            "DELETE FROM Oeprcfil_Sql   " & _
            "WHERE  Id = " & m_decId & " AND ISNULL(Extra_14, 0) <> 0 AND ISNULL(Extra_14, 0) = " & m_intExtra_14 & " AND CD_TP_1_CUST_NO = '" & m_strCd_Tp_1_Cust_No.Trim & "' AND CD_TP_1_ITEM_NO = '" & m_strCd_Tp_1_Item_No.Trim & "' "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    '++ID this delete is for frmManagerGlobalOptions.vb
    Public Sub Delete(ByRef ID As Integer)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
           " DELETE FROM Oeprcfil_Sql " & _
            " where ID = " & ID

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    '++ID 23.12.2014
    Public Sub LoadMinQty(ByVal currency As String, ByVal item_cd As String, ByVal item_color As String)
        Try
            Dim strSql As String
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim strColor As String = ""


            strColor = _
                "   SELECT distinct Item_No  FROM MDB_ITEM_DETAIL   WITH (Nolock)" & _
            " WHERE Item_Cd = '" & item_cd & "' AND Color_List = '" & item_color & "' "

            strColor =
                " SELECT DISTINCT ITEM_NO FROM imitmidx_sql WITH (Nolock) " &
                " WHERE user_def_fld_1 = '" & item_cd & "' AND ITEM_NO = '" & item_color & "' "
            '++ID 1.8.2018
            strColor =
                " SELECT DISTINCT ITEM_NO FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
                " WHERE ITEM_CD = '" & item_cd & "' AND (Color_List = '" & item_color & "' or ITEM_NO = '" & item_color & "') "

            dt = db.DataTable(strColor)

            If dt.Rows.Count <> 0 Then
                item_cd = Trim(dt.Rows(0).Item("Item_no").ToString)
            Else
                item_cd = item_cd.PadRight(6, "0")
            End If


            strSql =
                " select MIN(minimum_qty_2) as minQty2 from oeprcfil_sql  WITH (Nolock) " &
                " where cd_tp = '6' and cd_tp_1_item_no = '" & Trim(item_cd) & "' " &
                " and curr_cd = '" & currency & "'"


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                If IsDBNull(dt.Rows(0).Item("minQty2")) Then
                    m_decMinimum_Qty_2 = 0.0
                Else
                    m_decMinimum_Qty_2 = dt.Rows(0).Item("minQty2")
                End If

            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Function displayPrice(ByVal cus_no As String, ByVal curr_cd As String, ByVal item_cd As String, ByVal item_color As String, _
                                 ByVal quantity As Integer, Optional ByVal program_Type As String = "", Optional ByVal eqp_level As Boolean = False) As Decimal

        displayPrice = 0.0
        Dim db As New cDBA
        Dim dt As DataTable
        Dim strSql As String
        Dim strItemNo As String

        'find or retrieve item_no

        If item_color <> "ALL" Then

            'strSql = _
            '    " select Item_No from MDB_ITEM_DETAIL  WITH (Nolock) " & _
            '    " where Item_Cd = '" & item_cd & "' and Color_List = '" & item_color & "'"

            'strSql =
            '  " SELECT ITEM_NO FROM imitmidx_sql WITH (Nolock) " &
            '  " WHERE user_def_fld_1 = '" & item_cd & "' AND user_def_fld_2 = '" & item_color & "' "

            'strSql =
            '  " SELECT ITEM_NO FROM imitmidx_sql WITH (Nolock) " &
            '  " WHERE user_def_fld_1 = '" & item_cd & "' AND user_def_fld_2 = '" & item_color & "' "

            '++ID 1.8.2018 created view because certane info is miising also in imitimidx_sql
            'need revide only by send country cd for seklect  good package
            strSql =
              " SELECT ITEM_NO FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
              " WHERE ITEM_CD = '" & item_cd & "' AND LTrim(RTrim(Color_List)) = '" & Trim(item_color) & "' "


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                strItemNo = Trim(RTrim(dt.Rows(0).Item("Item_No").ToString))
            Else
                strItemNo = ""
            End If

        Else
            'AST ASORTED
            'strSql = _
            '    "select TOP 1  Item_No from MDB_ITEM_DETAIL  WITH (Nolock) " & _
            '    " where Item_Cd = '" & item_cd & "' AND Item_No NOT like '%AST'  "

            'strSql =
            '   " SELECT TOP 1 ITEM_NO FROM imitmidx_sql WITH (Nolock) " &
            '   " WHERE user_def_fld_1 = '" & item_cd & "' AND ITEM_NO NOT like '%AST' "
            '++ID 
            strSql =
               " SELECT TOP 1 ITEM_NO FROM View_MDB_ITEM_DETAIL WITH (Nolock) " &
               " WHERE ITEM_CD = '" & item_cd & "' AND ITEM_NO NOT like '%AST'"



            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                strItemNo = dt.Rows(0).Item("Item_No").ToString
            Else
                strItemNo = ""
            End If

        End If
        'end work for retrieve item_no

        'now with cus_no and item_no we can easier find price if he is EQP ....
        strSql = " select ISNULL(prc_or_disc_6,0.0) AS prc_or_disc_6,Isnull(Minimum_Qty_6,0.0) AS Minimum_Qty_6,Isnull(prc_or_disc_5,0.0) As prc_or_disc_5, " _
            & " Isnull(Minimum_Qty_5,0.0) AS Minimum_qty_5,Isnull(prc_or_disc_4,0.0) As prc_or_disc_4 ,Isnull(Minimum_Qty_4,0.0) AS Minimum_qty_4, " _
             & " Isnull(prc_or_disc_3,0.0) AS prc_or_disc_3,Isnull(Minimum_Qty_3,0.0) AS Minimum_qty_3,isnull(prc_or_disc_2,0.0) AS prc_or_disc_2, " _
             & " Isnull(Minimum_Qty_2,0.0) As Minimum_qty_2,Isnull(prc_or_disc_1,0.0) AS prc_or_disc_1 ,Isnull(Minimum_Qty_1,0.0) AS Minimum_qty_1 " _
             & " from Oeprcfil_Sql  WITH (Nolock) " _
              & " where cd_tp_1_cust_no = '" & cus_no & "' and curr_Cd = '" & curr_cd & "'" _
              & " and end_dt >= GETDATE() and cd_tp_1_item_no = '" & Trim(strItemNo) & "' " _
              & " and cd_tp_3_cust_type = '' and extra_14 is null "

        dt = db.DataTable(strSql)

        If dt.Rows.Count <> 0 Then
            'it must analise if is null pass to another price(prc_or_disc_2(3,4,5,6..))
            displayPrice = dt.Rows(0).Item("prc_or_disc_1")

            '++ID commented below line becasue Special_pricing is already eqo_level, seconf no cell Eqp_level in Special Princing Type this means never will enter in Exception
            '   If program_Type = "Program" Or (program_Type = "Special Pricing" And eqp_level = True) Then
            '++ID Commented 01.19.2021
            ' If (program_Type = "Program" Or program_Type = "Special Pricing") Then
            '++ID  was did in version 277 after that commented EQP customer it have always in first column price the latest from regulat 
            'If program_Type = "Program" Then
            '    'it must create an (if or select) for identifie the price smaller
            '    'If  prc_or_disc_6 is not exist pass prc_or_disc_5 until find the price with value
            '    'also it must think about if EQP is checked this is also an critere

            '    If dt.Rows(0).Item("prc_or_disc_6") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_6")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_5") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_5")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_4") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_4")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_3") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_3")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_2") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_2")
            '    ElseIf dt.Rows(0).Item("prc_or_disc_1") <> 0.0 Then
            '        displayPrice = dt.Rows(0).Item("prc_or_disc_1")
            '    End If

            'Else

            '    If quantity < dt.Rows(0).Item("Minimum_Qty_2") Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_1")

            '    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_2") And quantity < dt.Rows(0).Item("Minimum_Qty_3")) _
            '        Or dt.Rows(0).Item("Minimum_Qty_3") = 0.0 Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_2")

            '    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_3") And quantity < dt.Rows(0).Item("Minimum_Qty_4")) _
            '        Or dt.Rows(0).Item("Minimum_Qty_4") = 0.0 Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_3")

            '    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_4") And quantity < dt.Rows(0).Item("Minimum_Qty_5")) _
            '        Or dt.Rows(0).Item("Minimum_Qty_5") = 0.0 Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_4")

            '    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_5") And quantity < dt.Rows(0).Item("Minimum_Qty_6")) _
            '        Or dt.Rows(0).Item("Minimum_Qty_6") = 0.0 Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_5")

            '    ElseIf quantity >= dt.Rows(0).Item("Minimum_Qty_6") Then

            '        displayPrice = dt.Rows(0).Item("prc_or_disc_6")

            '    End If



            'End If


        Else
            'if is not EQP .... , we seek only with item_no and retrieve prc_or_disc_2 if min quantite is greater as 300 and as smoller 700 
            'justin20210303 correct sql prc_or_disc_6 to prc_or_disc_4
            strSql =
               " select ISNULL(prc_or_disc_6,0.0) AS prc_or_disc_6,Isnull(Minimum_Qty_6,0.0) AS Minimum_Qty_6,Isnull(prc_or_disc_5,0.0) As prc_or_disc_5, " &
               " Isnull(Minimum_Qty_5,0.0) AS Minimum_qty_5,Isnull(prc_or_disc_4,0.0) As prc_or_disc_4 ,Isnull(Minimum_Qty_4,0.0) AS Minimum_qty_4, " &
               " Isnull(prc_or_disc_3,0.0) AS prc_or_disc_3,Isnull(Minimum_Qty_3,0.0) AS Minimum_qty_3,isnull(prc_or_disc_2,0.0) AS prc_or_disc_2, " &
               " Isnull(Minimum_Qty_2,0.0) As Minimum_qty_2,Isnull(prc_or_disc_1,0.0) AS prc_or_disc_1 ,Isnull(Minimum_Qty_1,0.0) AS Minimum_qty_1 " &
               " from Oeprcfil_Sql  WITH (Nolock) " &
               " where cd_tp = 6 And cd_tp_1_cust_no = '' and curr_Cd = '" & curr_cd & "' " &
               " and end_dt >= GETDATE() and  cd_tp_1_item_no = '" & Trim(strItemNo) & "' " &
               " and cd_tp_3_cust_type = '' and extra_14 is null "


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                'it must seeks price by quantity
                '  If program_Type <> "Program"  And eqp_level = False
                '++ID commented 01.19.2021
                ' If (program_Type <> "Program" Or program_Type <> "Special Pricing") And eqp_level = False Then

                If program_Type <> "Program" Then


                    If quantity < dt.Rows(0).Item("Minimum_Qty_2") Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_1")

                    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_2") And quantity < dt.Rows(0).Item("Minimum_Qty_3")) _
                        Or dt.Rows(0).Item("Minimum_Qty_3") = 0.0 Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_2")

                    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_3") And quantity < dt.Rows(0).Item("Minimum_Qty_4")) _
                        Or dt.Rows(0).Item("Minimum_Qty_4") = 0.0 Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_3")

                    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_4") And quantity < dt.Rows(0).Item("Minimum_Qty_5")) _
                        Or dt.Rows(0).Item("Minimum_Qty_5") = 0.0 Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_4")

                    ElseIf (quantity >= dt.Rows(0).Item("Minimum_Qty_5") And quantity < dt.Rows(0).Item("Minimum_Qty_6")) _
                        Or dt.Rows(0).Item("Minimum_Qty_6") = 0.0 Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_5")

                    ElseIf quantity >= dt.Rows(0).Item("Minimum_Qty_6") Then

                        displayPrice = dt.Rows(0).Item("prc_or_disc_6")

                    End If
                    '++ID commented below line becasue Special_pricing is already eqo_level, seconf no cell Eqp_level in Special Princing Type this means never will enter in Exception
                    '   ElseIf program_Type = "Program" Or (program_Type = "Special Pricing" And eqp_level = True) Then
                    '++ID commented 01.19.2021
                    ' ElseIf (program_Type = "Program" Or program_Type = "Special Pricing") Then

                ElseIf program_Type = "Program" Then
                    'it must create an (if or select) for identifie the price smaller
                    'If  prc_or_disc_6 is not exist pass prc_or_disc_5 until find the price with value
                    'also it must think about if EQP is checked this is also an critere

                    If dt.Rows(0).Item("prc_or_disc_6") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_6")
                    ElseIf dt.Rows(0).Item("prc_or_disc_5") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_5")
                    ElseIf dt.Rows(0).Item("prc_or_disc_4") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_4")
                    ElseIf dt.Rows(0).Item("prc_or_disc_3") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_3")
                    ElseIf dt.Rows(0).Item("prc_or_disc_2") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_2")
                    ElseIf dt.Rows(0).Item("prc_or_disc_1") <> 0.0 Then
                        displayPrice = dt.Rows(0).Item("prc_or_disc_1")
                    End If

                Else
                    displayPrice = dt.Rows(0).Item("prc_or_disc_1")
                End If

            End If

        End If

    End Function


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Oeprcfil_Sql WITH (Nolock) " & _
            "WHERE  Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pstrItem_No As String, ByVal pstrCurr_Cd As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Oeprcfil_Sql WITH (Nolock) " & _
            "WHERE  Cd_Tp = 6 AND Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " & _
            "       Curr_Cd = '" & pstrCurr_Cd & "' AND " & _
            "       (Start_Dt IS NULL OR Start_Dt <= GETDATE()) AND (End_Dt IS NULL OR End_Dt >= GETDATE()) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pstrItem_No As String, ByVal pstrCus_No As String, ByVal pstrCurr_Cd As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Oeprcfil_Sql WITH (Nolock) " & _
            "WHERE  Cd_Tp = 6 AND " & _
            "       Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " & _
            "       Cd_Tp_1_Cust_No = '" & pstrCus_No & "' AND " & _
            "       Curr_Cd = '" & pstrItem_No & "' " & _
            "       (Start_Dt IS NULL OR Start_Dt <= GETDATE()) AND (End_Dt IS NULL OR End_Dt >= GETDATE()) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    'Private Sub Load(ByVal pstrItem_No As String, ByVal pCus_Prog_ID As Integer, ByVal pCus_Prog_Item_List_ID As Integer)
    'Private Sub Load(ByVal pstrItem_No As String, ByVal pCus_Prog_ID As Integer)
    Private Sub Load(ByVal pstrItem_No As String, ByVal opProgram As cMdb_Cus_Prog)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Oeprcfil_Sql WITH (Nolock) " &
            "WHERE  Cd_Tp = " & IIf(opProgram.Prog_Type = 2, "1", "9") & " AND " &
            "       Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " &
            "       Extra_14 = " & opProgram.Cus_Prog_Id & " "



            'strSql = _
            '"SELECT * " & _
            '"FROM   Oeprcfil_Sql WITH (Nolock) " & _
            '"WHERE  Cd_Tp = 1 AND " & _
            '"       Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " & _
            '"       Extra_14 = " & pCus_Prog_ID & " "
            '"WHERE  Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND Extra_14 = " & pCus_Prog_ID & " AND Extra_15 = " & pCus_Prog_Item_List_ID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub LoadByExtar_14(ByVal opProgram As cMdb_Cus_Prog)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Oeprcfil_Sql WITH (Nolock) " &
            "WHERE  Extra_14 = " & opProgram.Cus_Prog_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    '++ID 04.30.2024  added 
    Public Sub Loadpricing(ByVal pstrItem_No As String, ByVal opProgram As cMdb_Cus_Prog, ByVal m_cus_no As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Oeprcfil_Sql WITH (Nolock) " &
            "WHERE  Cd_Tp = " & IIf(opProgram.Prog_Type = 2, "1", "9") & " AND " &
            "       Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " &
            "       Extra_14 = " & opProgram.Cus_Prog_Id & " "

            If m_cus_no <> "" Then
                strSql &= "  and cd_tp_1_cust_no = '" & m_cus_no & "'"
            End If

            'strSql = _
            '"SELECT * " & _
            '"FROM   Oeprcfil_Sql WITH (Nolock) " & _
            '"WHERE  Cd_Tp = 1 AND " & _
            '"       Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND " & _
            '"       Extra_14 = " & pCus_Prog_ID & " "
            '"WHERE  Cd_Tp_1_Item_No = '" & pstrItem_No & "' AND Extra_14 = " & pCus_Prog_ID & " AND Extra_15 = " & pCus_Prog_Item_List_ID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Oeprcfil_Sql " & _
            "WHERE  Id = " & m_decId & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region



#Region "Public procedures ################################################"

    Public Sub Set_Prc_Or_Disc(ByVal piIndex As Integer, ByVal pdecPrice As Decimal)

        Try
            Select Case piIndex
                Case 1
                    m_decPrc_Or_Disc_1 = pdecPrice
                Case 2
                    m_decPrc_Or_Disc_2 = pdecPrice
                Case 3
                    m_decPrc_Or_Disc_3 = pdecPrice
                Case 4
                    m_decPrc_Or_Disc_4 = pdecPrice
                Case 5
                    m_decPrc_Or_Disc_5 = pdecPrice
                Case 6
                    m_decPrc_Or_Disc_6 = pdecPrice
                Case 7
                    m_decPrc_Or_Disc_7 = pdecPrice
                Case 8
                    m_decPrc_Or_Disc_8 = pdecPrice
                Case 9
                    m_decPrc_Or_Disc_9 = pdecPrice
                Case 10
                    m_decPrc_Or_Disc_10 = pdecPrice

            End Select

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub Set_Minimum_Qty(ByVal piIndex As Integer, ByVal pdecQty As Decimal)

        Try
            Select Case piIndex

                Case 1
                    m_decMinimum_Qty_1 = pdecQty
                Case 2
                    m_decMinimum_Qty_2 = pdecQty
                Case 3
                    m_decMinimum_Qty_3 = pdecQty
                Case 4
                    m_decMinimum_Qty_4 = pdecQty
                Case 5
                    m_decMinimum_Qty_5 = pdecQty
                Case 6
                    m_decMinimum_Qty_6 = pdecQty
                Case 7
                    m_decMinimum_Qty_7 = pdecQty
                Case 8
                    m_decMinimum_Qty_8 = pdecQty
                Case 9
                    m_decMinimum_Qty_9 = pdecQty
                Case 10
                    m_decMinimum_Qty_10 = pdecQty

            End Select

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Get_Eqp_Price() As Decimal

        Get_Eqp_Price = 0

        Try
            Dim oPrice As New cMacolaOeprcfil_Sql(Item_No, Curr_Cd)
            Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_10
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_9
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_8
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_7
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_6
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_5
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_4
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_3
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_2
            If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_1

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    'Public Function Get_Eqp_Price() As Decimal

    '    Get_Eqp_Price = 0

    '    Try
    '        Dim oPrice As New cMacolaOeprcfil_Sql(Item_No, Curr_Cd)
    '        Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_5
    '        If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_4
    '        If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_3
    '        If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_2
    '        If Get_Eqp_Price = 0 Then Get_Eqp_Price = oPrice.m_decPrc_Or_Disc_1

    '    Catch ex As Exception
    '        MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

#End Region


#Region "Public properties ################################################"

    Public Property Cd_Tp() As Byte
        Get
            Cd_Tp = m_bCd_Tp
        End Get
        Set(ByVal value As Byte)
            m_bCd_Tp = value
        End Set
    End Property

    Public Property Curr_Cd() As String
        Get
            Curr_Cd = m_strCurr_Cd
        End Get
        Set(ByVal value As String)
            m_strCurr_Cd = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCd_Tp_1_Cust_No
        End Get
        Set(ByVal value As String)
            m_strCd_Tp_1_Cust_No = value
        End Set
    End Property

    Public Property Cd_Tp_3_Cust_Type() As String
        Get
            Cd_Tp_3_Cust_Type = m_strCd_Tp_3_Cust_Type
        End Get
        Set(ByVal value As String)
            m_strCd_Tp_3_Cust_Type = value
        End Set
    End Property

    Public Property Item_No() As String
        Get
            Item_No = m_strCd_Tp_1_Item_No
        End Get
        Set(ByVal value As String)
            m_strCd_Tp_1_Item_No = value
        End Set
    End Property

    Public Property Prod_Cat() As String
        Get
            Prod_Cat = m_strCd_Tp_2_Prod_Cat
        End Get
        Set(ByVal value As String)
            m_strCd_Tp_2_Prod_Cat = value
        End Set
    End Property

    Public Property Start_Dt() As DateTime
        Get
            Start_Dt = m_dtStart_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtStart_Dt = value
        End Set
    End Property

    Public Property End_Dt() As DateTime
        Get
            End_Dt = m_dtEnd_Dt
        End Get
        Set(ByVal value As DateTime)
            m_dtEnd_Dt = value
        End Set
    End Property

    Public Property Cd_Prc_Basis() As String
        Get
            Cd_Prc_Basis = m_strCd_Prc_Basis
        End Get
        Set(ByVal value As String)
            m_strCd_Prc_Basis = value
        End Set
    End Property

    Public Property Minimum_Qty_1() As Decimal
        Get
            Minimum_Qty_1 = m_decMinimum_Qty_1
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_1 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_1() As Decimal
        Get
            Prc_Or_Disc_1 = m_decPrc_Or_Disc_1
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_1 = value
        End Set
    End Property

    Public Property Minimum_Qty_2() As Decimal
        Get
            Minimum_Qty_2 = m_decMinimum_Qty_2
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_2 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_2() As Decimal
        Get
            Prc_Or_Disc_2 = m_decPrc_Or_Disc_2
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_2 = value
        End Set
    End Property

    Public Property Minimum_Qty_3() As Decimal
        Get
            Minimum_Qty_3 = m_decMinimum_Qty_3
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_3 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_3() As Decimal
        Get
            Prc_Or_Disc_3 = m_decPrc_Or_Disc_3
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_3 = value
        End Set
    End Property

    Public Property Minimum_Qty_4() As Decimal
        Get
            Minimum_Qty_4 = m_decMinimum_Qty_4
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_4 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_4() As Decimal
        Get
            Prc_Or_Disc_4 = m_decPrc_Or_Disc_4
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_4 = value
        End Set
    End Property

    Public Property Minimum_Qty_5() As Decimal
        Get
            Minimum_Qty_5 = m_decMinimum_Qty_5
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_5 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_5() As Decimal
        Get
            Prc_Or_Disc_5 = m_decPrc_Or_Disc_5
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_5 = value
        End Set
    End Property

    Public Property Minimum_Qty_6() As Decimal
        Get
            Minimum_Qty_6 = m_decMinimum_Qty_6
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_6 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_6() As Decimal
        Get
            Prc_Or_Disc_6 = m_decPrc_Or_Disc_6
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_6 = value
        End Set
    End Property

    Public Property Minimum_Qty_7() As Decimal
        Get
            Minimum_Qty_7 = m_decMinimum_Qty_7
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_7 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_7() As Decimal
        Get
            Prc_Or_Disc_7 = m_decPrc_Or_Disc_7
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_7 = value
        End Set
    End Property

    Public Property Minimum_Qty_8() As Decimal
        Get
            Minimum_Qty_8 = m_decMinimum_Qty_8
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_8 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_8() As Decimal
        Get
            Prc_Or_Disc_8 = m_decPrc_Or_Disc_8
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_8 = value
        End Set
    End Property

    Public Property Minimum_Qty_9() As Decimal
        Get
            Minimum_Qty_9 = m_decMinimum_Qty_9
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_9 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_9() As Decimal
        Get
            Prc_Or_Disc_9 = m_decPrc_Or_Disc_9
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_9 = value
        End Set
    End Property

    Public Property Minimum_Qty_10() As Decimal
        Get
            Minimum_Qty_10 = m_decMinimum_Qty_10
        End Get
        Set(ByVal value As Decimal)
            m_decMinimum_Qty_10 = value
        End Set
    End Property

    Public Property Prc_Or_Disc_10() As Decimal
        Get
            Prc_Or_Disc_10 = m_decPrc_Or_Disc_10
        End Get
        Set(ByVal value As Decimal)
            m_decPrc_Or_Disc_10 = value
        End Set
    End Property

    Public Property Extra_1() As String
        Get
            Extra_1 = m_strExtra_1
        End Get
        Set(ByVal value As String)
            m_strExtra_1 = value
        End Set
    End Property

    Public Property Extra_2() As String
        Get
            Extra_2 = m_strExtra_2
        End Get
        Set(ByVal value As String)
            m_strExtra_2 = value
        End Set
    End Property

    Public Property Extra_3() As String
        Get
            Extra_3 = m_strExtra_3
        End Get
        Set(ByVal value As String)
            m_strExtra_3 = value
        End Set
    End Property

    Public Property Extra_4() As String
        Get
            Extra_4 = m_strExtra_4
        End Get
        Set(ByVal value As String)
            m_strExtra_4 = value
        End Set
    End Property

    Public Property Extra_5() As String
        Get
            Extra_5 = m_strExtra_5
        End Get
        Set(ByVal value As String)
            m_strExtra_5 = value
        End Set
    End Property

    Public Property Extra_6() As String
        Get
            Extra_6 = m_strExtra_6
        End Get
        Set(ByVal value As String)
            m_strExtra_6 = value
        End Set
    End Property

    Public Property Extra_7() As String
        Get
            Extra_7 = m_strExtra_7
        End Get
        Set(ByVal value As String)
            m_strExtra_7 = value
        End Set
    End Property

    Public Property Extra_8() As String
        Get
            Extra_8 = m_strExtra_8
        End Get
        Set(ByVal value As String)
            m_strExtra_8 = value
        End Set
    End Property

    '++ID pu in comment and added other
    'Public Property Spector_Cd() As String
    '    Get
    '        Spector_Cd = m_strExtra_9
    '    End Get
    '    Set(ByVal value As String)
    '        m_strExtra_9 = value
    '    End Set
    'End Property

    Public Property Extra_9() As String
        Get
            Extra_9 = m_strExtra_9
        End Get
        Set(ByVal value As String)
            m_strExtra_9 = value
        End Set
    End Property
    Public Property Extra_10() As Decimal
        Get
            Extra_10 = m_decExtra_10
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_10 = value
        End Set
    End Property

    Public Property Extra_11() As Decimal
        Get
            Extra_11 = m_decExtra_11
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_11 = value
        End Set
    End Property

    Public Property Extra_12() As Decimal
        Get
            Extra_12 = m_decExtra_12
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_12 = value
        End Set
    End Property

    Public Property Extra_13() As Decimal
        Get
            Extra_13 = m_decExtra_13
        End Get
        Set(ByVal value As Decimal)
            m_decExtra_13 = value
        End Set
    End Property

    Public Property Cus_Prog_Id() As Integer
        Get
            Cus_Prog_Id = m_intExtra_14
        End Get
        Set(ByVal value As Int32)
            m_intExtra_14 = value
        End Set
    End Property
    '++ID added because is missing
    Public Property Extra_15 As Integer
        Get
            Extra_15 = m_intExtra_15
        End Get
        Set(ByVal value As Integer)
            m_intExtra_15 = value
        End Set
    End Property

    Public Property Cus_Prog_Item_List_ID() As Integer
        Get
            Cus_Prog_Item_List_ID = m_intExtra_15
        End Get
        Set(ByVal value As Int32)
            m_intExtra_15 = value
        End Set
    End Property

    Public Property Filler_0004() As String
        Get
            Filler_0004 = m_strFiller_0004
        End Get
        Set(ByVal value As String)
            m_strFiller_0004 = value
        End Set
    End Property

    Public Property Id() As Decimal
        Get
            Id = m_decId
        End Get
        Set(ByVal value As Decimal)
            m_decId = value
        End Set
    End Property

#End Region

End Class ' cMacolaOeprcfil_Sql


