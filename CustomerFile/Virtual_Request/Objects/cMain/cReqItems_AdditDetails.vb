Imports System
Public Class cReqItems_AdditLocation
    Implements ICloneable

    Private m_intAdditional_id As Integer
    Private m_intReqItemId As Integer 'come from ReqItems
    Private m_strReqItemGuid As String 'comme from ReqItems
    Private m_strGuid As String  'guid is generated each time when we add line in listview

    Private m_intDec_met_id As Integer
    Private m_intImp_desc_id As Integer

    ' Private m_strArea_Size As String

    Private m_intPatch_Color As Integer
    Private m_intPatchShape As Integer

    Private m_strImprintColor As String
    Private m_strImprintLogo As String

    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_dtCreateDate As Date

    Private m_intModifyBy As Integer
    Private m_strModifyByFullname As String
    Private m_dtModifyDate As Date

    '-------------- latest changes added three fields --------------------
    Private m_intThread_Color As Integer
    Private m_strBackGround_Color As String
    Private m_strStampingPattern As String

    Private m_strItemComment As String

    Sub New()
        Call Init()
        'Dim g As Guid
        'g = GUID.NewGuid
    End Sub

    Sub New(p_requestId As String)
        Call Init()
    End Sub

    Sub New(p_requestd As String, p_reviewId As String)
        Call Init()
    End Sub
    Private Sub Init()

        m_intAdditional_id = 0
        m_intReqItemId = 0
        m_strReqItemGuid = String.Empty

        m_strGuid = System.Guid.NewGuid.ToString()  'String.Empty

        m_intDec_met_id = 0
        m_intImp_desc_id = 0

        m_intPatch_Color = 0
        m_intPatchShape = 0

        m_strImprintColor = String.Empty
        m_strImprintLogo = String.Empty

        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreateDate = Date.Now

        m_intModifyBy = 0
        m_strModifyByFullname = String.Empty
        m_dtModifyDate = Date.Now

        'latest changes added 2.01.2018 (february)
        m_intThread_Color = 0
        m_strBackGround_Color = "Tone On Tone"
        m_strStampingPattern = String.Empty
        m_strItemComment = String.Empty
    End Sub

    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("Additional_Id").Equals(DBNull.Value)) Then m_intAdditional_id = pdrRow.Item("Additional_Id")
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then m_intReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("ReqItemGuid").Equals(DBNull.Value)) Then m_strReqItemGuid = pdrRow.Item("ReqItemGuid").ToString
            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then m_strGuid = pdrRow.Item("GUID").ToString

            If Not (pdrRow.Item("dec_met_id").Equals(DBNull.Value)) Then m_intDec_met_id = pdrRow.Item("dec_met_id")
            If Not (pdrRow.Item("imp_desc_id").Equals(DBNull.Value)) Then m_intImp_desc_id = pdrRow.Item("imp_desc_id")
            If Not (pdrRow.Item("patch_shape").Equals(DBNull.Value)) Then m_intPatchShape = pdrRow.Item("patch_shape")
            If Not (pdrRow.Item("patch_color").Equals(DBNull.Value)) Then m_intPatch_Color = pdrRow.Item("patch_color")

            If Not (pdrRow.Item("imprint_color").Equals(DBNull.Value)) Then m_strImprintColor = pdrRow.Item("imprint_color").ToString
            If Not (pdrRow.Item("imprint_logo").Equals(DBNull.Value)) Then m_strImprintLogo = pdrRow.Item("imprint_logo").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then m_intModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then m_strModifyByFullname = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then m_dtModifyDate = pdrRow.Item("ModifyDate").ToString

            If Not (pdrRow.Item("Thread_Color").Equals(DBNull.Value)) Then m_intThread_Color = pdrRow.Item("Thread_Color")
            If Not (pdrRow.Item("BackGround_Color").Equals(DBNull.Value)) Then m_strBackGround_Color = pdrRow.Item("BackGround_Color").ToString
            If Not (pdrRow.Item("StampingPattern").Equals(DBNull.Value)) Then m_strStampingPattern = pdrRow.Item("StampingPattern").ToString

            If Not (pdrRow.Item("ReqItemComm").Equals(DBNull.Value)) Then m_strItemComment = pdrRow.Item("ReqItemComm").ToString

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqItems_AdditLocation, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("Additional_Id").Equals(DBNull.Value)) Then pClass.Additional_ID = pdrRow.Item("Additional_Id")
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then pClass.ReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("ReqItemGuid").Equals(DBNull.Value)) Then pClass.ReqItemGuid = pdrRow.Item("ReqItemGuid").ToString

            If Not (pdrRow.Item("dec_met_id").Equals(DBNull.Value)) Then pClass.dec_met_id = pdrRow.Item("dec_met_id")
            If Not (pdrRow.Item("imp_desc_id").Equals(DBNull.Value)) Then pClass.imp_desc_id = pdrRow.Item("imp_desc_id")
            If Not (pdrRow.Item("patch_shape").Equals(DBNull.Value)) Then pClass.patch_shape = pdrRow.Item("patch_shape")
            If Not (pdrRow.Item("patch_color").Equals(DBNull.Value)) Then pClass.Patch_Color = pdrRow.Item("patch_color")
            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then pClass.GUID = pdrRow.Item("GUID").ToString

            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then pClass.ModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then pClass.ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then pClass.ModifyDate = pdrRow.Item("ModifyDate").ToString

            If Not (pdrRow.Item("imprint_color").Equals(DBNull.Value)) Then pClass.IMPRINT_COLOR = pdrRow.Item("imprint_color").ToString
            If Not (pdrRow.Item("imprint_logo").Equals(DBNull.Value)) Then pClass.IMPRINT_LOGO = pdrRow.Item("imprint_logo").ToString


            If Not (pdrRow.Item("Thread_Color").Equals(DBNull.Value)) Then pClass.Thread_Color = pdrRow.Item("Thread_Color")
            If Not (pdrRow.Item("BackGround_Color").Equals(DBNull.Value)) Then pClass.BackGround_Color = pdrRow.Item("BackGround_Color").ToString
            If Not (pdrRow.Item("StampingPattern").Equals(DBNull.Value)) Then pClass.StampingPattern = pdrRow.Item("StampingPattern").ToString

            If Not (pdrRow.Item("ReqItemComm").Equals(DBNull.Value)) Then pClass.ReqItemComm = pdrRow.Item("ReqItemComm").ToString


        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            '  If Not (pdrRow.Item("Additional_Id").Equals(DBNull.Value)) Then m_intAdditional_id = pdrRow.Item("Additional_Id")
            pdrRow.Item("ReqItemId") = m_intReqItemId
            pdrRow.Item("ReqItemGuid") = m_strReqItemGuid
            pdrRow.Item("GUID") = m_strGuid

            pdrRow.Item("dec_met_id") = m_intDec_met_id
            pdrRow.Item("imp_desc_id") = m_intImp_desc_id
            pdrRow.Item("patch_shape") = m_intPatchShape
            pdrRow.Item("patch_color") = m_intPatch_Color

            pdrRow.Item("imprint_color") = m_strImprintColor
            pdrRow.Item("imprint_logo") = m_strImprintLogo

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If m_intAdditional_id > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("Thread_Color") = m_intThread_Color
            pdrRow.Item("BackGround_Color") = m_strBackGround_Color
            pdrRow.Item("StampingPattern") = m_strStampingPattern
            pdrRow.Item("ReqItemComm") = m_strItemComment


        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqItems_AdditLocation, pdrRow As System.Data.DataRow)
        Try
            '  If Not (pdrRow.Item("Additional_Id").Equals(DBNull.Value)) Then pClass.ReqItemId = pdrRow.Item("Additional_Id")
            pdrRow.Item("ReqItemId") = pClass.ReqItemId
            pdrRow.Item("ReqItemGuid") = pClass.ReqItemGuid
            pdrRow.Item("GUID") = pClass.GUID

            pdrRow.Item("dec_met_id") = pClass.dec_met_id
            pdrRow.Item("imp_desc_id") = pClass.imp_desc_id
            pdrRow.Item("patch_shape") = pClass.patch_shape

            pdrRow.Item("patch_color") = pClass.Patch_Color

            pdrRow.Item("imprint_color") = pClass.IMPRINT_COLOR
            pdrRow.Item("imprint_logo") = pClass.IMPRINT_LOGO

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If pClass.Additional_ID > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("Thread_Color") = pClass.Thread_Color
            pdrRow.Item("BackGround_Color") = pClass.BackGround_Color
            pdrRow.Item("StampingPattern") = pClass.StampingPattern

            pdrRow.Item("ReqItemComm") = pClass.ReqItemComm

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "---------------------------------- Public Function ----------------------------------"
    Public Function Load(strQuery As String) As cReqItems_AdditLocation

        Load = New cReqItems_AdditLocation

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = strQuery
            '" SELECT * " &
            '" FROM   ReqItems_AdditLocation WITH (Nolock) "


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReqItems_AdditLocation)

        LoadLst = New List(Of cReqItems_AdditLocation)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqItems_AdditLocation)
            Dim i As Integer
            Dim strSql As String

            strSql = strQuery
            '  "SELECT * " &
            '  "FROM  " & strQuery

            '" WHERE  RequestId = " & pinReqId & " " &
            '  " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqItems_AdditLocation
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadLst(ByVal pinAdditionalId As Integer) As List(Of cReqItems_AdditLocation)

        LoadLst = New List(Of cReqItems_AdditLocation)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqItems_AdditLocation)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM ReqItems_AdditLocation WITH (Nolock) " &
              " WHERE  Additional_Id = " & pinAdditionalId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqItems_AdditLocation
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                " FROM   ReqItems_AdditLocation " &
                " WHERE Additional_Id = " & m_intAdditional_id

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

            ' If m_intReqItemId = 0 Then m_intReqItemId = db.DataTable("SELECT MAX(Cus_Prog_Id) AS Max_Cus_Prog_Id FROM MDB_CUS_PROG WITH (Nolock)").Rows(0).Item("Max_Cus_Prog_Id")


        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Save(ByRef pClass As cReqItems_AdditLocation) As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   ReqItems_AdditLocation where Additional_Id = " & pClass.Additional_ID

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

            db.DBDataAdapter.Update(db.DBDataTable)

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    'Public Function Delete() As Boolean
    '    Delete = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql =
    '            "DELETE FROM ReqItems_AdditLocation  WHERE  Additional_Id = " & m_intAdditional_id

    '        db.Execute(strSql)

    '        Delete = True

    '    Catch ex As Exception
    '        MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try
    'End Function
    Public Function Delete(ByRef pClass As cReqItems_AdditLocation) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqItems_AdditLocation " &
            " WHERE  Additional_Id = " & pClass.Additional_ID

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqItems_AdditLocation." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region

#Region "--------------------------------- Public Properties -----------------------------------"
    Public Property Additional_ID As Integer
        Get
            Return m_intAdditional_id
        End Get
        Set(value As Integer)
            m_intAdditional_id = value
        End Set
    End Property

    Public Property ReqItemId As Integer
        Get
            Return m_intReqItemId
        End Get
        Set(value As Integer)
            m_intReqItemId = value
        End Set
    End Property

    Public Property ReqItemGuid As String
        Get
            Return m_strReqItemGuid
        End Get
        Set(value As String)
            m_strReqItemGuid = value
        End Set
    End Property

    Public Property dec_met_id As Integer
        Get
            Return m_intDec_met_id
        End Get
        Set(value As Integer)
            m_intDec_met_id = value
        End Set
    End Property

    Public Property imp_desc_id As Integer
        Get
            Return m_intImp_desc_id
        End Get
        Set(value As Integer)
            m_intImp_desc_id = value
        End Set
    End Property
    Public Property patch_shape As Integer
        Get
            Return m_intPatchShape
        End Get
        Set(value As Integer)
            m_intPatchShape = value
        End Set
    End Property

    Public Property GUID As String
        Get
            Return m_strGuid
        End Get
        Set(value As String)
            m_strGuid = value
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
            Return m_dtCreateDate
        End Get
        Set(value As Date)
            m_dtCreateDate = value
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
            Return m_dtModifyDate
        End Get
        Set(value As Date)
            m_dtModifyDate = value
        End Set
    End Property
    Public Property IMPRINT_COLOR As String
        Get
            Return m_strImprintColor
        End Get
        Set(value As String)
            m_strImprintColor = value
        End Set
    End Property
    Public Property IMPRINT_LOGO As String
        Get
            Return m_strImprintLogo
        End Get
        Set(value As String)
            m_strImprintLogo = value
        End Set
    End Property
    Public Property Patch_Color As Integer
        Get
            Return m_intPatch_Color
        End Get
        Set(value As Integer)
            m_intPatch_Color = value
        End Set
    End Property
    Public Property Thread_Color As Integer
        Get
            Return m_intThread_Color
        End Get
        Set(value As Integer)
            m_intThread_Color = value
        End Set
    End Property
    Public Property BackGround_Color As String
        Get
            Return m_strBackGround_Color
        End Get
        Set(value As String)
            m_strBackGround_Color = value
        End Set
    End Property
    Public Property StampingPattern As String
        Get
            Return m_strStampingPattern
        End Get
        Set(value As String)
            m_strStampingPattern = value
        End Set
    End Property

    Public Property ReqItemComm As String
        Get
            Return m_strItemComment
        End Get
        Set(value As String)
            m_strItemComment = value
        End Set
    End Property
#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class
