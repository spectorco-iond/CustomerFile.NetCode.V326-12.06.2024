Imports System.Data.Odbc

Public Class cMdb_Cus_Prog_Supp_Item_DAL

    Public Function Insert(pMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean

        Insert = False

        Try

            Dim oDB As New cDBA("DSN=TRAVELER;")
            Dim parameters As OdbcParameter() = New OdbcParameter() { _
            New OdbcParameter("@Cus_Prog_Item_List_Id", pMdb_Cus_Prog_Supp_Item.Cus_Prog_Item_List_Id), _
            New OdbcParameter("@Item_No", pMdb_Cus_Prog_Supp_Item.Item_No), _
            New OdbcParameter("@Item_Type", pMdb_Cus_Prog_Supp_Item.Item_Type), _
            New OdbcParameter("@Price_Included", pMdb_Cus_Prog_Supp_Item.Price_Included), _
            New OdbcParameter("@Unit_Price", pMdb_Cus_Prog_Supp_Item.Unit_Price), _
            New OdbcParameter("@User_Login", Environment.UserName), _
            New OdbcParameter("@Update_Ts", pMdb_Cus_Prog_Supp_Item.Update_Ts)}

            Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_Supp_Item_SPInsert", CommandType.StoredProcedure, parameters)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Supp_Item." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Public Function Update(pMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean

        Update = False

        Try

            Dim oDB As New cDBA("DSN=TRAVELER;")
            Dim parameters As OdbcParameter() = New OdbcParameter() { _
            New OdbcParameter("@Cus_Prog_Supp_Item_Id", pMdb_Cus_Prog_Supp_Item.Cus_Prog_Supp_Item_Id), _
            New OdbcParameter("@Cus_Prog_Item_List_Id", pMdb_Cus_Prog_Supp_Item.Cus_Prog_Item_List_Id), _
            New OdbcParameter("@Item_No", pMdb_Cus_Prog_Supp_Item.Item_No), _
            New OdbcParameter("@Item_Type", pMdb_Cus_Prog_Supp_Item.Item_Type), _
            New OdbcParameter("@Price_Included", pMdb_Cus_Prog_Supp_Item.Price_Included), _
            New OdbcParameter("@Unit_Price", pMdb_Cus_Prog_Supp_Item.Unit_Price), _
            New OdbcParameter("@User_Login", pMdb_Cus_Prog_Supp_Item.User_Login), _
            New OdbcParameter("@Update_Ts", pMdb_Cus_Prog_Supp_Item.Update_Ts)}

            Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_Supp_Item_SPUpdate", CommandType.StoredProcedure, parameters)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Supp_Item." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Public Function Delete(pm_intCus_Prog_Supp_Item_Id As Integer) As Boolean

        Delete = False

        Try

            Dim oDB As New cDBA("DSN=TRAVELER;")
            Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Prog_Supp_Item_Id", pm_intCus_Prog_Supp_Item_Id)}

            Return oDB.ExecuteNonQuery("Mdb_Cus_Prog_Supp_Item_SPDelete", CommandType.StoredProcedure, parameters)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Supp_Item." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Public Function GetItem(pm_intCus_Prog_Supp_Item_Id As Integer) As cMdb_Cus_Prog_Supp_Item

        GetItem = Nothing

        Try

            Dim oDB As New cDBA("DSN=TRAVELER;")
            Dim oMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item = Nothing
            Dim parameters As OdbcParameter() = New OdbcParameter() {New OdbcParameter("@Cus_Prog_Supp_Item_Id", pm_intCus_Prog_Supp_Item_Id)}

            'Lets get the list of all Mdb_Cus_Prog_Supp_Item in a datataable
            Using table As DataTable = oDB.ExecuteParamerizedSelectCommand("Mdb_Cus_Prog_Supp_Item_SPGetItem", CommandType.StoredProcedure, parameters)

                'check if any record exist or not
                If table.Rows.Count = 1 Then
                    Dim row As DataRow = table.Rows(0)

                    'Lets go ahead and create the list of Mdb_Cus_Prog_Supp_Item
                    oMdb_Cus_Prog_Supp_Item = New cMdb_Cus_Prog_Supp_Item()

                    'Now lets populate the employee details into the list of Mdb_Cus_Prog_Supp_Item
                    oMdb_Cus_Prog_Supp_Item.Cus_Prog_Supp_Item_Id = Convert.ToInt32(row("Cus_Prog_Supp_Item_Id"))
                    oMdb_Cus_Prog_Supp_Item.Cus_Prog_Item_List_Id = Convert.ToInt32(row("Cus_Prog_Item_List_Id"))
                    oMdb_Cus_Prog_Supp_Item.Item_No = row("Item_No").ToString()
                    oMdb_Cus_Prog_Supp_Item.Item_Type = Convert.ToInt32(row("Item_Type"))
                    oMdb_Cus_Prog_Supp_Item.Price_Included = Convert.ToBoolean(row("Price_Included"))
                    oMdb_Cus_Prog_Supp_Item.Unit_Price = Convert.ToDecimal(row("Unit_Price"))
                    oMdb_Cus_Prog_Supp_Item.User_Login = row("User_Login").ToString()
                    oMdb_Cus_Prog_Supp_Item.Update_Ts = Convert.ToDateTime(row("Update_Ts"))
                End If

            End Using

            Return oMdb_Cus_Prog_Supp_Item

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Supp_Item." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Public Function GetList() As List(Of cMdb_Cus_Prog_Supp_Item)

        GetList = Nothing

        Try

            Dim oDB As New cDBA("DSN=TRAVELER;")
            Dim oMdb_Cus_Prog_Supp_Item_list As List(Of cMdb_Cus_Prog_Supp_Item) = Nothing

            'Lets get the list of all Mdb_Cus_Prog_Supp_Item in a datataable
            Using table As DataTable = oDB.ExecuteSelectCommand("SELECT * FROM Mdb_Cus_Prog_Supp_Item ", CommandType.Text)

                'check if any record exist or not
                If table.Rows.Count > 0 Then

                    'Lets go ahead and create the list of employees
                    oMdb_Cus_Prog_Supp_Item_list = New List(Of cMdb_Cus_Prog_Supp_Item)()

                    'Now lets populate the employee details into the list of employees
                    For Each row As DataRow In table.Rows

                        Dim oMdb_Cus_Prog_Supp_Item As New cMdb_Cus_Prog_Supp_Item()
                        oMdb_Cus_Prog_Supp_Item.Cus_Prog_Supp_Item_Id = Convert.ToInt32(row("Cus_Prog_Supp_Item_Id"))
                        oMdb_Cus_Prog_Supp_Item.Cus_Prog_Item_List_Id = Convert.ToInt32(row("Cus_Prog_Item_List_Id"))
                        oMdb_Cus_Prog_Supp_Item.Item_No = row("Item_No").ToString()
                        oMdb_Cus_Prog_Supp_Item.Item_Type = Convert.ToInt32(row("Item_Type"))
                        oMdb_Cus_Prog_Supp_Item.Price_Included = Convert.ToBoolean(row("Price_Included"))
                        oMdb_Cus_Prog_Supp_Item.Unit_Price = Convert.ToDecimal(row("Unit_Price"))
                        oMdb_Cus_Prog_Supp_Item.User_Login = row("User_Login").ToString()
                        oMdb_Cus_Prog_Supp_Item.Update_Ts = Convert.ToDateTime(row("Update_Ts"))

                        oMdb_Cus_Prog_Supp_Item_list.Add(oMdb_Cus_Prog_Supp_Item)

                    Next

                End If

            End Using

            Return oMdb_Cus_Prog_Supp_Item_list

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Supp_Item." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


End Class ' cMdb_Cus_Prog_Supp_Item


