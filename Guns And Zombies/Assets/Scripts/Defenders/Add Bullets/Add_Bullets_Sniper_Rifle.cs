
// This script is attached to Defender_5 Prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Bullets_Sniper_Rifle : MonoBehaviour
{
    [SerializeField] Add_Bullets Add_bullets = new Add_Bullets();
    private Bullets_Selector_UI bullets_selector_UI;

    private Sniper_Rifle sniper_rifle_script;
    private Money_Manager bullets_cost_money;
    


    private void Start() {       
        sniper_rifle_script = FindObjectOfType<Sniper_Rifle>();
        bullets_cost_money = FindObjectOfType<Money_Manager>(); 
        bullets_selector_UI = GameObject.Find("Sniper Rifle Bullets").GetComponent<Bullets_Selector_UI>();
    }


    private void OnMouseDown() { 
    
        if (Bullets_Selector_UI.bullet_No[4] == true) {        
            if (Static_Fields.money >= Static_Fields.SR_ammo_cost && sniper_rifle_script.Sniper_rifle.bullet_count <= 0) {             
                sniper_rifle_script.Sniper_rifle.Add_Bullets(Add_bullets.ammo_count);
                bullets_cost_money.Deduct_Money(Static_Fields.SR_ammo_cost);

                Add_bullets.add_ammo_audio.Play();
                Change_Color_To_Black();
            }
            else
                GameObject.Find("Money Manager").GetComponent<AudioSource>().Play();
        }
    }
    private void Change_Color_To_Black() { 
    
        GameObject.Find("Sniper Rifle Bullets").GetComponent<SpriteRenderer>().color = Color.black;
        Bullets_Selector_UI.bullet_No[4] = false;
        Bullets_Selector_UI.selected_bullet = false;
        bullets_selector_UI.color_is_white = false;
    }





}
