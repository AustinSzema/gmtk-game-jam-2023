using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    //example : public static readonly Evt eventName = new Evt();
    //example for param : public static readonly Evt<type for param> eventName = new Evt<type for param>();

    //public static readonly Evt<HexTile> OnClickTile = new Evt<HexTile>();
    //public static readonly Evt<HexTile> OnHighlightTile = new Evt<HexTile>();
    //public static readonly Evt<GameObject> UserInterfaceSelectUpdate = new Evt<GameObject>();

    //public static readonly Evt<VisualSoundPresets, Vector2> SpawnSound = new Evt<VisualSoundPresets, Vector2>();
    public static readonly Evt<VisualSoundPresets, Vector2, float> SpawnUIVisualSound = new Evt<VisualSoundPresets, Vector2, float>();
    public static readonly Evt<VisualSoundPresets, Vector2, float> SpawnWorldSpaceSound = new Evt<VisualSoundPresets, Vector2, float>();
}
