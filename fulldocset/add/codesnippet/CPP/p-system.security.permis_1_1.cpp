   // Use the enumeration flags to indicate that this method exposes shared state, 
   // self-affecting process management, and self-affecting threading.
   // This method allows the user to quit the sample.

   [HostProtection(SharedState=true,SelfAffectingProcessMgmt=true,
   SelfAffectingThreading=true,UI=true)]
   static void ExecuteBreak()
   {
      Console::WriteLine( "Executing Debugger.Break." );
      Debugger::Break();
      Debugger::Log( 1, "info", "test message" );
   }