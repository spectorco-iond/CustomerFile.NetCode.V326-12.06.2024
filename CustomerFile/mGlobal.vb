Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices

Public Class WorkaroundDataGridViewComboBoxCell

    Inherits DataGridViewComboBoxCell

    Public Overloads Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

        Dim cb As ComboBox = TryCast(MyBase.DataGridView.EditingControl, ComboBox)

        cb.DropDownHeight = 120

    End Sub

End Class

Module mGlobal

    'variable was added for identify if frmCustomer i open 
    'the variable is used in ucShowRequest when we want open frmStoryBoardRequest
    Public varIdentIfCustFormIsOpen As Boolean = False
    'Public Structure SpectorControlSettings
    '    Dim StartHidden As Boolean
    '    Dim AskConfirmation As Boolean
    '    Dim MinimizeOnClose As Boolean
    'End Structure

    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    'this two variable we use for customized packaging
    Public printScreen As String
    Public pack_code As String
    Public frm_pack_close As Boolean
    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

    Public Declare Function GetUsername Lib "advapi32.dll" Alias "GetUserNameA" (ByVal lpBuffer As String, ByRef nSize As Integer) As Integer

#Region "    DGV Columns functions ############################### "

    Public Function DGVButtonColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewButtonColumn

        DGVButtonColumn = New DataGridViewButtonColumn

        DGVButtonColumn.HeaderText = pstrHeaderText
        DGVButtonColumn.DataPropertyName = pstrName
        DGVButtonColumn.Name = pstrName
        DGVButtonColumn.Text = pstrHeaderText
        DGVButtonColumn.UseColumnTextForButtonValue = True

        If plWidth <> 0 Then DGVButtonColumn.Width = plWidth

    End Function

    Public Function DGVButtonCell(ByVal pstrValue As String) As DataGridViewButtonCell

        DGVButtonCell = New DataGridViewButtonCell

        DGVButtonCell.UseColumnTextForButtonValue = True
        DGVButtonCell.Value = "C"

    End Function

    Public Function DGVCalendarColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As CalendarColumn

        DGVCalendarColumn = New CalendarColumn

        DGVCalendarColumn.HeaderText = pstrHeaderText
        DGVCalendarColumn.DataPropertyName = pstrName
        DGVCalendarColumn.Name = pstrName
        'DGVCalendarColumn.DefaultCellStyle = "mm/dd/yyyy"
        ' DGVCalendarColumn.DefaultCellStyle.Format = "mm/dd/yyyy"
        DGVCalendarColumn.DefaultCellStyle.Format = "MM/dd/yyyy"

        If plWidth <> 0 Then DGVCalendarColumn.Width = plWidth

    End Function

    Public Function DGVCheckBoxColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewCheckBoxColumn

        DGVCheckBoxColumn = New DataGridViewCheckBoxColumn

        DGVCheckBoxColumn.HeaderText = pstrHeaderText
        DGVCheckBoxColumn.DataPropertyName = pstrName
        DGVCheckBoxColumn.Name = pstrName

        DGVCheckBoxColumn.FalseValue = 0 '"False"
        DGVCheckBoxColumn.TrueValue = 1 '"True"
        DGVCheckBoxColumn.IndeterminateValue = 0 '"False"


        If plWidth <> 0 Then DGVCheckBoxColumn.Width = plWidth

    End Function

    Public Function DGVComboBoxColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewComboBoxColumn

        DGVComboBoxColumn = New DataGridViewComboBoxColumn

        With DGVComboBoxColumn
            '  .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .HeaderText = pstrHeaderText
            .DataPropertyName = pstrName
            .Name = pstrName
            .MaxDropDownItems = 10
            .FlatStyle = FlatStyle.Flat
            .Width = plWidth
        End With

        If plWidth <> 0 Then DGVComboBoxColumn.Width = plWidth

        DGVComboBoxColumn.CellTemplate = New WorkaroundDataGridViewComboBoxCell()

    End Function

    Public Function DGVImageColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, ByVal plWidth As Long) As DataGridViewImageColumn

        DGVImageColumn = New DataGridViewImageColumn
        DGVImageColumn.Name = pstrName
        DGVImageColumn.DataPropertyName = pstrName
        DGVImageColumn.HeaderText = pstrHeaderText

        If plWidth <> 0 Then DGVImageColumn.Width = plWidth

    End Function

    Public Function DGVTextBoxColumn(ByVal pstrName As String, ByVal pstrHeaderText As String, Optional ByVal plWidth As Long = 0) As DataGridViewTextBoxColumn

        DGVTextBoxColumn = New DataGridViewTextBoxColumn

        DGVTextBoxColumn.HeaderText = pstrHeaderText
        DGVTextBoxColumn.DataPropertyName = pstrName
        DGVTextBoxColumn.Name = pstrName


        If plWidth <> 0 Then DGVTextBoxColumn.Width = plWidth

    End Function

    Public Function GetDDTestsDataTable(ByVal pstrTable As String, ByVal pstrField As String) As DataTable

        Dim dt As DataTable
        Dim db As New cDBA
        Dim strsql As String = _
        "SELECT     DatabaseChar, DisplayChar, ISNULL(Description, '') AS Description " & _
        "FROM       DDTests WITH (nolock) " & _
        "WHERE      TableName = 'cicmpy' AND FieldName = 'cmp_type' " & _
        "ORDER BY   TableName, FieldName, DatabaseChar "

        dt = db.DataTable(strsql)

        Return dt

    End Function

    Public Function GetElementDescription(ByVal pstrTable As String, ByVal pstrField As String, ByVal pstrValue As String, Optional ByVal pstrValue2 As String = "") As String

        GetElementDescription = ""

        Dim dt As DataTable
        Dim db As New cDBA
        Dim strsql As String = ""

        Select Case pstrTable.ToUpper

            Case "ADDRESSSTATES" ' States and provinces
                strsql = _
                "SELECT StateCode, ISNULL(Name, '') AS Description, CountryCode " & _
                "FROM   AddressStates WITH (Nolock) " & _
                "WHERE  CountryCode='" & pstrValue & "' AND StateCode = '" & pstrValue2 & "' "

            Case "ARSLMFIL_SQL"
                'strsql = "SELECT * FROM ARSLMFIL_SQL WITH (Nolock) WHERE HumRes_ID = '" & pstrValue & "'"
                strsql = _
                "SELECT HUMRES_ID, SLSPSN_NAME AS DESCRIPTION " & _
                "FROM   ARSLMFIL_SQL WITH (Nolock) " & _
                "WHERE  HumRes_ID = '" & pstrValue & "'"

            Case "CICMPY"

                Select Case pstrField.ToUpper

                    Case "CMP_CODE"
                        strsql = _
                        "SELECT Cmp_Code, ISNULL(cmp_name, '') AS Description " & _
                        "FROM   Cicmpy WITH (Nolock) " & _
                        "WHERE 	Cmp_Code = '" & pstrValue & "' "

                    Case "CMP_PARENT"
                        strsql = _
                        "SELECT Cmp_Code AS Description " & _
                        "FROM   Cicmpy WITH (Nolock) " & _
                        "WHERE  CMP_WWN = '" & pstrValue & "' "

                    Case ""
                        'Case ""
                        'Case ""

                End Select

            Case "CLASSIFICATIONS"
                strsql = _
                "SELECT     C.ClassificationID, ISNULL(C.Description, '') AS Description " & _
                "FROM       Classifications C WITH (Nolock) " & _
                "LEFT JOIN  DDTests D WITH (Nolock) ON D.TableName = 'cicmpy' AND D.FieldName = 'cmp_type' AND C.Type = D.DatabaseChar " & _
                "WHERE      C.Type IS NULL AND C.ClassificationID = '" & pstrValue & "' "

            Case "HUMRES"

                Select Case pstrField.ToUpper

                    Case "FULLNAME"
                        strsql = _
                        "SELECT ISNULL(FULLNAME, '') AS Description " & _
                        "FROM   Humres WITH (Nolock) " & _
                        "WHERE 	res_id = " & pstrValue & " "

                    Case "MAIL"
                        strsql = _
                        "SELECT ISNULL(MAIL, '') AS Description " & _
                        "FROM   Humres WITH (Nolock) " & _
                        "WHERE  res_id = " & pstrValue & " "

                    Case "TELNR_WERK" ' YES IT IS WRITTEN THAT WAY IN MACOLA...
                        strsql = _
                        "SELECT ISNULL(TELNR_WERK, '') AS Description " & _
                        "FROM   Humres WITH (Nolock) " & _
                        "WHERE  res_id = " & pstrValue & " "

                    Case ""
                        'Case ""
                        'Case ""

                End Select

            Case "LAND" ' Country
                strsql = _
                "SELECT LandCode, ISNULL(OMS60_0, '') AS Description " & _
                "FROM   Land WITH (Nolock) " & _
                "WHERE  Active = 1 AND LandCode = '" & pstrValue & "' "

            Case "SYCDEFIL_SQL"
                strsql = _
                "SELECT Sy_Code, ISNULL(Code_Desc, '') AS Description " & _
                "FROM   SYCDEFIL_SQL WITH (Nolock) " & _
                "WHERE  Sy_Code = '" & pstrValue & "'"

            Case "SYTRMFIL_SQL"
                strsql = _
                "SELECT Term_Code, ISNULL(Description, '') AS Description " & _
                "FROM   SYTRMFIL_SQL WITH (Nolock) " & _
                "WHERE  Term_Code = '" & pstrValue & "'"

            Case "TAAL"
                strsql = _
                "SELECT TaalCode, ISNULL(OMS30_0, '') AS Description " & _
                "FROM   Taal WITH (Nolock) " & _
                "WHERE  TaalCode = '" & pstrValue & "' "

            Case "TAXDETL_SQL"
                strsql = _
                "SELECT Tax_Cd, ISNULL(Tax_Cd_Description, '') AS Description " & _
                "FROM   TAXDETL_SQL WITH (Nolock) " & _
                "WHERE  Tax_Cd = '" & pstrValue & "' "

            Case "TAXSCHED_SQL"
                strsql = _
                "SELECT Tax_Sched, ISNULL(Tax_Sched_Desc, '') AS Description " & _
                "FROM   TAXSCHED_SQL WITH (Nolock) " & _
                "WHERE  Tax_Sched = '" & pstrValue & "'"

        End Select

        If strsql = "" Then

            strsql = _
            "SELECT     DatabaseChar, DisplayChar, ISNULL(Description, '') AS Description " & _
            "FROM       DDTests WITH (nolock) " & _
            "WHERE      TableName = '" & pstrTable & "' AND FieldName = '" & pstrField & "' AND DatabaseChar = '" & pstrValue & "' " & _
            "ORDER BY   TableName, FieldName, DatabaseChar "

        End If

        dt = db.DataTable(strsql)

        If dt.Rows.Count <> 0 Then
            GetElementDescription = dt.Rows(0).Item("Description").ToString
        End If

        'Dim strSql As String = "SELECT * FROM SYCDEFIL_SQL WITH (Nolock) WHERE sy_code = '" & pstrShip_Via_Cd & "'"
        'Dim strSql As String = "SELECT * FROM SYTRMFIL_SQL WITH (Nolock) WHERE Term_Code = '" & pstrAr_Terms_Cd & "'"
        'Dim strSql As String = "SELECT * FROM TAXSCHED_SQL WITH (Nolock) WHERE Tax_Sched = '" & pstrTax_Sched & "'"
        'Dim strSql As String = _
        '"SELECT ISNULL(Tax_Cd_Description, '') AS Tax_Cd_Description " & _
        '"FROM TAXDETL_SQL WITH (Nolock) WHERE Tax_Cd"
        'Dim strSql As String = "SELECT * FROM ARSLMFIL_SQL WITH (Nolock) WHERE HumRes_ID = '" & piSlspsn_No & "'"

    End Function

#End Region

#Region "    CalendarColumn Class ##############################################"

    Public Class CalendarColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)

                ' Ensure that the cell used for the template is a CalendarCell.
                If (value IsNot Nothing) AndAlso _
                    Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                    Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value

            End Set
        End Property

    End Class

    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            ' Use the short date format.
            Me.Style.Format = "d"

        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
            ByVal initialFormattedValue As Object, _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)

            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl = _
                CType(DataGridView.EditingControl, CalendarEditingControl)

            If (Me.RowIndex <> -1) Then
                ' Use the default row value when Value property is null.
                If (Me.Value Is Nothing) Or (Me.Value.Equals(DBNull.Value)) Then
                    ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
                Else
                    ctl.Value = CType(Me.Value, DateTime)
                End If
            End If

        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing control that CalendarCell uses.
                Return GetType(CalendarEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains.
                Return GetType(DateTime)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value.
                Return DateTime.Now
            End Get
        End Property

    End Class

    Class CalendarEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            Me.Format = DateTimePickerFormat.Short
        End Sub

        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue

            Get
                Return Me.Value.ToShortDateString()
            End Get

            Set(ByVal value As Object)
                Try
                    ' This will throw an exception of the string is 
                    ' null, empty, or not in the format of a date.
                    Me.Value = DateTime.Parse(CStr(value))
                Catch
                    ' In the case of an exception, just use the default
                    ' value so we're not left with a null value.
                    Me.Value = DateTime.Now
                End Try
            End Set

        End Property

        Public Function GetEditingControlFormattedValue(ByVal context _
            As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Value.ToShortDateString()

        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
            DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

        End Sub

        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex

            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set

        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, _
            ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
            Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            ' Let the DateTimePicker handle the keys listed.
            Select Case key And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                    Return True

                Case Else
                    Return Not dataGridViewWantsInputKey
            End Select

        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            ' No preparation needs to be done.

        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange() _
            As Boolean Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange

            Get
                Return False
            End Get

        End Property

        Public Property EditingControlDataGridView() As DataGridView _
            Implements IDataGridViewEditingControl.EditingControlDataGridView

            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set

        End Property

        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged

            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set

        End Property

        Public ReadOnly Property EditingControlCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor

            Get
                Return MyBase.Cursor
            End Get

        End Property

        Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

            ' Notify the DataGridView that the contents of the cell have changed.
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)

        End Sub

    End Class

#End Region

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '////////////////       GET NTUSERID         //////////////////////////////////////////////////////////////////////////////////
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Function Version() As String
        Version = ""

        Try

            Dim _assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

            Dim fileInfo As New System.IO.FileInfo(_assembly.Location)

            Dim lastModified = fileInfo.LastWriteTime


            Version = "Version :" & " " & _assembly.GetName.Version.ToString & "; Date :  " & fileInfo.LastWriteTime 'lastModified.ToString("dd-MM-yyyy hh:mm tt") & ";"


        Catch ex As Exception
            MsgBox("Error in mGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function GetNTUserID() As String

        GetNTUserID = ""

        Try
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            Dim str_Renamed As String
            Dim API_Return As Short
            Dim length As Integer

            'Create string of nulls
            str_Renamed = New String(Chr(0), 255)

            'Call API
            API_Return = GetUsername(str_Renamed, Len(str_Renamed))

            'Returns 0 if failure
            If API_Return = 0 Then
                'failure
                'UPGRADE_WARNING: Couldn't resolve default property of object GetNTUserID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                GetNTUserID = ""
                Exit Function
            End If

            'str will have NTUserID followed by string of nulls
            'Find the first null characters in the string to determine the length of the userid
            length = InStr(1, str_Renamed, Chr(0)) - 1

            str_Renamed = Left(str_Renamed, length)

            'RETURN
            GetNTUserID = Trim(str_Renamed)
            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        Catch er As Exception
            MsgBox("Error in mGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    Public Function NoDate() As Date

        NoDate = New Date

    End Function

    Public Sub SetUser_Rights(ByRef User_Rights As String, ByVal pstrForm_Tag As String)

        Try
            Dim db As New cDBA
            Dim dt As DataTable
            Dim strSql As String
            Dim user As String = Environment.UserName 'Environment.UserName, pamelab, krista, lisa, angela, betty, tania, suzy

            strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & pstrForm_Tag & "' AND SCREEN_USER = '" & user & "' "
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                User_Rights = dt.Rows(0).Item("Access_Type").ToString
            Else
                strSql = "SELECT * FROM MDB_SYS_SCREEN_USER WHERE SCREEN_CD = '" & pstrForm_Tag & "' AND SCREEN_USER = 'ALL' "
                dt = db.DataTable(strSql)
                If dt.Rows.Count <> 0 Then
                    User_Rights = dt.Rows(0).Item("Access_Type").ToString
                End If
            End If

        Catch er As Exception
            MsgBox("Error in mGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    'Public Sub SetControl_Rights(ByRef User_Rights As String, ByVal pstrForm_Tag As String, ByRef Control_Name As String)
    Public Sub SetControl_Rights(ByRef User_Rights As String, ByRef oForm As Form)

        Try
            Dim oScreen As New cMDB_SYS_SCREEN(oForm.Tag.ToString)

            For Each c As Control In oForm.Controls

                If oScreen.Func_Name.Contains(c.Name) Then

                    ' This func has a hole to fix, if somehow a parameter of screen is Readonly, this one will overwrite.

                    Dim oFunc As New cMDB_SYS_SCREEN_FUNC_USER(oScreen.Screen_Id, c.Name, Environment.UserName)
                    If oFunc.Screen_Func_User_Id <> 0 Then

                        Select Case oFunc.Access_Type
                            Case "READWRITE"
                                c.Enabled = True

                            Case "SUPERUSER"
                                c.Enabled = True

                            Case "READONLY"
                                c.Enabled = False

                        End Select

                    End If

                End If

            Next

        Catch er As Exception
            MsgBox("Error in mGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Sub Get_Permission_Screen_Name(ByRef User_Rights As String, ByRef oForm As Form)

        Try
            Dim db As New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql = "SELECT * FROM MDB_SYS_SCREEN_FUNC_USER WHERE SCREEN_CD = '" & oForm.Tag & "' AND SCREEN_USER = '" & Environment.UserName & "' "
            dt = db.DataTable(strSql)
            If dt.Rows.Count <> 0 Then
                User_Rights = dt.Rows(0).Item("Access_Type").ToString
            Else
                strSql = "SELECT * FROM MDB_SYS_SCREEN_FUNC_USER WHERE SCREEN_CD = '" & oForm.Tag & "' AND SCREEN_USER = 'ALL' "
                dt = db.DataTable(strSql)
                If dt.Rows.Count <> 0 Then
                    User_Rights = dt.Rows(0).Item("Access_Type").ToString
                End If
            End If

        Catch er As Exception
            MsgBox("Error in mGlobal." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Sub

    Public Function GetLikeCondition(ByVal oColumnName As String, ByVal oValue As String) As String

        GetLikeCondition = ""

        Select Case oColumnName

            Case "Ord_No", "Inv_No", "Repeat_From", "RMA_No", "CT_Ord_No", "CT_Inv_No"
                If oValue.Trim.Length >= 6 And oValue.Trim.Length <= 8 Then
                    GetLikeCondition = oColumnName & " = '" & oValue.Trim.PadLeft(8, " ") & "' "

                Else
                    GetLikeCondition = oColumnName & " LIKE '%" & oValue & "%' "
                End If
            Case "Active_y"
                GetLikeCondition = oColumnName & " = " & oValue

            Case Else
                Dim oWords() As String

                GetLikeCondition = ""

                oValue = oValue.Replace("-", " ")
                oValue = oValue.Replace(",", " ")
                oValue = oValue.Replace(".", " ")

                oWords = oValue.Split(" ")

                For Each oWord In oWords
                    If Not (GetLikeCondition = String.Empty) Then GetLikeCondition &= " AND "
                    GetLikeCondition &= oColumnName & " LIKE '%" & oWord & "%' "
                Next

        End Select

    End Function

    Friend Enum EditMode
        Insert
        Update
        Delete
        View
    End Enum

    Friend Enum Program_Types
        Program = 0
        Special_Pricing = 1
        Quote = 2
    End Enum

    Friend Enum Quote_Step

        New_Quote = 0
        Saved_Quote
        Pending_Pricing_Approval
        Pricing_Approved
        Ready_To_Send
        Sent_To_Customer

    End Enum
    Public Function User_FullName() As String
        User_FullName = String.Empty
        Try
            Dim db As New cDBA
            Dim dt As DataTable
            Dim strSql As String

            strSql =
                    " SELECT Fullname  FROM user_permissions_info With (Nolock) WHERE User_Name = '" & Environment.UserName & "'" &
                    " Union " &
                    " select fullname  from humres With (Nolock) where USR_ID = '" & Environment.UserName & "'"


            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                User_FullName = dt.Rows(0).Item("fullname").ToString
            End If


        Catch ex As Exception
            MsgBox("Error in function User_FullName() :" & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function displayItemNo(ByVal strItemCode As String, ByVal strItemColor As String) As String
        displayItemNo = ""
        Try
            Dim db As New cDBA
            Dim strSql As String
            Dim dt As DataTable

            strSql =
                " SELECT ITEM_NO FROM imitmidx_sql  WITH (Nolock) " &
                " WHERE user_def_fld_1 = '" & strItemCode & "'  and user_def_fld_2 = '" & strItemColor & "'"
            '++ID 1.18.2018 from MDB
            strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
                            & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
                            & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '" & strItemCode & "'  and c.COLOR_NAME = '" & strItemColor & "'"

            '++justin 20200106 get color_name by COLOR_ID in sql (get item_no by color_id)''
            strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
                & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
                & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '" & strItemCode & "'  and c.COLOR_ID = '" & strItemColor & "'"
            ''

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                displayItemNo = Trim(RTrim(dt.Rows(0).Item("ITEM_NO").ToString))

            Else
                strSql =
             " SELECT ITEM_NO FROM imitmidx_sql  WITH (Nolock) " &
             " WHERE  user_def_fld_1 = '66" & strItemCode & "'  and user_def_fld_2 = '" & strItemColor & "'"

                '++ID 1.18.2018 from MDB
                strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
                & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
                & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '66" & strItemCode & "'  and c.COLOR_NAME = '" & strItemColor & "'"

                'justin 20200106
                strSql = "  select * from mdb_item_master m inner join MDB_ITEM_VARIANT v on " _
                & " m.ITEM_MASTER_ID = v.ITEM_MASTER_ID   inner join MDB_CFG_COLOR c on " _
                & " v.COLOR_ID = c.COLOR_ID   where ITEM_CD = '66" & strItemCode & "'  and c.COLOR_ID = '" & strItemColor & "'"

                dt = db.DataTable(strSql)

                If dt.Rows.Count <> 0 Then
                    displayItemNo = Trim(RTrim(dt.Rows(0).Item("ITEM_NO").ToString))
                End If

            End If

        Catch ex As Exception
            MsgBox("Error in  mGlobal.displayItemNo." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function
End Module
