Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml
Imports System.Globalization

Public Class cMdb_Cfg_Prod_Cat_BLL

    ' Handle to the Mdb_Cus_Prog DBAccess class
    Private oDAL As cMdb_Cfg_Prod_Cat_DAL = Nothing


    Public Sub New()
        oDAL = New cMdb_Cfg_Prod_Cat_DAL()
    End Sub


    '' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Cus_Prog)
    '    Return oMdb_Cus_Prog_DA.GetList()
    'End Function


    ' Get element with ID specified from the database 
    Public Function Load(ByVal piProd_Cat_Id As Integer) As cMdb_Cfg_Prod_Cat
        Return oDAL.Load(piProd_Cat_Id)
    End Function


    Public Function Load(ByVal piProd_Cat_Code_Cd As String) As cMdb_Cfg_Prod_Cat
        Return oDAL.Load(piProd_Cat_Code_Cd)
    End Function


    ' Insert current element in the database 
    Public Function Save(ByRef oProd_Cat As cMdb_Cfg_Prod_Cat) As Boolean
        Return oDAL.Save(oProd_Cat)
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
    Public Function Validate(ByRef oProd_Cat As cMdb_Cfg_Prod_Cat) As Boolean
        Return True
    End Function

    Public Sub Init(ByRef oProd_Cat As cMdb_Cfg_Prod_Cat)

        Try

            With oProd_Cat

                .Prod_Cat_ID = 0
                .Prod_Cat_Code = String.Empty
                .Prod_Cat_Desc = String.Empty
                .Prod_Cat_Order = 0
                .User_Login = String.Empty
                .Create_Ts = NoDate()
                .Update_Ts = NoDate()

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Function Clone(ByRef oSource As cMdb_Cfg_Prod_Cat) As cMdb_Cfg_Prod_Cat

        ' Clones everything BUT the primary key
        Dim oClone As New cMdb_Cfg_Prod_Cat

        oClone.Prod_Cat_Code = oSource.Prod_Cat_Code
        oClone.Prod_Cat_Desc = oSource.Prod_Cat_Desc
        oClone.Prod_Cat_Order = oSource.Prod_Cat_Order

        oClone.User_Login = Environment.UserName
        oClone.Create_Ts = Date.Now
        oClone.Update_Ts = Date.Now

        Return oClone

    End Function


    Public Function Get_Item_List(ByVal pProd_Cat_ID As Integer) As DataTable

        Get_Item_List = Nothing

        Try

            Dim strSql As String = _
            "SELECT * " & _
            "FROM   mdb_item_prod_cat_preview " & _
            "WHERE  prod_cat_id = " & pProd_Cat_ID.ToString

            Get_Item_List = New cDBA().DataTable(strSql)

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Function

End Class
