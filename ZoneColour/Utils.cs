using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ColossalFramework.IO;
using ColossalFramework.Math;
using ColossalFramework.Threading;
using ICities;
using UnityEngine;

namespace ZoneColour
{
    class Utils
    {
        /*  Unzoned,
	            Distant,
	            ResidentialLow,
	            ResidentialHigh,
	            CommercialLow,
	            CommercialHigh,
	            Industrial,
	            Office,
             */
        public static void SetZoneColour(Color colour, int index)
        {
            Singleton<ZoneManager>.instance.m_properties.m_zoneColors[index] = colour;
            Shader.SetGlobalColor("_ZoneColor" + index, colour.linear);
        }

        public static bool SetZoneColours(Color[] colours)
        {
            int coloursLength = colours.Length;
            if (coloursLength != 8)
                return false;

            for (int i = 0; i < coloursLength; i++)
            {
                Singleton<ZoneManager>.instance.m_properties.m_zoneColors[i] = colours[i];
                Shader.SetGlobalColor("_ZoneColor" + i, colours[i].linear);
            }
            return true;
        }
    }
}
