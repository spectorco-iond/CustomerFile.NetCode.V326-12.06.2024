Public Class cComplaintCallLevel_DAL


    Public Function Load() As List(Of cComplaintCallLevel)

        Load = New List(Of cComplaintCallLevel)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cComplaintCallLevel)


            Dim strSql As String
            strSql =
            " select COMPLAINT_CALL_LEVEL_ID , COMPLAINT_CALL_LEVEL_NAME from COMPLAINT_CALL_LEVEL "

            dt = db.DataTable(strSql)


            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cComplaintCallLevel
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load = myList

            ''

        Catch ex As Exception
            MsgBox("Error In cComplatintCallLevel_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(pClass As cComplaintCallLevel, ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_LEVEL_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_LEVEL_ID = pdrRow.Item("COMPLAINT_CALL_LEVEL_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_LEVEL_NAME").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_LEVEL_NAME = pdrRow.Item("COMPLAINT_CALL_LEVEL_NAME").ToString

        Catch ex As Exception
            MsgBox("Error in cComplatintCallLevel_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


End Class
