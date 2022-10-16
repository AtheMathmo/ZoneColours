using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace ZoneColorChanger {
	public class ModInfo : IUserMod {
		public static readonly string Version = "0.2";

		public static string settingsFileName = "ZoneColorChanger";
		public static readonly SavedInputKey ToggleUIShortcut = new SavedInputKey("toggleUIShortcut", settingsFileName, SavedInputKey.Encode(KeyCode.K, true, false, false), true);

		public static readonly SettingsBool ShowUUIButton = new SettingsBool("Show UUI Button", "",  "showUUIButton", false);

		public static readonly Vector2 defaultPanelPosition = new Vector2(85, 10);
		public static readonly SavedInt savedPanelPositionX = new SavedInt("panelPositionX", settingsFileName, (int)defaultPanelPosition.x, true);
		public static readonly SavedInt savedPanelPositionY = new SavedInt("panelPositionY", settingsFileName, (int)defaultPanelPosition.y, true);

		public static bool _settingsFailed = false;

		public ModInfo() {
			try {
				// Creating setting file - from SamsamTS
				// only the toggle ui keybind is stored in his file. color profile is in ColorProfileConfigFile
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

		public string Name => "Zone Color Changer";

		public string Description => "change the color of each zone type"; 

		public void OnSettingsUI(UIHelperBase helper) {
			UIHelper group = helper.AddGroup(Name) as UIHelper;
			UIPanel panel = group.self as UIPanel;

			group.AddSpace(10);
			panel.gameObject.AddComponent<OptionsKeymapping>();
			group.AddSpace(10);
			ShowUUIButton.Draw(group, (b) => {
				//Debug.Log("Setting Show UUI Button is now " + ShowUUIButton.value);
				if(ShowUUIButton.value) {
					ZoneColorChanger.Instance.ShowUUIButton();
				}
				else {
					ZoneColorChanger.Instance.HideUUIButton();
				}
			});
		}
	}
}
