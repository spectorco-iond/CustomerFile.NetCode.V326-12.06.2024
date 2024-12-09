Imports System.Data.Odbc

Public Class cCOMPLAINT_CALL_DETAIL_FILE_DAL


    Public Function Load(ByVal pintID As Integer) As cCOMPLAINT_CALL_DETAIL_FILE
        Load = New cCOMPLAINT_CALL_DETAIL_FILE
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              "SELECT  COMPLAINT_CALL_DETAIL_FILE_ID       ,COMPLAINT_CALL_DETAIL_ID       ,COMPLAINT_CALL_DETAIL_FILE_TYPE_ID      ,FILE_NAME,       FILE_EXT,        FILE_NOTE       ,UPLOAD_DATETIME       ,IF_VALID " &
              " FROM   COMPLAINT_CALL_DETAIL_FILE WITH (Nolock) " &
              " WHERE  COMPLAINT_CALL_DETAIL_FILE_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function

    Public Function get_cOMPLAINT_CALL_DETAIL_FILE(ByVal pintID As Integer) As cCOMPLAINT_CALL_DETAIL_FILE
        get_cOMPLAINT_CALL_DETAIL_FILE = New cCOMPLAINT_CALL_DETAIL_FILE()
        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
              "SELECT  COMPLAINT_CALL_DETAIL_FILE_ID       ,COMPLAINT_CALL_DETAIL_ID       , " _
              & " COMPLAINT_CALL_DETAIL_FILE_TYPE_ID      ,FILE_NAME,       FILE_EXT,     FILE_CONTENT,   FILE_NOTE       ,UPLOAD_DATETIME       ,IF_VALID " _
              & " FROM   COMPLAINT_CALL_DETAIL_FILE WITH (Nolock) " _
              & " WHERE  COMPLAINT_CALL_DETAIL_FILE_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                If Not (dt.Rows(0).Item("COMPLAINT_CALL_DETAIL_FILE_ID").Equals(DBNull.Value)) Then get_cOMPLAINT_CALL_DETAIL_FILE.COMPLAINT_CALL_DETAIL_FILE_ID = dt.Rows(0).Item("COMPLAINT_CALL_DETAIL_FILE_ID")
                If Not (dt.Rows(0).Item("COMPLAINT_CALL_DETAIL_ID")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.COMPLAINT_CALL_DETAIL_FILE_TYPE_ID = dt.Rows(0).Item("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID")
                If Not (dt.Rows(0).Item("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID").Equals(DBNull.Value)) Then get_cOMPLAINT_CALL_DETAIL_FILE.FILE_NAME = dt.Rows(0).Item("FILE_NAME")
                If Not (dt.Rows(0).Item("FILE_NAME")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.FILE_EXT = dt.Rows(0).Item("FILE_EXT")
                If Not (dt.Rows(0).Item("FILE_EXT")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.FILE_CONTENT = dt.Rows(0).Item("FILE_CONTENT")
                If Not (dt.Rows(0).Item("FILE_CONTENT")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.FILE_NOTE = dt.Rows(0).Item("FILE_NOTE")
                If Not (dt.Rows(0).Item("UPLOAD_DATETIME")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.UPLOAD_DATETIME = dt.Rows(0).Item("UPLOAD_DATETIME")
                If Not (dt.Rows(0).Item("IF_VALID")).Equals(DBNull.Value) Then get_cOMPLAINT_CALL_DETAIL_FILE.IF_VALID = dt.Rows(0).Item("IF_VALID")
            End if


        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    Private Sub LoadLine(pClass As cCOMPLAINT_CALL_DETAIL_FILE, ByRef pdrRow As DataRow)
        Try

            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_DETAIL_FILE_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_DETAIL_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID").Equals(DBNull.Value)) Then pClass.COMPLAINT_CALL_DETAIL_FILE_TYPE_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID")
            'If Not (pdrRow.Item("FILE_HEADER").Equals(DBNull.Value)) Then pClass.FILE_HEADER = pdrRow.Item("FILE_HEADER")
            If Not (pdrRow.Item("FILE_NAME").Equals(DBNull.Value)) Then pClass.FILE_NAME = pdrRow.Item("FILE_NAME")
            If Not (pdrRow.Item("FILE_EXT").Equals(DBNull.Value)) Then pClass.FILE_EXT = pdrRow.Item("FILE_EXT").ToString
            'If Not (pdrRow.Item("FILE_CONTENT").Equals(DBNull.Value)) Then pClass.FILE_CONTENT = pdrRow.Item("FILE_CONTENT")
            If Not (pdrRow.Item("FILE_NOTE").Equals(DBNull.Value)) Then pClass.FILE_NOTE = pdrRow.Item("FILE_NOTE").ToString
            If Not (pdrRow.Item("UPLOAD_DATETIME").Equals(DBNull.Value)) Then pClass.UPLOAD_DATETIME = pdrRow.Item("UPLOAD_DATETIME")
            If Not (pdrRow.Item("IF_VALID").Equals(DBNull.Value)) Then pClass.IF_VALID = pdrRow.Item("IF_VALID")


        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    Public Function GetList(ByVal pintCOMPLAINT_CALL_DETAIL_FILE_ID As Int32) As List(Of cCOMPLAINT_CALL_DETAIL_FILE)
        GetList = New List(Of cCOMPLAINT_CALL_DETAIL_FILE)
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cCOMPLAINT_CALL_DETAIL_FILE)
            Dim i As Integer
            Dim strSql As String

            strSql =
                    " select  " _
            & "    COMPLAINT_CALL_DETAIL_FILE_ID," _
            & "    COMPLAINT_CALL_DETAIL_ID," _
            & " COMPLAINT_CALL_DETAIL_FILE_TYPE_ID," _
            & "    FILE_NAME," _
            & "    FILE_EXT," _
            & "    FILE_NOTE," _
            & "    UPLOAD_DATETIME," _
            & "    IF_VALID" _
            & "    from COMPLAINT_CALL_DETAIL_FILE " _
            & "    where COMPLAINT_CALL_DETAIL_ID = " & pintCOMPLAINT_CALL_DETAIL_FILE_ID

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cCOMPLAINT_CALL_DETAIL_FILE
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList = myList

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    ' Insert/Update the current row into the database, or creates it if not existing
    Public Function Save(ByVal pClass As cCOMPLAINT_CALL_DETAIL_FILE) As Boolean
        Save = False
        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String



            strSql = "SELECT COMPLAINT_CALL_DETAIL_FILE_ID " _
                    & "      ,COMPLAINT_CALL_DETAIL_ID " _
                    & "      ,COMPLAINT_CALL_DETAIL_FILE_TYPE_ID " _
                    & "      ,FILE_HEADER " _
                    & "      ,FILE_NAME, " _
                    & "      FILE_EXT, " _
                    & "      FILE_NOTE " _
                    & "      ,UPLOAD_DATETIME " _
                    & "      ,IF_VALID " _
                    & "  FROM COMPLAINT_CALL_DETAIL_FILE " _
                   & " WHERE  COMPLAINT_CALL_DETAIL_FILE_ID = " & pClass.COMPLAINT_CALL_DETAIL_FILE_ID

            ' if the doc is NEW, include the FILE_CONTENT field

            If pClass.COMPLAINT_CALL_DETAIL_FILE_ID < 1 Then
                strSql = Replace(strSql, "FILE_EXT,", "FILE_EXT, FILE_CONTENT,")
            End If

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
                drRow.Item("UPLOAD_DATETIME") = Date.Now
            Else
                drRow = dt.Rows(0)
            End If
            Call SaveLine(pClass, drRow)

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
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Function


    Private Sub SaveLine(ByRef pClass As cCOMPLAINT_CALL_DETAIL_FILE, ByRef pdrRow As DataRow)
        Try

            'pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_ID") = pClass.COMPLAINT_CALL_DETAIL_FILE_ID
            pdrRow.Item("COMPLAINT_CALL_DETAIL_ID") = pClass.COMPLAINT_CALL_DETAIL_ID
            pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_TYPE_ID") = pClass.COMPLAINT_CALL_DETAIL_FILE_TYPE_ID
            pdrRow.Item("FILE_NAME") = pClass.FILE_NAME
            pdrRow.Item("FILE_EXT") = pClass.FILE_EXT
            If pdrRow.Item("COMPLAINT_CALL_DETAIL_FILE_ID") Is DBNull.Value Then
                'MsgBox(0)
                pdrRow.Item("FILE_CONTENT") = pClass.FILE_CONTENT
            Else
                'MsgBox(1)
            End If

            pdrRow.Item("FILE_NOTE") = pClass.FILE_NOTE
            pClass.UPLOAD_DATETIME = Date.Now
            pdrRow.Item("IF_VALID") = pClass.IF_VALID


        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub


    ' Deletes the current row from the database, if it exists.
    Public Function Delete(pintID As Integer) As Boolean

        Delete = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
                    "DELETE FROM COMPLAINT_CALL_DETAIL_FILE " &
                  "WHERE  COMPLAINT_CALL_DETAIL_FILE_ID = " & pintID & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL_FILE_DAL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


End Class ' cCOMPLAINT_CALL_DETAIL_FILE_DAL


