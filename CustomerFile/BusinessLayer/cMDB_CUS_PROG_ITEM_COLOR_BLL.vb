Public Class cMDB_CUS_PROG_ITEM_COLOR_BLL


    ' Handle to the MDB_CUS_PROG_ITEM_COLOR DBAccess class
    Private oMDB_CUS_PROG_ITEM_COLOR_DA As cMDB_CUS_PROG_ITEM_COLOR_DAL = Nothing

    Public Sub New()
        oMDB_CUS_PROG_ITEM_COLOR_DA = New cMDB_CUS_PROG_ITEM_COLOR_DAL()
    End Sub

    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Prog_Item_Color_Id As Integer) As cMDB_CUS_PROG_ITEM_COLOR
        Return oMDB_CUS_PROG_ITEM_COLOR_DA.Load(piCus_Prog_Item_Color_Id)
    End Function

    ' Insert current element in the database 
    Public Function Save(ByRef oMDB_CUS_PROG_ITEM_COLOR As cMDB_CUS_PROG_ITEM_COLOR) As Boolean
        Return oMDB_CUS_PROG_ITEM_COLOR_DA.Save(oMDB_CUS_PROG_ITEM_COLOR)
    End Function

    ' Delete element with ID specified from the database 
    Public Function Delete(ByVal piCus_Prog_Item_Color_Id As Integer) As Boolean
        Return oMDB_CUS_PROG_ITEM_COLOR_DA.Delete(piCus_Prog_Item_Color_Id)
    End Function

    Public Sub Init(ByRef oItem_List As cMDB_CUS_PROG_ITEM_COLOR)

        Try
            With oItem_List

                .Cus_Prog_Item_Color_Id = 0
                .Cus_Prog_Item_List_Guid = String.Empty
                .Item_No = String.Empty
                .Selected = False
                .Create_Ts = NoDate()
                .Update_Ts = NoDate()
                .User_Login = ""

            End With

        Catch ex As Exception
            MsgBox("Error in cMDB_CUS_PROG_ITEM_COLOR_BLL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Clone(ByRef oItem As cMDB_CUS_PROG_ITEM_COLOR) As cMDB_CUS_PROG_ITEM_COLOR

        Dim oClone As New cMDB_CUS_PROG_ITEM_COLOR

        With oClone

            .Cus_Prog_Item_Color_Id = oItem.Cus_Prog_Item_Color_Id
            .Cus_Prog_Item_List_Guid = oItem.Cus_Prog_Item_List_Guid
            .Item_No = oItem.Item_No
            .Selected = oItem.Selected
            .User_Login = Environment.UserName
            .Create_Ts = Date.Now
            .Update_Ts = Date.Now

        End With

        Return oClone

    End Function


    '    ' List all elements in the database 
    'Public Function GetList() As List(Of cMDB_CUS_PROG_ITEM_COLOR)
    '    Return oMDB_CUS_PROG_ITEM_COLOR_DA.GetList()
    'End Function


    '    ' Update current element in the database 
    '    Public Function Update(oMDB_CUS_PROG_ITEM_COLOR As cMDB_CUS_PROG_ITEM_COLOR) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_COLOR_DA.Update(oMDB_CUS_PROG_ITEM_COLOR)
    '    End Function


    '    ' Get element with ID specified from the database 
    'Public Function GetItem(piCus_Prog_Item_Color_Id As Integer) As cMDB_CUS_PROG_ITEM_COLOR
    '    Return oMDB_CUS_PROG_ITEM_COLOR_DA.GetItem(piCus_Prog_Item_Color_Id)
    'End Function


    '    ' Delete element with ID specified from the database 
    '    Public Function Delete(piCus_Prog_Item_Color_Id As Integer) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_COLOR_DA.Delete(piCus_Prog_Item_Color_Id)
    '    End Function


    '    ' Insert current element in the database 
    '    Public Function Insert(oMDB_CUS_PROG_ITEM_COLOR As cMDB_CUS_PROG_ITEM_COLOR) As Boolean
    '    Return oMDB_CUS_PROG_ITEM_COLOR_DA.Insert(oMDB_CUS_PROG_ITEM_COLOR)
    '    End Function


    ' Validate current element 
    Public Function Validate(oMDB_CUS_PROG_ITEM_COLOR As cMDB_CUS_PROG_ITEM_COLOR) As Boolean
        Return True

    End Function


    '' Validate current element 
    'Public Function Validate(oMDB_CUS_PROG_ITEM_COLOR As cMDB_CUS_PROG_ITEM_COLOR) As Boolean

    'End Function

End Class
