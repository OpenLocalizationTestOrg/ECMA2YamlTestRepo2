         WarningException^ myEx = gcnew WarningException( "This is a warning" );
         Console::WriteLine( myEx->Message );
         Console::WriteLine( myEx->ToString() );