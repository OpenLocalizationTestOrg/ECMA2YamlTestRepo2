    Public Sub OleDbCommandPrepare(ByVal connectionString As String)

        Using connection As OleDbConnection = New _
            OleDbConnection(connectionString)
            connection.Open()

            ' Create the Command.
            Dim command As OleDbCommand = New OleDbCommand()

            ' Set the Connection, CommandText and Parameters.
            command.Connection = connection
            command.CommandText = _
              "INSERT INTO dbo.Region (RegionID, RegionDescription) VALUES (?, ?);"
            command.Parameters.Add("RegionID", OleDbType.Integer, 4)
            command.Parameters.Add("RegionDescription", OleDbType.VarWChar, 50)
            command.Parameters(0).Value = 20
            command.Parameters(1).Value = "First Region"

            ' Call  Prepare and ExecuteNonQuery.
            command.Prepare()
            command.ExecuteNonQuery()

            ' Change parameter values and call ExecuteNonQuery.
            command.Parameters(0).Value = 21
            command.Parameters(1).Value = "Second Region"
            command.ExecuteNonQuery()
        End Using
    End Sub