﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.SetupTool.Models;

public class Commands
{
    public string Alias { get; set; }
    public List<string> AvailableCommands { get; set; }
}
