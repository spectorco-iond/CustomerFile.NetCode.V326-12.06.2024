Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

' Insert Include here


Public Class cMdb_Cus_Ship


#Region "private variables #################################################"


    Private m_intCus_Ship_Id As Int32 = 0
    Private m_strGroup_Cd As String
    Private m_strCus_No As String
    Private m_strCus_Alt_Adr_Cd As String
    Private m_strCountry_Cd As String
    Private m_intProg_Id As Int32
    Private m_strShip_Via_Cd As String
    Private m_strShip_Via_Account As String
    Private m_strPrinter_Comment As String
    Private m_strPrinter_Instructions As String
    Private m_strPacker_Comment As String
    Private m_strPacker_Instructions As String
    Private m_strShip_Comments As String
    Private m_strShip_Instructions_1 As String
    Private m_strShip_Instructions_2 As String
    Private m_blnAlways_Use As Boolean
    Private m_blnNever_Use As Boolean
    Private m_strCmt_When_Selected As String
    Private m_blnNo_Charge As Boolean
    Private m_blnSamples_Only As Boolean
    Private m_strUser_Login As String
    Private m_dtUpdate_Ts As DateTime


#End Region


#Region "Public constructors ##############################################"


    Public Sub New()

        Try

            Call Init()

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Public Sub New(ByVal pCus_Ship_Id As Int32)

        Try

            Call Init()
            Call Load(pCus_Ship_Id)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"


    Private Sub Init()

        Try

            m_intCus_Ship_Id = 0
            m_strGroup_Cd = String.Empty
            m_strCus_No = String.Empty
            m_strCus_Alt_Adr_Cd = String.Empty
            m_strCountry_Cd = String.Empty
            m_intProg_Id = 0
            m_strShip_Via_Cd = String.Empty
            m_strShip_Via_Account = String.Empty
            m_strPrinter_Comment = String.Empty
            m_strPrinter_Instructions = String.Empty
            m_strPacker_Comment = String.Empty
            m_strPacker_Instructions = String.Empty
            m_strShip_Comments = String.Empty
            m_strShip_Instructions_1 = String.Empty
            m_strShip_Instructions_2 = String.Empty
            m_blnAlways_Use = False
            m_blnNever_Use = False
            m_strCmt_When_Selected = String.Empty
            m_blnNo_Charge = False
            m_blnSamples_Only = False
            m_strUser_Login = String.Empty


        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)

        Try

            If Not (pdrRow.Item("Cus_Ship_Id").Equals(DBNull.Value)) Then m_intCus_Ship_Id = pdrRow.Item("Cus_Ship_Id")
            If Not (pdrRow.Item("Group_Cd").Equals(DBNull.Value)) Then m_strGroup_Cd = pdrRow.Item("Group_Cd").ToString
            If Not (pdrRow.Item("Cus_No").Equals(DBNull.Value)) Then m_strCus_No = pdrRow.Item("Cus_No").ToString
            If Not (pdrRow.Item("Cus_Alt_Adr_Cd").Equals(DBNull.Value)) Then m_strCus_Alt_Adr_Cd = pdrRow.Item("Cus_Alt_Adr_Cd").ToString
            If Not (pdrRow.Item("Country_Cd").Equals(DBNull.Value)) Then m_strCountry_Cd = pdrRow.Item("Country_Cd").ToString
            If Not (pdrRow.Item("Prog_Id").Equals(DBNull.Value)) Then m_intProg_Id = pdrRow.Item("Prog_Id")
            If Not (pdrRow.Item("Ship_Via_Cd").Equals(DBNull.Value)) Then m_strShip_Via_Cd = pdrRow.Item("Ship_Via_Cd").ToString
            If Not (pdrRow.Item("Ship_Via_Account").Equals(DBNull.Value)) Then m_strShip_Via_Account = pdrRow.Item("Ship_Via_Account").ToString
            If Not (pdrRow.Item("Printer_Comment").Equals(DBNull.Value)) Then m_strPrinter_Comment = pdrRow.Item("Printer_Comment").ToString
            If Not (pdrRow.Item("Printer_Instructions").Equals(DBNull.Value)) Then m_strPrinter_Instructions = pdrRow.Item("Printer_Instructions").ToString
            If Not (pdrRow.Item("Packer_Comment").Equals(DBNull.Value)) Then m_strPacker_Comment = pdrRow.Item("Packer_Comment").ToString
            If Not (pdrRow.Item("Packer_Instructions").Equals(DBNull.Value)) Then m_strPacker_Instructions = pdrRow.Item("Packer_Instructions").ToString
            If Not (pdrRow.Item("Ship_Comments").Equals(DBNull.Value)) Then m_strShip_Comments = pdrRow.Item("Ship_Comments").ToString
            If Not (pdrRow.Item("Ship_Instructions_1").Equals(DBNull.Value)) Then m_strShip_Instructions_1 = pdrRow.Item("Ship_Instructions_1").ToString
            If Not (pdrRow.Item("Ship_Instructions_2").Equals(DBNull.Value)) Then m_strShip_Instructions_2 = pdrRow.Item("Ship_Instructions_2").ToString
            If Not (pdrRow.Item("Always_Use").Equals(DBNull.Value)) Then m_blnAlways_Use = pdrRow.Item("Always_Use")
            If Not (pdrRow.Item("Never_Use").Equals(DBNull.Value)) Then m_blnNever_Use = pdrRow.Item("Never_Use")
            If Not (pdrRow.Item("Cmt_When_Selected").Equals(DBNull.Value)) Then m_strCmt_When_Selected = pdrRow.Item("Cmt_When_Selected").ToString
            If Not (pdrRow.Item("No_Charge").Equals(DBNull.Value)) Then m_blnNo_Charge = pdrRow.Item("No_Charge")
            If Not (pdrRow.Item("Samples_Only").Equals(DBNull.Value)) Then m_blnSamples_Only = pdrRow.Item("Samples_Only")
            If Not (pdrRow.Item("User_Login").Equals(DBNull.Value)) Then m_strUser_Login = pdrRow.Item("User_Login").ToString
            If Not (pdrRow.Item("Update_Ts").Equals(DBNull.Value)) Then m_dtUpdate_Ts = pdrRow.Item("Update_Ts")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub SaveLine(ByRef pdrRow As DataRow)

        Try

            'pdrRow.Item("Cus_Ship_Id") = m_intCus_Ship_Id
            pdrRow.Item("Group_Cd") = m_strGroup_Cd
            pdrRow.Item("Cus_No") = m_strCus_No
            pdrRow.Item("Cus_Alt_Adr_Cd") = m_strCus_Alt_Adr_Cd
            pdrRow.Item("Country_Cd") = m_strCountry_Cd
            pdrRow.Item("Prog_Id") = m_intProg_Id
            pdrRow.Item("Ship_Via_Cd") = m_strShip_Via_Cd
            pdrRow.Item("Ship_Via_Account") = m_strShip_Via_Account
            pdrRow.Item("Printer_Comment") = m_strPrinter_Comment
            pdrRow.Item("Printer_Instructions") = m_strPrinter_Instructions
            pdrRow.Item("Packer_Comment") = m_strPacker_Comment
            pdrRow.Item("Packer_Instructions") = m_strPacker_Instructions
            pdrRow.Item("Ship_Comments") = m_strShip_Comments
            pdrRow.Item("Ship_Instructions_1") = m_strShip_Instructions_1
            pdrRow.Item("Ship_Instructions_2") = m_strShip_Instructions_2
            pdrRow.Item("Always_Use") = m_blnAlways_Use
            pdrRow.Item("Never_Use") = m_blnNever_Use
            pdrRow.Item("Cmt_When_Selected") = m_strCmt_When_Selected
            pdrRow.Item("No_Charge") = m_blnNo_Charge
            pdrRow.Item("Samples_Only") = m_blnSamples_Only
            pdrRow.Item("User_Login") = Environment.UserName
            If m_dtUpdate_Ts.Year <> 1 Then pdrRow.Item("Update_Ts") = m_dtUpdate_Ts.Date

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current Comment from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql = _
            "DELETE FROM Mdb_Cus_Ship " & _
            "WHERE  Cus_Ship_Id = " & m_intCus_Ship_Id & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql = _
            "SELECT * " & _
            "FROM   Mdb_Cus_Ship WITH (Nolock) " & _
            "WHERE  Cus_Ship_Id = " & pintID & " "

            dt = db.DataTable(strSql)

            Call LoadLine(dt.Rows(0))

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
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
            "FROM   Mdb_Cus_Ship " & _
            "WHERE  Cus_Ship_Id = " & m_intCus_Ship_Id & " "

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

            If m_intCus_Ship_Id = 0 Then m_intCus_Ship_Id = db.DataTable("SELECT MAX(Cus_Ship_Id) AS Max_Cus_Ship_Id FROM Mdb_Cus_Ship WITH (Nolock)").Rows(0).Item("Max_Cus_Ship_Id")

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Ship." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property Cus_Ship_Id() As Int32
        Get
            Cus_Ship_Id = m_intCus_Ship_Id
        End Get
        Set(ByVal value As Int32)
            m_intCus_Ship_Id = value
        End Set
    End Property

    Public Property Group_Cd() As String
        Get
            Group_Cd = m_strGroup_Cd
        End Get
        Set(ByVal value As String)
            m_strGroup_Cd = value
        End Set
    End Property

    Public Property Cus_No() As String
        Get
            Cus_No = m_strCus_No
        End Get
        Set(ByVal value As String)
            m_strCus_No = value
        End Set
    End Property

    Public Property Cus_Alt_Adr_Cd() As String
        Get
            Cus_Alt_Adr_Cd = m_strCus_Alt_Adr_Cd
        End Get
        Set(ByVal value As String)
            m_strCus_Alt_Adr_Cd = value
        End Set
    End Property

    Public Property Country_Cd() As String
        Get
            Country_Cd = m_strCountry_Cd
        End Get
        Set(ByVal value As String)
            m_strCountry_Cd = value
        End Set
    End Property

    Public Property Prog_Id() As Int32
        Get
            Prog_Id = m_intProg_Id
        End Get
        Set(ByVal value As Int32)
            m_intProg_Id = value
        End Set
    End Property

    Public Property Ship_Via_Cd() As String
        Get
            Ship_Via_Cd = m_strShip_Via_Cd
        End Get
        Set(ByVal value As String)
            m_strShip_Via_Cd = value
        End Set
    End Property

    Public Property Ship_Via_Account() As String
        Get
            Ship_Via_Account = m_strShip_Via_Account
        End Get
        Set(ByVal value As String)
            m_strShip_Via_Account = value
        End Set
    End Property

    Public Property Printer_Comment() As String
        Get
            Printer_Comment = m_strPrinter_Comment
        End Get
        Set(ByVal value As String)
            m_strPrinter_Comment = value
        End Set
    End Property

    Public Property Printer_Instructions() As String
        Get
            Printer_Instructions = m_strPrinter_Instructions
        End Get
        Set(ByVal value As String)
            m_strPrinter_Instructions = value
        End Set
    End Property

    Public Property Packer_Comment() As String
        Get
            Packer_Comment = m_strPacker_Comment
        End Get
        Set(ByVal value As String)
            m_strPacker_Comment = value
        End Set
    End Property

    Public Property Packer_Instructions() As String
        Get
            Packer_Instructions = m_strPacker_Instructions
        End Get
        Set(ByVal value As String)
            m_strPacker_Instructions = value
        End Set
    End Property

    Public Property Ship_Comments() As String
        Get
            Ship_Comments = m_strShip_Comments
        End Get
        Set(ByVal value As String)
            m_strShip_Comments = value
        End Set
    End Property

    Public Property Ship_Instructions_1() As String
        Get
            Ship_Instructions_1 = m_strShip_Instructions_1
        End Get
        Set(ByVal value As String)
            m_strShip_Instructions_1 = value
        End Set
    End Property

    Public Property Ship_Instructions_2() As String
        Get
            Ship_Instructions_2 = m_strShip_Instructions_2
        End Get
        Set(ByVal value As String)
            m_strShip_Instructions_2 = value
        End Set
    End Property

    Public Property Always_Use() As Boolean
        Get
            Always_Use = m_blnAlways_Use
        End Get
        Set(ByVal value As Boolean)
            m_blnAlways_Use = value
        End Set
    End Property

    Public Property Never_Use() As Boolean
        Get
            Never_Use = m_blnNever_Use
        End Get
        Set(ByVal value As Boolean)
            m_blnNever_Use = value
        End Set
    End Property

    Public Property Cmt_When_Selected() As String
        Get
            Cmt_When_Selected = m_strCmt_When_Selected
        End Get
        Set(ByVal value As String)
            m_strCmt_When_Selected = value
        End Set
    End Property

    Public Property No_Charge() As Boolean
        Get
            No_Charge = m_blnNo_Charge
        End Get
        Set(ByVal value As Boolean)
            m_blnNo_Charge = value
        End Set
    End Property

    Public Property Samples_Only() As Boolean
        Get
            Samples_Only = m_blnSamples_Only
        End Get
        Set(ByVal value As Boolean)
            m_blnSamples_Only = value
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

    Public Property Update_Ts() As DateTime
        Get
            Update_Ts = m_dtUpdate_Ts
        End Get
        Set(ByVal value As DateTime)
            m_dtUpdate_Ts = value
        End Set
    End Property

#End Region


End Class ' cMdb_Cus_Ship


