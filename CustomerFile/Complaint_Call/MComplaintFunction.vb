Module MComplaintFunction
    Public Function dgv_fill_from_dataset(ByVal dgv As DataGridView, ByVal dt As DataTable) As Boolean

        Try
            dgv.Columns.Clear()
            If dt.Rows.Count <> 0 Then
                Dim name(dt.Columns.Count) As String
                Dim i As Integer = 0
                For Each column As DataColumn In dt.Columns
                    name(i) = column.ColumnName
                    With dgv.Columns
                        .Add(DGVTextBoxColumn(name(i), name(i), 100))
                    End With
                Next
                dgv.DataSource = dt
            End If
        Catch er As Exception
            MsgBox("Error in " & "MComplaintFunction->dgv_fill_from_dataset" & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            Return False
        End Try
        Return True
    End Function
End Module
