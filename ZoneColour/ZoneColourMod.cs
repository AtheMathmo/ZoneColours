using System;
using System.Collections;
using System.Collections.Generic;
using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColour
{
    public class ZoneColourMod : IUserMod
    {
        public string Name
        {
            get { return "Zone Color Changer"; }
        }

        public string Description
        {
            get { return "Allows zone color modification."; }
        }
    }
}
