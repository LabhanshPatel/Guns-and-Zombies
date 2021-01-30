
// This script is attached to Defender_3 Prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Bullets_Shot_Gun : MonoBehaviour
{
    [SerializeField] Add_Bullets Add_bullets = new Add_Bullets();
    private Bullets_Selector_UI bullets_selector_UI;

    private Shot_Gun shot_gun_script;
    private Money_Manager bullets_cost_money;
  
    private void Start() {
        if (Scene_Loader.current_scene == 11)
        {
            Add_bullets.ammo_count = 48;
        }

        shot_gun_script = FindObjectOfType<Shot_Gun>();
        bullets_cost_money = FindObjectOfType<Money_Manager>();
        bullets_selector_UI = GameObject.Find("Shot Gun Bullets").GetComponent<Bullets_Selector_UI>();
    }


    private void OnMouseDown() {
        if (Bullets_Selector_UI.bullet_No[2] == true) {

            if (Static_Fields.money >= Static_Fields.SG_ammo_cost && shot_gun_script.Shot_gun.bullet_count <= 0) {

                shot_gun_script.Shot_gun.Add_Bullets(Add_bullets.ammo_count);
                bullets_cost_money.Deduct_Money(Static_Fields.SG_ammo_cost);

                Add_bullets.add_ammo_audio.Play();
                Change_Color_To_Black();
            }
            else
                GameObject.Find("Money Manager").GetComponent<AudioSource>().Play();

        } 
    }



    private void Change_Color_To_Black() { 
    
        GameObject.Find("Shot Gun Bullets").GetComponent<SpriteRenderer>().color = Color.black;
        Bullets_Selector_UI.bullet_No[2] = false;
        Bullets_Selector_UI.selected_bullet = false;
        bullets_selector_UI.color_is_white = false;
    }

 
    
}
