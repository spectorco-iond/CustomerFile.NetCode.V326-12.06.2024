Public Class cExact_Traveler_Communications


#Region "private variables ####################################################"


    Private m_intId As Int32 = 0
    Private m_strCus_No As String
    Private m_strOrd_No As String
    Private m_strCsr_Contact As String
    Private m_strCus_Contact As String
    Private m_strSubject As String
    Private m_strMessage As String
    Private m_dtCreatedate As DateTime
    Private m_strUserid As String
    Private m_blnDeleted As Boolean
    Private m_intOrig_Id As Int32
    Private m_blnNegativeFeed As Boolean
    Private m_intRating As Integer

#End Region


#Region "Public constructors ##################################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pId As Int32)

        Try

            Call Init()
            Call Load(pId)

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures #######################################"


    Private Sub Init()

        Try

            m_intId = 0
            m_strCus_No = String.Empty
            m_strOrd_No = String.Empty
            m_strCsr_Contact = String.Empty
            m_strCus_Contact = String.Empty
            m_strSubject = String.Empty
            m_strMessage = String.Empty

            m_strUserid = String.Empty
            m_blnDeleted = False
            m_intOrig_Id = 0
            m_blnNegativeFeed = False
            m_intRating = 0

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Id").Equals(DBNull.Value)) Then m_intId = pdrRow.Item("Id")
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_strOrd_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("Csr_Contact").Equals(DBNull.Value)) Then m_strCsr_Contact = pdrRow.Item("Csr_Contact").ToString
            If Not (pdrRow.Item("Cus_Contact").Equals(DBNull.Value)) Then m_strCus_Contact = pdrRow.Item("Cus_Contact").ToString
            If Not (pdrRow.Item("Subject").Equals(DBNull.Value)) Then m_strSubject = pdrRow.Item("Subject").ToString
            If Not (pdrRow.Item("Message").Equals(DBNull.Value)) Then m_strMessage = pdrRow.Item("Message").ToString
            If Not (pdrRow.Item("Createdate").Equals(DBNull.Value)) Then m_dtCreatedate = pdrRow.Item("Createdate")
            If Not (pdrRow.Item("Userid").Equals(DBNull.Value)) Then m_strUserid = pdrRow.Item("Userid").ToString
            If Not (pdrRow.Item("Deleted").Equals(DBNull.Value)) Then m_blnDeleted = pdrRow.Item("Deleted")
            If Not (pdrRow.Item("Orig_Id").Equals(DBNull.Value)) Then m_intOrig_Id = pdrRow.Item("Orig_Id")
            If Not (pdrRow.Item("NegativeFeed").Equals(DBNull.Value)) Then m_blnNegativeFeed = pdrRow.Item("NegativeFeed")
            If Not (pdrRow.Item("Rating").Equals(DBNull.Value)) Then m_intRating = pdrRow.Item("Rating")

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Id") = m_intId
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Ord_No") = m_strOrd_No
            pdrRow.Item("Csr_Contact") = m_strCsr_Contact
            pdrRow.Item("Cus_Contact") = m_strCus_Contact
            pdrRow.Item("Subject") = m_strSubject
            pdrRow.Item("Message") = m_strMessage
            pdrRow.Item("Deleted") = m_blnDeleted
            pdrRow.Item("Orig_Id") = m_intOrig_Id
            pdrRow.Item("NegativeFeed") = m_blnNegativeFeed
            pdrRow.Item("Rating") = m_intRating

            If m_dtCreatedate.Year = 1 Then m_dtCreatedate = Now.Date
            m_strUserid = Environment.UserName

            pdrRow.Item("Createdate") = m_dtCreatedate
            pdrRow.Item("Userid") = m_strUserid

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region


#Region "Public maintenance procedures ########################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Exact_Traveler_Communications " & _
            "WHERE  Id = " & m_intId & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Exact_Traveler_Communications WITH (Nolock) " & _
            "WHERE  Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Exact_Traveler_Communications " & _
            "WHERE  Id = " & m_intId & " "

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
            MsgBox("Error in cExact_Traveler_Communications." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ####################################################"

    Public Property Id() As Int32
        Get
            Id = m_intId
        End Get
        Set(ByVal value As Int32)
            m_intId = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Public Property Ord_No() As String
        Get
            Ord_No = m_strOrd_No
        End Get
        Set(ByVal value As String)
            m_strOrd_No = value
        End Set
    End Property

    Public Property Csr_Contact() As String
        Get
            Csr_Contact = m_strCsr_Contact
        End Get
        Set(ByVal value As String)
            m_strCsr_Contact = value
        End Set
    End Property

    Public Property Cus_Contact() As String
        Get
            Cus_Contact = m_strCus_Contact
        End Get
        Set(ByVal value As String)
            m_strCus_Contact = value
        End Set
    End Property

    Public Property Subject() As String
        Get
            Subject = m_strSubject
        End Get
        Set(ByVal value As String)
            m_strSubject = value
        End Set
    End Property

    Public Property Message() As String
        Get
            Message = m_strMessage
        End Get
        Set(ByVal value As String)
            m_strMessage = value
        End Set
    End Property

    Public Property Createdate() As DateTime
        Get
            Createdate = m_dtCreatedate
        End Get
        Set(ByVal value As DateTime)
            m_dtCreatedate = value
        End Set
    End Property

    Public Property Userid() As String
        Get
            Userid = m_strUserid
        End Get
        Set(ByVal value As String)
            m_strUserid = value
        End Set
    End Property

    Public Property Deleted() As Boolean
        Get
            Deleted = m_blnDeleted
        End Get
        Set(ByVal value As Boolean)
            m_blnDeleted = value
        End Set
    End Property

    Public Property Orig_Id() As Int32
        Get
            Orig_Id = m_intOrig_Id
        End Get
        Set(ByVal value As Int32)
            m_intOrig_Id = value
        End Set
    End Property

    Public Property NegativeFeed() As Boolean
        Get
            NegativeFeed = m_blnNegativeFeed
        End Get
        Set(ByVal value As Boolean)
            m_blnNegativeFeed = value
        End Set
    End Property

    Public Property Rating() As Int32
        Get
            Rating = m_intRating
        End Get
        Set(ByVal value As Int32)
            m_intRating = value
        End Set
    End Property

#End Region


End Class ' cExact_Traveler_Communications


