
// This script is attached to Defender_4 Prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Bullets_Burst_Gun : MonoBehaviour
{

    [SerializeField] Add_Bullets Add_bullets = new Add_Bullets();
    private Bullets_Selector_UI bullets_selector_UI;

    private Burst_Gun burst_gun_script;
    private Money_Manager bullets_cost_money;
   


    private void Start() {

        if (Scene_Loader.current_scene == 11)
        {
            Add_bullets.ammo_count = 192;
        }

        burst_gun_script = FindObjectOfType<Burst_Gun>();
        bullets_cost_money = FindObjectOfType<Money_Manager>();  
        bullets_selector_UI = GameObject.Find("Burst Gun Bullets").GetComponent<Bullets_Selector_UI>();
    }

    private void OnMouseDown()
    {
        if (Bullets_Selector_UI.bullet_No[3] == true) { 
        
            if (Static_Fields.money >= Static_Fields.BG_ammo_cost && burst_gun_script.Burst_gun.bullet_count <= 0) { 
            
                burst_gun_script.Burst_gun.Add_Bullets(Add_bullets.ammo_count);
                bullets_cost_money.Deduct_Money(Static_Fields.BG_ammo_cost);

                Add_bullets.add_ammo_audio.Play();
                Change_Color_To_Black();
            }
            else
                GameObject.Find("Money Manager").GetComponent<AudioSource>().Play();
        }
    }



    private void Change_Color_To_Black() { 
    
        GameObject.Find("Burst Gun Bullets").GetComponent<SpriteRenderer>().color = Color.black;  
        Bullets_Selector_UI.bullet_No[3] = false;
        Bullets_Selector_UI.selected_bullet = false;
        bullets_selector_UI.color_is_white = false;
    }

   
}
