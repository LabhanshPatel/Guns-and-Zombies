// This script is attached to Defender_2 Prefab


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Bullets_Assault_Rifle : MonoBehaviour
{

    [SerializeField] Add_Bullets Add_bullets = new Add_Bullets();

    private Bullets_Selector_UI bullets_selector_UI;
    private Assault_Rifle assualt_rifle_script;
    private Money_Manager money_manager;
    
    

    private void Start() {

        if(Scene_Loader.current_scene == 11)
        {
            Add_bullets.ammo_count = 300;
        }

        assualt_rifle_script = FindObjectOfType<Assault_Rifle>();
        money_manager = FindObjectOfType<Money_Manager>();
        bullets_selector_UI = GameObject.Find("Assault Rifle Bullets").GetComponent<Bullets_Selector_UI>();
    }


    private void OnMouseDown() {

        if (Bullets_Selector_UI.bullet_No[1] == true) {

            if (Static_Fields.money >= Static_Fields.AR_ammo_cost && assualt_rifle_script.Assault_rifle.bullet_count <= 0)
            {

                assualt_rifle_script.Assault_rifle.Add_Bullets(Add_bullets.ammo_count);
                money_manager.Deduct_Money(Static_Fields.AR_ammo_cost);

                Add_bullets.add_ammo_audio.Play();
                Change_Color_To_Black();


            }
            else
                GameObject.Find("Money Manager").GetComponent<AudioSource>().Play();

        }
    }



    private void Change_Color_To_Black() { 
    
        GameObject.Find("Assault Rifle Bullets").GetComponent<SpriteRenderer>().color = Color.black;
        Bullets_Selector_UI.bullet_No[1] = false;
        Bullets_Selector_UI.selected_bullet = false;
        bullets_selector_UI.color_is_white = false;
    }



}
