
Module gGlobal

    Public Function Remove_Space(ByVal _str As String)
        Remove_Space = String.Empty
        Try

            _str = Trim(RTrim((LTrim(_str))))

            Remove_Space = _str
        Catch ex As Exception
            MsgBox("Error in gGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Enum HeaderInfo
        Cus_Prog_Id
        Cus_No
        ProgType
        SpectorCd
        Impr
        Prog_Csr
        dtStart_Dt
        dtEnd_Dt
        Prog_Comment
        Cnt_FullName
        Cnt_Tel
        Cnt_Email
        Current_Rev_No
        Create_By
        Cmp_Name
        Addr1
        Addr2
        Addr3
        City_Code
        Spector_Contact
        Spector_Email
    End Enum

End Module
