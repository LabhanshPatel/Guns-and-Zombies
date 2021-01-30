
// This script is attached to Defender_1 Prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Bullets_Hand_Gun : MonoBehaviour
{
    [SerializeField] Add_Bullets Add_bullets = new Add_Bullets();
    private Bullets_Selector_UI bullets_selector_UI;

    private Hand_Gun hand_gun_script;
    private Money_Manager bullets_cost_money;
    
    private void Start() {
        if (Scene_Loader.current_scene == 11)
        {
            Add_bullets.ammo_count = 500;
        }


        hand_gun_script = FindObjectOfType<Hand_Gun>();
        bullets_cost_money = FindObjectOfType<Money_Manager>();
        bullets_selector_UI = GameObject.Find("Hand Gun Bullets").GetComponent<Bullets_Selector_UI>();
    }

    private void OnMouseDown()
    {

        if (Bullets_Selector_UI.bullet_No[0] == true) {     

            if (Static_Fields.money >= Static_Fields.HG_ammo_cost && hand_gun_script.Hand_gun.bullet_count <= 0) {
          
                hand_gun_script.Hand_gun.Add_Bullets(Add_bullets.ammo_count);
                bullets_cost_money.Deduct_Money(Static_Fields.HG_ammo_cost);

                Add_bullets.add_ammo_audio.Play();
                Change_Color_To_Black();
            }
            else
                GameObject.Find("Money Manager").GetComponent<AudioSource>().Play();
        }
    }



    private void Change_Color_To_Black() { 
    
        GameObject.Find("Hand Gun Bullets").GetComponent<SpriteRenderer>().color = Color.black;  
        Bullets_Selector_UI.bullet_No[0] = false;
        Bullets_Selector_UI.selected_bullet = false;
        bullets_selector_UI.color_is_white = false;

      
    }

}
