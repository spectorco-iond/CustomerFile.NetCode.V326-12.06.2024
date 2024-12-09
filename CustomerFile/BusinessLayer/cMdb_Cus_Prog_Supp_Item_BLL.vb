Public Class cMdb_Cus_Prog_Supp_Item_BUS



        ' Handle to the Mdb_Cus_Prog_Supp_Item DBAccess class
        Private oMdb_Cus_Prog_Supp_Item_DA As cMdb_Cus_Prog_Supp_Item_DAL = Nothing


        Public Sub New()
                oMdb_Cus_Prog_Supp_Item_DA = New cMdb_Cus_Prog_Supp_Item_DAL()
        End Sub


        ' List all elements in the database 
    Public Function GetList() As List(Of cMdb_Cus_Prog_Supp_Item)
        Return oMdb_Cus_Prog_Supp_Item_DA.GetList()
    End Function


        ' Update current element in the database 
        Public Function Update(oMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean
        Return oMdb_Cus_Prog_Supp_Item_DA.Update(oMdb_Cus_Prog_Supp_Item)
        End Function


        ' Get element with ID specified from the database 
    Public Function GetItem(piCus_Prog_Supp_Item_Id As Integer) As cMdb_Cus_Prog_Supp_Item
        Return oMdb_Cus_Prog_Supp_Item_DA.GetItem(piCus_Prog_Supp_Item_Id)
    End Function


        ' Delete element with ID specified from the database 
        Public Function Delete(piCus_Prog_Supp_Item_Id As Integer) As Boolean
        Return oMdb_Cus_Prog_Supp_Item_DA.Delete(piCus_Prog_Supp_Item_Id)
        End Function


        ' Insert current element in the database 
        Public Function Insert(oMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean
        Return oMdb_Cus_Prog_Supp_Item_DA.Insert(oMdb_Cus_Prog_Supp_Item)
        End Function


        ' Validate current element 
        Public Function Validate(oMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean
        Return True

        End Function


    '' Validate current element 
    'Public Function Validate(oMdb_Cus_Prog_Supp_Item As cMdb_Cus_Prog_Supp_Item) As Boolean

    'End Function

End Class ' cMdb_Cus_Prog_Supp_Item


