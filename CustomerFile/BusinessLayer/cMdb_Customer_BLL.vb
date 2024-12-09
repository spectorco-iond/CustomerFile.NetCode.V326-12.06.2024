Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml
Imports System.Globalization

Public Class cMdb_Customer_BUS

    ' Handle to the Mdb_Cus_Prog DBAccess class
    Private oDAL As cMdb_Customer_DAL = Nothing


    Public Sub New()
        oDAL = New cMdb_Customer_DAL()
    End Sub


    '' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Cus_Prog)
    '    Return oMdb_Cus_Prog_DA.GetList()
    'End Function


    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Id As Integer) As cMdb_Customer
        Return oDAL.Load(piCus_Id)
    End Function


    Public Function Load(ByVal piCus_No As String) As cMdb_Customer
        Return oDAL.Load(piCus_No)
    End Function


    ' Insert current element in the database 
    Public Function Save(ByRef oMdb_Customer As cMdb_Customer) As Boolean
        Save = False
        Save = oDAL.Save(oMdb_Customer)
        ' Important - we cannot call SaveCustomersFromGroup from here 
        ' because it will create an infinite recursive loop
    End Function

    Public Function SaveCustomersFromGroup(ByRef oThis As cMdb_Customer) As Boolean

        SaveCustomersFromGroup = False

        Try

            Dim oBus As New cMdb_Customer_BUS

            'Dim oThis As New cMdb_Customer

            'oThis = oBus.Load(cmp_code)

            Dim oCol As New Collection
            oCol = oDAL.LoadCustomersFromGroup(oThis)

            If oCol.Count > 0 Then

                For Each oCustomer As cMdb_Customer In oCol
                    oCustomer.White_Glove_End_Date = oThis.White_Glove_End_Date
                    oCustomer.White_Glove_Order_Count = oThis.White_Glove_Order_Count
                    oBus.Save(oCustomer)
                Next

            End If

            SaveCustomersFromGroup = True

        Catch er As Exception
            MsgBox("Error in COrdhead." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & er.Message)
        End Try

    End Function

    ' Delete element with ID specified from the database 
    'Public Function Delete(ByVal piProd_Cat_Id As Integer) As Boolean
    '    Return oMdb_Cus_Prog_DA.Delete(piProd_Cat_Id)
    'End Function

    '' Update current element in the database 
    'Public Function Update(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
    '    Return oMdb_Cus_Prog_DA.Save(oMdb_Cus_Prog)
    'End Function

    ' Validate current element 
    Public Function Validate(ByRef oMdb_Cus_Prog As cMdb_Customer) As Boolean
        Return True
    End Function

    Public Sub Init(ByRef oCus_Prog_Rev As cMdb_Customer)

        Try

            With oCus_Prog_Rev

                .Cus_Id = 0
                .Cus_No = String.Empty
                .Cus_Dec_Count = 0
                .Edi_Cus_Name = String.Empty
                .Pick_Sensitivity = 0
                .Star_Level = 0
                .Eqp_Status = False
                .Eqp_Column = 0
                .Eqp_Pct = False
                .Eqp_Trial = False
                .Group_Member = String.Empty
                .All_Star_Traveler = False
                .White_Glove_End_Date = NoDate()
                .White_Glove_Order_Count = 0
                .Coop_Pricing = False

                .User_Login = String.Empty
                .Update_Ts = NoDate()
                .CountRMA_3Month = 0

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Get_Item_List(ByVal pCus_ID As Integer) As DataTable

        Get_Item_List = Nothing

        Try

            Dim strSql As String = _
            "SELECT * " & _
            "FROM   mdb_Customer " & _
            "WHERE  Cus_id = " & pCus_ID.ToString

            Get_Item_List = New cDBA().DataTable(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function


    '    ' Handle to the Mdb_Customer DBAccess class
    '    Private oMdb_Customer_DA As cMdb_Customer_DAL = Nothing


    '    Public Sub New()
    '            oMdb_Customer_DA = New cMdb_Customer_DAL()
    '    End Sub


    '    ' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Customer)
    '    Return oMdb_Customer_DA.GetList()
    'End Function


    '    ' Update current element in the database 
    '    Public Function Update(oMdb_Customer As cMdb_Customer) As Boolean
    '    Return oMdb_Customer_DA.Update(oMdb_Customer)
    '    End Function


    '    ' Get element with ID specified from the database 
    'Public Function GetItem(piCus_Id As Integer) As cMdb_Customer
    '    Return oMdb_Customer_DA.GetItem(piCus_Id)
    'End Function


    '    ' Delete element with ID specified from the database 
    '    Public Function Delete(piCus_Id As Integer) As Boolean
    '    Return oMdb_Customer_DA.Delete(piCus_Id)
    '    End Function


    '    ' Insert current element in the database 
    '    Public Function Insert(oMdb_Customer As cMdb_Customer) As Boolean
    '    Return oMdb_Customer_DA.Insert(oMdb_Customer)
    '    End Function


    '    ' Validate current element 
    '    Public Function Validate(oMdb_Customer As cMdb_Customer) As Boolean
    '    Return True

    '    End Function


    ' '' Validate current element 
    ''Public Function Validate(oMdb_Customer As cMdb_Customer) As Boolean

    ''End Function

End Class ' cMdb_Customer


