Public Class cMDB_CFG_IMP_LOC
    Private m_intImp_Loc_Id As Integer
    Private m_strDescription As String

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()
        m_intImp_Loc_Id = 0
        m_strDescription = String.Empty
    End Sub

    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("IMP_LOC_ID").Equals(DBNull.Value)) Then m_intImp_Loc_Id = pdrRow.Item("IMP_LOC_ID")
            If Not (pdrRow.Item("DESCRIPTION").Equals(DBNull.Value)) Then m_strDescription = pdrRow.Item("DESCRIPTION").ToString

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_IMP_LOC." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub LoadLine(pClass As cMDB_CFG_IMP_LOC, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("IMP_LOC_ID").Equals(DBNull.Value)) Then pClass.IMP_LOC_ID = pdrRow.Item("IMP_LOC_ID")
            If Not (pdrRow.Item("DESCRIPTION").Equals(DBNull.Value)) Then pClass.IMP_DESC = pdrRow.Item("DESCRIPTION").ToString

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_IMP_LOC." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Public Function Load(ByVal pintID As Integer) As Boolean
        Load = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT IMP_LOC_ID, DESCRIPTION " &
            "FROM   MDB_CFG_IMP_LOC WITH (Nolock) " &
            "WHERE  IMP_LOC_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_IMP_LOC." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function LoadLst() As List(Of cMDB_CFG_IMP_LOC)
        LoadLst = New List(Of cMDB_CFG_IMP_LOC)
        Try
            Dim oEnum = New cMDB_CFG_IMP_LOC
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMDB_CFG_IMP_LOC)
            Dim i As Integer
            Dim strSql As String

            strSql = "SELECT IMP_LOC_ID, DESCRIPTION " &
            "FROM   MDB_CFG_IMP_LOC WITH (Nolock) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMDB_CFG_IMP_LOC
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList


        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_IMP_LOC." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Property IMP_LOC_ID() As Integer
        Get
            Return m_intImp_Loc_Id
        End Get
        Set(value As Integer)
            m_intImp_Loc_Id = value
        End Set
    End Property
    Public Property IMP_DESC As String
        Get
            Return m_strDescription
        End Get
        Set(value As String)
            m_strDescription = value
        End Set
    End Property

End Class



