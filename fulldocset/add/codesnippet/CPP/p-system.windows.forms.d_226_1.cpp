private:
   void GetPropertyDescriptor()
   {
      PropertyDescriptor^ pd;
      pd = dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 0 ]->PropertyDescriptor;
      Console::WriteLine( pd );
   }

   void CreateNewDataGridColumnStyle()
   {
      GridColumnStylesCollection^ myGridColumnCol;
      myGridColumnCol = dataGrid1->TableStyles[ 0 ]->GridColumnStyles;
      
      // Get the CurrencyManager for the table you want to add a column to.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ ds->Tables[ "Suppliers" ] ]);
      
      // Get the PropertyDescriptor for the DataColumn of the new column.
      PropertyDescriptor^ pd = myCurrencyManager->GetItemProperties()[ "City" ];
      DataGridColumnStyle^ myColumn = gcnew DataGridTextBoxColumn( pd );
      myGridColumnCol->Add( myColumn );
   }
