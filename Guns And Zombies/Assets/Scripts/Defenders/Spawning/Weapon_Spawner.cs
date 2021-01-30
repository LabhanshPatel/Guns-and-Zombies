using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spawner : MonoBehaviour
{
    [HideInInspector]   public bool change_color_to_black_assault_rifle = false;
    [HideInInspector]   public bool change_color_to_black_hand_gun = false;
    [HideInInspector]   public bool change_color_to_black_shot_gun = false;
    [HideInInspector]   public bool change_color_to_black_burst_gun = false;
    [HideInInspector]   public bool change_color_to_black_sniper_rifle = false;

    [SerializeField] LayerMask layer_mask_sniper_rifle;

    private Gun_UI assault_rifle_ui;
    private Gun_UI hand_gun_ui;
    private Gun_UI shot_gun_ui;
    private Gun_UI burst_gun_ui;
    private Gun_UI sniper_rifle_ui;

    private Vector3 touch_pos;
    private bool allow_once = true;

    private Money_Manager money_manager;

    enum Gun_cost { HG =0, AR, SG, BG, SR}
    public void Start() { 
    
        money_manager = FindObjectOfType<Money_Manager>();

        hand_gun_ui = GameObject.Find("Hand Gun").GetComponent<Gun_UI>();
        assault_rifle_ui = GameObject.Find("Assault Rifle").GetComponent<Gun_UI>();
        shot_gun_ui = GameObject.Find("Shot Gun").GetComponent<Gun_UI>();
        burst_gun_ui = GameObject.Find("Burst Gun").GetComponent<Gun_UI>();
        sniper_rifle_ui = GameObject.Find("Sniper Rifle").GetComponent<Gun_UI>();

        
    }


    void Update() { 
    
        // SETTINGS FOR PC
           touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 



        // SETTINGS FOR ANDROID
     /*   if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touch_pos = Camera.main.ScreenToWorldPoint(touch.position);
            
        GameObject.Find("Play Space").transform.Find("Canvas(bg Music)").
                transform.Find("Background").GetComponent<Image>().color = new Color(1, 0, 1);
        } */

        if (hand_gun_ui.change_this_black_color)    
            change_color_to_black_hand_gun = false;       
        else if (assault_rifle_ui.change_this_black_color)         
            change_color_to_black_assault_rifle = false;       
        else if (shot_gun_ui.change_this_black_color)          
            change_color_to_black_shot_gun = false;       
        else if (burst_gun_ui.change_this_black_color)         
            change_color_to_black_burst_gun = false;        
        else if (sniper_rifle_ui.change_this_black_color)         
            change_color_to_black_sniper_rifle = false;
        
    }



    public void Spawn_Selector(GameObject weapon_prefab)
    {
        if (weapon_prefab.name == "Defender_1" && hand_gun_ui.allow_instantiation) {
            hand_gun_ui.is_selected = false;

            change_color_to_black_hand_gun = true;
            Instantiate(weapon_prefab, new Vector3((int)this.touch_pos.x + 1f, (int)this.touch_pos.y + 0.2f, -2f), Quaternion.identity);

            if (hand_gun_ui.change_weapon_color.a >= 1)
                money_manager.Deduct_Money(Static_Fields.gun_cost[(int)Gun_cost.HG]);

        }
        else if (weapon_prefab.name == "Defender_2" && assault_rifle_ui.allow_instantiation) {
            assault_rifle_ui.is_selected = false;

            change_color_to_black_assault_rifle = true;
            Instantiate(weapon_prefab, new Vector3((int)this.touch_pos.x + 0.5f, (int)this.touch_pos.y + 0.7f, -2f), Quaternion.identity);

            if (assault_rifle_ui.change_weapon_color.a >= 1)
                money_manager.Deduct_Money(Static_Fields.gun_cost[(int)Gun_cost.AR]);
        }
        else if (weapon_prefab.name == "Defender_3" && shot_gun_ui.allow_instantiation) {
            shot_gun_ui.is_selected = false;

            change_color_to_black_shot_gun = true;
            Instantiate(weapon_prefab, new Vector3((int)this.touch_pos.x + 1.5f, (int)this.touch_pos.y + 0.5f, -2f), Quaternion.identity);

            if (shot_gun_ui.change_weapon_color.a >= 1)
                money_manager.Deduct_Money(Static_Fields.gun_cost[(int)Gun_cost.SG]);
        }
        else if (weapon_prefab.name == "Defender_4" && burst_gun_ui.allow_instantiation) {
            burst_gun_ui.is_selected = false;

            change_color_to_black_burst_gun = true;
            Instantiate(weapon_prefab, new Vector3((int)this.touch_pos.x + 3.1f, (int)this.touch_pos.y, -2f), Quaternion.identity);

            if (burst_gun_ui.change_weapon_color.a >= 1)
                money_manager.Deduct_Money(Static_Fields.gun_cost[(int)Gun_cost.BG]);
        }
        else if (weapon_prefab.name == "Defender_5" && sniper_rifle_ui.allow_instantiation) {
            sniper_rifle_ui.is_selected = false;

            bool allow_instantiation = Physics2D.Raycast(new Vector2((int)this.touch_pos.x, (int)this.touch_pos.y + 0.5f),
                                                         Vector2.right, 1.2f, layer_mask_sniper_rifle);

            if ((allow_instantiation == false) || allow_once) {
                change_color_to_black_sniper_rifle = true;

                if (sniper_rifle_ui.change_weapon_color.a >= 1)
                    money_manager.Deduct_Money(Static_Fields.gun_cost[(int)Gun_cost.SR]);
                allow_once = false;
                Instantiate(weapon_prefab, new Vector3((int)this.touch_pos.x + 1f, (int)this.touch_pos.y + 0.7f, -2f), Quaternion.identity);
            }
        }               
        
        
    }

  
}
