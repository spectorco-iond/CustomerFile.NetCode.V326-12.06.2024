Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cfg_Charge_Usage


#Region "private variables #################################################"


    Private m_intCharge_Usage_Id As Int32 = 0
    Private m_intCharge_Id As Int32
    Private m_strCharge_Cd As String
    Private m_intDec_Met_ID As Int32
    Private m_strCus_No As String
    Private m_strApply_To_Ship_To As String
    Private m_strApply_To_Program As String
    Private m_intCus_Prog_ID As Integer
    Private m_intCus_Prog_Item_List_ID As Integer
    Private m_blnAlways_Use As Boolean
    Private m_blnNever_Use As Boolean
    Private m_intWhen_Qty_Gt As Int32
    Private m_intWhen_Amt_Gt As Int32
    Private m_intWhen_Qty_Lt As Int32
    Private m_intWhen_Amt_Lt As Int32
    'Private m_blnAlways_Surclass_Never As Boolean
    Private m_blnSend_Email As Boolean
    Private m_strEmail_To As String
    Private m_dblUnit_Price As Double
    Private m_blnNo_Charge As Boolean
    Private m_dtCharge_From As DateTime
    Private m_dtCharge_To As DateTime
    Private m_blnWhen_Req As Boolean
    Private m_blnBlind As Boolean
    Private m_strComments As String
    Private m_strAutorized_By As String
    Private m_strUser_Login As String
    Private m_dtUpdate_TS As DateTime

    Private m_Program As cMdb_Cus_Prog = Nothing
    'Private m_Item As cMdb_Cus_Prog_Item_List = Nothing

#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCharge_Usage_Id As Int32)

        Try

            Call Init()
            m_intCharge_Usage_Id = pCharge_Usage_Id
            Call Load(pCharge_Usage_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Prog_ID As Int32, ByVal pCus_Prog_Item_List_ID As Int32)

        Try

            Call Init()

            m_intCus_Prog_ID = pCus_Prog_ID
            m_intCus_Prog_Item_List_ID = pCus_Prog_Item_List_ID

            Call Load(pCus_Prog_ID, pCus_Prog_Item_List_ID)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pCus_Prog As cMdb_Cus_Prog, ByVal pCus_Prog_Item_List_ID As Int32) ' ByVal pItem As cMdb_Cus_Prog_Item_List)

        Try

            Call Init()

            m_Program = pCus_Prog
            'm_Item = pItem

            m_intCus_Prog_ID = m_Program.Cus_Prog_Id
            m_intCus_Prog_Item_List_ID = pCus_Prog_Item_List_ID

            Call Load(m_intCus_Prog_ID, m_intCus_Prog_Item_List_ID)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByRef pCus_Prog As cMdb_Cus_Prog, ByRef pCustomer As cCustomer) ' ByVal pItem As cMdb_Cus_Prog_Item_List)

        Try

            Call Init()

            m_Program = pCus_Prog
            'm_Item = pItem

            m_intCus_Prog_ID = m_Program.Cus_Prog_Id
            m_strCus_No = pCustomer.cmp_code

            Call Load(m_intCus_Prog_ID, m_strCus_No)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCharge_Usage_Id = 0
            m_intCharge_Id = 0
            m_strCharge_Cd = String.Empty
            m_intDec_Met_ID = 0
            m_strCus_No = String.Empty
            m_strApply_To_Ship_To = String.Empty
            m_strApply_To_Program = String.Empty
            m_intCus_Prog_ID = 0
            m_intCus_Prog_Item_List_ID = 0
            m_blnAlways_Use = False
            m_blnNever_Use = False
            m_intWhen_Qty_Gt = 0
            m_intWhen_Amt_Gt = 0
            m_intWhen_Qty_Lt = 0
            m_intWhen_Amt_Lt = 0
            'm_blnAlways_Surclass_Never = False
            m_blnSend_Email = False
            m_strEmail_To = String.Empty
            m_dblUnit_Price = 0
            m_blnNo_Charge = False
            m_dtCharge_From = NoDate() ' Date.Now
            m_dtCharge_To = NoDate() ' Date.Now.AddYears(1).AddDays(-1)
            m_blnWhen_Req = False
            m_blnBlind = False
            m_strComments = String.Empty
            m_strAutorized_By = String.Empty
            m_strUser_Login = String.Empty
            m_dtUpdate_TS = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Charge_Usage_Id").Equals(DBNull.Value)) Then m_intCharge_Usage_Id = pdrRow.Item("Charge_Usage_Id")
            If Not (pdrRow.Item("Charge_Id").Equals(DBNull.Value)) Then m_intCharge_Id = pdrRow.Item("Charge_Id")
            If Not (pdrRow.Item("Charge_Cd").Equals(DBNull.Value)) Then m_strCharge_Cd = pdrRow.Item("Charge_Cd").ToString
            If Not (pdrRow.Item("Dec_Met_Id").Equals(DBNull.Value)) Then m_intDec_Met_ID = pdrRow.Item("Dec_Met_Id")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Apply_To_Ship_To").Equals(DBNull.Value)) Then m_strApply_To_Ship_To = pdrRow.Item("Apply_To_Ship_To").ToString
            If Not (pdrRow.Item("Apply_To_Program").Equals(DBNull.Value)) Then m_strApply_To_Program = pdrRow.Item("Apply_To_Program").ToString
            If Not (pdrRow.Item("Cus_Prog_ID").Equals(DBNull.Value)) Then m_intCus_Prog_ID = pdrRow.Item("Cus_Prog_ID")
            If Not (pdrRow.Item("Cus_Prog_Item_List_ID").Equals(DBNull.Value)) Then m_intCus_Prog_Item_List_ID = pdrRow.Item("Cus_Prog_Item_List_ID")
            If Not (pdrRow.Item("Always_Use").Equals(DBNull.Value)) Then m_blnAlways_Use = pdrRow.Item("Always_Use")
            If Not (pdrRow.Item("Never_Use").Equals(DBNull.Value)) Then m_blnNever_Use = pdrRow.Item("Never_Use")
            If Not (pdrRow.Item("When_Qty_Gt").Equals(DBNull.Value)) Then m_intWhen_Qty_Gt = pdrRow.Item("When_Qty_Gt")
            If Not (pdrRow.Item("When_Amt_Gt").Equals(DBNull.Value)) Then m_intWhen_Amt_Gt = pdrRow.Item("When_Amt_Gt")
            If Not (pdrRow.Item("When_Qty_Lt").Equals(DBNull.Value)) Then m_intWhen_Qty_Lt = pdrRow.Item("When_Qty_Lt")
            If Not (pdrRow.Item("When_Amt_Lt").Equals(DBNull.Value)) Then m_intWhen_Amt_Lt = pdrRow.Item("When_Amt_Lt")
            'If Not (pdrRow.Item("Always_Surclass_Never").Equals(DBNull.Value)) Then m_blnAlways_Surclass_Never = pdrRow.Item("Always_Surclass_Never")
            If Not (pdrRow.Item("Send_Email").Equals(DBNull.Value)) Then m_blnSend_Email = pdrRow.Item("Send_Email")
            If Not (pdrRow.Item("Email_To").Equals(DBNull.Value)) Then m_strEmail_To = pdrRow.Item("Email_To").ToString
            If Not (pdrRow.Item("Unit_Price").Equals(DBNull.Value)) Then m_dblUnit_Price = pdrRow.Item("Unit_Price")
            If Not (pdrRow.Item("No_Charge").Equals(DBNull.Value)) Then m_blnNo_Charge = pdrRow.Item("No_Charge")
            If Not (pdrRow.Item("Charge_From").Equals(DBNull.Value)) Then m_dtCharge_From = pdrRow.Item("Charge_From")
            If Not (pdrRow.Item("Charge_To").Equals(DBNull.Value)) Then m_dtCharge_To = pdrRow.Item("Charge_To")
            If Not (pdrRow.Item("When_Req").Equals(DBNull.Value)) Then m_blnWhen_Req = pdrRow.Item("When_Req")
            If Not (pdrRow.Item("Blind").Equals(DBNull.Value)) Then m_blnBlind = pdrRow.Item("Blind")
            If Not (pdrRow.Item("Comments").Equals(DBNull.Value)) Then m_strComments = pdrRow.Item("Comments").ToString
            If Not (pdrRow.Item("Autorized_By").Equals(DBNull.Value)) Then m_strAutorized_By = pdrRow.Item("Autorized_By").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_TS").Equals(DBNull.Value)) Then m_dtUpdate_TS = pdrRow.Item("Update_TS")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Charge_Usage_Id") = m_intCharge_Usage_Id
            pdrRow.Item("Charge_Id") = m_intCharge_Id
            pdrRow.Item("Charge_Cd") = m_strCharge_Cd
            pdrRow.Item("Dec_Met_Id") = m_intDec_Met_ID
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Apply_To_Ship_To") = m_strApply_To_Ship_To
            pdrRow.Item("Apply_To_Program") = m_strApply_To_Program
            pdrRow.Item("Cus_Prog_ID") = m_intCus_Prog_ID
            pdrRow.Item("Cus_Prog_Item_List_ID") = m_intCus_Prog_Item_List_ID
            pdrRow.Item("Always_Use") = m_blnAlways_Use
            pdrRow.Item("Never_Use") = m_blnNever_Use
            pdrRow.Item("When_Qty_Gt") = m_intWhen_Qty_Gt
            pdrRow.Item("When_Amt_Gt") = m_intWhen_Amt_Gt
            pdrRow.Item("When_Qty_Lt") = m_intWhen_Qty_Lt
            pdrRow.Item("When_Amt_Lt") = m_intWhen_Amt_Lt
            'pdrRow.Item("Always_Surclass_Never") = m_blnAlways_Surclass_Never
            pdrRow.Item("Send_Email") = m_blnSend_Email
            pdrRow.Item("Email_To") = m_strEmail_To
            pdrRow.Item("Unit_Price") = m_dblUnit_Price
            pdrRow.Item("No_Charge") = m_blnNo_Charge
            If m_dtCharge_From.Year <> 1 Then pdrRow.Item("Charge_From") = m_dtCharge_From
            If m_dtCharge_To.Year <> 1 Then pdrRow.Item("Charge_To") = m_dtCharge_To
            pdrRow.Item("When_Req") = m_blnWhen_Req
            pdrRow.Item("Blind") = m_blnBlind
            pdrRow.Item("Comments") = m_strComments
            pdrRow.Item("Autorized_By") = m_strAutorized_By

            m_strUser_Login = Environment.UserName
            m_dtUpdate_TS = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            pdrRow.Item("Update_TS") = m_dtUpdate_TS

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"
    'Ion 
    Public Function Count(ByRef oCus_Prog As cMdb_Cus_Prog) As Int32

        Count = 0
        Dim db As New cDBA
        Dim strSql As String
        Dim dt As DataTable

        strSql = _
            "SELECT CUS_PROG_ID FROM Mdb_Cfg_Charge_Usage " & _
            " WHERE CUS_PROG_ID = " & oCus_Prog.Cus_Prog_Id

        dt = db.DataTable(strSql)

        Count = dt.Rows.Count

        Return Count

    End Function
    'Ion 14.10.14
    Public Sub DeleteAll()
        Dim db As New cDBA
        Dim strSql As String
        Dim dt As DataTable
        Try
            Dim cus_prog_id As Int32 = m_intCus_Prog_ID
            strSql = _
            " SELECT * " & _
            " FROM   Mdb_Cfg_Charge_Usage WITH (Nolock) " & _
            " where CUS_PROG_ID = " & cus_prog_id & ""

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                For Each item As DataRow In dt.Rows
                    m_intCharge_Usage_Id = item.Item("Charge_Usage_Id").ToString()
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

            strSql = _
            "DELETE FROM Mdb_Cfg_Charge_Usage " & _
            "WHERE  Charge_Usage_Id = " & m_intCharge_Usage_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Charge_Usage WITH (Nolock) " & _
            "WHERE  Charge_Usage_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pCus_Prog_ID As Integer, ByVal pCus_Prog_Item_List_ID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Charge_Usage WITH (Nolock) " & _
            "WHERE  Cus_Prog_ID = " & pCus_Prog_ID & " AND Cus_Prog_Item_List_ID = " & pCus_Prog_Item_List_ID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load(ByVal pCus_Prog_ID As Integer, ByVal pCus_No As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Charge_Usage WITH (Nolock) " & _
            "WHERE  Cus_Prog_ID = " & pCus_Prog_ID & " AND Cus_No = '" & pCus_No & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            ' Must use this here to get item short description
            m_strCharge_Cd = db.DataTable("SELECT Charge_Cd FROM Mdb_Cfg_Charge WITH (Nolock) WHERE Charge_ID = " & m_intCharge_Id & " ").Rows(0).Item("Charge_Cd").ToString

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Charge_Usage " & _
            "WHERE  Charge_Usage_Id = " & m_intCharge_Usage_Id & " "

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

            If m_intCharge_Usage_Id = 0 Then m_intCharge_Usage_Id = db.DataTable("SELECT MAX(Charge_Usage_Id) AS Max_Charge_Usage_Id FROM Mdb_Cfg_Charge_Usage WITH (Nolock)").Rows(0).Item("Max_Charge_Usage_Id")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub SaveChargeToMacola(ByRef poProgram As cMdb_Cus_Prog, ByRef poCustomer As cCustomer)

        Try

            If poProgram.One_Shot And Trim(poProgram.Ord_No) <> String.Empty Then Exit Sub

            Dim dtItems As DataTable
            Dim db As New cDBA

            Dim strSql As String = ""

            If m_intCharge_Id = 27 Then
                'Ion MB++ we added in the query  and CU.Cus_NO = P.CD_TP_1_CUST_NO 21.10.14
                strSql = _
                "SELECT		CU.CUS_NO, CU.CUS_PROG_ID, CU.CHARGE_USAGE_ID, CU.CHARGE_ID, CU.DEC_MET_ID, " & _
                "           I.ITEM_NO, ISNULL(P.ID, 0) AS OEPRCFIL_ID " & _
                "FROM		MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) " & _
                "INNER JOIN	MDB_CFG_DEC_MET C WITH (NOLOCK) ON CU.DEC_MET_ID = C.DEC_MET_ID " & _
                "LEFT JOIN	IMITMIDX_SQL I WITH (NOLOCK) ON C.SETUP_ITEM_NO = I.ITEM_NO AND CU.CHARGE_ID = I.EXTRA_14 " & _
                "LEFT JOIN	OEPRCFIL_SQL P WITH (NOLOCK) ON CU.CUS_PROG_ID = P.EXTRA_14 AND I.ITEM_NO = P.CD_TP_1_ITEM_NO  and CU.Cus_NO = P.CD_TP_1_CUST_NO"
            Else
                strSql = _
                "SELECT		CU.CUS_NO, CU.CUS_PROG_ID, CU.CHARGE_USAGE_ID, CU.CHARGE_ID, CU.DEC_MET_ID, " & _
                "           I.ITEM_NO, ISNULL(P.ID, 0) AS OEPRCFIL_ID " & _
                "FROM		MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) " & _
                "LEFT JOIN	IMITMIDX_SQL I WITH (NOLOCK) ON CU.CHARGE_ID = I.EXTRA_14 " & _
                "LEFT JOIN	OEPRCFIL_SQL P WITH (NOLOCK) ON CU.CUS_PROG_ID = P.EXTRA_14 " & _
                "                                       AND I.ITEM_NO = P.CD_TP_1_ITEM_NO and CU.Cus_NO = P.CD_TP_1_CUST_NO " & _
                "LEFT JOIN  MDB_CFG_DEC_MET DM WITH (Nolock) ON CU.DEC_MET_ID = DM.DEC_MET_ID "
            End If

            If (poProgram.Prog_Type = 2 And Not poProgram.One_Shot) Or poProgram.Prog_Type = 4 Then
                strSql &= " AND P.CD_TP = '1' "
            Else
                strSql &= " AND P.CD_TP = '9' "
            End If

            If m_intCharge_Id = 27 Then
                strSql &= "WHERE CU.CUS_NO = '" & m_strCus_No & "' AND " & _
                "           CU.CUS_PROG_ID = " & poProgram.Cus_Prog_Id & " AND " & _
                "           CU.CHARGE_ID = " & m_intCharge_Id & " AND " & _
                "           CU.DEC_MET_ID = " & m_intDec_Met_ID & " " & _
                "           ORDER BY	CHARGE_USAGE_ID, ITEM_NO "
            Else
                strSql &= "WHERE	CU.CUS_NO = '" & m_strCus_No & "' AND " & _
                "           CU.CUS_PROG_ID = " & poProgram.Cus_Prog_Id & " AND " & _
                "           CU.CHARGE_ID = " & m_intCharge_Id & " " & _
                "ORDER BY	CHARGE_USAGE_ID, ITEM_NO "
            End If

            dtItems = db.DataTable(strSql)
            If dtItems.Rows.Count <> 0 Then

                For Each drItem As DataRow In dtItems.Rows

                    Dim oItemPrice As cMacolaOeprcfil_Sql

                    If drItem.Item("OEPRCFIL_ID") = 0 Then

                        oItemPrice = New cMacolaOeprcfil_Sql()

                    Else

                        oItemPrice = New cMacolaOeprcfil_Sql(drItem.Item("OEPRCFIL_ID"))

                    End If

                    If m_blnNo_Charge Then
                        oItemPrice.Prc_Or_Disc_1 = 0
                    Else
                        oItemPrice.Prc_Or_Disc_1 = m_dblUnit_Price
                    End If

                    If Not m_blnNo_Charge And m_dblUnit_Price = 0 Then
                        If m_intCharge_Usage_Id <> 0 Then
                            If oItemPrice.Id <> 0 Then
                                oItemPrice.Delete()
                            End If
                        End If
                    Else

                        If (poProgram.Prog_Type = 2 And Not poProgram.One_Shot) Or poProgram.Prog_Type = 4 Then
                            oItemPrice.Cd_Tp = 1
                        Else
                            oItemPrice.Cd_Tp = 9
                        End If

                        oItemPrice.Cus_No = m_strCus_No
                        oItemPrice.Curr_Cd = poCustomer.Currency
                        oItemPrice.Item_No = drItem.Item("Item_No").ToString
                        oItemPrice.Start_Dt = poProgram.Revision.Start_Dt
                        oItemPrice.End_Dt = poProgram.Revision.End_Dt
                        oItemPrice.Cus_Prog_Id = poProgram.Cus_Prog_Id
                        oItemPrice.Cd_Prc_Basis = "P"
                        oItemPrice.Prod_Cat = poProgram.Spector_Cd.Substring(0, 3)
                        oItemPrice.Cd_Tp_3_Cust_Type = poProgram.Cus_Prog_Id.ToString.Trim.PadLeft(10, "0").Substring(5, 5)

                        oItemPrice.Save()

                    End If

                Next drItem

            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Important: Charges were not updated succesfully in Macola. Please report this problem to IT.")
        End Try

    End Sub

    Public Sub DeleteChargeFromMacola()

        Try

            Dim dtItems As DataTable
            Dim db As New cDBA

            Dim strSql As String = ""

            If m_intCharge_Id = 27 Then
                strSql = _
                "SELECT		CU.CUS_NO, CU.CUS_PROG_ID, CU.CHARGE_USAGE_ID, CU.CHARGE_ID, CU.DEC_MET_ID, " & _
                "           I.ITEM_NO, ISNULL(P.ID, 0) AS OEPRCFIL_ID " & _
                "FROM		MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) " & _
                "INNER JOIN	MDB_CFG_DEC_MET C WITH (NOLOCK) ON CU.DEC_MET_ID = C.DEC_MET_ID " & _
                "INNER JOIN	IMITMIDX_SQL I WITH (NOLOCK) ON C.SETUP_ITEM_NO = I.ITEM_NO AND CU.CHARGE_ID = I.EXTRA_14 " & _
                "INNER JOIN	OEPRCFIL_SQL P WITH (NOLOCK) ON CU.CUS_PROG_ID = P.EXTRA_14 AND I.ITEM_NO = P.CD_TP_1_ITEM_NO "
            Else
                strSql = _
                "SELECT		CU.CUS_NO, CU.CUS_PROG_ID, CU.CHARGE_USAGE_ID, CU.CHARGE_ID, CU.DEC_MET_ID, " & _
                "           I.ITEM_NO, ISNULL(P.ID, 0) AS OEPRCFIL_ID " & _
                "FROM		MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) " & _
                "INNER JOIN	IMITMIDX_SQL I WITH (NOLOCK) ON CU.CHARGE_ID = I.EXTRA_14 " & _
                "INNER JOIN	OEPRCFIL_SQL P WITH (NOLOCK) ON CU.CUS_PROG_ID = P.EXTRA_14 " & _
                "                                       AND I.ITEM_NO = P.CD_TP_1_ITEM_NO " & _
                "INNER JOIN  MDB_CFG_DEC_MET DM WITH (Nolock) ON CU.DEC_MET_ID = DM.DEC_MET_ID "
            End If

            '"SELECT		CU.CUS_NO, CU.CUS_PROG_ID, CU.CHARGE_USAGE_ID, CU.CHARGE_ID, CU.DEC_MET_ID, " & _
            '"           I.ITEM_NO, ISNULL(P.ID, 0) AS OEPRCFIL_ID " & _
            '"FROM		MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) " & _
            '"INNER JOIN	IMITMIDX_SQL I WITH (NOLOCK) ON CU.CHARGE_ID = I.EXTRA_14 " & _
            '"INNER JOIN	OEPRCFIL_SQL P WITH (NOLOCK) ON CU.CUS_PROG_ID = P.EXTRA_14 " & _
            '"                                       AND I.ITEM_NO = P.CD_TP_1_ITEM_NO " & _
            '"INNER JOIN MDB_CFG_DEC_MET DM WITH (Nolock) ON CU.DEC_MET_ID = DM.DEC_MET_ID "

            If (m_Program.Prog_Type = 2 And Not m_Program.One_Shot) Or m_Program.Prog_Type = 4 Then
                'If m_Program.Prog_Type = 2 Or m_Program.Prog_Type = 4 Then
                strSql &= " AND P.CD_TP = '1' "
            Else
                strSql &= " AND P.CD_TP = '9' "
            End If

            If m_intCharge_Id = 27 Then
                strSql &= "WHERE		CU.CUS_NO = '" & m_strCus_No & "' AND " & _
                "           CU.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " & _
                "           CU.CHARGE_ID = " & m_intCharge_Id & " AND " & _
                "           CU.DEC_MET_ID = " & m_intDec_Met_ID & " " & _
                "ORDER BY	CHARGE_USAGE_ID, ITEM_NO "
            Else
                strSql &= "WHERE		CU.CUS_NO = '" & m_strCus_No & "' AND " & _
                "           CU.CUS_PROG_ID = " & m_Program.Cus_Prog_Id & " AND " & _
                "           CU.CHARGE_ID = " & m_intCharge_Id & " " & _
                "ORDER BY	CHARGE_USAGE_ID, ITEM_NO "
            End If

            dtItems = db.DataTable(strSql)

            If dtItems.Rows.Count <> 0 Then
                For Each drItem As DataRow In dtItems.Rows

                    Dim oItemPrice As New cMacolaOeprcfil_Sql(drItem.Item("OEPRCFIL_ID"))
                    oItemPrice.Delete()

                Next drItem
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Charge_Usage." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Important: Charges were not updated succesfully in Macola. Please report this problem to IT.")
        End Try

    End Sub

#End Region


#Region "Public properties ################################################"

    Public Property Charge_Usage_Id() As Int32
        Get
            Charge_Usage_Id = m_intCharge_Usage_Id
        End Get
        Set(ByVal value As Int32)
            m_intCharge_Usage_Id = value
        End Set
    End Property

    Public Property Charge_Id() As Int32
        Get
            Charge_Id = m_intCharge_Id
        End Get
        Set(ByVal value As Int32)
            m_intCharge_Id = value
        End Set
    End Property

    Public Property Charge_Cd() As String
        Get
            Charge_Cd = m_strCharge_Cd
        End Get
        Set(ByVal value As String)
            m_strCharge_Cd = value
        End Set
    End Property

    Public Property Dec_Met_Id() As Int32
        Get
            Dec_Met_Id = m_intDec_Met_ID
        End Get
        Set(ByVal value As Int32)
            m_intDec_Met_ID = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Public Property Apply_To_Ship_To() As String
        Get
            Apply_To_Ship_To = m_strApply_To_Ship_To
        End Get
        Set(ByVal value As String)
            m_strApply_To_Ship_To = value
        End Set
    End Property

    Public Property Apply_To_Program() As String
        Get
            Apply_To_Program = m_strApply_To_Program
        End Get
        Set(ByVal value As String)
            m_strApply_To_Program = value
        End Set
    End Property

    Public Property Cus_Prog_ID() As Integer
        Get
            Cus_Prog_ID = m_intCus_Prog_ID
        End Get
        Set(ByVal value As Integer)
            m_intCus_Prog_ID = value
        End Set
    End Property

    Public Property Cus_Prog_Item_List_ID() As Integer
        Get
            Cus_Prog_Item_List_ID = m_intCus_Prog_Item_List_ID
        End Get
        Set(ByVal value As Integer)
            m_intCus_Prog_Item_List_ID = value
        End Set
    End Property

    Public Property Always_Use() As Boolean
        Get
            Always_Use = m_blnAlways_Use
        End Get
        Set(ByVal value As Boolean)
            m_blnAlways_Use = value
        End Set
    End Property

    Public Property Never_Use() As Boolean
        Get
            Never_Use = m_blnNever_Use
        End Get
        Set(ByVal value As Boolean)
            m_blnNever_Use = value
        End Set
    End Property

    Public Property When_Qty_Gt() As Int32
        Get
            When_Qty_Gt = m_intWhen_Qty_Gt
        End Get
        Set(ByVal value As Int32)
            m_intWhen_Qty_Gt = value
        End Set
    End Property

    Public Property When_Amt_Gt() As Int32
        Get
            When_Amt_Gt = m_intWhen_Amt_Gt
        End Get
        Set(ByVal value As Int32)
            m_intWhen_Amt_Gt = value
        End Set
    End Property

    Public Property When_Qty_Lt() As Int32
        Get
            When_Qty_Lt = m_intWhen_Qty_Lt
        End Get
        Set(ByVal value As Int32)
            m_intWhen_Qty_Lt = value
        End Set
    End Property

    Public Property When_Amt_Lt() As Int32
        Get
            When_Amt_Lt = m_intWhen_Amt_Lt
        End Get
        Set(ByVal value As Int32)
            m_intWhen_Amt_Lt = value
        End Set
    End Property

    'Public Property Always_Surclass_Never() As Boolean
    '    Get
    '        Always_Surclass_Never = m_blnAlways_Surclass_Never
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_blnAlways_Surclass_Never = value
    '    End Set
    'End Property

    Public Property Send_Email() As Boolean
        Get
            Send_Email = m_blnSend_Email
        End Get
        Set(ByVal value As Boolean)
            m_blnSend_Email = value
        End Set
    End Property

    Public Property Email_To() As String
        Get
            Email_To = m_strEmail_To
        End Get
        Set(ByVal value As String)
            m_strEmail_To = value
        End Set
    End Property

    Public Property Unit_Price() As Double
        Get
            Unit_Price = m_dblUnit_Price
        End Get
        Set(ByVal value As Double)
            m_dblUnit_Price = value
        End Set
    End Property

    Public Property No_Charge() As Boolean
        Get
            No_Charge = m_blnNo_Charge
        End Get
        Set(ByVal value As Boolean)
            m_blnNo_Charge = value
        End Set
    End Property

    Public Property Charge_From() As DateTime
        Get
            Charge_From = m_dtCharge_From
        End Get
        Set(ByVal value As DateTime)
            m_dtCharge_From = value
        End Set
    End Property

    Public Property Charge_To() As DateTime
        Get
            Charge_To = m_dtCharge_To
        End Get
        Set(ByVal value As DateTime)
            m_dtCharge_To = value
        End Set
    End Property

    Public Property When_Req() As Boolean
        Get
            When_Req = m_blnWhen_Req
        End Get
        Set(ByVal value As Boolean)
            m_blnWhen_Req = value
        End Set
    End Property

    Public Property Blind() As Boolean
        Get
            Blind = m_blnBlind
        End Get
        Set(ByVal value As Boolean)
            m_blnBlind = value
        End Set
    End Property

    Public Property Comments() As String
        Get
            Comments = m_strComments
        End Get
        Set(ByVal value As String)
            m_strComments = value
        End Set
    End Property

    Public Property Autorized_By() As String
        Get
            Autorized_By = m_strAutorized_By
        End Get
        Set(ByVal value As String)
            m_strAutorized_By = value
        End Set
    End Property

    Public Property User_Login() As String
        Get
            User_Login = m_strUser_Login
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
        End Set
    End Property

    Public Property Update_TS() As DateTime
        Get
            Update_TS = m_dtUpdate_TS
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_TS = value
        End Set
    End Property

#End Region


End Class ' cMdb_Cfg_Charge_Usage


