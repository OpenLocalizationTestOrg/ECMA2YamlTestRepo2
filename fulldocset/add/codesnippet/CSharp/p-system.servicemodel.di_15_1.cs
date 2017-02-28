            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            ServiceThrottle throttle = dispatcher.ServiceThrottle;