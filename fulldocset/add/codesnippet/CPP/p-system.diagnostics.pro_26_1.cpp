#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
int main()
{
   try
   {
      Console::Write( "Create notepad processes on remote computer \n" );
      Console::Write( "Enter remote computer name : " );
      String^ remoteMachineName = Console::ReadLine();
      
      // Get all notepad processess into Process array.
      array<Process^>^myProcesses = Process::GetProcessesByName( "notepad", remoteMachineName );
      if ( myProcesses->Length == 0 )
            Console::WriteLine( "Could not find notepad processes on remote computer." );
      Collections::IEnumerator^ myEnum = myProcesses->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Process^ myProcess = safe_cast<Process^>(myEnum->Current);
         Console::Write( "Process Name : {0}  Process ID : {1}  MachineName : {2}\n", myProcess->ProcessName, myProcess->Id, myProcess->MachineName );
      }
   }
   catch ( SystemException^ e ) 
   {
      Console::Write( "Caught Exception .... : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::Write( "Caught Exception .... : {0}", e->Message );
   }

}
