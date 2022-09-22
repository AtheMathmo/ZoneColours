using ICities;
using UnityEngine;

namespace ZoneColour {
	public class ZCThreading : ThreadingExtensionBase {
		private bool _keyProcessed = false;

		public override void OnUpdate(float realTimeDelta, float b) {
			base.OnUpdate();


			if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.K)) {
				// cancel if they key input was already processed in a previous frame
				if(_keyProcessed) return;

				_keyProcessed = true;
				Utils.ToggleUIPanelVisibility();
				Debug.Log("Keyboard: Strg+K");
			}
			else {
				// not both keys pressed: Reset processed state
				_keyProcessed = false;
			}
		}
	}
}
