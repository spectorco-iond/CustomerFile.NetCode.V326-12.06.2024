Imports System.Data.Odbc

Public Class cMDB_CUS_PROG_ITEM_COLOR_DAL

    Public Function Load(ByVal pintID As Integer) As cMDB_CUS_PROG_ITEM_COLOR

        Load = New cMDB_CUS_PROG_ITEM_COLOR()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_Color WITH (Nolock) " & _
            "WHERE  Cus_Prog_Item_Color_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMDB_CUS_PROG_ITEM_COLOR, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Item_Color_Id").Equals(DBNull.Value)) Then .Cus_Prog_Item_Color_Id = pdrRow.Item("Cus_Prog_Item_Color_Id")
                If Not (pdrRow.Item("Cus_Prog_Item_List_Guid").Equals(DBNull.Value)) Then .Cus_Prog_Item_List_Guid = pdrRow.Item("Cus_Prog_Item_List_Guid").ToString
                If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then .Item_No = pdrRow.Item("Item_No").ToString
                If Not (pdrRow.Item("Selected").Equals(DBNull.Value)) Then .Selected = pdrRow.Item("Selected")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_Ts = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")

            End With

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cus_Prog_Item_Color As cMDB_CUS_PROG_ITEM_COLOR) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Item_Color " & _
            "WHERE  Cus_Prog_Item_Color_Id = " & pMdb_Cus_Prog_Item_Color.Cus_Prog_Item_Color_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cus_Prog_Item_Color, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cus_Prog_Item_Color.Cus_Prog_Item_Color_Id = 0 Then pMdb_Cus_Prog_Item_Color.Cus_Prog_Item_Color_Id = db.DataTable("SELECT MAX(Cus_Prog_Item_Color_Id) AS Max_Cus_Prog_Item_Color_Id FROM Mdb_Cus_Prog_Item_Color WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Item_Color_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pColor As cMDB_CUS_PROG_ITEM_COLOR, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Prog_Item_List_Guid") = pColor.Cus_Prog_Item_List_Guid
            pdrRow.Item("Item_No") = pColor.Item_No
            pdrRow.Item("Selected") = pColor.Selected

            pColor.User_Login = Environment.UserName
            pColor.Update_Ts = Date.Now

            If pColor.Cus_Prog_Item_Color_Id = 0 Then
                pColor.Create_Ts = pColor.Update_Ts
                pdrRow.Item("Create_Ts") = pColor.Update_Ts
            End If

            pdrRow.Item("User_Login") = pColor.User_Login
            pdrRow.Item("Update_Ts") = pColor.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(pm_intCus_Prog_Item_Color_Id As Integer) As Boolean

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Prog_Item_Color " & _
            "WHERE  Cus_Prog_Item_Color_Id = " & pm_intCus_Prog_Item_Color_Id & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


End Class
