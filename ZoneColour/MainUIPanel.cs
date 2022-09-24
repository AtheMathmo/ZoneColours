using ColossalFramework.UI;
using UnityEngine;

namespace ZoneColour {
	public class MainUIPanel : UIPanel{
		private UIDragHandle _dragHandle;

		ColourPicker lowResColourPanel;
		ColourPicker highResColourPanel;
		ColourPicker lowComColourPanel;
		ColourPicker highComColourPanel;
		ColourPicker IndColourPanel;
		ColourPicker OfficeColourPanel;

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
			this.backgroundSprite = "GenericPanel";
			this.width = 488;
			this.height = 56;
			_dragHandle = (UIDragHandle)this.AddUIComponent(typeof(UIDragHandle));

			AddZoneColorPickers(this);
			this.Hide();
		}

		private void AddZoneColorPickers(UIPanel container) {
			int spriteWidth = 50;

			int xPos = 10;
			int yPos = 8;
			lowResColourPanel = container.AddUIComponent<ColourPicker>();
			lowResColourPanel.transform.parent = container.transform;
			lowResColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowResColourPanel.ChosenColour = 2;

			xPos += spriteWidth;

			highResColourPanel = container.AddUIComponent<ColourPicker>();
			highResColourPanel.transform.parent = container.transform;
			highResColourPanel.relativePosition = new Vector3(xPos, yPos);
			highResColourPanel.ChosenColour = 3;

			xPos += spriteWidth;

			lowComColourPanel = container.AddUIComponent<ColourPicker>();
			lowComColourPanel.transform.parent = container.transform;
			lowComColourPanel.relativePosition = new Vector3(xPos, yPos);
			lowComColourPanel.ChosenColour = 4;

			xPos += spriteWidth;

			highComColourPanel = container.AddUIComponent<ColourPicker>();
			highComColourPanel.transform.parent = container.transform;
			highComColourPanel.relativePosition = new Vector3(xPos, yPos);
			highComColourPanel.ChosenColour = 5;

			xPos += spriteWidth;

			IndColourPanel = container.AddUIComponent<ColourPicker>();
			IndColourPanel.transform.parent = container.transform;
			IndColourPanel.relativePosition = new Vector3(xPos, yPos);
			IndColourPanel.ChosenColour = 6;

			xPos += spriteWidth;

			OfficeColourPanel = container.AddUIComponent<ColourPicker>();
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
