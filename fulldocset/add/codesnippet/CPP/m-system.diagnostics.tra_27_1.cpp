private:
    static TraceSwitch^ appSwitch = gcnew TraceSwitch("mySwitch",
        "Switch in config file");

public:
    static void Main(array<String^>^ args)
    {
        //...
        Console::WriteLine("Trace switch {0} configured as {1}",
        appSwitch->DisplayName, appSwitch->Level.ToString());
        if (appSwitch->TraceError)
        {
            //...
        }
    }