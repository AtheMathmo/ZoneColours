using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
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
	class ZCConfig
	{
		private static Color[] savedColours;

		public static Color[] SavedColours
		{
			get { return savedColours; }
			set { savedColours = value; }
		}

		// Credit: https://github.com/MrLawbreaker
		private static string ConfigPath
		{
			get
			{
				string path = string.Format("{0}/{1}/", DataLocation.localApplicationData, "ModConfig");

				if (!Directory.Exists(path)) 
					Directory.CreateDirectory(path);

				path += "zone-colours.cfg";

				return path;
			}
		}

		private static string[] ConfigLines
		{
			get
			{
				if (File.Exists(ConfigPath))
				{
					return File.ReadAllLines(ConfigPath);
				}
				else
				{
					savedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
					using (StreamWriter sw = new StreamWriter(ConfigPath))
					{
						sw.WriteLine("Zone Colours Config");
						sw.WriteLine();
						foreach(Color colour in savedColours)
						{
							sw.WriteLine(String.Format("{0},{1},{2},{3}", colour.r, colour.g, colour.b, colour.a));
						}
					}
					return File.ReadAllLines(ConfigPath);
				}
			}
		}

		public static bool LoadSavedColours()
		{
			string[] configLines = ConfigLines;

			savedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			int savedColourIndex = 0;

			for (int i = 0; i < configLines.Length; i++)
			{
				string line = configLines[i].Trim();
				string[] data = line.Split(',');

				if (data.Length != 4)
				{
					continue;
				}

				float[] colourArray = new float[4];

				for (int j = 0; j < 4; j++)
				{
					// Check if valid, break out if not
					if (!float.TryParse(data[j], out colourArray[j]))
					{
						Debug.Log("Invalid config found. Default values used.");
						return false;
					}
				}
				savedColours[savedColourIndex++] = new Color(colourArray[0], colourArray[1], colourArray[2], colourArray[3]);
			}

			if (savedColourIndex != 8)
			{
				Debug.Log("Invalid config found. Default values used.");
				return false;
			}
			return true;
		}

		public static bool SaveColours()
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(ConfigPath))
				{
					sw.WriteLine("Zone Colours Config");
					sw.WriteLine();
					foreach (Color colour in savedColours)
					{
						sw.WriteLine(String.Format("{0},{1},{2},{3}", colour.r, colour.g, colour.b, colour.a));
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
			
		}
	}
}
