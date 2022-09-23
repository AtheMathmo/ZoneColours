using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace ZoneColour {
	public class ZoneColourMod : IUserMod {
		public const string settingsFileName = "ZoneColoursVisited";
		public static readonly SavedInputKey ToggleUIShortcut = new SavedInputKey("toggleUIShortcut", settingsFileName, SavedInputKey.Encode(KeyCode.O, true, false, false), true);

		public static bool _settingsFailed = false;

		public ZoneColourMod() {
			try {
				// Creating setting file - from SamsamTS
				if(GameSettings.FindSettingsFileByName(settingsFileName) == null) {
					GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = settingsFileName } });
				}
			}
			catch(Exception e) {
				_settingsFailed = true;
				Debug.Log("Couldn't load/create the setting file.");
				Debug.LogException(e);
			}
		}

		public string Name {
			get { return "Zone Colours Revisited"; }
		}

		public string Description {
			get { return "Allows zone colour modification."; }
		}

		public void OnSettingsUI(UIHelperBase helper) {
			UIHelper group = helper.AddGroup(Name) as UIHelper;
			UIPanel panel = group.self as UIPanel;

			group.AddSpace(10);
			panel.gameObject.AddComponent<OptionsKeymapping>(); // 
			group.AddSpace(10);
		}
	}
}
