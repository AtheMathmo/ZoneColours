using ColossalFramework;
using System;
using UnityEngine;

namespace ZoneColour {
	public class ZCManager : MonoBehaviour {

		private ZCMainUIPanel mainUIPanelGameObject;

		private bool _keyProcessed = false;

		public void Start() {
			try {
				if(mainUIPanelGameObject == null) {
					mainUIPanelGameObject = GameObject.Find("MainUIPanel")?.GetComponent<ZCMainUIPanel>();
				}
			}
			catch(Exception e) {
				Debug.Log("[ZoneColour] ZCManager:Start -> Exception: " + e.Message);
			}
		}

		public void Update() {
			
			if(ZoneColourMod.ToggleUIShortcut.IsPressed()) {
				// cancel if they key input was already processed in a previous frame
				if(_keyProcessed) return;

				_keyProcessed = true;
				ToggleUIPanelVisibility();
				Debug.Log("Keyboard: Strg+K");
			}
			else {
				// not both keys pressed: Reset processed state
				_keyProcessed = false;
			}
		}

		public void ToggleUIPanelVisibility() {
			mainUIPanelGameObject.ToggleVisibility();
		}
	}
}
