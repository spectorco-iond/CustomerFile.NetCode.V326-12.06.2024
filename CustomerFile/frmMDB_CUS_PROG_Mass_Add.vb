Public Class frmMDB_CUS_PROG_Mass_Add

    Private m_strProg_Guid As String = ""
    Private m_strItem_List As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pstrProg_Guid As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_strProg_Guid = pstrProg_Guid

    End Sub

    Public Property Item_List() As String
        Get
            Item_List = m_strItem_List
        End Get
        Set(value As String)
            m_strItem_List = value
        End Set
    End Property

    Public ReadOnly Property Item_List(ByVal pSplitChar As Char) As String()
        Get
            ' The additional space is to create a CRLF on the last line else is does not.
            m_strItem_List = m_strItem_List.Replace(vbCrLf, " ") & " "
            Item_List = m_strItem_List.Split(pSplitChar)
        End Get
    End Property

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click

        m_strItem_List = txtItem_List.Text
        Me.Hide()

    End Sub

End Class