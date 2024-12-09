Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Text

' Insert Include here

Public Class cItem_Picture_Pack


#Region "private variables #################################################"

    Private m_strItem_No As String
    Private m_strCatalog_Item_Num As String
    Private m_intW_Pixels As Integer
    Private m_intH_Pixels As Integer
    Private m_intOEI_W_Pixels As Integer
    Private m_intOEI_H_Pixels As Integer
    Private m_strRotate As String

    Private m_DocFile As FileInfo

    Private m_FileUpload As ADODB.Stream


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pItem_No As String)

        Try

            Call Init()
            Call Load(pItem_No)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pItem_Cd As String, ByVal pItem_Color As String)

        Try

            Call Init()
            Call Load(pItem_Cd, pItem_Color)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    'Public Sub New(ByVal pPath As String)

    '    Try

    '        Call Init()

    '        m_FileUpload = New ADODB.Stream
    '        m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
    '        m_FileUpload.Open()
    '        m_FileUpload.LoadFromFile(pPath)

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


        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("W_Pixels").Equals(DBNull.Value)) Then m_intW_Pixels = pdrRow.Item("W_Pixels")
            If Not (pdrRow.Item("H_Pixels").Equals(DBNull.Value)) Then m_intH_Pixels = pdrRow.Item("H_Pixels")
            If Not (pdrRow.Item("Item_No").Equals(DBNull.Value)) Then m_strItem_No = pdrRow.Item("Item_No").ToString
            If Not (pdrRow.Item("OEI_W_Pixels").Equals(DBNull.Value)) Then m_intOEI_W_Pixels = pdrRow.Item("OEI_W_Pixels")
            If Not (pdrRow.Item("OEI_H_Pixels").Equals(DBNull.Value)) Then m_intOEI_H_Pixels = pdrRow.Item("OEI_H_Pixels")
            If Not (pdrRow.Item("Catalog_Item_Num").Equals(DBNull.Value)) Then m_strCatalog_Item_Num = pdrRow.Item("Catalog_Item_Num").ToString
            If Not (pdrRow.Item("Rotate").Equals(DBNull.Value)) Then m_strRotate = pdrRow.Item("Rotate").ToString

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region


#Region "Public maintenance procedures ####################################"

    Private Sub Load(ByVal pItem_No As String)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Item_Pictures WITH (Nolock) " & _
            "WHERE  Item_No = '" & pItem_No.Trim & "' "

            '++ID 1.9.2018 changed item_pictures -> Ion_View_Item_Picture all come from Master Database
            strSql =
            "SELECT * " &
            "FROM   Ion_View_Item_Picture WITH (Nolock) " &
            "WHERE  Item_No = '" & pItem_No.Trim & "' "


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cItem_Picture_Pack." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub Load(ByVal pItem_Cd As String, ByVal pItem_Color As String)
        Try
            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "SELECT		P.* " & _
            "FROM		ITEM_PICTURES P WITH (NOLOCK) " & _
            "INNER JOIN	MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD AND P.ITEM_NO = I.ITEM_NO " & _
            "WHERE		I.ITEM_CD = '" & pItem_Cd.Trim & "' "

            strSql = _
                " SELECT	P.* FROM ITEM_PICTURES P WITH (NOLOCK)  " & _
                " INNER JOIN	imitmidx_sql I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.user_def_fld_1 AND P.ITEM_NO = I.ITEM_NO  " & _
                " WHERE	I.user_def_fld_1 = '" & Trim(RTrim(pItem_Cd)) & "' "
            '++ID 1.8.2018
            strSql =
                " SELECT P.* FROM ITEM_PICTURES P WITH (NOLOCK)  " &
                " INNER JOIN	View_MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD AND P.ITEM_NO = I.ITEM_NO  " &
                " WHERE	I.ITEM_CD = '" & Trim(RTrim(pItem_Cd)) & "' and COUNTRY_CD = 'CA' "

            '++ID 1.9.2018 created new view for replace item_pictures
            strSql =
                " SELECT P.* FROM Ion_View_Item_Picture P WITH (NOLOCK)  " &
                " INNER JOIN	View_MDB_ITEM_DETAIL I WITH (NOLOCK) ON P.CATALOG_ITEM_NUM = I.ITEM_CD AND P.ITEM_NO = I.ITEM_NO  " &
                " WHERE	I.ITEM_CD = '" & Trim(RTrim(pItem_Cd)) & "' "


            If pItem_Color <> "ALL" Then
                ' strSql &= " AND I.COLOR_CODE = '" & Trim(RTrim(pItem_Color)) & "'"
                ' strSql &= " AND I.user_def_fld_2 = '" & Trim(RTrim(pItem_Color)) & "'"
                '++ID 1.8.2018
                strSql &= " AND I.Color_List = '" & Trim(RTrim(pItem_Color)) & "'"
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cItem_Picture_Pack." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Item_No") = m_strItem_No
            pdrRow.Item("Catalog_Item_Num") = m_strCatalog_Item_Num

            pdrRow.Item("picture") = m_FileUpload.Read

            pdrRow.Item("W_Pixels") = m_intW_Pixels
            pdrRow.Item("H_Pixels") = m_intH_Pixels
            pdrRow.Item("OEI_W_Pixels") = m_intOEI_W_Pixels
            pdrRow.Item("OEI_H_Pixels") = m_intOEI_H_Pixels

            pdrRow.Item("Rotate") = m_strRotate




        Catch ex As Exception
            MsgBox("Error in cItem_Picture_Pack." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub Save()

        Try
            MsgBox("Function is closed for add image for now. Send ticket to IT about that. Message from cItem_Picture_Pack.Save")
            Exit Sub

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * FROM  Item_pictures  where  item_no= '" & m_strItem_No & "'"


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
            MsgBox("Error in cItem_Picture_Pack." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

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

    Public Function SaveFileTo(ByRef bit() As Byte) As String

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String
        SaveFileTo = ""

        Try

            '  If Not (bit Is Nothing) Then

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
            mStream.Write(bit)
            mStream.SaveToFile(strFileSave, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            SaveFileTo = strFileSave

            '   End If

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

                Dim strSql As String = _
                "SELECT * " & _
                "FROM   Item_Pictures WITH (Nolock) " & _
                "WHERE  Item_No = '" & m_strItem_No & "' "

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

