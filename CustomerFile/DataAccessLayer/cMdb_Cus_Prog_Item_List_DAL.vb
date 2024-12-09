Imports System.Data.Odbc

Public Class cMdb_Cus_Prog_Item_List_DAL

    Public Function Load(ByVal pintID As Integer) As cMdb_Cus_Prog_Item_List

        Load = New cMdb_Cus_Prog_Item_List()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_List WITH (Nolock) " & _
            "WHERE  Cus_Prog_Item_List_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Cus_Prog_Item_List, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Item_List_ID").Equals(DBNull.Value)) Then .Cus_Prog_Item_List_Id = pdrRow.Item("Cus_Prog_Item_List_ID")
                If Not (pdrRow.Item("Cus_Prog_Item_List_Guid").Equals(DBNull.Value)) Then .Cus_Prog_Item_List_Guid = pdrRow.Item("Cus_Prog_Item_List_Guid").ToString
                If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then .Cus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
                If Not (pdrRow.Item("Prod_Cat_Id").Equals(DBNull.Value)) Then .Prod_Cat_ID = pdrRow.Item("Prod_Cat_Id")
                If Not (pdrRow.Item("Item_Cd").Equals(DBNull.Value)) Then .Item_Cd = pdrRow.Item("Item_Cd").ToString
                If Not (pdrRow.Item("Custom_Item_Id").Equals(DBNull.Value)) Then .Custom_Item_Id = pdrRow.Item("Custom_Item_Id")
                If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then .Item_No = pdrRow.Item("Item_No").ToString
                If Not (pdrRow.Item("Item_Desc").Equals(DBNull.Value)) Then .Item_Desc = pdrRow.Item("Item_Desc").ToString
                If Not (pdrRow.Item("Item_Color").Equals(DBNull.Value)) Then .Item_Color = pdrRow.Item("Item_Color").ToString
                If Not (pdrRow.Item("Eqp_Level").Equals(DBNull.Value)) Then .Eqp_Level = pdrRow.Item("Eqp_Level")
                If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then .Eqp_Column = pdrRow.Item("Eqp_Column")
                If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then .Eqp_Pct = pdrRow.Item("Eqp_Pct")
                If Not (pdrRow.Item("Unit_Price").Equals(DBNull.Value)) Then .Unit_Price = pdrRow.Item("Unit_Price")
                If Not (pdrRow.Item("Min_Qty_Ord").Equals(DBNull.Value)) Then .Min_Qty_Ord = pdrRow.Item("Min_Qty_Ord")
                If Not (pdrRow.Item("Setup_Waived").Equals(DBNull.Value)) Then .Setup_Waived = pdrRow.Item("Setup_Waived")
                If Not (pdrRow.Item("Setup_Price").Equals(DBNull.Value)) Then .Setup_Price = pdrRow.Item("Setup_Price")
                If Not (pdrRow.Item("CHARGE_ID").Equals(DBNull.Value)) Then .ChargeId = pdrRow.Item("CHARGE_ID")
                If Not (pdrRow.Item("Run_Charge").Equals(DBNull.Value)) Then .Run_Charge = pdrRow.Item("Run_Charge")
                If Not (pdrRow.Item("Dec_Met_ID").Equals(DBNull.Value)) Then .Dec_Met_ID = pdrRow.Item("Dec_Met_ID")
                If Not (pdrRow.Item("Dec_Met_Group_ID").Equals(DBNull.Value)) Then .Dec_Met_Group_ID = pdrRow.Item("Dec_Met_Group_ID")
                If Not (pdrRow.Item("Color_Count").Equals(DBNull.Value)) Then .Color_Count = pdrRow.Item("Color_Count")
                If Not (pdrRow.Item("Location_Count").Equals(DBNull.Value)) Then .Location_Count = pdrRow.Item("Location_Count")
                If Not (pdrRow.Item("Quote_Type_ID").Equals(DBNull.Value)) Then .Quote_Type_ID = pdrRow.Item("Quote_Type_ID")
                If Not (pdrRow.Item("Quote_Ship_Method_ID").Equals(DBNull.Value)) Then .Quote_Ship_Method_ID = pdrRow.Item("Quote_Ship_Method_ID")
                If Not (pdrRow.Item("Pack_ID").Equals(DBNull.Value)) Then .Pack_ID = pdrRow.Item("Pack_ID")
                If Not (pdrRow.Item("Pack_Qty_By_ID").Equals(DBNull.Value)) Then .Pack_Qty_By_ID = pdrRow.Item("Pack_Qty_By_ID")
                If Not (pdrRow.Item("Pack_Comment").Equals(DBNull.Value)) Then .Pack_Comment = pdrRow.Item("Pack_Comment").ToString
                'If Not (pdrRow.Item("Overseas").Equals(DBNull.Value)) Then .Overseas = pdrRow.Item("Overseas")
                'If Not (pdrRow.Item("Domestic").Equals(DBNull.Value)) Then .Domestic = pdrRow.Item("Domestic")
                If Not (pdrRow.Item("Refill_ID").Equals(DBNull.Value)) Then .Refill_ID = pdrRow.Item("Refill_ID")
                If Not (pdrRow.Item("Refill_Color").Equals(DBNull.Value)) Then .Refill_Color = pdrRow.Item("Refill_Color").ToString
                If Not (pdrRow.Item("Refill_Qty").Equals(DBNull.Value)) Then .Refill_Qty = pdrRow.Item("Refill_Qty")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_Ts = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")
                If Not (pdrRow.Item("DocId").Equals(DBNull.Value)) Then .DocID = pdrRow.Item("DocId")

                If Not (pdrRow.Item("Need_Approval").Equals(DBNull.Value)) Then .Need_Approval = pdrRow.Item("Need_Approval")
                If Not (pdrRow.Item("Approved_By").Equals(DBNull.Value)) Then .ApprovedBy = pdrRow.Item("Approved_By").ToString
                If Not (pdrRow.Item("Approved_Date").Equals(DBNull.Value)) Then .Approved_Date = pdrRow.Item("Approved_Date").ToString
                If Not (pdrRow.Item("Item_comment_LOGO").Equals(DBNull.Value)) Then .Item_comment_logo = pdrRow.Item("Item_comment_LOGO").ToString

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String
            '[CUS_PROG_ITEM_LIST_ID],[CUS_PROG_ID],[PROD_CAT_ID],[ITEM_CD],[ITEM_NO],[ITEM_DESC],[ITEM_COLOR],[EQP_LEVEL],[EQP_COLUMN],[EQP_PCT],[UNIT_PRICE],[MIN_QTY_ORD],[USER_LOGIN],[UPDATE_TS]

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_List " & _
            "WHERE  Cus_Prog_Item_List_Id = " & pMdb_Cus_Prog_Item_List.Cus_Prog_Item_List_Id & " "

            'strSql = _
            '"SELECT [CUS_PROG_ITEM_LIST_ID],[CUS_PROG_ID],[PROD_CAT_ID],[ITEM_CD],[ITEM_NO],[ITEM_DESC],[ITEM_COLOR],[EQP_LEVEL],[EQP_COLUMN],[EQP_PCT],[UNIT_PRICE],[MIN_QTY_ORD],[USER_LOGIN],[UPDATE_TS] " & _
            '"FROM   Mdb_Cus_Prog_Item_List " & _
            '"WHERE  Cus_Prog_Item_List_Id = " & pMdb_Cus_Prog_Item_List.Cus_Prog_Item_List_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cus_Prog_Item_List, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cus_Prog_Item_List.Cus_Prog_Item_List_Id = 0 Then pMdb_Cus_Prog_Item_List.Cus_Prog_Item_List_Id = db.DataTable("SELECT MAX(Cus_Prog_Item_List_Id) AS Max_Cus_Prog_Item_List_Id FROM Mdb_Cus_Prog_Item_List WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Item_List_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pCus_Prog As cMdb_Cus_Prog_Item_List, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Prog_Item_List_Guid") = pCus_Prog.Cus_Prog_Item_List_Guid
            pdrRow.Item("Cus_Prog_Id") = pCus_Prog.Cus_Prog_Id
            pdrRow.Item("Prod_Cat_Id") = pCus_Prog.Prod_Cat_ID
            pdrRow.Item("Item_Cd") = pCus_Prog.Item_Cd
            pdrRow.Item("Custom_Item_Id") = pCus_Prog.Custom_Item_Id
            pdrRow.Item("Item_No") = pCus_Prog.Item_No
            pdrRow.Item("Item_Desc") = pCus_Prog.Item_Desc
            pdrRow.Item("Item_Color") = pCus_Prog.Item_Color
            pdrRow.Item("Eqp_Level") = pCus_Prog.Eqp_Level
            pdrRow.Item("Eqp_Column") = pCus_Prog.Eqp_Column
            pdrRow.Item("Eqp_Pct") = pCus_Prog.Eqp_Pct
            pdrRow.Item("Unit_Price") = pCus_Prog.Unit_Price
            Debug.Print("Save in mdb_cus_prog_item_list EQP_LEVEL = " & pCus_Prog.Eqp_Level & " Item Cd " & pCus_Prog.Item_Cd & " Price " & pCus_Prog.Unit_Price)

            pdrRow.Item("Min_Qty_Ord") = pCus_Prog.Min_Qty_Ord
            pdrRow.Item("Setup_Waived") = pCus_Prog.Setup_Waived
            pdrRow.Item("Setup_Price") = pCus_Prog.Setup_Price

            pdrRow.Item("CHARGE_ID") = pCus_Prog.ChargeId
            If pCus_Prog.Run_Charge = -1 Then
                pdrRow.Item("Run_Charge") = DBNull.Value
            Else
                pdrRow.Item("Run_Charge") = pCus_Prog.Run_Charge
            End If
            pdrRow.Item("Dec_Met_ID") = pCus_Prog.Dec_Met_ID
            pdrRow.Item("Dec_Met_Group_ID") = pCus_Prog.Dec_Met_Group_ID
            pdrRow.Item("Color_Count") = pCus_Prog.Color_Count
            pdrRow.Item("Location_Count") = pCus_Prog.Location_Count
            pdrRow.Item("Quote_Type_ID") = pCus_Prog.Quote_Type_ID
            pdrRow.Item("Quote_Ship_Method_ID") = pCus_Prog.Quote_Ship_Method_ID
            pdrRow.Item("Pack_ID") = pCus_Prog.Pack_ID
            pdrRow.Item("Pack_Qty_By_ID") = pCus_Prog.Pack_Qty_By_ID
            pdrRow.Item("Pack_Comment") = pCus_Prog.Pack_Comment
            pdrRow.Item("Overseas") = pCus_Prog.Overseas
            pdrRow.Item("Domestic") = pCus_Prog.Domestic
            pdrRow.Item("Refill_ID") = pCus_Prog.Refill_ID
            pdrRow.Item("Refill_Color") = pCus_Prog.Refill_Color
            pdrRow.Item("Refill_Qty") = pCus_Prog.Refill_Qty

            pCus_Prog.User_Login = Environment.UserName
            pCus_Prog.Update_Ts = Date.Now

            pdrRow.Item("User_Login") = pCus_Prog.User_Login
            pdrRow.Item("Update_Ts") = pCus_Prog.Update_Ts
            pdrRow.Item("DocId") = pCus_Prog.DocID

            pdrRow.Item("Need_Approval") = pCus_Prog.Need_Approval
            pdrRow.Item("Item_comment_LOGO") = pCus_Prog.Item_comment_logo

            If pCus_Prog.ApprovedBy <> "" Then
                pdrRow.Item("Approved_By") = pCus_Prog.ApprovedBy
            End If
            If pCus_Prog.Approved_Date.ToString <> "1/1/0001 12:00:00 AM" Then
                pdrRow.Item("Approved_Date") = pCus_Prog.Approved_Date
            End If



        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    'Ion 14.10.14   Delete element with CUS_PROG_ID from database
    Public Sub DeleteAll(ByRef oCus_Prog_Id As cMdb_Cus_Prog)
        Dim db As New cDBA
        Dim strSql As String
        Dim dt As DataTable
        Try
            Dim cus_prog_id As Int32 = oCus_Prog_Id.Cus_Prog_Id
            strSql = _
            " SELECT * " & _
            " FROM   Mdb_Cus_Prog_Item_List WITH (Nolock) " & _
            " where Cus_Prog_Id = " & cus_prog_id & ""

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                For Each item As DataRow In dt.Rows
                    Call Delete(CInt(item.Item("Cus_Prog_Item_List_Id").ToString))
                Next

            End If

        Catch ex As Exception
            MsgBox("Error in cMacolaOeprcfil_Sql." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    'Ion 
    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(ByVal pm_intCus_Prog_Item_List_Id As Integer)

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Prog_Item_List " & _
            "WHERE  Cus_Prog_Item_List_Id = " & pm_intCus_Prog_Item_List_Id & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    ' Deletes the current Comment from the database, if it exists.
    Public Function DeleteMacolaProgramPricing(ByVal pstrItem_Cd As String, ByVal piCus_Prog_ID As Integer)

        DeleteMacolaProgramPricing = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            ' Make sure only to remove program pricing. By default, Extra_14 is null.
            If piCus_Prog_ID > 0 Then

                strSql = "" & _
                "DELETE FROM OEPRCFIL_SQL " & _
                "WHERE CD_TP_1_ITEM_NO IN " & _
                "   ( SELECT ITEM_NO FROM IMITMIDX_SQL WHERE USER_DEF_FLD_1 = '" & pstrItem_Cd.Trim & "' ) " & _
                "AND EXTRA_14 = " & piCus_Prog_ID

                db.Execute(strSql)

            End If

            DeleteMacolaProgramPricing = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class ' cMdb_Cus_Prog_Item_List


