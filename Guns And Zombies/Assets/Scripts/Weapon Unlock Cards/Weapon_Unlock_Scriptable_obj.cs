using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Description", menuName = "Weapon Unlock scriptableobj")]
public class Weapon_Unlock_Scriptable_obj: ScriptableObject
{
    public Sprite image;
    public string name;

    [TextArea(10,10)] public string description;
}
