using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ICities;
using UnityEngine;
using System.ComponentModel;
using System.Xml.Linq;


namespace ZoneColour
{
	public class ZoneColourLoader : LoadingExtensionBase {

		private GameObject mainUIPanelGameObject;
		private GameObject managerGameObject;
	
		//private UIDragHandle _dragHandle;
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









/*			ZoningPanel zoningPanel = GameObject.FindObjectOfType<ZoningPanel>();
			UIPanel container = zoningPanel.GetComponentInChildren<UIPanel>();*/

	 //	   UIView view = UIView.GetAView();
			//ZCMainUIPanel panel = view.AddUIComponent(typeof(ZCMainUIPanel)) as ZCMainUIPanel;
			//panel.transform.parent = view.transform;
			/*			UIPanel panel = view.AddUIComponent(typeof(UIPanel)) as UIPanel;
						panel.name = "MyUIPanel";
						panel.backgroundSprite = "GenericPanel";
						panel.width = 360;
						panel.height = 56;
						_dragHandle = (UIDragHandle)panel.AddUIComponent(typeof(UIDragHandle));*/
			//AddZoneColorPickers(panel);
		//AddZoneColorPickers(container);


		try {
			managerGameObject = new GameObject("Manager");
			managerGameObject.AddComponent<ZCManager>();

			UIView view = UIView.GetAView();
			//UIView uiView = UnityEngine.Object.FindObjectOfType<UIView>();

			if(view != null) {
				mainUIPanelGameObject = new GameObject("MainUIPanel");
				mainUIPanelGameObject.transform.parent = view.transform;
				mainUIPanelGameObject.AddComponent<ZCMainUIPanel>(); 
			}
			   
		}

		catch(Exception e) {
			Debug.Log("[ZoneColourRevisited] Loading:OnLevelLoaded -> Exception: " + e.Message);
		}

		   // AddZoneColorPickers(mainUIPanelGameObject);


		}

		public override void OnLevelUnloading()
		{
			ZCConfig.SavedColours = Singleton<ZoneManager>.instance.m_properties.m_zoneColors;
			ZCConfig.SaveColours();
		}

		private void AddZoneColorPickers(UIPanel container)
		{
			int spriteWidth = 50;

			int xPos = 10;
			int yPos = 8;
			ZoneColourPanel lowResColourPanel = container.AddUIComponent<ZoneColourPanel>();
			lowResColourPanel.transform.parent = container.transform;
			lowResColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowResColourPanel.ChosenColour = 2;

			xPos += spriteWidth;

			ZoneColourPanel highResColourPanel = container.AddUIComponent<ZoneColourPanel>();
			highResColourPanel.transform.parent = container.transform;
			highResColourPanel.relativePosition = new Vector3(xPos, yPos);
			highResColourPanel.ChosenColour = 3;

			xPos += spriteWidth;

			ZoneColourPanel lowComColourPanel = container.AddUIComponent<ZoneColourPanel>();
			lowComColourPanel.transform.parent = container.transform;
			lowComColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowComColourPanel.ChosenColour = 4;

			xPos += spriteWidth;

			ZoneColourPanel highComColourPanel = container.AddUIComponent<ZoneColourPanel>();
			highComColourPanel.transform.parent = container.transform;
			highComColourPanel.relativePosition = new Vector3(xPos, yPos);
			highComColourPanel.ChosenColour = 5;

			xPos += spriteWidth;

			ZoneColourPanel IndColourPanel = container.AddUIComponent<ZoneColourPanel>();
			IndColourPanel.transform.parent = container.transform;
			IndColourPanel.relativePosition = new Vector3(xPos, yPos);
			IndColourPanel.ChosenColour = 6;

			xPos += spriteWidth;

			ZoneColourPanel OfficeColourPanel = container.AddUIComponent<ZoneColourPanel>();
			OfficeColourPanel.transform.parent = container.transform;
			OfficeColourPanel.relativePosition = new Vector3(xPos, yPos);
			OfficeColourPanel.ChosenColour = 7;

			xPos += spriteWidth;
			UIButton saveButton = CreateButton(container);
			saveButton.transform.parent = container.transform;
			saveButton.relativePosition = new Vector3(xPos, yPos+4);
		}
		public static UIButton CreateButton(UIComponent parent) {
			UIButton button = (UIButton)parent.AddUIComponent<UIButton>();

			//button.atlas = GetAtlas("Ingame");

			button.width = 37;
			button.height = 31;
			//button.size = new Vector2(30f, 30f);
			button.textScale = 0.9f;
			button.normalBgSprite = "ButtonMenu";
			button.hoveredBgSprite = "ButtonMenuHovered";
			button.pressedBgSprite = "ButtonMenuPressed";
			button.canFocus = false;

			return button;
		}
	}





}
