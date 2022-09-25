using ColossalFramework.UI;
using UnityEngine;

namespace ZoneColorChanger {
	public class MainUIPanel : UIPanel {

		private UIDragHandle _dragHandle;

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
			_dragHandle = (UIDragHandle)this.AddUIComponent(typeof(UIDragHandle));

			this.backgroundSprite = "GenericPanel";
			this.width = 488;
			this.height = 56;

			AddZoneColorPickers(this);
			this.Hide();
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

		public void ToggleVisibility() {
			if(isVisible) {
				Hide();
			}
			else {
				Show();
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
