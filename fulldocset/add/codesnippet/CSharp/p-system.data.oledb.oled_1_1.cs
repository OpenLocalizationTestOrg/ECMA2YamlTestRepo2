    static void OpenConnection(string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0} \nProvider: {1}",
                    connection.ServerVersion, connection.Provider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
    }