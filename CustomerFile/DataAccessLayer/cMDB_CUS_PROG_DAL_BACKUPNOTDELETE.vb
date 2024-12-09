Imports System.Data.Odbc

Public Class cMDB_CUS_PROG_DAL_BACKUPNOTDELETE

    'Public Function Insert(pMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean

    '    Insert = False

    '    Try

    '        Dim oDB As New cDBANTier("DSN=TRAVELER;")

    '        Dim parameters As OdbcParameter() = New OdbcParameter() { _
    '        New OdbcParameter("@Cus_No", pMdb_Cus_Prog.Cus_No), _
    '        New OdbcParameter("@Prog_Cd", pMdb_Cus_Prog.Prog_Cd), _
    '        New OdbcParameter("@Prog_Type", pMdb_Cus_Prog.Prog_Type), _
    '        New OdbcParameter("@Start_Dt", pMdb_Cus_Prog.Start_Dt.Date), _
    '        New OdbcParameter("@End_Dt", pMdb_Cus_Prog.End_Dt.Date), _
    '        New OdbcParameter("@Prog_Infinite", pMdb_Cus_Prog.Prog_Infinite), _
    '        New OdbcParameter("@Renew_To_Cus_Prog_Id", pMdb_Cus_Prog.Renew_To_Cus_Prog_Id), _
    '        New OdbcParameter("@Approved_By_Us", pMdb_Cus_Prog.Approved_By_Us), _
    '        New OdbcParameter("@Approved_By_Them", pMdb_Cus_Prog.Approved_By_Them), _
    '        New OdbcParameter("@Approved_Dt", pMdb_Cus_Prog.Approved_Dt.Date), _
    '        New OdbcParameter("@Eqp_Level", pMdb_Cus_Prog.Eqp_Level), _
    '        New OdbcParameter("@Eqp_Column", pMdb_Cus_Prog.Eqp_Column), _
    '        New OdbcParameter("@Eqp_Pct", pMdb_Cus_Prog.Eqp_Pct), _
    '        New OdbcParameter("@User_Login", pMdb_Cus_Prog.User_Login), _
    '        New OdbcParameter("@Update_Ts", pMdb_Cus_Prog.Update_Ts), _
    '        New OdbcParameter("@New_ID", 0)}

    '        '' OLD CODE
    '        'Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_SPInsert", CommandType.StoredProcedure, parameters)
    '        '' END OLD CODE

    '        'NEW CODE
    '        parameters(15).Direction = ParameterDirection.Output

    '        Dim oResult As Boolean
    '        oResult = oDB.ExecuteNonQuery("{CALL Mdb_Cus_Prog_SPInsert (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}", CommandType.StoredProcedure, parameters)

    '        pMdb_Cus_Prog.Cus_Prog_Id = parameters("@NEW_ID").Value.ToString()
    '        Debug.Print(pMdb_Cus_Prog.Cus_Prog_Id.ToString())

    '        oDB = Nothing

    '        Insert = True

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    'Public Function Insert1(pMdb_Cfg_Param As cMdb_Cfg_Param) As Boolean

    '    Dim blnResult As Boolean = False

    '    Try

    '        Using oDB As New cDBA("DSN=TRAVELER")

    '            'oDB.Command("Mdb_Cfg_Param_Insert")
    '            oDB.Command("{CALL Mdb_Cfg_Param_Insert (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}")
    '            '{call Mdb_Cfg_Param_Insert (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}
    '            'oDB.DBCommand.CommandText = "Mdb_Cfg_Param_Insert"

    '            oDB.DBCommand.CommandType = CommandType.StoredProcedure

    '            'oDB.DBCommand.Parameters.AddWithValue("@Param_Field", pMdb_Cfg_Param.Param_Field)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Param_Label", pMdb_Cfg_Param.Param_Label)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Param_Value_Type", pMdb_Cfg_Param.Param_Value_Type)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Is_Indexable", pMdb_Cfg_Param.Is_Indexable)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Allow_Param_Values_Only", pMdb_Cfg_Param.Allow_Param_Values_Only)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Web_Dest_Table", pMdb_Cfg_Param.Web_Dest_Table)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Web_Dest_Field", pMdb_Cfg_Param.Web_Dest_Field)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Is_Mandatory", pMdb_Cfg_Param.Is_Mandatory)
    '            'oDB.DBCommand.Parameters.AddWithValue("@User_Login", pMdb_Cfg_Param.User_Login)
    '            'oDB.DBCommand.Parameters.AddWithValue("@Update_Ts", pMdb_Cfg_Param.Update_Ts)

    '            Dim oParameters As OdbcParameter() = New OdbcParameter() { _
    '            New OdbcParameter("@Param_Field", pMdb_Cfg_Param.Param_Field.ToString), _
    '            New OdbcParameter("@Param_Label", pMdb_Cfg_Param.Param_Label.ToString), _
    '            New OdbcParameter("@Param_Value_Type", pMdb_Cfg_Param.Param_Value_Type.ToString), _
    '            New OdbcParameter("@Is_Indexable", pMdb_Cfg_Param.Is_Indexable), _
    '            New OdbcParameter("@Allow_Param_Values_Only", pMdb_Cfg_Param.Allow_Param_Values_Only), _
    '            New OdbcParameter("@Web_Dest_Table", pMdb_Cfg_Param.Web_Dest_Table), _
    '            New OdbcParameter("@Web_Dest_Field", pMdb_Cfg_Param.Web_Dest_Field), _
    '            New OdbcParameter("@Is_Mandatory", pMdb_Cfg_Param.Is_Mandatory), _
    '            New OdbcParameter("@User_Login", pMdb_Cfg_Param.User_Login), _
    '            New OdbcParameter("@Update_Ts", pMdb_Cfg_Param.Update_Ts.Date), _
    '            New OdbcParameter("@New_ID", 0)}

    '            oParameters(10).Direction = ParameterDirection.Output

    '            oDB.DBCommand.Parameters.AddRange(oParameters)

    '            oDB.DBCommand.Connection.Open()
    '            oDB.Execute(oDB.DBCommand)

    '            'a1 = cDBA.ExecuteNonQuery("Mdb_Cfg_Param_Insert", CommandType.StoredProcedure, oParameters)

    '            oDB.DBCommand.Connection.Close()

    '            pMdb_Cfg_Param.Param_Id = oDB.DBCommand.Parameters("@NEW_ID").Value.ToString()
    '            Debug.Print(pMdb_Cfg_Param.Param_Id.ToString())

    '            blnResult = True

    '        End Using

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cfg_Param." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    '    Return blnResult

    'End Function

    'Public Function Update(pMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean

    '    Update = False

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() { _
    '        New OdbcParameter("@Cus_Prog_Id", pMdb_Cus_Prog.Cus_Prog_Id), _
    '        New OdbcParameter("@Cus_No", pMdb_Cus_Prog.Cus_No), _
    '        New OdbcParameter("@Prog_Cd", pMdb_Cus_Prog.Prog_Cd), _
    '        New OdbcParameter("@Prog_Type", pMdb_Cus_Prog.Prog_Type), _
    '        New OdbcParameter("@Start_Dt", pMdb_Cus_Prog.Start_Dt), _
    '        New OdbcParameter("@End_Dt", pMdb_Cus_Prog.End_Dt), _
    '        New OdbcParameter("@Prog_Infinite", pMdb_Cus_Prog.Prog_Infinite), _
    '        New OdbcParameter("@Renew_To_Cus_Prog_Id", pMdb_Cus_Prog.Renew_To_Cus_Prog_Id), _
    '        New OdbcParameter("@Approved_By_Us", pMdb_Cus_Prog.Approved_By_Us), _
    '        New OdbcParameter("@Approved_By_Them", pMdb_Cus_Prog.Approved_By_Them), _
    '        New OdbcParameter("@Approved_Dt", pMdb_Cus_Prog.Approved_Dt), _
    '        New OdbcParameter("@Eqp_Level", pMdb_Cus_Prog.Eqp_Level), _
    '        New OdbcParameter("@Eqp_Column", pMdb_Cus_Prog.Eqp_Column), _
    '        New OdbcParameter("@Eqp_Pct", pMdb_Cus_Prog.Eqp_Pct), _
    '        New OdbcParameter("@User_Login", pMdb_Cus_Prog.User_Login), _
    '        New OdbcParameter("@Update_Ts", pMdb_Cus_Prog.Update_Ts)}

    '        Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_SPUpdate", CommandType.StoredProcedure, parameters)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function


    'Public Function Delete(pm_intCus_Prog_Id As Integer) As Boolean

    '    Delete = False

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Prog_Id", pm_intCus_Prog_Id)}

    '        Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_SPDelete", CommandType.StoredProcedure, parameters)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    'Public Function GetItem(pm_intCus_Prog_Id As Integer) As cMdb_Cus_Prog

    '    GetItem = Nothing

    '    Try

    '        Dim oMdb_Cus_Prog As cMdb_Cus_Prog = Nothing

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Prog_Id", pm_intCus_Prog_Id)}

    '        'Lets get the list of all Mdb_Cus_Prog in a datataable
    '        '{CALL Mdb_Cus_Prog_SPInsert (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}
    '        'Using table As DataTable = oDB.ExecuteParamerizedSelectCommand("Mdb_Cus_Prog_SPGetItem", CommandType.StoredProcedure, parameters)

    '        Using table As DataTable = oDB.ExecuteParamerizedSelectCommand("{CALL Mdb_Cus_Prog_SPGetItem (?)}", CommandType.StoredProcedure, parameters)

    '            'check if any record exist or not
    '            If table.Rows.Count = 1 Then

    '                LoadItem(oMdb_Cus_Prog, table.Rows(0))

    '            End If

    '        End Using

    '        Return oMdb_Cus_Prog

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    'Public Function GetItem(pCus_Prog_Cd As String) As cMdb_Cus_Prog

    '    GetItem = Nothing

    '    Try

    '        Dim oMdb_Cus_Prog As cMdb_Cus_Prog = Nothing
    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim strSql As String = _
    '        "SELECT * FROM Mdb_Cus_Prog WHERE Cus_Prog_Cd = '" & pCus_Prog_Cd & "' "

    '        'Lets get the list of all Mdb_Cus_Prog in a datataable
    '        Using table As DataTable = oDB.ExecuteSelectCommand(strSql, CommandType.Text)

    '            'check if any record exist or not
    '            If table.Rows.Count = 1 Then
    '                LoadItem(oMdb_Cus_Prog, table.Rows(0))
    '            End If

    '        End Using

    '        Return oMdb_Cus_Prog

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    'Private Sub LoadItem(ByRef oItem As cMdb_Cus_Prog, ByRef row As DataRow)

    '    Try

    '        With oItem

    '            'Now lets populate the details into the list of Mdb_Cus_Prog
    '            .Cus_Prog_Id = Convert.ToInt32(row("Cus_Prog_Id"))
    '            .Cus_No = row("Cus_No").ToString()
    '            .Prog_Cd = row("Prog_Cd").ToString()
    '            .Prog_Type = Convert.ToInt32(row("Prog_Type"))
    '            .Start_Dt = Convert.ToDateTime(row("Start_Dt"))
    '            .End_Dt = Convert.ToDateTime(row("End_Dt"))
    '            .Prog_Infinite = Convert.ToBoolean(row("Prog_Infinite"))
    '            .Renew_To_Cus_Prog_Id = Convert.ToInt32(row("Renew_To_Cus_Prog_Id"))
    '            .Approved_By_Us = row("Approved_By_Us").ToString()
    '            .Approved_By_Them = row("Approved_By_Them").ToString()
    '            .Approved_Dt = Convert.ToDateTime(row("Approved_Dt"))
    '            .Eqp_Level = Convert.ToInt32(row("Eqp_Level"))
    '            .Eqp_Column = Convert.ToInt32(row("Eqp_Column"))
    '            .Eqp_Pct = Convert.ToDecimal(row("Eqp_Pct"))
    '            .User_Login = row("User_Login").ToString()
    '            .Update_Ts = Convert.ToDateTime(row("Update_Ts"))

    '        End With

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub

    'Public Function GetList() As List(Of cMdb_Cus_Prog)

    '    GetList = Nothing

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim oMdb_Cus_Prog_list As List(Of cMdb_Cus_Prog) = Nothing

    '        'Lets get the list of all Mdb_Cus_Prog in a datataable
    '        Using table As DataTable = oDB.ExecuteSelectCommand("SELECT * FROM Mdb_Cus_Prog ", CommandType.Text)

    '            'check if any record exist or not
    '            If table.Rows.Count > 0 Then

    '                'Lets go ahead and create the list of employees
    '                oMdb_Cus_Prog_list = New List(Of cMdb_Cus_Prog)()

    '                'Now lets populate the employee details into the list of employees
    '                For Each row As DataRow In table.Rows

    '                    Dim oMdb_Cus_Prog As New cMdb_Cus_Prog()
    '                    LoadItem(oMdb_Cus_Prog, table.Rows(0))

    '                    oMdb_Cus_Prog_list.Add(oMdb_Cus_Prog)

    '                Next

    '            End If

    '        End Using

    '        Return oMdb_Cus_Prog_list

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

    Private Function Load(ByVal pintID As Integer) As cMdb_Cus_Prog

        Load = New cMdb_Cus_Prog()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog WITH (Nolock) " & _
            "WHERE  Cus_Prog_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            LoadLine(Load, dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Cus_Prog, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Prog_Id").Equals(DBNull.Value)) Then .Cus_Prog_Id = pdrRow.Item("Cus_Prog_Id")
                If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then .Cus_No = pdrRow.Item("Cus_No").ToString
                If Not (pdrRow.Item("Prog_Cd").Equals(DBNull.Value)) Then .Prog_Cd = pdrRow.Item("Prog_Cd").ToString
                If Not (pdrRow.Item("Prog_Type").Equals(DBNull.Value)) Then .Prog_Type = pdrRow.Item("Prog_Type")
                'If Not (pdrRow.Item("Start_Dt").Equals(DBNull.Value)) Then .Start_Dt = pdrRow.Item("Start_Dt")
                'If Not (pdrRow.Item("End_Dt").Equals(DBNull.Value)) Then .End_Dt = pdrRow.Item("End_Dt")
                If Not (pdrRow.Item("No_End_Date").Equals(DBNull.Value)) Then .No_End_Date = pdrRow.Item("No_End_Date")
                If Not (pdrRow.Item("Renew_To_Cus_Prog_Id").Equals(DBNull.Value)) Then .Renew_To_Cus_Prog_Id = pdrRow.Item("Renew_To_Cus_Prog_Id")
                If Not (pdrRow.Item("Approved_By_Us").Equals(DBNull.Value)) Then .Approved_By_Us = pdrRow.Item("Approved_By_Us").ToString
                If Not (pdrRow.Item("Approved_By_Them").Equals(DBNull.Value)) Then .Approved_By_Them = pdrRow.Item("Approved_By_Them").ToString
                If Not (pdrRow.Item("Approved_Dt").Equals(DBNull.Value)) Then .Approved_Dt = pdrRow.Item("Approved_Dt")
                If Not (pdrRow.Item("Eqp_Level").Equals(DBNull.Value)) Then .Eqp_Level = pdrRow.Item("Eqp_Level")
                If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then .Eqp_Column = pdrRow.Item("Eqp_Column")
                If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then .Eqp_Pct = pdrRow.Item("Eqp_Pct")
                If Not (pdrRow.Item("Prog_Comments").Equals(DBNull.Value)) Then .Prog_Comments = pdrRow.Item("Prog_Comments").ToString
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Save(pMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean

        Save = False

        Try

            Dim db As New cDBA
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

            pdrRow.Item("Cus_Prog_Id") = pCus_Prog.Cus_Prog_Id
            pdrRow.Item("Cus_No") = pCus_Prog.Cus_No
            pdrRow.Item("Prog_Cd") = pCus_Prog.Prog_Cd
            pdrRow.Item("Prog_Type") = pCus_Prog.Prog_Type
            'If pCus_Prog.Start_Dt.Year <> 1 Then pdrRow.Item("Start_Dt") = pCus_Prog.Start_Dt.Date
            'If pCus_Prog.End_Dt.Year <> 1 Then pdrRow.Item("End_Dt") = pCus_Prog.End_Dt.Date
            pdrRow.Item("No_End_Date") = pCus_Prog.No_End_Date
            pdrRow.Item("Renew_To_Cus_Prog_Id") = pCus_Prog.Renew_To_Cus_Prog_Id
            pdrRow.Item("Approved_By_Us") = pCus_Prog.Approved_By_Us
            pdrRow.Item("Approved_By_Them") = pCus_Prog.Approved_By_Them
            If pCus_Prog.Approved_Dt.Year <> 1 Then pdrRow.Item("Approved_Dt") = pCus_Prog.Approved_Dt.Date
            pdrRow.Item("Eqp_Level") = pCus_Prog.Eqp_Level
            pdrRow.Item("Eqp_Column") = pCus_Prog.Eqp_Column
            pdrRow.Item("Eqp_Pct") = pCus_Prog.Eqp_Pct
            pdrRow.Item("Prog_Comments") = pCus_Prog.Prog_Comments
            pdrRow.Item("User_Login") = Environment.UserName
            pdrRow.Item("Update_Ts") = Date.Now

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(pm_intCus_Prog_Id As Integer)

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Prog " & _
            "WHERE  Cus_Prog_Id = " & pm_intCus_Prog_Id & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class
