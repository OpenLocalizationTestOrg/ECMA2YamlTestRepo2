private:
   void GetMyData()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;
      
      // Creates a new data object and assigns it the component.
      DataObject^ myDataObject = gcnew DataObject( myComponent );
      
      // Creates a type to store the type of data.
      Type^ myType = myComponent->GetType();
      
      // Retrieves the data using myType to represent its type.
      Object^ myObject = myDataObject->GetData( myType );
      if ( myObject != nullptr )
      {
         textBox1->Text = String::Format( "The data type stored in the DataObject is: {0}",
            myObject->GetType()->Name );
      }
      else
      {
         textBox1->Text = "Data of the specified type was not stored in the DataObject.";
      }
   }