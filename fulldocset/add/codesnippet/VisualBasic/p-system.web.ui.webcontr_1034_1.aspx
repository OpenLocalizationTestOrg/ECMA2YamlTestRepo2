<%@ page language="VB" %>
<%@ register tagprefix="aspSample" 
             Namespace="Samples.AspNet.VB.Controls" 
             Assembly="TextDisplayWebPartVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      backcolor="#99cccc">
        <parttitlestyle font-bold="true" forecolor="#ffffff" />
        <partstyle
          borderwidth="1px" 
          borderstyle="Solid" 
          bordercolor="#81AAF2" />
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" 
            width="350px" 
            HelpMode="navigate"
            HelpUrl="TextWebPartHelp.htm" />
        </zonetemplate>
    </asp:webpartzone>
  </form>
</body>
</html>