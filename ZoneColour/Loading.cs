using System;
using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColour {
	public class Loading : LoadingExtensionBase {

		private GameObject zoneColoursRevisitedGameObject;

		public override void OnLevelLoaded(LoadMode mode) {
			try {
				zoneColoursRevisitedGameObject = new GameObject("Manager");
				zoneColoursRevisitedGameObject.AddComponent<ZoneColourRevisited>();
			}

			catch(Exception e) {
				Debug.Log("[ZoneColoursRevisited] Loading:OnLevelLoaded -> Exception: " + e.Message);
			}
		}

		public override void OnLevelUnloading() {
			Utils.SaveColors();
		}
	}
}
