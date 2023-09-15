using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/FloorToPatchMap")]
public class FloorToPatchMap : ScriptableObject
{
    public enum FloorType
    {
        Wood,
        Carpet,
        Stone

    }

    public List<Patch> _materialPatches = new List<Patch>();


    public Patch GetPatch(FloorType inputType)
    {
        return _materialPatches[(int)inputType];
    }

    
}
