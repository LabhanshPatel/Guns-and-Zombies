using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spawning_Area : MonoBehaviour
{

    public bool clicked_spawn_area;
    
    private void OnMouseDown() {   
        clicked_spawn_area = true;      
    }

    private void OnMouseUp() {   
        clicked_spawn_area = false;
    }
}
