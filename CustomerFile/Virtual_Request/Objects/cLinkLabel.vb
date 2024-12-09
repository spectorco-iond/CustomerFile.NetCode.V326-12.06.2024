Public Class xLinkLabel
    Inherits LinkLabel

    Private m_strTagName As String
    Private m_btTagByte As Byte()
    Private m_strTagId As String
    Private m_strPath As String
    Private m_strExtention As String


    Public Property TagName As String
        Get
            Return m_strTagName
        End Get
        Set(value As String)
            m_strTagName = value
        End Set
    End Property
    Public Property TagByte As Byte()
        Get
            Return m_btTagByte
        End Get
        Set(ByVal value As Byte())
            m_btTagByte = value
        End Set
    End Property
    Public Property TagId As String
        Get
            Return m_strTagId
        End Get
        Set(value As String)
            m_strTagId = value
        End Set
    End Property
    Public Property TagPath As String
        Get
            Return m_strPath
        End Get
        Set(value As String)
            m_strPath = value
        End Set
    End Property
    Public Property TagExtention As String
        Get
            Return m_strExtention
        End Get
        Set(value As String)
            m_strExtention = value
        End Set
    End Property

End Class
Public Class cLinkLabel


    Private p_count As Int32
    Private p_lnkLabel As LinkLabel

    Public Sub New()
        Init()
    End Sub

    Private Sub Init()
        p_count = 0
        p_lnkLabel = New LinkLabel
    End Sub
    Public Property Count As Int32
        Get
            Count = p_count
        End Get
        Set(value As Int32)
            p_count = value
        End Set
    End Property
    Public Property LNKLABEL As LinkLabel
        Get
            LNKLABEL = p_lnkLabel
        End Get
        Set(value As LinkLabel)
            p_lnkLabel = value
        End Set
    End Property

End Class
Public Class cLabel

    Private p_count As Int32
    Private p_Label As Label

    Public Sub New()
        Init()
    End Sub

    Private Sub Init()
        p_count = 0
        p_Label = New Label
    End Sub
    Public Property Count As Int32
        Get
            Count = p_count
        End Get
        Set(value As Int32)
            p_count = value
        End Set
    End Property
    Public Property LABEL As Label
        Get
            LABEL = p_Label
        End Get
        Set(value As Label)
            p_Label = value
        End Set
    End Property

End Class
