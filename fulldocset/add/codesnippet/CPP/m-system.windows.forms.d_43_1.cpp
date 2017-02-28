private:
   void button3_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      ColorDialog^ myColorDialog = gcnew ColorDialog;

      // Disable selecting a custom color.
      myColorDialog->AllowFullOpen = false;

      // Enable the help button.
      myColorDialog->ShowHelp = true;

      // Set the initial color to the current color.
      myColorDialog->Color = myDataGrid->HeaderForeColor;

      // Show color dialog box.
      myColorDialog->ShowDialog();

      // Set the header foreground color.
      myDataGrid->HeaderForeColor = myColorDialog->Color;
   }

   // Reset the header foregroundcolor.
   void button4_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->ResetHeaderForeColor();
   }