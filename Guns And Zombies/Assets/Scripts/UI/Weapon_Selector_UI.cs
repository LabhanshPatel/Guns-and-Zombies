using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Selector_UI : MonoBehaviour
{
    // static field
    private static bool[] instantiate_gun = { false, false, false, false, false };
  
    [SerializeField] GameObject[] Weapon_No;
    
    private Weapon_Spawning_Area spawning_area; 
    private Weapon_Spawner weapon_spawner;

    private bool can_instantiate;
    private int weapon_ID = 0;

    private Vector3 touch_pos;


    private void Start()
    {      
        spawning_area = FindObjectOfType<Weapon_Spawning_Area>();
        weapon_spawner = FindObjectOfType<Weapon_Spawner>();

        check_for_current_instance();
    }


    

    private void Update() { 
    
        Instantiate_Defenders();               
    }

    private void Instantiate_Defenders()
    {
         can_instantiate = spawning_area.clicked_spawn_area;


         for (int i = 0; i < Weapon_No.Length; i++) { 
        
            if (can_instantiate && instantiate_gun[i]) {

                if (Static_Fields.money >= Static_Fields.gun_cost[i])
                {                   
                    weapon_spawner.Spawn_Selector(Weapon_No[i]);
                }

                can_instantiate = false;
                instantiate_gun[i] = false;

                break;
            }
         }   
    }


   
    private void OnMouseDown() { 
    
        for(int i=0; i<Weapon_No.Length; i++) {
            if (i == (weapon_ID - 1))             
                instantiate_gun[i] = true;            
            else
                instantiate_gun[i] = false;
        }      
    }

    private void check_for_current_instance()
    {

        if (this.gameObject.name == "Hand Gun")
            weapon_ID = 1;
        else if (this.gameObject.name == "Assault Rifle")
            weapon_ID = 2;
        else if (this.gameObject.name == "Shot Gun")
            weapon_ID = 3;
        else if (this.gameObject.name == "Burst Gun")
            weapon_ID = 4;
        else if (this.gameObject.name == "Sniper Rifle")
            weapon_ID = 5;
    }

}
