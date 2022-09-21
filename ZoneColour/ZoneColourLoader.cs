using System;
using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColour {
	public class ZoneColourLoader : LoadingExtensionBase {

		private GameObject mainUIPanelGameObject;
		private GameObject managerGameObject;

		public override void OnLevelLoaded(LoadMode mode) {
			//ZoneColourTrigger.DefaultColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors; // doesn't always work, no idea why
																										  // values are now hardcoded where used
			if(ZCConfig.LoadSavedColours()) {
				bool success = Utils.SetZoneColours(ZCConfig.SavedColours);

				if(success) {
					Debug.Log("Saved colors successfully applied.");
				}
				else {
					Debug.Log("Saved colors failed to apply.");
				}
			}

			/*			
						// color pickers back in the zoning panel like in 
						// the original Zone Colours mod would be cool
						// but they always expand to the bottom in there,
						// half of it is out of screen. It seems the
						// color fields do not want to expand above the
						// upper zoning panel border and I could not 
						// figure out how to fix it. Suggestions welcome. 

						ZoningPanel zoningPanel = GameObject.FindObjectOfType<ZoningPanel>();
						UIPanel container = zoningPanel.GetComponentInChildren<UIPanel>();
						AddZoneColorPickers(container); // is now in the panel class
			*/

			try {
				managerGameObject = new GameObject("Manager");
				managerGameObject.AddComponent<ZCManager>();

				UIView view = UIView.GetAView();

				if(view != null) {
					mainUIPanelGameObject = new GameObject("MainUIPanel");
					mainUIPanelGameObject.transform.parent = view.transform;
					mainUIPanelGameObject.AddComponent<ZCMainUIPanel>();
				}
			}

			catch(Exception e) {
				Debug.Log("[ZoneColorChanger] Loading:OnLevelLoaded -> Exception: " + e.Message);
			}
		}

		public override void OnLevelUnloading() {
			ZCConfig.SavedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			ZCConfig.SaveColours();
		}
	}
}
