Private Sub DataGridView1_CellPainting(sender as Object, e as DataGridViewCellPaintingEventArgs) _ 
     Handles DataGridView1.CellPainting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AdvancedBorderStyle", e.AdvancedBorderStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellPainting Event")

End Sub