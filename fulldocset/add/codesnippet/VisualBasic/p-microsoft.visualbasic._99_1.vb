        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.SetDelimiters(",")
        End Using