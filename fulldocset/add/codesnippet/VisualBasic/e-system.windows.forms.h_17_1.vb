Private Sub HtmlElement1_MouseUp(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub