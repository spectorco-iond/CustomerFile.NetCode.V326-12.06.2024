Public Class cOEPrcFil_Sql_BLL

    Public Sub New()

    End Sub

    Public Function Get_EQP(ByVal pItem_No As String, ByVal pCurr_Cd As String) As Double

        Get_EQP = 0

        Dim db As New cDBA
        Dim dt As DataTable

        ' CD_TP = 6 IS THE DEFAULT PRICE
        Dim strsql As String = _
        "SELECT     CD_TP, CD_TP_1_ITEM_NO, CURR_CD, " & _
        "           ISNULL(Prc_Or_Disc_1, 0) AS Prc_Or_Disc_1, " & _
        "           ISNULL(Prc_Or_Disc_5, 0) AS Prc_Or_Disc_5 " & _
        "FROM       OEPRCFIL_SQL " & _
        "WHERE      CD_TP = 6 AND CD_TP_1_ITEM_NO = '" & pItem_No.Trim & "' AND CURR_CD = '" & pCurr_Cd & "' "

        dt = db.DataTable(strsql)
        If dt.Rows.Count <> 0 Then
            Get_EQP = dt.Rows(0).Item("Prc_Or_Disc_5")
            If Get_EQP = 0 Then
                Get_EQP = dt.Rows(0).Item("Prc_Or_Disc_1")
            End If
        End If

    End Function

End Class
