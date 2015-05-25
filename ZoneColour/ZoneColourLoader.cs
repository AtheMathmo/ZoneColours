using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColour
{
    public class ZoneColourLoader : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            ZoneColourTrigger.DefaultColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;

            if (ZCConfig.LoadSavedColours())
            {
                
                bool success = Utils.SetZoneColours(ZCConfig.SavedColours);

                if (success)
                {
                    Debug.Log("Saved colours successfully applied.");
                }
                else
                {
                    Debug.Log("Saved colours failed to apply.");
                }
            }

            ZoningPanel zoningPanel = GameObject.FindObjectOfType<ZoningPanel>();
            UIPanel container = zoningPanel.GetComponentInChildren<UIPanel>();

            AddZoneColorPickers(container);
            

        }

        public override void OnLevelUnloading()
        {
            ZCConfig.SavedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
            ZCConfig.SaveColours();
        }

        private void AddZoneColorPickers(UIPanel container)
        {
            int spriteWidth = 109;

            int xPos = 50;
            ZoneColourPanel lowResColourPanel = container.AddUIComponent<ZoneColourPanel>();
            lowResColourPanel.transform.parent = container.transform;
            lowResColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            lowResColourPanel.ChosenColour = 2;

            xPos += spriteWidth;

            ZoneColourPanel highResColourPanel = container.AddUIComponent<ZoneColourPanel>();
            highResColourPanel.transform.parent = container.transform;
            highResColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            highResColourPanel.ChosenColour = 3;

            xPos += spriteWidth;

            ZoneColourPanel lowComColourPanel = container.AddUIComponent<ZoneColourPanel>();
            lowComColourPanel.transform.parent = container.transform;
            lowComColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            lowComColourPanel.ChosenColour = 4;

            xPos += spriteWidth;

            ZoneColourPanel highComColourPanel = container.AddUIComponent<ZoneColourPanel>();
            highComColourPanel.transform.parent = container.transform;
            highComColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            highComColourPanel.ChosenColour = 5;

            xPos += spriteWidth;

            ZoneColourPanel IndColourPanel = container.AddUIComponent<ZoneColourPanel>();
            IndColourPanel.transform.parent = container.transform;
            IndColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            IndColourPanel.ChosenColour = 6;

            xPos += spriteWidth;

            ZoneColourPanel OfficeColourPanel = container.AddUIComponent<ZoneColourPanel>();
            OfficeColourPanel.transform.parent = container.transform;
            OfficeColourPanel.relativePosition = new Vector3(xPos + 50, 10);
            OfficeColourPanel.ChosenColour = 7;
        }
    }
}
