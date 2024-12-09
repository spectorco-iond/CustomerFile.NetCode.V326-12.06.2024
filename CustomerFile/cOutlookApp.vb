Public Class cOutlookApp
    Private m_StartDate As Date
    Private m_bool As Boolean

    Public Property StartDate As Date
        Get
            StartDate = m_StartDate
        End Get
        Set(ByVal value As Date)
            m_StartDate = value
        End Set
    End Property
    Public Property BOOL As Boolean
        Get
            BOOL = m_bool
        End Get
        Set(ByVal value As Boolean)
            m_bool = value
        End Set
    End Property
End Class
