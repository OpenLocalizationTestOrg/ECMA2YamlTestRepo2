
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>PagerSetting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>PagerSetting Example</h3>
                       
        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          runat="server">
          
          <pagersettings mode="NextPreviousFirstLast"
            firstpageimageurl="~/Images/FirstPage.jpg"
            firstpagetext="First Page" 
            lastpageimageurl="~/Images/LastPage.jpg"
            lastpagetext="Last Page" 
            nextpageimageurl="~/Images/NextPage.jpg"
            nextpagetext="Next Page" 
            previouspageimageurl="~/Images/PreviousPage.jpg"
            previouspagetext="Previous Page"    
            position="Bottom"/> 
            
        </asp:gridview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>
