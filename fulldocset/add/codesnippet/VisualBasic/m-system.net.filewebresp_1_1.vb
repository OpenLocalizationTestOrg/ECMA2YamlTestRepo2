            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri .
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response. 
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            
            
            ' CALLING METHOD GetResponseStream will return the stream associated with the response object.
            Dim ReceiveStream As Stream = myFileWebResponse.GetResponseStream()
            
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            ' Pipe the stream to a higher level stream reader with the required encoding format .
            Dim readStream As New StreamReader(ReceiveStream, encode)
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            
            Dim read(256) As [Char]
            ' Reading 256 characters at a time.    
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("File Data..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0
                ' Dump the 256 characters on a string and display the string onto the console.
                Dim str As New [String](read, 0, count)
                Console.Write(str)
                count = readStream.Read(read, 0, 256)
            End While
            Console.WriteLine("")
            ' Release the resources of stream object.
            readStream.Close()
            ' Release the resources of response object.
            myFileWebResponse.Close()