public:
   bool FindMyText( String^ text )
   {
      // Initialize the return value to false by default.
      bool returnValue = false;
      
      // Ensure a search string has been specified.
      if ( text->Length > 0 )
      {
         // Obtain the location of the search string in richTextBox1.
         int indexToText = richTextBox1->Find( text );
         // Determine whether the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            returnValue = true;
         }
      }

      return returnValue;
   }