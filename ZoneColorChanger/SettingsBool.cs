using ColossalFramework;
using ColossalFramework.UI;

// copied from Roundabout Builder, thank you

namespace ZoneColorChanger {
	public class SettingsBool : SavedBool {
		public string Description { get; private set; }
		public string Tooltip { get; private set; }

		public SettingsBool(string description, string tooltip, string name,  bool defaultValue) : base(name, ModInfo.settingsFileName, defaultValue, true) {
			this.Description = description;
			this.Tooltip = tooltip;
			
		}

		public UICheckBox Draw(UIHelper group, ICities.OnCheckChanged callback = null) {
			UICheckBox chb;
			chb = (UICheckBox)group.AddCheckbox(Description, this.value, (b) => {
				this.value = b;
				if (callback != null) callback.Invoke(b);
			});
			chb.tooltip = Tooltip;
			return chb;
		}
	}
}
