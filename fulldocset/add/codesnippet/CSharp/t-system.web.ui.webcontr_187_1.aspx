
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  
  <script runat="server">
  
    void Page_Load(Object sender, EventArgs e)
    {
      
      // Create a new DetailsView object.
      DetailsView customerDetailsView = new DetailsView();
      
      // Set the DetailsView object's properties.
      customerDetailsView.ID = "CustomerDetailsView";
      customerDetailsView.DataSourceID = "DetailsViewSource";
      customerDetailsView.AutoGenerateRows = true;
      customerDetailsView.AutoGenerateDeleteButton = true;
      customerDetailsView.AllowPaging = true;
      customerDetailsView.PagerSettings.Mode = 
        PagerButtons.NextPrevious;
      customerDetailsView.DataKeyNames = new String[1] { "CustomerID" };

      // Programmatically register the event-handling method
      // for the ItemDeleted event of a DetailsView control.
      customerDetailsView.ItemDeleted += 
        new DetailsViewDeletedEventHandler(
        this.CustomerDetailView_ItemDeleted);

      // Add the DetailsView object to the Controls collection
      // of the PlaceHolder control.
      DetailsViewPlaceHolder.Controls.Add(customerDetailsView);

    }

    void CustomerDetailView_ItemDeleted(Object sender, 
      DetailsViewDeletedEventArgs e)
    {
      // Use the Exception property to determine whether an exception
      // occurred during the delete operation.
      if (e.Exception == null)
      {
        // Use the AffectedRows property to determine the numbers of
        // rows affected by the delete operation.
        if (e.AffectedRows == 1)
        {
          MessageLabel.Text = e.AffectedRows.ToString() 
            + " record deleted successfully.";
        }
        else
        {
          MessageLabel.Text = e.AffectedRows.ToString() 
            + " records deleted successfully.";
        }
      }
      else
      {
        // Insert the code to handle the exception.
        MessageLabel.Text = e.Exception.Message;

        // Use the ExceptionHandled property to indicate that the 
        // exception is already handled.
        e.ExceptionHandled = true;
      }
    }
  
  </script>
    
  <head runat="server">
    <title>DetailsViewDeletedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewDeletedEventHandler Example</h3>
        
        <!-- Use a PlaceHolder control as the container for the -->
        <!-- dynamically generated DetailsView control.         -->       
        <asp:PlaceHolder id="DetailsViewPlaceHolder"
          runat="server"/>
          
        <br/><br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], 
            [City], [PostalCode], [Country] From [Customers]"
          deletecommand="Delete [Customers] 
            Where [CustomerID]=@CustomerID"
          connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>