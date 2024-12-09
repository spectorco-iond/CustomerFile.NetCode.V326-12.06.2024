Imports System.IO
Imports System.Text

'++ID 11.1.15 ..
Public Class cEXACT_TRAVELER_DOCUMENT
    Private db As New cDBA

    Private m_DocID As Integer
    Private m_Ord_No As String
    Private m_HeaderID As Integer
    Private m_DocType As String
    Private m_DocTypeID As Integer
    Private m_DocDescription As String

    Private m_DocName As String
    Private m_Document As Object
    Private m_Document_Array As Byte()
    Private m_DocumentText As String = String.Empty
    Private m_CreateDate As Date
    Private m_ArtworkPurged As Integer
    Private m_Ord_Guid As String = String.Empty
    Private m_Item_Guid As String = String.Empty

    Private m_AutoSave As Boolean = False

    'Private m_DocFile As String
    Private m_OnDrive As Integer ' tinyint 0-255
    Private m_Added_By_User As String

    Private m_FileUpload As ADODB.Stream
    Private m_DocFile As FileInfo
    Private m_Path As String = "c:\ExactTemp\"

    Private pPath As String = String.Empty

    Public Sub New()
        Try
            Call Init()
        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal path As String, ByVal pDocID As Int32)
        Try

            If pDocID > 0 Then

                Call Load(pDocID)
            Else
                Call Init()
            End If


            pPath = path

        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pDocId As Int32)
        Try
            Call Init()
            Call Load(pDocId)

        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "Private maintenance procedures################################################"


    Private Sub Init()

        m_DocID = 0
        m_Ord_No = String.Empty
        m_HeaderID = 0
        m_DocType = String.Empty
        m_DocTypeID = 0
        m_DocDescription = String.Empty
        m_DocFile = Nothing
        m_DocName = String.Empty
        m_Document = Nothing ' New Object()
        m_DocumentText = String.Empty
        m_CreateDate = Now ' String.Empty
        m_ArtworkPurged = 0
        m_OnDrive = 0
        m_Added_By_User = String.Empty

    End Sub

    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("DocID").Equals(DBNull.Value)) Then m_DocID = pdrRow.Item("DocID")
            If Not (pdrRow.Item("Ord_No").Equals(DBNull.Value)) Then m_Ord_No = pdrRow.Item("Ord_No").ToString
            If Not (pdrRow.Item("HeaderID").Equals(DBNull.Value)) Then m_HeaderID = pdrRow.Item("HeaderID")
            If Not (pdrRow.Item("DocType").Equals(DBNull.Value)) Then m_DocType = pdrRow.Item("DocType").ToString
            If Not (pdrRow.Item("DocTypeID").Equals(DBNull.Value)) Then m_DocTypeID = pdrRow.Item("DocTypeID")
            If Not (pdrRow.Item("DocDescription").Equals(DBNull.Value)) Then m_DocDescription = pdrRow.Item("DocDescription").ToString

            If Not (pdrRow.Item("DocName").Equals(DBNull.Value)) Then m_DocName = pdrRow.Item("DocName").ToString

            If Not (pdrRow.Item("Document").Equals(DBNull.Value)) Then m_Document = pdrRow.Item("Document")

            If Not (pdrRow.Item("CreateDate").Equals(DBNull.Value)) Then m_CreateDate = pdrRow.Item("CreateDate")
            If Not (pdrRow.Item("ArtworkPurged").Equals(DBNull.Value)) Then m_ArtworkPurged = pdrRow.Item("ArtworkPurged").ToString
            If Not (pdrRow.Item("Ord_Guid").Equals(DBNull.Value)) Then m_Ord_Guid = pdrRow.Item("Ord_Guid").ToString
            If Not (pdrRow.Item("Item_Guid").Equals(DBNull.Value)) Then m_Item_Guid = pdrRow.Item("Item_Guid").ToString
            If Not (pdrRow.Item("OnDrive").Equals(DBNull.Value)) Then m_OnDrive = pdrRow.Item("OnDrive").ToString
            If Not (pdrRow.Item("Added_By_User").Equals(DBNull.Value)) Then m_Added_By_User = pdrRow.Item("Added_By_User").ToString

        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveLine(ByRef pRow As DataRow)
        Try

            pRow.Item("DocType") = m_DocType
            pRow.Item("DocTypeID") = m_DocTypeID
            pRow.Item("DocDescription") = m_DocDescription

            If m_DocID = 0 Then

                If m_Document Is Nothing Then
                    m_FileUpload = New ADODB.Stream
                    m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
                    m_FileUpload.Open()
                    m_FileUpload.LoadFromFile(pPath)
                    pRow.Item("Document") = m_FileUpload.Read
                    m_DocName = pPath.Substring(pPath.LastIndexOf("\") + 1)
                Else
                    If pRow.Item("Document").Equals(DBNull.Value) Then
                        If m_Document_Array Is Nothing Then
                            Dim oimage As cImage = New cImage()
                            Dim baImage As Byte() = Nothing
                            oimage.SetImageAsByteArray(m_Document, baImage)
                            pRow.Item("Document") = baImage
                        Else
                            pRow.Item("Document") = m_Document_Array
                        End If

                    End If

                End If

            Else
                m_FileUpload = New ADODB.Stream
                m_FileUpload.Type = ADODB.StreamTypeEnum.adTypeBinary
                m_FileUpload.Open()
                m_FileUpload.LoadFromFile(pPath)
                pRow.Item("Document") = m_FileUpload.Read
                m_DocName = pPath.Substring(pPath.LastIndexOf("\") + 1)
            End If


            pRow.Item("HeaderId") = m_HeaderID
            pRow.Item("DocName") = m_DocName
            pRow.Item("CreateDate") = Now()
            pRow.Item("ArtworkPurged") = 0
            pRow.Item("OnDrive") = 0
            pRow.Item("Added_By_User") = Environment.UserName


        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
    '---------------------------------------------------------------------------
#Region "Public maintenance procedures ############################################"

    Public Sub Load(ByVal pDocId As Int32)
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = _
             " SELECT * FROM   Exact_Traveler_Document WITH (Nolock) " & _
             " WHERE  DocID = " & pDocId

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If


        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Function SaveFileToPath() As String

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String
        SaveFileToPath = ""

        Try

            If Not (GetDocumentRow Is Nothing) Then

                Dim strPath As String = "C:\ExactTemp\"
                Dim strFileSave As String = strPath & m_DocName

                If Not (Directory.Exists(strPath)) Then
                    MkDir(strPath)
                End If

                '/////////////////////////////
                'Get the document from the database and write it to a temp file
                Dim mStream As New ADODB.Stream
                mStream.Type = ADODB.StreamTypeEnum.adTypeBinary
                mStream.Open()
                mStream.Write(GetDocumentRow.Item("Document"))

                If File.Exists(strFileSave) Then

                Else
                    mStream.SaveToFile(strFileSave, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
                End If

                '++ID 20.1.15
                mStream.Close()
                mStream = Nothing

                SaveFileToPath = strFileSave

            End If



        Catch er As Exception
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try

    End Function

    Public Sub Save()
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim drRow As DataRow

            strSql = _
                " SELECT * FROM  EXACT_TRAVELER_DOCUMENT " & _
                " WHERE  DocId = " & m_DocID

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
            If m_DocID = 0 Then m_DocID = db.DataTable("SELECT MAX(DocId) AS Max_DocId FROM EXACT_TRAVELER_DOCUMENT WITH (Nolock)").Rows(0).Item("Max_DocId")

        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Delete()
        Try
            Dim strSql As String

            strSql = _
                " DELETE FROM  EXACT_TRAVELER_DOCUMENT " & _
                " WHERE DocID = " & m_DocID

            db.Execute(strSql)


        Catch ex As Exception
            MsgBox("Error in cEXACT_TRAVELER_DOCUMENT." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
    '---------------------------------------------------------------

    Public Property Added_By_User() As String
        Get
            Added_By_User = m_Added_By_User
        End Get
        Set(ByVal value As String)
            m_Added_By_User = value
        End Set
    End Property
    Public Property ArtworkPurged() As Integer
        Get
            ArtworkPurged = m_ArtworkPurged
        End Get
        Set(ByVal value As Integer)
            m_ArtworkPurged = value
        End Set
    End Property
    Public Property AutoSave() As Boolean
        Get
            AutoSave = m_AutoSave
        End Get
        Set(ByVal value As Boolean)
            m_AutoSave = value
        End Set
    End Property
    Public Property CreateDate() As Date
        Get
            CreateDate = m_CreateDate
        End Get
        Set(ByVal value As Date)
            m_CreateDate = value
        End Set
    End Property

    Public Property DocDescription() As String
        Get
            DocDescription = m_DocDescription
        End Get
        Set(ByVal value As String)
            m_DocDescription = value
        End Set
    End Property
    Public Property DocFile() As String
        Get
            DocFile = m_DocFile.Name
        End Get
        Set(ByVal value As String)
            If value = "" Then
                m_DocFile = Nothing
                m_DocName = ""
            Else
                m_DocFile = New FileInfo(value)
                m_DocName = m_DocFile.Name
            End If
        End Set
    End Property
    Public Property DocID() As Integer
        Get
            DocID = m_DocID
        End Get
        Set(ByVal value As Integer)
            m_DocID = value
        End Set
    End Property
    Public Property DocType() As String
        Get
            DocType = m_DocType
        End Get
        Set(ByVal value As String)
            m_DocType = value
        End Set
    End Property
    Public Property DocTypeID() As Integer
        Get
            DocTypeID = m_DocTypeID
        End Get
        Set(ByVal value As Integer)
            m_DocTypeID = value
        End Set
    End Property
    Public Property DocName() As String
        Get
            DocName = m_DocName
        End Get
        Set(ByVal value As String)
            m_DocName = value
        End Set
    End Property
    Public Property Document() As Object
        Get
            Document = m_Document
        End Get
        Set(ByVal value As Object)
            m_Document = value
        End Set
    End Property
    Public Property Document_Array() As Byte()
        Get
            Document_Array = m_Document_Array
        End Get
        Set(ByVal value As Byte())
            m_Document_Array = value
        End Set
    End Property
    Public Property HeaderID() As Integer
        Get
            HeaderID = m_HeaderID
        End Get
        Set(ByVal value As Integer)
            m_HeaderID = value
        End Set
    End Property
    Public Property Item_Guid() As String
        Get
            Item_Guid = m_Item_Guid
        End Get
        Set(ByVal value As String)
            m_Item_Guid = value
            'Call CreateSql()
        End Set
    End Property
    Public Property OnDrive() As Integer
        Get
            OnDrive = m_OnDrive
        End Get
        Set(ByVal value As Integer)
            m_OnDrive = value
        End Set
    End Property
    Public Property Ord_Guid() As String
        Get
            Ord_Guid = m_Ord_Guid
        End Get
        Set(ByVal value As String)
            m_Ord_Guid = value
        End Set
    End Property
    Public Property Ord_No() As String
        Get
            Ord_No = m_Ord_No
        End Get
        Set(ByVal value As String)
            m_Ord_No = value
        End Set
    End Property

    Private ReadOnly Property GetDocumentRow() As DataRow
        Get
            Dim strSql As String
            Dim dt As New DataTable
            If m_DocID <> 0 Then
                strSql = _
                " select * from  EXACT_TRAVELER_DOCUMENT " & _
                " where DocID = " & m_DocID

                dt = db.DataTable(strSql)
            End If
            GetDocumentRow = dt.Rows(0)
        End Get
    End Property

    Public Sub PreviewDoc(ByRef m_Doc As Object, ByRef wbShowFile As WebBrowser, ByRef pnlPreviewDoc As Panel)

        'Dim mStream As ADODB.Stream
        'Dim strPathAndFile As String

        Try
            'm_Document c'est l'object avec touts le proprietes
            If m_Doc Is Nothing Then Exit Sub

            Dim strPathAndFile As String
            'Dim strPathAndFile As String = gPath & m_Doc.DocFile
            If m_Doc.DocID <> 0 Then
                If Trim(m_Doc.DocName) = "" Then
                    strPathAndFile = m_Path & m_Doc.DocID
                Else
                    strPathAndFile = m_Path & m_Doc.DocName
                End If

            Else
                strPathAndFile = m_Path & m_Doc.DocFile ' Name
            End If

            'Dim strPathAndFile As String = gPath & m_Document.DocFile ' Name

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

            mStream.Write(GetDocumentRow.Item("Document"))


            If m_Doc.DocID <> 0 Then
                'mStream.Write(m_Document.GetDocumentRow.Item("Document"))
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            Else
                'mStream.Write(m_Document.GetDocumentImage())
                mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            End If

            'mStream.SaveToFile(strPathAndFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)

            '////////////////////////////////
            'Show the file
            Select Case Mid(strPathAndFile.ToUpper, strPathAndFile.Length - 3)

                '   Me.pnlPreviewDoc = New System.Windows.Forms.Panel
                Case ".MSG", ".XLS", "XLSX", ".DOC", "DOCX", ".BMP"
                    pnlPreviewDoc.Visible = False 'panel   ' il faut enlever le commenter

                Case Else
                    pnlPreviewDoc.Visible = True    ' il faut enlever le commenter

            End Select

            ' Me.wbShowFile = New System.Windows.Forms.WebBrowser
            wbShowFile.Navigate((strPathAndFile), False) '1 = NewWindow  il faut enlever le commenter   display image



            '  wbShowFile.Navigate(New System.Uri(strPathAndFile), True) '1 = NewWindow

            'End If

        Catch er As Exception
            If er.Message = "Object reference not set to an instance of an object." Then
                MsgBox("Please select an item to make a preview.")
            Else
                MsgBox("Error in  cEXACT_TRAVELER_DOCUMEN ." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
            End If
        End Try

    End Sub

End Class
