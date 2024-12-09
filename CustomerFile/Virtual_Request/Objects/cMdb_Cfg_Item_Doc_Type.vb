Imports System.Data.Odbc

Public Class cMdb_Cfg_Item_Doc_Type
#Region "private variables #################################################"


    Private m_intItem_Doc_Type_Id As Int32
    Private m_strDoc_Type As String
    Private m_blnActive As Boolean
    Private m_strUser_Login As String
    Private m_dtCreate_Ts As DateTime
    Private m_dtUpdate_Ts As DateTime

#End Region


    Public Function Load(ByVal pintID As Integer) As cMdb_Cfg_Item_Doc_Type

        Load = New cMdb_Cfg_Item_Doc_Type()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   Mdb_Cfg_Item_Doc_Type WITH (Nolock) " &
            "WHERE  Item_Doc_Type_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(Load, dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Item_Doc_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Private Sub LoadLine(pClass As cMdb_Cfg_Item_Doc_Type, ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Item_Doc_Type_Id").Equals(DBNull.Value)) Then pClass.Item_Doc_Type_Id = pdrRow.Item("Item_Doc_Type_Id")
            If Not (pdrRow.Item("Doc_Type").Equals(DBNull.Value)) Then pClass.Doc_Type = pdrRow.Item("Doc_Type").ToString
            If Not (pdrRow.Item("Active").Equals(DBNull.Value)) Then pClass.Active = pdrRow.Item("Active")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then pClass.User_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then pClass.Create_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then pClass.Update_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Item_Doc_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Load(ByVal p_strQuery As String) As List(Of cMdb_Cfg_Item_Doc_Type)

        Load = New List(Of cMdb_Cfg_Item_Doc_Type)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim myList = New List(Of cMdb_Cfg_Item_Doc_Type)
            Dim i As Integer
            Dim strSql As String


            strSql =
              "SELECT * " &
              "FROM   Mdb_Cfg_Item_Doc_Type WITH (Nolock) " & p_strQuery

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim oEnum = New cMdb_Cfg_Item_Doc_Type
                    Call LoadLine(oEnum, dt.Rows(i))
                    myList.Add(oEnum)
                Next
            End If

            Load = myList

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Enum." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    ' Insert/Update the current row into the database, or creates it if not existing
    Public Function Save(pClass As cMdb_Cfg_Item_Doc_Type) As Boolean

        Save = False

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
                  "SELECT * " &
                  "FROM   Mdb_Cfg_Item_Doc_Type " &
              "WHERE  Item_Doc_Type_Id = " & pClass.Item_Doc_Type_Id & " "

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
            MsgBox("Error in cMdb_Cfg_Item_Doc_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    Private Sub SaveLine(ByRef pClass As cMdb_Cfg_Item_Doc_Type, ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Item_Doc_Type_Id") = pClass.Item_Doc_Type_Id
            pdrRow.Item("Doc_Type") = pClass.Doc_Type
            pdrRow.Item("Active") = pClass.Active
            pClass.User_Login = Environment.UserName
            pdrRow.Item("User_Login") = pClass.User_Login
            pClass.Update_Ts = Date.Now
            pdrRow.Item("Update_Ts") = pClass.Update_Ts

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Item_Doc_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
                  "DELETE FROM Mdb_Cfg_Item_Doc_Type " &
              "WHERE  Item_Doc_Type_Id = " & pintID & " "

            db.Execute(strSql)

            Delete = True

        Catch ex As Exception
            MsgBox("Error in cMdb_Cfg_Item_Doc_Type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

#Region "Public properties ################################################"

    Public Property Item_Doc_Type_Id() As Int32
        Get
            Item_Doc_Type_Id = m_intItem_Doc_Type_Id
        End Get
        Set(ByVal value As Int32)
            m_intItem_Doc_Type_Id = value
        End Set
    End Property

    Public Property Doc_Type() As String
        Get
            Doc_Type = m_strDoc_Type
        End Get
        Set(ByVal value As String)
            m_strDoc_Type = value
        End Set
    End Property

    Public Property Active() As Boolean
        Get
            Active = m_blnActive
        End Get
        Set(ByVal value As Boolean)
            m_blnActive = value
        End Set
    End Property

    Public Property User_Login() As String
        Get
            User_Login = m_strUser_Login
        End Get
        Set(ByVal value As String)
            m_strUser_Login = value
        End Set
    End Property

    Public Property Create_Ts() As DateTime
        Get
            Create_Ts = m_dtCreate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtCreate_Ts = value
        End Set
    End Property

    Public Property Update_Ts() As DateTime
        Get
            Update_Ts = m_dtUpdate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_Ts = value
        End Set
    End Property

#End Region

End Class ' cMdb_Cfg_Item_Doc_Type


