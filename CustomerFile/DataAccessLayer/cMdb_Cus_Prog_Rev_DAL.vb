Imports System.Data.Odbc

Public Class cMdb_Cus_Prog_Rev_DAL

    Public Function Load(ByVal pintID As Integer) As cMdb_Cus_Prog_Rev

        Load = New cMdb_Cus_Prog_Rev()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Rev WITH (Nolock) " & _
            "WHERE  Cus_Prog_Rev_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Load(ByRef poProgram As cMdb_Cus_Prog) As cMdb_Cus_Prog_Rev

        Load = New cMdb_Cus_Prog_Rev()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Rev WITH (Nolock) " & _
            "WHERE  Cus_Prog_Id = " & poProgram.Cus_Prog_Id & " AND " & _
            "       Rev_No = " & poProgram.current_rev_no

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Cus_Prog_Rev, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Rev_Id").Equals(DBNull.Value)) Then .Cus_Prog_Rev_ID = pdrRow.Item("Cus_Prog_Rev_Id")
                If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then .Cus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
                If Not (pdrRow.Item("Rev_No").Equals(DBNull.Value)) Then .Rev_No = pdrRow.Item("Rev_No")
                If Not (pdrRow.Item("Rev_State").Equals(DBNull.Value)) Then .Rev_State = pdrRow.Item("Rev_State").ToString
                If Not (pdrRow.Item("Program").Equals(DBNull.Value)) Then .Program = pdrRow.Item("Program").ToString
                If Not (pdrRow.Item("Imprint").Equals(DBNull.Value)) Then .Imprint = pdrRow.Item("Imprint").ToString
                If Not (pdrRow.Item("Prog_CSR").Equals(DBNull.Value)) Then .Prog_CSR = pdrRow.Item("Prog_CSR").ToString
                If Not (pdrRow.Item("Start_Dt").Equals(DBNull.Value)) Then .Start_Dt = pdrRow.Item("Start_Dt")
                If Not (pdrRow.Item("End_Dt").Equals(DBNull.Value)) Then .End_Dt = pdrRow.Item("End_Dt")
                If Not (pdrRow.Item("Cicntp_Id").Equals(DBNull.Value)) Then .Cicntp_ID = pdrRow.Item("Cicntp_Id")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then .Create_Ts = pdrRow.Item("Create_Ts")
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cus_Prog_Rev As cMdb_Cus_Prog_Rev) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Rev " & _
            "WHERE  Cus_Prog_Rev_Id = " & pMdb_Cus_Prog_Rev.Cus_Prog_Rev_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Cus_Prog_Rev, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Cus_Prog_Rev.Cus_Prog_Rev_Id = 0 Then pMdb_Cus_Prog_Rev.Cus_Prog_Rev_Id = db.DataTable("SELECT MAX(Cus_Prog_Rev_Id) AS Max_Cus_Prog_Rev_Id FROM Mdb_Cus_Prog_Rev WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Rev_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pData As cMdb_Cus_Prog_Rev, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Cus_Prog_Id") = pData.Cus_Prog_Id
            pdrRow.Item("Rev_No") = pData.Rev_No
            pdrRow.Item("Rev_State") = pData.Rev_State
            pdrRow.Item("Program") = pData.Program
            pdrRow.Item("Imprint") = pData.Imprint
            pdrRow.Item("Prog_CSR") = pData.Prog_CSR
            If pData.Start_Dt.Year <> 1 Then pdrRow.Item("Start_Dt") = pData.Start_Dt
            If pData.Start_Dt.Year <> 1 Then pdrRow.Item("End_Dt") = pData.End_Dt
            pdrRow.Item("Cicntp_ID") = pData.Cicntp_ID

            If pData.Cus_Prog_Rev_ID = 0 Then

                pData.Create_Ts = Date.Now
                pdrRow.Item("Create_Ts") = pData.Create_Ts

            End If

            pData.User_Login = Environment.UserName
            pData.Update_Ts = Date.Now

            pdrRow.Item("User_Login") = pData.User_Login
            pdrRow.Item("Update_Ts") = pData.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    'Ion 15.10.14   Delete element with CUS_PROG_ID from database
    Public Sub Delete(ByRef pId As cMdb_Cus_Prog)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim pData As New cMdb_Cus_Prog_Rev
            Dim strSql As String

            strSql = _
            "SELECT * FROM Mdb_Cus_Prog_Rev " & _
            "WHERE  Cus_Prog_Id = " & pId.Cus_Prog_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                pData.Cus_Prog_Rev_ID = dt.Rows(0).Item("Cus_Prog_Rev_Id").ToString
                Delete(pData.Cus_Prog_Rev_ID)
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "DELETE FROM Mdb_Cus_Prog_Rev " & _
            "WHERE  Cus_Prog_Rev_Id = " & pId & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Get_Rev_No(ByVal pProg As cMdb_Cus_Prog) As Integer

        Get_Rev_No = 0

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT ISNULL(MAX(Rev_No), 0) AS Max_Rev_No " & _
            "FROM   Mdb_Cus_Prog_Rev WITH (Nolock) " & _
            "WHERE  Cus_Prog_Rev_Id = " & pProg.Cus_Prog_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Get_Rev_No = dt.Rows(0).Item("Max_Rev_No")
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class


