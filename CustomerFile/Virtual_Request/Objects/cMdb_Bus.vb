

Public Class cMdb_Bus
    Private oMdb_Item_VariantColor As cMdb_Item_VariantColor = Nothing
    Private oMdb_Item_Master As cMdb_Item_Master = Nothing


    Public Sub New()
        oMdb_Item_VariantColor = New cMdb_Item_VariantColor()
        oMdb_Item_Master = New cMdb_Item_Master()
    End Sub

    Public Function LoadMasterCd_List(ByVal piMasterCd As String) As cMdb_Item_Master
        Return oMdb_Item_Master.LoadByMasterId(piMasterCd)
    End Function
    Public Function GetList_Color(ByVal pColorId As Int32) As List(Of cMdb_Item_VariantColor)
        Return oMdb_Item_VariantColor.Load_VariantListColor(pColorId)
    End Function

End Class
