      ArrayList myOptions = new ArrayList();
      String myOption;
      bool toUnInstall = false;
      bool toPrintHelp = false;
      TransactedInstaller myTransactedInstaller = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller;
      InstallContext myInstallContext;

      try
      {
         for(int i = 0; i < args.Length; i++)
         {
            // Process the arguments.
            if(args[i].StartsWith("/") || args[i].StartsWith("-"))
            {
               myOption = args[i].Substring(1);
               // Determine whether the option is to 'uninstall' an assembly.
               if(String.Compare(myOption, "u", true) == 0 ||
                  String.Compare(myOption, "uninstall", true) == 0)
               {
                  toUnInstall = true;
                  continue;
               }
               // Determine whether the option is for printing help information.
               if(String.Compare(myOption, "?", true) == 0 ||
                  String.Compare(myOption, "help", true) == 0)
               {
                  toPrintHelp = true;
                  continue;
               }
               // Add the option encountered to the list of all options
               // encountered for the current assembly.
               myOptions.Add(myOption);
            }
            else
            {
               // Determine whether the assembly file exists.
               if(!File.Exists(args[i]))
               {
                  // If assembly file doesn't exist then print error.
                  Console.WriteLine("\nError : {0} - Assembly file doesn't exist.",
                     args[i]);
                  return;
               }
            
               // Create a instance of 'AssemblyInstaller' that installs the given assembly.
               myAssemblyInstaller = 
                  new AssemblyInstaller(args[i], 
                  (string[]) myOptions.ToArray(typeof(string)));
               // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.  
               myTransactedInstaller.Installers.Add(myAssemblyInstaller);
            }
         }
         // If user requested help or didn't provide any assemblies to install
         // then print help message.
         if(toPrintHelp || myTransactedInstaller.Installers.Count == 0)
         {
            PrintHelpMessage();
            return;
         }

         // Create a instance of 'InstallContext' with the options specified.
         myInstallContext = 
            new InstallContext("Install.log", 
            (string[]) myOptions.ToArray(typeof(string)));
         myTransactedInstaller.Context = myInstallContext;

         // Install or Uninstall an assembly depending on the option provided.
         if(!toUnInstall)
            myTransactedInstaller.Install(new Hashtable());
         else
            myTransactedInstaller.Uninstall(null);
      }
      catch(Exception e)
      {
         Console.WriteLine("\nException raised : {0}", e.Message);
      }  