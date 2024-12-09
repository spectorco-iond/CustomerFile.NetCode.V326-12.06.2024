﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics

Public Class cComplaintCallDetailType

#Region "private variables #################################################"
    Private m_COMPLAINT_CALL_DETAIL_TYPE_ID As Int32 = 0
    Private m_COMPLAINT_CALL_DETAIL_TYPE_NAME As String
#End Region

#Region "Public constructors ##############################################"

    Public Sub New()
        Try
            Call Init()
        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal pcomplaint_call_detail_type_id As Int32)

        Try
            Call Init()
            Call Load(pcomplaint_call_detail_type_id)

        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Private maintenance procedures ###################################"

    Private Sub Init()

        Try
            m_COMPLAINT_CALL_DETAIL_TYPE_ID = 0
            m_COMPLAINT_CALL_DETAIL_TYPE_NAME = String.Empty
        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub LoadLine(ByRef pdrRow As DataRow)
        Try
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_DETAIL_TYPE_ID = pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID")
            If Not (pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_NAME").Equals(DBNull.Value)) Then m_COMPLAINT_CALL_DETAIL_TYPE_NAME = pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_NAME").ToString
        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SaveLine(ByRef pdrRow As DataRow)
        Try
            pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_ID") = m_COMPLAINT_CALL_DETAIL_TYPE_ID
            pdrRow.Item("COMPLAINT_CALL_DETAIL_TYPE_NAME") = m_COMPLAINT_CALL_DETAIL_TYPE_NAME

        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public maintenance procedures ####################################"


    ' Deletes the current COMPLAINT_CALL_TYPE_ID from the database, if it exists.
    Public Sub Delete()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String

            strSql =
            "DELETE FROM COMPLAINT_CALL_DETAIL_TYPE " &
            "WHERE  COMPLAINT_CALL_DETAIL_TYPE_ID = " & m_COMPLAINT_CALL_DETAIL_TYPE_ID & " "

            db.Execute(strSql)

        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub Load(ByVal pintID As Integer)

        Try

            Dim db As New cDBA
            Dim dt As New DataTable

            Dim strSql As String
            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_DETAIL_TYPE WITH (Nolock) " &
            "WHERE  COMPLAINT_CALL_DETAIL_TYPE_ID = " & pintID & " "

            dt = db.DataTable(strSql)

            If dt.Rows.Count <> 0 Then
                Call LoadLine(dt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


    ' Update the current ccomplaint_call_detail_type into the database, or creates it if not existing
    Public Sub Save()

        Try

            Dim db As New cDBA
            Dim dt As New DataTable
            Dim drRow As DataRow

            Dim strSql As String

            strSql =
            "SELECT * " &
            "FROM   COMPLAINT_CALL_DETAIL_TYPE " &
            "WHERE  COMPLAINT_CALL_DETAIL_TYPE_ID = " & m_COMPLAINT_CALL_DETAIL_TYPE_ID & " "

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

            If m_COMPLAINT_CALL_DETAIL_TYPE_ID = 0 Then m_COMPLAINT_CALL_DETAIL_TYPE_ID = db.DataTable("SELECT MAX(COMPLAINT_CALL_DETAIL_TYPE_ID) AS Max_COMPLAINT_CALL_DETAIL_TYPE_ID FROM COMPLAINT_CALL_DETAIL_TYPE WITH (Nolock)").Rows(0).Item("Max_COMPLAINT_CALL_DETAIL_TYPE_ID")

        Catch ex As Exception
            MsgBox("Error in ccomplaint_call_detail_type." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub


#End Region


#Region "Public properties ################################################"

    Public Property COMPLAINT_CALL_DETAIL_TYPE_ID() As Int32
        Get
            COMPLAINT_CALL_DETAIL_TYPE_ID = m_COMPLAINT_CALL_DETAIL_TYPE_ID
        End Get
        Set(ByVal value As Int32)
            m_COMPLAINT_CALL_DETAIL_TYPE_ID = value
        End Set
    End Property

    Public Property COMPLAINT_CALL_DETAIL_TYPE_NAME() As String
        Get
            COMPLAINT_CALL_DETAIL_TYPE_NAME = m_COMPLAINT_CALL_DETAIL_TYPE_NAME
        End Get
        Set(ByVal value As String)
            m_COMPLAINT_CALL_DETAIL_TYPE_NAME = value
        End Set
    End Property

#End Region


End Class ' cCOMPLAINT_CALL_TYPE