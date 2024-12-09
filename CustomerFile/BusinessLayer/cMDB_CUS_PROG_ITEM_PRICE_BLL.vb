Public Class cMDB_CUS_PROG_ITEM_PRICE_BLL



    ' Handle to the MDB_CUS_PROG_ITEM_PRICE DBAccess class
    Private oMDB_CUS_PROG_ITEM_PRICE_DA As cMDB_CUS_PROG_ITEM_PRICE_DAL = Nothing

    Public Sub New()
        oMDB_CUS_PROG_ITEM_PRICE_DA = New cMDB_CUS_PROG_ITEM_PRICE_DAL()
    End Sub

    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Prog_Item_Price_Id As Integer) As cMDB_CUS_PROG_ITEM_PRICE
        Return oMDB_CUS_PROG_ITEM_PRICE_DA.Load(piCus_Prog_Item_Price_Id)
    End Function

    ' Insert current element in the database 
    Public Function Save(ByRef oMDB_CUS_PROG_ITEM_PRICE As cMDB_CUS_PROG_ITEM_PRICE) As Boolean
        Return oMDB_CUS_PROG_ITEM_PRICE_DA.Save(oMDB_CUS_PROG_ITEM_PRICE)
    End Function

    ' Delete element with ID specified from the database 
    Public Function Delete(ByVal piCus_Prog_Item_Price_Id As Integer) As Boolean
        Return oMDB_CUS_PROG_ITEM_PRICE_DA.Delete(piCus_Prog_Item_Price_Id)
    End Function

    Public Sub Init(ByRef oItem_List As cMDB_CUS_PROG_ITEM_PRICE)

        Try
            With oItem_List

                .Cus_Prog_Item_Price_Id = 0
                .Cus_Prog_Item_List_Guid = String.Empty
                .Eqp_Column = 0
                .Eqp_Level = 0
                .Eqp_Pct = 0
                .Min_Qty_Ord = 0
                .Unit_Price = 0
                .Create_Ts = NoDate()
                .Update_Ts = NoDate()
                .User_Login = ""

            End With

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_PRICE_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Clone(ByRef oItem As cMDB_CUS_PROG_ITEM_PRICE) As cMDB_CUS_PROG_ITEM_PRICE

        ' Clones everything BUT the primary key
        Dim oClone As New cMDB_CUS_PROG_ITEM_PRICE

        oClone.Cus_Prog_Item_List_Guid = oItem.Cus_Prog_Item_List_Guid
        oClone.Eqp_Level = oItem.Eqp_Level
        oClone.Eqp_Column = oItem.Eqp_Column
        oClone.Eqp_Pct = oItem.Eqp_Pct
        oClone.Unit_Price = oItem.Unit_Price
        oClone.Min_Qty_Ord = oItem.Min_Qty_Ord

        oClone.User_Login = Environment.UserName
        oClone.Create_TS = Date.Now
        oClone.Update_TS = Date.Now

        Return oClone

    End Function


    '    ' List all elements in the database 
    'Public Function GetList() As List(Of cMDB_CUS_PROG_ITEM_PRICE)
    '    Return oMDB_CUS_PROG_ITEM_PRICE_DA.GetList()
    'End Function


    '    ' Update current element in the database 
    '    Public Function Update(oMDB_CUS_PROG_ITEM_PRICE As cMDB_CUS_PROG_ITEM_PRICE) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_PRICE_DA.Update(oMDB_CUS_PROG_ITEM_PRICE)
    '    End Function


    '    ' Get element with ID specified from the database 
    'Public Function GetItem(piCus_Prog_Item_Price_Id As Integer) As cMDB_CUS_PROG_ITEM_PRICE
    '    Return oMDB_CUS_PROG_ITEM_PRICE_DA.GetItem(piCus_Prog_Item_Price_Id)
    'End Function


    '    ' Delete element with ID specified from the database 
    '    Public Function Delete(piCus_Prog_Item_Price_Id As Integer) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_PRICE_DA.Delete(piCus_Prog_Item_Price_Id)
    '    End Function


    '    ' Insert current element in the database 
    '    Public Function Insert(oMDB_CUS_PROG_ITEM_PRICE As cMDB_CUS_PROG_ITEM_PRICE) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_PRICE_DA.Insert(oMDB_CUS_PROG_ITEM_PRICE)
    '    End Function


    ' Validate current element 
    Public Function Validate(oMDB_CUS_PROG_ITEM_PRICE As cMDB_CUS_PROG_ITEM_PRICE) As Boolean
        Return True

    End Function


    '' Validate current element 
    'Public Function Validate(oMDB_CUS_PROG_ITEM_PRICE As cMDB_CUS_PROG_ITEM_PRICE) As Boolean

    'End Function

End Class
