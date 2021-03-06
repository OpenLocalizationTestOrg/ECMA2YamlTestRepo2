   Private Sub CreateMyStatusBar()
      ' Create a StatusBar control.
      Dim statusBar1 As New StatusBar()

      ' Create two StatusBarPanel objects to display in the StatusBar.
      Dim panel1 As New StatusBarPanel()
      Dim panel2 As New StatusBarPanel()

      ' Display the first panel with a sunken border style.
      panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken

      ' Initialize the text of the panel.
      panel1.Text = "Ready..."

      ' Set the AutoSize property to use all remaining space on the StatusBar.
      panel1.AutoSize = StatusBarPanelAutoSize.Spring
      
      ' Display the second panel with a raised border style.
      panel2.BorderStyle = StatusBarPanelBorderStyle.Raised
      
      ' Create ToolTip text that displays the time the application was started.
      panel2.ToolTipText = "Started: " & System.DateTime.Now.ToShortTimeString()

      ' Set the text of the panel to the current date.
      panel2.Text = System.DateTime.Today.ToLongDateString()

      ' Set the AutoSize property to size the panel to the size of the contents.
      panel2.AutoSize = StatusBarPanelAutoSize.Contents

      ' Display panels in the StatusBar control.
      statusBar1.ShowPanels = True

      ' Add both panels to the StatusBarPanelCollection of the StatusBar.			
      statusBar1.Panels.Add(panel1)
      statusBar1.Panels.Add(panel2)

      ' Add the StatusBar to the form.
      Me.Controls.Add(statusBar1)
   End Sub