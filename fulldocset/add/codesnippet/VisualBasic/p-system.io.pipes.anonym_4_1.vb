Imports System
Imports System.IO
Imports System.IO.Pipes

Class PipeClient
    Shared Sub Main(args() as String)
        If args.Length > 0 Then
            Using pipeClient As New AnonymousPipeClientStream(PipeDirection.In, args(0))
                ' Show that anonymous Pipes do not support Message mode.
                Try
                    Console.WriteLine("[CLIENT] Setting ReadMode to ""Message"".")
                    pipeClient.ReadMode = PipeTransmissionMode.Message
                Catch e As NotSupportedException
                    Console.WriteLine("[CLIENT] Execption:" + vbNewLine + "    {0}", e.Message)
                End Try

                Console.WriteLine("[CLIENT] Current TransmissionMode: {0}.", _
                   pipeClient.TransmissionMode)

                Using sr As New StreamReader(pipeClient)
                    ' Display the read text to the console
                    Dim temp As String

                    ' Wait for 'sync message' from the server.
                    Do
                        Console.WriteLine("[CLIENT] Wait for sync...")
                        temp = sr.ReadLine()
                    Loop While temp.StartsWith("SYNC") = False

                    ' Read the server data and echo to the console.
                    temp = sr.ReadLine()
                    While Not temp = Nothing
                        Console.WriteLine("[CLIENT] Echo: " + temp)
                        temp = sr.ReadLine()
                    End While
                End Using
            End Using
        End If
        Console.Write("[CLIENT] Press Enter to continue...")
        Console.ReadLine()
    End Sub
End Class