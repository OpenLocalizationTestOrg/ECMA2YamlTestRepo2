        Public Shared Function CompileExecutable(sourceName As String) As Boolean
            Dim sourceFile As FileInfo = New FileInfo(sourceName)
            Dim provider As CodeDomProvider = Nothing
            Dim compileOk As Boolean = False

            ' Select the code provider based on the input file extension.
            If sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".CS"

                provider = CodeDomProvider.CreateProvider("CSharp")

            ElseIf sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".VB"

                provider = CodeDomProvider.CreateProvider("VisualBasic")

            Else
                Console.WriteLine("Source file must have a .cs or .vb extension")
            End If

            If Not provider Is Nothing

                ' Format the executable file name.
                ' Build the output assembly path using the current directory
                ' and <source>_cs.exe or <source>_vb.exe.

                Dim exeName As String = String.Format("{0}\{1}.exe", _
                    System.Environment.CurrentDirectory, _
                    sourceFile.Name.Replace(".", "_"))

                Dim cp As CompilerParameters = new CompilerParameters()

                ' Generate an executable instead of 
                ' a class library.
                cp.GenerateExecutable = True

                ' Specify the assembly file name to generate.
                cp.OutputAssembly = exeName
    
                ' Save the assembly as a physical file.
                cp.GenerateInMemory = False
    
                ' Set whether to treat all warnings as errors.
                cp.TreatWarningsAsErrors = False
 
                ' Invoke compilation of the source file.
                Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, _
                    sourceName)
    
                If cr.Errors.Count > 0
                    ' Display compilation errors.
                    Console.WriteLine("Errors building {0} into {1}", _
                        sourceName, cr.PathToAssembly)

                    Dim ce As CompilerError
                    For Each ce In cr.Errors
                        Console.WriteLine("  {0}", ce.ToString())
                        Console.WriteLine()
                    Next ce
                Else
                    ' Display a successful compilation message.
                    Console.WriteLine("Source {0} built into {1} successfully.", _
                        sourceName, cr.PathToAssembly)
                End If
              
                ' Return the results of the compilation.
                If cr.Errors.Count > 0
                    compileOk = False
                Else 
                    compileOk = True
                End If
            End If
            return compileOk

        End Function