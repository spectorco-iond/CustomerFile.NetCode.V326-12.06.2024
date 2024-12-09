Imports System.Data.Odbc

Public Class cDBA

    Private m_Connexion As Odbc.OdbcConnection
    Private m_Command As Odbc.OdbcCommand
    Private m_CommandBuilder As Odbc.OdbcCommandBuilder
    Private m_DataAdapter As Odbc.OdbcDataAdapter
    Private m_DataSet As DataSet
    Private m_DataTable As DataTable
    Private m_ConnectionString As String

    Public Sub New()

        m_Connexion = Connexion() ' New Odbc.OdbcConnection
        m_Command = New Odbc.OdbcCommand
        m_CommandBuilder = New Odbc.OdbcCommandBuilder
        m_DataAdapter = New Odbc.OdbcDataAdapter
        m_DataSet = New DataSet
        m_DataTable = New DataTable

    End Sub

    Public Sub New(ByVal pstrConnection As String)

        m_ConnectionString = pstrConnection
        m_Connexion = Connexion(pstrConnection) ' New Odbc.OdbcConnection
        m_Command = New Odbc.OdbcCommand
        m_CommandBuilder = New Odbc.OdbcCommandBuilder
        m_DataAdapter = New Odbc.OdbcDataAdapter
        m_DataSet = New DataSet
        m_DataTable = New DataTable

    End Sub

    Public Function Connexion() As Odbc.OdbcConnection

        'Connexion = Connexion("Driver={SQL Server};Server=Exact;Trusted_Connection=Yes;Database=100")
        'Connexion = Connexion("Provider=SQLOLEDB;" & gConn.ConnectionString)

        'If gServerName Is Nothing Then
        '    If g_User Is Nothing Then
        '        Connexion = Connexion(g_Default_Conn_String)
        '    Else
        '        Connexion = Connexion(g_User.Conn_String)
        '    End If
        'Else
        '    If gServerName.ToUpper.Trim = "THOR" Then
        '        Connexion = Connexion("DSN=Thor;")
        '    Else
        '        'Connexion = Connexion("DSN=Exact;")
        '        If g_User Is Nothing Then
        '            Connexion = Connexion(g_Default_Conn_String)
        '        Else
        '            Connexion = Connexion(g_User.Conn_String)
        '        End If
        '    End If
        'End If

        Connexion = Connexion("DSN=EXACT")

        m_Connexion = Connexion

    End Function

    Public Property DBCommand() As Odbc.OdbcCommand
        Get
            DBCommand = m_Command
        End Get
        Set(ByVal value As Odbc.OdbcCommand)
            m_Command = value
        End Set
    End Property

    Public Property DBDataAdapter() As Odbc.OdbcDataAdapter
        Get
            DBDataAdapter = m_DataAdapter
        End Get
        Set(ByVal value As Odbc.OdbcDataAdapter)
            m_DataAdapter = value
        End Set
    End Property

    Public Property DBDataSet() As DataSet
        Get
            DBDataSet = m_DataSet
        End Get
        Set(ByVal value As DataSet)
            m_DataSet = value
        End Set
    End Property

    Public Property DBDataTable() As DataTable
        Get
            DBDataTable = m_DataTable
        End Get
        Set(ByVal value As DataTable)
            m_DataTable = value
        End Set
    End Property

    Public Function Connexion(ByVal pstrConnectionString) As Odbc.OdbcConnection

        Connexion = New Odbc.OdbcConnection(pstrConnectionString)
        m_Connexion = Connexion

    End Function

    Public Function Command(ByVal pstrSql As String) As Odbc.OdbcCommand

        Command = New Odbc.OdbcCommand(pstrSql, m_Connexion)

        m_Command = Command

    End Function

    Public Function Command(ByVal pstrSql As String, ByRef oConnexion As Odbc.OdbcConnection) As Odbc.OdbcCommand

        Command = New Odbc.OdbcCommand(pstrSql, oConnexion)
        m_Command = Command

    End Function

    Public Function DataAdapter(ByRef oCommand As Odbc.OdbcCommand) As Odbc.OdbcDataAdapter

        DataAdapter = New Odbc.OdbcDataAdapter(oCommand)
        'Call SetCommandBuilders()
        m_DataAdapter = DataAdapter

    End Function

    Public Function DataAdapter(ByVal pstrSql As String) As Odbc.OdbcDataAdapter

        DataAdapter = New Odbc.OdbcDataAdapter(Command(pstrSql))
        'Call SetCommandBuilders()
        m_DataAdapter = DataAdapter

    End Function

    Public Function DataSet(ByRef oDataAdapter As Odbc.OdbcDataAdapter) As DataSet

        DataSet = New DataSet
        oDataAdapter.Fill(DataSet)
        m_DataSet = DataSet

    End Function

    Public Function DataSet(ByVal pstrSql As String) As DataSet

        DataSet = New DataSet
        DataAdapter(pstrSql).Fill(DataSet)
        m_DataSet = DataSet

    End Function

    Public Function DataTable(ByRef oDataset As DataSet, ByVal pstrIndex As String) As DataTable

        DataTable = oDataset.Tables(pstrIndex)
        m_DataTable = DataTable

    End Function

    Public Function DataTable(ByRef oDataset As DataSet, ByVal piIndex As Integer) As DataTable

        DataTable = oDataset.Tables(piIndex)
        m_DataTable = DataTable

    End Function

    Public Function DataTable(ByVal pstrSql As String) As DataTable

        DataTable = DataSet(pstrSql).Tables(0)
        m_DataTable = DataTable

    End Function

    Public Sub Execute(ByVal pstrSql As String)

        m_Command = Command(pstrSql)

        If m_Command.Connection.State <> ConnectionState.Open Then m_Command.Connection.Open()

        m_Command.ExecuteNonQuery()

        If m_Command.Connection.State <> ConnectionState.Closed Then m_Command.Connection.Close()

    End Sub


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
