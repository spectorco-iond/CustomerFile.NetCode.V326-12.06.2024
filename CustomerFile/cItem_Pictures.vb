Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Text

' Insert Include here

Public Class cItem_Pictures


#Region "private variables #################################################"

    Private m_strItem_No As String
    Private m_strCatalog_Item_Num As String
    Private m_intW_Pixels As Integer
    Private m_intH_Pixels As Integer
    Private m_intOEI_W_Pixels As Integer
    Private m_intOEI_H_Pixels As Integer
    Private m_strRotate As String
    Private m_DocFile As FileInfo

#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pItem_No As String)

        Try

            Call Init()
            Call Load(pItem_No)

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pItem_Cd As String, ByVal pItem_Color As String)

        Try

            Call Init()
            Call Load(pItem_Cd, pItem_Color)

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    'Public Sub New(ByVal pPath As String)

    '    Try

    '        Call Init()

    '        m_FileUpload = New ADODB.Stream
    '        m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
    '        m_FileUpload.Open()
    '        m_FileUpload.LoadFromFile(pPath)

    '        m_strCatalog_Item_Num = pPath.Substring(pPath.LastIndexOf("\") + 1)
    '        m_strRotate = pPath
    '        m_strDocument_Ext = pPath.Substring(pPath.LastIndexOf(".") + 1)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    'Public Sub New(ByVal pEmail As Stream)

    '    Try

    '        Call Init()


    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intW_Pixels = 0
            m_intH_Pixels = 0
            m_strItem_No = String.Empty
            m_intOEI_W_Pixels = 0
            m_intOEI_H_Pixels = 0
            m_strCatalog_Item_Num = String.Empty
            m_strRotate = String.Empty
            'm_strDocument_Ext = String.Empty
            'm_strCus_Prog_Guid = String.Empty

            'm_strUser_Login = String.Empty
            'm_dtCreate_Ts = NoDate()
            'm_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            'If Not (pdrRow.Item("W_Pixels").Equals(DBNull.Value)) Then m_intW_Pixels = pdrRow.Item("W_Pixels")
            'If Not (pdrRow.Item("H_Pixels").Equals(DBNull.Value)) Then m_intH_Pixels = pdrRow.Item("H_Pixels")
            'If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then m_strItem_No = pdrRow.Item("Item_No").ToString
            'If Not (pdrRow.Item("OEI_W_Pixels").Equals(DBNull.Value)) Then m_intOEI_W_Pixels = pdrRow.Item("OEI_W_Pixels")
            'If Not (pdrRow.Item("OEI_H_Pixels").Equals(DBNull.Value)) Then m_intOEI_H_Pixels = pdrRow.Item("OEI_H_Pixels")
            'If Not (pdrRow.Item("Catalog_Item_Num").Equals(DBNull.Value)) Then m_strCatalog_Item_Num = pdrRow.Item("Catalog_Item_Num").ToString
            'If Not (pdrRow.Item("Rotate").Equals(DBNull.Value)) Then m_strRotate = pdrRow.Item("Rotate").ToString
            'm_DocFile = New FileInfo(m_strRotate)
            'End If
            'If Not (pdrRow.Item("Document_Ext").Equals(DBNull.Value)) Then m_strDocument_Ext = pdrRow.Item("Document_Ext").ToString
            'If Not (pdrRow.Item("Document_Data").Equals(DBNull.Value)) Then m_bDocument_Data = pdrRow.Item("Document_Data")
            'If Not (pdrRow.Item("Cus_Prog_Guid").Equals(DBNull.Value)) Then m_strCus_Prog_Guid = pdrRow.Item("Cus_Prog_Guid").ToString
            'If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            'If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_Ts = pdrRow.Item("Create_Ts")
            'If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

            If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then m_strItem_No = pdrRow.Item("item_no").ToString

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    'Private Sub SaveLine(ByRef pdrRow As DataRow)

    '    Try

    '        'pdrRow.Item("W_Pixels") = m_intW_Pixels
    '        pdrRow.Item("H_Pixels") = m_intH_Pixels
    '        pdrRow.Item("Item_No") = m_strItem_No
    '        pdrRow.Item("OEI_W_Pixels") = m_intOEI_W_Pixels
    '        pdrRow.Item("OEI_H_Pixels") = m_intOEI_H_Pixels
    '        pdrRow.Item("Catalog_Item_Num") = m_strCatalog_Item_Num
    '        pdrRow.Item("Rotate") = m_strRotate
    '        pdrRow.Item("Document_Ext") = m_strDocument_Ext
    '        If m_intW_Pixels = 0 Then
    '            If Not (m_FileUpload Is Nothing) Then
    '                pdrRow.Item("Document_Data") = m_FileUpload.Read
    '            ElseIf Not (m_bDocument_Data Is Nothing) Then
    '                pdrRow.Item("Document_Data") = m_bDocument_Data
    '            End If
    '        End If
    '        pdrRow.Item("Cus_Prog_Guid") = m_strCus_Prog_Guid
    '        pdrRow.Item("User_Login") = m_strUser_Login
    '        If m_dtCreate_Ts.Year <> 1 Then pdrRow.Item("Create_Ts") = m_dtCreate_Ts
    '        If m_dtUpdate_Ts.Year <> 1 Then pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub

#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current Comment from the database, if it exists.
    'Public Sub Delete()

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql = _
    '        "DELETE FROM Mdb_Cus_Document " & _
    '        "WHERE  W_Pixels = " & m_intW_Pixels & " "

    '        db.Execute(strSql)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


    Private Sub Load(ByVal pItem_No As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            'strSql = _
            '"SELECT * " & _
            '"FROM   ITEM_PICTURES WITH (Nolock) " & _
            '"WHERE  Item_No = '" & pItem_No.Trim & "' "

            '++ID 1.9.2018 changed item_pictures -> Ion_View_Item_Picture all come from Master Database
            strSql =
            "SELECT * " &
            "FROM   Ion_View_Item_Picture WITH (Nolock) " &
            "WHERE  Item_No = '" & pItem_No.Trim & "' and item_doc_type_id = 6 "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pItem_Cd As String, pItem_Color As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            'Ion I change MDB_ITEM_DETAIL => MDB_ITEM_DETAIL_OLD only for THOR dbo.100
            'strSql = _
            '"SELECT		P.* " & _
            '"FROM		ITEM_PICTURES P WITH (NOLOCK) " & _
            '"INNER JOIN	MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD AND P.ITEM_NO = I.ITEM_NO " & _
            '"WHERE		I.ITEM_CD = '" & pItem_Cd.Trim & "' "

            '++ID 02.02.2016 added, changed  MDB_ITEM_DETAIL=>imitmidx_sql
            'strSql = _
            '   "SELECT	P.* " & _
            '   "FROM ITEM_PICTURES P WITH (NOLOCK) " & _
            '   "INNER JOIN	imitmidx_sql I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.user_def_fld_1 " & _
            '   "WHERE	I.ITEM_CD = '" & pItem_Cd.Trim & "' "

            '++ID 1.8.2018
            'strSql =
            '   "SELECT	P.* " &
            '   "FROM ITEM_PICTURES P WITH (NOLOCK) " &
            '   "INNER JOIN	View_MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD " &
            '   "WHERE	I.ITEM_CD = '" & pItem_Cd.Trim & "' and COUNTRY_CD = 'CA' and BOUND_TYPE = 'out' "

            '++ID 1.9.2018 created new view for replace item_pictures
            strSql =
                " SELECT P.* FROM Ion_View_Item_Picture P WITH (NOLOCK)  " &
                " INNER JOIN	View_MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD AND P.ITEM_NO = I.ITEM_NO  " &
                " WHERE	I.ITEM_CD = '" & Trim(RTrim(pItem_Cd)) & "'"


            If pItem_Color <> "ALL" Then

                '  strSql &= " AND I.user_def_fld_2 like '%" & pItem_Color.Trim & "%'"
                '++ID 1.8.2018
                strSql &= " AND I.Color_List like '%" & pItem_Color.Trim & "%'"
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cItem_Pictures." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Update the current Comment into the database, or creates it if not existing
    'Public Sub Save()

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable
    '        Dim drRow As DataRow

    '        Dim strSql As String

    '        If m_intW_Pixels = 0 Then
    '            strSql = _
    '            "SELECT * " & _
    '            "FROM   Mdb_Cus_Document " & _
    '            "WHERE  W_Pixels = " & m_intW_Pixels & " "
    '        Else
    '            strSql = _
    '            "SELECT W_Pixels, H_Pixels, Item_No, OEI_W_Pixels, " & _
    '            "       OEI_H_Pixels, Catalog_Item_Num, Rotate, DOCUMENT_EXT, " & _
    '            "       CUS_PROG_GUID, USER_LOGIN, CREATE_TS, UPDATE_TS " & _
    '            "FROM   Mdb_Cus_Document " & _
    '            "WHERE  W_Pixels = " & m_intW_Pixels & " "
    '        End If

    '        dt = db.DataTable(strSql)

    '        If dt.Rows.Count = 0 Then
    '            drRow = dt.NewRow()
    '        Else
    '            drRow = dt.Rows(0)
    '        End If

    '        Call SaveLine(drRow)

    '        If dt.Rows.Count = 0 Then

    '            db.DBDataTable.Rows.Add(drRow)
    '            Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
    '            db.DBDataAdapter.InsertCommand = cmd.GetInsertCommand

    '        Else

    '            Dim cmd As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(db.DBDataAdapter)
    '            db.DBDataAdapter.UpdateCommand = cmd.GetUpdateCommand

    '        End If

    '        db.DBDataAdapter.Update(db.DBDataTable)

    '    Catch ex As Exception
    '        MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Sub


#End Region


#Region "Public properties ################################################"

    Public Property W_Pixels() As Integer
        Get
            W_Pixels = m_intW_Pixels
        End Get
        Set(ByVal value As Integer)
            m_intW_Pixels = value
        End Set
    End Property

    Public Property H_Pixels() As Integer
        Get
            H_Pixels = m_intH_Pixels
        End Get
        Set(ByVal value As Integer)
            m_intH_Pixels = value
        End Set
    End Property

    Public Property Item_No() As String
        Get
            Item_No = m_strItem_No
        End Get
        Set(ByVal value As String)
            m_strItem_No = value
        End Set
    End Property

    Public Property OEI_W_Pixels() As Integer
        Get
            OEI_W_Pixels = m_intOEI_W_Pixels
        End Get
        Set(ByVal value As Integer)
            m_intOEI_W_Pixels = value
        End Set
    End Property

    Public Property OEI_H_Pixels() As Integer
        Get
            OEI_H_Pixels = m_intOEI_H_Pixels
        End Get
        Set(ByVal value As Integer)
            m_intOEI_H_Pixels = value
        End Set
    End Property

    Public Property Catalog_Item_Num() As String
        Get
            Catalog_Item_Num = m_strCatalog_Item_Num
        End Get
        Set(ByVal value As String)
            m_strCatalog_Item_Num = value
        End Set
    End Property

    Public Property Rotate() As String
        Get
            Rotate = m_strRotate
        End Get
        Set(ByVal value As String)
            m_strRotate = value
        End Set
    End Property

    'Public Property Document_Ext() As String
    '    Get
    '        Document_Ext = m_strDocument_Ext
    '    End Get
    '    Set(ByVal value As String)
    '        m_strDocument_Ext = value
    '    End Set
    'End Property

    'Public Property Document_Data() As Byte()
    '    Get
    '        Document_Data = m_bDocument_Data
    '    End Get
    '    Set(ByVal value As Byte())
    '        m_bDocument_Data = value
    '    End Set
    'End Property

    'Public Property Cus_Prog_Guid() As String
    '    Get
    '        Cus_Prog_Guid = m_strCus_Prog_Guid
    '    End Get
    '    Set(value As String)
    '        m_strCus_Prog_Guid = value
    '    End Set
    'End Property

    'Public Property User_Login() As String
    '    Get
    '        User_Login = m_strUser_Login
    '    End Get
    '    Set(ByVal value As String)
    '        m_strUser_Login = value
    '    End Set
    'End Property

    'Public Property Create_Ts() As DateTime
    '    Get
    '        Create_Ts = m_dtCreate_Ts
    '    End Get
    '    Set(ByVal value As DateTime)
    '        m_dtCreate_Ts = value
    '    End Set
    'End Property

    'Public Property Update_Ts() As DateTime
    '    Get
    '        Update_Ts = m_dtUpdate_Ts
    '    End Get
    '    Set(ByVal value As DateTime)
    '        m_dtUpdate_Ts = value
    '    End Set
    'End Property

    'Public ReadOnly Property GetDocumentRow() As DataRow
    '    Get
    '        Dim dt As New DataTable
    '        Dim db As New cDBA

    '        If m_intW_Pixels <> 0 Then
    '            'Dim strSql As String = _
    '            '"SELECT * " & _
    '            '"FROM   Exact_Traveler_Document_Deleted WITH (Nolock) " & _
    '            '"WHERE  DocID = '" & m_DocID & "' "

    '            Dim strSql As String = _
    '            "SELECT * " & _
    '            "FROM   MDB_CUS_DOCUMENT WITH (Nolock) " & _
    '            "WHERE  W_Pixels = '" & m_intW_Pixels & "' "
    '            dt = db.DataTable(strSql)
    '            'Else
    '            '    '"FROM       OEI_Documents WITH (Nolock) " & _
    '            '    Dim strsql As String = _
    '            '    "SELECT     * " & _
    '            '    "FROM       MDB_CUS_DOCUMENT WITH (Nolock) " & _
    '            '    "WHERE      Cus_Prog_Guid = '" & m_strCus_Prog_Guid & "' AND " & _
    '            '    "           DocName = '" & m_DocFile.Name & "' "

    '            '    '"SELECT     * " & _
    '            '    '"FROM       Exact_Traveler_Document WITH (Nolock) " & _
    '            '    '"WHERE      Ord_Guid = '" & m_Ord_Guid & "' AND " & _
    '            '    '"           Item_Guid = '" & m_Item_Guid & "' AND " & _
    '            '    '"           DocName = '" & m_DocFile.Name & "' "

    '            '    dt = db.DataTable(strsql)
    '        End If
    '        GetDocumentRow = dt.Rows(0)
    '    End Get
    'End Property

    Public Property DocFile() As String
        Get
            DocFile = m_DocFile.Name
        End Get
        Set(ByVal value As String)
            If value = "" Then
                m_DocFile = Nothing
                'm_DocName = ""
            Else
                m_DocFile = New FileInfo(value)
                'm_DocName = m_DocFile.Name
            End If
        End Set
    End Property

    Public Function SaveFileToPath() As String

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String
        SaveFileToPath = ""

        Try

            If Not (GetDocumentRow Is Nothing) Then

                Dim strPath As String = "C:\ExactTemp\"
                Dim strFileSave As String = strPath & m_strItem_No & ".jpg"

                If Not (Directory.Exists(strPath)) Then
                    MkDir(strPath)
                End If

                '/////////////////////////////
                'Get the document from the database and write it to a temp file
                Dim mStream As New ADODB.Stream
                mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
                mStream.Open()
                mStream.Write(GetDocumentRow.Item("Picture"))
                mStream.SaveToFile(strFileSave, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

                SaveFileToPath = strFileSave

            End If

        Catch er As Exception
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in cItem_Picture." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try

    End Function

    Public ReadOnly Property GetDocumentRow() As DataRow
        Get
            Dim dt As New DataTable
            Dim db As New cDBA

            If m_strItem_No <> "" Then

                Dim strSql As String

                'strSql = "SELECT * " &
                '"FROM   Item_Pictures WITH (Nolock) " &
                '"WHERE  Item_No = '" & m_strItem_No & "' "

                '++ID 1.9.2018 changed item_pictures -> Ion_View_Item_Picture all come from Master Database
                strSql =
            "SELECT ITEM_ID, ITEM_CD, ITEM_NO, Color_List, ITEM_DOC_TYPE_ID, ITEM_DOC as picture, ITEM_DOC_FILE_EXT, DOC_TYPE, 
                         ITEM_DOC_FOLDER, IS_KIT  " &
            "FROM   Ion_View_Item_Picture WITH (Nolock) " &
            "WHERE  Item_No = '" & m_strItem_No & "' and item_doc_type_id = 6 "

                dt = db.DataTable(strSql)

            End If
            If dt.Rows.Count <> 0 Then
                GetDocumentRow = dt.Rows(0)
            Else
                GetDocumentRow = Nothing
            End If
        End Get
    End Property

#End Region

End Class
