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
    class ZoneColourPanel : UIPanel
    {
        private UIPanel colorPanel;
        private UIColorField colorField;
        private UIColorField colorFIeldTemplate;

        private int chosenColour = 0;

        public UIPanel Parent { get; set; }

        public int ChosenColour
        {
            get { return chosenColour; }
            set { chosenColour = value; }
        }

        public override void Awake()
        {
            height = 20;
            width = 20;
        }

        public override void Start()
        {

            if(colorFIeldTemplate == null) {
                UIComponent template = UITemplateManager.Get("LineTemplate");
                if(template == null) return;

                colorFIeldTemplate = template.Find<UIColorField>("LineColor");
                if(colorFIeldTemplate == null) return;
            }

            colorField = Instantiate(colorFIeldTemplate.gameObject).GetComponent<UIColorField>();
            this.AttachUIComponent(colorField.gameObject);
            colorField.name = "ZoneColorPicker";
            colorField.size = new Vector2(20, 20);
            colorField.relativePosition = new Vector3(0, 0);
            colorField.pickerPosition = UIColorField.ColorPickerPosition.LeftAbove;
           
            colorField.selectedColor = Singleton<ZoneManager>.instance.m_properties.m_zoneColors[ChosenColour];
            colorField.eventSelectedColorChanged += (component, value) => Utils.SetZoneColour(value, ChosenColour);
           
            /*
            textField.width = 40;
            textField.relativePosition = new Vector3(0, 0);
            textField.normalBgSprite = "TextFieldPanel";
            textField.hoveredBgSprite = "TextFieldPanelHovered";
            textField.focusedBgSprite = "TextFieldUnderline";

            textField.text = "0";

            textField.isInteractive = true;
            textField.enabled = true;
            textField.readOnly = false;
            textField.builtinKeyNavigation = true; 
             */
        }

        protected override void OnVisibilityChanged()
        {
            base.OnVisibilityChanged();

        }

        protected override void OnResolutionChanged(Vector2 previousResolution, Vector2 currentResolution)
        {
            base.OnResolutionChanged(previousResolution, currentResolution);
        }

    }
}
