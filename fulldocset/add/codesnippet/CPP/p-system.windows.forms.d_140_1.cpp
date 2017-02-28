   // Handles drawing the ToolTip.
private:
   void toolTip1_Draw( System::Object^ /*sender*/, System::Windows::Forms::DrawToolTipEventArgs^ e )
   {
      // Draw the ToolTip differently depending on which 
      // control this ToolTip is for.
      // Draw a custom 3D border if the ToolTip is for button1.
      if ( e->AssociatedControl == button1 )
      {
         // Draw the standard background.
         e->DrawBackground();
         
         // Draw the custom border to appear 3-dimensional.
         array<Point>^ temp1 = {Point(0,e->Bounds.Height - 1),Point(0,0),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlLightLight, temp1 );
         array<Point>^ temp2 = {Point(0,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlDarkDark, temp2 );
         
         // Specify custom text formatting flags.
         TextFormatFlags sf = static_cast<TextFormatFlags>(TextFormatFlags::VerticalCenter | TextFormatFlags::HorizontalCenter | TextFormatFlags::NoFullWidthCharacterBreak);
         
         // Draw the standard text with customized formatting options.
         e->DrawText( sf );
      }
      // Draw a custom background and text if the ToolTip is for button2.
      else
      
      // Draw a custom background and text if the ToolTip is for button2.
      if ( e->AssociatedControl == button2 )
      {
         // Draw the custom background.
         e->Graphics->FillRectangle( SystemBrushes::ActiveCaption, e->Bounds );
         
         // Draw the standard border.
         e->DrawBorder();
         
         // Draw the custom text.
         // The using block will dispose the StringFormat automatically.
         StringFormat^ sf = gcnew StringFormat;
         try
         {
            sf->Alignment = StringAlignment::Center;
            sf->LineAlignment = StringAlignment::Center;
            sf->HotkeyPrefix = System::Drawing::Text::HotkeyPrefix::None;
            sf->FormatFlags = StringFormatFlags::NoWrap;
            System::Drawing::Font^ f = gcnew System::Drawing::Font( "Tahoma",9 );
            try
            {
               e->Graphics->DrawString( e->ToolTipText, f, SystemBrushes::ActiveCaptionText, e->Bounds, sf );
            }
            finally
            {
               if ( f )
                  delete safe_cast<IDisposable^>(f);
            }

         }
         finally
         {
            if ( sf )
               delete safe_cast<IDisposable^>(sf);
         }
      }
      // Draw the ToolTip using default values if the ToolTip is for button3.
      else if ( e->AssociatedControl == button3 )
      {
         e->DrawBackground();
         e->DrawBorder();
         e->DrawText();
      }
   }