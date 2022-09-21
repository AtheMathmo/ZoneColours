using ColossalFramework;
using ICities;
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
            if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.I)) {
                // cancel if they key input was already processed in a previous frame
                if(_keyProcessed) return;

                _keyProcessed = true;
                ToggleUIPanelVisibility();
                Debug.Log("Keyboard: Strg+I");
            }
            else {
                // not both keys pressed: Reset processed state
                _keyProcessed = false;
            }
        }

        public void ToggleUIPanelVisibility() {
            mainUIPanelGameObject.ToggleVisibility();
        }

        public void SaveColors() {
            Debug.Log("saving colours...");
            ZCConfig.SavedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
            ZCConfig.SaveColours();
        }

        public void LoadColors() {
            if(ZCConfig.LoadSavedColours()) {
                bool success = Utils.SetZoneColours(ZCConfig.SavedColours);

                if(success) {
                    Debug.Log("Saved colours successfully applied.");
                }
                else {
                    Debug.Log("Saved colours failed to apply.");
                }
            }
        }

        public void ResetColors() {
            //bool success = Utils.SetZoneColours(ZoneColourTrigger.DefaultColours);

            Utils.ResetToDefaultColors();
            
        }



    }
}
