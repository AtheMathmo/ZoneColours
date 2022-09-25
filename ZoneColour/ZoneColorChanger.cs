using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.ComponentModel;
using UnityEngine;

namespace ZoneColorChanger {
	public class ZoneColorChanger : MonoBehaviour {

		private MainUIPanel mainUIPanel;

		private bool _keyProcessed = false;
		
		public void Start() {
			Utils.LoadColors();

			UIView view = UIView.GetAView();
			mainUIPanel = view.AddUIComponent(typeof(MainUIPanel)) as MainUIPanel;
		}

		public void Update() {
			if(ModInfo.ToggleUIShortcut.IsPressed()) {
				// cancel if they key input was already processed in a previous frame
				if(_keyProcessed) return;

				_keyProcessed = true;
				ToggleUIPanelVisibility();
			}
			else {
				// not both keys pressed: Reset processed state
				_keyProcessed = false;
			}
		}

		public void ToggleUIPanelVisibility() {
			mainUIPanel.ToggleVisibility();
		}
	}
}
