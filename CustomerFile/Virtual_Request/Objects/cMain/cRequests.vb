Imports System.Data.Odbc
Public Class cRequests
    Implements ICloneable

    Private m_intRequestId As Integer
    Private m_intTypeId As Integer
    Private m_itemCode As String
    Private m_dtCreate As Date
    Private m_dtModify As Date
    Private m_dtViewDate As Date
    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_intModifyBy As Integer
    Private m_strModifyByFullname As String
    Private m_strfreefield As String
    Private m_strReq_Guid As String

    '----------------------
    Private Sub Init()
        m_intRequestId = 0
        m_intTypeId = 0
        m_itemCode = String.Empty
        m_strfreefield = 0
        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreate = Date.Now
        m_intModifyBy = 0
        m_strModifyByFullname = String.Empty
        m_dtModify = Date.Now
        m_dtViewDate = Date.Now
    End Sub
    '
    'm_intRequestId 
    '    m_intTypeId 
    '    m_itemCode 
    '    m_intStatus 
    '    m_intCreateBy 
    '    m_strCreateByFullName 
    '    m_dtCreate 
    '    m_intModifiedBy 
    '    m_strModifiedByFullname 
    '    m_dtModified 
    '    m_dtViewDate 
    '
    '---------------------
    Public Sub New()
        Call Init()
    End Sub

    Public Sub New(p_intRequestId As Integer)

    End Sub

#Region "------------------------ Private Function ----------------------------------"
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            'If Not (pdrRow.Item("RequestID").Equals(DBNull.Value)) Then RequestID = pdrRow.Item("RequestID")
            'If Not (pdrRow.Item("TypeID").Equals(DBNull.Value)) Then TypeID = pdrRow.Item("TypeID") 'request storyboard type id
            'If Not (pdrRow.Item("ItemCode").Equals(DBNull.Value)) Then ItemCode = pdrRow.Item("ItemCode").ToString
            'If Not (pdrRow.Item("Freefield").Equals(DBNull.Value)) Then Freefield = pdrRow.Item("Freefield").ToString
            'If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then CreateBy = pdrRow.Item("CreateBy")
            'If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            'If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then CreateDate = pdrRow.Item("CreateDate").ToString
            'If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then ModifyBy = pdrRow.Item("ModifyBy")
            'If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            'If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then ModifyDate = pdrRow.Item("ModifyDate").ToString
            'If Not (pdrRow.Item("ViewDate").Equals(DBNull.Value)) Then ViewDate = pdrRow.Item("ViewDate").ToString
            'If Not (pdrRow.Item("Req_Guid").Equals(DBNull.Value)) Then Req_Guid = pdrRow.Item("Req_Guid").ToString

            If Not (pdrRow.Item("RequestID").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestID")
            If Not (pdrRow.Item("TypeID").Equals(DBNull.Value)) Then m_intTypeId = pdrRow.Item("TypeID")
            If Not (pdrRow.Item("ItemCode").Equals(DBNull.Value)) Then m_itemCode = pdrRow.Item("ItemCode").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then m_intModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then m_strModifyByFullname = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then m_dtModify = pdrRow.Item("ModifyDate").ToString
            If Not (pdrRow.Item("ViewDate").Equals(DBNull.Value)) Then m_dtViewDate = pdrRow.Item("ViewDate").ToString
            If Not (pdrRow.Item("Req_Guid").Equals(DBNull.Value)) Then m_strReq_Guid = pdrRow.Item("Req_Guid").ToString


        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cRequests, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("RequestID").Equals(DBNull.Value)) Then pClass.RequestID = pdrRow.Item("RequestID")
            If Not (pdrRow.Item("TypeID").Equals(DBNull.Value)) Then pClass.TypeID = pdrRow.Item("TypeID") 'request storyboard type id
            If Not (pdrRow.Item("ItemCode").Equals(DBNull.Value)) Then pClass.ItemCode = pdrRow.Item("ItemCode").ToString
            If Not (pdrRow.Item("Freefield").Equals(DBNull.Value)) Then pClass.Freefield = pdrRow.Item("Freefield").ToString
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then pClass.ModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then pClass.ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then pClass.ModifyDate = pdrRow.Item("ModifyDate").ToString
            If Not (pdrRow.Item("ViewDate").Equals(DBNull.Value)) Then pClass.ViewDate = pdrRow.Item("ViewDate").ToString
            If Not (pdrRow.Item("Req_Guid").Equals(DBNull.Value)) Then pClass.Req_Guid = pdrRow.Item("Req_Guid").ToString

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            'pdrRow.Item("RequestID") = RequestID
            'pdrRow.Item("TypeID") = TypeID
            'pdrRow.Item("ItemCode") = ItemCode
            'pdrRow.Item("Freefield") = Freefield
            'pdrRow.Item("CreateBy") = CreateBy
            'pdrRow.Item("CreateByFullName") = CreateByFullName
            'pdrRow.Item("CreateDate") = CreateDate
            'pdrRow.Item("ModifyBy") = ModifyBy
            'pdrRow.Item("ModifyByFullName") = ModifyByFullName
            'pdrRow.Item("ModifyDate") = ModifyDate
            'pdrRow.Item("ViewDate") = ViewDate
            'pdrRow.Item("Req_Guid") = Req_Guid

            If Not (pdrRow.Item("RequestID").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestID")

            ' pdrRow.Item("RequestID") = m_intRequestId
            pdrRow.Item("TypeID") = m_intTypeId
            pdrRow.Item("ItemCode") = m_itemCode
            pdrRow.Item("Freefield") = Freefield


            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If m_intRequestId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("ViewDate") = m_dtViewDate
            pdrRow.Item("Req_Guid") = m_strReq_Guid


        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cRequests, pdrRow As System.Data.DataRow)
        Try
            '  pdrRow.Item("RequestID") = pClass.RequestID
            pdrRow.Item("TypeID") = pClass.TypeID
            pdrRow.Item("ItemCode") = pClass.ItemCode
            pdrRow.Item("Freefield") = pClass.Freefield
            'properties are filled in the public propperty
            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If Not (pdrRow.Item("RequestID").Equals(DBNull.Value)) Then pClass.RequestID = pdrRow.Item("RequestID")

            If pClass.RequestID > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("ViewDate") = pClass.ViewDate
            pdrRow.Item("Req_Guid") = pClass.Req_Guid

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
#Region "----------------------- Public Function -------------------------------"
    Public Function Load(ByVal p_strGuid As String) As Boolean
        Load = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM   Requests WITH (Nolock) " &
              "WHERE  Ltrim(Rtrim(Req_Guid)) = '" & p_strGuid & "'"

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Load(ByVal p_intRequestId As Integer) As Boolean
        Load = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM   Requests WITH (Nolock) " &
              "WHERE  RequestID = " & p_intRequestId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    'display all Request
    Public Function Load_List() As List(Of cRequests)
        Load_List = New List(Of cRequests)
        Try
            Dim oEnum = New cRequests
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cRequests)
            Dim i As Integer
            Dim strSql As String

            strSql = "select * from Requests WITH (NOLOCK) "

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cRequests
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load_List = myList

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadRequest_List(ByVal p_intMotherId As Int32) As List(Of cRequests)
        LoadRequest_List = New List(Of cRequests)
        Try
            Dim oEnum = New cRequests
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cRequests)
            Dim i As Integer
            Dim strSql As String

            strSql = "select * from Requests WITH (NOLOCK) " _
                   & " where  RequestID = " & p_intMotherId

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cRequests
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadRequest_List = myList

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save() As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
                "SELECT * " &
                "FROM   Requests WITH (NOLOCK)" &
            "WHERE  RequestID = " & RequestID

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

            Save = db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save(ByRef pClass As cRequests) As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
                "SELECT * " &
                "FROM   Requests WITH (NOLOCK)" &
            "WHERE  RequestID = " & pClass.RequestID

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(pClass, drRow)

            If dt.Rows.Count = 0 Then

                db.DBDataTable.Rows.Add(drRow)
                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

            Else

                Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
                db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

            End If

            Save = db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete() As Boolean
        Delete = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                " DELETE FROM Requests " &
            " WHERE  RequestId = " & m_intRequestId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete(pintID As Integer) As Boolean
        Delete = False
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
                " DELETE FROM Requests " &
            " WHERE  RequestId = " & pintID

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cRequests." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


#End Region
#Region "---------------Public properties------------"
    Public Property RequestID As Integer
        Get
            Return m_intRequestId
        End Get
        Set(value As Integer)
            m_intRequestId = value
        End Set
    End Property

    Public Property TypeID As Integer
        Get
            Return m_intTypeId
        End Get
        Set(value As Integer)
            m_intTypeId = value
        End Set
    End Property

    Public Property ItemCode As String
        Get
            Return m_itemCode
        End Get
        Set(value As String)
            m_itemCode = value
        End Set
    End Property

    Public Property CreateBy As Integer
        Get
            Return m_intCreateBy
        End Get
        Set(value As Integer)
            m_intCreateBy = value
        End Set
    End Property

    Public Property CreateByFullName As String
        Get
            Return m_strCreateByFullName
        End Get
        Set(value As String)
            m_strCreateByFullName = value
        End Set
    End Property

    Public Property CreateDate As Date
        Get
            Return m_dtCreate
        End Get
        Set(value As Date)
            m_dtCreate = value
        End Set
    End Property

    Public Property ModifyBy As Integer
        Get
            Return m_intModifyBy
        End Get
        Set(value As Integer)
            m_intModifyBy = value
        End Set
    End Property

    Public Property ModifyByFullName As String
        Get
            Return m_strModifyByFullname
        End Get
        Set(value As String)
            m_strModifyByFullname = value
        End Set
    End Property

    Public Property ModifyDate As Date
        Get
            Return m_dtModify
        End Get
        Set(value As Date)
            m_dtModify = value
        End Set
    End Property
    Public Property ViewDate As Date
        Get
            Return m_dtViewDate
        End Get
        Set(value As Date)
            m_dtViewDate = value
        End Set
    End Property
    Public Property Freefield As String
        Get
            Return m_strfreefield
        End Get
        Set(value As String)
            m_strfreefield = value
        End Set
    End Property
    Public Property Req_Guid As String
        Get
            Return m_strReq_Guid
        End Get
        Set(value As String)
            m_strReq_Guid = value
        End Set
    End Property
#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function




End Class


