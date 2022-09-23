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

namespace ZoneColour {
	class Utils {
		/*  
			Unzoned,
			Distant,
			ResidentialLow,
			ResidentialHigh,
			CommercialLow,
			CommercialHigh,
			Industrial,
			Office,
		*/

		private static Color[] defaultColours; 

		public static void Init() {

		}

		public static void SetZoneColour(Color colour, int index) {
			Singleton<ZoneManager>.instance.m_properties.m_zoneColors[index] = colour;
			Shader.SetGlobalColor("_ZoneColor" + index, colour.linear);
		}

		public static bool SetZoneColours(Color[] colours) {
			Debug.Log("SetZoneColours");
			int coloursLength = colours.Length;
			if (coloursLength != 8) {
				return false;
			}

			for (int i = 0; i < coloursLength; i++) {
				Singleton<ZoneManager>.instance.m_properties.m_zoneColors[i] = colours[i];
				Shader.SetGlobalColor("_ZoneColor" + i, colours[i].linear);
				Debug.Log(colours[i]);
				Debug.Log(colours[i].linear);
			}
			return true;
		}

		public static void ResetToDefaultColors() {
			// ZoneColourTrigger.Defaultcolours didn't always work, no idea why. Hardcoded default colors should work
			// as long as they stay the same in the game

			Debug.Log("reset to default colours");
			defaultColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;

			defaultColours[0] = new Color(1f, 1f, 1f, 0.01568628f);
			defaultColours[1] = new Color(1f, 1f, 1f, 0.003921569f);
			defaultColours[2] = new Color(0.2745098f, 0.627451f, 0.2117647f, 1f);
			defaultColours[3] = new Color(0, 0.3014706f, 0.2016734f, 1f);
			defaultColours[4] = new Color(0, 0.5529412f, 0.8666667f, 1f);
			defaultColours[5] = new Color(0, 0.2588235f, 0.5686275f, 1f);
			defaultColours[6] = new Color(0.9372549f, 0.7116971f, 0.1333333f, 1f);
			defaultColours[7] = new Color(0, 0.9090365f, 0.9485294f, 1f);

			SetZoneColours(defaultColours);
		}

		public static void SaveColors() {
			Debug.Log("saving colours...");
			ZCConfig.SavedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			ZCConfig.SaveColours();
		}

		public static void LoadColors() {
			if(ZCConfig.LoadSavedColours()) {
				bool success = SetZoneColours(ZCConfig.SavedColours);

				if(success) {
					Debug.Log("Saved colours successfully applied.");
				}
				else {
					Debug.Log("Saved colours failed to apply.");
				}
			}
		}

		public static void ToggleUIPanelVisibility() {
			Debug.Log("utils toggle ui");
		}
	}
}
