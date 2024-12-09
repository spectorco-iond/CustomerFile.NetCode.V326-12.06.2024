Imports System.Data.Odbc

Public Class cMdb_Customer_DAL

    Public Function Load(ByVal pintID As Integer) As cMdb_Customer

        Load = New cMdb_Customer()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Customer WITH (Nolock) " & _
            "WHERE  Cus_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Load(ByVal pCus_No As String) As cMdb_Customer

        Load = New cMdb_Customer()

        Try
            Load.Cus_No = pCus_No

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Customer WITH (Nolock) " & _
            "WHERE  Cus_No = '" & pCus_No & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function LoadCustomersFromGroup(ByRef pCustomer As cMdb_Customer) As Collection

        LoadCustomersFromGroup = New Collection

        Try
            Dim oCicmpy As New cCustomer(pCustomer.Cus_No)

            Dim db As New cDBA
            Dim dt As DataTable

            Dim oCustomer_B As New cMdb_Customer_BUS
            Dim oCustomer As cMdb_Customer

            Dim strSql As String = _
            "SELECT * " & _
            "FROM   CICMPY WITH (Nolock) " & _
            "WHERE  TextField3 = '" & oCicmpy.textfield3 & "' AND " & _
            "       Cmp_Code <> '" & pCustomer.Cus_No & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then

                For Each drRow As DataRow In dt.Rows

                    oCustomer = oCustomer_B.Load(drRow.Item("Cmp_Code").ToString)
                    LoadCustomersFromGroup.Add(oCustomer, oCustomer.Cus_No)

                Next

            End If

        Catch er As Exception
            MsgBox("Error in COrdhead." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Private Sub LoadLine(ByRef pLoad As cMdb_Customer, ByRef pdrRow As DataRow)

        Try

            With (pLoad)

                If Not (pdrRow.Item("Cus_Id").Equals(DBNull.Value)) Then .Cus_Id = pdrRow.Item("Cus_Id")
                If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then .Cus_No = pdrRow.Item("Cus_No").ToString
                If Not (pdrRow.Item("Cus_Dec_Count").Equals(DBNull.Value)) Then .Cus_Dec_Count = pdrRow.Item("Cus_Dec_Count")
                If Not (pdrRow.Item("Edi_Cus_Name").Equals(DBNull.Value)) Then .Edi_Cus_Name = pdrRow.Item("Edi_Cus_Name").ToString
                If Not (pdrRow.Item("Pick_Sensitivity").Equals(DBNull.Value)) Then .Pick_Sensitivity = pdrRow.Item("Pick_Sensitivity")
                If Not (pdrRow.Item("Star_Level").Equals(DBNull.Value)) Then .Star_Level = pdrRow.Item("Star_Level")
                If Not (pdrRow.Item("Eqp_Status").Equals(DBNull.Value)) Then .Eqp_Status = pdrRow.Item("Eqp_Status")
                If Not (pdrRow.Item("Eqp_Column").Equals(DBNull.Value)) Then .Eqp_Column = pdrRow.Item("Eqp_Column")
                If Not (pdrRow.Item("Eqp_Pct").Equals(DBNull.Value)) Then .Eqp_Pct = pdrRow.Item("Eqp_Pct")
                If Not (pdrRow.Item("Eqp_Trial").Equals(DBNull.Value)) Then .Eqp_Trial = pdrRow.Item("Eqp_Trial")
                If Not (pdrRow.Item("Group_Member").Equals(DBNull.Value)) Then .Group_Member = pdrRow.Item("Group_Member").ToString
                If Not (pdrRow.Item("All_Star_Traveler").Equals(DBNull.Value)) Then .All_Star_Traveler = pdrRow.Item("All_Star_Traveler")
                If Not (pdrRow.Item("White_Glove_End_Date").Equals(DBNull.Value)) Then .White_Glove_End_Date = pdrRow.Item("White_Glove_End_Date")
                If Not (pdrRow.Item("White_Glove_Order_Count").Equals(DBNull.Value)) Then .White_Glove_Order_Count = pdrRow.Item("White_Glove_Order_Count")
                If Not (pdrRow.Item("Coop_Pricing").Equals(DBNull.Value)) Then .Coop_Pricing = pdrRow.Item("Coop_Pricing")
                If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then .User_Login = pdrRow.Item("User_Login").ToString
                If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then .Update_Ts = pdrRow.Item("Update_Ts")
                'we must populate during 3 month 
                'it must declare one public variable
                .CountRMA_3Month = CountFunRMA_3Month(.Cus_No)

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function CountFunRMA_3Month(ByVal pCus_No As String) As Integer
        CountFunRMA_3Month = 0
        Try
            Dim strSql As String
            Dim db As New cDBA
            Dim dt As DataTable


            strSql = _
                " SELECT distinct hdf.rma_no " & _
                " FROM dbo.oerhdfil_sql hdf INNER JOIN dbo.oerdtfil_sql dtf " & _
                " ON hdf.rma_no = dtf.rma_no AND hdf.cus_no = dtf.oe_cus_no " & _
                " where cus_no = '" & pCus_No & "' and rma_dt_entered >= DATEADD(MONTH, -3, GETDATE()) order by hdf.rma_no asc "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                CountFunRMA_3Month = dt.Rows.Count
            End If


        Catch ex As Exception
            MsgBox("Error in cMdb_Customer_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function Save(ByVal pMdb_Customer As cMdb_Customer) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Customer " & _
            "WHERE  Cus_Id = " & pMdb_Customer.Cus_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pMdb_Customer, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

            If pMdb_Customer.Cus_Id = 0 Then pMdb_Customer.Cus_Id = db.DataTable("SELECT MAX(Cus_Id) AS Max_Cus_Id FROM Mdb_Customer WITH (Nolock)").Rows(0).Item("Max_Cus_Id")

            Save = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub SaveLine(ByRef pData As cMdb_Customer, ByRef pdrRow As DataRow)

        Try

            'Private m_intCus_Id As Int32
            'Private m_strCus_No As String
            'Private m_intCus_Dec_Count As Int32
            'Private m_strEdi_Cus_Name As String
            'Private m_intPick_Sensitivity As Int32
            'Private m_intStar_Level As Int32
            'Private m_blnEqp_Status As Boolean
            'Private m_intEqp_Column As Int32
            'Private m_decEqp_Pct As Decimal
            'Private m_blnEqp_Trial As Boolean
            'Private m_strGroup_Member As String
            'Private m_blnAll_Star_Traveler As Boolean
            'Private m_dtWhite_Glove_End_Date As DateTime
            'Private m_intWhite_Glove_Order_Count As Integer
            'Private m_blnCoop_Pricing As Boolean

            'pdrRow.Item("Cus_Id") = pData.Cus_Id
            pdrRow.Item("Cus_No") = pData.Cus_No
            pdrRow.Item("Cus_Dec_Count") = pData.Cus_Dec_Count
            pdrRow.Item("Edi_Cus_Name") = pData.Edi_Cus_Name
            pdrRow.Item("Pick_Sensitivity") = pData.Pick_Sensitivity
            pdrRow.Item("Star_Level") = pData.Star_Level
            pdrRow.Item("Eqp_Status") = pData.Eqp_Status
            pdrRow.Item("Eqp_Column") = pData.Eqp_Column
            pdrRow.Item("Eqp_Pct") = pData.Eqp_Pct
            pdrRow.Item("Eqp_Trial") = pData.Eqp_Trial
            pdrRow.Item("Group_Member") = pData.Group_Member
            pdrRow.Item("All_Star_Traveler") = pData.All_Star_Traveler
            pdrRow.Item("White_Glove_End_Date") = IIf(pData.White_Glove_End_Date.Equals(NoDate()), DBNull.Value, pData.White_Glove_End_Date)
            pdrRow.Item("White_Glove_Order_Count") = pData.White_Glove_Order_Count
            pdrRow.Item("Coop_Pricing") = pData.Coop_Pricing

            If pData.Cus_Id = 0 Then

                pData.Create_Ts = Date.Now
                pdrRow.Item("Create_Ts") = pData.Create_Ts

            End If

            pData.User_Login = Environment.UserName
            pdrRow.Item("User_Login") = pData.User_Login

            pData.Update_Ts = Date.Now
            pdrRow.Item("Update_Ts") = pData.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current Comment from the database, if it exists.
    Public Function Delete(ByVal pId As Integer)

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Customer " & _
            "WHERE  Cus_Id = " & pId & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    'Public Function Insert(pMdb_Customer As cMdb_Customer) As Boolean

    '    Insert = False

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() { _
    '        New OdbcParameter("@Cus_No", pMdb_Customer.Cus_No), _
    '        New OdbcParameter("@Cus_Dec_Count", pMdb_Customer.Cus_Dec_Count), _
    '        New OdbcParameter("@Edi_Cus_Name", pMdb_Customer.Edi_Cus_Name), _
    '        New OdbcParameter("@Pick_Sensitivity", pMdb_Customer.Pick_Sensitivity), _
    '        New OdbcParameter("@Star_Level", pMdb_Customer.Star_Level), _
    '        New OdbcParameter("@Eqp_Status", pMdb_Customer.Eqp_Status), _
    '        New OdbcParameter("@Eqp_Column", pMdb_Customer.Eqp_Column), _
    '        New OdbcParameter("@Eqp_Pct", pMdb_Customer.Eqp_Pct), _
    '        New OdbcParameter("@Eqp_Trial", pMdb_Customer.Eqp_Trial), _
    '        New OdbcParameter("@Group_Member", pMdb_Customer.Group_Member), _
    '        New OdbcParameter("@All_Star_Traveler", pMdb_Customer.All_Star_Traveler), _
    '        New OdbcParameter("@Coop_Pricing", pMdb_Customer.Coop_Pricing), _
    '        New OdbcParameter("@User_Login", Environment.UserName), _
    '        New OdbcParameter("@Update_Ts", pMdb_Customer.Update_Ts)}

    '        Return oDB.ExecuteNonQuery("Mdb_Customer_SPInsert", CommandType.StoredProcedure, parameters)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function


    'Public Function Update(pMdb_Customer As cMdb_Customer) As Boolean

    '    Update = False

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() { _
    '        New OdbcParameter("@Cus_Id", pMdb_Customer.Cus_Id), _
    '        New OdbcParameter("@Cus_No", pMdb_Customer.Cus_No), _
    '        New OdbcParameter("@Cus_Dec_Count", pMdb_Customer.Cus_Dec_Count), _
    '        New OdbcParameter("@Edi_Cus_Name", pMdb_Customer.Edi_Cus_Name), _
    '        New OdbcParameter("@Pick_Sensitivity", pMdb_Customer.Pick_Sensitivity), _
    '        New OdbcParameter("@Star_Level", pMdb_Customer.Star_Level), _
    '        New OdbcParameter("@Eqp_Status", pMdb_Customer.Eqp_Status), _
    '        New OdbcParameter("@Eqp_Column", pMdb_Customer.Eqp_Column), _
    '        New OdbcParameter("@Eqp_Pct", pMdb_Customer.Eqp_Pct), _
    '        New OdbcParameter("@Eqp_Trial", pMdb_Customer.Eqp_Trial), _
    '        New OdbcParameter("@Group_Member", pMdb_Customer.Group_Member), _
    '        New OdbcParameter("@All_Star_Traveler", pMdb_Customer.All_Star_Traveler), _
    '        New OdbcParameter("@Coop_Pricing", pMdb_Customer.Coop_Pricing), _
    '        New OdbcParameter("@User_Login", pMdb_Customer.User_Login), _
    '        New OdbcParameter("@Update_Ts", pMdb_Customer.Update_Ts)}

    '        Return oDB.ExecuteNonQuery("Mdb_Customer_SPUpdate", CommandType.StoredProcedure, parameters)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function


    'Public Function Delete(pm_intCus_Id As Integer) As Boolean

    '    Delete = False

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Id", pm_intCus_Id)}

    '        Return oDB.ExecuteNonQuery("Mdb_Customer_SPDelete", CommandType.StoredProcedure, parameters)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function


    'Public Function GetItem(pm_intCus_Id As Integer) As cMdb_Customer

    '    GetItem = Nothing

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim oMdb_Customer As cMdb_Customer = Nothing
    '        Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Id", pm_intCus_Id)}

    '        'Lets get the list of all Mdb_Customer in a datataable
    '        Using table As DataTable = oDB.ExecuteParamerizedSelectCommand("Mdb_Customer_SPGetItem", CommandType.StoredProcedure, parameters)

    '            'check if any record exist or not
    '            If table.Rows.Count = 1 Then
    '                Dim row As DataRow = table.Rows(0)

    '                'Lets go ahead and create the list of Mdb_Customer
    '                oMdb_Customer = New cMdb_Customer()

    '                'Now lets populate the employee details into the list of Mdb_Customer
    '                oMdb_Customer.Cus_Id = Convert.ToInt32(row("Cus_Id"))
    '                oMdb_Customer.Cus_No = row("Cus_No").ToString()
    '                oMdb_Customer.Cus_Dec_Count = Convert.ToInt32(row("Cus_Dec_Count"))
    '                oMdb_Customer.Edi_Cus_Name = row("Edi_Cus_Name").ToString()
    '                oMdb_Customer.Pick_Sensitivity = Convert.ToInt32(row("Pick_Sensitivity"))
    '                oMdb_Customer.Star_Level = Convert.ToInt32(row("Star_Level"))
    '                oMdb_Customer.Eqp_Status = Convert.ToBoolean(row("Eqp_Status"))
    '                oMdb_Customer.Eqp_Column = Convert.ToInt32(row("Eqp_Column"))
    '                oMdb_Customer.Eqp_Pct = Convert.ToDecimal(row("Eqp_Pct"))
    '                oMdb_Customer.Eqp_Trial = Convert.ToBoolean(row("Eqp_Trial"))
    '                oMdb_Customer.Group_Member = row("Group_Member").ToString()
    '                oMdb_Customer.All_Star_Traveler = Convert.ToBoolean(row("All_Star_Traveler"))
    '                oMdb_Customer.Coop_Pricing = Convert.ToBoolean(row("Coop_Pricing"))
    '                oMdb_Customer.User_Login = row("User_Login").ToString()
    '                oMdb_Customer.Update_Ts = Convert.ToDateTime(row("Update_Ts"))
    '            End If

    '        End Using

    '        Return oMdb_Customer

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function


    'Public Function GetList() As List(Of cMdb_Customer)

    '    GetList = Nothing

    '    Try

    '        Dim oDB As New cDBA("DSN=TRAVELER;")
    '        Dim oMdb_Customer_list As List(Of cMdb_Customer) = Nothing

    '        'Lets get the list of all Mdb_Customer in a datataable
    '        Using table As DataTable = oDB.ExecuteSelectCommand("SELECT * FROM Mdb_Customer ", CommandType.Text)

    '            'check if any record exist or not
    '            If table.Rows.Count > 0 Then

    '                'Lets go ahead and create the list of employees
    '                oMdb_Customer_list = New List(Of cMdb_Customer)()

    '                'Now lets populate the employee details into the list of employees
    '                For Each row As DataRow In table.Rows

    '                    Dim oMdb_Customer As New cMdb_Customer()
    '                    oMdb_Customer.Cus_Id = Convert.ToInt32(row("Cus_Id"))
    '                    oMdb_Customer.Cus_No = row("Cus_No").ToString()
    '                    oMdb_Customer.Cus_Dec_Count = Convert.ToInt32(row("Cus_Dec_Count"))
    '                    oMdb_Customer.Edi_Cus_Name = row("Edi_Cus_Name").ToString()
    '                    oMdb_Customer.Pick_Sensitivity = Convert.ToInt32(row("Pick_Sensitivity"))
    '                    oMdb_Customer.Star_Level = Convert.ToInt32(row("Star_Level"))
    '                    oMdb_Customer.Eqp_Status = Convert.ToBoolean(row("Eqp_Status"))
    '                    oMdb_Customer.Eqp_Column = Convert.ToInt32(row("Eqp_Column"))
    '                    oMdb_Customer.Eqp_Pct = Convert.ToDecimal(row("Eqp_Pct"))
    '                    oMdb_Customer.Eqp_Trial = Convert.ToBoolean(row("Eqp_Trial"))
    '                    oMdb_Customer.Group_Member = row("Group_Member").ToString()
    '                    oMdb_Customer.All_Star_Traveler = Convert.ToBoolean(row("All_Star_Traveler"))
    '                    oMdb_Customer.Coop_Pricing = Convert.ToBoolean(row("Coop_Pricing"))
    '                    oMdb_Customer.User_Login = row("User_Login").ToString()
    '                    oMdb_Customer.Update_Ts = Convert.ToDateTime(row("Update_Ts"))

    '                    oMdb_Customer_list.Add(oMdb_Customer)

    '                Next

    '            End If

    '        End Using

    '        Return oMdb_Customer_list

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Customer." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function



End Class ' cMdb_Customer


