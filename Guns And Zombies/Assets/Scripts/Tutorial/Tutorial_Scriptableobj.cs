using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Description", menuName = "Tutorial scriptableobj")]
public class Tutorial_Scriptableobj : ScriptableObject
{
    
    [TextArea(10,10)] public List<string> description;
}
