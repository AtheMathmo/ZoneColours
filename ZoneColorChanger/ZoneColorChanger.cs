﻿using ColossalFramework.UI;
using UnityEngine;
using UnifiedUI.Helpers;
using ColossalFramework;
using static RenderManager;

/* Zone Color Changer is a mod for Cities Skylines. 
 * 
 * Provides an option to change the colors of the rico zones.
 * With color issues some of the zoning colors might not be clearly 
 * visible or one does simply not like the color. 
 * 
 * This is a continuation of the Zone Colours mod by AtheMathmo.
 * In the original mod color pickers are attached to the zoning panel
 * and had alignment/wrapping issues, the colorfield always expanded
 * out of screen, I was not able to solve this issue. Even if it would be solved
 * more problem could come with ui resolution mods when hooking the zoning panel.
 * In the original mod, he color profile is only saved at OnLevelUnload. 
 * Instant return to desktop or a crash leads to lost color profile.
 * 
 * Because of lacking programming skills I took the easiest solution.
 * The mod now has a free floating UI Panel (which btw solves the random exception
 * issue where the mod tried to access the zoning panel before it is unlocked)
 * which can be toggled by a Keybind (set in mod option panel, default is Ctrl+K).
 * 
 * The UI has 6 color fields, on for every zone in the game's order.
 * 3 Buttons for save, load and reset. Save saves the current set color
 * profile in the "zone-color-changer.cfg" file, localappdata/ModConfig.
 * Load loads the profile from this file, reset resets the profile to 
 * the game default colors (but does not save it to the file).
 * 
 * Things could made much better in here, but the mod is functional.
 * The color of the zoning icon in the zoning panel does not change,
 * this would be a cool feature. Also it would be nice to have the color pickers
 * back in the zoning panel and icons for the buttons.
 * 
 * Contributions and suggestions welcome.
 * 
 */

namespace ZoneColorChanger {
	public class ZoneColorChanger : MonoBehaviour {

		private static ZoneColorChanger instance;

		public static ZoneColorChanger Instance {
			get {
				if (instance == null) {
					instance = GameObject.FindObjectOfType<ZoneColorChanger>();
				}
				return instance;
			}
		}

		void Awake() {
			DontDestroyOnLoad(gameObject);
		}

		private MainUIPanel mainUIPanel;

		private bool _keyProcessed = false;

		private UUICustomButton customButton;

		private const string settingsFileName = "ZoneColorChanger";
		
		public string SettingsFileName() {
			return settingsFileName;
		}

		public void Start() {
			Utils.LoadColors();

			UIView view = UIView.GetAView();
			mainUIPanel = view.AddUIComponent(typeof(MainUIPanel)) as MainUIPanel;
			AddUUIButton();
			if(!ModInfo.ShowUUIButton) {
				HideUUIButton();
			}
        }

		public void AddUUIButton() {
			string iconPath = UUIHelpers.GetFullPath<ModInfo>("Resources", "UUIButton.png"); // returns Path/To/Mod/Resources/UUIButton.png
			customButton = UUIHelpers.RegisterCustomButton(
				name: "ZCCUUIButton",
				groupName: null, // default group
				tooltip: "Zone Color Changer",
				icon: UUIHelpers.LoadTexture(iconPath),
				onToggle: (value) => ToggleUIPanelVisibility()
			);
			UpdateUUIButtonStatus(mainUIPanel.isVisible);
		}

		public void ShowUUIButton() {
			customButton.Button.Show();
		}

		public void HideUUIButton() {
			customButton.Button.Hide();
		}

		public void Update() {
			if(ModInfo.ToggleUIShortcut.IsPressed()) {
				// cancel if they key input was already processed in a previous frame
				if(_keyProcessed) return;

				_keyProcessed = true;
				
				UpdateUUIButtonStatus(ToggleUIPanelVisibility()); // updating UUI button status when using shortcut for open/close
			}
			else {
				// not both keys pressed: Reset processed state
				_keyProcessed = false;
			}
		}

		public void UpdateUUIButtonStatus() {
			customButton.IsPressed = mainUIPanel.isVisible;
		}

		public void UpdateUUIButtonStatus(bool isVisible) {
			customButton.IsPressed = isVisible;
		}

		public bool ToggleUIPanelVisibility() {
			return mainUIPanel.ToggleVisibility();
		}
	}
}
