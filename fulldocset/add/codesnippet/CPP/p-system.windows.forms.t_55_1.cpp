   // Declare ToolBar1.
internal:
   System::Windows::Forms::ToolBar^ ToolBar1;

private:

   // Initialize ToolBar1 with Bold(B), Italic(I), and 
   // Underline(U) buttons.
   void InitializeToolBar()
   {
      ToolBar1 = gcnew ToolBar;
      
      // Set the appearance to Flat.
      ToolBar1->Appearance = ToolBarAppearance::Flat;
      
      // Set the toolbar to dock at the bottom of the form.
      ToolBar1->Dock = DockStyle::Bottom;
      
      // Set the toolbar font to 14 points and bold.
      ToolBar1->Font = gcnew System::Drawing::Font( FontFamily::GenericSansSerif,14,FontStyle::Bold );
      
      // Declare fontstyle array with the three font styles.
      array<FontStyle>^ fonts = {FontStyle::Bold,FontStyle::Italic,FontStyle::Underline};
      int count;
      
      // Create a button for each value in the array, setting its 
      // text to the first letter of the style and its 
      // button's tag property.
      for ( count = 0; count < fonts->Length; count++ )
      {
         ToolBarButton^ fontButton = gcnew ToolBarButton( fonts[ count ].ToString()->Substring( 0, 1 ) );
         fontButton->Style = ToolBarButtonStyle::ToggleButton;
         fontButton->Tag = fonts[ count ];
         ToolBar1->Buttons->Add( fontButton );

      }
      this->ToolBar1->ButtonClick += gcnew ToolBarButtonClickEventHandler( this, &Form1::ToolBar1_ButtonClick );
      this->Controls->Add( this->ToolBar1 );
   }

   // Declare FontStyle object, which defaults to the Regular
   // FontStyle.
   FontStyle style;
   void ToolBar1_ButtonClick( Object^ /*sender*/, System::Windows::Forms::ToolBarButtonClickEventArgs^ e )
   {
      // If a button is pushed, use a bitwise Or combination 
      // of the style variable and the button tag, to set style to 
      // the correct FontStyle. Set the button's PartialPush 
      // property to true for a Windows XP-like appearance.
      if ( e->Button->Pushed )
      {
         e->Button->PartialPush = true;
         style = (FontStyle)(style | safe_cast<FontStyle>(e->Button->Tag));
      }
      else
      {
         // If the button was not pushed, use a bitwise XOR 
         // combination to turn off that style 
         // and set the PartialPush property to false.
         e->Button->PartialPush = false;
         style = (FontStyle)(style ^ safe_cast<FontStyle>(e->Button->Tag));
      }

      // Set the font using the existing RichTextBox font and the new
      // style.
      RichTextBox1->Font = gcnew System::Drawing::Font( RichTextBox1->Font,style );
   }