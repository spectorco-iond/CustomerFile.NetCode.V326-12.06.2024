Public Class cCOMPLAINT_CALL_DETAIL_FILE
    Implements ICloneable


#Region "private variables #################################################"

    Private m_COMPLAINT_CALL_DETAIL_FILE_ID As Int32
    Private m_COMPLAINT_CALL_DETAIL_ID As Int32
    Private m_COMPLAINT_CALL_DETAIL_FILE_TYPE_ID As Int32
    Private m_FILE_HEADER As Byte()
    Private m_FILE_NAME As String
    Private m_FILE_EXT As String
    Private m_FILE_CONTENT As Byte()
    Private m_FILE_NOTE As String
    Private m_UPLOAD_DATETIME As DateTime
    Private m_IF_VALID As Int32

#End Region
    'Public Function load_initial_byid(pintID As Integer) As Boolean

    '    load_initial_byid = False

    '    Try

    '        Dim db As New cDBA
    '        Dim dt As New DataTable

    '        Dim strSql As String

    '        strSql =
    '                "DELETE FROM COMPLAINT_CALL_DETAIL_FILE " &
    '              "WHERE  COMPLAINT_CALL_DETAIL_FILE_ID = " & pintID & " "

    '        db.Execute(strSql)

    '        load_initial_byid = True

    '    Catch ex As Exception
    '        MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
    '    End Try

    'End Function

#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_DETAIL_FILE_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_FILE_ID = m_COMPLAINT_CALL_DETAIL_FILE_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_FILE_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_DETAIL_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_ID = m_COMPLAINT_CALL_DETAIL_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_DETAIL_FILE_TYPE_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_FILE_TYPE_ID = m_COMPLAINT_CALL_DETAIL_FILE_TYPE_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_FILE_TYPE_ID = value
        End Set
    End Property

    Public Property FILE_HEADER() As Byte()
        Get
            FILE_HEADER = m_FILE_HEADER
        End Get
        Set(ByVal value As Byte())
            m_FILE_HEADER = value
        End Set
    End Property

    Public Property FILE_NAME() As String
        Get
            FILE_NAME = m_FILE_NAME
        End Get
        Set(ByVal value As String)
            m_FILE_NAME = value
        End Set
    End Property

    Public Property FILE_EXT() As String
        Get
            FILE_EXT = m_FILE_EXT
        End Get
        Set(ByVal value As String)
            m_FILE_EXT = value
        End Set
    End Property

    Public Property FILE_CONTENT() As Byte()
        Get
            FILE_CONTENT = m_FILE_CONTENT
        End Get
        Set(ByVal value As Byte())
            m_FILE_CONTENT = value
        End Set
    End Property

    Public Property FILE_NOTE() As String
        Get
            FILE_NOTE = m_FILE_NOTE
        End Get
        Set(ByVal value As String)
            m_FILE_NOTE = value
        End Set
    End Property

    Public Property UPLOAD_DATETIME() As DateTime
        Get
            UPLOAD_DATETIME = m_UPLOAD_DATETIME
        End Get
        Set(ByVal value As DateTime)
            m_UPLOAD_DATETIME = value
        End Set
    End Property

    Public Property IF_VALID() As Int32
        Get
            IF_VALID = m_IF_VALID
        End Get
        Set(ByVal value As Int32)
            m_IF_VALID = value
        End Set
    End Property



#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class ' cCOMPLAINT_CALL_DETAIL_FILE


