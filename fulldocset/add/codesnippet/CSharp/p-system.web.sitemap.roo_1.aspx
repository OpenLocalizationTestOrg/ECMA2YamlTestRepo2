<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
    // Examine the CurrentNode, and navigate the SiteMap relative to it.
    Response.Write(SiteMap.CurrentNode.Title + "<br />");
    Response.Write("<font COLOR='red'>" + SiteMap.CurrentNode.Url + "</font><br />");

    // What nodes are children of the CurrentNode?
    if (SiteMap.CurrentNode.HasChildNodes) {
        IEnumerator childNodesEnumerator = SiteMap.CurrentNode.ChildNodes.GetEnumerator();
        while (childNodesEnumerator.MoveNext()) {
            // Prints the Title of each node.
            Response.Write(childNodesEnumerator.Current.ToString() + "<br />");
        }
    }
    Response.Write("<hr />");

    // Examine the RootNode, and navigate the SiteMap relative to it.
    Response.Write(SiteMap.RootNode.Title + "<br />");
    Response.Write(SiteMap.RootNode.Url + "<br />");

    // What nodes are children of the RootNode?
    if (SiteMap.RootNode.HasChildNodes) {
        IEnumerator rootNodesChildrenEnumerator = SiteMap.RootNode.ChildNodes.GetEnumerator();
        while (rootNodesChildrenEnumerator.MoveNext()) {
            // Prints the Title of each node.
            Response.Write(rootNodesChildrenEnumerator.Current.ToString() + "<br />");
        }
    }
}
</script>