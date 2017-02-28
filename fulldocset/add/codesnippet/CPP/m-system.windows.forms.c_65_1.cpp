   protected:
      virtual void OnTextChanged( System::EventArgs^ e ) override
      {
         try
         {
            // Convert the text to a Double and determine
            // if it is a negative number.
            if ( Double::Parse( this->Text ) < 0 )
            {
               // If the number is negative, display it in Red.
               this->ForeColor = Color::Red;
            }
            else
            {
               // If the number is not negative, display it in Black.
               this->ForeColor = Color::Black;
            }
         }
         catch ( Exception^ ) 
         {
            // If there is an error, display the
            // text using the system colors.
            this->ForeColor = SystemColors::ControlText;
         }

         TextBox::OnTextChanged( e );
      }