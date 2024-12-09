Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cComplaintCallDetail

#Region "private variables #################################################"
    Private m_COMPLAINT_CALL_DETAIL_ID As Int32 = 0
    Private m_COMPLAINT_CALL_HEADER_ID As Int32 = 0
    Private m_COMPLAINT_CALL_PRODUCT_ID As Int32 = 86
    Private m_COMPLAINT_CALL_DETAIL_TYPE_ID As Int32 = 1
    Private m_PURCHASE_QUANTITY As Int32 = 0
    Private m_DESCRIPTION_PRODUCT As String = String.Empty
    Private m_LOGO_ON_PRODUCT As String = String.Empty
    Private m_PURCHASED_FROM As String = String.Empty
    Private m_ITEM_NO As String = ""
    Private m_EXPIRY_DATE As Date = System.DateTime.Now.ToString()
    Private m_COMPLAINT_DETAIL As String = String.Empty
    Private m_NOTE As String = String.Empty
    Private m_LOT_NO As String = String.Empty
    Private m_PO_NO As String = String.Empty
    Private m_ORD_NO As Int32 = 0
#End Region

#Region "Public constructors ##############################################"

    Public Sub New()
        Try
            Call Init()
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pCOMPLAINT_CALL_DETAIL_ID As Int32)

        Try
            Call Init()
            Call Load(pCOMPLAINT_CALL_DETAIL_ID)

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"

    Private Sub Init()

        Try
            m_COMPLAINT_CALL_DETAIL_ID = 0
        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_DETAIL_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_HEADER_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_HEADER_ID = pdrRow.Item("COMPLAINT_CALL_HEADER_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_PRODUCT_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_PRODUCT_ID = pdrRow.Item("COMPLAINT_CALL_PRODUCT_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_DETAIL_TYPE_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID")
            If Not (pdrRow.Item("PURCHASE_QUANTITY").Equals(DBNull.Value)) Then m_PURCHASE_QUANTITY = pdrRow.Item("PURCHASE_QUANTITY")
            If Not (pdrRow.Item("DESCRIPTION_PRODUCT").Equals(DBNull.Value)) Then m_DESCRIPTION_PRODUCT = pdrRow.Item("DESCRIPTION_PRODUCT")
            If Not (pdrRow.Item("LOGO_ON_PRODUCT").Equals(DBNull.Value)) Then m_LOGO_ON_PRODUCT = pdrRow.Item("LOGO_ON_PRODUCT")
            If Not (pdrRow.Item("PURCHASED_FROM").Equals(DBNull.Value)) Then m_PURCHASED_FROM = pdrRow.Item("PURCHASED_FROM")
            If Not (pdrRow.Item("ITEM_NO").Equals(DBNull.Value)) Then m_ITEM_NO = pdrRow.Item("ITEM_NO")
            If Not (pdrRow.Item("EXPIRY_DATE").Equals(DBNull.Value)) Then m_EXPIRY_DATE = pdrRow.Item("EXPIRY_DATE")
            If Not (pdrRow.Item("COMPLAINT_DETAIL").Equals(DBNull.Value)) Then m_COMPLAINT_DETAIL = pdrRow.Item("COMPLAINT_DETAIL")
            If Not (pdrRow.Item("NOTE").Equals(DBNull.Value)) Then m_NOTE = pdrRow.Item("NOTE")
            If Not (pdrRow.Item("LOT_NO").Equals(DBNull.Value)) Then m_LOT_NO = pdrRow.Item("LOT_NO")
            If Not (pdrRow.Item("PO_NO").Equals(DBNull.Value)) Then m_PO_NO = pdrRow.Item("PO_NO")
            If Not (pdrRow.Item("ORD_NO").Equals(DBNull.Value)) Then m_ORD_NO = pdrRow.Item("ORD_NO")
        Catch ex As Exception
            MsgBox("Error in ccCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveLine(ByRef pdrRow As DataRow) 'save m from input 1row
        Try
            pdrRow.Item("COMPLAINT_CALL_DETAIL_ID") = m_COMPLAINT_CALL_DETAIL_ID
            pdrRow.Item("COMPLAINT_CALL_HEADER_ID") = m_COMPLAINT_CALL_HEADER_ID
            pdrRow.Item("COMPLAINT_CALL_PRODUCT_ID") = m_COMPLAINT_CALL_PRODUCT_ID
            pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID") = m_COMPLAINT_CALL_DETAIL_TYPE_ID
            pdrRow.Item("PURCHASE_QUANTITY") = m_PURCHASE_QUANTITY
            pdrRow.Item("DESCRIPTION_PRODUCT") = m_DESCRIPTION_PRODUCT
            pdrRow.Item("LOGO_ON_PRODUCT") = m_LOGO_ON_PRODUCT
            pdrRow.Item("PURCHASED_FROM") = m_PURCHASED_FROM
            pdrRow.Item("ITEM_NO") = m_ITEM_NO
            pdrRow.Item("EXPIRY_DATE") = m_EXPIRY_DATE
            pdrRow.Item("COMPLAINT_DETAIL") = m_COMPLAINT_DETAIL
            pdrRow.Item("NOTE") = m_NOTE
            pdrRow.Item("LOT_NO") = m_LOT_NO
            pdrRow.Item("PO_NO") = m_PO_NO
            pdrRow.Item("ORD_NO") = m_ORD_NO

        Catch ex As Exception
            MsgBox("Error in ccCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current row from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
            "DELETE FROM COMPLAINT_CALL_DETAIL " &
            "WHERE  COMPLAINT_CALL_DETAIL_ID = " & m_COMPLAINT_CALL_DETAIL_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in ccCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_DETAIL WITH (Nolock) " &
            "WHERE  COMPLAINT_CALL_DETAIL_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current cCOMPLAINT_CALL_DETAIL into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_DETAIL " &
            "WHERE  COMPLAINT_CALL_DETAIL_ID = " & m_COMPLAINT_CALL_DETAIL_ID & " "

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


            If m_COMPLAINT_CALL_DETAIL_ID = 0 Then m_COMPLAINT_CALL_DETAIL_ID = db.DataTable("SELECT MAX(COMPLAINT_CALL_DETAIL_ID) AS Max_COMPLAINT_CALL_DETAIL_ID FROM COMPLAINT_CALL_DETAIL WITH (Nolock)").Rows(0).Item("Max_COMPLAINT_CALL_DETAIL_ID")

        Catch ex As Exception
            MsgBox("Error in cCOMPLAINT_CALL_DETAIL." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_DETAIL_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_ID = m_COMPLAINT_CALL_DETAIL_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_HEADER_ID() As Int32
        Get
            COMPLAINT_CALL_HEADER_ID = m_COMPLAINT_CALL_HEADER_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_HEADER_ID = value
        End Set
    End Property
    Public Property COMPLAINT_CALL_PRODUCT_ID() As Int32
        Get
            COMPLAINT_CALL_PRODUCT_ID = m_COMPLAINT_CALL_PRODUCT_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_PRODUCT_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_DETAIL_TYPE_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_TYPE_ID = m_COMPLAINT_CALL_DETAIL_TYPE_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_TYPE_ID = value
        End Set
    End Property
    Public Property PURCHASE_QUANTITY() As Int32
        Get
            PURCHASE_QUANTITY = m_PURCHASE_QUANTITY
        End Get
        Set(ByVal value As Int32)
            m_PURCHASE_QUANTITY = value
        End Set
    End Property
    Public Property DESCRIPTION_PRODUCT() As String
        Get
            DESCRIPTION_PRODUCT = m_DESCRIPTION_PRODUCT
        End Get
        Set(ByVal value As String)
            m_DESCRIPTION_PRODUCT = value
        End Set
    End Property

    Public Property LOGO_ON_PRODUCT() As String
        Get
            LOGO_ON_PRODUCT = m_LOGO_ON_PRODUCT
        End Get
        Set(ByVal value As String)
            m_LOGO_ON_PRODUCT = value
        End Set
    End Property
    Public Property PURCHASED_FROM() As String
        Get
            PURCHASED_FROM = m_PURCHASED_FROM
        End Get
        Set(ByVal value As String)
            m_PURCHASED_FROM = value
        End Set
    End Property
    Public Property ITEM_NO() As String
        Get
            ITEM_NO = m_ITEM_NO
        End Get
        Set(ByVal value As String)
            m_ITEM_NO = value
        End Set
    End Property
    Public Property EXPIRY_DATE() As DateTime
        Get
            EXPIRY_DATE = m_EXPIRY_DATE
        End Get
        Set(ByVal value As DateTime)
            m_EXPIRY_DATE = value
        End Set
    End Property
    Public Property COMPLAINT_DETAIL() As String
        Get
            COMPLAINT_DETAIL = m_COMPLAINT_DETAIL
        End Get
        Set(ByVal value As String)
            m_COMPLAINT_DETAIL = value
        End Set
    End Property
    Public Property NOTE() As String
        Get
            NOTE = m_NOTE
        End Get
        Set(ByVal value As String)
            m_NOTE = value
        End Set
    End Property

    Public Property LOT_NO() As String
        Get
            LOT_NO = m_LOT_NO
        End Get
        Set(ByVal value As String)
            m_LOT_NO = value
        End Set
    End Property

    Public Property PO_NO() As String
        Get
            PO_NO = m_PO_NO
        End Get
        Set(ByVal value As String)
            m_PO_NO = value
        End Set
    End Property
    Public Property ORD_NO() As String
        Get
            ORD_NO = m_ORD_NO
        End Get
        Set(ByVal value As String)
            m_ORD_NO = value
            '(case ) 
        End Set
    End Property
#End Region


End Class ' cCOMPLAINT_CALL_DETAIL