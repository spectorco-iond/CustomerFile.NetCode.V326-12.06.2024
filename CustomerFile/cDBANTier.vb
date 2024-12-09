Imports System.Data.Odbc

Public Class cDBANTier

    Public m_ConnectionString As String = "DSN=Traveler;"

    'Const CONNECTION_STRING As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;User Instance=True"

    Public Sub New()

    End Sub

    Public Sub New(ByVal pConnectionString As String)

        m_ConnectionString = pConnectionString

    End Sub

    ' This function will be used to execute R(CRUD) operation of parameterless commands
    'Friend Shared Function ExecuteSelectCommand(ByVal CommandName As String, ByVal cmdType As CommandType) As DataTable
    Public Function ExecuteSelectCommand(ByVal CommandName As String, ByVal cmdType As CommandType) As DataTable
        Dim table As DataTable = Nothing
        Using con As New OdbcConnection(m_ConnectionString)
            Using cmd As OdbcCommand = con.CreateCommand()
                cmd.CommandType = cmdType
                cmd.CommandText = CommandName

                Try
                    If con.State <> ConnectionState.Open Then
                        con.Open()
                    End If

                    Using da As New OdbcDataAdapter(cmd)
                        table = New DataTable()
                        da.Fill(table)
                    End Using
                Catch
                    Throw
                End Try
            End Using
        End Using

        Return table
    End Function

    ' This function will be used to execute R(CRUD) operation of parameterized commands
    'Friend Shared Function ExecuteParamerizedSelectCommand(ByVal CommandName As String, ByVal cmdType As CommandType, ByVal param As OdbcParameter()) As DataTable
    Public Function ExecuteParamerizedSelectCommand(ByVal CommandName As String, ByVal cmdType As CommandType, ByVal param As OdbcParameter()) As DataTable
        Dim table As New DataTable()

        Using con As New OdbcConnection(m_ConnectionString)
            Using cmd As OdbcCommand = con.CreateCommand()
                cmd.CommandType = cmdType
                cmd.CommandText = CommandName
                cmd.Parameters.AddRange(param)

                Try
                    If con.State <> ConnectionState.Open Then
                        con.Open()
                    End If

                    Using da As New OdbcDataAdapter(cmd)
                        da.Fill(table)
                    End Using
                Catch
                    Throw
                End Try
            End Using
        End Using

        Return table
    End Function

    ' This function will be used to execute CUD(CRUD) operation of parameterized commands
    'Friend Shared Function ExecuteNonQuery(ByVal CommandName As String, ByVal cmdType As CommandType, ByVal pars As OdbcParameter()) As Boolean
    Public Function ExecuteNonQuery(ByVal CommandName As String, ByVal cmdType As CommandType, ByVal pars As OdbcParameter()) As Boolean
        Dim result As Integer = 0

        Using con As New OdbcConnection(m_ConnectionString)
            'Using con As New OdbcConnection(CONNECTION_STRING)
            Using cmd As OdbcCommand = con.CreateCommand()
                cmd.CommandType = cmdType
                cmd.CommandText = CommandName
                cmd.Parameters.AddRange(pars)

                Try
                    If con.State <> ConnectionState.Open Then
                        con.Open()
                    End If

                    result = cmd.ExecuteNonQuery()
                Catch
                    Throw
                End Try
            End Using
        End Using

        Return (result > 0)
    End Function

End Class
