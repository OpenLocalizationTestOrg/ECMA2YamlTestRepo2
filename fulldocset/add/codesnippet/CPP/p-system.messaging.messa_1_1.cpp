            // Set the queue's MessageReadPropertyFilter property 
            // to enable the message's DigitalSignature property.
            queue->MessageReadPropertyFilter->
                DigitalSignature = true;
            
            // Peek at the message. Time out after ten seconds 
            // in case the message was not delivered.
            orderMessage = queue->Peek(TimeSpan::FromSeconds(10.0));
            
            // Display the value of the message's 
            // DigitalSignature property.
            Console::WriteLine("Message.DigitalSignature: {0}", 
                orderMessage->DigitalSignature);
            