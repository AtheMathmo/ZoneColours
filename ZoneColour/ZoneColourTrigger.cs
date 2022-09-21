using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ColossalFramework.IO;
using ColossalFramework.Math;
using ColossalFramework.Threading;
using ICities;
using UnityEngine;

namespace ZoneColour
{
	public class ZoneColourTrigger : ThreadingExtensionBase
	{
		private static Color[] defaultColours;

		public static Color[] DefaultColours
		{
			get { return defaultColours; }
			set { defaultColours = value; }
		}

		public override void OnCreated(IThreading threading) {
		}

		public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
		{
			/*	
 			if (Input.GetKeyDown(KeyCode.K)) {
				Debug.Log("K Pressed.");
				Utils.SetZoneColours(defaultColours);
			}*/ 
		}
	}
}
