<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Bind a data source to the Repeater control. 
    Repeater1.DataSource = CreateRepeaterSource()
    Repeater1.DataBind()

  End Sub

  Sub Item_Bound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
 
    ' The ItemDataBound event is raised when data is bound to an
    ' item in the Repeater control. Items can include the Header,
    ' Footer, and so on. Use the following logic only if the item 
    ' being bound is an Item or AlternatingItem.
    If (e.Item.ItemType = ListItemType.Item) Or _
       (e.Item.ItemType = ListItemType.AlternatingItem) Then

      ' The runtime automatically generates a unique identifier
      ' for each control embedded in a list control, such as the
      ' Repeater control. The Name property of the HtmlTextArea 
      ' control contains this unique identifier and is commonly used to 
      ' identify a specific control.
            
      ' Retrieve the HtmlTextArea control from the RepeaterItem.
      Dim area As HtmlTextArea = _
          CType(e.Item.FindControl("TextArea1"), HtmlTextArea)

      ' Insert a custom message for the fourth HtmlTextArea control by
      ' looking for a Name property that contains the number 3.
      If area.Name.Contains("3") Then

        area.Value = "Hello World"

      End If

    End If

  End Sub

  Function CreateRepeaterSource() As DataView

    ' Create a DataTable that contains sample data for the 
    ' Repeater control.
    Dim dt As DataTable = New DataTable()
    Dim dr As DataRow
 
    dt.Columns.Add(New DataColumn("Category", GetType(String)))
 
    ' Populate the DataTable with sample values.
    Dim i As Integer
 
    For i = 0 To 4
       
      dr = dt.NewRow()
 
      dr(0) = "Category " & i.ToString()

      dt.Rows.Add(dr)
         
    Next i
 
    ' Create a DataView from the DataTable.
    Dim dv As DataView = New DataView(dt)
    Return dv

  End Function
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTextArea Name Example</title>
</head>  
<body>

   <form id="form1" runat="server">
  
      <h3>HtmlTextArea Name Example</h3>

      Notice that Category 3 has custom text. <br /> 
  
      <asp:Repeater id="Repeater1"
                    onitemdatabound="Item_Bound"
                    runat="server">

         <ItemTemplate>

            <h4><%# DataBinder.Eval(Container.DataItem, "Category") %></h4>

            Enter text:

            <br />

            <textarea rows="2" cols="20" id="TextArea1" 
                      runat="server"/>

            <br /><br />

            <hr />

         </ItemTemplate>

      </asp:Repeater>
  
   </form>

</body>
</html>