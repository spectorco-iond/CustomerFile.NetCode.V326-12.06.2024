
Imports cGetElem
Imports System.Data.SqlClient
Public Class sqlConnect

    Private oGetElem As cGetElem.cGetElem

    Public Sub New()
        '    Call Test()
        Call GetInfo()
    End Sub

    Private Sub GetInfo()

        oGetElem = New cGetElem.cGetElem

        Debug.Print(oGetElem.GetElementDescription("ARSLMFIL_SQL", "", "1216"))

    End Sub

    Private Sub Test()
        '
        ' Dim conString As String = "Provider=SQLNCLI11.1;Integrated Security=SSPI;Persist Security Info=False;User ID='';Initial Catalog=100ESE;Data Source=BARIUM;Initial File Name='';Server SPN='' "

        Dim conString As String = "Data Source=BARIUM;Initial Catalog=100ESE;Persist Security Info=False;User ID='';Integrated Security=SSPI;"


        Dim conn As New SqlConnection(conString)
        Dim dt As New DataTable
        Dim adap As SqlDataAdapter
        Dim ds As New DataSet

        Dim selCmdTxt As String = " SELECT * FROM   [100].dbo.Mdb_Customer WITH (Nolock) WHERE  Cus_No = @cusno "

        conn.Open()
        Dim selCommand As New SqlCommand(selCmdTxt, conn)

        Dim param As New SqlParameter
        param.ParameterName = "@cusno"
        param.SqlDbType = SqlDbType.VarChar
        param.Value = "100055"
        selCommand.Parameters.Add(param)

        adap = New SqlDataAdapter(selCommand)

        adap.Fill(dt)

        If dt.Rows.Count <> 0 Then

        End If


    End Sub
End Class
