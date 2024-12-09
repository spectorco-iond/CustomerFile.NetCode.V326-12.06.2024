Imports System.Data.Odbc 

Public Class cMdb_Cfg_Color_DAL

    Public Function Load(ByVal pintID As Integer) As cMdb_Cfg_Color

        Load = New cMdb_Cfg_Color()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
              "SELECT * " & _
              "FROM   Mdb_Cfg_Color WITH (Nolock) " & _
              "WHERE  Color_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function LoadByCode(ByVal pstrCd As String) As cMdb_Cfg_Color

        LoadByCode = New cMdb_Cfg_Color()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
              "SELECT TOP 1 * " & _
              "FROM   Mdb_Cfg_Color WITH (Nolock) " & _
              "WHERE  Color_Cd = '" & Trim(pstrCd) & "' "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(LoadByCode, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function LoadFullColorName(ByVal pintID As Integer) As cMdb_Cfg_Color

        LoadFullColorName = New cMdb_Cfg_Color()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
              "SELECT COLOR_ID, COLOR_CD, COLOR_CD + ' - ' + CASE WHEN COLOR_NAME IS NULL THEN '' ELSE COLOR_NAME  + ' ' END AS COLOR_NAME, " _
                & "     USER_LOGIN, CREATE_TS, UPDATE_TS, COLOR_NAME_FR " _
                & "FROM   Mdb_Cfg_Color WITH (Nolock) " & _
              "WHERE  Color_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(LoadFullColorName, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub LoadLine(ByVal pClass As cMdb_Cfg_Color, ByRef pdrRow As DataRow)

        Try

            'If Not (pdrRow.Item("Color_Id").Equals(DBNull.Value)) Then pClass.Color_Id = pdrRow.Item("Color_Id")
            'If Not (pdrRow.Item("Color_Cd").Equals(DBNull.Value)) Then pClass.Color_Cd = pdrRow.Item("Color_Cd").ToString
            'If Not (pdrRow.Item("Color_Name").Equals(DBNull.Value)) Then pClass.Color_Name = pdrRow.Item("Color_Name").ToString
            'If Not (pdrRow.Item("Color_Name_Fr").Equals(DBNull.Value)) Then pClass.Color_Name_Fr = pdrRow.Item("Color_Name_Fr").ToString
            'If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then pClass.User_Login = pdrRow.Item("User_Login").ToString
            'If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then pClass.Create_Ts = pdrRow.Item("Create_Ts")
            'If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then pClass.Update_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function GetList_All() As List(Of cMdb_Cfg_Color)

        GetList_All = New List(Of cMdb_Cfg_Color)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Cfg_Color)
            Dim i As Integer
            Dim strSql As String

            strSql = _
                  " SELECT COLOR_ID, COLOR_CD, COLOR_CD + ' - ' + CASE WHEN COLOR_NAME IS NULL THEN '' ELSE COLOR_NAME  + ' ' END AS COLOR_NAME, " _
                & "     USER_LOGIN, CREATE_TS, UPDATE_TS, COLOR_NAME_FR " _
                & " FROM   Mdb_Cfg_Color WITH (Nolock) " _
                & " ORDER BY COLOR_NAME ASC "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Cfg_Color
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_All = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function GetList_BasicColors() As List(Of cMdb_Cfg_Color)

        GetList_BasicColors = New List(Of cMdb_Cfg_Color)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Cfg_Color)
            Dim i As Integer
            Dim strSql As String

            strSql = _
                  " SELECT COLOR_ID, COLOR_CD, COLOR_CD + ' - ' + CASE WHEN COLOR_NAME IS NULL THEN '' ELSE COLOR_NAME  + ' ' END AS COLOR_NAME, " _
                & "     USER_LOGIN, CREATE_TS, UPDATE_TS, COLOR_NAME_FR " _
                & " FROM   Mdb_Cfg_Color WITH (Nolock) " _
                & " WHERE (COLOR_CD <> ''" _
                & "         AND COLOR_CD IS NOT NULL) " _
                & " ORDER BY COLOR_NAME ASC "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Cfg_Color
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_BasicColors = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function GetList_BasicColorsFull() As List(Of cMdb_Cfg_Color)

        GetList_BasicColorsFull = New List(Of cMdb_Cfg_Color)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Cfg_Color)
            Dim i As Integer
            Dim strSql As String

            strSql = _
                  " SELECT * " _
                & " FROM   Mdb_Cfg_Color WITH (Nolock) "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Cfg_Color
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            GetList_BasicColorsFull = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

  ' Insert/Update the current row into the database, or creates it if not existing
      Public Function Save(pClass As cMdb_Cfg_Color) As Boolean 

          Save = False 

          Try

              Dim db As New cDBA
              Dim dt As New DataTable
              Dim drRow As DataRow

              Dim strSql As String

              strSql = _
                  "SELECT * " & _
                  "FROM   Mdb_Cfg_Color " & _
              "WHERE  Color_Id = " & pClass.Color_Id & " "

              dt = db.DataTable(strSql)

              If dt.Rows.Count = 0 Then
                  drRow = dt.NewRow()
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
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

      End Function

      Private sub SaveLine(ByRef pClass As cMdb_Cfg_Color, ByRef pdrRow As DataRow) 
        Try

            ''pdrRow.Item("Color_Id") = pClass.Color_Id
            'pdrRow.Item("Color_Cd") = pClass.Color_Cd
            'pdrRow.Item("Color_Name") = pClass.Color_Name
            'pdrRow.Item("Color_Name_Fr") = pClass.Color_Name_Fr
            'pClass.User_Login = Environment.UserName
            'pdrRow.Item("User_Login") = pClass.User_Login
            'pClass.Update_Ts = Date.Now
            'pdrRow.Item("Update_Ts") = pClass.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    ' Deletes the current row from the database, if it exists.
    Public Function Delete( pintID As Integer ) As Boolean

          Delete = False 

          Try

              Dim db As New cDBA
              Dim dt As New DataTable

              Dim strSql As String

              strSql = _
                  "DELETE FROM Mdb_Cfg_Color " & _
              "WHERE  Color_Id = " & pintID & " "

              db.Execute(strSql)

              Delete = True 

          Catch ex as Exception
              MsgBox("Error in cMdb_Cfg_Color." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
          End Try

    End Function

    Public Function HighId() As Integer
        Dim db As New cDBA
        Dim dt As New DataTable
        Try
            Dim strSql As String

            strSql = "select max(COLOR_ID) as 'Value' from Mdb_Cfg_Color"

            dt = db.DataTable(strSql)

        Catch er As Exception
            MsgBox("Error in CComment." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try
        If IsDBNull(dt.Rows(0).Item("Value")) Then
            Return 0
        Else
            Return dt.Rows(0).Item("Value") + 1
        End If
    End Function

    Public Function ColorCodeUnique(ByVal pClass As cMdb_Cfg_Color) As Boolean

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim ver As Boolean

        Dim strSql As String
        strSql = _
          "select * from Mdb_Cfg_Color where color_cd = '" + pClass.Color_Cd + "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count = 0 Then
            ver = True
        Else
            ver = False
        End If
        Return ver
    End Function

    Public Function ColorNameUnique(ByVal pClass As cMdb_Cfg_Color) As Boolean

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim ver As Boolean

        Dim strSql As String
        strSql = _
          "select * from Mdb_Cfg_Color where color_name = '" + pClass.Color_Name + "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count = 0 Then
            ver = True
        Else
            ver = False
        End If
        Return ver
    End Function

    Public Function codesUNIQUE(ByVal pClass As cMdb_Cfg_Color) As Boolean

        Dim db As New cDBA
        Dim dt As New DataTable
        Dim ver As Boolean

        Dim strSql As String
        strSql = _
          "select * from Mdb_Cfg_Color where color_cd = '" + pClass.Color_Cd + "' and color_name = '" + pClass.Color_Name + "'"

        dt = db.DataTable(strSql)

        If dt.Rows.Count = 0 Then
            ver = True
        Else
            ver = False
        End If
        Return ver
    End Function
End Class ' cMdb_Cfg_Color


