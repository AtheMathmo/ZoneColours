using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ZoneColour {
    public class ZCMainUIPanel : UIPanel{
        private UIDragHandle _dragHandle;

        public override void Start() {
            base.Start();
            this.name = "ZCMainUIPanel";
            this.backgroundSprite = "GenericPanel";
            this.width = 360;
            this.height = 56;
            _dragHandle = (UIDragHandle)this.AddUIComponent(typeof(UIDragHandle));

            AddZoneColorPickers(this);
        }

        private void AddZoneColorPickers(UIPanel container) {
            int spriteWidth = 50;

            int xPos = 10;
            int yPos = 8;
            ZoneColourPanel lowResColourPanel = container.AddUIComponent<ZoneColourPanel>();
            lowResColourPanel.transform.parent = container.transform;
            lowResColourPanel.relativePosition = new Vector3(xPos, yPos);
            lowResColourPanel.ChosenColour = 2;

            xPos += spriteWidth;

            ZoneColourPanel highResColourPanel = container.AddUIComponent<ZoneColourPanel>();
            highResColourPanel.transform.parent = container.transform;
            highResColourPanel.relativePosition = new Vector3(xPos, yPos);
            highResColourPanel.ChosenColour = 3;

            xPos += spriteWidth;

            ZoneColourPanel lowComColourPanel = container.AddUIComponent<ZoneColourPanel>();
            lowComColourPanel.transform.parent = container.transform;
            lowComColourPanel.relativePosition = new Vector3(xPos, yPos);
            lowComColourPanel.ChosenColour = 4;

            xPos += spriteWidth;

            ZoneColourPanel highComColourPanel = container.AddUIComponent<ZoneColourPanel>();
            highComColourPanel.transform.parent = container.transform;
            highComColourPanel.relativePosition = new Vector3(xPos, yPos);
            highComColourPanel.ChosenColour = 5;

            xPos += spriteWidth;

            ZoneColourPanel IndColourPanel = container.AddUIComponent<ZoneColourPanel>();
            IndColourPanel.transform.parent = container.transform;
            IndColourPanel.relativePosition = new Vector3(xPos, yPos);
            IndColourPanel.ChosenColour = 6;

            xPos += spriteWidth;

            ZoneColourPanel OfficeColourPanel = container.AddUIComponent<ZoneColourPanel>();
            OfficeColourPanel.transform.parent = container.transform;
            OfficeColourPanel.relativePosition = new Vector3(xPos, yPos);
            OfficeColourPanel.ChosenColour = 7;

            xPos += spriteWidth;
            UIButton saveButton = CreateButton(container);
            saveButton.transform.parent = container.transform;
            saveButton.relativePosition = new Vector3(xPos, yPos + 4);
        }
        public static UIButton CreateButton(UIComponent parent) {
            UIButton button = (UIButton)parent.AddUIComponent<UIButton>();

            //button.atlas = GetAtlas("Ingame");

            button.width = 37;
            button.height = 31;
            //button.size = new Vector2(30f, 30f);
            button.textScale = 0.9f;
            button.normalBgSprite = "ButtonMenu";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.canFocus = false;

            return button;
        }
    }
}
