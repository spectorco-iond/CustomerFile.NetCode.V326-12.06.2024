Imports System.Data.Odbc
Public Class cReqItems
    Implements ICloneable

    'Private m_strArea_Size As String
    Private m_intColorId As Integer
    Private m_intCreateBy As Integer
    Private m_strCreateByFullName As String
    Private m_dtCreateDate As Date
    Private m_intDec_met_id As Integer
    ' Private m_blDefaultLoc As Boolean
    Private m_strGuid As String
    Private m_intImp_desc_id As Integer
    Private m_strIs_Kit As String
    Private m_intItem_master_Id As Integer
    Private m_strItem_no As String
    Private m_strItemCd As String
    Private m_strMaco_Desc1 As String
    Private m_intModifyBy As Integer
    Private m_strModifyByFullname As String
    Private m_dtModifyDate As Date
    Private m_intRequestId As Integer
    Private m_strParent_Guid As String
    Private m_intPatchShape As Integer
    Private m_strProdCat As String
    Private m_intReqItemId As Integer
    Private m_ReviewId As Integer

    Private m_strImprintColor As String
    Private m_strImprintLogo As String

    Private m_intPatch_Color As Integer

    Private m_intThread_Color As Integer
    Private m_strBackGround_Color As String
    Private m_strStampingPattern As String


    Private m_strItemComment As String
    'only for internal use
    Private m_strAddi_Loc_Mess As String

    Sub New()
        Init()
    End Sub

    Sub New(p_requestId As String)
        Init()
    End Sub

    Sub New(p_requestd As String, p_reviewId As String)
        Init()
    End Sub
    Private Sub Init()
        m_intReqItemId = 0
        m_intRequestId = 0
        m_ReviewId = 0
        m_intItem_master_Id = 0
        m_strItemCd = String.Empty
        m_strIs_Kit = String.Empty
        m_strProdCat = String.Empty
        m_strMaco_Desc1 = String.Empty
        m_intColorId = 0
        m_strItem_no = String.Empty
        m_intDec_met_id = 0
        m_intImp_desc_id = 0
        'm_strArea_Size = String.Empty
        'm_blDefaultLoc = False
        m_intPatchShape = 0
        m_strGuid = String.Empty
        m_strParent_Guid = String.Empty

        m_intCreateBy = 0
        m_strCreateByFullName = String.Empty
        m_dtCreateDate = Date.Now

        m_intModifyBy = 0
        m_strModifyByFullname = String.Empty
        m_dtModifyDate = Date.Now

        m_strImprintColor = String.Empty
        m_strImprintLogo = String.Empty

        m_intPatch_Color = 0

        'latest changes added 2.01.2018 (february)
        m_intThread_Color = 0
        m_strBackGround_Color = String.Empty
        m_strStampingPattern = String.Empty

        m_strItemComment = String.Empty

        m_strAddi_Loc_Mess = String.Empty
    End Sub

    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then m_intReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then m_ReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("item_master_id").Equals(DBNull.Value)) Then m_intItem_master_Id = pdrRow.Item("item_master_id")
            If Not (pdrRow.Item("ItemCd").Equals(DBNull.Value)) Then m_strItemCd = pdrRow.Item("ItemCd").ToString
            If Not (pdrRow.Item("Is_Kit").Equals(DBNull.Value)) Then m_strIs_Kit = pdrRow.Item("Is_Kit").ToString
            If Not (pdrRow.Item("prod_category").Equals(DBNull.Value)) Then m_strProdCat = pdrRow.Item("prod_category").ToString
            If Not (pdrRow.Item("Maco_desc1").Equals(DBNull.Value)) Then m_strMaco_Desc1 = pdrRow.Item("Maco_desc1").ToString
            If Not (pdrRow.Item("color_id").Equals(DBNull.Value)) Then m_intColorId = pdrRow.Item("color_id")
            If Not (pdrRow.Item("item_no").Equals(DBNull.Value)) Then m_strItem_no = pdrRow.Item("item_no").ToString
            If Not (pdrRow.Item("dec_met_id").Equals(DBNull.Value)) Then m_intDec_met_id = pdrRow.Item("dec_met_id")
            If Not (pdrRow.Item("imp_desc_id").Equals(DBNull.Value)) Then m_intImp_desc_id = pdrRow.Item("imp_desc_id")
            If Not (pdrRow.Item("patch_shape").Equals(DBNull.Value)) Then m_intPatchShape = pdrRow.Item("patch_shape")
            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then m_strGuid = pdrRow.Item("GUID").ToString
            If Not (pdrRow.Item("parent_guid").Equals(DBNull.Value)) Then m_strParent_Guid = pdrRow.Item("parent_guid").ToString
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then m_intCreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then m_strCreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_dtCreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then m_intModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then m_strModifyByFullname = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then m_dtModifyDate = pdrRow.Item("ModifyDate").ToString

            If Not (pdrRow.Item("imprint_color").Equals(DBNull.Value)) Then m_strImprintColor = pdrRow.Item("imprint_color").ToString
            If Not (pdrRow.Item("imprint_logo").Equals(DBNull.Value)) Then m_strImprintLogo = pdrRow.Item("imprint_logo").ToString

            If Not (pdrRow.Item("patch_color").Equals(DBNull.Value)) Then m_intPatch_Color = pdrRow.Item("patch_color")

            If Not (pdrRow.Item("Thread_Color").Equals(DBNull.Value)) Then m_intThread_Color = pdrRow.Item("Thread_Color")
            If Not (pdrRow.Item("BackGround_Color").Equals(DBNull.Value)) Then m_strBackGround_Color = pdrRow.Item("BackGround_Color").ToString
            If Not (pdrRow.Item("StampingPattern").Equals(DBNull.Value)) Then m_strStampingPattern = pdrRow.Item("StampingPattern").ToString


            If Not (pdrRow.Item("ReqItemComm").Equals(DBNull.Value)) Then m_strItemComment = pdrRow.Item("ReqItemComm").ToString

            If Not (pdrRow.Item("Addi_Loc_Mess").Equals(DBNull.Value)) Then m_strAddi_Loc_Mess = pdrRow.Item("Addi_Loc_Mess").ToString

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub LoadLine(ByRef pClass As CustomerFile.cReqItems, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then pClass.ReqItemId = pdrRow.Item("ReqItemId")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then pClass.ReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("item_master_id").Equals(DBNull.Value)) Then pClass.item_master_id = pdrRow.Item("item_master_id")
            If Not (pdrRow.Item("ItemCd").Equals(DBNull.Value)) Then pClass.ItemCd = pdrRow.Item("ItemCd").ToString
            If Not (pdrRow.Item("Is_Kit").Equals(DBNull.Value)) Then pClass.Is_Kit = pdrRow.Item("Is_Kit").ToString
            If Not (pdrRow.Item("prod_category").Equals(DBNull.Value)) Then pClass.prod_category = pdrRow.Item("prod_category").ToString
            If Not (pdrRow.Item("Maco_desc1").Equals(DBNull.Value)) Then pClass.Maco_desc1 = pdrRow.Item("Maco_desc1").ToString
            If Not (pdrRow.Item("color_id").Equals(DBNull.Value)) Then pClass.color_id = pdrRow.Item("color_id")
            If Not (pdrRow.Item("item_no").Equals(DBNull.Value)) Then pClass.item_no = pdrRow.Item("item_no").ToString
            If Not (pdrRow.Item("dec_met_id").Equals(DBNull.Value)) Then pClass.dec_met_id = pdrRow.Item("dec_met_id")
            If Not (pdrRow.Item("imp_desc_id").Equals(DBNull.Value)) Then pClass.imp_desc_id = pdrRow.Item("imp_desc_id")
            If Not (pdrRow.Item("patch_shape").Equals(DBNull.Value)) Then pClass.patch_shape = pdrRow.Item("patch_shape")
            If Not (pdrRow.Item("GUID").Equals(DBNull.Value)) Then pClass.GUID = pdrRow.Item("GUID").ToString
            If Not (pdrRow.Item("parent_guid").Equals(DBNull.Value)) Then pClass.parent_guid = pdrRow.Item("parent_guid").ToString
            If Not (pdrRow.Item("CreateBy").Equals(DBNull.Value)) Then pClass.CreateBy = pdrRow.Item("CreateBy")
            If Not (pdrRow.Item("CreateByFullName").Equals(DBNull.Value)) Then pClass.CreateByFullName = pdrRow.Item("CreateByFullName").ToString
            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then pClass.CreateDate = pdrRow.Item("CreateDate").ToString
            If Not (pdrRow.Item("ModifyBy").Equals(DBNull.Value)) Then pClass.ModifyBy = pdrRow.Item("ModifyBy")
            If Not (pdrRow.Item("ModifyByFullName").Equals(DBNull.Value)) Then pClass.ModifyByFullName = pdrRow.Item("ModifyByFullName").ToString
            If Not (pdrRow.Item("ModifyDate").Equals(DBNull.Value)) Then pClass.ModifyDate = pdrRow.Item("ModifyDate").ToString

            If Not (pdrRow.Item("imprint_color").Equals(DBNull.Value)) Then pClass.IMPRINT_COLOR = pdrRow.Item("imprint_color").ToString
            If Not (pdrRow.Item("imprint_logo").Equals(DBNull.Value)) Then pClass.IMPRINT_LOGO = pdrRow.Item("imprint_logo").ToString

            If Not (pdrRow.Item("patch_color").Equals(DBNull.Value)) Then pClass.Patch_Color = pdrRow.Item("patch_color")

            If Not (pdrRow.Item("Thread_Color").Equals(DBNull.Value)) Then pClass.Thread_Color = pdrRow.Item("Thread_Color")
            If Not (pdrRow.Item("BackGround_Color").Equals(DBNull.Value)) Then pClass.BackGround_Color = pdrRow.Item("BackGround_Color").ToString
            If Not (pdrRow.Item("StampingPattern").Equals(DBNull.Value)) Then pClass.StampingPattern = pdrRow.Item("StampingPattern").ToString

            If Not (pdrRow.Item("ReqItemComm").Equals(DBNull.Value)) Then pClass.ReqItemComm = pdrRow.Item("ReqItemComm").ToString

            If pdrRow.Item("Addit_Loc_Mess") Is Nothing Then Exit Sub
            If Not (pdrRow.Item("Addit_Loc_Mess").Equals(DBNull.Value)) Then pClass.Addit_Loc_Mess = pdrRow.Item("Addit_Loc_Mess").ToString

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As System.Data.DataRow)
        Try
            '    pdrRow.Item("ReqItemId") = m_intReqItemId
            pdrRow.Item("RequestId") = m_intRequestId
            pdrRow.Item("ReviewId") = m_ReviewId
            pdrRow.Item("item_master_id") = m_intItem_master_Id
            pdrRow.Item("ItemCd") = m_strItemCd
            pdrRow.Item("Is_Kit") = m_strIs_Kit
            pdrRow.Item("prod_category") = m_strProdCat
            pdrRow.Item("Maco_desc1") = m_strMaco_Desc1
            pdrRow.Item("color_id") = m_intColorId
            pdrRow.Item("item_no") = m_strItem_no
            pdrRow.Item("dec_met_id") = m_intDec_met_id
            pdrRow.Item("imp_desc_id") = m_intImp_desc_id
            pdrRow.Item("patch_shape") = m_intPatchShape
            pdrRow.Item("GUID") = m_strGuid
            pdrRow.Item("parent_guid") = m_strParent_Guid

            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then m_intReqItemId = pdrRow.Item("ReqItemId")

            oExact_Traveler_Permission = New cExact_Traveler_Permission

            If m_intReqItemId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("imprint_color") = m_strImprintColor
            pdrRow.Item("imprint_logo") = m_strImprintLogo

            pdrRow.Item("patch_color") = m_intPatch_Color

            pdrRow.Item("Thread_Color") = m_intThread_Color
            pdrRow.Item("BackGround_Color") = m_strBackGround_Color
            pdrRow.Item("StampingPattern") = m_strStampingPattern

            pdrRow.Item("ReqItemComm") = m_strItemComment

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As CustomerFile.cReqItems, pdrRow As System.Data.DataRow)
        Try
            '   pdrRow.Item("ReqItemId") = pClass.ReqItemId
            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("ReviewId") = pClass.ReviewId
            pdrRow.Item("item_master_id") = pClass.item_master_id
            pdrRow.Item("ItemCd") = pClass.ItemCd
            pdrRow.Item("Is_Kit") = pClass.Is_Kit
            pdrRow.Item("prod_category") = pClass.prod_category
            pdrRow.Item("Maco_desc1") = pClass.Maco_desc1
            pdrRow.Item("color_id") = pClass.color_id
            pdrRow.Item("item_no") = pClass.item_no
            pdrRow.Item("dec_met_id") = pClass.dec_met_id
            pdrRow.Item("imp_desc_id") = pClass.imp_desc_id
            pdrRow.Item("patch_shape") = pClass.patch_shape
            pdrRow.Item("GUID") = pClass.GUID
            pdrRow.Item("parent_guid") = pClass.parent_guid

            oExact_Traveler_Permission = New cExact_Traveler_Permission
            If Not (pdrRow.Item("ReqItemId").Equals(DBNull.Value)) Then pClass.ReqItemId = pdrRow.Item("ReqItemId")
            If pClass.ReqItemId > 0 Then
                pdrRow.Item("ModifyBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("ModifyByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("ModifyDate") = DateNow()
            Else
                pdrRow.Item("CreateBy") = oExact_Traveler_Permission.ID
                pdrRow.Item("CreateByFullName") = oExact_Traveler_Permission.Fullname
                pdrRow.Item("CreateDate") = DateNow()
            End If

            pdrRow.Item("imprint_color") = pClass.IMPRINT_COLOR
            pdrRow.Item("imprint_logo") = pClass.IMPRINT_LOGO

            pdrRow.Item("patch_color") = pClass.Patch_Color

            pdrRow.Item("Thread_Color") = pClass.Thread_Color
            pdrRow.Item("BackGround_Color") = pClass.BackGround_Color
            pdrRow.Item("StampingPattern") = pClass.StampingPattern

            pdrRow.Item("ReqItemComm") = pClass.ReqItemComm



        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    '
    'm_intReqItemId 
    '  m_intRequestId 
    '  m_ReviewId 
    '  m_intItem_master_Id 
    '  m_strItemCd 
    '  m_strIs_Kit 
    '  m_strProdCat 
    '  m_strMaco_Desc1 
    '  m_intColorId 
    '  m_strItem_no 
    '  m_intDec_met_id 
    '  m_intImp_desc_id 
    '  m_strArea_Size 
    '  m_blDefaultLoc 
    '  m_intPatchShape 
    '  m_strGuid 
    '  m_strParent_Guid 

    '  m_intCreateBy 
    '  m_strCreateByFullName 
    '  m_dtCreateDate 

    '  m_intModifyBy 
    '  m_strModifyByFullname 
    '  m_dtModifyDate = Date.Now
    '

#Region "---------------------------------- Public Properties ----------------------------------"
    Public Function Load(ByVal pinReqId As Integer, ByVal pintReviewID As Integer) As cReqItems

        Load = New cReqItems

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              " SELECT * ,Addit_Loc_Mess = '' " &
              " FROM   ReqItems WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId & " " &
              " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function LoadLst(strQuery As String) As List(Of cReqItems)

        LoadLst = New List(Of cReqItems)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqItems)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT *,Addit_Loc_Mess = '' " &
              "FROM ReqItems WITH (Nolock) " & strQuery

            '" WHERE  RequestId = " & pinReqId & " " &
            '  " and reviewId = " & pintReviewID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqItems
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function LoadLst_ForEmail(strQuery As String) As List(Of cReqItems)

        LoadLst_ForEmail = New List(Of cReqItems)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqItems)
            Dim i As Integer
            Dim strSql As String

            strSql = strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqItems
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst_ForEmail = myList

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function LoadLst(ByVal pinReqId As Integer) As List(Of cReqItems)

        LoadLst = New List(Of cReqItems)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cReqItems)
            Dim i As Integer
            Dim strSql As String

            strSql =
              "SELECT *,Addit_Loc_Mess = '' " &
              "FROM ReqItems WITH (Nolock) " &
              " WHERE  RequestId = " & pinReqId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cReqItems
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                " FROM   ReqItems " &
                " WHERE ReqItemId = " & m_intReqItemId

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

            If m_intReqItemId = 0 Then m_intReqItemId = db.DataTable("SELECT MAX(ReqItemId ) AS ReqItemId FROM ReqItems WITH (Nolock)").Rows(0).Item("ReqItemId")


        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
    Public Function Save(pClass As cReqItems) As Boolean
        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow
            Dim strSql As String

            strSql =
                "SELECT * " &
                " FROM   ReqItems " &
                " WHERE ReviewID = " & pClass.ReviewId & " " &
                " AND RequestId = " & pClass.RequestId

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
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function Delete() As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqItems  WHERE  ReqItemId = " & m_intReqItemId

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete(pReqItemID As Integer) As Boolean
        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                "DELETE FROM ReqItems " &
            " WHERE  ReqItemId = " & pReqItemID

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cReqItems." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region

#Region "--------------------------------- Public Properties -----------------------------------"
    Public Property ReqItemId As Integer
        Get
            Return m_intReqItemId
        End Get
        Set(value As Integer)
            m_intReqItemId = value
        End Set
    End Property

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
            Return m_ReviewId
        End Get
        Set(value As Integer)
            m_ReviewId = value
        End Set
    End Property

    Public Property item_master_id As Integer
        Get
            Return m_intItem_master_Id
        End Get
        Set(value As Integer)
            m_intItem_master_Id = value
        End Set
    End Property

    Public Property ItemCd As String
        Get
            Return m_strItemCd
        End Get
        Set(value As String)
            m_strItemCd = value
        End Set
    End Property

    Public Property prod_category As String
        Get
            Return m_strProdCat
        End Get
        Set(value As String)
            m_strProdCat = value
        End Set
    End Property

    Public Property Is_Kit As String
        Get
            Return m_strIs_Kit
        End Get
        Set(value As String)
            m_strIs_Kit = value
        End Set
    End Property

    Public Property color_id As Integer
        Get
            Return m_intColorId
        End Get
        Set(value As Integer)
            m_intColorId = value
        End Set
    End Property

    Public Property item_no As String
        Get
            Return m_strItem_no
        End Get
        Set(value As String)
            m_strItem_no = value
        End Set
    End Property

    Public Property Maco_desc1 As String
        Get
            Return m_strMaco_Desc1
        End Get
        Set(value As String)
            m_strMaco_Desc1 = value
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

    Public Property parent_guid As String
        Get
            Return m_strParent_Guid
        End Get
        Set(value As String)
            m_strParent_Guid = value
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
    'Only for internal use , dont entered in DB
    Public Property Addit_Loc_Mess As String
        Get
            Return m_strAddi_Loc_Mess
        End Get
        Set(value As String)
            m_strAddi_Loc_Mess = value
        End Set
    End Property

#End Region
    Public Function Clone() As Object Implements ICloneable.Clone
        Throw New NotImplementedException()
    End Function
End Class


