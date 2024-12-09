Public Class cReqCFGStatus
    Private m_intID As Integer
    Private m_strDescription As String
    'Private m_intTermId As Integer
    'Private m_intDivision As Short

    Public Sub New()
        Call Init()
    End Sub
#Region "---------------------------- Private Function -----------------------------"

    Private Sub Init()
        m_intID = 0
        m_strDescription = String.Empty
        'm_intTermId = 0
        'm_intDivision = 0
    End Sub
    '
    'm_intID 
    'm_strDescription 
    'm_intTermId 
    'm_intDivision 

    '  ID 
    'Description 
    'TermId 
    'Division 
    '
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then ID = pdrRow.Item("ID")
            If Not (pdrRow.Item("Description").Equals(DBNull.Value)) Then Description = pdrRow.Item("Description").ToString
            'If Not (pdrRow.Item("TermId").Equals(DBNull.Value)) Then TermId = pdrRow.Item("TermId")
            'If Not (pdrRow.Item("Division").Equals(DBNull.Value)) Then Division = pdrRow.Item("Division")

        Catch ex As Exception
            MsgBox("Error in cReqCFGStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqCFGStatus, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then pClass.ID = pdrRow.Item("ID")
            If Not (pdrRow.Item("Description").Equals(DBNull.Value)) Then pClass.Description = pdrRow.Item("Description").ToString
            'If Not (pdrRow.Item("TermId").Equals(DBNull.Value)) Then pClass.TermId = pdrRow.Item("TermId")
            'If Not (pdrRow.Item("Division").Equals(DBNull.Value)) Then pClass.Division = pdrRow.Item("Division")

        Catch ex As Exception
            MsgBox("Error in cReqCFGStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "--------------------------------- Public Function -----------------------------"
    Public Sub Load(ByVal p_Id As Integer)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
              " SELECT * " &
              " FROM   ReqCFGStatus WITH (Nolock) " &
              " WHERE  ID = " & p_Id & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in ReqCFGStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Public Function LoadLst() As List(Of cReqCFGStatus)

        LoadLst = New List(Of cReqCFGStatus)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqCFGStatus)
            Dim i As Integer
            Dim strSql As String

            strSql =
              " SELECT * " &
              " FROM   ReqCFGStatus WITH (Nolock) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqCFGStatus
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqCFGStatus." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region

#Region "---------------------- Public Properties -------------------------"
    Public Property ID As Integer
        Get
            Return m_intID
        End Get
        Set(value As Integer)
            m_intID = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return m_strDescription
        End Get
        Set(value As String)
            m_strDescription = value
        End Set
    End Property

    'Public Property TermId As Integer
    '    Get
    '        Return m_intTermId
    '    End Get
    '    Set(value As Integer)
    '        m_intTermId = value
    '    End Set
    'End Property

    'Public Property Division As Short
    '    Get
    '        Return m_intDivision
    '    End Get
    '    Set(value As Short)
    '        m_intDivision = Division
    '    End Set
    'End Property
#End Region
End Class
