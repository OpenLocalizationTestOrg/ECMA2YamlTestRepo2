#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Configuration::Install;
using namespace System::Diagnostics;
using namespace System::ComponentModel;

[RunInstaller(true)]
public ref class SampleEventLogInstaller : public Installer
{
private:
   EventLogInstaller^ myEventLogInstaller;

public:
   SampleEventLogInstaller()
   {
      
      // Create an instance of an EventLogInstaller.
      myEventLogInstaller = gcnew EventLogInstaller;
      
      // Set the source name of the event log.
      myEventLogInstaller->Source = "ApplicationEventSource";
      
      // Set the event log into which the source writes entries.
      //myEventLogInstaller.Log = "MyCustomLog";
      myEventLogInstaller->Log = "myNewLog";
      
      // Set the resource file for the event log.
      // The message strings are defined in EventLogMsgs.mc; the message 
      // identifiers used in the application must match those defined in the
      // corresponding message resource file. The messages must be built
      // into a Win32 resource library and copied to the target path on the
      // system.  
      myEventLogInstaller->CategoryResourceFile =
             Environment::SystemDirectory + "\\eventlogmsgs.dll";
      myEventLogInstaller->CategoryCount = 3;
      myEventLogInstaller->MessageResourceFile =
             Environment::SystemDirectory + "\\eventlogmsgs.dll";
      myEventLogInstaller->ParameterResourceFile =
             Environment::SystemDirectory + "\\eventlogmsgs.dll";

      // Add myEventLogInstaller to the installer collection.
      Installers->Add( myEventLogInstaller );
   }

};

int main()
{
   Console::WriteLine( "Usage: InstallUtil.exe [<install>.exe | <install>.dll]" );
}
