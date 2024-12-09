Public Class cMdb_Cus_Prog_Count


#Region "private variables #################################################"

    Private m_intCus_Prog_Count_Id As Int32 = 0
    Private m_strProg_Date_Cd As String
    Private m_intProg_Count As Int32 = 0
    Private m_oProgram As cMdb_Cus_Prog

#End Region


#Region "Public constructors ##############################################"

    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Prog_Count_Id As Int32)

        Try

            Call Init()
            Call Load(pCus_Prog_Count_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pProg_Date_Cd As String)

        Try

            Call Init()
            Call Load(pProg_Date_Cd)

            If m_strProg_Date_Cd = String.Empty Then m_strProg_Date_Cd = pProg_Date_Cd

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByRef pProgram As cMdb_Cus_Prog)

        Try

            Call Init()
            m_oProgram = pProgram

            Call Load(m_oProgram)

            'If m_strProg_Date_Cd = String.Empty Then m_strProg_Date_Cd = pProg_Date_Cd

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCus_Prog_Count_Id = 0
            m_strProg_Date_Cd = String.Empty
            m_intProg_Count = 0

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Prog_Count_Id").Equals(DBNull.Value)) Then m_intCus_Prog_Count_Id = pdrRow.Item("Cus_Prog_Count_Id")
            If Not (pdrRow.Item("Prog_Date_Cd").Equals(DBNull.Value)) Then m_strProg_Date_Cd = pdrRow.Item("Prog_Date_Cd").ToString
            If Not (pdrRow.Item("Prog_Count").Equals(DBNull.Value)) Then m_intProg_Count = pdrRow.Item("Prog_Count")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Cus_Prog_Count_Id") = m_intCus_Prog_Count_Id
            pdrRow.Item("Prog_Date_Cd") = m_strProg_Date_Cd
            pdrRow.Item("Prog_Count") = m_intProg_Count

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    '' Deletes the current Comment from the database, if it exists.
    'Public Sub Delete()

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql = _
    '        "DELETE FROM Mdb_Cus_Prog_Count " & _
    '        "WHERE  Cus_Prog_Count_Id = " & m_intCus_Prog_Count_Id & " "

    '        db.Execute(strSql)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Count WITH (Nolock) " & _
            "WHERE  Cus_Prog_Count_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load(ByVal pProg_Date_Cd As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Count WITH (Nolock) " & _
            "WHERE  Prog_Date_Cd = '" & pProg_Date_Cd.Trim.Replace("'", "''") & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load(ByRef poProgram As cMdb_Cus_Prog)

        Try
            Dim strPrefix As String = ""

            Select Case poProgram.Prog_Type

                Case 1 ' Program
                    strPrefix = "P" & Mid(Date.Now.Year.ToString, 3, 2)

                Case 2, 4 ' Special Pricing
                    strPrefix = "S" & Mid(Date.Now.Year.ToString, 3, 2)

                Case 3 ' Quote
                    strPrefix = "Q" & Mid(Date.Now.Year.ToString, 3, 2)

            End Select

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Count WITH (Nolock) " & _
            "WHERE  Prog_Date_Cd = '" & strPrefix & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            Else
                m_strProg_Date_Cd = strPrefix
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Prog_Count " & _
            "WHERE  Cus_Prog_Count_Id = " & m_intCus_Prog_Count_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Count." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Function Set_Next_Prog_Count() As String

        Set_Next_Prog_Count = ""

        'm_strProg_Date_Cd = "P13"
        m_intProg_Count += 1

        Call Save()

        Select Case m_oProgram.Prog_Type
            Case 1
                Set_Next_Prog_Count = m_strProg_Date_Cd & "-" & m_intProg_Count.ToString.PadLeft(4, "0")
            Case 2, 4
                Set_Next_Prog_Count = m_strProg_Date_Cd & "-" & m_intProg_Count.ToString.PadLeft(4, "0")
            Case 3
                Set_Next_Prog_Count = m_strProg_Date_Cd & "-" & m_intProg_Count.ToString.PadLeft(4, "0")
        End Select

    End Function

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Prog_Count_Id() As Int32
        Get
            Cus_Prog_Count_Id = m_intCus_Prog_Count_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Prog_Count_Id = value
        End Set
    End Property

    Public Property Prog_Date_Cd() As String
        Get
            Prog_Date_Cd = m_strProg_Date_Cd
        End Get
        Set(ByVal value As String)
            m_strProg_Date_Cd = value
        End Set
    End Property

    Public Property Prog_Count() As Int32
        Get
            Prog_Count = m_intProg_Count
        End Get
        Set(ByVal value As Int32)
            m_intProg_Count = value
        End Set
    End Property

#End Region


End Class ' cMdb_Cus_Prog_Count


