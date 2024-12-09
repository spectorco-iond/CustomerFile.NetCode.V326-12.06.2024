Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMDB_CFG_DISRUPTION


#Region "private variables #################################################"


    Private m_intDisruption_ID As Int32
    Private m_strDisruption_Group As String
    Private m_strDisruption_Desc As String
    Private m_intSort_Order As Int32
    Private m_blnShow_CSR As Boolean
    Private m_blnShow_DML As Boolean
    Private m_blnShow_ProofReading As Boolean
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime
    Private m_dtCreate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal pDisruption_ID As Int32)

        Try

            Call Init()
            Call Load(pDisruption_ID)

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intDisruption_ID = 0
            m_strDisruption_Group = String.Empty
            m_strDisruption_Desc = String.Empty
            m_intSort_Order = 0
            m_blnShow_CSR = False
            m_blnShow_DML = False
            m_blnShow_ProofReading = False
            m_strUser_Login = String.Empty
            m_dtCreate_Ts = NoDate()
            m_dtUpdate_Ts = NoDate()

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Disruption_ID").Equals(DBNull.Value)) Then m_intDisruption_ID = pdrRow.Item("Disruption_ID")
            If Not (pdrRow.Item("Disruption_Group").Equals(DBNull.Value)) Then m_strDisruption_Group = pdrRow.Item("Disruption_Group").ToString
            If Not (pdrRow.Item("Disruption_Desc").Equals(DBNull.Value)) Then m_strDisruption_Desc = pdrRow.Item("Disruption_Desc").ToString
            If Not (pdrRow.Item("Sort_Order").Equals(DBNull.Value)) Then m_intSort_Order = pdrRow.Item("Sort_Order")
            If Not (pdrRow.Item("Show_CSR").Equals(DBNull.Value)) Then m_blnShow_CSR = pdrRow.Item("Show_CSR")
            If Not (pdrRow.Item("Show_DML").Equals(DBNull.Value)) Then m_blnShow_DML = pdrRow.Item("Show_DML")
            If Not (pdrRow.Item("Show_ProofReading").Equals(DBNull.Value)) Then m_blnShow_ProofReading = pdrRow.Item("Show_ProofReading")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Create_Ts").Equals(DBNull.Value)) Then m_dtCreate_Ts = pdrRow.Item("Create_Ts")
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            pdrRow.Item("Disruption_Group") = m_strDisruption_Group
            pdrRow.Item("Disruption_Desc") = m_strDisruption_Desc
            pdrRow.Item("Sort_Order") = m_intSort_Order
            pdrRow.Item("Show_CSR") = m_blnShow_CSR
            pdrRow.Item("Show_DML") = m_blnShow_DML
            pdrRow.Item("Show_ProofReading") = m_blnShow_ProofReading

            If m_intDisruption_ID = 0 Then
                m_dtCreate_Ts = Date.Now
                pdrRow.Item("Create_Ts") = m_dtCreate_Ts
            End If

            m_strUser_Login = Environment.UserName
            m_dtUpdate_Ts = Date.Now

            pdrRow.Item("User_Login") = m_strUser_Login
            pdrRow.Item("Update_Ts") = m_dtUpdate_Ts

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"

    Public Function Clone(ByRef oFrom As cMDB_CFG_DISRUPTION) As cMDB_CFG_DISRUPTION

        Clone = New cMDB_CFG_DISRUPTION()

        Try
            With Clone

                .Disruption_ID = oFrom.Disruption_ID
                .Disruption_Group = oFrom.Disruption_Group
                .Disruption_Desc = oFrom.Disruption_Desc
                .Sort_Order = oFrom.Sort_Order
                .Show_CSR = oFrom.Show_CSR
                .Show_DML = oFrom.Show_DML
                .Show_ProofReading = oFrom.Show_ProofReading
                .User_Login = oFrom.User_Login
                .Create_Ts = oFrom.Create_Ts
                .Update_Ts = oFrom.Update_Ts

            End With

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM MDB_CFG_DISRUPTION " & _
            "WHERE  Disruption_ID = " & m_intDisruption_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   MDB_CFG_DISRUPTION WITH (Nolock) " & _
            "WHERE  Disruption_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current Comment into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql = _
            "SELECT * " & _
            "FROM   MDB_CFG_DISRUPTION " & _
            "WHERE  Disruption_ID = " & m_intDisruption_ID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count = 0 Then
                drRow = dt.NewRow()
            Else
                drRow = dt.Rows(0)
            End If

            Call SaveLine(drRow)

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
            MsgBox("Error in cMDB_CFG_DISRUPTION." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Disruption_ID() As Int32
        Get
            Disruption_ID = m_intDisruption_ID
        End Get
        Set(ByVal value As Int32)
            m_intDisruption_ID = value
        End Set
    End Property

    Public Property Disruption_Group() As String
        Get
            Disruption_Group = m_strDisruption_Group
        End Get
        Set(ByVal value As String)
            m_strDisruption_Group = value
        End Set
    End Property

    Public Property Disruption_Desc() As String
        Get
            Disruption_Desc = m_strDisruption_Desc
        End Get
        Set(ByVal value As String)
            m_strDisruption_Desc = value
        End Set
    End Property

    Public Property Sort_Order() As Int32
        Get
            Sort_Order = m_intSort_Order
        End Get
        Set(ByVal value As Int32)
            m_intSort_Order = value
        End Set
    End Property

    Public Property Show_CSR() As Boolean
        Get
            Show_CSR = m_blnShow_CSR
        End Get
        Set(ByVal value As Boolean)
            m_blnShow_CSR = value
        End Set
    End Property

    Public Property Show_DML() As Boolean
        Get
            Show_DML = m_blnShow_DML
        End Get
        Set(ByVal value As Boolean)
            m_blnShow_DML = value
        End Set
    End Property

    Public Property Show_ProofReading() As Boolean
        Get
            Show_ProofReading = m_blnShow_ProofReading
        End Get
        Set(ByVal value As Boolean)
            m_blnShow_ProofReading = value
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

End Class
