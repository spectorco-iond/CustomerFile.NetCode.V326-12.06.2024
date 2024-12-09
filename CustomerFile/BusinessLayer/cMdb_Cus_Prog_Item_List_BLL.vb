Public Class cMdb_Cus_Prog_Item_List_BUS



    ' Handle to the Mdb_Cus_Prog_Item_List DBAccess class
    Private oMdb_Cus_Prog_Item_List_DA As cMdb_Cus_Prog_Item_List_DAL = Nothing

    Public Sub New()
        oMdb_Cus_Prog_Item_List_DA = New cMdb_Cus_Prog_Item_List_DAL()
    End Sub

    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Prog_Item_List_Id As Integer) As cMdb_Cus_Prog_Item_List
        Return oMdb_Cus_Prog_Item_List_DA.Load(piCus_Prog_Item_List_Id)
    End Function

    ' Insert current element in the database 
    Public Function Save(ByRef oMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean
        Return oMdb_Cus_Prog_Item_List_DA.Save(oMdb_Cus_Prog_Item_List)
    End Function

    ' Delete element with ID specified from the database 
    Public Function Delete(ByVal piCus_Prog_Item_List_Id As Integer) As Boolean
        Return oMdb_Cus_Prog_Item_List_DA.Delete(piCus_Prog_Item_List_Id)
    End Function

    '.DeleteMacolaProgramPricing("", 0)
    Public Function DeleteMacolaProgramPricing(ByVal pstrItem_Cd As String, ByVal piCus_Prog_Id As Integer) As Boolean
        Return oMdb_Cus_Prog_Item_List_DA.DeleteMacolaProgramPricing(pstrItem_Cd, piCus_Prog_Id)
    End Function

    Public Sub Init(ByRef oItem_List As cMdb_Cus_Prog_Item_List)

        Try
            With oItem_List

                .Cus_Prog_Id = 0
                .Cus_Prog_Item_List_Id = 0
                .Cus_Prog_Item_List_Guid = String.Empty
                .Eqp_Column = 0
                .Eqp_Level = 0
                .Eqp_Pct = 0
                .Prod_Cat_ID = 0
                .Item_Cd = String.Empty
                .Custom_Item_Id = 0
                .Item_No = String.Empty
                .Item_Desc = String.Empty
                .Item_Color = String.Empty
                .Min_Qty_Ord = 0
                .Unit_Price = 0
                .Setup_Waived = False
                .Setup_Price = 0
                .Run_Charge = Nothing ' 0.000001
                .Dec_Met_ID = 0
                .Dec_Met_Group_ID = 0
                .Color_Count = 1
                .Location_Count = 1
                .Quote_Type_ID = 0
                .Quote_Ship_Method_ID = 0
                .Pack_ID = 0
                .Pack_Qty_By_ID = 0
                .Pack_Comment = String.Empty
                '.Overseas = False
                '.Domestic = False
                .Refill_ID = 0
                .Refill_Color = String.Empty
                .Refill_Qty = 0
                .Update_Ts = NoDate()
                .User_Login = ""
                .ChargeId = 0

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Item_List_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Clone(ByRef oItem As cMdb_Cus_Prog_Item_List) As cMdb_Cus_Prog_Item_List

        ' Clones everything BUT the primary key
        Dim oClone As New cMdb_Cus_Prog_Item_List

        oClone.Cus_Prog_Item_List_Guid = oItem.Cus_Prog_Item_List_Guid
        oClone.Cus_Prog_Id = oItem.Cus_Prog_Id
        oClone.Prod_Cat_ID = oItem.Prod_Cat_ID
        oClone.Item_Cd = oItem.Item_Cd
        oClone.Custom_Item_Id = oItem.Custom_Item_Id
        oClone.Item_No = oItem.Item_No
        oClone.Item_Desc = oItem.Item_Desc
        oClone.Item_Color = oItem.Item_Color
        oClone.Eqp_Level = oItem.Eqp_Level
        oClone.Eqp_Column = oItem.Eqp_Column
        oClone.Eqp_Pct = oItem.Eqp_Pct
        oClone.Unit_Price = oItem.Unit_Price
        oClone.Min_Qty_Ord = oItem.Min_Qty_Ord
        oClone.Setup_Waived = oItem.Setup_Waived
        oClone.Setup_Price = oItem.Setup_Price
        oClone.Run_Charge = oItem.Run_Charge
        oClone.Dec_Met_ID = oItem.Dec_Met_ID
        oClone.Dec_Met_Group_ID = oItem.Dec_Met_Group_ID
        oClone.Color_Count = oItem.Color_Count
        oClone.Location_Count = oItem.Location_Count
        oClone.Quote_Type_ID = oItem.Quote_Type_ID
        oClone.Quote_Ship_Method_ID = oItem.Quote_Ship_Method_ID
        oClone.Pack_ID = oItem.Pack_ID
        oClone.Pack_Qty_By_ID = oItem.Pack_Qty_By_ID
        oClone.Pack_Comment = oItem.Pack_Comment
        'oClone.Overseas = oItem.Overseas
        'oClone.Domestic = oItem.Domestic
        oClone.Refill_ID = oItem.Refill_ID
        oClone.Refill_Color = oItem.Refill_Color
        oClone.Refill_Qty = oItem.Refill_Qty

        oClone.User_Login = Environment.UserName
        oClone.Create_Ts = Date.Now
        oClone.Update_Ts = Date.Now
        oClone.ChargeId = oItem.ChargeId

        Return oClone

    End Function


    '    ' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Cus_Prog_Item_List)
    '    Return oMdb_Cus_Prog_Item_List_DA.GetList()
    'End Function


    '    ' Update current element in the database 
    '    Public Function Update(oMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean
    '    Return oMdb_Cus_Prog_Item_List_DA.Update(oMdb_Cus_Prog_Item_List)
    '    End Function


    '    ' Get element with ID specified from the database 
    'Public Function GetItem(piCus_Prog_Item_List_Id As Integer) As cMdb_Cus_Prog_Item_List
    '    Return oMdb_Cus_Prog_Item_List_DA.GetItem(piCus_Prog_Item_List_Id)
    'End Function


    '    ' Delete element with ID specified from the database 
    '    Public Function Delete(piCus_Prog_Item_List_Id As Integer) As Boolean
    '    Return oMdb_Cus_Prog_Item_List_DA.Delete(piCus_Prog_Item_List_Id)
    '    End Function


    '    ' Insert current element in the database 
    '    Public Function Insert(oMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean
    '    Return oMdb_Cus_Prog_Item_List_DA.Insert(oMdb_Cus_Prog_Item_List)
    '    End Function


    ' Validate current element 
    Public Function Validate(ByVal oMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean
        Return True

    End Function


    '' Validate current element 
    'Public Function Validate(oMdb_Cus_Prog_Item_List As cMdb_Cus_Prog_Item_List) As Boolean

    'End Function

End Class ' cMdb_Cus_Prog_Item_List


