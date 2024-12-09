Imports System.Data.Odbc

Public Class cMDB_CUS_PROG_ITEM_PRICE_DAL

    Public Function Load(ByVal pintID As Integer) As cMDB_CUS_PROG_ITEM_PRICE

        Load = New cMDB_CUS_PROG_ITEM_PRICE()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_Price WITH (Nolock) " & _
            "WHERE  Cus_Prog_Item_Price_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMDB_CUS_PROG_ITEM_PRICE, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Item_Price_Id").Equals(DBNull.Value)) Then .Cus_Prog_Item_Price_Id = pdrRow.Item("Cus_Prog_Item_Price_Id")
                If Not (pdrRow.Item("Cus_Prog_Item_List_Guid").Equals(DBNull.Value)) Then .Cus_Prog_Item_List_Guid = pdrRow.Item("Cus_Prog_Item_List_Guid").ToString
                If Not (pdrRow.Item("Eqp_Level").Equals(DBNull.Value)) Then .Eqp_Level = pdrRow.Item("Eqp_Level")
                If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then .Eqp_Column = pdrRow.Item("Eqp_Column")
                If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then .Eqp_Pct = pdrRow.Item("Eqp_Pct")
                If Not (pdrRow.Item("Unit_Price").Equals(DBNull.Value)) Then .Unit_Price = pdrRow.Item("Unit_Price")
                If Not (pdrRow.Item("Min_Qty_Ord").Equals(DBNull.Value)) Then .Min_Qty_Ord = pdrRow.Item("Min_Qty_Ord")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_Ts = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")

            End With

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cus_Prog_Item_Price As cMDB_CUS_PROG_ITEM_PRICE) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_Price " & _
            "WHERE  Cus_Prog_Item_Price_Id = " & pMdb_Cus_Prog_Item_Price.Cus_Prog_Item_Price_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cus_Prog_Item_Price, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cus_Prog_Item_Price.Cus_Prog_Item_Price_Id = 0 Then pMdb_Cus_Prog_Item_Price.Cus_Prog_Item_Price_Id = db.DataTable("SELECT MAX(Cus_Prog_Item_Price_Id) AS Max_Cus_Prog_Item_Price_Id FROM Mdb_Cus_Prog_Item_Price WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Item_Price_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pCus_Prog As cMDB_CUS_PROG_ITEM_PRICE, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Prog_Item_List_Guid") = pCus_Prog.Cus_Prog_Item_List_Guid
            pdrRow.Item("Eqp_Level") = pCus_Prog.Eqp_Level
            pdrRow.Item("Eqp_Column") = pCus_Prog.Eqp_Column
            pdrRow.Item("Eqp_Pct") = pCus_Prog.Eqp_Pct
            pdrRow.Item("Unit_Price") = pCus_Prog.Unit_Price
            pdrRow.Item("Min_Qty_Ord") = pCus_Prog.Min_Qty_Ord

            pCus_Prog.User_Login = Environment.UserName
            pCus_Prog.Update_Ts = Date.Now

            If pCus_Prog.Cus_Prog_Item_Price_Id = 0 Then
                pCus_Prog.Create_Ts = pCus_Prog.Update_Ts
                pdrRow.Item("Create_Ts") = pCus_Prog.Update_Ts
            End If

            pdrRow.Item("User_Login") = pCus_Prog.User_Login
            pdrRow.Item("Update_Ts") = pCus_Prog.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(pm_intCus_Prog_Item_Price_Id As Integer)

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Prog_Item_Price " & _
            "WHERE  Cus_Prog_Item_Price_Id = " & pm_intCus_Prog_Item_Price_Id & " "

            '  db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class
