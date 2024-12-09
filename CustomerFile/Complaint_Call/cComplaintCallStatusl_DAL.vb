Public Class cComplaintCallStatus_DAL


    Public Function Load() As List(Of cComplaintCallStatus)

        Load = New List(Of cComplaintCallStatus)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cComplaintCallStatus)


            Dim strSql As String
            strSql =
            " select COMPLAINT_CALL_STATUS_ID , COMPLAINT_CALL_STATUS_NAME from COMPLAINT_CALL_STATUS "

            dt = db.DataTable(strSql)


            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cComplaintCallStatus
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load = myList

            ''

        Catch ex As Exception
            MsgBox("Error In cComplatintCallStatus_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(pClass As cComplaintCallStatus, ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_STATUS_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_STATUS_ID = pdrRow.Item("COMPLAINT_CALL_STATUS_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_STATUS_NAME").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_STATUS_NAME = pdrRow.Item("COMPLAINT_CALL_STATUS_NAME").ToString

        Catch ex As Exception
            MsgBox("Error in cComplatintCallStatus_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


End Class
