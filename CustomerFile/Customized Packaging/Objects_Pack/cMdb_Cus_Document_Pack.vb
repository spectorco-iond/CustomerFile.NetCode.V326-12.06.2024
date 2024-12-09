Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Public Class cMdb_Cus_Document_Pack
#Region "private variables #################################################"


    Private m_intCus_Document_Id As Int32
    Private m_intDoc_Type_Id As Int32
    Private m_strDoc_Type As String
    Private m_strCus_No As String
    Private m_intCus_Contact_Id As Int32
    Private m_intMain_Cus_Doc_Id As Int32
    Private m_strDocument_Desc As String
    Private m_strDocument_Path As String
    Private m_strDocument_Ext As String
    Private m_bDocument_Data As Byte()
    Private m_strUser_Login As String
    Private m_strCus_Prog_Guid As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime
    Private m_FileUpload As ADODB.Stream
    Private m_DocFile As FileInfo
    Private m_Path As String = "c:\ExactTemp\"

#End Region

#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Document_Id As Integer)

        Try

            Call Init()
            Call Load(pCus_Document_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pPath As String)

        Try

            Call Init()

            m_FileUpload = New ADODB.Stream
            m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
            m_FileUpload.Open()
            m_FileUpload.LoadFromFile(pPath)

            m_strDocument_Desc = pPath.Substring(pPath.LastIndexOf("\") + 1)
            m_strDocument_Path = pPath
            m_strDocument_Ext = pPath.Substring(pPath.LastIndexOf(".") + 1)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pEmail As Stream)

        Try

            Call Init()


        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region

#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCus_Document_Id = 0
            m_intDoc_Type_Id = 0
            m_strDoc_Type = String.Empty
            m_strCus_No = String.Empty
            m_intCus_Contact_Id = 0
            m_intMain_Cus_Doc_Id = 0
            m_strDocument_Desc = String.Empty
            m_strDocument_Path = String.Empty
            m_strDocument_Ext = String.Empty
            m_strCus_Prog_Guid = String.Empty

            m_strUser_Login = String.Empty
            m_dtCreate_Ts = NoDate()
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Document_Id").Equals(DBNull.Value)) Then m_intCus_Document_Id = pdrRow.Item("Cus_Document_Id")
            If Not (pdrRow.Item("Doc_Type_Id").Equals(DBNull.Value)) Then m_intDoc_Type_Id = pdrRow.Item("Doc_Type_Id")
            If Not (pdrRow.Item("Doc_Type").Equals(DBNull.Value)) Then m_strDoc_Type = pdrRow.Item("Doc_Type").ToString
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Cus_Contact_Id").Equals(DBNull.Value)) Then m_intCus_Contact_Id = pdrRow.Item("Cus_Contact_Id")
            If Not (pdrRow.Item("Main_Cus_Doc_Id").Equals(DBNull.Value)) Then m_intMain_Cus_Doc_Id = pdrRow.Item("Main_Cus_Doc_Id")
            If Not (pdrRow.Item("Document_Desc").Equals(DBNull.Value)) Then m_strDocument_Desc = pdrRow.Item("Document_Desc").ToString
            If Not (pdrRow.Item("Document_Path").Equals(DBNull.Value)) Then
                m_strDocument_Path = pdrRow.Item("Document_Path").ToString
                m_DocFile = New FileInfo(m_strDocument_Path)
            End If
            If Not (pdrRow.Item("Document_Ext").Equals(DBNull.Value)) Then m_strDocument_Ext = pdrRow.Item("Document_Ext").ToString
            If Not (pdrRow.Item("Document_Data").Equals(DBNull.Value)) Then m_bDocument_Data = pdrRow.Item("Document_Data")
            If Not (pdrRow.Item("Cus_Prog_Guid").Equals(DBNull.Value)) Then m_strCus_Prog_Guid = pdrRow.Item("Cus_Prog_Guid").ToString
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Cus_Document_Id") = m_intCus_Document_Id
            pdrRow.Item("Doc_Type_Id") = m_intDoc_Type_Id
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Cus_Contact_Id") = m_intCus_Contact_Id 'no
            pdrRow.Item("Main_Cus_Doc_Id") = m_intMain_Cus_Doc_Id 'no
            pdrRow.Item("Document_Desc") = m_strDocument_Desc
            pdrRow.Item("Document_Path") = m_strDocument_Path
            pdrRow.Item("Document_Ext") = m_strDocument_Ext
            If m_intCus_Document_Id = 0 Then
                If Not (m_FileUpload Is Nothing) Then
                    pdrRow.Item("Document_Data") = m_FileUpload.Read
                End If
            End If
            pdrRow.Item("Cus_Prog_Guid") = m_strCus_Prog_Guid ' Guid from Quote
            pdrRow.Item("User_Login") = Environment.UserName ' m_strUser_Login


            m_dtCreate_Ts = Date.Now
            pdrRow.Item("Create_Ts") = m_dtCreate_Ts

            m_dtUpdate_Ts = Date.Now
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts


        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region

#Region "Public maintenance procedures ####################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Document " & _
            "WHERE  Cus_Document_Id = " & m_intCus_Document_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub Hide()

        Try

            Dim oMBResult As New MsgBoxResult
            oMBResult = MsgBox("Do you want to delete this document: " & vbCrLf & m_strDocument_Desc & " ?", MsgBoxStyle.YesNoCancel)

            If oMBResult = MsgBoxResult.Yes Then
                m_strCus_No = "--" & m_strCus_No.Trim & "--"
                Call Save()
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT D.*, ISNULL(DT.DocType, '') AS Doc_Type " & _
            "FROM   Mdb_Cus_Document D WITH (Nolock) " & _
            "LEFT JOIN EXACT_TRAVELER_XREF_DOCTYPE DT WITH (NOLOCK) ON D.Doc_Type_ID = DT.DocTypeID " & _
            "WHERE  Cus_Document_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            If m_intCus_Document_Id = 0 Then
                strSql = _
                "SELECT * " & _
                "FROM   Mdb_Cus_Document " & _
                "WHERE  Cus_Document_Id = " & m_intCus_Document_Id & " "
            Else
                strSql = _
                "SELECT CUS_DOCUMENT_ID, DOC_TYPE_ID, CUS_NO, CUS_CONTACT_ID, " & _
                "       MAIN_CUS_DOC_ID, DOCUMENT_DESC, DOCUMENT_PATH, DOCUMENT_EXT, " & _
                "       CUS_PROG_GUID, USER_LOGIN, CREATE_TS, UPDATE_TS " & _
                "FROM   Mdb_Cus_Document " & _
                "WHERE  Cus_Document_Id = " & m_intCus_Document_Id & " "
            End If

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
            MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function SaveToDataObject() As DataObject

        Dim fileas As String() = New [String](0) {}
        fileas(0) = SaveToFileName()

        SaveToDataObject = New DataObject(DataFormats.FileDrop, fileas)
        SaveToDataObject.SetData(DataFormats.StringFormat, fileas)
        'DoDragDrop(dta, DragDropEffects.Copy)    'This copy the tmp_donot_delete.antf2 to the destination, get the destination to the output variable, delete the temp_donot....antf2, and finially run your code.

    End Function

    Public Function SaveToFileName() As String

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String

        SaveToFileName = ""

        Try

            Dim strPathAndFile As String
            'Dim strPathAndFile As String = gPath & DocFile
            If Cus_Document_Id <> 0 Then
                If Trim(DocFile) = "" Then
                    strPathAndFile = m_Path & Cus_Document_Id
                Else
                    strPathAndFile = m_Path & DocFile
                End If

            Else
                strPathAndFile = m_Path & DocFile ' Name
            End If

            'Dim strPathAndFile As String = gPath & DocFile ' Name

            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Not (Directory.Exists(m_Path)) Then
                'If Dir(m_Path, FileAttribute.Directory) = "" Then
                MkDir(m_Path)
            End If

            '/////////////////////////////
            'Get the document from the database and write it to a temp file
            Dim mStream As New ADODB.Stream
            mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
            mStream.Open()
            mStream.Write(GetDocumentRow.Item("Document_Data"))
            If Cus_Document_Id <> 0 Then
                'mStream.Write(GetDocumentRow.Item("Document"))
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            Else
                'mStream.Write(GetDocumentImage())
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            End If

            SaveToFileName = strPathAndFile

            'mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            '////////////////////////////////
            'Show the file
            'Select Case Mid(strPathAndFile.ToUpper, strPathAndFile.Length - 3)

            '    Case ".MSG", ".XLS", "XLSX", ".DOC", "DOCX", ".BMP"
            '        pnlPreviewDoc.Visible = False

            '    Case Else
            '        pnlPreviewDoc.Visible = True

            'End Select

            'wbShowFile.Navigate(strPathAndFile, False) ', True) '1 = NewWindow
            'wbShowFile.Navigate(New System.Uri(strPathAndFile), True) '1 = NewWindow

            'End If

        Catch er As Exception
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in cMdb_Cus_Document." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try


    End Function

#End Region


#Region "Public properties ################################################"

    Public Property Cus_Document_Id() As Int32
        Get
            Cus_Document_Id = m_intCus_Document_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Document_Id = value
        End Set
    End Property

    Public Property Doc_Type_Id() As Int32
        Get
            Doc_Type_Id = m_intDoc_Type_Id
        End Get
        Set(ByVal value As Int32)
            m_intDoc_Type_Id = value
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

    Public Property Doc_Type() As String
        Get
            Doc_Type = m_strDoc_Type
        End Get
        Set(ByVal value As String)
            m_strDoc_Type = value
        End Set
    End Property

    Public Property Cus_Contact_Id() As Int32
        Get
            Cus_Contact_Id = m_intCus_Contact_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Contact_Id = value
        End Set
    End Property

    Public Property Main_Cus_Doc_Id() As Int32
        Get
            Main_Cus_Doc_Id = m_intMain_Cus_Doc_Id
        End Get
        Set(ByVal value As Int32)
            m_intMain_Cus_Doc_Id = value
        End Set
    End Property

    Public Property Document_Desc() As String
        Get
            Document_Desc = m_strDocument_Desc
        End Get
        Set(ByVal value As String)
            m_strDocument_Desc = value
        End Set
    End Property

    Public Property Document_Path() As String
        Get
            Document_Path = m_strDocument_Path
        End Get
        Set(ByVal value As String)
            m_strDocument_Path = value
        End Set
    End Property

    Public Property Document_Ext() As String
        Get
            Document_Ext = m_strDocument_Ext
        End Get
        Set(ByVal value As String)
            m_strDocument_Ext = value
        End Set
    End Property

    Public Property Document_Data() As Byte()
        Get
            Document_Data = m_bDocument_Data
        End Get
        Set(ByVal value As Byte())
            m_bDocument_Data = value
        End Set
    End Property

    Public Property Cus_Prog_Guid() As String
        Get
            Cus_Prog_Guid = m_strCus_Prog_Guid
        End Get
        Set(ByVal value As String)
            m_strCus_Prog_Guid = value
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

    Public ReadOnly Property GetDocumentRow() As DataRow
        Get
            Dim dt As New DataTable
            Dim db As New cDBA

            If m_intCus_Document_Id <> 0 Then
                'Dim strSql As String = _
                '"SELECT * " & _
                '"FROM   Exact_Traveler_Document_Deleted WITH (Nolock) " & _
                '"WHERE  DocID = '" & m_DocID & "' "

                Dim strSql As String = _
                "SELECT * " & _
                "FROM   MDB_CUS_DOCUMENT WITH (Nolock) " & _
                "WHERE  Cus_Document_ID = '" & m_intCus_Document_Id & "' "
                dt = db.DataTable(strSql)
                'Else
                '    '"FROM       OEI_Documents WITH (Nolock) " & _
                '    Dim strsql As String = _
                '    "SELECT     * " & _
                '    "FROM       MDB_CUS_DOCUMENT WITH (Nolock) " & _
                '    "WHERE      Cus_Prog_Guid = '" & m_strCus_Prog_Guid & "' AND " & _
                '    "           DocName = '" & m_DocFile.Name & "' "

                '    '"SELECT     * " & _
                '    '"FROM       Exact_Traveler_Document WITH (Nolock) " & _
                '    '"WHERE      Ord_Guid = '" & m_Ord_Guid & "' AND " & _
                '    '"           Item_Guid = '" & m_Item_Guid & "' AND " & _
                '    '"           DocName = '" & m_DocFile.Name & "' "

                '    dt = db.DataTable(strsql)
            End If
            GetDocumentRow = dt.Rows(0)
        End Get
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

#End Region
End Class
