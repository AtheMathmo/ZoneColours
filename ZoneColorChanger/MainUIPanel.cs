using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

namespace ZoneColorChanger {
	public class MainUIPanel : UIPanel {

		private UIDragHandle dragHandle;

		ColorPickerPanel lowResColorPanel;
		ColorPickerPanel highResColorPanel;
		ColorPickerPanel lowComColorPanel;
		ColorPickerPanel highComColorPanel;
		ColorPickerPanel indColorPanel;
		ColorPickerPanel officeColorPanel;

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

		public override void Start() {
			isVisible = false;

			absolutePosition = new Vector3(ModInfo.savedPanelPositionX.value, ModInfo.savedPanelPositionY.value);

			eventPositionChanged += (c, p) => { // again thanks Roundabout Builder
				if (absolutePosition.x < 0)
					absolutePosition = ModInfo.defaultPanelPosition;

				Vector2 resolution = GetUIView().GetScreenResolution();

				absolutePosition = new Vector2(
					Mathf.Clamp(absolutePosition.x, 0, resolution.x - width),
					Mathf.Clamp(absolutePosition.y, 0, resolution.y - height));

				ModInfo.savedPanelPositionX.value = (int)absolutePosition.x;
				ModInfo.savedPanelPositionY.value = (int)absolutePosition.y;
			};


			dragHandle = (UIDragHandle)this.AddUIComponent(typeof(UIDragHandle));

			this.backgroundSprite = "GenericPanel";
			this.width = 488;
			this.height = 56;

			AddZoneColorPickers(this);
			AddCloseButton(this);
			this.Hide();
		}

		private void AddCloseButton(UIPanel container) {
			var width = 12;
			var height = 12;
			var border_margin = 2; // button is anchored top right
			int xPos = (int)(container.width - width - border_margin);
			int yPos = border_margin;
			UIButton closeButton = CreateButton(container, width, height);
			closeButton.text = "x";
			closeButton.textScale = 0.7f;
			//UIButton closeButton = container.AddUIComponent<CloseButton>();
			closeButton.transform.parent = container.transform;
			
			closeButton.relativePosition = new Vector3(xPos, yPos);
            closeButton.eventClick += CloseButtonClick;
        }

		private void AddZoneColorPickers(UIPanel container) {
			int spriteWidth = 50;

			int xPos = 10;
			int yPos = 8;
			lowResColorPanel = container.AddUIComponent<ColorPickerPanel>();
			lowResColorPanel.transform.parent = container.transform;
			lowResColorPanel.relativePosition = new Vector3(xPos, yPos);
			lowResColorPanel.ChosenColor = 2;

			xPos += spriteWidth;

			highResColorPanel = container.AddUIComponent<ColorPickerPanel>();
			highResColorPanel.transform.parent = container.transform;
			highResColorPanel.relativePosition = new Vector3(xPos, yPos);
			highResColorPanel.ChosenColor = 3;

			xPos += spriteWidth;

			lowComColorPanel = container.AddUIComponent<ColorPickerPanel>();
			lowComColorPanel.transform.parent = container.transform;
			lowComColorPanel.relativePosition = new Vector3(xPos, yPos);
			lowComColorPanel.ChosenColor = 4;

			xPos += spriteWidth;

			highComColorPanel = container.AddUIComponent<ColorPickerPanel>();
			highComColorPanel.transform.parent = container.transform;
			highComColorPanel.relativePosition = new Vector3(xPos, yPos);
			highComColorPanel.ChosenColor = 5;

			xPos += spriteWidth;

			indColorPanel = container.AddUIComponent<ColorPickerPanel>();
			indColorPanel.transform.parent = container.transform;
			indColorPanel.relativePosition = new Vector3(xPos, yPos);
			indColorPanel.ChosenColor = 6;

			xPos += spriteWidth;

			officeColorPanel = container.AddUIComponent<ColorPickerPanel>();
			officeColorPanel.transform.parent = container.transform;
			officeColorPanel.relativePosition = new Vector3(xPos, yPos);
			officeColorPanel.ChosenColor = 7;

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

        public static UIButton CreateButton(UIComponent parent, float width, float height)
        { // thanks SamsamTS
            UIButton button = (UIButton)parent.AddUIComponent<UIButton>();
            button.width = width;
            button.height = height;
            button.normalBgSprite = "ButtonMenu";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.canFocus = false;
            return button;
        }

        public void saveButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Utils.SaveColors();
		}

		public void loadButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Utils.LoadColors();
			ShowCurrentZoneColorsInColorPickers();
		}

		public void resetButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			Debug.Log("reset Button Click");
			Utils.ResetToDefaultColors();
			ShowCurrentZoneColorsInColorPickers();
		}

		public void CloseButtonClick(UIComponent component, UIMouseEventParameter eventParam) {
			ToggleVisibility();
			ZoneColorChanger.Instance.UpdateUUIButtonStatus(isVisible);
		}

		public bool ToggleVisibility() { 
			if(isVisible) {
				Hide();
				return isVisible;
			}
			else {
				Show();
				return isVisible;
			}
		}

		private void ShowCurrentZoneColorsInColorPickers() { 
			lowResColorPanel.UpdateCurrentZoneColor();
			highResColorPanel.UpdateCurrentZoneColor();
			lowComColorPanel.UpdateCurrentZoneColor();
			highComColorPanel.UpdateCurrentZoneColor();
			indColorPanel.UpdateCurrentZoneColor();
			officeColorPanel.UpdateCurrentZoneColor();
		}
	}
}
