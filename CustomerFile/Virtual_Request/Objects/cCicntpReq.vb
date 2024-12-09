Public Class cCicntpReq

    Private m_ID As Int32
    Private m_cnt_id As String
    Private m_cmp_wwn As String
    Private m_cnt_f_name As String
    Private m_cnt_l_name As String
    Private m_cnt_m_name As String
    Private m_FullName As String
    Private m_Gender As String
    Private m_cnt_job_desc As String
    Private m_cnt_dept As String
    Private m_taalcode As String
    Private m_cnt_f_ext As String
    Private m_cnt_f_fax As String
    Private m_cnt_f_tel As String
    Private m_cnt_f_mobile As String
    Private m_cnt_email As String
    Private m_cnt_acc_man As Int32
    Private m_active As String
    Private m_active_y As Int32

    Public Sub New()
        Call Init()
    End Sub

#Region "-------------------- Private function ----------------------------"
    Private Sub Init()

        m_ID = 0
        m_cnt_id = String.Empty
        m_cmp_wwn = String.Empty
        m_cnt_f_name = String.Empty
        m_cnt_l_name = String.Empty
        m_cnt_m_name = String.Empty
        m_FullName = String.Empty
        m_Gender = String.Empty
        m_cnt_job_desc = String.Empty
        m_cnt_dept = String.Empty
        m_taalcode = String.Empty
        m_cnt_f_ext = String.Empty
        m_cnt_f_fax = String.Empty
        m_cnt_f_tel = String.Empty
        m_cnt_f_mobile = String.Empty
        m_cnt_acc_man = 0
        m_active = String.Empty
        m_active_y = 0

    End Sub
    Private Sub SaveLine(ByRef pdrRow As DataRow)
        Try

            With pdrRow
                .Item("ID") = m_ID
                .Item("cnt_id") = m_cnt_id
                .Item("cmp_wwn") = m_cmp_wwn
                .Item("cnt_f_name") = m_cnt_f_name
                .Item("cnt_l_name") = m_cnt_l_name
                .Item("cnt_m_name") = m_cnt_m_name
                .Item("FullName") = m_FullName
                .Item("Gender") = m_Gender
                .Item("cnt_job_desc") = m_cnt_job_desc
                .Item("cnt_dept") = m_cnt_dept
                .Item("taalcode") = m_taalcode
                .Item("cnt_f_ext") = m_cnt_f_ext
                .Item("cnt_f_fax") = m_cnt_f_fax
                .Item("cnt_f_tel") = m_cnt_f_tel
                .Item("cnt_f_mobile") = m_cnt_f_mobile
                .Item("cnt_email") = m_cnt_email
                .Item("cnt_acc_man") = m_cnt_acc_man
                .Item("active_y") = m_active_y
            End With

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.SaveLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            With pdrRow
                If Not (.Item("ID").Equals(DBNull.Value)) Then m_ID = .Item("ID")
                If Not (.Item("cnt_id").Equals(DBNull.Value)) Then m_cnt_id = .Item("cnt_id").ToString
                If Not (.Item("cmp_wwn").Equals(DBNull.Value)) Then m_cmp_wwn = .Item("cmp_wwn").ToString
                If Not (.Item("cnt_f_name").Equals(DBNull.Value)) Then m_cnt_f_name = .Item("cnt_f_name").ToString
                If Not (.Item("cnt_l_name").Equals(DBNull.Value)) Then m_cnt_l_name = .Item("cnt_l_name").ToString
                If Not (.Item("cnt_m_name").Equals(DBNull.Value)) Then m_cnt_m_name = .Item("cnt_m_name").ToString
                If Not (.Item("FullName").Equals(DBNull.Value)) Then m_FullName = .Item("FullName").ToString
                If Not (.Item("Gender").Equals(DBNull.Value)) Then m_Gender = .Item("Gender").ToString
                If Not (.Item("cnt_job_desc").Equals(DBNull.Value)) Then m_cnt_job_desc = .Item("cnt_job_desc").ToString
                If Not (.Item("cnt_dept").Equals(DBNull.Value)) Then m_cnt_dept = .Item("cnt_dept").ToString
                If Not (.Item("taalcode").Equals(DBNull.Value)) Then m_taalcode = .Item("taalcode").ToString
                If Not (.Item("cnt_f_ext").Equals(DBNull.Value)) Then m_cnt_f_ext = .Item("cnt_f_ext").ToString
                If Not (.Item("cnt_f_fax").Equals(DBNull.Value)) Then m_cnt_f_fax = .Item("cnt_f_fax").ToString
                If Not (.Item("cnt_f_tel").Equals(DBNull.Value)) Then m_cnt_f_tel = .Item("cnt_f_tel").ToString
                If Not (.Item("cnt_f_mobile").Equals(DBNull.Value)) Then m_cnt_f_mobile = .Item("cnt_f_mobile").ToString
                If Not (.Item("cnt_email").Equals(DBNull.Value)) Then m_cnt_email = .Item("cnt_email").ToString
                If Not (.Item("cnt_acc_man").Equals(DBNull.Value)) Then m_cnt_acc_man = .Item("cnt_acc_man")
                If Not (.Item("active_y").Equals(DBNull.Value)) Then m_active = .Item("active_y").ToString

                If Not (.Item("active_y").Equals(DBNull.Value)) Then m_active_y = .Item("active_y")

            End With

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.LoadLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(pClass As cCicntpReq, ByRef pdrRow As DataRow)
        Try
            With pdrRow
                If Not (.Item("ID").Equals(DBNull.Value)) Then pClass.m_ID = .Item("ID")
                If Not (.Item("cnt_id").Equals(DBNull.Value)) Then pClass.m_cnt_id = .Item("cnt_id").ToString
                If Not (.Item("cmp_wwn").Equals(DBNull.Value)) Then pClass.m_cmp_wwn = .Item("cmp_wwn").ToString
                If Not (.Item("cnt_f_name").Equals(DBNull.Value)) Then pClass.m_cnt_f_name = .Item("cnt_f_name").ToString
                If Not (.Item("cnt_l_name").Equals(DBNull.Value)) Then pClass.m_cnt_l_name = .Item("cnt_l_name").ToString
                If Not (.Item("cnt_m_name").Equals(DBNull.Value)) Then pClass.m_cnt_m_name = .Item("cnt_m_name").ToString
                If Not (.Item("FullName").Equals(DBNull.Value)) Then pClass.m_FullName = .Item("FullName").ToString
                If Not (.Item("Gender").Equals(DBNull.Value)) Then pClass.m_Gender = .Item("Gender").ToString
                If Not (.Item("cnt_job_desc").Equals(DBNull.Value)) Then pClass.m_cnt_job_desc = .Item("cnt_job_desc").ToString
                If Not (.Item("cnt_dept").Equals(DBNull.Value)) Then pClass.m_cnt_dept = .Item("cnt_dept").ToString
                If Not (.Item("taalcode").Equals(DBNull.Value)) Then pClass.m_taalcode = .Item("taalcode").ToString
                If Not (.Item("cnt_f_ext").Equals(DBNull.Value)) Then pClass.m_cnt_f_ext = .Item("cnt_f_ext").ToString
                If Not (.Item("cnt_f_fax").Equals(DBNull.Value)) Then pClass.m_cnt_f_fax = .Item("cnt_f_fax").ToString
                If Not (.Item("cnt_f_tel").Equals(DBNull.Value)) Then pClass.m_cnt_f_tel = .Item("cnt_f_tel").ToString
                If Not (.Item("cnt_f_mobile").Equals(DBNull.Value)) Then pClass.m_cnt_f_mobile = .Item("cnt_f_mobile").ToString
                If Not (.Item("cnt_email").Equals(DBNull.Value)) Then pClass.m_cnt_email = .Item("cnt_email").ToString
                If Not (.Item("cnt_acc_man").Equals(DBNull.Value)) Then pClass.m_cnt_acc_man = .Item("cnt_acc_man")
                If Not (.Item("active").Equals(DBNull.Value)) Then pClass.m_active = .Item("active").ToString
                If Not (.Item("active_y").Equals(DBNull.Value)) Then pClass.m_active_y = .Item("active_y")

            End With

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.LoadLine(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "--------------------- Public Function -----------------------------"
    Public Sub Load(ByVal pID As Int32)
        Try
            Dim db As New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql =
                " SELECT * FROM Cicmpy WITH (NOLOCK) " &
                " WHERE ID = " & pID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Load(ByVal p_strGuid As String)
        Try
            Dim db As New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql =
                " SELECT * FROM cicntp WITH (NOLOCK) " &
                " WHERE ISNULL(active_y,0) = 1 And cnt_id = '" & p_strGuid & "'"

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function GetList_cCicntpReq() As List(Of cCicntpReq)

        GetList_cCicntpReq = New List(Of cCicntpReq)
        Try
            Dim oEnum = New cCicntpReq
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCicntpReq)
            Dim i As Integer
            Dim strSql As String

            strSql = "select  ID,cnt_id,cmp_wwn,cnt_f_name,cnt_l_name,cnt_m_name,FullName, Gender,cnt_job_desc, cnt_dept, " _
                    & " taalcode,cnt_f_ext,CNT_F_FAX,cnt_f_tel,cnt_f_mobile,cnt_email,cnt_acc_man," _
                    & " Case  when active_y = 1 then 'Yes' " _
                    & " when active_y = 0 then 'NOT' " _
                    & " else 'NOT' end as active , active_y" _
                    & " From cicntp WITH (NOLOCK) where ISNULL(active_y,0) = 1 "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cCicntpReq
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_cCicntpReq = myList

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function GetList_cCicntpReq(ByVal m_cmp_wwn As String, Optional ByVal m_search As String = "") As List(Of cCicntpReq)

        GetList_cCicntpReq = New List(Of cCicntpReq)
        Try

            Dim oEnum = New cCicntpReq
            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCicntpReq)
            Dim i As Integer
            Dim strSql As String

            strSql = " select  ID,cnt_id,cmp_wwn,cnt_f_name,cnt_l_name,cnt_m_name,FullName, Gender,cnt_job_desc, cnt_dept, " _
                    & " taalcode,cnt_f_ext,CNT_F_FAX,cnt_f_tel,cnt_f_mobile,cnt_email,cnt_acc_man, " _
                    & " Case  when active_y = 1 then 'Yes' " _
                    & " when active_y = 0 then 'NOT' " _
                    & " else 'NOT' end as active , active_y" _
                    & " From cicntp WITH (NOLOCK) where ISNULL(active_y,0) = 1 And cmp_wwn = '" & m_cmp_wwn & "' "

            '++ID 11.13.2019 added criteria for exclude inactive contacts active_y = 1 

            If m_search.Length <> 0 Then
                strSql &= " AND (FullName like '%" & m_search & "%' or cnt_email like '%" & m_search & "%')"
            End If

            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                ' myList.Insert(0, oEnum)
                For i = 0 To dt.Rows.Count - 1
                    oEnum = New cCicntpReq
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_cCicntpReq = myList

        Catch ex As Exception
            MsgBox("Error in cCicntpReq.Load(). " & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "---------------------------- Public Properties --------------------------------"

    Public Property ID As Int32
        Get
            ID = m_ID
        End Get
        Set(ByVal value As Int32)
            m_ID = ID
        End Set
    End Property
    Public Property CNT_ID As String
        Get
            CNT_ID = m_cnt_id
        End Get
        Set(ByVal value As String)
            m_cnt_id = CNT_ID
        End Set
    End Property
    Public Property CMP_WWN As String
        Get
            CMP_WWN = m_cmp_wwn
        End Get
        Set(ByVal value As String)
            m_cmp_wwn = CMP_WWN
        End Set
    End Property
    Public Property CNT_F_NAME As String
        Get
            CNT_F_NAME = m_cnt_f_name
        End Get
        Set(ByVal value As String)
            m_cnt_f_name = CNT_F_NAME
        End Set
    End Property
    Public Property CNT_L_NAME As String
        Get
            CNT_L_NAME = m_cnt_l_name
        End Get
        Set(ByVal value As String)
            m_cnt_l_name = CNT_L_NAME
        End Set
    End Property
    Public Property CNT_M_NAME As String
        Get
            CNT_M_NAME = m_cnt_m_name
        End Get
        Set(ByVal value As String)
            m_cnt_m_name = CNT_M_NAME
        End Set
    End Property
    Public Property FULLNAME As String
        Get
            FULLNAME = m_FullName
        End Get
        Set(ByVal value As String)
            m_FullName = FULLNAME
        End Set
    End Property
    Public Property GENDER As String
        Get
            GENDER = m_Gender
        End Get
        Set(ByVal value As String)
            m_Gender = GENDER
        End Set
    End Property
    Public Property CNT_JOB_DESC As String
        Get
            CNT_JOB_DESC = m_cnt_job_desc
        End Get
        Set(ByVal value As String)
            m_cnt_job_desc = CNT_JOB_DESC
        End Set
    End Property
    Public Property CNT_DEPT As String
        Get
            CNT_DEPT = m_cnt_dept
        End Get
        Set(ByVal value As String)
            m_cnt_dept = CNT_DEPT
        End Set
    End Property
    Public Property TAALCODE As String
        Get
            TAALCODE = m_taalcode
        End Get
        Set(ByVal value As String)
            m_taalcode = TAALCODE
        End Set
    End Property
    Public Property CNT_F_EXT As String
        Get
            CNT_F_EXT = m_cnt_f_ext
        End Get
        Set(ByVal value As String)
            m_cnt_f_ext = CNT_F_EXT
        End Set
    End Property
    Public Property CNT_F_FAX As String
        Get
            CNT_F_FAX = m_cnt_f_fax
        End Get
        Set(ByVal value As String)
            m_cnt_f_fax = CNT_F_FAX
        End Set
    End Property
    Public Property CNT_F_TEL As String
        Get
            CNT_F_TEL = m_cnt_f_tel
        End Get
        Set(ByVal value As String)
            m_cnt_f_tel = CNT_F_TEL
        End Set
    End Property
    Public Property CNT_F_MOBILE As String
        Get
            CNT_F_MOBILE = m_cnt_f_mobile
        End Get
        Set(ByVal value As String)
            m_cnt_f_mobile = CNT_F_MOBILE
        End Set
    End Property
    Public Property CNT_EMAIL As String
        Get
            CNT_EMAIL = m_cnt_email
        End Get
        Set(ByVal value As String)
            m_cnt_email = CNT_EMAIL
        End Set
    End Property
    Public Property CNT_ACC_MAN As Int32
        Get
            CNT_ACC_MAN = m_cnt_acc_man
        End Get
        Set(ByVal value As Int32)
            m_cnt_acc_man = CNT_ACC_MAN
        End Set
    End Property
    Public Property ACTIVE As String
        Get
            ACTIVE = m_active
        End Get
        Set(ByVal value As String)
            m_active = ACTIVE
        End Set
    End Property
    Public Property ACTIVE_Y As Int32
        Get
            ACTIVE_Y = m_active_y
        End Get
        Set(ByVal value As Int32)
            m_active_y = ACTIVE_Y
        End Set
    End Property

    'Private Sub cleanAs()
    '    m_ID
    '    m_cnt_id
    '    m_cmp_wwn
    '    m_cnt_f_name
    '    m_cnt_l_name
    '    m_cnt_m_name
    '    m_FullName
    '    m_Gender
    '    m_cnt_job_desc
    '    m_cnt_dept
    '    m_taalcode
    '    m_cnt_f_ext
    '    m_cnt_f_fax
    '    m_cnt_f_tel
    '    m_cnt_f_mobile
    '    m_cnt_email
    '    m_cnt_acc_man
    '    m_active_y
    'End Sub
    'Private Sub cleanPro()
    '    ID
    '    cnt_id
    '    cmp_wwn
    '    cnt_f_name
    '    cnt_l_name
    '    cnt_ name
    '     FullName
    '    Gender
    '    cnt_job_desc
    '    cnt_dept
    '    taalcode
    '    cnt_f_ext
    '    cnt_f_fax
    '    cnt_f_tel
    '    cnt_f_mobile
    '    cnt_email
    '    cnt_acc_man
    '    active_y
    'End Sub

#End Region



End Class
