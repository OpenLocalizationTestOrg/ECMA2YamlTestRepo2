        // Get the current EnableSessionState property value.
        Console.WriteLine(
            "Current EnableSessionState value: '{0}'",
            pagesSection.EnableSessionState);

        // Set the EnableSessionState property to
        // PagesEnableSessionState.ReadOnly.
        pagesSection.EnableSessionState =
            PagesEnableSessionState.ReadOnly;