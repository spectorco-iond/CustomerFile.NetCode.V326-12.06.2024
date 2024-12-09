Public Class cExact_Traveler_Permission
    Private m_intID As Integer
    Private m_strUser_Name As String
    Private m_strFullname As String
    Private m_strEmail As String
    Private m_intPerm_group_id As Integer
    Private m_strPassword As String
    Private m_intEmployee_id As String
    Private m_intPayroll_dept_code As String
    Private m_blMdbPermission As Boolean
    Private m_strGroup_name As String

    Public Sub New()
        Call Init()
        Call Load()
    End Sub
    Public Sub New(ByVal p_sqlQuery As String)
        Call Init()
        Call Load(p_sqlQuery)
    End Sub
#Region "----------------------- Private Region --------------------------"

    Private Sub Init()
        m_intID = 0
        m_strUser_Name = String.Empty
        m_strFullname = String.Empty
        m_strEmail = String.Empty
        m_intPerm_group_id = 0
        m_strPassword = String.Empty
        m_intEmployee_id = String.Empty
        m_intPayroll_dept_code = String.Empty
        m_blMdbPermission = False
        m_strGroup_name = String.Empty
    End Sub

    'm_intID 
    'm_strUser_Name 
    'm_strFullname 
    'm_strEmail 
    'm_intPerm_group_id 
    'm_strPassword 
    'm_intEmployee_id 
    'm_intPayroll_dept_code 
    'm_blMdbPermission 
    'm_strGroup_name

    'ID 
    'User_Name 
    'Fullname 
    'Email 
    'Perm_group_id 
    'Password 
    'Employee_id 
    'Payroll_dept_code 
    'MdbPermission 
    'Group_name
    Private Sub LoadLine(pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then m_intID = pdrRow.Item("ID")
            If Not (pdrRow.Item("User_Name").Equals(DBNull.Value)) Then m_strUser_Name = pdrRow.Item("User_Name").ToString
            If Not (pdrRow.Item("Fullname").Equals(DBNull.Value)) Then m_strFullname = pdrRow.Item("Fullname").ToString
            If Not (pdrRow.Item("Email").Equals(DBNull.Value)) Then m_strEmail = pdrRow.Item("Email").ToString
            If Not (pdrRow.Item("Perm_group_id").Equals(DBNull.Value)) Then m_intPerm_group_id = pdrRow.Item("Perm_group_id")
            If Not (pdrRow.Item("Password").Equals(DBNull.Value)) Then m_strPassword = pdrRow.Item("Password").ToString
            If Not (pdrRow.Item("Employee_id").Equals(DBNull.Value)) Then m_intEmployee_id = pdrRow.Item("Employee_id").ToString
            If Not (pdrRow.Item("Payroll_dept_code").Equals(DBNull.Value)) Then m_intPayroll_dept_code = pdrRow.Item("Payroll_dept_code").ToString
            If Not (pdrRow.Item("MdbPermission").Equals(DBNull.Value)) Then m_blMdbPermission = pdrRow.Item("MdbPermission")
            If Not (pdrRow.Item("Group_name").Equals(DBNull.Value)) Then m_strGroup_name = pdrRow.Item("Group_name").ToString
        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Permission." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadLine(ByRef pClass As CustomerFile.cExact_Traveler_Permission, pdrRow As System.Data.DataRow)
        Try
            If Not (pdrRow.Item("ID").Equals(DBNull.Value)) Then pClass.ID = pdrRow.Item("ID")
            If Not (pdrRow.Item("User_Name").Equals(DBNull.Value)) Then pClass.User_Name = pdrRow.Item("User_Name").ToString
            If Not (pdrRow.Item("Fullname").Equals(DBNull.Value)) Then pClass.Fullname = pdrRow.Item("Fullname").ToString
            If Not (pdrRow.Item("Email").Equals(DBNull.Value)) Then pClass.Email = pdrRow.Item("Email").ToString
            If Not (pdrRow.Item("Perm_group_id").Equals(DBNull.Value)) Then pClass.perm_group_id = pdrRow.Item("Perm_group_id")
            If Not (pdrRow.Item("Password").Equals(DBNull.Value)) Then pClass.Password = pdrRow.Item("Password").ToString
            If Not (pdrRow.Item("Employee_id").Equals(DBNull.Value)) Then pClass.employee_id = pdrRow.Item("Employee_id").ToString
            If Not (pdrRow.Item("Payroll_dept_code").Equals(DBNull.Value)) Then pClass.payroll_dept_code = pdrRow.Item("Payroll_dept_code").ToString
            If Not (pdrRow.Item("MdbPermission").Equals(DBNull.Value)) Then pClass.MdbPermission = pdrRow.Item("MdbPermission")
            If Not (pdrRow.Item("Group_name").Equals(DBNull.Value)) Then pClass.Group_Name = pdrRow.Item("Group_name").ToString

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Permission." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Load()
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
              " SELECT  p.ID,p.User_Name,Fullname ,p.Email,perm_group_id ,p.Password ,p.employee_id,p.payroll_dept_code,p.MdbPermission ,pg.group_name  " &
              "  from EXACT_TRAVELER_PERMISSION p WITH (Nolock) left join  EXACT_TRAVELER_PERMISSION_GROUP pg WITH (Nolock) on p.perm_group_id = pg.id  " &
              " WHERE  Ltrim(Rtrim(User_Name)) = '" & Environment.UserName & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Permission." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "--------------------------------- Public Function -----------------------------"

    Public Function Load(Optional ByVal pstrQuery As String = "") As Boolean
        Load = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
             " SELECT  p.ID,p.User_Name,Fullname ,p.Email,perm_group_id ,p.Password ,p.employee_id,p.payroll_dept_code,p.MdbPermission ,pg.group_name  " &
             "  from EXACT_TRAVELER_PERMISSION p WITH (Nolock) left join  EXACT_TRAVELER_PERMISSION_GROUP pg WITH (Nolock) on p.perm_group_id = pg.id  "

            If pstrQuery <> "" Then
                strSql &= pstrQuery
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
                Load = True
            End If

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Permission." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function LoadLst(Optional ByVal pStrQuery As String = "") As List(Of cExact_Traveler_Permission)

        LoadLst = New List(Of cExact_Traveler_Permission)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cExact_Traveler_Permission)
            Dim i As Integer
            Dim strSql As String

            strSql =
                " SELECT  p.ID,p.User_Name,Fullname ,p.Email,perm_group_id ,p.Password ,p.employee_id,p.payroll_dept_code,p.MdbPermission ,pg.group_name  " &
              "  from EXACT_TRAVELER_PERMISSION p WITH (Nolock) left join  EXACT_TRAVELER_PERMISSION_GROUP pg WITH (Nolock) on p.perm_group_id = pg.id  "

            If pStrQuery <> "" Then
                strSql &= pStrQuery
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cExact_Traveler_Permission
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            LoadLst = myList

        Catch ex As Exception
            MsgBox("Error in cExact_Traveler_Permission." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "----------------------- Public Properties -------------------------"

    Public Property ID As Integer
        Get
            Return m_intID
        End Get
        Set(value As Integer)
            m_intID = value
        End Set
    End Property

    Public Property User_Name As String
        Get
            Return m_strUser_Name
        End Get
        Set(value As String)
            m_strUser_Name = value
        End Set
    End Property

    Public Property Fullname As String
        Get
            Return m_strFullname
        End Get
        Set(value As String)
            m_strFullname = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return m_strEmail
        End Get
        Set(value As String)
            m_strEmail = value
        End Set
    End Property

    Public Property perm_group_id As Integer
        Get
            Return m_intPerm_group_id
        End Get
        Set(value As Integer)
            m_intPerm_group_id = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return m_strPassword
        End Get
        Set(value As String)
            m_strPassword = value
        End Set
    End Property

    Public Property employee_id As String
        Get
            Return m_intEmployee_id
        End Get
        Set(value As String)
            m_intEmployee_id = value
        End Set
    End Property

    Public Property payroll_dept_code As String
        Get
            Return m_intPayroll_dept_code
        End Get
        Set(value As String)
            m_intPayroll_dept_code = value
        End Set
    End Property

    Public Property MdbPermission As Boolean
        Get
            Return m_blMdbPermission
        End Get
        Set(value As Boolean)
            m_blMdbPermission = value
        End Set
    End Property
    Public Property Group_Name As String
        Get
            Return m_strGroup_name
        End Get
        Set(value As String)
            m_strGroup_name = value
        End Set
    End Property
#End Region
End Class
