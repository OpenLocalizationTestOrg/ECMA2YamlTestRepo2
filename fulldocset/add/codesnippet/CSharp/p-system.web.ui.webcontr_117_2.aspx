<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ICollection CreateDataSource()
    {
        // Create a Random object to mix up the 
        // order of items in the sample data.
        Random randNum = new Random();

        // Create sample data for the DataGrid control.
        DataTable dt = new DataTable();

        // Define the columns of the table.
        dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
        dt.Columns.Add(new DataColumn("StringValue", typeof(String)));
        dt.Columns.Add(new DataColumn("CurrencyValue", typeof(Double)));

        // Populate the table with sample values.
        for (int i = 0; i <= 8; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = "Item " + randNum.Next(1, 15).ToString();
            dr[2] = 1.23 * randNum.Next(1, 15);
            dt.Rows.Add(dr);
        }

        // To persist the data source between posts to the server,
        // store it in session state.  
        Session["Source"] = dt;
        DataView dv = new DataView(dt);
        return dv;
    }

    void Page_Load(Object sender, EventArgs e)
    {
        // Load sample data only once, when the page is first loaded.
        if (!IsPostBack)
        {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
        }
    }

    void Sort_Grid(Object sender, DataGridSortCommandEventArgs e)
    {
        // Retrieve the data source from session state.
        DataTable dt = (DataTable)Session["Source"];

        // Create a DataView from the DataTable.
        DataView dv = new DataView(dt);

        // The DataView provides an easy way to sort. Simply set the
        // Sort property with the name of the field to sort by.
        dv.Sort = e.SortExpression;

        // Rebind the data source and specify that it should be sorted
        // by the field specified in the SortExpression property.
        ItemsGrid.DataSource = dv;
        ItemsGrid.DataBind();
    }

    void Check_Change(Object sender, EventArgs e)
    {
        // Allow or prevent sorting depending on the user's selection.
        ItemsGrid.AllowSorting = AllowSortingCheckBox.Checked;

        // After changing the property, rebind the data to
        // refresh the DataGrid control.

        // Retrieve the data source from session state.
        DataTable dt = (DataTable)Session["Source"];

        // Create a DataView from the DataTable.
        DataView dv = new DataView(dt);

        // Rebind the data source.
        ItemsGrid.DataSource = dv;
        ItemsGrid.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>
        ExtractTemplateRows Example
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>DataGrid AllowSorting Example</h3>

      <p>Select whether to allow sorting in the DataGrid control.<br />
      <asp:CheckBox id="AllowSortingCheckBox"
           Text="Allow sorting"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/></p>
      <hr />
 
      <b>Product List</b>
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           OnSortCommand="Sort_Grid"
           UseAccessibleHeader="true"
           AutoGenerateColumns="False"
           AllowSorting="True"
           runat="server">

         <HeaderStyle BackColor="#00aaaa" />
         <Columns>
            <asp:BoundColumn DataField="IntegerValue" 
                 SortExpression="IntegerValue"
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue"
                 SortExpression="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 SortExpression="CurrencyValue"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>
            </asp:BoundColumn>
         </Columns> 
      </asp:DataGrid>
 
   </div>
   </form>
</body>
</html>