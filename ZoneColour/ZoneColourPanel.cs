using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;

namespace ZoneColour {
	class ZoneColourPanel : UIPanel {

		private UIColorField colorField;
		private UIColorField colorFIeldTemplate;

		private int chosenColour = 0;

		public UIPanel Parent { get; set; }

		public int ChosenColour {
			get { return chosenColour; }
			set { chosenColour = value; }
		}

		public override void Awake() {
			height = 40;
			width = 40;
		}

		public override void Start() {
			// The source code of the Move It mod helped fixing the color picker icon, thanks SamsamTS

			if(colorFIeldTemplate == null) {
				UIComponent template = UITemplateManager.Get("LineTemplate");
				if(template == null) return;

				colorFIeldTemplate = template.Find<UIColorField>("LineColor");
				if(colorFIeldTemplate == null) return;
			}

			colorField = Instantiate(colorFIeldTemplate.gameObject).GetComponent<UIColorField>();
			this.AttachUIComponent(colorField.gameObject);
			colorField.name = "ZoneColorPicker";
			colorField.size = new Vector2(40, 40);
			colorField.relativePosition = new Vector3(0, 0);
			colorField.pickerPosition = UIColorField.ColorPickerPosition.LeftAbove;
		   
			colorField.selectedColor = Singleton<ZoneManager>.instance.m_properties.m_zoneColors[ChosenColour];
			colorField.eventSelectedColorChanged += (component, value) => Utils.SetZoneColour(value, ChosenColour);
		}

		protected override void OnVisibilityChanged() {
			base.OnVisibilityChanged();

		}

		protected override void OnResolutionChanged(Vector2 previousResolution, Vector2 currentResolution) {
			base.OnResolutionChanged(previousResolution, currentResolution);
		}

		public void UpdateCurrentZoneColor() {
			colorField.selectedColor = Singleton<ZoneManager>.instance.m_properties.m_zoneColors[ChosenColour];
		}
	}
}
