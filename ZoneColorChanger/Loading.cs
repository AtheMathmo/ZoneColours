using System;
using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColorChanger {
	public class Loading : LoadingExtensionBase {

		private GameObject zoneColorsChangerGameObject;

		public override void OnLevelLoaded(LoadMode mode) {
			try {
				zoneColorsChangerGameObject = new GameObject("Manager");
				zoneColorsChangerGameObject.AddComponent<ZoneColorChanger>();
			}

			catch(Exception e) {
				Debug.Log("[ZoneColorChanger] Loading:OnLevelLoaded -> Exception: " + e.Message);
			}
		}

		public override void OnLevelUnloading() {
			Utils.SaveColors();
		}
	}
}
