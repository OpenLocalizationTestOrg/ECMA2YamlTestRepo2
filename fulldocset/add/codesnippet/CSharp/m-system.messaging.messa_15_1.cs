
        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new message.
        Message msg = new Message("Example Message Body");

        // Send the message.
        queue.Send(msg, "Example Message Label");

        // Get the message's Id property value.
        string id = msg.Id;

        // Peek at the message.
        msg = queue.PeekById(id, TimeSpan.FromSeconds(10.0));
