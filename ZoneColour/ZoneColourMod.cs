using ICities;
using System;

namespace ZoneColour
{
	public class ZoneColourMod : IUserMod
	{
		public string Name
		{
			get { return "Zone Colours Revisited"; }
		}

		public string Description
		{
			get { return "Allows zone colour modification."; }
		}


		// Sets up a settings user interface
		public void OnSettingsUI(UIHelperBase helper) {
			// there is no configuration because my programming skills are bad. couldn't figure out
			// how to do the keybind setting UI, so Ctrl+K is the UI shortcut.

			// ZoneColourRevisitedConfiguration config = Configuration<ZoneColourRevisitedConfiguration>.Load();

	
			helper.AddTextfield("Toggle UI: Ctrl+K", "my programming skills are bad and the cities skylines modding api has very bad documentation, no keybind setting here", sel => {
				
			});

		}

		// Returns the index number of the option that is currently selected
/*		private int GetSelectedOptionIndex(string value) {
			int index = Array.IndexOf(OptionValues, value);
			if(index < 0) index = 0;

			return index;
		}*/
	}
}
