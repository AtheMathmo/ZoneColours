using ColossalFramework;
using UnityEngine;

namespace ZoneColorChanger {
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

		private static Color[] defaultColors;

		public static void Init() {
		
		}

		public static void SetZoneColor(Color color, int index) {
			Singleton<ZoneManager>.instance.m_properties.m_zoneColors[index] = color;
			Shader.SetGlobalColor("_ZoneColor" + index, color.linear);
		}

		public static bool SetZoneColors(Color[] colors) {
			int colorsLength = colors.Length;
			if (colorsLength != 8) {
				return false;
			}

			for (int i = 0; i < colorsLength; i++) {
				Singleton<ZoneManager>.instance.m_properties.m_zoneColors[i] = colors[i];
				Shader.SetGlobalColor("_ZoneColor" + i, colors[i].linear);
			}
			return true;
		}

		public static void ResetToDefaultColors() {
			// ZoneColourTrigger.Defaultcolours didn't always work, no idea why. Hardcoded default colors should work
			// as long as they stay the same in the game. 

			Debug.Log("reset to default colors...");
			defaultColors = Singleton<ZoneManager>.instance.m_properties.m_zoneColors; // I don't understand this, without it doesn't work
																						

			defaultColors[0] = new Color(1f, 1f, 1f, 0.01568628f);
			defaultColors[1] = new Color(1f, 1f, 1f, 0.003921569f);
			defaultColors[2] = new Color(0.2745098f, 0.627451f, 0.2117647f, 1f);
			defaultColors[3] = new Color(0, 0.3014706f, 0.2016734f, 1f);
			defaultColors[4] = new Color(0, 0.5529412f, 0.8666667f, 1f);
			defaultColors[5] = new Color(0, 0.2588235f, 0.5686275f, 1f);
			defaultColors[6] = new Color(0.9372549f, 0.7116971f, 0.1333333f, 1f);
			defaultColors[7] = new Color(0, 0.9090365f, 0.9485294f, 1f);

			SetZoneColors(defaultColors);
		}

		public static void SaveColors() {
			Debug.Log("saving colors...");
			ColorProfileConfigFile.SavedColors = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			ColorProfileConfigFile.SaveColors();
		}

		public static void LoadColors() {
			if(ColorProfileConfigFile.LoadSavedColors()) {
				bool success = SetZoneColors(ColorProfileConfigFile.SavedColors);

				if(success) {
					Debug.Log("Saved colors successfully applied.");
				}
				else {
					Debug.Log("Saved colors failed to apply.");
				}
			}
		}
	}
}
