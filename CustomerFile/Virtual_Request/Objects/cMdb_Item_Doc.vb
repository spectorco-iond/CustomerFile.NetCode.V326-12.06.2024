Imports System.Data.Odbc

Public Class cMdb_Item_Doc
    Implements ICloneable


#Region "private variables #################################################"

    Private m_intItem_Doc_Id As Int32
    Private m_intItem_Id As Int32
    Private m_intColor_Id As Int32
    Private m_strItem_Doc_Desc As String
    Private m_strItem_Doc_Desc_Fr As String
    Private m_strDoc_Lang As String
    Private m_intItem_Doc_Type_Id As Int32
    Private m_bItem_Doc As Byte()
    Private m_strItem_Doc_Folder As String
    Private m_strItem_Doc_Name As String
    Private m_strItem_Doc_File_Ext As String
    Private m_intDec_Met_Id As Int32
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime
    Private m_intItem_loc As Int32
    Private m_intRequestId As Integer
    Private m_intreviewId As Integer
    Private m_strReq_Guid As String

#End Region

#Region "-------------------- Private Function ---------------------------"

    Private Sub LoadLine(pdrRow As DataRow)
        Try

            If Not (pdrRow.Item("Item_Doc_Id").Equals(DBNull.Value)) Then m_intItem_Doc_Id = pdrRow.Item("Item_Doc_Id")
            If Not (pdrRow.Item("Item_Id").Equals(DBNull.Value)) Then m_intItem_Id = pdrRow.Item("Item_Id")
            If Not (pdrRow.Item("Color_Id").Equals(DBNull.Value)) Then m_intColor_Id = pdrRow.Item("Color_Id")
            If Not (pdrRow.Item("Item_Doc_Desc").Equals(DBNull.Value)) Then m_strItem_Doc_Desc = pdrRow.Item("Item_Doc_Desc").ToString
            If Not (pdrRow.Item("Item_Doc_Desc_Fr").Equals(DBNull.Value)) Then m_strItem_Doc_Desc_Fr = pdrRow.Item("Item_Doc_Desc_Fr").ToString
            If Not (pdrRow.Item("Doc_Lang").Equals(DBNull.Value)) Then m_strDoc_Lang = pdrRow.Item("Doc_Lang").ToString
            If Not (pdrRow.Item("Item_Doc_Type_Id").Equals(DBNull.Value)) Then m_intItem_Doc_Type_Id = pdrRow.Item("Item_Doc_Type_Id")
            If Not (pdrRow.Item("Item_Doc").Equals(DBNull.Value)) Then m_bItem_Doc = pdrRow.Item("Item_Doc")
            If Not (pdrRow.Item("Item_Doc_Folder").Equals(DBNull.Value)) Then m_strItem_Doc_Folder = pdrRow.Item("Item_Doc_Folder").ToString
            If Not (pdrRow.Item("Item_Doc_Name").Equals(DBNull.Value)) Then m_strItem_Doc_Name = pdrRow.Item("Item_Doc_Name").ToString.Replace("?", "")
            If Not (pdrRow.Item("Item_Doc_File_Ext").Equals(DBNull.Value)) Then m_strItem_Doc_File_Ext = pdrRow.Item("Item_Doc_File_Ext").ToString
            If Not (pdrRow.Item("Dec_Met_Id").Equals(DBNull.Value)) Then m_intDec_Met_Id = pdrRow.Item("Dec_Met_Id")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")
            If Not (pdrRow.Item("ITEM_LOCATION").Equals(DBNull.Value)) Then m_intItem_loc = pdrRow.Item("ITEM_LOCATION")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then m_intRequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then m_intreviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("Req_Guid").Equals(DBNull.Value)) Then m_intreviewId = pdrRow.Item("Req_Guid").ToString

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub LoadLine(pClass As cMdb_Item_Doc, ByRef pdrRow As DataRow)
        Try

            If Not (pdrRow.Item("Item_Doc_Id").Equals(DBNull.Value)) Then pClass.Item_Doc_Id = pdrRow.Item("Item_Doc_Id")
            If Not (pdrRow.Item("Item_Id").Equals(DBNull.Value)) Then pClass.Item_Id = pdrRow.Item("Item_Id")
            If Not (pdrRow.Item("Color_Id").Equals(DBNull.Value)) Then pClass.Color_Id = pdrRow.Item("Color_Id")
            If Not (pdrRow.Item("Item_Doc_Desc").Equals(DBNull.Value)) Then pClass.Item_Doc_Desc = pdrRow.Item("Item_Doc_Desc").ToString
            If Not (pdrRow.Item("Item_Doc_Desc_Fr").Equals(DBNull.Value)) Then pClass.Item_Doc_Desc_Fr = pdrRow.Item("Item_Doc_Desc_Fr").ToString
            If Not (pdrRow.Item("Doc_Lang").Equals(DBNull.Value)) Then pClass.Doc_Lang = pdrRow.Item("Doc_Lang").ToString
            If Not (pdrRow.Item("Item_Doc_Type_Id").Equals(DBNull.Value)) Then pClass.Item_Doc_Type_Id = pdrRow.Item("Item_Doc_Type_Id")
            If Not (pdrRow.Item("Item_Doc").Equals(DBNull.Value)) Then pClass.Item_Doc = pdrRow.Item("Item_Doc")
            If Not (pdrRow.Item("Item_Doc_Folder").Equals(DBNull.Value)) Then pClass.Item_Doc_Folder = pdrRow.Item("Item_Doc_Folder").ToString
            If Not (pdrRow.Item("Item_Doc_Name").Equals(DBNull.Value)) Then pClass.Item_Doc_Name = pdrRow.Item("Item_Doc_Name").ToString.Replace("?", "")
            If Not (pdrRow.Item("Item_Doc_File_Ext").Equals(DBNull.Value)) Then pClass.Item_Doc_File_Ext = pdrRow.Item("Item_Doc_File_Ext").ToString
            If Not (pdrRow.Item("Dec_Met_Id").Equals(DBNull.Value)) Then pClass.Dec_Met_Id = pdrRow.Item("Dec_Met_Id")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then pClass.User_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then pClass.Create_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then pClass.Update_Ts = pdrRow.Item("Update_Ts")
            If Not (pdrRow.Item("ITEM_LOCATION").Equals(DBNull.Value)) Then pClass.ITEM_LOC = pdrRow.Item("ITEM_LOCATION")
            If Not (pdrRow.Item("RequestId").Equals(DBNull.Value)) Then pClass.RequestId = pdrRow.Item("RequestId")
            If Not (pdrRow.Item("ReviewId").Equals(DBNull.Value)) Then pClass.ReviewId = pdrRow.Item("ReviewId")
            If Not (pdrRow.Item("Req_Guid").Equals(DBNull.Value)) Then pClass.Req_Guid = pdrRow.Item("Req_Guid").ToString

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(pdrRow As DataRow)
        Try

            'pdrRow.Item("Item_Doc_Id") = pClass.Item_Doc_Id
            pdrRow.Item("Item_Id") = m_intItem_Id
            pdrRow.Item("Color_Id") = m_intColor_Id
            pdrRow.Item("Item_Doc_Desc") = m_strItem_Doc_Desc
            pdrRow.Item("Item_Doc_Desc_Fr") = m_strItem_Doc_Desc_Fr
            pdrRow.Item("Doc_Lang") = m_strDoc_Lang
            pdrRow.Item("Item_Doc_Type_Id") = m_intItem_Doc_Type_Id
            '  If pdrRow.Item("Item_Doc_Id") Is DBNull.Value Then
            pdrRow.Item("Item_Doc") = m_bItem_Doc
            '   End If
            pdrRow.Item("Item_Doc_Folder") = m_strItem_Doc_Folder
            pdrRow.Item("Item_Doc_Name") = m_strItem_Doc_Name.Replace("?", "")
            pdrRow.Item("Item_Doc_File_Ext") = m_strItem_Doc_File_Ext
            pdrRow.Item("Dec_Met_Id") = m_intDec_Met_Id

            pdrRow.Item("User_Login") = Environment.UserName

            pdrRow.Item("Update_Ts") = Date.Now.ToString("MM/dd/yyyy HHH:mm:ss")
            pdrRow.Item("ITEM_LOCATION") = m_intItem_loc
            pdrRow.Item("RequestId") = m_intRequestId
            pdrRow.Item("ReviewId") = m_intreviewId
            pdrRow.Item("Req_Guid") = m_strReq_Guid

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SaveLine(ByRef pClass As cMdb_Item_Doc, ByRef pdrRow As DataRow)
        Try

            'pdrRow.Item("Item_Doc_Id") = pClass.Item_Doc_Id
            pdrRow.Item("Item_Id") = pClass.Item_Id
            pdrRow.Item("Color_Id") = pClass.Color_Id
            pdrRow.Item("Item_Doc_Desc") = pClass.Item_Doc_Desc
            pdrRow.Item("Item_Doc_Desc_Fr") = pClass.Item_Doc_Desc_Fr
            pdrRow.Item("Doc_Lang") = pClass.Doc_Lang
            pdrRow.Item("Item_Doc_Type_Id") = pClass.Item_Doc_Type_Id
            If pdrRow.Item("Item_Doc_Id") Is DBNull.Value Then
                pdrRow.Item("Item_Doc") = pClass.Item_Doc
            End If
            pdrRow.Item("Item_Doc_Folder") = pClass.Item_Doc_Folder
            pdrRow.Item("Item_Doc_Name") = pClass.Item_Doc_Name.Replace("?", "")
            pdrRow.Item("Item_Doc_File_Ext") = pClass.Item_Doc_File_Ext
            pdrRow.Item("Dec_Met_Id") = pClass.Dec_Met_Id

            pClass.User_Login = Environment.UserName
            pdrRow.Item("User_Login") = pClass.User_Login
            pClass.Update_Ts = Date.Now.ToString("MM/dd/yyyy HHH:mm:ss")
            pdrRow.Item("Update_Ts") = pClass.Update_Ts
            pdrRow.Item("ITEM_LOCATION") = pClass.ITEM_LOC
            pdrRow.Item("RequestId") = pClass.RequestId
            pdrRow.Item("ReviewId") = pClass.ReviewId '
            pdrRow.Item("Req_Guid") = pClass.ReviewId

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "---------------------------- Public function -------------------------------"
    Public Function Load(strQuery As String) As Boolean
        Load = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM   Mdb_Item_Doc WITH (Nolock) " & strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Load(ByVal pintID As Integer) As cMdb_Item_Doc
        Load = New cMdb_Item_Doc()
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
              "SELECT * " &
              "FROM   Mdb_Item_Doc WITH (Nolock) " &
              "WHERE  Item_Doc_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadList(strQuery As String) As List(Of cMdb_Item_Doc)
        LoadList = New List(Of cMdb_Item_Doc)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Doc)
            Dim i As Integer
            Dim strSql As String

            strSql =
              " SELECT * " &
              " FROM   Mdb_Item_Doc WITH (Nolock) " & strQuery


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Item_Doc
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadList = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    'show all documents by request and revision 
    Public Function GetList(ByVal pintRequestId As Int32, ByVal pintRevisionId As Int32) As List(Of cMdb_Item_Doc)
        GetList = New List(Of cMdb_Item_Doc)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Item_Doc)
            Dim i As Integer
            Dim strSql As String


            strSql =
              "SELECT * " &
              "FROM   Mdb_Item_Doc WITH (Nolock) " &
              " WHERE requestId = " & pintRequestId & " and reviewId = " & pintRevisionId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Item_Doc
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save() As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = " SELECT * " _
                   & " FROM Mdb_Item_Doc WITH (Nolock)" _
                   & " WHERE  Item_Doc_Id = " & m_intItem_Doc_Id

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
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Save(ByVal pClass As cMdb_Item_Doc) As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = " SELECT * " _
                   & " FROM Mdb_Item_Doc WITH (Nolock) " _
                   & " WHERE  Item_Doc_Id = " & pClass.Item_Doc_Id

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
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete() As Boolean

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                    "DELETE FROM Mdb_Item_Doc " &
                      "WHERE  Item_Doc_Id = " & m_intItem_Doc_Id & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Delete(pintID As Integer) As Boolean

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                    "DELETE FROM Mdb_Item_Doc " &
                  "WHERE  Item_Doc_Id = " & pintID & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Item_Doc." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function
#End Region
#Region "Public properties ################################################"

    Public Property Item_Doc_Id() As Int32
        Get
            Item_Doc_Id = m_intItem_Doc_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Doc_Id = value
        End Set
    End Property

    Public Property Item_Id() As Int32
        Get
            Item_Id = m_intItem_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Id = value
        End Set
    End Property

    Public Property Color_Id() As Int32
        Get
            Color_Id = m_intColor_Id
        End Get
        Set(ByVal value As Int32)
            m_intColor_Id = value
        End Set
    End Property

    Public Property Item_Doc_Desc() As String
        Get
            Item_Doc_Desc = m_strItem_Doc_Desc
        End Get
        Set(ByVal value As String)
            m_strItem_Doc_Desc = value
        End Set
    End Property

    Public Property Item_Doc_Desc_Fr() As String
        Get
            Item_Doc_Desc_Fr = m_strItem_Doc_Desc_Fr
        End Get
        Set(ByVal value As String)
            m_strItem_Doc_Desc_Fr = value
        End Set
    End Property

    Public Property Doc_Lang() As String
        Get
            Doc_Lang = m_strDoc_Lang
        End Get
        Set(ByVal value As String)
            m_strDoc_Lang = value
        End Set
    End Property

    Public Property Item_Doc_Type_Id() As Int32
        Get
            Item_Doc_Type_Id = m_intItem_Doc_Type_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Doc_Type_Id = value
        End Set
    End Property

    Public Property Item_Doc() As Byte()
        Get
            Item_Doc = m_bItem_Doc
        End Get
        Set(ByVal value As Byte())
            m_bItem_Doc = value
        End Set
    End Property

    Public Property Item_Doc_Folder() As String
        Get
            Item_Doc_Folder = m_strItem_Doc_Folder
        End Get
        Set(ByVal value As String)
            m_strItem_Doc_Folder = value
        End Set
    End Property

    Public Property Item_Doc_Name() As String
        Get
            Item_Doc_Name = m_strItem_Doc_Name
        End Get
        Set(ByVal value As String)
            m_strItem_Doc_Name = value
        End Set
    End Property

    Public Property Item_Doc_File_Ext() As String
        Get
            Item_Doc_File_Ext = m_strItem_Doc_File_Ext
        End Get
        Set(ByVal value As String)
            m_strItem_Doc_File_Ext = value
        End Set
    End Property

    Public Property Dec_Met_Id() As Int32
        Get
            Dec_Met_Id = m_intDec_Met_Id
        End Get
        Set(ByVal value As Int32)
            m_intDec_Met_Id = value
        End Set
    End Property

    Public Property User_Login() As String
        Get
            User_Login = m_strUser_Login
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
        End Set
    End Property

    Public Property Create_Ts() As DateTime
        Get
            Create_Ts = m_dtCreate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtCreate_Ts = value
        End Set
    End Property

    Public Property Update_Ts() As DateTime
        Get
            Update_Ts = m_dtUpdate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_Ts = value
        End Set
    End Property
    Public Property ITEM_LOC As Int32
        Get
            ITEM_LOC = m_intItem_loc
        End Get
        Set(value As Int32)
            m_intItem_loc = value
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
            Return m_intreviewId
        End Get
        Set(value As Integer)
            m_intreviewId = value
        End Set
    End Property
    Public Property Req_Guid() As String
        Get
            Return m_strReq_Guid
        End Get
        Set(value As String)
            m_strReq_Guid = value
        End Set
    End Property

#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class ' cMdb_Item_Doc


