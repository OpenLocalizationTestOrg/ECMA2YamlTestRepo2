        // Set the queue's MessageReadPropertyFilter property to enable the
        // message's HashAlgorithm property.
        queue.MessageReadPropertyFilter.HashAlgorithm = true;

        // Peek at the message. Time out after ten seconds in case the message
        // was not delivered.
        orderMessage = queue.Peek(TimeSpan.FromSeconds(10.0)); 

        // Display the value of the message's HashAlgorithm property.
        Console.WriteLine("Message.HashAlgorithm: {0}",
            orderMessage.HashAlgorithm);