public:
   void InstantiateMyCheckBox()
   {
      // Create and initialize a CheckBox.   
      CheckBox^ checkBox1 = gcnew CheckBox;
      
      // Make the check box control appear as a toggle button.
      checkBox1->Appearance = Appearance::Button;
      
      // Turn off the update of the display on the click of the control.
      checkBox1->AutoCheck = false;
      
      // Add the check box control to the form.
      this->Controls->Add( checkBox1 );
   }