# ZoneColorChanger

https://steamcommunity.com/workshop/filedetails/?id=2867708583

Zone Color Changer is a mod for Cities Skylines which allows changing the default colors of the rico (residential, industrial, commercial, offices) zones. Useful for players with color issues like color-blindness or who don't like the default colors. 

It is a continuation of the mod Zone Colours by [AtheMathmo](https://github.com/AtheMathmo).

The mod provides an option to change color of each zone type, the icons in the zoning panel are not affected. (would be a great feature) The color profile is stored in in \AppData\Local\Colossal Order\Cities_Skylines\ModConfig\zone-color-changer.cfg like the original mod did. 

The color pickers have been in the zoning panel above the rico icons. Was cool but the colorfield always expanded to the bottom (even if set to top, something with border wrapping I think, couldn't solve it) with lower half out of the screen. So the color pickers are in their own UI Panel now, the toggle keybind (default Ctrl+K) can be set in mod option panel (which doesn't remember its position on reload). They are not labeled but in same order as in the zoning panel, should be obvious and I didn't want to clutter the UI. Taking the color pickers out of the zoning panel solved the random crash at newgame bug in the original mod. It tried to access the zoning panel before it was unlocked or something like that. 

The old mod did only save at OnLevelUnloading(), fast return to desktop and crashes would not save the profile, so three buttons (I could not figure out how to load custom sprites I gave up) were added:

* save current (and overwrite a previously saved) color profile to the .cfg file
* load previously saved color profile from the .cfg file
* reset to default color profile (but do not save the profile)

The mod is not perfect and the color pickers in an own panel seems like a step back, but it's working. Some "design decisions" are results of bad programming skills. I did not find any other mod providing the feature this mod does (if there is any pls let me know). 
Suggestions and contributions are welcome :-)
