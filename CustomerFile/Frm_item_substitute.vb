Imports System.Data.Odbc

Public Class Frm_item_substitute
    Private p_master_item_cd As String = ""
    Private p_master_item_id As Integer = 0

    Public Sub New(ByVal pstr_master_item_cd As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_master_item_cd = pstr_master_item_cd

        Call Get_main_master_id() 'get p_master_item_id by cd

    End Sub
    Private Sub Frm_item_substitute_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Item_substitute_list of " & CStr(p_master_item_cd)
        If p_master_item_id = 0 Then
            Bt_Add_SITEM.Enabled = False
            Bt_Del_SITEM.Enabled = False
        End If
        Call Dgv_item_substitute_c_cols()
        Call Dgv_item_substitute_Fill()
        If Dgv_item_substitute.Rows.Count > 0 Then
            Dgv_item_substitute.Rows(0).Selected = True
        End If
        Call Dgv_item_list_c_cols()
        'If Dgv_item_list.Rows.Count > 0 Then
        '    Dgv_item_list.Rows(0).Selected = True
        'End If

    End Sub

    Private Sub Dgv_frash()

        Dgv_item_substitute.DataSource = Nothing
        Dgv_item_substitute.Refresh()

        Call Dgv_item_substitute_c_cols()

        Dgv_item_list.DataSource = Nothing
        Dgv_item_list.Refresh()

        Call Dgv_item_list_c_cols()

        Call Dgv_item_substitute_Fill()
        If Dgv_item_substitute.Rows.Count > 0 Then
            Dgv_item_substitute.Rows(0).Selected = True
        End If

        Dim row_id As Int32
        row_id = 0
        Try
            Call Dgv_item_list_filter(LTrim(RTrim(TBox_filter_by_cd.Text)))
            'If Dgv_item_list.Rows.Count > 0 Then
            '    Dgv_item_list.Rows(0).Selected = True
            'End If
            ''
            ''delete row if master_id in dgv_item_substitute
            If LTrim(RTrim(TBox_filter_by_cd.Text)).Length > 2 Then
                For Each oRow As DataGridViewRow In Dgv_item_list.Rows
                    For Each oRow_st As DataGridViewRow In Dgv_item_substitute.Rows
                        If oRow.Cells("item_master_id").Value.ToString = oRow_st.Cells("SUBST_ITEM_MASTER_ID").Value.ToString Then
                            Dim cm1 As CurrencyManager = CType(BindingContext(Dgv_item_list.DataSource), CurrencyManager)
                            cm1.SuspendBinding()
                            Dgv_item_list.Rows(row_id).Visible = False
                        End If
                    Next
                    row_id = row_id + 1
                Next
            Else
                Dgv_item_list.DataSource = Nothing
            End If
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub
    Private Sub Dgv_item_substitute_c_cols()
        Try
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("item_master_id", "item_master_id", 100))
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("SUBST_ITEM_MASTER_ID", "SUBST_ITEM_MASTER_ID", 100))
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("ITEM_CD", "ITEM_CD", 90)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("ITEM_ID", "ITEM_ID", 100)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("IS_CURRENT", "IS_CURRENT", 100)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("IS_KIT", "IS_KIT", 100)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("PENDING_ITEM_CD", "PENDING_ITEM_CD", 100)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("STATUS", "STATUS", 100)) 'substitue's info
            Dgv_item_substitute.Columns.Add(DGVTextBoxColumn("ITEM_CLASSIFICATION_ID", "ITEM_CLASSIFICATION_ID", 100)) 'substitue's info

            Dgv_item_substitute.Columns("item_master_id").Visible = False
            Dgv_item_substitute.Columns("SUBST_ITEM_MASTER_ID").Visible = False
            Dgv_item_substitute.Columns("ITEM_ID").Visible = False
            Dgv_item_substitute.Columns("IS_CURRENT").Visible = False
            Dgv_item_substitute.Columns("IS_KIT").Visible = False
            Dgv_item_substitute.Columns("PENDING_ITEM_CD").Visible = False
            Dgv_item_substitute.Columns("STATUS").Visible = False
            Dgv_item_substitute.Columns("ITEM_CLASSIFICATION_ID").Visible = False


            Dgv_item_substitute.Columns("ITEM_CD").ReadOnly = True
            Dgv_item_substitute.Columns("ITEM_CD").Visible = True
            Dgv_item_substitute.AllowUserToAddRows = False
            Dgv_item_substitute.AllowUserToDeleteRows = False

            Dgv_item_substitute.RowHeadersVisible = False

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Dgv_item_list_c_cols()
        Try
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("item_master_id", "item_master_id", 100))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("ITEM_CD", "ITEM_CD", 80))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("ITEM_ID", "ITEM_ID", 100))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("IS_CURRENT", "IS_CURRENT", 20))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("IS_KIT", "IS_KIT", 20))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("PENDING_ITEM_CD", "PENDING_ITEM_CD", 50))
            Dgv_item_list.Columns.Add(DGVTextBoxColumn("STATUS", "STATUS", 55))

            Dgv_item_list.Columns("item_master_id").Visible = False
            Dgv_item_list.Columns("ITEM_CD").Visible = True
            Dgv_item_list.Columns("ITEM_ID").Visible = False
            Dgv_item_list.Columns("IS_CURRENT").Visible = False
            Dgv_item_list.Columns("IS_KIT").Visible = False
            Dgv_item_list.Columns("PENDING_ITEM_CD").Visible = False
            Dgv_item_list.Columns("STATUS").Visible = True

            Dgv_item_list.Columns("item_master_id").ReadOnly = True
            Dgv_item_list.Columns("ITEM_CD").ReadOnly = True
            Dgv_item_list.Columns("ITEM_ID").ReadOnly = True
            Dgv_item_list.Columns("IS_CURRENT").ReadOnly = True
            Dgv_item_list.Columns("IS_KIT").ReadOnly = True
            Dgv_item_list.Columns("PENDING_ITEM_CD").ReadOnly = True
            Dgv_item_list.Columns("STATUS").ReadOnly = True

            Dgv_item_list.AllowUserToAddRows = False
            Dgv_item_list.AllowUserToDeleteRows = False

            Dgv_item_list.RowHeadersVisible = False
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Dgv_item_substitute_Fill()
        Try

            Dim db As New cDBA

            Dim strLoadString As String =
            " select t1.item_master_id , t1.SUBST_ITEM_MASTER_ID,  " &
            " t3.ITEM_CD,t3.ITEM_ID,t3.IS_CURRENT,t3.IS_KIT,t3.PENDING_ITEM_CD , t3.STATUS , t3.ITEM_CLASSIFICATION_ID " &
            " from MDB_SUBSTITUTE_ITEM_MASTER t1 , mdb_item_master t2 , mdb_item_master t3 " &
            " where t1.ITEM_MASTER_ID = t2.ITEM_MASTER_ID " &
            " and t2.ITEM_CD = '" & p_master_item_cd & "'" &
            " and t1.SUBST_ITEM_MASTER_ID = t3.ITEM_MASTER_ID "

            Dgv_item_substitute.DataSource = db.DataTable(strLoadString)

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Get_main_master_id()
        Try
            Dim db As New cDBA
            Dim dt As DataTable

            Dim strLoadString As String =
            " select top 1 t1.item_master_id " &
            " from mdb_item_master t1  " &
            " where t1.ITEM_CD = '" & p_master_item_cd & "'"

            dt = db.DataTable(strLoadString)
            If dt.Rows.Count > 0 Then
                p_master_item_id = dt.Rows(0).Item(0)
            End If

        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Dgv_item_list_filter(ByVal pstr_master_item_cd As String)
        Try

            Dim db As New cDBA

            Dim strLoadString As String =
            " select t1.item_master_id ,   " &
            " t1.ITEM_CD,t1.ITEM_ID,t1.IS_CURRENT,t1.IS_KIT, t1.PENDING_ITEM_CD , t1.STATUS  " &
            " from mdb_item_master t1 " &
            " where t1.ITEM_CD like '%" & pstr_master_item_cd & "%'"

            Dgv_item_list.DataSource = db.DataTable(strLoadString)
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub TBox_filter_by_cd_TextChanged(sender As Object, e As EventArgs) Handles TBox_filter_by_cd.TextChanged
        Dim row_id As Int32
        row_id = 0
        Try
            If LTrim(RTrim(TBox_filter_by_cd.Text)).Length > 2 Then
                Dgv_item_list.DataSource = Nothing
                Dgv_item_list.Refresh()

                Call Dgv_item_list_c_cols()

                Call Dgv_item_list_filter(LTrim(RTrim(TBox_filter_by_cd.Text)))
                ''delete row if master_id in dgv_item_substitute
                For Each oRow As DataGridViewRow In Dgv_item_list.Rows
                    For Each oRow_st As DataGridViewRow In Dgv_item_substitute.Rows
                        If oRow.Cells("item_master_id").Value.ToString = oRow_st.Cells("SUBST_ITEM_MASTER_ID").Value.ToString Then

                            Dim cm1 As CurrencyManager = CType(BindingContext(Dgv_item_list.DataSource), CurrencyManager)
                            cm1.SuspendBinding()
                            Dgv_item_list.Rows(row_id).Visible = False

                        End If
                    Next
                    row_id = row_id + 1
                Next

                ''
            Else
                Dgv_item_list.DataSource = Nothing
            End If
        Catch er As Exception
            MsgBox("Error in " & Me.Name & "." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
    End Sub

    Private Sub Bt_Add_SITEM_Click(sender As Object, e As EventArgs) Handles Bt_Add_SITEM.Click
        ''get selected a row in dgv_item_list
        For Each oRow As DataGridViewRow In Dgv_item_list.Rows
            If oRow.Selected Then
                Call Add_subst_item(p_master_item_id, oRow.Cells("item_master_id").Value)
            End If
        Next

        ''insert into SUBSTITUTE_ITEM_MASTER with master_id
    End Sub

    Private Sub Bt_Del_SITEM_Click(sender As Object, e As EventArgs) Handles Bt_Del_SITEM.Click
        ''get selected a row in dgv_substitute_item_list
        For Each oRow As DataGridViewRow In Dgv_item_substitute.Rows
            If oRow.Selected Then
                Call Del_subst_item(oRow.Cells("item_master_id").Value, oRow.Cells("SUBST_ITEM_MASTER_ID").Value)
            End If
        Next
        ''delete into SUBSTITUTE_ITEM_MASTER with master_id and SUBST_ITEM_MASTER_ID
    End Sub


    Private Sub Dgv_item_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_item_list.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        Dgv_item_list.Rows(e.RowIndex).Selected = True
    End Sub
    Private Sub Dgv_item_substitute_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_item_substitute.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        Dgv_item_substitute.Rows(e.RowIndex).Selected = True
    End Sub

    Public Sub Add_subst_item(ByVal ipstr_item_master_id As String, ByVal ipstr_subst_item_master_id As String)
        Try
            Dim db As New cDBA
            Dim _sql As String
            Dim dt As DataTable
            _sql = "select * from MDB_SUBSTITUTE_ITEM_MASTER where item_master_id = " & ipstr_item_master_id & " and subst_item_master_id = " & ipstr_subst_item_master_id
            dt = db.DataTable(_sql)
            If dt.Rows.Count = 0 Then
                'insert
                _sql = " insert into MDB_SUBSTITUTE_ITEM_MASTER values( " & ipstr_item_master_id & "," & ipstr_subst_item_master_id & ")"
                db.Execute(_sql)
            Else
                MsgBox("SUBSTITUTE_ITEM: alread exists!!")
            End If

            Call Dgv_frash()

        Catch ex As Exception
            MsgBox("Error in SUBSTITUTE_ITEM." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ''
    Public Sub Del_subst_item(ByVal ipstr_item_master_id As String, ByVal ipstr_subst_item_master_id As String)
        Try
            Dim db As New cDBA
            Dim _sql As String
            Dim dt As DataTable
            _sql = "select * from MDB_SUBSTITUTE_ITEM_MASTER where item_master_id = " & ipstr_item_master_id & " and subst_item_master_id = " & ipstr_subst_item_master_id
            dt = db.DataTable(_sql)
            If dt.Rows.Count = 0 Then
                MsgBox("SUBSTITUTE_ITEM: not exists!!")
            Else
                'delete
                _sql = " delete MDB_SUBSTITUTE_ITEM_MASTER where ITEM_MASTER_ID = " & ipstr_item_master_id & " and SUBST_ITEM_MASTER_ID =  " & ipstr_subst_item_master_id
                db.Execute(_sql)
            End If
            ''
            Call Dgv_frash()

        Catch ex As Exception
            MsgBox("Error in SUBSTITUTE_ITEM." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub





    ''


    ''

End Class