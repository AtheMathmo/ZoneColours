using System;
using System.IO;
using ColossalFramework;
using ColossalFramework.IO;
using UnityEngine;

namespace ZoneColorChanger {
	class ColorProfileConfigFile {
		/* This class is from the original Zone Colours Mod
		 * The current zone color profile ist stored in this config file
		 * in localappdata/ModConfig/
		 * Maybe it would be a good idea to store the colors
		 * together with the keybind option setting. 
		 */

		private static string filename = "zone-color-changer.cfg";
		private static Color[] savedColors;

		public static Color[] SavedColors {
			get { return savedColors; }
			set { savedColors = value; }
		}

		// Credit: https://github.com/MrLawbreaker
		private static string ConfigPath {
			get {
				string path = string.Format("{0}/{1}/", DataLocation.localApplicationData, "ModConfig");

				if (!Directory.Exists(path)) 
					Directory.CreateDirectory(path);

				path += filename;

				return path;
			}
		}

		private static string[] ConfigLines {
			get {
				if (File.Exists(ConfigPath)) {
					return File.ReadAllLines(ConfigPath);
				}
				else {
					savedColors = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
					using (StreamWriter sw = new StreamWriter(ConfigPath)) {
						sw.WriteLine("Zone Color Changer Color Profile");
						sw.WriteLine();
						foreach(Color color in savedColors) {
							sw.WriteLine(String.Format("{0},{1},{2},{3}", color.r, color.g, color.b, color.a));
						}
					}
					return File.ReadAllLines(ConfigPath);
				}
			}
		}

		public static bool LoadSavedColors() {
			string[] configLines = ConfigLines;

			savedColors = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			int savedColorIndex = 0;

			for (int i = 0; i < configLines.Length; i++) {
				string line = configLines[i].Trim();
				string[] data = line.Split(',');

				if (data.Length != 4) {
					continue;
				}

				float[] colorArray = new float[4];

				for (int j = 0; j < 4; j++) {
					// Check if valid, break out if not
					if (!float.TryParse(data[j], out colorArray[j])) {
						Debug.Log("Invalid config found. Default values used.");
						return false;
					}
				}
				savedColors[savedColorIndex++] = new Color(colorArray[0], colorArray[1], colorArray[2], colorArray[3]);
			}

			if (savedColorIndex != 8) {
				Debug.Log("Invalid config found. Default values used.");
				return false; 
			}
			return true;
		}

		public static bool SaveColors() {
			try {
				using (StreamWriter sw = new StreamWriter(ConfigPath)) {
					sw.WriteLine("Zone Color Changer Color Profile");
					sw.WriteLine();
					foreach (Color color in savedColors) {
						sw.WriteLine(String.Format("{0},{1},{2},{3}", color.r, color.g, color.b, color.a));
					}
				}
				return true;
			}
			catch {
				return false;
			}
		}
	}
}
