                    ' Get the roleManager section.
                    Dim roleManager _
                    As RoleManagerSection = _
                    systemWeb.RoleManager
                    ' Read section information.
                    info = roleManager.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
