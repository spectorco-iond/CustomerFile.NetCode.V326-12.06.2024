Imports System.Data.Odbc

Public Class cMdb_Cus_Prog_DAL

    Dim db As New cDBA

    Public Function Load(ByVal pintID As Integer) As cMdb_Cus_Prog

        Load = New cMdb_Cus_Prog()

        Try

            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog WITH (Nolock) " & _
            "WHERE  Cus_Prog_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Load(ByVal pstrProg_Cd As String) As cMdb_Cus_Prog

        Load = New cMdb_Cus_Prog()

        Try

            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog WITH (Nolock) " & _
            "WHERE  Spector_Cd = '" & pstrProg_Cd.Trim.Replace("'", "''") & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function Delete(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
        Delete = False
        Dim strSql As String
        Try
            strSql = _
                " Delete from Mdb_Cus_Prog where Cus_Prog_Id = " & oMdb_Cus_Prog.Cus_Prog_Id & ""

            db.Execute(strSql)

            Delete = True
        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Cus_Prog, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then .Cus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
                If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then .Cus_No = pdrRow.Item("Cus_No").ToString
                If Not (pdrRow.Item("Cus_Prog_Guid").Equals(DBNull.Value)) Then .Cus_Prog_Guid = pdrRow.Item("Cus_Prog_Guid").ToString
                If Not (pdrRow.Item("Spector_Cd").Equals(DBNull.Value)) Then .Spector_Cd = pdrRow.Item("Spector_Cd").ToString
                If Not (pdrRow.Item("Prog_Cd").Equals(DBNull.Value)) Then .Prog_Cd = pdrRow.Item("Prog_Cd").ToString
                'If Not (pdrRow.Item("Prog_Desc").Equals(DBNull.Value)) Then .Prog_Desc = pdrRow.Item("Prog_Desc").ToString
                If Not (pdrRow.Item("Imprint").Equals(DBNull.Value)) Then .Imprint = pdrRow.Item("Imprint").ToString
                If Not (pdrRow.Item("Prog_CSR").Equals(DBNull.Value)) Then .Prog_CSR = pdrRow.Item("Prog_CSR").ToString
                If Not (pdrRow.Item("Prog_Type").Equals(DBNull.Value)) Then .Prog_Type = pdrRow.Item("Prog_Type")
                If Not (pdrRow.Item("Quote_Type_ID").Equals(DBNull.Value)) Then .Quote_Type_ID = pdrRow.Item("Quote_Type_ID").ToString
                If Not (pdrRow.Item("Quote_Ship_Method_ID").Equals(DBNull.Value)) Then .Quote_Ship_Method_ID = pdrRow.Item("Quote_Ship_Method_ID").ToString
                If Not (pdrRow.Item("Quote_Step_ID").Equals(DBNull.Value)) Then .Quote_Step_ID = pdrRow.Item("Quote_Step_ID")
                If Not (pdrRow.Item("Quote_Step_User").Equals(DBNull.Value)) Then .Quote_Step_User = pdrRow.Item("Quote_Step_User").ToString
                If Not (pdrRow.Item("Start_Dt").Equals(DBNull.Value)) Then .Start_Dt = pdrRow.Item("Start_Dt")
                If Not (pdrRow.Item("End_Dt").Equals(DBNull.Value)) Then .End_Dt = pdrRow.Item("End_Dt")
                If Not (pdrRow.Item("No_End_Date").Equals(DBNull.Value)) Then .No_End_Date = pdrRow.Item("No_End_Date")
                If Not (pdrRow.Item("Renew_To_Cus_Prog_Id").Equals(DBNull.Value)) Then .Renew_To_Cus_Prog_Id = pdrRow.Item("Renew_To_Cus_Prog_Id")
                If Not (pdrRow.Item("Approved_By_Us").Equals(DBNull.Value)) Then .Approved_By_Us = pdrRow.Item("Approved_By_Us").ToString
                If Not (pdrRow.Item("Approved_By_Them").Equals(DBNull.Value)) Then .Approved_By_Them = pdrRow.Item("Approved_By_Them").ToString
                If Not (pdrRow.Item("Approved_Dt").Equals(DBNull.Value)) Then .Approved_Dt = pdrRow.Item("Approved_Dt")
                If Not (pdrRow.Item("Eqp_Level").Equals(DBNull.Value)) Then .Eqp_Level = pdrRow.Item("Eqp_Level")
                If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then .Eqp_Column = pdrRow.Item("Eqp_Column")
                If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then .Eqp_Pct = pdrRow.Item("Eqp_Pct")
                If Not (pdrRow.Item("Prog_Comments").Equals(DBNull.Value)) Then .Prog_Comments = pdrRow.Item("Prog_Comments").ToString
                If Not (pdrRow.Item("Contact_ID").Equals(DBNull.Value)) Then .Contact_ID = pdrRow.Item("Contact_ID")
                If Not (pdrRow.Item("One_Shot").Equals(DBNull.Value)) Then .One_Shot = pdrRow.Item("One_Shot")
                If Not (pdrRow.Item("Current_Rev_No").Equals(DBNull.Value)) Then .Current_Rev_No = pdrRow.Item("Current_Rev_No")
                If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then .Ord_No = pdrRow.Item("Ord_No").ToString
                If Not (pdrRow.Item("Auto_Renew").Equals(DBNull.Value)) Then .Auto_Renew = pdrRow.Item("Auto_Renew")
                If Not (pdrRow.Item("Renew_Dt").Equals(DBNull.Value)) Then .Renew_Dt = pdrRow.Item("Renew_Dt")
                If Not (pdrRow.Item("Renew_End_Dt").Equals(DBNull.Value)) Then .Renew_End_Dt = pdrRow.Item("Renew_End_Dt")
                If Not (pdrRow.Item("Renew_Sent").Equals(DBNull.Value)) Then .Renew_Sent = pdrRow.Item("Renew_Sent")
                If Not (pdrRow.Item("For_All_Accounts").Equals(DBNull.Value)) Then .For_All_Accounts = pdrRow.Item("For_All_Accounts")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_TS = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Create_By").Equals(DBNull.Value)) Then .Create_By = pdrRow.Item("Create_By").ToString
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_TS = pdrRow.Item("Update_Ts")
                '++ID 16.03.2015
                If Not (pdrRow.Item("QUOTE_STATUS").Equals(DBNull.Value)) Then .Quote_Status = pdrRow.Item("QUOTE_STATUS").ToString
                If Not (pdrRow.Item("QUOTE_RESULT").Equals(DBNull.Value)) Then .Quote_Result = pdrRow.Item("QUOTE_RESULT").ToString
                If Not (pdrRow.Item("DECISION_DT").Equals(DBNull.Value)) Then .Decision_Dt = pdrRow.Item("DECISION_DT")

                If Not (pdrRow.Item("Note").Equals(DBNull.Value)) Then .Note = pdrRow.Item("Note").ToString

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(ByVal pMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
        Save = False
        Try
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog " & _
            "WHERE  Cus_Prog_Id = " & pMdb_Cus_Prog.Cus_Prog_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cus_Prog, drRow)

            If dt.Rows.Count = 0 Then
                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand
            Else
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand
            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cus_Prog.Cus_Prog_Id = 0 Then pMdb_Cus_Prog.Cus_Prog_Id = db.DataTable("SELECT MAX(Cus_Prog_Id) AS Max_Cus_Prog_Id FROM MDB_CUS_PROG WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pCus_Prog As cMdb_Cus_Prog, ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Cus_Prog_Id") = pCus_Prog.Cus_Prog_Id
            pdrRow.Item("Cus_No") = pCus_Prog.Cus_No
            pdrRow.Item("Cus_Prog_Guid") = pCus_Prog.Cus_Prog_Guid
            pdrRow.Item("Spector_Cd") = pCus_Prog.Spector_Cd
            pdrRow.Item("Prog_Cd") = pCus_Prog.Prog_Cd
            pdrRow.Item("Imprint") = pCus_Prog.Imprint
            pdrRow.Item("Prog_CSR") = pCus_Prog.Prog_CSR

            ' Exceptionnaly here, we set long data to the long field. first extraction cause it that way.

            'Normally we should NOT save in Prog_Comments as it is only a TEMP field.
            'If pCus_Prog.Prog_Desc.Length > 50 Then
            '    pdrRow.Item("Prog_Comments") = pCus_Prog.Prog_Comments
            'Else
            '    pdrRow.Item("Prog_Desc") = pCus_Prog.Prog_Desc
            'End If

            'pdrRow.Item("Prog_Desc") = pCus_Prog.Prog_Desc
            pdrRow.Item("Prog_Comments") = pCus_Prog.Prog_Comments
            pdrRow.Item("Prog_Type") = pCus_Prog.Prog_Type
            pdrRow.Item("Quote_Type_ID") = pCus_Prog.Quote_Type_ID
            pdrRow.Item("Quote_Ship_Method_ID") = pCus_Prog.Quote_Ship_Method_ID
            If pCus_Prog.Quote_Step_ID = Quote_Step.New_Quote Then pCus_Prog.Quote_Step_ID = Quote_Step.Saved_Quote
            pdrRow.Item("Quote_Step_ID") = pCus_Prog.Quote_Step_ID
            pdrRow.Item("Quote_Step_User") = pCus_Prog.Quote_Step_User

            If pCus_Prog.Start_Dt.Year <> 1 Then pdrRow.Item("Start_Dt") = pCus_Prog.Start_Dt.Date
            If pCus_Prog.End_Dt.Year <> 1 Then pdrRow.Item("End_Dt") = pCus_Prog.End_Dt.Date
            pdrRow.Item("No_End_Date") = pCus_Prog.No_End_Date
            pdrRow.Item("Renew_To_Cus_Prog_Id") = pCus_Prog.Renew_To_Cus_Prog_Id
            pdrRow.Item("Approved_By_Us") = pCus_Prog.Approved_By_Us
            pdrRow.Item("Approved_By_Them") = pCus_Prog.Approved_By_Them
            If pCus_Prog.Approved_Dt.Year <> 1 Then pdrRow.Item("Approved_Dt") = pCus_Prog.Approved_Dt.Date
            pdrRow.Item("Eqp_Level") = pCus_Prog.Eqp_Level
            pdrRow.Item("Eqp_Column") = pCus_Prog.Eqp_Column
            pdrRow.Item("Eqp_Pct") = pCus_Prog.Eqp_Pct
            pdrRow.Item("Contact_ID") = pCus_Prog.Contact_ID
            pdrRow.Item("One_Shot") = pCus_Prog.One_Shot
            pdrRow.Item("Ord_No") = pCus_Prog.Ord_No
            pdrRow.Item("Current_Rev_No") = pCus_Prog.Current_Rev_No

            pdrRow.Item("Auto_Renew") = pCus_Prog.Auto_Renew
            If pCus_Prog.Renew_Dt.Year <> 1 Then pdrRow.Item("Renew_Dt") = pCus_Prog.Renew_Dt.Date
            If pCus_Prog.Renew_End_Dt.Year <> 1 Then pdrRow.Item("Renew_End_Dt") = pCus_Prog.Renew_End_Dt.Date
            pdrRow.Item("Renew_Sent") = pCus_Prog.Renew_Sent
            pdrRow.Item("For_All_Accounts") = pCus_Prog.For_All_Accounts

            pCus_Prog.User_Login = Environment.UserName
            pCus_Prog.Update_Ts = Date.Now

            If pCus_Prog.Cus_Prog_Id = 0 Then
                pdrRow.Item("Create_By") = pCus_Prog.User_Login
                pdrRow.Item("Create_Ts") = pCus_Prog.Update_TS
            End If

            pdrRow.Item("User_Login") = pCus_Prog.User_Login
            pdrRow.Item("Update_Ts") = pCus_Prog.Update_TS

            '++ID 16.03.2015
            If pCus_Prog.Prog_Type = 3 Then
                pdrRow.Item("QUOTE_STATUS") = pCus_Prog.Quote_Status
                pdrRow.Item("QUOTE_RESULT") = pCus_Prog.Quote_Result
                If pCus_Prog.Decision_Dt.Year <> 1 Then pdrRow.Item("DECISION_DT") = pCus_Prog.Decision_Dt

            End If

            '++ID 7.28.2018
            pdrRow.Item("Note") = pCus_Prog.Note

            '------------------------------------------

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current Comment from the database, if it exists.
    'Public Function Delete(pm_intCus_Prog_Id As Integer)

    '    Delete = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql = _
    '        "DELETE FROM Mdb_Cus_Prog " & _
    '        "WHERE  Cus_Prog_Id = " & pm_intCus_Prog_Id & " "

    '        db.Execute(strSql)

    '        Delete = True

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    Public Function Get_Quote_Step_ComboList() As DataTable

        Get_Quote_Step_ComboList = db.DataTable( _
        "SELECT     CAST(0 AS INT) AS Quote_Step_ID, CAST(' ' AS VARCHAR(255)) AS Quote_Step_Desc " & _
        "UNION      " & _
        "SELECT     ENUM_ORDER AS Quote_Step_ID, ENUM_VALUE AS Quote_Step_Desc " & _
        "FROM       MDB_CFG_ENUM WITH (Nolock) " & _
        "WHERE      ENUM_CAT = 'QUOTE_STEP_ID' " & _
        "ORDER BY   Quote_Step_ID ")

    End Function

    Public Function Get_Quote_Type_ComboList() As DataTable

        Get_Quote_Type_ComboList = db.DataTable( _
        "SELECT     CAST(0 AS INT) AS Quote_Type_ID, CAST(' ' AS VARCHAR(255)) AS Quote_Type_Desc " & _
        "UNION      " & _
        "SELECT     ID AS Quote_Type_ID, ENUM_VALUE AS Quote_Type_Desc " & _
        "FROM       MDB_CFG_ENUM WITH (Nolock) " & _
        "WHERE      ENUM_CAT = 'QUOTE_TYPE_ID' " & _
        "ORDER BY   Quote_Type_ID ")

    End Function

    Public Function Get_Quote_Ship_Method_ComboList() As DataTable

        Get_Quote_Ship_Method_ComboList = db.DataTable( _
        "SELECT     CAST(0 AS INT) AS Quote_Ship_Method_ID, CAST(' ' AS VARCHAR(255)) AS Quote_Ship_Method_Desc " & _
        "UNION      " & _
        "SELECT     ID AS Quote_Ship_Method_ID, ENUM_VALUE AS Quote_Ship_Method_Desc " & _
        "FROM       MDB_CFG_ENUM WITH (Nolock) " & _
        "WHERE      ENUM_CAT = 'QUOTE_SHIP_METHOD_ID' " & _
        "ORDER BY   Quote_Ship_Method_ID ")

    End Function

    Public Function Get_XML(ByVal pintID As Integer) As DataTable

        Get_XML = db.DataTable( _
        "SELECT * " & _
        "FROM   Mdb_Cus_Prog WITH (Nolock) " & _
        "WHERE  Cus_Prog_Id = " & pintID & " " & _
        "FOR XML AUTO ")

    End Function

    Public Function Get_Program_XML(ByVal pProgram As cMdb_Cus_Prog) As DataTable

        Get_Program_XML = Nothing
        '++ID 24.03.2015 added :   "           MDB_CUS_PROG.QUOTE_STATUS, MDB_CUS_PROG.QUOTE_RESULT, MDB_CUS_PROG.DECISION_DT,      " & _
        '++ID 7.28.2018 added : MDB_CUS_PROG.NOTE,

        Dim strSql As String = "" &
        "SELECT	    MDB_CUS_PROG.CUS_PROG_ID, MDB_CUS_PROG.CUS_NO, MDB_CUS_PROG.CUS_PROG_GUID, MDB_CUS_PROG.SPECTOR_CD, " &
        "           MDB_CUS_PROG.PROG_TYPE, MDB_CUS_PROG.PROG_CD, MDB_CUS_PROG.PROG_DESC, MDB_CUS_PROG.IMPRINT, MDB_CUS_PROG.PROG_CSR, " &
        "           MDB_CUS_PROG.QUOTE_TYPE_ID, MDB_CUS_PROG.QUOTE_SHIP_METHOD_ID, MDB_CUS_PROG.QUOTE_STEP_ID, MDB_CUS_PROG.QUOTE_STEP_USER, " &
        "           MDB_CUS_PROG.START_DT, MDB_CUS_PROG.END_DT, MDB_CUS_PROG.NO_END_DATE, MDB_CUS_PROG.RENEW_TO_CUS_PROG_ID, " &
        "           MDB_CUS_PROG.APPROVED_BY_US, MDB_CUS_PROG.APPROVED_BY_THEM, MDB_CUS_PROG.APPROVED_DT, MDB_CUS_PROG.EQP_LEVEL, " &
        "           MDB_CUS_PROG.EQP_COLUMN, MDB_CUS_PROG.EQP_PCT, MDB_CUS_PROG.PROG_COMMENTS, MDB_CUS_PROG.CONTACT_ID, " &
        "           MDB_CUS_PROG.ONE_SHOT, MDB_CUS_PROG.ORD_NO, MDB_CUS_PROG.CURRENT_REV_NO, MDB_CUS_PROG.FOR_ALL_ACCOUNTS, " &
        "           MDB_CUS_PROG.USER_LOGIN, MDB_CUS_PROG.CREATE_TS, MDB_CUS_PROG.CREATE_BY, MDB_CUS_PROG.UPDATE_TS, " &
        "           MDB_CUS_PROG.QUOTE_STATUS, MDB_CUS_PROG.QUOTE_RESULT, MDB_CUS_PROG.DECISION_DT, MDB_CUS_PROG.NOTE,     " &
        "           MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ITEM_LIST_ID, MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ITEM_LIST_GUID, " &
        "           MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ID, MDB_CUS_PROG_ITEM_LIST.PROD_CAT_ID, MDB_CUS_PROG_ITEM_LIST.ITEM_CD, " &
        "           MDB_CUS_PROG_ITEM_LIST.ITEM_NO, MDB_CUS_PROG_ITEM_LIST.ITEM_DESC, MDB_CUS_PROG_ITEM_LIST.ITEM_COLOR, " &
        "           MDB_CUS_PROG_ITEM_LIST.EQP_LEVEL, MDB_CUS_PROG_ITEM_LIST.EQP_COLUMN, MDB_CUS_PROG_ITEM_LIST.EQP_PCT, " &
        "           MDB_CUS_PROG_ITEM_LIST.UNIT_PRICE, MDB_CUS_PROG_ITEM_LIST.MIN_QTY_ORD, MDB_CUS_PROG_ITEM_LIST.SETUP_WAIVED, " &
        "           MDB_CUS_PROG_ITEM_LIST.SETUP_PRICE, MDB_CUS_PROG_ITEM_LIST.RUN_CHARGE, MDB_CUS_PROG_ITEM_LIST.DEC_MET_GROUP_ID, " &
        "           MDB_CUS_PROG_ITEM_LIST.COLOR_COUNT, MDB_CUS_PROG_ITEM_LIST.LOCATION_COUNT, MDB_CUS_PROG_ITEM_LIST.QUOTE_TYPE_ID, " &
        "           MDB_CUS_PROG_ITEM_LIST.QUOTE_SHIP_METHOD_ID, MDB_CUS_PROG_ITEM_LIST.PACK_ID, MDB_CUS_PROG_ITEM_LIST.OVERSEAS, " &
        "           MDB_CUS_PROG_ITEM_LIST.DOMESTIC, MDB_CUS_PROG_ITEM_LIST.USER_LOGIN, MDB_CUS_PROG_ITEM_LIST.CREATE_TS, " &
        "           MDB_CUS_PROG_ITEM_LIST.UPDATE_TS " &
        "FROM	    MDB_CUS_PROG WITH (NOLOCK) " &
        "LEFT JOIN	MDB_CUS_PROG_REV WITH (NOLOCK) ON MDB_CUS_PROG.CUS_PROG_ID = MDB_CUS_PROG_REV.CUS_PROG_ID AND MDB_CUS_PROG.CURRENT_REV_NO = MDB_CUS_PROG_REV.REV_NO " &
        "LEFT JOIN	MDB_CUS_PROG_ITEM_LIST WITH (NOLOCK) ON MDB_CUS_PROG.CUS_PROG_ID = MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ID " &
        "WHERE      MDB_CUS_PROG.CUS_PROG_ID = " & pProgram.Cus_Prog_Id.ToString & " " &
        "FOR XML AUTO "

        Get_Program_XML = db.DataTable(strSql)

    End Function

    Public Function Get_Revision_XML(ByVal pProgram As cMdb_Cus_Prog) As DataTable

        Get_Revision_XML = Nothing
        '++ID 24.03.2015 added :   "           MDB_CUS_PROG.QUOTE_STATUS, MDB_CUS_PROG.QUOTE_RESULT, MDB_CUS_PROG.DECISION_DT,      " & _
        '++ID 7.28.2018 added : MDB_CUS_PROG.NOTE,
        Dim strSql As String = "" &
        "SELECT	    MDB_CUS_PROG.CUS_PROG_ID, MDB_CUS_PROG.CUS_NO, MDB_CUS_PROG.CUS_PROG_GUID, MDB_CUS_PROG.SPECTOR_CD, " &
        "           MDB_CUS_PROG.PROG_TYPE, MDB_CUS_PROG.PROG_CD, MDB_CUS_PROG.PROG_DESC, MDB_CUS_PROG.IMPRINT, MDB_CUS_PROG.PROG_CSR, " &
        "           MDB_CUS_PROG.QUOTE_TYPE_ID, MDB_CUS_PROG.QUOTE_SHIP_METHOD_ID, MDB_CUS_PROG.QUOTE_STEP_ID, MDB_CUS_PROG.QUOTE_STEP_USER, " &
        "           MDB_CUS_PROG.START_DT, MDB_CUS_PROG.END_DT, MDB_CUS_PROG.NO_END_DATE, MDB_CUS_PROG.RENEW_TO_CUS_PROG_ID, " &
        "           MDB_CUS_PROG.APPROVED_BY_US, MDB_CUS_PROG.APPROVED_BY_THEM, MDB_CUS_PROG.APPROVED_DT, MDB_CUS_PROG.EQP_LEVEL, " &
        "           MDB_CUS_PROG.EQP_COLUMN, MDB_CUS_PROG.EQP_PCT, MDB_CUS_PROG.PROG_COMMENTS, MDB_CUS_PROG.CONTACT_ID, " &
        "           MDB_CUS_PROG.ONE_SHOT, MDB_CUS_PROG.ORD_NO, MDB_CUS_PROG.CURRENT_REV_NO, MDB_CUS_PROG.USER_LOGIN, " &
        "           MDB_CUS_PROG.CREATE_TS, MDB_CUS_PROG.CREATE_BY, MDB_CUS_PROG.UPDATE_TS, MDB_CUS_PROG.FOR_ALL_ACCOUNTS, " &
        "           MDB_CUS_PROG.QUOTE_STATUS, MDB_CUS_PROG.QUOTE_RESULT, MDB_CUS_PROG.DECISION_DT, MDB_CUS_PROG.NOTE,      " &
        "           MDB_CUS_PROG_REV.CUS_PROG_REV_ID, MDB_CUS_PROG_REV.CUS_PROG_ID, MDB_CUS_PROG_REV.REV_NO, " &
        "           MDB_CUS_PROG_REV.REV_STATE, MDB_CUS_PROG_REV.PROGRAM, MDB_CUS_PROG_REV.IMPRINT, " &
        "           MDB_CUS_PROG_REV.PROG_CSR, MDB_CUS_PROG_REV.START_DT, MDB_CUS_PROG_REV.END_DT, " &
        "           MDB_CUS_PROG_REV.CICNTP_ID, MDB_CUS_PROG_REV.USER_LOGIN, MDB_CUS_PROG_REV.CREATE_TS, MDB_CUS_PROG_REV.UPDATE_TS, " &
        "           MDB_CFG_CHARGE_USAGE.CHARGE_USAGE_ID, MDB_CFG_CHARGE_USAGE.CHARGE_ID, MDB_CFG_CHARGE_USAGE.CHARGE_CD, " &
        "           MDB_CFG_CHARGE_USAGE.DEC_MET_ID, MDB_CFG_CHARGE_USAGE.CUS_NO, MDB_CFG_CHARGE_USAGE.APPLY_TO_SHIP_TO, " &
        "           MDB_CFG_CHARGE_USAGE.APPLY_TO_PROGRAM, MDB_CFG_CHARGE_USAGE.CUS_PROG_ID, MDB_CFG_CHARGE_USAGE.CUS_PROG_ITEM_LIST_ID, " &
        "           MDB_CFG_CHARGE_USAGE.ALWAYS_USE, MDB_CFG_CHARGE_USAGE.NEVER_USE, MDB_CFG_CHARGE_USAGE.WHEN_QTY_GT, " &
        "           MDB_CFG_CHARGE_USAGE.WHEN_AMT_GT, MDB_CFG_CHARGE_USAGE.WHEN_QTY_LT, MDB_CFG_CHARGE_USAGE.WHEN_AMT_LT, " &
        "           MDB_CFG_CHARGE_USAGE.ALWAYS_SURCLASS_NEVER, MDB_CFG_CHARGE_USAGE.SEND_EMAIL, MDB_CFG_CHARGE_USAGE.EMAIL_TO, " &
        "           MDB_CFG_CHARGE_USAGE.UNIT_PRICE, MDB_CFG_CHARGE_USAGE.NO_CHARGE, MDB_CFG_CHARGE_USAGE.CHARGE_FROM, " &
        "           MDB_CFG_CHARGE_USAGE.CHARGE_TO, MDB_CFG_CHARGE_USAGE.WHEN_REQ, MDB_CFG_CHARGE_USAGE.BLIND, " &
        "           MDB_CFG_CHARGE_USAGE.COMMENTS, MDB_CFG_CHARGE_USAGE.AUTORIZED_BY, MDB_CFG_CHARGE_USAGE.FOR_REPEATS_ONLY, " &
        "           MDB_CFG_CHARGE_USAGE.USER_LOGIN, MDB_CFG_CHARGE_USAGE.CREATE_TS, MDB_CFG_CHARGE_USAGE.UPDATE_TS, " &
        "           MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ITEM_LIST_ID, MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ITEM_LIST_GUID, " &
        "           MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ID, MDB_CUS_PROG_ITEM_LIST.PROD_CAT_ID, MDB_CUS_PROG_ITEM_LIST.ITEM_CD, " &
        "           MDB_CUS_PROG_ITEM_LIST.ITEM_NO, MDB_CUS_PROG_ITEM_LIST.ITEM_DESC, MDB_CUS_PROG_ITEM_LIST.ITEM_COLOR, " &
        "           MDB_CUS_PROG_ITEM_LIST.EQP_LEVEL, MDB_CUS_PROG_ITEM_LIST.EQP_COLUMN, MDB_CUS_PROG_ITEM_LIST.EQP_PCT, " &
        "           MDB_CUS_PROG_ITEM_LIST.UNIT_PRICE, MDB_CUS_PROG_ITEM_LIST.MIN_QTY_ORD, MDB_CUS_PROG_ITEM_LIST.SETUP_WAIVED, " &
        "           MDB_CUS_PROG_ITEM_LIST.SETUP_PRICE, MDB_CUS_PROG_ITEM_LIST.RUN_CHARGE, MDB_CUS_PROG_ITEM_LIST.DEC_MET_GROUP_ID, " &
        "           MDB_CUS_PROG_ITEM_LIST.COLOR_COUNT, MDB_CUS_PROG_ITEM_LIST.LOCATION_COUNT, MDB_CUS_PROG_ITEM_LIST.QUOTE_TYPE_ID, " &
        "           MDB_CUS_PROG_ITEM_LIST.QUOTE_SHIP_METHOD_ID, MDB_CUS_PROG_ITEM_LIST.PACK_ID, MDB_CUS_PROG_ITEM_LIST.OVERSEAS, " &
        "           MDB_CUS_PROG_ITEM_LIST.DOMESTIC, MDB_CUS_PROG_ITEM_LIST.USER_LOGIN, MDB_CUS_PROG_ITEM_LIST.CREATE_TS, " &
        "           MDB_CUS_PROG_ITEM_LIST.UPDATE_TS " &
        "FROM	    MDB_CUS_PROG WITH (NOLOCK) " &
        "LEFT JOIN	MDB_CUS_PROG_REV WITH (NOLOCK) ON MDB_CUS_PROG.CUS_PROG_ID = MDB_CUS_PROG_REV.CUS_PROG_ID AND MDB_CUS_PROG.CURRENT_REV_NO = MDB_CUS_PROG_REV.REV_NO " &
        "LEFT JOIN	MDB_CUS_PROG_ITEM_LIST WITH (NOLOCK) ON MDB_CUS_PROG.CUS_PROG_ID = MDB_CUS_PROG_ITEM_LIST.CUS_PROG_ID " &
        "LEFT JOIN  MDB_CFG_CHARGE_USAGE WITH (NOLOCK) ON MDB_CUS_PROG.CUS_PROG_ID = MDB_CFG_CHARGE_USAGE.CUS_PROG_ID " &
        "WHERE      MDB_CUS_PROG.CUS_PROG_ID = " & pProgram.Cus_Prog_Id.ToString & " " &
        "FOR XML AUTO "

        Get_Revision_XML = db.DataTable(strSql)

    End Function

    Public Function ContainsCustomItems(ByRef pProgram As cMdb_Cus_Prog) As Boolean

        ContainsCustomItems = False

        Dim strSql As String = "" & _
        "SELECT	    I.* " & _
        "FROM	    MDB_CUS_PROG p WITH (NOLOCK) " & _
        "LEFT JOIN	MDB_CUS_PROG_ITEM_LIST I WITH (NOLOCK) ON P.CUS_PROG_ID = I.CUS_PROG_ID " & _
        "WHERE      I.CUS_PROG_ID = " & pProgram.Cus_Prog_Id.ToString & " AND I.CUSTOM_ITEM_ID <> 0 "

        Dim DT As New DataTable
        DT = db.DataTable(strSql)

        ContainsCustomItems = (DT.Rows.Count <> 0)

    End Function


End Class ' cMdb_Cus_Prog_DAL

