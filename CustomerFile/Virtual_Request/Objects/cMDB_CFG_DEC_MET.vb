Public Class cMDB_CFG_DEC_MET
    Private m_intDEC_MET_ID As Integer
    Private m_strDEC_MET_NAME As String

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()
        m_intDEC_MET_ID = 0
        m_strDEC_MET_NAME = String.Empty
    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("DEC_MET_ID").Equals(DBNull.Value)) Then m_intDEC_MET_ID = pdrRow.Item("DEC_MET_ID")
            If Not (pdrRow.Item("DEC_MET_NAME").Equals(DBNull.Value)) Then m_strDEC_MET_NAME = pdrRow.Item("DEC_MET_NAME").ToString

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DEC_MET." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub LoadLine(pClass As cMDB_CFG_DEC_MET, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("DEC_MET_ID").Equals(DBNull.Value)) Then pClass.DEC_MET_ID = pdrRow.Item("DEC_MET_ID")
            If Not (pdrRow.Item("DEC_MET_NAME").Equals(DBNull.Value)) Then pClass.DEC_MET_NAME = pdrRow.Item("DEC_MET_NAME").ToString

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DEC_MET." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Load(ByVal pintID As Integer) As Boolean
        Load = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT DEC_MET_ID,DEC_MET_NAME " &
            "FROM   MDB_CFG_DEC_MET WITH (Nolock) " &
            "WHERE  DEC_MET_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DEC_MET." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst() As List(Of cMDB_CFG_DEC_MET)
        LoadLst = New List(Of cMDB_CFG_DEC_MET)
        Try
            Dim oEnum = New cMDB_CFG_DEC_MET
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMDB_CFG_DEC_MET)
            Dim i As Integer
            Dim strSql As String

            strSql =
            "SELECT DEC_MET_ID,DEC_MET_NAME " &
            "FROM   MDB_CFG_DEC_MET WITH (Nolock) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cMDB_CFG_DEC_MET
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList


        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DEC_MET." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    Public Property DEC_MET_ID() As Integer
        Get
            Return m_intDEC_MET_ID
        End Get
        Set(value As Integer)
            m_intDEC_MET_ID = value
        End Set
    End Property
    Public Property DEC_MET_NAME As String
        Get
            Return m_strDEC_MET_NAME
        End Get
        Set(value As String)
            m_strDEC_MET_NAME = value
        End Set
    End Property
End Class
