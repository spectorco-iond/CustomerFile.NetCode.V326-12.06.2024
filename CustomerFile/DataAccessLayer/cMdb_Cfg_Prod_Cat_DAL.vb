Imports System.Data.Odbc

Public Class cMdb_Cfg_Prod_Cat_DAL

    Public Function Load(ByVal pintID As Integer) As cMdb_Cfg_Prod_Cat

        Load = New cMdb_Cfg_Prod_Cat()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Prod_Cat WITH (Nolock) " & _
            "WHERE  Prod_Cat_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Prod_Cat_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Cfg_Prod_Cat, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Prod_Cat_Id").Equals(DBNull.Value)) Then .Prod_Cat_Id = pdrRow.Item("Prod_Cat_Id")
                If Not (pdrRow.Item("Prod_Cat_Code").Equals(DBNull.Value)) Then .Prod_Cat_Code = pdrRow.Item("Prod_Cat_Code").ToString
                If Not (pdrRow.Item("Prod_Cat_Desc").Equals(DBNull.Value)) Then .Prod_Cat_Desc = pdrRow.Item("Prod_Cat_Desc").ToString
                If Not (pdrRow.Item("Prod_Cat_Order").Equals(DBNull.Value)) Then .Prod_Cat_Order = pdrRow.Item("Prod_Cat_Order")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_Ts = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Prod_Cat_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cfg_Prod_Cat As cMdb_Cfg_Prod_Cat) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cfg_Prod_Cat " & _
            "WHERE  Prod_Cat_Id = " & pMdb_Cfg_Prod_Cat.Prod_Cat_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cfg_Prod_Cat, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cfg_Prod_Cat.Prod_Cat_Id = 0 Then pMdb_Cfg_Prod_Cat.Prod_Cat_Id = db.DataTable("SELECT MAX(Prod_Cat_Id) AS Max_Prod_Cat_Id FROM Mdb_Cfg_Prod_Cat WITH (Nolock)").Rows(0).Item("Max_Prod_Cat_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Prod_Cat_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pData As cMdb_Cfg_Prod_Cat, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Prod_Cat_Code") = pData.Prod_Cat_Code
            pdrRow.Item("Prod_Cat_Desc") = pData.Prod_Cat_Desc
            pdrRow.Item("Prod_Cat_Order") = pData.Prod_Cat_Order

            If pData.Prod_Cat_Id = 0 Then

                pData.Create_Ts = Date.Now
                pdrRow.Item("Create_Ts") = pData.Create_Ts

            End If

            pData.User_Login = Environment.UserName
            pdrRow.Item("User_Login") = pData.User_Login

            pData.Update_Ts = Date.Now
            pdrRow.Item("Update_Ts") = pData.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Prod_Cat_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(pId As Integer)

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cfg_Prod_Cat " & _
            "WHERE  Prod_Cat_Id = " & pId & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Prod_Cat_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class
