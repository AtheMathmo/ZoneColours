using ICities;

namespace ZoneColour {
	public class ZoneColourMod : IUserMod {
		public string Name {
			get { return "Zone Colours Revisited"; }
		}

		public string Description {
			get { return "Allows zone colour modification."; }
		}

		public void OnSettingsUI(UIHelperBase helper) {
			// there is no configuration because my programming skills are bad. couldn't figure out
			// how to do the keybind setting UI, so Ctrl+K is the UI shortcut.
	
			helper.AddTextfield("Toggle UI: Ctrl+K", "my programming skills are bad and the cities skylines modding api has very bad documentation, no keybind setting here", sel => {
				
			});
		}
	}
}
