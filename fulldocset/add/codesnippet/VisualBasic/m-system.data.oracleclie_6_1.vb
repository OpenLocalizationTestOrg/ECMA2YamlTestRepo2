    Public Sub CreateOracleCommand _
    (ByVal queryString As String, ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            command.Connection.Open()
            command.ExecuteReader()
            command.Cancel()
        End Using
    End Sub