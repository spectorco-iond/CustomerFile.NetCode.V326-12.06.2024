Public Class cRequest_View
    Implements ICloneable

    Private m_intRequestId As Int32
    Private m_intReviewId As Int32
    Private m_intReviewNo As Int32
    Private m_strRush_Order As String
    Private m_dtCreated As DateTime
    Private m_strCreator As String
    Private m_strDescription As String
    Private m_strStatus As String
    Private m_strPerson As String
    Private m_strAccount As String
    Private m_strRevItemCd As String

    Private m_strItems_No As String
    Private m_strImprint_Logos As String

    Public Sub New()
        Call Init()
    End Sub

    Private Sub Init()
        m_intRequestId = 0
        m_intReviewId = 0
        m_intReviewNo = 0
        m_strRush_Order = String.Empty
        m_dtCreated = DateNow()
        m_strCreator = String.Empty
        m_strDescription = String.Empty
        m_strStatus = String.Empty
        m_strPerson = String.Empty
        m_strAccount = String.Empty
        m_strRevItemCd = String.Empty

        m_strItems_No = String.Empty
        m_strImprint_Logos = String.Empty
    End Sub
    'RequestId 
    'ReviewId 
    'ReviewNo 
    'Created 
    'Creator 
    'Description 
    'Status 
    'Person 
    'Account 
    'm_intRequestId 
    '  m_intReviewId 
    '  m_intReviewNo 
    ' m_dtCreated
    '  m_strCreator 
    '  m_strDescription 
    '  m_strStatus 
    '  m_strPerson 
    '  m_strAccount 
#Region "------------------------------ Private Function -------------------------------"

    Private Sub LoadLine(ByRef pClass As cRequest_View, pdrRow As System.Data.DataRow)
        Try
            'CONVERT(varchar(10), rr.CreateDate, 105) AS Created
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then pClass.ReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("ReviewNo").Equals(DBNull.Value)) Then pClass.ReviewNo = pdrRow.Item("ReviewNo")

            If Not (pdrRow.Item("Rush_Order").Equals(DBNull.Value)) Then pClass.Rush_Order = pdrRow.Item("Rush_Order").ToString

            If Not (pdrRow.Item("Created").Equals(DBNull.Value)) Then pClass.Created = pdrRow.Item("Created").ToString
            If Not (pdrRow.Item("Creator").Equals(DBNull.Value)) Then pClass.Creator = pdrRow.Item("Creator").ToString

            If Not (pdrRow.Item("Description").Equals(DBNull.Value)) Then pClass.Description = pdrRow.Item("Description").ToString

            If Not (pdrRow.Item("Status").Equals(DBNull.Value)) Then pClass.Status = pdrRow.Item("Status").ToString

            If Not (pdrRow.Item("Person").Equals(DBNull.Value)) Then pClass.Person = pdrRow.Item("Person").ToString
            If Not (pdrRow.Item("Account").Equals(DBNull.Value)) Then pClass.Account = pdrRow.Item("Account").ToString
            If Not (pdrRow.Item("RevItemCd").Equals(DBNull.Value)) Then pClass.RevItemCd = pdrRow.Item("RevItemCd").ToString

            If Not (pdrRow.Item("Items_CD").Equals(DBNull.Value)) Then pClass.Items_No = pdrRow.Item("Items_CD").ToString
            If Not (pdrRow.Item("Imprint_Logos").Equals(DBNull.Value)) Then pClass.Imprint_Logos = pdrRow.Item("Imprint_Logos").ToString

        Catch ex As Exception
            MsgBox("Error in cRequest_View." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
#Region "----------------------------- Public Function ------------------------------"

    Public Function LoadLst(Optional strQuery As String = "") As List(Of cRequest_View)

        LoadLst = New List(Of cRequest_View)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cRequest_View)
            Dim i As Integer
            Dim strSql As String



            strSql =
              "SELECT * FROM Request_View WITH (Nolock) "

            'Justin by add top 500 as per ticket 11237 on 20200319
            'strSql =
            '  "SELECT * FROM iond_Request_View_New WITH (Nolock) "

            strSql =
              " SELECT top 500 * FROM iond_Request_View_New WITH (Nolock) "

            '++ID 4.02.2020 was created new view with display top 500 and order by  Created desc 
            ' was did , because user ask sort or order by create date and in this case it tooks 10-11 sec for continue 
            'ticket 11571 Virtual system in Customer File - searching
            'strSql =
            '  " SELECT top 1000 *, ISNULL(sr.Items_CD, '') AS Items_CD, ISNULL(sr.Imprint_Logo, '') AS Imprint_Logos " _
            '  & " FROM  [dbo].[iond_Request_View_NewTop500] r WITH (Nolock) LEFT OUTER JOIN dbo.iond_RequestView_STUFF_Items_Imprint  sr  WITH (Nolock) " _
            ' & " ON r.RequestId = sr.requestid AND r.ReviewId = sr.ReviewId  "

            '++ID 4.27.2020
            strSql = " select Top 5000 * from ( " _
                & " Select  r.*, ISNULL(sr.Items_CD, '') AS Items_CD, ISNULL(sr.Imprint_Logo, '') AS Imprint_Logos  FROM  [dbo].[iond_Request_View_NewTop500] r WITH (Nolock) " _
                & " LEFT OUTER JOIN dbo.iond_RequestView_STUFF_Items_Imprint  sr   WITH (Nolock)  ON r.RequestId = sr.requestid AND r.ReviewId = sr.ReviewId ) as t "



            'If strQuery <> "" Then
            '    strSql &= strQuery
            'End If

            '++ID 12.04.2023 was added new column in main table for to manage requests under netsuite  
            If strQuery <> "" Then
                strSql &= strQuery & " And NetSuiteFIeld = 0 "
            Else
                strSql &= " where NetSuiteFIeld = 0 "
            End If

            strSql &= " order by  Created desc  "





            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cRequest_View
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error In cRequest_View." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function LoadDistinct(Optional strQuery As String = "") As List(Of cRequest_View)

        LoadDistinct = New List(Of cRequest_View)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cRequest_View)
            Dim i As Integer
            Dim strSql As String



            strSql =
              "Select * FROM Request_View With (Nolock) "

            strSql =
              "Select * FROM iond_Request_View_New With (Nolock) "

            '++ID 4.02.2020       'ticket 11571 Virtual system in Customer File - searching
            strSql =
              " Select top 1000 *, ISNULL(sr.Items_CD, '') AS Items_CD, ISNULL(sr.Imprint_Logo, '') AS Imprint_Logos " _
              & " FROM  [dbo].[iond_Request_View_NewTop500] r WITH (Nolock) LEFT OUTER JOIN dbo.iond_RequestView_STUFF_Items_Imprint  sr  WITH (Nolock) " _
             & " ON r.RequestId = sr.requestid AND r.ReviewId = sr.ReviewId  "


            If strQuery <> "" Then
                strSql &= strQuery
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cRequest_View
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadDistinct = myList

        Catch ex As Exception
            MsgBox("Error in cRequest_View." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

#End Region

#Region "------------------------------------- Public Properites ------------------------------"
    Public Property RequestId As Integer
        Get
            Return m_intRequestId
        End Get
        Set(value As Integer)
            m_intRequestId = value
        End Set
    End Property

    Public Property ReviewId As Integer
        Get
            Return m_intReviewId
        End Get
        Set(value As Integer)
            m_intReviewId = value
        End Set
    End Property
    Public Property ReviewNo As Integer
        Get
            Return m_intReviewNo
        End Get
        Set(value As Integer)
            m_intReviewNo = value
        End Set
    End Property
    Public Property Rush_Order As String
        Get
            Return m_strRush_Order
        End Get
        Set(value As String)
            m_strRush_Order = value
        End Set
    End Property
    Public Property Created As DateTime
        Get
            Return m_dtCreated
        End Get
        Set(value As DateTime)
            m_dtCreated = value
        End Set
    End Property
    Public Property Creator As String
        Get
            Return m_strCreator
        End Get
        Set(value As String)
            m_strCreator = value
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
    Public Property Person As String
        Get
            Return m_strPerson
        End Get
        Set(value As String)
            m_strPerson = value
        End Set
    End Property

    Public Property Account As String
        Get
            Return m_strAccount
        End Get
        Set(value As String)
            m_strAccount = value
        End Set
    End Property
    Public Property Status As String
        Get
            Return m_strStatus
        End Get
        Set(value As String)
            m_strStatus = value
        End Set
    End Property
    Public Property RevItemCd As String
        Get
            Return m_strRevItemCd
        End Get
        Set(value As String)
            m_strRevItemCd = value
        End Set
    End Property

    Public Property Items_No As String
        Get
            Return m_strItems_No
        End Get
        Set(value As String)
            m_strItems_No = value
        End Set
    End Property
    Public Property Imprint_Logos As String
        Get
            Return m_strImprint_Logos
        End Get
        Set(value As String)
            m_strImprint_Logos = value
        End Set
    End Property

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
