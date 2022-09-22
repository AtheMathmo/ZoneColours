using ColossalFramework.UI;
using System;
using UnityEngine;

namespace ZoneColour {
	public class ZCMainUIPanel : UIPanel{
		private UIDragHandle _dragHandle;

		private ZCManager manager;

		ZoneColourPanel lowResColourPanel;
		ZoneColourPanel highResColourPanel;
		ZoneColourPanel lowComColourPanel;
		ZoneColourPanel highComColourPanel;
		ZoneColourPanel IndColourPanel;
		ZoneColourPanel OfficeColourPanel;

		public override void Start() {
			base.Start();

			try {
				if(manager == null) {
					manager = GameObject.Find("Manager")?.GetComponent<ZCManager>();
				}
			}
			catch(Exception e) {
				Debug.Log("[ZoneColoursRevisited] ZCMainUIPanel:Start -> Exception: " + e.Message);
			}

			this.backgroundSprite = "GenericPanel";
			this.width = 487;
			this.height = 56;
			_dragHandle = (UIDragHandle)this.AddUIComponent(typeof(UIDragHandle));


			AddZoneColorPickers(this);
			this.Hide();
		}

		private void AddZoneColorPickers(UIPanel container) {
			int spriteWidth = 50;

			int xPos = 10;
			int yPos = 8;
			lowResColourPanel = container.AddUIComponent<ZoneColourPanel>();
			lowResColourPanel.transform.parent = container.transform;
			lowResColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowResColourPanel.ChosenColour = 2;

			xPos += spriteWidth;

			highResColourPanel = container.AddUIComponent<ZoneColourPanel>();
			highResColourPanel.transform.parent = container.transform;
			highResColourPanel.relativePosition = new Vector3(xPos, yPos);
			highResColourPanel.ChosenColour = 3;

			xPos += spriteWidth;

			lowComColourPanel = container.AddUIComponent<ZoneColourPanel>();
			lowComColourPanel.transform.parent = container.transform;
			lowComColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowComColourPanel.ChosenColour = 4;

			xPos += spriteWidth;

			highComColourPanel = container.AddUIComponent<ZoneColourPanel>();
			highComColourPanel.transform.parent = container.transform;
			highComColourPanel.relativePosition = new Vector3(xPos, yPos);
			highComColourPanel.ChosenColour = 5;

			xPos += spriteWidth;

			IndColourPanel = container.AddUIComponent<ZoneColourPanel>();
			IndColourPanel.transform.parent = container.transform;
			IndColourPanel.relativePosition = new Vector3(xPos, yPos);
			IndColourPanel.ChosenColour = 6;

			xPos += spriteWidth;

			OfficeColourPanel = container.AddUIComponent<ZoneColourPanel>();
			OfficeColourPanel.transform.parent = container.transform;
			OfficeColourPanel.relativePosition = new Vector3(xPos, yPos);
			OfficeColourPanel.ChosenColour = 7;

			xPos += spriteWidth;

			UIButton saveButton = CreateButton(container);
			saveButton.transform.parent = container.transform;
			saveButton.relativePosition = new Vector3(xPos, yPos + 4);
			saveButton.text = "SAVE";
			saveButton.eventClick += saveButtonClick;
			saveButton.textScale = 0.85f;

			xPos += spriteWidth+8;

			UIButton loadButton = CreateButton(container);
			loadButton.transform.parent = container.transform;
			loadButton.relativePosition = new Vector3(xPos, yPos + 4);
			loadButton.text = "LOAD";
			loadButton.eventClick += loadButtonClick;
			loadButton.textScale = 0.85f;

			xPos += spriteWidth+8;

			UIButton resetButton = CreateButton(container);
			resetButton.transform.parent = container.transform;
			resetButton.relativePosition = new Vector3(xPos, yPos + 4);
			resetButton.text = "RESET";
			resetButton.eventClick += resetButtonClick;
			resetButton.textScale = 0.85f;
		}

		public static UIButton CreateButton(UIComponent parent) { // thanks SamsamTS
			UIButton button = (UIButton)parent.AddUIComponent<UIButton>();
			button.width = 50;
			button.height = 31;
			button.textScale = 0.9f;
			button.normalBgSprite = "ButtonMenu";
			button.hoveredBgSprite = "ButtonMenuHovered";
			button.pressedBgSprite = "ButtonMenuPressed";
			button.canFocus = false;

			return button;
		}

		public void saveButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Debug.Log("save Button Click");
			Utils.SaveColors();
		}

		public void loadButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Debug.Log("load Button Click");
			Utils.LoadColors();
			ShowCurrentZoneColorsInColorPickers();
		}

		public void resetButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Debug.Log("reset Button Click");
			Utils.ResetToDefaultColors();
			ShowCurrentZoneColorsInColorPickers();
		}

		public void ToggleVisibility() {
			if(isVisible) {
				Hide();
				Debug.Log("show panel: " + isVisible);
			}
			else {
				Show();
				Debug.Log("show panel: " + isVisible);
			}
		}

		private void ShowCurrentZoneColorsInColorPickers() { 
			lowResColourPanel.UpdateCurrentZoneColor();
			highResColourPanel.UpdateCurrentZoneColor();
			lowComColourPanel.UpdateCurrentZoneColor();
			highComColourPanel.UpdateCurrentZoneColor();
			IndColourPanel.UpdateCurrentZoneColor();
			OfficeColourPanel.UpdateCurrentZoneColor();
		}
	}
}
