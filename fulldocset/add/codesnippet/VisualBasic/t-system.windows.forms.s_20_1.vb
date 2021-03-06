
    Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar

    Private Sub InitializeStatusBarPanels()

        ' Create a StatusBar control.
        statusBar1 = New StatusBar

        ' Dock the status bar at the top of the form. 
        statusBar1.Dock = DockStyle.Top

        ' Set the SizingGrip property to false so the user cannot 
        ' resize the status bar.
        statusBar1.SizingGrip = False

        ' Create two StatusBarPanel objects to display in statusBar1.
        Dim panel1 As New StatusBarPanel
        Dim panel2 As New StatusBarPanel

        ' Set the width of panel2 explicitly and set
        ' panel1 to fill in the remaining space.
        panel2.Width = 80
        panel1.AutoSize = StatusBarPanelAutoSize.Spring

        ' Set the text alignment within each panel.
        panel1.Alignment = HorizontalAlignment.Left
        panel2.Alignment = HorizontalAlignment.Right

        ' Display the first panel without a border and the second
        ' with a raised border.
        panel1.BorderStyle = StatusBarPanelBorderStyle.None
        panel2.BorderStyle = StatusBarPanelBorderStyle.Raised

        ' Set the text of the panels. The panel1 object is reserved
        ' for line numbers, while panel2 is set to the current time.
        panel1.Text = "Reserved for important information."
        panel2.Text = System.DateTime.Now.ToShortTimeString

        ' Set a tooltip for panel2
        panel2.ToolTipText = "Click time to display seconds"

        ' Display panels in statusBar1 and add them to the
        ' status bar's StatusBarPanelCollection.
        statusBar1.ShowPanels = True
        statusBar1.Panels.Add(panel1)
        statusBar1.Panels.Add(panel2)

        ' Add the StatusBar to the form.
        Me.Controls.Add(statusBar1)
    End Sub


    ' If the user clicks the status bar, check the text of the 
    ' StatusBarPanel.  If the text equals a short time string,
    ' change it to long time display.
    Private Sub statusBar1_PanelClick(ByVal sender As Object, _
        ByVal e As StatusBarPanelClickEventArgs) _
            Handles statusBar1.PanelClick
        If (e.StatusBarPanel.Text = _
            System.DateTime.Now.ToShortTimeString) Then
            e.StatusBarPanel.Text = System.DateTime.Now.ToLongTimeString
        End If
    End Sub