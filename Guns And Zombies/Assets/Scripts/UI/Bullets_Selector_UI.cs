using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_Selector_UI : MonoBehaviour
{
    // static fields
    public static bool selected_bullet = false;
    public static bool[] bullet_No = { false, false, false, false, false };

    private int weapon_ID = 0;
    [HideInInspector] public bool color_is_white = false;

    private bool is_triggered = true;

    private bool flag_1 = false;
    private bool flag_2 = false;


    private void Start() {    
        check_for_current_instance();
    }

    private void Update()
    {
        if (bullet_No[weapon_ID - 1] == true ) {      
            if(flag_1 == true) { 
               GetComponent<SpriteRenderer>().color = Color.white;
               color_is_white = true;

               flag_1 = false;
            }
        }
        else if (flag_2 == true) {        
            GetComponent<SpriteRenderer>().color = Color.black;
            flag_2 = false;
        }
    }

    private void OnMouseOver() { 
        if(is_triggered == true && selected_bullet == false)
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
     

    private void OnMouseDown()
    {

        is_triggered = false;
        selected_bullet = true;

        if (color_is_white == true) {        

            if (bullet_No[weapon_ID - 1] == true) {             

                selected_bullet = false;
                is_triggered = true;

                bullet_No[weapon_ID - 1] = false;
            }

            color_is_white = false;
        }
        else { 
        
            for (int i = 0; i < bullet_No.Length; i++) { 
            
                if (i == weapon_ID - 1) {                
                    bullet_No[i] = true;
                    flag_1 = true;
                }
                else {                
                    bullet_No[i] = false;
                    flag_2 = true;
                }
            }

        }
  
    }


    private void OnMouseExit() { 
        if(selected_bullet == false)
            GetComponent<SpriteRenderer>().color = Color.black;
        is_triggered = true;
    }



    private void check_for_current_instance() { 
    
        if (this.gameObject.name == "Hand Gun Bullets")
            weapon_ID = 1;
        else if (this.gameObject.name == "Assault Rifle Bullets")
            weapon_ID = 2;
        else if (this.gameObject.name == "Shot Gun Bullets")
            weapon_ID = 3;
        else if (this.gameObject.name == "Burst Gun Bullets")
            weapon_ID = 4;
        else if (this.gameObject.name == "Sniper Rifle Bullets")
            weapon_ID = 5;
    }
}
