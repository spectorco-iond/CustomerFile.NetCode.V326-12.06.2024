Option Strict Off
Option Explicit On

Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Xml
Imports System.Globalization

Public Class cMdb_Cus_Prog_Rev_BLL

    ' Handle to the Mdb_Cus_Prog DBAccess class
    Private oDAL As cMdb_Cus_Prog_Rev_DAL = Nothing


    Public Sub New()
        oDAL = New cMdb_Cus_Prog_Rev_DAL()
    End Sub


    '' List all elements in the database 
    'Public Function GetList() As List(Of cMdb_Cus_Prog)
    '    Return oMdb_Cus_Prog_DA.GetList()
    'End Function


    ' Get element with ID specified from the database 
    Public Function Load(ByVal piCus_Prog_Rev_Id As Integer) As cMdb_Cus_Prog_Rev
        Return oDAL.Load(piCus_Prog_Rev_Id)
    End Function

    ' Insert current element in the database 
    Public Function Load(ByRef oProgram As cMdb_Cus_Prog) As cMdb_Cus_Prog_Rev
        Return oDAL.Load(oProgram)
    End Function

    ' Insert current element in the database 
    Public Function Save(ByRef oCus_Prog_Rev As cMdb_Cus_Prog_Rev) As Boolean
        Return oDAL.Save(oCus_Prog_Rev)
    End Function

    'Ion 15.10.14 Delete element with ID specified from the database 
    Public Sub Delete(ByRef oProgram As cMdb_Cus_Prog)
        oDAL.Delete(oProgram)
    End Sub

    Public Function Clone(ByRef oCus_Prog_Rev As cMdb_Cus_Prog_Rev) As cMdb_Cus_Prog_Rev

        ' Clones everything BUT the primary key
        Dim oClone As New cMdb_Cus_Prog_Rev

        oClone.Cus_Prog_Id = oCus_Prog_Rev.Cus_Prog_Id
        oClone.Rev_No = oCus_Prog_Rev.Rev_No
        oClone.Rev_State = oCus_Prog_Rev.Rev_State
        oClone.Program = oCus_Prog_Rev.Program
        oClone.Imprint = oCus_Prog_Rev.Imprint
        oClone.Prog_CSR = oCus_Prog_Rev.Prog_CSR
        oClone.Start_Dt = oCus_Prog_Rev.Start_Dt
        oClone.End_Dt = oCus_Prog_Rev.End_Dt
        oClone.Cicntp_ID = oCus_Prog_Rev.Cicntp_ID

        oClone.User_Login = Environment.UserName
        oClone.Create_Ts = Date.Now
        oClone.Update_Ts = Date.Now

        Return oClone

    End Function


    ' Delete element with ID specified from the database 
    'Public Function Delete(ByVal piCus_Prog_Id As Integer) As Boolean
    '    Return oMdb_Cus_Prog_DA.Delete(piCus_Prog_Id)
    'End Function

    '' Update current element in the database 
    'Public Function Update(ByRef oMdb_Cus_Prog As cMdb_Cus_Prog) As Boolean
    '    Return oMdb_Cus_Prog_DA.Save(oMdb_Cus_Prog)
    'End Function

    ' Validate current element 
    Public Function Validate(ByRef oCus_Prog_Rev As cMdb_Cus_Prog_Rev) As Boolean
        Return True
    End Function


    Public Sub Init(ByRef oCus_Prog_Rev As cMdb_Cus_Prog_Rev)

        Try

            With oCus_Prog_Rev

                .Cus_Prog_Rev_ID = 0
                .Cus_Prog_Id = 0
                .Rev_No = 0
                .Rev_State = String.Empty
                .Program = String.Empty
                .Imprint = String.Empty
                .Prog_CSR = String.Empty
                .Start_Dt = NoDate()
                .End_Dt = NoDate()
                .Cicntp_ID = 0
                .User_Login = Environment.UserName
                .Create_Ts = Date.Now
                .Update_Ts = Date.Now

            End With

        Catch ex As Exception
            MsgBox("Error in cMdb_Cus_Prog_Rev_BUS." & New Diagnostics.StackFrame(0).GetMethod.Name & vbCrLf & ex.Message)
        End Try

    End Sub

End Class
