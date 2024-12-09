Public Class cComplaintCallType_DAL


    Public Function Load() As List(Of cComplaintCallType)

        Load = New List(Of cComplaintCallType)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cComplaintCallType)


            Dim strSql As String
            strSql =
            " select COMPLAINT_CALL_TYPE_ID , COMPLAINT_CALL_TYPE_NAME from COMPLAINT_CALL_TYPE "

            dt = db.DataTable(strSql)


            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cComplaintCallType
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load = myList

            ''

        Catch ex As Exception
            MsgBox("Error In cMdb_H_Item_No_List_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(pClass As cComplaintCallType, ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_TYPE_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_TYPE_ID = pdrRow.Item("COMPLAINT_CALL_TYPE_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_TYPE_NAME").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_TYPE_NAME = pdrRow.Item("COMPLAINT_CALL_TYPE_NAME").ToString

        Catch ex As Exception
            MsgBox("Error in cComplaintCallType_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


End Class
